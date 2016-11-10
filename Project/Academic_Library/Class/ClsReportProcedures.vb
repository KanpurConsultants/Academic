Public Class ClsReportProcedures

#Region "Danger Zone"
    Dim StrArr1() As String = Nothing, StrArr2() As String = Nothing, StrArr3() As String = Nothing, StrArr4() As String = Nothing, StrArr5() As String = Nothing

    Dim mGRepFormName As String = ""
    Dim WithEvents ObjRFG As AgLibrary.RepFormGlobal

    Public Property GRepFormName() As String
        Get
            GRepFormName = mGRepFormName
        End Get
        Set(ByVal value As String)
            mGRepFormName = value
        End Set
    End Property

#End Region

#Region "Common Reports Constant"
    Private Const CityList As String = "CityList"
    Private Const UserWiseEntryReport As String = "UserWiseEntryReport"
    Private Const UserWiseEntryTargetReport As String = "UserWiseEntryTargetReport"
#End Region

#Region "Reports Constant"
    Private Const BookRequisitionReport As String = "BookPurchaseRequisitionReport"
    Private Const BookPurchaseIndentReport As String = "BookIndentReport"
    Private Const BookQuatationReport As String = "BookPurchaseQuotationReport"
    Private Const BookPurchaseOrderReport As String = "BookPurchaseOrderReport"
    Private Const StationaryPurchaseOrderReport As String = "StationaryPurchaseOrderReport"
    Private Const GeneralsSubscriptionReport As String = "JournalsSubscriptionReport"
    Private Const BookReceiveReport As String = "BookReceiveReport"
    Private Const StationaryReceiveReport As String = "StationaryReceiveReport"
    Private Const MemberBookLedger As String = "MemberWiseBookLedgerReport"
    Private Const SaleQuotationReport As String = "ScrapSaleQuotationReport"
    Private Const BookDonetedApplicationReport As String = "DonatedBookApplicationReport"
    Private Const DonetedBookIssueReport As String = "BooksIssueforDonationReport"
    Private Const BookIssueReport As String = "BookIssueReport"
    Private Const SaleReport As String = "ScrapSaleInvoiceReport"
    Private Const BookPurchaseReport As String = "BookPurchaseReport"
    Private Const StationaryPurchaseReport As String = "StationaryPurchaseReport"
    Private Const GenralsAndPeriodicalReceiptReport As String = "JournalsReceiveReport"
    Private Const AccessionReport As String = "BookAccessionReport"
    Private Const BookWiseHoldStatus As String = "BookWiseHoldStatusReport"
    Private Const FSN As String = "BookFSNReport"
    Private Const BookStatus As String = "BookWiseStatusReport"
    Private Const MemberStatus As String = "MemberWiseStatusReport"
    Private Const BooksWriteOffReport As String = "BooksWriteOffReport"
    Private Const BooksReturnfromMemberReport As String = "BooksReturnfromMemberReport"
    Private Const BooksReceivedInDonationReport As String = "BooksReceivedInDonationReport"
    Private Const StationaryIssueReport As String = "StationaryIssueReport"
    Private Const StationaryStockSummary As String = "StationaryStockSummary"
    Private Const StationaryStockLedger As String = "StationaryStockLedger"
    Private Const StationaryStockInHand As String = "StationaryStockInHand"
    Private Const BooksIssueToBranchReport As String = "BooksIssueToBranchReport"
    Private Const BookMasterReport As String = "BookMasterReport"
    Private Const MemberCardReport As String = "MemberCardReport"
    Private Const JournalsNotReceivedReport As String = "JournalsNotReceivedReport"
    Private Const PaymentReport As String = "PaymentReport"
    Private Const BillWisePaymentReport As String = "BillWisePaymentReport"
    Private Const MoneyReceiptReport As String = "MoneyReceiptReport"
    Private Const BillWiseReceiptReport As String = "BillWiseReceiptReport"
    Private Const BookReplacementReport As String = "BookReplacementReport"
    Private Const BookLostReport As String = "BookLostReport"
    Private Const BookAccessionLablePrint As String = "BookAccessionLablePrint"
    Private Const MemberMasterReport As String = "MemberMasterReport"
    Private Const EmployeeMasterReport As String = "EmployeeMasterReport"
    Private Const SiteTransferReport As String = "SiteTransferReport"
    Private Const AccessionRegister As String = "AccessionRegister"
    Private Const ScrapSaleRequisitionRegister As String = "ScrapSaleRequisitionReport"
    Private Const StationaryPurchaseQuotation As String = "StationaryPurchaseQuotationReport"
    Private Const BranchTransferReport As String = "BranchTransferReport"
    Private Const MemberVisitRegister As String = "MemberVisitReport"
    Private Const FineReceiptReport As String = "FineReceiptReport"

#End Region

#Region "Queries Definition"
    Dim mHelpCityQry$ = "Select Convert(BIT,0) As [Select],CityCode, CityName From City "
    Dim mHelpPortQry$ = "Select Convert(BIT,0) As [Select],P.Code ,P.Description ,C.CityName AS City FROM SeaPort P LEFT JOIN City C ON C.CityCode=P.City "
    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "
    Dim mHelpDivisionQry$ = "Select Convert(BIT,0) As [Select], Div_Code AS Code,Div_Name AS Division FROM Division WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
    Dim mHelpStateQry$ = "Select DISTINCT Convert(BIT,0) As [Select], State AS Code,State FROM City WHERE State IS NOT NULL "
    Dim mHelpCountryQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Country AS Code,Country FROM City WHERE Country IS NOT NULL "
    Dim mHelpBuyerQry$ = " Select DISTINCT Convert(BIT,0) As [Select], B.SubCode AS Code,S.DispName AS Buyer,C.CityName AS City " & _
                            " FROM Buyer B " & _
                            " LEFT JOIN SubGroup S ON S.SubCode=B.SubCode  " & _
                            " LEFT JOIN City C ON C.CityCode=S.CityCode  " & _
                            " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "S.Site_Code", AgL.PubSiteCode, "S.CommonAc") & ""

    Dim mHelpAcGroupQry$ = "Select DISTINCT Convert(BIT,0) As [Select], GroupCode AS Code,GroupName  FROM AcGroup A "

    Dim mHelpItemQry$ = "Select DISTINCT Convert(BIT,0) As [Select], I.Code,I.Description  AS Item FROM Item I  "
    Dim mHelpItemTypeQry$ = "Select DISTINCT Convert(BIT,0) As [Select], I.ItemType AS Code,I.ItemType AS [Item Type] FROM Item I WHERE I.ItemType IS NOT NULL "
    Dim mHelpCityStatus$ = "Select DISTINCT Convert(BIT,0) As [Select], Status AS Code,Status FROM City WHERE Status IS NOT NULL  "

    Dim mHelpBookQry$ = " Select DISTINCT Convert(BIT,0) As [Select], I.Code ,I.Description AS Book,B.Writer ,B.Publisher " & _
                        " FROM Item I " & _
                        " LEFT JOIN Lib_Book B ON I.Code=B.Code  " & _
                        " WHERE ISNULL(I.IsDeleted,0)=0 And ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                        " AND I.ItemType IN (" & AgL.Chk_Text(ClsMain.ItemType.Book) & " ," & AgL.Chk_Text(ClsMain.ItemType.Generals) & " )"

    Dim mHelpStationaryQry$ = " Select DISTINCT Convert(BIT,0) As [Select], I.Code ,I.Description AS Stationary " & _
                    " FROM Item I " & _
                    " WHERE ISNULL(I.IsDeleted,0)=0 And ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                    " AND I.ItemType IN (" & AgL.Chk_Text(ClsMain.ItemType.Stationary) & " )"

    Dim mHelpGeneralQry$ = " Select DISTINCT Convert(BIT,0) As [Select], I.Code ,I.Description AS Generals " & _
                " FROM Item I " & _
                " WHERE ISNULL(I.IsDeleted,0)=0 And ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                " AND I.ItemType IN (" & AgL.Chk_Text(ClsMain.ItemType.Generals) & " )"

    Dim mHelpBookIdQry$ = " Select DISTINCT Convert(BIT,0) As [Select], AD.Book_UID AS Code,AD.Book_UID AS [Book Id], I.Description AS Book " & _
                " FROM Lib_AccessionDetail AD " & _
                " LEFT JOIN Lib_Accession A ON A.DocID=AD.DocId  " & _
                " LEFT JOIN Item I ON I.Code=AD.Book " & _
                " WHERE ISNULL(A.IsDeleted,0)=0 And ISNULL(A.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"

    Dim mHelpBkWriterQry$ = " Select DISTINCT Convert(BIT,0) As [Select], B.Writer AS Code ,B.Writer  " & _
                            " FROM Lib_Book B " & _
                            " LEFT JOIN Item I ON I.Code=B.Code  " & _
                            " WHERE B.Writer IS NOT NULL  AND ISNULL(I.IsDeleted,0)=0 " & _
                            " And ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"

    Dim mHelpBkPublisherQry$ = " Select DISTINCT Convert(BIT,0) As [Select], B.Publisher AS Code ,B.Publisher  " & _
                            " FROM Lib_Book B " & _
                            " LEFT JOIN Item I ON I.Code=B.Code  " & _
                            " WHERE B.Publisher IS NOT NULL  AND ISNULL(I.IsDeleted,0) = 0 " & _
                            " And ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"

    Dim mHelpVendorQry$ = " Select DISTINCT Convert(BIT,0) As [Select],V.SubCode AS Code,SG.DispName AS Vendor  " & _
                            " FROM Vendor V  " & _
                            " LEFT JOIN SubGroup SG ON SG.SubCode=V.SubCode  " & _
                            " WHERE isnull(SG.IsDeleted,0) =0  " & _
                            " And ISNULL(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                            " and " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""

    Dim mHelpBookPurchOrderNoQry$ = " Select DISTINCT Convert(BIT,0) As [Select],P.DocID AS Code,P.V_Type + ' - '+ Convert(NVARCHAR(5),P.V_No) AS [ORDER No] " & _
                                " FROM PurchOrder P " & _
                                " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=P.V_Type " & _
                                " WHERE isnull(P.IsDeleted,0) =0  AND Vt.NCat =" & AgL.Chk_Text(ClsMain.Temp_NCat.BookPurchaseOrder) & " " & _
                                " And ISNULL(P.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                                " and " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & ""

    Dim mHelpBookPurchaseChalanNoQry$ = " Select DISTINCT Convert(BIT,0) As [Select],P.DocID AS Code,P.V_Type + ' - '+ Convert(NVARCHAR(5),P.V_No) AS [Challan No] " & _
                               " FROM PurchChallan P " & _
                               " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=P.V_Type " & _
                               " WHERE isnull(P.IsDeleted,0) =0  AND Vt.NCat IN (" & AgL.Chk_Text(ClsMain.Temp_NCat.GRNewBooks) & "," & AgL.Chk_Text(ClsMain.Temp_NCat.GROldBooks) & "," & AgL.Chk_Text(ClsMain.Temp_NCat.GRRareBooks) & "," & AgL.Chk_Text(ClsMain.Temp_NCat.GRDonatedBooks) & ") " & _
                               " And ISNULL(P.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                               " and " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & ""

    Dim mHelpStationaryPurchaseChalanNoQry$ = " Select DISTINCT Convert(BIT,0) As [Select],P.DocID AS Code,P.V_Type + ' - '+ Convert(NVARCHAR(5),P.V_No) AS [Challan No] " & _
                               " FROM PurchChallan P " & _
                               " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=P.V_Type " & _
                               " WHERE isnull(P.IsDeleted,0) =0  AND Vt.NCat =" & AgL.Chk_Text(ClsMain.Temp_NCat.GRStationary) & " " & _
                               " And ISNULL(P.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                               " and " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & ""

    Dim mHelpStationaryPurchOrderNoQry$ = " Select DISTINCT Convert(BIT,0) As [Select],P.DocID AS Code,P.V_Type + ' - '+ Convert(NVARCHAR(5),P.V_No) AS [ORDER No] " & _
                                " FROM PurchOrder P " & _
                                " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=P.V_Type " & _
                                " WHERE isnull(P.IsDeleted,0) =0  AND Vt.NCat =" & AgL.Chk_Text(ClsMain.Temp_NCat.StationaryPurchaseOrder) & " " & _
                                " And ISNULL(P.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                                " and " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & ""

    Dim mHelpSaleQuotationNoQry$ = " Select DISTINCT Convert(BIT,0) As [Select],P.DocID AS Code,P.V_Type + ' - '+ Convert(NVARCHAR(5),P.V_No) AS [ORDER No] " & _
                                " FROM Lib_SaleQuot P " & _
                                " WHERE isnull(P.IsDeleted,0) =0  " & _
                                " And ISNULL(P.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                                " and " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & ""

    Dim mHelpScrapCategory$ = " Select DISTINCT Convert(BIT,0) As [Select], I.Code ,I.Description AS [Scrap Category] " & _
                                " FROM Lib_ScrapCategory I " & _
                                " WHERE ISNULL(I.IsDeleted,0)=0 And ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                                 " and " & AgL.PubSiteCondition("I.Site_Code", AgL.PubSiteCode) & ""

    Dim mHelpGodownQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Code,Description AS Godown FROM Godown " & _
                               " WHERE ISNULL(IsDeleted,0)=0 And ISNULL(Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                                " and " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & ""


    Dim mHelpMemberCard$ = " Select DISTINCT Convert(BIT,0) As [Select],M.SubCode AS Code,M.MemberCardNo AS [Card No],SG.DispName AS [Member Name] ,MT.Description AS [Member Type], M.Class  " & _
                            " FROM Lib_Member M " & _
                            " LEFT JOIN Lib_MemberType MT ON MT.Code=M.MemberType  " & _
                            " LEFT JOIN SubGroup SG ON SG.SubCode=M.SubCode " & _
                            " WHERE isnull(SG.IsDeleted,0) =0  " & _
                            " And ISNULL(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                            " and " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & ""

    Dim mHelpPayEmployee$ = " Select DISTINCT Convert(BIT,0) As [Select],P.SubCode AS Code,SG.DispName AS [Employee] FROM Pay_Employee P " & _
                            " LEFT JOIN SubGroup SG ON SG.SubCode=P.SubCode  " & _
                            " WHERE isnull(SG.IsDeleted,0) = 0  " & _
                            " And ISNULL(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                            " and " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""

    Dim mHelpSubGroup$ = " Select DISTINCT Convert(BIT,0) As [Select],SG.SubCode AS Code,SG.DispName  AS [Name] " & _
                        " FROM Lib_Member M " & _
                        " LEFT JOIN SubGroup SG ON SG.SubCode=M.SubCode " & _
                        " WHERE isnull(SG.IsDeleted,0) =0  " & _
                        " And ISNULL(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                        " and " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & ""


    Dim mHelpBookRequisitionVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                            " FROM Voucher_Type VT WHERE VT.NCat in (" & AgL.Chk_Text(ClsMain.Temp_NCat.BookRequisition) & "," & AgL.Chk_Text(ClsMain.Temp_NCat.NewBookRequisition) & " ) "

    Dim mHelpBookPurchIndentVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                            " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.BookIndent) & ""

    Dim mHelpBookPurchQuatationVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                            " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.BookPurchaseQuotation) & ""

    Dim mHelpBookPurchOrderVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                        " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.BookPurchaseOrder) & ""

    Dim mHelpStationaryPurchOrderVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                            " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.StationaryPurchaseOrder) & ""

    Dim mHelpGeneralsubscriptionVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                            " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.Generalsubscription) & ""

    Dim mHelpBookReceiveVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                            " FROM Voucher_Type VT WHERE VT.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.GRNewBooks) & "," & AgL.Chk_Text(ClsMain.Temp_NCat.GROldBooks) & "," & AgL.Chk_Text(ClsMain.Temp_NCat.GRRareBooks) & ")"

    Dim mHelpDonetedBookReceiveVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                        " FROM Voucher_Type VT WHERE VT.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.GRDonatedBooks) & ")"

    Dim mHelpMemberQry$ = " Select Convert(BIT,0) As [Select],M.SubCode AS Code, SG.DispName AS Member, M.MemberCardNo AS [Card No], M.Class " & _
                            " FROM Lib_Member M  " & _
                            " LEFT JOIN SubGroup SG ON SG.SubCode = M.SubCode  " & _
                            " WHERE isnull(SG.IsDeleted,0) =0  " & _
                            " And ISNULL(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                            " and " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & ""

    Dim mHelpStationaryReceiveVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                            " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.GRStationary) & ""

    Dim mHelpGenandPreReceiveVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                           " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.GeneralPeriodicalRecd) & ""

    Dim mHelpBookDonetedAppVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                           " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.GRDonatedBooks) & ""

    Dim mHelpDonetedBookIssueVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                           " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.DonatedBookIssue) & ""

    Dim mHelpBookIssueReceiveVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                           " FROM Voucher_Type VT WHERE VT.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.BookIssueReceive) & " )"

    Dim mHelpSaleQuotationVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                           " FROM Voucher_Type VT WHERE VT.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.ScrapQuotation) & " )"

    Dim mHelpSaleVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                           " FROM Voucher_Type VT WHERE VT.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.ScrapSale) & " )"

    Dim mHelpBookPurchaseVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                           " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.InvoiceBooks) & ""

    Dim mHelpStationaryPurchaseVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                          " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.InvoiceStationary) & ""

    Dim mHelpAccessionVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                         " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.Accession) & ""


    Dim mHelpBookWriteOffVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                     " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.WriteOffBooks) & ""

    Dim mHelpStationaryIssueVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                    " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.StationaryAdjustmentIssue) & ""

    Dim mHelpBookIssueToBranchVTypeQry$ = " Select DISTINCT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.V_Type AS [Voucher Type],Vt.Description  " & _
                                    " FROM Voucher_Type VT WHERE VT.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.BranchTransfer) & ""

    Dim mHelpSubjectQry$ = " SELECT Convert(BIT,0) As [Select], S.Code AS Code, S.Description AS Subject FROM Lib_Subject S  "

    Dim mHelpMemberTypeQry$ = " SELECT Convert(BIT,0) As [Select], Mt.Code, Mt.Description AS MemberType FROM Lib_MemberType Mt Where " & AgL.PubSiteCondition("MT.Site_Code", AgL.PubSiteCode) & ""


    Dim mHelpRecurrenceQry$ = " SELECT Convert(BIT,0) As [Select],'" & ClsMain.Recurrance.Daily & "' AS Code ,'" & ClsMain.Recurrance.Daily & "' AS Recurrance " & _
                                " Union ALL " & _
                                " SELECT Convert(BIT,0) As [Select],'" & ClsMain.Recurrance.Weekly & "' AS Code ,'" & ClsMain.Recurrance.Weekly & "' AS Recurrance " & _
                                " Union ALL " & _
                                " SELECT Convert(BIT,0) As [Select],'" & ClsMain.Recurrance.Fortnightly & "' AS Code ,'" & ClsMain.Recurrance.Fortnightly & "' AS Recurrance " & _
                                " Union ALL " & _
                                " SELECT Convert(BIT,0) As [Select],'" & ClsMain.Recurrance.Monthly & "' AS Code ,'" & ClsMain.Recurrance.Monthly & "' AS Recurrance " & _
                                " Union ALL " & _
                                " SELECT Convert(BIT,0) As [Select],'" & ClsMain.Recurrance.Bimonthly & "' AS Code ,'" & ClsMain.Recurrance.Bimonthly & "' AS Recurrance " & _
                                " Union ALL " & _
                                " SELECT Convert(BIT,0) As [Select],'" & ClsMain.Recurrance.Quarterly & "' AS Code ,'" & ClsMain.Recurrance.Quarterly & "' AS Recurrance " & _
                                " Union ALL " & _
                                " SELECT Convert(BIT,0) As [Select],'" & ClsMain.Recurrance.HalfYearly & "' AS Code ,'" & ClsMain.Recurrance.HalfYearly & "' AS Recurrance " & _
                                " Union ALL " & _
                                " SELECT Convert(BIT,0) As [Select],'" & ClsMain.Recurrance.Annually & "' AS Code ,'" & ClsMain.Recurrance.Annually & "' AS Recurrance "


    Dim mHelpWriterQry$ = " SELECT DISTINCT Convert(BIT,0) As [Select], B.Writer AS Code, B.Writer FROM Lib_Book B WHERE B.Writer IS NOT NULL "
    Dim mHelpPublisherQry$ = " SELECT DISTINCT  Convert(BIT,0) As [Select],B.Publisher AS Code, B.Publisher FROM Lib_Book B WHERE B.Publisher IS NOT NULL "
    Dim mHelpBookTypeQry$ = " SELECT Convert(BIT,0) As [Select],H.Code AS Code, H.Description AS BookType FROM Lib_BookType H Where " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
    Dim mHelpClassQry$ = " SELECT DISTINCT Convert(BIT,0) As [Select], M.Class AS Code, M.Class AS Class FROM Lib_Member M WHERE IsNull(M.Class,'') <> '' "
