<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmissueReceive
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
        Me.LblIssueReceiveDetail = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtDocId = New AgControls.AgTextBox
        Me.LblDocId = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.TxtV_No = New AgControls.AgTextBox
        Me.LblV_No = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.TxtV_Type = New AgControls.AgTextBox
        Me.LblV_Type = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.TxtAmount = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblAcCodeReq = New System.Windows.Forms.Label
        Me.TxtAcCode = New AgControls.AgTextBox
        Me.LblAcCode = New System.Windows.Forms.Label
        Me.TxtDepartment = New AgControls.AgTextBox
        Me.LblDepartment = New System.Windows.Forms.Label
        Me.TxtDepartment2 = New AgControls.AgTextBox
        Me.LblDepartment2 = New System.Windows.Forms.Label
        Me.LblRefNo = New System.Windows.Forms.Label
        Me.TxtRefNo = New AgControls.AgTextBox
        Me.Label66 = New System.Windows.Forms.Label
        Me.TxtToGodown = New AgControls.AgTextBox
        Me.lblToGodown = New System.Windows.Forms.Label
        Me.TxtFrmGodown = New AgControls.AgTextBox
        Me.lblFromGodown = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblIssueReceiveDetail
        '
        Me.LblIssueReceiveDetail.AutoSize = True
        Me.LblIssueReceiveDetail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIssueReceiveDetail.ForeColor = System.Drawing.Color.Blue
        Me.LblIssueReceiveDetail.Location = New System.Drawing.Point(37, 220)
        Me.LblIssueReceiveDetail.Name = "LblIssueReceiveDetail"
        Me.LblIssueReceiveDetail.Size = New System.Drawing.Size(129, 13)
        Me.LblIssueReceiveDetail.TabIndex = 279
        Me.LblIssueReceiveDetail.Text = "Issue Receive Detail:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(177, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 278
        Me.Label5.Text = "Ä"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(177, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 277
        Me.Label4.Text = "Ä"
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
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(744, 559)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 268
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
        Me.GrpUP.Location = New System.Drawing.Point(12, 559)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 267
        Me.GrpUP.TabStop = False
        Me.GrpUP.Tag = "TR"
        Me.GrpUP.Text = "Prepared By "
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
        Me.Topctrl1.TabIndex = 13
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
        Me.TxtDocId.Location = New System.Drawing.Point(190, 58)
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
        Me.LblDocId.Location = New System.Drawing.Point(46, 62)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(83, 13)
        Me.LblDocId.TabIndex = 243
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(190, 80)
        Me.TxtSite_Code.MaxLength = 25
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 21)
        Me.TxtSite_Code.TabIndex = 1
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(46, 84)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(111, 13)
        Me.LblSite_Code.TabIndex = 244
        Me.LblSite_Code.Text = "Site/Branch Name"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(177, 87)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 249
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
        Me.TxtV_Date.Location = New System.Drawing.Point(190, 124)
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
        Me.TxtV_No.Location = New System.Drawing.Point(415, 124)
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
        Me.LblV_No.Location = New System.Drawing.Point(297, 128)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(77, 13)
        Me.LblV_No.TabIndex = 239
        Me.LblV_No.Text = "Voucher No."
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(-1, 549)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(947, 4)
        Me.GroupBox2.TabIndex = 269
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(46, 128)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(85, 13)
        Me.LblV_Date.TabIndex = 240
        Me.LblV_Date.Text = "Voucher Date"
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
        Me.TxtV_Type.Location = New System.Drawing.Point(190, 102)
        Me.TxtV_Type.MaxLength = 25
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(325, 21)
        Me.TxtV_Type.TabIndex = 2
        Me.TxtV_Type.Text = "TxtV_Type"
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(46, 106)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(56, 13)
        Me.LblV_Type.TabIndex = 246
        Me.LblV_Type.Text = "Vr. Type"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(40, 239)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(890, 240)
        Me.Pnl1.TabIndex = 11
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(378, 128)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(56, 13)
        Me.LblPrefix.TabIndex = 276
        Me.LblPrefix.Text = "LblPrefix"
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
        Me.TxtAmount.ForeColor = System.Drawing.Color.Blue
        Me.TxtAmount.Location = New System.Drawing.Point(790, 500)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.ReadOnly = True
        Me.TxtAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtAmount.TabIndex = 280
        Me.TxtAmount.TabStop = False
        Me.TxtAmount.Text = "AgTextBox1"
        Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(683, 504)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 281
        Me.Label2.Text = "Total Amount"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 504)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 9
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
        Me.TxtRemark.Location = New System.Drawing.Point(82, 500)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(325, 21)
        Me.TxtRemark.TabIndex = 12
        Me.TxtRemark.Text = "TxtRemark"
        '
        'LblAcCodeReq
        '
        Me.LblAcCodeReq.AutoSize = True
        Me.LblAcCodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAcCodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAcCodeReq.Location = New System.Drawing.Point(662, 65)
        Me.LblAcCodeReq.Name = "LblAcCodeReq"
        Me.LblAcCodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAcCodeReq.TabIndex = 284
        Me.LblAcCodeReq.Text = "Ä"
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
        Me.TxtAcCode.Location = New System.Drawing.Point(680, 58)
        Me.TxtAcCode.MaxLength = 10
        Me.TxtAcCode.Name = "TxtAcCode"
        Me.TxtAcCode.Size = New System.Drawing.Size(242, 21)
        Me.TxtAcCode.TabIndex = 8
        Me.TxtAcCode.Text = "TxtAcCode"
        '
        'LblAcCode
        '
        Me.LblAcCode.AutoSize = True
        Me.LblAcCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcCode.Location = New System.Drawing.Point(545, 62)
        Me.LblAcCode.Name = "LblAcCode"
        Me.LblAcCode.Size = New System.Drawing.Size(74, 13)
        Me.LblAcCode.TabIndex = 282
        Me.LblAcCode.Text = "Party Name"
        '
        'TxtDepartment
        '
        Me.TxtDepartment.AgAllowUserToEnableMasterHelp = False
        Me.TxtDepartment.AgMandatory = False
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
        Me.TxtDepartment.Location = New System.Drawing.Point(190, 168)
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
        Me.LblDepartment.Location = New System.Drawing.Point(46, 172)
        Me.LblDepartment.Name = "LblDepartment"
        Me.LblDepartment.Size = New System.Drawing.Size(83, 13)
        Me.LblDepartment.TabIndex = 286
        Me.LblDepartment.Text = "Departmen-1"
        '
        'TxtDepartment2
        '
        Me.TxtDepartment2.AgAllowUserToEnableMasterHelp = False
        Me.TxtDepartment2.AgMandatory = False
        Me.TxtDepartment2.AgMasterHelp = False
        Me.TxtDepartment2.AgNumberLeftPlaces = 0
        Me.TxtDepartment2.AgNumberNegetiveAllow = False
        Me.TxtDepartment2.AgNumberRightPlaces = 0
        Me.TxtDepartment2.AgPickFromLastValue = False
        Me.TxtDepartment2.AgRowFilter = ""
        Me.TxtDepartment2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDepartment2.AgSelectedValue = Nothing
        Me.TxtDepartment2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDepartment2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDepartment2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDepartment2.Location = New System.Drawing.Point(190, 190)
        Me.TxtDepartment2.MaxLength = 10
        Me.TxtDepartment2.Name = "TxtDepartment2"
        Me.TxtDepartment2.Size = New System.Drawing.Size(325, 21)
        Me.TxtDepartment2.TabIndex = 7
        Me.TxtDepartment2.Text = "AgTextBox1"
        '
        'LblDepartment2
        '
        Me.LblDepartment2.AutoSize = True
        Me.LblDepartment2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDepartment2.Location = New System.Drawing.Point(46, 194)
        Me.LblDepartment2.Name = "LblDepartment2"
        Me.LblDepartment2.Size = New System.Drawing.Size(87, 13)
        Me.LblDepartment2.TabIndex = 289
        Me.LblDepartment2.Text = "Department-2"
        '
        'LblRefNo
        '
        Me.LblRefNo.AutoSize = True
        Me.LblRefNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRefNo.Location = New System.Drawing.Point(46, 150)
        Me.LblRefNo.Name = "LblRefNo"
        Me.LblRefNo.Size = New System.Drawing.Size(88, 13)
        Me.LblRefNo.TabIndex = 716
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
        Me.TxtRefNo.Location = New System.Drawing.Point(190, 146)
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
        Me.Label66.Location = New System.Drawing.Point(177, 153)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(10, 7)
        Me.Label66.TabIndex = 717
        Me.Label66.Text = "Ä"
        '
        'TxtToGodown
        '
        Me.TxtToGodown.AgAllowUserToEnableMasterHelp = False
        Me.TxtToGodown.AgMandatory = False
        Me.TxtToGodown.AgMasterHelp = False
        Me.TxtToGodown.AgNumberLeftPlaces = 0
        Me.TxtToGodown.AgNumberNegetiveAllow = False
        Me.TxtToGodown.AgNumberRightPlaces = 0
        Me.TxtToGodown.AgPickFromLastValue = False
        Me.TxtToGodown.AgRowFilter = ""
        Me.TxtToGodown.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtToGodown.AgSelectedValue = Nothing
        Me.TxtToGodown.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtToGodown.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtToGodown.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToGodown.Location = New System.Drawing.Point(680, 102)
        Me.TxtToGodown.MaxLength = 10
        Me.TxtToGodown.Name = "TxtToGodown"
        Me.TxtToGodown.Size = New System.Drawing.Size(242, 21)
        Me.TxtToGodown.TabIndex = 10
        Me.TxtToGodown.Text = "AgTextBox1"
        '
        'lblToGodown
        '
        Me.lblToGodown.AutoSize = True
        Me.lblToGodown.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToGodown.Location = New System.Drawing.Point(545, 106)
        Me.lblToGodown.Name = "lblToGodown"
        Me.lblToGodown.Size = New System.Drawing.Size(71, 13)
        Me.lblToGodown.TabIndex = 722
        Me.lblToGodown.Text = "To Godown"
        '
        'TxtFrmGodown
        '
        Me.TxtFrmGodown.AgAllowUserToEnableMasterHelp = False
        Me.TxtFrmGodown.AgMandatory = False
        Me.TxtFrmGodown.AgMasterHelp = False
        Me.TxtFrmGodown.AgNumberLeftPlaces = 0
        Me.TxtFrmGodown.AgNumberNegetiveAllow = False
        Me.TxtFrmGodown.AgNumberRightPlaces = 0
        Me.TxtFrmGodown.AgPickFromLastValue = False
        Me.TxtFrmGodown.AgRowFilter = ""
        Me.TxtFrmGodown.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFrmGodown.AgSelectedValue = Nothing
        Me.TxtFrmGodown.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFrmGodown.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFrmGodown.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFrmGodown.Location = New System.Drawing.Point(680, 80)
        Me.TxtFrmGodown.MaxLength = 10
        Me.TxtFrmGodown.Name = "TxtFrmGodown"
        Me.TxtFrmGodown.Size = New System.Drawing.Size(242, 21)
        Me.TxtFrmGodown.TabIndex = 9
        Me.TxtFrmGodown.Text = "AgTextBox1"
        '
        'lblFromGodown
        '
        Me.lblFromGodown.AutoSize = True
        Me.lblFromGodown.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFromGodown.Location = New System.Drawing.Point(545, 84)
        Me.lblFromGodown.Name = "lblFromGodown"
        Me.lblFromGodown.Size = New System.Drawing.Size(86, 13)
        Me.lblFromGodown.TabIndex = 720
        Me.lblFromGodown.Text = "From Godown"
        '
        'FrmissueReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 616)
        Me.Controls.Add(Me.TxtToGodown)
        Me.Controls.Add(Me.lblToGodown)
        Me.Controls.Add(Me.TxtFrmGodown)
        Me.Controls.Add(Me.lblFromGodown)
        Me.Controls.Add(Me.LblRefNo)
        Me.Controls.Add(Me.TxtRefNo)
        Me.Controls.Add(Me.Label66)
        Me.Controls.Add(Me.TxtDepartment2)
        Me.Controls.Add(Me.LblDepartment2)
        Me.Controls.Add(Me.TxtDepartment)
        Me.Controls.Add(Me.LblDepartment)
        Me.Controls.Add(Me.LblAcCodeReq)
        Me.Controls.Add(Me.TxtAcCode)
        Me.Controls.Add(Me.LblAcCode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.TxtAmount)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblIssueReceiveDetail)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtDocId)
        Me.Controls.Add(Me.LblDocId)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.TxtV_No)
        Me.Controls.Add(Me.LblV_No)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.TxtV_Type)
        Me.Controls.Add(Me.LblV_Type)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LblPrefix)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmissueReceive"
        Me.Text = "Issue Receive Entry"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblIssueReceiveDetail As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtDocId As AgControls.AgTextBox
    Friend WithEvents LblDocId As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents TxtV_Date As AgControls.AgTextBox
    Friend WithEvents TxtV_No As AgControls.AgTextBox
    Friend WithEvents LblV_No As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblV_Date As System.Windows.Forms.Label
    Friend WithEvents TxtV_Type As AgControls.AgTextBox
    Friend WithEvents LblV_Type As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents TxtAmount As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents LblAcCodeReq As System.Windows.Forms.Label
    Friend WithEvents TxtAcCode As AgControls.AgTextBox
    Friend WithEvents LblAcCode As System.Windows.Forms.Label
    Friend WithEvents TxtDepartment As AgControls.AgTextBox
    Friend WithEvents LblDepartment As System.Windows.Forms.Label
    Friend WithEvents TxtDepartment2 As AgControls.AgTextBox
    Friend WithEvents LblDepartment2 As System.Windows.Forms.Label
    Friend WithEvents LblRefNo As System.Windows.Forms.Label
    Friend WithEvents TxtRefNo As AgControls.AgTextBox
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents TxtToGodown As AgControls.AgTextBox
    Friend WithEvents lblToGodown As System.Windows.Forms.Label
    Friend WithEvents TxtFrmGodown As AgControls.AgTextBox
    Friend WithEvents lblFromGodown As System.Windows.Forms.Label
End Class
