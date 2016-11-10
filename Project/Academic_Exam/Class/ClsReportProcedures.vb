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
    Private Const MarkSheet As String = "MarkSheet"
    Private Const StudentsHavingMarksGreaterThanADefinedPercentage As String = "StudentsHavingMarksGreaterThanADefinedPercentage"
    Private Const StudentsHavingMarksLessThanADefinedPercentage As String = "StudentsHavingMarksLessThanADefinedPercentage"
    Private Const GAIAReport As String = "GAIAReport"   'Changed By Akash on date 4-9-10
    Private Const StatementOfMarks As String = "StatementOfMarks"   'Changed By Akash on date 22-11-10
    Private Const HallTicket As String = "HallTicket"
#End Region

#Region "Queries Definition"
    Dim mHelpCustomerQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Customer Name] From SubGroup Where Nature In ('Customer') And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpCityQry$ = "Select Convert(BIT,0) As [Select],CityCode, CityName From City "
    Dim mHelpStateQry$ = "Select Convert(BIT,0) As [Select],State_Code, State_Desc From State "
    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpEntryPointQry$ = " Select Distinct Convert(BIT,0) As [Select], User_Permission.MnuText AS code , User_Permission.MnuText As [Entry Point] From User_Permission  "
    Dim mHelpBankQry$ = "Select Convert(BIT,0) As [Select],Bank_Code Code, Bank_Name As [Bank Name] From Bank "
    Dim mHelpBankBranchQry$ = "Select Convert(BIT,0) As [Select],BankBranch_Code Code, BankBranch_Name As [Bank Branch Name] From BankBranch "
    Dim mHelpSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site/Branch Name] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "

    'Code By AKASH on date 4-10-10
    Dim mHelpCategaryQry$ = "Select Convert(BIT,0) As [Select],Code,Manualcode AS [Category Short Name], Description AS Catagory From Sch_Category "
    'End Code 
    Dim mHelpClassSectionQry$ = "Select Convert(BIT,0) As [Select],Code,ClassSectionDesc FROM ViewSch_ClassSection V Where " & AgL.PubSiteCondition("V.Site_Code", AgL.PubSiteCode) & "  "

    Dim mHelpClassSectionSubSectionQry$ = "SELECT Convert(BIT,0) As [Select], S.Code , S.SubSection As [Sub-Section], S.ClassSectionDesc As [Class/Section] " & _
                                            " FROM ViewSch_ClassSectionSubSection S " & _
                                            " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " "


    Dim mHelpStreamYearSemesterQry$ = "Select Convert(BIT,0) As [Select], Code, StreamYearSemesterDesc AS [Session Programme Stream Semester Name], SessionProgrammeStreamDesc FROM ViewSch_StreamYearSemester V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "

    Dim mHelpStudentQry$ = "Select Convert(BIT,0) As [Select], docid as code,StudentName AS [Student Name],Docid as [Admission Id] FROM	ViewSch_admission Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpSemesterQry$ = "Select Convert(BIT,0) As [Select], Code, StreamYearSemesterDesc AS [Semester Name], V.SessionProgrammeDesc , V.StreamManualCode FROM ViewSch_StreamYearSemester V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpExamQry$ = "Select Convert(BIT,0) As [Select], Code, semesterExamDesc AS [Semester Exam Name], ExamTypeDesc , ExamNature FROM ViewExam_SemesterExam V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "


    Dim mHelpToSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site/Branch Name] From SiteMast Where Code <>'" & AgL.PubSiteCode & "'"

    Dim mComboHelpExamQry$ = "Select Code, semesterExamDesc As Name FROM ViewExam_SemesterExam V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "

    'Code by Akash on date 22-11-10
    Dim mComboHelpSemesterExamQry$ = "Select Code, semesterExamDesc As Name FROM ViewExam_SemesterExam V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " And v.ExamNature='" & ExamNature_Exam & "' "
    'End Code