#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = ""
    Dim mRepType As ClsMain.ReportType

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                Case BookRequisitionReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    StrArr2 = New String() {"All", "Pending for Indent", "Indented", "Issued To Member", "Pending for Issue"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1, , "Report For", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBookRequisitionVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case BookPurchaseIndentReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    StrArr2 = New String() {"All", "Pending To Purchase Order", "Ordered", "Pending To Receive"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1, , "Report For", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBookPurchIndentVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case BookPurchaseOrderReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    StrArr2 = New String() {"All", "Pending", "Purchased"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1, , "Report For", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Vendor")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBookPurchOrderVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case BookQuatationReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Vendor")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBookPurchQuatationVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case StationaryPurchaseOrderReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    StrArr2 = New String() {"All", "Pending", "Purchased"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1, , "Report For", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Vendor")
                    ObjRFG.CreateHelpGrid(mHelpStationaryQry, "Stationary")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpStationaryPurchOrderVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case GeneralsSubscriptionReport
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Vendor")
                    ObjRFG.CreateHelpGrid(mHelpGeneralQry, "Generals")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpGeneralsubscriptionVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case BookReceiveReport, BooksReceivedInDonationReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    StrArr2 = New String() {"All", "Pending To Invoice", "Invoiced"}
                    If GRepFormName = BooksReceivedInDonationReport Then
                        Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    Else
                        Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1, , "Report For", StrArr2)
                    End If

                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Vendor")
                    ObjRFG.CreateHelpGrid(mHelpBookPurchOrderNoQry, "Order No.")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    If GRepFormName = BooksReceivedInDonationReport Then
                        ObjRFG.CreateHelpGrid(mHelpDonetedBookReceiveVTypeQry, "Voucher Type")
                    Else
                        ObjRFG.CreateHelpGrid(mHelpBookReceiveVTypeQry, "Voucher Type")
                    End If
                    mRepType = ClsMain.ReportType.Main

                Case StationaryReceiveReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    StrArr2 = New String() {"All", "Pending To Bill", "Billed"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1, , "Report For", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Vendor")
                    ObjRFG.CreateHelpGrid(mHelpStationaryPurchOrderNoQry, "Order No.")
                    ObjRFG.CreateHelpGrid(mHelpStationaryQry, "Stationary")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBookReceiveVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case SaleQuotationReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpBuyerQry, "Buyer")
                    ObjRFG.CreateHelpGrid(mHelpScrapCategory, "Scrap Category")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpSaleQuotationVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case SaleReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSaleQuotationNoQry, "Sale Quotation No.")
                    ObjRFG.CreateHelpGrid(mHelpBuyerQry, "Buyer")
                    ObjRFG.CreateHelpGrid(mHelpScrapCategory, "Scrap Category")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpSaleVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case BookDonetedApplicationReport
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpMemberCard, "Member Card ")
                    ObjRFG.CreateHelpGrid(mHelpPayEmployee, "Attested By")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBookDonetedAppVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case DonetedBookIssueReport
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpMemberCard, "Member Card ")
                    ObjRFG.CreateHelpGrid(mHelpPayEmployee, "Transaction By")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpDonetedBookIssueVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case BookIssueReport
                    StrArr1 = New String() {"All", "Pending to Return", "Over Due", "Returned"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report For", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpMemberCard, "Member Card ")
                    ObjRFG.CreateHelpGrid(mHelpPayEmployee, "Transaction By")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBookIssueReceiveVTypeQry, "Voucher Type")
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry, "Subject")
                    ObjRFG.CreateHelpGrid(mHelpClassQry, "Class")
                    mRepType = ClsMain.ReportType.Main

                Case BookPurchaseReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Vendor")
                    ObjRFG.CreateHelpGrid(mHelpBookPurchaseChalanNoQry, "Challan No")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBookPurchaseVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case StationaryPurchaseReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Vendor")
                    ObjRFG.CreateHelpGrid(mHelpStationaryPurchaseChalanNoQry, "Challan No")
                    ObjRFG.CreateHelpGrid(mHelpStationaryQry, "Stationary")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpStationaryPurchaseVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case MemberBookLedger
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpMemberQry, "Member")
                    ObjRFG.CreateHelpGrid(mHelpClassQry, "Class")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")

                    mRepType = ClsMain.ReportType.Main

                Case MemberStatus
                    Call ObjRFG.Ini_Grp("Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpMemberQry, "Member")
                    ObjRFG.CreateHelpGrid(mHelpPayEmployee, "Employee")
                    ObjRFG.CreateHelpGrid(mHelpClassQry, "Class")
                    mRepType = ClsMain.ReportType.Main

                Case GenralsAndPeriodicalReceiptReport
                    StrArr1 = New String() {"Date", "Generals"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Short On", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpGeneralQry, "General")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpGenandPreReceiveVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case AccessionReport, BookAccessionLablePrint
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpPayEmployee, "Transaction By")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpAccessionVTypeQry, "Voucher Type")
                    ObjRFG.CreateHelpGrid(mHelpBookTypeQry, "Book Type")
                    mRepType = ClsMain.ReportType.Main

                Case AccessionRegister
                    StrArr1 = New String() {"Date", "Accession No"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Order By", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpPayEmployee, "Transaction By")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpAccessionVTypeQry, "Voucher Type")
                    ObjRFG.CreateHelpGrid(mHelpBookTypeQry, "Book Type")
                    mRepType = ClsMain.ReportType.Main

                Case BookWiseHoldStatus
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpMemberCard, "Member Card No.")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpClassQry, "Class")

                    mRepType = ClsMain.ReportType.Main

                Case FSN
                    StrArr1 = New String() {"Issuance", "Over Dues", "Requisitions"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Short On", StrArr1, , "Fast Moving %", , , "Slow Moving %", , , "None Moving %")
                    ObjRFG.ParameterCmbo2_Value = "50"
                    ObjRFG.ParameterCmbo3_Value = "30"
                    ObjRFG.ParameterCmbo4_Value = "20"
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    mRepType = ClsMain.ReportType.Main

                Case BookStatus
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry, "Subject")
                    mRepType = ClsMain.ReportType.Main

                Case BooksWriteOffReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSubGroup, "Order By")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBookWriteOffVTypeQry, "Voucher Type")
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry, "Subject")
                    mRepType = ClsMain.ReportType.Main

                Case BooksReturnfromMemberReport, BookReplacementReport, BookLostReport
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpMemberCard, "Member Card ")
                    ObjRFG.CreateHelpGrid(mHelpPayEmployee, "Transaction By")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBookIssueReceiveVTypeQry, "Voucher Type")
                    ObjRFG.CreateHelpGrid(mHelpClassQry, "Class")
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry, "Subject")

                    mRepType = ClsMain.ReportType.Main

                Case StationaryIssueReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpPayEmployee, "Issued To")
                    ObjRFG.CreateHelpGrid(mHelpPayEmployee, "Order By")
                    ObjRFG.CreateHelpGrid(mHelpStationaryQry, "Stationary")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpStationaryIssueVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case StationaryStockSummary, StationaryStockLedger
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpStationaryQry, "Stationary")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")

                Case StationaryStockInHand
                    Call ObjRFG.Ini_Grp("AS On Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpStationaryQry, "Stationary")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")

                Case BooksIssueToBranchReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpGodownQry, "From Godown")
                    ObjRFG.CreateHelpGrid(mHelpGodownQry, "To Godown")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBkWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpBkPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    ObjRFG.CreateHelpGrid(mHelpBookIssueToBranchVTypeQry, "Voucher Type")
                    mRepType = ClsMain.ReportType.Main

                Case BookMasterReport
                    Call ObjRFG.Ini_Grp()
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry, "Subject")
                    ObjRFG.CreateHelpGrid(mHelpWriterQry, "Writer")
                    ObjRFG.CreateHelpGrid(mHelpPublisherQry, "Publisher")
                    ObjRFG.CreateHelpGrid(mHelpBookTypeQry$, "BookType")
                    mRepType = ClsMain.ReportType.Main

                Case MemberCardReport, MemberMasterReport
                    Call ObjRFG.Ini_Grp()
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpMemberCard, "Member Card No.")
                    ObjRFG.CreateHelpGrid(mHelpMemberQry, "Member")
                    ObjRFG.CreateHelpGrid(mHelpMemberTypeQry, "Member Type")
                    ObjRFG.CreateHelpGrid(mHelpClassQry, "Class")
                    mRepType = ClsMain.ReportType.Main

                Case JournalsNotReceivedReport
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpGeneralQry, "Journals")
                    ObjRFG.CreateHelpGrid(mHelpRecurrenceQry, "Recurrence")
                    mRepType = ClsMain.ReportType.Main

                Case PaymentReport, MoneyReceiptReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Party")
                    mRepType = ClsMain.ReportType.Main

                Case FineReceiptReport
                    StrArr1 = New String() {"Yes", "No", "All"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Show Pending", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpMemberQry$, "Member")
                    mRepType = ClsMain.ReportType.Main

                Case BillWisePaymentReport, BillWiseReceiptReport
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Party")
                    mRepType = ClsMain.ReportType.Main

                Case EmployeeMasterReport
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    mRepType = ClsMain.ReportType.Main

                Case SiteTransferReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBookIdQry, "Book ID")

                Case ScrapSaleRequisitionRegister
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpScrapCategory, "Scrap Category")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    mRepType = ClsMain.ReportType.Main

                Case StationaryPurchaseQuotation
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpVendorQry, "Vendor")
                    ObjRFG.CreateHelpGrid(mHelpStationaryQry, "Stationary")
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
                    mRepType = ClsMain.ReportType.Main

                Case BranchTransferReport
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpBookQry, "Book")
                    ObjRFG.CreateHelpGrid(mHelpBookIdQry, "Book ID")

                Case MemberVisitRegister
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry, "Site")
                    ObjRFG.CreateHelpGrid(mHelpMemberQry, "Member")
                    ObjRFG.CreateHelpGrid(mHelpDivisionQry, "Division")
            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName

            Case BookRequisitionReport
                ProcBookRequisitionReport()

            Case BookPurchaseIndentReport
                ProcBookPurchIndentReport()

            Case BookQuatationReport
                ProcBookPurchQuatationReport()

            Case BookPurchaseOrderReport
                ProcBookPurchOrderReport()

            Case StationaryPurchaseOrderReport
                ProcStationaryPurchOrderReport()

            Case GeneralsSubscriptionReport
                ProcGeneralsubscriptionReport()

            Case BookReceiveReport
                ProcBookReceiveReport("" & AgL.Chk_Text(ClsMain.Temp_NCat.GRNewBooks) & "," & AgL.Chk_Text(ClsMain.Temp_NCat.GROldBooks) & "," & AgL.Chk_Text(ClsMain.Temp_NCat.GRRareBooks) & "", "Book Receive Report", "Lib_BookReceiveReport")

            Case BooksReceivedInDonationReport
                ProcBookReceiveReport("" & AgL.Chk_Text(ClsMain.Temp_NCat.GRDonatedBooks) & "", "Books Received In Donation Report", "Lib_DonatedBookReceiveReport")

            Case StationaryReceiveReport
                ProcStationaryReceiveReport()

            Case MemberBookLedger
                ProcMemberBookLedger()

            Case MemberStatus
                ProcMemberStatus()

            Case BookDonetedApplicationReport
                ProcDonationAppReport()

            Case DonetedBookIssueReport
                ProcDonetedBookIssueReport(ClsMain.Temp_NCat.DonatedBookIssue, "Donated Book Issue Report", "Lib_DonetedBookIssueReport")

            Case BookIssueReport
                ProcDonetedBookIssueReport(ClsMain.Temp_NCat.BookIssueReceive, "Book Issue Report", "Lib_BookIssueReport")

            Case SaleReport
                ProcScrapSaleReport()

            Case SaleQuotationReport
                ProcScrapSaleQuotationReport()

            Case BookPurchaseReport
                ProcBookPurchaseReport()

            Case StationaryPurchaseReport
                ProcStationaryPurchaseReport()

            Case GenralsAndPeriodicalReceiptReport
                ProcGeneralPeriodicalReceiveReport()

            Case AccessionReport
                ProcAccessionReport("Lib_AccessionReport", "Accession Report")

            Case AccessionRegister
                ProcAccessionReport("Lib_AccessionRegister", "Accession Register")

            Case BookAccessionLablePrint
                ProcAccessionReport("Lib_AccessionLablePrint", "Accession Lable Print")

            Case BookWiseHoldStatus
                ProcBookWiseHoldStatusReport()

            Case FSN
                ProcFSNReport()

            Case BookStatus
                ProcBookStatusReport()

            Case BooksWriteOffReport
                ProcBookWriteOffReport()

            Case BooksReturnfromMemberReport
                ProcBooksReturnReport(ClsMain.Temp_NCat.BookIssueReceive, "Books Return from Member Report", "Lib_BookReturnReport", "Received")

            Case BookReplacementReport
                ProcBooksReturnReport(ClsMain.Temp_NCat.BookIssueReceive, "Books Replacement Report", "Lib_BookReturnReport", "Replaced")

            Case BookLostReport
                ProcBooksReturnReport(ClsMain.Temp_NCat.BookIssueReceive, "Books Lost Report", "Lib_BookReturnReport", "Lost")

            Case StationaryIssueReport
                ProcStationaryIssueReport()

            Case StationaryStockSummary
                procStockSummary("Stationary Stock Summary")

            Case StationaryStockLedger
                procStockSummary("Stationary Stock Ledger")

            Case StationaryStockInHand
                procStockSummary("Stationary Stock In Hand")

            Case BooksIssueToBranchReport
                ProcBookIssueToBranchReport()

            Case BookMasterReport
                ProcBookMasterReport()

            Case MemberCardReport
                ProcMemberMasterReport("Lib_MemberMaster", "Member Master")

            Case MemberMasterReport
                ProcMemberMasterReport("Lib_MemberListReport", "Member Master Report")

            Case JournalsNotReceivedReport
                ProcJournalsNotReceivedReport()

            Case PaymentReport
                ProcPaymentReport("Payment")

            Case MoneyReceiptReport
                ProcPaymentReport("Receipt")

            Case FineReceiptReport
                ProcFineReceiptReport()

            Case BillWiseReceiptReport
                ProcBillWiseOutstandingReport("Receipt", "Bill Wise Receipt Report")

            Case BillWisePaymentReport
                ProcBillWiseOutstandingReport("Payment", "Bill Wise Payment Report")

            Case EmployeeMasterReport
                ProcEmployeeMasterReport()

            Case SiteTransferReport
                ProcStockSiteTransferReport("Lib_StockSiteTransferReport", "Site Transfer Report")

            Case ScrapSaleRequisitionRegister
                ProSaleRequisitionRegisterReport()

            Case StationaryPurchaseQuotation
                ProcStationaryPurchQuatationReport()

            Case BranchTransferReport
                ProcStockSiteTransferReport("Lib_BranchTransferReport", "Branch Transfer Report")

            Case MemberVisitRegister
                ProcMemberVisitRegister()
        End Select
    End Sub

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub

