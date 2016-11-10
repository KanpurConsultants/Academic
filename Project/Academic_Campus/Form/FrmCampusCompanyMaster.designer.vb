<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCampusCompanyMaster
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
        Me.LblManualCode = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblCityCode = New System.Windows.Forms.Label
        Me.TxtCityCode = New AgControls.AgTextBox
        Me.TxtPin = New AgControls.AgTextBox
        Me.LblAdd1 = New System.Windows.Forms.Label
        Me.TxtAdd1 = New AgControls.AgTextBox
        Me.TxtAdd2 = New AgControls.AgTextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtPhone = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtMobile = New AgControls.AgTextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.TxtEMail = New AgControls.AgTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtWebSite = New AgControls.AgTextBox
        Me.TxtRank = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtSegment = New AgControls.AgTextBox
        Me.txtManualCode = New AgControls.AgTextBox
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
        Me.Topctrl1.TabIndex = 13
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
        'LblManualCode
        '
        Me.LblManualCode.AutoSize = True
        Me.LblManualCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualCode.Location = New System.Drawing.Point(20, 90)
        Me.LblManualCode.Name = "LblManualCode"
        Me.LblManualCode.Size = New System.Drawing.Size(73, 15)
        Me.LblManualCode.TabIndex = 8
        Me.LblManualCode.Text = "Short Name"
        '
        'TxtDescription
        '
        Me.TxtDescription.AgAllowUserToEnableMasterHelp = False
        Me.TxtDescription.AgMandatory = True
        Me.TxtDescription.AgMasterHelp = True
        Me.TxtDescription.AgNumberLeftPlaces = 0
        Me.TxtDescription.AgNumberNegetiveAllow = False
        Me.TxtDescription.AgNumberRightPlaces = 0
        Me.TxtDescription.AgPickFromLastValue = False
        Me.TxtDescription.AgRowFilter = ""
        Me.TxtDescription.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDescription.AgSelectedValue = Nothing
        Me.TxtDescription.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDescription.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescription.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(140, 68)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(325, 18)
        Me.TxtDescription.TabIndex = 0
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(20, 70)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(97, 15)
        Me.LblDescription.TabIndex = 9
        Me.LblDescription.Text = "Company Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(124, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Ä"
        '
        'LblCityCode
        '
        Me.LblCityCode.AutoSize = True
        Me.LblCityCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCityCode.Location = New System.Drawing.Point(20, 150)
        Me.LblCityCode.Name = "LblCityCode"
        Me.LblCityCode.Size = New System.Drawing.Size(27, 15)
        Me.LblCityCode.TabIndex = 526
        Me.LblCityCode.Text = "City"
        '
        'TxtCityCode
        '
        Me.TxtCityCode.AgAllowUserToEnableMasterHelp = False
        Me.TxtCityCode.AgMandatory = False
        Me.TxtCityCode.AgMasterHelp = False
        Me.TxtCityCode.AgNumberLeftPlaces = 0
        Me.TxtCityCode.AgNumberNegetiveAllow = False
        Me.TxtCityCode.AgNumberRightPlaces = 0
        Me.TxtCityCode.AgPickFromLastValue = False
        Me.TxtCityCode.AgRowFilter = ""
        Me.TxtCityCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCityCode.AgSelectedValue = Nothing
        Me.TxtCityCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCityCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCityCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCityCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCityCode.Location = New System.Drawing.Point(140, 148)
        Me.TxtCityCode.MaxLength = 25
        Me.TxtCityCode.Name = "TxtCityCode"
        Me.TxtCityCode.Size = New System.Drawing.Size(198, 18)
        Me.TxtCityCode.TabIndex = 4
        Me.TxtCityCode.Text = "AgTextBox5"
        '
        'TxtPin
        '
        Me.TxtPin.AgAllowUserToEnableMasterHelp = False
        Me.TxtPin.AgMandatory = False
        Me.TxtPin.AgMasterHelp = False
        Me.TxtPin.AgNumberLeftPlaces = 0
        Me.TxtPin.AgNumberNegetiveAllow = False
        Me.TxtPin.AgNumberRightPlaces = 0
        Me.TxtPin.AgPickFromLastValue = False
        Me.TxtPin.AgRowFilter = ""
        Me.TxtPin.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPin.AgSelectedValue = Nothing
        Me.TxtPin.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPin.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPin.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPin.Location = New System.Drawing.Point(373, 148)
        Me.TxtPin.MaxLength = 6
        Me.TxtPin.Name = "TxtPin"
        Me.TxtPin.Size = New System.Drawing.Size(93, 18)
        Me.TxtPin.TabIndex = 5
        Me.TxtPin.Text = "XXXXXX"
        '
        'LblAdd1
        '
        Me.LblAdd1.AutoSize = True
        Me.LblAdd1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdd1.Location = New System.Drawing.Point(20, 110)
        Me.LblAdd1.Name = "LblAdd1"
        Me.LblAdd1.Size = New System.Drawing.Size(53, 15)
        Me.LblAdd1.TabIndex = 528
        Me.LblAdd1.Text = "Address"
        '
        'TxtAdd1
        '
        Me.TxtAdd1.AgAllowUserToEnableMasterHelp = False
        Me.TxtAdd1.AgMandatory = False
        Me.TxtAdd1.AgMasterHelp = False
        Me.TxtAdd1.AgNumberLeftPlaces = 0
        Me.TxtAdd1.AgNumberNegetiveAllow = False
        Me.TxtAdd1.AgNumberRightPlaces = 0
        Me.TxtAdd1.AgPickFromLastValue = False
        Me.TxtAdd1.AgRowFilter = ""
        Me.TxtAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdd1.AgSelectedValue = Nothing
        Me.TxtAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd1.Location = New System.Drawing.Point(140, 108)
        Me.TxtAdd1.MaxLength = 50
        Me.TxtAdd1.Name = "TxtAdd1"
        Me.TxtAdd1.Size = New System.Drawing.Size(326, 18)
        Me.TxtAdd1.TabIndex = 2
        Me.TxtAdd1.Text = "AgTextBox3"
        '
        'TxtAdd2
        '
        Me.TxtAdd2.AgAllowUserToEnableMasterHelp = False
        Me.TxtAdd2.AgMandatory = False
        Me.TxtAdd2.AgMasterHelp = False
        Me.TxtAdd2.AgNumberLeftPlaces = 0
        Me.TxtAdd2.AgNumberNegetiveAllow = False
        Me.TxtAdd2.AgNumberRightPlaces = 0
        Me.TxtAdd2.AgPickFromLastValue = False
        Me.TxtAdd2.AgRowFilter = ""
        Me.TxtAdd2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdd2.AgSelectedValue = Nothing
        Me.TxtAdd2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdd2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd2.Location = New System.Drawing.Point(140, 128)
        Me.TxtAdd2.MaxLength = 50
        Me.TxtAdd2.Name = "TxtAdd2"
        Me.TxtAdd2.Size = New System.Drawing.Size(326, 18)
        Me.TxtAdd2.TabIndex = 3
        Me.TxtAdd2.Text = "AgTextBox4"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(507, 70)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(43, 15)
        Me.Label26.TabIndex = 529
        Me.Label26.Text = "Phone"
        '
        'TxtPhone
        '
        Me.TxtPhone.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtPhone.Location = New System.Drawing.Point(585, 68)
        Me.TxtPhone.MaxLength = 35
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(267, 18)
        Me.TxtPhone.TabIndex = 6
        Me.TxtPhone.Text = "AgTextBox4"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(507, 90)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(43, 15)
        Me.Label25.TabIndex = 530
        Me.Label25.Text = "Mobile"
        '
        'TxtMobile
        '
        Me.TxtMobile.AgAllowUserToEnableMasterHelp = False
        Me.TxtMobile.AgMandatory = False
        Me.TxtMobile.AgMasterHelp = False
        Me.TxtMobile.AgNumberLeftPlaces = 0
        Me.TxtMobile.AgNumberNegetiveAllow = False
        Me.TxtMobile.AgNumberRightPlaces = 0
        Me.TxtMobile.AgPickFromLastValue = False
        Me.TxtMobile.AgRowFilter = ""
        Me.TxtMobile.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMobile.AgSelectedValue = Nothing
        Me.TxtMobile.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMobile.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMobile.Location = New System.Drawing.Point(585, 88)
        Me.TxtMobile.MaxLength = 35
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(267, 18)
        Me.TxtMobile.TabIndex = 7
        Me.TxtMobile.Text = "AgTextBox3"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(507, 130)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(50, 15)
        Me.Label31.TabIndex = 531
        Me.Label31.Text = "EMail Id"
        '
        'TxtEMail
        '
        Me.TxtEMail.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtEMail.Location = New System.Drawing.Point(585, 128)
        Me.TxtEMail.MaxLength = 100
        Me.TxtEMail.Name = "TxtEMail"
        Me.TxtEMail.Size = New System.Drawing.Size(267, 18)
        Me.TxtEMail.TabIndex = 9
        Me.TxtEMail.Text = "AgTextBox4"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(342, 150)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 15)
        Me.Label13.TabIndex = 527
        Me.Label13.Text = "PIN"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(507, 110)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 535
        Me.Label2.Text = "WebSite"
        '
        'TxtWebSite
        '
        Me.TxtWebSite.AgAllowUserToEnableMasterHelp = False
        Me.TxtWebSite.AgMandatory = False
        Me.TxtWebSite.AgMasterHelp = False
        Me.TxtWebSite.AgNumberLeftPlaces = 0
        Me.TxtWebSite.AgNumberNegetiveAllow = False
        Me.TxtWebSite.AgNumberRightPlaces = 0
        Me.TxtWebSite.AgPickFromLastValue = False
        Me.TxtWebSite.AgRowFilter = ""
        Me.TxtWebSite.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtWebSite.AgSelectedValue = Nothing
        Me.TxtWebSite.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtWebSite.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtWebSite.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtWebSite.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWebSite.Location = New System.Drawing.Point(585, 108)
        Me.TxtWebSite.MaxLength = 100
        Me.TxtWebSite.Name = "TxtWebSite"
        Me.TxtWebSite.Size = New System.Drawing.Size(267, 18)
        Me.TxtWebSite.TabIndex = 8
        Me.TxtWebSite.Text = "AgTextBox4"
        '
        'TxtRank
        '
        Me.TxtRank.AgAllowUserToEnableMasterHelp = False
        Me.TxtRank.AgMandatory = False
        Me.TxtRank.AgMasterHelp = False
        Me.TxtRank.AgNumberLeftPlaces = 0
        Me.TxtRank.AgNumberNegetiveAllow = False
        Me.TxtRank.AgNumberRightPlaces = 0
        Me.TxtRank.AgPickFromLastValue = False
        Me.TxtRank.AgRowFilter = ""
        Me.TxtRank.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRank.AgSelectedValue = Nothing
        Me.TxtRank.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRank.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtRank.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRank.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRank.Location = New System.Drawing.Point(785, 148)
        Me.TxtRank.MaxLength = 6
        Me.TxtRank.Name = "TxtRank"
        Me.TxtRank.Size = New System.Drawing.Size(67, 18)
        Me.TxtRank.TabIndex = 11
        Me.TxtRank.Text = "XXXXXX"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(740, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 537
        Me.Label3.Text = "Rank"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(20, 208)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(828, 260)
        Me.Pnl1.TabIndex = 12
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(20, 185)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(173, 20)
        Me.LinkLabel1.TabIndex = 826
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "CONTACT PERSON DETAIL:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(507, 150)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 15)
        Me.Label4.TabIndex = 828
        Me.Label4.Text = "Segment"
        '
        'TxtSegment
        '
        Me.TxtSegment.AgAllowUserToEnableMasterHelp = False
        Me.TxtSegment.AgMandatory = False
        Me.TxtSegment.AgMasterHelp = False
        Me.TxtSegment.AgNumberLeftPlaces = 0
        Me.TxtSegment.AgNumberNegetiveAllow = False
        Me.TxtSegment.AgNumberRightPlaces = 0
        Me.TxtSegment.AgPickFromLastValue = False
        Me.TxtSegment.AgRowFilter = ""
        Me.TxtSegment.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSegment.AgSelectedValue = Nothing
        Me.TxtSegment.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSegment.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSegment.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSegment.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSegment.Location = New System.Drawing.Point(585, 148)
        Me.TxtSegment.MaxLength = 50
        Me.TxtSegment.Name = "TxtSegment"
        Me.TxtSegment.Size = New System.Drawing.Size(149, 18)
        Me.TxtSegment.TabIndex = 10
        Me.TxtSegment.Text = "AgTextBox4"
        '
        'txtManualCode
        '
        Me.txtManualCode.AgAllowUserToEnableMasterHelp = False
        Me.txtManualCode.AgMandatory = False
        Me.txtManualCode.AgMasterHelp = False
        Me.txtManualCode.AgNumberLeftPlaces = 0
        Me.txtManualCode.AgNumberNegetiveAllow = False
        Me.txtManualCode.AgNumberRightPlaces = 0
        Me.txtManualCode.AgPickFromLastValue = False
        Me.txtManualCode.AgRowFilter = ""
        Me.txtManualCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.txtManualCode.AgSelectedValue = Nothing
        Me.txtManualCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.txtManualCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.txtManualCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtManualCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtManualCode.Location = New System.Drawing.Point(140, 88)
        Me.txtManualCode.MaxLength = 20
        Me.txtManualCode.Name = "txtManualCode"
        Me.txtManualCode.Size = New System.Drawing.Size(198, 18)
        Me.txtManualCode.TabIndex = 1
        Me.txtManualCode.Text = "AgTextBox3"
        '
        'FrmCampusCompanyMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 480)
        Me.Controls.Add(Me.txtManualCode)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtSegment)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtRank)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtWebSite)
        Me.Controls.Add(Me.LblCityCode)
        Me.Controls.Add(Me.TxtCityCode)
        Me.Controls.Add(Me.TxtPin)
        Me.Controls.Add(Me.LblAdd1)
        Me.Controls.Add(Me.TxtAdd1)
        Me.Controls.Add(Me.TxtAdd2)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.TxtPhone)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TxtMobile)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TxtEMail)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.LblManualCode)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmCampusCompanyMaster"
        Me.Text = "Company Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents LblManualCode As System.Windows.Forms.Label
    Protected WithEvents TxtDescription As AgControls.AgTextBox
    Protected WithEvents LblDescription As System.Windows.Forms.Label
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents LblCityCode As System.Windows.Forms.Label
    Protected WithEvents TxtCityCode As AgControls.AgTextBox
    Protected WithEvents TxtPin As AgControls.AgTextBox
    Protected WithEvents LblAdd1 As System.Windows.Forms.Label
    Protected WithEvents TxtAdd1 As AgControls.AgTextBox
    Protected WithEvents TxtAdd2 As AgControls.AgTextBox
    Protected WithEvents Label26 As System.Windows.Forms.Label
    Protected WithEvents TxtPhone As AgControls.AgTextBox
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtMobile As AgControls.AgTextBox
    Protected WithEvents Label31 As System.Windows.Forms.Label
    Protected WithEvents TxtEMail As AgControls.AgTextBox
    Protected WithEvents Label13 As System.Windows.Forms.Label
    Protected WithEvents Label2 As System.Windows.Forms.Label
    Protected WithEvents TxtWebSite As AgControls.AgTextBox
    Protected WithEvents TxtRank As AgControls.AgTextBox
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents TxtSegment As AgControls.AgTextBox
    Protected WithEvents txtManualCode As AgControls.AgTextBox
End Class
