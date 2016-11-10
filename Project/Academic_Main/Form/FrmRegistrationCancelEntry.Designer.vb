<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRegistrationCancelEntry
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRegistrationCancelEntry))
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.PnlFooter = New System.Windows.Forms.Panel
        Me.LblRefundAmount = New System.Windows.Forms.Label
        Me.TxtRefundAmount = New AgControls.AgTextBox
        Me.TxtIsNewStudent = New AgControls.AgTextBox
        Me.TxtSessionProgramme = New AgControls.AgTextBox
        Me.Label112 = New System.Windows.Forms.Label
        Me.TxtDocId = New AgControls.AgTextBox
        Me.TxtRemark = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.LblV_No = New System.Windows.Forms.Label
        Me.TxtV_No = New AgControls.AgTextBox
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.LblV_Type = New System.Windows.Forms.Label
        Me.TxtV_Type = New AgControls.AgTextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblDocId = New System.Windows.Forms.Label
        Me.TxtAdmissionNature = New AgControls.AgTextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.LblV_TypeReq = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtFirstName = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtMiddleName = New AgControls.AgTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtLastName = New AgControls.AgTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtStudent = New AgControls.AgTextBox
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.TxtMotherName = New AgControls.AgTextBox
        Me.TxtMotherNamePrefix = New AgControls.AgTextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtFatherName = New AgControls.AgTextBox
        Me.TxtFatherNamePrefix = New AgControls.AgTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.LblRegistrationDocIdReq = New System.Windows.Forms.Label
        Me.TxtRegistrationDocId = New AgControls.AgTextBox
        Me.LblRegistrationDocId = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnApproved = New System.Windows.Forms.Button
        Me.TxtApproved = New System.Windows.Forms.TextBox
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 453)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 500
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
        Me.GroupBox4.Location = New System.Drawing.Point(402, 453)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 501
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
        Me.GroupBox2.Location = New System.Drawing.Point(0, 443)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(950, 4)
        Me.GroupBox2.TabIndex = 373
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'PnlFooter
        '
        Me.PnlFooter.Location = New System.Drawing.Point(637, 279)
        Me.PnlFooter.Name = "PnlFooter"
        Me.PnlFooter.Size = New System.Drawing.Size(293, 118)
        Me.PnlFooter.TabIndex = 39
        '
        'LblRefundAmount
        '
        Me.LblRefundAmount.AutoSize = True
        Me.LblRefundAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRefundAmount.ForeColor = System.Drawing.Color.Blue
        Me.LblRefundAmount.Location = New System.Drawing.Point(718, 415)
        Me.LblRefundAmount.Name = "LblRefundAmount"
        Me.LblRefundAmount.Size = New System.Drawing.Size(95, 13)
        Me.LblRefundAmount.TabIndex = 16
        Me.LblRefundAmount.Text = "Refund &Amount"
        '
        'TxtRefundAmount
        '
        Me.TxtRefundAmount.AgMandatory = False
        Me.TxtRefundAmount.AgMasterHelp = False
        Me.TxtRefundAmount.AgNumberLeftPlaces = 8
        Me.TxtRefundAmount.AgNumberNegetiveAllow = False
        Me.TxtRefundAmount.AgNumberRightPlaces = 2
        Me.TxtRefundAmount.AgPickFromLastValue = False
        Me.TxtRefundAmount.AgRowFilter = ""
        Me.TxtRefundAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRefundAmount.AgSelectedValue = Nothing
        Me.TxtRefundAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRefundAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtRefundAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRefundAmount.ForeColor = System.Drawing.Color.Blue
        Me.TxtRefundAmount.Location = New System.Drawing.Point(830, 411)
        Me.TxtRefundAmount.Name = "TxtRefundAmount"
        Me.TxtRefundAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtRefundAmount.TabIndex = 17
        Me.TxtRefundAmount.Text = "Refund Amount"
        Me.TxtRefundAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtIsNewStudent
        '
        Me.TxtIsNewStudent.AgMandatory = False
        Me.TxtIsNewStudent.AgMasterHelp = False
        Me.TxtIsNewStudent.AgNumberLeftPlaces = 0
        Me.TxtIsNewStudent.AgNumberNegetiveAllow = False
        Me.TxtIsNewStudent.AgNumberRightPlaces = 0
        Me.TxtIsNewStudent.AgPickFromLastValue = False
        Me.TxtIsNewStudent.AgRowFilter = ""
        Me.TxtIsNewStudent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsNewStudent.AgSelectedValue = Nothing
        Me.TxtIsNewStudent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsNewStudent.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsNewStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsNewStudent.Location = New System.Drawing.Point(574, 78)
        Me.TxtIsNewStudent.MaxLength = 3
        Me.TxtIsNewStudent.Name = "TxtIsNewStudent"
        Me.TxtIsNewStudent.Size = New System.Drawing.Size(60, 21)
        Me.TxtIsNewStudent.TabIndex = 615
        Me.TxtIsNewStudent.Text = "TxtIsNewStudent"
        Me.TxtIsNewStudent.Visible = False
        '
        'TxtSessionProgramme
        '
        Me.TxtSessionProgramme.AgMandatory = False
        Me.TxtSessionProgramme.AgMasterHelp = False
        Me.TxtSessionProgramme.AgNumberLeftPlaces = 0
        Me.TxtSessionProgramme.AgNumberNegetiveAllow = False
        Me.TxtSessionProgramme.AgNumberRightPlaces = 0
        Me.TxtSessionProgramme.AgPickFromLastValue = False
        Me.TxtSessionProgramme.AgRowFilter = ""
        Me.TxtSessionProgramme.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSessionProgramme.AgSelectedValue = Nothing
        Me.TxtSessionProgramme.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSessionProgramme.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSessionProgramme.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSessionProgramme.Location = New System.Drawing.Point(163, 188)
        Me.TxtSessionProgramme.MaxLength = 50
        Me.TxtSessionProgramme.Name = "TxtSessionProgramme"
        Me.TxtSessionProgramme.Size = New System.Drawing.Size(293, 21)
        Me.TxtSessionProgramme.TabIndex = 6
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label112.Location = New System.Drawing.Point(18, 192)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(56, 13)
        Me.Label112.TabIndex = 611
        Me.Label112.Text = "Program"
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
        Me.TxtDocId.Location = New System.Drawing.Point(163, 78)
        Me.TxtDocId.MaxLength = 21
        Me.TxtDocId.Name = "TxtDocId"
        Me.TxtDocId.ReadOnly = True
        Me.TxtDocId.Size = New System.Drawing.Size(293, 21)
        Me.TxtDocId.TabIndex = 0
        Me.TxtDocId.TabStop = False
        Me.TxtDocId.Text = "TxtDocId"
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
        Me.TxtRemark.Location = New System.Drawing.Point(93, 411)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(363, 21)
        Me.TxtRemark.TabIndex = 19
        Me.TxtRemark.Text = "AgTextBox4"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 415)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "&Remark"
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(277, 148)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(47, 13)
        Me.LblV_No.TabIndex = 385
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
        Me.TxtV_No.Location = New System.Drawing.Point(356, 144)
        Me.TxtV_No.Name = "TxtV_No"
        Me.TxtV_No.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_No.TabIndex = 4
        Me.TxtV_No.Text = "TxtV_No"
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(18, 149)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(85, 13)
        Me.LblV_Date.TabIndex = 383
        Me.LblV_Date.Text = "Voucher Date"
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
        Me.TxtV_Date.Location = New System.Drawing.Point(163, 144)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_Date.TabIndex = 3
        Me.TxtV_Date.Text = "TxtV_Date"
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(18, 127)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(86, 13)
        Me.LblV_Type.TabIndex = 382
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
        Me.TxtV_Type.Location = New System.Drawing.Point(163, 122)
        Me.TxtV_Type.MaxLength = 5
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(293, 21)
        Me.TxtV_Type.TabIndex = 2
        Me.TxtV_Type.Text = "TxtV_Type"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Blue
        Me.Label28.Location = New System.Drawing.Point(18, 243)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(69, 13)
        Me.Label28.TabIndex = 449
        Me.Label28.Text = "Fee Detail:"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(150, 108)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 381
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(18, 105)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 384
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(163, 100)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(293, 21)
        Me.TxtSite_Code.TabIndex = 1
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblDocId
        '
        Me.LblDocId.AutoSize = True
        Me.LblDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocId.Location = New System.Drawing.Point(18, 83)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(41, 13)
        Me.LblDocId.TabIndex = 43
        Me.LblDocId.Text = "DocId"
        '
        'TxtAdmissionNature
        '
        Me.TxtAdmissionNature.AgMandatory = False
        Me.TxtAdmissionNature.AgMasterHelp = False
        Me.TxtAdmissionNature.AgNumberLeftPlaces = 0
        Me.TxtAdmissionNature.AgNumberNegetiveAllow = False
        Me.TxtAdmissionNature.AgNumberRightPlaces = 0
        Me.TxtAdmissionNature.AgPickFromLastValue = False
        Me.TxtAdmissionNature.AgRowFilter = ""
        Me.TxtAdmissionNature.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdmissionNature.AgSelectedValue = Nothing
        Me.TxtAdmissionNature.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdmissionNature.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdmissionNature.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionNature.Location = New System.Drawing.Point(163, 211)
        Me.TxtAdmissionNature.MaxLength = 50
        Me.TxtAdmissionNature.Name = "TxtAdmissionNature"
        Me.TxtAdmissionNature.Size = New System.Drawing.Size(293, 21)
        Me.TxtAdmissionNature.TabIndex = 7
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(18, 215)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(107, 13)
        Me.Label31.TabIndex = 457
        Me.Label31.Text = "Admission Nature"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.AutoSize = True
        Me.LblV_TypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblV_TypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblV_TypeReq.Location = New System.Drawing.Point(150, 130)
        Me.LblV_TypeReq.Name = "LblV_TypeReq"
        Me.LblV_TypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblV_TypeReq.TabIndex = 386
        Me.LblV_TypeReq.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(150, 153)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 387
        Me.Label2.Text = "Ä"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(150, 86)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 388
        Me.Label5.Text = "Ä"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(492, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 393
        Me.Label3.Text = "First Name"
        '
        'TxtFirstName
        '
        Me.TxtFirstName.AgMandatory = False
        Me.TxtFirstName.AgMasterHelp = True
        Me.TxtFirstName.AgNumberLeftPlaces = 0
        Me.TxtFirstName.AgNumberNegetiveAllow = False
        Me.TxtFirstName.AgNumberRightPlaces = 0
        Me.TxtFirstName.AgPickFromLastValue = False
        Me.TxtFirstName.AgRowFilter = ""
        Me.TxtFirstName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFirstName.AgSelectedValue = Nothing
        Me.TxtFirstName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFirstName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFirstName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFirstName.Location = New System.Drawing.Point(637, 100)
        Me.TxtFirstName.MaxLength = 50
        Me.TxtFirstName.Name = "TxtFirstName"
        Me.TxtFirstName.Size = New System.Drawing.Size(293, 21)
        Me.TxtFirstName.TabIndex = 9
        Me.TxtFirstName.Text = "TxtFirstName"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(492, 127)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 13)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Middle Name"
        '
        'TxtMiddleName
        '
        Me.TxtMiddleName.AgMandatory = False
        Me.TxtMiddleName.AgMasterHelp = True
        Me.TxtMiddleName.AgNumberLeftPlaces = 0
        Me.TxtMiddleName.AgNumberNegetiveAllow = False
        Me.TxtMiddleName.AgNumberRightPlaces = 0
        Me.TxtMiddleName.AgPickFromLastValue = False
        Me.TxtMiddleName.AgRowFilter = ""
        Me.TxtMiddleName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMiddleName.AgSelectedValue = Nothing
        Me.TxtMiddleName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMiddleName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMiddleName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMiddleName.Location = New System.Drawing.Point(637, 122)
        Me.TxtMiddleName.MaxLength = 25
        Me.TxtMiddleName.Name = "TxtMiddleName"
        Me.TxtMiddleName.Size = New System.Drawing.Size(293, 21)
        Me.TxtMiddleName.TabIndex = 10
        Me.TxtMiddleName.Text = "AgTextBox3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(492, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(67, 13)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Last Name"
        '
        'TxtLastName
        '
        Me.TxtLastName.AgMandatory = False
        Me.TxtLastName.AgMasterHelp = True
        Me.TxtLastName.AgNumberLeftPlaces = 0
        Me.TxtLastName.AgNumberNegetiveAllow = False
        Me.TxtLastName.AgNumberRightPlaces = 0
        Me.TxtLastName.AgPickFromLastValue = False
        Me.TxtLastName.AgRowFilter = ""
        Me.TxtLastName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLastName.AgSelectedValue = Nothing
        Me.TxtLastName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLastName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtLastName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLastName.Location = New System.Drawing.Point(637, 144)
        Me.TxtLastName.MaxLength = 25
        Me.TxtLastName.Name = "TxtLastName"
        Me.TxtLastName.Size = New System.Drawing.Size(293, 21)
        Me.TxtLastName.TabIndex = 11
        Me.TxtLastName.Text = "AgTextBox4"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(492, 82)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 417
        Me.Label16.Text = "Student"
        '
        'TxtStudent
        '
        Me.TxtStudent.AgMandatory = False
        Me.TxtStudent.AgMasterHelp = False
        Me.TxtStudent.AgNumberLeftPlaces = 0
        Me.TxtStudent.AgNumberNegetiveAllow = False
        Me.TxtStudent.AgNumberRightPlaces = 0
        Me.TxtStudent.AgPickFromLastValue = False
        Me.TxtStudent.AgRowFilter = ""
        Me.TxtStudent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStudent.AgSelectedValue = Nothing
        Me.TxtStudent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStudent.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStudent.Location = New System.Drawing.Point(637, 78)
        Me.TxtStudent.MaxLength = 123
        Me.TxtStudent.Name = "TxtStudent"
        Me.TxtStudent.Size = New System.Drawing.Size(293, 21)
        Me.TxtStudent.TabIndex = 8
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(21, 261)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(586, 136)
        Me.Pnl1.TabIndex = 42
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(321, 148)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(56, 13)
        Me.LblPrefix.TabIndex = 378
        Me.LblPrefix.Text = "LblPrefix"
        '
        'TxtMotherName
        '
        Me.TxtMotherName.AgMandatory = False
        Me.TxtMotherName.AgMasterHelp = False
        Me.TxtMotherName.AgNumberLeftPlaces = 0
        Me.TxtMotherName.AgNumberNegetiveAllow = False
        Me.TxtMotherName.AgNumberRightPlaces = 0
        Me.TxtMotherName.AgPickFromLastValue = False
        Me.TxtMotherName.AgRowFilter = ""
        Me.TxtMotherName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMotherName.AgSelectedValue = Nothing
        Me.TxtMotherName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMotherName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMotherName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotherName.Location = New System.Drawing.Point(698, 188)
        Me.TxtMotherName.MaxLength = 100
        Me.TxtMotherName.Name = "TxtMotherName"
        Me.TxtMotherName.Size = New System.Drawing.Size(232, 21)
        Me.TxtMotherName.TabIndex = 15
        Me.TxtMotherName.Text = "XXXXXX"
        '
        'TxtMotherNamePrefix
        '
        Me.TxtMotherNamePrefix.AgMandatory = False
        Me.TxtMotherNamePrefix.AgMasterHelp = False
        Me.TxtMotherNamePrefix.AgNumberLeftPlaces = 0
        Me.TxtMotherNamePrefix.AgNumberNegetiveAllow = False
        Me.TxtMotherNamePrefix.AgNumberRightPlaces = 0
        Me.TxtMotherNamePrefix.AgPickFromLastValue = False
        Me.TxtMotherNamePrefix.AgRowFilter = ""
        Me.TxtMotherNamePrefix.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMotherNamePrefix.AgSelectedValue = Nothing
        Me.TxtMotherNamePrefix.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMotherNamePrefix.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMotherNamePrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMotherNamePrefix.Location = New System.Drawing.Point(637, 188)
        Me.TxtMotherNamePrefix.MaxLength = 10
        Me.TxtMotherNamePrefix.Name = "TxtMotherNamePrefix"
        Me.TxtMotherNamePrefix.Size = New System.Drawing.Size(59, 21)
        Me.TxtMotherNamePrefix.TabIndex = 14
        Me.TxtMotherNamePrefix.Text = "AgTextBox5"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(492, 193)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(83, 13)
        Me.Label14.TabIndex = 621
        Me.Label14.Text = "Mother Name"
        '
        'TxtFatherName
        '
        Me.TxtFatherName.AgMandatory = False
        Me.TxtFatherName.AgMasterHelp = False
        Me.TxtFatherName.AgNumberLeftPlaces = 0
        Me.TxtFatherName.AgNumberNegetiveAllow = False
        Me.TxtFatherName.AgNumberRightPlaces = 0
        Me.TxtFatherName.AgPickFromLastValue = False
        Me.TxtFatherName.AgRowFilter = ""
        Me.TxtFatherName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFatherName.AgSelectedValue = Nothing
        Me.TxtFatherName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFatherName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFatherName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFatherName.Location = New System.Drawing.Point(698, 166)
        Me.TxtFatherName.MaxLength = 100
        Me.TxtFatherName.Name = "TxtFatherName"
        Me.TxtFatherName.Size = New System.Drawing.Size(232, 21)
        Me.TxtFatherName.TabIndex = 13
        Me.TxtFatherName.Text = "XXXXXX"
        '
        'TxtFatherNamePrefix
        '
        Me.TxtFatherNamePrefix.AgMandatory = False
        Me.TxtFatherNamePrefix.AgMasterHelp = False
        Me.TxtFatherNamePrefix.AgNumberLeftPlaces = 0
        Me.TxtFatherNamePrefix.AgNumberNegetiveAllow = False
        Me.TxtFatherNamePrefix.AgNumberRightPlaces = 0
        Me.TxtFatherNamePrefix.AgPickFromLastValue = False
        Me.TxtFatherNamePrefix.AgRowFilter = ""
        Me.TxtFatherNamePrefix.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFatherNamePrefix.AgSelectedValue = Nothing
        Me.TxtFatherNamePrefix.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFatherNamePrefix.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFatherNamePrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFatherNamePrefix.Location = New System.Drawing.Point(637, 166)
        Me.TxtFatherNamePrefix.MaxLength = 10
        Me.TxtFatherNamePrefix.Name = "TxtFatherNamePrefix"
        Me.TxtFatherNamePrefix.Size = New System.Drawing.Size(59, 21)
        Me.TxtFatherNamePrefix.TabIndex = 12
        Me.TxtFatherNamePrefix.Text = "AgTextBox5"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(492, 170)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 13)
        Me.Label13.TabIndex = 620
        Me.Label13.Text = "Father Name"
        '
        'LblRegistrationDocIdReq
        '
        Me.LblRegistrationDocIdReq.AutoSize = True
        Me.LblRegistrationDocIdReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblRegistrationDocIdReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblRegistrationDocIdReq.Location = New System.Drawing.Point(150, 174)
        Me.LblRegistrationDocIdReq.Name = "LblRegistrationDocIdReq"
        Me.LblRegistrationDocIdReq.Size = New System.Drawing.Size(10, 7)
        Me.LblRegistrationDocIdReq.TabIndex = 625
        Me.LblRegistrationDocIdReq.Text = "Ä"
        '
        'TxtRegistrationDocId
        '
        Me.TxtRegistrationDocId.AgMandatory = True
        Me.TxtRegistrationDocId.AgMasterHelp = False
        Me.TxtRegistrationDocId.AgNumberLeftPlaces = 0
        Me.TxtRegistrationDocId.AgNumberNegetiveAllow = False
        Me.TxtRegistrationDocId.AgNumberRightPlaces = 0
        Me.TxtRegistrationDocId.AgPickFromLastValue = False
        Me.TxtRegistrationDocId.AgRowFilter = ""
        Me.TxtRegistrationDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRegistrationDocId.AgSelectedValue = Nothing
        Me.TxtRegistrationDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRegistrationDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRegistrationDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRegistrationDocId.Location = New System.Drawing.Point(163, 166)
        Me.TxtRegistrationDocId.MaxLength = 50
        Me.TxtRegistrationDocId.Name = "TxtRegistrationDocId"
        Me.TxtRegistrationDocId.Size = New System.Drawing.Size(293, 21)
        Me.TxtRegistrationDocId.TabIndex = 5
        '
        'LblRegistrationDocId
        '
        Me.LblRegistrationDocId.AutoSize = True
        Me.LblRegistrationDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistrationDocId.Location = New System.Drawing.Point(18, 171)
        Me.LblRegistrationDocId.Name = "LblRegistrationDocId"
        Me.LblRegistrationDocId.Size = New System.Drawing.Size(119, 13)
        Me.LblRegistrationDocId.TabIndex = 624
        Me.LblRegistrationDocId.Text = "Registration Vr. No."
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnApproved)
        Me.GroupBox1.Controls.Add(Me.TxtApproved)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(744, 453)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox1.TabIndex = 626
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
        'FrmRegistrationCancelEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 516)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LblRegistrationDocIdReq)
        Me.Controls.Add(Me.TxtRegistrationDocId)
        Me.Controls.Add(Me.LblRegistrationDocId)
        Me.Controls.Add(Me.TxtMotherName)
        Me.Controls.Add(Me.TxtMotherNamePrefix)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtFatherName)
        Me.Controls.Add(Me.TxtFatherNamePrefix)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtRefundAmount)
        Me.Controls.Add(Me.TxtIsNewStudent)
        Me.Controls.Add(Me.LblRefundAmount)
        Me.Controls.Add(Me.PnlFooter)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtSessionProgramme)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Label112)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtDocId)
        Me.Controls.Add(Me.TxtStudent)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TxtLastName)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtMiddleName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblV_No)
        Me.Controls.Add(Me.TxtFirstName)
        Me.Controls.Add(Me.TxtV_No)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblV_Type)
        Me.Controls.Add(Me.LblV_TypeReq)
        Me.Controls.Add(Me.TxtV_Type)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TxtAdmissionNature)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblDocId)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblPrefix)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRegistrationCancelEntry"
        Me.Text = "Registration Cancel Entry"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents PnlFooter As System.Windows.Forms.Panel
    Friend WithEvents LblRefundAmount As System.Windows.Forms.Label
    Friend WithEvents TxtRefundAmount As AgControls.AgTextBox
    Friend WithEvents TxtDocId As AgControls.AgTextBox
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LblV_No As System.Windows.Forms.Label
    Friend WithEvents TxtV_No As AgControls.AgTextBox
    Friend WithEvents LblV_Date As System.Windows.Forms.Label
    Friend WithEvents TxtV_Date As AgControls.AgTextBox
    Friend WithEvents LblV_Type As System.Windows.Forms.Label
    Friend WithEvents TxtV_Type As AgControls.AgTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblDocId As System.Windows.Forms.Label
    Friend WithEvents TxtAdmissionNature As AgControls.AgTextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents LblV_TypeReq As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtFirstName As AgControls.AgTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtMiddleName As AgControls.AgTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtLastName As AgControls.AgTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtStudent As AgControls.AgTextBox
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtSessionProgramme As AgControls.AgTextBox
    Friend WithEvents Label112 As System.Windows.Forms.Label
    Friend WithEvents TxtIsNewStudent As AgControls.AgTextBox
    Friend WithEvents TxtMotherName As AgControls.AgTextBox
    Friend WithEvents TxtMotherNamePrefix As AgControls.AgTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtFatherName As AgControls.AgTextBox
    Friend WithEvents TxtFatherNamePrefix As AgControls.AgTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents LblRegistrationDocIdReq As System.Windows.Forms.Label
    Friend WithEvents TxtRegistrationDocId As AgControls.AgTextBox
    Friend WithEvents LblRegistrationDocId As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnApproved As System.Windows.Forms.Button
    Friend WithEvents TxtApproved As System.Windows.Forms.TextBox
End Class