#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                Case MarkSheet
                    Call ObjRFG.Ini_Grp()
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpStreamYearSemesterQry$, "Semester")
                    ObjRFG.CreateHelpGrid(mHelpStudentQry$, "Student Name")
                    ObjRFG.CreateHelpGrid(mHelpExamQry$, "Exam Name")

                Case StudentsHavingMarksGreaterThanADefinedPercentage, StudentsHavingMarksLessThanADefinedPercentage
                    StrArr1 = New String() {mComboHelpExamQry}

                    If GRepFormName = StudentsHavingMarksGreaterThanADefinedPercentage Then
                        Call ObjRFG.Ini_Grp(, , , , "For Exam", StrArr1, AgL.GCn, "Marks > %")
                    ElseIf GRepFormName = StudentsHavingMarksLessThanADefinedPercentage Then
                        Call ObjRFG.Ini_Grp(, , , , "For Exam", StrArr1, AgL.GCn, "Marks < %")
                    End If


                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpStudentQry$, "Student Name")

                Case GAIAReport
                    'Code by Akash on date 5-10-10
                    StrArr1 = New String() {mComboHelpExamQry}
                    Call ObjRFG.Ini_Grp(, , , , "For Exam", StrArr1, AgL.GCn)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpStreamYearSemesterQry$, "Semester")
                    ObjRFG.CreateHelpGrid(mHelpClassSectionQry, "Class/Section")
                    ObjRFG.CreateHelpGrid(mHelpStudentQry$, "Student Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Categary")
                    'End code 

                    'Code by Akash on date 22-11-10
                Case StatementOfMarks
                    StrArr1 = New String() {mComboHelpSemesterExamQry}
                    Call ObjRFG.Ini_Grp(, , , , "For Exam", StrArr1, AgL.GCn)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpStreamYearSemesterQry$, "Semester")
                    ObjRFG.CreateHelpGrid(mHelpClassSectionQry, "Class/Section")
                    ObjRFG.CreateHelpGrid(mHelpStudentQry$, "Student Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Categary")
                    'End code 

                Case HallTicket
                    StrArr1 = New String() {mComboHelpSemesterExamQry}
                    Call ObjRFG.Ini_Grp(, , , , "For Exam", StrArr1, AgL.GCn)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpStudentQry$, "Student Name")

            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName
            Case MarkSheet
                procMarkSheet()

            Case StudentsHavingMarksGreaterThanADefinedPercentage, StudentsHavingMarksLessThanADefinedPercentage
                ProcStudentsHavingMarksGreaterThanADefinedPercentage()

            Case GAIAReport
                Call ProcGAIAReport()

            Case StatementOfMarks
                Call ProcStatementOfMarksReport()

            Case HallTicket
                Call ProcHallTicket()

        End Select
    End Sub

