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

            Academic_ProjLib.ClsMain.IsModuleActive_AcademicMain = True
            Academic_ProjLib.ClsMain.IsModuleActive_FeeModule = True
            Academic_ProjLib.ClsMain.IsModuleActive_Library = True
            Academic_ProjLib.ClsMain.IsModuleActive_Enquiry = True
            Academic_ProjLib.ClsMain.IsModuleActive_Transport = True
            Academic_ProjLib.ClsMain.IsModuleActive_Mess = True

            FOpenIni = BlnRtn
        End Try
    End Function

    Public Sub IniDtEnviro()
        Call IniDtCommon_Enviro()
        Call IniDtSch_Enviro()
    End Sub
    
    Public Sub IniDtCommon_Enviro()
        DtCommon_Enviro = AgL.FillData("SELECT E.* FROM Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
    End Sub

    Public Sub IniDtSch_Enviro()
        DtSch_Enviro = AgL.FillData("SELECT E.* FROM Sch_Enviro E WHERE E.Site_Code ='" & AgL.PubSiteCode & "'", AgL.GCn).Tables(0)
    End Sub


    Public Function FunIsDateLock(ByVal StrDate As String) As Boolean
        Dim bBlnReturn As Boolean = False
        Dim bIntLockBackDays% = 0
        Try
            If CDate(StrDate) > CDate(AgL.PubLoginDate) Then
                bBlnReturn = True
            Else
                If DtSch_Enviro.Rows.Count > 0 Then
                    bIntLockBackDays = AgL.VNull(DtSch_Enviro.Rows(0)("LockBackDays"))
                    If bIntLockBackDays > 0 Then
                        If DateDiff(DateInterval.Day, CDate(StrDate), CDate(AgL.PubLoginDate)) > bIntLockBackDays Then
                            bBlnReturn = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunIsDateLock = bBlnReturn
        End Try
    End Function
End Module