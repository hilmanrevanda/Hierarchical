Public Class Form1
    Dim btp As Bitmap
    Dim g As Graphics

    'belok
    Public Deg As Integer = 0

    'baru
    Public Stack As New Stack

    Public Vt(3, 3), Vpervective(3, 3), St(3, 3) As Double
    Public Robot As New Listof3DObject

    Public calc As Matrix = New Matrix

    'parts
    Public Arm, LArm, Claws, LClaw1, LClaw2 As Listof3DObject

    'Private Sub TrackBar1_Scroll(sender As Object, e As EventArgs) Handles TrackBar1.Scroll
    '    Dim a As Double = TrackBar1.Value

    '    Dim Matrix(3, 3) As Double
    '    Matrix = New Double(3, 3) {
    '        {1, 0, 0, 0},
    '        {0, 1, 0, 0},
    '        {0, 0, 1, 0},
    '        {0, 0, 0, 1}
    '    }

    '    Matrix(3, 0) = a / 1000
    '    World.Transform = calc.MatrixMultiplication(Matrix, World.Transform)
    '    Draw()
    'End Sub

    'Private Sub TrackBar2_Scroll(sender As Object, e As EventArgs) Handles TrackBar2.Scroll
    '    Dim a As Double = TrackBar2.Value
    '    World.Axis = "x"
    '    World.Rotate(a)
    '    'World.Nxt.Rotate(a)
    '    Draw()
    'End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btp = New Bitmap(pbCanvas.Width, pbCanvas.Height)
        g = Graphics.FromImage(btp)
        g.Clear(Color.White)

        InitValue() ' st vt vpers

        InitObject()

        Draw()
    End Sub

    Sub Draw()
        g.Clear(Color.White)

        Dim temp(3, 3) As Double
        temp = calc.MatrixMultiplication(Vt, Vpervective)

        Stack.Push(temp)

        Process(Robot)
    End Sub

    Sub Process(start As Listof3DObject)
        Dim T(3, 3) As Double

        While Not IsNothing(start)
            T = calc.MatrixMultiplication(start.Transform, Stack.Peek())
            Stack.Push(T)

            Process(start.Child)

            If Not IsNothing(start.Object3D) Then
                'Draw Object
                Dim Trans(,) As Double
                Trans = Stack.Pop()

                Dim points(7) As pnt
                Dim point1, point2 As Point

                For i = 0 To points.Length - 1
                    points(i) = calc.MultiplyPointMatrix(start.Object3D.vertices(i), Trans)
                    points(i) = calc.MultiplyPointMatrix(points(i), St)
                Next

                For i = 0 To 11
                    point1.X = points(start.Object3D.edges(i).p1).x / points(start.Object3D.edges(i).p1).w
                    point1.Y = points(start.Object3D.edges(i).p1).y / points(start.Object3D.edges(i).p1).w
                    point2.X = points(start.Object3D.edges(i).p2).x / points(start.Object3D.edges(i).p2).w
                    point2.Y = points(start.Object3D.edges(i).p2).y / points(start.Object3D.edges(i).p2).w

                    If i <= 3 Then
                        g.DrawLine(Pens.Red, point1, point2)
                    Else
                        g.DrawLine(Pens.Black, point1, point2)
                    End If
                Next

            Else
                Stack.Pop()
            End If

            start = start.Nxt
        End While
        pbCanvas.Image = btp
    End Sub

    Sub InitObject()
        'New(xmin As Double, ymin As Double, zmin As Double, xmax As Double, ymax As Double, zmax As Double)
        Robot = New Listof3DObject

        Robot.Create(0, 0, 0) 'body
        Robot.Object3D = New Object3D(-1.5, -1, -1, 1.5, 1, 1)

        Arm = New Listof3DObject
        Arm.Create(-1.5, 0.75, 0)
        Arm.Object3D = New Object3D(-0.5, -0.75, -0.25, 0, 0.25, 0.25)
        Robot.Child = Arm

        LArm = New Listof3DObject
        LArm.Create(-0.25, -0.25, 0)
        LArm.Object3D = New Object3D(-0.25, -0.5, -0.25, 0.25, -1.0, 0.25)
        Arm.Child = LArm

        Claws = New Listof3DObject
        Claws.Create(0, 0, 0)
        LArm.Child = Claws

        LClaw1 = New Listof3DObject
        LClaw1.Create(-0.5, -0.2, 0)
        LClaw1.Object3D = New Object3D(0.35, -1.0, -0.2, 0.45, -0.8, 0.2)
        Claws.Child = LClaw1

        LClaw2 = New Listof3DObject
        LClaw2.Create(-0.5, -0.2, 0)
        LClaw2.Object3D = New Object3D(0.55, -1.0, -0.2, 0.65, -0.8, 0.2)
        LClaw1.Nxt = LClaw2

        'World.Child = New Listof3DObject
        'World.Child.Create(-1.5, 0.75, 0, "x")
        'World.Child.Object3D = New Object3D(-0.5, -0.25, -0.25, 0, 0.25, 0.25)

        'World.Child.Child = New Listof3DObject
        'World.Child.Child.Create(-0.25, -0.25, 0, "z")
        'World.Child.Child.Object3D = New Object3D(-0.25, -0.5, -0.25, 0.25, 0, 0.25)

        'codingan  tahun lalu
        'RUpperArm = New TElmtList3DObject(-0.25, -0.25, 0, "z", 0)
        'RightShoulder.Child = New TList3DObject
        'RightShoulder.Child.First = RUpperArm
        'RUpperArm.Obj = New T3DObject(-0.25, -0.5, -0.25, 0.25, 0, 0.25)

        'RLowerArm = New TElmtList3DObject(0, -0.5, 0, "x", -90)
        'RUpperArm.Child = New TList3DObject
        'RUpperArm.Child.First = RLowerArm
        'RLowerArm.Obj = New T3DObject(-0.25, -1, -0.25, 0.25, 0, 0.25)

        'RWrist = New TElmtList3DObject(0, -1, 0, "y", 0)
        'RLowerArm.Child = New TList3DObject
        'RLowerArm.Child.First = RWrist

        'RClaw1 = New TElmtList3DObject(-0.125, 0, 0, "z", 0)
        'RWrist.Child = New TList3DObject
        'RWrist.Child.First = RClaw1
        'RClaw1.Obj = New T3DObject(-0.075, -0.5, -0.25, 0.075, 0, 0.25)
        'RClaw1.Child = New TList3DObject
        'RClaw1.Child.First = Nothing

        'RClaw2 = New TElmtList3DObject(0.125, 0, 0, "z", 0)
        'RClaw1.Nxt = RClaw2
        'RClaw2.Obj = New T3DObject(-0.075, -0.5, -0.25, 0.075, 0, 0.25)
        'RClaw2.Child = New TList3DObject
        'RClaw2.Child.First = Nothing

        ''Left
        'LeftShoulder = New TElmtList3DObject(1.5, 0.75, 0, "x", 0)
        'RightShoulder.Nxt = LeftShoulder
        'LeftShoulder.Obj = New T3DObject(0, -0.25, -0.25, 0.5, 0.25, 0.25)

        'LUpperArm = New TElmtList3DObject(0.25, -0.25, 0, "z", 0)
        'LeftShoulder.Child = New TList3DObject
        'LeftShoulder.Child.First = LUpperArm
        'LUpperArm.Obj = New T3DObject(-0.25, -0.5, -0.25, 0.25, 0, 0.25)

        'LLowerArm = New TElmtList3DObject(0, -0.5, 0, "x", -90)
        'LUpperArm.Child = New TList3DObject
        'LUpperArm.Child.First = LLowerArm
        'LLowerArm.Obj = New T3DObject(-0.25, -1, -0.25, 0.25, 0, 0.25)

        'LWrist = New TElmtList3DObject(0, -1, 0, "y", 0)
        'LLowerArm.Child = New TList3DObject
        'LLowerArm.Child.First = LWrist

        'LClaw1 = New TElmtList3DObject(0.125, 0, 0, "z", 0)
        'LWrist.Child = New TList3DObject
        'LWrist.Child.First = LClaw1
        'LClaw1.Obj = New T3DObject(-0.075, -0.5, -0.25, 0.075, 0, 0.25)
        'LClaw1.Child = New TList3DObject
        'LClaw1.Child.First = Nothing

        'LClaw2 = New TElmtList3DObject(-0.125, 0, 0, "z", 0)
        'LClaw1.Nxt = LClaw2
        'LClaw2.Obj = New T3DObject(-0.075, -0.5, -0.25, 0.075, 0, 0.25)
        'LClaw2.Child = New TList3DObject
        'LClaw2.Child.First = Nothing
    End Sub

    Private Sub tbClaw_Scroll(sender As Object, e As EventArgs) Handles tbClaw.Scroll
        Dim a As Double = tbClaw.Value
        Claws.Rotate(-a, "y")
        Draw()
    End Sub

    Private Sub tbTweeze_Scroll(sender As Object, e As EventArgs) Handles tbTweeze.Scroll
        Dim a As Double = tbTweeze.Value
        LClaw1.Rotate(a, "z")
        LClaw2.Rotate(-a, "z")
        Draw()
    End Sub

    Private Sub tbUnderArm_Scroll(sender As Object, e As EventArgs) Handles tbUnderArm.Scroll
        Dim a As Double = tbUnderArm.Value
        LArm.Rotate(-a, "x")
        Draw()
    End Sub

    Private Sub tbUpperArm_Scroll(sender As Object, e As EventArgs) Handles tbUpperArm.Scroll
        Dim a As Double = tbUpperArm.Value
        Arm.Rotate(-a, "z")
        Draw()
    End Sub

    Sub InitValue()
        Dim vt1(3, 3), vt2(3, 3), st1(3, 3), st2(3, 3) As Double

        vt1 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, -0.125},
            {0, 0, 0, 1}
        }

        vt2 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 0, 0}, 'z=0
            {0, 0, 0, 1}
        }

        Vpervective = calc.MatrixMultiplication(vt1, vt2)

        st1 = New Double(3, 3) {
            {30, 0, 0, 0},  'right
            {0, -30, 0, 0}, 'below
            {0, 0, 0, 0},
            {0, 0, 0, 1}
        }

        st2 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {300, 200, 0, 1} 'translation to x and y
        }

        St = calc.MatrixMultiplication(st1, st2)

        Vt = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1}
        }
    End Sub

    'panah
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean
        Dim Matrix(3, 3) As Double
        Matrix = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1}
        }

        'detect up arrow key
        If keyData = Keys.Up Then
            Matrix(3, 2) = 0.1 'y
            Robot.Transform = calc.MatrixMultiplication(Matrix, Robot.Transform)
            Draw()
            Return True
        End If
        'detect down arrow key
        If keyData = Keys.Down Then
            Matrix(3, 2) = -0.1 'y
            Robot.Transform = calc.MatrixMultiplication(Matrix, Robot.Transform)
            Draw()
            Return True
        End If
        'detect left arrow key
        If keyData = Keys.Left Then
            Deg = Deg - 1

            Robot.Rotate(Deg, "y")
            Draw()
            Return True
        End If
        'detect right arrow key
        If keyData = Keys.Right Then
            Deg = Deg + 1

            Robot.Rotate(Deg, "y")
            Draw()
            'Matrix(3, 0) = 0.1
            'World.Transform = calc.MatrixMultiplication(Matrix, World.Transform)
            'Draw()
            Return True
        End If
        Return MyBase.ProcessCmdKey(msg, keyData)
    End Function

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'timer
    End Sub

