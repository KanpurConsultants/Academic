Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmEnrollmentNoAssign
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1AdmissionDocId As Byte = 1
    Private Const Col1AdmissionID As Byte = 2
    Private Const Col1EnrollmentNo As Byte = 3
    Private Const Col1TempEnrollmentNo As Byte = 4

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
        ''================< Fee Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionDocId", 250, 8, "Student", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionId", 150, 8, "Admission ID", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1EnrollmentNo", 120, 60, "Enrollment No.", True, False, True)
            .AddAgTextColumn(DGL1, "Dgl1TempEnrollmentNo", 150, 60, "Temp Enrollment No.", False, True, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False

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
        Try
            Me.Cursor = Cursors.WaitCursor
            If Topctrl1.Mode = "Browse" Then Exit Sub
            Select Case Sender.name
                'Case <Sender>.Name
                'PObj.FOpen_LinkForm_Common_Master("MnuCustomerMaster", "Customer Master", Me.MdiParent)
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
            AgL.WinSetting(Me, 650, 880, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
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
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("Sem.Site_Code", AgL.PubSiteCode) & " "

            mQry = "SELECT Sem.SessionProgrammeStreamCode AS SearchCode " & _
                    " FROM Sch_AdmissionEnrollmentNo E " & _
                    " LEFT JOIN (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.PromotionDate IS NULL) vP On E.DocId = vP.AdmissionDocId " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON  Sem.Code = vP.FromStreamYearSemester " & _
                    " " & mCondStr & " " & _
                    " GROUP BY Sem.SessionProgrammeStreamCode "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT P.Code , P.SessionProgramme AS Name " & _
                " FROM ViewSch_SessionProgramme P " & _
                " Where 1=1 And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY P.SessionProgramme"
        TxtSessionProgramme.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.Code, S.SessionProgrammeStream AS Name, S.SessionProgramme AS SessionProgrammeCode " & _
                " FROM ViewSch_SessionProgrammeStream S " & _
                " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY S.SessionProgrammeStream "
        TxtSessionProgrammeStream.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT V1.DocId As Code, V1.StudentName As [Student Name], V1.AdmissionID, V1.EnrollmentNo, V1.Student As StudentCode " & _
                " FROM ViewSch_Admission V1 " & _
                " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By V1.StudentName "
        DGL1.AgHelpDataSet(Col1AdmissionDocId, 2) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bSubQry$ = ""

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            If mSearchCode <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    bSubQry = "SELECT V1.DocId " & _
                            " FROM (SELECT P.* FROM Sch_AdmissionPromotion P  WITH (NoLock) WHERE P.PromotionDate IS NULL) vP " & _
                            " LEFT JOIN Sch_Admission V1  WITH (NoLock) On V1.DocId = vP.AdmissionDocId " & _
                            " LEFT JOIN ViewSch_StreamYearSemester Sem  WITH (NoLock) ON  Sem.Code = vP.FromStreamYearSemester " & _
                            " Where V1.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " And " & _
                            " Sem.SessionProgrammeStreamCode = " & AgL.Chk_Text(mSearchCode) & " "

                    mQry = "Delete From Sch_AdmissionEnrollmentNo " & _
                            " Where DocId In (" & bSubQry & ") "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

                    AgL.ETrans.Commit()
                    mTrans = False

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
        TxtSessionProgrammeStream.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("Ps.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQry = "SELECT Sem.SessionProgrammeStreamCode As SearchCode, Max(S.Name) As [Site Name], Max(Sem.SessionProgrammeDesc) AS [Session/Programme], Max(Sem.SessionProgrammeStreamDesc) As [Session/Programme/Stream] " & _
                                " FROM Sch_AdmissionEnrollmentNo E " & _
                                " LEFT JOIN (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.PromotionDate IS NULL) vP On E.DocId = vP.AdmissionDocId " & _
                                " LEFT JOIN ViewSch_StreamYearSemester Sem ON  Sem.Code = vP.FromStreamYearSemester " & _
                                " LEFT JOIN SiteMast S ON Sem.Site_Code = S.Code " & _
                                " Where " & AgL.PubSiteCondition("Sem.Site_Code", AgL.PubSiteCode) & " " & _
                                " GROUP BY Sem.SessionProgrammeStreamCode "

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
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = "Enrollment Report"
            RepName = "Academic_Enrollment_Report" : RepTitle = "Enrollment Report"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " SELECT e.docid, s.SessionProgrammeStream, S.Site_Code As Site_Code, p.SessionProgramme AS SessionProgrammeCode, a.AdmissionID, a.EnrollmentNo,a.StudentName " & _
                     " FROM Sch_AdmissionEnrollmentNo E LEFT JOIN ViewSch_Admission A ON E.DocId = A.DocId " & _
                     " LEFT JOIN ViewSch_SessionProgrammeStream S ON A.SessionProgrammeStream = S.Code  " & _
                     " left JOIN ViewSch_SessionProgramme p ON s.SessionProgramme=p.Code " & _
                     " Where a.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " And " & _
                     " a.SessionProgrammeStream = " & AgL.Chk_Text(mSearchCode) & " "



            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)
            mCrd.Load(PLib.PubReportPath_Academic_Main & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer
        Dim mTrans As Boolean = False

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If Topctrl1.Mode = "Add" Then
                        If .Item(Col1AdmissionDocId, I).Value.ToString.Trim <> "" And .Item(Col1EnrollmentNo, I).Value.ToString.Trim <> "" Then
                            mQry = FunGetInsertQry(I)
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If .Item(Col1AdmissionDocId, I).Value.ToString.Trim <> "" And .Item(Col1EnrollmentNo, I).Value.ToString.Trim <> "" And _
                            Not AgL.StrCmp(.Item(Col1EnrollmentNo, I).Value, .Item(Col1TempEnrollmentNo, I).Value) Then

                            If .Item(Col1TempEnrollmentNo, I).Value.ToString.Trim <> "" Then
                                mQry = "Update Sch_AdmissionEnrollmentNo " & _
                                        " SET " & _
                                        " 	EnrollmentNo = " & AgL.Chk_Text(.Item(Col1EnrollmentNo, I).Value) & ", " & _
                                        " 	U_AE = 'E', " & _
                                        " 	Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                                        " 	ModifiedBy = '" & AgL.PubUserName & "' " & _
                                        " WHERE DocId = " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & " "
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            Else
                                mQry = FunGetInsertQry(I)
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            End If
                        ElseIf .Item(Col1AdmissionDocId, I).Value.ToString.Trim <> "" And .Item(Col1EnrollmentNo, I).Value.ToString.Trim = "" Then
                            If .Item(Col1TempEnrollmentNo, I).Value.ToString.Trim <> "" Then
                                mQry = "Delete From Sch_AdmissionEnrollmentNo " & _
                                        " Where DocId = " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & " "
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            End If
                        End If
                    End If
                Next I
            End With

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)


            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode

                Topctrl1.FButtonClick(0)

                'If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    Call PrintDocument(mDocId)
                'End If

                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FunGetInsertQry(ByVal bRowIndex As Integer) As String
        Dim bQry$ = ""

        bQry = "INSERT INTO Sch_AdmissionEnrollmentNo ( " & _
                " DocId, EnrollmentNo, PreparedBy, U_EntDt, U_AE ) " & _
                " VALUES ( " & _
                " " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1AdmissionDocId, bRowIndex)) & ", " & AgL.Chk_Text(DGL1.Item(Col1EnrollmentNo, bRowIndex).Value) & ", " & _
                " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"

        FunGetInsertQry = bQry
    End Function

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim MastPos As Long
        Dim I As Integer
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
                'mQry = "SELECT A.SessionProgrammeStream, Max(S.Site_Code) As Site_Code, Max(S.SessionProgramme) AS SessionProgrammeCode " & _
                '        " FROM Sch_AdmissionEnrollmentNo E " & _
                '        " LEFT JOIN Sch_Admission A ON E.DocId = A.DocId " & _
                '        " LEFT JOIN ViewSch_SessionProgrammeStream S ON A.SessionProgrammeStream = S.Code " & _
                '        " Where A.SessionProgrammeStream = '" & mSearchCode & "' " & _
                '        " GROUP BY A.SessionProgrammeStream "

                mQry = "SELECT Sem.SessionProgrammeStreamCode As SessionProgrammeStream, Max(Sem.Site_Code) As Site_Code, Max(Sem.SessionProgrammeCode) AS SessionProgrammeCode " & _
                        " FROM Sch_AdmissionEnrollmentNo E " & _
                        " LEFT JOIN (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.PromotionDate IS NULL) vP On E.DocId = vP.AdmissionDocId " & _
                        " LEFT JOIN ViewSch_StreamYearSemester Sem ON  Sem.Code = vP.FromStreamYearSemester " & _
                        " Where Sem.SessionProgrammeStreamCode = '" & mSearchCode & "' " & _
                        " GROUP BY Sem.SessionProgrammeStreamCode "

                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgrammeCode"))
                        TxtSessionProgrammeStream.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgrammeStream"))                        

                        LblSessionProgrammeStream.Tag = AgL.XNull(.Rows(0)("SessionProgrammeCode"))
                    End If
                End With



                'mQry = "SELECT V1.DocId As AdmissionDocId, V1.AdmissionID, V1.EnrollmentNo, V1.Student As StudentCode " & _
                '        " FROM ViewSch_Admission V1 " & _
                '        " Where V1.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " And " & _
                '        " V1.SessionProgrammeStream = " & AgL.Chk_Text(mSearchCode) & " " & _
                '        " Order By V1.StudentName "
                mQry = "SELECT V1.DocId As AdmissionDocId, V1.AdmissionID, V1.EnrollmentNo, V1.Student As StudentCode " & _
                        " FROM (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.PromotionDate IS NULL) vP  " & _
                        " LEFT JOIN ViewSch_Admission V1 On V1.DocId = vP.AdmissionDocId " & _
                        " LEFT JOIN ViewSch_StreamYearSemester Sem ON  Sem.Code = vP.FromStreamYearSemester " & _
                        " Where V1.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " And " & _
                        " Sem.SessionProgrammeStreamCode = " & AgL.Chk_Text(mSearchCode) & " " & _
                        " Order By V1.StudentName "
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                            DGL1.Item(Col1AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))
                            DGL1.Item(Col1EnrollmentNo, I).Value = AgL.XNull(.Rows(I)("EnrollmentNo"))
                            DGL1.Item(Col1TempEnrollmentNo, I).Value = AgL.XNull(.Rows(I)("EnrollmentNo"))

                            If AgL.XNull(.Rows(I)("EnrollmentNo")).ToString.Trim <> "" Then
                                TxtTotalStudent.Text = Val(TxtTotalStudent.Text) + 1
                            End If
                        Next I
                    End If
                End With
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            DTbl = Nothing
            'Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""

        DGL1.RowCount = 1 : DGL1.Rows.Clear()

    End Sub



    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False

        If Topctrl1.Mode = "Edit" Then
            TxtSessionProgramme.Enabled = False
            TxtSessionProgrammeStream.Enabled = False
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
                Case Col1AdmissionDocId
                    'DGL1.AgRowFilter(AdmissionDocId) = " And AdmissionDocId = '" & TxtStreamYearSemester.AgSelectedValue & "'"
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
                '<Executable Code>
            End Select
            Call Calculation()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
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
                Case Col1AdmissionDocId
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

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
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
        TxtSite_Code.Enter, TxtSessionProgramme.Enter, TxtSessionProgrammeStream.Enter
        Try
            Select Case sender.name
                Case TxtSessionProgrammeStream.Name
                    TxtSessionProgrammeStream.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
           TxtSite_Code.Validating, TxtSessionProgramme.Validating, TxtSessionProgrammeStream.Validating


        Try
            Select Case sender.NAME
                Case TxtSessionProgrammeStream.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblSessionProgrammeStream.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblSessionProgrammeStream.Tag = AgL.XNull(.Item("SessionProgrammeCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

            End Select

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblSessionProgrammeStream.Tag.ToString) Then
                TxtSessionProgrammeStream.AgSelectedValue = ""
                LblSessionProgrammeStream.Tag = ""
            End If

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        TxtTotalStudent.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1AdmissionDocId, I).Value Is Nothing Then .Item(Col1AdmissionDocId, I).Value = ""
                If .Item(Col1EnrollmentNo, I).Value Is Nothing Then .Item(Col1EnrollmentNo, I).Value = ""

                If .Item(Col1AdmissionDocId, I).Value <> "" And .Item(Col1EnrollmentNo, I).Value.ToString.Trim <> "" Then
                    TxtTotalStudent.Text = Val(TxtTotalStudent.Text) + 1
                End If
            Next
        End With

        TxtTotalStudent.Text = Format(Val(TxtTotalStudent.Text), "0")
    End Sub


    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtSessionProgramme, "Session/Programme") Then Exit Function
            If AgL.RequiredField(TxtSessionProgrammeStream, "Session/Programme/Stream") Then Exit Function

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblSessionProgrammeStream.Tag.ToString) Then
                MsgBox("Session/Programme/Stream Is Not Valid!...") : TxtSessionProgrammeStream.Focus() : Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1AdmissionDocId) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1AdmissionDocId & "") Then Exit Function

            If AgL.RequiredField(TxtTotalStudent, "Total Student", True) Then DGL1.CurrentCell = DGL1(Col1EnrollmentNo, 0) : DGL1.Focus() : Exit Function

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            If Topctrl1.Mode = "Add" Then
                If FunIsRecordExists() = True Then MsgBox("Record Already Exists!...") : TxtSessionProgrammeStream.Focus() : Exit Function

                mSearchCode = TxtSessionProgrammeStream.AgSelectedValue
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Function FunIsRecordExists() As Boolean
        Dim bFlag As Boolean = False

        mQry = "SELECT IsNull(Count(*),0) Cnt FROM ViewSch_Admission A " & _
                " WHERE A.Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And " & _
                " A.SessionProgrammeStream = '" & TxtSessionProgrammeStream.AgSelectedValue & "' And " & _
                " A.EnrollmentNo IS NOT NULL "
        If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then bFlag = True

        FunIsRecordExists = bFlag
    End Function
    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode

        TxtSessionProgramme.Focus()
    End Sub


    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillStudent.Click
        Try
            Select Case sender.name
                Case BtnFillStudent.Name
                    Call ProcFillStudent()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillStudent()
        Dim DtTemp As DataTable
        Dim I As Integer
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If AgL.RequiredField(TxtSite_Code) Then Exit Sub
            If AgL.RequiredField(TxtSessionProgramme, "Session/Programme") Then Exit Sub
            If AgL.RequiredField(TxtSessionProgrammeStream, "Session/Programme/Stream") Then Exit Sub

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblSessionProgrammeStream.Tag.ToString) Then
                MsgBox("Session/Programme/Stream Is Not Valid!...") : TxtSessionProgrammeStream.Focus() : Exit Sub
            End If

            If Topctrl1.Mode = "Add" Then
                If FunIsRecordExists() = True Then MsgBox("Record Already Exists!...") : TxtSessionProgrammeStream.Focus() : Exit Sub
            End If


            'mQry = "SELECT V1.DocId As AdmissionDocId, V1.AdmissionID, V1.EnrollmentNo, V1.Student As StudentCode " & _
            '        " FROM ViewSch_Admission V1 " & _
            '        " Where V1.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " And " & _
            '        " V1.SessionProgrammeStream = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " " & _
            '        " Order By V1.StudentName "
            mQry = "SELECT V1.DocId As AdmissionDocId, V1.AdmissionID, V1.EnrollmentNo, V1.Student As StudentCode " & _
                    " FROM (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.PromotionDate IS NULL) vP  " & _
                    " LEFT JOIN ViewSch_Admission V1 On V1.DocId = vP.AdmissionDocId " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON  Sem.Code = vP.FromStreamYearSemester " & _
                    " Where V1.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " And " & _
                    " Sem.SessionProgrammeStreamCode = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " " & _
                    " Order By V1.StudentName "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If .Rows.Count > 0 Then
                    TxtSessionProgramme.Enabled = False
                    TxtSessionProgrammeStream.Enabled = False

                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL1.Item(Col1AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))
                        DGL1.Item(Col1EnrollmentNo, I).Value = AgL.XNull(.Rows(I)("EnrollmentNo"))
                        DGL1.Item(Col1TempEnrollmentNo, I).Value = AgL.XNull(.Rows(I)("EnrollmentNo"))
                    Next I

                    DGL1.CurrentCell = DGL1(Col1EnrollmentNo, 0) : DGL1.Focus()
                Else
                    TxtSessionProgramme.Enabled = True
                    TxtSessionProgrammeStream.Enabled = True

                    MsgBox("No Student Record Exists!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            Call Calculation()
        End Try
    End Sub

End Class
