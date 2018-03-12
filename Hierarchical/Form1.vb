Public Class Form1
    Public Boxes As List(Of Box) = New List(Of Box)
    Dim cos30 As Double = 0.86602540378
    Dim sin45 As Double = 0.70710678118
    Dim btp As Bitmap
    Dim g As Graphics

    Dim degree As Integer = 0

    Dim axis As String

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

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Boxes(0).rotateY(TrackBar1.Value)
        Boxes(1).rotateY(TrackBar1.Value)

        drawCube()
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        Boxes(0).rotateX(TrackBar2.Value)
        Boxes(1).rotateX(TrackBar2.Value)

        drawCube()
    End Sub

    Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles btnForward.Click
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

    Private Sub btnBackward_Click(sender As Object, e As EventArgs) Handles btnBackward.Click
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

    Private Sub btnStop_Click(sender As Object, e As EventArgs) Handles btnStop.Click
        'Timer1.Enabled = False
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btp = New Bitmap(pbCanvas.Width, pbCanvas.Height)
        g = Graphics.FromImage(btp)
        g.Clear(Color.White)

        Boxes.Add(New Box())
        Boxes(0).scale(50)
        Boxes(0).translate(200, 200)

        Boxes.Add(New Box())
        Boxes(1).scale(20)
        Boxes(1).translate(200, 130)

        Timer1.Enabled = False
        drawCube()
    End Sub

    Private Sub drawCube()
        g.Clear(Color.White)
        Dim a, b, c, d As Integer

        For Each Box In Boxes
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
            pbCanvas.Image = btp
        Next
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

    Sub translate(x As Integer, y As Integer)
        screen(0, 3) = x
        screen(1, 3) = y

        vr = multiplication(v, view)
        vs = multiplication(vr, screen)
    End Sub
    Sub scale(times As Integer)
        screen(0, 0) = times
        screen(1, 1) = -times

        vr = multiplication(v, view)
        vs = multiplication(vr, screen)
    End Sub

    Sub rotateX(deg As Double)
        Dim sintet, costet, degtorad As Double
        degtorad = Math.PI * (deg / 180)
        sintet = Math.Sin(degtorad)
        costet = Math.Cos(degtorad)
        view(1, 1) = costet
        view(1, 2) = -sintet
        view(2, 1) = sintet
        view(2, 2) = costet

        vr = multiplication(v, view)
        vs = multiplication(vr, screen)
    End Sub

    Sub rotateY(deg As Double)
        Dim sintet, costet, degtorad As Double
        degtorad = Math.PI * (deg / 180)
        sintet = Math.Sin(degtorad)
        costet = Math.Cos(degtorad)

        view(0, 0) = costet
        view(0, 2) = -sintet
        view(2, 0) = sintet
        view(2, 2) = costet

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
