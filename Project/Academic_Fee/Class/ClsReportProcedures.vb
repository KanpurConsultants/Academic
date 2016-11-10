
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
    Private Const FeeReceiveRegister As String = "FeeReceiveRegister"
    '============================================================================================================
    '======================<Fee Collection Summary Fee Head Wise>================================================
    '==============================< Is Not in Use Now >=========================================================
    Private Const FeeCollectionSummaryFeeHeadWise As String = "FeeCollectionSummaryFeeHeadWise"
    Private Const OutStandingReportFeeHeadWise As String = "OutStandingReportFeeHeadWise"
    '============================================================================================================
    Private Const StudentLeftRegister As String = "StudentLeftRegister" '********** Code by Satyam on 20/09/2010
    Private Const AdmissionRegister As String = "AdmissionRegister" '********** Code by Satyam on 22/09/2010
    Private Const FeeRefundRegister As String = "FeeRefundRegister" ' Code by Satyam on 24/09/2010
    Private Const AdvanceReceiveRegister As String = "AdvanceReceiveRegister" 'end Code by Satyam on 24/09/2010
    Private Const TeacherRegister As String = "TeacherRegister" ' Code by Satyam on 15/10/2010




    'Code By Akash On Date 23-3-11
    Private Const FeeReport As String = "FeeReport"
    Private Const FeeReportSummary As String = "FeeReportSummary"
    'End Code

    Private Const InstallmentReport As String = "InstallmentReport"


#End Region

#Region "Queries Definition"
    Dim mHelpCustomerQry$ = "Select Convert(BIT,0) As [Select], SubCode As Code, Name As [Customer Name] From SubGroup Where Nature In ('Customer') And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
    Dim mHelpCityQry$ = "Select Convert(BIT,0) As [Select],CityCode, CityName From City "
    Dim mHelpStateQry$ = "Select Convert(BIT,0) As [Select],State_Code, State_Desc From State "
    Dim mHelpUserQry$ = "Select Convert(BIT,0) As [Select],User_Name As Code, User_Name As [User], Description From UserMast "
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
    'Code By Satyam on 16/03/2011
    Dim mHelpBankACQry$ = " SELECT Distinct Convert(BIT,0) As [Select],	SG.SubCode AS Code,SG.Name AS [Bank A/c],SG.ManualCode FROM dbo.SubGroup SG	" & _
                            " WHERE SG.Nature ='Bank' AND " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "SG.Site_Code", AgL.PubSiteCode, "SG.CommonAc") & ""
    'Code By Satyam on 16/03/2011

    'Code By Akash On Date 22-3-2011
    Dim mHelpOtherFeeReceiveVTypeQry$ = "SELECT Distinct Convert(BIT,0) As [Select], V_Type AS Code, Description AS Name FROM Voucher_Type Where NCat In (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ReceiveEntry) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceive) & ",  " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceiveAdjustment) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) & ") "
    'End Code

    Dim mHelpDueInstallmentEntryNoQry$ = "Select Convert(BIT,0) As [Select],  Convert(VARCHAR(36),H.UID) As Code, " & FunGetEntryNoDisplayField("H") & " As [Installment Entry No], " & AgL.ConvertDateField("H.EntryDate") & "  As [Entry Date] FROM Sch_DueInstallment H Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " And H.EntryDate <= " & AgL.ConvertDate(AgL.PubEndDate) & "   "


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
                    Call ObjRFG.Ini_Grp(, , , , "Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCityQry$, "City Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")

                Case RegistrationRegister
                    StrArr1 = New String() {"Yes", "No"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "With Detail Fees", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCityQry$, "City Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")

                Case CategoryWiseCourseWiseOutstanding, StudentOutstandingReport, StudentOutstandingReportCategoryWise
                    StrArr1 = New String() {"No", "Yes"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Show Zero Balance", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")

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

                Case StudentOutstandingReportFeeHeadWise, OutStandingReportFeeHeadWise
                    StrArr1 = New String() {"No", "Yes"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Show Zero Balance", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")
                    ObjRFG.CreateHelpGrid(mHelpFeeHeadQry, "Fee Head")

                Case AdditionalFeeFineReceiptReport, FeeReceiptHeadWiseReport, _
                    FeeReceiveReportSessionwise, FeeHeadDetailReportYearWise, FeeDetailReportCourseYearwise

                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")
                    If GRepFormName = AdditionalFeeFineReceiptReport Then ObjRFG.CreateHelpGrid(mHelpOtherFeeReceiveVTypeQry, "Voucher Type")

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
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")

                Case FeeReceiveRegister
                    StrArr1 = New String() {"Yes", "No"}
                    Call ObjRFG.Ini_Grp("Date From", AgL.PubStartDate, "Date To", AgL.PubLoginDate, "Fee Detail", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Current Semester")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Current Stream")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Current Programme")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Current Session")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")


                Case StudentCard, IdentityCard
                    Call ObjRFG.Ini_Grp()

                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpStudentQry$, "Student Name")

                Case StudentInformationCategorywiseReport
                    Call ObjRFG.Ini_Grp()

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
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionProgrammeStreamQry$, "Session Programme Stream")
                    ObjRFG.CreateHelpGrid(mHelpStudentLeavQry, "Student Name")

                Case CharacterCertificate
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
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
                    StrArr1 = New String() {"No", "Yes"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "With Registration", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionProgrammeStreamQry$, "Session Programme Stream")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry, "Stream")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry, "Student Categary")
                    ObjRFG.CreateHelpGrid(mHelpBankQry, "Bank")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")
                    ObjRFG.CreateHelpGrid(mHelpUserQry, "Prepared By")


                Case AttendanceAndLectureDelivery, TeacherWiseStudentAbsentReport
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpClassSectionQry$, "Class Section")
                    ObjRFG.CreateHelpGrid(mHelpTimeSlotQry$, "Time Slot")
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry$, "Subject")
                    ObjRFG.CreateHelpGrid(mHelpTeacherQry$, "Teacher Name")

                Case CourseWiseVacancyReport
                    Call ObjRFG.Ini_Grp()
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session")
                    ObjRFG.CreateHelpGrid(mHelpProgrammeQry$, "Programme")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry, "Stream")

                Case AttendanceBelowAGivenPecentage, AttendanceBetweenAGivenRange
                    If GRepFormName = AttendanceBelowAGivenPecentage Then
                        Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Attendance < %", )

                    ElseIf GRepFormName = AttendanceBetweenAGivenRange Then
                        Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Attendance >= %", , , "Attendance <= %", )
                    End If

                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpClassSectionQry$, "Class Section")
                    ObjRFG.CreateHelpGrid(mHelpTimeSlotQry$, "Time Slot")
                    ObjRFG.CreateHelpGrid(mHelpSubjectQry$, "Subject")
                    ObjRFG.CreateHelpGrid(mHelpTeacherQry$, "Teacher Name")
                    ObjRFG.CreateHelpGrid(mHelpOcQry, "OC Name")


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
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Session Name")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Programme Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Stream Name")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Semester Name")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionNatureQry$, "Admission Nature")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")
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

                    'Code By Akash On date 23-3-11
                Case FeeReport, FeeReportSummary
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Current Stream")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Current Session")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Current Programme")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Current Semester")

                Case InstallmentReport
                    StrArr1 = New String() {"Yes", "No", "All"}
                    StrArr2 = New String() {"Yes", "No", "All"}

                    Call ObjRFG.Ini_Grp("From Entry Date", AgL.PubStartDate, "To Entry Date", AgL.PubLoginDate, "Active Entry", StrArr1, , "Active Installment", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpAdmissionIdQry, "Admission ID")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category Name")
                    ObjRFG.CreateHelpGrid(mHelpBranchQry$, "Current Stream")
                    ObjRFG.CreateHelpGrid(mHelpSessionQry$, "Current Session")
                    ObjRFG.CreateHelpGrid(mHelpCourseQry$, "Current Programme")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry$, "Current Semester")
                    ObjRFG.CreateHelpGrid(mHelpDueInstallmentEntryNoQry, "Installment Entry No")
            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName

            Case StudentRegister
                ProcStudentRegister()

            Case RegistrationRegister
                ProcRegistrationRegister()

            Case CategoryWiseCourseWiseOutstanding, StudentOutstandingReport, StudentOutstandingReportCategoryWise
                ProcCategorywiseCoursewiseOutstanding()

            Case StudentOutstandingReportFeeHeadWise, OutStandingReportFeeHeadWise
                ProcStudentOutstandingReportFeeHeadWise()

            Case FeeCollectionSummaryStudentWise, FeeCollectionSummaryFeeHeadWise
                ProcFeeCollectionSummary()

            Case AdditionalFeeFineReceiptReport, FeeReceiptHeadWiseReport, FeeReceiveReportSessionwise
                ProcAdditionalFeeFineReceiptReport()

            Case FeeCollectionReport
                ProcFeeCollectionReport()

            Case FeeReceiveRegister
                ProcFeeReceiveRegister()

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


            Case FeeReport
                Call ProcFeeReport()

            Case FeeReportSummary
                Call ProcFeeReportSummary()

            Case InstallmentReport
                Call ProcInstallmentReport()

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

#Region "Student Left Register" ' ****************** Code by Satyam on 20/09/2010 
    Private Sub ProcStudentLeftRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "
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