End Class

Public Class pnt 'point
    Public x, y, z, w As Double

    Public Sub New(x As Double, y As Double, z As Double, w As Double)
        Me.x = x
        Me.y = y
        Me.z = z
        Me.w = w
    End Sub

End Class

Public Class edge
    Public p1, p2 As Integer

    Sub New(p1 As Integer, p2 As Integer)
        Me.p1 = p1
        Me.p2 = p2
    End Sub
End Class


Public Class Object3D
    Public edges As List(Of edge) = New List(Of edge)
    Public vertices As List(Of pnt) = New List(Of pnt)

    Sub New(xmin As Double, ymin As Double, zmin As Double, xmax As Double, ymax As Double, zmax As Double)
        vertices.Add(New pnt(xmin, ymax, zmax, 1))
        vertices.Add(New pnt(xmax, ymax, zmax, 1))

        vertices.Add(New pnt(xmax, ymin, zmax, 1))
        vertices.Add(New pnt(xmin, ymin, zmax, 1))

        vertices.Add(New pnt(xmin, ymax, zmin, 1))
        vertices.Add(New pnt(xmax, ymax, zmin, 1))

        vertices.Add(New pnt(xmax, ymin, zmin, 1))
        vertices.Add(New pnt(xmin, ymin, zmin, 1))

        edges.Add(New edge(0, 1))
        edges.Add(New edge(1, 2))
        edges.Add(New edge(2, 3))
        edges.Add(New edge(3, 0))
        edges.Add(New edge(0, 4))
        edges.Add(New edge(1, 5))
        edges.Add(New edge(2, 6))
        edges.Add(New edge(3, 7))
        edges.Add(New edge(4, 5))
        edges.Add(New edge(5, 6))
        edges.Add(New edge(6, 7))
        edges.Add(New edge(7, 4))
    End Sub
