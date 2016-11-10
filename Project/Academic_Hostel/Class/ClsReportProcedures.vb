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

#Region "Reports Constant"
    Private Const RoomAllotmentRegister As String = "RoomAllotmentRegister"
    Private Const RoomLeftRegister As String = "RoomLeftRegister"
    Private Const RoomTransferRegister As String = "RoomTransferRegister"
    Private Const AdvanceChargeRegister As String = "AdvanceChargeRegister"
    Private Const ChargeDueRegister As String = "ChargeDueRegister"
    Private Const ChargeReceiveRegister As String = "ChargeReceiveRegister"
    Private Const ChargeRefundRegister As String = "ChargeRefundRegister"
    Private Const RoomStatusReport As String = "RoomStatusReport"
    Private Const MemberWiseOutstandingSummary As String = "MemberWiseOutstandingSummary"
    Private Const MemberRegister As String = "MemberRegister"
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
    Dim mHelpStudentQry$ = "Select Convert(BIT,0) As [Select], Subcode as code,DispName AS [Student Name] FROM	ViewSch_Student Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "
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
    '******* Code By Satyam on  25/10/2010
    Dim mHelpHostelMemberQry$ = " SELECT Convert(BIT,0) As [Select], A.SubCode AS Code, Max(Sg.Name) AS [Member Name] " & _
                                " FROM Ht_RoomAllotment A WITH (NoLock) " & _
                                " LEFT JOIN SubGroup Sg ON Sg.SubCode = A.SubCode " & _
                                " Where " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " " & _
                                " GROUP BY A.SubCode "

    Dim mHelpHostelQry$ = " Select Convert(BIT,0) As [Select], Code,Description AS [Hostel Name],ContactPerson AS [Contact Person] FROM	Ht_Hostel Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpHostelBuildingQry$ = " Select Convert(BIT,0) As [Select], Code,Description AS [Building Name],Nature,ContactPerson AS [Contact Person] FROM Ht_Building Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "
    Dim mHelpHostelBuildingFloorQry$ = " Select Convert(BIT,0) As [Select],HBF.Code,HB.ManualCode+'\'+HF.Description AS [Buiding Floor],TotalRooms FROM Ht_BuildingFloor HBF " & _
                                         " LEFT JOIN Ht_Building HB ON HB.Code=HBF.Building " & _
                                         " LEFT JOIN Ht_Floor HF ON HF.Code =HBF.Floor " & _
                                         " Where " & AgL.PubSiteCondition("HB.Site_Code", AgL.PubSiteCode) & " "

    Dim mHelpHostelRoomQry$ = " Select Convert(BIT,0) As [Select], HR.Code,	HR.Description AS Room, HB.ManualCode+'\'+HF.Description AS [Buiding Floor], HRT.Description AS [Room Type], HR.TotalBed As [Total Bed]" & _
                                    " FROM Ht_Room HR  " & _
                                    " LEFT JOIN Ht_RoomType HRT ON HRT.Code=HR.RoomType " & _
                                    " LEFT JOIN Ht_BuildingFloor HBF ON HBF.Code =HR.BuildingFloor " & _
                                    " LEFT JOIN Ht_Building HB ON HB.Code=HBF.Building  " & _
                                    " LEFT JOIN Ht_Floor HF ON HF.Code =HBF.Floor  " & _
                                    " Where " & AgL.PubSiteCondition("HB.Site_Code", AgL.PubSiteCode) & " "

    Dim mHelpAdvanceChargeQry$ = "Select Convert(BIT,0) As [Select], HCR.DocId As Code," & AgL.V_No_Field("HCR.DocId") & "  as [Voucher No]  FROM Ht_ChargeReceive HCR " & _
                                    " Where " & AgL.PubSiteCondition("HCR.Site_Code", AgL.PubSiteCode) & " "


    'Code By Satyam on date 8-11-10

    Dim mHelpAdvanceChargeVTypeQry$ = " Select Convert(BIT,0) As [Select], Vt.V_Type As Code, Vt.Description As Name, NCat From Voucher_Type Vt " & _
                                        " Where Vt.NCat In (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceReceive) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeAdvanceOpening) & ")"


    Dim mHelpReceiveVoucherNoQry$ = "Select Convert(BIT,0) As [Select], HCR.DocId As Code," & AgL.V_No_Field("HCR.DocId") & "  as [Voucher No]  FROM Ht_ChargeReceive HCR " & _
                                " Where " & AgL.PubSiteCondition("HCR.Site_Code", AgL.PubSiteCode) & " "

    Dim mHelpRefundVoucherNoQry$ = "Select Convert(BIT,0) As [Select], HCR.DocId As Code," & AgL.V_No_Field("HCR.DocId") & "  as [Voucher No]  FROM Ht_ChargeRefund HCR " & _
                            " Where " & AgL.PubSiteCondition("HCR.Site_Code", AgL.PubSiteCode) & " "

    Dim mHelpChargeDueVoucherNoQry$ = "Select Convert(BIT,0) As [Select], HCR.DocId As Code," & AgL.V_No_Field("HCR.DocId") & "  as [Voucher No]  FROM Ht_ChargeDue HCR " & _
                                " Where " & AgL.PubSiteCondition("HCR.Site_Code", AgL.PubSiteCode) & " "


    'End Code



#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", mQry1$ = "", RepName$ = "", RepTitle$ = ""

#Region "Initializing Grid"

    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName

                Case RoomAllotmentRegister, RoomLeftRegister
                    StrArr1 = New String() {"All", "Male", "Female"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Gender", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpHostelQry$, "Hostel")
                    ObjRFG.CreateHelpGrid(mHelpHostelBuildingQry$, "Building")
                    ObjRFG.CreateHelpGrid(mHelpHostelBuildingFloorQry$, "Building\Floor")
                    ObjRFG.CreateHelpGrid(mHelpHostelRoomQry$, "Room")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpHostelMemberQry$, "Hostel Member")

                Case RoomTransferRegister
                    StrArr1 = New String() {"All", "Male", "Female"}
                    StrArr2 = New String() {"No", "Yes"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Gender", StrArr1, , "With Charge Detail", StrArr2)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpHostelQry$, "Hostel")
                    ObjRFG.CreateHelpGrid(mHelpHostelBuildingQry$, "Building")
                    ObjRFG.CreateHelpGrid(mHelpHostelBuildingFloorQry$, "Building\Floor")
                    ObjRFG.CreateHelpGrid(mHelpHostelRoomQry$, "Room")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpHostelMemberQry$, "Hostel Member")

                Case AdvanceChargeRegister
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpAdvanceChargeVTypeQry$, "Voucher Type")
                    ObjRFG.CreateHelpGrid(mHelpHostelMemberQry$, "Hostel Member")

                Case ChargeReceiveRegister
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpHostelMemberQry$, "Hostel Member")
                    ObjRFG.CreateHelpGrid(mHelpReceiveVoucherNoQry$, "Receipt Voucher No.")

                Case ChargeRefundRegister
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpHostelMemberQry$, "Hostel Member")
                    ObjRFG.CreateHelpGrid(mHelpRefundVoucherNoQry$, "Receipt Voucher No.")

                Case RoomStatusReport
                    StrArr1 = New String() {"All", "Male", "Female"}
                    Call ObjRFG.Ini_Grp("As On Date", AgL.PubLoginDate, , , "Gender", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpHostelQry$, "Hostel")
                    ObjRFG.CreateHelpGrid(mHelpHostelBuildingQry$, "Building")
                    ObjRFG.CreateHelpGrid(mHelpHostelBuildingFloorQry$, "Building\Floor")
                    ObjRFG.CreateHelpGrid(mHelpHostelRoomQry$, "Room")

                Case ChargeDueRegister
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpHostelMemberQry$, "Hostel Member")

                Case MemberWiseOutStandingSummary
                    StrArr1 = New String() {"Both", "Student", "Employee"}
                    Call ObjRFG.Ini_Grp("From Date", AgL.PubStartDate, "To Date", AgL.PubLoginDate, "Member Type", StrArr1)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpCategaryQry$, "Category")
                    ObjRFG.CreateHelpGrid(mHelpHostelMemberQry$, "Hostel Member")


                Case MemberRegister
                    StrArr1 = New String() {"All", ClsMain.MemberType.Student, ClsMain.MemberType.Employee}
                    StrArr2 = New String() {"All", "Male", "Female"}
                    StrArr3 = New String() {"No", "Yes", "All"}
                    Call ObjRFG.Ini_Grp(, , , , "Member Type", StrArr1, , "Gender", StrArr2, , "Left Member", StrArr3)
                    ObjRFG.CreateHelpGrid(mHelpSiteQry$, "Site")
                    ObjRFG.CreateHelpGrid(mHelpSemesterQry, "Current Semester")
                    ObjRFG.CreateHelpGrid(mHelpHostelQry$, "Hostel")
                    ObjRFG.CreateHelpGrid(mHelpHostelBuildingQry$, "Building")
                    ObjRFG.CreateHelpGrid(mHelpHostelBuildingFloorQry$, "Building\Floor")
                    ObjRFG.CreateHelpGrid(mHelpHostelRoomQry$, "Room")
                    ObjRFG.CreateHelpGrid(mHelpHostelMemberQry$, "Hostel Member")

            End Select
            Call ObjRFG.Arrange_Grid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

