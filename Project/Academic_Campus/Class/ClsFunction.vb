Public Class ClsFunction
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Dim CRepProc As ClsReportProcedures

    Public Function FOpen(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True, _
                            Optional ByVal StrUserPermission As String = "", Optional ByVal DTUP As DataTable = Nothing)

        Dim FrmObj As Form
        Dim ADMain As OleDb.OleDbDataAdapter = Nothing
        Dim MDI As New MDIMain

        'For User Permission Open
        If StrUserPermission.Trim = "" Then
            StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, StrSender, StrSenderText, DTUP)
            If AgL.PubDivisionList = "('')" Then AgL.PubDivisionList = "('" + AgL.PubDivCode + "')"
        End If
        ''For User Permission End 


        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuCapmusCompanyMaster.Name
                    FrmObj = New FrmCampusCompanyMaster(StrUserPermission, DTUP)

                Case MDI.mnuSessionCompanyEntry.Name
                    FrmObj = New FrmSessionCompanyAssignEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSessionCompanyAssignEntry).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.mnuPlacementEntry.Name
                    FrmObj = New FrmPlacementEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmPlacementEntry).FormType = Academic_ProjLib.TempTransaction.eFormType.Main



                Case Else
                    FrmObj = Nothing
            End Select
        Else
            ObjRepFormGlobal = New AgLibrary.RepFormGlobal(AgL)
            CRepProc = New ClsReportProcedures(ObjRepFormGlobal)
            CRepProc.GRepFormName = Replace(Replace(StrSenderText, "&", ""), " ", "")
            CRepProc.Ini_Grid()
            FrmObj = ObjRepFormGlobal
        End If
        If FrmObj IsNot Nothing Then
            FrmObj.Text = StrSenderText
        End If
        Return FrmObj
    End Function
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

