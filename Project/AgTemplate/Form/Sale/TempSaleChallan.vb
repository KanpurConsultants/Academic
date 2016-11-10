Imports CrystalDecisions.CrystalReports.Engine
Public Class TempSaleChallan
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Dim DsMain As DataSet

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    'Dim mLastKeyPressed As Keys
    Public WithEvents AgCShowGrid1 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCShowGrid2 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid

    Public WithEvents Dgl1 As AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Item As String = "Item"
    Protected Const Col1SalesTaxGroup As String = "Sales Tax Group Item"
    Protected Const Col1DocQty As String = "Doc Qty"
    Protected Const Col1RejQty As String = "Rejected Qty"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1MeasureUnit As String = "Measure Unit"
    Protected Const Col1TotalDocMeasure As String = "Total Doc Measure"
    Protected Const Col1TotalRejMeasure As String = "Total Rej Measure"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1InvoicedQty As String = "Invoiced Qty"
    Protected Const Col1InvoicedMeasure As String = "Invoiced Measure"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1SaleOrder As String = "Sale Order"
    Protected Const Col1DeliveryOrder As String = "Delivery Order"
    Protected Const Col1LotNo As String = "Lot No"

    Public Class HelpDataSet
        Public Shared Buyer As DataSet = Nothing
        Public Shared Vendor As DataSet = Nothing
        Public Shared City As DataSet = Nothing
        Public Shared Port As DataSet = Nothing
        Public Shared Currency As DataSet = Nothing
        Public Shared AgStructure As DataSet = Nothing
        Public Shared SalesTaxGroupParty As DataSet = Nothing
        Public Shared BillingType As DataSet = Nothing
        Public Shared SaleOrder As DataSet = Nothing
        Public Shared Godown As DataSet = Nothing
        Public Shared Form As DataSet = Nothing
        Public Shared Transporter As DataSet = Nothing
        Public Shared FormNo As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared SaleOrderItem As DataSet = Nothing
        Public Shared GateEntry As DataSet = Nothing
    End Class

    Dim mIsPostStock As Boolean = True

    Protected Property IsPostStock() As Boolean
        Get
            IsPostStock = mIsPostStock
        End Get
        Set(ByVal value As Boolean)
            mIsPostStock = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtSaleToParty = New AgControls.AgTextBox
        Me.LblParty = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalMeasure = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtSalesTaxGroupParty = New AgControls.AgTextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtBillingType = New AgControls.AgTextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LblTransport = New System.Windows.Forms.Label
        Me.TxtTransport = New AgControls.AgTextBox
        Me.LblCurrency = New System.Windows.Forms.Label
        Me.TxtCurrency = New AgControls.AgTextBox
        Me.TxtGodown = New AgControls.AgTextBox
        Me.LblGodown = New System.Windows.Forms.Label
        Me.LblOrderNo = New System.Windows.Forms.Label
        Me.TxtSaleOrderNo = New AgControls.AgTextBox
        Me.BtnFill = New System.Windows.Forms.Button
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtGateEntryNo = New AgControls.AgTextBox
        Me.LblGateEntryNo = New System.Windows.Forms.Label
        Me.TxtTruckNo = New AgControls.AgTextBox
        Me.LblTruckNo = New System.Windows.Forms.Label
        Me.TxtForm = New AgControls.AgTextBox
        Me.LblForm = New System.Windows.Forms.Label
        Me.TxtFormNo = New AgControls.AgTextBox
        Me.LblFormNo = New System.Windows.Forms.Label
        Me.TxtTransporter = New AgControls.AgTextBox
        Me.LblTransporter = New System.Windows.Forms.Label
        Me.BtnRemoveFilter = New System.Windows.Forms.Button
        Me.PnlCShowGrid1 = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtLrNo = New AgControls.AgTextBox
        Me.LblLrNo = New System.Windows.Forms.Label
        Me.TxtLrDate = New AgControls.AgTextBox
        Me.LblLrDate = New System.Windows.Forms.Label
        Me.RbtChallanDirect = New System.Windows.Forms.RadioButton
        Me.RbtChallanForOrder = New System.Windows.Forms.RadioButton
        Me.TxtSaleToPartyAddress = New AgControls.AgTextBox
        Me.LblAddress = New System.Windows.Forms.Label
        Me.TxtSaleToPartyCity = New AgControls.AgTextBox
        Me.LblCity = New System.Windows.Forms.Label
        Me.TxtSaleToPartyMobile = New AgControls.AgTextBox
        Me.LblMobile = New System.Windows.Forms.Label
        Me.TxtDriverMobile = New AgControls.AgTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtDriverName = New AgControls.AgTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtShipToPartyMobile = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtShipToPartyCity = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtShipToPartyAddress = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtShipToPartyName = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtDeliveryNo = New AgControls.AgTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtVendorName = New AgControls.AgTextBox
        Me.LblVendor = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtPrivateMarka = New AgControls.AgTextBox
        Me.TxtPortofLoading = New AgControls.AgTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtDestinationPort = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtShipmentThrough = New AgControls.AgTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtFinalPlaceofDelivery = New AgControls.AgTextBox
        Me.TxtPlaceOfPreCarriage = New AgControls.AgTextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtPreCarriageBy = New AgControls.AgTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
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
        Me.GroupBox2.Location = New System.Drawing.Point(829, 577)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(648, 577)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(453, 577)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(168, 577)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 577)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 573)
        Me.GroupBox1.Size = New System.Drawing.Size(1032, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(316, 577)
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
        Me.LblV_No.Location = New System.Drawing.Point(235, 32)
        Me.LblV_No.Size = New System.Drawing.Size(76, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Receipt No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(362, 31)
        Me.TxtV_No.Size = New System.Drawing.Size(144, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(113, 37)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(16, 32)
        Me.LblV_Date.Size = New System.Drawing.Size(83, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Receipt Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(313, 17)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(129, 31)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(235, 13)
        Me.LblV_Type.Size = New System.Drawing.Size(84, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Receipt Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(362, 11)
        Me.TxtV_Type.Size = New System.Drawing.Size(144, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(113, 17)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(16, 12)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(129, 11)
        Me.TxtSite_Code.Size = New System.Drawing.Size(100, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(300, 32)
        Me.LblPrefix.Tag = ""
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-3, 18)
        Me.TabControl1.Size = New System.Drawing.Size(1020, 181)
        Me.TabControl1.TabIndex = 1
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtPreCarriageBy)
        Me.TP1.Controls.Add(Me.Label16)
        Me.TP1.Controls.Add(Me.TxtPlaceOfPreCarriage)
        Me.TP1.Controls.Add(Me.Label15)
        Me.TP1.Controls.Add(Me.TxtShipmentThrough)
        Me.TP1.Controls.Add(Me.Label13)
        Me.TP1.Controls.Add(Me.TxtDestinationPort)
        Me.TP1.Controls.Add(Me.Label12)
        Me.TP1.Controls.Add(Me.TxtPortofLoading)
        Me.TP1.Controls.Add(Me.Label11)
        Me.TP1.Controls.Add(Me.TxtVendorName)
        Me.TP1.Controls.Add(Me.LblVendor)
        Me.TP1.Controls.Add(Me.TxtShipToPartyMobile)
        Me.TP1.Controls.Add(Me.TxtShipToPartyCity)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.TxtShipToPartyAddress)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Controls.Add(Me.TxtShipToPartyName)
        Me.TP1.Controls.Add(Me.Label7)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyMobile)
        Me.TP1.Controls.Add(Me.LblMobile)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyCity)
        Me.TP1.Controls.Add(Me.LblCity)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyAddress)
        Me.TP1.Controls.Add(Me.LblAddress)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtGodown)
        Me.TP1.Controls.Add(Me.LblGodown)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.TxtBillingType)
        Me.TP1.Controls.Add(Me.Label32)
        Me.TP1.Controls.Add(Me.TxtSaleOrderNo)
        Me.TP1.Controls.Add(Me.LblOrderNo)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.TxtSaleToParty)
        Me.TP1.Controls.Add(Me.LblParty)
        Me.TP1.Controls.Add(Me.TxtCurrency)
        Me.TP1.Controls.Add(Me.LblCurrency)
        Me.TP1.Controls.Add(Me.BtnFill)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(1012, 155)
        Me.TP1.Text = "Document Detail"
        Me.TP1.UseVisualStyleBackColor = True
        Me.TP1.Controls.SetChildIndex(Me.BtnFill, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label32, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBillingType, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAddress, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyAddress, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCity, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyCity, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMobile, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyMobile, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label7, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtShipToPartyName, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label5, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtShipToPartyAddress, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label3, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtShipToPartyCity, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtShipToPartyMobile, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorName, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label11, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPortofLoading, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label12, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDestinationPort, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label13, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtShipmentThrough, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label15, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPlaceOfPreCarriage, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label16, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPreCarriageBy, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(1014, 41)
        Me.Topctrl1.TabIndex = 18
        '
        'Dgl1
        '
        Me.Dgl1.AgLastColumn = -1
        Me.Dgl1.AgMandatoryColumn = 0
        Me.Dgl1.AgReadOnlyColumnColor = System.Drawing.Color.Ivory
        Me.Dgl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Dgl1.AgSkipReadOnlyColumns = False
        Me.Dgl1.CancelEditingControlValidating = False
        Me.Dgl1.Location = New System.Drawing.Point(0, 0)
        Me.Dgl1.Name = "Dgl1"
        Me.Dgl1.Size = New System.Drawing.Size(240, 150)
        Me.Dgl1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(113, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 694
        Me.Label4.Text = "Ä"
        '
        'TxtSaleToParty
        '
        Me.TxtSaleToParty.AgMandatory = True
        Me.TxtSaleToParty.AgMasterHelp = False
        Me.TxtSaleToParty.AgNumberLeftPlaces = 8
        Me.TxtSaleToParty.AgNumberNegetiveAllow = False
        Me.TxtSaleToParty.AgNumberRightPlaces = 2
        Me.TxtSaleToParty.AgPickFromLastValue = False
        Me.TxtSaleToParty.AgRowFilter = ""
        Me.TxtSaleToParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToParty.AgSelectedValue = Nothing
        Me.TxtSaleToParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToParty.Location = New System.Drawing.Point(129, 51)
        Me.TxtSaleToParty.MaxLength = 0
        Me.TxtSaleToParty.Name = "TxtSaleToParty"
        Me.TxtSaleToParty.Size = New System.Drawing.Size(377, 18)
        Me.TxtSaleToParty.TabIndex = 4
        Me.TxtSaleToParty.Text = "TxtPartyName"
        '
        'LblParty
        '
        Me.LblParty.AutoSize = True
        Me.LblParty.BackColor = System.Drawing.Color.Transparent
        Me.LblParty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblParty.Location = New System.Drawing.Point(16, 52)
        Me.LblParty.Name = "LblParty"
        Me.LblParty.Size = New System.Drawing.Size(42, 16)
        Me.LblParty.TabIndex = 693
        Me.LblParty.Text = "Buyer"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalMeasure)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Location = New System.Drawing.Point(4, 401)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.AutoSize = True
        Me.LblTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalMeasure.Location = New System.Drawing.Point(865, 3)
        Me.LblTotalMeasure.Name = "LblTotalMeasure"
        Me.LblTotalMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalMeasure.TabIndex = 666
        Me.LblTotalMeasure.Text = "."
        Me.LblTotalMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblTotalMeasure.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(754, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(106, 16)
        Me.Label33.TabIndex = 665
        Me.Label33.Text = "Total Measure :"
        Me.Label33.Visible = False
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalQty.Location = New System.Drawing.Point(97, 3)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 660
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.AutoSize = True
        Me.LblTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalAmount.Location = New System.Drawing.Point(465, 4)
        Me.LblTotalAmount.Name = "LblTotalAmount"
        Me.LblTotalAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalAmount.TabIndex = 662
        Me.LblTotalAmount.Text = "."
        Me.LblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.AutoSize = True
        Me.LblTotalQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQtyText.Location = New System.Drawing.Point(12, 3)
        Me.LblTotalQtyText.Name = "LblTotalQtyText"
        Me.LblTotalQtyText.Size = New System.Drawing.Size(73, 16)
        Me.LblTotalQtyText.TabIndex = 659
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.AutoSize = True
        Me.LblTotalAmountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmountText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalAmountText.Location = New System.Drawing.Point(361, 3)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(101, 16)
        Me.LblTotalAmountText.TabIndex = 661
        Me.LblTotalAmountText.Text = "Total Amount :"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(5, 228)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(1000, 170)
        Me.Pnl1.TabIndex = 2
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnlCalcGrid.Location = New System.Drawing.Point(612, 591)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(119, 23)
        Me.PnlCalcGrid.TabIndex = 694
        '
        'TxtStructure
        '
        Me.TxtStructure.AgMandatory = False
        Me.TxtStructure.AgMasterHelp = False
        Me.TxtStructure.AgNumberLeftPlaces = 8
        Me.TxtStructure.AgNumberNegetiveAllow = False
        Me.TxtStructure.AgNumberRightPlaces = 2
        Me.TxtStructure.AgPickFromLastValue = False
        Me.TxtStructure.AgRowFilter = ""
        Me.TxtStructure.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStructure.AgSelectedValue = Nothing
        Me.TxtStructure.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStructure.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStructure.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStructure.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStructure.Location = New System.Drawing.Point(562, 552)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(83, 18)
        Me.TxtStructure.TabIndex = 14
        Me.TxtStructure.Text = "TxtStructure"
        Me.TxtStructure.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(494, 554)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 715
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.AgMandatory = False
        Me.TxtSalesTaxGroupParty.AgMasterHelp = False
        Me.TxtSalesTaxGroupParty.AgNumberLeftPlaces = 8
        Me.TxtSalesTaxGroupParty.AgNumberNegetiveAllow = False
        Me.TxtSalesTaxGroupParty.AgNumberRightPlaces = 2
        Me.TxtSalesTaxGroupParty.AgPickFromLastValue = False
        Me.TxtSalesTaxGroupParty.AgRowFilter = ""
        Me.TxtSalesTaxGroupParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSalesTaxGroupParty.AgSelectedValue = Nothing
        Me.TxtSalesTaxGroupParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSalesTaxGroupParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSalesTaxGroupParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSalesTaxGroupParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(121, 530)
        Me.TxtSalesTaxGroupParty.MaxLength = 20
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(127, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 13
        Me.TxtSalesTaxGroupParty.Text = "TxtSalesTaxGroupParty"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(7, 530)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(105, 16)
        Me.Label27.TabIndex = 717
        Me.Label27.Text = "Sales Tax Group"
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
        Me.TxtRemarks.Location = New System.Drawing.Point(462, 451)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Multiline = True
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(200, 95)
        Me.TxtRemarks.TabIndex = 17
        Me.TxtRemarks.Text = "TxtRemarks"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(458, 430)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
        '
        'TxtBillingType
        '
        Me.TxtBillingType.AgMandatory = False
        Me.TxtBillingType.AgMasterHelp = False
        Me.TxtBillingType.AgNumberLeftPlaces = 0
        Me.TxtBillingType.AgNumberNegetiveAllow = False
        Me.TxtBillingType.AgNumberRightPlaces = 0
        Me.TxtBillingType.AgPickFromLastValue = False
        Me.TxtBillingType.AgRowFilter = ""
        Me.TxtBillingType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBillingType.AgSelectedValue = Nothing
        Me.TxtBillingType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBillingType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBillingType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBillingType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBillingType.Location = New System.Drawing.Point(888, 132)
        Me.TxtBillingType.MaxLength = 20
        Me.TxtBillingType.Name = "TxtBillingType"
        Me.TxtBillingType.Size = New System.Drawing.Size(90, 18)
        Me.TxtBillingType.TabIndex = 21
        Me.TxtBillingType.Text = "TxtBillingType"
        Me.TxtBillingType.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(783, 133)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(64, 16)
        Me.Label32.TabIndex = 727
        Me.Label32.Text = "Billing On"
        Me.Label32.Visible = False
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.AgMandatory = True
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(129, 111)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(112, 18)
        Me.TxtReferenceNo.TabIndex = 8
        Me.TxtReferenceNo.Text = "TxtReferenceNo"
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(16, 112)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(74, 16)
        Me.LblReferenceNo.TabIndex = 731
        Me.LblReferenceNo.Text = "Manual No."
        '
        'LblTransport
        '
        Me.LblTransport.AutoSize = True
        Me.LblTransport.BackColor = System.Drawing.Color.Transparent
        Me.LblTransport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTransport.Location = New System.Drawing.Point(254, 510)
        Me.LblTransport.Name = "LblTransport"
        Me.LblTransport.Size = New System.Drawing.Size(62, 16)
        Me.LblTransport.TabIndex = 729
        Me.LblTransport.Text = "Transport"
        '
        'TxtTransport
        '
        Me.TxtTransport.AgMandatory = False
        Me.TxtTransport.AgMasterHelp = True
        Me.TxtTransport.AgNumberLeftPlaces = 8
        Me.TxtTransport.AgNumberNegetiveAllow = False
        Me.TxtTransport.AgNumberRightPlaces = 2
        Me.TxtTransport.AgPickFromLastValue = False
        Me.TxtTransport.AgRowFilter = ""
        Me.TxtTransport.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTransport.AgSelectedValue = Nothing
        Me.TxtTransport.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTransport.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTransport.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTransport.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransport.Location = New System.Drawing.Point(345, 510)
        Me.TxtTransport.MaxLength = 50
        Me.TxtTransport.Name = "TxtTransport"
        Me.TxtTransport.Size = New System.Drawing.Size(111, 18)
        Me.TxtTransport.TabIndex = 12
        Me.TxtTransport.Text = "TxtTransport"
        '
        'LblCurrency
        '
        Me.LblCurrency.AutoSize = True
        Me.LblCurrency.BackColor = System.Drawing.Color.Transparent
        Me.LblCurrency.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrency.Location = New System.Drawing.Point(783, 113)
        Me.LblCurrency.Name = "LblCurrency"
        Me.LblCurrency.Size = New System.Drawing.Size(60, 16)
        Me.LblCurrency.TabIndex = 735
        Me.LblCurrency.Text = "Currency"
        '
        'TxtCurrency
        '
        Me.TxtCurrency.AgMandatory = False
        Me.TxtCurrency.AgMasterHelp = False
        Me.TxtCurrency.AgNumberLeftPlaces = 8
        Me.TxtCurrency.AgNumberNegetiveAllow = False
        Me.TxtCurrency.AgNumberRightPlaces = 2
        Me.TxtCurrency.AgPickFromLastValue = False
        Me.TxtCurrency.AgRowFilter = ""
        Me.TxtCurrency.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCurrency.AgSelectedValue = Nothing
        Me.TxtCurrency.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCurrency.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCurrency.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCurrency.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrency.Location = New System.Drawing.Point(887, 112)
        Me.TxtCurrency.MaxLength = 0
        Me.TxtCurrency.Name = "TxtCurrency"
        Me.TxtCurrency.Size = New System.Drawing.Size(91, 18)
        Me.TxtCurrency.TabIndex = 20
        Me.TxtCurrency.Text = "TxtCurrency"
        '
        'TxtGodown
        '
        Me.TxtGodown.AgMandatory = False
        Me.TxtGodown.AgMasterHelp = False
        Me.TxtGodown.AgNumberLeftPlaces = 8
        Me.TxtGodown.AgNumberNegetiveAllow = False
        Me.TxtGodown.AgNumberRightPlaces = 2
        Me.TxtGodown.AgPickFromLastValue = False
        Me.TxtGodown.AgRowFilter = ""
        Me.TxtGodown.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGodown.AgSelectedValue = Nothing
        Me.TxtGodown.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGodown.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGodown.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGodown.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGodown.Location = New System.Drawing.Point(630, 110)
        Me.TxtGodown.MaxLength = 0
        Me.TxtGodown.Name = "TxtGodown"
        Me.TxtGodown.Size = New System.Drawing.Size(147, 18)
        Me.TxtGodown.TabIndex = 19
        Me.TxtGodown.Text = "TxtGodown"
        '
        'LblGodown
        '
        Me.LblGodown.AutoSize = True
        Me.LblGodown.BackColor = System.Drawing.Color.Transparent
        Me.LblGodown.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGodown.Location = New System.Drawing.Point(513, 110)
        Me.LblGodown.Name = "LblGodown"
        Me.LblGodown.Size = New System.Drawing.Size(55, 16)
        Me.LblGodown.TabIndex = 737
        Me.LblGodown.Text = "Godown"
        '
        'LblOrderNo
        '
        Me.LblOrderNo.AutoSize = True
        Me.LblOrderNo.BackColor = System.Drawing.Color.Transparent
        Me.LblOrderNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrderNo.Location = New System.Drawing.Point(253, 112)
        Me.LblOrderNo.Name = "LblOrderNo"
        Me.LblOrderNo.Size = New System.Drawing.Size(64, 16)
        Me.LblOrderNo.TabIndex = 733
        Me.LblOrderNo.Text = "Order No."
        '
        'TxtSaleOrderNo
        '
        Me.TxtSaleOrderNo.AgMandatory = False
        Me.TxtSaleOrderNo.AgMasterHelp = False
        Me.TxtSaleOrderNo.AgNumberLeftPlaces = 8
        Me.TxtSaleOrderNo.AgNumberNegetiveAllow = False
        Me.TxtSaleOrderNo.AgNumberRightPlaces = 2
        Me.TxtSaleOrderNo.AgPickFromLastValue = False
        Me.TxtSaleOrderNo.AgRowFilter = ""
        Me.TxtSaleOrderNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleOrderNo.AgSelectedValue = Nothing
        Me.TxtSaleOrderNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleOrderNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleOrderNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleOrderNo.Location = New System.Drawing.Point(362, 111)
        Me.TxtSaleOrderNo.MaxLength = 0
        Me.TxtSaleOrderNo.Name = "TxtSaleOrderNo"
        Me.TxtSaleOrderNo.Size = New System.Drawing.Size(101, 18)
        Me.TxtSaleOrderNo.TabIndex = 9
        Me.TxtSaleOrderNo.Text = "TxtSaleOrderNo"
        '
        'BtnFill
        '
        Me.BtnFill.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(469, 111)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(37, 18)
        Me.BtnFill.TabIndex = 7
        Me.BtnFill.Text = "Fill"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 206)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(193, 20)
        Me.LinkLabel1.TabIndex = 738
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Sale Challan For Following Items"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtGateEntryNo
        '
        Me.TxtGateEntryNo.AgMandatory = False
        Me.TxtGateEntryNo.AgMasterHelp = True
        Me.TxtGateEntryNo.AgNumberLeftPlaces = 8
        Me.TxtGateEntryNo.AgNumberNegetiveAllow = False
        Me.TxtGateEntryNo.AgNumberRightPlaces = 2
        Me.TxtGateEntryNo.AgPickFromLastValue = False
        Me.TxtGateEntryNo.AgRowFilter = ""
        Me.TxtGateEntryNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGateEntryNo.AgSelectedValue = Nothing
        Me.TxtGateEntryNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGateEntryNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGateEntryNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGateEntryNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGateEntryNo.Location = New System.Drawing.Point(121, 430)
        Me.TxtGateEntryNo.MaxLength = 0
        Me.TxtGateEntryNo.Name = "TxtGateEntryNo"
        Me.TxtGateEntryNo.Size = New System.Drawing.Size(127, 18)
        Me.TxtGateEntryNo.TabIndex = 3
        Me.TxtGateEntryNo.Text = "TxtGateEntryNo"
        '
        'LblGateEntryNo
        '
        Me.LblGateEntryNo.AutoSize = True
        Me.LblGateEntryNo.BackColor = System.Drawing.Color.Transparent
        Me.LblGateEntryNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGateEntryNo.Location = New System.Drawing.Point(7, 431)
        Me.LblGateEntryNo.Name = "LblGateEntryNo"
        Me.LblGateEntryNo.Size = New System.Drawing.Size(95, 16)
        Me.LblGateEntryNo.TabIndex = 740
        Me.LblGateEntryNo.Text = "Gate Entry No."
        '
        'TxtTruckNo
        '
        Me.TxtTruckNo.AgMandatory = False
        Me.TxtTruckNo.AgMasterHelp = False
        Me.TxtTruckNo.AgNumberLeftPlaces = 8
        Me.TxtTruckNo.AgNumberNegetiveAllow = False
        Me.TxtTruckNo.AgNumberRightPlaces = 2
        Me.TxtTruckNo.AgPickFromLastValue = False
        Me.TxtTruckNo.AgRowFilter = ""
        Me.TxtTruckNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTruckNo.AgSelectedValue = Nothing
        Me.TxtTruckNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTruckNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTruckNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTruckNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTruckNo.Location = New System.Drawing.Point(345, 430)
        Me.TxtTruckNo.MaxLength = 50
        Me.TxtTruckNo.Name = "TxtTruckNo"
        Me.TxtTruckNo.Size = New System.Drawing.Size(111, 18)
        Me.TxtTruckNo.TabIndex = 4
        Me.TxtTruckNo.Text = "TxtTruckNo"
        '
        'LblTruckNo
        '
        Me.LblTruckNo.AutoSize = True
        Me.LblTruckNo.BackColor = System.Drawing.Color.Transparent
        Me.LblTruckNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTruckNo.Location = New System.Drawing.Point(253, 433)
        Me.LblTruckNo.Name = "LblTruckNo"
        Me.LblTruckNo.Size = New System.Drawing.Size(75, 16)
        Me.LblTruckNo.TabIndex = 742
        Me.LblTruckNo.Text = "Vehicle No."
        '
        'TxtForm
        '
        Me.TxtForm.AgMandatory = False
        Me.TxtForm.AgMasterHelp = False
        Me.TxtForm.AgNumberLeftPlaces = 8
        Me.TxtForm.AgNumberNegetiveAllow = False
        Me.TxtForm.AgNumberRightPlaces = 2
        Me.TxtForm.AgPickFromLastValue = False
        Me.TxtForm.AgRowFilter = ""
        Me.TxtForm.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForm.AgSelectedValue = Nothing
        Me.TxtForm.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForm.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtForm.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForm.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForm.Location = New System.Drawing.Point(121, 550)
        Me.TxtForm.MaxLength = 0
        Me.TxtForm.Name = "TxtForm"
        Me.TxtForm.Size = New System.Drawing.Size(127, 18)
        Me.TxtForm.TabIndex = 15
        Me.TxtForm.Text = "TxtForm"
        '
        'LblForm
        '
        Me.LblForm.AutoSize = True
        Me.LblForm.BackColor = System.Drawing.Color.Transparent
        Me.LblForm.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblForm.Location = New System.Drawing.Point(7, 552)
        Me.LblForm.Name = "LblForm"
        Me.LblForm.Size = New System.Drawing.Size(38, 16)
        Me.LblForm.TabIndex = 744
        Me.LblForm.Text = "Form"
        '
        'TxtFormNo
        '
        Me.TxtFormNo.AgMandatory = False
        Me.TxtFormNo.AgMasterHelp = True
        Me.TxtFormNo.AgNumberLeftPlaces = 8
        Me.TxtFormNo.AgNumberNegetiveAllow = False
        Me.TxtFormNo.AgNumberRightPlaces = 2
        Me.TxtFormNo.AgPickFromLastValue = False
        Me.TxtFormNo.AgRowFilter = ""
        Me.TxtFormNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFormNo.AgSelectedValue = Nothing
        Me.TxtFormNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFormNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFormNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFormNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFormNo.Location = New System.Drawing.Point(345, 550)
        Me.TxtFormNo.MaxLength = 30
        Me.TxtFormNo.Name = "TxtFormNo"
        Me.TxtFormNo.Size = New System.Drawing.Size(85, 18)
        Me.TxtFormNo.TabIndex = 16
        Me.TxtFormNo.Text = "TxtFormNo"
        '
        'LblFormNo
        '
        Me.LblFormNo.AutoSize = True
        Me.LblFormNo.BackColor = System.Drawing.Color.Transparent
        Me.LblFormNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFormNo.Location = New System.Drawing.Point(253, 552)
        Me.LblFormNo.Name = "LblFormNo"
        Me.LblFormNo.Size = New System.Drawing.Size(62, 16)
        Me.LblFormNo.TabIndex = 746
        Me.LblFormNo.Text = "Form No."
        '
        'TxtTransporter
        '
        Me.TxtTransporter.AgMandatory = False
        Me.TxtTransporter.AgMasterHelp = False
        Me.TxtTransporter.AgNumberLeftPlaces = 8
        Me.TxtTransporter.AgNumberNegetiveAllow = False
        Me.TxtTransporter.AgNumberRightPlaces = 2
        Me.TxtTransporter.AgPickFromLastValue = False
        Me.TxtTransporter.AgRowFilter = ""
        Me.TxtTransporter.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTransporter.AgSelectedValue = Nothing
        Me.TxtTransporter.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTransporter.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTransporter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTransporter.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransporter.Location = New System.Drawing.Point(121, 510)
        Me.TxtTransporter.MaxLength = 0
        Me.TxtTransporter.Name = "TxtTransporter"
        Me.TxtTransporter.Size = New System.Drawing.Size(128, 18)
        Me.TxtTransporter.TabIndex = 11
        Me.TxtTransporter.Text = "TxtTransporter"
        '
        'LblTransporter
        '
        Me.LblTransporter.AutoSize = True
        Me.LblTransporter.BackColor = System.Drawing.Color.Transparent
        Me.LblTransporter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTransporter.Location = New System.Drawing.Point(7, 510)
        Me.LblTransporter.Name = "LblTransporter"
        Me.LblTransporter.Size = New System.Drawing.Size(73, 16)
        Me.LblTransporter.TabIndex = 748
        Me.LblTransporter.Text = "Transporter"
        '
        'BtnRemoveFilter
        '
        Me.BtnRemoveFilter.BackColor = System.Drawing.Color.White
        Me.BtnRemoveFilter.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnRemoveFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRemoveFilter.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.BtnRemoveFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRemoveFilter.Location = New System.Drawing.Point(432, 549)
        Me.BtnRemoveFilter.Name = "BtnRemoveFilter"
        Me.BtnRemoveFilter.Size = New System.Drawing.Size(24, 21)
        Me.BtnRemoveFilter.TabIndex = 749
        Me.BtnRemoveFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRemoveFilter.UseVisualStyleBackColor = False
        '
        'PnlCShowGrid1
        '
        Me.PnlCShowGrid1.Location = New System.Drawing.Point(668, 430)
        Me.PnlCShowGrid1.Name = "PnlCShowGrid1"
        Me.PnlCShowGrid1.Size = New System.Drawing.Size(186, 140)
        Me.PnlCShowGrid1.TabIndex = 750
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(114, 118)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 738
        Me.LblReferenceNoReq.Text = "Ä"
        '
        'TxtLrNo
        '
        Me.TxtLrNo.AgMandatory = False
        Me.TxtLrNo.AgMasterHelp = True
        Me.TxtLrNo.AgNumberLeftPlaces = 8
        Me.TxtLrNo.AgNumberNegetiveAllow = False
        Me.TxtLrNo.AgNumberRightPlaces = 2
        Me.TxtLrNo.AgPickFromLastValue = False
        Me.TxtLrNo.AgRowFilter = ""
        Me.TxtLrNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLrNo.AgSelectedValue = Nothing
        Me.TxtLrNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLrNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtLrNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLrNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLrNo.Location = New System.Drawing.Point(121, 490)
        Me.TxtLrNo.MaxLength = 20
        Me.TxtLrNo.Name = "TxtLrNo"
        Me.TxtLrNo.Size = New System.Drawing.Size(127, 18)
        Me.TxtLrNo.TabIndex = 9
        Me.TxtLrNo.Text = "TxtLrNo"
        '
        'LblLrNo
        '
        Me.LblLrNo.AutoSize = True
        Me.LblLrNo.BackColor = System.Drawing.Color.Transparent
        Me.LblLrNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLrNo.Location = New System.Drawing.Point(7, 491)
        Me.LblLrNo.Name = "LblLrNo"
        Me.LblLrNo.Size = New System.Drawing.Size(60, 16)
        Me.LblLrNo.TabIndex = 753
        Me.LblLrNo.Text = "L. R. No."
        '
        'TxtLrDate
        '
        Me.TxtLrDate.AgMandatory = False
        Me.TxtLrDate.AgMasterHelp = True
        Me.TxtLrDate.AgNumberLeftPlaces = 8
        Me.TxtLrDate.AgNumberNegetiveAllow = False
        Me.TxtLrDate.AgNumberRightPlaces = 2
        Me.TxtLrDate.AgPickFromLastValue = False
        Me.TxtLrDate.AgRowFilter = ""
        Me.TxtLrDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLrDate.AgSelectedValue = Nothing
        Me.TxtLrDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLrDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtLrDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLrDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLrDate.Location = New System.Drawing.Point(345, 490)
        Me.TxtLrDate.MaxLength = 20
        Me.TxtLrDate.Name = "TxtLrDate"
        Me.TxtLrDate.Size = New System.Drawing.Size(111, 18)
        Me.TxtLrDate.TabIndex = 10
        Me.TxtLrDate.Text = "TxtLrDate"
        '
        'LblLrDate
        '
        Me.LblLrDate.AutoSize = True
        Me.LblLrDate.BackColor = System.Drawing.Color.Transparent
        Me.LblLrDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLrDate.Location = New System.Drawing.Point(253, 492)
        Me.LblLrDate.Name = "LblLrDate"
        Me.LblLrDate.Size = New System.Drawing.Size(67, 16)
        Me.LblLrDate.TabIndex = 755
        Me.LblLrDate.Text = "L. R. Date"
        '
        'RbtChallanDirect
        '
        Me.RbtChallanDirect.AutoSize = True
        Me.RbtChallanDirect.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtChallanDirect.Location = New System.Drawing.Point(336, 209)
        Me.RbtChallanDirect.Name = "RbtChallanDirect"
        Me.RbtChallanDirect.Size = New System.Drawing.Size(106, 17)
        Me.RbtChallanDirect.TabIndex = 743
        Me.RbtChallanDirect.TabStop = True
        Me.RbtChallanDirect.Text = "Challan Direct"
        Me.RbtChallanDirect.UseVisualStyleBackColor = True
        '
        'RbtChallanForOrder
        '
        Me.RbtChallanForOrder.AutoSize = True
        Me.RbtChallanForOrder.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtChallanForOrder.Location = New System.Drawing.Point(205, 209)
        Me.RbtChallanForOrder.Name = "RbtChallanForOrder"
        Me.RbtChallanForOrder.Size = New System.Drawing.Size(127, 17)
        Me.RbtChallanForOrder.TabIndex = 742
        Me.RbtChallanForOrder.TabStop = True
        Me.RbtChallanForOrder.Text = "Challan For Order"
        Me.RbtChallanForOrder.UseVisualStyleBackColor = True
        '
        'TxtSaleToPartyAddress
        '
        Me.TxtSaleToPartyAddress.AgMandatory = False
        Me.TxtSaleToPartyAddress.AgMasterHelp = True
        Me.TxtSaleToPartyAddress.AgNumberLeftPlaces = 8
        Me.TxtSaleToPartyAddress.AgNumberNegetiveAllow = False
        Me.TxtSaleToPartyAddress.AgNumberRightPlaces = 2
        Me.TxtSaleToPartyAddress.AgPickFromLastValue = False
        Me.TxtSaleToPartyAddress.AgRowFilter = ""
        Me.TxtSaleToPartyAddress.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToPartyAddress.AgSelectedValue = Nothing
        Me.TxtSaleToPartyAddress.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToPartyAddress.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToPartyAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToPartyAddress.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToPartyAddress.Location = New System.Drawing.Point(128, 71)
        Me.TxtSaleToPartyAddress.MaxLength = 0
        Me.TxtSaleToPartyAddress.Name = "TxtSaleToPartyAddress"
        Me.TxtSaleToPartyAddress.Size = New System.Drawing.Size(378, 18)
        Me.TxtSaleToPartyAddress.TabIndex = 5
        Me.TxtSaleToPartyAddress.Text = "TxtPartyAddress"
        '
        'LblAddress
        '
        Me.LblAddress.AutoSize = True
        Me.LblAddress.BackColor = System.Drawing.Color.Transparent
        Me.LblAddress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAddress.Location = New System.Drawing.Point(18, 71)
        Me.LblAddress.Name = "LblAddress"
        Me.LblAddress.Size = New System.Drawing.Size(56, 16)
        Me.LblAddress.TabIndex = 740
        Me.LblAddress.Text = "Address"
        '
        'TxtSaleToPartyCity
        '
        Me.TxtSaleToPartyCity.AgMandatory = False
        Me.TxtSaleToPartyCity.AgMasterHelp = True
        Me.TxtSaleToPartyCity.AgNumberLeftPlaces = 8
        Me.TxtSaleToPartyCity.AgNumberNegetiveAllow = False
        Me.TxtSaleToPartyCity.AgNumberRightPlaces = 2
        Me.TxtSaleToPartyCity.AgPickFromLastValue = False
        Me.TxtSaleToPartyCity.AgRowFilter = ""
        Me.TxtSaleToPartyCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToPartyCity.AgSelectedValue = Nothing
        Me.TxtSaleToPartyCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToPartyCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToPartyCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToPartyCity.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToPartyCity.Location = New System.Drawing.Point(129, 91)
        Me.TxtSaleToPartyCity.MaxLength = 0
        Me.TxtSaleToPartyCity.Name = "TxtSaleToPartyCity"
        Me.TxtSaleToPartyCity.Size = New System.Drawing.Size(111, 18)
        Me.TxtSaleToPartyCity.TabIndex = 6
        Me.TxtSaleToPartyCity.Text = "TxtPartyCity"
        '
        'LblCity
        '
        Me.LblCity.AutoSize = True
        Me.LblCity.BackColor = System.Drawing.Color.Transparent
        Me.LblCity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCity.Location = New System.Drawing.Point(16, 91)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(31, 16)
        Me.LblCity.TabIndex = 742
        Me.LblCity.Text = "City"
        '
        'TxtSaleToPartyMobile
        '
        Me.TxtSaleToPartyMobile.AgMandatory = False
        Me.TxtSaleToPartyMobile.AgMasterHelp = True
        Me.TxtSaleToPartyMobile.AgNumberLeftPlaces = 8
        Me.TxtSaleToPartyMobile.AgNumberNegetiveAllow = False
        Me.TxtSaleToPartyMobile.AgNumberRightPlaces = 2
        Me.TxtSaleToPartyMobile.AgPickFromLastValue = False
        Me.TxtSaleToPartyMobile.AgRowFilter = ""
        Me.TxtSaleToPartyMobile.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToPartyMobile.AgSelectedValue = Nothing
        Me.TxtSaleToPartyMobile.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToPartyMobile.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToPartyMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToPartyMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToPartyMobile.Location = New System.Drawing.Point(362, 91)
        Me.TxtSaleToPartyMobile.MaxLength = 0
        Me.TxtSaleToPartyMobile.Name = "TxtSaleToPartyMobile"
        Me.TxtSaleToPartyMobile.Size = New System.Drawing.Size(144, 18)
        Me.TxtSaleToPartyMobile.TabIndex = 7
        Me.TxtSaleToPartyMobile.Text = "TxtPartyMobile"
        '
        'LblMobile
        '
        Me.LblMobile.AutoSize = True
        Me.LblMobile.BackColor = System.Drawing.Color.Transparent
        Me.LblMobile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMobile.Location = New System.Drawing.Point(252, 93)
        Me.LblMobile.Name = "LblMobile"
        Me.LblMobile.Size = New System.Drawing.Size(46, 16)
        Me.LblMobile.TabIndex = 744
        Me.LblMobile.Text = "Mobile"
        '
        'TxtDriverMobile
        '
        Me.TxtDriverMobile.AgMandatory = False
        Me.TxtDriverMobile.AgMasterHelp = True
        Me.TxtDriverMobile.AgNumberLeftPlaces = 8
        Me.TxtDriverMobile.AgNumberNegetiveAllow = False
        Me.TxtDriverMobile.AgNumberRightPlaces = 2
        Me.TxtDriverMobile.AgPickFromLastValue = False
        Me.TxtDriverMobile.AgRowFilter = ""
        Me.TxtDriverMobile.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDriverMobile.AgSelectedValue = Nothing
        Me.TxtDriverMobile.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDriverMobile.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDriverMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDriverMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDriverMobile.Location = New System.Drawing.Point(345, 450)
        Me.TxtDriverMobile.MaxLength = 50
        Me.TxtDriverMobile.Name = "TxtDriverMobile"
        Me.TxtDriverMobile.Size = New System.Drawing.Size(111, 18)
        Me.TxtDriverMobile.TabIndex = 6
        Me.TxtDriverMobile.Text = "TxtDriverMobile"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(253, 453)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 16)
        Me.Label6.TabIndex = 759
        Me.Label6.Text = "Mobile No."
        '
        'TxtDriverName
        '
        Me.TxtDriverName.AgMandatory = False
        Me.TxtDriverName.AgMasterHelp = True
        Me.TxtDriverName.AgNumberLeftPlaces = 8
        Me.TxtDriverName.AgNumberNegetiveAllow = False
        Me.TxtDriverName.AgNumberRightPlaces = 2
        Me.TxtDriverName.AgPickFromLastValue = False
        Me.TxtDriverName.AgRowFilter = ""
        Me.TxtDriverName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDriverName.AgSelectedValue = Nothing
        Me.TxtDriverName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDriverName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDriverName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDriverName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDriverName.Location = New System.Drawing.Point(121, 450)
        Me.TxtDriverName.MaxLength = 50
        Me.TxtDriverName.Name = "TxtDriverName"
        Me.TxtDriverName.Size = New System.Drawing.Size(127, 18)
        Me.TxtDriverName.TabIndex = 5
        Me.TxtDriverName.Text = "TxtDriverName"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 451)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 16)
        Me.Label8.TabIndex = 758
        Me.Label8.Text = "Driver Name"
        '
        'TxtShipToPartyMobile
        '
        Me.TxtShipToPartyMobile.AgMandatory = False
        Me.TxtShipToPartyMobile.AgMasterHelp = True
        Me.TxtShipToPartyMobile.AgNumberLeftPlaces = 8
        Me.TxtShipToPartyMobile.AgNumberNegetiveAllow = False
        Me.TxtShipToPartyMobile.AgNumberRightPlaces = 2
        Me.TxtShipToPartyMobile.AgPickFromLastValue = False
        Me.TxtShipToPartyMobile.AgRowFilter = ""
        Me.TxtShipToPartyMobile.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShipToPartyMobile.AgSelectedValue = Nothing
        Me.TxtShipToPartyMobile.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShipToPartyMobile.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShipToPartyMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShipToPartyMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShipToPartyMobile.Location = New System.Drawing.Point(887, 51)
        Me.TxtShipToPartyMobile.MaxLength = 0
        Me.TxtShipToPartyMobile.Name = "TxtShipToPartyMobile"
        Me.TxtShipToPartyMobile.Size = New System.Drawing.Size(91, 18)
        Me.TxtShipToPartyMobile.TabIndex = 14
        Me.TxtShipToPartyMobile.Text = "TxtShipToPartyMobile"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(783, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 16)
        Me.Label1.TabIndex = 761
        Me.Label1.Text = "Mobile"
        '
        'TxtShipToPartyCity
        '
        Me.TxtShipToPartyCity.AgMandatory = False
        Me.TxtShipToPartyCity.AgMasterHelp = False
        Me.TxtShipToPartyCity.AgNumberLeftPlaces = 8
        Me.TxtShipToPartyCity.AgNumberNegetiveAllow = False
        Me.TxtShipToPartyCity.AgNumberRightPlaces = 2
        Me.TxtShipToPartyCity.AgPickFromLastValue = False
        Me.TxtShipToPartyCity.AgRowFilter = ""
        Me.TxtShipToPartyCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShipToPartyCity.AgSelectedValue = Nothing
        Me.TxtShipToPartyCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShipToPartyCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShipToPartyCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShipToPartyCity.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShipToPartyCity.Location = New System.Drawing.Point(630, 51)
        Me.TxtShipToPartyCity.MaxLength = 0
        Me.TxtShipToPartyCity.Name = "TxtShipToPartyCity"
        Me.TxtShipToPartyCity.Size = New System.Drawing.Size(147, 18)
        Me.TxtShipToPartyCity.TabIndex = 13
        Me.TxtShipToPartyCity.Text = "TxtShipToPartyCity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(513, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 16)
        Me.Label3.TabIndex = 759
        Me.Label3.Text = "City"
        '
        'TxtShipToPartyAddress
        '
        Me.TxtShipToPartyAddress.AgMandatory = False
        Me.TxtShipToPartyAddress.AgMasterHelp = True
        Me.TxtShipToPartyAddress.AgNumberLeftPlaces = 8
        Me.TxtShipToPartyAddress.AgNumberNegetiveAllow = False
        Me.TxtShipToPartyAddress.AgNumberRightPlaces = 2
        Me.TxtShipToPartyAddress.AgPickFromLastValue = False
        Me.TxtShipToPartyAddress.AgRowFilter = ""
        Me.TxtShipToPartyAddress.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShipToPartyAddress.AgSelectedValue = Nothing
        Me.TxtShipToPartyAddress.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShipToPartyAddress.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShipToPartyAddress.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShipToPartyAddress.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShipToPartyAddress.Location = New System.Drawing.Point(630, 31)
        Me.TxtShipToPartyAddress.MaxLength = 0
        Me.TxtShipToPartyAddress.Name = "TxtShipToPartyAddress"
        Me.TxtShipToPartyAddress.Size = New System.Drawing.Size(348, 18)
        Me.TxtShipToPartyAddress.TabIndex = 12
        Me.TxtShipToPartyAddress.Text = "TxtShipToPartyAddress"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(513, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 757
        Me.Label5.Text = "Ship To Address"
        '
        'TxtShipToPartyName
        '
        Me.TxtShipToPartyName.AgMandatory = False
        Me.TxtShipToPartyName.AgMasterHelp = False
        Me.TxtShipToPartyName.AgNumberLeftPlaces = 8
        Me.TxtShipToPartyName.AgNumberNegetiveAllow = False
        Me.TxtShipToPartyName.AgNumberRightPlaces = 2
        Me.TxtShipToPartyName.AgPickFromLastValue = False
        Me.TxtShipToPartyName.AgRowFilter = ""
        Me.TxtShipToPartyName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShipToPartyName.AgSelectedValue = Nothing
        Me.TxtShipToPartyName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShipToPartyName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShipToPartyName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShipToPartyName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShipToPartyName.Location = New System.Drawing.Point(630, 11)
        Me.TxtShipToPartyName.MaxLength = 0
        Me.TxtShipToPartyName.Name = "TxtShipToPartyName"
        Me.TxtShipToPartyName.Size = New System.Drawing.Size(348, 18)
        Me.TxtShipToPartyName.TabIndex = 11
        Me.TxtShipToPartyName.Text = "TxtShipToPartyName"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(513, 11)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 16)
        Me.Label7.TabIndex = 755
        Me.Label7.Text = "Ship To Party"
        '
        'TxtDeliveryNo
        '
        Me.TxtDeliveryNo.AgMandatory = False
        Me.TxtDeliveryNo.AgMasterHelp = True
        Me.TxtDeliveryNo.AgNumberLeftPlaces = 8
        Me.TxtDeliveryNo.AgNumberNegetiveAllow = False
        Me.TxtDeliveryNo.AgNumberRightPlaces = 2
        Me.TxtDeliveryNo.AgPickFromLastValue = False
        Me.TxtDeliveryNo.AgRowFilter = ""
        Me.TxtDeliveryNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDeliveryNo.AgSelectedValue = Nothing
        Me.TxtDeliveryNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDeliveryNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDeliveryNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDeliveryNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDeliveryNo.Location = New System.Drawing.Point(345, 470)
        Me.TxtDeliveryNo.MaxLength = 0
        Me.TxtDeliveryNo.Name = "TxtDeliveryNo"
        Me.TxtDeliveryNo.Size = New System.Drawing.Size(111, 18)
        Me.TxtDeliveryNo.TabIndex = 8
        Me.TxtDeliveryNo.Text = "TxtDeliveryNo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(253, 471)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 16)
        Me.Label9.TabIndex = 763
        Me.Label9.Text = "Delivery No."
        '
        'TxtVendorName
        '
        Me.TxtVendorName.AgMandatory = False
        Me.TxtVendorName.AgMasterHelp = False
        Me.TxtVendorName.AgNumberLeftPlaces = 8
        Me.TxtVendorName.AgNumberNegetiveAllow = False
        Me.TxtVendorName.AgNumberRightPlaces = 2
        Me.TxtVendorName.AgPickFromLastValue = False
        Me.TxtVendorName.AgRowFilter = ""
        Me.TxtVendorName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendorName.AgSelectedValue = Nothing
        Me.TxtVendorName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendorName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVendorName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendorName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendorName.Location = New System.Drawing.Point(129, 131)
        Me.TxtVendorName.MaxLength = 0
        Me.TxtVendorName.Name = "TxtVendorName"
        Me.TxtVendorName.Size = New System.Drawing.Size(378, 18)
        Me.TxtVendorName.TabIndex = 10
        Me.TxtVendorName.Text = "TxtVendorName"
        '
        'LblVendor
        '
        Me.LblVendor.AutoSize = True
        Me.LblVendor.BackColor = System.Drawing.Color.Transparent
        Me.LblVendor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendor.Location = New System.Drawing.Point(16, 132)
        Me.LblVendor.Name = "LblVendor"
        Me.LblVendor.Size = New System.Drawing.Size(49, 16)
        Me.LblVendor.TabIndex = 763
        Me.LblVendor.Text = "Vendor"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(253, 532)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 16)
        Me.Label10.TabIndex = 765
        Me.Label10.Text = "Private Marka"
        '
        'TxtPrivateMarka
        '
        Me.TxtPrivateMarka.AgMandatory = False
        Me.TxtPrivateMarka.AgMasterHelp = True
        Me.TxtPrivateMarka.AgNumberLeftPlaces = 8
        Me.TxtPrivateMarka.AgNumberNegetiveAllow = False
        Me.TxtPrivateMarka.AgNumberRightPlaces = 2
        Me.TxtPrivateMarka.AgPickFromLastValue = False
        Me.TxtPrivateMarka.AgRowFilter = ""
        Me.TxtPrivateMarka.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPrivateMarka.AgSelectedValue = Nothing
        Me.TxtPrivateMarka.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPrivateMarka.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPrivateMarka.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrivateMarka.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrivateMarka.Location = New System.Drawing.Point(345, 530)
        Me.TxtPrivateMarka.MaxLength = 20
        Me.TxtPrivateMarka.Name = "TxtPrivateMarka"
        Me.TxtPrivateMarka.Size = New System.Drawing.Size(111, 18)
        Me.TxtPrivateMarka.TabIndex = 14
        Me.TxtPrivateMarka.Text = "TxtPrivateMarka"
        '
        'TxtPortofLoading
        '
        Me.TxtPortofLoading.AgMandatory = False
        Me.TxtPortofLoading.AgMasterHelp = False
        Me.TxtPortofLoading.AgNumberLeftPlaces = 8
        Me.TxtPortofLoading.AgNumberNegetiveAllow = False
        Me.TxtPortofLoading.AgNumberRightPlaces = 2
        Me.TxtPortofLoading.AgPickFromLastValue = False
        Me.TxtPortofLoading.AgRowFilter = ""
        Me.TxtPortofLoading.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPortofLoading.AgSelectedValue = Nothing
        Me.TxtPortofLoading.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPortofLoading.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPortofLoading.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPortofLoading.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPortofLoading.Location = New System.Drawing.Point(630, 70)
        Me.TxtPortofLoading.MaxLength = 0
        Me.TxtPortofLoading.Name = "TxtPortofLoading"
        Me.TxtPortofLoading.Size = New System.Drawing.Size(147, 18)
        Me.TxtPortofLoading.TabIndex = 15
        Me.TxtPortofLoading.Text = "TxtPortofLoading"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(513, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 16)
        Me.Label11.TabIndex = 765
        Me.Label11.Text = "Port of Loading"
        '
        'TxtDestinationPort
        '
        Me.TxtDestinationPort.AgMandatory = False
        Me.TxtDestinationPort.AgMasterHelp = False
        Me.TxtDestinationPort.AgNumberLeftPlaces = 8
        Me.TxtDestinationPort.AgNumberNegetiveAllow = False
        Me.TxtDestinationPort.AgNumberRightPlaces = 2
        Me.TxtDestinationPort.AgPickFromLastValue = False
        Me.TxtDestinationPort.AgRowFilter = ""
        Me.TxtDestinationPort.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDestinationPort.AgSelectedValue = Nothing
        Me.TxtDestinationPort.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDestinationPort.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDestinationPort.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDestinationPort.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDestinationPort.Location = New System.Drawing.Point(887, 70)
        Me.TxtDestinationPort.MaxLength = 0
        Me.TxtDestinationPort.Name = "TxtDestinationPort"
        Me.TxtDestinationPort.Size = New System.Drawing.Size(91, 18)
        Me.TxtDestinationPort.TabIndex = 16
        Me.TxtDestinationPort.Text = "TxtDestinationPort"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(783, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 16)
        Me.Label12.TabIndex = 767
        Me.Label12.Text = "Destination Port"
        '
        'TxtShipmentThrough
        '
        Me.TxtShipmentThrough.AgMandatory = False
        Me.TxtShipmentThrough.AgMasterHelp = True
        Me.TxtShipmentThrough.AgNumberLeftPlaces = 8
        Me.TxtShipmentThrough.AgNumberNegetiveAllow = False
        Me.TxtShipmentThrough.AgNumberRightPlaces = 2
        Me.TxtShipmentThrough.AgPickFromLastValue = False
        Me.TxtShipmentThrough.AgRowFilter = ""
        Me.TxtShipmentThrough.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShipmentThrough.AgSelectedValue = Nothing
        Me.TxtShipmentThrough.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShipmentThrough.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShipmentThrough.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShipmentThrough.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShipmentThrough.Location = New System.Drawing.Point(630, 130)
        Me.TxtShipmentThrough.MaxLength = 100
        Me.TxtShipmentThrough.Name = "TxtShipmentThrough"
        Me.TxtShipmentThrough.Size = New System.Drawing.Size(147, 18)
        Me.TxtShipmentThrough.TabIndex = 22
        Me.TxtShipmentThrough.Text = "TxtShipmentThrough"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(513, 131)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(113, 16)
        Me.Label13.TabIndex = 769
        Me.Label13.Text = "Shipment Through"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(7, 471)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 16)
        Me.Label14.TabIndex = 767
        Me.Label14.Text = "Place of Delivery "
        '
        'TxtFinalPlaceofDelivery
        '
        Me.TxtFinalPlaceofDelivery.AgMandatory = False
        Me.TxtFinalPlaceofDelivery.AgMasterHelp = True
        Me.TxtFinalPlaceofDelivery.AgNumberLeftPlaces = 8
        Me.TxtFinalPlaceofDelivery.AgNumberNegetiveAllow = False
        Me.TxtFinalPlaceofDelivery.AgNumberRightPlaces = 2
        Me.TxtFinalPlaceofDelivery.AgPickFromLastValue = False
        Me.TxtFinalPlaceofDelivery.AgRowFilter = ""
        Me.TxtFinalPlaceofDelivery.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFinalPlaceofDelivery.AgSelectedValue = Nothing
        Me.TxtFinalPlaceofDelivery.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFinalPlaceofDelivery.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFinalPlaceofDelivery.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFinalPlaceofDelivery.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFinalPlaceofDelivery.Location = New System.Drawing.Point(121, 470)
        Me.TxtFinalPlaceofDelivery.MaxLength = 50
        Me.TxtFinalPlaceofDelivery.Name = "TxtFinalPlaceofDelivery"
        Me.TxtFinalPlaceofDelivery.Size = New System.Drawing.Size(127, 18)
        Me.TxtFinalPlaceofDelivery.TabIndex = 7
        Me.TxtFinalPlaceofDelivery.Text = "TxtFinalPlaceofDelivery"
        '
        'TxtPlaceOfPreCarriage
        '
        Me.TxtPlaceOfPreCarriage.AgMandatory = False
        Me.TxtPlaceOfPreCarriage.AgMasterHelp = False
        Me.TxtPlaceOfPreCarriage.AgNumberLeftPlaces = 8
        Me.TxtPlaceOfPreCarriage.AgNumberNegetiveAllow = False
        Me.TxtPlaceOfPreCarriage.AgNumberRightPlaces = 2
        Me.TxtPlaceOfPreCarriage.AgPickFromLastValue = False
        Me.TxtPlaceOfPreCarriage.AgRowFilter = ""
        Me.TxtPlaceOfPreCarriage.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPlaceOfPreCarriage.AgSelectedValue = Nothing
        Me.TxtPlaceOfPreCarriage.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPlaceOfPreCarriage.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPlaceOfPreCarriage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPlaceOfPreCarriage.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPlaceOfPreCarriage.Location = New System.Drawing.Point(630, 90)
        Me.TxtPlaceOfPreCarriage.MaxLength = 50
        Me.TxtPlaceOfPreCarriage.Name = "TxtPlaceOfPreCarriage"
        Me.TxtPlaceOfPreCarriage.Size = New System.Drawing.Size(147, 18)
        Me.TxtPlaceOfPreCarriage.TabIndex = 17
        Me.TxtPlaceOfPreCarriage.Text = "TxtPlaceOfPreCarriage"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(513, 91)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(134, 16)
        Me.Label15.TabIndex = 771
        Me.Label15.Text = "Place Of Pre Carriage"
        '
        'TxtPreCarriageBy
        '
        Me.TxtPreCarriageBy.AgMandatory = False
        Me.TxtPreCarriageBy.AgMasterHelp = False
        Me.TxtPreCarriageBy.AgNumberLeftPlaces = 8
        Me.TxtPreCarriageBy.AgNumberNegetiveAllow = False
        Me.TxtPreCarriageBy.AgNumberRightPlaces = 2
        Me.TxtPreCarriageBy.AgPickFromLastValue = False
        Me.TxtPreCarriageBy.AgRowFilter = ""
        Me.TxtPreCarriageBy.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPreCarriageBy.AgSelectedValue = Nothing
        Me.TxtPreCarriageBy.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPreCarriageBy.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPreCarriageBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPreCarriageBy.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPreCarriageBy.Location = New System.Drawing.Point(888, 91)
        Me.TxtPreCarriageBy.MaxLength = 50
        Me.TxtPreCarriageBy.Name = "TxtPreCarriageBy"
        Me.TxtPreCarriageBy.Size = New System.Drawing.Size(90, 18)
        Me.TxtPreCarriageBy.TabIndex = 18
        Me.TxtPreCarriageBy.Text = "TxtPreCarriageBy"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(783, 93)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(100, 16)
        Me.Label16.TabIndex = 773
        Me.Label16.Text = "Pre Carriage By"
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(860, 430)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(145, 140)
        Me.PnlCShowGrid2.TabIndex = 768
        '
        'TempSaleChallan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(1014, 618)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtFinalPlaceofDelivery)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtPrivateMarka)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtDeliveryNo)
        Me.Controls.Add(Me.TxtDriverMobile)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtDriverName)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.RbtChallanDirect)
        Me.Controls.Add(Me.TxtLrDate)
        Me.Controls.Add(Me.RbtChallanForOrder)
        Me.Controls.Add(Me.LblLrDate)
        Me.Controls.Add(Me.TxtLrNo)
        Me.Controls.Add(Me.LblLrNo)
        Me.Controls.Add(Me.PnlCShowGrid1)
        Me.Controls.Add(Me.BtnRemoveFilter)
        Me.Controls.Add(Me.TxtTransporter)
        Me.Controls.Add(Me.LblTransporter)
        Me.Controls.Add(Me.TxtFormNo)
        Me.Controls.Add(Me.LblFormNo)
        Me.Controls.Add(Me.TxtForm)
        Me.Controls.Add(Me.LblForm)
        Me.Controls.Add(Me.TxtTruckNo)
        Me.Controls.Add(Me.LblTruckNo)
        Me.Controls.Add(Me.TxtGateEntryNo)
        Me.Controls.Add(Me.LblGateEntryNo)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtRemarks)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.TxtStructure)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TxtSalesTaxGroupParty)
        Me.Controls.Add(Me.TxtTransport)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.LblTransport)
        Me.Name = "TempSaleChallan"
        Me.Text = "Template Goods Receive"
        Me.Controls.SetChildIndex(Me.LblTransport, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.TxtTransport, 0)
        Me.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.LblGateEntryNo, 0)
        Me.Controls.SetChildIndex(Me.TxtGateEntryNo, 0)
        Me.Controls.SetChildIndex(Me.LblTruckNo, 0)
        Me.Controls.SetChildIndex(Me.TxtTruckNo, 0)
        Me.Controls.SetChildIndex(Me.LblForm, 0)
        Me.Controls.SetChildIndex(Me.TxtForm, 0)
        Me.Controls.SetChildIndex(Me.LblFormNo, 0)
        Me.Controls.SetChildIndex(Me.TxtFormNo, 0)
        Me.Controls.SetChildIndex(Me.LblTransporter, 0)
        Me.Controls.SetChildIndex(Me.TxtTransporter, 0)
        Me.Controls.SetChildIndex(Me.BtnRemoveFilter, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid1, 0)
        Me.Controls.SetChildIndex(Me.LblLrNo, 0)
        Me.Controls.SetChildIndex(Me.TxtLrNo, 0)
        Me.Controls.SetChildIndex(Me.LblLrDate, 0)
        Me.Controls.SetChildIndex(Me.RbtChallanForOrder, 0)
        Me.Controls.SetChildIndex(Me.TxtLrDate, 0)
        Me.Controls.SetChildIndex(Me.RbtChallanDirect, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.TxtDriverName, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtDriverMobile, 0)
        Me.Controls.SetChildIndex(Me.TxtDeliveryNo, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.TxtPrivateMarka, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.TxtFinalPlaceofDelivery, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
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
        Me.PerformLayout()

    End Sub
    Protected WithEvents LblParty As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToParty As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtSalesTaxGroupParty As AgControls.AgTextBox
    Protected WithEvents Label27 As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents TxtBillingType As AgControls.AgTextBox
    Protected WithEvents Label32 As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents Label33 As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtCurrency As AgControls.AgTextBox
    Protected WithEvents LblCurrency As System.Windows.Forms.Label
    Protected WithEvents TxtTransport As AgControls.AgTextBox
    Protected WithEvents LblTransport As System.Windows.Forms.Label
    Protected WithEvents TxtGodown As AgControls.AgTextBox
    Protected WithEvents LblGodown As System.Windows.Forms.Label
    Protected WithEvents TxtSaleOrderNo As AgControls.AgTextBox
    Protected WithEvents LblOrderNo As System.Windows.Forms.Label
    Protected WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents TxtGateEntryNo As AgControls.AgTextBox
    Protected WithEvents LblGateEntryNo As System.Windows.Forms.Label
    Protected WithEvents TxtTruckNo As AgControls.AgTextBox
    Protected WithEvents LblTruckNo As System.Windows.Forms.Label
    Protected WithEvents TxtForm As AgControls.AgTextBox
    Protected WithEvents LblForm As System.Windows.Forms.Label
    Protected WithEvents TxtFormNo As AgControls.AgTextBox
    Protected WithEvents LblFormNo As System.Windows.Forms.Label
    Protected WithEvents TxtTransporter As AgControls.AgTextBox
    Protected WithEvents LblTransporter As System.Windows.Forms.Label
    Protected WithEvents BtnRemoveFilter As System.Windows.Forms.Button
    Protected WithEvents PnlCShowGrid1 As System.Windows.Forms.Panel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtLrNo As AgControls.AgTextBox
    Protected WithEvents LblLrNo As System.Windows.Forms.Label
    Protected WithEvents TxtLrDate As AgControls.AgTextBox
    Protected WithEvents LblLrDate As System.Windows.Forms.Label
    Protected WithEvents RbtChallanDirect As System.Windows.Forms.RadioButton
    Protected WithEvents RbtChallanForOrder As System.Windows.Forms.RadioButton
    Protected WithEvents TxtSaleToPartyAddress As AgControls.AgTextBox
    Protected WithEvents LblAddress As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToPartyMobile As AgControls.AgTextBox
    Protected WithEvents LblMobile As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToPartyCity As AgControls.AgTextBox
    Protected WithEvents LblCity As System.Windows.Forms.Label
    Protected WithEvents TxtDriverMobile As AgControls.AgTextBox
    Protected WithEvents Label6 As System.Windows.Forms.Label
    Protected WithEvents TxtDriverName As AgControls.AgTextBox
    Protected WithEvents Label8 As System.Windows.Forms.Label
    Protected WithEvents TxtShipToPartyMobile As AgControls.AgTextBox
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TxtShipToPartyCity As AgControls.AgTextBox
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents TxtShipToPartyAddress As AgControls.AgTextBox
    Protected WithEvents Label5 As System.Windows.Forms.Label
    Protected WithEvents TxtShipToPartyName As AgControls.AgTextBox
    Protected WithEvents Label7 As System.Windows.Forms.Label
    Protected WithEvents TxtDeliveryNo As AgControls.AgTextBox
    Protected WithEvents Label9 As System.Windows.Forms.Label
    Protected WithEvents TxtVendorName As AgControls.AgTextBox
    Protected WithEvents LblVendor As System.Windows.Forms.Label
    Protected WithEvents Label10 As System.Windows.Forms.Label
    Protected WithEvents TxtPrivateMarka As AgControls.AgTextBox
    Protected WithEvents TxtPortofLoading As AgControls.AgTextBox
    Protected WithEvents Label11 As System.Windows.Forms.Label
    Protected WithEvents TxtDestinationPort As AgControls.AgTextBox
    Protected WithEvents Label12 As System.Windows.Forms.Label
    Protected WithEvents TxtShipmentThrough As AgControls.AgTextBox
    Protected WithEvents Label13 As System.Windows.Forms.Label
    Protected WithEvents Label14 As System.Windows.Forms.Label
    Protected WithEvents TxtFinalPlaceofDelivery As AgControls.AgTextBox
    Protected WithEvents TxtPlaceOfPreCarriage As AgControls.AgTextBox
    Protected WithEvents Label15 As System.Windows.Forms.Label
    Protected WithEvents TxtPreCarriageBy As AgControls.AgTextBox
    Protected WithEvents Label16 As System.Windows.Forms.Label
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
#End Region

    Private Sub TempSaleChallan_BaseEvent_ApproveDeletion_PreTrans(ByVal SearchCode As String) Handles Me.BaseEvent_ApproveDeletion_PreTrans
        mQry = " SELECT L.DocId, L.Item, L.SaleOrder, L.Item, L.Qty, L.TotalMeasure " & _
               " FROM SaleChallanDetail L " & _
               " WHERE L.DocId = '" & mInternalCode & "' "
        DsMain = AgL.FillData(mQry, AgL.GcnRead)
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "SaleChallan"
        LogTableName = "SaleChallan_Log"
        MainLineTableCsv = "SaleChallanDetail,Stock,Structure_TransFooter,Structure_TransLine"
        LogLineTableCsv = "SaleChallanDetail_LOG,Stock_Log,Structure_TransFooter_Log,Structure_TransLine_Log"

        AgL.GridDesign(Dgl1)
        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)
        AgL.AddAgDataGrid(AgCShowGrid1, PnlCShowGrid1)
        AgL.AddAgDataGrid(AgCShowGrid2, PnlCShowGrid2)

        AgCShowGrid1.Visible = False
        AgCShowGrid2.Visible = False

        AgCalcGrid1.AgLibVar = AgL
        AgCalcGrid1.Visible = False
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From SaleChallan H " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " Where IsNull(IsDeleted,0)=0  " & mCondStr & "  Order By V_Date Desc "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select UID As SearchCode " & _
               " From SaleChallan_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = " SELECT  H.UID AS SearchCode, H.V_Date AS Date, D.Div_Name AS Division_Name, SM.Name AS Site_Name, " & _
                        " H.ReferenceNo AS Manual_No, SGV.DispName AS Vendor, H.SaleToPartyName AS Sale_To_Party_Name,  " & _
                        " H.SaleToPartyAddress AS Sale_To_Party_Address, CP.CityName AS Sale_To_Party_City, H.SaleToPartyMobile AS Sale_To_Party_Mobile,  " & _
                        " H.ShipToPartyName AS Ship_To_Party_Name, H.ShipToPartyAddress AS Ship_To_Party_Address, CS.CityName AS Ship_To_Party_City, H.ShipToPartyMobile AS Ship_To_Party_Mobile,  " & _
                        " H.Currency, H.GateEntryNo AS Gate_Entry_No, H.TruckNo AS Truck_No, H.SalesTaxGroupParty AS Sales_Tax_Group_Party,  " & _
                        " H.BillingType AS Billing_Type, H.Form, H.FormNo AS Form_No, H.DriverName AS Driver_Name, H.DriverContactNo AS Driver_Contact_No,  " & _
                        " G.Description AS Godown, H.LrNo, H.LrDate, H.PrivateMark AS Private_Mark, PL.Description AS Port_Of_Loading, PD.Description AS Destination_Port,  " & _
                        " H.FinalPlaceOfDelivery AS Final_Place_Of_Delivery, H.PreCarriageBy AS Pre_Carriage_By, H.PlaceOfPreCarriage AS Place_Of_Pre_Carriage,  " & _
                        " H.ShipmentThrough AS Shipment_Through, H.Remarks, H.TotalQty AS Total_Qty, H.TotalMeasure AS Total_Measure, H.TotalAmount AS Total_Amount,  " & _
                        " H.EntryBy AS Entry_By,  H.Status " & _
                        " FROM  SaleChallan_Log  H " & _
                        " LEFT JOIN Voucher_Type Vt on Vt.V_Type = H.V_Type " & _
                        " LEFT JOIN Division D ON D.Div_Code = H.Div_Code  " & _
                        " LEFT JOIN SiteMast SM ON SM.Code = H.Site_Code  " & _
                        " LEFT JOIN SubGroup SGV ON SGV.SubCode = H.Vendor  " & _
                        " LEFT JOIN City CP ON CP.CityCode = H.SaleToPartyCity  " & _
                        " LEFT JOIN City CS ON CS.CityCode = H.ShipToPartyCity  " & _
                        " LEFT JOIN Godown G ON G.Code = H.Godown  " & _
                        " LEFT JOIN SeaPort PL ON PL.Code=H.PortOfLoading  " & _
                        " LEFT JOIN SeaPort PD ON PD.Code=H.DestinationPort " & _
                        " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, H.V_Date AS Date, D.Div_Name AS Division_Name, SM.Name AS Site_Name, " & _
                        " H.ReferenceNo AS Manual_No, SGV.DispName AS Vendor, H.SaleToPartyName AS Sale_To_Party_Name,  " & _
                        " H.SaleToPartyAddress AS Sale_To_Party_Address, CP.CityName AS Sale_To_Party_City, H.SaleToPartyMobile AS Sale_To_Party_Mobile,  " & _
                        " H.ShipToPartyName AS Ship_To_Party_Name, H.ShipToPartyAddress AS Ship_To_Party_Address, CS.CityName AS Ship_To_Party_City, H.ShipToPartyMobile AS Ship_To_Party_Mobile,  " & _
                        " H.Currency, H.GateEntryNo AS Gate_Entry_No, H.TruckNo AS Truck_No, H.SalesTaxGroupParty AS Sales_Tax_Group_Party,  " & _
                        " H.BillingType AS Billing_Type, H.Form, H.FormNo AS Form_No, H.DriverName AS Driver_Name, H.DriverContactNo AS Driver_Contact_No,  " & _
                        " G.Description AS Godown, H.LrNo, H.LrDate, H.PrivateMark AS Private_Mark, PL.Description AS Port_Of_Loading, PD.Description AS Destination_Port,  " & _
                        " H.FinalPlaceOfDelivery AS Final_Place_Of_Delivery, H.PreCarriageBy AS Pre_Carriage_By, H.PlaceOfPreCarriage AS Place_Of_Pre_Carriage,  " & _
                        " H.ShipmentThrough AS Shipment_Through, H.Remarks, H.TotalQty AS Total_Qty, H.TotalMeasure AS Total_Measure, H.TotalAmount AS Total_Amount,  " & _
                        " H.EntryBy AS Entry_By,  H.Status " & _
                        " FROM  SaleChallan  H " & _
                        " LEFT JOIN Voucher_Type Vt on Vt.V_Type = H.V_Type " & _
                        " LEFT JOIN Division D ON D.Div_Code = H.Div_Code  " & _
                        " LEFT JOIN SiteMast SM ON SM.Code = H.Site_Code  " & _
                        " LEFT JOIN SubGroup SGV ON SGV.SubCode = H.Vendor  " & _
                        " LEFT JOIN City CP ON CP.CityCode = H.SaleToPartyCity  " & _
                        " LEFT JOIN City CS ON CS.CityCode = H.ShipToPartyCity  " & _
                        " LEFT JOIN Godown G ON G.Code = H.Godown  " & _
                        " LEFT JOIN SeaPort PL ON PL.Code=H.PortOfLoading  " & _
                        " LEFT JOIN SeaPort PD ON PD.Code=H.DestinationPort " & _
                        " Where IsNull(H.IsDeleted,0)=0  " & mCondStr

        AgL.PubFindQryOrdBy = "[Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 180, 0, Col1Item, True, False)
            .AddAgTextColumn(Dgl1, Col1SalesTaxGroup, 120, 0, Col1SalesTaxGroup, False, False)
            .AddAgNumberColumn(Dgl1, Col1DocQty, 50, 8, 3, False, Col1DocQty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1RejQty, 60, 8, 3, False, Col1RejQty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Qty, 50, 8, 3, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 70, 8, 3, False, Col1MeasurePerPcs, True, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 50, 0, Col1MeasureUnit, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalDocMeasure, 70, 8, 3, False, Col1TotalDocMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalRejMeasure, 70, 8, 3, False, Col1TotalRejMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 70, 8, 3, False, Col1TotalMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 60, 8, 4, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 70, 8, 2, False, Col1Amount, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1InvoicedQty, 70, 8, 3, False, Col1InvoicedQty, False, False, True)
            .AddAgNumberColumn(Dgl1, Col1InvoicedMeasure, 70, 8, 3, False, Col1InvoicedMeasure, False, False, True)
            .AddAgTextColumn(Dgl1, Col1Remark, 150, 0, Col1Remark, True, False)
            .AddAgTextColumn(Dgl1, Col1LotNo, 120, 20, Col1LotNo, True, False)
            .AddAgTextColumn(Dgl1, Col1SaleOrder, 120, 0, Col1SaleOrder, False, False)
            .AddAgTextColumn(Dgl1, Col1DeliveryOrder, 120, 0, Col1DeliveryOrder, False, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Panel1.Anchor = Dgl1.Anchor
        Dgl1.ColumnHeadersHeight = 35


        AgCalcGrid1.Ini_Grid(mSearchCode)
        AgCalcGrid1.AgFixedRows = 5
        AgCShowGrid1.AgIsFixedRows = True
        AgCShowGrid1.AgParentCalcGrid = AgCalcGrid1
        AgCShowGrid2.AgParentCalcGrid = AgCalcGrid1
        If AgCalcGrid1.RowCount > 0 Then
            AgCShowGrid1.Ini_Grid()
            AgCShowGrid2.Ini_Grid()
        End If


        AgCalcGrid1.AgLineGrid = Dgl1
        AgCalcGrid1.AgLineGridMandatoryColumn = Dgl1.Columns(Col1Item).Index
        AgCalcGrid1.AgLineGridGrossColumn = Dgl1.Columns(Col1Amount).Index
        AgCalcGrid1.AgLineGridPostingGroupSalesTaxProd = Dgl1.Columns(Col1SalesTaxGroup).Index

        Dgl1.AgSkipReadOnlyColumns = True

        FrmSaleOrder_BaseFunction_FIniList()
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = " UPDATE SaleChallan_Log " & _
                " SET ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " SaleToParty = " & AgL.Chk_Text(TxtSaleToParty.AgSelectedValue) & ", " & _
                " SaleToPartyName = " & AgL.Chk_Text(TxtSaleToParty.Text) & ", " & _
                " SaleToPartyAddress = " & AgL.Chk_Text(TxtSaleToPartyAddress.Text) & ", " & _
                " SaleToPartyCity = " & AgL.Chk_Text(TxtSaleToPartyCity.AgSelectedValue) & ", " & _
                " SaleToPartyMobile = " & AgL.Chk_Text(TxtSaleToPartyMobile.Text) & ", " & _
                " ShipToParty = " & AgL.Chk_Text(TxtShipToPartyName.AgSelectedValue) & ", " & _
                " ShipToPartyName = " & AgL.Chk_Text(TxtShipToPartyName.Text) & ", " & _
                " ShipToPartyAddress = " & AgL.Chk_Text(TxtShipToPartyAddress.Text) & ", " & _
                " ShipToPartyCity = " & AgL.Chk_Text(TxtShipToPartyCity.AgSelectedValue) & ", " & _
                " ShipToPartyMobile = " & AgL.Chk_Text(TxtShipToPartyMobile.Text) & ", " & _
                " Currency = " & AgL.Chk_Text(TxtCurrency.AgSelectedValue) & ", " & _
                " GateEntryNo = " & AgL.Chk_Text(TxtGateEntryNo.Text) & ", " & _
                " TruckNo = " & AgL.Chk_Text(TxtTruckNo.Text) & ", " & _
                " SalesTaxGroupParty = " & AgL.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & ", " & _
                " Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                " BillingType = " & AgL.Chk_Text(TxtBillingType.AgSelectedValue) & ", " & _
                " Form = " & AgL.Chk_Text(TxtForm.AgSelectedValue) & ", " & _
                " FormNo = " & AgL.Chk_Text(TxtFormNo.Text) & ", " & _
                " Transporter = " & AgL.Chk_Text(TxtTransporter.AgSelectedValue) & ", " & _
                " Godown = " & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " TotalQty = " & AgL.Chk_Text(LblTotalQty.Text) & ", " & _
                " TotalMeasure = " & AgL.Chk_Text(LblTotalMeasure.Text) & ", " & _
                " TotalAmount = " & AgL.Chk_Text(LblTotalAmount.Text) & ", " & _
                " Vendor = " & AgL.Chk_Text(TxtVendorName.AgSelectedValue) & ", " & _
                " SaleOrder = " & AgL.Chk_Text(TxtSaleOrderNo.AgSelectedValue) & ", " & _
                " DeliveryOrder = " & AgL.Chk_Text(TxtDeliveryNo.Text) & ", " & _
                " Driver = " & AgL.Chk_Text(TxtDriverName.AgSelectedValue) & ", " & _
                " DriverName = " & AgL.Chk_Text(TxtDriverName.Text) & ", " & _
                " DriverContactNo = " & AgL.Chk_Text(TxtDriverMobile.Text) & ", " & _
                " LrNo = " & AgL.Chk_Text(TxtLrNo.Text) & ", " & _
                " LrDate = " & AgL.Chk_Text(TxtLrDate.Text) & ", " & _
                " Vehicle = " & AgL.Chk_Text(TxtTruckNo.AgSelectedValue) & ", " & _
                " VehicleDescription = " & AgL.Chk_Text(TxtTruckNo.Text) & ", " & _
                " PrivateMark = " & AgL.Chk_Text(TxtPrivateMarka.Text) & ", " & _
                " PortOfLoading = " & AgL.Chk_Text(TxtPortofLoading.AgSelectedValue) & ", " & _
                " DestinationPort = " & AgL.Chk_Text(TxtDestinationPort.AgSelectedValue) & ", " & _
                " FinalPlaceOfDelivery =  " & AgL.Chk_Text(TxtFinalPlaceofDelivery.Text) & ", " & _
                " PreCarriageBy = " & AgL.Chk_Text(TxtPreCarriageBy.Text) & ", " & _
                " PlaceOfPreCarriage = " & AgL.Chk_Text(TxtPlaceOfPreCarriage.Text) & ", " & _
                " ShipmentThrough = " & AgL.Chk_Text(TxtShipmentThrough.Text) & "  " & _
                " Where UID = '" & mSearchCode & "'"

        ' " Transport = " & AgL.Chk_Text(TxtTransport.Text) & ", " & _

        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        AgCalcGrid1.Save_TransFooter(mInternalCode, Conn, Cmd, SearchCode)

        mQry = "Delete From SaleChallanDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        If mIsPostStock Then
            mQry = "Delete From Stock_Log Where UID = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1

                mQry = " INSERT INTO SaleChallanDetail_Log (UID, DocId, Sr, Item, " & _
                        " SalesTaxGroupItem, DocQty, RejQty, Qty, Unit, MeasurePerPcs, MeasureUnit,  " & _
                        " TotalDocMeasure, TotalRejMeasure, TotalMeasure, Rate, Amount, InvoicedQty,  " & _
                        " InvoicedMeasure, LotNo, Remark, SaleOrder, DeliveryOrder) " & _
                        " VALUES ( " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & mSr & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1SalesTaxGroup, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1DocQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1RejQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalDocMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalRejMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1InvoicedQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1InvoicedMeasure, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1LotNo, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Remark, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1SaleOrder, I)) & ", " & _
                       " " & AgL.Chk_Text(TxtDeliveryNo.AgSelectedValue) & " ) "

                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                If mIsPostStock Then Call ProcStockPost(Conn, Cmd, I, mSr)

                AgCalcGrid1.Save_TransLine(mInternalCode, mSr, I, Conn, Cmd, SearchCode)
                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer

        Dim DsTemp As DataSet

        Call IniItemList()
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From SaleChallan H " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                " From SaleChallan_Log H " & _
                " Where H.UID='" & SearchCode & "'"

        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)


        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)

                If AgL.XNull(.Rows(0)("Structure")) <> "" Then
                    TxtStructure.AgSelectedValue = AgL.XNull(.Rows(0)("Structure"))
                End If
                AgCalcGrid1.FrmType = Me.FrmType
                AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue

                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                TxtSaleToParty.AgSelectedValue = AgL.XNull(.Rows(0)("SaleToParty"))
                TxtSaleToPartyAddress.Text = AgL.XNull(.Rows(0)("SaleToPartyAddress"))
                TxtSaleToPartyCity.AgSelectedValue = AgL.XNull(.Rows(0)("SaleToPartyCity"))
                TxtSaleToPartyMobile.Text = AgL.XNull(.Rows(0)("SaleToPartyMobile"))
                TxtShipToPartyName.AgSelectedValue = AgL.XNull(.Rows(0)("ShipToParty"))
                TxtShipToPartyName.Text = AgL.XNull(.Rows(0)("ShipToPartyName"))
                TxtShipToPartyAddress.Text = AgL.XNull(.Rows(0)("ShipToPartyAddress"))
                TxtShipToPartyCity.AgSelectedValue = AgL.XNull(.Rows(0)("ShipToPartyCity"))
                TxtShipToPartyMobile.Text = AgL.XNull(.Rows(0)("ShipToPartyMobile"))
                TxtCurrency.AgSelectedValue = AgL.XNull(.Rows(0)("Currency"))
                TxtGateEntryNo.Text = AgL.XNull(.Rows(0)("GateEntryNo"))
                TxtTruckNo.Text = AgL.XNull(.Rows(0)("TruckNo"))
                TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))
                TxtStructure.AgSelectedValue = AgL.XNull(.Rows(0)("Structure"))
                TxtBillingType.AgSelectedValue = AgL.XNull(.Rows(0)("BillingType"))
                TxtForm.AgSelectedValue = AgL.XNull(.Rows(0)("Form"))
                TxtFormNo.Text = AgL.XNull(.Rows(0)("FormNo"))
                TxtTransporter.AgSelectedValue = AgL.XNull(.Rows(0)("Transporter"))
                '  TxtTransport.Text = AgL.XNull(.Rows(0)("Transport"))
                TxtGodown.AgSelectedValue = AgL.XNull(.Rows(0)("Godown"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))
                LblTotalMeasure.Text = AgL.VNull(.Rows(0)("TotalMeasure"))

                TxtVendorName.AgSelectedValue = AgL.XNull(.Rows(0)("Vendor"))
                TxtSaleOrderNo.AgSelectedValue = AgL.XNull(.Rows(0)("SaleOrder"))
                TxtDeliveryNo.Text = AgL.XNull(.Rows(0)("DeliveryOrder"))
                TxtDriverName.AgSelectedValue = AgL.XNull(.Rows(0)("Driver"))
                TxtDriverName.Text = AgL.XNull(.Rows(0)("DriverName"))
                TxtDriverMobile.Text = AgL.XNull(.Rows(0)("DriverContactNo"))
                TxtLrNo.Text = AgL.XNull(.Rows(0)("LrNo"))
                TxtLrDate.Text = AgL.XNull(.Rows(0)("LrDate"))
                TxtPrivateMarka.Text = AgL.XNull(.Rows(0)("PrivateMark"))
                TxtPortofLoading.AgSelectedValue = AgL.XNull(.Rows(0)("PortOfLoading"))
                TxtDestinationPort.AgSelectedValue = AgL.XNull(.Rows(0)("DestinationPort"))
                TxtFinalPlaceofDelivery.Text = AgL.XNull(.Rows(0)("FinalPlaceOfDelivery"))
                TxtPreCarriageBy.Text = AgL.XNull(.Rows(0)("PreCarriageBy"))
                TxtPlaceOfPreCarriage.Text = AgL.XNull(.Rows(0)("PlaceOfPreCarriage"))
                TxtShipmentThrough.Text = AgL.XNull(.Rows(0)("ShipmentThrough"))


                AgCalcGrid1.MoveRec_TransFooter(SearchCode)

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from SaleChallanDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from SaleChallanDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If


                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))

                            Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                            Dgl1.Item(Col1DocQty, I).Value = AgL.VNull(.Rows(I)("DocQty"))
                            Dgl1.Item(Col1RejQty, I).Value = AgL.VNull(.Rows(I)("RejQty"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.".PadRight(CType(Dgl1.Columns(Col1MeasurePerPcs), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalDocMeasure")), "0.".PadRight(CType(Dgl1.Columns(Col1TotalDocMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1TotalRejMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalRejMeasure")), "0.".PadRight(CType(Dgl1.Columns(Col1TotalRejMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1TotalMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalMeasure")), "0.".PadRight(CType(Dgl1.Columns(Col1TotalMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1Rate, I).Value = AgL.VNull(.Rows(I)("Rate"))
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1InvoicedQty, I).Value = AgL.VNull(.Rows(I)("InvoicedQty"))
                            Dgl1.Item(Col1InvoicedMeasure, I).Value = AgL.VNull(.Rows(I)("InvoicedMeasure"))
                            Dgl1.Item(Col1LotNo, I).Value = AgL.XNull(.Rows(I)("LotNo"))
                            Dgl1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))
                            Dgl1.AgSelectedValue(Col1SaleOrder, I) = AgL.XNull(.Rows(I)("SaleOrder"))
                            Dgl1.AgSelectedValue(Col1DeliveryOrder, I) = AgL.XNull(.Rows(I)("DeliveryOrder"))

                            Call AgCalcGrid1.MoveRec_TransLine(mSearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With

                AgCShowGrid1.MoveRec_FromCalcGrid()
                AgCShowGrid2.MoveRec_FromCalcGrid()
                '-------------------------------------------------------------
            End If
        End With

    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgCalcGrid1.FrmType = Me.FrmType
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtSaleOrderNo.Validating, TxtSaleToParty.Validating, TxtSalesTaxGroupParty.Validating, TxtGateEntryNo.Validating, TxtReferenceNo.Validating
        Dim DrTemp As DataRow()
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    IniGrid()
                    ProcFillReferenceNo()

                Case TxtSaleOrderNo.Name
                    e.Cancel = Not Validate_SaleOrder(TxtSaleOrderNo)
                    If e.Cancel = False Then
                        Validating_SaleOrder(sender.AgSelectedValue)
                    End If

                Case TxtSaleToParty.Name
                    If sender.text.ToString.Trim <> "" Then
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("SubCode = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtCurrency.AgSelectedValue = AgL.XNull(DrTemp(0)("Currency"))
                            TxtSaleToPartyCity.AgSelectedValue = AgL.XNull(DrTemp(0)("CityCode"))
                            TxtSaleToPartyAddress.Text = AgL.XNull(DrTemp(0)("Add1"))
                            TxtSaleToPartyMobile.Text = AgL.XNull(DrTemp(0)("Phone"))
                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("SalesTaxPostingGroup")), "") Then
                                TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                                AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                            End If
                        End If
                    End If

                Case TxtSalesTaxGroupParty.Name
                    AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                    Calculation()

                Case TxtGateEntryNo.Name
                    Validating_GateEntry(TxtGateEntryNo.AgSelectedValue)

                Case TxtReferenceNo.Name
                    e.Cancel = Not FCheckDuplicateRefNo()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_Party()
        Dim DrTemp As DataRow()
        If TxtSaleToParty.AgSelectedValue.ToString.Trim <> "" Then
            If TxtSaleToParty.AgHelpDataSet IsNot Nothing Then
                DrTemp = TxtSaleToParty.AgHelpDataSet.Tables(0).Select("SubCode = " & AgL.Chk_Text(TxtSaleToParty.AgSelectedValue) & "")
                TxtSaleToPartyAddress.Text = AgL.XNull(DrTemp(0)("Add1"))
                TxtSaleToPartyCity.AgSelectedValue = AgL.XNull(DrTemp(0)("CityCode"))
                TxtSaleToPartyMobile.Text = AgL.XNull(DrTemp(0)("State"))
            End If
        Else
            TxtSaleToPartyAddress.Text = ""
            TxtSaleToPartyCity.AgSelectedValue = ""
            TxtSaleToPartyMobile.Text = ""
        End If
    End Sub

    Private Sub Validating_SaleOrder(ByVal Code As String)
        Dim DrTemp As DataRow() = Nothing
        Try
            If TxtSaleOrderNo.Text <> "" Then
                DrTemp = TxtSaleOrderNo.AgHelpDataSet.Tables(0).Select(" Code = '" & Code & "' ")
                If DrTemp.Length > 0 Then
                    TxtCurrency.AgSelectedValue = AgL.XNull(DrTemp(0)("Currency"))
                Else
                    TxtCurrency.AgSelectedValue = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_GateEntry(ByVal Code As String)
        Dim DrTemp As DataRow() = Nothing
        Try
            If TxtGateEntryNo.Text <> "" Then
                DrTemp = TxtGateEntryNo.AgHelpDataSet.Tables(0).Select(" Code = '" & Code & "' ")
                If DrTemp.Length > 0 Then
                    TxtTransporter.AgSelectedValue = AgL.XNull(DrTemp(0)("Transporter"))
                    TxtTruckNo.Text = AgL.XNull(DrTemp(0)("VehicleNo"))
                    TxtLrNo.Text = AgL.XNull(DrTemp(0)("LrNo"))
                    TxtLrDate.Text = AgL.XNull(DrTemp(0)("LrDate"))
                Else
                    TxtTransporter.AgSelectedValue = ""
                    TxtTruckNo.Text = ""
                    TxtLrNo.Text = ""
                    TxtLrDate.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        ProcFillReferenceNo()
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        IniGrid()
        TabControl1.SelectedTab = TP1

        TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupParty"))
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue

        RbtChallanForOrder.Checked = True
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtSaleToParty.AgHelpDataSet(8, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Buyer
        TxtVendorName.AgHelpDataSet(9, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Vendor
        TxtSaleToPartyCity.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.City
        TxtShipToPartyCity.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.City
        TxtCurrency.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Currency
        TxtStructure.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.AgStructure
        TxtSalesTaxGroupParty.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.SalesTaxGroupParty
        TxtBillingType.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.BillingType
        TxtSaleOrderNo.AgHelpDataSet(8, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.SaleOrder
        TxtGodown.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Godown
        TxtForm.AgHelpDataSet(2) = HelpDataSet.Form
        TxtTransporter.AgHelpDataSet(1) = HelpDataSet.Transporter
        TxtFormNo.AgHelpDataSet(3) = HelpDataSet.FormNo
        TxtGateEntryNo.AgHelpDataSet(7) = HelpDataSet.GateEntry

        Dgl1.AgHelpDataSet(Col1SaleOrder) = HelpDataSet.SaleOrder


        TxtDestinationPort.AgHelpDataSet(2, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Port
        TxtPortofLoading.AgHelpDataSet(2, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Port

        Call IniItemList()
    End Sub

    Private Sub IniItemList(Optional ByVal All_Records As Boolean = True)
        If All_Records Then
            Dgl1.AgHelpDataSet(Col1Item, 11) = HelpDataSet.Item
        Else
            Dgl1.AgHelpDataSet(Col1Item, 12) = HelpDataSet.SaleOrderItem
        End If
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DtTemp As DataTable = Nothing
        Try

            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Unit, mRow).Value = ""
                Dgl1.Item(Col1MeasureUnit, mRow).Value = ""
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = 0
                Dgl1.Item(Col1Rate, mRow).Value = 0
                Dgl1.Item(Col1DocQty, mRow).Value = 0
                Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = ""
            Else
                If Dgl1.AgDataRow IsNot Nothing Then
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Unit").Value)
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("MeasureUnit").Value)
                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("MeasurePerPcs").Value)
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("Rate").Value)
                    Dgl1.Item(Col1DocQty, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("BalQty").Value)
                    Dgl1.Item(Col1Qty, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("BalQty").Value)
                    Dgl1.AgSelectedValue(Col1SaleOrder, mRow) = AgL.XNull(Dgl1.AgDataRow.Cells("SaleOrder").Value)
                    Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(Dgl1.AgDataRow.Cells("SalesTaxGroupItem").Value)
                    If AgL.StrCmp(Dgl1.Item(Col1SalesTaxGroup, mRow).Value, "") Then
                        Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
                    End If
                End If
            End If
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
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
                Case Col1Item
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0
        LblTotalMeasure.Text = 0
        LblTotalAmount.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                If Val(Dgl1.Item(Col1DocQty, I).Value) <> 0 And Val(Dgl1.Item(Col1RejQty, I).Value) <> 0 Then
                    Dgl1.Item(Col1Qty, I).Value = Val(Dgl1.Item(Col1DocQty, I).Value) - Val(Dgl1.Item(Col1RejQty, I).Value)
                End If

                Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1TotalMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1TotalDocMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                Dgl1.Item(Col1TotalRejMeasure, I).Value = Format(Val(Dgl1.Item(Col1RejQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1TotalRejMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))

                If AgL.StrCmp(TxtBillingType.Text, "Qty") Or TxtBillingType.Text = "" Then
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                Else
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1TotalDocMeasure, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                End If


                'Footer Calculation
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
            End If
        Next
        AgCalcGrid1.Calculation()
        LblTotalQty.Text = Val(LblTotalQty.Text)
        LblTotalMeasure.Text = Val(LblTotalMeasure.Text)
        LblTotalAmount.Text = Val(LblTotalAmount.Text)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgL.RequiredField(TxtSaleToParty, LblParty.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then passed = False : Exit Sub

        If TxtSaleOrderNo.AgSelectedValue <> "" Then
            If Validate_SaleOrder(TxtSaleOrderNo) = False Then passed = False : Exit Sub
        End If

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If

                    If Val(.Item(Col1Rate, I).Value) = 0 Then
                        MsgBox("Rate Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Rate, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With

        passed = FCheckDuplicateRefNo()

    End Sub

    Private Function FCheckDuplicateRefNo() As Boolean
        FCheckDuplicateRefNo = True
        If Topctrl1.Mode = "Add" Then
            mQry = " SELECT COUNT(*) FROM SaleChallan WHERE ReferenceNo = '" & TxtReferenceNo.Text & "'   " & _
                    " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtReferenceNo.Focus()
        Else
            mQry = " SELECT COUNT(*) FROM SaleChallan WHERE ReferenceNo = '" & TxtReferenceNo.Text & "'  " & _
                    " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0 AND DocID <>'" & mInternalCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtReferenceNo.Focus()
        End If
    End Function

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCurrency.Enter, TxtSaleOrderNo.Enter, TxtFormNo.Enter, TxtSaleToParty.Enter, TxtSalesTaxGroupParty.Enter
        Try
            Select Case sender.name
                Case TxtSaleToParty.Name
                    sender.AgRowFilter = " IsDeleted = 0 " & _
                        " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "

                Case TxtSaleOrderNo.Name
                    sender.AgRowFilter = " IsDeleted = 0 " & _
                        " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                        " And " & ClsMain.RetDivFilterStr & " " & _
                        " AND SaleToParty=" & AgL.Chk_Text(TxtSaleToParty.AgSelectedValue) & " " & _
                        " And V_date <= '" & TxtV_Date.Text & "' "

                Case TxtCurrency.Name
                    sender.AgRowFilter = " IsDeleted = 0 "

                Case TxtForm.Name
                    sender.AgRowFilter = " IsDeleted = 0 And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"

                Case TxtFormNo.Name
                    If BtnRemoveFilter.Tag = 0 Then
                        TxtFormNo.AgRowFilter = " Form = '" & TxtForm.AgSelectedValue & "' " & _
                            " And IsUtilised = 0 " & _
                            " And IssueTo In ('" & TxtSaleToParty.AgSelectedValue & "','" & TxtTransport.AgSelectedValue & "' ) "
                    Else
                        TxtFormNo.AgRowFilter = " Form = '" & TxtForm.AgSelectedValue & "' " & _
                            " And IssueTo In ('" & TxtSaleToParty.AgSelectedValue & "','" & TxtTransport.AgSelectedValue & "' ) "
                    End If
                Case TxtSalesTaxGroupParty.Name
                    TxtSalesTaxGroupParty.AgRowFilter = " Active = 1 "

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        BtnRemoveFilter.Tag = 0
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                If TxtSaleOrderNo.AgSelectedValue <> "" Then
                    Call IniItemList(False)
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                            " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                            " AND BalQty > 0 " & _
                            " And SaleOrder = '" & TxtSaleOrderNo.AgSelectedValue & "' "

                ElseIf RbtChallanForOrder.Checked Then
                    Call IniItemList(False)
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                            " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                            " AND BalQty > 0 "
                Else
                    Call IniItemList()
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                            " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                End If
        End Select
    End Sub

    Private Sub TempGr_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Call ProcUpDateSaleOrder(SearchCode, Conn, Cmd)

        mQry = " UPDATE Form_ReceiveDetail " & _
                " SET IsUtilised = (SELECT Count(*) FROM SaleChallan WITH (NoLock) WHERE FormNo = '" & TxtFormNo.Text & "') " & _
                " WHERE FormNo = '" & TxtFormNo.Text & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Public Sub ProcStockPost(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand, ByVal RowIndex As Integer, ByVal mSr As Integer)
        mQry = "Insert Into Stock_Log(UID, DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                    " SubCode, Currency, SalesTaxGroupParty, Structure, BillingType, Item, LotNo, " & _
                    " Godown, Qty_Iss, Unit, MeasurePerPcs, Measure_Iss, MeasureUnit, " & _
                    " Rate, Amount ) " & _
                    " Values( " & _
                    " '" & mSearchCode & "', '" & mInternalCode & "',  " & Val(mSr) & ", " & _
                    " " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(LblPrefix.Text) & ", " & AgL.Chk_Text(TxtV_Date.Text) & ", " & _
                    " " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtSaleToParty.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtCurrency.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtBillingType.Text) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, RowIndex)) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1LotNo, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1Qty, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1MeasurePerPcs, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1TotalMeasure, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1Rate, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1Amount, RowIndex).Value) & ")  "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub TempGr_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            TxtSaleOrderNo.Enabled = True
            BtnFill.Enabled = True
        Else
            TxtSaleOrderNo.Enabled = False
            BtnFill.Enabled = False
        End If
    End Sub

    Private Sub Dgl1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control = True And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
    End Sub

    Private Sub ProcFillSaleOrderDetails(ByVal bSaleOrder As String)
        Dim DtTemp As DataTable = Nothing
        Dim bReferenceDocId$ = "", bConStr$ = ""
        Dim I As Integer = 0
        Try
            If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then Exit Sub
            Call IniItemList()

            mQry = " SELECT L.Item AS Code, I.Description AS Item , H.PartyOrderNo AS Order_No, H.DocID AS SaleOrder, " & _
                    " L.Unit , L.MeasurePerPcs, L.MeasureUnit,  I.ItemType , L.SalesTaxGroupItem, isnull(H.IsDeleted,0) AS IsDeleted, H.Div_Code , " & _
                    " H.SaleToParty, L.Qty-L.ShippedQty AS BalQty, L.Rate, L.Amount  " & _
                    " FROM SaleOrder H " & _
                    " LEFT JOIN SaleOrderDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN Item I ON I.Code = L.Item  " & _
                    " WHERE H.DocID = " & AgL.Chk_Text(TxtSaleOrderNo.AgSelectedValue) & " And (L.Qty - L.ShippedQty) > 0 "


            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                Dgl1.RowCount = 1
                Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                        Dgl1.AgSelectedValue(Col1SaleOrder, I) = AgL.XNull(.Rows(I)("SaleOrder"))
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Code"))
                        Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                        Dgl1.Item(Col1DocQty, I).Value = AgL.VNull(.Rows(I)("BalQty"))
                        Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.000")
                        Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                        Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                        Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        If Val(Dgl1.Item(Col1DocQty, I).Value) > 0 Then
                            Dgl1.Item(Col1Qty, I).Value = Val(Dgl1.Item(Col1DocQty, I).Value) - Val(Dgl1.Item(Col1RejQty, I).Value)
                        End If

                        Call Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)
                    Next I
                End If
            End With
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        If TxtSaleOrderNo.Text <> "" Then Call ProcFillSaleOrderDetails(TxtSaleOrderNo.AgSelectedValue)
    End Sub

    Private Sub BtnRemoveFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRemoveFilter.Click
        BtnRemoveFilter.Tag = 1
    End Sub

    Private Sub AgCalcGrid1_Calculated() Handles AgCalcGrid1.Calculated
        AgCShowGrid1.MoveRec_FromCalcGrid()
        AgCShowGrid2.MoveRec_FromCalcGrid()
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try
            Dim bRData As String

            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo FROM QCDetail   L LEFT JOIN QC  H ON L.DocId = H.DocID WHERE L.PurchChallan  = '" & TxtDocId.Text & "' And IsNull(H.IsDeleted,0)=0) AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Quality Checking " & bRData & " created against Challan No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If


            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo FROM PurchInvoiceDetail   L LEFT JOIN PurchInvoice  H ON L.DocId = H.DocID WHERE L.PurchChallan  = '" & TxtDocId.Text & "'  And IsNull(H.IsDeleted,0)=0) AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Purchase Invoice " & bRData & " created against Challan No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function


    Private Sub ME_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub ME_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub TempGr_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = "SELECT Sg.SubCode, Sg.DispName AS [Name], Sg.ManualCode, P.Currency, Sg.SalesTaxPostingGroup, SG.Add1, SG.Phone, SG.CityCode, " & _
                " IsNull(Sg.IsDeleted,0) As IsDeleted, IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status , " & _
                " Sg.Div_Code " & _
                " FROM Vendor P " & _
                " LEFT JOIN SubGroup Sg ON P.SubCode = Sg.subCode " & _
                " LEFT JOIN City C ON Sg.CityCode = C.CityCode  " & _
                " LEFT JOIN seaport SP ON P.SeaPort = SP.Code  " & _
                " LEFT JOIN City Dc ON sp.City = Dc.CityCode  "
        HelpDataSet.Vendor = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Sg.SubCode, Sg.DispName AS [Name], Sg.Add1, SG.CityCode, SG.Phone, P.Currency, Sg.SalesTaxPostingGroup, " & _
                " IsNull(Sg.IsDeleted,0) As IsDeleted, IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status , " & _
                " Sg.Div_Code " & _
                " FROM Buyer P " & _
                " LEFT JOIN SubGroup Sg ON P.SubCode = Sg.subCode " & _
                " LEFT JOIN City C ON Sg.CityCode = C.CityCode  " & _
                " LEFT JOIN seaport SP ON P.SeaPort = SP.Code  " & _
                " LEFT JOIN City Dc ON sp.City = Dc.CityCode  "
        HelpDataSet.Buyer = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT CityCode AS Code, CityName, State, ISNULL(Isdeleted,0) AS Isdeleted, " & _
                " Status FROM City "
        HelpDataSet.City = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Code, Description AS Port,ISNULL(Isdeleted,0) AS Isdeleted, " & _
                " Status FROM SeaPort "
        HelpDataSet.Port = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Code AS Currency, IsNull(IsDeleted,0) AS IsDeleted " & _
                " FROM Currency " & _
                " ORDER BY Code "
        HelpDataSet.Currency = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Description  FROM Structure ORDER BY Description "
        HelpDataSet.AgStructure = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Description AS Code, Description, IsNull(Active,0) AS Active FROM PostingGroupSalesTaxParty "
        HelpDataSet.SalesTaxGroupParty = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT 'Qty' AS Code, 'Qty' AS Name " & _
                " Union ALL " & _
                " SELECT 'Area' AS Code, 'Area' AS Name"
        HelpDataSet.BillingType = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT H.DocID AS Code, H.PartyOrderNo AS OrderNo, H.V_Type + '-' + Convert(NVARCHAR, H.V_No) AS [Sale Order No], H.SaleToParty, H.V_date , " & _
                " isnull(H.IsDeleted,0) AS IsDeleted, H.Div_Code , isnull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                " H.MoveToLog, H.Currency" & _
                " FROM SaleOrder H " & _
                " LEFT JOIN SaleOrderDetail L ON L.DocId=H.DocID " & _
                " WHERE H.PartyOrderNo IS NOT NULL "
        HelpDataSet.SaleOrder = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT G.Code AS Code, G.Description AS Godown FROM Godown G "
        HelpDataSet.Godown = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select F.Code, F.Description As Form, " & _
                " IsNull(F.IsDeleted,0) As IsDeleted,  " & _
                " IsNull(F.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status    " & _
                " From Form_Master F " & _
                " Where F.Category = 'Road Permit'"
        HelpDataSet.Form = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT T.SubCode AS Code, Sg.DispName AS Name, Sg.ManualCode " & _
                " FROM Transporter T " & _
                " LEFT JOIN SubGroup Sg ON T.SubCode = Sg.SubCode "
        HelpDataSet.Transporter = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Rd.FormNo AS Code, Rd.FormNo, IsNull(Rd.IsUtilised,0) AS IsUtilised, " & _
                " Rd.IssueTo, Rd.Form " & _
                " FROM Form_ReceiveDetail Rd "
        HelpDataSet.FormNo = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup AS SalesTaxGroupItem, " & _
                    " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                    " I.MeasureUnit, I.Measure As MeasurePerPcs, 0 As Rate, 0 As BalQty, '' AS SaleOrder, " & _
                    " IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                    " FROM Item I "
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT L.Item AS Code, I.Description AS Item , H.PartyOrderNo AS Order_No, H.DocID AS SaleOrder, " & _
                " L.Unit , I.ItemType , L.SalesTaxGroupItem, isnull(H.IsDeleted,0) AS IsDeleted, H.Div_Code , " & _
                " H.SaleToParty, L.Qty-L.ShippedQty AS BalQty, L.MeasurePerPcs, L.MeasureUnit, L.Rate , " & _
                " IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                " FROM SaleOrder H " & _
                " LEFT JOIN SaleOrderDetail L ON L.DocId=H.DocID  " & _
                " LEFT JOIN Item I ON I.Code = L.Item "
        HelpDataSet.SaleOrderItem = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT GIO.DocID AS Code, GIO.V_Type +'-'+ convert(NVARCHAR(5),GIO.V_No) AS [Entry No], " & _
                " GIO.VehicleNo ,GIO.LrNo,GIO.LrDate, GIO.Transporter, GIO.Driver,  " & _
                " IsNull(GIO.IsDeleted ,0) AS IsDeleted, GIO.Div_Code," & _
                " IsNull(GIO.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                " FROM GateInOut GIO "
        HelpDataSet.GateEntry = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Function Validate_SaleOrder(ByVal Sender As Object, Optional ByVal RowIndex As Integer = 0) As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            Select Case Sender.Name
                'Case Dgl1.Name
                '    If Dgl1.AgSelectedValue(Col1SaleOrder, RowIndex) <> "" Then
                '        DrTemp = Dgl1.AgHelpDataSet(Col1SaleOrder).Tables(0).Select("Code = '" & Dgl1.AgSelectedValue(Col1SaleOrder, RowIndex) & "' ")
                '        If DrTemp.Length > 0 Then
                '            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                '                MsgBox("Currently Sale Order """ & Dgl1.Item(Col1SaleOrder, RowIndex).Value & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                '                Dgl1.AgSelectedValue(Col1SaleOrder, RowIndex) = ""
                '                Exit Function
                '            End If

                '            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                '                MsgBox("Currently Sale Order """ & Dgl1.Item(Col1SaleOrder, RowIndex).Value & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                '                Dgl1.AgSelectedValue(Col1SaleOrder, RowIndex) = ""
                '                Exit Function
                '            End If
                '        End If
                '    End If
                '    Validate_SaleOrder = True

                Case TxtSaleOrderNo.Name
                    If TxtSaleOrderNo.AgSelectedValue <> "" Then
                        DrTemp = TxtSaleOrderNo.AgHelpDataSet().Tables(0).Select("Code = '" & TxtSaleOrderNo.AgSelectedValue & "' ")
                        If DrTemp.Length > 0 Then
                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                                MsgBox("Currently Sale Order """ & TxtSaleOrderNo.Text & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                                TxtSaleOrderNo.AgSelectedValue = "" : Exit Function
                            End If

                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                                MsgBox("Currently Sale Order """ & TxtSaleOrderNo.Text & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                                TxtSaleOrderNo.AgSelectedValue = "" : Exit Function
                            End If
                        End If
                    End If
                    Validate_SaleOrder = True
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub ProcFillReferenceNo()
        If TxtReferenceNo.Text = "" Then
            If TxtV_Type.Text.ToString.Trim <> "" Or TxtV_Type.AgSelectedValue.Trim <> "" Then
                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + TxtV_No.Text
            End If
        End If
    End Sub

    Private Sub TempJobReceive_BaseEvent_Approve_PreTrans(ByVal SearchCode As String) Handles Me.BaseEvent_Approve_PreTrans
        mQry = " SELECT L.DocId, L.Item, L.SaleOrder, L.Item, L.Qty, L.TotalMeasure " & _
                " FROM SaleChallanDetail L " & _
                " WHERE L.DocId = '" & mInternalCode & "' "
        DsMain = AgL.FillData(mQry, AgL.GcnRead)
    End Sub

    Private Sub TempSaleChallan_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        Call ProcUpDateSaleOrder(SearchCode, Conn, Cmd)
    End Sub

    Private Sub ProcUpDateSaleOrder(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand)
        Dim I As Integer = 0
        Dim bTableName$ = "", bDocId$ = ""

        With DsMain.Tables(0)
            If .Rows.Count > 0 Then
                For I = 0 To DsMain.Tables(0).Rows.Count - 1
                    mQry = " UPDATE SaleOrderDetail " & _
                            " SET ShippedQty = (SELECT IsNull(Sum(L.Qty),0)  " & _
                            " 				   FROM SaleChallanDetail L " & _
                            "                  LEFT JOIN SaleCHallan H On L.DocId  = H.DocId " & _
                            "                  LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                            " 				   WHERE Vt.NCat = '" & EntryNCat & "' " & _
                            "                  And L.SaleOrder = '" & AgL.XNull(.Rows(I)("SaleOrder")) & "' " & _
                            " 				   And L.Item = '" & AgL.XNull(.Rows(I)("Item")) & "' " & _
                            "                  And IsNull(H.IsDeleted,0)=0), " & _
                            " ShippedMeasure = (SELECT IsNull(Sum(L.TotalMeasure),0)  " & _
                            " 				   FROM SaleChallanDetail L " & _
                            "                  LEFT JOIN SaleCHallan H On L.DocId  = H.DocId " & _
                            "                  LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                            " 				   WHERE Vt.NCat = '" & EntryNCat & "' " & _
                            "                  And L.SaleOrder = '" & AgL.XNull(.Rows(I)("SaleOrder")) & "' " & _
                            " 				   And L.Item = '" & AgL.XNull(.Rows(I)("Item")) & "' " & _
                            "                  And IsNull(H.IsDeleted,0)=0) " & _
                            " Where DocId = '" & AgL.XNull(.Rows(I)("SaleOrder")) & "' " & _
                            " And Item = '" & AgL.XNull(.Rows(I)("Item")) & "'  "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                Next
            End If
        End With

        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = "UPDATE SaleOrderDetail " & _
                            " SET ShippedQty = (SELECT IsNull(Sum(Cd.Qty),0) " & _
                            " 				    FROM SaleChallanDetail Cd With (NoLock) " & _
                            "                   LEFT JOIN SaleChallan C With (NoLock) On Cd.DocId = C.DocId " & _
                            " 				    WHERE Cd.SaleOrder = '" & .AgSelectedValue(Col1SaleOrder, I) & "' " & _
                            " 				    AND Cd.Item = '" & .AgSelectedValue(Col1Item, I) & "' " & _
                            "                   AND IsNull(C.IsDeleted,0) = 0 ), " & _
                            " ShippedMeasure = (SELECT IsNull(Sum(Cd.TotalMeasure),0) " & _
                            " 				    FROM SaleChallanDetail Cd With (NoLock) " & _
                            "                   LEFT JOIN SaleChallan C With (NoLock) On Cd.DocId = C.DocId " & _
                            " 				    WHERE Cd.SaleOrder = '" & .AgSelectedValue(Col1SaleOrder, I) & "' " & _
                            " 				    AND Cd.Item = '" & .AgSelectedValue(Col1Item, I) & "' " & _
                            "                   AND IsNull(C.IsDeleted,0) = 0 ) " & _
                            " WHERE DocId = '" & .AgSelectedValue(Col1SaleOrder, I) & "' " & _
                            " AND Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
    End Sub
End Class
