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
    'Private Const EnquiryFollowupReport As String = "EnquiryFollowupReport"
    Private Const DriverRegister As String = "DriverRegister"
    Private Const VehicleRegister As String = "VehicleRegister"
    Private Const MemberRegister As String = "MemberRegister"
    Private Const VehicleRouteChart As String = "VehicleRouteChart"
    Private Const AttendanceRegister As String = "AttendanceRegister"
    Private Const VehicleExpenseRegister As String = "VehicleMaintenance/ExpenseRegister"
    Private Const VehicleLogRegister As String = "VehicleLogRegister"


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
    Dim mHelpvehicleQry$ = "Select Convert(BIT,0) As [Select], tp.Code as code,tp.RegistrationNo as [Registration No],tp.Description as [Vehicle Name]  from Tp_Vehicle  tp"
    Dim mHelpGateVehicleNoQry$ = "Select Convert(BIT,0) As [Select], H.RegistrationNo  As Code, H.RegistrationNo As [Vehicle No], " & _
                                " H.Description As [Vehicle Name], H.VehicleType [Vehicle Type] " & _
                                " From Tp_Vehicle H  " & _
                                " UNION ALL  " & _
                                " SELECT DISTINCT Convert(BIT,0) As [Select], H.VehicleNo AS Code, H.VehicleNo As [Vehicle No],  " & _
                                " H.VehicleNo As [Vehicle Name], H.VehicleType [Vehicle Type]  " & _
                                " FROM GateInOut H  " & _
                                " Left Join Tp_Vehicle V On H.VehicleNo = V.RegistrationNo  " & _
                                " WHERE V.Code Is Null And isnull(H.VehicleNo,'') != '' "


    Dim mHelpvehicleRoute$ = "Select Convert(BIT,0) As [Select], R.Code as code,R.Description as [Route Name] from Sch_route R"


    Dim mHelpTpMember$ = "Select Convert(BIT,0) As [Select], SubGroup.SubCode As Code, SubGroup.DispName As [Name] , Tp_Member.MemberCardNo as [Member Card No]  " & _
                        " From Tp_Member " & _
                        " LEFT JOIN SubGroup on Tp_Member.SubCode =  SubGroup.SubCode "


    Dim mHelpEnquiryModeQry = " SELECT Convert(BIT,0) As [Select],'E-Mail' AS Code ,'E-Mail' AS Name  " & _
                            " UNION ALL   " & _
                            " SELECT Convert(BIT,0) As [Select],'Phone' AS Code ,'Phone' AS Name   " & _
                            " UNION ALL   " & _
                            " SELECT Convert(BIT,0) As [Select],'SMS' AS Code ,'SMS' AS Name   " & _
                            " UNION ALL   " & _
                            " SELECT Convert(BIT,0) As [Select],'Walking At Office' AS Code ,'Walking At Office' AS Name "

    Dim mHelpFollowupModeQry = " SELECT Convert(BIT,0) As [Select],'E-Mail' AS Code ,'E-Mail' AS Name  " & _
                        " UNION ALL   " & _
                        " SELECT Convert(BIT,0) As [Select],'Phone' AS Code ,'Phone' AS Name   " & _
                        " UNION ALL   " & _
                        " SELECT Convert(BIT,0) As [Select],'SMS' AS Code ,'SMS' AS Name   "

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
#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = "", mQry1$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                'Case EnquiryFollowupReport
                '    StrArr1 = New String() {"Summary", "Detail"}
                '    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Report Type", StrArr1)
                '    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                '    ObjRFG.CreateHelpGrid(mHelpFollowupModeQry, "Followup Mode")
                '    ObjRFG.CreateHelpGrid(mHelpEmployeeQry, "Followup By")
                '    ObjRFG.CreateHelpGrid(mHelpSessionProgrammeQry, "Session Programme")
                '    ObjRFG.CreateHelpGrid(mHelpSessionProgrammeStreamQry, "Session Programme Stream")
                '    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                '    ObjRFG.CreateHelpGrid(mHelpEnquiryNo, "Enquiry No.")

                Case DriverRegister
                    StrArr1 = New String() {"No", "Yes", "All"}
                    Call ObjRFG.Ini_Grp(, , , , "Left Driver", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpEmployeeQry$, "Driver")

                Case VehicleRegister
                    StrArr1 = New String() {"Yes", "No"}
                    StrArr2 = New String() {"All", "Yes", "No"}
                    Call ObjRFG.Ini_Grp(, , , , "Maintenance Detail", StrArr1, , "Own/Rented", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpvehicleQry$, "RegistrationNo")

                Case MemberRegister
                    StrArr1 = New String() {"Yes", "No"}
                    Call ObjRFG.Ini_Grp(, , , , "Memeber Active", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpTpMember$, "Member")

                Case VehicleRouteChart
                    Call ObjRFG.Ini_Grp("Up To Date ", AgL.PubLoginDate, , )
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpvehicleQry$, "Vehicle")
                    ObjRFG.CreateHelpGrid(mHelpvehicleRoute$, "Route Name")

                Case AttendanceRegister
                    StrArr1 = New String() {"Detail", "Summary"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpTpMember$, "Member")
                    ObjRFG.CreateHelpGrid(mHelpvehicleQry$, "Vehicle")
                    ObjRFG.CreateHelpGrid(mHelpvehicleRoute$, "Route Name")

                Case VehicleExpenseRegister
                    StrArr1 = New String() {"Detail", "Summary"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpvehicleQry$, "Vehicle")

                Case VehicleLogRegister
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, , )
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpGateVehicleNoQry, "Vehicle No.")


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
            Case VehicleRegister
                Call ProcVehicleRegister()
            Case MemberRegister
                Call ProcMemberRegister()
            Case VehicleRouteChart
                Call ProcVehicleRouteChart()
            Case AttendanceRegister
                Call ProcAttendanceRegister()
            Case VehicleExpenseRegister
                Call ProcVehicleExpenseRegister()
            Case VehicleLogRegister
                Call ProcVehicleLogRegister()
        End Select
    End Sub

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

