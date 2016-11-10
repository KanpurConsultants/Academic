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
    Private Const RegistrationRegister As String = "RegistrationRegister"
    Private Const StudentRegister As String = "StudentRegister"
    Private Const CategoryWiseCourseWiseOutstanding As String = "CategoryWiseCourseWiseOutstanding"
    Private Const StudentOutstandingReport As String = "StudentOutstandingReport"
    Private Const StudentOutstandingReportCategoryWise As String = "StudentOutstandingReportCategoryWise"
    Private Const StudentOutstandingReportFeeHeadWise As String = "StudentOutstandingReportFeeHeadWise"
    Private Const AdditionalFeeFineReceiptReport As String = "Additional/FeeFineReceiptReport"
    Private Const FeeReceiptHeadWiseReport As String = "FeeReceiptHeadWiseReport"
    Private Const FeeReceiveReportSessionwise As String = "FeeReceiptReportSessionWise"
    Private Const FeeCollectionReport As String = "FeeCollectionReport"
    Private Const FeeHeadDetailReportYearWise As String = "FeeHeadDetailReportYearWise"
    Private Const FeeDetailReportCourseYearwise As String = "FeeDetailReportCourseYearWise"
    Private Const StudentLedger As String = "StudentLedger"
    Private Const FeeStructureReport As String = "FeeStructureReport"
    Private Const StudentCard As String = "StudentCard"
    Private Const StudentInformationCategorywiseReport As String = "StudentInformationCategorywiseReport"
    Private Const StudentInformation As String = "StudentInformation"
    Private Const StudentInformationCategorywiseDetail As String = "StudentInformationCategorywiseDetail"
    Private Const LeavingCancellationReport As String = "Leaving/CancellationReport"
    Private Const TransferCertificate As String = "TransferCertificate"
    Private Const CharacterCertificate As String = "CharacterCertificate"
    Private Const SemesterWiseSubjectReport As String = "SemesterWiseSubjectReport"
    Private Const IdentityCard As String = "IdentityCard"
    Private Const PaymentReceiptReport As String = "Payment/ReceiptReport"
    Private Const PaymentReceiptSummary As String = "Payment/ReceiptSummary"
    Private Const BankScrollList As String = "BankScrollList"
    Private Const AttendanceAndLectureDelivery As String = "AttendanceAndLectureDelivery"
    Private Const TeacherWiseStudentAbsentReport As String = "TeacherWiseStudentAbsentReport"
    Private Const CourseWiseVacancyReport As String = "CourseWiseVacancyReport"
    Private Const AttendanceBelowAGivenPecentage As String = "AttendanceBelowAGivenPecentage"
    Private Const AttendanceBetweenAGivenRange As String = "AttendanceBetweenAGivenRange"
    Private Const FeeCollectionSummaryStudentWise As String = "FeeCollectionSummaryStudentWise"
    Private Const FeeCollectionSummaryFeeHeadWise As String = "FeeCollectionSummaryFeeHeadWise"
    Private Const StudentLeftRegister As String = "StudentLeftRegister" '********** Code by Satyam on 20/09/2010
    Private Const AdmissionRegister As String = "AdmissionRegister" '********** Code by Satyam on 22/09/2010
    Private Const FeeRefundRegister As String = "FeeRefundRegister" ' Code by Satyam on 24/09/2010
    Private Const AdvanceReceiveRegister As String = "AdvanceReceiveRegister" 'end Code by Satyam on 24/09/2010
    Private Const TeacherRegister As String = "TeacherRegister" ' Code by Satyam on 15/10/2010
    Private Const StudentStatusChangeRegister As String = "StudentStatusChangeRegister" ' Code by Satyam on 23/03/2011
    Private Const RankMeritWiseRegistrationRegister As String = "RankMeritWiseRegistrationRegister" ' Code by Satyam on 25/03/2011
    Private Const StudentCurrentList As String = "StudentCurrentList" ' Code by Satyam on 25/03/2011
    Private Const RegistrationDetail As String = "RegistrationDetail"
    Private Const EmployeeIdentityCard As String = "EmployeeIdentityCard"
    Private Const StudentLabel As String = "StudentLabel"

    Private Const TutorialSheetRegister As String = "TutorialSheetRegister"
    Private Const AssignmentSheetRegister As String = "AssignmentSheetRegister"
    Private Const AcademicProgressTheoryRegister As String = "AcademicProgressTheoryRegister"
    Private Const AcademicProgressLaboratoryRegister As String = "AcademicProgressLaboratoryRegister"
    Private Const LecturePlanRegister As String = "LecturePlanRegister"
    Private Const LabStatusRegister As String = "LabStatusRegister"
    Private Const LabWorkRegister As String = "LabWorkRegister"


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

    Dim mHelpCategaryQry$ = "Select Convert(BIT,0) As [Select],Code, ManualCode As Category, Description As [Category Name] From Sch_Category "
    '**************************** Code By Satyam On 23/09/2010
    Dim mHelpAdmissionNatureQry$ = "Select Convert(BIT,0) As [Select],Code, ManualCode,Description From Sch_AdmissionNature "
    '**************************** Code By Satyam On 23/09/2010
    Dim mHelpToSiteQry$ = "Select Convert(BIT,0) As [Select], Code, Name As [Site/Branch Name] From SiteMast Where Code <>'" & AgL.PubSiteCode & "'"
    Dim mHelpBranchQry$ = "Select Convert(BIT,0) As [Select], Code, ManualCode As Stream, Description As [Stream Name] From Sch_Stream Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpCourseQry$ = "Select Convert(BIT,0) As [Select], code,SessionProgramme AS [Programme Name] FROM	ViewSch_SessionProgramme Where  " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpSessionQry$ = "Select Convert(BIT,0) As [Select], S.Code , S.ManualCode AS Session, S.Description AS [Session Name] FROM Sch_Session S "
    Dim mHelpSemesterQry$ = "Select Convert(BIT,0) As [Select], Code, StreamYearSemesterDesc AS Semester, V.SessionProgrammeDesc As [Session Programme], V.StreamManualCode FROM ViewSch_StreamYearSemester V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpStudentQry$ = "Select Convert(BIT,0) As [Select], Subcode as code,Name AS [Student Name] FROM	ViewSch_Student Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpAdmissionIdQry$ = "Select Convert(BIT,0) As [Select], V.DocId as Code, V.AdmissionID, V.StudentName AS [Student Name] FROM ViewSch_Admission V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & ""

    Dim mHelpSessionProgrammeStreamQry$ = "Select Convert(BIT,0) As [Select], Code, SessionProgrammeStream AS [Session Programme Stream], V.ProgrammeManualCode , V.StreamManualCode,v.SessionManualCode FROM ViewSch_SessionProgrammeStream V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpStudentLeavQry$ = "Select Convert(BIT,0) As [Select], V.DocId as Code, V.AdmissionID, V.StudentName AS [Student Name] FROM ViewSch_Admission V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & "  and LeavingDate is not null "
    Dim mHelpProgrammeQry$ = "Select Convert(BIT,0) As [Select],  Code, Description as Programme  FROM Sch_Programme V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "

    Dim mHelpClassSectionQry$ = "Select Convert(BIT,0) As [Select],Code,ClassSectionDesc [Section] FROM ViewSch_ClassSection V Where " & AgL.PubSiteCondition("V.Site_Code", AgL.PubSiteCode) & " And IsNull(V.IsOpenElectiveSection,0) = 0 "

    Dim mHelpClassSectionSubSectionQry$ = "SELECT Convert(BIT,0) As [Select], S.Code , S.SubSection As [Sub-Section], S.ClassSectionDesc As [Section] " & _
                                            " FROM ViewSch_ClassSectionSubSection S " & _
                                            " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                                            " And IsNull(S.IsOpenElectiveSection,0) = 0  "


    Dim mHelpOpenElectiveSectionQry$ = "Select Convert(BIT,0) As [Select],Code,ClassSectionDesc As [Open Elective Section] FROM ViewSch_ClassSection V Where " & AgL.PubSiteCondition("V.Site_Code", AgL.PubSiteCode) & " AND IsNull(V.IsOpenElectiveSection,0) <> 0 "

    Dim mHelpOpenElectiveSectionSubSectionQry$ = "SELECT Convert(BIT,0) As [Select], S.Code , S.SubSection As [Open Elective Sub-Section], S.ClassSectionDesc As [Open Elective Section] " & _
                                                    " FROM ViewSch_ClassSectionSubSection S " & _
                                                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                                                    " And IsNull(S.IsOpenElectiveSection,0) <> 0 "


    Dim mHelpRegistrationType$ = "Select Convert(BIT,0) As [Select],V_Type As Code, Description As Name, NCat From Voucher_Type " & _
              " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RegistrationEntry) & "" & _
              " "



    Dim mHelpTimeSlotQry$ = "Select Convert(BIT,0) As [Select],  Code,description AS [TIME Slot] FROM Sch_TimeSlot V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & "   "
    Dim mHelpSubjectQry$ = "Select Convert(BIT,0) As [Select],  Code,description AS [Subject] FROM Sch_Subject V Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & "  "
    Dim mHelpFeeHeadQry$ = "SELECT Convert(BIT,0) As [Select],  F.Code, F.ManualCode AS [Fee Short Name], F.Name [Fee Head] FROM ViewSch_Fee F WHERE " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "F.Site_Code", AgL.PubSiteCode, "F.CommonAc") & " "
    Dim mHelpTeacherQry$ = "Select Convert(BIT,0) As [Select],  v.subcode AS Code,Sg.Name AS [Teacher Name] FROM Pay_Employee V LEFT JOIN SubGroup Sg ON v.SubCode=Sg.SubCode Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & "  AND (IsNull(v.IsTeachingStaff,0)<>0 or IsNull(v.CanTakeClass,0)<>0) "
    Dim mHelpEmployeeQry$ = "Select Convert(BIT,0) As [Select],  v.Subcode AS Code,Sg.Name AS [Employee Name] FROM Pay_Employee V LEFT JOIN SubGroup Sg ON v.SubCode=Sg.SubCode Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
    Dim mHelpOcQry$ = "SELECT Distinct Convert(BIT,0) As [Select], Oc.OC AS Code, Sg.Name As [OC Name] FROM Sch_SessionProgrammeStreamOC Oc LEFT JOIN SubGroup Sg ON Oc.OC = Sg.SubCode WHERE " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
    '**************************** Code By Satyam On 02/03/2011
    Dim mStudentGroupQry$ = " SELECT Convert(BIT,0) As [Select],A.GroupCode AS Code, A.GroupName AS [A/c Group]  " & _
                            " FROM AcGroup A " & _
                            " WHERE LEFT(MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryDebtors & ")='" & AgLibrary.ClsConstant.MainGRCodeSundryDebtors & "' AND " & _
                            " MainGrLen > " & AgLibrary.ClsConstant.MainGRLenSundryDebtors & " AND AliasYn = 'N'"
    Dim mYesNoQry$ = " SELECT Convert(BIT,0) As [Select] ,'1' AS Code, 'Yes' AS Name " & _
                        " UNION ALL ( SELECT Convert(BIT,0) As [Select] ,'0' AS Code, 'No' AS Name)"




    Dim mStatusHelp$ = "SELECT Convert(BIT,0) As [Select],CODE ,NAME FROM (select " & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_Registered) & " as code," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_Registered) & " as name " & _
     "Union All select " & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_SeatAllotedByManagement) & " as code," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_SeatAllotedByManagement) & " as name " & _
     "Union All select " & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_SeatAllotedBySeeUptu) & " as code," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_SeatAllotedBySeeUptu) & " as name " & _
     "Union All select " & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_AdmittedByManagement) & " as code," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_AdmittedByManagement) & " as name " & _
     "Union All select " & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_AdmittedBySeeUptu) & " as code," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_AdmittedBySeeUptu) & " as name " & _
     "Union All select " & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_Cancelled) & " as code," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_Cancelled) & " as name)  AS V  "

    Dim mHelpSessionProgrammeQry$ = "Select Convert(BIT,0) As [Select], V.Code, V.SessionProgramme AS Name FROM ViewSch_SessionProgramme V WHERE " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "

    '**************************** End Code By Satyam On 02/03/2011
#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                Case RegistrationDetail
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")

                Case StudentRegister
                    StrArr1 = New String() {"With Picture", "With Out Picture"}
                    Call ObjRFG.Ini_Grp(, , , , "Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCityQry$, "City Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mStudentGroupQry, "A/C Group")

                Case RegistrationRegister
                    StrArr1 = New String() {"Yes", "No"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "With Detail Fees", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCityQry$, "City Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpRegistrationType$, "Registration Type")
                    '

                Case RankMeritWiseRegistrationRegister
                    StrArr1 = New String() {"Rank", "Merit %", "Registration No"}

                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Sort By", StrArr1, , "Rank From", , , "Rank To ", )
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCityQry$, "City Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream")
                    ObjRFG.CreateHelpGrid(mStatusHelp$, "Status")
                    ObjRFG.CreateHelpGrid(mHelpRegistrationType$, "Registration Type")

                Case StudentCurrentList
                    StrArr1 = New String() {"Semester Wise", "Section Wise"}
                    StrArr2 = New String() {"All", "Yes", "No"}
                    StrArr3 = New String() {"No", "Yes"}
                    Call ObjRFG.Ini_Grp(, , , , "Group By", StrArr1, , "Section Assign", StrArr2, , "Register", StrArr3)

                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Current Semester")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream ")
                    ObjRFG.CreateHelpGrid(mHelpClassSectionQry, "Section")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry, "Category")
                    ObjRFG.CreateHelpGrid(mStudentGroupQry, "A/C Group")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission Id")
                    ObjRFG.CreateHelpGrid(mHelpOpenElectiveSectionQry, "Open Elective Section")

                Case CategoryWiseCourseWiseOutstanding, StudentOutstandingReport, StudentOutstandingReportCategoryWise
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")

                Case StudentLedger
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")

                Case FeeStructureReport
                    Call ObjRFG.Ini_Grp()
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")

                Case StudentOutstandingReportFeeHeadWise, AdditionalFeeFineReceiptReport, FeeReceiptHeadWiseReport, _
                    FeeReceiveReportSessionwise, FeeHeadDetailReportYearWise, FeeDetailReportCourseYearwise

                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")

                Case FeeCollectionSummaryStudentWise, FeeCollectionSummaryFeeHeadWise
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")

                    If GRepFormName = FeeCollectionSummaryFeeHeadWise Then ObjRFG.CreateHelpGrid(mHelpFeeHeadQry, "Fee Head")

                Case FeeCollectionReport
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")

                Case StudentCard
                    Call ObjRFG.Ini_Grp()

                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpStudentQry$, "Student Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Current Semester")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream ")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry, "Category")

                Case IdentityCard
                    Call ObjRFG.Ini_Grp()

                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpStudentQry$, "Student Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Current Semester")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream ")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry, "Category")

                Case StudentInformationCategorywiseReport
                    Call ObjRFG.Ini_Grp()
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)

                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionProgrammeStreamQry$, "Session Programme Stream")

                Case StudentInformationCategorywiseDetail, StudentInformation
                    Call ObjRFG.Ini_Grp()

                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpStudentQry$, "StudentName")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")

                Case LeavingCancellationReport
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionProgrammeStreamQry$, "Session Programme Stream")

                Case TransferCertificate
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Section Assign", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionProgrammeStreamQry$, "Session Programme Stream")
                    ObjRFG.CreateHelpGrid(mHelpStudentLeavQry, "Student Name")

                Case CharacterCertificate
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Section Assign", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionProgrammeStreamQry$, "Session Programme Stream")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Student Name")


                Case SemesterWiseSubjectReport
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")

                Case PaymentReceiptReport, PaymentReceiptSummary
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")

                Case BankScrollList
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionProgrammeStreamQry$, "Session Programme Stream")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry, "Stream")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry, "Student Categary")

                Case AttendanceAndLectureDelivery, TeacherWiseStudentAbsentReport
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpClassSectionQry$, "Section")
                    ObjRFG.CreateHelpGrid(mHelpTimeSlotQry$, "Time Slot")
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry$, "Subject")
                    ObjRFG.CreateHelpGrid(mHelpTeacherQry$, "Teacher Name")
                    ObjRFG.CreateHelpGrid(mHelpOpenElectiveSectionQry, "Open Elective Section")

                Case CourseWiseVacancyReport
                    Call ObjRFG.Ini_Grp()
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpProgrammeQry$, "Programme")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry, "Stream")

                Case AttendanceBelowAGivenPecentage, AttendanceBetweenAGivenRange
                    StrArr3 = New String() {"No", "Yes"}
                    If GRepFormName = AttendanceBelowAGivenPecentage Then
                        Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Attendance < %", , , , , , "Subject Attendance", StrArr3)

                    ElseIf GRepFormName = AttendanceBetweenAGivenRange Then
                        Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Attendance >= %", , , "Attendance <= %", , , "Subject Attendance", StrArr3)
                    End If

                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpClassSectionQry$, "Section")
                    ObjRFG.CreateHelpGrid(mHelpTimeSlotQry$, "Time Slot")
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry$, "Subject")
                    ObjRFG.CreateHelpGrid(mHelpTeacherQry$, "Teacher Name")
                    ObjRFG.CreateHelpGrid(mHelpOcQry, "OC Name")
                    ObjRFG.CreateHelpGrid(mHelpOpenElectiveSectionQry, "Open Elective Section")

                Case StudentLeftRegister    '*************** code by satyam on 20/09/2010

                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")
                    '************** End code by satyam on 20/09/2010

                Case AdmissionRegister '*************** Code by Satyam on 22/09/2010
                    StrArr1 = New String() {"All", "Yes", "No"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Against Registration", StrArr1, , "Is Diploma Holder", StrArr1, , "Is Fee Wavier", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionNatureQry$, "Admission Nature")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")
                    ObjRFG.CreateHelpGrid(mStudentGroupQry, "A/C Group")
                    '************** End code by satyam on 22/09/2010

                Case FeeRefundRegister '*************** Code by Satyam on 24/09/2010
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")

                Case AdvanceReceiveRegister
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")
                    '************** End code by satyam on 24/09/2010

                Case TeacherRegister 'code by satyam on 15/10/2010 
                    Call ObjRFG.Ini_Grp()
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry$, "Subject Name")
                    ObjRFG.CreateHelpGrid(mHelpTeacherQry$, "Teacher Name")
                    '******************   End code by satyam on 15/10/2010 

                Case EmployeeIdentityCard
                    StrArr1 = New String() {"Yes", "No", "All"}
                    StrArr2 = New String() {"No", "Yes", "All"}
                    StrArr3 = New String() {"No", "Yes"}

                    Call ObjRFG.Ini_Grp(, , , , "Teaching Staff", StrArr1, , "Left Employee", StrArr2, , "Print Label", StrArr3)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpTeacherQry$, "Teacher Name")
                    ObjRFG.CreateHelpGrid(mHelpCityQry, "City")

                Case StudentStatusChangeRegister  'code by satyam on 23/03/2011 
                    StrArr1 = New String() {"All", Academic_ProjLib.ClsMain.AdmissionStatus_Ex, Academic_ProjLib.ClsMain.AdmissionStatus_ReAdmit, Academic_ProjLib.ClsMain.AdmissionStatus_Regular}
                    StrArr2 = New String() {"No", "Yes", "All"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, " New Status", StrArr1, , "Is Stream Changed?", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "New Stream")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")
                    '******************   End code by satyam on 23/03/2011 

                Case StudentLabel
                    StrArr1 = New String() {"No", "Yes", "All"}

                    Call ObjRFG.Ini_Grp(, , , , "Left Student", StrArr1)

                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Current Semester")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream ")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry, "Category")
                    ObjRFG.CreateHelpGrid(mStudentGroupQry, "A/C Group")
                    ObjRFG.CreateHelpGrid(mHelpCityQry, "City")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission Id")

                Case TutorialSheetRegister, AssignmentSheetRegister, LecturePlanRegister, LabStatusRegister, AcademicProgressTheoryRegister, AcademicProgressLaboratoryRegister, LabWorkRegister
                    StrArr1 = New String() {"Summary", "Detail"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Report Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionProgrammeQry$, "Programme")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Current Semester")
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry, "Subject")
                    ObjRFG.CreateHelpGrid(mHelpTeacherQry, "Teacher")

            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ObjRFG_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ObjRFG.BackColorChanged

    End Sub


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName

            Case StudentRegister
                ProcStudentRegister()

            Case RegistrationRegister
                ProcRegistrationRegister()

            Case RegistrationDetail
                procRegistrationDetail()

            Case CategoryWiseCourseWiseOutstanding, StudentOutstandingReport, StudentOutstandingReportCategoryWise
                ProcCategorywiseCoursewiseOutstanding()

            Case StudentOutstandingReportFeeHeadWise
                ProcStudentOutstandingReportFeeHeadWise()

            Case FeeCollectionSummaryStudentWise, FeeCollectionSummaryFeeHeadWise
                ProcFeeCollectionSummary()

            Case AdditionalFeeFineReceiptReport, FeeReceiptHeadWiseReport, FeeReceiveReportSessionwise
                ProcAdditionalFeeFineReceiptReport()

            Case FeeCollectionReport
                ProcFeeCollectionReport()

            Case FeeHeadDetailReportYearWise, FeeDetailReportCourseYearwise
                ProcFeeHeadDetailReportYearWise()

            Case StudentLedger
                ProcStudentLedger()

            Case FeeStructureReport
                ProcFeeStructureReport()

            Case StudentCard
                ProcStudentCard()

            Case IdentityCard
                ProcIdentityCard()

            Case StudentInformationCategorywiseReport
                ProcStudentInformationCategorywiseReport()

            Case StudentInformation, StudentInformationCategorywiseDetail
                ProcStudentInformation()

            Case LeavingCancellationReport
                ProcLeavingCancellationReport()

            Case TransferCertificate, CharacterCertificate
                ProcTransferCertificate()

            Case SemesterWiseSubjectReport
                ProcSemesterWiseSubjectReport()

            Case PaymentReceiptReport, PaymentReceiptSummary
                ProcPaymentReceiptReport()

            Case BankScrollList
                ProcBankScrollList()

            Case AttendanceAndLectureDelivery, TeacherWiseStudentAbsentReport
                ProcAttendanceAndLectureDelivery()

            Case CourseWiseVacancyReport
                ProcCourseWiseVacancyReport()

            Case AttendanceBelowAGivenPecentage, AttendanceBetweenAGivenRange
                Call ProcAttendanceBelowAGivenPecentage()

                '************************ code by Satyam on 20/09/2010
            Case StudentLeftRegister
                Call ProcStudentLeftRegister()

            Case AdmissionRegister
                Call ProcAdmissionRegister()
                '************************ end code by Satyam on 22/09/2010

            Case FeeRefundRegister ' code by Satyam on 24/09/2010
                Call ProcFeeRefundRegister()

            Case AdvanceReceiveRegister
                Call ProcAdvanceReceiveRegister() ' end code by Satyam on 24/09/2010

            Case TeacherRegister
                Call ProcTeacherRegister() ' end code by Satyam on 15/10/2010

            Case EmployeeIdentityCard
                Call ProcEmployeeIdentityCard()

            Case StudentStatusChangeRegister
                Call ProcStudentStatusChangeReport() ' code by Satyam on 23/03/2011

            Case RankMeritWiseRegistrationRegister
                procRankWiseRegistrationRegister()

            Case StudentCurrentList
                procStudentCurrentList()

            Case StudentLabel
                ProcStudentLabel()

                '************************ code by Rati on 14/06/2012

            Case TutorialSheetRegister, AssignmentSheetRegister
                ProcTutorialSheetRegister()

            Case AcademicProgressTheoryRegister, AcademicProgressLaboratoryRegister
                ProcAcademicProgressTheoryRegister()

            Case LecturePlanRegister
                ProcLecturePlanRegister()

            Case LabStatusRegister
                ProcLabStatusRegister()

            Case LabWorkRegister
                ProcLabWorkRegister()

                '************************ code by Rati on 14/06/2012
        End Select
    End Sub

