Public Class ClsFunction
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Dim CRepProc As ClsReportProcedures

    Public Function FOpen_Lib(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True)
        Dim mQry As String = ""
        Dim FrmObj As Form
        Dim StrUserPermission As String
        Dim DTUP As New DataTable
        Dim ADMain As OleDb.OleDbDataAdapter = Nothing
        Dim MDI As New MDI_Lib

        'For User Permission Open
        StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, StrSender, StrSenderText, DTUP)
        If AgL.PubDivisionList = "('')" Then AgL.PubDivisionList = "('" + AgL.PubDivCode + "')"
        ''For User Permission End 

        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuMemberVisitEntry.Name
                    FrmObj = New FrmMemberVisit(StrUserPermission, DTUP)

                Case MDI.MnuStationaryPurchaseQuotationEntry.Name
                    FrmObj = New FrmStationaryQuatation(StrUserPermission, DTUP)
                    CType(FrmObj, FrmStationaryQuatation).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuScrapSaleRequisitionEntryLog.Name
                    FrmObj = New FrmScrapSaleRequistion(StrUserPermission, DTUP)
                    CType(FrmObj, FrmScrapSaleRequistion).FrmType = ClsMain.EntryPointType.Log
                    CType(FrmObj, FrmScrapSaleRequistion).LogSystem = True

                Case MDI.MnuScrapSaleRequisitionEntryMain.Name
                    FrmObj = New FrmScrapSaleRequistion(StrUserPermission, DTUP)
                    CType(FrmObj, FrmScrapSaleRequistion).FrmType = ClsMain.EntryPointType.Main
                    CType(FrmObj, FrmScrapSaleRequistion).LogSystem = False

                Case MDI.MnuSubjectClassificationDisplay.Name
                    FrmObj = New FrmSubjectClassificationDisplay

                Case MDI.MnuDefineSubjectClassification.Name
                    FrmObj = New FrmSubjectClassification()

                Case MDI.MnuMoneyReceiptEntry.Name
                    FrmObj = New FrmPaymentEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmPaymentEntry).FrmType = ClsMain.EntryPointType.Log
                    CType(FrmObj, FrmPaymentEntry).TransType = AgTemplate.TempPayment.TransactionType.Receipt

                Case MDI.MnuPaymentEntry.Name
                    FrmObj = New FrmPaymentEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmPaymentEntry).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBillEntry.Name
                    FrmObj = New FrmBillEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBillEntry).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookIssueReceiveForBinfing.Name
                    FrmObj = New FrmBookIssueToBinder(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookIssueToBinder).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuSearchPanel.Name
                    FrmObj = New FrmSearchPanel()

                Case MDI.MnuVendorMaster.Name
                    FrmObj = New FrmVendor(StrUserPermission, DTUP)
                    'FrmObj = New FrmEnviro(StrUserPermission, DTUP)

                Case MDI.MnuBuyerMaster.Name
                    FrmObj = New FrmBuyerMaster(StrUserPermission, DTUP)
                    'FrmObj = New Form1()

                Case MDI.MnuCityMaster.Name
                    FrmObj = New AgTemplate.FrmCity(StrUserPermission, DTUP)

                Case MDI.MnuPrintBarCode.Name
                    FrmObj = New FrmBarCodePrint()

                Case MDI.MnuBookIssueToBranch.Name
                    FrmObj = New FrmBookIssueToBranch(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookIssueToBranch).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuEmployeeMaster.Name
                    FrmObj = New FrmEmployee(StrUserPermission, DTUP)
                    CType(FrmObj, FrmEmployee).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuMemberTypeMaster.Name
                    FrmObj = New FrmMemberType(StrUserPermission, DTUP)
                    CType(FrmObj, FrmMemberType).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookTypeMaster.Name
                    FrmObj = New FrmBookType(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookType).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuSubjectMaster.Name
                    FrmObj = New FrmSubject1(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSubject1).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookMaster.Name
                    FrmObj = New FrmBookNew(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookNew).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuAlmiraMaster.Name
                    FrmObj = New FrmGodown(StrUserPermission, DTUP)
                    CType(FrmObj, FrmGodown).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuGeneralsPeriodicalsMaster.Name
                    FrmObj = New FrmGenerals(StrUserPermission, DTUP)
                    CType(FrmObj, FrmGenerals).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuStationaryItemMaster.Name
                    FrmObj = New FrmItem(StrUserPermission, DTUP)
                    CType(FrmObj, FrmItem).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuScrapCategoryMaster.Name
                    FrmObj = New FrmScrapCategory(StrUserPermission, DTUP)
                    CType(FrmObj, FrmScrapCategory).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuMemberMaster.Name
                    FrmObj = New FrmMember(StrUserPermission, DTUP)
                    CType(FrmObj, FrmMember).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuPurchaseRequisitionEntry.Name
                    FrmObj = New FrmBookRequisition(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookRequisition).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookIndentEntry.Name
                    FrmObj = New FrmBookPurchaseIndent(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookPurchaseIndent).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookPurchaseQuotationEntry.Name
                    FrmObj = New FrmBookQuatation(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookQuatation).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuGeneralsSubscriptionEntry.Name
                    FrmObj = New FrmGeneralSubscription(StrUserPermission, DTUP)
                    CType(FrmObj, FrmGeneralSubscription).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookPurchaseOrderEntry.Name
                    FrmObj = New FrmBookPurchaseOrder(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookPurchaseOrder).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuStationaryPurchaseOrderEntry.Name
                    FrmObj = New FrmStationaryPurchOrder(StrUserPermission, DTUP)
                    CType(FrmObj, FrmStationaryPurchOrder).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuDonatedBookApplicationEntry.Name
                    FrmObj = New FrmDonatedApplication(StrUserPermission, DTUP)
                    CType(FrmObj, FrmDonatedApplication).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuDonatedBooksIssueEntry.Name
                    FrmObj = New FrmDonatedBookIssue(StrUserPermission, DTUP)
                    CType(FrmObj, FrmDonatedBookIssue).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuScrapSalesQuotationEntry.Name
                    FrmObj = New FrmSaleQuotation(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSaleQuotation).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuScarpSalesInvoiceEntry.Name
                    FrmObj = New FrmSale(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSale).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookReceiveEntry.Name
                    FrmObj = New FrmBooksReceived(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBooksReceived).FrmType = ClsMain.EntryPointType.Log
                    CType(FrmObj, FrmBooksReceived).EntryNCat = "" & ClsMain.Temp_NCat.GRNewBooks & "," & ClsMain.Temp_NCat.GROldBooks & "," & ClsMain.Temp_NCat.GRRareBooks & ""

                Case MDI.MnuDonatedBookReceiveEntry.Name
                    FrmObj = New FrmDonatedBooksReceived(StrUserPermission, DTUP)
                    CType(FrmObj, FrmDonatedBooksReceived).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuStationaryReceiveEntry.Name
                    FrmObj = New FrmStationaryReceived(StrUserPermission, DTUP)
                    CType(FrmObj, FrmStationaryReceived).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookPurchaseInvoiceEntry.Name
                    FrmObj = New FrmBookPurchaseInvoice(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookPurchaseInvoice).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuStationaryPurchaseInvoiceEntry.Name
                    FrmObj = New FrmStationaryPurchaseInvoice(StrUserPermission, DTUP)
                    CType(FrmObj, FrmStationaryPurchaseInvoice).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBooksIssueReceiveEntry.Name
                    FrmObj = New FrmBookIssue(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookIssue).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuGeneralsReceiveEntryMonthly.Name
                    FrmObj = New FrmPeriodicalRecd(StrUserPermission, DTUP)

                Case MDI.MnuGeneralsReceiveEntryYearly.Name
                    FrmObj = New FrmPeriodicalRecdYearly(StrUserPermission, DTUP)

                Case MDI.MnuBooksWriteOffEntry.Name
                    FrmObj = New FrmWriteoffBooks(StrUserPermission, DTUP)
                    CType(FrmObj, FrmWriteoffBooks).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuStationaryIssueEntry.Name
                    FrmObj = New FrmStationaryIssueEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmStationaryIssueEntry).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookAccessionEntry.Name
                    FrmObj = New frmaccessionentry(StrUserPermission, DTUP)
                    CType(FrmObj, frmaccessionentry).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuGeneralsWriteOffEntry.Name
                    FrmObj = New FrmWriteoffGenerals(StrUserPermission, DTUP)
                    CType(FrmObj, FrmWriteoffGenerals).FrmType = ClsMain.EntryPointType.Log

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
                Case MDI.MnuMoneyReceiptEntry.Name
                    FrmObj = New FrmPaymentEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmPaymentEntry).FrmType = ClsMain.EntryPointType.Log
                    CType(FrmObj, FrmPaymentEntry).TransType = AgTemplate.TempPayment.TransactionType.Receipt

                Case MDI.MnuPaymentEntry.Name
                    FrmObj = New FrmPaymentEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmPaymentEntry).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBillEntry.Name
                    FrmObj = New FrmBillEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBillEntry).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookIssueReceiveForBinfing.Name
                    FrmObj = New FrmBookIssueToBinder(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookIssueToBinder).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuVendorMaster.Name
                    FrmObj = New FrmVendor(StrUserPermission, DTUP)

                Case MDI.MnuBuyerMaster.Name
                    FrmObj = New FrmBuyerMaster(StrUserPermission, DTUP)

                Case MDI.MnuCityMaster.Name
                    FrmObj = New AgTemplate.FrmCity(StrUserPermission, DTUP)

                Case MDI.MnuPrintBarCode.Name
                    FrmObj = New FrmBarCodePrint()

                Case MDI.MnuSearchPanel.Name
                    FrmObj = New FrmSearchPanel()

                Case MDI.MnuBookIssueToBranch.Name
                    FrmObj = New FrmBookIssueToBranch(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookIssueToBranch).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuEmployeeMaster.Name
                    FrmObj = New FrmEmployee(StrUserPermission, DTUP)
                    CType(FrmObj, FrmEmployee).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuMemberTypeMaster.Name
                    FrmObj = New FrmMemberType(StrUserPermission, DTUP)
                    CType(FrmObj, FrmMemberType).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookTypeMaster.Name
                    FrmObj = New FrmBookType(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookType).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuSubjectMaster.Name
                    FrmObj = New FrmSubject1(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSubject1).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookMaster.Name
                    FrmObj = New FrmBookNew(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookNew).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuAlmiraMaster.Name
                    FrmObj = New FrmGodown(StrUserPermission, DTUP)
                    CType(FrmObj, FrmGodown).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuGeneralsPeriodicalsMaster.Name
                    FrmObj = New FrmGenerals(StrUserPermission, DTUP)
                    CType(FrmObj, FrmGenerals).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuStationaryItemMaster.Name
                    FrmObj = New FrmItem(StrUserPermission, DTUP)
                    CType(FrmObj, FrmItem).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuScrapCategoryMaster.Name
                    FrmObj = New FrmScrapCategory(StrUserPermission, DTUP)
                    CType(FrmObj, FrmScrapCategory).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuMemberMaster.Name
                    FrmObj = New FrmMember(StrUserPermission, DTUP)
                    CType(FrmObj, FrmMember).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuPurchaseRequisitionEntry.Name
                    FrmObj = New FrmBookRequisition(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookRequisition).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookIndentEntry.Name
                    FrmObj = New FrmBookPurchaseIndent(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookPurchaseIndent).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookPurchaseQuotationEntry.Name
                    FrmObj = New FrmBookQuatation(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookQuatation).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuGeneralsSubscriptionEntry.Name
                    FrmObj = New FrmGeneralSubscription(StrUserPermission, DTUP)
                    CType(FrmObj, FrmGeneralSubscription).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookPurchaseOrderEntry.Name
                    FrmObj = New FrmBookPurchaseOrder(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookPurchaseOrder).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuStationaryPurchaseOrderEntry.Name
                    FrmObj = New FrmStationaryPurchOrder(StrUserPermission, DTUP)
                    CType(FrmObj, FrmStationaryPurchOrder).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuDonatedBookApplicationEntry.Name
                    FrmObj = New FrmDonatedApplication(StrUserPermission, DTUP)
                    CType(FrmObj, FrmDonatedApplication).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuDonatedBooksIssueEntry.Name
                    FrmObj = New FrmDonatedBookIssue(StrUserPermission, DTUP)
                    CType(FrmObj, FrmDonatedBookIssue).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuScrapSalesQuotationEntry.Name
                    FrmObj = New FrmSaleQuotation(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSaleQuotation).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuScarpSalesInvoiceEntry.Name
                    FrmObj = New FrmSale(StrUserPermission, DTUP)
                    CType(FrmObj, FrmSale).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookReceiveEntry.Name
                    FrmObj = New FrmBooksReceived(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBooksReceived).FrmType = ClsMain.EntryPointType.Log
                    CType(FrmObj, FrmBooksReceived).EntryNCat = "" & ClsMain.Temp_NCat.GRNewBooks & "," & ClsMain.Temp_NCat.GROldBooks & "," & ClsMain.Temp_NCat.GRRareBooks & ""

                Case MDI.MnuDonatedBookReceiveEntry.Name
                    FrmObj = New FrmDonatedBooksReceived(StrUserPermission, DTUP)
                    CType(FrmObj, FrmDonatedBooksReceived).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuStationaryReceiveEntry.Name
                    FrmObj = New FrmStationaryReceived(StrUserPermission, DTUP)
                    CType(FrmObj, FrmStationaryReceived).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookPrchaseInvoiceEntry.Name
                    FrmObj = New FrmBookPurchaseInvoice(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookPurchaseInvoice).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuStationaryPurchaseInvoiceEntry.Name
                    FrmObj = New FrmStationaryPurchaseInvoice(StrUserPermission, DTUP)
                    CType(FrmObj, FrmStationaryPurchaseInvoice).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBooksIssueReceiveEntry.Name
                    FrmObj = New FrmBookIssue(StrUserPermission, DTUP)
                    CType(FrmObj, FrmBookIssue).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuGeneralsReceiveEntryMonthly.Name
                    FrmObj = New FrmPeriodicalRecd(StrUserPermission, DTUP)

                Case MDI.MnuGeneralsReceiveEntryYearly.Name
                    FrmObj = New FrmPeriodicalRecdYearly(StrUserPermission, DTUP)

                Case MDI.MnuEnviro.Name
                    FrmObj = New FrmEnviro(StrUserPermission, DTUP)

                Case MDI.MnuBooksWriteOffEntry.Name
                    FrmObj = New FrmWriteoffBooks(StrUserPermission, DTUP)
                    CType(FrmObj, FrmWriteoffBooks).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuStationaryIssueEntry.Name
                    FrmObj = New FrmStationaryIssueEntry(StrUserPermission, DTUP)
                    CType(FrmObj, FrmStationaryIssueEntry).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuBookAccessionEntry.Name
                    FrmObj = New frmaccessionentry(StrUserPermission, DTUP)
                    CType(FrmObj, frmaccessionentry).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuGeneralsWriteOffEntry.Name
                    FrmObj = New FrmWriteoffGenerals(StrUserPermission, DTUP)
                    CType(FrmObj, FrmWriteoffGenerals).FrmType = ClsMain.EntryPointType.Log

                Case MDI.MnuSubjectClassificationDisplay.Name
                    FrmObj = New FrmSubjectClassificationDisplay

                Case MDI.MnuDefineSubjectClassification.Name
                    FrmObj = New FrmSubjectClassification()

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

