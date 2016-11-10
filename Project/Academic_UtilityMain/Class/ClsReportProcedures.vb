Public Class ClsReportProcedures

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub

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

    Dim DsRep As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = ""

    Private Const UserWiseEntryReport As String = "UserWiseEntryReport"
    Private Const UserWiseEntryTargetReport As String = "UserWiseEntryTargetReport"
    Private Const UserWiseEntryActionReport As String = "UserWiseEntryActionReport"



#Region "Queries Definition"
    Dim mHelpSalesManQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [SalesMan Name] From SubGroup Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpCustomerQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Customer Name] From SubGroup Where Nature In ('Customer') And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpAstrologerQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Astrologer Name] From SubGroup Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpVehicleQry$ = "Select Convert(BIT,0) As [Select], Code As Code, Description As [Vehicle ] From Vehicle  "
    Dim mHelpVehicleDescriptionQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Code, Description As [Vehicla No] From Vehicle "
    Dim mHelpCourierCompanyQry$ = "Select DISTINCT Convert(BIT,0) As [Select], Code, Description As [Courier Company] From CourierCompany "
    Dim mHelpPartyQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Party Name] From SubGroup Where Nature In ('Customer','Supplier')  And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & ""

    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpEntryPointQry$ = " Select Distinct Convert(BIT,0) As [Select], User_Permission.MnuText AS code , User_Permission.MnuText As [Entry Point] From User_Permission  "

#End Region

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                Case UserWiseEntryReport
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)

                    ObjRFG.CreateHelpGrid(mHelpUserQry, "User")
                    ObjRFG.CreateHelpGrid("Select Distinct Convert(BIT,0) As [Select],EntryPoint As Code, EntryPoint As [Module] From LogTable ", "Module")


                Case UserWiseEntryTargetReport
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Type", StrArr1)

                    ObjRFG.CreateHelpGrid(mHelpUserQry, "UserName")
                    ObjRFG.CreateHelpGrid(mHelpEntryPointQry, "Entry")

                Case UserWiseEntryActionReport
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)

                    ObjRFG.CreateHelpGrid(mHelpUserQry, "UserName")
                    ObjRFG.CreateHelpGrid(mHelpEntryPointQry, "Entry")

            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName

            Case UserWiseEntryReport
                ProcUserWiseEntryReport()

            Case UserWiseEntryTargetReport
                ProcUserWiseEntryTargetReport()

            Case UserWiseEntryActionReport
                ProcUserWiseEntryActionReport()

        End Select
    End Sub

