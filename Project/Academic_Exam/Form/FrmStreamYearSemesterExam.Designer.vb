<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStreamYearSemesterExam
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
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.TxtCopyFrom = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblExamTypeReq = New System.Windows.Forms.Label
        Me.TxtExamType = New AgControls.AgTextBox
        Me.LblExamType = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.TxtSessionProgramme = New AgControls.AgTextBox
        Me.LblSessionProgramme = New System.Windows.Forms.Label
        Me.ChkTheory = New System.Windows.Forms.CheckBox
        Me.GrpSubjectType = New System.Windows.Forms.GroupBox
        Me.ChkGenProf = New System.Windows.Forms.CheckBox
        Me.ChkPractical = New System.Windows.Forms.CheckBox
        Me.TxtClassSectionSubSection = New AgControls.AgTextBox
        Me.LblClassSectionSubSection = New System.Windows.Forms.Label
        Me.LblClassSection = New System.Windows.Forms.Label
        Me.TxtClassSection = New AgControls.AgTextBox
        Me.TxtSession = New AgControls.AgTextBox
        Me.LblSession = New System.Windows.Forms.Label
        Me.TxtExamDescription = New AgControls.AgTextBox
        Me.LblSemesterExam = New System.Windows.Forms.Label
        Me.TC1 = New System.Windows.Forms.TabControl
        Me.TP1 = New System.Windows.Forms.TabPage
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TP2 = New System.Windows.Forms.TabPage
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpSubjectType.SuspendLayout()
        Me.TC1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.TP2.SuspendLayout()
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
        Me.Topctrl1.Size = New System.Drawing.Size(942, 41)
        Me.Topctrl1.TabIndex = 12
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
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(273, 92)
        Me.TxtStreamYearSemester.MaxLength = 50
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(325, 21)
        Me.TxtStreamYearSemester.TabIndex = 2
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(129, 95)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(62, 13)
        Me.LblStreamYearSemester.TabIndex = 0
        Me.LblStreamYearSemester.Text = "Semester"
        '
        'TxtCopyFrom
        '
        Me.TxtCopyFrom.AgAllowUserToEnableMasterHelp = False
        Me.TxtCopyFrom.AgMandatory = False
        Me.TxtCopyFrom.AgMasterHelp = False
        Me.TxtCopyFrom.AgNumberLeftPlaces = 0
        Me.TxtCopyFrom.AgNumberNegetiveAllow = False
        Me.TxtCopyFrom.AgNumberRightPlaces = 0
        Me.TxtCopyFrom.AgPickFromLastValue = False
        Me.TxtCopyFrom.AgRowFilter = ""
        Me.TxtCopyFrom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCopyFrom.AgSelectedValue = Nothing
        Me.TxtCopyFrom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCopyFrom.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCopyFrom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCopyFrom.Location = New System.Drawing.Point(273, 158)
        Me.TxtCopyFrom.MaxLength = 50
        Me.TxtCopyFrom.Name = "TxtCopyFrom"
        Me.TxtCopyFrom.Size = New System.Drawing.Size(325, 21)
        Me.TxtCopyFrom.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(129, 161)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Copy From"
        '
        'LblExamTypeReq
        '
        Me.LblExamTypeReq.AutoSize = True
        Me.LblExamTypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblExamTypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblExamTypeReq.Location = New System.Drawing.Point(257, 144)
        Me.LblExamTypeReq.Name = "LblExamTypeReq"
        Me.LblExamTypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblExamTypeReq.TabIndex = 15
        Me.LblExamTypeReq.Text = "Ä"
        '
        'TxtExamType
        '
        Me.TxtExamType.AgAllowUserToEnableMasterHelp = False
        Me.TxtExamType.AgMandatory = True
        Me.TxtExamType.AgMasterHelp = False
        Me.TxtExamType.AgNumberLeftPlaces = 0
        Me.TxtExamType.AgNumberNegetiveAllow = False
        Me.TxtExamType.AgNumberRightPlaces = 0
        Me.TxtExamType.AgPickFromLastValue = False
        Me.TxtExamType.AgRowFilter = ""
        Me.TxtExamType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtExamType.AgSelectedValue = Nothing
        Me.TxtExamType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtExamType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtExamType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExamType.Location = New System.Drawing.Point(273, 136)
        Me.TxtExamType.MaxLength = 50
        Me.TxtExamType.Name = "TxtExamType"
        Me.TxtExamType.Size = New System.Drawing.Size(325, 21)
        Me.TxtExamType.TabIndex = 5
        '
        'LblExamType
        '
        Me.LblExamType.AutoSize = True
        Me.LblExamType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblExamType.Location = New System.Drawing.Point(129, 139)
        Me.LblExamType.Name = "LblExamType"
        Me.LblExamType.Size = New System.Drawing.Size(71, 13)
        Me.LblExamType.TabIndex = 13
        Me.LblExamType.Text = "Exam Type"
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
        Me.TxtSite_Code.BackColor = System.Drawing.SystemColors.Control
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(273, 48)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 21)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(129, 52)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 512
        Me.LblSite_Code.Text = "Branch/Site"
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
        Me.TxtRemark.Location = New System.Drawing.Point(93, 525)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(325, 21)
        Me.TxtRemark.TabIndex = 11
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(13, 528)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(52, 13)
        Me.LblRemark.TabIndex = 7
        Me.LblRemark.Text = "&Remark"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(681, 150)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(186, 23)
        Me.BtnFill.TabIndex = 9
        Me.BtnFill.Text = "&Fill Subject"
        Me.BtnFill.UseVisualStyleBackColor = True
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
        Me.TxtSessionProgramme.Location = New System.Drawing.Point(273, 70)
        Me.TxtSessionProgramme.MaxLength = 50
        Me.TxtSessionProgramme.Name = "TxtSessionProgramme"
        Me.TxtSessionProgramme.Size = New System.Drawing.Size(325, 21)
        Me.TxtSessionProgramme.TabIndex = 1
        '
        'LblSessionProgramme
        '
        Me.LblSessionProgramme.AutoSize = True
        Me.LblSessionProgramme.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgramme.Location = New System.Drawing.Point(129, 73)
        Me.LblSessionProgramme.Name = "LblSessionProgramme"
        Me.LblSessionProgramme.Size = New System.Drawing.Size(123, 13)
        Me.LblSessionProgramme.TabIndex = 514
        Me.LblSessionProgramme.Text = "Session/Programme"
        '
        'ChkTheory
        '
        Me.ChkTheory.AutoSize = True
        Me.ChkTheory.Location = New System.Drawing.Point(21, 22)
        Me.ChkTheory.Name = "ChkTheory"
        Me.ChkTheory.Size = New System.Drawing.Size(66, 17)
        Me.ChkTheory.TabIndex = 518
        Me.ChkTheory.Text = "Theory"
        Me.ChkTheory.UseVisualStyleBackColor = True
        '
        'GrpSubjectType
        '
        Me.GrpSubjectType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpSubjectType.Controls.Add(Me.ChkGenProf)
        Me.GrpSubjectType.Controls.Add(Me.ChkPractical)
        Me.GrpSubjectType.Controls.Add(Me.ChkTheory)
        Me.GrpSubjectType.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpSubjectType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpSubjectType.ForeColor = System.Drawing.Color.Maroon
        Me.GrpSubjectType.Location = New System.Drawing.Point(681, 60)
        Me.GrpSubjectType.Name = "GrpSubjectType"
        Me.GrpSubjectType.Size = New System.Drawing.Size(186, 88)
        Me.GrpSubjectType.TabIndex = 689
        Me.GrpSubjectType.TabStop = False
        Me.GrpSubjectType.Tag = ""
        Me.GrpSubjectType.Text = "Subject Type"
        '
        'ChkGenProf
        '
        Me.ChkGenProf.AutoSize = True
        Me.ChkGenProf.Location = New System.Drawing.Point(21, 62)
        Me.ChkGenProf.Name = "ChkGenProf"
        Me.ChkGenProf.Size = New System.Drawing.Size(137, 17)
        Me.ChkGenProf.TabIndex = 691
        Me.ChkGenProf.Text = "General Proficiency"
        Me.ChkGenProf.UseVisualStyleBackColor = True
        '
        'ChkPractical
        '
        Me.ChkPractical.AutoSize = True
        Me.ChkPractical.Location = New System.Drawing.Point(21, 42)
        Me.ChkPractical.Name = "ChkPractical"
        Me.ChkPractical.Size = New System.Drawing.Size(74, 17)
        Me.ChkPractical.TabIndex = 690
        Me.ChkPractical.Text = "Practical"
        Me.ChkPractical.UseVisualStyleBackColor = True
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
        Me.TxtClassSectionSubSection.Location = New System.Drawing.Point(480, 114)
        Me.TxtClassSectionSubSection.MaxLength = 50
        Me.TxtClassSectionSubSection.Name = "TxtClassSectionSubSection"
        Me.TxtClassSectionSubSection.Size = New System.Drawing.Size(118, 21)
        Me.TxtClassSectionSubSection.TabIndex = 4
        '
        'LblClassSectionSubSection
        '
        Me.LblClassSectionSubSection.AutoSize = True
        Me.LblClassSectionSubSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSectionSubSection.Location = New System.Drawing.Point(400, 118)
        Me.LblClassSectionSubSection.Name = "LblClassSectionSubSection"
        Me.LblClassSectionSubSection.Size = New System.Drawing.Size(75, 13)
        Me.LblClassSectionSubSection.TabIndex = 701
        Me.LblClassSectionSubSection.Text = "Sub Section"
        '
        'LblClassSection
        '
        Me.LblClassSection.AutoSize = True
        Me.LblClassSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSection.Location = New System.Drawing.Point(129, 117)
        Me.LblClassSection.Name = "LblClassSection"
        Me.LblClassSection.Size = New System.Drawing.Size(85, 13)
        Me.LblClassSection.TabIndex = 700
        Me.LblClassSection.Text = "Class/Section"
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
        Me.TxtClassSection.Location = New System.Drawing.Point(273, 114)
        Me.TxtClassSection.MaxLength = 50
        Me.TxtClassSection.Name = "TxtClassSection"
        Me.TxtClassSection.Size = New System.Drawing.Size(122, 21)
        Me.TxtClassSection.TabIndex = 3
        '
        'TxtSession
        '
        Me.TxtSession.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSession.Location = New System.Drawing.Point(273, 180)
        Me.TxtSession.MaxLength = 0
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(325, 21)
        Me.TxtSession.TabIndex = 7
        '
        'LblSession
        '
        Me.LblSession.AutoSize = True
        Me.LblSession.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSession.Location = New System.Drawing.Point(129, 184)
        Me.LblSession.Name = "LblSession"
        Me.LblSession.Size = New System.Drawing.Size(51, 13)
        Me.LblSession.TabIndex = 703
        Me.LblSession.Text = "Session"
        '
        'TxtExamDescription
        '
        Me.TxtExamDescription.AgAllowUserToEnableMasterHelp = False
        Me.TxtExamDescription.AgMandatory = False
        Me.TxtExamDescription.AgMasterHelp = False
        Me.TxtExamDescription.AgNumberLeftPlaces = 0
        Me.TxtExamDescription.AgNumberNegetiveAllow = False
        Me.TxtExamDescription.AgNumberRightPlaces = 0
        Me.TxtExamDescription.AgPickFromLastValue = False
        Me.TxtExamDescription.AgRowFilter = ""
        Me.TxtExamDescription.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtExamDescription.AgSelectedValue = Nothing
        Me.TxtExamDescription.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtExamDescription.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtExamDescription.Enabled = False
        Me.TxtExamDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExamDescription.Location = New System.Drawing.Point(273, 202)
        Me.TxtExamDescription.MaxLength = 50
        Me.TxtExamDescription.Name = "TxtExamDescription"
        Me.TxtExamDescription.Size = New System.Drawing.Size(325, 21)
        Me.TxtExamDescription.TabIndex = 8
        '
        'LblSemesterExam
        '
        Me.LblSemesterExam.AutoSize = True
        Me.LblSemesterExam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSemesterExam.Location = New System.Drawing.Point(129, 206)
        Me.LblSemesterExam.Name = "LblSemesterExam"
        Me.LblSemesterExam.Size = New System.Drawing.Size(99, 13)
        Me.LblSemesterExam.TabIndex = 705
        Me.LblSemesterExam.Text = "Semester/Exam"
        '
        'TC1
        '
        Me.TC1.Controls.Add(Me.TP1)
        Me.TC1.Controls.Add(Me.TP2)
        Me.TC1.Location = New System.Drawing.Point(12, 225)
        Me.TC1.Name = "TC1"
        Me.TC1.SelectedIndex = 0
        Me.TC1.Size = New System.Drawing.Size(918, 294)
        Me.TC1.TabIndex = 10
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.LightGray
        Me.TP1.Controls.Add(Me.Pnl1)
        Me.TP1.ForeColor = System.Drawing.Color.Black
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Name = "TP1"
        Me.TP1.Padding = New System.Windows.Forms.Padding(3)
        Me.TP1.Size = New System.Drawing.Size(910, 268)
        Me.TP1.TabIndex = 1
        Me.TP1.Text = "Subject Detail"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Pnl1.Location = New System.Drawing.Point(4, 6)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(900, 255)
        Me.Pnl1.TabIndex = 34
        '
        'TP2
        '
        Me.TP2.BackColor = System.Drawing.Color.LightGray
        Me.TP2.Controls.Add(Me.Pnl2)
        Me.TP2.ForeColor = System.Drawing.Color.Black
        Me.TP2.Location = New System.Drawing.Point(4, 22)
        Me.TP2.Name = "TP2"
        Me.TP2.Size = New System.Drawing.Size(910, 268)
        Me.TP2.TabIndex = 2
        Me.TP2.Text = "Semester Detail"
        '
        'Pnl2
        '
        Me.Pnl2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Pnl2.Location = New System.Drawing.Point(17, 15)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(385, 237)
        Me.Pnl2.TabIndex = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(257, 189)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 706
        Me.Label1.Text = "Ä"
        '
        'FrmStreamYearSemesterExam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 566)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TC1)
        Me.Controls.Add(Me.TxtExamDescription)
        Me.Controls.Add(Me.LblSemesterExam)
        Me.Controls.Add(Me.TxtSession)
        Me.Controls.Add(Me.LblSession)
        Me.Controls.Add(Me.TxtClassSectionSubSection)
        Me.Controls.Add(Me.TxtClassSection)
        Me.Controls.Add(Me.GrpSubjectType)
        Me.Controls.Add(Me.LblClassSectionSubSection)
        Me.Controls.Add(Me.LblClassSection)
        Me.Controls.Add(Me.TxtSessionProgramme)
        Me.Controls.Add(Me.LblSessionProgramme)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.LblRemark)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.LblExamTypeReq)
        Me.Controls.Add(Me.TxtExamType)
        Me.Controls.Add(Me.LblExamType)
        Me.Controls.Add(Me.TxtCopyFrom)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtStreamYearSemester)
        Me.Controls.Add(Me.LblStreamYearSemester)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmStreamYearSemesterExam"
        Me.Text = "Stream Year Semester Exam"
        Me.GrpSubjectType.ResumeLayout(False)
        Me.GrpSubjectType.PerformLayout()
        Me.TC1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents TxtCopyFrom As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblExamTypeReq As System.Windows.Forms.Label
    Friend WithEvents LblExamType As System.Windows.Forms.Label
    Friend WithEvents TxtExamType As AgControls.AgTextBox
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents LblRemark As System.Windows.Forms.Label
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Friend WithEvents TxtSessionProgramme As AgControls.AgTextBox
    Friend WithEvents LblSessionProgramme As System.Windows.Forms.Label
    Friend WithEvents ChkTheory As System.Windows.Forms.CheckBox
    Friend WithEvents GrpSubjectType As System.Windows.Forms.GroupBox
    Friend WithEvents ChkGenProf As System.Windows.Forms.CheckBox
    Friend WithEvents ChkPractical As System.Windows.Forms.CheckBox
    Friend WithEvents TxtClassSectionSubSection As AgControls.AgTextBox
    Friend WithEvents LblClassSectionSubSection As System.Windows.Forms.Label
    Friend WithEvents LblClassSection As System.Windows.Forms.Label
    Friend WithEvents TxtClassSection As AgControls.AgTextBox
    Friend WithEvents TxtSession As AgControls.AgTextBox
    Friend WithEvents LblSession As System.Windows.Forms.Label
    Friend WithEvents TxtExamDescription As AgControls.AgTextBox
    Friend WithEvents LblSemesterExam As System.Windows.Forms.Label
    Friend WithEvents TC1 As System.Windows.Forms.TabControl
    Friend WithEvents TP1 As System.Windows.Forms.TabPage
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TP2 As System.Windows.Forms.TabPage
    Friend WithEvents Pnl2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
