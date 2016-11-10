<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmItem
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
        Me.LblItemGroupReq = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtItemGroup = New AgControls.AgTextBox
        Me.LblItemGroup = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDisplayName = New System.Windows.Forms.Label
        Me.LblDisplayNameReq = New System.Windows.Forms.Label
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.TxtManualCode = New AgControls.AgTextBox
        Me.LblManualCode = New System.Windows.Forms.Label
        Me.TxtPurchaseRate = New AgControls.AgTextBox
        Me.TxtSaleRate = New AgControls.AgTextBox
        Me.LblPurchaseRate = New System.Windows.Forms.Label
        Me.LblSaleRate = New System.Windows.Forms.Label
        Me.LblManualCodeReq = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblUnitReq = New System.Windows.Forms.Label
        Me.TxtUnit = New AgControls.AgTextBox
        Me.LblUnit = New System.Windows.Forms.Label
        Me.TxtMRP = New AgControls.AgTextBox
        Me.LblPcsPerCaseReq = New System.Windows.Forms.Label
        Me.LblPcsPerCase = New System.Windows.Forms.Label
        Me.TxtPcsPerCase = New AgControls.AgTextBox
        Me.LblReOrderLevel = New System.Windows.Forms.Label
        Me.TxtReOrderLevel = New AgControls.AgTextBox
        Me.TxtNature = New AgControls.AgTextBox
        Me.LblNature = New System.Windows.Forms.Label
        Me.TxtDisplayName = New AgControls.AgTextBox
        Me.LblItemCategoryReq = New System.Windows.Forms.Label
        Me.TxtItemCategory = New AgControls.AgTextBox
        Me.LblItemCategory = New System.Windows.Forms.Label
        Me.LblNatureReq = New System.Windows.Forms.Label
        Me.TxtSalesTaxPostingGroup = New AgControls.AgTextBox
        Me.LblSalesTaxPostingGroup = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblItemGroupReq
        '
        Me.LblItemGroupReq.AutoSize = True
        Me.LblItemGroupReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblItemGroupReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblItemGroupReq.Location = New System.Drawing.Point(262, 155)
        Me.LblItemGroupReq.Name = "LblItemGroupReq"
        Me.LblItemGroupReq.Size = New System.Drawing.Size(10, 7)
        Me.LblItemGroupReq.TabIndex = 297
        Me.LblItemGroupReq.Text = "Ä"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(674, 353)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 294
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
        Me.GrpUP.Location = New System.Drawing.Point(12, 353)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 293
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
        Me.Topctrl1.TabIndex = 10
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(-4, 339)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(876, 4)
        Me.GroupBox2.TabIndex = 295
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'TxtItemGroup
        '
        Me.TxtItemGroup.AgMandatory = True
        Me.TxtItemGroup.AgMasterHelp = False
        Me.TxtItemGroup.AgNumberLeftPlaces = 0
        Me.TxtItemGroup.AgNumberNegetiveAllow = False
        Me.TxtItemGroup.AgNumberRightPlaces = 0
        Me.TxtItemGroup.AgPickFromLastValue = False
        Me.TxtItemGroup.AgRowFilter = ""
        Me.TxtItemGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtItemGroup.AgSelectedValue = Nothing
        Me.TxtItemGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtItemGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtItemGroup.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtItemGroup.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtItemGroup.Location = New System.Drawing.Point(278, 149)
        Me.TxtItemGroup.MaxLength = 45
        Me.TxtItemGroup.Name = "TxtItemGroup"
        Me.TxtItemGroup.Size = New System.Drawing.Size(372, 18)
        Me.TxtItemGroup.TabIndex = 3
        '
        'LblItemGroup
        '
        Me.LblItemGroup.AutoSize = True
        Me.LblItemGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblItemGroup.Location = New System.Drawing.Point(122, 151)
        Me.LblItemGroup.Name = "LblItemGroup"
        Me.LblItemGroup.Size = New System.Drawing.Size(68, 15)
        Me.LblItemGroup.TabIndex = 290
        Me.LblItemGroup.Text = "Item Group"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(12, 105)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(26, 43)
        Me.Pnl1.TabIndex = 11
        Me.Pnl1.Visible = False
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
        Me.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescription.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(781, 61)
        Me.TxtDescription.MaxLength = 100
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(80, 18)
        Me.TxtDescription.TabIndex = 2
        Me.TxtDescription.Text = "TxtItem"
        Me.TxtDescription.Visible = False
        '
        'LblDisplayName
        '
        Me.LblDisplayName.AutoSize = True
        Me.LblDisplayName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDisplayName.Location = New System.Drawing.Point(122, 131)
        Me.LblDisplayName.Name = "LblDisplayName"
        Me.LblDisplayName.Size = New System.Drawing.Size(68, 15)
        Me.LblDisplayName.TabIndex = 301
        Me.LblDisplayName.Text = "Item Name"
        '
        'LblDisplayNameReq
        '
        Me.LblDisplayNameReq.AutoSize = True
        Me.LblDisplayNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblDisplayNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblDisplayNameReq.Location = New System.Drawing.Point(262, 135)
        Me.LblDisplayNameReq.Name = "LblDisplayNameReq"
        Me.LblDisplayNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblDisplayNameReq.TabIndex = 302
        Me.LblDisplayNameReq.Text = "Ä"
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(12, 61)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(26, 43)
        Me.Pnl2.TabIndex = 12
        Me.Pnl2.Visible = False
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
        Me.TxtManualCode.Location = New System.Drawing.Point(278, 109)
        Me.TxtManualCode.MaxLength = 20
        Me.TxtManualCode.Name = "TxtManualCode"
        Me.TxtManualCode.Size = New System.Drawing.Size(132, 18)
        Me.TxtManualCode.TabIndex = 1
        '
        'LblManualCode
        '
        Me.LblManualCode.AutoSize = True
        Me.LblManualCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualCode.Location = New System.Drawing.Point(122, 111)
        Me.LblManualCode.Name = "LblManualCode"
        Me.LblManualCode.Size = New System.Drawing.Size(80, 15)
        Me.LblManualCode.TabIndex = 305
        Me.LblManualCode.Text = "Manual Code"
        '
        'TxtPurchaseRate
        '
        Me.TxtPurchaseRate.AgMandatory = False
        Me.TxtPurchaseRate.AgMasterHelp = False
        Me.TxtPurchaseRate.AgNumberLeftPlaces = 8
        Me.TxtPurchaseRate.AgNumberNegetiveAllow = False
        Me.TxtPurchaseRate.AgNumberRightPlaces = 2
        Me.TxtPurchaseRate.AgPickFromLastValue = False
        Me.TxtPurchaseRate.AgRowFilter = ""
        Me.TxtPurchaseRate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPurchaseRate.AgSelectedValue = Nothing
        Me.TxtPurchaseRate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPurchaseRate.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtPurchaseRate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPurchaseRate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPurchaseRate.Location = New System.Drawing.Point(278, 209)
        Me.TxtPurchaseRate.MaxLength = 0
        Me.TxtPurchaseRate.Name = "TxtPurchaseRate"
        Me.TxtPurchaseRate.Size = New System.Drawing.Size(132, 18)
        Me.TxtPurchaseRate.TabIndex = 7
        '
        'TxtSaleRate
        '
        Me.TxtSaleRate.AgMandatory = False
        Me.TxtSaleRate.AgMasterHelp = False
        Me.TxtSaleRate.AgNumberLeftPlaces = 8
        Me.TxtSaleRate.AgNumberNegetiveAllow = False
        Me.TxtSaleRate.AgNumberRightPlaces = 2
        Me.TxtSaleRate.AgPickFromLastValue = False
        Me.TxtSaleRate.AgRowFilter = ""
        Me.TxtSaleRate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleRate.AgSelectedValue = Nothing
        Me.TxtSaleRate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleRate.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSaleRate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleRate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleRate.Location = New System.Drawing.Point(550, 209)
        Me.TxtSaleRate.MaxLength = 0
        Me.TxtSaleRate.Name = "TxtSaleRate"
        Me.TxtSaleRate.Size = New System.Drawing.Size(100, 18)
        Me.TxtSaleRate.TabIndex = 8
        '
        'LblPurchaseRate
        '
        Me.LblPurchaseRate.AutoSize = True
        Me.LblPurchaseRate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPurchaseRate.Location = New System.Drawing.Point(122, 211)
        Me.LblPurchaseRate.Name = "LblPurchaseRate"
        Me.LblPurchaseRate.Size = New System.Drawing.Size(89, 15)
        Me.LblPurchaseRate.TabIndex = 308
        Me.LblPurchaseRate.Text = "Purchase Rate"
        '
        'LblSaleRate
        '
        Me.LblSaleRate.AutoSize = True
        Me.LblSaleRate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaleRate.Location = New System.Drawing.Point(462, 211)
        Me.LblSaleRate.Name = "LblSaleRate"
        Me.LblSaleRate.Size = New System.Drawing.Size(61, 15)
        Me.LblSaleRate.TabIndex = 309
        Me.LblSaleRate.Text = "Sale Rate"
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.AutoSize = True
        Me.LblManualCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblManualCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblManualCodeReq.Location = New System.Drawing.Point(262, 115)
        Me.LblManualCodeReq.Name = "LblManualCodeReq"
        Me.LblManualCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblManualCodeReq.TabIndex = 310
        Me.LblManualCodeReq.Text = "Ä"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(262, 95)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 1
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(122, 91)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 402
        Me.LblSite_Code.Text = "Branch/Site"
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(278, 89)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(372, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblUnitReq
        '
        Me.LblUnitReq.AutoSize = True
        Me.LblUnitReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblUnitReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblUnitReq.Location = New System.Drawing.Point(534, 195)
        Me.LblUnitReq.Name = "LblUnitReq"
        Me.LblUnitReq.Size = New System.Drawing.Size(10, 7)
        Me.LblUnitReq.TabIndex = 405
        Me.LblUnitReq.Text = "Ä"
        '
        'TxtUnit
        '
        Me.TxtUnit.AgMandatory = True
        Me.TxtUnit.AgMasterHelp = False
        Me.TxtUnit.AgNumberLeftPlaces = 0
        Me.TxtUnit.AgNumberNegetiveAllow = False
        Me.TxtUnit.AgNumberRightPlaces = 0
        Me.TxtUnit.AgPickFromLastValue = False
        Me.TxtUnit.AgRowFilter = ""
        Me.TxtUnit.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtUnit.AgSelectedValue = Nothing
        Me.TxtUnit.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtUnit.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtUnit.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUnit.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnit.Location = New System.Drawing.Point(550, 189)
        Me.TxtUnit.MaxLength = 45
        Me.TxtUnit.Name = "TxtUnit"
        Me.TxtUnit.Size = New System.Drawing.Size(100, 18)
        Me.TxtUnit.TabIndex = 6
        '
        'LblUnit
        '
        Me.LblUnit.AutoSize = True
        Me.LblUnit.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnit.Location = New System.Drawing.Point(462, 191)
        Me.LblUnit.Name = "LblUnit"
        Me.LblUnit.Size = New System.Drawing.Size(29, 15)
        Me.LblUnit.TabIndex = 404
        Me.LblUnit.Text = "Unit"
        '
        'TxtMRP
        '
        Me.TxtMRP.AgMandatory = False
        Me.TxtMRP.AgMasterHelp = False
        Me.TxtMRP.AgNumberLeftPlaces = 8
        Me.TxtMRP.AgNumberNegetiveAllow = False
        Me.TxtMRP.AgNumberRightPlaces = 2
        Me.TxtMRP.AgPickFromLastValue = False
        Me.TxtMRP.AgRowFilter = ""
        Me.TxtMRP.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMRP.AgSelectedValue = Nothing
        Me.TxtMRP.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMRP.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMRP.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMRP.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMRP.Location = New System.Drawing.Point(781, 121)
        Me.TxtMRP.MaxLength = 0
        Me.TxtMRP.Name = "TxtMRP"
        Me.TxtMRP.Size = New System.Drawing.Size(80, 18)
        Me.TxtMRP.TabIndex = 10
        Me.TxtMRP.Text = "TxtMRP"
        Me.TxtMRP.Visible = False
        '
        'LblPcsPerCaseReq
        '
        Me.LblPcsPerCaseReq.AutoSize = True
        Me.LblPcsPerCaseReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblPcsPerCaseReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblPcsPerCaseReq.Location = New System.Drawing.Point(768, 88)
        Me.LblPcsPerCaseReq.Name = "LblPcsPerCaseReq"
        Me.LblPcsPerCaseReq.Size = New System.Drawing.Size(10, 7)
        Me.LblPcsPerCaseReq.TabIndex = 409
        Me.LblPcsPerCaseReq.Text = "Ä"
        Me.LblPcsPerCaseReq.Visible = False
        '
        'LblPcsPerCase
        '
        Me.LblPcsPerCase.AutoSize = True
        Me.LblPcsPerCase.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPcsPerCase.Location = New System.Drawing.Point(719, 83)
        Me.LblPcsPerCase.Name = "LblPcsPerCase"
        Me.LblPcsPerCase.Size = New System.Drawing.Size(62, 15)
        Me.LblPcsPerCase.TabIndex = 408
        Me.LblPcsPerCase.Text = "Unit/Case"
        Me.LblPcsPerCase.Visible = False
        '
        'TxtPcsPerCase
        '
        Me.TxtPcsPerCase.AgMandatory = True
        Me.TxtPcsPerCase.AgMasterHelp = False
        Me.TxtPcsPerCase.AgNumberLeftPlaces = 8
        Me.TxtPcsPerCase.AgNumberNegetiveAllow = False
        Me.TxtPcsPerCase.AgNumberRightPlaces = 3
        Me.TxtPcsPerCase.AgPickFromLastValue = False
        Me.TxtPcsPerCase.AgRowFilter = ""
        Me.TxtPcsPerCase.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPcsPerCase.AgSelectedValue = Nothing
        Me.TxtPcsPerCase.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPcsPerCase.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtPcsPerCase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPcsPerCase.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPcsPerCase.Location = New System.Drawing.Point(781, 80)
        Me.TxtPcsPerCase.MaxLength = 5
        Me.TxtPcsPerCase.Name = "TxtPcsPerCase"
        Me.TxtPcsPerCase.Size = New System.Drawing.Size(80, 18)
        Me.TxtPcsPerCase.TabIndex = 5
        Me.TxtPcsPerCase.Text = "AgTextBox2"
        Me.TxtPcsPerCase.Visible = False
        '
        'LblReOrderLevel
        '
        Me.LblReOrderLevel.AutoSize = True
        Me.LblReOrderLevel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReOrderLevel.Location = New System.Drawing.Point(719, 103)
        Me.LblReOrderLevel.Name = "LblReOrderLevel"
        Me.LblReOrderLevel.Size = New System.Drawing.Size(84, 15)
        Me.LblReOrderLevel.TabIndex = 411
        Me.LblReOrderLevel.Text = "Reorder Level"
        Me.LblReOrderLevel.Visible = False
        '
        'TxtReOrderLevel
        '
        Me.TxtReOrderLevel.AgMandatory = False
        Me.TxtReOrderLevel.AgMasterHelp = False
        Me.TxtReOrderLevel.AgNumberLeftPlaces = 8
        Me.TxtReOrderLevel.AgNumberNegetiveAllow = False
        Me.TxtReOrderLevel.AgNumberRightPlaces = 3
        Me.TxtReOrderLevel.AgPickFromLastValue = False
        Me.TxtReOrderLevel.AgRowFilter = ""
        Me.TxtReOrderLevel.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtReOrderLevel.AgSelectedValue = Nothing
        Me.TxtReOrderLevel.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtReOrderLevel.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtReOrderLevel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtReOrderLevel.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReOrderLevel.Location = New System.Drawing.Point(781, 101)
        Me.TxtReOrderLevel.MaxLength = 5
        Me.TxtReOrderLevel.Name = "TxtReOrderLevel"
        Me.TxtReOrderLevel.Size = New System.Drawing.Size(80, 18)
        Me.TxtReOrderLevel.TabIndex = 8
        Me.TxtReOrderLevel.Text = "AgTextBox1"
        Me.TxtReOrderLevel.Visible = False
        '
        'TxtNature
        '
        Me.TxtNature.AgMandatory = True
        Me.TxtNature.AgMasterHelp = False
        Me.TxtNature.AgNumberLeftPlaces = 0
        Me.TxtNature.AgNumberNegetiveAllow = False
        Me.TxtNature.AgNumberRightPlaces = 0
        Me.TxtNature.AgPickFromLastValue = False
        Me.TxtNature.AgRowFilter = ""
        Me.TxtNature.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtNature.AgSelectedValue = Nothing
        Me.TxtNature.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtNature.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtNature.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNature.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNature.Location = New System.Drawing.Point(278, 189)
        Me.TxtNature.MaxLength = 45
        Me.TxtNature.Name = "TxtNature"
        Me.TxtNature.Size = New System.Drawing.Size(132, 18)
        Me.TxtNature.TabIndex = 5
        '
        'LblNature
        '
        Me.LblNature.AutoSize = True
        Me.LblNature.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNature.Location = New System.Drawing.Point(122, 191)
        Me.LblNature.Name = "LblNature"
        Me.LblNature.Size = New System.Drawing.Size(44, 15)
        Me.LblNature.TabIndex = 413
        Me.LblNature.Text = "Nature"
        '
        'TxtDisplayName
        '
        Me.TxtDisplayName.AgMandatory = True
        Me.TxtDisplayName.AgMasterHelp = True
        Me.TxtDisplayName.AgNumberLeftPlaces = 0
        Me.TxtDisplayName.AgNumberNegetiveAllow = False
        Me.TxtDisplayName.AgNumberRightPlaces = 0
        Me.TxtDisplayName.AgPickFromLastValue = False
        Me.TxtDisplayName.AgRowFilter = ""
        Me.TxtDisplayName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDisplayName.AgSelectedValue = Nothing
        Me.TxtDisplayName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDisplayName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDisplayName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDisplayName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDisplayName.Location = New System.Drawing.Point(278, 129)
        Me.TxtDisplayName.MaxLength = 100
        Me.TxtDisplayName.Name = "TxtDisplayName"
        Me.TxtDisplayName.Size = New System.Drawing.Size(372, 18)
        Me.TxtDisplayName.TabIndex = 2
        '
        'LblItemCategoryReq
        '
        Me.LblItemCategoryReq.AutoSize = True
        Me.LblItemCategoryReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblItemCategoryReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblItemCategoryReq.Location = New System.Drawing.Point(262, 175)
        Me.LblItemCategoryReq.Name = "LblItemCategoryReq"
        Me.LblItemCategoryReq.Size = New System.Drawing.Size(10, 7)
        Me.LblItemCategoryReq.TabIndex = 417
        Me.LblItemCategoryReq.Text = "Ä"
        '
        'TxtItemCategory
        '
        Me.TxtItemCategory.AgMandatory = True
        Me.TxtItemCategory.AgMasterHelp = False
        Me.TxtItemCategory.AgNumberLeftPlaces = 0
        Me.TxtItemCategory.AgNumberNegetiveAllow = False
        Me.TxtItemCategory.AgNumberRightPlaces = 0
        Me.TxtItemCategory.AgPickFromLastValue = False
        Me.TxtItemCategory.AgRowFilter = ""
        Me.TxtItemCategory.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtItemCategory.AgSelectedValue = Nothing
        Me.TxtItemCategory.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtItemCategory.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtItemCategory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtItemCategory.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtItemCategory.Location = New System.Drawing.Point(278, 169)
        Me.TxtItemCategory.MaxLength = 45
        Me.TxtItemCategory.Name = "TxtItemCategory"
        Me.TxtItemCategory.Size = New System.Drawing.Size(372, 18)
        Me.TxtItemCategory.TabIndex = 4
        '
        'LblItemCategory
        '
        Me.LblItemCategory.AutoSize = True
        Me.LblItemCategory.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblItemCategory.Location = New System.Drawing.Point(122, 171)
        Me.LblItemCategory.Name = "LblItemCategory"
        Me.LblItemCategory.Size = New System.Drawing.Size(83, 15)
        Me.LblItemCategory.TabIndex = 416
        Me.LblItemCategory.Text = "Item Category"
        '
        'LblNatureReq
        '
        Me.LblNatureReq.AutoSize = True
        Me.LblNatureReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblNatureReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblNatureReq.Location = New System.Drawing.Point(262, 195)
        Me.LblNatureReq.Name = "LblNatureReq"
        Me.LblNatureReq.Size = New System.Drawing.Size(10, 7)
        Me.LblNatureReq.TabIndex = 418
        Me.LblNatureReq.Text = "Ä"
        '
        'TxtSalesTaxPostingGroup
        '
        Me.TxtSalesTaxPostingGroup.AgMandatory = True
        Me.TxtSalesTaxPostingGroup.AgMasterHelp = False
        Me.TxtSalesTaxPostingGroup.AgNumberLeftPlaces = 0
        Me.TxtSalesTaxPostingGroup.AgNumberNegetiveAllow = False
        Me.TxtSalesTaxPostingGroup.AgNumberRightPlaces = 0
        Me.TxtSalesTaxPostingGroup.AgPickFromLastValue = False
        Me.TxtSalesTaxPostingGroup.AgRowFilter = ""
        Me.TxtSalesTaxPostingGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSalesTaxPostingGroup.AgSelectedValue = Nothing
        Me.TxtSalesTaxPostingGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSalesTaxPostingGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSalesTaxPostingGroup.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSalesTaxPostingGroup.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSalesTaxPostingGroup.Location = New System.Drawing.Point(278, 229)
        Me.TxtSalesTaxPostingGroup.MaxLength = 0
        Me.TxtSalesTaxPostingGroup.Name = "TxtSalesTaxPostingGroup"
        Me.TxtSalesTaxPostingGroup.Size = New System.Drawing.Size(372, 18)
        Me.TxtSalesTaxPostingGroup.TabIndex = 9
        '
        'LblSalesTaxPostingGroup
        '
        Me.LblSalesTaxPostingGroup.AutoSize = True
        Me.LblSalesTaxPostingGroup.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSalesTaxPostingGroup.Location = New System.Drawing.Point(122, 231)
        Me.LblSalesTaxPostingGroup.Name = "LblSalesTaxPostingGroup"
        Me.LblSalesTaxPostingGroup.Size = New System.Drawing.Size(143, 15)
        Me.LblSalesTaxPostingGroup.TabIndex = 420
        Me.LblSalesTaxPostingGroup.Text = "Sales Tax Posting Group"
        '
        'FrmItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 416)
        Me.Controls.Add(Me.TxtSalesTaxPostingGroup)
        Me.Controls.Add(Me.LblSalesTaxPostingGroup)
        Me.Controls.Add(Me.LblNatureReq)
        Me.Controls.Add(Me.LblItemCategoryReq)
        Me.Controls.Add(Me.TxtItemCategory)
        Me.Controls.Add(Me.LblItemCategory)
        Me.Controls.Add(Me.TxtDisplayName)
        Me.Controls.Add(Me.LblNature)
        Me.Controls.Add(Me.TxtNature)
        Me.Controls.Add(Me.TxtReOrderLevel)
        Me.Controls.Add(Me.LblPcsPerCaseReq)
        Me.Controls.Add(Me.LblPcsPerCase)
        Me.Controls.Add(Me.TxtPcsPerCase)
        Me.Controls.Add(Me.TxtMRP)
        Me.Controls.Add(Me.LblUnitReq)
        Me.Controls.Add(Me.TxtUnit)
        Me.Controls.Add(Me.LblUnit)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblManualCodeReq)
        Me.Controls.Add(Me.LblSaleRate)
        Me.Controls.Add(Me.LblPurchaseRate)
        Me.Controls.Add(Me.TxtSaleRate)
        Me.Controls.Add(Me.TxtPurchaseRate)
        Me.Controls.Add(Me.LblManualCode)
        Me.Controls.Add(Me.TxtManualCode)
        Me.Controls.Add(Me.Pnl2)
        Me.Controls.Add(Me.LblDisplayNameReq)
        Me.Controls.Add(Me.LblDisplayName)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblItemGroupReq)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtItemGroup)
        Me.Controls.Add(Me.LblItemGroup)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LblReOrderLevel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmItem"
        Me.Text = "Item Master"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Protected WithEvents LblItemGroupReq As System.Windows.Forms.Label
    Protected WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Protected WithEvents TxtModified As System.Windows.Forms.TextBox
    Protected WithEvents GrpUP As System.Windows.Forms.GroupBox
    Protected WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Protected WithEvents Topctrl1 As Topctrl.Topctrl
    Protected WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Protected WithEvents LblItemGroup As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LblDisplayName As System.Windows.Forms.Label
    Protected WithEvents LblDisplayNameReq As System.Windows.Forms.Label
    Protected WithEvents Pnl2 As System.Windows.Forms.Panel
    Protected WithEvents LblManualCode As System.Windows.Forms.Label
    Protected WithEvents LblPurchaseRate As System.Windows.Forms.Label
    Protected WithEvents LblSaleRate As System.Windows.Forms.Label
    Protected WithEvents LblManualCodeReq As System.Windows.Forms.Label
    Protected WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Protected WithEvents LblSite_Code As System.Windows.Forms.Label
    Protected WithEvents LblUnitReq As System.Windows.Forms.Label
    Protected WithEvents LblUnit As System.Windows.Forms.Label
    Protected WithEvents LblPcsPerCaseReq As System.Windows.Forms.Label
    Protected WithEvents LblPcsPerCase As System.Windows.Forms.Label
    Protected WithEvents LblReOrderLevel As System.Windows.Forms.Label
    Protected WithEvents LblNature As System.Windows.Forms.Label
    Protected WithEvents TxtItemGroup As AgControls.AgTextBox
    Protected WithEvents TxtDescription As AgControls.AgTextBox
    Protected WithEvents TxtManualCode As AgControls.AgTextBox
    Protected WithEvents TxtPurchaseRate As AgControls.AgTextBox
    Protected WithEvents TxtSaleRate As AgControls.AgTextBox
    Protected WithEvents TxtSite_Code As AgControls.AgTextBox
    Protected WithEvents TxtUnit As AgControls.AgTextBox
    Protected WithEvents TxtMRP As AgControls.AgTextBox
    Protected WithEvents TxtPcsPerCase As AgControls.AgTextBox
    Protected WithEvents TxtReOrderLevel As AgControls.AgTextBox
    Protected WithEvents TxtNature As AgControls.AgTextBox
    Protected WithEvents TxtDisplayName As AgControls.AgTextBox
    Protected WithEvents LblItemCategoryReq As System.Windows.Forms.Label
    Protected WithEvents TxtItemCategory As AgControls.AgTextBox
    Protected WithEvents LblItemCategory As System.Windows.Forms.Label
    Protected WithEvents LblNatureReq As System.Windows.Forms.Label
    Protected WithEvents TxtSalesTaxPostingGroup As AgControls.AgTextBox
    Protected WithEvents LblSalesTaxPostingGroup As System.Windows.Forms.Label

End Class