#Region "Vehicle Register"
    Private Sub ProcVehicleRegister()
        Try
            Dim mCondStr$ = " Where 1 =1 ", mCondStr1$ = " Where 1 =1 "

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo2_Control) Then Exit Sub
            Call ObjRFG.FillGridString()

            If ObjRFG.GetWhereCondition("Tp.Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Tp.Site_code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Tp.Site_code", 0)
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Tp.Code", 1)


            If AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Yes") Then
                mCondStr += " And Tp.OwnRented =Isnull('Own','') "

            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "No") Then
                mCondStr += " And Tp.OwnRented =Isnull('Rental','') "
            End If






            mCondStr1 = mCondStr

            mQry = " SELECT TP.Code,TP.RegistrationNo ,Tp.Description,TP.VehicleType,TP.VehicleModel,TP.ChassisNo, " & _
                   " TP.EngineNo , TP.SeatingCapacity, TP.Mileage, TP.OwnRented ,Sm.Name as SiteName, Tp.Site_Code , " & _
                   " '" & ObjRFG.ParameterCmbo1_Value & "' As ReportType  " & _
                   " FROM Tp_Vehicle TP  " & _
                   " LEFT JOIN Sitemast Sm on Tp.Site_code = Sm.Code  " & _
                   " " & mCondStr & " "

            mQry1 = " SELECT L.Code as Code , L.Sr, L.Expense, L.ExpenseType,  " & _
                    " L.DueOnDate, L.DueOnMeterReading, L.Remark ,Tp_Expense.Description as ExpenseDesc " & _
                    " FROM Tp_Vehicle TP " & _
                    " Left Join Tp_Vehicle1 L On Tp.Code = L.Code  " & _
                    " LEFT JOIN Tp_Expense ON Tp_Expense.Code = L.Expense  " & mCondStr1

            DsRep = AgL.FillData(mQry, AgL.GCn)
            DsRep1 = AgL.FillData(mQry1, AgL.GCn)


            RepName = "TP_VehicleRegister" : RepTitle = "Vehicle Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            ObjRFG.SubReport1DataSet = DsRep1

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)



        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region
