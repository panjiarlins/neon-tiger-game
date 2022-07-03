Imports System.IO

Public Enum StateNeonTiger
    IntroStart
    IntroEnd
    Stand
    ShotBlock
    RaySplasher1
    JumpUpStart
    JumpUp
    JumpUpEnd
    Creep
    RaySplasher2
    JumpDownGoingUp
    JumpDownGoingDown
    JumpDownCreep
    JumpDown
    JumpDownEnd
    DiveAttackStart
    DiveAttackEnd
    RushAttackStart
    RushAttackHorizontal
    RushAttackJumpUpStart
    RushAttackJumpUp
    RushAttackUpperCut
    RushAttackJumpDown
    RushAttackEnd
    Stun
    WaitForDecisionAfterShotBlock
    WaitForDecisionAfterRaySplasher2
    WaitForDecisionAfterRushAttackEnd
End Enum

Public Enum StateNeonTigerProjectile
    ProjRaySplasher
End Enum

Public Enum StateMegaMan
    Intro
    Stand
    MoveLeft
    MoveRight
    JumpUpStart
    JumpUp
    JumpDown
    JumpDownEnd
    Shoot
    JumpShoot
    JumpMoveLeft
    JumpMoveRight
    Stun
    RecallStart
    RecallEnd
End Enum

Public Enum StateMegaManProjectile
    Shoot
End Enum

Public Enum FaceDir
    Left
    Right
End Enum

Public Class CImage
    Public Width As Integer
    Public Height As Integer
    Public Elmt(,) As System.Drawing.Color
    Public ColorMode As Integer 'not used

    Sub OpenImage(ByVal FName As String)
        Dim s As String
        Dim L As Long
        Dim BR As BinaryReader
        Dim h, w, pos As Integer
        Dim r, g, b As Integer
        Dim pad As Integer

        BR = New BinaryReader(File.Open(FName, FileMode.Open))

        Try
            BlockRead(BR, 2, s)

            If s <> "BM" Then
                MessageBox.Show("Not a BMP file")
            Else 'BMP file
                BlockReadInt(BR, 4, L) 'size
                'MsgBox("Size = " + CStr(L))
                BlankRead(BR, 4) 'reserved
                BlockReadInt(BR, 4, pos) 'start of data
                BlankRead(BR, 4) 'size of header
                BlockReadInt(BR, 4, Width) 'width
                'MsgBox("Width = " + CStr(I.Width))
                BlockReadInt(BR, 4, Height) 'height
                'MsgBox("Height = " + CStr(I.Height))
                BlankRead(BR, 2) 'color panels
                BlockReadInt(BR, 2, ColorMode) 'colormode
                If ColorMode <> 24 Then
                    MessageBox.Show("Not a 24-bit color BMP")
                Else

                    BlankRead(BR, pos - 30)

                    ReDim Elmt(Width - 1, Height - 1)
                    pad = (4 - (Width * 3 Mod 4)) Mod 4

                    For h = Height - 1 To 0 Step -1
                        For w = 0 To Width - 1
                            BlockReadInt(BR, 1, b)
                            BlockReadInt(BR, 1, g)
                            BlockReadInt(BR, 1, r)
                            Elmt(w, h) = Color.FromArgb(r, g, b)

                        Next
                        BlankRead(BR, pad)
                    Next
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error")
        End Try

        BR.Close()
    End Sub

    Sub CreateMask(ByRef Mask As CImage)
        Dim i, j As Integer

        Mask = New CImage
        Mask.Width = Width
        Mask.Height = Height

        ReDim Mask.Elmt(Mask.Width - 1, Mask.Height - 1)

        For i = 0 To Width - 1
            For j = 0 To Height - 1
                If Elmt(i, j).R = 0 And Elmt(i, j).G = 0 And Elmt(i, j).B = 0 Then
                    Mask.Elmt(i, j) = Color.FromArgb(255, 255, 255)
                Else
                    Mask.Elmt(i, j) = Color.FromArgb(0, 0, 0)
                End If
            Next
        Next
    End Sub

    Sub CopyImg(ByRef Img As CImage)
        'copies image to Img
        Img = New CImage
        Img.Width = Width
        Img.Height = Height
        ReDim Img.Elmt(Width - 1, Height - 1)

        For i = 0 To Width - 1
            For j = 0 To Height - 1
                Img.Elmt(i, j) = Elmt(i, j)
            Next
        Next
    End Sub
