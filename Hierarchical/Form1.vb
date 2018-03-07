Public Class Form1
    Private Const cos30 = 0.86602540378
    Private Const sin45 = 0.70710678118

    Dim btp As Bitmap
    Dim g As Graphics

    Public v, vr, vs As List(Of Tpoint)
    Dim view(3, 3), screen(3, 3) As Double
    Dim edge As List(Of LineIndex)
    Dim degree As Integer = 0

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        degree += 2
        view(1, 1) = sin45 * Math.Sin(degree * Math.PI / 180)
        view(1, 1) = Math.Cos(degree * Math.PI / 180)
        view(1, 2) = -sin45 * Math.Sin(degree * Math.PI / 180)
        drawCube()
    End Sub

    Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
        Dim MoveForward(3, 3) As Double
        MoveForward = New Double(3, 3) {
        {0.86, 0, -0.5, 0},         'cost 0 -sint 0 30
        {0, 1, 0, 0},               '0 1 0 0
        {0.5, 0, 0.86, 0},          'sint 0 cost 0
        {0, 0, 0, 1}                '0 0 0 1
        }

        vr = multiplication(vr, MoveForward)
        drawCube()
    End Sub

    Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
        screen(0, 3) = 200 + TrackBar2.Value
        drawCube()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        v = New List(Of Tpoint)
        vr = New List(Of Tpoint)
        vs = New List(Of Tpoint)

        edge = New List(Of LineIndex)

        btp = New Bitmap(pbCanvas.Width, pbCanvas.Height)
        g = Graphics.FromImage(btp)
        g.Clear(Color.White)

        v.Add(New Tpoint(-1, -1, 1, 1)) '1
        v.Add(New Tpoint(1, -1, 1, 1)) '2
        v.Add(New Tpoint(1, -1, -1, 1)) '3
        v.Add(New Tpoint(-1, -1, -1, 1)) '4
        v.Add(New Tpoint(-1, 1, 1, 1)) '5
        v.Add(New Tpoint(1, 1, 1, 1)) '6
        v.Add(New Tpoint(1, 1, -1, 1)) '7
        v.Add(New Tpoint(-1, 1, -1, 1)) '8

        edge.Add(New LineIndex(0, 1)) '1
        edge.Add(New LineIndex(1, 2)) '2
        edge.Add(New LineIndex(2, 3)) '3
        edge.Add(New LineIndex(3, 0)) '4
        edge.Add(New LineIndex(0, 4)) '5
        edge.Add(New LineIndex(1, 5)) '6
        edge.Add(New LineIndex(2, 6)) '7
        edge.Add(New LineIndex(3, 7)) '8
        edge.Add(New LineIndex(4, 5)) '9
        edge.Add(New LineIndex(5, 6)) '10
        edge.Add(New LineIndex(6, 7)) '11
        edge.Add(New LineIndex(7, 4)) '12

        view = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, -0.2}, 'cop= 5
            {0, 0, 0, 1}
        }

        screen = New Double(3, 3) {
            {50, 0, 0, 200},
            {0, -50, 0, 200},
            {0, 0, 0, 0},
            {0, 0, 0, 1}
        }

        vr = multiplication(v, view)



        Timer1.Enabled = False
        drawCube()
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

    Private Sub drawCube()
        g.Clear(Color.White)

        vs = multiplication(vr, screen)

        Dim a, b, c, d As Integer
        For i = 0 To edge.Count - 1
            a = vs(edge(i).p1).x
            b = vs(edge(i).p1).y
            c = vs(edge(i).p2).x
            d = vs(edge(i).p2).y
            If i = 6 Or i = 7 Or i = 2 Or i = 10 Then
                g.DrawLine(Pens.Red, a, b, c, d)
            Else
                g.DrawLine(Pens.Black, a, b, c, d)
            End If
        Next

        'test gambar garis x0 y0
        g.DrawLine(Pens.Black, -100, 0, 100, 0)
        g.DrawLine(Pens.Black, 0, -100, 0, 100)

        pbCanvas.Image = btp
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