#Region "Student Status Change Report" ' ****************** Code by Satyam on 23/03/2011 
    Private Sub ProcStudentStatusChangeReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where ASCD.StatusChangeDate Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, Academic_ProjLib.ClsMain.AdmissionStatus_Ex) Then
                mCondStr = mCondStr & " And ASCD.NewStatus = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.AdmissionStatus_Ex) & ""
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, Academic_ProjLib.ClsMain.AdmissionStatus_ReAdmit) Then
                mCondStr = mCondStr & " And ASCD.NewStatus = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.AdmissionStatus_ReAdmit) & ""
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) Then
                mCondStr = mCondStr & " And ASCD.NewStatus = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.AdmissionStatus_Regular) & ""
            Else
                mCondStr = mCondStr
            End If

            If AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "No") Then
                mCondStr = mCondStr & " And ASCD.IsStreamChange = 0 "
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Yes") Then
                mCondStr = mCondStr & " And ASCD.IsStreamChange = 1 "
            Else
                mCondStr = mCondStr
            End If

            If ObjRFG.GetWhereCondition("A.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("NVSYS.StreamCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.DocId", 2)

            mQry = " SELECT ASCD.DocId,ASCD.Sr  ,ASCD.StatusChangeDate,ASCD.OldStatus ,ASCD.NewStatus,ASCD.IsStreamChange, " & _
                    " ASCD.IsNewStatusAfterPromotion,ASCD.StreamYearSemester,ASCD.NewStreamYearSemester,SG.Name,A.DocId AS AdmissionDocId ,A.AdmissionId, " & _
                    " VSYS.StreamYearSemesterDesc,NVSYS.StreamYearSemesterDesc AS NewStreamYearSemesterDesc,A.Site_Code ,SM.Name AS Site_Name  " & _
                    " FROM Sch_AdmissionStatusChangeDetail ASCD " & _
                    " LEFT JOIN Sch_Admission A ON A.DocId=ASCD.DocId  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=A.Student  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester VSYS ON VSYS.Code=ASCD.StreamYearSemester  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester NVSYS ON NVSYS.Code=ASCD.NewStreamYearSemester " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=A.Site_Code   " & _
                    " " & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Academic_StudentStatusChangeReport" : RepTitle = "Student Status Change Report"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region ' ****************** End Code by Satyam on 23/03/2011 

#Region "Rank Wise Registration Register"
    Private Sub procRankWiseRegistrationRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = "", bStr$ = "", morderby$ = ""
            Dim mqry1$ = ""
            Dim subqry$ = ""
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo3_Control) Then Exit Sub

            mCondStr = " where Sr.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("SR.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("SR.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("SR.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("srd.citycode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("srd.Category", 2)


            If ObjRFG.GetCodeString(3) <> "" Then
                mCondStr = mCondStr & " and (Sps.stream in (" & Replace(ObjRFG.GetCodeString(3), "''", "'") & ")  or Sps1.stream in (" & Replace(ObjRFG.GetCodeString(3), "''", "'") & ")  )"
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("srst.Status", 4)

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Rank") Then
                mCondStr = mCondStr & " and isnull(SR.Rank_No,0)>" & Val(ObjRFG.ParameterCmbo2_Value) & " and  isnull(SR.Rank_No,0)<=" & Val(ObjRFG.ParameterCmbo3_Value) & ""
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Registration No") Then
            Else
                mCondStr = mCondStr & " and isnull(vRad.MeritPercentage,0)>" & Val(ObjRFG.ParameterCmbo2_Value) & " and  isnull(vRad.MeritPercentage,0)<=" & Val(ObjRFG.ParameterCmbo3_Value) & ""

            End If



           

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Rank") Then
                bStr = " SR.Rank_No "
                mCondStr = mCondStr & " and isnull(SR.Rank_No,0)>0 "
                morderby = "order by SR.Rank_No "
                'Registration No
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Registration No") Then

                bStr = "Sr.Rowid"
                morderby = "order by SR.Rowid   "
            Else
                bStr = " vRad.MeritPercentage "
                mCondStr = mCondStr & " and isnull(vRad.MeritPercentage,0)>0 "
                morderby = "order by  vRad.MeritPercentage  desc  "
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SR.V_Type", 5)
            mCondStr = mCondStr & " and ViewSch_Registration.RegistrationCancelDocId IS  NULL  "

            mQry = "SELECT Sr.Docid,vRad.MeritPercentage, vRad.MeritRemark," & AgL.V_No_Field("Sr.DocId") & "  As VoucherNo ,SR.V_Type,SR.V_No,SR.totalamount, " & _
                   " SR.totaldiscount,SR.totalnetAmount , SR.v_date,san.Description as AdmissionNature,(CASE WHEN isnull(SPS.streammanualcode,'')='' THEN " & _
                   " SPS1.streammanualcode ELSE  SPS.streammanualcode END) AS SessionProgrammeStream ,  SRD.FirstName as [First Name],SRD.MiddleName as [Middle Name], Srd.Lastname as [Last Name], SRD.Sex as [Male/Female]," & _
                   " SRD.Fathername as [Father Name],SRD.MotherName as [Mother Name], SRD.Add1 as [Address1],SRD.add2 as Address2,SRD.pin, city.cityname as [CityName], SRD.Mobile,Srd.Phone, " & _
                   " SRD.Dob,SRD.Email,SRD.BloodGroup, Sch_Category.ManualCode as Category , " & _
                   " sr.Rank_No,sr.RankRemark,sr.RollNo,pd.CashAmount,pd.BankAmount AS BankAmount1,pd.Chq_No AS chq1,pd.Chq_Date AS Chqdate1,b1.Bank_Name AS Bank1,pd.BankAmount2 AS BankAmount2,pd.Chq_No2 AS chq2,pd.Chq_Date2 AS Chqdate2,b2.Bank_Name AS Bank2, " & _
                   " pd.BankAmount3 AS BankAmount3,pd.Chq_No3 AS chq3,pd.Chq_Date3 AS Chqdate3,b3.Bank_Name AS Bank3,sr.remark,'" & ObjRFG.ParameterCmbo1_Value & "' AS SortByField, " & _
                   " " & bStr & " As OrderByField ,sr.Rank_No2,sr.RankRemark2,sr.RollNo2,srst.status as StuStatus,Srst.StatusDate,SR.RANKMARKS1 ,SR.RANKMARKS2,  srs.sr,SPS12.streammanualcode as StatusStre,sr.RankMaxMarks1,sr.RankMaxMarks2  " & _
                   " FROM Sch_Registration SR  left join ViewSch_Registration on sr.docid=ViewSch_Registration.docid " & _
                   " LEFT JOIN Sch_RegistrationStudentDetail srd ON SR.DocId=srd.DocId " & _
                   " LEFT JOIN ( " & _
                   " SELECT Rad.DocId , Max(Rad.PCMPercentage) AS MeritPercentage, Max(Rad.Remark) MeritRemark " & _
                   " FROM Sch_RegistrationAcademicDetail Rad WHERE IsNull(Rad.PCMPercentage,0) > 0 GROUP BY Rad.DocId) vRad ON vRad.DocId = Sr.DocId " & _
                   " LEFT JOIN Sch_AdmissionNature San ON SR.AdmissionNature=san.Code  " & _
                   " LEFT JOIN ViewSch_SessionProgrammeStream sps ON SR.SessionProgrammeStream=sps.Code " & _
                   " left join city on srd.citycode=city.citycode  " & _
                   " LEFT JOIN Sch_Category ON SRD.Category=Sch_Category.Code  " & _
                   " LEFT JOIN PaymentDetail pd ON sr.DocId=pd.DocId  " & _
                   " LEFT JOIN Bank b1 ON pd.Bank_Code=b1.Bank_Code " & _
                   " LEFT JOIN Bank b2 ON pd.Bank_Code2=b2.Bank_Code " & _
                   " LEFT JOIN Bank b3 ON pd.Bank_Code3=b3.Bank_Code " & _
                   " LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId " & _
                   " LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code left join Sch_RegistrationStatus srst On   sr.DocId = srst.DocId  LEFT JOIN ViewSch_SessionProgrammeStream sps12 ON srst.SessionProgrammeStream=sps12.Code  " & mCondStr & "  " & morderby & ""

            mqry1 = "SELECT 	DocId,	ClassSr,	Sr,	Subject,	Marks,	Percentage FROM Sch_RegistrationMeritMarks"


            DsRep = AgL.FillData(mQry, AgL.GCn)
            DsRep1 = AgL.FillData(mqry1, AgL.GCn)
            RepName = "Academic_main_RankWise_RegistrationRegister" : RepTitle = "Registration Register "



            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.SubReport1DataSet = DsRep1
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try


    End Sub
#End Region

#Region "Student Current List"
    Private Sub procStudentCurrentList()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim bGroupByVar$ = ""

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Semester Wise") Then
                bGroupByVar = "Sem.StreamYearSemesterDesc"
            Else
                bGroupByVar = "Cs.ClassSectionDesc"
            End If

            If AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "No") Then
                mCondStr = mCondStr & " AND VSection.Code IS NULL"
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Yes") Then
                mCondStr = mCondStr & " AND VSection.Code IS NOT NULL "
            End If

            If ObjRFG.GetWhereCondition("A.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.Code", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.Streamcode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("CS.Code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Category", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("sg.GroupCode", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.DocId", 7)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ocs.Code", 8)

            mQry = "SELECT Cs.ClassSectionDesc, Sem.SessionProgrammeDesc, " & _
                   " SubSec.SubSection,  A.StudentName,  " & _
                   " A.Site_Code ,  A.Status AS CurrentStatus, A.AdmissionId,A.EnrollmentNo, " & _
                   " RollNo,A.StudentDispName,A.FatherName,  A.MotherName,A.CityName,   " & _
                   " Sem.StreamYearSemesterDesc AS CurrentStreamYearSemester, " & _
                   " " & bGroupByVar & " AS bGroupByVar, sem.code, VSection.Code AS ClassSectionAsignCode, " & _
                   " Sg.ManualCode, oCs.ClassSectionDesc As OpenElectiveSectionDesc, oSubSec.SubSection As OpenElectiveSubSection, " & _
                   " SgI.Photo, Sg.Add1, Sg.Add2, Sg.Add3, Sg.PIN, Sg.Phone, Sg.Mobile, Sg.FAX, Sg.EMail, " & _
                   " Sg.DOB, Sg.Remark, Sg.LogInUser, Sg.Sex, " & _
                   " Religion.Description AS Religion, Cat.Description AS CategoryDesc, Cat.ManualCode AS CategoryShortName, " & _
                   " S.MotherIncome, S.FatherIncome, S.FamilyIncome " & _
                   " FROM (SELECT * FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) vAp  " & _
                   " LEFT JOIN ViewSch_Admission A  ON A.DocId = vAp.AdmissionDocId   " & _
                   " LEFT JOIN Sch_Student S ON A.Student=S.SubCode   " & _
                   " LEFT JOIN SubGroup sg ON sg.SubCode =S.SubCode   " & _
                   " LEFT JOIN SubGroup_Image SgI ON Sg.SubCode = SgI.SubCode " & _
                   " Left Join city on Sg.citycode=city.citycode " & _
                   " LEFT JOIN Sch_Category Cat ON S.Category=Cat.Code " & _
                   " LEFT JOIN Sch_Religion Religion ON Religion.Code = S.Religion " & _
                   " LEFT JOIN ViewSch_StreamYearSemester Sem ON vAp.FromStreamYearSemester = Sem.Code " & _
                   " Left Join " & _
                   " ( " & _
                   " SELECT vCsa3.Code, vCsa3.AdmissionDocId, vCsa3.StreamYearSemester,   vCsa3.ClassSection, vCsa3.ClassSectionSubSectionCode AS ClassSectionSubSection, vCsa3.SectionLeftOnDate " & _
                   " FROM (SELECT vCsa1.* FROM ViewSch_ClassSectionSemesterAdmission vCsa1 " & _
                   " INNER JOIN " & _
                   " (SELECT vCsa.ClassSection , Max(vCsa.SemesterStartDate) AS SemesterStartDate " & _
                   " FROM ViewSch_ClassSectionSemesterAdmission vCsa  " & _
                   " GROUP BY vCsa.ClassSection  " & _
                   " ) vCsa2 ON vCsa1.ClassSection = vCsa2.ClassSection AND vCsa1.SemesterStartDate = vCsa2.SemesterStartDate) vCsa3 " & _
                   " WHERE vCsa3.SectionLeftOnDate IS NULL  " & _
                   " ) AS VSection ON Vap.AdmissionDocId = Vsection.AdmissionDocId " & _
                   " LEFT JOIN ViewSch_ClassSection Cs ON VSection.ClassSection = Cs.Code " & _
                   " LEFT JOIN Sch_ClassSectionSubSection SubSec ON VSection.ClassSectionSubSection = SubSec.Code " & _
                   " Left Join " & _
                   " ( " & _
                   " SELECT vOCsa3.Code, vOCsa3.AdmissionDocId, vOCsa3.StreamYearSemester,   vOCsa3.ClassSection, vOCsa3.ClassSectionSubSectionCode AS ClassSectionSubSection, vOCsa3.SectionLeftOnDate " & _
                   " FROM (SELECT vOCsa1.* FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa1 " & _
                   " INNER JOIN " & _
                   " (SELECT vOCsa.ClassSection , Max(vOCsa.SemesterStartDate) AS SemesterStartDate " & _
                   " FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa  " & _
                   " GROUP BY vOCsa.ClassSection  " & _
                   " ) vOCsa2 ON vOCsa1.ClassSection = vOCsa2.ClassSection AND vOCsa1.SemesterStartDate = vOCsa2.SemesterStartDate) vOCsa3 " & _
                   " WHERE vOCsa3.SectionLeftOnDate IS NULL  " & _
                   " ) AS vOSection ON vAp.AdmissionDocId = vOsection.AdmissionDocId " & _
                   " LEFT JOIN ViewSch_ClassSection OCs ON vOsection.ClassSection = OCs.Code " & _
                   " LEFT JOIN Sch_ClassSectionSubSection OSubSec ON vOSection.ClassSectionSubSection = OSubSec.Code " & _
                   " WHERE A.Leavingdate IS NULL " & _
                   " " & mCondStr & " "
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If AgL.StrCmp(ObjRFG.ParameterCmbo3_Value, "Yes") Then
                RepName = "Academic_StudentCurrentRegister" : RepTitle = "Student Current Register"
            Else
                RepName = "Academic_Semester_Wise_Student_List" : RepTitle = "Student Current Detail"
            End If


            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Student Label"
    Private Sub ProcStudentLabel()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = " Where 1=1 "

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "No") Then
                mCondStr = mCondStr & " AND A.LeavingDate IS NULL "
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Yes") Then
                mCondStr = mCondStr & " AND A.LeavingDate IS Not NULL "
            End If

            If ObjRFG.GetWhereCondition("A.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.Code", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.Streamcode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Category", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("sg.GroupCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sg.CityCode", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.DocId", 7)

            mQry = "SELECT Sem.SessionProgrammeDesc, " & _
                   " A.StudentName, A.Site_Code,  A.Status AS CurrentStatus, A.AdmissionId, A.EnrollmentNo, " & _
                   " A.RollNo, A.StudentDispName, A.FatherName,  A.MotherName, A.CityName,   " & _
                   " Sem.StreamYearSemesterDesc AS CurrentStreamYearSemester, " & _
                   " Sg.ManualCode, SgI.Photo, Sg.Add1, Sg.Add2, Sg.Add3, Sg.PIN, Sg.Phone, Sg.Mobile, Sg.FAX, Sg.EMail, " & _
                   " Sg.DOB, Sg.Remark, Sg.LogInUser, Sg.Sex, " & _
                   " Religion.Description AS Religion, Cat.Description AS CategoryDesc, Cat.ManualCode AS CategoryShortName, " & _
                   " S.MotherIncome, S.FatherIncome, S.FamilyIncome " & _
                   " FROM ViewSch_Admission A " & _
                   " LEFT JOIN Sch_Student S ON A.Student=S.SubCode   " & _
                   " LEFT JOIN SubGroup sg ON sg.SubCode =S.SubCode   " & _
                   " LEFT JOIN SubGroup_Image SgI ON Sg.SubCode = SgI.SubCode " & _
                   " Left Join city on Sg.citycode=city.citycode " & _
                   " LEFT JOIN Sch_Category Cat ON S.Category=Cat.Code " & _
                   " LEFT JOIN Sch_Religion Religion ON Religion.Code = S.Religion " & _
                   " LEFT JOIN ViewSch_StreamYearSemester Sem ON A.CurrentSemester = Sem.Code " & _
                   " " & mCondStr & " "
            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Academic_StudentLabel" : RepTitle = "Student Label"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Teacher Register" ' ****************** Code by Satyam on 15/10/2010 
    Private Sub ProcTeacherRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""
            Dim mqry1$ = ""
            Dim mqry2$ = ""
            If ObjRFG.GetWhereCondition("Sg.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Sg.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sg.Site_Code", 0)
            End If
            mCondStr1 = mCondStr

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("E.Category", 1)

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("TS.Subject", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("TS.Subcode", 3)


            mQry = "SELECT TS.SubCode,TS.Subject,S.Description AS Sub_Desc,E.DateOfJoin,E.Sex,E.BloodGroup,E.Religion,E.Category,C.Description as Category_Desc, " & _
                   " Sg.Site_Code,sg.DispName as Name,sg.Name as DispName,sg.Add1,sg.Add2,sg.Add3,sg.CityCode,city.CityName,sg.Phone,sg.Mobile,sg.EMail,sg.DOB,sg.FatherName, " & _
                   " Si.Name AS Site_Name,s.DisplayName AS Subject_Name,s.SubjectType,s.ManualCode AS Subject_Code, " & _
                   " E.DateOfJoin,E .DateOfResign,E .ResignRemark,E .MotherName,E .Shift,E .AppointmentType,E .SalaryMode,E .PayScale,E .Programme,E .WorkExperience " & _
                " ,E .TeachingExperience,E .ResearchExperience,E .IndustryExperience,E .BankAcNo,E .BankName,E .BankBranch,E .IfscCode " & _
 " ,E .TotalBooksPublished " & _
 " ,E .IsCommonSubjectTeacher,E .IsCommonSubjectBeingTaught,E .Stream,E .ProgrammeNature,E .TotalPapersPublishedInNationalJournals,E .TotalPapersPublishedInInternationalJournals," & _
      "      E.TotalInternationalConferencesAttended, E.TotalNationalConferencesAttended, E.TotalPapersInNationalConference, E.TotalPapersInInternationalConference, E.TotalShortTermCoursesAttended" & _
 " ,E .TotalWorkshopsAttended,E .TotalSeminarsAttended,E .CommonSubject ,state.state_desc ,SubGroup.EMail,SubGroup.PAN ,SubGroup.FAX,e.Designation,Sch_Stream.ManualCode as StramDesc ,SubGroup.PIN,Sch_Programme.manualcode as Programm_Desc	,e.TotalPGProjectsGuided,e.TotalDoctorateProjectsGuided,e.title " & _
                   " FROM Pay_TeacherSubject TS " & _
                   " LEFT JOIN Pay_Employee E ON E.SubCode=TS.SubCode " & _
                   " LEFT JOIN SubGroup SG ON SG.SubCode=E.SubCode " & _
                   " LEFT JOIN SiteMast Si ON Si.Code =Sg.Site_Code  " & _
                   " LEFT JOIN Sch_Category C ON C.Code=E.Category  " & _
                   " LEFT JOIN Sch_Subject S ON S.Code=TS.Subject " & _
                   " LEFT JOIN City ON city.CityCode=sg.CityCode " & _
                   " left join state on city.state_code=state.state_code LEFT JOIN SubGroup ON TS.SubCode =SubGroup.SubCode left join Sch_Stream on e.stream=Sch_Stream.code left join Sch_Programme on e.Programme=Sch_Programme.code " & _
                   " WHERE isnull(E.IsTeachingStaff,0)<>0 " & _
                   " " & mCondStr & " "


            mqry1 = "SELECT 	Pay_Employee.subcode,Class,	YearOfPassing,Sch_University.Description AS University,	EnrollmentNo,	Subjects,	Result,	TotalPercentage,	MeritPercentage,	Remark,  	Learning,	Specialization,	Institute" & _
                    " FROM dbo.Pay_EmployeeAcademicDetail LEFT JOIN Pay_Employee ON Pay_EmployeeAcademicDetail.SubCode=Pay_Employee.SubCode LEFT JOIN Sch_University ON Pay_EmployeeAcademicDetail.University=Sch_University.Code   "
            mqry2 = "SELECT e.subcode,e.Designation,Sch_Stream.ManualCode as StramDesc ,Sch_Programme.manualcode as Programm_Desc  FROM Pay_Employee E  left join Sch_Stream on e.stream=Sch_Stream.code left join Sch_Programme on e.Programme=Sch_Programme.code  LEFT JOIN SubGroup sg ON e.SubCode=sg.subcode LEFT JOIN SiteMast Si ON Si.Code =Sg.Site_Code  " & mCondStr1 & "  "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            DsRep1 = AgL.FillData(mqry1, AgL.GCn)
            DsRep2 = AgL.FillData(mqry2, AgL.GCn)
            RepName = "Academic_TeacherRegister" : RepTitle = "TEACHER REGISTER"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.SubReport1DataSet = DsRep1
            ObjRFG.SubReport2DataSet = DsRep2
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region ' ****************** End Code by Satyam on 15/10/2010 

#Region "Employee Identity Card"
    Private Sub ProcEmployeeIdentityCard()
        Try
            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo2_Control) Then Exit Sub

            Call ObjRFG.FillGridString()

            mCondStr = " where 1=1 "

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then
                mCondStr += " And IsNull(H.IsTeachingStaff,0) <> 0 "
            End If

            If AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Yes") Then
                mCondStr += " And H.DateOfResign Is Not Null "

            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "No") Then
                mCondStr += " And H.DateOfResign Is Null "
            End If


            If ObjRFG.GetWhereCondition("Sg.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Sg.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sg.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Category", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SubCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sg.CityCode", 3)

            mQry = "SELECT H.SubCode, Sg.Name, Sg.DispName, Sg.ManualCode, Sg.FatherName, Sg.MotherName, " & _
                    " Sg.Add1, Sg.Add2, Sg.Add3, City.CityName, Sg.PIN, Sg.Phone, Sg.Mobile, Sg.EMail, Sg.FAX, Sg.PAN, " & _
                    " H.DateOfJoin, H.DateOfResign, H.ResignRemark, H.Sex, H.BloodGroup,  " & _
                    " R.Description AS Religion, C.ManualCode AS Category,  " & _
                    " H.IsTeachingStaff, H.Designation, H.Shift, H.AppointmentType, H.SalaryMode, H.PayScale,  " & _
                    " P.Description As ProgrammeDesc, P.ManualCode AS ProgrammeManualCode, Pn.Description As ProgrammeNature, " & _
                    " H.Title, H.Stream, H.WorkExperience, H.TeachingExperience, H.ResearchExperience, H.IndustryExperience, " & _
                    " H.BankAcNo, H.BankName, H.BankBranch, H.IfscCode, H.TotalPGProjectsGuided,  " & _
                    " H.TotalDoctorateProjectsGuided, H.TotalBooksPublished,  " & _
                    " H.TotalPapersPublishedInNationalJournals, H.TotalPapersPublishedInInternationalJournals,  " & _
                    " H.TotalInternationalConferencesAttended, H.TotalNationalConferencesAttended,  " & _
                    " H.TotalPapersInNationalConference, H.TotalPapersInInternationalConference, H.TotalShortTermCoursesAttended,  " & _
                    " H.TotalWorkshopsAttended, H.TotalSeminarsAttended, H.IsCommonSubjectTeacher,  " & _
                    " H.IsCommonSubjectBeingTaught, H.CommonSubject,  " & _
                    " H.TotalPapersPublishedInNationalGenerals, H.TotalPapersPublishedInInternationalGenerals, H.MasterType, " & _
                    " Sg.Site_Code, Site.Name AS Site_Name, Site.Photo AS Site_Photo, SgI.Photo " & _
                    " FROM dbo.Pay_Employee H WITH (NoLock) " & _
                    " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.SubCode  " & _
                    " LEFT JOIN SiteMast Site WITH (NoLock) ON Site.Code = Sg.Site_Code  " & _
                    " LEFT JOIN City WITH (NoLock) ON Sg.CityCode = City.CityCode  " & _
                    " LEFT JOIN SubGroup_Image SgI WITH (NoLock) ON SgI.SubCode = Sg.SubCode  " & _
                    " LEFT JOIN Sch_Religion R WITH (NoLock) ON R.Code = H.Religion  " & _
                    " LEFT JOIN Sch_Category C  WITH (NoLock) ON C.Code = H.Category  " & _
                    " LEFT JOIN Sch_Programme P  WITH (NoLock) ON P.Code = H.Programme  " & _
                    " LEFT JOIN Sch_ProgrammeNature Pn WITH (NoLock) ON Pn.Code = H.ProgrammeNature "

            mQry += mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If AgL.StrCmp(ObjRFG.ParameterCmbo3_Value, "No") Then
                RepTitle = "Identity Card"

                If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then
                    RepName = "Academic_TeacherICard"
                Else
                    RepName = "Academic_EmployeeICard"
                End If

            Else
                RepTitle = "Identity Card"
                RepName = "Academic_EmployeeLabel"
            End If
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            If DsRep IsNot Nothing Then DsRep.Dispose()
        End Try
    End Sub
#End Region

#Region "Student Left Register" ' ****************** Code by Satyam on 20/09/2010 
    Private Sub ProcStudentLeftRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where A.LeavingDate Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("A.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("P.FromStreamYearSemester", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Vss.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionProgrammeCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.DocId", 6)


            mQry = "SELECT A.DocId As AdmissionDocId, A.AdmissionID, A.Student As StudentCode, A.StudentName, a.StudentDispName, " & _
                    " A.LeavingDate, A.LeavingReason,a.V_Date AS J_Date,a.RollNo,a.FatherName, Sem.ProgrammeManualCode, Sem.StreamManualCode, Sem.SessionProgrammeStreamDesc, Sem.SessionManualCode," & _
                    " S.Name As Site_Name,sem.StreamYearSemesterDesc " & _
                    " FROM ViewSch_Admission A " & _
                    " LEFT JOIN (SELECT Ap.* FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL ) P ON A.DocId = P.AdmissionDocId  " & _
                    " left join SiteMast S on a.Site_Code=S.Code " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON P.FromStreamYearSemester = Sem.Code " & _
                    " LEFT JOIN viewSch_Student VSS ON A.Student = VSS.SubCode " & _
                    " " & mCondStr & " " & _
                    " and A.LeavingDate IS NOT NULL  " & _
                    " Order By A.StudentName "



            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Academic_StudentLeftRegister" : RepTitle = "STUDENT LEFT REGISTER"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region ' ****************** End Code by Satyam on 20/09/2010 

#Region "Admission Register"    '******************* code Change by satyam on 02/03/2011
    Private Sub ProcAdmissionRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where A.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "No") Then
                mCondStr = mCondStr & " And A.RegistrationDocId is  null "
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then
                mCondStr = mCondStr & " And A.RegistrationDocId is not null "
            End If

            If AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "No") Then
                mCondStr = mCondStr & " And IsNull(A.IsDiplomaHolder,0) = 0 "
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Yes") Then
                mCondStr = mCondStr & " And IsNull(A.IsDiplomaHolder,0) <> 0 "
            End If

            If AgL.StrCmp(ObjRFG.ParameterCmbo3_Value, "No") Then
                mCondStr = mCondStr & " And IsNull(A.IsFeeWavier,0) = 0 "
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo3_Value, "Yes") Then
                mCondStr = mCondStr & " And IsNull(A.IsFeeWavier,0) <> 0"
            End If



            If ObjRFG.GetWhereCondition("A.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Site_Code", 0)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.SessionCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.SessionProgrammeCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.FromStreamYearSemester", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("s.Category", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.AdmissionNature", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.DocId", 7)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("sg.GroupCode", 8)

            mQry = " SELECT A.V_Date,A.AdmissionID,A.Student AS [StudentID],A.RollNo,A.EnrollmentNo, " & _
                    " sg.Name,sg.DispName,s.MotherName,sg.FatherName,sg.Add1,sg.Add2,sg.Add3," & _
                    " sg.Phone,sg.Mobile,sg.EMail,c.CityName,s.Sex,sc.ManualCode AS Category, " & _
                    " Sem.StreamYearSemesterDesc, SemTo.StreamYearSemesterDesc As PromotionSemester," & AgL.V_No_Field("A.RegistrationDocId") & " AS RegistrationNo," & AgL.Chk_Text(ObjRFG.ParameterCmbo3_Value) & " As List " & _
                    " FROM ViewSch_Admission A " & _
                    " LEFT JOIN Sch_Student S ON A.Student=S.SubCode " & _
                    " LEFT JOIN SubGroup sg ON sg.SubCode =S.SubCode " & _
                    " LEFT JOIN City c ON sg.CityCode=c.CityCode " & _
                    " LEFT JOIN Sch_Category sc ON s.Category=sc.Code" & _
                    " LEFT JOIN Sch_SessionProgrammeStream Sps ON A.SessionProgrammeStream = Sps.Code " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON A.FromStreamYearSemester = Sem.Code " & _
                    " LEFT JOIN ViewSch_StreamYearSemester SemTo ON A.ToStreamYearSemester = SemTo.Code " & _
                    " " & mCondStr & " " & _
                    " Order By A.StudentName "



            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Academic_AdmissionRegister" : RepTitle = "ADMISSION REGISTER"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region  '******************* End code Change by satyam on 02/03/2011