End Class

Public Class CCharacter
    Public Autoplayer As Boolean = True
    Public PosX, PosY As Double
    Public Vx, Vy As Double
    Public FrameIdx As Integer
    Public CurrFrame As Integer
    Public ArrSprites() As CArrFrame
    Public IdxArrSprites As Integer
    Public FDir As FaceDir
    Public Destroy As Boolean = False
    Public IsNTP As Boolean = False
    Public IsMMP As Boolean = False
    Public startMovingPosition As Integer 'for HomingMotion()
    Public StunStartPosition As Integer = 0 'for HomingMotion()

    Public Sub GetNextFrame()
        CurrFrame = CurrFrame + 1
        If CurrFrame = ArrSprites(IdxArrSprites).Elmt(FrameIdx).MaxFrameTime Then
            FrameIdx = FrameIdx + 1
            If FrameIdx = ArrSprites(IdxArrSprites).N Then
                FrameIdx = 0
            End If
            CurrFrame = 0
        End If
    End Sub

    Public Sub HomingMotion(Top As Integer, Bottom As Integer, LDside As Integer, RDside As Integer, destinationY As Integer, isGoingUp As Boolean)
        If Vx = 0 And Vy = 0 Then
            startMovingPosition = PosX
        End If
        Dim destX, destY, dx, dy, z As Integer
        Dim dir As Double
        Dim turnrate As Double = 5 * Math.PI / 180
        If FDir = FaceDir.Left Then
            If isGoingUp Then
                dir = ((((Math.Atan((Bottom - Top) / (startMovingPosition - LDside)) * 180) / Math.PI) + 180) * Math.PI / 180)
            Else
                dir = 180 - ((Math.Atan((Bottom - Top) / (startMovingPosition - LDside)) * 180) / Math.PI)
                dir = dir * Math.PI / 180
            End If
            destX = LDside
            destY = destinationY
            dx = destX - PosX
            dy = destY - PosY
        Else
            If isGoingUp Then
                dir = 360 - ((Math.Atan((Bottom - Top) / (RDside - startMovingPosition)) * 180) / Math.PI)
                dir = dir * Math.PI / 180
            Else
                dir = Math.Atan((Bottom - Top) / (RDside - startMovingPosition))
            End If
            destX = RDside
            destY = destinationY
            dx = destX - PosX
            dy = destY - PosY
        End If
        Vx = 8 * Math.Cos(dir)
        Vy = 8 * Math.Sin(dir)
        z = Vx * dy - Vy * dx
        If z > 0 Then
            dir += turnrate
        ElseIf z < 0 Then
            dir -= turnrate
        End If
        Vx = 8 * Math.Cos(dir)
        Vy = 8 * Math.Sin(dir)
    End Sub

    Public Overridable Sub Update()

    End Sub
End Class

