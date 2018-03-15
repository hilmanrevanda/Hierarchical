Public Class Form1
    Public Boxes As List(Of Box) = New List(Of Box)
    Public World As List(Of Robot) = New List(Of Robot)

    Dim cos30 As Double = 0.86602540378
    Dim sin45 As Double = 0.70710678118
    Dim btp As Bitmap
    Dim g As Graphics

    Dim degree As Integer = 0


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'degree += 20
        'If axis = "x" Then
        '    rotateX(TrackBar1.Value)
        'ElseIf axis = "y" Then
        '    rotateY(TrackBar1.Value)
        'ElseIf axis = "z" Then
        '    rotateX(TrackBar1.Value) 'ganti jadi z
        'End If

        'drawCube()
    End Sub

    Private Sub btnForward_Click(sender As Object, e As EventArgs)
        'Dim MoveForward(3, 3) As Double
        'MoveForward = New Double(3, 3) {
        '{1, 0, 0, 0},
        '{0, 1, 0, 0},
        '{0, 0, 0, 0.1},
        '{0, 0, 0, 1}
        '}

        'vr = multiplication(vr, MoveForward)
        'Timer1.Enabled = True
    End Sub

    Private Sub btnBackward_Click(sender As Object, e As EventArgs)
        'Dim MoveBackward(3, 3) As Double
        'MoveBackward = New Double(3, 3) {
        '{1, 0, 0, 0},
        '{0, 1, 0, 0},
        '{0, 0, 0, 0.1},
        '{0, 0, 0, 1}
        '}

        'vr = multiplication(vr, MoveBackward)
        'Timer1.Enabled = True
    End Sub

    Private Sub btnStop_Click(sender As Object, e As EventArgs)
        'Timer1.Enabled = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btp = New Bitmap(pbCanvas.Width, pbCanvas.Height)
        g = Graphics.FromImage(btp)
        g.Clear(Color.White)

        For i As Integer = 0 To 1
            World.Add(New Robot)  ' Init new robot

            World.Last.Robot.Add(New LBox) 'Body
            World.Last.Robot.Last.LBox.Add(New Box)
            World.Last.Robot.Last.LBox.Last.scale(50)
            World.Last.Robot.Last.LBox.Last.translate(200, 200, 0)

            World.Last.Robot.Add(New LBox) 'Right Arm
            World.Last.Robot.Last.LBox.Add(New Box) ' Upper arm
            World.Last.Robot.Last.LBox.Last.scale(15)
            World.Last.Robot.Last.LBox.Last.translate(265, 190, 0)

            World.Last.Robot.Last.LBox.Add(New Box) ' Lower arm
            World.Last.Robot.Last.LBox.Last.scale(15)
            World.Last.Robot.Last.LBox.Last.translate(265, 220, 0)

            World.Last.Robot.Last.LBox.Add(New Box) 'left claw
            World.Last.Robot.Last.LBox.Last.scale(5)
            World.Last.Robot.Last.LBox.Last.translate(260, 240, 0)

            World.Last.Robot.Last.LBox.Add(New Box) 'right claw
            World.Last.Robot.Last.LBox.Last.scale(5)
            World.Last.Robot.Last.LBox.Last.translate(270, 240, 0)

            World.Last.Robot.Add(New LBox) 'Left Arm
            World.Last.Robot.Last.LBox.Add(New Box) ' Upper arm
            World.Last.Robot.Last.LBox.Last.scale(15)
            World.Last.Robot.Last.LBox.Last.translate(135, 190, 0)

            World.Last.Robot.Last.LBox.Add(New Box) ' Lower arm
            World.Last.Robot.Last.LBox.Last.scale(15)
            World.Last.Robot.Last.LBox.Last.translate(135, 220, 0)

            World.Last.Robot.Last.LBox.Add(New Box) 'left claw
            World.Last.Robot.Last.LBox.Last.scale(5)
            World.Last.Robot.Last.LBox.Last.translate(130, 240, 0)

            World.Last.Robot.Last.LBox.Add(New Box) 'right claw
            World.Last.Robot.Last.LBox.Last.scale(5)
            World.Last.Robot.Last.LBox.Last.translate(140, 240, 0)

            World.Last.Translate(-200 * i, 0, 0)
        Next
        Timer1.Enabled = False
        drawCube()
    End Sub

    Private Sub drawCube()
        g.Clear(Color.White)
        Dim a, b, c, d As Integer

        'For Each Box In Boxes
        '    For i = 0 To Box.edges.Count - 1
        '        a = Box.vs(Box.edges(i).p1).x
        '        b = Box.vs(Box.edges(i).p1).y
        '        c = Box.vs(Box.edges(i).p2).x
        '        d = Box.vs(Box.edges(i).p2).y
        '        If i <= 3 Then
        '            g.DrawLine(Pens.Red, a, b, c, d)
        '        Else
        '            g.DrawLine(Pens.Black, a, b, c, d)
        '        End If
        '    Next
        '    pbCanvas.Image = btp
        'Next

        For Each Robots In World
            For Each Robot In Robots.Robot
                For Each Box In Robot.LBox
                    For i = 0 To Box.edges.Count - 1
                        a = Box.vs(Box.edges(i).p1).x
                        b = Box.vs(Box.edges(i).p1).y
                        c = Box.vs(Box.edges(i).p2).x
                        d = Box.vs(Box.edges(i).p2).y
                        If i <= 3 Then
                            g.DrawLine(Pens.Red, a, b, c, d)
                        Else
                            g.DrawLine(Pens.Black, a, b, c, d)
                        End If
                    Next
                    'pbCanvas.Image = btp
                Next
            Next
        Next
    End Sub

    Private Sub tbTorsoY_Scroll(sender As Object, e As EventArgs) Handles tbTorsoY.Scroll
        For Each item In World
            item.RotateX(tbTorsoY.Value)
        Next
        'Boxes(0).rotateY(tbTorsoY.Value)
        'Boxes(1).rotateY(tbTorsoY.Value)

        drawCube()
    End Sub

    Private Sub tbTorsoX_Scroll(sender As Object, e As EventArgs) Handles tbTorsoX.Scroll
        For Each item In World
            item.RotateY(tbTorsoX.Value)
        Next

        drawCube()
    End Sub

