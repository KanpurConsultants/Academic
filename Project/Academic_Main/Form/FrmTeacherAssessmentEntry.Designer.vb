<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTeacherAssessmentEntry
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtAssesmentType = New AgControls.AgTextBox
        Me.LblAssesmentType = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.BtnFill = New System.Windows.Forms.Button
        Me.LblAssesmentTypeReq = New System.Windows.Forms.Label
        Me.TxtAssesmentDate = New AgControls.AgTextBox
        Me.LblAssesmentDate = New System.Windows.Forms.Label
        Me.LblAssesmentDateReq = New System.Windows.Forms.Label
        Me.LblTeacherReq = New System.Windows.Forms.Label
        Me.TxtTeacher = New AgControls.AgTextBox
        Me.LblTeacher = New System.Windows.Forms.Label
        Me.TxtSession = New AgControls.AgTextBox
        Me.LblSession = New System.Windows.Forms.Label
        Me.LblMaxPointsReq = New System.Windows.Forms.Label
        Me.TxtMaxPoints = New AgControls.AgTextBox
        Me.LblMaxPoints = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.Topctrl1.TabIndex = 9
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
        'TxtAssesmentType
        '
        Me.TxtAssesmentType.AgMandatory = True
        Me.TxtAssesmentType.AgMasterHelp = False
        Me.TxtAssesmentType.AgNumberLeftPlaces = 0
        Me.TxtAssesmentType.AgNumberNegetiveAllow = False
        Me.TxtAssesmentType.AgNumberRightPlaces = 0
        Me.TxtAssesmentType.AgPickFromLastValue = False
        Me.TxtAssesmentType.AgRowFilter = ""
        Me.TxtAssesmentType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAssesmentType.AgSelectedValue = Nothing
        Me.TxtAssesmentType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAssesmentType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAssesmentType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAssesmentType.Location = New System.Drawing.Point(300, 79)
        Me.TxtAssesmentType.MaxLength = 50
        Me.TxtAssesmentType.Name = "TxtAssesmentType"
        Me.TxtAssesmentType.Size = New System.Drawing.Size(208, 21)
        Me.TxtAssesmentType.TabIndex = 1
        '
        'LblAssesmentType
        '
        Me.LblAssesmentType.AutoSize = True
        Me.LblAssesmentType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAssesmentType.Location = New System.Drawing.Point(181, 84)
        Me.LblAssesmentType.Name = "LblAssesmentType"
        Me.LblAssesmentType.Size = New System.Drawing.Size(101, 13)
        Me.LblAssesmentType.TabIndex = 16
        Me.LblAssesmentType.Text = "Assesment Type"
        '
        'TxtStreamYearSemester
        '
        Me.TxtStreamYearSemester.AgMandatory = False
        Me.TxtStreamYearSemester.AgMasterHelp = False
        Me.TxtStreamYearSemester.AgNumberLeftPlaces = 0
        Me.TxtStreamYearSemester.AgNumberNegetiveAllow = False
        Me.TxtStreamYearSemester.AgNumberRightPlaces = 0
        Me.TxtStreamYearSemester.AgPickFromLastValue = False
        Me.TxtStreamYearSemester.AgRowFilter = ""
        Me.TxtStreamYearSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStreamYearSemester.AgSelectedValue = Nothing
        Me.TxtStreamYearSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStreamYearSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(300, 123)
        Me.TxtStreamYearSemester.MaxLength = 50
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(208, 21)
        Me.TxtStreamYearSemester.TabIndex = 5
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(181, 126)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(62, 13)
        Me.LblStreamYearSemester.TabIndex = 18
        Me.LblStreamYearSemester.Text = "Semester"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(217, 186)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(439, 346)
        Me.Pnl1.TabIndex = 8
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(10, 553)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 506
        Me.GrpUP.TabStop = False
        Me.GrpUP.Tag = "TR"
        Me.GrpUP.Text = "Prepared By "
        '
        'TxtPrepared
        '
        Me.TxtPrepared.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtPrepared.BackColor = System.Drawing.Color.White
        Me.TxtPrepared.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrepared.Enabled = False
        Me.TxtPrepared.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrepared.Location = New System.Drawing.Point(14, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.ReadOnly = True
        Me.TxtPrepared.Size = New System.Drawing.Size(158, 18)
        Me.TxtPrepared.TabIndex = 0
        Me.TxtPrepared.TabStop = False
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(674, 553)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 507
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
        '
        'TxtModified
        '
        Me.TxtModified.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtModified.BackColor = System.Drawing.Color.White
        Me.TxtModified.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtModified.Enabled = False
        Me.TxtModified.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModified.Location = New System.Drawing.Point(13, 21)
        Me.TxtModified.Name = "TxtModified"
        Me.TxtModified.ReadOnly = True
        Me.TxtModified.Size = New System.Drawing.Size(158, 18)
        Me.TxtModified.TabIndex = 0
        Me.TxtModified.TabStop = False
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(-2, 543)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 4)
        Me.GroupBox2.TabIndex = 505
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(287, 63)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 511
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(181, 63)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 512
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgMandatory = False
        Me.TxtSite_Code.AgMasterHelp = False
        Me.TxtSite_Code.AgNumberLeftPlaces = 0
        Me.TxtSite_Code.AgNumberNegetiveAllow = False
        Me.TxtSite_Code.AgNumberRightPlaces = 0
        Me.TxtSite_Code.AgPickFromLastValue = False
        Me.TxtSite_Code.AgRowFilter = ""
        Me.TxtSite_Code.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSite_Code.AgSelectedValue = Nothing
        Me.TxtSite_Code.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSite_Code.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(300, 57)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(391, 21)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(217, 163)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(439, 22)
        Me.BtnFill.TabIndex = 7
        Me.BtnFill.Text = "&Fill"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'LblAssesmentTypeReq
        '
        Me.LblAssesmentTypeReq.AutoSize = True
        Me.LblAssesmentTypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAssesmentTypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAssesmentTypeReq.Location = New System.Drawing.Point(287, 86)
        Me.LblAssesmentTypeReq.Name = "LblAssesmentTypeReq"
        Me.LblAssesmentTypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAssesmentTypeReq.TabIndex = 515
        Me.LblAssesmentTypeReq.Text = "Ä"
        '
        'TxtAssesmentDate
        '
        Me.TxtAssesmentDate.AgMandatory = True
        Me.TxtAssesmentDate.AgMasterHelp = False
        Me.TxtAssesmentDate.AgNumberLeftPlaces = 0
        Me.TxtAssesmentDate.AgNumberNegetiveAllow = False
        Me.TxtAssesmentDate.AgNumberRightPlaces = 0
        Me.TxtAssesmentDate.AgPickFromLastValue = False
        Me.TxtAssesmentDate.AgRowFilter = ""
        Me.TxtAssesmentDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAssesmentDate.AgSelectedValue = Nothing
        Me.TxtAssesmentDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAssesmentDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtAssesmentDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAssesmentDate.Location = New System.Drawing.Point(600, 79)
        Me.TxtAssesmentDate.MaxLength = 50
        Me.TxtAssesmentDate.Name = "TxtAssesmentDate"
        Me.TxtAssesmentDate.Size = New System.Drawing.Size(91, 21)
        Me.TxtAssesmentDate.TabIndex = 2
        '
        'LblAssesmentDate
        '
        Me.LblAssesmentDate.AutoSize = True
        Me.LblAssesmentDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAssesmentDate.Location = New System.Drawing.Point(514, 83)
        Me.LblAssesmentDate.Name = "LblAssesmentDate"
        Me.LblAssesmentDate.Size = New System.Drawing.Size(34, 13)
        Me.LblAssesmentDate.TabIndex = 519
        Me.LblAssesmentDate.Text = "Date"
        '
        'LblAssesmentDateReq
        '
        Me.LblAssesmentDateReq.AutoSize = True
        Me.LblAssesmentDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAssesmentDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAssesmentDateReq.Location = New System.Drawing.Point(587, 87)
        Me.LblAssesmentDateReq.Name = "LblAssesmentDateReq"
        Me.LblAssesmentDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAssesmentDateReq.TabIndex = 520
        Me.LblAssesmentDateReq.Text = "Ä"
        '
        'LblTeacherReq
        '
        Me.LblTeacherReq.AutoSize = True
        Me.LblTeacherReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTeacherReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTeacherReq.Location = New System.Drawing.Point(287, 109)
        Me.LblTeacherReq.Name = "LblTeacherReq"
        Me.LblTeacherReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTeacherReq.TabIndex = 523
        Me.LblTeacherReq.Text = "Ä"
        '
        'TxtTeacher
        '
        Me.TxtTeacher.AgMandatory = True
        Me.TxtTeacher.AgMasterHelp = False
        Me.TxtTeacher.AgNumberLeftPlaces = 0
        Me.TxtTeacher.AgNumberNegetiveAllow = False
        Me.TxtTeacher.AgNumberRightPlaces = 0
        Me.TxtTeacher.AgPickFromLastValue = False
        Me.TxtTeacher.AgRowFilter = ""
        Me.TxtTeacher.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTeacher.AgSelectedValue = Nothing
        Me.TxtTeacher.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTeacher.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTeacher.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTeacher.Location = New System.Drawing.Point(300, 101)
        Me.TxtTeacher.MaxLength = 50
        Me.TxtTeacher.Name = "TxtTeacher"
        Me.TxtTeacher.Size = New System.Drawing.Size(208, 21)
        Me.TxtTeacher.TabIndex = 3
        '
        'LblTeacher
        '
        Me.LblTeacher.AutoSize = True
        Me.LblTeacher.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTeacher.Location = New System.Drawing.Point(181, 104)
        Me.LblTeacher.Name = "LblTeacher"
        Me.LblTeacher.Size = New System.Drawing.Size(53, 13)
        Me.LblTeacher.TabIndex = 522
        Me.LblTeacher.Text = "Teacher"
        '
        'TxtSession
        '
        Me.TxtSession.AgMandatory = False
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
        Me.TxtSession.Location = New System.Drawing.Point(600, 123)
        Me.TxtSession.MaxLength = 50
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(91, 21)
        Me.TxtSession.TabIndex = 6
        '
        'LblSession
        '
        Me.LblSession.AutoSize = True
        Me.LblSession.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSession.Location = New System.Drawing.Point(514, 126)
        Me.LblSession.Name = "LblSession"
        Me.LblSession.Size = New System.Drawing.Size(51, 13)
        Me.LblSession.TabIndex = 525
        Me.LblSession.Text = "Session"
        '
        'LblMaxPointsReq
        '
        Me.LblMaxPointsReq.AutoSize = True
        Me.LblMaxPointsReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblMaxPointsReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMaxPointsReq.Location = New System.Drawing.Point(587, 109)
        Me.LblMaxPointsReq.Name = "LblMaxPointsReq"
        Me.LblMaxPointsReq.Size = New System.Drawing.Size(10, 7)
        Me.LblMaxPointsReq.TabIndex = 529
        Me.LblMaxPointsReq.Text = "Ä"
        '
        'TxtMaxPoints
        '
        Me.TxtMaxPoints.AgMandatory = True
        Me.TxtMaxPoints.AgMasterHelp = False
        Me.TxtMaxPoints.AgNumberLeftPlaces = 0
        Me.TxtMaxPoints.AgNumberNegetiveAllow = False
        Me.TxtMaxPoints.AgNumberRightPlaces = 0
        Me.TxtMaxPoints.AgPickFromLastValue = False
        Me.TxtMaxPoints.AgRowFilter = ""
        Me.TxtMaxPoints.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMaxPoints.AgSelectedValue = Nothing
        Me.TxtMaxPoints.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMaxPoints.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMaxPoints.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaxPoints.Location = New System.Drawing.Point(600, 101)
        Me.TxtMaxPoints.MaxLength = 50
        Me.TxtMaxPoints.Name = "TxtMaxPoints"
        Me.TxtMaxPoints.Size = New System.Drawing.Size(91, 21)
        Me.TxtMaxPoints.TabIndex = 4
        '
        'LblMaxPoints
        '
        Me.LblMaxPoints.AutoSize = True
        Me.LblMaxPoints.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMaxPoints.Location = New System.Drawing.Point(514, 104)
        Me.LblMaxPoints.Name = "LblMaxPoints"
        Me.LblMaxPoints.Size = New System.Drawing.Size(68, 13)
        Me.LblMaxPoints.TabIndex = 528
        Me.LblMaxPoints.Text = "Max Points"
        '
        'FrmTeacherAssesmentEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 616)
        Me.Controls.Add(Me.LblMaxPointsReq)
        Me.Controls.Add(Me.TxtMaxPoints)
        Me.Controls.Add(Me.LblMaxPoints)
        Me.Controls.Add(Me.TxtSession)
        Me.Controls.Add(Me.LblSession)
        Me.Controls.Add(Me.LblTeacherReq)
        Me.Controls.Add(Me.TxtTeacher)
        Me.Controls.Add(Me.LblTeacher)
        Me.Controls.Add(Me.LblAssesmentDateReq)
        Me.Controls.Add(Me.TxtAssesmentDate)
        Me.Controls.Add(Me.LblAssesmentDate)
        Me.Controls.Add(Me.LblAssesmentTypeReq)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtStreamYearSemester)
        Me.Controls.Add(Me.LblStreamYearSemester)
        Me.Controls.Add(Me.TxtAssesmentType)
        Me.Controls.Add(Me.LblAssesmentType)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmTeacherAssesmentEntry"
        Me.Text = "Section Assign Entry"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtAssesmentType As AgControls.AgTextBox
    Friend WithEvents LblAssesmentType As System.Windows.Forms.Label
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox

    Private Sub FrmClassSectionSemesterAdmission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Friend WithEvents LblAssesmentTypeReq As System.Windows.Forms.Label
    Friend WithEvents TxtAssesmentDate As AgControls.AgTextBox
    Friend WithEvents LblAssesmentDate As System.Windows.Forms.Label
    Friend WithEvents LblAssesmentDateReq As System.Windows.Forms.Label
    Friend WithEvents LblTeacherReq As System.Windows.Forms.Label
    Friend WithEvents TxtTeacher As AgControls.AgTextBox
    Friend WithEvents LblTeacher As System.Windows.Forms.Label
    Friend WithEvents TxtSession As AgControls.AgTextBox
    Friend WithEvents LblSession As System.Windows.Forms.Label
    Friend WithEvents LblMaxPointsReq As System.Windows.Forms.Label
    Friend WithEvents TxtMaxPoints As AgControls.AgTextBox
    Friend WithEvents LblMaxPoints As System.Windows.Forms.Label
End Class
