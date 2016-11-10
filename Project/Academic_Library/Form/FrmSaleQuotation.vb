Public Class FrmSaleQuotation
    Inherits AgTemplate.TempTransaction
    Public mQry$
    Dim mTransFlag As Boolean = False

    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1ScrapCategory As String = "Scrap Category"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected WithEvents txtByerQuotationNo As AgControls.AgTextBox
    Protected WithEvents LblByerQuotationNo As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblTotalAmountValue As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents LblBuyerQuoteDate As System.Windows.Forms.Label
    Protected WithEvents TxtBuyerQuoteDate As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.ScrapQuotation
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalAmountValue = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.LblBuyerReq = New System.Windows.Forms.Label
        Me.TxtBuyer = New AgControls.AgTextBox
        Me.LblBuyer = New System.Windows.Forms.Label
        Me.txtByerQuotationNo = New AgControls.AgTextBox
        Me.LblByerQuotationNo = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LblBuyerQuoteDate = New System.Windows.Forms.Label
        Me.TxtBuyerQuoteDate = New AgControls.AgTextBox
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(756, 465)
        Me.GroupBox2.Size = New System.Drawing.Size(148, 40)
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Location = New System.Drawing.Point(29, 19)
        Me.TxtStatus.Tag = ""
        '
        'CmdStatus
        '
        Me.CmdStatus.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(596, 465)
        Me.GBoxMoveToLog.Size = New System.Drawing.Size(148, 40)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 19)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(142, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'CmdMoveToLog
        '
        Me.CmdMoveToLog.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(421, 465)
        Me.GBoxApprove.Size = New System.Drawing.Size(148, 40)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Location = New System.Drawing.Point(29, 19)
        Me.TxtApproveBy.Tag = ""
        '
        'CmdDiscard
        '
        Me.CmdDiscard.Size = New System.Drawing.Size(26, 19)
        '
        'CmdApprove
        '
        Me.CmdApprove.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(145, 465)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(11, 465)
        Me.GrpUP.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 461)
        Me.GroupBox1.Size = New System.Drawing.Size(895, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(287, 465)
        Me.GBoxDivision.Size = New System.Drawing.Size(114, 40)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Location = New System.Drawing.Point(3, 19)
        Me.TxtDivision.Tag = ""
        '
        'TxtDocId
        '
        Me.TxtDocId.AgSelectedValue = ""
        Me.TxtDocId.BackColor = System.Drawing.Color.White
        Me.TxtDocId.Tag = ""
        Me.TxtDocId.Text = ""
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(477, 38)
        Me.LblV_No.Size = New System.Drawing.Size(88, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Quotation No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(597, 38)
        Me.TxtV_No.Size = New System.Drawing.Size(135, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(306, 45)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(168, 40)
        Me.LblV_Date.Size = New System.Drawing.Size(95, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Quotation Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(581, 24)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(322, 38)
        Me.TxtV_Date.Size = New System.Drawing.Size(135, 18)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(477, 21)
        Me.LblV_Type.Size = New System.Drawing.Size(96, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Quotation Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(597, 19)
        Me.TxtV_Type.Size = New System.Drawing.Size(135, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(306, 25)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(168, 21)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(322, 19)
        Me.TxtSite_Code.Size = New System.Drawing.Size(135, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(20, 35)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-2, 20)
        Me.TabControl1.Size = New System.Drawing.Size(880, 184)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.LblBuyerQuoteDate)
        Me.TP1.Controls.Add(Me.TxtBuyerQuoteDate)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.txtByerQuotationNo)
        Me.TP1.Controls.Add(Me.LblByerQuotationNo)
        Me.TP1.Controls.Add(Me.LblBuyer)
        Me.TP1.Controls.Add(Me.LblBuyerReq)
        Me.TP1.Controls.Add(Me.TxtBuyer)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(872, 158)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBuyer, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblBuyerReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblBuyer, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblByerQuotationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.txtByerQuotationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBuyerQuoteDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblBuyerQuoteDate, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(877, 41)
        Me.Topctrl1.TabIndex = 2
        '
        'Dgl1
        '
        Me.Dgl1.AgMandatoryColumn = 0
        Me.Dgl1.AgReadOnlyColumnColor = System.Drawing.Color.Ivory
        Me.Dgl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Dgl1.CancelEditingControlValidating = False
        Me.Dgl1.Location = New System.Drawing.Point(0, 0)
        Me.Dgl1.Name = "Dgl1"
        Me.Dgl1.Size = New System.Drawing.Size(240, 150)
        Me.Dgl1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalAmountValue)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Location = New System.Drawing.Point(4, 438)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(872, 21)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalAmountValue
        '
        Me.LblTotalAmountValue.AutoSize = True
        Me.LblTotalAmountValue.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmountValue.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalAmountValue.Location = New System.Drawing.Point(769, 3)
        Me.LblTotalAmountValue.Name = "LblTotalAmountValue"
        Me.LblTotalAmountValue.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalAmountValue.TabIndex = 672
        Me.LblTotalAmountValue.Text = "."
        Me.LblTotalAmountValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.AutoSize = True
        Me.LblTotalAmountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmountText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalAmountText.Location = New System.Drawing.Point(658, 3)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(101, 16)
        Me.LblTotalAmountText.TabIndex = 671
        Me.LblTotalAmountText.Text = "Total Amount :"
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalQty.Location = New System.Drawing.Point(531, 3)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 668
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.AutoSize = True
        Me.LblTotalQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQtyText.Location = New System.Drawing.Point(446, 3)
        Me.LblTotalQtyText.Name = "LblTotalQtyText"
        Me.LblTotalQtyText.Size = New System.Drawing.Size(73, 16)
        Me.LblTotalQtyText.TabIndex = 667
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(4, 227)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(872, 211)
        Me.Pnl1.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(168, 116)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgMandatory = False
        Me.TxtRemarks.AgMasterHelp = False
        Me.TxtRemarks.AgNumberLeftPlaces = 0
        Me.TxtRemarks.AgNumberNegetiveAllow = False
        Me.TxtRemarks.AgNumberRightPlaces = 0
        Me.TxtRemarks.AgPickFromLastValue = False
        Me.TxtRemarks.AgRowFilter = ""
        Me.TxtRemarks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemarks.AgSelectedValue = Nothing
        Me.TxtRemarks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemarks.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemarks.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemarks.Location = New System.Drawing.Point(322, 114)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(410, 18)
        Me.TxtRemarks.TabIndex = 8
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 205)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(159, 20)
        Me.LinkLabel1.TabIndex = 731
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Quotation Following Items"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblBuyerReq
        '
        Me.LblBuyerReq.AutoSize = True
        Me.LblBuyerReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBuyerReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBuyerReq.Location = New System.Drawing.Point(306, 84)
        Me.LblBuyerReq.Name = "LblBuyerReq"
        Me.LblBuyerReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBuyerReq.TabIndex = 732
        Me.LblBuyerReq.Text = "Ä"
        '
        'TxtBuyer
        '
        Me.TxtBuyer.AgMandatory = True
        Me.TxtBuyer.AgMasterHelp = False
        Me.TxtBuyer.AgNumberLeftPlaces = 8
        Me.TxtBuyer.AgNumberNegetiveAllow = False
        Me.TxtBuyer.AgNumberRightPlaces = 2
        Me.TxtBuyer.AgPickFromLastValue = False
        Me.TxtBuyer.AgRowFilter = ""
        Me.TxtBuyer.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyer.AgSelectedValue = Nothing
        Me.TxtBuyer.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyer.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuyer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyer.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyer.Location = New System.Drawing.Point(322, 76)
        Me.TxtBuyer.MaxLength = 20
        Me.TxtBuyer.Name = "TxtBuyer"
        Me.TxtBuyer.Size = New System.Drawing.Size(410, 18)
        Me.TxtBuyer.TabIndex = 5
        '
        'LblBuyer
        '
        Me.LblBuyer.AutoSize = True
        Me.LblBuyer.BackColor = System.Drawing.Color.Transparent
        Me.LblBuyer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyer.Location = New System.Drawing.Point(168, 78)
        Me.LblBuyer.Name = "LblBuyer"
        Me.LblBuyer.Size = New System.Drawing.Size(46, 16)
        Me.LblBuyer.TabIndex = 731
        Me.LblBuyer.Text = "Buyer "
        '
        'txtByerQuotationNo
        '
        Me.txtByerQuotationNo.AgMandatory = False
        Me.txtByerQuotationNo.AgMasterHelp = False
        Me.txtByerQuotationNo.AgNumberLeftPlaces = 8
        Me.txtByerQuotationNo.AgNumberNegetiveAllow = False
        Me.txtByerQuotationNo.AgNumberRightPlaces = 2
        Me.txtByerQuotationNo.AgPickFromLastValue = False
        Me.txtByerQuotationNo.AgRowFilter = ""
        Me.txtByerQuotationNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.txtByerQuotationNo.AgSelectedValue = Nothing
        Me.txtByerQuotationNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.txtByerQuotationNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.txtByerQuotationNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtByerQuotationNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtByerQuotationNo.Location = New System.Drawing.Point(322, 95)
        Me.txtByerQuotationNo.MaxLength = 20
        Me.txtByerQuotationNo.Name = "txtByerQuotationNo"
        Me.txtByerQuotationNo.Size = New System.Drawing.Size(135, 18)
        Me.txtByerQuotationNo.TabIndex = 6
        '
        'LblByerQuotationNo
        '
        Me.LblByerQuotationNo.AutoSize = True
        Me.LblByerQuotationNo.BackColor = System.Drawing.Color.Transparent
        Me.LblByerQuotationNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblByerQuotationNo.Location = New System.Drawing.Point(168, 97)
        Me.LblByerQuotationNo.Name = "LblByerQuotationNo"
        Me.LblByerQuotationNo.Size = New System.Drawing.Size(119, 16)
        Me.LblByerQuotationNo.TabIndex = 734
        Me.LblByerQuotationNo.Text = "Byer Quotation No."
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.AgMandatory = False
        Me.TxtReferenceNo.AgMasterHelp = True
        Me.TxtReferenceNo.AgNumberLeftPlaces = 8
        Me.TxtReferenceNo.AgNumberNegetiveAllow = False
        Me.TxtReferenceNo.AgNumberRightPlaces = 2
        Me.TxtReferenceNo.AgPickFromLastValue = False
        Me.TxtReferenceNo.AgRowFilter = ""
        Me.TxtReferenceNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtReferenceNo.AgSelectedValue = Nothing
        Me.TxtReferenceNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtReferenceNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtReferenceNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReferenceNo.Location = New System.Drawing.Point(322, 57)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(410, 18)
        Me.TxtReferenceNo.TabIndex = 4
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(168, 59)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(86, 16)
        Me.LblReferenceNo.TabIndex = 740
        Me.LblReferenceNo.Text = "Reference No"
        '
        'LblBuyerQuoteDate
        '
        Me.LblBuyerQuoteDate.AutoSize = True
        Me.LblBuyerQuoteDate.BackColor = System.Drawing.Color.Transparent
        Me.LblBuyerQuoteDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyerQuoteDate.Location = New System.Drawing.Point(477, 95)
        Me.LblBuyerQuoteDate.Name = "LblBuyerQuoteDate"
        Me.LblBuyerQuoteDate.Size = New System.Drawing.Size(109, 16)
        Me.LblBuyerQuoteDate.TabIndex = 745
        Me.LblBuyerQuoteDate.Text = "Buyer Quot. Date"
        '
        'TxtBuyerQuoteDate
        '
        Me.TxtBuyerQuoteDate.AgMandatory = False
        Me.TxtBuyerQuoteDate.AgMasterHelp = False
        Me.TxtBuyerQuoteDate.AgNumberLeftPlaces = 8
        Me.TxtBuyerQuoteDate.AgNumberNegetiveAllow = False
        Me.TxtBuyerQuoteDate.AgNumberRightPlaces = 2
        Me.TxtBuyerQuoteDate.AgPickFromLastValue = False
        Me.TxtBuyerQuoteDate.AgRowFilter = ""
        Me.TxtBuyerQuoteDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuyerQuoteDate.AgSelectedValue = Nothing
        Me.TxtBuyerQuoteDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuyerQuoteDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtBuyerQuoteDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBuyerQuoteDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuyerQuoteDate.Location = New System.Drawing.Point(597, 95)
        Me.TxtBuyerQuoteDate.MaxLength = 20
        Me.TxtBuyerQuoteDate.Name = "TxtBuyerQuoteDate"
        Me.TxtBuyerQuoteDate.Size = New System.Drawing.Size(135, 18)
        Me.TxtBuyerQuoteDate.TabIndex = 7
        '
        'FrmSaleQuotation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(877, 506)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "FrmSaleQuotation"
        Me.Text = "Template Sale Order"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents LblBuyerReq As System.Windows.Forms.Label
    Protected WithEvents TxtBuyer As AgControls.AgTextBox
    Protected WithEvents LblBuyer As System.Windows.Forms.Label
#End Region

    Private Sub TempRequisition_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Lib_SaleQuot"
        LogTableName = "Lib_SaleQuot_Log"
        MainLineTableCsv = "Lib_SaleQuotDetail"
        LogLineTableCsv = "Lib_SaleQuotDetail_Log"
        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmTempRequisition_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
               " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select R.DocID As SearchCode " & _
            " From Lib_SaleQuot R " & _
            " Left Join Voucher_Type Vt On R.V_Type = Vt.V_Type  " & _
            " Where IsNull(R.IsDeleted,0) = 0  " & mCondStr & "  Order By R.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmTempRequisition_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = "Select R.UID As SearchCode " & _
               " From Lib_SaleQuot_Log R " & _
               " Left Join Voucher_Type Vt On R.V_Type = Vt.V_Type  " & _
               " Where R.EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By R.EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT R.DocID AS SearchCode, Vt.Description AS [Entry Type], R.V_Date AS [Entry Date], " & _
                            " R.V_No AS [Entry No], R.ReferenceNo AS [Reference No], SG.DispName AS [Buyer Name], " & _
                            " R.BuyerDocNo AS [Buyer Quot. No.],R.BuyerDocDate AS [Buyer Quot. Date], Remarks  " & _
                            " FROM Lib_SaleQuot R " & _
                            " LEFT JOIN Voucher_type Vt ON R.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup SG ON SG.SubCode = R.Buyer " & _
                            " Where 1=1 " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT R.UID AS SearchCode, Vt.Description AS [Entry Type], R.V_Date AS [Entry Date], " & _
                            " R.V_No AS [Entry No], R.ReferenceNo AS [Reference No], SG.DispName AS [Buyer Name], " & _
                            " R.BuyerDocNo AS [Buyer Quot. No.],R.BuyerDocDate AS [Buyer Quot. Date], Remarks  " & _
                            " FROM Lib_SaleQuot_Log R " & _
                            " LEFT JOIN Voucher_type Vt ON R.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup SG ON SG.SubCode = R.Buyer " & _
                            " Where R.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid

        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 35, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1ScrapCategory, 250, 0, Col1ScrapCategory, True, False)
            .AddAgNumberColumn(Dgl1, Col1Qty, 100, 8, 3, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 100, 0, Col1Unit, True, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 100, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, True, True, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35
        'Dgl1.Anchor = AnchorStyles.None
        'Panel1.Anchor = Dgl1.Anchor
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = " UPDATE Lib_SaleQuot_Log " & _
                " SET	ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " Buyer = " & AgL.Chk_Text(TxtBuyer.AgSelectedValue) & ", " & _
                " BuyerDocNo = " & AgL.Chk_Text(txtByerQuotationNo.Text) & ", " & _
                " BuyerDocDate = " & AgL.ConvertDate(TxtBuyerQuoteDate.Text) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & " , " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " TotalAmount = " & Val(LblTotalAmountValue.Text) & " " & _
                " WHERE 	UID =  '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Lib_SaleQuotDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1ScrapCategory, I).Value <> "" Then
                    mSr += 1
                    mQry = " INSERT INTO Lib_SaleQuotDetail_Log	(DocId,	Sr,	ScrapCategory,	Qty, " & _
                            " Unit,	Rate,	Amount,	UID	) " & _
                            " VALUES (	" & AgL.Chk_Text(mInternalCode) & "," & mSr & "," & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1ScrapCategory, I)) & ", " & _
                            " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ",	" & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                            " " & Val(Dgl1.Item(Col1Amount, I).Value) & "," & AgL.Chk_Text(SearchCode) & ")"

                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select R.* " & _
                " From Lib_SaleQuot R " & _
                " Where R.DocID = '" & SearchCode & "'"
        Else
            mQry = "Select R.* " & _
                " From Lib_SaleQuot_Log R " & _
                " Where R.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtBuyer.AgSelectedValue = AgL.XNull(.Rows(0)("Buyer"))
                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                txtByerQuotationNo.Text = AgL.XNull(.Rows(0)("BuyerDocNo"))
                TxtBuyerQuoteDate.Text = AgL.XNull(.Rows(0)("BuyerDocDate"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                LblTotalQty.Text = Format(AgL.VNull(.Rows(0)("TotalQty")), "0.000")
                LblTotalAmountValue.Text = Format(AgL.VNull(.Rows(0)("TotalAmount")), "0.00")

                '-------------------------------------------------------------
                'Line Records are showing in First Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * Lib_SaleQuotDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from Lib_SaleQuotDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1ScrapCategory, I) = AgL.XNull(.Rows(I)("ScrapCategory"))
                            Dgl1.Item(Col1Qty, I).Value = Format(AgL.VNull(.Rows(I)("Qty")), "0.000")
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        Next I
                    End If
                End With
                Calculation()
                '-------------------------------------------------------------
            End If
        End With
    End Sub

    Private Sub FrmTempRequisition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgL.WinSetting(Me, 540, 885)
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select V.SubCode As Code, Sg.DispName As Buyer,SG.Div_Code, " & _
                        " IsNull(Sg.IsDeleted,0) As IsDeleted, IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) As Status " & _
                        " From Buyer V " & _
                        " LEFT JOIN SubGroup Sg On V.SubCode = Sg.SubCode " & _
                        " LEFT JOIN City C On Sg.CityCode = C.CityCode " & _
                        " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
        TxtBuyer.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT I.Code, I.Description AS [Scrap Category] ,I.Unit, " & _
                " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status" & _
                " FROM Lib_ScrapCategory I" & _
                " LEFT JOIN Lib_Book B ON B.Code=I.Code " & _
                " Where " & AgL.PubSiteCondition("I.Site_Code", AgL.PubSiteCode) & " "
        Dgl1.AgHelpDataSet(Col1ScrapCategory, 4) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1ScrapCategory
                Dgl1.AgRowFilter(Dgl1.Columns(Col1ScrapCategory).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "

        End Select
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0 : LblTotalAmountValue.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1ScrapCategory, I).Value <> "" Then

                Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.00")
                'Footer(Calculation)
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalAmountValue.Text = Val(LblTotalAmountValue.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
            End If
        Next
        LblTotalAmountValue.Text = Format(Val(LblTotalAmountValue.Text), "0.00")
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")
    End Sub
    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub
    Private Sub FrmTempRequisition_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0

        If AgL.RequiredField(TxtBuyer, LblBuyer.Text) Then passed = False : Exit Sub

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1ScrapCategory).Index) Then passed = False : Exit Sub
        If AgCL.AgIsDuplicate(Dgl1, Dgl1.Columns(Col1ScrapCategory).Index) Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1ScrapCategory, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With

    End Sub

    Private Sub FrmTempRequisition_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        LblTotalAmountValue.Text = 0 : LblTotalQty.Text = 0
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtBuyer.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtBuyer.Name

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtBuyer.Enter
        Try
            Select Case sender.name
                Case TxtBuyer.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND " & ClsMain.RetDivFilterStr & ""

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1ScrapCategory
                    Validating_Item(Dgl1.AgSelectedValue(Col1ScrapCategory, mRowIndex), mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Try
            If Dgl1.Item(Col1ScrapCategory, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1ScrapCategory, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Unit, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1ScrapCategory) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1ScrapCategory).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

End Class
