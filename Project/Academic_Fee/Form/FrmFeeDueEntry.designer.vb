<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFeeDueEntry
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
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtAmount = New AgControls.AgTextBox
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.LblV_No = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.TxtV_No = New AgControls.AgTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtDocId = New AgControls.AgTextBox
        Me.LblDocId = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.TxtV_Type = New AgControls.AgTextBox
        Me.LblV_Type = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(355, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 7)
        Me.Label10.TabIndex = 403
        Me.Label10.Text = "�"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(686, 456)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 398
        Me.Label1.Text = "Amount"
        '
        'TxtAmount
        '
        Me.TxtAmount.AgMandatory = True
        Me.TxtAmount.AgMasterHelp = False
        Me.TxtAmount.AgNumberLeftPlaces = 8
        Me.TxtAmount.AgNumberNegetiveAllow = False
        Me.TxtAmount.AgNumberRightPlaces = 0
        Me.TxtAmount.AgPickFromLastValue = False
        Me.TxtAmount.AgRowFilter = ""
        Me.TxtAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAmount.AgSelectedValue = Nothing
        Me.TxtAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmount.Location = New System.Drawing.Point(760, 452)
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtAmount.TabIndex = 7
        Me.TxtAmount.Text = "TxtAmount"
        Me.TxtAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(12, 174)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(848, 272)
        Me.Pnl1.TabIndex = 6
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(559, 129)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(48, 13)
        Me.LblPrefix.TabIndex = 391
        Me.LblPrefix.Text = "LblPrefix"
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(478, 129)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(73, 13)
        Me.LblV_No.TabIndex = 381
        Me.LblV_No.Text = "Voucher No"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(208, 85)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 384
        Me.LblSite_Code.Text = "Site/Branch"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(355, 88)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 387
        Me.LblSite_CodeReq.Text = "�"
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
        Me.TxtV_Date.Location = New System.Drawing.Point(373, 125)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_Date.TabIndex = 3
        Me.TxtV_Date.Text = "TxtV_Date"
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
        Me.TxtV_No.Location = New System.Drawing.Point(598, 125)
        Me.TxtV_No.Name = "TxtV_No"
        Me.TxtV_No.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_No.TabIndex = 4
        Me.TxtV_No.Text = "TxtV_No"
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(355, 66)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 7)
        Me.Label13.TabIndex = 396
        Me.Label13.Text = "�"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(9, 456)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 393
        Me.Label7.Text = "Remark"
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
        Me.TxtRemark.Location = New System.Drawing.Point(68, 452)
        Me.TxtRemark.MaxLength = 150
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(325, 21)
        Me.TxtRemark.TabIndex = 8
        Me.TxtRemark.Text = "TxtRemark"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(355, 132)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 392
        Me.Label5.Text = "�"
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(674, 503)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 389
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
        Me.GrpUP.Location = New System.Drawing.Point(12, 503)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 388
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
        Me.Topctrl1.TabIndex = 385
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
        Me.TxtDocId.Location = New System.Drawing.Point(373, 59)
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
        Me.LblDocId.Location = New System.Drawing.Point(208, 63)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(83, 13)
        Me.LblDocId.TabIndex = 383
        Me.LblDocId.Text = "Document ID"
        '
        'TxtSite_Code
        '
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(373, 81)
        Me.TxtSite_Code.MaxLength = 25
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 21)
        Me.TxtSite_Code.TabIndex = 1
        Me.TxtSite_Code.Text = "TxtFromSite_Code"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(2, 493)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 4)
        Me.GroupBox2.TabIndex = 390
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(208, 129)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(85, 13)
        Me.LblV_Date.TabIndex = 382
        Me.LblV_Date.Text = "Voucher Date"
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
        Me.TxtV_Type.Location = New System.Drawing.Point(373, 103)
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
        Me.LblV_Type.Location = New System.Drawing.Point(208, 107)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(56, 13)
        Me.LblV_Type.TabIndex = 386
        Me.LblV_Type.Text = "Vr. Type"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(757, 138)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(100, 28)
        Me.BtnFill.TabIndex = 404
        Me.BtnFill.Text = "Fill"
        Me.BtnFill.UseVisualStyleBackColor = True
        Me.BtnFill.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(355, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 407
        Me.Label2.Text = "�"
        '
        'TxtStreamYearSemester
        '
        Me.TxtStreamYearSemester.AgMandatory = True
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
        Me.TxtStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(373, 147)
        Me.TxtStreamYearSemester.MaxLength = 25
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(325, 21)
        Me.TxtStreamYearSemester.TabIndex = 5
        Me.TxtStreamYearSemester.Text = "AgTextBox1"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(208, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(138, 13)
        Me.Label3.TabIndex = 406
        Me.Label3.Text = "Stream Year Semester"
        '
        'FrmFeeDueEntry
        '
        Me.ClientSize = New System.Drawing.Size(872, 566)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtStreamYearSemester)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtAmount)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LblV_No)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.TxtV_No)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtDocId)
        Me.Controls.Add(Me.LblDocId)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.TxtV_Type)
        Me.Controls.Add(Me.LblV_Type)
        Me.Controls.Add(Me.LblPrefix)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmFeeDueEntry"
        Me.Text = "Fee Due Entry"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtAmount As AgControls.AgTextBox
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents LblV_No As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents TxtV_Date As AgControls.AgTextBox
    Friend WithEvents TxtV_No As AgControls.AgTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtDocId As AgControls.AgTextBox
    Friend WithEvents LblDocId As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents LblV_Date As System.Windows.Forms.Label
    Friend WithEvents TxtV_Type As AgControls.AgTextBox
    Friend WithEvents LblV_Type As System.Windows.Forms.Label
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class