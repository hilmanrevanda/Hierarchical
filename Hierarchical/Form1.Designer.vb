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
        Me.pbCanvas = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbRight = New System.Windows.Forms.RadioButton()
        Me.rbLeft = New System.Windows.Forms.RadioButton()
        Me.rbRobot2 = New System.Windows.Forms.RadioButton()
        Me.rbRobot1 = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbTweeze = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbClaw = New System.Windows.Forms.TrackBar()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbUnderArm = New System.Windows.Forms.TrackBar()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbUpperArm = New System.Windows.Forms.TrackBar()
        Me.tbTorsoX = New System.Windows.Forms.TrackBar()
        Me.Geser = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbTorsoY = New System.Windows.Forms.TrackBar()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnBackward = New System.Windows.Forms.Button()
        Me.btnForward = New System.Windows.Forms.Button()
        CType(Me.pbCanvas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.tbTweeze, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbClaw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbUnderArm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbUpperArm, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTorsoX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbTorsoY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbCanvas
        '
        Me.pbCanvas.Location = New System.Drawing.Point(17, 16)
        Me.pbCanvas.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pbCanvas.Name = "pbCanvas"
        Me.pbCanvas.Size = New System.Drawing.Size(773, 523)
        Me.pbCanvas.TabIndex = 0
        Me.pbCanvas.TabStop = False
        '
        'Timer1
        '
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Teal
        Me.Panel1.Controls.Add(Me.rbRight)
        Me.Panel1.Controls.Add(Me.rbLeft)
        Me.Panel1.Controls.Add(Me.rbRobot2)
        Me.Panel1.Controls.Add(Me.rbRobot1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.btnReset)
        Me.Panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Panel1.Location = New System.Drawing.Point(791, 16)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(501, 197)
        Me.Panel1.TabIndex = 23
        '
        'rbRight
        '
        Me.rbRight.AutoSize = True
        Me.rbRight.ForeColor = System.Drawing.Color.Aqua
        Me.rbRight.Location = New System.Drawing.Point(327, 153)
        Me.rbRight.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbRight.Name = "rbRight"
        Me.rbRight.Size = New System.Drawing.Size(62, 21)
        Me.rbRight.TabIndex = 29
        Me.rbRight.TabStop = True
        Me.rbRight.Text = "Right"
        Me.rbRight.UseVisualStyleBackColor = True
        '
        'rbLeft
        '
        Me.rbLeft.AutoSize = True
        Me.rbLeft.ForeColor = System.Drawing.Color.Aqua
        Me.rbLeft.Location = New System.Drawing.Point(327, 111)
        Me.rbLeft.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbLeft.Name = "rbLeft"
        Me.rbLeft.Size = New System.Drawing.Size(53, 21)
        Me.rbLeft.TabIndex = 28
        Me.rbLeft.TabStop = True
        Me.rbLeft.Text = "Left"
        Me.rbLeft.UseVisualStyleBackColor = True
        '
        'rbRobot2
        '
        Me.rbRobot2.AutoSize = True
        Me.rbRobot2.ForeColor = System.Drawing.Color.Aqua
        Me.rbRobot2.Location = New System.Drawing.Point(72, 153)
        Me.rbRobot2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbRobot2.Name = "rbRobot2"
        Me.rbRobot2.Size = New System.Drawing.Size(79, 21)
        Me.rbRobot2.TabIndex = 27
        Me.rbRobot2.TabStop = True
        Me.rbRobot2.Text = "Robot 2"
        Me.rbRobot2.UseVisualStyleBackColor = True
        '
        'rbRobot1
        '
        Me.rbRobot1.AutoSize = True
        Me.rbRobot1.ForeColor = System.Drawing.Color.Aqua
        Me.rbRobot1.Location = New System.Drawing.Point(72, 111)
        Me.rbRobot1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rbRobot1.Name = "rbRobot1"
        Me.rbRobot1.Size = New System.Drawing.Size(79, 21)
        Me.rbRobot1.TabIndex = 26
        Me.rbRobot1.TabStop = True
        Me.rbRobot1.Text = "Robot 1"
        Me.rbRobot1.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label7.Location = New System.Drawing.Point(323, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 17)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Side"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label6.Location = New System.Drawing.Point(64, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(46, 17)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "Robot"
        '
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnReset.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnReset.Location = New System.Drawing.Point(189, 21)
        Me.btnReset.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(100, 28)
        Me.btnReset.TabIndex = 23
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Teal
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.tbTweeze)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.tbClaw)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.tbUnderArm)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.tbUpperArm)
        Me.Panel2.Controls.Add(Me.tbTorsoX)
        Me.Panel2.Controls.Add(Me.Geser)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.tbTorsoY)
        Me.Panel2.Location = New System.Drawing.Point(791, 220)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(501, 208)
        Me.Panel2.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Aqua
        Me.Label5.Location = New System.Drawing.Point(269, 124)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(97, 17)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "Tweeze Claws"
        '
        'tbTweeze
        '
        Me.tbTweeze.Location = New System.Drawing.Point(269, 143)
        Me.tbTweeze.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbTweeze.Maximum = 7
        Me.tbTweeze.Name = "tbTweeze"
        Me.tbTweeze.Size = New System.Drawing.Size(209, 56)
        Me.tbTweeze.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Aqua
        Me.Label4.Location = New System.Drawing.Point(21, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 17)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Rotate Claws"
        '
        'tbClaw
        '
        Me.tbClaw.Location = New System.Drawing.Point(21, 143)
        Me.tbClaw.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbClaw.Maximum = 100
        Me.tbClaw.Name = "tbClaw"
        Me.tbClaw.Size = New System.Drawing.Size(209, 56)
        Me.tbClaw.TabIndex = 25
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Aqua
        Me.Label3.Location = New System.Drawing.Point(269, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 17)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "Rotate Under Arm"
        '
        'tbUnderArm
        '
        Me.tbUnderArm.Location = New System.Drawing.Point(269, 82)
        Me.tbUnderArm.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbUnderArm.Maximum = 100
        Me.tbUnderArm.Name = "tbUnderArm"
        Me.tbUnderArm.Size = New System.Drawing.Size(209, 56)
        Me.tbUnderArm.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Aqua
        Me.Label2.Location = New System.Drawing.Point(21, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 17)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Rotate Upper Arm"
        '
        'tbUpperArm
        '
        Me.tbUpperArm.Location = New System.Drawing.Point(21, 82)
        Me.tbUpperArm.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbUpperArm.Maximum = 100
        Me.tbUpperArm.Name = "tbUpperArm"
        Me.tbUpperArm.Size = New System.Drawing.Size(209, 56)
        Me.tbUpperArm.TabIndex = 21
        '
        'tbTorsoX
        '
        Me.tbTorsoX.Location = New System.Drawing.Point(269, 22)
        Me.tbTorsoX.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbTorsoX.Maximum = 100
        Me.tbTorsoX.Name = "tbTorsoX"
        Me.tbTorsoX.Size = New System.Drawing.Size(208, 56)
        Me.tbTorsoX.TabIndex = 20
        '
        'Geser
        '
        Me.Geser.AutoSize = True
        Me.Geser.ForeColor = System.Drawing.Color.Aqua
        Me.Geser.Location = New System.Drawing.Point(269, 4)
        Me.Geser.Name = "Geser"
        Me.Geser.Size = New System.Drawing.Size(100, 17)
        Me.Geser.TabIndex = 19
        Me.Geser.Text = "Coba 1 bagian"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Aqua
        Me.Label1.Location = New System.Drawing.Point(21, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Coba world"
        '
        'tbTorsoY
        '
        Me.tbTorsoY.Location = New System.Drawing.Point(21, 22)
        Me.tbTorsoY.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tbTorsoY.Maximum = 100
        Me.tbTorsoY.Name = "tbTorsoY"
        Me.tbTorsoY.Size = New System.Drawing.Size(209, 56)
        Me.tbTorsoY.TabIndex = 17
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Teal
        Me.Panel3.Controls.Add(Me.btnStop)
        Me.Panel3.Controls.Add(Me.btnBackward)
        Me.Panel3.Controls.Add(Me.btnForward)
        Me.Panel3.Location = New System.Drawing.Point(791, 437)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(507, 123)
        Me.Panel3.TabIndex = 25
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnStop.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnStop.Location = New System.Drawing.Point(373, 48)
        Me.btnStop.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(100, 28)
        Me.btnStop.TabIndex = 11
        Me.btnStop.Text = "Stop"
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnBackward
        '
        Me.btnBackward.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnBackward.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnBackward.Location = New System.Drawing.Point(205, 48)
        Me.btnBackward.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnBackward.Name = "btnBackward"
        Me.btnBackward.Size = New System.Drawing.Size(100, 28)
        Me.btnBackward.TabIndex = 10
        Me.btnBackward.Text = "Backward"
        Me.btnBackward.UseVisualStyleBackColor = False
        '
        'btnForward
        '
        Me.btnForward.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnForward.ForeColor = System.Drawing.Color.GhostWhite
        Me.btnForward.Location = New System.Drawing.Point(35, 48)
        Me.btnForward.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnForward.Name = "btnForward"
        Me.btnForward.Size = New System.Drawing.Size(100, 28)
        Me.btnForward.TabIndex = 9
        Me.btnForward.Text = "Forward"
        Me.btnForward.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkCyan
        Me.ClientSize = New System.Drawing.Size(1291, 554)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pbCanvas)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Hierarchical Model"
        CType(Me.pbCanvas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.tbTweeze, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbClaw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbUnderArm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbUpperArm, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTorsoX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbTorsoY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbCanvas As PictureBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents rbRight As RadioButton
    Friend WithEvents rbLeft As RadioButton
    Friend WithEvents rbRobot2 As RadioButton
    Friend WithEvents rbRobot1 As RadioButton
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents btnReset As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents tbTweeze As TrackBar
    Friend WithEvents Label4 As Label
    Friend WithEvents tbClaw As TrackBar
    Friend WithEvents Label3 As Label
    Friend WithEvents tbUnderArm As TrackBar
    Friend WithEvents Label2 As Label
    Friend WithEvents tbUpperArm As TrackBar
    Friend WithEvents tbTorsoX As TrackBar
    Friend WithEvents Geser As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tbTorsoY As TrackBar
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnStop As Button
    Friend WithEvents btnBackward As Button
    Friend WithEvents btnForward As Button
End Class
