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
                Case MDI.MnuEnvironmentSettings.Name
                    FrmObj = New FrmEnviro(StrUserPermission, DTUP)

                Case MDI.MnuUnitMaster.Name
                    FrmObj = New FrmUnit(StrUserPermission, DTUP)

                Case MDI.MnuItemCategory.Name
                    FrmObj = New FrmItemCategory(StrUserPermission, DTUP)
                    CType(FrmObj, FrmItemCategory).ItemType = ClsMain.ItemType.Mess

                Case MDI.MnuItemGroupMaster.Name
                    FrmObj = New FrmItemGroup(StrUserPermission, DTUP)
                    CType(FrmObj, FrmItemGroup).ItemType = ClsMain.ItemType.Mess

                Case MDI.MnuItemMaster.Name
                    FrmObj = New FrmItem(StrUserPermission, DTUP)
                    CType(FrmObj, FrmItem).ItemType = ClsMain.ItemType.Mess

                Case MDI.MnuItemBOMMaster.Name
                    FrmObj = New FrmBOM(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBOM).ItemType = ClsMain.ItemType.Mess

                Case MDI.MnuGodownMaster.Name
                    FrmObj = New FrmGodown(StrUserPermission, DTUP)

                Case MDI.MnuMemberMaster.Name
                    FrmObj = New FrmMessMember(StrUserPermission, DTUP)

                Case MDI.MnuSupplierMaster.Name
                    FrmObj = New FrmSupplier(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSupplier).FormType = Academic_ProjLib.TempParty.eFormType.Main
                    CType(FrmObj, FrmSupplier).MasterType = ClsMain.PartyMasterType.Supplier
                    CType(FrmObj, FrmSupplier).Party_Type = AgLibrary.ClsConstant.SubGroupType_Other
                    CType(FrmObj, FrmSupplier).MsCode = AgLibrary.ClsConstant.MainGRCodeSundryCreditors

                Case MDI.MnuPurchaseEntry.Name
                    FrmObj = New FrmMessPurchase(StrUserPermission, DTUP)
                    CType(FrmObj, FrmMessPurchase).FormType = Academic_ProjLib.TempTransaction.eFormType.Main
                    CType(FrmObj, FrmMessPurchase).QuantityType = Academic_ProjLib.TempPurchase.eQuantityType.Receive
                    CType(FrmObj, FrmMessPurchase).ManageStock = True
                    CType(FrmObj, FrmMessPurchase).ManageAccount = True

                Case MDI.MnuPurchaseReturnEntry.Name
                    FrmObj = New FrmMessPurchaseReturn(StrUserPermission, DTUP)
                    CType(FrmObj, FrmMessPurchaseReturn).FormType = Academic_ProjLib.TempTransaction.eFormType.Main
                    CType(FrmObj, FrmMessPurchaseReturn).QuantityType = Academic_ProjLib.TempPurchase.eQuantityType.Issue
                    CType(FrmObj, FrmMessPurchaseReturn).ManageStock = True
                    CType(FrmObj, FrmMessPurchaseReturn).ManageAccount = True


                Case MDI.MnuMessMenuCreateEntry.Name
                    FrmObj = New FrmMenu(StrUserPermission, DTUP)
                    CType(FrmObj, FrmMenu).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuMemberLeaveEntry.Name
                    FrmObj = New FrmMemberLeaveEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmMemberLeaveEntry).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuAttendanceEntry.Name
                    FrmObj = New FrmAttendanceEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmAttendanceEntry).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuExtraPersonEntry.Name
                    FrmObj = New FrmExtraPersonEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmExtraPersonEntry).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuMessConsumptionEntry.Name
                    FrmObj = New FrmConsumptionEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmConsumptionEntry).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuStockAdjustmentEntry.Name
                    FrmObj = New FrmMessStockAdjustment(StrUserPermission, DTUP)
                    CType(FrmObj, FrmMessStockAdjustment).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

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

    Public Function FOpen_Attendance(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True, _
                            Optional ByVal StrUserPermission As String = "", Optional ByVal DTUP As DataTable = Nothing)

        Dim FrmObj As Form
        Dim ADMain As OleDb.OleDbDataAdapter = Nothing
        Dim MDI As New MDI_Attendance

        'For User Permission Open
        If StrUserPermission.Trim = "" Then
            StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, StrSender, StrSenderText, DTUP)
            If AgL.PubDivisionList = "('')" Then AgL.PubDivisionList = "('" + AgL.PubDivCode + "')"
        End If
        ''For User Permission End 


        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuEnvironmentSettings.Name
                    FrmObj = New FrmEnviro(StrUserPermission, DTUP)

                Case MDI.MnuMemberMaster.Name
                    FrmObj = New FrmMessMember(StrUserPermission, DTUP)

                Case MDI.MnuMemberLeaveEntry.Name
                    FrmObj = New FrmMemberLeaveEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmMemberLeaveEntry).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

                Case MDI.MnuAttendanceEntry.Name
                    FrmObj = New FrmAttendanceEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmAttendanceEntry).FormType = Academic_ProjLib.TempTransaction.eFormType.Main

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

