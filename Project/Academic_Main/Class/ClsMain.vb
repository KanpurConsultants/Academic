Imports System.Data.SqlClient

Public Class ClsMain
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Academic Main"

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain, ByVal PLibVar As Academic_ProjLib.ClsMain)
        AgL = AgLibVar
        PLib = PLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        PObj = New Academic_Objects.ClsMain(AgL, PLib)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)

        Call IniDtEnviro()
    End Sub

    Class Temp_NCat
        Public Const TutorialSheet As String = "TSEET"
        Public Const AssignmentSheet As String = "ASEET"
        Public Const AcademicProgressTheory As String = "APT"
        Public Const AcademicProgressLaboratory As String = "APL"
        Public Const LecturePlan As String = "LPLN"
        Public Const LabStatus As String = "LSTS"
        Public Const LabWork As String = "LWORK"
    End Class

    Class EnquiryStatus
        Public Const NewEnquiry As String = "New"
        Public Const FollowUp As String = "Follow Up"
        Public Const Closed As String = "Closed"
    End Class

    Class SubjectType
        Public Const Theory As String = "Theory"
        Public Const Practical As String = "Practical"
    End Class
    Class MemberType
        Public Const Student As String = "Student"
        Public Const Employee As String = "Employee"
    End Class

    Class SmsEvent
        Public Const BirthDay_Student As String = "Student Birthday"
        Public Const BirthDay_Employee As String = "Employee Birthday"
        Public Const MarriageAnniversary_Employee As String = "Employee Marriage Anniversary "
        Public Const StudentAdmission As String = "Student Admission"
        Public Const StudentRegistration As String = "Student Registration"
        Public Const StudentAttendance As String = "Student Attendance"
        Public Const StudentLeave As String = "Student Leave"
    End Class

    Public Enum eAcademicProgressType
        Theory
        Laboratory
    End Enum

