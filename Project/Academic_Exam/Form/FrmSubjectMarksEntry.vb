Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmSubjectMarksEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Dim mSubjectHelpFlag As Boolean = False

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1SemesterExamAdmission1 As Byte = 1
    Private Const Col1AdmissionID As Byte = 2
    Private Const Col1PresentStatus As Byte = 3
    Private Const Col1MarksObtain As Byte = 4
    Private Const Col1GraceMarks As Byte = 5
    Private Const Col1TotalMarks As Byte = 6
    Private Const Col1Result As Byte = 7
    Private Const Col1AdmissionDocId As Byte = 8

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
        ''================< Student Data Grid >====================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1SemesterExamAdmission1", 280, 8, "Student", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionId", 180, 8, "Admission ID", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1PresentStatus", 60, 20, "Present/ Absent", True, False, False)
            .AddAgNumberColumn(DGL1, "Dgl1MarksObtain", 70, 3, 3, False, "Marks Obtained", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1GraceMarks", 70, 3, 3, False, "Grace Marks", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1TotalMarks", 70, 3, 3, False, "Total Marks", True, True, True)
            .AddAgTextColumn(DGL1, "DGL1Result", 100, 20, "Result", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionDocId", 210, 8, "AdmissionDocId", False, True, False)
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
            AgL.WinSetting(Me, 650, 950, 0, 0)
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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("A.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
                mCondStr += " And A.PreparedBy = '" & AgL.PubUserName & "' "
            End If

            mQry = "Select A.DocId As SearchCode " & _
                    " From Exam_SubjectMarks A " & _
                    " LEFT JOIN Voucher_Type Vt ON A.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
              " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_SubjectMarksEntry) & "" & _
              " Order By Description "
        TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT P.Code, P.SessionProgramme AS Name  " & _
                " FROM ViewSch_SessionProgramme P " & _
                " Where " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By P.SessionProgramme"
        TxtSessionProgramme.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Sem.Code, Sem.StreamYearSemesterDesc as Name, Sem.SessionProgrammeCode " & _
                " FROM ViewSch_StreamYearSemester Sem " & _
                " Where " & AgL.PubSiteCondition("Sem.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By Sem.StreamYearSemesterDesc"
        TxtStreamYearSemester.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT E.Code , E.SemesterExamDesc [Semester Exam], E.ExamNature, " & _
                " E.SessionProgrammeCode , E.StreamYearSemester  StreamYearSemesterCode, E.ClassSection,E.ClassSectionSubSection , E.Session, " & _
                " E.ExamType AS ExamTypeCode " & _
                " FROM ViewExam_SemesterExam E " & _
                " Where " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY E.SemesterExamDesc "
        TxtSemesterExam.AgHelpDataSet(7) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.Code, S.ClassSectionDesc, S.SessionProgramme As SessionProgrammeCode  " & _
                " FROM ViewSch_ClassSection S " & _
                " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY S.ClassSectionDesc "
        TxtClassSection.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.Code , S.SubSection, S.ClassSection " & _
                " FROM ViewSch_ClassSectionSubSection S " & _
                " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY S.ClassSectionSubSectionDesc"
        TxtClassSectionSubSection.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT A1.Code, V1.StudentName, V1.AdmissionID, A1.AdmissionDocId, V1.Student As StudentCode " & _
                " FROM Exam_SemesterExamAdmission1 A1 " & _
                " LEFT JOIN ViewSch_Admission V1 ON A1.AdmissionDocId = V1.DocId  " & _
                " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By V1.StudentName "
        DGL1.AgHelpDataSet(Col1SemesterExamAdmission1, 2) = AgL.FillData(mQry, AgL.GCn)

        AgCL.IniAgHelpList(TxtExamNature, PubExamNatureStr)

        mQry = "Select '" & ClsMain.ExamPresentStatus.Present & "' As Code, '" & ClsMain.ExamPresentStatus.Present & "' As Name " & _
                " UNION ALL " & _
                "Select '" & ClsMain.ExamPresentStatus.Absent & "' As Code, '" & ClsMain.ExamPresentStatus.Absent & "' As Name "
        DGL1.AgHelpDataSet(Col1PresentStatus) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.Code, S.ManualCode AS Session " & _
                 " FROM Sch_Session S " & _
                 " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                 " Order By S.ManualCode "
        TxtSession.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)


        Call IniSubjectHelp()
    End Sub

    Private Sub IniSubjectHelp(Optional ByVal bAllRecords As Boolean = True)
        mQry = ""
        If bAllRecords Then
            If mSubjectHelpFlag = False Then               
                mQry = "Select S.Code  As Code, S.Description As Name, S.SubjectType, " & _
                        " Null As ExamType, Null As ExamNature, 0 As Exam_MaxMarks, 0 As Exam_MinMarks, " & _
                        " 0 As Test_MaxMarks, 0 As Test_MinMarks, 0 As Assignment_MaxMarks, 0 As Assignment_MinMarks, " & _
                        " 0 As Attendance_MaxMarks, 0 As Attendance_MinMarks, 0 As Total_MaxMarks, 0 As Total_MinMarks  " & _
                        " From Sch_Subject S " & _
                        " Order By S.Description "

                mSubjectHelpFlag = True
            End If
        Else
            mSubjectHelpFlag = False

            mQry = "SELECT E1.Subject As Code, S.Description As Name, S.SubjectType, " & _
                    " V2.ExamType, V2.ExamNature, E1.Exam_MaxMarks, E1.Exam_MinMarks, " & _
                    " E1.Test_MaxMarks, E1.Test_MinMarks, E1.Assignment_MaxMarks, E1.Assignment_MinMarks, " & _
                    " E1.Attendance_MaxMarks, E1.Attendance_MinMarks, E1.Total_MaxMarks, E1.Total_MinMarks  " & _
                    " FROM ViewExam_SemesterExam V2 " & _
                    " LEFT JOIN Exam_SemesterExam1 E1 ON V2.Code = E1.Code  " & _
                    " LEFT JOIN Sch_Subject S ON E1.Subject = S.Code  " & _
                    " WHERE V2.Code = " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & " " & _
                    " ORDER BY S.Description "
        End If

        If mQry.Trim <> "" Then TxtSubject.AgHelpDataSet(12) = AgL.FillData(mQry, AgL.GCn)

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


                    AgL.Dman_ExecuteNonQry("Delete From Exam_SubjectMarks1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Exam_SubjectMarks Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        TxtV_Date.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("A.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
                mCondStr += " And A.PreparedBy = '" & AgL.PubUserName & "' "
            End If

            AgL.PubFindQry = "SELECT A.DocId As SearchCode, " & AgL.V_No_Field("A.DocId") & " As [Voucher No], " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], A.V_Date, " & _
                                " E.SemesterExamDesc As [Semester/Exam], Sub.Description As Subject, " & _
                                " Case When IsNull(IsAttendanceMarks,0) = 0 Then 'No' Else 'Yes' End As [Attendance Marks], " & _
                                " E.StreamYearSemesterDesc As Semester, CSec.ClassSectionDesc AS [Section], SubSec.SubSection, A.PreparedBy , A.ModifiedBy " & _
                                " FROM Exam_SubjectMarks A " & _
                                " LEFT JOIN Voucher_Type Vt ON A.V_Type = Vt.V_Type " & _
                                " LEFT JOIN SiteMast S ON A.Site_Code = S.Code " & _
                                " Left Join Sch_Subject Sub On A.Subject = Sub.Code " & _
                                " LEFT JOIN ViewExam_SemesterExam E ON A.SemesterExam = E.Code " & _
                                " LEFT JOIN ViewSch_ClassSection CSec ON A.ClassSection = CSec.Code " & _
                                " LEFT JOIN Sch_ClassSectionSubSection SubSec ON SubSec.Code = A.ClassSectionSubSection " & mCondStr

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
        mSubjectHelpFlag = False

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

            AgL.PubReportTitle = "Subject Marks Entry"
            RepName = "Exam_Subject_Marks_Entry" : RepTitle = "Subject Marks Entry"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " Select A.v_date," & AgL.V_No_Field("a.DocId") & " As VoucherNo,a.V_No,a.MaxMarks,a.MinMarks,a.PreparedBy,v2.SemesterExamDesc, " & _
                     " v2.StreamYearSemesterdesc,V1.StudentName,  V1.AdmissionID, Sch_Subject.Description AS subject,a1.MarksObtain,a1.GraceMarks,a1.TotalMarks, " & _
                     " a1.Result, Vt.NCat, V2.SessionProgrammeCode, V2.StreamYearSemester, V2.ExamNature,v2.ExamTypeDesc,a.Remark, A.IsAttendanceMarks " & _
                     " From Exam_SubjectMarks A " & _
                     " LEFT JOIN Exam_SubjectMarks1 a1 on a.DocId=a1.docid " & _
                     " LEFT JOIN Exam_SemesterExamAdmission1 ESEA ON a1.SemesterExamAdmission1=esea.Code " & _
                     " LEFT JOIN ViewSch_Admission V1 ON esea.AdmissionDocId = V1.DocId   " & _
                     " Left Join Voucher_Type Vt On A.V_Type = Vt.V_Type " & _
                     " Left Join ViewExam_SemesterExam V2 On A.SemesterExam = V2.Code  " & _
                     " LEFT JOIN Sch_Subject ON a.Subject=Sch_Subject.code " & _
                     " Where A.DocId='" & mDocId & "'"


            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Exam & "\" & RepName & ".ttx", True)
            mCrd.Load(PLib.PubReportPath_Exam & "\" & RepName & ".rpt")
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
        Dim I As Integer, bSr As Integer
        Dim mTrans As Boolean = False
        Dim bSemesterExamAdmission1$ = ""

        Dim GcnRead As SqlClient.SqlConnection

        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Exam_SubjectMarks (DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, " & _
                        " SemesterExam, Subject, MaxMarks, MinMarks, Remark, IsAttendanceMarks, ClassSection, ClassSectionSubSection, " & _
                        " PreparedBy, U_EntDt, U_AE, Session ) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & "," & _
                        " " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & ", " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ", " & _
                        " " & Val(TxtMaxMarks.Text) & ", " & Val(TxtMinMarks.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & IIf(AgL.StrCmp(TxtIsAttendanceMarks.Text, "Yes"), 1, 0) & ", " & _
                        " " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A', " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ") "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Exam_SubjectMarks " & _
                        " SET  " & _
                        " 	V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " 	SemesterExam = " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & ", " & _
                        " 	Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ", " & _
                        "   MaxMarks = " & Val(TxtMaxMarks.Text) & ", " & _
                        "   MinMarks = " & Val(TxtMinMarks.Text) & ", " & _
                        " 	Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        "   IsAttendanceMarks = " & IIf(AgL.StrCmp(TxtIsAttendanceMarks.Text, "Yes"), 1, 0) & "," & _
                        "   ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & _
                        "   ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & ", " & _
                        " 	U_AE = 'E', " & _
                        "   Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ", " & _
                        " 	Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " 	ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & mSearchCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Exam_SubjectMarks1 Where DocId='" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1AdmissionDocId, I).Value <> "" Then
                        bSr += 1

                        mQry = "INSERT INTO Exam_SubjectMarks1 ( DocId, Sr, SemesterExamAdmission1, MarksObtain, " & _
                                " GraceMarks, TotalMarks, Result, PresentStatus ) " & _
                                " VALUES ( " & _
                                " " & AgL.Chk_Text(mSearchCode) & ", " & bSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1SemesterExamAdmission1, I)) & ", " & _
                                " " & Val(.Item(Col1MarksObtain, I).Value) & ", " & Val(.Item(Col1GraceMarks, I).Value) & ", " & Val(.Item(Col1TotalMarks, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Result, I).Value) & ", " & AgL.Chk_Text(.Item(Col1PresentStatus, I).Value) & " " & _
                                " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With


            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
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

                mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

                Topctrl1.FButtonClick(0)

                If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Call PrintDocument(mDocId)
                End If

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

            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim MastPos As Long
        Dim I As Integer
        Dim bStreamYearSemester$ = ""

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
                Call IniSubjectHelp()

                mQry = "Select A.*, Vt.NCat, V2.SessionProgrammeCode, V2.StreamYearSemester, V2.ExamNature " & _
                        " From Exam_SubjectMarks A " & _
                        " Left Join Voucher_Type Vt On A.V_Type = Vt.V_Type " & _
                        " Left Join ViewExam_SemesterExam V2 On A.SemesterExam = V2.Code " & _
                        " " & _
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

                        TxtIsAttendanceMarks.Text = IIf(AgL.VNull(.Rows(0)("IsAttendanceMarks")), "Yes", "No")
                        TxtExamNature.Text = AgL.XNull(.Rows(0)("ExamNature"))
                        TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgrammeCode"))

                        TxtStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        LblStreamYearSemester.Tag = AgL.XNull(.Rows(0)("SessionProgrammeCode"))

                        TxtSemesterExam.AgSelectedValue = AgL.XNull(.Rows(0)("SemesterExam"))
                        LblSemesterExam.Tag = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        LblSemesterExamReq.Tag = AgL.XNull(.Rows(0)("ExamNature"))

                        TxtClassSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSection"))
                        LblClassSection.Tag = AgL.XNull(.Rows(0)("SessionProgrammeCode"))

                        TxtClassSectionSubSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSectionSubSection"))
                        LblClassSectionSubSection.Tag = AgL.XNull(.Rows(0)("ClassSection"))

                        TxtSubject.AgSelectedValue = AgL.XNull(.Rows(0)("Subject"))
                        TxtMaxMarks.Text = AgL.VNull(.Rows(0)("MaxMarks"))
                        TxtMinMarks.Text = AgL.VNull(.Rows(0)("MinMarks"))
                        TxtSession.AgSelectedValue = AgL.XNull(.Rows(0)("Session"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "SELECT Count(SemesterExamAdmission1) AS TotalStudent, Result " & _
                        " FROM Exam_SubjectMarks1 Sm1 " & _
                        " WHERE Sm1.DocId = '" & mSearchCode & "' " & _
                        " GROUP BY Sm1.Result "
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            If AgL.StrCmp(ResultStr_Pass, AgL.XNull(.Rows(I)("Result"))) Then
                                TxtTotalPassStudent.Text = AgL.VNull(.Rows(I)("TotalStudent"))

                            ElseIf AgL.StrCmp(ResultStr_PassWithGrace, AgL.XNull(.Rows(I)("Result"))) Then
                                TxtTotalPassWithGraceStudent.Text = AgL.VNull(.Rows(I)("TotalStudent"))

                            ElseIf AgL.StrCmp(ResultStr_Fail, AgL.XNull(.Rows(I)("Result"))) Then
                                TxtTotalFailStudent.Text = AgL.VNull(.Rows(I)("TotalStudent"))
                            End If
                        Next
                    End If
                End With
                TxtTotalStudent.Text = Val(TxtTotalPassStudent.Text) + Val(TxtTotalPassWithGraceStudent.Text) + Val(TxtTotalFailStudent.Text)

                mQry = "Select A1.*, Ea1.AdmissionDocId, V1.AdmissionID  " & _
                        " From Exam_SubjectMarks1 A1 " & _
                        " Left Join Exam_SemesterExamAdmission1 Ea1 On A1.SemesterExamAdmission1 = Ea1.Code " & _
                        " LEFT JOIN ViewSch_Admission V1 ON Ea1.AdmissionDocId = V1.DocId " & _
                        " Where A1.DocId = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1SemesterExamAdmission1, I) = AgL.XNull(.Rows(I)("SemesterExamAdmission1"))
                            DGL1.Item(Col1AdmissionDocId, I).Value = AgL.XNull(.Rows(I)("AdmissionDocId"))
                            DGL1.Item(Col1AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))
                            DGL1.Item(Col1PresentStatus, I).Value = AgL.XNull(.Rows(I)("PresentStatus"))
                            DGL1.Item(Col1MarksObtain, I).Value = AgL.VNull(.Rows(I)("MarksObtain"))
                            DGL1.Item(Col1GraceMarks, I).Value = AgL.VNull(.Rows(I)("GraceMarks"))
                            DGL1.Item(Col1TotalMarks, I).Value = AgL.VNull(.Rows(I)("TotalMarks"))
                            DGL1.Item(Col1Result, I).Value = AgL.XNull(.Rows(I)("Result"))
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
        mSearchCode = "" : LblPrefix.Text = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()

        TxtIsAttendanceMarks.Text = "No"

        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        BtnFill.Enabled = Enb

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False

            TxtExamNature.Enabled = False
            TxtIsAttendanceMarks.Enabled = False
            TxtSessionProgramme.Enabled = False
            TxtStreamYearSemester.Enabled = False
            TxtSemesterExam.Enabled = False
            TxtSubject.Enabled = False
            TxtClassSection.Enabled = False
            TxtClassSectionSubSection.Enabled = False
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
                Case Col1SemesterExamAdmission1
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

    Private Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            If DGL1.Item(Col1PresentStatus, mRowIndex).Value Is Nothing Then DGL1.Item(Col1PresentStatus, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1MarksObtain
                    If AgL.StrCmp(DGL1.Item(Col1PresentStatus, mRowIndex).Value.ToString, ClsMain.ExamPresentStatus.Absent) Then
                        DGL1.Item(Col1MarksObtain, mRowIndex).Value = ""
                    Else
                        If Val(DGL1.Item(Col1MarksObtain, mRowIndex).Value) > Val(TxtMaxMarks.Text) Then
                            DGL1.Item(Col1MarksObtain, mRowIndex).Value = ""
                        End If
                    End If

                Case Col1GraceMarks
                    If DGL1.Item(Col1MarksObtain, mRowIndex).Value Is Nothing Then DGL1.Item(Col1MarksObtain, mRowIndex).Value = ""

                    If AgL.StrCmp(DGL1.Item(Col1PresentStatus, mRowIndex).Value.ToString, ClsMain.ExamPresentStatus.Absent) Then
                        DGL1.Item(Col1GraceMarks, mRowIndex).Value = ""
                    Else
                        If Val(DGL1.Item(Col1GraceMarks, mRowIndex).Value) > Val(DGL1.Item(Col1MarksObtain, mRowIndex).Value) Then
                            DGL1.Item(Col1GraceMarks, mRowIndex).Value = ""
                        End If

                        If Val(DGL1.Item(Col1MarksObtain, mRowIndex).Value) = 0 And Val(DGL1.Item(Col1GraceMarks, mRowIndex).Value) > 0 Then
                            DGL1.Item(Col1GraceMarks, mRowIndex).Value = ""

                        ElseIf Val(DGL1.Item(Col1MarksObtain, mRowIndex).Value) > Val(TxtMinMarks.Text) And Val(DGL1.Item(Col1GraceMarks, mRowIndex).Value) > 0 Then
                            DGL1.Item(Col1GraceMarks, mRowIndex).Value = ""

                        ElseIf Val(DGL1.Item(Col1GraceMarks, mRowIndex).Value) >= Val(DGL1.Item(Col1MarksObtain, mRowIndex).Value) And Val(DGL1.Item(Col1GraceMarks, mRowIndex).Value) > 0 Then
                            DGL1.Item(Col1GraceMarks, mRowIndex).Value = ""

                        ElseIf (Val(DGL1.Item(Col1GraceMarks, mRowIndex).Value) + Val(DGL1.Item(Col1MarksObtain, mRowIndex).Value)) > Val(TxtMinMarks.Text) And Val(DGL1.Item(Col1GraceMarks, mRowIndex).Value) > 0 Then
                            DGL1.Item(Col1GraceMarks, mRowIndex).Value = ""
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
        TxtV_Type.Enter, TxtSite_Code.Enter, TxtRemark.Enter, TxtV_Date.Enter, TxtV_No.Enter, TxtSubject.Enter, _
         TxtSemesterExam.Enter, TxtStreamYearSemester.Enter, TxtDocId.Enter, TxtSessionProgramme.Enter, TxtExamNature.Enter, _
         TxtMaxMarks.Enter, TxtMinMarks.Enter, TxtClassSection.Enter, TxtClassSectionSubSection.Enter

        Try
            Select Case sender.name
                Case TxtStreamYearSemester.Name
                    TxtStreamYearSemester.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "

                Case TxtSemesterExam.Name
                    If TxtStreamYearSemester.Text.ToString.Trim <> "" Then
                        TxtSemesterExam.AgRowFilter = " StreamYearSemesterCode = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " And ExamNature = " & AgL.Chk_Text(TxtExamNature.Text) & " "
                    End If
                    If TxtClassSection.Text.ToString.Trim <> "" Then
                        TxtSemesterExam.AgRowFilter = IIf(TxtClassSectionSubSection.Text.ToString.Trim <> "", " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " And ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " And Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & "  And ExamNature = " & AgL.Chk_Text(TxtExamNature.Text) & "", " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " And Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & "  And ExamNature = " & AgL.Chk_Text(TxtExamNature.Text) & "")
                    End If


                Case TxtSubject.Name
                    Call IniSubjectHelp(False)

                    'Case TxtClassSection.Name
                    '    TxtClassSection.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "

                Case TxtClassSectionSubSection.Name
                    TxtClassSectionSubSection.AgRowFilter = " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " "


            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtDocId.Validating, TxtV_Date.Validating, _
        TxtRemark.Validating, TxtSemesterExam.Validating, TxtStreamYearSemester.Validating, TxtExamNature.Validating, _
        TxtSessionProgramme.Validating, TxtDocId.Validating, TxtSubject.Validating, TxtMaxMarks.Validating, TxtMinMarks.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing

        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblV_Type.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblV_Type.Tag = AgL.XNull(.Item("NCat", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate

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

                Case TxtSemesterExam.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblSemesterExam.Tag = ""
                        LblSemesterExamReq.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblSemesterExam.Tag = AgL.XNull(.Item("StreamYearSemesterCode", .CurrentCell.RowIndex).Value)
                                LblSemesterExamReq.Tag = AgL.XNull(.Item("ExamNature", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtClassSection.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        sender.AgSelectedValue = ""
                        LblClassSection.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            LblClassSection.Tag = AgL.XNull(DrTemp(0)("SessionProgrammeCode"))
                        End If
                    End If

                Case TxtClassSectionSubSection.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        sender.AgSelectedValue = ""
                        LblClassSectionSubSection.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            LblClassSectionSubSection.Tag = AgL.XNull(DrTemp(0)("ClassSection"))
                        End If
                    End If


                Case TxtSubject.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtMaxMarks.Text = ""
                        TxtMinMarks.Text = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                If AgL.StrCmp(TxtIsAttendanceMarks.Text, "Yes") Then
                                    TxtMaxMarks.Text = AgL.VNull(.Item("Attendance_MaxMarks", .CurrentCell.RowIndex).Value)
                                    TxtMinMarks.Text = AgL.VNull(.Item("Attendance_MinMarks", .CurrentCell.RowIndex).Value)
                                Else
                                    Select Case TxtExamNature.Text
                                        Case ExamNature_Exam
                                            TxtMaxMarks.Text = AgL.VNull(.Item("Exam_MaxMarks", .CurrentCell.RowIndex).Value)
                                            TxtMinMarks.Text = AgL.VNull(.Item("Exam_MinMarks", .CurrentCell.RowIndex).Value)

                                        Case ExamNature_Test
                                            TxtMaxMarks.Text = AgL.VNull(.Item("Test_MaxMarks", .CurrentCell.RowIndex).Value)
                                            TxtMinMarks.Text = AgL.VNull(.Item("Test_MinMarks", .CurrentCell.RowIndex).Value)

                                        Case ExamNature_Assignment
                                            TxtMaxMarks.Text = AgL.VNull(.Item("Assignment_MaxMarks", .CurrentCell.RowIndex).Value)
                                            TxtMinMarks.Text = AgL.VNull(.Item("Assignment_MinMarks", .CurrentCell.RowIndex).Value)

                                        Case Else
                                            TxtMaxMarks.Text = ""
                                            TxtMinMarks.Text = ""
                                    End Select
                                End If
                            End With
                        End If
                    End If


            End Select

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblStreamYearSemester.Tag) Then
                TxtStreamYearSemester.AgSelectedValue = ""
                LblStreamYearSemester.Tag = ""
            End If

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblClassSection.Tag) And LblClassSection.Tag.ToString.Trim <> "" Then
                TxtClassSection.AgSelectedValue = ""
                LblClassSection.Tag = ""
            End If

            If Not AgL.StrCmp(TxtClassSection.AgSelectedValue, LblClassSectionSubSection.Tag) And LblClassSectionSubSection.Tag.ToString.Trim <> "" Then
                TxtClassSectionSubSection.AgSelectedValue = ""
                LblClassSectionSubSection.Tag = ""
            End If

            If (Not AgL.StrCmp(TxtStreamYearSemester.AgSelectedValue, LblSemesterExam.Tag)) Or _
                (Not AgL.StrCmp(TxtExamNature.Text, LblSemesterExamReq.Tag)) Then

                TxtSemesterExam.AgSelectedValue = ""
                LblSemesterExam.Tag = ""
                LblSemesterExamReq.Tag = ""
            End If


            Call Calculation()

            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mSearchCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        TxtTotalStudent.Text = ""
        TxtTotalPassStudent.Text = ""
        TxtTotalFailStudent.Text = ""
        TxtTotalPassWithGraceStudent.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1SemesterExamAdmission1, I).Value Is Nothing Then .Item(Col1SemesterExamAdmission1, I).Value = ""
                If .Item(Col1AdmissionDocId, I).Value Is Nothing Then .Item(Col1AdmissionDocId, I).Value = ""
                If .Item(Col1MarksObtain, I).Value Is Nothing Then .Item(Col1MarksObtain, I).Value = ""
                If .Item(Col1GraceMarks, I).Value Is Nothing Then .Item(Col1GraceMarks, I).Value = ""
                If .Item(Col1PresentStatus, I).Value Is Nothing Then .Item(Col1PresentStatus, I).Value = ""

                If .Item(Col1AdmissionDocId, I).Value.ToString.Trim <> "" Then
                    .Item(Col1PresentStatus, I).Value = ClsMain.ExamPresentStatus.Present
                End If

                If .Item(Col1SemesterExamAdmission1, I).Value.ToString.Trim <> "" Then

                    If AgL.StrCmp(.Item(Col1PresentStatus, I).Value.ToString, ClsMain.ExamPresentStatus.Absent) Then
                        .Item(Col1MarksObtain, I).Value = ""
                        .Item(Col1GraceMarks, I).Value = ""
                    End If

                    .Item(Col1TotalMarks, I).Value = Val(.Item(Col1MarksObtain, I).Value) + Val(.Item(Col1GraceMarks, I).Value)

                    If Val(.Item(Col1TotalMarks, I).Value) > 0 And .Item(Col1PresentStatus, I).Value.ToString.Trim = "" Then
                        .Item(Col1PresentStatus, I).Value = ClsMain.ExamPresentStatus.Present
                    End If

                    If Val(.Item(Col1TotalMarks, I).Value) < Val(TxtMinMarks.Text) Then
                        .Item(Col1Result, I).Value = ResultStr_Fail
                        TxtTotalFailStudent.Text = Val(TxtTotalFailStudent.Text) + 1
                    Else
                        If Val(.Item(Col1GraceMarks, I).Value) > 0 Then
                            .Item(Col1Result, I).Value = ResultStr_PassWithGrace
                            TxtTotalPassWithGraceStudent.Text = Val(TxtTotalPassWithGraceStudent.Text) + 1
                        Else
                            .Item(Col1Result, I).Value = ResultStr_Pass
                            TxtTotalPassStudent.Text = Val(TxtTotalPassStudent.Text) + 1
                        End If
                    End If

                    TxtTotalStudent.Text = Val(TxtTotalStudent.Text) + 1
                End If
            Next
        End With
    End Sub


    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = ""
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtExamNature, "Exam Nature") Then Exit Function
            If AgL.RequiredField(TxtIsAttendanceMarks, "Is Attendance Marks?") Then Exit Function
            'If AgL.RequiredField(TxtSessionProgramme, "Session/Programme") Then Exit Function
            'If AgL.RequiredField(TxtStreamYearSemester, "Semester") Then Exit Function
            If AgL.RequiredField(TxtSemesterExam, "Semester/Exam") Then Exit Function
            If AgL.RequiredField(TxtSubject, "Subject") Then Exit Function

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblStreamYearSemester.Tag) Then
                MsgBox("Stream/Year/Semester Is Not Valid!...") : TxtStreamYearSemester.Focus() : Exit Function
            End If

            If (Not AgL.StrCmp(TxtStreamYearSemester.AgSelectedValue, LblSemesterExam.Tag)) Or _
                (Not AgL.StrCmp(TxtExamNature.Text, LblSemesterExamReq.Tag)) Then

                MsgBox("Semester/Exam Is Not Valid!...") : TxtSemesterExam.Focus() : Exit Function
            End If

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblClassSection.Tag) And LblClassSection.Tag.ToString.Trim <> "" Then
                MsgBox("Class/Section Is Not Valid!...") : TxtClassSection.Focus() : Exit Function
            End If

            If Not AgL.StrCmp(TxtClassSection.AgSelectedValue, LblClassSectionSubSection.Tag) And LblClassSectionSubSection.Tag.ToString.Trim <> "" Then
                MsgBox("Sub-Section Is Not Valid!...") : TxtClassSectionSubSection.Focus() : Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1SemesterExamAdmission1) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1SemesterExamAdmission1 & "") Then Exit Function

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1SemesterExamAdmission1, I).Value <> "" Then
                        If .Item(Col1PresentStatus, I).Value.ToString.Trim = "" Then
                            MsgBox("Present/Absent Is Required For Student :" & vbCrLf & .Item(Col1SemesterExamAdmission1, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1PresentStatus, I) : DGL1.Focus() : Exit Function
                        End If

                        If Val(.Item(Col1MarksObtain, I).Value) >= Val(TxtMinMarks.Text) And Val(.Item(Col1GraceMarks, I).Value) > 0 Then
                            MsgBox("Grace Marks Is Not Required For Student :" & vbCrLf & .Item(Col1SemesterExamAdmission1, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1GraceMarks, I) : DGL1.Focus() : Exit Function
                        End If

                        If Val(.Item(Col1MarksObtain, I).Value) > Val(TxtMaxMarks.Text) Then
                            MsgBox("Marks Obtained Can't be Greater Than From " & Val(TxtMaxMarks.Text) & " For Student :" & vbCrLf & .Item(Col1SemesterExamAdmission1, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1MarksObtain, I) : DGL1.Focus() : Exit Function
                        End If

                        If Val(.Item(Col1MarksObtain, I).Value) = 0 And Val(.Item(Col1GraceMarks, I).Value) > 0 Then
                            MsgBox("Grace Marks Is Not Required For Student :" & vbCrLf & .Item(Col1SemesterExamAdmission1, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1GraceMarks, I) : DGL1.Focus() : Exit Function
                        ElseIf Val(.Item(Col1MarksObtain, I).Value) > Val(TxtMinMarks.Text) And Val(.Item(Col1GraceMarks, I).Value) > 0 Then
                            MsgBox("Grace Marks Is Not Required For Student :" & vbCrLf & .Item(Col1SemesterExamAdmission1, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1GraceMarks, I) : DGL1.Focus() : Exit Function
                        ElseIf Val(.Item(Col1GraceMarks, I).Value) >= Val(.Item(Col1MarksObtain, I).Value) And Val(.Item(Col1GraceMarks, I).Value) > 0 Then
                            MsgBox("Grace Marks Are Not Valid For Student :" & vbCrLf & .Item(Col1SemesterExamAdmission1, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1MarksObtain, I) : DGL1.Focus() : Exit Function
                        ElseIf Val(.Item(Col1TotalMarks, I).Value) > Val(TxtMinMarks.Text) And Val(.Item(Col1GraceMarks, I).Value) > 0 Then
                            MsgBox("Grace Marks Can't Be Greater Than From " & Val(TxtMinMarks.Text) - Val(.Item(Col1MarksObtain, I).Value) & " For Student :" & vbCrLf & .Item(Col1SemesterExamAdmission1, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1GraceMarks, I) : DGL1.Focus() : Exit Function
                        End If

                        If Val(.Item(Col1TotalMarks, I).Value) > Val(TxtMaxMarks.Text) Then
                            MsgBox("Total Marks Can't be Greater Than From " & Val(TxtMaxMarks.Text) & " For Student :" & vbCrLf & .Item(Col1SemesterExamAdmission1, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1MarksObtain, I) : DGL1.Focus() : Exit Function
                        End If
                    End If
                Next
            End With


            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            If FunIsSubjectMarksExists() Then MsgBox("Marks Already Exists For Subject : " & vbCrLf & TxtSubject.Text & " !...") : TxtSubject.Focus() : Exit Function

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mSearchCode <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                    TxtDocId.Text = mSearchCode
                End If

            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Function FunIsSubjectMarksExists() As Boolean
        Dim bFlag As Boolean = False
        mQry = "SELECT IsNull(Count(*),0) Cnt " & _
                " FROM Exam_SubjectMarks A " & _
                " WHERE A.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " AND " & _
                " A.SemesterExam = " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & " And " & _
                " A.Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & " And " & _
                " IsNull(A.IsAttendanceMarks,0) " & IIf(AgL.StrCmp(TxtIsAttendanceMarks.Text, "Yes"), " <> ", " = ") & " 0 And " & _
                " A.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " And " & _
                " A.ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " And " & _
                " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " A.DocId <> '" & mSearchCode & "' ") & " "
        If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) > 0 Then bFlag = True

        FunIsSubjectMarksExists = bFlag
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.ReadOnly = True
        Else
            TxtV_Type.ReadOnly = False
        End If

        If mTmV_Type.Trim = "" Then
            If TxtV_Type.ReadOnly = False Then TxtV_Type.Focus() Else TxtV_Date.Focus()
        Else
            TxtV_Date.Focus()
        End If
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

            If MsgBox("Are You Sure To Fill Student?...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If AgL.RequiredField(TxtSite_Code) Then Exit Sub
            If AgL.RequiredField(TxtExamNature, "Exam Nature") Then Exit Sub
            If AgL.RequiredField(TxtIsAttendanceMarks, "Is Attendance Marks?") Then Exit Sub
            'If AgL.RequiredField(TxtSessionProgramme, "Session/Programme") Then Exit Sub
            'If AgL.RequiredField(TxtStreamYearSemester, "Semester") Then Exit Sub
            If AgL.RequiredField(TxtSemesterExam, "Semester/Exam") Then Exit Sub
            If AgL.RequiredField(TxtSubject, "Subject") Then Exit Sub

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblStreamYearSemester.Tag) Then
                MsgBox("Stream/Year/Semester Is Not Valid!...") : TxtStreamYearSemester.Focus() : Exit Sub
            End If

            If (Not AgL.StrCmp(TxtStreamYearSemester.AgSelectedValue, LblSemesterExam.Tag)) Or _
                (Not AgL.StrCmp(TxtExamNature.Text, LblSemesterExamReq.Tag)) Then

                MsgBox("Semester/Exam Is Not Valid!...") : TxtSemesterExam.Focus() : Exit Sub
            End If

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblClassSection.Tag) And LblClassSection.Tag.ToString.Trim <> "" Then
                MsgBox("Class/Section Is Not Valid!...") : TxtClassSection.Focus() : Exit Sub
            End If

            If Not AgL.StrCmp(TxtClassSection.AgSelectedValue, LblClassSectionSubSection.Tag) And LblClassSectionSubSection.Tag.ToString.Trim <> "" Then
                MsgBox("Sub-Section Is Not Valid!...") : TxtClassSectionSubSection.Focus() : Exit Sub
            End If


            If FunIsSubjectMarksExists() Then MsgBox("Marks Already Exists For Subject : " & vbCrLf & TxtSubject.Text & " !...") : TxtSubject.Focus() : Exit Sub

            bCondStr = " WHERE Ea.SemesterExam = " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & " "

            If TxtStreamYearSemester.Text.Trim <> "" Then
                bCondStr += " And V2.StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "
            End If

            If TxtClassSection.Text.Trim <> "" Then
                bCondStr += " And Ea.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " "
            End If

            If TxtClassSectionSubSection.Text.Trim <> "" Then
                bCondStr += " And Ea.ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " "
            End If

            bCondStr += " And Ea1.Code Not In (" & _
                        " SELECT M1.SemesterExamAdmission1 " & _
                        " FROM Exam_SubjectMarks M " & _
                        " LEFT JOIN Exam_SubjectMarks1 M1 ON M.DocId = M1.DocId " & _
                        " Where M.Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & " " & _
                        " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " M1.DocId <> '" & mSearchCode & "' ") & " )"

            mQry = "SELECT DISTINCT Ea1.Code As SemesterExamAdmission1, V1.StudentName,  V1.AdmissionID, Ea1.AdmissionDocId, Ea.SemesterExam , Ea.DocId AS SemesterExamAdmission, " & _
                    " V2.ExamType, V2.ExamNature, E1.Subject, E1.Exam_MaxMarks, E1.Exam_MinMarks, E1.Test_MaxMarks, E1.Test_MinMarks, E1.Assignment_MaxMarks, E1.Assignment_MinMarks, " & _
                    " E1.Attendance_MaxMarks, E1.Attendance_MinMarks, E1.Total_MaxMarks, E1.Total_MinMarks " & _
                    " FROM Exam_SemesterExamAdmission Ea " & _
                    " LEFT JOIN Exam_SemesterExamAdmission1 Ea1 ON Ea1.DocId = Ea.DocId " & _
                    " LEFT JOIN ViewExam_SemesterExam V2 ON Ea.SemesterExam = V2.Code  " & _
                    " LEFT JOIN Exam_SemesterExam1 E1 ON V2.Code = E1.Code AND E1.Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & " " & _
                    " LEFT JOIN ViewSch_AdmissionCurrentDetail V1 ON Ea1.AdmissionDocId = V1.AdmissionDocId  " & _
                    " INNER JOIN ViewSch_AdmissionSubject V3 On Ea1.AdmissionDocId = V3.AdmissionDocId And V3.SubjectCode = E1.Subject " & _
                    " " & bCondStr & " " & _
                    " ORDER BY V1.StudentName "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1SemesterExamAdmission1, I) = AgL.XNull(.Rows(I)("SemesterExamAdmission1"))
                        DGL1.Item(Col1AdmissionDocId, I).Value = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL1.Item(Col1AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))
                    Next I

                    DGL1.CurrentCell = DGL1(Col1MarksObtain, 0) : DGL1.Focus()
                Else
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
