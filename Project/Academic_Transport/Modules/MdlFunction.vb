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
            PLib.PubReportPath_Academic_Main = AgL.INIRead(StrIniPath, "Reports", "Academic_Main", AgL.PubReportPath)

            Academic_ProjLib.ClsMain.IsModuleActive_Transport = True

            FOpenIni = BlnRtn
        End Try
    End Function

    Public Sub IniDtEnviro()
        Call IniDtCommon_Enviro()
        Call IniDtTp_Enviro()
    End Sub

    Public Sub IniDtCommon_Enviro()
        DtCommon_Enviro = AgL.FillData("SELECT E.* FROM Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
    End Sub

    Public Sub IniDtTp_Enviro()
        If AgL.IsTableExist("Tp_Enviro", AgL.GCn) Then
            DtTp_Enviro = AgL.FillData("SELECT E.* FROM Tp_Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
        End If
    End Sub

    Public Function FunGetCurrentSemester(ByVal StrStudentCode As String) As String
        Dim bStrReturn$ = "", bQry$ = ""
        Dim GcnRead As SqlClient.SqlConnection
        Dim bDtTemp As DataTable = Nothing

        Try
            If StrStudentCode.Trim = "" Then Exit Function

            GcnRead = New SqlClient.SqlConnection
            GcnRead.ConnectionString = AgL.Gcn_ConnectionString
            GcnRead.Open()

            bQry = "SELECT Top 1 A.Student, P.FromStreamYearSemester, " & _
                    " A.V_Date AS AdmissionDate, A.LeavingDate " & _
                    " FROM Sch_Admission A With (NoLock) " & _
                    " INNER JOIN (SELECT Ap.* FROM Sch_AdmissionPromotion Ap With (NoLock) WHERE Ap.PromotionDate IS NULL) AS P ON A.DocId = P.AdmissionDocId " & _
                    " WHERE A.Student = " & AgL.Chk_Text(StrStudentCode) & " " & _
                    " Order By A.V_Date Desc "
            bDtTemp = AgL.FillData(bQry, GcnRead).Tables(0)
            If bDtTemp.Rows.Count > 0 Then
                bStrReturn = AgL.XNull(bDtTemp.Rows(0)("FromStreamYearSemester"))
            End If

        Catch ex As Exception
            bStrReturn = ""
        Finally
            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
            FunGetCurrentSemester = bStrReturn
        End Try
    End Function
End Module