#Region "Admission Register"    '******************* code by satyam on 22/09/2010
    Private Sub ProcAdmissionRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where A.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("A.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.SessionCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.SessionProgrammeCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sps.Code", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.FromStreamYearSemester", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("s.Category", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.AdmissionNature", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.DocId", 7)

            mQry = " SELECT A.V_Date,A.AdmissionID,A.Student AS [StudentID],A.RollNo,A.EnrollmentNo, " & _
                    " sg.Name,sg.DispName,s.MotherName,sg.FatherName,sg.Add1,sg.Add2,sg.Add3," & _
                    " sg.Phone,sg.Mobile,sg.EMail,c.CityName,s.Sex,sc.ManualCode AS Category, " & _
                    " Sem.StreamYearSemesterDesc, SemTo.StreamYearSemesterDesc As PromotionSemester " & _
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
#End Region  ' ****************** End Code by Satyam on 22/09/2010 

#Region "Fee Refund Register" ' Code By Satyam on 25/09/2010
    Private Sub ProcFeeRefundRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "
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
                    " FR.TotalLineNetAmount,FR.Remark,FR.Refundamount as RefundAmount, Fr.ExcessRefund, FR.TotalFeeRefund, " & _
                    " Fr.AdmissionDocId, Adm.AdmissionID, Stu.name As Student_Name, FR1.Amount AS Line_Amount, " & _
                    " Fr1.ReturnHeadType, " & AgL.V_No_Field("FR1.FeeReceiveDocId") & " As FeeRecv_VoucherNo, " & _
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

            Dim mCondStr$ = "  "
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

            Dim mCondStr$ = "  "

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
            If GRepFormName = TeacherWiseStudentAbsentReport Then
                mCondStr = mCondStr & " and saa1.IsPresent=0 "
            End If

            mQry = " SELECT saa.a_date ,sts.description AS TimeSlot,vsc.ClassSectionDesc,scr.Description AS Classroom," & _
                   " ss.Description AS subject,SubGroup.Name AS teacher,vsa.AdmissionID,vsa.StudentName,vsa.StudentDispName,CASE WHEN saa1.IsPresent=1 THEN 'Present' ELSE 'Absent' END AS [Absent/Prasent],vsa.RollNo,sts.StartTime,sts.EndTime  " & _
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
            Dim mCondStr$ = "", bPresentPercentageStr$ = "", bHavingStr$ = "", bView1Str$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

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


            bPresentPercentageStr = " (Sum(CASE WHEN IsNull(A.IsPresent,0)<>0 THEN 1 ELSE 0 END) * 100) / Count(A.IsPresent) "

            If GRepFormName = AttendanceBelowAGivenPecentage Then
                bHavingStr = " Having " & bPresentPercentageStr & " < " & Val(ObjRFG.ParameterCmbo1_Value) & " "
            ElseIf GRepFormName = AttendanceBetweenAGivenRange Then
                bHavingStr = " Having " & bPresentPercentageStr & " Between " & Val(ObjRFG.ParameterCmbo1_Value) & " And " & Val(ObjRFG.ParameterCmbo2_Value) & " "
            End If

            bView1Str = "Select A.AdmissionDocID, Sum(1) as GrandTotalClasses, " & _
                        " Sum(CASE WHEN A.IsPresent = 0 THEN 0 ELSE 1 END) GrandTotalPresents, " & _
                        " (Sum(CASE WHEN A.IsPresent = 0 THEN 0 ELSE 1 END) * 100) / Sum(1) As TotalPresentPer " & _
                        " From ViewSch_StudentAttendance1 A " & _
                        " " & mCondStr & " Group By A.AdmissionDocID "

            mQry = "SELECT Max(Adm.StudentName) StudentName, Max(Adm.AdmissionId) AS AdmissionId, " & _
                    " A.ClassSection AS ClassSectionCode, A.Subject AS SubjectCode,  " & _
                    " A.AdmissionDocId, Count(A.IsPresent) AS TotalClasses, " & bPresentPercentageStr & " As PresentPercentage,  " & _
                    " Sum(CASE WHEN IsNull(A.IsPresent,0)<>0 THEN 1 ELSE 0 END) AS TotalPresents, " & _
                    " Max(A.ClassSectionDesc) AS ClassSectionDesc,   " & _
                    " Max(A.SubjectName) AS SubjectName, Max(A.SubjectDisplayName) AS SubjectDisplayName,  " & _
                    " Max(A.SubjectType) AS SubjectType, A.CurrentStreamYearSemesterCode, Max(Sem.StreamYearSemesterDesc) AS StreamYearSemesterDesc, " & _
                    " Max(A.SubjectManualCode) AS SubjectManualCode, Max(A.PaperID) AS PaperID, Max(V.GrandTotalClasses)  As GrandTotalClasses, " & _
                    " Max(V.GrandTotalPresents) As GrandTotalPresents, Max(V.TotalPresentPer) As TotalPresentPer " & _
                    " FROM ViewSch_StudentAttendance1 A   " & _
                    " LEFT JOIN ViewSch_Admission Adm ON A.AdmissionDocId = Adm.DocId  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON A.CurrentStreamYearSemesterCode = Sem.Code " & _
                    " LEFT JOIN (" & bView1Str & ") As V On V.AdmissionDocID = A.AdmissionDocId " & _
                    " " & mCondStr & " GROUP BY A.ClassSection, A.AdmissionDocId, A.Subject, A.CurrentStreamYearSemesterCode " & _
                    " " & bHavingStr & " "

            DsRep = AgL.FillData(mQry, AgL.GCn)

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
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Bank Scroll List"
    Private Sub ProcBankScrollList()
        Try
            Call ObjRFG.FillGridString()

            'Code Change By Satyam on 16/03/2011
            Dim mCondStr$ = "", mCondStr1$ = "", bStrVAdvance = "", mCondStr2$ = ""
            Dim bQry1$ = "", bQry2$ = "", bREGQry$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            bStrVAdvance = " SELECT ARec.*, A.AdmissionID, A.Student AS StudentCode, A.StudentName,  " & _
                            " Fra.FeeReceiveDocId,  " & _
                            " Convert(BIT,CASE WHEN Fra.FeeReceiveDocId IS NULL THEN 0 ELSE 1 END) AS IsAdjusted,  " & _
                            " Vt.NCat, Vt.Description AS VoucherTypeDesc  , " & _
                            " (SELECT P.FromStreamYearSemester    FROM ViewSch_AdmissionPromotion P  WHERE P.AdmissionDocId = ARec.AdmissionDocId   AND ARec.V_Date >= P.AdmissionDate   AND P.Sr =   (SELECT Max(P.Sr)  FROM ViewSch_AdmissionPromotion P  WHERE P.AdmissionDocId = ARec.AdmissionDocId  AND ARec.V_Date >= P.AdmissionDate)) AS CurrentStreamYearSemesterCode    " & _
                            " FROM Sch_Advance ARec " & _
                            " LEFT JOIN Voucher_Type Vt ON ARec.V_Type = Vt.V_Type  " & _
                            " LEFT JOIN Sch_FeeReceiveAdvance Fra ON ARec.DocId = Fra.AdvanceDocId " & _
                            " LEFT JOIN ViewSch_Admission A ON ARec.AdmissionDocId = A.DocId   " & _
                            " WHERE Vt.NCat In (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_AdvanceReceive) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ReceiveEntry) & ") "
            mCondStr = " And Fr.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("Fr.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("Fr.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("Fr.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("FR1.SessionProgrammeStreamCode", 1)
            'mCondStr = mCondStr & ObjRFG.GetWhereCondition("SYSem.Stream", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("stu.category", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.bank_code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Fr.AdmissionDocId", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Fr.PreparedBy", 6)

            mCondStr1 = " And VSA.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("VSA.Site_Code", 0) = "" Then
                mCondStr1 = mCondStr1 & " And " & AgL.PubSiteCondition("VSA.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("VSA.Site_Code", 0)
            End If

            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("VSSY.SessionProgrammeStreamCode", 1)
            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("VSSY.StreamCode", 2)
            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("stu.category", 3)
            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("B.bank_code", 4)
            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("VSA.AdmissionDocId", 5)
            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("VSA.PreparedBy", 6)

            ''**********************Rati********************
            mCondStr2 = " And REG.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("REG.Site_Code", 0) = "" Then
                mCondStr2 = mCondStr2 & " And " & AgL.PubSiteCondition("REG.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr2 = mCondStr2 & ObjRFG.GetWhereCondition("REG.Site_Code", 0)
            End If

            mCondStr2 = mCondStr2 & ObjRFG.GetWhereCondition("REG.SessionProgrammeStream", 1)
            mCondStr2 = mCondStr2 & ObjRFG.GetWhereCondition("REGSP.Stream", 2)
            mCondStr2 = mCondStr2 & ObjRFG.GetWhereCondition("REGDT.category", 3)
            mCondStr2 = mCondStr2 & ObjRFG.GetWhereCondition("REGB.bank_code", 4)
            'mCondStr2 = mCondStr2 & ObjRFG.GetWhereCondition("VSA.AdmissionDocId", 5)
            mCondStr2 = mCondStr2 & ObjRFG.GetWhereCondition("REG.PreparedBy", 6)

            bREGQry = " SELECT REG.DocId ," & AgL.V_No_Field("REG.DocID") & " as DocID_Print,REG.Site_Code ,REG.V_Date ,'' AS AdmissionDocId, " & _
                   " REG.SessionProgrammeStream as SessionProgrammeStreamCode, " & _
                   " '' AS RegistrationDocId, '' AS AdmissionID, " & _
                   " Case When REGDT.Student Is Null Then (isnull(REGDT.FirstName,'') +' '+ isnull(REGDT.MiddleName,'') + ' '+ isnull(REGDT.LastName,''))  Else REGSTU.name End   As Student_Name,REGDT.FatherName ,   REGDT.Add1, REGDT.Add2, REGCT.CityName AS CityName , '' AS EnrollmentNo, " & _
                   " ''  as StudentManualcode,  REGSC.manualcode as StuCategory,Case When REGDT.Student Is Null Then (isnull(REGDT.FirstName,'') +' '+ isnull(REGDT.MiddleName,'') + ' '+ isnull(REGDT.LastName,''))  Else REGSTU.dispname END  as Student_Displayname,   " & _
                   " REGPd.CashAc, REGPd.CashAmount,REGPd.BankAc AS BankAc, REGPd.BankAmount AS BankAmount, REGPd.Bank_Code AS BankCode,REGB.Bank_Name, REGPd.Chq_No AS Chq_No, REGPd.Chq_Date AS Chq_Date, REGPd.Clg_Date AS Clr_Date, 'Bank-1' AS BankType,REGPd.TotalAmount,REGPd.PartyDrCr, " & _
                   " REGSP.SessionProgrammeStream AS SessionProgrammeStream,REGSP.StreamManualCode AS stream " & _
                   " FROM Sch_Registration REG  WITH (NoLock) " & _
                   " LEFT Join Sch_RegistrationStudentDetail REGDT WITH (NoLock) ON REG.DocId=REGDT.DocId  " & _
                   " LEFT Join ViewSch_SessionProgrammeStream REGSP WITH (NoLock) ON REG.SessionProgrammeStream=REGSP.Code  " & _
                   " LEFT JOIN ViewSch_Student REGSTU WITH (NoLock) ON REGDT.Student =REGSTU.SubCode    " & _
                   " LEFT Join City REGCT WITH (NoLock) ON REGDT.cityCode=REGCT.cityCode   " & _
                   " LEFT JOIN Sch_Category REGSC WITH (NoLock) on REGDT.category=REGSC.code     " & _
                   " LEFT JOIN PaymentDetail REGPd WITH (NoLock) ON REG.DocId = REGPd.DocId    " & _
                   " Left Join Bank REGB WITH (NoLock) on REGPd.bank_code=REGB.bank_code    " & _
                   " WHERE REGPd.BankAmount > 0 " & mCondStr2 & "  " & _
                   " UNION ALL (  " & _
                   " SELECT REG.DocId ," & AgL.V_No_Field("REG.DocID") & " as DocID_Print,REG.Site_Code ,REG.V_Date ,'' as AdmissionDocId, " & _
                   " REG.SessionProgrammeStream as SessionProgrammeStreamCode, " & _
                   " '' AS RegistrationDocId, '' AS AdmissionID, " & _
                   " Case When REGDT.Student Is Null Then (isnull(REGDT.FirstName,'') +' '+ isnull(REGDT.MiddleName,'') + ' '+ isnull(REGDT.LastName,''))  Else REGSTU.name End   As Student_Name,REGDT.FatherName ,   REGDT.Add1, REGDT.Add2, REGCT.CityName AS CityName , '' AS EnrollmentNo, " & _
                   " ''  as StudentManualcode,  REGSC.manualcode as StuCategory,Case When REGDT.Student Is Null Then (isnull(REGDT.FirstName,'') +' '+ isnull(REGDT.MiddleName,'') + ' '+ isnull(REGDT.LastName,''))  Else REGSTU.dispname END  as Student_Displayname,   " & _
                   " REGPd.CashAc, REGPd.CashAmount,REGPd.BankAc2 AS BankAc, REGPd.BankAmount2 AS BankAmount, REGPd.Bank_Code2 AS BankCode,REGB.Bank_Name, REGPd.Chq_No2 AS Chq_No2, REGPd.Chq_Date2 AS Chq_Date, REGPd.Clg_Date2 AS Clr_Date, 'Bank-2' AS BankType,REGPd.TotalAmount,REGPd.PartyDrCr, " & _
                   " REGSP.SessionProgrammeStream AS SessionProgrammeStream,REGSP.StreamManualCode AS stream " & _
                   " FROM Sch_Registration REG  WITH (NoLock) " & _
                   " LEFT Join Sch_RegistrationStudentDetail REGDT WITH (NoLock) ON REG.DocId=REGDT.DocId  " & _
                   " LEFT Join ViewSch_SessionProgrammeStream REGSP WITH (NoLock) ON REG.SessionProgrammeStream=REGSP.Code  " & _
                   " LEFT JOIN ViewSch_Student REGSTU WITH (NoLock) ON REGDT.Student =REGSTU.SubCode    " & _
                   " LEFT Join City REGCT WITH (NoLock) ON REGDT.cityCode=REGCT.cityCode   " & _
                   " LEFT JOIN Sch_Category REGSC WITH (NoLock) on REGDT.category=REGSC.code     " & _
                   " LEFT JOIN PaymentDetail REGPd WITH (NoLock) ON REG.DocId = REGPd.DocId    " & _
                   " Left Join Bank REGB WITH (NoLock) on REGPd.bank_code=REGB.bank_code    " & _
                   " WHERE REGPd.BankAmount2 > 0 " & mCondStr2 & " ) " & _
                   " UNION ALL (  " & _
                   " SELECT REG.DocId ," & AgL.V_No_Field("REG.DocID") & " as DocID_Print,REG.Site_Code ,REG.V_Date ,'' AS AdmissionDocId, " & _
                   " REG.SessionProgrammeStream as SessionProgrammeStreamCode, " & _
                   " '' AS RegistrationDocId, '' AS AdmissionID, " & _
                   " Case When REGDT.Student Is Null Then (isnull(REGDT.FirstName,'') +' '+ isnull(REGDT.MiddleName,'') + ' '+ isnull(REGDT.LastName,''))  Else REGSTU.name End   As Student_Name,REGDT.FatherName ,   REGDT.Add1, REGDT.Add2, REGCT.CityName AS CityName , '' AS EnrollmentNo, " & _
                   " ''  as StudentManualcode,  REGSC.manualcode as StuCategory,Case When REGDT.Student Is Null Then (isnull(REGDT.FirstName,'') +' '+ isnull(REGDT.MiddleName,'') + ' '+ isnull(REGDT.LastName,''))  Else REGSTU.dispname END  as Student_Displayname,   " & _
                   " REGPd.CashAc, REGPd.CashAmount,REGPd.BankAc3 AS BankAc, REGPd.BankAmount3 AS BankAmount, REGPd.Bank_Code3 AS BankCode,REGB.Bank_Name, REGPd.Chq_No3 AS Chq_No3, REGPd.Chq_Date3 AS Chq_Date, REGPd.Clg_Date3 AS Clr_Date, 'Bank-3' AS BankType,REGPd.TotalAmount,REGPd.PartyDrCr, " & _
                   " REGSP.SessionProgrammeStream AS SessionProgrammeStream,REGSP.StreamManualCode AS stream " & _
                   " FROM Sch_Registration REG  WITH (NoLock) " & _
                   " LEFT Join Sch_RegistrationStudentDetail REGDT WITH (NoLock) ON REG.DocId=REGDT.DocId  " & _
                   " LEFT Join ViewSch_SessionProgrammeStream REGSP WITH (NoLock) ON REG.SessionProgrammeStream=REGSP.Code  " & _
                   " LEFT JOIN ViewSch_Student REGSTU WITH (NoLock) ON REGDT.Student =REGSTU.SubCode    " & _
                   " LEFT Join City REGCT WITH (NoLock) ON REGDT.cityCode=REGCT.cityCode   " & _
                   " LEFT JOIN Sch_Category REGSC WITH (NoLock) on REGDT.category=REGSC.code     " & _
                   " LEFT JOIN PaymentDetail REGPd WITH (NoLock) ON REG.DocId = REGPd.DocId    " & _
                   " Left Join Bank REGB WITH (NoLock) on REGPd.bank_code=REGB.bank_code    " & _
                   " WHERE REGPd.BankAmount3 > 0 " & mCondStr2 & "  ) "


            '****************************************

            bQry1 = " SELECT VSA.DocId ," & AgL.V_No_Field("VSA.DocID") & " as DocID_Print,VSA.Site_Code ,VSA.V_Date ,VSA.AdmissionDocId, " & _
                    " VSA.CurrentStreamYearSemesterCode as SessionProgrammeStreamCode, " & _
                    " Adm.RegistrationDocId, Adm.AdmissionID, " & _
                    " Stu.name As Student_Name,  stu.FatherName ,   Stu.Add1, Stu.Add2, stu.CityName , Adm.EnrollmentNo, " & _
                    " stu.manualcode as StudentManualcode,  SC.manualcode as StuCategory,stu.dispname as Student_Displayname, " & _
                    " PD.CashAc, PD.CashAmount,PD.BankAc AS BankAc, PD.BankAmount AS BankAmount, PD.Bank_Code AS BankCode,B.Bank_Name, PD.Chq_No AS Chq_No, PD.Chq_Date AS Chq_Date, PD.Clg_Date AS Clr_Date, 'Bank-1' AS BankType,PD.TotalAmount,PD.PartyDrCr, " & _
                    " VSSY.SessionProgrammeStreamDesc AS SessionProgrammeStream,VSSY.StreamManualCode AS stream " & _
                    " FROM ( " & bStrVAdvance & " ) VSA " & _
                    " LEFT JOIN ViewSch_StreamYearSemester VSSY ON VSSY.Code=VSA.CurrentStreamYearSemesterCode  " & _
                    " LEFT JOIN ViewSch_Admission  ADM ON ADM.DocId=VSA.AdmissionDocId  " & _
                    " LEFT JOIN ViewSch_Student STU ON ADM.Student =STU.SubCode  " & _
                    " LEFT JOIN Sch_Category SC on stu.category=SC.code   " & _
                    " LEFT JOIN PaymentDetail Pd ON VSA.DocId = Pd.DocId  " & _
                    " Left Join Bank B on PD.bank_code=B.bank_code  " & _
                    " WHERE Pd.BankAmount > 0 " & mCondStr1 & "  " & _
                    " UNION ALL (  " & _
                    " SELECT VSA.DocId ," & AgL.V_No_Field("VSA.DocID") & " as DocID_Print,VSA.Site_Code ,VSA.V_Date ,VSA.AdmissionDocId, " & _
                    " VSA.CurrentStreamYearSemesterCode as SessionProgrammeStreamCode, " & _
                    " Adm.RegistrationDocId, Adm.AdmissionID, " & _
                    " Stu.name As Student_Name,  stu.FatherName ,   Stu.Add1, Stu.Add2, stu.CityName , Adm.EnrollmentNo, " & _
                    " stu.manualcode as StudentManualcode,  SC.manualcode as StuCategory,stu.dispname as Student_Displayname, " & _
                    " PD.CashAc, PD.CashAmount,PD.BankAc2 AS BankAc, PD.BankAmount2 AS BankAmount, PD.Bank_Code2 AS BankCode,B.Bank_Name, PD.Chq_No2 AS Chq_No2, PD.Chq_Date2 AS Chq_Date, PD.Clg_Date2 AS Clr_Date, 'Bank-2' AS BankType,PD.TotalAmount,PD.PartyDrCr, " & _
                    " VSSY.SessionProgrammeStreamDesc AS SessionProgrammeStream,VSSY.StreamManualCode AS stream " & _
                    " FROM ( " & bStrVAdvance & " ) VSA " & _
                    " LEFT JOIN ViewSch_StreamYearSemester VSSY ON VSSY.Code=VSA.CurrentStreamYearSemesterCode    " & _
                    " LEFT JOIN ViewSch_Admission  ADM ON ADM.DocId=VSA.AdmissionDocId  " & _
                    " LEFT JOIN ViewSch_Student STU ON ADM.Student =STU.SubCode   " & _
                    " LEFT JOIN Sch_Category SC on stu.category=SC.code   " & _
                    " LEFT JOIN PaymentDetail Pd ON VSA.DocId = Pd.DocId " & _
                    " Left Join Bank B on PD.bank_code2=B.bank_code   " & _
                    " WHERE Pd.BankAmount2 > 0 " & mCondStr1 & " ) " & _
                    " UNION ALL (  " & _
                    " SELECT VSA.DocId ," & AgL.V_No_Field("VSA.DocID") & " as DocID_Print,VSA.Site_Code ,VSA.V_Date ,VSA.AdmissionDocId, " & _
                    " VSA.CurrentStreamYearSemesterCode as SessionProgrammeStreamCode, " & _
                    " Adm.RegistrationDocId, Adm.AdmissionID, " & _
                    " Stu.name As Student_Name,  stu.FatherName ,   Stu.Add1, Stu.Add2, stu.CityName , Adm.EnrollmentNo, " & _
                    " stu.manualcode as StudentManualcode,  SC.manualcode as StuCategory,stu.dispname as Student_Displayname, " & _
                    " PD.CashAc, PD.CashAmount,PD.BankAc3 AS BankAc, PD.BankAmount3 AS BankAmount, PD.Bank_Code3 AS BankCode,B.Bank_Name, PD.Chq_No3 AS Chq_No3, PD.Chq_Date3 AS Chq_Date, PD.Clg_Date3 AS Clr_Date, 'Bank-3' AS BankType,PD.TotalAmount,PD.PartyDrCr, " & _
                    " VSSY.SessionProgrammeStreamDesc AS SessionProgrammeStream,VSSY.StreamManualCode AS stream " & _
                    " FROM ( " & bStrVAdvance & " ) VSA " & _
                    " LEFT JOIN ViewSch_StreamYearSemester VSSY ON VSSY.Code=VSA.CurrentStreamYearSemesterCode  " & _
                    " LEFT JOIN ViewSch_Admission  ADM ON ADM.DocId=VSA.AdmissionDocId     " & _
                    " LEFT JOIN ViewSch_Student STU ON ADM.Student =STU.SubCode   " & _
                    " LEFT JOIN Sch_Category SC on stu.category=SC.code   " & _
                    " LEFT JOIN PaymentDetail Pd ON VSA.DocId = Pd.DocId  " & _
                    " Left Join Bank B on PD.bank_code3=B.bank_code   " & _
                    " WHERE Pd.BankAmount3 > 0 " & mCondStr1 & "  ) "


            bQry2 = " Select vFr.*, SYSem.SessionProgrammeStream , SYSem.streamManualcode as Stream " & _
                    " From ( " & _
                    " SELECT FR.DocId ," & AgL.V_No_Field("FR.DocID") & " as DocID_Print,FR.site_code,FR.v_date ,FR.AdmissionDocId, " & _
                    " Case When FR1.SessionProgrammeStreamCode Is Null Then FR.SessionProgrammeStreamCode Else FR1.SessionProgrammeStreamCode End As SessionProgrammeStreamCode, " & _
                    " Adm.RegistrationDocId, Adm.AdmissionID, " & _
                    " Stu.name As Student_Name,  stu.FatherName , Stu.Add1, Stu.Add2, stu.CityName , Adm.EnrollmentNo , " & _
                    " stu.manualcode as StudentManualcode,SC.manualcode as StuCategory,stu.dispname as Student_Displayname, " & _
                    " PD.CashAc, PD.CashAmount,PD.BankAc AS BankAc, PD.BankAmount AS BankAmount, PD.Bank_Code AS BankCode,B.Bank_Name, PD.Chq_No AS Chq_No, PD.Chq_Date AS Chq_Date, PD.Clg_Date AS Clr_Date, 'Bank-1' AS BankType,PD.TotalAmount,PD.PartyDrCr " & _
                    " FROM ViewSch_FeeReceive Fr " & _
                    " LEFT JOIN ( " & _
                    " 			 SELECT fr1.DocId AS docid,max(fr1.SessionProgrammeStreamCode) AS SessionProgrammeStreamCode  " & _
                    " 			 FROM ViewSch_FeeReceive1 fr1  " & _
                    " 			 GROUP BY fr1.DocId " & _
                    "  			) FR1 ON FR.docid=FR1.DocId   " & _
                    " LEFT JOIN ViewSch_Admission  Adm ON FR.AdmissionDocId = Adm.DocId    " & _
                    " LEFT JOIN ViewSch_Student Stu ON Adm.Student =stu.SubCode   " & _
                    " Left Join Sch_Category SC on stu.category=SC.Code  " & _
                    " LEFT JOIN PaymentDetail Pd ON Fr.DocId = Pd.DocId  " & _
                    " Left Join Bank B on PD.bank_code=B.bank_code  " & _
                    " WHERE Pd.BankAmount > 0 " & mCondStr & " " & _
                    " UNION ALL ( " & _
                    " SELECT FR.DocId ," & AgL.V_No_Field("FR.DocID") & " as DocID_Print,FR.site_code,FR.v_date ,FR.AdmissionDocId,  " & _
                    " Case When FR1.SessionProgrammeStreamCode Is Null Then FR.SessionProgrammeStreamCode Else FR1.SessionProgrammeStreamCode End As SessionProgrammeStreamCode, " & _
                    " Adm.RegistrationDocId, Adm.AdmissionID,  " & _
                    " Stu.name As Student_Name,  stu.FatherName , Stu.Add1, Stu.Add2, stu.CityName , Adm.EnrollmentNo , " & _
                    " stu.manualcode as StudentManualcode,SC.manualcode as StuCategory,stu.dispname as Student_Displayname, " & _
                    " PD.CashAc, PD.CashAmount,PD.BankAc2 AS BankAc, PD.BankAmount2 AS BankAmount, PD.Bank_Code2 AS BankCode,B.Bank_Name, PD.Chq_No2 AS Chq_No, PD.Chq_Date2 AS Chq_Date, PD.Clg_Date2 AS Clr_Date, 'Bank-2' AS BankType,PD.TotalAmount,PD.PartyDrCr " & _
                    " FROM ViewSch_FeeReceive Fr " & _
                    " LEFT JOIN ( " & _
                    " 			 SELECT fr1.DocId AS docid,max(fr1.SessionProgrammeStreamCode) AS SessionProgrammeStreamCode  " & _
                    " 			 FROM ViewSch_FeeReceive1 fr1  " & _
                    " 			 GROUP BY fr1.DocId " & _
                    "  			) FR1 ON FR.docid=FR1.DocId   " & _
                    " LEFT JOIN ViewSch_Admission  Adm ON FR.AdmissionDocId = Adm.DocId    " & _
                    " LEFT JOIN ViewSch_Student Stu ON Adm.Student =stu.SubCode   " & _
                    " Left Join Sch_Category SC on stu.category=SC.Code  " & _
                    " LEFT JOIN PaymentDetail Pd ON Fr.DocId = Pd.DocId  " & _
                    " Left Join Bank B on PD.bank_code2=B.bank_code " & _
                    " WHERE Pd.BankAmount2 > 0 " & mCondStr & " ) " & _
                    " UNION ALL ( " & _
                    " SELECT FR.DocId ," & AgL.V_No_Field("FR.DocID") & " as DocID_Print,FR.site_code,FR.v_date ,FR.AdmissionDocId,  " & _
                    " Case When FR1.SessionProgrammeStreamCode Is Null Then FR.SessionProgrammeStreamCode Else FR1.SessionProgrammeStreamCode End As SessionProgrammeStreamCode, " & _
                    " Adm.RegistrationDocId, Adm.AdmissionID,  " & _
                    " Stu.name As Student_Name,  stu.FatherName , Stu.Add1, Stu.Add2, stu.CityName , Adm.EnrollmentNo , " & _
                    " stu.manualcode as StudentManualcode,SC.manualcode as StuCategory,stu.dispname as Student_Displayname, " & _
                    " PD.CashAc, PD.CashAmount,PD.BankAc3 AS BankAc, PD.BankAmount3 AS BankAmount, PD.Bank_Code3 AS BankCode, B.Bank_Name,PD.Chq_No3 AS Chq_No, PD.Chq_Date3 AS Chq_Date, PD.Clg_Date3 AS Clr_Date, 'Bank-3' AS BankType,PD.TotalAmount,PD.PartyDrCr " & _
                    " FROM ViewSch_FeeReceive Fr " & _
                    " LEFT JOIN ( " & _
                    " 			 SELECT fr1.DocId AS docid,max(fr1.SessionProgrammeStreamCode) AS SessionProgrammeStreamCode  " & _
                    " 			 FROM ViewSch_FeeReceive1 fr1  " & _
                    " 			 GROUP BY fr1.DocId " & _
                    "  			) FR1 ON FR.docid=FR1.DocId   " & _
                    " LEFT JOIN ViewSch_Admission  Adm ON FR.AdmissionDocId = Adm.DocId  " & _
                    " LEFT JOIN ViewSch_Student Stu ON Adm.Student =stu.SubCode   " & _
                    " Left Join Sch_Category SC on stu.category=SC.Code  " & _
                    " LEFT JOIN PaymentDetail Pd ON Fr.DocId = Pd.DocId  " & _
                    " Left Join Bank B on PD.bank_code3=B.bank_code " & _
                    " WHERE Pd.BankAmount3 > 0 " & mCondStr & " ) " & _
                    " ) As vFr " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStream SYSem ON vFr.SessionProgrammeStreamCode = sysem.Code Where 1=1 " & ObjRFG.GetWhereCondition("SYSem.Stream", 2) & ""


            If ObjRFG.ParameterCmbo1_Value = "Yes" Then
                mQry = " (" & bQry2 & ") UNION ALL (" & bQry1 & ") UNION ALL (" & bREGQry & ")"
            Else
                mQry = " (" & bQry2 & ") UNION ALL (" & bQry1 & ") "
            End If

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

            Dim mCondStr$ = "  "
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
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

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

            mCondStr1 = "'" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForSessionProgrammeStream,'" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' as Todate "


            mQry = "SELECT A.DocId As AdmissionDocId, A.AdmissionID, A.Student As StudentCode,a.StudentDispName, " & _
                    " A.LeavingDate, A.LeavingReason,a.V_Date AS J_Date,a.RollNo,a.FatherName,a.ProgrammeManualCode, " & _
                    " a.StreamManualCode,a.SessionProgrammeStreamDesc,a.SessionManualCode,ViewSch_Student.Add1,ViewSch_Student.Add2," & _
                    " ViewSch_Student.Add3,ViewSch_Student.CityName ,ViewSch_Student.dob, S.Photo As SitePhoto, " & mCondStr1 & "   " & _
                    " FROM ViewSch_Admission A " & _
                    " LEFT JOIN (SELECT Ap.* FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL ) P ON A.DocId = P.AdmissionDocId  " & _
                    " left join ViewSch_Student on a.student=ViewSch_Student.subcode " & _
                    " Left Join SiteMast S On A.Site_Code = S.Code " & _
                    " " & mCondStr & " " & _
                    " Order By A.StudentName "



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
#End Region

#Region "Leaving/Cancellation Report"
    Private Sub ProcLeavingCancellationReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "
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

            Dim mCondStr$ = "  "
            Dim mCondStr1$ = ""

            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where 1=1 "

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
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "
            Dim mCondStr1$ = ""

            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where 1=1 "

            If ObjRFG.GetWhereCondition("VSA.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("VSA.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSA.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsa.Student", 1)

            mQry = " SELECT VSA.V_Date,VSA.AdmissionID,VSA.	LeavingDate,VSA.Status,VSA.	EnrollmentNo,VSA.RollNo,VSA.StudentDispName,VSA.FatherName,VSA.MotherName," & _
                   " VSA.CityName,VSA.PIN,VSA.SessionProgrammeStreamDesc,VSA.SessionManualCode,VSA.	ProgrammeManualCode, " & _
                   " VSA.StreamManualCode,	ss.Add1,ss.add2,ss.add3,ss.Mobile,ss.Phone,ss.PAdd1,ss.PAdd2,ss.PAdd3,ss.CityName,ss.DOB," & _
                   " ss.CategoryManualCode,ss.Religion,ss.FatherOccupationDesc,ss.MotherOccupation,ss.BloodGroup,	Nationality.Nationaliy, " & _
                   " Si.Photo AS STudent_Photo,Si.Signature AS Stu_Sign,ss.Sex, S.Photo As SitePhoto " & _
                   " FROM ViewSch_Admission vsa " & _
                  " Left Join SiteMast S On Vsa.Site_Code =  S.Code " & _
                  " LEFT JOIN viewSch_Student SS ON vsa.Student=ss.SubCode " & _
                  " LEFT JOIN Nationality ON ss.NationalityCode=Nationality.NationalityCode " & _
                  " LEFT JOIN SubGroup_Image Si ON vsa.Student=Si.SubCode " & mCondStr & " "

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

            Dim mCondStr$ = "  "
            Dim mCondStr1$ = ""
            Dim mqry1 As String
            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            'If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where 1=1 "

            If ObjRFG.GetWhereCondition("VSA.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("VSA.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("VSA.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vsa.Student", 1)


            mQry = " SELECT VSA.V_Date,VSA.AdmissionID,VSA.	LeavingDate,VSA.Status,VSA.	EnrollmentNo,VSA.RollNo,VSA.StudentDispName,VSA.FatherName,VSA.MotherName," & _
                   " VSA.CityName,VSA.PIN,VSA.SessionProgrammeStreamDesc,VSA.SessionManualCode,VSA.	ProgrammeManualCode, " & _
                   " VSA.StreamManualCode,	ss.Add1,ss.add2,ss.add3,ss.Mobile,ss.Phone,ss.PAdd1,ss.PAdd2,ss.PAdd3,ss.CityName,ss.DOB," & _
                   " ss.CategoryManualCode,ss.Religion,ss.FatherOccupationDesc,ss.MotherOccupation,ss.BloodGroup,	Nationality.Nationaliy,ssad.Class,ssad.YearOfPassing,ssad.Subjects,ssad.TotalPercentage," & _
                   " ssad.PCMPercentage,Sch_University.Description AS University,Si.Photo AS STudent_Photo,Si.Signature AS Stu_Sign,ss.Sex, " & _
                   " Ss.Name AS StudentName, Ss.FamilyIncome , ss.FatherIncome , ss.MotherIncome, S.Photo As SitePhoto " & _
                   " FROM ViewSch_Admission vsa " & _
                  " Left Join SiteMast S On Vsa.Site_Code =  S.Code " & _
                  " LEFT JOIN viewSch_Student SS ON vsa.Student=ss.SubCode " & _
                  " LEFT JOIN Nationality ON ss.NationalityCode=Nationality.NationalityCode " & _
                  " LEFT JOIN Sch_StudentAcademicDetail SSAD ON vsa.Student=SSAD.SubCode " & _
                  " LEFT JOIN Sch_University ON ssad.University=Sch_University.code " & _
                  " LEFT JOIN SubGroup_Image Si ON vsa.Student=Si.SubCode " & mCondStr & " "

            mqry1 = " SELECT SSa.Amount ,vsa.AdmissionID,vsys.StreamYearSemesterDesc,vsf.DispName AS fee  " & _
                  " FROM Sch_AdmissionFeeDetail ssa  " & _
                  " LEFT JOIN ViewSch_Admission VSA ON ssa.DocId=vsa.DocId " & _
                  " LEFT JOIN ViewSch_StreamYearSemester VSYS ON ssa.StreamYearSemester=vsys.Code " & _
                  " LEFT JOIN ViewSch_Fee vsf ON ssa.Fee=vsf.Code " & mCondStr & " "

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

            Dim mCondStr$ = "  "
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
                    " Max(Sm.Name) AS Site_Name, Max(L.Site_Code) As Site_Code, Max(L.DivCode) As Div_Code, Max(V1.AdmissionID) As AdmissionID, Max(V1.Status) As Status, Max(V1.EnrollmentNo) As EnrollmentNo, Max(V1.RollNo) As RollNo, Max(V1.SessionProgrammeDesc) As SessionProgrammeDesc, Max(V1.SessionManualCode) As SessionManualCode ,max(lm.Narration) as Remark  " & _
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
                    " Sm.Name AS Site_Name, L.Site_Code, L.DivCode As Div_Code, V1.AdmissionID, V1.Status, V1.EnrollmentNo, V1.RollNo, V1.SessionProgrammeDesc, V1.SessionManualCode ,(lm.Narration) as Remark  " & _
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
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Fr.AdmissionDocId", 6)

            mQry = "SELECT Max(Sm.Name) AS Site_Name, Fr.Site_Code , Max(S.StartDate) AS SessionStartDate, " & _
                    " IsNull(sum(pd.CashAmount),0) AS CashAmount, IsNull(sum(pd.BankAmount),0) + IsNull(sum(pd.BankAmount2),0) + IsNull(sum(pd.BankAmount3),0) AS BankAmount, " & _
                    " IsNull(sum(pd.CardAmount),0) AS CardAmount, IsNull(sum(pd.AcTransferAmount),0) AS AcTransferAmount, IsNull(sum(fr.TotalLineDiscount),0) AS LineDiscount, " & _
                    " IsNull(sum(fr.DiscountAmount),0) AS HederDiscountAmount, IsNull(sum(fr.AdjustmentAmount),0) AS AdjustmentAmount, IsNull(Sum(Fr.TotalAdvanceAdjusted),0) As TotalAdvanceAdjusted, " & _
                    " Sem.StreamYearSemesterDesc, Max(Sem.SessionProgrammeStreamDesc) AS SessionProgrammeStreamDesc, S.Description AS SessionDesc, " & _
                    " IsNull(sum(fr.ScholarShipAmount),0) AS ScholarShipAmount, IsNull(sum(fr.CounselingFeeAdjusted),0) AS CounselingFeeAdjusted, IsNull(sum(pd.AdjustmentAmount),0) As PaymentDetail_AdjustmentAmount " & _
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

#Region "Fee Receive Register"
    Private Sub ProcFeeReceiveRegister()
        Try


            Dim mCondStr$ = "", bView1Str$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            Call ObjRFG.FillGridString()

            mCondStr = " Where H.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.CurrentSemester", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("ST.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionProgrammeCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.AdmissionDocId", 6)

            mQry = "SELECT H.DocId, H.Div_Code, H.Site_Code, H.V_Date, H.V_Type, H.V_Prefix, " & AgL.V_No_Field("H.DocID") & " as V_No, H.TotalLineAmount, H.TotalLineDiscount, " & _
                    " H.TotalLineNetAmount, H.Advance, H.SubTotal1, H.AdjustmentAmount as RegAdjustmentAmt, H.SubTotal2, H.DiscountPer, H.DiscountAmount, H.TotalNetAmount, H.Remark,H.ReceiveAmount, H.AdvanceCarriedForward, H.AdmissionDocId, H.TotalAdvanceAdjusted, H.IsAdjustableReceipt, H.TotalFeeReceiveAdjusted, H.FeeAdjustmentAc, H.FeeReceiptAdjustmentAc,H.ScholarShipAmount,H.ScholarshipAdjustmentAc,H.CounselingFeeAdjusted,h.CounselingFeeAdjustmentAc, " & _
                    " L.Amount, L.Discount, L.NetAmount,P.CashAc, P.CashAmount, P.BankAc, P.BankAmount, P.Bank_Code, P.Chq_No, P.Chq_Date,P.CardAc, P.CardAmount, P.CardBank_Code, P.Card_No, P.AcTransferBankAc, P.AcTransferAmount, P.AcTransferBank_Code, P.TotalAmount,P.AcTransferAcNo, P.PartyDrCr, P.BankAc2, P.BankAmount2, P.Bank_Code2, " & _
                    " P.Chq_No2, P.Chq_Date2, P.BankAc3, P.BankAmount3, P.Bank_Code3, P.Chq_No3, P.Chq_Date3, P.AdjustmentAc, P.AdjustmentAmount, P.AdjustmentRemark, " & _
                    " Sm.Name AS Site_Name, H.Site_Code ,St.Name AS StudentName, sg.Name as fee,CS.name AS CasAC,SG1.Name AS BankAC1,SG2.Name AS BankAC2,SG3.Name AS BankAC3,B1.Bank_Name AS Bank1,B2.Bank_Name AS Bank2,B3.Bank_Name AS Bank3,Ad.Name AS Adjustment,SG4.Name AS CardAC,B4.Bank_Name AS CardBank,SG5.Name AS ACTransferAC,B5.Bank_Name AS ACTransferBank, '" & ObjRFG.ParameterCmbo1_Value & "' AS ReportType, " & _
                    " A.CurrentSemester AS CurrentSemesterCode, Sem.StreamYearSemesterDesc AS CurrentSemesterDesc, Sem.SessionManualCode , Sem.SessionProgrammeDesc, " & _
                    " sem.StreamManualCode, Sem.ProgrammeManualCode, St.DispName AS StudentDispName, St.ManualCode AS StudentManualCode, St.Category,St.CategoryManualCode " & _
                    " FROM dbo.Sch_FeeReceive H WITH (NoLock)  " & _
                    " LEFT join dbo.Sch_FeeReceive1 L WITH (NoLock) ON H.DocId = L.DocId  " & _
                    " LEFT join dbo.Sch_FeeDue1 FD WITH (NoLock) ON L.FeeDue1 = FD.Code" & _
                    " LEFT join dbo.Subgroup SG WITH (NoLock) ON FD.Fee = SG.SubCode " & _
                    " LEFT JOIN dbo.PaymentDetail P WITH (NoLock) ON H.DocId = P.DocId " & _
                    " LEFT JOIN SiteMast Sm WITH (NoLock) ON H.Site_Code = Sm.Code " & _
                    " Left Join SubGroup CS WITH (NoLock) on P.CashAc =Cs.SubCode " & _
                    " Left Join SubGroup SG1 WITH (NoLock) on P.BankAc =SG1.SubCode " & _
                    " Left Join SubGroup SG2 WITH (NoLock) on P.BankAc2 =SG2.SubCode " & _
                    " Left Join SubGroup SG3 WITH (NoLock) on P.BankAc3 =SG3.SubCode " & _
                    " Left Join Bank B1 WITH (NoLock) on P.Bank_Code =B1.Bank_Code " & _
                    " Left Join Bank B2 WITH (NoLock) on P.Bank_Code2 =B2.Bank_Code " & _
                    " Left Join Bank B3 WITH (NoLock) on P.Bank_Code3 =B3.Bank_Code " & _
                    " Left Join SubGroup SG4 WITH (NoLock) on P.CardAc =SG4.SubCode " & _
                    " Left Join Bank B4 WITH (NoLock) on P.CardBank_Code =B4.Bank_Code " & _
                    " Left Join SubGroup SG5 WITH (NoLock) on P.AcTransferBankAc =SG5.SubCode " & _
                    " Left Join Bank B5 WITH (NoLock) on P.AcTransferBank_Code =B5.Bank_Code " & _
                    " Left Join SubGroup Ad WITH (NoLock) on P.AdjustmentAc =AD.SubCode " & _
                    " LEFT JOIN Sch_Admission A WITH (NoLock) On A.DocId = H.AdmissionDocId  " & _
                    " LEFT JOIN ViewSch_Student St WITH (NoLock) On A.Student = St.SubCode  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem WITH (NoLock) ON Sem.Code = A.CurrentSemester   " & _
                    " " & mCondStr & " "

            RepName = "Academic_FeeReceiveRegister" : RepTitle = "Fee Receive Register"
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

            Dim mCondStr$ = "  "
            Dim mCondStr1$ = "", mCondStr2$ = ""
            Dim mqry1 As String, mQry2 As String = ""

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

            If GRepFormName = AdditionalFeeFineReceiptReport Then mCondStr = mCondStr & ObjRFG.GetWhereCondition("Fr.V_Type", 7)

            'Code By Akash On Date 19-3-2011
            mCondStr1 = " where A.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("A.Site_Code", 0) = "" Then
                mCondStr1 = mCondStr1 & " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("A.Site_Code", 0)
            End If

            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("VSPSY.Code", 1)
            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("VSS.Category", 2)
            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("VSPSY.StreamCode", 3)
            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("VSPSY.SessionProgrammeCode", 4)
            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("VSPSY.SessionCode", 5)
            mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("ViewSch_Admission.DocId", 6)
            If GRepFormName = AdditionalFeeFineReceiptReport Then mCondStr1 = mCondStr1 & ObjRFG.GetWhereCondition("A.V_Type", 7)
            'End Code

            mQry = " SELECT Site.Name As Site_Name, VSPSY.StreamYearSemesterDesc, Sch_Category.manualcode AS Category, " & _
                    " Fr1.NetAmount NetReceiveAmount ,Fr1.Discount AS Discount, " & _
                    " ViewSch_Admission.AdmissionID as AdmissionId,Fr.V_Date, VSS.name as StudenName, " & _
                    " VSPSY.StreamManualCode as Stream,VSPSY.ProgrammeManualCode as Programme, " & _
                    " VSPSY.SessionDescription as Session,subgroup.dispname as Fees,Fr.v_no as Vno, Fr1.Amount AS ReceiveAmount, " & AgL.V_No_Field("Fr.DocId") & " As Receipt_VNo, Fr.V_Type, " & _
                    " '" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForSemester,'" & ObjRFG.GetHelpString(2) & "' As ForCatgory, " & _
                    " '" & ObjRFG.GetHelpString(3) & "' As ForStream,'" & ObjRFG.GetHelpString(4) & "' As ForProgramme,'" & ObjRFG.GetHelpString(5) & "' As ForSession, " & _
                    " '" & ObjRFG.GetHelpString(6) & "' As ForSTUDENT, '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' as Todate " & _
                    " FROM ViewSch_FeeReceive Fr " & _
                    " LEFT JOIN SiteMast Site On Fr.Site_Code = Site.Code " & _
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


            'Code By Akash On Date 19-3-11

            mQry2 = " SELECT Site.Name As Site_Name, VSPSY.StreamYearSemesterDesc, C.manualcode AS Category, " & _
                    " Rd.ReceiveAmount AS NetReceiveAmount, 0 AS Discount, ViewSch_Admission.AdmissionID, A.V_Date, " & _
                    " ViewSch_Admission.StudentName, VSPSY.StreamManualCode AS Stream, VSPSY.ProgrammeManualCode AS Programme, " & _
                    " VSPSY.SessionDescription as Session, Sg.dispname as Fees,A.v_no as Vno,  " & _
                    " Rd.ReceiveAmount AS ReceiveAmount, " & _
                    " " & AgL.V_No_Field("A.DocId") & " As Receipt_VNo, A.V_Type,  " & _
                    " '" & ObjRFG.GetHelpString(0) & "' As ForSiteCode,'" & ObjRFG.GetHelpString(1) & "' As ForSemester,'" & ObjRFG.GetHelpString(2) & "' As ForCatgory, " & _
                    " '" & ObjRFG.GetHelpString(3) & "' As ForStream,'" & ObjRFG.GetHelpString(4) & "' As ForProgramme,'" & ObjRFG.GetHelpString(5) & "' As ForSession, " & _
                    " '" & ObjRFG.GetHelpString(6) & "' As ForSTUDENT, '" & ObjRFG.ParameterDate1_Value & "'  as FromDate,'" & ObjRFG.ParameterDate2_Value & "' as Todate " & _
                    " FROM Sch_Advance A  " & _
                    " LEFT JOIN SiteMast Site On A.Site_Code = Site.Code " & _
                    " LEFT JOIN Sch_ReceiveDetail Rd ON A.DocId = Rd.DocId " & _
                    " LEFT JOIN ViewSch_Admission ViewSch_Admission ON A.AdmissionDocId = ViewSch_Admission.DocId " & _
                    " Left Join " & _
                    " (SELECT Ap.AdmissionDocId, Ap.FromStreamYearSemester AS StreamYearSemester " & _
                    " FROM Sch_AdmissionPromotion Ap  " & _
                    " WHERE Ap.PromotionDate IS NULL) AS V1 ON ViewSch_Admission.DocId = V1.AdmissionDocId " & _
                    " LEFT JOIN ViewSch_StreamYearSemester VSPSY ON V1.StreamYearSemester = VSPSY.Code " & _
                    " Left join Sch_Fee on Rd.Fee = Sch_Fee.code   " & _
                    " LEFT JOIN SubGroup Sg ON Rd.Fee = Sg.SubCode  " & _
                    " LEFT JOIN ViewSch_Student Vss ON ViewSch_Admission.Student = Vss.SubCode     " & _
                    " LEFT JOIN Sch_Category C ON VSS.Category  = C.Code " & _
                    " " & mCondStr1 & " "

            'End Code


            If GRepFormName = FeeReceiptHeadWiseReport Then
                RepName = "Academic_Fee_Receipt_HeadWise_Report" : RepTitle = "Fee Receipt HeadWise Report"
            ElseIf GRepFormName = FeeReceiveReportSessionwise Then
                DsRep1 = AgL.FillData(mqry1, AgL.GCn)
                RepName = "Academic_Fee_Fee_Receive_Report_Sessionwise" : RepTitle = "Fee Receive Report Sessionwise"
            Else
                mQry = mQry & " and Sch_Fee.feenature in (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.FeeNature_Fine) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.FeeNature_LateFee) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.FeeNature_Others) & ")  "
                mQry = mQry & " UNION ALL " & mQry2 & " and Sch_Fee.feenature in (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.FeeNature_Fine) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.FeeNature_LateFee) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.FeeNature_Others) & ")  "
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
                   " vfd.AdmissionDocId, ViewSch_Admission.AdmissionID as AdmissionId,VSS.fathername as FatherName,VFD.V_Date, " & _
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

            Dim mCondStr$ = "  "
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
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

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
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VFD.FeeCode", 7)


            mCondStr = mCondStr & " and case when A.LeavingDate is  null then " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " else A.LeavingDate end <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & "   "

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "No") Then
                mCondStr = mCondStr & "  AND vfd.TillDate_NetBalance > 0 "
            End If


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

            If AgL.StrCmp(GRepFormName, OutStandingReportFeeHeadWise) Then
                RepName = "Fee_Outstanding_Report_FeeHead_Wise" : RepTitle = "Outstanding Report Fee Head Wise"
            Else
                RepName = "Academic_Student_Outstanding_Report_FeeHead_Wise" : RepTitle = "Student Outstanding Report FeeHead Wise"
            End If


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
            '============================================================================================================
            '======================<Fee Collection Summary Fee Head Wise>================================================
            '==============================< Is Not in Use Now >=========================================================
            '============================================================================================================

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
                                " Max(vFd.DueAmount) AS FeeDue, Sum(FRecv1.Discount) AS FeeDiscount, Sum(FRecv1.NetAmount) AS FeeReceive, IsNull(Sum(vFRef1.NetFeeRefund),0) AS NetFeeRefund, " & _
                                " Max(vFd.FeeCode) AS FeeCode, Max(Sg.DispName) as FeeDispName, Max(Sg.Name) As FeeName, Max(Sg.ManualCode) AS FeeShortName, " & _
                                " IsNull(Max(vFd.DueAmount),0) - (IsNull(Sum(FRecv1.Discount),0) + IsNull(Sum(FRecv1.NetAmount),0) ) + IsNull(Sum(vFRef1.NetFeeRefund),0) As FeeBalance " & _
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
                                " Sum(FRecv.CounselingFeeAdjusted) As CounselingFeeAdjusted, Sum(FRecv.ScholarShipAmount) As ScholarShipAdjusted, Sum(FRecv.TotalFeeReceiveAdjusted) As TotalFeeReceiveAdjusted, " & _
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
                                " FRef.Site_Code, vFRef1.FeeReceiveDocId, FRef.AdmissionDocId, " & _
                                " Sum(FRef.RefundAmount) AS RefundAmount, Sum(FRef.ExcessRefund) AS ExcessRefund, Sum(FRef.TotalFeeRefund) As TotalFeeRefund " & _
                                " FROM Sch_FeeRefund FRef " & _
                                " LEFT JOIN (SELECT FRef1.DocId, FRef1.FeeReceiveDocId, Sum(FRef1.NetAmount) AS RefundAount FROM Sch_FeeRefund1 FRef1 GROUP BY FRef1.DocId, FRef1.FeeReceiveDocId) vFRef1 On vFRef1.DocId = FRef.DocId " & _
                                " WHERE FRef.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " " & _
                                " GROUP BY FRef.Site_Code, vFRef1.FeeReceiveDocId, FRef.AdmissionDocId " & _
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

            Dim mCondStr$ = "  ", bViewStr$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

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
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vfd.AdmissionDocId", 6)

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
                    " " & IIf(AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes"), "", " Having Sum(vfd.TillDate_NetBalance) > 0 ") & " "
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

#Region "Registration Register"
    Private Sub ProcRegistrationRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub


            mCondStr = " where Sr.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If ObjRFG.GetWhereCondition("SR.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("SR.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("SR.Site_Code", 0)
            End If

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



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Fee Report" 'Code By Akash On Date 23-3-11
    Private Sub ProcFeeReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            mCondStr = " where 1=1 "

            If ObjRFG.GetWhereCondition("FeeStr.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("FeeStr.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("FeeStr.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vAp.AdmissionDocId", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionProgrammeCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.Code", 6)

            mQry = "SELECT Va.AdmissionId, Va.StudentName, " & _
                        " FeeStr.Site_Code, FeeStr.AdmissionDocId, " & _
                        " FeeStr.OpeningDr, FeeStr.OpeningCr, FeeStr.OpeningNetDr, " & _
                        " FeeStr.OpeningNetCr, FeeStr.OpeningAdvanceReceive, FeeStr.OpeningBalanceLedger,    " & _
                        " FeeStr.OpeningNetBal,  FeeStr.DueAmt, FeeStr.LineAmount,   FeeStr.LineDiscount, FeeStr.LineNetAmount,  " & _
                        " FeeStr.AdvanceBF,  FeeStr.AdjustmentAmount, FeeStr.DiscountAmount,    " & _
                        " FeeStr.TotalAdvanceAdjusted, FeeStr.TotalFeeReceiveAdjusted,  " & _
                        " FeeStr.TotalNetAmount,   FeeStr.TotalFeeRecvCrAmt, FeeStr.RefundAmt, FeeStr.AdvanceAmt,   " & _
                        " FeeStr.CurrentDr,  FeeStr.CurrentCr, FeeStr.CurrentNetDr,  FeeStr.CurrentNetCr,    " & _
                        " FeeStr.CurrentAdvanceReceive, FeeStr.CurrentBalanceLedger,   " & _
                        " FeeStr.CurrentNetBal, FeeStr.ClosingDr, FeeStr.ClosingCr,   " & _
                        " FeeStr.ClosingNetDr,   " & _
                        " FeeStr.ClosingNetCr,   " & _
                        " FeeStr.ClosingAdvanceReceive,   " & _
                        " FeeStr.ClosingBalanceLedger,   " & _
                        " FeeStr.ClosingNetBal,   " & _
                        " FeeStr.ReverseDueAmt, FeeStr.CounselingFeeAdjusted, FeeStr.ScholarShipAmount, " & _
                        " FeeStr.OpeningLedgerDr, FeeStr.OpeningLedgerCr, FeeStr.CurrentLedgerDr, FeeStr.CurrentLedgerCr, " & _
                        " FeeStr.OpeningFeeReceiveAmt, FeeStr.CurrentFeeReceiveAmt, " & _
                        " FeeHeadStr.OpeningReverseDueAmt, FeeHeadStr.CurrentReverseDueAmt, FeeHeadStr.Fee, FeeHeadStr.FeeHead , " & _
                        " FeeHeadStr.OpeningDueAmt,  " & _
                        " FeeHeadStr.OpeningReceiveAmt,  " & _
                        " FeeHeadStr.OpeningDiscount,  " & _
                        " FeeHeadStr.OpeningRefundAmt,  " & _
                        " FeeHeadStr.OpeningBalance,  " & _
                        " FeeHeadStr.CurrentDueAmt,  " & _
                        " FeeHeadStr.CurrentReceiveAmt,  " & _
                        " FeeHeadStr.CurrentDiscount,  " & _
                        " FeeHeadStr.CurrentRefundAmt,  " & _
                        " FeeHeadStr.CurrentBalance, " & _
                        " FeeHeadStr.TillDateDueAmt, " & _
                        " FeeHeadStr.TillDateReceiveAmt, " & _
                        " FeeHeadStr.TillDateDiscount, " & _
                        " FeeHeadStr.TillDateRefundAmt, " & _
                        " FeeHeadStr.TillDateBalance, " & _
                        " Sem.StreamYearSemesterDesc , Sem.SessionProgrammeStreamYearDesc, Sem.SessionProgrammeDesc, " & _
                        " Sem.SessionProgrammeStreamDesc, Sem.SessionManualCode , Sem.ProgrammeManualCode , " & _
                        " Sem.StreamManualCode, Sem.SemesterSerialNo , Sem.YearSerial, S.CategoryManualCode, Sm.Name As Site_Name " & _
                        " From (SELECT Ap.* FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) vAp " & _
                        " LEFT JOIN ViewSch_Admission Va ON vAp.AdmissionDocId = Va.DocId  " & _
                        " LEFT JOIN ViewSch_Student S ON vA.Student = S.SubCode " & _
                        " LEFT JOIN ViewSch_StreamYearSemester Sem ON vAp.FromStreamYearSemester = Sem.Code " & _
                        " LEFT JOIN (" & FunGetFeeDetailStr(ObjRFG.ParameterDate1_Value, ObjRFG.ParameterDate2_Value) & ") As FeeStr On vAp.AdmissionDocId = FeeStr.AdmissionDocId " & _
                        " LEFT JOIN (" & FunGetFeeHeadDetailStr(ObjRFG.ParameterDate1_Value, ObjRFG.ParameterDate2_Value) & ") As FeeHeadStr ON FeeStr.Site_Code = FeeHeadStr.Site_Code AND FeeStr.AdmissionDocId = FeeHeadStr.AdmissionDocId  " & _
                        " LEFT JOIN SiteMast Sm On FeeStr.Site_Code = Sm.Code " & mCondStr


            'mQry = FunGetFeeDetailStr(ObjRFG.ParameterDate1_Value, ObjRFG.ParameterDate2_Value)

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Academic_FeeReport" : RepTitle = "Fee Report"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Fee Report Summary" 'Code By Akash On Date 23-3-11
    Private Sub ProcFeeReportSummary()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "  "

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            mCondStr = " where 1=1 "

            If ObjRFG.GetWhereCondition("FeeStr.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("FeeStr.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("FeeStr.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("vAp.AdmissionDocId", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionProgrammeCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.Code", 6)

            mQry = "SELECT Va.AdmissionId, Va.StudentName, " & _
                        " FeeStr.Site_Code, FeeStr.AdmissionDocId, " & _
                        " FeeStr.OpeningDr, FeeStr.OpeningCr, FeeStr.OpeningNetDr, " & _
                        " FeeStr.OpeningNetCr, FeeStr.OpeningAdvanceReceive, FeeStr.OpeningBalanceLedger,    " & _
                        " FeeStr.OpeningNetBal,  FeeStr.DueAmt, FeeStr.LineAmount,   FeeStr.LineDiscount, FeeStr.LineNetAmount,  " & _
                        " FeeStr.AdvanceBF,  FeeStr.AdjustmentAmount, FeeStr.DiscountAmount,    " & _
                        " FeeStr.TotalAdvanceAdjusted, FeeStr.TotalFeeReceiveAdjusted,  " & _
                        " FeeStr.TotalNetAmount,   FeeStr.TotalFeeRecvCrAmt, FeeStr.RefundAmt, FeeStr.AdvanceAmt,   " & _
                        " FeeStr.CurrentDr,  FeeStr.CurrentCr, FeeStr.CurrentNetDr,  FeeStr.CurrentNetCr,    " & _
                        " FeeStr.CurrentAdvanceReceive, FeeStr.CurrentBalanceLedger,   " & _
                        " FeeStr.CurrentNetBal, FeeStr.ClosingDr, FeeStr.ClosingCr,   " & _
                        " FeeStr.ClosingNetDr,   " & _
                        " FeeStr.ClosingNetCr,   " & _
                        " FeeStr.ClosingAdvanceReceive,   " & _
                        " FeeStr.ClosingBalanceLedger,   " & _
                        " FeeStr.ClosingNetBal, " & _
                        " FeeStr.ReverseDueAmt, FeeStr.CounselingFeeAdjusted, FeeStr.ScholarShipAmount, " & _
                        " FeeStr.OpeningLedgerDr, FeeStr.OpeningLedgerCr, FeeStr.CurrentLedgerDr, FeeStr.CurrentLedgerCr, " & _
                        " FeeStr.OpeningFeeReceiveAmt, FeeStr.CurrentFeeReceiveAmt, " & _
                        " Sem.StreamYearSemesterDesc , Sem.SessionProgrammeStreamYearDesc, Sem.SessionProgrammeDesc, " & _
                        " Sem.SessionProgrammeStreamDesc, Sem.SessionManualCode , Sem.ProgrammeManualCode , " & _
                        " Sem.StreamManualCode, Sem.SemesterSerialNo , Sem.YearSerial, S.CategoryManualCode, Sm.Name As Site_Name " & _
                        " From (SELECT Ap.* FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) vAp " & _
                        " LEFT JOIN ViewSch_Admission Va ON vAp.AdmissionDocId = Va.DocId  " & _
                        " LEFT JOIN ViewSch_Student S ON vA.Student = S.SubCode " & _
                        " LEFT JOIN ViewSch_StreamYearSemester Sem ON vAp.FromStreamYearSemester = Sem.Code " & _
                        " LEFT JOIN  (" & FunGetFeeDetailStr(ObjRFG.ParameterDate1_Value, ObjRFG.ParameterDate2_Value) & ") As FeeStr On vAp.AdmissionDocId = FeeStr.AdmissionDocId " & _
                        " LEFT JOIN SiteMast Sm On FeeStr.Site_Code = Sm.Code " & _
                        " " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Academic_FeeReportSummary" : RepTitle = "Fee Report (Summary)"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Academic_Main)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Installment Report"
    Private Sub ProcInstallmentReport()
        Try
            Dim mCondStr$ = "  "

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub

            Call ObjRFG.FillGridString()


            mCondStr = " where 1=1 "

            mCondStr += " And H.EntryDate Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Yes") Then
                mCondStr += " And H.InActiveDate Is Null "
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "No") Then
                mCondStr += " And H.InActiveDate Is Not Null "
            End If

            If AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Yes") Then
                mCondStr += " And IsNull(L.IsInActive,0) = 0 "
            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "No") Then
                mCondStr += " And IsNull(L.IsInActive,0) <> 0 "
            End If

            If ObjRFG.GetWhereCondition("FeeStr.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.AdmissionDocId", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("S.Category", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.StreamCode", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionCode", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.SessionProgrammeCode", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Sem.Code", 6)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Uid", 7)

            mQry = "SELECT Convert(VARCHAR(36),H.UID) AS Uid, H.Div_Code, H.Site_Code, Sm.Name AS Site_Name, " & FunGetEntryNoDisplayField("H") & " As EntryNoDisplay, " & _
                    " H.EntryDate, H.Prefix, H.EntryNo, H.RecordType, Sg.Name As EmployeeName, Sg.DispName As EmployeeDispName, Sg.ManualCode As EmployeeManualCode, " & _
                    " H.AdmissionDocId, H.DueAmount, H.InstallmentAmount As Header_InstallmentAmount, H.TotalInstallments, H.InstallmentStartDate, H.Remark,  " & _
                    " Case When H.InActiveDate Is Not Null Then 'Yes' Else 'No' End As Header_InActive, " & _
                    " H.InActiveDate AS Header_InActiveDate, H.InActiveRemark AS Header_InActiveRemark,  " & _
                    " H.PreparedBy, H.U_EntDt, H.U_AE, H.Edit_Date, H.ModifiedBy, H.ApprovedBy, H.ApprovedDate, " & _
                    " L.InstallmentDate, L.InstallmentAmount, L.RemindBeforeDays, L.RemindAfterDays,  " & _
                    " CASE WHEN IsNull(L.IsInActive,0) <> 0 THEN 'Yes' ELSE 'No' END AS InActiveInstallment, " & _
                    " S.Name AS StudentName, S.DispName AS StudentDispName, S.ManualCode AS StudentManualCode, " & _
                    " S.FatherName, S.HusbandName, S.Sex, " & _
                    " S.Add1, S.add2, S.Add3, S.CityName, S.PIN, S.Phone, S.Mobile, S.FAX, S.EMail, S.PAN, " & _
                    " S.PAdd1, S.PAdd2, S.PAdd3, S.PCityName, S.PPin, S.PPhone, S.PMobile, S.PFax,S.LocalGuardian, " & _
                    " S.TAdd1, S.TAdd2, S.TAdd3, S.TCityName, S.TPin, S.TPhone, S.TMobile, S.TFax,  " & _
                    " S.CategoryDesc, S.CategoryManualCode, S.ReligionDesc,  " & _
                    " Sem.StreamYearSemesterDesc , Sem.SessionProgrammeStreamYearDesc, Sem.SessionProgrammeDesc, " & _
                    " Sem.SessionProgrammeStreamDesc, Sem.SessionManualCode , Sem.ProgrammeManualCode , " & _
                    " Sem.StreamManualCode, Sem.SemesterSerialNo , Sem.YearSerial " & _
                    " FROM Sch_DueInstallment H " & _
                    " LEFT JOIN (SELECT Ap.* FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) vAp ON vAp.AdmissionDocId = H.AdmissionDocId  " & _
                    " LEFT JOIN Sch_DueInstallment1 L ON H.UID = L.UID " & _
                    " LEFT JOIN SiteMast Sm ON Sm.Code = H.Site_Code  " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode = H.Employee " & _
                    " LEFT JOIN ViewSch_Student S ON S.SubCode = H.SubCode  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON vAp.FromStreamYearSemester = Sem.Code " & _
                    " " & mCondStr & ""

            DsRep = AgL.FillData(mQry, AgL.GCn)
            RepName = "Fee_InstallmentReport" : RepTitle = "Fee_InstallmentReport"

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

    Public Function FunGetFeeDueStr(ByVal bFromDateStr As String, ByVal bToDateStr As String) As String
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

    Private Function FunGetFeeDetailStr(ByVal bFromDateStr As String, ByVal bToDateStr As String) As String
        Dim bViewStr$ = "", bStrNCatExceptLedger$ = ""

        Try
            bStrNCatExceptLedger = "" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeDue) & ", " & _
                                    " " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ReverseFeeDue) & ", " & _
                                    " " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningFeeDue) & ", " & _
                                    " " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceive) & ", " & _
                                    " " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceiveAdjustment) & ", " & _
                                    " " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeRefund) & ", " & _
                                    " " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvance) & ", " & _
                                    " " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_AdvanceReceive) & ", " & _
                                    " " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) & ""

            bViewStr = "SELECT VMain.Site_Code, VMain.AdmissionDocId, " & _
                        " sum(VMain.OpeningDr) AS OpeningDr, " & _
                        " sum(VMain.OpeningCr) AS OpeningCr,     " & _
                        " sum(VMain.OpeningNetDr) AS OpeningNetDr, " & _
                        " sum(VMain.OpeningNetCr) AS OpeningNetCr,     " & _
                        " sum(VMain.OpeningAdvanceReceive) AS OpeningAdvanceReceive,    " & _
                        " sum(VMain.OpeningFeeReceiveAmt) AS OpeningFeeReceiveAmt,    " & _
                        " sum(VMain.OpeningLedgerDr) AS OpeningLedgerDr,    " & _
                        " sum(VMain.OpeningLedgerCr) AS OpeningLedgerCr,    " & _
                        " sum(VMain.OpeningBalanceLedger) AS OpeningBalanceLedger,    " & _
                        " sum(VMain.OpeningNetBal) AS OpeningNetBal,  sum(VMain.DueAmt) AS DueAmt, sum(VMain.ReverseDueAmt) AS ReverseDueAmt,    " & _
                        " sum(VMain.LineAmount) AS LineAmount,   sum(VMain.LineDiscount) AS LineDiscount,  " & _
                        " sum(VMain.LineAmount) - sum(VMain.LineDiscount) AS LineNetAmount,  " & _
                        " sum(VMain.BFAdvance) AS AdvanceBF,  sum(VMain.AdjustmentAmount) AS AdjustmentAmount,  " & _
                        " sum(VMain.CounselingFeeAdjusted) AS CounselingFeeAdjusted,    " & _
                        " sum(VMain.ScholarShipAmount) AS ScholarShipAmount,    " & _
                        " sum(VMain.DiscountAmount) AS DiscountAmount,    " & _
                        " sum(VMain.TotalAdvanceAdjusted) AS TotalAdvanceAdjusted,   " & _
                        " sum(VMain.TotalFeeReceiveAdjusted) AS TotalFeeReceiveAdjusted,  " & _
                        " sum(VMain.TotalNetAmount) AS TotalNetAmount,   sum(VMain.TotalFeeRecvCrAmt) AS TotalFeeRecvCrAmt,    " & _
                        " sum(VMain.RefundAmt) AS RefundAmt, " & _
                        " sum(VMain.AdvanceAmt) AS AdvanceAmt,    " & _
                        " sum(VMain.CurrentDr) AS CurrentDr,  sum(VMain.CurrentCr) AS CurrentCr,    " & _
                        " sum(VMain.CurrentNetDr) AS CurrentNetDr,  sum(VMain.CurrentNetCr) AS CurrentNetCr,    " & _
                        " sum(VMain.CurrentAdvanceReceive) AS CurrentAdvanceReceive,   " & _
                        " sum(VMain.CurrentFeeReceiveAmt) AS CurrentFeeReceiveAmt,   " & _
                        " sum(VMain.CurrentLedgerDr) AS CurrentLedgerDr,   " & _
                        " sum(VMain.CurrentLedgerCr) AS CurrentLedgerCr,   " & _
                        " sum(VMain.CurrentBalanceLedger) AS CurrentBalanceLedger,   " & _
                        " sum(VMain.CurrentNetBal) AS CurrentNetBal,   " & _
                        " CASE WHEN sum(VMain.OpeningDr) + sum(VMain.CurrentDr) >  sum(VMain.OpeningCr) + sum(VMain.CurrentCr)  " & _
                        " 	   THEN sum(VMain.OpeningDr) + sum(VMain.CurrentDr) -  sum(VMain.OpeningCr) - sum(VMain.CurrentCr) ELSE 0 END  " & _
                        " AS ClosingDr,   " & _
                        " CASE WHEN sum(VMain.OpeningDr) + sum(VMain.CurrentDr) <=  sum(VMain.OpeningCr) + sum(VMain.CurrentCr)  " & _
                        " 	   THEN sum(VMain.OpeningCr) + sum(VMain.CurrentCr) - sum(VMain.OpeningDr) - sum(VMain.CurrentDr) ELSE 0 END  " & _
                        " AS ClosingCr,   " & _
                        " CASE WHEN sum(VMain.OpeningNetDr) + sum(VMain.CurrentNetDr) >  sum(VMain.OpeningNetCr) + sum(VMain.CurrentNetCr)  " & _
                        " 	   THEN sum(VMain.OpeningNetDr) + sum(VMain.CurrentNetDr) -  sum(VMain.OpeningNetCr) - sum(VMain.CurrentNetCr) ELSE 0 END  " & _
                        " AS ClosingNetDr,   " & _
                        " CASE WHEN sum(VMain.OpeningNetDr) + sum(VMain.CurrentNetDr) <=  sum(VMain.OpeningNetCr) + sum(VMain.CurrentNetCr)  " & _
                        " 	   THEN sum(VMain.OpeningNetCr) + sum(VMain.CurrentNetCr) - sum(VMain.OpeningNetDr) - sum(VMain.CurrentNetDr) ELSE 0 END  " & _
                        " AS ClosingNetCr,   " & _
                        " sum(VMain.OpeningAdvanceReceive) + sum(VMain.CurrentAdvanceReceive) AS ClosingAdvanceReceive,   " & _
                        " sum(VMain.OpeningBalanceLedger) + sum(VMain.CurrentBalanceLedger) AS ClosingBalanceLedger,   " & _
                        " sum(VMain.OpeningNetBal) + sum(VMain.CurrentNetBal) AS ClosingNetBal   " & _
                        " FROM  ( " & _
                        " SELECT V1.Site_Code, V1.AdmissionDocId,    " & _
                        " CASE WHEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) >  Sum(isnull(V1.TotalFeeRecvCrAmt,0)) + sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) " & _
                        " 	   THEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) -  Sum(isnull(V1.TotalFeeRecvCrAmt,0)) - sum(isnull(V1.AdvanceReceive,0)) - Sum(isnull(V1.ReverseDueAmt,0)) ELSE 0 END  " & _
                        " AS OpeningDr,   " & _
                        " CASE WHEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) <=  Sum(isnull(V1.TotalFeeRecvCrAmt,0)) +  sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) " & _
                        " 	   THEN Sum(isnull(V1.TotalFeeRecvCrAmt,0)) + sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) - Sum(isnull(V1.DueAmt,0)) - Sum(isnull(V1.RefundAmt,0))  ELSE 0 END  " & _
                        " AS OpeningCr,    " & _
                        " CASE WHEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) + sum(isnull(V1.AmtDr,0)) >  Sum(isnull(V1.TotalFeeRecvCrAmt,0)) + sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) + sum(isnull(V1.AmtCr,0)) " & _
                        " 	   THEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) + sum(isnull(V1.AmtDr,0)) -  Sum(isnull(V1.TotalFeeRecvCrAmt,0)) - sum(isnull(V1.AdvanceReceive,0)) - Sum(isnull(V1.ReverseDueAmt,0)) - sum(isnull(V1.AmtCr,0))  ELSE 0 END  " & _
                        " AS OpeningNetDr,   " & _
                        " CASE WHEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0))  + sum(isnull(V1.AmtDr,0)) <=  Sum(isnull(V1.TotalFeeRecvCrAmt,0)) +  sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) + sum(isnull(V1.AmtCr,0)) " & _
                        " 	   THEN Sum(isnull(V1.TotalFeeRecvCrAmt,0)) + sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) + sum(isnull(V1.AmtCr,0)) - Sum(isnull(V1.DueAmt,0)) - Sum(isnull(V1.RefundAmt,0))  - sum(isnull(V1.AmtDr,0))  ELSE 0 END  " & _
                        " AS OpeningNetCr,    " & _
                        " sum(isnull(V1.AdvanceReceive,0)) AS OpeningAdvanceReceive, sum(isnull(V1.FeeReceiveAmt,0)) AS  OpeningFeeReceiveAmt, " & _
                        " sum(isnull(V1.AmtDr,0)) AS OpeningLedgerDr, sum(isnull(V1.AmtCr,0)) AS OpeningLedgerCr, " & _
                        " sum(isnull(V1.AmtDr,0)) - sum(isnull(V1.AmtCr,0)) AS OpeningBalanceLedger,   " & _
                        " Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) + sum(isnull(V1.AmtDr,0)) -  Sum(isnull(V1.TotalFeeRecvCrAmt,0)) - sum(isnull(V1.AdvanceReceive,0))  - Sum(isnull(V1.ReverseDueAmt,0)) - sum(isnull(V1.AmtCr,0)) AS OpeningNetBal,   " & _
                        " 0 AS DueAmt, 0 As ReverseDueAmt,  0 LineAmount, 0 AS LineDiscount, 0 AS BFAdvance,    " & _
                        " 0 AS AdjustmentAmount, 0 AS DiscountAmount, 0 AS TotalAdvanceAdjusted,    " & _
                        " 0 AS TotalFeeReceiveAdjusted, 0 As ScholarShipAmount, 0 As CounselingFeeAdjusted, " & _
                        " 0 AS TotalNetAmount, 0 As TotalFeeRecvCrAmt, 0 AS RefundAmt, 0 AS AdvanceAmt  ,   " & _
                        " 0 AS  CurrentDr, 0 AS CurrentCr,  " & _
                        " 0 AS  CurrentNetDr, 0 AS CurrentNetCr, " & _
                        " 0 AS CurrentAdvanceReceive, 0 As CurrentFeeReceiveAmt,  0 AS CurrentLedgerDr, 0 AS CurrentLedgerCr, 0 AS CurrentBalanceLedger,  " & _
                        " 0 AS CurrentNetBal   " & _
                        " FROM  ( " & _
                        " SELECT SFD.Site_Code,SFD.V_Date,SFD1.AdmissionDocId ,   " & _
                        " 0 AS AmtCr,0 AS AmtDr,0 AS AdvanceReceive,sum(SFD1.Amount)  AS DueAmt, 0 AS ReverseDueAmt,    " & _
                        " 0 AS LineAmount,0 AS LineDiscount,0 AS BFAdvance,0 AS AdjustmentAmount,   " & _
                        " 0 AS DiscountAmount ,0 AS TotalAdvanceAdjusted,0  AS TotalFeeReceiveAdjusted, 0 As ScholarShipAmount, 0 As CounselingFeeAdjusted, " & _
                        " 0 AS TotalNetAmount ,0 AS FeeReceiveAmt ,   " & _
                        " 0 AS TotalFeeRecvCrAmt ,0 AS RefundAmt   " & _
                        " FROM Sch_FeeDue SFD   " & _
                        " LEFT JOIN Sch_FeeDue1 SFD1 ON SFD.DocId=SFD1.DocId    " & _
                        " GROUP BY SFD.Site_Code,SFD1.AdmissionDocId,SFD.V_Date    " & _
                        " UNION ALL    " & _
                        " SELECT Rfd.Site_Code, Rfd.V_Date,Rfd.AdmissionDocId ,   " & _
                        " 0 AS AmtCr,0 AS AmtDr,0 AS AdvanceReceive, 0 AS DueAmt, Rfd.TotalAmount AS ReverseDueAmt, " & _
                        " 0 AS LineAmount,0 AS LineDiscount,0 AS BFAdvance,0 AS AdjustmentAmount,   " & _
                        " 0 AS DiscountAmount ,0 AS TotalAdvanceAdjusted,0  AS TotalFeeReceiveAdjusted, 0 As ScholarShipAmount, 0 As CounselingFeeAdjusted, " & _
                        " 0 AS TotalNetAmount ,0 AS FeeReceiveAmt ,  0 AS TotalFeeRecvCrAmt ,0 AS RefundAmt   " & _
                        " FROM Sch_ReverseFeeDue Rfd " & _
                        " UNION ALL " & _
                        " SELECT SFR.Site_Code,SFR.V_Date,Sfr.AdmissionDocId,   " & _
                        " 0 AS AmtCr,0 AS AmtDr,0 AS AdvanceReceive, 0 AS DueAmt, 0 As ReverseDueAmt,   " & _
                        " SFR.TotalLineAmount AS LineAmount,SFR.TotalLineDiscount AS LineDiscount,   " & _
                        " SFR.Advance AS BFAdvance, SFR.AdjustmentAmount AS AdjustmentAmount,   " & _
                        " SFR.DiscountAmount AS DiscountAmount ,SFR.TotalAdvanceAdjusted AS TotalAdvanceAdjusted,   " & _
                        " SFR.TotalFeeReceiveAdjusted  AS TotalFeeReceiveAdjusted, SFR.ScholarShipAmount, Sfr.CounselingFeeAdjusted, SFR.TotalNetAmount ,   " & _
                        " SFR.ReceiveAmount AS FeeReceiveAmt ,   " & _
                        " SFR.ReceiveAmount + SFR.DiscountAmount + SFR.TotalLineDiscount + SFR.AdjustmentAmount + SFR.ScholarShipAmount + Sfr.CounselingFeeAdjusted  AS TotalFeeRecvCrAmt ,   " & _
                        " 0 AS RefundAmt   " & _
                        " FROM Sch_FeeReceive SFR  " & _
                        " UNION ALL " & _
                        " SELECT SR.Site_Code ,SR.V_Date, SR.AdmissionDocId,   " & _
                        " 0 AS AmtCr,0 AS AmtDr,0 AS AdvanceReceive,0  AS DueAmt, 0 As ReverseDueAmt,    " & _
                        " 0 AS LineAmount,0 AS LineDiscount,0 AS BFAdvance,0 AS AdjustmentAmount,   " & _
                        " 0 AS DiscountAmount ,0 AS TotalAdvanceAdjusted,0  AS TotalFeeReceiveAdjusted, 0 As ScholarShipAmount, 0 As CounselingFeeAdjusted, " & _
                        " 0 AS TotalNetAmount ,0 AS FeeReceiveAmt ,0 AS TotalFeeRecvCrAmt ,   " & _
                        " SR.RefundAmount   AS RefundAmt   " & _
                        " FROM Sch_FeeRefund SR   " & _
                        " UNION ALL " & _
                        " SELECT VSAR.Site_Code,VSAR.V_Date,VSAR.AdmissionDocId ,   " & _
                        " 0 AS AmtCr,0 AS AmtDr, VSAR.ReceiveAmount AS AdvanceReceive,0 AS DueAmt, 0 As ReverseDueAmt,   " & _
                        " 0 AS LineAmount,0 AS LineDiscount,0 AS BFAdvance,0 AS AdjustmentAmount,   " & _
                        " 0 AS DiscountAmount ,0 AS TotalAdvanceAdjusted,0  AS TotalFeeReceiveAdjusted, 0 As ScholarShipAmount, 0 As CounselingFeeAdjusted, " & _
                        " 0 AS TotalNetAmount ,0 AS FeeReceiveAmt ,0 AS TotalFeeRecvCrAmt , 0 AS RefundAmt   " & _
                        " FROM ViewSch_AdvanceReceive VSAR   " & _
                        " UNION ALL " & _
                        " SELECT L.Site_Code,L.V_Date,VA.DocId AS AdmissionDocId,  L.AmtCr AS AmtCr, " & _
                        " L.AmtDr AS AmtDr,0 AS AdvanceReceive,0 AS DueAmt, 0 As ReverseDueAmt,  0 AS LineAmount,0 AS LineDiscount, " & _
                        " 0 AS BFAdvance,0 AS AdjustmentAmount,  0 AS DiscountAmount , " & _
                        " 0 AS TotalAdvanceAdjusted,0  AS TotalFeeReceiveAdjusted, 0 As ScholarShipAmount, 0 As CounselingFeeAdjusted, 0 AS TotalNetAmount , " & _
                        " 0 AS FeeReceiveAmt ,0 AS TotalFeeRecvCrAmt ,0   AS RefundAmt    " & _
                        " FROM Sch_Student SS   " & _
                        " LEFT JOIN Ledger L ON L.SubCode=SS.SubCode    " & _
                        " LEFT JOIN Voucher_Type VT ON VT.V_Type=L.V_Type    " & _
                        " LEFT JOIN ViewSch_Admission VA ON VA.Student=SS.SubCode    " & _
                        " WHERE VA.DocId IS NOT NULL AND VT.NCat     " & _
                        " NOT IN (" & bStrNCatExceptLedger & ")) As V1 " & _
                        " WHERE V1.AdmissionDocId IS NOT NULL AND V1.V_Date < " & AgL.ConvertDate(bFromDateStr) & "   " & _
                        " GROUP BY V1.Site_Code,V1.AdmissionDocId " & _
                        " UNION ALL   " & _
                        " SELECT V1.Site_Code, V1.AdmissionDocId,    " & _
                        " 0 AS OpeningDr, 0 AS OpeningCr,  " & _
                        " 0 AS OpeningNetDr, 0 AS OpeningNetCr,  " & _
                        " 0 AS OpeningAdvanceReceive, 0 As OpeningFeeReceiveAmt, 0 AS OpeningLedgerDr, 0 AS OpeningLedgerCr, 0 AS OpeningBalanceLedger,  " & _
                        " 0 AS OpeningNetBal,  Sum(isnull(V1.DueAmt,0)) AS DueAmt, Sum(isnull(V1.ReverseDueAmt,0)) AS ReverseDueAmt,   " & _
                        " Sum(isnull(V1.LineAmount,0))  AS TotalFeeRecvCrAmt,   " & _
                        " Sum(isnull(V1.LineDiscount,0))  AS LineDiscount,   " & _
                        " Sum(isnull(V1.BFAdvance,0))  AS BFAdvance,   " & _
                        " Sum(isnull(V1.AdjustmentAmount,0))  AS AdjustmentAmount,   " & _
                        " Sum(isnull(V1.DiscountAmount,0))  AS DiscountAmount,   " & _
                        " Sum(isnull(V1.TotalAdvanceAdjusted,0))  AS TotalAdvanceAdjusted,   " & _
                        " Sum(isnull(V1.TotalFeeReceiveAdjusted,0))  AS TotalFeeReceiveAdjusted,  " & _
                        " Sum(isnull(V1.ScholarShipAmount,0))  AS ScholarShipAmount,  " & _
                        " Sum(isnull(V1.CounselingFeeAdjusted,0))  AS CounselingFeeAdjusted,  " & _
                        " Sum(isnull(V1.TotalNetAmount,0))  AS TotalNetAmount,   " & _
                        " Sum(isnull(V1.TotalFeeRecvCrAmt,0))  AS TotalFeeRecvCrAmt,   " & _
                        " Sum(isnull(V1.RefundAmt,0))  AS RefundAmt, " & _
                        " Sum(isnull(V1.AdvanceReceive,0))  AS AdvanceAmt,    " & _
                        " CASE WHEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) >  Sum(isnull(V1.TotalFeeRecvCrAmt,0))  + sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) " & _
                        " 	 THEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) -  Sum(isnull(V1.TotalFeeRecvCrAmt,0))  - sum(isnull(V1.AdvanceReceive,0)) - Sum(isnull(V1.ReverseDueAmt,0)) ELSE 0 END  " & _
                        " AS CurrentDr,   " & _
                        " CASE WHEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) <=  Sum(isnull(V1.TotalFeeRecvCrAmt,0))  + sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) " & _
                        " 	 THEN Sum(isnull(V1.TotalFeeRecvCrAmt,0))  + sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) - Sum(isnull(V1.DueAmt,0)) - Sum(isnull(V1.RefundAmt,0))  ELSE 0 END  " & _
                        " AS CurrentCr,    " & _
                        " CASE WHEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) + sum(isnull(V1.AmtDr,0)) >  Sum(isnull(V1.TotalFeeRecvCrAmt,0)) + sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) + sum(isnull(V1.AmtCr,0)) " & _
                        " 	 THEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) + sum(isnull(V1.AmtDr,0)) -  Sum(isnull(V1.TotalFeeRecvCrAmt,0)) - sum(isnull(V1.AdvanceReceive,0)) - Sum(isnull(V1.ReverseDueAmt,0)) - sum(isnull(V1.AmtCr,0))  ELSE 0 END  " & _
                        " AS CurrentNetDr,   " & _
                        " CASE WHEN Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0))  + sum(isnull(V1.AmtDr,0)) <=  Sum(isnull(V1.TotalFeeRecvCrAmt,0)) +  sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) + sum(isnull(V1.AmtCr,0)) " & _
                        " 	 THEN Sum(isnull(V1.TotalFeeRecvCrAmt,0)) + sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) + sum(isnull(V1.AmtCr,0)) - Sum(isnull(V1.DueAmt,0)) - Sum(isnull(V1.RefundAmt,0))  - sum(isnull(V1.AmtDr,0)) ELSE 0 END  " & _
                        " AS CurrentNetCr,    " & _
                        " sum(isnull(V1.AdvanceReceive,0)) AS CurrentAdvanceReceive, sum(isnull(V1.FeeReceiveAmt,0)) AS CurrentFeeReceiveAmt,  " & _
                        " sum(isnull(V1.AmtDr,0)) AS CurrentLedgerDr, sum(isnull(V1.AmtCr,0)) AS CurrentLedgerCr, " & _
                        " sum(isnull(V1.AmtDr,0)) - sum(isnull(V1.AmtCr,0)) AS CurrentBalanceLedger,   " & _
                        " Sum(isnull(V1.DueAmt,0)) + Sum(isnull(V1.RefundAmt,0)) -  Sum(isnull(V1.TotalFeeRecvCrAmt,0)) - sum(isnull(V1.AdvanceReceive,0)) + Sum(isnull(V1.ReverseDueAmt,0)) + sum(isnull(V1.AmtDr,0)) - sum(isnull(V1.AmtCr,0)) AS CurrentNetBal   " & _
                        " FROM  (   " & _
                        " SELECT SFD.Site_Code,SFD.V_Date,SFD1.AdmissionDocId ,   " & _
                        " 0 AS AmtCr,0 AS AmtDr,0 AS AdvanceReceive,sum(SFD1.Amount)  AS DueAmt, 0 AS ReverseDueAmt,    " & _
                        " 0 AS LineAmount,0 AS LineDiscount,0 AS BFAdvance,0 AS AdjustmentAmount,   " & _
                        " 0 AS DiscountAmount ,0 AS TotalAdvanceAdjusted,0  AS TotalFeeReceiveAdjusted, 0 As ScholarShipAmount, 0 As CounselingFeeAdjusted, " & _
                        " 0 AS TotalNetAmount ,0 AS FeeReceiveAmt ,  0 AS TotalFeeRecvCrAmt ,0 AS RefundAmt   " & _
                        " FROM Sch_FeeDue SFD  " & _
                        " LEFT JOIN Sch_FeeDue1 SFD1 ON SFD.DocId=SFD1.DocId    " & _
                        " GROUP BY SFD.Site_Code,SFD1.AdmissionDocId,SFD.V_Date    " & _
                        " UNION ALL " & _
                        " SELECT Rfd.Site_Code, Rfd.V_Date,Rfd.AdmissionDocId ,   " & _
                        " 0 AS AmtCr,0 AS AmtDr,0 AS AdvanceReceive, 0 AS DueAmt, Rfd.TotalAmount AS ReverseDueAmt, " & _
                        " 0 AS LineAmount,0 AS LineDiscount,0 AS BFAdvance,0 AS AdjustmentAmount,   " & _
                        " 0 AS DiscountAmount ,0 AS TotalAdvanceAdjusted, 0  AS TotalFeeReceiveAdjusted, 0 As ScholarShipAmount, 0 As CounselingFeeAdjusted, " & _
                        " 0 AS TotalNetAmount ,0 AS FeeReceiveAmt ,  0 AS TotalFeeRecvCrAmt ,0 AS RefundAmt   " & _
                        " FROM Sch_ReverseFeeDue Rfd " & _
                        " UNION ALL " & _
                        " SELECT SFR.Site_Code,SFR.V_Date,Sfr.AdmissionDocId,   " & _
                        " 0 AS AmtCr,0 AS AmtDr,0 AS AdvanceReceive, 0 AS DueAmt, 0 As ReverseDueAmt, " & _
                        " SFR.TotalLineAmount AS LineAmount,SFR.TotalLineDiscount AS LineDiscount,   " & _
                        " SFR.Advance AS BFAdvance,SFR.AdjustmentAmount AS AdjustmentAmount,   " & _
                        " SFR.DiscountAmount AS DiscountAmount ,SFR.TotalAdvanceAdjusted AS TotalAdvanceAdjusted,   " & _
                        " SFR.TotalFeeReceiveAdjusted  AS TotalFeeReceiveAdjusted, SFR.ScholarShipAmount, Sfr.CounselingFeeAdjusted, SFR.TotalNetAmount ,   " & _
                        " SFR.ReceiveAmount AS FeeReceiveAmt,  " & _
                        " SFR.ReceiveAmount + SFR.DiscountAmount+ SFR.TotalLineDiscount + SFR.AdjustmentAmount + SFR.ScholarShipAmount + Sfr.CounselingFeeAdjusted AS TotalFeeRecvCrAmt ,   " & _
                        " 0 AS RefundAmt " & _
                        " FROM Sch_FeeReceive SFR   " & _
                        " UNION ALL  " & _
                        " SELECT SR.Site_Code ,SR.V_Date, Sr.AdmissionDocId,   " & _
                        " 0 AS AmtCr,0 AS AmtDr,0 AS AdvanceReceive,0  AS DueAmt, 0 As ReverseDueAmt, " & _
                        " 0 AS LineAmount,0 AS LineDiscount,0 AS BFAdvance,0 AS AdjustmentAmount,   " & _
                        " 0 AS DiscountAmount ,0 AS TotalAdvanceAdjusted,0  AS TotalFeeReceiveAdjusted, 0 As ScholarShipAmount, 0 As CounselingFeeAdjusted,   " & _
                        " 0 AS TotalNetAmount ,0 AS FeeReceiveAmt ,   " & _
                        " 0 AS TotalFeeRecvCrAmt ,SR.RefundAmount AS RefundAmt   " & _
                        " FROM Sch_FeeRefund SR   " & _
                        " UNION ALL " & _
                        " SELECT VSAR.Site_Code,VSAR.V_Date,VSAR.AdmissionDocId ,   " & _
                        " 0 AS AmtCr,0 AS AmtDr, " & _
                        " VSAR.ReceiveAmount AS AdvanceReceive,0 AS DueAmt, 0 As ReverseDueAmt, 0 AS LineAmount, " & _
                        " 0 AS LineDiscount,0 AS BFAdvance,0 AS AdjustmentAmount,   " & _
                        " 0 AS DiscountAmount ,0 AS TotalAdvanceAdjusted,0  AS TotalFeeReceiveAdjusted, 0 As ScholarShipAmount, 0 As CounselingFeeAdjusted,  " & _
                        " 0 AS TotalNetAmount ,0 AS FeeReceiveAmt ,0 AS TotalFeeRecvCrAmt , " & _
                        " 0 AS RefundAmt " & _
                        " FROM ViewSch_AdvanceReceive VSAR   " & _
                        " UNION ALL " & _
                        " SELECT L.Site_Code,L.V_Date,VA.DocId AS AdmissionDocId,  L.AmtCr AS AmtCr, " & _
                        " L.AmtDr AS AmtDr,0 AS AdvanceReceive,0 AS DueAmt, 0 As ReverseDueAmt, 0 AS LineAmount,0 AS LineDiscount, " & _
                        " 0 AS BFAdvance,0 AS AdjustmentAmount,  0 AS DiscountAmount , " & _
                        " 0 AS TotalAdvanceAdjusted,0  AS TotalFeeReceiveAdjusted, 0 as ScholarShipAmount, 0 as CounselingFeeAdjusted, 0 AS TotalNetAmount , " & _
                        " 0 AS FeeReceiveAmt ,0 AS TotalFeeRecvCrAmt ,0   AS RefundAmt    " & _
                        " FROM Sch_Student SS " & _
                        " LEFT JOIN Ledger L ON L.SubCode=SS.SubCode    " & _
                        " LEFT JOIN Voucher_Type VT ON VT.V_Type=L.V_Type    " & _
                        " LEFT JOIN ViewSch_Admission VA ON VA.Student=SS.SubCode    " & _
                        " WHERE VA.DocId IS NOT NULL AND VT.NCat     " & _
                        " NOT IN (" & bStrNCatExceptLedger & ")) AS V1   " & _
                        " WHERE V1.AdmissionDocId IS NOT NULL    " & _
                        " AND V1.V_Date BETWEEN " & AgL.ConvertDate(bFromDateStr) & " AND " & AgL.ConvertDate(bToDateStr) & "   " & _
                        " GROUP BY V1.Site_Code,V1.AdmissionDocId  ) AS VMain   " & _
                        " GROUP BY VMain.Site_Code,VMain.AdmissionDocId  "


        Catch ex As Exception
            bViewStr = ""
            MsgBox(ex.Message)
        Finally
            FunGetFeeDetailStr = bViewStr
        End Try
    End Function

    Private Function FunGetFeeHeadDetailStr(ByVal bFromDateStr As String, ByVal bToDateStr As String) As String
        Dim bViewStr$ = ""
        Try

            bViewStr = "SELECT " & _
                        " VHead.Site_Code,  VHead.AdmissionDocId, VHead.Fee, Max(Sg.Name) AS FeeHead , " & _
                        " sum(VHead.OpeningDueAmt) AS OpeningDueAmt,  " & _
                        " sum(VHead.OpeningReverseDueAmt) AS OpeningReverseDueAmt,  " & _
                        " sum(VHead.OpeningReceiveAmt) AS OpeningReceiveAmt,  " & _
                        " sum(VHead.OpeningDiscount) AS OpeningDiscount,  " & _
                        " sum(VHead.OpeningRefundAmt) AS OpeningRefundAmt,  " & _
                        " sum(VHead.OpeningBalance) AS OpeningBalance,  " & _
                        " sum(VHead.CurrentDueAmt) AS CurrentDueAmt,  " & _
                        " sum(VHead.CurrentReverseDueAmt) AS CurrentReverseDueAmt,  " & _
                        " sum(VHead.CurrentReceiveAmt) AS CurrentReceiveAmt,  " & _
                        " sum(VHead.CurrentDiscount) AS CurrentDiscount,  " & _
                        " sum(VHead.CurrentRefundAmt) AS CurrentRefundAmt,  " & _
                        " sum(VHead.CurrentBalance) AS CurrentBalance, " & _
                        " sum(VHead.OpeningDueAmt) + sum(VHead.CurrentDueAmt) AS TillDateDueAmt, " & _
                        " sum(VHead.OpeningReverseDueAmt) + sum(VHead.CurrentReverseDueAmt) AS TillDateReverseDueAmt, " & _
                        " sum(VHead.OpeningReceiveAmt) + sum(VHead.CurrentReceiveAmt) AS TillDateReceiveAmt, " & _
                        " sum(VHead.OpeningDiscount) + sum(VHead.CurrentDiscount) AS TillDateDiscount, " & _
                        " sum(VHead.OpeningRefundAmt) + sum(VHead.CurrentRefundAmt) AS TillDateRefundAmt, " & _
                        " sum(VHead.OpeningBalance) + sum(VHead.CurrentBalance) AS TillDateBalance " & _
                        " FROM  " & _
                        " (SELECT V1.Site_Code,  V1.AdmissionDocId, V1.Fee,  " & _
                        " Sum(V1.DueAmt) AS OpeningDueAmt,  " & _
                        " Sum(V1.ReverseDueAmt) AS OpeningReverseDueAmt,  " & _
                        " Sum(V1.ReceiveAmt) AS OpeningReceiveAmt,  " & _
                        " Sum(V1.Discount) AS OpeningDiscount,  " & _
                        " Sum(V1.RefundAmt) AS OpeningRefundAmt, " & _
                        " Sum(V1.DueAmt) - (Sum(V1.ReverseDueAmt) + Sum(V1.ReceiveAmt) + Sum(V1.Discount)) + Sum(V1.RefundAmt) AS OpeningBalance, " & _
                        " 0 AS CurrentDueAmt,  " & _
                        " 0 AS CurrentReverseDueAmt,  " & _
                        " 0 AS CurrentReceiveAmt,  " & _
                        " 0 AS CurrentDiscount,  " & _
                        " 0 AS CurrentRefundAmt, " & _
                        " 0 AS CurrentBalance " & _
                        " FROM  " & _
                        " ( " & _
                        " SELECT SFD.Site_Code,SFD.V_Date,SFD1.Fee ,SFD1.AdmissionDocId ,   " & _
                        " SFD1.Amount AS DueAmt, 0 As ReverseDueAmt, 0 AS ReceiveAmt, 0 AS Discount,0 AS RefundAmt " & _
                        " FROM Sch_FeeDue1 SFD1 " & _
                        " LEFT JOIN Sch_FeeDue SFD ON SFD.DocId=SFD1.DocId  " & _
                        " UNION ALL  " & _
                        " ( " & _
                        " SELECT Rfd.Site_Code, Rfd.V_Date, Fd1.Fee, Rfd.AdmissionDocId, " & _
                        " 0 AS DueAmt, Rfd1.Amount AS ReverseDueAmt,0 AS ReceiveAmt, 0 AS Discount,0 AS RefundAmt " & _
                        " FROM Sch_ReverseFeeDue Rfd " & _
                        " LEFT JOIN Sch_ReverseFeeDue1 Rfd1 ON Rfd1.DocId = Rfd.DocId  " & _
                        " LEFT JOIN Sch_FeeDue1 Fd1 ON Fd1.Code = Rfd1.FeeDue1 AND Fd1.AdmissionDocId = Rfd.AdmissionDocId  " & _
                        " ) " & _
                        " UNION ALL  " & _
                        " ( " & _
                        " SELECT SFR.Site_Code,SFR.V_Date,SFD1.Fee ,SFR.AdmissionDocId,0 AS DueAmt, 0 As ReverseDueAmt,  " & _
                        " SFR1.NetAmount AS ReceiveAmt, SFr1.Discount AS Discount ,0 AS RefundAmt " & _
                        " FROM Sch_FeeReceive1 SFR1 " & _
                        " LEFT JOIN Sch_FeeReceive SFR ON SFR.DocId=SFR1.DocId  " & _
                        " LEFT JOIN Sch_FeeDue1 SFD1 ON SFD1.Code=SFR1.FeeDue1  " & _
                        " ) " & _
                        " UNION ALL  " & _
                        " ( " & _
                        " SELECT SR.Site_Code ,SR.V_Date, SFD1.Fee ,Sr.AdmissionDocId,0 AS DueAmt, 0 As ReverseDueAmt, " & _
                        " 0 AS ReceiveAmt, 0 AS Discount,SR1.NetAmount  AS RefundAmt " & _
                        " FROM Sch_FeeRefund1 SR1 " & _
                        " LEFT JOIN Sch_FeeRefund SR ON SR.DocId=SR1.DocId  " & _
                        " LEFT JOIN Sch_FeeReceive1 SFR1 ON SFR1.Code=SR1.FeeReceive1  " & _
                        " LEFT JOIN Sch_FeeDue1 SFD1 ON SFD1.Code=SFR1.FeeDue1  " & _
                        " ) " & _
                        " ) V1 " & _
                        " WHERE V1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " " & _
                        " GROUP BY V1.Site_Code, V1.AdmissionDocId, V1.Fee " & _
                        " UNION ALL " & _
                        " SELECT V1.Site_Code,  V1.AdmissionDocId, V1.Fee,  " & _
                        " 0 AS OpeningDueAmt,  " & _
                        " 0 AS OpeningReverseDueAmt,  " & _
                        " 0 AS OpeningReceiveAmt,  " & _
                        " 0 AS OpeningDiscount,  " & _
                        " 0 AS OpeningRefundAmt, " & _
                        " 0 AS OpeningBalance, " & _
                        " Sum(V1.DueAmt) AS CurrentDueAmt,  " & _
                        " Sum(V1.ReverseDueAmt) AS CurrentReverseDueAmt,  " & _
                        " Sum(V1.ReceiveAmt) AS CurrentReceiveAmt,  " & _
                        " Sum(V1.Discount) AS CurrentDiscount,  " & _
                        " Sum(V1.RefundAmt) AS CurrentRefundAmt, " & _
                        " Sum(V1.DueAmt) - (Sum(V1.ReverseDueAmt) + Sum(V1.ReceiveAmt) + Sum(V1.Discount)) + Sum(V1.RefundAmt) AS CurrentBalance " & _
                        " FROM  " & _
                        " ( " & _
                        " SELECT SFD.Site_Code,SFD.V_Date,SFD1.Fee ,SFD1.AdmissionDocId ,   " & _
                        " SFD1.Amount AS DueAmt, 0 As ReverseDueAmt,0 AS ReceiveAmt, 0 AS Discount,0 AS RefundAmt " & _
                        " FROM Sch_FeeDue1 SFD1 " & _
                        " LEFT JOIN Sch_FeeDue SFD ON SFD.DocId=SFD1.DocId  " & _
                        " UNION ALL  " & _
                        " ( " & _
                        " SELECT Rfd.Site_Code, Rfd.V_Date, Fd1.Fee, Rfd.AdmissionDocId, " & _
                        " 0 AS DueAmt, Rfd1.Amount AS ReverseDueAmt,0 AS ReceiveAmt, 0 AS Discount,0 AS RefundAmt " & _
                        " FROM Sch_ReverseFeeDue Rfd " & _
                        " LEFT JOIN Sch_ReverseFeeDue1 Rfd1 ON Rfd1.DocId = Rfd.DocId  " & _
                        " LEFT JOIN Sch_FeeDue1 Fd1 ON Fd1.Code = Rfd1.FeeDue1 AND Fd1.AdmissionDocId = Rfd.AdmissionDocId  " & _
                        " ) " & _
                        " UNION ALL  " & _
                        " ( " & _
                        " SELECT SFR.Site_Code,SFR.V_Date,SFD1.Fee ,SFR.AdmissionDocId,0 AS DueAmt, 0 As ReverseDueAmt,  " & _
                        " SFR1.NetAmount AS ReceiveAmt, SFr1.Discount AS Discount ,0 AS RefundAmt " & _
                        " FROM Sch_FeeReceive1 SFR1 " & _
                        " LEFT JOIN Sch_FeeReceive SFR ON SFR.DocId=SFR1.DocId  " & _
                        " LEFT JOIN Sch_FeeDue1 SFD1 ON SFD1.Code=SFR1.FeeDue1  " & _
                        " ) " & _
                        " UNION ALL  " & _
                        " ( " & _
                        " SELECT SR.Site_Code ,SR.V_Date, SFD1.Fee ,SR.AdmissionDocId,0 AS DueAmt, 0 As ReverseDueAmt, " & _
                        " 0 AS ReceiveAmt, 0 AS Discount,SR1.NetAmount  AS RefundAmt " & _
                        " FROM Sch_FeeRefund1 SR1 " & _
                        " LEFT JOIN Sch_FeeRefund SR ON SR.DocId=SR1.DocId  " & _
                        " LEFT JOIN Sch_FeeReceive1 SFR1 ON SFR1.Code=SR1.FeeReceive1  " & _
                        " LEFT JOIN Sch_FeeDue1 SFD1 ON SFD1.Code=SFR1.FeeDue1  " & _
                        " ) " & _
                        " ) V1 " & _
                        " WHERE V1.V_Date BETWEEN " & AgL.ConvertDate(bFromDateStr) & " AND " & AgL.ConvertDate(bToDateStr) & " " & _
                        " GROUP BY V1.Site_Code, V1.AdmissionDocId, V1.Fee) AS VHead " & _
                        " LEFT JOIN SubGroup Sg ON VHead.Fee = Sg.SubCode " & _
                        " GROUP BY VHead.Site_Code,  VHead.AdmissionDocId, VHead.Fee "

        Catch ex As Exception
            bViewStr = ""
            MsgBox(ex.Message)
        Finally
            FunGetFeeHeadDetailStr = bViewStr
        End Try
    End Function
End Class
