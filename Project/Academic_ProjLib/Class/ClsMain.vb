Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class ClsMain
    Dim AgL As AgLibrary.ClsMain

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain)
        AgL = AgLibVar
    End Sub

    Public Class PartyMasterType
        Public Const Cash As String = "Cash"
        Public Const Party As String = "Party"
        Public Const Supplier As String = "Supplier"
        Public Const Customer As String = "Customer"
        Public Const Transport As String = "Transport"
        Public Const Agent As String = "Agent"
    End Class

#Region "Voucher Type Settings Constants"
#Region "<Voucher NCat> Constants"
    Public Shared NCat_FaOpening As String = "OPBAL"

    '<Voucher NCat> Constants For Academic Module ==============================
    Public Shared NCat_RegistrationEntry As String = "REG"
    Public Shared NCat_RegistrationCancelEntry As String = "CREG"
    Public Shared NCat_StudentAdmission As String = "ADMSN"

    '<Voucher NCat> Constants For Fee Module ==============================
    Public Shared NCat_FeeDue As String = "FD"
    Public Shared NCat_OpeningFeeDue As String = "OFD"

    Public Shared NCat_FeeReceive As String = "FR"
    Public Shared NCat_FeeReceiveAdjustment As String = "FRA"
    Public Shared NCat_OpeningAdvanceFee As String = "OAF"

    Public Shared NCat_FeeRefund As String = "FREF"
    Public Shared NCat_AdvanceReceive As String = "AREC"
    Public Shared NCat_OpeningAdvance As String = "OAREC"

    Public Shared NCat_ReverseFeeDue As String = "RFD"
    Public Shared NCat_ReceiveEntry As String = "REC"
    Public Shared NCat_ScholarshipDemand As String = "SDMD"
    Public Shared NCat_ScholarshipReceive As String = "SREC"

    '<Voucher NCat> Constants For Exam Module ==============================
    Public Shared NCat_SemesterExamCreation As String = "SEC"
    Public Shared NCat_SubjectMarksEntry As String = "SME"
    Public Shared NCat_ConsolidatedSubjectMarksEntry As String = "CSME"

    '<Voucher NCat> Constants For Hostel Module ==============================
    Public Shared NCat_RoomAllotment As String = "RALOT"
    Public Shared NCat_RoomChargeDue As String = "RCDUE"
    Public Shared NCat_RoomChargeMonthlyDue As String = "RCMDU"
    Public Shared NCat_RoomChargeReceive As String = "RCREC"
    Public Shared NCat_RoomChargeRefund As String = "RCREF"
    Public Shared NCat_RoomChargeOpeningDue As String = "RCODU"
    Public Shared NCat_RoomChargeAdvanceReceive As String = "RCARC"
    Public Shared NCat_RoomChargeAdvanceOpening As String = "RCAOP"

    '<Voucher NCat> Constants For Vertical Library Module ==============================
    Public Shared NCat_VbLib_BookReceiveEntry As String = "BRECV"
    Public Shared NCat_VbLib_IssueReceiveEntry As String = "ISSUE"
    Public Shared NCat_VbLib_MagazineReceiveEntry As String = "MRECV"
    Public Shared NCat_VbLib_PurchaseEntry As String = "PBILL"
#End Region

#Region "<Voucher Category> Constants"
    Public Shared Cat_FaOpening As String = "OPBAL"

    '<Voucher Category> Constants For Academic Module ==============================
    Public Shared Cat_RegistrationEntry As String = "REG"
    Public Shared Cat_RegistrationCancelEntry As String = "CREG"
    Public Shared Cat_StudentAdmission As String = "ADMSN"

    '<Voucher Category> Constants For Academic Module ==============================
    Public Shared Cat_FeeDue As String = "FD"
    Public Shared Cat_FeeReceive As String = "FR"
    Public Shared Cat_FeeRefund As String = "FREF"
    Public Shared Cat_AdvanceReceive As String = "AREC"

    Public Shared Cat_ReverseFeeDue As String = "RFD"
    Public Shared Cat_ReceiveEntry As String = "REC"
    Public Shared Cat_ScholarshipDemand As String = "SDMD"
    Public Shared Cat_ScholarshipReceive As String = "SREC"

    '<Voucher Category> Constants For Exam Module ==============================
    Public Shared Cat_SemesterExamCreation As String = "SEC"
    Public Shared Cat_SubjectMarksEntry As String = "SME"
    Public Shared Cat_ConsolidatedSubjectMarksEntry As String = "CSME"

    '<Voucher Category> Constants For Hostel Module ==============================
    Public Shared Cat_RoomAllotment As String = "RALOT"
    Public Shared Cat_RoomChargeDue As String = "RCDUE"
    Public Shared Cat_RoomChargeReceive As String = "RCREC"
    Public Shared Cat_RoomChargeRefund As String = "RCREF"
    Public Shared Cat_RoomChargeAdvanceReceive As String = "RCARC"

    '<Voucher Category> Constants For Vertical Library Module ==============================
    Public Shared Cat_VbLib_BookReceiveEntry As String = "BRECV"
    Public Shared Cat_VbLib_IssueReceiveEntry As String = "ISSUE"
    Public Shared Cat_VbLib_MagazineReceiveEntry As String = "MRECV"
    Public Shared Cat_VbLib_PurchaseEntry As String = "PBILL"
    Public Shared Cat_VbLib_Library As String = "LIB"

