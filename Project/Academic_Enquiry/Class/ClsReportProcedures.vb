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
    Private Const EnquiryReport As String = "EnquiryReport"
    Private Const EnquiryFollowupReport As String = "EnquiryFollowupReport"
    Private Const EnquiryCloseRegister As String = "EnquiryCloseRegister"
    Private Const ProspectusPurchaseRegister As String = "ProspectusPurchaseRegister"
    Private Const ProspectusSaleRegister As String = "ProspectusSaleRegister"
    Private Const ProspectusStockRegister As String = "ProspectusStockRegister"



#End Region

#Region "Queries Definition"
    Dim mHelpCustomerQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Customer Name] From SubGroup Where Nature In ('Customer') And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpCityQry$ = "Select Convert(BIT,0) As [Select],CityCode, CityName From City "
    Dim mHelpStateQry$ = "Select Convert(BIT,0) As [Select],State_Code, State_Desc From State "
    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpEntryPointQry$ = " Select Distinct Convert(BIT,0) As [Select], User_Permission.MnuText AS code , User_Permission.MnuText As [Entry Point] From User_Permission  "
    Dim mHelpBankQry$ = "Select Convert(BIT,0) As [Select],Bank_Code Code, Bank_Name As [Bank Name] From Bank "
    Dim mHelpBankBranchQry$ = "Select Convert(BIT,0) As [Select],BankBranch_Code Code, BankBranch_Name As [Bank Branch Name] From BankBranch "
    Dim mHelpSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "
    Dim mHelpCategaryQry$ = "Select Convert(BIT,0) As [Select],Code, ManualCode As [Category Short Name], Description As Category From Sch_Category "
    Dim mHelpEmployeeQry$ = "Select Convert(BIT,0) As [Select],  v.subcode AS Code,Sg.DispName AS Name FROM Pay_Employee V LEFT JOIN SubGroup Sg ON v.SubCode=Sg.SubCode Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  AND IsNull(v.IsTeachingStaff,0) = 0 "
    Dim mHelpCloseQry$ = "Select Convert(BIT,0) As [Select],  v.subcode AS Code,Sg.DispName AS Name FROM Pay_Employee V LEFT JOIN SubGroup Sg ON v.SubCode=Sg.SubCode Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  AND IsNull(v.IsTeachingStaff,0) = 0 "

    'Dim mHelpEnquiryModeQry = " SELECT Convert(BIT,0) As [Select],'E-Mail' AS Code ,'E-Mail' AS Name  " & _
    '                        " UNION ALL   " & _
    '                        " SELECT Convert(BIT,0) As [Select],'Phone' AS Code ,'Phone' AS Name   " & _
    '                        " UNION ALL   " & _
    '                        " SELECT Convert(BIT,0) As [Select],'SMS' AS Code ,'SMS' AS Name   " & _
    '                        " UNION ALL   " & _
    '                        " SELECT Convert(BIT,0) As [Select],'Walking At Office' AS Code ,'Walking At Office' AS Name "

    Dim mHelpEnquiryModeQry = "Select Convert(BIT,0) As [Select],Code, Code as Name From Sch_EnquiryMode "


    'Dim mHelpFollowupModeQry = " SELECT Convert(BIT,0) As [Select],'E-Mail' AS Code ,'E-Mail' AS Name  " & _
    '                    " UNION ALL   " & _
    '                    " SELECT Convert(BIT,0) As [Select],'Phone' AS Code ,'Phone' AS Name   " & _
    '                    " UNION ALL   " & _
    '                    " SELECT Convert(BIT,0) As [Select],'SMS' AS Code ,'SMS' AS Name   "

    Dim mHelpSessionProgrammeQry = "SELECT Convert(BIT,0) As [Select], Vs.Code , VS.SessionProgramme Name " & _
                            " FROM ViewSch_SessionProgramme VS " & _
                            " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " "

    Dim mHelpSessionProgrammeStreamQry = "SELECT Convert(BIT,0) As [Select], Vs.Code , VS.SessionProgrammeStream Name " & _
                        " FROM ViewSch_SessionProgrammeStream VS " & _
                        " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " "

    Dim mHelpEnquiryNo = "  SELECT Convert(BIT,0) As [Select],H.DocId AS Code, " & _
                        " isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS Name , " & _
                        " SG.DispName AS Employee , C.CityName AS City,  H.Mobile, H.Email, " & _
                        " " & AgL.V_No_Field("H.DocId") & " AS [Enquiry No], " & _
                        " H.V_Date AS [Enquiry DATE] " & _
                        " FROM Enquiry_Enquiry H   " & _
                        " LEFT JOIN SubGroup SG ON SG.SubCode =H.Employee " & _
                        " LEFT JOIN City C ON C.CityCode=H.CityCode "
    Dim mHelpSessionQry$ = "Select Convert(BIT,0) As [Select], S.Code , S.ManualCode AS Session, S.Description AS [Session Name] FROM Sch_Session S Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpProgrammeQry$ = "Select Convert(BIT,0) As [Select],  Code, Description as Programme  FROM Sch_Programme V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpStreamQry$ = "Select Convert(BIT,0) As [Select],  Code, ManualCode AS Stream, Description AS [Stream Name]  FROM Sch_Stream V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "

    Dim mHelpReferenceNoQry$ = " SELECT Distinct Convert(BIT,0) As [Select],R.ReferenceNo AS Code,R.ReferenceNo  FROM Enquiry_Enquiry R WHERE R.ReferenceNo IS NOT NULL "

    Dim mHelpItemQry$ = "Select Convert(BIT,0) As [Select], Code, Description As [Item Name] From store_Item Where  Store_Item.MasterType = '" & ClsMain.ItemType.Prospectus & "'"

    Dim mHelpPartyQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Party Name] " & _
                          " From ViewSubGroup Sg " & _
                          " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                          " And (Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenSundryDebtors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryDebtors) & " Or " & _
                          "       Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryCreditors) & "Or " & _
                          "       Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenCashInHand & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeCashInHand) & ") "

    Dim mHelpSupplierPartyQry$ = "Select Convert(BIT,0) As [Select], Sg.SubCode As Code, " & _
                           " Sg.DispName AS [Party Name], Sg.ManualCode As [Party Code], City.CityName As City  " & _
                           " From SubGroup Sg With (NoLock) " & _
                           " LEFT JOIN AcGroup Ag  With (NoLock) ON Ag.GroupCode = Sg.GroupCode " & _
                           " Left Join City With (NoLock)  On Sg.CityCode = City.CityCode " & _
                           " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                           " And Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenCashInHand & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeCashInHand) & " " & _
                           " UNION ALL " & _
                           " Select Convert(BIT,0) As [Select], Sg.SubCode As Code, " & _
                           " Sg.DispName AS [Party Name], Sg.ManualCode As [Party Code], City.CityName As City  " & _
                           " From Party P With (NoLock) " & _
                           " Left Join SubGroup Sg With (NoLock) On P.SubCode = Sg.SubCode " & _
                           " LEFT JOIN AcGroup Ag  With (NoLock) ON Ag.GroupCode = Sg.GroupCode " & _
                           " Left Join City With (NoLock)  On Sg.CityCode = City.CityCode " & _
                           " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "

    Dim mHelpGodownQry$ = "SELECT Convert(BIT,0) As [Select], Godown.Code,Godown.Description  FROM Store_Godown Godown With (NoLock)  "


    Dim mHelpSaleNoQry$ = "Select Convert(BIT,0) As [Select], S.DocID as Code,S.V_No as VrNo, S.V_Date As [Date],S.PartyName as Student,S.ReferenceNo From Store_Sale S Where  S.V_Type = '" & ClsMain.Temp_NCat.ProspectusSale & "'"


    Dim mHelpVType_ProspectusSale$ = "SELECT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.Description AS [Voucher Type] FROM Voucher_Type Vt WHERE Vt.NCat = '" & ClsMain.Temp_NCat.ProspectusSale & "' "

    Dim mHelpVType_ProspectusPurchase$ = "SELECT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.Description AS [Voucher Type] FROM Voucher_Type Vt WHERE Vt.NCat = '" & ClsMain.Temp_NCat.ProspectusPurchase & "' "