End Class

Public Class Listof3DObject
    Public calc As Matrix = New Matrix

    Public Object3D As Object3D
    Public Child As Listof3DObject
    Public Nxt As Listof3DObject
    Public Transform(3, 3) As Double

    Public Alphax, Alphay, Alphaz As Double

    Public Sub Create(x As Double, y As Double, z As Double)
        Alphax = 0
        Alphay = 0
        Alphaz = 0

        Transform = New Double(3, 3) {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {x, y, z, 1}
            }
    End Sub

    Public Sub Rotate(tet As Double, Axis As Char)
        Dim t1(3, 3) As Double
        Dim deg, sintet, costet As Double

        If Axis = "x" Then
            deg = tet - Alphax
            Alphax = tet
        ElseIf Axis = "y" Then
            deg = tet - Alphay
            Alphay = tet
        ElseIf Axis = "z" Then
            deg = tet - Alphaz
            Alphaz = tet
        End If

        deg = Math.PI * (deg / 180)
        sintet = Math.Sin(deg)
        costet = Math.Cos(deg)

        If (Axis = "x") Then
            t1 = New Double(3, 3) {
                    {1, 0, 0, 0},
                    {0, costet, sintet, 0},
                    {0, -sintet, costet, 0},
                    {0, 0, 0, 1}
                }
        ElseIf (Axis = "y") Then
            t1 = New Double(3, 3) {
                    {costet, 0, -sintet, 0},
                    {0, 1, 0, 0},
                    {sintet, 0, costet, 0},
                    {0, 0, 0, 1}
                }
        ElseIf (Axis = "z") Then
            t1 = New Double(3, 3) {
                    {costet, -sintet, 0, 0},
                    {sintet, costet, 0, 0},
                    {0, 0, 1, 0},
                    {0, 0, 0, 1}
                }
        End If

        Transform = calc.MatrixMultiplication(t1, Transform)
    End Sub