#Region "Book Requisition Report"
    Private Sub ProcBookRequisitionReport()
        Dim bTableName$ = "", mOrderBy$ = "", bSecTableName As String = ""
        Try
            Call ObjRFG.FillGridString()

            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "Requisition_Log" : bSecTableName = "RequisitionDetail_Log  R1 ON R1.UID =R.UID "
                RepName = "Lib_BookRequisitionLogReport" : RepTitle = "Book Requisition Log Report"
            Else
                bTableName = "Requisition" : bSecTableName = "RequisitionDetail R1 ON R1.DocID =R.DocID"
                RepName = "Lib_BookRequisitionReport" : RepTitle = "Book Requisition Report"
            End If

            Dim mCondStr$ = ""

            mOrderBy = "ORDER BY R.V_Date"
            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(R.IsDeleted,0)=0  And ISNULL(R.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND R.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.ParameterCmbo2_Value = "Indented" Then
                mCondStr = mCondStr & " AND R1.PurchaseIndent IS NOT NULL "
            ElseIf ObjRFG.ParameterCmbo2_Value = "Pending for Indent" Then
                mCondStr = mCondStr & " AND R1.PurchaseIndent IS NULL "
            ElseIf ObjRFG.ParameterCmbo2_Value = "Issued To Member" Then
                mCondStr = mCondStr & " AND R1.IssueDocId IS NOT NULL "
            ElseIf ObjRFG.ParameterCmbo2_Value = "Pending for Issue" Then
                mCondStr = mCondStr & " AND R1.IssueDocId IS NULL "
            Else
                mCondStr = mCondStr
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("R1.Item", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 2)

            If ObjRFG.GetWhereCondition("R.Site_Code", 3) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("R.Site_Code", 3)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("R.Div_Code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("R.V_Type", 5)


            mQry = " SELECT  R.DocID, R.V_Type, R.V_Prefix, R.V_Date, R.V_No, R.Div_Code, R.Site_Code, " & _
                    " R.Department, R.RequisitionBy, R.Remarks, R.TotalQty, R.TotalMeasure, R.EntryBy, " & _
                    " R.EntryDate, R.EntryType, R.EntryStatus, R.ApproveBy, R.ApproveDate, R.MoveToLog, " & _
                    " R.MoveToLogDate, R.IsDeleted, R.Status, R.UID,SG.DispName AS ReqByName, " & _
                    " R1.Sr, R1.Item, R1.Qty, R1.Unit, R1.MeasurePerPcs, R1.MeasureUnit, " & _
                    " R1.TotalMeasure AS LineTotalMeasure, R1.RequireDate, R1.PurchaseIndent, " & _
                    " SM.Name AS SiteName,I.Description AS ItemDesc, B.Writer,B.Publisher  , " & _
                    " R1.IssueDocId, BI.V_Date AS IssueDate, BI.V_Type AS IssueType,BI.V_No AS IssueNo," & _
                    " '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, P.V_No AS IndentNo,P.V_Type AS IndentType" & _
                    " FROM " & bTableName & " R " & _
                    " LEFT JOIN " & bSecTableName & "  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=R.Site_Code  " & _
                    " LEFT JOIN Item I ON I.Code=R1.Item  " & _
                    " LEFT JOIN SUbGroup SG ON SG.SubCode=R.RequisitionBy  " & _
                    " LEFT JOIN PurchIndent P ON P.DocId=R1.PurchaseIndent " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=R.V_Type  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=I.Code " & _
                    " LEFT JOIN Lib_BookIssue BI ON BI.DocID=R1.IssueDocId " & _
                    " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Book Purchase Indent Report"
    Private Sub ProcBookPurchIndentReport()
        Dim bTableName$ = "", mOrderBy$ = "", bSecTableName As String = ""
        Try
            Call ObjRFG.FillGridString()


            If AgL.StrCmp(mRepType, ClsMain.ReportType.Log) Then
                bTableName = "PurchIndent_Log" : bSecTableName = "PurchIndentDetail_Log  P1 ON P1.UID =P.UID "
                RepName = "Lib_BookPurchIndentLogReport" : RepTitle = "Book Purchase Indent Log Report"
            Else
                bTableName = "PurchIndent" : bSecTableName = "PurchIndentDetail P1 ON P1.DocID =P.DocID"
                RepName = "Lib_BookPurchIndentReport" : RepTitle = "Book Purchase Indent Report"
            End If

            Dim mCondStr$ = ""

            mOrderBy = "ORDER BY P.V_Date"
            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(P.IsDeleted,0)=0 And ISNULL(P.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND P.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.ParameterCmbo2_Value = "Ordered" Then
                mCondStr = mCondStr & " AND P1.IndentQty - P1.OrdQty  <= 0  "
            ElseIf ObjRFG.ParameterCmbo2_Value = "Pending To Purchase Order" Then
                mCondStr = mCondStr & " AND P1.IndentQty - P1.OrdQty  > 0 "
            ElseIf ObjRFG.ParameterCmbo2_Value = "Pending To Receive" Then
                mCondStr = mCondStr & " AND V1.ReceiveDocId IS NULL "
            Else
                mCondStr = mCondStr
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P1.Item", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 2)

            If ObjRFG.GetWhereCondition("P.Site_Code", 3) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.Site_Code", 3)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.Div_Code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.V_Type", 5)

            mQry = " SELECT  P.DocID, P.V_Type, P.V_Prefix, P.V_Date, P.V_No, P.Div_Code, P.Site_Code, " & _
                " P.Department, Sg.DispName As Indentor, P.Remarks, P.TotalQty, P.TotalMeasure, P.EntryBy, P.EntryDate, " & _
                " P.EntryType, P.EntryStatus, P.ApproveBy, P.ApproveDate, P.MoveToLog, P.MoveToLogDate, P.IsDeleted, P.Status, P.UID, " & _
                " P1.Sr, P1.Item, P1.CurrentStock, P1.ReqQty, P1.IndentQty, P1.Unit,P1.MeasurePerPcs, P1.MeasureUnit,  " & _
                " P1.TotalReqMeasure AS LineTotalMeasure, P1.TotalIndentMeasure AS LineTotalIndentMeasure, P1.OrdQty, P1.OrdMeasure, " & _
                " P1.PurchQty, P1.PurchMeasure, P1.RequireDate,SM.Name AS SiteName,I.Description AS ItemDesc, " & _
                " B.Writer, B.Publisher,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType " & _
                " FROM " & bTableName & " P " & _
                " LEFT JOIN " & bSecTableName & " " & _
                " LEFT JOIN SiteMast SM ON SM.Code=P.Site_Code  " & _
                " LEFT JOIN Item I ON I.Code=P1.Item  " & _
                " LEFT JOIN Lib_Book B ON B.Code = P1.Item  " & _
                " LEFT JOIN SubGroup Sg On P.Indentor = Sg.SubCode " & _
                " LEFT JOIN  " & _
                " ( " & _
                " SELECT POD.PurchIndent,PCD.DocId AS ReceiveDocId   " & _
                " FROM PurchChallanDetail PCD " & _
                " LEFT JOIN PurchOrderDetail POD ON POD.DocId=PCD.PurchOrder AND PCD.Item =POD.Item  " & _
                " WHERE POD.PurchIndent IS NOT NULL " & _
                " ) V1 ON V1.PurchIndent =P.DocId " & _
                " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Book Purchase Quatation Report"
    Private Sub ProcBookPurchQuatationReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_BookPurchaseQuatationReport" : RepTitle = "Book Purchase Quatation Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND Vt.NCat = '" & ClsMain.Temp_NCat.BookPurchaseQuotation & "' "
            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vendor", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 3)

            If ObjRFG.GetWhereCondition("H.Site_Code", 4) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 4)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 6)

            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.Vendor, H.VendorName, H.Currency, H.Structure, H.BillingType, H.VendorQuoteNo, H.VendorQuoteDate, " & _
                    " H.TermsAndConditions, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, H.PostingGroupSalesTaxParty, H.PurchIndent, " & _
                    " L.Item, L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalMeasure AS LineTotalMeasure, " & _
                    " L.Rate, L.Amount, L.PostingGroupSalesTaxItem, L.OrdQty, L.OrdMeasure, L.PurchQty, L.PurchMeasure, " & _
                    " I.Description AS ItemDesc,B.Writer ,B.Publisher,SM.Name AS SiteName,SF.*, SL.* ,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, P.V_No AS IndentNo, P.V_Type AS IndentType  " & _
                    " FROM PurchQuotation H " & _
                    " LEFT JOIN PurchQuotationDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.BookPurchaseQuotation) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.BookPurchaseQuotation) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=L.Item  " & _
                    " LEFT JOIN PurchIndent P ON P.DocId=H.PurchIndent  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                    " " & mCondStr & ""
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Book Purchase Order Report"
    Private Sub ProcBookPurchOrderReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_BookPurchaseOrderReport" : RepTitle = "Book Purchase Order Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If ObjRFG.ParameterCmbo2_Value = "Purchased" Then
                mCondStr = mCondStr & " AND  L.Qty <= isnull(V1.ChallanQty,0) "
            ElseIf ObjRFG.ParameterCmbo2_Value = "Pending" Then
                mCondStr = mCondStr & " AND  L.Qty > isnull(V1.ChallanQty,0)"
            Else
                mCondStr = mCondStr
            End If

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND Vt.NCat =" & AgL.Chk_Text(ClsMain.Temp_NCat.BookPurchaseOrder) & ""
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vendor", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 3)

            If ObjRFG.GetWhereCondition("H.Site_Code", 4) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 4)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 6)

            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.VendorName, H.VendorAdd1, H.VendorAdd2, H.VendorCity, H.VendorCityName, H.VendorState, H.VendorCountry, " & _
                    " H.PurchQuotaion, H.PurchIndent,  H.TermsAndConditions, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, " & _
                    " H.IsDeleted, L.PurchIndent AS LinePurchIndent, L.Item, L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalMeasure AS LineTotalMeasure, L.Rate, L.Amount ," & _
                    " I.Description AS ItemDesc, B.Writer,B.Publisher ,SM.Name AS SiteName ,SF.*, SL.* ,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, P.V_No AS IndentNo, P.V_Type AS IndentType,isnull(V1.ChallanQty,0) AS ChallanQty " & _
                    " FROM PurchOrder H " & _
                    " LEFT JOIN PurchOrderDetail L ON L.DocId=H.DocID " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.BookPurchaseOrder) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.BookPurchaseOrder) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=I.Code  " & _
                    " LEFT JOIN PurchIndent P on P.DocId=L.PurchIndent " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
                    " LEFT JOIN " & _
                    "  ( " & _
                    " SELECT PC.PurchOrder,PC.Item,sum(PC.Qty) AS ChallanQty  " & _
                    " FROM PurchChallanDetail PC " & _
                    " WHERE PC.PurchOrder IS NOT NULL  " & _
                    " GROUP BY PC.PurchOrder,PC.Item " & _
                    "  )V1 ON V1.PurchOrder=L.DocId AND V1.Item=L.Item " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Stationary Purchase Order Report"
    Private Sub ProcStationaryPurchOrderReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_StationaryPurchaseOrderReport" : RepTitle = "Stationary Purchase Order Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If ObjRFG.ParameterCmbo2_Value = "Purchased" Then
                mCondStr = mCondStr & " AND  L.Qty <= isnull(V1.ChallanQty,0) "
            ElseIf ObjRFG.ParameterCmbo2_Value = "Pending" Then
                mCondStr = mCondStr & " AND  L.Qty > isnull(V1.ChallanQty,0)"
            Else
                mCondStr = mCondStr
            End If

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND Vt.NCat =" & AgL.Chk_Text(ClsMain.Temp_NCat.StationaryPurchaseOrder) & ""
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vendor", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 1)

            If ObjRFG.GetWhereCondition("H.Site_Code", 2) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 2)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 4)

            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.VendorName, H.VendorAdd1, H.VendorAdd2, H.VendorCity, H.VendorCityName, H.VendorState, H.VendorCountry, " & _
                    " H.PurchQuotaion, H.PurchIndent,  H.TermsAndConditions, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, " & _
                    " H.IsDeleted, L.PurchIndent AS LinePurchIndent, L.Item, L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalMeasure AS LineTotalMeasure, L.Rate, L.Amount ," & _
                    " I.Description AS ItemDesc, SM.Name AS SiteName ,SF.*, SL.* ,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, P.V_No AS IndentNo, P.V_Type AS IndentType,isnull(V1.ChallanQty,0) AS ChallanQty " & _
                    " FROM PurchOrder H " & _
                    " LEFT JOIN PurchOrderDetail L ON L.DocId=H.DocID " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.StationaryPurchaseOrder) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.StationaryPurchaseOrder) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN PurchIndent P on P.DocId=L.PurchIndent " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
                    " LEFT JOIN " & _
                    "  ( " & _
                    " SELECT PC.PurchOrder,PC.Item,sum(PC.Qty) AS ChallanQty  " & _
                    " FROM PurchChallanDetail PC " & _
                    " WHERE PC.PurchOrder IS NOT NULL  " & _
                    " GROUP BY PC.PurchOrder,PC.Item " & _
                    "  )V1 ON V1.PurchOrder=L.DocId AND V1.Item=L.Item " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Generals Subscription Report"
    Private Sub ProcGeneralsubscriptionReport()
        Dim bTableName$ = "", mOrderBy$ = "", bSecTableName As String = ""
        Try
            Call ObjRFG.FillGridString()


            RepName = "Lib_GeneralsubscriptionReport" : RepTitle = "Journals Subscription Report"
            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(G.IsDeleted,0)=0 And ISNULL(G.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND G.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("G.Vendor", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("G.General", 1)

            If ObjRFG.GetWhereCondition("G.Site_Code", 2) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("G.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("G.Site_Code", 2)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("G.Div_Code", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("G.V_Type", 4)

            mQry = " SELECT  G.DocID, G.V_Type + ' - ' + Convert(NVARCHAR(5),G.V_No) AS VoucherNo,G.V_Type, G.V_Prefix, G.Qty, G.V_Date, G.V_No, G.Div_Code, G.Site_Code, " & _
                    " G.Vendor, G.General, G.FromDate, G.ToDate, G.Recurrance, G.PaymentType,  " & _
                    " G.Amount, G.Remarks,SG.DispName AS VendorName,I.Description AS ItemDesc,SM.Name AS SiteName " & _
                    " FROM Lib_Subscription G " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=G.Vendor  " & _
                    " LEFT JOIN Item I ON I.Code=G.General  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=G.Site_Code " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Book Receive Report"
    Private Sub ProcBookReceiveReport(ByVal bNCat As String, ByVal bRepTitle As String, ByVal bRepName As String)
        Try
            Call ObjRFG.FillGridString()
            RepName = bRepName : RepTitle = bRepTitle

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND Vt.NCat IN ( " & bNCat & ")"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.ParameterCmbo2_Value = "Invoiced" Then
                mCondStr = mCondStr & " AND PID.DocId IS NOT NULL "
            ElseIf ObjRFG.ParameterCmbo2_Value = "Pending To Invoice" Then
                mCondStr = mCondStr & " AND PID.DocId IS NULL "
            Else
                mCondStr = mCondStr
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vendor", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.PurchOrder", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 4)

            If ObjRFG.GetWhereCondition("H.Site_Code", 5) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 5)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 7)

            mQry = " SELECT  H.DocID, H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo,H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.Currency, H.SalesTaxGroupParty, H.Structure, " & _
                    " H.BillingType, H.VendorDocNo, H.VendorDocDate, H.Transport, H.Godown, H.Remarks, " & _
                    " H.TotalQty, H.TotalMeasure, H.TotalAmount, H.EntryBy, H.Status, " & _
                    " L.Sr, L.PurchOrder, L.Item, L.SalesTaxGroupItem, L.DocQty, L.RejQty, L.Qty, " & _
                    " L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalRejMeasure, L.TotalMeasure, " & _
                    " L.Rate, L.Amount, L.InvoicedQty, L.InvoicedMeasure,SG.DispName AS VendorName,SG.Add1,SG.Add2 ,SG.Add3,SG.CityCode ,SG.Mobile, " & _
                    " C.CityName ,I.Description AS ItemName,B.Writer,B.Publisher,SF.*, SL.* , '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType ," & _
                    " PO.V_Type AS OrderType,PO.V_No AS OrderNo,PO.V_Type + ' - ' + Convert(NVARCHAR(5),PO.V_No) AS POrderNo,SM.Name AS SiteName,PID.DocId AS InvoiceId " & _
                    " FROM PurchChallan H " & _
                    " LEFT JOIN PurchChallanDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.GRNewBooks) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.GRNewBooks) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Vendor  " & _
                    " LEFT JOIN Godown G ON G.Code=H.Godown  " & _
                    " LEFT JOIN City C ON C.CityCode =SG.CityCode  " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN PurchOrder PO ON PO.DocId=L.PurchOrder  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=I.Code " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code " & _
                    " LEFT JOIN PurchInvoiceDetail PID ON PID.PurchChallan = L.DocId AND PID.Item=L.Item " & _
                    " " & mCondStr & ""


            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Stationary Receive Report"
    Private Sub ProcStationaryReceiveReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_StationaryReceiveReport" : RepTitle = "Stationary Receive Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            If ObjRFG.ParameterCmbo2_Value = "Billed" Then
                mCondStr = mCondStr & " AND PID.DocId IS NOT NULL "
            ElseIf ObjRFG.ParameterCmbo2_Value = "Pending To Bill" Then
                mCondStr = mCondStr & " AND PID.DocId IS NULL "
            Else
                mCondStr = mCondStr
            End If

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND Vt.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.GRStationary) & ")"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vendor", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.PurchOrder", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 2)

            If ObjRFG.GetWhereCondition("H.Site_Code", 3) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 3)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 5)

            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.Currency, H.SalesTaxGroupParty, H.Structure, " & _
                    " H.BillingType, H.VendorDocNo, H.VendorDocDate, H.Transport, H.Godown, H.Remarks, " & _
                    " H.TotalQty, H.TotalMeasure, H.TotalAmount, H.EntryBy, H.Status, " & _
                    " L.Sr, L.PurchOrder, L.Item, L.SalesTaxGroupItem, L.DocQty, L.RejQty, L.Qty, " & _
                    " L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalRejMeasure, L.TotalMeasure, " & _
                    " L.Rate, L.Amount, L.InvoicedQty, L.InvoicedMeasure,SG.DispName AS VendorName,SG.Add1,SG.Add2 ,SG.Add3,SG.CityCode ,SG.Mobile, " & _
                    " C.CityName ,I.Description AS ItemName,SF.*, SL.* ,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, " & _
                    " PO.V_Type AS OrderType,PO.V_No AS OrderNo,SM.Name AS SiteName " & _
                    " FROM PurchChallan H " & _
                    " LEFT JOIN PurchChallanDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.BookPurchaseOrder) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.BookPurchaseOrder) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Vendor  " & _
                    " LEFT JOIN Godown G ON G.Code=H.Godown  " & _
                    " LEFT JOIN City C ON C.CityCode =SG.CityCode  " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN PurchOrder PO ON PO.DocId=L.PurchOrder  " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code " & _
                    " LEFT JOIN PurchInvoiceDetail PID ON PID.PurchChallan = L.DocId AND PID.Item=L.Item " & _
                    " " & mCondStr & ""


            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Donation Application Report"
    Private Sub ProcDonationAppReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_DonationAppReport" : RepTitle = "Donation Application Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Member", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.AttestedByStaff", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Book", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 4)

            If ObjRFG.GetWhereCondition("H.Site_Code", 5) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 5)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 7)

            mQry = " SELECT  H.DocID,H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code,H.Site_Code, H.Member, " & _
                    " H.MonthlyIncome, H.Subject, H.AttestedByStaff, H.Remarks, H.ReferenceNo,SM.Name AS SiteName, " & _
                    " SG.DispName AS AttestByName, L.Book,I.Description AS bookName,B.Writer ,B.Publisher, M.MemberCardNo ,  " & _
                    " SGM.DispName AS MemberName " & _
                    " FROM Lib_DonationApp H " & _
                    " LEFT JOIN Lib_DonationAppDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.AttestedByStaff  " & _
                    " LEFT JOIN Item I ON I.Code=L.Book  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=I.Code " & _
                    " LEFT JOIN Lib_Member M ON M.SubCode=H.Member " & _
                    " LEFT JOIN SubGroup SGM ON SGM.SubCode=H.Member  " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Doneted Book Issue Report"
    Private Sub ProcDonetedBookIssueReport(ByVal bNCat As String, ByVal bReportTitle As String, ByVal bReportPrint As String)
        Try
            Call ObjRFG.FillGridString()
            RepName = bReportPrint : RepTitle = bReportTitle

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            If bNCat = ClsMain.Temp_NCat.BookIssueReceive Then
                If ObjRFG.ParameterCmbo1_Value = "Pending to Return" Then
                    mCondStr = mCondStr & " AND  L.ReturnDocId IS NULL "
                ElseIf ObjRFG.ParameterCmbo1_Value = "Over Due" Then
                    mCondStr = mCondStr & " AND  L.ToReturnDate < getdate() AND L.ReturnDocId IS NULL"
                ElseIf ObjRFG.ParameterCmbo1_Value = "Returned" Then
                    mCondStr = mCondStr & " AND  L.ReturnDocId IS NOT NULL "
                Else
                    mCondStr = mCondStr
                End If
            End If

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & " AND Vt.NCat IN ( " & AgL.Chk_Text(bNCat) & " )"

            mCondStr = mCondStr & " AND L.Book_UID IS NOT NULL"


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Member", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.TransactionBy", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Book", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 4)

            If ObjRFG.GetWhereCondition("H.Site_Code", 5) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 5)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 7)
            'mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Subject", 8)
            'mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.Class", 9)
         

            mQry = " SELECT  H.DocID,H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.Member, H.DonationApp, H.TransactionBy, H.MemberRemarks, H.Remarks, " & _
                    " L.Book_UID, L.Book, L.ForDays, L.ToReturnDate, L.ReturnDocId, " & _
                    " L.ReturnDate, L.Status, L.FinePerDay, L.FineAmount, L.Remarks AS LineRemark, L.Edition, " & _
                    " SM.Name AS SiteName,M.MemberCardNo ,SG.DispName AS MemberName,SG.DispName AS MemberDispName, " & _
                    " DA.V_Type AS DAV_Type,DA.V_No AS DAV_No,DA.V_Type + ' - ' + Convert(NVARCHAR(5),DA.V_No) AS ApplicationNo,SGT.Name AS TransByName,SGT.DispName AS TransByDispName, " & _
                    " I.Description AS BookDesc,B.Writer ,B.Publisher,  " & _
                    " R.V_Type AS RetV_Type, R.V_No AS RetV_No,R.V_Type + ' - ' + Convert(NVARCHAR(5),R.V_No) AS ReturnNo ,L.AccessionNo " & _
                    " FROM Lib_BookIssue H " & _
                    " LEFT JOIN Lib_BookIssueDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code =H.Site_Code  " & _
                    " LEFT JOIN Lib_Member M ON M.SubCode=H.Member  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode =H.Member  " & _
                    " LEFT JOIN Lib_DonationApp DA ON DA.DocID=H.DonationApp  " & _
                    " LEFT JOIN SubGroup SGT ON SGT.SubCode=H.TransactionBy  " & _
                    " LEFT JOIN Item I ON I.Code=L.Book  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=L.Book  " & _
                    " LEFT JOIN Lib_BookIssue R ON R.DocID=L.ReturnDocId " & _
                    " LEFT JOIN Voucher_Type Vt ON H.V_Type=Vt.V_Type " & _
                    " " & mCondStr & ""
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Scrap Sale Quotation Report"
    Private Sub ProcScrapSaleQuotationReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_ScrapSaleQuotationReport" : RepTitle = "Scrap Sale Quotation Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Buyer", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.ScrapCategory", 1)

            If ObjRFG.GetWhereCondition("H.Site_Code", 2) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 2)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 4)

            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, " & _
                    " H.Site_Code, H.ReferenceNo, H.Buyer, H.BuyerDocNo, H.BuyerDocDate, H.Remarks, " & _
                    " H.TotalQty, H.TotalAmount,SM.Name AS SiteName,SG.Name AS BuyerName,SG.DispName AS BuyerDispName, " & _
                    " L.ScrapCategory, L.Qty, L.Unit, L.Rate, L.Amount,SC.Description AS ScrapSDesc,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType " & _
                    " FROM Lib_SaleQuot H " & _
                    " LEFT JOIN Lib_SaleQuotDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Buyer  " & _
                    " LEFT JOIN Lib_ScrapCategory SC ON SC.Code =L.ScrapCategory  " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Scrap Sale Report"
    Private Sub ProcScrapSaleReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_ScrapSaleReport" : RepTitle = "Scrap Sale Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Quotation", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Buyer", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.ScrapCategory", 2)

            If ObjRFG.GetWhereCondition("H.Site_Code", 3) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 3)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 5)

            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.Quotation, H.ReferenceNo, H.Buyer, H.BuyerDocNo, H.BuyerDocDate, H.Remarks, H.TotalQty, H.TotalAmount, " & _
                    " L.ScrapCategory, L.Qty, L.Unit, L.Rate, L.Amount,SM.Name AS SiteName,SQ.V_Type AS QtV_Type,SQ.V_No AS QtV_No, " & _
                    " SG.Name AS BuyerName,SG.DispName AS BuyerDispName,SC.Description AS ScrapCatDesc, '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType " & _
                    " FROM Lib_Sale H " & _
                    " LEFT JOIN Lib_SaleDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code =H.Site_Code  " & _
                    " LEFT JOIN Lib_SaleQuot SQ ON SQ.DocID=H.Quotation  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Buyer  " & _
                    " LEFT JOIN Lib_ScrapCategory SC ON SC.Code = L.ScrapCategory " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Book Purchase Report"
    Private Sub ProcBookPurchaseReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_BookPurchaseReport" : RepTitle = "Book Purchase Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND Vt.NCat =" & AgL.Chk_Text(ClsMain.Temp_NCat.InvoiceBooks) & ""
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vendor", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.PurchChallan", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 4)

            If ObjRFG.GetWhereCondition("H.Site_Code", 5) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 5)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 7)

            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.PurchChallan, H.Currency, H.SalesTaxGroupParty, H.Structure, " & _
                    " H.BillingType, H.VendorDocNo, H.VendorDocDate, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, " & _
                    " L.PurchChallan, L.Item, L.SalesTaxGroupItem, L.DocQty, L.Qty,SM.Name AS SiteName,SG.DispName AS VenderName,SG.DispName AS VendorDispName, " & _
                    " L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalMeasure, " & _
                    " L.Rate, L.Amount, L.PurchChallan, " & _
                    " PC.V_Type AS PCV_Type,PC.V_No AS PCV_No,I.Description AS ItemDesc,B.Writer ,B.Publisher,SF.*, SL.* ,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType  " & _
                    " FROM PurchInvoice H " & _
                    " LEFT JOIN PurchInvoiceDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.InvoiceBooks) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.InvoiceBooks) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN SiteMast SM ON SM.Code =H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Vendor  " & _
                    " LEFT JOIN PurchChallan PC ON PC.DocID=L.PurchChallan  " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=L.Item " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Stationary Purchase Report"
    Private Sub ProcStationaryPurchaseReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_StationaryPurchaseReport" : RepTitle = "Stationary Purchase Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND Vt.NCat =" & AgL.Chk_Text(ClsMain.Temp_NCat.InvoiceStationary) & ""
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vendor", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.PurchChallan", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 2)
          
            If ObjRFG.GetWhereCondition("H.Site_Code", 3) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 3)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 5)

            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.PurchChallan, H.Currency, H.SalesTaxGroupParty, H.Structure, " & _
                    " H.BillingType, H.VendorDocNo, H.VendorDocDate, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, " & _
                    " L.PurchChallan, L.Item, L.SalesTaxGroupItem, L.DocQty, L.Qty,SM.Name AS SiteName,SG.DispName AS VenderName,SG.DispName AS VendorDispName, " & _
                    " L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalMeasure, L.Rate, L.Amount, L.PurchOrder, " & _
                    " PC.V_Type AS PCV_Type,PC.V_No AS PCV_No,I.Description AS ItemDesc,SF.*, SL.* ,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType  " & _
                    " FROM PurchInvoice H " & _
                    " LEFT JOIN PurchInvoiceDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.InvoiceStationary) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.InvoiceStationary) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN SiteMast SM ON SM.Code =H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Vendor  " & _
                    " LEFT JOIN PurchChallan PC ON PC.DocID=L.PurchChallan  " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Generals AND Periodical Receive Report"
    Private Sub ProcGeneralPeriodicalReceiveReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_GenAndPreReceiveReport"
            RepTitle = "Journals AND Periodical Receive Report"

            Dim mCondStr$ = ""
            Dim mOrderByStr$ = ""

            mCondStr = " where 1=1 "

            If ObjRFG.ParameterCmbo1_Value = "Date" Then
                mOrderByStr = " Order BY L.V_Date "
            Else
                mOrderByStr = " Order BY I.Description  "
            End If

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND Vt.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.GeneralPeriodicalRecd) & "," & AgL.Chk_Text(ClsMain.Temp_NCat.GeneralPeriodicalMonthlyRecd) & ")"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "



            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 0)

            If ObjRFG.GetWhereCondition("H.Site_Code", 1) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 1)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 3)

            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.Currency, H.SalesTaxGroupParty, H.Structure, " & _
                    " H.BillingType, H.VendorDocNo, H.VendorDocDate, H.Transport, H.Godown, H.Remarks, " & _
                    " H.TotalQty, H.TotalMeasure, H.TotalAmount, H.EntryBy, H.Status, " & _
                    " L.Sr, L.PurchOrder, L.Item, L.SalesTaxGroupItem, L.DocQty, L.RejQty, L.Qty, " & _
                    " L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalRejMeasure, L.TotalMeasure, " & _
                    " L.Edition,	L.SysEdition,	L.V_Date AS LineV_Date,	L.AccessionQty, " & _
                    " L.Rate, L.Amount, L.InvoicedQty, L.InvoicedMeasure,SG.DispName AS VendorName,SG.Add1,SG.Add2 ,SG.Add3,SG.CityCode ,SG.Mobile, " & _
                    " C.CityName ,I.Description AS ItemName,SF.*, SL.* ," & _
                    " PO.V_Type AS OrderType,PO.V_No AS OrderNo,SM.Name AS SiteName,S.Qty AS SubscribedQty  " & _
                    " FROM PurchChallan H " & _
                    " LEFT JOIN PurchChallanDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.GRStationary) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.GRStationary) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Vendor  " & _
                    " LEFT JOIN Godown G ON G.Code=H.Godown  " & _
                    " LEFT JOIN City C ON C.CityCode =SG.CityCode  " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN Lib_Subscription S ON S.General=L.Item " & _
                    " AND (L.V_date BETWEEN S.FromDate AND S.Todate OR S.ToDate IS NULL) " & _
                    " LEFT JOIN PurchOrder PO ON PO.DocId=L.PurchOrder  " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code " & _
                    " " & mCondStr & " " & mOrderByStr & "  "


            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Accession Report"
    Private Sub ProcAccessionReport(ByVal bRepName As String, ByVal bRepTitle As String)
        Try
            Call ObjRFG.FillGridString()

            'RepName = "Lib_AccessionReport" : RepTitle = "Accession Report"
            RepName = bRepName : RepTitle = bRepTitle
            Dim mCondStr$ = ""
            Dim mOrderByStr$ = ""

            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0  And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.TransactionBy", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Book", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Writer", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Publisher", 3)

            If ObjRFG.GetWhereCondition("H.Site_Code", 4) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 4)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.BookType", 7)

            If ObjRFG.ParameterCmbo1_Value = "Date" Then
                mOrderByStr = ",h.V_Date as OrderByStr "
            Else
                mOrderByStr = " ,l.AccessionNo_Sr as OrderByStr "
            End If


            mQry = " SELECT  H.DocID, H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo,H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReceiptNo, H.TransactionBy, H.Remarks As HeaderRemark ,SM.Name AS SiteName,PC.V_Type + ' - ' + Convert(NVARCHAR(5),PC.V_No) AS PCVoucherNo,PC.V_Type AS PCV_Type,PC.V_No AS PCV_No," & _
                    " L.Sr, L.AccessionNo, L.Book_UID, L.Book, L.Writer, " & _
                    " L.Publisher, L.Series, L.Subject, L.Volume, L.Language, L.ISBN, L.Edition, " & _
                    " L.Pages, L.MRP,L.Rate, L.WithCD, L.Godown, L.GodownSection, L.RefAccessionNo, " & _
                    " L.Remarks As LineFileRemark, L.IsInStock,I.Description AS BookDisp,SG.DispName AS TransactionByName, " & _
                    " SG.DispName AS TransactionByDispName, L.PublicationYear, L.Place " & mOrderByStr & " " & _
                    " FROM  Lib_Accession H " & _
                    " LEFT JOIN Lib_AccessionDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode = H.TransactionBy " & _
                    " LEFT JOIN Item I ON I.Code=L.Book " & _
                    " LEFT JOIN PurchChallan PC ON H.ReceiptNo =PC.DocID  " & _
                    " LEFT JOIN Lib_Book B On I.Code = B.Code " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Book Wise Hold Status Report"
    Private Sub ProcBookWiseHoldStatusReport()
        Try
            Call ObjRFG.FillGridString()


            RepName = "Lib_BookWiseHoldStatus" : RepTitle = "Book Wise Hold Status"
            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0  And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND Vt.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.BookIssueReceive) & " )"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Member", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Book", 1)

            If ObjRFG.GetWhereCondition("H.Site_Code", 2) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 2)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.Class", 4)


            mQry = " SELECT V2.*, I.ManualCode AS BookCode, I.Description AS BookDesc, SG.DispName AS MemberName " & _
                " FROM " & _
                " ( " & _
                " SELECT V1.BooK ,V1.Member,Sum(isnull(V1.HoldDays,0)) AS HoldDays, " & _
                " Sum(isnull(V1.OverDays,0)) AS OverDays,Sum(isnull(V1.FineAmount,0)) AS FineAmount, " & _
                " Count(V1.BooK) AS Recurrance, Max(V1.MemberCardNo) As MemberCardNo ,Max(V1.AccessionNo) AS AccessionNo  " & _
                " FROM  " & _
                " ( " & _
                " SELECT L.BooK, H.Member, DateDiff(Day, H.V_Date ,IsNull(l.ReturnDate,GetDate())) AS HoldDays, " & _
                " DateDiff(Day, L.ToReturnDate ,IsNull(l.ReturnDate,GetDate())) AS OverDays,L.FineAmount, " & _
                " M.MemberCardNo ,L.AccessionNo  " & _
                " FROM Lib_BookIssueDetail  L " & _
                " LEFT JOIN Lib_BookIssue H ON L.DocId = H.DocID  " & _
                " LEFT JOIN Lib_Member M ON M.SubCode = H.Member " & _
                " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
                " " & mCondStr & " " & _
                " ) V1 " & _
                " GROUP BY V1.BooK ,V1.Member " & _
                " ) V2 " & _
                " LEFT JOIN Item I ON I.Code=V2.Book " & _
                " LEFT JOIN SubGroup SG ON SG.SubCode=V2.member "
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "FSN Report"
    Private Sub ProcFSNReport()
        Try
            Call ObjRFG.FillGridString()

            If Val(ObjRFG.ParameterCmbo2_Value) + Val(ObjRFG.ParameterCmbo3_Value) + Val(ObjRFG.ParameterCmbo4_Value) <> 100 Then
                MsgBox("Total Moving % should be 100 !") : Exit Sub
            End If

            Dim mSubQryIssueRec As String = ""
            Dim mSubQryReq As String = ""


            RepName = "Lib_FSN" : RepTitle = "FSN Report"
            Dim mCondStr$ = ""


            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0  And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND Vt.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.BookIssueReceive) & " )"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Book", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 2)

            mSubQryIssueRec = " SELECT V1.BooK ,Sum(isnull(V1.HoldDays,0)) AS HoldDays,   " & _
                            " Sum(isnull(V1.OverDays,0)) AS OverDays,Sum(isnull(V1.FineAmount,0)) AS FineAmount,   " & _
                            " Count(V1.BooK) AS Issuance   " & _
                            " FROM   (   " & _
                            " SELECT L.BooK, DateDiff(Day, H.V_Date ,IsNull(l.ReturnDate,GetDate())) AS HoldDays, " & _
                            " DateDiff(Day, L.ToReturnDate ,IsNull(l.ReturnDate,GetDate())) AS OverDays,L.FineAmount    " & _
                            " FROM Lib_BookIssueDetail  L   " & _
                            " LEFT JOIN Lib_BookIssue H ON L.DocId = H.DocID    " & _
                            " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type    " & _
                            " " & mCondStr & " " & _
                            "  ) V1  GROUP BY V1.BooK    "

            mSubQryReq = " SELECT sum(isnull(RD.Qty,0)) AS ReqQty,RD.Item " & _
                            " FROM RequisitionDetail RD " & _
                            " LEFT JOIN Requisition R ON R.DocID=RD.DocId  " & _
                            " WHERE R.V_Date BETWEEN " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " " & _
                            " AND RD.IssueDocId IS NULL AND ISNULL(R.IsDeleted,0)=0  " & _
                            " And ISNULL(R.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                            " GROUP BY RD.Item "

            mQry = " SELECT V2.* ,I.ManualCode AS BookCode,I.Description AS BookDesc, " & _
                    " VMain.BookSCount, " & _
                    " isnull(VReq.ReqQty,0) AS ReqQty,Isnull(V2.Issuance,0)/VMain.BookSCount AS FSN, " & _
                    " " & Val(ObjRFG.ParameterCmbo2_Value) & " AS MoveFastPer ," & _
                    " " & Val(ObjRFG.ParameterCmbo3_Value) & " AS MoveSlowPer , '" & ObjRFG.ParameterCmbo3_Text & "' AS MoveSlowText," & _
                    " " & Val(ObjRFG.ParameterCmbo4_Value) & " AS MoveNonePer ,'" & ObjRFG.ParameterCmbo4_Text & "' AS MoveNoneText" & _
                    " FROM  " & _
                    " ( " & _
                    " SELECT AD.Book ,count(*) AS BookSCount " & _
                    " FROM Lib_AccessionDetail AD " & _
                    " LEFT JOIN Lib_Accession A ON A.DocID=AD.DocId  " & _
                    " WHERE  ISNULL(AD.WriteOff,0) =0 " & _
                    " GROUP BY AD.Book  " & _
                    "  ) VMain  LEFT JOIN Item I ON I.Code=VMain.Book  " & _
                    " LEFT JOIN (" & mSubQryIssueRec & " ) V2 ON VMain.Book=V2.Book " & _
                    " LEFT JOIN (" & mSubQryReq & " ) VReq ON VReq.Item=V2.Book " & _
                    " ORDER BY Isnull(V2.Issuance,0)/VMain.BookSCount "

            '" Isnull(V2.Issuance,0)/VMain.BookSCount*100/Sum(Isnull(V2.Issuance,0)/VMain.BookSCount), " & _

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Book Wise Hold Status Report"
    Private Sub ProcBookStatusReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mSubQryReq As String = ""
            RepName = "Lib_BookStatus" : RepTitle = "Book Status"
            Dim mCondStr$ = ""


            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0  And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Book", 0)

            If ObjRFG.GetWhereCondition("H.Site_Code", 1) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 1)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Writer", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Publisher", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Subject", 5)




            mSubQryReq = " SELECT sum(isnull(RD.Qty,0)) AS ReqQty,RD.Item " & _
                            " FROM RequisitionDetail RD " & _
                            " LEFT JOIN Requisition R ON R.DocID=RD.DocId  " & _
                            " WHERE R.V_Date BETWEEN " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " " & _
                            " AND RD.IssueDocId IS NULL AND ISNULL(R.IsDeleted,0)=0  " & _
                            " And ISNULL(R.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                            " GROUP BY RD.Item "

            mQry = " SELECT I.ManualCode AS BookCode,I.Description AS BookDesc, " & _
                    " VMain.BookSCount, VMain.CurrentStock ," & _
                    " isnull(VReq.ReqQty,0) AS ReqQty " & _
                    " FROM  " & _
                    " ( " & _
                    " SELECT L.Book ,Count(*) BookSCount ," & _
                    " Sum(CASE WHEN l.IsInStock = 1 THEN 1 ELSE 0 END ) AS CurrentStock " & _
                    " FROM Lib_AccessionDetail L " & _
                    " LEFT JOIN Lib_Accession H ON L.DocID=H.DocId  " & _
                    " " & mCondStr & " " & _
                    " AND  ISNULL(L.WriteOff,0) =0 " & _
                    " GROUP BY L.Book  " & _
                    "  ) VMain  LEFT JOIN Item I ON I.Code=VMain.Book  " & _
                    " LEFT JOIN (" & mSubQryReq & " ) VReq ON VReq.Item=VMain.Book "

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Member Book Ledger"
    Private Sub ProcMemberBookLedger()
        Dim bTableName$ = "", mOrderBy$ = "", bSecTableName As String = ""
        Try
            Call ObjRFG.FillGridString()

            RepName = "Lib_MemberBookLedger" : RepTitle = "Member Book Ledger"

            Dim mCondStr$ = ""

            mOrderBy = "ORDER BY I.V_Date"
            mCondStr = " Where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(I.IsDeleted,0) = 0  And ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND I.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("I.Member", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.Class", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Id.Book", 2)

            mQry = " SELECT Sg.ManualCode As MemberCode, Sg.DispName As MemberName, It.ManualCode AS BookCode, It.Description AS BookTitle, " & _
                    " I.V_Date AS IssueDate, Id.ToReturnDate AS DateToReturn, Id.ReturnDate, Id.FineAmount ,Id.AccessionNo    " & _
                    " FROM Lib_BookIssue I " & _
                    " LEFT JOIN Lib_BookIssueDetail Id ON I.DocID = Id.DocId " & _
                    " LEFT JOIN Lib_Member M ON I.Member = M.SubCode " & _
                    " LEFT JOIN SubGroup Sg ON I.Member = Sg.SubCode " & _
                    " LEFT JOIN Item It ON Id.Book = It.Code " & _
                    " LEFT JOIN Voucher_Type Vt On I.V_Type = Vt.V_Type " & _
                    " " & mCondStr & "" & mOrderBy & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Member Status"
    Private Sub ProcMemberStatus()
        Dim bTableName$ = "", mOrderBy$ = "", bSecTableName As String = ""
        Dim mConStr1$ = "", mConStr2$ = ""
        Try
            Call ObjRFG.FillGridString()

            RepName = "Lib_MemberStatus" : RepTitle = "Member Status"

            Dim mCondStr$ = ""

            mConStr1 = " WHERE I.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " "
            mConStr1 = mConStr1 & " AND Id.Book_UID IS NOT NULL "


            mConStr2 = " WHERE R.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " "
            mConStr2 = mConStr2 & " And Rd.PurchaseIndent Is Null And Rd.IssueDocId Is Null "

            mCondStr = " Where 1=1 "

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("IsNull(V1.MemberSubCode, V2.MemberSubCode)", 0)
            mCondStr = mCondStr & Replace(ObjRFG.GetWhereCondition("IsNull(V1.MemberSubCode, V2.MemberSubCode)", 1), "And", "Or")
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("IsNull(V1.Class, V2.Class)", 2)

            mQry = " SELECT IsNull(V1.MemberCode, V2.MemberCode) As MemberCode, " & _
                        " IsNull(V1.MemberName, V2.MemberName) As MemberName , " & _
                        " V1.BookCode As IssueBookCode, " & _
                        " V1.BookTitle As IssueBookTitle, V1.HoldDays , V1.IssueDate, " & _
                        " V2.BookCode As RequestedBookCode, V2.BookTitle As RequestedBookTitle, " & _
                        " V2.PendingFromDays, V2.RequitionDate, " & _
                        " IsNull(V1.Class, V2.Class) As Class ,V1.AccessionNo " & _
                        " FROM " & _
                        " ( " & _
                        " SELECT Row_number() OVER  (PARTITION BY Sg.SubCode ORDER BY Id.Book) AS RowNum, " & _
                        " Sg.SubCode AS MemberSubCode,   " & _
                        " Sg.ManualCode As MemberCode, Sg.DispName As MemberName,  " & _
                        " It.ManualCode AS BookCode, It.Description AS BookTitle,   " & _
                        " I.V_Date , Id.ReturnDate, " & _
                        " datediff(dd, I.V_Date ,IsNull(Id.ReturnDate,getdate())) AS HoldDays, I.V_Date As IssueDate, " & _
                        " M.Class ,Id.AccessionNo " & _
                        " FROM Lib_BookIssue I   " & _
                        " LEFT JOIN Lib_BookIssueDetail Id ON I.DocID = Id.DocId   " & _
                        " LEFT JOIN Lib_Member M ON I.Member = M.SubCode   " & _
                        " LEFT JOIN SubGroup Sg ON I.Member = Sg.SubCode   " & _
                        " LEFT JOIN Item It ON Id.Book = It.Code   " & _
                        " LEFT JOIN Voucher_Type Vt On I.V_Type = Vt.V_Type " & mConStr1 & _
                        " ) AS V1 " & _
                        " FULL JOIN	 " & _
                        " ( " & _
                        " SELECT Row_number() OVER (PARTITION BY Sg.SubCode ORDER BY Rd.Item) AS RowNum,   " & _
                        " Sg.SubCode AS MemberSubCode,   " & _
                        " Sg.ManualCode As MemberCode, Sg.DispName As MemberName,  " & _
                        " It.ManualCode AS BookCode, It.Description AS BookTitle, " & _
                        " datediff(dd,Rd.RequireDate," & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & ")  AS PendingFromDays, " & _
                        " R.V_Date As RequitionDate, " & _
                        " M.Class " & _
                        " FROM Requisition R " & _
                        " LEFT JOIN RequisitionDetail Rd ON R.DocID = Rd.DocId   " & _
                        " LEFT JOIN Lib_Member M ON R.RequisitionBy = M.SubCode   " & _
                        " LEFT JOIN SubGroup Sg ON R.RequisitionBy = Sg.SubCode  " & _
                        " LEFT JOIN Item It ON Rd.Item = It.Code " & mConStr2 & _
                        " ) AS V2 " & _
                        " ON V1.RowNum = V2.RowNum AND V1.MemberSubCode = V2.MemberSubCode " & _
                        mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Book Write Off Report"
    Private Sub ProcBookWriteOffReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_BookWriteOffReport" : RepTitle = "Book Write Off Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & " AND Vt.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.WriteOffBooks) & " )"

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.OrderBy", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 3)

            If ObjRFG.GetWhereCondition("H.Site_Code", 4) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 4)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Subject", 6)

            mQry = " SELECT H.DocID,H.V_Type,H.V_Prefix,H.V_Date,H.V_No,H.Div_Code,H.Site_Code, " & _
                    " H.SubCode,H.FromProcess,H.ToProcess,H.FromGodown,H.ToGodown,H.TotalQty,H.TotalMeasure, " & _
                    " H.Amount,H.Addition,H.Deduction,H.NetAmount,H.Remarks,SM.Name AS SiteName, " & _
                    " L.Item_UID,L.Item,L.Godown,L.Unit,L.Remarks AS LineRemark,SG.DispName AS OrderByName, " & _
                    " I.Description AS ItemDesc,B.Writer ,B.Publisher ,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, " & _
                    " Ad.AccessionNo ,Ad.Mrp ,Ad.Rate  " & _
                    " FROM StockHead H " & _
                    " LEFT JOIN Voucher_Type Vt ON H.V_Type=Vt.V_Type " & _
                    " LEFT JOIN Stock L ON L.DocID=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.OrderBy  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=L.Item  " & _
                    " LEFT JOIN Item I ON I.Code =L.Item  " & _
                    " INNER JOIN Lib_AccessionDetail Ad ON Ad.Book_UID = L.Item_UID " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Books Return from Member Report"
    Private Sub ProcBooksReturnReport(ByVal bNCat As String, ByVal bReportTitle As String, ByVal bReportPrint As String, ByVal bReportStatus As String)
        Try
            Call ObjRFG.FillGridString()
            RepName = bReportPrint : RepTitle = bReportTitle

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & " AND Vt.NCat IN ( " & AgL.Chk_Text(bNCat) & " )"

            mCondStr = mCondStr & " AND L.Book_UID IS NOT NULL"
            mCondStr = mCondStr & " AND L.Status ='" & bReportStatus & "'"

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Member", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.TransactionBy", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Book", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 4)

            If ObjRFG.GetWhereCondition("H.Site_Code", 5) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 5)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 7)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.Class", 8)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Subject", 9)

            mQry = " SELECT  H.DocID,H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.Member, H.DonationApp, H.TransactionBy, H.MemberRemarks, H.Remarks, " & _
                    " L.Book_UID, L.Book, L.ForDays, L.ToReturnDate, L.ReturnDocId, " & _
                    " L.ReturnDate, L.Status, L.FinePerDay, L.FineAmount, L.Remarks AS LineRemark, L.Edition, " & _
                    " SM.Name AS SiteName,M.MemberCardNo ,SG.Name AS MemberName,SG.DispName AS MemberDispName, " & _
                    " DA.V_Type AS DAV_Type,DA.V_No AS DAV_No,SGT.Name AS TransByName,SGT.DispName AS TransByDispName, " & _
                    " I.Description AS BookDesc,B.Writer ,B.Publisher,  " & _
                    " R.V_Type AS RetV_Type, R.V_No AS RetV_No ,L.AccessionNo " & _
                    " FROM Lib_BookIssue H " & _
                    " LEFT JOIN Lib_BookIssueDetail L  ON L.ReturnDocId =H.DocID   " & _
                    " LEFT JOIN SiteMast SM ON SM.Code =H.Site_Code  " & _
                    " LEFT JOIN Lib_Member M ON M.SubCode=H.Member  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode =H.Member  " & _
                    " LEFT JOIN Lib_DonationApp DA ON DA.DocID=H.DonationApp  " & _
                    " LEFT JOIN SubGroup SGT ON SGT.SubCode=H.TransactionBy  " & _
                    " LEFT JOIN Item I ON I.Code=L.Book  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=L.Book  " & _
                    " LEFT JOIN Lib_BookIssue R ON R.DocID=L.ReturnDocId " & _
                    " LEFT JOIN Voucher_Type Vt ON H.V_Type=Vt.V_Type " & _
                    " " & mCondStr & ""
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception

            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Stationary Issue Report"
    Private Sub ProcStationaryIssueReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_StationaryIssueReport" : RepTitle = "Stationary Issue Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & " AND Vt.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.StationaryAdjustmentIssue) & " )"

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SubCode", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.OrderBy", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 2)

            If ObjRFG.GetWhereCondition("H.Site_Code", 3) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 3)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 5)

            mQry = " SELECT H.DocID,H.V_Type,H.V_Prefix,H.V_Date,H.V_No,H.Div_Code,H.Site_Code, " & _
                    " H.SubCode,H.FromProcess,H.ToProcess,H.FromGodown,H.ToGodown,H.TotalQty,H.TotalMeasure, " & _
                    " H.Amount,H.Addition,H.Deduction,H.NetAmount,H.Remarks,SM.Name AS SiteName, " & _
                    " L.Item_UID,L.Item,L.Godown,L.Qty_Iss, L.Unit,L.Remarks AS LineRemark,SG.DispName AS OrderByName,SGI.DispName AS IssuedToName, " & _
                    " I.Description AS ItemDesc ,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType " & _
                    " FROM StockHead H " & _
                    " LEFT JOIN Stock L ON L.DocID=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.OrderBy  " & _
                    " LEFT JOIN SubGroup SGI ON SGI.SubCode=H.SubCode  " & _
                    " LEFT JOIN Item I ON I.Code =L.Item  " & _
                    " LEFT JOIN Voucher_Type Vt ON H.V_Type=Vt.V_Type " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Stock Summary"
    Private Sub procStockSummary(ByVal bReportType As String)
        Try
            Call ObjRFG.FillGridString()

            Dim bQry$ = ""
            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If bReportType <> "Stationary Stock In Hand" Then
                If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            Else
                ObjRFG.ParameterDate2_Value = ObjRFG.ParameterDate1_Value
            End If

            mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND I.ItemType=" & AgL.Chk_Text(ClsMain.ItemType.Stationary) & ""

            If ObjRFG.GetWhereCondition("V1.Site_Code", 2) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.Site_Code", 2)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.Item", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.Div_Code", 1)

            mQry = " SELECT V1.*,SM.ManualCode AS Site_Name,I.Description AS ItemDesc, " & _
                " Vc.NCatDescription As ProcessDescription, P.ProcessGroup As ProcessGroup, " & _
                " PG.Description AS ProcessGroupDesc " & _
                " FROM ( " & StockQry(ObjRFG.ParameterDate1_Value, ObjRFG.ParameterDate2_Value) & " ) V1" & _
                " LEFT JOIN SiteMast SM ON SM.Code = V1.Site_Code " & _
                " LEFT JOIN Item I ON I.Code = V1.Item " & _
                " LEFT JOIN Process P On V1.Process = P.NCat " & _
                " LEFT JOIN VoucherCat Vc On P.NCat = Vc.NCat " & _
                " LEFT JOIN ProcessGroup PG ON PG.Code = P.ProcessGroup " & _
                " " & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            If bReportType = "Stationary Stock Summary" Then
                RepName = "Lib_StockSummary" : RepTitle = "Stationary Stock Summary"
            ElseIf bReportType = "Stationary Stock Ledger" Then
                RepName = "Lib_StockReport" : RepTitle = "Stationary Stock Ledger"
            ElseIf bReportType = "Stationary Stock In Hand" Then
                RepName = "Lib_StockInHand" : RepTitle = "Stationary Stock In Hand"
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub

    Private Function StockQry(ByVal mFromDate As String, ByVal mToDate As String)
        StockQry = " SELECT S.Site_Code,S.Div_Code,isnull(S.Process,'') AS Process, " & _
                " " & AgL.ConvertDate(mFromDate) & " As V_Date, 'Opening' As DocID,  " & _
                " 1 AS V_No, 'Opening' As  VType,'Opening' AS TransactionaNo,S.Item , " & _
                " sum(isnull(S.Qty_Rec,0)) - sum(isnull(S.Qty_Iss,0)) AS Opening,0 AS ReceiveQty, " & _
                " 0 AS IssueQty " & _
                " FROM Stock S " & _
                " LEFT JOIN StockHead SH ON SH.DocId=S.DocId " & _
                " WHERE S.V_Date < " & AgL.ConvertDate(mFromDate) & " " & _
                " AND isnull(SH.IsDeleted,0) =0  " & _
                " And ISNULL(SH.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'" & _
                " GROUP BY S.Item,S.Site_Code,S.Div_Code,S.Process "

        StockQry = StockQry & " UNION ALL " & _
                " SELECT S.Site_Code,S.Div_Code,isnull(S.Process,'') AS Process, " & _
                " S.V_Date,S.DocID , S.V_No,Vt.Description AS VType,Vt.V_Type +'-'+ Convert(NVARCHAR(10),S.V_No ) AS TransactionaNo, " & _
                " S.Item ,0 AS Opening,isnull(S.Qty_Rec,0)AS ReceiveQty,isnull(S.Qty_Iss,0) AS IssueQty   " & _
                " FROM Stock S " & _
                " LEFT JOIN StockHead SH ON SH.DocId=S.DocId " & _
                " LEFT JOIN Voucher_Type Vt ON Vt.V_Type = S.V_Type  " & _
                " WHERE S.V_Date BETWEEN " & AgL.ConvertDate(mFromDate) & " And " & AgL.ConvertDate(mToDate) & " " & _
                " AND isnull(SH.IsDeleted,0) =0  " & _
                " And ISNULL(SH.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
    End Function