#Region "Update Table Structure"
    Public Sub UpdateTableStructure(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        Try
            Call CreateDatabase(MdlTable)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub UpdateTableStructure()
        Try

            Call AddNewTable()

            Call AddNewField()

            Call DeleteField()

            Call EditField()

            Call CreateVType()

            Call AddNewVoucherReference()

            Call CreateFunction()

            Call CreateView()

            Call InitializeTables()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub InitializeTables()
        TB_Experiment()
        TB_SMS_Event()
        TB_Sch_LabWork1()

    End Sub
    Private Sub TB_Experiment()
        Dim mQry As String = ""
        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Dim bIntI% = 0
        Dim bStrField$ = ""
        Try
            If AgL.IsTableExist("Sch_Experiment", AgL.GCn) Then
                For bIntI = 1 To 10
                    bStrField = "Experiment" + Space(1) + bIntI.ToString

                    mQry = "If Not EXISTS(SELECT * FROM Sch_Experiment WHERE Code = '" & bStrField & "') " & _
                                " INSERT INTO dbo.Sch_Experiment (Code) VALUES ('" & bStrField & "')"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TB_Sch_LabWork1()
        Dim mQry As String = ""
        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Try
            If AgL.IsTableExist("Sch_LabWork1", AgL.GCn) Then
                mQry = " If EXISTS( SELECT H.DocId FROM Sch_LabWork H WITH (NoLock) " & _
                       " LEFT JOIN Sch_LabWork1 L WITH (NOLock) ON L.DocId = H.DocId " & _
                       "WHERE L.DocId IS NULL  )" & _
                       "INSERT INTO dbo.Sch_LabWork1  (DocId, Sr, Student,AdmissionDocId,Experiment,PerformedDate,SubmissionDate,StreamYearSemester,Session,Programme,Stream,Semester,Year) " & _
                       " SELECT S.DocId, 1, S.Student,S.AdmissionDocId,S.Experiment,S.V_Date,S.SubmissionDate,S.StreamYearSemester ,S.Session,S.Programme,S.Stream,S.Semester,S.Year " & _
                       " FROM Sch_LabWork S With (NoLock) LEFT JOIN Sch_LabWork1 W WITH (NOLock) ON W.DocId = S.DocId WHERE W.DocId IS NULL  "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TB_SMS_Event()
        Dim mQry As String = ""
        '' Note Write Each Table Query in Separate <Try---Catch> Section
        Dim bIntI% = 0
        Try
            If AgL.IsTableExist("SMS_Event", AgL.GCn) Then
                mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.BirthDay_Student & "') " & _
                            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.BirthDay_Student & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.BirthDay_Employee & "') " & _
                            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.BirthDay_Employee & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.StudentAdmission & "') " & _
                            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.StudentAdmission & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.StudentRegistration & "') " & _
                            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.StudentRegistration & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.StudentAttendance & "') " & _
                            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.StudentAttendance & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.StudentLeave & "') " & _
                            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.StudentLeave & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.MarriageAnniversary_Employee & "') " & _
                            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.MarriageAnniversary_Employee & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                'mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.FeeDue & "') " & _
                '            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.FeeDue & "')"
                'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                'mQry = "If Not EXISTS(SELECT * FROM SMS_Event WHERE Event = '" & SmsEvent.FeeReceive & "') " & _
                '            " INSERT INTO dbo.SMS_Event (Event) VALUES ('" & SmsEvent.FeeReceive & "')"
                'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub AddNewField()
        Dim mQry$ = ""
        Try
            ''============================< Sch_SessionProgramme >==================================================
            'If AgL.AddNewField(AgL.GCn, "Sch_SessionProgramme", "Description", "nvarchar(50)") Then
            '    mQry = "UPDATE Sch_SessionProgramme SET " & _
            '            " Sch_SessionProgramme.Description = v.Description " & _
            '            " FROM ( " & _
            '            " 	SELECT  SP.Code, P.ManualCode  +'/' + S.ManualCode AS Description   " & _
            '            " 	FROM Sch_SessionProgramme SP WITH (NoLock)  " & _
            '            " 	INNER JOIN Sch_Session S  WITH (NoLock) ON sp.Session =S.Code    " & _
            '            " 	INNER JOIN Sch_Programme P  WITH (NoLock) ON SP.Programme =P.Code   " & _
            '            " 	) AS v " & _
            '            " WHERE Sch_SessionProgramme.Code = v.Code	 " & _
            '            " And IsNull(Sch_SessionProgramme.Description) = '' "
            '    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            'End If
            ''============================< ************************** >==================================================

            ''============================< Sch_SessionProgrammeStream >==================================================
            AgL.AddNewField(AgL.GCn, "Sch_SessionProgrammeStream", "SeatsForRegistration", "int", 0, False)
            'If AgL.AddNewField(AgL.GCn, "Sch_SessionProgrammeStream", "Description", "nvarchar(100)") Then
            '    'UPDATE Sch_SessionProgrammeStream SET 
            '    'Sch_SessionProgrammeStream.Description = V.Description
            '    'FROM (
            '    '	SELECT Sps.Code, P.ManualCode + '/' +  S.ManualCode + '/' +  St.ManualCode AS Description 
            '    '	FROM Sch_SessionProgrammeStream SPS WITH (NoLock) 
            '    '	LEFT JOIN Sch_SessionProgramme Sp  WITH (NoLock) ON SP.Code = SPS.SessionProgramme   
            '    '	LEFT JOIN Sch_Session S  WITH (NoLock) ON SP.Session =S.Code   
            '    '	LEFT JOIN Sch_Programme P  WITH (NoLock) ON SP.Programme =P.Code  
            '    '	LEFT JOIN Sch_Stream St  WITH (NoLock) ON SPS.Stream =St.Code 
            '    '	) AS v
            '    'WHERE Sch_SessionProgrammeStream.Code = V.Code
            '    'AND IsNull(Sch_SessionProgrammeStream.Description,'') = ''
            'End If
            ''============================< ************************** >==================================================

            ''============================< Sch_StreamYearSemester >==================================================
            'If AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "Description", "nvarchar(255)") Then

            'End If

            'If AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "Site_Code", "nvarchar(2)") Then
            '    mQry = "UPDATE Sch_StreamYearSemester " & _
            '            " SET Sch_StreamYearSemester.Site_Code = V.Site_Code " & _
            '            " FROM ( " & _
            '            " 	SELECT Sem.Code, Sp.Site_Code, Sp.Div_Code  " & _
            '            " 	FROM Sch_StreamYearSemester Sem " & _
            '            " 	INNER JOIN Sch_SessionProgrammeStreamYear Yr ON Yr.Code = Sem.SessionProgrammeStreamYear  " & _
            '            " 	INNER JOIN Sch_SessionProgrammeStream Stream ON Stream.Code = Yr.SessionProgrammeStream  " & _
            '            " 	INNER JOIN Sch_SessionProgramme Sp ON Sp.Code = Stream.SessionProgramme  " & _
            '            " ) AS V " & _
            '            " WHERE Sch_StreamYearSemester.Code = V.Code "
            '    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            'End If
            'If AgL.IsFieldExist("Site_Code", "Sch_StreamYearSemester", AgL.GCn) Then
            '    AgL.AddForeignKey(AgL.GCn, "FK_Sch_StreamYearSemester_Site_Code", "SiteMast", "Sch_StreamYearSemester", "Code", "Site_Code")
            'End If

            'If AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "Div_Code", "nvarchar(1)") Then
            '    mQry = "UPDATE Sch_StreamYearSemester " & _
            '            " SET Sch_StreamYearSemester.Div_Code = V.Div_Code " & _
            '            " FROM ( " & _
            '            " 	SELECT Sem.Code, Sp.Site_Code, Sp.Div_Code  " & _
            '            " 	FROM Sch_StreamYearSemester Sem " & _
            '            " 	INNER JOIN Sch_SessionProgrammeStreamYear Yr ON Yr.Code = Sem.SessionProgrammeStreamYear  " & _
            '            " 	INNER JOIN Sch_SessionProgrammeStream Stream ON Stream.Code = Yr.SessionProgrammeStream  " & _
            '            " 	INNER JOIN Sch_SessionProgramme Sp ON Sp.Code = Stream.SessionProgramme  " & _
            '            " ) AS V " & _
            '            " WHERE Sch_StreamYearSemester.Code = V.Code "
            '    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            'End If

            'AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "PreparedBy", "nVarChar(10)")
            'AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "U_EntDt", "DATETIME")
            'AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "U_AE", "nVarChar(1)")
            'AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "Edit_Date", "DATETIME")
            'AgL.AddNewField(AgL.GCn, "Sch_StreamYearSemester", "ModifiedBy", "nVarChar(10)")
            ''============================< ************************** >==================================================

            ''============================< Sch_AdmissionDocument >==================================================
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionDocument", "BlobSr", "int")
            ''============================< ************************** >==================================================

            ''============================< Pay_Employee >==================================================
            If AgL.AddNewField(AgL.GCn, "Pay_Employee", "MasterType", "nVarChar(20)") Then
                mQry = "UPDATE Pay_Employee " & _
                        " SET MasterType = '" & Academic_ProjLib.ClsMain.MasterType.Teacher & "' " & _
                        " WHERE IsNull(IsTeachingStaff,0) <> 0 " & _
                        " AND MasterType IS NULL "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            AgL.AddNewField(AgL.GCn, "Pay_Employee", "MotherName", "nVarChar(100)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "Designation", "nVarChar(50)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "Shift", "nVarChar(20)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "AppointmentType", "nVarChar(20)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "SalaryMode", "nVarChar(4)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "PayScale", "nVarChar(20)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "Programme", "nVarChar(8)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "Title", "nVarChar(8)")
            If AgL.IsFieldExist("Programme", "Pay_Employee", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Programme_Programme", "Sch_Programme", "Pay_Employee", "Code", "Programme")
            End If

            AgL.AddNewField(AgL.GCn, "Pay_Employee", "Stream", "nVarChar(8)")
            If AgL.IsFieldExist("Stream", "Pay_Employee", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Pay_Employee_Stream", "Sch_Stream", "Pay_Employee", "Code", "Stream")
            End If

            AgL.AddNewField(AgL.GCn, "Pay_Employee", "ProgrammeNature", "nVarChar(8)")
            If AgL.IsFieldExist("ProgrammeNature", "Pay_Employee", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Pay_Employee_ProgrammeNature", "Sch_ProgrammeNature", "Pay_Employee", "Code", "ProgrammeNature")
            End If

            AgL.AddNewField(AgL.GCn, "Pay_Employee", "WorkExperience", "float", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TeachingExperience", "float", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "ResearchExperience", "float", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "IndustryExperience", "float", 0, False)

            AgL.AddNewField(AgL.GCn, "Pay_Employee", "BankAcNo", "nVarChar(20)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "BankName", "nVarChar(100)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "BankBranch", "nVarChar(100)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "IfscCode", "nVarChar(20)")

            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalPGProjectsGuided", "int", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalDoctorateProjectsGuided", "int", 0, False)

            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalBooksPublished", "int", 0, False)

            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalPapersPublishedInNationalJournals", "int", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalPapersPublishedInInternationalJournals", "int", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalInternationalConferencesAttended", "int", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalNationalConferencesAttended", "int", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalPapersInNationalConference", "int", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalPapersInInternationalConference", "int", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalShortTermCoursesAttended", "int", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalWorkshopsAttended", "int", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "TotalSeminarsAttended", "int", 0, False)

            AgL.AddNewField(AgL.GCn, "Pay_Employee", "IsCommonSubjectTeacher", "bit", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "IsCommonSubjectBeingTaught", "bit", 0, False)
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "CommonSubject", "nVarChar(100)")
            AgL.AddNewField(AgL.GCn, "Pay_Employee", "CanTakeClass", "bit", 0, False)            
            ''============================< ************************* >=====================================
            ''================================<< SubGroup >>====================================================================
            AgL.AddNewField(AgL.GCn, "SubGroup", "LogInUser", "nVarChar(10)")
            AgL.AddNewField(AgL.GCn, "SubGroup", "MotherName", "nVarChar(100)")
            AgL.AddNewField(AgL.GCn, "SubGroup", "Sex", "nVarChar(6)")
            AgL.AddNewField(AgL.GCn, "SubGroup", "MarriageDate", "SmallDateTime")
            AgL.AddNewField(AgL.GCn, "SubGroup", "AttendanceCode", "nVarChar(20)")

            AgL.AddNewField(AgL.GCn, "SubGroup", "ManualCodePrefix", "nVarChar(20)")
            AgL.AddNewField(AgL.GCn, "SubGroup", "ManualCodeSr", "int", 0)


            If AgL.IsTableExist("SubGroup_Log", AgL.GCn) Then
                AgL.AddNewField(AgL.GCn, "SubGroup_Log", "LogInUser", "nVarChar(10)")
                AgL.AddNewField(AgL.GCn, "SubGroup_Log", "MotherName", "nVarChar(100)")
                AgL.AddNewField(AgL.GCn, "SubGroup_Log", "Sex", "nVarChar(6)")
                AgL.AddNewField(AgL.GCn, "SubGroup_Log", "MarriageDate", "SmallDateTime")
                AgL.AddNewField(AgL.GCn, "SubGroup_Log", "AttendanceCode", "nVarChar(20)")
            End If

            If AgL.IsFieldExist("MotherName", "SubGroup", AgL.GCn) _
                And AgL.IsFieldExist("Sex", "SubGroup", AgL.GCn) Then

                mQry = "Update SubGroup Set " & _
                        " SubGroup.MotherName = Sch_Student.MotherName, " & _
                        " SubGroup.Sex = Sch_Student.Sex " & _
                        " From Sch_Student " & _
                        " Where SubGroup.SubCode = Sch_Student.SubCode "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)


                mQry = "Update SubGroup Set " & _
                        " SubGroup.MotherName = Pay_Employee.MotherName, " & _
                        " SubGroup.Sex = Pay_Employee.Sex " & _
                        " From Pay_Employee " & _
                        " Where SubGroup.SubCode = Pay_Employee.SubCode "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                If AgL.IsTableExist("SubGroup_Log", AgL.GCn) Then
                    mQry = "Update SubGroup_Log Set " & _
                            " SubGroup_Log.MotherName = Sch_Student.MotherName, " & _
                            " SubGroup_Log.Sex = Sch_Student.Sex " & _
                            " From Sch_Student " & _
                            " Where SubGroup_Log.SubCode = Sch_Student.SubCode "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    mQry = "Update SubGroup_Log Set " & _
                            " SubGroup_Log.MotherName = Pay_Employee.MotherName, " & _
                            " SubGroup_Log.Sex = Pay_Employee.Sex " & _
                            " From Pay_Employee " & _
                            " Where SubGroup_Log.SubCode = Pay_Employee.SubCode "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                End If
            End If

            AgL.AddNewField(AgL.GCn, "SubGroup", "ManualCodePrefix", "nVarChar(12)")
            AgL.AddNewField(AgL.GCn, "SubGroup", "ManualCodeSr", "int", 0)
            ''============================<< ******SubGroup_Log****** >>================================================================
            AgL.AddNewField(AgL.GCn, "SubGroup_Log", "ManualCodePrefix", "nVarChar(12)")
            AgL.AddNewField(AgL.GCn, "SubGroup_Log", "ManualCodeSr", "int", 0)

            ''============================<< ************ >>================================================================

            ''============================< Pay_EmployeeAcademicDetail >====================================
            AgL.AddNewField(AgL.GCn, "Pay_EmployeeAcademicDetail", "Learning", "nVarChar(20)")
            AgL.AddNewField(AgL.GCn, "Pay_EmployeeAcademicDetail", "Specialization", "nVarChar(100)")
            AgL.AddNewField(AgL.GCn, "Pay_EmployeeAcademicDetail", "Institute", "nVarChar(100)")
            ''============================< ************************* >=====================================

            ''============================< Sch_Subject >===================================================
            AgL.AddNewField(AgL.GCn, "Sch_Subject", "IsGeneralProficiency", "bit", 0, False)
            ''============================< ************************* >=====================================

            ''============================< Sch_Student >=====================================
            AgL.AddNewField(AgL.GCn, "Sch_Student", "LocalGuardian", "nVarChar(100)")
            If AgL.AddNewField(AgL.GCn, "Sch_Student", "FatherIncome", "Float", 0, False) Then
                AgL.Dman_ExecuteNonQry("Update Sch_Student Set FatherIncome = IsNull(FamilyIncome,0) ", AgL.GCn)
                AgL.Dman_ExecuteNonQry("Update Sch_Student Set FamilyIncome = IsNull(FatherIncome,0) + IsNull(MotherIncome,0) ", AgL.GCn)
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_Registration >=====================================
            AgL.AddNewField(AgL.GCn, "Sch_Registration", "Rank_No", "NUMERIC")
            AgL.AddNewField(AgL.GCn, "Sch_Registration", "RankRemark", "NVARCHAR(100)")
            AgL.AddNewField(AgL.GCn, "Sch_Registration", "RollNo", "NVARCHAR(25)")

            AgL.AddNewField(AgL.GCn, "Sch_Registration", "Rank_No2", "NUMERIC")
            AgL.AddNewField(AgL.GCn, "Sch_Registration", "RankRemark2", "NVARCHAR(100)")
            AgL.AddNewField(AgL.GCn, "Sch_Registration", "RollNo2", "NVARCHAR(25)")

            AgL.AddNewField(AgL.GCn, "Sch_Registration", "ManualRegNo", "NVARCHAR(25)")
            AgL.AddNewField(AgL.GCn, "Sch_Registration", "RankMarks1", "float", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_Registration", "RankMarks2", "float", 0, False)


            AgL.AddNewField(AgL.GCn, "Sch_Registration", "RankMaxMarks1", "float", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_Registration", "RankMaxMarks2", "float", 0, False)

            If AgL.AddNewField(AgL.GCn, "Sch_Registration", "IsAutoApproved", "bit", 0, False) Then
                mQry = "UPDATE Sch_Registration " & _
                        " SET " & _
                        " ApprovedBy = CASE WHEN Edit_Date IS NULL THEN PreparedBy ELSE ModifiedBy END, " & _
                        " ApprovedDate = CASE WHEN Edit_Date IS NULL THEN U_EntDt ELSE Edit_Date END, " & _
                        " IsAutoApproved = 1 " & _
                        " WHERE ApprovedDate IS NULL "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            If AgL.IsTableExist("Enquiry_Enquiry", AgL.GCn) Then
                AgL.AddNewField(AgL.GCn, "Sch_Registration", "EnquiryDocId", "nVarChar(21)")
                If AgL.IsFieldExist("EnquiryDocId", "Sch_Registration", AgL.GCn) Then
                    AgL.AddForeignKey(AgL.GCn, "FK_Sch_Registration_EnquiryDocId", "Enquiry_Enquiry", "Sch_Registration", "DocId", "EnquiryDocId")
                End If
            End If
            ''============================< ************************* >=====================================


            ''============================< Sch_RegistrationPaymentDetail >============================================
            AgL.DeleteForeignKey(AgL.GCn, "FK_Sch_RegistrationPaymentDetail_PaymentDetail", "Sch_RegistrationPaymentDetail")

            AgL.AddNewField(AgL.GCn, "Sch_RegistrationPaymentDetail", "PaymentDocId", "NVARCHAR(21)")
            If AgL.IsFieldExist("Sch_RegistrationPaymentDetail", "PaymentDocId", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_RegistrationPaymentDetail_PaymentDocId", "PaymentDetail", "Sch_RegistrationPaymentDetail", "DocId", "PaymentDocId")
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_RegistrationCancel >============================================
            If AgL.AddNewField(AgL.GCn, "Sch_RegistrationCancel", "IsAutoApproved", "bit", 0, False) Then
                mQry = "UPDATE Sch_RegistrationCancel " & _
                        " SET " & _
                        " ApprovedBy = CASE WHEN Edit_Date IS NULL THEN PreparedBy ELSE ModifiedBy END, " & _
                        " ApprovedDate = CASE WHEN Edit_Date IS NULL THEN U_EntDt ELSE Edit_Date END, " & _
                        " IsAutoApproved = 1 " & _
                        " WHERE ApprovedDate IS NULL "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
            ''============================< ************************* >=========================================

            ''============================< Sch_RegistrationCancelPaymentDetail >============================================
            AgL.DeleteForeignKey(AgL.GCn, "FK_Sch_RegistrationCancelPaymentDetail_PaymentDetail", "Sch_RegistrationCancelPaymentDetail")

            AgL.AddNewField(AgL.GCn, "Sch_RegistrationCancelPaymentDetail", "PaymentDocId", "NVARCHAR(21)")
            If AgL.IsFieldExist("Sch_RegistrationCancelPaymentDetail", "PaymentDocId", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_RegistrationCancelPaymentDetail_PaymentDocId", "PaymentDetail", "Sch_RegistrationCancelPaymentDetail", "DocId", "PaymentDocId")
            End If
            ''============================< ************************* >=====================================


            ''============================< Sch_RegistrationStudentDetail >=====================================
            If AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "FatherIncome", "Float", 0, False) Then
                AgL.Dman_ExecuteNonQry("Update Sch_RegistrationStudentDetail Set FatherIncome = IsNull(FamilyIncome,0) ", AgL.GCn)
                AgL.Dman_ExecuteNonQry("Update Sch_RegistrationStudentDetail Set FamilyIncome = IsNull(FatherIncome,0) + IsNull(MotherIncome,0) ", AgL.GCn)
            End If

            AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "LocalGuardian", "nVarChar(100)")
            AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "PAdd1", "nVarChar(50)")
            AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "PAdd2", "nVarChar(50)")
            AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "PAdd3", "nVarChar(50)")
            AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "PCityCode", "nVarChar(6)")
            If AgL.IsFieldExist("PCityCode", "Sch_RegistrationStudentDetail", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_RegistrationStudentDetail_PCityCode", "City", "Sch_RegistrationStudentDetail", "CityCode", "PCityCode")
            End If
            AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "PPin", "nVarChar(6)")
            AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "PPhone", "nVarChar(35)")
            AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "PMobile", "nVarChar(35)")
            AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "PFax", "nVarChar(35)")
            If AgL.AddNewField(AgL.GCn, "Sch_RegistrationStudentDetail", "IsNewStudent", "bit", 1, False) Then
                mQry = "Update Sch_RegistrationStudentDetail Set IsNewStudent = Case When Student Is Not Null Then 0 Else 1 End "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_FeeDue >=====================================
            AgL.AddNewField(AgL.GCn, "Sch_FeeDue", "StreamYearSemester", "nVarChar(10)", , False)
            If AgL.IsFieldExist("StreamYearSemester", "Sch_FeeDue", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_FeeDue_StreamYearSemester", "Sch_StreamYearSemester", "Sch_FeeDue", "Code", "StreamYearSemester")
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_Admission >=====================================
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "AdmissionNature", "nVarChar(8)", , False)
            If AgL.IsFieldExist("AdmissionNature", "Sch_Admission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_AdmissionNature", "Sch_AdmissionNature", "Sch_Admission", "Code", "AdmissionNature")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Admission", "LeavingDate", "SmallDateTime")
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "LeavingReason", "nVarChar(100)")
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "ScholarshipApplied", "bit", 0, False)

            If AgL.AddNewField(AgL.GCn, "Sch_Admission", "Status", "nVarChar(20)", , True) Then
                mQry = "Update Sch_Admission Set Status = '" & Academic_ProjLib.ClsMain.AdmissionStatus_Regular & "' Where Status Is Null "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                AgL.EditField("Sch_Admission", "Status", "nVarChar(20)", AgL.GCn, False)
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Admission", "Rank", "Numeric(18,2)", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "RankRemark", "nVarChar(100)")
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "MeritPercentage", "Numeric(18,2)", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "MeritRemark", "nVarChar(100)")
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "IsFeeWavier", "bit", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "IsDiplomaHolder", "bit", 0, False)

            AgL.AddNewField(AgL.GCn, "Sch_Admission", "Conduct", "nVarChar(100)", , True)

            AgL.AddNewField(AgL.GCn, "Sch_Admission", "SessionProgramme", "nVarChar(8)")
            If AgL.IsFieldExist("SessionProgramme", "Sch_Admission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_SessionProgramme", "Sch_SessionProgramme", "Sch_Admission", "Code", "SessionProgramme")
                mQry = "UPDATE Sch_Admission " & _
                        " SET " & _
                        " Sch_Admission.SessionProgramme = Sch_SessionProgrammeStream.SessionProgramme " & _
                        " FROM Sch_SessionProgrammeStream " & _
                        " WHERE Sch_Admission.SessionProgrammeStream = Sch_SessionProgrammeStream.Code " & _
                        " And Sch_Admission.SessionProgramme Is Null "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Admission", "CounselingFee", "Float", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_Admission", "CounselingFeeReceiptNo", "nVarChar(35)")

            If AgL.AddNewField(AgL.GCn, "Sch_Admission", "IsAutoApproved", "bit", 0, False) Then
                If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                    mQry = "UPDATE Sch_Admission " & _
                            " SET " & _
                            " ApprovedBy = CASE WHEN Edit_Date IS NULL THEN PreparedBy ELSE ModifiedBy END, " & _
                            " ApprovedDate = CASE WHEN Edit_Date IS NULL THEN U_EntDt ELSE Edit_Date END, " & _
                            " IsAutoApproved = 1 " & _
                            " WHERE ApprovedDate IS NULL "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                End If
            End If

            If AgL.IsTableExist("Enquiry_Enquiry", AgL.GCn) Then
                AgL.AddNewField(AgL.GCn, "Sch_Admission", "EnquiryDocId", "nVarChar(21)")
                If AgL.IsFieldExist("EnquiryDocId", "Sch_Admission", AgL.GCn) Then
                    AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_EnquiryDocId", "Enquiry_Enquiry", "Sch_Admission", "DocId", "EnquiryDocId")
                End If
            End If

            If AgL.AddNewField(AgL.GCn, "Sch_Admission", "AdmissionSemester", "nVarChar(10)") Then
                mQry = "UPDATE Sch_Admission " & _
                        " SET Sch_Admission.AdmissionSemester = V.FromStreamYearSemester " & _
                        " FROM ( " & _
                        " 	SELECT A.DocId, Ap.FromStreamYearSemester, Ap.ToStreamYearSemester " & _
                        " 	FROM Sch_Admission A " & _
                        " 	INNER JOIN Sch_AdmissionPromotion Ap ON Ap.AdmissionDocId = A.DocId AND Ap.Sr = 1 " & _
                        " ) AS V " & _
                        " WHERE Sch_Admission.DocId = V.DocId "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
            If AgL.IsFieldExist("AdmissionSemester", "Sch_Admission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_AdmissionSemester", "Sch_StreamYearSemester", "Sch_Admission", "Code", "AdmissionSemester")
            End If

            If AgL.AddNewField(AgL.GCn, "Sch_Admission", "PromotionSemester", "nVarChar(10)") Then
                mQry = "UPDATE Sch_Admission " & _
                        " SET Sch_Admission.PromotionSemester = V.ToStreamYearSemester " & _
                        " FROM ( " & _
                        " 	SELECT A.DocId, Ap.FromStreamYearSemester, Ap.ToStreamYearSemester " & _
                        " 	FROM Sch_Admission A " & _
                        " 	INNER JOIN Sch_AdmissionPromotion Ap ON Ap.AdmissionDocId = A.DocId AND Ap.PromotionDate = A.V_Date AND Ap.Sr = 1 " & _
                        " ) AS V " & _
                        " WHERE Sch_Admission.DocId = V.DocId "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
            If AgL.IsFieldExist("PromotionSemester", "Sch_Admission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_PromotionSemester", "Sch_StreamYearSemester", "Sch_Admission", "Code", "PromotionSemester")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Admission", "CurrentSemester", "nVarChar(10)")
            If AgL.IsFieldExist("CurrentSemester", "Sch_Admission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_CurrentSemester", "Sch_StreamYearSemester", "Sch_Admission", "Code", "CurrentSemester")

                Call FunUpdateCurrentSemester(AgL.GCn)
            End If


            AgL.AddNewField(AgL.GCn, "Sch_Admission", "CurrentSection", "nVarChar(10)")
            If AgL.IsFieldExist("CurrentSection", "Sch_Admission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_CurrentSection", "Sch_ClassSection", "Sch_Admission", "Code", "CurrentSection")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Admission", "CurrentSubSection", "nVarChar(10)")
            If AgL.IsFieldExist("CurrentSubSection", "Sch_Admission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_CurrentSubSection", "Sch_ClassSectionSubSection", "Sch_Admission", "Code", "CurrentSubSection")
            End If

            If AgL.IsFieldExist("CurrentSection", "Sch_Admission", AgL.GCn) _
                And AgL.IsFieldExist("CurrentSubSection", "Sch_Admission", AgL.GCn) Then

                Call FunUpdateCurrentSection(AgL.GCn)
            End If
            
            If AgL.IsTableExist("Enquiry_Enquiry", AgL.GCn) Then
                AgL.AddNewField(AgL.GCn, "Sch_Admission", "EnquiryDocId", "nVarChar(21)")
                If AgL.IsFieldExist("EnquiryDocId", "Sch_Admission", AgL.GCn) Then
                    AgL.AddForeignKey(AgL.GCn, "FK_Sch_Admission_EnquiryDocId", "Enquiry_Enquiry", "Sch_Admission", "DocId", "EnquiryDocId")
                End If
            End If
            
            ''============================< ************************* >=====================================

            ''============================< Sch_AdmissionSubject >==========================================
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionSubject", "OtherSemesterSubject", "nVarChar(10)")
            If AgL.IsFieldExist("OtherSemesterSubject", "Sch_AdmissionSubject", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_AdmissionSubject_OtherSemesterSubject", "Sch_SemesterSubject", "Sch_AdmissionSubject", "Code", "OtherSemesterSubject")
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_AdmissionEnrollmentNo >=====================================
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionEnrollmentNo", "PreparedBy", "nVarChar(10)", , False)
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionEnrollmentNo", "U_EntDt", "DATETIME", , False)
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionEnrollmentNo", "U_AE", "nVarChar(1)", , False)
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionEnrollmentNo", "Edit_Date", "DATETIME")
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionEnrollmentNo", "ModifiedBy", "nVarChar(10)")
            ''============================< ************************* >=====================================

            ''============================< Sch_AdmissionPromotion >========================================
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionPromotion", "PromotionType", "nVarChar(20)")

            If AgL.IsFieldExist("PromotionType", "Sch_AdmissionPromotion", AgL.GCn) Then
                mQry = "Update Sch_AdmissionPromotion Set PromotionType = '" & Academic_ProjLib.ClsMain.PromotionType_Promotion & "' Where PromotionType Is Null "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_AdmissionStatusChangeDetail >========================================
            AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "IsNewStatusAfterPromotion", "bit", 0, False)

            AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "GUID", "nVarChar(36)")
            If AgL.IsFieldExist("GUID", "Sch_AdmissionStatusChangeDetail", AgL.GCn) Then
                mQry = "Update Sch_AdmissionStatusChangeDetail Set GUID = NewId() Where GUID Is Null "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                AgL.EditField("Sch_AdmissionStatusChangeDetail", "GUID", "nVarChar(36)", AgL.GCn, False)

                AgL.AddUniqueKeyConstraint("IX_Sch_AdmissionStatusChangeDetail_GUID", "Sch_AdmissionStatusChangeDetail", "GUID", AgL.GCn)
            End If

            AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "FeeDueDocId", "nVarChar(21)")
            If AgL.IsFieldExist("FeeDueDocId", "Sch_AdmissionStatusChangeDetail", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_AdmissionStatusChangeDetail_FeeDueDocId", "Sch_FeeDue", "Sch_AdmissionStatusChangeDetail", "DocId", "FeeDueDocId")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "ReverseFeeDueDocId", "nVarChar(21)")
            If AgL.IsFieldExist("ReverseFeeDueDocId", "Sch_AdmissionStatusChangeDetail", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_AdmissionStatusChangeDetail_ReverseFeeDueDocId", "Sch_ReverseFeeDue", "Sch_AdmissionStatusChangeDetail", "DocId", "ReverseFeeDueDocId")
            End If


            AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "StreamYearSemester", "nVarChar(10)")
            If AgL.IsFieldExist("StreamYearSemester", "Sch_AdmissionStatusChangeDetail", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_AdmissionStatusChangeDetail_StreamYearSemester", "Sch_StreamYearSemester", "Sch_AdmissionStatusChangeDetail", "Code", "StreamYearSemester")

                Try
                    mQry = "UPDATE Sch_AdmissionStatusChangeDetail " & _
                            " SET Sch_AdmissionStatusChangeDetail.StreamYearSemester = Sch_AdmissionPromotion.FromStreamYearSemester " & _
                            " FROM Sch_AdmissionPromotion " & _
                            " WHERE Sch_AdmissionPromotion.AdmissionDocId = Sch_AdmissionStatusChangeDetail.DocId " & _
                            " AND Sch_AdmissionStatusChangeDetail.StatusChangeDate = Sch_AdmissionPromotion.PromotionDate " & _
                            " AND Sch_AdmissionStatusChangeDetail.StreamYearSemester IS NULL "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                Catch ex As Exception

                End Try

                AgL.EditField("Sch_AdmissionStatusChangeDetail", "StreamYearSemester", "nVarChar(10)", AgL.GCn, False)

                If AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "PreparedBy", "nVarChar(10)") Then
                    mQry = "Update Sch_AdmissionStatusChangeDetail Set PreparedBy = '" & AgL.PubUserName & "' Where PreparedBy Is Null "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                End If

                If AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "U_EntDt", "DateTime") Then
                    mQry = "Update Sch_AdmissionStatusChangeDetail Set U_EntDt = StatusChangeDate Where U_EntDt Is Null "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                End If

                If AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "U_AE", "nVarChar(1)") Then
                    mQry = "Update Sch_AdmissionStatusChangeDetail Set U_AE = 'A' Where U_AE Is Null "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                End If

                AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "Edit_Date", "DateTime")
                AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "ModifiedBy", "nVarChar(10)")


                If AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "IsAutoApproved", "bit", 0, False) Then
                    mQry = "UPDATE Sch_AdmissionStatusChangeDetail " & _
                            " SET " & _
                            " ApprovedBy = '" & AgL.PubUserName & "', " & _
                            " ApprovedDate = StatusChangeDate, " & _
                            " IsAutoApproved = 1 " & _
                            " WHERE ApprovedDate IS NULL "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                End If

            End If

            AgL.AddNewField(AgL.GCn, "Sch_AdmissionStatusChangeDetail", "NewStreamYearSemester", "nVarChar(10)")
            If AgL.IsFieldExist("NewStreamYearSemester", "Sch_AdmissionStatusChangeDetail", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_AdmissionStatusChangeDetail_NewStreamYearSemester", "Sch_StreamYearSemester", "Sch_AdmissionStatusChangeDetail", "Code", "NewStreamYearSemester")

                Try
                    mQry = "UPDATE Sch_AdmissionStatusChangeDetail " & _
                            " SET Sch_AdmissionStatusChangeDetail.NewStreamYearSemester = Sch_AdmissionPromotion.ToStreamYearSemester " & _
                            " FROM Sch_AdmissionPromotion " & _
                            " WHERE Sch_AdmissionPromotion.AdmissionDocId = Sch_AdmissionStatusChangeDetail.DocId " & _
                            " AND Sch_AdmissionStatusChangeDetail.StatusChangeDate = Sch_AdmissionPromotion.PromotionDate " & _
                            " AND Sch_AdmissionStatusChangeDetail.NewStreamYearSemester IS NULL " & _
                            " AND CASE WHEN Sch_AdmissionStatusChangeDetail.OldStatus <> '" & Academic_ProjLib.ClsMain.AdmissionStatus_Regular & "' " & _
                            "       AND Sch_AdmissionStatusChangeDetail.NewStatus = '" & Academic_ProjLib.ClsMain.AdmissionStatus_Regular & "' " & _
                            " THEN Null ELSE Sch_AdmissionPromotion.ToStreamYearSemester END IS NOT NULL "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                Catch ex As Exception

                End Try
            End If
            ''============================< ************************* >==============================================

            ''============================< Sch_FeeReceive >================================================
            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "IsManageFee", "bit", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "ReceiveAmount", "Float", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "AdvanceCarriedForward", "Float", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "AdmissionDocId", "nVarChar(21)", , False)
            If AgL.IsFieldExist("AdmissionDocId", "Sch_FeeReceive", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_FeeReceive_AdmissionDocId", "Sch_Admission", "Sch_FeeReceive", "DocId", "AdmissionDocId")
            End If
            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "TotalAdvanceAdjusted", "Float", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "IsAdjustableReceipt", "bit", 0, False)
            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "TotalFeeReceiveAdjusted", "Float", 0, False)
            ''============================< ************************* >=====================================

            ''============================< Sch_FeeReceivePaymentDetail >================================================
            If AgL.AddNewField(AgL.GCn, "Sch_FeeReceivePaymentDetail", "PaymentDetailDocId", "nVarChar(21)") Then
                AgL.Dman_ExecuteNonQry("Update Sch_FeeReceivePaymentDetail Set PaymentDetailDocId = DocId Where PaymentDetailDocId Is Null", AgL.GCn)
            End If

            If AgL.IsFieldExist("PaymentDetailDocId", "Sch_FeeReceivePaymentDetail", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_FeeReceivePaymentDetail_PaymentDetailDocId1", "PaymentDetail", "Sch_FeeReceivePaymentDetail", "DocId", "PaymentDetailDocId")
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_FeeReceivePaymentDetail_PaymentDetailDocId2", "Sch_FeeReceive", "Sch_FeeReceivePaymentDetail", "DocId", "PaymentDetailDocId")

                AgL.DeleteForeignKey(AgL.GCn, "FK_Sch_FeeReceivePaymentDetail_PaymentDetail", "Sch_FeeReceivePaymentDetail")
            End If
            ''============================< ************************* >=====================================


            ''============================< Sch_FeeDue1 >===================================================
            AgL.AddNewField(AgL.GCn, "Sch_FeeDue1", "AdmissionDocId", "nVarChar(21)", , False)
            If AgL.IsFieldExist("AdmissionDocId", "Sch_FeeDue1", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_FeeDue1_AdmissionDocId", "Sch_Admission", "Sch_FeeDue1", "DocId", "AdmissionDocId")
                AgL.AddUniqueKeyConstraint("IX_Sch_FeeDue1_U_DocId_AdmissionDocId_Fee", "Sch_FeeDue1", "DocId,AdmissionDocId,Fee", AgL.GCn)
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_ClassSection >============================================
            AgL.AddNewField(AgL.GCn, "Sch_ClassSection", "IsOpenElectiveSection", "bit", 0, False)
            ''============================< ************************* >=====================================

            ''============================< Sch_ClassSectionSemesterAdmission >=============================
            AgL.AddNewField(AgL.GCn, "Sch_ClassSectionSemesterAdmission", "ClassSectionSubSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSectionSubSection", "Sch_ClassSectionSemesterAdmission", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_ClassSectionSemesterAdmission_ClassSectionSubSection", "Sch_ClassSectionSubSection", "Sch_ClassSectionSemesterAdmission", "Code", "ClassSectionSubSection")
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_StudentAttendance >=========================================
            AgL.AddNewField(AgL.GCn, "Sch_StudentAttendance", "ClassSectionSubSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSectionSubSection", "Sch_StudentAttendance", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_StudentAttendance_ClassSectionSubSection", "Sch_ClassSectionSubSection", "Sch_StudentAttendance", "Code", "ClassSectionSubSection")

                If AgL.IsConstraintExist("IX_Sch_StudentAttendance", "Sch_StudentAttendance", "Div_Code,Site_Code,A_Date,ClassSection,ClassRoom,TimeSlot", AgL.GCn) Then
                    AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_StudentAttendance DROP CONSTRAINT [IX_Sch_StudentAttendance]", AgL.GCn)
                End If
                AgL.AddUniqueKeyConstraint("IX_Sch_StudentAttendance", "Sch_StudentAttendance", "Div_Code,Site_Code,A_Date,ClassSection,ClassSectionSubSection,ClassRoom,TimeSlot", AgL.GCn)
            End If
            ''============================< ************************* >=====================================

            ''============================< Sch_Enviro >===================================================
            AgL.AddNewField(AgL.GCn, "Sch_Enviro", "DiscountAc", "nVarChar(10)")
            If AgL.IsFieldExist("DiscountAc", "Sch_Enviro", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Enviro_DiscountAc", "SubGroup", "Sch_Enviro", "SubCode", "DiscountAc")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Enviro", "FeeAdjustmentAc", "nVarChar(10)")
            If AgL.IsFieldExist("FeeAdjustmentAc", "Sch_Enviro", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Enviro_FeeAdjustmentAc", "SubGroup", "Sch_Enviro", "SubCode", "FeeAdjustmentAc")
            End If

            'Code By Akash On Date 24-01-11
            AgL.AddNewField(AgL.GCn, "Sch_Enviro", "FeeReceiptAdjustmentAc", "nVarChar(10)")
            If AgL.IsFieldExist("FeeReceiptAdjustmentAc", "Sch_Enviro", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Enviro_FeeReceiptAdjustmentAc", "SubGroup", "Sch_Enviro", "SubCode", "FeeReceiptAdjustmentAc")
            End If
            'End Code

            AgL.AddNewField(AgL.GCn, "Sch_Enviro", "ScholarshipAdjustmentAc", "nVarChar(10)")
            If AgL.IsFieldExist("ScholarshipAdjustmentAc", "Sch_Enviro", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Enviro_ScholarshipAdjustmentAc", "SubGroup", "Sch_Enviro", "SubCode", "ScholarshipAdjustmentAc")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Enviro", "CounselingFeeAdjustmentAc", "nVarChar(10)")
            If AgL.IsFieldExist("CounselingFeeAdjustmentAc", "Sch_Enviro", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Enviro_CounselingFeeAdjustmentAc", "SubGroup", "Sch_Enviro", "SubCode", "CounselingFeeAdjustmentAc")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Enviro", "LockBackDays", "int", 0)

            AgL.AddNewField(AgL.GCn, "Sch_Enviro", "AttendanceDbName", "nVarchar(100)")
            AgL.AddNewField(AgL.GCn, "Sch_Enviro", "AttendanceServer", "nVarchar(100)")
            AgL.AddNewField(AgL.GCn, "Sch_Enviro", "AttendanceUser", "nVarchar(100)")
            AgL.AddNewField(AgL.GCn, "Sch_Enviro", "AttendancePassword", "nVarchar(100)")

            AgL.AddNewField(AgL.GCn, "Sch_Enviro", "IsAutoAcManualCode", "bit", 0)
            ''============================< ************************* >=====================================

            ''============================< Sch_Department >===================================================
            AgL.AddNewField(AgL.GCn, "Sch_Department", "ParentCode", "nVarChar(8)")
            If AgL.IsFieldExist("ParentCode", "Sch_Department", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_Department_ParentCode", "Sch_Department", "Sch_Department", "Code", "ParentCode")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_Department", "MainStreamCode", "nVarChar(Max)", , False)
            AgL.AddNewField(AgL.GCn, "Sch_Department", "GroupLevel", "Int", 0, False)
            ''============================< ************************* >=====================================

            'Code By Akash On Date 24-01-11
            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "FeeAdjustmentAc", "nVarChar(10)")
            If AgL.IsFieldExist("FeeAdjustmentAc", "Sch_FeeReceive", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_FeeReceive_FeeAdjustmentAc", "SubGroup", "Sch_FeeReceive", "SubCode", "FeeAdjustmentAc")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_FeeReceive", "FeeReceiptAdjustmentAc", "nVarChar(10)")
            If AgL.IsFieldExist("FeeReceiptAdjustmentAc", "Sch_FeeReceive", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_FeeReceive_FeeReceiptAdjustmentAc", "SubGroup", "Sch_FeeReceive", "SubCode", "FeeReceiptAdjustmentAc")
                AgL.Dman_ExecuteNonQry("UPDATE Sch_FeeReceive SET FeeAdjustmentAc = Sch_Enviro.FeeAdjustmentAc FROM Sch_Enviro WHERE Sch_FeeReceive.Site_Code = Sch_Enviro.Site_Code And Sch_FeeReceive.FeeAdjustmentAc Is Null ", AgL.GCn)
            End If
            'End Code


            AgL.AddNewField(AgL.GCn, "Sch_AdmissionFeeDetail", "FeeStreamYearSemester", "nVarChar(10)")
            If AgL.IsFieldExist("FeeStreamYearSemester", "Sch_AdmissionFeeDetail", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_AdmissionFeeDetail_FeeStreamYearSemester", "Sch_StreamYearSemester", "Sch_AdmissionFeeDetail", "Code", "FeeStreamYearSemester")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_ClassSectionSemesterAdmission", "SectionLeftOnDate", "SmallDateTime")


            AgL.AddNewField(AgL.GCn, "Sch_ClassSectionOpenElectiveSemesterAdmission", "SectionLeftOnDate", "SmallDateTime")

            ''============================< Rati 15/Jun2012 Sch_LabStatus >=============================================
            If AgL.IsFieldExist("V_Type", "Sch_LabStatus", AgL.GCn) Then
                mQry = "Update Sch_LabStatus Set V_Type = '" & ClsMain.Temp_NCat.LabStatus & "' Where V_Type  = '" & ClsMain.Temp_NCat.LecturePlan & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If

            ''============================< Rati 16/Apr2012 Sch_LabWork >=============================================
            AgL.AddNewField(AgL.GCn, "Sch_LabWork", "ClassSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSection", "Sch_LabWork", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_LabWork_ClassSection", "Sch_ClassSection", "Sch_LabWork", "Code", "ClassSection")
            End If

            AgL.AddNewField(AgL.GCn, "Sch_LabWork", "ClassSectionSubSection", "nVarChar(10)")
            If AgL.IsFieldExist("ClassSectionSubSection", "Sch_LabWork", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Sch_LabWork_ClassSectionSubSection", "Sch_ClassSectionSubSection", "Sch_LabWork", "Code", "ClassSectionSubSection")
            End If

            ''============================< Rati 17/May2012 Sch_LabWork1 >=============================================
            If AgL.AddNewField(AgL.GCn, "Sch_LabWork1", "StreamYearSemester", "nVarChar(10)") Then
                mQry = "Update dbo.Sch_LabWork1 " & _
                         " Set Sch_LabWork1.StreamYearSemester=Sch_LabWork.StreamYearSemester   " & _
                         " FROM Sch_LabWork  " & _
                         " Where  Sch_LabWork.DocId=Sch_LabWork1.DocId " & _
                         " And Sch_LabWork.StreamYearSemester Is Not Null "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            End If
            If AgL.IsFieldExist("StreamYearSemester", "Exam_SemesterExamAdmission1", AgL.GCn) Then
                AgL.AddForeignKey(AgL.GCn, "FK_Exam_SemesterExamAdmission1_StreamYearSemester", "Sch_StreamYearSemester", "Exam_SemesterExamAdmission1", "Code", "StreamYearSemester")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DeleteField()
        Try
            If AgL.IsFieldExist("ScholarshipApplied", "Sch_Student", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_Student DROP CONSTRAINT [DF_Sch_Student_EnglishProficiency_TOEFL1]", AgL.GCn)
                AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_Student DROP COLUMN ScholarshipApplied", AgL.GCn)
            End If

            If AgL.IsFieldExist("Student", "Sch_FeeDue1", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_FeeDue1 DROP CONSTRAINT [IX_Sch_FeeDue1]", AgL.GCn)
                AgL.DeleteForeignKey(AgL.GCn, "FK_Sch_FeeDue1_Sch_Student", "Sch_FeeDue1")
                AgL.DeleteField("Sch_FeeDue1", "Student", AgL.GCn)
            End If

            If AgL.IsFieldExist("Student", "Sch_FeeReceive", AgL.GCn) Then
                AgL.DeleteForeignKey(AgL.GCn, "FK_Sch_FeeReceive_Sch_Student", "Sch_FeeReceive")
                AgL.DeleteField("Sch_FeeReceive", "Student", AgL.GCn)
            End If

            If AgL.IsFieldExist("RowId", "Sch_RegistrationAcademicDetail", AgL.GCn) Then
                If Not AgL.IsIdentityColumn("RowId", "Sch_RegistrationAcademicDetail", AgL.GCn) Then
                    AgL.DeleteField("Sch_RegistrationAcademicDetail", "RowId", AgL.GCn)
                End If
            End If

            If AgL.IsFieldExist("RowId", "Store_Item", AgL.GCn) Then
                If Not AgL.IsIdentityColumn("RowId", "Store_Item", AgL.GCn) Then
                    AgL.DeleteField("Store_Item", "RowId", AgL.GCn)
                End If
            End If

            If AgL.IsFieldExist("Student", "Sch_FeeDue", AgL.GCn) Then
                AgL.DeleteForeignKey(AgL.GCn, "FK_Sch_FeeDue_Sch_Student", "Sch_FeeDue")
                AgL.DeleteField("Sch_FeeDue", "Student", AgL.GCn)
            End If

            If AgL.IsFieldExist("SessionProgrammeStreamYear", "Sch_FeeDue", AgL.GCn) Then
                AgL.DeleteForeignKey(AgL.GCn, "FK_Sch_FeeDue_Sch_SessionProgrammeStreamYear", "Sch_FeeDue")
                AgL.DeleteField("Sch_FeeDue", "SessionProgrammeStreamYear", AgL.GCn)
            End If

            If AgL.IsFieldExist("RowId", "Sch_AdmissionEnrollmentNo", AgL.GCn) Then
                If Not AgL.IsIdentityColumn("RowId", "Sch_AdmissionEnrollmentNo", AgL.GCn) Then
                    AgL.DeleteField("Sch_AdmissionEnrollmentNo", "RowId", AgL.GCn)
                End If
            End If

            If AgL.IsFieldExist("RowId", "Sch_FeeDue", AgL.GCn) Then
                If Not AgL.IsIdentityColumn("RowId", "Sch_FeeDue", AgL.GCn) Then
                    AgL.DeleteField("Sch_FeeDue", "RowId", AgL.GCn)
                End If
            End If

            If AgL.IsFieldExist("RowId", "Sch_FeeDue1", AgL.GCn) Then
                If Not AgL.IsIdentityColumn("RowId", "Sch_FeeDue1", AgL.GCn) Then
                    AgL.DeleteField("Sch_FeeDue1", "RowId", AgL.GCn)
                End If
            End If

            If AgL.IsFieldExist("RollNo", "Sch_AdmissionEnrollmentNo", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry("ALTER TABLE Sch_AdmissionEnrollmentNo DROP CONSTRAINT [IX_Sch_AdmissionEnrollmentNo_1]", AgL.GCn)
                AgL.DeleteField("Sch_AdmissionEnrollmentNo", "RollNo", AgL.GCn)
            End If

            If AgL.IsFieldExist("Fee", "Sch_FeeReceive1", AgL.GCn) Then
                AgL.DeleteForeignKey(AgL.GCn, "FK_Sch_FeeReceive1_Sch_Fee", "Sch_FeeReceive1")
                AgL.DeleteField("Sch_FeeReceive1", "Fee", AgL.GCn)
            End If


            '=========================================================================================================
            '====================< Pay Employee >=====================================================================
            '=========================================================================================================
            If AgL.IsFieldExist("Course", "Pay_Employee", AgL.GCn) Then
                AgL.DeleteField("Pay_Employee", "Course", AgL.GCn)
            End If

            If AgL.IsFieldExist("FacultyType", "Pay_Employee", AgL.GCn) Then
                AgL.DeleteField("Pay_Employee", "FacultyType", AgL.GCn)
            End If

            If AgL.IsFieldExist("IsPapersPublishedInNationalJournals", "Pay_Employee", AgL.GCn) Then
                AgL.DeleteField("Pay_Employee", "IsPapersPublishedInNationalJournals", AgL.GCn)
            End If

            If AgL.IsFieldExist("IsPapersPublishedInInternationalJournals", "Pay_Employee", AgL.GCn) Then
                AgL.DeleteField("Pay_Employee", "IsPapersPublishedInInternationalJournals", AgL.GCn)
            End If

            If AgL.IsFieldExist("IsInternationalConferencesAttended", "Pay_Employee", AgL.GCn) Then
                AgL.DeleteField("Pay_Employee", "IsInternationalConferencesAttended", AgL.GCn)
            End If

            If AgL.IsFieldExist("IsNationalConferencesAttended", "Pay_Employee", AgL.GCn) Then
                AgL.DeleteField("Pay_Employee", "IsNationalConferencesAttended", AgL.GCn)
            End If

            If AgL.IsFieldExist("IsPapersInNationalConference", "Pay_Employee", AgL.GCn) Then
                AgL.DeleteField("Pay_Employee", "IsPapersInNationalConference", AgL.GCn)
            End If

            If AgL.IsFieldExist("IsPapersInInternationalConference", "Pay_Employee", AgL.GCn) Then
                AgL.DeleteField("Pay_Employee", "IsPapersInInternationalConference", AgL.GCn)
            End If

            If AgL.IsFieldExist("IsShortTermCoursesAttended", "Pay_Employee", AgL.GCn) Then
                AgL.DeleteField("Pay_Employee", "IsShortTermCoursesAttended", AgL.GCn)
            End If

            If AgL.IsFieldExist("IsWorkshopsAttended", "Pay_Employee", AgL.GCn) Then
                AgL.DeleteField("Pay_Employee", "IsWorkshopsAttended", AgL.GCn)
            End If

            If AgL.IsFieldExist("IsSeminarsAttended", "Pay_Employee", AgL.GCn) Then
                AgL.DeleteField("Pay_Employee", "IsSeminarsAttended", AgL.GCn)
            End If

            '=========================================================================================================
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EditField()
        Try
            AgL.EditField("Sch_Admission", "AdmissionID", "nVarChar(61)", AgL.GCn, False)

            AgL.EditField("Sch_Subject", "Description", "nVarChar(123)", AgL.GCn, False)
            AgL.EditField("Sch_Subject", "DisplayName", "nVarChar(100)", AgL.GCn, False)

            AgL.AddUniqueKeyConstraint("IX_Sch_ClassSectionSemester", "Sch_ClassSectionSemester", "ClassSection,StreamYearSemester", AgL.GCn)


            AgL.EditField("Sch_DocumentIssue", "SubCode", "nVarChar(10)", AgL.GCn)
            AgL.EditField("Sch_Student", "LastName", "nVarChar(25)", AgL.GCn)

            'AgL.AddForeignKey(AgL.GCn, "FK_VehicleHireChallan_AdvancePayAc", "SubGroup", "VehicleHireChallan", "SubCode", "AdvancePayAc")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AddNewTable()
        Dim mQry As String = "", mQry1 As String = ""

        Try
            mQry = "CREATE TABLE dbo.Sch_StreamYearSemesterFee " & _
                    " ( " & _
                    " Code               NVARCHAR (10) NOT NULL, " & _
                    " StreamYearSemester NVARCHAR (10) NOT NULL, " & _
                    " Fee                NVARCHAR (10) NOT NULL, " & _
                    " Amount             FLOAT NOT NULL, " & _
                    " RowId              BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate         SMALLDATETIME NULL, " & _
                    " CONSTRAINT PK_Sch_SessionProgrammeStreamFee PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_SessionProgrammeStreamFee UNIQUE (StreamYearSemester,Fee), " & _
                    " CONSTRAINT FK_Sch_SessionProgrammeStreamFee_Sch_Fee FOREIGN KEY (Fee) REFERENCES dbo.Sch_Fee (Code), " & _
                    " CONSTRAINT FK_Sch_SessionProgrammeStreamFee_Sch_StreamYearSemester FOREIGN KEY (StreamYearSemester) REFERENCES dbo.Sch_StreamYearSemester (Code) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_StreamYearSemesterFee", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                AgL.Dman_ExecuteNonQry("Drop Table Sch_SessionProgrammeStreamFee", AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_StreamYearSemesterFee", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                    AgL.Dman_ExecuteNonQry("Drop Table Sch_SessionProgrammeStreamFee", AgL.GcnSite)
                End If
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_AdmissionRollNo " & _
                    " ( " & _
                    " DocId      NVARCHAR (21) NOT NULL, " & _
                    " RollNo     NVARCHAR (60) NOT NULL, " & _
                    " PreparedBy NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt    DATETIME NOT NULL, " & _
                    " U_AE       NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date  DATETIME NULL, " & _
                    " ModifiedBy NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_AdmissionRollNo PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Sch_AdmissionRollNo UNIQUE (RollNo), " & _
                    " CONSTRAINT FK_Sch_AdmissionRollNo_Sch_Admission FOREIGN KEY (DocId) REFERENCES dbo.Sch_Admission (DocId) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_AdmissionRollNo", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_AdmissionRollNo", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_AdmissionPromotion " & _
                    " ( " & _
                    " AdmissionDocId         NVARCHAR (21) NOT NULL, " & _
                    " Sr                     INT NOT NULL, " & _
                    " FromStreamYearSemester NVARCHAR (10) NOT NULL, " & _
                    " PromotionDate          SMALLDATETIME NULL, " & _
                    " ToStreamYearSemester   NVARCHAR (10) NULL, " & _
                    " PreparedBy             NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt                DATETIME NOT NULL, " & _
                    " U_AE                   NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date              DATETIME NULL, " & _
                    " ModifiedBy             NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_AdmissionPromotion PRIMARY KEY (AdmissionDocId,Sr), " & _
                    " CONSTRAINT IX_Sch_AdmissionPromotion UNIQUE (AdmissionDocId,FromStreamYearSemester), " & _
                    " CONSTRAINT IX_Sch_AdmissionPromotion_1 UNIQUE (AdmissionDocId,PromotionDate), " & _
                    " CONSTRAINT IX_Sch_AdmissionPromotion_2 UNIQUE (AdmissionDocId,ToStreamYearSemester), " & _
                    " CONSTRAINT FK_Sch_AdmissionPromotion_Sch_StreamYearSemester1 FOREIGN KEY (FromStreamYearSemester) REFERENCES dbo.Sch_StreamYearSemester (Code), " & _
                    " CONSTRAINT FK_Sch_AdmissionPromotion_Sch_StreamYearSemester2 FOREIGN KEY (ToStreamYearSemester) REFERENCES dbo.Sch_StreamYearSemester (Code), " & _
                    " CONSTRAINT FK_Sch_AdmissionPromotion_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_AdmissionPromotion", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_AdmissionPromotion", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Sch_AdmissionFeeDue " & _
                    " ( " & _
                    " AdmissionDocId NVARCHAR (21) NOT NULL, " & _
                    " FeeDueDocId    NVARCHAR (21) NOT NULL, " & _
                    " Remark         NVARCHAR (255) NULL, " & _
                    " CONSTRAINT PK_Sch_AdmissionFeeDue PRIMARY KEY (AdmissionDocId,FeeDueDocId), " & _
                    " CONSTRAINT FK_Sch_AdmissionFeeDue_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId), " & _
                    " CONSTRAINT FK_Sch_AdmissionFeeDue_Sch_FeeDue FOREIGN KEY (FeeDueDocId) REFERENCES dbo.Sch_FeeDue (DocId) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_AdmissionFeeDue", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_AdmissionFeeDue", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_RegistrationPaymentDetail " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " LedgerMDocId NVARCHAR (21) NULL, " & _
                    " CONSTRAINT PK_Sch_RegistrationPaymentDetail PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Sch_RegistrationPaymentDetail_Sch_Registration FOREIGN KEY (DocId) REFERENCES dbo.Sch_Registration (DocId), " & _
                    " CONSTRAINT FK_Sch_RegistrationPaymentDetail_PaymentDetail FOREIGN KEY (DocId) REFERENCES dbo.PaymentDetail (DocId), " & _
                    " CONSTRAINT FK_Sch_RegistrationPaymentDetail_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId), " & _
                    " CONSTRAINT FK_Sch_RegistrationPaymentDetail_Sch_Registration1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Sch_Registration (DocId) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_RegistrationPaymentDetail", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_RegistrationPaymentDetail", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Sch_FeeReceivePaymentDetail " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " LedgerMDocId NVARCHAR (21) NULL, " & _
                    " CONSTRAINT PK_Sch_FeeReceivePaymentDetail PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeReceivePaymentDetail_Sch_FeeReceive FOREIGN KEY (DocId) REFERENCES dbo.Sch_FeeReceive (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeReceivePaymentDetail_PaymentDetail FOREIGN KEY (DocId) REFERENCES dbo.PaymentDetail (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeReceivePaymentDetail_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeReceivePaymentDetail_Sch_FeeReceive1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Sch_FeeReceive (DocId) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_FeeReceivePaymentDetail", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_FeeReceivePaymentDetail", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_FeeDueLedgerM " & _
                    " ( " & _
                    " DocId NVARCHAR (21) NOT NULL, " & _
                    " CONSTRAINT PK_Sch_FeeDueLedgerM PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeDueLedgerM_Sch_FeeDue FOREIGN KEY (DocId) REFERENCES dbo.Sch_FeeDue (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeDueLedgerM_LedgerM FOREIGN KEY (DocId) REFERENCES dbo.LedgerM (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_FeeDueLedgerM", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_FeeDueLedgerM", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_FeeReceiveRegistration " & _
                    " ( " & _
                    " FeeReceiveDocId   NVARCHAR (21) NOT NULL, " & _
                    " RegistrationDocId NVARCHAR (21) NOT NULL, " & _
                    " Remark            NVARCHAR (255) NULL, " & _
                    " CONSTRAINT PK_Sch_FeeReceiveRegistration PRIMARY KEY (FeeReceiveDocId,RegistrationDocId), " & _
                    " CONSTRAINT FK_Sch_FeeReceiveRegistration_Sch_Registration FOREIGN KEY (RegistrationDocId) REFERENCES dbo.Sch_Registration (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeReceiveRegistration_Sch_FeeReceive FOREIGN KEY (FeeReceiveDocId) REFERENCES dbo.Sch_FeeReceive (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_FeeReceiveRegistration", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_FeeReceiveRegistration", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ClassRoom " & _
                    " ( " & _
                    " Code        NVARCHAR (8) NOT NULL, " & _
                    " Description NVARCHAR (50) NOT NULL, " & _
                    " ManualCode  NVARCHAR (20) NOT NULL, " & _
                    " Capacity    INT CONSTRAINT DF_Sch_ClassRoom_Capacity DEFAULT ((0)) NOT NULL, " & _
                    " Location    NVARCHAR (255) NULL, " & _
                    " Div_Code    NVARCHAR (1) NOT NULL, " & _
                    " Site_Code   NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy  NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt     DATETIME NOT NULL, " & _
                    " U_AE        NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date   DATETIME NULL, " & _
                    " ModifiedBy  NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_ClassRoom PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_ClassRoom UNIQUE (Description), " & _
                    " CONSTRAINT IX_Sch_ClassRoom_1 UNIQUE (ManualCode), " & _
                    " CONSTRAINT FK_Sch_ClassRoom_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_ClassRoom", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ClassRoom", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ClassSection " & _
                    " ( " & _
                    " Code             NVARCHAR (10) NOT NULL, " & _
                    " SessionProgramme NVARCHAR (8) NOT NULL, " & _
                    " Section          NVARCHAR (5) NOT NULL, " & _
                    " RowId            BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate       SMALLDATETIME NULL, " & _
                    " CONSTRAINT PK_Sch_ClassSection PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_ClassSection UNIQUE (SessionProgramme,Section), " & _
                    " CONSTRAINT FK_Sch_ClassSection_Sch_SessionProgramme FOREIGN KEY (SessionProgramme) REFERENCES dbo.Sch_SessionProgramme (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_ClassSection", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ClassSection", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ClassSectionSemester " & _
                    " ( " & _
                    " Code               NVARCHAR (10) NOT NULL, " & _
                    " ClassSection       NVARCHAR (10) NOT NULL, " & _
                    " StreamYearSemester NVARCHAR (10) NOT NULL, " & _
                    " TotalStudent       INT CONSTRAINT DF_TT_ClassSectionSemester_TotalStudent DEFAULT ((0)) NOT NULL, " & _
                    " Remark             NVARCHAR (255) NULL, " & _
                    " Div_Code           NVARCHAR (1) NOT NULL, " & _
                    " Site_Code          NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy         NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt            DATETIME NOT NULL, " & _
                    " U_AE               NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date          DATETIME NULL, " & _
                    " ModifiedBy         NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_TT_ClassSectionSemester PRIMARY KEY (Code), " & _
                    " CONSTRAINT FK_TT_ClassSectionSemester_TT_ClassSection FOREIGN KEY (ClassSection) REFERENCES dbo.Sch_ClassSection (Code), " & _
                    " CONSTRAINT FK_TT_ClassSectionSemester_Sch_StreamYearSemester FOREIGN KEY (StreamYearSemester) REFERENCES dbo.Sch_StreamYearSemester (Code), " & _
                    " CONSTRAINT FK_TT_ClassSectionSemester_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_ClassSectionSemester", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ClassSectionSemester", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ClassSectionSemesterAdmission " & _
                    " ( " & _
                    " Code           NVARCHAR (10) NOT NULL, " & _
                    " Sr             INT NOT NULL, " & _
                    " AdmissionDocId NVARCHAR (21) NOT NULL, " & _
                    " CONSTRAINT PK_TT_ClassSectionSemesterAdmission PRIMARY KEY (Code,Sr), " & _
                    " CONSTRAINT IX_TT_ClassSectionSemesterAdmission UNIQUE (Code,AdmissionDocId), " & _
                    " CONSTRAINT FK_TT_ClassSectionSemesterAdmission_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId), " & _
                    " CONSTRAINT FK_TT_ClassSectionSemesterAdmission_TT_ClassSectionSemester FOREIGN KEY (Code) REFERENCES dbo.Sch_ClassSectionSemester (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_ClassSectionSemesterAdmission", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ClassSectionSemesterAdmission", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Pay_Employee " & _
                    " ( " & _
                    " SubCode         NVARCHAR (10) NOT NULL, " & _
                    " FirstName       NVARCHAR (49) NOT NULL, " & _
                    " MiddleName      NVARCHAR (24) NULL, " & _
                    " LastName        NVARCHAR (25) NOT NULL, " & _
                    " DateOfJoin      SMALLDATETIME NOT NULL, " & _
                    " DateOfResign    SMALLDATETIME NULL, " & _
                    " ResignRemark    NVARCHAR (255) NULL, " & _
                    " Sex             NVARCHAR (6) NULL, " & _
                    " BloodGroup      NVARCHAR (6) NULL, " & _
                    " Religion        NVARCHAR (8) NULL, " & _
                    " Category        NVARCHAR (8) NULL, " & _
                    " IsTeachingStaff BIT CONSTRAINT DF_Pay_Employee_IsTeachingStaff DEFAULT ((0)) NOT NULL, " & _
                    " CONSTRAINT PK_Pay_Employee PRIMARY KEY (SubCode), " & _
                    " CONSTRAINT FK_Pay_Employee_Sch_Religion FOREIGN KEY (Religion) REFERENCES dbo.Sch_Religion (Code), " & _
                    " CONSTRAINT FK_Pay_Employee_Sch_Category FOREIGN KEY (Category) REFERENCES dbo.Sch_Category (Code), " & _
                    " CONSTRAINT FK_Pay_Employee_SubGroup FOREIGN KEY (SubCode) REFERENCES dbo.SubGroup (SubCode) " & _
                    " )"
            If Not AgL.IsTableExist("Pay_Employee", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Pay_Employee", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Pay_EmployeeAcademicDetail " & _
                    " ( " & _
                    " SubCode         NVARCHAR (10) NOT NULL, " & _
                    " Sr              INT NOT NULL, " & _
                    " Class           NVARCHAR (50) NOT NULL, " & _
                    " University      NVARCHAR (8) NULL, " & _
                    " EnrollmentNo    NVARCHAR (20) NULL, " & _
                    " YearOfPassing   SMALLINT NULL, " & _
                    " Subjects        NVARCHAR (255) NULL, " & _
                    " Result          NVARCHAR (20) NULL, " & _
                    " TotalPercentage NUMERIC (18,2) CONSTRAINT DF_Sch_EmployeeAcademicDetail_TotalPercentage DEFAULT ((0)) NOT NULL, " & _
                    " MeritPercentage NUMERIC (18,2) CONSTRAINT DF_Table_1_PCMPercentage DEFAULT ((0)) NOT NULL, " & _
                    " Remark          NVARCHAR (255) CONSTRAINT DF_Sch_EmployeeAcademicDetail_Remark DEFAULT ('') NULL, " & _
                    " CONSTRAINT PK_Pay_EmployeeAcademicDetail PRIMARY KEY (SubCode,Sr), " & _
                    " CONSTRAINT IX_Pay_EmployeeAcademicDetail UNIQUE (SubCode,Class), " & _
                    " CONSTRAINT FK_Pay_EmployeeAcademicDetail_Sch_University FOREIGN KEY (University) REFERENCES dbo.Sch_University (Code), " & _
                    " CONSTRAINT FK_Pay_EmployeeAcademicDetail_Pay_Employee FOREIGN KEY (SubCode) REFERENCES dbo.Pay_Employee (SubCode) " & _
                    " )"
            If Not AgL.IsTableExist("Pay_EmployeeAcademicDetail", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Pay_EmployeeAcademicDetail", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Pay_TeacherSubject " & _
                    " ( " & _
                    " SubCode NVARCHAR (10) NOT NULL, " & _
                    " Sr      INT NOT NULL, " & _
                    " Subject NVARCHAR (8) NOT NULL, " & _
                    " CONSTRAINT PK_Sch_TeacherSubject PRIMARY KEY (SubCode,Sr), " & _
                    " CONSTRAINT IX_Sch_TeacherSubject UNIQUE (SubCode,Subject), " & _
                    " CONSTRAINT FK_Sch_TeacherSubject_Sch_Subject FOREIGN KEY (Subject) REFERENCES dbo.Sch_Subject (Code), " & _
                    " CONSTRAINT FK_Sch_TeacherSubject_Pay_Employee FOREIGN KEY (SubCode) REFERENCES dbo.Pay_Employee (SubCode) " & _
                    " )"
            If Not AgL.IsTableExist("Pay_TeacherSubject", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Pay_TeacherSubject", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_TimeSlot " & _
                    " ( " & _
                    " Code        NVARCHAR (8) NOT NULL, " & _
                    " Description NVARCHAR (50) NOT NULL, " & _
                    " StartTime   DATETIME NOT NULL, " & _
                    " EndTime     DATETIME NOT NULL, " & _
                    " Duration    FLOAT CONSTRAINT DF_Sch_TimeSlot_Duration DEFAULT ((0)) NOT NULL, " & _
                    " Div_Code    NVARCHAR (1) NOT NULL, " & _
                    " Site_Code   NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy  NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt     DATETIME NOT NULL, " & _
                    " U_AE        NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date   DATETIME NULL, " & _
                    " ModifiedBy  NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_TimeSlot PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_TimeSlot UNIQUE (Description), " & _
                    " CONSTRAINT IX_Sch_TimeSlot_1 UNIQUE (StartTime,EndTime), " & _
                    " CONSTRAINT FK_Sch_TimeSlot_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_TimeSlot", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_TimeSlot", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_StudentAttendance " & _
                    " ( " & _
                    " Code         NVARCHAR (10) NOT NULL, " & _
                    " A_Date       SMALLDATETIME NOT NULL, " & _
                    " TimeSlot     NVARCHAR (8) NOT NULL, " & _
                    " ClassSection NVARCHAR (10) NOT NULL, " & _
                    " ClassRoom    NVARCHAR (8) NOT NULL, " & _
                    " Subject      NVARCHAR (8) NOT NULL, " & _
                    " Teacher      NVARCHAR (10) NOT NULL, " & _
                    " Remark       NVARCHAR (255) NULL, " & _
                    " Div_Code     NVARCHAR (1) NOT NULL, " & _
                    " Site_Code    NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy   NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt      DATETIME NOT NULL, " & _
                    " U_AE         NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date    DATETIME NULL, " & _
                    " ModifiedBy   NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_StudentAttendance PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_StudentAttendance UNIQUE (Div_Code,Site_Code,A_Date,ClassSection,ClassRoom,TimeSlot), " & _
                    " CONSTRAINT IX_Sch_StudentAttendance_1 UNIQUE (A_Date,TimeSlot,Teacher), " & _
                    " CONSTRAINT IX_Sch_StudentAttendance_2 UNIQUE (A_Date,TimeSlot,Teacher,Subject), " & _
                    " CONSTRAINT FK_Sch_StudentAttendance_Sch_ClassSection FOREIGN KEY (ClassSection) REFERENCES dbo.Sch_ClassSection (Code), " & _
                    " CONSTRAINT FK_Sch_StudentAttendance_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Sch_StudentAttendance_Pay_Employee FOREIGN KEY (Teacher) REFERENCES dbo.Pay_Employee (SubCode), " & _
                    " CONSTRAINT FK_Sch_StudentAttendance_Sch_Subject FOREIGN KEY (Subject) REFERENCES dbo.Sch_Subject (Code), " & _
                    " CONSTRAINT FK_Sch_StudentAttendance_Sch_TimeSlot FOREIGN KEY (TimeSlot) REFERENCES dbo.Sch_TimeSlot (Code), " & _
                    " CONSTRAINT FK_Sch_StudentAttendance_Sch_ClassRoom FOREIGN KEY (ClassRoom) REFERENCES dbo.Sch_ClassRoom (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_StudentAttendance", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_StudentAttendance", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Sch_StudentAttendance1 " & _
                    " ( " & _
                    " Code           NVARCHAR (10) NOT NULL, " & _
                    " Sr             INT NOT NULL, " & _
                    " AdmissionDocId NVARCHAR (21) NOT NULL, " & _
                    " IsPresent      BIT CONSTRAINT DF_Sch_StudentAttendance1_IsPresent DEFAULT ((0)) NOT NULL, " & _
                    " CONSTRAINT PK_Sch_StudentAttendance1 PRIMARY KEY (Code,Sr), " & _
                    " CONSTRAINT IX_Sch_StudentAttendance1 UNIQUE (Code,AdmissionDocId), " & _
                    " CONSTRAINT FK_Sch_StudentAttendance1_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId), " & _
                    " CONSTRAINT FK_Sch_StudentAttendance1_Sch_StudentAttendance FOREIGN KEY (Code) REFERENCES dbo.Sch_StudentAttendance (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_StudentAttendance1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_StudentAttendance1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ClassSectionSubSection " & _
                    " ( " & _
                    " Code         NVARCHAR (10) NOT NULL, " & _
                    " ClassSection NVARCHAR (10) NOT NULL, " & _
                    " SubSection   NVARCHAR (10) NOT NULL, " & _
                    " RowId        BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate   SMALLDATETIME NULL, " & _
                    " CONSTRAINT PK_Sch_ClassSectionSubSection PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_ClassSectionSubSection UNIQUE (ClassSection,SubSection), " & _
                    " CONSTRAINT FK_Sch_ClassSectionSubSection_Sch_ClassSection FOREIGN KEY (ClassSection) REFERENCES dbo.Sch_ClassSection (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_ClassSectionSubSection", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ClassSectionSubSection", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ClassSectionOpenElectiveSemester " & _
                    " ( " & _
                    " Code               NVARCHAR (10) NOT NULL, " & _
                    " ClassSection       NVARCHAR (10) NOT NULL, " & _
                    " StreamYearSemester NVARCHAR (10) NOT NULL, " & _
                    " TotalStudent       INT CONSTRAINT DF_Sch_ClassSectionOpenElectiveSemester_TotalStudent DEFAULT ((0)) NOT NULL, " & _
                    " Remark             NVARCHAR (255) NULL, " & _
                    " Div_Code           NVARCHAR (1) NOT NULL, " & _
                    " Site_Code          NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy         NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt            DATETIME NOT NULL, " & _
                    " U_AE               NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date          DATETIME NULL, " & _
                    " ModifiedBy         NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_ClassSectionOpenElectiveSemester PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_ClassSectionOpenElectiveSemester UNIQUE (ClassSection,StreamYearSemester), " & _
                    " CONSTRAINT FK_Sch_ClassSectionOpenElectiveSemester_Sch_ClassSection FOREIGN KEY (ClassSection) REFERENCES dbo.Sch_ClassSection (Code), " & _
                    " CONSTRAINT FK_Sch_ClassSectionOpenElectiveSemester_Sch_StreamYearSemester FOREIGN KEY (StreamYearSemester) REFERENCES dbo.Sch_StreamYearSemester (Code), " & _
                    " CONSTRAINT FK_Sch_ClassSectionOpenElectiveSemester_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_ClassSectionOpenElectiveSemester", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ClassSectionOpenElectiveSemester", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_ClassSectionOpenElectiveSemesterAdmission " & _
                    " ( " & _
                    " Code                   NVARCHAR (10) NOT NULL, " & _
                    " Sr                     INT NOT NULL, " & _
                    " AdmissionDocId         NVARCHAR (21) NOT NULL, " & _
                    " ClassSectionSubSection NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_ClassSectionOpenElectiveSemesterAdmission PRIMARY KEY (Code,Sr), " & _
                    " CONSTRAINT IX_Sch_ClassSectionOpenElectiveSemesterAdmission UNIQUE (Code,AdmissionDocId), " & _
                    " CONSTRAINT FK_Sch_ClassSectionOpenElectiveSemesterAdmission_Sch_ClassSectionOpenElectiveSemester FOREIGN KEY (Code) REFERENCES dbo.Sch_ClassSectionOpenElectiveSemester (Code), " & _
                    " CONSTRAINT FK_Sch_ClassSectionOpenElectiveSemesterAdmission_Sch_ClassSectionSubSection FOREIGN KEY (ClassSectionSubSection) REFERENCES dbo.Sch_ClassSectionSubSection (Code), " & _
                    " CONSTRAINT FK_Sch_ClassSectionOpenElectiveSemesterAdmission_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_ClassSectionOpenElectiveSemesterAdmission", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_ClassSectionOpenElectiveSemesterAdmission", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_FeeRefund " & _
                    " ( " & _
                    " DocId              NVARCHAR (21) NOT NULL, " & _
                    " Div_Code           NVARCHAR (1) NOT NULL, " & _
                    " Site_Code          NVARCHAR (2) NOT NULL, " & _
                    " V_Date             SMALLDATETIME NOT NULL, " & _
                    " V_Type             NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix           NVARCHAR (5) NOT NULL, " & _
                    " V_No               BIGINT NOT NULL, " & _
                    " FeeReceiveDocId    NVARCHAR (21) NOT NULL, " & _
                    " TotalLineAmount    FLOAT NOT NULL, " & _
                    " TotalLineNetAmount FLOAT NOT NULL, " & _
                    " IsManageFee        BIT CONSTRAINT DF_Sch_FeeRefund_IsManageFee DEFAULT ((0)) NOT NULL, " & _
                    " RefundAmount       FLOAT CONSTRAINT DF_Table_1_ReceiveAmount DEFAULT ((0)) NOT NULL, " & _
                    " ExcessRefund       FLOAT CONSTRAINT DF_Sch_FeeRefund_AdvanceCarriedForward DEFAULT ((0)) NOT NULL, " & _
                    " Remark             NVARCHAR (255) CONSTRAINT DF_Sch_FeeRefund_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy         NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt            DATETIME NOT NULL, " & _
                    " U_AE               NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date          DATETIME NULL, " & _
                    " ModifiedBy         NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_FeeRefund PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Sch_FeeRefund UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Sch_FeeRefund_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Sch_FeeRefund_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Sch_FeeRefund_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Sch_FeeRefund_Sch_FeeReceive FOREIGN KEY (FeeReceiveDocId) REFERENCES dbo.Sch_FeeReceive (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_FeeRefund", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_FeeRefund", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_FeeRefund1 " & _
                    " ( " & _
                    " Code        NVARCHAR (10) NOT NULL, " & _
                    " DocId       NVARCHAR (21) NOT NULL, " & _
                    " FeeReceive1 NVARCHAR (10) NOT NULL, " & _
                    " Amount      FLOAT CONSTRAINT DF_Sch_FeeRefund1_Amount DEFAULT ((0)) NOT NULL, " & _
                    " NetAmount   FLOAT CONSTRAINT DF_Sch_FeeRefund1_Amount1 DEFAULT ((0)) NOT NULL, " & _
                    " CONSTRAINT PK_Sch_FeeRefund1 PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_FeeRefund1 UNIQUE (DocId,FeeReceive1), " & _
                    " CONSTRAINT FK_Sch_FeeRefund1_Sch_FeeReceive1 FOREIGN KEY (FeeReceive1) REFERENCES dbo.Sch_FeeReceive1 (Code), " & _
                    " CONSTRAINT FK_Sch_FeeRefund1_Sch_FeeRefund FOREIGN KEY (DocId) REFERENCES dbo.Sch_FeeRefund (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_FeeRefund1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_FeeRefund1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_FeeRefundPaymentDetail " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " LedgerMDocId NVARCHAR (21) NULL, " & _
                    " CONSTRAINT PK_Sch_FeeRefundPaymentDetail PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeRefundPaymentDetail_PaymentDetail FOREIGN KEY (DocId) REFERENCES dbo.PaymentDetail (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeRefundPaymentDetail_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeRefundPaymentDetail_Sch_FeeRefund FOREIGN KEY (DocId) REFERENCES dbo.Sch_FeeRefund (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeRefundPaymentDetail_Sch_FeeRefund1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Sch_FeeRefund (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_FeeRefundPaymentDetail", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_FeeRefundPaymentDetail", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_Advance " & _
                    " ( " & _
                    " DocId          NVARCHAR (21) NOT NULL, " & _
                    " Div_Code       NVARCHAR (1) NOT NULL, " & _
                    " Site_Code      NVARCHAR (2) NOT NULL, " & _
                    " V_Date         SMALLDATETIME NOT NULL, " & _
                    " V_Type         NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix       NVARCHAR (5) NOT NULL, " & _
                    " V_No           BIGINT NOT NULL, " & _
                    " AdmissionDocId NVARCHAR (21) NOT NULL, " & _
                    " ReceiveAmount  FLOAT CONSTRAINT DF_Table_1_Advance DEFAULT ((0)) NOT NULL, " & _
                    " Remark         NVARCHAR (255) CONSTRAINT DF_Sch_AdvanceReceive_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy     NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt        DATETIME NOT NULL, " & _
                    " U_AE           NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date      DATETIME NULL, " & _
                    " ModifiedBy     NVARCHAR (10) NULL, " & _
                    " RowId          BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate     SMALLDATETIME NULL, " & _
                    " CONSTRAINT PK_Sch_Advance PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Sch_Advance UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_Sch_Advance_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Sch_Advance_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Sch_Advance_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Sch_Advance_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_Advance", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_Advance", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_AdvancePaymentDetail " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " LedgerMDocId NVARCHAR (21) NULL, " & _
                    " RowId        BIGINT IDENTITY NOT NULL, " & _
                    " UpLoadDate   SMALLDATETIME NULL, " & _
                    " CONSTRAINT PK_Sch_AdvancePaymentDetail PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Sch_AdvancePaymentDetail_Sch_Advance FOREIGN KEY (DocId) REFERENCES dbo.Sch_Advance (DocId), " & _
                    " CONSTRAINT FK_Sch_AdvancePaymentDetail_PaymentDetail FOREIGN KEY (DocId) REFERENCES dbo.PaymentDetail (DocId), " & _
                    " CONSTRAINT FK_Sch_AdvancePaymentDetail_Sch_Advance1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Sch_Advance (DocId), " & _
                    " CONSTRAINT FK_Sch_AdvancePaymentDetail_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_AdvancePaymentDetail", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_AdvancePaymentDetail", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_AdvanceOpeningLedgerM " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " LedgerMDocId NVARCHAR (21) NULL, " & _
                    " CONSTRAINT PK_Sch_AdvanceOpeningLedgerM PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Sch_AdvanceOpeningLedgerM_Sch_Advance FOREIGN KEY (DocId) REFERENCES dbo.Sch_Advance (DocId), " & _
                    " CONSTRAINT FK_Sch_AdvanceOpeningLedgerM_Sch_Advance1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Sch_Advance (DocId), " & _
                    " CONSTRAINT FK_Sch_AdvanceOpeningLedgerM_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_AdvanceOpeningLedgerM", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_AdvanceOpeningLedgerM", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_FeeReceiveAdvance " & _
                    " ( " & _
                    " FeeReceiveDocId NVARCHAR (21) NOT NULL, " & _
                    " Sr              INT NOT NULL, " & _
                    " AdvanceDocId    NVARCHAR (21) NOT NULL, " & _
                    " CONSTRAINT PK_Sch_FeeReceiveAdvance PRIMARY KEY (FeeReceiveDocId,Sr), " & _
                    " CONSTRAINT IX_Sch_FeeReceiveAdvance UNIQUE (FeeReceiveDocId,AdvanceDocId), " & _
                    " CONSTRAINT FK_Sch_FeeReceiveAdvance_Sch_FeeReceive FOREIGN KEY (FeeReceiveDocId) REFERENCES dbo.Sch_FeeReceive (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeReceiveAdvance_Sch_Advance FOREIGN KEY (AdvanceDocId) REFERENCES dbo.Sch_Advance (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_FeeReceiveAdvance", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_FeeReceiveAdvance", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Sch_RegistrationCancel " & _
                    " ( " & _
                    " DocId             NVARCHAR (21) NOT NULL, " & _
                    " Div_Code          NVARCHAR (1) NOT NULL, " & _
                    " Site_Code         NVARCHAR (2) NOT NULL, " & _
                    " V_Date            SMALLDATETIME NOT NULL, " & _
                    " V_Type            NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix          NVARCHAR (5) NOT NULL, " & _
                    " V_No              BIGINT NOT NULL, " & _
                    " RegistrationDocId NVARCHAR (21) NOT NULL, " & _
                    " RefundAmount      FLOAT NOT NULL, " & _
                    " Remark            NVARCHAR (255) CONSTRAINT DF_Sch_RegistrationCancel_Remark DEFAULT ('') NULL, " & _
                    " PreparedBy        NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt           DATETIME NOT NULL, " & _
                    " U_AE              NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date         DATETIME NULL, " & _
                    " ModifiedBy        NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_RegistrationCancel PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_Sch_RegistrationCancel UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT IX_Sch_RegistrationCancel_1 UNIQUE (RegistrationDocId), " & _
                    " CONSTRAINT FK_Sch_RegistrationCancel_Sch_Registration FOREIGN KEY (RegistrationDocId) REFERENCES dbo.Sch_Registration (DocId), " & _
                    " CONSTRAINT FK_Sch_RegistrationCancel_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_Sch_RegistrationCancel_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_Sch_RegistrationCancel_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_RegistrationCancel", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_RegistrationCancel", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_RegistrationCancelPaymentDetail " & _
                    " ( " & _
                    " DocId        NVARCHAR (21) NOT NULL, " & _
                    " LedgerMDocId NVARCHAR (21) NULL, " & _
                    " CONSTRAINT PK_Sch_RegistrationCancelPaymentDetail PRIMARY KEY (DocId), " & _
                    " CONSTRAINT FK_Sch_RegistrationCancelPaymentDetail_Sch_RegistrationCancel FOREIGN KEY (DocId) REFERENCES dbo.Sch_RegistrationCancel (DocId), " & _
                    " CONSTRAINT FK_Sch_RegistrationCancelPaymentDetail_PaymentDetail FOREIGN KEY (DocId) REFERENCES dbo.PaymentDetail (DocId), " & _
                    " CONSTRAINT FK_Sch_RegistrationCancelPaymentDetail_Sch_RegistrationCancel1 FOREIGN KEY (LedgerMDocId) REFERENCES dbo.Sch_RegistrationCancel (DocId), " & _
                    " CONSTRAINT FK_Sch_RegistrationCancelPaymentDetail_LedgerM FOREIGN KEY (LedgerMDocId) REFERENCES dbo.LedgerM (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_RegistrationCancelPaymentDetail", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_RegistrationCancelPaymentDetail", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_Department " & _
                    " ( " & _
                    " Code        NVARCHAR (8) NOT NULL, " & _
                    " Description NVARCHAR (50) NOT NULL, " & _
                    " ManualCode  NVARCHAR (20) NOT NULL, " & _
                    " Div_Code    NVARCHAR (1) NOT NULL, " & _
                    " Site_Code   NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy  NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt     DATETIME NOT NULL, " & _
                    " U_AE        NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date   DATETIME NULL, " & _
                    " ModifiedBy  NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_Department PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_Department UNIQUE (Description), " & _
                    " CONSTRAINT IX_Sch_Department_1 UNIQUE (ManualCode), " & _
                    " CONSTRAINT FK_Sch_Department_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_Department", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_Department", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_Area " & _
                    " ( " & _
                    " Code        NVARCHAR (8) NOT NULL, " & _
                    " Description NVARCHAR (50) NOT NULL, " & _
                    " ManualCode  NVARCHAR (20) NOT NULL, " & _
                    " Div_Code    NVARCHAR (1) NOT NULL, " & _
                    " Site_Code   NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy  NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt     DATETIME NOT NULL, " & _
                    " U_AE        NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date   DATETIME NULL, " & _
                    " ModifiedBy  NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_Area PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_Area UNIQUE (Description), " & _
                    " CONSTRAINT IX_Sch_Area_1 UNIQUE (ManualCode), " & _
                    " CONSTRAINT FK_Sch_Area_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_Area", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_Area", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_Route " & _
                    " ( " & _
                    " Code        NVARCHAR (8) NOT NULL, " & _
                    " Description NVARCHAR (50) NOT NULL, " & _
                    " ManualCode  NVARCHAR (20) NOT NULL, " & _
                    " Div_Code    NVARCHAR (1) NOT NULL, " & _
                    " Site_Code   NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy  NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt     DATETIME NOT NULL, " & _
                    " U_AE        NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date   DATETIME NULL, " & _
                    " ModifiedBy  NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_Route PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_Route UNIQUE (Description), " & _
                    " CONSTRAINT IX_Sch_Route_1 UNIQUE (ManualCode), " & _
                    " CONSTRAINT FK_Sch_Route_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_Route", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_Route", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_Route1 " & _
                    " ( " & _
                    " Code NVARCHAR (8) NOT NULL, " & _
                    " Sr   INT NOT NULL, " & _
                    " Area NVARCHAR (8) NOT NULL, " & _
                    " CONSTRAINT PK_Sch_Route1 PRIMARY KEY (Code,Sr), " & _
                    " CONSTRAINT IX_Sch_Route1 UNIQUE (Code,Area), " & _
                    " CONSTRAINT FK_Sch_Route1_Sch_Route FOREIGN KEY (Code) REFERENCES dbo.Sch_Route (Code), " & _
                    " CONSTRAINT FK_Sch_Route1_Sch_Area FOREIGN KEY (Area) REFERENCES dbo.Sch_Area (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_Route1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_Route1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_SessionProgrammeStreamOC " & _
                    " ( " & _
                    " Code                   NVARCHAR (8) NOT NULL, " & _
                    " SessionProgrammeStream NVARCHAR (8) NOT NULL, " & _
                    " OC                     NVARCHAR (10) NOT NULL, " & _
                    " FromDate               SMALLDATETIME NOT NULL, " & _
                    " UptoDate               SMALLDATETIME NULL, " & _
                    " Remark                 NVARCHAR (255) NULL, " & _
                    " Div_Code               NVARCHAR (1) NOT NULL, " & _
                    " Site_Code              NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy             NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt                DATETIME NOT NULL, " & _
                    " U_AE                   NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date              DATETIME NULL, " & _
                    " ModifiedBy             NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_SessionProgrammeStreamOC PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_SessionProgrammeStreamOC UNIQUE (SessionProgrammeStream,OC,FromDate), " & _
                    " CONSTRAINT IX_Sch_SessionProgrammeStreamOC_1 UNIQUE (SessionProgrammeStream,OC,UptoDate), " & _
                    " CONSTRAINT FK_Sch_SessionProgrammeStreamOC_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_Sch_SessionProgrammeStreamOC_Sch_SessionProgrammeStream FOREIGN KEY (SessionProgrammeStream) REFERENCES dbo.Sch_SessionProgrammeStream (Code), " & _
                    " CONSTRAINT FK_Sch_SessionProgrammeStreamOC_Pay_Employee FOREIGN KEY (OC) REFERENCES dbo.Pay_Employee (SubCode) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_SessionProgrammeStreamOC", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_SessionProgrammeStreamOC", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_AdmissionStatusChangeDetail " & _
                    " ( " & _
                    " DocId            NVARCHAR (21) NOT NULL, " & _
                    " Sr               INT NOT NULL, " & _
                    " StatusChangeDate SMALLDATETIME NOT NULL, " & _
                    " OldStatus        NVARCHAR (20) NOT NULL, " & _
                    " NewStatus        NVARCHAR (20) NOT NULL, " & _
                    " IsStreamChange   BIT CONSTRAINT DF_Sch_AdmissionStatusChangeDetail_IsStreamChange DEFAULT ((0)) NOT NULL, " & _
                    " CONSTRAINT PK_Sch_AdmissionStatusChangeDetail PRIMARY KEY (DocId,Sr), " & _
                    " CONSTRAINT FK_Sch_AdmissionStatusChangeDetail_Sch_Admission FOREIGN KEY (DocId) REFERENCES dbo.Sch_Admission (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_AdmissionStatusChangeDetail", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_AdmissionStatusChangeDetail", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_StudentLeave " & _
                    " ( " & _
                    " Code            NVARCHAR (10) NOT NULL, " & _
                    " Div_Code        NVARCHAR (1) NOT NULL, " & _
                    " Site_Code       NVARCHAR (2) NOT NULL, " & _
                    " V_Date          SMALLDATETIME NOT NULL, " & _
                    " AdmissionDocId  NVARCHAR (21) NOT NULL, " & _
                    " FromDate        SMALLDATETIME NOT NULL, " & _
                    " ToDate          SMALLDATETIME NOT NULL, " & _
                    " TotalDays       INT CONSTRAINT DF_Sch_StudentLeave_TotalDays DEFAULT ((0)) NOT NULL, " & _
                    " PurposeOfLeave  NVARCHAR (100) NOT NULL, " & _
                    " LeavePassedBy   NVARCHAR (10) NULL, " & _
                    " LeaveApprovedBy NVARCHAR (10) NULL, " & _
                    " Remark          NVARCHAR (255) NULL, " & _
                    " PreparedBy      NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt         DATETIME NOT NULL, " & _
                    " U_AE            NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date       DATETIME NULL, " & _
                    " ModifiedBy      NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_StudentLeave PRIMARY KEY (Code), " & _
                    " CONSTRAINT IX_Sch_StudentLeave UNIQUE (AdmissionDocId,FromDate,ToDate), " & _
                    " CONSTRAINT IX_Sch_StudentLeave_1 UNIQUE (AdmissionDocId,FromDate), " & _
                    " CONSTRAINT IX_Sch_StudentLeave_2 UNIQUE (AdmissionDocId,ToDate), " & _
                    " CONSTRAINT FK_Sch_StudentLeave_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId), " & _
                    " CONSTRAINT FK_Sch_StudentLeave_Pay_Employee FOREIGN KEY (LeavePassedBy) REFERENCES dbo.Pay_Employee (SubCode), " & _
                    " CONSTRAINT FK_Sch_StudentLeave_Pay_Employee1 FOREIGN KEY (LeaveApprovedBy) REFERENCES dbo.Pay_Employee (SubCode), " & _
                    " CONSTRAINT FK_Sch_StudentLeave_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_StudentLeave", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_StudentLeave", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_FeeReceiveAdjustableFeeReceive " & _
                    " ( " & _
                    " FeeReceiveDocId           NVARCHAR (21) NOT NULL, " & _
                    " Sr                        INT NOT NULL, " & _
                    " AdjustableFeeReceiveDocId NVARCHAR (21) NOT NULL, " & _
                    " CONSTRAINT PK_SchFeeReceive_AdjustableFeeReceive PRIMARY KEY (FeeReceiveDocId,Sr), " & _
                    " CONSTRAINT IX_SchFeeReceive_AdjustableFeeReceive UNIQUE (FeeReceiveDocId,AdjustableFeeReceiveDocId), " & _
                    " CONSTRAINT FK_Sch_FeeReceiveAdjustableFeeReceive_Sch_FeeReceive FOREIGN KEY (FeeReceiveDocId) REFERENCES dbo.Sch_FeeReceive (DocId), " & _
                    " CONSTRAINT FK_Sch_FeeReceiveAdjustableFeeReceive_Sch_FeeReceive1 FOREIGN KEY (AdjustableFeeReceiveDocId) REFERENCES dbo.Sch_FeeReceive (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_FeeReceiveAdjustableFeeReceive", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_FeeReceiveAdjustableFeeReceive", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Sch_StudentFamilyIncome " & _
                    " ( " & _
                    " GUID                 NVARCHAR (36) NOT NULL, " & _
                    " Student              NVARCHAR (10) NOT NULL, " & _
                    " AsOnDate             SMALLDATETIME NOT NULL, " & _
                    " FatherIncome         FLOAT CONSTRAINT DF_Sch_StudentFamilyIncome_FatherIncome DEFAULT ((0)) NOT NULL, " & _
                    " MotherIncome         FLOAT CONSTRAINT DF_Sch_StudentFamilyIncome_MotherIncome DEFAULT ((0)) NOT NULL, " & _
                    " FamilyIncome         FLOAT CONSTRAINT DF_Sch_StudentFamilyIncome_FamilyIncome DEFAULT ((0)) NOT NULL, " & _
                    " FatherOccupation     NVARCHAR (8) NULL, " & _
                    " FatherCompany        NVARCHAR (100) NULL, " & _
                    " FatherCompanyAddress NVARCHAR (100) NULL, " & _
                    " FatherDesignation    NVARCHAR (50) NULL, " & _
                    " MotherOccupation     NVARCHAR (8) NULL, " & _
                    " MotherCompany        NVARCHAR (100) NULL, " & _
                    " MotherCompanyAddress NVARCHAR (100) NULL, " & _
                    " MotherDesignation    NVARCHAR (50) NULL, " & _
                    " Div_Code             NVARCHAR (1) NOT NULL, " & _
                    " Site_Code            NVARCHAR (2) NOT NULL, " & _
                    " PreparedBy           NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt              DATETIME NOT NULL, " & _
                    " U_AE                 NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date            DATETIME NULL, " & _
                    " ModifiedBy           NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_StudentFamilyIncome PRIMARY KEY (GUID), " & _
                    " CONSTRAINT IX_Sch_StudentFamilyIncome UNIQUE (Student,AsOnDate), " & _
                    " CONSTRAINT FK_Sch_StudentFamilyIncome_Sch_Student FOREIGN KEY (Student) REFERENCES dbo.Sch_Student (SubCode), " & _
                    " CONSTRAINT FK_Sch_StudentFamilyIncome_Sch_Occupation FOREIGN KEY (FatherOccupation) REFERENCES dbo.Sch_Occupation (Code), " & _
                    " CONSTRAINT FK_Sch_StudentFamilyIncome_Sch_Occupation1 FOREIGN KEY (MotherOccupation) REFERENCES dbo.Sch_Occupation (Code), " & _
                    " CONSTRAINT FK_Sch_StudentFamilyIncome_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " ) "

            mQry1 = "INSERT INTO dbo.Sch_StudentFamilyIncome (GUID, Student, AsOnDate, FatherIncome, MotherIncome, FamilyIncome, FatherOccupation, FatherCompany, FatherCompanyAddress, FatherDesignation, MotherOccupation, MotherCompany, MotherCompanyAddress, MotherDesignation, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE) " & _
                        " SELECT NewId() AS Guid, S.SubCode AS Student, CASE WHEN A.V_Date IS NULL THEN '01/Apr/2010' ELSE A.V_Date END  AS AsOnDate, " & _
                        " S.FatherIncome, S.MotherIncome, S.FamilyIncome, S.Occupation AS FatherOccupation, S.FatherCompany, S.FatherCompanyAddress,  " & _
                        " S.FatherDesignation, S.MotherOccupation, S.MotherCompany, S.MotherCompanyAddress, S.MotherDesignation,  " & _
                        " Sg.Div_Code, Sg.Site_Code, Sg.U_Name As PreparedBy, Sg.U_EntDt, 'A' AS U_AE " & _
                        " FROM Sch_Student S " & _
                        " LEFT JOIN SubGroup Sg ON Sg.SubCode = S.SubCode  " & _
                        " LEFT JOIN Sch_Admission A ON A.Student = S.SubCode  "

            If Not AgL.IsTableExist("Sch_StudentFamilyIncome", AgL.GCn) Then
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                AgL.Dman_ExecuteNonQry(mQry1, AgL.GCn)
            End If

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_StudentFamilyIncome", AgL.GcnSite) Then
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                    AgL.Dman_ExecuteNonQry(mQry1, AgL.GcnSite)
                End If
            End If

            Try
                mQry = "CREATE TABLE dbo.Sch_DocumentIssue " & _
                        " ( " & _
                        " GUID               UNIQUEIDENTIFIER NOT NULL, " & _
                        " DocumentType       NVARCHAR (50) NOT NULL, " & _
                        " IssueDate          SMALLDATETIME NOT NULL, " & _
                        " AdmissionDocId     NVARCHAR (21) NULL, " & _
                        " SubCode            NVARCHAR (10) NOT NULL, " & _
                        " IssuedTo           NVARCHAR (100) NOT NULL, " & _
                        " StreamYearSemester NVARCHAR (10) NULL, " & _
                        " Subject            NVARCHAR (255) NULL, " & _
                        " BodyText           NVARCHAR (max) NULL, " & _
                        " FooterRemark       NVARCHAR (255) NULL, " & _
                        " Purpose            NVARCHAR (255) NULL, " & _
                        " Remark             NVARCHAR (255) NULL, " & _
                        " Div_Code           NVARCHAR (1) NOT NULL, " & _
                        " Site_Code          NVARCHAR (2) NOT NULL, " & _
                        " PreparedBy         NVARCHAR (10) CONSTRAINT DF_Sch_DocumentIssue_PreparedBy DEFAULT ('') NOT NULL, " & _
                        " U_EntDt            DATETIME NOT NULL, " & _
                        " U_AE               NVARCHAR (1) NOT NULL, " & _
                        " Edit_Date          DATETIME NULL, " & _
                        " ModifiedBy         NVARCHAR (10) NULL, " & _
                        " RowId              BIGINT IDENTITY NOT NULL, " & _
                        " UpLoadDate         SMALLDATETIME NULL, " & _
                        " ApprovedBy         NVARCHAR (10) NULL, " & _
                        " ApprovedDate       SMALLDATETIME NULL, " & _
                        " GPX1               NVARCHAR (255) NULL, " & _
                        " GPX2               NVARCHAR (255) NULL, " & _
                        " GPN1               FLOAT NULL, " & _
                        " GPN2               FLOAT NULL, " & _
                        " CONSTRAINT PK_Sch_DocumentIssue PRIMARY KEY (GUID), " & _
                        " CONSTRAINT FK_Sch_DocumentIssue_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId), " & _
                        " CONSTRAINT FK_Sch_DocumentIssue_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                        " CONSTRAINT FK_Sch_DocumentIssue_Sch_StreamYearSemester FOREIGN KEY (StreamYearSemester) REFERENCES dbo.Sch_StreamYearSemester (Code), " & _
                        " CONSTRAINT FK_Sch_DocumentIssue_SubGroup FOREIGN KEY (SubCode) REFERENCES dbo.SubGroup (SubCode) " & _
                        " )"

                If Not AgL.IsTableExist("Sch_DocumentIssue", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                If AgL.PubOfflineApplicable Then
                    If Not AgL.IsTableExist("Sch_DocumentIssue", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.Sch_TeacherAssessment " & _
                    " ( " & _
                    " Guid               UNIQUEIDENTIFIER NOT NULL, " & _
                    " Div_Code           NVARCHAR (1) NOT NULL, " & _
                    " Site_Code          NVARCHAR (2) NOT NULL, " & _
                    " AssessmentType     NVARCHAR (100) NOT NULL, " & _
                    " AssessmentDate     SMALLDATETIME NOT NULL, " & _
                    " Teacher            NVARCHAR (10) NOT NULL, " & _
                    " Session            NVARCHAR (8) NOT NULL, " & _
                    " StreamYearSemester NVARCHAR (10) NULL, " & _
                    " MaxPoints          INT CONSTRAINT DF_Sch_TeacherAssessment_PointsObtain DEFAULT ((0)) NOT NULL, " & _
                    " PreparedBy         NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt            DATETIME NOT NULL, " & _
                    " U_AE               NVARCHAR (1) NOT NULL, " & _
                    " Edit_Date          DATETIME NULL, " & _
                    " ModifiedBy         NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_Sch_TeacherAssessment PRIMARY KEY (Guid), " & _
                    " CONSTRAINT FK_Sch_TeacherAssessment_Pay_Employee FOREIGN KEY (Teacher) REFERENCES dbo.Pay_Employee (SubCode), " & _
                    " CONSTRAINT FK_Sch_TeacherAssessment_Sch_StreamYearSemester FOREIGN KEY (StreamYearSemester) REFERENCES dbo.Sch_StreamYearSemester (Code), " & _
                    " CONSTRAINT FK_Sch_TeacherAssessment_Sch_Session FOREIGN KEY (Session) REFERENCES dbo.Sch_Session (Code) " & _
                    " )"

            If Not AgL.IsTableExist("Sch_TeacherAssessment", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_TeacherAssessment", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_TeacherAssessment1 " & _
                    " ( " & _
                    " Guid           UNIQUEIDENTIFIER NOT NULL, " & _
                    " Sr             INT NOT NULL, " & _
                    " SubCode        NVARCHAR (10) NOT NULL, " & _
                    " AdmissionDocId NVARCHAR (21) NULL, " & _
                    " PointsObtain   INT CONSTRAINT DF_Sch_TeacherAssessment1_PointsObtain DEFAULT ((0)) NOT NULL, " & _
                    " CONSTRAINT PK_Sch_TeacherAssessment1 PRIMARY KEY (Guid,Sr), " & _
                    " CONSTRAINT IX_Sch_TeacherAssessment1 UNIQUE (Guid,SubCode), " & _
                    " CONSTRAINT FK_Sch_TeacherAssessment1_SubGroup FOREIGN KEY (SubCode) REFERENCES dbo.SubGroup (SubCode), " & _
                    " CONSTRAINT FK_Sch_TeacherAssessment1_Sch_Admission FOREIGN KEY (AdmissionDocId) REFERENCES dbo.Sch_Admission (DocId), " & _
                    " CONSTRAINT FK_Sch_TeacherAssessment1_Sch_TeacherAssessment FOREIGN KEY (Guid) REFERENCES dbo.Sch_TeacherAssessment (Guid) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_TeacherAssessment1", AgL.GCn) And AgL.IsTableExist("Sch_TeacherAssessment", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_TeacherAssessment1", AgL.GcnSite) And AgL.IsTableExist("Sch_TeacherAssessment", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_RegistrationMeritMarks " & _
                    " ( " & _
                    " DocId      NVARCHAR (21) NOT NULL, " & _
                    " ClassSr    INT NOT NULL, " & _
                    " Sr         INT NOT NULL, " & _
                    " Subject    NVARCHAR (100) CONSTRAINT DF_Table_1_Remark1_1 DEFAULT ('') NOT NULL, " & _
                    " Marks      FLOAT CONSTRAINT DF_Table_1_TotalPercentage DEFAULT ((0)) NOT NULL, " & _
                    " Percentage FLOAT CONSTRAINT DF_Table_1_PCMPercentage_1 DEFAULT ((0)) NOT NULL, " & _
                    " CONSTRAINT PK_Sch_RegistrationMeritMarks PRIMARY KEY (DocId,ClassSr,Sr), " & _
                    " CONSTRAINT IX_Sch_RegistrationMeritMarks UNIQUE (DocId,ClassSr,Subject), " & _
                    " CONSTRAINT FK_Sch_RegistrationMeritMarks_Sch_RegistrationAcademicDetail FOREIGN KEY (DocId,ClassSr) REFERENCES dbo.Sch_RegistrationAcademicDetail (DocId,Sr) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_RegistrationMeritMarks", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_RegistrationMeritMarks", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.Sch_RegistrationStatus " & _
                    " ( " & _
                    " DocId                  NVARCHAR (21) NOT NULL, " & _
                    " Sr                     INT NOT NULL, " & _
                    " Status                 NVARCHAR (50) NOT NULL, " & _
                    " StatusDate             SMALLDATETIME NOT NULL, " & _
                    " SessionProgrammeStream NVARCHAR (8) NULL, " & _
                    " CONSTRAINT PK_Sch_RegistrationStatus PRIMARY KEY (DocId,Sr), " & _
                    " CONSTRAINT IX_Sch_RegistrationStatus UNIQUE (DocId,Status,StatusDate), " & _
                    " CONSTRAINT FK_Sch_RegistrationStatus_Sch_Registration FOREIGN KEY (DocId) REFERENCES dbo.Sch_Registration (DocId), " & _
                    " CONSTRAINT FK_Sch_RegistrationStatus_Sch_SessionProgrammeStream FOREIGN KEY (SessionProgrammeStream) REFERENCES dbo.Sch_SessionProgrammeStream (Code) " & _
                    " )"
            If Not AgL.IsTableExist("Sch_RegistrationStatus", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                If Not AgL.IsTableExist("Sch_RegistrationStatus", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.TutorialAssignment_BLOB " & _
                    " ( " & _
                    " DocId       NVARCHAR (21) NOT NULL, " & _
                    " Sr          INT NOT NULL, " & _
                    " BLOB        IMAGE NULL, " & _
                    " Description VARCHAR (255) NULL, " & _
                    " FileName    VARCHAR (255) NULL, " & _
                    " CONSTRAINT PK_TutorialAssignment_BLOB PRIMARY KEY (DocId,Sr) " & _
                    " ) "

            If AgL.XNull(AgL.PubImageDBName).ToString.Trim <> "" Then
                If Not AgL.IsTableExist("TutorialAssignment_BLOB", AgL.GcnImage) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnImage)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateView()
        Dim mQry$ = ""
        '' Note Write Each View in Separate <Try---Catch> Section

        Try
            mQry = "CREATE VIEW dbo.ViewSch_SessionProgramme AS " & _
                    " SELECT  SP.*, S.ManualCode AS SessionManualCode, S.Description AS SessionDescription, S.StartDate AS SessionStartDate, S.EndDate AS SessionEndDate, P.Description AS ProgrammeDescription, P.ManualCode AS ProgrammeManualCode, P.ProgrammeDuration, P.Semesters AS ProgrammeSemesters, P.SemesterDuration AS ProgrammeSemesterDuration, P.ProgrammeNature , PN.Description AS ProgrammeNatureDescription  , P.ManualCode  +'/' + S.ManualCode   AS SessionProgramme " & _
                    " FROM Sch_SessionProgramme SP " & _
                    " LEFT JOIN Sch_Session S ON sp.Session =S.Code  " & _
                    " LEFT JOIN Sch_Programme P ON SP.Programme =P.Code " & _
                    " LEFT JOIN Sch_ProgrammeNature PN ON P.ProgrammeNature =PN.Code "

            AgL.IsViewExist("ViewSch_SessionProgramme", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_SessionProgramme", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_SessionProgrammeStream As " & _
                    " SELECT SPS.*, P.ManualCode + '/' +  S.ManualCode + '/' +  St.ManualCode AS SessionProgrammeStream, S.ManualCode AS SessionManualCode, " & _
                    " P.ManualCode AS ProgrammeManualCode, St.ManualCode AS StreamManualCode, SP.Div_Code , SP.Site_Code, Sp.SessionProgramme As SessionProgrammeDesc, " & _
                    " S.StartDate As SessionStartDate, Sp.Session AS SessionCode, Sp.Programme AS ProgrammeCode " & _
                    " FROM Sch_SessionProgrammeStream SPS " & _
                    " LEFT JOIN ViewSch_SessionProgramme SP ON SP.Code = SPS.SessionProgramme  " & _
                    " LEFT JOIN Sch_Session S ON SP.Session =S.Code  " & _
                    " LEFT JOIN Sch_Programme P ON SP.Programme =P.Code " & _
                    " LEFT JOIN Sch_Stream St ON SPS.Stream =St.Code "

            AgL.IsViewExist("ViewSch_SessionProgrammeStream", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_SessionProgrammeStream", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_SessionProgrammeStreamYear AS " & _
                    " SELECT SPSY.Code AS SessionProgrammeStreamYearCode, SPSY.SessionProgrammeStream AS SessionProgrammeStreamCode, SPS.Div_Code, SPS.Site_Code, " & _
                    " SPS.SessionProgrammeStream,SPSY.YearSerial,SPSY.YearStartDate, SPS.SessionProgrammeStream + '/' + CONVERT(NVARCHAR, SPSY.YearSerial) AS SessionProgrammeStreamYearDesc, " & _
                    " Convert(VARCHAR(4),DatePart(Year,SPSY.YearStartDate)) + '-' + Convert(VARCHAR(4),DatePart(Year,DateAdd(Day, -1,Dateadd(Year, 1, SPSY.YearStartDate)))) AS AcademicYearDesc  " & _
                    " FROM dbo.Sch_SessionProgrammeStreamYear SPSY " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStream SPS On  SPSY.SessionProgrammeStream = SPS.Code"

            AgL.IsViewExist("ViewSch_SessionProgrammeStreamYear", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_SessionProgrammeStreamYear", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_StreamYearSemester as " & _
                    " SELECT Sem.*, YEAR.SessionProgrammeStreamYearDesc + '/' +  S.Description  AS StreamYearSemesterDesc,  " & _
                    " Year.SessionProgrammeStream AS SessionProgrammeStreamDesc, Year.SessionProgrammeStreamCode , Sps.SessionProgramme AS SessionProgrammeCode,  " & _
                    " Sps.SessionManualCode , Sps.ProgrammeManualCode, Sps.StreamManualCode , Sps.Stream AS StreamCode, " & _
                    " Sp.Session AS SessionCode, Sp.Programme AS ProgrammeCode, Sp.SessionDescription , Sp.SessionStartDate , Sp.ProgrammeNatureDescription , Sp.ProgrammeNature As ProgrammeNatureCode, " & _
                    " Sp.SessionProgramme AS SessionProgrammeDesc, Year.SessionProgrammeStreamYearDesc , Year.YearSerial , Year.YearStartDate , S.SerialNo AS SemesterSerialNo, S.Description AS SemesterDesc, Year.AcademicYearDesc, Sp.Site_Code, Sp.Div_Code " & _
                    " FROM Sch_StreamYearSemester Sem  " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStreamYear Year ON sem.SessionProgrammeStreamYear =year.SessionProgrammeStreamYearCode  " & _
                    " LEFT JOIN Sch_Semester S ON Sem.Semester =S.Code " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStream Sps ON Year.SessionProgrammeStreamCode = Sps.Code  " & _
                    " LEFT JOIN ViewSch_SessionProgramme Sp ON Sps.SessionProgramme = Sp.Code  "

            AgL.IsViewExist("ViewSch_StreamYearSemester", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_StreamYearSemester", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_StreamYearSemesterFee as " & _
                    "SELECT SPSF.Code AS StreamYearSemesterFeeCode, SYS1.SessionProgrammeStreamYear, SPSY.SessionProgrammeStreamYearDesc  ,   SPSF.Fee, SPSF.Amount, S.ManualCode AS FeeManualCode, S.Name AS FeeName, SPSY.YearSerial , SPSY.YearStartDate, SPSY.Div_Code, SPSY.Site_Code   " & _
                    "FROM dbo.Sch_StreamYearSemesterFee SPSF " & _
                    "LEFT JOIN Sch_StreamYearSemester SYS1 ON SPSf.StreamYearSemester = SYS1.Code  " & _
                    "LEFT JOIN ViewSch_SessionProgrammeStreamYear SPSY ON SPSY.SessionProgrammeStreamYearCode = sys1.SessionProgrammeStreamYear  " & _
                    "LEFT JOIN Sch_Fee F ON SPSF.Fee =F.Code  " & _
                    "LEFT JOIN SubGroup S ON F.Code =S.SubCode "
            AgL.IsViewExist("ViewSch_StreamYearSemesterFee", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_StreamYearSemesterFee", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try

            mQry = "CREATE VIEW dbo.ViewSch_Student As " & _
                    " SELECT Sg.Name, Sg.DispName, Sg.ManualCode, Sg.Add1, Sg.add2, Sg.Add3, C.CityCode, " & _
                    " C.CityName, Sg.Site_Code, Sg.PIN, Sg.Phone, Sg.Mobile, Sg.FAX, Sg.EMail, Sg.PAN, " & _
                    " Sg.PAdd1, Sg.PAdd2, Sg.PAdd3, Sg.PCityCode , PC.CityName AS PCityName, Sg.PPin,  " & _
                    " Sg.PPhone, Sg.PMobile, Sg.PFax, Sg.FatherName, Sg.FatherNamePrefix, Sg.HusbandName,  " & _
                    " Sg.HusbandNamePrefix,  Sg.DOB, Sg.Remark, Sg.CommonAc,  S.*,  " & _
                    " Tc.CityName AS TCityName, C1.Description AS CategoryDesc, C1.ManualCode AS CategoryManualCode, R.Description AS ReligionDesc, " & _
                    " Fo.Description AS FatherOccupationDesc, Mo.Description AS MotherOccupationDesc " & _
                    " FROM Sch_Student S   " & _
                    " LEFT JOIN SubGroup Sg ON S.SubCode =Sg.SubCode    " & _
                    " LEFT JOIN City C ON Sg.CityCode =C.CityCode   " & _
                    " LEFT JOIN City PC ON Sg.PCityCode = PC.CityCode  " & _
                    " LEFT JOIN City Tc ON S.TCityCode = Tc.CityCode  " & _
                    " LEFT JOIN Sch_Category C1 ON S.Category = C1.Code  " & _
                    " LEFT JOIN Sch_Religion R ON S.Religion = R.Code  " & _
                    " LEFT JOIN Sch_Occupation Fo ON S.Occupation = Fo.Code  " & _
                    " LEFT JOIN Sch_Occupation Mo ON S.MotherOccupation = Mo.Code "

            AgL.IsViewExist("ViewSch_Student", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_Student", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_SemesterSubject As " & _
                    " SELECT Ss.*, S.Description AS SubjectDesc, S.DisplayName AS SubjectDisplayName, S.SubjectType , S.SubjectGroup AS SubjectGroupCode , Sg.Description AS SubjectGroupDesc, " & _
                    " Vs.StreamYearSemesterDesc , Vy.SessionProgrammeStreamYearCode , Vy.SessionProgrammeStreamCode , Vy.SessionProgrammeStream AS SessionProgrammeStreamDesc , Vy.SessionProgrammeStreamYearDesc, " & _
                    " Vs.Div_Code, Vs.Site_Code, Vs.SemesterStartDate  " & _
                    " FROM Sch_SemesterSubject Ss " & _
                    " LEFT JOIN Sch_Subject S ON Ss.Subject = S.Code " & _
                    " LEFT JOIN Sch_SubjectGroup Sg  ON S.SubjectGroup = Sg.Code " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Vs ON Ss.StreamYearSemester = Vs.Code " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStreamYear Vy ON Vs.SessionProgrammeStreamYear = Vy.SessionProgrammeStreamYearCode  "

            AgL.IsViewExist("ViewSch_SemesterSubject", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_SemesterSubject", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_Admission As " & _
                    " SELECT Adm.*, AdmE.EnrollmentNo , AdmR.RollNo, Vs.Name AS StudentName , Vs.DispName  AS StudentDispName, Vs.FatherName , Vs.MotherName , Vs.CityCode , Vs.CityName , Vs.PIN, Vs.CommonAc," & _
                    " VStream.SessionProgrammeStream AS SessionProgrammeStreamDesc, VStream.SessionManualCode , VStream.ProgrammeManualCode, VStream.StreamManualCode, " & _
                    " V1.FromStreamYearSemester, V1.PromotionDate, V1.ToStreamYearSemester, VStream.SessionProgramme As SessionProgrammeCode, VStream.SessionProgrammeDesc, VStream.SessionCode, VStream.ProgrammeCode,  " & _
                    " vS.Phone, vS.Mobile, R.ManualRegNo, Vs.ManualCode As StudentManualCode " & _
                    " FROM Sch_Admission Adm " & _
                    " LEFT JOIN Sch_AdmissionEnrollmentNo AS AdmE ON Adm.DocId = AdmE.DocId  " & _
                    " LEFT JOIN Sch_AdmissionRollNo AS AdmR ON Adm.DocId = AdmR.DocId  " & _
                    " LEFT JOIN ViewSch_Student Vs ON Adm.Student = Vs.SubCode  " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStream VStream ON Adm.SessionProgrammeStream = VStream.Code  " & _
                    " LEFT JOIN Sch_Registration R ON Adm.RegistrationDocId = R.DocId " & _
                    " LEFT JOIN (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.Sr = 1) V1 ON V1.AdmissionDocId = Adm.DocId "

            AgL.IsViewExist("ViewSch_Admission", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_Admission", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_AdmissionPromotion AS " & _
                    " SELECT V2.*, Csa.ClassSectionSubSectionCode, Csa.ClassSectionSubSectionDesc, Csa.SubSection, " & _
                    " Csa.ClassSection AS ClassSectionCode, Csa.ClassSectionDesc, Csa.Section " & _
                    " FROM ( " & _
                    " SELECT V1.*, " & _
                    " 	( " & _
                    " 	SELECT TOP 1 Sa.ClassSectionSemesterAdmissionCode  " & _
                    " 	FROM ViewSch_ClassSectionSemesterAdmission Sa " & _
                    " 	WHERE Sa.AdmissionDocId = V1.AdmissionDocId " & _
                    " 	AND Sa.SemesterStartDate <= V1.AdmissionDate " & _
                    " 	ORDER BY Sa.SemesterStartDate DESC " & _
                    " 	) AS ClassSectionSemesterAdmissionCode " & _
                    " FROM " & _
                    " ( " & _
                    " SELECT  CASE WHEN P.Sr = 1 THEN A.V_Date ELSE P1.PromotionDate  END AS AdmissionDate, " & _
                    " P.* " & _
                    " FROM Sch_AdmissionPromotion P " & _
                    " LEFT JOIN Sch_Admission A ON P.AdmissionDocId = A.DocId " & _
                    " LEFT JOIN Sch_AdmissionPromotion P1 ON P.AdmissionDocId = P1.AdmissionDocId AND P.FromStreamYearSemester = P1.ToStreamYearSemester AND P.Sr = P1.Sr +1 " & _
                    " ) AS V1 " & _
                    " ) AS V2 " & _
                    " LEFT JOIN ViewSch_ClassSectionSemesterAdmission Csa ON V2.ClassSectionSemesterAdmissionCode = CSa.ClassSectionSemesterAdmissionCode "

            AgL.IsViewExist("ViewSch_AdmissionPromotion", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_AdmissionPromotion", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_Fee As " & _
                    " SELECT F.*, S.CommonAc, S.ManualCode, S.name, S.DispName, S.groupCode, S.GroupNature, S.Nature, G.GroupName " & _
                    " FROM Sch_Fee F " & _
                    " LEFT JOIN SubGroup S ON F.Code =S.SubCode " & _
                    " LEFT JOIN AcGroup G ON S.GroupCode =G.GroupCode "

            AgL.IsViewExist("ViewSch_Fee", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_Fee", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE VIEW dbo.ViewSch_ClassSection As  " & _
                    " SELECT  S.*, C.SessionProgramme + '/' + S.Section AS ClassSectionDesc, " & _
                    " C.SessionProgramme AS SessionProgrammeDesc, C.Div_Code, C.Site_Code, IsNull(V.TotalSubsection,0) As TotalSubsection, " & _
                    " C.Session AS SessionCode, C.SessionManualCode, C.SessionDescription " & _
                    " FROM Sch_ClassSection S " & _
                    " LEFT JOIN ViewSch_SessionProgramme C ON S.SessionProgramme = C.Code " & _
                    " LEFT JOIN (SELECT S.ClassSection , IsNull(Count(S.Code),0) AS TotalSubsection  FROM Sch_ClassSectionSubSection S GROUP BY S.ClassSection ) V ON S.Code = V.ClassSection "

            AgL.IsViewExist("ViewSch_ClassSection", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_ClassSection", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE VIEW dbo.ViewSch_ClassSectionSemesterAdmission As  " & _
                    " SELECT Ssa.Code + convert(VARCHAR,Ssa.Sr) AS ClassSectionSemesterAdmissionCode, " & _
                    " Ssa.AdmissionDocId , Ssa.Sr, Ssa.ClassSectionSubSection AS ClassSectionSubSectionCode, Ssa.SectionLeftOnDate, S1.ClassSectionSubSectionDesc, S1.SubSection, " & _
                    " Csa.*, Cs.Code AS ClassSectionCode, Cs.ClassSectionDesc, " & _
                    " Cs.SessionProgramme AS SessionProgrammeCode,  Cs.Section, Cs.SessionProgrammeDesc  ,  " & _
                    " A.AdmissionID , A.StudentName , A.Student AS StudentCode, Sem.StreamYearSemesterDesc , " & _
                    " Sem.SessionProgrammeStreamYear AS SessionProgrammeStreamYearCode , " & _
                    " Sem.Semester AS SemesterCode, Sem.SessionProgrammeStreamCode , Sem.SessionProgrammeStreamDesc, " & _
                    " Sem.SemesterStartDate " & _
                    " FROM Sch_ClassSectionSemester Csa " & _
                    " LEFT JOIN Sch_ClassSectionSemesterAdmission Ssa ON Csa.Code = Ssa.Code  " & _
                    " LEFT JOIN ViewSch_ClassSection Cs ON Csa.ClassSection = Cs.Code " & _
                    " LEFT JOIN ViewSch_Admission A ON Ssa.AdmissionDocId = A.DocId " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON Csa.StreamYearSemester = sem.Code " & _
                    " LEFT JOIN ViewSch_ClassSectionSubSection S1 ON Ssa.ClassSectionSubSection = S1.Code "

            AgL.IsViewExist("ViewSch_ClassSectionSemesterAdmission", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_ClassSectionSemesterAdmission", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_AdmissionSubject As " & _
                    " SELECT V1.*, V2.StreamYearSemester, V2.StreamYearSemesterDesc, V2.SessionProgrammeStreamYearCode, V2.SessionProgrammeStreamCode, V2.SessionProgrammeStreamDesc, V2.SessionProgrammeStreamYearDesc, " & _
                    " V3.Subject AS SubjectCode, V3.ManualCode AS SubjectManualCode, V3.PaperID, V3.MinCreditHours, V3.IsElectiveSubject, V3.SubjectDesc, V3.SubjectDisplayName, V3.SubjectType, V3.SubjectGroupCode, V3.SubjectGroupDesc  " & _
                    " FROM  " & _
                    " ( " & _
                    " SELECT Ads.DocId AS AdmissionDocId, Ads.Sr , Ads.RowId, Ads.SemesterSubject,  " & _
                    " CASE WHEN Ads.OtherSemesterSubject IS NULL THEN Ads.SemesterSubject ELSE Ads.OtherSemesterSubject END OtherSemesterSubject,  " & _
                    " Convert(BIT,CASE WHEN Ads.OtherSemesterSubject IS NULL THEN 0 ELSE 1 END) IsSubjectSwap " & _
                    " FROM Sch_AdmissionSubject Ads " & _
                    " ) V1  " & _
                    " LEFT JOIN ViewSch_SemesterSubject V2 ON V1.SemesterSubject = V2.Code  " & _
                    " LEFT JOIN ViewSch_SemesterSubject V3 ON V1.OtherSemesterSubject = V3.Code  "

            AgL.IsViewExist("ViewSch_AdmissionSubject", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then AgL.IsViewExist("ViewSch_AdmissionSubject", AgL.GcnSite, True)
            If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_ClassSectionSubSection As " & _
                    " SELECT S.*, V1.ClassSectionDesc + '/' + S.SubSection As ClassSectionSubSectionDesc, " & _
                    " V1.SessionProgramme As SessionProgrammeCode, V1.Section, V1.IsOpenElectiveSection, V1.ClassSectionDesc, " & _
                    " V1.SessionProgrammeDesc, V1.Div_Code, V1.Site_Code " & _
                    " FROM Sch_ClassSectionSubSection S " & _
                    " LEFT JOIN ViewSch_ClassSection V1 ON S.ClassSection = V1.Code "
            AgL.IsViewExist("ViewSch_ClassSectionSubSection", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_ClassSectionSubSection", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_ClassSectionOpenElectiveSemesterAdmission As  " & _
                    " SELECT Ssa.Code + convert(VARCHAR,Ssa.Sr) AS ClassSectionOpenElectiveSemesterAdmissionCode, " & _
                    " Ssa.AdmissionDocId , Ssa.Sr, Ssa.ClassSectionSubSection AS ClassSectionSubSectionCode, Ssa.SectionLeftOnDate, S1.ClassSectionSubSectionDesc, S1.SubSection, " & _
                    " Csa.*, Cs.Code AS ClassSectionCode, Cs.ClassSectionDesc, " & _
                    " Cs.SessionProgramme AS SessionProgrammeCode,  Cs.Section, Cs.SessionProgrammeDesc, " & _
                    " A.AdmissionID , A.StudentName , A.Student AS StudentCode, Sem.StreamYearSemesterDesc ,  " & _
                    " Sem.SessionProgrammeStreamYear AS SessionProgrammeStreamYearCode ,  " & _
                    " Sem.Semester AS SemesterCode, Sem.SessionProgrammeStreamCode , Sem.SessionProgrammeStreamDesc, " & _
                    " Sem.SemesterStartDate " & _
                    " FROM Sch_ClassSectionOpenElectiveSemester Csa   " & _
                    " LEFT JOIN Sch_ClassSectionOpenElectiveSemesterAdmission Ssa ON Csa.Code = Ssa.Code    " & _
                    " LEFT JOIN ViewSch_ClassSection Cs ON Csa.ClassSection = Cs.Code   " & _
                    " LEFT JOIN ViewSch_Admission A ON Ssa.AdmissionDocId = A.DocId   " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON Csa.StreamYearSemester = sem.Code " & _
                    " LEFT JOIN ViewSch_ClassSectionSubSection S1 ON Ssa.ClassSectionSubSection = S1.Code  "

            AgL.IsViewExist("ViewSch_ClassSectionOpenElectiveSemesterAdmission", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_ClassSectionOpenElectiveSemesterAdmission", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_Registration As " & _
                    " SELECT R.*, Rc.DocId AS RegistrationCancelDocId, Rc.V_Date AS CancelVDate, Rc.RefundAmount, " & _
                    " Convert(BIT,CASE WHEN  Rc.DocId IS NULL THEN 0 ELSE 1 END) AS IsCancelled, " & _
                    " Rsd.Student AS StudentCode, Rsd.FirstName, Rsd.MiddleName, Rsd.LastName, Rsd.Add1, Rsd.Add2, Rsd.Add3, Rsd.CityCode, Rsd.PIN, " & _
                    " Rsd.Phone, Rsd.Mobile, Rsd.EMail, Rsd.Sex, Rsd.NationalityCode, Rsd.Occupation, Rsd.DOB, Rsd.FatherName, Rsd.FatherNamePrefix, " & _
                    " Rsd.MotherName, Rsd.MotherNamePrefix, Rsd.FamilyIncome, Rsd.Religion, Rsd.Category, Rsd.IsInternationalStudent, " & _
                    " Rsd.PassportNo, Rsd.VisaExpiryDate, Rsd.VisaType, Rsd.EnglishProficiency_IELTS, Rsd.EnglishProficiency_TOEFL, " & _
                    " Rsd.EnglishProficiency_Others, Rsd.BloodGroup, Rsd.FatherCompany, Rsd.FatherCompanyAddress, Rsd.FatherDesignation, " & _
                    " Rsd.MotherOccupation, Rsd.MotherCompany, Rsd.MotherCompanyAddress, Rsd.MotherDesignation, Rsd.MotherIncome, " & _
                    " Rsd.ScholarshipApplied, Rsd.MarkOfId, Rsd.TAdd1, Rsd.TAdd2, Rsd.TAdd3, Rsd.TCityCode, Rsd.TPin, Rsd.TPhone, Rsd.TMobile, Rsd.TFax, " & _
                    " Rsd.FatherIncome, Rsd.LocalGuardian, Rsd.PAdd1, Rsd.PAdd2, Rsd.PAdd3, Rsd.PCityCode, Rsd.PPin, Rsd.PPhone, Rsd.PMobile, Rsd.PFax, Rsd.IsNewStudent, " & _
                    " Convert(BIT,CASE WHEN A.DocId IS NULL THEN 0 ELSE 1 END) AS IsAdmited, A.DocId AS AdmissionDocId, A.V_Date AS AdmissionVDate, A.SessionProgrammeStream AS AdmissionSessionProgrammeStreamCode, " & _
                    " Sp.Session AS SessionCode, Sp.Programme AS ProgrammeCode, Sp.SessionStartDate " & _
                    " FROM Sch_Registration R " & _
                    " Left Join Sch_RegistrationStudentDetail AS Rsd On R.DocId = Rsd.DocId " & _
                    " LEFT JOIN Sch_RegistrationCancel Rc ON R.DocId = Rc.RegistrationDocId " & _
                    " LEFT JOIN Sch_Admission A ON R.DocId = A.RegistrationDocId " & _
                    " Left Join ViewSch_SessionProgramme Sp On R.SessionProgramme = Sp.Code "

            AgL.IsViewExist("ViewSch_Registration", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_Registration", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "SELECT A.*, A1.AdmissionDocId, A1.IsPresent, " & _
                    " ( " & _
                    " SELECT TOP 1 Oc.OC   " & _
                    " FROM Sch_SessionProgrammeStreamOC Oc  " & _
                    " WHERE Oc.SessionProgrammeStream = SemAdm.SessionProgrammeStreamCode  " & _
                    " AND A.A_Date >= Oc.FromDate " & _
                    " ORDER BY Oc.FromDate Desc " & _
                    " ) AS OcCode, Cs.ClassSectionDesc, Css.ClassSectionSubSectionDesc, Sg.Name AS TeacherName, Sg.DispName AS TeacherDispName, Ts.Description TimeSlotDesc, Ts.StartTime, Ts.EndTime " & _
                    " , Cr.Description ClassRoomDesc, Sub.Description AS SubjectName, Sub.DisplayName AS SubjectDisplayName , Sub.SubjectType , S.Name AS Site_Name " & _
                    " ,dbo.fn_GetCurrentSemester (A1.AdmissionDocId, A.A_Date) AS CurrentStreamYearSemesterCode  " & _
                    " FROM Sch_StudentAttendance A " & _
                    " LEFT JOIN Sch_StudentAttendance1 A1 ON A.Code = A1.Code  " & _
                    " LEFT JOIN SiteMast S On A.Site_Code = S.Code  " & _
                    " LEFT JOIN ViewSch_ClassSectionSemesterAdmission SemAdm ON A.ClassSection = SemAdm.Code AND A1.AdmissionDocId = SemAdm.AdmissionDocId  " & _
                    " LEFT JOIN ViewSch_ClassSection Cs ON A.ClassSection = Cs.Code  " & _
                    " LEFT JOIN ViewSch_ClassSectionSubSection Css ON A.ClassSectionSubSection = Css.Code  " & _
                    " LEFT JOIN SubGroup Sg ON A.Teacher = Sg.SubCode  " & _
                    " LEFT JOIN Sch_TimeSlot Ts ON A.TimeSlot = Ts.Code  " & _
                    " LEFT JOIN Sch_ClassRoom Cr ON A.ClassRoom = Cr.Code   " & _
                    " LEFT JOIN Sch_Subject Sub ON A.Subject = Sub.Code "
            mQry = "CREATE VIEW dbo.ViewSch_StudentAttendance1 As " & _
                    " SELECT V.*, Sub.ManualCode As SubjectManualCode, Sub.PaperID, SgO.Name AS OcName, SgO.DispName AS OcDispName, SgO.ManualCode AS OcManualCode " & _
                    " From (" & mQry & ") As V " & _
                    " LEFT JOIN SubGroup SgO ON V.OcCode = SgO.SubCode " & _
                    " LEFT JOIN ViewSch_SemesterSubject AS Sub  ON Sub.StreamYearSemester =  V.CurrentStreamYearSemesterCode AND Sub.Subject = V.Subject"

            AgL.IsViewExist("ViewSch_StudentAttendance1", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_StudentAttendance1", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_Department As " & _
                    " SELECT D.*, Dp.MainStreamCode AS ParentMainStreamCode, Dp.ManualCode AS ParentManualCode, Dp.Description AS ParentDesc, " & _
                    " (SELECT IsNull(Count(*),0) Cnt  " & _
                    " FROM Sch_Department Dc  " & _
                    " WHERE  " & _
                    " Left(Dc.MainStreamCode, Len(D.MainStreamCode)) = D.MainStreamCode  " & _
                    " AND Len(Dc.MainStreamCode) > Len(D.MainStreamCode) ) AS TotalChildren " & _
                    " FROM Sch_Department D " & _
                    " LEFT JOIN Sch_Department Dp ON D.ParentCode = Dp.Code "

            AgL.IsViewExist("ViewSch_Department", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_Department", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE VIEW dbo.ViewSch_AdmissionCurrentDetail As " & _
                    " SELECT A.DocId AS AdmissionDocId, A.Site_Code, Sm.Name AS Site_Name, A.Div_Code, A.AdmissionId, A.Status, " & _
                    " Sg.Name AS StudentName, Sg.DispName AS StudentDispName, Sg.ManualCode AS StudentManualCode, Sg.CommonAc, " & _
                    " Ae.EnrollmentNo,  Ar.RollNo,  Sg.FatherName, S.MotherName, Sg.Add1 AS Address1, Sg.Add2 AS Address2, Sg.Add3 AS Address3, City.CityName, " & _
                    " Sg.Phone, Sg.Mobile, Sg.EMail, Sg.Fax, " & _
                    " VSection.Code AS ClassSectionAsignCode, Cs.Code AS ClassSectionCode, Cs.ClassSectionDesc, SubSec.Code As ClassSectionSubSectionCode, SubSec.SubSection, " & _
                    " Sem.Code AS StreamYearSemesterCode, Sem.SessionProgrammeStreamYear AS SessionProgrammeStreamYearCode,  " & _
                    " Sem.Semester AS SemesterCode, Sem.SemesterStartDate, Sem.StreamYearSemesterDesc, Sem.SessionProgrammeStreamDesc,  " & _
                    " Sem.SessionProgrammeStreamCode, Sem.SessionProgrammeCode, Sem.SessionManualCode, Sem.ProgrammeManualCode, Sem.StreamManualCode,  " & _
                    " Sem.StreamCode, Sem.SessionCode, Sem.ProgrammeCode, Sem.SessionDescription, Sem.SessionStartDate,  " & _
                    " Sem.ProgrammeNatureDescription, Sem.ProgrammeNatureCode, Sem.SessionProgrammeDesc, Sem.SessionProgrammeStreamYearDesc,  " & _
                    " Sem.YearSerial, Sem.YearStartDate, Sem.SemesterSerialNo, Sem.SemesterDesc " & _
                    " FROM  " & _
                    " (SELECT * FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) vAp  " & _
                    " LEFT JOIN Sch_Admission A  ON A.DocId = vAp.AdmissionDocId   " & _
                    " LEFT JOIN SiteMast Sm ON A.Site_Code = Sm.Code   " & _
                    " LEFT JOIN Sch_Student S ON A.Student=S.SubCode     " & _
                    " LEFT JOIN SubGroup sg ON sg.SubCode =S.SubCode " & _
                    " LEFT JOIN City ON City.CityCode = Sg.CityCode     " & _
                    " LEFT JOIN Sch_AdmissionRollNo Ar ON A.DocId = Ar.DocId " & _
                    " LEFT JOIN Sch_AdmissionEnrollmentNo Ae On A.DocId = Ae.DocId " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON vAp.FromStreamYearSemester = Sem.Code     " & _
                    " Left Join  ( " & _
                    "   SELECT vCsa3.Code, vCsa3.AdmissionDocId, vCsa3.StreamYearSemester,    " & _
                    "   vCsa3.ClassSection, vCsa3.ClassSectionSubSectionCode AS ClassSectionSubSection,  " & _
                    "   vCsa3.SectionLeftOnDate   " & _
                    "   FROM ( " & _
                    "   		SELECT vCsa1.*  " & _
                    "   		FROM ViewSch_ClassSectionSemesterAdmission vCsa1   " & _
                    "   		INNER JOIN  (SELECT vCsa.ClassSection , Max(vCsa.SemesterStartDate) AS SemesterStartDate  FROM ViewSch_ClassSectionSemesterAdmission vCsa   GROUP BY vCsa.ClassSection " & _
                    "   	   ) vCsa2 ON vCsa1.ClassSection = vCsa2.ClassSection AND vCsa1.SemesterStartDate = vCsa2.SemesterStartDate) vCsa3  WHERE vCsa3.SectionLeftOnDate IS NULL   ) AS VSection ON Vap.AdmissionDocId = Vsection.AdmissionDocId   " & _
                    " LEFT JOIN ViewSch_ClassSection Cs ON VSection.ClassSection = Cs.Code   " & _
                    " LEFT JOIN Sch_ClassSectionSubSection SubSec ON VSection.ClassSectionSubSection = SubSec.Code   " & _
                    " WHERE A.Leavingdate IS NULL "

            AgL.IsViewExist("ViewSch_AdmissionCurrentDetail", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("ViewSch_AdmissionCurrentDetail", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Try
            'mQry = "CREATE VIEW dbo.<ViewName> As " & _
            '                    " SELECT Query "

            'AgL.IsViewExist("<View Name>", AgL.GCn, True)
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            'If AgL.PubOfflineApplicable Then AgL.IsViewExist("<View Name>", AgL.GcnSite, True)
            'If AgL.PubOfflineApplicable Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateVType()
        Try
            '===================================================< Registration Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RegistrationEntry, Academic_ProjLib.ClsMain.Cat_RegistrationEntry, "Registration Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RegistrationEntry, Academic_ProjLib.ClsMain.Cat_RegistrationEntry, Academic_ProjLib.ClsMain.NCat_RegistrationEntry, "Registration Entry", Academic_ProjLib.ClsMain.NCat_RegistrationEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Registration Cancel Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RegistrationCancelEntry, Academic_ProjLib.ClsMain.Cat_RegistrationCancelEntry, "Registration Cancel Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_RegistrationCancelEntry, Academic_ProjLib.ClsMain.Cat_RegistrationCancelEntry, Academic_ProjLib.ClsMain.NCat_RegistrationCancelEntry, "Registration Cancel Entry", Academic_ProjLib.ClsMain.NCat_RegistrationCancelEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Student Admission V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_StudentAdmission, Academic_ProjLib.ClsMain.Cat_StudentAdmission, "Student Admission", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_StudentAdmission, Academic_ProjLib.ClsMain.Cat_StudentAdmission, Academic_ProjLib.ClsMain.NCat_StudentAdmission, "Student Admission", Academic_ProjLib.ClsMain.NCat_StudentAdmission, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Fee Due V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeDue, Academic_ProjLib.ClsMain.Cat_FeeDue, "Fee Due Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeDue, Academic_ProjLib.ClsMain.Cat_FeeDue, Academic_ProjLib.ClsMain.NCat_FeeDue, "Fee Due Entry", Academic_ProjLib.ClsMain.NCat_FeeDue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_OpeningFeeDue, Academic_ProjLib.ClsMain.Cat_FeeDue, "Opening Fee Due", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_OpeningFeeDue, Academic_ProjLib.ClsMain.Cat_FeeDue, Academic_ProjLib.ClsMain.NCat_OpeningFeeDue, "Opening Fee Due", Academic_ProjLib.ClsMain.NCat_OpeningFeeDue, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Fee Receive Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeReceive, Academic_ProjLib.ClsMain.Cat_FeeReceive, "Fee Receive Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeReceive, Academic_ProjLib.ClsMain.Cat_FeeReceive, Academic_ProjLib.ClsMain.NCat_FeeReceive, "Fee Receive Entry", Academic_ProjLib.ClsMain.NCat_FeeReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Fee Refund Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeRefund, Academic_ProjLib.ClsMain.Cat_FeeRefund, "Fee Refund Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_FeeRefund, Academic_ProjLib.ClsMain.Cat_FeeRefund, Academic_ProjLib.ClsMain.NCat_FeeRefund, "Fee Refund Entry", Academic_ProjLib.ClsMain.NCat_FeeRefund, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Advance Receive Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_AdvanceReceive, Academic_ProjLib.ClsMain.Cat_AdvanceReceive, "Advance Receive Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_AdvanceReceive, Academic_ProjLib.ClsMain.Cat_AdvanceReceive, Academic_ProjLib.ClsMain.NCat_AdvanceReceive, "Advance Receive Entry", Academic_ProjLib.ClsMain.NCat_AdvanceReceive, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_OpeningAdvance, Academic_ProjLib.ClsMain.Cat_AdvanceReceive, "Opening Advance", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_OpeningAdvance, Academic_ProjLib.ClsMain.Cat_AdvanceReceive, Academic_ProjLib.ClsMain.NCat_OpeningAdvance, "Opening Advance", Academic_ProjLib.ClsMain.NCat_OpeningAdvance, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< **************************** >===================================================

            '===================================================< Tutorial Sheet V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.TutorialSheet, ClsMain.Temp_NCat.TutorialSheet, "Tutorial Sheet", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.TutorialSheet, ClsMain.Temp_NCat.TutorialSheet, ClsMain.Temp_NCat.TutorialSheet, "Tutorial Sheet", ClsMain.Temp_NCat.TutorialSheet, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ************** >===================================================

            '===================================================< Assignment Sheet V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.AssignmentSheet, ClsMain.Temp_NCat.AssignmentSheet, "Assignment Sheet", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.AssignmentSheet, ClsMain.Temp_NCat.AssignmentSheet, ClsMain.Temp_NCat.AssignmentSheet, "Assignment Sheet", ClsMain.Temp_NCat.AssignmentSheet, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ************** >===================================================

            '===================================================< Academic Progress Theory V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.AcademicProgressTheory, ClsMain.Temp_NCat.AcademicProgressTheory, "Academic Progress (Theory)", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.AcademicProgressTheory, ClsMain.Temp_NCat.AcademicProgressTheory, ClsMain.Temp_NCat.AcademicProgressTheory, "Academic Progress (Theory)", ClsMain.Temp_NCat.AcademicProgressTheory, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ************** >===================================================

            '===================================================< Academic Progress Laboratory V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.AcademicProgressLaboratory, ClsMain.Temp_NCat.AcademicProgressLaboratory, "Academic Progress (Laboratory)", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.AcademicProgressLaboratory, ClsMain.Temp_NCat.AcademicProgressLaboratory, ClsMain.Temp_NCat.AcademicProgressLaboratory, "Academic Progress (Laboratory)", ClsMain.Temp_NCat.AcademicProgressLaboratory, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ************** >===================================================

            '===================================================< Lecture Plan V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.LecturePlan, ClsMain.Temp_NCat.LecturePlan, "Lecture Plan", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.LecturePlan, ClsMain.Temp_NCat.LecturePlan, ClsMain.Temp_NCat.LecturePlan, "Lecture Plan", ClsMain.Temp_NCat.LecturePlan, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ************** >===================================================

            '===================================================< Lab Status V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.LabStatus, ClsMain.Temp_NCat.LabStatus, "Lab Status", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.LabStatus, ClsMain.Temp_NCat.LabStatus, ClsMain.Temp_NCat.LabStatus, "Lab Status", ClsMain.Temp_NCat.LabStatus, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ************** >===================================================

            '===================================================< Lab Work Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, ClsMain.Temp_NCat.LabWork, ClsMain.Temp_NCat.LabWork, "Lab Work", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, ClsMain.Temp_NCat.LabWork, ClsMain.Temp_NCat.LabWork, ClsMain.Temp_NCat.LabWork, "Lab Work", ClsMain.Temp_NCat.LabWork, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            '===================================================< ************** >===================================================

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AddNewVoucherReference()
        Try
            Dim VRefObj As New Academic_ProjLib.ClsMain.VRef_ReferenceTable

            'VRefObj.VRef_VehicleInsuranceClaimPayment()
            'AgL.AddNewVoucherReference(AgL.GCn, VRefObj.Code, VRefObj.Description, VRefObj.BoundField, VRefObj.DisplayField, VRefObj.IsDocId_DisplayField, VRefObj.HelpQuery, VRefObj.FilterField, VRefObj.SiteField, VRefObj.LastHiddenColumns)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateFunction()
        Dim mQry$ = "", bStrSch_AdmissionPromotionSql$ = ""
        '' Note Write Each Function in Separate <Try---Catch> Section

        Try
            bStrSch_AdmissionPromotionSql = " SELECT  CASE WHEN Ap.Sr = 1 THEN A.V_Date ELSE Ap1.PromotionDate  END AS AdmissionDate, Ap.* " & _
                                            " FROM Sch_AdmissionPromotion Ap  " & _
                                            " LEFT JOIN Sch_Admission A ON Ap.AdmissionDocId = A.DocId  " & _
                                            " LEFT JOIN Sch_AdmissionPromotion Ap1 ON Ap.AdmissionDocId = Ap1.AdmissionDocId AND Ap.FromStreamYearSemester = Ap1.ToStreamYearSemester AND Ap.Sr = Ap1.Sr +1  "


            mQry = "CREATE function fn_GetCurrentSemester " & _
                    " (@AdmissionDocId NVARCHAR(21), @EntryDate AS SMALLDATETIME)      returns NVARCHAR(10) " & _
                    " AS " & _
                    "   BEGIN  " & _
                    "   declare @CurrentSemester NVARCHAR(10); " & _
                    "   SELECT TOP 1 @CurrentSemester = P.FromStreamYearSemester  " & _
                    "   FROM (" & bStrSch_AdmissionPromotionSql & ") P   " & _
                    "   WHERE P.AdmissionDocId = @AdmissionDocId  " & _
                    "   AND @EntryDate BETWEEN P.AdmissionDate  " & _
                    "   AND CASE WHEN P.PromotionDate IS NULL THEN @EntryDate ELSE P.PromotionDate END  " & _
                    "   ORDER BY P.Sr DESC " & _
                    "   return @CurrentSemester " & _
                    "   end "
            AgL.IsFunctionExist("fn_GetCurrentSemester", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsFunctionExist("fn_GetCurrentSemester", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub CreateDatabase(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FSms_Event(MdlTable, "Sms_Event")

        FSch_TutorialAssignment(MdlTable, "Sch_TutorialAssignment")
        FSch_TutorialAssignment1(MdlTable, "Sch_TutorialAssignment1")
        FSch_TutorialAssignment2(MdlTable, "Sch_TutorialAssignment2")

        FSch_AcademicProgress(MdlTable, "Sch_AcademicProgress")
        FSch_AcademicProgress1(MdlTable, "Sch_AcademicProgress1")

        FSch_LecturePlan(MdlTable, "Sch_LecturePlan")
        FSch_LecturePlan1(MdlTable, "Sch_LecturePlan1")

        FSch_LabStatus(MdlTable, "Sch_LabStatus")
        FSch_LabStatus1(MdlTable, "Sch_LabStatus1")

        FSch_Experiment(MdlTable, "Sch_Experiment")
        FSch_LabWork(MdlTable, "Sch_LabWork")
        FSch_LabWork1(MdlTable, "Sch_LabWork1")

    End Sub

    Private Sub FSms_Event(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Event", AgLibrary.ClsMain.SQLDataType.nVarChar, 50, True)
        AgL.FSetColumnValue(MdlTable, "Message", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Category", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
    End Sub

    Private Sub FSch_TutorialAssignment(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "SessionProgramme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "StreamYearSemester", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "SubjectManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "Group", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Unit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Topic", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "Teacher", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CompletionDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "TotalQuestion", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalReference", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "TotalDocuments", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)

        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Teacher", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "SessionProgramme", "Code", "Sch_SessionProgramme")
        AgL.FSetFKeyValue(MdlTable, "StreamYearSemester", "Code", "Sch_StreamYearSemester")
        AgL.FSetFKeyValue(MdlTable, "Subject", "Code", "Sch_Subject")
    End Sub

    Private Sub FSch_TutorialAssignment1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Question", AgLibrary.ClsMain.SQLDataType.VarCharMax)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "Sch_TutorialAssignment")
    End Sub

    Private Sub FSch_TutorialAssignment2(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Reference", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "Sch_TutorialAssignment")
    End Sub

    Private Sub FSch_AcademicProgress(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "SessionProgramme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "StreamYearSemester", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "SubjectManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "FromDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ToDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "SessionProgramme", "Code", "Sch_SessionProgramme")
        AgL.FSetFKeyValue(MdlTable, "StreamYearSemester", "Code", "Sch_StreamYearSemester")
        AgL.FSetFKeyValue(MdlTable, "Subject", "Code", "Sch_Subject")
    End Sub

    Private Sub FSch_AcademicProgress1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Teacher", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "StreamYearSemester", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Session", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Programme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Stream", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Semester", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Year", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "SubjectManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "CumulativeQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "CoveredPer_Course_Lab", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "CoveredUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Checked_Assignment_Practical", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Checked_Tutorial_Quiz", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)

        AgL.FSetColumnValue(MdlTable, "HOD", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "SeniorObservation", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "Teacher", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "HOD", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "StreamYearSemester", "Code", "Sch_StreamYearSemester")
        AgL.FSetFKeyValue(MdlTable, "Session", "Code", "Session")
        AgL.FSetFKeyValue(MdlTable, "Programme", "Code", "Sch_Programme")
        AgL.FSetFKeyValue(MdlTable, "Stream", "Code", "Sch_Stream")
        AgL.FSetFKeyValue(MdlTable, "Semester", "Code", "Sch_Semester")
        AgL.FSetFKeyValue(MdlTable, "Subject", "Code", "Sch_Subject")
        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "Sch_AcademicProgress")
    End Sub

    Private Sub FSch_LecturePlan(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "SessionProgramme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "StreamYearSemester", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Session", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Programme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Stream", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Semester", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Year", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "SubjectManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Teacher", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EvaluationScheme", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "LecturePerWeek", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "Teacher", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "SessionProgramme", "Code", "Sch_SessionProgramme")
        AgL.FSetFKeyValue(MdlTable, "StreamYearSemester", "Code", "Sch_StreamYearSemester")
        AgL.FSetFKeyValue(MdlTable, "Session", "Code", "Session")
        AgL.FSetFKeyValue(MdlTable, "Programme", "Code", "Sch_Programme")
        AgL.FSetFKeyValue(MdlTable, "Stream", "Code", "Sch_Stream")
        AgL.FSetFKeyValue(MdlTable, "Semester", "Code", "Sch_Semester")
        AgL.FSetFKeyValue(MdlTable, "Subject", "Code", "Sch_Subject")
    End Sub
    Private Sub FSch_LabWork1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Student", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "AdmissionDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Experiment", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PerformedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "SubmissionDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "StreamYearSemester", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Session", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Programme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Stream", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Semester", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Year", AgLibrary.ClsMain.SQLDataType.Int)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "Sch_LabWork")
        AgL.FSetFKeyValue(MdlTable, "Student", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "AdmissionDocId", "DocId", "Sch_Admission")
        AgL.FSetFKeyValue(MdlTable, "Experiment", "Code", "Sch_Experiment")
        AgL.FSetFKeyValue(MdlTable, "StreamYearSemester", "Code", "Sch_StreamYearSemester")
        AgL.FSetFKeyValue(MdlTable, "Session", "Code", "Session")
        AgL.FSetFKeyValue(MdlTable, "Programme", "Code", "Sch_Programme")
        AgL.FSetFKeyValue(MdlTable, "Stream", "Code", "Sch_Stream")
        AgL.FSetFKeyValue(MdlTable, "Semester", "Code", "Sch_Semester")

    End Sub

    Private Sub FSch_LecturePlan1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "LectureNo", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "UnitCovered", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "TopicCovered", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "DeliveryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "PresentStudent", AgLibrary.ClsMain.SQLDataType.Int, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "SeniorObservation", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "Sch_LecturePlan")
    End Sub

    Private Sub FSch_LabStatus(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "SessionProgramme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "StreamYearSemester", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "SubjectManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)


        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "SessionProgramme", "Code", "Sch_SessionProgramme")
        AgL.FSetFKeyValue(MdlTable, "StreamYearSemester", "Code", "Sch_StreamYearSemester")
        AgL.FSetFKeyValue(MdlTable, "Subject", "Code", "Sch_Subject")

    End Sub

    Private Sub FSch_LabStatus1(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "ExperimentDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ExperimentName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "SessionProgramme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "StreamYearSemester", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Session", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Programme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Stream", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Semester", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Year", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "SubjectManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Teacher", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "StatusOfManuals", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "StatusOfExperimentalSetup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "SeniorObservation", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "DocId", "DocId", "Sch_LabStatus")
        AgL.FSetFKeyValue(MdlTable, "Teacher", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "SessionProgramme", "Code", "Sch_SessionProgramme")
        AgL.FSetFKeyValue(MdlTable, "StreamYearSemester", "Code", "Sch_StreamYearSemester")
        AgL.FSetFKeyValue(MdlTable, "Session", "Code", "Session")
        AgL.FSetFKeyValue(MdlTable, "Programme", "Code", "Sch_Programme")
        AgL.FSetFKeyValue(MdlTable, "Stream", "Code", "Sch_Stream")
        AgL.FSetFKeyValue(MdlTable, "Semester", "Code", "Sch_Semester")
        AgL.FSetFKeyValue(MdlTable, "Subject", "Code", "Sch_Subject")
    End Sub

    Private Sub FSch_Experiment(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
    End Sub

    Private Sub FSch_LabWork(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21, True)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Site_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 2)
        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_Prefix", AgLibrary.ClsMain.SQLDataType.nVarChar, 5)
        AgL.FSetColumnValue(MdlTable, "V_No", AgLibrary.ClsMain.SQLDataType.BigInt)
        AgL.FSetColumnValue(MdlTable, "V_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ReferenceNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)

        AgL.FSetColumnValue(MdlTable, "SessionProgramme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "StreamYearSemester", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "SubjectManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Session", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Programme", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Stream", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Semester", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "Year", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Subject", AgLibrary.ClsMain.SQLDataType.nVarChar, 8)
        AgL.FSetColumnValue(MdlTable, "SubjectManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Student", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "AdmissionDocId", AgLibrary.ClsMain.SQLDataType.nVarChar, 21)
        AgL.FSetColumnValue(MdlTable, "Teacher", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "HOD", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Experiment", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "SubmissionDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Remark", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApprovedDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "RowId", AgLibrary.ClsMain.SQLDataType.IDENTITY, , , False)
        AgL.FSetColumnValue(MdlTable, "UpLoadDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetFKeyValue(MdlTable, "V_Type", "V_Type", "Voucher_Type")
        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
        AgL.FSetFKeyValue(MdlTable, "SessionProgramme", "Code", "Sch_SessionProgramme")
        AgL.FSetFKeyValue(MdlTable, "StreamYearSemester", "Code", "Sch_StreamYearSemester")
        AgL.FSetFKeyValue(MdlTable, "Session", "Code", "Session")
        AgL.FSetFKeyValue(MdlTable, "Programme", "Code", "Sch_Programme")
        AgL.FSetFKeyValue(MdlTable, "Stream", "Code", "Sch_Stream")
        AgL.FSetFKeyValue(MdlTable, "Semester", "Code", "Sch_Semester")
        AgL.FSetFKeyValue(MdlTable, "Subject", "Code", "Sch_Subject")
        AgL.FSetFKeyValue(MdlTable, "Student", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "AdmissionDocId", "DocId", "Sch_Admission")
        AgL.FSetFKeyValue(MdlTable, "Teacher", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "HOD", "SubCode", "SubGroup")
        AgL.FSetFKeyValue(MdlTable, "Experiment", "Code", "Sch_Experiment")

    End Sub
#End Region
Public Structure StructTransportMember
        Public StrSubCode As String
        Public StrStuent As String
        Public StrEmployee As String
        Public StrMemberCardNo As String
        Public StrCardPrefix As String
        Public StrCardSrNo As Integer
        Public StrValidTillDate As String
        Public StrVehicle As String
        Public StrSeatno As String
        Public StrRoute As String
        Public StrPickupPoint As String
        Public StrUID As String
        Sub ProcBlankStruct()
            StrSubCode = ""
            StrStuent = ""
            StrEmployee = ""
            StrMemberCardNo = ""
            StrUID = ""
            StrCardPrefix = ""
            StrCardSrNo = 0
            StrValidTillDate = ""
            StrVehicle = ""
            StrSeatno = ""
            StrRoute = ""
            StrPickupPoint = ""
        End Sub
    End Structure
    
    Public Structure StructMessMember
        Public StrSubCode As String
        Public StrStuent As String
        Public StrEmployee As String
        Public StrMemberType As String
        Public StrJoinDate As String
        Sub ProcBlankStruct()
            StrSubCode = ""
            StrStuent = ""
            StrEmployee = ""
            StrMemberType = ""
            StrJoinDate = ""
        End Sub
    End Structure

    Public Structure StructLibraryMember
        Public StrSubCode As String
        Public StrStuent As String
        Public StrEmployee As String
        Public StrMemberCardNo As String
        Public StrMotherName As String
        Public StrMemberType As String
        Public StrAdmissionNo As String
        Public StrClass As String
        Public StrSession As String
        Public StrManualCode As String
        Public StrUID As String
        Public StrSiteCode As String

        Sub ProcBlankStruct()
            StrSubCode = ""
            StrStuent = ""
            StrEmployee = ""
            StrMemberCardNo = ""
            StrMotherName = ""
            StrMemberType = ""
            StrAdmissionNo = ""
            StrClass = ""
            StrSession = ""
            StrManualCode = ""
            StrUID = ""
        End Sub
    End Structure

    Public Function FunGetMemberCardNo(ByVal StrClass As String, ByVal StrSession As String, ByVal StrManualCode As String) As String
        Dim bStrReturn$ = "", bCondStr$ = " Where 1=1 ", mQry$ = ""
        Dim bLongMaxId As Long = 0

        Try
            If StrClass.Trim <> "" Then
                bCondStr += " And M.Class = " & AgL.Chk_Text(StrClass) & " "
                bStrReturn += IIf(bStrReturn.Trim = "", StrClass, "-" + StrClass)
            End If

            If StrSession.Trim <> "" Then
                bCondStr += " And M.Session = " & AgL.Chk_Text(StrSession) & " "
                bStrReturn += IIf(bStrReturn.Trim = "", StrSession, "-" + StrSession)
            End If


            mQry = "SELECT IsNull(Max(M.CardSrNo),0) AS MaxId " & _
                    " FROM Lib_Member M With (NoLock) " & bCondStr

            bLongMaxId = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) + 1

            bStrReturn += IIf(bStrReturn.Trim = "", bLongMaxId.ToString, "-" + bLongMaxId.ToString)

            If StrManualCode.Trim <> "" Then
                bStrReturn += IIf(bStrReturn.Trim = "", StrManualCode, "-" + StrManualCode)
            End If

        Catch ex As Exception
            bStrReturn = ""
        Finally
            FunGetMemberCardNo = bStrReturn
        End Try
    End Function

    Public Function FunSaveLibraryMember(ByVal ObjStructLibraryMember As StructLibraryMember, ByVal SqlConn As SqlConnection, ByVal SqlCmd As SqlCommand, ByVal StrEntryMode As String) As Boolean
        Dim bQry$ = "", bStrTableName$ = "", bStrSubCode$ = "", bStrUID$ = ""
        Dim bIntI% = 0
        Dim bBlnReturn As Boolean = False

        Try
            With ObjStructLibraryMember
                bStrSubCode = ObjStructLibraryMember.StrSubCode

                bStrUID = AgL.FunCreateSubGroup_Log(SqlConn, SqlCmd, bStrSubCode)
                If bStrUID.Trim = "" Then Err.Raise(1, , "")

                For bIntI = 0 To 1
                    If bIntI = 0 Then
                        bStrTableName = "Lib_Member_Log"
                    Else
                        bStrTableName = "Lib_Member"
                    End If

                    If AgL.StrCmp(StrEntryMode, "Add") Then
                        bQry = "INSERT INTO " & bStrTableName & " (" & _
                                " SubCode, Student, Employee, MemberCardNo, MotherName, MemberType, AdmissionNo, Class, Session, UID,Site_Code) " & _
                                " VALUES (" & AgL.Chk_Text(.StrSubCode) & ", " & _
                                " " & AgL.Chk_Text(.StrStuent) & ", " & _
                                " " & AgL.Chk_Text(.StrEmployee) & ", " & _
                                " " & AgL.Chk_Text(.StrMemberCardNo) & ", " & _
                                " " & AgL.Chk_Text(.StrMotherName) & ", " & _
                                " " & AgL.Chk_Text(.StrMemberType) & ", " & _
                                " " & AgL.Chk_Text(.StrAdmissionNo) & ", " & _
                                " " & AgL.Chk_Text(.StrClass) & ", " & _
                                " " & AgL.Chk_Text(.StrSession) & ", " & _
                                " " & AgL.Chk_Text(bStrUID) & ", " & _
                                " " & AgL.Chk_Text(.StrSiteCode) & " " & _
                                " ) "
                        AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)

                    Else
                        bQry = "UPDATE " & bStrTableName & " " & _
                                " SET SubCode = " & AgL.Chk_Text(.StrSubCode) & "," & _
                                " 	Student = " & AgL.Chk_Text(.StrStuent) & "," & _
                                " 	Employee = " & AgL.Chk_Text(.StrEmployee) & "," & _
                                " 	MemberCardNo = " & AgL.Chk_Text(.StrMemberCardNo) & "," & _
                                " 	MotherName = " & AgL.Chk_Text(.StrMotherName) & "," & _
                                " 	MemberType = " & AgL.Chk_Text(.StrMemberType) & "," & _
                                " 	AdmissionNo = " & AgL.Chk_Text(.StrAdmissionNo) & "," & _
                                " 	Class = " & AgL.Chk_Text(.StrClass) & "," & _
                                " 	Site_Code = " & AgL.Chk_Text(.StrSiteCode) & "," & _
                                " 	Session = " & AgL.Chk_Text(.StrSession) & " " & _
                                " WHERE UID = " & AgL.Chk_Text(bStrUID) & " "
                        AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)
                    End If

                Next
            End With


            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
            MsgBox(ex.Message)
        Finally
            FunSaveLibraryMember = bBlnReturn
        End Try
    End Function

    Public Function FunSaveTransportMember(ByVal ObjStructTransportMember As StructTransportMember, ByVal SqlConn As SqlConnection, ByVal SqlCmd As SqlCommand, ByVal StrEntryMode As String) As Boolean
        Dim bQry$ = "", bStrTableName$ = "", bStrSubCode$ = "", bStrUID$ = ""
        Dim bIntI% = 0
        Dim bBlnReturn As Boolean = False

        Try
            With ObjStructTransportMember
                bStrSubCode = ObjStructTransportMember.StrSubCode

                bStrUID = AgL.FunCreateSubGroup_Log(SqlConn, SqlCmd, bStrSubCode)
                If bStrUID.Trim = "" Then Err.Raise(1, , "")

                For bIntI = 0 To 1
                    If bIntI = 0 Then
                        bStrTableName = "Tp_Member_Log"
                    Else
                        bStrTableName = "Tp_Member"
                    End If

                    If AgL.StrCmp(StrEntryMode, "Add") Then
                        bQry = "INSERT INTO " & bStrTableName & " (" & _
                                " SubCode, Student, Employee, MemberCardNo,CardPrefix,CardSrNo,ValidTillDate,Vehicle,SeatNo,Route,PickUpPoint, UID) " & _
                                " VALUES (" & AgL.Chk_Text(.StrSubCode) & ", " & _
                                " " & AgL.Chk_Text(.StrStuent) & ", " & _
                                " " & AgL.Chk_Text(.StrEmployee) & ", " & _
                                " " & AgL.Chk_Text(.StrMemberCardNo) & ", " & _
                                 " " & AgL.Chk_Text(.StrCardPrefix) & ", " & _
                                " " & Val(.StrCardSrNo) & ", " & _
                                "  " & AgL.ConvertDate(.StrValidTillDate) & ", " & _
                                " " & AgL.Chk_Text(.StrVehicle) & ", " & _
                                  " " & AgL.Chk_Text(.StrSeatno) & ", " & _
                                " " & AgL.Chk_Text(.StrRoute) & ", " & _
                                " " & AgL.Chk_Text(.StrPickupPoint) & ", " & _
                                " " & AgL.Chk_Text(bStrUID) & " " & _
                                " ) "
                        AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)

                    Else
                        bQry = "UPDATE " & bStrTableName & " " & _
                                " SET SubCode = " & AgL.Chk_Text(.StrSubCode) & "," & _
                                " 	Student = " & AgL.Chk_Text(.StrStuent) & "," & _
                                " 	Employee = " & AgL.Chk_Text(.StrEmployee) & "," & _
                                " 	MemberCardNo = " & AgL.Chk_Text(.StrMemberCardNo) & "," & _
                                " CardPrefix = " & AgL.Chk_Text(.StrCardPrefix) & ", " & _
                                " CardSrNo = " & AgL.Chk_Text(.StrCardSrNo) & ", " & _
                                " ValidTillDate = " & AgL.ConvertDate(.StrValidTillDate) & ", " & _
                                " Vehicle = " & AgL.Chk_Text(.StrVehicle) & "," & _
                                " SeatNo = " & AgL.Chk_Text(.StrSeatno) & "," & _
                                " Route = " & AgL.Chk_Text(.StrRoute) & "," & _
                                " PickUpPoint = " & AgL.Chk_Text(.StrPickupPoint) & " " & _
                                " WHERE UID = " & AgL.Chk_Text(bStrUID) & " "
                        AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)
                    End If

                Next
            End With


            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
            MsgBox(ex.Message)
        Finally
            FunSaveTransportMember = bBlnReturn
        End Try
    End Function

    Public Function FunSaveMessMember(ByVal ObjStructMessMember As StructMessMember, ByVal SqlConn As SqlConnection, ByVal SqlCmd As SqlCommand, ByVal StrEntryMode As String) As Boolean
        Dim bQry$ = "", bStrTableName$ = "", bStrSubCode$ = "", bStrUID$ = ""
        Dim bIntI% = 0
        Dim bBlnReturn As Boolean = False

        Try
            With ObjStructMessMember
                bStrSubCode = ObjStructMessMember.StrSubCode

                bStrUID = AgL.FunCreateSubGroup_Log(SqlConn, SqlCmd, bStrSubCode)
                If bStrUID.Trim = "" Then Err.Raise(1, , "")

              
                bStrTableName = "Mess_Member"


                If AgL.StrCmp(StrEntryMode, "Add") Then
                    bQry = "INSERT INTO " & bStrTableName & " (" & _
                            " SubCode, Student, Employee, MemberType,JoiningDate) " & _
                            " VALUES (" & AgL.Chk_Text(.StrSubCode) & ", " & _
                            " " & AgL.Chk_Text(.StrStuent) & ", " & _
                            " " & AgL.Chk_Text(.StrEmployee) & ", " & _
                            " " & AgL.Chk_Text(.StrMemberType) & ", " & _
                            " " & AgL.Chk_Text(.StrJoinDate) & " " & _
                            " ) "
                    AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)

                Else
                    bQry = "UPDATE " & bStrTableName & " " & _
                            " SET SubCode = " & AgL.Chk_Text(.StrSubCode) & "," & _
                            " 	Student = " & AgL.Chk_Text(.StrStuent) & "," & _
                            " 	Employee = " & AgL.Chk_Text(.StrEmployee) & "," & _
                            " 	MemberType = " & AgL.Chk_Text(.StrMemberType) & "," & _
                            " JoiningDate = " & AgL.Chk_Text(.StrJoinDate) & " " & _
                            " WHERE SubCode = " & AgL.Chk_Text(.StrSubCode) & " "
                    AgL.Dman_ExecuteNonQry(bQry, SqlConn, SqlCmd)
                End If

            End With


            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
            MsgBox(ex.Message)
        Finally
            FunSaveMessMember = bBlnReturn
        End Try
    End Function
    Public Function FunCreateCity(ByVal StrCityName As String, ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As String
        Dim bStrCode$ = "", mQry$ = ""
        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            SqlCmd = AgL.Dman_Execute("Select CityCode From City With (NoLock) Where CityName='" & StrCityName & "' ", AgL.GcnRead)
            bStrCode = AgL.XNull(SqlCmd.ExecuteScalar())

            If bStrCode.Trim = "" Then
                bStrCode = AgL.GetMaxId("City", "CityCode", AgL.GcnRead, AgL.PubDivCode, AgL.PubSiteCode, 4, True, True, , AgL.Gcn_ConnectionString)

                mQry = "Insert Into City (CityCode, CityName, U_EntDt, U_Name, U_AE) Values(" & _
                        " '" & bStrCode & "', '" & StrCityName & "', " & _
                        " '" & Format(AgL.PubLoginDate, "Short Date") & "', '" & AgL.PubUserName & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)
            End If
        Catch ex As Exception
            bStrCode = ""
        Finally
            FunCreateCity = bStrCode
        End Try
    End Function

    Public Function FunUpdateCurrentSemester(ByVal StrAdmissionDocId As String, ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As Boolean
        Dim bBlnReturn As Boolean = False
        Dim mQry$ = ""

        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            mQry = "UPDATE Sch_Admission " & _
                    " SET Sch_Admission.CurrentSemester = V.CurrentSemester " & _
                    " FROM ( " & _
                    " 	SELECT P.AdmissionDocId, P.FromStreamYearSemester AS CurrentSemester  " & _
                    " 	FROM Sch_AdmissionPromotion P WITH (NoLock)  " & _
                    " 	WHERE 1=1 " & _
                    "   And P.AdmissionDocId = " & AgL.Chk_Text(StrAdmissionDocId) & " " & _
                    "   And P.PromotionDate IS NULL " & _
                    " 	) AS V " & _
                    " WHERE 1=1 " & _
                    " And Sch_Admission.DocId = " & AgL.Chk_Text(StrAdmissionDocId) & " " & _
                    " And Sch_Admission.DocId = V.AdmissionDocId " & _
                    " And IsNull(Sch_Admission.CurrentSemester,'') <> IsNull(V.CurrentSemester,'') "
            AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunUpdateCurrentSemester = bBlnReturn
        End Try
    End Function

    Public Function FunUpdateCurrentSemester(ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As Boolean
        Dim bBlnReturn As Boolean = False
        Dim mQry$ = ""

        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            mQry = "UPDATE Sch_Admission " & _
                    " SET Sch_Admission.CurrentSemester = V.CurrentSemester " & _
                    " FROM ( " & _
                    " 	SELECT P.AdmissionDocId, P.FromStreamYearSemester AS CurrentSemester  " & _
                    " 	FROM Sch_AdmissionPromotion P WITH (NoLock)  " & _
                    " 	WHERE 1=1 " & _
                    "   And P.PromotionDate IS NULL " & _
                    " 	) AS V " & _
                    " WHERE 1=1 " & _
                    " And Sch_Admission.DocId = V.AdmissionDocId " & _
                    " And IsNull(Sch_Admission.CurrentSemester,'') <> IsNull(V.CurrentSemester,'') "
            AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunUpdateCurrentSemester = bBlnReturn
        End Try
    End Function

    Public Function FunCreateExperiment(ByVal StrExperiment As String, ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing) As Boolean
        Dim mQry$ = ""
        Dim bBlnRetun As Boolean = False, bBlnCmdFlag As Boolean = False
        Dim mTrans As Boolean = False
        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = SqlConn.CreateCommand
                bBlnCmdFlag = False
            Else
                bBlnCmdFlag = True
            End If

            If StrExperiment.Trim <> "" Then
                If Not bBlnCmdFlag Then
                    SqlCmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    SqlCmd.Transaction = AgL.ETrans

                    mTrans = True
                End If

                mQry = "If Not EXISTS(SELECT * FROM Sch_Experiment WHERE Code = '" & StrExperiment & "') " & _
                            " INSERT INTO dbo.Sch_Experiment (Code) VALUES ('" & StrExperiment & "')"
                AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)

                If Not bBlnCmdFlag Then
                    AgL.ETrans.Commit()
                    mTrans = False
                End If

                bBlnRetun = True
            End If
        Catch ex As Exception

            MsgBox(ex.Message)
            bBlnRetun = False
            If Not bBlnCmdFlag Then
                If mTrans = True Then AgL.ETrans.Rollback()
            End If
        Finally
            FunCreateExperiment = bBlnRetun
        End Try
    End Function


    Public Function FunUpdateCurrentSection(ByVal SqlConn As SqlClient.SqlConnection, Optional ByVal SqlCmd As SqlClient.SqlCommand = Nothing, Optional ByVal StrAdmissionDocId As String = "") As Boolean
        Dim bBlnReturn As Boolean = False
        Dim mQry$ = "", bQryClassSection$ = "", bQryCurrentClassSection$ = ""

        Try
            If SqlCmd Is Nothing Then
                SqlCmd = New SqlClient.SqlCommand
                SqlCmd = AgL.GcnRead.CreateCommand
            End If

            bQryClassSection = "SELECT Ssa.ClassSectionSubSection, Ssa.SectionLeftOnDate, Ssa.AdmissionDocId, " & _
                                " Csa.ClassSection, Sem.SemesterStartDate " & _
                                " FROM Sch_ClassSectionSemester Csa WITH (NoLock) " & _
                                " LEFT JOIN Sch_ClassSectionSemesterAdmission Ssa WITH (NoLock) ON Csa.Code = Ssa.Code " & _
                                " LEFT JOIN Sch_ClassSection Cs WITH (NoLock) ON Csa.ClassSection = Cs.Code " & _
                                " LEFT JOIN Sch_StreamYearSemester Sem WITH (NoLock) ON Csa.StreamYearSemester = sem.Code " & _
                                " Where 1=1 " & _
                                " And " & IIf(StrAdmissionDocId.Trim = "", " 1=1 ", " Ssa.AdmissionDocId = " & AgL.Chk_Text(StrAdmissionDocId) & " ") & " "

            bQryCurrentClassSection = "SELECT vCsa1.AdmissionDocId, vCsa1.ClassSection As CurrentSection, vCsa1.ClassSectionSubSection As CurrentSubSection " & _
                                        " FROM (" & bQryClassSection & ") AS vCsa1  " & _
                                        " INNER JOIN ( " & _
                                        " 	SELECT vCsa.ClassSection , Max(vCsa.SemesterStartDate) AS SemesterStartDate  " & _
                                        " 	FROM  (" & bQryClassSection & ") AS vCsa  " & _
                                        " 	GROUP BY vCsa.ClassSection   " & _
                                        " 	) vCsa2 ON vCsa1.ClassSection = vCsa2.ClassSection AND vCsa1.SemesterStartDate = vCsa2.SemesterStartDate " & _
                                        " WHERE vCsa1.SectionLeftOnDate IS NULL "

            mQry = "UPDATE Sch_Admission " & _
                    " SET Sch_Admission.CurrentSection = V.CurrentSection, " & _
                    " Sch_Admission.CurrentSubSection = V.CurrentSubSection " & _
                    " FROM (" & bQryCurrentClassSection & ") AS V " & _
                    " WHERE 1=1 " & _
                    " And " & IIf(StrAdmissionDocId.Trim = "", " 1=1 ", " Sch_Admission.DocId = " & AgL.Chk_Text(StrAdmissionDocId) & " ") & " " & _
                    " And Sch_Admission.DocId = V.AdmissionDocId " & _
                    " And (IsNull(Sch_Admission.CurrentSection,'') <> IsNull(V.CurrentSection,'') Or IsNull(Sch_Admission.CurrentSubSection,'') <> IsNull(V.CurrentSubSection,'') ) "
            AgL.Dman_ExecuteNonQry(mQry, SqlConn, SqlCmd)

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunUpdateCurrentSection = bBlnReturn
        End Try
    End Function

End Class