#End Region


    Private Sub ObjRepFormGlobal_ProcessReport() Handles ObjRFG.ProcessReport
        Select Case mGRepFormName

            Case RoomAllotmentRegister
                ProcRoomAllotmentRegister()

            Case RoomLeftRegister
                ProcRoomLeftRegister()

            Case RoomTransferRegister
                ProcRoomTransferRegister()

            Case AdvanceChargeRegister
                ProcAdvanceChargeRegister()

            Case ChargeDueRegister
                ProcChargeDueRegister()

            Case ChargeReceiveRegister
                ProcChargeReceiveRegister()

            Case ChargeRefundRegister
                ProcChargeRefundRegister()

            Case RoomStatusReport
                ProcRoomStatusReport()

            Case MemberWiseOutStandingSummary
                ProcMemberWiseOutStandingSummary()

            Case MemberRegister
                ProcMemberRegister()
        End Select
    End Sub

#Region "Room Left Register"

    Private Sub ProcRoomLeftRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = " "

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            mCondStr = " where HRL.LeftDate Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "All") Then
                mCondStr = mCondStr
            Else

                mCondStr = mCondStr & " And VHSG.Sex = '" & ObjRFG.ParameterCmbo1_Value & "' "
            End If

            If ObjRFG.GetWhereCondition("HRA.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("HRA.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRA.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRA.Site_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HB.Hostel", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HBF.Building", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HR.BuildingFloor", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRL.Room ", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHSG.Category", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRTR.SubCode", 6)

            mQry = " SELECT HRL.AllotmentDocId, HRL.Room, HRL.LeftDate, HRL.LeftRemark,HRL.BalanceAsOnLeftDate," & AgL.V_No_Field("HRA.DocId") & "  as DocID_Print, HRA.Div_Code, HRA.Site_Code, Si.Name AS Site_Name, HRA.V_Date, HRA.V_Type, HRA.V_Prefix, HRA.V_No, HRA.Remark , " & _
                    " HR.Description AS RoomDesc, HB.ManualCode+'\'+HF.Description AS [Buiding Floor], HB.ManualCode+'\'+HF.Description+'\'+HR.Description AS [Buiding Floor Room], HH.Description as Hostel, " & _
                    " HRTR.SubCode, VHSG.MemberType, VHSG.ManualCode, VHSG.Name, VHSG.DispName, VHSG.Sex, VHSG.BloodGroup, VHSG.ReligionDesc, " & _
                    " VHSG.Category, Sc.ManualCode As CategoryManualCode,VHSG.CategoryDesc, VSG.FName AS Father " & _
                    " FROM ViewHt_RoomLeft HRL " & _
                    " LEFT JOIN Ht_RoomAllotment HRA ON HRA.DocId =HRL.AllotmentDocId " & _
                    " LEFT JOIN Ht_RoomTransfer HRTR ON HRTR.AllotmentDocId=HRA.DocId AND HRTR.AllotmentType='" & AllotmentType_Allotment & "' " & _
                    " LEFT JOIN Ht_Room HR ON HR.Code=HRL.Room   " & _
                    " LEFT JOIN Ht_BuildingFloor HBF ON HBF.Code =HR.BuildingFloor " & _
                    " LEFT JOIN Ht_Building HB ON HB.Code=HBF.Building  " & _
                    " LEFT JOIN Ht_Floor HF ON HF.Code =HBF.Floor " & _
                    " LEFT JOIN Ht_Hostel HH ON HH.Code=HB.Hostel " & _
                    " LEFT JOIN ViewHt_SubGroup VHSG ON VHSG.SubCode =HRTR.SubCode  " & _
                    " LEFT JOIN SiteMast SI ON Si.Code =HRA.Site_Code " & _
                    " LEFT JOIN ViewSubGroup VSG ON VSG.SubCode=HRTR.SubCode  " & _
                    " Left join Sch_Category Sc on Sc.Code =VHSG.Category " & _
                    " " & mCondStr & " "


            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "Hostel_RoomLeftRegister" : RepTitle = "Room Left Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Hostel)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub

#End Region

#Region "Room Allotment Register"

    Private Sub ProcRoomAllotmentRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            mCondStr = " where HRA.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "All") Then
                mCondStr = mCondStr
            Else

                mCondStr = mCondStr & " And VHSG.Sex = '" & ObjRFG.ParameterCmbo1_Value & "' "
            End If

            If ObjRFG.GetWhereCondition("HRA.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("HRA.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRA.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRA.Site_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HB.Hostel", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HBF.Building", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HR.BuildingFloor", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRTR.Room", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHSG.Category", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRTR.SubCode", 6)

            mQry = " SELECT HRA.DocId, " & AgL.V_No_Field("HRA.DocId") & "  as DocID_Print, HRA.Div_Code, HRA.Site_Code, Si.Name AS Site_Name, HRA.V_Date, HRA.V_Type, HRA.V_Prefix, HRA.V_No, HRA.Remark, " & _
                    " HRTR.Room, HR.Description AS RoomDesc, HB.ManualCode+'\'+HF.Description AS [Buiding Floor], HB.ManualCode+'\'+HF.Description+'\'+HR.Description AS [Buiding Floor Room],HH.Description as Hostel, " & _
                    " HRTR.SubCode, VHSG.MemberType, VHSG.ManualCode, VHSG.Name, VHSG.DispName, VHSG.Sex, VHSG.BloodGroup, VHSG.ReligionDesc, " & _
                    " VHSG.Category, Sc.ManualCode As CategoryManualCode,VHSG.CategoryDesc, VSG.FName AS Father " & _
                    " FROM ViewHt_RoomAllotment HRA " & _
                    " LEFT JOIN Ht_RoomTransfer HRTR ON HRTR.AllotmentDocId=HRA.DocId  AND HRTR.AllotmentType='" & AllotmentType_Allotment & "'" & _
                    " LEFT JOIN Ht_Room HR ON HR.Code=HRTR.Room  " & _
                    " LEFT JOIN Ht_BuildingFloor HBF ON HBF.Code =HR.BuildingFloor " & _
                    " LEFT JOIN Ht_Building HB ON HB.Code=HBF.Building  " & _
                    " LEFT JOIN Ht_Floor HF ON HF.Code =HBF.Floor " & _
                    " LEFT JOIN Ht_Hostel HH ON HH.Code=HB.Hostel " & _
                    " LEFT JOIN ViewHt_SubGroup VHSG ON VHSG.SubCode =HRTR.SubCode  " & _
                    " LEFT JOIN SiteMast SI ON Si.Code =HRA.Site_Code " & _
                    " LEFT JOIN ViewSubGroup VSG ON VSG.SubCode=HRTR.SubCode  " & _
                    " Left join Sch_Category Sc on Sc.Code =VHSG.Category " & _
                    " " & mCondStr & " "


            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "Hostel_RoomAllotmentRegister" : RepTitle = "Room Allotment Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Hostel)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub

#End Region

#Region "Room Transfer Register"

    Private Sub ProcRoomTransferRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            mCondStr = " where HRTR.AllotmentType = '" & AllotmentType_Transfer & "'  AND HRTR.AllotmentDate Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "

            If Not AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "All") Then
                mCondStr = mCondStr & " And VHSG.Sex = '" & ObjRFG.ParameterCmbo1_Value & "' "
            End If



            If ObjRFG.GetWhereCondition("HRTR.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("HRTR.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRTR.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRTR.Site_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHR.HostelCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHR.BuildingCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHR.BuildingFloor", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRTR.Room", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHSG.Category", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HRTR.SubCode", 6)

            mQry = " SELECT HRTR.Code as RoomTransferCode, HRTR.AllotmentDocId, " & AgL.V_No_Field("HRTR.AllotmentDocId") & "  as DocID_Print,	HRTR.SubCode, HRTR.Room, HRTR.AllotmentDate, HRTR.AllotmentType, HRTR.TransferDate,	HRTR.TransferRemark, HRTR.Div_Code,	HRTR.Site_Code, SM.Name AS Site_Name, " & _
                    " VHR.Code AS RoomCode, VHR.Description AS Room_Desc, VHR.BuildingFloor, VHR.RoomType as RoomTypeCode, HRT.ManualCode as RoomTypeManualCode , VHR.TotalBed, VHR.BuildingFloorRoomDesc, VHR.BuildingCode, VHR.FloorCode, VHR.BuildingDesc, VHR.BuildingManualCode, " & _
                    " VHR.BuildingNature, VHR.FloorDesc, VHR.BuildingFloorDesc, VHR.HostelCode, VHR.HostelDesc, VHR.HostelManualCode, " & _
                    " VHSG.MemberType, VHSG.Name AS Member_Name, VHSG.DispName AS Member_dispName, VHSG.MemberType, VHSG.Add1, VHSG.Add2, VHSG.Add3, VHSG.CityCode, City.CityName, VHSG.Phone, VHSG.Mobile, VHSG.FAX, VHSG.EMail, VHSG.FatherName, VHSG.DOB, " & _
                    " VHSG.Sex, VHSG.BloodGroup, VHSG.Religion, VHSG.Category, VHSG.CategoryDesc, '" & ObjRFG.ParameterCmbo2_Value & "' as ChargeDetail, " & _
                    " HRTC.Charge, HRTC.Amount, HRTC.ChargeType, SG.ManualCode AS Charge_Desc, HRTC.DueMonth, HRTC.IsOnceInLife, HRTC.IsFirstTimeRequired, " & _
                    " Rt1.BuildingFloorRoomDesc As OldRoomDesc, HRTR.BuildingFloorRoomDesc AS NewRoomDesc, Rt1.AllotmentDate AS OldRoomJoinDate,HRTR.AllotmentDate AS NewRoomJoinDate, Rt1.RoomTypeDesc As OldRoomTypeDescription, HRT.Description as NewRoom_TypeDesc" & _
                    " FROM ViewHt_RoomTransfer HRTR " & _
                    " LEFT JOIN ViewHt_RoomTransfer Rt1 ON HRTR.AllotmentDocId = Rt1.AllotmentDocId  AND HRTR.AllotmentDate=Rt1.TransferDate " & _
                    " LEFT JOIN ViewHt_Room VHR ON VHR.Code=HRTR.Room " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=HRTR.Site_Code  " & _
                    " LEFT JOIN ViewHt_SubGroup VHSG ON VHSG.SubCode =HRTR.SubCode " & _
                    " LEFT JOIN Ht_RoomType HRT ON HRT.Code =VHR.RoomType    " & _
                    " LEFT JOIN City ON City.CityCode=VHSG.CityCode " & _
                    " LEFT JOIN Ht_RoomTransferCharge HRTC ON HRTC.RoomTransfer =HRTR.Code " & _
                    " LEFT JOIN Ht_Charge HC ON HC.SubCode =HRTC.Charge " & _
                    " LEFT JOIN SubGroup Sg ON HC.SubCode=Sg.SubCode  " & _
                    " " & mCondStr & " "


            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "Hostel_RoomTransferRegister" : RepTitle = "Room Transfer Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Hostel)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub

#End Region

#Region "Advance Charge Register"


    Private Sub ProcAdvanceChargeRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            mCondStr = " where HAC.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            If ObjRFG.GetWhereCondition("HAC.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("HAC.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("HAC.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HAC.Site_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HAC.V_Type", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHRA.MemberCode", 2)

            mQry = " SELECT HAC.DocId," & AgL.V_No_Field("HAC.DocId") & "  as DocID_Print, HAC.Div_Code, HAC.Site_Code, SI.Name AS Site_Name, HAC.V_Date, HAC.V_Type, HAC.V_Prefix, HAC.V_No, HAC.AllotmentDocId, HAC.ReceiveAmount, HAC.Remark, HAC.PreparedBy, HAC.U_EntDt, HAC.U_AE, " & _
                    " Vt.NCat, VHRA.MemberCode AS Member, VHRA.DocId AS AllotmentID, VHRA.MemberName, VHRA.MemberDispName, VHRA.MemberType, VHRA.FatherName, VHRA.Phone, VHRA.Mobile, VHRA.FAX, VHRA.EMail, VHRA.Add1, VHRA.Add2, VHRA.Add3, VHRA.PIN, VHRA.CityName, " & _
                    " HCRA.ChargeReceiveDocId, HAC.IsAdjusted, VHRT.Room, VHRT.BuildingFloorRoomDesc " & _
                    " FROM ViewHt_AdvanceReceive HAC " & _
                    " Left Join Voucher_Type Vt On HAC.V_Type = Vt.V_Type  " & _
                    " LEFT JOIN ViewHt_RoomAllotment VHRA ON VHRA.DocId =HAC.AllotmentDocId  " & _
                    " LEFT JOIN Ht_ChargeReceiveAdvance  HCRA ON HCRA.ChargeAdvanceDocId =HAC.DocId " & _
                    " LEFT JOIN ViewHt_RoomTransfer VHRT ON HAC.V_Date BETWEEN VHRT.AllotmentDate AND VHRT.TransferDate AND HAC.AllotmentDocId =VHRT.AllotmentDocId " & _
                    " LEFT JOIN SiteMast SI ON SI.Code=HAC.Site_Code  " & _
                    " " & mCondStr & " "


            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "Hostel_AdvanceChargeRegister" : RepTitle = "Advance Charge Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Hostel)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub
#End Region

#Region "Charge Due Register"

    Private Sub ProcChargeDueRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "", bViewStr$ = ""


            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            'mCondStr = " where Vcd.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = " where Vcd.V_Date < =" & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            If ObjRFG.GetWhereCondition("VCD.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("VCD.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("VCD.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VCD.Site_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Vsg.Category", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Vra.MemberCode", 2)

            bViewStr = FunGetChargeDueStr(ObjRFG.ParameterDate1_Value, ObjRFG.ParameterDate2_Value)


            'mQry = " SELECT HCD.DocId, " & AgL.V_No_Field("HCD.DocId") & "  as DocID_Print, HCD.Div_Code, HCD.Site_Code, SI.Name AS Site_Name,HCD.V_Date, HCD.V_Type, VT.Description AS V_Desc, HCD.V_Prefix, HCD.V_No, HCD.MonthStartDate, HCD.TotalAmount, HCD.Remark, HCD.PreparedBy, HCD.U_EntDt, HCD.U_AE, " & _
            '       " HCD1.Charge, HCD1.Amount,SG.Name AS Charge_Desc, " & _
            '       " VHRA.MemberCode,VHRA.MemberName,VHRA.MemberDispName,VHRA.MemberType,VHRA.FatherName,VHRA.Phone,VHRA.Mobile,VHRA.FAX,VHRA.EMail,VHRA.Add1,VHRA.Add2,VHRA.Add3,VHRA.PIN,VHRA.CityName " & _
            '       " sum(vfd.dueamount) AS TotalAmount, Sum(vfd.TillDate_NetReceiveAmount) AS ReceivedAmt, " & _
            '       " Sum(vfd.TillDate_Discount) AS Discount, sum(vfd.TillDate_NetBalance) AS BalAmt, " & _
            '       " sum(VCD.OpeningDueAmount) AS OpeningDueAmount,Sum(VCd.CurrentDueAmount) AS CurrentDueAmount,  " & _
            '       " Sum(VCD.OpeningNetReceiveAmount) AS OpeningNetReceiveAmount, sum(VCD.CurrentNetReceiveAmount) AS CurrentNetReceiveAmount,  " & _
            '       " sum(VCD.OpeningDiscount) AS OpeningDiscount, Sum(VCD.CurrentDiscount) AS CurrentDiscount, " & _
            '       " Sum(VCD.OpeningNetBalance) AS OpeningNetBalance, sum(VCD.CurrentNetBalance) AS CurrentNetBalance, " & _
            '       " Sum(VCD.TillDate_NetRefundAmount) As TillDate_NetRefundAmount, Sum(VCD.OpeningNetRefundAmount) As OpeningNetRefundAmount, Sum(VCD.CurrentNetRefundAmount) As CurrentNetRefundAmount " & _
            '       " FROM (" & bViewStr & ") AS  VCD " & _
            '       " LEFT JOIN Ht_ChargeDue1 HCD1 ON HCD1.DocId=VCD.DocId  " & _
            '       " LEFT JOIN ViewHt_RoomAllotment VHRA ON VHRA.DocId =HCD1.AllotmentDocId  " & _
            '       " LEFT JOIN SiteMast SI ON SI.Code=HCD.Site_Code  " & _
            '       " LEFT JOIN Ht_Charge HC ON HC.SubCode=HCD1.Charge  " & _
            '       " LEFT JOIN SubGroup SG ON SG.SubCode =HC.SubCode   " & _
            '       " LEFT JOIN Voucher_Type VT ON VT.V_Type =HCD.V_Type  " & _
            '       " " & mCondStr & " "


            mQry = " SELECT " & _
                   " Vcd.dueamount AS TotalAmount, Vcd.TillDate_NetReceiveAmount AS ReceivedAmt," & _
                   " Vcd.TillDate_Discount AS Discount,Vcd.V_Date," & _
                   " Vcd.TillDate_NetBalance AS BalAmt,Vra.MemberName," & _
                   " Vcd.OpeningDueAmount, Vcd.CurrentDueAmount, Vcd.OpeningNetReceiveAmount, Vcd.CurrentNetReceiveAmount, " & _
                   " Vcd.OpeningDiscount, Vcd.CurrentDiscount, Vcd.OpeningNetBalance, Vcd.CurrentNetBalance, " & _
                   " Vcd.TillDate_NetRefundAmount, Vcd.OpeningNetRefundAmount, Vcd.CurrentNetRefundAmount , " & _
                   " Vcd.AllotmentDocId, Vcd.ChargeCode, Vcd.ChargeName, Vcd.ChargeManualCode, Vcd.ChargeDispName, VSg.SubCode, Vcd.Site_Code, Si.Name as Site_Name " & _
                   " FROM (" & bViewStr & ") Vcd " & _
                   " LEFT JOIN ViewHt_RoomAllotment Vra ON Vcd.AllotmentDocId=Vra.DocId " & _
                   " LEFT JOIN ViewHt_SubGroup Vsg ON Vra.MemberCode = Vsg.SubCode " & _
                   " LEFT JOIN SiteMast SI ON SI.Code=Vcd.Site_Code  " & _
                   " " & mCondStr & " "

         
            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Hostel_ChargeDueRegister" : RepTitle = "Charge Due Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Hostel)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub

#End Region