#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName

                Case EnquiryReport
                    StrArr1 = New String() {"All", "New", "Followup", "Closed"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Enquiry Status", StrArr1)

                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpEnquiryModeQry, "Enquiry Mode")
                    ObjRFG.CreateHelpGrid(mHelpEmployeeQry, "Enquiry By")
                    'ObjRFG.CreateHelpGrid(mHelpSessionProgrammeQry, "Session Programme")
                    'ObjRFG.CreateHelpGrid(mHelpSessionProgrammeStreamQry, "Session Programme Stream")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpProgrammeQry$, "Programme")
                    ObjRFG.CreateHelpGrid(mHelpStreamQry$, "Stream")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpEnquiryNo, "Enquiry No.")
                    ObjRFG.CreateHelpGrid(mHelpReferenceNoQry$, "Reference No.")

                Case EnquiryFollowupReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpEnquiryModeQry, "Followup Mode")
                    ObjRFG.CreateHelpGrid(mHelpEmployeeQry, "Followup By")
                    'ObjRFG.CreateHelpGrid(mHelpSessionProgrammeQry, "Session Programme")
                    'ObjRFG.CreateHelpGrid(mHelpSessionProgrammeStreamQry, "Session Programme Stream")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpProgrammeQry$, "Programme")
                    ObjRFG.CreateHelpGrid(mHelpStreamQry$, "Stream")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpEnquiryNo, "Enquiry No.")
                    ObjRFG.CreateHelpGrid(mHelpReferenceNoQry$, "Reference No.")

                Case EnquiryCloseRegister
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpEnquiryNo, "Enquiry No.")
                    ObjRFG.CreateHelpGrid(mHelpReferenceNoQry$, "Reference No.")
                    ObjRFG.CreateHelpGrid(mHelpEmployeeQry, "Enquiry By")
                    ObjRFG.CreateHelpGrid(mHelpCloseQry, "Close By")

                Case ProspectusPurchaseRegister
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpPartyQry$, "Supplier Name")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item Name")
                    ObjRFG.CreateHelpGrid(mHelpVType_ProspectusPurchase$, "Vr. Type")

                Case ProspectusSaleRegister
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpProgrammeQry$, "Programme")
                    ObjRFG.CreateHelpGrid(mHelpSaleNoQry, "Sale No.")
                    ObjRFG.CreateHelpGrid(mHelpVType_ProspectusSale, "Vr. Type")


                Case ProspectusStockRegister
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSupplierPartyQry, "Party Name")
                    ObjRFG.CreateHelpGrid(mHelpGodownQry, "Godown Name")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpProgrammeQry$, "Programme")

            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName
            Case EnquiryReport
                Call ProcEnquiryReport()

            Case EnquiryFollowupReport
                Call ProcEnquiryFollowupReport()

            Case EnquiryCloseRegister
                Call ProcEnquiryCloseRegister()

            Case ProspectusPurchaseRegister
                Call ProcProspectusPurchaseRegister()

            Case ProspectusSaleRegister
                Call ProcProspectusSaleRegister()

            Case ProspectusStockRegister
                Call ProcProspectusStockRegister()

        End Select
    End Sub
