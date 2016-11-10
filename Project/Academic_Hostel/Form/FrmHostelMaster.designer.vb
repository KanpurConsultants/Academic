<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHostelMaster
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblBank_NameReq = New System.Windows.Forms.Label
        Me.TxtManualCode = New AgControls.AgTextBox
        Me.LblManualCode = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtContactPerson = New AgControls.AgTextBox
        Me.LblContactPerson = New System.Windows.Forms.Label
        Me.TxtAdd1 = New AgControls.AgTextBox
        Me.LblAddress = New System.Windows.Forms.Label
        Me.TxtAdd2 = New AgControls.AgTextBox
        Me.TxtAdd3 = New AgControls.AgTextBox
        Me.TxtCity = New AgControls.AgTextBox
        Me.LblCity = New System.Windows.Forms.Label
        Me.TxtPin = New AgControls.AgTextBox
        Me.LblPin = New System.Windows.Forms.Label
        Me.TxtPhone = New AgControls.AgTextBox
        Me.LblPhone = New System.Windows.Forms.Label
        Me.TxtFax = New AgControls.AgTextBox
        Me.LblFax = New System.Windows.Forms.Label
        Me.TxtEmail = New AgControls.AgTextBox
        Me.LblEmail = New System.Windows.Forms.Label
        Me.TxtMobile = New AgControls.AgTextBox
        Me.LblMobile = New System.Windows.Forms.Label
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(158, 152)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Ä"
        '
        'LblBank_NameReq
        '
        Me.LblBank_NameReq.AutoSize = True
        Me.LblBank_NameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBank_NameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBank_NameReq.Location = New System.Drawing.Point(158, 129)
        Me.LblBank_NameReq.Name = "LblBank_NameReq"
        Me.LblBank_NameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBank_NameReq.TabIndex = 34
        Me.LblBank_NameReq.Text = "Ä"
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
        Me.TxtManualCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManualCode.Location = New System.Drawing.Point(171, 124)
        Me.TxtManualCode.MaxLength = 20
        Me.TxtManualCode.Name = "TxtManualCode"
        Me.TxtManualCode.Size = New System.Drawing.Size(125, 21)
        Me.TxtManualCode.TabIndex = 0
        '
        'LblManualCode
        '
        Me.LblManualCode.AutoSize = True
        Me.LblManualCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualCode.Location = New System.Drawing.Point(62, 126)
        Me.LblManualCode.Name = "LblManualCode"
        Me.LblManualCode.Size = New System.Drawing.Size(81, 13)
        Me.LblManualCode.TabIndex = 31
        Me.LblManualCode.Text = "Manual Code"
        '
        'TxtDescription
        '
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
        Me.TxtDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(171, 146)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(250, 21)
        Me.TxtDescription.TabIndex = 1
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(62, 148)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(71, 13)
        Me.LblDescription.TabIndex = 30
        Me.LblDescription.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(158, 174)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Ä"
        '
        'TxtContactPerson
        '
        Me.TxtContactPerson.AgMandatory = True
        Me.TxtContactPerson.AgMasterHelp = False
        Me.TxtContactPerson.AgNumberLeftPlaces = 0
        Me.TxtContactPerson.AgNumberNegetiveAllow = False
        Me.TxtContactPerson.AgNumberRightPlaces = 0
        Me.TxtContactPerson.AgPickFromLastValue = False
        Me.TxtContactPerson.AgRowFilter = ""
        Me.TxtContactPerson.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtContactPerson.AgSelectedValue = Nothing
        Me.TxtContactPerson.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtContactPerson.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtContactPerson.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtContactPerson.Location = New System.Drawing.Point(171, 168)
        Me.TxtContactPerson.MaxLength = 100
        Me.TxtContactPerson.Name = "TxtContactPerson"
        Me.TxtContactPerson.Size = New System.Drawing.Size(250, 21)
        Me.TxtContactPerson.TabIndex = 2
        '
        'LblContactPerson
        '
        Me.LblContactPerson.AutoSize = True
        Me.LblContactPerson.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblContactPerson.Location = New System.Drawing.Point(62, 170)
        Me.LblContactPerson.Name = "LblContactPerson"
        Me.LblContactPerson.Size = New System.Drawing.Size(94, 13)
        Me.LblContactPerson.TabIndex = 36
        Me.LblContactPerson.Text = "Contact Person"
        '
        'TxtAdd1
        '
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
        Me.TxtAdd1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd1.Location = New System.Drawing.Point(171, 190)
        Me.TxtAdd1.MaxLength = 50
        Me.TxtAdd1.Name = "TxtAdd1"
        Me.TxtAdd1.Size = New System.Drawing.Size(250, 21)
        Me.TxtAdd1.TabIndex = 3
        '
        'LblAddress
        '
        Me.LblAddress.AutoSize = True
        Me.LblAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAddress.Location = New System.Drawing.Point(62, 192)
        Me.LblAddress.Name = "LblAddress"
        Me.LblAddress.Size = New System.Drawing.Size(53, 13)
        Me.LblAddress.TabIndex = 39
        Me.LblAddress.Text = "Address"
        '
        'TxtAdd2
        '
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
        Me.TxtAdd2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd2.Location = New System.Drawing.Point(171, 212)
        Me.TxtAdd2.MaxLength = 50
        Me.TxtAdd2.Name = "TxtAdd2"
        Me.TxtAdd2.Size = New System.Drawing.Size(250, 21)
        Me.TxtAdd2.TabIndex = 4
        '
        'TxtAdd3
        '
        Me.TxtAdd3.AgMandatory = False
        Me.TxtAdd3.AgMasterHelp = False
        Me.TxtAdd3.AgNumberLeftPlaces = 0
        Me.TxtAdd3.AgNumberNegetiveAllow = False
        Me.TxtAdd3.AgNumberRightPlaces = 0
        Me.TxtAdd3.AgPickFromLastValue = False
        Me.TxtAdd3.AgRowFilter = ""
        Me.TxtAdd3.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdd3.AgSelectedValue = Nothing
        Me.TxtAdd3.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdd3.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdd3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd3.Location = New System.Drawing.Point(171, 234)
        Me.TxtAdd3.MaxLength = 50
        Me.TxtAdd3.Name = "TxtAdd3"
        Me.TxtAdd3.Size = New System.Drawing.Size(250, 21)
        Me.TxtAdd3.TabIndex = 5
        '
        'TxtCity
        '
        Me.TxtCity.AgMandatory = False
        Me.TxtCity.AgMasterHelp = True
        Me.TxtCity.AgNumberLeftPlaces = 0
        Me.TxtCity.AgNumberNegetiveAllow = False
        Me.TxtCity.AgNumberRightPlaces = 0
        Me.TxtCity.AgPickFromLastValue = False
        Me.TxtCity.AgRowFilter = ""
        Me.TxtCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCity.AgSelectedValue = Nothing
        Me.TxtCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCity.Location = New System.Drawing.Point(561, 124)
        Me.TxtCity.MaxLength = 6
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(250, 21)
        Me.TxtCity.TabIndex = 6
        '
        'LblCity
        '
        Me.LblCity.AutoSize = True
        Me.LblCity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCity.Location = New System.Drawing.Point(477, 127)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(30, 13)
        Me.LblCity.TabIndex = 44
        Me.LblCity.Text = "City"
        '
        'TxtPin
        '
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
        Me.TxtPin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPin.Location = New System.Drawing.Point(561, 146)
        Me.TxtPin.MaxLength = 6
        Me.TxtPin.Name = "TxtPin"
        Me.TxtPin.Size = New System.Drawing.Size(250, 21)
        Me.TxtPin.TabIndex = 7
        '
        'LblPin
        '
        Me.LblPin.AutoSize = True
        Me.LblPin.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPin.Location = New System.Drawing.Point(477, 149)
        Me.LblPin.Name = "LblPin"
        Me.LblPin.Size = New System.Drawing.Size(24, 13)
        Me.LblPin.TabIndex = 46
        Me.LblPin.Text = "Pin"
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
        Me.TxtPhone.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPhone.Location = New System.Drawing.Point(561, 168)
        Me.TxtPhone.MaxLength = 35
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(250, 21)
        Me.TxtPhone.TabIndex = 8
        '
        'LblPhone
        '
        Me.LblPhone.AutoSize = True
        Me.LblPhone.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPhone.Location = New System.Drawing.Point(477, 171)
        Me.LblPhone.Name = "LblPhone"
        Me.LblPhone.Size = New System.Drawing.Size(42, 13)
        Me.LblPhone.TabIndex = 48
        Me.LblPhone.Text = "Phone"
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
        Me.TxtFax.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFax.Location = New System.Drawing.Point(561, 212)
        Me.TxtFax.MaxLength = 35
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(250, 21)
        Me.TxtFax.TabIndex = 10
        '
        'LblFax
        '
        Me.LblFax.AutoSize = True
        Me.LblFax.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFax.Location = New System.Drawing.Point(477, 215)
        Me.LblFax.Name = "LblFax"
        Me.LblFax.Size = New System.Drawing.Size(27, 13)
        Me.LblFax.TabIndex = 50
        Me.LblFax.Text = "Fax"
        '
        'TxtEmail
        '
        Me.TxtEmail.AgMandatory = False
        Me.TxtEmail.AgMasterHelp = False
        Me.TxtEmail.AgNumberLeftPlaces = 0
        Me.TxtEmail.AgNumberNegetiveAllow = False
        Me.TxtEmail.AgNumberRightPlaces = 0
        Me.TxtEmail.AgPickFromLastValue = False
        Me.TxtEmail.AgRowFilter = ""
        Me.TxtEmail.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEmail.AgSelectedValue = Nothing
        Me.TxtEmail.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEmail.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEmail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmail.Location = New System.Drawing.Point(561, 234)
        Me.TxtEmail.MaxLength = 100
        Me.TxtEmail.Name = "TxtEmail"
        Me.TxtEmail.Size = New System.Drawing.Size(250, 21)
        Me.TxtEmail.TabIndex = 11
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmail.Location = New System.Drawing.Point(477, 237)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(54, 13)
        Me.LblEmail.TabIndex = 52
        Me.LblEmail.Text = "EMail ID"
        '
        'TxtMobile
        '
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
        Me.TxtMobile.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMobile.Location = New System.Drawing.Point(561, 190)
        Me.TxtMobile.MaxLength = 35
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(250, 21)
        Me.TxtMobile.TabIndex = 9
        '
        'LblMobile
        '
        Me.LblMobile.AutoSize = True
        Me.LblMobile.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMobile.Location = New System.Drawing.Point(477, 193)
        Me.LblMobile.Name = "LblMobile"
        Me.LblMobile.Size = New System.Drawing.Size(43, 13)
        Me.LblMobile.TabIndex = 54
        Me.LblMobile.Text = "Mobile"
        '
        'FrmHostelMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 366)
        Me.Controls.Add(Me.TxtMobile)
        Me.Controls.Add(Me.LblMobile)
        Me.Controls.Add(Me.TxtEmail)
        Me.Controls.Add(Me.LblEmail)
        Me.Controls.Add(Me.TxtFax)
        Me.Controls.Add(Me.LblFax)
        Me.Controls.Add(Me.TxtPhone)
        Me.Controls.Add(Me.LblPhone)
        Me.Controls.Add(Me.TxtPin)
        Me.Controls.Add(Me.LblPin)
        Me.Controls.Add(Me.TxtCity)
        Me.Controls.Add(Me.LblCity)
        Me.Controls.Add(Me.TxtAdd3)
        Me.Controls.Add(Me.TxtAdd2)
        Me.Controls.Add(Me.TxtAdd1)
        Me.Controls.Add(Me.LblAddress)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtContactPerson)
        Me.Controls.Add(Me.LblContactPerson)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblBank_NameReq)
        Me.Controls.Add(Me.TxtManualCode)
        Me.Controls.Add(Me.LblManualCode)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.Name = "FrmHostelMaster"
        Me.Text = "Hostel Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblBank_NameReq As System.Windows.Forms.Label
    Friend WithEvents TxtManualCode As AgControls.AgTextBox
    Friend WithEvents LblManualCode As System.Windows.Forms.Label
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtContactPerson As AgControls.AgTextBox
    Friend WithEvents LblContactPerson As System.Windows.Forms.Label
    Friend WithEvents TxtAdd1 As AgControls.AgTextBox
    Friend WithEvents LblAddress As System.Windows.Forms.Label
    Friend WithEvents TxtAdd2 As AgControls.AgTextBox
    Friend WithEvents TxtAdd3 As AgControls.AgTextBox
    Friend WithEvents TxtCity As AgControls.AgTextBox
    Friend WithEvents LblCity As System.Windows.Forms.Label
    Friend WithEvents TxtPin As AgControls.AgTextBox
    Friend WithEvents LblPin As System.Windows.Forms.Label
    Friend WithEvents TxtPhone As AgControls.AgTextBox
    Friend WithEvents LblPhone As System.Windows.Forms.Label
    Friend WithEvents TxtFax As AgControls.AgTextBox
    Friend WithEvents LblFax As System.Windows.Forms.Label
    Friend WithEvents TxtEmail As AgControls.AgTextBox
    Friend WithEvents LblEmail As System.Windows.Forms.Label
    Friend WithEvents TxtMobile As AgControls.AgTextBox
    Friend WithEvents LblMobile As System.Windows.Forms.Label
End Class
