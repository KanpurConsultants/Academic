<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFee
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
        Me.TxtManualCode = New AgControls.AgTextBox
        Me.LblManualCode = New System.Windows.Forms.Label
        Me.TxtDispName = New AgControls.AgTextBox
        Me.LblDispName = New System.Windows.Forms.Label
        Me.LblBank_NameReq = New System.Windows.Forms.Label
        Me.LblDispNameReq = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtFeeGroup = New AgControls.AgTextBox
        Me.LblFeeGroup = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtFeeNature = New AgControls.AgTextBox
        Me.LblFeeNature = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtAcGroup = New AgControls.AgTextBox
        Me.LblAcGroup = New System.Windows.Forms.Label
        Me.TxtNature = New AgControls.AgTextBox
        Me.TxtGroupNature = New AgControls.AgTextBox
        Me.ChkRefundable = New System.Windows.Forms.CheckBox
        Me.TxtName = New AgControls.AgTextBox
        Me.LblName = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblRefundable = New System.Windows.Forms.Label
        Me.LblRefundableRemark = New System.Windows.Forms.Label
        Me.TxtCommonAc = New AgControls.AgTextBox
        Me.LblCommonAc = New System.Windows.Forms.Label
        Me.LblCommonAcReq = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtFeeType = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
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
        Me.Topctrl1.TabIndex = 8
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
        Me.TxtManualCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManualCode.Location = New System.Drawing.Point(322, 109)
        Me.TxtManualCode.MaxLength = 20
        Me.TxtManualCode.Name = "TxtManualCode"
        Me.TxtManualCode.Size = New System.Drawing.Size(150, 21)
        Me.TxtManualCode.TabIndex = 1
        '
        'LblManualCode
        '
        Me.LblManualCode.AutoSize = True
        Me.LblManualCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualCode.Location = New System.Drawing.Point(211, 113)
        Me.LblManualCode.Name = "LblManualCode"
        Me.LblManualCode.Size = New System.Drawing.Size(81, 13)
        Me.LblManualCode.TabIndex = 0
        Me.LblManualCode.Text = "Manual Code"
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
        Me.TxtDispName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDispName.Location = New System.Drawing.Point(322, 131)
        Me.TxtDispName.MaxLength = 100
        Me.TxtDispName.Name = "TxtDispName"
        Me.TxtDispName.Size = New System.Drawing.Size(313, 21)
        Me.TxtDispName.TabIndex = 2
        '
        'LblDispName
        '
        Me.LblDispName.AutoSize = True
        Me.LblDispName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDispName.Location = New System.Drawing.Point(211, 135)
        Me.LblDispName.Name = "LblDispName"
        Me.LblDispName.Size = New System.Drawing.Size(86, 13)
        Me.LblDispName.TabIndex = 0
        Me.LblDispName.Text = "Display Name"
        '
        'LblBank_NameReq
        '
        Me.LblBank_NameReq.AutoSize = True
        Me.LblBank_NameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBank_NameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBank_NameReq.Location = New System.Drawing.Point(309, 114)
        Me.LblBank_NameReq.Name = "LblBank_NameReq"
        Me.LblBank_NameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBank_NameReq.TabIndex = 2
        Me.LblBank_NameReq.Text = "Ä"
        '
        'LblDispNameReq
        '
        Me.LblDispNameReq.AutoSize = True
        Me.LblDispNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblDispNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblDispNameReq.Location = New System.Drawing.Point(309, 137)
        Me.LblDispNameReq.Name = "LblDispNameReq"
        Me.LblDispNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblDispNameReq.TabIndex = 3
        Me.LblDispNameReq.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(309, 202)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Ä"
        '
        'TxtFeeGroup
        '
        Me.TxtFeeGroup.AgAllowUserToEnableMasterHelp = False
        Me.TxtFeeGroup.AgMandatory = True
        Me.TxtFeeGroup.AgMasterHelp = False
        Me.TxtFeeGroup.AgNumberLeftPlaces = 0
        Me.TxtFeeGroup.AgNumberNegetiveAllow = False
        Me.TxtFeeGroup.AgNumberRightPlaces = 0
        Me.TxtFeeGroup.AgPickFromLastValue = False
        Me.TxtFeeGroup.AgRowFilter = ""
        Me.TxtFeeGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFeeGroup.AgSelectedValue = Nothing
        Me.TxtFeeGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFeeGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFeeGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFeeGroup.Location = New System.Drawing.Point(322, 197)
        Me.TxtFeeGroup.MaxLength = 20
        Me.TxtFeeGroup.Name = "TxtFeeGroup"
        Me.TxtFeeGroup.Size = New System.Drawing.Size(150, 21)
        Me.TxtFeeGroup.TabIndex = 5
        '
        'LblFeeGroup
        '
        Me.LblFeeGroup.AutoSize = True
        Me.LblFeeGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFeeGroup.Location = New System.Drawing.Point(211, 201)
        Me.LblFeeGroup.Name = "LblFeeGroup"
        Me.LblFeeGroup.Size = New System.Drawing.Size(66, 13)
        Me.LblFeeGroup.TabIndex = 4
        Me.LblFeeGroup.Text = "Fee Group"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(309, 225)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Ä"
        '
        'TxtFeeNature
        '
        Me.TxtFeeNature.AgAllowUserToEnableMasterHelp = False
        Me.TxtFeeNature.AgMandatory = True
        Me.TxtFeeNature.AgMasterHelp = False
        Me.TxtFeeNature.AgNumberLeftPlaces = 0
        Me.TxtFeeNature.AgNumberNegetiveAllow = False
        Me.TxtFeeNature.AgNumberRightPlaces = 0
        Me.TxtFeeNature.AgPickFromLastValue = False
        Me.TxtFeeNature.AgRowFilter = ""
        Me.TxtFeeNature.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFeeNature.AgSelectedValue = Nothing
        Me.TxtFeeNature.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFeeNature.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFeeNature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFeeNature.Location = New System.Drawing.Point(322, 219)
        Me.TxtFeeNature.MaxLength = 20
        Me.TxtFeeNature.Name = "TxtFeeNature"
        Me.TxtFeeNature.Size = New System.Drawing.Size(150, 21)
        Me.TxtFeeNature.TabIndex = 6
        '
        'LblFeeNature
        '
        Me.LblFeeNature.AutoSize = True
        Me.LblFeeNature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFeeNature.Location = New System.Drawing.Point(211, 223)
        Me.LblFeeNature.Name = "LblFeeNature"
        Me.LblFeeNature.Size = New System.Drawing.Size(69, 13)
        Me.LblFeeNature.TabIndex = 7
        Me.LblFeeNature.Text = "Fee Nature"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(309, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 7)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Ä"
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
        Me.TxtAcGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcGroup.Location = New System.Drawing.Point(322, 175)
        Me.TxtAcGroup.MaxLength = 50
        Me.TxtAcGroup.Name = "TxtAcGroup"
        Me.TxtAcGroup.Size = New System.Drawing.Size(313, 21)
        Me.TxtAcGroup.TabIndex = 4
        '
        'LblAcGroup
        '
        Me.LblAcGroup.AutoSize = True
        Me.LblAcGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcGroup.Location = New System.Drawing.Point(211, 179)
        Me.LblAcGroup.Name = "LblAcGroup"
        Me.LblAcGroup.Size = New System.Drawing.Size(91, 13)
        Me.LblAcGroup.TabIndex = 10
        Me.LblAcGroup.Text = "Account Group"
        '
        'TxtNature
        '
        Me.TxtNature.AgAllowUserToEnableMasterHelp = False
        Me.TxtNature.AgMandatory = True
        Me.TxtNature.AgMasterHelp = True
        Me.TxtNature.AgNumberLeftPlaces = 0
        Me.TxtNature.AgNumberNegetiveAllow = False
        Me.TxtNature.AgNumberRightPlaces = 0
        Me.TxtNature.AgPickFromLastValue = False
        Me.TxtNature.AgRowFilter = ""
        Me.TxtNature.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtNature.AgSelectedValue = Nothing
        Me.TxtNature.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtNature.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtNature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNature.Location = New System.Drawing.Point(12, 68)
        Me.TxtNature.MaxLength = 20
        Me.TxtNature.Name = "TxtNature"
        Me.TxtNature.Size = New System.Drawing.Size(115, 21)
        Me.TxtNature.TabIndex = 14
        Me.TxtNature.Text = "TxtNature"
        Me.TxtNature.Visible = False
        '
        'TxtGroupNature
        '
        Me.TxtGroupNature.AgAllowUserToEnableMasterHelp = False
        Me.TxtGroupNature.AgMandatory = True
        Me.TxtGroupNature.AgMasterHelp = True
        Me.TxtGroupNature.AgNumberLeftPlaces = 0
        Me.TxtGroupNature.AgNumberNegetiveAllow = False
        Me.TxtGroupNature.AgNumberRightPlaces = 0
        Me.TxtGroupNature.AgPickFromLastValue = False
        Me.TxtGroupNature.AgRowFilter = ""
        Me.TxtGroupNature.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGroupNature.AgSelectedValue = Nothing
        Me.TxtGroupNature.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGroupNature.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGroupNature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGroupNature.Location = New System.Drawing.Point(12, 46)
        Me.TxtGroupNature.MaxLength = 20
        Me.TxtGroupNature.Name = "TxtGroupNature"
        Me.TxtGroupNature.Size = New System.Drawing.Size(115, 21)
        Me.TxtGroupNature.TabIndex = 13
        Me.TxtGroupNature.Text = "TxtGroupNature"
        Me.TxtGroupNature.Visible = False
        '
        'ChkRefundable
        '
        Me.ChkRefundable.AutoSize = True
        Me.ChkRefundable.BackColor = System.Drawing.Color.Transparent
        Me.ChkRefundable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkRefundable.Location = New System.Drawing.Point(322, 271)
        Me.ChkRefundable.Name = "ChkRefundable"
        Me.ChkRefundable.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkRefundable.Size = New System.Drawing.Size(15, 14)
        Me.ChkRefundable.TabIndex = 8
        Me.ChkRefundable.UseVisualStyleBackColor = False
        '
        'TxtName
        '
        Me.TxtName.AgAllowUserToEnableMasterHelp = False
        Me.TxtName.AgMandatory = True
        Me.TxtName.AgMasterHelp = True
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
        Me.TxtName.Location = New System.Drawing.Point(322, 153)
        Me.TxtName.MaxLength = 123
        Me.TxtName.Name = "TxtName"
        Me.TxtName.ReadOnly = True
        Me.TxtName.Size = New System.Drawing.Size(313, 21)
        Me.TxtName.TabIndex = 3
        Me.TxtName.TabStop = False
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblName.Location = New System.Drawing.Point(211, 157)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(89, 13)
        Me.LblName.TabIndex = 16
        Me.LblName.Text = "Account Name"
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
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(322, 87)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(313, 21)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(211, 92)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 387
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(309, 95)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 386
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblRefundable
        '
        Me.LblRefundable.AutoSize = True
        Me.LblRefundable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRefundable.Location = New System.Drawing.Point(211, 272)
        Me.LblRefundable.Name = "LblRefundable"
        Me.LblRefundable.Size = New System.Drawing.Size(78, 13)
        Me.LblRefundable.TabIndex = 388
        Me.LblRefundable.Text = "Refundable*"
        '
        'LblRefundableRemark
        '
        Me.LblRefundableRemark.AutoSize = True
        Me.LblRefundableRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRefundableRemark.ForeColor = System.Drawing.Color.Blue
        Me.LblRefundableRemark.Location = New System.Drawing.Point(343, 271)
        Me.LblRefundableRemark.Name = "LblRefundableRemark"
        Me.LblRefundableRemark.Size = New System.Drawing.Size(262, 13)
        Me.LblRefundableRemark.TabIndex = 389
        Me.LblRefundableRemark.Text = "*(Applicable In Case of Student Registraion)"
        '
        'TxtCommonAc
        '
        Me.TxtCommonAc.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtCommonAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCommonAc.Location = New System.Drawing.Point(600, 197)
        Me.TxtCommonAc.MaxLength = 3
        Me.TxtCommonAc.Name = "TxtCommonAc"
        Me.TxtCommonAc.Size = New System.Drawing.Size(35, 21)
        Me.TxtCommonAc.TabIndex = 6
        Me.TxtCommonAc.Text = "XXX"
        '
        'LblCommonAc
        '
        Me.LblCommonAc.AutoSize = True
        Me.LblCommonAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCommonAc.Location = New System.Drawing.Point(480, 201)
        Me.LblCommonAc.Name = "LblCommonAc"
        Me.LblCommonAc.Size = New System.Drawing.Size(107, 13)
        Me.LblCommonAc.TabIndex = 597
        Me.LblCommonAc.Text = "Is Common A/c ?"
        '
        'LblCommonAcReq
        '
        Me.LblCommonAcReq.AutoSize = True
        Me.LblCommonAcReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblCommonAcReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblCommonAcReq.Location = New System.Drawing.Point(589, 204)
        Me.LblCommonAcReq.Name = "LblCommonAcReq"
        Me.LblCommonAcReq.Size = New System.Drawing.Size(10, 7)
        Me.LblCommonAcReq.TabIndex = 598
        Me.LblCommonAcReq.Text = "Ä"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(309, 247)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 601
        Me.Label1.Text = "Ä"
        '
        'TxtFeeType
        '
        Me.TxtFeeType.AgAllowUserToEnableMasterHelp = False
        Me.TxtFeeType.AgMandatory = True
        Me.TxtFeeType.AgMasterHelp = False
        Me.TxtFeeType.AgNumberLeftPlaces = 0
        Me.TxtFeeType.AgNumberNegetiveAllow = False
        Me.TxtFeeType.AgNumberRightPlaces = 0
        Me.TxtFeeType.AgPickFromLastValue = False
        Me.TxtFeeType.AgRowFilter = ""
        Me.TxtFeeType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFeeType.AgSelectedValue = Nothing
        Me.TxtFeeType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFeeType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFeeType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFeeType.Location = New System.Drawing.Point(322, 241)
        Me.TxtFeeType.MaxLength = 20
        Me.TxtFeeType.Name = "TxtFeeType"
        Me.TxtFeeType.Size = New System.Drawing.Size(150, 21)
        Me.TxtFeeType.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(211, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 13)
        Me.Label3.TabIndex = 599
        Me.Label3.Text = "Fee Type"
        '
        'FrmFee
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 316)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtFeeType)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblCommonAcReq)
        Me.Controls.Add(Me.TxtCommonAc)
        Me.Controls.Add(Me.LblCommonAc)
        Me.Controls.Add(Me.LblRefundableRemark)
        Me.Controls.Add(Me.LblRefundable)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.LblName)
        Me.Controls.Add(Me.ChkRefundable)
        Me.Controls.Add(Me.TxtNature)
        Me.Controls.Add(Me.TxtGroupNature)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtAcGroup)
        Me.Controls.Add(Me.LblAcGroup)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtFeeNature)
        Me.Controls.Add(Me.LblFeeNature)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtFeeGroup)
        Me.Controls.Add(Me.LblFeeGroup)
        Me.Controls.Add(Me.LblDispNameReq)
        Me.Controls.Add(Me.LblBank_NameReq)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtManualCode)
        Me.Controls.Add(Me.LblManualCode)
        Me.Controls.Add(Me.TxtDispName)
        Me.Controls.Add(Me.LblDispName)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmFee"
        Me.Text = "Fee Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtManualCode As AgControls.AgTextBox
    Friend WithEvents LblManualCode As System.Windows.Forms.Label
    Friend WithEvents TxtDispName As AgControls.AgTextBox
    Friend WithEvents LblDispName As System.Windows.Forms.Label
    Friend WithEvents LblBank_NameReq As System.Windows.Forms.Label
    Friend WithEvents LblDispNameReq As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtFeeGroup As AgControls.AgTextBox
    Friend WithEvents LblFeeGroup As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtFeeNature As AgControls.AgTextBox
    Friend WithEvents LblFeeNature As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtAcGroup As AgControls.AgTextBox
    Friend WithEvents LblAcGroup As System.Windows.Forms.Label
    Friend WithEvents TxtNature As AgControls.AgTextBox
    Friend WithEvents TxtGroupNature As AgControls.AgTextBox
    Friend WithEvents ChkRefundable As System.Windows.Forms.CheckBox
    Friend WithEvents TxtName As AgControls.AgTextBox
    Friend WithEvents LblName As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblRefundable As System.Windows.Forms.Label
    Friend WithEvents LblRefundableRemark As System.Windows.Forms.Label
    Friend WithEvents TxtCommonAc As AgControls.AgTextBox
    Friend WithEvents LblCommonAc As System.Windows.Forms.Label
    Friend WithEvents LblCommonAcReq As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtFeeType As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