#Region "Prospectus Purchase Register"
    Private Sub ProcProspectusPurchaseRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            'If AgL.RequiredField(Cmbo1) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "


            mCondStr = mCondStr & " And H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.AcCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 3)

            mCondStr = mCondStr & " And Vt.NCat in (" & AgL.Chk_Text(ClsMain.Temp_NCat.ProspectusPurchase) & ")"

            mQry = " SELECT H.DocId,H. V_Type,H. V_Prefix,H. V_No,H. V_Date,H. PartyBillNo,H. PartyBillDate,H. Amount,H.Addition,H.Deduction,H.NetAmount,H.Addition_H,H.Deduction_H,H.InvoiceAmount,H. Remark,H. ReferenceNo,H. NetSubTotal,H. RoundOff,H. TotalQty, " & _
                    " L. ItemDescription,L. Unit,L. BatchNo,L. Godown,L. Qty,L. Rate,L. Amount as LineAmount,L. Addition as LineAddition,L. Deduction as LineDeduction ,L. NetAmount as LineNetAmount,L. Addition_H,L. Deduction_H,L. LandedAmount,L. Remark,L. Prefix,L. Suffix,L. StartSrNo,L. EndSrNo, " & _
                    " SM.Name AS SiteName,I.Description AS ItemName,DM.Div_Name AS DivisionName,G.Description AS Godown,   " & _
                    " Sg.Name AS Supplier,Sg.Add1, Sg.Add2, Sg.Add3, Sg.PIN, City.CityName, Sg.Phone, Sg.Mobile,SF.*,SL.* " & _
                    " FROM dbo.Store_Purchase H " & _
                    " LEFT JOIN Store_PurchaseDetail L WITH (Nolock) ON L.DocId=H.DocId " & _
                    " LEFT JOIN SiteMast SM WITH (Nolock) ON SM.Code=H.Site_Code   " & _
                    " LEFT JOIN division DM WITH (Nolock) ON DM.Div_Code=H.Div_Code   " & _
                    " LEFT JOIN Store_Item I WITH (Nolock) ON I.Code=L.Item " & _
                    " LEFT JOIN Voucher_Type Vt WITH (Nolock) ON Vt.V_Type=H.V_Type " & _
                    " LEFT JOIN Store_Godown G WITH (NoLock) ON L.Godown=G.Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Accode " & _
                    " LEFT JOIN City WITH (NoLock) ON Sg.CityCode = City.CityCode " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.ProspectusPurchase) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.ProspectusPurchase) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr "



            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                RepName = "Enquiry_ProspectusPurchaseRegisterSummary" : RepTitle = "Prospectus Purchase Register Summary"
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                RepName = "Enquiry_ProspectusPurchaseRegister" : RepTitle = "Prospectus Purchase Register"
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region


