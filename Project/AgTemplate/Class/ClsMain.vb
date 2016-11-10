Public Class ClsMain    
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "AgTemplate"

    Public PubIsLinkWithFA As Byte = 0
    Public PubIsNegativeStockAllowed As Byte = 0
    Public PubIsLotNoApplicable As Byte = 0

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain)
        AgL = AgLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)
        ClsVar_Utility = New Utility.ClsMain(AgL)
    End Sub

    Public Enum EntryPointType
        Main
        Log
    End Enum

    Public Class EntryStatus
        Public Const Active As String = "Active"
        Public Const Inactive As String = "Inactive"
        Public Const Cancelled As String = "Cancelled"
    End Class

    Public Class LogStatus
        Public Const LogOpen As String = "Open"
        Public Const LogDiscard As String = "Discard"
        Public Const LogApproved As String = "Approved"
    End Class

    Public Class PaymentReceiptType
        Public Const Payment As String = "Payment"
        Public Const Receipt As String = "Receipt"
        Public Const DebitNote As String = "Debit Note"
        Public Const CreditNote As String = "Credit Note"
    End Class

    Class AcNature
        Public Const Bank As String = "Bank"
        Public Const Cash As String = "Cash"
        Public Const Customer As String = "Customer"
        Public Const Employee As String = "Employee"
        Public Const Expenses As String = "Expenses"
        Public Const Others As String = "Others"
        Public Const Purchase As String = "Purchase"
        Public Const Sales As String = "Sales"
        Public Const Supplier As String = "Supplier"
        Public Const TDS As String = "T.D.S."
        Public Const Transporter As String = "Transporter"
        Public Const Unloader As String = "Unloader"
    End Class

    Class AcGroup
        Public Const CapitalAccount As String = "0001"
        Public Const LoanLiability As String = "0002"
        Public Const CurrentLiabilities As String = "0003"
        Public Const FixedAssets As String = "0004"
        Public Const Investments As String = "0005"
        Public Const CurrentAssets As String = "0006"
        Public Const BranchDivisions As String = "0007"
        Public Const MiscExpencesAsset As String = "0008"
        Public Const SuspenseAc As String = "0009"
        Public Const ClosingStock As String = "000A"
        Public Const ReservesSurplus As String = "0010"
        Public Const BankODAc As String = "0011"
        Public Const SecuredLoans As String = "0012"
        Public Const UnsecuredLoans As String = "0013"
        Public Const DutiesTaxes As String = "0014"
        Public Const Provisions As String = "0015"
        Public Const SundryCreditors As String = "0016"
        Public Const OpeningStock As String = "0017"
        Public Const DepositsAsset As String = "0018"
        Public Const LoansAdvancesAsset As String = "0019"
        Public Const SundryDebtors As String = "0020"
        Public Const CashInHand As String = "0021"
        Public Const BankAccounts As String = "0022"
        Public Const SalesAccounts As String = "0023"
        Public Const PurchaseAccounts As String = "0024"
        Public Const DirectIncomes As String = "0025"
        Public Const DirectExpenses As String = "0026"
        Public Const IndirectIncomes As String = "0027"
        Public Const IndirectExpenses As String = "0028"
        Public Const ProfitLossAc As String = "0029"
    End Class

    Class Temp_NCat
        'Common NCat
        Public Const StockOpening As String = "OPSTK"
        Public Const AdjustmentIssue As String = "ADISS"
        Public Const AdjustmentReceive As String = "ADREC"
        Public Const StockTransferIssue As String = "TRFI"
        Public Const StockTransferReceive As String = "TRFR"
        Public Const PhysicalStockEntry As String = "PHSTK"

        'Production NCat
        Public Const ProductionOrder As String = "PRO"
        Public Const ProductionPlan As String = "PRP"
        Public Const MaterialPlan As String = "MP"
        Public Const JobOrder As String = "JO"
        Public Const JobIssue As String = "JI"
        Public Const JobReceive As String = "JR"

        'Purchase NCat
        Public Const PurchaseIndent As String = "IND"
        Public Const PurchaseQuotation As String = "PQOT"
        Public Const PurchaseQuotSelection As String = "PQOTS"
        Public Const PurchaseOrder As String = "PO"
        Public Const GoodsReceipt As String = "GR"
        Public Const PurchaseInvoice As String = "PINV"
        Public Const PurchaseReturn As String = "PRET"

        'Sale
        Public Const SaleOrder As String = "SO"
        Public Const SaleInvoice As String = "SI"
        Public Const SaleChallan As String = "SCHLN"

        'Payment
        Public Const Payment As String = "PMNT"
        Public Const Receipt As String = "RECT"
        Public Const DebitNote As String = "DNOTE"
        Public Const CreditNote As String = "CNOTE"

        'For Import Export
        Public Const DocumentEntry As String = "DOC"
        Public Const ShipmentEntry As String = "SHIP"

        'For Form Management
        Public Const FormReceive As String = "FRCV"
        Public Const FormIssue As String = "FISS"

        'Gate InOut
        Public Const VehicleGate As String = "VGATE"

        'Visitor InOut
        Public Const VisitorGate As String = "PGATE"
    End Class

    Public Class Charges
        Public Const ADDITIONALDUTY As String = "ADUTY"
        Public Const CUSTOMDUTY As String = "CD"
        Public Const CUSTOMDUTYECESS As String = "CDEC"
        Public Const CUSTOMDUTYHECESS As String = "CDHEC"
        Public Const CUSTOMDUTYTAXABLEAMT As String = "CDTA"
        Public Const CST As String = "CST"
        Public Const DISCOUNT As String = "DIS"
        Public Const DISCOUNTPRETAX As String = "DPTAX"
        Public Const FREIGHT As String = "FRT"
        Public Const GROSSAMOUNT As String = "GAMT"
        Public Const HANDLINGCHARGES As String = "HCHRG"
        Public Const INCENTIVE As String = "INCENT"
        Public Const INSURANCE As String = "INS"
        Public Const NETAMOUNT As String = "NAMT"
        Public Const OTHERADDITIONSPRETAX As String = "OAPTAX"
        Public Const OTHERCHARGES As String = "OC"
        Public Const PENALTY As String = "PENALTY"
        Public Const ROUNDOFF As String = "RO"
        Public Const SAT As String = "SAT"
        Public Const SUBTOTAL As String = "STOT"
        Public Const SALESTAXTAXABLEAMT As String = "STTA"
        Public Const TOTALCUSTOMDUTY As String = "TCD"
        Public Const VAT As String = "VAT"
        Public Const LANDEDVALUE As String = "LV"
        Public Const SERVICETAXECESS As String = "SECESS"
        Public Const SERVICETAX As String = "SERV"
        Public Const SERVICETAXASSESABLEAMT As String = "SERV_AA"
        Public Const SERVICETAXHECESS As String = "SHECESS"
        Public Const TotalFreight As String = "TFRT"
    End Class

    Public Class JobReceiveFor
        Public Const JobOrder As String = "Job Order"
        Public Const JobIssue As String = "Job Issue"
    End Class

    Public Class JobType
        Public Const Inside As String = "Inside"
        Public Const Outside As String = "Outside"
    End Class

    Public Enum JobWithMaterialYN
        NA
        Yes
        No
    End Enum

    Public Enum JobReceiveBillPosting
        Dues
        ToBeBilled
        Dues_JobOrderWise
        NA
        None
    End Enum

    Public Enum JobOrderType
        JobOrder
        JobOrder_With_Issue
        JobOrder_Cancel
        NA
    End Enum

    Public Class JobOrderFor
        Public Const ProductionOrder As String = "Production Order"
        Public Const Stock As String = "Stock"
        Public Const Sample As String = "Sample"
    End Class

    Public Class StockStatus
        Public Const Standard As String = "Standard"
        Public Const Rejected As String = "Rejected"
        Public Const Damaged As String = "Damaged"
    End Class

    Public Class SaleOrderStatus
        Public Const Active As String = "Active"
        Public Const Hold As String = "Hold"
        Public Const Cancelled As String = "Cancelled"
        Public Const Closed As String = "Closed"
    End Class

    Public Class Unit
        Public Const Pcs As String = "Pcs"
        Public Const Kg As String = "Kg"
        Public Const Meter As String = "Meter"
        Public Const Liter As String = "Liter"
        Public Const SqYard As String = "Sq.Yard"
    End Class

    Public Structure StructStock
        Dim DocID As String
        Dim Sr As String
        Dim V_Type As String
        Dim V_Prefix As String
        Dim V_Date As String
        Dim V_No As String
        Dim Div_Code As String
        Dim Site_Code As String
        Dim SubCode As String
        Dim Currency As String
        Dim SalesTaxGroupParty As String
        Dim Structure1 As String
        Dim BillingType As String
        Dim Item As String
        Dim ProcessGroup As String
        Dim Godown As String
        Dim Qty_Iss As Double
        Dim Qty_Rec As Double
        Dim Unit As String
        Dim LotNo As String
        Dim MeasurePerPcs As Double
        Dim Measure_Iss As Double
        Dim Measure_Rec As Double
        Dim MeasureUnit As String
        Dim Rate As Double
        Dim Amount As Double
        Dim Addition As Double
        Dim Deduction As Double
        Dim NetAmount As Double
        Dim Remarks As String
        Dim Status As String
        Dim UID As String
        Dim Process As String
        Dim FIFORate As Double
        Dim FIFOAmt As Double
        Dim AVGRate As Double
        Dim AVGAmt As Double
        Dim Cost As Double
        Dim Doc_Qty As Double
        Dim ReferenceDocID As String
    End Structure

#Region "Public Help Queries"
    Public Class HelpQueries
        Public Const StockStatus As String = "Select '" & ClsMain.StockStatus.Standard & "' as Code, '" & ClsMain.StockStatus.Standard & "' as Description " & _
                                                " Union All Select '" & ClsMain.StockStatus.Rejected & "' as Code, '" & ClsMain.StockStatus.Rejected & "' as Description " & _
                                                " Union All Select '" & ClsMain.StockStatus.Damaged & "' as Code, '" & ClsMain.StockStatus.Damaged & "' as Description "

        Public Const BillingType As String = "Select 'Qty' as Code, 'Qty' as Description " & _
                                            " Union All Select 'Area' as Code, 'Area' as Description "

    End Class

#End Region


