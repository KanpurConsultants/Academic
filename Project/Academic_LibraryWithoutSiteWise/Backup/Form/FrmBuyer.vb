Public Class FrmBuyerMaster
    Inherits AgTemplate.TempMaster
    Dim mQry$ = ""
    Dim mGroupNature As String = "", mNature As String = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtBuyerCountry = New AgControls.AgTextBox
        Me.LblCountry = New System.Windows.Forms.Label
        Me.TxtBuyerEMail = New AgControls.AgTextBox
        Me.LblBuyerEMail = New System.Windows.Forms.Label
        Me.TxtBuyerFax = New AgControls.AgTextBox
        Me.LblBuyerFax = New System.Windows.Forms.Label
        Me.TxtBuyerPhone = New AgControls.AgTextBox
        Me.LblPhone = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtBuyerCity = New AgControls.AgTextBox
        Me.LblBuyerCity = New System.Windows.Forms.Label
        Me.TxtDestinationPort = New AgControls.AgTextBox
        Me.LblDestinationPort = New System.Windows.Forms.Label
        Me.LblBuyerAddressReq = New System.Windows.Forms.Label
        Me.TxtBuyerAdd2 = New AgControls.AgTextBox
        Me.TxtBuyerAdd1 = New AgControls.AgTextBox
        Me.LblBuyerAddress = New System.Windows.Forms.Label
        Me.TxtBuyerAdd3 = New AgControls.AgTextBox
        Me.LblBuyerNameReq = New System.Windows.Forms.Label
        Me.LblBuyerCodeReq = New System.Windows.Forms.Label
        Me.TxtBuyerCode = New AgControls.AgTextBox
        Me.LblBuyerCode = New System.Windows.Forms.Label
        Me.TxtBuyerDispName = New AgControls.AgTextBox
        Me.LblBuyerName = New System.Windows.Forms.Label
        Me.TxtBankAcNo = New AgControls.AgTextBox
        Me.LblBankAcNo = New System.Windows.Forms.Label
        Me.TxtBankAdd1 = New AgControls.AgTextBox
        Me.LblBankAddress = New System.Windows.Forms.Label
        Me.TxtBankName = New AgControls.AgTextBox
        Me.LblBankName = New System.Windows.Forms.Label
        Me.TxtCurrency = New AgControls.AgTextBox
        Me.LblCurrency = New System.Windows.Forms.Label
        Me.TxtMFaxNo = New AgControls.AgTextBox
        Me.LblFaxNo = New System.Windows.Forms.Label
        Me.TxtMContactNo = New AgControls.AgTextBox
        Me.LblMContactNo = New System.Windows.Forms.Label
        Me.TxtMCity = New AgControls.AgTextBox
        Me.LblMCity = New System.Windows.Forms.Label
        Me.TxtMAddress2 = New AgControls.AgTextBox
        Me.TxtMAddress1 = New AgControls.AgTextBox
        Me.LblMAddress = New System.Windows.Forms.Label
        Me.TxtContactPerson = New AgControls.AgTextBox
        Me.LblContactPerson = New System.Windows.Forms.Label
        Me.TxtTradeRegNo = New AgControls.AgTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtSisterConcern = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtMCountry = New AgControls.AgTextBox
        Me.LblMCountry = New System.Windows.Forms.Label
        Me.TxtCEmail = New AgControls.AgTextBox
        Me.LblCEmail = New System.Windows.Forms.Label
        Me.TxtCFaxNo = New AgControls.AgTextBox
        Me.LblCFaxNo = New System.Windows.Forms.Label
        Me.TxtCPhoneNo = New AgControls.AgTextBox
        Me.LblCPhoneNo = New System.Windows.Forms.Label
        Me.TxtCAdd2 = New AgControls.AgTextBox
        Me.TxtCAdd1 = New AgControls.AgTextBox
        Me.LblCAdd1 = New System.Windows.Forms.Label
        Me.TxtConsignee = New AgControls.AgTextBox
        Me.LblConsignee = New System.Windows.Forms.Label
        Me.TxtCMobile = New AgControls.AgTextBox
        Me.LblConsigneeMob = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtAcGroup = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
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
        Me.Topctrl1.TabIndex = 32
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
        'TxtBuyerCountry
        '
        Me.TxtBuyerCountry.AgMandatory = False
        Me.TxtBuyerCountry.AgMasterHelp = False
        Me.TxtBuyerCountry.AgNumberLeftPlaces = 0
        Me.TxtBuyerCountry.AgNumberNegetiveAllow = False
        Me.TxtBuyerCountry.AgNumberRightPlaces = 0
        Me.TxtBuyerCountry.AgPickFromLastValue = False
        Me.TxtBuyerCountry.AgRowFilter = ""
        Me.TxtBuyerCountry.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyerCountry.AgSelectedValue = Nothing
        Me.TxtBuyerCountry.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyerCountry.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuyerCountry.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyerCountry.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyerCountry.Location = New System.Drawing.Point(344, 191)
        Me.TxtBuyerCountry.MaxLength = 0
        Me.TxtBuyerCountry.Name = "TxtBuyerCountry"
        Me.TxtBuyerCountry.Size = New System.Drawing.Size(101, 18)
        Me.TxtBuyerCountry.TabIndex = 7
        '
        'LblCountry
        '
        Me.LblCountry.AutoSize = True
        Me.LblCountry.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCountry.Location = New System.Drawing.Point(291, 192)
        Me.LblCountry.Name = "LblCountry"
        Me.LblCountry.Size = New System.Drawing.Size(53, 16)
        Me.LblCountry.TabIndex = 804
        Me.LblCountry.Text = "Country"
        '
        'TxtBuyerEMail
        '
        Me.TxtBuyerEMail.AgMandatory = False
        Me.TxtBuyerEMail.AgMasterHelp = False
        Me.TxtBuyerEMail.AgNumberLeftPlaces = 0
        Me.TxtBuyerEMail.AgNumberNegetiveAllow = False
        Me.TxtBuyerEMail.AgNumberRightPlaces = 0
        Me.TxtBuyerEMail.AgPickFromLastValue = False
        Me.TxtBuyerEMail.AgRowFilter = ""
        Me.TxtBuyerEMail.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyerEMail.AgSelectedValue = Nothing
        Me.TxtBuyerEMail.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyerEMail.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuyerEMail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyerEMail.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyerEMail.Location = New System.Drawing.Point(153, 251)
        Me.TxtBuyerEMail.MaxLength = 100
        Me.TxtBuyerEMail.Name = "TxtBuyerEMail"
        Me.TxtBuyerEMail.Size = New System.Drawing.Size(292, 18)
        Me.TxtBuyerEMail.TabIndex = 10
        '
        'LblBuyerEMail
        '
        Me.LblBuyerEMail.AutoSize = True
        Me.LblBuyerEMail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerEMail.Location = New System.Drawing.Point(28, 251)
        Me.LblBuyerEMail.Name = "LblBuyerEMail"
        Me.LblBuyerEMail.Size = New System.Drawing.Size(41, 16)
        Me.LblBuyerEMail.TabIndex = 799
        Me.LblBuyerEMail.Text = "EMail"
        '
        'TxtBuyerFax
        '
        Me.TxtBuyerFax.AgMandatory = False
        Me.TxtBuyerFax.AgMasterHelp = False
        Me.TxtBuyerFax.AgNumberLeftPlaces = 0
        Me.TxtBuyerFax.AgNumberNegetiveAllow = False
        Me.TxtBuyerFax.AgNumberRightPlaces = 0
        Me.TxtBuyerFax.AgPickFromLastValue = False
        Me.TxtBuyerFax.AgRowFilter = ""
        Me.TxtBuyerFax.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyerFax.AgSelectedValue = Nothing
        Me.TxtBuyerFax.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyerFax.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuyerFax.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyerFax.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyerFax.Location = New System.Drawing.Point(153, 231)
        Me.TxtBuyerFax.MaxLength = 35
        Me.TxtBuyerFax.Name = "TxtBuyerFax"
        Me.TxtBuyerFax.Size = New System.Drawing.Size(292, 18)
        Me.TxtBuyerFax.TabIndex = 9
        '
        'LblBuyerFax
        '
        Me.LblBuyerFax.AutoSize = True
        Me.LblBuyerFax.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerFax.Location = New System.Drawing.Point(28, 231)
        Me.LblBuyerFax.Name = "LblBuyerFax"
        Me.LblBuyerFax.Size = New System.Drawing.Size(54, 16)
        Me.LblBuyerFax.TabIndex = 796
        Me.LblBuyerFax.Text = "Fax No,"
        '
        'TxtBuyerPhone
        '
        Me.TxtBuyerPhone.AgMandatory = False
        Me.TxtBuyerPhone.AgMasterHelp = False
        Me.TxtBuyerPhone.AgNumberLeftPlaces = 0
        Me.TxtBuyerPhone.AgNumberNegetiveAllow = False
        Me.TxtBuyerPhone.AgNumberRightPlaces = 0
        Me.TxtBuyerPhone.AgPickFromLastValue = False
        Me.TxtBuyerPhone.AgRowFilter = ""
        Me.TxtBuyerPhone.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyerPhone.AgSelectedValue = Nothing
        Me.TxtBuyerPhone.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyerPhone.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuyerPhone.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyerPhone.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyerPhone.Location = New System.Drawing.Point(153, 211)
        Me.TxtBuyerPhone.MaxLength = 35
        Me.TxtBuyerPhone.Name = "TxtBuyerPhone"
        Me.TxtBuyerPhone.Size = New System.Drawing.Size(292, 18)
        Me.TxtBuyerPhone.TabIndex = 8
        '
        'LblPhone
        '
        Me.LblPhone.AutoSize = True
        Me.LblPhone.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPhone.Location = New System.Drawing.Point(28, 211)
        Me.LblPhone.Name = "LblPhone"
        Me.LblPhone.Size = New System.Drawing.Size(77, 16)
        Me.LblPhone.TabIndex = 793
        Me.LblPhone.Text = "Contact No."
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(139, 198)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 7)
        Me.Label13.TabIndex = 791
        Me.Label13.Text = "Ä"
        '
        'TxtBuyerCity
        '
        Me.TxtBuyerCity.AgMandatory = True
        Me.TxtBuyerCity.AgMasterHelp = False
        Me.TxtBuyerCity.AgNumberLeftPlaces = 0
        Me.TxtBuyerCity.AgNumberNegetiveAllow = False
        Me.TxtBuyerCity.AgNumberRightPlaces = 0
        Me.TxtBuyerCity.AgPickFromLastValue = False
        Me.TxtBuyerCity.AgRowFilter = ""
        Me.TxtBuyerCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyerCity.AgSelectedValue = Nothing
        Me.TxtBuyerCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyerCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuyerCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyerCity.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyerCity.Location = New System.Drawing.Point(153, 191)
        Me.TxtBuyerCity.MaxLength = 0
        Me.TxtBuyerCity.Name = "TxtBuyerCity"
        Me.TxtBuyerCity.Size = New System.Drawing.Size(132, 18)
        Me.TxtBuyerCity.TabIndex = 6
        '
        'LblBuyerCity
        '
        Me.LblBuyerCity.AutoSize = True
        Me.LblBuyerCity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerCity.Location = New System.Drawing.Point(28, 191)
        Me.LblBuyerCity.Name = "LblBuyerCity"
        Me.LblBuyerCity.Size = New System.Drawing.Size(31, 16)
        Me.LblBuyerCity.TabIndex = 790
        Me.LblBuyerCity.Text = "City"
        '
        'TxtDestinationPort
        '
        Me.TxtDestinationPort.AgMandatory = False
        Me.TxtDestinationPort.AgMasterHelp = False
        Me.TxtDestinationPort.AgNumberLeftPlaces = 0
        Me.TxtDestinationPort.AgNumberNegetiveAllow = False
        Me.TxtDestinationPort.AgNumberRightPlaces = 0
        Me.TxtDestinationPort.AgPickFromLastValue = False
        Me.TxtDestinationPort.AgRowFilter = ""
        Me.TxtDestinationPort.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDestinationPort.AgSelectedValue = Nothing
        Me.TxtDestinationPort.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDestinationPort.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDestinationPort.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDestinationPort.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDestinationPort.Location = New System.Drawing.Point(153, 271)
        Me.TxtDestinationPort.MaxLength = 0
        Me.TxtDestinationPort.Name = "TxtDestinationPort"
        Me.TxtDestinationPort.Size = New System.Drawing.Size(292, 18)
        Me.TxtDestinationPort.TabIndex = 11
        '
        'LblDestinationPort
        '
        Me.LblDestinationPort.AutoSize = True
        Me.LblDestinationPort.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDestinationPort.Location = New System.Drawing.Point(28, 271)
        Me.LblDestinationPort.Name = "LblDestinationPort"
        Me.LblDestinationPort.Size = New System.Drawing.Size(101, 16)
        Me.LblDestinationPort.TabIndex = 787
        Me.LblDestinationPort.Text = "Destination Port"
        '
        'LblBuyerAddressReq
        '
        Me.LblBuyerAddressReq.AutoSize = True
        Me.LblBuyerAddressReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBuyerAddressReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBuyerAddressReq.Location = New System.Drawing.Point(138, 139)
        Me.LblBuyerAddressReq.Name = "LblBuyerAddressReq"
        Me.LblBuyerAddressReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBuyerAddressReq.TabIndex = 785
        Me.LblBuyerAddressReq.Text = "Ä"
        '
        'TxtBuyerAdd2
        '
        Me.TxtBuyerAdd2.AgMandatory = False
        Me.TxtBuyerAdd2.AgMasterHelp = True
        Me.TxtBuyerAdd2.AgNumberLeftPlaces = 8
        Me.TxtBuyerAdd2.AgNumberNegetiveAllow = False
        Me.TxtBuyerAdd2.AgNumberRightPlaces = 2
        Me.TxtBuyerAdd2.AgPickFromLastValue = False
        Me.TxtBuyerAdd2.AgRowFilter = ""
        Me.TxtBuyerAdd2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyerAdd2.AgSelectedValue = Nothing
        Me.TxtBuyerAdd2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyerAdd2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuyerAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyerAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyerAdd2.Location = New System.Drawing.Point(153, 151)
        Me.TxtBuyerAdd2.MaxLength = 50
        Me.TxtBuyerAdd2.Name = "TxtBuyerAdd2"
        Me.TxtBuyerAdd2.Size = New System.Drawing.Size(292, 18)
        Me.TxtBuyerAdd2.TabIndex = 4
        '
        'TxtBuyerAdd1
        '
        Me.TxtBuyerAdd1.AgMandatory = True
        Me.TxtBuyerAdd1.AgMasterHelp = True
        Me.TxtBuyerAdd1.AgNumberLeftPlaces = 8
        Me.TxtBuyerAdd1.AgNumberNegetiveAllow = False
        Me.TxtBuyerAdd1.AgNumberRightPlaces = 2
        Me.TxtBuyerAdd1.AgPickFromLastValue = False
        Me.TxtBuyerAdd1.AgRowFilter = ""
        Me.TxtBuyerAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyerAdd1.AgSelectedValue = Nothing
        Me.TxtBuyerAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyerAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuyerAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyerAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyerAdd1.Location = New System.Drawing.Point(153, 131)
        Me.TxtBuyerAdd1.MaxLength = 50
        Me.TxtBuyerAdd1.Name = "TxtBuyerAdd1"
        Me.TxtBuyerAdd1.Size = New System.Drawing.Size(292, 18)
        Me.TxtBuyerAdd1.TabIndex = 3
        '
        'LblBuyerAddress
        '
        Me.LblBuyerAddress.AutoSize = True
        Me.LblBuyerAddress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerAddress.Location = New System.Drawing.Point(28, 131)
        Me.LblBuyerAddress.Name = "LblBuyerAddress"
        Me.LblBuyerAddress.Size = New System.Drawing.Size(94, 16)
        Me.LblBuyerAddress.TabIndex = 784
        Me.LblBuyerAddress.Text = "Buyer Address"
        '
        'TxtBuyerAdd3
        '
        Me.TxtBuyerAdd3.AgMandatory = False
        Me.TxtBuyerAdd3.AgMasterHelp = True
        Me.TxtBuyerAdd3.AgNumberLeftPlaces = 8
        Me.TxtBuyerAdd3.AgNumberNegetiveAllow = False
        Me.TxtBuyerAdd3.AgNumberRightPlaces = 3
        Me.TxtBuyerAdd3.AgPickFromLastValue = False
        Me.TxtBuyerAdd3.AgRowFilter = ""
        Me.TxtBuyerAdd3.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyerAdd3.AgSelectedValue = Nothing
        Me.TxtBuyerAdd3.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyerAdd3.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuyerAdd3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyerAdd3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyerAdd3.Location = New System.Drawing.Point(153, 171)
        Me.TxtBuyerAdd3.MaxLength = 50
        Me.TxtBuyerAdd3.Name = "TxtBuyerAdd3"
        Me.TxtBuyerAdd3.Size = New System.Drawing.Size(292, 18)
        Me.TxtBuyerAdd3.TabIndex = 5
        '
        'LblBuyerNameReq
        '
        Me.LblBuyerNameReq.AutoSize = True
        Me.LblBuyerNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBuyerNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBuyerNameReq.Location = New System.Drawing.Point(138, 98)
        Me.LblBuyerNameReq.Name = "LblBuyerNameReq"
        Me.LblBuyerNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBuyerNameReq.TabIndex = 781
        Me.LblBuyerNameReq.Text = "Ä"
        '
        'LblBuyerCodeReq
        '
        Me.LblBuyerCodeReq.AutoSize = True
        Me.LblBuyerCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBuyerCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBuyerCodeReq.Location = New System.Drawing.Point(138, 78)
        Me.LblBuyerCodeReq.Name = "LblBuyerCodeReq"
        Me.LblBuyerCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBuyerCodeReq.TabIndex = 778
        Me.LblBuyerCodeReq.Text = "Ä"
        '
        'TxtBuyerCode
        '
        Me.TxtBuyerCode.AgMandatory = True
        Me.TxtBuyerCode.AgMasterHelp = True
        Me.TxtBuyerCode.AgNumberLeftPlaces = 0
        Me.TxtBuyerCode.AgNumberNegetiveAllow = False
        Me.TxtBuyerCode.AgNumberRightPlaces = 0
        Me.TxtBuyerCode.AgPickFromLastValue = False
        Me.TxtBuyerCode.AgRowFilter = ""
        Me.TxtBuyerCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyerCode.AgSelectedValue = Nothing
        Me.TxtBuyerCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyerCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuyerCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyerCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyerCode.Location = New System.Drawing.Point(153, 71)
        Me.TxtBuyerCode.MaxLength = 20
        Me.TxtBuyerCode.Name = "TxtBuyerCode"
        Me.TxtBuyerCode.Size = New System.Drawing.Size(171, 18)
        Me.TxtBuyerCode.TabIndex = 0
        '
        'LblBuyerCode
        '
        Me.LblBuyerCode.AutoSize = True
        Me.LblBuyerCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerCode.Location = New System.Drawing.Point(28, 71)
        Me.LblBuyerCode.Name = "LblBuyerCode"
        Me.LblBuyerCode.Size = New System.Drawing.Size(76, 16)
        Me.LblBuyerCode.TabIndex = 775
        Me.LblBuyerCode.Text = "Buyer Code"
        '
        'TxtBuyerDispName
        '
        Me.TxtBuyerDispName.AgMandatory = True
        Me.TxtBuyerDispName.AgMasterHelp = True
        Me.TxtBuyerDispName.AgNumberLeftPlaces = 0
        Me.TxtBuyerDispName.AgNumberNegetiveAllow = False
        Me.TxtBuyerDispName.AgNumberRightPlaces = 0
        Me.TxtBuyerDispName.AgPickFromLastValue = False
        Me.TxtBuyerDispName.AgRowFilter = ""
        Me.TxtBuyerDispName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyerDispName.AgSelectedValue = Nothing
        Me.TxtBuyerDispName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyerDispName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuyerDispName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyerDispName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyerDispName.Location = New System.Drawing.Point(153, 91)
        Me.TxtBuyerDispName.MaxLength = 100
        Me.TxtBuyerDispName.Name = "TxtBuyerDispName"
        Me.TxtBuyerDispName.Size = New System.Drawing.Size(292, 18)
        Me.TxtBuyerDispName.TabIndex = 1
        '
        'LblBuyerName
        '
        Me.LblBuyerName.AutoSize = True
        Me.LblBuyerName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerName.Location = New System.Drawing.Point(28, 91)
        Me.LblBuyerName.Name = "LblBuyerName"
        Me.LblBuyerName.Size = New System.Drawing.Size(80, 16)
        Me.LblBuyerName.TabIndex = 777
        Me.LblBuyerName.Text = "Buyer Name"
        '
        'TxtBankAcNo
        '
        Me.TxtBankAcNo.AgMandatory = False
        Me.TxtBankAcNo.AgMasterHelp = True
        Me.TxtBankAcNo.AgNumberLeftPlaces = 0
        Me.TxtBankAcNo.AgNumberNegetiveAllow = False
        Me.TxtBankAcNo.AgNumberRightPlaces = 0
        Me.TxtBankAcNo.AgPickFromLastValue = False
        Me.TxtBankAcNo.AgRowFilter = ""
        Me.TxtBankAcNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBankAcNo.AgSelectedValue = Nothing
        Me.TxtBankAcNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBankAcNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBankAcNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBankAcNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBankAcNo.Location = New System.Drawing.Point(153, 331)
        Me.TxtBankAcNo.MaxLength = 20
        Me.TxtBankAcNo.Name = "TxtBankAcNo"
        Me.TxtBankAcNo.Size = New System.Drawing.Size(292, 18)
        Me.TxtBankAcNo.TabIndex = 14
        '
        'LblBankAcNo
        '
        Me.LblBankAcNo.AutoSize = True
        Me.LblBankAcNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBankAcNo.Location = New System.Drawing.Point(28, 331)
        Me.LblBankAcNo.Name = "LblBankAcNo"
        Me.LblBankAcNo.Size = New System.Drawing.Size(86, 16)
        Me.LblBankAcNo.TabIndex = 815
        Me.LblBankAcNo.Text = "Bank A/c No."
        '
        'TxtBankAdd1
        '
        Me.TxtBankAdd1.AgMandatory = False
        Me.TxtBankAdd1.AgMasterHelp = True
        Me.TxtBankAdd1.AgNumberLeftPlaces = 8
        Me.TxtBankAdd1.AgNumberNegetiveAllow = False
        Me.TxtBankAdd1.AgNumberRightPlaces = 2
        Me.TxtBankAdd1.AgPickFromLastValue = False
        Me.TxtBankAdd1.AgRowFilter = ""
        Me.TxtBankAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBankAdd1.AgSelectedValue = Nothing
        Me.TxtBankAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBankAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBankAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBankAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBankAdd1.Location = New System.Drawing.Point(153, 311)
        Me.TxtBankAdd1.MaxLength = 100
        Me.TxtBankAdd1.Name = "TxtBankAdd1"
        Me.TxtBankAdd1.Size = New System.Drawing.Size(292, 18)
        Me.TxtBankAdd1.TabIndex = 13
        '
        'LblBankAddress
        '
        Me.LblBankAddress.AutoSize = True
        Me.LblBankAddress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBankAddress.Location = New System.Drawing.Point(28, 311)
        Me.LblBankAddress.Name = "LblBankAddress"
        Me.LblBankAddress.Size = New System.Drawing.Size(90, 16)
        Me.LblBankAddress.TabIndex = 813
        Me.LblBankAddress.Text = "Bank Address"
        '
        'TxtBankName
        '
        Me.TxtBankName.AgMandatory = False
        Me.TxtBankName.AgMasterHelp = True
        Me.TxtBankName.AgNumberLeftPlaces = 0
        Me.TxtBankName.AgNumberNegetiveAllow = False
        Me.TxtBankName.AgNumberRightPlaces = 0
        Me.TxtBankName.AgPickFromLastValue = False
        Me.TxtBankName.AgRowFilter = ""
        Me.TxtBankName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBankName.AgSelectedValue = Nothing
        Me.TxtBankName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBankName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBankName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBankName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBankName.Location = New System.Drawing.Point(153, 291)
        Me.TxtBankName.MaxLength = 50
        Me.TxtBankName.Name = "TxtBankName"
        Me.TxtBankName.Size = New System.Drawing.Size(292, 18)
        Me.TxtBankName.TabIndex = 12
        '
        'LblBankName
        '
        Me.LblBankName.AutoSize = True
        Me.LblBankName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBankName.Location = New System.Drawing.Point(28, 291)
        Me.LblBankName.Name = "LblBankName"
        Me.LblBankName.Size = New System.Drawing.Size(114, 16)
        Me.LblBankName.TabIndex = 809
        Me.LblBankName.Text = "Buyer Bank Name"
        '
        'TxtCurrency
        '
        Me.TxtCurrency.AgMandatory = False
        Me.TxtCurrency.AgMasterHelp = False
        Me.TxtCurrency.AgNumberLeftPlaces = 0
        Me.TxtCurrency.AgNumberNegetiveAllow = False
        Me.TxtCurrency.AgNumberRightPlaces = 0
        Me.TxtCurrency.AgPickFromLastValue = False
        Me.TxtCurrency.AgRowFilter = ""
        Me.TxtCurrency.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCurrency.AgSelectedValue = Nothing
        Me.TxtCurrency.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCurrency.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCurrency.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCurrency.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrency.Location = New System.Drawing.Point(585, 71)
        Me.TxtCurrency.MaxLength = 0
        Me.TxtCurrency.Name = "TxtCurrency"
        Me.TxtCurrency.Size = New System.Drawing.Size(100, 18)
        Me.TxtCurrency.TabIndex = 15
        '
        'LblCurrency
        '
        Me.LblCurrency.AutoSize = True
        Me.LblCurrency.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrency.Location = New System.Drawing.Point(475, 71)
        Me.LblCurrency.Name = "LblCurrency"
        Me.LblCurrency.Size = New System.Drawing.Size(60, 16)
        Me.LblCurrency.TabIndex = 807
        Me.LblCurrency.Text = "Currency"
        '
        'TxtMFaxNo
        '
        Me.TxtMFaxNo.AgMandatory = False
        Me.TxtMFaxNo.AgMasterHelp = False
        Me.TxtMFaxNo.AgNumberLeftPlaces = 0
        Me.TxtMFaxNo.AgNumberNegetiveAllow = False
        Me.TxtMFaxNo.AgNumberRightPlaces = 0
        Me.TxtMFaxNo.AgPickFromLastValue = False
        Me.TxtMFaxNo.AgRowFilter = ""
        Me.TxtMFaxNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMFaxNo.AgSelectedValue = Nothing
        Me.TxtMFaxNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMFaxNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMFaxNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMFaxNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMFaxNo.Location = New System.Drawing.Point(585, 211)
        Me.TxtMFaxNo.MaxLength = 35
        Me.TxtMFaxNo.Name = "TxtMFaxNo"
        Me.TxtMFaxNo.Size = New System.Drawing.Size(294, 18)
        Me.TxtMFaxNo.TabIndex = 24
        '
        'LblFaxNo
        '
        Me.LblFaxNo.AutoSize = True
        Me.LblFaxNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFaxNo.Location = New System.Drawing.Point(475, 211)
        Me.LblFaxNo.Name = "LblFaxNo"
        Me.LblFaxNo.Size = New System.Drawing.Size(54, 16)
        Me.LblFaxNo.TabIndex = 832
        Me.LblFaxNo.Text = "Fax No,"
        '
        'TxtMContactNo
        '
        Me.TxtMContactNo.AgMandatory = False
        Me.TxtMContactNo.AgMasterHelp = False
        Me.TxtMContactNo.AgNumberLeftPlaces = 0
        Me.TxtMContactNo.AgNumberNegetiveAllow = False
        Me.TxtMContactNo.AgNumberRightPlaces = 0
        Me.TxtMContactNo.AgPickFromLastValue = False
        Me.TxtMContactNo.AgRowFilter = ""
        Me.TxtMContactNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMContactNo.AgSelectedValue = Nothing
        Me.TxtMContactNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMContactNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMContactNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMContactNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMContactNo.Location = New System.Drawing.Point(585, 191)
        Me.TxtMContactNo.MaxLength = 35
        Me.TxtMContactNo.Name = "TxtMContactNo"
        Me.TxtMContactNo.Size = New System.Drawing.Size(294, 18)
        Me.TxtMContactNo.TabIndex = 23
        '
        'LblMContactNo
        '
        Me.LblMContactNo.AutoSize = True
        Me.LblMContactNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMContactNo.Location = New System.Drawing.Point(475, 191)
        Me.LblMContactNo.Name = "LblMContactNo"
        Me.LblMContactNo.Size = New System.Drawing.Size(77, 16)
        Me.LblMContactNo.TabIndex = 829
        Me.LblMContactNo.Text = "Contact No."
        '
        'TxtMCity
        '
        Me.TxtMCity.AgMandatory = False
        Me.TxtMCity.AgMasterHelp = False
        Me.TxtMCity.AgNumberLeftPlaces = 0
        Me.TxtMCity.AgNumberNegetiveAllow = False
        Me.TxtMCity.AgNumberRightPlaces = 0
        Me.TxtMCity.AgPickFromLastValue = False
        Me.TxtMCity.AgRowFilter = ""
        Me.TxtMCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMCity.AgSelectedValue = Nothing
        Me.TxtMCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMCity.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMCity.Location = New System.Drawing.Point(585, 171)
        Me.TxtMCity.MaxLength = 0
        Me.TxtMCity.Name = "TxtMCity"
        Me.TxtMCity.Size = New System.Drawing.Size(137, 18)
        Me.TxtMCity.TabIndex = 21
        '
        'LblMCity
        '
        Me.LblMCity.AutoSize = True
        Me.LblMCity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMCity.Location = New System.Drawing.Point(475, 171)
        Me.LblMCity.Name = "LblMCity"
        Me.LblMCity.Size = New System.Drawing.Size(31, 16)
        Me.LblMCity.TabIndex = 826
        Me.LblMCity.Text = "City"
        '
        'TxtMAddress2
        '
        Me.TxtMAddress2.AgMandatory = False
        Me.TxtMAddress2.AgMasterHelp = True
        Me.TxtMAddress2.AgNumberLeftPlaces = 8
        Me.TxtMAddress2.AgNumberNegetiveAllow = False
        Me.TxtMAddress2.AgNumberRightPlaces = 2
        Me.TxtMAddress2.AgPickFromLastValue = False
        Me.TxtMAddress2.AgRowFilter = ""
        Me.TxtMAddress2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMAddress2.AgSelectedValue = Nothing
        Me.TxtMAddress2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMAddress2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMAddress2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMAddress2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMAddress2.Location = New System.Drawing.Point(585, 151)
        Me.TxtMAddress2.MaxLength = 100
        Me.TxtMAddress2.Name = "TxtMAddress2"
        Me.TxtMAddress2.Size = New System.Drawing.Size(294, 18)
        Me.TxtMAddress2.TabIndex = 20
        '
        'TxtMAddress1
        '
        Me.TxtMAddress1.AgMandatory = False
        Me.TxtMAddress1.AgMasterHelp = True
        Me.TxtMAddress1.AgNumberLeftPlaces = 8
        Me.TxtMAddress1.AgNumberNegetiveAllow = False
        Me.TxtMAddress1.AgNumberRightPlaces = 2
        Me.TxtMAddress1.AgPickFromLastValue = False
        Me.TxtMAddress1.AgRowFilter = ""
        Me.TxtMAddress1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMAddress1.AgSelectedValue = Nothing
        Me.TxtMAddress1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMAddress1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMAddress1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMAddress1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMAddress1.Location = New System.Drawing.Point(585, 131)
        Me.TxtMAddress1.MaxLength = 100
        Me.TxtMAddress1.Name = "TxtMAddress1"
        Me.TxtMAddress1.Size = New System.Drawing.Size(294, 18)
        Me.TxtMAddress1.TabIndex = 19
        '
        'LblMAddress
        '
        Me.LblMAddress.AutoSize = True
        Me.LblMAddress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMAddress.Location = New System.Drawing.Point(475, 131)
        Me.LblMAddress.Name = "LblMAddress"
        Me.LblMAddress.Size = New System.Drawing.Size(101, 16)
        Me.LblMAddress.TabIndex = 823
        Me.LblMAddress.Text = "Mailing Address"
        '
        'TxtContactPerson
        '
        Me.TxtContactPerson.AgMandatory = False
        Me.TxtContactPerson.AgMasterHelp = True
        Me.TxtContactPerson.AgNumberLeftPlaces = 0
        Me.TxtContactPerson.AgNumberNegetiveAllow = False
        Me.TxtContactPerson.AgNumberRightPlaces = 0
        Me.TxtContactPerson.AgPickFromLastValue = False
        Me.TxtContactPerson.AgRowFilter = ""
        Me.TxtContactPerson.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtContactPerson.AgSelectedValue = Nothing
        Me.TxtContactPerson.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtContactPerson.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtContactPerson.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtContactPerson.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtContactPerson.Location = New System.Drawing.Point(585, 111)
        Me.TxtContactPerson.MaxLength = 50
        Me.TxtContactPerson.Name = "TxtContactPerson"
        Me.TxtContactPerson.Size = New System.Drawing.Size(294, 18)
        Me.TxtContactPerson.TabIndex = 18
        '
        'LblContactPerson
        '
        Me.LblContactPerson.AutoSize = True
        Me.LblContactPerson.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblContactPerson.Location = New System.Drawing.Point(475, 111)
        Me.LblContactPerson.Name = "LblContactPerson"
        Me.LblContactPerson.Size = New System.Drawing.Size(98, 16)
        Me.LblContactPerson.TabIndex = 818
        Me.LblContactPerson.Text = "Contact Person"
        '
        'TxtTradeRegNo
        '
        Me.TxtTradeRegNo.AgMandatory = False
        Me.TxtTradeRegNo.AgMasterHelp = False
        Me.TxtTradeRegNo.AgNumberLeftPlaces = 0
        Me.TxtTradeRegNo.AgNumberNegetiveAllow = False
        Me.TxtTradeRegNo.AgNumberRightPlaces = 0
        Me.TxtTradeRegNo.AgPickFromLastValue = False
        Me.TxtTradeRegNo.AgRowFilter = ""
        Me.TxtTradeRegNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTradeRegNo.AgSelectedValue = Nothing
        Me.TxtTradeRegNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTradeRegNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTradeRegNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTradeRegNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTradeRegNo.Location = New System.Drawing.Point(585, 91)
        Me.TxtTradeRegNo.MaxLength = 0
        Me.TxtTradeRegNo.Name = "TxtTradeRegNo"
        Me.TxtTradeRegNo.Size = New System.Drawing.Size(294, 18)
        Me.TxtTradeRegNo.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(475, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 16)
        Me.Label10.TabIndex = 835
        Me.Label10.Text = "Trade Regn No."
        '
        'TxtSisterConcern
        '
        Me.TxtSisterConcern.AgMandatory = False
        Me.TxtSisterConcern.AgMasterHelp = False
        Me.TxtSisterConcern.AgNumberLeftPlaces = 0
        Me.TxtSisterConcern.AgNumberNegetiveAllow = False
        Me.TxtSisterConcern.AgNumberRightPlaces = 0
        Me.TxtSisterConcern.AgPickFromLastValue = False
        Me.TxtSisterConcern.AgRowFilter = ""
        Me.TxtSisterConcern.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSisterConcern.AgSelectedValue = Nothing
        Me.TxtSisterConcern.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSisterConcern.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtSisterConcern.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSisterConcern.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSisterConcern.Location = New System.Drawing.Point(821, 71)
        Me.TxtSisterConcern.MaxLength = 0
        Me.TxtSisterConcern.Name = "TxtSisterConcern"
        Me.TxtSisterConcern.Size = New System.Drawing.Size(58, 18)
        Me.TxtSisterConcern.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(691, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 16)
        Me.Label2.TabIndex = 839
        Me.Label2.Text = "Sister Concern (Y/N)"
        '
        'TxtMCountry
        '
        Me.TxtMCountry.AgMandatory = False
        Me.TxtMCountry.AgMasterHelp = False
        Me.TxtMCountry.AgNumberLeftPlaces = 0
        Me.TxtMCountry.AgNumberNegetiveAllow = False
        Me.TxtMCountry.AgNumberRightPlaces = 0
        Me.TxtMCountry.AgPickFromLastValue = False
        Me.TxtMCountry.AgRowFilter = ""
        Me.TxtMCountry.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMCountry.AgSelectedValue = Nothing
        Me.TxtMCountry.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMCountry.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMCountry.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMCountry.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMCountry.Location = New System.Drawing.Point(778, 171)
        Me.TxtMCountry.MaxLength = 0
        Me.TxtMCountry.Name = "TxtMCountry"
        Me.TxtMCountry.Size = New System.Drawing.Size(101, 18)
        Me.TxtMCountry.TabIndex = 22
        '
        'LblMCountry
        '
        Me.LblMCountry.AutoSize = True
        Me.LblMCountry.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMCountry.Location = New System.Drawing.Point(723, 174)
        Me.LblMCountry.Name = "LblMCountry"
        Me.LblMCountry.Size = New System.Drawing.Size(53, 16)
        Me.LblMCountry.TabIndex = 841
        Me.LblMCountry.Text = "Country"
        '
        'TxtCEmail
        '
        Me.TxtCEmail.AgMandatory = False
        Me.TxtCEmail.AgMasterHelp = False
        Me.TxtCEmail.AgNumberLeftPlaces = 0
        Me.TxtCEmail.AgNumberNegetiveAllow = False
        Me.TxtCEmail.AgNumberRightPlaces = 0
        Me.TxtCEmail.AgPickFromLastValue = False
        Me.TxtCEmail.AgRowFilter = ""
        Me.TxtCEmail.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCEmail.AgSelectedValue = Nothing
        Me.TxtCEmail.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCEmail.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCEmail.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCEmail.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCEmail.Location = New System.Drawing.Point(585, 331)
        Me.TxtCEmail.MaxLength = 100
        Me.TxtCEmail.Name = "TxtCEmail"
        Me.TxtCEmail.Size = New System.Drawing.Size(294, 18)
        Me.TxtCEmail.TabIndex = 31
        '
        'LblCEmail
        '
        Me.LblCEmail.AutoSize = True
        Me.LblCEmail.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCEmail.Location = New System.Drawing.Point(475, 333)
        Me.LblCEmail.Name = "LblCEmail"
        Me.LblCEmail.Size = New System.Drawing.Size(41, 16)
        Me.LblCEmail.TabIndex = 856
        Me.LblCEmail.Text = "EMail"
        '
        'TxtCFaxNo
        '
        Me.TxtCFaxNo.AgMandatory = False
        Me.TxtCFaxNo.AgMasterHelp = False
        Me.TxtCFaxNo.AgNumberLeftPlaces = 0
        Me.TxtCFaxNo.AgNumberNegetiveAllow = False
        Me.TxtCFaxNo.AgNumberRightPlaces = 0
        Me.TxtCFaxNo.AgPickFromLastValue = False
        Me.TxtCFaxNo.AgRowFilter = ""
        Me.TxtCFaxNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCFaxNo.AgSelectedValue = Nothing
        Me.TxtCFaxNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCFaxNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCFaxNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCFaxNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCFaxNo.Location = New System.Drawing.Point(585, 311)
        Me.TxtCFaxNo.MaxLength = 35
        Me.TxtCFaxNo.Name = "TxtCFaxNo"
        Me.TxtCFaxNo.Size = New System.Drawing.Size(294, 18)
        Me.TxtCFaxNo.TabIndex = 30
        '
        'LblCFaxNo
        '
        Me.LblCFaxNo.AutoSize = True
        Me.LblCFaxNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCFaxNo.Location = New System.Drawing.Point(475, 311)
        Me.LblCFaxNo.Name = "LblCFaxNo"
        Me.LblCFaxNo.Size = New System.Drawing.Size(54, 16)
        Me.LblCFaxNo.TabIndex = 853
        Me.LblCFaxNo.Text = "Fax No,"
        '
        'TxtCPhoneNo
        '
        Me.TxtCPhoneNo.AgMandatory = False
        Me.TxtCPhoneNo.AgMasterHelp = False
        Me.TxtCPhoneNo.AgNumberLeftPlaces = 0
        Me.TxtCPhoneNo.AgNumberNegetiveAllow = False
        Me.TxtCPhoneNo.AgNumberRightPlaces = 0
        Me.TxtCPhoneNo.AgPickFromLastValue = False
        Me.TxtCPhoneNo.AgRowFilter = ""
        Me.TxtCPhoneNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCPhoneNo.AgSelectedValue = Nothing
        Me.TxtCPhoneNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCPhoneNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCPhoneNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCPhoneNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCPhoneNo.Location = New System.Drawing.Point(585, 291)
        Me.TxtCPhoneNo.MaxLength = 35
        Me.TxtCPhoneNo.Name = "TxtCPhoneNo"
        Me.TxtCPhoneNo.Size = New System.Drawing.Size(116, 18)
        Me.TxtCPhoneNo.TabIndex = 28
        '
        'LblCPhoneNo
        '
        Me.LblCPhoneNo.AutoSize = True
        Me.LblCPhoneNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCPhoneNo.Location = New System.Drawing.Point(475, 291)
        Me.LblCPhoneNo.Name = "LblCPhoneNo"
        Me.LblCPhoneNo.Size = New System.Drawing.Size(69, 16)
        Me.LblCPhoneNo.TabIndex = 850
        Me.LblCPhoneNo.Text = "Phone No."
        '
        'TxtCAdd2
        '
        Me.TxtCAdd2.AgMandatory = False
        Me.TxtCAdd2.AgMasterHelp = True
        Me.TxtCAdd2.AgNumberLeftPlaces = 8
        Me.TxtCAdd2.AgNumberNegetiveAllow = False
        Me.TxtCAdd2.AgNumberRightPlaces = 2
        Me.TxtCAdd2.AgPickFromLastValue = False
        Me.TxtCAdd2.AgRowFilter = ""
        Me.TxtCAdd2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCAdd2.AgSelectedValue = Nothing
        Me.TxtCAdd2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCAdd2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCAdd2.Location = New System.Drawing.Point(585, 271)
        Me.TxtCAdd2.MaxLength = 100
        Me.TxtCAdd2.Name = "TxtCAdd2"
        Me.TxtCAdd2.Size = New System.Drawing.Size(294, 18)
        Me.TxtCAdd2.TabIndex = 27
        '
        'TxtCAdd1
        '
        Me.TxtCAdd1.AgMandatory = False
        Me.TxtCAdd1.AgMasterHelp = True
        Me.TxtCAdd1.AgNumberLeftPlaces = 8
        Me.TxtCAdd1.AgNumberNegetiveAllow = False
        Me.TxtCAdd1.AgNumberRightPlaces = 2
        Me.TxtCAdd1.AgPickFromLastValue = False
        Me.TxtCAdd1.AgRowFilter = ""
        Me.TxtCAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCAdd1.AgSelectedValue = Nothing
        Me.TxtCAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCAdd1.Location = New System.Drawing.Point(585, 251)
        Me.TxtCAdd1.MaxLength = 100
        Me.TxtCAdd1.Name = "TxtCAdd1"
        Me.TxtCAdd1.Size = New System.Drawing.Size(294, 18)
        Me.TxtCAdd1.TabIndex = 26
        '
        'LblCAdd1
        '
        Me.LblCAdd1.AutoSize = True
        Me.LblCAdd1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCAdd1.Location = New System.Drawing.Point(475, 251)
        Me.LblCAdd1.Name = "LblCAdd1"
        Me.LblCAdd1.Size = New System.Drawing.Size(56, 16)
        Me.LblCAdd1.TabIndex = 847
        Me.LblCAdd1.Text = "Address"
        '
        'TxtConsignee
        '
        Me.TxtConsignee.AgMandatory = False
        Me.TxtConsignee.AgMasterHelp = True
        Me.TxtConsignee.AgNumberLeftPlaces = 0
        Me.TxtConsignee.AgNumberNegetiveAllow = False
        Me.TxtConsignee.AgNumberRightPlaces = 0
        Me.TxtConsignee.AgPickFromLastValue = False
        Me.TxtConsignee.AgRowFilter = ""
        Me.TxtConsignee.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtConsignee.AgSelectedValue = Nothing
        Me.TxtConsignee.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtConsignee.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtConsignee.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtConsignee.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConsignee.Location = New System.Drawing.Point(585, 231)
        Me.TxtConsignee.MaxLength = 50
        Me.TxtConsignee.Name = "TxtConsignee"
        Me.TxtConsignee.Size = New System.Drawing.Size(294, 18)
        Me.TxtConsignee.TabIndex = 25
        '
        'LblConsignee
        '
        Me.LblConsignee.AutoSize = True
        Me.LblConsignee.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConsignee.Location = New System.Drawing.Point(475, 231)
        Me.LblConsignee.Name = "LblConsignee"
        Me.LblConsignee.Size = New System.Drawing.Size(69, 16)
        Me.LblConsignee.TabIndex = 842
        Me.LblConsignee.Text = "Consignee"
        '
        'TxtCMobile
        '
        Me.TxtCMobile.AgMandatory = False
        Me.TxtCMobile.AgMasterHelp = False
        Me.TxtCMobile.AgNumberLeftPlaces = 0
        Me.TxtCMobile.AgNumberNegetiveAllow = False
        Me.TxtCMobile.AgNumberRightPlaces = 0
        Me.TxtCMobile.AgPickFromLastValue = False
        Me.TxtCMobile.AgRowFilter = ""
        Me.TxtCMobile.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCMobile.AgSelectedValue = Nothing
        Me.TxtCMobile.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCMobile.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCMobile.Location = New System.Drawing.Point(759, 291)
        Me.TxtCMobile.MaxLength = 12
        Me.TxtCMobile.Name = "TxtCMobile"
        Me.TxtCMobile.Size = New System.Drawing.Size(120, 18)
        Me.TxtCMobile.TabIndex = 29
        '
        'LblConsigneeMob
        '
        Me.LblConsigneeMob.AutoSize = True
        Me.LblConsigneeMob.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblConsigneeMob.Location = New System.Drawing.Point(707, 292)
        Me.LblConsigneeMob.Name = "LblConsigneeMob"
        Me.LblConsigneeMob.Size = New System.Drawing.Size(46, 16)
        Me.LblConsigneeMob.TabIndex = 858
        Me.LblConsigneeMob.Text = "Mobile"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(138, 118)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 7)
        Me.Label3.TabIndex = 861
        Me.Label3.Text = "Ä"
        '
        'TxtAcGroup
        '
        Me.TxtAcGroup.AgMandatory = True
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
        Me.TxtAcGroup.Location = New System.Drawing.Point(153, 111)
        Me.TxtAcGroup.MaxLength = 100
        Me.TxtAcGroup.Name = "TxtAcGroup"
        Me.TxtAcGroup.Size = New System.Drawing.Size(292, 18)
        Me.TxtAcGroup.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(28, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 16)
        Me.Label4.TabIndex = 860
        Me.Label4.Text = "A/c Group"
        '
        'FrmBuyerMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(907, 486)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtAcGroup)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCMobile)
        Me.Controls.Add(Me.LblConsigneeMob)
        Me.Controls.Add(Me.TxtCEmail)
        Me.Controls.Add(Me.LblCEmail)
        Me.Controls.Add(Me.TxtCFaxNo)
        Me.Controls.Add(Me.LblCFaxNo)
        Me.Controls.Add(Me.TxtCPhoneNo)
        Me.Controls.Add(Me.LblCPhoneNo)
        Me.Controls.Add(Me.TxtCAdd2)
        Me.Controls.Add(Me.TxtCAdd1)
        Me.Controls.Add(Me.LblCAdd1)
        Me.Controls.Add(Me.TxtConsignee)
        Me.Controls.Add(Me.LblConsignee)
        Me.Controls.Add(Me.TxtMCountry)
        Me.Controls.Add(Me.LblMCountry)
        Me.Controls.Add(Me.TxtSisterConcern)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtTradeRegNo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtMFaxNo)
        Me.Controls.Add(Me.LblFaxNo)
        Me.Controls.Add(Me.TxtMContactNo)
        Me.Controls.Add(Me.LblMContactNo)
        Me.Controls.Add(Me.TxtMCity)
        Me.Controls.Add(Me.LblMCity)
        Me.Controls.Add(Me.TxtMAddress2)
        Me.Controls.Add(Me.TxtMAddress1)
        Me.Controls.Add(Me.LblMAddress)
        Me.Controls.Add(Me.TxtContactPerson)
        Me.Controls.Add(Me.LblContactPerson)
        Me.Controls.Add(Me.TxtBankAcNo)
        Me.Controls.Add(Me.LblBankAcNo)
        Me.Controls.Add(Me.TxtBankAdd1)
        Me.Controls.Add(Me.LblBankAddress)
        Me.Controls.Add(Me.TxtBankName)
        Me.Controls.Add(Me.LblBankName)
        Me.Controls.Add(Me.TxtCurrency)
        Me.Controls.Add(Me.LblCurrency)
        Me.Controls.Add(Me.TxtBuyerCountry)
        Me.Controls.Add(Me.LblCountry)
        Me.Controls.Add(Me.TxtBuyerEMail)
        Me.Controls.Add(Me.LblBuyerEMail)
        Me.Controls.Add(Me.TxtBuyerFax)
        Me.Controls.Add(Me.LblBuyerFax)
        Me.Controls.Add(Me.TxtBuyerPhone)
        Me.Controls.Add(Me.LblPhone)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtBuyerCity)
        Me.Controls.Add(Me.LblBuyerCity)
        Me.Controls.Add(Me.TxtDestinationPort)
        Me.Controls.Add(Me.LblDestinationPort)
        Me.Controls.Add(Me.LblBuyerAddressReq)
        Me.Controls.Add(Me.TxtBuyerAdd2)
        Me.Controls.Add(Me.TxtBuyerAdd1)
        Me.Controls.Add(Me.LblBuyerAddress)
        Me.Controls.Add(Me.TxtBuyerAdd3)
        Me.Controls.Add(Me.LblBuyerNameReq)
        Me.Controls.Add(Me.LblBuyerCodeReq)
        Me.Controls.Add(Me.TxtBuyerCode)
        Me.Controls.Add(Me.LblBuyerCode)
        Me.Controls.Add(Me.TxtBuyerDispName)
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
        Me.Controls.SetChildIndex(Me.TxtBuyerDispName, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerCode, 0)
        Me.Controls.SetChildIndex(Me.TxtBuyerCode, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerCodeReq, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerNameReq, 0)
        Me.Controls.SetChildIndex(Me.TxtBuyerAdd3, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerAddress, 0)
        Me.Controls.SetChildIndex(Me.TxtBuyerAdd1, 0)
        Me.Controls.SetChildIndex(Me.TxtBuyerAdd2, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerAddressReq, 0)
        Me.Controls.SetChildIndex(Me.LblDestinationPort, 0)
        Me.Controls.SetChildIndex(Me.TxtDestinationPort, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerCity, 0)
        Me.Controls.SetChildIndex(Me.TxtBuyerCity, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.LblPhone, 0)
        Me.Controls.SetChildIndex(Me.TxtBuyerPhone, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerFax, 0)
        Me.Controls.SetChildIndex(Me.TxtBuyerFax, 0)
        Me.Controls.SetChildIndex(Me.LblBuyerEMail, 0)
        Me.Controls.SetChildIndex(Me.TxtBuyerEMail, 0)
        Me.Controls.SetChildIndex(Me.LblCountry, 0)
        Me.Controls.SetChildIndex(Me.TxtBuyerCountry, 0)
        Me.Controls.SetChildIndex(Me.LblCurrency, 0)
        Me.Controls.SetChildIndex(Me.TxtCurrency, 0)
        Me.Controls.SetChildIndex(Me.LblBankName, 0)
        Me.Controls.SetChildIndex(Me.TxtBankName, 0)
        Me.Controls.SetChildIndex(Me.LblBankAddress, 0)
        Me.Controls.SetChildIndex(Me.TxtBankAdd1, 0)
        Me.Controls.SetChildIndex(Me.LblBankAcNo, 0)
        Me.Controls.SetChildIndex(Me.TxtBankAcNo, 0)
        Me.Controls.SetChildIndex(Me.LblContactPerson, 0)
        Me.Controls.SetChildIndex(Me.TxtContactPerson, 0)
        Me.Controls.SetChildIndex(Me.LblMAddress, 0)
        Me.Controls.SetChildIndex(Me.TxtMAddress1, 0)
        Me.Controls.SetChildIndex(Me.TxtMAddress2, 0)
        Me.Controls.SetChildIndex(Me.LblMCity, 0)
        Me.Controls.SetChildIndex(Me.TxtMCity, 0)
        Me.Controls.SetChildIndex(Me.LblMContactNo, 0)
        Me.Controls.SetChildIndex(Me.TxtMContactNo, 0)
        Me.Controls.SetChildIndex(Me.LblFaxNo, 0)
        Me.Controls.SetChildIndex(Me.TxtMFaxNo, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.TxtTradeRegNo, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtSisterConcern, 0)
        Me.Controls.SetChildIndex(Me.LblMCountry, 0)
        Me.Controls.SetChildIndex(Me.TxtMCountry, 0)
        Me.Controls.SetChildIndex(Me.LblConsignee, 0)
        Me.Controls.SetChildIndex(Me.TxtConsignee, 0)
        Me.Controls.SetChildIndex(Me.LblCAdd1, 0)
        Me.Controls.SetChildIndex(Me.TxtCAdd1, 0)
        Me.Controls.SetChildIndex(Me.TxtCAdd2, 0)
        Me.Controls.SetChildIndex(Me.LblCPhoneNo, 0)
        Me.Controls.SetChildIndex(Me.TxtCPhoneNo, 0)
        Me.Controls.SetChildIndex(Me.LblCFaxNo, 0)
        Me.Controls.SetChildIndex(Me.TxtCFaxNo, 0)
        Me.Controls.SetChildIndex(Me.LblCEmail, 0)
        Me.Controls.SetChildIndex(Me.TxtCEmail, 0)
        Me.Controls.SetChildIndex(Me.LblConsigneeMob, 0)
        Me.Controls.SetChildIndex(Me.TxtCMobile, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtAcGroup, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
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

    Friend WithEvents LblBuyerName As System.Windows.Forms.Label
    Friend WithEvents TxtBankAcNo As AgControls.AgTextBox
    Friend WithEvents LblBankAcNo As System.Windows.Forms.Label
    Friend WithEvents TxtBankAdd1 As AgControls.AgTextBox
    Friend WithEvents LblBankAddress As System.Windows.Forms.Label
    Friend WithEvents TxtBankName As AgControls.AgTextBox
    Friend WithEvents LblBankName As System.Windows.Forms.Label
    Friend WithEvents TxtCurrency As AgControls.AgTextBox
    Friend WithEvents LblCurrency As System.Windows.Forms.Label
    Friend WithEvents TxtMFaxNo As AgControls.AgTextBox
    Friend WithEvents LblFaxNo As System.Windows.Forms.Label
    Friend WithEvents TxtMContactNo As AgControls.AgTextBox
    Friend WithEvents LblMContactNo As System.Windows.Forms.Label
    Friend WithEvents TxtMCity As AgControls.AgTextBox
    Friend WithEvents LblMCity As System.Windows.Forms.Label
    Friend WithEvents TxtMAddress2 As AgControls.AgTextBox
    Friend WithEvents TxtMAddress1 As AgControls.AgTextBox
    Friend WithEvents LblMAddress As System.Windows.Forms.Label
    Friend WithEvents TxtContactPerson As AgControls.AgTextBox
    Friend WithEvents LblContactPerson As System.Windows.Forms.Label
    Friend WithEvents TxtTradeRegNo As AgControls.AgTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtSisterConcern As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtMCountry As AgControls.AgTextBox
    Friend WithEvents LblMCountry As System.Windows.Forms.Label
    Friend WithEvents TxtCEmail As AgControls.AgTextBox
    Friend WithEvents LblCEmail As System.Windows.Forms.Label
    Friend WithEvents TxtCFaxNo As AgControls.AgTextBox
    Friend WithEvents LblCFaxNo As System.Windows.Forms.Label
    Friend WithEvents TxtCPhoneNo As AgControls.AgTextBox
    Friend WithEvents LblCPhoneNo As System.Windows.Forms.Label
    Friend WithEvents TxtCAdd2 As AgControls.AgTextBox
    Friend WithEvents TxtCAdd1 As AgControls.AgTextBox
    Friend WithEvents LblCAdd1 As System.Windows.Forms.Label
    Friend WithEvents TxtConsignee As AgControls.AgTextBox
    Friend WithEvents LblConsignee As System.Windows.Forms.Label
    Friend WithEvents TxtCMobile As AgControls.AgTextBox
    Friend WithEvents LblConsigneeMob As System.Windows.Forms.Label
    Friend WithEvents TxtBuyerDispName As AgControls.AgTextBox
    Friend WithEvents LblBuyerCode As System.Windows.Forms.Label
    Friend WithEvents TxtBuyerCode As AgControls.AgTextBox
    Friend WithEvents LblBuyerCodeReq As System.Windows.Forms.Label
    Friend WithEvents LblBuyerNameReq As System.Windows.Forms.Label
    Friend WithEvents TxtBuyerAdd3 As AgControls.AgTextBox
    Friend WithEvents LblBuyerAddress As System.Windows.Forms.Label
    Friend WithEvents TxtBuyerAdd1 As AgControls.AgTextBox
    Friend WithEvents TxtBuyerAdd2 As AgControls.AgTextBox
    Friend WithEvents LblBuyerAddressReq As System.Windows.Forms.Label
    Friend WithEvents LblDestinationPort As System.Windows.Forms.Label
    Friend WithEvents TxtDestinationPort As AgControls.AgTextBox
    Friend WithEvents LblBuyerCity As System.Windows.Forms.Label
    Friend WithEvents TxtBuyerCity As AgControls.AgTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblPhone As System.Windows.Forms.Label
    Friend WithEvents TxtBuyerPhone As AgControls.AgTextBox
    Friend WithEvents LblBuyerFax As System.Windows.Forms.Label
    Friend WithEvents TxtBuyerFax As AgControls.AgTextBox
    Friend WithEvents LblBuyerEMail As System.Windows.Forms.Label
    Friend WithEvents TxtBuyerEMail As AgControls.AgTextBox
    Friend WithEvents LblCountry As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtAcGroup As AgControls.AgTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtBuyerCountry As AgControls.AgTextBox



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
        AgL.PubFindQry = "SELECT B.UID, S.ManualCode as [Buyer Code], S.DispName as [Buyer Name], " & _
                        " C.CityName as City , Co.Name as Country, S.Phone, S.Fax " & _
                        " FROM Buyer_Log B " & _
                        " LEFT JOIN SubGroup_Log S On B.UID = S.UID  " & _
                        " LEFT JOIN CIty C On S.CityCode = C.CityCode " & _
                        " LEFT JOIN Country Co On S.CountryCode = Co.Code " & _
                        " WHERE S.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Buyer Code]"
    End Sub

    Private Sub FrmShade_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        AgL.PubFindQry = "SELECT B.SubCode, S.ManualCode as [Buyer Code], S.DispName as [Buyer Name], " & _
                        " C.CityName as City , Co.Name as Country, S.Phone, S.Fax  " & _
                        " FROM Buyer B " & _
                        " LEFT JOIN SubGroup  S On B.SubCode = S.SubCode " & _
                        " LEFT JOIN CIty C On S.CityCode = C.CityCode " & _
                        " LEFT JOIN Country Co On S.CountryCode = Co.Code " & _
                        " WHERE IsNull(S.IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Buyer Code]"
    End Sub

    Private Sub FrmShade_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "SubGroup"
        LogTableName = "SubGroup_LOG"
        MainLineTableCsv = "Buyer"
        LogLineTableCsv = "Buyer_LOG"
        PrimaryField = "SubCode"
    End Sub

    Private Sub FrmShade_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
    End Sub

    Private Sub FrmQuality1_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtBuyerCountry.Enabled = False : TxtMCountry.Enabled = False
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select S.SubCode as Code, S.ManualCode As BuyerCode " & _
                " From Buyer B " & _
                " LEFT JOIN SubGroup S On B.SubCode = S.SubCode " & _
                " Order By S.ManualCode "
        TxtBuyerCode.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select S.SubCode as Code, S.DispName As Name " & _
            " From Buyer B " & _
            " LEFT JOIN SubGroup S On B.SubCode = S.SubCode " & _
            " Order By S.DispName "
        TxtBuyerDispName.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT C.CityCode AS Code, C.CityName, C.Country, C.Status, IsNull(C.IsDeleted,0) as IsDeleted  " & _
                " FROM City C  "
        TxtBuyerCity.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)
        TxtMCity.AgHelpDataSet(1) = TxtBuyerCity.AgHelpDataSet.Copy

        mQry = "SELECT C.Code AS Code, C.Code AS Currency, IsNull(C.IsDeleted,0) as IsDeleted FROM Currency C "
        TxtCurrency.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Description AS SeaPort, Status, IsNull(IsDeleted,0) as IsDeleted  FROM SeaPort"
        TxtDestinationPort.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT A.GroupCode AS Code, A.GroupName AS Name, A.GroupNature , A.Nature  " & _
                  " FROM AcGroup A " & _
                  " WHERE LEFT(MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") in ('" & AgLibrary.ClsConstant.MainGRCodeSundryCreditors & "' , '" & AgLibrary.ClsConstant.MainGRCodeSundryDebtors & "') " & _
                  " AND MainGrLen >= " & AgLibrary.ClsConstant.MainGRLenSundryCreditors & " " & _
                  " AND AliasYn = 'N'"
        TxtAcGroup.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmShade_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        mQry = "Select B.SubCode As SearchCode " & _
            " From Buyer B " & _
            " LEFT JOIN SubGroup S ON B.SubCode = S.SubCode " & _
            " WHERE IsNull(S.IsDeleted,0)=0 "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmShade_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        mQry = "Select B.UID As SearchCode " & _
               " From Buyer_Log B " & _
               " LEFT JOIN SubGroup_Log S On B.UID = S.UID " & _
               " WHERE S.EntryStatus = '" & LogStatus.LogOpen & "' "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmBuyerMaster_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid

    End Sub

    Private Sub FrmQuality1_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet
        Dim DrTemp As DataRow() = Nothing

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select S.*, " & _
                    " B.SeaPort, B.BankName, B.BankAddress, B.BankAcNo, B.Currency, " & _
                    " B.ContactPerson as BuyerContactPerson, B.MAddress1, B.MAddress2, B.MCity, B.MContactNo, " & _
                    " B.MFaxNo, B.Consignee, B.CAddress1, B.CAddress2, B.CPhoneNo, " & _
                    " B.CMobileNo, B.CFaxNo, B.CEmail " & _
                    " From Buyer B " & _
                    " LEFT JOIN SubGroup S On B.SubCode = S.SubCode " & _
                    " Where B.SubCode='" & SearchCode & "'"
        Else
            mQry = "Select S.*, " & _
                    " B.SeaPort, B.BankName, B.BankAddress, B.BankAcNo, B.Currency, " & _
                    " B.ContactPerson as BuyerContactPerson, B.MAddress1, B.MAddress2, B.MCity, B.MContactNo, " & _
                    " B.MFaxNo, B.Consignee, B.CAddress1, B.CAddress2, B.CPhoneNo, " & _
                    " B.CMobileNo, B.CFaxNo, B.CEmail " & _
                    " From Buyer_Log B " & _
                    " LEFT JOIN SubGroup_Log  S On B.UID = S.UID " & _
                    " Where B.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("SubCode"))
                TxtBuyerCode.Text = AgL.XNull(.Rows(0)("ManualCode"))
                TxtBuyerDispName.Text = AgL.XNull(.Rows(0)("DispName"))
                TxtAcGroup.AgSelectedValue = AgL.XNull(.Rows(0)("GroupCode"))
                TxtBuyerAdd1.Text = AgL.XNull(.Rows(0)("Add1"))
                TxtBuyerAdd2.Text = AgL.XNull(.Rows(0)("Add2"))
                TxtBuyerAdd3.Text = AgL.XNull(.Rows(0)("Add3"))
                TxtBuyerCity.AgSelectedValue = AgL.XNull(.Rows(0)("CityCode"))
                TxtBuyerPhone.Text = AgL.XNull(.Rows(0)("Phone"))
                TxtBuyerFax.Text = AgL.XNull(.Rows(0)("Fax"))
                TxtBuyerEMail.Text = AgL.XNull(.Rows(0)("EMail"))
                TxtDestinationPort.AgSelectedValue = AgL.XNull(.Rows(0)("SeaPort"))
                TxtBankName.Text = AgL.XNull(.Rows(0)("BankName"))
                TxtBankAdd1.Text = AgL.XNull(.Rows(0)("BankAddress"))
                TxtBankAcNo.Text = AgL.XNull(.Rows(0)("BankAcNo"))
                TxtCurrency.AgSelectedValue = AgL.XNull(.Rows(0)("Currency"))
                TxtTradeRegNo.Text = AgL.XNull(.Rows(0)("LSTNO"))
                TxtSisterConcern.Text = IIf(AgL.VNull(.Rows(0)("SisterConcernYn")) = 0, "No", "Yes")
                TxtContactPerson.Text = AgL.XNull(.Rows(0)("BuyerContactPerson"))
                TxtMAddress1.Text = AgL.XNull(.Rows(0)("MAddress1"))
                TxtMAddress2.Text = AgL.XNull(.Rows(0)("MAddress2"))
                TxtMCity.AgSelectedValue = AgL.XNull(.Rows(0)("MCity"))
                TxtMContactNo.Text = AgL.XNull(.Rows(0)("MContactNo"))
                TxtMFaxNo.Text = AgL.XNull(.Rows(0)("MFaxNo"))
                TxtConsignee.Text = AgL.XNull(.Rows(0)("Consignee"))
                TxtCAdd1.Text = AgL.XNull(.Rows(0)("CAddress1"))
                TxtCAdd2.Text = AgL.XNull(.Rows(0)("CAddress2"))
                TxtCPhoneNo.Text = AgL.XNull(.Rows(0)("CPhoneNo"))
                TxtCMobile.Text = AgL.XNull(.Rows(0)("CMobileNo"))
                TxtCFaxNo.Text = AgL.XNull(.Rows(0)("CFaxNo"))
                TxtCEmail.Text = AgL.XNull(.Rows(0)("CEmail"))
                mGroupNature = AgL.XNull(.Rows(0)("GroupNature"))
                mNature = AgL.XNull(.Rows(0)("Nature"))

                If TxtBuyerCity.Text.ToString.Trim = "" Or TxtBuyerCity.AgSelectedValue.Trim = "" Then
                    TxtBuyerCountry.Text = ""
                Else
                    If TxtBuyerCity.AgHelpDataSet IsNot Nothing Then
                        DrTemp = TxtBuyerCity.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtBuyerCity.AgSelectedValue) & "")
                        TxtBuyerCountry.Text = AgL.XNull(DrTemp(0)("Country"))
                    End If
                End If

                If TxtMCity.Text.ToString.Trim = "" Or TxtMCity.AgSelectedValue.Trim = "" Then
                    TxtMCountry.Text = ""
                Else
                    If TxtMCity.AgHelpDataSet IsNot Nothing Then
                        DrTemp = TxtMCity.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtMCity.AgSelectedValue) & "")
                        TxtMCountry.Text = AgL.XNull(DrTemp(0)("Country"))
                    End If
                End If
            End If
        End With
        Topctrl1.tPrn = False
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtBuyerCode.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        TxtBuyerCode.Focus()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
    End Sub

    Private Sub FrmShade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 500, 920, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Select Case sender.name
                'Case TxtBuyerCode.Name

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Public Overrides Sub ProcSave()
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bName$ = ""
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If AgCL.AgCheckMandatory(Me) = False Then Exit Sub
            If AgL.RequiredField(TxtBuyerCode, LblBuyerCode.Text) Then Exit Sub
            If AgL.RequiredField(TxtBuyerDispName, LblBuyerName.Text) Then Exit Sub

            If Topctrl1.Mode = "Add" Then
                mQry = "Select count(*) From SubGroup Where ManualCode='" & TxtBuyerCode.Text & "' "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Code Already Exists")

                mQry = "Select count(*) From SubGroup Where DispName='" & TxtBuyerDispName.Text & "'"
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Name Already Exists")

                mQry = "Select count(*) From SubGroup_Log Where ManualCode='" & TxtBuyerCode.Text & "' And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Code Already Exists in Log File")

                mQry = "Select count(*) From SubGroup_Log Where DispName='" & TxtBuyerDispName.Text & "' And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Name Already Exists in Log File")

                mSearchCode = AgL.GetGUID(AgL.GCn).ToString
                mInternalCode = AgL.GetMaxId("SubGroup_Log", "SubCode", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, AgL.ECmd, AgL.Gcn_ConnectionString)
            Else
                mQry = "Select count(*) From SubGroup Where ManualCode ='" & TxtBuyerCode.Text & "' And SubCode<>'" & mInternalCode & "' "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Code Already Exists")

                mQry = "Select count(*) From SubGroup Where DispName='" & TxtBuyerDispName.Text & "' And SubCode<>'" & mInternalCode & "' "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Name Already Exists")

                mQry = "Select count(*) From SubGroup_Log Where ManualCode='" & TxtBuyerCode.Text & "' And UID <>'" & mSearchCode & "' And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Code Already Exists in Log File")

                mQry = "Select count(*) From SubGroup_Log Where DispName='" & TxtBuyerDispName.Text & "' And UID <>'" & mSearchCode & "' And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Buyer Name Already Exists in Log File")
            End If

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            bName = TxtBuyerDispName.Text + " {" + TxtBuyerCode.Text + "}"
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO SubGroup_Log(UID, SubCode, Site_Code, Name, DispName, " & _
                        " GroupCode, GroupNature,	ManualCode,	Nature,	Add1,	Add2,	Add3,	CityCode, " & _
                        " Phone,	FAX,	EMail, LSTNo, SisterConcernYn, 	 " & _
                        " EntryBy, EntryDate,  EntryType, EntryStatus, Div_Code, " & _
                        " U_Name, U_EntDt, U_AE) " & _
                        " VALUES(" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & _
                        " '" & AgL.PubSiteCode & "',	" & AgL.Chk_Text(bName) & ",	" & _
                        " " & AgL.Chk_Text(TxtBuyerDispName.Text) & ", " & AgL.Chk_Text(TxtAcGroup.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(mGroupNature) & ", " & AgL.Chk_Text(TxtBuyerCode.Text) & ", " & _
                        " " & AgL.Chk_Text(mNature) & ", " & AgL.Chk_Text(TxtBuyerAdd1.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtBuyerAdd2.Text) & ", " & AgL.Chk_Text(TxtBuyerAdd3.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtBuyerCity.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtBuyerPhone.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtBuyerFax.Text) & ", " & AgL.Chk_Text(TxtBuyerEMail.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtTradeRegNo.Text) & ",  " & IIf(TxtSisterConcern.Text = "Yes", 1, 0) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                        " " & AgL.Chk_Text(Topctrl1.Mode) & ", " & AgL.Chk_Text(LogStatus.LogOpen) & ", " & _
                        " " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "','" & Format(AgL.PubLoginDate, "Short Date") & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "INSERT INTO Buyer_Log(UID, SubCode, SeaPort, BankName, BankAddress, BankAcNo, Currency, " & _
                        " ContactPerson, MAddress1, MAddress2, MCity,MContactNo, MFaxNo,	 " & _
                        " Consignee, CAddress1,	CAddress2,	CPhoneNo,CMobileNo,	CFaxNo,	CEmail) " & _
                        " VALUES (" & AgL.Chk_Text(mSearchCode) & ", '" & mInternalCode & "', " & AgL.Chk_Text(TxtDestinationPort.AgSelectedValue) & ",	" & _
                        " " & AgL.Chk_Text(TxtBankName.Text) & ", " & AgL.Chk_Text(TxtBankAdd1.Text) & ",	" & _
                        " " & AgL.Chk_Text(TxtBankAcNo.Text) & ", " & AgL.Chk_Text(TxtCurrency.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtContactPerson.Text) & ", " & AgL.Chk_Text(TxtMAddress1.Text) & ",	" & _
                        " " & AgL.Chk_Text(TxtMAddress2.Text) & ", " & AgL.Chk_Text(TxtMCity.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtMContactNo.Text) & ", " & AgL.Chk_Text(TxtMFaxNo.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtConsignee.Text) & ", " & AgL.Chk_Text(TxtCAdd1.Text) & ",	" & _
                        " " & AgL.Chk_Text(TxtCAdd2.Text) & ", " & AgL.Chk_Text(TxtCPhoneNo.Text) & ",  " & _
                        " " & AgL.Chk_Text(TxtCMobile.Text) & ", " & AgL.Chk_Text(TxtCFaxNo.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtCEmail.Text) & ") "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "UPDATE SubGroup_Log " & _
                        " SET " & _
                        " Name = " & AgL.Chk_Text(bName) & ", " & _
                        " DispName = " & AgL.Chk_Text(TxtBuyerDispName.Text) & ", " & _
                        " GroupCode = " & AgL.Chk_Text(TxtAcGroup.AgSelectedValue) & ", " & _
                        " GroupNature = " & AgL.Chk_Text(mGroupNature) & ", " & _
                        " ManualCode = " & AgL.Chk_Text(TxtBuyerCode.Text) & ", " & _
                        " Nature = " & AgL.Chk_Text(mNature) & ", " & _
                        " Add1 = " & AgL.Chk_Text(TxtBuyerAdd1.Text) & ", " & _
                        " Add2 = " & AgL.Chk_Text(TxtBuyerAdd2.Text) & ", " & _
                        " Add3 = " & AgL.Chk_Text(TxtBuyerAdd3.Text) & ", " & _
                        " CityCode = " & AgL.Chk_Text(TxtBuyerCity.AgSelectedValue) & ", " & _
                        " Phone = " & AgL.Chk_Text(TxtBuyerPhone.Text) & ", " & _
                        " FAX = " & AgL.Chk_Text(TxtBuyerFax.Text) & ", " & _
                        " EMail = " & AgL.Chk_Text(TxtBuyerEMail.Text) & ", " & _
                        " LSTNo = " & AgL.Chk_Text(TxtTradeRegNo.Text) & ", " & _
                        " SisterConcernYn = " & IIf(TxtSisterConcern.Text = "Yes", 1, 0) & ", " & _
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

                mQry = "UPDATE Buyer_Log " & _
                        " SET " & _
                        " SeaPort = " & AgL.Chk_Text(TxtDestinationPort.AgSelectedValue) & ", " & _
                        " BankName = " & AgL.Chk_Text(TxtBankName.Text) & ", " & _
                        " BankAddress = " & AgL.Chk_Text(TxtBankAdd1.Text) & ", " & _
                        " BankAcNo = " & AgL.Chk_Text(TxtBankAcNo.Text) & ", " & _
                        " Currency = " & AgL.Chk_Text(TxtCurrency.AgSelectedValue) & ", " & _
                        " ContactPerson = " & AgL.Chk_Text(TxtContactPerson.Text) & ", " & _
                        " MAddress1 = " & AgL.Chk_Text(TxtMAddress1.Text) & ", " & _
                        " MAddress2 = " & AgL.Chk_Text(TxtMAddress2.Text) & ", " & _
                        " MCity = " & AgL.Chk_Text(TxtMCity.AgSelectedValue) & ", " & _
                        " MContactNo = " & AgL.Chk_Text(TxtMContactNo.Text) & ", " & _
                        " MFaxNo = " & AgL.Chk_Text(TxtMFaxNo.Text) & ", " & _
                        " Consignee = " & AgL.Chk_Text(TxtConsignee.Text) & ", " & _
                        " CAddress1 = " & AgL.Chk_Text(TxtCAdd1.Text) & ", " & _
                        " CAddress2 = " & AgL.Chk_Text(TxtCAdd2.Text) & ", " & _
                        " CPhoneNo = " & AgL.Chk_Text(TxtCPhoneNo.Text) & ", " & _
                        " CMobileNo = " & AgL.Chk_Text(TxtCMobile.Text) & ", " & _
                        " CFaxNo = " & AgL.Chk_Text(TxtCFaxNo.Text) & ", " & _
                        " CEmail = " & AgL.Chk_Text(TxtCEmail.Text) & " " & _
                        " Where UID = " & AgL.Chk_Text(mSearchCode) & "  "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

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

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtBuyerCity.Validating, _
                TxtMCity.Validating, TxtAcGroup.Validating, TxtBuyerCity.Validating, TxtBuyerCountry.Validating, _
                TxtMCity.Validating, TxtMCountry.Validating
        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtBuyerCity.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtBuyerCountry.Text = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtBuyerCountry.Text = AgL.XNull(DrTemp(0)("Country"))
                        End If
                    End If

                Case TxtMCity.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtMCountry.Text = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtMCountry.Text = AgL.XNull(DrTemp(0)("Country"))
                        End If
                    End If

                Case TxtAcGroup.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        mGroupNature = ""
                        mNature = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtAcGroup.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtAcGroup.AgSelectedValue) & "")
                            mGroupNature = AgL.XNull(DrTemp(0)("GroupNature"))
                            mNature = AgL.XNull(DrTemp(0)("Nature"))
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtDestinationPort_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDestinationPort.Enter, TxtBuyerCity.Enter, TxtMCity.Enter
        Select Case sender.Name
            Case TxtDestinationPort.Name
                sender.AgRowFilter = " Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' And IsDeleted=0 "
            Case TxtBuyerCity.Name, TxtMCity.Name
                sender.AgRowFilter = " Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' And IsDeleted=0 "
            Case TxtCurrency.Name
                sender.AgRowFilter = " IsDeleted=0 "
        End Select
    End Sub
End Class