End Class

Public Class Matrix
    Function MatrixMultiplication(Matrix1(,) As Double, Matrix2(,) As Double) As Double(,)
        Dim temp(3, 3) As Double
        For i = 0 To 3
            temp(i, 0) = Matrix1(i, 0) * Matrix2(0, 0) + Matrix1(i, 1) * Matrix2(1, 0) + Matrix1(i, 2) * Matrix2(2, 0) + Matrix1(i, 3) * Matrix2(3, 0)
            temp(i, 1) = Matrix1(i, 0) * Matrix2(0, 1) + Matrix1(i, 1) * Matrix2(1, 1) + Matrix1(i, 2) * Matrix2(2, 1) + Matrix1(i, 3) * Matrix2(3, 1)
            temp(i, 2) = Matrix1(i, 0) * Matrix2(0, 2) + Matrix1(i, 1) * Matrix2(1, 2) + Matrix1(i, 2) * Matrix2(2, 2) + Matrix1(i, 3) * Matrix2(3, 2)
            temp(i, 3) = Matrix1(i, 0) * Matrix2(0, 3) + Matrix1(i, 1) * Matrix2(1, 3) + Matrix1(i, 2) * Matrix2(2, 3) + Matrix1(i, 3) * Matrix2(3, 3)
        Next
        Return temp
    End Function

    Function MultiplyPointMatrix(Point As pnt, Marix(,) As Double) As pnt
        Return New pnt(Point.x * Marix(0, 0) + Point.y * Marix(1, 0) + Point.z * Marix(2, 0) + Point.w * Marix(3, 0),
                       Point.x * Marix(0, 1) + Point.y * Marix(1, 1) + Point.z * Marix(2, 1) + Point.w * Marix(3, 1),
                       Point.x * Marix(0, 2) + Point.y * Marix(1, 2) + Point.z * Marix(2, 2) + Point.w * Marix(3, 2),
                       Point.x * Marix(0, 3) + Point.y * Marix(1, 3) + Point.z * Marix(2, 3) + Point.w * Marix(3, 3))
    End Function
End Class