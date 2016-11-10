Public Class ClsReportProcedures
    Public ObjClsMain As New ClsMain(AgL)

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
    Private Const DriverRegister As String = "DriverRegister"
    Private Const PurchaseRegister As String = "PurchaseRegister"
    Private Const PurchaseReturnRegister As String = "PurchaseReturnRegister"
    Private Const StockRegister As String = "StockRegister"
    Private Const MessMenu As String = "MessMenu"
    Private Const MessAttendanceRegister As String = "MessAttendanceRegister"

#End Region

#Region "Queries Definition"
    Dim mHelpCityQry$ = "Select Convert(BIT,0) As [Select],CityCode, CityName From City "
    Dim mHelpStateQry$ = "Select Convert(BIT,0) As [Select],State_Code, State_Desc From State "
    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpEntryPointQry$ = " Select Distinct Convert(BIT,0) As [Select], User_Permission.MnuText AS code , User_Permission.MnuText As [Entry Point] From User_Permission  "
    Dim mHelpBankQry$ = "Select Convert(BIT,0) As [Select],Bank_Code Code, Bank_Name As [Bank Name] From Bank "
    Dim mHelpBankBranchQry$ = "Select Convert(BIT,0) As [Select],BankBranch_Code Code, BankBranch_Name As [Bank Branch Name] From BankBranch "
    Dim mHelpSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "
    Dim mHelpCategaryQry$ = "Select Convert(BIT,0) As [Select],Code, ManualCode As [Category Short Name], Description As Category From Sch_Category "
    Dim mHelpEmployeeQry$ = "Select Convert(BIT,0) As [Select],  v.subcode AS Code,Sg.DispName AS Name FROM Pay_Employee V LEFT JOIN SubGroup Sg ON v.SubCode=Sg.SubCode Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  AND IsNull(v.IsTeachingStaff,0) = 0 "

    Dim mHelpCustomerQry$ = "Select Convert(BIT,0) As [Select], Sg.SubCode As Code, " & _
                            " Sg.DispName AS [Party Name], Sg.ManualCode As [Party Code], City.CityName As City  " & _
                            " From SubGroup Sg With (NoLock) " & _
                            " LEFT JOIN AcGroup Ag  With (NoLock) ON Ag.GroupCode = Sg.GroupCode " & _
                            " Left Join City With (NoLock)  On Sg.CityCode = City.CityCode " & _
                            " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                            " And ( " & _
                            " (Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenCashInHand & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeCashInHand) & ") " & _
                            " Or (Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryDebtors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryDebtors) & ") " & _
                            " ) "

    Dim mHelpSupplierQry$ = "Select Convert(BIT,0) As [Select], Sg.SubCode As Code, " & _
                            " Sg.DispName AS [Party Name], Sg.ManualCode As [Party Code], City.CityName As City  " & _
                            " From SubGroup Sg With (NoLock) " & _
                            " LEFT JOIN AcGroup Ag  With (NoLock) ON Ag.GroupCode = Sg.GroupCode " & _
                            " Left Join City With (NoLock)  On Sg.CityCode = City.CityCode " & _
                            " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                            " And ( " & _
                            " (Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenCashInHand & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeCashInHand) & ") " & _
                            " Or (Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryCreditors) & ") " & _
                            " ) "

    Dim mHelpAllPartyQry$ = "Select Convert(BIT,0) As [Select], Sg.SubCode As Code, " & _
                            " Sg.DispName AS [Party Name], Sg.ManualCode As [Party Code], City.CityName As City  " & _
                            " From SubGroup Sg With (NoLock) " & _
                            " LEFT JOIN AcGroup Ag  With (NoLock) ON Ag.GroupCode = Sg.GroupCode " & _
                            " Left Join City With (NoLock)  On Sg.CityCode = City.CityCode " & _
                            " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                            " And ( " & _
                            " (Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenCashInHand & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeCashInHand) & ") " & _
                            " Or (Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryDebtors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryDebtors) & ") " & _
                            " Or (Left(Ag.MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryCreditors) & ") " & _
                            " ) "

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


    Dim mHelpItemQry$ = "SELECT Convert(BIT,0) As [Select], I.Code, I.Description AS [Item Name], I.Unit, " & _
                        " C.Description AS [Item Category], G.Description AS [Item Group], " & _
                        " I.Nature " & _
                        " FROM Store_Item I  With (NoLock) " & _
                        " LEFT JOIN Store_ItemGroup G  With (NoLock) ON G.Code = I.ItemGroup  " & _
                        " LEFT JOIN Store_ItemCategory C With (NoLock)  ON C.Code = I.ItemCategory " & _
                        " Where IsNull(I.MasterType,'') = '" & ClsMain.ItemType.Mess & "' "

    Dim mHelpItemCategoryQry$ = "SELECT Convert(BIT,0) As [Select], C.Code, C.Description AS [Item Category] " & _
                                " From Store_ItemCategory C With (NoLock) " & _
                                " Where IsNull(C.MasterType,'') = '" & ClsMain.ItemType.Mess & "' "

    Dim mHelpItemGroupQry$ = "SELECT Convert(BIT,0) As [Select], C.Code, C.Description AS [Item Group] " & _
                                " From Store_ItemGroup C With (NoLock) " & _
                                " Where IsNull(C.MasterType,'') = '" & ClsMain.ItemType.Mess & "' "

    Dim mHelpVType_MessPurchaseQry$ = "SELECT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.Description AS [Voucher Type] FROM Voucher_Type Vt WHERE Vt.NCat = '" & ClsMain.Temp_NCat.MessPurchase & "' "
    Dim mHelpVType_MessPurchaseReturnQry$ = "SELECT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.Description AS [Voucher Type] FROM Voucher_Type Vt WHERE Vt.NCat = '" & ClsMain.Temp_NCat.MessPurchaseReturn & "' "

    'Code by Rohit
    Dim mHelpGodownQry$ = "SELECT Convert(BIT,0) As [Select], Godown.Code,Godown.Description  FROM Store_Godown Godown With (NoLock)  "

    Dim mhelpItemTypeQry$ = "SELECT Convert(BIT,0) As [Select], '" & ClsMain.ItemNature.RawMaterial & "' as Code, '" & ClsMain.ItemNature.RawMaterial & "' as Name " & _
                    " Union All " & _
                    " Select Convert(BIT,0) As [Select],'" & ClsMain.ItemNature.SemiFinished & "' as Code, '" & ClsMain.ItemNature.SemiFinished & "' as Name " & _
                    " Union All " & _
                    " Select Convert(BIT,0) As [Select],'" & ClsMain.ItemNature.Finished & "' as Code, '" & ClsMain.ItemNature.Finished & "' as Name "

    Dim mHelpShiftQry$ = "Select Convert(BIT,0) As [Select], Code, Code As [Shift] From Mess_Shift  "

    Dim mHelpWeekdayQry$ = "Select Convert(BIT,0) As [Select], Code, Description As [Weekday] From Sch_WeekDay "

    Dim mHelpVType_MessAttendance$ = "SELECT Convert(BIT,0) As [Select], Vt.V_Type AS Code, Vt.Description AS [Voucher Type] FROM Voucher_Type Vt WHERE Vt.NCat = '" & ClsMain.Temp_NCat.MessMemberAttendance & "' "


    Dim mHelpMessMemberQry$ = "SELECT Convert(BIT,0) As [Select],H.SubCode AS Code, Sg.Name, Sg.ManualCode AS [Member Code] " & _
                              " FROM Mess_Member H With (NoLock)  " & _
                              " LEFT JOIN SubGroup Sg With (NoLock) ON Sg.SubCode = H.SubCode " & _
                              " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "


    'End Code
