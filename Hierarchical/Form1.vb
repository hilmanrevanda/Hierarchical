Public Class Form1
    Dim btp As Bitmap
    Dim g As Graphics

    'belok
    Public Deg As Integer = 0

    'baru
    Public Stack As New Stack

<<<<<<< HEAD
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
=======
    Public Vt(3, 3), Vpervective(3, 3), St(3, 3) As Double
    Public World As New Listof3DObject

    Public calc As Matrix = New Matrix

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

                    g.DrawLine(Pens.Black, point1, point2)
                Next

            Else
                Stack.Pop()
            End If

            start = start.Nxt
        End While
        pbCanvas.Image = btp
>>>>>>> 2688fd6c0e8c2c2568a09e3f0368466c4c282624
    End Sub

    Sub InitObject()

        World = New Listof3DObject
        World.Create(-3, -1, 0, "y")
        World.Object3D = New Object3D(-1.5, -1, -1, 1.5, 1, 1)

        World.Child = New Listof3DObject
        World.Child.Create(-1.5, 0.75, 0, "x")
        World.Child.Object3D = New Object3D(-0.5, -0.25, -0.25, 0, 0.25, 0.25)

        World.Child.Child = New Listof3DObject
        World.Child.Child.Create(-0.25, -0.25, 0, "z")
        World.Child.Child.Object3D = New Object3D(-0.25, -0.5, -0.25, 0.25, 0, 0.25)

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

<<<<<<< HEAD
    Private Sub tbTorsoY_Scroll(sender As Object, e As EventArgs) Handles tbTorsoY.Scroll
        For Each item In World
            item.RotateX(tbTorsoY.Value)
        Next
        'Boxes(0).rotateY(tbTorsoY.Value)
        'Boxes(1).rotateY(tbTorsoY.Value)
=======
    Sub InitValue()
        Dim vt1(3, 3), vt2(3, 3), st1(3, 3), st2(3, 3) As Double

        vt1 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, -0.125},
            {0, 0, 0, 1}
        }
>>>>>>> 2688fd6c0e8c2c2568a09e3f0368466c4c282624

        vt2 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 1}
        }

        Vpervective = calc.MatrixMultiplication(vt1, vt2)

        st1 = New Double(3, 3) {
            {30, 0, 0, 0},
            {0, -30, 0, 0},
            {0, 0, 0, 0},
            {0, 0, 0, 1}
        }

<<<<<<< HEAD
End Class

