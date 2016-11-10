<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSessionProgramme
    Inherits System.Windows.Forms.Form
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.          [Ag]
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtSession = New AgControls.AgTextBox
        Me.LblSession = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtProgramme = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtProgrammeDuration = New AgControls.AgTextBox
        Me.TxtSessionStartDate = New AgControls.AgTextBox
        Me.Tc1 = New System.Windows.Forms.TabControl
        Me.Tp1 = New System.Windows.Forms.TabPage
        Me.Tp2 = New System.Windows.Forms.TabPage
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.Tp3 = New System.Windows.Forms.TabPage
        Me.Pnl3 = New System.Windows.Forms.Panel
        Me.TxtSemesters = New AgControls.AgTextBox
        Me.TxtSemesterDuration = New AgControls.AgTextBox
        Me.Tc1.SuspendLayout()
        Me.Tp1.SuspendLayout()
        Me.Tp2.SuspendLayout()
        Me.Tp3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Topctrl1.Location = New System.Drawing.Point(0, 0)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(872, 41)
        Me.Topctrl1.TabIndex = 0
        Me.Topctrl1.tAdd = True
        Me.Topctrl1.tCancel = True
        Me.Topctrl1.tDel = True
        Me.Topctrl1.tDiscard = False
        Me.Topctrl1.tEdit = True
        Me.Topctrl1.tExit = True
        Me.Topctrl1.tFind = True
        Me.Topctrl1.tFirst = True
        Me.Topctrl1.tLast = True
        Me.Topctrl1.tNext = True
        Me.Topctrl1.tPrev = True
        Me.Topctrl1.tPrn = True
        Me.Topctrl1.tRef = True
        Me.Topctrl1.tSave = False
        Me.Topctrl1.tSite = True
        '
        'TxtSession
        '
        Me.TxtSession.AgMandatory = True
        Me.TxtSession.AgMasterHelp = False
        Me.TxtSession.AgNumberLeftPlaces = 0
        Me.TxtSession.AgNumberNegetiveAllow = False
        Me.TxtSession.AgNumberRightPlaces = 0
        Me.TxtSession.AgPickFromLastValue = False
        Me.TxtSession.AgRowFilter = ""
        Me.TxtSession.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSession.AgSelectedValue = Nothing
        Me.TxtSession.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSession.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSession.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSession.Location = New System.Drawing.Point(292, 57)
        Me.TxtSession.MaxLength = 50
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(244, 21)
        Me.TxtSession.TabIndex = 1
        '
        'LblSession
        '
        Me.LblSession.AutoSize = True
        Me.LblSession.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSession.Location = New System.Drawing.Point(189, 61)
        Me.LblSession.Name = "LblSession"
        Me.LblSession.Size = New System.Drawing.Size(51, 13)
        Me.LblSession.TabIndex = 0
        Me.LblSession.Text = "Session"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(276, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(276, 85)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Ä"
        '
        'TxtProgramme
        '
        Me.TxtProgramme.AgMandatory = True
        Me.TxtProgramme.AgMasterHelp = False
        Me.TxtProgramme.AgNumberLeftPlaces = 0
        Me.TxtProgramme.AgNumberNegetiveAllow = False
        Me.TxtProgramme.AgNumberRightPlaces = 0
        Me.TxtProgramme.AgPickFromLastValue = False
        Me.TxtProgramme.AgRowFilter = ""
        Me.TxtProgramme.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtProgramme.AgSelectedValue = Nothing
        Me.TxtProgramme.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtProgramme.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtProgramme.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProgramme.Location = New System.Drawing.Point(292, 79)
        Me.TxtProgramme.MaxLength = 50
        Me.TxtProgramme.Name = "TxtProgramme"
        Me.TxtProgramme.Size = New System.Drawing.Size(244, 21)
        Me.TxtProgramme.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(189, 82)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Programme"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(26, 5)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(538, 409)
        Me.Pnl1.TabIndex = 3
        '
        'TxtProgrammeDuration
        '
        Me.TxtProgrammeDuration.AgMandatory = True
        Me.TxtProgrammeDuration.AgMasterHelp = False
        Me.TxtProgrammeDuration.AgNumberLeftPlaces = 0
        Me.TxtProgrammeDuration.AgNumberNegetiveAllow = False
        Me.TxtProgrammeDuration.AgNumberRightPlaces = 0
        Me.TxtProgrammeDuration.AgPickFromLastValue = False
        Me.TxtProgrammeDuration.AgRowFilter = ""
        Me.TxtProgrammeDuration.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtProgrammeDuration.AgSelectedValue = Nothing
        Me.TxtProgrammeDuration.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtProgrammeDuration.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtProgrammeDuration.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProgrammeDuration.Location = New System.Drawing.Point(0, 45)
        Me.TxtProgrammeDuration.MaxLength = 50
        Me.TxtProgrammeDuration.Name = "TxtProgrammeDuration"
        Me.TxtProgrammeDuration.Size = New System.Drawing.Size(123, 21)
        Me.TxtProgrammeDuration.TabIndex = 20
        Me.TxtProgrammeDuration.Text = "TxtProgrammeDuration"
        Me.TxtProgrammeDuration.Visible = False
        '
        'TxtSessionStartDate
        '
        Me.TxtSessionStartDate.AgMandatory = True
        Me.TxtSessionStartDate.AgMasterHelp = False
        Me.TxtSessionStartDate.AgNumberLeftPlaces = 0
        Me.TxtSessionStartDate.AgNumberNegetiveAllow = False
        Me.TxtSessionStartDate.AgNumberRightPlaces = 0
        Me.TxtSessionStartDate.AgPickFromLastValue = False
        Me.TxtSessionStartDate.AgRowFilter = ""
        Me.TxtSessionStartDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSessionStartDate.AgSelectedValue = Nothing
        Me.TxtSessionStartDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSessionStartDate.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSessionStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSessionStartDate.Location = New System.Drawing.Point(0, 67)
        Me.TxtSessionStartDate.MaxLength = 50
        Me.TxtSessionStartDate.Name = "TxtSessionStartDate"
        Me.TxtSessionStartDate.Size = New System.Drawing.Size(123, 21)
        Me.TxtSessionStartDate.TabIndex = 21
        Me.TxtSessionStartDate.Text = "SessionStartDate"
        Me.TxtSessionStartDate.Visible = False
        '
        'Tc1
        '
        Me.Tc1.Controls.Add(Me.Tp1)
        Me.Tc1.Controls.Add(Me.Tp2)
        Me.Tc1.Controls.Add(Me.Tp3)
        Me.Tc1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tc1.Location = New System.Drawing.Point(107, 138)
        Me.Tc1.Name = "Tc1"
        Me.Tc1.SelectedIndex = 0
        Me.Tc1.Size = New System.Drawing.Size(600, 446)
        Me.Tc1.TabIndex = 22
        '
        'Tp1
        '
        Me.Tp1.Controls.Add(Me.Pnl1)
        Me.Tp1.Location = New System.Drawing.Point(4, 22)
        Me.Tp1.Name = "Tp1"
        Me.Tp1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp1.Size = New System.Drawing.Size(592, 420)
        Me.Tp1.TabIndex = 2
        Me.Tp1.Text = "Session Programme Stream"
        Me.Tp1.UseVisualStyleBackColor = True
        '
        'Tp2
        '
        Me.Tp2.Controls.Add(Me.Pnl2)
        Me.Tp2.Location = New System.Drawing.Point(4, 22)
        Me.Tp2.Name = "Tp2"
        Me.Tp2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp2.Size = New System.Drawing.Size(592, 420)
        Me.Tp2.TabIndex = 0
        Me.Tp2.Text = "Session Programme Stream Year"
        Me.Tp2.UseVisualStyleBackColor = True
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(80, 6)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(412, 393)
        Me.Pnl2.TabIndex = 4
        '
        'Tp3
        '
        Me.Tp3.Controls.Add(Me.Pnl3)
        Me.Tp3.Location = New System.Drawing.Point(4, 22)
        Me.Tp3.Name = "Tp3"
        Me.Tp3.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp3.Size = New System.Drawing.Size(592, 420)
        Me.Tp3.TabIndex = 1
        Me.Tp3.Text = "Session Programme Stream Semester"
        Me.Tp3.UseVisualStyleBackColor = True
        '
        'Pnl3
        '
        Me.Pnl3.Location = New System.Drawing.Point(80, 5)
        Me.Pnl3.Name = "Pnl3"
        Me.Pnl3.Size = New System.Drawing.Size(414, 409)
        Me.Pnl3.TabIndex = 5
        '
        'TxtSemesters
        '
        Me.TxtSemesters.AgMandatory = True
        Me.TxtSemesters.AgMasterHelp = False
        Me.TxtSemesters.AgNumberLeftPlaces = 0
        Me.TxtSemesters.AgNumberNegetiveAllow = False
        Me.TxtSemesters.AgNumberRightPlaces = 0
        Me.TxtSemesters.AgPickFromLastValue = False
        Me.TxtSemesters.AgRowFilter = ""
        Me.TxtSemesters.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSemesters.AgSelectedValue = Nothing
        Me.TxtSemesters.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSemesters.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSemesters.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSemesters.Location = New System.Drawing.Point(0, 89)
        Me.TxtSemesters.MaxLength = 50
        Me.TxtSemesters.Name = "TxtSemesters"
        Me.TxtSemesters.Size = New System.Drawing.Size(123, 21)
        Me.TxtSemesters.TabIndex = 23
        Me.TxtSemesters.Text = "Semesters"
        Me.TxtSemesters.Visible = False
        '
        'TxtSemesterDuration
        '
        Me.TxtSemesterDuration.AgMandatory = True
        Me.TxtSemesterDuration.AgMasterHelp = False
        Me.TxtSemesterDuration.AgNumberLeftPlaces = 0
        Me.TxtSemesterDuration.AgNumberNegetiveAllow = False
        Me.TxtSemesterDuration.AgNumberRightPlaces = 0
        Me.TxtSemesterDuration.AgPickFromLastValue = False
        Me.TxtSemesterDuration.AgRowFilter = ""
        Me.TxtSemesterDuration.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSemesterDuration.AgSelectedValue = Nothing
        Me.TxtSemesterDuration.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSemesterDuration.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSemesterDuration.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSemesterDuration.Location = New System.Drawing.Point(0, 111)
        Me.TxtSemesterDuration.MaxLength = 50
        Me.TxtSemesterDuration.Name = "TxtSemesterDuration"
        Me.TxtSemesterDuration.Size = New System.Drawing.Size(123, 21)
        Me.TxtSemesterDuration.TabIndex = 24
        Me.TxtSemesterDuration.Text = "SemesterDuration"
        Me.TxtSemesterDuration.Visible = False
        '
        'FrmSessionProgramme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 585)
        Me.Controls.Add(Me.TxtSemesterDuration)
        Me.Controls.Add(Me.TxtSemesters)
        Me.Controls.Add(Me.Tc1)
        Me.Controls.Add(Me.TxtSessionStartDate)
        Me.Controls.Add(Me.TxtProgrammeDuration)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtProgramme)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtSession)
        Me.Controls.Add(Me.LblSession)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSessionProgramme"
        Me.Text = "Fee Group Master"
        Me.Tc1.ResumeLayout(False)
        Me.Tp1.ResumeLayout(False)
        Me.Tp2.ResumeLayout(False)
        Me.Tp3.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtSession As AgControls.AgTextBox
    Friend WithEvents LblSession As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtProgramme As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtProgrammeDuration As AgControls.AgTextBox
    Friend WithEvents TxtSessionStartDate As AgControls.AgTextBox
    Friend WithEvents Tc1 As System.Windows.Forms.TabControl
    Friend WithEvents Tp2 As System.Windows.Forms.TabPage
    Friend WithEvents Tp3 As System.Windows.Forms.TabPage
    Friend WithEvents Pnl2 As System.Windows.Forms.Panel
    Friend WithEvents Pnl3 As System.Windows.Forms.Panel
    Friend WithEvents TxtSemesters As AgControls.AgTextBox
    Friend WithEvents TxtSemesterDuration As AgControls.AgTextBox
    Friend WithEvents Tp1 As System.Windows.Forms.TabPage
End Class