#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = "", mQry1$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                Case DriverRegister
                    StrArr1 = New String() {"No", "Yes", "All"}
                    Call ObjRFG.Ini_Grp(, , , , "Left Driver", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpEmployeeQry$, "Driver")


                Case PurchaseRegister, PurchaseReturnRegister
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")

                    If mGRepFormName = PurchaseRegister Then
                        ObjRFG.CreateHelpGrid(mHelpVType_MessPurchaseQry, "Purchase Type")
                    ElseIf mGRepFormName = PurchaseReturnRegister Then
                        ObjRFG.CreateHelpGrid(mHelpVType_MessPurchaseReturnQry, "PurchaseReturn Type")
                    End If

                    If mGRepFormName = PurchaseRegister Or mGRepFormName = PurchaseReturnRegister Then
                        ObjRFG.CreateHelpGrid(mHelpSupplierPartyQry, "Party Name")
                    Else
                        ObjRFG.CreateHelpGrid(mHelpAllPartyQry, "Party Name")
                    End If
                    ObjRFG.CreateHelpGrid(mHelpItemCategoryQry, "Item Category")
                    ObjRFG.CreateHelpGrid(mHelpItemGroupQry, "Item Group")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item Name")


                Case StockRegister
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSupplierPartyQry, "Party Name")
                    ObjRFG.CreateHelpGrid(mHelpGodownQry, "Godown Name")
                    ObjRFG.CreateHelpGrid(mHelpItemCategoryQry, "Item Category")
                    ObjRFG.CreateHelpGrid(mHelpItemGroupQry, "Item Group")
                    ObjRFG.CreateHelpGrid(mHelpItemQry, "Item Name")
                    ObjRFG.CreateHelpGrid(mhelpItemTypeQry, "Item type")

                Case MessMenu
                    Call ObjRFG.Ini_Grp("Menu Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpWeekdayQry$, "WeekDay")
                    ObjRFG.CreateHelpGrid(mHelpShiftQry$, "Shift")

                Case MessAttendanceRegister
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpVType_MessAttendance, "Attendance Type")
                    ObjRFG.CreateHelpGrid(mHelpShiftQry$, "Shift")
                    ObjRFG.CreateHelpGrid(mHelpMessMemberQry, "Member")

            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName
            Case DriverRegister
                Call ProcDriverRegister()

            Case PurchaseRegister
                Call ProcPurchaseRegister(ClsMain.Temp_NCat.MessPurchase)

            Case PurchaseReturnRegister
                Call ProcPurchaseRegister(ClsMain.Temp_NCat.MessPurchaseReturn)

            Case StockRegister
                Call ProcStockRegister()

            Case MessMenu
                Call ProcMessMenu()

            Case MessAttendanceRegister
                Call ProcMessAttendanceRegister()

        End Select
    End Sub
