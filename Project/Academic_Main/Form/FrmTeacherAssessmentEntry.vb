Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmTeacherAssessmentEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1SubCode As Byte = 1
    Private Const Col1AdmissionDocId As Byte = 2
    Private Const Col1PointsObtain As Byte = 3

    Private AssessmentType_Student As String = "Student"
    Private AssessmentType_HOD As String = "HOD"
    Dim mMaxPoints As Integer = 0

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
            .AddAgTextColumn(DGL1, "DGL1SNo", 50, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1SubCode", 290, 8, "Name", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionDocId", 150, 8, "AdmissionDocId", False, True, False)
            .AddAgNumberColumn(DGL1, "Dgl1MarksObtain", 70, 3, 0, False, "Marks Obtained", True, False)
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
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " "

            mQry = "Select S.GUID As SearchCode " & _
                    " From Sch_TeacherAssessment S " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            AgCL.IniAgHelpList(TxtAssesmentType, "" & AssessmentType_Student & "," & AssessmentType_HOD & "")

            mQry = "SELECT S.Code , S.StreamYearSemesterDesc AS Name, S.SessionProgrammeCode, S.SessionCode as Session " & _
                    " FROM ViewSch_StreamYearSemester S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " ORDER BY S.StreamYearSemesterDesc "
            TxtStreamYearSemester.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.Description AS Session FROM Sch_Session S "
            TxtSession.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.SubCode, S.Name AS Name " & _
                    " FROM SubGroup S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By S.Name"
            DGL1.AgHelpDataSet(Col1SubCode, 1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT E.SubCode AS Code, S.Name AS Teacher, E.DateOfJoin, E.DateOfResign  " & _
                    " FROM Pay_Employee E " & _
                    " LEFT JOIN SubGroup S ON E.SubCode = S.SubCode " & _
                    " WHERE isnull(E.IsTeachingStaff,0) <> 0 " & _
                    " AND " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " "
            TxtTeacher.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            If mSearchCode <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then
                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    AgL.Dman_ExecuteNonQry("Delete From Sch_TeacherAssessment1 Where GUID ='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_TeacherAssessment Where GUID='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        TxtAssesmentType.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "
            mQry = "Select A.GUID As SearchCode, S.Name AS [Site Name],  " & _
                    "  A.AssessmentDate, T.DispName as Teacher, " & _
                    " V2.StreamYearSemesterDesc as StreamYearSemester,  " & _
                    " V2.SessionDescription as Session " & _
                    " From Sch_TeacherAssessment A " & _
                    " LEFT JOIN SiteMast S ON A.Site_Code = S.Code " & _
                    " Left Join ViewSch_StreamYearSemester V2 On A.StreamYearSemester = V2.Code " & _
                    " LEFT JOIN SubGroup T On A.Teacher = T.SubCode " & _
                    " " & mCondStr & " "

            AgL.PubFindQry = mQry

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
            RepName = "Academic_Main_TeacherAssessment"
            RepTitle = "Teacher Assessment"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " SELECT  A.Guid, A.Div_Code, A.Site_Code, A.AssessmentType, A.AssessmentDate, " & _
                        " A.Teacher, A.Session, A.StreamYearSemester, A.MaxPoints, A.PreparedBy, " & _
                        " A.U_EntDt, A.U_AE, A.Edit_Date, A.ModifiedBy, A1.SubCode,  " & _
                        " A1.AdmissionDocId, A1.PointsObtain, S.ManualCode AS TeacherManualCode,  " & _
                        " S.DispName AS TeacherDispName, S.Name  AS TeacherName, " & _
                        " S1.ManualCode AS PersonManualCode, S1.DispName AS PersonDispName,  " & _
                        " S1.Name AS PersonName, Sm.Name AS SiteName, Se.Description AS SessionDescription, " & _
                        " Se.ManualCode AS SessionManualCode, Ys.StreamYearSemesterDesc " & _
                        " FROM Sch_TeacherAssessment A " & _
                        " LEFT JOIN Sch_TeacherAssessment1 A1 ON A.Guid = A1.Guid " & _
                        " LEFT JOIN Sch_Session Se ON A.Session = Se.Code " & _
                        " LEFT JOIN ViewSch_StreamYearSemester Ys ON A.StreamYearSemester = Ys.Code " & _
                        " LEFT JOIN SiteMast Sm ON A.Site_Code = Sm.Code " & _
                        " LEFT JOIN SubGroup S ON A.Teacher = S.SubCode " & _
                        " LEFT JOIN SubGroup S1 ON A1.SubCode = S1.SubCode " & _
                        " WHERE A.GUID = '" & mSearchCode & "' "

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)

            ''''''''''IF CUSTOMER NEED SOME CHANGE IN FORMAT OF A REPORT'''''''''''
            ''''''''''CUTOMIZE REPORT CAN BE CREATED WITHOUT CHANGE IN CODE''''''''
            ''''''''''WITH ADDING 6 CHAR OF COMPANY NAME AND 4 CHAR OF CITY NAME'''
            ''''''''''WITHOUT SPACES IN EXISTING REPORT NAME''''''''''''''''''''''''''''''''''''''
            RepName = AgPL.GetRepNameCustomize(RepName, PLib.PubReportPath_Academic_Main)

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
        Dim I As Integer, bSr As Integer = 0
        Dim mTrans As Boolean = False

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO dbo.Sch_TeacherAssessment(Guid, Div_Code, Site_Code, AssessmentType, " & _
                        " AssessmentDate, Teacher, Session, StreamYearSemester, MaxPoints, PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ( '" & mSearchCode & "',	'" & AgL.PubDivCode & "',	" & _
                        " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & AgL.Chk_Text(TxtAssesmentType.Text) & ", " & _
                        " " & AgL.ConvertDate(TxtAssesmentDate.Text) & ", " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & ",	" & _
                        " " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ",	" & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                        " " & Val(TxtMaxPoints.Text) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "UPDATE Sch_TeacherAssessment " & _
                        " SET " & _
                        " AssessmentType = " & AgL.Chk_Text(TxtAssesmentType.Text) & ", " & _
                        " AssessmentDate = " & AgL.ConvertDate(TxtAssesmentDate.Text) & ", " & _
                        " Teacher = " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & ", " & _
                        " Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ", " & _
                        " StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                        " MaxPoints = " & Val(TxtMaxPoints.Text) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "'" & _
                        " WHERE GUID = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If Topctrl1.Mode = "Edit" Then
                AgL.Dman_ExecuteNonQry("Delete From Sch_TeacherAssessment1 Where GUID='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1SubCode, I).Value <> "" Then
                        bSr += 1
                        mQry = "INSERT INTO Sch_TeacherAssessment1(Guid, Sr, SubCode, AdmissionDocId, PointsObtain) " & _
                                " VALUES ('" & mSearchCode & "', " & bSr & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1SubCode, I)) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1AdmissionDocId, I).Value) & ",	" & _
                                " " & Val(.Item(Col1PointsObtain, I).Value) & ")"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
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

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim MastPos As Long
        Dim I As Integer
        Dim mTransFlag As Boolean = False
        Try
            FClear()
            BlankText()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode").ToString
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then
                mQry = "Select S.* " & _
                        " From Sch_TeacherAssessment S " & _
                        " Where S.GUID = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtAssesmentType.Text = AgL.XNull(.Rows(0)("AssessmentType"))
                        TxtAssesmentDate.Text = Format(AgL.XNull(.Rows(0)("AssessmentDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                        TxtTeacher.AgSelectedValue = AgL.XNull(.Rows(0)("Teacher"))
                        TxtSession.AgSelectedValue = AgL.XNull(.Rows(0)("Session"))
                        TxtStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        TxtMaxPoints.Text = AgL.VNull(.Rows(0)("MaxPoints"))

                        LblStreamYearSemester.Tag = AgL.XNull(.Rows(0)("Session"))
                        DGL1.Tag = TxtStreamYearSemester.AgSelectedValue

                        mMaxPoints = Val(TxtMaxPoints.Text)
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select A1.* " & _
                        " From Sch_TeacherAssessment1 A1 " & _
                        " Where A1.GUID = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1SubCode, I) = AgL.XNull(.Rows(I)("SubCode"))
                            DGL1.Item(Col1AdmissionDocId, I).Value = AgL.XNull(.Rows(I)("AdmissionDocId"))
                            DGL1.Item(Col1PointsObtain, I).Value = AgL.VNull(.Rows(I)("PointsObtain"))
                        Next I
                    End If
                End With
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If mTransFlag Then
                    Topctrl1.tEdit = False
                    Topctrl1.tDel = False
                Else
                    If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                    If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
                End If
            End If

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
        LblStreamYearSemester.Tag = "" : DGL1.Tag = "" : mMaxPoints = 0
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False

        If Topctrl1.Mode = "Edit" Then
            TxtAssesmentType.Enabled = False
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
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                '<Executable Code>
            End Select
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

            End Select
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
        TxtSite_Code.Enter, TxtAssesmentType.Enter, TxtStreamYearSemester.Enter, TxtTeacher.Enter
        Try
            Select Case sender.name
                Case TxtTeacher.Name
                    TxtTeacher.AgRowFilter = "DateOfJoin <= " & AgL.ConvertDate(TxtAssesmentDate.Text) & " AND (DateOfResign > " & AgL.ConvertDate(TxtAssesmentDate.Text) & " Or DateOfResign Is Null) "

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
           TxtSite_Code.Validating, TxtAssesmentType.Validating, TxtStreamYearSemester.Validating, _
           TxtStreamYearSemester.Validating, TxtSession.Validating, TxtMaxPoints.Validating, TxtAssesmentDate.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtStreamYearSemester.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtSession.AgSelectedValue = AgL.XNull(DrTemp(0)("Session"))
                            LblStreamYearSemester.Tag = AgL.XNull(DrTemp(0)("Session"))
                        End If
                    End If

                Case TxtMaxPoints.Name
                    mMaxPoints = Val(TxtMaxPoints.Text)

                Case TxtAssesmentDate.Name
                    If TxtAssesmentDate.Text.ToString.Trim = "" Then TxtAssesmentDate.Text = AgL.PubLoginDate
                    TxtAssesmentDate.Text = AgL.RetFinancialYearDate(TxtAssesmentDate.Text.ToString)

            End Select

            If AgL.StrCmp(TxtAssesmentType.Text, AssessmentType_HOD) Then TxtStreamYearSemester.Enabled = False
            If TxtStreamYearSemester.Text <> "" Then
                If Not AgL.StrCmp(LblStreamYearSemester.Tag, TxtSession.AgSelectedValue) Then
                    TxtStreamYearSemester.AgSelectedValue = ""
                    LblStreamYearSemester.Tag = ""
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtAssesmentType, LblAssesmentType.Text) Then Exit Function
            If AgL.RequiredField(TxtTeacher, LblTeacher.Text) Then Exit Function

            If AgL.StrCmp(TxtAssesmentType.Text, AssessmentType_Student) Then
                If AgL.RequiredField(TxtStreamYearSemester, LblStreamYearSemester.Text) Then Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1SubCode) Then Exit Function
            'If AgCL.AgIsDuplicate(DGL1, "" & Col1SubCode & "") Then Exit Function

            If Not AgL.StrCmp(DGL1.Tag, TxtStreamYearSemester.AgSelectedValue) Then
                MsgBox("Students In Grid Does Not Belong To " & TxtStreamYearSemester.Text & " ")
                Exit Function
            End If

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .AgSelectedValue(Col1SubCode, I) <> "" Then
                        If Val(.Item(Col1PointsObtain, I).Value) > Val(TxtMaxPoints.Text) Then
                            MsgBox("Obtained Points Are Greater Than " & Val(TxtMaxPoints.Text) & " At Row No " & .Item(Col_SNo, I).Value & " ", MsgBoxStyle.Information)
                            .CurrentCell = .Item(Col1PointsObtain, I) : DGL1.Focus() : Exit Function
                        End If
                    End If
                Next
            End With

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                mSearchCode = AgL.GetGUID(AgL.GcnRead).ToString
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtAssesmentType.Focus()
    End Sub

    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Try
            Select Case sender.name
                Case BtnFill.Name
                    Call ProcFillStudent()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillStudent()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim bCondStr$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If AgL.RequiredField(TxtSite_Code) Then Exit Sub
            If AgL.RequiredField(TxtAssesmentType) Then Exit Sub
            If AgL.RequiredField(TxtSession, LblSession.Text) Then Exit Sub

            If AgL.StrCmp(TxtAssesmentType.Text, AssessmentType_Student) Then
                If AgL.RequiredField(TxtStreamYearSemester, LblStreamYearSemester.Text) Then Exit Sub
                DGL1.Tag = TxtStreamYearSemester.AgSelectedValue
            End If

            If AgL.StrCmp(TxtAssesmentType.Text, AssessmentType_Student) Then
                bCondStr = "WHERE V1.FromStreamYearSemester = '" & TxtStreamYearSemester.AgSelectedValue & "' And A.Site_Code = '" & AgL.PubSiteCode & "'  "
                mQry = "SELECT V1.*, A.Student AS SubCode " & _
                        " FROM " & _
                        " (SELECT Ap.* FROM ViewSch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) AS V1 " & _
                        " LEFT JOIN ViewSch_Admission A ON V1.AdmissionDocId = A.DocId " & bCondStr & _
                        " ORDER BY A.StudentName "
            Else
                mQry = "SELECT E.SubCode , '' AS AdmissionDocId " & _
                        " FROM Pay_Employee E " & _
                        " LEFT JOIN SubGroup S ON E.SubCode = S.SubCode " & _
                        " WHERE (IsNull(E.IsTeachingStaff,0)<>0 or IsNull(E.CanTakeClass,0)<>0) " & _
                        " AND DateOfJoin <= '" & TxtAssesmentDate.Text & "'  " & _
                        " AND (DateOfResign > '" & TxtAssesmentDate.Text & "' Or DateOfResign Is Null)  " & _
                        " AND S.Site_Code = '" & AgL.PubSiteCode & "'" & _
                        " Order By S.Name"
            End If

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1SubCode, I) = AgL.XNull(.Rows(I)("SubCode"))
                        DGL1.Item(Col1AdmissionDocId, I).Value = AgL.XNull(.Rows(I)("AdmissionDocId"))
                    Next I
                Else
                    MsgBox("No Student Record Exists!...")
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            TxtAssesmentType.Enabled = False
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub DGL1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGL1.CellValidating
        Dim J As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex
            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                If .CurrentCell.ColumnIndex = Col1PointsObtain Then
                    If .Item(Col1SubCode, e.RowIndex).Value <> "" Then
                        If Val(e.FormattedValue) > Val(mMaxPoints) Then
                            MsgBox("Obtained Marks Can't Be Greater Than """ & TxtMaxPoints.Text & """ ", MsgBoxStyle.Information)
                            e.Cancel = True
                            Exit Sub
                        End If
                    End If
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub
End Class
