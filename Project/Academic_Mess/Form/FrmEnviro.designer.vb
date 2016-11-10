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
        Me.TxtIsShift = New AgControls.AgTextBox
        Me.lblIsTransport = New System.Windows.Forms.Label
        Me.TxtSalesTaxGroupItem = New AgControls.AgTextBox
        Me.LblSalesTaxGroupItem = New System.Windows.Forms.Label
        Me.TxtSalesTaxGroupParty = New AgControls.AgTextBox
        Me.LblSalesTaxGroupParty = New System.Windows.Forms.Label
        Me.TcEnviro = New System.Windows.Forms.TabControl
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtServer = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtDatabase = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtPassward = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtUserID = New AgControls.AgTextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
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
        Me.TpAcParameter.BackColor = System.Drawing.Color.LightGray
        Me.TpAcParameter.Controls.Add(Me.TxtServer)
        Me.TpAcParameter.Controls.Add(Me.Label3)
        Me.TpAcParameter.Controls.Add(Me.TxtDatabase)
        Me.TpAcParameter.Controls.Add(Me.Label2)
        Me.TpAcParameter.Controls.Add(Me.TxtPassward)
        Me.TpAcParameter.Controls.Add(Me.Label1)
        Me.TpAcParameter.Controls.Add(Me.TxtUserID)
        Me.TpAcParameter.Controls.Add(Me.Label38)
        Me.TpAcParameter.Controls.Add(Me.LinkLabel1)
        Me.TpAcParameter.Controls.Add(Me.TxtIsShift)
        Me.TpAcParameter.Controls.Add(Me.lblIsTransport)
        Me.TpAcParameter.Controls.Add(Me.TxtSalesTaxGroupItem)
        Me.TpAcParameter.Controls.Add(Me.LblSalesTaxGroupItem)
        Me.TpAcParameter.Controls.Add(Me.TxtSalesTaxGroupParty)
        Me.TpAcParameter.Controls.Add(Me.LblSalesTaxGroupParty)
        Me.TpAcParameter.Location = New System.Drawing.Point(4, 22)
        Me.TpAcParameter.Name = "TpAcParameter"
        Me.TpAcParameter.Padding = New System.Windows.Forms.Padding(3)
        Me.TpAcParameter.Size = New System.Drawing.Size(666, 319)
        Me.TpAcParameter.TabIndex = 0
        Me.TpAcParameter.Text = "A/c Parameter"
        '
        'TxtIsShift
        '
        Me.TxtIsShift.AgAllowUserToEnableMasterHelp = False
        Me.TxtIsShift.AgMandatory = True
        Me.TxtIsShift.AgMasterHelp = False
        Me.TxtIsShift.AgNumberLeftPlaces = 0
        Me.TxtIsShift.AgNumberNegetiveAllow = False
        Me.TxtIsShift.AgNumberRightPlaces = 0
        Me.TxtIsShift.AgPickFromLastValue = False
        Me.TxtIsShift.AgRowFilter = ""
        Me.TxtIsShift.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsShift.AgSelectedValue = Nothing
        Me.TxtIsShift.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsShift.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsShift.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsShift.Location = New System.Drawing.Point(246, 66)
        Me.TxtIsShift.MaxLength = 3
        Me.TxtIsShift.Name = "TxtIsShift"
        Me.TxtIsShift.Size = New System.Drawing.Size(43, 21)
        Me.TxtIsShift.TabIndex = 2
        Me.TxtIsShift.Text = "AgTextBox4"
        '
        'lblIsTransport
        '
        Me.lblIsTransport.AutoSize = True
        Me.lblIsTransport.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIsTransport.Location = New System.Drawing.Point(45, 70)
        Me.lblIsTransport.Name = "lblIsTransport"
        Me.lblIsTransport.Size = New System.Drawing.Size(135, 13)
        Me.lblIsTransport.TabIndex = 743
        Me.lblIsTransport.Text = "Shift Attendance (Y/N)"
        '
        'TxtSalesTaxGroupItem
        '
        Me.TxtSalesTaxGroupItem.AgAllowUserToEnableMasterHelp = False
        Me.TxtSalesTaxGroupItem.AgMandatory = False
        Me.TxtSalesTaxGroupItem.AgMasterHelp = False
        Me.TxtSalesTaxGroupItem.AgNumberLeftPlaces = 0
        Me.TxtSalesTaxGroupItem.AgNumberNegetiveAllow = False
        Me.TxtSalesTaxGroupItem.AgNumberRightPlaces = 0
        Me.TxtSalesTaxGroupItem.AgPickFromLastValue = False
        Me.TxtSalesTaxGroupItem.AgRowFilter = ""
        Me.TxtSalesTaxGroupItem.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSalesTaxGroupItem.AgSelectedValue = Nothing
        Me.TxtSalesTaxGroupItem.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSalesTaxGroupItem.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSalesTaxGroupItem.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSalesTaxGroupItem.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSalesTaxGroupItem.Location = New System.Drawing.Point(246, 46)
        Me.TxtSalesTaxGroupItem.MaxLength = 0
        Me.TxtSalesTaxGroupItem.Name = "TxtSalesTaxGroupItem"
        Me.TxtSalesTaxGroupItem.Size = New System.Drawing.Size(341, 18)
        Me.TxtSalesTaxGroupItem.TabIndex = 1
        '
        'LblSalesTaxGroupItem
        '
        Me.LblSalesTaxGroupItem.AutoSize = True
        Me.LblSalesTaxGroupItem.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSalesTaxGroupItem.Location = New System.Drawing.Point(45, 48)
        Me.LblSalesTaxGroupItem.Name = "LblSalesTaxGroupItem"
        Me.LblSalesTaxGroupItem.Size = New System.Drawing.Size(178, 15)
        Me.LblSalesTaxGroupItem.TabIndex = 741
        Me.LblSalesTaxGroupItem.Text = "Sales Tax Posting Group (Item)"
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.AgAllowUserToEnableMasterHelp = False
        Me.TxtSalesTaxGroupParty.AgMandatory = False
        Me.TxtSalesTaxGroupParty.AgMasterHelp = False
        Me.TxtSalesTaxGroupParty.AgNumberLeftPlaces = 0
        Me.TxtSalesTaxGroupParty.AgNumberNegetiveAllow = False
        Me.TxtSalesTaxGroupParty.AgNumberRightPlaces = 0
        Me.TxtSalesTaxGroupParty.AgPickFromLastValue = False
        Me.TxtSalesTaxGroupParty.AgRowFilter = ""
        Me.TxtSalesTaxGroupParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSalesTaxGroupParty.AgSelectedValue = Nothing
        Me.TxtSalesTaxGroupParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSalesTaxGroupParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSalesTaxGroupParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSalesTaxGroupParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(246, 26)
        Me.TxtSalesTaxGroupParty.MaxLength = 0
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(341, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 0
        '
        'LblSalesTaxGroupParty
        '
        Me.LblSalesTaxGroupParty.AutoSize = True
        Me.LblSalesTaxGroupParty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSalesTaxGroupParty.Location = New System.Drawing.Point(45, 28)
        Me.LblSalesTaxGroupParty.Name = "LblSalesTaxGroupParty"
        Me.LblSalesTaxGroupParty.Size = New System.Drawing.Size(181, 15)
        Me.LblSalesTaxGroupParty.TabIndex = 739
        Me.LblSalesTaxGroupParty.Text = "Sales Tax Posting Group (Party)"
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
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(319, 57)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(293, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(216, 61)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 510
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'TxtServer
        '
        Me.TxtServer.AgAllowUserToEnableMasterHelp = False
        Me.TxtServer.AgMandatory = False
        Me.TxtServer.AgMasterHelp = False
        Me.TxtServer.AgNumberLeftPlaces = 0
        Me.TxtServer.AgNumberNegetiveAllow = False
        Me.TxtServer.AgNumberRightPlaces = 0
        Me.TxtServer.AgPickFromLastValue = False
        Me.TxtServer.AgRowFilter = ""
        Me.TxtServer.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtServer.AgSelectedValue = Nothing
        Me.TxtServer.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtServer.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtServer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtServer.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtServer.Location = New System.Drawing.Point(246, 177)
        Me.TxtServer.MaxLength = 20
        Me.TxtServer.Name = "TxtServer"
        Me.TxtServer.Size = New System.Drawing.Size(341, 19)
        Me.TxtServer.TabIndex = 752
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(48, 180)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 15)
        Me.Label3.TabIndex = 757
        Me.Label3.Text = "Server"
        '
        'TxtDatabase
        '
        Me.TxtDatabase.AgAllowUserToEnableMasterHelp = False
        Me.TxtDatabase.AgMandatory = False
        Me.TxtDatabase.AgMasterHelp = False
        Me.TxtDatabase.AgNumberLeftPlaces = 0
        Me.TxtDatabase.AgNumberNegetiveAllow = False
        Me.TxtDatabase.AgNumberRightPlaces = 0
        Me.TxtDatabase.AgPickFromLastValue = False
        Me.TxtDatabase.AgRowFilter = ""
        Me.TxtDatabase.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDatabase.AgSelectedValue = Nothing
        Me.TxtDatabase.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDatabase.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDatabase.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDatabase.Location = New System.Drawing.Point(246, 156)
        Me.TxtDatabase.MaxLength = 20
        Me.TxtDatabase.Name = "TxtDatabase"
        Me.TxtDatabase.Size = New System.Drawing.Size(341, 19)
        Me.TxtDatabase.TabIndex = 751
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(48, 159)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 15)
        Me.Label2.TabIndex = 756
        Me.Label2.Text = "Database"
        '
        'TxtPassward
        '
        Me.TxtPassward.AgAllowUserToEnableMasterHelp = False
        Me.TxtPassward.AgMandatory = False
        Me.TxtPassward.AgMasterHelp = False
        Me.TxtPassward.AgNumberLeftPlaces = 0
        Me.TxtPassward.AgNumberNegetiveAllow = False
        Me.TxtPassward.AgNumberRightPlaces = 0
        Me.TxtPassward.AgPickFromLastValue = False
        Me.TxtPassward.AgRowFilter = ""
        Me.TxtPassward.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPassward.AgSelectedValue = Nothing
        Me.TxtPassward.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPassward.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPassward.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPassward.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPassward.Location = New System.Drawing.Point(246, 135)
        Me.TxtPassward.MaxLength = 20
        Me.TxtPassward.Name = "TxtPassward"
        Me.TxtPassward.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassward.Size = New System.Drawing.Size(341, 19)
        Me.TxtPassward.TabIndex = 750
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(48, 138)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 755
        Me.Label1.Text = "Passward"
        '
        'TxtUserID
        '
        Me.TxtUserID.AgAllowUserToEnableMasterHelp = False
        Me.TxtUserID.AgMandatory = False
        Me.TxtUserID.AgMasterHelp = False
        Me.TxtUserID.AgNumberLeftPlaces = 0
        Me.TxtUserID.AgNumberNegetiveAllow = False
        Me.TxtUserID.AgNumberRightPlaces = 0
        Me.TxtUserID.AgPickFromLastValue = False
        Me.TxtUserID.AgRowFilter = ""
        Me.TxtUserID.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtUserID.AgSelectedValue = Nothing
        Me.TxtUserID.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtUserID.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtUserID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUserID.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUserID.Location = New System.Drawing.Point(246, 114)
        Me.TxtUserID.MaxLength = 20
        Me.TxtUserID.Name = "TxtUserID"
        Me.TxtUserID.Size = New System.Drawing.Size(341, 19)
        Me.TxtUserID.TabIndex = 749
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(48, 117)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(49, 15)
        Me.Label38.TabIndex = 754
        Me.Label38.Text = "User ID"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(11, 89)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(207, 20)
        Me.LinkLabel1.TabIndex = 753
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Attendance Database Detail:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Protected WithEvents TxtSalesTaxGroupItem As AgControls.AgTextBox
    Friend WithEvents LblSalesTaxGroupItem As System.Windows.Forms.Label
    Protected WithEvents TxtSalesTaxGroupParty As AgControls.AgTextBox
    Friend WithEvents LblSalesTaxGroupParty As System.Windows.Forms.Label
    Friend WithEvents TxtIsShift As AgControls.AgTextBox
    Friend WithEvents lblIsTransport As System.Windows.Forms.Label
    Friend WithEvents TxtServer As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDatabase As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtPassward As AgControls.AgTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtUserID As AgControls.AgTextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
End Class