#Region "Mark Sheet"
    Private Sub procMarkSheet()
        Try
            Dim mCondStr$ = " Where IsNull(A.IsAttendanceMarks,0) = 0 "

            Call ObjRFG.FillGridString()

            If ObjRFG.GetWhereCondition("A.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("V2.StreamYearSemester", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("esea.AdmissionDocId ", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.SemesterExam ", 3)

            mQry = " Select A.v_date,a.V_No,a.MaxMarks,a.MinMarks,a.PreparedBy,v2.SemesterExamDesc, " & _
                        " vSYS.StreamYearSemesterdesc,V1.StudentName,  V1.AdmissionID, Sch_Subject.Description AS subject,a1.MarksObtain,a1.GraceMarks,a1.TotalMarks, " & _
                        " a1.Result, Vt.NCat, vSYS.SessionProgrammeCode, ESEA.StreamYearSemester, V2.ExamNature,v2.ExamTypeDesc,a.Remark, " & _
                        " VSYS.SessionDescription,VSYS.ProgrammeManualCode, VSYS.StreamManualCode,ViewSch_Student.DOB AS STUDENTDOB,V1.RollNo,V1.Enrollmentno " & _
                        " From Exam_SubjectMarks A " & _
                        " LEFT JOIN Exam_SubjectMarks1 a1 on a.DocId=a1.docid " & _
                        " LEFT JOIN Exam_SemesterExamAdmission1 ESEA ON a1.SemesterExamAdmission1=esea.Code " & _
                        " LEFT JOIN ViewSch_Admission V1 ON esea.AdmissionDocId = V1.DocId   " & _
                        " Left Join Voucher_Type Vt On A.V_Type = Vt.V_Type " & _
                        " Left Join ViewExam_SemesterExam V2 On A.SemesterExam = V2.Code  " & _
                        " LEFT JOIN Sch_Subject ON a.Subject=Sch_Subject.code " & _
                        " LEFT JOIN ViewSch_StreamYearSemester  vSYS ON ESEA.StreamYearSemester=VSYS.Code LEFT JOIN ViewSch_Student ON V1.Student=ViewSch_Student.SUBCODE " & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Exam_Mark_Sheet" : RepTitle = "Mark Sheet"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Exam)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Students Having Marks Greater/Less Than A Defined Percentage"
    Private Sub ProcStudentsHavingMarksGreaterThanADefinedPercentage()
        Try
            Dim mCondStr$ = "", bHavingStr$ = "", bTotalMarksPercentageStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo2_Control) Then Exit Sub

            Call ObjRFG.FillGridString()

            mCondStr = " Where M.SemesterExam = " & AgL.Chk_Text(ObjRFG.ParameterCmbo1_AgSelectedValue) & " And M.IsStudentMarksExists <> 0 "

            If ObjRFG.GetWhereCondition("M.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("M.AdmissionDocId ", 1)

            bTotalMarksPercentageStr = " (Sum(M.TotalMarks) * 100)/ Sum(M.MaxMarks) "

            If GRepFormName = StudentsHavingMarksGreaterThanADefinedPercentage Then
                bHavingStr = " Having " & bTotalMarksPercentageStr & " > " & Val(ObjRFG.ParameterCmbo2_Value) & " "
            ElseIf GRepFormName = StudentsHavingMarksLessThanADefinedPercentage Then
                bHavingStr = " Having " & bTotalMarksPercentageStr & " < " & Val(ObjRFG.ParameterCmbo2_Value) & " "
            End If

            mQry = "SELECT  Row_number() OVER (ORDER BY " & bTotalMarksPercentageStr & IIf(GRepFormName = StudentsHavingMarksGreaterThanADefinedPercentage, "Desc", "") & ") AS SrlNo, M.AdmissionDocId, Max(M.StudentName) AS StudentName, Max(M.StudentDispName) AS StudentDispName, " & _
                    " Max(M.FatherName) AS FatherName, Max(M.MotherName) AS MotherName , Max(M.AdmissionID) AS AdmissionID , Max(M.RollNo) AS RollNo , Max(M.EnrollmentNo) AS EnrollmentNo, " & _
                    " Max(M.SemesterExam)  AS SemesterExamCode, Max(M.StreamYearSemesterCode) AS StreamYearSemesterCode, Max(M.Site_Code) AS Site_Code , Max(M.Div_Code) AS Div_Code , Max(M.ExamTypeDesc) AS ExamTypeDesc , Max(M.ExamNature) AS ExamNature , " & _
                    " Max(M.StreamYearSemesterDesc) AS StreamYearSemesterDesc , Max(M.SemesterExamDesc) AS SemesterExamDesc ,  " & _
                    " Sum(M.TotalMarks) AS TotalMarks, Sum(M.MarksObtain) AS MarksObtain, Sum(M.GraceMarks) AS GraceMarks, Sum(M.MaxMarks) AS MaxMarks, Sum(M.MinMarks) AS MinMarks, " & _
                    " " & bTotalMarksPercentageStr & " AS TotalMarksPer, '" & AgL.PubUserName.ToUpper & "' As PrintedBy " & _
                    " FROM ViewExam_AdmissionSubjectMarks M " & _
                    " " & mCondStr & " GROUP BY M.AdmissionDocId " & bHavingStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Exam_StudentsMarksGreaterOrLessThanADefinedPer"
            If GRepFormName = StudentsHavingMarksGreaterThanADefinedPercentage Then
                RepTitle = "List Of Students Having Marks > " & Val(ObjRFG.ParameterCmbo2_Value) & "%"
            ElseIf GRepFormName = StudentsHavingMarksLessThanADefinedPercentage Then
                RepTitle = "List Of Students Having Marks < " & Val(ObjRFG.ParameterCmbo2_Value) & "%"
            End If
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Exam)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region


