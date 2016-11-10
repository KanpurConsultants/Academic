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
    Private Const TimeTableReport As String = "TimeTableReport"
#End Region

#Region "Reports Constant"
    Private Const MaterialReceiptRegister As String = "MaterialReceiptRegister"
    Private Const PurchaseRegister As String = "PurchaseRegister"
    Private Const MaterialReturnRegister As String = "MaterialReturnRegister"
    Private Const SaleOrderRegister As String = "SaleOrderRegister"
    Private Const AstrologyRegister As String = "AstrologyRegister"
    Private Const ArtisionIssueRegister As String = "ArtisionIssueRegister"
    Private Const ArtisionReceiveRegister As String = "ArtisionReceiveRegister"
    Private Const SalesRegister As String = "SalesRegister"
    Private Const StockTransferRegister As String = "StockTransferRegister"
    Private Const StockAdjustmentRegister As String = "StockAdjustmentRegister"
    Private Const SalesmanCommissionStatement As String = "SalesmanCommissionStatement"
    Private Const AstrologerCommissionStatement As String = "AstrologerCommissionStatement"
    Private Const SalesExcutiveWiseAstrologerWiseCommissionStatement As String = "SalesExcutiveWiseAstrologerWiseCommissionStatement"
    Private Const ArtisionWiseBillWiseProfit As String = "ArtisionWiseBillWiseProfit"
    Private Const PartyWiseBillWiseProfit As String = "PartyWiseBillWiseProfit"
    Private Const SaleReturnRegister As String = "SaleReturnRegister"
    Private Const StockRegister As String = "StockRegister"
    Private Const StockInHand As String = "StockInHand"
    Private Const ArtisianIssue As String = "ArtisianIssue"
    Private Const RegistrationRegister As String = "RegistrationRegister"

    Private Const StudentRegister As String = "StudentRegister"
    Private Const TeacherTimeTableReport As String = "TeacherTimeTableReport"
    Private Const ReallocatedTeacherReport As String = "ReallocatedTeacherReport"
    Private Const TeacherAttendanceReport As String = "TeacherAttendanceReport"
#End Region

#Region "Queries Definition"
    Dim mHelpCustomerQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Customer Name] From SubGroup Where Nature In ('Customer') And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpCityQry$ = "Select Convert(BIT,0) As [Select],CityCode, CityName From City "
    Dim mHelpStateQry$ = "Select Convert(BIT,0) As [Select],State_Code, State_Desc From State "
    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpEntryPointQry$ = " Select Distinct Convert(BIT,0) As [Select], User_Permission.MnuText AS code , User_Permission.MnuText As [Entry Point] From User_Permission  "
    Dim mHelpBankQry$ = "Select Convert(BIT,0) As [Select],Bank_Code Code, Bank_Name As [Bank Name] From Bank "
    Dim mHelpBankBranchQry$ = "Select Convert(BIT,0) As [Select],BankBranch_Code Code, BankBranch_Name As [Bank Branch Name] From BankBranch "


    'If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then

    Dim Qry$ = "Select Sitelist From UserSite Where User_Name='" & AgL.PubUserName & "' And CompCode='" & AgL.PubCompCode & "'"
    Dim StrUserSiteList$ = AgL.XNull(AgL.Dman_Execute(Qry, AgL.ECompConn).ExecuteScalar)
    'Dim mCondStr$ = mCondStr & " S.Code In (" & Replace(StrUserSiteList, "|", "'") & ")"

    Dim mHelpSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site/Branch Name] From SiteMast Where " & IIf(AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName), "1=1", " Code In (" & Replace(StrUserSiteList, "|", "'") & ")")


    Dim mHelpCategaryQry$ = "Select Convert(BIT,0) As [Select],Code, Description From Sch_Category "

    Dim mHelpSemesterQry$ = "Select Convert(BIT,0) As [Select], Code, StreamYearSemesterDesc AS Semester, V.SessionProgrammeDesc As [Session Programme], V.StreamManualCode FROM ViewSch_StreamYearSemester V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mhelpSecionQry$ = "Select Convert(BIT,0) As [Select],Code, ClassSectionDesc As [Class/Section],sessionDescription AS Session From ViewSch_ClassSection Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & "  "
    Dim mHelpToSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site/Branch Name] From SiteMast Where Code <>'" & AgL.PubSiteCode & "'"
    Dim mHelpTeacherQry$ = "Select Convert(BIT,0) As [Select],Pem.subcode AS Code, SubGroup.Name As [Teacher Name] From Pay_Employee  pem LEFT JOIN SubGroup ON pem.SubCode=SubGroup.SubCode WHERE (IsNull(pem.IsTeachingStaff,0)<>0 or IsNull(pem.CanTakeClass,0)<>0) and " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "subgroup.Site_Code", AgL.PubSiteCode, "SubGroup.CommonAc") & " "

    Dim mHelpClassSectionSubSectionQry$ = "SELECT Convert(BIT,0) As [Select], S.Code , S.SubSection As [Sub-Section], S.ClassSectionDesc As [Section] " & _
                                           " FROM ViewSch_ClassSectionSubSection S " & _
                                           " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                                           " And IsNull(S.IsOpenElectiveSection,0) = 0  "


