<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoomChargeRefund
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
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.TxtTotalRefundAmount = New AgControls.AgTextBox
        Me.LblTotalRefundAmount = New System.Windows.Forms.Label
        Me.LblChargeReceiveDocIdReq = New System.Windows.Forms.Label
        Me.LblAdmissionDocIdReq = New System.Windows.Forms.Label
        Me.TxtChargeReceiveDocId = New AgControls.AgTextBox
        Me.LblChargeReceiveDocId = New System.Windows.Forms.Label
        Me.TxtReceiveAmount = New AgControls.AgTextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.TxtAllotmentDocId = New AgControls.AgTextBox
        Me.LblAllotmentDocId = New System.Windows.Forms.Label
        Me.BtnFillCharge = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.PnlFooter1 = New System.Windows.Forms.Panel
        Me.TxtRefundAmount = New AgControls.AgTextBox
        Me.LblRefundAmount = New System.Windows.Forms.Label
        Me.LblIsManageFeeReq = New System.Windows.Forms.Label
        Me.LblIsManageCharge = New System.Windows.Forms.Label
        Me.TxtIsManageCharge = New AgControls.AgTextBox
        Me.TxtRemark = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.Topctrl1.TabIndex = 18
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
        Me.TxtDocId.Location = New System.Drawing.Point(166, 68)
        Me.TxtDocId.MaxLength = 21
        Me.TxtDocId.Name = "TxtDocId"
        Me.TxtDocId.ReadOnly = True
        Me.TxtDocId.Size = New System.Drawing.Size(293, 21)
        Me.TxtDocId.TabIndex = 0
        Me.TxtDocId.TabStop = False
        Me.TxtDocId.Text = "TxtDocId"
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(280, 138)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(47, 13)
        Me.LblV_No.TabIndex = 415
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
        Me.TxtV_No.Location = New System.Drawing.Point(359, 134)
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
        Me.Label5.Location = New System.Drawing.Point(153, 76)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 418
        Me.Label5.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(153, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 417
        Me.Label2.Text = "Ä"
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(22, 139)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(85, 13)
        Me.LblV_Date.TabIndex = 413
        Me.LblV_Date.Text = "Voucher Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.AutoSize = True
        Me.LblV_TypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblV_TypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblV_TypeReq.Location = New System.Drawing.Point(153, 120)
        Me.LblV_TypeReq.Name = "LblV_TypeReq"
        Me.LblV_TypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblV_TypeReq.TabIndex = 416
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
        Me.TxtV_Date.Location = New System.Drawing.Point(166, 134)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_Date.TabIndex = 3
        Me.TxtV_Date.Text = "TxtV_Date"
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(22, 117)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(86, 13)
        Me.LblV_Type.TabIndex = 412
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
        Me.TxtV_Type.Location = New System.Drawing.Point(166, 112)
        Me.TxtV_Type.MaxLength = 5
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(293, 21)
        Me.TxtV_Type.TabIndex = 2
        Me.TxtV_Type.Text = "TxtV_Type"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(153, 98)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 411
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(22, 95)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 414
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(166, 90)
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
        Me.LblDocId.Location = New System.Drawing.Point(22, 73)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(41, 13)
        Me.LblDocId.TabIndex = 409
        Me.LblDocId.Text = "DocId"
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(324, 138)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(56, 13)
        Me.LblPrefix.TabIndex = 410
        Me.LblPrefix.Text = "LblPrefix"
        '
        'TxtTotalRefundAmount
        '
        Me.TxtTotalRefundAmount.AgMandatory = False
        Me.TxtTotalRefundAmount.AgMasterHelp = False
        Me.TxtTotalRefundAmount.AgNumberLeftPlaces = 8
        Me.TxtTotalRefundAmount.AgNumberNegetiveAllow = False
        Me.TxtTotalRefundAmount.AgNumberRightPlaces = 2
        Me.TxtTotalRefundAmount.AgPickFromLastValue = False
        Me.TxtTotalRefundAmount.AgRowFilter = ""
        Me.TxtTotalRefundAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalRefundAmount.AgSelectedValue = Nothing
        Me.TxtTotalRefundAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalRefundAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalRefundAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalRefundAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtTotalRefundAmount.Location = New System.Drawing.Point(826, 109)
        Me.TxtTotalRefundAmount.Name = "TxtTotalRefundAmount"
        Me.TxtTotalRefundAmount.ReadOnly = True
        Me.TxtTotalRefundAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtTotalRefundAmount.TabIndex = 8
        Me.TxtTotalRefundAmount.TabStop = False
        Me.TxtTotalRefundAmount.Text = "Total Refund"
        Me.TxtTotalRefundAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalRefundAmount
        '
        Me.LblTotalRefundAmount.AutoSize = True
        Me.LblTotalRefundAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalRefundAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblTotalRefundAmount.Location = New System.Drawing.Point(741, 113)
        Me.LblTotalRefundAmount.Name = "LblTotalRefundAmount"
        Me.LblTotalRefundAmount.Size = New System.Drawing.Size(79, 13)
        Me.LblTotalRefundAmount.TabIndex = 652
        Me.LblTotalRefundAmount.Text = "Total Refund"
        '
        'LblChargeReceiveDocIdReq
        '
        Me.LblChargeReceiveDocIdReq.AutoSize = True
        Me.LblChargeReceiveDocIdReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblChargeReceiveDocIdReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblChargeReceiveDocIdReq.Location = New System.Drawing.Point(615, 94)
        Me.LblChargeReceiveDocIdReq.Name = "LblChargeReceiveDocIdReq"
        Me.LblChargeReceiveDocIdReq.Size = New System.Drawing.Size(10, 7)
        Me.LblChargeReceiveDocIdReq.TabIndex = 651
        Me.LblChargeReceiveDocIdReq.Text = "Ä"
        '
        'LblAdmissionDocIdReq
        '
        Me.LblAdmissionDocIdReq.AutoSize = True
        Me.LblAdmissionDocIdReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAdmissionDocIdReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAdmissionDocIdReq.Location = New System.Drawing.Point(615, 72)
        Me.LblAdmissionDocIdReq.Name = "LblAdmissionDocIdReq"
        Me.LblAdmissionDocIdReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAdmissionDocIdReq.TabIndex = 650
        Me.LblAdmissionDocIdReq.Text = "Ä"
        '
        'TxtChargeReceiveDocId
        '
        Me.TxtChargeReceiveDocId.AgMandatory = True
        Me.TxtChargeReceiveDocId.AgMasterHelp = False
        Me.TxtChargeReceiveDocId.AgNumberLeftPlaces = 0
        Me.TxtChargeReceiveDocId.AgNumberNegetiveAllow = False
        Me.TxtChargeReceiveDocId.AgNumberRightPlaces = 0
        Me.TxtChargeReceiveDocId.AgPickFromLastValue = False
        Me.TxtChargeReceiveDocId.AgRowFilter = ""
        Me.TxtChargeReceiveDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtChargeReceiveDocId.AgSelectedValue = Nothing
        Me.TxtChargeReceiveDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtChargeReceiveDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtChargeReceiveDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChargeReceiveDocId.Location = New System.Drawing.Point(631, 87)
        Me.TxtChargeReceiveDocId.MaxLength = 21
        Me.TxtChargeReceiveDocId.Name = "TxtChargeReceiveDocId"
        Me.TxtChargeReceiveDocId.Size = New System.Drawing.Size(293, 21)
        Me.TxtChargeReceiveDocId.TabIndex = 6
        '
        'LblChargeReceiveDocId
        '
        Me.LblChargeReceiveDocId.AutoSize = True
        Me.LblChargeReceiveDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChargeReceiveDocId.Location = New System.Drawing.Point(467, 91)
        Me.LblChargeReceiveDocId.Name = "LblChargeReceiveDocId"
        Me.LblChargeReceiveDocId.Size = New System.Drawing.Size(142, 13)
        Me.LblChargeReceiveDocId.TabIndex = 649
        Me.LblChargeReceiveDocId.Text = "Charge Receive Vr. No."
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
        Me.TxtReceiveAmount.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TxtReceiveAmount.Location = New System.Drawing.Point(631, 109)
        Me.TxtReceiveAmount.Name = "TxtReceiveAmount"
        Me.TxtReceiveAmount.ReadOnly = True
        Me.TxtReceiveAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtReceiveAmount.TabIndex = 7
        Me.TxtReceiveAmount.TabStop = False
        Me.TxtReceiveAmount.Text = "Receive Amount"
        Me.TxtReceiveAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label39.Location = New System.Drawing.Point(467, 113)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(100, 13)
        Me.Label39.TabIndex = 646
        Me.Label39.Text = "Receive Amount"
        '
        'TxtAllotmentDocId
        '
        Me.TxtAllotmentDocId.AgMandatory = True
        Me.TxtAllotmentDocId.AgMasterHelp = False
        Me.TxtAllotmentDocId.AgNumberLeftPlaces = 0
        Me.TxtAllotmentDocId.AgNumberNegetiveAllow = False
        Me.TxtAllotmentDocId.AgNumberRightPlaces = 0
        Me.TxtAllotmentDocId.AgPickFromLastValue = False
        Me.TxtAllotmentDocId.AgRowFilter = ""
        Me.TxtAllotmentDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAllotmentDocId.AgSelectedValue = Nothing
        Me.TxtAllotmentDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAllotmentDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAllotmentDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAllotmentDocId.Location = New System.Drawing.Point(631, 65)
        Me.TxtAllotmentDocId.MaxLength = 123
        Me.TxtAllotmentDocId.Name = "TxtAllotmentDocId"
        Me.TxtAllotmentDocId.Size = New System.Drawing.Size(293, 21)
        Me.TxtAllotmentDocId.TabIndex = 5
        '
        'LblAllotmentDocId
        '
        Me.LblAllotmentDocId.AutoSize = True
        Me.LblAllotmentDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAllotmentDocId.Location = New System.Drawing.Point(467, 69)
        Me.LblAllotmentDocId.Name = "LblAllotmentDocId"
        Me.LblAllotmentDocId.Size = New System.Drawing.Size(90, 13)
        Me.LblAllotmentDocId.TabIndex = 647
        Me.LblAllotmentDocId.Text = "Member Name"
        '
        'BtnFillCharge
        '
        Me.BtnFillCharge.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillCharge.Location = New System.Drawing.Point(558, 165)
        Me.BtnFillCharge.Name = "BtnFillCharge"
        Me.BtnFillCharge.Size = New System.Drawing.Size(75, 23)
        Me.BtnFillCharge.TabIndex = 9
        Me.BtnFillCharge.Text = "Fill &Charge"
        Me.BtnFillCharge.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(25, 170)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(172, 13)
        Me.Label1.TabIndex = 655
        Me.Label1.Text = "Room Charge Refund Detail:"
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(25, 189)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(608, 259)
        Me.Pnl1.TabIndex = 10
        '
        'PnlFooter1
        '
        Me.PnlFooter1.Location = New System.Drawing.Point(639, 340)
        Me.PnlFooter1.Name = "PnlFooter1"
        Me.PnlFooter1.Size = New System.Drawing.Size(293, 108)
        Me.PnlFooter1.TabIndex = 656
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
        Me.TxtRefundAmount.Location = New System.Drawing.Point(826, 467)
        Me.TxtRefundAmount.Name = "TxtRefundAmount"
        Me.TxtRefundAmount.Size = New System.Drawing.Size(100, 21)
        Me.TxtRefundAmount.TabIndex = 658
        Me.TxtRefundAmount.Text = "Refund Amount"
        Me.TxtRefundAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblRefundAmount
        '
        Me.LblRefundAmount.AutoSize = True
        Me.LblRefundAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRefundAmount.ForeColor = System.Drawing.Color.Blue
        Me.LblRefundAmount.Location = New System.Drawing.Point(714, 471)
        Me.LblRefundAmount.Name = "LblRefundAmount"
        Me.LblRefundAmount.Size = New System.Drawing.Size(95, 13)
        Me.LblRefundAmount.TabIndex = 657
        Me.LblRefundAmount.Text = "Refund &Amount"
        '
        'LblIsManageFeeReq
        '
        Me.LblIsManageFeeReq.AutoSize = True
        Me.LblIsManageFeeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblIsManageFeeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblIsManageFeeReq.Location = New System.Drawing.Point(575, 474)
        Me.LblIsManageFeeReq.Name = "LblIsManageFeeReq"
        Me.LblIsManageFeeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblIsManageFeeReq.TabIndex = 663
        Me.LblIsManageFeeReq.Text = "Ä"
        '
        'LblIsManageCharge
        '
        Me.LblIsManageCharge.AutoSize = True
        Me.LblIsManageCharge.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsManageCharge.Location = New System.Drawing.Point(398, 471)
        Me.LblIsManageCharge.Name = "LblIsManageCharge"
        Me.LblIsManageCharge.Size = New System.Drawing.Size(151, 13)
        Me.LblIsManageCharge.TabIndex = 659
        Me.LblIsManageCharge.Text = "Manage Charge (Yes/No)"
        '
        'TxtIsManageCharge
        '
        Me.TxtIsManageCharge.AgMandatory = True
        Me.TxtIsManageCharge.AgMasterHelp = False
        Me.TxtIsManageCharge.AgNumberLeftPlaces = 0
        Me.TxtIsManageCharge.AgNumberNegetiveAllow = False
        Me.TxtIsManageCharge.AgNumberRightPlaces = 0
        Me.TxtIsManageCharge.AgPickFromLastValue = False
        Me.TxtIsManageCharge.AgRowFilter = ""
        Me.TxtIsManageCharge.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsManageCharge.AgSelectedValue = Nothing
        Me.TxtIsManageCharge.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsManageCharge.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsManageCharge.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsManageCharge.Location = New System.Drawing.Point(591, 467)
        Me.TxtIsManageCharge.Name = "TxtIsManageCharge"
        Me.TxtIsManageCharge.Size = New System.Drawing.Size(42, 21)
        Me.TxtIsManageCharge.TabIndex = 12
        Me.TxtIsManageCharge.Text = "TxtIsManageCharge"
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
        Me.TxtRemark.Location = New System.Drawing.Point(92, 467)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(288, 21)
        Me.TxtRemark.TabIndex = 11
        Me.TxtRemark.Text = "TxtRemark"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(22, 471)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 661
        Me.Label12.Text = "&Remark"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(0, 500)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1020, 4)
        Me.GroupBox2.TabIndex = 664
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 510)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 665
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
        Me.GroupBox4.Location = New System.Drawing.Point(744, 510)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 666
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
        'FrmRoomChargeRefundEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(942, 573)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtRefundAmount)
        Me.Controls.Add(Me.LblRefundAmount)
        Me.Controls.Add(Me.LblIsManageFeeReq)
        Me.Controls.Add(Me.LblIsManageCharge)
        Me.Controls.Add(Me.TxtIsManageCharge)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.PnlFooter1)
        Me.Controls.Add(Me.BtnFillCharge)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtTotalRefundAmount)
        Me.Controls.Add(Me.LblTotalRefundAmount)
        Me.Controls.Add(Me.LblChargeReceiveDocIdReq)
        Me.Controls.Add(Me.LblAdmissionDocIdReq)
        Me.Controls.Add(Me.TxtChargeReceiveDocId)
        Me.Controls.Add(Me.LblChargeReceiveDocId)
        Me.Controls.Add(Me.TxtReceiveAmount)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.TxtAllotmentDocId)
        Me.Controls.Add(Me.LblAllotmentDocId)
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
        Me.Controls.Add(Me.LblPrefix)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRoomChargeRefundEntry"
        Me.Text = "Room Charge Refund Entry"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
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
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents TxtTotalRefundAmount As AgControls.AgTextBox
    Friend WithEvents LblTotalRefundAmount As System.Windows.Forms.Label
    Friend WithEvents LblChargeReceiveDocIdReq As System.Windows.Forms.Label
    Friend WithEvents LblAdmissionDocIdReq As System.Windows.Forms.Label
    Friend WithEvents TxtChargeReceiveDocId As AgControls.AgTextBox
    Friend WithEvents LblChargeReceiveDocId As System.Windows.Forms.Label
    Friend WithEvents TxtReceiveAmount As AgControls.AgTextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents TxtAllotmentDocId As AgControls.AgTextBox
    Friend WithEvents LblAllotmentDocId As System.Windows.Forms.Label
    Friend WithEvents BtnFillCharge As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents PnlFooter1 As System.Windows.Forms.Panel
    Friend WithEvents TxtRefundAmount As AgControls.AgTextBox
    Friend WithEvents LblRefundAmount As System.Windows.Forms.Label
    Friend WithEvents LblIsManageFeeReq As System.Windows.Forms.Label
    Friend WithEvents LblIsManageCharge As System.Windows.Forms.Label
    Friend WithEvents TxtIsManageCharge As AgControls.AgTextBox
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
End Class