#Region "GAIA REPORT" 'Code Start By AKASH On date 4-10-10
    Private Sub ProcGAIAReport()
        Try
            Dim mCondStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            mCondStr = " Where Asm.SemesterExam = " & AgL.Chk_Text(ObjRFG.ParameterCmbo1_AgSelectedValue) & " And " & _
                        " Asm.SubjectType='Theory' AND isnull(Asm.IsStudentMarksExists, 0) <> 0 "

            If ObjRFG.GetWhereCondition("Asm.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Asm.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Asm.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Asm.StreamYearSemesterCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ap.ClassSectionCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Asm..AdmissionDocId ", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Category ", 4)

            mQry = "SELECT Asm.Site_Code, Sm.Name As Site_Name, Asm.StreamManualCode, Asm.StreamYearSemesterDesc AS Semester,  " & _
                    " Asm.SessionManualCode, Ses.Description AS SessionYear, Asm.AdmissionDocId,  Asm.StudentName, Asm.StudentDispName, " & _
                    " Asm.StudentManualCode, Asm.FatherName, Asm.MotherName, Asm.AdmissionID, Asm.RollNo, Asm.EnrollmentNo,  " & _
                    " Asm.SubjectDesc, Asm.SubjectManualCode,  Asm.SubjectType, Asm.MaxMarks, Asm.MinMarks, Asm.MarksObtain, " & _
                    " Asm.GraceMarks, Asm.TotalMarks, Asm.ExamTypeDesc, " & _
                    " Asm.Result, Ap.Section, S.Category AS CategoryCode, S.CategoryManualCode, " & _
                    " Ap.ClassSectionDesc, Ap.ClassSectionCode, Asm.SemesterExam As SemesterExamCode, Asm.SemesterExamDesc, " & _
                    " Case Asm.Result When '" & ResultStr_Fail & "' Then 1 Else 0 End As ResultIsFail, " & _
                    " Case Asm.Result When '" & ResultStr_Pass & "' Then 1 WHEN '" & ResultStr_PassWithGrace & "'  THEN 1 Else 0 End As ResultIsPass, " & _
                    " IsNull(Asm.PresentStatus,'') As PresentStatus " & _
                    " FROM ViewExam_AdmissionSubjectMarks Asm " & _
                    " Left Join SiteMast Sm On Asm.Site_Code = Sm.Code " & _
                    " LEFT JOIN ViewSch_ClassSectionSemesterAdmission Ap ON Asm.AdmissionDocId=Ap.AdmissionDocId AND Asm.StreamYearSemesterCode=Ap.StreamYearSemester " & _
                    " LEFT JOIN ViewSch_Admission A ON Asm.AdmissionDocId=A.DocId " & _
                    " LEFT JOIN ViewSch_Student S ON A.Student=S.SubCode " & _
                    " LEFT JOIN Sch_Session Ses On Asm.SessionCode = Ses.Code " & _
                    " " & mCondStr & " "
            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Exam_GAIAReport" : RepTitle = "GAIA Report"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Exam)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region 'Code End By AKASH On date 4-10-10

#Region "Statement Of Marks " 'Code Start By AKASH On date 9-10-10
    Private Sub ProcStatementOfMarksReport()
        Try
            Dim mCondStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            mCondStr = " Where asm.SemesterExam = " & AgL.Chk_Text(ObjRFG.ParameterCmbo1_AgSelectedValue) & "  " & _
                        " And Vas.SubjectCode is not null "

            If ObjRFG.GetWhereCondition("Asm.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("asm.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("asm.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("asm.StreamYearSemesterCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ap.ClassSectionCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("asm..AdmissionDocId ", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Category ", 4)

            mQry = "SELECT asm.StudentName, asm.StudentDispName, asm.StudentManualCode, asm.FatherName, asm.MotherName, " & _
                    " asm.AdmissionID, asm.RollNo, asm.EnrollmentNo, asm.SemesterExamAdmission1, asm.AdmissionDocId, " & _
                    " asm.SemesterExam, asm.SemesterExamAdmissionDocId, asm.StreamYearSemesterCode, asm.ExamType, " & _
                    " asm.Div_Code, asm.Site_Code, asm.ExamTypeDesc, asm.ExamNature, asm.SemesterExamDesc, " & _
                    " asm.SessionProgrammeCode, asm.SessionManualCode, asm.ProgrammeManualCode, asm.StreamManualCode, " & _
                    " asm.StreamCode, asm.SessionCode, asm.ProgrammeCode, asm.SessionProgrammeStreamYear, asm.StreamYearSemesterDesc, " & _
                    " asm.SubjectCode, asm.SubjectDesc, asm.SubjectDisplayName, asm.SubjectType, asm.SubjectManualCode, " & _
                    " asm.Exam_MinMarks, asm.Test_MaxMarks, asm.Test_MinMarks, asm.Assignment_MaxMarks, " & _
                    " asm.Assignment_MinMarks, asm.Attendance_MaxMarks, asm.Attendance_MinMarks, asm.Total_MaxMarks, " & _
                    " asm.Total_MinMarks, asm.MaxMarks, asm.MinMarks, asm.MarksObtain, asm.GraceMarks, " & _
                    " asm.Result, asm.IsSubjectMarksExists, asm.IsStudentMarksExists, s.Category, " & _
                    " Ap.ClassSectionDesc, Ap.ClassSectionCode, " & _
                    " asam.TotalMarks AS AttendenceMarks, " & _
                    " v2.TotalMarks AS TotalTestObtainMarks, " & _
                    " v3.TotalMarks AS TotalAssignmentObtainMarks, " & _
                    " (asm.Total_MaxMarks-asm.Exam_MaxMarks) AS SessionalMaxMarks, " & _
                    " asm.Exam_MaxMarks,asm.Total_MaxMarks, " & _
                    " (isnull(asam.totalMarks,0) + isnull(v2.TotalMarks,0) + isnull(v3.TotalMarks,0)) AS SessionalObtainMarks, " & _
                    " asm.TotalMarks AS ExamObtainMarks, " & _
                    " (isnull(asam.totalMarks,0) + isnull(v2.TotalMarks,0) + isnull(v3.TotalMarks,0) +isnull(asm.TotalMarks,0)) AS TotalObtainMarks ,vas.SubjectCode , " & _
                    " S.EMail, S.SubCode as [StudentCode]  " & _
                    " FROM ViewExam_AdmissionSubjectMarks asm " & _
                    " LEFT JOIN ViewExam_AdmissionSubjectAttendanceMarks asam " & _
                    " ON asm.SemesterExamAdmission1=asam.SemesterExamAdmission1  " & _
                    " AND asm.SubjectCode=asam.SubjectCode " & _
                    " Left Join  " & _
                    " 	    (SELECT csm.Subject,csm2.SemesterExamAdmission1,csm2.TotalMarks " & _
                    " 	    FROM Exam_ConsolidatedSubjectMarks csm " & _
                    " 	    LEFT JOIN Exam_ConsolidatedSubjectMarks2 csm2 " & _
                    " 	    ON csm.DocId=csm2.DocId " & _
                    " 	    WHERE csm.SubExamNature='" & ExamNature_Test & "') AS V2  " & _
                    " ON asm.SemesterExamAdmission1=v2.SemesterExamAdmission1 AND asm.SubjectCode=v2.Subject " & _
                    " Left Join  " & _
                    " 	    (SELECT csm.Subject,csm2.SemesterExamAdmission1,csm2.TotalMarks " & _
                    " 	    FROM Exam_ConsolidatedSubjectMarks csm " & _
                    " 	    LEFT JOIN Exam_ConsolidatedSubjectMarks2 csm2 " & _
                    " 	    ON csm.DocId=csm2.DocId " & _
                    " 	    WHERE csm.SubExamNature='" & ExamNature_Assignment & "') AS V3 " & _
                    " ON asm.SemesterExamAdmission1=v3.SemesterExamAdmission1 AND asm.SubjectCode=v3.Subject " & _
                    " LEFT JOIN ViewSch_Admission A ON asm.AdmissionDocId=A.DocId  " & _
                    " LEFT JOIN ViewSch_Student S ON A.Student=S.SubCode " & _
                    " LEFT JOIN ViewSch_AdmissionPromotion Ap ON asm.AdmissionDocId=Ap.AdmissionDocId " & _
                    " AND asm.StreamYearSemesterCode=Ap.FromStreamYearSemester " & _
                    " LEFT JOIN ViewSch_AdmissionSubject vas ON asm.AdmissionDocId=vas.AdmissionDocId " & _
                    " AND asm.StreamYearSemesterCode=vas.StreamYearSemester AND asm.Subjectcode=vas.SubjectCode " & _
                    " " & mCondStr & " "


            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Exam_StatementOfMarks" : RepTitle = "Statement Of Marks"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            'Code By Akash on date 1-12-10
            'Dim FrmObj As Form
            'FrmObj = New FrmAutoMail()
            'If FrmObj IsNot Nothing Then
            '    CType(FrmObj, FrmAutoMail).DsMarksheets = DsRep
            'End If
            'FrmObj.MdiParent = ObjRFG.MdiParent
            'FrmObj.Show()
            'End Code


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Exam)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region 'Code End By AKASH On date 4-10-10


#Region "Hall Ticket"
    Private Sub ProcHallTicket()
        Try
            Dim mCondStr$ = ""

            Call ObjRFG.FillGridString()

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            mCondStr = " Where H.SemesterExam = " & AgL.Chk_Text(ObjRFG.ParameterCmbo1_AgSelectedValue) & "  " & _
                        " AND AdmSub.AdmissionDocId  IS NOT Null "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.AdmissionDocId ", 1)

            mQry = "SELECT H.DocId AS SearchCode, H.Site_Code, " & _
                    " H.V_Date As ExamCreationVDate, H.SemesterExam, H.TotalStudent, H.Remark, " & _
                    " L.Code, L.AdmissionDocId, A.Student AS StudentCode, " & _
                    " Sg.Name AS StudentName, Sg.DispName AS StudentDispName,  " & _
                    " Sg.ManualCode AS StudentManualCode, " & _
                    " Sg.FatherName, Sg.MotherName, Sg.Sex, Sg.DOB,  " & _
                    " Sg.Phone, Sg.Mobile, Sg.EMail, Sg.Add1, Sg.Add2, Sg.Add3, Sg.PIN, C.CityName, " & _
                    " AdmSub.SubjectManualCode, AdmSub.PaperID, AdmSub.SubjectDesc, AdmSub.SubjectDisplayName, AdmSub.IsElectiveSubject, AdmSub.SubjectType,  " & _
                    " Et.Description AS ExamTypeDesc, Et.ExamNature, " & _
                    " Sem.StreamYearSemesterDesc, Sem.SessionManualCode, Sem.StreamManualCode, Sem.ProgrammeManualCode, Sem.SemesterDesc, " & _
                    " A.AdmissionID, A.Status, ENo.EnrollmentNo, Rno.RollNo, " & _
                    " Sm.ManualCode AS SiteManualCode, Sm.Name AS SiteName, Sm.Photo AS SiteLogo, " & _
                    " SgI.Photo AS StudentPhoto " & _
                    " FROM (Exam_SemesterExamAdmission H WITH (NoLock) " & _
                    " INNER JOIN dbo.Exam_SemesterExamAdmission1 L WITH (NoLock) ON L.DocId = H.DocId) " & _
                    " LEFT JOIN SiteMast AS Sm WITH (NoLock) ON Sm.Code = H.Site_Code  " & _
                    " LEFT JOIN Exam_SemesterExam SemExam WITH (NoLock) ON SemExam.Code = H.SemesterExam  " & _
                    " LEFT JOIN Exam_SemesterExam1 SemExam1 WITH (NoLock) ON SemExam1.Code = SemExam.Code  " & _
                    " LEFT JOIN Sch_Admission A WITH (NoLock) ON A.DocId = L.AdmissionDocId  " & _
                    " LEFT JOIN ViewSch_AdmissionSubject AdmSub WITH (NoLock) ON AdmSub.AdmissionDocId = A.DocId AND AdmSub.StreamYearSemester = L.StreamYearSemester AND AdmSub.SubjectCode = SemExam1.Subject  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem WITH (NoLock) ON L.StreamYearSemester = Sem.Code  " & _
                    " LEFT JOIN Exam_ExamType Et WITH (NoLock) ON Et.Code = SemExam.ExamType  " & _
                    " LEFT JOIN Sch_Student S WITH (NoLock) ON S.SubCode = A.Student  " & _
                    " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = S.SubCode  " & _
                    " LEFT JOIN City C WITH (NoLock) ON C.CityCode = Sg.CityCode  " & _
                    " LEFT JOIN Sch_AdmissionEnrollmentNo ENo  WITH (NoLock) ON ENo.DocId = A.DocId " & _
                    " LEFT JOIN Sch_AdmissionRollNo RNo WITH (NoLock) ON RNo.DocId = A.DocId " & _
                    " LEFT JOIN SubGroup_Image SgI ON SgI.SubCode = Sg.SubCode  "

            mQry = mQry & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GcnRead)

            RepName = "Exam_HallTicket" : RepTitle = "Hall Ticket"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region 'Code End By AKASH On date 4-10-10

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub
End Class