#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                Case StudentRegister
                    StrArr1 = New String() {"With Picture", "With Out Picture"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site ")
                    ObjRFG.CreateHelpGrid(mHelpCityQry$, "City Name ")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name ")

                Case RegistrationRegister
                    StrArr1 = New String() {"Yes", "No"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "With Detail Fees", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site ")
                    ObjRFG.CreateHelpGrid(mHelpCityQry$, "City Name ")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name ")

                Case TimeTableReport, TeacherTimeTableReport
                    Call ObjRFG.Ini_Grp("Print Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site ")
                    ObjRFG.CreateHelpGrid(mhelpSecionQry$, "Section Name ")
                    ObjRFG.CreateHelpGrid(mHelpClassSectionSubSectionQry$, "Sub Section")
                    ObjRFG.CreateHelpGrid(mHelpTeacherQry$, "Teacher Name ")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester")


                Case ReallocatedTeacherReport
                    Call ObjRFG.Ini_Grp("Print Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site ")
                    ObjRFG.CreateHelpGrid(mHelpTeacherQry$, "Teacher Name ")

                Case TeacherAttendanceReport
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site ")
                    ObjRFG.CreateHelpGrid(mHelpTeacherQry$, "Teacher Name ")

            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName
            Case SalesRegister
                ProcSalesRegister()

            Case StudentRegister
                procStudentRegister()

            Case RegistrationRegister
                ProcRegistrationRegister()

            Case TimeTableReport, TeacherTimeTableReport
                procTimeTableReport()

            Case ReallocatedTeacherReport
                procReallocatedTeacherReport()

            Case TeacherAttendanceReport
                procTeacherAttendanceReport()
        End Select
    End Sub

#Region "Teacher Attendance Report"
    Private Sub ProcTeacherAttendanceReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = " where 1=1 "
            Dim mCondStr1$ = ""
            Dim StrUserSiteList$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            If ObjRFG.GetWhereCondition("PD.Site_Code", 0) = "" Then
                StrUserSiteList = FunGetSiteList(AgL.PubUserName)
                If StrUserSiteList <> "" Then
                    mCondStr += " And PD.Site_Code In (" & Replace(StrUserSiteList, "|", "'") & ")"
                End If
            Else
                mCondStr += ObjRFG.GetWhereCondition("PD.Site_Code", 0)
            End If



            mCondStr = mCondStr & " and pd.A_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("pd1.Employee", 1)

            mQry = " SELECT pd.A_Date,pd.PreparedBy ,pemp.Name,CASE WHEN pd1.IsPresent=1 THEN 'Present' ELSE 'Absent' END AS [Present/Absent], " & _
                     " (CASE WHEN pd1.IsPresent = 0 THEN 0 ELSE 1 END)  TotalPresent, (CASE WHEN pd1.IsPresent = 0 THEN 1 ELSE 0 END)  TotalAbsent " & _
                     " FROM Pay_DayAttendance pd LEFT JOIN Pay_DayAttendance1 pd1 ON pd.Code=pd1.Code " & _
                     " LEFT JOIN SubGroup Pemp ON pd1.Employee=pemp.SubCode " & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "TT_Teacher_Attendance_Report" : RepTitle = "Teacher Attendance Report"
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_TimeTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Reallocated Teacher Report"
    Private Sub procReallocatedTeacherReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = " Where 1=1  "
            Dim mCondStr1$ = ""
            Dim StrUserSiteList$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub

            If ObjRFG.GetWhereCondition("R.Site_Code", 0) = "" Then
                StrUserSiteList = FunGetSiteList(AgL.PubUserName)
                If StrUserSiteList <> "" Then
                    mCondStr += " And R.Site_Code In (" & Replace(StrUserSiteList, "|", "'") & ")"
                End If
            Else
                mCondStr += ObjRFG.GetWhereCondition("R.Site_Code", 0)
            End If


            mCondStr = mCondStr & " and  R.ReallocationDate = " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & "  "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("r1.ReallocateTeacher", 1)

            mQry = " Select T.ClassSection  ,Sch_TimeSlot.Description AS Time_Slot,SubGroup.Name AS Reallocated_teacher,ViewSch_ClassSection.ClassSectionDesc," & _
                   " vcss.ClassSectionSubSectionDesc,r.ReallocationDate,s1.Name AS RePlacedTo,r.PreparedBy,ss.Description AS subjectname,'" & ObjRFG.ParameterDate1_Value & "'  as FPrintDate,R1.IsEngageTimeSlot,ss1.Description AS TimeTableSubject  " & _
                   " From TT_ReallocateTeacher r LEFT JOIN TT_ReallocateTeacher1 R1 ON r.Code=r1.Code LEFT JOIN TT_TimeTable T ON R1.TimeTable = T.Code " & _
                   " LEFT JOIN Sch_TimeSlot Ts ON R1.TimeSlot = Ts.Code LEFT JOIN Sch_TimeSlot ON r1.TimeSlot=Sch_TimeSlot.Code LEFT JOIN SubGroup s1 ON r.Teacher=s1.SubCode " & _
                   " LEFT JOIN SubGroup ON r1.ReallocateTeacher=SubGroup.SubCode LEFT JOIN ViewSch_ClassSection ON t.ClassSection=ViewSch_ClassSection.Code " & _
                   " LEFT JOIN ViewSch_ClassSectionSubSection vcss ON r1.ClassSectionSubSection=vcss.Code " & _
                   " LEFT JOIN Sch_Subject ss ON r1.Subject=ss.Code LEFT JOIN Sch_Subject ss1 ON r1.TimeTableSubject=ss1.Code" & mCondStr & " and SubGroup.Name is not null " & _
                   " ORDER BY Ts.StartTime "



            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "TT_Reallocated_Teacher_Report" : RepTitle = "Reallocated Teacher Report"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_TimeTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try


    End Sub
#End Region

#Region "TimeTableReport"
    Private Sub procTimeTableReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = " Where 1=1 ", mCondStr1$ = " Where 1=1 ", mCondStr2$ = " Where 1=1 "
            Dim bQrySemester$ = ""
            Dim StrUserSiteList$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub


            mCondStr1 += " And H.ApplyDate <= " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " "


            If ObjRFG.GetWhereCondition("T.Site_Code", 0) = "" Then
                StrUserSiteList = FunGetSiteList(AgL.PubUserName)
                If StrUserSiteList <> "" Then
                    mCondStr1 += " And H.Site_Code In (" & Replace(StrUserSiteList, "|", "'") & ")"
                    mCondStr += " And T.Site_Code In (" & Replace(StrUserSiteList, "|", "'") & ")"
                End If
            Else
                mCondStr1 += ObjRFG.GetWhereCondition("H.Site_Code", 0)
                mCondStr += ObjRFG.GetWhereCondition("T.Site_Code", 0)
            End If




            mCondStr1 += ObjRFG.GetWhereCondition("H.ClassSection", 1)
            mCondStr += ObjRFG.GetWhereCondition("T.ClassSection", 1)

            mCondStr += ObjRFG.GetWhereCondition("S1.Code", 2)
            mCondStr += ObjRFG.GetWhereCondition("T1.Teacher", 3)

            If ObjRFG.GetWhereCondition("Sem3.Code", 4) = "" Then
                bQrySemester = "Select 1 "
            Else
                mCondStr2 += ObjRFG.GetWhereCondition("V1.ClassSection", 1)
                mCondStr2 += ObjRFG.GetWhereCondition("Sem3.Code", 4)

                bQrySemester = "SELECT V1.ClassSection, Sem3.Code, Sem3.StreamYearSemesterDesc  " & _
                                " FROM (" & _
                                "        SELECT v.ClassSection, v.SessionProgrammeStreamCode, Max(Sem2.SemesterStartDate) AS LastSemesterStartDate " & _
                                "        FROM( " & _
                                "        	SELECT Css.ClassSection, Sem1.SessionProgrammeStreamCode, Min(Sem1.SemesterStartDate) AS SemesterStartDate " & _
                                "        	FROM Sch_ClassSectionSemester Css WITH (NoLock) " & _
                                "        	LEFT JOIN ViewSch_StreamYearSemester Sem1 WITH (NoLock) ON Sem1.Code = Css.StreamYearSemester  " & _
                                "        	GROUP BY Css.ClassSection, Sem1.SessionProgrammeStreamCode " & _
                                "        	) AS V " & _
                                "        LEFT JOIN ViewSch_StreamYearSemester Sem2 WITH (NoLock) ON  " & _
                                "        Sem2.SessionProgrammeStreamCode = v.SessionProgrammeStreamCode " & _
                                "        AND Sem2.SemesterStartDate BETWEEN V.SemesterStartDate AND " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " " & _
                                "        GROUP BY v.ClassSection, v.SessionProgrammeStreamCode " & _
                                " ) AS V1 " & _
                                " LEFT JOIN ViewSch_StreamYearSemester Sem3 WITH (NoLock) ON Sem3.SessionProgrammeStreamCode = V1.SessionProgrammeStreamCode AND Sem3.SemesterStartDate = V1.LastSemesterStartDate " & _
                                " " & mCondStr2 & ""
            End If


            mQry = "IF EXISTS (" & bQrySemester & ") " & _
                    " SELECT T.ApplyDate, T.WeekDay AS WeekDayCode, D.Description As WeekDayDesc, " & _
                    " S1.ClassSectionSubSectionDesc, S.ClassSectionDesc, S.SessionDescription, " & _
                    " S.SessionProgrammeDesc, Sub.DisplayName As SubjectDisplayName, Sub.SubjectType, Sg.Name AS TeacherName, " & _
                    " Ts.Description As TimeSlotDesc, T1.TimeSlot, " & _
                    " '" & ObjRFG.ParameterDate1_Value & "'  as FPrintDate,  Ts.StartTime ,Ts.EndTime, S1.SubSection " & _
                    " FROM (( " & _
                    " 	SELECT H.ClassSection, H.WeekDay, Max(H.ApplyDate) AS ApplyDate " & _
                    " 	FROM TT_TimeTable H WITH (NoLock) " & _
                    " 	" & mCondStr1 & " " & _
                    " 	GROUP BY H.ClassSection, H.WeekDay " & _
                    " 	) AS vH  " & _
                    " INNER JOIN TT_TimeTable T WITH (NoLock) ON T.ClassSection = vH.ClassSection AND T.WeekDay = vH.WeekDay AND T.ApplyDate = vH.ApplyDate) " & _
                    " LEFT JOIN TT_TimeTable1 T1 WITH (NoLock) ON T.Code = T1.Code    " & _
                    " LEFT JOIN Sch_WeekDay D WITH (NoLock) ON D.Code = T.WeekDay    " & _
                    " LEFT JOIN ViewSch_ClassSection S WITH (NoLock) ON T.ClassSection = S.Code  " & _
                    " LEFT JOIN Sch_TimeSlot Ts WITH (NoLock) ON T1.TimeSlot = Ts.Code    " & _
                    " LEFT JOIN Sch_Subject Sub WITH (NoLock) ON T1.Subject = Sub.Code    " & _
                    " LEFT JOIN Pay_Employee E WITH (NoLock) ON T1.Teacher = E.SubCode    " & _
                    " LEFT JOIN SubGroup Sg WITH (NoLock) ON E.SubCode = Sg.SubCode    " & _
                    " LEFT JOIN ViewSch_ClassSectionSubSection S1 WITH (NoLock) ON T1.ClassSectionSubSection = S1.Code  " & _
                    " " & mCondStr & " " & _
                    " ELSE SELECT -1 "
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 1 And DsRep.Tables(0).Columns.Count = 1 Then
                If AgL.XNull(DsRep.Tables(0).Rows(0)(0)) = "-1" Then
                    Err.Raise(1, , "No Records to Print!")
                End If
            End If

            If AgL.StrCmp(GRepFormName, TeacherTimeTableReport) Then
                RepName = "TT_Teacher_TimeTable" : RepTitle = "Teacher Time Table"
            Else
                RepName = "TT_TimeTable" : RepTitle = "Time Table"
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_TimeTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Registration Register"
    Private Sub ProcRegistrationRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

           
            mCondStr = " where  " & AgL.PubSiteCondition("SR.Site_Code", AgL.PubSiteCode) & "  and Sr.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sr.Site_code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("srd.citycode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("srd.Category", 2)


            mQry = "SELECT Sr.Docid,SR.V_Type,SR.V_No,SR.totalamount,SR.totaldiscount,SR.totalnetAmount ," & _
            " SR.v_date,san.Description as AdmissionNature,SPS.SessionProgrammeStream, " & _
            " SRD.FirstName as [First Name],SRD.MiddleName as [Middle Name], Srd.Lastname as [Last Name]," & _
            " SRD.Sex as [Male/Female],SRD.Fathername as [Father Name],SRD.MotherName as [Mother Name]," & _
            " SRD.Add1 as [Address1],SRD.add2 as Address2,SRD.pin," & _
            " city.cityname as [CityName]," & _
            " SRD.Mobile,Srd.Phone,SRD.Dob,SRD.Email,SRD.BloodGroup," & _
            " Sch_Category.Description as Category ,ViewSch_Fee.DispName as Fees,SRf.AMount as [Line Amount],SRF.discount as [Line Discount],srf.netamount as [Line NetAmount],  " & _
             " '" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForCity,'" & ObjRFG.GetHelpString(2) & "' As ForCatgory, " & _
              " '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' as Todate,'" & ObjRFG.ParameterCmbo1_Value & "' as FessDetailYN " & _
            " FROM Sch_Registration SR " & _
            " LEFT JOIN Sch_RegistrationStudentDetail srd ON SR.DocId=srd.DocId" & _
            " left join Sch_RegistrationFee srf on sr.docid=srf.docid " & _
            " LEFT JOIN ViewSch_Fee ON Srf.fee=ViewSch_Fee.code " & _
            " LEFT JOIN Sch_AdmissionNature San ON SR.AdmissionNature=san.Code" & _
            " LEFT JOIN ViewSch_SessionProgrammeStream sps ON SR.SessionProgrammeStream=sps.Code" & _
            " left join city on srd.citycode=city.citycode " & _
            " LEFT JOIN Sch_Category ON SRD.Category=Sch_Category.Code" & _
            " " & mCondStr & " "


          
            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "Academic_main_RegistrationRegister" : RepTitle = "Registration Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_TimeTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Student Register"
    Private Sub procStudentRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = " where 1=1 "
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub


            'mCondStr = mCondStr & " And Vt.NCat in (" & AgL.Chk_Text(SRAK_ProjLib.ClsMain.SaleInvoiceNCat) & "," & AgL.Chk_Text(SRAK_ProjLib.ClsMain.TaxInvoiceNCat) & ", " & AgL.Chk_Text(SRAK_ProjLib.ClsMain.CentralSaleNCat) & ") "
            'mCondStr1 = mCondStr1 & " And Vt.NCat in (" & AgL.Chk_Text(SRAK_ProjLib.ClsMain.SaleInvoiceNCat) & "," & AgL.Chk_Text(SRAK_ProjLib.ClsMain.TaxInvoiceNCat) & ", " & AgL.Chk_Text(SRAK_ProjLib.ClsMain.CentralSaleNCat) & ") "

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Site_code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("s.citycode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("f.Category", 2)

            mQry = "Select F.SubCode , S.ManualCode As [Manual Code],  S.Name As [Name],F.FirstName as [First Name],f.MiddleName as [Middle Name], " & _
                                 " F.Lastname as [Last Name],F.Sex as [Male/Female],s.Fathername as [Father Name],F.MotherName as [Mother Name]," & _
                                 " S.Add1 as [Address1],s.add2 as Address2,S.pin,city.cityname as [CityName],S.Mobile,S.Phone,S.Dob,S.Email,f.BloodGroup,Sch_Category.Description as Category, " & _
                                 " '" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForCity,'" & ObjRFG.GetHelpString(2) & "' As ForCatgory,SubGroup_Image.photo " & _
                                 " From  Sch_Student F Left join SubGroup S On F.SubCode = S.SubCode left join city on s.citycode=city.citycode   LEFT JOIN Sch_Category ON f.Category=Sch_Category.Code left JOIN  SubGroup_Image ON s.subcode=SubGroup_Image.subcode  " & _
                                   " " & mCondStr & " "
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "With Picture") Then
                RepName = "Academic_main_StudentRegister_Picture" : RepTitle = "Student Register"
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "With Out Picture") Then
                RepName = "Academic_main_StudentRegister" : RepTitle = "Student Register"
            End If
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_TimeTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Sales Register"
    Private Sub ProcSalesRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            mCondStr = " where  " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & "  and S.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr1 = " where  " & AgL.PubSiteCondition("S1.Site_Code", AgL.PubSiteCode) & "  and S1.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            'mCondStr = mCondStr & " And Vt.NCat in (" & AgL.Chk_Text(SRAK_ProjLib.ClsMain.SaleInvoiceNCat) & "," & AgL.Chk_Text(SRAK_ProjLib.ClsMain.TaxInvoiceNCat) & ", " & AgL.Chk_Text(SRAK_ProjLib.ClsMain.CentralSaleNCat) & ") "
            'mCondStr1 = mCondStr1 & " And Vt.NCat in (" & AgL.Chk_Text(SRAK_ProjLib.ClsMain.SaleInvoiceNCat) & "," & AgL.Chk_Text(SRAK_ProjLib.ClsMain.TaxInvoiceNCat) & ", " & AgL.Chk_Text(SRAK_ProjLib.ClsMain.CentralSaleNCat) & ") "

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Customer", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Astrologer", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.SalesMan", 2)



            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                mQry = " SELECT S.DocId, S.V_Date,S.V_No,S.Amount,S.Scheme,S.Addition,S.Deduction, " & _
                       " S.TaxableAmt,S.TaxAmt,S.AdditionAfterTax,S.DeductionAfterTax, " & _
                       " S.Labour,S.AmountWithTax,S.RoundOff,S.TotalAmount,S.NetAmount, " & _
                       " S.Advance,S.Balance ,SubGroup.Name AS Customer,Astro.Name AS Astrologer, " & _
                       " sman.Name AS SalesMan,SaleOrder.V_No AS OrderNo ,'" & ObjRFG.GetHelpString(0) & "' As ForCustomer, " & _
                       " '" & ObjRFG.GetHelpString(1) & "' As ForAstrologer,'" & ObjRFG.GetHelpString(2) & "' As ForSalesman, " & _
                       " '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' as Todate " & _
                       " FROM Sale S " & _
                       " LEFT JOIN Voucher_Type Vt ON S.V_Type = Vt.V_Type " & _
                       " LEFT JOIN SubGroup ON S.Customer=SubGroup.SubCode " & _
                       " LEFT JOIN SubGroup Astro ON S.Astrologer=Astro.SubCode " & _
                       " LEFT JOIN SubGroup SMan ON S.SalesMan=Sman.SubCode " & _
                       " LEFT JOIN SaleOrder ON S.SaleOrderDocId=SaleOrder.DocId " & _
                       " " & mCondStr & " "
                DsRep = AgL.FillData(mQry, AgL.GCn)

                RepName = "SalesRegister" : RepTitle = "Sale Register"
            Else
                mQry = " SELECT S.DocId, S.V_Date,S.V_No,S.Amount,S.Scheme,S.Addition,S.Deduction, " & _
                       " S.TaxableAmt,S.TaxAmt,S.AdditionAfterTax,S.DeductionAfterTax, " & _
                       " S.Labour,S.AmountWithTax,S.RoundOff,S.TotalAmount,S.NetAmount, " & _
                       " S.Advance,S.Balance ,SubGroup.Name AS Customer,Astro.Name AS Astrologer, " & _
                       " sman.Name AS SalesMan,SaleOrder.V_No AS OrderNo,S1.Sr as L_Sr, S1.BarCode as L_BarCode, S1.Item as L_Item, (Case When IsNull(S1.ItemDesc,'')='' Then I.Description Else S1.ItemDesc End) as L_ItemDesc, S1.IssueQty as L_IssueQty, S1.PrintQty as L_PrintQty, " & _
                       "S1.Rate as L_Rate, S1.Amount as L_Amount, S1.Addition as L_Addition, S1.Deduction as L_Deduction, S1.TaxableAmt as L_TaxableAmt, S1.TaxPer as L_TaxPer, S1.TaxAmt as L_TaxAmt, " & _
                       "S1.AdditionalTaxPer as L_AdditionalTaxPer, S1.AdditionalTaxAmt as L_AdditionalTaxAmt, S1.NetAmount as L_NetAmount ,'" & ObjRFG.GetHelpString(0) & "' As ForCustomer, " & _
                       " '" & ObjRFG.GetHelpString(1) & "' As ForAstrologer,'" & ObjRFG.GetHelpString(2) & "' As ForSalesman, " & _
                       " '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' as Todate " & _
                       " FROM Sale S " & _
                       " Left Join Stock S1 On S.DocId = S1.DocId " & _
                       " Left Join Item I On S1.Item = I.Code " & _
                       " LEFT JOIN Voucher_Type Vt ON S.V_Type = Vt.V_Type " & _
                       " LEFT JOIN SubGroup ON S.Customer=SubGroup.SubCode " & _
                       " LEFT JOIN SubGroup Astro ON S.Astrologer=Astro.SubCode " & _
                       " LEFT JOIN SubGroup SMan ON S.SalesMan=Sman.SubCode " & _
                       " LEFT JOIN SaleOrder ON S.SaleOrderDocId=SaleOrder.DocId " & _
                       " " & mCondStr & " "
                DsRep = AgL.FillData(mQry, AgL.GCn)


                RepName = "SalesRegisterDetail" : RepTitle = "Sale Register (Detailed)"

                'If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Detail") Then
                '    mQry = "SELECT S1.DocId, S1.Sr as L_Sr, S1.BarCode as L_BarCode, S1.Item as L_Item, S1.ItemDesc as L_ItemDesc, S1.IssueQty as L_IssueQty, S1.PrintQty as L_PrintQty, " & _
                '           "S1.Rate as L_Rate, S1.Amount as L_Amount, S1.Addition as L_Addition, S1.Deduction as L_Deduction, S1.TaxableAmt as L_TaxableAmt, S1.TaxPer as L_TaxPer, S1.TaxAmt as L_TaxAmt, " & _
                '           "S1.AdditionalTaxPer as L_AdditionalTaxPer, S1.AdditionalTaxAmt as L_AdditionalTaxAmt, S1.NetAmount as L_NetAmount  " & _
                '           "FROM Stock S1 " & _
                '           " LEFT JOIN Voucher_Type Vt ON S1.V_Type = Vt.V_Type "
                '    ObjRFG.SubReport1DataSet = AgL.FillData(mQry, AgL.GCn)
                'End If
            End If
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_TimeTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub

    Public Function FunGetSiteList(ByVal bUserName As String) As String
        Dim StrUserSiteList$ = ""
        Try
            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
                Dim Qry$ = "Select Sitelist From UserSite Where User_Name='" & bUserName & "' And CompCode='" & AgL.PubCompCode & "'"
                StrUserSiteList = AgL.XNull(AgL.Dman_Execute(Qry, AgL.GcnRead).ExecuteScalar)
            End If

        Catch ex As Exception
            StrUserSiteList = ""
            MsgBox(ex.Message)
        Finally
            FunGetSiteList = StrUserSiteList
        End Try
    End Function

End Class