#End Region

#Region "<Voucher Type> Constants"
    Public Shared VType_FaOpening As String = "F_AO"
#End Region

#End Region

#Region "Voucher Reference Table Constants"
    Public Structure VRef_ReferenceTable
        Public Code As String
        Public Description As String
        Public BoundField As String
        Public DisplayField As String
        Public IsDocId_DisplayField As Boolean
        Public HelpQuery As String
        Public FilterField As String
        Public SiteField As String
        Public LastHiddenColumns As Integer
        Public RowId As Long
        Public UpLoadDate As String

        'Public Sub VRef_VehicleInsuranceClaimPayment()
        '    Code = "Vehicle Insurance Claim Payment"
        '    Description = "ViewInsuranceClaim"
        '    BoundField = ""
        '    DisplayField = ""
        '    IsDocId_DisplayField = True
        '    HelpQuery = "SELECT I.DocId, I.VoucherNo AS [Voucher No], I.ClaimAmount AS [Claim Amount], I.InsuranceCompanyCode, I.Site_Code FROM ViewInsuranceClaim I ORDER BY I.V_Date DESC "
        '    FilterField = "InsuranceCompanyCode"
        '    SiteField = "Site_Code"
        '    LastHiddenColumns = 2
        '    RowId = 0
        '    UpLoadDate = ""
        'End Sub
    End Structure
#End Region

#Region "Project Report Path Variables"
    Public PubReportPath_Academic_Main As String = ""
    Public PubReportPath_TimeTable As String = ""
    Public PubReportPath_Exam As String = ""
    Public PubReportPath_Hostel As String = ""
    Public PubReportPath_Library As String = ""
#End Region

#Region "Fee Nature Constants"
    Public Const FeeNature_Fee As String = "Fee"
    Public Const FeeNature_Fine As String = "Fine"
    Public Const FeeNature_LateFee As String = "Late Fee"
    Public Const FeeNature_Others As String = "Others"
    Public Const FeeNature_Security As String = "Security"
#End Region

#Region "Admission Status Constants"
    Public Shared AdmissionStatus_Regular As String = "Regular"
    Public Shared AdmissionStatus_ReAdmit As String = "Re-Admit"
    Public Shared AdmissionStatus_Ex As String = "Ex"
#End Region

#Region "Registration Status Constants"
    Public Const RegistrationStatus_Registered As String = "Registered"
    Public Const RegistrationStatus_SeatAllotedBySeeUptu As String = "Seat Alloted By SEE UPTU"
    Public Const RegistrationStatus_SeatAllotedByManagement As String = "Seat Alloted By Management"
    Public Const RegistrationStatus_AdmittedBySeeUptu As String = "Admitted By SEE UPTU"
    Public Const RegistrationStatus_AdmittedByManagement As String = "Admitted By Management"
    Public Const RegistrationStatus_Cancelled As String = "Cancelled"
#End Region

#Region "Promotion Type Constants"
    Public Shared PromotionType_Promotion As String = "Promotion"
    Public Shared PromotionType_StreamChange As String = "Stream Change"
    Public Shared PromotionType_ReAdmit As String = "Re-Admit"
    Public Shared PromotionType_Ex As String = "Ex"
#End Region

#Region "Return Head Type"
    Public Const ReturnHeadType_Fee As String = "Fee"
    Public Const ReturnHeadType_Advance As String = "Advance"
#End Region

#Region "Active Module Variables"
    '===============< Common Modules >===============================
    Public Shared IsModuleActive_FinancialAccount As Boolean = False
    Public Shared IsModuleActive_CommonMaster As Boolean = False
    Public Shared IsModuleActive_Utility As Boolean = False
    '===============< ************* >================================

    '===============< Rest Modules >=================================
    Public Shared IsModuleActive_AcademicMain As Boolean = False
    Public Shared IsModuleActive_FeeModule As Boolean = False
    Public Shared IsModuleActive_TimeTable As Boolean = False
    Public Shared IsModuleActive_Exam As Boolean = False
    Public Shared IsModuleActive_Store As Boolean = False
    Public Shared IsModuleActive_Hostel As Boolean = False
    Public Shared IsModuleActive_VerticalLibrary As Boolean = False
    Public Shared IsModuleActive_Library As Boolean = False
    Public Shared IsModuleActive_Enquiry As Boolean = False
    Public Shared IsModuleActive_Transport As Boolean = False
    Public Shared IsModuleActive_Mess As Boolean = False
    Public Shared IsModuleActive_Canteen As Boolean = False
    '===============< ************* >================================
