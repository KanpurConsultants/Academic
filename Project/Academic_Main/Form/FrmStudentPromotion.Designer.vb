<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStudentPromotion
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
        Me.BtnFillStudent = New System.Windows.Forms.Button
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblTotalStudent = New System.Windows.Forms.Label
        Me.TxtTotalStudent = New AgControls.AgTextBox
        Me.LblSessionProgrammeReq = New System.Windows.Forms.Label
        Me.TxtSessionProgramme = New AgControls.AgTextBox
        Me.LblSessionProgramme = New System.Windows.Forms.Label
        Me.LblSessionProgrammeStreamReq = New System.Windows.Forms.Label
        Me.TxtSessionProgrammeStream = New AgControls.AgTextBox
        Me.LblSessionProgrammeStream = New System.Windows.Forms.Label
        Me.LblFromStreamYearSemesterReq = New System.Windows.Forms.Label
        Me.TxtFromStreamYearSemester = New AgControls.AgTextBox
        Me.LblFromStreamYearSemester = New System.Windows.Forms.Label
        Me.LblSelectAllReq = New System.Windows.Forms.Label
        Me.LblSelectAll = New System.Windows.Forms.Label
        Me.TxtSelectAll = New AgControls.AgTextBox
        Me.TxtPromotionDate = New AgControls.AgTextBox
        Me.LblPromotionDate = New System.Windows.Forms.Label
        Me.LblPromotionDateReq = New System.Windows.Forms.Label
        Me.LblToStreamYearSemesterReq = New System.Windows.Forms.Label
        Me.TxtToStreamYearSemester = New AgControls.AgTextBox
        Me.LblToStreamYearSemester = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.BtnExit = New System.Windows.Forms.Button
        Me.BtnSave = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnFillStudent
        '
        Me.BtnFillStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillStudent.Location = New System.Drawing.Point(763, 107)
        Me.BtnFillStudent.Name = "BtnFillStudent"
        Me.BtnFillStudent.Size = New System.Drawing.Size(100, 27)
        Me.BtnFillStudent.TabIndex = 7
        Me.BtnFillStudent.Text = "&Fill Student"
        Me.BtnFillStudent.UseVisualStyleBackColor = True
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(149, 134)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(596, 415)
        Me.Pnl1.TabIndex = 8
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(136, 32)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 511
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(13, 29)
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
        Me.TxtSite_Code.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtSite_Code.AgSelectedValue = Nothing
        Me.TxtSite_Code.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSite_Code.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(149, 25)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(300, 21)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblTotalStudent
        '
        Me.LblTotalStudent.AutoSize = True
        Me.LblTotalStudent.BackColor = System.Drawing.Color.Cornsilk
        Me.LblTotalStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalStudent.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalStudent.Location = New System.Drawing.Point(339, 7)
        Me.LblTotalStudent.Name = "LblTotalStudent"
        Me.LblTotalStudent.Size = New System.Drawing.Size(142, 13)
        Me.LblTotalStudent.TabIndex = 516
        Me.LblTotalStudent.Text = "Total Promoted Student"
        '
        'TxtTotalStudent
        '
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
        Me.TxtTotalStudent.Location = New System.Drawing.Point(487, 3)
        Me.TxtTotalStudent.MaxLength = 255
        Me.TxtTotalStudent.Name = "TxtTotalStudent"
        Me.TxtTotalStudent.ReadOnly = True
        Me.TxtTotalStudent.Size = New System.Drawing.Size(100, 21)
        Me.TxtTotalStudent.TabIndex = 8
        Me.TxtTotalStudent.Text = "AgTextBox1"
        Me.TxtTotalStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblSessionProgrammeReq
        '
        Me.LblSessionProgrammeReq.AutoSize = True
        Me.LblSessionProgrammeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSessionProgrammeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSessionProgrammeReq.Location = New System.Drawing.Point(136, 54)
        Me.LblSessionProgrammeReq.Name = "LblSessionProgrammeReq"
        Me.LblSessionProgrammeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSessionProgrammeReq.TabIndex = 520
        Me.LblSessionProgrammeReq.Text = "Ä"
        '
        'TxtSessionProgramme
        '
        Me.TxtSessionProgramme.AgMandatory = True
        Me.TxtSessionProgramme.AgMasterHelp = False
        Me.TxtSessionProgramme.AgNumberLeftPlaces = 0
        Me.TxtSessionProgramme.AgNumberNegetiveAllow = False
        Me.TxtSessionProgramme.AgNumberRightPlaces = 0
        Me.TxtSessionProgramme.AgPickFromLastValue = False
        Me.TxtSessionProgramme.AgRowFilter = ""
        Me.TxtSessionProgramme.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtSessionProgramme.AgSelectedValue = Nothing
        Me.TxtSessionProgramme.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSessionProgramme.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSessionProgramme.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSessionProgramme.Location = New System.Drawing.Point(149, 47)
        Me.TxtSessionProgramme.MaxLength = 50
        Me.TxtSessionProgramme.Name = "TxtSessionProgramme"
        Me.TxtSessionProgramme.Size = New System.Drawing.Size(300, 21)
        Me.TxtSessionProgramme.TabIndex = 1
        '
        'LblSessionProgramme
        '
        Me.LblSessionProgramme.AutoSize = True
        Me.LblSessionProgramme.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgramme.Location = New System.Drawing.Point(13, 51)
        Me.LblSessionProgramme.Name = "LblSessionProgramme"
        Me.LblSessionProgramme.Size = New System.Drawing.Size(123, 13)
        Me.LblSessionProgramme.TabIndex = 519
        Me.LblSessionProgramme.Text = "Session/Programme"
        '
        'LblSessionProgrammeStreamReq
        '
        Me.LblSessionProgrammeStreamReq.AutoSize = True
        Me.LblSessionProgrammeStreamReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSessionProgrammeStreamReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSessionProgrammeStreamReq.Location = New System.Drawing.Point(136, 76)
        Me.LblSessionProgrammeStreamReq.Name = "LblSessionProgrammeStreamReq"
        Me.LblSessionProgrammeStreamReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSessionProgrammeStreamReq.TabIndex = 523
        Me.LblSessionProgrammeStreamReq.Text = "Ä"
        '
        'TxtSessionProgrammeStream
        '
        Me.TxtSessionProgrammeStream.AgMandatory = True
        Me.TxtSessionProgrammeStream.AgMasterHelp = False
        Me.TxtSessionProgrammeStream.AgNumberLeftPlaces = 0
        Me.TxtSessionProgrammeStream.AgNumberNegetiveAllow = False
        Me.TxtSessionProgrammeStream.AgNumberRightPlaces = 0
        Me.TxtSessionProgrammeStream.AgPickFromLastValue = False
        Me.TxtSessionProgrammeStream.AgRowFilter = ""
        Me.TxtSessionProgrammeStream.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtSessionProgrammeStream.AgSelectedValue = Nothing
        Me.TxtSessionProgrammeStream.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSessionProgrammeStream.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSessionProgrammeStream.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSessionProgrammeStream.Location = New System.Drawing.Point(149, 69)
        Me.TxtSessionProgrammeStream.MaxLength = 50
        Me.TxtSessionProgrammeStream.Name = "TxtSessionProgrammeStream"
        Me.TxtSessionProgrammeStream.Size = New System.Drawing.Size(300, 21)
        Me.TxtSessionProgrammeStream.TabIndex = 2
        '
        'LblSessionProgrammeStream
        '
        Me.LblSessionProgrammeStream.AutoSize = True
        Me.LblSessionProgrammeStream.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgrammeStream.Location = New System.Drawing.Point(13, 73)
        Me.LblSessionProgrammeStream.Name = "LblSessionProgrammeStream"
        Me.LblSessionProgrammeStream.Size = New System.Drawing.Size(49, 13)
        Me.LblSessionProgrammeStream.TabIndex = 522
        Me.LblSessionProgrammeStream.Text = "Stream"
        '
        'LblFromStreamYearSemesterReq
        '
        Me.LblFromStreamYearSemesterReq.AutoSize = True
        Me.LblFromStreamYearSemesterReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblFromStreamYearSemesterReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblFromStreamYearSemesterReq.Location = New System.Drawing.Point(551, 32)
        Me.LblFromStreamYearSemesterReq.Name = "LblFromStreamYearSemesterReq"
        Me.LblFromStreamYearSemesterReq.Size = New System.Drawing.Size(10, 7)
        Me.LblFromStreamYearSemesterReq.TabIndex = 526
        Me.LblFromStreamYearSemesterReq.Text = "Ä"
        '
        'TxtFromStreamYearSemester
        '
        Me.TxtFromStreamYearSemester.AgMandatory = True
        Me.TxtFromStreamYearSemester.AgMasterHelp = False
        Me.TxtFromStreamYearSemester.AgNumberLeftPlaces = 0
        Me.TxtFromStreamYearSemester.AgNumberNegetiveAllow = False
        Me.TxtFromStreamYearSemester.AgNumberRightPlaces = 0
        Me.TxtFromStreamYearSemester.AgPickFromLastValue = False
        Me.TxtFromStreamYearSemester.AgRowFilter = ""
        Me.TxtFromStreamYearSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtFromStreamYearSemester.AgSelectedValue = Nothing
        Me.TxtFromStreamYearSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFromStreamYearSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFromStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromStreamYearSemester.Location = New System.Drawing.Point(563, 25)
        Me.TxtFromStreamYearSemester.MaxLength = 50
        Me.TxtFromStreamYearSemester.Name = "TxtFromStreamYearSemester"
        Me.TxtFromStreamYearSemester.Size = New System.Drawing.Size(300, 21)
        Me.TxtFromStreamYearSemester.TabIndex = 3
        '
        'LblFromStreamYearSemester
        '
        Me.LblFromStreamYearSemester.AutoSize = True
        Me.LblFromStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFromStreamYearSemester.Location = New System.Drawing.Point(456, 29)
        Me.LblFromStreamYearSemester.Name = "LblFromStreamYearSemester"
        Me.LblFromStreamYearSemester.Size = New System.Drawing.Size(95, 13)
        Me.LblFromStreamYearSemester.TabIndex = 525
        Me.LblFromStreamYearSemester.Text = "From Semester"
        '
        'LblSelectAllReq
        '
        Me.LblSelectAllReq.AutoSize = True
        Me.LblSelectAllReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSelectAllReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSelectAllReq.Location = New System.Drawing.Point(750, 76)
        Me.LblSelectAllReq.Name = "LblSelectAllReq"
        Me.LblSelectAllReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSelectAllReq.TabIndex = 532
        Me.LblSelectAllReq.Text = "Ä"
        '
        'LblSelectAll
        '
        Me.LblSelectAll.AutoSize = True
        Me.LblSelectAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectAll.Location = New System.Drawing.Point(672, 73)
        Me.LblSelectAll.Name = "LblSelectAll"
        Me.LblSelectAll.Size = New System.Drawing.Size(60, 13)
        Me.LblSelectAll.TabIndex = 531
        Me.LblSelectAll.Text = "Select All"
        '
        'TxtSelectAll
        '
        Me.TxtSelectAll.AgMandatory = True
        Me.TxtSelectAll.AgMasterHelp = False
        Me.TxtSelectAll.AgNumberLeftPlaces = 0
        Me.TxtSelectAll.AgNumberNegetiveAllow = False
        Me.TxtSelectAll.AgNumberRightPlaces = 0
        Me.TxtSelectAll.AgPickFromLastValue = False
        Me.TxtSelectAll.AgRowFilter = ""
        Me.TxtSelectAll.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSelectAll.AgSelectedValue = Nothing
        Me.TxtSelectAll.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSelectAll.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtSelectAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectAll.Location = New System.Drawing.Point(763, 69)
        Me.TxtSelectAll.Name = "TxtSelectAll"
        Me.TxtSelectAll.Size = New System.Drawing.Size(100, 21)
        Me.TxtSelectAll.TabIndex = 6
        '
        'TxtPromotionDate
        '
        Me.TxtPromotionDate.AgMandatory = True
        Me.TxtPromotionDate.AgMasterHelp = False
        Me.TxtPromotionDate.AgNumberLeftPlaces = 0
        Me.TxtPromotionDate.AgNumberNegetiveAllow = False
        Me.TxtPromotionDate.AgNumberRightPlaces = 0
        Me.TxtPromotionDate.AgPickFromLastValue = False
        Me.TxtPromotionDate.AgRowFilter = ""
        Me.TxtPromotionDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPromotionDate.AgSelectedValue = Nothing
        Me.TxtPromotionDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPromotionDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtPromotionDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPromotionDate.Location = New System.Drawing.Point(563, 69)
        Me.TxtPromotionDate.Name = "TxtPromotionDate"
        Me.TxtPromotionDate.Size = New System.Drawing.Size(100, 21)
        Me.TxtPromotionDate.TabIndex = 5
        '
        'LblPromotionDate
        '
        Me.LblPromotionDate.AutoSize = True
        Me.LblPromotionDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPromotionDate.Location = New System.Drawing.Point(456, 73)
        Me.LblPromotionDate.Name = "LblPromotionDate"
        Me.LblPromotionDate.Size = New System.Drawing.Size(96, 13)
        Me.LblPromotionDate.TabIndex = 528
        Me.LblPromotionDate.Text = "Promotion Date"
        '
        'LblPromotionDateReq
        '
        Me.LblPromotionDateReq.AutoSize = True
        Me.LblPromotionDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblPromotionDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblPromotionDateReq.Location = New System.Drawing.Point(551, 76)
        Me.LblPromotionDateReq.Name = "LblPromotionDateReq"
        Me.LblPromotionDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblPromotionDateReq.TabIndex = 533
        Me.LblPromotionDateReq.Text = "Ä"
        '
        'LblToStreamYearSemesterReq
        '
        Me.LblToStreamYearSemesterReq.AutoSize = True
        Me.LblToStreamYearSemesterReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblToStreamYearSemesterReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblToStreamYearSemesterReq.Location = New System.Drawing.Point(551, 54)
        Me.LblToStreamYearSemesterReq.Name = "LblToStreamYearSemesterReq"
        Me.LblToStreamYearSemesterReq.Size = New System.Drawing.Size(10, 7)
        Me.LblToStreamYearSemesterReq.TabIndex = 536
        Me.LblToStreamYearSemesterReq.Text = "Ä"
        '
        'TxtToStreamYearSemester
        '
        Me.TxtToStreamYearSemester.AgMandatory = True
        Me.TxtToStreamYearSemester.AgMasterHelp = False
        Me.TxtToStreamYearSemester.AgNumberLeftPlaces = 0
        Me.TxtToStreamYearSemester.AgNumberNegetiveAllow = False
        Me.TxtToStreamYearSemester.AgNumberRightPlaces = 0
        Me.TxtToStreamYearSemester.AgPickFromLastValue = False
        Me.TxtToStreamYearSemester.AgRowFilter = ""
        Me.TxtToStreamYearSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtToStreamYearSemester.AgSelectedValue = Nothing
        Me.TxtToStreamYearSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtToStreamYearSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtToStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToStreamYearSemester.Location = New System.Drawing.Point(563, 47)
        Me.TxtToStreamYearSemester.MaxLength = 50
        Me.TxtToStreamYearSemester.Name = "TxtToStreamYearSemester"
        Me.TxtToStreamYearSemester.Size = New System.Drawing.Size(300, 21)
        Me.TxtToStreamYearSemester.TabIndex = 4
        '
        'LblToStreamYearSemester
        '
        Me.LblToStreamYearSemester.AutoSize = True
        Me.LblToStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToStreamYearSemester.Location = New System.Drawing.Point(456, 51)
        Me.LblToStreamYearSemester.Name = "LblToStreamYearSemester"
        Me.LblToStreamYearSemester.Size = New System.Drawing.Size(80, 13)
        Me.LblToStreamYearSemester.TabIndex = 535
        Me.LblToStreamYearSemester.Text = "To Semester"
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Location = New System.Drawing.Point(16, 245)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(51, 41)
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
        Me.Topctrl1.Visible = False
        '
        'BtnExit
        '
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(788, 583)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 538
        Me.BtnExit.Text = "E&xit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'BtnSave
        '
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(707, 583)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 537
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Cornsilk
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-1, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(596, 27)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Student List"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(149, 106)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(596, 28)
        Me.Panel1.TabIndex = 7
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TxtTotalStudent)
        Me.Panel2.Controls.Add(Me.LblTotalStudent)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Location = New System.Drawing.Point(149, 549)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(596, 28)
        Me.Panel2.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Cornsilk
        Me.Label1.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-1, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(596, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmStudentPromotion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 616)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.LblToStreamYearSemesterReq)
        Me.Controls.Add(Me.TxtToStreamYearSemester)
        Me.Controls.Add(Me.LblToStreamYearSemester)
        Me.Controls.Add(Me.BtnFillStudent)
        Me.Controls.Add(Me.LblPromotionDateReq)
        Me.Controls.Add(Me.LblSelectAllReq)
        Me.Controls.Add(Me.LblSelectAll)
        Me.Controls.Add(Me.TxtSelectAll)
        Me.Controls.Add(Me.LblPromotionDate)
        Me.Controls.Add(Me.TxtPromotionDate)
        Me.Controls.Add(Me.LblFromStreamYearSemesterReq)
        Me.Controls.Add(Me.TxtFromStreamYearSemester)
        Me.Controls.Add(Me.LblFromStreamYearSemester)
        Me.Controls.Add(Me.LblSessionProgrammeStreamReq)
        Me.Controls.Add(Me.TxtSessionProgrammeStream)
        Me.Controls.Add(Me.LblSessionProgrammeStream)
        Me.Controls.Add(Me.LblSessionProgrammeReq)
        Me.Controls.Add(Me.TxtSessionProgramme)
        Me.Controls.Add(Me.LblSessionProgramme)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmStudentPromotion"
        Me.Text = "Student Promotion"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel

    Private Sub FrmClassSectionSemesterAdmission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents BtnFillStudent As System.Windows.Forms.Button
    Friend WithEvents LblTotalStudent As System.Windows.Forms.Label
    Friend WithEvents TxtTotalStudent As AgControls.AgTextBox
    Friend WithEvents LblSessionProgrammeReq As System.Windows.Forms.Label
    Friend WithEvents TxtSessionProgramme As AgControls.AgTextBox
    Friend WithEvents LblSessionProgramme As System.Windows.Forms.Label
    Friend WithEvents LblSessionProgrammeStreamReq As System.Windows.Forms.Label
    Friend WithEvents TxtSessionProgrammeStream As AgControls.AgTextBox
    Friend WithEvents LblSessionProgrammeStream As System.Windows.Forms.Label
    Friend WithEvents LblFromStreamYearSemesterReq As System.Windows.Forms.Label
    Friend WithEvents TxtFromStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblFromStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents LblSelectAllReq As System.Windows.Forms.Label
    Friend WithEvents LblSelectAll As System.Windows.Forms.Label
    Friend WithEvents TxtSelectAll As AgControls.AgTextBox
    Friend WithEvents TxtPromotionDate As AgControls.AgTextBox
    Friend WithEvents LblPromotionDate As System.Windows.Forms.Label
    Friend WithEvents LblPromotionDateReq As System.Windows.Forms.Label
    Friend WithEvents LblToStreamYearSemesterReq As System.Windows.Forms.Label
    Friend WithEvents TxtToStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblToStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents BtnExit As System.Windows.Forms.Button
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