#Region " Structure Update Code "

    Public Sub UpdateTableStructure_Production(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FProcessGroup(MdlTable, "ProcessGroup", EntryPointType.Main)
        FProcess(MdlTable, "Process", EntryPointType.Main)

        FBom(MdlTable, "BOM", EntryPointType.Main)
        FBom(MdlTable, "Bom_Log", EntryPointType.Log)

        FBomDetail(MdlTable, "BOMDetail", EntryPointType.Main)
        FBomDetail(MdlTable, "BomDetail_Log", EntryPointType.Log)

        FStock(MdlTable, "StockProcess", EntryPointType.Main)
        FStock(MdlTable, "StockProcess_Log", EntryPointType.Log)

        FStockUID(MdlTable, "StockUID", EntryPointType.Main)
        FStockUID(MdlTable, "StockUID_Log", EntryPointType.Log)

        FProdOrder(MdlTable, "ProdOrder", EntryPointType.Main)
        FProdOrder(MdlTable, "ProdOrder_Log", EntryPointType.Log)

        FProdOrderDetail(MdlTable, "ProdOrderDetail", EntryPointType.Main)
        FProdOrderDetail(MdlTable, "ProdOrderDetail_Log", EntryPointType.Log)


        FMaterialPlan(MdlTable, "MaterialPlan", EntryPointType.Main)
        FMaterialPlan(MdlTable, "MaterialPlan_Log", EntryPointType.Log)

        FMaterialPlanForDetail(MdlTable, "MaterialPlanForDetail", EntryPointType.Main)
        FMaterialPlanForDetail(MdlTable, "MaterialPlanForDetail_Log", EntryPointType.Log)

        FMaterialPlanDetail(MdlTable, "MaterialPlanDetail", EntryPointType.Main)
        FMaterialPlanDetail(MdlTable, "MaterialPlanDetail_Log", EntryPointType.Log)

        FMaterialPlanProcess(MdlTable, "MaterialPlanProcess", EntryPointType.Main)
    End Sub

    Public Sub UpdateTableStructureJob(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FJobWorker(MdlTable, "JobWorker", EntryPointType.Main)
        FJobWorker(MdlTable, "JobWorker_Log", EntryPointType.Log)

        FJobWorkerProcess(MdlTable, "JobWorkerProcess", EntryPointType.Main)
        FJobWorkerProcess(MdlTable, "JobWorkerProcess_Log", EntryPointType.Log)

        FJobOrder(MdlTable, "JobOrder", EntryPointType.Main)
        FJobOrder(MdlTable, "JobOrder_Log", EntryPointType.Log)

        FJobOrderDetail(MdlTable, "JobOrderDetail", EntryPointType.Main)
        FJobOrderDetail(MdlTable, "JobOrderDetail_Log", EntryPointType.Log)

        FJobOrderBom(MdlTable, "JobOrderBOM", EntryPointType.Main)
        FJobOrderBom(MdlTable, "JobOrderBOM_Log", EntryPointType.Log)

        FJobOrderQCInstruction(MdlTable, "JobOrderQCInstruction", EntryPointType.Main)
        FJobOrderQCInstruction(MdlTable, "JobOrderQCInstruction_Log", EntryPointType.Log)

        FJobOrderByProduct(MdlTable, "JobOrderByProduct", EntryPointType.Main)
        FJobOrderByProduct(MdlTable, "JobOrderByProduct_Log", EntryPointType.Log)

        FJobIssRec(MdlTable, "JobIssRec", EntryPointType.Main)
        FJobIssRec(MdlTable, "JobIssRec_Log", EntryPointType.Log)

        FJobIssRecUID(MdlTable, "JobIssRecUID", EntryPointType.Main)
        FJobIssRecUID(MdlTable, "JobIssRecUID_Log", EntryPointType.Log)

        FJobIssueDetail(MdlTable, "JobIssueDetail", EntryPointType.Main)
        FJobIssueDetail(MdlTable, "JobIssueDetail_Log", EntryPointType.Log)

        FJobReceiveDetail(MdlTable, "JobReceiveDetail", EntryPointType.Main)
        FJobReceiveDetail(MdlTable, "JobReceiveDetail_Log", EntryPointType.Log)

        FJobReceiveByProduct(MdlTable, "JobReceiveByProduct", EntryPointType.Main)
        FJobReceiveByProduct(MdlTable, "JobReceiveByProduct_Log", EntryPointType.Main)

        FJobReceiveBOM(MdlTable, "JobReceiveBOM", EntryPointType.Main)
        FJobReceiveBOM(MdlTable, "JobReceiveBOM_Log", EntryPointType.Log)

        FJobExchangeDetail(MdlTable, "JobExchangeDetail", EntryPointType.Main)
        FJobExchangeDetail(MdlTable, "JobExchangeDetail_Log", EntryPointType.Log)

        FJobInvoice(MdlTable, "JobInvoice", EntryPointType.Main)
        FJobInvoice(MdlTable, "JobInvoice_Log", EntryPointType.Log)

        FJobInvoiceDetail(MdlTable, "JobInvoiceDetail", EntryPointType.Main)
        FJobInvoiceDetail(MdlTable, "JobInvoiceDetail_Log", EntryPointType.Log)

        FJobInvoiceBOM(MdlTable, "JobInvoiceBom", EntryPointType.Main)
        FJobInvoiceBOM(MdlTable, "JobInvoiceBom_Log", EntryPointType.Log)

        FJobWorkerRateGroup(MdlTable, "JobWorkerRateGroup", EntryPointType.Main)
        FJobWorkerRateGroup(MdlTable, "JobWorkerRateGroup_Log", EntryPointType.Log)

		FJobWorkerRate(MdlTable, "JobWorkerRate", EntryPointType.Main)
        FJobWorkerRate(MdlTable, "JobWorkerRate_Log", EntryPointType.Log)

        FJobWorkerRateDetail(MdlTable, "JobWorkerRateDetail", EntryPointType.Main)
        FJobWorkerRateDetail(MdlTable, "JobWorkerRateDetail_Log", EntryPointType.Log)
    End Sub

    Public Sub UpdateTableStructurePurchase(ByRef MdlTable() As AgLibrary.ClsMain.LITable)

        FQCGroup(MdlTable, "QcGroup", EntryPointType.Main)
        FQCGroup(MdlTable, "QcGroup_Log", EntryPointType.Log)

        FQCGroupDetail(MdlTable, "QcGroupDetail", EntryPointType.Main)
        FQCGroupDetail(MdlTable, "QcGroupDetail_Log", EntryPointType.Log)

        FAgent(MdlTable, "Agent", EntryPointType.Main)
        FAgent(MdlTable, "Agent_Log", EntryPointType.Log)

        FAgentItem(MdlTable, "AgentItem", EntryPointType.Main)
        FAgentItem(MdlTable, "AgentItem_Log", EntryPointType.Log)

        FTransporter(MdlTable, "Transporter", EntryPointType.Main)
        FTransporter(MdlTable, "Transporter_Log", EntryPointType.Log)

        FVendor(MdlTable, "Vendor", EntryPointType.Main)
        FVendor(MdlTable, "Vendor_Log", EntryPointType.Log)

        FRequisition(MdlTable, "Requisition", EntryPointType.Main)
        FRequisition(MdlTable, "Requisition_Log", EntryPointType.Log)

        FRequisitionDetail(MdlTable, "RequisitionDetail", EntryPointType.Main)
        FRequisitionDetail(MdlTable, "RequisitionDetail_Log", EntryPointType.Log)

        FPurchaseIndent(MdlTable, "PurchIndent", EntryPointType.Main)
        FPurchaseIndent(MdlTable, "PurchIndent_Log", EntryPointType.Log)

        FPurchaseIndentDetail(MdlTable, "PurchIndentDetail", EntryPointType.Main)
        FPurchaseIndentDetail(MdlTable, "PurchIndentDetail_Log", EntryPointType.Log)

        FPurchaseIndentReq(MdlTable, "PurchIndentReq", EntryPointType.Main)
        FPurchaseIndentReq(MdlTable, "PurchIndentReq_Log", EntryPointType.Log)

        FPurchaseQuotation(MdlTable, "PurchQuotation", EntryPointType.Main)
        FPurchaseQuotation(MdlTable, "PurchQuotation_Log", EntryPointType.Log)

        FPurchaseQuotationDetail(MdlTable, "PurchQuotationDetail", EntryPointType.Main)
        FPurchaseQuotationDetail(MdlTable, "PurchQuotationDetail_Log", EntryPointType.Log)

        FPurchaseQuotSelection(MdlTable, "PurchQuotSelection", EntryPointType.Main)
        FPurchaseQuotSelection(MdlTable, "PurchQuotSelection_Log", EntryPointType.Log)

        FPurchaseQuotSelectionDetail(MdlTable, "PurchQuotSelectionDetail", EntryPointType.Main)
        FPurchaseQuotSelectionDetail(MdlTable, "PurchQuotSelectionDetail_Log", EntryPointType.Log)

        FPurchaseOrder(MdlTable, "PurchOrder", EntryPointType.Main)
        FPurchaseOrder(MdlTable, "PurchOrder_Log", EntryPointType.Log)

        FPurchaseOrderDetail(MdlTable, "PurchOrderDetail", EntryPointType.Main)
        FPurchaseOrderDetail(MdlTable, "PurchOrderDetail_Log", EntryPointType.Log)

        FPurchChallan(MdlTable, "PurchChallan", EntryPointType.Main)
        FPurchChallan(MdlTable, "PurchChallan_Log", EntryPointType.Log)

        FPurchChallanDetail(MdlTable, "PurchChallanDetail", EntryPointType.Main)
        FPurchChallanDetail(MdlTable, "PurchChallanDetail_Log", EntryPointType.Log)

        FQC(MdlTable, "QC", EntryPointType.Main)
        FQC(MdlTable, "QC_Log", EntryPointType.Log)

        FQcDetail(MdlTable, "QcDetail", EntryPointType.Main)
        FQcDetail(MdlTable, "QCDetail_Log", EntryPointType.Log)

        FQcParameterDetail(MdlTable, "QcParameterDetail", EntryPointType.Main)
        FQcParameterDetail(MdlTable, "QCParameterDetail_Log", EntryPointType.Log)

        FPurchInvoice(MdlTable, "PurchInvoice", EntryPointType.Main)
        FPurchInvoice(MdlTable, "PurchInvoice_Log", EntryPointType.Log)

        FPurchInvoiceDetail(MdlTable, "PurchInvoiceDetail", EntryPointType.Main)
        FPurchInvoiceDetail(MdlTable, "PurchInvoiceDetail_Log", EntryPointType.Log)

        FPurchaseEnviro(MdlTable, "PurchaseEnviro")
    End Sub

    Public Sub UpdateTableStructureSales(ByRef MdlTable() As AgLibrary.ClsMain.LITable)

        FAgent(MdlTable, "Agent", EntryPointType.Main)
        FAgent(MdlTable, "Agent_Log", EntryPointType.Log)

        FAgentItem(MdlTable, "AgentItem", EntryPointType.Main)
        FAgentItem(MdlTable, "AgentItem_Log", EntryPointType.Log)

        FTransporter(MdlTable, "Transporter", EntryPointType.Main)
        FTransporter(MdlTable, "Transporter_Log", EntryPointType.Log)

        FSaleQuotation(MdlTable, "SaleQuotation", EntryPointType.Main)
        FSaleQuotation(MdlTable, "SaleQuotation_Log", EntryPointType.Log)

        FSaleQuotationDetail(MdlTable, "SaleQuotationDetail", EntryPointType.Main)
        FSaleQuotationDetail(MdlTable, "SaleQuotationDetail_Log", EntryPointType.Log)

        FSaleOrder(MdlTable, "SaleOrder", EntryPointType.Main)
        FSaleOrder(MdlTable, "SaleOrder_Log", EntryPointType.Log)

        FSalesOrderPriority(MdlTable, "FSaleOrderPriority", EntryPointType.Main)
        FSalesOrderPriority(MdlTable, "FSaleOrderPriority_Log", EntryPointType.Log)

        FSalesOrderPriorityDetail(MdlTable, "FSaleOrderPriorityDetail", EntryPointType.Main)
        FSalesOrderPriorityDetail(MdlTable, "FSaleOrderPriorityDetail_Log", EntryPointType.Log)

        FSaleOrderDetail(MdlTable, "SaleOrderDetail", EntryPointType.Main)
        FSaleOrderDetail(MdlTable, "SaleOrderDetail_Log", EntryPointType.Log)

        FDeliveryOrder(MdlTable, "DeliveryOrder", EntryPointType.Main)
        FDeliveryOrder(MdlTable, "DeliveryOrder_Log", EntryPointType.Log)

        FDeliveryOrderDetail(MdlTable, "DeliveryOrderDetail", EntryPointType.Main)
        FDeliveryOrderDetail(MdlTable, "DeliveryOrderDetail_Log", EntryPointType.Log)



        FSaleInvoice(MdlTable, "SaleInvoice", EntryPointType.Main)
        FSaleInvoice(MdlTable, "SaleInvoice_Log", EntryPointType.Log)

        FSaleInvoiceDetail(MdlTable, "SaleInvoiceDetail", EntryPointType.Main)
        FSaleInvoiceDetail(MdlTable, "SaleInvoiceDetail_Log", EntryPointType.Log)

        FSaleChallan(MdlTable, "SaleChallan", EntryPointType.Main)
        FSaleChallan(MdlTable, "SaleChallan_Log", EntryPointType.Log)

        FSaleChallanDetail(MdlTable, "SaleChallanDetail", EntryPointType.Main)
        FSaleChallanDetail(MdlTable, "SaleChallanDetail_Log", EntryPointType.Log)

    End Sub

    Public Sub UpdateTableStructureExport(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FIE_Doc(MdlTable, "IE_Doc", EntryPointType.Main)
        FIE_Doc(MdlTable, "IE_Doc_Log", EntryPointType.Log)

        FIE_DocEntry(MdlTable, "IE_DocEntry", EntryPointType.Main)
        FIE_DocEntry(MdlTable, "IE_DocEntry_Log", EntryPointType.Log)

        FIE_DocAmend(MdlTable, "IE_DocAmend", EntryPointType.Main)
        FIE_DocAmend(MdlTable, "IE_DocAmend_Log", EntryPointType.Log)

        FIE_DocItem(MdlTable, "IE_DocItem", EntryPointType.Main)
        FIE_DocItem(MdlTable, "IE_DocItem_Log", EntryPointType.Log)

        FIE_Shipment(MdlTable, "IE_Shipment", EntryPointType.Main)
        FIE_Shipment(MdlTable, "IE_Shipment_Log", EntryPointType.Log)

        FIE_ShipmentDoc(MdlTable, "IE_ShipmentDoc", EntryPointType.Main)
        FIE_ShipmentDoc(MdlTable, "IE_ShipmentDoc_Log", EntryPointType.Log)

        FIE_ShipmentBOE(MdlTable, "IE_ShipmentBOE", EntryPointType.Main)
        FIE_ShipmentBOE(MdlTable, "IE_ShipmentBOE_Log", EntryPointType.Log)

        FIE_ShipmentItem(MdlTable, "IE_ShipmentItem", EntryPointType.Main)
        FIE_ShipmentItem(MdlTable, "IE_ShipmentItem_Log", EntryPointType.Log)

    End Sub

    Public Sub UpdateTableStructureForm(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FForm_Master(MdlTable, "Form_Master", EntryPointType.Main)
        FForm_Master(MdlTable, "Form_Master_Log", EntryPointType.Log)

        FForm_Receive(MdlTable, "Form_Receive", EntryPointType.Main)
        FForm_Receive(MdlTable, "Form_Receive_Log", EntryPointType.Log)

        FForm_ReceiveDetail(MdlTable, "Form_ReceiveDetail", EntryPointType.Main)
        FForm_ReceiveDetail(MdlTable, "Form_ReceiveDetail_Log", EntryPointType.Log)

    End Sub

    Public Sub UpdateTableStructureFA(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FLedgerM(MdlTable, "LedgerM", EntryPointType.Main)
        FLedger(MdlTable, "Ledger", EntryPointType.Main)
        FVoucher(MdlTable, "Voucher", EntryPointType.Main)
        FVoucherDetail(MdlTable, "VoucherDetail", EntryPointType.Main)
        FBank(MdlTable, "Bank", EntryPointType.Main)
        FBankBranch(MdlTable, "BankBranch", EntryPointType.Main)
        FNarrMast(MdlTable, "NarrMast", EntryPointType.Main)
        FCountry(MdlTable, "Country", EntryPointType.Main)
        FNature(MdlTable, "Nature", EntryPointType.Main)
        FChequePrint(MdlTable, "ChequePrint", EntryPointType.Main)
        FPermitForm(MdlTable, "PermitForm", EntryPointType.Main)
        FTdsCat_Det(MdlTable, "TdsCat_Det", EntryPointType.Main)
        FTDSCat(MdlTable, "TdsCat", EntryPointType.Main)
        FTDSCat_Description(MdlTable, "TDSCat_Description", EntryPointType.Main)
        FTDSLedger(MdlTable, "TdsLedger")
    End Sub

    Public Sub UpdateTableStructure(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        Try
            FSubGroupType(MdlTable, "SubGroupType")

            FSynchronise_Error(MdlTable, "Synchronise_Error")

            FTable_SearchField(MdlTable, "Table_SearchField")

            FUnit(MdlTable, "Unit")

            FAcGroup(MdlTable, "AcGroup")

            FCompany(MdlTable, "Company")

            FCurrency(MdlTable, "Currency")

            FDivision(MdlTable, "Division")

            FEntryPointPermission(MdlTable, "EntryPointPermission")

            FEnviro(MdlTable, "Enviro")

            FLog_TablePermission(MdlTable, "Log_TablePermission")

            FLog_TableRecords(MdlTable, "Log_TableRecords")

            FLogin_Log(MdlTable, "Login_Log")

            FLogTable(MdlTable, "LogTable")

            FSiteMast(MdlTable, "SiteMast")

            FSubGroup(MdlTable, "SubGroup", EntryPointType.Main)
            FSubGroup(MdlTable, "SubGroup_Log", EntryPointType.Log)

            FSubGroup_Image(MdlTable, "SubGroup_Image", EntryPointType.Main)
            FSubGroup_Image(MdlTable, "SubGroup_Image_Log", EntryPointType.Log)

            FCity(MdlTable, "City", EntryPointType.Main)
            FCity(MdlTable, "City_Log", EntryPointType.Log)


            FGodown(MdlTable, "Godown", EntryPointType.Main)
            FGodown(MdlTable, "Godown_Log", EntryPointType.Log)

            FGodownSection(MdlTable, "GodownSection", EntryPointType.Main)
            FGodownSection(MdlTable, "GodownSection_Log", EntryPointType.Log)

            FBuyer(MdlTable, "Buyer", EntryPointType.Main)
            FBuyer(MdlTable, "Buyer_Log", EntryPointType.Log)

            FItem(MdlTable, "Item", EntryPointType.Main)
            FItem(MdlTable, "Item_Log", EntryPointType.Log)

            FItem(MdlTable, "ItemRate", EntryPointType.Main)
            FItem(MdlTable, "ItemRate_Log", EntryPointType.Log)

            FItemCategory(MdlTable, "ItemCategory", EntryPointType.Main)
            FItemCategory(MdlTable, "ItemCategory_Log", EntryPointType.Log)

            FItemGroup(MdlTable, "ItemGroup", EntryPointType.Main)
            FItemGroup(MdlTable, "ItemGroup_Log", EntryPointType.Log)

            FItemBuyer(MdlTable, "ItemBuyer", EntryPointType.Main)
            FItemBuyer(MdlTable, "ItemBuyer_Log", EntryPointType.Log)

            FItem_UID(MdlTable, "Item_UID", EntryPointType.Main)
            FItem_UID(MdlTable, "Item_UID_Log", EntryPointType.Log)

            FStockHead(MdlTable, "StockHead", EntryPointType.Main)
            FStockHead(MdlTable, "StockHead_Log", EntryPointType.Log)

            FStock(MdlTable, "Stock", EntryPointType.Main)
            FStock(MdlTable, "Stock_Log", EntryPointType.Log)


            FEmployee(MdlTable, "Employee", EntryPointType.Main)
            FEmployee(MdlTable, "Employee_Log", EntryPointType.Log)

            FDepartment(MdlTable, "Department", EntryPointType.Main)
            FDepartment(MdlTable, "Department_Log", EntryPointType.Log)

            FEnviroDefaultGodown(MdlTable, "EnviroDefaultGodown")

            FUser_Control_Permission(MdlTable, "User_Control_Permission")

            FUser_Permission(MdlTable, "User_Permission")

            FUserMast(MdlTable, "UserMast")

            FUserSite(MdlTable, "UserSite")

            FVoucher_Exclude(MdlTable, "Voucher_Exclude")

            FVoucher_Include(MdlTable, "Voucher_Include")

            FVoucher_Prefix(MdlTable, "Voucher_Prefix")

            FVoucher_Prefix_Type(MdlTable, "Voucher_Prefix_Type")

            FVoucher_Type(MdlTable, "Voucher_Type")

            FVoucherCat(MdlTable, "VoucherCat")

            FGateInOut(MdlTable, "GateInOut", EntryPointType.Main)
            FGateInOut(MdlTable, "GateInOut_Log", EntryPointType.Log)

            FVisitorsGateInOut(MdlTable, "Visitor_GateInOut", EntryPointType.Main)
            FVisitorsGateInOut(MdlTable, "Visitor_GateInOut_Log", EntryPointType.Log)

            FDues(MdlTable, "Dues", EntryPointType.Main)
            FDues(MdlTable, "Dues_Log", EntryPointType.Main)

            FDuesPaymentEnviro(MdlTable, "DuesPaymentEnviro")

            FDuesPayment(MdlTable, "DuesPayment", EntryPointType.Main)
            FDuesPayment(MdlTable, "DuesPayment_Log", EntryPointType.Log)

            FDuesPaymentDetail(MdlTable, "DuesPaymentDetail", EntryPointType.Main)
            FDuesPaymentDetail(MdlTable, "DuesPaymentDetail_Log", EntryPointType.Log)

            FGBill(MdlTable, "GBill", EntryPointType.Main)
            FGBill(MdlTable, "GBill_Log", EntryPointType.Log)

            FGBillDetail(MdlTable, "GBillDetail", EntryPointType.Main)
            FGBillDetail(MdlTable, "GBillDetail_Log", EntryPointType.Log)

            FToBeBilled(MdlTable, "ToBeBilled", EntryPointType.Main)            

            FPhysicalStockDetail(MdlTable, "PhysicalStockDetail", EntryPointType.Main)
            FPhysicalStockDetail(MdlTable, "PhysicalStockDetail_Log", EntryPointType.Log)

            FTermsCondition(MdlTable, "TermsCondition", EntryPointType.Main)
            FTermsCondition(MdlTable, "TermsCondition_Log", EntryPointType.Log)

            FProcessGroup(MdlTable, "ProcessGroup", EntryPointType.Main)

            FItemType(MdlTable, "ItemType", EntryPointType.Main)



        'For Custom Fields

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateTableInitialiser()
        Call CreateVType()

        Call CreateView()

        Call FInitialize_Unit()

        Call FInitialize_Charges()
    End Sub

    Public Sub UpdateTableInitialiserProduction()
        Call FInitialize_ProcessGroup()
    End Sub

    Public Sub UpdateTableInitialiserFA()
        FInitialize_Nature()
        Finitialize_AcGroup()
        FInitialize_Subcode()
    End Sub

    Private Sub FInitialize_Subcode()
        Dim mQry$


        If AgL.Dman_Execute("Select Count(*) From Subgroup Where Subcode = 'PURCHASE'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.SubGroup (SubCode, Site_Code, Div_Code, SiteList, Name, DispName, GroupCode, GroupNature, ManualCode, Nature, U_Name, U_EntDt, U_AE, CommonAc) " & _
                 "VALUES ('PURCHASE', '" & AgL.PubSiteCode & "', '" & AgL.PubDivCode & "', '|" & AgL.PubSiteCode & "|', 'Purchase A/c', 'Purchase A/c', '" & AcGroup.PurchaseAccounts & "', 'L', 'PURCHASE', '" & AcNature.Purchase & "', 'SA', '2008-10-21', 'A', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Subgroup Where Subcode = 'DISCOUNT'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.SubGroup (SubCode, Site_Code, Div_Code, SiteList, Name, DispName, GroupCode, GroupNature, ManualCode, Nature, U_Name, U_EntDt, U_AE, CommonAc) " & _
                 "VALUES ('DISCOUNT', '" & AgL.PubSiteCode & "', '" & AgL.PubDivCode & "', '|" & AgL.PubSiteCode & "|', 'Discount A/c', 'Discount A/c', '" & AcGroup.DirectExpenses & "', 'L', 'DISCOUNT', 'Others', 'SA', '2008-10-21', 'A', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Subgroup Where Subcode = 'CASH'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.SubGroup (SubCode, Site_Code, Div_Code, SiteList, Name, DispName, GroupCode, GroupNature, ManualCode, Nature, U_Name, U_EntDt, U_AE, CommonAc) " & _
                 "VALUES ('CASH', '" & AgL.PubSiteCode & "', '" & AgL.PubDivCode & "', '|" & AgL.PubSiteCode & "|', 'Cash A/c', 'Cash A/c', '0021', 'A', 'CASH', 'Cash', 'SA', '2008-10-21', 'A', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Subgroup Where Subcode = 'BANK'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.SubGroup (SubCode, Site_Code, Div_Code, SiteList, Name, DispName, GroupCode, GroupNature, ManualCode, Nature, U_Name, U_EntDt, U_AE, CommonAc) " & _
                 "VALUES ('BANK', '" & AgL.PubSiteCode & "', '" & AgL.PubDivCode & "', '|" & AgL.PubSiteCode & "|', 'Bank A/c', 'Bank A/c', '0022', 'A', 'BANK', 'BANK', 'SA', '2008-10-21', 'A', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Subgroup Where Subcode = 'DNOTE'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.SubGroup (SubCode, Site_Code, Div_Code, SiteList, Name, DispName, GroupCode, GroupNature, ManualCode, Nature, U_Name, U_EntDt, U_AE, CommonAc) " & _
                 "VALUES ('DNOTE', '" & AgL.PubSiteCode & "', '" & AgL.PubDivCode & "', '|" & AgL.PubSiteCode & "|', 'Debit Note A/c', 'Debit Note A/c', '0009', 'A', 'DNOTE', 'Others', 'SA', '2008-10-21', 'A', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Subgroup Where Subcode = 'CNOTE'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.SubGroup (SubCode, Site_Code, Div_Code, SiteList, Name, DispName, GroupCode, GroupNature, ManualCode, Nature, U_Name, U_EntDt, U_AE, CommonAc) " & _
                 "VALUES ('CNOTE', '" & AgL.PubSiteCode & "', '" & AgL.PubDivCode & "', '|" & AgL.PubSiteCode & "|', 'Credit Note A/c', 'Credit Note A/c', '0009', 'A', 'CNOTE', 'Others', 'SA', '2008-10-21', 'A', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Subgroup Where Subcode = 'TDS'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.SubGroup (SubCode, Site_Code, Div_Code, SiteList, Name, DispName, GroupCode, GroupNature, ManualCode, Nature, U_Name, U_EntDt, U_AE, CommonAc) " & _
                 "VALUES ('TDS', '" & AgL.PubSiteCode & "', '" & AgL.PubDivCode & "', '|" & AgL.PubSiteCode & "|', 'TDS A/c', 'TDS A/c', '0014', 'L', 'TDS', 'Others', 'SA', '2008-10-21', 'A', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
    End Sub

    Private Sub FInitialize_Unit()
        Dim mQry$
        If AgL.Dman_Execute("Select Count(*) From Unit Where Code = '" & Unit.Pcs & "'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into Unit (Code) Values ('" & Unit.Pcs & "')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From Unit Where Code = '" & Unit.Kg & "'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into Unit (Code) Values ('" & Unit.Kg & "')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From Unit Where Code = '" & Unit.Meter & "'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into Unit (Code) Values ('" & Unit.Meter & "')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From Unit Where Code = '" & Unit.Liter & "'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into Unit (Code) Values ('" & Unit.Liter & "')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
    End Sub

    Private Sub FInitialize_ProcessGroup()
        Dim mQry$
        If AgL.Dman_Execute("Select Count(*) From ProcessGroup Where Code = 'Finishing'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ProcessGroup (Code, Description) Values ('Finishing','Finishing')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From ProcessGroup Where Code = 'Packing'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ProcessGroup (Code, Description) Values ('Packing','Packing')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From ProcessGroup Where Code = 'Other'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into ProcessGroup (Code, Description) Values ('Other','Other')"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
    End Sub

    Private Sub Finitialize_AcGroup()
        Dim mQry$
        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Capital Account'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0001', NULL, 'Capital Account', 'Capital Account', NULL, 'A', 'Customer', 'Y', 'SA', '2003-04-01', 'A', 'N', '010', 10, 3, 1, '1', 'Capital Account', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Loan (Liability)'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0002', NULL, 'Loan (Liability)', 'Loan (Liability)', NULL, 'L', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '020', 20, 3, 2, '1', 'Loan (Liability)', 0, 4, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Current Liabilities'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0003', NULL, 'Current Liabilities', 'Current Liabilities', NULL, 'L', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '030', 30, 3, 3, '1', 'Current Liabilities', 0, 4, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Fixed Assets'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0004', NULL, 'Fixed Assets', 'Fixed Assets', NULL, 'A', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '040', 40, 3, 4, '1', 'Fixed Assets', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Investments'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0005', NULL, 'Investments', 'Investments', NULL, 'A', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '050', 50, 3, 5, '1', 'Investments', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Current Assets'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0006', NULL, 'Current Assets', 'Current Assets', NULL, 'A', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '060', 60, 3, 6, '1', 'Current Assets', 0, 8, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Branch/Divisions'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                  "VALUES ('0007', NULL, 'Branch/Divisions', 'Branch/Divisions', NULL, 'A', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '070', 70, 3, 7, '1', 'Branch/Divisions', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Misc. Expences (Asset)'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0008', NULL, 'Misc. Expences (Asset)', 'Misc. Expences (Asset)', NULL, 'A', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '080', 80, 3, 8, '1', 'Misc. Expences (Asset)', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Suspense A/c'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0009', NULL, 'Suspense A/c', 'Suspense A/c', NULL, 'A', 'Others', 'Y', 'SA', '2008-07-02', 'E', 'N', '090', 90, 3, 9, '1', 'Suspense A/c', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Closing Stock'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('000A', NULL, 'Closing Stock', 'Closing Stock', NULL, 'R', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '060007', 0, 6, 10, '1', 'Closing Stock', 1, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Reserves & Surplus'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0010', NULL, 'Reserves & Surplus', 'Reserves & Surplus', NULL, 'L', 'Others', 'Y', 'SA', '2008-07-02', 'E', 'N', '010001', 100, 6, 11, '1', 'Reserves & Surplus', 1, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Bank OD A/c'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0011', NULL, 'Bank OD A/c', 'Bank OD A/c', NULL, 'L', 'Others', 'Y', 'SA', '2003-04-01', 'E', 'N', '020001', 110, 6, 12, '1', 'Bank OD A/c', 1, 1, 0, 'N', 'N', NULL, 0)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Secured Loans'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "   VALUES ('0012', NULL, 'Secured Loans', 'Secured Loans', NULL, 'L', 'Others', 'Y', 'SA', '2008-07-02', 'E', 'N', '020002', 120, 6, 13, '1', 'Secured Loans', 1, 1, 0, 'N', 'N', NULL, 0)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Unsecured Loans'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "   VALUES ('0013', NULL, 'Unsecured Loans', 'Unsecured Loans', NULL, 'L', 'Others', 'Y', 'SA', '2008-07-02', 'E', 'N', '020003', 130, 6, 14, '1', 'Unsecured Loans', 1, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Duties & Taxes'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0014', NULL, 'Duties & Taxes', 'Duties & Taxes', NULL, 'L', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '030001', 140, 6, 15, '1', 'Duties & Taxes', 1, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Provisions'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                  "  VALUES ('0015', NULL, 'Provisions', 'Provisions', NULL, 'L', 'Expenses', 'Y', 'SA', '2008-07-02', 'E', 'N', '030002', 150, 6, 16, '1', 'Provisions', 1, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Sundry Creditors'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0016', NULL, 'Sundry Creditors', 'Sundry Creditors', NULL, 'L', 'Supplier', 'Y', 'SA', '2008-07-02', 'E', 'N', '030003', 160, 6, 17, '1', 'Sundry Creditors', 1, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Opening Stock'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0017', NULL, 'Opening Stock', 'Opening Stock', NULL, 'A', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '060001', 170, 6, 18, '1', 'Opening Stock', 1, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Deposits (Asset)'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                   "VALUES ('0018', NULL, 'Deposits (Asset)', 'Deposits (Asset)', NULL, 'A', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '060002', 180, 6, 19, '1', 'Deposits (Asset)', 1, 1, 0, 'N', 'N', NULL, 0)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Loans & Advances (Asset)'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0019', NULL, 'Loans & Advances (Asset)', 'Loans & Advances (Asset)', NULL, 'A', 'Others', 'Y', 'SA', '2008-07-02', 'E', 'N', '060003', 190, 6, 20, '1', 'Loans & Advances (Asset)', 1, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Sundry Debtors'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0020', NULL, 'Sundry Debtors', 'Sundry Debtors', NULL, 'A', 'Customer', 'Y', 'SA', '2008-07-07', 'E', 'N', '060004', 200, 6, 21, '1', 'Sundry Debtors', 1, 1, 0, 'N', 'N', NULL, 0)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Cash-in-Hand'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                  "VALUES ('0021', NULL, 'Cash-in-Hand', 'Cash-in-Hand', NULL, 'A', 'Cash', 'Y', 'SA', '2008-07-05', 'E', 'N', '060005', 210, 6, 22, '1', 'Cash-in-Hand', 1, 1, 0, 'N', 'N', NULL, 0)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Bank Accounts'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0022', NULL, 'Bank Accounts', 'Bank Accounts', NULL, 'A', 'Bank', 'Y', 'SA', '2003-04-01', 'E', 'N', '060006', 220, 6, 23, '1', 'Bank Accounts', 1, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Sales Accounts'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0023', NULL, 'Sales Accounts', 'Sales Accounts', NULL, 'R', 'Sale', 'Y', 'SA', '2003-04-01', 'A', 'Y', '230', 230, 3, 24, '1', 'Sales Accounts', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Purchase Accounts'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0024', NULL, 'Purchase Accounts', 'Purchase Accounts', NULL, 'E', 'Purchase', 'Y', 'SA', '2003-04-01', 'A', 'Y', '240', 240, 3, 25, '1', 'Purchase Accounts', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Direct Incomes'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0025', NULL, 'Direct Incomes', 'Direct Incomes', NULL, 'R', 'Others', 'Y', 'SA', '2003-04-01', 'E', 'Y', '250', 250, 3, 26, '1', 'Direct Incomes', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Direct Expenses'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                   "VALUES ('0026', NULL, 'Direct Expenses', 'Direct Expenses', NULL, 'E', 'Others', 'Y', 'SA', '2003-04-01', 'E', 'Y', '260', 260, 3, 27, '1', 'Direct Expenses', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Indirect Incomes'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0027', NULL, 'Indirect Incomes', 'Indirect Incomes', NULL, 'R', 'Others', 'Y', 'SA', '2003-04-01', 'E', 'N', '270', 270, 3, 28, '1', 'Indirect Incomes', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Indirect Expenses'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                 "VALUES ('0028', NULL, 'Indirect Expenses', 'Indirect Expenses', NULL, 'E', 'Others', 'Y', 'SA', '2008-07-05', 'E', 'N', '280', 280, 3, 29, '1', 'Indirect Expenses', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From AcGroup Where GroupName = 'Profit & Loss A/c'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, ContraGroupName, GroupUnder, GroupNature, Nature, SysGroup, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance) " & _
                   "VALUES ('0029', NULL, 'Profit & Loss A/c', 'Profit & Loss A/c', NULL, 'L', 'Others', 'Y', 'SA', '2003-04-01', 'A', 'N', '999', 290, 3, 30, '1', 'Profit & Loss A/c', 0, 1, 0, 'N', 'N', NULL, 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
    End Sub

    Private Sub FInitialize_Nature()
        Dim mQry$

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'Bank'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "   VALUES ('Bank', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'Cash'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "VALUES ('Cash', 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'Customer'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "VALUES ('Customer', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'Employee'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "VALUES ('Employee', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'Expenses'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "VALUES ('Expenses', 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'Others'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "VALUES ('Others', 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'Purchase'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "VALUES ('Purchase', 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'Sales'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "VALUES ('Sales', 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'Supplier'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "VALUES ('Supplier', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'T.D.S.'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "VALUES ('T.D.S.', 0) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'Transporter'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "VALUES ('Transporter', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Nature Where Nature = 'Unloader'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Nature (Nature, Personal_Nature) " & _
                 "VALUES ('Unloader', 1) "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

    End Sub


    Private Sub FInitialize_Charges()
        Dim mQry$
        Dim mTableName As String = "Charges"

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'ADUTY'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate) " & _
                    " Values ('ADUTY', 'Additional Duty', 'ADUTY', 'D', '1', 'SUPER', '2011-09-17', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'CD'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
                    " Values ('CD', 'Custom Duty', 'CD', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'CDEC'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('CDEC', 'Custom Duty ECess', 'CDEC', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'CDHEC'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('CDHEC', 'Custom Duty HECess', 'CDHEC', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'CDTA'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('CDTA', 'Custom Duty Taxable Amt', 'CDTA', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'CST'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('CST', 'Cst', 'CST', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'DIS'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('DIS', 'Discount', 'DIS', 'M', '1', 'SUPER', '26/Aug/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'DPTAX'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('DPTAX', 'Discount Pre Tax', 'DPTAX', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'FRT'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('FRT', 'Freight', 'FRT', 'D', '1', 'SUPER', '23/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'GAMT'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('GAMT', 'Gross Amount', 'GAMT', 'D', '1', 'sa', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'HCHRG'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('HCHRG', 'Handling Charges', 'HCHRG', 'D', '1', 'SUPER', '23/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'INCENT'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('INCENT', 'Incentive', 'INCENT', 'D', '1', 'sa', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'INS'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('INS', 'Insurance', 'INS', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'NAMT'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('NAMT', 'Net Amount', 'NAMT', 'D', '1', 'sa', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'OAPTAX'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('OAPTAX', 'Other Additions Pre Tax', 'OAPTAX', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'OC'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('OC', 'Other Charges', 'OC', 'M', '1', 'SUPER', '26/Aug/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'PENALTY'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('PENALTY', 'Penalty', 'PENALTY', 'D', '1', 'sa', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'RO'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('RO', 'Round Off', 'RO', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'SAT'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('SAT', 'Sat', 'SAT', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'STOT'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('STOT', 'Sub Total', 'STOT', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'STTA'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('STTA', 'Sales Tax Taxable Amt', 'STTA', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'TCD'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('TCD', 'Total Custom Duty', 'TCD', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'VAT'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)    " & _
            " Values ('VAT', 'Vat', 'VAT', 'D', '1', 'SUPER', '17/Sep/2011 12:00:00 AM', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'LV'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)" & _
                " VALUES ('LV', 'Landed Value', 'LV', 'M', '1', 'SUPER', '2011-08-26', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'SECESS'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)" & _
                " VALUES ('SECESS', 'Service Tax ECess', 'SECESS', 'M', '1', 'SA', '2011-10-23', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'SERV'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)" & _
                " VALUES ('SERV', 'Service Tax', 'SERV', 'M', '1', 'SA', '2011-10-19', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'SERV_AA'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)" & _
                " VALUES ('SERV_AA', 'Service Tax Assesable Amt', 'SERV_AA', 'M', '1', 'SA', '2011-10-23', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'SHECESS'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)" & _
                " VALUES ('SHECESS', 'Service Tax HECess', 'SHECESS', 'M', '1', 'SA', '2011-10-23', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.Dman_Execute("Select Count(*) From Charges Where Code = 'TFRT'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)" & _
                " VALUES ('TFRT', 'Total Freight', 'TFRT', 'M', '1', 'SA', '2011-10-20', 'A', NULL, NULL, NULL)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
    End Sub




    Sub AddNewField()
        Dim mQry$ = ""
        Try
            ''============================< Table Name >====================================================
            'AgL.AddNewField(AgL.GCn, "Sch_Subject", "IsGeneralProficiency", "bit", 0, False)
            ''============================< ************************* >=====================================
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Sub EditField()
        Try
            'AgL.EditField("Sch_Admission", "AdmissionID", "nVarChar(61)", AgL.GCn, False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub CreateView()
        Dim mQry$ = ""
        '' Note Write Each View in Separate <Try---Catch> Section

        Try
            'mQry = "CREATE VIEW dbo.ViewSch_SessionProgramme AS " & _
            '        " SELECT  SP.*, S.ManualCode AS SessionManualCode, S.Description AS SessionDescription, S.StartDate AS SessionStartDate, S.EndDate AS SessionEndDate, P.Description AS ProgrammeDescription, P.ManualCode AS ProgrammeManualCode, P.ProgrammeDuration, P.Semesters AS ProgrammeSemesters, P.SemesterDuration AS ProgrammeSemesterDuration, P.ProgrammeNature , PN.Description AS ProgrammeNatureDescription  , P.ManualCode  +'/' + S.ManualCode   AS SessionProgramme " & _
            '        " FROM Sch_SessionProgramme SP " & _
            '        " LEFT JOIN Sch_Session S ON sp.Session =S.Code  " & _
            '        " LEFT JOIN Sch_Programme P ON SP.Programme =P.Code " & _
            '        " LEFT JOIN Sch_ProgrammeNature PN ON P.ProgrammeNature =PN.Code "

            'AgL.IsViewExist("ViewSch_SessionProgramme", AgL.GCn, True)
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    AgL.IsViewExist("ViewSch_SessionProgramme", AgL.GcnSite, True)
            '    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = " Create View [ViewSubGroup] As  " & _
                    " SELECT SubGroup.SubCode AS AcId, SubGroup.SubCode AS AcCode, SubGroup.Site_Code, " & _
                    " SubGroup.SubCode, LEFT(SubGroup.Name COLLATE DATABASE_DEFAULT + ISNULL(', ' + City.CityName  COLLATE DATABASE_DEFAULT , ''), 50) AS Name,  " & _
                    " SubGroup.GroupCode, SubGroup.GroupNature, " & _
                    " SubGroup.Nature, 'N' AS AliasYN, SubGroup.Add1, SubGroup.Add2, SubGroup.Add3, SubGroup.CityCode, " & _
                    " SubGroup.PIN, SubGroup.Phone AS PHONEl, AcGroup.MainGrCode AS MainGrCodeS, 'N' AS GAliasYn,  " & _
                    " AcGroup.GroupName AS GName, AcGroup.SysGroup AS SysGrp,  " & _
                    " LEFT(SubGroup.Name  COLLATE DATABASE_DEFAULT + ISNULL(', ' + City.CityName  COLLATE DATABASE_DEFAULT, ''), 50) AS NameWithCity,  City.CityName,  Mobile, Fax, Email,                         AcGroup.GroupName, AcGroup.TradingYn, AcGroup.BlOrd, 'N' AS SubAliasYn, SubGroup.FatherName AS FName,                        SubGroup.CreditLimit, SubGroup.Phone, SubGroup.DueDays, SubGroup.Curr_Bal, IsNull(SubGroup.CommonAc,0) As CommonAc   " & _
                    " FROM  SubGroup  " & _
                    " LEFT OUTER JOIN AcGroup ON SubGroup.GroupCode = AcGroup.GroupCode                        " & _
                    " LEFT OUTER JOIN City ON SubGroup.CityCode = City.CityCode "

            AgL.IsViewExist("ViewSubGroup", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSubGroup", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DropTable()
        Dim mQry$ = ""
        Try
            'If AgL.IsTableExist("Test", AgL.GCn) Then
            '    AgL.Dman_ExecuteNonQry("DROP TABLE Test", AgL.GCn)
            'End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateVType()
        Try
            'Common VType

            '===================================================< Stock Opening V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.StockOpening, Temp_NCat.StockOpening, "Stock Opening", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.StockOpening, Temp_NCat.StockOpening, Temp_NCat.StockOpening, "Stock Opening", Temp_NCat.StockOpening, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Stock Adjustment Issue V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.AdjustmentIssue, Temp_NCat.AdjustmentIssue, "Stock Adjustment Issue", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.AdjustmentIssue, Temp_NCat.AdjustmentIssue, Temp_NCat.AdjustmentIssue, "Stock Adjustment Issue", Temp_NCat.AdjustmentIssue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Stock Adjustment Receive V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.AdjustmentReceive, Temp_NCat.AdjustmentReceive, "Stock Adjustment Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.AdjustmentReceive, Temp_NCat.AdjustmentReceive, Temp_NCat.AdjustmentReceive, "Stock Adjustment Receive", Temp_NCat.AdjustmentReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Stock Transfer Issue V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.StockTransferIssue, Temp_NCat.StockTransferIssue, "Stock Transfer Issue", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.StockTransferIssue, Temp_NCat.StockTransferIssue, Temp_NCat.StockTransferIssue, "Stock Transfer Issue", Temp_NCat.StockTransferIssue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Stock Transfer Receive V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.StockTransferReceive, Temp_NCat.StockTransferReceive, "Stock Transfer Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.StockTransferReceive, Temp_NCat.StockTransferReceive, Temp_NCat.StockTransferReceive, "Stock Transfer Receive", Temp_NCat.StockTransferReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Physical Stock Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.PhysicalStockEntry, Temp_NCat.PhysicalStockEntry, "Physical Stock Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.PhysicalStockEntry, Temp_NCat.PhysicalStockEntry, Temp_NCat.PhysicalStockEntry, "Physical Stock Entry", Temp_NCat.PhysicalStockEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            'Production VType

            '===================================================< Production Order V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.ProductionOrder, Temp_NCat.ProductionOrder, "Production Order", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.ProductionOrder, Temp_NCat.ProductionOrder, Temp_NCat.ProductionOrder, "Production Order", Temp_NCat.ProductionOrder, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Production Plan V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.ProductionPlan, Temp_NCat.ProductionPlan, "Production Plan", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.ProductionPlan, Temp_NCat.ProductionPlan, Temp_NCat.ProductionPlan, "Production Plan", Temp_NCat.ProductionPlan, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Material Plan V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.MaterialPlan, Temp_NCat.MaterialPlan, "Material Plan", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.MaterialPlan, Temp_NCat.MaterialPlan, Temp_NCat.MaterialPlan, "Material Plan", Temp_NCat.MaterialPlan, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Job Order V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.JobOrder, Temp_NCat.JobOrder, "Job Order", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.JobOrder, Temp_NCat.JobOrder, Temp_NCat.JobOrder, "Job Order", Temp_NCat.JobOrder, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Job Issue V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.JobIssue, Temp_NCat.JobIssue, "Job Issue", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.JobIssue, Temp_NCat.JobIssue, Temp_NCat.JobIssue, "Job Issue", Temp_NCat.JobIssue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Job Receive V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.JobReceive, Temp_NCat.JobReceive, "Job Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.JobReceive, Temp_NCat.JobReceive, Temp_NCat.JobReceive, "Job Receive", Temp_NCat.JobReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            'Purchase VType

            AgL.CreateNCat(AgL.GCn, Temp_NCat.PurchaseIndent, Temp_NCat.PurchaseIndent, "Purchase Indent", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.PurchaseIndent, Temp_NCat.PurchaseIndent, Temp_NCat.PurchaseIndent, "Purchase Indent", Temp_NCat.PurchaseIndent, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Temp_NCat.PurchaseQuotation, Temp_NCat.PurchaseQuotation, "Purchase Quotation", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.PurchaseQuotation, Temp_NCat.PurchaseQuotation, Temp_NCat.PurchaseQuotation, "Purchase Quotation", Temp_NCat.PurchaseQuotation, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Temp_NCat.PurchaseQuotSelection, Temp_NCat.PurchaseQuotSelection, "Purchase Quotation Selection", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.PurchaseQuotSelection, Temp_NCat.PurchaseQuotSelection, Temp_NCat.PurchaseQuotSelection, "Purchase Quotation Selection", Temp_NCat.PurchaseQuotSelection, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Temp_NCat.PurchaseOrder, Temp_NCat.PurchaseOrder, "Purchase Order", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.PurchaseOrder, Temp_NCat.PurchaseOrder, Temp_NCat.PurchaseOrder, "Purchase Order", Temp_NCat.PurchaseOrder, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Temp_NCat.GoodsReceipt, Temp_NCat.GoodsReceipt, "Purchase Challan", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.GoodsReceipt, Temp_NCat.GoodsReceipt, Temp_NCat.GoodsReceipt, "Purchase Challan", Temp_NCat.GoodsReceipt, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)


            'Sale VType

            '===================================================< Sale Order V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.SaleOrder, Temp_NCat.SaleOrder, "Sale Order", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.SaleOrder, Temp_NCat.SaleOrder, Temp_NCat.SaleOrder, "Sale Order", Temp_NCat.SaleOrder, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)


            '===================================================< Document Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.DocumentEntry, Temp_NCat.DocumentEntry, "Document Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.DocumentEntry, Temp_NCat.DocumentEntry, Temp_NCat.DocumentEntry, "Document Entry", Temp_NCat.DocumentEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Shipment Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.ShipmentEntry, Temp_NCat.ShipmentEntry, "Shipment Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.ShipmentEntry, Temp_NCat.ShipmentEntry, Temp_NCat.ShipmentEntry, "Shipment Entry", Temp_NCat.ShipmentEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Form Receive Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.FormReceive, Temp_NCat.FormReceive, "Form Receive", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.FormReceive, Temp_NCat.FormReceive, Temp_NCat.FormReceive, "Form Receive", Temp_NCat.FormReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Form Issue Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.FormIssue, Temp_NCat.FormIssue, "Form Issue", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.FormIssue, Temp_NCat.FormIssue, Temp_NCat.FormIssue, "Form Issue", Temp_NCat.FormIssue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            'Payment VType
            '===================================================<Payment Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.Payment, Temp_NCat.Payment, "Payment", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.Payment, Temp_NCat.Payment, Temp_NCat.Payment, "Payment", Temp_NCat.Payment, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Temp_NCat.Receipt, Temp_NCat.Receipt, "Receipt", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.Receipt, Temp_NCat.Receipt, Temp_NCat.Receipt, "Receipt", Temp_NCat.Receipt, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Temp_NCat.DebitNote, Temp_NCat.DebitNote, "Debit Note.", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.DebitNote, Temp_NCat.DebitNote, Temp_NCat.DebitNote, "Debit Note.", Temp_NCat.DebitNote, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Temp_NCat.CreditNote, Temp_NCat.CreditNote, "Credit Note.", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.CreditNote, Temp_NCat.CreditNote, Temp_NCat.CreditNote, "Credit Note.", Temp_NCat.CreditNote, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Vehicle Gate In/Out Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.VehicleGate, Temp_NCat.VehicleGate, "Vehicle In/Out", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.VehicleGate, Temp_NCat.VehicleGate, Temp_NCat.VehicleGate, "Vehicle In/Out", Temp_NCat.VehicleGate, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================<Visitor Gate In/Out Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Temp_NCat.VisitorGate, Temp_NCat.VisitorGate, "Visitor In/Out", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Temp_NCat.VisitorGate, Temp_NCat.VisitorGate, Temp_NCat.VisitorGate, "Visitor In/Out", Temp_NCat.VisitorGate, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CreateDatabase(ByRef MdlTable() As AgLibrary.ClsMain.LITable)



    End Sub



#Region "Table Functions"

    Private Sub FItem_UID(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "GenDocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "GenSr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Item_UID", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Item_ManualUID", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "RecDocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "RecSr", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Subcode", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "IsInStock", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "RollNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "Subcode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
    End Sub

    Private Sub FEmployee(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Designation", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Department", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        End If
        AgL.FSetFKeyValue(MdlTable, "Department", "Code", "Department")
    End Sub

    Private Sub FDepartment(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FAcGroup(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "GroupCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 4, True)
        AgL.FSetColumnValue(MdlTable, "SNo", AgLibrary.ClsMain.SQLDataType.TinyInt)
        AgL.FSetColumnValue(MdlTable, "GroupName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ContraGroupName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "GroupUnder", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "GroupNature", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Nature", AgLibrary.ClsMain.SQLDataType.nVarChar, 15)
        AgL.FSetColumnValue(MdlTable, "SysGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "TradingYn", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "MainGrCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "BlOrd", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MainGrLen", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "ID", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "GroupNameBiLang", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "GroupLevel", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CurrentCount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CurrentBalance", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SubLedYn", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "AliasYn", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "GroupHelp", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "LastYearBalance", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "GroupUnder", "GroupCode", "AcGroup")
    End Sub

    Private Sub FCompany(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Comp_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 5, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Comp_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CentralData_Path", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PrevDBName", AgLibrary.ClsMain.SQLDataType.VarChar, 50)
        AgL.FSetColumnValue(MdlTable, "DbPrefix", AgLibrary.ClsMain.SQLDataType.VarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Repo_Path", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Start_Dt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "End_Dt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "address1", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "address2", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "city", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "pin", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "phone", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "fax", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "lstno", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "lstdate", AgLibrary.ClsMain.SQLDataType.nVarChar, 12)
        AgL.FSetColumnValue(MdlTable, "cstno", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "cstdate", AgLibrary.ClsMain.SQLDataType.nVarChar, 12)
        AgL.FSetColumnValue(MdlTable, "cyear", AgLibrary.ClsMain.SQLDataType.nVarChar, 9)
        AgL.FSetColumnValue(MdlTable, "pyear", AgLibrary.ClsMain.SQLDataType.nVarChar, 9)
        AgL.FSetColumnValue(MdlTable, "SerialKeyNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "SName", AgLibrary.ClsMain.SQLDataType.nVarChar, 15)
        AgL.FSetColumnValue(MdlTable, "EMail", AgLibrary.ClsMain.SQLDataType.VarChar, 30)
        AgL.FSetColumnValue(MdlTable, "Gram", AgLibrary.ClsMain.SQLDataType.VarChar, 15)
        AgL.FSetColumnValue(MdlTable, "Desc1", AgLibrary.ClsMain.SQLDataType.VarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Desc2", AgLibrary.ClsMain.SQLDataType.VarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Desc3", AgLibrary.ClsMain.SQLDataType.VarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ECCCode", AgLibrary.ClsMain.SQLDataType.VarChar, 15)
        AgL.FSetColumnValue(MdlTable, "ExDivision", AgLibrary.ClsMain.SQLDataType.VarChar, 30)
        AgL.FSetColumnValue(MdlTable, "ExRegNo", AgLibrary.ClsMain.SQLDataType.VarChar, 30)
        AgL.FSetColumnValue(MdlTable, "ExColl", AgLibrary.ClsMain.SQLDataType.VarChar, 30)
        AgL.FSetColumnValue(MdlTable, "ExRange", AgLibrary.ClsMain.SQLDataType.VarChar, 30)
        AgL.FSetColumnValue(MdlTable, "Desc4", AgLibrary.ClsMain.SQLDataType.VarChar, 150)
        AgL.FSetColumnValue(MdlTable, "VatNo", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "VatDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "TinNo", AgLibrary.ClsMain.SQLDataType.VarChar, 12)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.VarChar, 2)
        AgL.FSetColumnValue(MdlTable, "LogSiteCode", AgLibrary.ClsMain.SQLDataType.VarChar, 2)
        AgL.FSetColumnValue(MdlTable, "PANNo", AgLibrary.ClsMain.SQLDataType.VarChar, 25)
        AgL.FSetColumnValue(MdlTable, "State", AgLibrary.ClsMain.SQLDataType.VarChar, 35)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.VarChar, 35)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "DeletedYN", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Country", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "NotificationNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "WorkAddress1", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "WorkAddress2", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "WorkCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "WorkCountry", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "WorkPin", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "WorkPhone", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "WorkFax", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "WebServer", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "WebUser", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "WebPassword", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Webdatabase", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "UseSiteNameAsCompanyName", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FCurrency(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FDivision(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1, True)
        AgL.FSetColumnValue(MdlTable, "Div_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "DataPath", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "address1", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "address2", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "address3", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "city", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "pin", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SitewiseV_No", AgLibrary.ClsMain.SQLDataType.Bit, , , , 0)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)
    End Sub

    Private Sub FEntryPointPermission(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "MnuModule", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "MnuName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100, True)
        AgL.FSetColumnValue(MdlTable, "IsOnLineEntry", AgLibrary.ClsMain.SQLDataType.Bit, , , , 0)
        AgL.FSetColumnValue(MdlTable, "IsOffLineEntry", AgLibrary.ClsMain.SQLDataType.Bit, , , , 1)
    End Sub

    Private Sub FEnviro(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "ID", AgLibrary.ClsMain.SQLDataType.nVarChar, 4, True)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "CashAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BankAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TdsAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "AdditionAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DeductionAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ServiceTaxAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ECessAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RoundOffAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "HECessAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ServiceTaxPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ECessPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "HECessPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "DefaultSalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "DefaultSalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PurchOrderShowIndentInLine", AgLibrary.ClsMain.SQLDataType.Bit, , , , 0)

        AgL.FSetColumnValue(MdlTable, "IsLinkWithFA", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "IsNegativeStockAllowed", AgLibrary.ClsMain.SQLDataType.Bit, , , , 1)
        AgL.FSetColumnValue(MdlTable, "IsLotNoApplicable", AgLibrary.ClsMain.SQLDataType.Bit, , , , 1)
        AgL.FSetColumnValue(MdlTable, "DefaultDueDays", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetFKeyValue(MdlTable, "CashAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "BankAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "AdditionAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "DeductionAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "TdsAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "ServiceTaxAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "ECessAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "HECessAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "RoundOffAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FLog_TablePermission(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "CreateLogYn", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FLog_TableRecords(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "SearchKey", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "AED", AgLibrary.ClsMain.SQLDataType.nVarChar, 1, True)
        AgL.FSetColumnValue(MdlTable, "UpdateDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime, , True)
        AgL.FSetColumnValue(MdlTable, "TableName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Site", AgLibrary.ClsMain.SQLDataType.nVarChar, -1)
        AgL.FSetColumnValue(MdlTable, "UploadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FLogin_Log(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "User_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MachineName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Comp_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FLogTable(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 36)
        AgL.FSetColumnValue(MdlTable, "EntryPoint", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "MachineName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PartyDetail", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FSiteMast(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2, True)
        AgL.FSetColumnValue(MdlTable, "Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "HO_YN", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Add1", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Add2", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Add3", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "City_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 7)
        AgL.FSetColumnValue(MdlTable, "Phone", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Mobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PinNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 15)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "AcCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SqlServer", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "DataPath", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "DataPathMain", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "SqlUser", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "SqlPassword", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "CreditLimit", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Active", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Photo", AgLibrary.ClsMain.SQLDataType.image)
        AgL.FSetColumnValue(MdlTable, "LastNarration", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
    End Sub

    Private Sub FSubGroup(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "SiteList", AgLibrary.ClsMain.SQLDataType.nVarChar, 500)
        AgL.FSetColumnValue(MdlTable, "NamePrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 123)
        AgL.FSetColumnValue(MdlTable, "DispName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "GroupCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "GroupNature", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Nature", AgLibrary.ClsMain.SQLDataType.nVarChar, 11)
        AgL.FSetColumnValue(MdlTable, "Add1", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Add2", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Add3", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "CityCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "CountryCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "PIN", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "Phone", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "Mobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "FAX", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "EMail", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CSTNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 40)
        AgL.FSetColumnValue(MdlTable, "LSTNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 40)
        AgL.FSetColumnValue(MdlTable, "TINNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PAN", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "TDS_Catg", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "TDSCat_Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "ActiveYN", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "CreditLimit", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CreditDays", AgLibrary.ClsMain.SQLDataType.SmallInt)
        AgL.FSetColumnValue(MdlTable, "DueDays", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "ContactPerson", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Party_Type", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "PAdd1", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PAdd2", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PAdd3", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PCityCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "PCountryCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 7)
        AgL.FSetColumnValue(MdlTable, "PPin", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "PPhone", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "PMobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "PFax", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "Curr_Bal", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OpBal_DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "FatherName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "FatherNamePrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "HusbandName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "HusbandNamePrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DOB", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, -1)
        AgL.FSetColumnValue(MdlTable, "Location", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "StCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "SiteStr", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "STRegNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "ECCNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "EXREGNO", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "CEXRANGE", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "CEXDIV", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "COMMRATE", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "VATNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "CommonAc", AgLibrary.ClsMain.SQLDataType.Bit, , , , 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ChequeReport", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SisterConcernYn", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetFKeyValue(MdlTable, "City", "CityCode", "City")
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "SalesTaxPostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ExcisePostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "EntryTaxPostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "MasterType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetFKeyValue(MdlTable, "CityCode", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "PCityCode", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "GroupCode", "GroupCode", "AcGroup")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FSubGroup_Image(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Photo", AgLibrary.ClsMain.SQLDataType.image)
        AgL.FSetColumnValue(MdlTable, "Signature", AgLibrary.ClsMain.SQLDataType.image)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

    End Sub


    Private Sub FSubGroupType(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Party_Type", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FSynchronise_Error(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , True)
        AgL.FSetColumnValue(MdlTable, "Message", AgLibrary.ClsMain.SQLDataType.nVarChar, -1)
    End Sub

    Private Sub FTable_SearchField(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "TABLE_NAME", AgLibrary.ClsMain.SQLDataType.nVarChar, 128)
        AgL.FSetColumnValue(MdlTable, "SEARCH_FIELD", AgLibrary.ClsMain.SQLDataType.nVarChar, 128)
    End Sub

    Private Sub FUnit(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "IsActive", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FVoucher_Exclude(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "GroupCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "Dr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Cr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "GroupCode", "GroupCode", "AcGroup")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
    End Sub

    Private Sub FVoucher_Include(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "GroupCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "Dr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Cr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "SITE_CODE", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "GroupCode", "GroupCode", "AcGroup")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
    End Sub

    Private Sub FVoucher_Prefix(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "Date_From", AgLibrary.ClsMain.SQLDataType.SmallDateTime, )
        AgL.FSetColumnValue(MdlTable, "Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "Start_Srl_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Date_To", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Comp_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
    End Sub

    Private Sub FVoucher_Prefix_Type(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FVoucher_Type(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "NCat", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Category", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Short_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SystemDefine", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "DivisionWise", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "SiteWise", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IssRec", AgLibrary.ClsMain.SQLDataType.nVarChar, 3)
        AgL.FSetColumnValue(MdlTable, "Description_Help", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "Description_BiLang", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "Short_Name_BiLang", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Report_Index", AgLibrary.ClsMain.SQLDataType.nVarChar, 3)
        AgL.FSetColumnValue(MdlTable, "Number_Method", AgLibrary.ClsMain.SQLDataType.nVarChar, 9)
        AgL.FSetColumnValue(MdlTable, "Start_No", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Last_Ent_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Form_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, -1)
        AgL.FSetColumnValue(MdlTable, "Saperate_Narr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Common_Narr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Narration", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Print_VNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Header_Desc", AgLibrary.ClsMain.SQLDataType.nVarChar, 80)
        AgL.FSetColumnValue(MdlTable, "Term_Desc", AgLibrary.ClsMain.SQLDataType.nVarChar, 150)
        AgL.FSetColumnValue(MdlTable, "Footer_Desc", AgLibrary.ClsMain.SQLDataType.nVarChar, 150)
        AgL.FSetColumnValue(MdlTable, "Exclude_Ac_Grp", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SerialNo_From_Table", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ChqNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ChqDt", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ClgDt", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "DefaultCrAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DefaultDrAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FirstDrCr", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TrnType", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "TdsDed", AgLibrary.ClsMain.SQLDataType.nVarChar, 3)
        AgL.FSetColumnValue(MdlTable, "ContraNarr", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TdsOnAmt", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Contra_Narr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Separate_Narr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Affect_FA", AgLibrary.ClsMain.SQLDataType.Bit, , , , 1)
        AgL.FSetColumnValue(MdlTable, "IsShowVoucherReference", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "MnuName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "MnuText", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)

    End Sub

    Private Sub FUser_Control_Permission(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "UserName", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "MnuModule", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "MnuName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100, True)
        AgL.FSetColumnValue(MdlTable, "MnuText", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "GroupText", AgLibrary.ClsMain.SQLDataType.nVarChar, 100, True)
        AgL.FSetColumnValue(MdlTable, "GroupName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100, True)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FUser_Permission(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "UserName", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "MnuModule", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "MnuName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100, True)
        AgL.FSetColumnValue(MdlTable, "MnuText", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SNo", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "MnuLevel", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Parent", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Permission", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "ReportFor", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Active", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MainStreamCode", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "GroupLevel", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ControlPermissionGroups", AgLibrary.ClsMain.SQLDataType.VarCharMax)
    End Sub

    Private Sub FUserMast(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "USER_NAME", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 15)
        AgL.FSetColumnValue(MdlTable, "PASSWD", AgLibrary.ClsMain.SQLDataType.nVarChar, 16)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Admin", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FUserSite(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "User_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "CompCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 5, True)
        AgL.FSetColumnValue(MdlTable, "Sitelist", AgLibrary.ClsMain.SQLDataType.nVarChar, 250)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "DivisionList", AgLibrary.ClsMain.SQLDataType.nVarChar, 250)

        AgL.FSetFKeyValue(MdlTable, "CompCode", "Comp_Code", "Company")
    End Sub

    Private Sub FVoucherCat(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "NCat", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Category", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "NCatDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "SITE_CODE", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "UserTypeYN", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FCity(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "CityCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 6, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "CityName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "State", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Country", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FBank(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)


        AgL.FSetColumnValue(MdlTable, "Bank_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 8, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Bank_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)        
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RowID", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UploadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ChequeReport", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

    End Sub


    Private Sub FBankBranch(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "BankBranch_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 8, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "BankBranch_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RowID", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UploadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)        
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FNarrMast(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 8, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)        
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "LogSiteCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "LogCompCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "SiteCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RowID", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UploadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub


    Private Sub FCountry(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 6, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RowID", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UploadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FNature(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Nature", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Personal_Nature", AgLibrary.ClsMain.SQLDataType.Bit, , , , 0)
        AgL.FSetColumnValue(MdlTable, "RowID", AgLibrary.ClsMain.SQLDataType.IDENTITY)
        AgL.FSetColumnValue(MdlTable, "UploadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
    End Sub

    Private Sub FPermitForm(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 8, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ActiveYn", AgLibrary.ClsMain.SQLDataType.Bit, 0)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.BigInt, 0)
    End Sub


    Private Sub FTDSCat_Description(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 6, True)
        AgL.FSetColumnValue(MdlTable, "Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)

    End Sub


    Private Sub FTDSCat(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
    End Sub


    Private Sub FTdsCat_Det(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 6, True)
        AgL.FSetColumnValue(MdlTable, "SrNo", AgLibrary.ClsMain.SQLDataType.Int, 0, True)
        AgL.FSetColumnValue(MdlTable, "AcCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Percentage", AgLibrary.ClsMain.SQLDataType.Float, 0)
        AgL.FSetColumnValue(MdlTable, "TdsDesc", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
    End Sub


    Private Sub FTDSLedger(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.BigInt, True)        
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PaidAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TdsOnAmt", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TDSPer", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TDSAmt", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.VarCharMax)


        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "DocID", "DocId", "Ledger")
    End Sub



    Private Sub FChequePrint(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "AgainstAcSr", AgLibrary.ClsMain.SQLDataType.Int, 0)
        AgL.FSetColumnValue(MdlTable, "PrintDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "InFavourOf", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "AcPayee", AgLibrary.ClsMain.SQLDataType.Bit, 0)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.BigInt, 0)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime, 0)
    End Sub

    Private Sub FProcessGroup(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub


    Private Sub FProcess(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "NCat", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "ProcessGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "QcGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "InsideOutside", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DefaultJobOrderFor", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "DefaultBillingType", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "JobOn", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PrevProcess", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ProcessIssueNCat", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ProcessReceiveNCat", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ProcessReturnNCat", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ProcessCancelNCat", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ProcessInvoiceNCat", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)

        AgL.FSetFKeyValue(MdlTable, "NCat", "NCat", "VoucherCat")
        AgL.FSetFKeyValue(MdlTable, "ProcessGroup", "Code", "ProcessGroup")
        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "PrevProcess", "NCat", "Process")
        AgL.FSetFKeyValue(MdlTable, "ProcessIssueNCat", "NCat", "VoucherCat")
        AgL.FSetFKeyValue(MdlTable, "ProcessReceiveNCat", "NCat", "VoucherCat")
        AgL.FSetFKeyValue(MdlTable, "ProcessReturnNCat", "NCat", "VoucherCat")
    End Sub

    Private Sub FGodown(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)

        AgL.FSetColumnValue(MdlTable, "Address", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "City", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "ContactPerson", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Mobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "OwnerName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "RentedYN", AgLibrary.ClsMain.SQLDataType.Bit)

        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Uid", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FGodownSection(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Section", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Godown_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Godown")
        End If

    End Sub

    Private Sub FBom(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ForQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ForWeight", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ForUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Uid", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FBomDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ConsumptionPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ApplyIn", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Uid", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Bom_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Bom")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Process", "NCat", "Process")
    End Sub

    Private Sub FItem(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "DisplayName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Measure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ItemCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ItemType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "GodownSection", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "QcGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CurrentStock", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CurrentIssued", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CurrentRequisition", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "UpcCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Bom", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ItemImportExportGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "UPCCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SalesTaxPostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ExcisePostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "EntryTaxPostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "LastPurchaseRate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LastPurchaseDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "LastPurchaseInvoice", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetFKeyValue(MdlTable, "Bom", "Code", "BOM")
        AgL.FSetFKeyValue(MdlTable, "SalesTaxPostingGroup", "Description", "PostingGroupSalesTaxItem")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "QcGroup", "Code", "QcGroup")
    End Sub

    Private Sub FItemRate(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "WEF", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
    End Sub

    Private Sub FItemBuyer(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Buyer", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BuyerSku", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "BuyerUpcCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 12)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Item_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Item")
        End If
    End Sub

    Private Sub FStockHead(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ManualRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "OrderBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FromProcess", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ToProcess", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FromGodown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ToGodown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Addition", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Deduction", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "ReferenceDocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "FromProcess", "NCat", "Process")
        AgL.FSetFKeyValue(MdlTable, "ToProcess", "NCat", "Process")
        AgL.FSetFKeyValue(MdlTable, "FromGodown", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "ToGodown", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "OrderBy", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
    End Sub

    Private Sub FStock(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item_UID", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "LotNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ProcessGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty_Iss", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Qty_Rec", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Measure_Iss", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Measure_Rec", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Addition", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Deduction", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetColumnValue(MdlTable, "FIFORate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "FIFOAmt", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "AVGRate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "AVGAmt", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "Cost", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Doc_Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "ProcessGroup", "Code", "ProcessGroup")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "Process", "NCat", "Process")
    End Sub

    Private Sub FEnviroDefaultGodown(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1, True)
        AgL.FSetColumnValue(MdlTable, "ItemType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2, True)

        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FGateInOut(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_Time", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "InOut", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "VehicleType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "VehicleNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "MeterReading", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Weight", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Transporter", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Driver", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "LrNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "LrDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Manual_RefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "Close_MeterReading", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Close_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Close_Time", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Close_Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Close_EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "Transporter", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")

        AgL.DeleteField(StrTableName, "Out_Date", AgL.GCn)
        AgL.DeleteField(StrTableName, "Out_Time", AgL.GCn)
        AgL.DeleteField(StrTableName, "Out_Remarks", AgL.GCn)
        AgL.DeleteField(StrTableName, "Out_EntryBy", AgL.GCn)
    End Sub



    Private Sub FReminder(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "ID", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Ref_ID", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_Time", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Narration", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "RemindTo", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "Narration", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "Reminder_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Reminder_Time", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)


        AgL.FSetFKeyValue(MdlTable, "Ref_ID", "ID", "Reminder")
    End Sub

    Private Sub FReminderDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "ID", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Reminder_To", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "ActReminder_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ActReminder_Time", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)


        AgL.FSetFKeyValue(MdlTable, "ID", "ID", "Reminder")
    End Sub


    Private Sub FDues(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        'AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "CashCredit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Narration", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "RefV_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "RefV_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "RefManualNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "RefPartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "RefPartyAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "RefPartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "PaybleAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReceivableAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "AdjustedAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        'AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)

        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub


    Private Sub FDuesPaymentEnviro(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "DiscountAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CashAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BankAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DebitNoteAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CreditNoteAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.VarCharMax)


        AgL.FSetFKeyValue(MdlTable, "DiscountAc", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "CashAc", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "BankAc", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "DebitNoteAc", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "CreditNoteAc", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
    End Sub

    Private Sub FPurchaseEnviro(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ShowLastPoRates", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "ShowRecordCount", AgLibrary.ClsMain.SQLDataType.BigInt)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
    End Sub



    Private Sub FDuesPayment(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)        
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ManualRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "TransactionType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PartyAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "CurrBalance", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TDSPer", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TDSAmt", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "PaidAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Discount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "CashBank", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CashBankAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ChqNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ChqDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.VarCharMax)


        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "CashBankAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "PartyCity", "CityCode", "City")
    End Sub

    Private Sub FDuesPaymentDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "TransactionType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PartyAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "CurrBalance", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "PaidAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Discount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "CashBank", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CashBankAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ChqNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ChqDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "AmtPendingForTds", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TdsOnAmt", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TdsPer", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TdsAmt", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Reference_Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "DuesPayment_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "DuesPayment")
        End If

        AgL.FSetFKeyValue(MdlTable, "ReferenceDocId", "DocID", "Dues")
    End Sub




    Private Sub FProdOrder(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "SaleOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ManualRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "DueDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FProdOrderDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ProdPlanQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdPlanMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "ProdOrder_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "ProdOrder")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
    End Sub

    Private Sub FMaterialPlan(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ProdPlan", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ProdOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "DueDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalComputerConsumptionPlanQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalComputerConsumptionPlanMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalUserConsumptionPlanQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalUserConsumptionPlanMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalUserPurchPlanQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalUserPurchPlanMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalConsumptionQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "SaleOrder", "DocID", "SaleOrder")
        AgL.FSetFKeyValue(MdlTable, "ProdOrder", "DocID", "ProdOrder")
    End Sub

    Private Sub FMaterialPlanForDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ProdOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "MaterialPlan_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "MaterialPlan")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "ProdOrder", "DocId", "ProdOrder")
    End Sub

    Private Sub FMaterialPlanDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BomQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "StockQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "IssuedQty_ProdPlan", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ComputerMaterialPlanQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ComputerMaterialPlanMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "UserMaterialPlanQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "UserMaterialPlanMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "UserMaterialPlanRemarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PurchOrdQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "PurchOrdMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "PurchQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "PurchMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ProdIssQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ProdIssMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "PendingPurchaseOrderQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "ProdOrdQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ProdOrdMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "JobOrderQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "JobOrderMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "JobRecQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "JobRecMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)


        AgL.FSetColumnValue(MdlTable, "ProducedQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ProducedMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ProdOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)


        AgL.FSetColumnValue(MdlTable, "StkQty_SemiFinished", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "StkQtyReq_OpenSaleOrder", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ExcessQty_Finished", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ExcessQty_SemiFinished", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "UserPurchPlanQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "UserPurchPlanMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ProdRecQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ProdRecMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "MaterialPlan_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "MaterialPlan")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "ProdOrder", "DocId", "ProdOrder")
    End Sub

    Private Sub FMaterialPlanProcess(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ProdOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Measure", AgLibrary.ClsMain.SQLDataType.Float)

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "MaterialPlan_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "MaterialPlan")
        End If
        AgL.FSetFKeyValue(MdlTable, "ProdOrder", "DocId", "ProdOrder")
        AgL.FSetFKeyValue(MdlTable, "MaterialPlan", "DocId", "MaterialPlan")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
    End Sub

    Private Sub FJobWorker(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "Guarantor", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "JobWithMaterialYN", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "InsideOutside", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        End If
    End Sub

    Private Sub FJobWorkerProcess(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        End If
    End Sub

    Private Sub FJobOrder(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ManualRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "JobOrderDocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "JobWorker", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "OrderBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DueDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalBomQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalBomMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)


        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "JobInstructions", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TermsAndConditions", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "InsideOutside", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobWithMaterialYN", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.VarChar, 20)

        AgL.FSetColumnValue(MdlTable, "LastIssueDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "LastReceiveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "JobOrderFor", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "JobWorker", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "OrderBy", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Godown")
    End Sub

    Private Sub FJobOrderDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FromProcess", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CurrStock", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CancelQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CancelMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ProdPlan", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ProdOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "LossPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Loss", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        'Field For Material which was applied by Job Worker In The Process.
        'It Will Increase the weight of Product Delivered.
        AgL.FSetColumnValue(MdlTable, "JobMaterialPer", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "JobMaterialQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Incentive", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReceiveQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReceiveMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReceiveLoss", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReceiveLossMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "BOM", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "InvoiceQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "InvoiceMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "InvoiceAmount", AgLibrary.ClsMain.SQLDataType.Float)




        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "JobOrder_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "JobOrder")
        End If

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "ProdPlan", "DocID", "MaterialPlan")
        AgL.FSetFKeyValue(MdlTable, "ProdOrder", "DocID", "ProdOrder")
        AgL.FSetFKeyValue(MdlTable, "BOM", "Code", "BOM")
    End Sub

    Private Sub FJobOrderBom(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CancelQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CancelMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PrevProcess", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IssuedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "IssuedMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReturnQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReturnMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ConsumedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ConsumedMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ActualConsumedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ActualConsumedMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "JobOrder_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "JobOrder")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "PrevProcess", "NCat", "Process")
    End Sub

    Private Sub FJobOrderQCInstruction(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Parameter", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "StdValue", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "JobOrder_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "JobOrder")
        End If
    End Sub

    Private Sub FJobOrderByProduct(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CancelQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "CancelMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ReceivedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReceivedMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "JobOrder_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "JobOrder")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "Process", "NCat", "Process")
    End Sub

    Private Sub FJobWorkerRateGroup(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "Process", "NCat", "Process")
    End Sub



    Private Sub FJobWorkerRate(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobWorkerRateGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "GeneralRate", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "GeneralRateOutSide", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Process", "NCat", "Process")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "ItemCategory", "Code", "ItemCategory")
        AgL.FSetFKeyValue(MdlTable, "ItemGroup", "Code", "ItemGroup")
    End Sub

    Private Sub FJobWorkerRateDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "WEF", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "JobWorkerRateGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobWorker", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RateOutSide", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "JobWorker", "Subcode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "Process", "NCat", "Process")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "ItemCategory", "Code", "ItemCategory")
        AgL.FSetFKeyValue(MdlTable, "ItemGroup", "Code", "ItemGroup")
        AgL.FSetFKeyValue(MdlTable, "JobWorkerRateGroup", "Code", "JobWorkerRateGroup")
    End Sub


    Private Sub FSalesOrderPriority(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Buyer", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "OrderBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "Buyer", "SubCode", "Subgroup")
    End Sub

    Private Sub FSalesOrderPriorityDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)        
        AgL.FSetColumnValue(MdlTable, "SaleOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Priority", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "SaleOrder", "DocID", "SaleOrder")        
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")        
        AgL.FSetFKeyValue(MdlTable, "Priority", "Code", "Priority")
    End Sub


    Private Sub FJobIssRec(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ManualRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobWorker", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobWorkerDocNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "JobOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DueDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IssQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "IssMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "RecQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "RecMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "JobReceiveFor", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "OrderBy", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobWithMaterialYn", AgLibrary.ClsMain.SQLDataType.Bit, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ToJobOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "JobReceiveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "TotalConsumptionQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalConsumptionMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "TotalByProductQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalByProductMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "JobWorker", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "Process", "NCat", "Process")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "OrderBy", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "JobOrder", "DocID", "JobOrder")
        AgL.FSetFKeyValue(MdlTable, "JobReceiveBy", "SubCode", "SubGroup")
    End Sub

    Private Sub FJobIssRecUID(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "TSr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item_UID", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Item_ManualUID", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "RollNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Process", "NCat", "Process")
    End Sub

    Private Sub FJobIssueDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "StockItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PrevProcess", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ReceiveQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReceiveMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReturnQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReturnMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ReceiveLoss", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LotNo", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "CurrStock", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "JobIssue_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "JobIssue")
        End If

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "JobOrder", "DocID", "JobOrder")
        AgL.FSetFKeyValue(MdlTable, "PrevProcess", "NCat", "Process")
        AgL.FSetFKeyValue(MdlTable, "ProdOrder", "DocID", "ProdOrder")
    End Sub

    Private Sub FJobReceiveDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item_UID", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DocQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RetQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "BillQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LossPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LossQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "DocMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RetMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "BillMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "JobIssueDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ProdOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "RollNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "InvoiceQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "InvoiceMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "InvoiceAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "LotNo", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Bom", AgLibrary.ClsMain.SQLDataType.VarChar, 10)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "JobIssue_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "JobIssue")
        End If

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "JobOrder", "DocID", "JobOrder")
        AgL.FSetFKeyValue(MdlTable, "JobIssueDocId", "DocID", "JobIssRec")
    End Sub

    Private Sub FJobReceiveByProduct(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "StockItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LotNo", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "IsDelivered", AgLibrary.ClsMain.SQLDataType.Bit)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "JobReceive_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "JobReceive")
        End If

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "JobOrder", "DocID", "JobOrder")
        AgL.FSetFKeyValue(MdlTable, "Process", "NCat", "Process")
        AgL.FSetFKeyValue(MdlTable, "ProdOrder", "DocID", "ProdOrder")
    End Sub


    Private Sub FJobInvoice(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ManualRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "JobWorker", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobWorkerDocNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "TotalDocQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalBillQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalLoss", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "TotalDocMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalBillMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalLossMeasure", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "TotalBomAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "NetPaybleAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "JobWorker", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Process", "NCat", "Process")
    End Sub


    Private Sub FJobInvoiceDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "JobReceive", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DocQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "BillQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LossPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LossQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "DocMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LossMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "BillMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "JobIssueDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ProdOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "LotNo", AgLibrary.ClsMain.SQLDataType.VarChar, 20)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "JobInvoice_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "JobInvoice")
        End If

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "JobOrder", "DocID", "JobOrder")
        AgL.FSetFKeyValue(MdlTable, "JobReceive", "DocID", "JobIssRec")
        AgL.FSetFKeyValue(MdlTable, "JobIssueDocId", "DocID", "JobIssRec")
    End Sub


    Private Sub FJobInvoiceBOM(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "JobInvoice_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "JobInvoice")
        End If

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
    End Sub


    Private Sub FJobReceiveBOM(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "TSr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "StockItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BOMItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LotNo", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PrevProcess", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ProdOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "JobReceive_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "JobReceive")
        End If

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "BOMItem", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "JobOrder", "DocID", "JobOrder")
        AgL.FSetFKeyValue(MdlTable, "PrevProcess", "NCat", "Process")
        AgL.FSetFKeyValue(MdlTable, "ProdOrder", "DocID", "ProdOrder")
    End Sub


    Private Sub FJobExchangeDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)

        AgL.FSetColumnValue(MdlTable, "ReceiveItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ReceiveQty", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "ReceiveItemUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ReceiveItemMeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReceiveItemTotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReceiveItemMeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "IssueItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IssueQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "IssueItemUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IssueItemMeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "IssueItemTotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "IssueItemMeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "JobOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PrevProcess", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "JobIssRec_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "JobIssRec")
        End If

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "JobOrder", "DocID", "JobOrder")
        AgL.FSetFKeyValue(MdlTable, "PrevProcess", "NCat", "Process")
    End Sub

    Private Sub FRequisition(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Department", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RequisitionBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Department", "Code", "Department")
        AgL.FSetFKeyValue(MdlTable, "RequisitionBy", "SubCode", "Subgroup")
    End Sub

    Private Sub FRequisitionDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RequireDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "PurchaseIndent", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "IssueDocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Requisition_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Requisition")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "PurchaseIndex", "DocID", "PurchaseIndent")
    End Sub

    Private Sub FPurchaseIndent(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Department", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ProdPlan", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ProdOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Indentor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Department", "Code", "Department")
        AgL.FSetFKeyValue(MdlTable, "Indentor", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "ProdPlan", "DocId", "MaterialPlan")
        AgL.FSetFKeyValue(MdlTable, "ProdOrder", "DocId", "ProdOrder")
    End Sub

    Private Sub FPurchaseIndentReq(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Requisition", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RequireDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "PurchaseIndent_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "PurchaseIndent")
        End If

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "Requisition", "DocId", "Requisition")
    End Sub

    Private Sub FPurchaseIndentDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CurrentStock", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReqQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "IndentQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalReqMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalIndentMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OrdQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OrdMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PurchQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PurchMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RequireDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ProdOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "PurchaseIndent_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "PurchaseIndent")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "ProdOrder", "DocId", "ProdOrder")
    End Sub


    Private Sub FQCGroup(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Uid", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FQCGroupDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Parameter", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "StdValue", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "QcGroup_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "QcGroup")
        End If
    End Sub


    Private Sub FQC(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Department", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PurchChallan", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "QcBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalPassedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalRejectQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalPassedMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalRejectMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Department", "Code", "Department")
        AgL.FSetFKeyValue(MdlTable, "QcBy", "SubCode", "Subgroup")
        AgL.FSetFKeyValue(MdlTable, "PurchChallan", "DocId", "PurchChallan")
    End Sub

    Private Sub FQcDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "PurchChallan", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "QcQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PassedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RejectQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalPassedMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalRejectMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "QC_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "QC")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "PurchChallan", "DocId", "PurchChallan")
    End Sub




    Private Sub FQcParameterDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "TSr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Parameter", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "StdValue", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ActValue", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "QcQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PassedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RejectQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalPassedMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalRejectMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
    End Sub



    Private Sub FPurchaseQuotation(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "PurchIndent", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "VendorName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)

        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "VendorQuoteNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "VendorQuoteDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "TermsAndConditions", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "PostingGroupSalesTaxParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetColumnValue(MdlTable, "PriceMode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Vendor", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "VendorCity", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "PurchIndent", "DocId", "PurchIndent")
    End Sub

    Private Sub FPurchaseQuotationDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "PurchIndent", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PostingGroupSalesTaxItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "OrdQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OrdMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PurchQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PurchMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "QuotSelection", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "QuotSelectionIndex", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "QuotSelectionV_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "QuotSelectionV_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "QuotSelectionV_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "PurchQuotation_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "PurchQuotation")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "QuotSelection", "DocId", "PurchQuotSelection")
    End Sub


    Private Sub FPurchaseQuotSelection(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Employee", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)


        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))



        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Employee", "SubCode", "Subgroup")
    End Sub

    Private Sub FPurchaseQuotSelectionDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)


        AgL.FSetColumnValue(MdlTable, "SelectionIndex", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "PurchIndent", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "PurchQuot", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PurchQuotV_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "PurchQuotV_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "PurchQuotV_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "VendorName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "VendorQuoteNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "VendorQuoteDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "TermsAndConditions", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PriceMode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "PurchQuotSelection_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "PurchQuotSelection")
        End If
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "Vendor", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "PurchIndent", "DocId", "PurchIndent")
        AgL.FSetFKeyValue(MdlTable, "PurchQuot", "DocId", "PurchQuotation")
    End Sub

    Private Sub FPurchaseOrder(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "VendorName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "VendorAdd1", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "VendorAdd2", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "VendorCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "VendorCityName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "VendorState", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "VendorCountry", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PurchQuotaion", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PurchIndent", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PurchOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "ShipToParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyAdd1", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyAdd2", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyCityName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyState", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyCountry", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "VendorOrderNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "VendorOrderDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "VendorDeliveryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "VendorOrderCancelDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "DestinationPort", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FinalPlaceOfDelivery", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "TermsAndConditions", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetColumnValue(MdlTable, "PreCarriageBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PlaceOfReceipt", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipmentThrough", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "BankAcNoVendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "BankNameVendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "BankAddressVendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "PriceMode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Agent", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PaymentTerms", AgLibrary.ClsMain.SQLDataType.VarCharMax)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Vendor", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "ShipToParty", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "VendorCity", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "ShipToPartyCity", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "PortOfLoading", "Code", "SeaPort")
        AgL.FSetFKeyValue(MdlTable, "DestinationLoading", "Code", "SeaPort")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "Agent", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "PurchQuotation", "DocID", "PurchQuotation")
        AgL.FSetFKeyValue(MdlTable, "PurchIndent", "DocID", "PurchIndent")
        AgL.FSetFKeyValue(MdlTable, "PurchOrder", "DocID", "PurchOrder")
    End Sub

    Private Sub FPurchaseOrderDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "PurchIndent", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "VendorSKU", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "VendorUPC", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ShippedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ShippedMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "PurchOrder_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "PurchOrder")
        End If
        AgL.FSetFKeyValue(MdlTable, "PurchIndent", "DocID", "PurchIndent")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub


    Private Sub FPurchChallan(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PurchOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "GateEntryNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "TruckNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "VendorDocNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "VendorDocDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "Form", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FormNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "Transporter", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "Transport", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "LrNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "LrDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Vendor", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "PurchOrder", "DocID", "PurchOrder")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "Form", "Code", "Form_Master")
    End Sub

    Private Sub FPurchChallanDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "PurchOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "DocQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RejQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalDocMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalRejMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "InvoicedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "InvoicedMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "QcQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "QcMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LotNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "PurchChallan_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "PurchChallan")
        End If

        AgL.FSetFKeyValue(MdlTable, "PurchOrder", "DocID", "PurchOrder")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub

    Private Sub FPurchInvoice(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PurchOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PurchChallan", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "VendorDocNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "VendorDocDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "Form", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FormNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Vendor", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "PurchOrder", "DocID", "PurchOrder")
        AgL.FSetFKeyValue(MdlTable, "PurchChallan", "DocID", "PurchChallan")
        AgL.FSetFKeyValue(MdlTable, "Form", "Code", "Form_Master")
    End Sub

    Private Sub FPurchInvoiceDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "PurchOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PurchChallan", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Specification", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "DocQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalDocMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "LotNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "PurchInvoice_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "PurchInvoice")
        End If

        AgL.FSetFKeyValue(MdlTable, "PurchOrder", "DocID", "PurchOrder")
        AgL.FSetFKeyValue(MdlTable, "PurchChallan", "DocID", "PurchChallan")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub


    Private Sub FBuyer(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "SeaPort", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BankName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "BankAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "BankAcNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ContactPerson", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "MAddress1", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "MAddress2", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "MCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "MContactNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "MFaxNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "Consignee", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "CAddress1", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CAddress2", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CPhoneNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "CMobileNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 12)
        AgL.FSetColumnValue(MdlTable, "CFaxNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "CEmail", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        End If

        AgL.FSetFKeyValue(MdlTable, "MCity", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "SeaPort", "Code", "SeaPort")
    End Sub

    Private Sub FVendor(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "SeaPort", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BankName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "BankAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "BankAcNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ContactPerson", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "MAddress1", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "MAddress2", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "MCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "MContactNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "MFaxNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "Consignee", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "CAddress1", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CAddress2", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CPhoneNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "CMobileNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 12)
        AgL.FSetColumnValue(MdlTable, "CFaxNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "CEmail", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        End If

        AgL.FSetFKeyValue(MdlTable, "MCity", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "SeaPort", "Code", "SeaPort")
    End Sub

    Private Sub FAgent(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
        AgL.FSetColumnValue(MdlTable, "Commission_Fix", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Commission_Per", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        End If


    End Sub

    Private Sub FAgentItem(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)
        AgL.FSetColumnValue(MdlTable, "Subcode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ToQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Commission_Per", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "Subgroup")
        Else
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "SubGroup_Log")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
    End Sub


    Private Sub FSaleQuotation(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Party", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)        

        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PartyEnquiryNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PartyEnquiryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "TermsAndConditions", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "PostingGroupSalesTaxParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetColumnValue(MdlTable, "PriceMode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Party", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
    End Sub

    Private Sub FSaleQuotationDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PostingGroupSalesTaxItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "OrdQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OrdMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "DispatchQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "DispatchMeasure", AgLibrary.ClsMain.SQLDataType.Float)


        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "SaleQuotation_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "SaleQuotation")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "MeasureUnit", "Code", "Unit")
    End Sub

    Private Sub FSaleOrder(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "SaleToParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyAdd1", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyAdd2", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyCityName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyState", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyCountry", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)

        AgL.FSetColumnValue(MdlTable, "ShipToParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyAdd1", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyAdd2", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyCityName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyState", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyCountry", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "PartyOrderNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PartyOrderDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "PartyDeliveryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "PartyOrderCancelDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "TermsAndConditions", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "StockTotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetColumnValue(MdlTable, "DestinationPort", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FinalPlaceOfDelivery", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PreCarriageBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PlaceOfReceipt", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipmentThrough", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "BankAcNoBuyer", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "BankNameBuyer", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "BankAddressBuyer", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "PriceMode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Agent", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "SaleToParty", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "ShipToParty", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "SaleToPartyCity", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "ShipToPartyCity", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "PortOfLoading", "Code", "SeaPort")
        AgL.FSetFKeyValue(MdlTable, "DestinationLoading", "Code", "SeaPort")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "Agent", "SubCode", "SubGroup")
    End Sub

    Private Sub FSaleOrderDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PartySKU", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PartyUPC", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "StockMeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "StockTotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ShippedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ShippedMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdOrdQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdOrdMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdPlanQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdPlanMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PurchQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PurchMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdIssQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdIssMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdRecQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdRecMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Priority", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "DeliveryOrderQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "DeliveryOrderMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "SaleOrder_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "SaleOrder")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub

    Private Sub FDeliveryOrder(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "SaleOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ManualRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SaleToParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyAdd1", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyAdd2", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyCityName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyState", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyCountry", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)

        AgL.FSetColumnValue(MdlTable, "ShipToParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyAdd1", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyAdd2", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyCityName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyState", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyCountry", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "PartyOrderNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PartyOrderDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "PartyDeliveryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "PartyOrderCancelDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "DestinationPort", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FinalPlaceOfDelivery", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "TermsAndConditions", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "StockTotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetColumnValue(MdlTable, "PreCarriageBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PlaceOfReceipt", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipmentThrough", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "BankAcNoBuyer", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "BankNameBuyer", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "BankAddressBuyer", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "PriceMode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Agent", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "SaleToParty", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "ShipToParty", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "SaleToPartyCity", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "ShipToPartyCity", "CityCode", "City")
        AgL.FSetFKeyValue(MdlTable, "PortOfLoading", "Code", "SeaPort")
        AgL.FSetFKeyValue(MdlTable, "DestinationLoading", "Code", "SeaPort")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "Agent", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "SaleOrder", "DocId", "SaleOrder")
    End Sub

    Private Sub FDeliveryOrderDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PartySKU", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PartyUPC", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "StockMeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "StockTotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ShippedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ShippedMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdOrdQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdOrdMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdPlanQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdPlanMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PurchQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PurchMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdIssQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdIssMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdRecQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ProdRecMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "SaleOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "DeliveryOrder_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "DeliveryOrder")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
        AgL.FSetFKeyValue(MdlTable, "SaleOrder", "DocId", "SaleOrder")
    End Sub


    Private Sub FSaleChallan(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SaleToParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyMobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)

        AgL.FSetColumnValue(MdlTable, "ShipToParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyMobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)

        AgL.FSetColumnValue(MdlTable, "SaleOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)	
        AgL.FSetColumnValue(MdlTable, "DeliveryOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)        
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "GateEntryNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "TruckNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)


        AgL.FSetColumnValue(MdlTable, "Form", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FormNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)

        AgL.FSetColumnValue(MdlTable, "Transporter", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Vehicle", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "VehicleDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Driver", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DriverName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "DriverContactNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "LrNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "LrDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "PrivateMark", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "PortOfLoading", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DestinationPort", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FinalPlaceOfDelivery", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PreCarriageBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PlaceOfPreCarriage", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipmentThrough", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)


        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Vendor", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "PurchOrder", "DocID", "PurchOrder")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "Form", "Code", "Form_Master")
    End Sub

    Private Sub FSaleChallanDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "SaleOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "DeliveryOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "DocQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "RejQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalDocMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalRejMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "BaleNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "JobReceiveDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "InvoicedQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "InvoicedMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "QcQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "QcMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LC:\Documents and Settings\dataman\Desktop\RightControl VB6 + NET source\RightControlWG.NET\RightControlWG.NET\basRegister.vbotNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "SaleChallan_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "SaleChallan")
        End If

        AgL.FSetFKeyValue(MdlTable, "PurchOrder", "DocID", "PurchOrder")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub


    Private Sub FSaleInvoice(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)


        AgL.FSetColumnValue(MdlTable, "Vendor", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SaleToParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyMobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyTinNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SaleToPartyCstNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 40)

        AgL.FSetColumnValue(MdlTable, "ShipToParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "ShipToPartyMobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)


        AgL.FSetColumnValue(MdlTable, "SaleOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "SaleChallan", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "BillingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "Form", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FormNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)


        AgL.FSetColumnValue(MdlTable, "Transporter", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Vehicle", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "VehicleDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Driver", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DriverName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "DriverContactNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)

        AgL.FSetColumnValue(MdlTable, "LrNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "LrDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "PrivateMark", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)




        AgL.FSetColumnValue(MdlTable, "PortOfLoading", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DestinationPort", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FinalPlaceOfDelivery", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PreCarriageBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PlaceOfPreCarriage", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ShipmentThrough", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CreditDays", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "Remarks", AgLibrary.ClsMain.SQLDataType.VarChar, 255)

        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "SaleToParty", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "ShipToParty", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "BillToParty", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "Form", "Code", "Form_Master")
    End Sub

    Private Sub FSaleInvoiceDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "SaleOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "SaleOrderSr", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "SaleChallan", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "SaleChallanSr", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Specification", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "DocQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MeasurePerPcs", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeasureUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalDocMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TotalMeasure", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "LotNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "SaleInvoice_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "SaleInvoice")
        End If

        AgL.FSetFKeyValue(MdlTable, "SaleOrder", "DocID", "SaleOrder")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub


    Private Sub FIE_Doc(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Nature", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FIE_DocEntry(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)

        AgL.FSetColumnValue(MdlTable, "Document", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DocumentNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "OpenedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FileNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FileDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Period", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Tollerance", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "ImportPayMode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ExportPayMode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Party", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Bank", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "ExpiryDateImport", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ExpiryDateExport", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Document", "Code", "IE_Doc")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Currency", "Code", "Currency")
        AgL.FSetFKeyValue(MdlTable, "Party", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Bank", "SubCode", "SubGroup")
    End Sub

    Private Sub FIE_DocAmend(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)

        AgL.FSetColumnValue(MdlTable, "AmendDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ExpiryDateImport", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ExpiryDateExport", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "IE_DocEntry_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "IE_DocEntry")
        End If
    End Sub

    Private Sub FIE_DocItem(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)

        AgL.FSetColumnValue(MdlTable, "Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemImportExportGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "AmountFC", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "AmountINR", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "IE_DocEntry_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "IE_DocEntry")
        End If
    End Sub

    Private Sub FIE_Shipment(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)

        AgL.FSetColumnValue(MdlTable, "PurchaseOrder", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PurchaseOrderReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "InvoiceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "InvoiceDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "BillOfEntryNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "BillOfEntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ShippingLine", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CountryOfOrigin", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "InsuranceDetail", AgLibrary.ClsMain.SQLDataType.VarCharMax)
        AgL.FSetColumnValue(MdlTable, "PortOfDispatch", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "PortOfDicharge", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "FinalPlaceOfDelivery", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "ETAAtIndianSeaPort", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ETAAtICD", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "CHA", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ShipperInformationDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ShipperInformationRemark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "DocSubmissionDateToCHA", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "DocRealisationDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "DutyAmountPaidDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ShipmentReleaseDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Transporter", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "VehicleNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "DriverName", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ArrivalDateAtFactory", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "VehicleReturnDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ProofSubmissionDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "BankAdviceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BankAdviceDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ExchangeRate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "BillOfLadingNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BillOfLadingDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ShipmentOnBoardDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "VesselName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)


        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "CHA", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Transporter", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "PortOfDispatch", "Code", "SeaPort")
        AgL.FSetFKeyValue(MdlTable, "PortOfDicharge", "Code", "SeaPort")
    End Sub

    Private Sub FIE_ShipmentDoc(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)

        AgL.FSetColumnValue(MdlTable, "Document", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DocumentNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "IE_Shipment_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "IE_Shipment")
        End If
        AgL.FSetFKeyValue(MdlTable, "Document", "Code", "IE_Doc")
    End Sub

    Private Sub FIE_ShipmentBOE(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)

        AgL.FSetColumnValue(MdlTable, "BOE", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FCValue", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "INRValue", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Term", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "DueDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "IE_Shipment_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "IE_Shipment")
        End If
    End Sub

    Private Sub FIE_ShipmentItem(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)

        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ContainerNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "KindsOfPackages", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "IE_Shipment_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "IE_Shipment")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub

    Private Sub FTransporter(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        End If
    End Sub

    Private Sub FForm_Master(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Category", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FForm_Receive(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)

        AgL.FSetColumnValue(MdlTable, "Form", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FormPrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "FormNoFrom", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "FormNoUpTo", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Party", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IsFromDepartment", AgLibrary.ClsMain.SQLDataType.Bit, , , , 0)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Party", "SubCode", "SubGroup")
    End Sub

    Private Sub FForm_ReceiveDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Form", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FormNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "ReceiveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReceiveFrom", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "IssueDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IssueTo", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IsInStock", AgLibrary.ClsMain.SQLDataType.Bit, , , False, 0)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IssueDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "FormPrefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "FormNoSerial", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "IsUtilised", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "PurchChallan", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PurchChallanV_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "PurchChallanV_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "PurchChallanV_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "PurchInvoice", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PurchInvoiceV_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "PurchInvoiceV_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "PurchInvoiceV_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "SaleChallan", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "SaleChallanV_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "SaleChallanV_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "SaleChallanV_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "SaleInvoice", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "SaleInvoiceV_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "SaleInvoiceV_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "SaleInvoiceV_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Form_Receive_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Form_Receive")
        End If
        AgL.FSetFKeyValue(MdlTable, "PurchChallan", "DocID", "PurchChallan")
        AgL.FSetFKeyValue(MdlTable, "PurchInvoice", "DocID", "PurchInvoice")
    End Sub

    Private Sub FGBill(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PartyAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FromDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "UptoDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PaidAmount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)



        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Structure", "Code", "Structure")
    End Sub

    Private Sub FGBillDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "RefDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "RefV_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "RefV_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "RefReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "RefDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "DueAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "AdjustedAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "BilledAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "PaidAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "GBill")
        Else
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "GBill_Log")
        End If
    End Sub

    Private Sub FToBeBilled(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PartyName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PartyAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "PartyCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ReceivableAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "PaybleAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "AdjustedAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "BilledAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "PaidAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub

    Private Sub FPhysicalStockDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "CurrentStock", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PhysicalStock", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Differnce", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "StockHead_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "DocId", "DocID", "StockHead")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Unit")
    End Sub

    Private Sub FLedgerM(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Narration", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "PreparedBY", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PostedBY", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OldDocid", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
    End Sub

    Private Sub FLedger(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "V_SNo", AgLibrary.ClsMain.SQLDataType.Int, 0, True)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ContraSub", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "AmtDr", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "AmtCr", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Chq_No", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Chq_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Clg_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "TDSCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "TdsDesc", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "TdsOnAmt", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TdsPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Tds_Of_V_Sno", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Narration", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "U_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "DivCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "PQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "SQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "AgRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "GroupCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 4)
        AgL.FSetColumnValue(MdlTable, "GroupNature", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "AddBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "AddDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifyBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ModifyDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OldDocid", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "CostCenter", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "ContraSub", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "GroupCode", "GroupCode", "AcGroup")
        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "LedgerM")

    End Sub

    Private Sub FVoucher(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Narration", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "CommonBankDetail", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "OldDocid", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Subcode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IsAutoApproved", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "AuditedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "AuditedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
    End Sub

    Private Sub FVoucherDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "ReferenceTable", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ContraSub", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "AmtDr", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "AmtCr", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Narration", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Bank_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Chq_No", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Chq_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Clg_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "GPX1", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPX2", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "GPN1", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "GPN2", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Bank_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Favouring_Name", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "CrossText", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "IsCrossCheque", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "OldDocid", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "CostCenter", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "ContraSub", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "Voucher")

    End Sub

    Private Sub FTermsCondition(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)

        AgL.FSetFKeyValue(MdlTable, "Code", "NCat", "Voucher_Type")
    End Sub

    Private Sub FStockUID(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "TSr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "ManualRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "FromSubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FromProcess", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item_UID", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "iDocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "iTSr", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "iSr", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "iV_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "iV_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "iV_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "iV_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "iManualRefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ToSubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ToProcess", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "RDocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Godown")
        AgL.FSetFKeyValue(MdlTable, "FromSubCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "FromProcess", "NCat", "Process")
        AgL.FSetFKeyValue(MdlTable, "iV_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "ToSubCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "ToProcess", "NCat", "Process")

    End Sub

    Private Sub FItemType(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
    End Sub

    Private Sub FItemCategory(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ItemType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "ItemType", "Code", "ItemType")
    End Sub

    Private Sub FItemGroup(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ItemType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ItemCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "ItemCategory", "Code", "ItemCategory")
        AgL.FSetFKeyValue(MdlTable, "ItemType", "Code", "ItemType")
    End Sub
#End Region
#End Region


#Region "Module Functions"
    Public Shared Function RetDivFilterStr() As String
        Try
            RetDivFilterStr = "IsNull(Div_Code,'" & AgL.PubDivCode & "') = '" & AgL.PubDivCode & "'"
        Catch ex As Exception
            RetDivFilterStr = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Public Shared Function FunRetStock(ByVal bItem As String, ByVal bInternalCode As String, Optional ByVal bCondStr As String = "", _
                                       Optional ByVal bGodown As String = "", _
                                       Optional ByVal bProcess As String = "", _
                                       Optional ByVal bStatus As String = "", _
                                       Optional ByVal bV_Date As String = "", _
                                       Optional ByVal bLotNo As String = "") As Double
        Dim bConStr$ = ""
        Dim bStockQty As Double = 0
        Dim mQry$

        Try
            bConStr = "WHERE 1=1 And S.Item = '" & bItem & "' "
            If bCondStr <> "" Then bConStr += bCondStr
            If bGodown <> "" Then bConStr += " And IsNull(S.Godown,'') = '" & bGodown & "'"
            If bProcess <> "" Then bConStr += " And IsNull(S.Process,'') = '" & bProcess & "'"
            If bStatus <> "" Then bConStr += " And IsNull(S.Status,'" & ClsMain.StockStatus.Standard & "') = '" & bStatus & "'"
            If bV_Date <> "" Then bConStr += " And S.V_Date <= '" & bV_Date & "'"
            If bLotNo <> "" Then bConStr += " And S.LotNo = '" & bLotNo & "'"
            bConStr += " And S.DocId <> '" & bInternalCode & "' "

            mQry = "SELECT IsNull(Sum(S.Qty_Rec),0) - IsNull(Sum(S.Qty_Iss),0) " & _
                    " FROM Stock S " & bConStr
            bStockQty = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
            FunRetStock = bStockQty
        Catch ex As Exception
            FunRetStock = 0
            MsgBox(ex.Message)
        End Try
    End Function
#End Region

    Public Shared Function FunCheckStock(ByVal bItem As String, ByVal bInternalCode As String, _
                               Optional ByVal bGodown As String = "", _
                               Optional ByVal bProcess As String = "", _
                               Optional ByVal bStatus As String = "") As Double
        Dim bConStr$ = ""
        Dim bStockQty As Double = 0
        Dim mQry$

        Try
            bConStr = "WHERE S.Item = '" & bItem & "' "
            bConStr += " And " & IIf(bGodown <> "", "S.Godown = '" & bGodown & "'", "1=1") & ""
            bConStr += " And " & IIf(bProcess <> "", "IsNull(S.Process,'') = '" & bProcess & "'", "1=1") & ""
            bConStr += " And " & IIf(bStatus <> "", "IsNull(S.Status,'" & ClsMain.StockStatus.Standard & "') = '" & bStatus & "'", "1=1") & ""
            bConStr += " And S.DocId <> '" & bInternalCode & "' "

            mQry = "SELECT IsNull(Sum(S.Qty_Rec),0) - IsNull(Sum(S.Qty_Iss),0) " & _
                    " FROM Stock S " & bConStr
            bStockQty = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
            FunCheckStock = bStockQty
        Catch ex As Exception
            FunCheckStock = 0
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub FVisitorsGateInOut(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "V_Time", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "Manual_RefNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "VisitorName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Address", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Phone", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "VehicleNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 30)
        AgL.FSetColumnValue(MdlTable, "Person_To_Meet", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Perpose", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "Out_EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Out_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Out_Time", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Div_Code", "Div_Code", "Division")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub


    Private Sub FFaChequeDatail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "GUID", AgLibrary.ClsMain.SQLDataType.nVarChar, 36, True)
        AgL.FSetColumnValue(MdlTable, "DocID", AgLibrary.ClsMain.SQLDataType.nvarchar, 21)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.int)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nvarchar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nvarchar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nvarchar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nvarchar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.bigint)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.smalldatetime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nvarchar, 50)
        AgL.FSetColumnValue(MdlTable, "BankAc", AgLibrary.ClsMain.SQLDataType.nvarchar, 10)
        AgL.FSetColumnValue(MdlTable, "PartyAc", AgLibrary.ClsMain.SQLDataType.nvarchar, 10)
        AgL.FSetColumnValue(MdlTable, "BankName", AgLibrary.ClsMain.SQLDataType.nvarchar, 100)
        AgL.FSetColumnValue(MdlTable, "ChequeNo", AgLibrary.ClsMain.SQLDataType.nvarchar, 20)
        AgL.FSetColumnValue(MdlTable, "ChequeDate", AgLibrary.ClsMain.SQLDataType.smalldatetime)
        AgL.FSetColumnValue(MdlTable, "ClearingDate", AgLibrary.ClsMain.SQLDataType.smalldatetime)
        AgL.FSetColumnValue(MdlTable, "DishonourDate", AgLibrary.ClsMain.SQLDataType.smalldatetime)
        AgL.FSetColumnValue(MdlTable, "AmtDr", AgLibrary.ClsMain.SQLDataType.float)
        AgL.FSetColumnValue(MdlTable, "AmtCr", AgLibrary.ClsMain.SQLDataType.float)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nvarchar, 255)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetFKeyValue(MdlTable, "PartyAc", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "BankAc", "SubCode", "SubGroup")
    End Sub


    Public Shared Sub ProcStockPost(ByVal bTableName As String, ByVal bStock As ClsMain.StructStock, _
                              ByVal bConn As SqlClient.SqlConnection, _
                              ByVal bCmd As SqlClient.SqlCommand)
        Dim mQry$

        With bStock
            mQry = "INSERT INTO " & bTableName & "(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                    " SubCode, Currency, SalesTaxGroupParty, Structure, BillingType, Item, ProcessGroup, " & _
                    " Godown, Qty_Iss, Qty_Rec, Unit, LotNo, MeasurePerPcs, Measure_Iss, Measure_Rec, MeasureUnit, " & _
                    " Rate, Amount, Addition, Deduction, NetAmount, Remarks, Status, UID, Process, " & _
                    " FIFORate, FIFOAmt, AVGRate, AVGAmt, Cost, Doc_Qty, ReferenceDocID) " & _
                    " VALUES (" & AgL.Chk_Text(.DocID) & ", " & Val(.Sr) & ", " & _
                    " " & AgL.Chk_Text(.V_Type) & ", " & AgL.Chk_Text(.V_Prefix) & ", " & _
                    " " & AgL.ConvertDate(.V_Date) & ",	" & Val(.V_No) & ", " & AgL.Chk_Text(.Div_Code) & ", " & _
                    " " & AgL.Chk_Text(.Site_Code) & ",	" & AgL.Chk_Text(.SubCode) & ",	" & _
                    " " & AgL.Chk_Text(.Currency) & ", " & AgL.Chk_Text(.SalesTaxGroupParty) & ", " & _
                    " " & AgL.Chk_Text(.Structure1) & ", " & AgL.Chk_Text(.BillingType) & ", " & _
                    " " & AgL.Chk_Text(.Item) & ",	" & AgL.Chk_Text(.ProcessGroup) & ", " & _
                    " " & AgL.Chk_Text(.Godown) & ", " & Val(.Qty_Iss) & ",	" & Val(.Qty_Rec) & ",  " & _
                    " " & AgL.Chk_Text(.Unit) & ", " & AgL.Chk_Text(.LotNo) & ", " & _
                    " " & Val(.MeasurePerPcs) & ",	" & Val(.Measure_Iss) & ",	" & Val(.Measure_Rec) & ",	" & _
                    " " & AgL.Chk_Text(.MeasureUnit) & ", " & Val(.Rate) & ", " & _
                    " " & Val(.Amount) & ",	" & Val(.Addition) & ",	" & Val(.Deduction) & ", " & _
                    " " & Val(.NetAmount) & ",	" & AgL.Chk_Text(.Remarks) & ",	" & AgL.Chk_Text(.Status) & ",	" & _
                    " " & AgL.Chk_Text(.UID) & ", " & AgL.Chk_Text(.Process) & ", " & Val(.FIFORate) & ", " & _
                    " " & Val(.FIFOAmt) & ", " & Val(.AVGRate) & ",	" & Val(.AVGAmt) & ", " & _
                    " " & Val(.Cost) & ", " & Val(.Doc_Qty) & ", " & AgL.Chk_Text(.ReferenceDocID) & ") "
            AgL.Dman_ExecuteNonQry(mQry, bConn, bCmd)
        End With
    End Sub


    Public Structure Dues
        Dim DocID As String
        Dim Sr As Integer
        Dim V_Type As String
        Dim V_Prefix As String
        Dim V_Date As String
        Dim V_No As Long
        Dim Div_Code As String
        Dim Site_Code As String
        Dim CashCredit As String
        Dim SubCode As String
        Dim Narration As String
        Dim ReferenceDocID As String
        Dim RefV_Type As String
        Dim RefV_No As String
        Dim RefPartyName As String
        Dim RefPartyAddress As String
        Dim RefPartyCity As String
        Dim PaybleAmount As Double
        Dim ReceivableAmount As Double
        Dim AdjustedAmount As Double
        Dim EntryBy As String
        Dim EntryDate As String
        Dim EntryType As String
        Dim EntryStatus As String
        Dim ApproveBy As String
        Dim ApproveDate As String
        Dim MoveToLog As String
        Dim MoveToLogDate As String
        Dim IsDeleted As String
        Dim Status As String
        Dim UID As String
    End Structure

    Public Shared Sub ProcPostInDues(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand, _
                              ByVal StructDue As ClsMain.Dues)
        Dim mQry$ = ""

        mQry = " Delete From Dues Where DocId = '" & StructDue.DocID & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "INSERT INTO Dues(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, CashCredit, " & _
                    " Site_Code, SubCode, Narration, ReferenceDocID, RefV_Type, RefV_No, RefPartyName, RefPartyAddress, RefPartyCity, PaybleAmount, ReceivableAmount, AdjustedAmount, " & _
                    "  EntryBy, EntryDate, EntryType, EntryStatus, ApproveBy, " & _
                    " ApproveDate, MoveToLog, MoveToLogDate, IsDeleted, Status,	UID	) " & _
                    " VALUES(" & AgL.Chk_Text(StructDue.DocID) & ", " & Val(StructDue.Sr) & ", " & _
                    " " & AgL.Chk_Text(StructDue.V_Type) & " , " & _
                    " " & AgL.Chk_Text(StructDue.V_Prefix) & ", " & AgL.Chk_Text(StructDue.V_Date) & ", " & _
                    " " & Val(StructDue.V_No) & ", " & _
                    " " & AgL.Chk_Text(StructDue.Div_Code) & ", " & AgL.Chk_Text(StructDue.CashCredit) & ", " & AgL.Chk_Text(StructDue.Site_Code) & ",  " & _
                    " " & AgL.Chk_Text(StructDue.SubCode) & ", " & AgL.Chk_Text(StructDue.Narration) & ", " & _
                    " " & AgL.Chk_Text(StructDue.ReferenceDocID) & ",  " & _
                    " " & AgL.Chk_Text(StructDue.RefV_Type) & ",  " & _
                    " " & AgL.Chk_Text(StructDue.RefV_No) & ",  " & _
                    " " & AgL.Chk_Text(StructDue.RefPartyName) & ",  " & _
                    " " & AgL.Chk_Text(StructDue.RefPartyAddress) & ",  " & _
                    " " & AgL.Chk_Text(StructDue.RefPartyCity) & ",  " & _
                    " " & Val(StructDue.PaybleAmount) & ", " & _
                    " " & Val(StructDue.ReceivableAmount) & ", " & Val(StructDue.AdjustedAmount) & ", " & _
                    " " & AgL.Chk_Text(StructDue.EntryBy) & ", " & AgL.Chk_Text(StructDue.EntryDate) & ", " & _
                    " " & AgL.Chk_Text(StructDue.EntryType) & ",  " & _
                    " " & AgL.Chk_Text(StructDue.EntryStatus) & ", " & AgL.Chk_Text(StructDue.ApproveBy) & ", " & _
                    " " & AgL.Chk_Text(StructDue.ApproveDate) & ", " & AgL.Chk_Text(StructDue.MoveToLog) & ", " & _
                    " " & AgL.Chk_Text(StructDue.MoveToLogDate) & ",  " & _
                    " " & AgL.Chk_Text(StructDue.IsDeleted) & ", " & AgL.Chk_Text(StructDue.Status) & ", " & _
                    " " & AgL.Chk_Text(StructDue.UID) & ") "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Public Structure ToBeBilled
        Dim DocID As String
        Dim V_Type As String
        Dim V_Prefix As String
        Dim V_Date As String
        Dim V_No As Long
        Dim Div_Code As String
        Dim Site_Code As String
        Dim ReferenceNo As String
        Dim SubCode As String
        Dim PartyName As String
        Dim PartyAddress As String
        Dim PartyCity As String
        Dim TotalQty As Double
        Dim ReceivableAmount As Double
        Dim PaybleAmount As Double
        Dim AdjustedAmount As Double
        Dim BilledAmount As Double
        Dim PaidAmount As Double
        Dim EntryBy As String
        Dim EntryDate As String
        Dim EntryType As String
        Dim EntryStatus As String
        Dim ApproveBy As String
        Dim ApproveDate As String
        Dim MoveToLog As String
        Dim MoveToLogDate As String
        Dim IsDeleted As Byte
        Dim Status As String
        Dim UID
    End Structure

    Public Shared Sub ProcPostInToBeBilled(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand, ByVal StructToBeBilled As ToBeBilled)
        Dim mQry$ = ""
        With StructToBeBilled
            mQry = " DELETE FROM ToBeBilled Where DocId = '" & .DocID & "'   "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

            mQry = " INSERT INTO ToBeBilled(DocID, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                    " ReferenceNo, SubCode, PartyName, PartyAddress, PartyCity, TotalQty, ReceivableAmount, " & _
                    " PaybleAmount, AdjustedAmount, BilledAmount, PaidAmount, EntryBy, EntryDate, " & _
                    " EntryType, EntryStatus, ApproveBy, ApproveDate, MoveToLog, MoveToLogDate, " & _
                    " IsDeleted, Status, UID) " & _
                    " VALUES (" & AgL.Chk_Text(.DocID) & ", " & AgL.Chk_Text(.V_Type) & ", " & _
                    " " & AgL.Chk_Text(.V_Prefix) & ", " & AgL.Chk_Text(.V_Date) & ", " & _
                    " " & Val(.V_No) & ", " & AgL.Chk_Text(.Div_Code) & ", " & _
                    " " & AgL.Chk_Text(.Site_Code) & ", " & _
                    " " & AgL.Chk_Text(.ReferenceNo) & ", " & AgL.Chk_Text(.SubCode) & ", " & _
                    " " & AgL.Chk_Text(.PartyName) & ", " & AgL.Chk_Text(.PartyAddress) & ", " & _
                    " " & AgL.Chk_Text(.PartyCity) & ", " & Val(.TotalQty) & ", " & _
                    " " & Val(.ReceivableAmount) & ", " & Val(.PaybleAmount) & ", " & _
                    " " & Val(.AdjustedAmount) & ", " & Val(.BilledAmount) & ", " & _
                    " " & Val(.PaidAmount) & ", " & _
                    " " & AgL.Chk_Text(.EntryBy) & ", " & AgL.Chk_Text(.EntryDate) & ", " & _
                    " " & AgL.Chk_Text(.EntryType) & ", " & AgL.Chk_Text(.EntryStatus) & ", " & _
                    " " & AgL.Chk_Text(.ApproveBy) & ", " & AgL.Chk_Text(.ApproveDate) & ", " & _
                    " " & AgL.Chk_Text(.MoveToLog) & ", " & AgL.Chk_Text(.MoveToLogDate) & ", " & _
                    " " & AgL.Chk_Text(.IsDeleted) & ", " & AgL.Chk_Text(.Status) & ", " & _
                    " " & AgL.Chk_Text(.UID) & ") "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End With
    End Sub


    Public Shared Sub ProcReminderSave(ByVal EntryDate As String, ByVal EntryTime As String, ByVal RemindDate As String, ByVal RemindTime As String, ByVal RemindNarration As String, ByVal StrRemindTo As String, Optional ByVal CurrentReminderId As String = "", Optional ByVal ParrentReminderId As String = "")
        Dim mQry As String
        Dim mSearchCode As String = ""
        Dim mTrans As Boolean = False
        Dim mID As String
        Dim I As Integer, mSr As Integer
        Dim mstrArrUser As String()
        Try
            mstrArrUser = StrRemindTo.Split(",")
            If CurrentReminderId = "" Then
                mQry = " SELECT isnull(max(substring(R.ID,7,4)),0)+ 1  FROM Reminder R WHERE R.V_Date = " & AgL.Chk_Text(EntryDate) & ""
                mID = AgL.Dman_Execute(mQry, AgL.GCn, AgL.ECmd).ExecuteScalar().ToString().PadLeft(4, "0")
                mSearchCode = Format(CDate(EntryDate), "ddMMyy") + mID

                mQry = " INSERT INTO Reminder (ID, Ref_ID, V_Date, V_Time, EntryBy, Narration, RemindTo ," & _
                        " Reminder_Date, Reminder_Time) " & _
                        " VALUES ('" & mSearchCode & "'," & AgL.Chk_Text(ParrentReminderId) & ", " & AgL.Chk_Text(EntryDate) & ", " & AgL.Chk_Text(EntryTime) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(RemindNarration) & ", " & AgL.Chk_Text(StrRemindTo) & ", " & AgL.Chk_Text(RemindDate) & "," & _
                        " " & AgL.Chk_Text(RemindTime) & " ) "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            Else
                mSearchCode = CurrentReminderId
                mQry = " UPDATE Reminder " & _
                         " SET Narration = " & AgL.Chk_Text(RemindNarration) & ", " & _
                         " RemindTo = " & AgL.Chk_Text(StrRemindTo) & ", " & _
                         " Reminder_Date = " & AgL.Chk_Text(RemindDate) & ", " & _
                         " Reminder_Time = " & AgL.Chk_Text(RemindTime) & " " & _
                         " WHERE ID = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            mQry = "Delete From ReminderDetail Where ID = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            For I = 0 To mstrArrUser.Length - 1
                mSr += 1
                mQry = " INSERT INTO ReminderDetail (ID, Sr, Reminder_To, Status) " & _
                        " VALUES ('" & mSearchCode & "', " & mSr & ", " & AgL.Chk_Text(mstrArrUser(I)) & ", 'Active') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Next

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()
            mTrans = False
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Sub ProcGetPartyAddress(ByVal Party As String, ByRef Address As String, ByRef City As String, ByVal Conn As SqlClient.SqlConnection)
        Dim mQry$ = ""
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = " SELECT CityCode As City, IsNull(Add1,'') + IsNull(Add2,'') + IsNull(Add3,'') AS Address FROM SubGroup WHERE SubCode = '" & Party & "' "
            DtTemp = AgL.FillData(mQry, Conn).Tables(0)
            With DtTemp
                If .Rows.Count > 0 Then
                    City = AgL.XNull(.Rows(0)("City"))
                    Address = Strings.Left(AgL.XNull(.Rows(0)("Address")), 100)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message & " In AgTemplate.ClsMain.ProGetPartyAddress.", MsgBoxStyle.Exclamation)
        End Try
    End Sub

    Public Shared Function FRetTermsCondition(ByVal VType As String) As String
        Dim mQry As String
        mQry = " SELECT ISNULL(H.Description,'')  FROM TermsCondition H " & _
                " WHERE H.Code ='" & VType & "' "
        FRetTermsCondition = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn, AgL.ECmd).ExecuteScalar)
    End Function

    Public Shared Sub ProcCreateLink(ByVal DGL As DataGridView, ByVal ColumnName As String)
        Try
            DGL.Columns(ColumnName).CellTemplate.Style.Font = New Font(DGL.DefaultCellStyle.Font.FontFamily, DGL.DefaultCellStyle.Font.Size, FontStyle.Underline)
            DGL.Columns(ColumnName).CellTemplate.Style.ForeColor = Color.Blue

            If DGL.Rows.Count > 0 Then
                DGL.Item(ColumnName, 0).Style.Font = New Font(DGL.DefaultCellStyle.Font.FontFamily, DGL.DefaultCellStyle.Font.Size, FontStyle.Underline)
                DGL.Item(ColumnName, 0).Style.ForeColor = Color.Blue
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class