Public Class Tpoint
=======
        st2 = New Double(3, 3) {
            {1, 0, 0, 0},
            {0, 1, 0, 0},
            {0, 0, 1, 0},
            {325, 200, 0, 1}
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
            Matrix(3, 2) = 0.1
            World.Transform = calc.MatrixMultiplication(Matrix, World.Transform)
            Draw()
            Return True
        End If
        'detect down arrow key
        If keyData = Keys.Down Then
            Matrix(3, 2) = -0.1
            World.Transform = calc.MatrixMultiplication(Matrix, World.Transform)
            Draw()
            Return True
        End If
        'detect left arrow key
        If keyData = Keys.Left Then
            Deg = Deg - 1

            World.Rotate(Deg)
            Draw()
            Return True
        End If
        'detect right arrow key
        If keyData = Keys.Right Then
            Deg = Deg + 1

            World.Rotate(Deg)
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
>>>>>>> 2688fd6c0e8c2c2568a09e3f0368466c4c282624
    Public x, y, z, w As Double

    Public Sub New(x As Double, y As Double, z As Double, w As Double)
        Me.x = x
        Me.y = y
        Me.z = z
        Me.w = w
    End Sub

<<<<<<< HEAD
Public Class LineIndex
=======
End Class

Public Class edge
>>>>>>> 2688fd6c0e8c2c2568a09e3f0368466c4c282624
    Public p1, p2 As Integer

    Sub New(p1 As Integer, p2 As Integer)
        Me.p1 = p1
        Me.p2 = p2
    End Sub
End Class

<<<<<<< HEAD
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
=======

Public Class Object3D
    Public edges As List(Of edge) = New List(Of edge)
    Public vertices As List(Of pnt) = New List(Of pnt)

    Sub New(xmin As Double, ymin As Double, zmin As Double, xmax As Double, ymax As Double, zmax As Double)
        vertices.Add(New pnt(xmin, ymax, zmax, 1))
        vertices.Add(New pnt(xmax, ymax, zmax, 1))

        vertices.Add(New pnt(xmax, ymin, zmax, 1))
        vertices.Add(New pnt(xmin, ymin, zmax, 1))
>>>>>>> 2688fd6c0e8c2c2568a09e3f0368466c4c282624

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

    Public Axis As Char
    Public Alpha As Double

<<<<<<< HEAD
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
=======
    Public Overloads Sub Create(x As Double, y As Double, z As Double, Axis As Char)
        Me.Axis = Axis

        Transform = New Double(3, 3) {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {x, y, z, 1}
            }
    End Sub

    Public Overloads Sub Create(x As Double, y As Double, z As Double, Axis As Char, Alpha As Double)
        Me.Axis = Axis
        Me.Alpha = Alpha

        Dim t1(3, 3), t2(3, 3) As Double
>>>>>>> 2688fd6c0e8c2c2568a09e3f0368466c4c282624

        t1 = New Double(3, 3) {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {x, y, z, 1}
            }

        SetRotationMatrix(t2, Alpha)

        Transform = calc.MatrixMultiplication(t2, t1)
    End Sub

<<<<<<< HEAD
        SetRotationMatrix(t1, deg, 0)
        t2 = view
        view = MatrixMultiplication(t1, t2)
        vr = multiplication(v, view)
        vs = multiplication(vr, screen)
    End Sub
=======
    Sub SetRotationMatrix(ByRef mx As Double(,), tet As Double)

        Dim sintet, costet, degtorad As Double
        degtorad = Math.PI * (tet / 180)
        sintet = Math.Sin(degtorad)
        costet = Math.Cos(degtorad)

        If (Axis = "x") Then
            mx = New Double(3, 3) {
                    {1, 0, 0, 0},
                    {0, costet, sintet, 0},
                    {0, -sintet, costet, 0},
                    {0, 0, 0, 1}
                }
        ElseIf (Axis = "y") Then
            mx = New Double(3, 3) {
                    {costet, 0, -sintet, 0},
                    {0, 1, 0, 0},
                    {sintet, 0, costet, 0},
                    {0, 0, 0, 1}
                }
        ElseIf (Axis = "z") Then
            mx = New Double(3, 3) {
                    {costet, sintet, 0, 0},
                    {-sintet, costet, 0, 0},
                    {0, 0, 1, 0},
                    {0, 0, 0, 1}
                }
        End If
    End Sub

    Sub Rotate(tet As Double)
        Dim deg As Double
        deg = tet - Alpha
        Alpha = tet
>>>>>>> 2688fd6c0e8c2c2568a09e3f0368466c4c282624

        Dim t1(3, 3) As Double

        SetRotationMatrix(t1, deg)
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

<<<<<<< HEAD
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
=======
    Function MultiplyPointMatrix(Point As pnt, Marix(,) As Double) As pnt
        Return New pnt(Point.x * Marix(0, 0) + Point.y * Marix(1, 0) + Point.z * Marix(2, 0) + Point.w * Marix(3, 0),
                       Point.x * Marix(0, 1) + Point.y * Marix(1, 1) + Point.z * Marix(2, 1) + Point.w * Marix(3, 1),
                       Point.x * Marix(0, 2) + Point.y * Marix(1, 2) + Point.z * Marix(2, 2) + Point.w * Marix(3, 2),
                       Point.x * Marix(0, 3) + Point.y * Marix(1, 3) + Point.z * Marix(2, 3) + Point.w * Marix(3, 3))
    End Function
End Class
>>>>>>> 2688fd6c0e8c2c2568a09e3f0368466c4c282624