#Region "Charge Receive Register"

    Private Sub ProcChargeReceiveRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            mCondStr = " where HCR.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            If ObjRFG.GetWhereCondition("HCR.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("HCR.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("HCR.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HCR.Site_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHSG.Category", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHRA.MemberCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HCR.DocId", 3)

            mQry = " SELECT HCR.DocId, " & AgL.V_No_Field("HCR.DocId") & "  as DocID_Print, HCR.Div_Code, HCR.Site_Code, SI.Name AS Site_Name, HCR.V_Date, HCR.V_Type, VT.Description AS Voucher_Desc, HCR.V_Prefix, HCR.V_No, HCR.AllotmentDocId, HCR.TotalLineAmount, HCR.TotalLineDiscount, HCR.TotalLineNetAmount, HCR.AdvanceBroughtForward, " & _
                    " HCR.TotalAdvanceAdjusted,HCR.SubTotal1,HCR.DiscountPer,HCR.DiscountAmount,HCR.TotalNetAmount,HCR.IsManageCharge,HCR.ReceiveAmount,HCR.AdvanceCarriedForward,HCR.Remark,HCR.PreparedBy,HCR.U_EntDt,HCR.U_AE, " & _
                    " HCR1.ChargeDue1 ,SG.Name AS [Charge Name],HCR1.Amount, HCR1.Discount ,HCR1.NetAmount, VHSG.Category, VHSG.CategoryDesc , " & _
                    " VHRA.MemberCode, VHRA.MemberName, VHRA.MemberDispName, VHRA.MemberType, VHRA.FatherName, VHRA.Phone, VHRA.Mobile, VHRA.FAX, VHRA.EMail, VHRA.Add1, VHRA.Add2, VHRA.Add3, VHRA.PIN, VHRA.CityName  " & _
                    " FROM Ht_ChargeReceive HCR " & _
                    " LEFT JOIN Ht_ChargeReceive1 HCR1 ON HCR1.DocId =HCR.DocId  " & _
                    " LEFT JOIN ViewHt_RoomAllotment VHRA ON VHRA.DocId=HCR.AllotmentDocId  " & _
                    " LEFT JOIN SiteMast SI ON SI.Code=HCR.Site_Code  " & _
                    " LEFT JOIN Voucher_Type VT ON VT.NCat = HCR.V_Type  " & _
                    " LEFT JOIN ViewHt_SubGroup VHSG ON VHSG.SubCode =VHRA.MemberCode " & _
                    " LEFT JOIN ht_ChargeDue1 HCD1 ON HCD1.Code = HCR1.ChargeDue1 " & _
                    " LEFT JOIN SubGroup SG ON HCD1.Charge=SG.SubCode " & _
                    " " & mCondStr & " "

            mQry1 = " SELECT sum(HCR1.NetAmount) AS TotalAmount,max(Sg.SubCode) AS ChargeSubCode ,max(Sg.Name) AS ChargeName ,max(Sg.DispName) AS ChargeDispName,max(Sg.ManualCode) AS ChargeManualCode " & _
                        " FROM Ht_ChargeReceive HCR  " & _
                        " LEFT JOIN Ht_ChargeReceive1 HCR1 ON HCR1.DocId =HCR.DocId  " & _
                        " LEFT JOIN ViewHt_RoomAllotment VHRA ON VHRA.DocId=HCR.AllotmentDocId  " & _
                        " LEFT JOIN SiteMast SI ON SI.Code=HCR.Site_Code  " & _
                        " LEFT JOIN Voucher_Type VT ON VT.NCat = HCR.V_Type  " & _
                        " LEFT JOIN ViewHt_SubGroup VHSG ON VHSG.SubCode =VHRA.MemberCode " & _
                        " LEFT JOIN ht_ChargeDue1 HCD1 ON HCD1.Code = HCR1.ChargeDue1 " & _
                        " LEFT JOIN SubGroup SG ON HCD1.Charge=SG.SubCode " & _
                        " " & mCondStr & " " & _
                        " GROUP BY SG.SubCode  "

            DsRep1 = AgL.FillData(mQry1, AgL.GCn)
            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "Hostel_ChargeReceiveRegister" : RepTitle = "Charge Receive Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")


            ObjRFG.SubReport1DataSet = DsRep1

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Hostel)

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub

#End Region

