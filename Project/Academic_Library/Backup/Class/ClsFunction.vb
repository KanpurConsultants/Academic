Public Class ClsFunction
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Dim CRepProc As ClsReportProcedures

    Public Function FOpen(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True)
        Dim mQry As String = ""
        Dim FrmObj As Form
        Dim StrUserPermission As String
        Dim DTUP As New DataTable
        Dim ADMain As OleDb.OleDbDataAdapter = Nothing
        Dim MDI As New MDIMain

        'For User Permission Open
        StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, StrSender, StrSenderText, DTUP)

        If AgL.PubDivisionList = "('')" Then AgL.PubDivisionList = "('" + AgL.PubDivCode + "')"

        ''For User Permission End 

        If IsEntryPoint Then
            Select Case StrSender

                Case MDI.MnuTaxPostingGroup.Name
                    FrmObj = New FrmTaxPostingGroupEntry()

                Case MDI.MnuUndyedYarnPlanningEntryLog.Name
                    FrmObj = New FrmUndyedYarnPlan(StrUserPermission, DTUP)
                    CType(FrmObj, FrmUndyedYarnPlan).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuUndyedYarnPlanningEntry.Name
                    FrmObj = New FrmUndyedYarnPlan(StrUserPermission, DTUP)
                    CType(FrmObj, FrmUndyedYarnPlan).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuOtherMaterialTransferReceiveEntryLog.Name
                    FrmObj = New FrmOtherMaterialTransferReceive(StrUserPermission, DTUP)
                    CType(FrmObj, FrmOtherMaterialTransferReceive).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuOtherMaterialTransferReceiveEntry.Name
                    FrmObj = New FrmOtherMaterialTransferReceive(StrUserPermission, DTUP)
                    CType(FrmObj, FrmOtherMaterialTransferReceive).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuYarnSkuTransferReceiveEntryLog.Name
                    FrmObj = New FrmYarnSKUTransferReceive(StrUserPermission, DTUP)
                    CType(FrmObj, FrmYarnSKUTransferReceive).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuYarnSkuTransferReceiveEntry.Name
                    FrmObj = New FrmYarnSKUTransferReceive(StrUserPermission, DTUP)
                    CType(FrmObj, FrmYarnSKUTransferReceive).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuCarpetTransferReceiveEntryLog.Name
                    FrmObj = New FrmCarpetTransferReceive(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetTransferReceive).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuCarpetTransferReceiveEntry.Name
                    FrmObj = New FrmCarpetTransferReceive(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetTransferReceive).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuOtherMaterialTransferIssueEntryLog.Name
                    FrmObj = New FrmOtherMaterialTransferIssue(StrUserPermission, DTUP)
                    CType(FrmObj, FrmOtherMaterialTransferIssue).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuOtherMaterialTransferIssueEntry.Name
                    FrmObj = New FrmOtherMaterialTransferIssue(StrUserPermission, DTUP)
                    CType(FrmObj, FrmOtherMaterialTransferIssue).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuYarnSkuTransferIssueEntryLog.Name
                    FrmObj = New FrmYarnSKUTransferIssue(StrUserPermission, DTUP)
                    CType(FrmObj, FrmYarnSKUTransferIssue).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuYarnSkuTransferIssueEntry.Name
                    FrmObj = New FrmYarnSKUTransferIssue(StrUserPermission, DTUP)
                    CType(FrmObj, FrmYarnSKUTransferIssue).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuCarpetTransferIssueEntryLog.Name
                    FrmObj = New FrmCarpetTransferIssue(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetTransferIssue).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuCarpetTransferIssueEntry.Name
                    FrmObj = New FrmCarpetTransferIssue(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetTransferIssue).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuOtherMaterialPlanningEntryLog.Name
                    FrmObj = New FrmOtherMaterialPlan(StrUserPermission, DTUP)
                    CType(FrmObj, FrmOtherMaterialPlan).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuOtherMaterialPlanningEntry.Name
                    FrmObj = New FrmOtherMaterialPlan(StrUserPermission, DTUP)
                    CType(FrmObj, FrmOtherMaterialPlan).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuOtherMaterialOpeningStockEntryLog.Name
                    FrmObj = New FrmOtherMaterialOpeningStock(StrUserPermission, DTUP)
                    CType(FrmObj, FrmOtherMaterialOpeningStock).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuOtherMaterialOpeningStockEntry.Name
                    FrmObj = New FrmOtherMaterialOpeningStock(StrUserPermission, DTUP)
                    CType(FrmObj, FrmOtherMaterialOpeningStock).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuYarnPlanningEntryLog.Name
                    FrmObj = New FrmCarpetMaterialPlan(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetMaterialPlan).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuYarnPlanningEntry.Name
                    FrmObj = New FrmCarpetMaterialPlan(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetMaterialPlan).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuYarnSkuOpeningStockEntryLog.Name
                    FrmObj = New FrmYarnSKUOpeningStock(StrUserPermission, DTUP)
                    CType(FrmObj, FrmYarnSKUOpeningStock).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuYarnSkuOpeningStockEntry.Name
                    FrmObj = New FrmYarnSKUOpeningStock(StrUserPermission, DTUP)
                    CType(FrmObj, FrmYarnSKUOpeningStock).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuPcsPlanningEntryLog.Name
                    FrmObj = New FrmCarpetProductionPlan(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetProductionPlan).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuPcsPlanningEntry.Name
                    FrmObj = New FrmCarpetProductionPlan(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetProductionPlan).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuGodownMasterLog.Name
                    FrmObj = New AgTemplate_Common.FrmGodown(StrUserPermission, DTUP)
                    CType(FrmObj, AgTemplate_Common.FrmGodown).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuGodownMaster.Name
                    FrmObj = New AgTemplate_Common.FrmGodown(StrUserPermission, DTUP)
                    CType(FrmObj, AgTemplate_Common.FrmGodown).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuCarpetOpeningStockEntryLog.Name
                    FrmObj = New FrmCarpetOpeningStock(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetOpeningStock).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuCarpetOpeningStockEntry.Name
                    FrmObj = New FrmCarpetOpeningStock(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetOpeningStock).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuProductionOrderEntryLog.Name
                    FrmObj = New FrmCarpetProductionOrder(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetProductionOrder).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuProductionOrderEntry.Name
                    FrmObj = New FrmCarpetProductionOrder(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetProductionOrder).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuExportOrderEntryLog.Name
                    FrmObj = New FrmCarpetSaleOrder(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetSaleOrder).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuExportOrderEntry.Name
                    FrmObj = New FrmCarpetSaleOrder(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetSaleOrder).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuCarpetSKUConsumptionMasterLog.Name
                    FrmObj = New FrmCarpetSkuConsumption(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetSkuConsumption).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuCarpetSKUConsumptionMasterMaster.Name
                    FrmObj = New FrmCarpetSkuConsumption(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetSkuConsumption).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuQualityMasterLog.Name
                    FrmObj = New FrmQuality1(StrUserPermission, DTUP)
                    CType(FrmObj, FrmQuality1).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuQualityMaster.Name
                    FrmObj = New FrmQuality1(StrUserPermission, DTUP)
                    CType(FrmObj, FrmQuality1).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuDesignMasterLog.Name
                    FrmObj = New FrmDesign(StrUserPermission, DTUP)
                    CType(FrmObj, FrmDesign).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuDesignMaster.Name
                    FrmObj = New FrmDesign(StrUserPermission, DTUP)
                    CType(FrmObj, FrmDesign).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuYarnMasterLog.Name
                    FrmObj = New FrmYarnMaster(StrUserPermission, DTUP)
                    CType(FrmObj, FrmYarnMaster).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuYarnMaster.Name
                    FrmObj = New FrmYarnMaster(StrUserPermission, DTUP)
                    CType(FrmObj, FrmYarnMaster).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuShadeMasterLog.Name
                    FrmObj = New FrmShade(StrUserPermission, DTUP)
                    CType(FrmObj, FrmShade).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuShadeMaster.Name
                    FrmObj = New FrmShade(StrUserPermission, DTUP)
                    CType(FrmObj, FrmShade).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuYarnSkuMasterLog.Name
                    FrmObj = New FrmYarnSKU(StrUserPermission, DTUP)
                    CType(FrmObj, FrmYarnSKU).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuYarnSKUMaster.Name
                    FrmObj = New FrmYarnSKU(StrUserPermission, DTUP)
                    CType(FrmObj, FrmYarnSKU).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuSizeMasterLog.Name
                    FrmObj = New FrmSize(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSize).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuSizeMaster.Name
                    FrmObj = New FrmSize(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSize).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuBuyerMasterLog.Name
                    FrmObj = New FrmBuyerMaster(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBuyerMaster).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBuyerMaster.Name
                    FrmObj = New FrmBuyerMaster(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBuyerMaster).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuPortMasterLog.Name
                    FrmObj = New FrmPortMaster(StrUserPermission, DTUP)
                    CType(FrmObj, FrmPortMaster).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuPortMaster.Name
                    FrmObj = New FrmPortMaster(StrUserPermission, DTUP)
                    CType(FrmObj, FrmPortMaster).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuConsumptionMasterLog.Name
                    FrmObj = New FrmDesignConsumption(StrUserPermission, DTUP)
                    CType(FrmObj, FrmDesignConsumption).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuDesignConsumptionMaster.Name
                    FrmObj = New FrmDesignConsumption(StrUserPermission, DTUP)
                    CType(FrmObj, FrmDesignConsumption).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuCityMasterLog.Name
                    FrmObj = New AgTemplate_Common.FrmCity(StrUserPermission, DTUP)
                    CType(FrmObj, AgTemplate_Common.FrmCity).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuCityMaster.Name
                    FrmObj = New AgTemplate_Common.FrmCity(StrUserPermission, DTUP)
                    CType(FrmObj, AgTemplate_Common.FrmCity).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuOtherMaterialMasterLog.Name
                    FrmObj = New FrmOtherMaterial(StrUserPermission, DTUP)
                    CType(FrmObj, FrmOtherMaterial).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuOtherMaterialMaster.Name
                    FrmObj = New FrmOtherMaterial(StrUserPermission, DTUP)
                    CType(FrmObj, FrmOtherMaterial).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuCarpetSkuMasterLog.Name
                    FrmObj = New FrmCarpetSku(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetSku).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuCarpetSkuMaster.Name
                    FrmObj = New FrmCarpetSku(StrUserPermission, DTUP)
                    CType(FrmObj, FrmCarpetSku).FrmType = ClsMain.EntryPointType.Main

                Case MDI.MnuAgentMasterLog.Name
                    FrmObj = New FrmAgent(StrUserPermission, DTUP)
                    CType(FrmObj, FrmAgent).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuAgentMaster.Name
                    FrmObj = New FrmAgent(StrUserPermission, DTUP)
                    CType(FrmObj, FrmAgent).FrmType = ClsMain.EntryPointType.Main

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

