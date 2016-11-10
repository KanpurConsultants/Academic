<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMessMember
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
        Me.LblDispName = New System.Windows.Forms.Label
        Me.TxtAdd1 = New AgControls.AgTextBox
        Me.LblAdd1 = New System.Windows.Forms.Label
        Me.TxtAdd2 = New AgControls.AgTextBox
        Me.TxtAdd3 = New AgControls.AgTextBox
        Me.LblCityCode = New System.Windows.Forms.Label
        Me.TxtPhone = New AgControls.AgTextBox
        Me.LblPhone = New System.Windows.Forms.Label
        Me.LblMobile = New System.Windows.Forms.Label
        Me.LblDispNameReq = New System.Windows.Forms.Label
        Me.LblFatherName = New System.Windows.Forms.Label
        Me.LblManualCode = New System.Windows.Forms.Label
        Me.LblManualCodeReq = New System.Windows.Forms.Label
        Me.TxtFatherName = New AgControls.AgTextBox
        Me.TxtCityCode = New AgControls.AgTextBox
        Me.TxtDispName = New AgControls.AgTextBox
        Me.TxtManualCode = New AgControls.AgTextBox
        Me.TxtMobile = New AgControls.AgTextBox
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtEMail = New AgControls.AgTextBox
        Me.LblEMail = New System.Windows.Forms.Label
        Me.TxtCommonAc = New AgControls.AgTextBox
        Me.LblCommonAc = New System.Windows.Forms.Label
        Me.LblCommonAcReq = New System.Windows.Forms.Label
        Me.GBoxModified = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LblAcGroupReq = New System.Windows.Forms.Label
        Me.TxtAcGroup = New AgControls.AgTextBox
        Me.LblAcGroup = New System.Windows.Forms.Label
        Me.TxtInActiveDate = New AgControls.AgTextBox
        Me.LblInActiveDate = New System.Windows.Forms.Label
        Me.TxtFax = New AgControls.AgTextBox
        Me.LblBuyerFax = New System.Windows.Forms.Label
        Me.TxtPin = New AgControls.AgTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.GBoxDivision = New System.Windows.Forms.GroupBox
        Me.TxtDivision = New AgControls.AgTextBox
        Me.LblMemberNameReq = New System.Windows.Forms.Label
        Me.TxtMemberName = New AgControls.AgTextBox
        Me.LblMemberName = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.LblMemberTypeReq = New System.Windows.Forms.Label
        Me.TxtMemberType = New AgControls.AgTextBox
        Me.LblMemberType = New System.Windows.Forms.Label
        Me.txtReminderRemark = New AgControls.AgTextBox
        Me.LblReminderRemark = New System.Windows.Forms.Label
        Me.TxtEmployeeCode = New AgControls.AgTextBox
        Me.LblEmployeeCode = New System.Windows.Forms.Label
        Me.TxtStudentCode = New AgControls.AgTextBox
        Me.LblStudentCode = New System.Windows.Forms.Label
        Me.TxtDob = New AgControls.AgTextBox
        Me.LblToDate = New System.Windows.Forms.Label
        Me.TxtFatherNamePrefix = New AgControls.AgTextBox
        Me.TxtMotherName = New AgControls.AgTextBox
        Me.LblMotherName = New System.Windows.Forms.Label
        Me.TxtJoiningDate = New AgControls.AgTextBox
        Me.LblJoiningDate = New System.Windows.Forms.Label
        Me.LblJoiningDateReq = New System.Windows.Forms.Label
        Me.TxtMessAttendanceCode = New AgControls.AgTextBox
        Me.LblMessAttendanceCode = New System.Windows.Forms.Label
        Me.TxtName = New AgControls.AgTextBox
        Me.GBoxModified.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
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
        Me.Topctrl1.Size = New System.Drawing.Size(992, 41)
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
        'LblDispName
        '
        Me.LblDispName.AutoSize = True
        Me.LblDispName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDispName.Location = New System.Drawing.Point(853, 131)
        Me.LblDispName.Name = "LblDispName"
        Me.LblDispName.Size = New System.Drawing.Size(85, 15)
        Me.LblDispName.TabIndex = 6
        Me.LblDispName.Text = "Display Name"
        Me.LblDispName.Visible = False
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
        Me.TxtAdd1.Location = New System.Drawing.Point(368, 201)
        Me.TxtAdd1.MaxLength = 50
        Me.TxtAdd1.Name = "TxtAdd1"
        Me.TxtAdd1.Size = New System.Drawing.Size(372, 18)
        Me.TxtAdd1.TabIndex = 8
        Me.TxtAdd1.Text = "TxtAdd1"
        '
        'LblAdd1
        '
        Me.LblAdd1.AutoSize = True
        Me.LblAdd1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdd1.Location = New System.Drawing.Point(182, 205)
        Me.LblAdd1.Name = "LblAdd1"
        Me.LblAdd1.Size = New System.Drawing.Size(53, 15)
        Me.LblAdd1.TabIndex = 13
        Me.LblAdd1.Text = "Address"
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
        Me.TxtAdd2.Location = New System.Drawing.Point(368, 221)
        Me.TxtAdd2.MaxLength = 50
        Me.TxtAdd2.Name = "TxtAdd2"
        Me.TxtAdd2.Size = New System.Drawing.Size(372, 18)
        Me.TxtAdd2.TabIndex = 9
        Me.TxtAdd2.Text = "TxtAdd2"
        '
        'TxtAdd3
        '
        Me.TxtAdd3.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtAdd3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdd3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdd3.Location = New System.Drawing.Point(933, 68)
        Me.TxtAdd3.MaxLength = 50
        Me.TxtAdd3.Name = "TxtAdd3"
        Me.TxtAdd3.Size = New System.Drawing.Size(57, 18)
        Me.TxtAdd3.TabIndex = 16
        Me.TxtAdd3.Text = "TxtAdd3"
        Me.TxtAdd3.Visible = False
        '
        'LblCityCode
        '
        Me.LblCityCode.AutoSize = True
        Me.LblCityCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCityCode.Location = New System.Drawing.Point(182, 245)
        Me.LblCityCode.Name = "LblCityCode"
        Me.LblCityCode.Size = New System.Drawing.Size(64, 15)
        Me.LblCityCode.TabIndex = 17
        Me.LblCityCode.Text = "City Name"
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
        Me.TxtPhone.Location = New System.Drawing.Point(608, 261)
        Me.TxtPhone.MaxLength = 35
        Me.TxtPhone.Name = "TxtPhone"
        Me.TxtPhone.Size = New System.Drawing.Size(132, 18)
        Me.TxtPhone.TabIndex = 13
        Me.TxtPhone.Text = "TxtPhone"
        '
        'LblPhone
        '
        Me.LblPhone.AutoSize = True
        Me.LblPhone.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPhone.Location = New System.Drawing.Point(509, 263)
        Me.LblPhone.Name = "LblPhone"
        Me.LblPhone.Size = New System.Drawing.Size(65, 15)
        Me.LblPhone.TabIndex = 19
        Me.LblPhone.Text = "Phone No."
        '
        'LblMobile
        '
        Me.LblMobile.AutoSize = True
        Me.LblMobile.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMobile.Location = New System.Drawing.Point(182, 265)
        Me.LblMobile.Name = "LblMobile"
        Me.LblMobile.Size = New System.Drawing.Size(65, 15)
        Me.LblMobile.TabIndex = 21
        Me.LblMobile.Text = "Mobile No."
        '
        'LblDispNameReq
        '
        Me.LblDispNameReq.AutoSize = True
        Me.LblDispNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblDispNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblDispNameReq.Location = New System.Drawing.Point(918, 135)
        Me.LblDispNameReq.Name = "LblDispNameReq"
        Me.LblDispNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblDispNameReq.TabIndex = 11
        Me.LblDispNameReq.Text = "Ä"
        Me.LblDispNameReq.Visible = False
        '
        'LblFatherName
        '
        Me.LblFatherName.AutoSize = True
        Me.LblFatherName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFatherName.Location = New System.Drawing.Point(182, 163)
        Me.LblFatherName.Name = "LblFatherName"
        Me.LblFatherName.Size = New System.Drawing.Size(88, 15)
        Me.LblFatherName.TabIndex = 10
        Me.LblFatherName.Text = "Father's Name"
        '
        'LblManualCode
        '
        Me.LblManualCode.AutoSize = True
        Me.LblManualCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualCode.Location = New System.Drawing.Point(182, 143)
        Me.LblManualCode.Name = "LblManualCode"
        Me.LblManualCode.Size = New System.Drawing.Size(85, 15)
        Me.LblManualCode.TabIndex = 2
        Me.LblManualCode.Text = "Member Code"
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.AutoSize = True
        Me.LblManualCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblManualCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblManualCodeReq.Location = New System.Drawing.Point(353, 147)
        Me.LblManualCodeReq.Name = "LblManualCodeReq"
        Me.LblManualCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblManualCodeReq.TabIndex = 12
        Me.LblManualCodeReq.Text = "Ä"
        '
        'TxtFatherName
        '
        Me.TxtFatherName.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtFatherName.Location = New System.Drawing.Point(368, 161)
        Me.TxtFatherName.MaxLength = 100
        Me.TxtFatherName.Name = "TxtFatherName"
        Me.TxtFatherName.Size = New System.Drawing.Size(372, 18)
        Me.TxtFatherName.TabIndex = 6
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
        Me.TxtCityCode.Location = New System.Drawing.Point(368, 241)
        Me.TxtCityCode.Name = "TxtCityCode"
        Me.TxtCityCode.Size = New System.Drawing.Size(287, 18)
        Me.TxtCityCode.TabIndex = 10
        '
        'TxtDispName
        '
        Me.TxtDispName.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtDispName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDispName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDispName.Location = New System.Drawing.Point(931, 129)
        Me.TxtDispName.Name = "TxtDispName"
        Me.TxtDispName.Size = New System.Drawing.Size(54, 18)
        Me.TxtDispName.TabIndex = 2
        Me.TxtDispName.Visible = False
        '
        'TxtManualCode
        '
        Me.TxtManualCode.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtManualCode.Location = New System.Drawing.Point(368, 141)
        Me.TxtManualCode.Name = "TxtManualCode"
        Me.TxtManualCode.Size = New System.Drawing.Size(132, 18)
        Me.TxtManualCode.TabIndex = 4
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
        Me.TxtMobile.Location = New System.Drawing.Point(368, 261)
        Me.TxtMobile.MaxLength = 35
        Me.TxtMobile.Name = "TxtMobile"
        Me.TxtMobile.Size = New System.Drawing.Size(132, 18)
        Me.TxtMobile.TabIndex = 12
        Me.TxtMobile.Text = "TxtMobile"
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
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(928, 229)
        Me.TxtSite_Code.MaxLength = 35
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(54, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Visible = False
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(859, 229)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(103, 15)
        Me.LblSite_Code.TabIndex = 0
        Me.LblSite_Code.Text = "Site/Branch Code"
        Me.LblSite_Code.Visible = False
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
        Me.TxtEMail.Location = New System.Drawing.Point(368, 281)
        Me.TxtEMail.MaxLength = 40
        Me.TxtEMail.Name = "TxtEMail"
        Me.TxtEMail.Size = New System.Drawing.Size(372, 18)
        Me.TxtEMail.TabIndex = 14
        '
        'LblEMail
        '
        Me.LblEMail.AutoSize = True
        Me.LblEMail.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEMail.Location = New System.Drawing.Point(182, 285)
        Me.LblEMail.Name = "LblEMail"
        Me.LblEMail.Size = New System.Drawing.Size(55, 15)
        Me.LblEMail.TabIndex = 23
        Me.LblEMail.Text = "EMail ID."
        '
        'TxtCommonAc
        '
        Me.TxtCommonAc.AgAllowUserToEnableMasterHelp = False
        Me.TxtCommonAc.AgMandatory = False
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
        Me.TxtCommonAc.Location = New System.Drawing.Point(933, 47)
        Me.TxtCommonAc.Name = "TxtCommonAc"
        Me.TxtCommonAc.Size = New System.Drawing.Size(47, 18)
        Me.TxtCommonAc.TabIndex = 5
        Me.TxtCommonAc.Visible = False
        '
        'LblCommonAc
        '
        Me.LblCommonAc.AutoSize = True
        Me.LblCommonAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCommonAc.Location = New System.Drawing.Point(858, 51)
        Me.LblCommonAc.Name = "LblCommonAc"
        Me.LblCommonAc.Size = New System.Drawing.Size(82, 13)
        Me.LblCommonAc.TabIndex = 4
        Me.LblCommonAc.Text = "C&ommon A/c"
        Me.LblCommonAc.Visible = False
        '
        'LblCommonAcReq
        '
        Me.LblCommonAcReq.AutoSize = True
        Me.LblCommonAcReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblCommonAcReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblCommonAcReq.Location = New System.Drawing.Point(917, 54)
        Me.LblCommonAcReq.Name = "LblCommonAcReq"
        Me.LblCommonAcReq.Size = New System.Drawing.Size(10, 7)
        Me.LblCommonAcReq.TabIndex = 50
        Me.LblCommonAcReq.Text = "Ä"
        Me.LblCommonAcReq.Visible = False
        '
        'GBoxModified
        '
        Me.GBoxModified.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GBoxModified.Controls.Add(Me.TxtModified)
        Me.GBoxModified.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GBoxModified.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GBoxModified.ForeColor = System.Drawing.Color.Maroon
        Me.GBoxModified.Location = New System.Drawing.Point(796, 408)
        Me.GBoxModified.Name = "GBoxModified"
        Me.GBoxModified.Size = New System.Drawing.Size(186, 51)
        Me.GBoxModified.TabIndex = 297
        Me.GBoxModified.TabStop = False
        Me.GBoxModified.Tag = "TR"
        Me.GBoxModified.Text = "Modified By "
        Me.GBoxModified.Visible = False
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
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(14, 408)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 296
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
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(-2, 394)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(996, 4)
        Me.GroupBox2.TabIndex = 298
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'LblAcGroupReq
        '
        Me.LblAcGroupReq.AutoSize = True
        Me.LblAcGroupReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAcGroupReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAcGroupReq.Location = New System.Drawing.Point(918, 115)
        Me.LblAcGroupReq.Name = "LblAcGroupReq"
        Me.LblAcGroupReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAcGroupReq.TabIndex = 864
        Me.LblAcGroupReq.Text = "Ä"
        Me.LblAcGroupReq.Visible = False
        '
        'TxtAcGroup
        '
        Me.TxtAcGroup.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtAcGroup.Location = New System.Drawing.Point(932, 109)
        Me.TxtAcGroup.MaxLength = 100
        Me.TxtAcGroup.Name = "TxtAcGroup"
        Me.TxtAcGroup.Size = New System.Drawing.Size(54, 18)
        Me.TxtAcGroup.TabIndex = 4
        Me.TxtAcGroup.Visible = False
        '
        'LblAcGroup
        '
        Me.LblAcGroup.AutoSize = True
        Me.LblAcGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcGroup.Location = New System.Drawing.Point(853, 111)
        Me.LblAcGroup.Name = "LblAcGroup"
        Me.LblAcGroup.Size = New System.Drawing.Size(60, 15)
        Me.LblAcGroup.TabIndex = 863
        Me.LblAcGroup.Text = "A/c Group"
        Me.LblAcGroup.Visible = False
        '
        'TxtInActiveDate
        '
        Me.TxtInActiveDate.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtInActiveDate.Location = New System.Drawing.Point(608, 301)
        Me.TxtInActiveDate.MaxLength = 20
        Me.TxtInActiveDate.Name = "TxtInActiveDate"
        Me.TxtInActiveDate.Size = New System.Drawing.Size(132, 18)
        Me.TxtInActiveDate.TabIndex = 16
        '
        'LblInActiveDate
        '
        Me.LblInActiveDate.AutoSize = True
        Me.LblInActiveDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInActiveDate.Location = New System.Drawing.Point(509, 303)
        Me.LblInActiveDate.Name = "LblInActiveDate"
        Me.LblInActiveDate.Size = New System.Drawing.Size(77, 15)
        Me.LblInActiveDate.TabIndex = 982
        Me.LblInActiveDate.Text = "Inactive Date"
        '
        'TxtFax
        '
        Me.TxtFax.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtFax.Location = New System.Drawing.Point(931, 150)
        Me.TxtFax.MaxLength = 35
        Me.TxtFax.Name = "TxtFax"
        Me.TxtFax.Size = New System.Drawing.Size(54, 18)
        Me.TxtFax.TabIndex = 12
        Me.TxtFax.Visible = False
        '
        'LblBuyerFax
        '
        Me.LblBuyerFax.AutoSize = True
        Me.LblBuyerFax.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerFax.Location = New System.Drawing.Point(853, 152)
        Me.LblBuyerFax.Name = "LblBuyerFax"
        Me.LblBuyerFax.Size = New System.Drawing.Size(48, 15)
        Me.LblBuyerFax.TabIndex = 981
        Me.LblBuyerFax.Text = "Fax No,"
        Me.LblBuyerFax.Visible = False
        '
        'TxtPin
        '
        Me.TxtPin.AgAllowUserToEnableMasterHelp = False
        Me.TxtPin.AgMandatory = False
        Me.TxtPin.AgMasterHelp = True
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
        Me.TxtPin.Location = New System.Drawing.Point(681, 241)
        Me.TxtPin.MaxLength = 6
        Me.TxtPin.Name = "TxtPin"
        Me.TxtPin.Size = New System.Drawing.Size(59, 18)
        Me.TxtPin.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(654, 242)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(29, 16)
        Me.Label13.TabIndex = 985
        Me.Label13.Text = "PIN"
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GBoxDivision.BackColor = System.Drawing.Color.Transparent
        Me.GBoxDivision.Controls.Add(Me.TxtDivision)
        Me.GBoxDivision.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GBoxDivision.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxDivision.ForeColor = System.Drawing.Color.Maroon
        Me.GBoxDivision.Location = New System.Drawing.Point(206, 408)
        Me.GBoxDivision.Name = "GBoxDivision"
        Me.GBoxDivision.Size = New System.Drawing.Size(186, 51)
        Me.GBoxDivision.TabIndex = 987
        Me.GBoxDivision.TabStop = False
        Me.GBoxDivision.Tag = "TR"
        Me.GBoxDivision.Text = "Division"
        Me.GBoxDivision.Visible = False
        '
        'TxtDivision
        '
        Me.TxtDivision.AgAllowUserToEnableMasterHelp = False
        Me.TxtDivision.AgMandatory = False
        Me.TxtDivision.AgMasterHelp = False
        Me.TxtDivision.AgNumberLeftPlaces = 0
        Me.TxtDivision.AgNumberNegetiveAllow = False
        Me.TxtDivision.AgNumberRightPlaces = 0
        Me.TxtDivision.AgPickFromLastValue = False
        Me.TxtDivision.AgRowFilter = ""
        Me.TxtDivision.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDivision.AgSelectedValue = Nothing
        Me.TxtDivision.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDivision.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDivision.BackColor = System.Drawing.Color.White
        Me.TxtDivision.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDivision.Enabled = False
        Me.TxtDivision.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDivision.Location = New System.Drawing.Point(13, 23)
        Me.TxtDivision.Name = "TxtDivision"
        Me.TxtDivision.ReadOnly = True
        Me.TxtDivision.Size = New System.Drawing.Size(158, 18)
        Me.TxtDivision.TabIndex = 0
        Me.TxtDivision.TabStop = False
        Me.TxtDivision.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblMemberNameReq
        '
        Me.LblMemberNameReq.AutoSize = True
        Me.LblMemberNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblMemberNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMemberNameReq.Location = New System.Drawing.Point(353, 127)
        Me.LblMemberNameReq.Name = "LblMemberNameReq"
        Me.LblMemberNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblMemberNameReq.TabIndex = 995
        Me.LblMemberNameReq.Text = "Ä"
        '
        'TxtMemberName
        '
        Me.TxtMemberName.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtMemberName.Location = New System.Drawing.Point(368, 121)
        Me.TxtMemberName.MaxLength = 20
        Me.TxtMemberName.Name = "TxtMemberName"
        Me.TxtMemberName.Size = New System.Drawing.Size(372, 18)
        Me.TxtMemberName.TabIndex = 3
        '
        'LblMemberName
        '
        Me.LblMemberName.AutoSize = True
        Me.LblMemberName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberName.Location = New System.Drawing.Point(182, 123)
        Me.LblMemberName.Name = "LblMemberName"
        Me.LblMemberName.Size = New System.Drawing.Size(89, 15)
        Me.LblMemberName.TabIndex = 994
        Me.LblMemberName.Text = "Member Name"
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
        Me.TxtStreamYearSemester.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStreamYearSemester.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(368, 101)
        Me.TxtStreamYearSemester.MaxLength = 0
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(372, 18)
        Me.TxtStreamYearSemester.TabIndex = 2
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(182, 103)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(61, 15)
        Me.LblStreamYearSemester.TabIndex = 993
        Me.LblStreamYearSemester.Text = "Semester"
        '
        'LblMemberTypeReq
        '
        Me.LblMemberTypeReq.AutoSize = True
        Me.LblMemberTypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblMemberTypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMemberTypeReq.Location = New System.Drawing.Point(594, 87)
        Me.LblMemberTypeReq.Name = "LblMemberTypeReq"
        Me.LblMemberTypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblMemberTypeReq.TabIndex = 992
        Me.LblMemberTypeReq.Text = "Ä"
        '
        'TxtMemberType
        '
        Me.TxtMemberType.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtMemberType.Location = New System.Drawing.Point(608, 81)
        Me.TxtMemberType.MaxLength = 0
        Me.TxtMemberType.Name = "TxtMemberType"
        Me.TxtMemberType.Size = New System.Drawing.Size(132, 18)
        Me.TxtMemberType.TabIndex = 1
        '
        'LblMemberType
        '
        Me.LblMemberType.AutoSize = True
        Me.LblMemberType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberType.Location = New System.Drawing.Point(509, 83)
        Me.LblMemberType.Name = "LblMemberType"
        Me.LblMemberType.Size = New System.Drawing.Size(81, 15)
        Me.LblMemberType.TabIndex = 991
        Me.LblMemberType.Text = "Member Type"
        '
        'txtReminderRemark
        '
        Me.txtReminderRemark.AgAllowUserToEnableMasterHelp = False
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
        Me.txtReminderRemark.Location = New System.Drawing.Point(928, 210)
        Me.txtReminderRemark.MaxLength = 255
        Me.txtReminderRemark.Name = "txtReminderRemark"
        Me.txtReminderRemark.Size = New System.Drawing.Size(54, 18)
        Me.txtReminderRemark.TabIndex = 998
        Me.txtReminderRemark.Visible = False
        '
        'LblReminderRemark
        '
        Me.LblReminderRemark.AutoSize = True
        Me.LblReminderRemark.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReminderRemark.Location = New System.Drawing.Point(853, 211)
        Me.LblReminderRemark.Name = "LblReminderRemark"
        Me.LblReminderRemark.Size = New System.Drawing.Size(109, 15)
        Me.LblReminderRemark.TabIndex = 1003
        Me.LblReminderRemark.Text = "Reminder Remark"
        Me.LblReminderRemark.Visible = False
        '
        'TxtEmployeeCode
        '
        Me.TxtEmployeeCode.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtEmployeeCode.Location = New System.Drawing.Point(928, 190)
        Me.TxtEmployeeCode.MaxLength = 20
        Me.TxtEmployeeCode.Name = "TxtEmployeeCode"
        Me.TxtEmployeeCode.Size = New System.Drawing.Size(54, 18)
        Me.TxtEmployeeCode.TabIndex = 1001
        Me.TxtEmployeeCode.Visible = False
        '
        'LblEmployeeCode
        '
        Me.LblEmployeeCode.AutoSize = True
        Me.LblEmployeeCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmployeeCode.Location = New System.Drawing.Point(853, 191)
        Me.LblEmployeeCode.Name = "LblEmployeeCode"
        Me.LblEmployeeCode.Size = New System.Drawing.Size(62, 15)
        Me.LblEmployeeCode.TabIndex = 1002
        Me.LblEmployeeCode.Text = "Employee"
        Me.LblEmployeeCode.Visible = False
        '
        'TxtStudentCode
        '
        Me.TxtStudentCode.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtStudentCode.Location = New System.Drawing.Point(928, 170)
        Me.TxtStudentCode.MaxLength = 20
        Me.TxtStudentCode.Name = "TxtStudentCode"
        Me.TxtStudentCode.Size = New System.Drawing.Size(54, 18)
        Me.TxtStudentCode.TabIndex = 999
        Me.TxtStudentCode.Visible = False
        '
        'LblStudentCode
        '
        Me.LblStudentCode.AutoSize = True
        Me.LblStudentCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStudentCode.Location = New System.Drawing.Point(853, 171)
        Me.LblStudentCode.Name = "LblStudentCode"
        Me.LblStudentCode.Size = New System.Drawing.Size(82, 15)
        Me.LblStudentCode.TabIndex = 1000
        Me.LblStudentCode.Text = "Student Code"
        Me.LblStudentCode.Visible = False
        '
        'TxtDob
        '
        Me.TxtDob.AgAllowUserToEnableMasterHelp = False
        Me.TxtDob.AgMandatory = False
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
        Me.TxtDob.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDob.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDob.Location = New System.Drawing.Point(368, 301)
        Me.TxtDob.Name = "TxtDob"
        Me.TxtDob.Size = New System.Drawing.Size(132, 18)
        Me.TxtDob.TabIndex = 15
        '
        'LblToDate
        '
        Me.LblToDate.AutoSize = True
        Me.LblToDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToDate.Location = New System.Drawing.Point(182, 305)
        Me.LblToDate.Name = "LblToDate"
        Me.LblToDate.Size = New System.Drawing.Size(74, 15)
        Me.LblToDate.TabIndex = 1005
        Me.LblToDate.Text = "Date of Birth"
        '
        'TxtFatherNamePrefix
        '
        Me.TxtFatherNamePrefix.AgAllowUserToEnableMasterHelp = False
        Me.TxtFatherNamePrefix.AgMandatory = True
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
        Me.TxtFatherNamePrefix.Location = New System.Drawing.Point(933, 88)
        Me.TxtFatherNamePrefix.MaxLength = 10
        Me.TxtFatherNamePrefix.Name = "TxtFatherNamePrefix"
        Me.TxtFatherNamePrefix.Size = New System.Drawing.Size(44, 18)
        Me.TxtFatherNamePrefix.TabIndex = 11
        Me.TxtFatherNamePrefix.Visible = False
        '
        'TxtMotherName
        '
        Me.TxtMotherName.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtMotherName.Location = New System.Drawing.Point(368, 181)
        Me.TxtMotherName.MaxLength = 100
        Me.TxtMotherName.Name = "TxtMotherName"
        Me.TxtMotherName.Size = New System.Drawing.Size(372, 18)
        Me.TxtMotherName.TabIndex = 7
        '
        'LblMotherName
        '
        Me.LblMotherName.AutoSize = True
        Me.LblMotherName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMotherName.Location = New System.Drawing.Point(182, 182)
        Me.LblMotherName.Name = "LblMotherName"
        Me.LblMotherName.Size = New System.Drawing.Size(81, 15)
        Me.LblMotherName.TabIndex = 1007
        Me.LblMotherName.Text = "Mother Name"
        '
        'TxtJoiningDate
        '
        Me.TxtJoiningDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtJoiningDate.AgMandatory = True
        Me.TxtJoiningDate.AgMasterHelp = False
        Me.TxtJoiningDate.AgNumberLeftPlaces = 0
        Me.TxtJoiningDate.AgNumberNegetiveAllow = False
        Me.TxtJoiningDate.AgNumberRightPlaces = 0
        Me.TxtJoiningDate.AgPickFromLastValue = False
        Me.TxtJoiningDate.AgRowFilter = ""
        Me.TxtJoiningDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtJoiningDate.AgSelectedValue = Nothing
        Me.TxtJoiningDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtJoiningDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtJoiningDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtJoiningDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtJoiningDate.Location = New System.Drawing.Point(368, 81)
        Me.TxtJoiningDate.MaxLength = 20
        Me.TxtJoiningDate.Name = "TxtJoiningDate"
        Me.TxtJoiningDate.Size = New System.Drawing.Size(132, 18)
        Me.TxtJoiningDate.TabIndex = 0
        '
        'LblJoiningDate
        '
        Me.LblJoiningDate.AutoSize = True
        Me.LblJoiningDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJoiningDate.Location = New System.Drawing.Point(182, 83)
        Me.LblJoiningDate.Name = "LblJoiningDate"
        Me.LblJoiningDate.Size = New System.Drawing.Size(76, 15)
        Me.LblJoiningDate.TabIndex = 1009
        Me.LblJoiningDate.Text = "Joining Date"
        '
        'LblJoiningDateReq
        '
        Me.LblJoiningDateReq.AutoSize = True
        Me.LblJoiningDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblJoiningDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblJoiningDateReq.Location = New System.Drawing.Point(353, 87)
        Me.LblJoiningDateReq.Name = "LblJoiningDateReq"
        Me.LblJoiningDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblJoiningDateReq.TabIndex = 1010
        Me.LblJoiningDateReq.Text = "Ä"
        '
        'TxtMessAttendanceCode
        '
        Me.TxtMessAttendanceCode.AgAllowUserToEnableMasterHelp = False
        Me.TxtMessAttendanceCode.AgMandatory = False
        Me.TxtMessAttendanceCode.AgMasterHelp = True
        Me.TxtMessAttendanceCode.AgNumberLeftPlaces = 0
        Me.TxtMessAttendanceCode.AgNumberNegetiveAllow = False
        Me.TxtMessAttendanceCode.AgNumberRightPlaces = 0
        Me.TxtMessAttendanceCode.AgPickFromLastValue = False
        Me.TxtMessAttendanceCode.AgRowFilter = ""
        Me.TxtMessAttendanceCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMessAttendanceCode.AgSelectedValue = Nothing
        Me.TxtMessAttendanceCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMessAttendanceCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMessAttendanceCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMessAttendanceCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMessAttendanceCode.Location = New System.Drawing.Point(608, 141)
        Me.TxtMessAttendanceCode.Name = "TxtMessAttendanceCode"
        Me.TxtMessAttendanceCode.Size = New System.Drawing.Size(132, 18)
        Me.TxtMessAttendanceCode.TabIndex = 5
        '
        'LblMessAttendanceCode
        '
        Me.LblMessAttendanceCode.AutoSize = True
        Me.LblMessAttendanceCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMessAttendanceCode.Location = New System.Drawing.Point(509, 143)
        Me.LblMessAttendanceCode.Name = "LblMessAttendanceCode"
        Me.LblMessAttendanceCode.Size = New System.Drawing.Size(101, 15)
        Me.LblMessAttendanceCode.TabIndex = 1011
        Me.LblMessAttendanceCode.Text = "Attendance Code"
        '
        'TxtName
        '
        Me.TxtName.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtName.Location = New System.Drawing.Point(920, 253)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Size = New System.Drawing.Size(54, 18)
        Me.TxtName.TabIndex = 1013
        Me.TxtName.Visible = False
        '
        'FrmMessMember
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 466)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.TxtMessAttendanceCode)
        Me.Controls.Add(Me.LblMessAttendanceCode)
        Me.Controls.Add(Me.LblJoiningDateReq)
        Me.Controls.Add(Me.TxtJoiningDate)
        Me.Controls.Add(Me.LblJoiningDate)
        Me.Controls.Add(Me.TxtMotherName)
        Me.Controls.Add(Me.LblMotherName)
        Me.Controls.Add(Me.TxtDob)
        Me.Controls.Add(Me.LblToDate)
        Me.Controls.Add(Me.txtReminderRemark)
        Me.Controls.Add(Me.LblReminderRemark)
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
        Me.Controls.Add(Me.GBoxDivision)
        Me.Controls.Add(Me.TxtPin)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtInActiveDate)
        Me.Controls.Add(Me.LblInActiveDate)
        Me.Controls.Add(Me.TxtFax)
        Me.Controls.Add(Me.LblBuyerFax)
        Me.Controls.Add(Me.LblAcGroupReq)
        Me.Controls.Add(Me.TxtAcGroup)
        Me.Controls.Add(Me.LblAcGroup)
        Me.Controls.Add(Me.GBoxModified)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtCommonAc)
        Me.Controls.Add(Me.LblCommonAc)
        Me.Controls.Add(Me.LblCommonAcReq)
        Me.Controls.Add(Me.TxtEMail)
        Me.Controls.Add(Me.LblEMail)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtManualCode)
        Me.Controls.Add(Me.TxtDispName)
        Me.Controls.Add(Me.TxtCityCode)
        Me.Controls.Add(Me.TxtFatherNamePrefix)
        Me.Controls.Add(Me.TxtFatherName)
        Me.Controls.Add(Me.LblManualCode)
        Me.Controls.Add(Me.LblManualCodeReq)
        Me.Controls.Add(Me.LblDispNameReq)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.LblDispName)
        Me.Controls.Add(Me.LblFatherName)
        Me.Controls.Add(Me.TxtAdd1)
        Me.Controls.Add(Me.LblAdd1)
        Me.Controls.Add(Me.TxtAdd2)
        Me.Controls.Add(Me.TxtAdd3)
        Me.Controls.Add(Me.LblCityCode)
        Me.Controls.Add(Me.TxtPhone)
        Me.Controls.Add(Me.LblPhone)
        Me.Controls.Add(Me.TxtMobile)
        Me.Controls.Add(Me.LblMobile)
        Me.KeyPreview = True
        Me.Name = "FrmMessMember"
        Me.Text = "Member Master"
        Me.GBoxModified.ResumeLayout(False)
        Me.GBoxModified.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents Topctrl1 As Topctrl.Topctrl
    Protected WithEvents LblDispName As System.Windows.Forms.Label
    Protected WithEvents TxtAdd1 As AgControls.AgTextBox
    Protected WithEvents LblAdd1 As System.Windows.Forms.Label
    Protected WithEvents TxtAdd2 As AgControls.AgTextBox
    Protected WithEvents TxtAdd3 As AgControls.AgTextBox
    Protected WithEvents LblCityCode As System.Windows.Forms.Label
    Protected WithEvents TxtPhone As AgControls.AgTextBox
    Protected WithEvents LblPhone As System.Windows.Forms.Label
    Protected WithEvents LblMobile As System.Windows.Forms.Label
    Protected WithEvents LblDispNameReq As System.Windows.Forms.Label
    Protected WithEvents LblFatherName As System.Windows.Forms.Label
    Protected WithEvents LblManualCode As System.Windows.Forms.Label
    Protected WithEvents LblManualCodeReq As System.Windows.Forms.Label
    Protected WithEvents TxtFatherName As AgControls.AgTextBox
    Protected WithEvents TxtCityCode As AgControls.AgTextBox
    Protected WithEvents TxtDispName As AgControls.AgTextBox
    Protected WithEvents TxtManualCode As AgControls.AgTextBox
    Protected WithEvents TxtMobile As AgControls.AgTextBox
    Protected WithEvents TxtSite_Code As AgControls.AgTextBox
    Protected WithEvents LblSite_Code As System.Windows.Forms.Label
    Protected WithEvents TxtEMail As AgControls.AgTextBox
    Protected WithEvents LblEMail As System.Windows.Forms.Label
    Protected WithEvents TxtCommonAc As AgControls.AgTextBox
    Protected WithEvents LblCommonAc As System.Windows.Forms.Label
    Protected WithEvents LblCommonAcReq As System.Windows.Forms.Label
    Protected WithEvents GBoxModified As System.Windows.Forms.GroupBox
    Protected WithEvents TxtModified As System.Windows.Forms.TextBox
    Protected WithEvents GrpUP As System.Windows.Forms.GroupBox
    Protected WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Protected WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Protected WithEvents LblAcGroupReq As System.Windows.Forms.Label
    Protected WithEvents TxtAcGroup As AgControls.AgTextBox
    Protected WithEvents LblAcGroup As System.Windows.Forms.Label
    Protected WithEvents TxtInActiveDate As AgControls.AgTextBox
    Protected WithEvents LblInActiveDate As System.Windows.Forms.Label
    Protected WithEvents TxtFax As AgControls.AgTextBox
    Protected WithEvents LblBuyerFax As System.Windows.Forms.Label
    Protected WithEvents TxtPin As AgControls.AgTextBox
    Protected WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents GBoxDivision As System.Windows.Forms.GroupBox
    Public WithEvents TxtDivision As AgControls.AgTextBox
    Friend WithEvents LblMemberNameReq As System.Windows.Forms.Label
    Protected WithEvents TxtMemberName As AgControls.AgTextBox
    Protected WithEvents LblMemberName As System.Windows.Forms.Label
    Protected WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Protected WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents LblMemberTypeReq As System.Windows.Forms.Label
    Protected WithEvents TxtMemberType As AgControls.AgTextBox
    Protected WithEvents LblMemberType As System.Windows.Forms.Label
    Protected WithEvents txtReminderRemark As AgControls.AgTextBox
    Protected WithEvents LblReminderRemark As System.Windows.Forms.Label
    Protected WithEvents TxtEmployeeCode As AgControls.AgTextBox
    Protected WithEvents LblEmployeeCode As System.Windows.Forms.Label
    Protected WithEvents TxtStudentCode As AgControls.AgTextBox
    Protected WithEvents LblStudentCode As System.Windows.Forms.Label
    Protected WithEvents TxtDob As AgControls.AgTextBox
    Protected WithEvents LblToDate As System.Windows.Forms.Label
    Protected WithEvents TxtFatherNamePrefix As AgControls.AgTextBox
    Protected WithEvents TxtMotherName As AgControls.AgTextBox
    Protected WithEvents LblMotherName As System.Windows.Forms.Label
    Protected WithEvents TxtJoiningDate As AgControls.AgTextBox
    Protected WithEvents LblJoiningDate As System.Windows.Forms.Label
    Friend WithEvents LblJoiningDateReq As System.Windows.Forms.Label
    Protected WithEvents TxtMessAttendanceCode As AgControls.AgTextBox
    Protected WithEvents LblMessAttendanceCode As System.Windows.Forms.Label
    Protected WithEvents TxtName As AgControls.AgTextBox
End Class
