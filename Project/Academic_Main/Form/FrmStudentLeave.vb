Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmStudentLeave
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
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
            AgL.WinSetting(Me, 500, 880, 0, 0)
            IniGrid()
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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("L.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("L.Site_Code", AgL.PubSiteCode) & " "

            mQry = "Select L.Code As SearchCode " & _
                    " From Sch_StudentLeave L " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V1.DocId As Code, V1.StudentName As [Student Name], V1.AdmissionID, " & _
                    " V1.Student As StudentCode, V1.LeavingDate, V1.V_Date As AdmissionDate, V1.Status, V1.CurrentSemester " & _
                    " FROM ViewSch_Admission V1 " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " And " & _
                    " V1.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                    " Order By V1.StudentName "
            TxtAdmissionDocId.AgHelpDataSet(5) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT E.SubCode AS Code, Sg.Name " & _
                    " FROM Pay_Employee E " & _
                    " LEFT JOIN SubGroup Sg ON E.SubCode = Sg.SubCode " & _
                    " WHERE " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                    " ORDER BY Sg.Name "
            TxtLeavePassedBy.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)
            TxtLeaveApprovedBy.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

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

                    AgL.Dman_ExecuteNonQry("Delete From Sch_StudentLeave Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("L.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("L.Site_Code", AgL.PubSiteCode) & " "


            AgL.PubFindQry = "SELECT L.Code AS SearchCode, A.StudentName, A.AdmissionID , Convert(VARCHAR,L.V_Date,103) AS [Voucher Date], " & _
                                " Convert(VARCHAR,L.FromDate,103) AS [From Date], Convert(VARCHAR,L.ToDate,103) AS [To Date], L.TotalDays , L.PurposeOfLeave " & _
                                " FROM Sch_StudentLeave L " & _
                                " LEFT JOIN ViewSch_Admission A ON L.AdmissionDocId = A.DocId " & _
                                " LEFT JOIN SiteMast S ON L.Site_Code = S.Code " & mCondStr

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

            AgL.PubReportTitle = "Leave Application "
            RepName = "Academic_StudentLeave" : RepTitle = "Leave Application"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If



            strQry = " SELECT L.Code AS LeaveCode, L.Div_Code, L.Site_Code, Sm.Name AS Site_Name, L.V_Date, L.AdmissionDocId, L.FromDate, L.ToDate, " & _
                     " L.TotalDays, L.PurposeOfLeave, L.LeavePassedBy AS LeavePassedByCode, L.LeaveApprovedBy AS LeaveApprovedByCode, L.Remark, L.PreparedBy, L.U_EntDt, L.U_AE, L.Edit_Date, L.ModifiedBy, " & _
                     " A.AdmissionID , A.StudentName , A.StudentDispName , A.FatherName , A.MotherName , A.SessionProgrammeStreamDesc , " & _
                     " A.SessionManualCode , A.ProgrammeManualCode , S.Add1 , S.add2 , S.Add3 , S.CityName , S.PIN , S.Phone , S.Mobile , S.FAX , S.EMail , S.Sex , " & _
                     " Sg1.Name AS LeavePassedByName,  Sg2.Name As LeaveApprovedByName, '" & AgL.PubUserName & "' As PrintedBy " & _
                     " FROM Sch_StudentLeave L " & _
                     " LEFT JOIN SiteMast Sm On L.Site_Code = Sm.Code LEFT JOIN ViewSch_Admission A ON L.AdmissionDocId = A.DocId " & _
                     " LEFT JOIN ViewSch_Student S ON A.Student = S.SubCode LEFT JOIN SubGroup Sg1 ON L.LeavePassedBy = Sg1.SubCode " & _
                     " LEFT JOIN SubGroup Sg2 ON L.LeaveApprovedBy = Sg2.SubCode WHERE L.Code = '" & mDocId & "'"
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
        Dim mTrans As Boolean = False
        Dim bAmount As Double = 0

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_StudentLeave ( " & _
                        " Code, Div_Code, Site_Code, V_Date, AdmissionDocId, FromDate, ToDate, TotalDays, PurposeOfLeave, " & _
                        " LeavePassedBy, LeaveApprovedBy, Remark, " & _
                        " PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtFromDate.Text) & ", " & AgL.ConvertDate(TxtToDate.Text) & ", " & Val(TxtTotalDays.Text) & ", " & AgL.Chk_Text(TxtPurposeOfLeave.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtLeavePassedBy.AgSelectedValue) & ", " & AgL.Chk_Text(TxtLeaveApprovedBy.AgSelectedValue) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_StudentLeave " & _
                        " SET  " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                        " FromDate = " & AgL.ConvertDate(TxtFromDate.Text) & ", " & _
                        " ToDate = " & AgL.ConvertDate(TxtToDate.Text) & ", " & _
                        " TotalDays = " & Val(TxtTotalDays.Text) & ", " & _
                        " PurposeOfLeave = " & AgL.Chk_Text(TxtPurposeOfLeave.Text) & ", " & _
                        " LeavePassedBy = " & AgL.Chk_Text(TxtLeavePassedBy.AgSelectedValue) & ", " & _
                        " LeaveApprovedBy = " & AgL.Chk_Text(TxtLeaveApprovedBy.AgSelectedValue) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE Code = '" & mSearchCode & "' "


                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            Try
                If AgLibrary.ClsConstant.IsSmsActive Then
                    Dim bStrSMS$ = "", bStrMobileNo$ = "", bStrCategory$ = "", bStrSubCode$ = "", bStrCurrentSemester$ = ""
                    Dim bBlnActiveEvent As Boolean = False
                    Dim bDtSmsEvent As DataTable = Nothing
                    Dim DrTemp As DataRow() = Nothing
                    Dim bDtTemp As DataTable = Nothing

                    DrTemp = TxtAdmissionDocId.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & "")
                    If DrTemp.Length > 0 Then
                        bStrSubCode = AgL.XNull(DrTemp(0)("StudentCode"))
                        bStrCurrentSemester = AgL.XNull(DrTemp(0)("CurrentSemester"))
                    End If


                    mQry = "SELECT E.* FROM Sms_Event E  WITH (NoLock) WHERE E.Event = '" & ClsMain.SmsEvent.StudentLeave & "'"
                    bDtSmsEvent = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

                    If bDtSmsEvent.Rows.Count > 0 Then
                        bStrCategory = AgL.XNull(bDtSmsEvent.Rows(0)("Category")).ToString

                        bBlnActiveEvent = IIf(AgL.XNull(bDtSmsEvent.Rows(0)("Message")).ToString.Trim <> "", True, False)
                    End If
                    If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()

                    If bBlnActiveEvent Then
                        bStrSMS = TxtAdmissionDocId.Text + " is on leave from " & TxtFromDate.Text & " To " & TxtToDate.Text & "."

                        If bStrSMS.Trim <> "" Then
                            'SMS To Parents
                            mQry = "SELECT Right(IsNull(Sg.PMobile,''),10) AS Mobile  FROM SubGroup Sg WITH (NoLock) WHERE Sg.SubCode = " & AgL.Chk_Text(bStrSubCode) & ""
                            bStrMobileNo = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar).ToString

                            If bStrMobileNo.Trim <> "" Then
                                AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, TxtV_Date.Text, bStrCategory, bStrSubCode, bStrMobileNo, TxtV_Date.Text, bStrSMS)
                            End If

                            'SMS To OC
                            mQry = "SELECT TOP 1 Oc.OC As SubCode, Right(IsNull(Sg.Mobile,''),10) AS Mobile " & _
                                    " FROM Sch_SessionProgrammeStreamOC Oc WITH (NoLock) " & _
                                    " INNER JOIN  " & _
                                    " 		(SELECT Sem.SessionProgrammeStreamCode " & _
                                    " 		FROM ViewSch_StreamYearSemester Sem WITH (NoLock)  " & _
                                    " 		WHERE Sem.Code = '" & bStrCurrentSemester & "' " & _
                                    " 		) AS vSem ON vSem.SessionProgrammeStreamCode = Oc.SessionProgrammeStream  " & _
                                    " LEFT JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = Oc.OC  " & _
                                    " WHERE " & AgL.Chk_Text(TxtV_Date.Text) & " >= Oc.FromDate " & _
                                    " ORDER BY Oc.FromDate Desc  "
                            bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                            If bDtTemp.Rows.Count > 0 Then
                                bStrSubCode = AgL.XNull(bDtTemp.Rows(0)("SubCode")).ToString
                                bStrMobileNo = AgL.XNull(bDtTemp.Rows(0)("Mobile")).ToString
                            End If
                            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()

                            If bStrMobileNo.Trim <> "" Then
                                AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, TxtV_Date.Text, bStrCategory, bStrSubCode, bStrMobileNo, TxtV_Date.Text, bStrSMS)
                            End If

                            Call AgL.SendSms(AgL)
                        End If


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

                Topctrl1.FButtonClick(0)

                If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Call PrintDocument(mDocId)
                End If

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
        Dim mTransFlag As Boolean = False

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
                mQry = "Select L.*, A.LeavingDate, A.V_Date As AdmissionDate, A.Status, A.AdmissionId " & _
                        " From Sch_StudentLeave L " & _
                        " Left Join Sch_Admission A On L.AdmissionDocId = A.DocId " & _
                        " Where L.Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtAdmissionDocId.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionDocId"))
                        LblAdmissionDocId.Tag = Format(AgL.XNull(.Rows(0)("AdmissionDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblAdmissionDocIdReq.Tag = Format(AgL.XNull(.Rows(0)("LeavingDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtAdmissionID.Text = AgL.XNull(.Rows(0)("AdmissionID"))
                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtFromDate.Text = Format(AgL.XNull(.Rows(0)("FromDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtToDate.Text = Format(AgL.XNull(.Rows(0)("ToDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtTotalDays.Text = AgL.VNull(.Rows(0)("TotalDays"))
                        TxtPurposeOfLeave.Text = AgL.XNull(.Rows(0)("PurposeOfLeave"))
                        TxtLeavePassedBy.AgSelectedValue = AgL.XNull(.Rows(0)("LeavePassedBy"))
                        TxtLeaveApprovedBy.AgSelectedValue = AgL.XNull(.Rows(0)("LeaveApprovedBy"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) Cnt " & _
                        " FROM Sch_StudentAttendance1 At1 " & _
                        " LEFT JOIN Sch_StudentAttendance At ON  At1.Code = At.Code " & _
                        " WHERE At1.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " AND " & _
                        " At.A_Date Between " & AgL.ConvertDate(TxtFromDate) & " And " & AgL.ConvertDate(TxtToDate) & " "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then mTransFlag = True

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
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtAdmissionID.Enabled = False
            TxtTotalDays.Enabled = False
            '<Executable Code>
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtAdmissionDocId.Enter, TxtFromDate.Enter, TxtToDate.Enter, TxtLeaveApprovedBy.Enter, TxtLeavePassedBy.Enter, _
        TxtRemark.Enter, TxtTotalDays.Enter
        Try
            Select Case sender.name
                Case TxtAdmissionDocId.Name
                    TxtAdmissionDocId.AgRowFilter = " LeavingDate Is Null And " & _
                                                    " AdmissionDate <= " & AgL.ConvertDate(TxtFromDate.Text) & " And " & _
                                                    " Status <> '" & Academic_ProjLib.ClsMain.AdmissionStatus_Ex & "' "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtAdmissionDocId.Validating, TxtSite_Code.Validating, TxtRemark.Validating, TxtAdmissionID.Validating, _
          TxtFromDate.Validating, TxtToDate.Validating, TxtPurposeOfLeave.Validating, TxtLeaveApprovedBy.Validating, TxtLeavePassedBy.Validating


        Try
            Select Case sender.NAME
                Case TxtFromDate.Name, TxtToDate.Name
                    If sender.Text.Trim = "" Then sender.Text = AgL.PubLoginDate

                Case TxtAdmissionDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtAdmissionID.Text = ""
                        LblAdmissionDocId.Tag = ""
                        LblAdmissionDocIdReq.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                TxtAdmissionID.Text = AgL.XNull(.Item("AdmissionID", .CurrentCell.RowIndex).Value)
                                LblAdmissionDocId.Tag = Format(AgL.XNull(.Item("AdmissionDate", .CurrentCell.RowIndex).Value), AgLibrary.ClsConstant.DateFormat_ShortDate)
                                LblAdmissionDocIdReq.Tag = Format(AgL.XNull(.Item("LeavingDate", .CurrentCell.RowIndex).Value), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            End With
                        End If
                    End If

            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        TxtTotalDays.Text = ""

        If TxtFromDate.Text.Trim <> "" And TxtToDate.Text.Trim <> "" Then
            TxtTotalDays.Text = DateDiff(DateInterval.Day, CDate(TxtFromDate.Text), CDate(TxtToDate.Text)) + 1
        End If

    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtFromDate, "From Date") Then Exit Function
            If AgL.RequiredField(TxtToDate, "To Date") Then Exit Function
            If AgL.RequiredField(TxtAdmissionDocId, "Student") Then Exit Function
            If AgL.RequiredField(TxtLeavePassedBy, "Passed By") Then Exit Function
            If AgL.RequiredField(TxtLeaveApprovedBy, "Approved By") Then Exit Function

            If CDate(TxtFromDate.Text) < CDate(LblAdmissionDocId.Tag) Then
                MsgBox("From Date Can't Be Less Than From " & LblAdmissionDocId.Tag & "!...")
                TxtFromDate.Focus() : Exit Function
            End If

            If LblAdmissionDocIdReq.Tag.ToString.Trim <> "" Then
                If CDate(TxtFromDate.Text) > CDate(LblAdmissionDocIdReq.Tag) Then
                    MsgBox("From Date Can't Be Greater Than From " & LblAdmissionDocIdReq.Tag & "!...")
                    TxtFromDate.Focus() : Exit Function
                End If

                If CDate(TxtToDate.Text) > CDate(LblAdmissionDocIdReq.Tag) Then
                    MsgBox("To Date Can't Be Greater Than From " & LblAdmissionDocIdReq.Tag & "!...")
                    TxtToDate.Focus() : Exit Function
                End If
            End If

            If CDate(TxtFromDate.Text) > CDate(TxtV_Date.Text) Then
                MsgBox("From Date Can't Be Greater Than From " & TxtV_Date.Text & "!...")
                TxtFromDate.Focus() : Exit Function
            End If

            If CDate(TxtToDate.Text) < CDate(TxtFromDate.Text) Then
                MsgBox("To Date Can't Be Less Than From " & TxtFromDate.Text & "!...")
                TxtToDate.Focus() : Exit Function
            End If


            mQry = "SELECT IsNull(Count(*),0) Cnt " & _
                    " FROM Sch_StudentAttendance1 At1 " & _
                    " LEFT JOIN Sch_StudentAttendance At ON  At1.Code = At.Code " & _
                    " WHERE At1.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " AND " & _
                    " At.A_Date Between " & AgL.ConvertDate(TxtFromDate) & " And " & AgL.ConvertDate(TxtToDate) & " AND " & _
                    " At1.IsPresent <> 0 "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                MsgBox("Attendance Exists For Selected Period!...")
                TxtFromDate.Focus() : Exit Function
            End If

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetMaxId("Sch_StudentLeave", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)
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
        TxtV_Date.Focus()
    End Sub

End Class
