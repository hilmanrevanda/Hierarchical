Public Class Form1
    Dim BMP As New Drawing.Bitmap(600, 400)
    Dim GFX As Graphics = Graphics.FromImage(BMP)
    Public startP, endP As Point
    Dim Pen = New Pen(Color.Black)
    Dim FrontPen = New Pen(Color.Red)
    Public Base As ElmtList3DObject

    Sub SetColMatrix(ByRef mx(,) As Double, ByVal col As Integer, ByVal a As Double, ByVal b As Double, ByVal c As Double, ByVal d As Double)
        mx(0, col) = a
        mx(1, col) = b
        mx(2, col) = c
        mx(3, col) = d
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class

Public Class Point 'coordinates of object in OCS
    Public x, y, z, w As Double
    Sub New(a As Double, b As Double, c As Double, d As Double)
        x = a
        y = b
        z = c
        w = d 'transformation
    End Sub
End Class

Public Class Line 'indexes of start point and end point of the line
    Public P1, P2 As Integer
    Sub New(d1 As Integer, d2 As Integer)
        P1 = d1
        P2 = d2
    End Sub
End Class

Public Class Object3D 'Cuboid contains array of vertices and array of edges
    Public vertices(7) As Point
    Public edges(11) As Line
    Sub SetPoint(index As Integer, x As Double, y As Double, z As Double)
        vertices(index) = New Point(x, y, z, 1)
    End Sub

End Class

Public Class List3DObject
    Public First As ElmtList3DObject
End Class

Public Class ElmtList3DObject
    Public Child As List3DObject
    Public Nxt As ElmtList3DObject
    Public Axisrot As Char
    Public alpha As Double
    Public Obj As Object3D
    Public Transform(3, 3) As Double

End Class