#Region "Enquiry Report"
    Private Sub ProcEnquiryReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "

            mCondStr = " Where 1= 1 "

            If ObjRFG.ParameterCmbo1_Value = "New" Then
                mCondStr = mCondStr & " AND H.Status = '" & ClsMain.EnquiryStatus.NewEnquiry & "'  "
            ElseIf ObjRFG.ParameterCmbo1_Value = "Followup" Then
                mCondStr = mCondStr & " AND H.Status = '" & ClsMain.EnquiryStatus.FollowUp & " ' "
            ElseIf ObjRFG.ParameterCmbo1_Value = "Closed" Then
                mCondStr = mCondStr & " AND H.Status = '" & ClsMain.EnquiryStatus.Closed & "'  "
            End If

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName) Or AgL.PubIsUserAdmin) Then
                mCondStr = mCondStr & " AND H.PreparedBy ='" & AgL.PubUserName & "' "
            End If

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.EnquiryMode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Employee", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Session", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Programme", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Stream", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Category", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.DocId", 7)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.ReferenceNo", 8)

            mQry = " SELECT H.DocId," & AgL.V_No_Field("H.DocId") & " AS VoucherNo,H.Site_Code,H.V_Date ,H.EnquiryMode, SG.DispName AS EnquiryByName, " & _
                        " VP.SessionProgramme,VPS.SessionProgrammeStream , " & _
                        " isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS Name, " & _
                        " isnull(H.Add1,'') +' '+ isnull(H.Add2,'') AS Address, " & _
                        " C.CityName AS City, H.Mobile, H.EMail,H.Sex,H.DOB,SC.Description AS CategoryDesc, " & _
                        " SR.Description AS ReligionDesc,H.Phone, " & _
                        " H.FatherName,H.MotherName ,H.FatherIncome ,H.MotherIncome, " & _
                        " SOF.Description AS FatherOccupationDesc,SOM.Description AS MotherOccupationDesc, " & _
                        " V1.FollowupDocId, SM.Name AS SiteName,H.Status  " & _
                        " FROM Enquiry_Enquiry H " & _
                        " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee  " & _
                        " LEFT JOIN ViewSch_SessionProgramme VP ON VP.Code=H.SessionProgramme " & _
                        " LEFT JOIN ViewSch_SessionProgrammeStream VPS ON VPS.Code=H.SessionProgrammeStream " & _
                        " LEFT JOIN City C ON C.CityCode=H.CityCode " & _
                        " LEFT JOIN Sch_Category SC ON SC.Code=H.Category " & _
                        " LEFT JOIN Sch_Religion SR ON SR.Code=H.Religion  " & _
                        " LEFT JOIN Sch_Occupation SOF ON SOF.Code=H.FatherOccupation  " & _
                        " LEFT JOIN Sch_Occupation SOM ON SOM.Code=H.MotherOccupation  " & _
                        " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code " & _
                        " LEFT JOIN " & _
                        " ( " & _
                        " SELECT  Min(F.DocId) AS FollowupDocId,F.EnquiryDocId   " & _
                        " FROM Enquiry_FollowUp F " & _
                        " WHERE F.EnquiryDocId IS NOT NULL  " & _
                        " GROUP BY F.EnquiryDocId " & _
                        " ) V1 ON V1.EnquiryDocId=H.DocId " & _
                        " " & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Enq_EnquiryReport" : RepTitle = "Enquiry Report"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Enquiry Followup Report"
    Private Sub ProcEnquiryFollowupReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "

            mCondStr = " Where 1= 1 "

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName) Or AgL.PubIsUserAdmin) Then
                mCondStr = mCondStr & " AND H.PreparedBy ='" & AgL.PubUserName & "' "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.FollowupMode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Employee", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("E.Session", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("E.Programme", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("E.Stream", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("E.Category", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.EnquiryDocId", 7)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("E.ReferenceNo", 8)

            mQry = " SELECT  H.DocId," & AgL.V_No_Field("H.DocId") & " AS VoucherNo, H.Site_Code, H.V_Date, H.Employee, H.EnquiryDocId," & AgL.V_No_Field("H.EnquiryDocId") & " AS EnquiryNo, " & _
                        " H.FollowupMode, H.PersonMet, H.Remark AS FollowerRemark, H.NextFollowUpDate, H.IsClosed, " & _
                        " H1.Remark FollowupDetail,SM.Name AS SiteName,SG.DispName AS EmployeeName,'" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, " & _
                        " isnull(E.FirstName,'') +' '+ isnull(E.MiddleName,'') +' '+ isnull(E.LastName,'') AS Name , " & _
                        " isnull(E.Add1,'') +' '+ isnull(E.Add2,'') +' '+ isnull(E.Add3,'') AS Address , " & _
                        " C.CityName ,E.Mobile,E.Phone,E.EMail,E.FatherName,E.MotherName " & _
                        " FROM Enquiry_FollowUp H " & _
                        " LEFT JOIN Enquiry_FollowUp1 H1 ON H.DocId=H1.DocId  " & _
                        " LEFT JOIN SiteMast SM ON SM.Code =H.Site_Code  " & _
                        " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee  " & _
                        " LEFT JOIN Enquiry_Enquiry E ON E.DocId=H.EnquiryDocId " & _
                        " LEFT JOIN City C ON C.CityCode =E.CityCode " & _
                        " " & mCondStr & " "


            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Enq_FollowupReport" : RepTitle = "Enquiry Followup Report"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Enquiry Close Register"
    Private Sub ProcEnquiryCloseRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "

            mCondStr = " Where 1= 1 "

            mCondStr = mCondStr & " AND H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName) Or AgL.PubIsUserAdmin) Then
                mCondStr = mCondStr & " AND H.PreparedBy ='" & AgL.PubUserName & "' "
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.DocId", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.ReferenceNo", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Employee", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("E.Employee", 4)

            mCondStr = mCondStr & " AND H.Status = '" & ClsMain.EnquiryStatus.Closed & "'  "

            mQry = " SELECT H.DocId,H.Div_Code,H.Site_Code,H.V_Date,H.V_Type,H.V_Prefix," & AgL.V_No_Field("H.DocId") & " AS VoucherNo,H.EnquiryMode, " & _
                        " SG.DispName AS EnquiryByName, SG1.DispName AS CloseByName,isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS Name, " & _
                        " isnull(H.Add1,'') +' '+ isnull(H.Add2,'') AS Address, C.CityName AS City,H.PIN,H.Phone,H.Mobile, " & _
                        " H.EMail,H.Sex,H.DOB,SR.Description AS ReligionDesc,SM.Name AS SiteName, " & _
                        " SC.Description AS CategoryDesc,H.FatherName,H.MotherName,H. Status,H. IsClosed,H. Remark,H. PreparedBy, " & _
                        " H.Session,H.Programme,H.Stream,H.Nationality,H.ReferenceNo,sreg.ManualRegNo," & AgL.V_No_Field("SReg.DocId") & " AS RegNo, " & _
                        " sd.V_No AS AdmNo,Sem.StreamYearSemesterDesc AS AdmissionSem " & _
                        " FROM dbo.Enquiry_Enquiry H WITH (NoLock) " & _
                        " LEFT JOIN SubGroup SG WITH (NoLock) ON SG.SubCode=H.Employee " & _
                        " LEFT JOIN City C WITH (NoLock) ON C.CityCode=H.CityCode  " & _
                        " LEFT JOIN Sch_Category SC WITH (NoLock) ON SC.Code=H.Category  " & _
                        " LEFT JOIN Sch_Religion SR WITH (NoLock) ON SR.Code=H.Religion  " & _
                        " LEFT JOIN SiteMast SM WITH (NoLock) ON SM.Code=H.Site_Code  " & _
                        " LEFT JOIN Enquiry_FollowUp E WITH (NoLock) ON E.EnquiryDocId=H.DocId AND E.IsClosed=H.IsClosed " & _
                        " LEFT JOIN SubGroup SG1 WITH (NoLock) ON SG1.SubCode=E.Employee " & _
                        " LEFT JOIN Sch_Admission SD WITH (NoLock) ON SD.EnquiryDocId = H.DocId  " & _
                        " LEFT JOIN Sch_Registration SReg WITH (NoLock) ON SReg.EnquiryDocId = H.DocId " & _
                        " LEFT JOIN viewSch_StreamYearSemester Sem WITH (NoLock) ON Sem.code = sd.AdmissionSemester " & _
                        " " & mCondStr & " "


            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Enq_CloseRegister" : RepTitle = "Enquiry Close Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Prospectus Sale Register"
    Private Sub ProcProspectusSaleRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            'If AgL.RequiredField(Cmbo1) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "


            mCondStr = mCondStr & " And H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Item", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Programme", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Session", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.DocId", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 5)


            mCondStr = mCondStr & " And Vt.NCat in (" & AgL.Chk_Text(ClsMain.Temp_NCat.ProspectusSale) & ")"

            mQry = " SELECT H.DocId,H. Div_Code,H. Site_Code,H. V_Type,H. V_Prefix,H. V_No,H. V_Date,H. Amount,H. Addition,H. Deduction,H. NetAmount,H. Addition_H,H. Deduction_H,H. InvoiceAmount,H. Remark,H. ReferenceNo,H. DocumentNo,H. DocumentDate,H. NetSubTotal,H. RoundOff,H. TotalQty,H. PartyName,H. PartyAdd1,H. PartyAdd2,H. PartyAdd3,H. PartyCityCode,H. PartyPhone,H. PartyMobile, " & _
                    " L. ItemDescription,L. Unit,L. Godown,L. Qty,L. Rate,L. Amount AS LineAmount,L. Addition AS LineAddition,L. Deduction AS LineDeduction,L. NetAmount AS LineNetAmount,L. Addition_H,L. Deduction_H,L. LandedAmount,L. Remark,L. ProspectusNo, " & _
                    " SM.Name AS SiteName,I.Description AS ItemName,DM.Div_Name AS DivisionName,G.Description AS Godown, PM.ManualCode AS Programme,S.ManualCode AS Session , City.CityName " & _
                    " FROM dbo.Store_Sale H " & _
                    " LEFT JOIN Store_SaleDetail L WITH (NoLock) ON H.DocId=L.DocId " & _
                    " LEFT JOIN SiteMast SM WITH (Nolock) ON SM.Code=H.Site_Code   " & _
                    " LEFT JOIN division DM WITH (Nolock) ON DM.Div_Code=H.Div_Code   " & _
                    " LEFT JOIN Store_Item I WITH (Nolock) ON I.Code=L.Item " & _
                    " LEFT JOIN Voucher_Type Vt WITH (Nolock) ON Vt.V_Type=H.V_Type " & _
                    " LEFT JOIN City WITH (NoLock) ON H.PartyCityCode = City.CityCode " & _
                    " LEFT JOIN Store_Godown G WITH (NoLock) ON L.Godown=G.Code  " & _
                    " LEFT JOIN Sch_Programme PM WITH (NoLock) ON L.Programme=PM.Code " & _
                    " LEFT JOIN Sch_Session S WITH (NoLock) ON L.Session=S.Code "

            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                RepName = "Enquiry_ProspectusSaleRegisterSummary" : RepTitle = "Prospectus Sale Register Summary"
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                RepName = "Enquiry_ProspectusSaleRegister" : RepTitle = "Prospectus Sale Register"
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Prospectus Stock Register"
    Private Sub ProcProspectusStockRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = "", mCondStr1$ = "", bStrOpeningStockQry$ = "", bStrCurrentStockQry$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            'If AgL.RequiredField(Cmbo1) Then Exit Sub

            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "


          
            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.AcCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Godown", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Item", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Session", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Programme", 5)
          
            mCondStr = mCondStr & " And H.V_Type in (" & AgL.Chk_Text(ClsMain.Temp_NCat.ProspectusPurchase) & "," & AgL.Chk_Text(ClsMain.Temp_NCat.ProspectusSale) & "," & AgL.Chk_Text(ClsMain.Temp_NCat.ProspectusAdjustment) & ")"

            mCondStr1 = mCondStr
            mCondStr1 += " And H.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & "  "
            mCondStr += " And H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

          
            bStrOpeningStockQry = " SELECT 'Opening' As DocId," & _
                                     " 0 As Sr, " & _
                                     " Null As VoucherNo," & _
                                     " H.Div_Code," & _
                                     " H.Site_Code," & _
                                     " 'Opening' as V_Type," & _
                                     " 'Opening' As V_Prefix," & _
                                     " -1 As V_No, " & _
                                     " " & AgL.Chk_Text(ObjRFG.ParameterDate1_Value) & " As V_Date," & _
                                     " H.Item," & _
                                     " H.BatchNo, " & _
                                     " Case When Sum(IsNull(H.Qty_Rec,0) - IsNull(H.Qty_Iss,0)) >= 0 Then 'Receive'  Else 'Issue' End  As IssueReceive, " & _
                                     " 0 As DocQty, " & _
                                     " Case When Sum(IsNull(H.Qty_Rec,0) - IsNull(H.Qty_Iss,0)) >= 0 Then  Sum(IsNull(H.Qty_Rec,0) - IsNull(H.Qty_Iss,0)) Else 0 End As Qty_Rec, " & _
                                     " Case When Sum(IsNull(H.Qty_Rec,0) - IsNull(H.Qty_Iss,0)) < 0 Then  Sum(IsNull(H.Qty_Rec,0) - IsNull(H.Qty_Iss,0)) Else 0 End As Qty_Iss, " & _
                                     " 0 As Rate," & _
                                     " 0 As Amount," & _
                                     " Null As Remark, " & _
                                     " H.Godown, " & _
                                     " H.ItemDescription," & _
                                     " Null as ReferenceNo," & _
                                     " Null AS PartyCode," & _
                                     " Max(H.Unit) as Unit," & _
                                     " Null As Uid," & _
                                     " Null As ReferenceDocId," & _
                                     " Null As ReferenceUId, " & _
                                     " Null as SalesTaxGroupParty," & _
                                     " Null as SalesTaxGroupItem," & _
                                     " Null AS VoucherDescription," & _
                                     " Null AS VoucherType," & _
                                     " max(SITE.Name) AS Site_Name, " & _
                                     " max(Site.ManualCode) AS SiteManualCode," & _
                                     " Max(Sg.Name) AS PartyName, " & _
                                     " Null AS PartyDispName, " & _
                                     " Null AS PartyManualCode, " & _
                                     " Null as Add1, " & _
                                     " Null as Add2, " & _
                                     " Null as Add3," & _
                                     " Null as PIN, " & _
                                     " Null as CityName," & _
                                     " Null as Phone,  " & _
                                     " Null as Mobile," & _
                                     " Null as FAX,  " & _
                                     " Null as LSTNo," & _
                                     " Null as CSTNo," & _
                                     " Null as TINNo," & _
                                     " Null as PAN," & _
                                     " Null as EMail, " & _
                                     " max(Item.Description) AS ItemName," & _
                                     " max(Item.ManualCode) AS ItemManualCode," & _
                                     " max(Ic.Description) AS ItemCategory, " & _
                                     " max(Ig.Description) AS ItemGroup," & _
                                     " max(Godown.Description) as GodownName, " & _
                                     " max(PM.ManualCode) AS Programme, " & _
                                     " max(S.ManualCode) AS Session " & _
                                     " FROM dbo.Store_Stock H WITH (NoLock)" & _
                                     " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type " & _
                                     " LEFT JOIN SiteMast Site ON Site.Code = H.Site_Code  " & _
                                     " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.AcCode" & _
                                     " LEFT JOIN City WITH (NoLock) ON Sg.CityCode = City.CityCode  " & _
                                     " LEFT JOIN Store_Item AS Item  WITH (NoLock) ON Item.Code = H.Item " & _
                                     " LEFT JOIN Store_ItemCategory Ic WITH (NoLock) ON Ic.Code = Item.ItemCategory" & _
                                     " LEFT JOIN Store_ItemGroup Ig WITH (NoLock) ON Ig.Code = Item.ItemGroup  " & _
                                     " LEFT JOIN Sch_Programme PM WITH (NoLock) ON H.Programme=PM.Code " & _
                                     " LEFT JOIN Sch_Session S WITH (NoLock) ON H.Session=S.Code " & _
                                     " LEFT JOIN Store_Godown Godown WITH (NoLock) ON Godown.Code = H.Godown   Where 1=1 " & mCondStr1 & _
                                     " Group By H.Div_Code, H.Site_Code, H.Item, H.BatchNo, H.ItemDescription, H.Godown "

            bStrCurrentStockQry = " SELECT H.DocId, H.Sr, " & AgL.V_No_Field("H.DocId") & " As VoucherNo,H.Div_Code, H.Site_Code, H.V_Type, H.V_Prefix, H.V_No, H.V_Date," & _
                                 " H.Item, H.BatchNo, H.IssueReceive, H.DocQty, H.Qty_Rec, H.Qty_Iss, " & _
                                 " H.Rate, H.Amount, H.Remark, H.Godown, " & _
                                 " H.ItemDescription, H.ReferenceNo, H.AcCode AS PartyCode, H.Unit," & _
                                 " Convert(varchar(36),H.UID) As Uid, H.ReferenceDocId, convert(varchar(36),H.ReferenceUId) as ReferenceUId, " & _
                                 " H.SalesTaxGroupParty, H.SalesTaxGroupItem," & _
                                 " Vt.Description AS VoucherDescription," & _
                                 " Vt.Description AS VoucherType, Site.Name AS Site_Name, Site.ManualCode AS SiteManualCode," & _
                                 " Sg.Name AS PartyName, Sg.DispName AS PartyDispName, Sg.ManualCode AS PartyManualCode, " & _
                                 " Sg.Add1, Sg.Add2, Sg.Add3, Sg.PIN, City.CityName, Sg.Phone, Sg.Mobile, Sg.FAX,  " & _
                                 " Sg.LSTNo, Sg.CSTNo, Sg.TINNo, Sg.PAN, Sg.EMail, " & _
                                 " Item.Description AS ItemName, Item.ManualCode AS ItemManualCode," & _
                                 " Ic.Description AS ItemCategory, Ig.Description AS ItemGroup,Godown.Description as GodownName, PM.ManualCode AS Programme,S.ManualCode AS Session " & _
                                 " FROM dbo.Store_Stock H WITH (NoLock)" & _
                                 " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type " & _
                                 " LEFT JOIN SiteMast Site ON Site.Code = H.Site_Code  " & _
                                 " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.AcCode" & _
                                 " LEFT JOIN City WITH (NoLock) ON Sg.CityCode = City.CityCode  " & _
                                 " LEFT JOIN Store_Item AS Item  WITH (NoLock) ON Item.Code = H.Item " & _
                                 " LEFT JOIN Store_ItemCategory Ic WITH (NoLock) ON Ic.Code = Item.ItemCategory" & _
                                 " LEFT JOIN Store_ItemGroup Ig WITH (NoLock) ON Ig.Code = Item.ItemGroup  " & _
                                 " LEFT JOIN Sch_Programme PM WITH (NoLock) ON H.Programme=PM.Code " & _
                                 " LEFT JOIN Sch_Session S WITH (NoLock) ON H.Session=S.Code " & _
                                 " LEFT JOIN Store_Godown Godown WITH (NoLock) ON Godown.Code = H.Godown  "


            bStrCurrentStockQry = bStrCurrentStockQry & " Where 1=1  " & mCondStr

            mQry = bStrOpeningStockQry + " UNION ALL " + bStrCurrentStockQry


            DsRep = AgL.FillData(mQry, AgL.GCn)
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                RepName = "Enquiry_ProspectusStockRegisterSummary" : RepTitle = "Prospectus Stock Register Summary"
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                RepName = "Enquiry_ProspectusStockRegister" : RepTitle = "Prospectus Stock Register"
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region


    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub

End Class