#Region "User Wise Entry Report"
    Private Sub ProcUserWiseEntryReport()
        Try

            Call ObjRFG.FillGridString()

            Dim mCondStr As String = ""


            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = mCondStr & " And CONVERT(SMALLDATETIME,REPLACE(CONVERT(VARCHAR, L.U_EntDt,106),' ','/')) Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.U_Name", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.EntryPoint", 1)

            mQry = "Select L.U_Name, L.EntryPoint, Count(Case When U_AE='A' Then 1 End) As [Add], Count(Case When U_AE='E' Then 1 End) As [Edit], " & _
                   "Count(Case When U_AE='D' Then 1 End) As [Delete], Count(Case When U_AE='P' Then 1 End) As [Print], 0 As Email, 0 As Sms, 0 As Fax, " & _
                   "'" & ObjRFG.GetHelpString(0) & "' As SelGrid1, '" & ObjRFG.GetHelpString(1) & "' As SelGrid2 " & _
                   "From LogTable L "

            mQry = mQry & " Where 1=1  " & mCondStr
            mQry = mQry & " Group By L.U_Name, L.EntryPoint "
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            RepName = "UserWiseEntryReport" : RepTitle = "User Wise Entry Report"

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Utility)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "User Wise Target Entry Detail"
    Private Sub ProcUserWiseEntryTargetReport()
        Try

            Call ObjRFG.FillGridString()

            Dim mCondStr As String = ""
            Dim mDays As Long = 0

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            mDays = DateDiff(DateInterval.Day, CDate(ObjRFG.ParameterDate1_Value), CDate(ObjRFG.ParameterDate2_Value))
            mCondStr = mCondStr & " And CONVERT(SMALLDATETIME,REPLACE(CONVERT(VARCHAR, LogTable.U_EntDt,106),' ','/')) Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & " And ((Ut.Date_to >= " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And Ut.Date_to <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & ") Or Ut.Date_to Is Null ) "



            mCondStr = mCondStr & ObjRFG.GetWhereCondition("LogTable.U_Name", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("LogTable.EntryPoint", 1)

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Summary") Then
                mCondStr = mCondStr & " GROUP BY LogTable.U_Name ,LogTable.EntryPoint "

                mQry = " SELECT LogTable.EntryPoint,Max(convert(NVARCHAR,LogTable.U_EntDt,3)) as U_Entdt,LogTable.U_Name," & _
                       " sum(CASE WHEN LogTable.u_ae='A' THEN 1 ELSE 0 END) AS ActualAdd, " & _
                       " sum(CASE WHEN LogTable.u_ae='E' THEN 1 ELSE 0 END) AS ActualEdit, " & _
                       " sum(CASE WHEN LogTable.u_ae='D' THEN 1 ELSE 0 END) AS Actualdel, " & _
                       " sum(CASE WHEN LogTable.u_ae='P' THEN 1 ELSE 0 END) AS ActualPrint, " & _
                       " sum(CASE WHEN LogTable.u_ae='F' THEN 1 ELSE 0 END) AS ActualFax, " & _
                       " sum(CASE WHEN LogTable.u_ae='S' THEN 1 ELSE 0 END) AS ActualSms, " & _
                       " sum(CASE WHEN LogTable.u_ae='M' THEN 1 ELSE 0 END) AS ActualEmail, " & _
                       " Convert(Float,max(utd.Add_Target))*" & mDays & " AS AddTarget,Convert(Float,max(utd.Edit_Target))*" & mDays & " AS Edittarget, " & _
                       " Convert(Float,max(utd.Print_Target))*" & mDays & " AS printtarget,Convert(Float,max(utd.Fax_Target))*" & mDays & " AS faxtarget,Convert(Float,max(utd.Email_Target))*" & mDays & " AS Emailtarget, " & _
                       " Convert(Float,max(utd.Sms_Target))*" & mDays & " AS smstarget,'" & ObjRFG.GetHelpString(0) & "' As SelGrid1, '" & ObjRFG.GetHelpString(1) & "' As SelGrid2  " & _
                       " FROM LogTable  LEFT JOIN User_Target ut ON LogTable.U_Name=ut.UserName " & _
                       " LEFT JOIN User_Target_Detail utd ON ut.Code=utd.Code "

                mQry = mQry & " Where LogTable.U_Name <>''  " & mCondStr


                mQry = "Select EntryPoint, U_EntDt, U_Name, ActualAdd, ActualEdit, ActualDel, ActualPrint, ActualFax, " & _
                       "ActualSms, ActualEmail, AddTarget, EditTarget, PrintTarget, FaxTarget, EmailTarget, " & _
                       "SmsTarget, (Case When AddTarget<>0 then (ActualAdd/AddTarget)*100 End) As AddPer, " & _
                       "(Case When EditTarget<>0 then (ActualEdit/EditTarget)*100 End) As EditPer, " & _
                       "(Case When PrintTarget<>0 then (ActualPrint/PrintTarget) End) As PrintPer, SelGrid1, SelGrid2  " & _
                       "From (" & mQry & ") As X "

                DsRep = AgL.FillData(mQry, AgL.GCn)
                If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


                RepName = "UserWiseEntryTargetReportSummary" : RepTitle = "User Wise Target Entry Summary"
                ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Utility)
            Else

                mCondStr = mCondStr & " GROUP BY LogTable.U_Name ,LogTable.EntryPoint,convert(NVARCHAR,LogTable.U_EntDt,3) "

                mQry = " SELECT LogTable.EntryPoint,convert(NVARCHAR,LogTable.U_EntDt,3) as U_Entdt,LogTable.U_Name," & _
                       " sum(CASE WHEN LogTable.u_ae='A' THEN 1 ELSE 0 END) AS ActualAdd, " & _
                       " sum(CASE WHEN LogTable.u_ae='E' THEN 1 ELSE 0 END) AS ActualEdit, " & _
                       " sum(CASE WHEN LogTable.u_ae='D' THEN 1 ELSE 0 END) AS Actualdel, " & _
                       " sum(CASE WHEN LogTable.u_ae='P' THEN 1 ELSE 0 END) AS ActualPrint, " & _
                       " sum(CASE WHEN LogTable.u_ae='F' THEN 1 ELSE 0 END) AS ActualFax, " & _
                       " sum(CASE WHEN LogTable.u_ae='S' THEN 1 ELSE 0 END) AS ActualSms, " & _
                       " sum(CASE WHEN LogTable.u_ae='M' THEN 1 ELSE 0 END) AS ActualEmail, " & _
                       " Convert(Float,max(utd.Add_Target)) AS AddTarget,Convert(Float,max(utd.Edit_Target)) AS Edittarget, " & _
                       " Convert(Float,max(utd.Print_Target)) AS printtarget,Convert(Float,max(utd.Fax_Target)) AS faxtarget,Convert(Float,max(utd.Email_Target)) AS Emailtarget, " & _
                       " Convert(Float,max(utd.Sms_Target)) AS smstarget,'" & ObjRFG.GetHelpString(0) & "' As SelGrid1, '" & ObjRFG.GetHelpString(1) & "' As SelGrid2  " & _
                       " FROM LogTable  LEFT JOIN User_Target ut ON LogTable.U_Name=ut.UserName " & _
                       " LEFT JOIN User_Target_Detail utd ON ut.Code=utd.Code  "

                mQry = mQry & " Where LogTable.U_Name <>''  " & mCondStr


                mQry = "Select EntryPoint, U_EntDt, U_Name, ActualAdd, ActualEdit, ActualDel, ActualPrint, ActualFax, " & _
                       "ActualSms, ActualEmail, AddTarget, EditTarget, PrintTarget, FaxTarget, EmailTarget, " & _
                       "SmsTarget, (Case When AddTarget<>0 then (ActualAdd/AddTarget)*100 End) As AddPer, " & _
                       "(Case When EditTarget<>0 then (ActualEdit/EditTarget)*100 End) As EditPer, " & _
                       "(Case When PrintTarget<>0 then (ActualPrint/PrintTarget) End) As PrintPer, SelGrid1, SelGrid2  " & _
                       "From (" & mQry & ") As X "

                DsRep = AgL.FillData(mQry, AgL.GCn)
                If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

                RepName = "UserWiseEntryTargetReport" : RepTitle = "User Wise Target Entry Detail"
                ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Utility)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "User Wise Entry Action Report"
    Private Sub ProcUserWiseEntryActionReport()
        Try

            Call ObjRFG.FillGridString()

            Dim mCondStr As String = ""
            Dim mDays As Long = 0

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
           
            mDays = DateDiff(DateInterval.Day, CDate(ObjRFG.ParameterDate1_Value), CDate(ObjRFG.ParameterDate2_Value))
            mCondStr = mCondStr & " And CONVERT(SMALLDATETIME,REPLACE(CONVERT(VARCHAR, L.U_EntDt,106),' ','/')) Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = mCondStr & " And ((Ut.Date_to >= " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And Ut.Date_to <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & ") Or Ut.Date_to Is Null ) "



            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.U_Name", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.EntryPoint", 1)
            mCondStr = mCondStr & " and L.U_Name <>''  "

            mQry = " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " AD.Student AS SubCode, Ad.V_Date AS V_Date, Ad.V_No AS V_No, Sg.Name AS Student  " & _
                   " FROM Sch_Admission Ad WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON Ad.Student=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=Ad.DocId  " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Admission Entry','Admission Entry [Authenticated]') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " SG.Student AS SubCode, FR.V_Date AS V_Date, FR.V_No AS V_No, Sg.Studentname AS Student  " & _
                   " FROM Sch_FeeReceive FR WITH (NoLock) " & _
                   " LEFT JOIN ViewSch_Admission Sg WITH (NoLock) ON FR.AdmissionDocID=Sg.DocID " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=FR.DocId " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Fee Receive Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student   " & _
                   " FROM Sch_AcademicProgress H WITH (NoLock)   " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId  " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Academic Progress (Laboratory)') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student   " & _
                   " FROM Sch_AcademicProgress H WITH (NoLock)   " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId  " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Academic Progress (Theory)') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student   " & _
                   " FROM Sch_TutorialAssignment H WITH (NoLock)   " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId  " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Assignment Sheet','Tutorial Sheet') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.A_Date AS V_Date, Null AS V_No, Null AS Student    " & _
                   " FROM Sch_StudentAttendance H WITH (NoLock)   " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code  " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Attendance Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student    " & _
                   " FROM Mess_Attendance H WITH (NoLock)   " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Attendance Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student    " & _
                   " FROM Lib_Accession H WITH (NoLock)   " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Barcode Print') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student    " & _
                   " FROM Lib_Accession H WITH (NoLock)   " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Book Accession Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM PurchIndent H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Indentor=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Book Indent Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM PurchInvoice H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Vendor=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Book Purchase Invoice Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM PurchOrder H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Vendor=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Book Purchase Order Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM PurchQuotation H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Vendor=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Book Purchase Quotation Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Requisition H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.RequisitionBy=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Book Purchase Requisition Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM PurchChallan H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Vendor=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Book Receive Entry','Books Received In Donation Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Lib_BookIssue H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Member=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Books Issue Return Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM StockHead H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Books Write Off Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student  " & _
                   " FROM Exam_ConsolidatedSubjectMarks H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Consolidated Subject Marks') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Lib_DonationApp H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Member=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Donated Books Application Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Enquiry_Enquiry H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Employee=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Enquiry Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Enquiry_FollowUp H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Employee=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Enquiry Followup') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM GateInOut H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Entry','Vehicle Gate Entry','Gate Pass Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student  " & _
                   " FROM Exam_SemesterExamAdmission H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Exam Creation Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student  " & _
                   " FROM Sch_FeeDue H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Fee Due Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Store_GRN H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.AcCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('GRN Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Store_StockAdjustment H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.AcCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Item Issue Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Store_StockAdjustment H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.AcCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Item Receive Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Lib_Subscription H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Vendor=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Journals Subscription Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student  " & _
                   " FROM Sch_LabStatus H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Lab Stauts Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student  " & _
                   " FROM Sch_LabWork H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Lab Work Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Pay_Leave H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Leave Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Sch_LecturePlan H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Teacher=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Lecture Plan Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Campus_Placement H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Student=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Placement Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Store_Purchase H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.AcCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Prospectus Purchase','Purchase Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Store_Sale H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.AcCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Prospectus Sale') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student  " & _
                   " FROM Store_StockAdjustment H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Prospectus Stock Adjustment') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Store_PurchIndent H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Purchase Indent Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Store_PurchOrder H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Purchse Order Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.StudentName AS Student  " & _
                   " FROM Sch_Advance H WITH (NoLock) " & _
                   " LEFT JOIN ViewSch_Admission Sg WITH (NoLock) ON H.AdmissionDocId=Sg.DocId " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Receive Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Sch_Registration H WITH (NoLock) " & _
                   " LEFT JOIN Sch_RegistrationStudentDetail Reg WITH (NoLock) ON H.DocID=Reg.DocID " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON Reg.Student=SG.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Registration Entry','Registration Entry [Authenticated]') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM PurchChallan H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Vendor=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Journals Receive Entry (Monthly)','Journals Receive Entry (Yearly)') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Store_Requisition H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Requisition Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Ht_RoomAllotment H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Room Allotment') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student  " & _
                   " FROM Ht_ChargeDue H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Room Charge Due Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.AllotmentDate AS V_Date, Null AS V_No, Null AS Student  " & _
                   " FROM Ht_RoomTransfer H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Room Transfer') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Lib_Sale H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Buyer=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId    " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Scarp Sales Invoice Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student  " & _
                   " FROM Lib_ScrapSaleRequisition H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId    " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Scrap Sale Requisition Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Lib_SaleQuot H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Buyer=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UId    " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Scrap Sales Quotation Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student " & _
                   " FROM DuesPayment H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UID     " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Money Receipt Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, Null AS Student  " & _
                   " FROM Exam_SubjectMarks H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId    " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Subject Marks Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.A_Date AS V_Date, Null AS V_No, Null AS Student   " & _
                   " FROM Pay_DayAttendance H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code    " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Teacher Attendance') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,H.V_Date AS V_Date, H.V_No AS V_No, SG.Name AS Student  " & _
                   " FROM Ledger H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.DocId   " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Voucher Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " SG.Student AS SubCode, FR.V_Date AS V_Date, FR.V_No AS V_No, Sg.Studentname AS Student  " & _
                   " FROM Sch_FeeRefund FR WITH (NoLock) " & _
                   " LEFT JOIN ViewSch_Admission Sg WITH (NoLock) ON FR.AdmissionDocID=Sg.DocID " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=FR.DocId " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Fee Refund Entry') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Description AS Student  " & _
                   " FROM Sch_AdmissionNature H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Admission Nature Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Description AS Student  " & _
                   " FROM Item H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UID " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Book Master','Journals  Periodicals Master','Stationary Item Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Description AS Student  " & _
                   " FROM Lib_BookType H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UID " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Book Type Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, SG.Name AS Student " & _
                   " FROM Buyer H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UID " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Buyer Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Comp_Name AS Student  " & _
                   " FROM Company H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Comp_Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Company Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Div_Name AS Student  " & _
                   " FROM Division H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Div_Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Division Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, SG.Name AS Student " & _
                   " FROM Pay_Employee H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UID " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Employee Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, SG.Name AS Student " & _
                   " FROM Sch_Fee H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.Code=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Fee Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Description AS Student  " & _
                   " FROM Store_Item H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Item Master','Prospectus Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Description AS Student  " & _
                   " FROM Store_ItemCategory H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Item Category Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Description AS Student  " & _
                   " FROM Store_ItemGroup H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Item Group Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Name AS Student  " & _
                   " FROM SubGroup H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.SubCode " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Ledger Account Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, SG.Name AS Student " & _
                   " FROM Lib_Member H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.SubCode " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Member Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Description AS Student  " & _
                   " FROM Lib_MemberType H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UID " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Member Type Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Description AS Student  " & _
                   " FROM Sch_Programme H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Programme Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, Null AS Student  " & _
                   " FROM Sch_SessionProgramme H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Session Programme Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, Null AS Student  " & _
                   " FROM Exam_SemesterExam H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Semester Exam Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, Null AS Student  " & _
                   " FROM Sch_StreamYearSemesterFee H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Semester Fee Allotment') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, Null AS Student  " & _
                   " FROM Sch_SemesterSubject H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Semester Subject Allotment') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Name AS Student  " & _
                   " FROM SiteMast H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Site Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Name AS Student  " & _
                   " FROM SubGroup H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.SubCode " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Student Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_Subject H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Subject Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Name AS Student  " & _
                   " FROM SubGroup H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.SubCode " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Supplier Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Name AS Student  " & _
                   " FROM SubGroup H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.SubCode " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Teacher Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, Null AS Student  " & _
                   " FROM TT_TimeTable H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Time Table Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, H.Description AS Student  " & _
                   " FROM UserMast H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.USER_NAME " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('User Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Tp_Vehicle H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Vehicle Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, SG.Name AS Student " & _
                   " FROM Vendor H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UID " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Vendor Master','Vendor/Customer Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Voucher_Type H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.NCat " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Voucher Type Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Godown H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UID " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Almira Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,Null AS Student  " & _
                   " FROM Ht_BuildingFloor H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Building Floor Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,Null AS Student  " & _
                   " FROM Ht_Building H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Building Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Campus_Company H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Campus Company Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_Category H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Category Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Ht_ChargeGroup H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Charge Group Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,Null AS Student  " & _
                   " FROM Ht_Charge H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.SubCode " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Charge Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.CityName AS Student  " & _
                   " FROM City H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.CityCode " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('City Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_ClassRoom H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Class Room Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_Department H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Department Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_Document H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Document Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No, SG.Name AS Student " & _
                   " FROM Pay_Employee H WITH (NoLock) " & _
                   " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.SubCode=Sg.SubCode " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.SubCode " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Driver Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Exam_ExamType H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Exam Type Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Tp_Expense H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Expense Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Ht_Floor H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Floor Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Ht_Hostel H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Hostel Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_Area H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Pickup Point Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_ProgrammeNature H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Programme Nature Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Ht_Room H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Room Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Ht_RoomType H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Room Type Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_Route H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Route Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Lib_ScrapCategory H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.UID " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Scrap Category Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_Semester H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Semester Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_Session H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Session Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Event AS Student  " & _
                   " FROM Sms_Event H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Event " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('SMS Event Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_Stream H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Stream Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_SubjectGroup H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Subject Group Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_TimeSlot H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Time Slot Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Store_Unit H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Unit Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,H.Description AS Student  " & _
                   " FROM Sch_University H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('University Master') " & mCondStr & " " & _
                   " UNION ALL " & _
                   " SELECT DISTINCT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
                   " L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
                   " L.SubCode AS SubCode,Null AS V_Date, Null AS V_No,Null AS Student  " & _
                   " FROM Sch_ClassSection H WITH (NoLock) " & _
                   " LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.SessionProgramme " & _
                   " LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
                   " LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
                   " Where L.EntryPoint IN ('Section Master') " & mCondStr & " "









            '" UNION ALL " & _
            '" SELECT L.EntryPoint,convert(SMALLDATETIME,L.U_EntDt,3) as U_Entdt,L. U_Name,   " & _
            '" L.DocId,L.MachineName, Case When L.U_AE='A' then 'Add' When L.U_AE='E' then 'Edit' When L.U_AE='D' then 'Delete' When L.U_AE='P' then 'Print' When L.U_AE='V' then 'Verified' When L.U_AE='B' then 'Browse' End as U_AE, " & _
            '" L.SubCode AS SubCode,H.A_Date AS V_Date, Null AS V_No, Null AS Student   " & _
            '" FROM Sch_StudentAttendance H WITH (NoLock) " & _
            '" LEFT JOIN LogTable L WITH (NoLock) ON L.DocId=H.Code    " & _
            '" LEFT JOIN User_Target ut WITH (NoLock) ON L.U_Name=ut.UserName   " & _
            '" LEFT JOIN User_Target_Detail utd WITH (NoLock) ON ut.Code=utd.Code   " & _
            '" Where L.EntryPoint IN ('Student Attendance Entry') " & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            RepName = "UserWiseEntryActionReport" : RepTitle = "User Wise Entry Action Report"
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath_Utility)
      

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region


End Class
