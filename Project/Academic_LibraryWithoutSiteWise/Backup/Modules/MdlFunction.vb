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
            ObjAgTemplate_Common = New AgTemplate_Common.ClsMain(AgL)
            ObjAgTemplate_Sale = New AgTemplate_Sale.ClsMain(AgL)
            ObjAgTemplate_Production = New AgTemplate_Production.ClsMain(AgL)


            AgL.PubDBUserSQL = "sa"
            AgL.PubDBPasswordSQL = ""
            AgL.PubServerName = AgL.INIRead(StrIniPath, "Server", "Name", "")
            AgL.PubReportPath = AgL.INIRead(StrIniPath, "Reports", "Path", "")
            AgL.PubCompanyDBName = AgL.INIRead(StrIniPath, "CompanyInfo", "Path", "")
            AgL.PubChkPasswordSQL = AgL.INIRead(StrIniPath, "Security", "PasswordSQL", "")
            AgL.PubChkPasswordAccess = AgL.INIRead(StrIniPath, "Security", "PasswordAccess", "")


            AgL.PubReportPath = RUG_Main.My.Application.Info.DirectoryPath & "\Reports"
            AgL.PubReportFaPath = RUG_Main.My.Application.Info.DirectoryPath & "\ReportFA"


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
        Call IniDtRug_Enviro()
    End Sub

    Public Sub IniDtCommon_Enviro()
        DtCommon_Enviro = AgL.FillData("SELECT E.* FROM Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
    End Sub

    Public Sub IniDtRug_Enviro()
        DtRug_Enviro = AgL.FillData("SELECT E.* FROM Rug_Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "' And E.Div_Code = '" & AgL.PubDivCode & "' ", AgL.GCn).Tables(0)
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
End Module