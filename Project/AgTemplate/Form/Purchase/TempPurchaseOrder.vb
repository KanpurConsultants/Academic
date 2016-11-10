Imports CrystalDecisions.CrystalReports.Engine
Public Class TempPurchaseOrder
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Public WithEvents AgCShowGrid1 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCShowGrid2 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid
    Public WithEvents Dgl1 As AgControls.AgDataGrid

    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Item As String = "Item"
    Protected Const Col1IndentNo As String = "Indent No."
    Protected Const Col1TempIndentNo As String = "Temp Indent No."
    Protected Const Col1TempItem As String = "Temp Item"
    Protected Const Col1PartySKU As String = "Party SKU"
    Protected Const Col1PartyUPC As String = "Party UPC"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1SalesTaxGroup As String = "Sales Tax Group"
    Protected Const Col1xPartySKU As String = "xParty SKU"
    Protected Const Col1xPartyUPC As String = "xParty UPC"

    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1MeasureUnit As String = "MeasureUnit"
    Protected Const Col1ShippedQty As String = "ShippedQty"
    Protected Const Col1ShippedMeasure As String = "ShippedMeasure"

    Dim DtItemDetail As DataTable = Nothing
    Dim Dgl As New AgControls.AgDataGrid
    Dim DtPurchaseEnviro As DataTable = Nothing

    Public Class HelpDataSet
        Public Shared Vendor As DataSet = Nothing
        Public Shared City As DataSet = Nothing
        Public Shared Currency As DataSet = Nothing
        Public Shared AgStructure As DataSet = Nothing
        Public Shared SalesTaxGroupParty As DataSet = Nothing
        Public Shared BillingType As DataSet = Nothing
        Public Shared Agent As DataSet = Nothing
        Public Shared QuotationNo As DataSet = Nothing
        Public Shared PriceMode As DataSet = Nothing
        Public Shared IndentNo As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared ItemFromIndent As DataSet = Nothing
    End Class

    Dim mLastKeyPressed As Keys

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtVendor = New AgControls.AgTextBox
        Me.LblVendor = New System.Windows.Forms.Label
        Me.TxtSaleToPartyAdd1 = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtSaleToPartyAdd2 = New AgControls.AgTextBox
        Me.TxtSaleToPartyCity = New AgControls.AgTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtSaleToPartyState = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtSaleToPartyCountry = New AgControls.AgTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtVendorOrderDate = New AgControls.AgTextBox
        Me.LvlVendoOrdDate = New System.Windows.Forms.Label
        Me.TxtVendorOrdNo = New AgControls.AgTextBox
        Me.LblVendorOrdNo = New System.Windows.Forms.Label
        Me.TxtVendorOrderCancelDate = New AgControls.AgTextBox
        Me.LblVendorCancelDate = New System.Windows.Forms.Label
        Me.TxtVendorDeliveryDate = New AgControls.AgTextBox
        Me.LblVendorDeliveryDate = New System.Windows.Forms.Label
        Me.TxtPriceMode = New AgControls.AgTextBox
        Me.LblPriceMode = New System.Windows.Forms.Label
        Me.TxtCurrency = New AgControls.AgTextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblStockTotalMeasure = New System.Windows.Forms.Label
        Me.LblTotalStockMeasureText = New System.Windows.Forms.Label
        Me.LblTotalMeasure = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtTermsAndConditions = New AgControls.AgTextBox
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtSalesTaxGroupParty = New AgControls.AgTextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.TxtShipToParty = New AgControls.AgTextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TxtShipToPartyAdd1 = New AgControls.AgTextBox
        Me.TxtShipToPartyAdd2 = New AgControls.AgTextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.TxtShipToPartyCity = New AgControls.AgTextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.TxtShipToPartyState = New AgControls.AgTextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.TxtShipToPartyCountry = New AgControls.AgTextBox
        Me.TPShipping = New System.Windows.Forms.TabPage
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtBillingType = New AgControls.AgTextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.TxtAgent = New AgControls.AgTextBox
        Me.LblAgent = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.TxtQutationNo = New AgControls.AgTextBox
        Me.LblQutationNo = New System.Windows.Forms.Label
        Me.TxtIndentNo = New AgControls.AgTextBox
        Me.LblIndentNo = New System.Windows.Forms.Label
        Me.PnlSettings = New System.Windows.Forms.Panel
        Me.BtnOk = New System.Windows.Forms.Button
        Me.TxtShowIndentInLine = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtPaymentTerms = New AgControls.AgTextBox
        Me.LblPaymentTerms = New System.Windows.Forms.Label
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.BtnFill = New System.Windows.Forms.Button
        Me.LblReferenceReq = New System.Windows.Forms.Label
        Me.RbtPOForIndent = New System.Windows.Forms.RadioButton
        Me.RbtPODirect = New System.Windows.Forms.RadioButton
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
        Me.TPShipping.SuspendLayout()
        Me.PnlSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(832, 581)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 581)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 581)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 581)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 581)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 577)
        Me.GroupBox1.Size = New System.Drawing.Size(1022, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(300, 581)
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
        Me.LblV_No.Location = New System.Drawing.Point(233, 29)
        Me.LblV_No.Size = New System.Drawing.Size(64, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Order No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(341, 28)
        Me.TxtV_No.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(111, 34)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(15, 29)
        Me.LblV_Date.Size = New System.Drawing.Size(71, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Order Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(311, 14)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(127, 28)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(233, 10)
        Me.LblV_Type.Size = New System.Drawing.Size(71, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Order Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(341, 8)
        Me.TxtV_Type.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(111, 14)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(15, 9)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(127, 8)
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
        Me.LblPrefix.Location = New System.Drawing.Point(293, 29)
        Me.LblPrefix.Tag = ""
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TPShipping)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(4, 18)
        Me.TabControl1.Size = New System.Drawing.Size(992, 206)
        Me.TabControl1.TabIndex = 0
        Me.TabControl1.Controls.SetChildIndex(Me.TPShipping, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TP1, 0)
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.RbtPODirect)
        Me.TP1.Controls.Add(Me.LblReferenceReq)
        Me.TP1.Controls.Add(Me.BtnFill)
        Me.TP1.Controls.Add(Me.RbtPOForIndent)
        Me.TP1.Controls.Add(Me.TxtPriceMode)
        Me.TP1.Controls.Add(Me.TxtIndentNo)
        Me.TP1.Controls.Add(Me.LblPriceMode)
        Me.TP1.Controls.Add(Me.LblIndentNo)
        Me.TP1.Controls.Add(Me.Label28)
        Me.TP1.Controls.Add(Me.TxtQutationNo)
        Me.TP1.Controls.Add(Me.TxtCurrency)
        Me.TP1.Controls.Add(Me.LblQutationNo)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.TxtAgent)
        Me.TP1.Controls.Add(Me.LblAgent)
        Me.TP1.Controls.Add(Me.TxtBillingType)
        Me.TP1.Controls.Add(Me.Label32)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.TxtSalesTaxGroupParty)
        Me.TP1.Controls.Add(Me.Label27)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.Label13)
        Me.TP1.Controls.Add(Me.TxtVendorOrderCancelDate)
        Me.TP1.Controls.Add(Me.LblVendorCancelDate)
        Me.TP1.Controls.Add(Me.TxtVendorDeliveryDate)
        Me.TP1.Controls.Add(Me.LblVendorDeliveryDate)
        Me.TP1.Controls.Add(Me.TxtVendorOrderDate)
        Me.TP1.Controls.Add(Me.LvlVendoOrdDate)
        Me.TP1.Controls.Add(Me.TxtVendorOrdNo)
        Me.TP1.Controls.Add(Me.LblVendorOrdNo)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyCountry)
        Me.TP1.Controls.Add(Me.Label8)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyState)
        Me.TP1.Controls.Add(Me.Label7)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyCity)
        Me.TP1.Controls.Add(Me.Label6)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyAdd2)
        Me.TP1.Controls.Add(Me.TxtSaleToPartyAdd1)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.TxtVendor)
        Me.TP1.Controls.Add(Me.LblVendor)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(984, 180)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.LblVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyAdd1, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyAdd2, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label6, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyCity, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label7, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyState, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label8, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToPartyCountry, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendorOrdNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorOrdNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LvlVendoOrdDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorOrderDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendorDeliveryDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorDeliveryDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendorCancelDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorOrderCancelDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label13, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label27, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label32, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBillingType, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAgent, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAgent, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblQutationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtQutationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label28, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblIndentNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPriceMode, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtIndentNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPriceMode, 0)
        Me.TP1.Controls.SetChildIndex(Me.RbtPOForIndent, 0)
        Me.TP1.Controls.SetChildIndex(Me.BtnFill, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.RbtPODirect, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(1004, 41)
        Me.Topctrl1.TabIndex = 3
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
        Me.Label4.Location = New System.Drawing.Point(113, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 694
        Me.Label4.Text = "Ä"
        '
        'TxtVendor
        '
        Me.TxtVendor.AgMandatory = True
        Me.TxtVendor.AgMasterHelp = False
        Me.TxtVendor.AgNumberLeftPlaces = 8
        Me.TxtVendor.AgNumberNegetiveAllow = False
        Me.TxtVendor.AgNumberRightPlaces = 2
        Me.TxtVendor.AgPickFromLastValue = False
        Me.TxtVendor.AgRowFilter = ""
        Me.TxtVendor.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendor.AgSelectedValue = Nothing
        Me.TxtVendor.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendor.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVendor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendor.Location = New System.Drawing.Point(127, 48)
        Me.TxtVendor.MaxLength = 0
        Me.TxtVendor.Name = "TxtVendor"
        Me.TxtVendor.Size = New System.Drawing.Size(377, 18)
        Me.TxtVendor.TabIndex = 4
        '
        'LblVendor
        '
        Me.LblVendor.AutoSize = True
        Me.LblVendor.BackColor = System.Drawing.Color.Transparent
        Me.LblVendor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendor.Location = New System.Drawing.Point(15, 48)
        Me.LblVendor.Name = "LblVendor"
        Me.LblVendor.Size = New System.Drawing.Size(48, 16)
        Me.LblVendor.TabIndex = 693
        Me.LblVendor.Text = "Vendor"
        '
        'TxtSaleToPartyAdd1
        '
        Me.TxtSaleToPartyAdd1.AgMandatory = False
        Me.TxtSaleToPartyAdd1.AgMasterHelp = True
        Me.TxtSaleToPartyAdd1.AgNumberLeftPlaces = 8
        Me.TxtSaleToPartyAdd1.AgNumberNegetiveAllow = False
        Me.TxtSaleToPartyAdd1.AgNumberRightPlaces = 2
        Me.TxtSaleToPartyAdd1.AgPickFromLastValue = False
        Me.TxtSaleToPartyAdd1.AgRowFilter = ""
        Me.TxtSaleToPartyAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToPartyAdd1.AgSelectedValue = Nothing
        Me.TxtSaleToPartyAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToPartyAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToPartyAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToPartyAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToPartyAdd1.Location = New System.Drawing.Point(127, 68)
        Me.TxtSaleToPartyAdd1.MaxLength = 20
        Me.TxtSaleToPartyAdd1.Name = "TxtSaleToPartyAdd1"
        Me.TxtSaleToPartyAdd1.Size = New System.Drawing.Size(377, 18)
        Me.TxtSaleToPartyAdd1.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 696
        Me.Label1.Text = "Address"
        '
        'TxtSaleToPartyAdd2
        '
        Me.TxtSaleToPartyAdd2.AgMandatory = False
        Me.TxtSaleToPartyAdd2.AgMasterHelp = True
        Me.TxtSaleToPartyAdd2.AgNumberLeftPlaces = 8
        Me.TxtSaleToPartyAdd2.AgNumberNegetiveAllow = False
        Me.TxtSaleToPartyAdd2.AgNumberRightPlaces = 2
        Me.TxtSaleToPartyAdd2.AgPickFromLastValue = False
        Me.TxtSaleToPartyAdd2.AgRowFilter = ""
        Me.TxtSaleToPartyAdd2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToPartyAdd2.AgSelectedValue = Nothing
        Me.TxtSaleToPartyAdd2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToPartyAdd2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToPartyAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToPartyAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToPartyAdd2.Location = New System.Drawing.Point(127, 88)
        Me.TxtSaleToPartyAdd2.MaxLength = 20
        Me.TxtSaleToPartyAdd2.Name = "TxtSaleToPartyAdd2"
        Me.TxtSaleToPartyAdd2.Size = New System.Drawing.Size(377, 18)
        Me.TxtSaleToPartyAdd2.TabIndex = 6
        '
        'TxtSaleToPartyCity
        '
        Me.TxtSaleToPartyCity.AgMandatory = True
        Me.TxtSaleToPartyCity.AgMasterHelp = False
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
        Me.TxtSaleToPartyCity.Location = New System.Drawing.Point(127, 108)
        Me.TxtSaleToPartyCity.MaxLength = 20
        Me.TxtSaleToPartyCity.Name = "TxtSaleToPartyCity"
        Me.TxtSaleToPartyCity.Size = New System.Drawing.Size(377, 18)
        Me.TxtSaleToPartyCity.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 16)
        Me.Label6.TabIndex = 700
        Me.Label6.Text = "City"
        '
        'TxtSaleToPartyState
        '
        Me.TxtSaleToPartyState.AgMandatory = True
        Me.TxtSaleToPartyState.AgMasterHelp = True
        Me.TxtSaleToPartyState.AgNumberLeftPlaces = 8
        Me.TxtSaleToPartyState.AgNumberNegetiveAllow = False
        Me.TxtSaleToPartyState.AgNumberRightPlaces = 2
        Me.TxtSaleToPartyState.AgPickFromLastValue = False
        Me.TxtSaleToPartyState.AgRowFilter = ""
        Me.TxtSaleToPartyState.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToPartyState.AgSelectedValue = Nothing
        Me.TxtSaleToPartyState.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToPartyState.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToPartyState.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToPartyState.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToPartyState.Location = New System.Drawing.Point(127, 128)
        Me.TxtSaleToPartyState.MaxLength = 20
        Me.TxtSaleToPartyState.Name = "TxtSaleToPartyState"
        Me.TxtSaleToPartyState.Size = New System.Drawing.Size(134, 18)
        Me.TxtSaleToPartyState.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(15, 128)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 16)
        Me.Label7.TabIndex = 702
        Me.Label7.Text = "State"
        '
        'TxtSaleToPartyCountry
        '
        Me.TxtSaleToPartyCountry.AgMandatory = True
        Me.TxtSaleToPartyCountry.AgMasterHelp = True
        Me.TxtSaleToPartyCountry.AgNumberLeftPlaces = 8
        Me.TxtSaleToPartyCountry.AgNumberNegetiveAllow = False
        Me.TxtSaleToPartyCountry.AgNumberRightPlaces = 2
        Me.TxtSaleToPartyCountry.AgPickFromLastValue = False
        Me.TxtSaleToPartyCountry.AgRowFilter = ""
        Me.TxtSaleToPartyCountry.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToPartyCountry.AgSelectedValue = Nothing
        Me.TxtSaleToPartyCountry.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToPartyCountry.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToPartyCountry.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToPartyCountry.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToPartyCountry.Location = New System.Drawing.Point(358, 128)
        Me.TxtSaleToPartyCountry.MaxLength = 20
        Me.TxtSaleToPartyCountry.Name = "TxtSaleToPartyCountry"
        Me.TxtSaleToPartyCountry.Size = New System.Drawing.Size(146, 18)
        Me.TxtSaleToPartyCountry.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(264, 129)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 16)
        Me.Label8.TabIndex = 704
        Me.Label8.Text = "Country"
        '
        'TxtVendorOrderDate
        '
        Me.TxtVendorOrderDate.AgMandatory = False
        Me.TxtVendorOrderDate.AgMasterHelp = True
        Me.TxtVendorOrderDate.AgNumberLeftPlaces = 8
        Me.TxtVendorOrderDate.AgNumberNegetiveAllow = False
        Me.TxtVendorOrderDate.AgNumberRightPlaces = 2
        Me.TxtVendorOrderDate.AgPickFromLastValue = False
        Me.TxtVendorOrderDate.AgRowFilter = ""
        Me.TxtVendorOrderDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendorOrderDate.AgSelectedValue = Nothing
        Me.TxtVendorOrderDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendorOrderDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtVendorOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendorOrderDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendorOrderDate.Location = New System.Drawing.Point(866, 47)
        Me.TxtVendorOrderDate.MaxLength = 20
        Me.TxtVendorOrderDate.Name = "TxtVendorOrderDate"
        Me.TxtVendorOrderDate.Size = New System.Drawing.Size(104, 18)
        Me.TxtVendorOrderDate.TabIndex = 14
        '
        'LvlVendoOrdDate
        '
        Me.LvlVendoOrdDate.AutoSize = True
        Me.LvlVendoOrdDate.BackColor = System.Drawing.Color.Transparent
        Me.LvlVendoOrdDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvlVendoOrdDate.Location = New System.Drawing.Point(756, 47)
        Me.LvlVendoOrdDate.Name = "LvlVendoOrdDate"
        Me.LvlVendoOrdDate.Size = New System.Drawing.Size(105, 16)
        Me.LvlVendoOrdDate.TabIndex = 708
        Me.LvlVendoOrdDate.Text = "Vendor Order Dt."
        '
        'TxtVendorOrdNo
        '
        Me.TxtVendorOrdNo.AgMandatory = False
        Me.TxtVendorOrdNo.AgMasterHelp = True
        Me.TxtVendorOrdNo.AgNumberLeftPlaces = 8
        Me.TxtVendorOrdNo.AgNumberNegetiveAllow = False
        Me.TxtVendorOrdNo.AgNumberRightPlaces = 2
        Me.TxtVendorOrdNo.AgPickFromLastValue = False
        Me.TxtVendorOrdNo.AgRowFilter = ""
        Me.TxtVendorOrdNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendorOrdNo.AgSelectedValue = Nothing
        Me.TxtVendorOrdNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendorOrdNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVendorOrdNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendorOrdNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendorOrdNo.Location = New System.Drawing.Point(628, 46)
        Me.TxtVendorOrdNo.MaxLength = 20
        Me.TxtVendorOrdNo.Name = "TxtVendorOrdNo"
        Me.TxtVendorOrdNo.Size = New System.Drawing.Size(126, 18)
        Me.TxtVendorOrdNo.TabIndex = 13
        '
        'LblVendorOrdNo
        '
        Me.LblVendorOrdNo.AutoSize = True
        Me.LblVendorOrdNo.BackColor = System.Drawing.Color.Transparent
        Me.LblVendorOrdNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendorOrdNo.Location = New System.Drawing.Point(512, 48)
        Me.LblVendorOrdNo.Name = "LblVendorOrdNo"
        Me.LblVendorOrdNo.Size = New System.Drawing.Size(108, 16)
        Me.LblVendorOrdNo.TabIndex = 706
        Me.LblVendorOrdNo.Text = "Vendor Order No."
        '
        'TxtVendorOrderCancelDate
        '
        Me.TxtVendorOrderCancelDate.AgMandatory = False
        Me.TxtVendorOrderCancelDate.AgMasterHelp = True
        Me.TxtVendorOrderCancelDate.AgNumberLeftPlaces = 8
        Me.TxtVendorOrderCancelDate.AgNumberNegetiveAllow = False
        Me.TxtVendorOrderCancelDate.AgNumberRightPlaces = 2
        Me.TxtVendorOrderCancelDate.AgPickFromLastValue = False
        Me.TxtVendorOrderCancelDate.AgRowFilter = ""
        Me.TxtVendorOrderCancelDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendorOrderCancelDate.AgSelectedValue = Nothing
        Me.TxtVendorOrderCancelDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendorOrderCancelDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtVendorOrderCancelDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendorOrderCancelDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendorOrderCancelDate.Location = New System.Drawing.Point(866, 66)
        Me.TxtVendorOrderCancelDate.MaxLength = 20
        Me.TxtVendorOrderCancelDate.Name = "TxtVendorOrderCancelDate"
        Me.TxtVendorOrderCancelDate.Size = New System.Drawing.Size(104, 18)
        Me.TxtVendorOrderCancelDate.TabIndex = 16
        '
        'LblVendorCancelDate
        '
        Me.LblVendorCancelDate.AutoSize = True
        Me.LblVendorCancelDate.BackColor = System.Drawing.Color.Transparent
        Me.LblVendorCancelDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendorCancelDate.Location = New System.Drawing.Point(756, 66)
        Me.LblVendorCancelDate.Name = "LblVendorCancelDate"
        Me.LblVendorCancelDate.Size = New System.Drawing.Size(113, 16)
        Me.LblVendorCancelDate.TabIndex = 712
        Me.LblVendorCancelDate.Text = "Vendor Cancel Dt."
        '
        'TxtVendorDeliveryDate
        '
        Me.TxtVendorDeliveryDate.AgMandatory = False
        Me.TxtVendorDeliveryDate.AgMasterHelp = True
        Me.TxtVendorDeliveryDate.AgNumberLeftPlaces = 8
        Me.TxtVendorDeliveryDate.AgNumberNegetiveAllow = False
        Me.TxtVendorDeliveryDate.AgNumberRightPlaces = 2
        Me.TxtVendorDeliveryDate.AgPickFromLastValue = False
        Me.TxtVendorDeliveryDate.AgRowFilter = ""
        Me.TxtVendorDeliveryDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendorDeliveryDate.AgSelectedValue = Nothing
        Me.TxtVendorDeliveryDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendorDeliveryDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtVendorDeliveryDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendorDeliveryDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendorDeliveryDate.Location = New System.Drawing.Point(628, 65)
        Me.TxtVendorDeliveryDate.MaxLength = 20
        Me.TxtVendorDeliveryDate.Name = "TxtVendorDeliveryDate"
        Me.TxtVendorDeliveryDate.Size = New System.Drawing.Size(126, 18)
        Me.TxtVendorDeliveryDate.TabIndex = 15
        '
        'LblVendorDeliveryDate
        '
        Me.LblVendorDeliveryDate.AutoSize = True
        Me.LblVendorDeliveryDate.BackColor = System.Drawing.Color.Transparent
        Me.LblVendorDeliveryDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendorDeliveryDate.Location = New System.Drawing.Point(512, 67)
        Me.LblVendorDeliveryDate.Name = "LblVendorDeliveryDate"
        Me.LblVendorDeliveryDate.Size = New System.Drawing.Size(118, 16)
        Me.LblVendorDeliveryDate.TabIndex = 710
        Me.LblVendorDeliveryDate.Text = "Vendor Delivery Dt."
        '
        'TxtPriceMode
        '
        Me.TxtPriceMode.AgMandatory = False
        Me.TxtPriceMode.AgMasterHelp = False
        Me.TxtPriceMode.AgNumberLeftPlaces = 8
        Me.TxtPriceMode.AgNumberNegetiveAllow = False
        Me.TxtPriceMode.AgNumberRightPlaces = 2
        Me.TxtPriceMode.AgPickFromLastValue = False
        Me.TxtPriceMode.AgRowFilter = ""
        Me.TxtPriceMode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPriceMode.AgSelectedValue = Nothing
        Me.TxtPriceMode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPriceMode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPriceMode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPriceMode.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPriceMode.Location = New System.Drawing.Point(866, 85)
        Me.TxtPriceMode.MaxLength = 50
        Me.TxtPriceMode.Name = "TxtPriceMode"
        Me.TxtPriceMode.Size = New System.Drawing.Size(104, 18)
        Me.TxtPriceMode.TabIndex = 730
        '
        'LblPriceMode
        '
        Me.LblPriceMode.AutoSize = True
        Me.LblPriceMode.BackColor = System.Drawing.Color.Transparent
        Me.LblPriceMode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPriceMode.Location = New System.Drawing.Point(756, 84)
        Me.LblPriceMode.Name = "LblPriceMode"
        Me.LblPriceMode.Size = New System.Drawing.Size(74, 16)
        Me.LblPriceMode.TabIndex = 731
        Me.LblPriceMode.Text = "Price Mode"
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
        Me.TxtCurrency.Location = New System.Drawing.Point(628, 85)
        Me.TxtCurrency.MaxLength = 20
        Me.TxtCurrency.Name = "TxtCurrency"
        Me.TxtCurrency.Size = New System.Drawing.Size(126, 18)
        Me.TxtCurrency.TabIndex = 17
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(512, 85)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(60, 16)
        Me.Label28.TabIndex = 717
        Me.Label28.Text = "Currency"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblStockTotalMeasure)
        Me.Panel1.Controls.Add(Me.LblTotalStockMeasureText)
        Me.Panel1.Controls.Add(Me.LblTotalMeasure)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Location = New System.Drawing.Point(4, 402)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(992, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblStockTotalMeasure
        '
        Me.LblStockTotalMeasure.AutoSize = True
        Me.LblStockTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStockTotalMeasure.ForeColor = System.Drawing.Color.Black
        Me.LblStockTotalMeasure.Location = New System.Drawing.Point(656, 3)
        Me.LblStockTotalMeasure.Name = "LblStockTotalMeasure"
        Me.LblStockTotalMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblStockTotalMeasure.TabIndex = 712
        Me.LblStockTotalMeasure.Text = "."
        Me.LblStockTotalMeasure.Visible = False
        '
        'LblTotalStockMeasureText
        '
        Me.LblTotalStockMeasureText.AutoSize = True
        Me.LblTotalStockMeasureText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalStockMeasureText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalStockMeasureText.Location = New System.Drawing.Point(507, 3)
        Me.LblTotalStockMeasureText.Name = "LblTotalStockMeasureText"
        Me.LblTotalStockMeasureText.Size = New System.Drawing.Size(144, 16)
        Me.LblTotalStockMeasureText.TabIndex = 711
        Me.LblTotalStockMeasureText.Text = "Total Stock Measure :"
        Me.LblTotalStockMeasureText.Visible = False
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.AutoSize = True
        Me.LblTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalMeasure.Location = New System.Drawing.Point(382, 3)
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
        Me.Label33.Location = New System.Drawing.Point(271, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(105, 16)
        Me.Label33.TabIndex = 665
        Me.Label33.Text = "Total Measure :"
        Me.Label33.Visible = False
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.AutoSize = True
        Me.LblTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalAmount.Location = New System.Drawing.Point(871, 3)
        Me.LblTotalAmount.Name = "LblTotalAmount"
        Me.LblTotalAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalAmount.TabIndex = 662
        Me.LblTotalAmount.Text = "."
        Me.LblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.AutoSize = True
        Me.LblTotalAmountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmountText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalAmountText.Location = New System.Drawing.Point(767, 3)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(100, 16)
        Me.LblTotalAmountText.TabIndex = 661
        Me.LblTotalAmountText.Text = "Total Amount :"
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalQty.Location = New System.Drawing.Point(116, 3)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 660
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.AutoSize = True
        Me.LblTotalQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQtyText.Location = New System.Drawing.Point(31, 3)
        Me.LblTotalQtyText.Name = "LblTotalQtyText"
        Me.LblTotalQtyText.Size = New System.Drawing.Size(72, 16)
        Me.LblTotalQtyText.TabIndex = 659
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(4, 249)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(992, 152)
        Me.Pnl1.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(113, 115)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 7)
        Me.Label13.TabIndex = 713
        Me.Label13.Text = "Ä"
        '
        'TxtTermsAndConditions
        '
        Me.TxtTermsAndConditions.AgMandatory = False
        Me.TxtTermsAndConditions.AgMasterHelp = True
        Me.TxtTermsAndConditions.AgNumberLeftPlaces = 8
        Me.TxtTermsAndConditions.AgNumberNegetiveAllow = False
        Me.TxtTermsAndConditions.AgNumberRightPlaces = 2
        Me.TxtTermsAndConditions.AgPickFromLastValue = False
        Me.TxtTermsAndConditions.AgRowFilter = ""
        Me.TxtTermsAndConditions.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTermsAndConditions.AgSelectedValue = Nothing
        Me.TxtTermsAndConditions.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTermsAndConditions.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTermsAndConditions.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTermsAndConditions.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTermsAndConditions.Location = New System.Drawing.Point(8, 447)
        Me.TxtTermsAndConditions.MaxLength = 0
        Me.TxtTermsAndConditions.Multiline = True
        Me.TxtTermsAndConditions.Name = "TxtTermsAndConditions"
        Me.TxtTermsAndConditions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtTermsAndConditions.Size = New System.Drawing.Size(465, 50)
        Me.TxtTermsAndConditions.TabIndex = 2
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnlCalcGrid.Location = New System.Drawing.Point(835, 431)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(161, 140)
        Me.PnlCalcGrid.TabIndex = 694
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(6, 428)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(114, 16)
        Me.Label26.TabIndex = 715
        Me.Label26.Text = "Terms && Condition"
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
        Me.TxtStructure.Location = New System.Drawing.Point(891, 127)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(87, 18)
        Me.TxtStructure.TabIndex = 16
        Me.TxtStructure.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(824, 128)
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
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(771, 127)
        Me.TxtSalesTaxGroupParty.MaxLength = 20
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(55, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 15
        Me.TxtSalesTaxGroupParty.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(670, 127)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(104, 16)
        Me.Label27.TabIndex = 717
        Me.Label27.Text = "Sales Tax Group"
        Me.Label27.Visible = False
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(13, 15)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(84, 16)
        Me.Label24.TabIndex = 715
        Me.Label24.Text = "Ship to Party"
        '
        'TxtShipToParty
        '
        Me.TxtShipToParty.AgMandatory = False
        Me.TxtShipToParty.AgMasterHelp = True
        Me.TxtShipToParty.AgNumberLeftPlaces = 8
        Me.TxtShipToParty.AgNumberNegetiveAllow = False
        Me.TxtShipToParty.AgNumberRightPlaces = 2
        Me.TxtShipToParty.AgPickFromLastValue = False
        Me.TxtShipToParty.AgRowFilter = ""
        Me.TxtShipToParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShipToParty.AgSelectedValue = Nothing
        Me.TxtShipToParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShipToParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShipToParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShipToParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShipToParty.Location = New System.Drawing.Point(125, 15)
        Me.TxtShipToParty.MaxLength = 20
        Me.TxtShipToParty.Name = "TxtShipToParty"
        Me.TxtShipToParty.Size = New System.Drawing.Size(377, 18)
        Me.TxtShipToParty.TabIndex = 22
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(13, 35)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(56, 16)
        Me.Label22.TabIndex = 718
        Me.Label22.Text = "Address"
        '
        'TxtShipToPartyAdd1
        '
        Me.TxtShipToPartyAdd1.AgMandatory = False
        Me.TxtShipToPartyAdd1.AgMasterHelp = True
        Me.TxtShipToPartyAdd1.AgNumberLeftPlaces = 8
        Me.TxtShipToPartyAdd1.AgNumberNegetiveAllow = False
        Me.TxtShipToPartyAdd1.AgNumberRightPlaces = 2
        Me.TxtShipToPartyAdd1.AgPickFromLastValue = False
        Me.TxtShipToPartyAdd1.AgRowFilter = ""
        Me.TxtShipToPartyAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShipToPartyAdd1.AgSelectedValue = Nothing
        Me.TxtShipToPartyAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShipToPartyAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShipToPartyAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShipToPartyAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShipToPartyAdd1.Location = New System.Drawing.Point(125, 35)
        Me.TxtShipToPartyAdd1.MaxLength = 20
        Me.TxtShipToPartyAdd1.Name = "TxtShipToPartyAdd1"
        Me.TxtShipToPartyAdd1.Size = New System.Drawing.Size(377, 18)
        Me.TxtShipToPartyAdd1.TabIndex = 23
        '
        'TxtShipToPartyAdd2
        '
        Me.TxtShipToPartyAdd2.AgMandatory = False
        Me.TxtShipToPartyAdd2.AgMasterHelp = True
        Me.TxtShipToPartyAdd2.AgNumberLeftPlaces = 8
        Me.TxtShipToPartyAdd2.AgNumberNegetiveAllow = False
        Me.TxtShipToPartyAdd2.AgNumberRightPlaces = 2
        Me.TxtShipToPartyAdd2.AgPickFromLastValue = False
        Me.TxtShipToPartyAdd2.AgRowFilter = ""
        Me.TxtShipToPartyAdd2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShipToPartyAdd2.AgSelectedValue = Nothing
        Me.TxtShipToPartyAdd2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShipToPartyAdd2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShipToPartyAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShipToPartyAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShipToPartyAdd2.Location = New System.Drawing.Point(125, 55)
        Me.TxtShipToPartyAdd2.MaxLength = 20
        Me.TxtShipToPartyAdd2.Name = "TxtShipToPartyAdd2"
        Me.TxtShipToPartyAdd2.Size = New System.Drawing.Size(377, 18)
        Me.TxtShipToPartyAdd2.TabIndex = 24
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(13, 75)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(31, 16)
        Me.Label21.TabIndex = 721
        Me.Label21.Text = "City"
        '
        'TxtShipToPartyCity
        '
        Me.TxtShipToPartyCity.AgMandatory = False
        Me.TxtShipToPartyCity.AgMasterHelp = True
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
        Me.TxtShipToPartyCity.Location = New System.Drawing.Point(125, 75)
        Me.TxtShipToPartyCity.MaxLength = 20
        Me.TxtShipToPartyCity.Name = "TxtShipToPartyCity"
        Me.TxtShipToPartyCity.Size = New System.Drawing.Size(377, 18)
        Me.TxtShipToPartyCity.TabIndex = 25
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.BackColor = System.Drawing.Color.Transparent
        Me.Label20.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(13, 95)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(39, 16)
        Me.Label20.TabIndex = 723
        Me.Label20.Text = "State"
        '
        'TxtShipToPartyState
        '
        Me.TxtShipToPartyState.AgMandatory = False
        Me.TxtShipToPartyState.AgMasterHelp = True
        Me.TxtShipToPartyState.AgNumberLeftPlaces = 8
        Me.TxtShipToPartyState.AgNumberNegetiveAllow = False
        Me.TxtShipToPartyState.AgNumberRightPlaces = 2
        Me.TxtShipToPartyState.AgPickFromLastValue = False
        Me.TxtShipToPartyState.AgRowFilter = ""
        Me.TxtShipToPartyState.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShipToPartyState.AgSelectedValue = Nothing
        Me.TxtShipToPartyState.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShipToPartyState.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShipToPartyState.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShipToPartyState.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShipToPartyState.Location = New System.Drawing.Point(125, 95)
        Me.TxtShipToPartyState.MaxLength = 20
        Me.TxtShipToPartyState.Name = "TxtShipToPartyState"
        Me.TxtShipToPartyState.Size = New System.Drawing.Size(134, 18)
        Me.TxtShipToPartyState.TabIndex = 26
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(262, 96)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(53, 16)
        Me.Label19.TabIndex = 725
        Me.Label19.Text = "Country"
        '
        'TxtShipToPartyCountry
        '
        Me.TxtShipToPartyCountry.AgMandatory = False
        Me.TxtShipToPartyCountry.AgMasterHelp = True
        Me.TxtShipToPartyCountry.AgNumberLeftPlaces = 8
        Me.TxtShipToPartyCountry.AgNumberNegetiveAllow = False
        Me.TxtShipToPartyCountry.AgNumberRightPlaces = 2
        Me.TxtShipToPartyCountry.AgPickFromLastValue = False
        Me.TxtShipToPartyCountry.AgRowFilter = ""
        Me.TxtShipToPartyCountry.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShipToPartyCountry.AgSelectedValue = Nothing
        Me.TxtShipToPartyCountry.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShipToPartyCountry.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShipToPartyCountry.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShipToPartyCountry.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShipToPartyCountry.Location = New System.Drawing.Point(356, 95)
        Me.TxtShipToPartyCountry.MaxLength = 20
        Me.TxtShipToPartyCountry.Name = "TxtShipToPartyCountry"
        Me.TxtShipToPartyCountry.Size = New System.Drawing.Size(146, 18)
        Me.TxtShipToPartyCountry.TabIndex = 27
        '
        'TPShipping
        '
        Me.TPShipping.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TPShipping.Controls.Add(Me.TxtShipToPartyCountry)
        Me.TPShipping.Controls.Add(Me.Label19)
        Me.TPShipping.Controls.Add(Me.TxtShipToPartyState)
        Me.TPShipping.Controls.Add(Me.Label20)
        Me.TPShipping.Controls.Add(Me.TxtShipToPartyCity)
        Me.TPShipping.Controls.Add(Me.Label21)
        Me.TPShipping.Controls.Add(Me.TxtShipToPartyAdd2)
        Me.TPShipping.Controls.Add(Me.TxtShipToPartyAdd1)
        Me.TPShipping.Controls.Add(Me.Label22)
        Me.TPShipping.Controls.Add(Me.TxtShipToParty)
        Me.TPShipping.Controls.Add(Me.Label24)
        Me.TPShipping.Location = New System.Drawing.Point(4, 22)
        Me.TPShipping.Name = "TPShipping"
        Me.TPShipping.Size = New System.Drawing.Size(984, 180)
        Me.TPShipping.TabIndex = 2
        Me.TPShipping.Text = "Shipping Detail"
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
        Me.TxtRemarks.Location = New System.Drawing.Point(628, 105)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(342, 18)
        Me.TxtRemarks.TabIndex = 18
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(512, 106)
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
        Me.TxtBillingType.Location = New System.Drawing.Point(628, 126)
        Me.TxtBillingType.MaxLength = 20
        Me.TxtBillingType.Name = "TxtBillingType"
        Me.TxtBillingType.Size = New System.Drawing.Size(36, 18)
        Me.TxtBillingType.TabIndex = 726
        Me.TxtBillingType.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(512, 126)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(64, 16)
        Me.Label32.TabIndex = 727
        Me.Label32.Text = "Billing On"
        Me.Label32.Visible = False
        '
        'TxtAgent
        '
        Me.TxtAgent.AgMandatory = False
        Me.TxtAgent.AgMasterHelp = False
        Me.TxtAgent.AgNumberLeftPlaces = 8
        Me.TxtAgent.AgNumberNegetiveAllow = False
        Me.TxtAgent.AgNumberRightPlaces = 2
        Me.TxtAgent.AgPickFromLastValue = False
        Me.TxtAgent.AgRowFilter = ""
        Me.TxtAgent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAgent.AgSelectedValue = Nothing
        Me.TxtAgent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAgent.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAgent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAgent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAgent.Location = New System.Drawing.Point(916, 6)
        Me.TxtAgent.MaxLength = 0
        Me.TxtAgent.Name = "TxtAgent"
        Me.TxtAgent.Size = New System.Drawing.Size(36, 18)
        Me.TxtAgent.TabIndex = 17
        Me.TxtAgent.Visible = False
        '
        'LblAgent
        '
        Me.LblAgent.AutoSize = True
        Me.LblAgent.BackColor = System.Drawing.Color.Transparent
        Me.LblAgent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAgent.Location = New System.Drawing.Point(868, 6)
        Me.LblAgent.Name = "LblAgent"
        Me.LblAgent.Size = New System.Drawing.Size(42, 16)
        Me.LblAgent.TabIndex = 729
        Me.LblAgent.Text = "Agent"
        Me.LblAgent.Visible = False
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(628, 8)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(126, 18)
        Me.TxtReferenceNo.TabIndex = 10
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(512, 10)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(103, 16)
        Me.LblReferenceNo.TabIndex = 731
        Me.LblReferenceNo.Text = "Manual Ord. No."
        '
        'TxtQutationNo
        '
        Me.TxtQutationNo.AgMandatory = False
        Me.TxtQutationNo.AgMasterHelp = False
        Me.TxtQutationNo.AgNumberLeftPlaces = 8
        Me.TxtQutationNo.AgNumberNegetiveAllow = False
        Me.TxtQutationNo.AgNumberRightPlaces = 2
        Me.TxtQutationNo.AgPickFromLastValue = False
        Me.TxtQutationNo.AgRowFilter = ""
        Me.TxtQutationNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtQutationNo.AgSelectedValue = Nothing
        Me.TxtQutationNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtQutationNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtQutationNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtQutationNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQutationNo.Location = New System.Drawing.Point(628, 27)
        Me.TxtQutationNo.MaxLength = 20
        Me.TxtQutationNo.Name = "TxtQutationNo"
        Me.TxtQutationNo.Size = New System.Drawing.Size(126, 18)
        Me.TxtQutationNo.TabIndex = 11
        '
        'LblQutationNo
        '
        Me.LblQutationNo.AutoSize = True
        Me.LblQutationNo.BackColor = System.Drawing.Color.Transparent
        Me.LblQutationNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblQutationNo.Location = New System.Drawing.Point(512, 29)
        Me.LblQutationNo.Name = "LblQutationNo"
        Me.LblQutationNo.Size = New System.Drawing.Size(88, 16)
        Me.LblQutationNo.TabIndex = 733
        Me.LblQutationNo.Text = "Quotation No."
        '
        'TxtIndentNo
        '
        Me.TxtIndentNo.AgMandatory = False
        Me.TxtIndentNo.AgMasterHelp = False
        Me.TxtIndentNo.AgNumberLeftPlaces = 8
        Me.TxtIndentNo.AgNumberNegetiveAllow = False
        Me.TxtIndentNo.AgNumberRightPlaces = 2
        Me.TxtIndentNo.AgPickFromLastValue = False
        Me.TxtIndentNo.AgRowFilter = ""
        Me.TxtIndentNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIndentNo.AgSelectedValue = Nothing
        Me.TxtIndentNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIndentNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtIndentNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIndentNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIndentNo.Location = New System.Drawing.Point(866, 27)
        Me.TxtIndentNo.MaxLength = 20
        Me.TxtIndentNo.Name = "TxtIndentNo"
        Me.TxtIndentNo.Size = New System.Drawing.Size(86, 18)
        Me.TxtIndentNo.TabIndex = 12
        '
        'LblIndentNo
        '
        Me.LblIndentNo.AutoSize = True
        Me.LblIndentNo.BackColor = System.Drawing.Color.Transparent
        Me.LblIndentNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIndentNo.Location = New System.Drawing.Point(756, 28)
        Me.LblIndentNo.Name = "LblIndentNo"
        Me.LblIndentNo.Size = New System.Drawing.Size(71, 16)
        Me.LblIndentNo.TabIndex = 735
        Me.LblIndentNo.Text = "Indent No. "
        '
        'PnlSettings
        '
        Me.PnlSettings.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PnlSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlSettings.Controls.Add(Me.BtnOk)
        Me.PnlSettings.Controls.Add(Me.TxtShowIndentInLine)
        Me.PnlSettings.Controls.Add(Me.Label3)
        Me.PnlSettings.Location = New System.Drawing.Point(4, 486)
        Me.PnlSettings.Name = "PnlSettings"
        Me.PnlSettings.Size = New System.Drawing.Size(257, 85)
        Me.PnlSettings.TabIndex = 736
        Me.PnlSettings.Visible = False
        '
        'BtnOk
        '
        Me.BtnOk.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(201, 57)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(48, 23)
        Me.BtnOk.TabIndex = 732
        Me.BtnOk.Text = "Ok"
        Me.BtnOk.UseVisualStyleBackColor = True
        '
        'TxtShowIndentInLine
        '
        Me.TxtShowIndentInLine.AgMandatory = False
        Me.TxtShowIndentInLine.AgMasterHelp = False
        Me.TxtShowIndentInLine.AgNumberLeftPlaces = 0
        Me.TxtShowIndentInLine.AgNumberNegetiveAllow = False
        Me.TxtShowIndentInLine.AgNumberRightPlaces = 0
        Me.TxtShowIndentInLine.AgPickFromLastValue = False
        Me.TxtShowIndentInLine.AgRowFilter = ""
        Me.TxtShowIndentInLine.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShowIndentInLine.AgSelectedValue = Nothing
        Me.TxtShowIndentInLine.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShowIndentInLine.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtShowIndentInLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtShowIndentInLine.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShowIndentInLine.Location = New System.Drawing.Point(201, 3)
        Me.TxtShowIndentInLine.MaxLength = 20
        Me.TxtShowIndentInLine.Name = "TxtShowIndentInLine"
        Me.TxtShowIndentInLine.Size = New System.Drawing.Size(48, 22)
        Me.TxtShowIndentInLine.TabIndex = 731
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(192, 14)
        Me.Label3.TabIndex = 730
        Me.Label3.Text = "Show Indent No In Line File ?"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 227)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(230, 20)
        Me.LinkLabel1.TabIndex = 737
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Purchase Order For Following Items"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtPaymentTerms
        '
        Me.TxtPaymentTerms.AgMandatory = False
        Me.TxtPaymentTerms.AgMasterHelp = False
        Me.TxtPaymentTerms.AgNumberLeftPlaces = 0
        Me.TxtPaymentTerms.AgNumberNegetiveAllow = False
        Me.TxtPaymentTerms.AgNumberRightPlaces = 0
        Me.TxtPaymentTerms.AgPickFromLastValue = False
        Me.TxtPaymentTerms.AgRowFilter = ""
        Me.TxtPaymentTerms.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPaymentTerms.AgSelectedValue = Nothing
        Me.TxtPaymentTerms.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPaymentTerms.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPaymentTerms.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPaymentTerms.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPaymentTerms.Location = New System.Drawing.Point(9, 522)
        Me.TxtPaymentTerms.MaxLength = 255
        Me.TxtPaymentTerms.Multiline = True
        Me.TxtPaymentTerms.Name = "TxtPaymentTerms"
        Me.TxtPaymentTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtPaymentTerms.Size = New System.Drawing.Size(464, 49)
        Me.TxtPaymentTerms.TabIndex = 736
        Me.TxtPaymentTerms.Visible = False
        '
        'LblPaymentTerms
        '
        Me.LblPaymentTerms.AutoSize = True
        Me.LblPaymentTerms.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPaymentTerms.Location = New System.Drawing.Point(7, 501)
        Me.LblPaymentTerms.Name = "LblPaymentTerms"
        Me.LblPaymentTerms.Size = New System.Drawing.Size(99, 16)
        Me.LblPaymentTerms.TabIndex = 737
        Me.LblPaymentTerms.Text = "Payment Terms"
        Me.LblPaymentTerms.Visible = False
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(678, 431)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(151, 140)
        Me.PnlCShowGrid.TabIndex = 738
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(497, 431)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(175, 140)
        Me.PnlCShowGrid2.TabIndex = 739
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Location = New System.Drawing.Point(950, 6)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(24, 23)
        Me.BtnFill.TabIndex = 736
        Me.BtnFill.Text = "F"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'LblReferenceReq
        '
        Me.LblReferenceReq.AutoSize = True
        Me.LblReferenceReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceReq.Location = New System.Drawing.Point(612, 14)
        Me.LblReferenceReq.Name = "LblReferenceReq"
        Me.LblReferenceReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceReq.TabIndex = 737
        Me.LblReferenceReq.Text = "Ä"
        '
        'RbtPOForIndent
        '
        Me.RbtPOForIndent.AutoSize = True
        Me.RbtPOForIndent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtPOForIndent.Location = New System.Drawing.Point(629, 155)
        Me.RbtPOForIndent.Name = "RbtPOForIndent"
        Me.RbtPOForIndent.Size = New System.Drawing.Size(104, 17)
        Me.RbtPOForIndent.TabIndex = 740
        Me.RbtPOForIndent.TabStop = True
        Me.RbtPOForIndent.Text = "PO For Indent"
        Me.RbtPOForIndent.UseVisualStyleBackColor = True
        '
        'RbtPODirect
        '
        Me.RbtPODirect.AutoSize = True
        Me.RbtPODirect.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtPODirect.Location = New System.Drawing.Point(742, 155)
        Me.RbtPODirect.Name = "RbtPODirect"
        Me.RbtPODirect.Size = New System.Drawing.Size(79, 17)
        Me.RbtPODirect.TabIndex = 741
        Me.RbtPODirect.TabStop = True
        Me.RbtPODirect.Text = "PO Direct"
        Me.RbtPODirect.UseVisualStyleBackColor = True
        '
        'TempPurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(1004, 622)
        Me.Controls.Add(Me.PnlSettings)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.TxtPaymentTerms)
        Me.Controls.Add(Me.LblPaymentTerms)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtTermsAndConditions)
        Me.Name = "TempPurchaseOrder"
        Me.Text = "Template Sale Order"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.TxtTermsAndConditions, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.LblPaymentTerms, 0)
        Me.Controls.SetChildIndex(Me.TxtPaymentTerms, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
        Me.Controls.SetChildIndex(Me.PnlSettings, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
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
        Me.TPShipping.ResumeLayout(False)
        Me.TPShipping.PerformLayout()
        Me.PnlSettings.ResumeLayout(False)
        Me.PnlSettings.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents LblVendor As System.Windows.Forms.Label
    Protected WithEvents TxtVendorOrderCancelDate As AgControls.AgTextBox
    Protected WithEvents LblVendorCancelDate As System.Windows.Forms.Label
    Protected WithEvents TxtVendorDeliveryDate As AgControls.AgTextBox
    Protected WithEvents LblVendorDeliveryDate As System.Windows.Forms.Label
    Protected WithEvents TxtVendorOrderDate As AgControls.AgTextBox
    Protected WithEvents LvlVendoOrdDate As System.Windows.Forms.Label
    Protected WithEvents TxtVendorOrdNo As AgControls.AgTextBox
    Protected WithEvents LblVendorOrdNo As System.Windows.Forms.Label
    Protected WithEvents TxtVendor As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToPartyAdd1 As AgControls.AgTextBox
    Protected WithEvents TxtSaleToPartyAdd2 As AgControls.AgTextBox
    Protected WithEvents Label6 As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToPartyCity As AgControls.AgTextBox
    Protected WithEvents Label7 As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToPartyState As AgControls.AgTextBox
    Protected WithEvents Label8 As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToPartyCountry As AgControls.AgTextBox
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents Label13 As System.Windows.Forms.Label
    Protected WithEvents TxtTermsAndConditions As AgControls.AgTextBox
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents Label26 As System.Windows.Forms.Label
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtCurrency As AgControls.AgTextBox
    Protected WithEvents Label28 As System.Windows.Forms.Label
    Protected WithEvents TxtSalesTaxGroupParty As AgControls.AgTextBox
    Protected WithEvents Label27 As System.Windows.Forms.Label
    Protected WithEvents TPShipping As System.Windows.Forms.TabPage
    Protected WithEvents TxtShipToPartyCountry As AgControls.AgTextBox
    Protected WithEvents Label19 As System.Windows.Forms.Label
    Protected WithEvents TxtShipToPartyState As AgControls.AgTextBox
    Protected WithEvents Label20 As System.Windows.Forms.Label
    Protected WithEvents TxtShipToPartyCity As AgControls.AgTextBox
    Protected WithEvents Label21 As System.Windows.Forms.Label
    Protected WithEvents TxtShipToPartyAdd2 As AgControls.AgTextBox
    Protected WithEvents TxtShipToPartyAdd1 As AgControls.AgTextBox
    Protected WithEvents Label22 As System.Windows.Forms.Label
    Protected WithEvents TxtShipToParty As AgControls.AgTextBox
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents TxtBillingType As AgControls.AgTextBox
    Protected WithEvents Label32 As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents Label33 As System.Windows.Forms.Label
    Protected WithEvents TxtAgent As AgControls.AgTextBox
    Protected WithEvents LblAgent As System.Windows.Forms.Label
    Protected WithEvents TxtPriceMode As AgControls.AgTextBox
    Protected WithEvents LblPriceMode As System.Windows.Forms.Label
    Protected WithEvents Label24 As System.Windows.Forms.Label
    Protected WithEvents LblStockTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents LblTotalStockMeasureText As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtIndentNo As AgControls.AgTextBox
    Protected WithEvents LblIndentNo As System.Windows.Forms.Label
    Protected WithEvents TxtQutationNo As AgControls.AgTextBox
    Protected WithEvents LblQutationNo As System.Windows.Forms.Label
    Protected WithEvents PnlSettings As System.Windows.Forms.Panel
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents BtnOk As System.Windows.Forms.Button
    Protected WithEvents TxtShowIndentInLine As AgControls.AgTextBox
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents TxtPaymentTerms As AgControls.AgTextBox
    Protected WithEvents LblPaymentTerms As System.Windows.Forms.Label
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents LblReferenceReq As System.Windows.Forms.Label
    Protected WithEvents RbtPOForIndent As System.Windows.Forms.RadioButton
    Protected WithEvents RbtPODirect As System.Windows.Forms.RadioButton
#End Region

    Private Sub TempPurchaseOrder_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer, mSr As Integer
        Dim bTotalIndentQty As Integer
        Dim bTotalMeasureIndentQty As Integer

        Dim bProdOrder As String
        Dim bTotalPlanningQty As Integer
        Dim bTotalMeasurePlanningQty As Integer

        Dim DsTemp As DataSet
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                bTotalIndentQty = 0 : bTotalMeasureIndentQty = 0
                If Dgl1.AgSelectedValue(Dgl1.Columns(Col1TempIndentNo).Index, I) <> "" Then
                    mQry = " SELECT sum(PD.Qty) AS Qty ,sum(PD.TotalMeasure) AS MeasureQty,PD.PurchIndent " & _
                            " FROM PurchOrderDetail PD WITH (NoLock) " & _
                            " LEFT JOIN PurchOrder P WITH (NoLock) ON PD.DocId=P.DocID " & _
                            " WHERE PD.PurchIndent =" & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1TempIndentNo).Index, I)) & " " & _
                            " AND PD.Item =" & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1TempItem).Index, I)) & " " & _
                            " AND isnull(P.IsDeleted,0) =0 " & _
                            " GROUP BY PD.PurchIndent "
                    DsTemp = AgL.FillData(mQry, AgL.GcnRead)
                    With DsTemp.Tables(0)
                        If .Rows.Count > 0 Then
                            bTotalIndentQty = AgL.VNull(.Rows(0)("Qty"))
                            bTotalMeasureIndentQty = AgL.VNull(.Rows(0)("MeasureQty"))
                        End If
                    End With

                    mQry = " UPDATE PurchIndentDetail SET " & _
                            " OrdQty = " & bTotalIndentQty & " ," & _
                            " OrdMeasure = " & bTotalMeasureIndentQty & " " & _
                            " WHERE DocId = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1TempIndentNo).Index, I)) & "  " & _
                            " AND Item = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1TempItem).Index, I)) & " "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If

                '    bTotalIndentQty = 0 : bTotalMeasureIndentQty = 0
                '    If Dgl1.AgSelectedValue(Dgl1.Columns(Col1IndentNo).Index, I) <> "" Then
                '        mQry = " SELECT sum(PD.Qty) AS Qty ,sum(PD.TotalMeasure) AS MeasureQty,PD.PurchIndent " & _
                '                " FROM PurchOrderDetail PD WITH (NoLock) " & _
                '                " LEFT JOIN PurchOrder P WITH (NoLock) ON PD.DocId=P.DocID " & _
                '                " WHERE PD.PurchIndent =" & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1IndentNo).Index, I)) & " " & _
                '                " AND PD.Item =" & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1Item).Index, I)) & " " & _
                '                " AND isnull(P.IsDeleted,0) =0 " & _
                '                " GROUP BY PD.PurchIndent "


                '        DsTemp = AgL.FillData(mQry, AgL.GcnRead)
                '        With DsTemp.Tables(0)
                '            If .Rows.Count > 0 Then
                '                bTotalIndentQty = AgL.VNull(.Rows(0)("Qty"))
                '                bTotalMeasureIndentQty = AgL.VNull(.Rows(0)("MeasureQty"))
                '            End If
                '        End With

                '        mQry = " UPDATE PurchIndentDetail SET " & _
                '                " OrdQty = " & bTotalIndentQty & " ," & _
                '                " OrdMeasure = " & bTotalMeasureIndentQty & " " & _
                '                " WHERE DocId = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1IndentNo).Index, I)) & "  " & _
                '                " AND Item = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1Item).Index, I)) & " "
                '        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                '    End If
                'End If

                bTotalPlanningQty = 0 : bTotalMeasurePlanningQty = 0
                If Dgl1.AgSelectedValue(Dgl1.Columns(Col1IndentNo).Index, I) <> "" Then
                    mQry = " SELECT ISNULL(PI.ProdOrder,'') AS ProdOrder  " & _
                            " FROM PurchIndentDetail PID WITH (NoLock)" & _
                            " LEFT JOIN PurchIndent PI WITH (NoLock) ON PI.DocID=PID.DocId  " & _
                            " WHERE PID.Item = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1Item).Index, I)) & " " & _
                            " AND PID.DocId = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1IndentNo).Index, I)) & "" & _
                            " AND isnull(PI.IsDeleted,0) =0 "
                    bProdOrder = AgL.Dman_Execute(mQry, AgL.GcnRead, AgL.ECmd).ExecuteScalar

                    If bProdOrder <> "" Then

                        mQry = " SELECT sum(isnull(PID.OrdQty,0)) AS Qty, sum(isnull(PID.OrdMeasure ,0)) AS MeasureQty  " & _
                                " FROM PurchIndent PI WITH (NoLock) " & _
                                " LEFT JOIN PurchIndentDetail PID WITH (NoLock) ON PID.DocId=PI.DocID  " & _
                                " WHERE PID.Item = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1Item).Index, I)) & " " & _
                                " AND PI.ProdOrder =" & AgL.Chk_Text(bProdOrder) & " " & _
                                " AND isnull(PI.IsDeleted,0) =0 "

                        DsTemp = AgL.FillData(mQry, AgL.GcnRead)
                        With DsTemp.Tables(0)
                            If .Rows.Count > 0 Then
                                bTotalPlanningQty = AgL.VNull(.Rows(0)("Qty"))
                                bTotalMeasurePlanningQty = AgL.VNull(.Rows(0)("MeasureQty"))
                            End If
                        End With

                        mQry = " UPDATE MaterialPlanDetail SET " & _
                                " PurchOrdQty = " & bTotalPlanningQty & ", " & _
                                " PurchOrdMeasure =  " & bTotalMeasurePlanningQty & "  " & _
                                " WHERE ProdOrder =" & AgL.Chk_Text(bProdOrder) & " " & _
                                " AND Item = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.Columns(Col1Item).Index, I)) & " "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    End If
                End If
            End If
        Next
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog

        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT H.UID as SearchCode, Vt.Description AS [Entry Type], H.V_Date AS [Entry Date], H.V_No AS [Entry No], " & _
        '                 " H.VendorName AS [Vendor Name], H.VendorAdd1 AS [Vendor Address1],  " & _
        '                 " H.VendorAdd2 AS [Vendor Address2], H.VendorCityName AS [Vendor City],  " & _
        '                 " H.VendorState AS [Vendor State], H.VendorCountry  AS [Vendor Country],  " & _
        '                 " H.VendorOrderNo  AS [Vendor Order No], H.VendorOrderDate AS [Vendor Order Date],  " & _
        '                 " H.VendorDeliveryDate AS [Vendor Delivery Date], H.VendorOrderCancelDate AS [Vendor Order Cancel Date]," & _
        '                 " H.TermsAndConditions AS [Terms & Conditions] " & _
        '                 " FROM PurchOrder_Log H " & _
        '                 " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type " & _
        '                 " LEFT JOIN SeaPort DP ON H.DestinationPort = DP.Code " & _
        '                 " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQry = " SELECT  H.UID AS SearchCode,H.DeliveryMeasure AS [Delivery Measure], H.V_Type AS [ORDER Type], H.V_Prefix AS [Prefix], H.V_Date AS Date, H.V_No AS [ORDER No], " & _
                " H.ReferenceNo AS [Manual No], H.VendorName AS [Vendor Name], H.VendorAdd1 AS [Vendor Add1], H.VendorAdd2 AS [Vendor Add2], H.VendorCityName AS [Vendor City Name],  " & _
                " H.VendorState AS [Vendor State], H.VendorCountry AS [Vendor Country], H.ShipToPartyName AS [Ship To Party Name], H.ShipToPartyAdd1 AS [Ship To Party Add1], H.ShipToPartyAdd2 AS [Ship To Party Add2],  " & _
                " H.ShipToPartyCityName AS [Ship To Party City Name], H.ShipToPartyState AS [Ship To Party State], H.ShipToPartyCountry AS [Ship To Party Country], H.Currency, H.SalesTaxGroupParty AS [Sales Tax Group Party],  " & _
                " H.Structure, H.BillingType AS [Billing Type], H.VendorOrderNo AS [Vendor Order No], H.VendorOrderDate AS [Vendor Order Date], H.VendorDeliveryDate AS [Vendor Delivery Date],  " & _
                " H.VendorOrderCancelDate AS [Vendor Order Cancel Date], H.FinalPlaceOfDelivery AS [Final Place Of Delivery], H.TermsAndConditions AS [Terms And Conditions], H.Remarks,  " & _
                " H.TotalQty AS [Total Qty], H.TotalMeasure AS [Total Measure], H.TotalAmount AS [Total Amount], H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type],  " & _
                " H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log], H.MoveToLogDate AS [Move To Log Date], H.Status, H.PreCarriageBy AS [Pre Carriage By],  " & _
                " H.PlaceOfReceipt AS [Place Of Receipt], H.ShipmentThrough AS [Shipment Through], H.BankAcNoVendor AS [Vendor Bank A/c No], H.BankNameVendor AS [Vendor Bank Name], H.BankAddressVendor AS [Vendor Bank Address],  " & _
                " H.PriceMode AS [Price Mode], SGA.DispName AS [Agent Name], H.PaymentTerms AS [Payment Terms], " & _
                " D.Div_Name AS Division, SM.Name AS [Site Name], PI.V_Type + convert(NVARCHAR,PI.V_No) AS [Indent No], PQ.V_Type + convert(NVARCHAR,PQ.V_No) AS [Quotation No], SF.* " & _
                " FROM  PurchOrder H " & _
                " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
                " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
                " LEFT JOIN PurchQuotation PQ ON PQ.DocID=H.PurchQuotaion  " & _
                " LEFT JOIN PurchIndent PI ON PI.DocID=H.PurchIndent  " & _
                " LEFT JOIN SubGroup SGA ON SGA.SubCode=H.Agent  " & _
                " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, EntryNCat, FrmType) & ") As SF On H.UID = SF.UId " & _
                " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "PurchOrder"
        LogTableName = "PurchOrder_Log"
        MainLineTableCsv = "PurchOrderDetail,Structure_TransFooter,Structure_TransLine"
        LogLineTableCsv = "PurchOrderDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"

        AgL.GridDesign(Dgl1)
        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)
        AgL.AddAgDataGrid(AgCShowGrid1, PnlCShowGrid)
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
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
            " From PurchOrder H " & _
            " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
            " Where IsNull(IsDeleted,0)=0  " & mCondStr & "  Order By V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = "Select UID As SearchCode " & _
               " From PurchOrder_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT H.DocId as SearchCode, Vt.Description AS [Entry Type], H.V_Date AS [Entry Date], H.V_No AS [Entry No], " & _
        '                " H.VendorName AS [Vendor Name], H.VendorAdd1 AS [Vendor Address1],  " & _
        '                " H.VendorAdd2 AS [Vendor Address2], H.VendorCityName AS [Vendor City],  " & _
        '                " H.VendorState AS [Vendor State], H.VendorCountry  AS [Vendor Country],  " & _
        '                " H.VendorOrderNo  AS [Vendor Order No], H.VendorOrderDate AS [Vendor Order Date],  " & _
        '                " H.VendorDeliveryDate AS [Vendor Delivery Date], H.VendorOrderCancelDate AS [Vendor Order Cancel Date]," & _
        '                " H.FinalPlaceOfDelivery AS [Final Place OF Delivery],  " & _
        '                " H.TermsAndConditions AS [Terms & Conditions] " & _
        '                " FROM dbo.PurchOrder H " & _
        '                " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type " & _
        '                " LEFT JOIN SeaPort DP ON H.DestinationPort = DP.Code " & _
        '                " Where IsNull(H.IsDeleted,0)=0   " & mCondStr

        AgL.PubFindQry = " SELECT  H.DocID AS SearchCode,H.DeliveryMeasure AS [Delivery Measure], H.V_Type AS [ORDER Type], H.V_Prefix AS [Prefix], H.V_Date AS Date, H.V_No AS [ORDER No], " & _
                        " H.ReferenceNo AS [Manual No], H.VendorName AS [Vendor Name], H.VendorAdd1 AS [Vendor Add1], H.VendorAdd2 AS [Vendor Add2], H.VendorCityName AS [Vendor City Name],  " & _
                        " H.VendorState AS [Vendor State], H.VendorCountry AS [Vendor Country], H.ShipToPartyName AS [Ship To Party Name], H.ShipToPartyAdd1 AS [Ship To Party Add1], H.ShipToPartyAdd2 AS [Ship To Party Add2],  " & _
                        " H.ShipToPartyCityName AS [Ship To Party City Name], H.ShipToPartyState AS [Ship To Party State], H.ShipToPartyCountry AS [Ship To Party Country], H.Currency, H.SalesTaxGroupParty AS [Sales Tax Group Party],  " & _
                        " H.Structure, H.BillingType AS [Billing Type], H.VendorOrderNo AS [Vendor Order No], H.VendorOrderDate AS [Vendor Order Date], H.VendorDeliveryDate AS [Vendor Delivery Date],  " & _
                        " H.VendorOrderCancelDate AS [Vendor Order Cancel Date], H.FinalPlaceOfDelivery AS [Final Place Of Delivery], H.TermsAndConditions AS [Terms And Conditions], H.Remarks,  " & _
                        " H.TotalQty AS [Total Qty], H.TotalMeasure AS [Total Measure], H.TotalAmount AS [Total Amount], H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type],  " & _
                        " H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log], H.MoveToLogDate AS [Move To Log Date], H.Status, H.PreCarriageBy AS [Pre Carriage By],  " & _
                        " H.PlaceOfReceipt AS [Place Of Receipt], H.ShipmentThrough AS [Shipment Through], H.BankAcNoVendor AS [Vendor Bank A/c No], H.BankNameVendor AS [Vendor Bank Name], H.BankAddressVendor AS [Vendor Bank Address],  " & _
                        " H.PriceMode AS [Price Mode], SGA.DispName AS [Agent Name], H.PaymentTerms AS [Payment Terms], " & _
                        " D.Div_Name AS Division, SM.Name AS [Site Name], PI.V_Type + convert(NVARCHAR,PI.V_No) AS [Indent No], PQ.V_Type + convert(NVARCHAR,PQ.V_No) AS [Quotation No], SF.* " & _
                        " FROM  PurchOrder H " & _
                        " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                        " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
                        " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
                        " LEFT JOIN PurchQuotation PQ ON PQ.DocID=H.PurchQuotaion  " & _
                        " LEFT JOIN PurchIndent PI ON PI.DocID=H.PurchIndent  " & _
                        " LEFT JOIN SubGroup SGA ON SGA.SubCode=H.Agent  " & _
                        " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, EntryNCat, FrmType) & ") As SF On H.DocId = SF.DocId " & _
                        " Where IsNull(H.IsDeleted,0)=0   " & mCondStr
        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 190, 0, Col1Item, True, False, False)
            .AddAgTextColumn(Dgl1, Col1IndentNo, 110, 0, Col1IndentNo, False, False, False)
            .AddAgTextColumn(Dgl1, Col1PartySKU, 110, 50, Col1PartySKU, False, False, False)
            .AddAgTextColumn(Dgl1, Col1PartyUPC, 110, 20, Col1PartyUPC, False, False, False)
            .AddAgNumberColumn(Dgl1, Col1Qty, 80, 8, 4, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True, False)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 100, 8, 4, False, Col1MeasurePerPcs, True, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 100, 50, Col1MeasureUnit, False, False, False)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 100, 8, 4, False, Col1TotalMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 80, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, True, True, True)
            .AddAgTextColumn(Dgl1, Col1SalesTaxGroup, 70, 0, Col1SalesTaxGroup, False, False, False)
            .AddAgTextColumn(Dgl1, Col1xPartySKU, 270, 50, Col1xPartySKU, False, False, False)
            .AddAgTextColumn(Dgl1, Col1xPartyUPC, 270, 50, Col1xPartyUPC, False, False, False)
            .AddAgNumberColumn(Dgl1, Col1ShippedQty, 100, 8, 4, False, Col1ShippedQty, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ShippedMeasure, 100, 8, 4, False, Col1ShippedMeasure, False, True, True)
            .AddAgTextColumn(Dgl1, Col1TempIndentNo, 120, 0, Col1TempIndentNo, False, False, False)
            .AddAgTextColumn(Dgl1, Col1TempItem, 200, 0, Col1TempItem, False, False, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Panel1.Anchor = Dgl1.Anchor
        Dgl1.ColumnHeadersHeight = 35

        AgCalcGrid1.Ini_Grid(mSearchCode)
        AgCalcGrid1.AgFixedRows = 6
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
        ProcAdjustGrid()
        'Ini_List()
    End Sub


    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer
        mQry = "UPDATE PurchOrder_Log " & _
                "   SET " & _
                "   Vendor = " & AgL.Chk_Text(TxtVendor.AgSelectedValue) & ", " & _
                "	VendorName = " & AgL.Chk_Text(TxtVendor.Text) & ", " & _
                "	VendorAdd1 = " & AgL.Chk_Text(TxtSaleToPartyAdd1.Text) & ", " & _
                "	VendorAdd2 = " & AgL.Chk_Text(TxtSaleToPartyAdd2.Text) & ", " & _
                "	VendorCity = " & AgL.Chk_Text(TxtSaleToPartyCity.AgSelectedValue) & ", " & _
                "	VendorCityName = " & AgL.Chk_Text(TxtSaleToPartyCity.Text) & ", " & _
                "	VendorState = " & AgL.Chk_Text(TxtSaleToPartyState.Text) & ", " & _
                "	VendorCountry = " & AgL.Chk_Text(TxtSaleToPartyCountry.Text) & ", " & _
                "	Currency = " & AgL.Chk_Text(TxtCurrency.AgSelectedValue) & ", " & _
                "	ShipToPartyName = " & AgL.Chk_Text(TxtShipToParty.Text) & ", " & _
                "	ShipToPartyAdd1 = " & AgL.Chk_Text(TxtShipToPartyAdd1.Text) & ", " & _
                "	ShipToPartyAdd2 = " & AgL.Chk_Text(TxtShipToPartyAdd2.Text) & ", " & _
                "	ShipToPartyCity = " & AgL.Chk_Text(TxtShipToPartyCity.AgSelectedValue) & ", " & _
                "	ShipToPartyCityName = " & AgL.Chk_Text(TxtShipToPartyCity.Text) & ", " & _
                "	ShipToPartyState = " & AgL.Chk_Text(TxtShipToPartyState.Text) & ", " & _
                "	ShipToPartyCountry = " & AgL.Chk_Text(TxtShipToPartyCountry.Text) & ", " & _
                "	SalesTaxGroupParty = " & AgL.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & ", " & _
                "   PurchIndent = " & AgL.Chk_Text(TxtIndentNo.AgSelectedValue) & ", " & _
                "   PurchQuotaion = " & AgL.Chk_Text(TxtQutationNo.AgSelectedValue) & ", " & _
                "	ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                "	VendorOrderNo = " & AgL.Chk_Text(TxtVendorOrdNo.Text) & ", " & _
                "	VendorOrderDate = " & AgL.Chk_Text(TxtVendorOrderDate.Text) & ", " & _
                "	VendorDeliveryDate =" & AgL.Chk_Text(TxtVendorDeliveryDate.Text) & ", " & _
                "	VendorOrderCancelDate =" & AgL.Chk_Text(TxtVendorOrderCancelDate.Text) & ", " & _
                "	TermsAndConditions = " & AgL.Chk_Text(TxtTermsAndConditions.Text) & ", " & _
                "   BillingType = " & AgL.Chk_Text(TxtBillingType.AgSelectedValue) & ", " & _
                "	Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                "	Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                "   TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                "   TotalAmount = " & Val(LblTotalAmount.Text) & ", " & _
                "   TotalMeasure = " & Val(LblTotalMeasure.Text) & ", " & _
                "   PriceMode = " & AgL.Chk_Text(TxtPriceMode.Text) & ", " & _
                "   PaymentTerms = " & AgL.Chk_Text(TxtPaymentTerms.Text) & ", " & _
                "   Agent = " & AgL.Chk_Text(TxtAgent.AgSelectedValue) & " " & _
                "   Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        AgCalcGrid1.Save_TransFooter(mInternalCode, Conn, Cmd, SearchCode)

        mQry = "Delete From PurchOrderDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                mQry = "INSERT INTO PurchOrderDetail_Log (DocId, Sr, PurchIndent, Item, SalesTaxGroupItem, Qty, " & _
                        " Unit, Rate, Amount, UID, VendorSKU, VendorUPC, " & _
                        " MeasurePerPcs, TotalMeasure, MeasureUnit, ShippedQty, ShippedMeasure) " & _
                        " VALUES (" & AgL.Chk_Text(mInternalCode) & ", " & mSr & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1IndentNo, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1SalesTaxGroup, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & ", " & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1PartySKU, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1PartyUPC, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalMeasure, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ShippedQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ShippedMeasure, I).Value) & " " & _
                        "  )"

                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                AgCalcGrid1.Save_TransLine(mInternalCode, mSr, I, Conn, Cmd, SearchCode)
                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)

            End If
        Next
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer

        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.*, C.Country as DestinationCountry " & _
                " From PurchOrder H " & _
                " Left Join SeaPort SP On H.DestinationPort = SP.Code " & _
                " Left Join City C On SP.City = C.CityCode " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.*, C.Country as DestinationCountry " & _
                " From PurchOrder_Log H " & _
                " Left Join SeaPort SP On H.DestinationPort = SP.Code " & _
                " Left Join City C On SP.City = C.CityCode " & _
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
                TxtVendor.AgSelectedValue = AgL.XNull(.Rows(0)("Vendor"))
                TxtVendor.Text = AgL.XNull(.Rows(0)("VendorName"))
                TxtSaleToPartyAdd1.Text = AgL.XNull(.Rows(0)("VendorAdd1"))
                TxtSaleToPartyAdd2.Text = AgL.XNull(.Rows(0)("VendorAdd2"))
                TxtSaleToPartyCity.AgSelectedValue = AgL.XNull(.Rows(0)("VendorCity"))
                TxtSaleToPartyState.Text = AgL.XNull(.Rows(0)("VendorState"))
                TxtSaleToPartyCountry.Text = AgL.XNull(.Rows(0)("VendorCountry"))
                TxtShipToParty.Text = AgL.XNull(.Rows(0)("ShipToPartyName"))
                TxtShipToPartyAdd1.Text = AgL.XNull(.Rows(0)("ShipToPartyAdd1"))
                TxtShipToPartyAdd2.Text = AgL.XNull(.Rows(0)("ShipToPartyAdd2"))
                TxtShipToPartyCity.AgSelectedValue = AgL.XNull(.Rows(0)("ShipToPartyCity"))
                TxtShipToPartyState.Text = AgL.XNull(.Rows(0)("ShipToPartyState"))
                TxtShipToPartyCountry.Text = AgL.XNull(.Rows(0)("ShipToPartyCountry"))
                TxtCurrency.AgSelectedValue = AgL.XNull(.Rows(0)("Currency"))
                TxtVendorOrdNo.Text = AgL.XNull(.Rows(0)("VendorOrderNo"))
                TxtVendorOrderDate.Text = AgL.XNull(.Rows(0)("VendorOrderDate"))
                TxtVendorDeliveryDate.Text = AgL.XNull(.Rows(0)("VendorDeliveryDate"))
                TxtVendorOrderCancelDate.Text = AgL.XNull(.Rows(0)("VendorOrderCancelDate"))
                TxtTermsAndConditions.Text = AgL.XNull(.Rows(0)("TermsAndConditions"))
                TxtBillingType.AgSelectedValue = AgL.XNull(.Rows(0)("BillingType"))
                TxtQutationNo.AgSelectedValue = AgL.XNull(.Rows(0)("PurchQuotaion"))
                TxtIndentNo.AgSelectedValue = AgL.XNull(.Rows(0)("PurchIndent"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))
                TxtPriceMode.Text = AgL.XNull(.Rows(0)("PriceMode"))
                TxtPaymentTerms.Text = AgL.XNull(.Rows(0)("PaymentTerms"))
                TxtAgent.AgSelectedValue = AgL.XNull(.Rows(0)("Agent"))
                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))
                LblTotalMeasure.Text = AgL.VNull(.Rows(0)("TotalMeasure"))


                AgCalcGrid1.MoveRec_TransFooter(SearchCode)

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from PurchOrderDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from PurchOrderDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If


                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1IndentNo, I) = AgL.XNull(.Rows(I)("PurchIndent"))
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))

                            Dgl1.AgSelectedValue(Col1TempIndentNo, I) = AgL.XNull(.Rows(I)("PurchIndent"))
                            Dgl1.AgSelectedValue(Col1TempItem, I) = AgL.XNull(.Rows(I)("Item"))

                            Dgl1.Item(Col1PartySKU, I).Value = AgL.XNull(.Rows(I)("VendorSKU"))
                            Dgl1.Item(Col1xPartySKU, I).Value = AgL.XNull(.Rows(I)("VendorSKU"))
                            Dgl1.Item(Col1PartyUPC, I).Value = AgL.XNull(.Rows(I)("VendorUPC"))
                            Dgl1.Item(Col1xPartyUPC, I).Value = AgL.XNull(.Rows(I)("VendorUPC"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Rate, I).Value = AgL.VNull(.Rows(I)("Rate"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1Amount, I).Value = AgL.VNull(.Rows(I)("Amount"))
                            Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))

                            Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                            Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1ShippedQty, I).Value = AgL.VNull(.Rows(I)("ShippedQty"))
                            Dgl1.Item(Col1ShippedMeasure, I).Value = AgL.VNull(.Rows(I)("ShippedMeasure"))

                            Call AgCalcGrid1.MoveRec_TransLine(mSearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With

                AgCShowGrid1.MoveRec_FromCalcGrid()
                AgCShowGrid2.MoveRec_FromCalcGrid()

                'Calculation()
                '-------------------------------------------------------------
            End If
        End With
        Call ProcLoadSettings()
    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgCalcGrid1.FrmType = Me.FrmType
        ProcFillEnviro(EntryNCat)
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtShipToPartyCity.Validating, TxtQutationNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    IniGrid()
                    ProcFillReferenceNo()
                    ProcFillTermCondition()

                Case TxtShipToPartyCity.Name
                    Validating_ShipToPartyCity(sender.AgSelectedValue)

                Case TxtQutationNo.Name
                    Validating_Quatation(sender.AgSelectedValue)

            End Select    '
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Validating_Quatation(ByVal Code As String)

        Dim DrTemp As DataRow() = Nothing
        If TxtQutationNo.Text <> "" Then
            DrTemp = TxtQutationNo.AgHelpDataSet.Tables(0).Select(" Code = '" & Code & "' ")
            If DrTemp.Length > 0 Then
                TxtIndentNo.AgSelectedValue = AgL.XNull(DrTemp(0)("PurchIndent"))
            Else
                TxtIndentNo.AgSelectedValue = ""
            End If
        End If
    End Sub

    Private Sub Validating_ShipToPartyCity(ByVal Code As String)

        Dim DrTemp As DataRow() = Nothing
        If TxtShipToPartyCity.Text <> "" Then
            DrTemp = TxtShipToPartyCity.AgHelpDataSet.Tables(0).Select(" CityCode = '" & Code & "' ")
            If DrTemp.Length > 0 Then
                TxtShipToPartyState.Text = AgL.XNull(DrTemp(0)("State"))
                TxtShipToPartyCountry.Text = AgL.XNull(DrTemp(0)("Country"))
            Else
                TxtShipToPartyState.Text = ""
                TxtShipToPartyCountry.Text = ""
            End If
        End If
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        ProcFillReferenceNo()
        ProcFillTermCondition()
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        IniGrid()
        TabControl1.SelectedTab = TP1
        TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupParty"))
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
        RbtPOForIndent.Checked = True
        If AgL.PubDtEnviro.Rows.Count > 0 Then
            TxtShowIndentInLine.Text = IIf(AgL.VNull(AgL.PubDtEnviro.Rows(0)("PurchOrderShowIndentInLine")) = 0, "No", "Yes")
        End If
        ProcAdjustGrid()
        If DtPurchaseEnviro.Rows.Count = 0 Then
            MsgBox("Fill Enviro", MsgBoxStyle.Information)
            Topctrl1.FButtonClick(14, True)
        End If
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtVendor.AgHelpDataSet(18, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Vendor
        TxtSaleToPartyCity.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.City
        TxtShipToPartyCity.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.City
        TxtCurrency.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Currency
        TxtStructure.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.AgStructure
        TxtSalesTaxGroupParty.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.SalesTaxGroupParty
        TxtBillingType.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.BillingType
        TxtAgent.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Agent
        TxtQutationNo.AgHelpDataSet(8, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.QuotationNo
        TxtPriceMode.AgHelpDataSet(, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.PriceMode

        TxtIndentNo.AgHelpDataSet(6, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.IndentNo
        Dgl1.AgHelpDataSet(Col1IndentNo, 6) = HelpDataSet.IndentNo
        Dgl1.AgHelpDataSet(Col1TempIndentNo, 5) = HelpDataSet.IndentNo

        Dgl1.AgHelpDataSet(Col1TempItem, 11) = HelpDataSet.Item

        IniItemHelp()
    End Sub

    Public Sub IniItemHelp(Optional ByVal All_Records As Boolean = True)
        If All_Records = True Then
            Dgl1.AgHelpDataSet(Col1Item, 11) = HelpDataSet.Item
        Else
            Dgl1.AgHelpDataSet(Col1Item, 13) = HelpDataSet.ItemFromIndent
        End If
    End Sub


    Private Sub TxtSaleToParty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtVendor.Validating, TxtSalesTaxGroupParty.Validating
        Dim DrTemp As DataRow()
        Select Case sender.name
            Case TxtVendor.Name
                If sender.text.ToString.Trim <> "" Then
                    If sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = sender.AgHelpDataSet.Tables(0).Select("SubCode = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                        TxtSaleToPartyAdd1.Text = AgL.XNull(DrTemp(0)("Add1"))
                        TxtSaleToPartyAdd2.Text = AgL.XNull(DrTemp(0)("Add2"))
                        TxtSaleToPartyCity.AgSelectedValue = AgL.XNull(DrTemp(0)("CityCode"))
                        TxtSaleToPartyState.Text = AgL.XNull(DrTemp(0)("State"))
                        TxtSaleToPartyCountry.Text = AgL.XNull(DrTemp(0)("Country"))
                        TxtCurrency.AgSelectedValue = AgL.XNull(DrTemp(0)("Currency"))
                        If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("SalesTaxPostingGroup")), "") Then
                            TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                            AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                        End If
                    End If
                Else
                    TxtSaleToPartyAdd1.Text = ""
                    TxtSaleToPartyAdd2.Text = ""
                    TxtSaleToPartyCity.AgSelectedValue = ""
                    TxtSaleToPartyState.Text = ""
                    TxtSaleToPartyCountry.Text = ""
                    TxtCurrency.AgSelectedValue = ""
                End If
            Case TxtSalesTaxGroupParty.Name
                AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                Calculation()
        End Select
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Unit, mRow).Value = ""
                Dgl1.Item(Col1SalesTaxGroup, mRow).Value = ""
            Else
                If Dgl1.AgDataRow IsNot Nothing Then
                    If RbtPOForIndent.Checked Then
                        Dgl1.AgSelectedValue(Col1IndentNo, mRow) = AgL.XNull(Dgl1.AgDataRow.Cells("IndentDocId").Value)
                        Dgl1.Item(Col1Qty, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("BalanceQty").Value)
                    End If
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Unit").Value)
                    Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(Dgl1.AgDataRow.Cells("SalesTaxPostingGroup").Value)
                    If AgL.StrCmp(Dgl1.Item(Col1SalesTaxGroup, mRow).Value, "") Then
                        Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
                    End If
                End If
            End If

            If TxtQutationNo.AgSelectedValue <> "" And Dgl1.AgSelectedValue(Col1Item, mRow) <> "" Then
                mQry = " SELECT Q.Rate  " & _
                        " FROM PurchQuotationDetail Q " & _
                        " WHERE Q.DocId = '" & TxtQutationNo.AgSelectedValue & "' " & _
                        " AND Q.Item = '" & Dgl1.AgSelectedValue(Col1Item, mRow) & "' "
                Dgl1.Item(Col1Rate, mRow).Value = Val(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        mRowIndex = Dgl1.CurrentCell.RowIndex
        mColumnIndex = Dgl1.CurrentCell.ColumnIndex

        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1IndentNo
                Dgl1.AgRowFilter(Dgl1.Columns(Col1IndentNo).Index) = " IsDeleted = 0 " & _
                            " And " & ClsMain.RetDivFilterStr & " " & _
                            " And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                            " AND (BalItem > 0 " & _
                            " OR Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Dgl1.CurrentCell.ColumnIndex, Dgl1.CurrentCell.RowIndex)) & " ) "

            Case Col1Item
                If TxtIndentNo.AgSelectedValue <> "" Then
                    Call IniItemHelp(False)
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                            " And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                            " AND BalanceQty > 0 " & _
                            " And IndentDocID = '" & TxtIndentNo.AgSelectedValue & "' "
                ElseIf RbtPOForIndent.Checked Then
                    Call IniItemHelp(False)
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                            " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                            " AND BalanceQty > 0 "
                Else
                    Call IniItemHelp()
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                            " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                End If
        End Select
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
                    ProcShowPurchaseOrderDetail(Dgl1.AgSelectedValue(Col1Item, mRowIndex))

                Case Col1IndentNo
                    e.Cancel = Not Validate_PurchIndent(Dgl1, Dgl1.CurrentCell.RowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Code BY Akash On date 15-6-2011
    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    'Changed By Akash On date 15-06-2011
    Private Sub FrmSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0
        LblTotalMeasure.Text = 0
        LblTotalAmount.Text = 0
        LblStockTotalMeasure.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1TotalMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                If AgL.StrCmp(TxtBillingType.Text, "Qty") Or TxtBillingType.Text = "" Then
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                Else
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1TotalMeasure, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                End If
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
            End If
        Next
        AgCalcGrid1.Calculation()
        LblTotalQty.Text = Val(LblTotalQty.Text)
        LblTotalMeasure.Text = Val(LblTotalMeasure.Text)
        LblTotalAmount.Text = Val(LblTotalAmount.Text)
        LblStockTotalMeasure.Text = Val(LblStockTotalMeasure.Text)
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtSaleToPartyAdd1.Enabled = False
        TxtSaleToPartyAdd2.Enabled = False
        TxtSaleToPartyCity.Enabled = False
        TxtSaleToPartyState.Enabled = False
        TxtSaleToPartyCountry.Enabled = False
        TxtShipToPartyState.Enabled = False
        TxtShipToPartyCountry.Enabled = False
    End Sub


    Private Sub TxtOrderCancelDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtRemarks.LostFocus, TxtPriceMode.LostFocus
        Select Case sender.NAME
            'Case TxtRemarks.Name
            '    TabControl1.SelectedTab = TPExport
            'Case TxtPriceMode.Name
            '    TabControl1.SelectedTab = TPShipping
        End Select
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgL.RequiredField(TxtVendor, LblVendor.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then passed = False : Exit Sub

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub
        If AgCL.AgIsDuplicate(Dgl1, "" & Dgl1.Columns(Col1IndentNo).Index & "," & Dgl1.Columns(Col1Item).Index & "") Then passed = False : Exit Sub

        If TxtIndentNo.AgSelectedValue <> "" Then
            If Validate_PurchIndent(TxtIndentNo) = False Then passed = False : Exit Sub
        End If

        If TxtQutationNo.AgSelectedValue <> "" Then
            If Validate_PurchQuotation() = False Then passed = False : Exit Sub
        End If

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If

                If .Item(Col1IndentNo, I).Value <> "" Then
                    If Validate_PurchIndent(Dgl1, I) = False Then passed = False : Exit Sub
                End If
            Next
        End With

        passed = FCheckDuplicateRefNo()
    End Sub

    Private Function FCheckDuplicateRefNo() As Boolean
        FCheckDuplicateRefNo = True
        If Topctrl1.Mode = "Add" Then
            mQry = " SELECT COUNT(*) FROM PurchOrder WHERE ReferenceNo = '" & TxtReferenceNo.Text & "'   " & _
                    " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtReferenceNo.Focus()
        Else
            mQry = " SELECT COUNT(*) FROM PurchOrder WHERE ReferenceNo = '" & TxtReferenceNo.Text & "'  " & _
                    " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0 AND DocID <>'" & mInternalCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtReferenceNo.Focus()
        End If
    End Function


    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtShipToPartyCity.Enter, TxtQutationNo.Enter, TxtIndentNo.Enter, TxtVendor.Enter
        Try
            Select Case sender.name
                Case TxtVendor.Name, TxtAgent.Name
                    'TxtVendor.AgRowFilter = " IsDeleted = 0 " & _
                    '    " And Status = '" & ClsMain.EntryStatus.Active & "'  " & _
                    '    " And " & ClsMain.RetDivFilterStr & ""
                    TxtVendor.AgRowFilter = " IsDeleted = 0 " & _
                        " And Status = '" & ClsMain.EntryStatus.Active & "'  "

                Case TxtShipToPartyCity.Name
                    TxtShipToPartyCity.AgRowFilter = " IsDeleted = 0 "

                Case TxtQutationNo.Name
                    TxtQutationNo.AgRowFilter = " IsDeleted = 0 " & _
                        " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                        " And " & ClsMain.RetDivFilterStr & " " & _
                        " AND Vendor=" & AgL.Chk_Text(TxtVendor.AgSelectedValue) & " " & _
                        " And QuotationDate <= '" & TxtV_Date.Text & "' "

                Case TxtIndentNo.Name
                    TxtIndentNo.AgRowFilter = " IsDeleted = 0 And " & _
                        " Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                        " And " & ClsMain.RetDivFilterStr & " " & _
                        " AND (BalItem > 0 OR Code = " & AgL.Chk_Text(TxtIndentNo.AgSelectedValue) & " ) "

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        'PrintDocument(SearchCode)
    End Sub

    'Public Overridable Sub PrintDocument(ByVal SearchCode As String)
    '    Dim mCrd As New ReportDocument
    '    Dim ReportView As New AgLibrary.RepView
    '    Dim DsRep As New DataSet
    '    Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
    '    Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
    '    Try
    '        Me.Cursor = Cursors.WaitCursor
    '        If FrmType = ClsMain.EntryPointType.Main Then
    '            AgL.PubReportTitle = "Export Order"
    '            RepName = "Rug_ExportOrder_Print" : RepTitle = "Export Order"
    '            bTableName = "SaleOrder" : bSecTableName = "SaleOrderDetail SO1 ON SO1.DocID =SO.DocID"
    '            bCondstr = "WHERE SO.DocID='" & SearchCode & "'"
    '        Else
    '            AgL.PubReportTitle = "Export Order Log"
    '            RepName = "Rug_ExportOrder_Print" : RepTitle = "Export Order Log"
    '            bTableName = "SaleOrder_Log" : bSecTableName = "SaleOrderDetail_Log  SO1 ON SO1.UID =SO.UID "
    '            bCondstr = "WHERE SO.UID='" & SearchCode & "'"
    '        End If

    '        strQry = " SELECT SO.DocID, SO.V_Type, SO.V_Prefix, SO.V_Date, SO.V_No, SO.Div_Code, SO.Site_Code, " & _
    '                    " SO.SaleToParty, SO.SaleToPartyName, SO.SaleToPartyAdd1, SO.SaleToPartyAdd2, SO.SaleToPartyCity, SO.SaleToPartyCityName, SO.SaleToPartyState, SO.SaleToPartyCountry,  " & _
    '                    " SO.ShipToPartyName, SO.ShipToPartyAdd1, SO.ShipToPartyAdd2, SO.ShipToPartyCity, SO.ShipToPartyCityName, SO.ShipToPartyState, SO.ShipToPartyCountry,  " & _
    '                    " SO.SalesTaxGroupParty, SO.PartyOrderNo, SO.PartyOrderDate, SO.PartyOrderCancelDate, SO.DestinationPort, SO.FinalPlaceOfDelivery, SO.TermsAndConditions, " & _
    '                    " SO.EntryBy, SO.EntryDate, SO.EntryType, SO.EntryStatus, SO.ApproveBy, SO.ApproveDate,SO.IsDeleted, SO.Status, SO.UID, " & _
    '                    " SO.PartyDeliveryDate, SO.Remarks, SO.DeliveryMeasure, SO.ShipmentDate, SO.FactoryDate, SO.FactoryDeliveryDate, SO.ExFactoryShipmentDate, SO.FactoryCancelDate, " & _
    '                    " SO.BillingType, SO.Currency, SO.TotalQty, SO.TotalAmount,SO.TotalMeasure, " & _
    '                    " SO1.Sr, SO1.Item, SO1.SalesTaxGroupItem, SO1.Qty, SO1.Unit, SO1.Rate, SO1.Amount, " & _
    '                    " SO1.UID, SO1.PartySKU, SO1.PartyUPC, SO1.MeasurePerPcs, SO1.TotalMeasure AS LineTotalMeasure, " & _
    '                    " D.Div_Name,SM.Name AS SiteName,SD.Description AS DestinationPortName,C.Country AS DestinationPortCountry, " & _
    '                    " I.Description AS ItemDesc,Vt.Description AS OrderTypeDesc,RD.Description AS DesignDesc,RS.Description AS SizeDesc " & _
    '                    " FROM " & bTableName & " SO " & _
    '                    " LEFT JOIN " & bSecTableName & "" & _
    '                    " LEFT JOIN Division D ON D.Div_Code=SO.Div_Code  " & _
    '                    " LEFT JOIN SiteMast SM ON SM.Code=SO.Site_Code  " & _
    '                    " LEFT JOIN SeaPort SD ON SD.Code=SO.DestinationPort  " & _
    '                    " LEFT JOIN City C ON C.CityCode=SD.City  " & _
    '                    " LEFT JOIN Item I ON I.Code=SO1.Item  " & _
    '                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type =SO.V_Type " & _
    '                    " LEFT JOIN RUG_CarpetSku CS ON CS.Code=SO1.Item " & _
    '                    " LEFT JOIN RUG_Design RD ON RD.Code=CS.Design " & _
    '                    " LEFT JOIN Rug_Size RS ON RS.Code=CS.Size " & _
    '                    " " & bCondstr & ""

    '        AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
    '        AgL.ADMain.Fill(DsRep)
    '        AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
    '        mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
    '        mCrd.SetDataSource(DsRep.Tables(0))
    '        CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
    '        AgPL.Formula_Set(mCrd, RepTitle)
    '        AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

    '        Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
    '    Catch Ex As Exception
    '        MsgBox(Ex.Message)
    '    Finally
    '        Me.Cursor = Cursors.Default
    '    End Try
    'End Sub

    Private Sub TempSaleOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        mLastKeyPressed = e.KeyCode
    End Sub

    Private Sub Topctrl1_tbSite() Handles Topctrl1.tbSite
        Dim FrmObj As Form = Nothing
        Try
            PnlSettings.Visible = True
            PnlSettings.Left = 320
            PnlSettings.Top = 100
            TxtShowIndentInLine.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcSavePurchOrderSettings()
        Dim mTrans As Boolean = False
        Try
            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            mQry = " UPDATE Enviro SET " & _
                    " PurchOrderShowIndentInLine = " & IIf(AgL.StrCmp(TxtShowIndentInLine.Text, "Yes"), 1, 0) & " "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False
        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcLoadSettings()
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = " Select E.PurchOrderShowIndentInLine From Enviro E "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                If .Rows.Count > 0 Then
                    TxtShowIndentInLine.Text = IIf(AgL.VNull(.Rows(0)("PurchOrderShowIndentInLine")) = 0, "No", "Yes")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        Call ProcSavePurchOrderSettings()
        PnlSettings.Visible = False
        Call ProcLoadSettings()
        Call ProcAdjustGrid()
    End Sub

    Private Sub ProcAdjustGrid()
        Try
            If AgL.StrCmp(TxtShowIndentInLine.Text, "Yes") Then
                Dgl1.Columns(Col1IndentNo).Visible = True
            Else
                Dgl1.Columns(Col1IndentNo).Visible = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AgCalcGrid1_Calculated() Handles AgCalcGrid1.Calculated
        AgCShowGrid1.MoveRec_FromCalcGrid()
        AgCShowGrid2.MoveRec_FromCalcGrid()
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try

            Dim bRData As String
            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo FROM PurchChallanDetail   L LEFT JOIN PurchChallan  H ON L.DocId = H.DocID WHERE L.PurchOrder  = '" & TxtDocId.Text & "') AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Purchase Challan " & bRData & " created against Order No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
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

    Private Sub TempPurchaseOrder_BaseFunction_Create() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = "SELECT Sg.SubCode, Sg.DispName AS [Name], Sg.ManualCode, C.CityName AS [City],  " & _
                " C.State, C.Country, C.CityCode, Dc.Country As DestinationCountry, " & _
                " Sg.Add1, Sg.Add2, Sg.Add3, P.SeaPort, P.Currency, IsNull(Sg.IsDeleted,0) AS IsDeleted, " & _
                " isnull(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                " P.BankName, P.BankAddress, P.BankAcNo, Sg.SalesTaxPostingGroup, Sg.Div_Code " & _
                " FROM Vendor P " & _
                " LEFT JOIN SubGroup Sg ON P.SubCode = Sg.subCode " & _
                " LEFT JOIN City C ON Sg.CityCode = C.CityCode  " & _
                " LEFT JOIN seaport SP ON P.SeaPort = SP.Code  " & _
                " LEFT JOIN City Dc ON sp.City = Dc.CityCode  " & _
                " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
        HelpDataSet.Vendor = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select CityCode, CityName As [Name], State, Country, IsNull(IsDeleted,0) as IsDeleted " & _
                " From City " & _
                " Order By CityName"
        HelpDataSet.City = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Code AS Currency, IsNull(IsDeleted,0) AS IsDeleted FROM Currency ORDER BY Code "
        HelpDataSet.Currency = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Description  FROM Structure ORDER BY Description "
        HelpDataSet.AgStructure = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Description AS Code, Description, IsNull(Active,0)  FROM PostingGroupSalesTaxParty "
        HelpDataSet.SalesTaxGroupParty = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT 'Qty' AS Code, 'Qty' AS Name " & _
                " Union ALL " & _
                " SELECT 'Measure' AS Code, 'Measure' AS Name"
        HelpDataSet.BillingType = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Sg.SubCode AS Code, Sg.DispName AS Name,  " & _
                " IsNull(Sg.IsDeleted,0) AS IsDeleted, " & _
                " isnull(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                " Sg.Div_Code " & _
                " FROM Agent H " & _
                " LEFT JOIN SubGroup Sg ON H.SubCode = Sg.SubCode"
        HelpDataSet.Agent = AgL.FillData(mQry, AgL.GCn)

        'Start Code Change By Satyam on 18/11/2011
        mQry = " SELECT P.DocID AS Code,P.V_Type + '-' +convert(NVARCHAR(5),P.V_No) AS [Quatation No] ,P.V_Date AS [Quatation Date], " & _
                " P.VendorQuoteNo AS [Vendor Quat. No],I.V_Type + '-' +convert(NVARCHAR(5),I.V_No) AS [Indent No],P.PurchIndent, " & _
                " isnull(P.IsDeleted,0) AS IsDeleted, P.Div_Code , " & _
                " isnull(P.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status , P.Vendor, Vt.NCat, " & _
                " P.V_Date As QuotationDate, P.MoveToLog  " & _
                " FROM PurchQuotation  P " & _
                " LEFT JOIN PurchIndent I ON I.DocID=P.PurchIndent " & _
                " LEFT JOIN Voucher_Type Vt On P.V_Type = Vt.V_Type " & _
                " Where " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " "
        HelpDataSet.QuotationNo = AgL.FillData(mQry, AgL.GCn)
        'End Code Change By Satyam on 18/11/2011

        mQry = " Select 'CIF' As Code, 'CIF' As Description " & _
                " UNION ALL " & _
                " Select 'FOB' As Code, 'FOB' As Description " & _
                " UNION ALL " & _
                " Select 'FOR' As Code, 'FOR' As Description "
        HelpDataSet.PriceMode = AgL.FillData(mQry, AgL.GCn)

        'Start Code Change By Satyam on 18/11/2011
        mQry = " SELECT P.DocID AS Code,P.V_Type + '-' +convert(NVARCHAR(5),P.V_No) AS [Indent No] , " & _
                 " SG.DispName AS [Indent By],P.V_Date AS [Indent Date], " & _
                 " isnull(P.IsDeleted,0) AS IsDeleted, P.Div_Code , " & _
                 " isnull(P.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status," & _
                 " isnull(V1.BalItem,0) AS BalItem, Vt.NCat, P.MoveToLog " & _
                 " FROM PurchIndent P " & _
                 " LEFT JOIN  " & _
                 " (  " & _
                 " SELECT PD.DocId,count(PD.item) BalItem  " & _
                 " FROM PurchIndentDetail PD " & _
                 " WHERE PD.IndentQty > PD.OrdQty  " & _
                 " GROUP BY PD.DocId " & _
                 " ) V1 ON V1.DocId = P.DocID " & _
                 " LEFT JOIN SubGroup SG On SG.SubCode = P.Indentor " & _
                 " LEFT JOIN Voucher_Type Vt On P.V_Type = Vt.V_Type " & _
                 " Where " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " "
        HelpDataSet.IndentNo = AgL.FillData(mQry, AgL.GCn)
        'End Code Change By Satyam on 18/11/2011

        mQry = " SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                    " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                    " I.Measure AS MeasurePerPcs, MeasureUnit, 0 AS Qty,0 AS TotalMeasure,'' AS RequireDate " & _
                    " FROM Item I"
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT RD.Item AS Code,I.Description AS [Item Name], RD.IndentQty AS Qty , RD.OrdQty,  " & _
                " RD.IndentQty - RD.OrdQty As BalanceQty, RD.DocId AS IndentDocId," & _
                " RD.Unit,RD.MeasurePerPcs , I.ItemType , I.SalesTaxPostingGroup ," & _
                " RD.MeasureUnit, RD.TotalIndentMeasure AS TotalMeasure, " & _
                " Isnull(H.IsDeleted,0) As IsDeleted,  " & _
                " Isnull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS  Status, " & _
                " H.Div_Code " & _
                " FROM PurchIndentDetail RD " & _
                " LEFT JOIN PurchIndent H On Rd.DocId = H.DocId " & _
                " LEFT JOIN Item I ON I.Code=RD.Item "
        HelpDataSet.ItemFromIndent = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Function Validate_PurchIndent(ByVal Sender As Object, Optional ByVal RowIndex As Integer = 0) As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            Select Case Sender.Name
                Case Dgl1.Name
                    If Dgl1.AgSelectedValue(Col1IndentNo, RowIndex) <> "" Then
                        DrTemp = Dgl1.AgHelpDataSet(Col1IndentNo).Tables(0).Select("Code = '" & Dgl1.AgSelectedValue(Col1IndentNo, RowIndex) & "' ")
                        If DrTemp.Length > 0 Then
                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                                MsgBox("Currently Purchase Indent """ & Dgl1.Item(Col1IndentNo, RowIndex).Value & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                                Dgl1.AgSelectedValue(Col1IndentNo, RowIndex) = ""
                                Exit Function
                            End If

                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                                MsgBox("Currently Purchase Indent """ & Dgl1.Item(Col1IndentNo, RowIndex).Value & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                                Dgl1.AgSelectedValue(Col1IndentNo, RowIndex) = ""
                                Exit Function
                            End If
                        End If
                    End If
                    Validate_PurchIndent = True

                Case TxtIndentNo.Name
                    If TxtIndentNo.AgSelectedValue <> "" Then
                        DrTemp = TxtIndentNo.AgHelpDataSet().Tables(0).Select("Code = '" & TxtIndentNo.AgSelectedValue & "' ")
                        If DrTemp.Length > 0 Then
                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                                MsgBox("Currently Purchase Indent """ & TxtIndentNo.Text & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                                TxtIndentNo.AgSelectedValue = "" : Exit Function
                            End If

                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                                MsgBox("Currently Purchase Indent """ & TxtIndentNo.Text & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                                TxtIndentNo.AgSelectedValue = "" : Exit Function
                            End If
                        End If
                    End If
                    Validate_PurchIndent = True
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function Validate_PurchQuotation() As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            If TxtQutationNo.Text <> "" Then
                DrTemp = TxtQutationNo.AgHelpDataSet.Tables(0).Select("Code = '" & TxtQutationNo.AgSelectedValue & "' ")
                If DrTemp.Length > 0 Then
                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                        MsgBox("Currently Purchase Quotation """ & TxtQutationNo.Text & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtQutationNo.Text = ""
                        Exit Function
                    End If

                    If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                        MsgBox("Currently Purchase Quotation """ & TxtQutationNo.Text & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtQutationNo.Text = ""
                        Exit Function
                    End If
                End If
            End If
            Validate_PurchQuotation = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub TxtIndentNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtIndentNo.Validating, TxtQutationNo.Validating, TxtReferenceNo.Validating
        Try
            Select Case sender.Name
                Case TxtIndentNo.Name
                    e.Cancel = Not Validate_PurchIndent(TxtIndentNo)

                Case TxtQutationNo.Name
                    e.Cancel = Not Validate_PurchQuotation()

                Case TxtReferenceNo.Name
                    e.Cancel = Not FCheckDuplicateRefNo()

            End Select
        Catch ex As Exception
        End Try
    End Sub
    'Code Start By Satyam on 18/11/2011
    Private Sub FillIndentdetail(ByVal bIndentDocId As String)
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer
        mQry = " SELECT H.DocID,L.Item,I.Description AS ItemDesc,I.WoolColour,L.IndentQty, " & _
                " L.Unit,L.Sr,L.Rate,L.OrdQty,L.IndentQty-L.OrdQty AS BalQty, I.SalesTaxPostingGroup  " & _
                " FROM PurchIndent H " & _
                " LEFT JOIN PurchIndentDetail L ON L.DocId=H.DocID  " & _
                " LEFT JOIN Item I ON I.Code = L.Item " & _
                " WHERE H.DocId =" & AgL.Chk_Text(bIndentDocId) & " AND L.IndentQty-L.OrdQty > 0"
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                    Dgl1.Rows.Add()
                    Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                    Dgl1.AgSelectedValue(Col1IndentNo, I) = AgL.XNull(.Rows(I)("DocID"))
                    Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                    Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                    Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("BalQty"))
                    'Dgl1.Item(Col1Rate, I).Value = AgL.VNull(.Rows(I)("Rate"))
                    Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxPostingGroup"))

                    'Call Validating_WoolItem(Dgl1.AgSelectedValue(Col1Item, I), I)
                    'AgCalcGrid1.FCopyStructureLine(AgL.XNull(.Rows(I)("DocId")), Dgl1, I, AgL.VNull(.Rows(I)("Sr")))
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)
                Next I
            End If
        End With

        Call Calculation()

    End Sub

    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            If TxtIndentNo.Text.ToString.Trim <> "" Or TxtIndentNo.AgSelectedValue.Trim <> "" Then
                Call FillIndentdetail(TxtIndentNo.AgSelectedValue)
            End If
        End If
    End Sub

    Private Sub ProcFillReferenceNo()
        If TxtReferenceNo.Text = "" Then
            If TxtV_Type.Text.ToString.Trim <> "" Or TxtV_Type.AgSelectedValue.Trim <> "" Then
                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + TxtV_No.Text
            End If
        End If
    End Sub

    Private Sub ProcFillTermCondition()
        If TxtTermsAndConditions.Text = "" Then
            If TxtV_Type.Text.ToString.Trim <> "" Or TxtV_Type.AgSelectedValue.Trim <> "" Then
                mQry = " SELECT ISNULL(H.Description,'')  FROM TermsCondition H " & _
                        " WHERE H.Code ='" & TxtV_Type.AgSelectedValue & "' "
                TxtTermsAndConditions.Text = AgL.Dman_Execute(mQry, AgL.GCn, AgL.ECmd).ExecuteScalar
            End If
        End If
    End Sub
    'Code End By Satyam on 18/11/2011

    Private Sub ProcShowPurchaseOrderDetail(ByVal Item As String)
        Dim DtTemp As DataTable = Nothing
        Dim Cnt As Integer = 0
        Try
            If DtPurchaseEnviro Is Nothing Then Exit Sub
            If DtPurchaseEnviro.Rows.Count = 0 Then Exit Sub

            If AgL.VNull(DtPurchaseEnviro.Rows(0)("ShowLastPoRates")) = 0 Then Exit Sub

            If Item = "" Then Dgl.DataSource = Nothing : Exit Sub

            If DtItemDetail IsNot Nothing Then
                If DtItemDetail.Rows.Count > 0 Then
                    Cnt = DtItemDetail.Select(" Item = '" & Item & "' ").Length
                End If
            End If

            If Cnt = 0 Then
                mQry = " SELECT TOP " & AgL.VNull(DtPurchaseEnviro.Rows(0)("ShowRecordCount")) & " H.V_Date AS [Invoice Date], " & _
                        " L.Item, Sg.DispName AS Vendor, " & _
                        " L.Rate, L.Qty " & _
                        " FROM PurchInvoiceDetail L  " & _
                        " LEFT JOIN  PurchInvoice H ON L.DocId = H.DocId " & _
                        " LEFT JOIN SubGroup Sg ON H.Vendor = Sg.SubCode " & _
                        " Where L.Item = '" & Item & "'" & _
                        " ORDER BY H.V_Date DESC	 "
                DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

                If DtItemDetail Is Nothing Then
                    DtItemDetail = DtTemp.Copy
                Else
                    DtItemDetail.Merge(DtTemp)
                End If
            End If

            Dgl.DataSource = DtItemDetail
            Dgl.DataSource.DefaultView.RowFilter = " Item = '" & Item & "' "

            Me.Controls.Add(Dgl)
            Dgl.Left = Me.Left + 3
            Dgl.Top = Me.Bottom - Dgl.Height - 100
            Dgl.Height = 130
            Dgl.Width = 350
            Dgl.ColumnHeadersHeight = 40
            Dgl.AllowUserToAddRows = False
            Dgl.Columns("Invoice Date").Width = 82
            Dgl.Columns("Vendor").Width = 140
            Dgl.Columns("Rate").Width = 60
            Dgl.Columns("Qty").Width = 60
            Dgl.Columns("Invoice Date").SortMode = DataGridViewColumnSortMode.NotSortable
            Dgl.Columns("Vendor").SortMode = DataGridViewColumnSortMode.NotSortable
            Dgl.Columns("Rate").SortMode = DataGridViewColumnSortMode.NotSortable
            Dgl.Columns("Qty").SortMode = DataGridViewColumnSortMode.NotSortable
            Dgl.Columns("Rate").CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            Dgl.Columns("Qty").CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            Dgl.Columns("Rate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            Dgl.Columns("Qty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
            Dgl.RowHeadersVisible = False
            Dgl.EnableHeadersVisualStyles = False
            Dgl.AllowUserToResizeRows = False
            Dgl.ReadOnly = True
            Dgl.Columns("Item").Visible = False
            Dgl.AutoResizeRows()
            Dgl.AutoResizeColumnHeadersHeight()
            Dgl.BackgroundColor = Color.Cornsilk
            Dgl.ColumnHeadersDefaultCellStyle.BackColor = Color.Cornsilk
            Dgl.DefaultCellStyle.BackColor = Color.Cornsilk
            Dgl.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
            Dgl.CellBorderStyle = DataGridViewCellBorderStyle.None
            Dgl.Font = New Font(New FontFamily("Verdana"), 8)
            Dgl.ColumnHeadersDefaultCellStyle.Font = New Font(New FontFamily("Verdana"), 8, FontStyle.Bold)
            Dgl.BringToFront()
            Dgl.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillEnviro(ByVal V_Type As String)
        Try
            mQry = " SELECT H.* FROM PurchaseEnviro H WHERE H.Site_Code = '" & AgL.PubSiteCode & "' AND H.V_Type = '" & EntryNCat & "' "
            DtPurchaseEnviro = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.RowEnter
        Try
            ProcShowPurchaseOrderDetail(Dgl1.AgSelectedValue(Col1Item, e.RowIndex))
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgl1.Leave
        Dgl.Visible = False
    End Sub
End Class
