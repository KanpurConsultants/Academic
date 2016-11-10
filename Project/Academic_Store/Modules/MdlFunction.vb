Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Module MdlFunction
    Public Function FOpenIni(ByVal StrIniPath As String, ByVal StrUserName As String, ByVal StrPassword As String) As Boolean
        Dim OLECmd As New OleDb.OleDbCommand
        Dim BlnRtn As Boolean = False
        Dim ECmd As SqlClient.SqlCommand

        Try
            AgL = New AgLibrary.ClsMain : AgL.AglObj = AgL

            AgL.PubDBUserSQL = "sa"
            AgL.PubDBPasswordSQL = ""
            AgL.PubServerName = AgL.INIRead(StrIniPath, "Server", "Name", "")
            AgL.PubReportPath = AgL.INIRead(StrIniPath, "Reports", "Path", "")
            AgL.PubCompanyDBName = AgL.INIRead(StrIniPath, "CompanyInfo", "Path", "")
            AgL.PubChkPasswordSQL = AgL.INIRead(StrIniPath, "Security", "PasswordSQL", "")
            AgL.PubChkPasswordAccess = AgL.INIRead(StrIniPath, "Security", "PasswordAccess", "")

            AgL.PubReportPath_CommonData = AgL.INIRead(StrIniPath, "Reports", "CommonData", AgL.PubReportPath)
            AgL.PubReportPath_Utility = AgL.INIRead(StrIniPath, "Reports", "Utility", AgL.PubReportPath)
            AgL.PubReportPath_Store = AgL.INIRead(StrIniPath, "Reports", "Store", AgL.PubReportPath)

            AgIniVar = New AgLibrary.ClsIniVariables(AgL)

            BlnRtn = AgIniVar.FOpenIni(StrUserName, StrPassword)

            OLECmd = Nothing
        Catch Ex As Exception
            BlnRtn = False
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        Finally
            ECmd = Nothing
            PLib = New Academic_ProjLib.ClsMain(AgL)
            AgPL = New AgLibrary.ClsPrinting(AgL)
            PObj = New Academic_Objects.ClsMain(AgL, PLib)
            FOpenIni = BlnRtn
        End Try
    End Function

    Public Sub IniDtEnviro()
        Call IniDtCommon_Enviro()
        Call IniDtStore_Enviro()
    End Sub

    Public Sub IniDtCommon_Enviro()
        DtCommon_Enviro = AgL.FillData("SELECT E.* FROM Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
    End Sub

    Public Sub IniDtStore_Enviro()
        If Not AgL.IsTableExist("Store_Enviro", AgL.GCn) Then Exit Sub
        DtStore_Enviro = AgL.FillData("SELECT E.* FROM Store_Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
        Call Ini_Enviro()
    End Sub

    Public Sub Ini_Enviro()
        With DtStore_Enviro
            If DtStore_Enviro.Rows.Count > 0 Then
                ClsVar.PurchaseAc = AgL.XNull(.Rows(0)("PurchaseAc"))
                ClsVar.PurchaseAdditionAc = AgL.XNull(.Rows(0)("PurchaseAdditionAc"))
                ClsVar.PurchaseAddition_HAc = AgL.XNull(.Rows(0)("PurchaseAddition_HAc"))
                ClsVar.PurchaseDeductionAc = AgL.XNull(.Rows(0)("PurchaseDeductionAc"))
                ClsVar.PurchaseDeduction_HAc = AgL.XNull(.Rows(0)("PurchaseDeduction_HAc"))

                ClsVar.SaleAc = AgL.XNull(.Rows(0)("SaleAc"))
                ClsVar.SaleAdditionAc = AgL.XNull(.Rows(0)("SaleAdditionAc"))
                ClsVar.SaleAddition_HAc = AgL.XNull(.Rows(0)("SaleAddition_HAc"))
                ClsVar.SaleDeductionAc = AgL.XNull(.Rows(0)("SaleDeductionAc"))
                ClsVar.SaleDeduction_HAc = AgL.XNull(.Rows(0)("SaleDeduction_HAc"))

                ClsVar.PurchaseAddition_Text = AgL.XNull(.Rows(0)("PurchaseAddition_Text"))
                ClsVar.PurchaseAddition_H_Text = AgL.XNull(.Rows(0)("PurchaseAddition_H_Text"))
                ClsVar.PurchaseDeduction_Text = AgL.XNull(.Rows(0)("PurchaseDeduction_Text"))
                ClsVar.PurchaseDeduction_H_Text = AgL.XNull(.Rows(0)("PurchaseDeduction_H_Text"))

                ClsVar.SaleAddition_Text = AgL.XNull(.Rows(0)("SaleAddition_Text"))
                ClsVar.SaleAddition_H_Text = AgL.XNull(.Rows(0)("SaleAddition_H_Text"))
                ClsVar.SaleDeduction_Text = AgL.XNull(.Rows(0)("SaleDeduction_Text"))
                ClsVar.SaleDeduction_H_Text = AgL.XNull(.Rows(0)("SaleDeduction_H_Text"))

                ClsVar.Item_Nature1_Description = AgL.XNull(.Rows(0)("Item_Nature1_Text"))
                ClsVar.Item_Nature2_Description = AgL.XNull(.Rows(0)("Item_Nature2_Text"))
                ClsVar.Item_Batch_Description = AgL.XNull(.Rows(0)("ItemBatch_Text"))
            Else
                'MsgBox("Store Environment Settings Not Defined")
            End If
        End With

    End Sub
End Module