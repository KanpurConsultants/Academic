Public Class ClsFunction
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Dim CRepProc As ClsReportProcedures

    Public Function FOpen(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True)
        Dim FrmObj As Form
        Dim StrUserPermission As String
        Dim DTUP As New DataTable
        Dim ADMain As OleDb.OleDbDataAdapter = Nothing
        Dim MDI As New MDIMain

        'For User Permission Open
        StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, StrSender, StrSenderText, DTUP)
        ''For User Permission End 


        If IsEntryPoint Then
            Select Case StrSender

                Case MDI.MnuUserMaster.Name
                    FrmObj = New FrmUser(StrUserPermission, DTUP, AgL)

                Case MDI.MnuUserPermission.Name
                    FrmObj = New FrmUserPermission(StrUserPermission, DTUP, AgL)


                Case MDI.MnuStructureMaster.Name
                    FrmObj = New AgStructure.FrmStructure(StrUserPermission, DTUP)

                Case MDI.MnuHeadMaster.Name
                    FrmObj = New AgStructure.FrmCharges(StrUserPermission, DTUP)

                Case MDI.MnuStructurePostingHead.Name
                    FrmObj = New AgStructure.FrmStructureAcPosting(StrUserPermission, DTUP)

                Case MDI.MnuUserPermission.Name
                    FrmObj = New FrmUserPermission(StrUserPermission, DTUP, AgL)

                Case MDI.MnuUserControlPermission.Name
                    FrmObj = New FrmUserControlPermission(StrUserPermission, DTUP, AgL)

                Case MDI.MnuUserTarget.Name
                    FrmObj = New FrmUserTarget(StrUserPermission, DTUP)

                Case MDI.MnuBackupDatabase.Name
                    FrmObj = New AgLibrary.FrmBackupDatase(AgL)

                Case MDI.MnuUserLoginPasswardChange.Name
                    FrmObj = New FrmUserPasswardChange("*E**", DTUP, AgL)

                Case MDI.MnuSitePermission.Name
                    FrmObj = New FrmUserSite(StrUserPermission, DTUP, AgL)

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

