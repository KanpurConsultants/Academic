<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnviro
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
        Me.components = New System.ComponentModel.Container
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TpAcParameter = New System.Windows.Forms.TabPage
        Me.TxtBookReturn = New AgControls.AgTextBox
        Me.LblBookReturn = New System.Windows.Forms.Label
        Me.TxtEmployeeAcGroup = New AgControls.AgTextBox
        Me.LblEmployeeAcGroup = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtPurchaseAc = New AgControls.AgTextBox
        Me.LblPurchaseAc = New System.Windows.Forms.Label
        Me.TxtDefaultUnit = New AgControls.AgTextBox
        Me.LblDefaultUnit = New System.Windows.Forms.Label
        Me.TxtDefaultLanguage = New AgControls.AgTextBox
        Me.LblDefaultLanguage = New System.Windows.Forms.Label
        Me.TxtDefaultBookType = New AgControls.AgTextBox
        Me.LblDefaultBookType = New System.Windows.Forms.Label
        Me.TxtMemberACGroup = New AgControls.AgTextBox
        Me.LblMemberACGroup = New System.Windows.Forms.Label
        Me.TcEnviro = New System.Windows.Forms.TabControl
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.lblCanTakeClass = New System.Windows.Forms.Label
        Me.txtIsAutoBookID = New AgControls.AgTextBox
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.TpAcParameter.SuspendLayout()
        Me.TcEnviro.SuspendLayout()
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
        Me.Topctrl1.TabIndex = 2
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
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(674, 462)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 201
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
        Me.TxtModified.Location = New System.Drawing.Point(15, 21)
        Me.TxtModified.Name = "TxtModified"
        Me.TxtModified.ReadOnly = True
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
        Me.GrpUP.Location = New System.Drawing.Point(7, 462)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 200
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
        Me.TxtPrepared.Location = New System.Drawing.Point(15, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.ReadOnly = True
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
        Me.GroupBox2.Location = New System.Drawing.Point(0, 451)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 4)
        Me.GroupBox2.TabIndex = 202
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'TpAcParameter
        '
        Me.TpAcParameter.Controls.Add(Me.lblCanTakeClass)
        Me.TpAcParameter.Controls.Add(Me.txtIsAutoBookID)
        Me.TpAcParameter.Controls.Add(Me.TxtBookReturn)
        Me.TpAcParameter.Controls.Add(Me.LblBookReturn)
        Me.TpAcParameter.Controls.Add(Me.TxtEmployeeAcGroup)
        Me.TpAcParameter.Controls.Add(Me.LblEmployeeAcGroup)
        Me.TpAcParameter.Controls.Add(Me.Label1)
        Me.TpAcParameter.Controls.Add(Me.Pnl1)
        Me.TpAcParameter.Controls.Add(Me.TxtPurchaseAc)
        Me.TpAcParameter.Controls.Add(Me.LblPurchaseAc)
        Me.TpAcParameter.Controls.Add(Me.TxtDefaultUnit)
        Me.TpAcParameter.Controls.Add(Me.LblDefaultUnit)
        Me.TpAcParameter.Controls.Add(Me.TxtDefaultLanguage)
        Me.TpAcParameter.Controls.Add(Me.LblDefaultLanguage)
        Me.TpAcParameter.Controls.Add(Me.TxtDefaultBookType)
        Me.TpAcParameter.Controls.Add(Me.LblDefaultBookType)
        Me.TpAcParameter.Controls.Add(Me.TxtMemberACGroup)
        Me.TpAcParameter.Controls.Add(Me.LblMemberACGroup)
        Me.TpAcParameter.Location = New System.Drawing.Point(4, 22)
        Me.TpAcParameter.Name = "TpAcParameter"
        Me.TpAcParameter.Padding = New System.Windows.Forms.Padding(3)
        Me.TpAcParameter.Size = New System.Drawing.Size(666, 319)
        Me.TpAcParameter.TabIndex = 0
        Me.TpAcParameter.Text = "A/c Parameter"
        Me.TpAcParameter.UseVisualStyleBackColor = True
        '
        'TxtBookReturn
        '
        Me.TxtBookReturn.AgAllowUserToEnableMasterHelp = False
        Me.TxtBookReturn.AgMandatory = False
        Me.TxtBookReturn.AgMasterHelp = False
        Me.TxtBookReturn.AgNumberLeftPlaces = 3
        Me.TxtBookReturn.AgNumberNegetiveAllow = False
        Me.TxtBookReturn.AgNumberRightPlaces = 0
        Me.TxtBookReturn.AgPickFromLastValue = False
        Me.TxtBookReturn.AgRowFilter = ""
        Me.TxtBookReturn.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBookReturn.AgSelectedValue = Nothing
        Me.TxtBookReturn.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBookReturn.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtBookReturn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBookReturn.Location = New System.Drawing.Point(283, 147)
        Me.TxtBookReturn.MaxLength = 10
        Me.TxtBookReturn.Name = "TxtBookReturn"
        Me.TxtBookReturn.Size = New System.Drawing.Size(110, 21)
        Me.TxtBookReturn.TabIndex = 6
        '
        'LblBookReturn
        '
        Me.LblBookReturn.AutoSize = True
        Me.LblBookReturn.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBookReturn.ForeColor = System.Drawing.Color.Black
        Me.LblBookReturn.Location = New System.Drawing.Point(71, 151)
        Me.LblBookReturn.Name = "LblBookReturn"
        Me.LblBookReturn.Size = New System.Drawing.Size(212, 13)
        Me.LblBookReturn.TabIndex = 739
        Me.LblBookReturn.Text = "Book Return Reminder Before Days"
        '
        'TxtEmployeeAcGroup
        '
        Me.TxtEmployeeAcGroup.AgAllowUserToEnableMasterHelp = False
        Me.TxtEmployeeAcGroup.AgMandatory = False
        Me.TxtEmployeeAcGroup.AgMasterHelp = False
        Me.TxtEmployeeAcGroup.AgNumberLeftPlaces = 0
        Me.TxtEmployeeAcGroup.AgNumberNegetiveAllow = False
        Me.TxtEmployeeAcGroup.AgNumberRightPlaces = 0
        Me.TxtEmployeeAcGroup.AgPickFromLastValue = False
        Me.TxtEmployeeAcGroup.AgRowFilter = ""
        Me.TxtEmployeeAcGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEmployeeAcGroup.AgSelectedValue = Nothing
        Me.TxtEmployeeAcGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEmployeeAcGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEmployeeAcGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEmployeeAcGroup.Location = New System.Drawing.Point(283, 34)
        Me.TxtEmployeeAcGroup.MaxLength = 10
        Me.TxtEmployeeAcGroup.Name = "TxtEmployeeAcGroup"
        Me.TxtEmployeeAcGroup.Size = New System.Drawing.Size(341, 21)
        Me.TxtEmployeeAcGroup.TabIndex = 1
        '
        'LblEmployeeAcGroup
        '
        Me.LblEmployeeAcGroup.AutoSize = True
        Me.LblEmployeeAcGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEmployeeAcGroup.Location = New System.Drawing.Point(71, 38)
        Me.LblEmployeeAcGroup.Name = "LblEmployeeAcGroup"
        Me.LblEmployeeAcGroup.Size = New System.Drawing.Size(125, 13)
        Me.LblEmployeeAcGroup.TabIndex = 737
        Me.LblEmployeeAcGroup.Text = "Employee A/c Group"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(71, 192)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 735
        Me.Label1.Text = "Book Id Prefix"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(71, 208)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(551, 102)
        Me.Pnl1.TabIndex = 8
        '
        'TxtPurchaseAc
        '
        Me.TxtPurchaseAc.AgAllowUserToEnableMasterHelp = False
        Me.TxtPurchaseAc.AgMandatory = False
        Me.TxtPurchaseAc.AgMasterHelp = False
        Me.TxtPurchaseAc.AgNumberLeftPlaces = 0
        Me.TxtPurchaseAc.AgNumberNegetiveAllow = False
        Me.TxtPurchaseAc.AgNumberRightPlaces = 0
        Me.TxtPurchaseAc.AgPickFromLastValue = False
        Me.TxtPurchaseAc.AgRowFilter = ""
        Me.TxtPurchaseAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPurchaseAc.AgSelectedValue = Nothing
        Me.TxtPurchaseAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPurchaseAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPurchaseAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPurchaseAc.Location = New System.Drawing.Point(283, 125)
        Me.TxtPurchaseAc.MaxLength = 10
        Me.TxtPurchaseAc.Name = "TxtPurchaseAc"
        Me.TxtPurchaseAc.Size = New System.Drawing.Size(341, 21)
        Me.TxtPurchaseAc.TabIndex = 5
        '
        'LblPurchaseAc
        '
        Me.LblPurchaseAc.AutoSize = True
        Me.LblPurchaseAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPurchaseAc.Location = New System.Drawing.Point(71, 129)
        Me.LblPurchaseAc.Name = "LblPurchaseAc"
        Me.LblPurchaseAc.Size = New System.Drawing.Size(89, 13)
        Me.LblPurchaseAc.TabIndex = 519
        Me.LblPurchaseAc.Text = "Purchase  A/C"
        '
        'TxtDefaultUnit
        '
        Me.TxtDefaultUnit.AgAllowUserToEnableMasterHelp = False
        Me.TxtDefaultUnit.AgMandatory = False
        Me.TxtDefaultUnit.AgMasterHelp = False
        Me.TxtDefaultUnit.AgNumberLeftPlaces = 0
        Me.TxtDefaultUnit.AgNumberNegetiveAllow = False
        Me.TxtDefaultUnit.AgNumberRightPlaces = 0
        Me.TxtDefaultUnit.AgPickFromLastValue = False
        Me.TxtDefaultUnit.AgRowFilter = ""
        Me.TxtDefaultUnit.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDefaultUnit.AgSelectedValue = Nothing
        Me.TxtDefaultUnit.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDefaultUnit.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDefaultUnit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDefaultUnit.Location = New System.Drawing.Point(283, 102)
        Me.TxtDefaultUnit.MaxLength = 10
        Me.TxtDefaultUnit.Name = "TxtDefaultUnit"
        Me.TxtDefaultUnit.Size = New System.Drawing.Size(341, 21)
        Me.TxtDefaultUnit.TabIndex = 4
        '
        'LblDefaultUnit
        '
        Me.LblDefaultUnit.AutoSize = True
        Me.LblDefaultUnit.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDefaultUnit.Location = New System.Drawing.Point(71, 106)
        Me.LblDefaultUnit.Name = "LblDefaultUnit"
        Me.LblDefaultUnit.Size = New System.Drawing.Size(74, 13)
        Me.LblDefaultUnit.TabIndex = 517
        Me.LblDefaultUnit.Text = "Default Unit"
        '
        'TxtDefaultLanguage
        '
        Me.TxtDefaultLanguage.AgAllowUserToEnableMasterHelp = False
        Me.TxtDefaultLanguage.AgMandatory = False
        Me.TxtDefaultLanguage.AgMasterHelp = True
        Me.TxtDefaultLanguage.AgNumberLeftPlaces = 0
        Me.TxtDefaultLanguage.AgNumberNegetiveAllow = False
        Me.TxtDefaultLanguage.AgNumberRightPlaces = 0
        Me.TxtDefaultLanguage.AgPickFromLastValue = False
        Me.TxtDefaultLanguage.AgRowFilter = ""
        Me.TxtDefaultLanguage.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDefaultLanguage.AgSelectedValue = Nothing
        Me.TxtDefaultLanguage.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDefaultLanguage.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDefaultLanguage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDefaultLanguage.Location = New System.Drawing.Point(283, 79)
        Me.TxtDefaultLanguage.MaxLength = 50
        Me.TxtDefaultLanguage.Name = "TxtDefaultLanguage"
        Me.TxtDefaultLanguage.Size = New System.Drawing.Size(341, 21)
        Me.TxtDefaultLanguage.TabIndex = 3
        '
        'LblDefaultLanguage
        '
        Me.LblDefaultLanguage.AutoSize = True
        Me.LblDefaultLanguage.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDefaultLanguage.Location = New System.Drawing.Point(71, 83)
        Me.LblDefaultLanguage.Name = "LblDefaultLanguage"
        Me.LblDefaultLanguage.Size = New System.Drawing.Size(111, 13)
        Me.LblDefaultLanguage.TabIndex = 515
        Me.LblDefaultLanguage.Text = "Default  Language"
        '
        'TxtDefaultBookType
        '
        Me.TxtDefaultBookType.AgAllowUserToEnableMasterHelp = False
        Me.TxtDefaultBookType.AgMandatory = False
        Me.TxtDefaultBookType.AgMasterHelp = False
        Me.TxtDefaultBookType.AgNumberLeftPlaces = 0
        Me.TxtDefaultBookType.AgNumberNegetiveAllow = False
        Me.TxtDefaultBookType.AgNumberRightPlaces = 0
        Me.TxtDefaultBookType.AgPickFromLastValue = False
        Me.TxtDefaultBookType.AgRowFilter = ""
        Me.TxtDefaultBookType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDefaultBookType.AgSelectedValue = Nothing
        Me.TxtDefaultBookType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDefaultBookType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDefaultBookType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDefaultBookType.Location = New System.Drawing.Point(283, 56)
        Me.TxtDefaultBookType.MaxLength = 10
        Me.TxtDefaultBookType.Name = "TxtDefaultBookType"
        Me.TxtDefaultBookType.Size = New System.Drawing.Size(341, 21)
        Me.TxtDefaultBookType.TabIndex = 2
        '
        'LblDefaultBookType
        '
        Me.LblDefaultBookType.AutoSize = True
        Me.LblDefaultBookType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDefaultBookType.Location = New System.Drawing.Point(71, 60)
        Me.LblDefaultBookType.Name = "LblDefaultBookType"
        Me.LblDefaultBookType.Size = New System.Drawing.Size(113, 13)
        Me.LblDefaultBookType.TabIndex = 513
        Me.LblDefaultBookType.Text = "Default Book Type"
        '
        'TxtMemberACGroup
        '
        Me.TxtMemberACGroup.AgAllowUserToEnableMasterHelp = False
        Me.TxtMemberACGroup.AgMandatory = False
        Me.TxtMemberACGroup.AgMasterHelp = False
        Me.TxtMemberACGroup.AgNumberLeftPlaces = 0
        Me.TxtMemberACGroup.AgNumberNegetiveAllow = False
        Me.TxtMemberACGroup.AgNumberRightPlaces = 0
        Me.TxtMemberACGroup.AgPickFromLastValue = False
        Me.TxtMemberACGroup.AgRowFilter = ""
        Me.TxtMemberACGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberACGroup.AgSelectedValue = Nothing
        Me.TxtMemberACGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberACGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberACGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberACGroup.Location = New System.Drawing.Point(283, 11)
        Me.TxtMemberACGroup.MaxLength = 10
        Me.TxtMemberACGroup.Name = "TxtMemberACGroup"
        Me.TxtMemberACGroup.Size = New System.Drawing.Size(341, 21)
        Me.TxtMemberACGroup.TabIndex = 0
        '
        'LblMemberACGroup
        '
        Me.LblMemberACGroup.AutoSize = True
        Me.LblMemberACGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberACGroup.Location = New System.Drawing.Point(71, 15)
        Me.LblMemberACGroup.Name = "LblMemberACGroup"
        Me.LblMemberACGroup.Size = New System.Drawing.Size(115, 13)
        Me.LblMemberACGroup.TabIndex = 30
        Me.LblMemberACGroup.Text = "Member A/c Group"
        '
        'TcEnviro
        '
        Me.TcEnviro.Controls.Add(Me.TpAcParameter)
        Me.TcEnviro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TcEnviro.Location = New System.Drawing.Point(99, 100)
        Me.TcEnviro.Name = "TcEnviro"
        Me.TcEnviro.SelectedIndex = 0
        Me.TcEnviro.Size = New System.Drawing.Size(674, 345)
        Me.TcEnviro.TabIndex = 1
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
        Me.TxtSite_Code.BackColor = System.Drawing.SystemColors.Control
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(319, 57)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(293, 21)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(216, 61)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 510
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'lblCanTakeClass
        '
        Me.lblCanTakeClass.AutoSize = True
        Me.lblCanTakeClass.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCanTakeClass.Location = New System.Drawing.Point(71, 173)
        Me.lblCanTakeClass.Name = "lblCanTakeClass"
        Me.lblCanTakeClass.Size = New System.Drawing.Size(196, 13)
        Me.lblCanTakeClass.TabIndex = 742
        Me.lblCanTakeClass.Text = "Generate Book ID Automatic Y/N"
        '
        'txtIsAutoBookID
        '
        Me.txtIsAutoBookID.AgAllowUserToEnableMasterHelp = False
        Me.txtIsAutoBookID.AgMandatory = True
        Me.txtIsAutoBookID.AgMasterHelp = False
        Me.txtIsAutoBookID.AgNumberLeftPlaces = 0
        Me.txtIsAutoBookID.AgNumberNegetiveAllow = False
        Me.txtIsAutoBookID.AgNumberRightPlaces = 0
        Me.txtIsAutoBookID.AgPickFromLastValue = False
        Me.txtIsAutoBookID.AgRowFilter = ""
        Me.txtIsAutoBookID.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.txtIsAutoBookID.AgSelectedValue = Nothing
        Me.txtIsAutoBookID.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.txtIsAutoBookID.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.txtIsAutoBookID.BackColor = System.Drawing.Color.White
        Me.txtIsAutoBookID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIsAutoBookID.Location = New System.Drawing.Point(283, 169)
        Me.txtIsAutoBookID.MaxLength = 3
        Me.txtIsAutoBookID.Name = "txtIsAutoBookID"
        Me.txtIsAutoBookID.Size = New System.Drawing.Size(38, 21)
        Me.txtIsAutoBookID.TabIndex = 7
        Me.txtIsAutoBookID.TabStop = False
        '
        'FrmEnviro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 516)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TcEnviro)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmEnviro"
        Me.Text = "Enviro Settings"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.TpAcParameter.ResumeLayout(False)
        Me.TpAcParameter.PerformLayout()
        Me.TcEnviro.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TpAcParameter As System.Windows.Forms.TabPage
    Friend WithEvents TcEnviro As System.Windows.Forms.TabControl
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TxtMemberACGroup As AgControls.AgTextBox
    Friend WithEvents LblMemberACGroup As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtDefaultBookType As AgControls.AgTextBox
    Friend WithEvents LblDefaultBookType As System.Windows.Forms.Label
    Friend WithEvents TxtDefaultUnit As AgControls.AgTextBox
    Friend WithEvents LblDefaultUnit As System.Windows.Forms.Label
    Friend WithEvents TxtDefaultLanguage As AgControls.AgTextBox
    Friend WithEvents LblDefaultLanguage As System.Windows.Forms.Label
    Friend WithEvents TxtPurchaseAc As AgControls.AgTextBox
    Friend WithEvents LblPurchaseAc As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtEmployeeAcGroup As AgControls.AgTextBox
    Friend WithEvents LblEmployeeAcGroup As System.Windows.Forms.Label
    Friend WithEvents LblBookReturn As System.Windows.Forms.Label
    Friend WithEvents TxtBookReturn As AgControls.AgTextBox
    Friend WithEvents lblCanTakeClass As System.Windows.Forms.Label
    Friend WithEvents txtIsAutoBookID As AgControls.AgTextBox
End Class
