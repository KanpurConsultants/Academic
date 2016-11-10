Imports System

Module ModMain
    Public Conn As SqlClient.SqlConnection
    Public Cmd As SqlClient.SqlCommand
    Public Agcl As New AgControls.AgLib
    Public mIniPath As String


    Public Function FOpenIniChkPwd() As Boolean
        Try
            mIniPath = My.Application.Info.DirectoryPath + "\" + IniName
            AgL.PubServerName = AgL.INIRead(mIniPath, "Server", "Name", "")
            AgL.PubCompanyDBName = AgL.INIRead(mIniPath, "CompanyInfo", "Path", "")
            AgL.PubDBPasswordSQL = AgL.XNull(AgL.DCODIFY(AgL.INIRead(mIniPath, "Security", "Password", "")))
            AgL.PubDBUserSQL = AgL.INIRead(mIniPath, "Security", "User", "SA")

            FOpenIniChkPwd = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Function ConnectDb(ByVal ServerName As String, ByVal DatabaseName As String, Optional ByVal DatabaseUser As String = "sa", Optional ByVal DatabasePassword As String = "") As String
        AgL.AglObj = AgL
        'AgL.PubDBUserSQL = "SA"
        AgL.GcnMain = New SqlClient.SqlConnection
        AgL.GcnMain_ConnectionString = "Persist Security Info=False;User ID='" & DatabaseUser & "';pwd=" & DatabasePassword & ";Initial Catalog=" & DatabaseName & ";Data Source=" & ServerName
        AgL.GcnMain.ConnectionString = AgL.GcnMain_ConnectionString
        ConnectDb = ""
        Try

            AgL.GcnMain.Open()
            AgL.ECmd = New SqlClient.SqlCommand
            AgL.ECmd = AgL.GcnMain.CreateCommand

        Catch ex As Exception
            ConnectDb = ex.Message
        End Try
    End Function



End Module