#Region "Charge Refund Register"

    Private Sub ProcChargeRefundRegister()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            mCondStr = " where HCR.V_Date Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "


            If ObjRFG.GetWhereCondition("HCR.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("HCR.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("HCR.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HCR.Site_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHSG.Category", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHRA.MemberCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("HCR.DocId", 3)

            mQry = " SELECT HCR.DocId," & AgL.V_No_Field("HCR.DocId") & "  as Refund_VNo,HCR.Div_Code,HCR.Site_Code,SI.Name AS Site_Name,HCR.V_Date,HCR.V_Type,HCR.V_Prefix,HCR.V_No,HCR.ChargeReceiveDocId, " & _
                    " " & AgL.V_No_Field("HCR.ChargeReceiveDocId") & "  as Recieve_VNo,CR.ReceiveAmount,HCR.TotalLineAmount,HCR.TotalLineNetAmount,HCR.IsManageCharge,HCR.RefundAmount,HCR.ExcessRefund,HCR.Remark, " & _
                    " HCR1.ChargeReceive1,HCR1.Amount,HCR1.NetAmount,VHC.ChargeName,VHC.ChargeDispName,HCG.ManualCode AS Charge_GroupDesc,HCR.AllotmentDocId,HCR.MemberCode,HCR.MemberName , " & _
                    " IsNull(ORef.OpenRefundAmount,0) AS OpenRefundAmount " & _
                    " FROM ViewHt_ChargeRefund HCR " & _
                    " LEFT JOIN Ht_ChargeRefund1 HCR1 ON HCR1.DocId=HCR.DocId  " & _
                    " LEFT JOIN ViewHt_ChargeReceive1  VCR1 ON VCR1.Code =HCR1.Code  " & _
                    " LEFT JOIN Ht_ChargeDue1 HCD1 ON HCD1.Code =VCR1.ChargeDue1  " & _
                    " LEFT JOIN ViewHt_Charge  VHC ON VHC.SubCode =HCD1.Charge  " & _
                    " LEFT JOIN SiteMast SI ON Si.Code=HCR.Site_Code  " & _
                    " LEFT JOIN Ht_ChargeGroup HCG ON HCG.Code =VHC.ChargeGroup  " & _
                    " LEFT JOIN ViewHt_RoomAllotment VHRA ON VHRA.DocId=HCR.AllotmentDocId  " & _
                    " LEFT JOIN ViewHt_SubGroup VHSG ON VHSG.SubCode =HCR.MemberCode " & _
                    " LEFT JOIN ( " & _
                    "             SELECT sum(VCR.RefundAmount) AS OpenRefundAmount, VCR.ChargeReceiveDocId " & _
                    "             FROM ViewHt_ChargeRefund VCR " & _
                    "             WHERE VCR.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " " & _
                    "             GROUP BY VCR.ChargeReceiveDocId " & _
                    "           ) AS ORef " & _
                    " ON  ORef.ChargeReceiveDocId= HCR.ChargeReceiveDocId " & _
                    " LEFT JOIN Ht_ChargeReceive CR ON CR.DocId=HCR.ChargeReceiveDocId " & _
                    " " & mCondStr & " "




            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "Hostel_ChargeRefundRegister" : RepTitle = "Charge Refund Register"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Hostel)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub

#End Region

#Region "Member Wise Out Standing Summary"

    Private Sub ProcMemberWiseOutStandingSummary()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = "", mCondStr1$ = "", bQry$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            'mCondStr = " where RT.AllotmentDate Between " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " And " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " "
            mCondStr = "Where 1=1"

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "Both") Then
                mCondStr = mCondStr
            Else

                mCondStr = mCondStr & " And RAlt.MemberType = '" & ObjRFG.ParameterCmbo1_Value & "' "
            End If

            If ObjRFG.GetWhereCondition("RT.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("RT.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("RT.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("RT.Site_Code", 0)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("VHSG.Category", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("RT.SubCode", 2)

            'bQry = " SELECT RAlt.DocId AS AllotmentDocid, RAlt.Site_Code,SM.Name AS Site_Name,RT.HostelCode,RT.HostelDesc,RAlt.MemberName AS MemberName,RAlt.FatherName, " & _
            '        " RAlt.Phone, RAlt.Mobile, RAlt.Fax, RAlt.EMail,VHSG.Sex,VHSG.Category,VHSG.CategoryDesc,Sc.ManualCode as CategoryManualCode, " & _
            '        " IsNull(vCd.OpeningDueAmount,0) - IsNull(vCRecv.OpeningReceiveAmount,0) + IsNull(vCRef.OpeningRefundAmount,0) AS OpeningBalance, " & _
            '        " IsNull(vCd.CurrentDueAmount,0) AS CurrentDueAmount, " & _
            '        " IsNull(vCRecv.CurrentReceiveAmount,0) AS CurrentReceiveAmount, " & _
            '        " IsNull(vCRef.CurrentRefundAmount,0) AS CurrentRefundAmount, " & _
            '        " (IsNull(vCd.OpeningDueAmount,0) - IsNull(vCRecv.OpeningReceiveAmount,0) + IsNull(vCRef.OpeningRefundAmount,0)) + " & _
            '        " (IsNull(vCd.CurrentDueAmount,0) - IsNull(vCRecv.CurrentReceiveAmount,0) + IsNull(vCRef.CurrentRefundAmount,0)) AS NetBalance, " & _
            '        " IsNull(vARecv.NetAdvanceTillDate,0) AS NetAdvanceTillDate, " & _
            '        " vRt.CurrentBuildingFloorRoomDesc, vRt.LeftDate, " & _
            '        " RAlt.MemberType, A.AdmissionID, " & _
            '        " CASE RAlt.MemberType WHEN 'Student' THEN " & _
            '        " ( " & _
            '        "  SELECT P.FromStreamYearSemester AS CurrentStramYearSemester " & _
            '        "  FROM ViewSch_AdmissionPromotion P " & _
            '        "  WHERE P.AdmissionDocId = A.DocId  " & _
            '        "  AND " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " >= P.AdmissionDate  " & _
            '        "  AND P.Sr =    " & _
            '        "	( " & _
            '        "		SELECT Max(P1.Sr)   " & _
            '        "		FROM ViewSch_AdmissionPromotion P1   " & _
            '        "		WHERE P1.AdmissionDocId = P.AdmissionDocId  AND  " & _
            '        "       " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " >= P1.AdmissionDate " & _
            '        "	) " & _
            '        " )  " & _
            '        " ELSE  " & _
            '        "	NULL " & _
            '        " END AS CurrentStramYearSemesterCode " & _
            '        " FROM ViewHt_RoomAllotment RAlt " & _
            '        " LEFT JOIN Sch_Admission A ON A.Student=RAlt.MemberCode  " & _
            '        " Left Join " & _
            '        " ( " & _
            '        " SELECT Cd.AllotmentDocId, " & _
            '        " SUM(CASE WHEN Cd.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " THEN Cd.DueAmount ELSE 0 END) AS OpeningDueAmount, " & _
            '        " SUM(CASE WHEN Cd.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " THEN 0 ELSE Cd.DueAmount END) AS CurrentDueAmount " & _
            '        " FROM ViewHt_ChargeDue Cd " & _
            '        " WHERE Cd.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " " & _
            '        " GROUP BY Cd.AllotmentDocId  " & _
            '        " ) vCd ON RAlt.DocId = vCd.AllotmentDocId " & _
            '        " LEFT JOIN  " & _
            '        " ( " & _
            '        " SELECT CRecv1.AllotmentDocId, " & _
            '        " SUM(CASE WHEN CRecv1.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " THEN CRecv1.Amount ELSE 0 END) AS OpeningReceiveAmount, " & _
            '        " SUM(CASE WHEN CRecv1.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " THEN 0 ELSE CRecv1.Amount END) AS CurrentReceiveAmount " & _
            '        " FROM ViewHt_ChargeReceive1 CRecv1 " & _
            '        " WHERE CRecv1.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " " & _
            '        " GROUP BY CRecv1.AllotmentDocId  " & _
            '        " ) vCRecv ON RAlt.DocId = vCRecv.AllotmentDocId " & _
            '        " LEFT JOIN  " & _
            '        " ( " & _
            '        " SELECT CRef1.AllotmentDocId, " & _
            '        " SUM(CASE WHEN CRef1.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " THEN CRef1.NetAmount ELSE 0 END) AS OpeningRefundAmount, " & _
            '        " SUM(CASE WHEN CRef1.V_Date < " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " THEN 0 ELSE CRef1.NetAmount END) AS CurrentRefundAmount " & _
            '        " FROM ViewHt_ChargeRefund1 CRef1 " & _
            '        " WHERE CRef1.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " " & _
            '        " GROUP BY CRef1.AllotmentDocId  " & _
            '        " ) vCRef ON RAlt.DocId = vCref.AllotmentDocId " & _
            '        " LEFT JOIN  " & _
            '        " ( " & _
            '        " SELECT ARecv.AllotmentDocId,  " & _
            '        " SUM(CASE WHEN CRecv.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " THEN 0 ELSE ARecv.ReceiveAmount END) AS NetAdvanceTillDate  " & _
            '        " FROM ViewHt_AdvanceReceive ARecv " & _
            '        " LEFT JOIN Ht_ChargeReceive CRecv ON ARecv.ChargeReceiveDocId = CRecv.DocId  " & _
            '        " WHERE ARecv.V_Date <= " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " " & _
            '        " GROUP BY ARecv.AllotmentDocId  " & _
            '        " ) vARecv ON RAlt.DocId = vARecv.AllotmentDocId " & _
            '        " LEFT JOIN  " & _
            '        " ( " & _
            '        " SELECT Rt.AllotmentDocId,  " & _
            '        " CASE WHEN Rt.LeftDate IS NULL THEN Rt.BuildingFloorRoomDesc Else CASE WHEN Rt.LeftDate > " & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " THEN Rt.BuildingFloorRoomDesc ELSE NULL END  END AS CurrentBuildingFloorRoomDesc, " & _
            '        "                                     Rt.LeftDate " & _
            '        " FROM ViewHt_RoomTransfer Rt " & _
            '        " WHERE Rt.AllotmentDate =	 " & _
            '        " 	( " & _
            '        " 		SELECT Max(VHRT.AllotmentDate) AS RoomJoinDate " & _
            '        " 		FROM ViewHt_RoomTransfer VHRT " & _
            '        " 		WHERE VHRT.AllotmentDate <=" & AgL.ConvertDate(ObjRFG.ParameterDate2_Value) & " AND VHRT.AllotmentDocId = Rt.AllotmentDocId " & _
            '        " 		GROUP BY VHRT.AllotmentDocId " & _
            '        " 	) " & _
            '        " ) vRt ON RAlt.DocId = vRt.AllotmentDocId " & _
            '        " LEFT JOIN ViewHt_RoomTransfer RT ON RT.AllotmentDocId=RAlt.DocId AND Rt.AllotmentType='Allotment'" & _
            '        " LEFT JOIN ViewHt_SubGroup VHSG ON VHSG.SubCode=RT.SubCode " & _
            '        " LEFT JOIN SiteMast SM ON SM.Code=RAlt.Site_Code  " & _
            '        " Left join Sch_Category Sc on Sc.Code =VHSG.Category " & _
            '        " " & mCondStr & " "

            mQry = " Select V1.*, IsNull(V1.NetBalance,0) -IsNull(V1.NetAdvanceTillDate,0) AS ActualNetBalance, Sem.StreamYearSemesterDesc AS CurrentStreamYearSemesterDesc " & _
                     " From (" & FunGetMemberOutstandingQry(ObjRFG.ParameterDate1_Value, ObjRFG.ParameterDate2_Value, mCondStr) & ") V1 " & _
                     " LEFT JOIN ViewSch_StreamYearSemester Sem ON V1.CurrentStramYearSemesterCode = Sem.Code " & _
                     " Where (IsNull(V1.NetAdvanceTillDate,0) + IsNull(V1.NetBalance,0)) <> 0 "

            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "Hostel_MemberWiseOutStandingSummary" : RepTitle = "Member Wise OutStanding Summary"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Hostel)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try

    End Sub

#End Region

    Public Sub New(ByVal mObjRepFormGlobal As AgLibrary.RepFormGlobal)
        ObjRFG = mObjRepFormGlobal
    End Sub

#Region "Room Status Report"

    Private Sub ProcRoomStatusReport()
        Try
            Call ObjRFG.FillGridString()

            Dim mCondStr$ = ""
            Dim mCondStr1$ = ""

            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Date1_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo1_Control) Then Exit Sub

            mCondStr = mCondStr & "Where 1=1"
            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, "All") Then
                mCondStr = mCondStr
            Else

                mCondStr = mCondStr & " And R.BuildingNature = '" & ObjRFG.ParameterCmbo1_Value & "' "
            End If


            If ObjRFG.GetWhereCondition("R.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("R.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("R.HostelCode", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("R.BuildingCode", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("R.BuildingFloor", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("R.Code", 4)

            mQry = " SELECT R.Code AS RoomCode, IsNull(V1.TotalAllotment,0) AS TotalAllotment, R.TotalBed, R.Div_Code, R.Site_Code, Si.Name As Site_Name, " & _
                   " R.BuildingFloorRoomDesc, R.RoomTypeDesc, R.Location, " & _
                   " R.BuildingDesc, R.BuildingManualCode, R.BuildingNature, R.FloorDesc,  " & _
                   " R.FloorNo, R.BuildingFloorDesc, R.HostelCode, R.HostelDesc, R.HostelManualCode,   " & _
                   " Convert(BIT,CASE WHEN V1.RoomCode IS NULL THEN 0 ELSE 1 END) AS Status, " & _
                   " Case When (IsNull(R.TotalBed,0) - IsNull(V1.TotalAllotment,0)) = 0 And IsNull(V1.TotalAllotment,0) > 0 Then 'Occupied' Else  " & _
                   " Case When (IsNull(R.TotalBed,0) - IsNull(V1.TotalAllotment,0)) > 0 And IsNull(V1.TotalAllotment,0) > 0 Then 'Partially Occupied' Else  " & _
                   " Case When (IsNull(R.TotalBed,0) - IsNull(V1.TotalAllotment,0)) > 0 And IsNull(V1.TotalAllotment,0) = 0 Then 'Vacant' End End End As StatusType, " & _
                   " Case When (IsNull(R.TotalBed,0) - IsNull(V1.TotalAllotment,0)) = 0 And IsNull(V1.TotalAllotment,0) > 0 Then 1 Else 0 End As Status_Occupied, " & _
                   " Case When (IsNull(R.TotalBed,0) - IsNull(V1.TotalAllotment,0)) > 0 And IsNull(V1.TotalAllotment,0) > 0 Then 1 Else 0 End As Status_PartiallyOccupied, " & _
                   " Case When (IsNull(R.TotalBed,0) - IsNull(V1.TotalAllotment,0)) > 0 And IsNull(V1.TotalAllotment,0) = 0 Then 1 Else 0 End As Status_Vacant " & _
                   " FROM ViewHt_Room R    " & _
                   " Left JOIN ( " & _
                   "			SELECT Rt.Room AS RoomCode,Max(Rt.AllotmentDate ) AS MaxAltDate ,count(AllotmentDocId) AS TotalAllotment " & _
                   " 			FROM ViewHt_RoomTransfer Rt   " & _
                   " 			WHERE " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " >= Rt.AllotmentDate AND  " & _
                   "				   " & AgL.ConvertDate(ObjRFG.ParameterDate1_Value) & " < CASE WHEN Rt.TransferDate IS NULL THEN CASE WHEN Rt.LeftDate IS NULL THEN " & AgL.ConvertDate(AgL.RetMonthEndDate(CDate(ObjRFG.ParameterDate1_Value))) & " ELSE Rt.LeftDate  END  ELSE  Rt.TransferDate  END  " & _
                   " 			GROUP BY Rt.Room  " & _
                   "			) AS V1 ON R.Code = V1.RoomCode  " & _
                   "LEFT JOIN SiteMast SI ON Si.Code= R.Site_Code   " & _
                   "" & mCondStr & ""



            DsRep = AgL.FillData(mQry, AgL.GCn)



            RepName = "Hostel_RoomStatusReport" : RepTitle = "Room Status Report"

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")



            ObjRFG.PrintReport(DsRep, RepName, RepTitle, PLib.PubReportPath_Hostel)
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
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo2_Control) Then Exit Sub
            If ObjRFG.IsRequiredField(AgLibrary.ClsMain.ReportFormGlobalControls.Cmbo3_Control) Then Exit Sub

            Call ObjRFG.FillGridString()

            mCondStr = " Where 1=1 "

            If AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, ClsMain.MemberType.Student) Then
                mCondStr += " And H.MemberType = '" & ClsMain.MemberType.Student & "'"

            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo1_Value, ClsMain.MemberType.Employee) Then
                mCondStr += " And H.MemberType = '" & ClsMain.MemberType.Employee & "'"

            End If

            If AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Male") Then
                mCondStr += " And Sg.Sex = 'Male'"

            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo2_Value, "Female") Then
                mCondStr += " And Sg.Sex = 'Female'"
            End If

            If AgL.StrCmp(ObjRFG.ParameterCmbo3_Value, "No") Then
                mCondStr += " And L.LeftDate Is Null "

            ElseIf AgL.StrCmp(ObjRFG.ParameterCmbo3_Value, "Yes") Then
                mCondStr += " And L.LeftDate Is Not Null "
            End If


            If ObjRFG.GetWhereCondition("H.Site_Code", 0) = "" Then
                mCondStr = mCondStr & " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            Else
                mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.Site_Code", 0)
            End If

            mCondStr = mCondStr & ObjRFG.GetWhereCondition("A.CurrentSemester", 1)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("B.Hostel", 2)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Bf.Building", 3)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("Bf.Code", 4)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.CurrentRoom", 5)
            mCondStr = mCondStr & ObjRFG.GetWhereCondition("H.SubCode", 6)

            mQry = "SELECT H.DocId As AllotmentDocId, H.Div_Code, H.Site_Code, H.V_Date, H.V_Type, H.V_Prefix, H.V_No, " & AgL.V_No_Field("H.DocId") & " As AllotmentVNo, H.Remark, H.SubCode, H.MemberType, " & _
                    " Sm.Name AS SiteName, Sm.ManualCode AS SiteManualCode, R.Description AS RoomDesc, R.RoomNoPrefix, R.RoomNoSuffix, R.Location, R.TotalBed, " & _
                    " B.Description AS BuildingDesc, F.Description AS FloorDesc, F.FloorNo, L.LeftDate, L.LeftRemark, " & _
                    " B.Nature AS BuildingNature, Hm.Description AS HostelDesc, Hm.ManualCode AS HotelManualCode, " & _
                    " Hm.Add1 AS HostelAdd1, Hm.Add2 AS HostelAdd2, Hm.Add3 AS HostelAdd3, Hm.CityCode AS HostelCity, Hm.Pin AS HostelPin, Hm.Phone AS HostelPhone, Hm.Mobile AS HostelMobile, Hm.Fax AS HostelFax, Hm.Email AS HostelEMail, Hm.ContactPerson   AS HostelContactPerson, " & _
                    " Sg.Name AS MemberName, Sg.DispName MmeberDispName, Sg.ManualCode AS MemberManualCode, Sg.Add1, Sg.Add2, Sg.Add3, City.CityName, Sg.PIN, Sg.Phone, Sg.Mobile, Sg.FAX, Sg.EMail, Sg.FatherName, Sg.MotherName, Sg.Sex, Sg.MarriageDate, Sg.DOB, SgI.Photo, " & _
                    " Sem.StreamYearSemesterDesc, Sem.SessionManualCode, Sem.ProgrammeManualCode, Sem.StreamManualCode,  " & _
                    " Sem.ProgrammeNatureDescription, Sem.YearSerial, Sem.SemesterSerialNo, Sem.SemesterDesc " & _
                    " FROM Ht_RoomAllotment H WITH (NoLock) " & _
                    " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = H.V_Type  " & _
                    " LEFT JOIN SiteMast Sm WITH (NoLock) ON Sm.Code = H.Site_Code " & _
                    " LEFT JOIN Ht_Room R WITH (NoLock) ON R.Code = H.CurrentRoom " & _
                    " LEFT JOIN dbo.SubGroup Sg WITH (NoLock) ON Sg.SubCode = H.SubCode " & _
                    " LEFT JOIN City WITH (NoLock) ON City.CityCode = Sg.CityCode  " & _
                    " LEFT JOIN Ht_RoomLeft L WITH (NoLock) ON L.AllotmentDocId = H.DocId  " & _
                    " LEFT JOIN Ht_BuildingFloor AS Bf WITH (NoLock) ON Bf.Code = R.BuildingFloor  " & _
                    " LEFT JOIN Ht_Building B WITH (NoLock) ON B.Code = Bf.Building  " & _
                    " LEFT JOIN Ht_Floor F WITH (NoLock) ON F.Code = Bf.Floor  " & _
                    " LEFT JOIN Ht_Hostel Hm WITH (NoLock) ON Hm.Code = B.Hostel " & _
                    " LEFT JOIN City AS hCity WITH (NoLock) ON hCity.CityCode = Hm.CityCode " & _
                    " LEFT JOIN SubGroup_Image SgI WITH (NoLock) ON SgI.SubCode = Sg.SubCode  " & _
                    " LEFT JOIN Sch_Admission A WITH (NoLock) ON A.Student = H.SubCode  " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem WITH (NoLock) ON Sem.Code = A.CurrentSemester  "


            mQry += mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            RepName = "Hostel_MemberRegister" : RepTitle = "Member Register"
            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ObjRFG.PrintReport(DsRep, RepName, RepTitle, AgL.PubReportPath)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        Finally
            If DsRep IsNot Nothing Then DsRep.Dispose()
        End Try

    End Sub

