Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmStreamYearSemesterExam

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Subject As Byte = 1
    Private Const Col1SubjectType As Byte = 2
    Private Const Col1Exam_MaxMarks As Byte = 3
    Private Const Col1Exam_MinMarks As Byte = 4
    Private Const Col1Test_MaxMarks As Byte = 5
    Private Const Col1Test_MinMarks As Byte = 6
    Private Const Col1Assignment_MaxMarks As Byte = 7
    Private Const Col1Assignment_MinMarks As Byte = 8
    Private Const Col1Attendance_MaxMarks As Byte = 9
    Private Const Col1Attendance_MinMarks As Byte = 10
    Private Const Col1Total_MaxMarks As Byte = 11
    Private Const Col1Total_MinMarks As Byte = 12

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Protected Const Col2SNo As String = "S. No."
    Protected Const Col2StreamYearSemester As String = "Current Semester"
    Protected Const Col2Session As String = "Session"
    Protected Const Col2Program As String = "Program"
    Protected Const Col2Stream As String = "Stream"
    Protected Const Col2Semester As String = "Semester"

    Dim mQry As String = "", mSearchCode As String = ""

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
        AgL.AddAgDataGrid(DGL1, Pnl1)
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1Subject", 240, 50, "Subject", True, True, False, True)
            .AddAgTextColumn(DGL1, "Dgl1SubjectType", 60, 20, "Subject Type", True, True, False)
            .AddAgNumberColumn(DGL1, "Dgl1Exam_MaxMarks", 60, 3, 2, False, "Exam Max Marks", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1Exam_MinMarks", 60, 3, 2, False, "Exam Min Marks", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1Test_MaxMarks", 50, 3, 2, False, "Test Max Marks", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1Test_MinMarks", 50, 3, 2, False, "Test Min Marks", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1Assignment_MaxMarks", 50, 3, 2, False, "Assign~t Max Marks", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1Assignment_MinMarks", 50, 3, 2, False, "Assign~t Min Marks", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1Attendance_MaxMarks", 50, 3, 2, False, "Attend~e Max Marks", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1Attendance_MinMarks", 50, 3, 2, False, "Attend~e Min Marks", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1Total_MaxMarks", 60, 3, 2, False, "Total Max Marks", True, True, True, True)
            .AddAgNumberColumn(DGL1, "Dgl1Total_MinMarks", 60, 3, 2, False, "Total Min Marks", True, True, True, True)
        End With
        DGL1.ColumnHeadersHeight = 60
        DGL1.AllowUserToAddRows = False
        ''***************************************************

        With AgCL
            .AddAgTextColumn(DGL2, Col2SNo, 60, 20, Col2SNo, True, True, False)
            .AddAgTextColumn(DGL2, Col2StreamYearSemester, 300, 20, Col2StreamYearSemester, True, True, False)
            .AddAgTextColumn(DGL2, Col2Session, 100, 20, Col2Session, False, True, False)
            .AddAgTextColumn(DGL2, Col2Program, 100, 20, Col2Program, False, True, False)
            .AddAgTextColumn(DGL2, Col2Stream, 100, 20, Col2Stream, False, True, False)
            .AddAgTextColumn(DGL2, Col2Semester, 100, 20, Col2Semester, False, True, False)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ReadOnly = True
        DGL2.AllowUserToAddRows = False
        DGL2.AgSkipReadOnlyColumns = True
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
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 600, 950, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            'Code by Akash on date 23-9-10
            'End code 
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr$ = ""

        mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & " "

        mQry = "SELECT E.Code As SearchCode FROM Exam_SemesterExam E " & mCondStr
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        Try

            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                   " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT P.Code, P.SessionProgramme AS Name  " & _
                    " FROM ViewSch_SessionProgramme P " & _
                    " Where " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By P.SessionProgramme"
            TxtSessionProgramme.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Sem.Code, Sem.StreamYearSemesterDesc as Name, Sem.SessionProgrammeCode,Sem.Semester,Sem.StreamCode,Sem.SessionCode,Sem.ProgrammeCode " & _
                    " FROM ViewSch_StreamYearSemester Sem " & _
                    " Where " & AgL.PubSiteCondition("Sem.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By Sem.StreamYearSemesterDesc"
            TxtStreamYearSemester.AgHelpDataSet(5) = AgL.FillData(mQry, AgL.GCn)
            DGL2.AgHelpDataSet(Col2StreamYearSemester, 5) = TxtStreamYearSemester.AgHelpDataSet.Copy

            mQry = "SELECT Et.Code , Et.Description AS [Exam Type], Et.ExamNature AS Nature FROM Exam_ExamType Et ORDER BY Et.Description "
            TxtExamType.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT E.Code, Sem.StreamYearSemesterDesc as Semester, Et.Description As ExamType, Et.ExamNature as ExamNature  " & _
                    " FROM Exam_SemesterExam E " & _
                    " Left Join ViewSch_StreamYearSemester Sem On E.StreamYearSemester = Sem.code " & _
                    " Left Join Exam_ExamType Et On E.ExamType = Et.Code " & _
                    " Where " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By Sem.StreamYearSemesterDesc "
            TxtCopyFrom.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select S.Code  As Code, S.Description As Name, S.SubjectType " & _
                    " From Sch_Subject S " & _
                    " Order By S.Description "
            DGL1.AgHelpDataSet(Col1Subject) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ClassSectionDesc " & _
                 " FROM ViewSch_ClassSection S " & _
                 " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                 " ORDER BY S.ClassSectionDesc "
            TxtClassSection.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)


            mQry = "SELECT S.Code , S.SubSection, S.ClassSection " & _
                    " FROM ViewSch_ClassSectionSubSection S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY S.ClassSectionSubSectionDesc"
            TxtClassSectionSubSection.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ManualCode AS Session " & _
                     " FROM Sch_Session S " & _
                     " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                     " Order By S.ManualCode "
            TxtSession.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtSessionProgramme.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False


        Try
            MastPos = BMBMaster.Position


            If DTMaster.Rows.Count > 0 Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True

                    mQry = "Delete From Exam_SemesterExam2 Where Code = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Delete From Exam_SemesterExam1 Where Code = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Delete From Exam_SemesterExam Where Code = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                    AgL.ETrans.Commit()
                    mTrans = False


                    FIniMaster(1)
                    Topctrl1_tbRef()
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
        'Changed by Akash on date 23-9-10
        DispText(False)
        'End change
    End Sub


    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtStreamYearSemester.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try

            AgL.PubFindQry = "SELECT E.Code As SearchCode, Sem.StreamYearSemesterDesc as Semester,C.ClassSectionDesc as [Class Section],CS.SubSection as [Class Sub Section], Et.Description As [Exam Type], Et.ExamNature As [Nature], " & _
                                " Sem.SessionProgrammeStreamDesc, Sem.SessionProgrammeDesc, Sem.SessionManualCode, Sem.ProgrammeManualCode, Sem.StreamManualCode " & _
                                " FROM Exam_SemesterExam E " & _
                                " Left Join ViewSch_StreamYearSemester Sem On E.StreamYearSemester = Sem.code " & _
                                " Left Join ViewSch_ClassSection C On E.ClassSection = C.code " & _
                                " Left Join ViewSch_ClassSectionSubSection CS On E.ClassSectionSubSection = CS.code " & _
                                " Left Join Exam_ExamType Et On E.ExamType = Et.Code " & _
                                " Where " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQryOrdBy = "[Semester]"

            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub
    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub
    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        Dim ds As New DataSet
        Dim strQry As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Exam List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = "SELECT Sem.StreamYearSemesterDesc as Semester, Et.Description As [Exam Type], Et.ExamNature As [Nature] " & _
                        " FROM Exam_SemesterExam E " & _
                        " Left Join ViewSch_StreamYearSemester Sem On E.StreamYearSemester = Sem.code " & _
                        " Left Join Exam_ExamType Et On E.ExamType = E.Code " & _
                        " Where " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & " "

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Exam List"
            mPrnHnd.TableIndex = 0
            mPrnHnd.PageSetupDialog(True)
            mPrnHnd.PrintPreview()
            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, bSr As Integer = 0
        Dim mTrans As Boolean = False

        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Exam_SemesterExam ( Code, StreamYearSemester, ExamType, Remark, " & _
                        " Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ClassSection, ClassSectionSubSection, Session,Description ) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & AgL.Chk_Text(TxtExamType.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtRemark.Text) & ", '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A' ," & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & ", " & AgL.Chk_Text(TxtSession.AgSelectedValue) & " , " & AgL.Chk_Text(TxtExamDescription.Text) & " )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Exam_SemesterExam " & _
                        " SET  " & _
                        " 	StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                        " 	ExamType = " & AgL.Chk_Text(TxtExamType.AgSelectedValue) & ", " & _
                        " 	Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        "   U_AE = 'E', " & _
                        " 	ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & _
                        "   ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & ", " & _
                        "   Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ", " & _
                        "   Description = " & AgL.Chk_Text(TxtExamDescription.Text) & ", " & _
                        " 	Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " 	ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE Code = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Exam_SemesterExam1 Where Code = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                mQry = "Delete From Exam_SemesterExam2 Where Code = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Subject, I).Value <> "" And Val(.Item(Col1Total_MaxMarks, I).Value) > 0 And Val(.Item(Col1Total_MinMarks, I).Value) > 0 Then
                        bSr += 1
                        mQry = "INSERT INTO dbo.Exam_SemesterExam1 " & _
                                " ( Code, Sr, Subject, Exam_MaxMarks, Exam_MinMarks, Test_MaxMarks, Test_MinMarks, " & _
                                " Assignment_MaxMarks, Assignment_MinMarks, Attendance_MaxMarks, Attendance_MinMarks, " & _
                                " Total_MaxMarks, Total_MinMarks ) " & _
                                " VALUES (  " & _
                                " '" & mSearchCode & "', " & bSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1Subject, I)) & ", " & _
                                " " & Val(.Item(Col1Exam_MaxMarks, I).Value) & ", " & Val(.Item(Col1Exam_MinMarks, I).Value) & ", " & _
                                " " & Val(.Item(Col1Test_MaxMarks, I).Value) & ", " & Val(.Item(Col1Test_MinMarks, I).Value) & ", " & _
                                " " & Val(.Item(Col1Assignment_MaxMarks, I).Value) & ", " & Val(.Item(Col1Assignment_MinMarks, I).Value) & ", " & _
                                " " & Val(.Item(Col1Attendance_MaxMarks, I).Value) & ", " & Val(.Item(Col1Attendance_MinMarks, I).Value) & ", " & _
                                " " & Val(.Item(Col1Total_MaxMarks, I).Value) & ", " & Val(.Item(Col1Total_MinMarks, I).Value) & " " & _
                                " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

            With DGL2
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2StreamYearSemester, I).Value <> "" Then
                        bSr += 1
                        mQry = "INSERT INTO dbo.Exam_SemesterExam2 " & _
                                " ( Code, Sr, StreamYearSemester,Session,Programme,Stream,Semester) " & _
                                " VALUES (  " & _
                                " '" & mSearchCode & "', " & bSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col2StreamYearSemester, I)) & " , " & AgL.Chk_Text(.Item(Col2Session, I).Value) & ", " & AgL.Chk_Text(.Item(Col2Program, I).Value) & ", " & AgL.Chk_Text(.Item(Col2Stream, I).Value) & ", " & AgL.Chk_Text(.Item(Col2Semester, I).Value) & ")"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)


            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()
            mTrans = False
            FIniMaster(0, 1)
            Topctrl1_tbRef()
            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
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
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Dim I As Integer
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "SELECT E.*, Et.ExamNature, Sem.SessionProgrammeCode " & _
                        " FROM Exam_SemesterExam E " & _
                        " Left Join Exam_ExamType Et On E.ExamType = Et.Code " & _
                        " Left Join ViewSch_StreamYearSemester Sem On E.StreamYearSemester = Sem.Code " & _
                        " WHERE E.Code ='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgrammeCode"))
                        TxtStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        LblStreamYearSemester.Tag = AgL.XNull(.Rows(0)("SessionProgrammeCode"))
                        TxtExamType.AgSelectedValue = AgL.XNull(.Rows(0)("ExamType"))
                        LblExamType.Tag = AgL.XNull(.Rows(0)("ExamNature"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        '********* Rati **********************
                        TxtClassSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSection"))
                        TxtClassSectionSubSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSectionSubSection"))
                        TxtSession.AgSelectedValue = AgL.XNull(.Rows(0)("Session"))
                        TxtExamDescription.Text = AgL.XNull(.Rows(0)("Description"))
                        ''************************************
                    End If
                End With

                mQry = "SELECT E1.*, S.SubjectType, S.IsGeneralProficiency  " & _
                        " FROM Exam_SemesterExam1 E1 " & _
                        " Left Join Sch_Subject S On E1.Subject = S.Code " & _
                        " WHERE E1.Code ='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                            DGL1.Item(Col1SubjectType, I).Value = AgL.XNull(.Rows(I)("SubjectType"))
                            DGL1.Item(Col1Exam_MaxMarks, I).Value = AgL.VNull(.Rows(I)("Exam_MaxMarks"))
                            DGL1.Item(Col1Exam_MinMarks, I).Value = AgL.VNull(.Rows(I)("Exam_MinMarks"))
                            DGL1.Item(Col1Test_MaxMarks, I).Value = AgL.VNull(.Rows(I)("Test_MaxMarks"))
                            DGL1.Item(Col1Test_MinMarks, I).Value = AgL.VNull(.Rows(I)("Test_MinMarks"))
                            DGL1.Item(Col1Assignment_MaxMarks, I).Value = AgL.VNull(.Rows(I)("Assignment_MaxMarks"))
                            DGL1.Item(Col1Assignment_MinMarks, I).Value = AgL.VNull(.Rows(I)("Assignment_MinMarks"))
                            DGL1.Item(Col1Attendance_MaxMarks, I).Value = AgL.VNull(.Rows(I)("Attendance_MaxMarks"))
                            DGL1.Item(Col1Attendance_MinMarks, I).Value = AgL.VNull(.Rows(I)("Attendance_MinMarks"))
                            DGL1.Item(Col1Total_MaxMarks, I).Value = AgL.VNull(.Rows(I)("Total_MaxMarks"))
                            DGL1.Item(Col1Total_MinMarks, I).Value = AgL.VNull(.Rows(I)("Total_MinMarks"))

                            'Change by Akash on date 23-9-10

                            If ChkTheory.Checked = False And DGL1.Item(Col1SubjectType, I).Value = "Theory" Then ChkTheory.Checked = True
                            If ChkPractical.Checked = False And DGL1.Item(Col1SubjectType, I).Value = "Practical" Then ChkPractical.Checked = True
                            If ChkGenProf.Checked = False Then ChkGenProf.Checked = AgL.VNull(.Rows(I)("IsGeneralProficiency"))

                            'End Change
                        Next I
                    End If
                End With

                mQry = "SELECT E1.*  " & _
                      " FROM Exam_SemesterExam2 E1 " & _
                      " WHERE E1.Code ='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL2.RowCount = 1 : DGL2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col2SNo, I).Value = DGL2.Rows.Count
                            DGL2.AgSelectedValue(Col2StreamYearSemester, I) = AgL.XNull(.Rows(I)("StreamYearSemester"))
                            DGL2.Item(Col2Session, I).Value = AgL.XNull(.Rows(I)("Session"))
                            DGL2.Item(Col2Program, I).Value = AgL.XNull(.Rows(I)("Programme"))
                            DGL2.Item(Col2Stream, I).Value = AgL.XNull(.Rows(I)("Stream"))
                            DGL2.Item(Col2Semester, I).Value = AgL.XNull(.Rows(I)("Semester"))
                        Next I
                    End If
                End With

            Else
                BlankText()
            End If

            Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            Call ProcChangeGridColumnsState()
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""

        'Code by Akash on date 23-9-10
        ChkPractical.Checked = False : ChkTheory.Checked = False : ChkGenProf.Checked = False

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls   
        TxtSite_Code.Enabled = False
        TxtExamDescription.Enabled = False


        Call ProcChangeGridColumnsState()

        'Code by Akash on date 23-9-10
        GrpSubjectType.Enabled = Enb
        'End Code 

        If Topctrl1.Mode = "Edit" Then
            TxtSessionProgramme.Enabled = False
        End If
    End Sub

    Private Sub ProcChangeGridColumnsState()
        If AgL.StrCmp(LblExamType.Tag, ExamNature_Test) Then
            DGL1.Columns(Col1Test_MaxMarks).Visible = True
            DGL1.Columns(Col1Test_MinMarks).Visible = True

            DGL1.Columns(Col1Assignment_MaxMarks).Visible = False
            DGL1.Columns(Col1Assignment_MinMarks).Visible = False

            DGL1.Columns(Col1Exam_MaxMarks).Visible = False
            DGL1.Columns(Col1Exam_MinMarks).Visible = False

            DGL1.Columns(Col1Attendance_MaxMarks).Visible = False
            DGL1.Columns(Col1Attendance_MinMarks).Visible = False

        ElseIf AgL.StrCmp(LblExamType.Tag, ExamNature_Assignment) Then
            DGL1.Columns(Col1Assignment_MaxMarks).Visible = True
            DGL1.Columns(Col1Assignment_MinMarks).Visible = True

            DGL1.Columns(Col1Test_MaxMarks).Visible = False
            DGL1.Columns(Col1Test_MinMarks).Visible = False

            DGL1.Columns(Col1Exam_MaxMarks).Visible = False
            DGL1.Columns(Col1Exam_MinMarks).Visible = False

            DGL1.Columns(Col1Attendance_MaxMarks).Visible = False
            DGL1.Columns(Col1Attendance_MinMarks).Visible = False

        ElseIf AgL.StrCmp(LblExamType.Tag, ExamNature_Exam) Then
            DGL1.Columns(Col1Test_MaxMarks).Visible = True
            DGL1.Columns(Col1Test_MinMarks).Visible = True

            DGL1.Columns(Col1Assignment_MaxMarks).Visible = True
            DGL1.Columns(Col1Assignment_MinMarks).Visible = True

            DGL1.Columns(Col1Exam_MaxMarks).Visible = True
            DGL1.Columns(Col1Exam_MinMarks).Visible = True

            DGL1.Columns(Col1Attendance_MaxMarks).Visible = True
            DGL1.Columns(Col1Attendance_MinMarks).Visible = True
        Else
            DGL1.Columns(Col1Test_MaxMarks).Visible = False
            DGL1.Columns(Col1Test_MinMarks).Visible = False

            DGL1.Columns(Col1Assignment_MaxMarks).Visible = False
            DGL1.Columns(Col1Assignment_MinMarks).Visible = False

            DGL1.Columns(Col1Exam_MaxMarks).Visible = False
            DGL1.Columns(Col1Exam_MinMarks).Visible = False

            DGL1.Columns(Col1Attendance_MaxMarks).Visible = False
            DGL1.Columns(Col1Attendance_MinMarks).Visible = False
        End If
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

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
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

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Subject
                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        DGL1.Item(Col1SubjectType, mRowIndex).Value = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                DGL1.Item(Col1SubjectType, mRowIndex).Value = AgL.XNull(.Item("SubjectType", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case Col1Exam_MinMarks
                    If DGL1.Item(Col1Exam_MaxMarks, mRowIndex).Value Is Nothing Then DGL1.Item(Col1Exam_MaxMarks, mRowIndex).Value = ""
                    If Val(DGL1.Item(Col1Exam_MinMarks, mRowIndex).Value) > Val(DGL1.Item(Col1Exam_MaxMarks, mRowIndex).Value) Then
                        DGL1.Item(Col1Exam_MinMarks, mRowIndex).Value = ""
                    End If
                Case Col1Test_MinMarks
                    If DGL1.Item(Col1Test_MaxMarks, mRowIndex).Value Is Nothing Then DGL1.Item(Col1Test_MaxMarks, mRowIndex).Value = ""
                    If Val(DGL1.Item(Col1Test_MinMarks, mRowIndex).Value) > Val(DGL1.Item(Col1Test_MaxMarks, mRowIndex).Value) Then
                        DGL1.Item(Col1Test_MinMarks, mRowIndex).Value = ""
                    End If

                Case Col1Assignment_MinMarks
                    If DGL1.Item(Col1Assignment_MaxMarks, mRowIndex).Value Is Nothing Then DGL1.Item(Col1Assignment_MaxMarks, mRowIndex).Value = ""
                    If Val(DGL1.Item(Col1Assignment_MinMarks, mRowIndex).Value) > Val(DGL1.Item(Col1Assignment_MaxMarks, mRowIndex).Value) Then
                        DGL1.Item(Col1Assignment_MinMarks, mRowIndex).Value = ""
                    End If

                Case Col1Attendance_MinMarks
                    If DGL1.Item(Col1Attendance_MaxMarks, mRowIndex).Value Is Nothing Then DGL1.Item(Col1Attendance_MaxMarks, mRowIndex).Value = ""
                    If Val(DGL1.Item(Col1Attendance_MinMarks, mRowIndex).Value) > Val(DGL1.Item(Col1Attendance_MaxMarks, mRowIndex).Value) Then
                        DGL1.Item(Col1Attendance_MinMarks, mRowIndex).Value = ""
                    End If

            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGL1.EditingControlShowing
        If Topctrl1.Mode = "Browse" Then Exit Sub
        If TypeOf e.Control Is ComboBox Then
            e.Control.Text = ""
        End If
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub

        Try
            Select Case sender.CurrentCell.ColumnIndex
                'Case <Dgl_Column>
                '    <Executable Code>
            End Select
        Catch Ex As NullReferenceException
        Catch Ex As Exception
            MsgBox(Ex.Message)
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtSite_Code.Enter, TxtCopyFrom.Enter, TxtStreamYearSemester.Enter, TxtRemark.Enter, TxtStreamYearSemester.Enter, _
        TxtSessionProgramme.Enter, TxtClassSection.Enter, TxtClassSectionSubSection.Enter
        Try
            Select Case sender.name
                Case TxtStreamYearSemester.Name
                    TxtStreamYearSemester.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "

                Case TxtCopyFrom.Name
                    TxtCopyFrom.AgRowFilter = " ExamNature = " & AgL.Chk_Text(LblExamType.Tag.ToString) & " "

                Case TxtClassSectionSubSection.Name
                    TxtClassSectionSubSection.AgRowFilter = " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " "


            End Select
        Catch ex As Exception

        End Try
    End Sub


    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtCopyFrom.Validating, TxtSite_Code.Validating, TxtExamType.Validating, TxtRemark.Validating, TxtStreamYearSemester.Validating, _
        TxtSessionProgramme.Validating, TxtClassSection.Validating, TxtClassSectionSubSection.Validating

        Try
            Select Case sender.name
                Case TxtCopyFrom.Name
                    FillCopyDetail(TxtCopyFrom.AgSelectedValue)

                Case TxtExamType.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblExamType.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblExamType.Tag = AgL.XNull(.Item("Nature", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If
                    Call ProcChangeGridColumnsState()
                    Call ProcFillExamDescription()

                Case TxtStreamYearSemester.Name

                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblStreamYearSemester.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                TxtClassSection.AgSelectedValue = ""
                                TxtClassSectionSubSection.AgSelectedValue = ""
                                LblStreamYearSemester.Tag = AgL.XNull(.Item("SessionProgrammeCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If
                    Call ProcFillExamDescription()
                    Call ProcFillSemester()


                Case TxtClassSection.Name, TxtClassSectionSubSection.Name
                    If TxtClassSection.Text.ToString.Trim = "" Then TxtClassSection.AgSelectedValue = ""
                    If TxtClassSectionSubSection.Text.ToString.Trim = "" Then TxtClassSectionSubSection.AgSelectedValue = ""

                    If TxtClassSection.Text.ToString.Trim <> "" Then TxtStreamYearSemester.AgSelectedValue = ""
                    If TxtClassSectionSubSection.Text.ToString.Trim <> "" Then TxtStreamYearSemester.AgSelectedValue = ""

                    Call ProcFillExamDescription()
                    Call ProcFillSemester()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblStreamYearSemester.Tag) Then
            TxtStreamYearSemester.AgSelectedValue = ""
            LblStreamYearSemester.Tag = ""
        End If

        Call Calculation()
    End Sub


    Sub FillCopyDetail(ByVal bSemesterExamCode As String)
        Dim I As Integer
        Dim DsTemp As DataSet
        Dim mCondStr As String = ""


        If bSemesterExamCode.Trim = "" Then
            Exit Sub
        Else
            If DGL1.RowCount > 1 Then
                If MsgBox("Do you Sure to Copy Detail From -- " & TxtCopyFrom.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If
        End If

       
        mQry = "SELECT E1.*, S.SubjectType " & _
                " FROM Exam_SemesterExam1 E1 " & _
                " Left Join Sch_Subject S On E1.Subject = S.Code " & _
                " WHERE E1.Code ='" & bSemesterExamCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                    DGL1.Rows.Add()
                    DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                    DGL1.AgSelectedValue(Col1Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                    DGL1.Item(Col1SubjectType, I).Value = AgL.XNull(.Rows(I)("SubjectType"))
                    DGL1.Item(Col1Exam_MaxMarks, I).Value = AgL.VNull(.Rows(I)("Exam_MaxMarks"))
                    DGL1.Item(Col1Exam_MinMarks, I).Value = AgL.VNull(.Rows(I)("Exam_MinMarks"))
                    DGL1.Item(Col1Test_MaxMarks, I).Value = AgL.VNull(.Rows(I)("Test_MaxMarks"))
                    DGL1.Item(Col1Test_MinMarks, I).Value = AgL.VNull(.Rows(I)("Test_MinMarks"))
                    DGL1.Item(Col1Assignment_MaxMarks, I).Value = AgL.VNull(.Rows(I)("Assignment_MaxMarks"))
                    DGL1.Item(Col1Assignment_MinMarks, I).Value = AgL.VNull(.Rows(I)("Assignment_MinMarks"))
                    DGL1.Item(Col1Attendance_MaxMarks, I).Value = AgL.VNull(.Rows(I)("Attendance_MaxMarks"))
                    DGL1.Item(Col1Attendance_MinMarks, I).Value = AgL.VNull(.Rows(I)("Attendance_MinMarks"))
                    DGL1.Item(Col1Total_MaxMarks, I).Value = AgL.VNull(.Rows(I)("Total_MaxMarks"))
                    DGL1.Item(Col1Total_MinMarks, I).Value = AgL.VNull(.Rows(I)("Total_MinMarks"))
                Next I
            End If
        End With
    End Sub

    Private Function Data_Validation() As Boolean
        Try
            Dim I As Integer

            Call Calculation()
            Call ProcFillExamDescription()

            If AgL.RequiredField(TxtSession, "Session") Then Exit Function
            If AgL.RequiredField(TxtExamType, "Exam Type") Then Exit Function


            If AgCL.AgCheckMandatory(Me) = False Then Exit Function

            'If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblStreamYearSemester.Tag) Then
            '    MsgBox("Please Select A Valid Semester!...") : TxtStreamYearSemester.Focus() : Exit Function
            'End If


            mQry = "SELECT IsNull(COUNT(*),0) Cnt " & _
                    " FROM Exam_SemesterExam E " & _
                    " WHERE E.StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " AND " & _
                    " E.ExamType = " & AgL.Chk_Text(TxtExamType.AgSelectedValue) & " And " & _
                    " " & IIf(Topctrl1.Mode = "Add", " 1=1 ", " E.Code <> '" & mSearchCode & "' ") & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar() > 0 Then MsgBox("Exam Already Exists!") : TxtExamType.Focus() : Exit Function

            mQry = "SELECT IsNull(COUNT(*),0) Cnt " & _
                 " FROM Exam_SemesterExam E " & _
                 " WHERE E.ClassSection = '" & AgL.XNull(TxtClassSection.AgSelectedValue) & "' AND " & _
                 " isnull(E.ClassSectionSubSection,'') = '" & AgL.XNull(TxtClassSectionSubSection.AgSelectedValue) & "' AND " & _
                 " E.Session = '" & AgL.XNull(TxtSession.AgSelectedValue) & "' AND " & _
                 " E.ExamType = '" & AgL.XNull(TxtExamType.AgSelectedValue) & "' And " & _
                 " " & IIf(Topctrl1.Mode = "Add", " 1=1 ", " E.Code <> '" & mSearchCode & "' ") & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar() > 0 Then MsgBox("Exam Already Exists!") : TxtExamType.Focus() : Exit Function


            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1Subject) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1Subject & "") Then Exit Function

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Subject, I).Value Is Nothing Then .Item(Col1Subject, I).Value = ""
                    If .Item(Col1Subject, I).Value <> "" Then
                        If Val(.Item(Col1Total_MaxMarks, I).Value) <= 0 Then MsgBox("Total Max Marks Is Required For Subject :  " & vbCrLf & "" & .Item(Col1Subject, I).Value & "!...") : DGL1.CurrentCell = DGL1(Col1Subject, I) : DGL1.Focus() : Exit Function
                        If Val(.Item(Col1Total_MinMarks, I).Value) <= 0 Then MsgBox("Total Min Marks Is Required For Subject :  " & vbCrLf & "" & .Item(Col1Subject, I).Value & "!...") : DGL1.CurrentCell = DGL1(Col1Subject, I) : DGL1.Focus() : Exit Function

                        If Val(DGL1.Item(Col1Exam_MinMarks, I).Value) > Val(DGL1.Item(Col1Exam_MaxMarks, I).Value) Then
                            MsgBox("Min Marks Is Greater Than From Max Marks For Subject :  " & vbCrLf & "" & .Item(Col1Subject, I).Value & "!...") : DGL1.CurrentCell = DGL1(Col1Exam_MinMarks, I) : DGL1.Focus() : Exit Function
                        End If

                        If Val(DGL1.Item(Col1Test_MinMarks, I).Value) > Val(DGL1.Item(Col1Test_MaxMarks, I).Value) Then
                            MsgBox("Min Marks Is Greater Than From Max Marks For Subject :  " & vbCrLf & "" & .Item(Col1Subject, I).Value & "!...") : DGL1.CurrentCell = DGL1(Col1Test_MinMarks, I) : DGL1.Focus() : Exit Function
                        End If

                        If Val(DGL1.Item(Col1Assignment_MinMarks, I).Value) > Val(DGL1.Item(Col1Assignment_MaxMarks, I).Value) Then
                            MsgBox("Min Marks Is Greater Than From Max Marks For Subject :  " & vbCrLf & "" & .Item(Col1Subject, I).Value & "!...") : DGL1.CurrentCell = DGL1(Col1Assignment_MinMarks, I) : DGL1.Focus() : Exit Function
                        End If

                        If Val(DGL1.Item(Col1Attendance_MinMarks, I).Value) > Val(DGL1.Item(Col1Attendance_MaxMarks, I).Value) Then
                            MsgBox("Min Marks Is Greater Than From Max Marks For Subject :  " & vbCrLf & "" & .Item(Col1Subject, I).Value & "!...") : DGL1.CurrentCell = DGL1(Col1Attendance_MinMarks, I) : DGL1.Focus() : Exit Function
                        End If

                        If Val(DGL1.Item(Col1Total_MinMarks, I).Value) > Val(DGL1.Item(Col1Total_MaxMarks, I).Value) Then
                            MsgBox("Total Min Marks Is Greater Than From Total Max Marks For Subject :  " & vbCrLf & "" & .Item(Col1Subject, I).Value & "!...") : DGL1.CurrentCell = DGL1(Col1Subject, I) : DGL1.Focus() : Exit Function
                        End If

                    End If
                Next
            End With


            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetMaxId("Exam_SemesterExam", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub


        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Subject, I).Value Is Nothing Then .Item(Col1Subject, I).Value = ""

                If .Item(Col1Subject, I).Value <> "" Then
                    If AgL.StrCmp(LblExamType.Tag, ExamNature_Test) Then
                        .Item(Col1Exam_MaxMarks, I).Value = ""
                        .Item(Col1Exam_MinMarks, I).Value = ""

                        .Item(Col1Assignment_MaxMarks, I).Value = ""
                        .Item(Col1Assignment_MinMarks, I).Value = ""

                        .Item(Col1Attendance_MaxMarks, I).Value = ""
                        .Item(Col1Attendance_MinMarks, I).Value = ""

                    ElseIf AgL.StrCmp(LblExamType.Tag, ExamNature_Assignment) Then
                        .Item(Col1Test_MaxMarks, I).Value = ""
                        .Item(Col1Test_MinMarks, I).Value = ""

                        .Item(Col1Exam_MaxMarks, I).Value = ""
                        .Item(Col1Exam_MinMarks, I).Value = ""

                        .Item(Col1Attendance_MaxMarks, I).Value = ""
                        .Item(Col1Attendance_MinMarks, I).Value = ""

                    End If

                    .Item(Col1Total_MaxMarks, I).Value = Val(.Item(Col1Exam_MaxMarks, I).Value) + Val(.Item(Col1Test_MaxMarks, I).Value) + Val(.Item(Col1Assignment_MaxMarks, I).Value) + Val(.Item(Col1Attendance_MaxMarks, I).Value)
                    .Item(Col1Total_MinMarks, I).Value = Val(.Item(Col1Exam_MinMarks, I).Value) + Val(.Item(Col1Test_MinMarks, I).Value) + Val(.Item(Col1Assignment_MinMarks, I).Value) + Val(.Item(Col1Attendance_MinMarks, I).Value)

                End If
            Next
        End With
    End Sub

    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            Select Case sender.name
                Case BtnFill.Name
                    If MsgBox("Are You Sure To Fill Subject!...", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
                    Call ProcFillSubject()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillSubject()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim mCondStr = ""
        Dim bStrViewClassSectionSemesterAdmission$ = "", bStrViewOpenElectiveSemesterAdmission$ = "", bStrTempViewSectionAdmission$ = ""
        Dim bBlnIsOpenElectiveSection As Boolean = False
        Try
            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            'Code by Akash on Date 22-9-10
            If ChkTheory.Checked = False And ChkPractical.Checked = False Then MsgBox("Please select any subject type.", MsgBoxStyle.Information) : Exit Sub
            If ChkTheory.Checked = False Then mCondStr += " AND s.SubjectType <> 'Theory'"
            If ChkPractical.Checked = False Then mCondStr += " AND s.SubjectType <> 'Practical'"
            If ChkGenProf.Checked = False Then mCondStr += " AND IsNull(s.IsGeneralProficiency,0) = 0 "
            'End Code

            '*********************************************************************************
            If TxtClassSection.Text.Trim <> "" Then
                bStrViewClassSectionSemesterAdmission = "SELECT vCsa3.* " & _
                                                  " FROM (SELECT vCsa1.* FROM ViewSch_ClassSectionSemesterAdmission vCsa1 " & _
                                                  " INNER JOIN " & _
                                                  " (SELECT vCsa.ClassSection , Max(vCsa.SemesterStartDate) AS SemesterStartDate " & _
                                                  " FROM ViewSch_ClassSectionSemesterAdmission vCsa  " & _
                                                  " GROUP BY vCsa.ClassSection  " & _
                                                  " ) vCsa2 ON vCsa1.ClassSection = vCsa2.ClassSection AND vCsa1.SemesterStartDate = vCsa2.SemesterStartDate) vCsa3 " & _
                                                  " WHERE vCsa3.SectionLeftOnDate IS NULL "

                bStrViewOpenElectiveSemesterAdmission = "SELECT vOCsa3.* " & _
                                                        " FROM (SELECT vOCsa1.* FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa1 " & _
                                                        " INNER JOIN " & _
                                                        " (SELECT vOCsa.ClassSection , Max(vOCsa.SemesterStartDate) AS SemesterStartDate " & _
                                                        " FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa  " & _
                                                        " GROUP BY vOCsa.ClassSection  " & _
                                                        " ) vOCsa2 ON vOCsa1.ClassSection = vOCsa2.ClassSection AND vOCsa1.SemesterStartDate = vOCsa2.SemesterStartDate) vOCsa3 " & _
                                                        " WHERE vOCsa3.SectionLeftOnDate IS NULL "



                mQry = "SELECT S.IsOpenElectiveSection FROM Sch_ClassSection S WHERE S.Code = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & "  "
                bBlnIsOpenElectiveSection = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)

                If bBlnIsOpenElectiveSection Then
                    bStrTempViewSectionAdmission = bStrViewOpenElectiveSemesterAdmission
                Else
                    bStrTempViewSectionAdmission = bStrViewClassSectionSemesterAdmission
                End If

                mCondStr += " AND   " & AgL.PubSiteCondition("Csa.Site_Code", TxtSite_Code.AgSelectedValue) & " And " & _
                       " Csa.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ""


                If TxtClassSectionSubSection.Text.Trim <> "" Then
                    mCondStr += " And Csa.ClassSectionSubSectionCode = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " "
                End If

            End If

            '****************************************************************
            If TxtClassSection.Text.Trim <> "" Then
                mQry = "SELECT DISTINCT S1.Subject, S.SubjectType,S.Description " & _
                       " FROM (" & bStrTempViewSectionAdmission & ") Csa " & _
                       " LEFT JOIN ViewSch_Admission V1 ON V1.DocId = Csa.AdmissionDocId  " & _
                       " LEFT JOIN Sch_SemesterSubject S1 ON V1.CurrentSemester = S1.StreamYearSemester " & _
                       " LEFT JOIN Sch_Subject S ON S1.Subject = S.Code " & _
                       " Where " & AgL.PubSiteCondition("V1.Site_Code", TxtSite_Code.AgSelectedValue) & "  " & _
                       " " & mCondStr & "  And" & _
                       " V1.LeavingDate IS NULL " & _
                       " Order By S.Description "
            ElseIf TxtStreamYearSemester.Text.Trim <> "" Then
                mQry = "SELECT S1.Subject, S.SubjectType " & _
                        " FROM Sch_SemesterSubject S1 " & _
                        " LEFT JOIN Sch_Subject S ON S1.Subject = S.Code " & _
                        " WHERE S1.StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " " & mCondStr & _
                        " Order By S.Description "

            End If

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                        DGL1.Item(Col1SubjectType, I).Value = AgL.XNull(.Rows(I)("SubjectType"))
                    Next I
                Else
                    MsgBox("Please Define Subjects For " & TxtStreamYearSemester.Text & "")
                    Exit Sub
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DtTemp = Nothing
        End Try
    End Sub
    Private Sub ProcFillExamDescription()
        Try
            If TxtStreamYearSemester.Text.ToString.Trim <> "" And TxtExamType.Text.ToString.Trim <> "" Then
                TxtExamDescription.Text = TxtStreamYearSemester.Text + "/" + TxtExamType.Text
            ElseIf TxtClassSection.Text.ToString.Trim <> "" And TxtExamType.Text.ToString.Trim <> "" Then
                TxtExamDescription.Text = IIf(TxtClassSectionSubSection.Text <> "", TxtClassSection.Text + "/" + TxtClassSectionSubSection.Text + "/" + TxtSession.Text + "/" + TxtExamType.Text, TxtClassSection.Text + "/" + TxtSession.Text + "/" + TxtExamType.Text)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub ProcFillSemester()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim mCondStr = ""
        Dim DrTemp As DataRow() = Nothing
        Dim bStrViewClassSectionSemesterAdmission$ = "", bStrViewOpenElectiveSemesterAdmission$ = "", bStrTempViewSectionAdmission$ = ""
        Dim bBlnIsOpenElectiveSection As Boolean = False
        Try

            If TxtClassSection.Text.Trim <> "" Then
                bStrViewClassSectionSemesterAdmission = "SELECT vCsa3.* " & _
                                                  " FROM (SELECT vCsa1.* FROM ViewSch_ClassSectionSemesterAdmission vCsa1 " & _
                                                  " INNER JOIN " & _
                                                  " (SELECT vCsa.ClassSection , Max(vCsa.SemesterStartDate) AS SemesterStartDate " & _
                                                  " FROM ViewSch_ClassSectionSemesterAdmission vCsa  " & _
                                                  " GROUP BY vCsa.ClassSection  " & _
                                                  " ) vCsa2 ON vCsa1.ClassSection = vCsa2.ClassSection AND vCsa1.SemesterStartDate = vCsa2.SemesterStartDate) vCsa3 " & _
                                                  " WHERE vCsa3.SectionLeftOnDate IS NULL "

                bStrViewOpenElectiveSemesterAdmission = "SELECT vOCsa3.* " & _
                                                        " FROM (SELECT vOCsa1.* FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa1 " & _
                                                        " INNER JOIN " & _
                                                        " (SELECT vOCsa.ClassSection , Max(vOCsa.SemesterStartDate) AS SemesterStartDate " & _
                                                        " FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa  " & _
                                                        " GROUP BY vOCsa.ClassSection  " & _
                                                        " ) vOCsa2 ON vOCsa1.ClassSection = vOCsa2.ClassSection AND vOCsa1.SemesterStartDate = vOCsa2.SemesterStartDate) vOCsa3 " & _
                                                        " WHERE vOCsa3.SectionLeftOnDate IS NULL "



                mQry = "SELECT S.IsOpenElectiveSection FROM Sch_ClassSection S WHERE S.Code = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & "  "
                bBlnIsOpenElectiveSection = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)

                If bBlnIsOpenElectiveSection Then
                    bStrTempViewSectionAdmission = bStrViewOpenElectiveSemesterAdmission
                Else
                    bStrTempViewSectionAdmission = bStrViewClassSectionSemesterAdmission
                End If

                mCondStr = "   " & AgL.PubSiteCondition("Csa.Site_Code", TxtSite_Code.AgSelectedValue) & " And " & _
                       " Csa.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ""


                If TxtClassSectionSubSection.Text.Trim <> "" Then
                    mCondStr += " And Csa.ClassSectionSubSectionCode = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " "
                End If

            End If

            If TxtClassSection.Text.Trim <> "" Then
                mQry = "SELECT V1.CurrentSemester  " & _
                       " FROM (" & bStrTempViewSectionAdmission & ") Csa " & _
                       " LEFT JOIN ViewSch_Admission V1 ON V1.DocId = Csa.AdmissionDocId  " & _
                       " Where " & AgL.PubSiteCondition("V1.Site_Code", TxtSite_Code.AgSelectedValue) & " And " & _
                       " " & mCondStr & "  And" & _
                       " V1.LeavingDate IS NULL " & _
                       " Group By V1.CurrentSemester " & _
                       " Order By V1.CurrentSemester "
                DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                With DtTemp
                    DGL2.RowCount = 1 : DGL2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col2SNo, I).Value = DGL2.Rows.Count
                            DGL2.AgSelectedValue(Col2StreamYearSemester, I) = AgL.XNull(.Rows(I)("CurrentSemester"))
                            DrTemp = DGL2.AgHelpDataSet(Col2StreamYearSemester).Tables(0).Select("Code = " & AgL.Chk_Text(DGL2.AgSelectedValue(Col2StreamYearSemester, I)) & "")
                            DGL2.Item(Col2Session, I).Value = AgL.XNull(DrTemp(0)("SessionCode"))
                            DGL2.Item(Col2Program, I).Value = AgL.XNull(DrTemp(0)("ProgrammeCode"))
                            DGL2.Item(Col2Stream, I).Value = AgL.XNull(DrTemp(0)("StreamCode"))
                            DGL2.Item(Col2Semester, I).Value = AgL.XNull(DrTemp(0)("Semester"))
                        Next I
                    End If
                End With
            ElseIf TxtStreamYearSemester.Text.Trim <> "" Then
                DGL2.RowCount = 1 : DGL2.Rows.Clear()
                DGL2.Rows.Add()
                DGL2.Item(Col2SNo, 0).Value = DGL2.Rows.Count
                DGL2.AgSelectedValue(Col2StreamYearSemester, 0) = AgL.XNull(TxtStreamYearSemester.AgSelectedValue)
                DrTemp = DGL2.AgHelpDataSet(Col2StreamYearSemester).Tables(0).Select("Code = " & AgL.Chk_Text(DGL2.AgSelectedValue(Col2StreamYearSemester, I)) & "")
                DGL2.Item(Col2Session, I).Value = AgL.XNull(DrTemp(0)("SessionCode"))
                DGL2.Item(Col2Program, I).Value = AgL.XNull(DrTemp(0)("ProgrammeCode"))
                DGL2.Item(Col2Stream, I).Value = AgL.XNull(DrTemp(0)("StreamCode"))
                DGL2.Item(Col2Semester, I).Value = AgL.XNull(DrTemp(0)("Semester"))
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class
