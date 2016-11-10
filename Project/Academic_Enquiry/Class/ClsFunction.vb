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
        End If
        ''For User Permission End 


        If IsEntryPoint Then
            Select Case StrSender

                Case MDI.MnuEnvironmentSettings.Name
                    FrmObj = New FrmEnviro(StrUserPermission, DTUP)

                Case MDI.MnuGodownMaster.Name
                    FrmObj = New FrmGodown(StrUserPermission, DTUP)

                Case MDI.mnuProspectusMaster.Name
                    FrmObj = New FrmProspectusMaster(StrUserPermission, DTUP)
                    CType(FrmObj, FrmProspectusMaster).ItemType = ClsMain.ItemType.Prospectus

                Case MDI.MnuEnquiryEntry.Name
                    FrmObj = New FrmEnquiryEntry(StrUserPermission, DTUP)

                Case MDI.mnuEnquiryAssignEntry.Name
                    FrmObj = New FrmEnquiryReAssignEntry()

                Case MDI.MnuEnquiryFollowup.Name
                    FrmObj = New FrmFollowupEntry(StrUserPermission, DTUP)

                Case MDI.MnuEnquiryFollowupReminder.Name
                    FrmObj = New FrmFollowupReminder()

                Case MDI.mnuProspectusPurchase.Name
                    FrmObj = New FrmProspectusPurchase(StrUserPermission, DTUP)
                    CType(FrmObj, FrmProspectusPurchase).FormType = Academic_ProjLib.TempTransaction.eFormType.Main
                    CType(FrmObj, FrmProspectusPurchase).QuantityType = Academic_ProjLib.TempPurchase.eQuantityType.Receive
                    CType(FrmObj, FrmProspectusPurchase).ManageStock = True
                    CType(FrmObj, FrmProspectusPurchase).ManageAccount = True

                Case MDI.MnuSupplierMaster.Name
                    FrmObj = New FrmSupplier(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSupplier).FormType = Academic_ProjLib.TempParty.eFormType.Main
                    CType(FrmObj, FrmSupplier).MasterType = ClsMain.PartyMasterType.Supplier
                    CType(FrmObj, FrmSupplier).Party_Type = AgLibrary.ClsConstant.SubGroupType_Other
                    CType(FrmObj, FrmSupplier).MsCode = AgLibrary.ClsConstant.MainGRCodeSundryCreditors

                Case MDI.mnuProspectusSale.Name
                    FrmObj = New FrmProspectusSale(StrUserPermission, DTUP)
                    CType(FrmObj, FrmProspectusSale).FormType = Academic_ProjLib.TempTransaction.eFormType.Main
                    CType(FrmObj, FrmProspectusSale).QuantityType = Academic_ProjLib.TempPurchase.eQuantityType.Issue
                    CType(FrmObj, FrmProspectusSale).ManageStock = True
                    CType(FrmObj, FrmProspectusSale).ManageAccount = True

                Case MDI.mnuProspectusStockAdjustment.Name
                    FrmObj = New FrmProspectusStockAdjustment(StrUserPermission, DTUP)
                    CType(FrmObj, FrmProspectusStockAdjustment).FormType = Academic_ProjLib.TempTransaction.eFormType.Main


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

