<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmScholarshipReceive
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmScholarshipReceive))
        Me.TxtDemandDocId = New AgControls.AgTextBox
        Me.LblDemandDocId = New System.Windows.Forms.Label
        Me.LblV_No = New System.Windows.Forms.Label
        Me.TxtV_No = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.LblV_TypeReq = New System.Windows.Forms.Label
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.LblV_Type = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblDocId = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.LblDemandDocIdReq = New System.Windows.Forms.Label
        Me.LblReceiveDetail = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtTotalReceiveAmount = New AgControls.AgTextBox
        Me.LblTotalReceiveAmt = New System.Windows.Forms.Label
        Me.TxtV_Type = New AgControls.AgTextBox
        Me.TxtDocId = New AgControls.AgTextBox
        Me.BtnFillStudents = New System.Windows.Forms.Button
        Me.TxtReceiveAmount = New AgControls.AgTextBox
        Me.LblReceiveAmt = New System.Windows.Forms.Label
        Me.LblReceiveAmtReq = New System.Windows.Forms.Label
        Me.LblScholarshipAcReq = New System.Windows.Forms.Label
        Me.TxtScholarshipAc = New AgControls.AgTextBox
        Me.LblScholarshipAc = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnApproved = New System.Windows.Forms.Button
        Me.TxtApproved = New System.Windows.Forms.TextBox
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtDemandDocId
        '
        Me.TxtDemandDocId.AgMandatory = False
        Me.TxtDemandDocId.AgMasterHelp = False
        Me.TxtDemandDocId.AgNumberLeftPlaces = 0
        Me.TxtDemandDocId.AgNumberNegetiveAllow = False
        Me.TxtDemandDocId.AgNumberRightPlaces = 0
        Me.TxtDemandDocId.AgPickFromLastValue = False
        Me.TxtDemandDocId.AgRowFilter = ""
        Me.TxtDemandDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDemandDocId.AgSelectedValue = Nothing
        Me.TxtDemandDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDemandDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDemandDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDemandDocId.Location = New System.Drawing.Point(573, 62)
        Me.TxtDemandDocId.MaxLength = 123
        Me.TxtDemandDocId.Name = "TxtDemandDocId"
        Me.TxtDemandDocId.Size = New System.Drawing.Size(300, 21)
        Me.TxtDemandDocId.TabIndex = 5
        '
        'LblDemandDocId
        '
        Me.LblDemandDocId.AutoSize = True
        Me.LblDemandDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDemandDocId.Location = New System.Drawing.Point(446, 66)
        Me.LblDemandDocId.Name = "LblDemandDocId"
        Me.LblDemandDocId.Size = New System.Drawing.Size(78, 13)
        Me.LblDemandDocId.TabIndex = 644
        Me.LblDemandDocId.Text = "Demand No."
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(236, 132)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(47, 13)
        Me.LblV_No.TabIndex = 640
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
        Me.TxtV_No.Location = New System.Drawing.Point(329, 128)
        Me.TxtV_No.Name = "TxtV_No"
        Me.TxtV_No.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_No.TabIndex = 4
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(113, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 642
        Me.Label2.Text = "Ä"
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(10, 133)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(85, 13)
        Me.LblV_Date.TabIndex = 638
        Me.LblV_Date.Text = "Voucher Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.AutoSize = True
        Me.LblV_TypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblV_TypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblV_TypeReq.Location = New System.Drawing.Point(113, 114)
        Me.LblV_TypeReq.Name = "LblV_TypeReq"
        Me.LblV_TypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblV_TypeReq.TabIndex = 641
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
        Me.TxtV_Date.Location = New System.Drawing.Point(129, 128)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_Date.TabIndex = 3
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(10, 111)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(86, 13)
        Me.LblV_Type.TabIndex = 637
        Me.LblV_Type.Text = "Voucher Type"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(113, 92)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 636
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(10, 89)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 639
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(129, 84)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(300, 21)
        Me.TxtSite_Code.TabIndex = 1
        Me.TxtSite_Code.TabStop = False
        '
        'LblDocId
        '
        Me.LblDocId.AutoSize = True
        Me.LblDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocId.Location = New System.Drawing.Point(10, 67)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(41, 13)
        Me.LblDocId.TabIndex = 634
        Me.LblDocId.Text = "DocId"
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
        Me.Topctrl1.Size = New System.Drawing.Size(884, 41)
        Me.Topctrl1.TabIndex = 11
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
        Me.LblPrefix.Location = New System.Drawing.Point(284, 132)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(56, 13)
        Me.LblPrefix.TabIndex = 635
        Me.LblPrefix.Text = "LblPrefix"
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
        Me.GrpUP.TabIndex = 647
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
        Me.GroupBox4.Location = New System.Drawing.Point(381, 556)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 648
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
        Me.GroupBox2.Location = New System.Drawing.Point(0, 546)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(892, 4)
        Me.GroupBox2.TabIndex = 646
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
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
        Me.TxtRemark.Location = New System.Drawing.Point(129, 518)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 21)
        Me.TxtRemark.TabIndex = 10
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(10, 521)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(52, 13)
        Me.LblRemark.TabIndex = 649
        Me.LblRemark.Text = "&Remark"
        '
        'LblDemandDocIdReq
        '
        Me.LblDemandDocIdReq.AutoSize = True
        Me.LblDemandDocIdReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblDemandDocIdReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblDemandDocIdReq.Location = New System.Drawing.Point(557, 69)
        Me.LblDemandDocIdReq.Name = "LblDemandDocIdReq"
        Me.LblDemandDocIdReq.Size = New System.Drawing.Size(10, 7)
        Me.LblDemandDocIdReq.TabIndex = 654
        Me.LblDemandDocIdReq.Text = "Ä"
        '
        'LblReceiveDetail
        '
        Me.LblReceiveDetail.AutoSize = True
        Me.LblReceiveDetail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReceiveDetail.ForeColor = System.Drawing.Color.Blue
        Me.LblReceiveDetail.Location = New System.Drawing.Point(12, 163)
        Me.LblReceiveDetail.Name = "LblReceiveDetail"
        Me.LblReceiveDetail.Size = New System.Drawing.Size(94, 13)
        Me.LblReceiveDetail.TabIndex = 656
        Me.LblReceiveDetail.Text = "Receive Detail:"
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(13, 179)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(859, 333)
        Me.Pnl1.TabIndex = 9
        '
        'TxtTotalReceiveAmount
        '
        Me.TxtTotalReceiveAmount.AgMandatory = False
        Me.TxtTotalReceiveAmount.AgMasterHelp = False
        Me.TxtTotalReceiveAmount.AgNumberLeftPlaces = 8
        Me.TxtTotalReceiveAmount.AgNumberNegetiveAllow = False
        Me.TxtTotalReceiveAmount.AgNumberRightPlaces = 2
        Me.TxtTotalReceiveAmount.AgPickFromLastValue = False
        Me.TxtTotalReceiveAmount.AgRowFilter = ""
        Me.TxtTotalReceiveAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalReceiveAmount.AgSelectedValue = Nothing
        Me.TxtTotalReceiveAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalReceiveAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalReceiveAmount.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalReceiveAmount.ForeColor = System.Drawing.Color.Black
        Me.TxtTotalReceiveAmount.Location = New System.Drawing.Point(752, 518)
        Me.TxtTotalReceiveAmount.Name = "TxtTotalReceiveAmount"
        Me.TxtTotalReceiveAmount.Size = New System.Drawing.Size(120, 22)
        Me.TxtTotalReceiveAmount.TabIndex = 657
        Me.TxtTotalReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalReceiveAmt
        '
        Me.LblTotalReceiveAmt.AutoSize = True
        Me.LblTotalReceiveAmt.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalReceiveAmt.Location = New System.Drawing.Point(628, 521)
        Me.LblTotalReceiveAmt.Name = "LblTotalReceiveAmt"
        Me.LblTotalReceiveAmt.Size = New System.Drawing.Size(118, 14)
        Me.LblTotalReceiveAmt.TabIndex = 658
        Me.LblTotalReceiveAmt.Text = "Total Receive Amt"
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
        Me.TxtV_Type.Location = New System.Drawing.Point(129, 106)
        Me.TxtV_Type.MaxLength = 5
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(300, 21)
        Me.TxtV_Type.TabIndex = 2
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
        Me.TxtDocId.Location = New System.Drawing.Point(129, 62)
        Me.TxtDocId.MaxLength = 21
        Me.TxtDocId.Name = "TxtDocId"
        Me.TxtDocId.Size = New System.Drawing.Size(300, 21)
        Me.TxtDocId.TabIndex = 0
        Me.TxtDocId.TabStop = False
        '
        'BtnFillStudents
        '
        Me.BtnFillStudents.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillStudents.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillStudents.Location = New System.Drawing.Point(729, 155)
        Me.BtnFillStudents.Name = "BtnFillStudents"
        Me.BtnFillStudents.Size = New System.Drawing.Size(100, 23)
        Me.BtnFillStudents.TabIndex = 8
        Me.BtnFillStudents.Text = "Fill &Students"
        Me.BtnFillStudents.UseVisualStyleBackColor = True
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
        Me.TxtReceiveAmount.Location = New System.Drawing.Point(573, 105)
        Me.TxtReceiveAmount.Name = "TxtReceiveAmount"
        Me.TxtReceiveAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtReceiveAmount.TabIndex = 7
        Me.TxtReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblReceiveAmt
        '
        Me.LblReceiveAmt.AutoSize = True
        Me.LblReceiveAmt.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReceiveAmt.ForeColor = System.Drawing.Color.Blue
        Me.LblReceiveAmt.Location = New System.Drawing.Point(446, 108)
        Me.LblReceiveAmt.Name = "LblReceiveAmt"
        Me.LblReceiveAmt.Size = New System.Drawing.Size(100, 13)
        Me.LblReceiveAmt.TabIndex = 659
        Me.LblReceiveAmt.Text = "Receive &Amount"
        '
        'LblReceiveAmtReq
        '
        Me.LblReceiveAmtReq.AutoSize = True
        Me.LblReceiveAmtReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReceiveAmtReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReceiveAmtReq.Location = New System.Drawing.Point(557, 113)
        Me.LblReceiveAmtReq.Name = "LblReceiveAmtReq"
        Me.LblReceiveAmtReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReceiveAmtReq.TabIndex = 660
        Me.LblReceiveAmtReq.Text = "Ä"
        '
        'LblScholarshipAcReq
        '
        Me.LblScholarshipAcReq.AutoSize = True
        Me.LblScholarshipAcReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblScholarshipAcReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblScholarshipAcReq.Location = New System.Drawing.Point(557, 90)
        Me.LblScholarshipAcReq.Name = "LblScholarshipAcReq"
        Me.LblScholarshipAcReq.Size = New System.Drawing.Size(10, 7)
        Me.LblScholarshipAcReq.TabIndex = 663
        Me.LblScholarshipAcReq.Text = "Ä"
        '
        'TxtScholarshipAc
        '
        Me.TxtScholarshipAc.AgMandatory = False
        Me.TxtScholarshipAc.AgMasterHelp = False
        Me.TxtScholarshipAc.AgNumberLeftPlaces = 0
        Me.TxtScholarshipAc.AgNumberNegetiveAllow = False
        Me.TxtScholarshipAc.AgNumberRightPlaces = 0
        Me.TxtScholarshipAc.AgPickFromLastValue = False
        Me.TxtScholarshipAc.AgRowFilter = ""
        Me.TxtScholarshipAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtScholarshipAc.AgSelectedValue = Nothing
        Me.TxtScholarshipAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtScholarshipAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtScholarshipAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtScholarshipAc.Location = New System.Drawing.Point(573, 83)
        Me.TxtScholarshipAc.MaxLength = 10
        Me.TxtScholarshipAc.Name = "TxtScholarshipAc"
        Me.TxtScholarshipAc.Size = New System.Drawing.Size(300, 21)
        Me.TxtScholarshipAc.TabIndex = 6
        '
        'LblScholarshipAc
        '
        Me.LblScholarshipAc.AutoSize = True
        Me.LblScholarshipAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblScholarshipAc.Location = New System.Drawing.Point(446, 87)
        Me.LblScholarshipAc.Name = "LblScholarshipAc"
        Me.LblScholarshipAc.Size = New System.Drawing.Size(96, 13)
        Me.LblScholarshipAc.TabIndex = 662
        Me.LblScholarshipAc.Text = "Scholarship A/c"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnApproved)
        Me.GroupBox1.Controls.Add(Me.TxtApproved)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(686, 556)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox1.TabIndex = 664
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "UP"
        Me.GroupBox1.Text = "Approved By "
        Me.GroupBox1.Visible = False
        '
        'BtnApproved
        '
        Me.BtnApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApproved.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.BtnApproved.Image = CType(resources.GetObject("BtnApproved.Image"), System.Drawing.Image)
        Me.BtnApproved.Location = New System.Drawing.Point(8, 19)
        Me.BtnApproved.Name = "BtnApproved"
        Me.BtnApproved.Size = New System.Drawing.Size(23, 23)
        Me.BtnApproved.TabIndex = 36
        Me.BtnApproved.UseVisualStyleBackColor = True
        '
        'TxtApproved
        '
        Me.TxtApproved.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtApproved.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApproved.Location = New System.Drawing.Point(36, 21)
        Me.TxtApproved.Name = "TxtApproved"
        Me.TxtApproved.Size = New System.Drawing.Size(142, 18)
        Me.TxtApproved.TabIndex = 0
        Me.TxtApproved.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmScholarshipReceive
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 612)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblScholarshipAcReq)
        Me.Controls.Add(Me.TxtScholarshipAc)
        Me.Controls.Add(Me.LblScholarshipAc)
        Me.Controls.Add(Me.LblReceiveAmtReq)
        Me.Controls.Add(Me.TxtReceiveAmount)
        Me.Controls.Add(Me.LblReceiveAmt)
        Me.Controls.Add(Me.BtnFillStudents)
        Me.Controls.Add(Me.LblTotalReceiveAmt)
        Me.Controls.Add(Me.TxtTotalReceiveAmount)
        Me.Controls.Add(Me.LblReceiveDetail)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.LblDemandDocIdReq)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.LblRemark)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtDemandDocId)
        Me.Controls.Add(Me.LblDemandDocId)
        Me.Controls.Add(Me.TxtDocId)
        Me.Controls.Add(Me.LblV_No)
        Me.Controls.Add(Me.TxtV_No)
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
        Me.Name = "FrmScholarshipReceive"
        Me.Text = "Scholarship Receive"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtDemandDocId As AgControls.AgTextBox
    Friend WithEvents LblDemandDocId As System.Windows.Forms.Label
    Friend WithEvents LblV_No As System.Windows.Forms.Label
    Friend WithEvents TxtV_No As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblV_Date As System.Windows.Forms.Label
    Friend WithEvents LblV_TypeReq As System.Windows.Forms.Label
    Friend WithEvents TxtV_Date As AgControls.AgTextBox
    Friend WithEvents LblV_Type As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblDocId As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents LblRemark As System.Windows.Forms.Label
    Friend WithEvents LblDemandDocIdReq As System.Windows.Forms.Label
    Friend WithEvents LblReceiveDetail As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtTotalReceiveAmount As AgControls.AgTextBox
    Friend WithEvents LblTotalReceiveAmt As System.Windows.Forms.Label
    Friend WithEvents TxtV_Type As AgControls.AgTextBox
    Friend WithEvents TxtDocId As AgControls.AgTextBox
    Friend WithEvents BtnFillStudents As System.Windows.Forms.Button
    Friend WithEvents TxtReceiveAmount As AgControls.AgTextBox
    Friend WithEvents LblReceiveAmt As System.Windows.Forms.Label
    Friend WithEvents LblReceiveAmtReq As System.Windows.Forms.Label
    Friend WithEvents LblScholarshipAcReq As System.Windows.Forms.Label
    Friend WithEvents TxtScholarshipAc As AgControls.AgTextBox
    Friend WithEvents LblScholarshipAc As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnApproved As System.Windows.Forms.Button
    Friend WithEvents TxtApproved As System.Windows.Forms.TextBox
End Class