End Class

Public Class Tpoint
    Public x, y, z, w As Double

    Sub New(x As Double, y As Double, z As Double, w As Double)
        Me.x = x
        Me.y = y
        Me.z = z
        Me.w = w
    End Sub
End Class

Public Class LineIndex
    Public p1, p2 As Integer

    Sub New(p1 As Integer, p2 As Integer)
        Me.p1 = p1
        Me.p2 = p2
    End Sub
End Class

Public Class Box
    Public edges As List(Of LineIndex) = New List(Of LineIndex)
    Public view(3, 3), screen(3, 3) As Double
    Public alpha As Integer = 0
    Public v As List(Of Tpoint) = New List(Of Tpoint)
    Public vr As List(Of Tpoint) = New List(Of Tpoint)
    Public vs As List(Of Tpoint) = New List(Of Tpoint)

    Sub New()
        v.Add(New Tpoint(-1, -1, 1, 1)) '1
        v.Add(New Tpoint(1, -1, 1, 1)) '2
        v.Add(New Tpoint(1, -1, -1, 1)) '3
        v.Add(New Tpoint(-1, -1, -1, 1)) '4
        v.Add(New Tpoint(-1, 1, 1, 1)) '5
        v.Add(New Tpoint(1, 1, 1, 1)) '6
        v.Add(New Tpoint(1, 1, -1, 1)) '7
        v.Add(New Tpoint(-1, 1, -1, 1)) '8

        edges.Add(New LineIndex(0, 1)) '1
        edges.Add(New LineIndex(1, 2)) '2
        edges.Add(New LineIndex(2, 3)) '3
        edges.Add(New LineIndex(3, 0)) '4
        edges.Add(New LineIndex(0, 4)) '5
        edges.Add(New LineIndex(1, 5)) '6
        edges.Add(New LineIndex(2, 6)) '7
        edges.Add(New LineIndex(3, 7)) '8
        edges.Add(New LineIndex(4, 5)) '9
        edges.Add(New LineIndex(5, 6)) '10
        edges.Add(New LineIndex(6, 7)) '11
        edges.Add(New LineIndex(7, 4)) '12

        view = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, -0.125},
            {0, 0, 0, 1}
        }

        screen = New Double(3, 3) {
            {0, 0, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 1}
        }

        vr = multiplication(v, view)
        vs = multiplication(vr, screen)
    End Sub

    Sub translate(x As Integer, y As Integer, z As Integer)
        screen(0, 3) = x
        screen(1, 3) = y
        screen(2, 3) = z

        vr = multiplication(v, view)
        vs = multiplication(vr, screen)
    End Sub

    Sub scale(times As Integer)
        screen(0, 0) = times
        screen(1, 1) = -times

        vr = multiplication(v, view)
        vs = multiplication(vr, screen)
    End Sub

    Sub rotateX(tet As Double)
        'Dim sintet, costet, degtorad As Double
        'degtorad = Math.PI * (deg / 180)
        'sintet = Math.Sin(degtorad)
        'costet = Math.Cos(degtorad)
        'view(1, 1) = costet
        'view(1, 2) = -sintet
        'view(2, 1) = sintet
        'view(2, 2) = costet
        'vr = multiplication(v, view)
        'vs = multiplication(vr, screen)

        Dim deg As Double
        deg = tet - alpha
        alpha = tet

        Dim t1(3, 3) As Double
        Dim t2(3, 3) As Double

        SetRotationMatrix(t1, deg, 1)
        t2 = view
        view = MatrixMultiplication(t1, t2)
        vr = multiplication(v, view)
        vs = multiplication(vr, screen)
    End Sub

    Sub SetRotationMatrix(ByRef mx As Double(,), tet As Double, ax As Integer)
        Dim sintet, costet, degtorad As Double
        degtorad = Math.PI * (tet / 180)
        sintet = Math.Sin(degtorad)
        costet = Math.Cos(degtorad)

        If ax = 1 Then
            mx = {
                {1, 0, 0, 0},
                {0, costet, sintet, 0},
                {0, -sintet, costet, 0},
                {0, 0, 0, 1}
            }
        ElseIf ax = 0 Then
            mx = {
                {costet, 0, -sintet, 0},
                {0, 1, 0, 0},
                {sintet, 0, costet, 0},
                {0, 0, 0, 1}
            }
        End If
    End Sub

    Sub rotateY(tet As Double)
        'Dim sintet, costet, degtorad As Double
        'degtorad = Math.PI * (deg / 180)
        'sintet = Math.Sin(degtorad)
        'costet = Math.Cos(degtorad)

        'view(0, 0) = costet
        'view(0, 2) = -sintet
        'view(2, 0) = sintet
        'view(2, 2) = costet

        'vr = multiplication(v, view)

        'vs = multiplication(vr, screen)
        Dim deg As Double
        deg = tet - alpha
        alpha = tet

        Dim t1(3, 3) As Double
        Dim t2(3, 3) As Double

        SetRotationMatrix(t1, deg, 0)
        t2 = view
        view = MatrixMultiplication(t1, t2)
        vr = multiplication(v, view)
        vs = multiplication(vr, screen)
    End Sub

    Function multiplication(origin As List(Of Tpoint), multiplier(,) As Double) As List(Of Tpoint)
        Dim result As List(Of Tpoint) = New List(Of Tpoint)

        For i = 0 To origin.Count - 1
            result.Add(New Tpoint(
                       origin(i).x * multiplier(0, 0) + origin(i).y * multiplier(0, 1) + origin(i).z * multiplier(0, 2) + origin(i).w * multiplier(0, 3),
                       origin(i).x * multiplier(1, 0) + origin(i).y * multiplier(1, 1) + origin(i).z * multiplier(1, 2) + origin(i).w * multiplier(1, 3),
                       origin(i).x * multiplier(2, 0) + origin(i).y * multiplier(2, 1) + origin(i).z * multiplier(2, 2) + origin(i).w * multiplier(2, 3),
                       origin(i).x * multiplier(3, 0) + origin(i).y * multiplier(3, 1) + origin(i).z * multiplier(3, 2) + origin(i).w * multiplier(3, 3)
            ))
        Next

        Return result
    End Function

    Function MatrixMultiplication(M1(,) As Double, M2(,) As Double) As Double(,)
        Dim temp(3, 3) As Double
        For i = 0 To 3
            temp(i, 0) = M1(i, 0) * M2(0, 0) + M1(i, 1) * M2(1, 0) + M1(i, 2) * M2(2, 0) + M1(i, 3) * M2(3, 0)
            temp(i, 1) = M1(i, 0) * M2(0, 1) + M1(i, 1) * M2(1, 1) + M1(i, 2) * M2(2, 1) + M1(i, 3) * M2(3, 1)
            temp(i, 2) = M1(i, 0) * M2(0, 2) + M1(i, 1) * M2(1, 2) + M1(i, 2) * M2(2, 2) + M1(i, 3) * M2(3, 2)
            temp(i, 3) = M1(i, 0) * M2(0, 3) + M1(i, 1) * M2(1, 3) + M1(i, 2) * M2(2, 3) + M1(i, 3) * M2(3, 3)
        Next
        Return temp
    End Function
