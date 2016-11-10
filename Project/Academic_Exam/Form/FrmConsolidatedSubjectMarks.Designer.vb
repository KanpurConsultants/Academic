<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConsolidatedSubjectMarks
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
        Me.LblMaxMarks = New System.Windows.Forms.Label
        Me.TxtMaxMarks = New AgControls.AgTextBox
        Me.LblSubjectReq = New System.Windows.Forms.Label
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubject = New System.Windows.Forms.Label
        Me.TxtSessionProgramme = New AgControls.AgTextBox
        Me.LblSessionProgramme = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.BtnFillMarksDetail = New System.Windows.Forms.Button
        Me.TxtRemark = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
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
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LblMinMarks = New System.Windows.Forms.Label
        Me.TxtMinMarks = New AgControls.AgTextBox
        Me.LblSubExamNatureReq = New System.Windows.Forms.Label
        Me.TxtSubExamNature = New AgControls.AgTextBox
        Me.LblSubExamNature = New System.Windows.Forms.Label
        Me.LblSemesterExamReq = New System.Windows.Forms.Label
        Me.TxtSemesterExam = New AgControls.AgTextBox
        Me.LblSemesterExam = New System.Windows.Forms.Label
        Me.BtnFillSubSemesterExam = New System.Windows.Forms.Button
        Me.Tc1 = New System.Windows.Forms.TabControl
        Me.Tp1 = New System.Windows.Forms.TabPage
        Me.Tp2 = New System.Windows.Forms.TabPage
        Me.TxtSession = New AgControls.AgTextBox
        Me.LblSession = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtClassSectionSubSection = New AgControls.AgTextBox
        Me.LblClassSectionSubSection = New System.Windows.Forms.Label
        Me.TxtClassSection = New AgControls.AgTextBox
        Me.LblClassSection = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Tc1.SuspendLayout()
        Me.Tp1.SuspendLayout()
        Me.Tp2.SuspendLayout()
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
        Me.Topctrl1.Size = New System.Drawing.Size(949, 41)
        Me.Topctrl1.TabIndex = 17
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
        'LblMaxMarks
        '
        Me.LblMaxMarks.AutoSize = True
        Me.LblMaxMarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMaxMarks.Location = New System.Drawing.Point(506, 173)
        Me.LblMaxMarks.Name = "LblMaxMarks"
        Me.LblMaxMarks.Size = New System.Drawing.Size(68, 13)
        Me.LblMaxMarks.TabIndex = 745
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
        Me.TxtMaxMarks.Location = New System.Drawing.Point(635, 171)
        Me.TxtMaxMarks.Name = "TxtMaxMarks"
        Me.TxtMaxMarks.ReadOnly = True
        Me.TxtMaxMarks.Size = New System.Drawing.Size(100, 21)
        Me.TxtMaxMarks.TabIndex = 13
        Me.TxtMaxMarks.TabStop = False
        Me.TxtMaxMarks.Text = "TxtMaxMarks"
        Me.TxtMaxMarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblSubjectReq
        '
        Me.LblSubjectReq.AutoSize = True
        Me.LblSubjectReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubjectReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubjectReq.Location = New System.Drawing.Point(618, 156)
        Me.LblSubjectReq.Name = "LblSubjectReq"
        Me.LblSubjectReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubjectReq.TabIndex = 744
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
        Me.TxtSubject.Location = New System.Drawing.Point(635, 149)
        Me.TxtSubject.MaxLength = 50
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(293, 21)
        Me.TxtSubject.TabIndex = 12
        Me.TxtSubject.Text = "TxtSubject"
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(506, 151)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(50, 13)
        Me.LblSubject.TabIndex = 743
        Me.LblSubject.Text = "Subject"
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
        Me.TxtSessionProgramme.Location = New System.Drawing.Point(153, 168)
        Me.TxtSessionProgramme.MaxLength = 50
        Me.TxtSessionProgramme.Name = "TxtSessionProgramme"
        Me.TxtSessionProgramme.Size = New System.Drawing.Size(320, 21)
        Me.TxtSessionProgramme.TabIndex = 6
        Me.TxtSessionProgramme.Text = "TxtSessionProgramme"
        '
        'LblSessionProgramme
        '
        Me.LblSessionProgramme.AutoSize = True
        Me.LblSessionProgramme.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgramme.Location = New System.Drawing.Point(18, 172)
        Me.LblSessionProgramme.Name = "LblSessionProgramme"
        Me.LblSessionProgramme.Size = New System.Drawing.Size(123, 13)
        Me.LblSessionProgramme.TabIndex = 737
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
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(635, 60)
        Me.TxtStreamYearSemester.MaxLength = 50
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(293, 21)
        Me.TxtStreamYearSemester.TabIndex = 7
        Me.TxtStreamYearSemester.Text = "TxtStreamYearSemester"
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(506, 62)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(62, 13)
        Me.LblStreamYearSemester.TabIndex = 735
        Me.LblStreamYearSemester.Text = "Semester"
        '
        'BtnFillMarksDetail
        '
        Me.BtnFillMarksDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillMarksDetail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillMarksDetail.Location = New System.Drawing.Point(768, 7)
        Me.BtnFillMarksDetail.Name = "BtnFillMarksDetail"
        Me.BtnFillMarksDetail.Size = New System.Drawing.Size(100, 23)
        Me.BtnFillMarksDetail.TabIndex = 14
        Me.BtnFillMarksDetail.Text = "&Fill Student"
        Me.BtnFillMarksDetail.UseVisualStyleBackColor = True
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
        Me.TxtRemark.Location = New System.Drawing.Point(164, 516)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(293, 21)
        Me.TxtRemark.TabIndex = 16
        Me.TxtRemark.Text = "TxtRemark"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(22, 516)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "&Remark"
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
        Me.TxtDocId.Location = New System.Drawing.Point(153, 58)
        Me.TxtDocId.MaxLength = 21
        Me.TxtDocId.Name = "TxtDocId"
        Me.TxtDocId.ReadOnly = True
        Me.TxtDocId.Size = New System.Drawing.Size(320, 21)
        Me.TxtDocId.TabIndex = 0
        Me.TxtDocId.TabStop = False
        Me.TxtDocId.Text = "TxtDocId"
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(255, 128)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(98, 13)
        Me.LblV_No.TabIndex = 731
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
        Me.TxtV_No.Location = New System.Drawing.Point(382, 124)
        Me.TxtV_No.Name = "TxtV_No"
        Me.TxtV_No.Size = New System.Drawing.Size(91, 21)
        Me.TxtV_No.TabIndex = 4
        Me.TxtV_No.Text = "TxtV_No"
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(140, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 734
        Me.Label5.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(140, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 733
        Me.Label2.Text = "Ä"
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(18, 129)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(106, 13)
        Me.LblV_Date.TabIndex = 729
        Me.LblV_Date.Text = "Marks Entry Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.AutoSize = True
        Me.LblV_TypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblV_TypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblV_TypeReq.Location = New System.Drawing.Point(140, 110)
        Me.LblV_TypeReq.Name = "LblV_TypeReq"
        Me.LblV_TypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblV_TypeReq.TabIndex = 732
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
        Me.TxtV_Date.Location = New System.Drawing.Point(153, 124)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_Date.TabIndex = 3
        Me.TxtV_Date.Text = "TxtV_Date"
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(18, 107)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(107, 13)
        Me.LblV_Type.TabIndex = 728
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
        Me.TxtV_Type.Location = New System.Drawing.Point(153, 102)
        Me.TxtV_Type.MaxLength = 5
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(320, 21)
        Me.TxtV_Type.TabIndex = 2
        Me.TxtV_Type.Text = "TxtV_Type"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(140, 88)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 727
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(18, 85)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 730
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(153, 80)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(320, 21)
        Me.TxtSite_Code.TabIndex = 1
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblDocId
        '
        Me.LblDocId.AutoSize = True
        Me.LblDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocId.Location = New System.Drawing.Point(18, 63)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(41, 13)
        Me.LblDocId.TabIndex = 725
        Me.LblDocId.Text = "DocId"
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(350, 128)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(56, 13)
        Me.LblPrefix.TabIndex = 726
        Me.LblPrefix.Text = "LblPrefix"
        '
        'Pnl2
        '
        Me.Pnl2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl2.Location = New System.Drawing.Point(30, 31)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(838, 242)
        Me.Pnl2.TabIndex = 15
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(198, 44)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(385, 229)
        Me.Pnl1.TabIndex = 1
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 553)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 748
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
        Me.GroupBox4.Location = New System.Drawing.Point(751, 553)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 749
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
        Me.GroupBox2.Location = New System.Drawing.Point(0, 543)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(950, 4)
        Me.GroupBox2.TabIndex = 750
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'LblMinMarks
        '
        Me.LblMinMarks.AutoSize = True
        Me.LblMinMarks.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMinMarks.Location = New System.Drawing.Point(747, 174)
        Me.LblMinMarks.Name = "LblMinMarks"
        Me.LblMinMarks.Size = New System.Drawing.Size(64, 13)
        Me.LblMinMarks.TabIndex = 752
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
        Me.TxtMinMarks.Location = New System.Drawing.Point(826, 170)
        Me.TxtMinMarks.Name = "TxtMinMarks"
        Me.TxtMinMarks.ReadOnly = True
        Me.TxtMinMarks.Size = New System.Drawing.Size(100, 21)
        Me.TxtMinMarks.TabIndex = 14
        Me.TxtMinMarks.TabStop = False
        Me.TxtMinMarks.Text = "TxtMinMarks"
        Me.TxtMinMarks.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblSubExamNatureReq
        '
        Me.LblSubExamNatureReq.AutoSize = True
        Me.LblSubExamNatureReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubExamNatureReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubExamNatureReq.Location = New System.Drawing.Point(618, 132)
        Me.LblSubExamNatureReq.Name = "LblSubExamNatureReq"
        Me.LblSubExamNatureReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubExamNatureReq.TabIndex = 758
        Me.LblSubExamNatureReq.Text = "Ä"
        '
        'TxtSubExamNature
        '
        Me.TxtSubExamNature.AgAllowUserToEnableMasterHelp = False
        Me.TxtSubExamNature.AgMandatory = True
        Me.TxtSubExamNature.AgMasterHelp = False
        Me.TxtSubExamNature.AgNumberLeftPlaces = 0
        Me.TxtSubExamNature.AgNumberNegetiveAllow = False
        Me.TxtSubExamNature.AgNumberRightPlaces = 0
        Me.TxtSubExamNature.AgPickFromLastValue = False
        Me.TxtSubExamNature.AgRowFilter = ""
        Me.TxtSubExamNature.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubExamNature.AgSelectedValue = Nothing
        Me.TxtSubExamNature.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubExamNature.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubExamNature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubExamNature.Location = New System.Drawing.Point(635, 127)
        Me.TxtSubExamNature.MaxLength = 50
        Me.TxtSubExamNature.Name = "TxtSubExamNature"
        Me.TxtSubExamNature.Size = New System.Drawing.Size(293, 21)
        Me.TxtSubExamNature.TabIndex = 11
        Me.TxtSubExamNature.Text = "TxtSubExamNature"
        '
        'LblSubExamNature
        '
        Me.LblSubExamNature.AutoSize = True
        Me.LblSubExamNature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubExamNature.Location = New System.Drawing.Point(506, 129)
        Me.LblSubExamNature.Name = "LblSubExamNature"
        Me.LblSubExamNature.Size = New System.Drawing.Size(107, 13)
        Me.LblSubExamNature.TabIndex = 757
        Me.LblSubExamNature.Text = "Sub Exam Nature"
        '
        'LblSemesterExamReq
        '
        Me.LblSemesterExamReq.AutoSize = True
        Me.LblSemesterExamReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSemesterExamReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSemesterExamReq.Location = New System.Drawing.Point(618, 110)
        Me.LblSemesterExamReq.Name = "LblSemesterExamReq"
        Me.LblSemesterExamReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSemesterExamReq.TabIndex = 761
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
        Me.TxtSemesterExam.Location = New System.Drawing.Point(635, 104)
        Me.TxtSemesterExam.MaxLength = 50
        Me.TxtSemesterExam.Name = "TxtSemesterExam"
        Me.TxtSemesterExam.Size = New System.Drawing.Size(293, 21)
        Me.TxtSemesterExam.TabIndex = 10
        Me.TxtSemesterExam.Text = "TxtSemesterExam"
        '
        'LblSemesterExam
        '
        Me.LblSemesterExam.AutoSize = True
        Me.LblSemesterExam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSemesterExam.Location = New System.Drawing.Point(506, 106)
        Me.LblSemesterExam.Name = "LblSemesterExam"
        Me.LblSemesterExam.Size = New System.Drawing.Size(99, 13)
        Me.LblSemesterExam.TabIndex = 760
        Me.LblSemesterExam.Text = "Semester/Exam"
        '
        'BtnFillSubSemesterExam
        '
        Me.BtnFillSubSemesterExam.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillSubSemesterExam.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillSubSemesterExam.Location = New System.Drawing.Point(198, 21)
        Me.BtnFillSubSemesterExam.Name = "BtnFillSubSemesterExam"
        Me.BtnFillSubSemesterExam.Size = New System.Drawing.Size(385, 23)
        Me.BtnFillSubSemesterExam.TabIndex = 0
        Me.BtnFillSubSemesterExam.Text = "Fill &Test/Assignment"
        Me.BtnFillSubSemesterExam.UseVisualStyleBackColor = True
        '
        'Tc1
        '
        Me.Tc1.Controls.Add(Me.Tp1)
        Me.Tc1.Controls.Add(Me.Tp2)
        Me.Tc1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tc1.Location = New System.Drawing.Point(12, 206)
        Me.Tc1.Name = "Tc1"
        Me.Tc1.SelectedIndex = 0
        Me.Tc1.Size = New System.Drawing.Size(916, 305)
        Me.Tc1.TabIndex = 15
        '
        'Tp1
        '
        Me.Tp1.Controls.Add(Me.Pnl1)
        Me.Tp1.Controls.Add(Me.BtnFillSubSemesterExam)
        Me.Tp1.Location = New System.Drawing.Point(4, 22)
        Me.Tp1.Name = "Tp1"
        Me.Tp1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp1.Size = New System.Drawing.Size(908, 279)
        Me.Tp1.TabIndex = 0
        Me.Tp1.Text = "Test/Assignment Detail"
        Me.Tp1.UseVisualStyleBackColor = True
        '
        'Tp2
        '
        Me.Tp2.Controls.Add(Me.Pnl2)
        Me.Tp2.Controls.Add(Me.BtnFillMarksDetail)
        Me.Tp2.Location = New System.Drawing.Point(4, 22)
        Me.Tp2.Name = "Tp2"
        Me.Tp2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp2.Size = New System.Drawing.Size(908, 279)
        Me.Tp2.TabIndex = 1
        Me.Tp2.Text = "Marks Detail"
        Me.Tp2.UseVisualStyleBackColor = True
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
        Me.TxtSession.Location = New System.Drawing.Point(153, 146)
        Me.TxtSession.MaxLength = 0
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(320, 21)
        Me.TxtSession.TabIndex = 5
        '
        'LblSession
        '
        Me.LblSession.AutoSize = True
        Me.LblSession.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSession.Location = New System.Drawing.Point(18, 150)
        Me.LblSession.Name = "LblSession"
        Me.LblSession.Size = New System.Drawing.Size(51, 13)
        Me.LblSession.TabIndex = 764
        Me.LblSession.Text = "Session"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(360, 302)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 7)
        Me.Label1.TabIndex = 763
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
        Me.TxtClassSectionSubSection.Location = New System.Drawing.Point(828, 82)
        Me.TxtClassSectionSubSection.MaxLength = 50
        Me.TxtClassSectionSubSection.Name = "TxtClassSectionSubSection"
        Me.TxtClassSectionSubSection.Size = New System.Drawing.Size(100, 21)
        Me.TxtClassSectionSubSection.TabIndex = 9
        '
        'LblClassSectionSubSection
        '
        Me.LblClassSectionSubSection.AutoSize = True
        Me.LblClassSectionSubSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSectionSubSection.Location = New System.Drawing.Point(755, 86)
        Me.LblClassSectionSubSection.Name = "LblClassSectionSubSection"
        Me.LblClassSectionSubSection.Size = New System.Drawing.Size(75, 13)
        Me.LblClassSectionSubSection.TabIndex = 768
        Me.LblClassSectionSubSection.Text = "Sub Section"
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
        Me.TxtClassSection.Location = New System.Drawing.Point(635, 82)
        Me.TxtClassSection.MaxLength = 50
        Me.TxtClassSection.Name = "TxtClassSection"
        Me.TxtClassSection.Size = New System.Drawing.Size(118, 21)
        Me.TxtClassSection.TabIndex = 8
        '
        'LblClassSection
        '
        Me.LblClassSection.AutoSize = True
        Me.LblClassSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSection.Location = New System.Drawing.Point(506, 86)
        Me.LblClassSection.Name = "LblClassSection"
        Me.LblClassSection.Size = New System.Drawing.Size(85, 13)
        Me.LblClassSection.TabIndex = 767
        Me.LblClassSection.Text = "Class/Section"
        '
        'FrmConsolidatedSubjectMarks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(949, 610)
        Me.Controls.Add(Me.TxtClassSectionSubSection)
        Me.Controls.Add(Me.LblClassSectionSubSection)
        Me.Controls.Add(Me.TxtClassSection)
        Me.Controls.Add(Me.LblClassSection)
        Me.Controls.Add(Me.TxtSession)
        Me.Controls.Add(Me.LblSession)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Tc1)
        Me.Controls.Add(Me.LblSemesterExamReq)
        Me.Controls.Add(Me.TxtSemesterExam)
        Me.Controls.Add(Me.LblSemesterExam)
        Me.Controls.Add(Me.LblSubExamNatureReq)
        Me.Controls.Add(Me.TxtSubExamNature)
        Me.Controls.Add(Me.LblSubExamNature)
        Me.Controls.Add(Me.LblMinMarks)
        Me.Controls.Add(Me.TxtMinMarks)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.LblMaxMarks)
        Me.Controls.Add(Me.TxtMaxMarks)
        Me.Controls.Add(Me.LblSubjectReq)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.LblSubject)
        Me.Controls.Add(Me.TxtSessionProgramme)
        Me.Controls.Add(Me.LblSessionProgramme)
        Me.Controls.Add(Me.TxtStreamYearSemester)
        Me.Controls.Add(Me.LblStreamYearSemester)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label12)
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
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmConsolidatedSubjectMarks"
        Me.Text = "FrmExamMarksEntry"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Tc1.ResumeLayout(False)
        Me.Tp1.ResumeLayout(False)
        Me.Tp2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblMaxMarks As System.Windows.Forms.Label
    Friend WithEvents TxtMaxMarks As AgControls.AgTextBox
    Friend WithEvents LblSubjectReq As System.Windows.Forms.Label
    Friend WithEvents TxtSubject As AgControls.AgTextBox
    Friend WithEvents LblSubject As System.Windows.Forms.Label
    Friend WithEvents TxtSessionProgramme As AgControls.AgTextBox
    Friend WithEvents LblSessionProgramme As System.Windows.Forms.Label
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents BtnFillMarksDetail As System.Windows.Forms.Button
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
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
    Friend WithEvents Pnl2 As System.Windows.Forms.Panel
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblMinMarks As System.Windows.Forms.Label
    Friend WithEvents TxtMinMarks As AgControls.AgTextBox
    Friend WithEvents LblSubExamNatureReq As System.Windows.Forms.Label
    Friend WithEvents TxtSubExamNature As AgControls.AgTextBox
    Friend WithEvents LblSubExamNature As System.Windows.Forms.Label
    Friend WithEvents LblSemesterExamReq As System.Windows.Forms.Label
    Friend WithEvents TxtSemesterExam As AgControls.AgTextBox
    Friend WithEvents LblSemesterExam As System.Windows.Forms.Label
    Friend WithEvents BtnFillSubSemesterExam As System.Windows.Forms.Button
    Friend WithEvents Tc1 As System.Windows.Forms.TabControl
    Friend WithEvents Tp1 As System.Windows.Forms.TabPage
    Friend WithEvents Tp2 As System.Windows.Forms.TabPage
    Friend WithEvents TxtSession As AgControls.AgTextBox
    Friend WithEvents LblSession As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtClassSectionSubSection As AgControls.AgTextBox
    Friend WithEvents LblClassSectionSubSection As System.Windows.Forms.Label
    Friend WithEvents TxtClassSection As AgControls.AgTextBox
    Friend WithEvents LblClassSection As System.Windows.Forms.Label
End Class