Public Class CCharNeonTiger
    Inherits CCharacter
    Public CurrState As StateNeonTiger
    Public IsEnemyOnRightSide As Boolean
    Public StunTrigger As Boolean = True

    Public Sub State(state As StateNeonTiger, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub

    Public Sub ChangeFaceDirection()
        If IsEnemyOnRightSide Then
            FDir = FaceDir.Right
        Else
            FDir = FaceDir.Left
        End If
        If CurrState = StateNeonTiger.RaySplasher1 Or CurrState = StateNeonTiger.RaySplasher2 Then
            If FDir = FaceDir.Left Then
                FDir = FaceDir.Right
            Else
                FDir = FaceDir.Left
            End If
        End If
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
            Case StateNeonTiger.IntroStart
                PosY += Vy
                GetNextFrame()
                If PosY >= 274 Then
                    State(StateNeonTiger.IntroEnd, 1)
                    PosY = 279
                    Vx = 0
                    Vy = 0
                End If

            Case StateNeonTiger.IntroEnd
                GetNextFrame()
                If FrameIdx = 11 Then
                    State(StateNeonTiger.Stand, 2)
                End If

            Case StateNeonTiger.Stand
                GetNextFrame()
                If FrameIdx = 1 Then
                    If Autoplayer Then
                        Dim i As Double = Rnd()
                        If i < 0.25 Then
                            State(StateNeonTiger.RaySplasher1, 4)
                        ElseIf i >= 0.25 And i < 0.5 Then
                            State(StateNeonTiger.JumpUpStart, 5)
                        ElseIf i >= 0.5 And i < 0.75 Then
                            State(StateNeonTiger.RushAttackStart, 17)
                        Else
                            State(StateNeonTiger.ShotBlock, 3)
                        End If
                        ChangeFaceDirection()
                    End If
                End If

            Case StateNeonTiger.ShotBlock
                GetNextFrame()
                If FrameIdx = 5 Then
                    If Autoplayer Then
                        Dim i As Double = Rnd()
                        If i < 0.33 Then
                            State(StateNeonTiger.RaySplasher1, 4)
                        ElseIf i >= 0.33 And i < 0.66 Then
                            State(StateNeonTiger.JumpUpStart, 5)
                        Else
                            State(StateNeonTiger.RushAttackStart, 17)
                        End If
                        ChangeFaceDirection()
                    Else
                        State(StateNeonTiger.WaitForDecisionAfterShotBlock, 2)
                    End If
                End If

            Case StateNeonTiger.WaitForDecisionAfterShotBlock
                FrameIdx = 1
                If Autoplayer Then
                    Dim i As Double = Rnd()
                    If i < 0.33 Then
                        State(StateNeonTiger.RaySplasher1, 4)
                    ElseIf i >= 0.33 And i < 0.66 Then
                        State(StateNeonTiger.JumpUpStart, 5)
                    Else
                        State(StateNeonTiger.RushAttackStart, 17)
                    End If
                    ChangeFaceDirection()
                End If

            Case StateNeonTiger.RaySplasher1
                If Not Autoplayer And FrameIdx = 0 And CurrFrame = 0 Then
                    If FDir = FaceDir.Left Then
                        FDir = FaceDir.Right
                    Else
                        FDir = FaceDir.Left
                    End If
                End If
                GetNextFrame()
                If FrameIdx = 25 Then
                    State(StateNeonTiger.Stand, 2)
                    If Autoplayer Then
                        ChangeFaceDirection()
                    Else
                        If FDir = FaceDir.Left Then
                            FDir = FaceDir.Right
                        Else
                            FDir = FaceDir.Left
                        End If
                    End If
                End If

            Case StateNeonTiger.JumpUpStart
                GetNextFrame()
                If FrameIdx = 1 Then
                    State(StateNeonTiger.JumpUp, 6)
                End If

            Case StateNeonTiger.JumpUp
                HomingMotion(150, 279, 42, 356, 150, True)
                PosX += Vx
                PosY += Vy
                GetNextFrame()
                If (PosX <= 42 Or PosX >= 356) Then
                    State(StateNeonTiger.JumpUpEnd, 7)
                    If PosX <= 42 Then
                        PosX = 36
                    ElseIf PosX >= 356 Then
                        PosX = 361
                    End If
                    Vx = 0
                    Vy = 0
                End If

            Case StateNeonTiger.JumpUpEnd
                GetNextFrame()
                If FrameIdx = 1 Then
                    State(StateNeonTiger.Creep, 8)
                    If FDir = FaceDir.Left Then
                        FDir = FaceDir.Right
                    Else
                        FDir = FaceDir.Left
                    End If
                End If

            Case StateNeonTiger.Creep
                GetNextFrame()
                If FrameIdx = 1 Then
                    If Autoplayer Then
                        Dim i As Double = Rnd()
                        If i < 0.33 Then
                            State(StateNeonTiger.RaySplasher2, 9)
                        ElseIf i >= 0.33 And i < 0.66 Then
                            State(StateNeonTiger.JumpDownGoingUp, 10)
                        Else
                            State(StateNeonTiger.DiveAttackStart, 15)
                        End If
                        ChangeFaceDirection()
                    End If
                End If

            Case StateNeonTiger.RaySplasher2
                If Not Autoplayer And FrameIdx = 0 And CurrFrame = 0 Then
                    If FDir = FaceDir.Left Then
                        FDir = FaceDir.Right
                    Else
                        FDir = FaceDir.Left
                    End If
                End If
                GetNextFrame()
                If FrameIdx = 26 Then
                    If FDir = FaceDir.Left Then
                        FDir = FaceDir.Right
                    Else
                        FDir = FaceDir.Left
                    End If
                    If Autoplayer = True Then
                        Dim i As Double = Rnd()
                        If i < 0.5 Then
                            State(StateNeonTiger.JumpDownGoingUp, 10)
                        Else
                            State(StateNeonTiger.DiveAttackStart, 15)
                        End If
                        ChangeFaceDirection()
                    Else
                        State(StateNeonTiger.WaitForDecisionAfterRaySplasher2, 8)
                    End If
                End If

            Case StateNeonTiger.WaitForDecisionAfterRaySplasher2
                If Autoplayer Then
                    Dim i As Double = Rnd()
                    If i < 0.5 Then
                        State(StateNeonTiger.JumpDownGoingUp, 10)
                    Else
                        State(StateNeonTiger.DiveAttackStart, 15)
                    End If
                    ChangeFaceDirection()
                End If

            Case StateNeonTiger.JumpDownGoingUp
                HomingMotion(68, 150, 254, 144, 68, True)
                PosX += Vx
                PosY += Vy
                GetNextFrame()
                If PosY <= 68 Then
                    State(StateNeonTiger.JumpDownGoingDown, 11)
                    PosY = 71
                    Vx = 0
                    Vy = 0
                End If

            Case StateNeonTiger.JumpDownGoingDown
                HomingMotion(71, 200, 49, 349, 200, False)
                PosX += Vx
                PosY += Vy
                GetNextFrame()
                If PosX <= 49 Or PosX >= 349 Then
                    State(StateNeonTiger.JumpDownCreep, 12)
                    If PosX <= 49 Then
                        PosX = 36
                    ElseIf PosX >= 349 Then
                        PosX = 361
                    End If
                    Vx = 0
                    Vy = 0
                    If FDir = FaceDir.Left Then
                        FDir = FaceDir.Right
                    Else
                        FDir = FaceDir.Left
                    End If
                End If

            Case StateNeonTiger.JumpDownCreep
                GetNextFrame()
                If FrameIdx = 1 Then
                    State(StateNeonTiger.JumpDown, 13)
                End If

            Case StateNeonTiger.JumpDown
                HomingMotion(200, 279, 286, 110, 279, False)
                PosX += Vx
                PosY += Vy
                GetNextFrame()
                If PosY >= 279 Then
                    State(StateNeonTiger.JumpDownEnd, 14)
                    PosY = 279
                    Vx = 0
                    Vy = 0
                    ChangeFaceDirection()
                End If

            Case StateNeonTiger.JumpDownEnd
                GetNextFrame()
                If FrameIdx = 1 Then
                    State(StateNeonTiger.Stand, 2)
                    If Autoplayer Then
                        ChangeFaceDirection()
                    End If
                End If

            Case StateNeonTiger.DiveAttackStart
                HomingMotion(150, 279, 254, 144, 279, False)
                PosX += Vx
                PosY += Vy
                GetNextFrame()
                If PosY >= 279 Then
                    State(StateNeonTiger.DiveAttackEnd, 16)
                    PosY = 279
                    Vx = 0
                    Vy = 0
                    ChangeFaceDirection()
                End If

            Case StateNeonTiger.DiveAttackEnd
                GetNextFrame()
                If FrameIdx = 5 Then
                    State(StateNeonTiger.Stand, 2)
                End If

            Case StateNeonTiger.RushAttackStart
                GetNextFrame()
                If FrameIdx = 14 Then
                    State(StateNeonTiger.RushAttackHorizontal, 18)
                End If

            Case StateNeonTiger.RushAttackHorizontal
                GetNextFrame()
                If FDir = FaceDir.Left Then
                    PosX += -8
                Else
                    PosX += 8
                End If
                If PosX <= 60 Or PosX >= 338 Then
                    State(StateNeonTiger.RushAttackJumpUpStart, 19)
                    If PosX <= 60 Then
                        PosX = 60
                    ElseIf PosX >= 338 Then
                        PosX = 338
                    End If
                End If

            Case StateNeonTiger.RushAttackJumpUpStart
                GetNextFrame()
                If FrameIdx = 1 Then
                    State(StateNeonTiger.RushAttackJumpUp, 20)
                    Vx = 0
                    Vy = -8
                End If

            Case StateNeonTiger.RushAttackJumpUp
                GetNextFrame()
                PosY += Vy
                If PosY <= 105 Then
                    State(StateNeonTiger.RushAttackJumpDown, 22)
                    PosY = 105
                    Vx = 0
                    Vy = 8
                ElseIf Autoplayer Then
                    If Rnd() <= 0.05 Then
                        State(StateNeonTiger.RushAttackUpperCut, 21)
                    End If
                End If

            Case StateNeonTiger.RushAttackUpperCut
                GetNextFrame()
                If FrameIdx = 2 Then
                    State(StateNeonTiger.RushAttackJumpDown, 22)
                    Vx = 0
                    Vy = 8
                End If

            Case StateNeonTiger.RushAttackJumpDown
                GetNextFrame()
                PosY += Vy
                If PosY >= 279 Then
                    State(StateNeonTiger.RushAttackEnd, 23)
                    PosY = 279
                    Vx = 0
                    Vy = 0
                End If

            Case StateNeonTiger.RushAttackEnd
                GetNextFrame()
                If FrameIdx = 5 Then
                    If Autoplayer Then
                        Dim i As Double = Rnd()
                        If i < 0.33 Then
                            State(StateNeonTiger.RaySplasher1, 4)
                        ElseIf i >= 0.33 And i < 0.66 Then
                            State(StateNeonTiger.JumpUpStart, 5)
                        Else
                            State(StateNeonTiger.ShotBlock, 3)
                        End If
                        ChangeFaceDirection()
                    Else
                        State(StateNeonTiger.WaitForDecisionAfterRushAttackEnd, 2)
                    End If
                End If

            Case StateNeonTiger.WaitForDecisionAfterRushAttackEnd
                If Autoplayer Then
                    Dim i As Double = Rnd()
                    If i < 0.33 Then
                        State(StateNeonTiger.RaySplasher1, 4)
                    ElseIf i >= 0.33 And i < 0.66 Then
                        State(StateNeonTiger.JumpUpStart, 5)
                    Else
                        State(StateNeonTiger.ShotBlock, 3)
                    End If
                    ChangeFaceDirection()
                End If

            Case StateNeonTiger.Stun
                GetNextFrame()
                If PosY >= 279 Then
                    If StunTrigger Then
                        StunStartPosition = PosX
                        StunTrigger = False
                    End If
                    If FDir = FaceDir.Left Then
                        If PosX >= 338 Or PosX >= StunStartPosition + 20 Then
                            State(StateNeonTiger.Stand, 2)
                            Vx = 0
                            Vy = 0
                            StunTrigger = True
                            If PosX > 338 Then
                                PosX = 338
                            End If
                            If Autoplayer Then
                                ChangeFaceDirection()
                            End If
                        Else
                            PosX += 2
                        End If
                    Else
                        If PosX <= 60 Or PosX <= StunStartPosition - 20 Then
                            State(StateNeonTiger.Stand, 2)
                            Vx = 0
                            Vy = 0
                            StunTrigger = True
                            If PosX < 60 Then
                                PosX = 60
                            End If
                            If Autoplayer Then
                                ChangeFaceDirection()
                            End If
                        Else
                            PosX += -2
                        End If
                    End If
                Else
                    If PosX < 69 Then
                        PosX = 69
                    ElseIf PosX > 329 Then
                        PosX = 329
                    End If

                    If PosY >= 274 Then
                        State(StateNeonTiger.Stand, 2)
                        Vx = 0
                        Vy = 0
                        PosY = 279
                        If Autoplayer Then
                            ChangeFaceDirection()
                        End If
                    Else
                        PosY += 8
                    End If
                End If
        End Select
    End Sub
End Class

Public Class CCharNeonTigerProjectile
    Inherits CCharacter
    Public CurrState As StateNeonTigerProjectile

    Public Sub State(state As StateNeonTigerProjectile, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
            Case StateNeonTigerProjectile.ProjRaySplasher
                GetNextFrame()
                PosX += Vx
                PosY += Vy
                If PosX <= 23 Or PosX >= 375 Or PosY <= 10 Or PosY >= 342 Then
                    Destroy = True
                End If
        End Select
    End Sub
End Class

Public Class CCharMegaMan
    Inherits CCharacter
    Public CurrState As StateMegaMan
    Public IsEnemyOnRightSide As Boolean
    Public Charge As Boolean = True 'Charge megaman shoot after shooting

    Public Sub State(state As StateMegaMan, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
        If PosX > 200 Then
            If state = StateMegaMan.MoveRight Or state = StateMegaMan.JumpMoveRight Then
                FDir = FaceDir.Left
            Else
                FDir = FaceDir.Right
            End If
        Else
            If state = StateMegaMan.MoveLeft Or state = StateMegaMan.JumpMoveLeft Then
                FDir = FaceDir.Right
            Else
                FDir = FaceDir.Left
            End If
        End If
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
            Case StateMegaMan.Intro
                GetNextFrame()
                If FrameIdx = 26 Then
                    State(StateMegaMan.Stand, 1)
                End If

            Case StateMegaMan.Stand
                If Autoplayer = False Then
                    State(StateMegaMan.Stand, 1)
                End If
                GetNextFrame()
                If FrameIdx = 4 Then
                    Dim i As Double = Rnd()
                    If i < 0.25 Then
                        State(StateMegaMan.Shoot, 7)
                    ElseIf i >= 0.25 And i < 0.5 Then
                        State(StateMegaMan.MoveRight, 2)
                    ElseIf i >= 0.5 And i < 0.75 Then
                        State(StateMegaMan.MoveLeft, 2)
                    Else
                        State(StateMegaMan.JumpUpStart, 3)
                    End If
                End If

            Case StateMegaMan.Shoot
                If IsEnemyOnRightSide Then
                    FDir = FaceDir.Left
                Else
                    FDir = FaceDir.Right
                End If
                If Charge Then
                    GetNextFrame()
                    If FrameIdx = 3 Then
                        If Autoplayer Then
                            Dim i As Double = Rnd()
                            If i < 0.33 Then
                                State(StateMegaMan.MoveLeft, 2)
                            ElseIf i >= 0.33 And i < 0.66 Then
                                State(StateMegaMan.MoveRight, 2)
                            Else
                                State(StateMegaMan.JumpUpStart, 3)
                            End If
                        Else
                            State(StateMegaMan.Stand, 1)
                        End If
                    End If
                Else
                    State(StateMegaMan.Stand, 1)
                End If

            Case StateMegaMan.MoveLeft
                FDir = FaceDir.Right
                GetNextFrame()
                PosX += -8
                If PosX <= 43 Then
                    State(StateMegaMan.Stand, 1)
                    PosX = 43
                End If
                If Autoplayer Then
                    If Rnd() <= 0.05 Then
                        Dim i As Double = Rnd()
                        If i < 0.2 Then
                            State(StateMegaMan.Stand, 1)
                        ElseIf i >= 0.2 And i < 0.4 Then
                            State(StateMegaMan.Shoot, 7)
                        ElseIf i >= 0.4 And i < 0.6 Then
                            State(StateMegaMan.MoveRight, 2)
                        ElseIf i >= 0.6 And i < 0.8 Then
                            State(StateMegaMan.MoveLeft, 2)
                        Else
                            State(StateMegaMan.JumpUpStart, 3)
                        End If
                    End If
                End If

            Case StateMegaMan.MoveRight
                FDir = FaceDir.Left
                GetNextFrame()
                PosX += 8
                If PosX >= 355 Then
                    State(StateMegaMan.Stand, 1)
                    PosX = 355
                End If
                If Autoplayer Then
                    If Rnd() <= 0.05 Then
                        Dim i As Double = Rnd()
                        If i < 0.2 Then
                            State(StateMegaMan.Stand, 1)
                        ElseIf i >= 0.2 And i < 0.4 Then
                            State(StateMegaMan.Shoot, 7)
                        ElseIf i >= 0.4 And i < 0.6 Then
                            State(StateMegaMan.MoveRight, 2)
                        ElseIf i >= 0.6 And i < 0.8 Then
                            State(StateMegaMan.MoveLeft, 2)
                        Else
                            State(StateMegaMan.JumpUpStart, 3)
                        End If
                    End If
                End If

            Case StateMegaMan.JumpUpStart
                GetNextFrame()
                If FrameIdx = 3 Then
                    State(StateMegaMan.JumpUp, 4)
                End If

            Case StateMegaMan.JumpUp
                GetNextFrame()
                PosY += -8
                If PosY <= 105 Then
                    State(StateMegaMan.JumpDown, 5)
                    PosY = 105
                End If
                If Autoplayer Then
                    If Rnd() <= 0.05 Then
                        Dim i As Double = Rnd()
                        If i < 0.25 Then
                            State(StateMegaMan.JumpDown, 5)
                        ElseIf i >= 0.25 And i < 0.5 Then
                            State(StateMegaMan.JumpShoot, 8)
                        ElseIf i >= 0.5 And i < 0.75 Then
                            State(StateMegaMan.JumpMoveRight, 9)
                        Else
                            State(StateMegaMan.JumpMoveLeft, 9)
                        End If
                    End If
                End If

            Case StateMegaMan.JumpDown
                GetNextFrame()
                PosY += 8
                If PosY >= 279 Then
                    State(StateMegaMan.JumpDownEnd, 6)
                    PosY = 279
                End If
                If Autoplayer Then
                    If Rnd() <= 0.05 Then
                        Dim i As Double = Rnd()
                        If i < 0.33 Then
                            State(StateMegaMan.JumpShoot, 8)
                        ElseIf i >= 0.33 And i < 0.66 Then
                            State(StateMegaMan.JumpMoveRight, 9)
                        Else
                            State(StateMegaMan.JumpMoveLeft, 9)
                        End If
                    End If
                End If

            Case StateMegaMan.JumpShoot
                If IsEnemyOnRightSide Then
                    FDir = FaceDir.Left
                Else
                    FDir = FaceDir.Right
                End If
                If Charge Then
                    GetNextFrame()
                    If FrameIdx = 5 Then
                        If Autoplayer Then
                            Dim i As Double = Rnd()
                            If i < 0.33 Then
                                State(StateMegaMan.JumpDown, 5)
                            ElseIf i >= 0.33 And i < 0.66 Then
                                State(StateMegaMan.JumpMoveLeft, 9)
                            Else
                                State(StateMegaMan.JumpMoveRight, 9)
                            End If
                        Else
                            State(StateMegaMan.JumpDown, 5)
                        End If
                    End If
                Else
                    State(StateMegaMan.JumpDown, 5)
                End If

            Case StateMegaMan.JumpMoveLeft
                FDir = FaceDir.Right
                GetNextFrame()
                PosX += -8
                If PosX <= 43 Then
                    State(StateMegaMan.JumpDown, 5)
                    PosX = 43
                End If
                If Autoplayer Then
                    If Rnd() <= 0.05 Then
                        Dim i As Double = Rnd()
                        If i < 0.25 Then
                            State(StateMegaMan.JumpDown, 5)
                        ElseIf i >= 0.25 And i < 0.5 Then
                            State(StateMegaMan.JumpShoot, 8)
                        ElseIf i >= 0.5 And i < 0.75 Then
                            State(StateMegaMan.JumpMoveRight, 9)
                        Else
                            State(StateMegaMan.JumpMoveLeft, 9)
                        End If
                    End If
                End If

            Case StateMegaMan.JumpMoveRight
                FDir = FaceDir.Left
                GetNextFrame()
                PosX += 8
                If PosX >= 355 Then
                    State(StateMegaMan.JumpDown, 5)
                    PosX = 355
                End If
                If Autoplayer Then
                    If Rnd() <= 0.05 Then
                        Dim i As Double = Rnd()
                        If i < 0.25 Then
                            State(StateMegaMan.JumpDown, 5)
                        ElseIf i >= 0.25 And i < 0.5 Then
                            State(StateMegaMan.JumpShoot, 8)
                        ElseIf i >= 0.5 And i < 0.75 Then
                            State(StateMegaMan.JumpMoveRight, 9)
                        Else
                            State(StateMegaMan.JumpMoveLeft, 9)
                        End If
                    End If
                End If

            Case StateMegaMan.JumpDownEnd
                GetNextFrame()
                If FrameIdx = 3 Then
                    State(StateMegaMan.Stand, 1)
                End If

            Case StateMegaMan.Stun
                GetNextFrame()
                If FrameIdx = 13 Then
                    State(StateMegaMan.RecallStart, 11)
                    PosX = 318 * Rnd() + 40
                    PosY = 60
                End If

            Case StateMegaMan.RecallStart
                GetNextFrame()
                PosY += 8
                If PosY >= 279 Then
                    State(StateMegaMan.RecallEnd, 12)
                    PosY = 279
                End If

            Case StateMegaMan.RecallEnd
                GetNextFrame()
                If FrameIdx = 4 Then
                    State(StateMegaMan.Stand, 1)
                End If
        End Select
    End Sub
End Class

Public Class CCharMegaManProjectile
    Inherits CCharacter
    Public CurrState As StateMegaManProjectile

    Public Sub State(state As StateMegaManProjectile, idxspr As Integer)
        CurrState = state
        IdxArrSprites = idxspr
        CurrFrame = 0
        FrameIdx = 0
    End Sub

    Public Overrides Sub Update()
        Select Case CurrState
            Case StateMegaManProjectile.Shoot
                GetNextFrame()
                PosX += Vx
                PosY += Vy
                If PosX <= 23 Or PosX >= 375 Then
                    Destroy = True
                End If
        End Select
    End Sub
End Class

Public Class CElmtFrame
    Public CtrPoint As TPoint
    Public Top, Bottom, Left, Right As Integer
    Public Idx As Integer
    Public MaxFrameTime As Integer

    Public Sub New(ctrx As Integer, ctry As Integer, l As Integer, t As Integer, r As Integer, b As Integer, mft As Integer)
        CtrPoint.x = ctrx
        CtrPoint.y = ctry
        Top = t
        Bottom = b
        Left = l
        Right = r
        MaxFrameTime = mft
    End Sub
End Class

Public Class CArrFrame
    Public N As Integer
    Public Elmt As CElmtFrame()
    Public Sub New()
        N = 0
        ReDim Elmt(-1)
    End Sub
    Public Overloads Sub Insert(E As CElmtFrame)
        ReDim Preserve Elmt(N)
        Elmt(N) = E
        N = N + 1
    End Sub
    Public Overloads Sub Insert(ctrx As Integer, ctry As Integer, l As Integer, t As Integer, r As Integer, b As Integer, mft As Integer)
        Dim E As CElmtFrame
        E = New CElmtFrame(ctrx, ctry, l, t, r, b, mft)
        ReDim Preserve Elmt(N)
        Elmt(N) = E
        N = N + 1
    End Sub
End Class

Public Structure TPoint
    Dim x As Integer
    Dim y As Integer
End Structure