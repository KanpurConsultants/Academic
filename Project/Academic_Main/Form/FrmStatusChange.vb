Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmStatusChange
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = "", mReverseFeeDueDocId$ = "", mFeeReceiveAdjustmentDocId$ = ""

    Dim mObjClsMain As New ClsMain(AgL, PLib)

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Dim mIsNewAdmissionPromotion As Boolean = False, mIsSubjectLocked As Boolean = False
    Dim mIsDuesChecked As Boolean = False, mBlnIsReverseFeeDue As Boolean = False, mBlnIsBothSemesterSame As Boolean = False

    Dim mAdmissionFeeDueDocId$ = "", mCurrentSemesterStartDate$ = "", mAdmissionDate$ = "", mLeavingDate$ = ""
    Dim mFirstStreamCode$ = "", mCurrentSemesterStreamCode$ = "", mProgrammeCode$ = "", mNewProgrammeCode$ = ""
    Dim mCurrentSemesterSerialNo As Integer = 0


    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1StreamYearSemester As Byte = 1
    Private Const Col1Fee As Byte = 2
    Private Const Col1Amount As Byte = 3

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2SemesterSubject As Byte = 1
    Private Const Col2Subject As Byte = 2
    Private Const Col2ManualCode As Byte = 3
    Private Const Col2PaperID As Byte = 4
    Private Const Col2MinCreditHours As Byte = 5
    Private Const Col2IsSubjectSelected As Byte = 6
    Private Const Col2IsElectiveSubject As Byte = 7
    Private Const Col2OtherSemesterSubject As Byte = 8

    Public WithEvents DGL3 As New AgControls.AgDataGrid
    Private Const Col3DueDate As Byte = 1
    Private Const Col3FeeDue1 As Byte = 2
    Private Const Col3TempFeeDue1 As Byte = 3
    Private Const Col3FeeCode As Byte = 4
    Private Const Col3DueAmount As Byte = 5
    Private Const Col3IsReversePostable As Byte = 6
    Private Const Col3Guid As Byte = 7

    Dim mBlnIsAutoApproved As Boolean = False, mBlnHaveReversePostPermission As Boolean = False
    Dim _FormType As eFormType

    Public Enum eFormType
        StatusChange
        StatusChangeAuthenticated
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
            .AddAgTextColumn(DGL1, "DGL1StreamYearSemester", 280, 50, "Semester", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1Fee", 420, 50, "Fee Head", True, True, False)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 100, 8, 2, False, "Amount", True, False, True)
        End With

        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False

        DGL1.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        LblFeeDetail.Visible = Academic_ProjLib.ClsMain.IsModuleActive_FeeModule
        ''==============================================================================
        ''================< Semester/Subject Data Grid >================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "Dgl2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "Dgl2StreamYearSemester", 230, 50, "Semester", True, True, False)
            .AddAgTextColumn(DGL2, "Dgl2SemesterSubject", 350, 73, "Subject", True, True, False)
            .AddAgTextColumn(DGL2, "Dgl2ManualCode", 80, 50, "Manual Code", True, True, False)
            .AddAgTextColumn(DGL2, "Dgl2PaperID", 60, 50, "Paper ID", True, True, False)
            .AddAgNumberColumn(DGL2, "Dgl2MinCreditHours", 50, 3, 2, False, "Credit Hrs.", True, True)
            .AddAgListColumn(DGL2, "Yes,No", "Dgl2IsSubjectSelected", 50, "1,0", "Yes/ No", True, False)
            .AddAgTextColumn(DGL2, "Dgl2IsElectiveSubject", 100, 1, "IsElectiveSubject", False, True, False)
            .AddAgTextColumn(DGL2, "Dgl2OtherSemesterSubject", 200, 1, "Subject Swap", False, True, False)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 40
        DGL2.AllowUserToAddRows = False

        ''==============================================================================
        ''================< Current Semester Fee Due Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL3, "DGL3SNo", 50, 5, "S.No.", True, True, False)
            .AddAgDateColumn(DGL3, "Dgl3DueDate", 100, "Due Date", True, True, False)
            .AddAgTextColumn(DGL3, "DGL3FeeDue1", 480, 30, "Fee Head", True, True, False)
            .AddAgTextColumn(DGL3, "DGL3TempFeeDue1", 300, 30, "TempFeeDue1", False, True, False)
            .AddAgTextColumn(DGL3, "DGL3Fee", 100, 10, "FeeCode", False, True, False)
            .AddAgNumberColumn(DGL3, "DGL3Amount", 100, 8, 3, False, "Amount", True, True, True)
            '.AddAgCheckBoxColumn(DGL3, "Is Reverse Postable", 100, "Is Reverse Postable", True, False, False, DataGridViewColumnSortMode.NotSortable)
            AgL.AddCheckColumn(DGL3, "Is Reverse Postable", 100, 1, "Is Reverse Postable", True, True, False)
            .AddAgTextColumn(DGL3, "DGL3Guid", 100, 8, "Guid", False, False, False)
        End With
        DGL3.ColumnHeadersHeight = 40
        DGL3.AllowUserToAddRows = False
        AgL.AddAgDataGrid(DGL3, Pnl3)
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
        Dim FrmObj As Form = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor
            If Topctrl1.Mode = "Browse" Then Exit Sub
            Select Case Sender.name
                'Case TxtStudent.Name
                '    If Academic_ProjLib.ClsMain.IsModuleActive_AcademicMain Then
                '        FrmObj = PObj.FOpen_LinkForm_Academic_Main(Academic_Objects.ClsConstant.MenuName_Main_StudentMaster, Academic_Objects.ClsConstant.MenuText_Main_StudentMaster, Me.MdiParent)
                '    Else
                '        If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                '            FrmObj = PObj.FOpen_LinkForm_Academic_Fee(Academic_Objects.ClsConstant.MenuName_Fee_StudentMaster, Academic_Objects.ClsConstant.MenuText_Fee_StudentMaster, Me.MdiParent)
                '        Else
                '            FrmObj = Nothing
                '        End If
                '    End If

                '    If FrmObj IsNot Nothing Then
                '        CType(FrmObj, FrmStudentMaster).RegistrationDocId = TxtRegistrationDocId.AgSelectedValue
                '    End If
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
            AgL.WinSetting(Me, 650, 950, 0, 0)

            mBlnHaveReversePostPermission = FunHaveControlPermission(GrpReversePost.Text)

            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGL3)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            Topctrl1.ChangeAgGridState(DGL3, False)
            If AgL.PubMoveRecApplicable Then FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr$ = ""

        If AgL.PubMoveRecApplicable Then
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Scd.StatusChangeDate", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            If _FormType = eFormType.StatusChange Then
                mCondStr += " And IsNull(Scd.ApprovedBy,'')='' "
            ElseIf _FormType = eFormType.StatusChangeAuthenticated Then
                mCondStr += " And IsNull(Scd.ApprovedBy,'')<>'' "
            End If

            mQry = "SELECT Scd.GUID AS SearchCode " & _
                    " FROM Sch_AdmissionStatusChangeDetail Scd " & _
                    " LEFT JOIN Sch_Admission A ON A.DocId = Scd.DocId " & mCondStr
            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
              " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ReverseFeeDue) & "" & _
              " Order By Description"
        TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select V1.DocId As Code, V1.StudentName As [Student Name], V1.AdmissionID, P.CurrentSemesterCode, V1.Student As StudentCode, " & _
                " V1.Status, V1.FromStreamYearSemester As FirstStreamYearSemester, V1.V_Date As AdmissionDate " & _
                " FROM ViewSch_Admission V1 " & _
                " LEFT JOIN (SELECT Ap.AdmissionDocId, Ap.FromStreamYearSemester AS CurrentSemesterCode FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) P ON V1.DocId = P.AdmissionDocId " & _
                " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By V1.StudentName "
        TxtAdmissionDocId.AgHelpDataSet(5) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT VSem.Code , VSem.StreamYearSemesterDesc AS Semester, VSem.SemesterStartDate , VYear.SessionProgrammeStreamCode,  " & _
                " VSem.SessionProgrammeCode, VSem.SemesterSerialNo, VSem.SessionStartDate, VSem.StreamCode, VSem.ProgrammeCode " & _
                " FROM ViewSch_StreamYearSemester VSem " & _
                " LEFT JOIN ViewSch_SessionProgrammeStreamYear VYear ON VSem.SessionProgrammeStreamYear = VYear.SessionProgrammeStreamYearCode " & _
                " Where " & AgL.PubSiteCondition("VSem.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By VYear.SessionProgrammeStreamCode, VSem.SemesterStartDate "
        TxtStreamYearSemester.AgHelpDataSet(7) = AgL.FillData(mQry, AgL.GCn)
        TxtNewStreamYearSemester.AgHelpDataSet(7) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Ss.Code, Vs.StreamYearSemesterDesc AS Semester, S.Description AS Subject, Ss.Subject AS SubjectCode, " & _
                " Ss.StreamYearSemester, Ss.ManualCode, Ss.PaperID, Ss.MinCreditHours, Ss.IsElectiveSubject " & _
                " FROM Sch_SemesterSubject Ss " & _
                " LEFT JOIN Sch_Subject S ON Ss.Subject = S.Code " & _
                " LEFT JOIN ViewSch_StreamYearSemester Vs ON Ss.StreamYearSemester = Vs.Code " & _
                " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY Vs.SemesterStartDate , Vs.StreamYearSemesterDesc, S.Description "
        DGL2.AgHelpDataSet(Col2SemesterSubject, 6, Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)
        DGL2.AgHelpDataSet(Col2OtherSemesterSubject, 6, Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.Code, S.Description AS Name " & _
                " FROM Sch_Subject S " & _
                " ORDER BY S.Description "
        DGL2.AgHelpDataSet(Col2Subject, , Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Vs.Code, Vs.StreamYearSemesterDesc AS Semester " & _
                " FROM ViewSch_StreamYearSemester Vs " & _
                " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY Vs.SemesterStartDate , Vs.StreamYearSemesterDesc "
        DGL1.AgHelpDataSet(Col1StreamYearSemester, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT F.Code, Sg.DispName [Fee Head], F.FeeNature, F.Refundable " & _
                " FROM Sch_Fee F " & _
                " LEFT JOIN SubGroup Sg ON Sg.SubCode = F.Code " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " And " & _
                " F.FeeNature  NOT IN ('" & Academic_ProjLib.ClsMain.FeeNature_LateFee & "', '" & Academic_ProjLib.ClsMain.FeeNature_Fine & "') " & _
                " ORDER BY F.FeeNature , Sg.Name "
        DGL1.AgHelpDataSet(Col1Fee, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Fd1.Code, SgF.Name AS [Fee Name], Fd.V_Date AS [Due Date], Fd1.Amount, Fd1.AdmissionDocId, Fd1.Fee AS FeeCode " & _
                " FROM Sch_FeeDue1 Fd1 " & _
                " LEFT JOIN Sch_FeeDue Fd ON Fd1.DocId = Fd.DocId " & _
                " LEFT JOIN SubGroup SgF ON Fd1.Fee = SgF.SubCode " & _
                " Where Fd.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " And " & _
                " " & AgL.PubSiteCondition("Fd.Site_Code", AgL.PubSiteCode) & " "
        DGL3.AgHelpDataSet(Col3FeeDue1, 3) = AgL.FillData(mQry, AgL.GCn)


        AgCL.IniAgHelpList(TxtStatus, PubAdmissionStatusStr)
        AgCL.IniAgHelpList(TxtNewStatus, PubAdmissionStatusStr)
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False


        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            'If mSearchCode <> "" Then
            '    If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


            '        AgL.ECmd = AgL.GCn.CreateCommand
            '        AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            '        AgL.ECmd.Transaction = AgL.ETrans
            '        mTrans = True

            '        mQry = "Update Sch_FeeDue1 " & _
            '                " SET Sch_FeeDue1.IsReversePosted = 0 " & _
            '                " FROM Sch_ReverseFeeDue1 " & _
            '                " WHERE Sch_ReverseFeeDue1.FeeDue1 = Sch_FeeDue1.Code " & _
            '                " AND Sch_ReverseFeeDue1.DocId = '" & mSearchCode & "' "
            '        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            '        AgL.Dman_ExecuteNonQry("Delete From Sch_FeeReverseDueLedgerM Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
            '        AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

            '        AgL.Dman_ExecuteNonQry("Delete From Sch_ReverseFeeDue1 Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
            '        AgL.Dman_ExecuteNonQry("Delete From Sch_ReverseFeeDue Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

            '        Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            '        AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            '        AgL.ETrans.Commit()
            '        mTrans = False

            '        If AgL.PubMoveRecApplicable Then
            '            FIniMaster(1)
            '            Topctrl_tbRef()
            '        Else
            '            AgL.PubSearchRow = ""
            '        End If
            '        MoveRec()
            '    End If
            'End If
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

        If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
            GrpReversePost.Enabled = mBlnHaveReversePostPermission
        End If

        If GrpReversePost.Enabled Then BtnFillDues.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr$ = ""
        Try
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Scd.StatusChangeDate", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            If _FormType = eFormType.StatusChange Then
                mCondStr += " And IsNull(Scd.ApprovedBy,'')='' "
            ElseIf _FormType = eFormType.StatusChangeAuthenticated Then
                mCondStr += " And IsNull(Scd.ApprovedBy,'')<>'' "
            End If

            AgL.PubFindQry = "SELECT Scd.GUID AS SearchCode, A.StudentName, A.RollNo, A.EnrollmentNo, " & AgL.ConvertDateField("Scd.StatusChangeDate") & " As [Status Change Date], " & _
                                " Scd.OldStatus As Status, Scd.NewStatus As [New Status], " & _
                                " CASE WHEN IsNull(Scd.IsStreamChange,0) <> 0 THEN 'Yes' ELSE 'No' END AS [IS Stream Change], " & _
                                " CASE WHEN IsNull(Scd.IsNewStatusAfterPromotion,0) <> 0 THEN 'Yes' ELSE 'No' END AS [IS New Status After Promotion],  " & _
                                " Sem.StreamYearSemesterDesc AS Semester, NewSem.StreamYearSemesterDesc AS [New Semester], " & _
                                " " & AgL.V_No_Field("Scd.FeeDueDocId") & " AS [Fee Due Voucher No], " & AgL.V_No_Field("Scd.ReverseFeeDueDocId") & " AS [Reverse Due Voucher No] " & _
                                " FROM dbo.Sch_AdmissionStatusChangeDetail Scd " & _
                                " LEFT JOIN ViewSch_Admission A ON A.DocId = Scd.DocId   " & _
                                " LEFT JOIN ViewSch_StreamYearSemester Sem ON Scd.StreamYearSemester = Sem.Code  " & _
                                " LEFT JOIN ViewSch_StreamYearSemester NewSem ON Scd.NewStreamYearSemester = NewSem.Code  " & mCondStr

            AgL.PubFindQryOrdBy = "[SearchCode]"


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

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, mSr As Integer = 0, bIntStatusChange_Sr As Integer = 0
        Dim mTrans As Boolean = False
        Dim bStrStatusChangeGuid$ = "", bNewStatus_FeeDueDocId$ = ""
        Dim bStrApprovedDate$ = ""

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            If mBlnIsAutoApproved Then bStrApprovedDate = AgL.GetDateTime(AgL.GCn)

            If mBlnIsReverseFeeDue = False Then
                mReverseFeeDueDocId = ""
            End If


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            If mBlnIsReverseFeeDue Then ProcSaveReverseFeeDue()

            If Topctrl1.Mode = "Add" Then
                '===============================================================================================================================================
                '==================< Change Status/Stream >=====================================================================================================
                '===============================================================================================================================================
                mQry = "Select IsNull(Max(Sr),0) Sr From Sch_AdmissionStatusChangeDetail With (NoLock) " & _
                        " Where " & _
                        " DocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " "
                bIntStatusChange_Sr = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) + 1
                bStrStatusChangeGuid = mSearchCode

                mQry = "INSERT INTO dbo.Sch_AdmissionStatusChangeDetail " & _
                        " (GUID, DocId, Sr, StatusChangeDate, OldStatus, NewStatus, IsStreamChange, IsNewStatusAfterPromotion, ReverseFeeDueDocId, StreamYearSemester, NewStreamYearSemester, PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES  ( " & _
                        " " & AgL.Chk_Text(bStrStatusChangeGuid) & " ," & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & bIntStatusChange_Sr & ", " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtStatus.Text) & ", " & AgL.Chk_Text(TxtNewStatus.Text) & ", " & _
                        " " & IIf(AgL.StrCmp(TxtIsStreamChange.Text, "Yes"), 1, 0) & ", " & IIf(AgL.StrCmp(TxtIsNewStatusAfterPromotion.Text, "Yes"), 1, 0) & ", " & _
                        " " & AgL.Chk_Text(mReverseFeeDueDocId) & ", " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & AgL.Chk_Text(TxtNewStreamYearSemester.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A' )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "UPDATE Sch_Admission " & _
                        " SET Status = " & AgL.Chk_Text(TxtNewStatus.Text) & " " & _
                        " WHERE DocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If mIsNewAdmissionPromotion And Not mBlnIsBothSemesterSame Then
                If Topctrl1.Mode = "Add" Then
                    mQry = "Update Sch_AdmissionPromotion " & _
                            " SET  " & _
                            " PromotionDate = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                            " ToStreamYearSemester = " & AgL.Chk_Text(TxtNewStreamYearSemester.AgSelectedValue) & ", " & _
                            " PromotionType = " & AgL.Chk_Text(PLib.FunGetPromotionType(TxtNewStatus.Text, TxtIsStreamChange.Text)) & ", " & _
                            " U_AE = 'E', " & _
                            " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                            " ModifiedBy = '" & AgL.PubUserName & "' " & _
                            " WHERE " & _
                            " AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " AND  " & _
                            " FromStreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " And " & _
                            " ToStreamYearSemester Is Null "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Select IsNull(Max(Sr),0) Sr From Sch_AdmissionPromotion With (NoLock) " & _
                            " Where " & _
                            " AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " "
                    mSr = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) + 1

                    mQry = "INSERT INTO Sch_AdmissionPromotion " & _
                            " (AdmissionDocId, Sr, FromStreamYearSemester, PromotionDate, ToStreamYearSemester, PromotionType, " & _
                            " PreparedBy, U_EntDt, U_AE ) " & _
                            " VALUES ( " & _
                            " " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & mSr & ", " & _
                            " " & AgL.Chk_Text(TxtNewStreamYearSemester.AgSelectedValue) & ", Null, Null, Null, " & _
                            " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A' ) "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    '===============================================================================================================================================

                    '===============================================================================================================================================
                    '==================< Update Current Semester >==================================================================================================
                    '===========================< Start >===========================================================================================================
                    '===============================================================================================================================================
                    If Not mObjClsMain.FunUpdateCurrentSemester(TxtAdmissionDocId.AgSelectedValue, AgL.GCn, AgL.ECmd) Then
                        Err.Raise(1, , "Error In Current Semester Updating!...")
                    End If
                    '===============================================================================================================================================
                    '==================< Update Current Semester >==================================================================================================
                    '===========================< End >=============================================================================================================
                    '===============================================================================================================================================


                    '===============================================================================================================================================
                    '==================< Sch_AdmissionFeeDetail >=====================================================================================================
                    '===============================================================================================================================================

                    If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                        mQry = "Delete From Sch_AdmissionFeeDetail Where DocId = '" & TxtAdmissionDocId.AgSelectedValue & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        With DGL1
                            mSr = 0
                            For I = 0 To .Rows.Count - 1
                                If .Item(Col1StreamYearSemester, I).Value <> "" Then
                                    mSr = mSr + 1

                                    mQry = "INSERT INTO Sch_AdmissionFeeDetail ( DocId, Sr, StreamYearSemester, Fee, Amount ) " & _
                                            " VALUES ( " & _
                                            " '" & TxtAdmissionDocId.AgSelectedValue & "', " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1StreamYearSemester, I)) & ", " & _
                                            " " & AgL.Chk_Text(.AgSelectedValue(Col1Fee, I)) & ", " & Val(.Item(Col1Amount, I).Value) & " )"
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                End If
                            Next I
                        End With
                    End If


                    '===============================================================================================================================================
                    '==================< Sch_AdmissionSubject >=====================================================================================================
                    '===============================================================================================================================================

                    mQry = "Delete From Sch_AdmissionSubject Where DocId = '" & TxtAdmissionDocId.AgSelectedValue & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    With DGL2
                        mSr = 0
                        For I = 0 To .Rows.Count - 1
                            If .Item(Col2SemesterSubject, I).Value <> "" And AgL.StrCmp(.Item(Col2IsSubjectSelected, I).Value, "Yes") Then
                                mSr = mSr + 1

                                mQry = "INSERT INTO Sch_AdmissionSubject ( DocId, Sr, SemesterSubject, OtherSemesterSubject) " & _
                                        " VALUES ( " & _
                                        " '" & TxtAdmissionDocId.AgSelectedValue & "', " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col2SemesterSubject, I)) & ", " & AgL.Chk_Text(.AgSelectedValue(Col2OtherSemesterSubject, I)) & " )"
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            End If
                        Next I
                    End With
                End If
                '===============================================================================================================================================
                '==================< Sch_FeeDue >=====================================================================================================
                '===============================================================================================================================================
                If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                    If mBlnIsAutoApproved Then
                        If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then
                            bStrStatusChangeGuid = mSearchCode
                        End If

                        bNewStatus_FeeDueDocId = FunSaveFeeDueDetail(bStrStatusChangeGuid)
                    End If
                End If
                '===============================================================================================================================================
            End If

            If mBlnIsReverseFeeDue = True Then
                If mBlnIsAutoApproved Then Call ProcFeeReceiveAdjustment(mFeeReceiveAdjustmentDocId, bNewStatus_FeeDueDocId, TxtV_Date.Text, TxtSite_Code.AgSelectedValue, AgL.PubDivCode)
            End If
            '===============================================================================================================================================

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            If mBlnIsAutoApproved Then
                Call ProcApproveVoucher(AgL.PubUserName, bStrApprovedDate, True)
            End If

            Call AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False
            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If
            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mReverseFeeDueDocId
                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                MoveRec()
            End If
        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim DrTemp1 As DataRow() = Nothing
        Dim MastPos As Long
        Dim I As Integer = 0
        Dim bNewStatus_FeeDueDocId$ = ""
        Dim mTransFlag As Boolean = False, bEditFlag As Boolean = False

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
                mQry = "SELECT Scd.*, A.V_Date As AdmissionDate, A.LeavingDate, A.Student As StudentCode, A.AdmissionID, " & _
                        " Af.FeeDueDocId As AdmissionFeeDueDocId, Sps.SessionProgramme, " & _
                        " Sps.SessionStartDate, Sps.Stream AS StreamCode, Sps.ProgrammeCode " & _
                        " FROM Sch_AdmissionStatusChangeDetail Scd " & _
                        " LEFT JOIN Sch_Admission A ON A.DocId = Scd.DocId " & _
                        " Left Join Sch_AdmissionFeeDue Af On A.DocId = Af.AdmissionDocId " & _
                        " Left Join ViewSch_SessionProgrammeStream Sps On A.SessionProgrammeStream = Sps.Code " & _
                        " Where Scd.Guid = '" & mSearchCode & "' "
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtAdmissionDocId.AgSelectedValue = AgL.XNull(.Rows(0)("DocId"))
                        LblAdmissionDocId.Tag = AgL.XNull(.Rows(0)("StudentCode"))

                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("StatusChangeDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                        mFirstStreamCode = AgL.XNull(.Rows(0)("StreamCode"))
                        mProgrammeCode = AgL.XNull(.Rows(0)("ProgrammeCode"))
                        mAdmissionFeeDueDocId = AgL.XNull(.Rows(0)("AdmissionFeeDueDocId"))
                        mReverseFeeDueDocId = AgL.XNull(.Rows(0)("ReverseFeeDueDocId"))
                        mBlnIsReverseFeeDue = IIf(AgL.XNull(.Rows(0)("ReverseFeeDueDocId")).ToString.Trim = "", False, True)
                        mAdmissionDate = Format(AgL.XNull(.Rows(0)("AdmissionDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        mLeavingDate = Format(AgL.XNull(.Rows(0)("LeavingDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                        TxtAdmissionID.Text = AgL.XNull(.Rows(0)("AdmissionID"))
                        TxtStatus.Text = AgL.XNull(.Rows(0)("OldStatus"))
                        TxtNewStatus.Text = AgL.XNull(.Rows(0)("NewStatus"))

                        TxtIsNewStatusAfterPromotion.Text = IIf(AgL.VNull(.Rows(0)("IsNewStatusAfterPromotion")), "Yes", "No")
                        TxtIsStreamChange.Text = IIf(AgL.VNull(.Rows(0)("IsStreamChange")), "Yes", "No")
                        bNewStatus_FeeDueDocId = AgL.XNull(.Rows(0)("FeeDueDocId"))

                        TxtStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        DrTemp1 = TxtStreamYearSemester.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(AgL.XNull(.Rows(0)("StreamYearSemester"))) & "")
                        mCurrentSemesterStreamCode = AgL.XNull(DrTemp1(0)("StreamCode"))
                        mCurrentSemesterStartDate = Format(AgL.XNull(DrTemp1(0)("SessionStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        mCurrentSemesterSerialNo = AgL.VNull(DrTemp1(0)("SemesterSerialNo"))
                        DrTemp1 = Nothing

                        TxtSemesterLastTransactionDate.Text = funGetCurrentSemLastTransactionDate()

                        mIsNewAdmissionPromotion = IIf(AgL.XNull(.Rows(0)("NewStreamYearSemester")).ToString.Trim <> "", True, False)

                        TxtNewStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("NewStreamYearSemester"))
                        DrTemp1 = TxtStreamYearSemester.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(AgL.XNull(.Rows(0)("NewStreamYearSemester"))) & "")
                        If DrTemp1.Length > 0 Then
                            LblNewStreamYearSemester.Tag = AgL.XNull(DrTemp1(0)("SessionProgrammeStreamCode"))
                            mNewProgrammeCode = AgL.XNull(DrTemp1(0)("ProgrammeCode"))
                        End If
                        DrTemp1 = Nothing
                        mBlnIsBothSemesterSame = AgL.StrCmp(TxtStreamYearSemester.Text, TxtNewStreamYearSemester.Text)

                        mBlnIsAutoApproved = AgL.VNull(.Rows(0)("IsAutoApproved"))

                        TxtApproved.Text = AgL.XNull(.Rows(0)("ApprovedBy"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "SELECT Rfd.*, Vt.NCat " & _
                        " FROM Sch_ReverseFeeDue Rfd " & _
                        " Left Join Voucher_Type Vt On Rfd.V_Type = Vt.V_Type " & _
                        " Where Rfd.DocId = '" & mReverseFeeDueDocId & "' "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = AgL.XNull(.Rows(0)("DocId"))

                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(+2, "0"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCat"))
                        LblV_Date.Tag = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtTotalAmount.Text = Format(AgL.VNull(.Rows(0)("TotalAmount")), "0.00")

                        mQry = "Select Rfd1.*, Fd.V_Date AS DueDate, Fd1.Fee AS FeeCode, Fd1.IsReversePostable, Fd1.IsReversePosted, vFr1.ReceiveDate " & _
                                " From Sch_ReverseFeeDue1 Rfd1 " & _
                                " LEFT JOIN Sch_FeeDue1 Fd1 ON Fd1.Code = Rfd1.FeeDue1 " & _
                                " LEFT JOIN Sch_FeeDue Fd ON Fd.DocId = Fd1.DocId " & _
                                " Left Join (SELECT Fr1.FeeDue1, Sum(Fr1.Amount) AS Amount, Max(Fr.V_Date) AS ReceiveDate " & _
                                " FROM Sch_FeeReceive1 Fr1 " & _
                                " LEFT JOIN Sch_FeeReceive  Fr ON Fr1.DocId = Fr.DocId  " & _
                                " GROUP BY Fr1.FeeDue1  " & _
                                " ) vFr1 ON Fd1.Code = vFr1.FeeDue1 " & _
                                " Where Rfd1.DocId='" & AgL.XNull(.Rows(0)("DocId")) & "' " & _
                                " Order By Rfd1.RowId "
                        DTbl = AgL.FillData(mQry, AgL.GCn).Tables(0)

                        DGL1.RowCount = 1
                        DGL1.Rows.Clear()
                        If DTbl.Rows.Count > 0 Then
                            For I = 0 To DTbl.Rows.Count - 1
                                DGL3.Rows.Add()
                                DGL3.Item(Col_SNo, I).Value = DGL3.Rows.Count
                                DGL3.AgSelectedValue(Col3FeeDue1, I) = AgL.XNull(DTbl.Rows(I)("FeeDue1"))
                                DGL3.Item(Col3TempFeeDue1, I).Value = AgL.XNull(DTbl.Rows(I)("FeeDue1"))
                                DGL3.Item(Col3DueDate, I).Value = Format(AgL.XNull(DTbl.Rows(I)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                                DGL3.Item(Col3FeeCode, I).Value = AgL.XNull(DTbl.Rows(I)("FeeCode"))

                                DGL3.Item(Col3DueAmount, I).Value = Format(AgL.VNull(DTbl.Rows(I)("Amount")), "0.00")
                                DGL3.Item(Col3Guid, I).Value = AgL.XNull(DTbl.Rows(I)("GUID"))
                                DGL3.Item(Col3IsReversePostable, I).Value = IIf(AgL.VNull(DTbl.Rows(I)("IsReversePostable")), AgLibrary.ClsConstant.StrCheckedValue, AgLibrary.ClsConstant.StrUnCheckedValue)

                                If BtnFillDues.Tag.ToString.Trim = "" Then
                                    BtnFillDues.Tag = Format(AgL.XNull(DTbl.Rows(I)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                                Else
                                    If CDate(Format(AgL.XNull(DTbl.Rows(I)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)) > CDate(TxtV_Date.Text) Then
                                        BtnFillDues.Tag = Format(AgL.XNull(DTbl.Rows(I)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                                    End If
                                End If

                                If AgL.XNull(DTbl.Rows(I)("ReceiveDate")).ToString.Trim <> "" Then
                                    If CDate(Format(AgL.XNull(DTbl.Rows(I)("ReceiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)) > CDate(TxtV_Date.Text) Then
                                        BtnFillDues.Tag = Format(AgL.XNull(DTbl.Rows(I)("ReceiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                                    End If
                                End If

                            Next I
                        End If
                    End If
                End With


                If mIsNewAdmissionPromotion Then
                    mQry = "Select Af.* " & _
                            " From Sch_AdmissionFeeDetail Af " & _
                            " Where Af.DocId='" & TxtAdmissionDocId.AgSelectedValue & "'"
                    DsTemp = AgL.FillData(mQry, AgL.GCn)

                    With DsTemp.Tables(0)
                        DGL1.RowCount = 1 : DGL1.Rows.Clear()
                        If .Rows.Count > 0 Then
                            For I = 0 To .Rows.Count - 1
                                DGL1.Rows.Add()
                                DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                                DGL1.AgSelectedValue(Col1StreamYearSemester, I) = AgL.XNull(.Rows(I)("StreamYearSemester"))
                                DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                                DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")

                                If AgL.StrCmp(DGL1.Item(Col1StreamYearSemester, I).Value.ToString, TxtNewStreamYearSemester.Text) Then
                                    TxtNewSemesterFee.Text = Val(TxtNewSemesterFee.Text) + Val(DGL1.Item(Col1Amount, I).Value)
                                End If
                            Next I
                        End If
                        TxtNewSemesterFee.Text = Format(Val(TxtNewSemesterFee.Text), "0.00")
                    End With


                    mQry = "Select Ads.SemesterSubject, VSub.Subject AS SubjectCode,  VSub.StreamYearSemester, VSub.ManualCode,  " & _
                            " VSub.PaperID, VSub.MinCreditHours, VSub.IsElectiveSubject, Convert(Bit,1) As IsSubjectSelected, Ads.Sr, Ads.OtherSemesterSubject    " & _
                            " From Sch_AdmissionSubject Ads   " & _
                            " Left Join ViewSch_SemesterSubject VSub On Ads.SemesterSubject = VSub.Code   " & _
                            " Where Ads.DocId = '" & TxtAdmissionDocId.AgSelectedValue & "' " & _
                            " ORDER BY Ads.Sr "

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
                                DGL2.Item(Col2MinCreditHours, I).Value = Format(AgL.VNull(.Rows(I)("ManualCode")), "0.00")
                                DGL2.Item(Col2IsSubjectSelected, I).Value = IIf(AgL.VNull(.Rows(I)("IsSubjectSelected")), "Yes", "No")
                                DGL2.Item(Col2IsElectiveSubject, I).Value = IIf(AgL.VNull(.Rows(I)("IsElectiveSubject")), 1, 0)
                                DGL2.AgSelectedValue(Col2OtherSemesterSubject, I) = AgL.XNull(.Rows(I)("OtherSemesterSubject"))


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
                End If
                FillColour()
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If mLeavingDate.Trim <> "" Then mTransFlag = True

                If mTransFlag = False Then
                    If _FormType = eFormType.StatusChange Then
                        bEditFlag = FunHaveControlPermission(GrpReversePost.Text)
                    End If
                    If Not bEditFlag Then mTransFlag = True
                End If


                If mTransFlag Then
                    Topctrl1.tEdit = False
                    Topctrl1.tDel = False
                Else
                    If _FormType = eFormType.StatusChange Then
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
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = "" : mReverseFeeDueDocId = "" : mFeeReceiveAdjustmentDocId = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
        DGL3.RowCount = 1 : DGL3.Rows.Clear()

        Call BlankFooterGrid()

        mIsNewAdmissionPromotion = False : mBlnIsAutoApproved = False
        mIsDuesChecked = False : mBlnIsReverseFeeDue = False : mIsSubjectLocked = False : mBlnIsBothSemesterSame = False

        TxtIsStreamChange.Text = "No" : TxtIsNewStatusAfterPromotion.Text = "No"
        TxtStatus.Text = Academic_ProjLib.ClsMain.AdmissionStatus_Regular
        mAdmissionFeeDueDocId = "" : mCurrentSemesterStartDate = "" : mProgrammeCode = "" : mNewProgrammeCode = ""

        mFirstStreamCode = "" : mCurrentSemesterStreamCode = "" : mLeavingDate = "" : mAdmissionDate = ""
        mCurrentSemesterSerialNo = 0

        BtnFillDues.Tag = ""
        Tc1.SelectedTab = Tp3
        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub BlankFooterGrid()
        '<Executable Code>
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls      
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        TxtStatus.Enabled = False
        TxtStreamYearSemester.Enabled = False
        TxtTotalAmount.Enabled = False
        TxtNewSemesterFee.Enabled = False

        BtnFillDetail.Enabled = Enb


        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
            TxtAdmissionDocId.Enabled = False
            TxtV_Date.Enabled = False

            BtnFillDetail.Enabled = False

            TxtNewStatus.Enabled = False
            TxtIsStreamChange.Enabled = False
            TxtIsNewStatusAfterPromotion.Enabled = False
            TxtNewStreamYearSemester.Enabled = False
            TxtNewSemesterFee.Enabled = False

            DGL1.ReadOnly = True
            DGL2.ReadOnly = True
            DGL3.ReadOnly = True
        End If

        GrpReversePost.Enabled = False

        If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
            If _FormType = eFormType.StatusChangeAuthenticated Then
                GroupBox1.Visible = True : BtnApproved.Enabled = False
                Topctrl1.tAdd = False : Topctrl1.tEdit = False

            ElseIf _FormType = eFormType.StatusChange Then
                GroupBox1.Visible = True
            End If
        Else
            GroupBox1.Visible = False
        End If
    End Sub

    Private Sub DGL3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL3.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL3.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL3.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL3.CurrentCell.ColumnIndex
                'Case Col1StreamYearSemester
                'Call IniItemHelp(False, Dgl3.AgSelectedValue(Col1BarCode, mRowIndex))
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL3_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL3.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            If DGL3.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL3.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL3
                Select Case .CurrentCell.ColumnIndex
                    'Case <ColumnIndex>
                    '<Executable Code>
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl3_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL3.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            Select Case DGL3.CurrentCell.ColumnIndex
                Case Col3IsReversePostable
                    Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgl1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown, DGL2.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub
    End Sub

    Private Sub DGL3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL3.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            Select Case DGL3.CurrentCell.ColumnIndex
                Case Col3IsReversePostable
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(DGL3, Col3IsReversePostable)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL3_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL3.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            If DGL3.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL3.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL3.CurrentCell.ColumnIndex
                Case Col3IsReversePostable
                    Call AgL.ProcSetCheckColumnCellValue(DGL3, Col3IsReversePostable)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub


    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                '<Executable Code>
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl3_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL3.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            If DGL3.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL3.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL3.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                '<Executable Code>
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded, DGL2.RowsAdded, DGL3.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved, DGL2.RowsRemoved, DGL3.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, Col_SNo)

        Call Calculation()
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
        TxtV_Type.Enter, TxtStreamYearSemester.Enter, TxtAdmissionID.Enter, TxtAdmissionDocId.Enter, _
        TxtIsStreamChange.Enter, TxtNewStatus.Enter, TxtV_Date.Enter, TxtNewStreamYearSemester.Enter
        Try
            Select Case sender.name
                Case TxtNewStreamYearSemester.Name
                    If (AgL.StrCmp(TxtNewStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) And Not AgL.StrCmp(TxtIsStreamChange.Text, "Yes")) Or _
                        (Not AgL.StrCmp(TxtNewStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) And AgL.StrCmp(TxtIsStreamChange.Text, "Yes")) Then
                        sender.AgRowFilter = " 1=2 "
                    Else
                        'sender.AgRowFilter = " SemesterStartDate " & IIf(AgL.StrCmp(TxtIsNewStatusAfterPromotion.Text, "Yes"), ">=", ">") & " " & AgL.ConvertDate(mCurrentSemesterStartDate) & " And " & _
                        '                        " " & IIf(AgL.StrCmp(TxtIsStreamChange.Text, "Yes"), " StreamCode <> " & AgL.Chk_Text(mFirstStreamCode) & " ", " StreamCode = " & AgL.Chk_Text(mCurrentSemesterStreamCode) & " ") & " And " & _
                        '                        " SemesterSerialNo " & IIf(AgL.StrCmp(TxtIsStreamChange.Text, "Yes"), " = " & mCurrentSemesterSerialNo + IIf(AgL.StrCmp(TxtIsNewStatusAfterPromotion.Text, "Yes"), 0, 1) & " ", " < " & mCurrentSemesterSerialNo & " ") & " "

                        sender.AgRowFilter = " SemesterStartDate " & IIf(AgL.StrCmp(TxtIsNewStatusAfterPromotion.Text, "Yes"), ">=", ">") & " " & AgL.ConvertDate(mCurrentSemesterStartDate) & " And " & _
                                                " " & IIf(AgL.StrCmp(TxtIsStreamChange.Text, "Yes"), " StreamCode <> " & AgL.Chk_Text(mFirstStreamCode) & " ", " StreamCode = " & AgL.Chk_Text(mCurrentSemesterStreamCode) & " ") & " And " & _
                                                " SemesterSerialNo " & IIf(AgL.StrCmp(TxtIsStreamChange.Text, "Yes"), " = ", " <= ") & mCurrentSemesterSerialNo + IIf(AgL.StrCmp(TxtIsNewStatusAfterPromotion.Text, "Yes"), 0, 1) & " "

                    End If

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtDocId.Validating, TxtV_Date.Validating, _
        TxtAdmissionDocId.Validating, TxtAdmissionID.Validating, _
        TxtIsStreamChange.Validating, TxtNewStatus.Validating, TxtNewStreamYearSemester.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing, DrTemp1 As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtNewStatus.Name

                Case TxtAdmissionDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtStreamYearSemester.AgSelectedValue = ""
                        TxtAdmissionID.Text = ""
                        LblAdmissionDocId.Tag = ""
                        TxtStatus.Text = ""
                        mCurrentSemesterStreamCode = ""
                        mCurrentSemesterStartDate = ""
                        mCurrentSemesterSerialNo = 0
                        mFirstStreamCode = ""
                        mAdmissionDate = ""
                        TxtSemesterLastTransactionDate.Text = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtStreamYearSemester.AgSelectedValue = AgL.XNull(DrTemp(0)("CurrentSemesterCode"))
                            TxtAdmissionID.Text = AgL.XNull(DrTemp(0)("AdmissionID"))
                            LblAdmissionDocId.Tag = AgL.XNull(DrTemp(0)("StudentCode"))
                            TxtStatus.Text = AgL.XNull(DrTemp(0)("Status"))
                            mAdmissionDate = Format(AgL.XNull(DrTemp(0)("AdmissionDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                            DrTemp1 = TxtStreamYearSemester.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(AgL.XNull(DrTemp(0)("CurrentSemesterCode"))) & "")
                            mCurrentSemesterStreamCode = AgL.XNull(DrTemp1(0)("StreamCode"))
                            mCurrentSemesterStartDate = Format(AgL.XNull(DrTemp1(0)("SessionStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            mCurrentSemesterSerialNo = AgL.VNull(DrTemp1(0)("SemesterSerialNo"))
                            DrTemp1 = Nothing

                            DrTemp1 = TxtStreamYearSemester.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(AgL.XNull(DrTemp(0)("FirstStreamYearSemester"))) & "")
                            mFirstStreamCode = AgL.XNull(DrTemp1(0)("StreamCode"))
                            DrTemp1 = Nothing

                            TxtSemesterLastTransactionDate.Text = funGetCurrentSemLastTransactionDate()
                        End If
                    End If

                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
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

                Case TxtNewStreamYearSemester.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblNewStreamYearSemester.Tag = ""
                        mNewProgrammeCode = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblNewStreamYearSemester.Tag = AgL.XNull(.Item("SessionProgrammeStreamCode", .CurrentCell.RowIndex).Value)
                                mNewProgrammeCode = AgL.XNull(.Item("ProgrammeCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtIsStreamChange.Name
                    If TxtIsStreamChange.Text.Trim = "" Then TxtIsStreamChange.Text = "No"

            End Select

            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mReverseFeeDueDocId = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mReverseFeeDueDocId
                TxtV_No.Text = Val(AgL.DeCodeDocID(mReverseFeeDueDocId, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mReverseFeeDueDocId, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
            DrTemp = Nothing
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Call BlankFooterGrid()

        TxtTotalAmount.Text = ""
        TxtNewSemesterFee.Text = ""

        With DGL3
            For I = 0 To .Rows.Count - 1
                If .Item(Col3IsReversePostable, I).Value Is Nothing Then .Item(Col3IsReversePostable, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                If .Item(Col3IsReversePostable, I).Value.ToString.Trim = "" Then .Item(Col3IsReversePostable, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                If .Item(Col3IsReversePostable, I).Value.ToString.Trim = AgLibrary.ClsConstant.StrCheckedValue Then
                    TxtTotalAmount.Text = Val(TxtTotalAmount.Text) + Val(.Item(Col3DueAmount, I).Value)
                End If
            Next
        End With


        If mIsNewAdmissionPromotion = True Then
            With DGL1
                For I = 0 To DGL1.Rows.Count - 1
                    If .Item(Col1StreamYearSemester, I).Value.ToString.Trim <> "" Then
                        If AgL.StrCmp(DGL1.Item(Col1StreamYearSemester, I).Value.ToString, TxtNewStreamYearSemester.Text) Then
                            TxtNewSemesterFee.Text = Val(TxtNewSemesterFee.Text) + Val(.Item(Col1Amount, I).Value)
                        End If
                    End If
                Next
            End With
        End If

        TxtTotalAmount.Text = Format(Val(TxtTotalAmount.Text), "0.00")
        TxtNewSemesterFee.Text = Format(Val(TxtNewSemesterFee.Text), "0.00")
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = ""
        Dim bIsNewSemesterFeeExists As Boolean = False
        Try
            mBlnIsAutoApproved = FunHaveControlPermission(GroupBox1.Text)

            Call Calculation()

            Tc1.SelectedTab = Tp1
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtStreamYearSemester, "Admission Semester") Then Exit Function
            If AgL.RequiredField(TxtStatus, "Status") Then Exit Function
            If AgL.RequiredField(TxtIsStreamChange, "Is Branch Change?") Then Exit Function

            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                If Not Validate_NewStatus() Then Exit Function
            Else
                If Val(TxtTotalAmount.Text) = 0 And mBlnIsReverseFeeDue And mBlnHaveReversePostPermission Then
                    MsgBox("First Fill Dues Before Proceed!...")
                    Tc1.SelectedTab = Tp3
                    If mTmV_Type.Trim = "" Then
                        If TxtV_Type.Enabled Then TxtV_Type.Focus() Else BtnFillDues.Focus()
                    Else
                        BtnFillDues.Focus()
                    End If
                    Exit Function
                End If

            End If

            If Not mBlnIsBothSemesterSame Then
                If mIsNewAdmissionPromotion Then
                    If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                        Tc1.SelectedTab = Tp1

                        If DGL1.Rows.Count = 0 Then MsgBox("Please Fill The Fee Detail!...") : BtnFillDetail.Focus()

                        AgCL.AgBlankNothingCells(DGL1)
                        If AgCL.AgIsBlankGrid(DGL1, Col1StreamYearSemester) Then Exit Function
                        If AgCL.AgIsDuplicate(DGL1, "" & Col1StreamYearSemester & "," & Col1Fee & "") Then Exit Function

                        If TxtNewStatus.Text.Trim <> "" Then
                            If Not AgL.StrCmp(TxtNewStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) Then

                                With DGL1
                                    For I = 0 To DGL1.Rows.Count - 1
                                        If .Item(Col1StreamYearSemester, I).Value.ToString.Trim <> "" Then
                                            If AgL.StrCmp(DGL1.Item(Col1StreamYearSemester, I).Value.ToString, TxtNewStreamYearSemester.Text) Then
                                                If bIsNewSemesterFeeExists = False Then bIsNewSemesterFeeExists = True : Exit For
                                            End If
                                        End If
                                    Next
                                End With

                                If Not bIsNewSemesterFeeExists Then MsgBox("Please Define Fee For Semester : : -" & vbCrLf & " """ & TxtNewStreamYearSemester.Text & """!...", MsgBoxStyle.Critical, "Validation Check") : Tc1.SelectedTab = Tp3 : BtnFillDetail.Focus() : Exit Function

                                If MsgBox("Have You Check Fee Deatil For Semester : -" & vbCrLf & " """ & TxtNewStreamYearSemester.Text & """?...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Function
                            End If
                        End If
                    End If


                    Tc1.SelectedTab = Tp2
                    If DGL2.Rows.Count = 0 Then MsgBox("Please Fill The Subject Detail!...") : BtnFillDetail.Focus()
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
                End If
            End If


            If Topctrl1.Mode = "Add" Then
                mReverseFeeDueDocId = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mReverseFeeDueDocId, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mReverseFeeDueDocId, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mReverseFeeDueDocId <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mReverseFeeDueDocId & "")
                    TxtDocId.Text = mReverseFeeDueDocId
                End If

                mSearchCode = AgL.GetGUID(AgL.GcnRead).ToString()
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Function FunHaveControlPermission(ByVal StrGroupText As String) As Boolean
        Dim bStrModule$ = ""
        Dim bBlnRetrunFlag As Boolean = False

        If Academic_ProjLib.ClsMain.IsModuleActive_AcademicMain Then
            bStrModule = Academic_Objects.ClsConstant.Module_Academic_Main
        ElseIf Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
            bStrModule = Academic_Objects.ClsConstant.Module_Academic_Fee
        Else
            bStrModule = ""
        End If

        bBlnRetrunFlag = AgL.FunHaveControlPermission(bStrModule, Me.Text, AgL.PubUserName, StrGroupText)

        Return bBlnRetrunFlag
    End Function

    Private Function Validate_NewStatus() As Boolean
        Try
            Dim bIsRegularStatus As Boolean = False
            Dim bStrTempNewStatusDate As String = ""

            If AgL.StrCmp(TxtIsStreamChange.Text, "Yes") Then
                If Not AgL.StrCmp(TxtStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) Then
                    MsgBox("Stream Can Only Change When Current Status Is : " & Academic_ProjLib.ClsMain.AdmissionStatus_Regular & "!...")
                    TxtIsStreamChange.Focus() : Exit Function
                End If

                If Not AgL.StrCmp(TxtNewStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) Then
                    MsgBox("Stream Can Only Change When New Status Is : " & Academic_ProjLib.ClsMain.AdmissionStatus_Regular & "!...")
                    TxtNewStatus.Focus() : Exit Function
                End If
            Else
                If AgL.StrCmp(TxtNewStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) Then bIsRegularStatus = True
            End If

            If bIsRegularStatus = True Then
                If AgL.StrCmp(TxtStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Regular) Then
                    MsgBox("Invalid New Status!...")
                    TxtNewStatus.Focus() : Exit Function
                End If

                If TxtNewStreamYearSemester.Text.Trim <> "" Then
                    MsgBox("New Semester Is Not Required!...")
                    TxtNewStreamYearSemester.Focus() : Exit Function
                End If
            ElseIf TxtNewStatus.Text.Trim <> "" Then
                If AgL.RequiredField(TxtNewStreamYearSemester, "New Semester") Then Exit Function

                mIsNewAdmissionPromotion = True
            End If

            If TxtNewStreamYearSemester.Text.Trim <> "" Then
                mBlnIsBothSemesterSame = AgL.StrCmp(TxtStreamYearSemester.Text, TxtNewStreamYearSemester.Text)

                If Not (AgL.StrCmp(TxtStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Ex) Or _
                    AgL.StrCmp(TxtNewStatus.Text, Academic_ProjLib.ClsMain.AdmissionStatus_Ex)) And mBlnIsBothSemesterSame Then

                    MsgBox("New Semester Can't Be Same As Previous Semsester!...") : TxtNewStreamYearSemester.Focus() : Exit Function
                End If
            End If

            If mIsNewAdmissionPromotion Then
                If AgL.RequiredField(TxtIsNewStatusAfterPromotion, "Is Student Promoted?") Then Exit Function

                If AgL.StrCmp(TxtIsNewStatusAfterPromotion.Text, "Yes") Then
                    If mBlnIsBothSemesterSame = True Then
                        mBlnIsReverseFeeDue = False
                        BtnFillDues.Enabled = False
                        DGL3.RowCount = 1 : DGL3.Rows.Clear()
                    Else
                        mBlnIsReverseFeeDue = True
                        BtnFillDues.Enabled = True
                    End If

                    If Val(TxtTotalAmount.Text) = 0 And mBlnIsReverseFeeDue And mBlnHaveReversePostPermission Then
                        MsgBox("First Fill Dues Before Proceed!...")
                        Tc1.SelectedTab = Tp3
                        If mTmV_Type.Trim = "" Then
                            If TxtV_Type.Enabled Then TxtV_Type.Focus() Else BtnFillDues.Focus()
                        Else
                            BtnFillDues.Focus()
                        End If
                        Exit Function
                    End If
                Else
                    mBlnIsReverseFeeDue = False
                    BtnFillDues.Enabled = False
                End If
            End If

            If TxtNewStatus.Text.Trim <> "" Then
                If AgL.RequiredField(TxtV_Date, "New Status Date") Then Exit Function
                If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate, "New Status Date") Then Exit Function

                If CDate(TxtV_Date.Text) < CDate(mAdmissionDate) Then
                    MsgBox("New Status Date Can't Be Less Than From Admission Date : """ & mCurrentSemesterStartDate & """!...")
                    TxtV_Date.Focus() : Exit Function
                ElseIf CDate(TxtV_Date.Text) < CDate(mCurrentSemesterStartDate) Then
                    MsgBox("New Status Date Can't Be Less Than From """ & mCurrentSemesterStartDate & """!...")
                    TxtV_Date.Focus() : Exit Function
                End If

                bStrTempNewStatusDate = funGetCurrentSemLastTransactionDate()

                If bStrTempNewStatusDate.Trim <> "" Then
                    If CDate(TxtV_Date.Text) < CDate(bStrTempNewStatusDate) Then
                        MsgBox("New Status Date Can't Be Less Than From """ & bStrTempNewStatusDate & """!...")
                        TxtV_Date.Focus() : Exit Function
                    End If
                End If

            End If

            Validate_NewStatus = True
        Catch ex As Exception
            Validate_NewStatus = False
            mIsNewAdmissionPromotion = False
        End Try
    End Function

    Private Function funGetCurrentSemLastTransactionDate() As String
        Dim bStrTempNewStatusDate As String
        mQry = "SELECT Max(V.V_Date) AS V_Date FROM " & _
                                " ( " & _
                                " SELECT Max(V_Date) AS V_Date FROM ViewSch_FeeDue Fd With (NoLock) WHERE AdmissionDocId = '" & TxtAdmissionDocId.AgSelectedValue & "' AND StreamYearSemester = '" & TxtStreamYearSemester.AgSelectedValue & "' " & _
                                " UNION All " & _
                                " SELECT Max(V_Date) AS V_Date FROM ViewSch_FeeReceive With (NoLock) WHERE AdmissionDocId = '" & TxtAdmissionDocId.AgSelectedValue & "' AND CurrentStreamYearSemesterCode = '" & TxtStreamYearSemester.AgSelectedValue & "' " & _
                                " UNION All " & _
                                " SELECT Max(V_Date) AS V_Date FROM ViewSch_FeeRefund With (NoLock) WHERE AdmissionDocId = '" & TxtAdmissionDocId.AgSelectedValue & "' AND CurrentStreamYearSemesterCode = '" & TxtStreamYearSemester.AgSelectedValue & "' " & _
                                " ) AS V "
        bStrTempNewStatusDate = Format(AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar), AgLibrary.ClsConstant.DateFormat_ShortDate)

        Return bStrTempNewStatusDate
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            TxtV_Type.Enabled = True
        End If

        If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
            GrpReversePost.Enabled = mBlnHaveReversePostPermission
        End If

        TxtAdmissionDocId.Focus()
    End Sub

    Private Sub ProcFillSubject()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim bCondStr$ = "", bNewSemesterStartDate$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL2.RowCount = 1 : DGL2.Rows.Clear()
            'mLastFromStreamYearSemesterCode_Subject = TxtFromStreamYearSemester.AgSelectedValue
            'mLastToStreamYearSemesterCode_Subject = TxtToStreamYearSemester.AgSelectedValue

            Dim bFromSemesterStartDate$ = ""

            Tc1.SelectedTab = Tp2
            mQry = "SELECT Sem.SemesterStartDate " & _
                    " FROM ViewSch_StreamYearSemester Sem " & _
                    " WHERE Sem.Code = " & AgL.Chk_Text(TxtNewStreamYearSemester.AgSelectedValue) & ""
            bNewSemesterStartDate = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar

            If bNewSemesterStartDate.Trim = "" Then
                mQry = "SELECT Ss.Code As SemesterSubject, Ss.Subject AS SubjectCode, " & _
                        " Ss.ManualCode, Ss.PaperID, Ss.IsElectiveSubject, " & _
                        " Convert(Bit,Case When Ss.IsElectiveSubject = 0 Then 1 Else 0 End) As IsSubjectSelected, " & _
                        " Ss.RowId As Sr, Null as OtherSemesterSubject, Sem.SemesterStartDate " & _
                        " FROM Sch_SemesterSubject Ss " & _
                        " LEFT JOIN Sch_Subject S ON Ss.Subject = S.Code " & _
                        " LEFT JOIN ViewSch_StreamYearSemester Sem ON Ss.StreamYearSemester = Sem.Code " & _
                        " Where 1=1 " & bCondStr & " " & _
                        " ORDER BY Sem.SemesterStartDate , Ss.RowId, Sem.StreamYearSemesterDesc, S.Description "
            Else
                bCondStr = " And VSub.SessionProgrammeStreamCode = " & AgL.Chk_Text(LblNewStreamYearSemester.Tag.ToString) & " "

                mQry = "Select Ads.SemesterSubject, VSub.Subject AS SubjectCode,  VSub.ManualCode,  " & _
                        " VSub.PaperID, VSub.IsElectiveSubject, Convert(Bit,1) As IsSubjectSelected, " & _
                        " Ads.Sr, Ads.OtherSemesterSubject, VSub.SemesterStartDate " & _
                        " From Sch_AdmissionSubject Ads   " & _
                        " Left Join ViewSch_SemesterSubject VSub On Ads.SemesterSubject = VSub.Code   " & _
                        " Where Ads.DocId = '" & TxtAdmissionDocId.AgSelectedValue & "' And " & _
                        " VSub.SemesterStartDate " & IIf(AgL.StrCmp(TxtIsNewStatusAfterPromotion.Text, "Yes"), "<=", "<") & " " & AgL.ConvertDate(bNewSemesterStartDate) & " " & _
                        " UNION ALL " & _
                        " Select VSub.Code AS SemesterSubject, VSub.Subject AS SubjectCode,  VSub.ManualCode,  " & _
                        " VSub.PaperID, VSub.IsElectiveSubject, Convert(Bit,Case When IsNull(VSub.IsElectiveSubject,0) = 0 Then 1 Else 0 End) As IsSubjectSelected, " & _
                        " 999999 As Sr, Null as OtherSemesterSubject, VSub.SemesterStartDate " & _
                        " FROM ViewSch_SemesterSubject VSub " & _
                        " Where 1=1 " & bCondStr & " And VSub.SemesterStartDate >= " & AgL.ConvertDate(bNewSemesterStartDate) & " " & _
                        " ORDER BY Sr, SemesterStartDate  "
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
                        DGL2.Item(Col2MinCreditHours, I).Value = Format(AgL.VNull(.Rows(I)("ManualCode")), "0.00")
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
        Dim bCondStr$ = "", bNewSemesterStartDate$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            'mLastFromStreamYearSemesterCode_Fee = TxtFromStreamYearSemester.AgSelectedValue
            'mLastToStreamYearSemesterCode_Fee = TxtToStreamYearSemester.AgSelectedValue

            Dim bFromSemesterStartDate$ = ""
            'mQry = "SELECT Sem.SemesterStartDate " & _
            '        " FROM ViewSch_StreamYearSemester Sem " & _
            '        " WHERE Sem.Code = " & AgL.Chk_Text(TxtFromStreamYearSemester.AgSelectedValue) & ""
            'bFromSemesterStartDate = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar

            Tc1.SelectedTab = Tp1
            mQry = "SELECT Sem.SemesterStartDate " & _
                    " FROM ViewSch_StreamYearSemester Sem " & _
                    " WHERE Sem.Code = " & AgL.Chk_Text(TxtNewStreamYearSemester.AgSelectedValue) & ""
            bNewSemesterStartDate = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar


            bCondStr = " And Sem.SessionProgrammeStreamCode = " & AgL.Chk_Text(LblNewStreamYearSemester.Tag.ToString) & " "

            mQry = "SELECT Afd.StreamYearSemester, Afd.Fee, Afd.Amount, " & _
                    " Sem.SemesterStartDate,  Sem.StreamYearSemesterDesc " & _
                    " FROM Sch_AdmissionFeeDetail Afd " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON Afd.StreamYearSemester = Sem.Code " & _
                    " WHERE Afd.DocId = '" & TxtAdmissionDocId.AgSelectedValue & "' AND " & _
                    " Sem.SemesterStartDate " & IIf(AgL.StrCmp(TxtIsNewStatusAfterPromotion.Text, "Yes"), "<=", "<") & " " & AgL.ConvertDate(bNewSemesterStartDate) & " "
            mQry += " UNION ALL " & _
                    " SELECT Sf.StreamYearSemester, Sf.Fee, Sf.Amount, " & _
                    " Sem.SemesterStartDate,  Sem.StreamYearSemesterDesc " & _
                    " FROM Sch_StreamYearSemesterFee Sf " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON Sf.StreamYearSemester = Sem.Code " & _
                    " Where 1=1 " & bCondStr & " And Sem.SemesterStartDate >= " & AgL.ConvertDate(bNewSemesterStartDate) & " " & _
                    " ORDER BY SemesterStartDate , StreamYearSemesterDesc "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp

                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1StreamYearSemester, I) = AgL.XNull(.Rows(I)("StreamYearSemester"))
                        DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                    Next I
                End If
            End With

            Call Calculation()
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

                If (Topctrl1.Mode = "Add" And bV_Date.Trim <> "" And bSite_Code.Trim <> "") Or bIsNewStatus_FeeDue Then
                    bQry = "Select Vt.V_Type From Voucher_Type Vt With (NoLock) " & _
                            " Where Vt.NCat = '" & Academic_ProjLib.ClsMain.NCat_FeeDue & "' "
                    bV_Type = AgL.XNull(AgL.Dman_Execute(bQry, bConnRead).ExecuteScalar)

                    bSearchCode = AgL.GetDocId(bV_Type, CStr(bV_No), CDate(bV_Date), bConnRead, bDiv_Code, bSite_Code)
                    If bIsNewStatus_FeeDue Then
                        bFeeDueDocId = bSearchCode
                    Else
                        mAdmissionFeeDueDocId = bSearchCode
                    End If

                Else
                    If bIsNewStatus_FeeDue Then
                        bSearchCode = bFeeDueDocId
                    Else
                        bSearchCode = mAdmissionFeeDueDocId
                    End If

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

    Private Sub BtnFillDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillDetail.Click
        Dim bFlag As Boolean = False
        Try
            Me.Cursor = Cursors.WaitCursor
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then
                bFlag = True
                Exit Sub
            End If
            If AgL.RequiredField(TxtIsNewStatusAfterPromotion, "Is New Status After Promotion?") Then Exit Sub
            If AgL.RequiredField(TxtNewStatus, "New Status") Then Exit Sub

            If Not Validate_NewStatus() Then Exit Sub

            If mIsNewAdmissionPromotion Then
                TxtNewStatus.Enabled = False
                TxtNewStreamYearSemester.Enabled = False
                TxtV_Date.Enabled = False
                TxtIsStreamChange.Enabled = False
                TxtIsNewStatusAfterPromotion.Enabled = False
                BtnFillDetail.Enabled = False

                If Not mBlnIsBothSemesterSame Then
                    If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                        Call ProcFillFee()
                    End If

                    Call ProcFillSubject()

                    Call FillColour()
                End If
            Else
                TxtNewStatus.Enabled = True
                TxtNewStreamYearSemester.Enabled = True
                TxtV_Date.Enabled = True
                TxtIsStreamChange.Enabled = True
                TxtIsNewStatusAfterPromotion.Enabled = True
                BtnFillDetail.Enabled = True
            End If



        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If bFlag = True Then
                TxtNewStreamYearSemester.AgSelectedValue = ""
                LblNewStreamYearSemester.Tag = "" : mNewProgrammeCode = ""
                TxtNewStatus.Text = ""
                'TxtNewStatusDate.Text = ""
            End If
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnFillDues_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillDues.Click
        Dim bDtTemp As DataTable = Nothing
        Dim bIntI As Integer
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL3.RowCount = 1 : DGL3.Rows.Clear()

            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Sub
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Sub
            If AgL.RequiredField(TxtAdmissionDocId, "Student") Then Exit Sub

            mIsDuesChecked = True

            mQry = "SELECT Fd1.Code As FeeDue1Code, Fd1.Fee AS FeeCode, Fd1.Amount As DueAmount, Fd.V_Date As DueDate, vFr1.ReceiveDate, Fd1.IsReversePostable   " & _
                    " FROM Sch_FeeDue1 Fd1 " & _
                    " LEFT JOIN Sch_FeeDue Fd ON Fd.DocId = Fd1.DocId " & _
                    " Left Join (SELECT Fr1.FeeDue1, Sum(Fr1.Amount) AS Amount, Max(Fr.V_Date) AS ReceiveDate " & _
                    " FROM Sch_FeeReceive1 Fr1 " & _
                    " LEFT JOIN Sch_FeeReceive  Fr ON Fr1.DocId = Fr.DocId  " & _
                    " GROUP BY Fr1.FeeDue1  " & _
                    " ) vFr1 ON Fd1.Code = vFr1.FeeDue1 " & _
                    " WHERE IsNull(Fd1.IsReversePosted,0) = 0 " & _
                    " AND Fd1.AdmissionDocId = '" & TxtAdmissionDocId.AgSelectedValue & "' " & _
                    " AND Fd.StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " " & _
                    " Order By Fd.V_Date "
            bDtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)


            With bDtTemp
                If .Rows.Count > 0 Then
                    DGL3.RowCount = 1 : DGL3.Rows.Clear()
                    TxtAdmissionDocId.Enabled = False

                    For bIntI = 0 To .Rows.Count - 1
                        DGL3.Rows.Add()
                        DGL3.Item(Col_SNo, bIntI).Value = DGL3.Rows.Count
                        DGL3.AgSelectedValue(Col3FeeDue1, bIntI) = AgL.XNull(.Rows(bIntI)("FeeDue1Code"))
                        DGL3.Item(Col3TempFeeDue1, bIntI).Value = AgL.XNull(.Rows(bIntI)("FeeDue1Code"))
                        DGL3.Item(Col3DueDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        DGL3.Item(Col3FeeCode, bIntI).Value = AgL.XNull(.Rows(bIntI)("FeeCode"))
                        DGL3.Item(Col3DueAmount, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("DueAmount")), "0.00")
                        DGL3.Item(Col3IsReversePostable, bIntI).Value = IIf(AgL.VNull(.Rows(bIntI)("IsReversePostable")), AgLibrary.ClsConstant.StrCheckedValue, AgLibrary.ClsConstant.StrUnCheckedValue)

                        If BtnFillDues.Tag.ToString.Trim = "" Then
                            BtnFillDues.Tag = Format(AgL.XNull(.Rows(bIntI)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        Else
                            If CDate(Format(AgL.XNull(.Rows(bIntI)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)) > CDate(TxtV_Date.Text) Then
                                BtnFillDues.Tag = Format(AgL.XNull(.Rows(bIntI)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            End If
                        End If

                        If AgL.XNull(.Rows(bIntI)("ReceiveDate")).ToString.Trim <> "" Then
                            If CDate(Format(AgL.XNull(.Rows(bIntI)("ReceiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)) > CDate(TxtV_Date.Text) Then
                                BtnFillDues.Tag = Format(AgL.XNull(.Rows(bIntI)("ReceiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            End If
                        End If
                    Next

                    DGL3.CurrentCell = DGL3(Col3IsReversePostable, 0) : DGL3.Focus()
                Else
                    MsgBox("No Fee Due Records Exists For Reverse Posting!...")
                    TxtAdmissionDocId.Enabled = True
                End If
            End With

            Call Calculation()
        Catch ex As Exception
            mIsDuesChecked = False
            MsgBox(ex.Message)
        Finally
            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
        End Try
    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer, bIntJ As Integer
        Dim mNarr As String = "", mCommonNarr$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(mReverseFeeDueDocId, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        Dim bDtTemp As DataTable = Nothing


        I = 0
        ReDim Preserve LedgAry(I)

        mQry = "SELECT Fd1.Fee as FeeCode, Convert(Numeric(18,2),IsNull(Sum(Rfd1.Amount),0)) AS Amount, Max(Sg.Name) as FeeHead " & _
                " FROM Sch_ReverseFeeDue1 Rfd1 WITH (NoLock) " & _
                " LEFT JOIN Sch_FeeDue1 Fd1 WITH (NoLock) ON Fd1.Code = Rfd1.FeeDue1  " & _
                " LEFT JOIN SubGroup Sg WITH (NoLock) ON Fd1.Fee = Sg.SubCode " & _
                " WHERE Rfd1.DocId = '" & mReverseFeeDueDocId & "'  " & _
                " GROUP BY Fd1.Fee "
        bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

        With bDtTemp
            If .Rows.Count > 0 Then
                mNarr = "Being Reverse Fee Due Of Rs. " & Format(Val(TxtTotalAmount.Text), "0.00") & "."
                If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)


                LedgAry(I).SubCode = LblAdmissionDocId.Tag
                LedgAry(I).ContraSub = .Rows(bIntJ)("FeeCode")
                LedgAry(I).AmtDr = 0
                LedgAry(I).AmtCr = Val(TxtTotalAmount.Text)
                LedgAry(I).Narration = mNarr

                For bIntJ = 0 To .Rows.Count - 1
                    I = UBound(LedgAry) + 1
                    ReDim Preserve LedgAry(I)

                    mNarr = "Being " & .Rows(bIntJ)("FeeHead") & " Of Rs. " & Format(AgL.VNull(.Rows(bIntJ)("Amount")), "0.00") & " Reverse Posted."
                    If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

                    LedgAry(I).SubCode = .Rows(bIntJ)("FeeCode")
                    LedgAry(I).ContraSub = LblAdmissionDocId.Tag
                    LedgAry(I).AmtDr = AgL.VNull(.Rows(bIntJ)("Amount"))
                    LedgAry(I).AmtCr = 0
                    LedgAry(I).Narration = mNarr
                Next
            End If
        End With

        mCommonNarr = TxtRemark.Text
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mReverseFeeDueDocId, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

        If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
    End Function

    Private Sub ProcFeeReceiveAdjustment(ByRef bFeeReceiveAdjustmentDocId As String, ByVal bNewStatus_FeeDueDocId As String, ByVal bV_Date As String, ByVal bSite_Code As String, ByVal bDiv_Code As String)
        Dim bDtTemp1 As DataTable = Nothing
        Dim bDblReceiveAmount As Double = 0, bDblAdjustedAmount As Double = 0
        Dim bIntI As Integer

        Dim bV_Type$ = "", bV_Prefix$ = "", bV_No As Long = 0, bSearchCode$ = "", bFeeReceive1Code$ = ""
        Dim bDblTotalLineAmount As Double = 0, bDblTotalLineNetAmount As Double = 0, bDblSubTotal1 As Double = 0, bDblSubTotal2 As Double = 0, bDblTotalNetAmount As Double = 0, bDblAdvanceCarriedForward As Double = 0, bDblTotalFeeReceiveAdjusted As Double = 0
        Dim bIsManageFee As Boolean = False

        mQry = "SELECT Fd1.AdmissionDocId, Fd1.Code AS FeeDue1Code, Fd1.Fee, Fd1.Amount AS DueAmount, Convert(FLOAT,0.00) AS AdjustableAmount " & _
                " FROM Sch_FeeDue1 Fd1 WITH (NoLock) " & _
                " WHERE Fd1.DocId = '" & bNewStatus_FeeDueDocId & "' " & _
                " ORDER BY Fd1.RowId "
        bDtTemp1 = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

        mQry = "SELECT IsNull(Sum(Fd.ReceiveAmount),0)  AS ReceiveAmount " & _
                " FROM Sch_ReverseFeeDue1 Rfd1 WITH (NoLock) " & _
                " LEFT JOIN ViewSch_FeeDue Fd WITH (NoLock) ON Fd.FeeDue1Code = Rfd1.FeeDue1 " & _
                " WHERE Rfd1.DocId  ='" & mReverseFeeDueDocId & "' " & _
                " And Fd.IsReversePosted <> 0 "
        bDblReceiveAmount = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar

        For bIntI = 0 To bDtTemp1.Rows.Count - 1
            If AgL.VNull(bDtTemp1.Rows(bIntI)("DueAmount")) > 0 Then
                If bDblReceiveAmount > bDblAdjustedAmount Then
                    If AgL.VNull(bDtTemp1.Rows(bIntI)("DueAmount")) <= (bDblReceiveAmount - bDblAdjustedAmount) Then
                        bDtTemp1.Rows(bIntI)("AdjustableAmount") = AgL.VNull(bDtTemp1.Rows(bIntI)("DueAmount"))
                        bDblAdjustedAmount += AgL.VNull(bDtTemp1.Rows(bIntI)("DueAmount"))
                        bDblTotalLineAmount = bDblAdjustedAmount
                    Else
                        bDtTemp1.Rows(bIntI)("AdjustableAmount") = bDblReceiveAmount - bDblAdjustedAmount
                        bDblAdjustedAmount += (bDblReceiveAmount - bDblAdjustedAmount)
                        bIsManageFee = True
                        bDblTotalLineAmount = bDblAdjustedAmount
                        Exit For
                    End If
                Else
                    Exit For
                End If
            End If
        Next

        bDblTotalLineNetAmount = bDblTotalLineAmount
        bDblSubTotal1 = bDblTotalLineNetAmount
        bDblTotalFeeReceiveAdjusted = bDblReceiveAmount
        bDblSubTotal2 = bDblSubTotal1 - bDblTotalFeeReceiveAdjusted
        bDblTotalNetAmount = bDblSubTotal2
        bDblAdvanceCarriedForward = bDblSubTotal2


        If (Topctrl1.Mode = "Add" Or bFeeReceiveAdjustmentDocId.Trim = "") And (bV_Date.Trim <> "" And bSite_Code.Trim <> "") Then
            mQry = "Select Vt.V_Type From Voucher_Type Vt With (NoLock) " & _
                    " Where Vt.NCat = '" & Academic_ProjLib.ClsMain.NCat_FeeReceiveAdjustment & "' "
            bV_Type = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar)

            bSearchCode = AgL.GetDocId(bV_Type, CStr(bV_No), CDate(bV_Date), AgL.GcnRead, bDiv_Code, bSite_Code)
            bFeeReceiveAdjustmentDocId = bSearchCode
        End If

        If bSearchCode.Trim = "" Then Err.Raise(1, , "Error in Fee Receive Adjustment Search Code Generation!...")

        bV_No = Val(AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        bV_Prefix = AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

        mQry = "INSERT INTO dbo.Sch_FeeReceive ( DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, " & _
                " TotalLineAmount, TotalLineDiscount, TotalLineNetAmount, Advance, SubTotal1, AdjustmentAmount, " & _
                " SubTotal2, DiscountPer, DiscountAmount, TotalNetAmount, IsManageFee, ReceiveAmount, " & _
                " AdvanceCarriedForward, AdmissionDocId, Remark, TotalAdvanceAdjusted, IsAdjustableReceipt, TotalFeeReceiveAdjusted, " & _
                " PreparedBy, U_EntDt, U_AE) " & _
                " VALUES ( " & _
                " '" & bSearchCode & "', '" & bDiv_Code & "', " & AgL.Chk_Text(bSite_Code) & ", " & _
                " " & AgL.ConvertDate(bV_Date) & ", " & AgL.Chk_Text(bV_Type) & ", " & AgL.Chk_Text(bV_Prefix) & ", " & bV_No & ", " & _
                " " & bDblTotalLineAmount & ", 0, " & bDblTotalLineNetAmount & ", 0, " & _
                " " & bDblSubTotal1 & ", 0, " & bDblSubTotal2 & ", " & 0 & ", " & _
                " " & 0 & ", " & bDblTotalNetAmount & ", " & IIf(bIsManageFee, 1, 0) & ", 0, " & bDblAdvanceCarriedForward & ", " & _
                " " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", Null, 0, 0, " & bDblTotalFeeReceiveAdjusted & ", " & _
                " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"

        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        For bIntI = 0 To bDtTemp1.Rows.Count - 1
            If AgL.XNull(bDtTemp1.Rows(bIntI)("FeeDue1Code")).ToString.Trim <> "" And AgL.VNull(bDtTemp1.Rows(bIntI)("AdjustableAmount")) > 0 Then
                bFeeReceive1Code = AgL.GetMaxId("Sch_FeeReceive1", "Code", AgL.GcnRead, bDiv_Code, bSite_Code, 8, True, True)

                mQry = "INSERT INTO Sch_FeeReceive1 ( " & _
                        " Code, DocId, FeeDue1, Amount, Discount, NetAmount	) " & _
                        " VALUES ( " & _
                        " '" & bFeeReceive1Code & "', '" & bSearchCode & "', " & AgL.Chk_Text(bDtTemp1.Rows(bIntI)("FeeDue1Code")) & ", " & _
                        " " & AgL.VNull(bDtTemp1.Rows(bIntI)("AdjustableAmount")) & ", 0, " & AgL.VNull(bDtTemp1.Rows(bIntI)("AdjustableAmount")) & " )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If
        Next bIntI

        mQry = "UPDATE Sch_ReverseFeeDue SET FeeReceiveAdjustmentDocId = " & AgL.Chk_Text(bFeeReceiveAdjustmentDocId) & " WHERE DocId = '" & mReverseFeeDueDocId & "'"
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        Call AgL.UpdateVoucherCounter(bSearchCode, CDate(bV_Date), AgL.GCn, AgL.ECmd, bDiv_Code, bSite_Code)
        Call AgL.LogTableEntry(bSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub FillColour()
        Dim I As Integer = 0
        Try
            For I = 0 To DGL1.Rows.Count - 1
                If DGL1.Item(Col1StreamYearSemester, I).Value.ToString.Trim <> "" Then
                    If AgL.StrCmp(DGL1.Item(Col1StreamYearSemester, I).Value.ToString, TxtNewStreamYearSemester.Text) Then
                        DGL1.CurrentCell = DGL1.Item(Col1Amount, I)
                        DGL1.CurrentCell.Style.BackColor = Color.Aqua
                    End If
                End If
            Next

            For I = 0 To DGL2.Rows.Count - 1
                If DGL2.Item(Col2SemesterSubject, I).Value.ToString.Trim <> "" Then
                    If AgL.StrCmp(DGL2.Item(Col2SemesterSubject, I).Value.ToString, TxtNewStreamYearSemester.Text) Then
                        DGL2.CurrentCell = DGL2.Item(Col2IsSubjectSelected, I)
                        DGL2.CurrentCell.Style.BackColor = Color.Aqua
                    End If
                End If
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub BtnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnApproved.Click
        Dim mTrans As Boolean = False
        Dim mApprovedDate$ = ""

        Select Case sender.name
            Case BtnApproved.Name
                Try
                    If Topctrl1.Mode = "Browse" Then
                        If mReverseFeeDueDocId.Trim <> "" And Val(TxtTotalAmount.Text) = 0 Then
                            MsgBox("Please First Define Reverse Fee Due Detail!...")
                            Exit Sub
                        End If

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
        Dim bNewStatus_FeeDueDocId$ = ""

        mQry = "Update Sch_AdmissionStatusChangeDetail Set ApprovedBy='" & StrApprovedBy & "', ApprovedDate=" & AgL.Chk_Text(StrApprovedDate) & ", IsAutoApproved = " & IIf(BlnIsAutoApproved, 1, 0) & " Where GuId='" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        If BlnIsAutoApproved = False Then
            bNewStatus_FeeDueDocId = FunSaveFeeDueDetail(mSearchCode)

            Call ProcFeeReceiveAdjustment(mFeeReceiveAdjustmentDocId, bNewStatus_FeeDueDocId, TxtV_Date.Text, TxtSite_Code.AgSelectedValue, AgL.PubDivCode)
        End If

        Call AgL.LogTableEntry(mSearchCode, Me.Text, AgLibrary.ClsConstant.EntryMode_Varified, AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , TxtV_Date.Text, , , , TxtSite_Code.AgSelectedValue, AgL.PubDivCode)
    End Sub

    Private Sub ProcSaveReverseFeeDue()
        Dim I As Integer = 0
        Dim bStrReverseFeeDue1Guid$ = ""
        Dim bBlanSaveFlag As Boolean = False

        If mBlnIsReverseFeeDue Then
            bBlanSaveFlag = IIf(Val(TxtTotalAmount.Text) = 0, True, False)

            If Val(TxtTotalAmount.Text) <> 0 Or bBlanSaveFlag Then
                If Topctrl1.Mode = "Add" Then
                    mQry = "INSERT INTO dbo.Sch_ReverseFeeDue (DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, " & _
                            " AdmissionDocId, StreamYearSemester, TotalAmount, Remark, " & _
                            " PreparedBy, U_EntDt, U_AE) " & _
                            " VALUES ('" & mReverseFeeDueDocId & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                            " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text.ToString) & ", " & Val(TxtV_No.Text) & ", " & _
                            " " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                            " " & Val(TxtTotalAmount.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                            " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A' )"
                Else
                    mQry = "Update dbo.Sch_ReverseFeeDue " & _
                            " SET  " & _
                            " 	V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                            " 	AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                            " 	StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                            " 	TotalAmount = " & Val(TxtTotalAmount.Text) & ", " & _
                            " 	Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                            " 	U_AE = 'E', " & _
                            " 	Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                            " 	ModifiedBy = '" & AgL.PubUserName & "' " & _
                            " WHERE DocId = '" & mReverseFeeDueDocId & "' "
                End If
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                If GrpReversePost.Enabled Then
                    With DGL3
                        For I = 0 To .Rows.Count - 1
                            If .Item(Col3Guid, I).Value = "" Then
                                If .Item(Col3FeeDue1, I).Value <> "" _
                                    And .Item(Col3IsReversePostable, I).Value.ToString.Trim = AgLibrary.ClsConstant.StrCheckedValue _
                                    And Val(.Item(Col3DueAmount, I).Value) > 0 Then

                                    bStrReverseFeeDue1Guid = AgL.GetGUID(AgL.GcnRead).ToString

                                    mQry = "INSERT INTO dbo.Sch_ReverseFeeDue1 (" & _
                                            " Guid, DocId, FeeDue1, Amount) " & _
                                            " VALUES (" & _
                                            " " & AgL.Chk_Text(bStrReverseFeeDue1Guid) & ", " & AgL.Chk_Text(mReverseFeeDueDocId) & ", " & _
                                            " " & AgL.Chk_Text(.AgSelectedValue(Col3FeeDue1, I)) & ", " & Val(.Item(Col3DueAmount, I).Value) & ")"
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                                    mQry = "UPDATE Sch_FeeDue1 SET IsReversePostable = 1, IsReversePosted = 1 WHERE Code = " & AgL.Chk_Text(.AgSelectedValue(Col3FeeDue1, I)) & " "
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                                End If
                            Else
                                If .Item(Col3FeeDue1, I).Value <> "" _
                                    And .Item(Col3IsReversePostable, I).Value.ToString.Trim = AgLibrary.ClsConstant.StrCheckedValue _
                                    And Val(.Item(Col3DueAmount, I).Value) > 0 Then

                                    mQry = "Update dbo.Sch_ReverseFeeDue1 " & _
                                            " SET " & _
                                            " 	FeeDue1 = " & AgL.Chk_Text(.AgSelectedValue(Col3FeeDue1, I)) & ", " & _
                                            " 	Amount = " & Val(.Item(Col3DueAmount, I).Value) & " " & _
                                            " WHERE Guid = " & AgL.Chk_Text(.Item(Col3Guid, I).Value) & " "
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                                    mQry = "UPDATE Sch_FeeDue1 SET IsReversePostable = 1, IsReversePosted = 1 WHERE Code = " & AgL.Chk_Text(.AgSelectedValue(Col3FeeDue1, I)) & " "
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                Else
                                    mQry = "Delete From Sch_ReverseFeeDue1 Where Guid = '" & .Item(Col3Guid, I).Value & "'"
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                                    mQry = "UPDATE Sch_FeeDue1 SET IsReversePostable = 0, IsReversePosted = 0 WHERE Code = " & AgL.Chk_Text(.Item(Col3TempFeeDue1, I).Value) & " "
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                End If
                            End If
                        Next I
                    End With

                    AgL.Dman_ExecuteNonQry("Delete From Sch_ReverseFeeDueLedgerM Where DocId='" & mReverseFeeDueDocId & "'", AgL.GCn, AgL.ECmd)

                    Call AccountPosting()

                    mQry = "INSERT INTO Sch_ReverseFeeDueLedgerM ( DocId, LedgerMDocId) VALUES ( " & _
                            " '" & mReverseFeeDueDocId & "', '" & mReverseFeeDueDocId & "' )"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If

                Call AgL.UpdateVoucherCounter(mReverseFeeDueDocId, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                Call AgL.LogTableEntry(mReverseFeeDueDocId, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
            End If
        End If
    End Sub

    Private Function FunSaveFeeDueDetail(ByVal bStrStatusChangeGuid As String) As String
        Dim bNewStatus_FeeDueObj As New Academic_ProjLib.ClsMain.Struct_FeeDue, bNewStatus_FeeDue1Obj() As Academic_ProjLib.ClsMain.Struct_FeeDue1 = Nothing
        Dim bIntStatusChange_Sr As Integer = 0
        Dim bNewStatus_FeeDueDocId$ = ""

        mQry = "Select Sr " & _
                " From Sch_AdmissionStatusChangeDetail With (NoLock) " & _
                " Where Guid = " & AgL.Chk_Text(bStrStatusChangeGuid) & " "
        bIntStatusChange_Sr = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar)

        '===============================================================================================================================================
        '============================< Sch_FeeDue >=====================================================================================================
        '===============================================================================================================================================
        If Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
            If TxtNewStatus.Text.Trim <> "" Then
                bNewStatus_FeeDueObj.StreamYearSemesterDesc = TxtNewStreamYearSemester.Text
                bNewStatus_FeeDueObj.V_Date = TxtV_Date.Text
                Call ProcCreateFeeDueStructure(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, TxtAdmissionDocId.AgSelectedValue, TxtNewStreamYearSemester.AgSelectedValue, bNewStatus_FeeDueObj, bNewStatus_FeeDue1Obj, bNewStatus_FeeDueDocId, True)

                Call PLib.ProcSaveFeeDueDetail(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, "Add", bNewStatus_FeeDueObj, bNewStatus_FeeDue1Obj, TxtAdmissionDocId.AgSelectedValue)
                Call PLib.FunFeeDueAccountPosting(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, "Add", bNewStatus_FeeDueObj)

                mQry = "UPDATE Sch_AdmissionStatusChangeDetail " & _
                        " SET FeeDueDocId = " & AgL.Chk_Text(bNewStatus_FeeDueDocId) & " " & _
                        " WHERE DocId = '" & TxtAdmissionDocId.AgSelectedValue & "' " & _
                        " AND Sr = " & bIntStatusChange_Sr & " "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                AgL.UpdateVoucherCounter(bNewStatus_FeeDueDocId, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                Call AgL.LogTableEntry(bNewStatus_FeeDueDocId, Me.Text, AgL.MidStr("Add", 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, Me.Text)
            End If
        End If
        '===============================================================================================================================================

        Return bNewStatus_FeeDueDocId
    End Function

End Class

