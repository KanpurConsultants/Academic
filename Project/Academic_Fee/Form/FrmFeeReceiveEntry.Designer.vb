<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFeeReceiveEntry
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
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.TxtDocId = New AgControls.AgTextBox
        Me.LblV_No = New System.Windows.Forms.Label
        Me.TxtV_No = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.LblV_TypeReq = New System.Windows.Forms.Label
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.LblV_Type = New System.Windows.Forms.Label
        Me.TxtV_Type = New AgControls.AgTextBox
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblDocId = New System.Windows.Forms.Label
        Me.TxtAdmissionDocId = New AgControls.AgTextBox
        Me.LblAdmissionDocId = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtAdmissionID = New AgControls.AgTextBox
        Me.LblAdmissionID = New System.Windows.Forms.Label
        Me.TxtReceiveAmount = New AgControls.AgTextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.PnlFooter2 = New System.Windows.Forms.Panel
        Me.PnlFooter1 = New System.Windows.Forms.Panel
        Me.BtnFillFee = New System.Windows.Forms.Button
        Me.LblIsManageFeeReq = New System.Windows.Forms.Label
        Me.LblIsManageFee = New System.Windows.Forms.Label
        Me.TxtIsManageFee = New AgControls.AgTextBox
        Me.LblIsAdjustableReceiptReq = New System.Windows.Forms.Label
        Me.LblIsAdjustableReceipt = New System.Windows.Forms.Label
        Me.TxtIsAdjustableReceipt = New AgControls.AgTextBox
        Me.Tp3 = New System.Windows.Forms.TabPage
        Me.Pnl4 = New System.Windows.Forms.Panel
        Me.Tp1 = New System.Windows.Forms.TabPage
        Me.BtnFillAdvanceVoucher = New System.Windows.Forms.Button
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.Tc1 = New System.Windows.Forms.TabControl
        Me.TxtOpeningAdvance = New AgControls.AgTextBox
        Me.LblOpeningAdvance = New System.Windows.Forms.Label
        Me.LblInstallment = New System.Windows.Forms.LinkLabel
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Tp3.SuspendLayout()
        Me.Tp1.SuspendLayout()
        Me.Tc1.SuspendLayout()
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
        Me.Topctrl1.Size = New System.Drawing.Size(934, 41)
        Me.Topctrl1.TabIndex = 15
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
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(314, 135)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(56, 13)
        Me.LblPrefix.TabIndex = 395
        Me.LblPrefix.Text = "LblPrefix"
        '
        'TxtDocId
        '
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
        Me.TxtDocId.Location = New System.Drawing.Point(156, 65)
        Me.TxtDocId.MaxLength = 21
        Me.TxtDocId.Name = "TxtDocId"
        Me.TxtDocId.ReadOnly = True
        Me.TxtDocId.Size = New System.Drawing.Size(300, 21)
        Me.TxtDocId.TabIndex = 0
        Me.TxtDocId.TabStop = False
        Me.TxtDocId.Text = "TxtDocId"
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(269, 135)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(47, 13)
        Me.LblV_No.TabIndex = 400
        Me.LblV_No.Text = "Vr. No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgMandatory = True
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
        Me.TxtV_No.Location = New System.Drawing.Point(356, 131)
        Me.TxtV_No.Name = "TxtV_No"
        Me.TxtV_No.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_No.TabIndex = 4
        Me.TxtV_No.Text = "TxtV_No"
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(143, 73)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 403
        Me.Label5.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(143, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 402
        Me.Label2.Text = "Ä"
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(12, 136)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(85, 13)
        Me.LblV_Date.TabIndex = 398
        Me.LblV_Date.Text = "Voucher Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.AutoSize = True
        Me.LblV_TypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblV_TypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblV_TypeReq.Location = New System.Drawing.Point(143, 117)
        Me.LblV_TypeReq.Name = "LblV_TypeReq"
        Me.LblV_TypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblV_TypeReq.TabIndex = 401
        Me.LblV_TypeReq.Text = "Ä"
        '
        'TxtV_Date
        '
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
        Me.TxtV_Date.Location = New System.Drawing.Point(156, 131)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_Date.TabIndex = 3
        Me.TxtV_Date.Text = "TxtV_Date"
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(12, 114)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(86, 13)
        Me.LblV_Type.TabIndex = 397
        Me.LblV_Type.Text = "Voucher Type"
        '
        'TxtV_Type
        '
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
        Me.TxtV_Type.Location = New System.Drawing.Point(156, 109)
        Me.TxtV_Type.MaxLength = 5
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(300, 21)
        Me.TxtV_Type.TabIndex = 2
        Me.TxtV_Type.Text = "TxtV_Type"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(143, 95)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 396
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(12, 92)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 399
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
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(156, 87)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(300, 21)
        Me.TxtSite_Code.TabIndex = 1
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblDocId
        '
        Me.LblDocId.AutoSize = True
        Me.LblDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocId.Location = New System.Drawing.Point(12, 70)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(41, 13)
        Me.LblDocId.TabIndex = 394
        Me.LblDocId.Text = "DocId"
        '
        'TxtAdmissionDocId
        '
        Me.TxtAdmissionDocId.AgMandatory = False
        Me.TxtAdmissionDocId.AgMasterHelp = False
        Me.TxtAdmissionDocId.AgNumberLeftPlaces = 0
        Me.TxtAdmissionDocId.AgNumberNegetiveAllow = False
        Me.TxtAdmissionDocId.AgNumberRightPlaces = 0
        Me.TxtAdmissionDocId.AgPickFromLastValue = False
        Me.TxtAdmissionDocId.AgRowFilter = ""
        Me.TxtAdmissionDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdmissionDocId.AgSelectedValue = Nothing
        Me.TxtAdmissionDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdmissionDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdmissionDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionDocId.Location = New System.Drawing.Point(156, 153)
        Me.TxtAdmissionDocId.MaxLength = 123
        Me.TxtAdmissionDocId.Name = "TxtAdmissionDocId"
        Me.TxtAdmissionDocId.Size = New System.Drawing.Size(300, 21)
        Me.TxtAdmissionDocId.TabIndex = 5
        '
        'LblAdmissionDocId
        '
        Me.LblAdmissionDocId.AutoSize = True
        Me.LblAdmissionDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmissionDocId.Location = New System.Drawing.Point(12, 158)
        Me.LblAdmissionDocId.Name = "LblAdmissionDocId"
        Me.LblAdmissionDocId.Size = New System.Drawing.Size(51, 13)
        Me.LblAdmissionDocId.TabIndex = 419
        Me.LblAdmissionDocId.Text = "Student"
        '
        'TxtRemark
        '
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
        Me.TxtRemark.Location = New System.Drawing.Point(77, 551)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(239, 21)
        Me.TxtRemark.TabIndex = 14
        Me.TxtRemark.Text = "TxtRemark"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(9, 555)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "&Remark"
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 591)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 503
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
        Me.TxtPrepared.Location = New System.Drawing.Point(14, 21)
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
        Me.GroupBox4.Location = New System.Drawing.Point(744, 591)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 504
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
        Me.TxtModified.Location = New System.Drawing.Point(13, 21)
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
        Me.GroupBox2.Location = New System.Drawing.Point(0, 581)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1012, 4)
        Me.GroupBox2.TabIndex = 502
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(12, 206)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(118, 13)
        Me.Label1.TabIndex = 623
        Me.Label1.Text = "Fee Receive Detail:"
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(12, 227)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(586, 320)
        Me.Pnl1.TabIndex = 622
        '
        'TxtAdmissionID
        '
        Me.TxtAdmissionID.AgMandatory = False
        Me.TxtAdmissionID.AgMasterHelp = False
        Me.TxtAdmissionID.AgNumberLeftPlaces = 0
        Me.TxtAdmissionID.AgNumberNegetiveAllow = False
        Me.TxtAdmissionID.AgNumberRightPlaces = 0
        Me.TxtAdmissionID.AgPickFromLastValue = False
        Me.TxtAdmissionID.AgRowFilter = ""
        Me.TxtAdmissionID.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdmissionID.AgSelectedValue = Nothing
        Me.TxtAdmissionID.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdmissionID.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdmissionID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionID.ForeColor = System.Drawing.Color.Blue
        Me.TxtAdmissionID.Location = New System.Drawing.Point(156, 175)
        Me.TxtAdmissionID.MaxLength = 21
        Me.TxtAdmissionID.Name = "TxtAdmissionID"
        Me.TxtAdmissionID.ReadOnly = True
        Me.TxtAdmissionID.Size = New System.Drawing.Size(300, 21)
        Me.TxtAdmissionID.TabIndex = 6
        Me.TxtAdmissionID.TabStop = False
        Me.TxtAdmissionID.Text = "TxtAdmissionID"
        '
        'LblAdmissionID
        '
        Me.LblAdmissionID.AutoSize = True
        Me.LblAdmissionID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmissionID.ForeColor = System.Drawing.Color.Blue
        Me.LblAdmissionID.Location = New System.Drawing.Point(12, 180)
        Me.LblAdmissionID.Name = "LblAdmissionID"
        Me.LblAdmissionID.Size = New System.Drawing.Size(83, 13)
        Me.LblAdmissionID.TabIndex = 625
        Me.LblAdmissionID.Text = "Admission ID"
        '
        'TxtReceiveAmount
        '
        Me.TxtReceiveAmount.AgMandatory = False
        Me.TxtReceiveAmount.AgMasterHelp = False
        Me.TxtReceiveAmount.AgNumberLeftPlaces = 8
        Me.TxtReceiveAmount.AgNumberNegetiveAllow = False
        Me.TxtReceiveAmount.AgNumberRightPlaces = 2
        Me.TxtReceiveAmount.AgPickFromLastValue = False
        Me.TxtReceiveAmount.AgRowFilter = ""
        Me.TxtReceiveAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtReceiveAmount.AgSelectedValue = Nothing
        Me.TxtReceiveAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtReceiveAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtReceiveAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReceiveAmount.ForeColor = System.Drawing.Color.Blue
        Me.TxtReceiveAmount.Location = New System.Drawing.Point(827, 551)
        Me.TxtReceiveAmount.Name = "TxtReceiveAmount"
        Me.TxtReceiveAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtReceiveAmount.TabIndex = 10
        Me.TxtReceiveAmount.Text = "Receive Amount"
        Me.TxtReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.Color.Blue
        Me.Label39.Location = New System.Drawing.Point(715, 555)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(100, 13)
        Me.Label39.TabIndex = 9
        Me.Label39.Text = "Receive &Amount"
        '
        'PnlFooter2
        '
        Me.PnlFooter2.Location = New System.Drawing.Point(609, 271)
        Me.PnlFooter2.Name = "PnlFooter2"
        Me.PnlFooter2.Size = New System.Drawing.Size(320, 274)
        Me.PnlFooter2.TabIndex = 8
        '
        'PnlFooter1
        '
        Me.PnlFooter1.Location = New System.Drawing.Point(609, 180)
        Me.PnlFooter1.Name = "PnlFooter1"
        Me.PnlFooter1.Size = New System.Drawing.Size(320, 91)
        Me.PnlFooter1.TabIndex = 629
        '
        'BtnFillFee
        '
        Me.BtnFillFee.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillFee.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillFee.Location = New System.Drawing.Point(498, 201)
        Me.BtnFillFee.Name = "BtnFillFee"
        Me.BtnFillFee.Size = New System.Drawing.Size(100, 23)
        Me.BtnFillFee.TabIndex = 7
        Me.BtnFillFee.Text = "Fill &Fee"
        Me.BtnFillFee.UseVisualStyleBackColor = True
        '
        'LblIsManageFeeReq
        '
        Me.LblIsManageFeeReq.AutoSize = True
        Me.LblIsManageFeeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblIsManageFeeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblIsManageFeeReq.Location = New System.Drawing.Point(447, 558)
        Me.LblIsManageFeeReq.Name = "LblIsManageFeeReq"
        Me.LblIsManageFeeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblIsManageFeeReq.TabIndex = 633
        Me.LblIsManageFeeReq.Text = "Ä"
        '
        'LblIsManageFee
        '
        Me.LblIsManageFee.AutoSize = True
        Me.LblIsManageFee.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsManageFee.Location = New System.Drawing.Point(319, 555)
        Me.LblIsManageFee.Name = "LblIsManageFee"
        Me.LblIsManageFee.Size = New System.Drawing.Size(129, 13)
        Me.LblIsManageFee.TabIndex = 11
        Me.LblIsManageFee.Text = "Manage Fee (Yes/No)"
        '
        'TxtIsManageFee
        '
        Me.TxtIsManageFee.AgMandatory = True
        Me.TxtIsManageFee.AgMasterHelp = False
        Me.TxtIsManageFee.AgNumberLeftPlaces = 0
        Me.TxtIsManageFee.AgNumberNegetiveAllow = False
        Me.TxtIsManageFee.AgNumberRightPlaces = 0
        Me.TxtIsManageFee.AgPickFromLastValue = False
        Me.TxtIsManageFee.AgRowFilter = ""
        Me.TxtIsManageFee.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsManageFee.AgSelectedValue = Nothing
        Me.TxtIsManageFee.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsManageFee.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsManageFee.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsManageFee.Location = New System.Drawing.Point(463, 551)
        Me.TxtIsManageFee.Name = "TxtIsManageFee"
        Me.TxtIsManageFee.Size = New System.Drawing.Size(42, 21)
        Me.TxtIsManageFee.TabIndex = 12
        Me.TxtIsManageFee.Text = "TxtIsManageFee"
        '
        'LblIsAdjustableReceiptReq
        '
        Me.LblIsAdjustableReceiptReq.AutoSize = True
        Me.LblIsAdjustableReceiptReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblIsAdjustableReceiptReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblIsAdjustableReceiptReq.Location = New System.Drawing.Point(399, 204)
        Me.LblIsAdjustableReceiptReq.Name = "LblIsAdjustableReceiptReq"
        Me.LblIsAdjustableReceiptReq.Size = New System.Drawing.Size(10, 7)
        Me.LblIsAdjustableReceiptReq.TabIndex = 637
        Me.LblIsAdjustableReceiptReq.Text = "Ä"
        Me.LblIsAdjustableReceiptReq.Visible = False
        '
        'LblIsAdjustableReceipt
        '
        Me.LblIsAdjustableReceipt.AutoSize = True
        Me.LblIsAdjustableReceipt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsAdjustableReceipt.Location = New System.Drawing.Point(268, 201)
        Me.LblIsAdjustableReceipt.Name = "LblIsAdjustableReceipt"
        Me.LblIsAdjustableReceipt.Size = New System.Drawing.Size(134, 13)
        Me.LblIsAdjustableReceipt.TabIndex = 635
        Me.LblIsAdjustableReceipt.Text = "Is Adjustable Receipt?"
        Me.LblIsAdjustableReceipt.Visible = False
        '
        'TxtIsAdjustableReceipt
        '
        Me.TxtIsAdjustableReceipt.AgMandatory = True
        Me.TxtIsAdjustableReceipt.AgMasterHelp = False
        Me.TxtIsAdjustableReceipt.AgNumberLeftPlaces = 0
        Me.TxtIsAdjustableReceipt.AgNumberNegetiveAllow = False
        Me.TxtIsAdjustableReceipt.AgNumberRightPlaces = 0
        Me.TxtIsAdjustableReceipt.AgPickFromLastValue = False
        Me.TxtIsAdjustableReceipt.AgRowFilter = ""
        Me.TxtIsAdjustableReceipt.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsAdjustableReceipt.AgSelectedValue = Nothing
        Me.TxtIsAdjustableReceipt.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsAdjustableReceipt.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsAdjustableReceipt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsAdjustableReceipt.Location = New System.Drawing.Point(415, 197)
        Me.TxtIsAdjustableReceipt.Name = "TxtIsAdjustableReceipt"
        Me.TxtIsAdjustableReceipt.Size = New System.Drawing.Size(42, 21)
        Me.TxtIsAdjustableReceipt.TabIndex = 636
        Me.TxtIsAdjustableReceipt.TabStop = False
        Me.TxtIsAdjustableReceipt.Text = "TxtIsAdjustableReceipt"
        Me.TxtIsAdjustableReceipt.Visible = False
        '
        'Tp3
        '
        Me.Tp3.Controls.Add(Me.Pnl4)
        Me.Tp3.Location = New System.Drawing.Point(4, 22)
        Me.Tp3.Name = "Tp3"
        Me.Tp3.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp3.Size = New System.Drawing.Size(453, 110)
        Me.Tp3.TabIndex = 2
        Me.Tp3.Text = "Define Accounts "
        Me.Tp3.UseVisualStyleBackColor = True
        '
        'Pnl4
        '
        Me.Pnl4.Location = New System.Drawing.Point(10, 4)
        Me.Pnl4.Name = "Pnl4"
        Me.Pnl4.Size = New System.Drawing.Size(431, 102)
        Me.Pnl4.TabIndex = 630
        '
        'Tp1
        '
        Me.Tp1.Controls.Add(Me.BtnFillAdvanceVoucher)
        Me.Tp1.Controls.Add(Me.Pnl2)
        Me.Tp1.Location = New System.Drawing.Point(4, 22)
        Me.Tp1.Name = "Tp1"
        Me.Tp1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp1.Size = New System.Drawing.Size(453, 110)
        Me.Tp1.TabIndex = 1
        Me.Tp1.Text = "Advance Voucher(s) "
        Me.Tp1.UseVisualStyleBackColor = True
        '
        'BtnFillAdvanceVoucher
        '
        Me.BtnFillAdvanceVoucher.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillAdvanceVoucher.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillAdvanceVoucher.Location = New System.Drawing.Point(8, 4)
        Me.BtnFillAdvanceVoucher.Name = "BtnFillAdvanceVoucher"
        Me.BtnFillAdvanceVoucher.Size = New System.Drawing.Size(437, 23)
        Me.BtnFillAdvanceVoucher.TabIndex = 639
        Me.BtnFillAdvanceVoucher.Text = "Fill Advance Voucher(s)"
        Me.BtnFillAdvanceVoucher.UseVisualStyleBackColor = True
        '
        'Pnl2
        '
        Me.Pnl2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl2.Location = New System.Drawing.Point(9, 28)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(436, 79)
        Me.Pnl2.TabIndex = 625
        '
        'Tc1
        '
        Me.Tc1.Controls.Add(Me.Tp1)
        Me.Tc1.Controls.Add(Me.Tp3)
        Me.Tc1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tc1.Location = New System.Drawing.Point(472, 43)
        Me.Tc1.Name = "Tc1"
        Me.Tc1.SelectedIndex = 0
        Me.Tc1.Size = New System.Drawing.Size(461, 136)
        Me.Tc1.TabIndex = 638
        '
        'TxtOpeningAdvance
        '
        Me.TxtOpeningAdvance.AgMandatory = False
        Me.TxtOpeningAdvance.AgMasterHelp = False
        Me.TxtOpeningAdvance.AgNumberLeftPlaces = 8
        Me.TxtOpeningAdvance.AgNumberNegetiveAllow = False
        Me.TxtOpeningAdvance.AgNumberRightPlaces = 2
        Me.TxtOpeningAdvance.AgPickFromLastValue = False
        Me.TxtOpeningAdvance.AgRowFilter = ""
        Me.TxtOpeningAdvance.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOpeningAdvance.AgSelectedValue = Nothing
        Me.TxtOpeningAdvance.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOpeningAdvance.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtOpeningAdvance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOpeningAdvance.ForeColor = System.Drawing.Color.Blue
        Me.TxtOpeningAdvance.Location = New System.Drawing.Point(611, 551)
        Me.TxtOpeningAdvance.Name = "TxtOpeningAdvance"
        Me.TxtOpeningAdvance.Size = New System.Drawing.Size(100, 21)
        Me.TxtOpeningAdvance.TabIndex = 654
        Me.TxtOpeningAdvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblOpeningAdvance
        '
        Me.LblOpeningAdvance.AutoSize = True
        Me.LblOpeningAdvance.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOpeningAdvance.ForeColor = System.Drawing.Color.Blue
        Me.LblOpeningAdvance.Location = New System.Drawing.Point(508, 555)
        Me.LblOpeningAdvance.Name = "LblOpeningAdvance"
        Me.LblOpeningAdvance.Size = New System.Drawing.Size(102, 13)
        Me.LblOpeningAdvance.TabIndex = 655
        Me.LblOpeningAdvance.Text = "&Opening Amount"
        '
        'LblInstallment
        '
        Me.LblInstallment.AutoSize = True
        Me.LblInstallment.BackColor = System.Drawing.Color.SteelBlue
        Me.LblInstallment.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInstallment.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LblInstallment.LinkColor = System.Drawing.Color.White
        Me.LblInstallment.Location = New System.Drawing.Point(458, 182)
        Me.LblInstallment.Name = "LblInstallment"
        Me.LblInstallment.Size = New System.Drawing.Size(143, 16)
        Me.LblInstallment.TabIndex = 936
        Me.LblInstallment.TabStop = True
        Me.LblInstallment.Text = "Installment : #####.##"
        Me.LblInstallment.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.LblInstallment.Visible = False
        '
        'FrmFeeReceiveEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 652)
        Me.Controls.Add(Me.LblInstallment)
        Me.Controls.Add(Me.TxtOpeningAdvance)
        Me.Controls.Add(Me.LblOpeningAdvance)
        Me.Controls.Add(Me.Tc1)
        Me.Controls.Add(Me.LblIsAdjustableReceiptReq)
        Me.Controls.Add(Me.LblIsAdjustableReceipt)
        Me.Controls.Add(Me.TxtIsAdjustableReceipt)
        Me.Controls.Add(Me.LblIsManageFeeReq)
        Me.Controls.Add(Me.LblIsManageFee)
        Me.Controls.Add(Me.TxtIsManageFee)
        Me.Controls.Add(Me.BtnFillFee)
        Me.Controls.Add(Me.PnlFooter1)
        Me.Controls.Add(Me.TxtReceiveAmount)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.PnlFooter2)
        Me.Controls.Add(Me.TxtAdmissionID)
        Me.Controls.Add(Me.LblAdmissionID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtAdmissionDocId)
        Me.Controls.Add(Me.LblAdmissionDocId)
        Me.Controls.Add(Me.TxtDocId)
        Me.Controls.Add(Me.LblV_No)
        Me.Controls.Add(Me.TxtV_No)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.LblV_TypeReq)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.LblV_Type)
        Me.Controls.Add(Me.TxtV_Type)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblDocId)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.LblPrefix)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmFeeReceiveEntry"
        Me.Text = "Fee Receive Entry"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Tp3.ResumeLayout(False)
        Me.Tp1.ResumeLayout(False)
        Me.Tc1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents TxtDocId As AgControls.AgTextBox
    Friend WithEvents LblV_No As System.Windows.Forms.Label
    Friend WithEvents TxtV_No As AgControls.AgTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblV_Date As System.Windows.Forms.Label
    Friend WithEvents LblV_TypeReq As System.Windows.Forms.Label
    Friend WithEvents TxtV_Date As AgControls.AgTextBox
    Friend WithEvents LblV_Type As System.Windows.Forms.Label
    Friend WithEvents TxtV_Type As AgControls.AgTextBox
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblDocId As System.Windows.Forms.Label
    Friend WithEvents TxtAdmissionDocId As AgControls.AgTextBox
    Friend WithEvents LblAdmissionDocId As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtAdmissionID As AgControls.AgTextBox
    Friend WithEvents LblAdmissionID As System.Windows.Forms.Label
    Friend WithEvents TxtReceiveAmount As AgControls.AgTextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents PnlFooter2 As System.Windows.Forms.Panel
    Friend WithEvents PnlFooter1 As System.Windows.Forms.Panel
    Friend WithEvents BtnFillFee As System.Windows.Forms.Button
    Friend WithEvents LblIsManageFeeReq As System.Windows.Forms.Label
    Friend WithEvents LblIsManageFee As System.Windows.Forms.Label
    Friend WithEvents TxtIsManageFee As AgControls.AgTextBox
    Friend WithEvents LblIsAdjustableReceiptReq As System.Windows.Forms.Label
    Friend WithEvents LblIsAdjustableReceipt As System.Windows.Forms.Label
    Friend WithEvents TxtIsAdjustableReceipt As AgControls.AgTextBox
    Friend WithEvents Tp3 As System.Windows.Forms.TabPage
    Friend WithEvents Pnl4 As System.Windows.Forms.Panel
    Friend WithEvents Tp1 As System.Windows.Forms.TabPage
    Friend WithEvents BtnFillAdvanceVoucher As System.Windows.Forms.Button
    Friend WithEvents Pnl2 As System.Windows.Forms.Panel
    Friend WithEvents Tc1 As System.Windows.Forms.TabControl
    Friend WithEvents TxtOpeningAdvance As AgControls.AgTextBox
    Friend WithEvents LblOpeningAdvance As System.Windows.Forms.Label
    Friend WithEvents LblInstallment As System.Windows.Forms.LinkLabel
End Class