#End Region

#Region "Client List Variables"
    Public Shared IsClient_Dataman As Boolean = False
    Public Shared IsClient_MIT As Boolean = False
    Public Shared IsClient_Lord As Boolean = False
    Public Shared IsClient_DevSthali As Boolean = False
    Public Shared IsClient_GlobalGroup As Boolean = False
    Public Shared IsClient_Naraina As Boolean = False
    Public Shared IsClient_Kukreja As Boolean = False
    Public Shared IsClient_Indus As Boolean = False
    Public Shared IsClient_SafdarHashmi As Boolean = False
#End Region

#Region "Master Type Constants"
    Public Const MasterType_ScholarshipParameter As String = "ScholarshipParameter"

    Class MasterType
        Public Const Employee As String = "Employee"
        Public Const Teacher As String = "Teacher"
        Public Const Driver As String = "Driver"
    End Class
#End Region

#Region "Vertical Library Member Master Structure"
    Public Structure Struct_LibraryMaster
        Public Member_Code As String
        Public Member_Name As String
        Public Member_Type As String
        Public Student As String
        Public Employee As String
        Public Father_Name As String
        Public Sex As String
        Public CardNo As String
        Public U_Name As String
        Public U_EntDt As String
        Public U_AE As String
    End Structure
#End Region

    Dim mQry As String
    Public PubIniMainStreamCode As String = "010"

    Public Structure Struct_FeeDue
        Public DocId As String
        Public Div_Code As String
        Public Site_Code As String
        Public V_Date As String
        Public V_Type As String
        Public V_Prefix As String
        Public V_No As Long
        Public StreamYearSemester As String
        Public StreamYearSemesterDesc As String
        Public TotalAmount As Double
        Public Remark As String
        Public PreparedBy As String
        Public U_EntDt As String
        Public U_AE As String
        Public Edit_Date As String
        Public ModifiedBy As String
        Public UpLoadDate As String
        Public RowId As Long

        Public Sub FeeDue()
            DocId = ""
            Div_Code = ""
            Site_Code = ""
            V_Date = ""
            V_Type = ""
            V_Prefix = ""
            V_No = 0
            StreamYearSemester = ""
            StreamYearSemesterDesc = ""
            TotalAmount = 0
            Remark = ""
            PreparedBy = ""
            U_EntDt = ""
            U_AE = ""
            Edit_Date = ""
            ModifiedBy = ""
            UpLoadDate = ""
            RowId = 0
        End Sub
    End Structure

    Public Structure Struct_FeeDue1
        Public Code As String
        Public DocId As String
        Public Fee As String
        Public Amount As Double
        Public AdmissionDocId As String
        Public IsReversePostable As Boolean
        Public UpLoadDate As String
        Public RowId As Long

        Public Sub FeeDue1()
            Code = ""
            DocId = ""
            Fee = ""
            Amount = 0
            AdmissionDocId = ""
            IsReversePostable = False
            UpLoadDate = ""
            RowId = 0
        End Sub
    End Structure

    Public Structure Struct_StudentFamilyIncome
        Public GUID As String
        Public Student As String
        Public AsOnDate As String
        Public FatherIncome As String
        Public MotherIncome As Double
        Public FamilyIncome As Double
        Public FatherOccupation As String
        Public FatherCompany As String
        Public FatherCompanyAddress As String
        Public FatherDesignation As String
        Public MotherOccupation As String
        Public MotherCompany As String
        Public MotherCompanyAddress As String
        Public MotherDesignation As String
        Public Div_Code As String
        Public Site_Code As String
        Public PreparedBy As String
        Public U_EntDt As String
        Public U_AE As String
        Public Edit_Date As String
        Public ModifiedBy As String
        Public UpLoadDate As String
        Public RowId As Long

        Public Sub Struct_StudentFamilyIncome()
            GUID = ""
            Student = ""
            AsOnDate = ""
            FatherIncome = ""
            MotherIncome = 0
            FamilyIncome = 0
            FatherOccupation = ""
            FatherCompany = ""
            FatherCompanyAddress = ""
            FatherDesignation = ""
            MotherOccupation = ""
            MotherCompany = ""
            MotherCompanyAddress = ""
            MotherDesignation = ""
            Div_Code = ""
            Site_Code = ""
            PreparedBy = ""
            U_EntDt = ""
            U_AE = ""
            Edit_Date = ""
            ModifiedBy = ""
            UpLoadDate = ""
            RowId = 0
        End Sub
    End Structure

    Public Sub Formula_Set(ByVal mCRD As ReportDocument, Optional ByVal mRepTitle As String = "", Optional ByVal Date1 As String = "", Optional ByVal Date2 As String = "")
        Dim i As Integer
        For i = 0 To mCRD.DataDefinition.FormulaFields.Count - 1
            Select Case AgL.UTrim(mCRD.DataDefinition.FormulaFields(i).Name)
                Case AgL.UTrim("comp_name")
                    mCRD.DataDefinition.FormulaFields(i).Text = "'" & AgL.PubCompName & "'"
                Case AgL.UTrim("comp_add")
                    mCRD.DataDefinition.FormulaFields(i).Text = "'" & AgL.PubCompAdd1 & "'"
                Case AgL.UTrim("RegOffice_FullAddress")
                    mCRD.DataDefinition.FormulaFields(i).Text = "'" & AgL.PubCompAdd1 & "'"
                Case AgL.UTrim("RegOffice_City")
                    mCRD.DataDefinition.FormulaFields(i).Text = "'" & AgL.PubCompAdd2 & "'"
                Case AgL.UTrim("comp_add1")
                    mCRD.DataDefinition.FormulaFields(i).Text = "'" & AgL.PubCompAdd2 & "'"
                Case AgL.UTrim("comp_Pin")
                    mCRD.DataDefinition.FormulaFields(i).Text = "'" & AgL.PubCompPinCode & "'"
                Case AgL.UTrim("comp_phone")
                    mCRD.DataDefinition.FormulaFields(i).Text = "'" & AgL.PubCompPhone & "'"
                Case AgL.UTrim("comp_city")
                    mCRD.DataDefinition.FormulaFields(i).Text = "'" & AgL.PubCompCity & "'"
                Case AgL.UTrim("Title")
                    mCRD.DataDefinition.FormulaFields(i).Text = "'" & mRepTitle & "'"
                Case AgL.UTrim("DateBetween")
                    If Date1 <> "" And Date2 <> "" Then
                        mCRD.DataDefinition.FormulaFields(i).Text = "'" & "From Date " & Date1 & " To " & Date2 & " '"
                    ElseIf Date1 <> "" And Date2 = "" Then
                        mCRD.DataDefinition.FormulaFields(i).Text = "' " & "For Date : " & Date1 & " '"
                    End If
            End Select
        Next
    End Sub

    Public Sub ProcSaveLibraryMember(ByVal mStruct_LibraryMaster As Struct_LibraryMaster, ByVal mConn As SqlClient.SqlConnection, ByVal mCmd As SqlClient.SqlCommand)
        Dim bCondStr$ = ""

        If AgL.StrCmp(mStruct_LibraryMaster.U_AE, "A") Then
            mQry = "INSERT INTO " & AgL.PubLibraryDbName & ".dbo.Library_Member " & _
                    " ( Member_Code, Member_Name, Member_Type, Student, Employee, Father_Name, Sex, " & _
                    " U_Name, U_EntDt, U_AE ) VALUES ( " & _
                    " '" & mStruct_LibraryMaster.Member_Code & "', " & AgL.Chk_Text(mStruct_LibraryMaster.Member_Name) & ", " & AgL.Chk_Text(mStruct_LibraryMaster.Member_Type) & ", " & _
                    " " & AgL.Chk_Text(mStruct_LibraryMaster.Student) & ", " & AgL.Chk_Text(mStruct_LibraryMaster.Employee) & ", " & AgL.Chk_Text(mStruct_LibraryMaster.Father_Name) & ", " & _
                    " " & AgL.Chk_Text(mStruct_LibraryMaster.Sex) & ",  " & _
                    " " & AgL.Chk_Text(mStruct_LibraryMaster.U_Name) & ", " & AgL.Chk_Text(mStruct_LibraryMaster.U_EntDt) & ", " & AgL.Chk_Text(mStruct_LibraryMaster.U_AE) & ")"

            AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)
        Else
            bCondStr = " Where 1=1 "

            If AgL.StrCmp(mStruct_LibraryMaster.Member_Type, "Student") Then
                bCondStr += " And Student = " & AgL.Chk_Text(mStruct_LibraryMaster.Student) & " "
            ElseIf AgL.StrCmp(mStruct_LibraryMaster.Member_Type, "Employee") Then
                bCondStr += " And Employee = " & AgL.Chk_Text(mStruct_LibraryMaster.Employee) & " "
            End If

            If AgL.StrCmp(mStruct_LibraryMaster.U_AE, "E") Then
                mQry = "UPDATE " & AgL.PubLibraryDbName & ".dbo.Library_Member " & _
                        " SET " & _
                        " Member_Name = " & AgL.Chk_Text(mStruct_LibraryMaster.Member_Name) & ", " & _
                        " Member_Type = " & AgL.Chk_Text(mStruct_LibraryMaster.Member_Type) & ", " & _
                        " Father_Name = " & AgL.Chk_Text(mStruct_LibraryMaster.Father_Name) & ", " & _
                        " Sex = " & AgL.Chk_Text(mStruct_LibraryMaster.Sex) & ", " & _
                        " U_Name = " & AgL.Chk_Text(mStruct_LibraryMaster.U_Name) & ", " & _
                        " U_EntDt = " & AgL.Chk_Text(mStruct_LibraryMaster.U_EntDt) & ", " & _
                        " U_AE = " & AgL.Chk_Text(mStruct_LibraryMaster.U_AE) & " " & bCondStr
                AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)

            ElseIf AgL.StrCmp(mStruct_LibraryMaster.U_AE, "D") Then
                mQry = "DELETE FROM " & AgL.PubLibraryDbName & ".dbo.Library_Member " & bCondStr
                AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)
            End If
        End If
    End Sub

    Public Function FunGetLibraryMemberCode(ByVal mConnLibrary As SqlClient.SqlConnection, Optional ByVal mCmd As SqlClient.SqlCommand = Nothing, Optional ByVal mConnectionString As String = "") As String
        Dim bCodeStr$ = ""
        Dim GcnRead As New SqlClient.SqlConnection

        If mConnectionString <> "" Then
            GcnRead.ConnectionString = mConnectionString
        Else
            GcnRead.ConnectionString = mConnLibrary.ConnectionString
        End If
        GcnRead.Open()

        If mCmd Is Nothing Then
            mCmd = New SqlCommand
            mCmd = GcnRead.CreateCommand
        End If

        mCmd = AgL.Dman_Execute("SELECT IsNull(Max(Convert(NUMERIC,Member_Code)),0)+1 As MaxId FROM " & AgL.PubLibraryDbName & ".dbo.Library_Member Lm", GcnRead)

        bCodeStr = mCmd.ExecuteScalar().ToString.PadLeft(10, "0")

        If mConnectionString <> "" Then
            GcnRead.Dispose()
        End If

        FunGetLibraryMemberCode = bCodeStr
    End Function

    Function CanDeleteLibraryMember(ByVal mStruct_LibraryMaster As Struct_LibraryMaster, ByVal mConnLibrary As SqlClient.SqlConnection)
        Dim bRetrunVal As Boolean = True
        Try
            mQry = "Select IsNull(Count(*),0) Cnt From BookIssueEntry Where Borrower = " & AgL.Chk_Text(mStruct_LibraryMaster.Member_Code) & " "
            If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnLibrary).ExecuteScalar) > 0 Then
                bRetrunVal = False
                MsgBox("Related Record Exists In Book Issue Entry")
                Exit Function
            End If
        Catch ex As Exception
            bRetrunVal = False
        Finally
            CanDeleteLibraryMember = bRetrunVal
        End Try
    End Function

    Public Function FunGetPromotionType(ByVal bStatus As String, ByVal bIsStreamChange As String) As String
        Dim bPromotionType$ = ""

        If AgL.StrCmp(bStatus, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) Then
            If AgL.StrCmp(bIsStreamChange, "Yes") Then
                bPromotionType = Academic_ProjLib.ClsMain.PromotionType_StreamChange
            Else
                bPromotionType = Academic_ProjLib.ClsMain.PromotionType_Promotion
            End If
        ElseIf AgL.StrCmp(bStatus, Academic_ProjLib.ClsMain.AdmissionStatus_ReAdmit) Then
            bPromotionType = Academic_ProjLib.ClsMain.PromotionType_ReAdmit

        ElseIf AgL.StrCmp(bStatus, Academic_ProjLib.ClsMain.AdmissionStatus_Ex) Then
            bPromotionType = Academic_ProjLib.ClsMain.PromotionType_Ex
        End If

        FunGetPromotionType = bPromotionType
    End Function

    Public Sub ProcSaveFeeDueDetail(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, ByVal bConnRead As SqlClient.SqlConnection, ByVal bConnectionString As String, ByVal bEntryMode As String, _
                                    ByVal bFeeDueObj As Struct_FeeDue, ByVal bFeeDue1Obj() As Struct_FeeDue1, Optional ByVal bAdmissionDocId As String = "")
        Dim bQry$ = "", bFeeDue1Code$ = ""
        Dim mSr As Integer, I As Integer

        If AgL.StrCmp(bEntryMode, "Add") Then
            bQry = "INSERT INTO Sch_FeeDue " & _
                " (DocId,Div_Code,Site_Code,V_Type,V_Prefix, " & _
                " V_No,V_Date,remark,TotalAmount, StreamYearSemester,PreparedBy,U_EntDt,U_AE) " & _
                " VALUES " & _
                " (" & AgL.Chk_Text(bFeeDueObj.DocId) & ", " & AgL.Chk_Text(bFeeDueObj.Div_Code) & ", " & AgL.Chk_Text(bFeeDueObj.Site_Code) & ", " & AgL.Chk_Text(bFeeDueObj.V_Type) & ", " & AgL.Chk_Text(bFeeDueObj.V_Prefix) & ", " & _
                " " & bFeeDueObj.V_No & "," & AgL.ConvertDate(bFeeDueObj.V_Date) & ", " & _
                " " & AgL.Chk_Text(bFeeDueObj.Remark) & "," & Val(bFeeDueObj.TotalAmount) & ", " & AgL.Chk_Text(bFeeDueObj.StreamYearSemester) & "," & _
                " " & AgL.Chk_Text(AgL.PubUserName) & "," & AgL.ConvertDate(AgL.PubLoginDate) & ",'" & AgL.MidStr(bEntryMode, 0, 1) & "')"

            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)

        Else
            bQry = "UPDATE Sch_FeeDue " & _
                    " SET V_Date = " & AgL.ConvertDate(bFeeDueObj.V_Date) & ", " & _
                    " Remark=" & AgL.Chk_Text(bFeeDueObj.Remark) & ",TotalAmount=" & Val(bFeeDueObj.TotalAmount) & ", StreamYearSemester =  " & AgL.Chk_Text(bFeeDueObj.StreamYearSemester) & " , " & _
                    " U_AE = 'E',	Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ",	ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & "  " & _
                    " Where DocId = '" & bFeeDueObj.DocId & "' "

            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
        End If



        mSr = 0
        For I = 0 To UBound(bFeeDue1Obj)
            If bFeeDue1Obj(I).Code = "" Then
                If bFeeDue1Obj(I).AdmissionDocId <> "" And bFeeDue1Obj(I).Fee <> "" Then
                    bFeeDue1Code = AgL.GetMaxId("Sch_FeeDue1", "Code", bConn, bFeeDueObj.Div_Code, bFeeDueObj.Site_Code, 8, True, True, , bConnectionString)
                    bQry = "INSERT INTO dbo.Sch_FeeDue1(Code,DocId,AdmissionDocId,Fee,Amount, IsReversePostable) " & _
                           "VALUES (" & AgL.Chk_Text(bFeeDue1Code) & "," & AgL.Chk_Text(bFeeDue1Obj(I).DocId) & ", " & _
                           " " & AgL.Chk_Text(bFeeDue1Obj(I).AdmissionDocId) & "," & _
                           " " & AgL.Chk_Text(bFeeDue1Obj(I).Fee) & "," & _
                           " " & Val(bFeeDue1Obj(I).Amount) & ", " & _
                           " " & IIf(bFeeDue1Obj(I).IsReversePostable, 1, 0) & " ) "
                    AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
                End If

            Else
                If bFeeDue1Obj(I).AdmissionDocId <> "" And bFeeDue1Obj(I).Fee <> "" Then
                    bQry = "UPDATE dbo.Sch_FeeDue1 " & _
                            "SET AdmissionDocId = " & AgL.Chk_Text(bFeeDue1Obj(I).AdmissionDocId) & ", " & _
                            "	Fee = " & AgL.Chk_Text(bFeeDue1Obj(I).Fee) & ", " & _
                            "	Amount = " & bFeeDue1Obj(I).Amount & ", " & _
                            "   IsReversePostable = " & IIf(bFeeDue1Obj(I).IsReversePostable, 1, 0) & " " & _
                            "WHERE Code = '" & bFeeDue1Obj(I).Code & "' "
                    AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
                Else
                    bQry = "Delete From Sch_feeDue1 Where Code = '" & bFeeDue1Obj(I).Code & "'"
                    AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
                End If
            End If
        Next I

        If AgL.StrCmp(bEntryMode, "Edit") And bAdmissionDocId.Trim <> "" Then
            bQry = "Delete From Sch_FeeDue1 " & _
                    " Where DocId = " & AgL.Chk_Text(bFeeDueObj.DocId) & " And " & _
                    " AdmissionDocId = " & AgL.Chk_Text(bAdmissionDocId) & " And " & _
                    " Fee Not In (SELECT Afd.Fee FROM Sch_AdmissionFeeDetail Afd " & _
                    "               WHERE Afd.DocId = " & AgL.Chk_Text(bAdmissionDocId) & " AND " & _
                    "               Afd.StreamYearSemester = " & AgL.Chk_Text(bFeeDueObj.StreamYearSemester) & " And " & _
                    "               Afd.Amount > 0 ) "
            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
        End If

    End Sub

    Public Function FunFeeDueAccountPosting(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, ByVal bConnRead As SqlClient.SqlConnection, ByVal bConnectionString As String, ByVal bEntryMode As String, _
                                    ByVal bFeeDueObj As Struct_FeeDue, Optional ByVal bIsOpeningFeeDue As Boolean = False) As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer, J As Integer
        Dim DtTemp As DataTable
        Dim mNarr As String = "", mCommonNarr$ = "", bContraSub$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(bFeeDueObj.DocId, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        Dim bQry$ = ""

        bQry = "SELECT D1.DocId, D1.AdmissionDocId, D1.Fee, SUM(D1.Amount) AS Amount, Max(A.Student) as Student, Max(SgF.DispName) As FeeName " & _
               " FROM Sch_FeeDue1 D1  With (NoLock) " & _
               " Left Join Sch_Admission A With (NoLock) On D1.AdmissionDocId = A.DocId " & _
               " Left Join SubGroup SgF With (NoLock) On D1.Fee = SgF.SubCode " & _
               " Where D1.DocID = '" & bFeeDueObj.DocId & "' " & _
               " Group By D1.DocID, D1.AdmissionDocId, D1.Fee " & _
               "   "
        DtTemp = AgL.FillData(bQry, bConnRead).Tables(0)


        Dim bStudent As String
        Dim bStudentFee As Double
        Dim bStudentChangeFlag As Boolean

        I = 0
        ReDim Preserve LedgAry(I)

        For J = 0 To DtTemp.Rows.Count - 1
            If Not bIsOpeningFeeDue Then
                mNarr = "Being " & AgL.XNull(DtTemp.Rows(J)("FeeName")) & " of Rs. " & Format(AgL.VNull(DtTemp.Rows(J)("Amount")), "0.00") & " Due For " & bFeeDueObj.StreamYearSemesterDesc
                If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

                I = UBound(LedgAry) + 1
                ReDim Preserve LedgAry(I)

                LedgAry(I).SubCode = DtTemp.Rows(J)("Fee")
                LedgAry(I).ContraSub = DtTemp.Rows(J)("Student")
                LedgAry(I).AmtCr = AgL.VNull(DtTemp.Rows(J)("Amount"))
                LedgAry(I).AmtDr = 0
                LedgAry(I).Narration = mNarr
            End If

            bStudent = DtTemp.Rows(J)("Student")
            bStudentFee = bStudentFee + AgL.VNull(DtTemp.Rows(J)("Amount"))
            If bContraSub.Trim = "" And bIsOpeningFeeDue = False Then bContraSub = DtTemp.Rows(J)("Fee")

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            If J < DtTemp.Rows.Count - 1 Then
                If Not AgL.StrCmp(bStudent, DtTemp.Rows(J + 1)("Student")) Then
                    bStudentChangeFlag = True
                Else
                    bStudentChangeFlag = False
                End If
            Else
                bStudentChangeFlag = True
            End If

            If bStudentChangeFlag Then
                mNarr = "Being Total Fee of Rs. " & Format(AgL.VNull(DtTemp.Rows(J)("Amount")), "0.00") & " Due For " & bFeeDueObj.StreamYearSemesterDesc
                If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

                LedgAry(I).SubCode = bStudent
                LedgAry(I).ContraSub = bContraSub
                LedgAry(I).AmtCr = 0
                LedgAry(I).AmtDr = bStudentFee
                LedgAry(I).Narration = mNarr

                bStudentFee = 0
                bStudentChangeFlag = False
                bContraSub = ""

                I = UBound(LedgAry) + 1
                ReDim Preserve LedgAry(I)
            End If
        Next

        mCommonNarr = bFeeDueObj.Remark
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDueLedgerM Where DocId = '" & bFeeDueObj.DocId & "'", bConn, bCmd)
        If AgL.LedgerPost(AgL.MidStr(bEntryMode, 0, 1), LedgAry, bConn, bCmd, bFeeDueObj.DocId, CDate(bFeeDueObj.V_Date), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, bIsOpeningFeeDue, bConnectionString) = False Then
            FunFeeDueAccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

        bQry = "INSERT INTO Sch_FeeDueLedgerM ( DocId ) VALUES ( " & _
                " '" & bFeeDueObj.DocId & "' )"
        AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)

    End Function

    Public Sub ProcSaveFamilyIncome(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, _
                                    ByVal bEntryMode As String, ByVal bIncomeObj As Struct_StudentFamilyIncome, _
                                    Optional ByVal IsCallFromFamilyIncome As Boolean = False)

        Dim bQry$ = "", bLastDate$ = ""

        If IsCallFromFamilyIncome Then
            mQry = "SELECT Max(Sfi.AsOnDate) " & _
                    " FROM Sch_StudentFamilyIncome Sfi With (NoLock) " & _
                    " WHERE Sfi.Student = '" & bIncomeObj.Student & "' "

            bLastDate = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar

            If CDate(bLastDate) <= CDate(bIncomeObj.AsOnDate) Then
                mQry = " UPDATE Sch_Student " & _
                        " SET 	" & _
                        " Occupation =" & AgL.Chk_Text(bIncomeObj.FatherOccupation) & ",	" & _
                        " FamilyIncome =" & Val(bIncomeObj.FamilyIncome) & ",	" & _
                        " FatherCompany = " & AgL.Chk_Text(bIncomeObj.FatherCompany) & ", " & _
                        " FatherCompanyAddress = " & AgL.Chk_Text(bIncomeObj.FatherCompanyAddress) & ", " & _
                        " FatherDesignation = " & AgL.Chk_Text(bIncomeObj.FatherDesignation) & ", " & _
                        " MotherOccupation = " & AgL.Chk_Text(bIncomeObj.MotherOccupation) & ", " & _
                        " MotherCompany = " & AgL.Chk_Text(bIncomeObj.MotherCompany) & ", " & _
                        " MotherCompanyAddress = " & AgL.Chk_Text(bIncomeObj.MotherCompanyAddress) & ", " & _
                        " MotherDesignation = " & AgL.Chk_Text(bIncomeObj.MotherDesignation) & ", " & _
                        " MotherIncome = " & Val(bIncomeObj.MotherIncome) & ", " & _
                        " FatherIncome = " & Val(bIncomeObj.FatherIncome) & " " & _
                        " WHERE SubCode= '" & bIncomeObj.Student & "'"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If
        End If

        If AgL.StrCmp(bEntryMode, "Add") Then
            bQry = "INSERT INTO dbo.Sch_StudentFamilyIncome (GUID, Student, AsOnDate, FatherIncome, " & _
                        " MotherIncome, FamilyIncome, " & _
                        " FatherOccupation, FatherCompany, FatherCompanyAddress, FatherDesignation, " & _
                        " MotherOccupation, MotherCompany, " & _
                        " MotherCompanyAddress, MotherDesignation, " & _
                        " Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES (" & AgL.Chk_Text(bIncomeObj.GUID) & ", " & AgL.Chk_Text(bIncomeObj.Student) & ", " & _
                        " " & AgL.ConvertDate(bIncomeObj.AsOnDate) & ", " & _
                        " " & Val(bIncomeObj.FatherIncome) & ", " & Val(bIncomeObj.MotherIncome) & ", " & _
                        " " & Val(bIncomeObj.FamilyIncome) & ", " & AgL.Chk_Text(bIncomeObj.FatherOccupation) & ", " & _
                        " " & AgL.Chk_Text(bIncomeObj.FatherCompany) & ", " & AgL.Chk_Text(bIncomeObj.FatherCompanyAddress) & ", " & _
                        " " & AgL.Chk_Text(bIncomeObj.FatherDesignation) & ", " & AgL.Chk_Text(bIncomeObj.MotherOccupation) & ", " & _
                        " " & AgL.Chk_Text(bIncomeObj.MotherCompany) & ", " & AgL.Chk_Text(bIncomeObj.MotherCompanyAddress) & ", " & _
                        " " & AgL.Chk_Text(bIncomeObj.MotherDesignation) & ", '" & bIncomeObj.Div_Code & "', " & _
                        " " & AgL.Chk_Text(bIncomeObj.Site_Code) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & "," & AgL.ConvertDate(AgL.PubLoginDate) & ",'" & AgL.MidStr(bEntryMode, 0, 1) & "')"

            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)

        Else
            bQry = "Update Sch_StudentFamilyIncome " & _
                      " SET  " & _
                      " Student = " & AgL.Chk_Text(bIncomeObj.Student) & ", " & _
                      " AsOnDate = " & AgL.ConvertDate(bIncomeObj.AsOnDate) & ", " & _
                      " FatherIncome = " & Val(bIncomeObj.FatherIncome) & ", " & _
                      " MotherIncome = " & Val(bIncomeObj.MotherIncome) & ", " & _
                      " FamilyIncome = " & Val(bIncomeObj.FamilyIncome) & ", " & _
                      " FatherOccupation = " & AgL.Chk_Text(bIncomeObj.FatherOccupation) & ", " & _
                      " FatherCompany = " & AgL.Chk_Text(bIncomeObj.FatherCompany) & ", " & _
                      " FatherCompanyAddress = " & AgL.Chk_Text(bIncomeObj.FatherCompanyAddress) & ", " & _
                      " FatherDesignation = " & AgL.Chk_Text(bIncomeObj.FatherDesignation) & ", " & _
                      " MotherOccupation = " & AgL.Chk_Text(bIncomeObj.MotherOccupation) & ", " & _
                      " MotherCompany = " & AgL.Chk_Text(bIncomeObj.MotherCompany) & ", " & _
                      " MotherCompanyAddress = " & AgL.Chk_Text(bIncomeObj.MotherCompanyAddress) & ", " & _
                      " MotherDesignation = " & AgL.Chk_Text(bIncomeObj.MotherDesignation) & ", " & _
                      " U_AE = 'E',	Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ",	ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & "  " & _
                      " WHERE GUID = '" & bIncomeObj.GUID & "' "

            AgL.Dman_ExecuteNonQry(bQry, bConn, bCmd)
        End If
    End Sub
End Class