#Region "Member Register"
    Private Sub ProcMemberRegister()
        Try
            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            Call ObjRFG.FillGridString()

            mCondStr = " Where 1=1 "

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then
                mCondStr += " And Tpm.InActiveDate Is Null "

            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "No") Then
                mCondStr += " And Tpm.InActiveDate Is Not Null "
            End If

            If ObjRFG.GetWhereCondition("Sg.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Sg.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sg.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("TPM.SubCode", 1)

            mQry = " SELECT Tpm.SubCode,Tpm.Student,Tpm.Employee,Tpm.MemberCardNo,Tpm.CardPrefix,Tpm.CardSrNo ,  " & _
                   " Tpm.ValidTillDate,Tpm.Vehicle,Tpm.SeatNo,Tpm.Route,Tpm.PickUpPoint,Tpm.ReminderRemark    ,  " & _
                   " Tpm.InActiveDate ,Sg.Add1,Sg.Add2,Sg.Add3,Sg.FatherName,Sg.MotherName,Sg.Phone,Sg.Mobile ,  " & _
                   " Sm.Name As SiteName , Sg.FAX,Sg.EMail ,Sr.Description AS Routename                       ,  " & _
                   " Ar.Description AS Pickuppoint,Tpv.Description AS VehicleName ,Sm.Code as SiteCode        ,  " & _
                   " Sg.ManualCode as MemberCode,C.CityName as City ,Sg.DispName AS MemberName                   " & _
                   " FROM Tp_Member Tpm                                 " & _
                   " LEFT JOIN SubGroup Sg ON SG.SubCode = Tpm.SubCode  " & _
                   " LEFT JOIN Sch_Route Sr ON Tpm.Route = Sr.Code      " & _
                   " LEFT JOIN Sch_Area Ar ON Tpm.PickUpPoint = Ar.Code " & _
                   " LEFT JOIN Tp_Vehicle Tpv ON Tpv.Code = Tpm.Vehicle " & _
                   " LEFT JOIN SiteMast Sm on Sg.Site_code = Sm.Code    " & _
                   " LEFT JOIN City C on Sg.CityCode= C.CityCode        " & _
                   " " & mCondStr & "                                   "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Tp_MemberRegister" : RepTitle = "Member Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region
#Region "Vehicle Route Chart"
    Private Sub ProcVehicleRouteChart()
        Try
            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            Call ObjRFG.FillGridString()

            mCondStr = " where H.AllotmentDate < = " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " "
            mCondStr = mCondStr & " And CASE WHEN H.InActiveDate IS NULL THEN  " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " ELSE H.InActiveDate END >=  " & AgL.ConvertDate(AgL.PubStartDate) & " "
            
            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vehicle", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Route", 2)


            mQry = " SELECT H.Code, H.Vehicle, H.Route, H.AllotmentDate, H.InActiveDate, H.Div_Code, H.Site_Code,             " & _
                   " Sm.Name AS Site_Name, V.RegistrationNo, V.Description AS VehicleName, V.VehicleType, V.VehicleModel,   " & _
                   " V.ChassisNo, V.EngineNo, V.SeatingCapacity, V.Mileage, V.OwnRented, R.Description AS RouteDesc ,        " & _
                   " R1.Area AS PickupPointCode, A.Description AS PickupPointDesc" & _
                   " FROM dbo.Tp_VehicleRoute H                         " & _
                   " LEFT JOIN SiteMast Sm ON Sm.Code = H.Site_Code     " & _
                   " LEFT JOIN Tp_Vehicle V ON V.Code = H.Vehicle       " & _
                   " LEFT JOIN Sch_Route R ON R.Code = H.Route          " & _
                   " LEFT JOIN Sch_Route1 R1 ON R1.Code = R.Code        " & _
                   " LEFT JOIN Sch_Area A ON A.Code = R1.Area           " & _
                   " " & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Tp_VehicleRouteChart" : RepTitle = "Vehicle Route Chart"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region
