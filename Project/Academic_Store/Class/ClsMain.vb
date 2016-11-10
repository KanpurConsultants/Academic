Public Class ClsMain
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Store"

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain, ByVal PLibVar As Academic_ProjLib.ClsMain)
        AgL = AgLibVar
        PLib = PLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        PObj = New Academic_Objects.ClsMain(AgL, PLib)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()
    End Sub
    Public Class PostingGroupSalesTaxParty
        Public Const Local As String = "Local"
        Public Const Central As String = "Central"
        Public Const LocalWithFormH As String = "Local {Form `H`}"
        Public Const CentralWithFormC As String = "Central {Form `C`}"
        Public Const Export As String = "Export"
    End Class

    Public Shared Item_Nature1_Description = "Item Nature1"
    Public Shared Item_Nature2_Description = "Item Nature2"
    Public Shared Item_Batch_Description = "Batch No"
    Public Class ItemNature
        Public Const RawMaterial As String = "Raw Material"
        Public Const SemiFinished As String = "Semi Finished"
        Public Const Finished As String = "Finished"

        Public Const Consumable As String = "Consumable"
        Public Const NonConsumable As String = "Non Consumable"
    End Class
    Public Class InOut
        Public Const GateIn As String = "IN"
        Public Const GateOut As String = "OUT"
    End Class

    Class Temp_NCat
        Public Const Requistion As String = "REQ"
        Public Const StorePurchaseIndent As String = "SPIND"
        Public Const StorePurchaseOrder As String = "SPO"
        Public Const StoreGRN As String = "GRN"
        Public Const StoreGatePass As String = "SGATE"

    End Class
    Class Temp_Structure
        Public Const StoreGRN As String = "StoreGRN"
    End Class
    Public Class Temp_Charges
        Public Const GrossAmount As String = "GAMT"
        Public Const LineAddition As String = "LAdd"
        Public Const LineDeduction As String = "LDed"
        Public Const LineNetAmount As String = "LNAmt"
        Public Const HeaderAddition As String = "HAdd"
        Public Const HeaderDeduction As String = "HDed"
        Public Const NetSubTotal As String = "NSTot"
        Public Const RoundOff As String = "ROff"
        Public Const NetAmount As String = "NAMT"
    End Class
    Public Class ItemType
        Public Const Book As String = "Book"
        Public Const Stationary As String = "Stationary"
        Public Const Generals As String = "Generals"
        Public Const CD As String = "CD"
        Public Const Mess As String = "Mess"
        Public Const Store As String = "Store"
    End Class
    Public Class PartyMasterType
        Public Const Cash As String = "Cash"
        Public Const Party As String = "Party"
        Public Const Supplier As String = "Supplier"
        Public Const Customer As String = "Customer"
        Public Const Transport As String = "Transport"
        Public Const Agent As String = "Agent"
    End Class

    Public Sub UpdateTableStructure(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        Try
            Call CreateDatabase(MdlTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CreateDatabase(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
    
        FStore_Requisition(MdlTable, "Store_Requisition")
        FStore_RequisitionDetail(MdlTable, "Store_RequisitionDetail")

        FStore_PurchIndent(MdlTable, "Store_PurchIndent")
        FStore_PurchIndentReq(MdlTable, "Store_PurchIndentReq")
        FStore_PurchIndentDetail(MdlTable, "Store_PurchIndentDetail")

        FStore_PurchOrder(MdlTable, "Store_PurchOrder")
        FStore_PurchOrderTerms(MdlTable, "Store_PurchOrderTerms")
        FStore_PurchOrderDetail(MdlTable, "Store_PurchOrderDetail")

        FStore_GRN(MdlTable, "Store_GRN")
        FStore_GRNDetail(MdlTable, "Store_GrnDetail")

    End Sub
    'req start
    Private Sub FStore_Requisition(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Department", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Department", "Code", "Sch_Department")
    End Sub

    Private Sub FStore_RequisitionDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "RequireDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Store_Requisition")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Store_Unit")
    End Sub

    Private Sub FStore_PurchIndent(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
    End Sub

    Private Sub FStore_PurchIndentReq(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "RequisitionDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "RequireUid", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "RequireQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "RequireDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Store_PurchIndent")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Store_Unit")
        AgL.FSetFKeyValue(MdlTable, "RequisitionDocId", "DocID", "Store_Requisition")
        AgL.FSetFKeyValue(MdlTable, "RequireUid", "Uid", "Store_RequisitionDetail")
    End Sub

    Private Sub FStore_PurchIndentDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "RequireQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "IndentQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "RequireDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Store_PurchIndent")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Store_Unit")
    End Sub

    Private Sub FStore_PurchOrder(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "PurchIndentDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "SubCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "IsAgainstIndent", AgLibrary.ClsMain.SQLDataType.Bit, , False)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)


        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "PurchIndentDocId", "DocID", "Store_PurchIndent")
        AgL.FSetFKeyValue(MdlTable, "SubCode", "SubCode", "SubGroup")
    End Sub

    Private Sub FStore_PurchOrderTerms(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Terms", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Store_PurchOrder")
    End Sub

    Private Sub FStore_PurchOrderDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "PurchIndentDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PurchIndentUID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Store_PurchOrder")
        AgL.FSetFKeyValue(MdlTable, "PurchIndentDocId", "DocID", "Store_PurchIndent")
        AgL.FSetFKeyValue(MdlTable, "PurchIndentUID", "Uid", "Store_PurchIndentDetail")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Store_Unit")
    End Sub

    Private Sub FStore_GRN(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 25)
        AgL.FSetColumnValue(MdlTable, "DocumentNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "DocumentDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "AcCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "PurchOrderDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "GatePassDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "IsAgainstOrder", AgLibrary.ClsMain.SQLDataType.Bit, , False)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "NetSubTotal", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "RoundOff", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "InvoiceAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Structure", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Department", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "AcCode", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "PurchOrderDocId", "DocID", "Store_PurchOrder")
        AgL.FSetFKeyValue(MdlTable, "GatePassDocId", "DocID", "GateInOut")
    End Sub

    Private Sub FStore_GrnDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ItemDescription", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "BatchNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Godown", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DocQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Amount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "NetAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "LandedAmount", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "PurchOrderDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "PurchOrderUID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "GatePassDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "GatePassUID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "ReferenceDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "ReferenceUId", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "SalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)
        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocID", "DocID", "Store_GRN")
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Store_Item")
        AgL.FSetFKeyValue(MdlTable, "Unit", "Code", "Store_Unit")
        AgL.FSetFKeyValue(MdlTable, "Godown", "Code", "Store_Godown")
        AgL.FSetFKeyValue(MdlTable, "PurchOrderDocId", "DocID", "Store_PurchOrder")
        AgL.FSetFKeyValue(MdlTable, "PurchOrderUID", "Uid", "Store_PurchOrderDetail")
        AgL.FSetFKeyValue(MdlTable, "GatePassDocId", "DocID", "GateInOut")
        AgL.FSetFKeyValue(MdlTable, "GatePassUID", "Uid", "GateInOut")
    End Sub
    'req end

    Public Sub UpdateTableStructure()
        Call AddNewTable()

        Call AddNewField()

        Call EditField()

        Call CreateVType()

        Call AddNewVoucherReference()

        Call CreateView()

        Call InitializeTables()

        Call InitializeStructure()

    End Sub

    Private Sub AddNewField()
        Dim mQry$ = ""
        '=======================< Table: Store_Enviro >==================================================================================
        AgL.AddNewField(AgL.GCn, "Store_Enviro", "SalesTaxGroupParty", "nVarChar(20)")
        AgL.AddNewField(AgL.GCn, "Store_Enviro", "SalesTaxGroupItem", "nVarChar(20)")
        AgL.AddNewField(AgL.GCn, "Store_Enviro", "IsItemNature", "bit", 0)

        '=======================< Table: Store_Item >==================================================================================
        AgL.AddNewField(AgL.GCn, "Store_Item", "SaleRate", "Float", "0", False)
        AgL.AddNewField(AgL.GCn, "Store_Item", "Nature", "nVarChar(50)", , True)

        AgL.AddNewField(AgL.GCn, "Store_Item", "ItemCategory", "nVarChar(10)", , True)
        If AgL.IsFieldExist("ItemCategory", "Store_Item", AgL.GCn) Then

            mQry = "UPDATE Store_Item   " & _
                      " SET Store_Item.ItemCategory = Store_Itemgroup.ItemCategory " & _
                      " FROM Store_Itemgroup " & _
                      " WHERE Store_Item.ItemGroup = Store_Itemgroup.Code  " & _
                      " And Store_Item.ItemCategory IS NULL "

            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

        End If


        '=======================< Table: Store_Enviro >==================================================================================
        'AgL.AddNewField(AgL.GCn, "Store_Enviro", "Godown", "nVarChar(10)", , True)
        'If AgL.IsFieldExist("Godown", "Store_Enviro", AgL.GCn) Then
        '    AgL.AddForeignKey(AgL.GCn, "FK_Store_Enviro_Godown", "Store_Godown", "Store_Enviro", "Code", "Godown")
        'End If

        If AgL.AddNewField(AgL.GCn, "Store_Enviro", "PreparedBy", "nVarChar(10)") Then
            AgL.Dman_ExecuteNonQry("Update Store_Enviro Set PreparedBy = '" & AgL.PubUserName & "'", AgL.GCn)
        End If

        If AgL.AddNewField(AgL.GCn, "Store_Enviro", "U_EntDt", "DATETIME") Then
            AgL.Dman_ExecuteNonQry("Update Store_Enviro Set U_EntDt = " & AgL.ConvertDate(AgL.PubLoginDate) & "", AgL.GCn)
        End If

        If AgL.AddNewField(AgL.GCn, "Store_Enviro", "U_AE", "nVarChar(1)") Then
            AgL.Dman_ExecuteNonQry("Update Store_Enviro Set U_AE = 'A'", AgL.GCn)
        End If

        AgL.AddNewField(AgL.GCn, "Store_Enviro", "Edit_Date", "DATETIME")
        AgL.AddNewField(AgL.GCn, "Store_Enviro", "ModifiedBy", "nVarChar(10)")

        '=======================< Table: Store_Stock >==================================================================================
        AgL.AddNewField(AgL.GCn, "Store_Stock", "Godown", "nVarChar(8)", , True)
        AgL.AddNewField(AgL.GCn, "Store_Stock", "OrderDocId", "NVARCHAR(21)")
        AgL.AddNewField(AgL.GCn, "Store_Stock", "OrderUID", "uniqueidentifier")
        AgL.AddNewField(AgL.GCn, "Store_Purchase", "OrderDocId", "NVARCHAR(21)")
        If AgL.IsFieldExist("Godown", "Store_Stock", AgL.GCn) Then
            AgL.AddForeignKey(AgL.GCn, "FK_Store_Stock_Godown", "Store_Godown", "Store_Stock", "Code", "Godown")
        End If

        AgL.AddNewField(AgL.GCn, "Store_Stock", "GRNDocId", "NVARCHAR(21)")
        If AgL.IsFieldExist("GRNDocId", "Store_Stock", AgL.GCn) Then
            AgL.AddForeignKey(AgL.GCn, "FK_Store_Stock_GRNDocId", "Store_GRN", "Store_Stock", "DocID", "GRNDocId")
        End If
        AgL.AddNewField(AgL.GCn, "Store_Stock", "GRNUID", "uniqueidentifier")

        '=======================< Table: Store_Purchase >==================================================================================
        AgL.AddNewField(AgL.GCn, "Store_Purchase", "Remark", "nVarChar(255)")
        AgL.AddNewField(AgL.GCn, "Store_Purchase", "OrderDocId", "NVARCHAR(21)")
        AgL.AddNewField(AgL.GCn, "Store_Purchase", "IsAgainstOrder", "bit", 0, False)
        AgL.AddNewField(AgL.GCn, "Store_Purchase", "Department", "nVarChar(8)", , True)
        If AgL.IsFieldExist("Department", "Store_Purchase", AgL.GCn) Then
            AgL.AddForeignKey(AgL.GCn, "FK_Store_Purchase_Department", "Sch_Department", "Store_Purchase", "Code", "Department")
        End If

        AgL.AddNewField(AgL.GCn, "Store_Purchase", "ApprovedBy", "nVarChar(10)")
        AgL.AddNewField(AgL.GCn, "Store_Purchase", "ApprovedDate", "SmallDateTime")

        AgL.AddNewField(AgL.GCn, "Store_Purchase", "ReferenceNo", "nVarChar(25)")

        AgL.AddNewField(AgL.GCn, "Store_Purchase", "GRNDocId", "NVARCHAR(21)")
        If AgL.IsFieldExist("GRNDocId", "Store_Purchase", AgL.GCn) Then
            AgL.AddForeignKey(AgL.GCn, "FK_Store_Purchase_GRNDocId", "Store_GRN", "Store_Purchase", "DocID", "GRNDocId")
        End If
        AgL.AddNewField(AgL.GCn, "Store_Purchase", "IsAgainstGRN", "bit", 0, False)

        '=======================< Table: Store_Sale >==================================================================================
        AgL.AddNewField(AgL.GCn, "Store_Sale", "Department", "nVarChar(8)", , True)
        If AgL.IsFieldExist("Department", "Store_Sale", AgL.GCn) Then
            AgL.AddForeignKey(AgL.GCn, "FK_Store_Sale_Department", "Sch_Department", "Store_Sale", "Code", "Department")
        End If

        AgL.AddNewField(AgL.GCn, "Store_Sale", "ApprovedBy", "nVarChar(10)")
        AgL.AddNewField(AgL.GCn, "Store_Sale", "ApprovedDate", "SmallDateTime")

        AgL.AddNewField(AgL.GCn, "Store_Sale", "ReferenceNo", "nVarChar(25)")

        '=======================< Table: Store_StockAdjustment >==================================================================================
        AgL.AddNewField(AgL.GCn, "Store_StockAdjustment", "Department2", "nVarChar(8)", , True)
        If AgL.IsFieldExist("Department2", "Store_StockAdjustment", AgL.GCn) Then
            AgL.AddForeignKey(AgL.GCn, "FK_Store_StockAdjustment_Department", "Sch_Department", "Store_StockAdjustment", "Code", "Department2")
        End If

        AgL.AddNewField(AgL.GCn, "Store_StockAdjustment", "ReferenceNo", "nVarChar(25)")

        AgL.AddNewField(AgL.GCn, "Store_StockAdjustment", "Godown1", "nVarChar(10)", , True)
        If AgL.IsFieldExist("Godown1", "Store_StockAdjustment", AgL.GCn) Then
            AgL.AddForeignKey(AgL.GCn, "FK_Store_StockAdjustment_Godown1", "Store_Godown", "Store_StockAdjustment", "Code", "Godown1")
        End If

        AgL.AddNewField(AgL.GCn, "Store_StockAdjustment", "Godown2", "nVarChar(10)", , True)
        If AgL.IsFieldExist("Godown2", "Store_StockAdjustment", AgL.GCn) Then
            AgL.AddForeignKey(AgL.GCn, "FK_Store_StockAdjustment_Godown2", "Store_Godown", "Store_StockAdjustment", "Code", "Godown2")
        End If

        '=======================< ******************* >==================================================================================
    End Sub

    Private Sub EditField()
        Dim mQry$ = ""
        'AgL.EditField("VehicleBreakDown", "DriverAc", "nVarChar(10)", AgL.GCn)

        If AgL.IsFieldExist("MasterType", "Store_Item", AgL.GCn) Then
            mQry = "UPDATE Store_Item SET MasterType = '" & ClsMain.ItemType.Store & "' WHERE MasterType IS NULL"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.IsFieldExist("MasterType", "Store_ItemCategory", AgL.GCn) Then
            mQry = "UPDATE Store_ItemCategory SET MasterType = '" & ClsMain.ItemType.Store & "' WHERE MasterType IS NULL"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If

        If AgL.IsFieldExist("MasterType", "Store_ItemGroup", AgL.GCn) Then
            mQry = "UPDATE Store_ItemGroup SET MasterType = '" & ClsMain.ItemType.Store & "' WHERE MasterType IS NULL"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
        If AgL.IsFieldExist("DisplayName", "Store_Item", AgL.GCn) Then
            mQry = "UPDATE Store_Item   " & _
                      " SET Store_Item.DisplayName = Left(Store_Item.Description,100) " & _
                      " WHERE Store_Item.DisplayName IS NULL "

            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If


    End Sub

    Private Sub AddNewTable()
        Dim mQry$ = "", mQry1$ = ""
        Try
            'mQry = "CREATE TABLE dbo.Store_Enviro " & _
            '        " ( " & _
            '        " Site_Code                NVARCHAR (2) NOT NULL, " & _
            '        " PurchaseAc               NVARCHAR (10) NOT NULL, " & _
            '        " PurchaseAdditionAc       NVARCHAR (10) NOT NULL, " & _
            '        " PurchaseDeductionAc      NVARCHAR (10) NOT NULL, " & _
            '        " PurchaseAddition_HAc     NVARCHAR (10) NOT NULL, " & _
            '        " PurchaseDeduction_HAc    NVARCHAR (10) NOT NULL, " & _
            '        " SaleAc                   NVARCHAR (10) NOT NULL, " & _
            '        " SaleAdditionAc           NVARCHAR (10) NOT NULL, " & _
            '        " SaleDeductionAc          NVARCHAR (10) NOT NULL, " & _
            '        " SaleAddition_HAc         NVARCHAR (10) NOT NULL, " & _
            '        " SaleDeduction_HAc        NVARCHAR (10) NOT NULL, " & _
            '        " PurchaseAddition_Text    NVARCHAR (20) NOT NULL, " & _
            '        " PurchaseDeduction_Text   NVARCHAR (20) NOT NULL, " & _
            '        " PurchaseAddition_H_Text  NVARCHAR (20) NOT NULL, " & _
            '        " PurchaseDeduction_H_Text NVARCHAR (20) NOT NULL, " & _
            '        " SaleAddition_Text        NVARCHAR (20) NOT NULL, " & _
            '        " SaleDeduction_Text       NVARCHAR (20) NOT NULL, " & _
            '        " SaleAddition_H_Text      NVARCHAR (20) NOT NULL, " & _
            '        " SaleDeduction_H_Text     NVARCHAR (20) NOT NULL, " & _
            '        " Item_Nature1_Text        NVARCHAR (20) NOT NULL, " & _
            '        " Item_Nature2_Text        NVARCHAR (20) NOT NULL, " & _
            '        " ItemBatch_Text           NVARCHAR (20) NOT NULL, " & _
            '        " RowId                    BIGINT IDENTITY NOT NULL, " & _
            '        " UpLoadDate               SMALLDATETIME NULL, " & _
            '        " CONSTRAINT PK_Store_Enviro PRIMARY KEY (Site_Code), " & _
            '        " CONSTRAINT FK_Store_Enviro_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
            '        " CONSTRAINT FK_Store_Enviro_SubGroup FOREIGN KEY (PurchaseAc) REFERENCES dbo.SubGroup (SubCode), " & _
            '        " CONSTRAINT FK_Store_Enviro_SubGroup1 FOREIGN KEY (PurchaseAddition_HAc) REFERENCES dbo.SubGroup (SubCode), " & _
            '        " CONSTRAINT FK_Store_Enviro_SubGroup2 FOREIGN KEY (PurchaseDeduction_HAc) REFERENCES dbo.SubGroup (SubCode), " & _
            '        " CONSTRAINT FK_Store_Enviro_SubGroup3 FOREIGN KEY (PurchaseAdditionAc) REFERENCES dbo.SubGroup (SubCode), " & _
            '        " CONSTRAINT FK_Store_Enviro_SubGroup4 FOREIGN KEY (PurchaseDeductionAc) REFERENCES dbo.SubGroup (SubCode), " & _
            '        " CONSTRAINT FK_Store_Enviro_SubGroup5 FOREIGN KEY (SaleAc) REFERENCES dbo.SubGroup (SubCode), " & _
            '        " CONSTRAINT FK_Store_Enviro_SubGroup6 FOREIGN KEY (SaleAddition_HAc) REFERENCES dbo.SubGroup (SubCode), " & _
            '        " CONSTRAINT FK_Store_Enviro_SubGroup7 FOREIGN KEY (SaleAdditionAc) REFERENCES dbo.SubGroup (SubCode), " & _
            '        " CONSTRAINT FK_Store_Enviro_SubGroup8 FOREIGN KEY (SaleDeductionAc) REFERENCES dbo.SubGroup (SubCode), " & _
            '        " CONSTRAINT FK_Store_Enviro_SubGroup9 FOREIGN KEY (SaleDeduction_HAc) REFERENCES dbo.SubGroup (SubCode) " & _
            '        " )"

            'If Not AgL.IsTableExist("Store_Enviro", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_Enviro", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_Item_Nature1 " & _
            '        " ( " & _
            '        " Code        NVARCHAR (10) NOT NULL, " & _
            '        " Item        NVARCHAR (8) NOT NULL, " & _
            '        " Description NVARCHAR (20) NOT NULL, " & _
            '        " CONSTRAINT PK_Store_Item_Nature1 PRIMARY KEY (Code), " & _
            '        " CONSTRAINT IX_Store_Item_Nature1 UNIQUE (Item,Description), " & _
            '        " CONSTRAINT FK_Store_Item_Nature1_Store_Item FOREIGN KEY (Item) REFERENCES dbo.Store_Item (Code) " & _
            '        " )"
            'If Not AgL.IsTableExist("Store_Item_Nature1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_Item_Nature1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_Item_Nature2 " & _
            '        " ( " & _
            '        " Code        NVARCHAR (10) NOT NULL, " & _
            '        " Item        NVARCHAR (8) NOT NULL, " & _
            '        " Description NVARCHAR (20) NOT NULL, " & _
            '        " CONSTRAINT PK_Store_Item_Nature2 PRIMARY KEY (Code), " & _
            '        " CONSTRAINT IX_Store_Item_Nature2 UNIQUE (Item,Description), " & _
            '        " CONSTRAINT FK_Store_Item_Nature2_Store_Item FOREIGN KEY (Item) REFERENCES dbo.Store_Item (Code) " & _
            '        " )"
            'If Not AgL.IsTableExist("Store_Item_Nature2", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_Item_Nature2", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_Purchase " & _
            '        " ( " & _
            '        " DocId         NVARCHAR (21) NOT NULL, " & _
            '        " Div_Code      NVARCHAR (1) NOT NULL, " & _
            '        " Site_Code     NVARCHAR (2) NOT NULL, " & _
            '        " V_Type        NVARCHAR (5) NOT NULL, " & _
            '        " V_Prefix      NVARCHAR (5) NOT NULL, " & _
            '        " V_No          BIGINT NOT NULL, " & _
            '        " V_Date        SMALLDATETIME NOT NULL, " & _
            '        " PartyBillNo   NVARCHAR (20) NULL, " & _
            '        " PartyBillDate SMALLDATETIME NULL, " & _
            '        " AcCode        NVARCHAR (10) NOT NULL, " & _
            '        " Amount        FLOAT CONSTRAINT DF_Store_Purchase_Amount DEFAULT ((0)) NOT NULL, " & _
            '        " Addition      FLOAT CONSTRAINT DF_Store_Purchase_Addition DEFAULT ((0)) NOT NULL, " & _
            '        " Deduction     FLOAT CONSTRAINT DF_Store_Purchase_Deduction DEFAULT ((0)) NOT NULL, " & _
            '        " NetAmount     FLOAT CONSTRAINT DF_Store_Purchase_NetAmount DEFAULT ((0)) NOT NULL, " & _
            '        " Addition_H    FLOAT CONSTRAINT DF_Store_Purchase_Addition_H DEFAULT ((0)) NOT NULL, " & _
            '        " Deduction_H   FLOAT CONSTRAINT DF_Store_Purchase_Deduction_H DEFAULT ((0)) NOT NULL, " & _
            '        " InvoiceAmount FLOAT CONSTRAINT DF_Store_Purchase_InvoiceAmount DEFAULT ((0)) NOT NULL, " & _
            '        " PreparedBy    NVARCHAR (10) NOT NULL, " & _
            '        " U_EntDt       DATETIME NOT NULL, " & _
            '        " U_AE          NVARCHAR (1) NOT NULL, " & _
            '        " Edit_Date     DATETIME NULL, " & _
            '        " ModifiedBy    NVARCHAR (10) NULL, " & _
            '        " CONSTRAINT PK_Store_Purchase PRIMARY KEY (DocId), " & _
            '        " CONSTRAINT IX_Store_Purchase UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
            '        " CONSTRAINT FK_Store_Purchase_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
            '        " CONSTRAINT FK_Store_Purchase_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
            '        " CONSTRAINT FK_Store_Purchase_SubGroup FOREIGN KEY (AcCode) REFERENCES dbo.SubGroup (SubCode), " & _
            '        " CONSTRAINT FK_Store_Purchase_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
            '        " )"
            'If Not AgL.IsTableExist("Store_Purchase", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_Purchase", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_PurchaseLedgerM " & _
            '        " ( " & _
            '        " DocId NVARCHAR (21) NOT NULL, " & _
            '        " CONSTRAINT PK_Store_PurchaseLedgerM PRIMARY KEY (DocId), " & _
            '        " CONSTRAINT FK_Store_PurchaseLedgerM_Store_Purchase FOREIGN KEY (DocId) REFERENCES dbo.Store_Purchase (DocId), " & _
            '        " CONSTRAINT FK_Store_PurchaseLedgerM_LedgerM FOREIGN KEY (DocId) REFERENCES dbo.LedgerM (DocId) " & _
            '        " ) "
            'If Not AgL.IsTableExist("Store_PurchaseLedgerM", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_PurchaseLedgerM", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            'mQry = "CREATE TABLE dbo.Store_Stock " & _
            '        " ( " & _
            '        " DocId        NVARCHAR (21) NOT NULL, " & _
            '        " Sr           INT NOT NULL, " & _
            '        " Div_Code     NVARCHAR (1) NOT NULL, " & _
            '        " Site_Code    NVARCHAR (2) NOT NULL, " & _
            '        " V_Type       NVARCHAR (5) NOT NULL, " & _
            '        " V_Prefix     NVARCHAR (5) NOT NULL, " & _
            '        " V_No         BIGINT NOT NULL, " & _
            '        " V_Date       SMALLDATETIME NOT NULL, " & _
            '        " Item         NVARCHAR (8) CONSTRAINT DF_Store_Stock_Item DEFAULT ((0)) NOT NULL, " & _
            '        " Item_Nature1 NVARCHAR (10) NULL, " & _
            '        " Item_Nature2 NVARCHAR (10) NULL, " & _
            '        " BatchNo      NVARCHAR (20) CONSTRAINT DF_Store_Stock_BatchNo DEFAULT ((0)) NULL, " & _
            '        " IssueReceive NVARCHAR (10) NULL, " & _
            '        " Qty_Rec      FLOAT CONSTRAINT DF_Store_Stock_Qty_Rec DEFAULT ((0)) NOT NULL, " & _
            '        " Qty_Iss      FLOAT CONSTRAINT DF_Store_Stock_Qty_Iss DEFAULT ((0)) NOT NULL, " & _
            '        " Rate         FLOAT CONSTRAINT DF_Store_Stock_Rate DEFAULT ((0)) NOT NULL, " & _
            '        " Amount       FLOAT CONSTRAINT DF_Store_Stock_Amount DEFAULT ((0)) NOT NULL, " & _
            '        " Addition     FLOAT CONSTRAINT DF_Store_Stock_Addition DEFAULT ((0)) NOT NULL, " & _
            '        " Deduction    FLOAT CONSTRAINT DF_Store_Stock_Deduction DEFAULT ((0)) NOT NULL, " & _
            '        " NetAmount    FLOAT CONSTRAINT DF_Store_Stock_NetAmount DEFAULT ((0)) NOT NULL, " & _
            '        " Addition_H   FLOAT CONSTRAINT DF_Store_Stock_Addition_H DEFAULT ((0)) NOT NULL, " & _
            '        " Deduction_H  FLOAT CONSTRAINT DF_Store_Stock_Deduction_H DEFAULT ((0)) NOT NULL, " & _
            '        " LandedAmount FLOAT CONSTRAINT DF_Store_Stock_LandedAmount DEFAULT ((0)) NOT NULL, " & _
            '        " Remark       NVARCHAR (255) NULL, " & _
            '        " CONSTRAINT PK_Store_Stock PRIMARY KEY (DocId,Sr), " & _
            '        " CONSTRAINT IX_Store_Stock UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No,Sr), " & _
            '        " CONSTRAINT FK_Store_Stock_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
            '        " CONSTRAINT FK_Store_Stock_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
            '        " CONSTRAINT FK_Store_Stock_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
            '        " CONSTRAINT FK_Store_Stock_Store_Item FOREIGN KEY (Item) REFERENCES dbo.Store_Item (Code), " & _
            '        " CONSTRAINT FK_Store_Stock_Store_Item_Nature1 FOREIGN KEY (Item_Nature1) REFERENCES dbo.Store_Item_Nature1 (Code), " & _
            '        " CONSTRAINT FK_Store_Stock_Store_Item_Nature2 FOREIGN KEY (Item_Nature2) REFERENCES dbo.Store_Item_Nature2 (Code) " & _
            '        " )"
            'If Not AgL.IsTableExist("Store_Stock", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_Stock", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_PurchaseStock " & _
            '        " ( " & _
            '        " DocId      NVARCHAR (21) NOT NULL, " & _
            '        " RowId      BIGINT IDENTITY NOT NULL, " & _
            '        " UpLoadDate SMALLDATETIME NULL, " & _
            '        " CONSTRAINT PK_Store_PurchaseStock PRIMARY KEY (DocId), " & _
            '        " CONSTRAINT FK_Store_PurchaseStock_Store_Purchase FOREIGN KEY (DocId) REFERENCES dbo.Store_Purchase (DocId) " & _
            '        " )"
            'If Not AgL.IsTableExist("Store_PurchaseStock", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_PurchaseStock", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_Godown " & _
            '        " ( " & _
            '        " Code        NVARCHAR (8) NOT NULL, " & _
            '        " Description NVARCHAR (50) NOT NULL, " & _
            '        " ManualCode  NVARCHAR (20) NOT NULL, " & _
            '        " Div_Code    NVARCHAR (1) NOT NULL, " & _
            '        " Site_Code   NVARCHAR (2) NOT NULL, " & _
            '        " PreparedBy  NVARCHAR (10) NOT NULL, " & _
            '        " U_EntDt     DATETIME NOT NULL, " & _
            '        " U_AE        NVARCHAR (1) NOT NULL, " & _
            '        " Edit_Date   DATETIME NULL, " & _
            '        " ModifiedBy  NVARCHAR (10) NULL, " & _
            '        " CONSTRAINT PK_Store_Godown PRIMARY KEY (Code), " & _
            '        " CONSTRAINT IX_Store_Godown UNIQUE (Description), " & _
            '        " CONSTRAINT IX_Store_Godown_1 UNIQUE (ManualCode), " & _
            '        " CONSTRAINT FK_Store_Godown_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
            '        " )"
            'If Not AgL.IsTableExist("Store_Godown", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_Godown", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_StockHeader " & _
            '        " ( " & _
            '        " DocId      NVARCHAR (21) NOT NULL, " & _
            '        " PreparedBy NVARCHAR (10) NOT NULL, " & _
            '        " U_EntDt    DATETIME NOT NULL, " & _
            '        " U_AE       NVARCHAR (1) NOT NULL, " & _
            '        " Edit_Date  DATETIME NULL, " & _
            '        " ModifiedBy NVARCHAR (10) NULL, " & _
            '        " CONSTRAINT PK_Store_StockHeader PRIMARY KEY (DocId) " & _
            '        " )"
            'mQry1 = "Insert Into Store_StockHeader (DocId, PreparedBy, U_EntDt, U_AE) " & _
            '        " (Select Distinct DocId, " & _
            '        " " & AgL.Chk_Text(AgL.PubUserName) & " As PreparedBy, " & _
            '        " " & AgL.ConvertDate(AgL.PubLoginDate) & " As U_EntDt, " & _
            '        " 'A' As U_AE " & _
            '        " From Store_Stock) "

            'If Not AgL.IsTableExist("Store_StockHeader", AgL.GCn) Then
            '    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            '    AgL.Dman_ExecuteNonQry(mQry1, AgL.GCn)
            'End If

            'If AgL.IsFieldExist("DocId", "Store_Stock", AgL.GCn) Then
            '    AgL.AddForeignKey(AgL.GCn, "FK_Store_Stock_Store_StockHeaderDocId", "Store_StockHeader", "Store_Stock", "DocId", "DocId")
            'End If

            'If AgL.IsFieldExist("DocId", "Store_PurchaseStock", AgL.GCn) Then
            '    AgL.AddForeignKey(AgL.GCn, "FK_Store_PurchaseStock_Store_StockHeaderDocId", "Store_StockHeader", "Store_PurchaseStock", "DocId", "DocId")
            'End If

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_StockHeader", AgL.GcnSite) Then
            '        AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)

            '        AgL.Dman_ExecuteNonQry(mQry1, AgL.GcnSite)
            '    End If

            '    If AgL.IsFieldExist("DocId", "Store_Stock", AgL.GcnSite) Then
            '        AgL.AddForeignKey(AgL.GcnSite, "FK_Store_Stock_Store_StockHeaderDocId", "Store_StockHeader", "Store_Stock", "DocId", "DocId")
            '    End If

            '    If AgL.IsFieldExist("DocId", "Store_PurchaseStock", AgL.GcnSite) Then
            '        AgL.AddForeignKey(AgL.GcnSite, "FK_Store_PurchaseStock_Store_StockHeaderDocId", "Store_StockHeader", "Store_PurchaseStock", "DocId", "DocId")
            '    End If
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_StockAdjustment " & _
            '        " ( " & _
            '        " DocId      NVARCHAR (21) NOT NULL, " & _
            '        " Div_Code   NVARCHAR (1) NOT NULL, " & _
            '        " Site_Code  NVARCHAR (2) NOT NULL, " & _
            '        " V_Type     NVARCHAR (5) NOT NULL, " & _
            '        " V_Prefix   NVARCHAR (5) NOT NULL, " & _
            '        " V_No       BIGINT NOT NULL, " & _
            '        " V_Date     SMALLDATETIME NOT NULL, " & _
            '        " AcCode     NVARCHAR (10) NULL, " & _
            '        " Department NVARCHAR (8) NOT NULL, " & _
            '        " Amount     FLOAT CONSTRAINT DF_Store_StockAdjustment_Amount DEFAULT ((0)) NOT NULL, " & _
            '        " Remark     NVARCHAR (255) CONSTRAINT DF_Store_StockAdjustment_Remark DEFAULT ('') NULL, " & _
            '        " PreparedBy NVARCHAR (10) NOT NULL, " & _
            '        " U_EntDt    DATETIME NOT NULL, " & _
            '        " U_AE       NVARCHAR (1) NOT NULL, " & _
            '        " Edit_Date  DATETIME NULL, " & _
            '        " ModifiedBy NVARCHAR (10) NULL, " & _
            '        " CONSTRAINT PK_Store_StockAdjustment PRIMARY KEY (DocId), " & _
            '        " CONSTRAINT IX_Store_StockAdjustment UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
            '        " CONSTRAINT FK_Store_StockAdjustment_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
            '        " CONSTRAINT FK_Store_StockAdjustment_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
            '        " CONSTRAINT FK_Store_StockAdjustment_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
            '        " CONSTRAINT FK_Store_StockAdjustment_SubGroup FOREIGN KEY (AcCode) REFERENCES dbo.SubGroup (SubCode), " & _
            '        " CONSTRAINT FK_Store_StockAdjustment_Sch_Department FOREIGN KEY (Department) REFERENCES dbo.Sch_Department (Code) " & _
            '        " )"
            'If Not AgL.IsTableExist("Store_StockAdjustment", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_StockAdjustment", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_StockAdjustmentStockHeader " & _
            '        " ( " & _
            '        " DocId NVARCHAR (21) NOT NULL, " & _
            '        " CONSTRAINT PK_Store_StockAdjustmentStockHeader PRIMARY KEY (DocId), " & _
            '        " CONSTRAINT FK_Store_StockAdjustmentStockHeader_Store_StockAdjustment FOREIGN KEY (DocId) REFERENCES dbo.Store_StockAdjustment (DocId), " & _
            '        " CONSTRAINT FK_Store_StockAdjustmentStockHeader_Store_StockHeader FOREIGN KEY (DocId) REFERENCES dbo.Store_StockHeader (DocId) " & _
            '        " )"
            'If Not AgL.IsTableExist("Store_StockAdjustmentStockHeader", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_StockAdjustmentStockHeader", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_Sale " & _
            '        " ( " & _
            '        " DocId         NVARCHAR (21) NOT NULL, " & _
            '        " Div_Code      NVARCHAR (1) NOT NULL, " & _
            '        " Site_Code     NVARCHAR (2) NOT NULL, " & _
            '        " V_Type        NVARCHAR (5) NOT NULL, " & _
            '        " V_Prefix      NVARCHAR (5) NOT NULL, " & _
            '        " V_No          BIGINT NOT NULL, " & _
            '        " V_Date        SMALLDATETIME NOT NULL, " & _
            '        " AcCode        NVARCHAR (10) NOT NULL, " & _
            '        " Amount        FLOAT CONSTRAINT DF_Store_Sale_Amount DEFAULT ((0)) NOT NULL, " & _
            '        " Addition      FLOAT CONSTRAINT DF_Store_Sale_Addition DEFAULT ((0)) NOT NULL, " & _
            '        " Deduction     FLOAT CONSTRAINT DF_Store_Sale_Deduction DEFAULT ((0)) NOT NULL, " & _
            '        " NetAmount     FLOAT CONSTRAINT DF_Store_Sale_NetAmount DEFAULT ((0)) NOT NULL, " & _
            '        " Addition_H    FLOAT CONSTRAINT DF_Store_Sale_Addition_H DEFAULT ((0)) NOT NULL, " & _
            '        " Deduction_H   FLOAT CONSTRAINT DF_Store_Sale_Deduction_H DEFAULT ((0)) NOT NULL, " & _
            '        " InvoiceAmount FLOAT CONSTRAINT DF_Store_Sale_InvoiceAmount DEFAULT ((0)) NOT NULL, " & _
            '        " Remark        NVARCHAR (255) NULL, " & _
            '        " PreparedBy    NVARCHAR (10) NOT NULL, " & _
            '        " U_EntDt       DATETIME NOT NULL, " & _
            '        " U_AE          NVARCHAR (1) NOT NULL, " & _
            '        " Edit_Date     DATETIME NULL, " & _
            '        " ModifiedBy    NVARCHAR (10) NULL, " & _
            '        " CONSTRAINT PK_Store_Sale PRIMARY KEY (DocId), " & _
            '        " CONSTRAINT IX_Store_Sale UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
            '        " CONSTRAINT FK_Store_Sale_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
            '        " CONSTRAINT FK_Store_Sale_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
            '        " CONSTRAINT FK_Store_Sale_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
            '        " CONSTRAINT FK_Store_Sale_SubGroup FOREIGN KEY (AcCode) REFERENCES dbo.SubGroup (SubCode) " & _
            '        " )"
            'If Not AgL.IsTableExist("Store_Sale", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_Sale", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_SaleLedgerM " & _
            '        " ( " & _
            '        " DocId NVARCHAR (21) NOT NULL, " & _
            '        " CONSTRAINT PK_Store_SaleLedgerM PRIMARY KEY (DocId), " & _
            '        " CONSTRAINT FK_Store_SaleLedgerM_Store_Sale FOREIGN KEY (DocId) REFERENCES dbo.Store_Sale (DocId), " & _
            '        " CONSTRAINT FK_Store_SaleLedgerM_LedgerM FOREIGN KEY (DocId) REFERENCES dbo.LedgerM (DocId) " & _
            '        " )"
            'If Not AgL.IsTableExist("Store_SaleLedgerM", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_SaleLedgerM", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            'mQry = "CREATE TABLE dbo.Store_SaleStockHeader " & _
            '        " ( " & _
            '        " DocId NVARCHAR (21) NOT NULL, " & _
            '        " CONSTRAINT PK_Store_SaleStockHeader PRIMARY KEY (DocId), " & _
            '        " CONSTRAINT FK_Store_SaleStockHeader_Store_Sale FOREIGN KEY (DocId) REFERENCES dbo.Store_Sale (DocId), " & _
            '        " CONSTRAINT FK_Store_SaleStockHeader_Store_StockHeader FOREIGN KEY (DocId) REFERENCES dbo.Store_StockHeader (DocId) " & _
            '        " )"
            'If Not AgL.IsTableExist("Store_SaleStockHeader", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then
            '    If Not AgL.IsTableExist("Store_SaleStockHeader", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            'End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateVType()
        AgL.CreateNCat(AgL.GCn, ClsVar.NCat_StorePurchase, ClsVar.Cat_StorePurchase, "Store Purchase Bill", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsVar.NCat_StorePurchase, ClsVar.Cat_StorePurchase, ClsVar.NCat_StorePurchase, "Store Purchase Bill", ClsVar.NCat_StorePurchase, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

        AgL.CreateNCat(AgL.GCn, ClsVar.NCat_StoreSale, ClsVar.Cat_StoreSale, "Store Sale Bill", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsVar.NCat_StoreSale, ClsVar.Cat_StoreSale, ClsVar.NCat_StoreSale, "Store Sale Bill", ClsVar.NCat_StoreSale, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

        AgL.CreateNCat(AgL.GCn, ClsVar.NCat_StoreSaleOld, ClsVar.Cat_StoreSale, "Store Old Sale", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsVar.NCat_StoreSaleOld, ClsVar.Cat_StoreSale, ClsVar.NCat_StoreSaleOld, "Store Old Sale", ClsVar.NCat_StoreSaleOld, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

        AgL.CreateNCat(AgL.GCn, ClsVar.NCat_StoreIssue, ClsVar.Cat_StoreIssue, "Store Issue", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsVar.NCat_StoreIssue, ClsVar.Cat_StoreIssue, ClsVar.NCat_StoreIssue, "Store Issue", ClsVar.NCat_StoreIssue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

        AgL.CreateNCat(AgL.GCn, ClsVar.NCat_StoreReceive, ClsVar.Cat_StoreReceive, "Store Receive", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsVar.NCat_StoreReceive, ClsVar.Cat_StoreReceive, ClsVar.NCat_StoreReceive, "Store Receive", ClsVar.NCat_StoreReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

        AgL.CreateNCat(AgL.GCn, ClsVar.NCat_StoreOpening, ClsVar.Cat_StoreReceive, "Store Opening", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsVar.NCat_StoreOpening, ClsVar.Cat_StoreReceive, ClsVar.NCat_StoreOpening, "Store Opening", ClsVar.NCat_StoreOpening, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

        AgL.CreateNCat(AgL.GCn, ClsVar.NCat_StoreIssueReceive, ClsVar.Cat_StoreIssueReceive, "Store Issue Receive", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsVar.NCat_StoreIssueReceive, ClsVar.Cat_StoreIssueReceive, ClsVar.NCat_StoreIssueReceive, "Store Issue Receive", ClsVar.NCat_StoreIssueReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

        AgL.CreateNCat(AgL.GCn, ClsVar.NCat_StoreSupplierBill, ClsVar.Cat_StoreSupplierBill, "Store Supplier Bill", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsVar.NCat_StoreSupplierBill, ClsVar.Cat_StoreSupplierBill, ClsVar.NCat_StoreSupplierBill, "Store Supplier Bill", ClsVar.NCat_StoreSupplierBill, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

        ''===================================================< Requisition Entry V_Type >===================================================
        AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.Requistion, ClsMain.Temp_NCat.Requistion, "Requisition Entry", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.Requistion, ClsMain.Temp_NCat.Requistion, ClsMain.Temp_NCat.Requistion, "Requisition Entry", ClsMain.Temp_NCat.Requistion, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
        ''===================================================< ************** >===================================================

        ''===================================================< Store Purchase Indent Entry V_Type >===================================================
        AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.StorePurchaseIndent, ClsMain.Temp_NCat.StorePurchaseIndent, "Store Purchase Indent", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.StorePurchaseIndent, ClsMain.Temp_NCat.StorePurchaseIndent, ClsMain.Temp_NCat.StorePurchaseIndent, "Store Purchase Indent", ClsMain.Temp_NCat.StorePurchaseIndent, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
        ''===================================================< ************** >===================================================

        ''===================================================< Store Purchase Order Entry V_Type >===================================================
        AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.StorePurchaseOrder, ClsMain.Temp_NCat.StorePurchaseOrder, "Store Purchase Order", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.StorePurchaseOrder, ClsMain.Temp_NCat.StorePurchaseOrder, ClsMain.Temp_NCat.StorePurchaseOrder, "Store Purchase Order", ClsMain.Temp_NCat.StorePurchaseOrder, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
        ''===================================================< ************** >===================================================

        ''===================================================< Store GRN Entry V_Type >===================================================
        AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.StoreGRN, ClsMain.Temp_NCat.StoreGRN, "Store Goods Receive", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.StoreGRN, ClsMain.Temp_NCat.StoreGRN, ClsMain.Temp_NCat.StoreGRN, "Store Goods Receive", ClsMain.Temp_NCat.StoreGRN, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
        ''===================================================< ************** >===================================================

        ''===================================================< Store Gate Pass Entry V_Type >===================================================
        AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.StoreGatePass, ClsMain.Temp_NCat.StoreGatePass, "Gate Pass", AgL.PubSiteCode)
        AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.StoreGatePass, ClsMain.Temp_NCat.StoreGatePass, ClsMain.Temp_NCat.StoreGatePass, "Gate Pass", ClsMain.Temp_NCat.StoreGatePass, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
        ''===================================================< ************** >===================================================


    End Sub

    Private Sub AddNewVoucherReference()
        Try
            'AgL.AddNewVoucherReference(AgL.GCn, ClsVar.VRef_DriverIncentivePayment, "Fleet_DriverIncentive", "DocId", "DocId", True)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateView()
        Dim mQry$ = ""
        '' Note Write Each View in Separate <Try---Catch> Section

        Try
            Dim bDepartmentCodeStr$ = "", bPartyCodeStr$ = ""

            bDepartmentCodeStr = " CASE " & _
                                    " WHEN Pur.Department IS NOT NULL  " & _
                                    "   THEN Pur.Department  " & _
                                    " WHEN Sale.Department IS NOT NULL " & _
                                    "   THEN Sale.Department  " & _
                                    " WHEN StkAdj.Department IS NOT NULL  " & _
                                    "   THEN StkAdj.Department  " & _
                                    " ELSE  " & _
                                    "   NULL " & _
                                    " End "

            bPartyCodeStr$ = " CASE " & _
                                " 	WHEN Pur.AcCode IS NOT NULL  " & _
                                " 		THEN Pur.AcCode  " & _
                                " 	WHEN Sale.AcCode IS NOT NULL  " & _
                                " 		THEN Sale.AcCode  " & _
                                " 	WHEN StkAdj.AcCode IS NOT NULL  " & _
                                " 		THEN StkAdj.AcCode  " & _
                                " 	ELSE  " & _
                                "        NULL " & _
                                "   End "

            mQry = "CREATE VIEW dbo.ViewStore_Stock As " & _
                    " SELECT Stk.*, D.Div_Name, S.Name AS Site_Name, G.Description AS GodownDesc, G.ManualCode AS GodownManualCode, " & _
                    " Pur.DocId AS PurchaseDocId, Sale.DocId AS SaleDocId, StkAdj.DocId AS StockAdjustmentDocId,  " & _
                    " " & bDepartmentCodeStr & " AS DepartmentCode, Dept.Description AS DepartmentDesc, Dept.ManualCode As DepartmentManualCode," & _
                    " " & bPartyCodeStr & " AS PartyCode, Sg.Name AS PartyName, Sg.DispName AS PartyDispName, Sg.ManualCode AS PartyManualCode, Sg.Nature AS PartyNature, Sg.GroupCode AS PartyGroupCode, Ag.GroupName AS PartyGroupName, " & _
                    " Sg.Add1 AS PartyAdd1, Sg.Add2 AS PartyAdd2, Sg.Add3 AS PartyAdd3, Sg.CityCode AS CityCode, City.CityName AS CityName,  " & _
                    " City.District , State.State_Desc AS StateName, State.ShortName StateShortName , Country.Name AS Country, Sg.PIN , Sg.Mobile ,Sg.Phone , Sg.FAX , Sg.EMail , Sg.CSTNo , Sg.LSTNo, Sg.TINNo , Sg.PAN,  " & _
                    " Vt.Description AS VoucherTypeDesc, Vt.NCat, Item.Description AS ItemDesc, Item.ManualCode AS ItemManualCode, Item.Unit AS UnitCode, Unit.Description AS UnitDesc, Unit.ManualCode AS UnitManualCode , Item.ItemGroup AS ItemGroupCode, IGrp.Description AS ItemGroupDesc, Item.ItemCategory AS ItemCategoryCode, ICat.Description AS ItemCategoryDesc, ICat.ManualCode AS ItemCategoryManualCode " & _
                    " FROM Store_Stock Stk " & _
                    " LEFT JOIN Division D ON Stk.Div_Code = D.Div_Code  " & _
                    " LEFT JOIN SiteMast S ON Stk.Site_Code = S.Code  " & _
                    " LEFT JOIN Voucher_Type Vt ON Stk.V_Type = Vt.V_Type " & _
                    " LEFT JOIN Store_Item Item ON Stk.Item = Item.Code  " & _
                    " LEFT JOIN Store_Unit Unit ON Item.Unit = Unit.Code  " & _
                    " LEFT JOIN Store_Item_Nature1 N1 ON Stk.Item_Nature1 = N1.Code  " & _
                    " LEFT JOIN Store_Item_Nature2 N2 ON Stk.Item_Nature2 = N2.Code  " & _
                    " LEFT JOIN Store_ItemGroup IGrp ON Item.ItemGroup = IGrp.Code  " & _
                    " LEFT JOIN Store_ItemCategory ICat ON Item.ItemCategory = ICat.Code  " & _
                    " LEFT JOIN Store_Godown G ON Stk.Godown = G.Code  " & _
                    " LEFT JOIN Store_Purchase Pur ON Stk.DocId = Pur.DocId  " & _
                    " LEFT JOIN Store_Sale Sale ON Stk.DocId = Sale.DocId  " & _
                    " LEFT JOIN Store_StockAdjustment StkAdj ON Stk.DocId = StkAdj.DocId " & _
                    " LEFT JOIN Sch_Department Dept ON " & bDepartmentCodeStr & " = Dept.Code " & _
                    " LEFT JOIN SubGroup Sg ON " & bPartyCodeStr & " = Sg.SubCode " & _
                    " LEFT JOIN AcGroup Ag ON Ag.GroupCode = Sg.GroupCode  " & _
                    " LEFT JOIN City ON Sg.CityCode = City.CityCode  " & _
                    " LEFT JOIN State ON City.State_Code = State.State_Code  " & _
                    " LEFT JOIN Country ON State.CountryCode = Country.Code "

            AgL.IsViewExist("ViewStore_Stock", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewStore_Stock", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub
    Public Sub InitializeTables()
        TB_PostingGroupSalesTaxParty()
        TB_ChargesType()

    End Sub

    Private Sub TB_PostingGroupSalesTaxParty()
        Dim mQry$

        If AgL.Dman_Execute("Select Count(*) From PostingGroupSalesTaxParty Where Description = '" & ClsMain.PostingGroupSalesTaxParty.Local & "'", AgL.GCn).ExecuteScalar = 0 Then
            mQry = "Insert Into PostingGroupSalesTaxParty (Description, Active) Values ('" & ClsMain.PostingGroupSalesTaxParty.Local & "',1)"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
        End If
    End Sub

    Public Sub InitializeStructure()
        Call ST_StoreGRN()
    End Sub
    Private Sub ST_StoreGRN()
        Dim mQry$ = "", bStrCode$ = Temp_Structure.StoreGRN, bStrNCat$ = ClsMain.Temp_NCat.StoreGRN
        Try
            If AgL.Dman_Execute("Select IsNull(Count(*),0) As Cnt From Structure With (NoLock) Where Code = '" & bStrCode & "'", AgL.GcnRead).ExecuteScalar = 0 Then
                mQry = "INSERT INTO dbo.Structure (Code, Description, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE) " & _
                                " VALUES ('" & bStrCode & "', '" & bStrCode & "', " & _
                        " '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                If AgL.Dman_Execute("Select IsNull(Count(*),0) As Cnt From StructureDetail With (NoLock) Where Code = '" & bStrCode & "'", AgL.GcnRead).ExecuteScalar = 0 Then
                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 10, '" & Temp_Charges.GrossAmount & "', 'Charges', 'FixedValue', NULL, '|Amount|', NULL, Null, NULL, NULL, 0, 1, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 20, '" & Temp_Charges.LineAddition & "', 'Charges', 'Percentage Or Amount', NULL, '{GAMT}*{LAdd}/100', NULL, NULL, NULL, NULL, 1, 1, 1, 0, 0, 0, 1, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 30, '" & Temp_Charges.LineDeduction & "', 'Charges', 'Percentage Or Amount', NULL, '{GAMT}*{LDed}/100', NULL, NULL, NULL, NULL, 1, 0, 1, 0, 0, 0, 1, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 40, '" & Temp_Charges.LineNetAmount & "', 'Charges', 'FixedValue', NULL, '{GAMT}+{LAdd}-{LDed}', NULL, NULL, NULL, NULL, 1, 1, 1, 0, 0, 0, 1, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 50, '" & Temp_Charges.HeaderAddition & "', 'Charges', 'Percentage Or Amount', NULL, '{LNAmt}*{HAdd}/100', 'Line Net Amount', NULL, NULL, NULL, 0, 1, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 60, '" & Temp_Charges.HeaderDeduction & "', 'Charges', 'Percentage Or Amount', NULL, '{LNAmt}*{HDed}/100', 'Line Net Amount', NULL, NULL, NULL, 0, 0, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 70, '" & Temp_Charges.NetSubTotal & "', 'Charges', 'FixedValue', NULL, '{LNAmt}+{HAdd}-{HDed}', NULL, NULL, NULL, NULL, 0, 1, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 80, '" & Temp_Charges.RoundOff & "', 'Charges', 'FixedValue', NULL, 'ROUND({NSTot},0)-{NSTot}', NULL, NULL, NULL, NULL, 0, 1, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Active, Percentage, Amount, VisibleInMaster, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, VisibleInMasterLine) " & _
                            " VALUES ('" & bStrCode & "', 90, '" & Temp_Charges.NetAmount & "', 'Charges', 'FixedValue', NULL, '{NSTot}+{ROff}', NULL, NULL, NULL, NULL, 0, 1, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, 0) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                End If

                '=====================================================================================================================================================================
                '====================< Update Structure Code In VoucherCat Table >====================================================================================================
                '=======================================< Start >=====================================================================================================================
                '=====================================================================================================================================================================
                mQry = "UPDATE VoucherCat SET Structure = " & AgL.Chk_Text(bStrCode) & " WHERE NCat = " & AgL.Chk_Text(bStrNCat) & " AND IsNull(Structure,'') <> " & AgL.Chk_Text(bStrCode) & ""
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                '=====================================================================================================================================================================
                '====================< Update Structure Code In VoucherCat Table >====================================================================================================
                '=======================================< End >=====================================================================================================================
                '=====================================================================================================================================================================

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub TB_ChargesType()
        Dim mQry As String = ""

        Try

            If AgL.IsTableExist("Charges", AgL.GCn) Then

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'GAMT') " & _
                            " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                            " VALUES ('GAMT', 'GAMT', 'GAMT','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)


                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'LAdd') " & _
                            " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                            " VALUES ('LAdd', 'LAdd', 'LAdd','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'LDed') " & _
                          " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                          " VALUES ('LDed', 'LDed', 'LDed','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'LNAmt') " & _
                        " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                        " VALUES ('LNAmt', 'LNAmt', 'LNAmt','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)


                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'HAdd') " & _
                        " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                        " VALUES ('HAdd', 'HAdd', 'HAdd','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'HDed') " & _
                       " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                       " VALUES ('HDed', 'HDed', 'HDed','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'NSTot') " & _
                     " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                     " VALUES ('NSTot', 'NSTot', 'NSTot','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'ROff') " & _
                   " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                   " VALUES ('ROff', 'ROff', 'ROff','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM Charges WHERE Code = 'NAMT') " & _
                  " INSERT INTO dbo.Charges (Code, Description, ManualCode, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE)" & _
                  " VALUES ('NAMT', 'NAMT', 'NAMT','" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class