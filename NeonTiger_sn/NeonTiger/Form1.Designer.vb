<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnFaceRight = New System.Windows.Forms.Button()
        Me.btnFaceLeft = New System.Windows.Forms.Button()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.btnMoveRight = New System.Windows.Forms.Button()
        Me.btnMoveLeft = New System.Windows.Forms.Button()
        Me.btnJumpUp = New System.Windows.Forms.Button()
        Me.btnShoot = New System.Windows.Forms.Button()
        Me.btnUpperCut = New System.Windows.Forms.Button()
        Me.btnDiveAttack = New System.Windows.Forms.Button()
        Me.btnRaySplasher2 = New System.Windows.Forms.Button()
        Me.btnJumpDown = New System.Windows.Forms.Button()
        Me.btnShotBlock = New System.Windows.Forms.Button()
        Me.btnRushAttack = New System.Windows.Forms.Button()
        Me.btnJumpToWall = New System.Windows.Forms.Button()
        Me.btnRaySplasher1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbControlMultiPlayer = New System.Windows.Forms.RadioButton()
        Me.rbControlAutoPlayer = New System.Windows.Forms.RadioButton()
        Me.rbControlMegaMan = New System.Windows.Forms.RadioButton()
        Me.rbControlNeonTiger = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 50
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnFaceRight)
        Me.Panel1.Controls.Add(Me.btnFaceLeft)
        Me.Panel1.Controls.Add(Me.ProgressBar1)
        Me.Panel1.Controls.Add(Me.btnMoveRight)
        Me.Panel1.Controls.Add(Me.btnMoveLeft)
        Me.Panel1.Controls.Add(Me.btnJumpUp)
        Me.Panel1.Controls.Add(Me.btnShoot)
        Me.Panel1.Controls.Add(Me.btnUpperCut)
        Me.Panel1.Controls.Add(Me.btnDiveAttack)
        Me.Panel1.Controls.Add(Me.btnRaySplasher2)
        Me.Panel1.Controls.Add(Me.btnJumpDown)
        Me.Panel1.Controls.Add(Me.btnShotBlock)
        Me.Panel1.Controls.Add(Me.btnRushAttack)
        Me.Panel1.Controls.Add(Me.btnJumpToWall)
        Me.Panel1.Controls.Add(Me.btnRaySplasher1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(802, 473)
        Me.Panel1.TabIndex = 2
        '
        'btnFaceRight
        '
        Me.btnFaceRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnFaceRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFaceRight.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnFaceRight.ForeColor = System.Drawing.Color.White
        Me.btnFaceRight.Location = New System.Drawing.Point(660, 291)
        Me.btnFaceRight.Name = "btnFaceRight"
        Me.btnFaceRight.Size = New System.Drawing.Size(128, 29)
        Me.btnFaceRight.TabIndex = 15
        Me.btnFaceRight.Text = "Face Right"
        Me.btnFaceRight.UseVisualStyleBackColor = False
        '
        'btnFaceLeft
        '
        Me.btnFaceLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnFaceLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFaceLeft.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnFaceLeft.ForeColor = System.Drawing.Color.White
        Me.btnFaceLeft.Location = New System.Drawing.Point(527, 291)
        Me.btnFaceLeft.Name = "btnFaceLeft"
        Me.btnFaceLeft.Size = New System.Drawing.Size(128, 29)
        Me.btnFaceLeft.TabIndex = 14
        Me.btnFaceLeft.Text = "Face Left"
        Me.btnFaceLeft.UseVisualStyleBackColor = False
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(660, 361)
        Me.ProgressBar1.MarqueeAnimationSpeed = 1
        Me.ProgressBar1.Maximum = 1000
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(128, 10)
        Me.ProgressBar1.Step = 1
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 13
        '
        'btnMoveRight
        '
        Me.btnMoveRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMoveRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMoveRight.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnMoveRight.ForeColor = System.Drawing.Color.White
        Me.btnMoveRight.Location = New System.Drawing.Point(660, 405)
        Me.btnMoveRight.Name = "btnMoveRight"
        Me.btnMoveRight.Size = New System.Drawing.Size(128, 29)
        Me.btnMoveRight.TabIndex = 12
        Me.btnMoveRight.Text = "Move Right"
        Me.btnMoveRight.UseVisualStyleBackColor = False
        '
        'btnMoveLeft
        '
        Me.btnMoveLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMoveLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMoveLeft.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnMoveLeft.ForeColor = System.Drawing.Color.White
        Me.btnMoveLeft.Location = New System.Drawing.Point(527, 405)
        Me.btnMoveLeft.Name = "btnMoveLeft"
        Me.btnMoveLeft.Size = New System.Drawing.Size(128, 29)
        Me.btnMoveLeft.TabIndex = 11
        Me.btnMoveLeft.Text = "Move Left"
        Me.btnMoveLeft.UseVisualStyleBackColor = False
        '
        'btnJumpUp
        '
        Me.btnJumpUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnJumpUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJumpUp.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnJumpUp.ForeColor = System.Drawing.Color.White
        Me.btnJumpUp.Location = New System.Drawing.Point(527, 370)
        Me.btnJumpUp.Name = "btnJumpUp"
        Me.btnJumpUp.Size = New System.Drawing.Size(128, 29)
        Me.btnJumpUp.TabIndex = 10
        Me.btnJumpUp.Text = "Jump Up"
        Me.btnJumpUp.UseVisualStyleBackColor = False
        '
        'btnShoot
        '
        Me.btnShoot.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnShoot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShoot.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnShoot.ForeColor = System.Drawing.Color.White
        Me.btnShoot.Location = New System.Drawing.Point(660, 370)
        Me.btnShoot.Name = "btnShoot"
        Me.btnShoot.Size = New System.Drawing.Size(128, 29)
        Me.btnShoot.TabIndex = 9
        Me.btnShoot.Text = "Shoot"
        Me.btnShoot.UseVisualStyleBackColor = False
        '
        'btnUpperCut
        '
        Me.btnUpperCut.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnUpperCut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUpperCut.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnUpperCut.ForeColor = System.Drawing.Color.White
        Me.btnUpperCut.Location = New System.Drawing.Point(660, 256)
        Me.btnUpperCut.Name = "btnUpperCut"
        Me.btnUpperCut.Size = New System.Drawing.Size(128, 29)
        Me.btnUpperCut.TabIndex = 8
        Me.btnUpperCut.Text = "Upper Cut"
        Me.btnUpperCut.UseVisualStyleBackColor = False
        '
        'btnDiveAttack
        '
        Me.btnDiveAttack.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDiveAttack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDiveAttack.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnDiveAttack.ForeColor = System.Drawing.Color.White
        Me.btnDiveAttack.Location = New System.Drawing.Point(660, 221)
        Me.btnDiveAttack.Name = "btnDiveAttack"
        Me.btnDiveAttack.Size = New System.Drawing.Size(128, 29)
        Me.btnDiveAttack.TabIndex = 7
        Me.btnDiveAttack.Text = "Dive Attack"
        Me.btnDiveAttack.UseVisualStyleBackColor = False
        '
        'btnRaySplasher2
        '
        Me.btnRaySplasher2.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRaySplasher2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRaySplasher2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnRaySplasher2.ForeColor = System.Drawing.Color.White
        Me.btnRaySplasher2.Location = New System.Drawing.Point(527, 221)
        Me.btnRaySplasher2.Name = "btnRaySplasher2"
        Me.btnRaySplasher2.Size = New System.Drawing.Size(128, 29)
        Me.btnRaySplasher2.TabIndex = 4
        Me.btnRaySplasher2.Text = "Ray Splasher 2"
        Me.btnRaySplasher2.UseVisualStyleBackColor = False
        '
        'btnJumpDown
        '
        Me.btnJumpDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnJumpDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJumpDown.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnJumpDown.ForeColor = System.Drawing.Color.White
        Me.btnJumpDown.Location = New System.Drawing.Point(527, 256)
        Me.btnJumpDown.Name = "btnJumpDown"
        Me.btnJumpDown.Size = New System.Drawing.Size(128, 29)
        Me.btnJumpDown.TabIndex = 4
        Me.btnJumpDown.Text = "Jump Down"
        Me.btnJumpDown.UseVisualStyleBackColor = False
        '
        'btnShotBlock
        '
        Me.btnShotBlock.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnShotBlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnShotBlock.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnShotBlock.ForeColor = System.Drawing.Color.White
        Me.btnShotBlock.Location = New System.Drawing.Point(660, 186)
        Me.btnShotBlock.Name = "btnShotBlock"
        Me.btnShotBlock.Size = New System.Drawing.Size(128, 29)
        Me.btnShotBlock.TabIndex = 6
        Me.btnShotBlock.Text = "Shot Block"
        Me.btnShotBlock.UseVisualStyleBackColor = False
        '
        'btnRushAttack
        '
        Me.btnRushAttack.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRushAttack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRushAttack.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnRushAttack.ForeColor = System.Drawing.Color.White
        Me.btnRushAttack.Location = New System.Drawing.Point(660, 151)
        Me.btnRushAttack.Name = "btnRushAttack"
        Me.btnRushAttack.Size = New System.Drawing.Size(128, 29)
        Me.btnRushAttack.TabIndex = 5
        Me.btnRushAttack.Text = "Rush Attack"
        Me.btnRushAttack.UseVisualStyleBackColor = False
        '
        'btnJumpToWall
        '
        Me.btnJumpToWall.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnJumpToWall.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJumpToWall.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnJumpToWall.ForeColor = System.Drawing.Color.White
        Me.btnJumpToWall.Location = New System.Drawing.Point(527, 186)
        Me.btnJumpToWall.Name = "btnJumpToWall"
        Me.btnJumpToWall.Size = New System.Drawing.Size(128, 29)
        Me.btnJumpToWall.TabIndex = 4
        Me.btnJumpToWall.Text = "Jump To Wall"
        Me.btnJumpToWall.UseVisualStyleBackColor = False
        '
        'btnRaySplasher1
        '
        Me.btnRaySplasher1.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnRaySplasher1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRaySplasher1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.btnRaySplasher1.ForeColor = System.Drawing.Color.White
        Me.btnRaySplasher1.Location = New System.Drawing.Point(527, 151)
        Me.btnRaySplasher1.Name = "btnRaySplasher1"
        Me.btnRaySplasher1.Size = New System.Drawing.Size(128, 29)
        Me.btnRaySplasher1.TabIndex = 3
        Me.btnRaySplasher1.Text = "Ray Splasher 1"
        Me.btnRaySplasher1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label2.Location = New System.Drawing.Point(527, 336)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(137, 31)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mega Man :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbControlMultiPlayer)
        Me.GroupBox1.Controls.Add(Me.rbControlAutoPlayer)
        Me.GroupBox1.Controls.Add(Me.rbControlMegaMan)
        Me.GroupBox1.Controls.Add(Me.rbControlNeonTiger)
        Me.GroupBox1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.GroupBox1.Location = New System.Drawing.Point(527, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 93)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Control"
        '
        'rbControlMultiPlayer
        '
        Me.rbControlMultiPlayer.AutoSize = True
        Me.rbControlMultiPlayer.Location = New System.Drawing.Point(139, 56)
        Me.rbControlMultiPlayer.Name = "rbControlMultiPlayer"
        Me.rbControlMultiPlayer.Size = New System.Drawing.Size(105, 24)
        Me.rbControlMultiPlayer.TabIndex = 3
        Me.rbControlMultiPlayer.Text = "Multiplayer"
        Me.rbControlMultiPlayer.UseVisualStyleBackColor = True
        '
        'rbControlAutoPlayer
        '
        Me.rbControlAutoPlayer.AutoSize = True
        Me.rbControlAutoPlayer.Location = New System.Drawing.Point(139, 26)
        Me.rbControlAutoPlayer.Name = "rbControlAutoPlayer"
        Me.rbControlAutoPlayer.Size = New System.Drawing.Size(103, 24)
        Me.rbControlAutoPlayer.TabIndex = 2
        Me.rbControlAutoPlayer.Text = "Autoplayer"
        Me.rbControlAutoPlayer.UseVisualStyleBackColor = True
        '
        'rbControlMegaMan
        '
        Me.rbControlMegaMan.AutoSize = True
        Me.rbControlMegaMan.Location = New System.Drawing.Point(6, 56)
        Me.rbControlMegaMan.Name = "rbControlMegaMan"
        Me.rbControlMegaMan.Size = New System.Drawing.Size(101, 24)
        Me.rbControlMegaMan.TabIndex = 1
        Me.rbControlMegaMan.Text = "Mega Man"
        Me.rbControlMegaMan.UseVisualStyleBackColor = True
        '
        'rbControlNeonTiger
        '
        Me.rbControlNeonTiger.AutoSize = True
        Me.rbControlNeonTiger.Location = New System.Drawing.Point(6, 26)
        Me.rbControlNeonTiger.Name = "rbControlNeonTiger"
        Me.rbControlNeonTiger.Size = New System.Drawing.Size(104, 24)
        Me.rbControlNeonTiger.TabIndex = 0
        Me.rbControlNeonTiger.Text = "Neon Tiger"
        Me.rbControlNeonTiger.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point)
        Me.Label1.Location = New System.Drawing.Point(527, 117)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(143, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Neon Tiger :"
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(521, 473)
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(802, 473)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Neon Tiger"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnShoot As Button
    Friend WithEvents btnUpperCut As Button
    Friend WithEvents btnDiveAttack As Button
    Friend WithEvents btnRaySplasher2 As Button
    Friend WithEvents btnJumpDown As Button
    Friend WithEvents btnShotBlock As Button
    Friend WithEvents btnRushAttack As Button
    Friend WithEvents btnJumpToWall As Button
    Friend WithEvents btnRaySplasher1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbControlMultiPlayer As RadioButton
    Friend WithEvents rbControlAutoPlayer As RadioButton
    Friend WithEvents rbControlMegaMan As RadioButton
    Friend WithEvents rbControlNeonTiger As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents btnMoveRight As Button
    Friend WithEvents btnMoveLeft As Button
    Friend WithEvents btnJumpUp As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents btnFaceRight As Button
    Friend WithEvents btnFaceLeft As Button
End Class