#End Region

    Private Function FunGetChargeDueStr(ByVal bFromDateStr As String, ByVal bToDateStr As String) As String
        Dim bViewStr$ = ""
        Try


            bViewStr = "SELECT " & _
                        " CASE WHEN Cd.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Cd.DueAmount ELSE 0 END AS OpeningDueAmount,  " & _
                        " CASE WHEN Cd.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Cd.DueAmount END AS CurrentDueAmount,  " & _
                        " IsNull(vCr1.OpeningNetReceiveAmount,0) As OpeningNetReceiveAmount,  " & _
                        " IsNull(vCr1.CurrentNetReceiveAmount,0) As CurrentNetReceiveAmount,  " & _
                        " IsNull(vCr1.OpeningReceiveAmount,0) As OpeningReceiveAmount,  " & _
                        " IsNull(vCr1.CurrentReceiveAmount,0) As CurrentReceiveAmount,  " & _
                        " IsNull(vCr1.OpeningDiscount,0) As OpeningDiscount,    " & _
                        " IsNull(vCr1.CurrentDiscount,0) As CurrentDiscount,  " & _
                        " CASE WHEN Cd.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Cd.DueAmount - IsNull(vCr1.OpeningReceiveAmount,0) + IsNull(vCr1.OpeningNetRefundAmount,0) ELSE 0 END AS OpeningNetBalance,  " & _
                        " CASE WHEN Cd.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Cd.DueAmount - IsNull(vCr1.CurrentReceiveAmount,0) + IsNull(vCr1.CurrentNetRefundAmount,0) END AS CurrentNetBalance,  " & _
                        " IsNull(vCr1.TillDate_ReceiveAmount,0) As TillDate_ReceiveAmount,  " & _
                        " IsNull(vCr1.TillDate_NetReceiveAmount,0) As TillDate_NetReceiveAmount, " & _
                        " IsNull(vCr1.TillDate_Discount,0) As TillDate_Discount,  " & _
                        " Cd.DueAmount As TillDate_TotalDueAmount, Cd.DueAmount - IsNull(vCr1.TillDate_ReceiveAmount,0) + IsNull(vCr1.TillDate_NetRefundAmount,0) As TillDate_NetBalance,  " & _
                        " IsNull(vCr1.TillDate_NetRefundAmount,0) AS TillDate_NetRefundAmount,  " & _
                        " IsNull(vCr1.OpeningNetRefundAmount,0) AS OpeningNetRefundAmount,  " & _
                        " IsNull(vCr1.CurrentNetRefundAmount,0) AS CurrentNetRefundAmount,  " & _
                        " Cd.*  " & _
                        " FROM ViewHt_ChargeDue Cd " & _
                        " LEFT JOIN " & _
                        "   (SELECT Sum(Cr1.Amount) AS TillDate_ReceiveAmount, " & _
                        "   Sum(Cr1.NetAmount) AS TillDate_NetReceiveAmount, " & _
                        "   Sum(Cr1.Discount) As TillDate_Discount,  Cr1.ChargeDue1, " & _
                        "   Sum(CASE WHEN Cr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Cr1.Amount ELSE 0 END) AS OpeningReceiveAmount, " & _
                        "   Sum(CASE WHEN Cr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Cr1.Amount END) AS CurrentReceiveAmount, " & _
                        "   Sum(CASE WHEN Cr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Cr1.NetAmount ELSE 0 END) AS OpeningNetReceiveAmount, " & _
                        "   Sum(CASE WHEN Cr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Cr1.NetAmount END) AS CurrentNetReceiveAmount,  " & _
                        "   Sum(CASE WHEN Cr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Cr1.Discount ELSE 0 END) AS OpeningDiscount,  " & _
                        "   Sum(CASE WHEN Cr1.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Cr1.Discount END) AS CurrentDiscount, " & _
                        "   IsNull(Sum(vCRef.TillDate_NetRefundAmount),0) AS TillDate_NetRefundAmount,  " & _
                        "   IsNull(Sum(vCRef.OpeningNetRefundAmount),0) AS OpeningNetRefundAmount,  " & _
                        "   IsNull(Sum(vCRef.CurrentNetRefundAmount),0) AS CurrentNetRefundAmount  " & _
                        "   FROM ViewHt_ChargeReceive1 Cr1 " & _
                        "   LEFT JOIN " & _
                        "       (SELECT Cref1.ChargeReceive1, sum(Cref1.NetAmount) AS TillDate_NetRefundAmount, " & _
                        "       Sum(CASE WHEN Cref.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN Cref1.NetAmount ELSE 0 END) AS OpeningNetRefundAmount,  " & _
                        "       Sum(CASE WHEN Cref.V_Date < " & AgL.ConvertDate(bFromDateStr) & " THEN 0 ELSE Cref1.NetAmount END) AS CurrentNetRefundAmount " & _
                        "       FROM Ht_ChargeRefund Cref " & _
                        "       LEFT JOIN Ht_ChargeRefund1 Cref1 ON Cref.DocId=Cref1.DocId  " & _
                        "       WHERE Cref.V_Date <=" & AgL.ConvertDate(bToDateStr) & " " & _
                        "       GROUP BY Cref1.ChargeReceive1) VCref " & _
                        "       ON Cr1.Code = Vcref.ChargeReceive1 " & _
                        "       Where Cr1.V_Date <=" & AgL.ConvertDate(bToDateStr) & " " & _
                        "       GROUP BY Cr1.ChargeDue1) AS vCr1  " & _
                        " On Cd.ChargeDue1Code = vCr1.ChargeDue1 "



        Catch ex As Exception
            bViewStr = ""
            MsgBox(ex.Message)
        Finally
            FunGetChargeDueStr = bViewStr
        End Try
    End Function


End Class
