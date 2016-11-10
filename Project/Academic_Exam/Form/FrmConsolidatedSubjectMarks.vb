Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmConsolidatedSubjectMarks
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Dim mSubjectHelpFlag As Boolean = False

    'Constants declared for Grid1
    Private Const Col1_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1SubSemesterExamCode As Byte = 1
    Private Const Col1YesNo As Byte = 2

    'Constants declared for Grid2
    Private Const Col2_SNo As Byte = 0
    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2AdmissionDocId As Byte = 1
    Private Const Col2StudentName As Byte = 2
    Private Const Col2SemesterExamAdmission1 As Byte = 3
    Private Const Col2AdmissionID As Byte = 4
    Private Const Col2MarksObtain As Byte = 5
    Private Const Col2GraceMarks As Byte = 6
    Private Const Col2TotalMarks As Byte = 7
    Private Const Col2Result As Byte = 8

    Dim mDg2TotalRunTimeColumns As Byte = 0

    Dim mSemExam() As String = Nothing, mSubExamCodeStr As String = ""
    Dim mSemesterExamDate As String = "", mSemesterStartDate As String = ""

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
            .AddAgTextColumn(DGL1, "DGL1Code", 250, 5, "SubSemesterExam", True, True, False)
            .AddAgCheckBoxColumn(DGL1, "Dgl1YesNo", 70, "Yes/No", True, False)
        End With

        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False

        Call IniConsolidatedMarksGrid()

        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 40
        DGL2.AllowUserToAddRows = False
    End Sub

    Private Sub IniConsolidatedMarksGrid()
        Dim I As Integer
        mDg2TotalRunTimeColumns = 0
        ''==============================================================================
        ''================< Student Data Grid >====================================
        ''==============================================================================
        With AgCL
            If mSemExam Is Nothing Then
                .AddAgTextColumn(DGL2, "DGL2SNo", 40, 5, "S.No.", True, True, False)
                .AddAgTextColumn(DGL2, "Dgl2AdmissionDocId", 210, 8, "AdmissionDocId", False, True, False)
                .AddAgTextColumn(DGL2, "Dgl2StudentName", 220, 123, "Student Name", True, True, False)
                .AddAgTextColumn(DGL2, "Dgl2SemesterExamAdmission1", 190, 8, "SemesterExamAdmission1Code", False, True, False)
                .AddAgTextColumn(DGL2, "Dgl2AdmissionId", 130, 8, "Admission ID", True, True, False)
                .AddAgNumberColumn(DGL2, "Dgl2MarksObtain", 50, 3, 2, False, "Marks Obtained", False, True, True)
                .AddAgNumberColumn(DGL2, "Dgl2GraceMarks", 50, 3, 2, False, "Grace Marks", False, True, True)
                .AddAgNumberColumn(DGL2, "Dgl2TotalMarks", 50, 3, 2, False, "Total Marks", True, True, True)
                .AddAgTextColumn(DGL2, "Dgl2Result", 60, 40, "Result", True, True, False)
            Else

                For I = 0 To mSemExam.Length - 1
                    .AddAgTextColumn(DGL2, "Dgl2SubSemesterExam" & I.ToString & "", 30, 8, "SubSemesterExam" & (I + 1).ToString & "", False, True, False) : If I = 0 Then mDg2TotalRunTimeColumns += 1
                    .AddAgTextColumn(DGL2, "Dgl2SubSemesterExamAdmission1" & I.ToString & "", 30, 8, "SubSemesterExamAdmission1" & (I + 1).ToString & "", False, True, False) : If I = 0 Then mDg2TotalRunTimeColumns += 1
                    .AddAgNumberColumn(DGL2, "Dgl2MaxMarks" & I.ToString & "", 50, 3, 2, False, "Max Marks" & (I + 1).ToString & "", True, True, True) : If I = 0 Then mDg2TotalRunTimeColumns += 1
                    .AddAgNumberColumn(DGL2, "Dgl2MinMarks" & I.ToString & "", 50, 3, 2, False, "Min Marks" & (I + 1).ToString & "", False, True, True) : If I = 0 Then mDg2TotalRunTimeColumns += 1
                    .AddAgNumberColumn(DGL2, "Dgl2TotalMarks" & I.ToString & "", 50, 3, 2, False, "Obtain Marks" & (I + 1).ToString & "", True, True, True) : If I = 0 Then mDg2TotalRunTimeColumns += 1
                    .AddAgNumberColumn(DGL2, "Dgl2CMarks" & I.ToString & "", 50, 3, 2, False, "Shared Marks" & (I + 1).ToString & "", True, False, True) : If I = 0 Then mDg2TotalRunTimeColumns += 1
                Next

                DGL2.Columns(Col2Result).DisplayIndex = Col2Result + ((mSemExam.Length) * mDg2TotalRunTimeColumns)
                DGL2.Columns(Col2TotalMarks).DisplayIndex = DGL2.Columns(Col2Result).DisplayIndex - 1
                DGL2.Columns(Col2GraceMarks).DisplayIndex = DGL2.Columns(Col2TotalMarks).DisplayIndex - 1
                DGL2.Columns(Col2MarksObtain).DisplayIndex = DGL2.Columns(Col2GraceMarks).DisplayIndex - 1

            End If
        End With
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
            AgL.GridDesign(DGL2)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
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

            mQry = "Select A.DocId As SearchCode " & _
                    " From Exam_ConsolidatedSubjectMarks A  " & _
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
              " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ConsolidatedSubjectMarksEntry) & "" & _
              " Order By Description "
        TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT P.Code, P.SessionProgramme AS Name  " & _
                " FROM ViewSch_SessionProgramme P " & _
                " Where " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By P.SessionProgramme"
        TxtSessionProgramme.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Sem.Code, Sem.StreamYearSemesterDesc as Name, Sem.SessionProgrammeCode, sem.SemesterStartDate  " & _
                " FROM ViewSch_StreamYearSemester Sem " & _
                " Where " & AgL.PubSiteCondition("Sem.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By Sem.StreamYearSemesterDesc"
        TxtStreamYearSemester.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT E.Code , E.SemesterExamDesc [Semester Exam], E.ExamNature, " & _
                " E.SessionProgrammeCode , E.StreamYearSemester AS StreamYearSemesterCode, E.ClassSection,E.ClassSectionSubSection , E.Session," & _
                " E.ExamType AS ExamTypeCode,E.ExamNature,E.U_EntDt as SemesterExamDate " & _
                " FROM ViewExam_SemesterExam E " & _
                " Where " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & " AND  E.ExamNature = '" & ExamNature_Exam & "' " & _
                " ORDER BY E.SemesterExamDesc "
        TxtSemesterExam.AgHelpDataSet(9) = AgL.FillData(mQry, AgL.GCn)

        AgCL.IniAgHelpList(TxtSubExamNature, "" & ExamNature_Test & "," & ExamNature_Assignment & "")

        Call IniSubjectHelp()

        mQry = "SELECT E.Code, E.SemesterExamDesc [Semester Exam], E.ExamNature, " & _
                        " E.SessionProgrammeCode , E.StreamYearSemester  StreamYearSemesterCode, " & _
                        " E.ExamType AS ExamTypeCode " & _
                        " FROM ViewExam_SemesterExam E " & _
                        " Where " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & " AND E.ExamNature IN ('" & ExamNature_Test & "','" & ExamNature_Assignment & "')  " & _
                        " ORDER BY E.SemesterExamDesc "
        DGL1.AgHelpDataSet(Col1SubSemesterExamCode, 2) = AgL.FillData(mQry, AgL.GCn)

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

        mQry = "SELECT S.Code, S.ManualCode AS Session,S.StartDate " & _
               " FROM Sch_Session S " & _
               " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
               " Order By S.ManualCode "
        TxtSession.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

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

                    mQry = "Update Exam_SubjectMarks1 Set " & _
                            " ConsolidatedSubjectMarks2GUID = Null, " & _
                            " ConsolidatedMarks = 0 " & _
                            " From Exam_ConsolidatedSubjectMarks2 " & _
                            " Where Exam_SubjectMarks1.ConsolidatedSubjectMarks2GUID = Exam_ConsolidatedSubjectMarks2.GUID And " & _
                            " Exam_ConsolidatedSubjectMarks2.DocId = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    AgL.Dman_ExecuteNonQry("Delete From Exam_ConsolidatedSubjectMarks2 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Exam_ConsolidatedSubjectMarks1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Exam_ConsolidatedSubjectMarks Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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

            AgL.PubFindQry = "SELECT A.DocId As SearchCode, " & AgL.V_No_Field("A.DocId") & " As [Voucher No], " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], A.V_Date, " & _
                                " E.SemesterExamDesc As [Semester/Exam], Sub.Description As Subject, E.StreamYearSemesterDesc, A.SubExamNature " & _
                                " FROM Exam_ConsolidatedSubjectMarks A " & _
                                " Left Join Sch_Subject Sub On A.Subject = Sub.Code " & _
                                " LEFT JOIN ViewExam_SemesterExam E ON A.SemesterExam = E.Code " & _
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
        mSubjectHelpFlag = False

        Ini_List()
    End Sub

    Private Sub Topctrl_tbPrn() Handles Topctrl1.tbPrn
        Call PrintDocument(mSearchCode)
    End Sub

    Private Sub PrintDocument(ByVal mDocId As String)
        Dim mQry1 As String = ""
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim DsRep1 As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = "Consolidated Subject Marks"
            RepName = "Exam_ConsolidatedSubjectMarks" : RepTitle = "Consolidated Subject Marks"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            mQry = "SELECT csm.DocId,csm.Div_Code,csm.Site_Code,SM.Name AS SiteName, " & _
                    " csm.V_Date, csm.V_Type, vt.NCat, csm.V_Prefix,csm.V_No,   " & _
                    " se.SessionManualCode AS Session,se.ProgrammeManualCode AS Programme,   " & _
                    " se.StreamManualCode AS Stream,se.StreamYearSemesterDesc AS StreamYearSemester,  " & _
                    " Se.ExamTypeDesc AS ExamType,csm.SemesterExam AS SemesterExamCode,   " & _
                    " se.SemesterExamDesc AS SemesterExam,csm.SubExamNature,  csm.Subject, " & _
                    " s.Description AS SubjectName,csm.MaxMarks,csm.MinMarks,  csm.Remark, " & _
                    " csm.PreparedBy,csm.U_EntDt,csm.U_AE,csm.Edit_Date,csm.ModifiedBy,   " & _
                    " csm.RowId,csm.UpLoadDate, " & _
                    " csm2.GUID,csm2.SemesterExamAdmission1,VA.DocId,va.StudentName,VA.AdmissionID, " & _
                    " csm2.MarksObtain,csm2.TotalMarks,csm2.TotalMarks,csm2.Result " & _
                    " FROM Exam_ConsolidatedSubjectMarks csm   " & _
                    " LEFT JOIN SiteMast SM ON csm.Site_Code=sm.Code  " & _
                    " LEFT JOIN Voucher_Type Vt ON csm.V_Type=vt.V_Type     " & _
                    " LEFT JOIN ViewExam_SemesterExam Se ON csm.SemesterExam=Se.Code   " & _
                    " LEFT JOIN Sch_Subject S ON csm.Subject=s.Code   " & _
                    " LEFT JOIN Exam_ConsolidatedSubjectMarks2 csm2 ON csm2.DocId=csm.DocId  " & _
                    " LEFT JOIN Exam_SemesterExamAdmission1 sea ON csm2.SemesterExamAdmission1=sea.Code " & _
                    " LEFT JOIN ViewSch_Admission va ON sea.AdmissionDocId=VA.DocId " & _
                    " WHERE csm.DocId='" & mSearchCode & "'    "




            mQry1 = " SELECT csm1.DocId,csm1.Sr,csm1.SubSemesterExam AS SubSemesterCode, " & _
                    " se.SemesterExamDesc AS SemesterExam " & _
                    " FROM Exam_ConsolidatedSubjectMarks1 csm1 " & _
                    " LEFT JOIN ViewExam_SemesterExam se " & _
                    " ON csm1.SubSemesterExam=se.Code " & _
                    " WHERE csm1.DocId = '" & mSearchCode & "'"


            DsRep = AgL.FillData(mQry, AgL.GCn)

            DsRep1 = AgL.FillData(mQry1, AgL.GCn)

            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Exam & "\" & RepName & ".ttx", True)
            AgPL.CreateFieldDefFile1(DsRep1, PLib.PubReportPath_Exam & "\" & RepName & "1.ttx", True)

            mCrd.Load(PLib.PubReportPath_Exam & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))



            mCrd.OpenSubreport("SUBREP1").Database.Tables(0).SetDataSource(DsRep1.Tables(0))


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
        Dim bGUID$ = ""

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

                mQry = " INSERT INTO Exam_ConsolidatedSubjectMarks(DocId,Div_Code,Site_Code,V_Date,V_Type,   " & _
                        " V_Prefix,V_No,SemesterExam,SubExamNature,Subject,MaxMarks,MinMarks,Remark,PreparedBy,   " & _
                        " U_EntDt,U_AE , ClassSection, ClassSectionSubSection,Session)   " & _
                        " VALUES( " & _
                        " '" & mSearchCode & "','" & AgL.PubDivCode & "'," & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & "," & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & "," & AgL.Chk_Text(LblPrefix.Text) & "," & Val(TxtV_No.Text) & "," & _
                        " " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & " ,   " & _
                        " " & AgL.Chk_Text(TxtSubExamNature.AgSelectedValue) & "," & AgL.Chk_Text(TxtSubject.AgSelectedValue) & "," & Val(TxtMaxMarks.Text) & ", " & Val(TxtMinMarks.Text) & "," & AgL.Chk_Text(TxtRemark.Text) & ",'" & AgL.PubUserName & "','" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "','A'," & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & "," & AgL.Chk_Text(TxtSession.AgSelectedValue) & ")   "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            Else

                mQry = " UPDATE dbo.Exam_ConsolidatedSubjectMarks  " & _
                        " SET    " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & "," & _
                        " SemesterExam = " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & "," & _
                        " SubExamNature = " & AgL.Chk_Text(TxtSubExamNature.Text) & "," & _
                        " Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & "," & _
                        " MaxMarks = " & Val(TxtMaxMarks.Text) & "," & _
                        " MinMarks = " & Val(TxtMinMarks.Text) & "," & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & "," & _
                        " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & _
                        " ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & ", " & _
                        " Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ", " & _
                        " U_AE = 'E'," & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "'," & _
                        " ModifiedBy = '" & AgL.PubUserName & "'" & _
                        " WHERE DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            End If

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Exam_ConsolidatedSubjectMarks1 Where DocId='" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If CBool(.Item(Col1YesNo, I).Value) Then
                        bSr += 1
                        mQry = " INSERT INTO dbo.Exam_ConsolidatedSubjectMarks1(DocId,Sr,SubSemesterExam)  " & _
                                " VALUES(" & AgL.Chk_Text(mSearchCode) & "," & bSr & "," & AgL.Chk_Text(.AgSelectedValue(Col1SubSemesterExamCode, I)) & ")  "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

            Dim J As Integer

            If Topctrl1.Mode = "Edit" Then
                mQry = "Update Exam_SubjectMarks1 Set " & _
                        " ConsolidatedSubjectMarks2GUID = Null, " & _
                        " ConsolidatedMarks = 0 " & _
                        " From Exam_ConsolidatedSubjectMarks2 " & _
                        " Where Exam_SubjectMarks1.ConsolidatedSubjectMarks2GUID = Exam_ConsolidatedSubjectMarks2.GUID And " & _
                        " Exam_ConsolidatedSubjectMarks2.DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "Delete From Exam_ConsolidatedSubjectMarks2 Where DocId='" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL2
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2AdmissionDocId, I).Value <> "" Then
                        bGUID = AgL.GetGUID(GcnRead).ToString
                        bSr += 1

                        mQry = " INSERT INTO dbo.Exam_ConsolidatedSubjectMarks2(GUID, DocId, SemesterExamAdmission1, MarksObtain,    " & _
                                " GraceMarks,TotalMarks,Result) " & _
                                " VALUES(" & AgL.Chk_Text(bGUID) & "," & AgL.Chk_Text(mSearchCode) & "," & AgL.Chk_Text(.Item(Col2SemesterExamAdmission1, I).Value) & "," & Val(.Item(Col2MarksObtain, I).Value) & "," & Val(.Item(Col2GraceMarks, I).Value) & "," & Val(.Item(Col2TotalMarks, I).Value) & ",   " & _
                                " " & AgL.Chk_Text(.Item(Col2Result, I).Value) & ")  "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        For J = 0 To mSemExam.Length - 1
                            mQry = " UPDATE Exam_SubjectMarks1 SET  " & _
                                    " ConsolidatedSubjectMarks2GUID = " & AgL.Chk_Text(bGUID) & " , " & _
                                    " ConsolidatedMarks = " & Val(.Item("Dgl2CMarks" & J.ToString & "", I).Value) & "  " & _
                                    " FROM Exam_SemesterExamAdmission1, Exam_SubjectMarks  " & _
                                    " WHERE " & _
                                    " Exam_SubjectMarks1.DocId = Exam_SubjectMarks.DocId And " & _
                                    " Exam_SubjectMarks1.SemesterExamAdmission1 = Exam_SemesterExamAdmission1.Code AND " & _
                                    " Exam_SemesterExamAdmission1.AdmissionDocId=" & AgL.Chk_Text(.Item(Col2AdmissionDocId, I).Value) & " And " & _
                                    " Exam_SubjectMarks.SemesterExam = " & AgL.Chk_Text(.Item("Dgl2SubSemesterExam" & J.ToString, I).Value) & " And " & _
                                    " Exam_SubjectMarks.Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & " And " & _
                                    " IsNull(Exam_SubjectMarks.IsAttendanceMarks,0) = 0 "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Next
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
        Dim I As Integer, J As Integer
        Dim bCondStr$ = ""
        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            FClear()
            BlankText()

            DGL2.Columns.Clear()
            Call IniConsolidatedMarksGrid()

            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then
                Call IniSubjectHelp()

                mQry = " SELECT A.*, vt.NCat,v2.SessionProgrammeCode, v2.StreamYearSemester, V2.ExamNature, " & _
                        " Sem.SemesterStartDate, Ea.V_Date As SemesterExamDate,S.StartDate as SessionStartDate  " & _
                        " FROM Exam_ConsolidatedSubjectMarks A  " & _
                        " LEFT JOIN Voucher_Type Vt ON a.V_Type=vt.V_Type  " & _
                        " Left Join Exam_SemesterExamAdmission Ea On A.SemesterExam = Ea.SemesterExam " & _
                        " LEFT JOIN ViewExam_SemesterExam v2 ON a.SemesterExam=v2.Code " & _
                        " Left Join ViewSch_StreamYearSemester Sem On V2.StreamYearSemester = Sem.Code " & _
                        " Left Join Sch_Session S On A.Session = S.Code " & _
                        " WHERE A.DocId='" & mSearchCode & "'  "


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

                        TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgrammeCode"))

                        TxtStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        LblStreamYearSemester.Tag = AgL.XNull(.Rows(0)("SessionProgrammeCode"))

                        TxtSemesterExam.AgSelectedValue = AgL.XNull(.Rows(0)("SemesterExam"))
                        LblSemesterExam.Tag = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        LblSemesterExamReq.Tag = AgL.XNull(.Rows(0)("ExamNature"))
                        mSemesterExamDate = Format(AgL.XNull(.Rows(0)("SemesterExamDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                        TxtSubExamNature.Text = AgL.XNull(.Rows(0)("SubExamNature"))

                        TxtSubject.AgSelectedValue = AgL.XNull(.Rows(0)("Subject"))
                        TxtMaxMarks.Text = AgL.VNull(.Rows(0)("MaxMarks"))
                        TxtMinMarks.Text = AgL.VNull(.Rows(0)("MinMarks"))

                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        TxtClassSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSection"))
                        TxtClassSectionSubSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSectionSubSection"))
                        TxtSession.AgSelectedValue = AgL.XNull(.Rows(0)("Session"))
                        If TxtClassSection.AgSelectedValue <> "" Then
                            mSemesterStartDate = Format(AgL.XNull(.Rows(0)("SessionStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        Else
                            mSemesterStartDate = Format(AgL.XNull(.Rows(0)("SemesterStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        End If



                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With


                If TxtStreamYearSemester.Text.Trim <> "" Then
                    bCondStr += " And E.StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "
                End If
                If TxtClassSection.Text.Trim <> "" Then
                    bCondStr += " And E.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " "
                End If

                If TxtClassSectionSubSection.Text.Trim <> "" Then
                    bCondStr += " And E.ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " "
                End If

                mQry = "SELECT Ea.SemesterExam AS SemesterExamCode,  Convert(BIT, CASE WHEN CM1.SubSemesterExam IS NULL THEN 0 ELSE 1 END ) AS YesNo " & _
                        " FROM Exam_SemesterExamAdmission Ea " & _
                        " Left Join ViewExam_SemesterExam E On Ea.SemesterExam = E.Code " & _
                        " LEFT JOIN (Select vCm1.* From Exam_ConsolidatedSubjectMarks1 As vCm1 Where vCm1.DocId = '" & mSearchCode & "') CM1 ON E.Code = CM1.SubSemesterExam " & _
                        " Where Ea.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                        " " & bCondStr & "  " & _
                        " AND E.ExamNature=" & AgL.Chk_Text(TxtSubExamNature.Text) & "  " & _
                        " AND Ea.V_Date BETWEEN " & AgL.ConvertDate(mSemesterStartDate) & " AND " & AgL.ConvertDate(mSemesterExamDate) & "  " & _
                        " ORDER BY Ea.V_Date "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col1_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1SubSemesterExamCode, I) = AgL.XNull(.Rows(I)("SemesterExamCode"))
                            DGL1.Item(Col1YesNo, I).Value = AgL.VNull(.Rows(I)("YesNo"))
                        Next I
                        mSubExamCodeStr = FunFillSubExamCodeList()
                        mSemExam = Split(mSubExamCodeStr, ",")
                    End If
                End With

                Call IniConsolidatedMarksGrid()

                mQry = " DECLARE @Columns AS NVARCHAR(Max) " & _
                " DECLARE @Qry AS NVARCHAR(Max) " & _
                " SET @Columns = '' " & _
                " SELECT @Columns = @Columns +  " & _
                                    " ' Max(CASE V.SemesterExam WHEN ''' + X.SubSemesterExam + ''' THEN V.MaxMarks ELSE 0 END) AS ['+ X.ColumnDesc +'_MaxMarks], ' + " & _
                                    " ' Max(CASE V.SemesterExam WHEN ''' + X.SubSemesterExam + ''' THEN V.MinMarks ELSE 0 END) AS ['+ X.ColumnDesc +'_MinMarks], ' + " & _
                                    " ' Max(CASE V.SemesterExam WHEN ''' + X.SubSemesterExam + ''' THEN V.TotalMarks ELSE 0 END) AS ['+ X.ColumnDesc +'_TotalMarks], ' + " & _
                                    " ' Max(CASE V.SemesterExam WHEN ''' + X.SubSemesterExam + ''' THEN V.ConsolidatedMarks ELSE 0 END) AS ['+ X.ColumnDesc +'_ConsolidatedMarks], ' + " & _
                                    " ' Max(CASE V.SemesterExam WHEN ''' + X.SubSemesterExam + ''' THEN ''' + X.SubSemesterExam + ''' ELSE Null END) AS ['+ X.ColumnDesc +'_SubSemesterExam], ' " & _
                " FROM  " & _
                " ( " & _
                " SELECT CM1.SubSemesterExam, 'Column' + Convert(VARCHAR, CM1.Sr) AS ColumnDesc  " & _
                " FROM Exam_ConsolidatedSubjectMarks1 CM1   " & _
                " WHERE CM1.DocId = '" & mSearchCode & "'  " & _
                " ) X  " & _
                " SET @Qry=''  " & _
                " SET @Qry =  " & _
                " 'SELECT Cm2.*, V1.* " & _
                " FROM Exam_ConsolidatedSubjectMarks2 Cm2  " & _
                " LEFT JOIN Exam_SemesterExamAdmission1 Ea1 ON Cm2.SemesterExamAdmission1 = Ea1.Code   " & _
                " LEFT JOIN   " & _
                " (  " & _
                " SELECT  ' + @Columns   " & _
                " + '  " & _
                " V.AdmissionDocId, V.ConsolidatedSubjectMarks2DocId, Max(V.AdmissionId) As AdmissionId, Max(V.StudentName) As StudentName " & _
                " FROM   " & _
                " (  " & _
                " SELECT vCM2.DocId AS ConsolidatedSubjectMarks2DocId, M.SemesterExam, M.MaxMarks , M.MinMarks, " & _
                " M1.TotalMarks, M1.ConsolidatedMarks, Ea1.AdmissionDocId, Va1.AdmissionID, Va1.StudentName " & _
                " FROM Exam_SubjectMarks1 M1   " & _
                " INNER JOIN Exam_SubjectMarks M ON M1.DocId = M.DocId   " & _
                " LEFT JOIN Exam_SemesterExamAdmission1 Ea1 ON M1.SemesterExamAdmission1 = Ea1.Code   " & _
                " LEFT JOIN Exam_ConsolidatedSubjectMarks2 vCM2 On vCM2.Guid = M1.ConsolidatedSubjectMarks2GUID " & _
                " LEFT JOIN ViewSch_Admission Va1 ON ea1.AdmissionDocId=va1.DocId " & _
                " WHERE vCM2.DocId = ''" & mSearchCode & "'' And IsNull(M.IsAttendanceMarks,0) = 0 " & _
                      " ) V   " & _
                " GROUP BY V.ConsolidatedSubjectMarks2DocId, V.AdmissionDocId  " & _
                " ) V1 ON Cm2.DocId = V1.ConsolidatedSubjectMarks2DocId AND Ea1.AdmissionDocId = V1.AdmissionDocId " & _
                " Where Cm2.DocId = ''" & mSearchCode & "'' " & _
                " ORDER BY StudentName' " & _
                " EXEC sp_executesql @Qry "

                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        BtnFillMarksDetail.Tag = 1

                        For I = 0 To .Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col2_SNo, I).Value = DGL2.Rows.Count
                            DGL2.Item(Col2StudentName, I).Value = AgL.XNull(.Rows(I)("StudentName"))
                            DGL2.Item(Col2SemesterExamAdmission1, I).Value = AgL.XNull(.Rows(I)("SemesterExamAdmission1"))
                            DGL2.Item(Col2AdmissionDocId, I).Value = AgL.XNull(.Rows(I)("AdmissionDocId"))
                            DGL2.Item(Col2AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))

                            For J = 0 To mSemExam.Length - 1
                                DGL2.Item("Dgl2SubSemesterExam" & J.ToString & "", I).Value = AgL.XNull(.Rows(I)("Column" & (J + 1).ToString & "_SubSemesterExam"))
                                DGL2.Item("Dgl2MaxMarks" & J.ToString & "", I).Value = AgL.VNull(.Rows(I)("Column" & (J + 1).ToString & "_MaxMarks"))
                                DGL2.Item("Dgl2MinMarks" & J.ToString & "", I).Value = AgL.VNull(.Rows(I)("Column" & (J + 1).ToString & "_MinMarks"))
                                DGL2.Item("Dgl2TotalMarks" & J.ToString & "", I).Value = AgL.VNull(.Rows(I)("Column" & (J + 1).ToString & "_TotalMarks"))
                                DGL2.Item("Dgl2CMarks" & J.ToString & "", I).Value = AgL.VNull(.Rows(I)("Column" & (J + 1).ToString & "_ConsolidatedMarks"))
                            Next


                            DGL2.Item(Col2MarksObtain, I).Value = AgL.VNull(.Rows(I)("MarksObtain"))
                            DGL2.Item(Col2GraceMarks, I).Value = AgL.VNull(.Rows(I)("GraceMarks"))
                            DGL2.Item(Col2TotalMarks, I).Value = AgL.VNull(.Rows(I)("TotalMarks"))
                            DGL2.Item(Col2Result, I).Value = AgL.XNull(.Rows(I)("Result"))


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
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = ""
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
        DGL1.RowCount = 1 : DGL1.Rows.Clear()

        mSemesterStartDate = "" : mSemesterExamDate = ""
        mSubExamCodeStr = "" : mSemExam = Nothing

        BtnFillMarksDetail.Tag = 0 : BtnFillSubSemesterExam.Tag = 0

        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        BtnFillMarksDetail.Enabled = Enb
        BtnFillSubSemesterExam.Enabled = Enb

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
            TxtSessionProgramme.Enabled = False
            TxtStreamYearSemester.Enabled = False
            TxtSemesterExam.Enabled = False
            TxtSubExamNature.Enabled = False
            TxtSubject.Enabled = False
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
                'Case <ColumnIndex>
                '<Executable Code>
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL2
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
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown, DGL2.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub



    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded, DGL2.RowsAdded
        sender(Col1_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved, DGL2.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, Col1_SNo)

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
         TxtStreamYearSemester.Enter, TxtDocId.Enter, TxtSessionProgramme.Enter, _
         TxtMaxMarks.Enter, TxtMinMarks.Enter, TxtSemesterExam.Enter, TxtSubExamNature.Enter, TxtModified.Enter, TxtPrepared.Enter

        Try
            Select Case sender.name
                Case TxtStreamYearSemester.Name
                    TxtStreamYearSemester.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "

                Case TxtSemesterExam.Name
                    If TxtStreamYearSemester.Text.ToString.Trim <> "" Then
                        TxtSemesterExam.AgRowFilter = " StreamYearSemesterCode = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & "  "
                    End If
                    If TxtClassSection.Text.ToString.Trim <> "" Then
                        TxtSemesterExam.AgRowFilter = IIf(TxtClassSectionSubSection.Text.ToString.Trim <> "", " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " And ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " And Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & "", " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " And Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & "")
                    End If

                Case TxtSubject.Name
                    Call IniSubjectHelp(False)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtDocId.Validating, TxtV_Date.Validating, _
        TxtRemark.Validating, TxtStreamYearSemester.Validating, _
        TxtSessionProgramme.Validating, TxtDocId.Validating, TxtSubject.Validating, TxtMaxMarks.Validating, TxtMinMarks.Validating, TxtSubExamNature.Validating, TxtSemesterExam.Validating, TxtSession.Validating

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
                                LblStreamYearSemester.Tag = AgL.XNull(.Item("SessionProgrammeCode", .CurrentCell.RowIndex).Value)
                                mSemesterStartDate = Format(AgL.XNull(.Item("SemesterStartDate", .CurrentCell.RowIndex).Value), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            End With
                        End If
                    End If

                Case TxtSemesterExam.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblSemesterExam.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblSemesterExam.Tag = AgL.XNull(.Item("StreamYearSemesterCode", .CurrentCell.RowIndex).Value)
                                mSemesterExamDate = AgL.XNull(.Item("SemesterExamDate", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtSession.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        mSemesterStartDate = ""
                    Else
                        DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & "")
                        mSemesterStartDate = AgL.XNull(DrTemp(0)("StartDate"))
                    End If

                Case TxtSubject.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtMaxMarks.Text = ""
                        TxtMinMarks.Text = ""
                    Else
                        DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & "")
                        Select Case TxtSubExamNature.Text
                            Case ExamNature_Exam
                                TxtMaxMarks.Text = AgL.VNull(DrTemp(0)("Exam_MaxMarks"))
                                TxtMinMarks.Text = AgL.VNull(DrTemp(0)("Exam_MinMarks"))

                            Case ExamNature_Test
                                TxtMaxMarks.Text = AgL.VNull(DrTemp(0)("Test_MaxMarks"))
                                TxtMinMarks.Text = AgL.VNull(DrTemp(0)("Test_MinMarks"))

                            Case ExamNature_Assignment
                                TxtMaxMarks.Text = AgL.VNull(DrTemp(0)("Assignment_MaxMarks"))
                                TxtMinMarks.Text = AgL.VNull(DrTemp(0)("Assignment_MinMarks"))

                            Case Else
                                TxtMaxMarks.Text = ""
                                TxtMinMarks.Text = ""
                        End Select
                    End If


            End Select

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblStreamYearSemester.Tag) Then
                TxtStreamYearSemester.AgSelectedValue = ""
                LblStreamYearSemester.Tag = ""
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

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = "", bSubExamCodeStr$ = ""
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtSubExamNature, "Exam Nature") Then Exit Function
            'If AgL.RequiredField(TxtSessionProgramme, "Session/Programme") Then Exit Function
            'If AgL.RequiredField(TxtStreamYearSemester, "Semester") Then Exit Function
            If AgL.RequiredField(TxtSubExamNature, "Semester/Exam") Then Exit Function
            If AgL.RequiredField(TxtSubject, "Subject") Then Exit Function
            If AgL.RequiredField(TxtMaxMarks, "Max Marks", True) Then Exit Function
            If AgL.RequiredField(TxtMinMarks, "Min Marks", True) Then Exit Function

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblStreamYearSemester.Tag) Then
                MsgBox("Stream/Year/Semester Is Not Valid!...") : TxtStreamYearSemester.Focus() : Exit Function
            End If

            bSubExamCodeStr = FunFillSubExamCodeList()
            If Not AgL.StrCmp(mSubExamCodeStr, bSubExamCodeStr) Then
                MsgBox("Please Fill Marks Detail First!...") : Tc1.SelectedTab = Tp2 : BtnFillMarksDetail.Focus() : Exit Function
            End If

            If AgCL.AgIsBlankGrid(DGL1, Col1SubSemesterExamCode) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1SubSemesterExamCode & "") Then Exit Function

            AgCL.AgBlankNothingCells(DGL2)
            If AgCL.AgIsBlankGrid(DGL2, Col2StudentName) Then Exit Function
            If AgCL.AgIsDuplicate(DGL2, "" & Col2StudentName & "") Then Exit Function

            With DGL2
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2StudentName, I).Value.ToString.Trim <> "" Then
                        If Val(.Item(Col2MarksObtain, I).Value) >= Val(TxtMinMarks.Text) And Val(.Item(Col2GraceMarks, I).Value) > 0 Then
                            MsgBox("Grace Marks Is Not Required For Student :" & vbCrLf & .Item(Col2StudentName, I).Value & " ") : DGL2.CurrentCell = DGL2(Col2GraceMarks, I) : DGL2.Focus() : Exit Function
                        End If

                        If Val(.Item(Col2MarksObtain, I).Value) > Val(TxtMaxMarks.Text) Then
                            MsgBox("Marks Obtained Can't be Greater Than From " & Val(TxtMaxMarks.Text) & " For Student :" & vbCrLf & .Item(Col2StudentName, I).Value & " ") : DGL2.CurrentCell = DGL2(Col2Result + mDg2TotalRunTimeColumns, I) : DGL2.Focus() : Exit Function
                        End If

                        If Val(.Item(Col2MarksObtain, I).Value) = 0 And Val(.Item(Col2GraceMarks, I).Value) > 0 Then
                            MsgBox("Grace Marks Is Not Required For Student :" & vbCrLf & .Item(Col2StudentName, I).Value & " ") : DGL2.CurrentCell = DGL2(Col2GraceMarks, I) : DGL2.Focus() : Exit Function
                        ElseIf Val(.Item(Col2MarksObtain, I).Value) > Val(TxtMinMarks.Text) And Val(.Item(Col2GraceMarks, I).Value) > 0 Then
                            MsgBox("Grace Marks Is Not Required For Student :" & vbCrLf & .Item(Col2StudentName, I).Value & " ") : DGL2.CurrentCell = DGL2(Col2GraceMarks, I) : DGL2.Focus() : Exit Function
                        ElseIf Val(.Item(Col2GraceMarks, I).Value) >= Val(.Item(Col2MarksObtain, I).Value) And Val(.Item(Col2GraceMarks, I).Value) > 0 Then
                            MsgBox("Grace Marks Are Not Valid For Student :" & vbCrLf & .Item(Col2StudentName, I).Value & " ") : DGL2.CurrentCell = DGL2(Col2Result + mDg2TotalRunTimeColumns, I) : DGL2.Focus() : Exit Function
                        ElseIf Val(.Item(Col2TotalMarks, I).Value) > Val(TxtMinMarks.Text) And Val(.Item(Col2GraceMarks, I).Value) > 0 Then
                            MsgBox("Grace Marks Can't Be Greater Than From " & Val(TxtMinMarks.Text) - Val(.Item(Col2MarksObtain, I).Value) & " For Student :" & vbCrLf & .Item(Col2StudentName, I).Value & " ") : DGL2.CurrentCell = DGL2(Col2GraceMarks, I) : DGL2.Focus() : Exit Function
                        End If

                        If Val(.Item(Col2TotalMarks, I).Value) > Val(TxtMaxMarks.Text) Then
                            MsgBox("Total Marks Can't be Greater Than From " & Val(TxtMaxMarks.Text) & " For Student :" & vbCrLf & .Item(Col2StudentName, I).Value & " ") : DGL2.CurrentCell = DGL2(Col2Result + mDg2TotalRunTimeColumns, I) : DGL2.Focus() : Exit Function
                        End If
                    End If
                Next
            End With


            '    If Not AgCL.AgCheckMandatory(Me) Then Exit Function

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
                " FROM Exam_ConsolidatedSubjectMarks A " & _
                " WHERE A.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " AND " & _
                " A.SemesterExam = " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & " And " & _
                " A.Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & " And " & _
                " A.SubExamNature = " & AgL.Chk_Text(TxtSubExamNature.Text) & " And " & _
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



    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillMarksDetail.Click, BtnFillSubSemesterExam.Click
        Try
            Select Case sender.name
                Case BtnFillMarksDetail.Name
                    Call ProcFillMarksDetail()

                Case BtnFillSubSemesterExam.Name
                    Call ProcFillSubSemesterExam()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ProcFillMarksDetail()
        Dim DtTemp As DataTable
        Dim J As Integer, I As Integer
        Dim bCondQry$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub
            'If Val(BtnFillSubSemesterExam.Tag) = 0 Then MsgBox("Fill " & TxtSubExamNature.Text & " Detail First!...") : Tc1.SelectedTab = Tp1 : BtnFillSubSemesterExam.Focus() : Exit Sub

            If MsgBox("Are You Sure To Fill Student?...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub

            DGL2.RowCount = 1 : DGL2.Rows.Clear()


            If AgL.RequiredField(TxtSite_Code) Then Exit Sub
            If AgL.RequiredField(TxtSubExamNature, "Exam Nature") Then Exit Sub
            'If AgL.RequiredField(TxtSessionProgramme, "Session/Programme") Then Exit Sub
            'If AgL.RequiredField(TxtStreamYearSemester, "Semester") Then Exit Sub
            If AgL.RequiredField(TxtSubExamNature, "Semester/Exam") Then Exit Sub
            If AgL.RequiredField(TxtSubject, "Subject") Then Exit Sub

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblStreamYearSemester.Tag) Then
                MsgBox("Stream/Year/Semester Is Not Valid!...") : TxtStreamYearSemester.Focus() : Exit Sub
            End If

            If FunIsSubjectMarksExists() Then MsgBox("Marks Already Exists For Subject : " & vbCrLf & TxtSubject.Text & " !...") : TxtSubject.Focus() : Exit Sub

            If Val(BtnFillMarksDetail.Tag) = 1 Or Topctrl1.Mode = "Add" Then
                DGL2.Columns.Clear() : mSemExam = Nothing : mSubExamCodeStr = ""
                IniConsolidatedMarksGrid()
            End If


            mSubExamCodeStr = FunFillSubExamCodeList()
            If mSubExamCodeStr.Trim = "" Then MsgBox("Please Select " & TxtSubExamNature.Text & " First!...") : Exit Sub

            mSemExam = Split(mSubExamCodeStr, ",")

            mQry = "SELECT V1.AdmissionDocId, Max(V2.StudentName) As StudentName, Max(v2.AdmissionId) As AdmissionId, Max(Ea1.Code) AS SemesterExamAdmission1 "
            For I = 0 To mSemExam.Length - 1
                mQry += " ,Max(V1.SemesterExam" & I.ToString & " ) AS SemesterExam" & I.ToString & ", " & _
                        " Max(V1.MaxMarks" & I.ToString & ") AS MaxMarks" & I.ToString & ", " & _
                        " Max(V1.MinMarks" & I.ToString & ") AS MinMarks" & I.ToString & ", " & _
                        " Max(V1.TotalMarks" & I.ToString & ") AS TotalMarks" & I.ToString & ", " & _
                        " 0 AS CM" & I.ToString & " "
            Next
            mQry += " ,0 AS TOM, 0 AS TGM,  0 AS TTM , NULL as Result " & _
                    " FROM Exam_SemesterExam E " & _
                    " LEFT JOIN Exam_SemesterExamAdmission Ea ON E.Code = Ea.SemesterExam " & _
                    " LEFT JOIN Exam_SemesterExamAdmission1 Ea1 ON Ea.DocId = Ea1.DocId " & _
                    " LEFT JOIN ViewSch_Admission V2 ON Ea1.AdmissionDocId=v2.DocId " & _
                    " LEFT JOIN ( SELECT M.SemesterExam, Ea1.AdmissionDocId "

            For I = 0 To mSemExam.Length - 1
                mQry += " ,CASE M.SemesterExam WHEN " & mSemExam(I).ToString & " THEN M.SemesterExam ELSE Null END AS SemesterExam" & I.ToString & ", " & _
                        " CASE M.SemesterExam WHEN " & mSemExam(I).ToString & " THEN M1.SemesterExamAdmission1 ELSE Null END AS SemesterExamAdmission1" & I.ToString & " ," & _
                        " CASE M.SemesterExam WHEN " & mSemExam(I).ToString & " THEN M.MaxMarks ELSE 0 END AS MaxMarks" & I.ToString & ", " & _
                        " CASE M.SemesterExam WHEN " & mSemExam(I).ToString & " THEN M.MinMarks ELSE 0 END AS MinMarks" & I.ToString & ", " & _
                        " CASE M.SemesterExam WHEN " & mSemExam(I).ToString & " THEN M1.TotalMarks ELSE 0 END AS TotalMarks" & I.ToString & " "

            Next


            mQry += " FROM Exam_SubjectMarks M  " & _
                    " LEFT JOIN Exam_SubjectMarks1 M1 ON M.DocId =M1.DocId  " & _
                    " LEFT JOIN Exam_SemesterExamAdmission1 Ea1 ON M1.SemesterExamAdmission1 = Ea1.Code   " & _
                    " WHERE M.SemesterExam IN (" & mSubExamCodeStr & " ) AND M.Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & "" & _
                    " And IsNull(M.IsAttendanceMarks,0)=0 " & _
                    " ) AS V1 ON V1.AdmissionDocId  = V2.DocId " & _
                    " WHERE E.Code = " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & " " & _
                    " GROUP BY  V1.AdmissionDocId " & _
                    " ORDER BY V2.StudentName "




            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)


            Call IniConsolidatedMarksGrid()

            With DtTemp
                DGL2.RowCount = 1 : DGL2.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL2.Rows.Add()
                        DGL2.Item(Col2_SNo, I).Value = DGL2.Rows.Count

                        DGL2.Item(Col2StudentName, I).Value = AgL.XNull(.Rows(I)("StudentName"))
                        DGL2.Item(Col2SemesterExamAdmission1, I).Value = AgL.XNull(.Rows(I)("SemesterExamAdmission1"))
                        DGL2.Item(Col2AdmissionDocId, I).Value = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL2.Item(Col2AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))

                        For J = 0 To mSemExam.Length - 1
                            DGL2.Item("Dgl2SubSemesterExam" & J.ToString & "", I).Value = AgL.XNull(.Rows(I)("SemesterExam" & J.ToString & ""))
                            DGL2.Item("Dgl2MaxMarks" & J.ToString & "", I).Value = AgL.VNull(.Rows(I)("MaxMarks" & J.ToString & ""))
                            DGL2.Item("Dgl2MinMarks" & J.ToString & "", I).Value = AgL.VNull(.Rows(I)("MinMarks" & J.ToString & ""))
                            DGL2.Item("Dgl2TotalMarks" & J.ToString & "", I).Value = AgL.VNull(.Rows(I)("TotalMarks" & J.ToString & ""))
                            DGL2.Item("Dgl2CMarks" & J.ToString & "", I).Value = AgL.VNull(.Rows(I)("CM" & J.ToString & ""))
                        Next

                        DGL2.Item(Col2MarksObtain, I).Value = AgL.VNull(.Rows(I)("TOM"))
                        DGL2.Item(Col2GraceMarks, I).Value = AgL.VNull(.Rows(I)("TGM"))
                        DGL2.Item(Col2TotalMarks, I).Value = AgL.VNull(.Rows(I)("TTM"))
                        DGL2.Item(Col2Result, I).Value = AgL.XNull(.Rows(I)("Result"))
                    Next I
                Else
                    MsgBox("No Record Exists!...")
                End If
            End With

            BtnFillMarksDetail.Tag = 1
        Catch ex As Exception
            MsgBox(ex.Message)
            DGL2.RowCount = 1 : DGL2.Rows.Clear()
            mSubExamCodeStr = "" : mSemExam = Nothing
        Finally
            DtTemp = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Function FunFillSubExamCodeList() As String
        Dim I As Integer
        Dim bSubExamCodeStr$ = ""

        For I = 0 To DGL1.RowCount - 1
            If CBool(DGL1.Item(Col1YesNo, I).Value) Then
                If bSubExamCodeStr.Trim = "" Then
                    bSubExamCodeStr = "" & AgL.Chk_Text(DGL1.AgSelectedValue(Col1SubSemesterExamCode, I)) & ""
                Else
                    bSubExamCodeStr += ", " & "" & AgL.Chk_Text(DGL1.AgSelectedValue(Col1SubSemesterExamCode, I)) & ""
                End If
            End If
        Next

        FunFillSubExamCodeList = bSubExamCodeStr
    End Function

    Private Sub ProcFillSubSemesterExam()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim bCondStr$ = ""
        Dim bCondQry$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If AgL.RequiredField(TxtSite_Code) Then Exit Sub
            'If AgL.RequiredField(TxtSessionProgramme, "Session/Programme") Then Exit Sub
            'If AgL.RequiredField(TxtStreamYearSemester, "Semester") Then Exit Sub
            If AgL.RequiredField(TxtSemesterExam, "Semester/Exam") Then Exit Sub
            If AgL.RequiredField(TxtSubExamNature, "Exam Nature") Then Exit Sub
            If AgL.RequiredField(TxtSubject, "Subject") Then Exit Sub

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblStreamYearSemester.Tag) Then
                MsgBox("Stream/Year/Semester Is Not Valid!...") : TxtStreamYearSemester.Focus() : Exit Sub
            End If

            If TxtStreamYearSemester.Text.Trim <> "" Then
                bCondStr += " And E.StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "
            End If
            If TxtClassSection.Text.Trim <> "" Then
                bCondStr += " And E.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " "
            End If

            If TxtClassSectionSubSection.Text.Trim <> "" Then
                bCondStr += " And E.ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " "
            End If

            mQry = " SELECT Ea.SemesterExam as SemesterExamCode  , E.SemesterExamDesc [Semester Exam],  " & _
                    " E.ExamNature, E.SessionProgrammeCode, E.StreamYearSemester,   " & _
                    " E.ExamType AS ExamTypeCode, Convert(Bit, 1) AS [Yes/No]     " & _
                    " FROM Exam_SemesterExamAdmission Ea " & _
                    " Left Join (" & _
                    "               SELECT E.* " & _
                    "               FROM ViewExam_SemesterExam E " & _
                    "               INNER JOIN (SELECT E1.Code AS SemesterExamCode FROM Exam_SemesterExam1 E1 WHERE E1.Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ")  vE1 ON E.Code = vE1.SemesterExamCode " & _
                    "           ) E  On Ea.SemesterExam = E.Code " & _
                    " Where Ea.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                    "" & bCondStr & "" & _
                    " AND E.ExamNature=" & AgL.Chk_Text(TxtSubExamNature.Text) & "  " & _
                    " AND Ea.V_Date BETWEEN " & AgL.ConvertDate(mSemesterStartDate) & " AND " & AgL.ConvertDate(mSemesterExamDate) & "  " & _
                    " ORDER BY Ea.V_Date  "


            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col1_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1SubSemesterExamCode, I) = AgL.XNull(.Rows(I)("SemesterExamCode"))
                        DGL1.Item(Col1YesNo, I).Value = AgL.VNull(.Rows(I)("Yes/No"))
                    Next I
                Else
                    MsgBox("No Test Record Exists!...")
                End If
            End With

            BtnFillSubSemesterExam.Tag = 1
        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0, J As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        With DGL2
            For I = 0 To .Rows.Count - 1
                If .Item(Col2StudentName, I).Value Is Nothing Then .Item(Col2StudentName, I).Value = ""
                If .Item(Col2SemesterExamAdmission1, I).Value Is Nothing Then .Item(Col2SemesterExamAdmission1, I).Value = ""
                If .Item(Col2AdmissionDocId, I).Value Is Nothing Then .Item(Col2AdmissionDocId, I).Value = ""
                If .Item(Col2MarksObtain, I).Value Is Nothing Then .Item(Col2MarksObtain, I).Value = ""
                If .Item(Col2GraceMarks, I).Value Is Nothing Then .Item(Col2GraceMarks, I).Value = ""

                If .Item(Col2AdmissionDocId, I).Value.ToString.Trim <> "" Then
                    If mSemExam IsNot Nothing Then
                        .Item(Col2MarksObtain, I).Value = ""
                        .Item(Col2GraceMarks, I).Value = ""
                        .Item(Col2TotalMarks, I).Value = ""
                        .Item(Col2Result, I).Value = ""

                        For J = 0 To mSemExam.Length - 1
                            .Item(Col2MarksObtain, I).Value = Val(.Item(Col2MarksObtain, I).Value) + Val(DGL2.Item("Dgl2CMarks" & J.ToString & "", I).Value)
                        Next
                    End If

                    .Item(Col2TotalMarks, I).Value = Val(.Item(Col2MarksObtain, I).Value) + Val(.Item(Col2GraceMarks, I).Value)
                End If

                If Val(.Item(Col2TotalMarks, I).Value) < Val(TxtMinMarks.Text) Then
                    .Item(Col2Result, I).Value = ResultStr_Fail
                Else
                    If Val(.Item(Col2GraceMarks, I).Value) > 0 Then
                        .Item(Col2Result, I).Value = ResultStr_PassWithGrace
                    Else
                        .Item(Col2Result, I).Value = ResultStr_Pass
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub DGL2_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGL2.CellValidating
        Dim J As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex
            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL2
                If DGL2.Item(Col2AdmissionDocId, e.RowIndex).Value <> "" And TxtMaxMarks.Text <> "" Then
                    If Val(e.FormattedValue) > Val(TxtMaxMarks.Text) - Val(.Item(Col2TotalMarks, e.RowIndex).Value) + Val(.CurrentCell.Value) Then
                        MsgBox("Total Marks Can't Be Greater Than """ & TxtMaxMarks.Text & """ ", MsgBoxStyle.Information)
                        e.Cancel = True
                        Exit Sub
                    End If
                End If
            End With
        Catch ex As Exception
        End Try
    End Sub

End Class