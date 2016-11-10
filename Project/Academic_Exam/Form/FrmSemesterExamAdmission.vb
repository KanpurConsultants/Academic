Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmSemesterExamAdmission
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode


    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1AdmissionDocId As Byte = 1
    Private Const Col1AdmissionID As Byte = 2
    'Private Const Col1YesNo As Byte = 3
    Private Const Col1IsYesNo As Byte = 3
    Private Const Col1Code As Byte = 4
    Private Const Col1StreamYearSemester As Byte = 5


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
            .AddAgTextColumn(DGL1, "Dgl1AdmissionDocId", 320, 8, "Student", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionId", 200, 8, "Admission ID", True, True, False)
            AgL.AddCheckColumn(DGL1, "Dgl1YesNo", 80, 50, "Yes/No", True, True)
            '.AddAgCheckBoxColumn(DGL1, "Dgl1YesNo", 60, "Yes/No", True, False)
            .AddAgTextColumn(DGL1, "DGL1Code", 30, 5, "Code", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1StreamYearSemester", 30, 5, "StreamYearSemester", False, True, False)
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

            mQry = "Select A.DocId As SearchCode " & _
                    " From Exam_SemesterExamAdmission A " & _
                    " LEFT JOIN Voucher_Type Vt ON A.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
                  " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_SemesterExamCreation) & "" & _
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
                    " E.SessionProgrammeCode , E.StreamYearSemester  StreamYearSemesterCode, E.ClassSection,E.ClassSectionSubSection , E.Session," & _
                    " E.ExamType AS ExamTypeCode " & _
                    " FROM ViewExam_SemesterExam E " & _
                    " Where " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY E.SemesterExamDesc "
            TxtSemesterExam.AgHelpDataSet(7) = AgL.FillData(mQry, AgL.GCn)

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

            mQry = "SELECT Vp.AdmissionDocId As Code, V1.StudentName As [Student Name], V1.AdmissionID, V1.Student As StudentCode, " & _
                    " Vp.FromStreamYearSemester AS StreamYearSemesterCode " & _
                    " FROM (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.PromotionDate IS NULL) Vp " & _
                    " LEFT JOIN ViewSch_Admission V1 ON Vp.AdmissionDocId = V1.DocId " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By V1.StudentName "
            DGL1.AgHelpDataSet(Col1AdmissionDocId, 1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ManualCode AS Session " & _
                    " FROM Sch_Session S " & _
                    " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By S.ManualCode "
            TxtSession.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)


            AgCL.IniAgHelpList(TxtExamNature, PubExamNatureStr)


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


                    AgL.Dman_ExecuteNonQry("Delete From Exam_SemesterExamAdmission1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Exam_SemesterExamAdmission Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
                                " E.SemesterExamDesc As [Semester/Exam], E.StreamYearSemesterDesc, A.TotalStudent " & _
                                " FROM Exam_SemesterExamAdmission A " & _
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

            AgL.PubReportTitle = "Semester Exam Admission"
            RepName = "Exam_Semester_Exam_Admission" : RepTitle = "Semester Exam Admission"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " Select A.V_Date,a.V_No," & AgL.V_No_Field("a.DocId") & " As VoucherNo,a.TotalStudent,a.Remark,a.PreparedBy,vese.ExamTypeDesc,vese.ExamNature,vese.SemesterExamDesc, " & _
                     " Vsp.SessionProgramme,Vsys.StreamYearSemesterDesc ,Vt.NCat, E.SessionProgrammeCode, E.StreamYearSemester, E.ExamNature ,a1.AdmissionDocId,ViewSch_Admission.StudentName  AS StudentName " & _
                     " From Exam_SemesterExamAdmission A  LEFT JOIN Exam_SemesterExamAdmission1 a1 ON a.docid=a1.docid " & _
                     " LEFT JOIN ViewSch_Admission ON a1.AdmissionDocId=ViewSch_Admission.docid " & _
                     " Left Join Voucher_Type Vt On A.V_Type = Vt.V_Type  Left Join ViewExam_SemesterExam E On A.SemesterExam = E.Code " & _
                     " LEFT JOIN ViewSch_SessionProgramme VSp ON  E.SessionProgrammeCode=vsp.Code " & _
                     " LEFT JOIN ViewSch_StreamYearSemester VSYS ON  E.StreamYearSemester=vsys.Code " & _
                     " LEFT JOIN ViewExam_SemesterExam VESE ON a.SemesterExam=VESE.Code " & _
                     " Where A.DocId='" & mSearchCode & "' "


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
        Dim I As Integer
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
                mQry = "INSERT INTO Exam_SemesterExamAdmission ( DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, " & _
                        " V_No, SemesterExam, TotalStudent, Remark, " & _
                        " PreparedBy, U_EntDt, U_AE , ClassSection, ClassSectionSubSection, Session) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & "," & _
                        " " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & ", " & Val(TxtTotalStudent.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A'," & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & ", " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ")"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Exam_SemesterExamAdmission " & _
                        " SET  " & _
                        " 	V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " 	SemesterExam = " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & ", " & _
                        " 	TotalStudent = " & Val(TxtTotalStudent.Text) & ", " & _
                        " 	Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " 	U_AE = 'E', " & _
                        "   Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ", " & _
                        " 	ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & _
                        "   ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & ", " & _
                        " 	Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " 	ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & mSearchCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Code, I).Value <> "" Then
                        If .Item(Col1AdmissionDocId, I).Value <> "" And DGL1.Item(Col1IsYesNo, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                            mQry = "UPDATE Exam_SemesterExamAdmission1 SET AdmissionDocId = " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & ",StreamYearSemester =" & AgL.Chk_Text(.Item(Col1StreamYearSemester, I).Value) & " " & _
                                    " WHERE Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        Else
                            mQry = "Delete From Exam_SemesterExamAdmission1 " & _
                                   "Where Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & ""
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If .Item(Col1AdmissionDocId, I).Value <> "" And DGL1.Item(Col1IsYesNo, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                            bSemesterExamAdmission1 = AgL.GetMaxId("Exam_SemesterExamAdmission1", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)

                            mQry = "INSERT INTO Exam_SemesterExamAdmission1 ( " & _
                                    " Code, DocId, AdmissionDocId,StreamYearSemester ) " & _
                                    " VALUES ( " & _
                                    " " & AgL.Chk_Text(bSemesterExamAdmission1) & ", " & AgL.Chk_Text(mSearchCode) & ", " & _
                                    " " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & " ," & AgL.Chk_Text(.Item(Col1StreamYearSemester, I).Value) & " )"

                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        End If
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
                mQry = "Select A.*, Vt.NCat, E.SessionProgrammeCode, E.StreamYearSemester,E.ExamNature " & _
                        " From Exam_SemesterExamAdmission A " & _
                        " Left Join Voucher_Type Vt On A.V_Type = Vt.V_Type " & _
                        " Left Join ViewExam_SemesterExam E On A.SemesterExam = E.Code " & _
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

                        TxtExamNature.Text = AgL.XNull(.Rows(0)("ExamNature"))
                        TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgrammeCode"))

                        TxtStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        LblStreamYearSemester.Tag = AgL.XNull(.Rows(0)("SessionProgrammeCode"))

                        TxtSemesterExam.AgSelectedValue = AgL.XNull(.Rows(0)("SemesterExam"))
                        LblSemesterExamReq.Tag = AgL.XNull(.Rows(0)("ExamNature"))
                        LblSemesterExam.Tag = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        '********* Rati **********************
                        TxtClassSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSection"))
                        TxtClassSectionSubSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSectionSubSection"))
                        TxtSession.AgSelectedValue = AgL.XNull(.Rows(0)("Session"))
                        ''************************************

                        TxtTotalStudent.Text = AgL.VNull(.Rows(0)("TotalStudent"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With


                mQry = "Select A1.*, V1.AdmissionID, Convert(bit,1) As YesNo " & _
                        " From Exam_SemesterExamAdmission1 A1 " & _
                        " LEFT JOIN ViewSch_Admission V1 ON A1.AdmissionDocId = V1.DocId " & _
                        " Where A1.DocId = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                            DGL1.Item(Col1AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))
                            DGL1.Item(Col1StreamYearSemester, I).Value = AgL.XNull(.Rows(I)("StreamYearSemester"))
                            'DGL1.Item(Col1YesNo, I).Value = AgL.VNull(.Rows(I)("YesNo"))
                            If AgL.VNull(.Rows(I)("YesNo")) Then
                                DGL1.Item(Col1IsYesNo, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                            End If
                            DGL1.Item(Col1Code, I).Value = AgL.XNull(.Rows(I)("Code"))
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
            TxtSessionProgramme.Enabled = False
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
                    'Call IniItemHelp(False, DGL1.AgSelectedValue(Col1BarCode, mRowIndex))
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        Dim mRowIndex As Integer, mColumnIndex As Integer

        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub

        If Topctrl1.Mode = "Browse" Then Exit Sub

        mRowIndex = DGL1.CurrentCell.RowIndex
        mColumnIndex = DGL1.CurrentCell.ColumnIndex

        Try
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1IsYesNo
                    If e.KeyCode = Keys.Space Then
                        AgCL.ProcSetCheckColumnCellValue(DGL1, Col1IsYesNo)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
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
        TxtV_Type.Enter, TxtSite_Code.Enter, TxtRemark.Enter, TxtV_Date.Enter, TxtV_No.Enter, _
         TxtSemesterExam.Enter, TxtStreamYearSemester.Enter, TxtDocId.Enter, TxtSessionProgramme.Enter, TxtExamNature.Enter, TxtClassSection.Enter, TxtClassSectionSubSection.Enter

        Try
            Select Case sender.name
                Case TxtSessionProgramme.Name
                    If TxtClassSection.Text.ToString.Trim <> "" Then
                        TxtSessionProgramme.AgRowFilter = " 1=2 "
                    Else
                        TxtSessionProgramme.AgRowFilter = ""
                    End If

                Case TxtStreamYearSemester.Name
                    If TxtClassSection.Text.ToString.Trim <> "" Then
                        TxtStreamYearSemester.AgRowFilter = " 1=2 "
                    Else
                        TxtStreamYearSemester.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "
                    End If

                Case TxtClassSection.Name
                    If TxtStreamYearSemester.Text.ToString.Trim <> "" Then
                        TxtClassSection.AgRowFilter = " 1=2 "
                    Else
                        TxtClassSection.AgRowFilter = ""
                    End If

                Case TxtClassSectionSubSection.Name
                    TxtClassSectionSubSection.AgRowFilter = " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " "

                Case TxtSemesterExam.Name
                    If TxtStreamYearSemester.Text.ToString.Trim <> "" Then
                        TxtSemesterExam.AgRowFilter = " StreamYearSemesterCode = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " And ExamNature = " & AgL.Chk_Text(TxtExamNature.Text) & " "
                    End If
                    If TxtClassSection.Text.ToString.Trim <> "" Then
                        TxtSemesterExam.AgRowFilter = IIf(TxtClassSectionSubSection.Text.ToString.Trim <> "", " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " And ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " And Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & "  And ExamNature = " & AgL.Chk_Text(TxtExamNature.Text) & "", " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " And Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & "  And ExamNature = " & AgL.Chk_Text(TxtExamNature.Text) & "")
                    End If



            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtDocId.Validating, TxtV_Date.Validating, _
        TxtRemark.Validating, TxtSemesterExam.Validating, TxtStreamYearSemester.Validating, TxtExamNature.Validating, _
        TxtSessionProgramme.Validating, TxtDocId.Validating, TxtClassSection.Validating, TxtClassSectionSubSection.Validating

        Dim DtTemp As DataTable = Nothing
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

                Case TxtClassSection.Name, TxtClassSectionSubSection.Name
                    If TxtClassSection.Text.ToString.Trim = "" Then TxtClassSection.AgSelectedValue = ""
                    If TxtClassSectionSubSection.Text.ToString.Trim = "" Then TxtClassSectionSubSection.AgSelectedValue = ""

                    If TxtClassSection.Text.ToString.Trim <> "" Then TxtStreamYearSemester.AgSelectedValue = ""
                    If TxtClassSection.Text.ToString.Trim <> "" Then TxtSessionProgramme.AgSelectedValue = ""
                    If TxtClassSectionSubSection.Text.ToString.Trim <> "" Then TxtStreamYearSemester.AgSelectedValue = ""


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

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        TxtTotalStudent.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1AdmissionDocId, I).Value Is Nothing Then .Item(Col1AdmissionDocId, I).Value = ""
                If .Item(Col1IsYesNo, I).Value Is Nothing Then .Item(Col1IsYesNo, I).Value = False

                Try
                    If .Item(Col1AdmissionDocId, I).Value = "" Then .Item(Col1IsYesNo, I).Value = False
                Catch ex As Exception

                End Try

                If .Item(Col1AdmissionDocId, I).Value <> "" And .Item(Col1IsYesNo, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                    TxtTotalStudent.Text = Val(TxtTotalStudent.Text) + 1
                End If
            Next
        End With
    End Sub
    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL1.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1IsYesNo
                    Call AgL.ProcSetCheckColumnCellValue(DGL1, Col1IsYesNo)
                    ProcSetPresentCellColour(mRowIndex)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub
    Private Sub ProcSetPresentCellColour(ByVal IntRowIndex As Integer)
        Try
            If DGL1.Item(Col1IsYesNo, IntRowIndex).Value Is Nothing Then DGL1.Item(Col1IsYesNo, IntRowIndex).Value = ""
            If DGL1.Item(Col1IsYesNo, IntRowIndex).Value.ToString.Trim = "" Then DGL1.Item(Col1IsYesNo, IntRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue


            DGL1.CurrentCell = DGL1(Col1IsYesNo, IntRowIndex)

            DGL1.CurrentCell.Style.BackColor = Color.White
            If DGL1.Item(Col1IsYesNo, IntRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                DGL1.CurrentCell.Style.ForeColor = Color.Blue
            Else
                DGL1.CurrentCell.Style.ForeColor = Color.Red
            End If
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
                Case Col1IsYesNo
                    Call Calculation()
                    ProcSetPresentCellColour(mRowIndex)
            End Select

        Catch ex As Exception

        End Try
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
            'If AgL.RequiredField(TxtSessionProgramme, "Session/Programme") Then Exit Function
            'If AgL.RequiredField(TxtStreamYearSemester, "Semester") Then Exit Function
            If AgL.RequiredField(TxtSemesterExam, "Semester/Exam") Then Exit Function

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblStreamYearSemester.Tag) Then
                MsgBox("Stream/Year/Semester Is Not Valid!...") : TxtStreamYearSemester.Focus() : Exit Function
            End If


            If (Not AgL.StrCmp(TxtStreamYearSemester.AgSelectedValue, LblSemesterExam.Tag)) Or _
                      (Not AgL.StrCmp(TxtExamNature.Text, LblSemesterExamReq.Tag)) Then
                MsgBox("Semester/Exam Is Not Valid!...") : TxtSemesterExam.Focus() : Exit Function
            End If
           

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1AdmissionDocId) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1AdmissionDocId & "") Then Exit Function


            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            mQry = "SELECT IsNull(Count(*),0) Cnt " & _
                    " FROM Exam_SemesterExamAdmission A " & _
                    " WHERE A.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " AND " & _
                    " A.SemesterExam = " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & " And " & _
                    " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " A.DocId <> '" & mSearchCode & "' ") & " "
            If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) > 0 Then MsgBox(TxtSemesterExam.Text & " Is Already Created!...") : TxtSemesterExam.Focus() : Exit Function

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
        Dim mCondStr$ = "", bStrViewClassSectionSemesterAdmission$ = "", bStrViewOpenElectiveSemesterAdmission$ = "", bStrTempViewSectionAdmission$ = ""
        Dim bBlnIsOpenElectiveSection As Boolean = False
        Dim bCondQry$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If AgL.RequiredField(TxtSite_Code) Then Exit Sub
            If AgL.RequiredField(TxtSemesterExam, "Semester/Exam") Then Exit Sub


            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblStreamYearSemester.Tag) Then
                MsgBox("Stream/Year/Semester Is Not Valid!...") : TxtStreamYearSemester.Focus() : Exit Sub
            End If

            If (Not AgL.StrCmp(TxtStreamYearSemester.AgSelectedValue, LblSemesterExam.Tag)) Or _
                          (Not AgL.StrCmp(TxtExamNature.Text, LblSemesterExamReq.Tag)) Then
                MsgBox("Semester/Exam Is Not Valid!...") : TxtSemesterExam.Focus() : Exit Sub
            End If

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

            bCondQry = "SELECT Sa.AdmissionDocId " & _
                        " FROM Exam_SemesterExamAdmission S " & _
                        " LEFT JOIN Exam_SemesterExamAdmission1 Sa ON S.DocId = Sa.DocId " & _
                        " Where S.SemesterExam = " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & " And " & _
                        " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " S.DocId = '" & mSearchCode & "' ") & " "

            If TxtClassSection.Text.Trim <> "" Then
                mQry = "SELECT V1.DocId as AdmissionDocId, V1.AdmissionID, Convert(Bit, 1) AS YesNo, Null As Code, V1.StudentName As StudentName,V1.CurrentSemester " & _
                       " FROM ((" & bStrTempViewSectionAdmission & ") Csa " & _
                       " Inner Join (Select A.* From ViewSch_Admission A With (NoLock) Where A.CurrentSemester In (Select StreamYearSemester From Exam_SemesterExam2 E2 WITH (NoLock) WHERE E2.Code = " & AgL.Chk_Text(TxtSemesterExam.AgSelectedValue) & ") ) V1 ON V1.DocId = Csa.AdmissionDocId)  " & _
                       " Where " & AgL.PubSiteCondition("V1.Site_Code", TxtSite_Code.AgSelectedValue) & " And " & _
                       " " & mCondStr & "  And" & _
                       " V1.DocId NOT IN (" & bCondQry & ") And V1.LeavingDate IS NULL " & _
                       " UNION ALL " & _
                       " Select A1.AdmissionDocId, V1.AdmissionID, Convert(bit,1) As YesNo, A1.Code, V1.StudentName As StudentName ,'' as CurrentSemester " & _
                       " From Exam_SemesterExamAdmission1 A1 " & _
                       " LEFT JOIN ViewSch_Admission V1 ON A1.AdmissionDocId = V1.DocId " & _
                       " Where A1.DocId = '" & mSearchCode & "'" & _
                       " Order By StudentName "
            Else
                If TxtStreamYearSemester.Text.Trim <> "" Then
                    mQry = "SELECT V1.DocId as AdmissionDocId, V1.AdmissionID, Convert(Bit, 1) AS YesNo, Null As Code, V1.StudentName As StudentName ,V1.CurrentSemester " & _
                           " FROM (SELECT A.* FROM ViewSch_Admission A WITH (NoLock) WHERE A.CurrentSemester =  " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ") AS V1  " & _
                           " Where " & AgL.PubSiteCondition("V1.Site_Code", TxtSite_Code.AgSelectedValue) & " And " & _
                           " V1.DocId NOT IN (" & bCondQry & ") And V1.LeavingDate IS NULL " & _
                           " UNION ALL " & _
                           " Select A1.AdmissionDocId, V1.AdmissionID, Convert(bit,1) As YesNo, A1.Code, V1.StudentName As StudentName  ,'' as CurrentSemester" & _
                           " From Exam_SemesterExamAdmission1 A1 " & _
                           " LEFT JOIN ViewSch_Admission V1 ON A1.AdmissionDocId = V1.DocId " & _
                           " Where A1.DocId = '" & mSearchCode & "'" & _
                           " Order By StudentName "
                End If
            End If
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL1.Item(Col1AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))
                        'DGL1.Item(Col1YesNo, I).Value = AgL.VNull(.Rows(I)("YesNo"))
                        If AgL.VNull(.Rows(I)("YesNo")) Then
                            DGL1.Item(Col1IsYesNo, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                        End If
                        DGL1.Item(Col1Code, I).Value = AgL.XNull(.Rows(I)("Code"))
                        DGL1.Item(Col1StreamYearSemester, I).Value = AgL.XNull(.Rows(I)("CurrentSemester"))
                    Next I
                    DGL1.CurrentCell = DGL1(Col1IsYesNo, 0) : DGL1.Focus()
                Else
                    'TxtClassSection.Enabled = True
                    'TxtStreamYearSemester.Enabled = True

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
