Public Class xFrmMember
    Inherits AgTemplate.TempSubGroup

    Dim mQry$ = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
        MainTable = "Tp_Member"
        LogTable = "Tp_Member_Log"
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtStudentCode = New AgControls.AgTextBox
        Me.LblStudentCode = New System.Windows.Forms.Label
        Me.TxtMemberCardNo = New AgControls.AgTextBox
        Me.LblMemberCardNo = New System.Windows.Forms.Label
        Me.TxtFatherName = New AgControls.AgTextBox
        Me.LblFatherName = New System.Windows.Forms.Label
        Me.txtReminderRemark = New AgControls.AgTextBox
        Me.LblReminderRemark = New System.Windows.Forms.Label
        Me.TxtCardPrefix = New AgControls.AgTextBox
        Me.LblCardPrefix = New System.Windows.Forms.Label
        Me.TxtCardSrNo = New AgControls.AgTextBox
        Me.LblCardSrNo = New System.Windows.Forms.Label
        Me.TxtValidTillDate = New AgControls.AgTextBox
        Me.LblValidTillDate = New System.Windows.Forms.Label
        Me.TxtPickUpPoint = New AgControls.AgTextBox
        Me.LblPickUpPoint = New System.Windows.Forms.Label
        Me.TxtRoute = New AgControls.AgTextBox
        Me.LblRoute = New System.Windows.Forms.Label
        Me.TxtVehicle = New AgControls.AgTextBox
        Me.LblVehicle = New System.Windows.Forms.Label
        Me.TxtSeatNo = New AgControls.AgTextBox
        Me.LblSeatNo = New System.Windows.Forms.Label
        Me.TxtInActiveDate = New AgControls.AgTextBox
        Me.LblInActiveDate = New System.Windows.Forms.Label
        Me.TxtIsMemberActive = New AgControls.AgTextBox
        Me.LblIsMemberActive = New System.Windows.Forms.Label
        Me.TxtMotherName = New AgControls.AgTextBox
        Me.LblMotherName = New System.Windows.Forms.Label
        Me.LinkLblTitle = New System.Windows.Forms.LinkLabel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtMemberType = New AgControls.AgTextBox
        Me.LblMemberType = New System.Windows.Forms.Label
        Me.LblMemberTypeReq = New System.Windows.Forms.Label
        Me.TxtEmployeeCode = New AgControls.AgTextBox
        Me.LblEmployeeCode = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.TxtMemberName = New AgControls.AgTextBox
        Me.LblMemberName = New System.Windows.Forms.Label
        Me.LblMemberNameReq = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblAcGroupReq
        '
        Me.LblAcGroupReq.Location = New System.Drawing.Point(13, 318)
        Me.LblAcGroupReq.Visible = False
        '
        'LblName
        '
        Me.LblName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(713, 94)
        Me.LblName.Size = New System.Drawing.Size(89, 15)
        Me.LblName.Text = "Member Name"
        '
        'TxtDispName
        '
        Me.TxtDispName.Location = New System.Drawing.Point(771, 93)
        Me.TxtDispName.Size = New System.Drawing.Size(132, 18)
        Me.TxtDispName.TabIndex = 2
        '
        'LblManualCode
        '
        Me.LblManualCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualCode.Location = New System.Drawing.Point(201, 141)
        Me.LblManualCode.Size = New System.Drawing.Size(85, 15)
        Me.LblManualCode.Text = "Member Code"
        '
        'TxtManualCode
        '
        Me.TxtManualCode.Location = New System.Drawing.Point(329, 140)
        Me.TxtManualCode.Size = New System.Drawing.Size(132, 18)
        Me.TxtManualCode.TabIndex = 3
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.Location = New System.Drawing.Point(313, 147)
        '
        'LblNameReq
        '
        Me.LblNameReq.Location = New System.Drawing.Point(755, 100)
        '
        'TxtAdd3
        '
        Me.TxtAdd3.Location = New System.Drawing.Point(329, 240)
        Me.TxtAdd3.Size = New System.Drawing.Size(350, 18)
        Me.TxtAdd3.TabIndex = 8
        '
        'LblAddress
        '
        Me.LblAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAddress.Location = New System.Drawing.Point(201, 201)
        Me.LblAddress.Size = New System.Drawing.Size(53, 15)
        '
        'TxtAdd1
        '
        Me.TxtAdd1.Location = New System.Drawing.Point(329, 200)
        Me.TxtAdd1.Size = New System.Drawing.Size(350, 18)
        Me.TxtAdd1.TabIndex = 6
        '
        'TxtAdd2
        '
        Me.TxtAdd2.Location = New System.Drawing.Point(329, 220)
        Me.TxtAdd2.Size = New System.Drawing.Size(350, 18)
        Me.TxtAdd2.TabIndex = 7
        '
        'LblAddressReq
        '
        Me.LblAddressReq.Location = New System.Drawing.Point(313, 208)
        '
        'LblCity
        '
        Me.LblCity.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCity.Location = New System.Drawing.Point(201, 260)
        Me.LblCity.Size = New System.Drawing.Size(27, 15)
        '
        'TxtCity
        '
        Me.TxtCity.Location = New System.Drawing.Point(329, 260)
        Me.TxtCity.TabIndex = 9
        '
        'LblCityReq
        '
        Me.LblCityReq.Location = New System.Drawing.Point(313, 267)
        '
        'LblPhone
        '
        Me.LblPhone.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPhone.Location = New System.Drawing.Point(201, 280)
        Me.LblPhone.Size = New System.Drawing.Size(71, 15)
        '
        'TxtPhone
        '
        Me.TxtPhone.Location = New System.Drawing.Point(329, 280)
        Me.TxtPhone.Size = New System.Drawing.Size(350, 18)
        Me.TxtPhone.TabIndex = 11
        '
        'LblFax
        '
        Me.LblFax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFax.Location = New System.Drawing.Point(201, 300)
        Me.LblFax.Size = New System.Drawing.Size(48, 15)
        '
        'TxtFax
        '
        Me.TxtFax.Location = New System.Drawing.Point(329, 300)
        Me.TxtFax.Size = New System.Drawing.Size(350, 18)
        Me.TxtFax.TabIndex = 12
        '
        'LblEMail
        '
        Me.LblEMail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEMail.Location = New System.Drawing.Point(201, 320)
        Me.LblEMail.Size = New System.Drawing.Size(37, 15)
        '
        'TxtEMail
        '
        Me.TxtEMail.Location = New System.Drawing.Point(329, 320)
        Me.TxtEMail.Size = New System.Drawing.Size(350, 18)
        Me.TxtEMail.TabIndex = 13
        '
        'LblCountry
        '
        Me.LblCountry.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCountry.Location = New System.Drawing.Point(467, 261)
        Me.LblCountry.Size = New System.Drawing.Size(49, 15)
        '
        'TxtAcGroup
        '
        Me.TxtAcGroup.Location = New System.Drawing.Point(32, 311)
        Me.TxtAcGroup.Size = New System.Drawing.Size(64, 18)
        Me.TxtAcGroup.Visible = False
        '
        'LblAcGroup
        '
        Me.LblAcGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcGroup.Location = New System.Drawing.Point(29, 332)
        Me.LblAcGroup.Size = New System.Drawing.Size(60, 15)
        Me.LblAcGroup.Visible = False
        '
        'TxtCountry
        '
        Me.TxtCountry.Location = New System.Drawing.Point(578, 260)
        Me.TxtCountry.TabIndex = 10
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(874, 41)
        Me.Topctrl1.TabIndex = 25
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 520)
        Me.GroupBox1.Size = New System.Drawing.Size(916, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(6, 524)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(142, 524)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(556, 524)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(400, 524)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(702, 524)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(271, 524)
        '
        'TxtStudentCode
        '
        Me.TxtStudentCode.AgMandatory = False
        Me.TxtStudentCode.AgMasterHelp = False
        Me.TxtStudentCode.AgNumberLeftPlaces = 0
        Me.TxtStudentCode.AgNumberNegetiveAllow = False
        Me.TxtStudentCode.AgNumberRightPlaces = 0
        Me.TxtStudentCode.AgPickFromLastValue = False
        Me.TxtStudentCode.AgRowFilter = ""
        Me.TxtStudentCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStudentCode.AgSelectedValue = Nothing
        Me.TxtStudentCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStudentCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStudentCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStudentCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStudentCode.Location = New System.Drawing.Point(771, 55)
        Me.TxtStudentCode.MaxLength = 20
        Me.TxtStudentCode.Name = "TxtStudentCode"
        Me.TxtStudentCode.Size = New System.Drawing.Size(132, 18)
        Me.TxtStudentCode.TabIndex = 0
        '
        'LblStudentCode
        '
        Me.LblStudentCode.AutoSize = True
        Me.LblStudentCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStudentCode.Location = New System.Drawing.Point(713, 56)
        Me.LblStudentCode.Name = "LblStudentCode"
        Me.LblStudentCode.Size = New System.Drawing.Size(82, 15)
        Me.LblStudentCode.TabIndex = 871
        Me.LblStudentCode.Text = "Student Code"
        '
        'TxtMemberCardNo
        '
        Me.TxtMemberCardNo.AgMandatory = False
        Me.TxtMemberCardNo.AgMasterHelp = False
        Me.TxtMemberCardNo.AgNumberLeftPlaces = 0
        Me.TxtMemberCardNo.AgNumberNegetiveAllow = False
        Me.TxtMemberCardNo.AgNumberRightPlaces = 0
        Me.TxtMemberCardNo.AgPickFromLastValue = False
        Me.TxtMemberCardNo.AgRowFilter = ""
        Me.TxtMemberCardNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberCardNo.AgSelectedValue = Nothing
        Me.TxtMemberCardNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberCardNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMemberCardNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberCardNo.Location = New System.Drawing.Point(329, 432)
        Me.TxtMemberCardNo.MaxLength = 50
        Me.TxtMemberCardNo.Name = "TxtMemberCardNo"
        Me.TxtMemberCardNo.Size = New System.Drawing.Size(132, 18)
        Me.TxtMemberCardNo.TabIndex = 19
        '
        'LblMemberCardNo
        '
        Me.LblMemberCardNo.AutoSize = True
        Me.LblMemberCardNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberCardNo.Location = New System.Drawing.Point(201, 434)
        Me.LblMemberCardNo.Name = "LblMemberCardNo"
        Me.LblMemberCardNo.Size = New System.Drawing.Size(101, 15)
        Me.LblMemberCardNo.TabIndex = 875
        Me.LblMemberCardNo.Text = "Member Card No"
        '
        'TxtFatherName
        '
        Me.TxtFatherName.AgMandatory = False
        Me.TxtFatherName.AgMasterHelp = False
        Me.TxtFatherName.AgNumberLeftPlaces = 0
        Me.TxtFatherName.AgNumberNegetiveAllow = False
        Me.TxtFatherName.AgNumberRightPlaces = 0
        Me.TxtFatherName.AgPickFromLastValue = False
        Me.TxtFatherName.AgRowFilter = ""
        Me.TxtFatherName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFatherName.AgSelectedValue = Nothing
        Me.TxtFatherName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFatherName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFatherName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFatherName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFatherName.Location = New System.Drawing.Point(329, 160)
        Me.TxtFatherName.MaxLength = 100
        Me.TxtFatherName.Name = "TxtFatherName"
        Me.TxtFatherName.Size = New System.Drawing.Size(350, 18)
        Me.TxtFatherName.TabIndex = 4
        '
        'LblFatherName
        '
        Me.LblFatherName.AutoSize = True
        Me.LblFatherName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFatherName.Location = New System.Drawing.Point(201, 161)
        Me.LblFatherName.Name = "LblFatherName"
        Me.LblFatherName.Size = New System.Drawing.Size(79, 15)
        Me.LblFatherName.TabIndex = 877
        Me.LblFatherName.Text = "Father Name"
        '
        'txtReminderRemark
        '
        Me.txtReminderRemark.AgMandatory = False
        Me.txtReminderRemark.AgMasterHelp = True
        Me.txtReminderRemark.AgNumberLeftPlaces = 0
        Me.txtReminderRemark.AgNumberNegetiveAllow = False
        Me.txtReminderRemark.AgNumberRightPlaces = 0
        Me.txtReminderRemark.AgPickFromLastValue = False
        Me.txtReminderRemark.AgRowFilter = ""
        Me.txtReminderRemark.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.txtReminderRemark.AgSelectedValue = Nothing
        Me.txtReminderRemark.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.txtReminderRemark.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.txtReminderRemark.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtReminderRemark.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtReminderRemark.Location = New System.Drawing.Point(329, 360)
        Me.txtReminderRemark.MaxLength = 255
        Me.txtReminderRemark.Name = "txtReminderRemark"
        Me.txtReminderRemark.Size = New System.Drawing.Size(350, 18)
        Me.txtReminderRemark.TabIndex = 16
        '
        'LblReminderRemark
        '
        Me.LblReminderRemark.AutoSize = True
        Me.LblReminderRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReminderRemark.Location = New System.Drawing.Point(200, 361)
        Me.LblReminderRemark.Name = "LblReminderRemark"
        Me.LblReminderRemark.Size = New System.Drawing.Size(109, 15)
        Me.LblReminderRemark.TabIndex = 885
        Me.LblReminderRemark.Text = "Reminder Remark"
        '
        'TxtCardPrefix
        '
        Me.TxtCardPrefix.AgMandatory = False
        Me.TxtCardPrefix.AgMasterHelp = False
        Me.TxtCardPrefix.AgNumberLeftPlaces = 0
        Me.TxtCardPrefix.AgNumberNegetiveAllow = False
        Me.TxtCardPrefix.AgNumberRightPlaces = 0
        Me.TxtCardPrefix.AgPickFromLastValue = False
        Me.TxtCardPrefix.AgRowFilter = ""
        Me.TxtCardPrefix.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCardPrefix.AgSelectedValue = Nothing
        Me.TxtCardPrefix.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCardPrefix.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCardPrefix.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCardPrefix.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCardPrefix.Location = New System.Drawing.Point(329, 412)
        Me.TxtCardPrefix.MaxLength = 20
        Me.TxtCardPrefix.Name = "TxtCardPrefix"
        Me.TxtCardPrefix.Size = New System.Drawing.Size(132, 18)
        Me.TxtCardPrefix.TabIndex = 17
        '
        'LblCardPrefix
        '
        Me.LblCardPrefix.AutoSize = True
        Me.LblCardPrefix.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCardPrefix.Location = New System.Drawing.Point(201, 413)
        Me.LblCardPrefix.Name = "LblCardPrefix"
        Me.LblCardPrefix.Size = New System.Drawing.Size(67, 15)
        Me.LblCardPrefix.TabIndex = 890
        Me.LblCardPrefix.Text = "Card Prefix"
        '
        'TxtCardSrNo
        '
        Me.TxtCardSrNo.AgMandatory = False
        Me.TxtCardSrNo.AgMasterHelp = False
        Me.TxtCardSrNo.AgNumberLeftPlaces = 8
        Me.TxtCardSrNo.AgNumberNegetiveAllow = False
        Me.TxtCardSrNo.AgNumberRightPlaces = 0
        Me.TxtCardSrNo.AgPickFromLastValue = False
        Me.TxtCardSrNo.AgRowFilter = ""
        Me.TxtCardSrNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCardSrNo.AgSelectedValue = Nothing
        Me.TxtCardSrNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCardSrNo.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtCardSrNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCardSrNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCardSrNo.Location = New System.Drawing.Point(578, 412)
        Me.TxtCardSrNo.MaxLength = 20
        Me.TxtCardSrNo.Name = "TxtCardSrNo"
        Me.TxtCardSrNo.Size = New System.Drawing.Size(101, 18)
        Me.TxtCardSrNo.TabIndex = 18
        Me.TxtCardSrNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblCardSrNo
        '
        Me.LblCardSrNo.AutoSize = True
        Me.LblCardSrNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCardSrNo.Location = New System.Drawing.Point(467, 413)
        Me.LblCardSrNo.Name = "LblCardSrNo"
        Me.LblCardSrNo.Size = New System.Drawing.Size(74, 15)
        Me.LblCardSrNo.TabIndex = 893
        Me.LblCardSrNo.Text = "Card Sr. No."
        '
        'TxtValidTillDate
        '
        Me.TxtValidTillDate.AgMandatory = False
        Me.TxtValidTillDate.AgMasterHelp = False
        Me.TxtValidTillDate.AgNumberLeftPlaces = 0
        Me.TxtValidTillDate.AgNumberNegetiveAllow = False
        Me.TxtValidTillDate.AgNumberRightPlaces = 0
        Me.TxtValidTillDate.AgPickFromLastValue = False
        Me.TxtValidTillDate.AgRowFilter = ""
        Me.TxtValidTillDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtValidTillDate.AgSelectedValue = Nothing
        Me.TxtValidTillDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtValidTillDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtValidTillDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtValidTillDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtValidTillDate.Location = New System.Drawing.Point(578, 432)
        Me.TxtValidTillDate.MaxLength = 20
        Me.TxtValidTillDate.Name = "TxtValidTillDate"
        Me.TxtValidTillDate.Size = New System.Drawing.Size(101, 18)
        Me.TxtValidTillDate.TabIndex = 20
        Me.TxtValidTillDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblValidTillDate
        '
        Me.LblValidTillDate.AutoSize = True
        Me.LblValidTillDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValidTillDate.Location = New System.Drawing.Point(467, 434)
        Me.LblValidTillDate.Name = "LblValidTillDate"
        Me.LblValidTillDate.Size = New System.Drawing.Size(83, 15)
        Me.LblValidTillDate.TabIndex = 895
        Me.LblValidTillDate.Text = "Card Valid Till"
        '
        'TxtPickUpPoint
        '
        Me.TxtPickUpPoint.AgMandatory = False
        Me.TxtPickUpPoint.AgMasterHelp = False
        Me.TxtPickUpPoint.AgNumberLeftPlaces = 0
        Me.TxtPickUpPoint.AgNumberNegetiveAllow = False
        Me.TxtPickUpPoint.AgNumberRightPlaces = 0
        Me.TxtPickUpPoint.AgPickFromLastValue = False
        Me.TxtPickUpPoint.AgRowFilter = ""
        Me.TxtPickUpPoint.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPickUpPoint.AgSelectedValue = Nothing
        Me.TxtPickUpPoint.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPickUpPoint.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPickUpPoint.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPickUpPoint.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPickUpPoint.Location = New System.Drawing.Point(329, 452)
        Me.TxtPickUpPoint.MaxLength = 0
        Me.TxtPickUpPoint.Name = "TxtPickUpPoint"
        Me.TxtPickUpPoint.Size = New System.Drawing.Size(350, 18)
        Me.TxtPickUpPoint.TabIndex = 21
        '
        'LblPickUpPoint
        '
        Me.LblPickUpPoint.AutoSize = True
        Me.LblPickUpPoint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPickUpPoint.Location = New System.Drawing.Point(201, 454)
        Me.LblPickUpPoint.Name = "LblPickUpPoint"
        Me.LblPickUpPoint.Size = New System.Drawing.Size(75, 15)
        Me.LblPickUpPoint.TabIndex = 897
        Me.LblPickUpPoint.Text = "Pickup Point"
        '
        'TxtRoute
        '
        Me.TxtRoute.AgMandatory = False
        Me.TxtRoute.AgMasterHelp = False
        Me.TxtRoute.AgNumberLeftPlaces = 0
        Me.TxtRoute.AgNumberNegetiveAllow = False
        Me.TxtRoute.AgNumberRightPlaces = 0
        Me.TxtRoute.AgPickFromLastValue = False
        Me.TxtRoute.AgRowFilter = ""
        Me.TxtRoute.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRoute.AgSelectedValue = Nothing
        Me.TxtRoute.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoute.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRoute.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRoute.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoute.Location = New System.Drawing.Point(329, 472)
        Me.TxtRoute.MaxLength = 0
        Me.TxtRoute.Name = "TxtRoute"
        Me.TxtRoute.Size = New System.Drawing.Size(350, 18)
        Me.TxtRoute.TabIndex = 22
        '
        'LblRoute
        '
        Me.LblRoute.AutoSize = True
        Me.LblRoute.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoute.Location = New System.Drawing.Point(201, 474)
        Me.LblRoute.Name = "LblRoute"
        Me.LblRoute.Size = New System.Drawing.Size(40, 15)
        Me.LblRoute.TabIndex = 899
        Me.LblRoute.Text = "Route"
        '
        'TxtVehicle
        '
        Me.TxtVehicle.AgMandatory = False
        Me.TxtVehicle.AgMasterHelp = False
        Me.TxtVehicle.AgNumberLeftPlaces = 0
        Me.TxtVehicle.AgNumberNegetiveAllow = False
        Me.TxtVehicle.AgNumberRightPlaces = 0
        Me.TxtVehicle.AgPickFromLastValue = False
        Me.TxtVehicle.AgRowFilter = ""
        Me.TxtVehicle.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicle.AgSelectedValue = Nothing
        Me.TxtVehicle.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicle.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicle.Location = New System.Drawing.Point(329, 492)
        Me.TxtVehicle.MaxLength = 0
        Me.TxtVehicle.Name = "TxtVehicle"
        Me.TxtVehicle.Size = New System.Drawing.Size(132, 18)
        Me.TxtVehicle.TabIndex = 23
        '
        'LblVehicle
        '
        Me.LblVehicle.AutoSize = True
        Me.LblVehicle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVehicle.Location = New System.Drawing.Point(201, 494)
        Me.LblVehicle.Name = "LblVehicle"
        Me.LblVehicle.Size = New System.Drawing.Size(84, 15)
        Me.LblVehicle.TabIndex = 901
        Me.LblVehicle.Text = "Vehicle Name"
        '
        'TxtSeatNo
        '
        Me.TxtSeatNo.AgMandatory = False
        Me.TxtSeatNo.AgMasterHelp = False
        Me.TxtSeatNo.AgNumberLeftPlaces = 0
        Me.TxtSeatNo.AgNumberNegetiveAllow = False
        Me.TxtSeatNo.AgNumberRightPlaces = 0
        Me.TxtSeatNo.AgPickFromLastValue = False
        Me.TxtSeatNo.AgRowFilter = ""
        Me.TxtSeatNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSeatNo.AgSelectedValue = Nothing
        Me.TxtSeatNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSeatNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSeatNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSeatNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSeatNo.Location = New System.Drawing.Point(578, 492)
        Me.TxtSeatNo.MaxLength = 0
        Me.TxtSeatNo.Name = "TxtSeatNo"
        Me.TxtSeatNo.Size = New System.Drawing.Size(101, 18)
        Me.TxtSeatNo.TabIndex = 24
        '
        'LblSeatNo
        '
        Me.LblSeatNo.AutoSize = True
        Me.LblSeatNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeatNo.Location = New System.Drawing.Point(469, 494)
        Me.LblSeatNo.Name = "LblSeatNo"
        Me.LblSeatNo.Size = New System.Drawing.Size(54, 15)
        Me.LblSeatNo.TabIndex = 903
        Me.LblSeatNo.Text = "Seat No."
        '
        'TxtInActiveDate
        '
        Me.TxtInActiveDate.AgMandatory = False
        Me.TxtInActiveDate.AgMasterHelp = False
        Me.TxtInActiveDate.AgNumberLeftPlaces = 0
        Me.TxtInActiveDate.AgNumberNegetiveAllow = False
        Me.TxtInActiveDate.AgNumberRightPlaces = 0
        Me.TxtInActiveDate.AgPickFromLastValue = False
        Me.TxtInActiveDate.AgRowFilter = ""
        Me.TxtInActiveDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtInActiveDate.AgSelectedValue = Nothing
        Me.TxtInActiveDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtInActiveDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtInActiveDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtInActiveDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInActiveDate.Location = New System.Drawing.Point(578, 340)
        Me.TxtInActiveDate.MaxLength = 20
        Me.TxtInActiveDate.Name = "TxtInActiveDate"
        Me.TxtInActiveDate.Size = New System.Drawing.Size(101, 18)
        Me.TxtInActiveDate.TabIndex = 15
        Me.TxtInActiveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblInActiveDate
        '
        Me.LblInActiveDate.AutoSize = True
        Me.LblInActiveDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInActiveDate.Location = New System.Drawing.Point(469, 342)
        Me.LblInActiveDate.Name = "LblInActiveDate"
        Me.LblInActiveDate.Size = New System.Drawing.Size(77, 15)
        Me.LblInActiveDate.TabIndex = 905
        Me.LblInActiveDate.Text = "Inactive Date"
        '
        'TxtIsMemberActive
        '
        Me.TxtIsMemberActive.AgMandatory = False
        Me.TxtIsMemberActive.AgMasterHelp = False
        Me.TxtIsMemberActive.AgNumberLeftPlaces = 0
        Me.TxtIsMemberActive.AgNumberNegetiveAllow = False
        Me.TxtIsMemberActive.AgNumberRightPlaces = 0
        Me.TxtIsMemberActive.AgPickFromLastValue = False
        Me.TxtIsMemberActive.AgRowFilter = ""
        Me.TxtIsMemberActive.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsMemberActive.AgSelectedValue = Nothing
        Me.TxtIsMemberActive.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsMemberActive.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsMemberActive.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIsMemberActive.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsMemberActive.Location = New System.Drawing.Point(329, 340)
        Me.TxtIsMemberActive.MaxLength = 0
        Me.TxtIsMemberActive.Name = "TxtIsMemberActive"
        Me.TxtIsMemberActive.Size = New System.Drawing.Size(54, 18)
        Me.TxtIsMemberActive.TabIndex = 14
        '
        'LblIsMemberActive
        '
        Me.LblIsMemberActive.AutoSize = True
        Me.LblIsMemberActive.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsMemberActive.Location = New System.Drawing.Point(201, 342)
        Me.LblIsMemberActive.Name = "LblIsMemberActive"
        Me.LblIsMemberActive.Size = New System.Drawing.Size(106, 15)
        Me.LblIsMemberActive.TabIndex = 907
        Me.LblIsMemberActive.Text = "Is Member Active?"
        '
        'TxtMotherName
        '
        Me.TxtMotherName.AgMandatory = False
        Me.TxtMotherName.AgMasterHelp = False
        Me.TxtMotherName.AgNumberLeftPlaces = 0
        Me.TxtMotherName.AgNumberNegetiveAllow = False
        Me.TxtMotherName.AgNumberRightPlaces = 0
        Me.TxtMotherName.AgPickFromLastValue = False
        Me.TxtMotherName.AgRowFilter = ""
        Me.TxtMotherName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMotherName.AgSelectedValue = Nothing
        Me.TxtMotherName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMotherName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMotherName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMotherName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotherName.Location = New System.Drawing.Point(329, 180)
        Me.TxtMotherName.MaxLength = 100
        Me.TxtMotherName.Name = "TxtMotherName"
        Me.TxtMotherName.Size = New System.Drawing.Size(350, 18)
        Me.TxtMotherName.TabIndex = 5
        '
        'LblMotherName
        '
        Me.LblMotherName.AutoSize = True
        Me.LblMotherName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMotherName.Location = New System.Drawing.Point(201, 181)
        Me.LblMotherName.Name = "LblMotherName"
        Me.LblMotherName.Size = New System.Drawing.Size(81, 15)
        Me.LblMotherName.TabIndex = 909
        Me.LblMotherName.Text = "Mother Name"
        '
        'LinkLblTitle
        '
        Me.LinkLblTitle.AutoSize = True
        Me.LinkLblTitle.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLblTitle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLblTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLblTitle.LinkColor = System.Drawing.Color.White
        Me.LinkLblTitle.Location = New System.Drawing.Point(200, 387)
        Me.LinkLblTitle.Name = "LinkLblTitle"
        Me.LinkLblTitle.Size = New System.Drawing.Size(166, 18)
        Me.LinkLblTitle.TabIndex = 938
        Me.LinkLblTitle.TabStop = True
        Me.LinkLblTitle.Text = "Transport Information:"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(202, 55)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(154, 18)
        Me.LinkLabel1.TabIndex = 939
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Member Information:"
        '
        'TxtMemberType
        '
        Me.TxtMemberType.AgMandatory = True
        Me.TxtMemberType.AgMasterHelp = False
        Me.TxtMemberType.AgNumberLeftPlaces = 0
        Me.TxtMemberType.AgNumberNegetiveAllow = False
        Me.TxtMemberType.AgNumberRightPlaces = 0
        Me.TxtMemberType.AgPickFromLastValue = False
        Me.TxtMemberType.AgRowFilter = ""
        Me.TxtMemberType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberType.AgSelectedValue = Nothing
        Me.TxtMemberType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMemberType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberType.Location = New System.Drawing.Point(329, 80)
        Me.TxtMemberType.MaxLength = 0
        Me.TxtMemberType.Name = "TxtMemberType"
        Me.TxtMemberType.Size = New System.Drawing.Size(132, 18)
        Me.TxtMemberType.TabIndex = 0
        '
        'LblMemberType
        '
        Me.LblMemberType.AutoSize = True
        Me.LblMemberType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberType.Location = New System.Drawing.Point(201, 82)
        Me.LblMemberType.Name = "LblMemberType"
        Me.LblMemberType.Size = New System.Drawing.Size(81, 15)
        Me.LblMemberType.TabIndex = 941
        Me.LblMemberType.Text = "Member Type"
        '
        'LblMemberTypeReq
        '
        Me.LblMemberTypeReq.AutoSize = True
        Me.LblMemberTypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblMemberTypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMemberTypeReq.Location = New System.Drawing.Point(313, 87)
        Me.LblMemberTypeReq.Name = "LblMemberTypeReq"
        Me.LblMemberTypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblMemberTypeReq.TabIndex = 942
        Me.LblMemberTypeReq.Text = "Ä"
        '
        'TxtEmployeeCode
        '
        Me.TxtEmployeeCode.AgMandatory = False
        Me.TxtEmployeeCode.AgMasterHelp = False
        Me.TxtEmployeeCode.AgNumberLeftPlaces = 0
        Me.TxtEmployeeCode.AgNumberNegetiveAllow = False
        Me.TxtEmployeeCode.AgNumberRightPlaces = 0
        Me.TxtEmployeeCode.AgPickFromLastValue = False
        Me.TxtEmployeeCode.AgRowFilter = ""
        Me.TxtEmployeeCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEmployeeCode.AgSelectedValue = Nothing
        Me.TxtEmployeeCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEmployeeCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEmployeeCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEmployeeCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmployeeCode.Location = New System.Drawing.Point(771, 74)
        Me.TxtEmployeeCode.MaxLength = 20
        Me.TxtEmployeeCode.Name = "TxtEmployeeCode"
        Me.TxtEmployeeCode.Size = New System.Drawing.Size(132, 18)
        Me.TxtEmployeeCode.TabIndex = 943
        '
        'LblEmployeeCode
        '
        Me.LblEmployeeCode.AutoSize = True
        Me.LblEmployeeCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmployeeCode.Location = New System.Drawing.Point(713, 75)
        Me.LblEmployeeCode.Name = "LblEmployeeCode"
        Me.LblEmployeeCode.Size = New System.Drawing.Size(62, 15)
        Me.LblEmployeeCode.TabIndex = 944
        Me.LblEmployeeCode.Text = "Employee"
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
        Me.TxtStreamYearSemester.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStreamYearSemester.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(329, 100)
        Me.TxtStreamYearSemester.MaxLength = 0
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(350, 18)
        Me.TxtStreamYearSemester.TabIndex = 1
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(201, 102)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(61, 15)
        Me.LblStreamYearSemester.TabIndex = 946
        Me.LblStreamYearSemester.Text = "Semester"
        '
        'TxtMemberName
        '
        Me.TxtMemberName.AgMandatory = True
        Me.TxtMemberName.AgMasterHelp = False
        Me.TxtMemberName.AgNumberLeftPlaces = 0
        Me.TxtMemberName.AgNumberNegetiveAllow = False
        Me.TxtMemberName.AgNumberRightPlaces = 0
        Me.TxtMemberName.AgPickFromLastValue = False
        Me.TxtMemberName.AgRowFilter = ""
        Me.TxtMemberName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberName.AgSelectedValue = Nothing
        Me.TxtMemberName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMemberName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberName.Location = New System.Drawing.Point(329, 120)
        Me.TxtMemberName.MaxLength = 20
        Me.TxtMemberName.Name = "TxtMemberName"
        Me.TxtMemberName.Size = New System.Drawing.Size(350, 18)
        Me.TxtMemberName.TabIndex = 2
        '
        'LblMemberName
        '
        Me.LblMemberName.AutoSize = True
        Me.LblMemberName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberName.Location = New System.Drawing.Point(201, 122)
        Me.LblMemberName.Name = "LblMemberName"
        Me.LblMemberName.Size = New System.Drawing.Size(89, 15)
        Me.LblMemberName.TabIndex = 948
        Me.LblMemberName.Text = "Member Name"
        '
        'LblMemberNameReq
        '
        Me.LblMemberNameReq.AutoSize = True
        Me.LblMemberNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblMemberNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMemberNameReq.Location = New System.Drawing.Point(313, 126)
        Me.LblMemberNameReq.Name = "LblMemberNameReq"
        Me.LblMemberNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblMemberNameReq.TabIndex = 949
        Me.LblMemberNameReq.Text = "Ä"
        '
        'FrmMember
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(874, 568)
        Me.Controls.Add(Me.LblMemberNameReq)
        Me.Controls.Add(Me.TxtMemberName)
        Me.Controls.Add(Me.LblMemberName)
        Me.Controls.Add(Me.TxtStreamYearSemester)
        Me.Controls.Add(Me.LblStreamYearSemester)
        Me.Controls.Add(Me.TxtEmployeeCode)
        Me.Controls.Add(Me.LblEmployeeCode)
        Me.Controls.Add(Me.LblMemberTypeReq)
        Me.Controls.Add(Me.TxtMemberType)
        Me.Controls.Add(Me.LblMemberType)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.LinkLblTitle)
        Me.Controls.Add(Me.TxtMotherName)
        Me.Controls.Add(Me.LblMotherName)
        Me.Controls.Add(Me.TxtIsMemberActive)
        Me.Controls.Add(Me.LblIsMemberActive)
        Me.Controls.Add(Me.TxtInActiveDate)
        Me.Controls.Add(Me.LblInActiveDate)
        Me.Controls.Add(Me.TxtSeatNo)
        Me.Controls.Add(Me.LblSeatNo)
        Me.Controls.Add(Me.TxtVehicle)
        Me.Controls.Add(Me.LblVehicle)
        Me.Controls.Add(Me.TxtRoute)
        Me.Controls.Add(Me.LblRoute)
        Me.Controls.Add(Me.TxtPickUpPoint)
        Me.Controls.Add(Me.LblPickUpPoint)
        Me.Controls.Add(Me.TxtValidTillDate)
        Me.Controls.Add(Me.LblValidTillDate)
        Me.Controls.Add(Me.TxtCardSrNo)
        Me.Controls.Add(Me.LblCardSrNo)
        Me.Controls.Add(Me.TxtCardPrefix)
        Me.Controls.Add(Me.LblCardPrefix)
        Me.Controls.Add(Me.txtReminderRemark)
        Me.Controls.Add(Me.LblReminderRemark)
        Me.Controls.Add(Me.TxtFatherName)
        Me.Controls.Add(Me.LblFatherName)
        Me.Controls.Add(Me.TxtMemberCardNo)
        Me.Controls.Add(Me.LblMemberCardNo)
        Me.Controls.Add(Me.TxtStudentCode)
        Me.Controls.Add(Me.LblStudentCode)
        Me.LogLineTableCsv = ""
        Me.LogTableName = "SubGroup_LOG"
        Me.MainLineTableCsv = ","
        Me.MainTableName = "SubGroup"
        Me.Name = "FrmMember"
        Me.PrimaryField = "SubCode"
        Me.Text = "Member Master"
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.LblName, 0)
        Me.Controls.SetChildIndex(Me.TxtDispName, 0)
        Me.Controls.SetChildIndex(Me.LblManualCode, 0)
        Me.Controls.SetChildIndex(Me.TxtManualCode, 0)
        Me.Controls.SetChildIndex(Me.LblManualCodeReq, 0)
        Me.Controls.SetChildIndex(Me.LblNameReq, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd3, 0)
        Me.Controls.SetChildIndex(Me.LblAddress, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd1, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd2, 0)
        Me.Controls.SetChildIndex(Me.LblAddressReq, 0)
        Me.Controls.SetChildIndex(Me.LblCity, 0)
        Me.Controls.SetChildIndex(Me.TxtCity, 0)
        Me.Controls.SetChildIndex(Me.LblCityReq, 0)
        Me.Controls.SetChildIndex(Me.LblPhone, 0)
        Me.Controls.SetChildIndex(Me.TxtPhone, 0)
        Me.Controls.SetChildIndex(Me.LblFax, 0)
        Me.Controls.SetChildIndex(Me.TxtFax, 0)
        Me.Controls.SetChildIndex(Me.LblEMail, 0)
        Me.Controls.SetChildIndex(Me.TxtEMail, 0)
        Me.Controls.SetChildIndex(Me.LblCountry, 0)
        Me.Controls.SetChildIndex(Me.TxtCountry, 0)
        Me.Controls.SetChildIndex(Me.LblAcGroup, 0)
        Me.Controls.SetChildIndex(Me.TxtAcGroup, 0)
        Me.Controls.SetChildIndex(Me.LblAcGroupReq, 0)
        Me.Controls.SetChildIndex(Me.LblStudentCode, 0)
        Me.Controls.SetChildIndex(Me.TxtStudentCode, 0)
        Me.Controls.SetChildIndex(Me.LblMemberCardNo, 0)
        Me.Controls.SetChildIndex(Me.TxtMemberCardNo, 0)
        Me.Controls.SetChildIndex(Me.LblFatherName, 0)
        Me.Controls.SetChildIndex(Me.TxtFatherName, 0)
        Me.Controls.SetChildIndex(Me.LblReminderRemark, 0)
        Me.Controls.SetChildIndex(Me.txtReminderRemark, 0)
        Me.Controls.SetChildIndex(Me.LblCardPrefix, 0)
        Me.Controls.SetChildIndex(Me.TxtCardPrefix, 0)
        Me.Controls.SetChildIndex(Me.LblCardSrNo, 0)
        Me.Controls.SetChildIndex(Me.TxtCardSrNo, 0)
        Me.Controls.SetChildIndex(Me.LblValidTillDate, 0)
        Me.Controls.SetChildIndex(Me.TxtValidTillDate, 0)
        Me.Controls.SetChildIndex(Me.LblPickUpPoint, 0)
        Me.Controls.SetChildIndex(Me.TxtPickUpPoint, 0)
        Me.Controls.SetChildIndex(Me.LblRoute, 0)
        Me.Controls.SetChildIndex(Me.TxtRoute, 0)
        Me.Controls.SetChildIndex(Me.LblVehicle, 0)
        Me.Controls.SetChildIndex(Me.TxtVehicle, 0)
        Me.Controls.SetChildIndex(Me.LblSeatNo, 0)
        Me.Controls.SetChildIndex(Me.TxtSeatNo, 0)
        Me.Controls.SetChildIndex(Me.LblInActiveDate, 0)
        Me.Controls.SetChildIndex(Me.TxtInActiveDate, 0)
        Me.Controls.SetChildIndex(Me.LblIsMemberActive, 0)
        Me.Controls.SetChildIndex(Me.TxtIsMemberActive, 0)
        Me.Controls.SetChildIndex(Me.LblMotherName, 0)
        Me.Controls.SetChildIndex(Me.TxtMotherName, 0)
        Me.Controls.SetChildIndex(Me.LinkLblTitle, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.LblMemberType, 0)
        Me.Controls.SetChildIndex(Me.TxtMemberType, 0)
        Me.Controls.SetChildIndex(Me.LblMemberTypeReq, 0)
        Me.Controls.SetChildIndex(Me.LblEmployeeCode, 0)
        Me.Controls.SetChildIndex(Me.TxtEmployeeCode, 0)
        Me.Controls.SetChildIndex(Me.LblStreamYearSemester, 0)
        Me.Controls.SetChildIndex(Me.TxtStreamYearSemester, 0)
        Me.Controls.SetChildIndex(Me.LblMemberName, 0)
        Me.Controls.SetChildIndex(Me.TxtMemberName, 0)
        Me.Controls.SetChildIndex(Me.LblMemberNameReq, 0)
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents TxtStudentCode As AgControls.AgTextBox
    Protected WithEvents LblStudentCode As System.Windows.Forms.Label
    Protected WithEvents TxtMemberCardNo As AgControls.AgTextBox
    Protected WithEvents LblMemberCardNo As System.Windows.Forms.Label
    Protected WithEvents TxtFatherName As AgControls.AgTextBox
    Protected WithEvents LblFatherName As System.Windows.Forms.Label
    Protected WithEvents txtReminderRemark As AgControls.AgTextBox
    Protected WithEvents LblReminderRemark As System.Windows.Forms.Label
    Protected WithEvents TxtCardPrefix As AgControls.AgTextBox
    Protected WithEvents LblCardPrefix As System.Windows.Forms.Label
    Protected WithEvents TxtCardSrNo As AgControls.AgTextBox
    Protected WithEvents TxtValidTillDate As AgControls.AgTextBox
    Protected WithEvents LblValidTillDate As System.Windows.Forms.Label
    Protected WithEvents TxtPickUpPoint As AgControls.AgTextBox
    Protected WithEvents LblPickUpPoint As System.Windows.Forms.Label
    Protected WithEvents TxtRoute As AgControls.AgTextBox
    Protected WithEvents LblRoute As System.Windows.Forms.Label
    Protected WithEvents TxtVehicle As AgControls.AgTextBox
    Protected WithEvents LblVehicle As System.Windows.Forms.Label
    Protected WithEvents TxtSeatNo As AgControls.AgTextBox
    Protected WithEvents LblSeatNo As System.Windows.Forms.Label
    Protected WithEvents TxtInActiveDate As AgControls.AgTextBox
    Protected WithEvents LblInActiveDate As System.Windows.Forms.Label
    Protected WithEvents TxtIsMemberActive As AgControls.AgTextBox
    Protected WithEvents LblIsMemberActive As System.Windows.Forms.Label
    Protected WithEvents TxtMotherName As AgControls.AgTextBox
    Protected WithEvents LblMotherName As System.Windows.Forms.Label
    Friend WithEvents LinkLblTitle As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents TxtMemberType As AgControls.AgTextBox
    Protected WithEvents LblMemberType As System.Windows.Forms.Label
    Friend WithEvents LblMemberTypeReq As System.Windows.Forms.Label
    Protected WithEvents TxtEmployeeCode As AgControls.AgTextBox
    Protected WithEvents LblEmployeeCode As System.Windows.Forms.Label
    Protected WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Protected WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Protected WithEvents TxtMemberName As AgControls.AgTextBox
    Protected WithEvents LblMemberName As System.Windows.Forms.Label
    Friend WithEvents LblMemberNameReq As System.Windows.Forms.Label
    Protected WithEvents LblCardSrNo As System.Windows.Forms.Label
