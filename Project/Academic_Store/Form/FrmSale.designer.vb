<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSale
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSale))
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtDocId = New AgControls.AgTextBox
        Me.LblDocId = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.TxtV_No = New AgControls.AgTextBox
        Me.LblV_No = New System.Windows.Forms.Label
        Me.TxtV_Type = New AgControls.AgTextBox
        Me.LblV_Type = New System.Windows.Forms.Label
        Me.TxtAcCode = New AgControls.AgTextBox
        Me.LblAcCode = New System.Windows.Forms.Label
        Me.TxtNetAmount = New AgControls.AgTextBox
        Me.LblTotalNetAmount = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.LblCity = New System.Windows.Forms.Label
        Me.LblAddress = New System.Windows.Forms.Label
        Me.TxtCity = New AgControls.AgTextBox
        Me.TxtAddress3 = New AgControls.AgTextBox
        Me.TxtAddress2 = New AgControls.AgTextBox
        Me.TxtAddress1 = New AgControls.AgTextBox
        Me.LblAcCodeReq = New System.Windows.Forms.Label
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtAmount = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDeduction = New AgControls.AgTextBox
        Me.LblDeduction = New System.Windows.Forms.Label
        Me.TxtAddition = New AgControls.AgTextBox
        Me.LblAddition = New System.Windows.Forms.Label
        Me.TxtAddition_H = New AgControls.AgTextBox
        Me.LblAddition_H = New System.Windows.Forms.Label
        Me.TxtDeduction_H = New AgControls.AgTextBox
        Me.LblDeduction_H = New System.Windows.Forms.Label
        Me.TxtInvoiceAmount = New AgControls.AgTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblDepartmentReq = New System.Windows.Forms.Label
        Me.TxtDepartment = New AgControls.AgTextBox
        Me.LblDepartment = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnApproved = New System.Windows.Forms.Button
        Me.TxtApproved = New System.Windows.Forms.TextBox
        Me.LblRefNo = New System.Windows.Forms.Label
        Me.TxtRefNo = New AgControls.AgTextBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.Topctrl1.Size = New System.Drawing.Size(942, 41)
        Me.Topctrl1.TabIndex = 20
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
        Me.TxtDocId.ForeColor = System.Drawing.Color.Blue
        Me.TxtDocId.Location = New System.Drawing.Point(146, 55)
        Me.TxtDocId.MaxLength = 21
        Me.TxtDocId.Name = "TxtDocId"
        Me.TxtDocId.ReadOnly = True
        Me.TxtDocId.Size = New System.Drawing.Size(325, 21)
        Me.TxtDocId.TabIndex = 0
        Me.TxtDocId.TabStop = False
        Me.TxtDocId.Text = "TxtDocId"
        '
        'LblDocId
        '
        Me.LblDocId.AutoSize = True
        Me.LblDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocId.ForeColor = System.Drawing.Color.Blue
        Me.LblDocId.Location = New System.Drawing.Point(22, 59)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(83, 13)
        Me.LblDocId.TabIndex = 0
        Me.LblDocId.Text = "Document ID"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgAllowUserToEnableMasterHelp = False
        Me.TxtSite_Code.AgMandatory = True
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(146, 77)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 21)
        Me.TxtSite_Code.TabIndex = 1
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(22, 81)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(111, 13)
        Me.LblSite_Code.TabIndex = 0
        Me.LblSite_Code.Text = "Site/Branch Name"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(133, 84)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 0
        Me.LblSite_CodeReq.Text = "Ä"
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
        Me.TxtV_Date.Location = New System.Drawing.Point(146, 121)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_Date.TabIndex = 3
        Me.TxtV_Date.Text = "TxtV_Date"
        '
        'TxtV_No
        '
        Me.TxtV_No.AgAllowUserToEnableMasterHelp = False
        Me.TxtV_No.AgMandatory = False
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
        Me.TxtV_No.Location = New System.Drawing.Point(371, 121)
        Me.TxtV_No.Name = "TxtV_No"
        Me.TxtV_No.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_No.TabIndex = 4
        Me.TxtV_No.Text = "TxtV_No"
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(256, 125)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(77, 13)
        Me.LblV_No.TabIndex = 0
        Me.LblV_No.Text = "Voucher No."
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
        Me.TxtV_Type.Location = New System.Drawing.Point(146, 99)
        Me.TxtV_Type.MaxLength = 5
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(325, 21)
        Me.TxtV_Type.TabIndex = 2
        Me.TxtV_Type.Text = "TxtV_Type"
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(22, 103)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(56, 13)
        Me.LblV_Type.TabIndex = 0
        Me.LblV_Type.Text = "Vr. Type"
        '
        'TxtAcCode
        '
        Me.TxtAcCode.AgAllowUserToEnableMasterHelp = False
        Me.TxtAcCode.AgMandatory = True
        Me.TxtAcCode.AgMasterHelp = False
        Me.TxtAcCode.AgNumberLeftPlaces = 0
        Me.TxtAcCode.AgNumberNegetiveAllow = False
        Me.TxtAcCode.AgNumberRightPlaces = 0
        Me.TxtAcCode.AgPickFromLastValue = False
        Me.TxtAcCode.AgRowFilter = ""
        Me.TxtAcCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAcCode.AgSelectedValue = Nothing
        Me.TxtAcCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAcCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAcCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcCode.Location = New System.Drawing.Point(597, 55)
        Me.TxtAcCode.MaxLength = 10
        Me.TxtAcCode.Name = "TxtAcCode"
        Me.TxtAcCode.Size = New System.Drawing.Size(325, 21)
        Me.TxtAcCode.TabIndex = 7
        Me.TxtAcCode.Text = "TxtAcCode"
        '
        'LblAcCode
        '
        Me.LblAcCode.AutoSize = True
        Me.LblAcCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcCode.Location = New System.Drawing.Point(499, 59)
        Me.LblAcCode.Name = "LblAcCode"
        Me.LblAcCode.Size = New System.Drawing.Size(63, 13)
        Me.LblAcCode.TabIndex = 0
        Me.LblAcCode.Text = "A/c Name"
        '
        'TxtNetAmount
        '
        Me.TxtNetAmount.AgAllowUserToEnableMasterHelp = False
        Me.TxtNetAmount.AgMandatory = False
        Me.TxtNetAmount.AgMasterHelp = False
        Me.TxtNetAmount.AgNumberLeftPlaces = 8
        Me.TxtNetAmount.AgNumberNegetiveAllow = False
        Me.TxtNetAmount.AgNumberRightPlaces = 2
        Me.TxtNetAmount.AgPickFromLastValue = False
        Me.TxtNetAmount.AgRowFilter = ""
        Me.TxtNetAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtNetAmount.AgSelectedValue = Nothing
        Me.TxtNetAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtNetAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtNetAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetAmount.Location = New System.Drawing.Point(579, 504)
        Me.TxtNetAmount.Name = "TxtNetAmount"
        Me.TxtNetAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtNetAmount.TabIndex = 18
        Me.TxtNetAmount.Text = "TxtTotalNetAmount"
        Me.TxtNetAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalNetAmount
        '
        Me.LblTotalNetAmount.AutoSize = True
        Me.LblTotalNetAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalNetAmount.Location = New System.Drawing.Point(472, 507)
        Me.LblTotalNetAmount.Name = "LblTotalNetAmount"
        Me.LblTotalNetAmount.Size = New System.Drawing.Size(74, 13)
        Me.LblTotalNetAmount.TabIndex = 0
        Me.LblTotalNetAmount.Text = "Net Amount"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(17, 203)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(913, 229)
        Me.Pnl1.TabIndex = 12
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(380, 556)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 126
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
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 556)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 125
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
        Me.GroupBox2.Location = New System.Drawing.Point(3, 542)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(939, 4)
        Me.GroupBox2.TabIndex = 127
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(22, 125)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(85, 13)
        Me.LblV_Date.TabIndex = 0
        Me.LblV_Date.Text = "Voucher Date"
        '
        'LblCity
        '
        Me.LblCity.AutoSize = True
        Me.LblCity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCity.Location = New System.Drawing.Point(499, 147)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(67, 13)
        Me.LblCity.TabIndex = 144
        Me.LblCity.Text = "City Name"
        '
        'LblAddress
        '
        Me.LblAddress.AutoSize = True
        Me.LblAddress.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAddress.Location = New System.Drawing.Point(499, 81)
        Me.LblAddress.Name = "LblAddress"
        Me.LblAddress.Size = New System.Drawing.Size(53, 13)
        Me.LblAddress.TabIndex = 143
        Me.LblAddress.Text = "Address"
        '
        'TxtCity
        '
        Me.TxtCity.AgAllowUserToEnableMasterHelp = False
        Me.TxtCity.AgMandatory = False
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
        Me.TxtCity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCity.Location = New System.Drawing.Point(597, 143)
        Me.TxtCity.MaxLength = 10
        Me.TxtCity.Name = "TxtCity"
        Me.TxtCity.Size = New System.Drawing.Size(325, 21)
        Me.TxtCity.TabIndex = 11
        Me.TxtCity.Text = "City"
        '
        'TxtAddress3
        '
        Me.TxtAddress3.AgAllowUserToEnableMasterHelp = False
        Me.TxtAddress3.AgMandatory = False
        Me.TxtAddress3.AgMasterHelp = False
        Me.TxtAddress3.AgNumberLeftPlaces = 0
        Me.TxtAddress3.AgNumberNegetiveAllow = False
        Me.TxtAddress3.AgNumberRightPlaces = 0
        Me.TxtAddress3.AgPickFromLastValue = False
        Me.TxtAddress3.AgRowFilter = ""
        Me.TxtAddress3.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAddress3.AgSelectedValue = Nothing
        Me.TxtAddress3.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAddress3.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAddress3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddress3.Location = New System.Drawing.Point(597, 121)
        Me.TxtAddress3.MaxLength = 50
        Me.TxtAddress3.Name = "TxtAddress3"
        Me.TxtAddress3.Size = New System.Drawing.Size(325, 21)
        Me.TxtAddress3.TabIndex = 10
        Me.TxtAddress3.Text = "Address3"
        '
        'TxtAddress2
        '
        Me.TxtAddress2.AgAllowUserToEnableMasterHelp = False
        Me.TxtAddress2.AgMandatory = False
        Me.TxtAddress2.AgMasterHelp = False
        Me.TxtAddress2.AgNumberLeftPlaces = 0
        Me.TxtAddress2.AgNumberNegetiveAllow = False
        Me.TxtAddress2.AgNumberRightPlaces = 0
        Me.TxtAddress2.AgPickFromLastValue = False
        Me.TxtAddress2.AgRowFilter = ""
        Me.TxtAddress2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAddress2.AgSelectedValue = Nothing
        Me.TxtAddress2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAddress2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAddress2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddress2.Location = New System.Drawing.Point(597, 99)
        Me.TxtAddress2.MaxLength = 50
        Me.TxtAddress2.Name = "TxtAddress2"
        Me.TxtAddress2.Size = New System.Drawing.Size(325, 21)
        Me.TxtAddress2.TabIndex = 9
        Me.TxtAddress2.Text = "Address2"
        '
        'TxtAddress1
        '
        Me.TxtAddress1.AgAllowUserToEnableMasterHelp = False
        Me.TxtAddress1.AgMandatory = False
        Me.TxtAddress1.AgMasterHelp = False
        Me.TxtAddress1.AgNumberLeftPlaces = 0
        Me.TxtAddress1.AgNumberNegetiveAllow = False
        Me.TxtAddress1.AgNumberRightPlaces = 0
        Me.TxtAddress1.AgPickFromLastValue = False
        Me.TxtAddress1.AgRowFilter = ""
        Me.TxtAddress1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAddress1.AgSelectedValue = Nothing
        Me.TxtAddress1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAddress1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAddress1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddress1.Location = New System.Drawing.Point(597, 77)
        Me.TxtAddress1.MaxLength = 50
        Me.TxtAddress1.Name = "TxtAddress1"
        Me.TxtAddress1.Size = New System.Drawing.Size(325, 21)
        Me.TxtAddress1.TabIndex = 8
        Me.TxtAddress1.Text = "Address1"
        '
        'LblAcCodeReq
        '
        Me.LblAcCodeReq.AutoSize = True
        Me.LblAcCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAcCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAcCodeReq.Location = New System.Drawing.Point(585, 62)
        Me.LblAcCodeReq.Name = "LblAcCodeReq"
        Me.LblAcCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAcCodeReq.TabIndex = 147
        Me.LblAcCodeReq.Text = "Ä"
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(331, 125)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(56, 13)
        Me.LblPrefix.TabIndex = 215
        Me.LblPrefix.Text = "LblPrefix"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(133, 106)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 216
        Me.Label4.Text = "Ä"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(133, 128)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 217
        Me.Label5.Text = "Ä"
        '
        'TxtAmount
        '
        Me.TxtAmount.AgAllowUserToEnableMasterHelp = False
        Me.TxtAmount.AgMandatory = False
        Me.TxtAmount.AgMasterHelp = False
        Me.TxtAmount.AgNumberLeftPlaces = 8
        Me.TxtAmount.AgNumberNegetiveAllow = False
        Me.TxtAmount.AgNumberRightPlaces = 2
        Me.TxtAmount.AgPickFromLastValue = False
        Me.TxtAmount.AgRowFilter = ""
        Me.TxtAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAmount.AgSelectedValue = Nothing
        Me.TxtAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmount.Location = New System.Drawing.Point(579, 438)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtAmount.TabIndex = 15
        Me.TxtAmount.Text = "AgTextBox1"
        Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(472, 442)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 221
        Me.Label2.Text = "Total Amount"
        '
        'TxtDeduction
        '
        Me.TxtDeduction.AgAllowUserToEnableMasterHelp = False
        Me.TxtDeduction.AgMandatory = False
        Me.TxtDeduction.AgMasterHelp = False
        Me.TxtDeduction.AgNumberLeftPlaces = 8
        Me.TxtDeduction.AgNumberNegetiveAllow = False
        Me.TxtDeduction.AgNumberRightPlaces = 2
        Me.TxtDeduction.AgPickFromLastValue = False
        Me.TxtDeduction.AgRowFilter = ""
        Me.TxtDeduction.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDeduction.AgSelectedValue = Nothing
        Me.TxtDeduction.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDeduction.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtDeduction.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDeduction.Location = New System.Drawing.Point(579, 482)
        Me.TxtDeduction.Name = "TxtDeduction"
        Me.TxtDeduction.Size = New System.Drawing.Size(100, 21)
        Me.TxtDeduction.TabIndex = 17
        Me.TxtDeduction.Text = "AgTextBox2"
        Me.TxtDeduction.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDeduction
        '
        Me.LblDeduction.AutoSize = True
        Me.LblDeduction.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDeduction.Location = New System.Drawing.Point(472, 485)
        Me.LblDeduction.Name = "LblDeduction"
        Me.LblDeduction.Size = New System.Drawing.Size(64, 13)
        Me.LblDeduction.TabIndex = 223
        Me.LblDeduction.Text = "Deduction"
        '
        'TxtAddition
        '
        Me.TxtAddition.AgAllowUserToEnableMasterHelp = False
        Me.TxtAddition.AgMandatory = False
        Me.TxtAddition.AgMasterHelp = False
        Me.TxtAddition.AgNumberLeftPlaces = 8
        Me.TxtAddition.AgNumberNegetiveAllow = False
        Me.TxtAddition.AgNumberRightPlaces = 2
        Me.TxtAddition.AgPickFromLastValue = False
        Me.TxtAddition.AgRowFilter = ""
        Me.TxtAddition.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAddition.AgSelectedValue = Nothing
        Me.TxtAddition.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAddition.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtAddition.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddition.Location = New System.Drawing.Point(579, 460)
        Me.TxtAddition.Name = "TxtAddition"
        Me.TxtAddition.Size = New System.Drawing.Size(100, 21)
        Me.TxtAddition.TabIndex = 16
        Me.TxtAddition.Text = "AgTextBox4"
        Me.TxtAddition.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblAddition
        '
        Me.LblAddition.AutoSize = True
        Me.LblAddition.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAddition.Location = New System.Drawing.Point(472, 463)
        Me.LblAddition.Name = "LblAddition"
        Me.LblAddition.Size = New System.Drawing.Size(53, 13)
        Me.LblAddition.TabIndex = 227
        Me.LblAddition.Text = "Addition"
        '
        'TxtAddition_H
        '
        Me.TxtAddition_H.AgAllowUserToEnableMasterHelp = False
        Me.TxtAddition_H.AgMandatory = False
        Me.TxtAddition_H.AgMasterHelp = False
        Me.TxtAddition_H.AgNumberLeftPlaces = 8
        Me.TxtAddition_H.AgNumberNegetiveAllow = False
        Me.TxtAddition_H.AgNumberRightPlaces = 2
        Me.TxtAddition_H.AgPickFromLastValue = False
        Me.TxtAddition_H.AgRowFilter = ""
        Me.TxtAddition_H.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAddition_H.AgSelectedValue = Nothing
        Me.TxtAddition_H.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAddition_H.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtAddition_H.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAddition_H.ForeColor = System.Drawing.Color.Black
        Me.TxtAddition_H.Location = New System.Drawing.Point(817, 441)
        Me.TxtAddition_H.Name = "TxtAddition_H"
        Me.TxtAddition_H.Size = New System.Drawing.Size(100, 21)
        Me.TxtAddition_H.TabIndex = 13
        Me.TxtAddition_H.Text = "AgTextBox2"
        Me.TxtAddition_H.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblAddition_H
        '
        Me.LblAddition_H.AutoSize = True
        Me.LblAddition_H.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAddition_H.ForeColor = System.Drawing.Color.Black
        Me.LblAddition_H.Location = New System.Drawing.Point(710, 444)
        Me.LblAddition_H.Name = "LblAddition_H"
        Me.LblAddition_H.Size = New System.Drawing.Size(87, 13)
        Me.LblAddition_H.TabIndex = 232
        Me.LblAddition_H.Text = "Misc. Charges"
        '
        'TxtDeduction_H
        '
        Me.TxtDeduction_H.AgAllowUserToEnableMasterHelp = False
        Me.TxtDeduction_H.AgMandatory = False
        Me.TxtDeduction_H.AgMasterHelp = False
        Me.TxtDeduction_H.AgNumberLeftPlaces = 8
        Me.TxtDeduction_H.AgNumberNegetiveAllow = False
        Me.TxtDeduction_H.AgNumberRightPlaces = 2
        Me.TxtDeduction_H.AgPickFromLastValue = False
        Me.TxtDeduction_H.AgRowFilter = ""
        Me.TxtDeduction_H.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDeduction_H.AgSelectedValue = Nothing
        Me.TxtDeduction_H.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDeduction_H.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtDeduction_H.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDeduction_H.Location = New System.Drawing.Point(817, 463)
        Me.TxtDeduction_H.Name = "TxtDeduction_H"
        Me.TxtDeduction_H.Size = New System.Drawing.Size(100, 21)
        Me.TxtDeduction_H.TabIndex = 14
        Me.TxtDeduction_H.Text = "AgTextBox4"
        Me.TxtDeduction_H.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblDeduction_H
        '
        Me.LblDeduction_H.AutoSize = True
        Me.LblDeduction_H.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDeduction_H.Location = New System.Drawing.Point(710, 466)
        Me.LblDeduction_H.Name = "LblDeduction_H"
        Me.LblDeduction_H.Size = New System.Drawing.Size(56, 13)
        Me.LblDeduction_H.TabIndex = 237
        Me.LblDeduction_H.Text = "Discount"
        '
        'TxtInvoiceAmount
        '
        Me.TxtInvoiceAmount.AgAllowUserToEnableMasterHelp = False
        Me.TxtInvoiceAmount.AgMandatory = False
        Me.TxtInvoiceAmount.AgMasterHelp = False
        Me.TxtInvoiceAmount.AgNumberLeftPlaces = 8
        Me.TxtInvoiceAmount.AgNumberNegetiveAllow = False
        Me.TxtInvoiceAmount.AgNumberRightPlaces = 2
        Me.TxtInvoiceAmount.AgPickFromLastValue = False
        Me.TxtInvoiceAmount.AgRowFilter = ""
        Me.TxtInvoiceAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtInvoiceAmount.AgSelectedValue = Nothing
        Me.TxtInvoiceAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtInvoiceAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtInvoiceAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInvoiceAmount.Location = New System.Drawing.Point(817, 485)
        Me.TxtInvoiceAmount.Name = "TxtInvoiceAmount"
        Me.TxtInvoiceAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtInvoiceAmount.TabIndex = 235
        Me.TxtInvoiceAmount.Text = "AgTextBox2"
        Me.TxtInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(710, 488)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(97, 13)
        Me.Label11.TabIndex = 236
        Me.Label11.Text = "Invoice Amount"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(19, 442)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "&Remark"
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
        Me.TxtRemark.Location = New System.Drawing.Point(89, 438)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(325, 21)
        Me.TxtRemark.TabIndex = 19
        Me.TxtRemark.Text = "TxtRemark"
        '
        'LblDepartmentReq
        '
        Me.LblDepartmentReq.AutoSize = True
        Me.LblDepartmentReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblDepartmentReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblDepartmentReq.Location = New System.Drawing.Point(133, 172)
        Me.LblDepartmentReq.Name = "LblDepartmentReq"
        Me.LblDepartmentReq.Size = New System.Drawing.Size(10, 7)
        Me.LblDepartmentReq.TabIndex = 293
        Me.LblDepartmentReq.Text = "Ä"
        '
        'TxtDepartment
        '
        Me.TxtDepartment.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtDepartment.Location = New System.Drawing.Point(146, 165)
        Me.TxtDepartment.MaxLength = 10
        Me.TxtDepartment.Name = "TxtDepartment"
        Me.TxtDepartment.Size = New System.Drawing.Size(325, 21)
        Me.TxtDepartment.TabIndex = 6
        Me.TxtDepartment.Text = "AgTextBox1"
        '
        'LblDepartment
        '
        Me.LblDepartment.AutoSize = True
        Me.LblDepartment.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDepartment.Location = New System.Drawing.Point(22, 169)
        Me.LblDepartment.Name = "LblDepartment"
        Me.LblDepartment.Size = New System.Drawing.Size(75, 13)
        Me.LblDepartment.TabIndex = 292
        Me.LblDepartment.Text = "Department"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnApproved)
        Me.GroupBox1.Controls.Add(Me.TxtApproved)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(713, 556)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 51)
        Me.GroupBox1.TabIndex = 294
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "UP"
        Me.GroupBox1.Text = "Approved By "
        Me.GroupBox1.Visible = False
        '
        'BtnApproved
        '
        Me.BtnApproved.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApproved.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.BtnApproved.Image = CType(resources.GetObject("BtnApproved.Image"), System.Drawing.Image)
        Me.BtnApproved.Location = New System.Drawing.Point(13, 19)
        Me.BtnApproved.Name = "BtnApproved"
        Me.BtnApproved.Size = New System.Drawing.Size(23, 23)
        Me.BtnApproved.TabIndex = 36
        Me.BtnApproved.UseVisualStyleBackColor = True
        '
        'TxtApproved
        '
        Me.TxtApproved.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtApproved.BackColor = System.Drawing.Color.White
        Me.TxtApproved.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtApproved.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApproved.Location = New System.Drawing.Point(43, 21)
        Me.TxtApproved.Name = "TxtApproved"
        Me.TxtApproved.ReadOnly = True
        Me.TxtApproved.Size = New System.Drawing.Size(158, 18)
        Me.TxtApproved.TabIndex = 0
        Me.TxtApproved.TabStop = False
        Me.TxtApproved.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblRefNo
        '
        Me.LblRefNo.AutoSize = True
        Me.LblRefNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRefNo.Location = New System.Drawing.Point(22, 147)
        Me.LblRefNo.Name = "LblRefNo"
        Me.LblRefNo.Size = New System.Drawing.Size(88, 13)
        Me.LblRefNo.TabIndex = 713
        Me.LblRefNo.Text = "Reference No."
        '
        'TxtRefNo
        '
        Me.TxtRefNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtRefNo.AgMandatory = True
        Me.TxtRefNo.AgMasterHelp = True
        Me.TxtRefNo.AgNumberLeftPlaces = 0
        Me.TxtRefNo.AgNumberNegetiveAllow = False
        Me.TxtRefNo.AgNumberRightPlaces = 0
        Me.TxtRefNo.AgPickFromLastValue = False
        Me.TxtRefNo.AgRowFilter = ""
        Me.TxtRefNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRefNo.AgSelectedValue = Nothing
        Me.TxtRefNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRefNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRefNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRefNo.Location = New System.Drawing.Point(146, 143)
        Me.TxtRefNo.MaxLength = 25
        Me.TxtRefNo.Name = "TxtRefNo"
        Me.TxtRefNo.Size = New System.Drawing.Size(325, 21)
        Me.TxtRefNo.TabIndex = 5
        Me.TxtRefNo.Text = "TxtRefNo."
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label66.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label66.Location = New System.Drawing.Point(133, 150)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(10, 7)
        Me.Label66.TabIndex = 714
        Me.Label66.Text = "Ä"
        '
        'FrmSale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 616)
        Me.Controls.Add(Me.LblRefNo)
        Me.Controls.Add(Me.TxtRefNo)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblDepartmentReq)
        Me.Controls.Add(Me.TxtDepartment)
        Me.Controls.Add(Me.LblDepartment)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.TxtDeduction_H)
        Me.Controls.Add(Me.LblDeduction_H)
        Me.Controls.Add(Me.TxtInvoiceAmount)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtAddition_H)
        Me.Controls.Add(Me.LblAddition_H)
        Me.Controls.Add(Me.TxtAddition)
        Me.Controls.Add(Me.LblAddition)
        Me.Controls.Add(Me.TxtDeduction)
        Me.Controls.Add(Me.LblDeduction)
        Me.Controls.Add(Me.TxtAmount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblAcCodeReq)
        Me.Controls.Add(Me.LblCity)
        Me.Controls.Add(Me.LblAddress)
        Me.Controls.Add(Me.TxtCity)
        Me.Controls.Add(Me.TxtAddress3)
        Me.Controls.Add(Me.TxtAddress2)
        Me.Controls.Add(Me.TxtAddress1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtDocId)
        Me.Controls.Add(Me.LblDocId)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.TxtV_No)
        Me.Controls.Add(Me.LblV_No)
        Me.Controls.Add(Me.TxtV_Type)
        Me.Controls.Add(Me.LblV_Type)
        Me.Controls.Add(Me.TxtAcCode)
        Me.Controls.Add(Me.LblAcCode)
        Me.Controls.Add(Me.TxtNetAmount)
        Me.Controls.Add(Me.LblTotalNetAmount)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LblPrefix)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSale"
        Me.Text = "Trip Money Receipt Entry"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtDocId As AgControls.AgTextBox
    Friend WithEvents LblDocId As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents TxtV_Date As AgControls.AgTextBox
    Friend WithEvents TxtV_No As AgControls.AgTextBox
    Friend WithEvents LblV_No As System.Windows.Forms.Label
    Friend WithEvents TxtV_Type As AgControls.AgTextBox
    Friend WithEvents LblV_Type As System.Windows.Forms.Label
    Friend WithEvents TxtAcCode As AgControls.AgTextBox
    Friend WithEvents LblAcCode As System.Windows.Forms.Label
    Friend WithEvents TxtNetAmount As AgControls.AgTextBox
    Friend WithEvents LblTotalNetAmount As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblV_Date As System.Windows.Forms.Label
    Friend WithEvents LblCity As System.Windows.Forms.Label
    Friend WithEvents LblAddress As System.Windows.Forms.Label
    Friend WithEvents TxtCity As AgControls.AgTextBox
    Friend WithEvents TxtAddress3 As AgControls.AgTextBox
    Friend WithEvents TxtAddress2 As AgControls.AgTextBox
    Friend WithEvents TxtAddress1 As AgControls.AgTextBox
    Friend WithEvents LblAcCodeReq As System.Windows.Forms.Label
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtAmount As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDeduction As AgControls.AgTextBox
    Friend WithEvents LblDeduction As System.Windows.Forms.Label
    Friend WithEvents TxtAddition As AgControls.AgTextBox
    Friend WithEvents LblAddition As System.Windows.Forms.Label
    Friend WithEvents TxtAddition_H As AgControls.AgTextBox
    Friend WithEvents LblAddition_H As System.Windows.Forms.Label
    Friend WithEvents TxtDeduction_H As AgControls.AgTextBox
    Friend WithEvents LblDeduction_H As System.Windows.Forms.Label
    Friend WithEvents TxtInvoiceAmount As AgControls.AgTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents LblDepartmentReq As System.Windows.Forms.Label
    Friend WithEvents TxtDepartment As AgControls.AgTextBox
    Friend WithEvents LblDepartment As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnApproved As System.Windows.Forms.Button
    Friend WithEvents TxtApproved As System.Windows.Forms.TextBox
    Friend WithEvents LblRefNo As System.Windows.Forms.Label
    Friend WithEvents TxtRefNo As AgControls.AgTextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
End Class
