Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class FrmEmployeeDayAttendance
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Employee As Byte = 1
    Private Const Col1IsPresent As Byte = 2
    Private Const Col1IsLeaveTaken As Byte = 3
    Dim EconAtt As New SqlConnection
    Dim StrTblParam As String = ""
    Dim StrTblParamIni As String = " Declare @TblParm AS Table(AttendanceDate SmallDateTime, " & _
                                 " AttendanceCode nvarchar(20) )"
    Dim mBlnImportFlag As Boolean = False, mBlnIsAttendanceExists As Boolean = False


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
            .AddAgTextColumn(DGL1, "Dgl1Employee", 300, 8, "Employee", True, True, False)
            .AddAgCheckColumn(DGL1, "Dgl1IsPresent", 60, "Present", True)
            .AddAgTextColumn(DGL1, "Dgl1IsLeaveTaken", 70, 0, "Leave Taken", True, True, False)
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

            mQry = "Select S.Code As SearchCode " & _
                    " From Pay_DayAttendance S " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Dim MDI As New MDIMain
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT E.SubCode AS Code, Sg.Name " & _
                    " FROM Pay_Employee E " & _
                    " LEFT JOIN SubGroup Sg ON E.SubCode = Sg.SubCode " & _
                    " WHERE (IsNull(E.IsTeachingStaff,0)<>0 or IsNull(E.CanTakeClass,0)<>0) And " & _
                    " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                    " ORDER BY Sg.Name "
            DGL1.AgHelpDataSet(Col1Employee, 0) = AgL.FillData(mQry, AgL.GCn)
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

                    AgL.Dman_ExecuteNonQry("Delete From Pay_DayAttendance1 Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Pay_DayAttendance Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        DispText(False)
    End Sub

    Private Sub Topctrl_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtA_Date.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQry = "SELECT A.Code AS SearchCode, S.Name AS [Site Name], " & AgL.ConvertDateField("A.A_Date") & " As [Attendance Date] " & _
                                " FROM Pay_DayAttendance A " & _
                                " LEFT JOIN SiteMast S on A.Site_Code = S.Code  " & _
                                " " & mCondStr & " "

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

            AgL.PubReportTitle = "Teacher Attendance"
            RepName = "TT_Teacher_Attendance" : RepTitle = "Teacher Attendance"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " SELECT pd.A_Date,pd.PreparedBy ,pemp.Name,CASE WHEN pd1.IsPresent=1 THEN 'Present' ELSE 'Absent' END AS [Present/Absent], " & _
                     " (CASE WHEN pd1.IsPresent = 0 THEN 0 ELSE 1 END)  TotalPresent, (CASE WHEN pd1.IsPresent = 0 THEN 1 ELSE 0 END)  TotalAbsent " & _
                     " FROM Pay_DayAttendance pd LEFT JOIN Pay_DayAttendance1 pd1 ON pd.Code=pd1.Code " & _
                     " LEFT JOIN SubGroup Pemp ON pd1.Employee=pemp.SubCode Where pd.Code = '" & mSearchCode & "'"


            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_TimeTable & "\" & RepName & ".ttx", True)
            mCrd.Load(PLib.PubReportPath_TimeTable & "\" & RepName & ".rpt")
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
        Dim bStrApprovedDate$ = ""

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True

            If mBlnImportFlag And mBlnIsAttendanceExists Then
                AgL.Dman_ExecuteNonQry("Delete From Pay_DayAttendance1 Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                AgL.Dman_ExecuteNonQry("Delete From Pay_DayAttendance Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
            End If

            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Pay_DayAttendance ( " & _
                        " Code, A_Date, Remark, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE " & _
                        " ) VALUES ( " & _
                        " '" & mSearchCode & "', " & AgL.ConvertDate(TxtA_Date.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Pay_DayAttendance " & _
                        " SET  " & _
                        " 	A_Date = " & AgL.ConvertDate(TxtA_Date.Text) & ", " & _
                        " 	Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " 	U_AE = 'E', " & _
                        " 	Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " 	ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE Code = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            If Topctrl1.Mode = "Edit" Then
                AgL.Dman_ExecuteNonQry("Delete From Pay_DayAttendance1 Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Employee, I).Value <> "" Then
                        bSr += 1

                        mQry = "INSERT INTO Pay_DayAttendance1 ( " & _
                                " Code, Sr, Employee, IsPresent ) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & bSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1Employee, I)) & "," & _
                                " " & IIf(AgL.StrCmp(.Item(Col1IsPresent, I).Value, AgLibrary.ClsConstant.StrCheckedValue), 1, 0) & " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If Topctrl1.Mode = "Add" Then
                If AgLibrary.ClsConstant.IsSmsActive Then
                    Call ProcCreateSms(Academic_TimeTable.ClsMain.SmsEvent.TeacherAttendance)
                End If
            End If

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

    Private Sub ProcCreateSms(ByVal StrEvent As String)
        Dim bDtMain As DataTable = Nothing
        Dim bDtSem As DataTable = Nothing
        Dim bDtHOD As DataTable = Nothing
        Dim bIntI% = 0
        Dim bStrSMS$ = "", bStrCategory$ = "", bStrSmsDate$ = "", bStrSubCode$ = "", bStrMDMobileNo$ = "", bStrHODMDMobileNo$ = "", bStrHodSubCode$ = "", bStrEmployeeName$ = ""
        Dim bStrSmsQry$ = "", bStrMainTable$ = "", bStrMainField$ = ""
        Dim bDtSmsEvent As DataTable = Nothing

        Try
            Me.Cursor = Cursors.WaitCursor
            If Not AgLibrary.ClsConstant.IsSmsActive Then Exit Sub

            If AgL.StrCmp(StrEvent, Academic_TimeTable.ClsMain.SmsEvent.TeacherAttendance) Then
                bStrMainTable = "Pay_DayAttendance"
                bStrMainField = "T.A_Date"
            End If

            mQry = "SELECT E.* FROM Sms_Event E  WITH (NoLock) WHERE E.Event = '" & StrEvent & "'"
            bDtSmsEvent = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            If bDtSmsEvent.Rows.Count > 0 Then
                bStrSMS = AgL.XNull(bDtSmsEvent.Rows(0)("Message")).ToString
                bStrCategory = AgL.XNull(bDtSmsEvent.Rows(0)("Category")).ToString
            End If
            If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()
            If bStrSMS.Trim = "" Then Exit Sub

            mQry = "SELECT ST.Employee, Sg.Name As EmployeeName, " & _
                    " T.A_Date AS V_Date, " & _
                    " Right(IsNull(SS.Mobile,''),10) AS MDMobile " & _
                    " FROM (" & bStrMainTable & " T WITH (NoLock) " & _
                    " LEFT JOIN SiteMast SS  WITH (NoLock) ON SS.Code = T.Site_Code) " & _
                    " LEFT JOIN Pay_DayAttendance1 ST WITH (noLock) ON T.code=ST.code  " & _
                    " LEFT JOIN SubGroup Sg WITH (NoLock) ON SG.SubCode = St.Employee " & _
                    " WHERE T.Code = '" & mSearchCode & "'  " & _
                    " And Isnull(ST.ISPresent,0)=0 "
            bDtMain = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            If bDtMain.Rows.Count > 0 Then
                For bIntI = 0 To bDtMain.Rows.Count - 1
                    bStrSubCode = AgL.XNull(bDtMain.Rows(bIntI)("Employee"))
                    bStrEmployeeName = AgL.XNull(bDtMain.Rows(bIntI)("EmployeeName"))
                    bStrMDMobileNo$ = AgL.XNull(bDtMain.Rows(bIntI)("MDMobile"))
                    bStrSmsDate = Format(AgL.XNull(bDtMain.Rows(bIntI)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                    bStrSMS = bStrEmployeeName + Space(1) + "Is Absent on : " + bStrSmsDate

                    mQry = "SELECT TOP 1 Sg.SubCode , Right(IsNull(Sg.Mobile,''),10) AS HODMobile " & _
                        " FROM TT_TimeTable T  " & _
                        " LEFT JOIN TT_TimeTable1 TT ON TT.Code = T.Code " & _
                        " LEFT JOIN Sch_ClassSection C ON C.Code = T.ClassSection " & _
                        " LEFT JOIN Sch_ClassSectionSemester CS ON CS.ClassSection = C.Code " & _
                        " LEFT JOIN ViewSch_StreamYearSemester SS ON SS.Code = CS.StreamYearSemester " & _
                        " LEFT JOIN Sch_SessionProgrammeStreamOC Oc ON SS.SessionProgrammeStreamCode=Oc.SessionProgrammeStream " & _
                        " LEFT JOIN SubGroup Sg WITH (NoLock)  ON Oc.OC = SG.SubCode " & _
                        " WHERE TT.Teacher = '" & AgL.XNull(bDtMain.Rows(0)("Employee")) & "' " & _
                        " AND Len(Sg.Mobile) >= 10 " & _
                        " AND '" & bStrSmsDate & "' BETWEEN  Oc.FromDate AND IsNull(Oc.UptoDate,'" & bStrSmsDate & "')" & _
                        " ORDER BY Oc.FromDate Desc "
                    bDtHOD = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                    If bDtHOD.Rows.Count > 0 Then
                        bStrHodSubCode = AgL.XNull(bDtHOD.Rows(0)("SubCode"))
                        bStrHODMDMobileNo = AgL.XNull(bDtHOD.Rows(0)("HODMobile"))
                    End If
                    If bDtHOD IsNot Nothing Then bDtHOD.Dispose()

                    If bStrSMS.Trim <> "" And bStrMDMobileNo$.Trim <> "" And bStrSmsDate.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, bStrSmsDate, bStrCategory, "", bStrMDMobileNo$, AgL.PubLoginDate, bStrSMS)
                    End If

                    If bStrSMS.Trim <> "" And bStrHODMDMobileNo.Trim <> "" And bStrSmsDate.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, bStrSmsDate, bStrCategory, bStrHodSubCode, bStrHODMDMobileNo, AgL.PubLoginDate, bStrSMS)
                    End If
                Next

                Call AgL.SendSms(AgL)
            End If
            If bDtMain IsNot Nothing Then bDtMain.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            If bDtMain IsNot Nothing Then bDtMain.Dispose()
            If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()
            If bDtHOD IsNot Nothing Then bDtHOD.Dispose()
        End Try
    End Sub

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
                mQry = "Select S.*, V1.TotalPresent, V1.TotalAbsent, V1.TotalEmployee " & _
                        " From Pay_DayAttendance S " & _
                        " Left Join (SELECT A1.Code, Sum(CASE WHEN A1.IsPresent = 0 THEN 0 ELSE 1 END)  TotalPresent, Sum(CASE WHEN A1.IsPresent = 0 THEN 1 ELSE 0 END)  TotalAbsent, Count(A1.Employee)  TotalEmployee FROM Pay_DayAttendance1 A1 Where A1.Code = '" & mSearchCode & "' GROUP BY A1.Code ) V1 On S.Code = V1.Code " & _
                        " Where S.Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtA_Date.Text = Format(AgL.XNull(.Rows(0)("A_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        TxtTotalAbsent.Text = AgL.VNull(.Rows(0)("TotalAbsent"))
                        TxtTotalPresent.Text = AgL.VNull(.Rows(0)("TotalPresent"))
                        TxtTotalEmployee.Text = AgL.VNull(.Rows(0)("TotalEmployee"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select Sa.* " & _
                        " From Pay_DayAttendance1 Sa " & _
                        " Where Sa.Code = '" & mSearchCode & "' " & _
                        " "
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1Employee, I) = AgL.XNull(.Rows(I)("Employee"))
                            DGL1.Item(Col1IsPresent, I).Value = IIf(AgL.VNull(.Rows(I)("IsPresent")), AgLibrary.ClsConstant.StrCheckedValue, AgLibrary.ClsConstant.StrUnCheckedValue)
                            DGL1.Item(Col1IsLeaveTaken, I).Value = IIf(FunIsEmployeeOnLeave(AgL.XNull(.Rows(I)("Employee")), TxtA_Date.Text), "Yes", "No")
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

            TxtFromDate.Enabled = BtnImprtFromDB.Enabled
            TxtToDate.Enabled = BtnImprtFromDB.Enabled

        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : mBlnIsAttendanceExists = False

        DGL1.RowCount = 1 : DGL1.Rows.Clear()

    End Sub



    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
    End Sub


    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Employee
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
                Case Col1IsPresent
                    If e.KeyCode = Keys.Space Then
                        AgCL.ProcSetCheckColumnCellValue(DGL1, Col1IsPresent)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL1.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1IsPresent
                    Call AgCL.ProcSetCheckColumnCellValue(DGL1, Col1IsPresent)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .CurrentCell.ColumnIndex
                    'Case Col1Employee
                    '    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                    '        '<Executable Code>
                    '        DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                    '    Else
                    '        If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                    '            DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")

                    '            'DGL1.Item(Col1AdmissionID, mRowIndex).Value = AgL.VNull(DrTemp(0)("AdmissionID"))
                    '        End If
                    '        DrTemp = Nothing
                    '    End If
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGL1.CellValidating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .CurrentCell.ColumnIndex
                    Case Col1IsPresent
                        If DGL1.Item(Col1IsLeaveTaken, mRowIndex).Value Is Nothing Then DGL1.Item(Col1IsLeaveTaken, mRowIndex).Value = ""

                        If DGL1.Item(mColumnIndex, e.RowIndex).Value.ToString = AgLibrary.ClsConstant.StrCheckedValue And AgL.StrCmp(DGL1.Item(Col1IsLeaveTaken, e.RowIndex).Value.ToString, "Yes") Then
                            If MsgBox("" & DGL1.Item(Col1Employee, mRowIndex).Value & " is On Leave!..." & vbCrLf & "Do You Want to Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                                e.Cancel = True : Exit Sub
                            End If
                        End If
                End Select
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGL1.CellFormatting
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = e.RowIndex
            mColumnIndex = e.ColumnIndex

            If DGL1.Item(Col1IsPresent, mRowIndex).Value Is Nothing Then DGL1.Item(Col1IsPresent, mRowIndex).Value = ""
            If DGL1.Item(Col1IsPresent, mRowIndex).Value.ToString.Trim = "" Then DGL1.Item(Col1IsPresent, mRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue


            DGL1.Item(Col1IsPresent, mRowIndex).Style.BackColor = Color.White
            If DGL1.Item(Col1IsPresent, mRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                DGL1.Item(Col1IsPresent, mRowIndex).Style.ForeColor = Color.Blue
            Else
                DGL1.Item(Col1IsPresent, mRowIndex).Style.ForeColor = Color.Red
            End If

        Catch ex As Exception

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
        TxtSite_Code.Enter, TxtRemark.Enter, TxtA_Date.Enter

        Try
            'Select Case sender.name

            'End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtRemark.Validating, TxtA_Date.Validating, TxtToDate.Validating

        Try
            Select Case sender.NAME
                Case TxtA_Date.Name
                    If TxtA_Date.Text.ToString.Trim = "" Then TxtA_Date.Text = AgL.PubLoginDate
                Case TxtToDate.Name
                    BtnImprtFromDB.Focus()
            End Select

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        TxtTotalEmployee.Text = ""
        TxtTotalAbsent.Text = ""
        TxtTotalPresent.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Employee, I).Value Is Nothing Then .Item(Col1Employee, I).Value = ""
                If .Item(Col1IsPresent, I).Value Is Nothing Then .Item(Col1IsPresent, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                If AgL.XNull(.Item(Col1IsPresent, I).Value).ToString.Trim = "" Then .Item(Col1IsPresent, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                If .Item(Col1Employee, I).Value <> "" Then
                    If AgL.StrCmp(.Item(Col1IsPresent, I).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                        TxtTotalPresent.Text = Val(TxtTotalPresent.Text) + 1
                    Else
                        TxtTotalAbsent.Text = Val(TxtTotalAbsent.Text) + 1
                    End If
                    TxtTotalEmployee.Text = Val(TxtTotalEmployee.Text) + 1
                End If
            Next
        End With
    End Sub


    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtA_Date, "Attendance Date") Then Exit Function

            mQry = "Select IsNull(count(*),0) Cnt " & _
                    " From Pay_DayAttendance A With (NoLock) " & _
                    " Where A.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " And " & _
                    " A.A_Date = " & AgL.ConvertDate(TxtA_Date.Text) & " And " & _
                    " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " A.Code <> '" & mSearchCode & "' ") & " "
            AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GcnRead)
            If AgL.ECmd.ExecuteScalar() > 0 Then mBlnIsAttendanceExists = True

            If mBlnImportFlag = False Then
                If mBlnIsAttendanceExists Then MsgBox("Attendance Already Exist!") : TxtA_Date.Focus() : Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1Employee) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1Employee & "") Then Exit Function

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Employee, I).Value.ToString.Trim <> "" Then
                        If mBlnImportFlag = False Then
                            If AgL.StrCmp(.Item(Col1IsLeaveTaken, I).Value, "Yes") And _
                                AgL.StrCmp(.Item(Col1IsPresent, I).Value, AgLibrary.ClsConstant.StrCheckedValue) Then

                                If MsgBox("" & .Item(Col1Employee, I).Value & " Is On Leave!..." & vbCrLf & "Want To Check Attendance?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Validation Check") = MsgBoxResult.No Then
                                    DGL1.CurrentCell = DGL1(Col1IsPresent, I)
                                    DGL1.Focus() : Exit Function
                                End If
                            End If
                        End If
                    End If
                Next
            End With

            If Topctrl1.Mode = "Add" Then
                If mBlnImportFlag And mBlnIsAttendanceExists Then
                    mQry = "Select A.Code " & _
                            " From Pay_DayAttendance A With (NoLock) " & _
                            " Where A.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " And " & _
                            " A.A_Date = " & AgL.ConvertDate(TxtA_Date.Text) & "  "
                    mSearchCode = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar).ToString

                Else
                    mSearchCode = AgL.GetMaxId("Pay_DayAttendance", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)
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

        TxtA_Date.Focus()
    End Sub


    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillStudent.Click
        Try
            Select Case sender.name
                Case BtnFillStudent.Name
                    Call ProcFillEmployee()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillEmployee()
        Dim DtTemp As DataTable
        Dim I As Integer
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If AgL.RequiredField(TxtSite_Code) Then Exit Sub

            mQry = "SELECT E.SubCode AS Employee, Sg.ManualCode  " & _
                    " FROM Pay_Employee E " & _
                    " LEFT JOIN SubGroup Sg ON E.SubCode = Sg.SubCode " & _
                    " WHERE (IsNull(E.IsTeachingStaff,0)<>0 or IsNull(E.CanTakeClass,0)<>0) And " & _
                    " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", TxtSite_Code.AgSelectedValue, "Sg.CommonAc") & " And " & _
                    " Case When E.DateOfResign Is Null Then " & AgL.ConvertDate(TxtA_Date.Text) & " Else E.DateOfResign End >= " & AgL.ConvertDate(TxtA_Date.Text) & " " & _
                    " ORDER BY Sg.Name "

            DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1Employee, I) = AgL.XNull(.Rows(I)("Employee"))


                        If FunIsEmployeeOnLeave(AgL.XNull(.Rows(I)("Employee")), TxtA_Date.Text) Then
                            DGL1.Item(Col1IsPresent, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                            DGL1.Item(Col1IsLeaveTaken, I).Value = "Yes"
                        Else
                            DGL1.Item(Col1IsPresent, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                            DGL1.Item(Col1IsLeaveTaken, I).Value = "No"
                        End If
                    Next I

                    DGL1.CurrentCell = DGL1(Col1IsPresent, 0) : DGL1.Focus()
                Else
                    MsgBox("No Employee Record Exists For Attendance!...")
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


    Private Function FunIsEmployeeOnLeave(ByVal StrSubCode As String, ByVal StrDate As String) As Boolean
        Dim bBlnReturn As Boolean = False
        Try
            mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                    " FROM (" & _
                    "       SELECT L.* FROM Pay_Leave L WITH (NoLock) " & _
                    "       WHERE L.SubCode = " & AgL.Chk_Text(StrSubCode) & " " & _
                    "       AND " & AgL.ConvertDate(StrDate) & " BETWEEN L.FromDate AND L.ToDate) vL " & _
                    " LEFT JOIN Voucher_Type Vt WITH (NoLock) ON Vt.V_Type = vL.V_Type " & _
                    " WHERE Vt.NCat = '" & ClsMain.Temp_NCat.EmployeeLeaveEntry & "' "
            bBlnReturn = IIf(AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar()) > 0, True, False)

        Catch ex As Exception
            bBlnReturn = False
            MsgBox(ex.Message)
        Finally
            FunIsEmployeeOnLeave = bBlnReturn
        End Try
    End Function

    Private Sub BtnImprtFromDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprtFromDB.Click
        Dim DsHeader As New DataSet
        Dim DsLine As New DataSet
        Dim DsAtt As New DataSet
        Dim J As Integer = 0
        Dim I As Integer = 0
        Dim Ds1 As New DataSet
        Try
            Me.Cursor = Cursors.WaitCursor
            mBlnImportFlag = True

            If Not FunConnectDB(AgL.XNull(DtSch_Enviro.Rows(0)("AttendanceUser")), _
                      AgL.XNull(DtSch_Enviro.Rows(0)("AttendancePassword")), _
                      AgL.XNull(DtSch_Enviro.Rows(0)("AttendanceDbName")), _
                      AgL.XNull(DtSch_Enviro.Rows(0)("AttendanceServer"))) Then

                Err.Raise(1, , "Error in establishing Connection With Attendance Database!...")
            End If

            If AgL.RequiredField(TxtFromDate, "From Date") Then Exit Sub
            If AgL.RequiredField(TxtToDate, "To Date") Then Exit Sub


            'Fetch Data**************
            mQry = "SELECT A.EmployeeId AS AttendanceCode , " & _
                    " Convert(SMALLDATETIME,Convert(VARCHAR,convert(SMALLDATETIME,A.InTime),106)) AS AttendanceDate" & _
                    " FROM AttendanceLogs A" & _
                    " WHERE(A.InTime Is Not NULL) AND Convert(SMALLDATETIME,Convert(VARCHAR,convert(SMALLDATETIME,A.InTime),106)) BETWEEN '" & TxtFromDate.Text & "' AND '" & TxtToDate.Text & "'"
            DsAtt = AgL.FillData(mQry, EconAtt)
            If DsAtt.Tables(0).Rows.Count > 0 Then

                'Insert Temp Table*****************
                StrTblParam = StrTblParamIni
                For I = 0 To DsAtt.Tables(0).Rows.Count - 1
                    StrTblParam += " INSERT INTO @TblParm  ( AttendanceDate, AttendanceCode) " & _
                                    " VALUES ( '" & Format(DsAtt.Tables(0).Rows(I).Item("AttendanceDate"), AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                                    " " & AgL.Chk_Text(DsAtt.Tables(0).Rows(I).Item("AttendanceCode")) & " " & _
                                    " ) "

                Next

                'Fetch Header Data*****************
                mQry = StrTblParam & _
                        " SELECT Sg.Site_Code, T.AttendanceDate " & _
                        " " & _
                        " FROM Pay_Employee E " & _
                        " LEFT JOIN SubGroup Sg WITH (NoLock) ON E.SubCode = Sg.SubCode " & _
                        " LEFT JOIN @TblParm T  ON Sg.AttendanceCode = T.AttendanceCode " & _
                        " Where sg.site_Code='" & AgL.PubSiteCode & "' AND T.AttendanceDate IS NOT NULL " & _
                        " Group By Sg.Site_Code, T.AttendanceDate " & _
                        " Order By Sg.Site_Code, T.AttendanceDate "
                DsHeader = AgL.FillData(mQry, AgL.GCn)
                If DsHeader.Tables(0).Rows.Count > 0 Then
                    For J = 0 To DsHeader.Tables(0).Rows.Count - 1
                        ''===========< Add >=======
                        Topctrl1.FButtonClick(0)
                        ''=========================

                        TxtSite_Code.AgSelectedValue = AgL.XNull(DsHeader.Tables(0).Rows(J)("Site_Code"))
                        TxtA_Date.Text = Format(AgL.XNull(DsHeader.Tables(0).Rows(J)("AttendanceDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                        'Fetch Line Data*****************
                        mQry = StrTblParam & _
                                " SELECT E.SubCode as EmployeeCode,Sg.Site_Code,T.AttendanceCode,T.AttendanceDate, " & _
                                " Convert(bit,Case When T.AttendanceCode Is Null Then 0 Else 1 End) As IsPresent " & _
                                " FROM Pay_Employee E " & _
                                " LEFT JOIN SubGroup Sg WITH (NoLock) ON E.SubCode = Sg.SubCode " & _
                                " LEFT JOIN @TblParm T ON Sg.AttendanceCode = T.AttendanceCode " & _
                                " Where sg.site_Code='" & AgL.XNull(DsHeader.Tables(0).Rows(J)("Site_Code")) & "' " & _
                                " And (IsNull(E.IsTeachingStaff,0)<>0 or IsNull(E.CanTakeClass,0)<>0) " & _
                                " and T.AttendanceDate='" & Format(AgL.XNull(DsHeader.Tables(0).Rows(J)("AttendanceDate")), AgLibrary.ClsConstant.DateFormat_ShortDate) & "'"
                        DsLine = AgL.FillData(mQry, AgL.GCn)
                        DGL1.RowCount = 1 : DGL1.Rows.Clear()
                        If DsLine.Tables(0).Rows.Count > 0 Then
                            For I = 0 To DsLine.Tables(0).Rows.Count - 1
                                DGL1.Rows.Add()
                                DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                                DGL1.AgSelectedValue(Col1Employee, I) = AgL.XNull(DsLine.Tables(0).Rows(I)("EmployeeCode"))
                                If AgL.VNull(DsLine.Tables(0).Rows(I)("IsPresent")) Then
                                    DGL1.Item(Col1IsPresent, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                                Else
                                    DGL1.Item(Col1IsPresent, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                                End If
                                DGL1.Item(Col1IsLeaveTaken, I).Value = IIf(FunIsEmployeeOnLeave(AgL.XNull(DsLine.Tables(0).Rows(I)("EmployeeCode")), Format(AgL.XNull(DsHeader.Tables(0).Rows(J)("AttendanceDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)), "Yes", "No")
                            Next I
                        End If

                        ''===========< Finally >==============
                        Topctrl1.FButtonClick(13)
                        ''===========< ******* >==============
                    Next
                End If
                MsgBox("Data Import Successfully...! ")
            Else
                MsgBox("No Record For Import...! ")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            mBlnImportFlag = False
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function FunConnectDB(ByVal AttDBUserSQL As String, ByVal AttDBPasswordSQL As String, ByVal AttDBName As String, ByVal AttServerName As String) As Boolean
        Dim bBlnReturn As Boolean = False
        Try
            EconAtt.ConnectionString = "Persist Security Info=False;User ID='" & AttDBUserSQL & "';pwd=" & AttDBPasswordSQL & ";Initial Catalog=" & AttDBName & ";Data Source=" & AttServerName
            EconAtt.Open()

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
        Finally
            FunConnectDB = bBlnReturn
        End Try
    End Function
   
End Class

