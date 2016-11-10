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
    Private Const TeacherRegister As String = "TeacherRegister" ' Code by Satyam on 15/10/2010
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
    '**************************** Code By Satyam On 23/09/2010
    Dim mHelpAdmissionNatureQry$ = "Select Convert(BIT,0) As [Select],Code, ManualCode,Description From Sch_AdmissionNature "
    '**************************** Code By Satyam On 23/09/2010
    Dim mHelpToSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site/Branch Name] From SiteMast Where Code <>'" & AgL.PubSiteCode & "'"
    Dim mHelpBranchQry$ = "Select Convert(BIT,0) As [Select], Code, ManualCode, Description As [Stream Name] From Sch_Stream Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpCourseQry$ = "Select Convert(BIT,0) As [Select], code,SessionProgramme AS [Programme Name] FROM	ViewSch_SessionProgramme Where  " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpSessionQry$ = "Select Convert(BIT,0) As [Select], S.Code , S.ManualCode AS [Session Short Name], S.Description AS [Session] FROM Sch_Session S "
    Dim mHelpSemesterQry$ = "Select Convert(BIT,0) As [Select], Code, StreamYearSemesterDesc AS [Semester Name], V.SessionProgrammeDesc , V.StreamManualCode FROM ViewSch_StreamYearSemester V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpStudentQry$ = "Select Convert(BIT,0) As [Select], Subcode as code,Name AS [Student Name] FROM	ViewSch_Student Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpAdmissionIdQry$ = "Select Convert(BIT,0) As [Select], V.DocId as Code, V.AdmissionID, V.StudentName AS [Student Name] FROM ViewSch_Admission V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & ""

    Dim mHelpSessionProgrammeStreamQry$ = "Select Convert(BIT,0) As [Select], Code, SessionProgrammeStream AS [Session Programme Stream Name], V.ProgrammeManualCode , V.StreamManualCode,v.SessionManualCode FROM ViewSch_SessionProgrammeStream V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpStudentLeavQry$ = "Select Convert(BIT,0) As [Select], V.DocId as Code, V.AdmissionID, V.StudentName AS [Student Name] FROM ViewSch_Admission V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & "  and LeavingDate is not null "
    Dim mHelpProgrammeQry$ = "Select Convert(BIT,0) As [Select],  Code, Description as Programme  FROM Sch_Programme V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "

    Dim mHelpClassSectionQry$ = "Select Convert(BIT,0) As [Select],Code,ClassSectionDesc FROM ViewSch_ClassSection V Where " & AgL.PubSiteCondition("V.Site_Code", AgL.PubSiteCode) & "  "

    Dim mHelpClassSectionSubSectionQry$ = "SELECT Convert(BIT,0) As [Select], S.Code , S.SubSection As [Sub-Section], S.ClassSectionDesc As [Class/Section] " & _
                                            " FROM ViewSch_ClassSectionSubSection S " & _
                                            " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " "


    Dim mHelpTimeSlotQry$ = "Select Convert(BIT,0) As [Select],  Code,description AS [TIME Slot] FROM Sch_TimeSlot V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & "   "
    Dim mHelpSubjectQry$ = "Select Convert(BIT,0) As [Select],  Code,description AS [Subject] FROM Sch_Subject V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & "  "
    Dim mHelpFeeHeadQry$ = "SELECT Convert(BIT,0) As [Select],  F.Code, F.ManualCode AS [Fee Short Name], F.Name [Fee Head] FROM ViewSch_Fee F WHERE " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "F.Site_Code", AgL.PubSiteCode, "F.CommonAc") & " "
    Dim mHelpTeacherQry$ = "Select Convert(BIT,0) As [Select],  v.subcode AS Code,Sg.Name AS [Teacher Name] FROM Pay_Employee V LEFT JOIN SubGroup Sg ON v.SubCode=Sg.SubCode Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  AND IsNull(v.IsTeachingStaff,0) <> 0 "
    Dim mHelpOcQry$ = "SELECT Distinct Convert(BIT,0) As [Select], Oc.OC AS Code, Sg.Name As [OC Name] FROM Sch_SessionProgrammeStreamOC Oc LEFT JOIN SubGroup Sg ON Oc.OC = Sg.SubCode WHERE " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName

                Case TeacherRegister 'code by satyam on 15/10/2010 
                    Call ObjRFG.Ini_Grp()
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry$, "Subject Name")
                    ObjRFG.CreateHelpGrid(mHelpTeacherQry$, "Teacher Name")
                    '******************   End code by satyam on 15/10/2010 


            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName
            Case TeacherRegister
                Call ProcTeacherRegister() ' end code by Satyam on 15/10/2010
        End Select
    End Sub

#Region "Teacher Register" ' ****************** Code by Satyam on 15/10/2010 
    Private Sub ProcTeacherRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "

            If ObjRFG.GetWhereCondition("Sg.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Sg.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sg.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("E.Category", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("TS.Subject", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("TS.Subcode", 3)

            mQry = "SELECT TS.SubCode,TS.Subject,S.Description AS Sub_Desc,E.DateOfJoin,E.Sex,E.BloodGroup,E.Religion,E.Category,C.Description as Category_Desc, " & _
                   " Sg.Site_Code,sg.Name,sg.DispName,sg.Add1,sg.Add2,sg.Add3,sg.CityCode,city.CityName,sg.Phone,sg.Mobile,sg.EMail,sg.DOB,sg.FatherName, " & _
                   " Si.Name AS Site_Name,s.DisplayName AS Subject_Name,s.SubjectType,s.ManualCode AS Subject_Code " & _
                   " FROM Pay_TeacherSubject TS " & _
                   " LEFT JOIN Pay_Employee E ON E.SubCode=TS.SubCode " & _
                   " LEFT JOIN SubGroup SG ON SG.SubCode=E.SubCode " & _
                   " LEFT JOIN SiteMast Si ON Si.Code =Sg.Site_Code  " & _
                   " LEFT JOIN Sch_Category C ON C.Code=E.Category  " & _
                   " LEFT JOIN Sch_Subject S ON S.Code=TS.Subject " & _
                   " LEFT JOIN City ON city.CityCode=sg.CityCode " & _
                   " WHERE E.IsTeachingStaff=1 " & _
                   " " & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Academic_TeacherRegister" : RepTitle = "TEACHER REGISTER"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region ' ****************** End Code by Satyam on 15/10/2010 

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub

End Class
