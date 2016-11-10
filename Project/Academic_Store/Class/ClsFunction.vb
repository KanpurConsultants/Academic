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
            StrUserPermission = AgIniVar.FunGetUserPermission(Academic_Objects.ClsConstant.Module_Academic_Store, StrSender, StrSenderText, DTUP)
        End If
        ''For User Permission End 

        If IsEntryPoint Then
            Select Case StrSender
                'Changed by akash on date 18-9-10
                Case MDI.MnuPurchaseEntry.Name, MDI.MnuPurchaseEntryAuthenticated.Name
                    FrmObj = New FrmPurchase(StrUserPermission, DTUP)

                Case MDI.MnuSaleEntry.Name, MDI.MnuSaleEntryAuthenticated.Name
                    FrmObj = New FrmSale(StrUserPermission, DTUP)

                    'end change 

                Case MDI.MnuUnitMaster.Name
                    FrmObj = New FrmUnit(StrUserPermission, DTUP)


                Case MDI.mnuRequisition.Name
                    FrmObj = New FrmRequisition(StrUserPermission, DTUP)

                Case MDI.mnuPurchaseIndentEntry.Name
                    FrmObj = New FrmPurchaseIndent(StrUserPermission, DTUP)

                Case MDI.mnuSupplier.Name
                    FrmObj = New FrmSupplier(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSupplier).FormType = Academic_ProjLib.TempParty.eFormType.Main
                    CType(FrmObj, FrmSupplier).MasterType = ClsMain.PartyMasterType.Supplier
                    CType(FrmObj, FrmSupplier).Party_Type = AgLibrary.ClsConstant.SubGroupType_Other
                    CType(FrmObj, FrmSupplier).MsCode = AgLibrary.ClsConstant.MainGRCodeSundryCreditors


                Case MDI.mnuPurchaseOrder.Name
                    FrmObj = New FrmPurchaseOrder(StrUserPermission, DTUP)

                Case MDI.MnuGRNEntry.Name
                    FrmObj = New FrmGRN(StrUserPermission, DTUP)

                Case MDI.MnuItemCategoryMaster.Name
                    FrmObj = New FrmItemCategory(StrUserPermission, DTUP)
                    CType(FrmObj, FrmItemCategory).ItemType = ClsMain.ItemType.Store

                Case MDI.MnuItemGroup.Name
                    FrmObj = New FrmItemGroup(StrUserPermission, DTUP)
                    CType(FrmObj, FrmItemGroup).ItemType = ClsMain.ItemType.Store

                Case MDI.MnuItem.Name
                    FrmObj = New FrmItem(StrUserPermission, DTUP)
                    CType(FrmObj, FrmItem).ItemType = ClsMain.ItemType.Store

                Case MDI.MnuVehicleGateEntry.Name
                    FrmObj = New FrmVehicleGateInOut(StrUserPermission, DTUP)

                Case MDI.MnuItemIssueEntry.Name, MDI.MnuItemReceiveEntry.Name, MDI.MnuOpeningStockEntry.Name
                    FrmObj = New FrmissueReceive(StrUserPermission, DTUP)

                Case MDI.MnuEnvironmentSettings.Name
                    FrmObj = New FrmEnviro(StrUserPermission, DTUP)

                Case MDI.MnuGodownMaster.Name
                    FrmObj = New FrmGodown(StrUserPermission, DTUP)

                    'Case MDI.MnuSupplierBillEntry.Name
                    '    FrmObj = New FrmSupplierBill(StrUserPermission, DTUP)

                    'Code By Akash on date 18-9-10
                    'Case MDI.MnuSaleEntryAuthenticated.Name
                    '    FrmObj = New FrmSale(StrUserPermission, DTUP)

                    'Case MDI.MnuPurchaseEntryAuthenticated.Name
                    '    FrmObj = New FrmPurchase(StrUserPermission, DTUP)
                    'End Change 

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