#End Region

#Region "Book Issue To Branch Report"
    Private Sub ProcBookIssueToBranchReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_BookIssueToBranchReport" : RepTitle = "Books Issue To Branch Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & " AND Vt.NCat IN ( " & AgL.Chk_Text(ClsMain.Temp_NCat.BranchTransfer) & " )"

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.FromGodown", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.ToGodown", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 4)

            If ObjRFG.GetWhereCondition("H.Site_Code", 5) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 5)
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 7)

            mQry = " SELECT H.DocID,H.V_Type,H.V_Prefix,H.V_Date,H.V_No,H.Div_Code,H.Site_Code, " & _
                    " H.SubCode,H.FromProcess,H.ToProcess,H.FromGodown,H.ToGodown,H.TotalQty,H.TotalMeasure, " & _
                    " H.Amount,H.Addition,H.Deduction,H.NetAmount,H.Remarks,SM.Name AS SiteName, " & _
                    " L.Item_UID,L.Item,L.Godown,L.Unit,L.Remarks AS LineRemark,SG.DispName AS OrderByName, " & _
                    " I.Description AS ItemDesc,B.Writer ,B.Publisher ,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, " & _
                    " GF.Description AS FromGoodownDesc ,GT.Description AS ToGoodownDesc " & _
                    " FROM StockHead H " & _
                    " LEFT JOIN Stock L ON L.DocID=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.OrderBy  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=L.Item  " & _
                    " LEFT JOIN Item I ON I.Code =L.Item  " & _
                    " LEFT JOIN Godown GF ON GF.Code=H.FromGodown  " & _
                    " LEFT JOIN Godown GT ON GT.Code=H.ToGodown  " & _
                    " LEFT JOIN Voucher_Type Vt ON H.V_Type=Vt.V_Type " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Book Master Report"
    Private Sub ProcBookMasterReport()
        Dim mCondStr$ = ""
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_BookMaster" : RepTitle = "Book Master"

            mCondStr = "WHERE I.ItemType = '" & ClsMain.ItemType.Book & "'"

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Subject", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Writer", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Publisher", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("BT.Code", 2)

            mQry = "SELECT I.UID, S.Description AS Subject,BT.Description AS [Book Type], " & _
                    " I.ManualCode as [Book Code], " & _
                    " I.Description [Book Name], " & _
                    " B.Series, B.Volume, B.ISBN, B.Language, Sc.Description As ScrapCategory, " & _
                    " B.Writer, B.Publisher, " & _
                    " B.SearchKeyWords AS [Search Key Words], " & _
                    " G.Description As Almira, I.GodownSection As Shelf, " & _
                    " Case When IsNull(B.WithCd,0) = 0 Then 'No' Else 'Yes' End As WithCD, " & _
                    " G1.Description As [Cd Almira], B.GodownSectionCD As [CD Shelf], B.Subject As SubjectCode " & _
                    " FROM Lib_Book B  " & _
                    " LEFT JOIN Item I ON B.Code = I.Code " & _
                    " LEFT JOIN Lib_BookType BT ON BT.Code=B.BookType " & _
                    " LEFT JOIN Lib_Subject S ON S.Code=B.Subject " & _
                    " LEFT JOIN Lib_ScrapCategory Sc On B.ScrapCategory = Sc.Code  " & _
                    " LEFT JOIN Godown G On I.Godown = G.Code " & _
                    " LEFT JOIN Godown G1 On B.GodownCD = G1.Code " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Member Master Report"
    Private Sub ProcMemberMasterReport(ByVal bRepName As String, ByVal bRepTitle As String)
        Dim mCondStr$ = ""
        Try
            Call ObjRFG.FillGridString()
            'RepName = "Lib_MemberMaster" : RepTitle = "Member Master"
            RepName = bRepName : RepTitle = bRepTitle

            mCondStr = "WHERE 1=1"

            If ObjRFG.GetWhereCondition("Sg.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Sg.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("SG.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.SubCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.SubCode", 2)
           

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.MemberType", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.Class", 4)

            mQry = "SELECT Sg.SubCode AS MemberCode, Sg.ManualCode AS MemberManualCode, " & _
                        " Sg.DispName AS MemberName,  " & _
                        " M.Student, M.Employee, M.MemberCardNo,  " & _
                        " M.MotherName, M.AdmissionNo, " & _
                        " M.Class, M.Session, M.ReminderRemark, " & _
                        " Mt.Description AS MemberType, S.Description AS Subject, " & _
                        " M.AdmissionNo, M.Class, M.Session, " & _
                        " Sg.Phone, Sg.Mobile, Sg.FAX , Sg.EMail ,Sg.FatherName,Sg.Add1,Sg.Add2,Sg.Add3 " & _
                        " FROM Lib_Member M " & _
                        " LEFT JOIN SubGroup Sg ON M.SubCode = Sg.SubCode " & _
                        " LEFT JOIN Lib_MemberType Mt ON M.MemberType = Mt.Code " & _
                        " LEFT JOIN Lib_Subject S ON M.Subject = S.Code " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Journals Not Received Report"
    Private Sub ProcJournalsNotReceivedReport()
        Dim mCondStr$ = ""
        Dim bDateDiff = 0
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_JournalsReceivedReport" : RepTitle = "Journals Not Received Report"

            mCondStr = "WHERE 1=1"
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("ReqDetail.General", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("ReqDetail.Recurrance", 1)

            mQry = "SELECT ReqDetail.*, RecDetail.*, Item.Description As GeneralDescription   FROM " & _
                        " (SELECT RQ.General, Max(RQ.Fromdate) AS FromDate, Max(RQ.UptoDate) AS UptoDate, " & _
                        " Max(RQ.Recurrance) AS Recurrance, Sum(RQ.CopiesRequired) AS CopiesRequired " & _
                        " FROM ( " & _
                        " SELECT X.General, X.Qty, X.Amount, X.FromDate, X.UptoDate, X.mMonths, X.mDays, X.Recurrance, " & _
                        " (CASE WHEN X.Recurrance = '" & ClsMain.Recurrance.Monthly & "' THEN  " & _
                        " 		Ceiling(Convert(FLOAT,X.MMonths)/1)*X.Qty " & _
                        " 	WHEN X.Recurrance = '" & ClsMain.Recurrance.Quarterly & "' THEN  " & _
                        " 		Ceiling(Convert(FLOAT,X.MMonths)/3)*X.Qty  " & _
                        " 	WHEN X.Recurrance = '" & ClsMain.Recurrance.Bimonthly & "' THEN  " & _
                        " 		Ceiling(Convert(FLOAT,X.MMonths)/2) *X.Qty " & _
                        " 	WHEN X.Recurrance = '" & ClsMain.Recurrance.HalfYearly & "' THEN  " & _
                        " 		Ceiling(Convert(FLOAT,X.MMonths)/6) *X.Qty " & _
                        " 	WHEN X.Recurrance = '" & ClsMain.Recurrance.Annually & "' THEN  " & _
                        " 		Ceiling(Convert(FLOAT,X.MMonths)/12) *X.Qty " & _
                        " 	WHEN X.Recurrance = '" & ClsMain.Recurrance.Daily & "' THEN  " & _
                        " 		X.MDays *X.Qty " & _
                        " 	WHEN X.Recurrance = '" & ClsMain.Recurrance.Weekly & "' THEN  " & _
                        " 		Ceiling(Convert(FLOAT,X.Mdays)/7) *X.Qty " & _
                        " 	WHEN X.Recurrance = '" & ClsMain.Recurrance.Fortnightly & "' THEN  " & _
                        " 		Ceiling(Convert(FLOAT,X.MDays)/15) *X.Qty " & _
                        " 	ELSE 0 END) AS CopiesRequired " & _
                        "   FROM (SELECT H.General, H.Qty, H.Amount, H.Recurrance , (CASE WHEN H.FromDate > " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " THEN H.FromDate ELSE " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " End) AS FromDate, " & _
                        " 	(CASE WHEN IsNull(H.ToDate,GetDate()) < " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " THEN IsNull(H.ToDate,GetDate()) ELSE " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " End) AS UptoDate, " & _
                        " 	Datediff (month,(CASE WHEN H.FromDate > " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " THEN H.FromDate ELSE " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " End),(CASE WHEN IsNull(H.ToDate,GetDate()) < " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " THEN IsNull(H.ToDate,GetDate()) ELSE " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " End)) AS mMonths, " & _
                        " 	Datediff (day,(CASE WHEN H.FromDate > " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " THEN H.FromDate ELSE " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " End),(CASE WHEN IsNull(H.ToDate,GetDate()) < " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " THEN IsNull(H.ToDate,GetDate()) ELSE " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " End)) AS mDays	 " & _
                        "   FROM Lib_Subscription H) AS X) AS RQ GROUP BY RQ.General " & _
                        " ) AS ReqDetail " & _
                        " LEFT JOIN  " & _
                        " 	(SELECT PC.Item, Sum(PC.Qty) AS RecQty   " & _
                        " 	 FROM Lib_Generals G  " & _
                        " 	 LEFT JOIN PurchChallanDetail PC ON G.Code = PC.Item WHERE PC.V_Date BETWEEN " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " AND " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " GROUP BY PC.Item) AS RecDetail ON ReqDetail.General = RecDetail.Item " & _
                        " LEFT JOIN Item ON ReqDetail.General = Item.Code  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Payment Report"
    Private Sub ProcPaymentReport(ByVal bReportType As String)
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_PaymentRegister" : RepTitle = "Payment Report"

            Dim mCondStr$ = ""
            Dim bFeildName As String = ""



            If bReportType = "Payment" Then
                bFeildName = "PaybleAmount"
            Else
                bFeildName = "ReceivableAmount"
            End If


            mCondStr = " Where IsNull(H.TransactionType,'Payment') = '" & bReportType & "' "

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SubCode", 0)

            mQry = " SELECT H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code,H.Site_Code, " & _
                        " H.SubCode, H.CurrBalance, H.PaidAmount, H.NetAmount, H.CashBank, H.ChqNo, " & _
                        " H.ChqDate, H.Remark, H.EntryBy, H.EntryDate, H.EntryType, H.EntryStatus, H.ApproveBy, " & _
                        " H.ApproveDate, H.MoveToLog, H.MoveToLogDate, H.IsDeleted, H.Status, H.UID, H.Discount, " & _
                        " L.DocID, L.Sr, L.ReferenceDocID, L.Amount, L.UID, L.Reference_Sr, " & _
                        " IsNull(D." & bFeildName & ",0) AS BillAmt, IsNull(D.AdjustedAmount,0) AS TotalAdjustedAmt, " & _
                        " Sg.DispName AS VendorName, H.V_Type  + '-' + Convert(NVARCHAR,H.V_No) AS PaymentNo, " & _
                        " D.V_Type + '-' + Convert(NVARCHAR,D.V_No) AS BillNo, '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, " & _
                        " Sg1.DispName As CashBankAc " & _
                        " FROM DuesPayment H " & _
                        " LEFT JOIN DuesPaymentDetail L ON H.DocID = L.DocID " & _
                        " LEFT JOIN Dues D ON L.ReferenceDocID + Convert(NVARCHAR ,L.Reference_Sr) = D.DocID + Convert(NVARCHAR, D.Sr)   " & _
                        " LEFT JOIN SubGroup Sg ON H.SubCode = Sg.SubCode " & _
                        " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                        " LEFT JOIN Voucher_Type Vt1 ON D.V_Type = Vt1.V_Type " & _
                        " LEFT JOIN SubGroup Sg1 On Sg1.SubCode = H.CashBankAc " & _
                        " " & mCondStr & ""


            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Fine Receipt Report"
    Private Sub ProcFineReceiptReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_FineReceiptRegister" : RepTitle = "Fine Receipt Report"

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""
            Dim bFeildName As String = ""

            'mCondStr = " where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(D.IsDeleted,0)=0 And ISNULL(D.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND D.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("D.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("D.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("D.Site_Code", 0)
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("D.SubCode", 1)

            If ObjRFG.ParameterCmbo1_Value = "Yes" Then
                mCondStr1 = mCondStr1 & " Having (sum(IsNull(D.ReceivableAmount,0))-sum(IsNull(D.AdjustedAmount,0))) >0 "
            ElseIf ObjRFG.ParameterCmbo1_Value = "No" Then
                mCondStr1 = mCondStr1 & " Having (sum(IsNull(D.ReceivableAmount,0))-sum(IsNull(D.AdjustedAmount,0))) =0 "
            End If


            mQry = " SELECT max(Sg.ManualCode) As MemberCode,max(D.V_Date) AS V_Date, sum(IsNull(D.ReceivableAmount,0)) AS BillAmt,D.SubCode,  " & _
                        " sum(IsNull(D.AdjustedAmount,0)) AS TotalAdjustedAmt,  " & _
                        " (sum(IsNull(D.ReceivableAmount,0))-sum(IsNull(D.AdjustedAmount,0))) AS FineAmt, " & _
                        " max(Sg.DispName) AS VendorName, max(D.Site_Code) AS Site_Code, " & _
                        " max(D.V_Type + '-' + Convert(NVARCHAR,D.V_No)) AS BillNo  " & _
                        " FROM  Dues D  " & _
                        " LEFT JOIN SiteMast SM ON SM.Code =D.Site_Code " & _
                        " LEFT JOIN SubGroup Sg ON D.SubCode = Sg.SubCode   " & _
                        " LEFT JOIN Voucher_Type Vt1 ON D.V_Type = Vt1.V_Type   " & _
                        " WHERE Vt1.V_Type='" & ClsMain.Temp_NCat.BookIssueReceive & "' " & _
                        " " & mCondStr & " " & _
                        " GROUP BY D.SubCode " & _
                        " " & mCondStr1 & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Bill Wise Outstanding Report"
    Private Sub ProcBillWiseOutstandingReport(ByVal bReportType As String, ByVal bRepTitle As String)
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_BillWiseOutctandingReport" : RepTitle = bRepTitle

            Dim mCondStr$ = ""
            Dim bFeildName As String = ""
            mCondStr = " Where 1=1 "

            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SubCode", 0)

            If bReportType = "Payment" Then
                bFeildName = "PaybleAmount"
                mCondStr = mCondStr & " And H.PaybleAmount > 0 "
            Else
                bFeildName = "ReceivableAmount"
                mCondStr = mCondStr & " And H.ReceivableAmount > 0 "
            End If

            'mQry = " SELECT H.DocID, H.Sr, H.V_Type,H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
            '            " H.SubCode, H.Narration, H.ReferenceDocID, H." & bFeildName & " AS Amount, " & _
            '            " IsNull(H.AdjustedAmount,0) As PaiddAmount, H.EntryBy, " & _
            '            " H.EntryDate, H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate, H.MoveToLog, " & _
            '            " H.MoveToLogDate, H.IsDeleted, H.Status, H.UID,  " & _
            '            " H.V_Type  + '-' + Convert(NVARCHAR,H.V_No) AS BillNo, " & _
            '            " Sg.DispName AS Name,  " & _
            '            " IsNull(H." & bFeildName & ",0) -  IsNull(H.AdjustedAmount,0) AS BalanceAmt " & _
            '            " FROM Dues H " & _
            '            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
            '            " LEFT JOIN SubGroup Sg ON H.SubCode = Sg.SubCode " & _
            '            " " & mCondStr & ""
            'DsRep = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT H.DocID, H.Sr, H.V_Type,H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                        " H.SubCode, H.Narration, H.ReferenceDocID, H." & bFeildName & " AS Amount, " & _
                        " IsNull(H.AdjustedAmount,0) As AdjustedAmount, H.EntryBy, " & _
                        " H.EntryDate, H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate, H.MoveToLog, " & _
                        " H.MoveToLogDate, H.IsDeleted, H.Status, H.UID,  " & _
                        " H.V_Type + '-' + Convert(NVARCHAR, H.V_No) AS BillNo, H.V_Date, Sg.DispName AS Name, " & _
                        " IsNull(Pd.Amount,0) AS PaidAmount, " & _
                        " IsNull(H." & bFeildName & ",0) -  IsNull(H.AdjustedAmount,0) AS BalanceAmt, " & _
                        " P.V_Type + '-' + Convert(NVARCHAR, P.V_No) AS PaymentNo, P.CashBank, P.ChqNo, " & _
                        " P.ChqDate, P.V_Date as PaymentDate " & _
                        " FROM Dues H  " & _
                        " LEFT JOIN DuesPaymentDetail Pd ON H.DocID = Pd.ReferenceDocID " & _
                        " LEFT JOIN DuesPayment P On Pd.DocId = P.DocId " & _
                        " LEFT JOIN SubGroup Sg ON H.SubCode = Sg.SubCode " & _
                        " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                        " " & mCondStr & "" & " Order By H.DocId "
            DsRep = AgL.FillData(mQry, AgL.GCn)


            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Employee Master Report"
    Private Sub ProcEmployeeMasterReport()
        Dim mCondStr$ = ""
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_EmployeeMaster" : RepTitle = "Employee Master"

            mCondStr = "WHERE 1=1"

            If ObjRFG.GetWhereCondition("SG.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("SG.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("SG.Site_Code", 0)
            End If

            mQry = "SELECT  Sg.SubCode, Sg.Site_Code, Sg.Div_Code, Sg.SiteList, Sg.NamePrefix, Sg.Name, " & _
                        "  Sg.DispName, Sg.GroupCode, Sg.GroupNature, Sg.ManualCode, Sg.Nature, " & _
                        "  Sg.Add1, Sg.Add2, Sg.Add3, Sg.CityCode, Sg.CountryCode, Sg.PIN, " & _
                        "  Sg.Phone, Sg.Mobile, Sg.FAX, Sg.EMail, Sg.CSTNo, Sg.LSTNo, Sg.TINNo, " & _
                        "  Sg.PAN, Sg.TDS_Catg, Sg.ActiveYN, Sg.CreditLimit, Sg.CreditDays, Sg.DueDays, " & _
                        "  Sg.ContactPerson, Sg.Party_Type, Sg.PAdd1,Sg.PAdd2, Sg.PAdd3, Sg.PCityCode, " & _
                        "  Sg.PCountryCode, Sg.PPin, Sg.PPhone, Sg.PMobile, Sg.PFax, Sg.Curr_Bal, " & _
                        "  Sg.OpBal_DocId, Sg.FatherName, Sg.FatherNamePrefix, Sg.HusbandName, Sg.HusbandNamePrefix, " & _
                        "  Sg.DOB, Sg.Remark, Sg.Location, Sg.U_Name, Sg.U_EntDt, Sg.U_AE, " & _
                        "  Sg.Edit_Date, Sg.ModifiedBy, Sg.ApprovedBy, Sg.StCategory, Sg.SiteStr, " & _
                        "  Sg.STRegNo, Sg.ECCNo, Sg.EXREGNO, Sg.CEXRANGE, Sg.CEXDIV, " & _
                        "  Sg.COMMRATE, Sg.VATNo, Sg.CommonAc, Sg.UpLoadDate, Sg.ChequeReport, " & _
                        "  Sg.EntryBy, Sg.EntryDate, Sg.EntryType, Sg.EntryStatus, Sg.ApproveBy, " & _
                        "  Sg.ApproveDate, Sg.MoveToLog, Sg.IsDeleted, Sg.MoveToLogDate, Sg.Status, " & _
                        "  Sg.SisterConcernYn, Sg.UID, Sg.SalesTaxPostingGroup, Sg.ExcisePostingGroup, Sg.EntryTaxPostingGroup, H.Designation " & _
                        " FROM Pay_Employee H " & _
                        " LEFT JOIN SubGroup Sg ON H.SubCode = Sg.SubCode " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Stock Stock Site Transfer Report"
    Private Sub ProcStockSiteTransferReport(ByVal bRepName As String, ByVal bRepTitle As String)
        Try
            Call ObjRFG.FillGridString()
            'RepName = "Lib_StockSiteTransferReport" : RepTitle = "Site Transfer Report"
            RepName = bRepName : RepTitle = bRepTitle

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 And Vt.NCat = '" & ClsMain.Temp_NCat.BranchTransfer & "' "


            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item_UID", 2)

            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                        " H.OrderBy, H.SubCode, H.FromProcess, H.ToProcess, H.FromGodown, H.ToGodown, " & _
                        " H.TotalQty, H.TotalMeasure, H.Amount, H.Addition, H.Deduction, H.NetAmount, " & _
                        " H.Remarks, H.IsDeleted, H.EntryBy, H.EntryDate, H.EntryType, H.EntryStatus, " & _
                        " H.ApproveBy, H.ApproveDate, H.MoveToLog, H.MoveToLogDate, H.Status, " & _
                        " H.UID, H.ReferenceDocID, H.Structure, H.ToSite_Code, " & _
                        " L.Sr, L.V_Type, L.V_Prefix, L.V_Date, L.V_No, L.Div_Code, " & _
                        " L.Site_Code, L.SubCode, L.Currency, L.SalesTaxGroupParty, L.Structure, " & _
                        " L.BillingType, L.Item, L.Item_UID, L.ProcessGroup, L.Godown, " & _
                        " L.Qty_Iss, L.Qty_Rec, L.Unit, L.MeasurePerPcs, L.Measure_Iss, L.Measure_Rec, " & _
                        " L.MeasureUnit, L.Rate, L.Amount, L.Addition, L.Deduction, L.NetAmount, " & _
                        " L.Remarks, L.Process, L.Status, L.UID, L.FIFORate, L.FIFOAmt, L.AVGRate, " & _
                        " L.AVGAmt, L.Cost, L.Doc_Qty, L.ReferenceDocID, L.Edition, " & _
                        " '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, " & _
                        " I.Description As ItemDescription, S.Description As SubjectDesc, " & _
                        " Sm.Name As FromSiteName, Sm1.Name As ToSiteName ," & _
                        " B.Writer, B.Publisher, B.Pages, B.PlaceOfPub, A.Rate As BookRate, " & _
                        " H.V_Type + '-' + Convert(nVarChar,H.V_No) As TransferNo " & _
                        " FROM StockHead H " & _
                        " LEFT JOIN Stock L ON H.DocID = L.DocID " & _
                        " LEFT JOIN Item I On L.Item = I.Code " & _
                        " LEFT JOIN SiteMast Sm On H.Site_Code = Sm.Code " & _
                        " LEFT JOIN SiteMast Sm1 ON H.ToSite_Code = Sm1.Code " & _
                        " LEFT JOIN Lib_Book B On I.Code = B.Code " & _
                        " LEFT JOIN Lib_Subject S On B.Subject = S.Code " & _
                        " LEFT JOIN Lib_AccessionDetail A On L.Item_Uid = A.Book_UID " & _
                        " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                        " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region " Scrap Sale Requisition Register"
    Private Sub ProSaleRequisitionRegisterReport()
        Try
            Call ObjRFG.FillGridString()
            'RepName = "Lib_SaleDetailReport" : RepTitle = "Scrap Sale Requisition Report"
            RepName = "Lib_ScrapSaleRequisitionReport" : RepTitle = "Scrap Sale Requisition Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "


            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.ScrapCategory", 0)

            If ObjRFG.GetWhereCondition("H.Site_Code", 1) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 1)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 2)


            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, " & _
                   " H.Site_Code, H.ManualRefNo,H.Remarks, H.TotalQty, H.EntryBy, H.EntryDate, " & _
                   " H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate, H.MoveToLog, " & _
                   " H.MoveToLogDate, H.IsDeleted, H.Status, H.UID,  " & _
                   " L.ScrapCategory, L.Qty, L.Unit, L.Remark, D.Div_Name, Sm.Name AS SiteName,  " & _
                   " c.Description AS ScrapCategoryDesc, " & _
                   " '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType,Vt.Description AS VoucherType  " & _
                   " FROM Lib_ScrapSaleRequisition H  " & _
                   " LEFT JOIN Lib_ScrapSaleRequisitionDetail L  ON H.DocID = L.DocId " & _
                   " LEFT JOIN Division D ON H.Div_Code = D.Div_Code " & _
                   " LEFT JOIN SiteMast Sm ON H.Site_Code = Sm.Code  " & _
                   " LEFT JOIN Voucher_Type VT ON VT.V_Type =H.V_Type  " & _
                   " LEFT JOIN Lib_ScrapCategory C ON L.ScrapCategory = C.Code " & _
                   " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Book Purchase Quatation Report"
    Private Sub ProcStationaryPurchQuatationReport()
        Try
            Call ObjRFG.FillGridString()
            RepName = "Lib_StationaryPurchaseQuatationReport" : RepTitle = "Stationary Purchase Quatation Report"

            Dim mCondStr$ = ""

            mCondStr = " where 1=1 "
            mCondStr = mCondStr & " AND Vt.NCat = '" & ClsMain.Temp_NCat.StationaryQuotation & "' "
            mCondStr = mCondStr & " AND ISNULL(H.IsDeleted,0)=0 And ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "'"
            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vendor", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 1)

            If ObjRFG.GetWhereCondition("H.Site_Code", 2) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 2)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_Code", 3)

            mQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.Vendor, H.VendorName, H.Currency, H.Structure, H.BillingType, H.VendorQuoteNo, H.VendorQuoteDate, " & _
                    " H.TermsAndConditions, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, H.PostingGroupSalesTaxParty, H.PurchIndent, " & _
                    " L.Item, L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalMeasure AS LineTotalMeasure, " & _
                    " L.Rate, L.Amount, L.PostingGroupSalesTaxItem, L.OrdQty, L.OrdMeasure, L.PurchQty, L.PurchMeasure, " & _
                    " I.Description AS ItemDesc, SM.Name AS SiteName,SF.*, SL.* , " & _
                    " '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType  " & _
                    " FROM PurchQuotation H " & _
                    " LEFT JOIN PurchQuotationDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.BookPurchaseQuotation) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.BookPurchaseQuotation) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                    " " & mCondStr & ""
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Member Visit Register"

    Private Sub ProcMemberVisitRegister()
        Try
            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub



            Call ObjRFG.FillGridString()
            mCondStr = " where H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SubCode", 1)
           

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Div_code", 2)

            mCondStr = mCondStr & "and H.V_Type in ('" & ClsMain.Temp_NCat.MemberVisit & "')"


            mQry = " SELECT H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_Time, H.V_No, H.Div_Code, H.Site_Code, H.SubCode,  " & _
                    " H.VehicleType, H.VehicleNo, H.Driver, H.Remarks, H.EntryBy, H.EntryDate, H.EntryType, H.Manual_RefNo, H.MeterReading,  " & _
                    " H.InOut AS OpenType, H.Close_MeterReading, H.Close_Date, H.Close_Time, H.Close_Remarks, H.Close_EntryBy, " & _
                    " CASE WHEN H.Close_Date IS NOT NULL THEN 'Yes' ELSE 'No' END AS IsClosed, " & _
                    " CASE WHEN H.Close_Date IS NOT NULL THEN CASE IsNull(H.InOut,'') WHEN '" & ClsMain.InOut.GateOut & "' THEN '" & ClsMain.InOut.GateIn & "' WHEN '" & ClsMain.InOut.GateIn & "' THEN '" & ClsMain.InOut.GateOut & "' END ELSE '' END AS CloseType , " & _
                    " '' as RegistrationNo ,'' as VehicleName,Sg.DispName as Member " & _
                    " FROM dbo.GateInOut H " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode = H.SubCode " & _
                    " " & mCondStr & "                                   "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Lb_MemberVisitRegister" : RepTitle = "Member Visit Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)


        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub

#End Region
End Class