End Class

Public Class LBox
    Public LBox As List(Of Box) = New List(Of Box)

    Sub RotateX(deg As Double)
        For Each Box In LBox
            Box.rotateX(deg)
        Next
    End Sub

    Sub RotateY(deg As Double)
        For Each Box In LBox
            Box.rotateY(deg)
        Next
    End Sub

    Sub Translate(X As Double, Y As Double, Z As Double)
        For Each Box In LBox
            Box.translate(X, Y, Z)
        Next
    End Sub
End Class

Public Class Robot
    Public Robot As List(Of LBox) = New List(Of LBox)

    Sub RotateX(deg As Double)
        For Each Boxes In Robot
            For Each Box In Boxes.LBox
                Box.rotateX(deg)
            Next
        Next
    End Sub

    Sub RotateY(deg As Double)
        For Each Boxes In Robot
            For Each Box In Boxes.LBox
                Box.rotateY(deg)
            Next
        Next
    End Sub

    Sub Translate(X As Integer, Y As Integer, Z As Integer)
        For Each Boxes In Robot
            For Each Box In Boxes.LBox

                Box.translate(Box.screen(0, 3) - X, Box.screen(1, 3) - Y, Box.screen(2, 3) - Z)
            Next
        Next
    End Sub
End Class

'Public Class Object3D 'Cuboid contains array of vertices and array of edges
'Public vertices(7) As Point
'Public edges(11) As Line
''Sub SetPoint(index As Integer, x As Double, y As Double, z As Double)
'vertices(index) = New Point(x, y, z, 1)
'End Sub
'End Class

'Public Class List3DObject
'Public First As ElmtList3DObject
'End Class

'Public Class ElmtList3DObject
'Public Child As List3DObject
'Public Nxt As ElmtList3DObject
'Public Axisrot As Char
'Public alpha As Double
'Public Obj As Object3D
'Public Transform(3, 3) As Double
'End Class