#Region "Fee Refund Register" ' Code By Satyam on 25/09/2010
    Private Sub ProcFeeRefundRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where FR.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("FR.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("FR.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("FR.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Fr.CurrentStreamYearSemesterCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Stu.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionProgrammeCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Fr.AdmissionDocId", 6)

            mQry = "SELECT " & AgL.V_No_Field("FR.DocId") & " AS Voucher_No, FR.Site_Code, FR.V_Date, Fr.V_Type AS V_TypeCode, Fr.V_TypeDesc, FR.TotalLineAmount, " & _
                    " FR.TotalLineNetAmount,FR.Remark,FR.Refundamount as RefundAmount, Fr.ExcessRefund, " & _
                    " Fr.AdmissionDocId, Adm.AdmissionID, Stu.name As Student_Name, FR1.Amount AS Line_Amount, " & _
                    " FR1.NetAmount AS Line_NetAmount,F.Dispname AS FeeDispName, F.ManualCode FeeManualCode, " & _
                    " F.Name AS FeeName, Fg.Description AS FeeGroup,Si.Name AS Site_Name, FR1.RowId AS FeeRefund1RowId, " & _
                    " VSPSY.StreamYearSemesterDesc, VSPSY.ProgrammeManualCode, VSPSY.SessionManualCode, " & _
                    " VSPSY.SessionDescription, VSPSY.StreamManualCode, VSPSY.SessionProgrammeDesc, Sch_Category.manualcode AS Category " & _
                    " FROM ViewSch_FeeRefund FR " & _
                    " LEFT Join ViewSch_FeeRefund1 FR1 ON FR.DocId =FR1.DocId   " & _
                    " LEFT JOIN ViewSch_StreamYearSemester VSPSY ON Fr.CurrentStreamYearSemesterCode = VSPSY.Code " & _
                    " LEFT JOIN viewSch_Fee F ON Fr1.FeeCode  =F.Code  " & _
                    " LEFT JOIN ViewSch_Admission  Adm ON Fr.AdmissionDocId = Adm.DocId   " & _
                    " LEFT JOIN ViewSch_Student Stu ON Adm.Student =stu.SubCode " & _
                    " LEFT JOIN Sch_Category ON Stu.Category=Sch_Category.Code " & _
                    " LEFT JOIN Sch_FeeGroup FG ON f.FeeGroup=FG.Code " & _
                    " LEFT JOIN SiteMast si  ON FR.Site_Code=si.Code " & _
                    " " & mCondStr & " "


            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Academic_FeeRefundRegister" : RepTitle = "FEE REFUND REGISTER"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region  '******************* code by satyam on 25/09/2010

#Region "Advance Receive Register"    '******************* code by satyam on 22/09/2010
    Private Sub ProcAdvanceReceiveRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where AR.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("AR.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("AR.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("AR.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ar.CurrentStreamYearSemesterCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("St.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionProgrammeCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.DocId", 6)


            mQry = " SELECT AR.DocId, " & AgL.V_No_Field("AR.DocId") & "  as DocID_Print, " & _
                    " Ar.Site_Code, AR.V_Date, AR.AdmissionDocId, AR.ReceiveAmount, AR.Remark, " & _
                    " a.AdmissionID, st.Name [StudentName], St.DispName As StudentDispName, " & _
                    " St.ManualCode As StudentManualCode, si.Name as Site_Name, " & _
                    " VSPSY.StreamYearSemesterDesc, VSPSY.ProgrammeManualCode, VSPSY.SessionManualCode, " & _
                    " VSPSY.SessionDescription, VSPSY.StreamManualCode, VSPSY.SessionProgrammeDesc, Sch_Category.manualcode AS Category " & _
                    " FROM ViewSch_AdvanceReceive AR" & _
                    " LEFT JOIN ViewSch_StreamYearSemester VSPSY ON Ar.CurrentStreamYearSemesterCode = VSPSY.Code " & _
                    " LEFT JOIN ViewSch_Admission A ON AR.AdmissionDocId=a.DocId" & _
                    " LEFT JOIN ViewSch_Student St ON A.Student =st.SubCode" & _
                    " LEFT JOIN Sch_Category ON St.Category=Sch_Category.Code " & _
                    " LEFT JOIN SiteMast si  ON AR.Site_Code=si.Code" & mCondStr



            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Academic_AdvanceReceiveRegister" : RepTitle = "ADVANCE RECEIVE REGISTER"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region '******************* End code by satyam on 22/09/2010

#Region "Course Wise Vacancy Report"
    Private Sub ProcCourseWiseVacancyReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = " where 1=1  "

            If ObjRFG.GetWhereCondition("Vsa.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Vsa.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Vsa.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsps.sessioncode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsps.programmecode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsps.Stream", 3)

            mQry = " SELECT vsps.SessionProgrammeStream,vsp.SessionDescription AS seseion,Sch_Programme.Description AS ProgrammeDescription ,ss.Description AS Stream, " & _
                   " max(Vsps.TotalSeats) AS Totalseat,Count(*) AS [NO Of Student],vsa.AdmissionID " & _
                   " FROM ViewSch_Admission vsa " & _
                   " LEFT JOIN ViewSch_SessionProgrammeStream vsps ON vsa.SessionProgrammeStream=vsps.Code " & _
                   " LEFT JOIN ViewSch_SessionProgramme vsp ON vsps.SessionCode =vsp.Session LEFT JOIN Sch_Programme ON vsps.ProgrammeCode=Sch_Programme.Code " & _
                   " leFT JOIN Sch_Stream ss ON vsps.Stream=ss.Code " & mCondStr & " " & _
                  " GROUP BY vsps.SessionProgrammeStream,vsp.SessionDescription ,Sch_Programme.Description,ss.Description,vsa.AdmissionID "

            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Academic_CourseWiseVacancyReport" : RepTitle = "Course Wise Vacancy Report"
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Attendance And Lecture Delivery"
    Private Sub ProcAttendanceAndLectureDelivery()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where saa.a_date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("SAA.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("SAA.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("SAA.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("saa.ClassSection", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("saa.TimeSlot", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("saa.Subject", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("saa.Teacher", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("saa.ClassSection", 5)

            If GRepFormName = TeacherWiseStudentAbsentReport Then
                mCondStr = mCondStr & " and saa1.IsPresent=0 "
            End If

            mQry = " SELECT saa.a_date ,sts.description AS TimeSlot,vsc.ClassSectionDesc,scr.Description AS Classroom," & _
                   " ss.Description AS subject,SubGroup.Name AS teacher,vsa.AdmissionID,vsa.StudentName,vsa.StudentDispName, " & _
                   " CASE WHEN saa1.IsPresent=1 THEN 'Present' ELSE 'Absent' END AS [Absent/Prasent],vsa.RollNo,sts.StartTime, " & _
                   " sts.EndTime, vSa.StudentManualCode, SAA.Code " & _
                   " FROM Sch_StudentAttendance SAA	LEFT JOIN Sch_StudentAttendance1 saa1 ON saa.Code=saa1.Code " & _
                   " LEFT JOIN ViewSch_Admission VSA ON saa1.AdmissionDocId=vsa.DocId " & _
                   " LEFT JOIN Sch_TimeSlot Sts ON saa.TimeSlot=Sts.code LEFT JOIN ViewSch_ClassSection VSC ON saa.ClassSection=vsc.Code " & _
                   " LEFT JOIN Sch_ClassRoom SCR ON saa.ClassRoom=scr.Code LEFT JOIN Sch_Subject SS ON saa.Subject=ss.Code LEFT JOIN SubGroup ON saa.Teacher=SubGroup.SubCode " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If GRepFormName = TeacherWiseStudentAbsentReport Then
                RepName = "Academic_Teacher_Wise_Student_Absent_Report" : RepTitle = "Teacher Wise Student Absent Report"
            Else
                RepName = "Academic_Attendance_And_Lecture_Delivery" : RepTitle = "Attendance And Lecture Delivery"
            End If


            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Attendance Below A Given Pecentage"
    Private Sub ProcAttendanceBelowAGivenPecentage()
        Try
            Dim mCondStr$ = "", mCondStr1$ = "", bPresentPercentageStr$ = "", bHavingStr$ = "", bViewMainStr$ = "", bView1Str$ = "", bView2Str$ = ""


            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo3_Control) Then Exit Sub

            If GRepFormName = AttendanceBetweenAGivenRange Then
                If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo2_Control) Then Exit Sub
            End If

            Call ObjRFG.FillGridString()

            mCondStr = " Where A.A_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("A.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.ClassSection", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.TimeSlot", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Subject", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Teacher", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.OcCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.ClassSection", 6)


            bPresentPercentageStr = " (Sum(CASE WHEN IsNull(A.IsPresent,0)<>0 THEN 1 ELSE 0 END) * 100) / Count(A.IsPresent) "

            If GRepFormName = AttendanceBelowAGivenPecentage Then
                If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then
                    bHavingStr = " Having " & bPresentPercentageStr & " < " & Val(ObjRFG.ParameterCmbo1_Value) & " "
                Else
                    mCondStr1 = " And V2.TotalPresentPer < " & Val(ObjRFG.ParameterCmbo1_Value) & " "
                End If

            ElseIf GRepFormName = AttendanceBetweenAGivenRange Then
                If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then
                    bHavingStr = " Having " & bPresentPercentageStr & " Between " & Val(ObjRFG.ParameterCmbo1_Value) & " And " & Val(ObjRFG.ParameterCmbo2_Value) & " "
                Else
                    mCondStr1 = " And V2.TotalPresentPer Between " & Val(ObjRFG.ParameterCmbo1_Value) & " And " & Val(ObjRFG.ParameterCmbo2_Value) & " "
                End If

            End If


            bViewMainStr = "Select A.ClassSection, A.AdmissionDocId, Max(A.Subject) As Subject, A.CurrentStreamYearSemesterCode, " & _
                            " Sum(1) as GrandTotalClasses, " & _
                            " Sum(CASE WHEN A.IsPresent = 0 THEN 0 ELSE 1 END) GrandTotalPresents, " & _
                            " (Sum(CASE WHEN A.IsPresent = 0 THEN 0 ELSE 1 END) * 100.00) / Sum(1.00) As TotalPresentPer " & _
                            " From ViewSch_StudentAttendance1 A " & _
                            " " & mCondStr & " "
            bView1Str = bViewMainStr & " Group By A.ClassSection, A.AdmissionDocId, A.Subject, A.CurrentStreamYearSemesterCode "
            bView2Str = bViewMainStr & " Group By A.ClassSection, A.AdmissionDocId, A.CurrentStreamYearSemesterCode "

            mQry = "SELECT Max(Adm.StudentName) StudentName, Max(Adm.AdmissionId) AS AdmissionId, " & _
                    " A.ClassSection AS ClassSectionCode, A.Subject AS SubjectCode,  " & _
                    " A.AdmissionDocId, Count(A.IsPresent) AS TotalClasses, " & bPresentPercentageStr & " As PresentPercentage,  " & _
                    " Sum(CASE WHEN IsNull(A.IsPresent,0)<>0 THEN 1 ELSE 0 END) AS TotalPresents, " & _
                    " Max(A.ClassSectionDesc) AS ClassSectionDesc,   " & _
                    " Max(A.SubjectName) AS SubjectName, Max(A.SubjectDisplayName) AS SubjectDisplayName,  " & _
                    " Max(A.SubjectType) AS SubjectType, A.CurrentStreamYearSemesterCode, Max(Sem.StreamYearSemesterDesc) AS StreamYearSemesterDesc, " & _
                    " Max(A.SubjectManualCode) AS SubjectManualCode, Max(A.PaperID) AS PaperID, " & _
                    " Max(V1.GrandTotalClasses)  As GrandTotalClasses, Max(V1.GrandTotalPresents) As GrandTotalPresents, Max(V2.TotalPresentPer) As TotalPresentPer  " & _
                    " FROM ViewSch_StudentAttendance1 A   " & _
                    " LEFT JOIN ViewSch_Admission Adm ON A.AdmissionDocId = Adm.DocId  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON A.CurrentStreamYearSemesterCode = Sem.Code " & _
                    " LEFT JOIN (" & bView1Str & ") As V1 On V1.AdmissionDocID = A.AdmissionDocId And V1.ClassSection = A.ClassSection And V1.Subject = A.Subject And V1.CurrentStreamYearSemesterCode = A.CurrentStreamYearSemesterCode " & _
                    " LEFT JOIN (" & bView2Str & ") As V2 On V2.AdmissionDocID = A.AdmissionDocId And V2.ClassSection = A.ClassSection And V2.CurrentStreamYearSemesterCode = A.CurrentStreamYearSemesterCode " & _
                    " " & mCondStr & mCondStr1 & "  " & _
                    " GROUP BY A.ClassSection, A.AdmissionDocId, A.Subject, A.CurrentStreamYearSemesterCode " & _
                    " " & bHavingStr & " "


            Dim DaTemp As SqlClient.SqlDataAdapter

            DaTemp = New SqlClient.SqlDataAdapter(mQry, AgL.GCn)
            DaTemp.SelectCommand.CommandTimeout = 2000
            DsRep = New DataSet
            DaTemp.Fill(DsRep)


            RepName = "Academic_AttendanceBelowAGivenPecentage"

            If GRepFormName = AttendanceBelowAGivenPecentage Then
                RepTitle = "Attendance < " & ObjRFG.ParameterCmbo1_Value & "%"
            ElseIf GRepFormName = AttendanceBetweenAGivenRange Then
                RepTitle = "Attendance Between " & ObjRFG.ParameterCmbo1_Value & "% And " & ObjRFG.ParameterCmbo2_Value & "%"
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
        Catch ex As Exception
            MsgBox(ex.Message)            
        Finally
            If DsRep IsNot Nothing Then DsRep.Dispose()
        End Try

    End Sub
#End Region

#Region "Bank Scroll List"
    Private Sub ProcBankScrollList()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where Fr.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("Fr.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Fr.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Fr.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("FR1.SessionProgrammeStreamCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SYSem.Stream", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("stu.category", 3)

            mQry = " SELECT FR.DocId," & AgL.V_No_Field("FR.DocID") & " as DocID_Print,FR.site_code,FR.v_date ,FR.AdmissionDocId,SYSem.sessionprogrammestream , Adm.DocId,  Adm.DocId, Adm.RegistrationDocId, Adm.AdmissionID, Stu.name As Student_Name, " & _
                   " stu.FatherName , Stu.Add1, Stu.Add2, stu.CityName , Adm.EnrollmentNo ,PD.CashAc, PD.CashAmount, PD.BankAc, PD.BankAmount, PD.Bank_Code, PD.Chq_No, PD.Chq_Date, PD.Clg_Date, PD.CardAc, PD.CardAmount, PD.CardBank_Code, PD.Card_No, " & _
                   " PD.AcTransferBankAc, PD.AcTransferAmount, PD.AcTransferBank_Code, PD.TotalAmount, PD.AcTransferAcNo, PD.PartyDrCr, (CASE WHEN PD.CashAmount>0 THEN 'Cash' WHEN PD.BankAmount>0 THEN 'Cheque / DD' WHEN PD.CardAmount>0 THEN 'Credit / Debit Card' WHEN PD.AcTransferAmount>0 THEN 'A/c Transfer' END) AS PaymentMode, " & _
                   " PD.CashAmount+PD.BankAmount+PD.BankAmount2+PD.BankAmount3+PD.CardAmount+PD.AcTransferAmount AS PaymentAmount,PD.BankAc2, PD.BankAmount2, PD.Bank_Code2, PD.Chq_No2, PD.Chq_Date2, PD.Clg_Date2,PD.BankAc3, PD.BankAmount3, PD.Bank_Code3, PD.Chq_No3, PD.Chq_Date3, PD.Clg_Date3," & _
                   " b1.bank_name as Bank1,b2.bank_name as Bank2,b3.bank_name as Bank3,stu.manualcode as StudentManualcode,Sch_Category.manualcode as StuCategory,stu.dispname as Student_Displayname,SYSem.streamManualcode as Stream  " & _
                   " FROM viewSch_FeeReceive fr   " & _
                   " LEFT JOIN (SELECT fr1.DocId AS docid,max(fr1.SessionProgrammeStreamCode) AS SessionProgrammeStreamCode FROM ViewSch_FeeReceive1 fr1 GROUP BY fr1.DocId) FR1 ON FR.docid=fr1.docid " & _
                   " LEFT JOIN ViewSch_SessionProgrammeStream SYSem ON FR1.SessionProgrammeStreamCode=sysem.Code  " & _
                   " LEFT JOIN dbo.PaymentDetail PD ON Fr.DocId =PD.DocId  LEFT JOIN ViewSch_Admission  Adm ON FR.AdmissionDocId = Adm.DocId  " & _
                   " LEFT JOIN ViewSch_Student Stu ON Adm.Student =stu.SubCode  Left Join Bank b1 on pd.bank_code=b1.bank_code  " & _
                   " Left Join Bank b2 on pd.bank_code2=b2.bank_code  Left Join Bank b3 on pd.bank_code3=b3.bank_code left join Sch_Category on stu.category=Sch_Category.code  " & mCondStr & "  "

            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Academic_Bank_Scroll_List" : RepTitle = "Bank Scroll List"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Payment Receipt Report"
    Private Sub ProcPaymentReceiptReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "", mCondStr1$ = "", mqryDr$ = "", mqryCr$ = "", mqryOpBank$ = "", mqryOpCash$ = "", mqryClBank$ = "", mqryClCash$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub


            mCondStr = " where Ld.SubCode <> V1.SubCode And " & AgL.PubSiteCondition("Ld.Site_Code", AgL.PubSiteCode) & "  and Ld.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " and ld.AmtCr > 0"
            mCondStr1 = " where Lc.SubCode <> V1.SubCode And " & AgL.PubSiteCondition("Lc.Site_Code", AgL.PubSiteCode) & "  and Lc.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " and lc.AmtDr > 0"


            mqryDr = "SELECT  row_number() OVER(PARTITION BY Ld.Site_Code + Convert(nVarChar,Ld.v_date) ORDER BY Convert(nVarChar,Ld.v_date) + Ld.SubCode) AS RowNo,ld.V_Date,ld.V_No,ld.Narration,ld.AmtCr As AmtDr,SubGroup.Name, Ld.Site_Code, Sm.Name As Site_Name " & _
                        " FROM Ledger lD " & _
                        " INNER JOIN " & _
                        " ( " & _
                        " 	SELECT Distinct L1.DocId AS LedgerDocId, Sg.* " & _
                        " 	FROM SubGroup Sg  " & _
                        " 	LEFT JOIN Ledger L1 ON L1.SubCode = Sg.SubCode  " & _
                        "   Where Sg.Nature In ('Cash', 'Bank') And L1.AmtDr > 0 " & _
                        " ) V1 ON V1.LedgerDocId = Ld.DocId " & _
                        " Left Join SiteMast Sm On Ld.Site_Code = Sm.Code " & _
                        " LEFT JOIN SubGroup ON ld.SubCode=SubGroup.SubCode " & mCondStr & ""

            mqryCr = "SELECT  row_number() OVER(PARTITION BY Lc.Site_Code + Convert(nVarChar,Lc.v_date) ORDER BY Convert(nVarChar,Lc.v_date) + Lc.SubCode) AS RowNo,Lc.V_Date,Lc.V_No,Lc.Narration,Lc.AmtDr As AmtCr,SubGroup.Name, Lc.Site_Code, Sm.Name As Site_Name " & _
                        " FROM Ledger Lc " & _
                        " INNER JOIN " & _
                        " ( " & _
                        " 	SELECT Distinct L1.DocId AS LedgerDocId, Sg.* " & _
                        " 	FROM SubGroup Sg  " & _
                        " 	LEFT JOIN Ledger L1 ON L1.SubCode = Sg.SubCode  " & _
                        "   Where Sg.Nature In ('Cash', 'Bank') And L1.AmtCr > 0 " & _
                        " ) V1 ON V1.LedgerDocId = Lc.DocId " & _
                        " Left Join SiteMast Sm On Lc.Site_Code = Sm.Code " & _
                        " LEFT JOIN SubGroup ON Lc.SubCode=SubGroup.SubCode " & mCondStr1 & ""


            mqryOpCash = "SELECT -1 As Sr, " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " As V_Date, " & _
                            " sum(Ld.amtdr)-sum(ld.amtcr) As Balance, Ld.Site_Code, Max(Sm.Name) As Site_Name " & _
                            " FROM Ledger Ld " & _
                            " Left Join SiteMast Sm On Ld.Site_Code = Sm.Code " & _
                            " LEFT JOIN SubGroup ON Ld.SubCode=SubGroup.SubCode " & _
                            " where  " & AgL.PubSiteCondition("Ld.Site_Code", AgL.PubSiteCode) & "  and " & _
                            " Ld.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " and " & _
                            " subgroup.Nature='Cash' " & _
                            " Group By Ld.Site_Code "

            mqryOpBank = "SELECT -1 As Sr, " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " As V_Date, " & _
                            " sum(Ld.amtdr)-sum(ld.amtcr) As Balance, Ld.Site_Code, Max(Sm.Name) As Site_Name " & _
                            " FROM Ledger Ld " & _
                            " Left Join SiteMast Sm On Ld.Site_Code = Sm.Code " & _
                            " LEFT JOIN SubGroup ON Ld.SubCode=SubGroup.SubCode " & _
                            " where  " & AgL.PubSiteCondition("Ld.Site_Code", AgL.PubSiteCode) & "  and " & _
                            " Ld.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " and " & _
                            " subgroup.Nature='Bank' " & _
                            " Group By Ld.Site_Code "

            mqryClCash = "SELECT 1 As Sr, " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " As V_Date, " & _
                            " sum(Ld.amtdr)-sum(ld.amtcr) As Balance, Ld.Site_Code, Max(Sm.Name) As Site_Name " & _
                            " FROM Ledger Ld " & _
                            " Left Join SiteMast Sm On Ld.Site_Code = Sm.Code " & _
                            " LEFT JOIN SubGroup ON Ld.SubCode=SubGroup.SubCode " & _
                            " where  " & AgL.PubSiteCondition("Ld.Site_Code", AgL.PubSiteCode) & "  " & _
                            " and Ld.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " and " & _
                            " subgroup.Nature='Cash' " & _
                            " Group By Ld.Site_Code "

            mqryClBank = "SELECT 1 As Sr, " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " As V_Date, " & _
                            " sum(Ld.amtdr)-sum(ld.amtcr) As Balance, Ld.Site_Code, Max(Sm.Name) As Site_Name " & _
                            " FROM Ledger Ld " & _
                            " Left Join SiteMast Sm On Ld.Site_Code = Sm.Code " & _
                            " LEFT JOIN SubGroup ON Ld.SubCode=SubGroup.SubCode " & _
                            " where  " & AgL.PubSiteCondition("Ld.Site_Code", AgL.PubSiteCode) & "  and " & _
                            " Ld.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " and " & _
                            " subgroup.Nature='Bank' " & _
                            " Group By Ld.Site_Code "


            mQry = " select " & _
                   " Oc.Site_Code, Oc.Site_Name, OC.Sr, Oc.V_Date as LdrDate, 0 as ldrVno,'' as ldrNarr, " & _
                   " Case When Oc.Balance >= 0 Then Oc.Balance Else 0 End as ldrDR  ,'Opening Cash' as ldrname , " & _
                   " Oc.V_Date as LdcDate, 0 as ldcVno, '' as ldcNarr, " & _
                   " Case When Oc.Balance < 0 Then Abs(Oc.Balance) Else 0 End as ldcCR  ,'Opening Cash' as ldcname , " & _
                   " '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' As ToDate, " & _
                   " Oc.V_Date AS VoucherDate " & _
                   " From (" & mqryOpCash & ") As OC "

            mQry += " UNION ALL select " & _
                   " Ob.Site_Code, Ob.Site_Name, Ob.Sr, Ob.V_Date as LdrDate, 0 as ldrVno,'' as ldrNarr, " & _
                   " Case When Ob.Balance >= 0 Then Ob.Balance Else 0 End as ldrDR  ,'Opening Bank' as ldrname , " & _
                   " Ob.V_Date as LdcDate, 0 as ldcVno, '' as ldcNarr, " & _
                   " Case When Ob.Balance < 0 Then Abs(Ob.Balance) Else 0 End as ldcCR  ,'Opening Bank' as ldcname , " & _
                   " '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' As ToDate, " & _
                   " Ob.V_Date AS VoucherDate " & _
                   " From (" & mqryOpBank & ") As Ob "


            mQry += " UNION ALL select " & _
                   " Cc.Site_Code, Cc.Site_Name, Cc.Sr, Cc.V_Date as LdrDate, 0 as ldrVno,'' as ldrNarr, " & _
                   " Case When Cc.Balance >= 0 Then Cc.Balance Else 0 End as ldrDR  ,'Closing Cash' as ldrname , " & _
                   " Cc.V_Date as LdcDate, 0 as ldcVno, '' as ldcNarr, " & _
                   " Case When Cc.Balance < 0 Then Abs(Cc.Balance) Else 0 End as ldcCR  ,'Closing Cash' as ldcname , " & _
                   " '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' As ToDate, " & _
                   " " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " AS VoucherDate " & _
                   " From (" & mqryClCash & ") As Cc "

            mQry += " UNION ALL select " & _
                   " Cb.Site_Code, Cb.Site_Name, Cb.Sr, Cb.V_Date as LdrDate, 0 as ldrVno,'' as ldrNarr, " & _
                   " Case When Cb.Balance >= 0 Then Cb.Balance Else 0 End as ldrDR  ,'Closing Bank' as ldrname , " & _
                   " Cb.V_Date as LdcDate, 0 as ldcVno, '' as ldcNarr, " & _
                   " Case When Cb.Balance < 0 Then Abs(Cb.Balance) Else 0 End as ldcCR  ,'Closing Bank' as ldcname , " & _
                   " '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' As ToDate, " & _
                   " " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " AS VoucherDate " & _
                   " From (" & mqryClBank & ") As Cb "

            If GRepFormName = PaymentReceiptSummary Then
                mqryDr = "SELECT row_number() OVER(PARTITION BY V.Site_Code ORDER BY V.Site_Code) AS RowNo, " & _
                            " " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " AS V_Date, 1 AS V_No, '' AS Narration, Sum(V.AmtDr) AS AmtDr, " & _
                            " V.Name, V.Site_Code, Max(V.Site_Name) AS Site_Name " & _
                            " FROM (" & mqryDr & ") As V " & _
                            " GROUP BY V.Site_Code, V.Name "

                mqryCr = "SELECT row_number() OVER(PARTITION BY V.Site_Code ORDER BY V.Site_Code) AS RowNo, " & _
                            " " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " AS V_Date, 1 AS V_No, '' AS Narration, Sum(V.AmtCr) AS AmtCr, " & _
                            " V.Name, V.Site_Code, Max(V.Site_Name) AS Site_Name " & _
                            " FROM (" & mqryCr & ") As V " & _
                            " GROUP BY V.Site_Code, V.Name "
            End If


            mQry += " UNION ALL select " & _
                   " Case When Ldr.Site_Code Is Not Null Then Ldr.Site_Code Else Lcr.Site_Code End As Site_Code, " & _
                   " Case When Ldr.Site_Name Is Not Null Then Ldr.Site_Name Else Lcr.Site_Name End As Site_Name, " & _
                   " 0 As Sr, ldr.V_Date as LdrDate,ldr.V_No as ldrVno,ldr.Narration as ldrNarr, IsNull(ldr.AmtDr,0) as ldrDR  ,Ldr.Name as ldrname , " & _
                   " lcr.V_Date as LdcDate,lcr.V_No as ldcVno,lcr.Narration as ldcNarr, IsNull(lcr.Amtcr,0) as ldcCR  ,lcr.Name as ldcname , " & _
                   " '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' As ToDate, " & _
                   " CASE WHEN Ldr.V_Date IS Not NULL THEN Ldr.V_Date Else LCr.V_Date END AS VoucherDate " & _
                   " From (" & mqryDr & ") ldr " & _
                   " Full join (" & mqryCr & ") lcr on Ldr.Site_Code = Lcr.Site_Code And Ldr.V_Date = LCr.V_Date And Ldr.Rowno=lcr.RowNo "


            DsRep = AgL.FillData(mQry, AgL.GCn)

            If GRepFormName = PaymentReceiptReport Then
                RepName = "Academic_Payment_Receipt_Report" : RepTitle = "Payment/Receipt Report"
            ElseIf GRepFormName = PaymentReceiptSummary Then
                RepName = "Academic_PaymentReceiptSummary" : RepTitle = "Payment/Receipt (Summary)"
            End If


            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Semester Wise Subject Report"
    Private Sub ProcSemesterWiseSubjectReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where 1=1 "

            If ObjRFG.GetWhereCondition("Sem.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Sem.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.Code", 1)
            mCondStr1 = "'" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForSemester "




            mQry = "SELECT Sem.StreamYearSemesterDesc AS  Semester, Sem.SemesterStartDate [Sem.Start Dt], Sj.DisplayName AS Subject,Sj.SubjectType, S.ManualCode, S.PaperID, S.MinCreditHours AS [Credit Hours], (CASE When S.IsElectiveSubject=1 THEN 'Yes' ELSE 'No' END) AS Elective," & mCondStr1 & "  " & _
                    "FROM Sch_SemesterSubject S  " & _
                    "LEFT JOIN ViewSch_StreamYearSemester Sem ON S.StreamYearSemester =Sem.Code   " & _
                    "LEFT JOIN Sch_Subject Sj ON S.Subject =Sj.Code " & _
                    "" & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)


            RepName = "Academic_Semester_Wise_Subject_Report" : RepTitle = "Semester Wise Subject Report"



            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Transfer Certificate"
    Private Sub ProcTransferCertificate()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "
            Dim mDatefield$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            mDatefield = AgL.RetValidDate(ObjRFG.ParameterCmbo1_Value)

            If GRepFormName = CharacterCertificate Then
                mCondStr = " where A.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            ElseIf GRepFormName = TransferCertificate Then
                mCondStr = " where A.LeavingDate Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " And A.LeavingDate IS NOT NULL "
            End If


            If ObjRFG.GetWhereCondition("A.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("a.sessionprogrammestream", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("a.docid", 2)

            mQry = QryTransferCertificate(mCondStr, mDatefield)

            DsRep = AgL.FillData(mQry, AgL.GCn)
            If GRepFormName = CharacterCertificate Then
                RepName = "Academic_Character_Certificate" : RepTitle = "CHARACTER CERTIFICATE"
            Else
                RepName = "Academic_Transfer_Certificate" : RepTitle = "TRANSFER CERTIFICATE"
            End If


            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub


    Public Shared Function QryTransferCertificate(ByVal mCondStr As String, ByVal mDateField As String)
        Dim mYearString As String
        mYearString = DatePart("yyyy", AgL.PubStartDate) & "-" & DatePart("yyyy", AgL.PubEndDate)
        QryTransferCertificate = "SELECT A.DocId As AdmissionDocId, A.AdmissionID, A.Student As StudentCode,a.StudentDispName, " & _
                    " A.LeavingDate, A.LeavingReason,a.V_Date AS J_Date,a.RollNo,a.FatherName,a.ProgrammeManualCode,A.Conduct, " & _
                    " a.StreamManualCode,a.SessionProgrammeStreamDesc,a.SessionManualCode,ViewSch_Student.Add1,ViewSch_Student.Add2," & _
                    " ViewSch_Student.Add3,ViewSch_Student.CityName ,ViewSch_Student.dob, S.Photo As SitePhoto ,'" & mDateField & "' AS IssuedDate," & mYearString & " as YearString,a.v_no " & _
                    " FROM ViewSch_Admission A " & _
                    " LEFT JOIN (SELECT Ap.* FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL ) P ON A.DocId = P.AdmissionDocId  " & _
                    " left join ViewSch_Student on a.student=ViewSch_Student.subcode " & _
                    " Left Join SiteMast S On A.Site_Code = S.Code " & _
                    " " & mCondStr & " " & _
                    " Order By A.StudentName "
    End Function
#End Region

#Region "Leaving/Cancellation Report"
    Private Sub ProcLeavingCancellationReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where A.LeavingDate Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("A.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Site_Code", 0)
            End If
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("a.sessionprogrammestream", 1)

            mCondStr1 = "'" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForSessionProgrammeStream,'" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' as Todate "



            mQry = "SELECT A.DocId As AdmissionDocId, A.AdmissionID, A.Student As StudentCode,a.StudentDispName, " & _
                    " A.LeavingDate, A.LeavingReason,a.V_Date AS J_Date,a.RollNo,a.FatherName,a.ProgrammeManualCode,a.StreamManualCode,a.SessionProgrammeStreamDesc,a.SessionManualCode ," & mCondStr1 & "   " & _
                    " FROM ViewSch_Admission A " & _
                    " LEFT JOIN (SELECT Ap.* FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL ) P ON A.DocId = P.AdmissionDocId  " & _
                    " " & mCondStr & " " & _
                    " and A.LeavingDate IS NOT NULL  " & _
                    " Order By A.StudentName "



            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Academic_Leaving_Cancellation_Report" : RepTitle = "Leaving/Cancellation Report"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub


#End Region

#Region "Student Information"
    Private Sub ProcStudentInformation()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""


            mCondStr = " Where 1=1 "

            If ObjRFG.GetWhereCondition("VSA.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("VSA.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSA.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Stream.Stream", 1)
            'Code by Akash on date 15-10-11
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsa.Student", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SS.Category", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsa.SessionCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsa.SessionProgrammeCode", 5)
            'End Code

            mQry = " SELECT VSA.V_Date,VSA.AdmissionID,VSA.	LeavingDate,VSA.Status,VSA.	EnrollmentNo,VSA.RollNo,VSA.StudentDispName,VSA.FatherName,VSA.MotherName," & _
                    " VSA.CityName,VSA.PIN,VSA.SessionProgrammeStreamDesc,VSA.SessionManualCode,VSA.	ProgrammeManualCode, " & _
                    " VSA.StreamManualCode,	ss.Add1,ss.add2,ss.add3,ss.Mobile,ss.Phone,ss.PAdd1,ss.PAdd2,ss.PAdd3,ss.CityName,ss.DOB," & _
                    " ss.CategoryManualCode,ss.Religion,ss.FatherOccupationDesc,ss.MotherOccupation,ss.BloodGroup,	Nationality.Nationaliy,ssad.Class,ssad.YearOfPassing,ssad.Subjects,ssad.TotalPercentage," & _
                    " ssad.PCMPercentage,Sch_University.Description AS University,Si.Photo AS STudent_Photo,Si.Signature AS Stu_Sign, ss.Sex " & _
                    " FROM ViewSch_Admission vsa " & _
                    " Left Join Sch_SessionProgrammeStream Stream On Stream.Code =  Vsa.SessionProgrammeStream " & _
                    " LEFT JOIN viewSch_Student SS ON vsa.Student=ss.SubCode " & _
                    " LEFT JOIN Nationality ON ss.NationalityCode=Nationality.NationalityCode " & _
                    " LEFT JOIN Sch_StudentAcademicDetail SSAD ON vsa.Student=SSAD.SubCode " & _
                    " LEFT JOIN Sch_University ON ssad.University=Sch_University.code " & _
                    " LEFT JOIN SubGroup_Image Si ON vsa.Student=Si.SubCode " & mCondStr & " "



            DsRep = AgL.FillData(mQry, AgL.GCn)
            If GRepFormName = StudentInformationCategorywiseDetail Then
                RepName = "Academic_Student_Information_Categorywise_Detail" : RepTitle = "Student Information Category wise"
            Else
                RepName = "Academic_Student_Information" : RepTitle = "Student Information"
            End If
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Student Information Category wise Report"
    Private Sub ProcStudentInformationCategorywiseReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

         
            mCondStr = " where vsa.v_date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "



            If ObjRFG.GetWhereCondition("VSA.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("VSA.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSA.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsa.SessionProgrammeStream", 1)


            mQry = " SELECT VSA.SessionProgrammeStreamDesc,ss.CategoryManualCode,ss.Sex ,Count(*) AS No_Student, " & _
                   " '" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForSessionProgrammeStream " & _
                   " FROM ViewSch_Admission vsa  LEFT JOIN viewSch_Student SS ON vsa.Student=ss.SubCode  " & _
                   " LEFT JOIN Nationality ON ss.NationalityCode=Nationality.NationalityCode  " & mCondStr & "  " & _
                   " GROUP BY VSA.SessionProgrammeStreamDesc,ss.CategoryManualCode,ss.Sex "




            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Academic_Student_Information_Categorywise_Report" : RepTitle = "Student Information Category wise Report"
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Identity Card"
    Private Sub ProcIdentityCard()
        Try
            Dim mCondStr$ = "", mCondStr1$ = ""

            Call ObjRFG.FillGridString()

            mCondStr = " where 1=1 "

            If ObjRFG.GetWhereCondition("VSA.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("VSA.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSA.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsa.Student", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vSem.SessionCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vSem.Code", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vSem.Streamcode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ss.Category", 5)


            mQry = "SELECT VSA.V_Date, VSA.AdmissionID, VSA.LeavingDate, VSA.Status, Ae.EnrollmentNo, Ar.RollNo, " & _
                    " ss.DispName AS StudentDispName, ss.FatherName, ss.MotherName,  ss.PIN, vSem.SessionProgrammeStreamDesc, " & _
                    " vSem.SessionManualCode, vSem.ProgrammeManualCode,  vSem.StreamManualCode, ss.Add1, ss.add2, ss.add3, " & _
                    " ss.Mobile, ss.Phone, ss.PAdd1, ss.PAdd2, ss.PAdd3, ss.CityName, ss.DOB,  ss.CategoryManualCode, " & _
                    " ss.Religion, ss.FatherOccupationDesc, ss.MotherOccupation,ss.BloodGroup, Nationality.Nationaliy,   " & _
                    " Si.Photo AS STudent_Photo, Si.Signature AS Stu_Sign, ss.Sex, S.Photo As SitePhoto, ss.ManualCode, " & _
                    " vsa.Student AS StudentCode, Vsa.Site_Code, S.Name AS Site_Name, vSem.StreamYearSemesterDesc, " & _
                    " vSem.SemesterDesc, vSem.YearSerial, vSem.SemesterSerialNo,S.ManualCode as SiteManualCode,S.WebSite as SiteWebSite,S.Email as SiteEmail" & _
                    " FROM Sch_Admission vsa WITH (NoLock) " & _
                    " LEFT JOIN Sch_AdmissionRollNo Ar WITH (NoLock) ON Ar.DocId = vsa.DocId  " & _
                    " LEFT JOIN Sch_AdmissionEnrollmentNo Ae WITH (NoLock) ON Ae.DocId = vsa.DocId  " & _
                    " Left Join SiteMast S WITH (NoLock) On Vsa.Site_Code =  S.Code   " & _
                    " LEFT JOIN viewSch_Student SS WITH (NoLock) ON vsa.Student=ss.SubCode  " & _
                    " LEFT JOIN Nationality WITH (NoLock) ON ss.NationalityCode=Nationality.NationalityCode " & _
                    " LEFT JOIN ViewSch_StreamYearSemester vSem ON vSem.Code = vsa.CurrentSemester  " & _
                    " LEFT JOIN SubGroup_Image Si WITH (NoLock) ON vsa.Student=Si.SubCode " & mCondStr & " "


            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Academic_Identity_Card" : RepTitle = "Identity Card"
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")




            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Student Card"
    Private Sub ProcStudentCard()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""
            Dim mqry1 As String

            mCondStr = " where 1=1 "

            If ObjRFG.GetWhereCondition("VSA.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("VSA.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSA.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsa.Student", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vSem.SessionCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vSem.Code", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vSem.Streamcode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Ss.Category", 5)


            mQry = "SELECT VSA.V_Date,VSA.AdmissionID,VSA.LeavingDate,VSA.Status, Ae.EnrollmentNo, Ar.RollNo, " & _
                    " ss.DispName AS StudentDispName,ss.FatherName,ss.MotherName, ss.PIN, " & _
                    " vSem.SessionProgrammeStreamDesc,vSem.SessionManualCode, vSem.ProgrammeManualCode,  vSem.StreamManualCode,  " & _
                    " ss.Add1,ss.add2,ss.add3,ss.Mobile,ss.Phone,ss.PAdd1, " & _
                    " ss.PAdd2,ss.PAdd3, SS.PCityName, ss.CityName,ss.DOB, ss.CategoryManualCode,ss.Religion,ss.FatherOccupationDesc, " & _
                    " ss.MotherOccupation,ss.BloodGroup,	Nationality.Nationaliy,ssad.Class,ssad.YearOfPassing, " & _
                    " ssad.Subjects,ssad.TotalPercentage, ssad.PCMPercentage, " & _
                    " Sch_University.Description AS University,Si.Photo AS STudent_Photo,Si.Signature AS Stu_Sign, " & _
                    " ss.Sex,  Ss.Name AS StudentName, Ss.FamilyIncome, ss.FatherIncome , ss.MotherIncome,  " & _
                    " S.Photo As SitePhoto, SS.ManualCode AS StudentManualCode, vSem.StreamYearSemesterDesc,  " & _
                    " vSem.YearSerial, vSem.SemesterSerialNo, vSem.SemesterDesc   " & _
                    " FROM Sch_Admission vsa WITH (NoLock) " & _
                    " LEFT JOIN Sch_AdmissionRollNo Ar WITH (NoLock) ON Ar.DocId = vsa.DocId  " & _
                    " LEFT JOIN Sch_AdmissionEnrollmentNo Ae WITH (NoLock) ON Ae.DocId = vsa.DocId  " & _
                    " Left Join SiteMast S WITH (NoLock) On Vsa.Site_Code =  S.Code   " & _
                    " LEFT JOIN viewSch_Student SS WITH (NoLock) ON vsa.Student=ss.SubCode  " & _
                    " LEFT JOIN Sch_StudentAcademicDetail SSAD WITH (NoLock) ON vsa.Student=SSAD.SubCode   " & _
                    " LEFT JOIN Sch_University WITH (NoLock) ON ssad.University=Sch_University.code   " & _
                    " LEFT JOIN Nationality WITH (NoLock) ON ss.NationalityCode=Nationality.NationalityCode " & _
                    " LEFT JOIN ViewSch_StreamYearSemester vSem ON vSem.Code = vsa.CurrentSemester  " & _
                    " LEFT JOIN SubGroup_Image Si WITH (NoLock) ON vsa.Student=Si.SubCode " & mCondStr & " "

            mqry1 = " SELECT SSa.Amount ,vsa.AdmissionID,vsys.StreamYearSemesterDesc,vsf.DispName AS fee  " & _
                      " FROM Sch_AdmissionFeeDetail ssa WITH (NoLock)  " & _
                      " LEFT JOIN Sch_Admission VSA WITH (NoLock) ON ssa.DocId=vsa.DocId " & _
                      " Left Join SiteMast S WITH (NoLock) On Vsa.Site_Code =  S.Code   " & _
                      " LEFT JOIN viewSch_Student SS WITH (NoLock) ON vsa.Student=ss.SubCode  " & _
                      " LEFT JOIN ViewSch_StreamYearSemester vSem ON vSem.Code = vsa.CurrentSemester  " & _
                      " LEFT JOIN ViewSch_StreamYearSemester VSYS WITH (NoLock) ON ssa.StreamYearSemester=vsys.Code " & _
                      " LEFT JOIN ViewSch_Fee vsf WITH (NoLock) ON ssa.Fee=vsf.Code " & mCondStr & " "

            DsRep1 = AgL.FillData(mqry1, AgL.GCn)
            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Academic_Student_Card" : RepTitle = "Student Card"
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.SubReport1DataSet = DsRep1

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Student Ledger"
    Private Sub ProcStudentLedger()
        Dim bOpeningCondStr$ = ""
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub


            mCondStr = " WHERE 1=1 "

            If ObjRFG.GetWhereCondition("L.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("L.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Category", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.SessionProgrammeCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.SessionCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.DocId", 4)

            bOpeningCondStr = mCondStr

            bOpeningCondStr += " AND L.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " "
            mCondStr += " And L.SubCode <> V1.Student And L.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & ""

            mQry = "SELECT 'Opening' As LedgerDocId, '' As [Ledger_VNo], 0 AS LedgerRowId, " & _
                    " Case When IsNull(Sum(L.AmtDr),0) - IsNull(Sum(L.AmtCr),0) >= 0 Then 0 Else Abs(IsNull(Sum(L.AmtDr),0) - IsNull(Sum(L.AmtCr),0) ) End As StudentCrAmt , " & _
                    " Case When IsNull(Sum(L.AmtDr),0) - IsNull(Sum(L.AmtCr),0) >= 0 Then IsNull(Sum(L.AmtDr),0) - IsNull(Sum(L.AmtCr),0) Else 0 End  As StudentDrAmt , " & _
                    " " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " As V_Date, Null As Chq_No, Null As Chq_Date, Null As Clg_Date, '' AS LineNarration, '' AS CommonNarration, Max(L.SubCode) As SubCode , 'Opening Balance' AS AcName, " & _
                    " Max(S.SubCode) AS StudentCode, Max(S.Name) AS StudentName, Max(S.DispName) AS StudentDispName, Max(S.ManualCode) AS StudentManualCode, Max(S.Add1) As Add1, Max(S.add2) As Add2, Max(S.Add3) As Add3, Max(S.CityName) As CityName, Max(S.PIN) As PIN, " & _
                    " Max(S.Phone) As Phone, Max(S.Mobile) As Mobile, Max(S.EMail) As EMail, Max(S.FatherName) As FatherName, Max(S.MotherName) As MotherName, Max(S.CategoryDesc) As CategoryDesc, Max(S.CategoryManualCode) As CategoryManualCode, Max(S.ReligionDesc) As ReligionDesc, " & _
                    " Max(Sm.Name) AS Site_Name, Max(L.Site_Code) As Site_Code, Max(L.DivCode) As Div_Code, Max(V1.AdmissionID) As AdmissionID, Max(V1.Status) As Status, Max(V1.EnrollmentNo) As EnrollmentNo, Max(V1.RollNo) As RollNo, Max(V1.SessionProgrammeDesc) As SessionProgrammeDesc, Max(V1.SessionManualCode) As SessionManualCode " & _
                    " FROM ViewSch_Admission V1 " & _
                    " INNER JOIN Ledger L On V1.Student = L.SubCode " & _
                    " LEFT JOIN SubGroup SgL ON L.SubCode = SgL.SubCode  " & _
                    " LEFT JOIN LedgerM Lm ON L.DocId = Lm.DocId  " & _
                    " LEFT JOIN ViewSch_Student S ON V1.Student = S.SubCode  " & _
                    " LEFT JOIN SiteMast Sm ON L.Site_Code = Sm.Code " & _
                    " " & bOpeningCondStr & " Group By V1.DocId  "

            mQry += " UNION ALL " & _
                    " SELECT  L.DocId As LedgerDocId, " & AgL.V_No_Field("L.DocId") & " As [Ledger_VNo], L.RowId AS LedgerRowId, L.AmtDr As StudentCrAmt , L.AmtCr As StudentDrAmt , " & _
                    " L.V_Date, L.Chq_No, L.Chq_Date, L.Clg_Date, L.Narration AS LineNarration, Lm.Narration AS CommonNarration, L.SubCode , SgL.Name AS AcName, " & _
                    " S.SubCode AS StudentCode, S.Name AS StudentName, S.DispName AS StudentDispName, S.ManualCode AS StudentManualCode, S.Add1, S.add2, S.Add3, S.CityName, S.PIN, " & _
                    " S.Phone, S.Mobile, S.EMail, S.FatherName, S.MotherName, S.CategoryDesc, S.CategoryManualCode, ReligionDesc, " & _
                    " Sm.Name AS Site_Name, L.Site_Code, L.DivCode As Div_Code, V1.AdmissionID, V1.Status, V1.EnrollmentNo, V1.RollNo, V1.SessionProgrammeDesc, V1.SessionManualCode " & _
                    " FROM Ledger L " & _
                    " INNER JOIN " & _
                    " ( " & _
                    " 	SELECT Distinct L1.DocId AS LedgerDocId, A.* " & _
                    " 	FROM ViewSch_Admission A  " & _
                    " 	LEFT JOIN Ledger L1 ON L1.SubCode = A.Student  " & _
                    " ) V1 ON V1.LedgerDocId = L.DocId " & _
                    " LEFT JOIN SubGroup SgL ON L.SubCode = SgL.SubCode  " & _
                    " LEFT JOIN LedgerM Lm ON L.DocId = Lm.DocId  " & _
                    " LEFT JOIN ViewSch_Student S ON V1.Student = S.SubCode  " & _
                    " LEFT JOIN SiteMast Sm ON L.Site_Code = Sm.Code  " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "Academic_Student_Ledger" : RepTitle = "Student Ledger"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Fee Collection Report"
    Private Sub ProcFeeCollectionReport()
        Try


            Dim mCondStr$ = "", bView1Str$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            Call ObjRFG.FillGridString()

            mCondStr = " Where Fr.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("Fr.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Fr.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Fr.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Fr.CurrentStreamYearSemesterCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("ST.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionProgrammeCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionCode", 5)

            mQry = "SELECT Max(Sm.Name) AS Site_Name, Fr.Site_Code , Max(S.StartDate) AS SessionStartDate, " & _
                    " IsNull(sum(pd.CashAmount),0) AS CashAmount, IsNull(sum(pd.BankAmount),0) + IsNull(sum(pd.BankAmount2),0) + IsNull(sum(pd.BankAmount3),0) AS BankAmount, " & _
                    " IsNull(sum(pd.CardAmount),0) AS CardAmount, IsNull(sum(pd.AcTransferAmount),0) AS AcTransferAmount, IsNull(sum(fr.TotalLineDiscount),0) AS LineDiscount, " & _
                    " IsNull(sum(fr.DiscountAmount),0) AS HederDiscountAmount, IsNull(sum(fr.AdjustmentAmount),0) AS AdjustmentAmount, IsNull(Sum(Fr.TotalAdvanceAdjusted),0) As TotalAdvanceAdjusted, " & _
                    " Sem.StreamYearSemesterDesc, Max(Sem.SessionProgrammeStreamDesc) AS SessionProgrammeStreamDesc, S.Description AS SessionDesc " & _
                    " FROM ViewSch_FeeReceive FR  " & _
                    " LEFT JOIN PaymentDetail pd ON fr.DocId=pd.docid  " & _
                    " LEFT JOIN SiteMast Sm ON FR.Site_Code = Sm.Code " & _
                    " LEFT JOIN Sch_Admission A On A.DocId = Fr.AdmissionDocId " & _
                    " LEFT JOIN Sch_Student St On A.Student = St.SubCode " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON Sem.Code = Fr.CurrentStreamYearSemesterCode  " & _
                    " LEFT JOIN Sch_Session S ON Sem.SessionCode = S.Code  " & _
                    " " & mCondStr & " GROUP BY Fr.Site_Code, S.Description, Sem.StreamYearSemesterDesc "

            RepName = "Academic_Fee_Collection_Report" : RepTitle = "Fee Collection Report"
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Additional/Fee Fine Receipt Report"
    Private Sub ProcAdditionalFeeFineReceiptReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""
            Dim mqry1 As String

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where Fr.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("Fr.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Fr.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Fr.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.Code", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSS.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionProgrammeCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("ViewSch_Admission.DocId", 6)


            mQry = " SELECT VSPSY.StreamYearSemesterDesc, Sch_Category.manualcode AS Category, " & _
                    " Fr1.NetAmount NetReceiveAmount ,Fr1.Discount AS Discount, " & _
                    " ViewSch_Admission.AdmissionID as AdmissionId,Fr.V_Date, VSS.name as StudenName, " & _
                    " VSPSY.StreamManualCode as Stream,VSPSY.ProgrammeManualCode as Programme, " & _
                    " VSPSY.SessionDescription as Session,subgroup.dispname as Fees,Fr.v_no as Vno, Fr1.Amount AS ReceiveAmount, " & AgL.V_No_Field("Fr.DocId") & " As Receipt_VNo, " & _
                    " '" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForSemester,'" & ObjRFG.GetHelpString(2) & "' As ForCatgory, " & _
                    " '" & ObjRFG.GetHelpString(3) & "' As ForStream,'" & ObjRFG.GetHelpString(4) & "' As ForProgramme,'" & ObjRFG.GetHelpString(5) & "' As ForSession, " & _
                    " '" & ObjRFG.GetHelpString(6) & "' As ForSTUDENT, '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' as Todate " & _
                    " FROM ViewSch_FeeReceive Fr " & _
                    " LEFT JOIN ViewSch_FeeReceive1 Fr1 ON Fr.DocId = Fr1.DocId " & _
                    " LEFT JOIN ViewSch_FeeDue VFD  ON Fr1.FeeDue1 = Vfd.FeeDue1Code  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester VSPSY ON VFD.StreamYearSemester = VSPSY.Code   " & _
                    " Left join Sch_Fee on vfd.FeeCode=Sch_Fee.code   " & _
                    " left join subgroup on Sch_Fee.code=subgroup.subcode  " & _
                    " LEFT JOIN ViewSch_Admission ON vfd.AdmissionDocId=ViewSch_Admission.DocId   " & _
                    " LEFT JOIN viewSch_Student VSS ON ViewSch_Admission.Student=VSS.SubCode   " & _
                    " LEFT JOIN Sch_Category ON VSS.Category=Sch_Category.Code   " & _
                    " " & mCondStr & " "

            mqry1 = " SELECT sum(Fr1.NetAmount) as Receive,subgroup.Name as Fees  " & _
                    " FROM ViewSch_FeeReceive Fr " & _
                    " LEFT JOIN ViewSch_FeeReceive1 Fr1 ON Fr.DocId = Fr1.DocId " & _
                    " LEFT JOIN ViewSch_FeeDue VFD  ON Fr1.FeeDue1 = Vfd.FeeDue1Code  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester VSPSY ON VFD.StreamYearSemester = VSPSY.Code " & _
                    " Left join Sch_Fee on vfd.FeeCode=Sch_Fee.code " & _
                    " left join subgroup on Sch_Fee.code=subgroup.subcode" & _
                    " LEFT JOIN ViewSch_Admission ON vfd.AdmissionDocId=ViewSch_Admission.DocId " & _
                    " LEFT JOIN viewSch_Student VSS ON ViewSch_Admission.Student=VSS.SubCode " & _
                    " LEFT JOIN Sch_Category ON VSS.Category=Sch_Category.Code " & _
                    " " & mCondStr & " group by subgroup.name  having  sum(Fr1.NetAmount) > 0 "

            If GRepFormName = FeeReceiptHeadWiseReport Then
                RepName = "Academic_Fee_Receipt_HeadWise_Report" : RepTitle = "Fee Receipt HeadWise Report"
            ElseIf GRepFormName = FeeReceiveReportSessionwise Then
                DsRep1 = AgL.FillData(mqry1, AgL.GCn)
                RepName = "Academic_Fee_Fee_Receive_Report_Sessionwise" : RepTitle = "Fee Receive Report Sessionwise"
            Else
                mQry = mQry & " and Sch_Fee.feenature in ('Late Fee','Fine','Others')  "
                RepName = "Academic_Additional_FeeFine_Receipt_Report" : RepTitle = "Additional/Fee Fine Receipt Report"
            End If
            DsRep = AgL.FillData(mQry, AgL.GCn)


            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            If GRepFormName = FeeReceiveReportSessionwise Then
                ObjRFG.SubReport1DataSet = DsRep1
                ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
            Else
                ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Fee Head Detail Report Year Wise"
    Private Sub ProcFeeHeadDetailReportYearWise()
        Try
            Dim mCondStr$ = "", mCondStr1$ = "", bViewStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            Call ObjRFG.FillGridString()

            mCondStr = " where VFD.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("VFD.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("VFD.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("VFD.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.Code", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSS.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionProgrammeCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("ViewSch_Admission.DocId", 6)


            bViewStr = FunGetFeeDueStr(ObjRFG.ParameterDate1_Value, ObjRFG.ParameterDate2_Value)

            mQry = " SELECT VSPSY.StreamYearSemesterDesc ,Sch_Category.manualcode AS Category, " & _
                   " (case when VSYS.YearSerial=1 then vfd.dueamount else 0 end) AS Fy_TotalAmount, " & _
                   " (case when VSYS.YearSerial=1 then IsNull(vfd.TillDate_ReceiveAmount,0) - IsNull(vfd.TillDate_NetRefundAmount,0) else 0 end) AS FY_GrossReceiveLessRefund," & _
                   " (case when VSYS.YearSerial=1 then vfd.TillDate_NetBalance else 0 end ) AS Fy_BalAmt , " & _
                   " (case when VSYS.YearSerial=1 then vfd.TillDate_Discount else 0 end) AS Fy_Discount, " & _
                   " (case when VSYS.YearSerial=2 then vfd.dueamount else 0 end) AS Sy_TotalAmount, " & _
                   " (case when VSYS.YearSerial=2 then IsNull(vfd.TillDate_ReceiveAmount,0) - IsNull(vfd.TillDate_NetRefundAmount,0) else 0 end) AS SY_GrossReceiveLessRefund," & _
                   " (case when VSYS.YearSerial=2 then vfd.TillDate_NetBalance else 0 end ) AS Sy_BalAmt , " & _
                   " (case when VSYS.YearSerial=2 then vfd.TillDate_Discount else 0 end) AS Sy_Discount, " & _
                   " (case when VSYS.YearSerial=3 then vfd.dueamount else 0 end) AS ty_TotalAmount, " & _
                   " (case when VSYS.YearSerial=3 then IsNull(vfd.TillDate_ReceiveAmount,0) - IsNull(vfd.TillDate_NetRefundAmount,0) else 0 end) AS tY_GrossReceiveLessRefund," & _
                   " (case when VSYS.YearSerial=3 then vfd.TillDate_NetBalance else 0 end ) AS ty_BalAmt , " & _
                   " (case when VSYS.YearSerial=3 then vfd.TillDate_Discount else 0 end) AS ty_Discount, " & _
                   " (case when VSYS.YearSerial>=4 then vfd.dueamount else 0 end) AS Foy_TotalAmount, " & _
                   " (case when VSYS.YearSerial>=4 then IsNull(vfd.TillDate_ReceiveAmount,0) - IsNull(vfd.TillDate_NetRefundAmount,0) else 0 end) AS foY_GrossReceiveLessRefund," & _
                   " (case when VSYS.YearSerial>=4 then vfd.TillDate_NetBalance else 0 end ) AS Foy_BalAmt , " & _
                   " (case when VSYS.YearSerial>=4 then vfd.TillDate_Discount else 0 end) AS Foy_Discount, " & _
                   " (case when VSYS.YearSerial=1 then vFd.OpeningDueAmount else 0 end) AS Fy_OpeningTotalAmount, " & _
                   " (case when VSYS.YearSerial=1 then vfd.OpeningReceiveAmount else 0 end) AS FY_OpeningReceiveAmount," & _
                   " (case when VSYS.YearSerial=1 then vfd.OpeningNetReceiveAmount else 0 end) AS FY_OpeningNetReceiveAmount," & _
                   " (case when VSYS.YearSerial=1 then vfd.OpeningNetBalance else 0 end ) AS Fy_OpeningNetBalance , " & _
                   " (case when VSYS.YearSerial=1 then vfd.OpeningDiscount else 0 end) AS Fy_OpeningDiscount, " & _
                   " (case when VSYS.YearSerial=2 then vFd.OpeningDueAmount else 0 end) AS Sy_OpeningTotalAmount, " & _
                   " (case when VSYS.YearSerial=2 then vfd.OpeningReceiveAmount else 0 end) AS Sy_OpeningReceiveAmount," & _
                   " (case when VSYS.YearSerial=2 then vfd.OpeningNetReceiveAmount else 0 end) AS Sy_OpeningNetReceiveAmount," & _
                   " (case when VSYS.YearSerial=2 then vfd.OpeningNetBalance else 0 end ) AS Sy_OpeningNetBalance , " & _
                   " (case when VSYS.YearSerial=2 then vfd.OpeningDiscount else 0 end) AS Sy_OpeningDiscount, " & _
                   " (case when VSYS.YearSerial=3 then vFd.OpeningDueAmount else 0 end) AS Ty_OpeningTotalAmount, " & _
                   " (case when VSYS.YearSerial=3 then vfd.OpeningReceiveAmount else 0 end) AS Ty_OpeningReceiveAmount," & _
                   " (case when VSYS.YearSerial=3 then vfd.OpeningNetReceiveAmount else 0 end) AS Ty_OpeningNetReceiveAmount," & _
                   " (case when VSYS.YearSerial=3 then vfd.OpeningNetBalance else 0 end ) AS Ty_OpeningNetBalance , " & _
                   " (case when VSYS.YearSerial=3 then vfd.OpeningDiscount else 0 end) AS Ty_OpeningDiscount, " & _
                   " (case when VSYS.YearSerial>=4 then vFd.OpeningDueAmount else 0 end) AS Foy_OpeningTotalAmount, " & _
                   " (case when VSYS.YearSerial>=4 then vfd.OpeningReceiveAmount else 0 end) AS Foy_OpeningReceiveAmount," & _
                   " (case when VSYS.YearSerial>=4 then vfd.OpeningNetReceiveAmount else 0 end) AS Foy_OpeningNetReceiveAmount," & _
                   " (case when VSYS.YearSerial>=4 then vfd.OpeningNetBalance else 0 end ) AS Foy_OpeningNetBalance , " & _
                   " (case when VSYS.YearSerial>=4 then vfd.OpeningDiscount else 0 end) AS Foy_OpeningDiscount, " & _
                   " (case when VSYS.YearSerial=1 then Vfd.CurrentDueAmount else 0 end) AS Fy_CurrentTotalAmount, " & _
                   " (case when VSYS.YearSerial=1 then vfd.CurrentReceiveAmount else 0 end) AS FY_CurrentReceiveAmount," & _
                   " (case when VSYS.YearSerial=1 then vfd.CurrentNetReceiveAmount else 0 end) AS FY_CurrentNetReceiveAmount," & _
                   " (case when VSYS.YearSerial=1 then vfd.CurrentNetBalance else 0 end ) AS Fy_CurrentNetBalance , " & _
                   " (case when VSYS.YearSerial=1 then vfd.CurrentDiscount else 0 end) AS Fy_CurrentDiscount, " & _
                   " (case when VSYS.YearSerial=2 then Vfd.CurrentDueAmount else 0 end) AS Sy_CurrentTotalAmount, " & _
                   " (case when VSYS.YearSerial=2 then vfd.CurrentReceiveAmount else 0 end) AS Sy_CurrentReceiveAmount," & _
                   " (case when VSYS.YearSerial=2 then vfd.CurrentNetReceiveAmount else 0 end) AS Sy_CurrentNetReceiveAmount," & _
                   " (case when VSYS.YearSerial=2 then vfd.CurrentNetBalance else 0 end ) AS Sy_CurrentNetBalance , " & _
                   " (case when VSYS.YearSerial=2 then vfd.CurrentDiscount else 0 end) AS Sy_CurrentDiscount, " & _
                   " (case when VSYS.YearSerial=3 then Vfd.CurrentDueAmount else 0 end) AS Ty_CurrentTotalAmount, " & _
                   " (case when VSYS.YearSerial=3 then vfd.CurrentReceiveAmount else 0 end) AS Ty_CurrentReceiveAmount," & _
                   " (case when VSYS.YearSerial=3 then vfd.CurrentNetReceiveAmount else 0 end) AS Ty_CurrentNetReceiveAmount," & _
                   " (case when VSYS.YearSerial=3 then vfd.CurrentNetBalance else 0 end ) AS Ty_CurrentNetBalance , " & _
                   " (case when VSYS.YearSerial=3 then vfd.CurrentDiscount else 0 end) AS Ty_CurrentDiscount, " & _
                   " (case when VSYS.YearSerial>=4 then Vfd.CurrentDueAmount else 0 end) AS Foy_CurrentTotalAmount, " & _
                   " (case when VSYS.YearSerial>=4 then vfd.CurrentReceiveAmount else 0 end) AS Foy_CurrentReceiveAmount," & _
                   " (case when VSYS.YearSerial>=4 then vfd.CurrentNetReceiveAmount else 0 end) AS Foy_CurrentNetReceiveAmount," & _
                   " (case when VSYS.YearSerial>=4 then vfd.CurrentNetBalance else 0 end ) AS Foy_CurrentNetBalance , " & _
                   " (case when VSYS.YearSerial>=4 then vfd.CurrentDiscount else 0 end) AS Foy_CurrentDiscount, " & _
                   " (case when VSYS.YearSerial=1 then vfd.TillDate_ReceiveAmount else 0 end) AS Fy_TillDate_ReceiveAmount," & _
                   " (case when VSYS.YearSerial=1 then vfd.TillDate_NetReceiveAmount else 0 end) AS Fy_TillDate_NetReceiveAmount," & _
                   " (case when VSYS.YearSerial=2 then vfd.TillDate_ReceiveAmount else 0 end) AS Sy_TillDate_ReceiveAmount," & _
                   " (case when VSYS.YearSerial=2 then vfd.TillDate_NetReceiveAmount else 0 end) AS Sy_TillDate_NetReceiveAmount," & _
                   " (case when VSYS.YearSerial=3 then vfd.TillDate_ReceiveAmount else 0 end) AS Ty_TillDate_ReceiveAmount," & _
                   " (case when VSYS.YearSerial=3 then vfd.TillDate_NetReceiveAmount else 0 end) AS Ty_TillDate_NetReceiveAmount," & _
                   " (case when VSYS.YearSerial>=4 then vfd.TillDate_ReceiveAmount else 0 end) AS Foy_TillDate_ReceiveAmount," & _
                   " (case when VSYS.YearSerial>=4 then vfd.TillDate_NetReceiveAmount else 0 end) AS Foy_TillDate_NetReceiveAmount," & _
                   " (case when VSYS.YearSerial=1 then vfd.TillDate_NetRefundAmount else 0 end) AS Fy_TillDate_NetRefundAmount, " & _
                   " (case when VSYS.YearSerial=1 then vfd.OpeningNetRefundAmount else 0 end) AS Fy_OpeningNetRefundAmount," & _
                   " (case when VSYS.YearSerial=1 then vfd.CurrentNetRefundAmount else 0 end) AS Fy_CurrentNetRefundAmount, " & _
                   " (case when VSYS.YearSerial=2 then vfd.TillDate_NetRefundAmount else 0 end) AS Sy_TillDate_NetRefundAmount, " & _
                   " (case when VSYS.YearSerial=2 then vfd.OpeningNetRefundAmount else 0 end) AS Sy_OpeningNetRefundAmount," & _
                   " (case when VSYS.YearSerial=2 then vfd.CurrentNetRefundAmount else 0 end ) AS Sy_CurrentNetRefundAmount, " & _
                   " (case when VSYS.YearSerial=3 then vfd.TillDate_NetRefundAmount else 0 end) AS Ty_TillDate_NetRefundAmount, " & _
                   " (case when VSYS.YearSerial=3 then vfd.OpeningNetRefundAmount else 0 end) AS Ty_OpeningNetRefundAmount," & _
                   " (case when VSYS.YearSerial=3 then vfd.CurrentNetRefundAmount else 0 end ) AS Ty_CurrentNetRefundAmount, " & _
                   " (case when VSYS.YearSerial>=4 then vfd.TillDate_NetRefundAmount else 0 end) AS Foy_TillDate_NetRefundAmount, " & _
                   " (case when VSYS.YearSerial>=4 then vfd.OpeningNetRefundAmount else 0 end) AS Foy_OpeningNetRefundAmount," & _
                   " (case when VSYS.YearSerial>=4 then vfd.CurrentNetRefundAmount else 0 end ) AS Foy_CurrentNetRefundAmount," & _
                   " ViewSch_Admission.AdmissionID as AdmissionId,VSS.fathername as FatherName,VFD.V_Date, " & _
                   " VSS.name as StudenName, VSPSY.StreamManualCode as Stream, VSPSY.ProgrammeManualCode as Programme, S.Description as Session,subgroup.dispname as Fees, " & _
                   " '" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForSemester,'" & ObjRFG.GetHelpString(2) & "' As ForCatgory, " & _
                   " '" & ObjRFG.GetHelpString(3) & "' As ForStream,'" & ObjRFG.GetHelpString(4) & "' As ForProgramme,'" & ObjRFG.GetHelpString(5) & "' As ForSession, " & _
                   " '" & ObjRFG.GetHelpString(6) & "' As ForSTUDENT, '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' as Todate " & _
                   " FROM (" & bViewStr & ") VFD " & _
                   " LEFT JOIN ViewSch_StreamYearSemester VSPSY ON  VFD.StreamYearSemester = VSPSY.Code " & _
                   " Left join Sch_Fee on vfd.FeeCode=Sch_Fee.code " & _
                   " left join subgroup on Sch_Fee.code=subgroup.subcode" & _
                   " LEFT JOIN ViewSch_Admission ON vfd.AdmissionDocId=ViewSch_Admission.DocId " & _
                   " LEFT JOIN viewSch_Student VSS ON ViewSch_Admission.Student=VSS.SubCode " & _
                   " LEFT JOIN Sch_Category ON VSS.Category=Sch_Category.Code " & _
                   " Left join ViewSch_SessionProgrammeStreamYear VSYS on VSPSY.SessionProgrammeStreamYear=VSYS.SessionProgrammeStreamYearcode   " & _
                   " LEFT JOIN Sch_Session S ON VSPSY.SessionCode = S.Code " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)


            If GRepFormName = FeeDetailReportCourseYearwise Then
                RepName = "Academic_Fee_Detail_Report_Course_Yearwise" : RepTitle = "Fee Detail Report Course Yearwise"
            Else
                RepName = "Academic_Fee_Head_Detail_Report_Year_Wise" : RepTitle = "Fee Head Detail Report Year Wise"
            End If

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Fee Structure Report"
    Private Sub ProcFeeStructureReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where 1=1 "

            If ObjRFG.GetWhereCondition("Vssf.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Vssf.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Vssf.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsp.Session", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsps.Stream", 2)




            mQry = " SELECT vssf.FeeName,vssf.YearStartDate AS Duedate,vssf.Amount,vssf.SessionProgrammeStreamYearDesc,vsps.ProgrammeManualCode, vsps.SessionManualCode " & _
                   " ,Sch_Stream.Description AS Stream ,vsp.SessionDescription, " & _
                   " '" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForSession,'" & ObjRFG.GetHelpString(2) & "' As ForStream" & _
                   " FROM ViewSch_StreamYearSemesterFee vSSF " & _
                   " LEFT JOIN ViewSch_SessionProgrammeStreamYear VSSY ON vssf.SessionProgrammeStreamYear=vssy.SessionProgrammeStreamYearCode " & _
                   " LEFT JOIN ViewSch_SessionProgrammeStream VSPS ON vssy.SessionProgrammeStreamCode=vsps.code " & _
                   " LEFT JOIN Sch_Stream ON vsps.Stream=Sch_Stream.code  LEFT JOIN ViewSch_SessionProgramme  VSP ON vsps.SessionProgramme=vsp.Code " & mCondStr & ""



            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "Academic_Fee_Structure_Report" : RepTitle = "Fee Structure Report"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Student Outstanding Report Fee Head Wise"

    Private Sub ProcStudentOutstandingReportFeeHeadWise()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "", bViewStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where VFD.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("VFD.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("VFD.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("VFD.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.Code", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSS.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionProgrammeCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.DocId", 6)

            mCondStr = mCondStr & " and case when A.LeavingDate is  null then " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " else A.LeavingDate end <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & "   "
            mCondStr = mCondStr & "  AND vfd.TillDate_NetBalance > 0 "

            bViewStr = FunGetFeeDueStr(ObjRFG.ParameterDate1_Value, ObjRFG.ParameterDate2_Value)

            mQry = " SELECT VSPSY.StreamYearSemesterDesc ,Sch_Category.manualcode AS Category, " & _
                   " vfd.dueamount AS TotalAmount, vfd.TillDate_NetReceiveAmount AS ReceivedAmt,vfd.TillDate_Discount AS Discount,A.AdmissionID as AdmissionId,VFD.V_Date," & _
                   " vfd.TillDate_NetBalance AS BalAmt,VSS.name as StudenName, VSPSY.StreamManualCode as Stream, VSPSY.ProgrammeManualCode as Programme, S.Description as Session, subgroup.dispname as Fees,vss.dispname as StudentDisplayName, " & _
                   " '" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForSemester,'" & ObjRFG.GetHelpString(2) & "' As ForCatgory, " & _
                   " '" & ObjRFG.GetHelpString(3) & "' As ForStream,'" & ObjRFG.GetHelpString(4) & "' As ForProgramme,'" & ObjRFG.GetHelpString(5) & "' As ForSession, " & _
                   " '" & ObjRFG.GetHelpString(6) & "' As ForSTUDENT, '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' as Todate, " & _
                   " vFd.OpeningDueAmount, Vfd.CurrentDueAmount, Vfd.OpeningNetReceiveAmount, Vfd.CurrentNetReceiveAmount, " & _
                   " Vfd.OpeningDiscount, Vfd.CurrentDiscount, Vfd.OpeningNetBalance, Vfd.CurrentNetBalance, " & _
                   " vFd.TillDate_NetRefundAmount, vFd.OpeningNetRefundAmount, vFd.CurrentNetRefundAmount " & _
                   " FROM (" & bViewStr & ") VFD " & _
                   " LEFT JOIN ViewSch_StreamYearSemester VSPSY ON VFD.StreamYearSemester = VSPSY.Code " & _
                   " Left join Sch_Fee on vfd.FeeCode=Sch_Fee.code " & _
                   " left join subgroup on Sch_Fee.code=subgroup.subcode" & _
                   " LEFT JOIN ViewSch_Admission A ON vfd.AdmissionDocId=A.DocId " & _
                   " LEFT JOIN viewSch_Student VSS ON A.Student=VSS.SubCode " & _
                   " LEFT JOIN Sch_Category ON VSS.Category=Sch_Category.Code " & _
                   " LEFT JOIN Sch_Session S ON VSPSY.SessionCode = S.Code " & _
                   " " & mCondStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Academic_Student_Outstanding_Report_FeeHead_Wise" : RepTitle = "Student Outstanding Report FeeHead Wise"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Fee Due/Collection Summary"
    Private Sub ProcFeeCollectionSummary()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim bFeeReceiveStr$ = "", bFeeReceive1Str$ = "", bViewFeeReceive1Str$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " Where FRecv.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("FRecv.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("FRecv.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("FRecv.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.Code", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSS.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionProgrammeCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("FRecv.AdmissionDocId", 6)

            If GRepFormName = FeeCollectionSummaryFeeHeadWise Then mCondStr = mCondStr & ObjRFG.GetWhereCondition("V1.FeeCode", 7)

            mCondStr = mCondStr & " And Case When A.LeavingDate Is Null Then " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " Else A.LeavingDate End <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & "   "


            bFeeReceive1Str = "SELECT FRecv.Site_Code, FRecv.AdmissionDocId, FRecv1.FeeDue1 AS FeeDue1Code, " & _
                                " FRecv.CurrentStreamYearSemesterCode, Max(FRecv.SessionProgrammeStreamCode) AS SessionProgrammeStreamCode, " & _
                                " Max(FRecv1.Amount) AS FeeDue, Sum(FRecv1.Discount) AS FeeDiscount, Sum(FRecv1.NetAmount) AS FeeReceive, IsNull(Sum(vFRef1.NetFeeRefund),0) AS NetFeeRefund, " & _
                                " Max(vFd.FeeCode) AS FeeCode, Max(Sg.DispName) as FeeDispName, Max(Sg.Name) As FeeName, Max(Sg.ManualCode) AS FeeShortName, " & _
                                " IsNull(Max(FRecv1.Amount),0) - (IsNull(Sum(FRecv1.Discount),0) + IsNull(Sum(FRecv1.NetAmount),0) ) + IsNull(Sum(vFRef1.NetFeeRefund),0) As FeeBalance " & _
                                " FROM ViewSch_FeeReceive FRecv " & _
                                " LEFT JOIN Sch_FeeReceive1 FRecv1 ON FRecv.DocId = FRecv1.DocId " & _
                                " LEFT JOIN  " & _
                                " (SELECT * FROM ViewSch_FeeDue Fd WHERE Fd.V_Date  <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & ") vFd ON FRecv1.FeeDue1 = vFd.FeeDue1Code " & _
                                " LEFT JOIN SubGroup Sg ON vFd.FeeCode = Sg.SubCode " & _
                                " LEFT JOIN ( " & _
                                " SELECT FRef1.FeeReceive1 As FeeReceive1Code, Max(FRef1.Amount) AS NetFeeReceive, Sum(FRef1.NetAmount) AS NetFeeRefund " & _
                                " FROM Sch_FeeRefund FRef " & _
                                " LEFT JOIN Sch_FeeRefund1 FRef1 ON FRef.DocId = FRef1.DocId " & _
                                " WHERE FRef.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " " & _
                                " GROUP BY FRef1.FeeReceive1 " & _
                                " ) vFRef1 ON FRecv1.Code =  vFRef1.FeeReceive1Code " & _
                                " WHERE FRecv.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " " & _
                                " GROUP BY FRecv.Site_Code, FRecv.CurrentStreamYearSemesterCode, FRecv.AdmissionDocId, FRecv1.FeeDue1 "


            bViewFeeReceive1Str = " SELECT vFRecv1.Site_Code, vFRecv1.AdmissionDocId, vFRecv1.CurrentStreamYearSemesterCode, " & _
                                    " Sum(vFRecv1.FeeDue) AS FeeDue, Sum(vFRecv1.FeeDiscount) AS FeeDiscount, Sum(vFRecv1.FeeReceive) AS FeeReceive, Sum(vFRecv1.NetFeeRefund) AS NetFeeRefund, " & _
                                    " IsNull(Sum(vFRecv1.FeeBalance),0) As FeeBalance, " & _
                                    " " & IIf(AgL.StrCmp(GRepFormName, FeeCollectionSummaryFeeHeadWise), " vFRecv1.FeeCode ", "''") & " As FeeCode, " & _
                                    " " & IIf(AgL.StrCmp(GRepFormName, FeeCollectionSummaryFeeHeadWise), " Max(vFRecv1.FeeDispName) ", "''") & " As FeeDispName, " & _
                                    " " & IIf(AgL.StrCmp(GRepFormName, FeeCollectionSummaryFeeHeadWise), " Max(vFRecv1.FeeName) ", "''") & " As FeeName, " & _
                                    " " & IIf(AgL.StrCmp(GRepFormName, FeeCollectionSummaryFeeHeadWise), " Max(vFRecv1.FeeShortName) ", "''") & " As FeeShortName " & _
                                    " FROM ( " & bFeeReceive1Str & ") vFRecv1 " & _
                                    " GROUP BY vFRecv1.Site_Code, vFRecv1.AdmissionDocId, vFRecv1.CurrentStreamYearSemesterCode " & _
                                    " " & IIf(AgL.StrCmp(GRepFormName, FeeCollectionSummaryFeeHeadWise), " ,vFRecv1.FeeCode ", " ") & " "

            bFeeReceiveStr = "SELECT " & _
                                " FRecv.Site_Code, Max(Sm.Name) AS Site_Name, " & _
                                " " & IIf(AgL.StrCmp(GRepFormName, FeeCollectionSummaryStudentWise), "FRecv.AdmissionDocId", "''") & " As AdmissionDocId, " & _
                                " " & IIf(AgL.StrCmp(GRepFormName, FeeCollectionSummaryFeeHeadWise), "V1.FeeCode", "''") & " As FeeCode, " & _
                                " FRecv.CurrentStreamYearSemesterCode, Max(FRecv.SessionProgrammeStreamCode) AS SessionProgrammeStreamCode, " & _
                                " Sum(TotalAdvanceAdjusted) AS TotalAdvanceAdjusted, Sum(Advance) AS AdvanceBroughtForward, " & _
                                " Sum(AdjustmentAmount) AS RegAmtAdjustment, Sum(DiscountAmount) AS Header_Discount, " & _
                                " Sum(ReceiveAmount) AS TotalReceiveAmount, Sum(AdvanceCarriedForward) AS AdvanceCarriedForward, " & _
                                " IsNull(Sum(vFRef.RefundAmount),0) AS TotalRefundAmount, IsNull(Sum(vFRef.ExcessRefund),0) AS TotalExcessRefund, " & _
                                " Max(VSPSY.StreamYearSemesterDesc) AS StreamYearSemesterDesc, Max(C.ManualCode) AS Category, Max(A.AdmissionID) AS AdmissionID, Max(VSS.Name) as StudenName, Max(vss.DispName) as StudentDisplayName, " & _
                                " Max(VSPSY.StreamManualCode) as Stream, Max(VSPSY.ProgrammeManualCode) as Programme, Max(S.Description) as Session, " & _
                                " Max(V1.FeeDue) AS FeeDue, Max(V1.FeeDiscount) AS FeeDiscount, Max(FeeReceive) AS FeeReceive, Max(V1.NetFeeRefund) AS NetFeeRefund, " & _
                                " IsNull(Max(V1.FeeBalance),0) As FeeBalance, Max(V1.FeeDispName) As FeeDispName, Max(V1.FeeName) As FeeName, Max(V1.FeeShortName) As FeeShortName " & _
                                " FROM ViewSch_FeeReceive FRecv " & _
                                " Left Join SiteMast Sm On FRecv.Site_Code = Sm.Code " & _
                                " LEFT JOIN ViewSch_StreamYearSemester VSPSY ON FRecv.CurrentStreamYearSemesterCode = VSPSY.Code " & _
                                " LEFT JOIN ViewSch_Admission A ON FRecv.AdmissionDocId = A.DocId " & _
                                " LEFT JOIN viewSch_Student VSS ON A.Student = VSS.SubCode " & _
                                " LEFT JOIN Sch_Category C ON VSS.Category = C.Code " & _
                                " LEFT JOIN Sch_Session S ON VSPSY.SessionCode = S.Code " & _
                                " LEFT JOIN ( " & _
                                " SELECT  " & _
                                " FRef.Site_Code, FRef.FeeReceiveDocId, FRecv.AdmissionDocId, " & _
                                " Sum(FRef.RefundAmount) AS RefundAmount, Sum(FRef.ExcessRefund) AS ExcessRefund " & _
                                " FROM Sch_FeeRefund FRef " & _
                                " LEFT JOIN Sch_FeeReceive FRecv ON FRef.FeeReceiveDocId = FRecv.DocId  " & _
                                " WHERE FRecv.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " " & _
                                " GROUP BY FRef.Site_Code, FRef.FeeReceiveDocId, FRecv.AdmissionDocId " & _
                                " ) vFRef ON FRecv.DocId = vFRef.FeeReceiveDocId " & _
                                " LEFT JOIN (" & bViewFeeReceive1Str & ") V1 ON FRecv.AdmissionDocId = V1.AdmissionDocId AND FRecv.CurrentStreamYearSemesterCode = V1.CurrentStreamYearSemesterCode " & _
                                " " & mCondStr & " GROUP BY FRecv.Site_Code, " & IIf(AgL.StrCmp(GRepFormName, FeeCollectionSummaryFeeHeadWise), " V1.FeeCode, ", " FRecv.AdmissionDocId, ") & " FRecv.CurrentStreamYearSemesterCode "

            mQry = bFeeReceiveStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If GRepFormName = FeeCollectionSummaryStudentWise Then
                RepName = "Academic_FeeCollectionSummaryStudentWise" : RepTitle = "Fee Collection Summary (Student Wise)"

            ElseIf GRepFormName = FeeCollectionSummaryFeeHeadWise Then
                RepName = "Academic_FeeCollectionSummaryFeeHeadWise" : RepTitle = "Fee Collection Summary (Fee Head Wise)"
            End If



            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Category wise Course wise Outstanding"
    Private Sub ProcCategorywiseCoursewiseOutstanding()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "", bViewStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where VFD.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("VFD.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("VFD.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("VFD.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.Code", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSS.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionProgrammeCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSPSY.SessionCode", 5)
            mCondStr = mCondStr & " and case when ViewSch_Admission.LeavingDate is  null then " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " else ViewSch_Admission.LeavingDate end <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & "   "

            bViewStr = FunGetFeeDueStr(ObjRFG.ParameterDate1_Value, ObjRFG.ParameterDate2_Value)

            mQry = " SELECT VSPSY.StreamYearSemesterDesc ,Sch_Category.manualcode AS Category,  sum(vfd.dueamount) AS TotalAmount, " & _
                    " Sum(vfd.TillDate_NetReceiveAmount) AS ReceivedAmt,Sum(vfd.TillDate_Discount) AS Discount, sum(vfd.TillDate_NetBalance) AS BalAmt, Max(VSS.name) as StudentName, " & _
                    " ViewSch_Admission.AdmissionID,max(vss.dispname) as StudentDisplayName,   " & _
                    " '" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForSemester,'" & ObjRFG.GetHelpString(2) & "' As ForCatgory, " & _
                    " '" & ObjRFG.GetHelpString(3) & "' As ForStream,'" & ObjRFG.GetHelpString(4) & "' As ForProgramme,'" & ObjRFG.GetHelpString(5) & "' As ForSession, " & _
                    " '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' as Todate," & _
                    " Max(vss.manualcode) as StudentManualCode,  sum(vFd.OpeningDueAmount) AS OpeningDueAmount,Sum(Vfd.CurrentDueAmount) AS CurrentDueAmount,  " & _
                    " Sum(vfd.OpeningNetReceiveAmount) AS OpeningNetReceiveAmount, sum(vfd.CurrentNetReceiveAmount) AS CurrentNetReceiveAmount,  " & _
                    " sum(vfd.OpeningDiscount) AS OpeningDiscount, Sum(vfd.CurrentDiscount) AS CurrentDiscount, " & _
                    " Sum(vfd.OpeningNetBalance) AS OpeningNetBalance, sum(vfd.CurrentNetBalance) AS CurrentNetBalance, " & _
                    " Sum(vFd.TillDate_NetRefundAmount) As TillDate_NetRefundAmount, Sum(vFd.OpeningNetRefundAmount) As OpeningNetRefundAmount, Sum(vFd.CurrentNetRefundAmount) As CurrentNetRefundAmount " & _
                    " FROM (" & bViewStr & ") AS  VFD " & _
                    " LEFT JOIN ViewSch_StreamYearSemester VSPSY ON VFD.StreamYearSemester = VSPSY.Code   " & _
                    " LEFT JOIN ViewSch_Admission ON vfd.AdmissionDocId=ViewSch_Admission.DocId   " & _
                    " LEFT JOIN viewSch_Student VSS ON ViewSch_Admission.Student=VSS.SubCode   " & _
                    " LEFT JOIN Sch_Category ON VSS.Category=Sch_Category.Code " & _
                    " " & mCondStr & "  " & _
                    " GROUP BY VSPSY.StreamYearSemesterDesc, Sch_Category.manualcode, ViewSch_Admission.AdmissionID   " & _
                    " Having(Sum(vfd.TillDate_NetBalance) > 0)"
            DsRep = AgL.FillData(mQry, AgL.GCn)


            If GRepFormName = CategoryWiseCourseWiseOutstanding Then
                RepName = "Academic_Category_wise_Course_wise_Outstanding" : RepTitle = "Category wise Course wise Outstanding"
            ElseIf GRepFormName = StudentOutstandingReport Then
                RepName = "Academic_Student_Outstanding_Report" : RepTitle = "Student Outstanding Report"
            ElseIf GRepFormName = StudentOutstandingReportCategoryWise Then
                RepName = "Academic_Student_Outstanding_Report_CategoryWise" : RepTitle = "Student Outstanding Report Category Wise"
            End If
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try


    End Sub
#End Region

#Region "Registration Detail"
    Private Sub ProcRegistrationDetail()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""
            Dim mqry1$ = ""
            Dim mqry2 As String
            Dim subq$ = ""
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            

            mCondStr = " where Sr.V_Date Between " & AgL.ConvertDate(AgL.PubStartDate) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " "
            mCondStr1 = " where Sr.V_Date = " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " "


            If ObjRFG.GetWhereCondition("SR.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("SR.Site_Code", AgL.PubSiteCode) & ""
                mCondStr1 = mCondStr1 & " And " & AgL.PubSiteCondition("SR.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("SR.Site_Code", 0)
                mCondStr1 = mCondStr & ObjRFG.GetWhereCondition("SR.Site_Code", 0)
            End If

            subq = "(SELECT Sr.Docid, (CASE WHEN isnull(SPS.streammanualcode,'')='' THEN     SRS.Sr ELSE  1 END) AS sno  FROM viewSch_Registration SR     LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code  LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code WHERE    (CASE WHEN isnull(SPS.streammanualcode,'')='' THEN     SRS.Sr ELSE  1 END)=1 )"


            mQry = " SELECT 'Registration on Date ' AS vtype,Sr.Docid,(CASE WHEN Max(SR.v_type)='REG' THEN max(sp.ManualCode) ELSE (CASE WHEN Max(SR.v_type)='REG2' THEN 'B-Tech II Year' ELSE 'M-Tech' END)end) AS prgram, 0 AS Noof_student,1 AS ondate ," & _
                  " (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream " & _
                  " FROM viewSch_Registration SR     LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code  LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId " & _
                  " LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code " & _
                  " Left Join " & subq & "  AS v ON SR.DocId=v.docid " & mCondStr1 & " and SR.RegistrationCancelDocId IS  NULL  GROUP BY Sr.Docid  "

            mQry = mQry & " union all  SELECT 'Total Registration ' AS vtype,Sr.Docid,(CASE WHEN Max(SR.v_type)='REG' THEN max(sp.ManualCode) ELSE (CASE WHEN Max(SR.v_type)='REG2' THEN 'B-Tech II Year' ELSE 'M-Tech' END)end) AS prgram, 1 AS Noof_student,0 AS ondate ," & _
                              " (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream " & _
                              " FROM viewSch_Registration SR     LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code  LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId " & _
                              " LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code " & _
                              " Left Join " & subq & "   AS v ON SR.DocId=v.docid " & mCondStr & "  and SR.RegistrationCancelDocId IS  NULL  GROUP BY Sr.Docid  "


            mQry = mQry & " union all  SELECT 'Withdrawls  ' AS vtype,Sr.Docid,(CASE WHEN Max(SR.v_type)='REG' THEN max(sp.ManualCode) ELSE (CASE WHEN Max(SR.v_type)='REG2' THEN 'B-Tech II Year' ELSE 'M-Tech' END)end) AS prgram, 1 AS Noof_student,0 AS ondate ," & _
                              " (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream " & _
                              " FROM viewSch_Registration SR     LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code  LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId " & _
                              " LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code " & _
                              " Left Join " & subq & "  AS v ON SR.DocId=v.docid " & mCondStr & " and SR.RegistrationCancelDocId IS NOT NULL GROUP BY Sr.Docid  "


            mCondStr = mCondStr & " and SR.RegistrationCancelDocId IS  NULL  "
            mCondStr = mCondStr & " AND SR.v_type='REG'"

            mqry1 = "SELECT 'Direct Admissions' AS vtype,asadst.Status, Sch_Programme.ManualCode AS ProgrammeDescription , " & _
                    " (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream, " & _
                    " 1 AS [NO Of Student],asad.AdmissionID    FROM ViewSch_Admission asad    LEFT JOIN ViewSch_Registration  sr ON asad.DocId=SR.AdmissionDocId   LEFT JOIN ViewSch_SessionProgrammeStream vsps ON asad.SessionProgrammeStream=vsps.Code " & _
                    " LEFT JOIN ViewSch_SessionProgramme vsp ON vsps.SessionCode =vsp.Session       LEFT JOIN Sch_Programme ON vsps.ProgrammeCode=Sch_Programme.Code        LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code " & _
                    " LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  " & _
                    " Left Join " & subq & "   AS v ON SR.DocId=v.docid       left join Sch_RegistrationStatus asadst On   asadst.DocId = sr.DocId   " & _
                    " " & mCondStr & "   And asad.Site_Code='1' AND SR.RegistrationCancelDocId IS  NULL and asadst.Status='Seat Alloted By Management' " & _
                    " GROUP BY asadst.Status,vsps.SessionProgrammeStream,vsp.SessionDescription ,Sch_Programme.ManualCode,asad.AdmissionID "

            mqry1 = mqry1 & "union all SELECT 'Seat Alloted By UPSEE ' AS vtype,asadst.Status, Sch_Programme.ManualCode AS ProgrammeDescription , " & _
                    " (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream, " & _
                    " 1 AS [NO Of Student],asad.AdmissionID    FROM ViewSch_Admission asad    LEFT JOIN ViewSch_Registration  sr ON asad.DocId=SR.AdmissionDocId   LEFT JOIN ViewSch_SessionProgrammeStream vsps ON asad.SessionProgrammeStream=vsps.Code " & _
                    " LEFT JOIN ViewSch_SessionProgramme vsp ON vsps.SessionCode =vsp.Session       LEFT JOIN Sch_Programme ON vsps.ProgrammeCode=Sch_Programme.Code        LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code " & _
                    " LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  " & _
                    " Left Join " & subq & "   AS v ON SR.DocId=v.docid       left join Sch_RegistrationStatus asadst On   asadst.DocId = sr.DocId   " & _
                    " " & mCondStr & "   And asad.Site_Code='1' AND SR.RegistrationCancelDocId IS  NULL and asadst.Status='Seat Alloted By SEE UPTU' " & _
                    " GROUP BY asadst.Status,vsps.SessionProgrammeStream,vsp.SessionDescription ,Sch_Programme.ManualCode,asad.AdmissionID "


            mqry1 = mqry1 & "union all SELECT 'Counselling ' AS vtype,asadst.Status, Sch_Programme.ManualCode AS ProgrammeDescription , " & _
                    " (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream, " & _
                    " 1 AS [NO Of Student],asad.AdmissionID    FROM ViewSch_Admission asad    LEFT JOIN ViewSch_Registration  sr ON asad.DocId=SR.AdmissionDocId   LEFT JOIN ViewSch_SessionProgrammeStream vsps ON asad.SessionProgrammeStream=vsps.Code " & _
                    " LEFT JOIN ViewSch_SessionProgramme vsp ON vsps.SessionCode =vsp.Session       LEFT JOIN Sch_Programme ON vsps.ProgrammeCode=Sch_Programme.Code        LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code " & _
                    " LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  " & _
                    " Left Join " & subq & "   AS v ON SR.DocId=v.docid       left join Sch_RegistrationStatus asadst On   asadst.DocId = sr.DocId   " & _
                    " " & mCondStr & "   And asad.Site_Code='1' AND SR.RegistrationCancelDocId IS  NULL and asadst.Status not in ('Seat Alloted By SEE UPTU','Seat Alloted By Management') " & _
                    " GROUP BY asadst.Status,vsps.SessionProgrammeStream,vsp.SessionDescription ,Sch_Programme.ManualCode,asad.AdmissionID "

            'SR.v_type)='REG'

            'mCondStr = mCondStr & " AND SR.v_type='REG'"
            
            'mqry2 = "SELECT '  .UPSEE Qualified' as Maintype,'     1-25000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  " & mCondStr & " and SRE.Rank_No > 0 And SRE.Rank_No < 25001 And SR.AdmissionDocId Is null GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,'    25001-50000  ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  " & mCondStr & " and sRE.Rank_No > 25000 And SRE.Rank_No < 50001 And SR.AdmissionDocId Is null GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,'   50001-75000  ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  " & mCondStr & " and SRE.Rank_No > 50000 And SRE.Rank_No < 75001 And SR.AdmissionDocId Is null GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,'  75001-100000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  " & mCondStr & " and SRE.Rank_No > 75000 And SRE.Rank_No < 100001 And SR.AdmissionDocId Is null GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,' 100001-125000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  " & mCondStr & " and sRE.Rank_No > 100000 And SRE.Rank_No < 125001 And SR.AdmissionDocId Is null GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,' 125001-150000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  " & mCondStr & " and sRE.Rank_No > 125001 And SRE.Rank_No < 150000 And SR.AdmissionDocId Is null GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,'150001-175000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  " & mCondStr & " and SRE.Rank_No > 150001 And SRE.Rank_No < 175000 And SR.AdmissionDocId Is null GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,'Above 175000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  " & mCondStr & " and SRE.Rank_No > 175000 and SR.AdmissionDocId Is null GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT ' .AIEEE Qualified ' as Maintype,' ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  " & mCondStr & " and SRE.Rank_No2 > 0 and SRE.Rank_No = 0 and SR.AdmissionDocId Is null GROUP BY Sr.Docid "

            'mqry2 = mqry2 & " UNION ALL SELECT '% Wise Detail (UPSEE/AIEEE Not Qualified)' as Maintype,'    80% & ABOVE ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid   LEFT JOIN Sch_RegistrationAcademicDetail ON  SR.DocId=Sch_RegistrationAcademicDetail.docid " & mCondStr & "  and isnull(SRE.Rank_No, 0) = 0 And isnull(SRE.Rank_No2, 0) = 0 And SR.AdmissionDocId Is NULL AND Sch_RegistrationAcademicDetail.PCMPercentage>80  GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT '% Wise Detail (UPSEE/AIEEE Not Qualified)' as Maintype,'   75% TO 79.6 % ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  LEFT JOIN Sch_RegistrationAcademicDetail ON  SR.DocId=Sch_RegistrationAcademicDetail.docid " & mCondStr & "   and isnull(SRE.Rank_No, 0) = 0 And isnull(SRE.Rank_No2, 0) = 0 And SR.AdmissionDocId Is NULL AND Sch_RegistrationAcademicDetail.PCMPercentage>75 AND Sch_RegistrationAcademicDetail.PCMPercentage<=79.6 GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT '% Wise Detail (UPSEE/AIEEE Not Qualified)' as Maintype,'  70% TO 74.6 %' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  LEFT JOIN Sch_RegistrationAcademicDetail ON  SR.DocId=Sch_RegistrationAcademicDetail.docid " & mCondStr & "  and isnull(SRE.Rank_No, 0) = 0 And isnull(SRE.Rank_No2, 0) = 0 And SR.AdmissionDocId Is NULL AND Sch_RegistrationAcademicDetail.PCMPercentage>70 AND Sch_RegistrationAcademicDetail.PCMPercentage<74.6 GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT '% Wise Detail (UPSEE/AIEEE Not Qualified)' as Maintype,' 60 % TO 69.6 %' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid LEFT JOIN Sch_RegistrationAcademicDetail ON  SR.DocId=Sch_RegistrationAcademicDetail.docid " & mCondStr & "  and  isnull(SRE.Rank_No, 0) = 0 And isnull(SRE.Rank_No2, 0) = 0 And SR.AdmissionDocId Is NULL AND Sch_RegistrationAcademicDetail.PCMPercentage>60 AND Sch_RegistrationAcademicDetail.PCMPercentage<69.6 GROUP BY Sr.Docid "
            'mqry2 = mqry2 & " UNION ALL SELECT '% Wise Detail (UPSEE/AIEEE Not Qualified)' as Maintype,'50% TO 59.6 %' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN max(isnull(SPS.streammanualcode,''))='' THEN  max(SPS1.streammanualcode) ELSE  max(SPS.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code Left Join " & subq & "  AS v ON SR.DocId=v.docid  LEFT JOIN Sch_RegistrationAcademicDetail ON  SR.DocId=Sch_RegistrationAcademicDetail.docid " & mCondStr & "  and isnull(SRE.Rank_No, 0) = 0 And isnull(SRE.Rank_No2, 0) = 0 And SR.AdmissionDocId Is NULL AND Sch_RegistrationAcademicDetail.PCMPercentage>50 AND Sch_RegistrationAcademicDetail.PCMPercentage<59.6 GROUP BY Sr.Docid "



            mqry2 = "SELECT '  .UPSEE Qualified' as Maintype,'     1-25000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  " & mCondStr & " and SRE.Rank_No > 0 And (ISNULL(SRS.Sr,0))<2 AND SRE.Rank_No < 25001 And SR.AdmissionDocId Is null GROUP BY Sr.Docid,(ISNULL(SRS.Sr,0)) "
            mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,'    25001-50000  ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  " & mCondStr & " and (ISNULL(SRS.Sr,0))<2 AND sRE.Rank_No > 25000 And SRE.Rank_No < 50001 And SR.AdmissionDocId Is null GROUP BY Sr.Docid,(ISNULL(SRS.Sr,0)) "
            mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,'   50001-75000  ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  " & mCondStr & " and (ISNULL(SRS.Sr,0))<2 AND SRE.Rank_No > 50000 And SRE.Rank_No < 75001 And SR.AdmissionDocId Is null GROUP BY Sr.Docid,(ISNULL(SRS.Sr,0)) "
            mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,'  75001-100000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream, 1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code   " & mCondStr & " and (ISNULL(SRS.Sr,0))<2 AND SRE.Rank_No > 75000 And SRE.Rank_No < 100001 And SR.AdmissionDocId Is null GROUP BY Sr.Docid,(ISNULL(SRS.Sr,0)) "
            mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,' 100001-125000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  " & mCondStr & " and (ISNULL(SRS.Sr,0))<2 AND sRE.Rank_No > 100000 And SRE.Rank_No < 125001 And SR.AdmissionDocId Is null GROUP BY Sr.Docid ,(ISNULL(SRS.Sr,0))"
            mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,' 125001-150000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,   1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code   " & mCondStr & " and (ISNULL(SRS.Sr,0))<2 AND sRE.Rank_No > 125001 And SRE.Rank_No < 150000 And SR.AdmissionDocId Is null GROUP BY Sr.Docid,(ISNULL(SRS.Sr,0)) "
            mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,'150001-175000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,   1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  " & mCondStr & " and (ISNULL(SRS.Sr,0))<2 AND SRE.Rank_No > 150001 And SRE.Rank_No < 175000 And SR.AdmissionDocId Is null GROUP BY Sr.Docid ,(ISNULL(SRS.Sr,0))"
            mqry2 = mqry2 & " UNION ALL SELECT '  .UPSEE Qualified' as Maintype,'Above 175000 ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  " & mCondStr & " and (ISNULL(SRS.Sr,0))<2 AND SRE.Rank_No > 175000 and SR.AdmissionDocId Is null GROUP BY Sr.Docid,(ISNULL(SRS.Sr,0)) "
            mqry2 = mqry2 & " UNION ALL SELECT ' .AIEEE Qualified ' as Maintype,' ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream, 1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  " & mCondStr & " and (ISNULL(SRS.Sr,0))<2 AND SRE.Rank_No2 > 0 and SRE.Rank_No = 0 and SR.AdmissionDocId Is null GROUP BY Sr.Docid,(ISNULL(SRS.Sr,0)) "

            mqry2 = mqry2 & " UNION ALL SELECT '% Wise Detail (UPSEE/AIEEE Not Qualified)' as Maintype,'    80% & ABOVE ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code   LEFT JOIN Sch_RegistrationAcademicDetail ON  SR.DocId=Sch_RegistrationAcademicDetail.docid " & mCondStr & "  and (ISNULL(SRS.Sr,0))<2 AND isnull(SRE.Rank_No, 0) = 0 And isnull(SRE.Rank_No2, 0) = 0 And SR.AdmissionDocId Is NULL AND Sch_RegistrationAcademicDetail.PCMPercentage>80  GROUP BY Sr.Docid,(ISNULL(SRS.Sr,0)) "
            mqry2 = mqry2 & " UNION ALL SELECT '% Wise Detail (UPSEE/AIEEE Not Qualified)' as Maintype,'   75% TO 79.6 % ' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram,(CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  LEFT JOIN Sch_RegistrationAcademicDetail ON  SR.DocId=Sch_RegistrationAcademicDetail.docid " & mCondStr & "   and (ISNULL(SRS.Sr,0))<2 AND isnull(SRE.Rank_No, 0) = 0 And isnull(SRE.Rank_No2, 0) = 0 And SR.AdmissionDocId Is NULL AND Sch_RegistrationAcademicDetail.PCMPercentage>75 AND Sch_RegistrationAcademicDetail.PCMPercentage<=79.6 GROUP BY Sr.Docid ,(ISNULL(SRS.Sr,0)) "
            mqry2 = mqry2 & " UNION ALL SELECT '% Wise Detail (UPSEE/AIEEE Not Qualified)' as Maintype,'  70% TO 74.6 %' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code   LEFT JOIN Sch_RegistrationAcademicDetail ON  SR.DocId=Sch_RegistrationAcademicDetail.docid " & mCondStr & "  and (ISNULL(SRS.Sr,0))<2 AND isnull(SRE.Rank_No, 0) = 0 And isnull(SRE.Rank_No2, 0) = 0 And SR.AdmissionDocId Is NULL AND Sch_RegistrationAcademicDetail.PCMPercentage>70 AND Sch_RegistrationAcademicDetail.PCMPercentage<74.6 GROUP BY Sr.Docid ,(ISNULL(SRS.Sr,0)) "
            mqry2 = mqry2 & " UNION ALL SELECT '% Wise Detail (UPSEE/AIEEE Not Qualified)' as Maintype,' 60 % TO 69.6 %' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram,(CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  LEFT JOIN Sch_RegistrationAcademicDetail ON  SR.DocId=Sch_RegistrationAcademicDetail.docid " & mCondStr & "  and  (ISNULL(SRS.Sr,0))<2 AND isnull(SRE.Rank_No, 0) = 0 And isnull(SRE.Rank_No2, 0) = 0 And SR.AdmissionDocId Is NULL AND Sch_RegistrationAcademicDetail.PCMPercentage>60 AND Sch_RegistrationAcademicDetail.PCMPercentage<69.6 GROUP BY Sr.Docid ,(ISNULL(SRS.Sr,0)) "
            mqry2 = mqry2 & " UNION ALL SELECT '% Wise Detail (UPSEE/AIEEE Not Qualified)' as Maintype,'50% TO 59.6 %' AS vtype,Sr.Docid,max(sp.ManualCode) AS prgram, (CASE WHEN (ISNULL(SRS.Sr,0))=0 THEN  max(SPS.streammanualcode) ELSE  max(SPS1.streammanualcode) END) AS stream,  1 AS Noof_student,1 AS ondate  FROM viewSch_Registration SR LEFT JOIN Sch_Registration SRE ON SR.DocId=SRE.DOCID LEFT JOIN ViewSch_SessionProgrammeStream sps ON  SR.SessionProgrammeStream=sps.Code   LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code  LEFT JOIN Sch_Programme sp ON SR.ProgrammeCode=sp.Code  LEFT JOIN Sch_RegistrationAcademicDetail ON  SR.DocId=Sch_RegistrationAcademicDetail.docid " & mCondStr & "  and (ISNULL(SRS.Sr,0))<2 AND isnull(SRE.Rank_No, 0) = 0 And isnull(SRE.Rank_No2, 0) = 0 And SR.AdmissionDocId Is NULL AND Sch_RegistrationAcademicDetail.PCMPercentage>50 AND Sch_RegistrationAcademicDetail.PCMPercentage<59.6 GROUP BY Sr.Docid ,(ISNULL(SRS.Sr,0)) "






            DsRep = AgL.FillData(mQry, AgL.GCn)
            DsRep1 = AgL.FillData(mqry1, AgL.GCn)
            DsRep2 = AgL.FillData(mqry2, AgL.GCn)


            RepName = "Academic_main_RegistrationDetail" : RepTitle = "Registration Detail "

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.SubReport1DataSet = DsRep1
            ObjRFG.SubReport2DataSet = DsRep2

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
            'ObjRFG.PrintReport(DsRep2, "Academic_main_RegistrationDetail2", RepTitle, PLib.PubReportPath_Academic_Main)


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

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""
            Dim mqry1$ = ""
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub


            mCondStr = " where Sr.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("SR.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("SR.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("SR.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("srd.citycode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("srd.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("SR.V_Type", 3)


            mQry = "SELECT Sr.Docid," & AgL.V_No_Field("Sr.DocId") & " As VoucherNo ,SR.V_Type,SR.V_No,SR.totalamount,SR.totaldiscount,SR.totalnetAmount ," & _
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



            mqry1 = "SELECT DISTINCT Sr.Docid,pd.CashAmount,pd.BankAmount AS BankAmount1,pd.Chq_No AS chq1,pd.Chq_Date AS Chqdate1,b1.Bank_Name AS Bank1,pd.BankAmount2 AS BankAmount2,pd.Chq_No2 AS chq2,pd.Chq_Date2 AS Chqdate2,b2.Bank_Name AS Bank2, " & _
                   " pd.BankAmount3 AS BankAmount3,pd.Chq_No3 AS chq3,pd.Chq_Date3 AS Chqdate3,b3.Bank_Name AS Bank3 " & _
                   " " & _
                   " FROM Sch_Registration SR  " & _
                   " LEFT JOIN Sch_RegistrationStudentDetail srd ON SR.DocId=srd.DocId " & _
                   " LEFT JOIN ( " & _
                   " SELECT Rad.DocId , Max(Rad.PCMPercentage) AS MeritPercentage, Max(Rad.Remark) MeritRemark " & _
                   " FROM Sch_RegistrationAcademicDetail Rad WHERE IsNull(Rad.PCMPercentage,0) > 0 GROUP BY Rad.DocId) vRad ON vRad.DocId = Sr.DocId " & _
                   " LEFT JOIN Sch_AdmissionNature San ON SR.AdmissionNature=san.Code  " & _
                   " LEFT JOIN ViewSch_SessionProgrammeStream sps ON SR.SessionProgrammeStream=sps.Code " & _
                   " left join city on srd.citycode=city.citycode  " & _
                   " LEFT JOIN Sch_Category ON SRD.Category=Sch_Category.Code  " & _
                   " LEFT JOIN PaymentDetail pd ON sr.DocId=pd.DocId  " & _
                   " LEFT JOIN Bank b1 ON pd.Bank_Code=b1.Bank_Code " & _
                   " LEFT JOIN Bank b2 ON pd.Bank_Code2=b2.Bank_Code " & _
                   " LEFT JOIN Bank b3 ON pd.Bank_Code3=b3.Bank_Code " & _
                   " LEFT JOIN Sch_RegistrationStream SRS ON sr.DocId=srs.DocId " & _
                   " LEFT JOIN ViewSch_SessionProgrammeStream sps1 ON SRs.SessionProgrammeStream=sps1.Code " & mCondStr & "  "





            DsRep = AgL.FillData(mQry, AgL.GCn)
            DsRep1 = AgL.FillData(mQry1, AgL.GCn)


            RepName = "Academic_main_RegistrationRegister" : RepTitle = "Registration Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.SubReport1DataSet = DsRep1
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)


        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Student Register"
    Private Sub ProcStudentRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = " where 1=1 "
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            If ObjRFG.GetWhereCondition("S.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Site_Code", 0)
            End If


            mCondStr = mCondStr & ObjRFG.GetWhereCondition("s.citycode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("f.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.GroupCode", 3)


            mQry = "Select F.SubCode, S.ManualCode As [Manual Code],  S.Name As [Name],F.FirstName as [First Name],f.MiddleName as [Middle Name], " & _
                     " F.Lastname as [Last Name],F.Sex as [Male/Female],s.Fathername as [Father Name],F.MotherName as [Mother Name]," & _
                     " S.Add1 as [Address1],s.add2 as Address2,S.pin,city.cityname as [CityName],S.Mobile,S.Phone,S.Dob,S.Email,f.BloodGroup,Sch_Category.Description as Category, " & _
                     " '" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForCity,'" & ObjRFG.GetHelpString(2) & "' As ForCatgory,SubGroup_Image.photo " & _
                     " From  Sch_Student F " & _
                     " Left join SubGroup S On F.SubCode = S.SubCode " & _
                     " left join city on s.citycode=city.citycode " & _
                     " LEFT JOIN Sch_Category ON f.Category=Sch_Category.Code " & _
                     " left JOIN  SubGroup_Image ON s.subcode=SubGroup_Image.subcode  " & _
                       " " & mCondStr & " "
            DsRep = AgL.FillData(mQry, AgL.GCn)
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "With Picture") Then
                RepName = "Academic_main_StudentRegister_Picture" : RepTitle = "Student Register"
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "With Out Picture") Then
                RepName = "Academic_main_StudentRegister" : RepTitle = "Student Register"
            End If
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Tutorial Sheet Register"  '************************ code by Rati on 14/06/2012
    Private Sub ProcTutorialSheetRegister()
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
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SessionProgramme", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.StreamYearSemester", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Subject", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Teacher", 4)


            If mGRepFormName = TutorialSheetRegister Then
                mCondStr = mCondStr & "and VT.NCat in('" & ClsMain.Temp_NCat.TutorialSheet & "')"
            ElseIf mGRepFormName = AssignmentSheetRegister Then
                mCondStr = mCondStr & "and VT.NCat in('" & ClsMain.Temp_NCat.AssignmentSheet & "')"
            End If


            mQry = " SELECT H.DocId,H.V_Type,H.V_No,H.V_Date,H.ReferenceNo,H.SubjectManualCode,H.Unit,H.Topic, " & _
                    " H.CompletionDate,H.TotalQuestion,H.TotalReference,H.Remark,H.TotalDocuments, " & _
                    " L.Question,SP.SessionProgramme AS SessionProgramme,SEM.StreamYearSemesterDesc AS Semester, " & _
                    " SM.Name AS SiteName,S.Description AS Subject,SG.Name AS Teacher,  " & _
                    " '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType " & _
                    " FROM dbo.Sch_TutorialAssignment H WITH (NoLock) " & _
                    " LEFT JOIN dbo.Sch_TutorialAssignment1 L WITH (NoLock) ON L.DocId=H.DocId " & _
                    " LEFT JOIN ViewSch_SessionProgramme SP  WITH (NoLock) ON SP.Code = H.SessionProgramme  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester SEM WITH (NoLock) ON SEM.Code = H.StreamYearSemester  " & _
                    " LEFT JOIN SiteMast SM WITH (NoLock)ON SM.Code=H.Site_Code " & _
                    " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = H.Subject " & _
                    " LEFT JOIN SubGroup SG WITH (NoLock) ON SG.SubCode = H.Teacher " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=H.V_Type  "



            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If mGRepFormName = TutorialSheetRegister Then
                RepName = "Academic_TutorialSheetRegister" : RepTitle = "Tutorial Sheet Register"
            ElseIf mGRepFormName = AssignmentSheetRegister Then
                RepName = "Academic_AssignmentSheetRegister" : RepTitle = "Assignment Sheet Register"
            End If


            ObjRFG.SubReport1DataSet = DsRep1
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region  '************************End code by Rati on 14/06/2012

#Region "Academic Progress Theory Register"  '************************ code by Rati on 15/06/2012
    Private Sub ProcAcademicProgressTheoryRegister()
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
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SessionProgramme", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.StreamYearSemester", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Subject", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Teacher", 4)


            If mGRepFormName = AcademicProgressTheoryRegister Then
                mCondStr = mCondStr & "and VT.NCat in('" & ClsMain.Temp_NCat.AcademicProgressTheory & "')"
            ElseIf mGRepFormName = AcademicProgressLaboratoryRegister Then
                mCondStr = mCondStr & "and VT.NCat in('" & ClsMain.Temp_NCat.AcademicProgressLaboratory & "')"
            End If


            mQry = " SELECT H.DocId,H.V_Type,H.V_No,H.V_Date,H.ReferenceNo,H.SubjectManualCode,H.FromDate,H.ToDate,H.Remark, " & _
                    " L.SeniorObservation,L.Year,L.SubjectManualCode,L.Qty,L.CumulativeQty,L.CoveredPer_Course_Lab, " & _
                    " L.CoveredUnit,L.Checked_Assignment_Practical,L.Checked_Tutorial_Quiz,L.Remark, " & _
                    " SP.SessionProgramme AS SessionProgramme,SEM.StreamYearSemesterDesc AS Semester,  " & _
                    " SM.Name AS SiteName,S.Description AS Subject,SG.Name AS Teacher,SEM1.StreamYearSemesterDesc AS SemesterLine, " & _
                    " S1.Description AS SubjectLine,SG1.Name AS HOD, " & _
                    " '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType " & _
                    " FROM dbo.Sch_AcademicProgress H WITH (NoLock) " & _
                    " LEFT JOIN Sch_AcademicProgress1 L WITH (NOLock) ON L.DocId = H.DocId " & _
                    " LEFT JOIN ViewSch_SessionProgramme SP  WITH (NoLock) ON SP.Code = H.SessionProgramme  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester SEM WITH (NoLock) ON SEM.Code = H.StreamYearSemester  " & _
                    " LEFT JOIN SiteMast SM WITH (NoLock)ON SM.Code=H.Site_Code " & _
                    " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = H.Subject " & _
                    " LEFT JOIN SubGroup SG WITH (NoLock) ON SG.SubCode = L.Teacher " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=H.V_Type   " & _
                    " LEFT JOIN ViewSch_StreamYearSemester SEM1 WITH (NoLock) ON SEM1.Code = L.StreamYearSemester " & _
                    " LEFT JOIN Sch_Subject S1 WITH (NoLock) ON S1.Code = L.Subject " & _
                    " LEFT JOIN SubGroup SG1 WITH (NoLock) ON SG1.SubCode = L.HOD "


            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If mGRepFormName = AcademicProgressTheoryRegister Then
                RepName = "Academic_AcademicProgressTheoryRegister" : RepTitle = "Academic Progress Theory Register"
            ElseIf mGRepFormName = AcademicProgressLaboratoryRegister Then
                RepName = "Academic_AcademicProgressLaboratoryRegister" : RepTitle = "Academic Progress Laboratory Register"
            End If


            ObjRFG.SubReport1DataSet = DsRep1
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region  '************************End code by Rati on 15/06/2012

#Region "Lecture Plan Register"  '************************ code by Rati on 15/06/2012
    Private Sub ProcLecturePlanRegister()
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
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SessionProgramme", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.StreamYearSemester", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Subject", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Teacher", 4)


            mQry = " SELECT H.DocId,H.V_Type,H.V_No,H.V_Date,H.ReferenceNo,H.SubjectManualCode,H.EvaluationScheme,H.LecturePerWeek,H.Remark, " & _
                    " L.LectureNo,L.UnitCovered,L.TopicCovered,L.DeliveryDate,L.PresentStudent,L.Remark,L.SeniorObservation, " & _
                    " SP.SessionProgramme AS SessionProgramme,SEM.StreamYearSemesterDesc AS Semester,  " & _
                    " SM.Name AS SiteName,S.Description AS Subject,SG.Name AS Teacher, " & _
                    " '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType " & _
                    " FROM dbo.Sch_LecturePlan H WITH (NoLock) " & _
                    " LEFT JOIN Sch_LecturePlan1 L WITH (NoLock) ON L.DocId = H.DocId " & _
                    " LEFT JOIN ViewSch_SessionProgramme SP  WITH (NoLock) ON SP.Code = H.SessionProgramme  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester SEM WITH (NoLock) ON SEM.Code = H.StreamYearSemester  " & _
                    " LEFT JOIN SiteMast SM WITH (NoLock)ON SM.Code=H.Site_Code " & _
                    " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = H.Subject " & _
                    " LEFT JOIN SubGroup SG WITH (NoLock) ON SG.SubCode = H.Teacher " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=H.V_Type   "
                  

            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Academic_LecturePlanRegister" : RepTitle = "Lecture Plan Register"

            ObjRFG.SubReport1DataSet = DsRep1
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region  '************************End code by Rati on 15/06/2012

#Region "Lab Status Register"  '************************ code by Rati on 15/06/2012
    Private Sub ProcLabStatusRegister()
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
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SessionProgramme", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.StreamYearSemester", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Subject", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("L.Teacher", 4)


            mQry = " SELECT H.DocId,H.V_Type,H.V_No,H.V_Date,H.ReferenceNo,H.SubjectManualCode,H.Remark,L.ExperimentDate,L.ExperimentName, " & _
                    " L.SubjectManualCode,L.StatusOfManuals,L.StatusOfExperimentalSetup,L.Remark,L.SeniorObservation,  " & _
                    " SP.SessionProgramme AS SessionProgramme,SEM.StreamYearSemesterDesc AS Semester, " & _
                    " SM.Name AS SiteName,S.Description AS Subject,SG.Name AS Teacher, " & _
                    " SP1.SessionProgramme AS SessionProgrammeLine,SEM1.StreamYearSemesterDesc AS SemesterLine,S1.Description AS SubjectLine, " & _
                    " '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType " & _
                    " FROM dbo.Sch_LabStatus H WITH (NoLock) " & _
                    " LEFT JOIN Sch_LabStatus1 L WITH (NoLock) ON L.DocId=H.DocId " & _
                    " LEFT JOIN ViewSch_SessionProgramme SP  WITH (NoLock) ON SP.Code = H.SessionProgramme  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester SEM WITH (NoLock) ON SEM.Code = H.StreamYearSemester " & _
                    " LEFT JOIN SiteMast SM WITH (NoLock)ON SM.Code=H.Site_Code " & _
                    " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = H.Subject " & _
                    " LEFT JOIN SubGroup SG WITH (NoLock) ON SG.SubCode = L.Teacher " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=H.V_Type   " & _
                    " LEFT JOIN ViewSch_SessionProgramme SP1  WITH (NoLock) ON SP1.Code = L.SessionProgramme " & _
                    " LEFT JOIN ViewSch_StreamYearSemester SEM1 WITH (NoLock) ON SEM1.Code = L.StreamYearSemester " & _
                    " LEFT JOIN Sch_Subject S1 WITH (NoLock) ON S1.Code = L.Subject "


            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Academic_LabStatusRegister" : RepTitle = "Lab Status Register"

            ObjRFG.SubReport1DataSet = DsRep1
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region  '************************End code by Rati on 15/06/2012

#Region "Lab Work Register"  '************************ code by Rati on 15/06/2012
    Private Sub ProcLabWorkRegister()
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
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SessionProgramme", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.StreamYearSemester", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Subject", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Teacher", 4)


            mQry = " SELECT H.DocId,H.V_Type,H.V_No,H.V_Date,H.ReferenceNo,H.SubjectManualCode,H.Remark, " & _
                    " L.Experiment,L.PerformedDate,L.SubmissionDate,L.StreamYearSemester, " & _
                    " SP.SessionProgramme AS SessionProgramme,SEM.StreamYearSemesterDesc AS Semester, " & _
                    " SM.Name AS SiteName,S.Description AS Subject,SG.Name AS Teacher,SEM1.StreamYearSemesterDesc AS SemesterLine, " & _
                    " SG1.Name AS Student,Ad.AdmissionID,SG2.Name AS HOD,CS.ClassSectionDesc,SS.SubSection,R.RollNo, " & _
                    " '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType " & _
                    " FROM dbo.Sch_LabWork H WITH (NoLock) " & _
                    " LEFT JOIN Sch_LabWork1 L WITH (NoLock) ON L.DocId=H.DocId " & _
                    " LEFT JOIN ViewSch_SessionProgramme SP  WITH (NoLock) ON SP.Code = H.SessionProgramme  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester SEM WITH (NoLock) ON SEM.Code = H.StreamYearSemester " & _
                    " LEFT JOIN SiteMast SM WITH (NoLock)ON SM.Code=H.Site_Code " & _
                    " LEFT JOIN Sch_Subject S WITH (NoLock) ON S.Code = H.Subject " & _
                    " LEFT JOIN SubGroup SG WITH (NoLock) ON SG.SubCode = H.Teacher " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=H.V_Type   " & _
                    " LEFT JOIN ViewSch_StreamYearSemester SEM1 WITH (NoLock) ON SEM1.Code = L.StreamYearSemester " & _
                    " LEFT JOIN SubGroup SG1 WITH (NoLock) ON SG1.SubCode = L.Student " & _
                    " LEFT JOIN Sch_Admission Ad WITH (NoLock) ON AD.DocID = L.AdmissionDocId " & _
                    " LEFT JOIN SubGroup SG2 WITH (NoLock) ON SG2.SubCode = H.HOD " & _
                    " LEFT JOIN ViewSch_ClassSection CS WITH (NoLock) ON CS.Code = H.ClassSection " & _
                    " LEFT JOIN ViewSch_ClassSectionSubSection SS WITH (NoLock) ON SS.Code = H.ClassSectionSubSection " & _
                    " LEFT JOIN Sch_AdmissionRollNo R  WITH (NoLock) ON R.DocId = Ad.DocId "


            mQry = mQry & " Where 1=1  " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Academic_LabWorkRegister" : RepTitle = "Lab Work Register"

            ObjRFG.SubReport1DataSet = DsRep1
            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region  '************************End code by Rati on 15/06/2012


    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub

    Private Function FunGetFeeDueStr(ByVal bFromDateStr As String, ByVal bToDateStr As String) As String
        Dim bViewStr$ = ""
        Try
            bViewStr = "SELECT " & _
                        " CASE WHEN FD.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Fd.DueAmount ELSE 0 END AS OpeningDueAmount, " & _
                        " CASE WHEN FD.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Fd.DueAmount END AS CurrentDueAmount, " & _
                        " IsNull(vFr1.OpeningNetReceiveAmount,0) As OpeningNetReceiveAmount, " & _
                        " IsNull(vFr1.CurrentNetReceiveAmount,0) As CurrentNetReceiveAmount, " & _
                        " IsNull(vFr1.OpeningReceiveAmount,0) As OpeningReceiveAmount, " & _
                        " IsNull(vFr1.CurrentReceiveAmount,0) As CurrentReceiveAmount, " & _
                        " IsNull(vFr1.OpeningDiscount,0) As OpeningDiscount,   IsNull(vFr1.CurrentDiscount,0) As CurrentDiscount, " & _
                        " CASE WHEN FD.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Fd.DueAmount - IsNull(vFr1.OpeningReceiveAmount,0) + IsNull(vFr1.OpeningNetRefundAmount,0) ELSE 0 END AS OpeningNetBalance, " & _
                        " CASE WHEN FD.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Fd.DueAmount - IsNull(vFr1.CurrentReceiveAmount,0) + IsNull(vFr1.CurrentNetRefundAmount,0) END AS CurrentNetBalance, " & _
                        " IsNull(vFr1.TillDate_ReceiveAmount,0) As TillDate_ReceiveAmount, " & _
                        " IsNull(vFr1.TillDate_NetReceiveAmount,0) As TillDate_NetReceiveAmount, " & _
                        " IsNull(vFr1.TillDate_Discount,0) As TillDate_Discount, " & _
                        " Fd.DueAmount As TillDate_TotalDueAmount, Fd.DueAmount - IsNull(vFr1.TillDate_ReceiveAmount,0) + IsNull(vFr1.TillDate_NetRefundAmount,0) As TillDate_NetBalance, " & _
                        " IsNull(vFr1.TillDate_NetRefundAmount,0) AS TillDate_NetRefundAmount, " & _
                        " IsNull(vFr1.OpeningNetRefundAmount,0) AS OpeningNetRefundAmount, " & _
                        " IsNull(vFr1.CurrentNetRefundAmount,0) AS CurrentNetRefundAmount, " & _
                        " Fd.* " & _
                        " FROM ViewSch_FeeDue Fd " & _
                        " Left Join ( " & _
                        " Select Sum(Fr1.Amount) As TillDate_ReceiveAmount , Sum(Fr1.NetAmount) As TillDate_NetReceiveAmount, " & _
                        " Sum(Fr1.Discount) As TillDate_Discount,  Fr1.FeeDue1, " & _
                        " Sum(CASE WHEN Fr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Fr1.Amount ELSE 0 END) AS OpeningReceiveAmount, " & _
                        " Sum(CASE WHEN Fr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Fr1.Amount END) AS CurrentReceiveAmount, " & _
                        " Sum(CASE WHEN Fr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Fr1.NetAmount ELSE 0 END) AS OpeningNetReceiveAmount, " & _
                        " Sum(CASE WHEN Fr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Fr1.NetAmount END) AS CurrentNetReceiveAmount, " & _
                        " Sum(CASE WHEN Fr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Fr1.Discount ELSE 0 END) AS OpeningDiscount, " & _
                        " Sum(CASE WHEN Fr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Fr1.Discount END) AS CurrentDiscount, " & _
                        " IsNull(Sum(vFRef.TillDate_NetRefundAmount),0) AS TillDate_NetRefundAmount, " & _
                        " IsNull(Sum(vFRef.OpeningNetRefundAmount),0) AS OpeningNetRefundAmount, " & _
                        " IsNull(Sum(vFRef.CurrentNetRefundAmount),0) AS CurrentNetRefundAmount " & _
                        " From ViewSch_FeeReceive1 Fr1 " & _
                        " LEFT JOIN " & _
                        " (SELECT FRef1.FeeReceive1, Sum(FRef1.NetAmount) AS TillDate_NetRefundAmount, " & _
                        " Sum(CASE WHEN Fref.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Fref1.NetAmount ELSE 0 END) AS OpeningNetRefundAmount, " & _
                        " Sum(CASE WHEN Fref.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Fref1.NetAmount END) AS CurrentNetRefundAmount " & _
                        " FROM Sch_FeeRefund FRef " & _
                        " LEFT JOIN Sch_FeeRefund1 FRef1 ON Fref.DocId = FRef1.DocId " & _
                        " WHERE FRef.V_Date  <= " & AgL.ConvertDate(bToDateStr) & " " & _
                        " GROUP BY FRef1.FeeReceive1 ) vFRef ON Fr1.Code = vFRef.FeeReceive1 " & _
                        " Where Fr1.V_Date <= " & AgL.ConvertDate(bToDateStr) & " " & _
                        " Group By Fr1.FeeDue1 " & _
                        " ) vFr1 On Fd.FeeDue1Code = vFr1.FeeDue1 "

        Catch ex As Exception
            bViewStr = ""
            MsgBox(ex.Message)
        Finally
            FunGetFeeDueStr = bViewStr
        End Try
    End Function

End Class
