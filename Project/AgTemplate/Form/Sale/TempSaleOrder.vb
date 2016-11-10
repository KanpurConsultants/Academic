Imports CrystalDecisions.CrystalReports.Engine
Public Class TempSaleOrder
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid
    Public WithEvents Dgl1 As AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Item As String = "Item"
    Protected Const Col1PartySKU As String = "Party SKU"
    Protected Const Col1PartyUPC As String = "Party UPC"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1SalesTaxGroup As String = "Sales Tax Group"
    Protected Const Col1xPartySKU As String = "xParty SKU"
    Protected Const Col1xPartyUPC As String = "xParty UPC"

    'Code BY Akash ON date 15-6-2011
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1MeasureUnit As String = "MeasureUnit"
    Protected Const Col1ShippedQty As String = "ShippedQty"
    Protected Const Col1ShippedMeasure As String = "ShippedMeasure"
    Protected Const Col1ProdOrdQty As String = "ProdOrdQty"
    Protected Const Col1ProdOrdMeasure As String = "ProdOrdMeasure"
    Protected Const Col1ProdPlanQty As String = "ProdPlanQty"
    Protected Const Col1ProdPlanMeasure As String = "ProdPlanMeasure"
    Protected Const Col1PurchQty As String = "PurchQty"
    Protected Const Col1PurchMeasure As String = "PurchMeasure"
    Protected Const Col1ProdIssQty As String = "ProdIssQty"
    Protected Const Col1ProdIssMeasure As String = "ProdIssMeasure"
    Protected Const Col1ProdRecQty As String = "ProdRecQty"
    Protected Const Col1ProdRecMeasure As String = "ProdRecMeasure"
    Protected Const Col1StockMeasurePerPcs As String = "Stock Measure Per Pcs"
    Protected Const Col1StockTotalMeasure As String = "Stock Total Measure"

    Public Class HelpDataSet
        Public Shared SaleToParty As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared City As DataSet = Nothing
        Public Shared Currency As DataSet = Nothing
        Public Shared Port As DataSet = Nothing
        Public Shared AgStructure As DataSet = Nothing
        Public Shared SalesTaxGroupParty As DataSet = Nothing
        Public Shared BillingType As DataSet = Nothing
        Public Shared Status As DataSet = Nothing
        Public Shared Priority As DataSet = Nothing
        Public Shared Agent As DataSet = Nothing
    End Class

    Dim mLastKeyPressed As Keys

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer
        Dim mSr As Integer


        '------------------------------------------------------------------------
        'Updating Buyer Wise Item SKU and UPC (Universal Product Code)
        '-------------------------------------------------------------------------
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" And (Dgl1.Item(Col1PartySKU, I).Value <> "" Or Dgl1.Item(Col1PartyUPC, I).Value <> "") Then
                If Not AgL.StrCmp(Dgl1.Item(Col1PartySKU, I).Value, Dgl1.Item(Col1xPartySKU, I).Value) Then
                    If Dgl1.Item(Col1xPartySKU, I).Value = "" Then
                        mQry = "Select IsNull(Max(Sr),0)+1 From ItemBuyer Where Code = '" & Dgl1.AgSelectedValue(Col1Item, I) & "'"
                        mSr = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
                        mQry = "INSERT INTO dbo.ItemBuyer (Code, Sr, Buyer, BuyerSku, BuyerUpcCode, UID) " & _
                               "VALUES (" & Dgl1.AgSelectedValue(Col1Item, I) & ", " & mSr & ", " & TxtSaleToParty.AgSelectedValue & ", " & AgL.Chk_Text(Dgl1.Item(Col1PartySKU, I).Value) & ", " & AgL.Chk_Text(Dgl1.Item(Col1PartyUPC, I).Value) & ", " & AgL.Chk_Text(SearchCode) & ") "
                    Else
                        mQry = "UPDATE dbo.ItemBuyer " & _
                               "SET BuyerSku = " & AgL.Chk_Text(Dgl1.Item(Col1PartySKU, I).Value) & ", " & _
                               "BuyerUpcCode =" & AgL.Chk_Text(Dgl1.Item(Col1PartyUPC, I).Value) & " " & _
                               "Where UID = '" & SearchCode & "' "
                    End If
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            End If
        Next
        '-------------------------------------------------------------------------

    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog

        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"


        'AgL.PubFindQry = "SELECT H.UID as SearchCode, Vt.Description AS [Entry Type], H.V_Date AS [Entry Date], H.V_No AS [Entry No], " & _
        '                 "H.SaleToPartyName AS [Sale TO Party], H.SaleToPartyAdd1 AS [Sale TO Party Address1],  " & _
        '                 "H.SaleToPartyAdd2 AS [Sale TO Party Address2], H.SaleToPartyCityName AS [Sale TO Party City],  " & _
        '                 "H.SaleToPartyState AS [Sale TO Party State], H.SaleToPartyCountry  AS [Sale TO Party Country],  " & _
        '                 "H.ShipToPartyName  AS [Ship TO Party Name], H.ShipToPartyAdd1  AS [Ship TO Party Address1],  " & _
        '                 "H.ShipToPartyAdd2  AS [Ship TO Party Address2], H.ShipToPartyCityName AS [Ship TO Party City],  " & _
        '                 "H.ShipToPartyState AS [Ship TO Party State], H.ShipToPartyCountry AS [Ship TO Party Country],  " & _
        '                 "H.PartyOrderNo  AS [Party Order No], H.PartyOrderDate AS [Party Order Date],  " & _
        '                 "H.PartyOrderCancelDate AS [Party ORDER Cancel Date], " & _
        '                 "DP.Description AS [Destination Port], H.FinalPlaceOfDelivery AS [Final Place OF Delivery],  " & _
        '                 "H.TermsAndConditions AS [Terms & Conditions], H.ApproveBy, H.ApproveDate, H.IsDeleted  " & _
        '                 "FROM dbo.SaleOrder_Log H " & _
        '                 "LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type " & _
        '                 "LEFT JOIN SeaPort DP ON H.DestinationPort = DP.Code " & _
        '                 "Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQry = " SELECT H.UID AS SearchCode, H.V_Type AS [Sale Order Type],  H.V_Prefix AS Prefix, H.V_Date AS [Sale Order Date], H.V_No AS [Sale Order No], " & _
                    " H.SaleToPartyName AS [Sale To Party Name], H.SaleToPartyAdd1 AS [Sale To Party Add1], H.SaleToPartyAdd2 AS [Sale To Party Add2], H.SaleToPartyCityName AS [Sale TO Party City Name],  " & _
                    " H.SaleToPartyState AS [Sale TO Party State], H.SaleToPartyCountry AS [Sale TO Party Country], H.ShipToPartyName AS [Ship TO Party Name], H.ShipToPartyAdd1 AS [Ship TO Party Add1], H.ShipToPartyAdd2 AS [Ship To Party Add2],  " & _
                    " H.ShipToPartyCityName AS [Ship To Party City Name], H.ShipToPartyState AS [Ship TO Party State], H.ShipToPartyCountry AS [Ship TO Party Country], H.Currency, " & _
                    " H.Structure, H.BillingType AS [Billing Type], H.PartyOrderNo AS [Party ORDER No], H.PartyOrderDate AS [Party ORDER Date], H.PartyDeliveryDate AS [Party Delivery Date], H.PartyOrderCancelDate AS [Party ORDER Cancel Date],  " & _
                    " H.FinalPlaceOfDelivery AS [Final Place Of Delivery] , H.TermsAndConditions AS [Terms & Conditions], H.Remarks, H.TotalQty AS [Total Qty], H.TotalMeasure AS [Total Measure], H.TotalAmount AS [Total Amount],  " & _
                    " H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move TO Log], H.MoveToLogDate AS [Move TO LOG Date], " & _
                    " H.Status, H.UID, H.DeliveryMeasure AS [Delivery Measure], H.ShipmentDate AS [Shipment Date], H.FactoryDate AS [Factory Date], H.FactoryDeliveryDate AS [Factory Delivery Date], H.ExFactoryShipmentDate AS [Ex-Factory Shipment Date],  " & _
                    " H.FactoryCancelDate AS [Factory Cancel Date], H.Priority, H.PreCarriageBy AS [Pre Carriage By], H.PlaceOfReceipt AS [Place Of Receipt], H.ShipmentThrough AS [Shipment Through], H.BankAcNoBuyer AS [Bank Ac No Buyer] ,  " & _
                    " H.BankNameBuyer AS [Bank Name Buyer], H.BankAddressBuyer AS [Bank Address Buyer], H.PriceMode AS [Price Mode], H.StockTotalMeasure AS [Stock Total Measure],D.Div_Name AS [Division],SM.Name AS [Site Name], SGA.DispName AS [Agent Name], " & _
                    " DP.Description AS [Destination Port Name] " & _
                    " FROM SaleOrder_Log  H " & _
                    " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type " & _
                    " LEFT JOIN SubGroup SGA ON SGA.SubCode  = H.Agent  " & _
                    " LEFT JOIN SeaPort DP ON H.DestinationPort = DP.Code  " & _
                    "Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Order Date]"
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "SaleOrder"
        LogTableName = "SaleOrder_Log"
        MainLineTableCsv = "SaleOrderDetail,Structure_TransFooter,Structure_TransLine"
        LogLineTableCsv = "SaleOrderDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"

        AgL.GridDesign(Dgl1)
        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)
        AgCalcGrid1.AgLibVar = AgL
        AgCalcGrid1.Visible = False
    End Sub


    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"


        mQry = "Select DocID As SearchCode " & _
            " From SaleOrder H " & _
            " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
            "Where IsNull(IsDeleted,0)=0  " & mCondStr & "  Order By V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = "Select UID As SearchCode " & _
               " From SaleOrder_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               "Where EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And IsNull(H.IsDeleted,0)=0 And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT H.DocID, Vt.Description AS [Entry Type], H.V_Date AS [Entry Date], H.V_No AS [Entry No], " & _
        '                 "H.SaleToPartyName AS [Sale TO Party], H.SaleToPartyAdd1 AS [Sale TO Party Address1],  " & _
        '                 "H.SaleToPartyAdd2 AS [Sale TO Party Address2], H.SaleToPartyCityName AS [Sale TO Party City],  " & _
        '                 "H.SaleToPartyState AS [Sale TO Party State], H.SaleToPartyCountry  AS [Sale TO Party Country],  " & _
        '                 "H.ShipToPartyName  AS [Ship TO Party Name], H.ShipToPartyAdd1  AS [Ship TO Party Address1],  " & _
        '                 "H.ShipToPartyAdd2  AS [Ship TO Party Address2], H.ShipToPartyCityName AS [Ship TO Party City],  " & _
        '                 "H.ShipToPartyState AS [Ship TO Party State], H.ShipToPartyCountry AS [Ship TO Party Country],  " & _
        '                 "H.PartyOrderNo  AS [Party Order No], H.PartyOrderDate AS [Party Order Date],  " & _
        '                 "H.PartyOrderCancelDate AS [Party ORDER Cancel Date], " & _
        '                 "DP.Description AS [Destination Port], H.FinalPlaceOfDelivery AS [Final Place OF Delivery],  " & _
        '                 "H.TermsAndConditions AS [Terms & Conditions], H.ApproveBy, H.ApproveDate, H.IsDeleted  " & _
        '                 "FROM dbo.SaleOrder H " & _
        '                 "LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type " & _
        '                 "LEFT JOIN SeaPort DP ON H.DestinationPort = DP.Code " & _
        '                 "Where 1=1 " & mCondStr

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, H.V_Type AS [Sale Order Type],  H.V_Prefix AS Prefix, H.V_Date AS [Sale Order Date], H.V_No AS [Sale Order No], " & _
                    " H.SaleToPartyName AS [Sale To Party Name], H.SaleToPartyAdd1 AS [Sale To Party Add1], H.SaleToPartyAdd2 AS [Sale To Party Add2], H.SaleToPartyCityName AS [Sale TO Party City Name],  " & _
                    " H.SaleToPartyState AS [Sale TO Party State], H.SaleToPartyCountry AS [Sale TO Party Country], H.ShipToPartyName AS [Ship TO Party Name], H.ShipToPartyAdd1 AS [Ship TO Party Add1], H.ShipToPartyAdd2 AS [Ship To Party Add2],  " & _
                    " H.ShipToPartyCityName AS [Ship To Party City Name], H.ShipToPartyState AS [Ship TO Party State], H.ShipToPartyCountry AS [Ship TO Party Country], H.Currency, " & _
                    " H.Structure, H.BillingType AS [Billing Type], H.PartyOrderNo AS [Party ORDER No], H.PartyOrderDate AS [Party ORDER Date], H.PartyDeliveryDate AS [Party Delivery Date], H.PartyOrderCancelDate AS [Party ORDER Cancel Date],  " & _
                    " H.FinalPlaceOfDelivery AS [Final Place Of Delivery] , H.TermsAndConditions AS [Terms & Conditions], H.Remarks, H.TotalQty AS [Total Qty], H.TotalMeasure AS [Total Measure], H.TotalAmount AS [Total Amount],  " & _
                    " H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move TO Log], H.MoveToLogDate AS [Move TO LOG Date], " & _
                    " H.Status, H.UID, H.DeliveryMeasure AS [Delivery Measure], H.ShipmentDate AS [Shipment Date], H.FactoryDate AS [Factory Date], H.FactoryDeliveryDate AS [Factory Delivery Date], H.ExFactoryShipmentDate AS [Ex-Factory Shipment Date],  " & _
                    " H.FactoryCancelDate AS [Factory Cancel Date], H.Priority, H.PreCarriageBy AS [Pre Carriage By], H.PlaceOfReceipt AS [Place Of Receipt], H.ShipmentThrough AS [Shipment Through], H.BankAcNoBuyer AS [Bank Ac No Buyer] ,  " & _
                    " H.BankNameBuyer AS [Bank Name Buyer], H.BankAddressBuyer AS [Bank Address Buyer], H.PriceMode AS [Price Mode], H.StockTotalMeasure AS [Stock Total Measure],D.Div_Name AS [Division],SM.Name AS [Site Name], SGA.DispName AS [Agent Name], " & _
                    " DP.Description AS [Destination Port Name] " & _
                    " FROM SaleOrder  H " & _
                    " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type " & _
                    " LEFT JOIN SubGroup SGA ON SGA.SubCode  = H.Agent  " & _
                    " LEFT JOIN SeaPort DP ON H.DestinationPort = DP.Code  " & _
                    " Where 1=1 " & mCondStr

        AgL.PubFindQryOrdBy = "[Order Date]"
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtSaleToParty = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtSaleToPartyAdd1 = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtSaleToPartyAdd2 = New AgControls.AgTextBox
        Me.TxtSaleToPartyCity = New AgControls.AgTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtSaleToPartyState = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtSaleToPartyCountry = New AgControls.AgTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtPartyOrderDate = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtPartyOrderNo = New AgControls.AgTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtOrderCancelDate = New AgControls.AgTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtDeliveryDate = New AgControls.AgTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TPExport = New System.Windows.Forms.TabPage
        Me.TxtPriceMode = New AgControls.AgTextBox
        Me.LblPriceMode = New System.Windows.Forms.Label
        Me.TxtBankAddressBuyer = New AgControls.AgTextBox
        Me.LblBankAddressBuyer = New System.Windows.Forms.Label
        Me.TxtBankNameBuyer = New AgControls.AgTextBox
        Me.LblBankNameBuyer = New System.Windows.Forms.Label
        Me.TxtBankAcNoBuyer = New AgControls.AgTextBox
        Me.LblBankAcNoBuyer = New System.Windows.Forms.Label
        Me.TxtShipmentThrough = New AgControls.AgTextBox
        Me.LblShipmentThrough = New System.Windows.Forms.Label
        Me.TxtPlaceOfReceipt = New AgControls.AgTextBox
        Me.LblPlaceOfReceipt = New System.Windows.Forms.Label
        Me.TxtPreCarriageBy = New AgControls.AgTextBox
        Me.LblPreCariageBy = New System.Windows.Forms.Label
        Me.TxtCurrency = New AgControls.AgTextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.TxtFinalPlaceOfDelivery = New AgControls.AgTextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtDestinationCountry = New AgControls.AgTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtDestinationPort = New AgControls.AgTextBox
        Me.Label15 = New System.Windows.Forms.Label
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
        Me.TxtPriority = New AgControls.AgTextBox
        Me.LblPriority = New System.Windows.Forms.Label
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
        Me.TPExport.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TPShipping.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(832, 575)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 575)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 575)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 575)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 575)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 571)
        Me.GroupBox1.Size = New System.Drawing.Size(1010, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(300, 575)
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
        Me.LblV_No.Location = New System.Drawing.Point(234, 25)
        Me.LblV_No.Size = New System.Drawing.Size(64, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Order No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(342, 24)
        Me.TxtV_No.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(112, 30)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(16, 25)
        Me.LblV_Date.Size = New System.Drawing.Size(71, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Order Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(312, 10)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(128, 24)
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(234, 6)
        Me.LblV_Type.Size = New System.Drawing.Size(72, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Order Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(342, 4)
        Me.TxtV_Type.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(112, 10)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(16, 5)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(128, 4)
        Me.TxtSite_Code.Size = New System.Drawing.Size(100, 18)
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(294, 25)
        Me.LblPrefix.Tag = ""
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TPExport)
        Me.TabControl1.Controls.Add(Me.TPShipping)
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(4, 41)
        Me.TabControl1.Size = New System.Drawing.Size(980, 176)
        Me.TabControl1.TabIndex = 22
        Me.TabControl1.Controls.SetChildIndex(Me.TPShipping, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TPExport, 0)
        Me.TabControl1.Controls.SetChildIndex(Me.TP1, 0)
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.LblPriority)
        Me.TP1.Controls.Add(Me.TxtPriority)
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
        Me.TP1.Controls.Add(Me.TxtOrderCancelDate)
        Me.TP1.Controls.Add(Me.Label10)
        Me.TP1.Controls.Add(Me.TxtDeliveryDate)
        Me.TP1.Controls.Add(Me.Label11)
        Me.TP1.Controls.Add(Me.TxtPartyOrderDate)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.TxtPartyOrderNo)
        Me.TP1.Controls.Add(Me.Label9)
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
        Me.TP1.Controls.Add(Me.TxtSaleToParty)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(972, 150)
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
        Me.TP1.Controls.SetChildIndex(Me.Label5, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToParty, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.Label9, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label3, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyOrderDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label11, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDeliveryDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label10, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtOrderCancelDate, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.TxtPriority, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPriority, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(992, 41)
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(114, 51)
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
        Me.TxtSaleToParty.Location = New System.Drawing.Point(128, 44)
        Me.TxtSaleToParty.MaxLength = 0
        Me.TxtSaleToParty.Name = "TxtSaleToParty"
        Me.TxtSaleToParty.Size = New System.Drawing.Size(377, 18)
        Me.TxtSaleToParty.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(16, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(84, 16)
        Me.Label5.TabIndex = 693
        Me.Label5.Text = "Sale to Party"
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
        Me.TxtSaleToPartyAdd1.Location = New System.Drawing.Point(128, 64)
        Me.TxtSaleToPartyAdd1.MaxLength = 20
        Me.TxtSaleToPartyAdd1.Name = "TxtSaleToPartyAdd1"
        Me.TxtSaleToPartyAdd1.Size = New System.Drawing.Size(377, 18)
        Me.TxtSaleToPartyAdd1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 64)
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
        Me.TxtSaleToPartyAdd2.Location = New System.Drawing.Point(128, 84)
        Me.TxtSaleToPartyAdd2.MaxLength = 20
        Me.TxtSaleToPartyAdd2.Name = "TxtSaleToPartyAdd2"
        Me.TxtSaleToPartyAdd2.Size = New System.Drawing.Size(377, 18)
        Me.TxtSaleToPartyAdd2.TabIndex = 7
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
        Me.TxtSaleToPartyCity.Location = New System.Drawing.Point(128, 104)
        Me.TxtSaleToPartyCity.MaxLength = 20
        Me.TxtSaleToPartyCity.Name = "TxtSaleToPartyCity"
        Me.TxtSaleToPartyCity.Size = New System.Drawing.Size(377, 18)
        Me.TxtSaleToPartyCity.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 105)
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
        Me.TxtSaleToPartyState.Location = New System.Drawing.Point(128, 124)
        Me.TxtSaleToPartyState.MaxLength = 20
        Me.TxtSaleToPartyState.Name = "TxtSaleToPartyState"
        Me.TxtSaleToPartyState.Size = New System.Drawing.Size(134, 18)
        Me.TxtSaleToPartyState.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(16, 124)
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
        Me.TxtSaleToPartyCountry.Location = New System.Drawing.Point(359, 124)
        Me.TxtSaleToPartyCountry.MaxLength = 20
        Me.TxtSaleToPartyCountry.Name = "TxtSaleToPartyCountry"
        Me.TxtSaleToPartyCountry.Size = New System.Drawing.Size(146, 18)
        Me.TxtSaleToPartyCountry.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(265, 125)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 16)
        Me.Label8.TabIndex = 704
        Me.Label8.Text = "Country"
        '
        'TxtPartyOrderDate
        '
        Me.TxtPartyOrderDate.AgMandatory = False
        Me.TxtPartyOrderDate.AgMasterHelp = True
        Me.TxtPartyOrderDate.AgNumberLeftPlaces = 8
        Me.TxtPartyOrderDate.AgNumberNegetiveAllow = False
        Me.TxtPartyOrderDate.AgNumberRightPlaces = 2
        Me.TxtPartyOrderDate.AgPickFromLastValue = False
        Me.TxtPartyOrderDate.AgRowFilter = ""
        Me.TxtPartyOrderDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPartyOrderDate.AgSelectedValue = Nothing
        Me.TxtPartyOrderDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPartyOrderDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtPartyOrderDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartyOrderDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartyOrderDate.Location = New System.Drawing.Point(853, 4)
        Me.TxtPartyOrderDate.MaxLength = 20
        Me.TxtPartyOrderDate.Name = "TxtPartyOrderDate"
        Me.TxtPartyOrderDate.Size = New System.Drawing.Size(104, 18)
        Me.TxtPartyOrderDate.TabIndex = 12
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(754, 5)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 16)
        Me.Label3.TabIndex = 708
        Me.Label3.Text = "Party Order Dt."
        '
        'TxtPartyOrderNo
        '
        Me.TxtPartyOrderNo.AgMandatory = False
        Me.TxtPartyOrderNo.AgMasterHelp = True
        Me.TxtPartyOrderNo.AgNumberLeftPlaces = 8
        Me.TxtPartyOrderNo.AgNumberNegetiveAllow = False
        Me.TxtPartyOrderNo.AgNumberRightPlaces = 2
        Me.TxtPartyOrderNo.AgPickFromLastValue = False
        Me.TxtPartyOrderNo.AgRowFilter = ""
        Me.TxtPartyOrderNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPartyOrderNo.AgSelectedValue = Nothing
        Me.TxtPartyOrderNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPartyOrderNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPartyOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartyOrderNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartyOrderNo.Location = New System.Drawing.Point(625, 4)
        Me.TxtPartyOrderNo.MaxLength = 20
        Me.TxtPartyOrderNo.Name = "TxtPartyOrderNo"
        Me.TxtPartyOrderNo.Size = New System.Drawing.Size(126, 18)
        Me.TxtPartyOrderNo.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(518, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 16)
        Me.Label9.TabIndex = 706
        Me.Label9.Text = "Party Order No."
        '
        'TxtOrderCancelDate
        '
        Me.TxtOrderCancelDate.AgMandatory = False
        Me.TxtOrderCancelDate.AgMasterHelp = True
        Me.TxtOrderCancelDate.AgNumberLeftPlaces = 8
        Me.TxtOrderCancelDate.AgNumberNegetiveAllow = False
        Me.TxtOrderCancelDate.AgNumberRightPlaces = 2
        Me.TxtOrderCancelDate.AgPickFromLastValue = False
        Me.TxtOrderCancelDate.AgRowFilter = ""
        Me.TxtOrderCancelDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOrderCancelDate.AgSelectedValue = Nothing
        Me.TxtOrderCancelDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOrderCancelDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtOrderCancelDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOrderCancelDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOrderCancelDate.Location = New System.Drawing.Point(853, 24)
        Me.TxtOrderCancelDate.MaxLength = 20
        Me.TxtOrderCancelDate.Name = "TxtOrderCancelDate"
        Me.TxtOrderCancelDate.Size = New System.Drawing.Size(104, 18)
        Me.TxtOrderCancelDate.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(754, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 16)
        Me.Label10.TabIndex = 712
        Me.Label10.Text = "Cancel Date"
        '
        'TxtDeliveryDate
        '
        Me.TxtDeliveryDate.AgMandatory = False
        Me.TxtDeliveryDate.AgMasterHelp = True
        Me.TxtDeliveryDate.AgNumberLeftPlaces = 8
        Me.TxtDeliveryDate.AgNumberNegetiveAllow = False
        Me.TxtDeliveryDate.AgNumberRightPlaces = 2
        Me.TxtDeliveryDate.AgPickFromLastValue = False
        Me.TxtDeliveryDate.AgRowFilter = ""
        Me.TxtDeliveryDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDeliveryDate.AgSelectedValue = Nothing
        Me.TxtDeliveryDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDeliveryDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtDeliveryDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDeliveryDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDeliveryDate.Location = New System.Drawing.Point(625, 24)
        Me.TxtDeliveryDate.MaxLength = 20
        Me.TxtDeliveryDate.Name = "TxtDeliveryDate"
        Me.TxtDeliveryDate.Size = New System.Drawing.Size(126, 18)
        Me.TxtDeliveryDate.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(518, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 16)
        Me.Label11.TabIndex = 710
        Me.Label11.Text = "Delivery Date"
        '
        'TPExport
        '
        Me.TPExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TPExport.Controls.Add(Me.TxtPriceMode)
        Me.TPExport.Controls.Add(Me.LblPriceMode)
        Me.TPExport.Controls.Add(Me.TxtBankAddressBuyer)
        Me.TPExport.Controls.Add(Me.LblBankAddressBuyer)
        Me.TPExport.Controls.Add(Me.TxtBankNameBuyer)
        Me.TPExport.Controls.Add(Me.LblBankNameBuyer)
        Me.TPExport.Controls.Add(Me.TxtBankAcNoBuyer)
        Me.TPExport.Controls.Add(Me.LblBankAcNoBuyer)
        Me.TPExport.Controls.Add(Me.TxtShipmentThrough)
        Me.TPExport.Controls.Add(Me.LblShipmentThrough)
        Me.TPExport.Controls.Add(Me.TxtPlaceOfReceipt)
        Me.TPExport.Controls.Add(Me.LblPlaceOfReceipt)
        Me.TPExport.Controls.Add(Me.TxtPreCarriageBy)
        Me.TPExport.Controls.Add(Me.LblPreCariageBy)
        Me.TPExport.Controls.Add(Me.TxtCurrency)
        Me.TPExport.Controls.Add(Me.Label28)
        Me.TPExport.Controls.Add(Me.TxtFinalPlaceOfDelivery)
        Me.TPExport.Controls.Add(Me.Label17)
        Me.TPExport.Controls.Add(Me.TxtDestinationCountry)
        Me.TPExport.Controls.Add(Me.Label16)
        Me.TPExport.Controls.Add(Me.TxtDestinationPort)
        Me.TPExport.Controls.Add(Me.Label15)
        Me.TPExport.Location = New System.Drawing.Point(4, 22)
        Me.TPExport.Name = "TPExport"
        Me.TPExport.Size = New System.Drawing.Size(972, 150)
        Me.TPExport.TabIndex = 1
        Me.TPExport.Text = "Export Detail"
        '
        'TxtPriceMode
        '
        Me.TxtPriceMode.AgMandatory = False
        Me.TxtPriceMode.AgMasterHelp = True
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
        Me.TxtPriceMode.Location = New System.Drawing.Point(657, 87)
        Me.TxtPriceMode.MaxLength = 50
        Me.TxtPriceMode.Name = "TxtPriceMode"
        Me.TxtPriceMode.Size = New System.Drawing.Size(298, 18)
        Me.TxtPriceMode.TabIndex = 730
        '
        'LblPriceMode
        '
        Me.LblPriceMode.AutoSize = True
        Me.LblPriceMode.BackColor = System.Drawing.Color.Transparent
        Me.LblPriceMode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPriceMode.Location = New System.Drawing.Point(499, 88)
        Me.LblPriceMode.Name = "LblPriceMode"
        Me.LblPriceMode.Size = New System.Drawing.Size(74, 16)
        Me.LblPriceMode.TabIndex = 731
        Me.LblPriceMode.Text = "Price Mode"
        '
        'TxtBankAddressBuyer
        '
        Me.TxtBankAddressBuyer.AgMandatory = False
        Me.TxtBankAddressBuyer.AgMasterHelp = True
        Me.TxtBankAddressBuyer.AgNumberLeftPlaces = 8
        Me.TxtBankAddressBuyer.AgNumberNegetiveAllow = False
        Me.TxtBankAddressBuyer.AgNumberRightPlaces = 2
        Me.TxtBankAddressBuyer.AgPickFromLastValue = False
        Me.TxtBankAddressBuyer.AgRowFilter = ""
        Me.TxtBankAddressBuyer.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBankAddressBuyer.AgSelectedValue = Nothing
        Me.TxtBankAddressBuyer.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBankAddressBuyer.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBankAddressBuyer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBankAddressBuyer.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBankAddressBuyer.Location = New System.Drawing.Point(657, 67)
        Me.TxtBankAddressBuyer.MaxLength = 50
        Me.TxtBankAddressBuyer.Name = "TxtBankAddressBuyer"
        Me.TxtBankAddressBuyer.Size = New System.Drawing.Size(298, 18)
        Me.TxtBankAddressBuyer.TabIndex = 728
        '
        'LblBankAddressBuyer
        '
        Me.LblBankAddressBuyer.AutoSize = True
        Me.LblBankAddressBuyer.BackColor = System.Drawing.Color.Transparent
        Me.LblBankAddressBuyer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBankAddressBuyer.Location = New System.Drawing.Point(499, 68)
        Me.LblBankAddressBuyer.Name = "LblBankAddressBuyer"
        Me.LblBankAddressBuyer.Size = New System.Drawing.Size(145, 16)
        Me.LblBankAddressBuyer.TabIndex = 729
        Me.LblBankAddressBuyer.Text = "Bank Address Of Buyer"
        '
        'TxtBankNameBuyer
        '
        Me.TxtBankNameBuyer.AgMandatory = False
        Me.TxtBankNameBuyer.AgMasterHelp = True
        Me.TxtBankNameBuyer.AgNumberLeftPlaces = 8
        Me.TxtBankNameBuyer.AgNumberNegetiveAllow = False
        Me.TxtBankNameBuyer.AgNumberRightPlaces = 2
        Me.TxtBankNameBuyer.AgPickFromLastValue = False
        Me.TxtBankNameBuyer.AgRowFilter = ""
        Me.TxtBankNameBuyer.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBankNameBuyer.AgSelectedValue = Nothing
        Me.TxtBankNameBuyer.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBankNameBuyer.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBankNameBuyer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBankNameBuyer.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBankNameBuyer.Location = New System.Drawing.Point(657, 47)
        Me.TxtBankNameBuyer.MaxLength = 50
        Me.TxtBankNameBuyer.Name = "TxtBankNameBuyer"
        Me.TxtBankNameBuyer.Size = New System.Drawing.Size(298, 18)
        Me.TxtBankNameBuyer.TabIndex = 726
        '
        'LblBankNameBuyer
        '
        Me.LblBankNameBuyer.AutoSize = True
        Me.LblBankNameBuyer.BackColor = System.Drawing.Color.Transparent
        Me.LblBankNameBuyer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBankNameBuyer.Location = New System.Drawing.Point(499, 48)
        Me.LblBankNameBuyer.Name = "LblBankNameBuyer"
        Me.LblBankNameBuyer.Size = New System.Drawing.Size(131, 16)
        Me.LblBankNameBuyer.TabIndex = 727
        Me.LblBankNameBuyer.Text = "Bank Name Of Buyer"
        '
        'TxtBankAcNoBuyer
        '
        Me.TxtBankAcNoBuyer.AgMandatory = False
        Me.TxtBankAcNoBuyer.AgMasterHelp = True
        Me.TxtBankAcNoBuyer.AgNumberLeftPlaces = 8
        Me.TxtBankAcNoBuyer.AgNumberNegetiveAllow = False
        Me.TxtBankAcNoBuyer.AgNumberRightPlaces = 2
        Me.TxtBankAcNoBuyer.AgPickFromLastValue = False
        Me.TxtBankAcNoBuyer.AgRowFilter = ""
        Me.TxtBankAcNoBuyer.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBankAcNoBuyer.AgSelectedValue = Nothing
        Me.TxtBankAcNoBuyer.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBankAcNoBuyer.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBankAcNoBuyer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBankAcNoBuyer.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBankAcNoBuyer.Location = New System.Drawing.Point(657, 27)
        Me.TxtBankAcNoBuyer.MaxLength = 50
        Me.TxtBankAcNoBuyer.Name = "TxtBankAcNoBuyer"
        Me.TxtBankAcNoBuyer.Size = New System.Drawing.Size(298, 18)
        Me.TxtBankAcNoBuyer.TabIndex = 724
        '
        'LblBankAcNoBuyer
        '
        Me.LblBankAcNoBuyer.AutoSize = True
        Me.LblBankAcNoBuyer.BackColor = System.Drawing.Color.Transparent
        Me.LblBankAcNoBuyer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBankAcNoBuyer.Location = New System.Drawing.Point(499, 28)
        Me.LblBankAcNoBuyer.Name = "LblBankAcNoBuyer"
        Me.LblBankAcNoBuyer.Size = New System.Drawing.Size(137, 16)
        Me.LblBankAcNoBuyer.TabIndex = 725
        Me.LblBankAcNoBuyer.Text = "Bank A/c No Of Buyer"
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
        Me.TxtShipmentThrough.Location = New System.Drawing.Point(657, 7)
        Me.TxtShipmentThrough.MaxLength = 50
        Me.TxtShipmentThrough.Name = "TxtShipmentThrough"
        Me.TxtShipmentThrough.Size = New System.Drawing.Size(298, 18)
        Me.TxtShipmentThrough.TabIndex = 722
        '
        'LblShipmentThrough
        '
        Me.LblShipmentThrough.AutoSize = True
        Me.LblShipmentThrough.BackColor = System.Drawing.Color.Transparent
        Me.LblShipmentThrough.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShipmentThrough.Location = New System.Drawing.Point(499, 8)
        Me.LblShipmentThrough.Name = "LblShipmentThrough"
        Me.LblShipmentThrough.Size = New System.Drawing.Size(113, 16)
        Me.LblShipmentThrough.TabIndex = 723
        Me.LblShipmentThrough.Text = "Shipment Through"
        '
        'TxtPlaceOfReceipt
        '
        Me.TxtPlaceOfReceipt.AgMandatory = False
        Me.TxtPlaceOfReceipt.AgMasterHelp = True
        Me.TxtPlaceOfReceipt.AgNumberLeftPlaces = 8
        Me.TxtPlaceOfReceipt.AgNumberNegetiveAllow = False
        Me.TxtPlaceOfReceipt.AgNumberRightPlaces = 2
        Me.TxtPlaceOfReceipt.AgPickFromLastValue = False
        Me.TxtPlaceOfReceipt.AgRowFilter = ""
        Me.TxtPlaceOfReceipt.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPlaceOfReceipt.AgSelectedValue = Nothing
        Me.TxtPlaceOfReceipt.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPlaceOfReceipt.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPlaceOfReceipt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPlaceOfReceipt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPlaceOfReceipt.Location = New System.Drawing.Point(157, 106)
        Me.TxtPlaceOfReceipt.MaxLength = 50
        Me.TxtPlaceOfReceipt.Name = "TxtPlaceOfReceipt"
        Me.TxtPlaceOfReceipt.Size = New System.Drawing.Size(298, 18)
        Me.TxtPlaceOfReceipt.TabIndex = 720
        '
        'LblPlaceOfReceipt
        '
        Me.LblPlaceOfReceipt.AutoSize = True
        Me.LblPlaceOfReceipt.BackColor = System.Drawing.Color.Transparent
        Me.LblPlaceOfReceipt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPlaceOfReceipt.Location = New System.Drawing.Point(19, 107)
        Me.LblPlaceOfReceipt.Name = "LblPlaceOfReceipt"
        Me.LblPlaceOfReceipt.Size = New System.Drawing.Size(106, 16)
        Me.LblPlaceOfReceipt.TabIndex = 721
        Me.LblPlaceOfReceipt.Text = "Place Of Receipt"
        '
        'TxtPreCarriageBy
        '
        Me.TxtPreCarriageBy.AgMandatory = False
        Me.TxtPreCarriageBy.AgMasterHelp = True
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
        Me.TxtPreCarriageBy.Location = New System.Drawing.Point(157, 86)
        Me.TxtPreCarriageBy.MaxLength = 50
        Me.TxtPreCarriageBy.Name = "TxtPreCarriageBy"
        Me.TxtPreCarriageBy.Size = New System.Drawing.Size(298, 18)
        Me.TxtPreCarriageBy.TabIndex = 718
        '
        'LblPreCariageBy
        '
        Me.LblPreCariageBy.AutoSize = True
        Me.LblPreCariageBy.BackColor = System.Drawing.Color.Transparent
        Me.LblPreCariageBy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPreCariageBy.Location = New System.Drawing.Point(19, 87)
        Me.LblPreCariageBy.Name = "LblPreCariageBy"
        Me.LblPreCariageBy.Size = New System.Drawing.Size(96, 16)
        Me.LblPreCariageBy.TabIndex = 719
        Me.LblPreCariageBy.Text = "PreCarriage By"
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
        Me.TxtCurrency.Location = New System.Drawing.Point(157, 6)
        Me.TxtCurrency.MaxLength = 20
        Me.TxtCurrency.Name = "TxtCurrency"
        Me.TxtCurrency.Size = New System.Drawing.Size(91, 18)
        Me.TxtCurrency.TabIndex = 17
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(19, 7)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(60, 16)
        Me.Label28.TabIndex = 717
        Me.Label28.Text = "Currency"
        '
        'TxtFinalPlaceOfDelivery
        '
        Me.TxtFinalPlaceOfDelivery.AgMandatory = False
        Me.TxtFinalPlaceOfDelivery.AgMasterHelp = True
        Me.TxtFinalPlaceOfDelivery.AgNumberLeftPlaces = 8
        Me.TxtFinalPlaceOfDelivery.AgNumberNegetiveAllow = False
        Me.TxtFinalPlaceOfDelivery.AgNumberRightPlaces = 2
        Me.TxtFinalPlaceOfDelivery.AgPickFromLastValue = False
        Me.TxtFinalPlaceOfDelivery.AgRowFilter = ""
        Me.TxtFinalPlaceOfDelivery.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFinalPlaceOfDelivery.AgSelectedValue = Nothing
        Me.TxtFinalPlaceOfDelivery.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFinalPlaceOfDelivery.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFinalPlaceOfDelivery.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFinalPlaceOfDelivery.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFinalPlaceOfDelivery.Location = New System.Drawing.Point(157, 66)
        Me.TxtFinalPlaceOfDelivery.MaxLength = 50
        Me.TxtFinalPlaceOfDelivery.Name = "TxtFinalPlaceOfDelivery"
        Me.TxtFinalPlaceOfDelivery.Size = New System.Drawing.Size(298, 18)
        Me.TxtFinalPlaceOfDelivery.TabIndex = 21
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(19, 67)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(136, 16)
        Me.Label17.TabIndex = 714
        Me.Label17.Text = "Final Place of Delivery"
        '
        'TxtDestinationCountry
        '
        Me.TxtDestinationCountry.AgMandatory = False
        Me.TxtDestinationCountry.AgMasterHelp = True
        Me.TxtDestinationCountry.AgNumberLeftPlaces = 8
        Me.TxtDestinationCountry.AgNumberNegetiveAllow = False
        Me.TxtDestinationCountry.AgNumberRightPlaces = 2
        Me.TxtDestinationCountry.AgPickFromLastValue = False
        Me.TxtDestinationCountry.AgRowFilter = ""
        Me.TxtDestinationCountry.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDestinationCountry.AgSelectedValue = Nothing
        Me.TxtDestinationCountry.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDestinationCountry.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDestinationCountry.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDestinationCountry.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDestinationCountry.Location = New System.Drawing.Point(157, 46)
        Me.TxtDestinationCountry.MaxLength = 0
        Me.TxtDestinationCountry.Name = "TxtDestinationCountry"
        Me.TxtDestinationCountry.Size = New System.Drawing.Size(298, 18)
        Me.TxtDestinationCountry.TabIndex = 20
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(19, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(122, 16)
        Me.Label16.TabIndex = 712
        Me.Label16.Text = "Destination Country"
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
        Me.TxtDestinationPort.Location = New System.Drawing.Point(157, 26)
        Me.TxtDestinationPort.MaxLength = 0
        Me.TxtDestinationPort.Name = "TxtDestinationPort"
        Me.TxtDestinationPort.Size = New System.Drawing.Size(298, 18)
        Me.TxtDestinationPort.TabIndex = 19
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(19, 27)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(101, 16)
        Me.Label15.TabIndex = 710
        Me.Label15.Text = "Destination Port"
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
        Me.Panel1.Location = New System.Drawing.Point(2, 380)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(979, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblStockTotalMeasure
        '
        Me.LblStockTotalMeasure.AutoSize = True
        Me.LblStockTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStockTotalMeasure.ForeColor = System.Drawing.Color.Black
        Me.LblStockTotalMeasure.Location = New System.Drawing.Point(656, 4)
        Me.LblStockTotalMeasure.Name = "LblStockTotalMeasure"
        Me.LblStockTotalMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblStockTotalMeasure.TabIndex = 712
        Me.LblStockTotalMeasure.Text = "."
        '
        'LblTotalStockMeasureText
        '
        Me.LblTotalStockMeasureText.AutoSize = True
        Me.LblTotalStockMeasureText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalStockMeasureText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalStockMeasureText.Location = New System.Drawing.Point(507, 4)
        Me.LblTotalStockMeasureText.Name = "LblTotalStockMeasureText"
        Me.LblTotalStockMeasureText.Size = New System.Drawing.Size(145, 16)
        Me.LblTotalStockMeasureText.TabIndex = 711
        Me.LblTotalStockMeasureText.Text = "Total Stock Measure :"
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
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(271, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(106, 16)
        Me.Label33.TabIndex = 665
        Me.Label33.Text = "Total Measure :"
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
        Me.LblTotalAmountText.Size = New System.Drawing.Size(101, 16)
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
        Me.LblTotalQtyText.Size = New System.Drawing.Size(73, 16)
        Me.LblTotalQtyText.TabIndex = 659
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(6, 233)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(973, 167)
        Me.Pnl1.TabIndex = 28
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(114, 111)
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
        Me.TxtTermsAndConditions.Location = New System.Drawing.Point(8, 435)
        Me.TxtTermsAndConditions.MaxLength = 20
        Me.TxtTermsAndConditions.Multiline = True
        Me.TxtTermsAndConditions.Name = "TxtTermsAndConditions"
        Me.TxtTermsAndConditions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TxtTermsAndConditions.Size = New System.Drawing.Size(465, 124)
        Me.TxtTermsAndConditions.TabIndex = 29
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnlCalcGrid.Location = New System.Drawing.Point(597, 408)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(383, 156)
        Me.PnlCalcGrid.TabIndex = 694
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(6, 416)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(115, 16)
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
        Me.TxtStructure.Location = New System.Drawing.Point(853, 125)
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
        Me.Label25.Location = New System.Drawing.Point(765, 126)
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
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(625, 125)
        Me.TxtSalesTaxGroupParty.MaxLength = 20
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(134, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 15
        Me.TxtSalesTaxGroupParty.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(518, 126)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(105, 16)
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
        Me.TPShipping.Size = New System.Drawing.Size(972, 150)
        Me.TPShipping.TabIndex = 2
        Me.TPShipping.Text = "Shipping Detail"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgMandatory = True
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
        Me.TxtRemarks.Location = New System.Drawing.Point(625, 84)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(332, 18)
        Me.TxtRemarks.TabIndex = 15
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(518, 84)
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
        Me.TxtBillingType.Location = New System.Drawing.Point(625, 44)
        Me.TxtBillingType.MaxLength = 20
        Me.TxtBillingType.Name = "TxtBillingType"
        Me.TxtBillingType.Size = New System.Drawing.Size(126, 18)
        Me.TxtBillingType.TabIndex = 726
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(518, 44)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(64, 16)
        Me.Label32.TabIndex = 727
        Me.Label32.Text = "Billing On"
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
        Me.TxtAgent.Location = New System.Drawing.Point(625, 64)
        Me.TxtAgent.MaxLength = 0
        Me.TxtAgent.Name = "TxtAgent"
        Me.TxtAgent.Size = New System.Drawing.Size(332, 18)
        Me.TxtAgent.TabIndex = 728
        '
        'LblAgent
        '
        Me.LblAgent.AutoSize = True
        Me.LblAgent.BackColor = System.Drawing.Color.Transparent
        Me.LblAgent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAgent.Location = New System.Drawing.Point(518, 64)
        Me.LblAgent.Name = "LblAgent"
        Me.LblAgent.Size = New System.Drawing.Size(42, 16)
        Me.LblAgent.TabIndex = 729
        Me.LblAgent.Text = "Agent"
        '
        'TxtPriority
        '
        Me.TxtPriority.AgMandatory = False
        Me.TxtPriority.AgMasterHelp = False
        Me.TxtPriority.AgNumberLeftPlaces = 0
        Me.TxtPriority.AgNumberNegetiveAllow = False
        Me.TxtPriority.AgNumberRightPlaces = 0
        Me.TxtPriority.AgPickFromLastValue = False
        Me.TxtPriority.AgRowFilter = ""
        Me.TxtPriority.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPriority.AgSelectedValue = Nothing
        Me.TxtPriority.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPriority.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPriority.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPriority.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPriority.Location = New System.Drawing.Point(853, 44)
        Me.TxtPriority.MaxLength = 20
        Me.TxtPriority.Name = "TxtPriority"
        Me.TxtPriority.Size = New System.Drawing.Size(104, 18)
        Me.TxtPriority.TabIndex = 728
        '
        'LblPriority
        '
        Me.LblPriority.AutoSize = True
        Me.LblPriority.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPriority.Location = New System.Drawing.Point(754, 44)
        Me.LblPriority.Name = "LblPriority"
        Me.LblPriority.Size = New System.Drawing.Size(85, 16)
        Me.LblPriority.TabIndex = 729
        Me.LblPriority.Text = "Order Priority"
        '
        'TempSaleOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.TxtTermsAndConditions)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "TempSaleOrder"
        Me.Text = "Template Sale Order"
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.TxtTermsAndConditions, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
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
        Me.TPExport.ResumeLayout(False)
        Me.TPExport.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TPShipping.ResumeLayout(False)
        Me.TPShipping.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents Label5 As System.Windows.Forms.Label
    Protected WithEvents TxtOrderCancelDate As AgControls.AgTextBox
    Protected WithEvents Label10 As System.Windows.Forms.Label
    Protected WithEvents TxtDeliveryDate As AgControls.AgTextBox
    Protected WithEvents Label11 As System.Windows.Forms.Label
    Protected WithEvents TxtPartyOrderDate As AgControls.AgTextBox
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents TxtPartyOrderNo As AgControls.AgTextBox
    Protected WithEvents Label9 As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToParty As AgControls.AgTextBox
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
    Protected WithEvents TPExport As System.Windows.Forms.TabPage
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents TxtDestinationCountry As AgControls.AgTextBox
    Protected WithEvents Label16 As System.Windows.Forms.Label
    Protected WithEvents TxtDestinationPort As AgControls.AgTextBox
    Protected WithEvents Label15 As System.Windows.Forms.Label
    Protected WithEvents Label13 As System.Windows.Forms.Label
    Protected WithEvents TxtFinalPlaceOfDelivery As AgControls.AgTextBox
    Protected WithEvents Label17 As System.Windows.Forms.Label
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
    Protected WithEvents TxtPreCarriageBy As AgControls.AgTextBox
    Protected WithEvents LblPreCariageBy As System.Windows.Forms.Label
    Protected WithEvents TxtBankAddressBuyer As AgControls.AgTextBox
    Protected WithEvents LblBankAddressBuyer As System.Windows.Forms.Label
    Protected WithEvents TxtBankNameBuyer As AgControls.AgTextBox
    Protected WithEvents LblBankNameBuyer As System.Windows.Forms.Label
    Protected WithEvents TxtBankAcNoBuyer As AgControls.AgTextBox
    Protected WithEvents LblBankAcNoBuyer As System.Windows.Forms.Label
    Protected WithEvents TxtShipmentThrough As AgControls.AgTextBox
    Protected WithEvents LblShipmentThrough As System.Windows.Forms.Label
    Protected WithEvents TxtPlaceOfReceipt As AgControls.AgTextBox
    Protected WithEvents LblPlaceOfReceipt As System.Windows.Forms.Label
    Protected WithEvents TxtPriceMode As AgControls.AgTextBox
    Protected WithEvents LblPriceMode As System.Windows.Forms.Label
    Protected WithEvents Label24 As System.Windows.Forms.Label
    Protected WithEvents LblPriority As System.Windows.Forms.Label
    Protected WithEvents TxtPriority As AgControls.AgTextBox
    Protected WithEvents LblStockTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents LblTotalStockMeasureText As System.Windows.Forms.Label
#End Region

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 200, 0, Col1Item, True, False, False)
            .AddAgTextColumn(Dgl1, Col1PartySKU, 110, 50, Col1PartySKU, True, False, False)
            .AddAgTextColumn(Dgl1, Col1PartyUPC, 110, 20, Col1PartyUPC, True, False, False)
            .AddAgNumberColumn(Dgl1, Col1Qty, 100, 8, 4, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True, False)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 100, 8, 4, False, Col1TotalMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 100, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, True, True, True)
            .AddAgTextColumn(Dgl1, Col1SalesTaxGroup, 70, 0, Col1SalesTaxGroup, False, False, False)
            .AddAgTextColumn(Dgl1, Col1xPartySKU, 270, 50, Col1xPartySKU, False, False, False)
            .AddAgTextColumn(Dgl1, Col1xPartyUPC, 270, 50, Col1xPartyUPC, False, False, False)

            'Code By Akash On Date 15-6-2011
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 100, 8, 4, False, Col1MeasurePerPcs, True, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 100, 50, Col1MeasureUnit, False, False, False)
            .AddAgNumberColumn(Dgl1, Col1ShippedQty, 100, 8, 4, False, Col1ShippedQty, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ShippedMeasure, 100, 8, 4, False, Col1ShippedMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdOrdQty, 100, 8, 4, False, Col1ProdOrdQty, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdOrdMeasure, 100, 8, 4, False, Col1ProdOrdMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdPlanQty, 100, 8, 4, False, Col1ProdPlanQty, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdPlanMeasure, 100, 8, 4, False, Col1ProdPlanMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1PurchQty, 100, 8, 4, False, Col1PurchQty, False, False, True)
            .AddAgNumberColumn(Dgl1, Col1PurchMeasure, 100, 8, 4, False, Col1PurchMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdIssQty, 100, 8, 4, False, Col1ProdIssQty, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdIssMeasure, 100, 8, 4, False, Col1ProdIssMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdRecQty, 100, 8, 4, False, Col1ProdRecQty, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1ProdRecMeasure, 100, 8, 4, False, Col1ProdRecMeasure, False, True, True)


            .AddAgNumberColumn(Dgl1, Col1StockMeasurePerPcs, 100, 8, 4, False, Col1StockMeasurePerPcs, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1StockTotalMeasure, 100, 8, 4, False, Col1StockTotalMeasure, False, True, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Panel1.Anchor = Dgl1.Anchor

        Dgl1.AgSkipReadOnlyColumns = True


        AgCalcGrid1.Ini_Grid(mSearchCode)

        AgCalcGrid1.AgLineGrid = Dgl1
        AgCalcGrid1.AgLineGridMandatoryColumn = Dgl1.Columns(Col1Item).Index
        AgCalcGrid1.AgLineGridGrossColumn = Dgl1.Columns(Col1Amount).Index
        AgCalcGrid1.AgLineGridPostingGroupSalesTaxProd = Dgl1.Columns(Col1SalesTaxGroup).Index

        FrmSaleOrder_BaseFunction_FIniList()
        'Ini_List()
    End Sub


    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        'Changed By Akash On Date 15-6-2011 For Totals
        mQry = "UPDATE SaleOrder_Log " & _
                "   SET " & _
                "   SaleToParty = " & AgL.Chk_Text(TxtSaleToParty.AgSelectedValue) & ", " & _
                "	SaleToPartyName = " & AgL.Chk_Text(TxtSaleToParty.Text) & ", " & _
                "	SaleToPartyAdd1 = " & AgL.Chk_Text(TxtSaleToPartyAdd1.Text) & ", " & _
                "	SaleToPartyAdd2 = " & AgL.Chk_Text(TxtSaleToPartyAdd2.Text) & ", " & _
                "	SaleToPartyCity = " & AgL.Chk_Text(TxtSaleToPartyCity.AgSelectedValue) & ", " & _
                "	SaleToPartyCityName = " & AgL.Chk_Text(TxtSaleToPartyCity.Text) & ", " & _
                "	SaleToPartyState = " & AgL.Chk_Text(TxtSaleToPartyState.Text) & ", " & _
                "	SaleToPartyCountry = " & AgL.Chk_Text(TxtSaleToPartyCountry.Text) & ", " & _
                "	Currency = " & AgL.Chk_Text(TxtCurrency.AgSelectedValue) & ", " & _
                "	ShipToPartyName = " & AgL.Chk_Text(TxtShipToParty.Text) & ", " & _
                "	ShipToPartyAdd1 = " & AgL.Chk_Text(TxtShipToPartyAdd1.Text) & ", " & _
                "	ShipToPartyAdd2 = " & AgL.Chk_Text(TxtShipToPartyAdd2.Text) & ", " & _
                "	ShipToPartyCity = " & AgL.Chk_Text(TxtShipToPartyCity.AgSelectedValue) & ", " & _
                "	ShipToPartyCityName = " & AgL.Chk_Text(TxtShipToPartyCity.Text) & ", " & _
                "	ShipToPartyState = " & AgL.Chk_Text(TxtShipToPartyState.Text) & ", " & _
                "	ShipToPartyCountry = " & AgL.Chk_Text(TxtShipToPartyCountry.Text) & ", " & _
                "	SalesTaxGroupParty = " & AgL.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & ", " & _
                "	PartyOrderNo = " & AgL.Chk_Text(TxtPartyOrderNo.Text) & ", " & _
                "	PartyOrderDate = " & AgL.Chk_Text(TxtPartyOrderDate.Text) & ", " & _
                "	PartyDeliveryDate =" & AgL.Chk_Text(TxtDeliveryDate.Text) & ", " & _
                "	PartyOrderCancelDate =" & AgL.Chk_Text(TxtOrderCancelDate.Text) & ", " & _
                "	DestinationPort = " & AgL.Chk_Text(TxtDestinationPort.AgSelectedValue) & ", " & _
                "	FinalPlaceOfDelivery = " & AgL.Chk_Text(TxtFinalPlaceOfDelivery.Text) & ", " & _
                "	TermsAndConditions = " & AgL.Chk_Text(TxtTermsAndConditions.Text) & ", " & _
                "   BillingType = " & AgL.Chk_Text(TxtBillingType.AgSelectedValue) & ", " & _
                "	Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                "	Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                "   TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                "   TotalAmount = " & Val(LblTotalAmount.Text) & ", " & _
                "   TotalMeasure = " & Val(LblTotalMeasure.Text) & ", " & _
                "   Priority = " & Val(TxtPriority.AgSelectedValue) & ", " & _
                "   PreCarriageBy = " & AgL.Chk_Text(TxtPreCarriageBy.Text) & ", " & _
                "   PlaceOfReceipt = " & AgL.Chk_Text(TxtPlaceOfReceipt.Text) & ", " & _
                "   ShipmentThrough = " & AgL.Chk_Text(TxtShipmentThrough.Text) & ", " & _
                "   BankAcNoBuyer = " & AgL.Chk_Text(TxtBankAcNoBuyer.Text) & ", " & _
                "   BankNameBuyer = " & AgL.Chk_Text(TxtBankNameBuyer.Text) & ", " & _
                "   BankAddressBuyer = " & AgL.Chk_Text(TxtBankAddressBuyer.Text) & ", " & _
                "   PriceMode = " & AgL.Chk_Text(TxtPriceMode.Text) & ", " & _
                "   StockTotalMeasure = " & Val(LblStockTotalMeasure.Text) & ", " & _
                "   Agent = " & AgL.Chk_Text(TxtAgent.AgSelectedValue) & " " & _
                "   Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        AgCalcGrid1.Save_TransFooter(mInternalCode, Conn, Cmd, SearchCode)

        mQry = "Delete From SaleOrderDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                mQry = "INSERT INTO SaleOrderDetail_Log (DocId, Sr, Item, SalesTaxGroupItem, Qty, " & _
                        " Unit, Rate, Amount, UID, PartySKU, PartyUPC, " & _
                        " MeasurePerPcs, TotalMeasure, MeasureUnit, ShippedQty, ShippedMeasure,  " & _
                        " ProdOrdQty, ProdOrdMeasure, ProdPlanQty, ProdPlanMeasure, PurchQty, " & _
                        " PurchMeasure, ProdIssQty, ProdIssMeasure, ProdRecQty, ProdRecMeasure, " & _
                        " StockMeasurePerPcs, StockTotalMeasure) " & _
                        " VALUES (" & AgL.Chk_Text(mInternalCode) & ", " & mSr & ", " & _
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
                        " " & Val(Dgl1.Item(Col1ShippedMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ProdOrdQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ProdOrdMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ProdPlanQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ProdPlanMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1PurchQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1PurchMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ProdIssQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ProdIssMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ProdRecQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1ProdRecMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1StockMeasurePerPcs, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1StockTotalMeasure, I).Value) & " " & _
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
                " From SaleOrder H " & _
                " Left Join SeaPort SP On H.DestinationPort = SP.Code " & _
                " Left Join City C On SP.City = C.CityCode " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.*, C.Country as DestinationCountry " & _
                " From SaleOrder_Log H " & _
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

                TxtSaleToParty.AgSelectedValue = AgL.XNull(.Rows(0)("SaleToParty"))
                TxtSaleToParty.Text = AgL.XNull(.Rows(0)("SaleToPartyName"))
                TxtSaleToPartyAdd1.Text = AgL.XNull(.Rows(0)("SaleToPartyAdd1"))
                TxtSaleToPartyAdd2.Text = AgL.XNull(.Rows(0)("SaleToPartyAdd2"))
                TxtSaleToPartyCity.AgSelectedValue = AgL.XNull(.Rows(0)("SaleToPartyCity"))
                TxtSaleToPartyState.Text = AgL.XNull(.Rows(0)("SaleToPartyState"))
                TxtSaleToPartyCountry.Text = AgL.XNull(.Rows(0)("SaleToPartyCountry"))
                TxtShipToParty.Text = AgL.XNull(.Rows(0)("ShipToPartyName"))
                TxtShipToPartyAdd1.Text = AgL.XNull(.Rows(0)("ShipToPartyAdd1"))
                TxtShipToPartyAdd2.Text = AgL.XNull(.Rows(0)("ShipToPartyAdd2"))
                TxtShipToPartyCity.AgSelectedValue = AgL.XNull(.Rows(0)("ShipToPartyCity"))
                TxtShipToPartyState.Text = AgL.XNull(.Rows(0)("ShipToPartyState"))
                TxtShipToPartyCountry.Text = AgL.XNull(.Rows(0)("ShipToPartyCountry"))
                TxtCurrency.AgSelectedValue = AgL.XNull(.Rows(0)("Currency"))
                TxtPartyOrderNo.Text = AgL.XNull(.Rows(0)("PartyOrderNo"))
                TxtPartyOrderDate.Text = AgL.XNull(.Rows(0)("PartyOrderDate"))
                TxtDeliveryDate.Text = AgL.XNull(.Rows(0)("PartyDeliveryDate"))
                TxtOrderCancelDate.Text = AgL.XNull(.Rows(0)("PartyOrderCancelDate"))
                TxtDestinationPort.AgSelectedValue = AgL.XNull(.Rows(0)("DestinationPort"))
                TxtDestinationCountry.Text = AgL.XNull(.Rows(0)("DestinationCountry"))
                TxtFinalPlaceOfDelivery.Text = AgL.XNull(.Rows(0)("FinalPlaceOfDelivery"))
                TxtTermsAndConditions.Text = AgL.XNull(.Rows(0)("TermsAndConditions"))
                TxtBillingType.AgSelectedValue = AgL.XNull(.Rows(0)("BillingType"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                TxtPriority.AgSelectedValue = IIf(AgL.VNull(.Rows(0)("Priority")) <> 0, AgL.VNull(.Rows(0)("Priority")), "")
                TxtPreCarriageBy.Text = AgL.XNull(.Rows(0)("PreCarriageBy"))
                TxtPlaceOfReceipt.Text = AgL.XNull(.Rows(0)("PlaceOfReceipt"))
                TxtShipmentThrough.Text = AgL.XNull(.Rows(0)("ShipmentThrough"))
                TxtBankAcNoBuyer.Text = AgL.XNull(.Rows(0)("BankAcNoBuyer"))
                TxtBankNameBuyer.Text = AgL.XNull(.Rows(0)("BankNameBuyer"))
                TxtBankAddressBuyer.Text = AgL.XNull(.Rows(0)("BankAddressBuyer"))
                TxtPriceMode.Text = AgL.XNull(.Rows(0)("PriceMode"))
                TxtAgent.AgSelectedValue = AgL.XNull(.Rows(0)("Agent"))

                'Code By Akash On Date 15-06-2011
                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))
                LblTotalMeasure.Text = AgL.VNull(.Rows(0)("TotalMeasure"))
                LblStockTotalMeasure.Text = AgL.VNull(.Rows(0)("StockTotalMeasure"))

                AgCalcGrid1.MoveRec_TransFooter(SearchCode)

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from SaleOrderDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from SaleOrderDetail_Log where UID = '" & SearchCode & "' Order By Sr"
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
                            Dgl1.Item(Col1PartySKU, I).Value = AgL.XNull(.Rows(I)("PartySKU"))
                            Dgl1.Item(Col1xPartySKU, I).Value = AgL.XNull(.Rows(I)("PartySKU"))
                            Dgl1.Item(Col1PartyUPC, I).Value = AgL.XNull(.Rows(I)("PartyUPC"))
                            Dgl1.Item(Col1xPartyUPC, I).Value = AgL.XNull(.Rows(I)("PartyUPC"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Rate, I).Value = AgL.VNull(.Rows(I)("Rate"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1Amount, I).Value = AgL.VNull(.Rows(I)("Amount"))
                            Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))

                            'Code By Akash On Date 15-6-2011
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                            Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1ShippedQty, I).Value = AgL.VNull(.Rows(I)("ShippedQty"))
                            Dgl1.Item(Col1ShippedMeasure, I).Value = AgL.VNull(.Rows(I)("ShippedMeasure"))
                            Dgl1.Item(Col1ProdOrdQty, I).Value = AgL.VNull(.Rows(I)("ProdOrdQty"))
                            Dgl1.Item(Col1ProdOrdMeasure, I).Value = AgL.VNull(.Rows(I)("ProdOrdMeasure"))
                            Dgl1.Item(Col1ProdPlanQty, I).Value = AgL.VNull(.Rows(I)("ProdPlanQty"))
                            Dgl1.Item(Col1ProdPlanMeasure, I).Value = AgL.VNull(.Rows(I)("ProdPlanMeasure"))
                            Dgl1.Item(Col1PurchQty, I).Value = AgL.VNull(.Rows(I)("PurchQty"))
                            Dgl1.Item(Col1PurchMeasure, I).Value = AgL.VNull(.Rows(I)("PurchMeasure"))
                            Dgl1.Item(Col1ProdIssQty, I).Value = AgL.VNull(.Rows(I)("ProdIssQty"))
                            Dgl1.Item(Col1ProdIssMeasure, I).Value = AgL.VNull(.Rows(I)("ProdIssMeasure"))
                            Dgl1.Item(Col1ProdRecQty, I).Value = AgL.VNull(.Rows(I)("ProdRecQty"))
                            Dgl1.Item(Col1ProdRecMeasure, I).Value = AgL.VNull(.Rows(I)("ProdRecMeasure"))

                            Dgl1.Item(Col1StockMeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("StockMeasurePerPcs"))
                            Dgl1.Item(Col1StockTotalMeasure, I).Value = AgL.VNull(.Rows(I)("StockTotalMeasure"))

                            Call AgCalcGrid1.MoveRec_TransLine(mSearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With
                Calculation()
                '-------------------------------------------------------------
            End If
        End With

    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgCalcGrid1.FrmType = Me.FrmType
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtShipToPartyCity.Validating
        Select Case sender.NAME
            Case TxtV_Type.Name
                TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                IniGrid()
            Case TxtShipToPartyCity.Name
                Validating_ShipToPartyCity(sender.AgSelectedValue)
        End Select
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
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        IniGrid()
        TabControl1.SelectedTab = TP1
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtSaleToParty.AgHelpDataSet(11, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.SaleToParty
        Dgl1.AgHelpDataSet(Col1Item, 4) = HelpDataSet.Item
        TxtSaleToPartyCity.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.City
        TxtShipToPartyCity.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.City
        TxtCurrency.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Currency
        TxtDestinationPort.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Port
        TxtStructure.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.AgStructure
        TxtSalesTaxGroupParty.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.SalesTaxGroupParty
        TxtBillingType.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.BillingType
        TxtStatus.AgHelpDataSet(0, GroupBox2.Top - 150, GroupBox2.Left) = HelpDataSet.Status
        TxtPriority.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Priority
        TxtAgent.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Agent
    End Sub

    Private Sub TxtSaleToParty_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSaleToParty.Validating, TxtPartyOrderNo.Validating, TxtV_Date.Validating
        Dim DrTemp As DataRow()
        Select Case sender.name
            Case TxtSaleToParty.Name
                If sender.text.ToString.Trim <> "" Then
                    If sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = sender.AgHelpDataSet.Tables(0).Select("SubCode = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                        TxtSaleToPartyAdd1.Text = AgL.XNull(DrTemp(0)("Add1"))
                        TxtSaleToPartyAdd2.Text = AgL.XNull(DrTemp(0)("Add2"))
                        TxtSaleToPartyCity.AgSelectedValue = AgL.XNull(DrTemp(0)("CityCode"))
                        TxtSaleToPartyState.Text = AgL.XNull(DrTemp(0)("State"))
                        TxtSaleToPartyCountry.Text = AgL.XNull(DrTemp(0)("Country"))
                        TxtCurrency.AgSelectedValue = AgL.XNull(DrTemp(0)("Currency"))
                        TxtDestinationPort.AgSelectedValue = AgL.XNull(DrTemp(0)("SeaPort"))
                        TxtDestinationCountry.Text = AgL.XNull(DrTemp(0)("DestinationCountry"))
                        TxtBankNameBuyer.Text = AgL.XNull(DrTemp(0)("BankName"))
                        TxtBankAddressBuyer.Text = AgL.XNull(DrTemp(0)("BankAddress"))
                        TxtBankAcNoBuyer.Text = AgL.XNull(DrTemp(0)("BankAcNo"))
                        'To Fill Export And Shipping Detail
                        Call ProcFillExportDetail(TxtSaleToParty.AgSelectedValue, TxtV_Date.Text)
                    End If
                Else
                    TxtSaleToPartyAdd1.Text = ""
                    TxtSaleToPartyAdd2.Text = ""
                    TxtSaleToPartyCity.AgSelectedValue = ""
                    TxtSaleToPartyState.Text = ""
                    TxtSaleToPartyCountry.Text = ""
                    TxtCurrency.AgSelectedValue = ""
                    TxtDestinationPort.AgSelectedValue = ""
                    TxtDestinationCountry.Text = ""
                    TxtBankNameBuyer.Text = ""
                    TxtBankAddressBuyer.Text = ""
                    TxtBankAcNoBuyer.Text = ""

                    TxtCurrency.AgSelectedValue = ""
                    TxtDestinationPort.AgSelectedValue = ""
                    TxtDestinationCountry.Text = ""
                    TxtFinalPlaceOfDelivery.Text = ""
                    TxtPreCarriageBy.Text = ""
                    TxtPlaceOfReceipt.Text = ""
                    TxtShipmentThrough.Text = ""
                    TxtBankAcNoBuyer.Text = ""
                    TxtBankNameBuyer.Text = ""
                    TxtBankAddressBuyer.Text = ""
                    TxtPriceMode.Text = ""
                    TxtShipToParty.Text = ""
                    TxtShipToPartyAdd1.Text = ""
                    TxtShipToPartyAdd2.Text = ""
                    TxtShipToPartyCity.AgSelectedValue = ""
                    TxtShipToPartyState.Text = ""
                    TxtShipToPartyCountry.Text = ""
                End If

            Case TxtPartyOrderNo.Name
                If Topctrl1.Mode = "Add" Then
                    mQry = " SELECT COUNT(*) FROM SaleOrder  WHERE PartyOrderNo  = '" & TxtPartyOrderNo.Text & "' AND SaleToParty ='" & TxtSaleToParty.AgSelectedValue & "' And Site_Code = '" & AgL.PubSiteCode & "' And Div_Code = '" & AgL.PubDivCode & "' And IsNull(IsDeleted,0) = 0 "
                    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Party Document No. Already Exists")
                Else
                    mQry = "  SELECT COUNT(*) FROM SaleOrder WHERE PartyOrderNo  = '" & TxtPartyOrderNo.Text & "' AND SaleToParty ='" & TxtSaleToParty.AgSelectedValue & "' And Site_Code = '" & AgL.PubSiteCode & "' And Div_Code = '" & AgL.PubDivCode & "' AND DocID <>'" & mInternalCode & "' And IsNull(IsDeleted,0)=0 "
                    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Reference No. Already Exists")
                End If

            Case TxtV_Date.Name
                If TxtPartyOrderDate.Text <> "" Then
                    TxtPartyOrderDate.Text = TxtV_Date.Text
                End If
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
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
                    Dgl1.Item(Col1SalesTaxGroup, mRow).Value = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                End If
            End If

            mQry = "Select BuyerSKU, BuyerUpcCode from ItemBuyer Where Code = '" & Code & "' And Buyer = '" & TxtSaleToParty.AgSelectedValue & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1PartySKU, mRow).Value = AgL.XNull(DtTemp.Rows(0)("BuyerSKU"))
                Dgl1.Item(Col1PartyUPC, mRow).Value = AgL.XNull(DtTemp.Rows(0)("BuyerUPCCode"))
            Else
                Dgl1.Item(Col1PartySKU, mRow).Value = ""
                Dgl1.Item(Col1PartyUPC, mRow).Value = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                            " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "

        End Select
    End Sub


    Protected Overridable Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
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
                Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.0000")
                Dgl1.Item(Col1StockTotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1StockMeasurePerPcs, I).Value), "0.0000")

                If AgL.StrCmp(TxtBillingType.Text, "Qty") Or TxtBillingType.Text = "" Then
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.00")
                Else : AgL.StrCmp(TxtBillingType.Text, "Area")
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1TotalMeasure, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.00")
                End If

                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
                LblStockTotalMeasure.Text = Val(LblStockTotalMeasure.Text) + Val(Dgl1.Item(Col1StockTotalMeasure, I).Value)
            End If
        Next
        AgCalcGrid1.Calculation()
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.00")
        LblTotalMeasure.Text = Format(Val(LblTotalMeasure.Text), "0.0000")
        LblTotalAmount.Text = Format(Val(LblTotalAmount.Text), "0.00")
        LblStockTotalMeasure.Text = Format(Val(LblStockTotalMeasure.Text), "0.0000")
    End Sub

    Private Shadows Sub Calculation()

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


    Private Sub TxtOrderCancelDate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtFinalPlaceOfDelivery.LostFocus, TxtRemarks.LostFocus, TxtPriceMode.LostFocus
        Select Case sender.NAME
            Case TxtRemarks.Name
                TabControl1.SelectedTab = TPExport
            Case TxtPriceMode.Name
                TabControl1.SelectedTab = TPShipping
        End Select
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0

        If TxtPartyOrderDate.Text <> "" Then
            If CDate(TxtPartyOrderDate.Text) > CDate(TxtV_Date.Text) Then
                MsgBox("Party order date can't be greater than order date")
                TxtPartyOrderDate.Focus()
                passed = False : Exit Sub
            End If
        End If

        If TxtDeliveryDate.Text <> "" Then
            If CDate(TxtV_Date.Text) > CDate(TxtDeliveryDate.Text) Then
                MsgBox("Delivery date can't be less than order date")
                TabControl1.SelectedTab = TP1 : TxtDeliveryDate.Focus()
                passed = False : Exit Sub
            End If
        End If


        If TxtOrderCancelDate.Text <> "" Then
            If CDate(TxtV_Date.Text) > CDate(TxtOrderCancelDate.Text) Then
                MsgBox("Order cancel date can't be less than order date")
                TxtOrderCancelDate.Focus()
                passed = False : Exit Sub
            End If
        End If

        If TxtOrderCancelDate.Text <> "" And TxtDeliveryDate.Text <> "" Then
            If CDate(TxtDeliveryDate.Text) > CDate(TxtOrderCancelDate.Text) Then
                MsgBox("Order cancel date can't be less than delivery date")
                TxtOrderCancelDate.Focus()
                passed = False : Exit Sub
            End If
        End If

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub
        If AgCL.AgIsDuplicate(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub


        If Topctrl1.Mode = "Add" Then
            mQry = " SELECT COUNT(*) FROM SaleOrder  WHERE PartyOrderNo  = '" & TxtPartyOrderNo.Text & "' AND SaleToParty ='" & TxtSaleToParty.AgSelectedValue & "' And Site_Code = '" & AgL.PubSiteCode & "' And Div_Code = '" & AgL.PubDivCode & "' And IsNull(IsDeleted,0) = 0 "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then passed = False : MsgBox("Party Document No. Already Exists")
        Else
            mQry = "  SELECT COUNT(*) FROM SaleOrder WHERE PartyOrderNo  = '" & TxtPartyOrderNo.Text & "' AND SaleToParty ='" & TxtSaleToParty.AgSelectedValue & "' And Site_Code = '" & AgL.PubSiteCode & "' And Div_Code = '" & AgL.PubDivCode & "' AND DocID <>'" & mInternalCode & "' And IsNull(IsDeleted,0)=0 "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then passed = False : MsgBox("Reference No. Already Exists")
        End If



        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If

                    'If Val(.Item(Col1Rate, I).Value) = 0 Then
                    '    MsgBox("Rate Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                    '    .CurrentCell = .Item(Col1Rate, I) : Dgl1.Focus()
                    '    passed = False : Exit Sub
                    'End If
                End If
            Next
        End With
    End Sub

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtShipToPartyCity.Enter
        Select Case sender.name
            Case TxtShipToPartyCity.Name
                TxtShipToPartyCity.AgRowFilter = " IsDeleted = 0 "
        End Select
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        PrintDocument(SearchCode)
    End Sub

    Public Overridable Sub PrintDocument(ByVal SearchCode As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            If FrmType = ClsMain.EntryPointType.Main Then
                AgL.PubReportTitle = "Export Order"
                RepName = "Rug_ExportOrder_Print" : RepTitle = "Export Order"
                bTableName = "SaleOrder" : bSecTableName = "SaleOrderDetail SO1 ON SO1.DocID =SO.DocID"
                bCondstr = "WHERE SO.DocID='" & SearchCode & "'"
            Else
                AgL.PubReportTitle = "Export Order Log"
                RepName = "Rug_ExportOrder_Print" : RepTitle = "Export Order Log"
                bTableName = "SaleOrder_Log" : bSecTableName = "SaleOrderDetail_Log  SO1 ON SO1.UID =SO.UID "
                bCondstr = "WHERE SO.UID='" & SearchCode & "'"
            End If

            strQry = " SELECT SO.DocID, SO.V_Type, SO.V_Prefix, SO.V_Date, SO.V_No, SO.Div_Code, SO.Site_Code, " & _
                        " SO.SaleToParty, SO.SaleToPartyName, SO.SaleToPartyAdd1, SO.SaleToPartyAdd2, SO.SaleToPartyCity, SO.SaleToPartyCityName, SO.SaleToPartyState, SO.SaleToPartyCountry,  " & _
                        " SO.ShipToPartyName, SO.ShipToPartyAdd1, SO.ShipToPartyAdd2, SO.ShipToPartyCity, SO.ShipToPartyCityName, SO.ShipToPartyState, SO.ShipToPartyCountry,  " & _
                        " SO.SalesTaxGroupParty, SO.PartyOrderNo, SO.PartyOrderDate, SO.PartyOrderCancelDate, SO.DestinationPort, SO.FinalPlaceOfDelivery, SO.TermsAndConditions, " & _
                        " SO.EntryBy, SO.EntryDate, SO.EntryType, SO.EntryStatus, SO.ApproveBy, SO.ApproveDate,SO.IsDeleted, SO.Status, SO.UID, " & _
                        " SO.PartyDeliveryDate, SO.Remarks, SO.DeliveryMeasure, SO.ShipmentDate, SO.FactoryDate, SO.FactoryDeliveryDate, SO.ExFactoryShipmentDate, SO.FactoryCancelDate, " & _
                        " SO.BillingType, SO.Currency, SO.TotalQty, SO.TotalAmount,SO.TotalMeasure, " & _
                        " SO1.Sr, SO1.Item, SO1.SalesTaxGroupItem, SO1.Qty, SO1.Unit, SO1.Rate, SO1.Amount, " & _
                        " SO1.UID, SO1.PartySKU, SO1.PartyUPC, SO1.MeasurePerPcs, SO1.TotalMeasure AS LineTotalMeasure, " & _
                        " D.Div_Name,SM.Name AS SiteName,SD.Description AS DestinationPortName,C.Country AS DestinationPortCountry, " & _
                        " I.Description AS ItemDesc,Vt.Description AS OrderTypeDesc,RD.Description AS DesignDesc,RS.Description AS SizeDesc " & _
                        " FROM " & bTableName & " SO " & _
                        " LEFT JOIN " & bSecTableName & "" & _
                        " LEFT JOIN Division D ON D.Div_Code=SO.Div_Code  " & _
                        " LEFT JOIN SiteMast SM ON SM.Code=SO.Site_Code  " & _
                        " LEFT JOIN SeaPort SD ON SD.Code=SO.DestinationPort  " & _
                        " LEFT JOIN City C ON C.CityCode=SD.City  " & _
                        " LEFT JOIN Item I ON I.Code=SO1.Item  " & _
                        " LEFT JOIN Voucher_Type Vt ON Vt.V_Type =SO.V_Type " & _
                        " LEFT JOIN RUG_CarpetSku CS ON CS.Code=SO1.Item " & _
                        " LEFT JOIN RUG_Design RD ON RD.Code=CS.Design " & _
                        " LEFT JOIN Rug_Size RS ON RS.Code=CS.Size " & _
                        " " & bCondstr & ""

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)
            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            AgPL.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub TempSaleOrder_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        mLastKeyPressed = e.KeyCode
    End Sub

    Private Sub ProcFillExportDetail(ByVal Party As String, ByVal V_Date As String)
        Dim DsTemp As DataSet = Nothing
        Try
            If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then Exit Sub

            mQry = "SELECT TOP 1 H.*, C.Country as DestinationCountry   " & _
                    " FROM SaleOrder H " & _
                    " Left Join SeaPort SP On H.DestinationPort = SP.Code " & _
                    " Left Join City C On SP.City = C.CityCode " & _
                    " WHERE H.SaleToParty = '" & Party & "' " & _
                    " AND H.V_Date <= '" & V_Date & "' " & _
                    " ORDER BY H.V_Date DESC	 "
            DsTemp = AgL.FillData(mQry, AgL.GCn)

            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    TxtCurrency.AgSelectedValue = AgL.XNull(.Rows(0)("Currency"))
                    TxtDestinationPort.AgSelectedValue = AgL.XNull(.Rows(0)("DestinationPort"))
                    TxtDestinationCountry.Text = AgL.XNull(.Rows(0)("DestinationCountry"))
                    TxtFinalPlaceOfDelivery.Text = AgL.XNull(.Rows(0)("FinalPlaceOfDelivery"))
                    TxtPreCarriageBy.Text = AgL.XNull(.Rows(0)("PreCarriageBy"))
                    TxtPlaceOfReceipt.Text = AgL.XNull(.Rows(0)("PlaceOfReceipt"))
                    TxtShipmentThrough.Text = AgL.XNull(.Rows(0)("ShipmentThrough"))
                    TxtBankAcNoBuyer.Text = AgL.XNull(.Rows(0)("BankAcNoBuyer"))
                    TxtBankNameBuyer.Text = AgL.XNull(.Rows(0)("BankNameBuyer"))
                    TxtBankAddressBuyer.Text = AgL.XNull(.Rows(0)("BankAddressBuyer"))
                    TxtPriceMode.Text = AgL.XNull(.Rows(0)("PriceMode"))
                    TxtShipToParty.Text = AgL.XNull(.Rows(0)("ShipToPartyName"))
                    TxtShipToPartyAdd1.Text = AgL.XNull(.Rows(0)("ShipToPartyAdd1"))
                    TxtShipToPartyAdd2.Text = AgL.XNull(.Rows(0)("ShipToPartyAdd2"))
                    TxtShipToPartyCity.AgSelectedValue = AgL.XNull(.Rows(0)("ShipToPartyCity"))
                    TxtShipToPartyState.Text = AgL.XNull(.Rows(0)("ShipToPartyState"))
                    TxtShipToPartyCountry.Text = AgL.XNull(.Rows(0)("ShipToPartyCountry"))
                Else
                    TxtCurrency.AgSelectedValue = ""
                    TxtDestinationPort.AgSelectedValue = ""
                    TxtDestinationCountry.Text = ""
                    TxtFinalPlaceOfDelivery.Text = ""
                    TxtPreCarriageBy.Text = ""
                    TxtPlaceOfReceipt.Text = ""
                    TxtShipmentThrough.Text = ""
                    TxtBankAcNoBuyer.Text = ""
                    TxtBankNameBuyer.Text = ""
                    TxtBankAddressBuyer.Text = ""
                    TxtPriceMode.Text = ""
                    TxtShipToParty.Text = ""
                    TxtShipToPartyAdd1.Text = ""
                    TxtShipToPartyAdd2.Text = ""
                    TxtShipToPartyCity.AgSelectedValue = ""
                    TxtShipToPartyState.Text = ""
                    TxtShipToPartyCountry.Text = ""
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub TempSaleOrder_BaseFunction_Create() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = "SELECT Sg.SubCode, Sg.DispName AS [Name], C.CityName AS [City], C.State, C.Country, C.CityCode, Dc.Country As DestinationCountry, " & _
                "Sg.Add1, Sg.Add2, Sg.Add3, P.SeaPort, P.Currency, IsNull(Sg.IsDeleted,0) as IsDeleted, P.BankName, P.BankAddress, P.BankAcNo " & _
                "FROM Buyer P " & _
                "LEFT JOIN SubGroup Sg ON P.SubCode = Sg.subCode " & _
                "LEFT JOIN City C ON Sg.CityCode = C.CityCode  " & _
                "LEFT JOIN seaport SP ON P.SeaPort = SP.Code  " & _
                "LEFT JOIN City Dc ON sp.City = Dc.CityCode  "
        HelpDataSet.SaleToParty = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup , IsNull(I.IsDeleted ,0) AS IsDeleted, IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, I.Div_Code FROM Item I"
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select CityCode, CityName As [Name], State, Country, IsNull(IsDeleted,0) as IsDeleted From City Order By CityName"
        HelpDataSet.City = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Code AS Currency, IsNull(IsDeleted,0) AS IsDeleted FROM Currency ORDER BY Code "
        HelpDataSet.Currency = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT P.Code, P.Description, IsNull(P.IsDeleted,0) AS IsDeleted  FROM SeaPort P ORDER BY P.Description "
        HelpDataSet.Port = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Description  FROM Structure ORDER BY Description "
        HelpDataSet.AgStructure = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Description AS Code, Description, IsNull(Active,0)  FROM PostingGroupSalesTaxParty "
        HelpDataSet.SalesTaxGroupParty = AgL.FillData(mQry, AgL.GCn)

        HelpDataSet.BillingType = AgL.FillData(ClsMain.HelpQueries.BillingType, AgL.GCn)

        mQry = "Select '" & ClsMain.SaleOrderStatus.Active & "' As Code, '" & ClsMain.SaleOrderStatus.Active & "' As Description " & _
               " Union All Select '" & ClsMain.SaleOrderStatus.Hold & "' As Code, '" & ClsMain.SaleOrderStatus.Hold & "' As Description " & _
               " Union All Select '" & ClsMain.SaleOrderStatus.Cancelled & "' As Code, '" & ClsMain.SaleOrderStatus.Cancelled & "' As Description " & _
               " Union All Select '" & ClsMain.SaleOrderStatus.Closed & "' As Code, '" & ClsMain.SaleOrderStatus.Closed & "' As Description "
        HelpDataSet.Status = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT P.Code , P.Description FROM Priority P "
        HelpDataSet.Priority = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT SubCode AS Code, DispName AS Name FROM SubGroup"
        HelpDataSet.Agent = AgL.FillData(mQry, AgL.GCn)
    End Sub
End Class
