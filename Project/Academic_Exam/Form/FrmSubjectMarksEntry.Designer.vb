<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubjectMarksEntry
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
        Me.LblExamNatureReq = New System.Windows.Forms.Label
        Me.TxtExamNature = New AgControls.AgTextBox
        Me.LblExamNature = New System.Windows.Forms.Label
        Me.LblTotalStudent = New System.Windows.Forms.Label
        Me.TxtTotalStudent = New AgControls.AgTextBox
        Me.LblSemesterExamReq = New System.Windows.Forms.Label
        Me.TxtSemesterExam = New AgControls.AgTextBox
        Me.LblSemesterExam = New System.Windows.Forms.Label
        Me.LblSessionProgrammeReq = New System.Windows.Forms.Label
        Me.TxtSessionProgramme = New AgControls.AgTextBox
        Me.LblSessionProgramme = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtRemark = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtDocId = New AgControls.AgTextBox
        Me.LblV_No = New System.Windows.Forms.Label
        Me.TxtV_No = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.LblV_TypeReq = New System.Windows.Forms.Label
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.LblV_Type = New System.Windows.Forms.Label
        Me.TxtV_Type = New AgControls.AgTextBox
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblDocId = New System.Windows.Forms.Label
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.LblSubjectReq = New System.Windows.Forms.Label
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubject = New System.Windows.Forms.Label
        Me.LblTotalPassStudent = New System.Windows.Forms.Label
        Me.TxtTotalPassStudent = New AgControls.AgTextBox
        Me.LblTotalFailStudent = New System.Windows.Forms.Label
        Me.TxtTotalFailStudent = New AgControls.AgTextBox
        Me.LblTotalPassWithGraceStudent = New System.Windows.Forms.Label
        Me.TxtTotalPassWithGraceStudent = New AgControls.AgTextBox
        Me.LblMaxMarks = New System.Windows.Forms.Label
        Me.TxtMaxMarks = New AgControls.AgTextBox
        Me.LblMinMarks = New System.Windows.Forms.Label
        Me.TxtMinMarks = New AgControls.AgTextBox
        Me.LblIsAttendanceMarksReq = New System.Windows.Forms.Label
        Me.TxtIsAttendanceMarks = New AgControls.AgTextBox
        Me.LblIsAttendanceMarks = New System.Windows.Forms.Label
        Me.TxtClassSection = New AgControls.AgTextBox
        Me.LblClassSection = New System.Windows.Forms.Label
        Me.TxtClassSectionSubSection = New AgControls.AgTextBox
        Me.LblClassSectionSubSection = New System.Windows.Forms.Label
        Me.TxtSession = New AgControls.AgTextBox
        Me.LblSession = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblExamNatureReq
        '
        Me.LblExamNatureReq.AutoSize = True
        Me.LblExamNatureReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblExamNatureReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblExamNatureReq.Location = New System.Drawing.Point(139, 148)
        Me.LblExamNatureReq.Name = "LblExamNatureReq"
        Me.LblExamNatureReq.Size = New System.Drawing.Size(10, 7)
        Me.LblExamNatureReq.TabIndex = 699
        Me.LblExamNatureReq.Text = "Ä"
        '
        'TxtExamNature
        '
        Me.TxtExamNature.AgAllowUserToEnableMasterHelp = False
        Me.TxtExamNature.AgMandatory = True
        Me.TxtExamNature.AgMasterHelp = False
        Me.TxtExamNature.AgNumberLeftPlaces = 0
        Me.TxtExamNature.AgNumberNegetiveAllow = False
        Me.TxtExamNature.AgNumberRightPlaces = 0
        Me.TxtExamNature.AgPickFromLastValue = False
        Me.TxtExamNature.AgRowFilter = ""
        Me.TxtExamNature.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtExamNature.AgSelectedValue = Nothing
        Me.TxtExamNature.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtExamNature.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtExamNature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExamNature.Location = New System.Drawing.Point(152, 141)
        Me.TxtExamNature.MaxLength = 50
        Me.TxtExamNature.Name = "TxtExamNature"
        Me.TxtExamNature.Size = New System.Drawing.Size(100, 21)
        Me.TxtExamNature.TabIndex = 5
        '
        'LblExamNature
        '
        Me.LblExamNature.AutoSize = True
        Me.LblExamNature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblExamNature.Location = New System.Drawing.Point(20, 145)
        Me.LblExamNature.Name = "LblExamNature"
        Me.LblExamNature.Size = New System.Drawing.Size(81, 13)
        Me.LblExamNature.TabIndex = 698
        Me.LblExamNature.Text = "Exam Nature"
        '
        'LblTotalStudent
        '
        Me.LblTotalStudent.AutoSize = True
        Me.LblTotalStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalStudent.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalStudent.Location = New System.Drawing.Point(740, 526)
        Me.LblTotalStudent.Name = "LblTotalStudent"
        Me.LblTotalStudent.Size = New System.Drawing.Size(83, 13)
        Me.LblTotalStudent.TabIndex = 697
        Me.LblTotalStudent.Text = "Total Student"
        '
        'TxtTotalStudent
        '
        Me.TxtTotalStudent.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalStudent.AgMandatory = False
        Me.TxtTotalStudent.AgMasterHelp = False
        Me.TxtTotalStudent.AgNumberLeftPlaces = 8
        Me.TxtTotalStudent.AgNumberNegetiveAllow = False
        Me.TxtTotalStudent.AgNumberRightPlaces = 0
        Me.TxtTotalStudent.AgPickFromLastValue = False
        Me.TxtTotalStudent.AgRowFilter = ""
        Me.TxtTotalStudent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalStudent.AgSelectedValue = Nothing
        Me.TxtTotalStudent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalStudent.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalStudent.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalStudent.Location = New System.Drawing.Point(829, 522)
        Me.TxtTotalStudent.Name = "TxtTotalStudent"
        Me.TxtTotalStudent.ReadOnly = True
        Me.TxtTotalStudent.Size = New System.Drawing.Size(100, 21)
        Me.TxtTotalStudent.TabIndex = 696
        Me.TxtTotalStudent.TabStop = False
        Me.TxtTotalStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblSemesterExamReq
        '
        Me.LblSemesterExamReq.AutoSize = True
        Me.LblSemesterExamReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSemesterExamReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSemesterExamReq.Location = New System.Drawing.Point(605, 126)
        Me.LblSemesterExamReq.Name = "LblSemesterExamReq"
        Me.LblSemesterExamReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSemesterExamReq.TabIndex = 695
        Me.LblSemesterExamReq.Text = "Ä"
        '
        'TxtSemesterExam
        '
        Me.TxtSemesterExam.AgAllowUserToEnableMasterHelp = False
        Me.TxtSemesterExam.AgMandatory = True
        Me.TxtSemesterExam.AgMasterHelp = False
        Me.TxtSemesterExam.AgNumberLeftPlaces = 0
        Me.TxtSemesterExam.AgNumberNegetiveAllow = False
        Me.TxtSemesterExam.AgNumberRightPlaces = 0
        Me.TxtSemesterExam.AgPickFromLastValue = False
        Me.TxtSemesterExam.AgRowFilter = ""
        Me.TxtSemesterExam.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSemesterExam.AgSelectedValue = Nothing
        Me.TxtSemesterExam.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSemesterExam.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSemesterExam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSemesterExam.Location = New System.Drawing.Point(621, 119)
        Me.TxtSemesterExam.MaxLength = 50
        Me.TxtSemesterExam.Name = "TxtSemesterExam"
        Me.TxtSemesterExam.Size = New System.Drawing.Size(293, 21)
        Me.TxtSemesterExam.TabIndex = 12
        '
        'LblSemesterExam
        '
        Me.LblSemesterExam.AutoSize = True
        Me.LblSemesterExam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSemesterExam.Location = New System.Drawing.Point(501, 123)
        Me.LblSemesterExam.Name = "LblSemesterExam"
        Me.LblSemesterExam.Size = New System.Drawing.Size(99, 13)
        Me.LblSemesterExam.TabIndex = 694
        Me.LblSemesterExam.Text = "Semester/Exam"
        '
        'LblSessionProgrammeReq
        '
        Me.LblSessionProgrammeReq.AutoSize = True
        Me.LblSessionProgrammeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSessionProgrammeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSessionProgrammeReq.Location = New System.Drawing.Point(139, 170)
        Me.LblSessionProgrammeReq.Name = "LblSessionProgrammeReq"
        Me.LblSessionProgrammeReq.Size = New System.Drawing.Size(0, 7)
        Me.LblSessionProgrammeReq.TabIndex = 693
        '
        'TxtSessionProgramme
        '
        Me.TxtSessionProgramme.AgAllowUserToEnableMasterHelp = False
        Me.TxtSessionProgramme.AgMandatory = False
        Me.TxtSessionProgramme.AgMasterHelp = False
        Me.TxtSessionProgramme.AgNumberLeftPlaces = 0
        Me.TxtSessionProgramme.AgNumberNegetiveAllow = False
        Me.TxtSessionProgramme.AgNumberRightPlaces = 0
        Me.TxtSessionProgramme.AgPickFromLastValue = False
        Me.TxtSessionProgramme.AgRowFilter = ""
        Me.TxtSessionProgramme.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSessionProgramme.AgSelectedValue = Nothing
        Me.TxtSessionProgramme.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSessionProgramme.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSessionProgramme.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSessionProgramme.Location = New System.Drawing.Point(621, 53)
        Me.TxtSessionProgramme.MaxLength = 50
        Me.TxtSessionProgramme.Name = "TxtSessionProgramme"
        Me.TxtSessionProgramme.Size = New System.Drawing.Size(293, 21)
        Me.TxtSessionProgramme.TabIndex = 8
        '
        'LblSessionProgramme
        '
        Me.LblSessionProgramme.AutoSize = True
        Me.LblSessionProgramme.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgramme.Location = New System.Drawing.Point(501, 57)
        Me.LblSessionProgramme.Name = "LblSessionProgramme"
        Me.LblSessionProgramme.Size = New System.Drawing.Size(123, 13)
        Me.LblSessionProgramme.TabIndex = 692
        Me.LblSessionProgramme.Text = "Session/Programme"
        '
        'TxtStreamYearSemester
        '
        Me.TxtStreamYearSemester.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(621, 75)
        Me.TxtStreamYearSemester.MaxLength = 50
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(293, 21)
        Me.TxtStreamYearSemester.TabIndex = 9
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(501, 79)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(62, 13)
        Me.LblStreamYearSemester.TabIndex = 690
        Me.LblStreamYearSemester.Text = "Semester"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(621, 215)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(293, 23)
        Me.BtnFill.TabIndex = 17
        Me.BtnFill.Text = "&Fill Student"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(17, 240)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(897, 271)
        Me.Pnl1.TabIndex = 18
        '
        'TxtRemark
        '
        Me.TxtRemark.AgAllowUserToEnableMasterHelp = False
        Me.TxtRemark.AgMandatory = False
        Me.TxtRemark.AgMasterHelp = False
        Me.TxtRemark.AgNumberLeftPlaces = 0
        Me.TxtRemark.AgNumberNegetiveAllow = False
        Me.TxtRemark.AgNumberRightPlaces = 0
        Me.TxtRemark.AgPickFromLastValue = False
        Me.TxtRemark.AgRowFilter = ""
        Me.TxtRemark.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemark.AgSelectedValue = Nothing
        Me.TxtRemark.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemark.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemark.Location = New System.Drawing.Point(621, 185)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(293, 21)
        Me.TxtRemark.TabIndex = 16
        Me.TxtRemark.Text = "AgTextBox4"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(501, 189)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 15
        Me.Label12.Text = "&Remark"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(-4, 544)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(942, 4)
        Me.GroupBox2.TabIndex = 687
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
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
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(8, 554)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 688
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
        Me.GroupBox4.Location = New System.Drawing.Point(743, 554)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 689
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
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
        Me.Topctrl1.Size = New System.Drawing.Size(934, 41)
        Me.Topctrl1.TabIndex = 19
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
        'TxtDocId
        '
        Me.TxtDocId.AgAllowUserToEnableMasterHelp = False
        Me.TxtDocId.AgMandatory = False
        Me.TxtDocId.AgMasterHelp = False
        Me.TxtDocId.AgNumberLeftPlaces = 0
        Me.TxtDocId.AgNumberNegetiveAllow = False
        Me.TxtDocId.AgNumberRightPlaces = 0
        Me.TxtDocId.AgPickFromLastValue = False
        Me.TxtDocId.AgRowFilter = ""
        Me.TxtDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDocId.AgSelectedValue = Nothing
        Me.TxtDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDocId.Location = New System.Drawing.Point(152, 53)
        Me.TxtDocId.MaxLength = 21
        Me.TxtDocId.Name = "TxtDocId"
        Me.TxtDocId.ReadOnly = True
        Me.TxtDocId.Size = New System.Drawing.Size(334, 21)
        Me.TxtDocId.TabIndex = 0
        Me.TxtDocId.TabStop = False
        Me.TxtDocId.Text = "TxtDocId"
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(256, 123)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(98, 13)
        Me.LblV_No.TabIndex = 683
        Me.LblV_No.Text = "Marks Entry No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgAllowUserToEnableMasterHelp = False
        Me.TxtV_No.AgMandatory = True
        Me.TxtV_No.AgMasterHelp = False
        Me.TxtV_No.AgNumberLeftPlaces = 8
        Me.TxtV_No.AgNumberNegetiveAllow = False
        Me.TxtV_No.AgNumberRightPlaces = 0
        Me.TxtV_No.AgPickFromLastValue = False
        Me.TxtV_No.AgRowFilter = ""
        Me.TxtV_No.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_No.AgSelectedValue = Nothing
        Me.TxtV_No.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_No.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtV_No.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_No.Location = New System.Drawing.Point(386, 119)
        Me.TxtV_No.Name = "TxtV_No"
        Me.TxtV_No.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_No.TabIndex = 4
        Me.TxtV_No.Text = "TxtV_No"
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(139, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 686
        Me.Label5.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(139, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 685
        Me.Label2.Text = "Ä"
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(20, 123)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(106, 13)
        Me.LblV_Date.TabIndex = 681
        Me.LblV_Date.Text = "Marks Entry Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.AutoSize = True
        Me.LblV_TypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblV_TypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblV_TypeReq.Location = New System.Drawing.Point(139, 104)
        Me.LblV_TypeReq.Name = "LblV_TypeReq"
        Me.LblV_TypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblV_TypeReq.TabIndex = 684
        Me.LblV_TypeReq.Text = "Ä"
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgAllowUserToEnableMasterHelp = False
        Me.TxtV_Date.AgMandatory = True
        Me.TxtV_Date.AgMasterHelp = False
        Me.TxtV_Date.AgNumberLeftPlaces = 0
        Me.TxtV_Date.AgNumberNegetiveAllow = False
        Me.TxtV_Date.AgNumberRightPlaces = 0
        Me.TxtV_Date.AgPickFromLastValue = False
        Me.TxtV_Date.AgRowFilter = ""
        Me.TxtV_Date.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_Date.AgSelectedValue = Nothing
        Me.TxtV_Date.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_Date.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_Date.Location = New System.Drawing.Point(152, 119)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_Date.TabIndex = 3
        Me.TxtV_Date.Text = "TxtV_Date"
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(20, 101)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(107, 13)
        Me.LblV_Type.TabIndex = 680
        Me.LblV_Type.Text = "Marks Entry Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgAllowUserToEnableMasterHelp = False
        Me.TxtV_Type.AgMandatory = True
        Me.TxtV_Type.AgMasterHelp = False
        Me.TxtV_Type.AgNumberLeftPlaces = 0
        Me.TxtV_Type.AgNumberNegetiveAllow = False
        Me.TxtV_Type.AgNumberRightPlaces = 0
        Me.TxtV_Type.AgPickFromLastValue = False
        Me.TxtV_Type.AgRowFilter = ""
        Me.TxtV_Type.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_Type.AgSelectedValue = Nothing
        Me.TxtV_Type.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_Type.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtV_Type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_Type.Location = New System.Drawing.Point(152, 97)
        Me.TxtV_Type.MaxLength = 5
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(334, 21)
        Me.TxtV_Type.TabIndex = 2
        Me.TxtV_Type.Text = "TxtV_Type"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(139, 82)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 679
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(20, 79)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 682
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(152, 75)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(334, 21)
        Me.TxtSite_Code.TabIndex = 1
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblDocId
        '
        Me.LblDocId.AutoSize = True
        Me.LblDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocId.Location = New System.Drawing.Point(20, 57)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(41, 13)
        Me.LblDocId.TabIndex = 677
        Me.LblDocId.Text = "DocId"
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(352, 123)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(56, 13)
        Me.LblPrefix.TabIndex = 678
        Me.LblPrefix.Text = "LblPrefix"
        '
        'LblSubjectReq
        '
        Me.LblSubjectReq.AutoSize = True
        Me.LblSubjectReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubjectReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubjectReq.Location = New System.Drawing.Point(605, 148)
        Me.LblSubjectReq.Name = "LblSubjectReq"
        Me.LblSubjectReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubjectReq.TabIndex = 702
        Me.LblSubjectReq.Text = "Ä"
        '
        'TxtSubject
        '
        Me.TxtSubject.AgAllowUserToEnableMasterHelp = False
        Me.TxtSubject.AgMandatory = True
        Me.TxtSubject.AgMasterHelp = False
        Me.TxtSubject.AgNumberLeftPlaces = 0
        Me.TxtSubject.AgNumberNegetiveAllow = False
        Me.TxtSubject.AgNumberRightPlaces = 0
        Me.TxtSubject.AgPickFromLastValue = False
        Me.TxtSubject.AgRowFilter = ""
        Me.TxtSubject.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubject.AgSelectedValue = Nothing
        Me.TxtSubject.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubject.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubject.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubject.Location = New System.Drawing.Point(621, 141)
        Me.TxtSubject.MaxLength = 50
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(293, 21)
        Me.TxtSubject.TabIndex = 13
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(501, 145)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(50, 13)
        Me.LblSubject.TabIndex = 701
        Me.LblSubject.Text = "Subject"
        '
        'LblTotalPassStudent
        '
        Me.LblTotalPassStudent.AutoSize = True
        Me.LblTotalPassStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalPassStudent.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalPassStudent.Location = New System.Drawing.Point(26, 526)
        Me.LblTotalPassStudent.Name = "LblTotalPassStudent"
        Me.LblTotalPassStudent.Size = New System.Drawing.Size(65, 13)
        Me.LblTotalPassStudent.TabIndex = 704
        Me.LblTotalPassStudent.Text = "Total Pass"
        '
        'TxtTotalPassStudent
        '
        Me.TxtTotalPassStudent.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalPassStudent.AgMandatory = False
        Me.TxtTotalPassStudent.AgMasterHelp = False
        Me.TxtTotalPassStudent.AgNumberLeftPlaces = 8
        Me.TxtTotalPassStudent.AgNumberNegetiveAllow = False
        Me.TxtTotalPassStudent.AgNumberRightPlaces = 0
        Me.TxtTotalPassStudent.AgPickFromLastValue = False
        Me.TxtTotalPassStudent.AgRowFilter = ""
        Me.TxtTotalPassStudent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalPassStudent.AgSelectedValue = Nothing
        Me.TxtTotalPassStudent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalPassStudent.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalPassStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalPassStudent.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalPassStudent.Location = New System.Drawing.Point(97, 522)
        Me.TxtTotalPassStudent.Name = "TxtTotalPassStudent"
        Me.TxtTotalPassStudent.ReadOnly = True
        Me.TxtTotalPassStudent.Size = New System.Drawing.Size(100, 21)
        Me.TxtTotalPassStudent.TabIndex = 703
        Me.TxtTotalPassStudent.TabStop = False
        Me.TxtTotalPassStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalFailStudent
        '
        Me.LblTotalFailStudent.AutoSize = True
        Me.LblTotalFailStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalFailStudent.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalFailStudent.Location = New System.Drawing.Point(539, 526)
        Me.LblTotalFailStudent.Name = "LblTotalFailStudent"
        Me.LblTotalFailStudent.Size = New System.Drawing.Size(58, 13)
        Me.LblTotalFailStudent.TabIndex = 706
        Me.LblTotalFailStudent.Text = "Total Fail"
        '
        'TxtTotalFailStudent
        '
        Me.TxtTotalFailStudent.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalFailStudent.AgMandatory = False
        Me.TxtTotalFailStudent.AgMasterHelp = False
        Me.TxtTotalFailStudent.AgNumberLeftPlaces = 8
        Me.TxtTotalFailStudent.AgNumberNegetiveAllow = False
        Me.TxtTotalFailStudent.AgNumberRightPlaces = 0
        Me.TxtTotalFailStudent.AgPickFromLastValue = False
        Me.TxtTotalFailStudent.AgRowFilter = ""
        Me.TxtTotalFailStudent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalFailStudent.AgSelectedValue = Nothing
        Me.TxtTotalFailStudent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalFailStudent.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalFailStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalFailStudent.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalFailStudent.Location = New System.Drawing.Point(619, 522)
        Me.TxtTotalFailStudent.Name = "TxtTotalFailStudent"
        Me.TxtTotalFailStudent.ReadOnly = True
        Me.TxtTotalFailStudent.Size = New System.Drawing.Size(100, 21)
        Me.TxtTotalFailStudent.TabIndex = 705
        Me.TxtTotalFailStudent.TabStop = False
        Me.TxtTotalFailStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalPassWithGraceStudent
        '
        Me.LblTotalPassWithGraceStudent.AutoSize = True
        Me.LblTotalPassWithGraceStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalPassWithGraceStudent.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalPassWithGraceStudent.Location = New System.Drawing.Point(248, 527)
        Me.LblTotalPassWithGraceStudent.Name = "LblTotalPassWithGraceStudent"
        Me.LblTotalPassWithGraceStudent.Size = New System.Drawing.Size(132, 13)
        Me.LblTotalPassWithGraceStudent.TabIndex = 708
        Me.LblTotalPassWithGraceStudent.Text = "Total Pass With Grace"
        '
        'TxtTotalPassWithGraceStudent
        '
        Me.TxtTotalPassWithGraceStudent.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalPassWithGraceStudent.AgMandatory = False
        Me.TxtTotalPassWithGraceStudent.AgMasterHelp = False
        Me.TxtTotalPassWithGraceStudent.AgNumberLeftPlaces = 8
        Me.TxtTotalPassWithGraceStudent.AgNumberNegetiveAllow = False
        Me.TxtTotalPassWithGraceStudent.AgNumberRightPlaces = 0
        Me.TxtTotalPassWithGraceStudent.AgPickFromLastValue = False
        Me.TxtTotalPassWithGraceStudent.AgRowFilter = ""
        Me.TxtTotalPassWithGraceStudent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalPassWithGraceStudent.AgSelectedValue = Nothing
        Me.TxtTotalPassWithGraceStudent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalPassWithGraceStudent.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalPassWithGraceStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalPassWithGraceStudent.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalPassWithGraceStudent.Location = New System.Drawing.Point(386, 523)
        Me.TxtTotalPassWithGraceStudent.Name = "TxtTotalPassWithGraceStudent"
        Me.TxtTotalPassWithGraceStudent.ReadOnly = True
        Me.TxtTotalPassWithGraceStudent.Size = New System.Drawing.Size(100, 21)
        Me.TxtTotalPassWithGraceStudent.TabIndex = 707
        Me.TxtTotalPassWithGraceStudent.TabStop = False
        Me.TxtTotalPassWithGraceStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblMaxMarks
        '
        Me.LblMaxMarks.AutoSize = True
        Me.LblMaxMarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMaxMarks.Location = New System.Drawing.Point(501, 167)
        Me.LblMaxMarks.Name = "LblMaxMarks"
        Me.LblMaxMarks.Size = New System.Drawing.Size(68, 13)
        Me.LblMaxMarks.TabIndex = 710
        Me.LblMaxMarks.Text = "Max Marks"
        '
        'TxtMaxMarks
        '
        Me.TxtMaxMarks.AgAllowUserToEnableMasterHelp = False
        Me.TxtMaxMarks.AgMandatory = True
        Me.TxtMaxMarks.AgMasterHelp = False
        Me.TxtMaxMarks.AgNumberLeftPlaces = 8
        Me.TxtMaxMarks.AgNumberNegetiveAllow = False
        Me.TxtMaxMarks.AgNumberRightPlaces = 0
        Me.TxtMaxMarks.AgPickFromLastValue = False
        Me.TxtMaxMarks.AgRowFilter = ""
        Me.TxtMaxMarks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMaxMarks.AgSelectedValue = Nothing
        Me.TxtMaxMarks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMaxMarks.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMaxMarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMaxMarks.Location = New System.Drawing.Point(621, 163)
        Me.TxtMaxMarks.Name = "TxtMaxMarks"
        Me.TxtMaxMarks.ReadOnly = True
        Me.TxtMaxMarks.Size = New System.Drawing.Size(118, 21)
        Me.TxtMaxMarks.TabIndex = 14
        Me.TxtMaxMarks.TabStop = False
        Me.TxtMaxMarks.Text = "AgTextBox1"
        Me.TxtMaxMarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblMinMarks
        '
        Me.LblMinMarks.AutoSize = True
        Me.LblMinMarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMinMarks.Location = New System.Drawing.Point(741, 167)
        Me.LblMinMarks.Name = "LblMinMarks"
        Me.LblMinMarks.Size = New System.Drawing.Size(64, 13)
        Me.LblMinMarks.TabIndex = 712
        Me.LblMinMarks.Text = "Min Marks"
        '
        'TxtMinMarks
        '
        Me.TxtMinMarks.AgAllowUserToEnableMasterHelp = False
        Me.TxtMinMarks.AgMandatory = True
        Me.TxtMinMarks.AgMasterHelp = False
        Me.TxtMinMarks.AgNumberLeftPlaces = 8
        Me.TxtMinMarks.AgNumberNegetiveAllow = False
        Me.TxtMinMarks.AgNumberRightPlaces = 0
        Me.TxtMinMarks.AgPickFromLastValue = False
        Me.TxtMinMarks.AgRowFilter = ""
        Me.TxtMinMarks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMinMarks.AgSelectedValue = Nothing
        Me.TxtMinMarks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMinMarks.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMinMarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMinMarks.Location = New System.Drawing.Point(814, 163)
        Me.TxtMinMarks.Name = "TxtMinMarks"
        Me.TxtMinMarks.ReadOnly = True
        Me.TxtMinMarks.Size = New System.Drawing.Size(100, 21)
        Me.TxtMinMarks.TabIndex = 15
        Me.TxtMinMarks.TabStop = False
        Me.TxtMinMarks.Text = "AgTextBox2"
        Me.TxtMinMarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblIsAttendanceMarksReq
        '
        Me.LblIsAttendanceMarksReq.AutoSize = True
        Me.LblIsAttendanceMarksReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblIsAttendanceMarksReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblIsAttendanceMarksReq.Location = New System.Drawing.Point(420, 148)
        Me.LblIsAttendanceMarksReq.Name = "LblIsAttendanceMarksReq"
        Me.LblIsAttendanceMarksReq.Size = New System.Drawing.Size(10, 7)
        Me.LblIsAttendanceMarksReq.TabIndex = 715
        Me.LblIsAttendanceMarksReq.Text = "Ä"
        '
        'TxtIsAttendanceMarks
        '
        Me.TxtIsAttendanceMarks.AgAllowUserToEnableMasterHelp = False
        Me.TxtIsAttendanceMarks.AgMandatory = True
        Me.TxtIsAttendanceMarks.AgMasterHelp = False
        Me.TxtIsAttendanceMarks.AgNumberLeftPlaces = 0
        Me.TxtIsAttendanceMarks.AgNumberNegetiveAllow = False
        Me.TxtIsAttendanceMarks.AgNumberRightPlaces = 0
        Me.TxtIsAttendanceMarks.AgPickFromLastValue = False
        Me.TxtIsAttendanceMarks.AgRowFilter = ""
        Me.TxtIsAttendanceMarks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsAttendanceMarks.AgSelectedValue = Nothing
        Me.TxtIsAttendanceMarks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsAttendanceMarks.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsAttendanceMarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsAttendanceMarks.Location = New System.Drawing.Point(437, 141)
        Me.TxtIsAttendanceMarks.MaxLength = 50
        Me.TxtIsAttendanceMarks.Name = "TxtIsAttendanceMarks"
        Me.TxtIsAttendanceMarks.Size = New System.Drawing.Size(49, 21)
        Me.TxtIsAttendanceMarks.TabIndex = 6
        '
        'LblIsAttendanceMarks
        '
        Me.LblIsAttendanceMarks.AutoSize = True
        Me.LblIsAttendanceMarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsAttendanceMarks.Location = New System.Drawing.Point(256, 145)
        Me.LblIsAttendanceMarks.Name = "LblIsAttendanceMarks"
        Me.LblIsAttendanceMarks.Size = New System.Drawing.Size(130, 13)
        Me.LblIsAttendanceMarks.TabIndex = 714
        Me.LblIsAttendanceMarks.Text = "Is Attendance Marks?"
        '
        'TxtClassSection
        '
        Me.TxtClassSection.AgAllowUserToEnableMasterHelp = False
        Me.TxtClassSection.AgMandatory = False
        Me.TxtClassSection.AgMasterHelp = False
        Me.TxtClassSection.AgNumberLeftPlaces = 0
        Me.TxtClassSection.AgNumberNegetiveAllow = False
        Me.TxtClassSection.AgNumberRightPlaces = 0
        Me.TxtClassSection.AgPickFromLastValue = False
        Me.TxtClassSection.AgRowFilter = ""
        Me.TxtClassSection.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClassSection.AgSelectedValue = Nothing
        Me.TxtClassSection.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClassSection.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClassSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassSection.Location = New System.Drawing.Point(621, 97)
        Me.TxtClassSection.MaxLength = 50
        Me.TxtClassSection.Name = "TxtClassSection"
        Me.TxtClassSection.Size = New System.Drawing.Size(118, 21)
        Me.TxtClassSection.TabIndex = 10
        '
        'LblClassSection
        '
        Me.LblClassSection.AutoSize = True
        Me.LblClassSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSection.Location = New System.Drawing.Point(501, 101)
        Me.LblClassSection.Name = "LblClassSection"
        Me.LblClassSection.Size = New System.Drawing.Size(85, 13)
        Me.LblClassSection.TabIndex = 717
        Me.LblClassSection.Text = "Class/Section"
        '
        'TxtClassSectionSubSection
        '
        Me.TxtClassSectionSubSection.AgAllowUserToEnableMasterHelp = False
        Me.TxtClassSectionSubSection.AgMandatory = False
        Me.TxtClassSectionSubSection.AgMasterHelp = False
        Me.TxtClassSectionSubSection.AgNumberLeftPlaces = 0
        Me.TxtClassSectionSubSection.AgNumberNegetiveAllow = False
        Me.TxtClassSectionSubSection.AgNumberRightPlaces = 0
        Me.TxtClassSectionSubSection.AgPickFromLastValue = False
        Me.TxtClassSectionSubSection.AgRowFilter = ""
        Me.TxtClassSectionSubSection.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClassSectionSubSection.AgSelectedValue = Nothing
        Me.TxtClassSectionSubSection.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClassSectionSubSection.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClassSectionSubSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassSectionSubSection.Location = New System.Drawing.Point(814, 97)
        Me.TxtClassSectionSubSection.MaxLength = 50
        Me.TxtClassSectionSubSection.Name = "TxtClassSectionSubSection"
        Me.TxtClassSectionSubSection.Size = New System.Drawing.Size(100, 21)
        Me.TxtClassSectionSubSection.TabIndex = 11
        '
        'LblClassSectionSubSection
        '
        Me.LblClassSectionSubSection.AutoSize = True
        Me.LblClassSectionSubSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSectionSubSection.Location = New System.Drawing.Point(741, 101)
        Me.LblClassSectionSubSection.Name = "LblClassSectionSubSection"
        Me.LblClassSectionSubSection.Size = New System.Drawing.Size(75, 13)
        Me.LblClassSectionSubSection.TabIndex = 720
        Me.LblClassSectionSubSection.Text = "Sub Section"
        '
        'TxtSession
        '
        Me.TxtSession.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSession.Location = New System.Drawing.Point(152, 163)
        Me.TxtSession.MaxLength = 0
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(334, 21)
        Me.TxtSession.TabIndex = 7
        '
        'LblSession
        '
        Me.LblSession.AutoSize = True
        Me.LblSession.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSession.Location = New System.Drawing.Point(20, 167)
        Me.LblSession.Name = "LblSession"
        Me.LblSession.Size = New System.Drawing.Size(51, 13)
        Me.LblSession.TabIndex = 722
        Me.LblSession.Text = "Session"
        '
        'FrmSubjectMarksEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 612)
        Me.Controls.Add(Me.TxtSession)
        Me.Controls.Add(Me.LblSession)
        Me.Controls.Add(Me.TxtClassSectionSubSection)
        Me.Controls.Add(Me.LblClassSectionSubSection)
        Me.Controls.Add(Me.TxtClassSection)
        Me.Controls.Add(Me.LblClassSection)
        Me.Controls.Add(Me.LblIsAttendanceMarksReq)
        Me.Controls.Add(Me.TxtIsAttendanceMarks)
        Me.Controls.Add(Me.LblIsAttendanceMarks)
        Me.Controls.Add(Me.LblMinMarks)
        Me.Controls.Add(Me.TxtMinMarks)
        Me.Controls.Add(Me.LblMaxMarks)
        Me.Controls.Add(Me.TxtMaxMarks)
        Me.Controls.Add(Me.LblTotalPassWithGraceStudent)
        Me.Controls.Add(Me.TxtTotalPassWithGraceStudent)
        Me.Controls.Add(Me.LblTotalFailStudent)
        Me.Controls.Add(Me.TxtTotalFailStudent)
        Me.Controls.Add(Me.LblTotalPassStudent)
        Me.Controls.Add(Me.TxtTotalPassStudent)
        Me.Controls.Add(Me.LblSubjectReq)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.LblSubject)
        Me.Controls.Add(Me.LblExamNatureReq)
        Me.Controls.Add(Me.TxtExamNature)
        Me.Controls.Add(Me.LblExamNature)
        Me.Controls.Add(Me.LblTotalStudent)
        Me.Controls.Add(Me.TxtTotalStudent)
        Me.Controls.Add(Me.LblSemesterExamReq)
        Me.Controls.Add(Me.TxtSemesterExam)
        Me.Controls.Add(Me.LblSemesterExam)
        Me.Controls.Add(Me.LblSessionProgrammeReq)
        Me.Controls.Add(Me.TxtSessionProgramme)
        Me.Controls.Add(Me.LblSessionProgramme)
        Me.Controls.Add(Me.TxtStreamYearSemester)
        Me.Controls.Add(Me.LblStreamYearSemester)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtDocId)
        Me.Controls.Add(Me.LblV_No)
        Me.Controls.Add(Me.TxtV_No)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.LblV_TypeReq)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.LblV_Type)
        Me.Controls.Add(Me.TxtV_Type)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblDocId)
        Me.Controls.Add(Me.LblPrefix)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSubjectMarksEntry"
        Me.Text = "Subject Marks Entry"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblExamNatureReq As System.Windows.Forms.Label
    Friend WithEvents TxtExamNature As AgControls.AgTextBox
    Friend WithEvents LblExamNature As System.Windows.Forms.Label
    Friend WithEvents LblTotalStudent As System.Windows.Forms.Label
    Friend WithEvents TxtTotalStudent As AgControls.AgTextBox
    Friend WithEvents LblSemesterExamReq As System.Windows.Forms.Label
    Friend WithEvents TxtSemesterExam As AgControls.AgTextBox
    Friend WithEvents LblSemesterExam As System.Windows.Forms.Label
    Friend WithEvents LblSessionProgrammeReq As System.Windows.Forms.Label
    Friend WithEvents TxtSessionProgramme As AgControls.AgTextBox
    Friend WithEvents LblSessionProgramme As System.Windows.Forms.Label
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtDocId As AgControls.AgTextBox
    Friend WithEvents LblV_No As System.Windows.Forms.Label
    Friend WithEvents TxtV_No As AgControls.AgTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblV_Date As System.Windows.Forms.Label
    Friend WithEvents LblV_TypeReq As System.Windows.Forms.Label
    Friend WithEvents TxtV_Date As AgControls.AgTextBox
    Friend WithEvents LblV_Type As System.Windows.Forms.Label
    Friend WithEvents TxtV_Type As AgControls.AgTextBox
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblDocId As System.Windows.Forms.Label
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents LblSubjectReq As System.Windows.Forms.Label
    Friend WithEvents TxtSubject As AgControls.AgTextBox
    Friend WithEvents LblSubject As System.Windows.Forms.Label
    Friend WithEvents LblTotalPassStudent As System.Windows.Forms.Label
    Friend WithEvents TxtTotalPassStudent As AgControls.AgTextBox
    Friend WithEvents LblTotalFailStudent As System.Windows.Forms.Label
    Friend WithEvents TxtTotalFailStudent As AgControls.AgTextBox
    Friend WithEvents LblTotalPassWithGraceStudent As System.Windows.Forms.Label
    Friend WithEvents TxtTotalPassWithGraceStudent As AgControls.AgTextBox
    Friend WithEvents LblMaxMarks As System.Windows.Forms.Label
    Friend WithEvents TxtMaxMarks As AgControls.AgTextBox
    Friend WithEvents LblMinMarks As System.Windows.Forms.Label
    Friend WithEvents TxtMinMarks As AgControls.AgTextBox
    Friend WithEvents LblIsAttendanceMarksReq As System.Windows.Forms.Label
    Friend WithEvents TxtIsAttendanceMarks As AgControls.AgTextBox
    Friend WithEvents LblIsAttendanceMarks As System.Windows.Forms.Label
    Friend WithEvents TxtClassSection As AgControls.AgTextBox
    Friend WithEvents LblClassSection As System.Windows.Forms.Label
    Friend WithEvents TxtClassSectionSubSection As AgControls.AgTextBox
    Friend WithEvents LblClassSectionSubSection As System.Windows.Forms.Label
    Friend WithEvents TxtSession As AgControls.AgTextBox
    Friend WithEvents LblSession As System.Windows.Forms.Label
End Class