#Region "Attendance Register"
    Private Sub ProcAttendanceRegister()
        Try
            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            Call ObjRFG.FillGridString()
            mCondStr = " where H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If



            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Member", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Vehicle", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Route", 3)


            mQry = " SELECT H.DocId, H.Div_Code, H.Site_Code, H.V_Date, H.V_Type, H.V_Prefix, H.V_No,  " & _
                   " H.ReferenceNo, H.InOut, H.GateInOutDocID, H.Vehicle, H.Driver, H.TotalMember,  " & _
                   " H.TotalPresent, H.TotalAbsent, H.Remark, H.UID, L.Member, L.Route, L.PickUpPoint, " & _
                   " L.IsPresent, L.IsUnRegistered,V.VehicleType ,V.RegistrationNo, " & _
                   " V.Description AS VehicleName,R.Description AS RouteDesc, G.VehicleNo AS GateVehicleNo ," & _
                   " SM.Name AS Sitename ,Sg.DispName AS MemberDispName ,M.MemberCardNo ,Sg.Name as MemberName ," & _
                   " Sg2.Name As DriverName,Sg2.DispName as DriverDispName ,A.Description as PickupPointDesc , G.Manual_RefNo as ManualRefno  " & _
                   " FROM dbo.Tp_MemberAttendance H " & _
                   " LEFT JOIN dbo.Tp_MemberAttendance1 L ON L.DocId = H.DocId  " & _
                   " LEFT JOIN GateInOut G ON H.GateInOutDocID =G.DocID  " & _
                   " LEFT JOIN Tp_Vehicle V ON V.Code = H.Vehicle " & _
                   " LEFT JOIN Sch_Route  R ON R.Code = L.Route   " & _
                   " LEFT JOIN SiteMast SM ON SM.Code = H.Site_Code " & _
                   " LEFT JOIN SubGroup Sg ON SG.Subcode = L.Member  " & _
                   " LEFT JOIN Tp_Member M ON SG.Subcode = M.SubCode  " & _
                   " LEFT JOIN SubGroup Sg2 ON SG2.Subcode = H.Driver " & _
                   " LEFT JOIN Sch_Area A on L.PickupPoint=  A.Code  " & _
                   " " & mCondStr & "                                   "

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                RepName = "Tp_AttendanceRegister" : RepTitle = "Attendance Register"

            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                RepName = "Tp_AttendanceSummary" : RepTitle = "Attendance Register Summary"
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region
    Private Sub ProcVehicleExpenseRegister()
        Try
            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            Call ObjRFG.FillGridString()
            mCondStr = " where H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Vehicle", 1)

            mQry = " SELECT H.DocId,H.Div_Code,H.Site_Code,H.V_Date,H.V_Type,H.V_Prefix,H.V_No,H.ReferenceNo, " & _
                   " H.Party,H.PartyDocumentNo,H.PartyDocumentDate,H.TotalQty,H.TotalLineAmount," & _
                   " H.TotalLineNetAmount,H.NetSubTotal,H.RoundOff,H.NetAmount,H.Remark, " & _
                   " L.Qty,L.Rate,L.Amount,L.MeterReading,L.NextAfterKm,L.NextAfterDays, " & _
                   " L.NextDate ,E.Description AS ExpenceDesc ,v.RegistrationNo ,v.Description AS VehicleName ,  '" & ObjRFG.ParameterCmbo1_Value & "' As ReportType , " & _
                   " S.Name AS PartyName,S.DispName  AS PartyDispName ,L.NextMeterReading ,SF.*,SL.* ,L.Vehicle ,L.Sr,Sm.Name as SiteName" & _
                   " FROM dbo.Tp_MaintenanceExpenseEntry H " & _
                   " LEFT JOIN Tp_MaintenanceExpenseEntry1 L ON L.DocId = H.DocId " & _
                   " LEFT JOIN  Tp_Expense  E ON L.Expense = E.Code  " & _
                   " LEFT JOIN  Tp_Vehicle V ON  L.Vehicle =V.Code  " & _
                   " LEFT JOIN SubGroup  S ON H.Party = S.SubCode     " & _
                   " LEFT JOIN SiteMast  Sm ON H.Site_Code = Sm.Code     " & _
                   " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.VehicleMaintenanceExpenseEntry) & ") As SF On H.DocId = SF.DocId " & _
                   " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.VehicleMaintenanceExpenseEntry) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                   " " & mCondStr & "                                   "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Tp_VehicleExpenceRegister"
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                RepTitle = "Vehicle Expence Register"

            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                RepTitle = "Vehicle Expence Summary"
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)


        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub

    Private Sub ProcVehicleLogRegister()
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


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.VehicleNo", 1)

            mQry = " SELECT H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_Time, H.V_No, H.Div_Code, H.Site_Code, H.SubCode,  " & _
                    " H.VehicleType, H.VehicleNo, H.Driver, H.Remarks, H.EntryBy, H.EntryDate, H.EntryType, H.Manual_RefNo, H.MeterReading,  " & _
                    " H.InOut AS OpenType, H.Close_MeterReading, H.Close_Date, H.Close_Time, H.Close_Remarks, H.Close_EntryBy, " & _
                    " CASE WHEN H.Close_Date IS NOT NULL THEN 'Yes' ELSE 'No' END AS IsClosed, " & _
                    " CASE WHEN H.Close_Date IS NOT NULL THEN CASE IsNull(H.InOut,'') WHEN '" & ClsMain.InOut.GateOut & "' THEN '" & ClsMain.InOut.GateIn & "' WHEN '" & ClsMain.InOut.GateIn & "' THEN '" & ClsMain.InOut.GateOut & "' END ELSE '' END AS CloseType , " & _
                    " V.RegistrationNo ,V.Description as VehicleName" & _
                    " FROM dbo.GateInOut H " & _
                    " LEFT JOIN  Tp_Vehicle V ON  H.VehicleNo =V.RegistrationNo  " & _
                    " " & mCondStr & "                                   "
            
            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Tp_VehicleLogRegister" : RepTitle = "Vehicle Log Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)


        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub
End Class