Imports System.IO
Public Class Form1
    Dim bmp As Bitmap
    Dim Bg, Bg1, Img As CImage

    Dim SpriteMap As CImage
    Dim SpriteMask As CImage

    Dim ListChar As New List(Of CCharacter)

    Dim Charge As Integer = 0

    'NeonTiger
    Dim NT As CCharNeonTiger
    Dim NTIntroStart, NTIntroEnd, NTStand, NTShotBlock, NTRaySplasher1, NTJumpUpStart As CArrFrame
    Dim NTJumpUp, NTJumpUpEnd, NTCreep, NTRaySplasher2, NTJumpDownGoingUp As CArrFrame
    Dim NTJumpDownGoingDown, NTJumpDownCreep, NTJumpDown, NTJumpDownEnd As CArrFrame
    Dim NTDiveAttackStart, NTDiveAttackEnd, NTRushAttackStart, NTRushAttackHorizontal As CArrFrame
    Dim NTRushAttackJumpUpStart, NTRushAttackJumpUp, NTRushAttackUpperCut As CArrFrame
    Dim NTRushAttackJumpDown, NTRushAttackEnd, NTUpStun, NTDownStun As CArrFrame

    'Neon Tiger Projectile
    Dim NTP As CCharNeonTigerProjectile
    Dim ProjRaySplasher As CArrFrame

    'Mega Man
    Dim MM As CCharMegaMan
    Dim MMIntro, MMStand, MMMove, MMJumpUpStart, MMJumpUp, MMJumpDown, MMJumpDownEnd As CArrFrame
    Dim MMShoot, MMJumpShoot, MMJumpMove, MMStun, MMRecallStart, MMRecallEnd As CArrFrame

    'Mega Man Projectile
    Dim MMP As CCharMegaManProjectile
    Dim ProjMegaManShoot As CArrFrame

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Randomize()

        'open image for background, assign to bg
        Bg = New CImage
        Bg.OpenImage(Path.GetFullPath(Application.StartupPath & "\..\..\..\Resources\") & "Background.bmp")
        Bg.CopyImg(Img)
        Bg.CopyImg(Bg1)

        SpriteMap = New CImage
        SpriteMap.OpenImage(Path.GetFullPath(Application.StartupPath & "\..\..\..\Resources\") & "NeonTigerSprite.bmp")
        SpriteMap.CreateMask(SpriteMask)

        'initialize sprites
        NTIntroStart = New CArrFrame
        NTIntroStart.Insert(797, 97, 765, 47, 844, 130, 1)
        NTIntroStart.Insert(875, 97, 844, 47, 921, 130, 1)

        NTIntroEnd = New CArrFrame
        NTIntroEnd.Insert(946, 106, 921, 67, 991, 130, 1)
        NTIntroEnd.Insert(1018, 104, 991, 83, 1063, 130, 1)
        NTIntroEnd.Insert(1093, 104, 1063, 73, 1130, 129, 5)
        NTIntroEnd.Insert(797, 180, 766, 156, 831, 205, 1)
        NTIntroEnd.Insert(870, 180, 832, 152, 898, 203, 1)
        NTIntroEnd.Insert(938, 180, 900, 144, 966, 203, 1)
        NTIntroEnd.Insert(870, 180, 832, 152, 898, 203, 1)
        NTIntroEnd.Insert(938, 180, 900, 144, 966, 203, 1)
        NTIntroEnd.Insert(870, 180, 832, 152, 898, 203, 1)
        NTIntroEnd.Insert(982, 180, 967, 140, 1028, 203, 2)
        NTIntroEnd.Insert(1071, 180, 1029, 160, 1116, 203, 8)
        NTIntroEnd.Insert(1071, 180, 1029, 160, 1116, 203, 1) '11

        NTStand = New CArrFrame
        NTStand.Insert(1093, 104, 1063, 73, 1130, 129, 10)
        NTStand.Insert(1093, 104, 1063, 73, 1130, 129, 1) '

        NTShotBlock = New CArrFrame
        NTShotBlock.Insert(232, 38, 203, 7, 270, 63, 1)
        NTShotBlock.Insert(304, 38, 274, 18, 345, 63, 1)
        NTShotBlock.Insert(388, 38, 350, 10, 416, 61, 4)
        NTShotBlock.Insert(457, 38, 419, 2, 485, 61, 10)
        NTShotBlock.Insert(520, 38, 489, 18, 554, 63, 2)
        NTShotBlock.Insert(520, 38, 489, 18, 554, 63, 1) '5

        NTRaySplasher1 = New CArrFrame
        NTRaySplasher1.Insert(55, 199, 12, 177, 78, 222, 1)
        NTRaySplasher1.Insert(119, 199, 81, 182, 160, 224, 1)
        NTRaySplasher1.Insert(199, 199, 161, 182, 240, 224, 1)
        NTRaySplasher1.Insert(278, 195, 240, 178, 320, 220, 1)
        NTRaySplasher1.Insert(360, 195, 322, 178, 401, 220, 1)
        NTRaySplasher1.Insert(441, 195, 403, 178, 485, 220, 1)
        NTRaySplasher1.Insert(525, 194, 487, 177, 569, 219, 1)
        NTRaySplasher1.Insert(610, 195, 572, 178, 661, 220, 1)
        NTRaySplasher1.Insert(701, 195, 663, 178, 753, 220, 1) 'shoot = 8
        NTRaySplasher1.Insert(119, 199, 81, 182, 160, 224, 4)
        NTRaySplasher1.Insert(525, 194, 487, 177, 569, 219, 2)
        NTRaySplasher1.Insert(610, 195, 572, 178, 661, 220, 2)
        NTRaySplasher1.Insert(701, 195, 663, 178, 753, 220, 1) 'shoot = 12
        NTRaySplasher1.Insert(119, 199, 81, 182, 160, 224, 4)
        NTRaySplasher1.Insert(525, 194, 487, 177, 569, 219, 2)
        NTRaySplasher1.Insert(610, 195, 572, 178, 661, 220, 2)
        NTRaySplasher1.Insert(701, 195, 663, 178, 753, 220, 1) 'shoot = 16
        NTRaySplasher1.Insert(119, 199, 81, 182, 160, 224, 4)
        NTRaySplasher1.Insert(525, 194, 487, 177, 569, 219, 2)
        NTRaySplasher1.Insert(610, 195, 572, 178, 661, 220, 2)
        NTRaySplasher1.Insert(701, 195, 663, 178, 753, 220, 1) 'shoot = 20
        NTRaySplasher1.Insert(119, 199, 81, 182, 160, 224, 4)
        NTRaySplasher1.Insert(525, 194, 487, 177, 569, 219, 2)
        NTRaySplasher1.Insert(610, 195, 572, 178, 661, 220, 2)
        NTRaySplasher1.Insert(701, 195, 663, 178, 753, 220, 1) 'shoot = 24
        NTRaySplasher1.Insert(701, 195, 663, 178, 753, 220, 1) '

        NTJumpUpStart = New CArrFrame
        NTJumpUpStart.Insert(797, 331, 766, 307, 833, 354, 2)
        NTJumpUpStart.Insert(797, 331, 766, 307, 833, 354, 1) '1

        NTJumpUp = New CArrFrame
        NTJumpUp.Insert(854, 324, 835, 306, 895, 354, 1)
        NTJumpUp.Insert(915, 324, 896, 306, 961, 354, 1)

        NTJumpUpEnd = New CArrFrame
        NTJumpUpEnd.Insert(790, 486, 765, 457, 834, 518, 2)
        NTJumpUpEnd.Insert(790, 486, 765, 457, 834, 518, 1) '1

        NTCreep = New CArrFrame
        NTCreep.Insert(801, 405, 766, 368, 817, 441, 10)
        NTCreep.Insert(801, 405, 766, 368, 817, 441, 1) '1

        NTRaySplasher2 = New CArrFrame
        NTRaySplasher2.Insert(74, 265, 58, 229, 109, 301, 1)
        NTRaySplasher2.Insert(130, 265, 113, 229, 174, 301, 1)
        NTRaySplasher2.Insert(194, 266, 176, 229, 235, 299, 1)
        NTRaySplasher2.Insert(257, 266, 239, 229, 298, 299, 1)
        NTRaySplasher2.Insert(319, 266, 301, 229, 361, 299, 1)
        NTRaySplasher2.Insert(384, 266, 366, 229, 427, 299, 1)
        NTRaySplasher2.Insert(450, 266, 432, 229, 495, 299, 1)
        NTRaySplasher2.Insert(518, 266, 500, 229, 563, 299, 1)
        NTRaySplasher2.Insert(587, 266, 569, 229, 639, 299, 1)
        NTRaySplasher2.Insert(660, 266, 642, 229, 713, 299, 1) 'shoot = 9
        NTRaySplasher2.Insert(257, 266, 239, 229, 298, 299, 4)
        NTRaySplasher2.Insert(518, 266, 500, 229, 563, 299, 2)
        NTRaySplasher2.Insert(587, 266, 569, 229, 639, 299, 2)
        NTRaySplasher2.Insert(660, 266, 642, 229, 713, 299, 1) 'shoot = 13
        NTRaySplasher2.Insert(257, 266, 239, 229, 298, 299, 4)
        NTRaySplasher2.Insert(518, 266, 500, 229, 563, 299, 2)
        NTRaySplasher2.Insert(587, 266, 569, 229, 639, 299, 2)
        NTRaySplasher2.Insert(660, 266, 642, 229, 713, 299, 1) 'shoot = 17
        NTRaySplasher2.Insert(257, 266, 239, 229, 298, 299, 4)
        NTRaySplasher2.Insert(518, 266, 500, 229, 563, 299, 2)
        NTRaySplasher2.Insert(587, 266, 569, 229, 639, 299, 2)
        NTRaySplasher2.Insert(660, 266, 642, 229, 713, 299, 1) 'shoot = 21
        NTRaySplasher2.Insert(257, 266, 239, 229, 298, 299, 4)
        NTRaySplasher2.Insert(518, 266, 500, 229, 563, 299, 2)
        NTRaySplasher2.Insert(587, 266, 569, 229, 639, 299, 2)
        NTRaySplasher2.Insert(660, 266, 642, 229, 713, 299, 1) 'shoot = 25
        NTRaySplasher2.Insert(660, 266, 642, 229, 713, 299, 1)

        NTJumpDownGoingUp = New CArrFrame
        NTJumpDownGoingUp.Insert(854, 324, 835, 306, 895, 354, 1)
        NTJumpDownGoingUp.Insert(915, 324, 896, 306, 961, 354, 1)

        NTJumpDownGoingDown = New CArrFrame
        NTJumpDownGoingDown.Insert(862, 483, 835, 455, 904, 518, 1)
        NTJumpDownGoingDown.Insert(931, 483, 905, 462, 979, 518, 1)

        NTJumpDownCreep = New CArrFrame
        NTJumpDownCreep.Insert(801, 405, 766, 368, 817, 441, 4)
        NTJumpDownCreep.Insert(801, 405, 766, 368, 817, 441, 1) '

        NTJumpDown = New CArrFrame
        NTJumpDown.Insert(862, 483, 835, 455, 904, 518, 1)
        NTJumpDown.Insert(931, 483, 905, 462, 979, 518, 1)

        NTJumpDownEnd = New CArrFrame
        NTJumpDownEnd.Insert(1108, 260, 1081, 241, 1152, 286, 2)
        NTJumpDownEnd.Insert(1108, 260, 1081, 241, 1152, 286, 1) '1

        NTDiveAttackStart = New CArrFrame
        NTDiveAttackStart.Insert(797, 97, 765, 47, 844, 130, 1)
        NTDiveAttackStart.Insert(875, 97, 844, 47, 921, 130, 1)

        NTDiveAttackEnd = New CArrFrame
        NTDiveAttackEnd.Insert(789, 261, 766, 217, 823, 284, 1)
        NTDiveAttackEnd.Insert(870, 261, 824, 219, 921, 284, 2)
        NTDiveAttackEnd.Insert(960, 260, 922, 244, 1009, 291, 2)
        NTDiveAttackEnd.Insert(1031, 260, 1010, 244, 1080, 286, 1)
        NTDiveAttackEnd.Insert(1108, 260, 1081, 241, 1152, 286, 1)
        NTDiveAttackEnd.Insert(1108, 260, 1081, 241, 1152, 286, 1) '5

        NTRushAttackStart = New CArrFrame
        NTRushAttackStart.Insert(105, 415, 77, 384, 144, 440, 1)
        NTRushAttackStart.Insert(176, 415, 148, 384, 215, 440, 1)
        NTRushAttackStart.Insert(246, 415, 218, 386, 285, 440, 1)
        NTRushAttackStart.Insert(327, 415, 288, 387, 354, 438, 1)
        NTRushAttackStart.Insert(397, 415, 358, 379, 424, 438, 1)
        NTRushAttackStart.Insert(466, 415, 427, 387, 493, 438, 1)
        NTRushAttackStart.Insert(538, 416, 499, 380, 565, 439, 1)
        NTRushAttackStart.Insert(607, 416, 568, 388, 633, 439, 1)
        NTRushAttackStart.Insert(675, 416, 636, 380, 702, 439, 1)
        NTRushAttackStart.Insert(176, 492, 137, 464, 203, 516, 1)
        NTRushAttackStart.Insert(248, 492, 209, 456, 275, 516, 1)
        NTRushAttackStart.Insert(313, 492, 284, 460, 351, 516, 1)
        NTRushAttackStart.Insert(387, 492, 361, 472, 433, 516, 1)
        NTRushAttackStart.Insert(471, 492, 441, 467, 509, 516, 1)
        NTRushAttackStart.Insert(471, 492, 441, 467, 509, 516, 1) '14

        NTRushAttackHorizontal = New CArrFrame
        NTRushAttackHorizontal.Insert(698, 583, 685, 528, 751, 606, 1)
        NTRushAttackHorizontal.Insert(698, 583, 685, 528, 751, 606, 1)

        NTRushAttackJumpUpStart = New CArrFrame
        NTRushAttackJumpUpStart.Insert(471, 492, 441, 467, 509, 516, 2)
        NTRushAttackJumpUpStart.Insert(471, 492, 441, 467, 509, 516, 1) '1

        NTRushAttackJumpUp = New CArrFrame
        NTRushAttackJumpUp.Insert(535, 487, 517, 469, 581, 517, 1)
        NTRushAttackJumpUp.Insert(605, 487, 586, 469, 646, 517, 1)

        NTRushAttackUpperCut = New CArrFrame
        NTRushAttackUpperCut.Insert(534, 571, 488, 552, 582, 605, 2)
        NTRushAttackUpperCut.Insert(628, 583, 587, 528, 681, 606, 2)
        NTRushAttackUpperCut.Insert(628, 583, 587, 528, 681, 606, 1) '2

        NTRushAttackJumpDown = New CArrFrame
        NTRushAttackJumpDown.Insert(268, 662, 237, 615, 314, 694, 1)
        NTRushAttackJumpDown.Insert(348, 663, 317, 615, 395, 695, 1)

        NTRushAttackEnd = New CArrFrame
        NTRushAttackEnd.Insert(387, 492, 361, 472, 433, 516, 1)
        NTRushAttackEnd.Insert(795, 779, 766, 749, 833, 802, 1)
        NTRushAttackEnd.Insert(863, 779, 834, 749, 901, 802, 1)
        NTRushAttackEnd.Insert(931, 779, 902, 749, 969, 802, 1)
        NTRushAttackEnd.Insert(999, 779, 970, 749, 1037, 802, 1)
        NTRushAttackEnd.Insert(999, 779, 970, 749, 1037, 802, 1) '5

        NTUpStun = New CArrFrame
        NTUpStun.Insert(268, 662, 237, 615, 314, 694, 1)
        NTUpStun.Insert(875, 97, 844, 47, 921, 130, 1)

        NTDownStun = New CArrFrame
        NTDownStun.Insert(795, 779, 766, 749, 833, 802, 1)
        NTDownStun.Insert(863, 781, 834, 749, 901, 802, 1)
        NTDownStun.Insert(931, 779, 902, 749, 969, 802, 1)
        NTDownStun.Insert(999, 781, 970, 749, 1037, 802, 1)

        NT = New CCharNeonTiger
        ReDim NT.ArrSprites(25)
        NT.ArrSprites(0) = NTIntroStart
        NT.ArrSprites(1) = NTIntroEnd
        NT.ArrSprites(2) = NTStand
        NT.ArrSprites(3) = NTShotBlock
        NT.ArrSprites(4) = NTRaySplasher1
        NT.ArrSprites(5) = NTJumpUpStart
        NT.ArrSprites(6) = NTJumpUp
        NT.ArrSprites(7) = NTJumpUpEnd
        NT.ArrSprites(8) = NTCreep
        NT.ArrSprites(9) = NTRaySplasher2
        NT.ArrSprites(10) = NTJumpDownGoingUp
        NT.ArrSprites(11) = NTJumpDownGoingDown
        NT.ArrSprites(12) = NTJumpDownCreep
        NT.ArrSprites(13) = NTJumpDown
        NT.ArrSprites(14) = NTJumpDownEnd
        NT.ArrSprites(15) = NTDiveAttackStart
        NT.ArrSprites(16) = NTDiveAttackEnd
        NT.ArrSprites(17) = NTRushAttackStart
        NT.ArrSprites(18) = NTRushAttackHorizontal
        NT.ArrSprites(19) = NTRushAttackJumpUpStart
        NT.ArrSprites(20) = NTRushAttackJumpUp
        NT.ArrSprites(21) = NTRushAttackUpperCut
        NT.ArrSprites(22) = NTRushAttackJumpDown
        NT.ArrSprites(23) = NTRushAttackEnd
        NT.ArrSprites(24) = NTUpStun
        NT.ArrSprites(25) = NTDownStun

        NT.PosX = 314
        NT.PosY = 76
        NT.Vx = 0
        NT.Vy = 8
        NT.State(StateNeonTiger.IntroStart, 0)
        NT.FDir = FaceDir.Left
        ListChar.Add(NT)

        'Projectile Neon Tiger
        ProjRaySplasher = New CArrFrame
        ProjRaySplasher.Insert(1173, 52, 1166, 45, 1180, 59, 1)
        ProjRaySplasher.Insert(1189, 52, 1181, 44, 1197, 69, 1)
        ProjRaySplasher.Insert(1203, 52, 1198, 47, 1208, 57, 1)

        'Initialize Mega Man
        MMIntro = New CArrFrame
        MMIntro.Insert(64, 717, 47, 697, 78, 740, 4)
        MMIntro.Insert(102, 717, 85, 700, 116, 740, 3)
        MMIntro.Insert(138, 717, 121, 703, 152, 740, 2)
        MMIntro.Insert(174, 717, 157, 705, 188, 740, 1)
        MMIntro.Insert(209, 717, 192, 707, 223, 740, 1)
        MMIntro.Insert(245, 717, 227, 705, 258, 740, 1)
        MMIntro.Insert(280, 717, 262, 705, 293, 740, 1)
        MMIntro.Insert(314, 717, 296, 705, 327, 740, 1)
        MMIntro.Insert(349, 717, 331, 705, 362, 740, 1)
        MMIntro.Insert(382, 717, 766, 705, 397, 740, 3)
        MMIntro.Insert(418, 717, 403, 705, 433, 740, 3)
        MMIntro.Insert(486, 839, 469, 816, 498, 862, 1)
        MMIntro.Insert(524, 839, 507, 816, 537, 862, 2)
        MMIntro.Insert(562, 839, 545, 813, 540, 862, 1)
        MMIntro.Insert(600, 839, 583, 816, 613, 862, 1)
        MMIntro.Insert(638, 839, 621, 816, 653, 862, 1) '15
        MMIntro.Insert(486, 839, 469, 816, 498, 862, 1)
        MMIntro.Insert(524, 839, 507, 816, 537, 862, 2)
        MMIntro.Insert(562, 839, 545, 813, 540, 862, 1)
        MMIntro.Insert(600, 839, 583, 816, 613, 862, 1)
        MMIntro.Insert(638, 839, 621, 816, 653, 862, 1) '20
        MMIntro.Insert(486, 839, 469, 816, 498, 862, 1)
        MMIntro.Insert(524, 839, 507, 816, 537, 862, 2)
        MMIntro.Insert(562, 839, 545, 813, 540, 862, 1)
        MMIntro.Insert(600, 839, 583, 816, 613, 862, 1)
        MMIntro.Insert(638, 839, 621, 816, 653, 862, 1) '25
        MMIntro.Insert(638, 839, 621, 816, 653, 862, 1) '26

        MMStand = New CArrFrame
        MMStand.Insert(245, 717, 227, 705, 258, 740, 1)
        MMStand.Insert(280, 717, 262, 705, 293, 740, 1)
        MMStand.Insert(314, 717, 296, 705, 327, 740, 1)
        MMStand.Insert(349, 717, 331, 705, 362, 740, 1)
        MMStand.Insert(349, 717, 331, 705, 362, 740, 1) '4

        MMMove = New CArrFrame
        MMMove.Insert(23, 755, 6, 743, 37, 778, 1)
        MMMove.Insert(62, 755, 51, 743, 72, 778, 1)
        MMMove.Insert(90, 756, 76, 743, 100, 779, 1)
        MMMove.Insert(124, 756, 106, 744, 139, 779, 1)
        MMMove.Insert(166, 755, 146, 744, 181, 778, 1)
        MMMove.Insert(206, 755, 191, 744, 218, 778, 1)
        MMMove.Insert(236, 755, 223, 743, 246, 778, 1)
        MMMove.Insert(264, 756, 249, 743, 275, 779, 1)
        MMMove.Insert(298, 755, 281, 743, 312, 779, 1)
        MMMove.Insert(337, 755, 319, 744, 354, 778, 1)
        MMMove.Insert(376, 755, 360, 744, 390, 778, 1)

        MMJumpUpStart = New CArrFrame
        MMJumpUpStart.Insert(184, 839, 167, 829, 198, 862, 2)
        MMJumpUpStart.Insert(18, 840, 7, 824, 32, 862, 1)
        MMJumpUpStart.Insert(45, 841, 37, 824, 54, 866, 1)
        MMJumpUpStart.Insert(45, 841, 37, 824, 54, 866, 1) '3

        MMJumpUp = New CArrFrame
        MMJumpUp.Insert(68, 841, 57, 822, 77, 869, 1)
        MMJumpUp.Insert(68, 841, 57, 822, 77, 869, 1)

        MMJumpDown = New CArrFrame
        MMJumpDown.Insert(94, 842, 81, 826, 105, 868, 1)
        MMJumpDown.Insert(94, 842, 81, 826, 105, 868, 1)

        MMJumpDownEnd = New CArrFrame
        MMJumpDownEnd.Insert(125, 842, 109, 826, 137, 869, 1)
        MMJumpDownEnd.Insert(152, 843, 140, 827, 165, 866, 1)
        MMJumpDownEnd.Insert(184, 844, 167, 829, 198, 862, 2)
        MMJumpDownEnd.Insert(184, 844, 167, 829, 198, 862, 1) '3

        MMShoot = New CArrFrame
        MMShoot.Insert(349, 717, 331, 705, 362, 740, 2)
        MMShoot.Insert(382, 717, 766, 705, 397, 740, 2)
        MMShoot.Insert(418, 717, 403, 705, 433, 740, 1)
        MMShoot.Insert(418, 717, 403, 705, 433, 740, 1) '3

        MMJumpShoot = New CArrFrame
        MMJumpShoot.Insert(214, 840, 202, 824, 232, 862, 1)
        MMJumpShoot.Insert(248, 841, 241, 824, 266, 866, 1)
        MMJumpShoot.Insert(283, 841, 272, 822, 300, 869, 1)
        MMJumpShoot.Insert(318, 842, 305, 826, 337, 868, 1)
        MMJumpShoot.Insert(355, 842, 342, 826, 374, 869, 1)
        MMJumpShoot.Insert(355, 842, 342, 826, 374, 869, 1) '5

        MMJumpMove = New CArrFrame
        MMJumpMove.Insert(611, 792, 584, 778, 633, 805, 1)
        MMJumpMove.Insert(611, 792, 584, 778, 633, 805, 1)

        MMStun = New CArrFrame
        MMStun.Insert(655, 737, 642, 723, 669, 760, 4)
        MMStun.Insert(625, 737, 612, 723, 639, 760, 1)
        MMStun.Insert(655, 737, 642, 723, 669, 760, 4)
        MMStun.Insert(625, 737, 612, 723, 639, 760, 1)
        MMStun.Insert(655, 737, 642, 723, 669, 760, 4)
        MMStun.Insert(625, 737, 612, 723, 639, 760, 1)
        MMStun.Insert(1253, 17, 1238, 2, 1268, 32, 4)
        MMStun.Insert(1194, 17, 1186, 9, 1202, 25, 4)
        MMStun.Insert(1179, 17, 1173, 11, 1185, 23, 4)
        MMStun.Insert(1169, 17, 1166, 14, 1172, 20, 4)
        MMStun.Insert(1229, 17, 1221, 9, 1237, 25, 4)
        MMStun.Insert(1215, 17, 1210, 12, 1220, 22, 4)
        MMStun.Insert(1206, 17, 1203, 14, 1209, 20, 4)
        MMStun.Insert(1206, 17, 1203, 14, 1209, 20, 1) '13

        MMRecallStart = New CArrFrame
        MMRecallStart.Insert(64, 717, 47, 697, 78, 740, 1)
        MMRecallStart.Insert(64, 717, 47, 697, 78, 740, 1)

        MMRecallEnd = New CArrFrame
        MMRecallEnd.Insert(102, 717, 85, 700, 116, 740, 4)
        MMRecallEnd.Insert(138, 717, 121, 703, 152, 740, 2)
        MMRecallEnd.Insert(174, 717, 157, 705, 188, 740, 2)
        MMRecallEnd.Insert(209, 717, 192, 707, 223, 740, 2)
        MMRecallEnd.Insert(209, 717, 192, 707, 223, 740, 1) '4

        MM = New CCharMegaMan
        ReDim MM.ArrSprites(12)
        MM.ArrSprites(0) = MMIntro
        MM.ArrSprites(1) = MMStand
        MM.ArrSprites(2) = MMMove
        MM.ArrSprites(3) = MMJumpUpStart
        MM.ArrSprites(4) = MMJumpUp
        MM.ArrSprites(5) = MMJumpDown
        MM.ArrSprites(6) = MMJumpDownEnd
        MM.ArrSprites(7) = MMShoot
        MM.ArrSprites(8) = MMJumpShoot
        MM.ArrSprites(9) = MMJumpMove
        MM.ArrSprites(10) = MMStun
        MM.ArrSprites(11) = MMRecallStart
        MM.ArrSprites(12) = MMRecallEnd

        MM.PosX = 70
        MM.PosY = 279
        MM.Vx = 0
        MM.Vy = 0
        MM.State(StateMegaMan.Intro, 0)
        NT.FDir = FaceDir.Left
        ListChar.Add(MM)

        'Projectile Mega Man
        ProjMegaManShoot = New CArrFrame
        ProjMegaManShoot.Insert(721, 742, 715, 736, 727, 748, 1)
        ProjMegaManShoot.Insert(737, 742, 729, 734, 745, 750, 1)

        bmp = New Bitmap(Img.Width, Img.Height)
        DisplayImg()
        ResizeImg()
        rbControlAutoPlayer.Checked = True

        Timer1.Enabled = True
    End Sub

    Sub PutSprites()
        Dim cc As CCharacter
        Dim i, j As Integer
        'set background
        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                Img.Elmt(i, j) = Bg.Elmt(i, j)
            Next
        Next

        For Each cc In ListChar
            Dim EF As CElmtFrame = cc.ArrSprites(cc.IdxArrSprites).Elmt(cc.FrameIdx)
            Dim spritewidth = EF.Right - EF.Left
            Dim spriteheight = EF.Bottom - EF.Top
            Dim imgX, imgY As Integer
            If cc.FDir = FaceDir.Left Then
                Dim spriteleft As Integer = cc.PosX - EF.CtrPoint.x + EF.Left
                Dim spritetop As Integer = cc.PosY - EF.CtrPoint.y + EF.Top
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        imgX = spriteleft + i
                        imgY = spritetop + j
                        If imgX >= 0 And imgX <= Img.Width - 1 And imgY >= 0 And imgY <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Left + i, EF.Top + j))
                        End If
                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        imgX = spriteleft + i
                        imgY = spritetop + j
                        If imgX >= 0 And imgX <= Img.Width - 1 And imgY >= 0 And imgY <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Left + i, EF.Top + j))
                        End If
                    Next
                Next
            Else 'facing right
                Dim spriteleft = cc.PosX + EF.CtrPoint.x - EF.Right
                Dim spritetop = cc.PosY - EF.CtrPoint.y + EF.Top
                'set mask
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        imgX = spriteleft + i
                        imgY = spritetop + j
                        If imgX >= 0 And imgX <= Img.Width - 1 And imgY >= 0 And imgY <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpAnd(Img.Elmt(spriteleft + i, spritetop + j), SpriteMask.Elmt(EF.Right - i, EF.Top + j))
                        End If
                    Next
                Next

                'set sprite
                For i = 0 To spritewidth
                    For j = 0 To spriteheight
                        imgX = spriteleft + i
                        imgY = spritetop + j
                        If imgX >= 0 And imgX <= Img.Width - 1 And imgY >= 0 And imgY <= Img.Height - 1 Then
                            Img.Elmt(spriteleft + i, spritetop + j) = OpOr(Img.Elmt(spriteleft + i, spritetop + j), SpriteMap.Elmt(EF.Right - i, EF.Top + j))
                        End If
                    Next
                Next
            End If
        Next
    End Sub

    Sub DisplayImg()
        'display bg and sprite on picturebox
        Dim i, j As Integer

        PutSprites()

        For i = 0 To Img.Width - 1
            For j = 0 To Img.Height - 1
                bmp.SetPixel(i, j, Img.Elmt(i, j))
            Next
        Next

        PictureBox1.Refresh()

        PictureBox1.Image = bmp
        PictureBox1.Width = bmp.Width
        PictureBox1.Height = bmp.Height
        PictureBox1.Top = 0
        PictureBox1.Left = 0
        'Me.Width = PictureBox1.Width + 30
        'Me.Height = PictureBox1.Height + 100
    End Sub

    Sub ResizeImg()
        Dim w, h As Integer

        w = PictureBox1.Width
        h = PictureBox1.Height

        Me.ClientSize = New Size(w + 320, h)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim CC As CCharacter
        PictureBox1.Refresh()
        CreateNeonTigerProjectile()
        CreateMegaManProjectile()

        If MM.PosX > NT.PosX Then
            NT.IsEnemyOnRightSide = True
            MM.IsEnemyOnRightSide = False
        Else
            NT.IsEnemyOnRightSide = False
            MM.IsEnemyOnRightSide = True
        End If

        For Each CC In ListChar
            CC.Update()
        Next

        Dim Listchar1 As New List(Of CCharacter)

        For Each CC In ListChar
            If Not CC.Destroy Then
                'When MM get hit by NTP
                If CC.IsNTP Then
                    If CollisionDetection(MM.ArrSprites(MM.IdxArrSprites).Elmt(MM.FrameIdx), CC.ArrSprites(CC.IdxArrSprites).Elmt(CC.FrameIdx), MM, CC) Then
                        If Not (MM.CurrState = StateMegaMan.RecallStart Or MM.CurrState = StateMegaMan.RecallEnd Or MM.CurrState = StateMegaMan.Stun) Then
                            MM.State(StateMegaMan.Stun, 10)
                        End If
                        CC.Destroy = True
                    End If
                End If
                If NT.CurrState = StateNeonTiger.DiveAttackEnd Or NT.CurrState = StateNeonTiger.RushAttackStart Or NT.CurrState = StateNeonTiger.RushAttackHorizontal Or NT.CurrState = StateNeonTiger.RushAttackJumpUpStart Or NT.CurrState = StateNeonTiger.RushAttackJumpUp Or NT.CurrState = StateNeonTiger.RushAttackUpperCut Or NT.CurrState = StateNeonTiger.RushAttackJumpDown Or NT.CurrState = StateNeonTiger.RushAttackEnd Then
                    If CollisionDetection(MM.ArrSprites(MM.IdxArrSprites).Elmt(MM.FrameIdx), NT.ArrSprites(NT.IdxArrSprites).Elmt(NT.FrameIdx), MM, NT) Then
                        If Not (MM.CurrState = StateMegaMan.RecallStart Or MM.CurrState = StateMegaMan.RecallEnd Or MM.CurrState = StateMegaMan.Stun) Then
                            MM.State(StateMegaMan.Stun, 10)
                        End If
                    End If
                End If

                'When NT get hit by MMP
                If CC.IsMMP Then
                    If CollisionDetection(NT.ArrSprites(NT.IdxArrSprites).Elmt(NT.FrameIdx), CC.ArrSprites(CC.IdxArrSprites).Elmt(CC.FrameIdx), NT, CC) Then
                        If NT.CurrState = StateNeonTiger.ShotBlock Or NT.CurrState = StateNeonTiger.RushAttackStart Or NT.CurrState = StateNeonTiger.RushAttackHorizontal Or NT.CurrState = StateNeonTiger.RushAttackJumpUpStart Or NT.CurrState = StateNeonTiger.RushAttackJumpUp Or NT.CurrState = StateNeonTiger.RushAttackUpperCut Or NT.CurrState = StateNeonTiger.RushAttackJumpDown Or NT.CurrState = StateNeonTiger.RushAttackEnd Then
                            CC.Vx = 0
                            CC.Vy = 0
                            CC.HomingMotion(90, NT.PosY, 23, 375, 90, True)
                            NT.ChangeFaceDirection()
                        Else
                            If NT.PosY >= 279 Then
                                NT.State(StateNeonTiger.Stun, 25)
                            Else
                                NT.State(StateNeonTiger.Stun, 24)
                            End If
                            CC.Destroy = True
                            NT.ChangeFaceDirection()
                        End If
                    End If
                End If
                Listchar1.Add(CC)
            End If
        Next
        ListChar = Listchar1

        DisplayImg()

        'Neon Tiger Button Activation
        If NT.CurrState = StateNeonTiger.Stand And (rbControlNeonTiger.Checked Or rbControlMultiPlayer.Checked) Then
            NeonTigerController(RS1:=True, JTW:=True, SB:=True, RA:=True, FL:=True, FR:=True)
        ElseIf NT.CurrState = StateNeonTiger.Creep And (rbControlNeonTiger.Checked Or rbControlMultiPlayer.Checked) Then
            NeonTigerController(RS2:=True, JD:=True, DA:=True)
        ElseIf NT.CurrState = StateNeonTiger.WaitForDecisionAfterShotBlock And (rbControlNeonTiger.Checked Or rbControlMultiPlayer.Checked) Then
            NeonTigerController(RS1:=True, JTW:=True, RA:=True, FL:=True, FR:=True)
        ElseIf NT.CurrState = StateNeonTiger.WaitForDecisionAfterRaySplasher2 And (rbControlNeonTiger.Checked Or rbControlMultiPlayer.Checked) Then
            NeonTigerController(JD:=True, DA:=True)
        ElseIf NT.CurrState = StateNeonTiger.RushAttackJumpUp And (rbControlNeonTiger.Checked Or rbControlMultiPlayer.Checked) Then
            NeonTigerController(UC:=True)
        ElseIf NT.CurrState = StateNeonTiger.WaitForDecisionAfterRushAttackEnd And (rbControlNeonTiger.Checked Or rbControlMultiPlayer.Checked) Then
            NeonTigerController(RS1:=True, JTW:=True, SB:=True, FL:=True, FR:=True)
        ElseIf NT.CurrState = StateNeonTiger.Stun Then
            NeonTigerController()
        End If

        'Mega Man Button Activation
        If (MM.CurrState = StateMegaMan.Stand Or MM.CurrState = StateMegaMan.MoveLeft Or MM.CurrState = StateMegaMan.MoveRight) And (rbControlMegaMan.Checked Or rbControlMultiPlayer.Checked) Then
            MegaManController(S:=True, MR:=True, ML:=True, JU:=True)
        ElseIf MM.CurrState = StateMegaMan.Shoot And (rbControlMegaMan.Checked Or rbControlMultiPlayer.Checked) Then
            MegaManController(ML:=True, MR:=True, JU:=True)
        ElseIf (MM.CurrState = StateMegaMan.JumpUp Or MM.CurrState = StateMegaMan.JumpDown Or MM.CurrState = StateMegaMan.JumpMoveLeft Or MM.CurrState = StateMegaMan.JumpMoveRight) And (rbControlMegaMan.Checked Or rbControlMultiPlayer.Checked) Then
            MegaManController(S:=True, MR:=True, ML:=True)
        ElseIf MM.CurrState = StateMegaMan.JumpShoot And (rbControlMegaMan.Checked Or rbControlMultiPlayer.Checked) Then
            MegaManController(MR:=True, ML:=True)
        Else
            MegaManController()
        End If
    End Sub

    Function CollisionDetection(f1 As CElmtFrame, f2 As CElmtFrame, char1 As CCharacter, char2 As CCharacter) As Boolean
        Dim condition1 As Boolean = False
        Dim condition2 As Boolean = False

        Dim f1L As Double = char1.PosX - (f1.CtrPoint.x - f1.Left)
        Dim f1R As Double = char1.PosX + (f1.Right - f1.CtrPoint.x)
        Dim f1T As Double = char1.PosY - (f1.CtrPoint.y - f1.Top)
        Dim f1B As Double = char1.PosY + (f1.Bottom - f1.CtrPoint.y)

        Dim f2L As Double = char2.PosX - (f2.CtrPoint.x - f2.Left)
        Dim f2R As Double = char2.PosX + (f2.Right - f2.CtrPoint.x)
        Dim f2T As Double = char2.PosY - (f2.CtrPoint.y - f2.Top)
        Dim f2B As Double = char2.PosY + (f2.Bottom - f2.CtrPoint.y)

        If (f2L > f1L And f2L < f1R) Or (f2R > f1L And f2R < f1R) Or (f2L < f1L And f2R > f1R) Or (char2.PosX >= char1.PosX - 8 And char2.PosX <= char1.PosX + 8) Then
            condition1 = True
        End If

        If (f2T > f1T And f2T < f1B) Or (f2B > f1T And f2B < f1B) Or (f2T < f1T And f2B > f1B) Or (char2.PosY >= char1.PosY - 8 And char2.PosY <= char1.PosY + 8) Then
            condition2 = True
        End If

        If condition1 And condition2 Then
            Return True
        Else
            Return False
        End If
    End Function

    Sub CreateNeonTigerProjectile()
        If (NT.CurrState = StateNeonTiger.RaySplasher1 And (NT.FrameIdx = 8 Or NT.FrameIdx = 12 Or NT.FrameIdx = 16 Or NT.FrameIdx = 20 Or NT.FrameIdx = 24)) Or (NT.CurrState = StateNeonTiger.RaySplasher2 And (NT.FrameIdx = 9 Or NT.FrameIdx = 13 Or NT.FrameIdx = 17 Or NT.FrameIdx = 21 Or NT.FrameIdx = 25)) Then
            NTP = New CCharNeonTigerProjectile
            NTP.IsNTP = True

            If NT.FDir = FaceDir.Right Then
                NTP.PosX = NT.PosX - 35
                NTP.FDir = FaceDir.Left
            Else
                NTP.PosX = NT.PosX + 35
                NTP.FDir = FaceDir.Right
            End If
            NTP.CurrState = StateNeonTigerProjectile.ProjRaySplasher
            If NT.CurrState = StateNeonTiger.RaySplasher1 Then
                NTP.PosY = NT.PosY + 6
                If NT.FrameIdx = 8 Then
                    NTP.HomingMotion(215, NT.PosY, 23, 375, 215, True)
                ElseIf NT.FrameIdx = 12 Then
                    NTP.HomingMotion(NT.PosY, 320, 23, 375, 320, False)
                ElseIf NT.FrameIdx = 16 Then
                    NTP.HomingMotion(NT.PosY, NT.PosY, 23, 375, NT.PosY, True)
                ElseIf NT.FrameIdx = 20 Then
                    NTP.HomingMotion(130, NT.PosY, 23, 375, 130, True)
                ElseIf NT.FrameIdx = 24 Then
                    NTP.HomingMotion(NT.PosY, 340, 23, 375, 340, False)
                End If
            ElseIf NT.CurrState = StateNeonTiger.RaySplasher2 Then
                NTP.PosY = NT.PosY - 6
                If NT.FrameIdx = 9 Then
                    NTP.HomingMotion(NT.PosY, 350, 23, 375, 350, False)
                ElseIf NT.FrameIdx = 13 Then
                    NTP.HomingMotion(NT.PosY, 238, 23, 375, 238, False)
                ElseIf NT.FrameIdx = 17 Then
                    NTP.HomingMotion(NT.PosY, 304, 23, 375, 304, False)
                ElseIf NT.FrameIdx = 21 Then
                    NTP.HomingMotion(NT.PosY, 350, 150, 250, 350, False)
                ElseIf NT.FrameIdx = 25 Then
                    NTP.HomingMotion(NT.PosY, NT.PosY, 23, 375, NT.PosY, True)
                End If
            End If

            ReDim NTP.ArrSprites(0)
            NTP.ArrSprites(0) = ProjRaySplasher
            ListChar.Add(NTP)
        End If
    End Sub

    Sub CreateMegaManProjectile()
        If (MM.CurrState = StateMegaMan.Shoot And MM.FrameIdx = 2) Or (MM.CurrState = StateMegaMan.JumpShoot And MM.FrameIdx = 4) Then
            MMP = New CCharMegaManProjectile
            If MM.FDir = FaceDir.Right Then
                MMP.PosX = MM.PosX - 18
                MMP.FDir = FaceDir.Right
                MMP.Vx = -8
            Else
                MMP.PosX = MM.PosX + 18
                MMP.FDir = FaceDir.Left
                MMP.Vx = 8
            End If

            MMP.PosY = MM.PosY - 3
            MMP.Vy = 0
            MMP.IsMMP = True

            ReDim MMP.ArrSprites(0)
            MMP.ArrSprites(0) = ProjMegaManShoot
            ListChar.Add(MMP)
        End If
    End Sub

    'Player Controller
    Sub ButtonBackColor(btn As Button, i As Boolean)
        If i Then
            btn.BackColor = Color.FromArgb(0, 192, 0)
        Else
            btn.BackColor = Color.Red
        End If
    End Sub
    Sub NeonTigerController(Optional RS1 As Boolean = False, Optional JTW As Boolean = False, Optional SB As Boolean = False, Optional RA As Boolean = False, Optional RS2 As Boolean = False, Optional JD As Boolean = False, Optional DA As Boolean = False, Optional UC As Boolean = False, Optional FL As Boolean = False, Optional FR As Boolean = False)
        'Neon Tiger Button Controller
        btnRaySplasher1.Enabled = RS1
        ButtonBackColor(btnRaySplasher1, RS1)
        btnJumpToWall.Enabled = JTW
        ButtonBackColor(btnJumpToWall, JTW)
        btnShotBlock.Enabled = SB
        ButtonBackColor(btnShotBlock, SB)
        btnRushAttack.Enabled = RA
        ButtonBackColor(btnRushAttack, RA)
        btnRaySplasher2.Enabled = RS2
        ButtonBackColor(btnRaySplasher2, RS2)
        btnJumpDown.Enabled = JD
        ButtonBackColor(btnJumpDown, JD)
        btnDiveAttack.Enabled = DA
        ButtonBackColor(btnDiveAttack, DA)
        btnUpperCut.Enabled = UC
        ButtonBackColor(btnUpperCut, UC)
        btnFaceLeft.Enabled = FL
        ButtonBackColor(btnFaceLeft, FL)
        btnFaceRight.Enabled = FR
        ButtonBackColor(btnFaceRight, FR)
    End Sub
    Sub MegaManController(Optional S As Boolean = False, Optional JU As Boolean = False, Optional ML As Boolean = False, Optional MR As Boolean = False)
        'Mega Man Controller
        'Mega Man Shoot Active After 1 second of charge
        If (MM.CurrState = StateMegaMan.Shoot And MM.FrameIdx = 2) Or (MM.CurrState = StateMegaMan.JumpShoot And MM.FrameIdx = 4) Then
            Charge = 0
            MM.Charge = False
            btnShoot.Enabled = False
            ButtonBackColor(btnShoot, False)
        Else
            Charge += 50
            If Charge >= 1000 Then
                Charge = 1000
                btnShoot.Enabled = S
                ButtonBackColor(btnShoot, S)
                MM.Charge = True
            Else
                btnShoot.Enabled = False
                ButtonBackColor(btnShoot, False)
            End If
        End If
        ProgressBar1.Value = Charge

        btnJumpUp.Enabled = JU
        ButtonBackColor(btnJumpUp, JU)
        btnMoveLeft.Enabled = ML
        ButtonBackColor(btnMoveLeft, ML)
        btnMoveRight.Enabled = MR
        ButtonBackColor(btnMoveRight, MR)
    End Sub
    Private Sub rbControlNeonTiger_CheckedChanged(sender As Object, e As EventArgs) Handles rbControlNeonTiger.CheckedChanged
        If rbControlNeonTiger.Checked Then
            NT.Autoplayer = False
            MM.Autoplayer = True
            MegaManController()
        End If
    End Sub
    Private Sub rbControlMegaMan_CheckedChanged(sender As Object, e As EventArgs) Handles rbControlMegaMan.CheckedChanged
        If rbControlMegaMan.Checked Then
            NT.Autoplayer = True
            MM.Autoplayer = False
            NeonTigerController()
        End If
    End Sub
    Private Sub rbControlAutoPlayer_CheckedChanged(sender As Object, e As EventArgs) Handles rbControlAutoPlayer.CheckedChanged
        If rbControlAutoPlayer.Checked Then
            NT.Autoplayer = True
            MM.Autoplayer = True
            NeonTigerController()
            MegaManController()
        End If
    End Sub
    Private Sub rbControlMultiPlayer_CheckedChanged(sender As Object, e As EventArgs) Handles rbControlMultiPlayer.CheckedChanged
        If rbControlMultiPlayer.Checked Then
            NT.Autoplayer = False
            MM.Autoplayer = False
        End If
    End Sub

    'Neon Tiger Button Controller
    Private Sub btnFaceRight_Click(sender As Object, e As EventArgs) Handles btnFaceRight.Click
        NT.FDir = FaceDir.Right
        NeonTigerController()
    End Sub
    Private Sub btnFaceLeft_Click(sender As Object, e As EventArgs) Handles btnFaceLeft.Click
        NT.FDir = FaceDir.Left
        NeonTigerController()
    End Sub
    Private Sub btnRaySplasher1_Click(sender As Object, e As EventArgs) Handles btnRaySplasher1.Click
        NT.State(StateNeonTiger.RaySplasher1, 4)
        NeonTigerController()
    End Sub
    Private Sub btnJumpToWall_Click(sender As Object, e As EventArgs) Handles btnJumpToWall.Click
        NT.State(StateNeonTiger.JumpUpStart, 5)
        NeonTigerController()
    End Sub
    Private Sub btnRushAttack_Click(sender As Object, e As EventArgs) Handles btnRushAttack.Click
        NT.State(StateNeonTiger.RushAttackStart, 17)
        NeonTigerController()
    End Sub
    Private Sub btnShotBlock_Click(sender As Object, e As EventArgs) Handles btnShotBlock.Click
        NT.State(StateNeonTiger.ShotBlock, 3)
        NeonTigerController()
    End Sub
    Private Sub btnRaySplasher2_Click(sender As Object, e As EventArgs) Handles btnRaySplasher2.Click
        NT.State(StateNeonTiger.RaySplasher2, 9)
        NeonTigerController()
    End Sub
    Private Sub btnDiveAttack_Click(sender As Object, e As EventArgs) Handles btnDiveAttack.Click
        NT.State(StateNeonTiger.DiveAttackStart, 15)
        NeonTigerController()
    End Sub
    Private Sub btnJumpDown_Click(sender As Object, e As EventArgs) Handles btnJumpDown.Click
        NT.State(StateNeonTiger.JumpDownGoingUp, 10)
        NeonTigerController()
    End Sub
    Private Sub btnUpperCut_Click(sender As Object, e As EventArgs) Handles btnUpperCut.Click
        NT.State(StateNeonTiger.RushAttackUpperCut, 21)
        NeonTigerController()
    End Sub

    'Mega Man Button Controller
    Private Sub btnShoot_Click(sender As Object, e As EventArgs) Handles btnShoot.Click
        If MM.PosY < 279 Then
            MM.State(StateMegaMan.JumpShoot, 8)
        Else
            MM.State(StateMegaMan.Shoot, 7)
        End If
        MegaManController()
    End Sub
    Private Sub btnJumpUp_Click(sender As Object, e As EventArgs) Handles btnJumpUp.Click
        MM.State(StateMegaMan.JumpUpStart, 3)
        MegaManController()
    End Sub
    Private Sub btnMoveLeft_Click(sender As Object, e As EventArgs) Handles btnMoveLeft.Click
        If MM.PosY < 279 Then
            MM.State(StateMegaMan.JumpMoveLeft, 9)
        Else
            MM.State(StateMegaMan.MoveLeft, 2)
        End If
        MegaManController()
    End Sub
    Private Sub btnMoveRight_Click(sender As Object, e As EventArgs) Handles btnMoveRight.Click
        If MM.PosY < 279 Then
            MM.State(StateMegaMan.JumpMoveRight, 9)
        Else
            MM.State(StateMegaMan.MoveRight, 2)
        End If
        MegaManController()
    End Sub
End Class