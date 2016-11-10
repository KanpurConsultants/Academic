Public Class FrmBuyerMaster
    Inherits AgTemplate.TempMaster
    Dim mQry$ = ""
    Dim mGroupNature As String = "", mNature As String = "", mSubGroupType As String = ""
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents LblMemberNameReq As System.Windows.Forms.Label
    Protected WithEvents TxtMemberName As AgControls.AgTextBox
    Protected WithEvents LblMemberName As System.Windows.Forms.Label
    Protected WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Protected WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents LblMemberTypeReq As System.Windows.Forms.Label
    Protected WithEvents TxtMemberType As AgControls.AgTextBox
    Protected WithEvents LblMemberType As System.Windows.Forms.Label
    Protected WithEvents TxtEmployeeCode As AgControls.AgTextBox
    Protected WithEvents LblEmployeeCode As System.Windows.Forms.Label
    Protected WithEvents TxtStudentCode As AgControls.AgTextBox
    Protected WithEvents LblStudentCode As System.Windows.Forms.Label
    Protected WithEvents TxtMotherName As AgControls.AgTextBox
    Protected WithEvents LblMotherName As System.Windows.Forms.Label
    Protected WithEvents TxtFatherName As AgControls.AgTextBox
    Protected WithEvents LblFatherName As System.Windows.Forms.Label
    Protected WithEvents TxtIsMemberActive As AgControls.AgTextBox
    Protected WithEvents LblIsMemberActive As System.Windows.Forms.Label
    Protected WithEvents TxtInActiveDate As AgControls.AgTextBox
    Protected WithEvents LblInActiveDate As System.Windows.Forms.Label
    Protected WithEvents txtReminderRemark As AgControls.AgTextBox
    Protected WithEvents LblReminderRemark As System.Windows.Forms.Label
    Friend WithEvents LinkLblTitle As System.Windows.Forms.LinkLabel
    Protected WithEvents TxtSeatNo As AgControls.AgTextBox
    Protected WithEvents LblSeatNo As System.Windows.Forms.Label
    Protected WithEvents TxtVehicle As AgControls.AgTextBox
    Protected WithEvents LblVehicle As System.Windows.Forms.Label
    Protected WithEvents TxtRoute As AgControls.AgTextBox
    Protected WithEvents LblRoute As System.Windows.Forms.Label
    Protected WithEvents TxtPickUpPoint As AgControls.AgTextBox
    Protected WithEvents LblPickUpPoint As System.Windows.Forms.Label
    Protected WithEvents TxtValidTillDate As AgControls.AgTextBox
    Protected WithEvents LblValidTillDate As System.Windows.Forms.Label
    Protected WithEvents TxtCardSrNo As AgControls.AgTextBox
    Protected WithEvents LblCardSrNo As System.Windows.Forms.Label
    Protected WithEvents TxtCardPrefix As AgControls.AgTextBox
    Protected WithEvents LblCardPrefix As System.Windows.Forms.Label
    Protected WithEvents TxtMemberCardNo As AgControls.AgTextBox
    Protected WithEvents LblMemberCardNo As System.Windows.Forms.Label

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtEMail = New AgControls.AgTextBox
        Me.LblBuyerEMail = New System.Windows.Forms.Label
        Me.TxtFax = New AgControls.AgTextBox
        Me.LblBuyerFax = New System.Windows.Forms.Label
        Me.TxtPhone = New AgControls.AgTextBox
        Me.LblPhone = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtCity = New AgControls.AgTextBox
        Me.LblBuyerCity = New System.Windows.Forms.Label
        Me.LblBuyerAddressReq = New System.Windows.Forms.Label
        Me.TxtAdd2 = New AgControls.AgTextBox
        Me.TxtAdd1 = New AgControls.AgTextBox
        Me.LblBuyerAddress = New System.Windows.Forms.Label
        Me.TxtAdd3 = New AgControls.AgTextBox
        Me.LblBuyerNameReq = New System.Windows.Forms.Label
        Me.LblManualCodeReq = New System.Windows.Forms.Label
        Me.TxtManualCode = New AgControls.AgTextBox
        Me.LblManualCode = New System.Windows.Forms.Label
        Me.TxtDispName = New AgControls.AgTextBox
        Me.LblBuyerName = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtAcGroup = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LblMemberNameReq = New System.Windows.Forms.Label
        Me.TxtMemberName = New AgControls.AgTextBox
        Me.LblMemberName = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.LblMemberTypeReq = New System.Windows.Forms.Label
        Me.TxtMemberType = New AgControls.AgTextBox
        Me.LblMemberType = New System.Windows.Forms.Label
        Me.TxtEmployeeCode = New AgControls.AgTextBox
        Me.LblEmployeeCode = New System.Windows.Forms.Label
        Me.TxtStudentCode = New AgControls.AgTextBox
        Me.LblStudentCode = New System.Windows.Forms.Label
        Me.TxtMotherName = New AgControls.AgTextBox
        Me.LblMotherName = New System.Windows.Forms.Label
        Me.TxtFatherName = New AgControls.AgTextBox
        Me.LblFatherName = New System.Windows.Forms.Label
        Me.TxtIsMemberActive = New AgControls.AgTextBox
        Me.LblIsMemberActive = New System.Windows.Forms.Label
        Me.TxtInActiveDate = New AgControls.AgTextBox
        Me.LblInActiveDate = New System.Windows.Forms.Label
        Me.txtReminderRemark = New AgControls.AgTextBox
        Me.LblReminderRemark = New System.Windows.Forms.Label
        Me.LinkLblTitle = New System.Windows.Forms.LinkLabel
        Me.TxtSeatNo = New AgControls.AgTextBox
        Me.LblSeatNo = New System.Windows.Forms.Label
        Me.TxtVehicle = New AgControls.AgTextBox
        Me.LblVehicle = New System.Windows.Forms.Label
        Me.TxtRoute = New AgControls.AgTextBox
        Me.LblRoute = New System.Windows.Forms.Label
        Me.TxtPickUpPoint = New AgControls.AgTextBox
        Me.LblPickUpPoint = New System.Windows.Forms.Label
        Me.TxtValidTillDate = New AgControls.AgTextBox
        Me.LblValidTillDate = New System.Windows.Forms.Label
        Me.TxtCardSrNo = New AgControls.AgTextBox
        Me.LblCardSrNo = New System.Windows.Forms.Label
        Me.TxtCardPrefix = New AgControls.AgTextBox
        Me.LblCardPrefix = New System.Windows.Forms.Label
        Me.TxtMemberCardNo = New AgControls.AgTextBox
        Me.LblMemberCardNo = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(907, 41)
        Me.Topctrl1.TabIndex = 23
        Me.Topctrl1.tAdd = False
        Me.Topctrl1.tDel = False
        Me.Topctrl1.tEdit = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 438)
        Me.GroupBox1.Size = New System.Drawing.Size(949, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(6, 442)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(142, 442)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(556, 442)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 23)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(133, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(400, 442)
        Me.GBoxApprove.Size = New System.Drawing.Size(147, 44)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Size = New System.Drawing.Size(89, 18)
        Me.TxtApproveBy.Tag = ""
        '
        'CmdDiscard
        '
        Me.CmdDiscard.Location = New System.Drawing.Point(118, 18)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(702, 442)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(271, 442)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Tag = ""
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Tag = ""
        '
        'TxtEMail
        '
        Me.TxtEMail.AgMandatory = False
        Me.TxtEMail.AgMasterHelp = False
        Me.TxtEMail.AgNumberLeftPlaces = 0
        Me.TxtEMail.AgNumberNegetiveAllow = False
        Me.TxtEMail.AgNumberRightPlaces = 0
        Me.TxtEMail.AgPickFromLastValue = False
        Me.TxtEMail.AgRowFilter = ""
        Me.TxtEMail.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEMail.AgSelectedValue = Nothing
        Me.TxtEMail.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEMail.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEMail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEMail.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEMail.Location = New System.Drawing.Point(145, 299)
        Me.TxtEMail.MaxLength = 100
        Me.TxtEMail.Name = "TxtEMail"
        Me.TxtEMail.Size = New System.Drawing.Size(292, 18)
        Me.TxtEMail.TabIndex = 11
        '
        'LblBuyerEMail
        '
        Me.LblBuyerEMail.AutoSize = True
        Me.LblBuyerEMail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerEMail.Location = New System.Drawing.Point(16, 299)
        Me.LblBuyerEMail.Name = "LblBuyerEMail"
        Me.LblBuyerEMail.Size = New System.Drawing.Size(37, 15)
        Me.LblBuyerEMail.TabIndex = 799
        Me.LblBuyerEMail.Text = "EMail"
        '
        'TxtFax
        '
        Me.TxtFax.AgMandatory = False
        Me.TxtFax.AgMasterHelp = False
        Me.TxtFax.AgNumberLeftPlaces = 0
        Me.TxtFax.AgNumberNegetiveAllow = False
        Me.TxtFax.AgNumberRightPlaces = 0
        Me.TxtFax.AgPickFromLastValue = False
        Me.TxtFax.AgRowFilter = ""
        Me.TxtFax.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFax.AgSelectedValue = Nothing
        Me.TxtFax.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFax.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFax.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFax.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFax.Location = New System.Drawing.Point(145, 279)
        Me.TxtFax.MaxLength = 35
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(292, 18)
        Me.TxtFax.TabIndex = 10
        '
        'LblBuyerFax
        '
        Me.LblBuyerFax.AutoSize = True
        Me.LblBuyerFax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerFax.Location = New System.Drawing.Point(16, 279)
        Me.LblBuyerFax.Name = "LblBuyerFax"
        Me.LblBuyerFax.Size = New System.Drawing.Size(48, 15)
        Me.LblBuyerFax.TabIndex = 796
        Me.LblBuyerFax.Text = "Fax No,"
        '
        'TxtPhone
        '
        Me.TxtPhone.AgMandatory = False
        Me.TxtPhone.AgMasterHelp = False
        Me.TxtPhone.AgNumberLeftPlaces = 0
        Me.TxtPhone.AgNumberNegetiveAllow = False
        Me.TxtPhone.AgNumberRightPlaces = 0
        Me.TxtPhone.AgPickFromLastValue = False
        Me.TxtPhone.AgRowFilter = ""
        Me.TxtPhone.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPhone.AgSelectedValue = Nothing
        Me.TxtPhone.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPhone.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPhone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPhone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPhone.Location = New System.Drawing.Point(145, 259)
        Me.TxtPhone.MaxLength = 35
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(292, 18)
        Me.TxtPhone.TabIndex = 9
        '
        'LblPhone
        '
        Me.LblPhone.AutoSize = True
        Me.LblPhone.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPhone.Location = New System.Drawing.Point(16, 259)
        Me.LblPhone.Name = "LblPhone"
        Me.LblPhone.Size = New System.Drawing.Size(71, 15)
        Me.LblPhone.TabIndex = 793
        Me.LblPhone.Text = "Contact No."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(131, 246)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 7)
        Me.Label13.TabIndex = 791
        Me.Label13.Text = "Ä"
        '
        'TxtCity
        '
        Me.TxtCity.AgMandatory = True
        Me.TxtCity.AgMasterHelp = False
        Me.TxtCity.AgNumberLeftPlaces = 0
        Me.TxtCity.AgNumberNegetiveAllow = False
        Me.TxtCity.AgNumberRightPlaces = 0
        Me.TxtCity.AgPickFromLastValue = False
        Me.TxtCity.AgRowFilter = ""
        Me.TxtCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCity.AgSelectedValue = Nothing
        Me.TxtCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCity.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCity.Location = New System.Drawing.Point(145, 239)
        Me.TxtCity.MaxLength = 0
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(292, 18)
        Me.TxtCity.TabIndex = 8
        '
        'LblBuyerCity
        '
        Me.LblBuyerCity.AutoSize = True
        Me.LblBuyerCity.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerCity.Location = New System.Drawing.Point(16, 239)
        Me.LblBuyerCity.Name = "LblBuyerCity"
        Me.LblBuyerCity.Size = New System.Drawing.Size(27, 15)
        Me.LblBuyerCity.TabIndex = 790
        Me.LblBuyerCity.Text = "City"
        '
        'LblBuyerAddressReq
        '
        Me.LblBuyerAddressReq.AutoSize = True
        Me.LblBuyerAddressReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBuyerAddressReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBuyerAddressReq.Location = New System.Drawing.Point(130, 205)
        Me.LblBuyerAddressReq.Name = "LblBuyerAddressReq"
        Me.LblBuyerAddressReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBuyerAddressReq.TabIndex = 785
        Me.LblBuyerAddressReq.Text = "Ä"
        '
        'TxtAdd2
        '
        Me.TxtAdd2.AgMandatory = False
        Me.TxtAdd2.AgMasterHelp = True
        Me.TxtAdd2.AgNumberLeftPlaces = 8
        Me.TxtAdd2.AgNumberNegetiveAllow = False
        Me.TxtAdd2.AgNumberRightPlaces = 2
        Me.TxtAdd2.AgPickFromLastValue = False
        Me.TxtAdd2.AgRowFilter = ""
        Me.TxtAdd2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdd2.AgSelectedValue = Nothing
        Me.TxtAdd2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdd2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd2.Location = New System.Drawing.Point(145, 219)
        Me.TxtAdd2.MaxLength = 50
        Me.TxtAdd2.Name = "TxtAdd2"
        Me.TxtAdd2.Size = New System.Drawing.Size(292, 18)
        Me.TxtAdd2.TabIndex = 7
        '
        'TxtAdd1
        '
        Me.TxtAdd1.AgMandatory = True
        Me.TxtAdd1.AgMasterHelp = True
        Me.TxtAdd1.AgNumberLeftPlaces = 8
        Me.TxtAdd1.AgNumberNegetiveAllow = False
        Me.TxtAdd1.AgNumberRightPlaces = 2
        Me.TxtAdd1.AgPickFromLastValue = False
        Me.TxtAdd1.AgRowFilter = ""
        Me.TxtAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdd1.AgSelectedValue = Nothing
        Me.TxtAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd1.Location = New System.Drawing.Point(145, 199)
        Me.TxtAdd1.MaxLength = 50
        Me.TxtAdd1.Name = "TxtAdd1"
        Me.TxtAdd1.Size = New System.Drawing.Size(292, 18)
        Me.TxtAdd1.TabIndex = 6
        '
        'LblBuyerAddress
        '
        Me.LblBuyerAddress.AutoSize = True
        Me.LblBuyerAddress.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerAddress.Location = New System.Drawing.Point(16, 201)
        Me.LblBuyerAddress.Name = "LblBuyerAddress"
        Me.LblBuyerAddress.Size = New System.Drawing.Size(53, 15)
        Me.LblBuyerAddress.TabIndex = 784
        Me.LblBuyerAddress.Text = "Address"
        '
        'TxtAdd3
        '
        Me.TxtAdd3.AgMandatory = False
        Me.TxtAdd3.AgMasterHelp = True
        Me.TxtAdd3.AgNumberLeftPlaces = 8
        Me.TxtAdd3.AgNumberNegetiveAllow = False
        Me.TxtAdd3.AgNumberRightPlaces = 3
        Me.TxtAdd3.AgPickFromLastValue = False
        Me.TxtAdd3.AgRowFilter = ""
        Me.TxtAdd3.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdd3.AgSelectedValue = Nothing
        Me.TxtAdd3.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdd3.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdd3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd3.Location = New System.Drawing.Point(763, 275)
        Me.TxtAdd3.MaxLength = 50
        Me.TxtAdd3.Name = "TxtAdd3"
        Me.TxtAdd3.Size = New System.Drawing.Size(132, 18)
        Me.TxtAdd3.TabIndex = 5
        Me.TxtAdd3.Text = "Address3"
        Me.TxtAdd3.Visible = False
        '
        'LblBuyerNameReq
        '
        Me.LblBuyerNameReq.AutoSize = True
        Me.LblBuyerNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBuyerNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBuyerNameReq.Location = New System.Drawing.Point(748, 220)
        Me.LblBuyerNameReq.Name = "LblBuyerNameReq"
        Me.LblBuyerNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBuyerNameReq.TabIndex = 781
        Me.LblBuyerNameReq.Text = "Ä"
        Me.LblBuyerNameReq.Visible = False
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.AutoSize = True
        Me.LblManualCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblManualCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblManualCodeReq.Location = New System.Drawing.Point(130, 146)
        Me.LblManualCodeReq.Name = "LblManualCodeReq"
        Me.LblManualCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblManualCodeReq.TabIndex = 778
        Me.LblManualCodeReq.Text = "Ä"
        '
        'TxtManualCode
        '
        Me.TxtManualCode.AgMandatory = True
        Me.TxtManualCode.AgMasterHelp = True
        Me.TxtManualCode.AgNumberLeftPlaces = 0
        Me.TxtManualCode.AgNumberNegetiveAllow = False
        Me.TxtManualCode.AgNumberRightPlaces = 0
        Me.TxtManualCode.AgPickFromLastValue = False
        Me.TxtManualCode.AgRowFilter = ""
        Me.TxtManualCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtManualCode.AgSelectedValue = Nothing
        Me.TxtManualCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtManualCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtManualCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtManualCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManualCode.Location = New System.Drawing.Point(145, 139)
        Me.TxtManualCode.MaxLength = 20
        Me.TxtManualCode.Name = "TxtManualCode"
        Me.TxtManualCode.Size = New System.Drawing.Size(132, 18)
        Me.TxtManualCode.TabIndex = 3
        '
        'LblManualCode
        '
        Me.LblManualCode.AutoSize = True
        Me.LblManualCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualCode.Location = New System.Drawing.Point(16, 139)
        Me.LblManualCode.Name = "LblManualCode"
        Me.LblManualCode.Size = New System.Drawing.Size(85, 15)
        Me.LblManualCode.TabIndex = 775
        Me.LblManualCode.Text = "Member Code"
        '
        'TxtDispName
        '
        Me.TxtDispName.AgMandatory = False
        Me.TxtDispName.AgMasterHelp = True
        Me.TxtDispName.AgNumberLeftPlaces = 0
        Me.TxtDispName.AgNumberNegetiveAllow = False
        Me.TxtDispName.AgNumberRightPlaces = 0
        Me.TxtDispName.AgPickFromLastValue = False
        Me.TxtDispName.AgRowFilter = ""
        Me.TxtDispName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDispName.AgSelectedValue = Nothing
        Me.TxtDispName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDispName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDispName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDispName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDispName.Location = New System.Drawing.Point(763, 214)
        Me.TxtDispName.MaxLength = 100
        Me.TxtDispName.Name = "TxtDispName"
        Me.TxtDispName.Size = New System.Drawing.Size(132, 18)
        Me.TxtDispName.TabIndex = 1
        Me.TxtDispName.Visible = False
        '
        'LblBuyerName
        '
        Me.LblBuyerName.AutoSize = True
        Me.LblBuyerName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerName.Location = New System.Drawing.Point(682, 216)
        Me.LblBuyerName.Name = "LblBuyerName"
        Me.LblBuyerName.Size = New System.Drawing.Size(75, 15)
        Me.LblBuyerName.TabIndex = 777
        Me.LblBuyerName.Text = "Buyer Name"
        Me.LblBuyerName.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(748, 200)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 7)
        Me.Label3.TabIndex = 861
        Me.Label3.Text = "Ä"
        Me.Label3.Visible = False
        '
        'TxtAcGroup
        '
        Me.TxtAcGroup.AgMandatory = False
        Me.TxtAcGroup.AgMasterHelp = False
        Me.TxtAcGroup.AgNumberLeftPlaces = 0
        Me.TxtAcGroup.AgNumberNegetiveAllow = False
        Me.TxtAcGroup.AgNumberRightPlaces = 0
        Me.TxtAcGroup.AgPickFromLastValue = False
        Me.TxtAcGroup.AgRowFilter = ""
        Me.TxtAcGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAcGroup.AgSelectedValue = Nothing
        Me.TxtAcGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAcGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAcGroup.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAcGroup.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcGroup.Location = New System.Drawing.Point(763, 194)
        Me.TxtAcGroup.MaxLength = 100
        Me.TxtAcGroup.Name = "TxtAcGroup"
        Me.TxtAcGroup.Size = New System.Drawing.Size(132, 18)
        Me.TxtAcGroup.TabIndex = 2
        Me.TxtAcGroup.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(682, 196)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 15)
        Me.Label4.TabIndex = 860
        Me.Label4.Text = "A/c Group"
        Me.Label4.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(16, 50)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(154, 18)
        Me.LinkLabel1.TabIndex = 940
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Member Information:"
        '
        'LblMemberNameReq
        '
        Me.LblMemberNameReq.AutoSize = True
        Me.LblMemberNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblMemberNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMemberNameReq.Location = New System.Drawing.Point(130, 125)
        Me.LblMemberNameReq.Name = "LblMemberNameReq"
        Me.LblMemberNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblMemberNameReq.TabIndex = 957
        Me.LblMemberNameReq.Text = "Ä"
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
        Me.TxtMemberName.Location = New System.Drawing.Point(145, 119)
        Me.TxtMemberName.MaxLength = 20
        Me.TxtMemberName.Name = "TxtMemberName"
        Me.TxtMemberName.Size = New System.Drawing.Size(292, 18)
        Me.TxtMemberName.TabIndex = 2
        '
        'LblMemberName
        '
        Me.LblMemberName.AutoSize = True
        Me.LblMemberName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberName.Location = New System.Drawing.Point(16, 121)
        Me.LblMemberName.Name = "LblMemberName"
        Me.LblMemberName.Size = New System.Drawing.Size(89, 15)
        Me.LblMemberName.TabIndex = 956
        Me.LblMemberName.Text = "Member Name"
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
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(145, 99)
        Me.TxtStreamYearSemester.MaxLength = 0
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(292, 18)
        Me.TxtStreamYearSemester.TabIndex = 1
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(16, 101)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(61, 15)
        Me.LblStreamYearSemester.TabIndex = 955
        Me.LblStreamYearSemester.Text = "Semester"
        '
        'LblMemberTypeReq
        '
        Me.LblMemberTypeReq.AutoSize = True
        Me.LblMemberTypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblMemberTypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMemberTypeReq.Location = New System.Drawing.Point(130, 86)
        Me.LblMemberTypeReq.Name = "LblMemberTypeReq"
        Me.LblMemberTypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblMemberTypeReq.TabIndex = 954
        Me.LblMemberTypeReq.Text = "Ä"
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
        Me.TxtMemberType.Location = New System.Drawing.Point(145, 79)
        Me.TxtMemberType.MaxLength = 0
        Me.TxtMemberType.Name = "TxtMemberType"
        Me.TxtMemberType.Size = New System.Drawing.Size(132, 18)
        Me.TxtMemberType.TabIndex = 0
        '
        'LblMemberType
        '
        Me.LblMemberType.AutoSize = True
        Me.LblMemberType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberType.Location = New System.Drawing.Point(16, 81)
        Me.LblMemberType.Name = "LblMemberType"
        Me.LblMemberType.Size = New System.Drawing.Size(81, 15)
        Me.LblMemberType.TabIndex = 953
        Me.LblMemberType.Text = "Member Type"
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
        Me.TxtEmployeeCode.Location = New System.Drawing.Point(763, 254)
        Me.TxtEmployeeCode.MaxLength = 20
        Me.TxtEmployeeCode.Name = "TxtEmployeeCode"
        Me.TxtEmployeeCode.Size = New System.Drawing.Size(132, 18)
        Me.TxtEmployeeCode.TabIndex = 960
        Me.TxtEmployeeCode.Visible = False
        '
        'LblEmployeeCode
        '
        Me.LblEmployeeCode.AutoSize = True
        Me.LblEmployeeCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmployeeCode.Location = New System.Drawing.Point(695, 255)
        Me.LblEmployeeCode.Name = "LblEmployeeCode"
        Me.LblEmployeeCode.Size = New System.Drawing.Size(62, 15)
        Me.LblEmployeeCode.TabIndex = 961
        Me.LblEmployeeCode.Text = "Employee"
        Me.LblEmployeeCode.Visible = False
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
        Me.TxtStudentCode.Location = New System.Drawing.Point(763, 234)
        Me.TxtStudentCode.MaxLength = 20
        Me.TxtStudentCode.Name = "TxtStudentCode"
        Me.TxtStudentCode.Size = New System.Drawing.Size(132, 18)
        Me.TxtStudentCode.TabIndex = 958
        Me.TxtStudentCode.Visible = False
        '
        'LblStudentCode
        '
        Me.LblStudentCode.AutoSize = True
        Me.LblStudentCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStudentCode.Location = New System.Drawing.Point(695, 235)
        Me.LblStudentCode.Name = "LblStudentCode"
        Me.LblStudentCode.Size = New System.Drawing.Size(82, 15)
        Me.LblStudentCode.TabIndex = 959
        Me.LblStudentCode.Text = "Student Code"
        Me.LblStudentCode.Visible = False
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
        Me.TxtMotherName.Location = New System.Drawing.Point(145, 179)
        Me.TxtMotherName.MaxLength = 100
        Me.TxtMotherName.Name = "TxtMotherName"
        Me.TxtMotherName.Size = New System.Drawing.Size(292, 18)
        Me.TxtMotherName.TabIndex = 5
        '
        'LblMotherName
        '
        Me.LblMotherName.AutoSize = True
        Me.LblMotherName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMotherName.Location = New System.Drawing.Point(16, 180)
        Me.LblMotherName.Name = "LblMotherName"
        Me.LblMotherName.Size = New System.Drawing.Size(81, 15)
        Me.LblMotherName.TabIndex = 965
        Me.LblMotherName.Text = "Mother Name"
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
        Me.TxtFatherName.Location = New System.Drawing.Point(145, 159)
        Me.TxtFatherName.MaxLength = 100
        Me.TxtFatherName.Name = "TxtFatherName"
        Me.TxtFatherName.Size = New System.Drawing.Size(292, 18)
        Me.TxtFatherName.TabIndex = 4
        '
        'LblFatherName
        '
        Me.LblFatherName.AutoSize = True
        Me.LblFatherName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFatherName.Location = New System.Drawing.Point(16, 160)
        Me.LblFatherName.Name = "LblFatherName"
        Me.LblFatherName.Size = New System.Drawing.Size(79, 15)
        Me.LblFatherName.TabIndex = 964
        Me.LblFatherName.Text = "Father Name"
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
        Me.TxtIsMemberActive.Location = New System.Drawing.Point(144, 319)
        Me.TxtIsMemberActive.MaxLength = 0
        Me.TxtIsMemberActive.Name = "TxtIsMemberActive"
        Me.TxtIsMemberActive.Size = New System.Drawing.Size(54, 18)
        Me.TxtIsMemberActive.TabIndex = 12
        '
        'LblIsMemberActive
        '
        Me.LblIsMemberActive.AutoSize = True
        Me.LblIsMemberActive.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsMemberActive.Location = New System.Drawing.Point(16, 321)
        Me.LblIsMemberActive.Name = "LblIsMemberActive"
        Me.LblIsMemberActive.Size = New System.Drawing.Size(106, 15)
        Me.LblIsMemberActive.TabIndex = 971
        Me.LblIsMemberActive.Text = "Is Member Active?"
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
        Me.TxtInActiveDate.Location = New System.Drawing.Point(335, 319)
        Me.TxtInActiveDate.MaxLength = 20
        Me.TxtInActiveDate.Name = "TxtInActiveDate"
        Me.TxtInActiveDate.Size = New System.Drawing.Size(101, 18)
        Me.TxtInActiveDate.TabIndex = 13
        Me.TxtInActiveDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblInActiveDate
        '
        Me.LblInActiveDate.AutoSize = True
        Me.LblInActiveDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInActiveDate.Location = New System.Drawing.Point(204, 321)
        Me.LblInActiveDate.Name = "LblInActiveDate"
        Me.LblInActiveDate.Size = New System.Drawing.Size(77, 15)
        Me.LblInActiveDate.TabIndex = 970
        Me.LblInActiveDate.Text = "Inactive Date"
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
        Me.txtReminderRemark.Location = New System.Drawing.Point(763, 295)
        Me.txtReminderRemark.MaxLength = 255
        Me.txtReminderRemark.Name = "txtReminderRemark"
        Me.txtReminderRemark.Size = New System.Drawing.Size(132, 18)
        Me.txtReminderRemark.TabIndex = 14
        Me.txtReminderRemark.Visible = False
        '
        'LblReminderRemark
        '
        Me.LblReminderRemark.AutoSize = True
        Me.LblReminderRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReminderRemark.Location = New System.Drawing.Point(688, 296)
        Me.LblReminderRemark.Name = "LblReminderRemark"
        Me.LblReminderRemark.Size = New System.Drawing.Size(109, 15)
        Me.LblReminderRemark.TabIndex = 969
        Me.LblReminderRemark.Text = "Reminder Remark"
        Me.LblReminderRemark.Visible = False
        '
        'LinkLblTitle
        '
        Me.LinkLblTitle.AutoSize = True
        Me.LinkLblTitle.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLblTitle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLblTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLblTitle.LinkColor = System.Drawing.Color.White
        Me.LinkLblTitle.Location = New System.Drawing.Point(480, 50)
        Me.LinkLblTitle.Name = "LinkLblTitle"
        Me.LinkLblTitle.Size = New System.Drawing.Size(166, 18)
        Me.LinkLblTitle.TabIndex = 988
        Me.LinkLblTitle.TabStop = True
        Me.LinkLblTitle.Text = "Transport Information:"
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
        Me.TxtSeatNo.Location = New System.Drawing.Point(803, 159)
        Me.TxtSeatNo.MaxLength = 0
        Me.TxtSeatNo.Name = "TxtSeatNo"
        Me.TxtSeatNo.Size = New System.Drawing.Size(92, 18)
        Me.TxtSeatNo.TabIndex = 22
        '
        'LblSeatNo
        '
        Me.LblSeatNo.AutoSize = True
        Me.LblSeatNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeatNo.Location = New System.Drawing.Point(716, 161)
        Me.LblSeatNo.Name = "LblSeatNo"
        Me.LblSeatNo.Size = New System.Drawing.Size(54, 15)
        Me.LblSeatNo.TabIndex = 987
        Me.LblSeatNo.Text = "Seat No."
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
        Me.TxtVehicle.Location = New System.Drawing.Point(603, 159)
        Me.TxtVehicle.MaxLength = 0
        Me.TxtVehicle.Name = "TxtVehicle"
        Me.TxtVehicle.Size = New System.Drawing.Size(100, 18)
        Me.TxtVehicle.TabIndex = 21
        '
        'LblVehicle
        '
        Me.LblVehicle.AutoSize = True
        Me.LblVehicle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVehicle.Location = New System.Drawing.Point(480, 161)
        Me.LblVehicle.Name = "LblVehicle"
        Me.LblVehicle.Size = New System.Drawing.Size(84, 15)
        Me.LblVehicle.TabIndex = 986
        Me.LblVehicle.Text = "Vehicle Name"
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
        Me.TxtRoute.Location = New System.Drawing.Point(603, 139)
        Me.TxtRoute.MaxLength = 0
        Me.TxtRoute.Name = "TxtRoute"
        Me.TxtRoute.Size = New System.Drawing.Size(292, 18)
        Me.TxtRoute.TabIndex = 20
        '
        'LblRoute
        '
        Me.LblRoute.AutoSize = True
        Me.LblRoute.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoute.Location = New System.Drawing.Point(480, 141)
        Me.LblRoute.Name = "LblRoute"
        Me.LblRoute.Size = New System.Drawing.Size(40, 15)
        Me.LblRoute.TabIndex = 985
        Me.LblRoute.Text = "Route"
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
        Me.TxtPickUpPoint.Location = New System.Drawing.Point(603, 119)
        Me.TxtPickUpPoint.MaxLength = 0
        Me.TxtPickUpPoint.Name = "TxtPickUpPoint"
        Me.TxtPickUpPoint.Size = New System.Drawing.Size(292, 18)
        Me.TxtPickUpPoint.TabIndex = 19
        '
        'LblPickUpPoint
        '
        Me.LblPickUpPoint.AutoSize = True
        Me.LblPickUpPoint.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPickUpPoint.Location = New System.Drawing.Point(480, 121)
        Me.LblPickUpPoint.Name = "LblPickUpPoint"
        Me.LblPickUpPoint.Size = New System.Drawing.Size(75, 15)
        Me.LblPickUpPoint.TabIndex = 984
        Me.LblPickUpPoint.Text = "Pickup Point"
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
        Me.TxtValidTillDate.Location = New System.Drawing.Point(803, 99)
        Me.TxtValidTillDate.MaxLength = 20
        Me.TxtValidTillDate.Name = "TxtValidTillDate"
        Me.TxtValidTillDate.Size = New System.Drawing.Size(92, 18)
        Me.TxtValidTillDate.TabIndex = 18
        Me.TxtValidTillDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblValidTillDate
        '
        Me.LblValidTillDate.AutoSize = True
        Me.LblValidTillDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblValidTillDate.Location = New System.Drawing.Point(714, 101)
        Me.LblValidTillDate.Name = "LblValidTillDate"
        Me.LblValidTillDate.Size = New System.Drawing.Size(83, 15)
        Me.LblValidTillDate.TabIndex = 983
        Me.LblValidTillDate.Text = "Card Valid Till"
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
        Me.TxtCardSrNo.Location = New System.Drawing.Point(803, 79)
        Me.TxtCardSrNo.MaxLength = 20
        Me.TxtCardSrNo.Name = "TxtCardSrNo"
        Me.TxtCardSrNo.Size = New System.Drawing.Size(92, 18)
        Me.TxtCardSrNo.TabIndex = 16
        Me.TxtCardSrNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblCardSrNo
        '
        Me.LblCardSrNo.AutoSize = True
        Me.LblCardSrNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCardSrNo.Location = New System.Drawing.Point(714, 81)
        Me.LblCardSrNo.Name = "LblCardSrNo"
        Me.LblCardSrNo.Size = New System.Drawing.Size(74, 15)
        Me.LblCardSrNo.TabIndex = 982
        Me.LblCardSrNo.Text = "Card Sr. No."
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
        Me.TxtCardPrefix.Location = New System.Drawing.Point(603, 79)
        Me.TxtCardPrefix.MaxLength = 20
        Me.TxtCardPrefix.Name = "TxtCardPrefix"
        Me.TxtCardPrefix.Size = New System.Drawing.Size(100, 18)
        Me.TxtCardPrefix.TabIndex = 15
        '
        'LblCardPrefix
        '
        Me.LblCardPrefix.AutoSize = True
        Me.LblCardPrefix.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCardPrefix.Location = New System.Drawing.Point(480, 81)
        Me.LblCardPrefix.Name = "LblCardPrefix"
        Me.LblCardPrefix.Size = New System.Drawing.Size(67, 15)
        Me.LblCardPrefix.TabIndex = 981
        Me.LblCardPrefix.Text = "Card Prefix"
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
        Me.TxtMemberCardNo.Location = New System.Drawing.Point(603, 99)
        Me.TxtMemberCardNo.MaxLength = 50
        Me.TxtMemberCardNo.Name = "TxtMemberCardNo"
        Me.TxtMemberCardNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtMemberCardNo.TabIndex = 17
        '
        'LblMemberCardNo
        '
        Me.LblMemberCardNo.AutoSize = True
        Me.LblMemberCardNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberCardNo.Location = New System.Drawing.Point(480, 101)
        Me.LblMemberCardNo.Name = "LblMemberCardNo"
        Me.LblMemberCardNo.Size = New System.Drawing.Size(101, 15)
        Me.LblMemberCardNo.TabIndex = 980
        Me.LblMemberCardNo.Text = "Member Card No"
        '
        'FrmBuyerMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(907, 486)
        Me.Controls.Add(Me.LinkLblTitle)
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
        Me.Controls.Add(Me.TxtMemberCardNo)
        Me.Controls.Add(Me.LblMemberCardNo)
        Me.Controls.Add(Me.TxtIsMemberActive)
        Me.Controls.Add(Me.LblIsMemberActive)
        Me.Controls.Add(Me.TxtInActiveDate)
        Me.Controls.Add(Me.LblInActiveDate)
        Me.Controls.Add(Me.txtReminderRemark)
        Me.Controls.Add(Me.LblReminderRemark)
        Me.Controls.Add(Me.TxtMotherName)
        Me.Controls.Add(Me.LblMotherName)
        Me.Controls.Add(Me.TxtFatherName)
        Me.Controls.Add(Me.LblFatherName)
        Me.Controls.Add(Me.TxtEmployeeCode)
        Me.Controls.Add(Me.LblEmployeeCode)
        Me.Controls.Add(Me.TxtStudentCode)
        Me.Controls.Add(Me.LblStudentCode)
        Me.Controls.Add(Me.LblMemberNameReq)
        Me.Controls.Add(Me.TxtMemberName)
        Me.Controls.Add(Me.LblMemberName)
        Me.Controls.Add(Me.TxtStreamYearSemester)
        Me.Controls.Add(Me.LblStreamYearSemester)
        Me.Controls.Add(Me.LblMemberTypeReq)
        Me.Controls.Add(Me.TxtMemberType)
        Me.Controls.Add(Me.LblMemberType)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtAcGroup)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtEMail)
        Me.Controls.Add(Me.LblBuyerEMail)
        Me.Controls.Add(Me.TxtFax)
        Me.Controls.Add(Me.LblBuyerFax)
        Me.Controls.Add(Me.TxtPhone)
        Me.Controls.Add(Me.LblPhone)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtCity)
        Me.Controls.Add(Me.LblBuyerCity)
        Me.Controls.Add(Me.LblBuyerAddressReq)
        Me.Controls.Add(Me.TxtAdd2)
        Me.Controls.Add(Me.TxtAdd1)
        Me.Controls.Add(Me.LblBuyerAddress)
        Me.Controls.Add(Me.TxtAdd3)
        Me.Controls.Add(Me.LblBuyerNameReq)
        Me.Controls.Add(Me.LblManualCodeReq)
        Me.Controls.Add(Me.TxtManualCode)
        Me.Controls.Add(Me.LblManualCode)
        Me.Controls.Add(Me.TxtDispName)
        Me.Controls.Add(Me.LblBuyerName)
        Me.Name = "FrmBuyerMaster"
        Me.Text = "Buyer Master"
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerName, 0)
        Me.Controls.SetChildIndex(Me.TxtDispName, 0)
        Me.Controls.SetChildIndex(Me.LblManualCode, 0)
        Me.Controls.SetChildIndex(Me.TxtManualCode, 0)
        Me.Controls.SetChildIndex(Me.LblManualCodeReq, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerNameReq, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd3, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerAddress, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd1, 0)
        Me.Controls.SetChildIndex(Me.TxtAdd2, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerAddressReq, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerCity, 0)
        Me.Controls.SetChildIndex(Me.TxtCity, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.LblPhone, 0)
        Me.Controls.SetChildIndex(Me.TxtPhone, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerFax, 0)
        Me.Controls.SetChildIndex(Me.TxtFax, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerEMail, 0)
        Me.Controls.SetChildIndex(Me.TxtEMail, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtAcGroup, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.LblMemberType, 0)
        Me.Controls.SetChildIndex(Me.TxtMemberType, 0)
        Me.Controls.SetChildIndex(Me.LblMemberTypeReq, 0)
        Me.Controls.SetChildIndex(Me.LblStreamYearSemester, 0)
        Me.Controls.SetChildIndex(Me.TxtStreamYearSemester, 0)
        Me.Controls.SetChildIndex(Me.LblMemberName, 0)
        Me.Controls.SetChildIndex(Me.TxtMemberName, 0)
        Me.Controls.SetChildIndex(Me.LblMemberNameReq, 0)
        Me.Controls.SetChildIndex(Me.LblStudentCode, 0)
        Me.Controls.SetChildIndex(Me.TxtStudentCode, 0)
        Me.Controls.SetChildIndex(Me.LblEmployeeCode, 0)
        Me.Controls.SetChildIndex(Me.TxtEmployeeCode, 0)
        Me.Controls.SetChildIndex(Me.LblFatherName, 0)
        Me.Controls.SetChildIndex(Me.TxtFatherName, 0)
        Me.Controls.SetChildIndex(Me.LblMotherName, 0)
        Me.Controls.SetChildIndex(Me.TxtMotherName, 0)
        Me.Controls.SetChildIndex(Me.LblReminderRemark, 0)
        Me.Controls.SetChildIndex(Me.txtReminderRemark, 0)
        Me.Controls.SetChildIndex(Me.LblInActiveDate, 0)
        Me.Controls.SetChildIndex(Me.TxtInActiveDate, 0)
        Me.Controls.SetChildIndex(Me.LblIsMemberActive, 0)
        Me.Controls.SetChildIndex(Me.TxtIsMemberActive, 0)
        Me.Controls.SetChildIndex(Me.LblMemberCardNo, 0)
        Me.Controls.SetChildIndex(Me.TxtMemberCardNo, 0)
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
        Me.Controls.SetChildIndex(Me.LinkLblTitle, 0)
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

    Protected WithEvents LblBuyerName As System.Windows.Forms.Label
    Protected WithEvents TxtDispName As AgControls.AgTextBox
    Protected WithEvents LblManualCode As System.Windows.Forms.Label
    Protected WithEvents TxtManualCode As AgControls.AgTextBox
    Protected WithEvents LblManualCodeReq As System.Windows.Forms.Label
    Protected WithEvents LblBuyerNameReq As System.Windows.Forms.Label
    Protected WithEvents TxtAdd3 As AgControls.AgTextBox
    Protected WithEvents LblBuyerAddress As System.Windows.Forms.Label
    Protected WithEvents TxtAdd1 As AgControls.AgTextBox
    Protected WithEvents TxtAdd2 As AgControls.AgTextBox
    Protected WithEvents LblBuyerAddressReq As System.Windows.Forms.Label
    Protected WithEvents LblBuyerCity As System.Windows.Forms.Label
    Protected WithEvents TxtCity As AgControls.AgTextBox
    Protected WithEvents Label13 As System.Windows.Forms.Label
    Protected WithEvents LblPhone As System.Windows.Forms.Label
    Protected WithEvents TxtPhone As AgControls.AgTextBox
    Protected WithEvents LblBuyerFax As System.Windows.Forms.Label
    Protected WithEvents TxtFax As AgControls.AgTextBox
    Protected WithEvents LblBuyerEMail As System.Windows.Forms.Label
    Protected WithEvents TxtEMail As AgControls.AgTextBox
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents TxtAcGroup As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
#End Region


    Private Sub FrmShade_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        'If AgL.RequiredField(TxtBuyerCode, LblBuyerCode.Text) Then Exit Sub
        'If AgL.RequiredField(TxtBuyerDispName, LblBuyerName.Text) Then Exit Sub
        'If Topctrl1.Mode = "Add" Then
        '    mQry = "Select count(*) From SubGroup Where ManualCode='" & TxtBuyerCode.Text & "' "
        '    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Code Already Exists")

        '    mQry = "Select count(*) From SubGroup Where DispName='" & TxtBuyerDispName.Text & "'"
        '    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Name Already Exists")
        'Else
        '    mQry = "Select count(*) From SubGroup Where ManualCode ='" & TxtBuyerCode.Text & "' And SubCode<>'" & mInternalCode & "' "
        '    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Code Already Exists")

        '    mQry = "Select count(*) From SubGroup Where DispName='" & TxtBuyerDispName.Text & "' And SubCode<>'" & mInternalCode & "' "
        '    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Name Already Exists")
        'End If
    End Sub


    Private Sub FrmShade_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        AgL.PubFindQry = "SELECT B.UID, S.ManualCode as [Member Code], S.DispName as [Member Name], " & _
                        " B.MemberCardNo AS [Member Card No.],S.FatherName, S.MotherName, " & _
                        " IsNull(S.Add1,'') + Space(1) + IsNull(S.Add2,'') + Space(1) + IsNull(S.Add3,'') As Address, " & _
                        " C.CityName as City, S.Phone, S.Fax " & _
                        " FROM Tp_Member_Log B " & _
                        " LEFT JOIN SubGroup_Log S On B.UID = S.UID  " & _
                        " LEFT JOIN CIty C On S.CityCode = C.CityCode " & _
                        " WHERE S.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Member Name]"
    End Sub

    Private Sub FrmShade_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        AgL.PubFindQry = "SELECT B.UID, S.ManualCode as [Member Code], S.DispName as [Member Name], " & _
                        " B.MemberCardNo AS [Member Card No.],S.FatherName, S.MotherName, " & _
                        " IsNull(S.Add1,'') + Space(1) + IsNull(S.Add2,'') + Space(1) + IsNull(S.Add3,'') As Address, " & _
                        " C.CityName as City, S.Phone, S.Fax " & _
                        " FROM Tp_Member B " & _
                        " LEFT JOIN SubGroup S On B.SubCode = S.SubCode " & _
                        " LEFT JOIN CIty C On S.CityCode = C.CityCode " & _
                        " WHERE IsNull(S.IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Member Name]"
    End Sub

    Private Sub FrmShade_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "SubGroup"
        LogTableName = "SubGroup_LOG"
        MainLineTableCsv = "Tp_Member"
        LogLineTableCsv = "Tp_Member_Log"
        PrimaryField = "SubCode"
    End Sub

    Private Sub FrmShade_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
    End Sub

    Private Sub FrmBuyerMaster_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        mNature = "" : mGroupNature = "" : mSubGroupType = ""
        TxtIsMemberActive.Text = "Yes"
    End Sub

    Private Sub FrmQuality1_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        'TxtBuyerCountry.Enabled = False : TxtMCountry.Enabled = False
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select S.SubCode as Code, S.ManualCode As Name " & _
                " From Tp_Member B " & _
                " LEFT JOIN SubGroup S On B.SubCode = S.SubCode " & _
                " Order By S.ManualCode "
        TxtManualCode.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select S.SubCode as Code, S.DispName As Name " & _
            " From Tp_Member B " & _
            " LEFT JOIN SubGroup S On B.SubCode = S.SubCode " & _
            " Order By S.DispName "
        TxtDispName.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT C.CityCode AS Code, C.CityName, C.Country, C.Status, IsNull(C.IsDeleted,0) as IsDeleted  " & _
                " FROM City C  "
        TxtCity.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT A.GroupCode AS Code, A.GroupName AS Name, A.GroupNature , A.Nature  " & _
                  " FROM AcGroup A " & _
                  " WHERE LEFT(MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") in ('" & AgLibrary.ClsConstant.MainGRCodeSundryCreditors & "' , '" & AgLibrary.ClsConstant.MainGRCodeSundryDebtors & "') " & _
                  " AND MainGrLen >= " & AgLibrary.ClsConstant.MainGRLenSundryCreditors & " " & _
                  " AND AliasYn = 'N'"
        TxtAcGroup.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

        If AgL.VNull(DtMess_Enviro.Rows(0)("IsLinkWithAcademic")) <> 0 Then
            mQry = " SELECT H.Subcode AS Code, SG.DispName AS Name, SG.ManualCode, " & _
                    " '" & ClsMain.MemberType.Student & "' As [Member Type], " & _
                    " SG.FatherName, Sg.MotherName, SG.Add1,SG.Add2,SG.Add3,SG.CityCode,SG.CountryCode, " & _
                    " SG.Mobile, SG.FAX, SG.EMail, vA.FromStreamYearSemester As CurrentSemester, Sg.GroupCode, Sg.Party_Type " & _
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
                    " SG.Mobile, SG.FAX, SG.EMail, '' As CurrentSemester, Sg.GroupCode, Sg.Party_Type " & _
                    " FROM Pay_Employee H  " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode=H.SubCode  "
        Else
            mQry = " SELECT H.Subcode AS Code, SG.DispName AS Name, SG.ManualCode, " & _
                    " '" & ClsMain.MemberType.Student & "' As [Member Type], " & _
                    " SG.FatherName, Sg.MotherName, SG.Add1,SG.Add2,SG.Add3,SG.CityCode,SG.CountryCode, " & _
                    " SG.Mobile, SG.FAX, SG.EMail, '' As CurrentSemester, Sg.GroupCode, Sg.Party_Type " & _
                    " FROM Tp_Member H  " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode=H.SubCode  " & _
                    " "
        End If
        TxtMemberName.AgHelpDataSet(14) = AgL.FillData(mQry, AgL.GCn)

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

        mQry = " Select '" & ClsMain.MemberType.Student & "' As Code, '" & ClsMain.MemberType.Student & "' As Name " & _
                " Union All " & _
                " Select '" & ClsMain.MemberType.Employee & "' As Code, '" & ClsMain.MemberType.Employee & "' As Name "
        TxtMemberType.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub FrmShade_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        mQry = "Select B.SubCode As SearchCode " & _
            " From Tp_Member B " & _
            " LEFT JOIN SubGroup S ON B.SubCode = S.SubCode " & _
            " WHERE IsNull(S.IsDeleted,0)=0 "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmShade_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        mQry = "Select B.UID As SearchCode " & _
               " From Tp_Member_Log B " & _
               " LEFT JOIN SubGroup_Log S On B.UID = S.UID " & _
               " WHERE S.EntryStatus = '" & LogStatus.LogOpen & "' "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmBuyerMaster_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid

    End Sub

    Private Sub FrmQuality1_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet = Nothing, bDtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select S.* " & _
                    " From Tp_Member B " & _
                    " Inner Join SubGroup S On B.SubCode = S.SubCode " & _
                    " Where B.SubCode='" & SearchCode & "'"
        Else
            mQry = "Select S.* " & _
                    " From Tp_Member_Log B " & _
                    " Inner Join SubGroup_Log  S On B.UID = S.UID " & _
                    " Where B.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("SubCode"))
                TxtManualCode.Text = AgL.XNull(.Rows(0)("ManualCode"))
                TxtDispName.Text = AgL.XNull(.Rows(0)("DispName"))
                TxtAcGroup.AgSelectedValue = AgL.XNull(.Rows(0)("GroupCode"))
                TxtAdd1.Text = AgL.XNull(.Rows(0)("Add1"))
                TxtAdd2.Text = AgL.XNull(.Rows(0)("Add2"))
                TxtAdd3.Text = AgL.XNull(.Rows(0)("Add3"))
                TxtCity.AgSelectedValue = AgL.XNull(.Rows(0)("CityCode"))
                TxtPhone.Text = AgL.XNull(.Rows(0)("Phone"))
                TxtFax.Text = AgL.XNull(.Rows(0)("Fax"))
                TxtEMail.Text = AgL.XNull(.Rows(0)("EMail"))
                mGroupNature = AgL.XNull(.Rows(0)("GroupNature"))
                mNature = AgL.XNull(.Rows(0)("Nature"))
                mSubGroupType = AgL.XNull(.Rows(0)("Party_Type"))
            End If
        End With

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
        bDtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
        With bDtTemp
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


        Topctrl1.tPrn = False
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtMemberType.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        TxtMemberType.Focus()
    End Sub

    Public Overrides Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim InstancePassed As Boolean = True

        Try
            MastPos = BMBMaster.Position

            If Not AgL.StrCmp(TxtDivision.AgSelectedValue, AgL.PubDivCode) Then
                MsgBox("Different Division Record. Can't Modify!", MsgBoxStyle.OkOnly, "Validation") : Exit Sub
            End If

            If LogSystem Then
                If TxtMoveToLog.Text = "" Then MsgBox("The Record Can't Be Deleted", MsgBoxStyle.Information) : Exit Sub
            End If

            'RaiseEvent BaseEvent_Topctrl_tbDel(InstancePassed)
            'If Not InstancePassed Then Exit Sub

            If DTMaster.Rows.Count > 0 Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then

                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True


                    If TxtStudentCode.Text.Trim + TxtEmployeeCode.Text.Trim <> "" Then
                        mQry = "DELETE FROM Tp_Member WHERE SubCode = " & AgL.Chk_Text(mInternalCode) & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "DELETE FROM Tp_Member_Log WHERE SubCode = " & AgL.Chk_Text(mInternalCode) & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    Else
                        mQry = "DELETE FROM Tp_Member WHERE SubCode = " & AgL.Chk_Text(mInternalCode) & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "DELETE FROM Tp_Member_Log WHERE SubCode = " & AgL.Chk_Text(mInternalCode) & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "DELETE FROM SubGroup WHERE SubCode = " & AgL.Chk_Text(mInternalCode) & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "DELETE FROM SubGroup_Log WHERE SubCode = " & AgL.Chk_Text(mInternalCode) & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)


                    AgL.ETrans.Commit()
                    mTrans = False

                    FIniMaster(1)
                    Topctrl1_tbRef()
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
    End Sub

    Private Sub FrmShade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 500, 920, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Public Overrides Sub ProcSave()
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bName$ = ""
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If AgCL.AgCheckMandatory(Me) = False Then Exit Sub
            If AgL.RequiredField(TxtManualCode, LblManualCode.Text) Then Exit Sub
            If AgL.RequiredField(TxtDispName, LblBuyerName.Text) Then Exit Sub


            If Topctrl1.Mode = "Add" Then
                If TxtStudentCode.Text.Trim <> "" Then
                    mInternalCode = TxtStudentCode.Text
                Else
                    If TxtEmployeeCode.Text.Trim <> "" Then
                        mInternalCode = TxtEmployeeCode.Text
                    End If
                End If

                If mInternalCode.Trim <> "" Then
                    mQry = "SELECT Convert(VARCHAR(36), Sg.UID) As Uid " & _
                            " FROM SubGroup Sg WITH (NoLock) " & _
                            " WHERE Sg.SubCode = " & AgL.Chk_Text(mInternalCode) & ""
                    mSearchCode = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)

                    If mSearchCode.Trim = "" Then mSearchCode = AgL.GetGUID(AgL.GCn).ToString
                End If
            End If

            If mSubGroupType.Trim = "" Then mSubGroupType = AgLibrary.ClsConstant.SubGroupType_Other

            If Topctrl1.Mode = "Add" And TxtStudentCode.Text.Trim + TxtEmployeeCode.Text.Trim = "" Then
                mQry = "Select count(*) From SubGroup Where ManualCode='" & TxtManualCode.Text & "' "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Member Code Already Exists")

                mQry = "Select count(*) From SubGroup Where DispName='" & TxtDispName.Text & "'"
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Member Name Already Exists")

                mQry = "Select count(*) From SubGroup_Log Where ManualCode='" & TxtManualCode.Text & "' And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Member Code Already Exists in Log File")

                mQry = "Select count(*) From SubGroup_Log Where DispName='" & TxtDispName.Text & "' And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Member Name Already Exists in Log File")

                mSearchCode = AgL.GetGUID(AgL.GCn).ToString
                mInternalCode = AgL.GetMaxId("SubGroup_Log", "SubCode", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, AgL.ECmd, AgL.Gcn_ConnectionString)
            Else
                mQry = "Select count(*) From SubGroup Where ManualCode ='" & TxtManualCode.Text & "' And SubCode<>'" & mInternalCode & "' "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Member Code Already Exists")

                mQry = "Select count(*) From SubGroup Where DispName='" & TxtDispName.Text & "' And SubCode<>'" & mInternalCode & "' "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Member Name Already Exists")

                mQry = "Select count(*) From SubGroup_Log Where ManualCode='" & TxtManualCode.Text & "' And UID <>'" & mSearchCode & "' And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Member Code Already Exists in Log File")

                mQry = "Select count(*) From SubGroup_Log Where DispName='" & TxtDispName.Text & "' And UID <>'" & mSearchCode & "' And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Member Name Already Exists in Log File")
            End If

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            bName = TxtDispName.Text + " {" + TxtManualCode.Text + "}"
            If Topctrl1.Mode = "Add" Then
                mQry = "If Not EXISTS(SELECT * FROM SubGroup_Log With (NoLock) WHERE Uid = " & AgL.Chk_Text(mSearchCode) & ") " & _
                        " INSERT INTO SubGroup_Log(UID, SubCode, Site_Code, Name, DispName, " & _
                        " GroupCode, GroupNature,	ManualCode,	Nature, Party_Type, " & _
                        " EntryBy, EntryDate,  EntryType, EntryStatus, Div_Code, " & _
                        " U_Name, U_EntDt, U_AE) " & _
                        " VALUES(" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & _
                        " '" & AgL.PubSiteCode & "',	" & AgL.Chk_Text(bName) & ",	" & _
                        " " & AgL.Chk_Text(TxtDispName.Text) & ", " & AgL.Chk_Text(TxtAcGroup.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(mGroupNature) & ", " & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
                        " " & AgL.Chk_Text(mNature) & ", " & AgL.Chk_Text(mSubGroupType) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                        " " & AgL.Chk_Text(Topctrl1.Mode) & ", " & AgL.Chk_Text(LogStatus.LogOpen) & ", " & _
                        " " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "','" & Format(AgL.PubLoginDate, "Short Date") & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "INSERT INTO Tp_Member_Log(UID, SubCode) " & _
                        " VALUES (" & AgL.Chk_Text(mSearchCode) & ", '" & mInternalCode & "') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "UPDATE SubGroup_Log " & _
                        " SET " & _
                        " EntryBy = " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                        " EntryDate = " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                        " EntryType = " & AgL.Chk_Text(Topctrl1.Mode) & ", " & _
                        " EntryStatus = " & AgL.Chk_Text(LogStatus.LogOpen) & ", " & _
                        " Div_Code = " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, "Short Date") & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " Where UID = " & AgL.Chk_Text(mSearchCode) & "  "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            mQry = "UPDATE SubGroup_Log " & _
                    " SET " & _
                    " Name = " & AgL.Chk_Text(bName) & ", " & _
                    " DispName = " & AgL.Chk_Text(TxtDispName.Text) & ", " & _
                    " GroupCode = " & AgL.Chk_Text(TxtAcGroup.AgSelectedValue) & ", " & _
                    " GroupNature = " & AgL.Chk_Text(mGroupNature) & ", " & _
                    " Party_Type =  " & AgL.Chk_Text(mSubGroupType) & ", " & _
                    " ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
                    " Nature = " & AgL.Chk_Text(mNature) & ", " & _
                    " Add1 = " & AgL.Chk_Text(TxtAdd1.Text) & ", " & _
                    " Add2 = " & AgL.Chk_Text(TxtAdd2.Text) & ", " & _
                    " Add3 = " & AgL.Chk_Text(TxtAdd3.Text) & ", " & _
                    " CityCode = " & AgL.Chk_Text(TxtCity.AgSelectedValue) & ", " & _
                    " Phone = " & AgL.Chk_Text(TxtPhone.Text) & ", " & _
                    " FAX = " & AgL.Chk_Text(TxtFax.Text) & ", " & _
                    " EMail = " & AgL.Chk_Text(TxtEMail.Text) & ", " & _
                    " FatherName = " & AgL.Chk_Text(TxtFatherName.Text) & ", " & _
                    " MotherName = " & AgL.Chk_Text(TxtMotherName.Text) & " " & _
                    " Where UID = " & AgL.Chk_Text(mSearchCode) & "  "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

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
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            '--------------------------------------------------------------
            'If not using Log System then approve record automatic on each save
            '--------------------------------------------------------------
            If Not LogSystem Then
                Call ProcApporve(AgL.GCn, AgL.ECmd)
            End If
            '--------------------------------------------------------------


            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl1_tbRef()
            End If

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtDestinationPort_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtCity.Enter, TxtManualCode.Enter, TxtMemberName.Enter, TxtMemberName.Enter, TxtStreamYearSemester.Enter

        Dim bStrFilter$ = ""
        Try
            Select Case sender.Name
                'Case TxtDestinationPort.Name
                '    sender.AgRowFilter = " Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' And IsDeleted=0 "
                Case TxtStreamYearSemester.Name
                    If Not AgL.StrCmp(TxtMemberType.Text, ClsMain.MemberType.Student) Then
                        bStrFilter = " 1=2 "
                    Else
                        bStrFilter = " 1=1 "
                    End If
                    sender.AgRowFilter = bStrFilter

                Case TxtMemberName.Name
                    bStrFilter = " 1=1 "
                    bStrFilter += " And [Member Type] = " & AgL.Chk_Text(TxtMemberType.Text) & " "

                    If AgL.StrCmp(TxtMemberType.Text, ClsMain.MemberType.Student) Then
                        bStrFilter += " And CurrentSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "
                    End If

                    sender.AgRowFilter = bStrFilter
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtCity.Validating, TxtAcGroup.Validating, TxtCity.Validating, _
        TxtStudentCode.Validating, TxtFatherName.Validating, TxtMotherName.Validating, TxtIsMemberActive.Validating, _
        TxtInActiveDate.Validating, TxtRoute.Validating, TxtPickUpPoint.Validating, TxtVehicle.Validating, TxtSeatNo.Validating, _
        TxtCardPrefix.Validating, TxtCardSrNo.Validating, TxtMemberCardNo.Validating, txtReminderRemark.Validating, _
        TxtMemberName.Validating, TxtStreamYearSemester.Validating, TxtMemberType.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

            Select Case sender.NAME
                Case TxtAcGroup.Name
                    Call Validating_Controls(sender)

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
                        TxtAcGroup.AgSelectedValue = ""
                        mSubGroupType = ""
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
                            TxtAcGroup.AgSelectedValue = AgL.XNull(DrTemp(0)("GroupCode"))
                            mSubGroupType = AgL.XNull(DrTemp(0)("Party_Type"))

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

                    Call Validating_Controls(TxtAcGroup)

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function Validating_Controls(ByVal Sender As Object) As Boolean
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtAcGroup.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    mGroupNature = ""
                    mNature = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        mGroupNature = AgL.XNull(DrTemp(0)("GroupNature"))
                        mNature = AgL.XNull(DrTemp(0)("Nature"))
                    End If
                End If
                DrTemp = Nothing
        End Select

        Validating_Controls = True
    End Function
End Class