#Region "Mess Attendance Register"
    Private Sub ProcMessAttendanceRegister()
        Try
            Dim mCondStr$ = "", mHelpListStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub


            mHelpListStr = " , '" & ObjRFG.GetHelpString(0) & "' As SelGrid1,  " & _
                            " 'Date From ' + '" & ObjRFG.ParameterDate1_Value & "' + ' To ' + '" & ObjRFG.ParameterDate2_Value & "' As ForPeriod "


            mCondStr = mCondStr & " And H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.V_Type", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Shift", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Member", 3)


            mQry = " SELECT H.DocId, H.Div_Code, H.Site_Code, H.V_Type, H.V_Prefix, H.V_No, H.V_Date, H.ReferenceNo,H.Shift,  " & _
                    " H.TotalMember, H.TotalPresent, H.TotalAbsent, H.Remark,L.IsPresent,SM.Name AS SiteName, " & _
                    " DM.Div_Name AS DivisionName,SG.Name AS Member,m.MemberType,CASE WHEN L.IsPresent<>0 THEN 'Yes' else 'NO' END AS Present " & _
                    " FROM Mess_Attendance H WITH (NoLock) " & _
                    " LEFT JOIN Mess_Attendance1 L WITH (NoLock) ON H.DocId=L.DocId  " & _
                    " LEFT JOIN Division DM WITH (NoLock) ON DM.Div_Code=H.Div_Code   " & _
                    " LEFT JOIN SiteMast SM WITH (NoLock) ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN Mess_Member M WITH (NoLock) ON M.SubCode=L.Member " & _
                    " LEFT JOIN SubGroup SG WITH (NoLock) ON SG.SubCode=L.Member    " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=H.V_Type   "




            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Mess_AttendanceRegister" : RepTitle = "Mess Attendance Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Driver Register"
    Private Sub ProcDriverRegister()
        Try
            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            Call ObjRFG.FillGridString()

            mCondStr = " Where PE.MasterType = '" & Academic_ProjLib.ClsMain.MasterType.Driver & "' "

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then
                mCondStr += " And Pe.DateOfResign Is Not Null "

            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "No") Then
                mCondStr += " And Pe.DateOfResign Is Null "
            End If

            If ObjRFG.GetWhereCondition("Sg.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Sg.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sg.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("PE.Category", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("PE.Employee", 2)

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName) Or AgL.PubIsUserAdmin) Then
                mCondStr = mCondStr & " AND H.PreparedBy ='" & AgL.PubUserName & "' "
            End If

            mQry = " SELECT PE.SubCode,PE.DateOfJoin,PE.Sex,PE.BloodGroup,PE.Religion,PE.Category, " & _
                   " C.Description as Category_Desc, Sg.Site_Code,sg.DispName as Name,sg.Name as DispName, " & _
                   " sg.Add1,sg.Add2,sg.Add3,sg.CityCode,city.CityName,sg.Phone,sg.Mobile,sg.EMail,sg.DOB, " & _
                   " sg.FatherName, Si.Name AS Site_Name,PE.DateOfJoin,PE.DateOfResign,PE.ResignRemark," & _
                   " PE.MotherName,PE.Shift,PE.AppointmentType,PE.SalaryMode,PE.PayScale,PE.WorkExperience  ," & _
                   " PE.BankAcNo,PE.BankName,PE.BankBranch,PE.IfscCode,State.state_desc ,SG.EMail,SG.PAN ,SG.FAX," & _
                   " PE.Designation, SG.PIN ,Sch_Religion.Description as EmpReligion ,PE.Bloodgroup FROM Pay_Employee PE " & _
                   " LEFT JOIN SubGroup SG ON SG.SubCode=PE.SubCode   " & _
                   " LEFT JOIN SiteMast Si ON Si.Code =Sg.Site_Code   " & _
                   " LEFT JOIN Sch_Category C ON C.Code=PE.Category   " & _
                   " LEFT JOIN City ON city.CityCode=sg.CityCode  " & _
                   " LEFT JOIN State on city.state_code=state.state_code " & _
                   " LEFT JOIN Sch_Religion on PE.Religion = Sch_Religion.Code " & _
                   " " & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Tp_DriverRegister" : RepTitle = "Driver Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Purchase Register"
    Private Sub ProcPurchaseRegister(ByVal StrNCat As String)
        Try
            Dim mCondStr$ = "", bCondStrSite$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub


            Call ObjRFG.FillGridString()

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                bCondStrSite = " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                bCondStrSite = ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If


            mQry = ObjClsMain.FunQueryPurchaseRegister(StrNCat, _
                                                    ObjRFG.ParameterDate1_Value, _
                                                    ObjRFG.ParameterDate2_Value, _
                                                    bCondStrSite, _
                                                    ObjRFG.GetWhereCondition("Vt.V_Type", 1), _
                                                    ObjRFG.GetWhereCondition("H.AcCode", 2), _
                                                    ObjRFG.GetWhereCondition("Item.ItemCategory", 3), _
                                                    ObjRFG.GetWhereCondition("Item.ItemGroup", 4), _
                                                    ObjRFG.GetWhereCondition("L.Item", 5) _
                                                    )
            DsRep = AgL.FillData(mQry, AgL.GCn)




            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                If mGRepFormName = PurchaseReturnRegister Then
                    RepName = "Canteen_PurchaseReturnSummary" : RepTitle = "Purchase Return Summary"
                Else
                    RepName = "Canteen_PurchaseSummary" : RepTitle = "Purchase Summary"
                End If
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                If mGRepFormName = PurchaseReturnRegister Then
                    RepName = "Canteen_PurchaseReturnRegister" : RepTitle = "Purchase Return Register"
                Else
                    RepName = "Canteen_PurchaseRegister" : RepTitle = "Purchase Register"
                End If
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Stock Register"
    Private Sub ProcStockRegister()
        Try
            Dim mCondStr$ = "", bCondStrSite$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            Call ObjRFG.FillGridString()

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                bCondStrSite = " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                bCondStrSite = ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If


            mQry = ObjClsMain.FunQueryStockRegister(ObjRFG.ParameterDate1_Value, _
                                                    ObjRFG.ParameterDate2_Value, _
                                                    bCondStrSite, _
                                                    ObjRFG.GetWhereCondition("H.AcCode", 1), _
                                                    ObjRFG.GetWhereCondition("H.Godown", 2), _
                                                    ObjRFG.GetWhereCondition("Item.ItemCategory", 3), _
                                                    ObjRFG.GetWhereCondition("Item.ItemGroup", 4), _
                                                    ObjRFG.GetWhereCondition("L.Item", 5), _
                                                    ObjRFG.GetWhereCondition("Item.Nature", 6) _
                                                    )
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                RepName = "Canteen_StockSummary" : RepTitle = "Stock Summary"
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                RepName = "Canteen_StockRegister" : RepTitle = "Stock  Register"
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Mess Menu"
    Private Sub ProcMessMenu()
        Try
            Dim mCondStr$ = " Where 1=1 "
            Dim bMenuQry$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub

            Call ObjRFG.FillGridString()

            mCondStr += " And Vt.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.MessMenu) & " "
            mCondStr += " And M.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " "

            If ObjRFG.GetWhereCondition("M.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.WeekDay", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.Shift", 2)

            mQry = " SELECT H.Site_Code, H.WeekDay, " & _
                        " Max(Sch_WeekDay.Description) as DayName, " & _
                        " Max(Sm.Name) AS Site_Name, Max(Sm.ManualCode) AS Site_ManualCode, L.Sr As Line_Serial, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN  " & AgL.Chk_Text(ClsMain.Shift.BreakFast) & "   THEN L.Item ELSE NULL END) AS BF_ItemCode, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.BreakFast) & " THEN L.ItemDescription ELSE NULL END) AS BF_ItemName, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.BreakFast) & " THEN L.Unit ELSE NULL END) AS BF_Unit, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.BreakFast) & " THEN L.Qty ELSE NULL END) AS BF_Qty, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.BreakFast) & " THEN L.Rate ELSE NULL END) AS BF_Rate, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.BreakFast) & " THEN L.Amount ELSE NULL END) AS BF_Amount, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.BreakFast) & " THEN L.Remark ELSE NULL END) AS BF_LineRemark, " & _
                        " " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Lunch) & " THEN L.Item ELSE NULL END) AS L_ItemCode, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Lunch) & " THEN L.ItemDescription ELSE NULL END) AS L_ItemName, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Lunch) & " THEN L.Unit ELSE NULL END) AS L_Unit, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Lunch) & " THEN L.Qty ELSE NULL END) AS L_Qty, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Lunch) & " THEN L.Rate ELSE NULL END) AS L_Rate, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Lunch) & " THEN L.Amount ELSE NULL END) AS L_Amount, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Lunch) & " THEN L.Remark ELSE NULL END) AS L_LineRemark, " & _
                        " " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Tiffin) & " THEN L.Item ELSE NULL END) AS T_ItemCode, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Tiffin) & " THEN L.ItemDescription ELSE NULL END) AS T_ItemName, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Tiffin) & " THEN L.Unit ELSE NULL END) AS T_Unit, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Tiffin) & " THEN L.Qty ELSE NULL END) AS T_Qty, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Tiffin) & " THEN L.Rate ELSE NULL END) AS T_Rate, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Tiffin) & " THEN L.Amount ELSE NULL END) AS T_Amount, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Tiffin) & " THEN L.Remark ELSE NULL END) AS T_LineRemark, " & _
                        " " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Dinner) & " THEN L.Item ELSE NULL END) AS D_ItemCode, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Dinner) & " THEN L.ItemDescription ELSE NULL END) AS D_ItemName, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Dinner) & " THEN L.Unit ELSE NULL END) AS D_Unit, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Dinner) & " THEN L.Qty ELSE NULL END) AS D_Qty, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Dinner) & " THEN L.Rate ELSE NULL END) AS D_Rate, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Dinner) & " THEN L.Amount ELSE NULL END) AS D_Amount, " & _
                        " Max(CASE IsNull(H.Shift,'') WHEN " & AgL.Chk_Text(ClsMain.Shift.Dinner) & " THEN L.Remark ELSE NULL END) AS D_LineRemark " & _
                        " FROM " & _
                        " ((SELECT M.WeekDay, M.Shift, Max(M.V_Date) AS V_Date " & _
                        " FROM Mess_Menu M WITH (NoLock) " & _
                        " LEFT JOIN Voucher_Type Vt ON Vt.V_Type = M.V_Type  " & mCondStr & _
                        " GROUP BY M.WeekDay, M.Shift " & _
                        " ) AS vM  " & _
                        " INNER JOIN Mess_Menu H WITH (NoLock) ON vM.V_Date = H.V_Date And vM.WeekDay " & _
                        " = H.WeekDay AND vM.Shift = H.Shift) " & _
                        " LEFT JOIN Mess_Menu1 L WITH (NoLock) ON L.DocId = H.DocId " & _
                        " LEFT JOIN Sch_WeekDay ON Sch_WeekDay.Code = H.WeekDay " & _
                        " Left Join SiteMast SM On H.Site_code = SM.Code " & _
                        " Group By H.Site_Code, H.WeekDay, L.Sr "





            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Mess_MessMenu" : RepTitle = "Mess Chart"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)

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