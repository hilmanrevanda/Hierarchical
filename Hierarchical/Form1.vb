Public Class Form1
    Dim btp As Bitmap
    Dim g As Graphics
    Dim last As Double = 0
    'belok
    Public Deg As Integer = 0

    'baru
    Public Stack As New Stack

    Public Vt(3, 3), Vpervective(3, 3), St(3, 3) As Double
    Public World, Robot, Robot2 As New Listof3DObject

    Public calc As Matrix = New Matrix

    'parts
    Public R1Arm1, R1RUArm1, R1RLArm1, R1RClaws1, R1RClaws11, R1RClaws12, R1Arm2, R1RUArm2, R1RLArm2, R1RClaws2, R1RClaws21, R1RClaws22 As Listof3DObject 'robot1
    Public R2Arm1, R2RUArm1, R2RLArm1, R2RClaws1, R2RClaws11, R2RClaws12, R2Arm2, R2RUArm2, R2RLArm2, R2RClaws2, R2RClaws21, R2RClaws22 As Listof3DObject 'robot1

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub


    'Move
    Public StartX, StartY As Integer
    Public Move As Boolean = False
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

        Process(World)
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


    End Sub

    Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles btnForward.Click
        Robot.Scale(0.1)
        Draw()
    End Sub

    Private Sub btnBackward_Click(sender As Object, e As EventArgs) Handles btnBackward.Click
        Robot.Scale(-0.1)
        Draw()
    End Sub

    Private Sub pbCanvas_MouseUp(sender As Object, e As MouseEventArgs) Handles pbCanvas.MouseUp
        Move = False
    End Sub

    Private Sub pbCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles pbCanvas.MouseMove
        If Move Then
            Robot.Rotate(StartX - e.X, "y")
            Robot.Rotate(StartY - e.Y, "x")

            Robot2.Rotate(StartX - e.X, "y")
            Robot2.Rotate(StartY - e.Y, "x")
            Draw()
        End If
    End Sub

    Sub InitObject()
        'New(xmin As Double, ymin As Double, zmin As Double, xmax As Double, ymax As Double, zmax As Double)
        World = New Listof3DObject
        World.Create(0, 0, 0)
        'World.Object3D = New Object3D(-5, -5, -5, 5, 5, 5)

        Robot = New Listof3DObject
        Robot.Create(0, 0, 0) 'body
        Robot.Object3D = New Object3D(-1.5, -1, -1, 1.5, 1, 1)
        'Robot.Translateto(2, "z")
        World.Child = Robot


        RUArm = New Listof3DObject
        RUArm.Create(-1.5, 0.75, 0)
        RUArm.Object3D = New Object3D(-0.5, -0.75, -0.25, 0, 0.25, 0.25)
        Robot.Child = RUArm

        R1RLArm1 = New Listof3DObject
        R1RLArm1.Create(0, -0.75, 0)
        'RLArm.Object3D = New Object3D(-0.5, -1, -1, 0.5, 1, 1)
        R1RUArm1.Nxt = R1RLArm1

        RClaws = New Listof3DObject
        RClaws.Create(0, 0, 0)
        'RClaws.Object3D = New Object3D(-1.5, -1, -1, 1.5, 1, 1)
        RLArm.Child = RClaws

        R1RClaws11 = New Listof3DObject
        R1RClaws11.Create(-0.5, 0.5, 0)
        R1RClaws11.Object3D = New Object3D(0.35, -1.0, -0.2, 0.45, -0.8, 0.2)
        R1RClaws1.Child = R1RClaws11

        R1RClaws12 = New Listof3DObject
        R1RClaws12.Create(-0.26, 0.5, 0)
        R1RClaws12.Object3D = New Object3D(0.35, -1.0, -0.2, 0.45, -0.8, 0.2)
        R1RClaws11.Nxt = R1RClaws12

        'ARM2
        R1Arm2 = New Listof3DObject
        R1Arm2.Create(-1.75, 0.5, 0)
        'Arm.Object3D = New Object3D(-0.5, -1, -1, 0.5, 1, 1)
        R1Arm1.Nxt = R1Arm2

        R1RUArm2 = New Listof3DObject
        R1RUArm2.Create(0, -0.5, 0)
        R1RUArm2.Object3D = New Object3D(-0.25, -0.5, -0.25, 0.25, 0.5, 0.25)
        R1Arm2.Child = R1RUArm2

        R1RLArm2 = New Listof3DObject
        R1RLArm2.Create(0, -0.75, 0)
        'RLArm.Object3D = New Object3D(-0.5, -1, -1, 0.5, 1, 1)
        R1RUArm2.Nxt = R1RLArm2

        R1RLArm2.Child = New Listof3DObject
        R1RLArm2.Child.Create(0, -0.75, 0)
        R1RLArm2.Child.Object3D = New Object3D(-0.25, -0.25, -0.25, 0.25, 0.5, 0.25)

        R1RClaws2 = New Listof3DObject
        R1RClaws2.Create(0, 0, 0)
        'RClaws.Object3D = New Object3D(-1.5, -1, -1, 1.5, 1, 1)
        R1RLArm2.Child.Child = R1RClaws2

        R1RClaws21 = New Listof3DObject
        R1RClaws21.Create(-0.5, 0.5, 0)
        R1RClaws21.Object3D = New Object3D(0.35, -1.0, -0.2, 0.45, -0.8, 0.2)
        R1RClaws2.Child = R1RClaws21

        R1RClaws22 = New Listof3DObject
        R1RClaws22.Create(-0.26, 0.5, 0)
        R1RClaws22.Object3D = New Object3D(0.35, -1.0, -0.2, 0.45, -0.8, 0.2)
        R1RClaws21.Nxt = R1RClaws22

        R1Arm2.Translateto(3.5, "x") 'copy arm left to right

        World.Child.Translateto(-3, "x")

        'robot 2
        Robot2 = New Listof3DObject
        Robot2.Create(0, 0, 0) 'body
        Robot2.Object3D = New Object3D(-1.5, -1, -1, 1.5, 1, 1)
        'Robot.Translateto(2, "z")
        Robot.Nxt = Robot2

        'ARM1
        R2Arm1 = New Listof3DObject
        R2Arm1.Create(-1.75, 0.5, 0)
        'Arm.Object3D = New Object3D(-0.5, -1, -1, 0.5, 1, 1)
        Robot2.Child = R2Arm1

        R2RUArm1 = New Listof3DObject
        R2RUArm1.Create(0, -0.5, 0)
        R2RUArm1.Object3D = New Object3D(-0.25, -0.5, -0.25, 0.25, 0.5, 0.25)
        R2Arm1.Child = R2RUArm1

        R2RLArm1 = New Listof3DObject
        R2RLArm1.Create(0, -0.75, 0)
        'RLArm.Object3D = New Object3D(-0.5, -1, -1, 0.5, 1, 1)
        R2RUArm1.Nxt = R2RLArm1

        R2RLArm1.Child = New Listof3DObject
        R2RLArm1.Child.Create(0, -0.75, 0)
        R2RLArm1.Child.Object3D = New Object3D(-0.25, -0.25, -0.25, 0.25, 0.5, 0.25)

        R2RClaws1 = New Listof3DObject
        R2RClaws1.Create(0, 0, 0)
        'RClaws.Object3D = New Object3D(-1.5, -1, -1, 1.5, 1, 1)
        R2RLArm1.Child.Child = R2RClaws1

        R2RClaws11 = New Listof3DObject
        R2RClaws11.Create(-0.5, 0.5, 0)
        R2RClaws11.Object3D = New Object3D(0.35, -1.0, -0.2, 0.45, -0.8, 0.2)
        R2RClaws1.Child = R2RClaws11

        R2RClaws12 = New Listof3DObject
        R2RClaws12.Create(-0.26, 0.5, 0)
        R2RClaws12.Object3D = New Object3D(0.35, -1.0, -0.2, 0.45, -0.8, 0.2)
        R2RClaws11.Nxt = R2RClaws12

        'ARM2
        R2Arm2 = New Listof3DObject
        R2Arm2.Create(-1.75, 0.5, 0)
        'Arm.Object3D = New Object3D(-0.5, -1, -1, 0.5, 1, 1)
        R2Arm1.Nxt = R2Arm2

        R2RUArm2 = New Listof3DObject
        R2RUArm2.Create(0, -0.5, 0)
        R2RUArm2.Object3D = New Object3D(-0.25, -0.5, -0.25, 0.25, 0.5, 0.25)
        R2Arm2.Child = R2RUArm2

        R2RLArm2 = New Listof3DObject
        R2RLArm2.Create(0, -0.75, 0)
        'RLArm.Object3D = New Object3D(-0.5, -1, -1, 0.5, 1, 1)
        R2RUArm2.Nxt = R2RLArm2

        R2RLArm2.Child = New Listof3DObject
        R2RLArm2.Child.Create(0, -0.75, 0)
        R2RLArm2.Child.Object3D = New Object3D(-0.25, -0.25, -0.25, 0.25, 0.5, 0.25)

        R2RClaws2 = New Listof3DObject
        R2RClaws2.Create(0, 0, 0)
        'RClaws.Object3D = New Object3D(-1.5, -1, -1, 1.5, 1, 1)
        R2RLArm2.Child.Child = R2RClaws2

        R2RClaws21 = New Listof3DObject
        R2RClaws21.Create(-0.5, 0.5, 0)
        R2RClaws21.Object3D = New Object3D(0.35, -1.0, -0.2, 0.45, -0.8, 0.2)
        R2RClaws2.Child = R2RClaws21

        R2RClaws22 = New Listof3DObject
        R2RClaws22.Create(-0.26, 0.5, 0)
        R2RClaws22.Object3D = New Object3D(0.35, -1.0, -0.2, 0.45, -0.8, 0.2)
        R2RClaws21.Nxt = R2RClaws22

        R2Arm2.Translateto(3.5, "x") 'copy arm left to right

        Robot2.Translateto(3, "x")
    End Sub
    Private Sub tbTorsoR_Scroll(sender As Object, e As EventArgs) Handles tbTorsoR.Scroll
        Robot.Rotate(tbTorsoR.Value, "y")
        Draw()
    End Sub

    Private Sub tbTorsoL_Scroll(sender As Object, e As EventArgs) Handles tbTorsoL.Scroll
        Robot.Rotate(-tbTorsoL.Value, "y")
        Draw()
    End Sub

    Private Sub tbClaw_Scroll(sender As Object, e As EventArgs) Handles tbClaw.Scroll
        Dim a As Double = tbClaw.Value

        If rbLeft.Checked Then
            If rbRobot1.Checked Then
                R1RClaws1.Rotate(-a, "y")
            ElseIf rbRobot2.Checked Then
                R2RClaws1.Rotate(-a, "y")
            End If
        ElseIf rbRight.Checked Then
            If rbRobot1.Checked Then
                R1RClaws2.Rotate(-a, "y")
            ElseIf rbRobot2.Checked Then
                R2RClaws2.Rotate(-a, "y")
            End If
        Else
            MsgBox("Side not declared")
            tbUpperArm.Value = 0
        End If
        Draw()

    End Sub

    Private Sub tbTweeze_Scroll(sender As Object, e As EventArgs) Handles tbTweeze.Scroll
        Dim a As Double = tbTweeze.Value
        'LClaw1.Rotate(a, "z")
        'LClaw2.Rotate(-a, "z")

        If rbLeft.Checked Then
            If rbRobot1.Checked Then
                R1RClaws11.Translateto(tbTweeze.Value / 100, "x")
                R1RClaws12.Translateto(-tbTweeze.Value / 100, "x")
            ElseIf rbRobot2.Checked Then
                R2RClaws11.Translateto(tbTweeze.Value / 100, "x")
                R2RClaws12.Translateto(-tbTweeze.Value / 100, "x")
            End If
        ElseIf rbRight.Checked Then
            If rbRobot1.Checked Then
                R1RClaws21.Translateto(tbTweeze.Value / 100, "x")
                R1RClaws22.Translateto(-tbTweeze.Value / 100, "x")
            ElseIf rbRobot2.Checked Then
                R2RClaws21.Translateto(tbTweeze.Value / 100, "x")
                R2RClaws22.Translateto(-tbTweeze.Value / 100, "x")
            End If
        Else
            MsgBox("Side not declared")
            tbUpperArm.Value = 0
        End If
        Draw()
        RClaws.Rotate(-a, "y")
        Draw()
        RLClaw1.Translateto(tbTweeze.Value / 100, "x")
        RLClaw2.Translateto(-tbTweeze.Value / 100, "x")
        Draw()
    End Sub

    Private Sub tbUnderArm_Scroll(sender As Object, e As EventArgs) Handles tbUnderArm.Scroll
        Dim a As Double = tbUnderArm.Value
        If rbLeft.Checked Then
            If rbRobot1.Checked Then
                R1RLArm1.Rotate(-a, "x")
            ElseIf rbRobot2.Checked Then
                R2RLArm1.Rotate(-a, "x")
            End If
        ElseIf rbRight.Checked Then
            If rbRobot1.Checked Then
                R1RLArm2.Rotate(-a, "x")
            ElseIf rbRobot2.Checked Then
                R2RLArm2.Rotate(-a, "x")
            End If
        Else
            MsgBox("Side not declared")
            tbUnderArm.Value = 0
        End If
        Draw()
    End Sub

    Private Sub tbUpperArm_Scroll(sender As Object, e As EventArgs) Handles tbUpperArm.Scroll
        Dim a As Double = tbUpperArm.Value

        If rbLeft.Checked Then
            If rbRobot1.Checked Then
                R1Arm1.Rotate(-a, "x")
            ElseIf rbRobot2.Checked Then
                R2Arm1.Rotate(-a, "x")
            End If
        ElseIf rbRight.Checked Then
            If rbRobot1.Checked Then
                R1Arm2.Rotate(-a, "x")
            ElseIf rbRobot2.Checked Then
                R2Arm2.Rotate(-a, "x")
            End If
        Else
            MsgBox("Side not declared")
            tbUpperArm.Value = 0
        End If
        Draw()
    End Sub

    'panah
    Protected Overrides Function ProcessCmdKey(ByRef msg As Message, ByVal keyData As Keys) As Boolean

        'detect up arrow key
        If keyData = Keys.Up Then
            Robot.Scale(0.1)
            Draw()
            Return True
        End If
        'detect down arrow key
        If keyData = Keys.Down Then
            Robot.Scale(-0.1)
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


    Private Sub pbCanvas_MouseDown(sender As Object, e As MouseEventArgs) Handles pbCanvas.MouseDown
        Move = True
        StartX = e.X
        StartY = e.Y

    End Sub

    Private Sub btnForward_Click(sender As Object, e As EventArgs) Handles btnForward.Click
        Robot.Scale(0.1)
        Draw()
    End Sub

    Private Sub btnBackward_Click(sender As Object, e As EventArgs) Handles btnBackward.Click
        Robot.Scale(-0.1)
        Draw()
    End Sub

    Private Sub pbCanvas_MouseUp(sender As Object, e As MouseEventArgs) Handles pbCanvas.MouseUp
        Move = False
    End Sub

    Private Sub pbCanvas_MouseMove(sender As Object, e As MouseEventArgs) Handles pbCanvas.MouseMove
        If Move Then
            Robot.Rotate(StartX - e.X, "y")
            Robot.Rotate(StartY - e.Y, "x")

            Robot2.Rotate(StartX - e.X, "y")
            Robot2.Rotate(StartY - e.Y, "x")
            Draw()
        End If
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
    Public Translate As Double = 0

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
                    {costet, sintet, 0, 0},
                    {-sintet, costet, 0, 0},
                    {0, 0, 1, 0},
                    {0, 0, 0, 1}
                }
        End If

        Transform = calc.MatrixMultiplication(t1, Transform)
    End Sub

    Public Sub Translateto(newest As Double, Axis As Char)
        Dim current As Double
        current = newest - Translate
        Translate = newest

        Dim Matrix(3, 3) As Double
        Matrix = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1}
        }

        If (Axis = "x") Then
            Matrix(3, 0) = current
        ElseIf (Axis = "y") Then
            Matrix(3, 1) = current
        ElseIf (Axis = "z") Then
            Matrix(3, 2) = current
        End If

        Transform = calc.MatrixMultiplication(Matrix, Transform)
    End Sub

    Sub Scale(value As Double)
        Dim Matrix(3, 3) As Double
        Matrix = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {0, 0, 0, 1}
        }

        Matrix(3, 2) = value

        Transform = calc.MatrixMultiplication(Matrix, Transform)
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