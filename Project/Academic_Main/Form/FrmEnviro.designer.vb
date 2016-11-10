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
        Me.TxtServer = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtDatabase = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtPassward = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtUserID = New AgControls.AgTextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtLockBackDays = New AgControls.AgTextBox
        Me.LblLockBackDays = New System.Windows.Forms.Label
        Me.TxtCounselingFeeAdjustmentAc = New AgControls.AgTextBox
        Me.LblCounselingFeeAdjustmentAc = New System.Windows.Forms.Label
        Me.TxtScholarshipAdjustmentAc = New AgControls.AgTextBox
        Me.LblScholarshipAdjustmentAc = New System.Windows.Forms.Label
        Me.TxtFeeReceiptAdjustmentAc = New AgControls.AgTextBox
        Me.LblFeeReceiptAdjustmentAc = New System.Windows.Forms.Label
        Me.TxtAcGroup_Student = New AgControls.AgTextBox
        Me.LblAcGroup_Student = New System.Windows.Forms.Label
        Me.TxtDiscountAc = New AgControls.AgTextBox
        Me.LblDiscountAc = New System.Windows.Forms.Label
        Me.TxtFeeAdjustmentAc = New AgControls.AgTextBox
        Me.LblFeeAdjustmentAc = New System.Windows.Forms.Label
        Me.TcEnviro = New System.Windows.Forms.TabControl
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtIsAutoAcManualCode = New AgControls.AgTextBox
        Me.LblIsAutoAcManualCode = New System.Windows.Forms.Label
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
        Me.TpAcParameter.Controls.Add(Me.TxtIsAutoAcManualCode)
        Me.TpAcParameter.Controls.Add(Me.LblIsAutoAcManualCode)
        Me.TpAcParameter.Controls.Add(Me.TxtServer)
        Me.TpAcParameter.Controls.Add(Me.Label3)
        Me.TpAcParameter.Controls.Add(Me.TxtDatabase)
        Me.TpAcParameter.Controls.Add(Me.Label2)
        Me.TpAcParameter.Controls.Add(Me.TxtPassward)
        Me.TpAcParameter.Controls.Add(Me.Label1)
        Me.TpAcParameter.Controls.Add(Me.TxtUserID)
        Me.TpAcParameter.Controls.Add(Me.Label38)
        Me.TpAcParameter.Controls.Add(Me.LinkLabel1)
        Me.TpAcParameter.Controls.Add(Me.TxtLockBackDays)
        Me.TpAcParameter.Controls.Add(Me.LblLockBackDays)
        Me.TpAcParameter.Controls.Add(Me.TxtCounselingFeeAdjustmentAc)
        Me.TpAcParameter.Controls.Add(Me.LblCounselingFeeAdjustmentAc)
        Me.TpAcParameter.Controls.Add(Me.TxtScholarshipAdjustmentAc)
        Me.TpAcParameter.Controls.Add(Me.LblScholarshipAdjustmentAc)
        Me.TpAcParameter.Controls.Add(Me.TxtFeeReceiptAdjustmentAc)
        Me.TpAcParameter.Controls.Add(Me.LblFeeReceiptAdjustmentAc)
        Me.TpAcParameter.Controls.Add(Me.TxtAcGroup_Student)
        Me.TpAcParameter.Controls.Add(Me.LblAcGroup_Student)
        Me.TpAcParameter.Controls.Add(Me.TxtDiscountAc)
        Me.TpAcParameter.Controls.Add(Me.LblDiscountAc)
        Me.TpAcParameter.Controls.Add(Me.TxtFeeAdjustmentAc)
        Me.TpAcParameter.Controls.Add(Me.LblFeeAdjustmentAc)
        Me.TpAcParameter.Location = New System.Drawing.Point(4, 22)
        Me.TpAcParameter.Name = "TpAcParameter"
        Me.TpAcParameter.Padding = New System.Windows.Forms.Padding(3)
        Me.TpAcParameter.Size = New System.Drawing.Size(666, 319)
        Me.TpAcParameter.TabIndex = 0
        Me.TpAcParameter.Text = "A/c Parameter"
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
        Me.TxtServer.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtServer.Location = New System.Drawing.Point(255, 273)
        Me.TxtServer.MaxLength = 20
        Me.TxtServer.Name = "TxtServer"
        Me.TxtServer.Size = New System.Drawing.Size(341, 21)
        Me.TxtServer.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(63, 276)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 748
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
        Me.TxtDatabase.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDatabase.Location = New System.Drawing.Point(255, 251)
        Me.TxtDatabase.MaxLength = 20
        Me.TxtDatabase.Name = "TxtDatabase"
        Me.TxtDatabase.Size = New System.Drawing.Size(341, 21)
        Me.TxtDatabase.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 13)
        Me.Label2.TabIndex = 746
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
        Me.TxtPassward.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPassward.Location = New System.Drawing.Point(255, 229)
        Me.TxtPassward.MaxLength = 20
        Me.TxtPassward.Name = "TxtPassward"
        Me.TxtPassward.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtPassward.Size = New System.Drawing.Size(341, 21)
        Me.TxtPassward.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(63, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 13)
        Me.Label1.TabIndex = 744
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
        Me.TxtUserID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUserID.Location = New System.Drawing.Point(255, 207)
        Me.TxtUserID.MaxLength = 20
        Me.TxtUserID.Name = "TxtUserID"
        Me.TxtUserID.Size = New System.Drawing.Size(341, 21)
        Me.TxtUserID.TabIndex = 7
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(63, 210)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(51, 13)
        Me.Label38.TabIndex = 742
        Me.Label38.Text = "User ID"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(20, 182)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(207, 20)
        Me.LinkLabel1.TabIndex = 740
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Attendance Database Detail:"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtLockBackDays
        '
        Me.TxtLockBackDays.AgAllowUserToEnableMasterHelp = False
        Me.TxtLockBackDays.AgMandatory = False
        Me.TxtLockBackDays.AgMasterHelp = False
        Me.TxtLockBackDays.AgNumberLeftPlaces = 5
        Me.TxtLockBackDays.AgNumberNegetiveAllow = False
        Me.TxtLockBackDays.AgNumberRightPlaces = 0
        Me.TxtLockBackDays.AgPickFromLastValue = False
        Me.TxtLockBackDays.AgRowFilter = ""
        Me.TxtLockBackDays.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLockBackDays.AgSelectedValue = Nothing
        Me.TxtLockBackDays.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLockBackDays.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtLockBackDays.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLockBackDays.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLockBackDays.Location = New System.Drawing.Point(255, 146)
        Me.TxtLockBackDays.MaxLength = 10
        Me.TxtLockBackDays.Name = "TxtLockBackDays"
        Me.TxtLockBackDays.Size = New System.Drawing.Size(87, 18)
        Me.TxtLockBackDays.TabIndex = 6
        Me.TxtLockBackDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblLockBackDays
        '
        Me.LblLockBackDays.AutoSize = True
        Me.LblLockBackDays.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLockBackDays.Location = New System.Drawing.Point(62, 150)
        Me.LblLockBackDays.Name = "LblLockBackDays"
        Me.LblLockBackDays.Size = New System.Drawing.Size(166, 13)
        Me.LblLockBackDays.TabIndex = 522
        Me.LblLockBackDays.Text = "Lock Back Days Attendance"
        '
        'TxtCounselingFeeAdjustmentAc
        '
        Me.TxtCounselingFeeAdjustmentAc.AgAllowUserToEnableMasterHelp = False
        Me.TxtCounselingFeeAdjustmentAc.AgMandatory = False
        Me.TxtCounselingFeeAdjustmentAc.AgMasterHelp = False
        Me.TxtCounselingFeeAdjustmentAc.AgNumberLeftPlaces = 0
        Me.TxtCounselingFeeAdjustmentAc.AgNumberNegetiveAllow = False
        Me.TxtCounselingFeeAdjustmentAc.AgNumberRightPlaces = 0
        Me.TxtCounselingFeeAdjustmentAc.AgPickFromLastValue = False
        Me.TxtCounselingFeeAdjustmentAc.AgRowFilter = ""
        Me.TxtCounselingFeeAdjustmentAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCounselingFeeAdjustmentAc.AgSelectedValue = Nothing
        Me.TxtCounselingFeeAdjustmentAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCounselingFeeAdjustmentAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCounselingFeeAdjustmentAc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCounselingFeeAdjustmentAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCounselingFeeAdjustmentAc.Location = New System.Drawing.Point(255, 126)
        Me.TxtCounselingFeeAdjustmentAc.MaxLength = 10
        Me.TxtCounselingFeeAdjustmentAc.Name = "TxtCounselingFeeAdjustmentAc"
        Me.TxtCounselingFeeAdjustmentAc.Size = New System.Drawing.Size(341, 18)
        Me.TxtCounselingFeeAdjustmentAc.TabIndex = 5
        '
        'LblCounselingFeeAdjustmentAc
        '
        Me.LblCounselingFeeAdjustmentAc.AutoSize = True
        Me.LblCounselingFeeAdjustmentAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCounselingFeeAdjustmentAc.Location = New System.Drawing.Point(62, 130)
        Me.LblCounselingFeeAdjustmentAc.Name = "LblCounselingFeeAdjustmentAc"
        Me.LblCounselingFeeAdjustmentAc.Size = New System.Drawing.Size(162, 13)
        Me.LblCounselingFeeAdjustmentAc.TabIndex = 520
        Me.LblCounselingFeeAdjustmentAc.Text = "Counseling Adjustment A/c"
        '
        'TxtScholarshipAdjustmentAc
        '
        Me.TxtScholarshipAdjustmentAc.AgAllowUserToEnableMasterHelp = False
        Me.TxtScholarshipAdjustmentAc.AgMandatory = False
        Me.TxtScholarshipAdjustmentAc.AgMasterHelp = False
        Me.TxtScholarshipAdjustmentAc.AgNumberLeftPlaces = 0
        Me.TxtScholarshipAdjustmentAc.AgNumberNegetiveAllow = False
        Me.TxtScholarshipAdjustmentAc.AgNumberRightPlaces = 0
        Me.TxtScholarshipAdjustmentAc.AgPickFromLastValue = False
        Me.TxtScholarshipAdjustmentAc.AgRowFilter = ""
        Me.TxtScholarshipAdjustmentAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtScholarshipAdjustmentAc.AgSelectedValue = Nothing
        Me.TxtScholarshipAdjustmentAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtScholarshipAdjustmentAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtScholarshipAdjustmentAc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtScholarshipAdjustmentAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtScholarshipAdjustmentAc.Location = New System.Drawing.Point(255, 106)
        Me.TxtScholarshipAdjustmentAc.MaxLength = 10
        Me.TxtScholarshipAdjustmentAc.Name = "TxtScholarshipAdjustmentAc"
        Me.TxtScholarshipAdjustmentAc.Size = New System.Drawing.Size(341, 18)
        Me.TxtScholarshipAdjustmentAc.TabIndex = 4
        '
        'LblScholarshipAdjustmentAc
        '
        Me.LblScholarshipAdjustmentAc.AutoSize = True
        Me.LblScholarshipAdjustmentAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblScholarshipAdjustmentAc.Location = New System.Drawing.Point(62, 110)
        Me.LblScholarshipAdjustmentAc.Name = "LblScholarshipAdjustmentAc"
        Me.LblScholarshipAdjustmentAc.Size = New System.Drawing.Size(165, 13)
        Me.LblScholarshipAdjustmentAc.TabIndex = 518
        Me.LblScholarshipAdjustmentAc.Text = "Scholarship Adjustment A/c"
        '
        'TxtFeeReceiptAdjustmentAc
        '
        Me.TxtFeeReceiptAdjustmentAc.AgAllowUserToEnableMasterHelp = False
        Me.TxtFeeReceiptAdjustmentAc.AgMandatory = False
        Me.TxtFeeReceiptAdjustmentAc.AgMasterHelp = False
        Me.TxtFeeReceiptAdjustmentAc.AgNumberLeftPlaces = 0
        Me.TxtFeeReceiptAdjustmentAc.AgNumberNegetiveAllow = False
        Me.TxtFeeReceiptAdjustmentAc.AgNumberRightPlaces = 0
        Me.TxtFeeReceiptAdjustmentAc.AgPickFromLastValue = False
        Me.TxtFeeReceiptAdjustmentAc.AgRowFilter = ""
        Me.TxtFeeReceiptAdjustmentAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFeeReceiptAdjustmentAc.AgSelectedValue = Nothing
        Me.TxtFeeReceiptAdjustmentAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFeeReceiptAdjustmentAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFeeReceiptAdjustmentAc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFeeReceiptAdjustmentAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFeeReceiptAdjustmentAc.Location = New System.Drawing.Point(255, 86)
        Me.TxtFeeReceiptAdjustmentAc.MaxLength = 10
        Me.TxtFeeReceiptAdjustmentAc.Name = "TxtFeeReceiptAdjustmentAc"
        Me.TxtFeeReceiptAdjustmentAc.Size = New System.Drawing.Size(341, 18)
        Me.TxtFeeReceiptAdjustmentAc.TabIndex = 3
        '
        'LblFeeReceiptAdjustmentAc
        '
        Me.LblFeeReceiptAdjustmentAc.AutoSize = True
        Me.LblFeeReceiptAdjustmentAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFeeReceiptAdjustmentAc.Location = New System.Drawing.Point(62, 90)
        Me.LblFeeReceiptAdjustmentAc.Name = "LblFeeReceiptAdjustmentAc"
        Me.LblFeeReceiptAdjustmentAc.Size = New System.Drawing.Size(165, 13)
        Me.LblFeeReceiptAdjustmentAc.TabIndex = 515
        Me.LblFeeReceiptAdjustmentAc.Text = "Fee Receipt Adjustment A/c"
        '
        'TxtAcGroup_Student
        '
        Me.TxtAcGroup_Student.AgAllowUserToEnableMasterHelp = False
        Me.TxtAcGroup_Student.AgMandatory = False
        Me.TxtAcGroup_Student.AgMasterHelp = False
        Me.TxtAcGroup_Student.AgNumberLeftPlaces = 0
        Me.TxtAcGroup_Student.AgNumberNegetiveAllow = False
        Me.TxtAcGroup_Student.AgNumberRightPlaces = 0
        Me.TxtAcGroup_Student.AgPickFromLastValue = False
        Me.TxtAcGroup_Student.AgRowFilter = ""
        Me.TxtAcGroup_Student.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAcGroup_Student.AgSelectedValue = Nothing
        Me.TxtAcGroup_Student.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAcGroup_Student.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAcGroup_Student.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAcGroup_Student.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcGroup_Student.Location = New System.Drawing.Point(255, 26)
        Me.TxtAcGroup_Student.MaxLength = 10
        Me.TxtAcGroup_Student.Name = "TxtAcGroup_Student"
        Me.TxtAcGroup_Student.Size = New System.Drawing.Size(341, 18)
        Me.TxtAcGroup_Student.TabIndex = 0
        '
        'LblAcGroup_Student
        '
        Me.LblAcGroup_Student.AutoSize = True
        Me.LblAcGroup_Student.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcGroup_Student.Location = New System.Drawing.Point(62, 30)
        Me.LblAcGroup_Student.Name = "LblAcGroup_Student"
        Me.LblAcGroup_Student.Size = New System.Drawing.Size(113, 13)
        Me.LblAcGroup_Student.TabIndex = 30
        Me.LblAcGroup_Student.Text = "Student A/c Group"
        '
        'TxtDiscountAc
        '
        Me.TxtDiscountAc.AgAllowUserToEnableMasterHelp = False
        Me.TxtDiscountAc.AgMandatory = False
        Me.TxtDiscountAc.AgMasterHelp = False
        Me.TxtDiscountAc.AgNumberLeftPlaces = 0
        Me.TxtDiscountAc.AgNumberNegetiveAllow = False
        Me.TxtDiscountAc.AgNumberRightPlaces = 0
        Me.TxtDiscountAc.AgPickFromLastValue = False
        Me.TxtDiscountAc.AgRowFilter = ""
        Me.TxtDiscountAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDiscountAc.AgSelectedValue = Nothing
        Me.TxtDiscountAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDiscountAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDiscountAc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDiscountAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiscountAc.Location = New System.Drawing.Point(255, 46)
        Me.TxtDiscountAc.MaxLength = 10
        Me.TxtDiscountAc.Name = "TxtDiscountAc"
        Me.TxtDiscountAc.Size = New System.Drawing.Size(341, 18)
        Me.TxtDiscountAc.TabIndex = 1
        '
        'LblDiscountAc
        '
        Me.LblDiscountAc.AutoSize = True
        Me.LblDiscountAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiscountAc.Location = New System.Drawing.Point(62, 50)
        Me.LblDiscountAc.Name = "LblDiscountAc"
        Me.LblDiscountAc.Size = New System.Drawing.Size(82, 13)
        Me.LblDiscountAc.TabIndex = 28
        Me.LblDiscountAc.Text = "Discount A/C"
        '
        'TxtFeeAdjustmentAc
        '
        Me.TxtFeeAdjustmentAc.AgAllowUserToEnableMasterHelp = False
        Me.TxtFeeAdjustmentAc.AgMandatory = False
        Me.TxtFeeAdjustmentAc.AgMasterHelp = False
        Me.TxtFeeAdjustmentAc.AgNumberLeftPlaces = 0
        Me.TxtFeeAdjustmentAc.AgNumberNegetiveAllow = False
        Me.TxtFeeAdjustmentAc.AgNumberRightPlaces = 0
        Me.TxtFeeAdjustmentAc.AgPickFromLastValue = False
        Me.TxtFeeAdjustmentAc.AgRowFilter = ""
        Me.TxtFeeAdjustmentAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFeeAdjustmentAc.AgSelectedValue = Nothing
        Me.TxtFeeAdjustmentAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFeeAdjustmentAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFeeAdjustmentAc.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFeeAdjustmentAc.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFeeAdjustmentAc.Location = New System.Drawing.Point(255, 66)
        Me.TxtFeeAdjustmentAc.MaxLength = 10
        Me.TxtFeeAdjustmentAc.Name = "TxtFeeAdjustmentAc"
        Me.TxtFeeAdjustmentAc.Size = New System.Drawing.Size(341, 18)
        Me.TxtFeeAdjustmentAc.TabIndex = 2
        '
        'LblFeeAdjustmentAc
        '
        Me.LblFeeAdjustmentAc.AutoSize = True
        Me.LblFeeAdjustmentAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFeeAdjustmentAc.Location = New System.Drawing.Point(62, 70)
        Me.LblFeeAdjustmentAc.Name = "LblFeeAdjustmentAc"
        Me.LblFeeAdjustmentAc.Size = New System.Drawing.Size(149, 13)
        Me.LblFeeAdjustmentAc.TabIndex = 26
        Me.LblFeeAdjustmentAc.Text = "Reg. Fee Adjustment A/c"
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
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(216, 61)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 510
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'TxtIsAutoAcManualCode
        '
        Me.TxtIsAutoAcManualCode.AgAllowUserToEnableMasterHelp = False
        Me.TxtIsAutoAcManualCode.AgMandatory = True
        Me.TxtIsAutoAcManualCode.AgMasterHelp = False
        Me.TxtIsAutoAcManualCode.AgNumberLeftPlaces = 0
        Me.TxtIsAutoAcManualCode.AgNumberNegetiveAllow = False
        Me.TxtIsAutoAcManualCode.AgNumberRightPlaces = 0
        Me.TxtIsAutoAcManualCode.AgPickFromLastValue = False
        Me.TxtIsAutoAcManualCode.AgRowFilter = ""
        Me.TxtIsAutoAcManualCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsAutoAcManualCode.AgSelectedValue = Nothing
        Me.TxtIsAutoAcManualCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsAutoAcManualCode.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsAutoAcManualCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIsAutoAcManualCode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsAutoAcManualCode.Location = New System.Drawing.Point(541, 146)
        Me.TxtIsAutoAcManualCode.MaxLength = 10
        Me.TxtIsAutoAcManualCode.Name = "TxtIsAutoAcManualCode"
        Me.TxtIsAutoAcManualCode.Size = New System.Drawing.Size(55, 18)
        Me.TxtIsAutoAcManualCode.TabIndex = 749
        '
        'LblIsAutoAcManualCode
        '
        Me.LblIsAutoAcManualCode.AutoSize = True
        Me.LblIsAutoAcManualCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsAutoAcManualCode.Location = New System.Drawing.Point(378, 150)
        Me.LblIsAutoAcManualCode.Name = "LblIsAutoAcManualCode"
        Me.LblIsAutoAcManualCode.Size = New System.Drawing.Size(159, 13)
        Me.LblIsAutoAcManualCode.TabIndex = 750
        Me.LblIsAutoAcManualCode.Text = "Auto Student Manual Code"
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
    Friend WithEvents TxtDiscountAc As AgControls.AgTextBox
    Friend WithEvents LblDiscountAc As System.Windows.Forms.Label
    Friend WithEvents TxtFeeAdjustmentAc As AgControls.AgTextBox
    Friend WithEvents LblFeeAdjustmentAc As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TxtAcGroup_Student As AgControls.AgTextBox
    Friend WithEvents LblAcGroup_Student As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtFeeReceiptAdjustmentAc As AgControls.AgTextBox
    Friend WithEvents LblFeeReceiptAdjustmentAc As System.Windows.Forms.Label
    Friend WithEvents TxtScholarshipAdjustmentAc As AgControls.AgTextBox
    Friend WithEvents LblScholarshipAdjustmentAc As System.Windows.Forms.Label
    Friend WithEvents TxtCounselingFeeAdjustmentAc As AgControls.AgTextBox
    Friend WithEvents LblCounselingFeeAdjustmentAc As System.Windows.Forms.Label
    Friend WithEvents TxtLockBackDays As AgControls.AgTextBox
    Friend WithEvents LblLockBackDays As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtServer As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtDatabase As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtPassward As AgControls.AgTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtUserID As AgControls.AgTextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents TxtIsAutoAcManualCode As AgControls.AgTextBox
    Friend WithEvents LblIsAutoAcManualCode As System.Windows.Forms.Label
End Class
