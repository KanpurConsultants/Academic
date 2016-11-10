Imports System.Data.SqlClient
Module MdlFunction
    Dim mQry As String = ""

    Public Function FOpenIni(ByVal StrIniPath As String, ByVal StrUserName As String, ByVal StrPassword As String) As Boolean
        Dim OLECmd As New OleDb.OleDbCommand
        Dim BlnRtn As Boolean = False
        Dim ECmd As SqlClient.SqlCommand

        Try
            AgL = New AgLibrary.ClsMain : AgL.AglObj = AgL

            ObjAgTemplate = New AgTemplate.ClsMain(AgL)
            ObjAgStructure = New AgStructure.ClsMain(AgL)


            AgL.PubDBUserSQL = "sa"
            AgL.PubDBPasswordSQL = ""

            'AgL.PubDBUserSQL = "dataman_ggi"
            'AgL.PubDBPasswordSQL = "dataman@ggi_lko" '""

            AgL.PubServerName = AgL.INIRead(StrIniPath, "Server", "Name", "")
            AgL.PubReportPath = AgL.INIRead(StrIniPath, "Reports", "Path", "")
            AgL.PubCompanyDBName = AgL.INIRead(StrIniPath, "CompanyInfo", "Path", "")
            AgL.PubChkPasswordSQL = AgL.INIRead(StrIniPath, "Security", "PasswordSQL", "")
            AgL.PubChkPasswordAccess = AgL.INIRead(StrIniPath, "Security", "PasswordAccess", "")


            AgL.PubReportPath = Academic_Library.My.Application.Info.DirectoryPath & "\Reports"
            AgL.PubReportFaPath = Academic_Library.My.Application.Info.DirectoryPath & "\ReportFA"


            AgIniVar = New AgLibrary.ClsIniVariables(AgL)

            BlnRtn = AgIniVar.FOpenIni(StrUserName, StrPassword)

            OLECmd = Nothing


        Catch Ex As Exception
            BlnRtn = False
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        Finally
            ECmd = Nothing
            AgPL = New AgLibrary.ClsPrinting(AgL)

            FOpenIni = BlnRtn
        End Try
    End Function

    Public Sub IniDtEnviro()
        Call IniDtCommon_Enviro()
        Call IniDtLib_Enviro()
    End Sub

    Public Sub IniDtCommon_Enviro()
        AgL.PubDtEnviro = AgL.FillData("SELECT E.* FROM Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
    End Sub

    Public Sub IniDtLib_Enviro()
        DtLib_Enviro = AgL.FillData("SELECT E.* FROM Lib_Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "' And E.Div_Code = '" & AgL.PubDivCode & "' ", AgL.GCn).Tables(0)
    End Sub

    Public Function RetDefaultGodown(ByVal bSite_Code As String, ByVal bDiv_Code As String, ByVal bItemType As String) As String
        Dim bGodown$ = ""
        Try
            mQry = "SELECT G.Godown FROM EnviroDefaultGodown G " & _
                    " WHERE G.Site_Code = '" & bSite_Code & "'  " & _
                    " AND G.Div_Code = '" & bDiv_Code & "' " & _
                    " AND G.ItemType = '" & bItemType & "'"
            bGodown = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            RetDefaultGodown = bGodown
        Catch ex As Exception
            RetDefaultGodown = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function FunRetStock(ByVal bItem As String, ByVal bInternalCode As String, _
                                   Optional ByVal bGodown As String = "", _
                                   Optional ByVal bProcess As String = "", _
                                   Optional ByVal bStatus As String = "") As Double
        Dim bConStr$ = ""
        Dim bStockQty As Double = 0

        Try
            bConStr = "WHERE S.Item = '" & bItem & "' "
            bConStr += " And " & IIf(bGodown <> "", "S.Godown = '" & bGodown & "'", "1=1") & ""
            bConStr += " And " & IIf(bProcess <> "", "IsNull(S.Process,'') = '" & bProcess & "'", "1=1") & ""
            bConStr += " And " & IIf(bStatus <> "", "IsNull(S.Status,'" & AgTemplate.ClsMain.StockStatus.Standard & "') = '" & bStatus & "'", "1=1") & ""
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

    Public Sub ProcStockPost(ByVal bTableName As String, ByVal bStock As ClsMain.StructStock, _
                              ByVal bConn As SqlClient.SqlConnection, _
                              ByVal bCmd As SqlClient.SqlCommand)
        Try
            With bStock
                mQry = "INSERT INTO " & bTableName & "(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                        " SubCode, Currency, SalesTaxGroupParty, Structure, BillingType, Item, ProcessGroup, " & _
                        " Godown, Qty_Iss, Qty_Rec, Unit, MeasurePerPcs, Measure_Iss, Measure_Rec, MeasureUnit, " & _
                        " Rate, Amount, Addition, Deduction, NetAmount, Remarks, Status, UID, Process, " & _
                        " FIFORate, FIFOAmt, AVGRate, AVGAmt, Cost, Doc_Qty, ReferenceDocID) " & _
                        " VALUES (" & AgL.Chk_Text(.DocID) & ", " & Val(.Sr) & ", " & _
                        " " & AgL.Chk_Text(.V_Type) & ", " & AgL.Chk_Text(.V_Prefix) & ", " & _
                        " " & AgL.ConvertDate(.V_Date) & ",	" & Val(.Sr) & ", " & AgL.Chk_Text(.Div_Code) & ", " & _
                        " " & AgL.Chk_Text(.Site_Code) & ",	" & AgL.Chk_Text(.SubCode) & ",	" & _
                        " " & AgL.Chk_Text(.Currency) & ", " & AgL.Chk_Text(.SalesTaxGroupParty) & ", " & _
                        " " & AgL.Chk_Text(.Structure1) & ", " & AgL.Chk_Text(.BillingType) & ", " & _
                        " " & AgL.Chk_Text(.Item) & ",	" & AgL.Chk_Text(.ProcessGroup) & ", " & _
                        " " & AgL.Chk_Text(.Godown) & ", " & Val(.Qty_Iss) & ",	" & Val(.Qty_Rec) & ", " & AgL.Chk_Text(.Unit) & ", " & _
                        " " & Val(.MeasurePerPcs) & ",	" & Val(.Measure_Iss) & ",	" & Val(.Measure_Rec) & ",	" & _
                        " " & AgL.Chk_Text(.MeasureUnit) & ", " & Val(.Rate) & ", " & _
                        " " & Val(.Amount) & ",	" & Val(.Addition) & ",	" & Val(.Deduction) & ", " & _
                        " " & Val(.NetAmount) & ",	" & AgL.Chk_Text(.Remarks) & ",	" & AgL.Chk_Text(.Status) & ",	" & _
                        " " & AgL.Chk_Text(.UID) & ", " & AgL.Chk_Text(.Process) & ", " & Val(.FIFORate) & ", " & _
                        " " & Val(.FIFOAmt) & ", " & Val(.AVGRate) & ",	" & Val(.AVGAmt) & ", " & _
                        " " & Val(.Cost) & ", " & Val(.Doc_Qty) & ", " & AgL.Chk_Text(.ReferenceDocID) & ") "
                AgL.Dman_ExecuteNonQry(mQry, bConn, bCmd)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Module