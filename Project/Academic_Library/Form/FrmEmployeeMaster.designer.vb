<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmployeeMaster
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
        Me.LblName = New System.Windows.Forms.Label
        Me.LblNameReq = New System.Windows.Forms.Label
        Me.LblDispName = New System.Windows.Forms.Label
        Me.LblAdd1 = New System.Windows.Forms.Label
        Me.LblDispNameReq = New System.Windows.Forms.Label
        Me.LblManualCode = New System.Windows.Forms.Label
        Me.LblManualCodeReq = New System.Windows.Forms.Label
        Me.LblToDate = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtSalary = New AgControls.AgTextBox
        Me.TxtDob = New AgControls.AgTextBox
        Me.TxtAdd1 = New AgControls.AgTextBox
        Me.TxtAdd2 = New AgControls.AgTextBox
        Me.TxtAdd3 = New AgControls.AgTextBox
        Me.lblCityReq = New System.Windows.Forms.Label
        Me.txtCity = New AgControls.AgTextBox
        Me.lblCity = New System.Windows.Forms.Label
        Me.LblMobile = New System.Windows.Forms.Label
        Me.TxtMobile = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtDispName = New AgControls.AgTextBox
        Me.TxtName = New AgControls.AgTextBox
        Me.TxtManualCode = New AgControls.AgTextBox
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.PicPhoto = New System.Windows.Forms.PictureBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.PicEmployeeSignature = New System.Windows.Forms.PictureBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label61 = New System.Windows.Forms.Label
        Me.TxtGroupCode = New AgControls.AgTextBox
        Me.Label60 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.TxtPanNo = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtEMail = New AgControls.AgTextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtPhone = New AgControls.AgTextBox
        Me.TxtPin = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtRank = New AgControls.AgTextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtUnderEmployee = New AgControls.AgTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtCostCenter = New AgControls.AgTextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDepartment = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        CType(Me.PicPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicEmployeeSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Topctrl1.Location = New System.Drawing.Point(0, 0)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(942, 41)
        Me.Topctrl1.TabIndex = 25
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
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(104, 107)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(93, 13)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "Employe Name"
        '
        'LblNameReq
        '
        Me.LblNameReq.AutoSize = True
        Me.LblNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblNameReq.Location = New System.Drawing.Point(205, 112)
        Me.LblNameReq.Name = "LblNameReq"
        Me.LblNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblNameReq.TabIndex = 0
        Me.LblNameReq.Text = "Ä"
        '
        'LblDispName
        '
        Me.LblDispName.AutoSize = True
        Me.LblDispName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDispName.Location = New System.Drawing.Point(104, 85)
        Me.LblDispName.Name = "LblDispName"
        Me.LblDispName.Size = New System.Drawing.Size(86, 13)
        Me.LblDispName.TabIndex = 0
        Me.LblDispName.Text = "Display Name"
        '
        'LblAdd1
        '
        Me.LblAdd1.AutoSize = True
        Me.LblAdd1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdd1.Location = New System.Drawing.Point(104, 217)
        Me.LblAdd1.Name = "LblAdd1"
        Me.LblAdd1.Size = New System.Drawing.Size(53, 13)
        Me.LblAdd1.TabIndex = 0
        Me.LblAdd1.Text = "Address"
        '
        'LblDispNameReq
        '
        Me.LblDispNameReq.AutoSize = True
        Me.LblDispNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblDispNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblDispNameReq.Location = New System.Drawing.Point(205, 90)
        Me.LblDispNameReq.Name = "LblDispNameReq"
        Me.LblDispNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblDispNameReq.TabIndex = 11
        Me.LblDispNameReq.Text = "Ä"
        '
        'LblManualCode
        '
        Me.LblManualCode.AutoSize = True
        Me.LblManualCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualCode.Location = New System.Drawing.Point(104, 64)
        Me.LblManualCode.Name = "LblManualCode"
        Me.LblManualCode.Size = New System.Drawing.Size(81, 13)
        Me.LblManualCode.TabIndex = 13
        Me.LblManualCode.Text = "Manual Code"
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.AutoSize = True
        Me.LblManualCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblManualCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblManualCodeReq.Location = New System.Drawing.Point(205, 68)
        Me.LblManualCodeReq.Name = "LblManualCodeReq"
        Me.LblManualCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblManualCodeReq.TabIndex = 12
        Me.LblManualCodeReq.Text = "Ä"
        '
        'LblToDate
        '
        Me.LblToDate.AutoSize = True
        Me.LblToDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToDate.Location = New System.Drawing.Point(104, 394)
        Me.LblToDate.Name = "LblToDate"
        Me.LblToDate.Size = New System.Drawing.Size(80, 13)
        Me.LblToDate.TabIndex = 15
        Me.LblToDate.Text = "Date of Birth"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(312, 394)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 13)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "Salary (Per Month)"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(205, 222)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 7)
        Me.Label13.TabIndex = 37
        Me.Label13.Text = "Ä"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(694, 503)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 123
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
        '
        'TxtModified
        '
        Me.TxtModified.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtModified.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtModified.Enabled = False
        Me.TxtModified.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModified.Location = New System.Drawing.Point(15, 21)
        Me.TxtModified.Name = "TxtModified"
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
        Me.GrpUP.Location = New System.Drawing.Point(12, 503)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 122
        Me.GrpUP.TabStop = False
        Me.GrpUP.Tag = "TR"
        Me.GrpUP.Text = "Prepared By "
        '
        'TxtPrepared
        '
        Me.TxtPrepared.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtPrepared.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrepared.Enabled = False
        Me.TxtPrepared.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrepared.Location = New System.Drawing.Point(15, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.Size = New System.Drawing.Size(158, 18)
        Me.TxtPrepared.TabIndex = 0
        Me.TxtPrepared.TabStop = False
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(1, 486)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(941, 4)
        Me.GroupBox2.TabIndex = 124
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'TxtSalary
        '
        Me.TxtSalary.AgMandatory = False
        Me.TxtSalary.AgMasterHelp = False
        Me.TxtSalary.AgNumberLeftPlaces = 8
        Me.TxtSalary.AgNumberNegetiveAllow = False
        Me.TxtSalary.AgNumberRightPlaces = 2
        Me.TxtSalary.AgPickFromLastValue = False
        Me.TxtSalary.AgRowFilter = ""
        Me.TxtSalary.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSalary.AgSelectedValue = Nothing
        Me.TxtSalary.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSalary.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSalary.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSalary.Location = New System.Drawing.Point(422, 391)
        Me.TxtSalary.MaxLength = 11
        Me.TxtSalary.Name = "TxtSalary"
        Me.TxtSalary.Size = New System.Drawing.Size(100, 21)
        Me.TxtSalary.TabIndex = 18
        Me.TxtSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtDob
        '
        Me.TxtDob.AgMandatory = True
        Me.TxtDob.AgMasterHelp = False
        Me.TxtDob.AgNumberLeftPlaces = 0
        Me.TxtDob.AgNumberNegetiveAllow = False
        Me.TxtDob.AgNumberRightPlaces = 0
        Me.TxtDob.AgPickFromLastValue = False
        Me.TxtDob.AgRowFilter = ""
        Me.TxtDob.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDob.AgSelectedValue = Nothing
        Me.TxtDob.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDob.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtDob.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDob.Location = New System.Drawing.Point(222, 390)
        Me.TxtDob.Name = "TxtDob"
        Me.TxtDob.Size = New System.Drawing.Size(84, 21)
        Me.TxtDob.TabIndex = 17
        '
        'TxtAdd1
        '
        Me.TxtAdd1.AgMandatory = True
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
        Me.TxtAdd1.Location = New System.Drawing.Point(222, 214)
        Me.TxtAdd1.MaxLength = 50
        Me.TxtAdd1.Name = "TxtAdd1"
        Me.TxtAdd1.Size = New System.Drawing.Size(300, 21)
        Me.TxtAdd1.TabIndex = 8
        Me.TxtAdd1.Text = "TxtAdd1"
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
        Me.TxtAdd2.Location = New System.Drawing.Point(222, 236)
        Me.TxtAdd2.MaxLength = 50
        Me.TxtAdd2.Name = "TxtAdd2"
        Me.TxtAdd2.Size = New System.Drawing.Size(300, 21)
        Me.TxtAdd2.TabIndex = 9
        Me.TxtAdd2.Text = "TxtAdd2"
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
        Me.TxtAdd3.Location = New System.Drawing.Point(222, 258)
        Me.TxtAdd3.MaxLength = 50
        Me.TxtAdd3.Name = "TxtAdd3"
        Me.TxtAdd3.Size = New System.Drawing.Size(300, 21)
        Me.TxtAdd3.TabIndex = 10
        Me.TxtAdd3.Text = "TxtAdd3"
        '
        'lblCityReq
        '
        Me.lblCityReq.AutoSize = True
        Me.lblCityReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.lblCityReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblCityReq.Location = New System.Drawing.Point(205, 288)
        Me.lblCityReq.Name = "lblCityReq"
        Me.lblCityReq.Size = New System.Drawing.Size(10, 7)
        Me.lblCityReq.TabIndex = 133
        Me.lblCityReq.Text = "Ä"
        '
        'txtCity
        '
        Me.txtCity.AgMandatory = True
        Me.txtCity.AgMasterHelp = False
        Me.txtCity.AgNumberLeftPlaces = 0
        Me.txtCity.AgNumberNegetiveAllow = False
        Me.txtCity.AgNumberRightPlaces = 0
        Me.txtCity.AgPickFromLastValue = False
        Me.txtCity.AgRowFilter = ""
        Me.txtCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.txtCity.AgSelectedValue = Nothing
        Me.txtCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.txtCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.txtCity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCity.Location = New System.Drawing.Point(222, 280)
        Me.txtCity.MaxLength = 50
        Me.txtCity.Name = "txtCity"
        Me.txtCity.Size = New System.Drawing.Size(214, 21)
        Me.txtCity.TabIndex = 11
        Me.txtCity.Text = "AgTextBox1"
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCity.Location = New System.Drawing.Point(104, 283)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(30, 13)
        Me.lblCity.TabIndex = 131
        Me.lblCity.Text = "City"
        '
        'LblMobile
        '
        Me.LblMobile.AutoSize = True
        Me.LblMobile.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMobile.Location = New System.Drawing.Point(104, 327)
        Me.LblMobile.Name = "LblMobile"
        Me.LblMobile.Size = New System.Drawing.Size(66, 13)
        Me.LblMobile.TabIndex = 135
        Me.LblMobile.Text = "Mobile No."
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
        Me.TxtMobile.Location = New System.Drawing.Point(222, 324)
        Me.TxtMobile.MaxLength = 35
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(300, 21)
        Me.TxtMobile.TabIndex = 14
        Me.TxtMobile.Text = "TxtContactNo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(209, 398)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(10, 7)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "Ä"
        '
        'TxtDispName
        '
        Me.TxtDispName.AgMandatory = True
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
        Me.TxtDispName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDispName.Location = New System.Drawing.Point(222, 82)
        Me.TxtDispName.MaxLength = 100
        Me.TxtDispName.Name = "TxtDispName"
        Me.TxtDispName.Size = New System.Drawing.Size(300, 21)
        Me.TxtDispName.TabIndex = 1
        Me.TxtDispName.Text = "TxtDispName"
        '
        'TxtName
        '
        Me.TxtName.AgMandatory = True
        Me.TxtName.AgMasterHelp = False
        Me.TxtName.AgNumberLeftPlaces = 0
        Me.TxtName.AgNumberNegetiveAllow = False
        Me.TxtName.AgNumberRightPlaces = 0
        Me.TxtName.AgPickFromLastValue = False
        Me.TxtName.AgRowFilter = ""
        Me.TxtName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtName.AgSelectedValue = Nothing
        Me.TxtName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(222, 104)
        Me.TxtName.MaxLength = 50
        Me.TxtName.Name = "TxtName"
        Me.TxtName.ReadOnly = True
        Me.TxtName.Size = New System.Drawing.Size(300, 21)
        Me.TxtName.TabIndex = 2
        Me.TxtName.Text = "TxtName"
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
        Me.TxtManualCode.Location = New System.Drawing.Point(222, 60)
        Me.TxtManualCode.MaxLength = 20
        Me.TxtManualCode.Name = "TxtManualCode"
        Me.TxtManualCode.Size = New System.Drawing.Size(134, 21)
        Me.TxtManualCode.TabIndex = 0
        Me.TxtManualCode.Text = "TxtCode"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(130, 461)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 550
        Me.LblSite_CodeReq.Text = "Ä"
        Me.LblSite_CodeReq.Visible = False
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(29, 456)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 551
        Me.LblSite_Code.Text = "Branch/Site"
        Me.LblSite_Code.Visible = False
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(147, 453)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(300, 21)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        Me.TxtSite_Code.Visible = False
        '
        'PicPhoto
        '
        Me.PicPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicPhoto.Location = New System.Drawing.Point(607, 335)
        Me.PicPhoto.Name = "PicPhoto"
        Me.PicPhoto.Size = New System.Drawing.Size(130, 139)
        Me.PicPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicPhoto.TabIndex = 608
        Me.PicPhoto.TabStop = False
        Me.PicPhoto.Visible = False
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(406, 322)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(78, 13)
        Me.Label44.TabIndex = 25
        Me.Label44.Text = "Photo Graph"
        Me.Label44.Visible = False
        '
        'PicEmployeeSignature
        '
        Me.PicEmployeeSignature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicEmployeeSignature.Location = New System.Drawing.Point(759, 426)
        Me.PicEmployeeSignature.Name = "PicEmployeeSignature"
        Me.PicEmployeeSignature.Size = New System.Drawing.Size(130, 48)
        Me.PicEmployeeSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicEmployeeSignature.TabIndex = 610
        Me.PicEmployeeSignature.TabStop = False
        Me.PicEmployeeSignature.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(756, 410)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Signature"
        Me.Label6.Visible = False
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label61.Location = New System.Drawing.Point(205, 134)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(10, 7)
        Me.Label61.TabIndex = 613
        Me.Label61.Text = "Ä"
        '
        'TxtGroupCode
        '
        Me.TxtGroupCode.AgMandatory = True
        Me.TxtGroupCode.AgMasterHelp = False
        Me.TxtGroupCode.AgNumberLeftPlaces = 0
        Me.TxtGroupCode.AgNumberNegetiveAllow = False
        Me.TxtGroupCode.AgNumberRightPlaces = 0
        Me.TxtGroupCode.AgPickFromLastValue = False
        Me.TxtGroupCode.AgRowFilter = ""
        Me.TxtGroupCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGroupCode.AgSelectedValue = Nothing
        Me.TxtGroupCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGroupCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGroupCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGroupCode.Location = New System.Drawing.Point(222, 126)
        Me.TxtGroupCode.MaxLength = 50
        Me.TxtGroupCode.Name = "TxtGroupCode"
        Me.TxtGroupCode.Size = New System.Drawing.Size(300, 21)
        Me.TxtGroupCode.TabIndex = 3
        Me.TxtGroupCode.Text = "AgTextBox4"
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(104, 129)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(65, 13)
        Me.Label60.TabIndex = 612
        Me.Label60.Text = "A/c Group"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(104, 373)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(52, 13)
        Me.Label31.TabIndex = 617
        Me.Label31.Text = "EMail Id"
        '
        'TxtPanNo
        '
        Me.TxtPanNo.AgMandatory = False
        Me.TxtPanNo.AgMasterHelp = False
        Me.TxtPanNo.AgNumberLeftPlaces = 0
        Me.TxtPanNo.AgNumberNegetiveAllow = False
        Me.TxtPanNo.AgNumberRightPlaces = 0
        Me.TxtPanNo.AgPickFromLastValue = False
        Me.TxtPanNo.AgRowFilter = ""
        Me.TxtPanNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPanNo.AgSelectedValue = Nothing
        Me.TxtPanNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPanNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPanNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPanNo.Location = New System.Drawing.Point(222, 346)
        Me.TxtPanNo.MaxLength = 20
        Me.TxtPanNo.Name = "TxtPanNo"
        Me.TxtPanNo.Size = New System.Drawing.Size(300, 21)
        Me.TxtPanNo.TabIndex = 15
        Me.TxtPanNo.Text = "AgTextBox4"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(104, 349)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 616
        Me.Label5.Text = "Pan No"
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
        Me.TxtEMail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEMail.Location = New System.Drawing.Point(222, 368)
        Me.TxtEMail.MaxLength = 35
        Me.TxtEMail.Name = "TxtEMail"
        Me.TxtEMail.Size = New System.Drawing.Size(300, 21)
        Me.TxtEMail.TabIndex = 16
        Me.TxtEMail.Text = "AgTextBox4"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(104, 305)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(65, 13)
        Me.Label26.TabIndex = 619
        Me.Label26.Text = "Phone No."
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
        Me.TxtPhone.Location = New System.Drawing.Point(222, 302)
        Me.TxtPhone.MaxLength = 35
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(300, 21)
        Me.TxtPhone.TabIndex = 13
        Me.TxtPhone.Text = "AgTextBox4"
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
        Me.TxtPin.Location = New System.Drawing.Point(463, 280)
        Me.TxtPin.MaxLength = 6
        Me.TxtPin.Name = "TxtPin"
        Me.TxtPin.Size = New System.Drawing.Size(59, 21)
        Me.TxtPin.TabIndex = 12
        Me.TxtPin.Text = "XXXXXX"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(435, 284)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 621
        Me.Label4.Text = "PIN"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(205, 178)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(10, 7)
        Me.Label12.TabIndex = 627
        Me.Label12.Text = "Ä"
        '
        'TxtRank
        '
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
        Me.TxtRank.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRank.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRank.Location = New System.Drawing.Point(222, 170)
        Me.TxtRank.MaxLength = 50
        Me.TxtRank.Name = "TxtRank"
        Me.TxtRank.Size = New System.Drawing.Size(300, 21)
        Me.TxtRank.TabIndex = 5
        Me.TxtRank.Text = "AgTextBox1"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(104, 173)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 625
        Me.Label14.Text = "Rank"
        '
        'TxtUnderEmployee
        '
        Me.TxtUnderEmployee.AgMandatory = False
        Me.TxtUnderEmployee.AgMasterHelp = False
        Me.TxtUnderEmployee.AgNumberLeftPlaces = 0
        Me.TxtUnderEmployee.AgNumberNegetiveAllow = False
        Me.TxtUnderEmployee.AgNumberRightPlaces = 0
        Me.TxtUnderEmployee.AgPickFromLastValue = False
        Me.TxtUnderEmployee.AgRowFilter = ""
        Me.TxtUnderEmployee.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtUnderEmployee.AgSelectedValue = Nothing
        Me.TxtUnderEmployee.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtUnderEmployee.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtUnderEmployee.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnderEmployee.Location = New System.Drawing.Point(157, 423)
        Me.TxtUnderEmployee.MaxLength = 50
        Me.TxtUnderEmployee.Name = "TxtUnderEmployee"
        Me.TxtUnderEmployee.Size = New System.Drawing.Size(300, 21)
        Me.TxtUnderEmployee.TabIndex = 6
        Me.TxtUnderEmployee.Text = "AgTextBox2"
        Me.TxtUnderEmployee.Visible = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(39, 426)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 13)
        Me.Label16.TabIndex = 628
        Me.Label16.Text = "Under Employee"
        Me.Label16.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label17.Location = New System.Drawing.Point(205, 200)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(10, 7)
        Me.Label17.TabIndex = 633
        Me.Label17.Text = "Ä"
        '
        'TxtCostCenter
        '
        Me.TxtCostCenter.AgMandatory = True
        Me.TxtCostCenter.AgMasterHelp = False
        Me.TxtCostCenter.AgNumberLeftPlaces = 0
        Me.TxtCostCenter.AgNumberNegetiveAllow = False
        Me.TxtCostCenter.AgNumberRightPlaces = 0
        Me.TxtCostCenter.AgPickFromLastValue = False
        Me.TxtCostCenter.AgRowFilter = ""
        Me.TxtCostCenter.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCostCenter.AgSelectedValue = Nothing
        Me.TxtCostCenter.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCostCenter.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCostCenter.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCostCenter.Location = New System.Drawing.Point(222, 192)
        Me.TxtCostCenter.MaxLength = 50
        Me.TxtCostCenter.Name = "TxtCostCenter"
        Me.TxtCostCenter.Size = New System.Drawing.Size(300, 21)
        Me.TxtCostCenter.TabIndex = 7
        Me.TxtCostCenter.Text = "AgTextBox3"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(104, 195)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 13)
        Me.Label18.TabIndex = 631
        Me.Label18.Text = "Cost Center"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(205, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 636
        Me.Label1.Text = "Ä"
        '
        'TxtDepartment
        '
        Me.TxtDepartment.AgMandatory = True
        Me.TxtDepartment.AgMasterHelp = False
        Me.TxtDepartment.AgNumberLeftPlaces = 0
        Me.TxtDepartment.AgNumberNegetiveAllow = False
        Me.TxtDepartment.AgNumberRightPlaces = 0
        Me.TxtDepartment.AgPickFromLastValue = False
        Me.TxtDepartment.AgRowFilter = ""
        Me.TxtDepartment.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDepartment.AgSelectedValue = Nothing
        Me.TxtDepartment.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDepartment.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDepartment.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDepartment.Location = New System.Drawing.Point(222, 148)
        Me.TxtDepartment.MaxLength = 50
        Me.TxtDepartment.Name = "TxtDepartment"
        Me.TxtDepartment.Size = New System.Drawing.Size(300, 21)
        Me.TxtDepartment.TabIndex = 4
        Me.TxtDepartment.Text = "AgTextBox1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(104, 151)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 13)
        Me.Label2.TabIndex = 634
        Me.Label2.Text = "Department"
        '
        'FrmEmployeeMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 566)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDepartment)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtCostCenter)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TxtUnderEmployee)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtRank)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtPin)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.TxtPhone)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TxtPanNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtEMail)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.TxtGroupCode)
        Me.Controls.Add(Me.Label60)
        Me.Controls.Add(Me.PicPhoto)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.PicEmployeeSignature)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.TxtManualCode)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtDispName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtMobile)
        Me.Controls.Add(Me.LblMobile)
        Me.Controls.Add(Me.lblCityReq)
        Me.Controls.Add(Me.txtCity)
        Me.Controls.Add(Me.lblCity)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtSalary)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtDob)
        Me.Controls.Add(Me.LblToDate)
        Me.Controls.Add(Me.LblManualCode)
        Me.Controls.Add(Me.LblManualCodeReq)
        Me.Controls.Add(Me.LblDispNameReq)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.LblNameReq)
        Me.Controls.Add(Me.LblDispName)
        Me.Controls.Add(Me.TxtAdd1)
        Me.Controls.Add(Me.LblAdd1)
        Me.Controls.Add(Me.TxtAdd2)
        Me.Controls.Add(Me.TxtAdd3)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmEmployeeMaster"
        Me.Text = "Employee Master"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        CType(Me.PicPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicEmployeeSignature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Topctrl1 As Topctrl.Topctrl
    Public WithEvents LblName As System.Windows.Forms.Label
    Public WithEvents LblNameReq As System.Windows.Forms.Label
    Public WithEvents LblDispName As System.Windows.Forms.Label
    Public WithEvents TxtAdd1 As AgControls.AgTextBox
    Public WithEvents LblAdd1 As System.Windows.Forms.Label
    Public WithEvents TxtAdd2 As AgControls.AgTextBox
    Public WithEvents TxtAdd3 As AgControls.AgTextBox
    Public WithEvents LblDispNameReq As System.Windows.Forms.Label
    Public WithEvents LblManualCode As System.Windows.Forms.Label
    Public WithEvents LblManualCodeReq As System.Windows.Forms.Label
    Public WithEvents TxtDob As AgControls.AgTextBox
    Public WithEvents LblToDate As System.Windows.Forms.Label
    Public WithEvents TxtSalary As AgControls.AgTextBox
    Public WithEvents Label9 As System.Windows.Forms.Label
    Public WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Public WithEvents TxtModified As System.Windows.Forms.TextBox
    Public WithEvents GrpUP As System.Windows.Forms.GroupBox
    Public WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Public WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Public WithEvents lblCityReq As System.Windows.Forms.Label
    Public WithEvents txtCity As AgControls.AgTextBox
    Public WithEvents lblCity As System.Windows.Forms.Label
    Public WithEvents LblMobile As System.Windows.Forms.Label
    Public WithEvents TxtMobile As AgControls.AgTextBox
    Public WithEvents Label7 As System.Windows.Forms.Label
    Public WithEvents TxtDispName As AgControls.AgTextBox
    Public WithEvents TxtName As AgControls.AgTextBox
    Public WithEvents TxtManualCode As AgControls.AgTextBox
    Public WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Public WithEvents LblSite_Code As System.Windows.Forms.Label
    Public WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents PicPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents PicEmployeeSignature As System.Windows.Forms.PictureBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents TxtGroupCode As AgControls.AgTextBox
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TxtPanNo As AgControls.AgTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtEMail As AgControls.AgTextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtPhone As AgControls.AgTextBox
    Friend WithEvents TxtPin As AgControls.AgTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents TxtRank As AgControls.AgTextBox
    Public WithEvents Label14 As System.Windows.Forms.Label
    Public WithEvents TxtUnderEmployee As AgControls.AgTextBox
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label17 As System.Windows.Forms.Label
    Public WithEvents TxtCostCenter As AgControls.AgTextBox
    Public WithEvents Label18 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents TxtDepartment As AgControls.AgTextBox
    Public WithEvents Label2 As System.Windows.Forms.Label
End Class
