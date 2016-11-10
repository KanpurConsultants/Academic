<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDriver
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
        Me.Label6 = New System.Windows.Forms.Label
        Me.PicStudentSignature = New System.Windows.Forms.PictureBox
        Me.Label44 = New System.Windows.Forms.Label
        Me.PicPhoto = New System.Windows.Forms.PictureBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtIsTeachingStaff = New AgControls.AgTextBox
        Me.TxtManualCode = New AgControls.AgTextBox
        Me.LblManualCode = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.LblGroupCode = New System.Windows.Forms.Label
        Me.TxtSex = New AgControls.AgTextBox
        Me.TxtGroupCode = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtCityCode = New AgControls.AgTextBox
        Me.TxtPin = New AgControls.AgTextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtAdd1 = New AgControls.AgTextBox
        Me.TxtAdd2 = New AgControls.AgTextBox
        Me.TxtDateOfJoin = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDateOfResign = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtMobile = New AgControls.AgTextBox
        Me.TxtResignRemark = New AgControls.AgTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtFatherNamePrefix = New AgControls.AgTextBox
        Me.TxtFatherName = New AgControls.AgTextBox
        Me.LblCommonAc = New System.Windows.Forms.Label
        Me.TxtCommonAc = New AgControls.AgTextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.LblCommonAcReq = New System.Windows.Forms.Label
        Me.TxtReligion = New AgControls.AgTextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtCategory = New AgControls.AgTextBox
        Me.TxtName = New AgControls.AgTextBox
        Me.LblDispName = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtBloodGroup = New AgControls.AgTextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.TxtPanNo = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtEMail = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtDOB = New AgControls.AgTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtPhone = New AgControls.AgTextBox
        Me.TxtDispName = New AgControls.AgTextBox
        Me.Label61 = New System.Windows.Forms.Label
        Me.LblManualCodeReq = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        CType(Me.PicStudentSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(737, 347)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 13)
        Me.Label6.TabIndex = 605
        Me.Label6.Text = "Signature"
        '
        'PicStudentSignature
        '
        Me.PicStudentSignature.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicStudentSignature.Location = New System.Drawing.Point(703, 366)
        Me.PicStudentSignature.Name = "PicStudentSignature"
        Me.PicStudentSignature.Size = New System.Drawing.Size(130, 48)
        Me.PicStudentSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicStudentSignature.TabIndex = 606
        Me.PicStudentSignature.TabStop = False
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(729, 178)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(78, 13)
        Me.Label44.TabIndex = 603
        Me.Label44.Text = "Photo Graph"
        '
        'PicPhoto
        '
        Me.PicPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicPhoto.Location = New System.Drawing.Point(703, 194)
        Me.PicPhoto.Name = "PicPhoto"
        Me.PicPhoto.Size = New System.Drawing.Size(130, 139)
        Me.PicPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicPhoto.TabIndex = 604
        Me.PicPhoto.TabStop = False
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 467)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 45)
        Me.GrpUP.TabIndex = 608
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
        Me.TxtPrepared.Location = New System.Drawing.Point(14, 18)
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
        Me.GroupBox4.Location = New System.Drawing.Point(694, 467)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 45)
        Me.GroupBox4.TabIndex = 609
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
        Me.TxtModified.Location = New System.Drawing.Point(13, 18)
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
        Me.GroupBox2.Location = New System.Drawing.Point(0, 459)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(872, 4)
        Me.GroupBox2.TabIndex = 607
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'TxtIsTeachingStaff
        '
        Me.TxtIsTeachingStaff.AgMandatory = True
        Me.TxtIsTeachingStaff.AgMasterHelp = False
        Me.TxtIsTeachingStaff.AgNumberLeftPlaces = 0
        Me.TxtIsTeachingStaff.AgNumberNegetiveAllow = False
        Me.TxtIsTeachingStaff.AgNumberRightPlaces = 0
        Me.TxtIsTeachingStaff.AgPickFromLastValue = False
        Me.TxtIsTeachingStaff.AgRowFilter = ""
        Me.TxtIsTeachingStaff.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsTeachingStaff.AgSelectedValue = Nothing
        Me.TxtIsTeachingStaff.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsTeachingStaff.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsTeachingStaff.BackColor = System.Drawing.Color.White
        Me.TxtIsTeachingStaff.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIsTeachingStaff.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsTeachingStaff.Location = New System.Drawing.Point(514, 132)
        Me.TxtIsTeachingStaff.MaxLength = 3
        Me.TxtIsTeachingStaff.Name = "TxtIsTeachingStaff"
        Me.TxtIsTeachingStaff.ReadOnly = True
        Me.TxtIsTeachingStaff.Size = New System.Drawing.Size(100, 18)
        Me.TxtIsTeachingStaff.TabIndex = 619
        Me.TxtIsTeachingStaff.TabStop = False
        Me.TxtIsTeachingStaff.Text = "IsTeachingStaff"
        Me.TxtIsTeachingStaff.Visible = False
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
        Me.TxtManualCode.Location = New System.Drawing.Point(314, 132)
        Me.TxtManualCode.MaxLength = 20
        Me.TxtManualCode.Name = "TxtManualCode"
        Me.TxtManualCode.Size = New System.Drawing.Size(150, 18)
        Me.TxtManualCode.TabIndex = 2
        '
        'LblManualCode
        '
        Me.LblManualCode.AutoSize = True
        Me.LblManualCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualCode.Location = New System.Drawing.Point(183, 134)
        Me.LblManualCode.Name = "LblManualCode"
        Me.LblManualCode.Size = New System.Drawing.Size(73, 15)
        Me.LblManualCode.TabIndex = 562
        Me.LblManualCode.Text = "Short Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(183, 194)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(27, 15)
        Me.Label11.TabIndex = 574
        Me.Label11.Text = "Sex"
        '
        'LblGroupCode
        '
        Me.LblGroupCode.AutoSize = True
        Me.LblGroupCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGroupCode.Location = New System.Drawing.Point(183, 154)
        Me.LblGroupCode.Name = "LblGroupCode"
        Me.LblGroupCode.Size = New System.Drawing.Size(60, 15)
        Me.LblGroupCode.TabIndex = 601
        Me.LblGroupCode.Text = "A/c Group"
        '
        'TxtSex
        '
        Me.TxtSex.AgMandatory = False
        Me.TxtSex.AgMasterHelp = False
        Me.TxtSex.AgNumberLeftPlaces = 0
        Me.TxtSex.AgNumberNegetiveAllow = False
        Me.TxtSex.AgNumberRightPlaces = 0
        Me.TxtSex.AgPickFromLastValue = False
        Me.TxtSex.AgRowFilter = ""
        Me.TxtSex.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSex.AgSelectedValue = Nothing
        Me.TxtSex.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSex.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSex.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSex.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSex.Location = New System.Drawing.Point(314, 192)
        Me.TxtSex.MaxLength = 6
        Me.TxtSex.Name = "TxtSex"
        Me.TxtSex.Size = New System.Drawing.Size(100, 18)
        Me.TxtSex.TabIndex = 7
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
        Me.TxtGroupCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGroupCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGroupCode.Location = New System.Drawing.Point(314, 152)
        Me.TxtGroupCode.MaxLength = 50
        Me.TxtGroupCode.Name = "TxtGroupCode"
        Me.TxtGroupCode.Size = New System.Drawing.Size(300, 18)
        Me.TxtGroupCode.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(182, 296)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(27, 15)
        Me.Label12.TabIndex = 575
        Me.Label12.Text = "City"
        '
        'TxtCityCode
        '
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
        Me.TxtCityCode.Location = New System.Drawing.Point(314, 292)
        Me.TxtCityCode.MaxLength = 25
        Me.TxtCityCode.Name = "TxtCityCode"
        Me.TxtCityCode.Size = New System.Drawing.Size(202, 18)
        Me.TxtCityCode.TabIndex = 15
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
        Me.TxtPin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPin.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPin.Location = New System.Drawing.Point(555, 292)
        Me.TxtPin.MaxLength = 6
        Me.TxtPin.Name = "TxtPin"
        Me.TxtPin.Size = New System.Drawing.Size(59, 18)
        Me.TxtPin.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(183, 255)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 15)
        Me.Label15.TabIndex = 577
        Me.Label15.Text = "Address"
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
        Me.TxtAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd1.Location = New System.Drawing.Point(314, 252)
        Me.TxtAdd1.MaxLength = 50
        Me.TxtAdd1.Name = "TxtAdd1"
        Me.TxtAdd1.Size = New System.Drawing.Size(300, 18)
        Me.TxtAdd1.TabIndex = 13
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
        Me.TxtAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd2.Location = New System.Drawing.Point(314, 272)
        Me.TxtAdd2.MaxLength = 50
        Me.TxtAdd2.Name = "TxtAdd2"
        Me.TxtAdd2.Size = New System.Drawing.Size(300, 18)
        Me.TxtAdd2.TabIndex = 14
        '
        'TxtDateOfJoin
        '
        Me.TxtDateOfJoin.AgMandatory = False
        Me.TxtDateOfJoin.AgMasterHelp = False
        Me.TxtDateOfJoin.AgNumberLeftPlaces = 0
        Me.TxtDateOfJoin.AgNumberNegetiveAllow = False
        Me.TxtDateOfJoin.AgNumberRightPlaces = 0
        Me.TxtDateOfJoin.AgPickFromLastValue = False
        Me.TxtDateOfJoin.AgRowFilter = ""
        Me.TxtDateOfJoin.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDateOfJoin.AgSelectedValue = Nothing
        Me.TxtDateOfJoin.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDateOfJoin.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtDateOfJoin.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDateOfJoin.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDateOfJoin.Location = New System.Drawing.Point(514, 232)
        Me.TxtDateOfJoin.MaxLength = 11
        Me.TxtDateOfJoin.Name = "TxtDateOfJoin"
        Me.TxtDateOfJoin.Size = New System.Drawing.Size(100, 18)
        Me.TxtDateOfJoin.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(420, 236)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 15)
        Me.Label2.TabIndex = 613
        Me.Label2.Text = "Joining Date"
        '
        'TxtDateOfResign
        '
        Me.TxtDateOfResign.AgMandatory = False
        Me.TxtDateOfResign.AgMasterHelp = False
        Me.TxtDateOfResign.AgNumberLeftPlaces = 0
        Me.TxtDateOfResign.AgNumberNegetiveAllow = False
        Me.TxtDateOfResign.AgNumberRightPlaces = 0
        Me.TxtDateOfResign.AgPickFromLastValue = False
        Me.TxtDateOfResign.AgRowFilter = ""
        Me.TxtDateOfResign.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDateOfResign.AgSelectedValue = Nothing
        Me.TxtDateOfResign.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDateOfResign.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtDateOfResign.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDateOfResign.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDateOfResign.Location = New System.Drawing.Point(514, 372)
        Me.TxtDateOfResign.MaxLength = 11
        Me.TxtDateOfResign.Name = "TxtDateOfResign"
        Me.TxtDateOfResign.Size = New System.Drawing.Size(100, 18)
        Me.TxtDateOfResign.TabIndex = 23
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(454, 315)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(43, 15)
        Me.Label25.TabIndex = 579
        Me.Label25.Text = "Mobile"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(421, 376)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 15)
        Me.Label3.TabIndex = 616
        Me.Label3.Text = "Resign Date"
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
        Me.TxtMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMobile.Location = New System.Drawing.Point(502, 312)
        Me.TxtMobile.MaxLength = 35
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(112, 18)
        Me.TxtMobile.TabIndex = 19
        '
        'TxtResignRemark
        '
        Me.TxtResignRemark.AgMandatory = False
        Me.TxtResignRemark.AgMasterHelp = False
        Me.TxtResignRemark.AgNumberLeftPlaces = 0
        Me.TxtResignRemark.AgNumberNegetiveAllow = False
        Me.TxtResignRemark.AgNumberRightPlaces = 0
        Me.TxtResignRemark.AgPickFromLastValue = False
        Me.TxtResignRemark.AgRowFilter = ""
        Me.TxtResignRemark.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtResignRemark.AgSelectedValue = Nothing
        Me.TxtResignRemark.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtResignRemark.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtResignRemark.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtResignRemark.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtResignRemark.Location = New System.Drawing.Point(314, 392)
        Me.TxtResignRemark.MaxLength = 35
        Me.TxtResignRemark.Name = "TxtResignRemark"
        Me.TxtResignRemark.Size = New System.Drawing.Size(300, 18)
        Me.TxtResignRemark.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(183, 174)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(79, 15)
        Me.Label16.TabIndex = 580
        Me.Label16.Text = "Father Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(183, 396)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(94, 15)
        Me.Label4.TabIndex = 618
        Me.Label4.Text = "Resign Remark"
        '
        'TxtFatherNamePrefix
        '
        Me.TxtFatherNamePrefix.AgMandatory = False
        Me.TxtFatherNamePrefix.AgMasterHelp = True
        Me.TxtFatherNamePrefix.AgNumberLeftPlaces = 0
        Me.TxtFatherNamePrefix.AgNumberNegetiveAllow = False
        Me.TxtFatherNamePrefix.AgNumberRightPlaces = 0
        Me.TxtFatherNamePrefix.AgPickFromLastValue = False
        Me.TxtFatherNamePrefix.AgRowFilter = ""
        Me.TxtFatherNamePrefix.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFatherNamePrefix.AgSelectedValue = Nothing
        Me.TxtFatherNamePrefix.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFatherNamePrefix.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFatherNamePrefix.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFatherNamePrefix.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFatherNamePrefix.Location = New System.Drawing.Point(314, 172)
        Me.TxtFatherNamePrefix.MaxLength = 10
        Me.TxtFatherNamePrefix.Name = "TxtFatherNamePrefix"
        Me.TxtFatherNamePrefix.Size = New System.Drawing.Size(59, 18)
        Me.TxtFatherNamePrefix.TabIndex = 4
        '
        'TxtFatherName
        '
        Me.TxtFatherName.AgMandatory = True
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
        Me.TxtFatherName.Location = New System.Drawing.Point(375, 172)
        Me.TxtFatherName.MaxLength = 100
        Me.TxtFatherName.Name = "TxtFatherName"
        Me.TxtFatherName.Size = New System.Drawing.Size(239, 18)
        Me.TxtFatherName.TabIndex = 5
        '
        'LblCommonAc
        '
        Me.LblCommonAc.AutoSize = True
        Me.LblCommonAc.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCommonAc.Location = New System.Drawing.Point(183, 376)
        Me.LblCommonAc.Name = "LblCommonAc"
        Me.LblCommonAc.Size = New System.Drawing.Size(101, 15)
        Me.LblCommonAc.TabIndex = 621
        Me.LblCommonAc.Text = "Is Common A/c ?"
        '
        'TxtCommonAc
        '
        Me.TxtCommonAc.AgMandatory = True
        Me.TxtCommonAc.AgMasterHelp = False
        Me.TxtCommonAc.AgNumberLeftPlaces = 0
        Me.TxtCommonAc.AgNumberNegetiveAllow = False
        Me.TxtCommonAc.AgNumberRightPlaces = 0
        Me.TxtCommonAc.AgPickFromLastValue = False
        Me.TxtCommonAc.AgRowFilter = ""
        Me.TxtCommonAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCommonAc.AgSelectedValue = Nothing
        Me.TxtCommonAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCommonAc.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtCommonAc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCommonAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCommonAc.Location = New System.Drawing.Point(314, 372)
        Me.TxtCommonAc.MaxLength = 3
        Me.TxtCommonAc.Name = "TxtCommonAc"
        Me.TxtCommonAc.Size = New System.Drawing.Size(100, 18)
        Me.TxtCommonAc.TabIndex = 22
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(420, 214)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 15)
        Me.Label19.TabIndex = 582
        Me.Label19.Text = "Religion"
        '
        'LblCommonAcReq
        '
        Me.LblCommonAcReq.AutoSize = True
        Me.LblCommonAcReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblCommonAcReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblCommonAcReq.Location = New System.Drawing.Point(302, 379)
        Me.LblCommonAcReq.Name = "LblCommonAcReq"
        Me.LblCommonAcReq.Size = New System.Drawing.Size(10, 7)
        Me.LblCommonAcReq.TabIndex = 622
        Me.LblCommonAcReq.Text = "Ä"
        '
        'TxtReligion
        '
        Me.TxtReligion.AgMandatory = False
        Me.TxtReligion.AgMasterHelp = False
        Me.TxtReligion.AgNumberLeftPlaces = 0
        Me.TxtReligion.AgNumberNegetiveAllow = False
        Me.TxtReligion.AgNumberRightPlaces = 0
        Me.TxtReligion.AgPickFromLastValue = False
        Me.TxtReligion.AgRowFilter = ""
        Me.TxtReligion.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtReligion.AgSelectedValue = Nothing
        Me.TxtReligion.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtReligion.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtReligion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtReligion.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReligion.Location = New System.Drawing.Point(514, 212)
        Me.TxtReligion.MaxLength = 50
        Me.TxtReligion.Name = "TxtReligion"
        Me.TxtReligion.Size = New System.Drawing.Size(100, 18)
        Me.TxtReligion.TabIndex = 10
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(183, 214)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 15)
        Me.Label18.TabIndex = 583
        Me.Label18.Text = "Category"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(183, 96)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 590
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'TxtCategory
        '
        Me.TxtCategory.AgMandatory = False
        Me.TxtCategory.AgMasterHelp = False
        Me.TxtCategory.AgNumberLeftPlaces = 0
        Me.TxtCategory.AgNumberNegetiveAllow = False
        Me.TxtCategory.AgNumberRightPlaces = 0
        Me.TxtCategory.AgPickFromLastValue = False
        Me.TxtCategory.AgRowFilter = ""
        Me.TxtCategory.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCategory.AgSelectedValue = Nothing
        Me.TxtCategory.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCategory.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCategory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCategory.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCategory.Location = New System.Drawing.Point(314, 212)
        Me.TxtCategory.MaxLength = 20
        Me.TxtCategory.Name = "TxtCategory"
        Me.TxtCategory.Size = New System.Drawing.Size(100, 18)
        Me.TxtCategory.TabIndex = 9
        '
        'TxtName
        '
        Me.TxtName.AgMandatory = False
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
        Me.TxtName.BackColor = System.Drawing.Color.White
        Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(314, 68)
        Me.TxtName.MaxLength = 123
        Me.TxtName.Name = "TxtName"
        Me.TxtName.ReadOnly = True
        Me.TxtName.Size = New System.Drawing.Size(100, 18)
        Me.TxtName.TabIndex = 5
        Me.TxtName.TabStop = False
        Me.TxtName.Text = "TxtName"
        Me.TxtName.Visible = False
        '
        'LblDispName
        '
        Me.LblDispName.AutoSize = True
        Me.LblDispName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDispName.Location = New System.Drawing.Point(183, 114)
        Me.LblDispName.Name = "LblDispName"
        Me.LblDispName.Size = New System.Drawing.Size(76, 15)
        Me.LblDispName.TabIndex = 588
        Me.LblDispName.Text = "Driver Name"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(420, 195)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(76, 15)
        Me.Label27.TabIndex = 584
        Me.Label27.Text = "Blood Group"
        '
        'TxtBloodGroup
        '
        Me.TxtBloodGroup.AgMandatory = False
        Me.TxtBloodGroup.AgMasterHelp = False
        Me.TxtBloodGroup.AgNumberLeftPlaces = 0
        Me.TxtBloodGroup.AgNumberNegetiveAllow = False
        Me.TxtBloodGroup.AgNumberRightPlaces = 0
        Me.TxtBloodGroup.AgPickFromLastValue = False
        Me.TxtBloodGroup.AgRowFilter = ""
        Me.TxtBloodGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBloodGroup.AgSelectedValue = Nothing
        Me.TxtBloodGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBloodGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBloodGroup.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBloodGroup.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBloodGroup.Location = New System.Drawing.Point(514, 192)
        Me.TxtBloodGroup.MaxLength = 4
        Me.TxtBloodGroup.Name = "TxtBloodGroup"
        Me.TxtBloodGroup.Size = New System.Drawing.Size(100, 18)
        Me.TxtBloodGroup.TabIndex = 8
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(183, 357)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(50, 15)
        Me.Label31.TabIndex = 587
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
        Me.TxtPanNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPanNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPanNo.Location = New System.Drawing.Point(314, 332)
        Me.TxtPanNo.MaxLength = 20
        Me.TxtPanNo.Name = "TxtPanNo"
        Me.TxtPanNo.Size = New System.Drawing.Size(300, 18)
        Me.TxtPanNo.TabIndex = 20
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(183, 335)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(48, 15)
        Me.Label30.TabIndex = 586
        Me.Label30.Text = "Pan No"
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
        Me.TxtEMail.Location = New System.Drawing.Point(314, 352)
        Me.TxtEMail.MaxLength = 35
        Me.TxtEMail.Name = "TxtEMail"
        Me.TxtEMail.Size = New System.Drawing.Size(300, 18)
        Me.TxtEMail.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(183, 236)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(33, 15)
        Me.Label5.TabIndex = 585
        Me.Label5.Text = "DOB"
        '
        'TxtDOB
        '
        Me.TxtDOB.AgMandatory = False
        Me.TxtDOB.AgMasterHelp = False
        Me.TxtDOB.AgNumberLeftPlaces = 0
        Me.TxtDOB.AgNumberNegetiveAllow = False
        Me.TxtDOB.AgNumberRightPlaces = 0
        Me.TxtDOB.AgPickFromLastValue = False
        Me.TxtDOB.AgRowFilter = ""
        Me.TxtDOB.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDOB.AgSelectedValue = Nothing
        Me.TxtDOB.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDOB.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtDOB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDOB.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDOB.Location = New System.Drawing.Point(314, 232)
        Me.TxtDOB.MaxLength = 11
        Me.TxtDOB.Name = "TxtDOB"
        Me.TxtDOB.Size = New System.Drawing.Size(100, 18)
        Me.TxtDOB.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(522, 296)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 15)
        Me.Label13.TabIndex = 576
        Me.Label13.Text = "PIN"
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
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(314, 92)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(300, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(183, 315)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(43, 15)
        Me.Label26.TabIndex = 578
        Me.Label26.Text = "Phone"
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
        Me.TxtPhone.Location = New System.Drawing.Point(314, 312)
        Me.TxtPhone.MaxLength = 35
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(134, 18)
        Me.TxtPhone.TabIndex = 18
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
        Me.TxtDispName.BackColor = System.Drawing.Color.White
        Me.TxtDispName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDispName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDispName.Location = New System.Drawing.Point(314, 112)
        Me.TxtDispName.MaxLength = 100
        Me.TxtDispName.Name = "TxtDispName"
        Me.TxtDispName.Size = New System.Drawing.Size(300, 18)
        Me.TxtDispName.TabIndex = 1
        Me.TxtDispName.TabStop = False
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label61.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label61.Location = New System.Drawing.Point(299, 158)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(10, 7)
        Me.Label61.TabIndex = 602
        Me.Label61.Text = "Ä"
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.AutoSize = True
        Me.LblManualCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblManualCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblManualCodeReq.Location = New System.Drawing.Point(299, 138)
        Me.LblManualCodeReq.Name = "LblManualCodeReq"
        Me.LblManualCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblManualCodeReq.TabIndex = 623
        Me.LblManualCodeReq.Text = "Ä"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(299, 118)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 624
        Me.Label1.Text = "Ä"
        '
        'FrmDriver
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 516)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblManualCodeReq)
        Me.Controls.Add(Me.TxtDispName)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.TxtBloodGroup)
        Me.Controls.Add(Me.TxtPhone)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.PicPhoto)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.LblDispName)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtIsTeachingStaff)
        Me.Controls.Add(Me.TxtCategory)
        Me.Controls.Add(Me.PicStudentSignature)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.TxtReligion)
        Me.Controls.Add(Me.TxtDOB)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtEMail)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtFatherName)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.TxtFatherNamePrefix)
        Me.Controls.Add(Me.TxtDateOfJoin)
        Me.Controls.Add(Me.TxtPanNo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label61)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TxtGroupCode)
        Me.Controls.Add(Me.TxtCityCode)
        Me.Controls.Add(Me.TxtSex)
        Me.Controls.Add(Me.TxtPin)
        Me.Controls.Add(Me.LblGroupCode)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtAdd1)
        Me.Controls.Add(Me.TxtAdd2)
        Me.Controls.Add(Me.LblManualCode)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtManualCode)
        Me.Controls.Add(Me.TxtDateOfResign)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtMobile)
        Me.Controls.Add(Me.LblCommonAcReq)
        Me.Controls.Add(Me.TxtResignRemark)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCommonAc)
        Me.Controls.Add(Me.LblCommonAc)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmDriver"
        Me.Text = "Driver Master"
        CType(Me.PicStudentSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PicStudentSignature As System.Windows.Forms.PictureBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents PicPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtIsTeachingStaff As AgControls.AgTextBox
    Friend WithEvents TxtManualCode As AgControls.AgTextBox
    Friend WithEvents LblManualCode As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblGroupCode As System.Windows.Forms.Label
    Friend WithEvents TxtSex As AgControls.AgTextBox
    Friend WithEvents TxtGroupCode As AgControls.AgTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtCityCode As AgControls.AgTextBox
    Friend WithEvents TxtPin As AgControls.AgTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtAdd1 As AgControls.AgTextBox
    Friend WithEvents TxtAdd2 As AgControls.AgTextBox
    Friend WithEvents TxtDateOfJoin As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDateOfResign As AgControls.AgTextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMobile As AgControls.AgTextBox
    Friend WithEvents TxtResignRemark As AgControls.AgTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtFatherNamePrefix As AgControls.AgTextBox
    Friend WithEvents TxtFatherName As AgControls.AgTextBox
    Friend WithEvents LblCommonAc As System.Windows.Forms.Label
    Friend WithEvents TxtCommonAc As AgControls.AgTextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents LblCommonAcReq As System.Windows.Forms.Label
    Friend WithEvents TxtReligion As AgControls.AgTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtCategory As AgControls.AgTextBox
    Friend WithEvents TxtName As AgControls.AgTextBox
    Friend WithEvents LblDispName As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxtBloodGroup As AgControls.AgTextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TxtPanNo As AgControls.AgTextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents TxtEMail As AgControls.AgTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtDOB As AgControls.AgTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents TxtPhone As AgControls.AgTextBox
    Friend WithEvents TxtDispName As AgControls.AgTextBox
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents LblManualCodeReq As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
