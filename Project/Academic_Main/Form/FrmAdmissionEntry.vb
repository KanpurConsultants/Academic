Imports System.IO
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmAdmissionEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode
    Dim mLastSessionProgrammeStreamDesc$ = "", mLastFromStreamYearSemesterCode_Fee$ = "", mLastToStreamYearSemesterCode_Fee$ = "", mLastFromStreamYearSemesterCode_Subject$ = "", mLastToStreamYearSemesterCode_Subject$ = ""

    Dim mBlnImprtFromExcelFlag As Boolean = False, mBlnIsSemFeeExists As Boolean = False

    Dim mIsPromotionDetailExists As Boolean = False, mIsSubjectLocked As Boolean = False, mIsFeeLocked As Boolean = False, mIsNewAdmissionPromotion As Boolean = False
    Dim mBlnIsLibraryMemberExists As Boolean = False
    Dim mBlnIsTransportMemberExists As Boolean = False
    Dim mBlnIsMessMemberExists As Boolean = False

    Dim mFeeDueDocId$ = "", mCurrentSemesterStartDate$ = ""

    Dim mFirstStreamCode$ = "", mFromSemesterStreamCode$ = "", mToSemesterStreamCode$ = "", mCurrentSemesterStreamCode$ = ""
    Dim mProgrammeCode$ = "", mNewProgrammeCode$ = "", mCurrentStreamYearSemester$ = ""
    Dim mFromSemesterSerialNo As Integer = 0, mToSemesterSerialNo As Integer = 0, mCurrentSemesterSerialNo As Integer = 0

    Dim mObjClsMain As New ClsMain(AgL, PLib)
    Dim mObjStructLibraryMember As ClsMain.StructLibraryMember = Nothing
    Dim mObjStructTransportMember As ClsMain.StructTransportMember = Nothing
    Dim mObjStructMessMember As ClsMain.StructMessMember = Nothing

    Protected Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1StreamYearSemester As Byte = 1
    Protected Const Col1Fee As Byte = 2
    Protected Const Col1Amount As Byte = 3
    Protected Const Col1FeeStreamYearSemester As Byte = 4

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Protected Const Col2SemesterSubject As Byte = 1
    Protected Const Col2Subject As Byte = 2
    Protected Const Col2ManualCode As Byte = 3
    Protected Const Col2PaperID As Byte = 4
    Protected Const Col2MinCreditHours As Byte = 5
    Protected Const Col2IsSubjectSelected As Byte = 6
    Protected Const Col2IsElectiveSubject As Byte = 7
    Protected Const Col2OtherSemesterSubject As Byte = 8

    Public WithEvents DGL3 As New AgControls.AgDataGrid
    Protected Const Col3DocumentCode As String = "Document"
    Protected Const Col3BtnAttachment As String = ""
    Protected Const Col3ByteArray As String = "Byte Array"
    Protected Const Col3FileName As String = "File Name"
    Protected Const Col3BlobSr As String = "Temp Sr"

    Public WithEvents DGL4 As New AgControls.AgDataGrid
    Protected Const Col4FromStreamYearSemester As Byte = 1
    Protected Const Col4PromotionDate As Byte = 2
    Protected Const Col4ToStreamYearSemester As Byte = 3
    Protected Const Col4PromotionType As Byte = 4

    Dim mFrmObjTransportInfo As Form = Nothing
    Dim mBlnIsUserCanApprove As Boolean = False, mBlnIsAutoApproved As Boolean = False
    Dim _FormType As eFormType
    Dim FormLocation As New System.Drawing.Point(0, 0)
   

    Public Enum eFormType
        AdmissionEntry
        AdmissionEntryAuthenticated
    End Enum

    Public Property FormType() As eFormType
        Get
            FormType = _FormType
        End Get
        Set(ByVal value As eFormType)
            _FormType = value
        End Set
    End Property

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        ''==============================================================================
        ''================< Semester/Fee Data Grid >====================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1StreamYearSemester", 300, 50, "Semester", True, True, False, True)
            .AddAgTextColumn(DGL1, "DGL1Fee", 420, 50, "Fee Head", True, False, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 100, 8, 2, False, "Amount", True, False, True, True)
            .AddAgTextColumn(DGL1, "DGL1FeeStreamYearSemester", 200, 50, "FeeStreamYearSemester", False, True, False, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40

        DGL1.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        LblFeeDetail.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        BtnFillFee.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        ''==============================================================================
        ''================< Semester/Subject Data Grid >================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "Dgl2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "Dgl2StreamYearSemester", 220, 50, "Semester", True, True, False, True)
            .AddAgTextColumn(DGL2, "Dgl2SemesterSubject", 350, 73, "Subject", True, True, False, True)
            .AddAgTextColumn(DGL2, "Dgl2ManualCode", 80, 50, "Manual Code", True, True, False, True)
            .AddAgTextColumn(DGL2, "Dgl2PaperID", 60, 50, "Paper ID", True, True, False, True)
            .AddAgNumberColumn(DGL2, "Dgl2MinCreditHours", 50, 3, 2, False, "Credit Hrs.", True, True, True)
            .AddAgListColumn(DGL2, "Yes,No", "Dgl2IsSubjectSelected", 60, "1,0", "Yes/No", True, False)
            .AddAgTextColumn(DGL2, "Dgl2IsElectiveSubject", 100, 1, "IsElectiveSubject", False, True, False)
            .AddAgTextColumn(DGL2, "Dgl2OtherSemesterSubject", 200, 1, "Subject Swap", False, True, False)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 40
        DGL2.AllowUserToAddRows = False

        ''==============================================================================
        ''================< Document Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL3, "DGL3SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL3, Col3DocumentCode, 200, 0, Col3DocumentCode, True, False, False)
            .AddAgButtonColumn(DGL3, Col3BtnAttachment, 40, Col3BtnAttachment, True, False, , , , "Webdings", 10, "6")
            .AddAgTextColumn(DGL3, Col3FileName, 100, 255, Col3FileName, True, True, False)
            .AddAgImageColumn(DGL3, Col3ByteArray, 100, Col3ByteArray, False, True, False)
            .AddAgTextColumn(DGL3, Col3BlobSr, 100, 0, Col3BlobSr, False, True, False)
        End With
        AgL.AddAgDataGrid(DGL3, Pnl3)
        DGL3.AgSkipReadOnlyColumns = True

        ''==============================================================================
        ''================< Promotion Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL4, "DGL4SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL4, "Dgl4FromStreamYearSemester", 240, 8, "From Semester", True, True, False)
            .AddAgDateColumn(DGL4, "Dgl4PromotionDate", 80, "Promotion Date", True, True, False)
            .AddAgTextColumn(DGL4, "Dgl4ToStreamYearSemester", 240, 8, "To Semester", True, True, False)
            .AddAgTextColumn(DGL4, "Dgl4PromotionType", 120, 20, "Promotion Type", True, True, False)

        End With
        AgL.AddAgDataGrid(DGL4, Pnl4)
        DGL4.ColumnHeadersHeight = 40
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F4 Or e.KeyCode = (Keys.F And e.Control) Or e.KeyCode = (Keys.P And e.Control) _
        Or e.KeyCode = (Keys.S And e.Control) Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 _
        Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.End Then
            Topctrl1.TopKey_Down(e)
        End If

        If Me.ActiveControl IsNot Nothing Then
            If Me.ActiveControl.Name <> Topctrl1.Name And _
                Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If

            If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)
        End If
    End Sub

    Private Sub OpenLinkForm(ByVal Sender As Object)
        Dim FrmObj As Form
        Try
            Me.Cursor = Cursors.WaitCursor
            If Topctrl1.Mode = "Browse" Then Exit Sub
            Select Case Sender.name
                Case TxtStudent.Name
                    If Academic_ProjLib.ClsMain.IsModuleActive_AcademicMain Then
                        FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_StudentMaster, Academic_Objects.ClsConstant.MenuText_Main_StudentMaster, Me.MdiParent)
                    Else
                        If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                            FrmObj = PObj.FOpen_LinkForm_Academic_Fee(Academic_Objects.ClsConstant.MenuName_Fee_StudentMaster, Academic_Objects.ClsConstant.MenuText_Fee_StudentMaster, Me.MdiParent)
                        Else
                            FrmObj = Nothing
                        End If
                    End If

                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmStudentMaster).RegistrationDocId = TxtRegistrationDocId.AgSelectedValue
                        CType(FrmObj, FrmStudentMaster).AsOnDate = TxtV_Date.Text
                    End If
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            TxtLibraryMemberType.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Library
            LblLibraryMemberType.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Library


            TxtlibrarySite.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Library
            lblLibrarySite.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Library

            TxtIsTransport.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Transport
            lblIsTransport.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Transport

            TxtIsMess.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Mess
            lblIsMess.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Mess
            txtMessJoinDt.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Mess
            lblMessjoinDt.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Mess

            AgL.WinSetting(Me, 667, 950, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGL3)
            AgL.GridDesign(DGL4)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            Topctrl1.ChangeAgGridState(DGL3, False)
            Topctrl1.ChangeAgGridState(DGL4, False)
            If AgL.PubMoveRecApplicable Then FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr As String


        If AgL.PubMoveRecApplicable Then
            mCondStr = " Where A.V_Date <=  '" & AgL.PubEndDate & "' " & _
                       " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            If _FormType = eFormType.AdmissionEntry Then
                mCondStr += " And IsNull(A.ApprovedBy,'')='' "
            ElseIf _FormType = eFormType.AdmissionEntryAuthenticated Then
                mCondStr += " And IsNull(A.ApprovedBy,'')<>'' "
            End If

            mQry = "Select A.DocId As SearchCode " & _
                    " From Sch_Admission A " & _
                    " LEFT JOIN Voucher_Type Vt ON A.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Dim MDI As New MDIMain
        Try
            If mBlnImprtFromExcelFlag = False Then
                mBlnIsUserCanApprove = AgL.FunHaveControlPermission(FunGetModuleName, MDI.MnuAmAdmissionEntry.Text, AgL.PubUserName, GroupBox1.Text)
            Else
                mBlnIsUserCanApprove = False
            End If


            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Code As Code, Name As Name From SiteMast " & _
               " Where 1=1 and isnull(IsLibrary,'')<>0 Order By Name"
            TxtlibrarySite.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)


            mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
                  " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_StudentAdmission) & "" & _
                  " Order By Description"
            TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.SubCode AS Code, Sg.Name, Sg.ManualCode, S.FirstName, S.MiddleName, S.LastName, S.Sex, S.NationalityCode, " & _
                      " S.Occupation, S.MotherName, S.MotherNamePrefix, S.FamilyIncome, S.Religion, S.Category, S.IsInternationalStudent," & _
                      " S.PassportNo, S.VisaExpiryDate, S.VisaType, S.EnglishProficiency_IELTS, S.EnglishProficiency_TOEFL, " & _
                      " S.EnglishProficiency_Others, S.BloodGroup, Sg.FatherNamePrefix , Sg.FatherName, Sg.Add1 , Sg.Add2 , Sg.Add3 ," & _
                      " Sg.CityCode, Sg.PIN , Sg.Phone , Sg.Mobile , Sg.EMail, Sg.DOB, " & _
                      " S.FatherCompany, S.FatherCompanyAddress, S.FatherDesignation, S.MotherOccupation, S.MotherCompany, S.MotherCompanyAddress, " & _
                      " S.MotherDesignation, S.MotherIncome, S.MarkOfId, S.TAdd1, S.TAdd2, S.TAdd3, S.TCityCode, S.TPin, S.TPhone, S.TMobile, S.TFax,  S.LocalGuardian, " & _
                      " Sg.PAdd1, Sg.PAdd2, Sg.PAdd3, Sg.PCityCode, Sg.PPin, Sg.PPhone, Sg.PMobile, Sg.PFax, S.FatherIncome " & _
                      " From Sch_Student S " & _
                      " Left Join SubGroup Sg On Sg.SubCode = S.SubCode " & _
                      " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                      " Order By Sg.Name "
            TxtStudent.AgHelpDataSet(58) = AgL.FillData(mQry, AgL.GCn)

            TxtCategory.AgHelpDataSet = AgL.FillData("SELECT C.Code , C.ManualCode AS Name FROM Sch_Category C Order By C.ManualCode ", AgL.GCn)

            mQry = "SELECT R.Code, R.Description AS Religion FROM Sch_Religion R ORDER BY R.Description "
            TxtReligion.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Vs.Code , VS.SessionProgrammeStream Name, VS.SessionProgramme, VS.SessionStartDate, " & _
                    " Vs.Stream AS StreamCode, Vs.ProgrammeCode, VS.SessionManualCode, VS.ProgrammeManualCode, VS.StreamManualCode " & _
                    " FROM ViewSch_SessionProgrammeStream VS " & _
                    " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY VS.SessionProgrammeStream "
            TxtSessionProgrammeStream.AgHelpDataSet(7) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT VSem.Code , VSem.StreamYearSemesterDesc AS Semester, VSem.SemesterStartDate , VYear.SessionProgrammeStreamCode,  " & _
                    " VSem.SessionProgrammeCode, VSem.SemesterSerialNo, VSem.SessionStartDate, VSem.StreamCode, VSem.ProgrammeCode, " & _
                    " VSem.SemesterDesc, VSem.SessionManualCode, VSem.ProgrammeManualCode, Vsem.StreamManualCode " & _
                    " FROM ViewSch_StreamYearSemester VSem " & _
                    " LEFT JOIN ViewSch_SessionProgrammeStreamYear VYear ON VSem.SessionProgrammeStreamYear = VYear.SessionProgrammeStreamYearCode " & _
                    " Where " & AgL.PubSiteCondition("VSem.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By VYear.SessionProgrammeStreamCode, VSem.SemesterStartDate "
            TxtAdmissionSemester.AgHelpDataSet(11) = AgL.FillData(mQry, AgL.GCn)
            TxtPromotionSemester.AgHelpDataSet(11) = TxtAdmissionSemester.AgHelpDataSet.Copy
            DGL4.AgHelpDataSet(Col4FromStreamYearSemester, 11) = TxtAdmissionSemester.AgHelpDataSet.Copy
            DGL4.AgHelpDataSet(Col4ToStreamYearSemester, 11) = TxtAdmissionSemester.AgHelpDataSet.Copy

            mQry = "SELECT N.Code , N.Description AS Name, N.ManualCode FROM Sch_AdmissionNature N ORDER BY N.Description "
            TxtAdmissionNature.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT R.DocId AS Code, " & AgL.V_No_Field("R.DocId") & " As [Voucher No], " & _
                    " Rs.FirstName + CASE WHEN Rs.MiddleName IS NULL THEN space(1) ELSE Rs.MiddleName + Space(1) END + rs.LastName As [Student Name], R.ManualRegNo As [Manual Registration No], Vs.SessionProgramme Proramme, " & _
                    " R.SessionProgramme , R.AdmissionNature , R.SessionProgrammeStream , Rs.Student, " & _
                    " R.SessionCode, R.ProgrammeCode, R.SessionStartDate, S.Stream As StreamCode, " & _
                    " IsNull(R.AdmissionDocId,'') As AdmissionDocId, CASE WHEN IsNull(R.AdmissionDocId,'') = '' THEN 'No' ELSE 'Yes' END IsAdmited, R.EnquiryDocId " & _
                    " FROM ViewSch_Registration R " & _
                    " LEFT JOIN Sch_RegistrationStudentDetail Rs ON R.DocId = Rs.DocId " & _
                    " Left Join ViewSch_SessionProgramme Vs On R.SessionProgramme = Vs.Code " & _
                    " Left Join ViewSch_SessionProgrammeStream S On S.Code = S.SessionProgrammeStream " & _
                    " Where R.V_Date < = " & AgL.ConvertDate(AgL.PubEndDate) & " And " & _
                    " IsNull(R.IsCancelled,0) = 0 And " & _
                    " " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " "
            TxtRegistrationDocId.AgHelpDataSet(10) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT D.Code , D.Description AS Name  FROM Sch_Document D ORDER BY D.Description "
            DGL3.AgHelpDataSet(Col3DocumentCode, , Tc1.Top + Tp4.Top, Tc1.Left + Tp4.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Ss.Code, Vs.StreamYearSemesterDesc AS Semester, S.Description AS Subject, Ss.Subject AS SubjectCode, " & _
                    " Ss.StreamYearSemester, Ss.ManualCode, Ss.PaperID, Ss.MinCreditHours, Ss.IsElectiveSubject " & _
                    " FROM Sch_SemesterSubject Ss " & _
                    " LEFT JOIN Sch_Subject S ON Ss.Subject = S.Code " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Vs ON Ss.StreamYearSemester = Vs.Code " & _
                    " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY Vs.SemesterStartDate , Vs.StreamYearSemesterDesc, S.Description "
            DGL2.AgHelpDataSet(Col2SemesterSubject, 6, Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)
            DGL2.AgHelpDataSet(Col2OtherSemesterSubject, 6, Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = DGL2.AgHelpDataSet(Col2SemesterSubject).Copy

            mQry = "SELECT S.Code, S.Description AS Name " & _
                    " FROM Sch_Subject S " & _
                    " ORDER BY S.Description "
            DGL2.AgHelpDataSet(Col2Subject, , Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Vs.Code, Vs.StreamYearSemesterDesc AS Semester " & _
                    " FROM ViewSch_StreamYearSemester Vs " & _
                    " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY Vs.SemesterStartDate , Vs.StreamYearSemesterDesc "
            DGL1.AgHelpDataSet(Col1StreamYearSemester, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)
            DGL1.AgHelpDataSet(Col1FeeStreamYearSemester, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = DGL2.AgHelpDataSet(Col2SemesterSubject).Copy

            mQry = "SELECT F.Code, Sg.DispName [Fee Head], F.FeeNature, F.Refundable " & _
                    " FROM Sch_Fee F " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode = F.Code " & _
                    " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " And " & _
                    " F.FeeNature  NOT IN ('" & Academic_ProjLib.ClsMain.FeeNature_LateFee & "', '" & Academic_ProjLib.ClsMain.FeeNature_Fine & "') " & _
                    " ORDER BY F.FeeNature , Sg.Name "
            DGL1.AgHelpDataSet(Col1Fee, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Vs.Code , VS.SessionProgramme, Vs.SessionManualCode, VS.ProgrammeManualCode " & _
                    " FROM ViewSch_SessionProgramme VS " & _
                    " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY VS.SessionProgramme "
            TxtSessionProgramme.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            AgCL.IniAgHelpList(TxtStatus, PubAdmissionStatusStr)

            mQry = "SELECT T.Code, T.Description, " & _
                   " CASE WHEN IsNull(T.IsDeleted,0) <> 0 THEN 'Yes' ELSE 'No' END AS IsDeleted " & _
                   " FROM Lib_MemberType T With (NoLock) Where " & AgL.PubSiteCondition("T.Site_Code", AgL.PubSiteCode) & "" & _
                   " ORDER BY T.Description "
            TxtLibraryMemberType.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            If AgL.IsTableExist("Enquiry_Enquiry", AgL.GCn) Then
                mQry = "SELECT H.DocId AS Code," & AgL.V_No_Field("H.DocId") & " As [Enquiry No], SG.DispName AS [Enquiry By], " & _
                        " isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS Name, " & _
                        " H.Status, H.EnquiryMode AS [Enquiry Mode],C.CityName AS City,isnull(H.IsClosed,0)  AS IsClosed, " & _
                        " H.V_Date As EnquiryDate, H.Employee As EmployeeCode, H.AssignedTo As AssignedToCode,  " & _
                        " R.DocId As RegistrationDocId, A.DocId As AdmissionDocId " & _
                        " FROM Enquiry_Enquiry H  " & _
                        " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee " & _
                        " LEFT JOIN SubGroup E2 ON E2.SubCode=H.AssignedTo " & _
                        " LEFT JOIN City C ON C.CityCode=H.CityCode  " & _
                        " LEFT JOIN Sch_Registration R ON H.DocId = R.EnquiryDocId " & _
                        " LEFT JOIN Sch_Admission A ON H.DocId = A.EnquiryDocId " & _
                        " Where H.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                        " Order By H.V_Date Desc, H.DocId "
                TxtEnquiryDocId.AgHelpDataSet(8) = AgL.FillData(mQry, AgL.GCn)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim I As Integer = 0
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            If mSearchCode <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    ''==========================================================================================================================================
                    ''==================================< Delete From Library Member Start >====================================================================
                    ''==========================================================================================================================================
                    AgL.Dman_ExecuteNonQry("Delete From Lib_Member Where SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & "", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Lib_Member_Log Where SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & "", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Tp_Member Where SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & "", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Tp_Member_Log Where SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & "", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Mess_Member Where SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & "", AgL.GCn, AgL.ECmd)
                    ''==========================================================================================================================================
                    ''==================================< Delete From Library Member End >====================================================================
                    ''==========================================================================================================================================

                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionFeeDue Where AdmissionDocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDueLedgerM Where DocId = '" & mFeeDueDocId & "'", AgL.GCn, AgL.ECmd)
                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mFeeDueDocId)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDue1 Where DocId = '" & mFeeDueDocId & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDue Where DocId = '" & mFeeDueDocId & "'", AgL.GCn, AgL.ECmd)

                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionDocument Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionSubject Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionFeeDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionStatusChangeDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionPromotion Where AdmissionDocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_Admission Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, TxtStatus.Text, TxtV_Date.Text, TxtStudent.AgSelectedValue, TxtStudent.Text, , TxtSite_Code.AgSelectedValue, AgL.PubDivCode)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

                    AgL.ETrans.Commit()
                    mTrans = False


                    If AgL.XNull(AgL.PubImageDBName).ToString.Trim <> "" Then
                        With DGL3
                            For I = 0 To .Rows.Count - 1
                                If .Item(Col3DocumentCode, I).Value <> "" _
                                    And AgL.VNull(.Item(Col3BlobSr, I).Value) > 0 Then
                                    Try
                                        mQry = "Delete From SubGroup_BLOB " & _
                                                " Where SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & " " & _
                                                " And Sr = " & Val(.Item(Col3BlobSr, I).Value) & " "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GcnImage)
                                    Catch ex As Exception

                                    End Try
                                End If
                            Next
                        End With
                    End If

                    If AgL.PubMoveRecApplicable Then
                        FIniMaster(1)
                        Topctrl_tbRef()
                    Else
                        AgL.PubSearchRow = ""
                    End If
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl_tbDiscard() Handles Topctrl1.tbDiscard
        If AgL.PubMoveRecApplicable Then FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtV_Date.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where A.V_Date <= '" & AgL.PubEndDate & "' " & _
                       " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            If _FormType = eFormType.AdmissionEntry Then
                mCondStr += " And IsNull(A.ApprovedBy,'')='' "
            ElseIf _FormType = eFormType.AdmissionEntryAuthenticated Then
                mCondStr += " And IsNull(A.ApprovedBy,'')<>'' "
            End If

            AgL.PubFindQry = "SELECT A.DocId As SearchCode, " & AgL.V_No_Field("A.DocId") & " As [Voucher No], A.AdmissionID , A.StudentName , " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], A.V_Date, " & _
                                " A.SessionProgrammeStreamDesc As Stream, N.Description AS [Admission Nature] , " & AgL.V_No_Field("A.RegistrationDocId") & " [Registration VNo], " & _
                                " A.ManualRegNo  AS [Manual Registration No], A.EnrollmentNo , A.RollNo, A.FatherName As [Father Name] , A.MotherName As [Mother Name] , " & _
                                " A.Phone , A.Mobile , A.CityName As City " & _
                                " FROM ViewSch_Admission A " & _
                                " LEFT JOIN Sch_AdmissionNature N ON A.AdmissionNature = N.Code " & _
                                " LEFT JOIN Voucher_Type Vt ON A.V_Type = Vt.V_Type " & _
                                " LEFT JOIN SiteMast S ON A.Site_Code = S.Code " & mCondStr

            AgL.PubFindQryOrdBy = "[Voucher No]"


            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                If AgL.PubMoveRecApplicable Then
                    AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                    BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                End If
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl_tbPrn() Handles Topctrl1.tbPrn
        Call PrintDocument(mSearchCode)
    End Sub

    Private Sub PrintDocument(ByVal mDocId As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            'Me.Cursor = Cursors.WaitCursor

            'AgL.PubReportTitle = "Sale Bill"
            'RepName = "SaleInvoice" : RepTitle = "Sale Invoice"

            'If mDocId = "" Then
            '    MsgBox("No Records Found to Print!!!", vbInformation, "Information")
            '    Me.Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'strQry = "SELECT S.DocId,Vt.Description AS V_TypeDesc,S.V_Prefix,S.V_No,S.V_Date, " & _
            '            "S.SaleOrderDocId,S.SaleDocId,S.CashCredit,C.Name As Customer_AC,S.PartyName, " & _
            '            "S.Add1,S.Add2,S.Add3,S.CityCode,SMan.Name AS SalesMan_Name,Astro.Name AS Astrologer_Name, " & _
            '            "S.Amount AS Amount_H,S.Scheme AS SchemeAmt_H, " & _
            '            "S.Addition AS Addition_H,S.Deduction AS Deduction_H,S.TaxableAmt AS TaxableAmt_H, " & _
            '            "S.TaxPer AS TaxPer_H,S.TaxAmt AS TaxAmt_H,S.AdditionalTaxPer AS AdditionalTaxPer_H, " & _
            '            "S.AdditionalTaxAmt AS AdditionalTaxAmt_H,S.Labour AS Labour_H, " & _
            '            "S.AdditionAfterTax_Per AS AdditionAfterTax_Per_H,S.AdditionAfterTax AS AdditionAfterTax_H, " & _
            '            "S.DeductionAfterTax_Per AS DeductionAfterTax_Per_H,S.DeductionAfterTax AS DeductionAfterTax_H, " & _
            '            "S.TotalAmount AS TotalAmount_H,S.RoundOff AS RoundOff_H,S.NetAmount AS NetAmount_H, " & _
            '            "S.Advance AS Advance_H,S.Balance AS Balance_H,S.Remark AS Remark_H,S.PreparedBy, " & _
            '            "S.U_EntDt,S.U_AE,S.Edit_Date,S.ModifiedBy,Stk.Sr,Stk.OrderDocId,Stk.ReferenceDocID, " & _
            '            "Stk.BarCode,Scheme.Description AS SchemeDescription,Stk.Item,(Case When Stk.ItemDesc Is Null Then I.Description Else Stk.ItemDesc End) As ItemDesc, U.Description As Unit, " & _
            '            "TFL.Description AS TaxForm_L,Stk.SchemeYn,Stk.GroupReceiveQty,Stk.GroupIssueQty,Stk.ReceiveQty, " & _
            '            "Stk.IssueQty,Stk.PrintQty,Stk.Rate,Stk.Amount,Stk.Addition,Stk.Deduction,Stk.TaxableAmt, " & _
            '            "Stk.TaxPer,Stk.TaxAmt,Stk.AdditionalTaxPer,Stk.AdditionalTaxAmt,Stk.AdditionAfterTax, " & _
            '            "Stk.DeductionAfterTax, Stk.NetAmount, Stk.CentralTaxAmt, Stk.LandedRate, Stk.LandedAmount, Stk.Remark, Site.Name As SiteName " & _
            '            "FROM Sale S " & _
            '            "LEFT JOIN Stock Stk ON S.DocId = Stk.DocId " & _
            '            "LEFT JOIN Voucher_Type Vt ON s.V_Type =Vt.V_Type " & _
            '            "LEFT JOIN SubGroup C ON S.Customer = C.SubCode " & _
            '            "LEFT JOIN SubGroup SMan ON S.SalesMan = SMan.SubCode " & _
            '            "LEFT JOIN SubGroup Astro ON S.Astrologer  = Astro.SubCode " & _
            '            " " & _
            '            "LEFT JOIN SCHEME ON Stk.Scheme = Scheme.Code " & _
            '            "LEFT JOIN TaxForm TfL ON Stk.TaxForm =TFL.Code " & _
            '            "Left Join Item I On Stk.Item = I.Code " & _
            '            "Left Join Unit U On I.Unit = U.Code " & _
            '            "Left Join SiteMast Site On I.Site_Code = Site.Code " & _
            '            "Where S.DocId = '" & mDocId & "' "


            'AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            'AgL.ADMain.Fill(DsRep)


            'AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic & "\" & RepName & ".ttx", True)
            'mCrd.Load(PLib.PubReportPath_Academic & "\" & RepName & ".rpt")
            'mCrd.SetDataSource(DsRep.Tables(0))
            'CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            'PLib.Formula_Set(mCrd, RepTitle)
            'AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            'Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, mSr As Integer = 0
        Dim mTrans As Boolean = False
        Dim GcnRead As SqlClient.SqlConnection
        Dim bStrApprovedDate$ = ""

        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub

            If mBlnIsUserCanApprove Then bStrApprovedDate = AgL.GetDateTime(AgL.GCn)

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_Admission ( DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, RegistrationDocId, " & _
                        " AdmissionNature, SessionProgrammeStream, SessionProgramme, Student, AdmissionID, Remark, ScholarshipApplied, Status, " & _
                        " Rank, RankRemark, MeritPercentage, MeritRemark, IsFeeWavier, IsDiplomaHolder, CounselingFee, CounselingFeeReceiptNo, " & _
                        " AdmissionSemester, PromotionSemester, " & _
                        " PreparedBy, U_EntDt, U_AE, EnquiryDocId) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & "," & _
                        " " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & ", " & AgL.Chk_Text(TxtAdmissionNature.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtAdmissionID.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & IIf(AgL.StrCmp(TxtScholarshipApplied.Text, "Yes"), 1, 0) & ", " & AgL.Chk_Text(TxtStatus.Text) & "," & _
                        " " & Val(TxtRank.Text) & ", " & AgL.Chk_Text(TxtRankRemark.Text) & ", " & Val(TxtMeritPercentage.Text) & ", " & AgL.Chk_Text(TxtMeritRemark.Text) & ", " & _
                        " " & IIf(AgL.StrCmp(TxtIsFeeWavier.Text, "Yes"), 1, 0) & ", " & IIf(AgL.StrCmp(TxtIsDiplomaHolder.Text, "Yes"), 1, 0) & ", " & _
                        " " & Val(TxtCounselingFee.Text) & ", " & AgL.Chk_Text(TxtCounselingFeeReceiptNo.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtAdmissionSemester.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtPromotionSemester.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A', " & AgL.Chk_Text(TxtEnquiryDocId.AgSelectedValue) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


                '===============================================================================================================================================
                '==================< INSERT FIRST RECORD IN >===================================================================================================
                '================< Sch_AdmissionPromotion Table >===============================================================================================
                '===============================================================================================================================================

                mQry = "INSERT INTO Sch_AdmissionPromotion ( " & _
                        " AdmissionDocId, Sr, FromStreamYearSemester,PromotionDate, ToStreamYearSemester, PromotionType, " & _
                        " PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', 1, " & AgL.Chk_Text(TxtAdmissionSemester.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(IIf(TxtPromotionSemester.Text.Trim = "", "", TxtV_Date.Text).ToString) & ", " & _
                        " " & AgL.Chk_Text(TxtPromotionSemester.AgSelectedValue) & ", " & AgL.Chk_Text(PLib.FunGetPromotionType(TxtStatus.Text, TxtIsStreamChange.Text)) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                '===============================================================================================================================================
                '==================< INSERT Second RECORD IN >===================================================================================================
                '================< Sch_AdmissionPromotion Table >===============================================================================================
                '===============================================================================================================================================
                If TxtPromotionSemester.Text.Trim <> "" Then
                    mQry = "INSERT INTO Sch_AdmissionPromotion ( AdmissionDocId, Sr, FromStreamYearSemester, " & _
                            " PreparedBy, U_EntDt, U_AE ) " & _
                            " VALUES ( " & _
                            " '" & mSearchCode & "', 2, " & AgL.Chk_Text(TxtPromotionSemester.AgSelectedValue) & ", " & _
                            " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If
                '===============================================================================================================================================
            Else
                mQry = "UPDATE Sch_Admission SET " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", Student = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & ", " & _
                        " SessionProgrammeStream = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & ", " & _
                        " SessionProgramme = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & ", " & _
                        " AdmissionNature = " & AgL.Chk_Text(TxtAdmissionNature.AgSelectedValue) & ", " & _
                        " RegistrationDocId = " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & ", AdmissionID = " & AgL.Chk_Text(TxtAdmissionID.Text) & ", Remark = " & AgL.Chk_Text(TxtRemark.Text) & " , " & _
                        " ScholarshipApplied = " & IIf(AgL.StrCmp(TxtScholarshipApplied.Text, "Yes"), 1, 0) & ", " & _
                        " Status = " & AgL.Chk_Text(TxtStatus.Text) & ", " & _
                        " Rank = " & Val(TxtRank.Text) & ", " & _
                        " RankRemark = " & AgL.Chk_Text(TxtRankRemark.Text) & ", " & _
                        " MeritPercentage = " & Val(TxtMeritPercentage.Text) & ", " & _
                        " MeritRemark = " & AgL.Chk_Text(TxtMeritRemark.Text) & ", " & _
                        " IsFeeWavier = " & IIf(AgL.StrCmp(TxtIsFeeWavier.Text, "Yes"), 1, 0) & ", IsDiplomaHolder = " & IIf(AgL.StrCmp(TxtIsDiplomaHolder.Text, "Yes"), 1, 0) & ", " & _
                        " CounselingFee = " & Val(TxtCounselingFee.Text) & ", " & _
                        " CounselingFeeReceiptNo = " & AgL.Chk_Text(TxtCounselingFeeReceiptNo.Text) & ", " & _
                        " AdmissionSemester = " & AgL.Chk_Text(TxtAdmissionSemester.AgSelectedValue) & ", " & _
                        " PromotionSemester = " & AgL.Chk_Text(TxtPromotionSemester.AgSelectedValue) & ", " & _
                        " EnquiryDocId = " & AgL.Chk_Text(TxtEnquiryDocId.AgSelectedValue) & "," & _
                        " U_AE = 'E', Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " Where DocId = '" & mSearchCode & "'"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "Select IsNull(Count(*),0) Cnt From Sch_AdmissionPromotion Ap With (NoLock) " & _
                            " Where Ap.AdmissionDocId = '" & mSearchCode & "' And Ap.Sr > 2 "
                If AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar() = 0 Then
                    '===============================================================================================================================================
                    '==================< INSERT FIRST RECORD IN >===================================================================================================
                    '================< Sch_AdmissionPromotion Table >===============================================================================================
                    '===============================================================================================================================================
                    mQry = "UPDATE Sch_AdmissionPromotion SET " & _
                            " FromStreamYearSemester = " & AgL.Chk_Text(TxtAdmissionSemester.AgSelectedValue) & ", PromotionDate = " & AgL.ConvertDate(IIf(TxtPromotionSemester.Text.Trim = "", "", TxtV_Date.Text).ToString) & ", " & _
                            " ToStreamYearSemester = " & AgL.Chk_Text(TxtPromotionSemester.AgSelectedValue) & ", " & _
                            " PromotionType = " & AgL.Chk_Text(PLib.FunGetPromotionType(TxtStatus.Text, TxtIsStreamChange.Text)) & ", " & _
                            " U_AE = 'E', Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', ModifiedBy = '" & AgL.PubUserName & "' " & _
                            " Where AdmissionDocId = '" & mSearchCode & "' AND Sr = 1"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    '===============================================================================================================================================
                    '==================< INSERT Second RECORD IN >===================================================================================================
                    '================< Sch_AdmissionPromotion Table >===============================================================================================
                    '===============================================================================================================================================
                    mQry = "UPDATE Sch_AdmissionPromotion SET " & _
                            " FromStreamYearSemester = " & AgL.Chk_Text(TxtPromotionSemester.AgSelectedValue) & ", PromotionDate = Null, " & _
                            " ToStreamYearSemester = Null, " & _
                            " PromotionType = Null, " & _
                            " U_AE = 'E', Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', ModifiedBy = '" & AgL.PubUserName & "' " & _
                            " Where AdmissionDocId = '" & mSearchCode & "' AND Sr = 2"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If
            End If

            '===============================================================================================================================================
            '==================< Update Current Semester >==================================================================================================
            '===========================< Start >===========================================================================================================
            '===============================================================================================================================================
            If Not mObjClsMain.FunUpdateCurrentSemester(mSearchCode, AgL.GCn, AgL.ECmd) Then
                Err.Raise(1, , "Error In Current Semester Updating!...")
            End If
            '===============================================================================================================================================
            '==================< Update Current Semester >==================================================================================================
            '===========================< End >=============================================================================================================
            '===============================================================================================================================================

            If mBlnImprtFromExcelFlag = False Then
                If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                    If Topctrl1.Mode = "Edit" Then
                        mQry = "Delete From Sch_AdmissionFeeDetail Where DocId = '" & mSearchCode & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If

                    With DGL1
                        mSr = 0
                        For I = 0 To .Rows.Count - 1
                            If .Item(Col1StreamYearSemester, I).Value <> "" Then
                                mSr = mSr + 1

                                mQry = "INSERT INTO Sch_AdmissionFeeDetail ( DocId, Sr, StreamYearSemester, Fee, Amount , FeeStreamYearSemester) " & _
                                        " VALUES ( " & _
                                        " '" & mSearchCode & "', " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1StreamYearSemester, I)) & ", " & _
                                        " " & AgL.Chk_Text(.AgSelectedValue(Col1Fee, I)) & ", " & Val(.Item(Col1Amount, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(.AgSelectedValue(Col1FeeStreamYearSemester, I)) & " )"
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            End If
                        Next I
                    End With
                End If


                If Topctrl1.Mode = "Edit" Then
                    mQry = "Delete From Sch_AdmissionSubject Where DocId = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If


                With DGL2
                    mSr = 0
                    For I = 0 To .Rows.Count - 1
                        If .Item(Col2SemesterSubject, I).Value <> "" And AgL.StrCmp(.Item(Col2IsSubjectSelected, I).Value, "Yes") Then
                            mSr = mSr + 1

                            mQry = "INSERT INTO Sch_AdmissionSubject ( DocId, Sr, SemesterSubject, OtherSemesterSubject) " & _
                                    " VALUES ( " & _
                                    " '" & mSearchCode & "', " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col2SemesterSubject, I)) & ", " & AgL.Chk_Text(.AgSelectedValue(Col2OtherSemesterSubject, I)) & " )"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Next I
                End With

                If Topctrl1.Mode = "Edit" Then
                    mQry = "Delete From Sch_AdmissionDocument Where DocId = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If


                With DGL3
                    mSr = 0
                    For I = 0 To .Rows.Count - 1
                        If .Item(Col3DocumentCode, I).Value <> "" Then
                            mSr = mSr + 1

                            mQry = "INSERT INTO Sch_AdmissionDocument ( DocId, Sr, DocumentCode, BlobSr) " & _
                                    " VALUES ( " & _
                                    " '" & mSearchCode & "', " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col3DocumentCode, I)) & ", Null )"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Next I
                End With
            End If


            If Academic_ProjLib.ClsMain.IsModuleActive_Library Then
                If Not mObjClsMain.FunSaveLibraryMember(mObjStructLibraryMember, AgL.GCn, AgL.ECmd, IIf(mBlnIsLibraryMemberExists, "Edit", "Add")) Then
                    Err.Raise(1, , "")
                End If
            End If

            '************** Rati 20/Apr/2012 ************************
            If Academic_ProjLib.ClsMain.IsModuleActive_Transport Then
                If AgL.StrCmp(TxtIsTransport.Text, "Yes") Then
                    If Not mObjClsMain.FunSaveTransportMember(mObjStructTransportMember, AgL.GCn, AgL.ECmd, IIf(mBlnIsTransportMemberExists, "Edit", "Add")) Then
                        Err.Raise(1, , "")
                    End If
                End If
            End If

            If Academic_ProjLib.ClsMain.IsModuleActive_Mess Then
                If AgL.StrCmp(TxtIsMess.Text, "Yes") Then
                    If Not mObjClsMain.FunSaveMessMember(mObjStructMessMember, AgL.GCn, AgL.ECmd, IIf(mBlnIsMessMemberExists, "Edit", "Add")) Then
                        Err.Raise(1, , "")
                    End If
                End If
            End If

            '**************************************


            If mBlnImprtFromExcelFlag = False Then
                If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                    If mBlnIsUserCanApprove Then Call ProcApproveVoucher(AgL.PubUserName, bStrApprovedDate, mBlnIsUserCanApprove)
                End If
            End If

            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, TxtStatus.Text, TxtV_Date.Text, TxtStudent.AgSelectedValue, TxtStudent.Text, , TxtSite_Code.AgSelectedValue, AgL.PubDivCode)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.XNull(AgL.PubImageDBName).ToString.Trim <> "" Then
                With DGL3
                    For I = 0 To .Rows.Count - 1
                        Call ProcSaveSubGroup_BLOB(I)
                        If .Item(Col3DocumentCode, I).Value <> "" Then
                            Try
                                mQry = "Update Sch_AdmissionDocument " & _
                                        " Set BlobSr = " & AgL.Chk_Text(.Item(Col3BlobSr, I).Value) & " " & _
                                        " Where DocId = '" & mSearchCode & "' " & _
                                        " And DocumentCode = " & AgL.Chk_Text(.AgSelectedValue(Col3DocumentCode, I)) & " "
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            Catch ex As Exception

                            End Try
                        End If
                    Next
                End With
            End If


            Try
                If AgLibrary.ClsConstant.IsSmsActive Then
                    Dim bStrSMS$ = "", bStrMobileNo$ = "", bStrCategory$ = ""
                    Dim bDtSmsEvent As DataTable = Nothing

                    mQry = "SELECT E.* FROM Sms_Event E  WITH (NoLock) WHERE E.Event = '" & ClsMain.SmsEvent.StudentAdmission & "'"
                    bDtSmsEvent = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

                    If bDtSmsEvent.Rows.Count > 0 Then
                        bStrSMS = AgL.XNull(bDtSmsEvent.Rows(0)("Message")).ToString
                        bStrCategory = AgL.XNull(bDtSmsEvent.Rows(0)("Category")).ToString
                    End If
                    If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()

                    mQry = "SELECT LEFT(IsNull(Sg.Mobile,''),10) AS Mobile  FROM SubGroup Sg WITH (NoLock) WHERE Sg.SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & ""
                    bStrMobileNo = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar).ToString

                    If bStrSMS.Trim <> "" And bStrMobileNo.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, TxtV_Date.Text, bStrCategory, AgL.XNull(TxtStudent.AgSelectedValue).ToString, bStrMobileNo, TxtV_Date.Text, bStrSMS)
                        Call AgL.SendSms(AgL)
                    End If
                End If
            Catch ex As Exception

            End Try


            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode

                mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

                Topctrl1.FButtonClick(0)

                'If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    Call PrintDocument(mDocId)
                'End If

                Exit Sub
            Else
                mTmV_Type = "" : mTmV_Prefix = "" : mTmV_Date = "" : mTmV_NCat = ""

                Topctrl1.SetDisp(True)
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If

            If ex.Message <> "" Then MsgBox(ex.Message)
        End Try
    End Sub

    Sub ProcSaveSubGroup_BLOB(ByVal IntRowIndex As Integer)
        Dim ByteArr As Byte() = Nothing
        Dim bCondStr$ = " Where 1=1 ", bStrSubCode$ = ""
        Dim GcnRead As SqlConnection = Nothing
        Dim bIntSr As Integer

        Try
            ByteArr = DGL3.Item(Col3ByteArray, IntRowIndex).Value
            bStrSubCode = AgL.XNull(TxtStudent.AgSelectedValue)
        Catch ex As Exception

        End Try


        Try
            GcnRead = AgL.FunGetReadConnection(AgL.GCnImage_ConnectionString)

            If AgL.XNull(DGL3.Item(Col3DocumentCode, IntRowIndex).Value).ToString.Trim <> "" _
                And ByteArr IsNot Nothing Then

                If Val(DGL3.Item(Col3BlobSr, IntRowIndex).Value) > 0 Then
                    bIntSr = Val(DGL3.Item(Col3BlobSr, IntRowIndex).Value)
                Else
                    mQry = "SELECT IsNull(Max(B.Sr),0) + 1 AS MaxSr " & _
                            " FROM SubGroup_BLOB B WITH (NoLock) " & _
                            " WHERE B.SubCode = " & AgL.Chk_Text(bStrSubCode) & " "
                    bIntSr = AgL.VNull(AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar)
                End If

                bCondStr += " And SubCode = " & AgL.Chk_Text(bStrSubCode) & " "
                bCondStr += " And Sr = " & bIntSr & " "

                If Val(DGL3.Item(Col3BlobSr, IntRowIndex).Value) = 0 Then
                    mQry = "INSERT INTO dbo.SubGroup_BLOB (SubCode, Sr, Description, FileName) " & _
                            " VALUES (" & AgL.Chk_Text(bStrSubCode) & ", " & bIntSr & ", " & _
                            " " & AgL.Chk_Text(DGL3.Item(Col3DocumentCode, IntRowIndex).Value) & ", " & _
                            " " & AgL.Chk_Text(DGL3.Item(Col3FileName, IntRowIndex).Value) & " " & _
                            " )"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnImage)
                End If

                mQry = "Update SubGroup_BLOB Set BLOB=@pic " & bCondStr

                Dim cmd As SqlCommand = New SqlCommand(mQry, AgL.GcnImage)
                Dim Pic As SqlParameter = New SqlParameter("@pic", SqlDbType.Image)
                Pic.Value = ByteArr
                cmd.Parameters.Add(Pic)
                cmd.ExecuteNonQuery()

                If Val(DGL3.Item(Col3BlobSr, IntRowIndex).Value) = 0 Then
                    DGL3.Item(Col3BlobSr, IntRowIndex).Value = bIntSr
                End If
            Else
                If Val(DGL3.Item(Col3BlobSr, IntRowIndex).Value) > 0 Then
                    bCondStr += " And SubCode = " & AgL.Chk_Text(bStrSubCode) & " "
                    bCondStr += " And Sr = " & bIntSr & " "

                    mQry = "Delete From SubGroup_BLOB " & bCondStr
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnImage)
                End If

                If ByteArr Is Nothing Then
                    DGL3.Item(Col3BlobSr, IntRowIndex).Value = ""
                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try
    End Sub

    Private Sub ProcSaveFeeDueDetail(Optional ByVal BlnIsApprovalCall As Boolean = False)
        Dim bFeeDueObj As New Academic_ProjLib.ClsMain.Struct_FeeDue, bFeeDue1Obj() As Academic_ProjLib.ClsMain.Struct_FeeDue1 = Nothing
        Dim bStreamYearSemester$ = "", bStreamYearSemesterDesc$ = "", bStrEntryMode As String = Topctrl1.Mode

        If BlnIsApprovalCall Then
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then
                bStrEntryMode = "Add"
            End If
        End If

        If TxtPromotionSemester.AgSelectedValue.Trim <> "" Then
            bStreamYearSemester = TxtPromotionSemester.AgSelectedValue
            bStreamYearSemesterDesc = TxtPromotionSemester.Text
        Else
            bStreamYearSemester = TxtAdmissionSemester.AgSelectedValue
            bStreamYearSemesterDesc = TxtAdmissionSemester.Text
        End If

        If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
            If mBlnIsSemFeeExists = False Then
                If AgL.XNull(mFeeDueDocId).ToString.Trim <> "" Then
                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionFeeDue Where AdmissionDocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDueLedgerM Where DocId = '" & mFeeDueDocId & "'", AgL.GCn, AgL.ECmd)
                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mFeeDueDocId)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDue1 Where DocId = '" & mFeeDueDocId & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeDue Where DocId = '" & mFeeDueDocId & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mFeeDueDocId, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, Me.Text)
                End If
            Else
                bFeeDueObj.StreamYearSemesterDesc = bStreamYearSemesterDesc
                ProcCreateFeeDueStructure(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, bStrEntryMode, mSearchCode, bStreamYearSemester, bFeeDueObj, bFeeDue1Obj, mFeeDueDocId)

                If AgL.XNull(bFeeDueObj.DocId).ToString.Trim <> "" Then
                    bStrEntryMode = AgL.Dman_Execute("If Not EXISTS(SELECT * FROM Sch_FeeDue With (NoLock) WHERE DocId = '" & bFeeDueObj.DocId & "') SELECT 'Add' ELSE SELECT 'Edit'", AgL.GcnRead).ExecuteScalar
                End If

                Call PLib.ProcSaveFeeDueDetail(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, bStrEntryMode, bFeeDueObj, bFeeDue1Obj, mSearchCode)
                Call PLib.FunFeeDueAccountPosting(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, bStrEntryMode, bFeeDueObj)

                If bStrEntryMode = "Edit" Then
                    mQry = "Delete From Sch_AdmissionFeeDue Where AdmissionDocId = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If

                mQry = "INSERT INTO Sch_AdmissionFeeDue ( AdmissionDocId, FeeDueDocId, Remark ) " & _
                       " VALUES ( " & _
                       " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mFeeDueDocId) & ", '' )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                AgL.UpdateVoucherCounter(mFeeDueDocId, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                Call AgL.LogTableEntry(mFeeDueDocId, Me.Text, AgL.MidStr(bStrEntryMode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, Me.Text)
            End If

        End If
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing, DTRTbl
        Dim MastPos As Long
        Dim I As Integer
        Dim bStreamYearSemester$ = "", bToStreamYearSemester$ = "", bLastSessionProgrammeStreamCode$ = ""
        Dim mTransFlag As Boolean = False, bIsStatusChanged As Boolean = False

        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            FClear()
            BlankText()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then
                mQry = "Select A.*, Vt.NCat, Af.FeeDueDocId, Sps.SessionProgramme As SessionProgrammeCodeTemp, Sps.SessionStartDate, " & _
                        " Sps.Stream AS StreamCode, Sps.ProgrammeCode " & _
                        " From Sch_Admission A " & _
                        " Left Join Voucher_Type Vt On A.V_Type = Vt.V_Type " & _
                        " Left Join Sch_AdmissionFeeDue Af On A.DocId = Af.AdmissionDocId " & _
                        " Left Join ViewSch_SessionProgrammeStream Sps On A.SessionProgrammeStream = Sps.Code " & _
                        " Where A.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = mSearchCode
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblV_Date.Tag = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(+2, "0"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCat"))
                        TxtSessionProgrammeStream.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgrammeStream"))
                        LblSessionProgrammeStream.Tag = AgL.XNull(.Rows(0)("SessionProgrammeCodeTemp"))

                        TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgramme"))
                        LblSessionProgrammeStreamReq.Tag = Format(AgL.XNull(.Rows(0)("SessionStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        mFirstStreamCode = AgL.XNull(.Rows(0)("StreamCode"))
                        mProgrammeCode = AgL.XNull(.Rows(0)("ProgrammeCode"))

                        TxtAdmissionNature.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionNature"))
                        TxtRegistrationDocId.AgSelectedValue = AgL.XNull(.Rows(0)("RegistrationDocId"))
                        TxtStudent.AgSelectedValue = AgL.XNull(.Rows(0)("Student"))
                        LblStudent.Tag = AgL.XNull(.Rows(0)("Student"))

                        TxtScholarshipApplied.Text = IIf(AgL.VNull(.Rows(0)("ScholarshipApplied")), "Yes", "No")
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtAdmissionID.Text = AgL.XNull(.Rows(0)("AdmissionID"))
                        mFeeDueDocId = AgL.XNull(.Rows(0)("FeeDueDocId"))

                        TxtEnquiryDocId.AgSelectedValue = AgL.XNull(.Rows(0)("EnquiryDocId"))
                        LblEnquiryDocId.Tag = AgL.XNull(.Rows(0)("EnquiryDocId"))
                        '==========================================================================================
                        '=============< Assign Admission Semester >================================================
                        '======================< Start >===========================================================
                        '==========================================================================================
                        TxtAdmissionSemester.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionSemester"))
                        mLastFromStreamYearSemesterCode_Fee = AgL.XNull(.Rows(0)("AdmissionSemester"))
                        mLastFromStreamYearSemesterCode_Subject = AgL.XNull(.Rows(0)("AdmissionSemester"))
                        '==========================================================================================
                        '=============< Assign Admission Semester >================================================
                        '========================< End >===========================================================
                        '==========================================================================================

                        '==========================================================================================
                        '=============< Assign Promotion Semester >================================================
                        '======================< Start >===========================================================
                        '==========================================================================================
                        If AgL.XNull(.Rows(0)("PromotionSemester")).ToString.Trim <> "" Then
                            LblAdmissionSemesterReq.Tag = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                            TxtPromotionSemester.AgSelectedValue = AgL.XNull(.Rows(0)("PromotionSemester"))
                            mLastToStreamYearSemesterCode_Fee = AgL.XNull(.Rows(0)("PromotionSemester"))
                            mLastToStreamYearSemesterCode_Subject = AgL.XNull(.Rows(0)("PromotionSemester"))
                            bToStreamYearSemester = AgL.XNull(.Rows(0)("PromotionSemester"))
                        End If
                        '==========================================================================================
                        '=============< Assign Promotion Semester >================================================
                        '========================< End >===========================================================
                        '==========================================================================================

                        '==========================================================================================
                        '===============< Assign Current Semester >================================================
                        '======================< Start >===========================================================
                        '==========================================================================================
                        mCurrentStreamYearSemester = AgL.XNull(.Rows(0)("CurrentSemester"))
                        '==========================================================================================
                        '===============< Assign Current Semester >================================================
                        '========================< End >===========================================================
                        '==========================================================================================


                        If Not mIsFeeLocked Then
                            mQry = "SELECT IsNull(Count(*),0) Cnt " & _
                                    " FROM Sch_FeeDue1 Fd1 " & _
                                    " WHERE Fd1.AdmissionDocId = '" & mSearchCode & "' " & _
                                    " AND Fd1.DocId <> " & AgL.Chk_Text(AgL.XNull(.Rows(0)("FeeDueDocId"))) & " "
                            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then mIsFeeLocked = True
                        End If

                        TxtLeavingDate.Text = Format(AgL.XNull(.Rows(0)("LeavingDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtLeavingReason.Text = AgL.XNull(.Rows(0)("LeavingReason"))
                        TxtStatus.Text = AgL.XNull(.Rows(0)("Status"))
                        TxtRank.Text = IIf(AgL.VNull(.Rows(0)("Rank")) = 0, "", AgL.VNull(.Rows(0)("Rank")))
                        TxtRankRemark.Text = AgL.XNull(.Rows(0)("RankRemark"))
                        TxtMeritPercentage.Text = IIf(AgL.VNull(.Rows(0)("MeritPercentage")) = 0, "", Format(AgL.VNull(.Rows(0)("MeritPercentage")), "0.00"))
                        TxtMeritRemark.Text = AgL.XNull(.Rows(0)("MeritRemark"))
                        TxtIsFeeWavier.Text = IIf(AgL.VNull(.Rows(0)("IsFeeWavier")), "Yes", "No")
                        TxtIsDiplomaHolder.Text = IIf(AgL.VNull(.Rows(0)("IsDiplomaHolder")), "Yes", "No")

                        TxtCounselingFee.Text = Format(AgL.VNull(.Rows(0)("CounselingFee")), "0.00")
                        TxtCounselingFeeReceiptNo.Text = AgL.XNull(.Rows(0)("CounselingFeeReceiptNo"))


                        mQry = "SELECT M.* FROM Lib_Member M With (NoLock) WHERE M.SubCode = " & AgL.Chk_Text(AgL.XNull(.Rows(0)("Student"))) & " "
                        DTbl = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                        If DTbl.Rows.Count > 0 Then
                            TxtLibraryMemberType.AgSelectedValue = AgL.XNull(DTbl.Rows(0)("MemberType"))
                            TxtlibrarySite.AgSelectedValue = AgL.XNull(DTbl.Rows(0)("Site_Code"))
                        End If
                        If DTbl IsNot Nothing Then DTbl.Dispose()

                        mQry = "SELECT M.* FROM tp_Member M With (NoLock) WHERE M.SubCode = " & AgL.Chk_Text(AgL.XNull(.Rows(0)("Student"))) & " "
                        DTRTbl = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                        If DTRTbl.Rows.Count > 0 Then
                            mFrmObjTransportInfo = New FrmTransportInfo()
                            Call CType(mFrmObjTransportInfo, FrmTransportInfo).Ini_List()

                            TxtIsTransport.Text = "Yes"

                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtMemberCardNo.Text = AgL.XNull(DTRTbl.Rows(0)("MemberCardNo"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardPrefix.Text = AgL.XNull(DTRTbl.Rows(0)("CardPrefix"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text = AgL.VNull(DTRTbl.Rows(0)("CardSrNo"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtValidTillDate.Text = AgL.XNull(DTRTbl.Rows(0)("ValidTillDate"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtVehicle.AgSelectedValue = AgL.XNull(DTRTbl.Rows(0)("Vehicle"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtSeatNo.Text = AgL.XNull(DTRTbl.Rows(0)("SeatNo"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtRoute.AgSelectedValue = AgL.XNull(DTRTbl.Rows(0)("Route"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtPickUpPoint.AgSelectedValue = AgL.XNull(DTRTbl.Rows(0)("PickUpPoint"))
                        End If
                        If DTRTbl IsNot Nothing Then DTRTbl.Dispose()

                        mQry = "SELECT M.* FROM Mess_Member M With (NoLock) WHERE M.SubCode = " & AgL.Chk_Text(AgL.XNull(.Rows(0)("Student"))) & " "
                        DTbl = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                        If DTbl.Rows.Count > 0 Then
                            TxtIsMess.Text = "Yes"
                            txtMessJoinDt.Text = Format(AgL.XNull(DTbl.Rows(0)("JoiningDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        End If
                        If DTbl IsNot Nothing Then DTbl.Dispose()

                        mBlnIsAutoApproved = AgL.VNull(.Rows(0)("IsAutoApproved"))

                        TxtApproved.Text = AgL.XNull(.Rows(0)("ApprovedBy"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select S.*, Sg.* " & _
                        " From Sch_Student S " & _
                        " Left Join SubGroup Sg On Sg.SubCode = S.SubCode " & _
                        " Where S.SubCode = '" & TxtStudent.AgSelectedValue & "' "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtReligion.AgSelectedValue = AgL.XNull(.Rows(0)("Religion"))
                        TxtCategory.AgSelectedValue = AgL.XNull(.Rows(0)("Category"))
                        TxtFamilyIncome.Text = Format(AgL.VNull(.Rows(0)("FamilyIncome")), "0.00")
                    End If
                End With

                mQry = "Select Ap.*, Sem.SessionProgrammeStreamCode, Sem.SemesterSerialNo, Sem.SemesterStartDate, Sem.StreamCode " & _
                        " From Sch_AdmissionPromotion Ap " & _
                        " Left Join ViewSch_StreamYearSemester Sem On Ap.FromStreamYearSemester = Sem.Code " & _
                        " Where Ap.AdmissionDocId = '" & mSearchCode & "' " & _
                        " Order By Ap.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            DGL4.Rows.Add()
                            DGL4.Item(Col_SNo, I).Value = DGL4.Rows.Count - 1
                            DGL4.AgSelectedValue(Col4FromStreamYearSemester, I) = AgL.XNull(.Rows(I)("FromStreamYearSemester"))
                            DGL4.AgSelectedValue(Col4ToStreamYearSemester, I) = AgL.XNull(.Rows(I)("ToStreamYearSemester"))
                            DGL4.Item(Col4PromotionDate, I).Value = Format(AgL.XNull(.Rows(I)("PromotionDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL4.Item(Col4PromotionType, I).Value = AgL.XNull(.Rows(I)("PromotionType"))
                            bLastSessionProgrammeStreamCode = AgL.XNull(.Rows(I)("SessionProgrammeStreamCode"))

                            If I = 0 Then
                                'TxtAdmissionSemester.AgSelectedValue = AgL.XNull(.Rows(I)("FromStreamYearSemester"))
                                'mLastFromStreamYearSemesterCode_Fee = AgL.XNull(.Rows(I)("FromStreamYearSemester"))
                                'mLastFromStreamYearSemesterCode_Subject = AgL.XNull(.Rows(I)("FromStreamYearSemester"))

                                LblAdmissionSemester.Tag = AgL.XNull(.Rows(I)("SessionProgrammeStreamCode"))
                                mFromSemesterSerialNo = AgL.VNull(.Rows(I)("SemesterSerialNo"))
                                mFromSemesterStreamCode = AgL.XNull(.Rows(I)("StreamCode"))

                                'If DGL4.Item(Col4PromotionDate, I).Value.ToString.Trim <> "" Then
                                '    If CDate(TxtV_Date.Text) = CDate(DGL4.Item(Col4PromotionDate, I).Value.ToString) Then
                                '        LblAdmissionSemesterReq.Tag = Format(AgL.XNull(.Rows(I)("PromotionDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                                '        TxtPromotionSemester.AgSelectedValue = AgL.XNull(.Rows(I)("ToStreamYearSemester"))
                                '        mLastToStreamYearSemesterCode_Fee = AgL.XNull(.Rows(I)("ToStreamYearSemester"))
                                '        mLastToStreamYearSemesterCode_Subject = AgL.XNull(.Rows(I)("ToStreamYearSemester"))
                                '        bToStreamYearSemester = AgL.XNull(.Rows(I)("ToStreamYearSemester"))
                                '    End If
                                'End If

                            ElseIf I = 1 And .Rows.Count > 1 And LblAdmissionSemesterReq.Tag.ToString.Trim <> "" Then
                                LblPromotionSemester.Tag = AgL.XNull(.Rows(I)("SessionProgrammeStreamCode"))
                                mToSemesterSerialNo = AgL.VNull(.Rows(I)("SemesterSerialNo"))
                                mToSemesterStreamCode = AgL.XNull(.Rows(I)("StreamCode"))
                            End If

                            If AgL.StrCmp(AgL.XNull(.Rows(I)("PromotionType")), Academic_ProjLib.ClsMain.PromotionType_Ex) Or _
                                AgL.StrCmp(AgL.XNull(.Rows(I)("PromotionType")), Academic_ProjLib.ClsMain.PromotionType_ReAdmit) Or _
                                AgL.StrCmp(AgL.XNull(.Rows(I)("PromotionType")), Academic_ProjLib.ClsMain.PromotionType_StreamChange) Then

                                If Not mIsSubjectLocked Then mIsFeeLocked = True
                                If Not mIsFeeLocked Then mIsFeeLocked = True
                            End If

                            If AgL.StrCmp(mCurrentStreamYearSemester, AgL.XNull(.Rows(I)("FromStreamYearSemester")).ToString) Then
                                mCurrentSemesterSerialNo = AgL.VNull(.Rows(I)("SemesterSerialNo"))
                                mCurrentSemesterStartDate = Format(AgL.XNull(.Rows(I)("SemesterStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                                mCurrentSemesterStreamCode = AgL.XNull(.Rows(I)("StreamCode"))
                            End If
                        Next


                        If bToStreamYearSemester.Trim = "" And .Rows.Count > 1 Then
                            mIsPromotionDetailExists = True
                        ElseIf bToStreamYearSemester.Trim <> "" And .Rows.Count > 2 Then
                            mIsPromotionDetailExists = True
                        End If

                    End If
                End With

                If mIsPromotionDetailExists = True And mIsFeeLocked = False Then mIsFeeLocked = True

                If TxtPromotionSemester.AgSelectedValue.Trim <> "" Then
                    bStreamYearSemester = TxtPromotionSemester.AgSelectedValue
                Else
                    bStreamYearSemester = TxtAdmissionSemester.AgSelectedValue
                End If

                mQry = "Select Af.* " & _
                        " From Sch_AdmissionFeeDetail Af " & _
                        " Where Af.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1StreamYearSemester, I) = AgL.XNull(.Rows(I)("StreamYearSemester"))
                            DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.AgSelectedValue(Col1FeeStreamYearSemester, I) = AgL.XNull(.Rows(I)("FeeStreamYearSemester"))
                        Next I
                    End If
                End With




                mQry = "Select Ads.SemesterSubject, VSub.Subject AS SubjectCode,  VSub.StreamYearSemester, VSub.ManualCode,  " & _
                        " VSub.PaperID, VSub.MinCreditHours, VSub.IsElectiveSubject, Convert(Bit,1) As IsSubjectSelected, Ads.Sr, Ads.OtherSemesterSubject    " & _
                        " From Sch_AdmissionSubject Ads   " & _
                        " Left Join ViewSch_SemesterSubject VSub On Ads.SemesterSubject = VSub.Code   " & _
                        " Where Ads.DocId = '" & mSearchCode & "' " & _
                        " UNION ALL  " & _
                        " Select VSub.Code AS SemesterSubject, VSub.Subject AS SubjectCode,  VSub.StreamYearSemester, VSub.ManualCode,  " & _
                        " VSub.PaperID, VSub.MinCreditHours, VSub.IsElectiveSubject, Convert(Bit,0) As IsSubjectSelected, 999999 As Sr, Null as OtherSemesterSubject    " & _
                        " FROM ViewSch_SemesterSubject VSub " & _
                        " LEFT JOIN Sch_AdmissionSubject Ads ON VSub.Code = Ads.SemesterSubject  " & _
                        " WHERE VSub.SessionProgrammeStreamCode ='" & TxtSessionProgrammeStream.AgSelectedValue & "' AND Ads.SemesterSubject IS NULL  " & _
                        " ORDER BY Sr "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL2.RowCount = 1 : DGL2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count
                            DGL2.AgSelectedValue(Col2SemesterSubject, I) = AgL.XNull(.Rows(I)("SemesterSubject"))
                            DGL2.AgSelectedValue(Col2Subject, I) = AgL.XNull(.Rows(I)("SubjectCode"))
                            DGL2.Item(Col2ManualCode, I).Value = AgL.XNull(.Rows(I)("ManualCode"))
                            DGL2.Item(Col2PaperID, I).Value = AgL.XNull(.Rows(I)("PaperId"))
                            DGL2.Item(Col2MinCreditHours, I).Value = Format(AgL.VNull(.Rows(I)("MinCreditHours")), "0.00")
                            DGL2.Item(Col2IsSubjectSelected, I).Value = IIf(AgL.VNull(.Rows(I)("IsSubjectSelected")), "Yes", "No")
                            DGL2.Item(Col2IsElectiveSubject, I).Value = IIf(AgL.VNull(.Rows(I)("IsElectiveSubject")), 1, 0)
                            DGL2.AgSelectedValue(Col2OtherSemesterSubject, I) = AgL.XNull(.Rows(I)("OtherSemesterSubject"))

                            If Not mIsSubjectLocked Then
                                If AgL.XNull(.Rows(I)("OtherSemesterSubject")).ToString.Trim <> "" Then mIsSubjectLocked = True
                            End If

                            If Not mIsSubjectLocked Then
                                mQry = "SELECT IsNull(count(*),0) Cnt " & _
                                        " FROM Sch_StudentAttendance A " & _
                                        " LEFT JOIN Sch_StudentAttendance1 A1 ON A.Code = A1.Code  " & _
                                        " WHERE A1.AdmissionDocId = '" & mSearchCode & "' AND " & _
                                        " A.Subject = " & AgL.Chk_Text(AgL.XNull(.Rows(I)("SubjectCode"))) & " "

                                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then mIsSubjectLocked = True
                            End If

                        Next I
                    End If
                End With

                mQry = "Select Ad.* " & _
                        " From Sch_AdmissionDocument Ad " & _
                        " Where Ad.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL3.RowCount = 1 : DGL3.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL3.Rows.Add()
                            DGL3.Item(Col_SNo, I).Value = DGL3.Rows.Count - 1
                            DGL3.AgSelectedValue(Col3DocumentCode, I) = AgL.XNull(.Rows(I)("DocumentCode"))

                            DGL3.Item(Col3BlobSr, I).Value = ""

                            If AgL.VNull(.Rows(I)("BlobSr")) > 0 Then
                                If AgL.XNull(AgL.PubImageDBName).ToString.Trim <> "" Then
                                    DGL3.Item(Col3BlobSr, I).Value = AgL.VNull(.Rows(I)("BlobSr"))

                                    mQry = "SELECT B.* FROM SubGroup_BLOB B With (NoLock) " & _
                                            " WHERE B.SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & " " & _
                                            " AND B.Sr = " & AgL.VNull(.Rows(I)("BlobSr")) & " "
                                    DTbl = AgL.FillData(mQry, AgL.GcnImage).Tables(0)
                                    If DTbl.Rows.Count > 0 Then
                                        If Not IsDBNull(DTbl.Rows(0)("BLOB")) Then
                                            DGL3.Item(Col3ByteArray, I).Value = DTbl.Rows(0)("BLOB")
                                            DGL3.Item(Col3FileName, I).Value = AgL.XNull(DTbl.Rows(0)("FileName"))
                                        End If
                                    End If
                                End If

                            End If
                        Next I
                    End If
                End With
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If TxtLeavingDate.Text.Trim <> "" Then mTransFlag = True

                If mTransFlag Then
                    Topctrl1.tEdit = False
                    Topctrl1.tDel = False
                Else
                    If _FormType = eFormType.AdmissionEntry Then
                        If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                    End If

                    If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            DTbl = Nothing
            Topctrl1.tPrn = False

            Call DispUpText()
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
        DGL3.RowCount = 1 : DGL3.Rows.Clear()
        DGL4.RowCount = 1 : DGL4.Rows.Clear()

        Call BlankFooterGrid()

        mObjStructLibraryMember = Nothing

        mIsPromotionDetailExists = False : mIsSubjectLocked = False : mIsFeeLocked = False : mIsNewAdmissionPromotion = False : mBlnIsAutoApproved = False : mBlnIsLibraryMemberExists = False
        mBlnIsSemFeeExists = False

        TxtScholarshipApplied.Text = "No" : TxtIsFeeWavier.Text = "No" : TxtIsStreamChange.Text = "No" : TxtIsDiplomaHolder.Text = "No" : TxtIsTransport.Text = "No" : TxtIsMess.Text = "No"
        TxtStatus.Text = Academic_ProjLib.ClsMain.AdmissionStatus_Regular
        mFeeDueDocId = "" : mCurrentSemesterStartDate = "" : mProgrammeCode = "" : mNewProgrammeCode = "" : mCurrentStreamYearSemester = ""
        mLastFromStreamYearSemesterCode_Fee = "" : mLastToStreamYearSemesterCode_Fee = "" : mLastFromStreamYearSemesterCode_Subject = "" : mLastToStreamYearSemesterCode_Subject = ""

        mFirstStreamCode = "" : mFromSemesterStreamCode = "" : mToSemesterStreamCode = "" : mCurrentSemesterStreamCode = ""
        mFromSemesterSerialNo = 0 : mToSemesterSerialNo = 0 : mCurrentSemesterSerialNo = 0

        mBlnImprtFromExcelFlag = False

        Tc1.SelectedTab = Tp1
        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If

        mFrmObjTransportInfo = Nothing
    End Sub

    Private Sub BlankFooterGrid()
        '<Executable Code>
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False
        TxtEnquiryDocId.Enabled = False

        BtnFillFee.Enabled = Enb
        BtnFillSubject.Enabled = Enb

        'TxtEnquiryDocId.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Enquiry
        'LblEnquiryDocId.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Enquiry


        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
            TxtSessionProgrammeStream.Enabled = False
            TxtSessionProgramme.Enabled = False

            If mIsFeeLocked Or mIsSubjectLocked Or mIsPromotionDetailExists Then
                BtnFillFee.Enabled = False
                BtnFillSubject.Enabled = False
                TxtPromotionSemester.Enabled = False
                TxtStatus.Enabled = False
            End If
        End If


        Call DispUpText(Enb)
    End Sub

    Private Sub DispUpText(Optional ByVal Enb As Boolean = False)
        If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
            If _FormType = eFormType.AdmissionEntryAuthenticated Then
                GroupBox1.Visible = True : BtnApproved.Enabled = False

                Topctrl1.tAdd = False
                If Not mBlnIsUserCanApprove Then Topctrl1.tEdit = False

            ElseIf _FormType = eFormType.AdmissionEntry Then
                GroupBox1.Visible = True
            End If
        Else
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1StreamYearSemester
                    'Call IniItemHelp(False, DGL1.AgSelectedValue(Col1BarCode, mRowIndex))
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                'Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown, DGL2.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1StreamYearSemester
                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        'DGL1.Item(Col1_ManualCode, mRowIndex).Value = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                'DGL1.Item(Col1_ManualCode, mRowIndex).Value = AgL.XNull(.Item("Name", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL2.CurrentCell.ColumnIndex
                Case Col2IsSubjectSelected
                    If AgL.StrCmp(DGL2.Item(Col2IsSubjectSelected, mRowIndex).Value.ToString, "No") And Val(DGL2.Item(Col2IsElectiveSubject, mRowIndex).Value) = 0 Then
                        DGL2.Item(Col2IsSubjectSelected, mRowIndex).Value = "Yes"
                        MsgBox("""" & DGL2.Item(Col2Subject, mRowIndex).Value & """ Is A Compulsory Subject!...")
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded, DGL2.RowsAdded, DGL3.RowsAdded, DGL4.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved, DGL2.RowsRemoved, DGL3.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, 0)

        Call Calculation()
    End Sub

    Private Sub DGL3_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL3.CellContentClick
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim OpenPicDialogBox As OpenFileDialog
        Dim ImagePath$ = "", sFilePath As String = ""
        Dim bBlnNewImageFlag As Boolean = False
        Dim fByte As Byte() = Nothing
        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            Select Case DGL3.Columns(DGL3.CurrentCell.ColumnIndex).Name
                Case Col3BtnAttachment
                    If DGL3.Item(Col3ByteArray, mRowIndex).Value Is Nothing Then DGL3.Item(Col3ByteArray, mRowIndex).Value = ""
                    If DGL3.Item(Col3FileName, mRowIndex).Value Is Nothing Then DGL3.Item(Col3FileName, mRowIndex).Value = ""

                    If DGL3.Item(Col3ByteArray, mRowIndex).Value.ToString.Trim <> "" Then
                        bBlnNewImageFlag = False
                        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then
                            If AgL.XNull(DGL3.Item(Col3FileName, mRowIndex).Value).ToString.Trim <> "" Then
                                sFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Cookies) + "\" + DGL3.Item(Col3FileName, mRowIndex).Value.ToString
                                Call SaveToFile(sFilePath, DGL3.Item(Col3ByteArray, mRowIndex).Value)
                                System.Diagnostics.Process.Start(sFilePath)
                            End If

                        Else
                            If MsgBox("Want To Change Image?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                                bBlnNewImageFlag = True
                            End If
                        End If
                    Else
                        If Not AgL.StrCmp(Topctrl1.Mode, "Browse") Then bBlnNewImageFlag = True
                    End If

                    If bBlnNewImageFlag Then
                        OpenPicDialogBox = New OpenFileDialog

                        OpenPicDialogBox.Title = "Set PDF File"
                        OpenPicDialogBox.Filter = "PDF Files(*.pdf)|*.pdf"

                        ImagePath = My.Application.Info.DirectoryPath
                        OpenPicDialogBox.InitialDirectory = ImagePath
                        OpenPicDialogBox.DefaultExt = "*.pdf"
                        OpenPicDialogBox.FilterIndex = 1

                        OpenPicDialogBox.FileName = ""

                        If OpenPicDialogBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub


                        sFilePath = OpenPicDialogBox.FileName
                        If OpenPicDialogBox.FileName.ToString.Trim = "" Then
                            DGL3.Item(Col3FileName, mRowIndex).Value = ""
                        Else
                            DGL3.Item(Col3FileName, mRowIndex).Value = AgL.MidStr(OpenPicDialogBox.FileName, InStrRev(OpenPicDialogBox.FileName, "\"), OpenPicDialogBox.FileName.Length - InStrRev(OpenPicDialogBox.FileName, "\"))
                        End If

                    End If

                    If bBlnNewImageFlag = True Then
                        If sFilePath = "" Then Exit Sub

                        fByte = GetFromFile(sFilePath)
                        DGL3.Item(Col3ByteArray, mRowIndex).Value = fByte
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FClear()
        DTStruct.Clear()
    End Sub

    Private Sub FAddRowStructure()
        Dim DRStruct As DataRow
        Try
            DRStruct = DTStruct.NewRow
            DTStruct.Rows.Add(DRStruct)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtV_Type.Enter, TxtSessionProgrammeStream.Enter, TxtAdmissionSemester.Enter, TxtPromotionSemester.Enter, _
        TxtSessionProgrammeStream.Enter, TxtRegistrationDocId.Enter, TxtAdmissionID.Enter, _
        TxtIsStreamChange.Enter, TxtLibraryMemberType.Enter, TxtEnquiryDocId.Enter
        Dim bStrFilter$ = ""

        Try
            Select Case sender.name
                Case TxtSessionProgrammeStream.Name
                    mLastSessionProgrammeStreamDesc = TxtSessionProgrammeStream.Text
                    If TxtRegistrationDocId.Text.Trim <> "" Then
                        TxtSessionProgrammeStream.AgRowFilter = " SessionProgramme = " & AgL.Chk_Text(LblSessionProgrammeStream.Tag) & " "
                    Else
                        TxtSessionProgrammeStream.AgRowFilter = ""
                    End If

                Case TxtAdmissionSemester.Name
                    If TxtSessionProgrammeStream.AgSelectedValue Is Nothing Then TxtSessionProgrammeStream.AgSelectedValue = ""
                    sender.AgRowFilter = " SessionProgrammeStreamCode = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " "

                Case TxtPromotionSemester.Name
                    If TxtSessionProgrammeStream.AgSelectedValue Is Nothing Then TxtSessionProgrammeStream.AgSelectedValue = ""

                    If AgL.StrCmp(TxtStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) Then
                        sender.AgRowFilter = " StreamCode " & IIf(AgL.StrCmp(TxtIsStreamChange.Text, "Yes"), " <> ", " = ") & " " & AgL.Chk_Text(mFirstStreamCode) & " And " & _
                                                " SemesterSerialNo > " & mFromSemesterSerialNo & " " & _
                                                "  "
                    Else
                        sender.AgRowFilter = " SessionStartDate > " & AgL.ConvertDate(LblSessionProgrammeStreamReq.Tag.ToString) & " And " & _
                                                " " & _
                                                " " & IIf(AgL.StrCmp(TxtIsStreamChange.Text, "Yes"), " StreamCode <> " & AgL.Chk_Text(mFirstStreamCode) & " ", " 1=1 ") & " "
                    End If

                Case TxtLibraryMemberType.Name
                    TxtLibraryMemberType.AgRowFilter = " IsDeleted = 'No' "

                Case TxtRegistrationDocId.Name
                    TxtRegistrationDocId.AgRowFilter = " (IsAdmited = 'No' Or AdmissionDocId = '" & mSearchCode & "' ) "

                Case TxtEnquiryDocId.Name
                    If TxtEnquiryDocId.AgHelpDataSet IsNot Nothing Then
                        bStrFilter = " 1=1 "
                        bStrFilter += " And EnquiryDate <= " & AgL.ConvertDate(TxtV_Date.Text) & " "
                        TxtEnquiryDocId.AgRowFilter = bStrFilter
                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtDocId.Validating, TxtV_Date.Validating, _
        TxtStudent.Validating, TxtSessionProgrammeStream.Validating, TxtRemark.Validating, TxtReligion.Validating, _
        TxtAdmissionSemester.Validating, TxtPromotionSemester.Validating, TxtRegistrationDocId.Validating, _
        TxtFamilyIncome.Validating, TxtCategory.Validating, TxtAdmissionNature.Validating, TxtScholarshipApplied.Validating, TxtAdmissionID.Validating, _
        TxtIsStreamChange.Validating, TxtCounselingFee.Validating, TxtCounselingFeeReceiptNo.Validating, TxtLibraryMemberType.Validating, TxtEnquiryDocId.Validating, TxtIsTransport.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtEnquiryDocId.Name
                    Call Validating_Controls(sender)

                Case TxtIsTransport.Name
                    Dim FrmObj As Form = Nothing
                    If mFrmObjTransportInfo Is Nothing Then
                        If AgL.StrCmp(TxtIsTransport.Text, "Yes") Then
                            FrmObj = New FrmTransportInfo
                        End If
                    Else
                        FrmObj = mFrmObjTransportInfo
                    End If
                    If FrmObj IsNot Nothing Then
                        FormLocation.Y = TxtIsTransport.Top : FormLocation.X = 200
                        CType(FrmObj, FrmTransportInfo).EntryMode = Topctrl1.Mode
                        CType(FrmObj, FrmTransportInfo).FormLocation = FormLocation
                        CType(FrmObj, FrmTransportInfo).FrmObj = mFrmObjTransportInfo
                        FrmObj.ShowDialog()
                        mFrmObjTransportInfo = FrmObj
                        TxtIsTransport.Tag = FrmObj
                    End If

                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        sender.AgSelectedValue = ""
                        LblV_Type.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
                        End If
                    End If

                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                    TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text.ToString)

                Case TxtRegistrationDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        '<Executable Code>
                        sender.AgSelectedValue = ""
                        If TxtSessionProgrammeStream.Text.Trim = "" Then
                            LblSessionProgrammeStream.Tag = ""
                            LblSessionProgrammeStreamReq.Tag = ""
                            mFirstStreamCode = ""
                            mProgrammeCode = ""
                        End If

                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtAdmissionNature.AgSelectedValue = AgL.XNull(DrTemp(0)("AdmissionNature"))
                            TxtSessionProgrammeStream.AgSelectedValue = AgL.XNull(DrTemp(0)("SessionProgrammeStream"))
                            LblSessionProgrammeStream.Tag = AgL.XNull(DrTemp(0)("SessionProgramme"))
                            TxtStudent.AgSelectedValue = AgL.XNull(DrTemp(0)("Student"))

                            LblSessionProgrammeStreamReq.Tag = Format(AgL.XNull(DrTemp(0)("SessionStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            mFirstStreamCode = AgL.XNull(DrTemp(0)("StreamCode"))
                            mProgrammeCode = AgL.XNull(DrTemp(0)("ProgrammeCode"))
                            TxtEnquiryDocId.AgSelectedValue = AgL.XNull(DrTemp(0)("EnquiryDocId"))

                        End If
                    End If

                Case TxtStudent.Name
                    Call ProcValidatingControl(sender)

                Case TxtSessionProgrammeStream.Name
                    Call ProcValidatingControl(sender)

                Case TxtSessionProgramme.Name
                    Call ProcValidatingControl(sender)

                Case TxtAdmissionSemester.Name
                    Call ProcValidatingControl(sender)

                Case TxtPromotionSemester.Name
                    Call ProcValidatingControl(sender)

                Case TxtIsStreamChange.Name
                    If TxtIsStreamChange.Text.Trim = "" Then TxtIsStreamChange.Text = "No"
            End Select

            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mSearchCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

            If mFromSemesterSerialNo > mToSemesterSerialNo And mToSemesterSerialNo > 0 Then
                LblPromotionSemester.Tag = ""
                TxtPromotionSemester.AgSelectedValue = ""
                mToSemesterSerialNo = 0
                mToSemesterStreamCode = ""
            End If

            If LblPromotionSemester.Tag.ToString.Trim <> "" Then
                If AgL.StrCmp(TxtStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) Then
                    If Not AgL.StrCmp(LblAdmissionSemester.Tag, LblPromotionSemester.Tag) And Not AgL.StrCmp(TxtIsStreamChange.Text, "Yes") Then
                        LblPromotionSemester.Tag = ""
                        TxtPromotionSemester.AgSelectedValue = ""
                        mToSemesterSerialNo = 0
                        mToSemesterStreamCode = ""
                    End If
                End If
            End If

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
            DrTemp = Nothing
        End Try
    End Sub

    Private Sub Validating_Controls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtEnquiryDocId.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")

                    End If
                End If
        End Select
    End Sub
    Private Sub BtnFindEnqury_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindEnqury.Click
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

            mQry = "SELECT H.DocId AS Code, " & AgL.V_No_Field("H.DocId") & " As [Enquiry No], " & AgL.ConvertDateField("H.V_Date") & " As [Enquiry Date], " & _
                                " isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS [Person Name], " & _
                                " C.CityName AS City, " & _
                                " SG.DispName AS [Enquiry By], H.EnquiryMode AS [Enquiry Mode], E2.DispName AS [Enquiry Assign To], " & _
                                " CASE WHEN isnull(H.IsClosed,0) <> 0 THEN 'Yes' ELSE 'No' End  AS [Is Closed], H.Status  " & _
                                " FROM Enquiry_Enquiry H  " & _
                                " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee " & _
                                " LEFT JOIN SubGroup E2 ON E2.SubCode=H.AssignedTo " & _
                                " LEFT JOIN City C ON C.CityCode=H.CityCode " & _
                                " Where H.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " "
            AgL.PubFindQry = mQry
            AgL.PubFindQryOrdBy = "Convert(SmallDateTime, [Enquiry Date]) Desc, [Enquiry No]"

            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing

            If AgL.PubSearchRow <> "" Then
                TxtEnquiryDocId.AgSelectedValue = AgL.PubSearchRow
                Call Validating_Controls(TxtEnquiryDocId)
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Call BlankFooterGrid()

    End Sub

    Private Function GetAdmissionID() As String
        Dim mAdmissionID$ = "", mSessionProgrammeStream$ = ""
        Try
            mQry = "SELECT Vs.SessionProgrammeStream FROM ViewSch_SessionProgrammeStream Vs WHERE Vs.Code = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " "
            mSessionProgrammeStream = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)

            mQry = "SELECT IsNull(Max(Convert(INT,RIGHT(A.AdmissionID,5))),0) + 1 " & _
                    " FROM Sch_Admission A " & _
                    " WHERE A.Div_Code = '" & AgL.PubDivCode & "' AND A.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " AND " & _
                    " A.SessionProgrammeStream = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " "
            mAdmissionID = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar).ToString.PadLeft(5, "0")

            mAdmissionID = AgL.PubDivCode + "/" + AgL.PubSiteCode + "/" + mSessionProgrammeStream + "/" + mAdmissionID

        Catch ex As Exception
            mAdmissionID = ""
        Finally
            GetAdmissionID = mAdmissionID
        End Try
    End Function

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = "", bStrModule$ = ""
        Dim bIsNewSemesterFeeExists As Boolean = False

        Try
            Call Calculation()

            Tc1.SelectedTab = Tp1
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtSessionProgrammeStream, "Program (Stream)") Then Exit Function
            If AgL.RequiredField(TxtSessionProgramme, "Session/Program") Then Exit Function
            If AgL.RequiredField(TxtAdmissionSemester, "Admission Semester") Then Exit Function
            If AgL.RequiredField(TxtStatus, "Status") Then Exit Function
            If AgL.RequiredField(TxtIsStreamChange, "Is Branch Change?") Then Exit Function
            If AgL.RequiredField(TxtIsDiplomaHolder, "Is Diploma Holder?") Then Exit Function
            If mBlnImprtFromExcelFlag = False Then
                If AgL.RequiredField(TxtIsFeeWavier, "Is Fee Wavier?") Then Exit Function
            End If
            If Academic_ProjLib.ClsMain.IsModuleActive_Library Then
                If AgL.RequiredField(TxtLibraryMemberType, LblLibraryMemberType.Text) Then Exit Function
            End If

            If AgL.StrCmp(TxtAdmissionSemester.Text, TxtPromotionSemester.Text) Then
                MsgBox("""Promotion Semester"" And ""Admission Semester"" Can't Be Same!...") : TxtPromotionSemester.Focus() : Exit Function
            End If

            If mFromSemesterSerialNo >= mToSemesterSerialNo And mToSemesterSerialNo > 0 Then
                MsgBox("""Promotion Semester"" Serial No >= ""Admission Semester""!...") : TxtPromotionSemester.Focus() : Exit Function
            End If

            If LblPromotionSemester.Tag.ToString.Trim <> "" Then
                If Not AgL.StrCmp(TxtIsStreamChange.Text, "Yes") Then
                    If Not AgL.StrCmp(mFirstStreamCode, mToSemesterStreamCode) Then
                        MsgBox("""Promotion Semester"" Stream Is Not Same As ""Admission Semester"" Stream!...") : TxtPromotionSemester.Focus() : Exit Function
                    End If
                End If
            End If

            If AgL.StrCmp(TxtIsDiplomaHolder.Text, "Yes") Then
                If AgL.StrCmp(LblSessionProgrammeStream.Tag.ToString, TxtSessionProgramme.AgSelectedValue) Then
                    MsgBox("Session/Programme Is Not Valid For Diploma Holder Student!...")
                    TxtSessionProgramme.Focus()
                    Exit Function
                End If
            Else
                If Not AgL.StrCmp(LblSessionProgrammeStream.Tag.ToString, TxtSessionProgramme.AgSelectedValue) Then
                    MsgBox("Session/Programme Is Not Valid!...")
                    TxtSessionProgramme.Focus()
                    Exit Function
                End If
            End If


            If AgL.RequiredField(TxtStudent, "Student") Then Exit Function
            If TxtRegistrationDocId.Text.Trim <> "" Then
                bStudentCode = AgL.XNull(AgL.Dman_Execute("SELECT Sd.Student FROM Sch_RegistrationStudentDetail Sd With (NoLock) WHERE Sd.DocId = " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & " ", AgL.GCn).ExecuteScalar)
                If Not AgL.StrCmp(TxtStudent.AgSelectedValue, bStudentCode) Then
                    MsgBox("" & TxtStudent.Text & " Student Is Not Valid!..." & vbCrLf & "Correct Student Is Assisgned!...")
                    TxtStudent.AgSelectedValue = bStudentCode
                End If
            End If

            mQry = "SELECT IsNull(Count(*),0) Cnt FROM ViewSch_Admission A With (NoLock) " & _
                    " WHERE A.Student = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & " " & _
                    " AND A.LeavingDate IS NULL And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " A.DocId <> '" & mSearchCode & "' ") & " "
            If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
                MsgBox("Admission Is Not Permitted!..." & vbCrLf & "Student Is Presently Studying!...")
                TxtStudent.Focus() : Exit Function
            End If

            If Val(TxtCounselingFee.Text) > 0 Then
                If AgL.RequiredField(TxtCounselingFeeReceiptNo, "Counseling Fee Receipt No.") Then Exit Function
            Else
                If TxtCounselingFeeReceiptNo.Text.Trim <> "" Then
                    MsgBox("Counseling Fee Receipt No. Is Not Required!...", MsgBoxStyle.Critical, "Validation Check")
                    TxtCounselingFeeReceiptNo.Focus() : Exit Function
                End If
            End If

            If mBlnImprtFromExcelFlag = False Then
                If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                    Tc1.SelectedTab = Tp1

                    If (AgL.StrCmp(mLastFromStreamYearSemesterCode_Fee, TxtAdmissionSemester.AgSelectedValue) = False Or _
                        AgL.StrCmp(mLastToStreamYearSemesterCode_Fee, TxtPromotionSemester.AgSelectedValue) = False) Then

                        MsgBox("Please Fill Fee Detail!...")
                        BtnFillFee.Focus() : Exit Function
                    End If

                    AgCL.AgBlankNothingCells(DGL1)
                    If AgCL.AgIsBlankGrid(DGL1, Col1StreamYearSemester) Then Exit Function
                    If AgCL.AgIsDuplicate(DGL1, "" & Col1StreamYearSemester & "," & Col1Fee & "") Then Exit Function

                    Dim bStreamYearSemester$ = ""
                    If TxtPromotionSemester.AgSelectedValue.Trim <> "" Then
                        bStreamYearSemester = TxtPromotionSemester.AgSelectedValue
                    Else
                        bStreamYearSemester = TxtAdmissionSemester.AgSelectedValue
                    End If


                    With DGL1
                        mBlnIsSemFeeExists = False
                        For I = 0 To .Rows.Count - 1
                            If AgL.StrCmp(bStreamYearSemester, AgL.XNull(.AgSelectedValue(Col1StreamYearSemester, I)).ToString) Then
                                If mBlnIsSemFeeExists = False Then mBlnIsSemFeeExists = True : Exit For
                            End If
                        Next
                    End With
                End If


                AgCL.AgBlankNothingCells(DGL3)
                If AgCL.AgIsBlankGrid(DGL3, DGL3.Columns(Col3DocumentCode).Index) Then Tc1.SelectedTab = Tp4 : Exit Function
                If AgCL.AgIsDuplicate(DGL3, "" & DGL3.Columns(Col3DocumentCode).Index & "") Then Tc1.SelectedTab = Tp4 : Exit Function

                Tc1.SelectedTab = Tp2
                If (AgL.StrCmp(mLastFromStreamYearSemesterCode_Subject, TxtAdmissionSemester.AgSelectedValue) = False Or _
                    AgL.StrCmp(mLastToStreamYearSemesterCode_Subject, TxtPromotionSemester.AgSelectedValue) = False) Then

                    MsgBox("Please Fill Subject Detail!...")
                    BtnFillSubject.Focus() : Exit Function
                End If

                AgCL.AgBlankNothingCells(DGL2)
                If AgCL.AgIsBlankGrid(DGL2, Col2ManualCode) Then Tc1.SelectedTab = Tp2 : DGL2.Focus() : Exit Function
                If AgCL.AgIsDuplicate(DGL2, "" & Col2SemesterSubject & "," & Col2Subject & "") Then Tc1.SelectedTab = Tp2 : DGL2.Focus() : Exit Function

                With DGL2
                    For I = 0 To DGL2.Rows.Count - 1
                        If .Item(Col2SemesterSubject, I).Value.ToString.Trim <> "" Then
                            If AgL.StrCmp(DGL2.Item(Col2IsSubjectSelected, I).Value.ToString, "No") And Val(DGL2.Item(Col2IsElectiveSubject, I).Value) = 0 Then
                                MsgBox("""" & DGL2.Item(Col2Subject, I).Value & """ Is A Compulsory Subject!...") : DGL2.CurrentCell = DGL2(Col2IsSubjectSelected, I) : DGL2.Focus() : Exit Function
                            End If
                        End If
                    Next
                End With

                If Not AgCL.AgCheckMandatory(Me) Then Exit Function
            End If

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mSearchCode <> TxtDocId.Text And TxtDocId.Text.Trim <> "" Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                    TxtDocId.Text = mSearchCode
                End If

                TxtAdmissionID.Text = GetAdmissionID()
            End If

            If Academic_ProjLib.ClsMain.IsModuleActive_Library Then
                mObjStructLibraryMember = Nothing
                If Not FunCreateLibraryMemberStructure(mObjStructLibraryMember, mBlnIsLibraryMemberExists) Then Exit Function
            End If

            If Academic_ProjLib.ClsMain.IsModuleActive_Transport Then
                If AgL.StrCmp(TxtIsTransport.Text, "Yes") Then
                    mObjStructTransportMember = Nothing
                    If Not FunCreateTransportMemberStructure(mObjStructTransportMember, mBlnIsTransportMemberExists) Then Exit Function
                End If
            End If

            If Academic_ProjLib.ClsMain.IsModuleActive_Mess Then
                If AgL.StrCmp(TxtIsMess.Text, "Yes") Then
                    mObjStructMessMember = Nothing
                    If Not FunCreateMessMemberStructure(mObjStructMessMember, mBlnIsMessMemberExists) Then Exit Function
                End If
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        Dim DrTemp As DataRow() = Nothing

        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            If mBlnImprtFromExcelFlag Then
                DrTemp = TxtV_Type.AgHelpDataSet.Tables(0).Select("NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_StudentAdmission) & "")
                If DrTemp.Length > 0 Then
                    TxtV_Type.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                    LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
                End If
            End If
            DrTemp = Nothing

            TxtV_Type.Enabled = True
        End If

        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled Then TxtV_Type.Focus() Else TxtV_Date.Focus()
        Else
            TxtV_Date.Focus()
        End If
    End Sub

    Private Sub BtnFillFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillFee.Click, BtnFillSubject.Click
        Try
            Select Case sender.name
                Case BtnFillFee.Name
                    Call ProcFillFee()

                Case BtnFillSubject.Name
                    Call ProcFillSubject()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillSubject()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim bCondStr$ = "", bNewSemesterStartDate$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL2.RowCount = 1 : DGL2.Rows.Clear()
            mLastFromStreamYearSemesterCode_Subject = TxtAdmissionSemester.AgSelectedValue
            mLastToStreamYearSemesterCode_Subject = TxtPromotionSemester.AgSelectedValue

            Dim bFromSemesterStartDate$ = ""
            mQry = "SELECT Sem.SemesterStartDate " & _
                    " FROM ViewSch_StreamYearSemester Sem " & _
                    " WHERE Sem.Code = " & AgL.Chk_Text(TxtAdmissionSemester.AgSelectedValue) & ""
            bFromSemesterStartDate = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar

            If AgL.RequiredField(TxtSessionProgrammeStream) Then Exit Sub


            If bNewSemesterStartDate.Trim = "" Then
                If TxtPromotionSemester.Text.Trim = "" Then
                    bCondStr = " And Sem.SessionProgrammeStreamCode = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " And Sem.SemesterStartDate >= " & AgL.ConvertDate(bFromSemesterStartDate) & " "
                ElseIf TxtPromotionSemester.Text.Trim <> "" Then
                    If AgL.StrCmp(LblAdmissionSemester.Tag, LblPromotionSemester.Tag) Then
                        bCondStr = " And Sem.SessionProgrammeStreamCode = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & "  And Sem.SemesterSerialNo >= " & mToSemesterSerialNo & " "
                    Else
                        bCondStr = " And Sem.SessionProgrammeStreamCode = " & AgL.Chk_Text(LblPromotionSemester.Tag.ToString) & "  And Sem.SemesterSerialNo >= " & mToSemesterSerialNo & " "
                    End If
                End If

                mQry = "SELECT Ss.Code As SemesterSubject, Ss.Subject AS SubjectCode, " & _
                        " Ss.ManualCode, Ss.PaperID, Ss.IsElectiveSubject, " & _
                        " Convert(Bit,Case When Ss.IsElectiveSubject = 0 Then 1 Else 0 End) As IsSubjectSelected, " & _
                        " Ss.RowId As Sr, Null as OtherSemesterSubject, Sem.SemesterStartDate, Ss.MinCreditHours  " & _
                        " FROM Sch_SemesterSubject Ss " & _
                        " LEFT JOIN Sch_Subject S ON Ss.Subject = S.Code " & _
                        " LEFT JOIN ViewSch_StreamYearSemester Sem ON Ss.StreamYearSemester = Sem.Code " & _
                        " Where 1=1 " & bCondStr & " " & _
                        " ORDER BY Sem.SemesterStartDate , Ss.RowId, Sem.StreamYearSemesterDesc, S.Description "
            Else
                'bCondStr = " And VSub.SessionProgrammeStreamCode = " & AgL.Chk_Text(LblNewStreamYearSemester.Tag.ToString) & " "

                'mQry = "Select Ads.SemesterSubject, VSub.Subject AS SubjectCode,  VSub.ManualCode,  " & _
                '        " VSub.PaperID, VSub.IsElectiveSubject, Convert(Bit,1) As IsSubjectSelected, " & _
                '        " Ads.Sr, Ads.OtherSemesterSubject, VSub.SemesterStartDate " & _
                '        " From Sch_AdmissionSubject Ads   " & _
                '        " Left Join ViewSch_SemesterSubject VSub On Ads.SemesterSubject = VSub.Code   " & _
                '        " Where Ads.DocId = '" & mSearchCode & "' And " & _
                '        " VSub.SemesterStartDate " & IIf(AgL.StrCmp(TxtIsNewStatusAfterPromotion.Text, "Yes"), "<=", "<") & " " & AgL.ConvertDate(bNewSemesterStartDate) & " " & _
                '        " UNION ALL " & _
                '        " Select VSub.Code AS SemesterSubject, VSub.Subject AS SubjectCode,  VSub.ManualCode,  " & _
                '        " VSub.PaperID, VSub.IsElectiveSubject, Convert(Bit,Case When IsNull(VSub.IsElectiveSubject,0) = 0 Then 1 Else 0 End) As IsSubjectSelected, " & _
                '        " 999999 As Sr, Null as OtherSemesterSubject, VSub.SemesterStartDate " & _
                '        " FROM ViewSch_SemesterSubject VSub " & _
                '        " Where 1=1 " & bCondStr & " And VSub.SemesterStartDate >= " & AgL.ConvertDate(bNewSemesterStartDate) & " " & _
                '        " ORDER BY Sr, SemesterStartDate  "


            End If
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL2.RowCount = 1 : DGL2.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL2.Rows.Add()
                        DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count
                        DGL2.AgSelectedValue(Col2SemesterSubject, I) = AgL.XNull(.Rows(I)("SemesterSubject"))
                        DGL2.AgSelectedValue(Col2Subject, I) = AgL.XNull(.Rows(I)("SubjectCode"))
                        DGL2.Item(Col2ManualCode, I).Value = AgL.XNull(.Rows(I)("ManualCode"))
                        DGL2.Item(Col2PaperID, I).Value = AgL.XNull(.Rows(I)("PaperId"))
                        DGL2.Item(Col2MinCreditHours, I).Value = Format(AgL.VNull(.Rows(I)("MinCreditHours")), "0.00")
                        DGL2.Item(Col2IsSubjectSelected, I).Value = IIf(AgL.VNull(.Rows(I)("IsSubjectSelected")), "Yes", "No")
                        DGL2.Item(Col2IsElectiveSubject, I).Value = IIf(AgL.VNull(.Rows(I)("IsElectiveSubject")), 1, 0)
                    Next I
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            DGL2.RowCount = 1 : DGL2.Rows.Clear()
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub ProcFillFee()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim bCondStr$ = "", bCondStr1$ = "", bQrySem$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            mLastFromStreamYearSemesterCode_Fee = TxtAdmissionSemester.AgSelectedValue
            mLastToStreamYearSemesterCode_Fee = TxtPromotionSemester.AgSelectedValue

            Dim bFromSemesterStartDate$ = ""
            mQry = "SELECT Sem.SemesterStartDate " & _
                    " FROM ViewSch_StreamYearSemester Sem " & _
                    " WHERE Sem.Code = " & AgL.Chk_Text(TxtAdmissionSemester.AgSelectedValue) & ""
            bFromSemesterStartDate = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar

            If AgL.RequiredField(TxtSessionProgrammeStream, "Programme (Stream)") Then Exit Sub
            If AgL.RequiredField(TxtSessionProgramme, "Session/Program") Then Exit Sub
            If AgL.RequiredField(TxtAdmissionSemester, "Admission Semester") Then Exit Sub
            If AgL.RequiredField(TxtIsDiplomaHolder, "Is Diploma Holder?") Then Exit Sub

            If AgL.StrCmp(TxtIsDiplomaHolder.Text, "Yes") Then
                If AgL.StrCmp(LblSessionProgrammeStream.Tag.ToString, TxtSessionProgramme.AgSelectedValue) Then
                    MsgBox("Session/Programme Is Not Valid For Diploma Holder Student!...")
                    TxtSessionProgramme.Focus()
                    Exit Sub
                End If
            Else
                If Not AgL.StrCmp(LblSessionProgrammeStream.Tag.ToString, TxtSessionProgramme.AgSelectedValue) Then
                    MsgBox("Session/Programme Is Not Valid!...")
                    TxtSessionProgramme.Focus()
                    Exit Sub
                End If
            End If

            bCondStr = " Where 1=1 "

            If TxtPromotionSemester.Text.Trim = "" Then
                bCondStr += " And Sem.SessionProgrammeStreamCode = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " And Sem.SemesterStartDate >= " & AgL.ConvertDate(bFromSemesterStartDate) & ""
            ElseIf TxtPromotionSemester.Text.Trim <> "" Then
                If AgL.StrCmp(LblAdmissionSemester.Tag, LblPromotionSemester.Tag) Then
                    bCondStr += " And Sem.SessionProgrammeStreamCode = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " And Sem.SemesterSerialNo >= " & mToSemesterSerialNo & " "
                Else
                    bCondStr += " And Sem.SessionProgrammeStreamCode = " & AgL.Chk_Text(LblPromotionSemester.Tag.ToString) & "  And Sem.SemesterSerialNo >= " & mToSemesterSerialNo & " "
                End If
            End If

            If Not AgL.StrCmp(TxtIsDiplomaHolder.Text, "Yes") Then
                mQry = "SELECT Sf.StreamYearSemester, Sf.Fee, Sf.Amount, " & _
                        " Sem.SemesterStartDate, Sem.StreamYearSemesterDesc, Null As FeeStreamYearSemester " & _
                        " FROM Sch_StreamYearSemesterFee Sf " & _
                        " LEFT JOIN ViewSch_StreamYearSemester Sem ON Sf.StreamYearSemester = Sem.Code " & _
                        " " & bCondStr & " " & _
                        " ORDER BY Sem.SemesterStartDate , Sem.StreamYearSemesterDesc, Sf.RowId "
            Else
                bCondStr1 = " Where Sem1.SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "

                If TxtPromotionSemester.Text.Trim = "" Then
                    bCondStr1 += " And Sem1.StreamCode = " & AgL.Chk_Text(mFromSemesterStreamCode) & " And Sem1.SemesterStartDate >= " & AgL.ConvertDate(bFromSemesterStartDate) & ""
                ElseIf TxtPromotionSemester.Text.Trim <> "" Then
                    If AgL.StrCmp(LblAdmissionSemester.Tag, LblPromotionSemester.Tag) Then
                        bCondStr1 += " And Sem1.StreamCode = " & AgL.Chk_Text(mFromSemesterStreamCode) & " And Sem1.SemesterSerialNo >= " & mToSemesterSerialNo & " "
                    Else
                        bCondStr1 += " And Sem1.StreamCode = " & AgL.Chk_Text(mToSemesterStreamCode) & "  And Sem1.SemesterSerialNo >= " & mToSemesterSerialNo & " "
                    End If
                End If

                bQrySem = "Select P.Semesters As TotalSemesters, P.ProgrammeDuration, Sem.* " & _
                            " From ViewSch_StreamYearSemester Sem " & _
                            " LEFT JOIN Sch_Programme P ON Sem.ProgrammeCode = P.Code " & bCondStr

                mQry = "SELECT vSem.Code As StreamYearSemester, Sf.Fee, Sf.Amount, " & _
                        " vSem.SemesterStartDate, vSem.StreamYearSemesterDesc, Null As FeeStreamYearSemester " & _
                        " FROM Sch_StreamYearSemesterFee Sf " & _
                        " INNER JOIN ViewSch_StreamYearSemester Sem1 ON Sf.StreamYearSemester = Sem1.Code " & _
                        " INNER JOIN (" & bQrySem & ") vSem ON vSem.SemesterSerialNo - (vSem.TotalSemesters / vSem.ProgrammeDuration) = Sem1.SemesterSerialNo  " & _
                        " " & bCondStr1 & " " & _
                        " ORDER BY vSem.SemesterStartDate , vSem.StreamYearSemesterDesc, Sf.RowId "
            End If
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp

                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                        DGL1.AgSelectedValue(Col1StreamYearSemester, I) = AgL.XNull(.Rows(I)("StreamYearSemester"))
                        DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        DGL1.AgSelectedValue(Col1FeeStreamYearSemester, I) = AgL.XNull(.Rows(I)("FeeStreamYearSemester"))
                    Next I
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub ProcCreateFeeDueStructure(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, ByVal bConnRead As SqlClient.SqlConnection, ByVal bConnectionString As String, ByVal bEntryMode As String, ByVal bAdmissionDocId As String, ByVal bStreamYearSemester As String, _
                                                ByRef bFeeDueObj As Academic_ProjLib.ClsMain.Struct_FeeDue, ByRef bFeeDue1Obj() As Academic_ProjLib.ClsMain.Struct_FeeDue1, ByRef bFeeDueDocId As String, _
                                                Optional ByVal bIsNewStatus_FeeDue As Boolean = False)

        Dim I As Integer, J As Integer, mFlagBln As Boolean = False
        Dim bSite_Code$ = "", bDiv_Code$ = "", bV_Type$ = "", bV_Prefix$ = "", bV_No As Long = 0, bV_Date$ = "", bSearchCode$ = ""
        Dim bDtTable As DataTable
        Dim bQry$ = ""
        Dim bTotalAmount As Double = 0

        If bIsNewStatus_FeeDue = False Then
            bQry = "SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student , Adm.AdmissionID , " & _
                    " Adm.V_Date, AdmFee.*, Fd1.Code As FeeDueCode " & _
                    " FROM Sch_Admission Adm WITH (NoLock) " & _
                    " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId " & _
                    " Left Join Sch_AdmissionFeeDue Afd With (NoLock) On Adm.DocId = Afd.AdmissionDocId " & _
                    " Left Join Sch_FeeDue1 Fd1 With (NoLock) On Afd.AdmissionDocId = Fd1.AdmissionDocId And Afd.FeeDueDocId = Fd1.DocId And AdmFee.Fee = Fd1.Fee " & _
                    " Where Adm.DocId = '" & bAdmissionDocId & "' And AdmFee.StreamYearSemester = '" & bStreamYearSemester & "' "
        Else
            bQry = "SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student , Adm.AdmissionID , " & _
                    " " & AgL.ConvertDate(bFeeDueObj.V_Date) & " As V_Date, AdmFee.*, Null As FeeDueCode " & _
                    " FROM Sch_Admission Adm WITH (NoLock) " & _
                    " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId " & _
                    " Where Adm.DocId = '" & bAdmissionDocId & "' And AdmFee.StreamYearSemester = '" & bStreamYearSemester & "' "
        End If
        bDtTable = AgL.FillData(bQry, bConnRead).Tables(0)


        With bDtTable
            If .Rows.Count > 0 Then
                bSite_Code = AgL.XNull(.Rows(0)("Site_Code"))
                bDiv_Code = AgL.XNull(.Rows(0)("Div_Code"))
                bV_Date = Format(AgL.XNull(.Rows(0)("V_Date")), "Short Date")

                If (bEntryMode = "Add" And bV_Date.Trim <> "" And bSite_Code.Trim <> "") Or bIsNewStatus_FeeDue Or bFeeDueDocId.Trim = "" Then
                    bQry = "Select Vt.V_Type From Voucher_Type Vt With (NoLock) " & _
                            " Where Vt.NCat = '" & Academic_ProjLib.ClsMain.NCat_FeeDue & "' "
                    bV_Type = AgL.XNull(AgL.Dman_Execute(bQry, bConnRead).ExecuteScalar)

                    bSearchCode = AgL.GetDocId(bV_Type, CStr(bV_No), CDate(bV_Date), bConnRead, bDiv_Code, bSite_Code)
                    If bIsNewStatus_FeeDue Then
                        bFeeDueDocId = bSearchCode
                    Else
                        mFeeDueDocId = bSearchCode
                    End If

                Else
                    If Not bIsNewStatus_FeeDue Then bSearchCode = mFeeDueDocId
                    bV_Type = AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherType)
                End If


                If bSearchCode.Trim = "" Then Err.Raise(1, , "Error in Fee Due Search Code Generation!...")

                bV_No = Val(AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                bV_Prefix = AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                J = 0
                For I = 0 To .Rows.Count - 1
                    If AgL.VNull(.Rows(I)("Amount")) > 0 Then
                        If mFlagBln = False Then
                            J = 0
                            mFlagBln = True
                        Else
                            J = UBound(bFeeDue1Obj) + 1
                        End If
                        ReDim Preserve bFeeDue1Obj(J)

                        bFeeDue1Obj(J).Code = AgL.XNull(.Rows(I)("FeeDueCode"))
                        bFeeDue1Obj(J).DocId = bSearchCode
                        bFeeDue1Obj(J).AdmissionDocId = bAdmissionDocId
                        bFeeDue1Obj(J).Fee = AgL.XNull(.Rows(I)("Fee"))
                        bFeeDue1Obj(J).Amount = AgL.VNull(.Rows(I)("Amount"))

                        bTotalAmount += AgL.VNull(.Rows(I)("Amount"))
                    End If
                Next

                If J = 0 And mFlagBln = False Then
                    ReDim Preserve bFeeDue1Obj(J)

                    bFeeDue1Obj(J).Code = ""
                    bFeeDue1Obj(J).DocId = bSearchCode
                    bFeeDue1Obj(J).AdmissionDocId = bAdmissionDocId
                    bFeeDue1Obj(J).Fee = ""
                    bFeeDue1Obj(J).Amount = 0

                End If

                bFeeDueObj.DocId = bSearchCode
                bFeeDueObj.Div_Code = bDiv_Code
                bFeeDueObj.Site_Code = bSite_Code
                bFeeDueObj.V_Type = bV_Type
                bFeeDueObj.V_Prefix = bV_Prefix
                bFeeDueObj.V_No = bV_No
                bFeeDueObj.V_Date = bV_Date
                bFeeDueObj.Remark = ""
                bFeeDueObj.TotalAmount = bTotalAmount
                bFeeDueObj.StreamYearSemester = bStreamYearSemester
            End If
        End With
    End Sub

    Private Sub BtnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnApproved.Click
        Dim mTrans As Boolean = False
        Dim mApprovedDate$ = ""

        Select Case sender.name
            Case BtnApproved.Name
                Try
                    If Topctrl1.Mode = "Browse" Then
                        If MsgBox("Are You Sure To Approve Record", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Approved Confirmation...") = MsgBoxResult.No Then Exit Sub

                        If mSearchCode <> "" Then
                            ''=======================Approval Start======================================

                            TxtApproved.Text = AgL.PubUserName
                            mApprovedDate = AgL.GetDateTime(AgL.GCn)

                            AgL.ECmd = AgL.GCn.CreateCommand
                            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                            AgL.ECmd.Transaction = AgL.ETrans
                            mTrans = True


                            Call ProcApproveVoucher(TxtApproved.Text, mApprovedDate, False)

                            ''===========================================================================

                            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                            AgL.ETrans.Commit()
                            mTrans = False

                            MsgBox("Voucher Approved Successfully.", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                            If AgL.PubMoveRecApplicable Then
                                FIniMaster(0, 1) : Topctrl_tbRef()
                            End If
                            MoveRec()
                        End If
                    End If
                Catch ex As Exception
                    If mTrans = True Then AgL.ETrans.Rollback()
                    MsgBox(ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                End Try
        End Select
    End Sub

    Private Sub ProcApproveVoucher(ByVal StrApprovedBy As String, ByVal StrApprovedDate As String, ByVal BlnIsAutoApproved As Boolean)

        mQry = "Update Sch_Admission Set ApprovedBy='" & StrApprovedBy & "', ApprovedDate=" & AgL.Chk_Text(StrApprovedDate) & ", IsAutoApproved = " & IIf(BlnIsAutoApproved, 1, 0) & " Where DocId='" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        Call ProcSaveFeeDueDetail(Not BlnIsAutoApproved)

        Call AgL.LogTableEntry(mSearchCode, Me.Text, AgLibrary.ClsConstant.EntryMode_Varified, AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , TxtV_Date.Text, , , , TxtSite_Code.AgSelectedValue, AgL.PubDivCode)
    End Sub

    Private Function FunCreateLibraryMemberStructure(ByRef ObjStructLibraryMember As ClsMain.StructLibraryMember, ByRef BlnIsMemberExists As Boolean) As Boolean
        Dim bBlnRerurn As Boolean = False
        Dim DrTemp As DataRow() = Nothing
        Dim bDtMember As DataTable = Nothing
        Try
            ObjStructLibraryMember = New ClsMain.StructLibraryMember()
            ObjStructLibraryMember.ProcBlankStruct()


            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                BlnIsMemberExists = False
            Else
                mQry = "SELECT M.* FROM Lib_Member M WHERE M.SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & " "
                bDtMember = AgL.FillData(mQry, AgL.GCn).Tables(0)

                If bDtMember.Rows.Count > 0 Then
                    BlnIsMemberExists = True
                Else
                    BlnIsMemberExists = False
                End If
            End If

            With ObjStructLibraryMember
                .StrSubCode = TxtStudent.AgSelectedValue
                .StrStuent = TxtStudent.AgSelectedValue
                .StrEmployee = ""
                .StrMemberType = TxtLibraryMemberType.AgSelectedValue
                .StrAdmissionNo = TxtAdmissionID.Text
                .StrSiteCode = TxtlibrarySite.AgSelectedValue

                DrTemp = TxtStudent.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & "")
                If DrTemp.Length > 0 Then
                    .StrMotherName = AgL.XNull(DrTemp(0)("MotherName"))
                    .StrManualCode = AgL.XNull(DrTemp(0)("ManualCode"))
                End If

                DrTemp = TxtSessionProgramme.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & "")
                If DrTemp.Length > 0 Then
                    .StrClass = AgL.XNull(DrTemp(0)("ProgrammeManualCode"))
                    .StrSession = AgL.XNull(DrTemp(0)("SessionManualCode"))
                End If

                If BlnIsMemberExists Then
                    .StrUID = AgL.XNull(bDtMember.Rows(0)("UID").ToString)

                    If Not (AgL.StrCmp(.StrClass, AgL.XNull(bDtMember.Rows(0)("Class"))) _
                        And AgL.StrCmp(.StrSession, AgL.XNull(bDtMember.Rows(0)("Session")))) _
                        Or AgL.XNull(bDtMember.Rows(0)("MemberCardNo")).ToString.Trim = "" Then

                        .StrMemberCardNo = mObjClsMain.FunGetMemberCardNo(.StrClass, .StrSession, .StrManualCode)
                    Else
                        .StrMemberCardNo = AgL.XNull(bDtMember.Rows(0)("MemberCardNo"))
                    End If
                Else
                    .StrMemberCardNo = mObjClsMain.FunGetMemberCardNo(.StrClass, .StrSession, .StrManualCode)
                End If
            End With

            bBlnRerurn = True
        Catch ex As Exception
            bBlnRerurn = False
        Finally
            FunCreateLibraryMemberStructure = bBlnRerurn
        End Try
    End Function
    Private Function FunCreateTransportMemberStructure(ByRef ObjStructTransportMember As ClsMain.StructTransportMember, ByRef BlnIsMemberExists As Boolean) As Boolean
        Dim bBlnRerurn As Boolean = False
        Dim DrTemp As DataRow() = Nothing
        Dim bDtMember As DataTable = Nothing
        Try
            ObjStructTransportMember = New ClsMain.StructTransportMember()
            ObjStructTransportMember.ProcBlankStruct()


            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                BlnIsMemberExists = False
                '**************Rati 21/Apr/2012************
                CType(mFrmObjTransportInfo, FrmTransportInfo).MemberCardNo()
                If CType(mFrmObjTransportInfo, FrmTransportInfo).MemberCardNo() <> CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text And CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text.Trim <> "" Then
                    MsgBox("Card SrNo : " & CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text & " Already Exist New Card SrNo Alloted : " & CType(mFrmObjTransportInfo, FrmTransportInfo).MemberCardNo() & "")
                    CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text = CType(mFrmObjTransportInfo, FrmTransportInfo).MemberCardNo()
                End If
                '*********
            Else
                mQry = "SELECT M.* FROM Tp_Member M WHERE M.SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & " "
                bDtMember = AgL.FillData(mQry, AgL.GCn).Tables(0)

                If bDtMember.Rows.Count > 0 Then
                    BlnIsMemberExists = True
                Else
                    BlnIsMemberExists = False
                End If
            End If

          
            With ObjStructTransportMember
                .StrSubCode = TxtStudent.AgSelectedValue
                .StrStuent = TxtStudent.AgSelectedValue
                .StrEmployee = ""
                .StrMemberCardNo = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtMemberCardNo.Text
                .StrCardPrefix = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardPrefix.Text
                .StrCardSrNo = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text
                .StrValidTillDate = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtValidTillDate.Text
                .StrVehicle = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtVehicle.AgSelectedValue
                .StrSeatno = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtSeatNo.Text
                .StrRoute = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtRoute.AgSelectedValue
                .StrPickupPoint = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtPickUpPoint.AgSelectedValue
               

                If BlnIsMemberExists Then
                    .StrUID = AgL.XNull(bDtMember.Rows(0)("UID").ToString)
                    .StrMemberCardNo = AgL.XNull(bDtMember.Rows(0)("MemberCardNo"))
                    .StrCardPrefix = AgL.XNull(bDtMember.Rows(0)("CardPrefix"))
                    .StrCardSrNo = AgL.XNull(bDtMember.Rows(0)("CardSrNo"))
                    .StrValidTillDate = AgL.XNull(bDtMember.Rows(0)("ValidTillDate"))
                    .StrVehicle = AgL.XNull(bDtMember.Rows(0)("Vehicle"))
                    .StrSeatno = AgL.XNull(bDtMember.Rows(0)("SeatNo"))
                    .StrRoute = AgL.XNull(bDtMember.Rows(0)("Route"))
                    .StrPickupPoint = AgL.XNull(bDtMember.Rows(0)("PickUpPoint"))
                End If
            End With

            bBlnRerurn = True
        Catch ex As Exception
            bBlnRerurn = False
        Finally
            FunCreateTransportMemberStructure = bBlnRerurn
        End Try
    End Function
    Private Function FunCreateMessMemberStructure(ByRef ObjStructMessMember As ClsMain.StructMessMember, ByRef BlnIsMemberExists As Boolean) As Boolean
        Dim bBlnRerurn As Boolean = False
        Dim DrTemp As DataRow() = Nothing
        Dim bDtMember As DataTable = Nothing
        Try
            ObjStructMessMember = New ClsMain.StructMessMember()
            ObjStructMessMember.ProcBlankStruct()


            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                BlnIsMemberExists = False
            Else
                mQry = "SELECT M.* FROM Mess_Member M WHERE M.SubCode = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & " "
                bDtMember = AgL.FillData(mQry, AgL.GCn).Tables(0)

                If bDtMember.Rows.Count > 0 Then
                    BlnIsMemberExists = True
                Else
                    BlnIsMemberExists = False
                End If
            End If

            With ObjStructMessMember
                .StrSubCode = TxtStudent.AgSelectedValue
                .StrStuent = TxtStudent.AgSelectedValue
                .StrEmployee = ""
                .StrMemberType = ClsMain.MemberType.Student
                .StrJoinDate = txtMessJoinDt.Text

                If BlnIsMemberExists Then
                    .StrJoinDate = AgL.XNull(bDtMember.Rows(0)("JoiningDate"))
                End If
            End With

            bBlnRerurn = True
        Catch ex As Exception
            bBlnRerurn = False
        Finally
            FunCreateMessMemberStructure = bBlnRerurn
        End Try
    End Function


    

    Private Function FunGetModuleName() As String
        Dim bStrReturn$ = ""
        Try
            If Academic_ProjLib.ClsMain.IsModuleActive_AcademicMain Then
                bStrReturn = Academic_Objects.ClsConstant.Module_Academic_Main
            ElseIf Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                bStrReturn = Academic_Objects.ClsConstant.Module_Academic_Fee
            Else
                bStrReturn = ""
            End If
        Catch ex As Exception
            bStrReturn = ""
        Finally
            FunGetModuleName = bStrReturn
        End Try
    End Function

    Private Sub BtnImprtFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprtFromExcel.Click
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim FW As System.IO.StreamWriter = New System.IO.StreamWriter("C:\ImportLog.Txt", False, System.Text.Encoding.Default)
        Dim StrErrLog As String = ""
        Dim DrTemp As DataRow() = Nothing

        mBlnIsUserCanApprove = False

        mQry = "                  Select '' as Srl, 'Student Code' as [Field Name],'Text' as [Data Type], 20 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Admission Date' as [Field Name],'DATETIME' as [Data Type], 0 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Admission Nature' as [Field Name],'Text' as [Data Type], 20 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Admission Session' as [Field Name],'Text' as [Data Type], 5 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Admission Programme' as [Field Name],'Text' as [Data Type], 20 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Admission Stream' as [Field Name],'Text' as [Data Type], 20 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Admission Semester' as [Field Name],'Text' as [Data Type], 20 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Current Status' as [Field Name],'Text' as [Data Type], 20 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Is Stream Change' as [Field Name],'Text' as [Data Type], 3 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Promotion Session' as [Field Name],'Text' as [Data Type], 5 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Promotion Programme' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Promotion Stream' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Promotion Semester' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Counseling Fee' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Counseling Fee Receipt No' as [Field Name],'Text' as [Data Type], 35 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Diploma Holder' as [Field Name],'Text' as [Data Type], 3 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Library Member Type' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "


        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Dim ObjFrmImport As New FrmImportFromExcel
        ObjFrmImport.LblTitle.Text = "Student Import"
        ObjFrmImport.Dgl1.DataSource = DtTemp
        ObjFrmImport.ShowDialog()

        If Not AgL.StrCmp(ObjFrmImport.UserAction, "OK") Then Exit Sub

        DtTemp = ObjFrmImport.P_DsExcelData.Tables(0)
        For I = 0 To DtTemp.Rows.Count - 1
            Topctrl1.FButtonClick(0)

            mBlnImprtFromExcelFlag = True

            If AgL.XNull(DtTemp.Rows(I)("Student Code")).ToString.Trim <> "" Then
                DrTemp = TxtStudent.AgHelpDataSet.Tables(0).Select("ManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Student Code"))) & "")
                If DrTemp.Length > 0 Then
                    TxtStudent.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                End If
                DrTemp = Nothing

                Call ProcValidatingControl(TxtStudent)
            End If

            If TxtStudent.Text.Trim <> "" Then
                TxtV_Date.Text = Format(AgL.XNull(DtTemp.Rows(I)("Admission Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                TxtStatus.Text = AgL.XNull(DtTemp.Rows(I)("Current Status"))
                TxtIsStreamChange.Text = IIf(AgL.StrCmp(AgL.XNull(DtTemp.Rows(I)("Is Stream Change")).ToString, "Yes"), "Yes", "No")
                TxtIsDiplomaHolder.Text = IIf(AgL.StrCmp(AgL.XNull(DtTemp.Rows(I)("Diploma Holder")).ToString, "Yes"), "Yes", "No")

                TxtCounselingFee.Text = Format(AgL.VNull(DtTemp.Rows(I)("Counseling Fee")), "0.00")
                TxtCounselingFeeReceiptNo.Text = AgL.XNull(DtTemp.Rows(I)("Counseling Fee Receipt No"))

                If AgL.XNull(DtTemp.Rows(I)("Admission Nature")).ToString.Trim <> "" Then
                    DrTemp = TxtAdmissionNature.AgHelpDataSet.Tables(0).Select("ManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Admission Nature"))) & "")
                    If DrTemp.Length > 0 Then
                        TxtAdmissionNature.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing
                End If

                If AgL.XNull(DtTemp.Rows(I)("Admission Session")).ToString.Trim <> "" _
                    And AgL.XNull(DtTemp.Rows(I)("Admission Programme")).ToString.Trim <> "" _
                    And AgL.XNull(DtTemp.Rows(I)("Admission Stream")).ToString.Trim <> "" Then

                    DrTemp = TxtSessionProgrammeStream.AgHelpDataSet.Tables(0).Select("SessionManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Admission Session"))) & " " & _
                                                                                 " And ProgrammeManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Admission Programme"))) & " " & _
                                                                                 " And StreamManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Admission Stream"))) & " " & _
                                                                                 " ")
                    If DrTemp.Length > 0 Then
                        TxtSessionProgrammeStream.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing

                    Call ProcValidatingControl(TxtSessionProgrammeStream)
                End If

                If AgL.XNull(DtTemp.Rows(I)("Admission Session")).ToString.Trim <> "" _
                    And AgL.XNull(DtTemp.Rows(I)("Admission Programme")).ToString.Trim <> ""  Then

                    DrTemp = TxtSessionProgramme.AgHelpDataSet.Tables(0).Select("SessionManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Admission Session"))) & " " & _
                                                                                 " And ProgrammeManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Admission Programme"))) & " " & _
                                                                                 " ")
                    If DrTemp.Length > 0 Then
                        TxtSessionProgramme.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing

                    Call ProcValidatingControl(TxtSessionProgramme)
                End If


                If AgL.XNull(DtTemp.Rows(I)("Admission Session")).ToString.Trim <> "" _
                    And AgL.XNull(DtTemp.Rows(I)("Admission Programme")).ToString.Trim <> "" _
                    And AgL.XNull(DtTemp.Rows(I)("Admission Stream")).ToString.Trim <> "" _
                    And AgL.XNull(DtTemp.Rows(I)("Admission Semester")).ToString.Trim <> "" Then

                    DrTemp = TxtAdmissionSemester.AgHelpDataSet.Tables(0).Select("SessionManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Admission Session"))) & " " & _
                                                                                 " And ProgrammeManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Admission Programme"))) & " " & _
                                                                                 " And StreamManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Admission Stream"))) & " " & _
                                                                                 " And SemesterDesc = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Admission Semester"))) & " " & _
                                                                                 " ")
                    If DrTemp.Length > 0 Then
                        TxtAdmissionSemester.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing

                    Call ProcValidatingControl(TxtAdmissionSemester)
                End If

                If AgL.XNull(DtTemp.Rows(I)("Promotion Session")).ToString.Trim <> "" _
                    And AgL.XNull(DtTemp.Rows(I)("Promotion Programme")).ToString.Trim <> "" _
                    And AgL.XNull(DtTemp.Rows(I)("Promotion Stream")).ToString.Trim <> "" _
                    And AgL.XNull(DtTemp.Rows(I)("Promotion Semester")).ToString.Trim <> "" Then

                    DrTemp = TxtPromotionSemester.AgHelpDataSet.Tables(0).Select("SessionManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Promotion Session"))) & " " & _
                                                                                 " And ProgrammeManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Promotion Programme"))) & " " & _
                                                                                 " And StreamManualCode = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Promotion Stream"))) & " " & _
                                                                                 " And SemesterDesc = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Promotion Semester"))) & " " & _
                                                                                 " ")
                    If DrTemp.Length > 0 Then
                        TxtPromotionSemester.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing

                    Call ProcValidatingControl(TxtPromotionSemester)
                End If

                If AgL.XNull(DtTemp.Rows(I)("Library Member Type")).ToString.Trim <> "" Then
                    DrTemp = TxtLibraryMemberType.AgHelpDataSet.Tables(0).Select("Description = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Library Member Type"))) & " And IsDeleted = 'No' ")
                    If DrTemp.Length > 0 Then
                        TxtLibraryMemberType.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                    End If
                    DrTemp = Nothing
                End If

                ''===========< Finally >==============
                Topctrl1.FButtonClick(13)
                ''===========< ******* >==============
            End If
        Next
        If StrErrLog <> "" Then
            MsgBox(StrErrLog)
        Else
            MsgBox("Import Process Completed.", MsgBoxStyle.Information, Me.Text)
        End If


        FW.Close()

        mBlnImprtFromExcelFlag = False

        ''======< At Last Move To Browse Mode >=======
        Topctrl1.FButtonClick(14, True)
    End Sub

    Private Sub ProcValidatingControl(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing

        Select Case Sender.Name
            Case TxtStudent.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    TxtFamilyIncome.Text = ""
                    TxtReligion.AgSelectedValue = ""
                    TxtCategory.AgSelectedValue = ""

                    If TxtRegistrationDocId.Text.Trim <> "" Then
                        mQry = "SELECT Sd.Student, Vs.Religion , Vs.Category, Vs.FamilyIncome " & _
                                " FROM Sch_RegistrationStudentDetail Sd With (NoLock) " & _
                                " LEFT JOIN ViewSch_Student Vs  With (NoLock) ON Sd.Student = Vs.SubCode " & _
                                " WHERE Sd.DocId = " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & " "
                        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                        If DtTemp.Rows.Count > 0 Then
                            TxtStudent.AgSelectedValue = AgL.XNull(DtTemp.Rows(0)("Student"))
                            TxtFamilyIncome.Text = Format(AgL.VNull(DtTemp.Rows(0)("FamilyIncome")), "0.00")
                            TxtReligion.AgSelectedValue = AgL.XNull(DtTemp.Rows(0)("Religion"))
                            TxtCategory.AgSelectedValue = AgL.XNull(DtTemp.Rows(0)("Category"))
                        End If
                        If DtTemp IsNot Nothing Then DtTemp.Dispose()
                    End If
                Else
                    DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                    TxtFamilyIncome.Text = Format(AgL.VNull(DrTemp(0)("FamilyIncome")), "0.00")
                    TxtReligion.AgSelectedValue = AgL.XNull(DrTemp(0)("Religion"))
                    TxtCategory.AgSelectedValue = AgL.XNull(DrTemp(0)("Category"))
                End If
                DrTemp = Nothing

            Case TxtSessionProgrammeStream.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    LblSessionProgrammeStream.Tag = ""
                    LblSessionProgrammeStreamReq.Tag = ""
                    mFirstStreamCode = ""
                    mProgrammeCode = ""
                    TxtSessionProgramme.AgSelectedValue = ""
                Else
                    DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                    LblSessionProgrammeStream.Tag = AgL.XNull(DrTemp(0)("SessionProgramme"))
                    LblSessionProgrammeStreamReq.Tag = Format(AgL.XNull(DrTemp(0)("SessionStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                    mFirstStreamCode = AgL.XNull(DrTemp(0)("StreamCode"))
                    mProgrammeCode = AgL.XNull(DrTemp(0)("ProgrammeCode"))
                    TxtSessionProgramme.AgSelectedValue = AgL.XNull(DrTemp(0)("SessionProgramme"))

                    If mBlnImprtFromExcelFlag = False Then
                        If Not AgL.StrCmp(TxtIsDiplomaHolder.Text, "Yes") Then
                            TxtSessionProgramme.AgSelectedValue = AgL.XNull(DrTemp(0)("SessionProgramme"))
                        End If

                        If mLastSessionProgrammeStreamDesc <> TxtSessionProgrammeStream.Text Then
                            TxtAdmissionSemester.AgSelectedValue = ""
                            TxtPromotionSemester.AgSelectedValue = ""
                        End If
                    End If
                End If

            Case TxtSessionProgramme.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    If Not AgL.StrCmp(TxtIsDiplomaHolder.Text, "Yes") And LblSessionProgrammeStream.Tag.ToString.Trim <> "" Then
                        TxtSessionProgramme.AgSelectedValue = LblSessionProgrammeStream.Tag
                    Else
                        Sender.AgSelectedValue = ""
                    End If
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        '<Executable Code>
                    End If
                End If

            Case TxtAdmissionSemester.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    LblAdmissionSemester.Tag = ""
                    mFromSemesterSerialNo = 0
                    mFromSemesterStreamCode = ""
                Else
                    DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                    LblAdmissionSemester.Tag = AgL.XNull(DrTemp(0)("SessionProgrammeStreamCode"))
                    mFromSemesterSerialNo = AgL.VNull(DrTemp(0)("SemesterSerialNo"))
                    mFromSemesterStreamCode = AgL.XNull(DrTemp(0)("StreamCode"))
                End If

            Case TxtPromotionSemester.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    LblPromotionSemester.Tag = ""
                    mToSemesterSerialNo = 0
                    mToSemesterStreamCode = ""
                Else
                    DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                    LblPromotionSemester.Tag = AgL.XNull(DrTemp(0)("SessionProgrammeStreamCode"))
                    mToSemesterSerialNo = AgL.VNull(DrTemp(0)("SemesterSerialNo"))
                    mToSemesterStreamCode = AgL.XNull(DrTemp(0)("StreamCode"))
                End If
        End Select

        If DtTemp IsNot Nothing Then DtTemp.Dispose()
    End Sub

    Public Function GetFromFile(ByVal filePath As String) As Byte()

        If Not File.Exists(filePath) Then Return Nothing

        Dim fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)

        Dim br As New BinaryReader(fs)

        Dim fByte As Byte() = br.ReadBytes(CInt(fs.Length))

        br.Close() : fs.Close()

        Return fByte

    End Function

    Public Sub SaveToFile(ByVal filePath As String, ByVal bFile As Byte())
        Dim fs As New FileStream(filePath, FileMode.Create)

        Dim bw As New BinaryWriter(fs)

        bw.Write(bFile)

        bw.Flush() : bw.Close() : bw = Nothing

        fs.Close() : fs = Nothing

    End Sub

End Class