#End Region

    Private Sub FrmMember_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgL.RequiredField(TxtMemberCardNo, LblMemberCardNo.Text) Then passed = False : Exit Sub
        If Not AgL.IsValid_EMailId(TxtEMail, "Email ID") Then passed = False : Exit Sub

        If TxtInActiveDate.Text.Trim = "" Then
            TxtIsMemberActive.Text = "Yes"
        Else
            If AgL.StrCmp(TxtIsMemberActive.Text, "Yes") Then
                MsgBox("Check Member Active Detail!...")
                TxtIsMemberActive.Focus() : passed = False : Exit Sub
            End If
        End If
    End Sub

    Private Sub FrmShade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 600, 880, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmEmployee_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select M.*,SG.FatherName, SG.MotherName " & _
                " From Tp_Member M " & _
                " LEFT JOIN SubGroup_Log SG ON SG.SubCode=M.SubCode " & _
                " Where M.SubCode ='" & SearchCode & "'"
        Else
            mQry = "Select M.* ,SG.FatherName, SG.MotherName " & _
                " From Tp_Member_Log M " & _
                " LEFT JOIN SubGroup_Log SG ON SG.UID=M.UID " & _
                " Where M.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtStudentCode.Text = AgL.XNull(.Rows(0)("Student"))
                TxtEmployeeCode.Text = AgL.XNull(.Rows(0)("Employee"))
                TxtMemberName.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))

                If AgL.XNull(.Rows(0)("Student")).ToString.Trim <> "" Then
                    TxtMemberType.Text = ClsMain.MemberType.Student
                ElseIf AgL.XNull(.Rows(0)("Employee")).ToString.Trim <> "" Then
                    TxtMemberType.Text = ClsMain.MemberType.Employee
                End If

                TxtMemberCardNo.Text = AgL.XNull(.Rows(0)("MemberCardNo"))
                TxtFatherName.Text = AgL.XNull(.Rows(0)("FatherName"))
                TxtMotherName.Text = AgL.XNull(.Rows(0)("MotherName"))


                TxtMemberCardNo.Text = AgL.XNull(.Rows(0)("MemberCardNo"))
                TxtCardPrefix.Text = AgL.XNull(.Rows(0)("CardPrefix"))
                TxtCardSrNo.Text = AgL.VNull(.Rows(0)("CardSrNo"))
                TxtValidTillDate.Text = Format(AgL.XNull(.Rows(0)("ValidTillDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                TxtVehicle.AgSelectedValue = AgL.XNull(.Rows(0)("Vehicle"))
                TxtSeatNo.Text = AgL.XNull(.Rows(0)("SeatNo"))
                TxtRoute.AgSelectedValue = AgL.XNull(.Rows(0)("Route"))
                TxtPickUpPoint.AgSelectedValue = AgL.XNull(.Rows(0)("PickUpPoint"))
                txtReminderRemark.Text = AgL.XNull(.Rows(0)("ReminderRemark"))
                TxtInActiveDate.Text = Format(AgL.XNull(.Rows(0)("InActiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                TxtIsMemberActive.Text = IIf(AgL.XNull(.Rows(0)("InActiveDate")).ToString.Trim = "", "Yes", "No")
            End If
        End With
    End Sub

    Private Sub FrmEmployee_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        If AgL.VNull(DtTp_Enviro.Rows(0)("IsLinkWithAcademic")) <> 0 Then
            mQry = " SELECT H.Subcode AS Code, SG.DispName AS Name, SG.ManualCode, " & _
                    " '" & ClsMain.MemberType.Student & "' As [Member Type], " & _
                    " SG.FatherName, Sg.MotherName, SG.Add1,SG.Add2,SG.Add3,SG.CityCode,SG.CountryCode, " & _
                    " SG.Mobile, SG.FAX, SG.EMail, vA.FromStreamYearSemester As CurrentSemester " & _
                    " FROM Sch_Student H  " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode=H.SubCode  " & _
                    " Left Join (SELECT A.Student, P.FromStreamYearSemester, A.V_Date AS AdmissionDate, A.LeavingDate " & _
                    " FROM Sch_Admission A " & _
                    " INNER JOIN (SELECT Ap.* FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) AS P ON A.DocId = P.AdmissionDocId " & _
                    " ) As vA On vA.Student = H.SubCode " & _
                    " UNION ALL " & _
                    " SELECT H.Subcode AS Code, SG.DispName AS Name, SG.ManualCode, " & _
                    " '" & ClsMain.MemberType.Employee & "' As [Member Type], " & _
                    " SG.FatherName, Sg.MotherName, SG.Add1,SG.Add2,SG.Add3,SG.CityCode,SG.CountryCode, " & _
                    " SG.Mobile, SG.FAX, SG.EMail, '' As CurrentSemester " & _
                    " FROM Pay_Employee H  " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode=H.SubCode  "
            TxtMemberName.AgHelpDataSet(12) = AgL.FillData(mQry, AgL.GCn)
        Else
            mQry = " SELECT H.Subcode AS Code, SG.DispName AS Name, SG.ManualCode, " & _
                    " '" & ClsMain.MemberType.Student & "' As [Member Type], " & _
                    " SG.FatherName, Sg.MotherName, SG.Add1,SG.Add2,SG.Add3,SG.CityCode,SG.CountryCode, " & _
                    " SG.Mobile, SG.FAX, SG.EMail, '' As CurrentSemester " & _
                    " FROM Tp_Member H  " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode=H.SubCode  " & _
                    " "
            TxtMemberName.AgHelpDataSet(12) = AgL.FillData(mQry, AgL.GCn)
        End If

        mQry = " Select '" & ClsMain.MemberType.Student & "' As Code, '" & ClsMain.MemberType.Student & "' As Name " & _
                " Union All " & _
                " Select '" & ClsMain.MemberType.Employee & "' As Code, '" & ClsMain.MemberType.Employee & "' As Name "
        TxtMemberType.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select V.Code  As Code, V.RegistrationNo As [Vehicle No], V.Description As [Vehicle Name] " & _
                " From Tp_Vehicle V " & _
                " Order By V.RegistrationNo "
        TxtVehicle.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT R.Code, R.Description AS Name FROM Sch_Route R ORDER BY R.Description "
        TxtRoute.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select S.Code  As Code, S.Description As Name, S.ManualCode As [Short Name] " & _
                " From Sch_Area S " & _
                " Order By S.ManualCode "
        TxtPickUpPoint.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.Code, S.StreamYearSemesterDesc AS Name, " & _
                " S.StreamCode, S.Semester, S.SessionCode, S.ProgrammeCode, S.YearSerial " & _
                " FROM ViewSch_StreamYearSemester S With (NoLock) " & _
                " Order By S.StreamYearSemesterDesc "
        TxtStreamYearSemester.AgHelpDataSet(5) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmEmployee_BaseEvent_Save_SubGroupInTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_SubGroupInTrans
        mQry = " UPDATE SubGroup_Log SET " & _
                " FatherName = " & AgL.Chk_Text(TxtFatherName.Text) & ", " & _
                " MotherName = " & AgL.Chk_Text(TxtMotherName.Text) & " " & _
                " WHERE UID = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " UPDATE dbo.Tp_Member_Log " & _
                " SET " & _
                " Student = " & AgL.Chk_Text(TxtStudentCode.Text) & ", " & _
                " Employee = " & AgL.Chk_Text(TxtEmployeeCode.Text) & ", " & _
                " MemberCardNo = " & AgL.Chk_Text(TxtMemberCardNo.Text) & ", " & _
                " CardPrefix = " & AgL.Chk_Text(TxtCardPrefix.Text) & ", " & _
                " CardSrNo = " & AgL.Chk_Text(TxtCardSrNo.Text) & ", " & _
                " ValidTillDate = " & AgL.ConvertDate(TxtValidTillDate.Text) & ", " & _
                " Vehicle = " & AgL.Chk_Text(TxtVehicle.AgSelectedValue) & ", " & _
                " SeatNo = " & AgL.Chk_Text(TxtSeatNo.Text) & ", " & _
                " Route = " & AgL.Chk_Text(TxtRoute.AgSelectedValue) & ", " & _
                " PickUpPoint = " & AgL.Chk_Text(TxtPickUpPoint.AgSelectedValue) & ", " & _
                " InActiveDate = " & AgL.Chk_Text(TxtInActiveDate.Text) & ", " & _
                " ReminderRemark = " & AgL.Chk_Text(txtReminderRemark.Text) & " " & _
                " WHERE UID = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtManualCode.Enter, TxtMemberName.Enter, TxtMemberName.Enter

        Dim bStrFilter$ = ""
        Try
            Select Case sender.name
                Case TxtMemberName.Name
                    bStrFilter = " 1=1 "
                    bStrFilter += " And [Member Type] = " & AgL.Chk_Text(TxtMemberType.Text) & " "

                    If AgL.StrCmp(TxtMemberType.Text, ClsMain.MemberType.Student) Then
                        bStrFilter += " And CurrentSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "
                    End If

                    sender.AgRowFilter = bStrFilter
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtStudentCode.Validating, TxtFatherName.Validating, TxtMotherName.Validating, TxtIsMemberActive.Validating, _
        TxtInActiveDate.Validating, TxtRoute.Validating, TxtPickUpPoint.Validating, TxtVehicle.Validating, TxtSeatNo.Validating, _
        TxtCardPrefix.Validating, TxtCardSrNo.Validating, TxtMemberCardNo.Validating, txtReminderRemark.Validating, _
        TxtMemberName.Validating, TxtStreamYearSemester.Validating, TxtMemberType.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtMemberCardNo.Name, TxtCardPrefix.Name, TxtCardSrNo.Name
                    TxtMemberCardNo.Text = TxtCardPrefix.Text + "-" + TxtCardSrNo.Text

                Case TxtMemberName.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        sender.AgSelectedValue = ""
                        TxtManualCode.Text = ""
                        TxtDispName.Text = ""
                        TxtFatherName.Text = ""
                        TxtMotherName.Text = ""
                        TxtAdd1.Text = ""
                        TxtAdd2.Text = ""
                        TxtAdd3.Text = ""
                        TxtCity.AgSelectedValue = ""
                        TxtEMail.Text = ""
                        TxtFax.Text = ""
                        TxtPhone.Text = ""

                        TxtEmployeeCode.Text = ""
                        TxtStudentCode.Text = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtManualCode.Text = AgL.XNull(DrTemp(0)("ManualCode"))
                            TxtDispName.Text = AgL.XNull(DrTemp(0)("Name"))
                            TxtFatherName.Text = AgL.XNull(DrTemp(0)("FatherName"))
                            TxtMotherName.Text = AgL.XNull(DrTemp(0)("MotherName"))
                            TxtAdd1.Text = AgL.XNull(DrTemp(0)("Add1"))
                            TxtAdd2.Text = AgL.XNull(DrTemp(0)("Add2"))
                            TxtAdd3.Text = AgL.XNull(DrTemp(0)("Add3"))
                            TxtCity.AgSelectedValue = AgL.XNull(DrTemp(0)("CityCode"))
                            TxtEMail.Text = AgL.XNull(DrTemp(0)("EMail"))
                            TxtFax.Text = AgL.XNull(DrTemp(0)("FAX"))
                            TxtPhone.Text = AgL.XNull(DrTemp(0)("Mobile"))


                            If AgL.StrCmp(AgL.XNull(DrTemp(0)("Member Type")), ClsMain.MemberType.Employee) Then
                                TxtEmployeeCode.Text = TxtMemberName.AgSelectedValue
                                TxtStudentCode.Text = ""

                            ElseIf AgL.StrCmp(AgL.XNull(DrTemp(0)("Member Type")), ClsMain.MemberType.Student) Then
                                TxtEmployeeCode.Text = ""
                                TxtStudentCode.Text = TxtMemberName.AgSelectedValue

                            Else
                                TxtEmployeeCode.Text = ""
                                TxtStudentCode.Text = ""
                            End If
                        End If
                    End If
            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmMember_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = " WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "SG.Div_Code") & "  And IsNull(SG.IsDeleted,0) = 0 "
        AgL.PubFindQry = " SELECT M.UID AS SearchCode, SG.DispName AS [Member Name], " & _
                    " M.MemberCardNo AS [Member Card No.],SG.FatherName " & _
                    " FROM Tp_Member_Log M " & _
                    " LEFT JOIN SubGroup_Log SG ON SG.UID=M.UID  " & mConStr & _
                    " And SG.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Member Name]"
    End Sub

    Private Sub FrmMember_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = " WHERE 1=1  " & AgL.RetDivisionCondition(AgL, "SG.Div_Code") & "  And IsNull(Sg.IsDeleted,0) = 0  "
        AgL.PubFindQry = " SELECT M.SubCode AS SearchCode,SG.DispName AS [Member Name], " & _
                    " M.MemberCardNo AS [Member Card No.],SG.FatherName " & _
                    " FROM Tp_Member M " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=M.SubCode  " & mConStr
        AgL.PubFindQryOrdBy = "[Member Name]"
    End Sub

    Private Sub FrmMember_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        If DtTp_Enviro.Rows.Count > 0 Then
            TxtAcGroup.AgSelectedValue = AgL.XNull(DtTp_Enviro.Rows(0)("MemberACGroup"))
        End If
    End Sub

    Private Sub FrmMember_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtMemberCardNo.Enabled = False

        If DtTp_Enviro.Rows.Count > 0 Then
            If AgL.VNull(DtTp_Enviro.Rows(0)("IsLinkWithAcademic")) = 0 Then
                TxtStudentCode.Visible = False
                LblStudentCode.Visible = False
            End If
        End If
    End Sub

    Private Sub FrmMember_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtMemberType.Focus()
    End Sub
End Class
