Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmInstallmentCreate
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mObjClsMain As New ClsMain(AgL, PLib)


    Protected Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Dgl1GridName As String = "Dgl1"

    Private Const Col1InstallmentDate As String = "Date"
    Private Const Col1InstallmentAmount As String = "Amount"
    Private Const Col1TotalAmount As String = "Total"
    Private Const Col1RemindBeforeDays As String = "Remind Before"
    Private Const Col1RemindAfterDays As String = "Remind After"
    Private Const Col1IsInActive As String = "In Active"
    Private Const Col1TempInstallmentDate As String = "Date"

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"
    Dim _RecordType As String = ""


    Public Property EntryMode() As String
        Get
            EntryMode = _EntryMode
        End Get
        Set(ByVal value As String)
            _EntryMode = value
        End Set
    End Property

    Public Property FormLocation() As System.Drawing.Point
        Get
            FormLocation = _FormLocation
        End Get
        Set(ByVal value As System.Drawing.Point)
            _FormLocation = value
        End Set
    End Property

    Public Property RecordId() As String
        Get
            RecordId = mSearchCode
        End Get
        Set(ByVal value As String)
            mSearchCode = value
        End Set
    End Property

    Public Property RecordType() As String
        Get
            RecordType = _RecordType
        End Get
        Set(ByVal value As String)
            _RecordType = value
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
        DTMaster = Nothing : mObjClsMain = Nothing
    End Sub

    Private Sub IniGrid()
        ''==============================================================================
        ''================< Complain Description Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgDateColumn(DGL1, Col1InstallmentDate, 100, Col1InstallmentDate, True, False, False)
            .AddAgNumberColumn(DGL1, Col1InstallmentAmount, 100, 8, 2, False, Col1InstallmentAmount, True, False, True)
            .AddAgNumberColumn(DGL1, Col1TotalAmount, 100, 8, 2, False, Col1TotalAmount, True, True, True)
            .AddAgNumberColumn(DGL1, Col1RemindBeforeDays, 40, 4, 0, False, Col1RemindBeforeDays, False, False, True)
            .AddAgNumberColumn(DGL1, Col1RemindAfterDays, 40, 4, 0, False, Col1RemindAfterDays, False, False, True)
            .AddAgCheckColumn(DGL1, Col1IsInActive, 50, Col1IsInActive, True)
            .AddAgDateColumn(DGL1, Col1TempInstallmentDate, 100, Col1TempInstallmentDate, False, True, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.Name = Dgl1GridName
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.AllowUserToAddRows = False
        ''==============================================================================
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
            AgL.WinSetting(Me, 650, 1000, _FormLocation.Y, _FormLocation.X)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            FIniMaster()
            Ini_List()
            DispText()

            If AgL.StrCmp(_EntryMode, "Add") Then
                Topctrl1.FButtonClick(0)
            Else
                MoveRec()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr$ = " WHERE 1=1 "

        mCondStr += " And H.EntryDate <= " & AgL.ConvertDate(AgL.PubEndDate) & " "
        mCondStr += " And H.RecordType = '" & ClsMain.RecordType.InstallentCreate & "' "

        mQry = "SELECT Convert(VARCHAR(36), H.UID) AS SearchCode " & _
                " FROM Sch_DueInstallment H " & mCondStr

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                   " Where 1=1 Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Div_Code, Div_Name From Division Order By Div_Name"
            TxtDiv_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.SubCode As Code, Sg.Name, vA1.AdmissionDate,  " & _
                    " CASE WHEN IsNull(Sg.CommonAc,1) <> 0 OR Sg.Site_Code = '" & AgL.PubSiteCode & "' THEN 'Yes' ELSE 'No' END AS CommonParty " & _
                    " FROM (SELECT A1.Student, Max(A1.V_Date) AS AdmissionDate FROM Sch_Admission A1 WHERE A1.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " GROUP BY A1.Student) vA1 " & _
                    " LEFT JOIN Sch_Student S ON vA1.Student = S.SubCode " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode = S.SubCode " & _
                    " Order By Sg.Name "
            TxtSubCode.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V1.DocId As Code, V1.StudentName As [Student Name], V1.AdmissionID [Admission Id], " & _
                    " V1.Student As StudentCode, V1.LeavingDate, V1.V_Date As AdmissionDate " & _
                    " FROM ViewSch_Admission V1 " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " And " & _
                    " V1.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                    " Order By V1.StudentName "
            TxtAdmissionDocId.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT E.SubCode As Code, Sg.Name, E.DateOfResign, " & _
                    " CASE WHEN IsNull(Sg.CommonAc,1) <> 0 OR Sg.Site_Code = '" & AgL.PubSiteCode & "' THEN 'Yes' ELSE 'No' END AS CommonParty, " & _
                    " CASE WHEN E.DateOfResign IS NULL THEN 'Yes' ELSE 'No' END AS IsActive " & _
                    " FROM Pay_Employee E " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode = E.SubCode  " & _
                    " WHERE E.DateOfJoin <= " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                    " ORDER BY Sg.Name "
            TxtEmployee.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()

        RecordType = ClsMain.RecordType.InstallentCreate
        TxtRecordType.Text = ClsMain.RecordType.InstallentCreate

        DispText(True)

        mSearchCode = AgL.GetGUID(AgL.Gcn_ConnectionString).ToString

        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtDiv_Code.AgSelectedValue = AgL.PubDivCode

        TxtEntryDate.Text = AgL.PubLoginDate
        Call Validating_Controls(TxtEntryDate)

        TxtEntryDate.Focus()

    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bStrTaskEntryMode$ = "Delete"
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If mSearchCode <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then
                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    mQry = "DELETE FROM Sch_DueInstallment1 WHERE UID = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "DELETE FROM Sch_DueInstallment WHERE UID = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

                    AgL.ETrans.Commit()
                    mTrans = False

                    If AgL.PubMoveRecApplicable Then
                        FIniMaster(1)
                        Topctrl1_tbRef()
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

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
        DispText(False)
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        'MsgBox("Permission Denied!..." & vbCrLf & "Task Is Assigned.")
        'Topctrl1.FButtonClick(14, True)
        'Exit Sub

        DispText(True)
        TxtSubCode.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr$ = " WHERE 1=1 "

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try
            mCondStr += " And H.EntryDate <= " & AgL.ConvertDate(AgL.PubEndDate) & " "
            mCondStr += " And H.RecordType = '" & ClsMain.RecordType.InstallentCreate & "' "

            AgL.PubFindQry = "SELECT Convert(VARCHAR(36), H.UID) AS SearchCode, " & _
                                " " & AgL.ConvertDateField("H.EntryDate") & " As [" & LblEntryDate.Text & "], " & _
                                " " & FunGetEntryNoDisplayField("H") & " As [" & LblEntryNo.Text & "], " & _
                                " Sg.Name As [" & LblAdmissionDocId.Text & "], A.AdmissionId As [" & LblAdmissionId.Text & "], " & _
                                " H.DueAmount, H.InstallmentAmount, H.TotalInstallments, H.InstallmentStartDate, " & _
                                " H.Remark, H.InActiveDate, H.InActiveRemark, H.Site_Code, H.Div_Code " & _
                                " FROM dbo.Sch_DueInstallment H " & _
                                " LEFT JOIN SiteMast S1 ON S1.Code = H.Site_Code " & _
                                " Left Join SubGroup Sg On Sg.SubCode = H.SubCode " & _
                                " Left Join Sch_Admission A On A.DocId = H.AdmissionDocId " & mCondStr

            AgL.PubFindQryOrdBy = "  Convert(SmallDateTime, [" & LblEntryDate.Text & "]) Desc, [" & LblEntryNo.Text & "] Desc"

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
            'AgL.PubReportTitle = "Job Worker List"
            'If Not DTMaster.Rows.Count > 0 Then
            '    MsgBox("No Records Found to Print!!!", vbInformation, "Information")
            '    Me.Cursor = Cursors.Default
            '    Exit Sub
            'End If


            'strQry = " SELECT SG.Name AS [Job Worker],CED.Sex, " & _
            '                " isnull(SG.Add1,'') + ' ' + isnull(SG.Add2,'') + ' '+ isnull(SG.Add3,'') + ' ' + City.CityName  AS Address, SG.Mobile,  " & _
            '                " SG.EMail AS [E-Mail ID],SG.FatherName AS [Father Name],CED.ReferredBy AS [Refered BY]  " & _
            '                " FROM CommonEmployeeDetail CED   " & _
            '                " LEFT JOIN SubGroup SG ON SG.SubCode=CED.SubCode   " & _
            '                " LEFT JOIN City ON City.CityCode = SG.CityCode  " & _
            '                " WHERE CED.MasterType='" & Carpet_ProjLib.ClsMain.MasterType.JobWorker & "' "

            'AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            'AgL.ADMain.Fill(ds)
            'Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            'mPrnHnd.DataSetToPrint = ds
            'mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            'mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            'mPrnHnd.ReportTitle = "Job Worker List"
            'mPrnHnd.TableIndex = 0
            'mPrnHnd.PageSetupDialog(True)
            'mPrnHnd.PrintPreview()
            'Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bStrTaskEntryMode$ = ""
        Dim bIntI As Integer = 0
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True


            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                mQry = "INSERT INTO dbo.Sch_DueInstallment (" & _
                        " UID, Div_Code, Site_Code, EntryDate, Prefix, EntryNo, RecordType, " & _
                        " Employee, SubCode, AdmissionDocId, DueAmount, InstallmentAmount, TotalInstallments, " & _
                        " InstallmentStartDate, Remark, InActiveDate, InActiveRemark, " & _
                        " PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES (" & _
                         " '" & mSearchCode & "', " & AgL.Chk_Text(TxtDiv_Code.AgSelectedValue) & ", " & _
                         " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & AgL.ConvertDate(TxtEntryDate.Text) & ", " & _
                         " " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtEntryNo.Tag) & ", " & AgL.Chk_Text(TxtRecordType.Text) & ", " & _
                         " " & AgL.Chk_Text(TxtEmployee.AgSelectedValue) & ", " & AgL.Chk_Text(TxtSubCode.AgSelectedValue) & ", " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                         " " & Val(TxtDueAmount.Text) & ", " & Val(TxtInstallmentAmount.Text) & ", " & Val(TxtTotalInstallments.Text) & ", " & _
                         " " & AgL.ConvertDate(TxtInstallmentStartDate.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                         " " & AgL.ConvertDate(TxtInActiveDate.Text) & ", " & AgL.Chk_Text(TxtInActiveRemark.Text) & ", " & _
                         " '" & AgL.PubUserName & "', '" & AgL.GetDateTime(AgL.GcnRead) & "', 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "UPDATE dbo.Sch_DueInstallment " & _
                        " SET  " & _
                        " 	Div_Code = " & AgL.Chk_Text(TxtDiv_Code.AgSelectedValue) & ", " & _
                        " 	Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " 	EntryDate = " & AgL.ConvertDate(TxtEntryDate.Text) & ", " & _
                        " 	Prefix = " & AgL.Chk_Text(LblPrefix.Text) & ", " & _
                        " 	EntryNo = " & Val(TxtEntryNo.Tag) & ", " & _
                        " 	RecordType = " & AgL.Chk_Text(TxtRecordType.Text) & ",  " & _
                        " 	Employee = " & AgL.Chk_Text(TxtEmployee.AgSelectedValue) & ", " & _
                        " 	SubCode = " & AgL.Chk_Text(TxtSubCode.AgSelectedValue) & ", " & _
                        " 	AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                        " 	DueAmount = " & Val(TxtDueAmount.Text) & ",  " & _
                        " 	InstallmentAmount = " & Val(TxtInstallmentAmount.Text) & ",  " & _
                        " 	TotalInstallments = " & Val(TxtTotalInstallments.Text) & ",  " & _
                        " 	InstallmentStartDate = " & AgL.ConvertDate(TxtInstallmentStartDate.Text) & ",  " & _
                        " 	Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " 	InActiveDate =" & AgL.ConvertDate(TxtInActiveDate.Text) & ",  " & _
                        " 	InActiveRemark = " & AgL.Chk_Text(TxtInActiveRemark.Text) & ",  " & _
                        " 	U_AE = 'E', " & _
                        " 	Edit_Date = '" & AgL.GetDateTime(AgL.GcnRead) & "', " & _
                        " 	ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE UID = '" & mSearchCode & "'"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            Dim bIntSr% = 0
            If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                mQry = "Delete From Sch_DueInstallment1  Where Uid = " & AgL.Chk_Text(mSearchCode) & ""
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bIntSr = 0
                For bIntI = 0 To .Rows.Count - 1
                    If .Item(Col1InstallmentDate, bIntI).Value.ToString.Trim <> "" _
                        And Val(.Item(Col1InstallmentAmount, bIntI).Value) > 0 Then

                        bIntSr += 1

                        mQry = "INSERT INTO dbo.Sch_DueInstallment1 ( " & _
                                " UID, Sr, InstallmentDate, InstallmentAmount, RemindBeforeDays, RemindAfterDays, IsInActive) " & _
                                " VALUES (" & _
                                " '" & mSearchCode & "', " & bIntSr & ", " & _
                                " " & AgL.ConvertDate(.Item(Col1InstallmentDate, bIntI).Value.ToString) & ", " & _
                                " " & Val(.Item(Col1InstallmentAmount, bIntI).Value) & ", " & _
                                " " & Val(.Item(Col1RemindBeforeDays, bIntI).Value) & ", " & _
                                " " & Val(.Item(Col1RemindAfterDays, bIntI).Value) & ", " & _
                                " " & IIf(.Item(Col1IsInActive, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue, 1, 0) & " " & _
                                " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With


            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl1_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If
            If ex.Message.Trim <> "" Then MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ProcRefreshForm()
        FIniMaster(0, 1)
        Topctrl1_tbRef()
        MoveRec()
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, bDtTemp As DataTable = Nothing
        Dim MastPos As Long
        Dim bIntI As Integer
        Dim mTransFlag As Boolean = False
        Dim bCondStr$ = ""
        Dim DrTemp As DataRow() = Nothing

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
                mQry = "Select H.*, " & FunGetEntryNoDisplayField("H") & " As EntryNoDisplay " & _
                        " From Sch_DueInstallment H " & _
                        " Where H.UID = " & AgL.Chk_Text(mSearchCode) & " "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtDiv_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Div_Code"))

                        TxtEntryDate.Text = Format(AgL.XNull(.Rows(0)("EntryDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblPrefix.Text = AgL.XNull(.Rows(0)("Prefix"))
                        TxtEntryNo.Tag = AgL.VNull(.Rows(0)("EntryNo"))
                        TxtEntryNo.Text = AgL.XNull(.Rows(0)("EntryNoDisplay"))
                        TxtRecordType.Text = AgL.XNull(.Rows(0)("RecordType"))

                        TxtEmployee.AgSelectedValue = AgL.XNull(.Rows(0)("Employee"))
                        TxtSubCode.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                        TxtAdmissionDocId.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionDocId"))

                        DrTemp = TxtAdmissionDocId.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & "")
                        If DrTemp.Length > 0 Then
                            TxtAdmissionId.Text = AgL.XNull(DrTemp(0)("Admission Id"))
                        End If

                        TxtDueAmount.Text = Format(AgL.VNull(.Rows(0)("DueAmount")), "0.00")
                        TxtInstallmentAmount.Text = Format(AgL.VNull(.Rows(0)("InstallmentAmount")), "0.00")
                        TxtTotalInstallments.Text = AgL.VNull(.Rows(0)("TotalInstallments"))
                        TxtInstallmentStartDate.Text = Format(AgL.XNull(.Rows(0)("InstallmentStartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        TxtInActiveDate.Text = Format(AgL.XNull(.Rows(0)("InActiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtInActiveRemark.Text = AgL.XNull(.Rows(0)("InActiveRemark"))


                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GrpModified.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                    DsTemp = Nothing
                End With

                mQry = "SELECT L.* " & _
                        " FROM Sch_DueInstallment1 L " & _
                        " WHERE L.Uid = " & AgL.Chk_Text(mSearchCode) & " " & _
                        " ORDER BY L.Sr  "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For bIntI = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count

                            DGL1.Item(Col1InstallmentDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("InstallmentDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL1.Item(Col1TempInstallmentDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("InstallmentDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                            DGL1.Item(Col1InstallmentAmount, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("InstallmentAmount")), "0.00")

                            LblValTotalAmount.Text = Format(Val(LblValTotalAmount.Text) + Val(DGL1.Item(Col1InstallmentAmount, bIntI).Value), "0.00")
                            DGL1.Item(Col1TotalAmount, bIntI).Value = LblValTotalAmount.Text

                            DGL1.Item(Col1RemindBeforeDays, bIntI).Value = AgL.VNull(.Rows(bIntI)("RemindBeforeDays"))
                            DGL1.Item(Col1RemindAfterDays, bIntI).Value = AgL.VNull(.Rows(bIntI)("RemindAfterDays"))

                            DGL1.Item(Col1IsInActive, bIntI).Value = IIf(AgL.VNull(.Rows(bIntI)("IsInActive")), AgLibrary.ClsConstant.StrCheckedValue, AgLibrary.ClsConstant.StrUnCheckedValue)

                            If bIntI = 0 Then
                                TxtRemindBeforeDays.Text = AgL.VNull(.Rows(bIntI)("RemindBeforeDays"))
                                TxtRemindAfterDays.Text = AgL.VNull(.Rows(bIntI)("RemindAfterDays"))
                            End If

                        Next bIntI
                    End If
                End With
            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)

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
            If DsTemp IsNot Nothing Then DsTemp.Dispose()
            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
            Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)

        mSearchCode = "" : LblPrefix.Text = ""

        LblValTotalAmount.Text = ""

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtDiv_Code.Enabled = False
        TxtEntryNo.Enabled = False : TxtSubCode.Enabled = False

        BtnFill.Enabled = Enb

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtRecordType.Enabled = False
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

    Private Function Data_Validation() As Boolean
        Dim bIntI% = 0
        Dim bStrLastDate$ = ""
        Try
            Call Calculation()
            If AgL.RequiredField(TxtRecordType, "Record Type") Then Exit Function
            If AgL.RequiredField(TxtEntryDate, LblEntryDate.Text) Then Exit Function
            If AgL.RequiredField(TxtAdmissionDocId, LblAdmissionDocId.Text) Then Exit Function
            If AgL.RequiredField(TxtSubCode, "Student") Then Exit Function
            If AgL.RequiredField(TxtDueAmount, LblDueAmount.Text, True) Then Exit Function
            If AgL.RequiredField(TxtInstallmentAmount, LblInstallmentAmount.Text, True) Then Exit Function
            If AgL.RequiredField(TxtTotalInstallments, LblTotalInstallments.Text, True) Then Exit Function
            If AgL.RequiredField(TxtInstallmentStartDate, LblInstallmentStartDate.Text, True) Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1InstallmentDate).Index) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, DGL1.Columns(Col1InstallmentDate).Index) Then Exit Function

            bStrLastDate = TxtInstallmentStartDate.Text

            For bIntI = 0 To DGL1.Rows.Count - 1
                If DGL1.Item(Col1InstallmentDate, bIntI).Value.ToString.Trim <> "" _
                    And Val(DGL1.Item(Col1InstallmentAmount, bIntI).Value) > 0 Then

                    If CDate(DGL1.Item(Col1InstallmentDate, bIntI).Value) < CDate(bStrLastDate) Then
                        MsgBox("Please Check Installment Date For Installment No : " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                        DGL1.CurrentCell = DGL1(Col1InstallmentDate, bIntI) : DGL1.Focus()
                        Exit Function
                    End If

                    bStrLastDate = DGL1.Item(Col1InstallmentDate, bIntI).Value
                End If
            Next


            If Val(LblValTotalAmount.Text) <> Val(TxtDueAmount.Text) Then
                MsgBox("Total of Installments Amount is Greater Than From : " & Val(TxtDueAmount.Text) & "!...")
                DGL1.CurrentCell = DGL1(Col1InstallmentAmount, 0)
                DGL1.Focus() : Exit Function
            End If

            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                LblPrefix.Text = CDate(TxtEntryDate.Text).Year.ToString
                TxtEntryNo.Tag = FunGetEntryNo("Sch_DueInstallment", LblPrefix.Text, TxtSite_Code.AgSelectedValue, TxtDiv_Code.AgSelectedValue)
                TxtEntryNo.Text = FunGetEntryNoDisplayValue(Val(TxtEntryNo.Tag), LblPrefix.Text, TxtSite_Code.AgSelectedValue, TxtDiv_Code.AgSelectedValue)
            End If


            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtSite_Code.Enter, TxtDiv_Code.Enter, TxtRemark.Enter, TxtEntryDate.Enter, TxtEntryNo.Enter, _
        TxtEmployee.Enter, TxtSubCode.Enter, TxtInActiveDate.Enter, TxtInActiveRemark.Enter

        Dim bStrFilter$ = ""
        Try

            Select Case sender.name
                Case TxtSubCode.Name
                    bStrFilter = " 1=1 "
                    bStrFilter += " And CommonParty = 'Yes' "
                    sender.AgRowFilter = bStrFilter

                Case TxtEmployee.Name
                    bStrFilter = " 1=1 "
                    bStrFilter += " And CommonParty = 'Yes' And IsActive = 'Yes' "
                    sender.AgRowFilter = bStrFilter

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtDiv_Code.Validating, TxtEntryDate.Validating, TxtEntryNo.Validating, _
        TxtRemark.Validating, TxtEmployee.Validating, TxtSubCode.Validating, TxtInstallmentAmount.Validating, _
        TxtInActiveDate.Validating, TxtInActiveRemark.Validating, TxtAdmissionDocId.Validating, TxtTotalInstallments.Validating

        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim DrTemp As DataRow() = Nothing

        Try
            Select Case sender.name
                Case TxtAdmissionDocId.Name
                    Call Validating_Controls(sender)

                Case TxtEntryDate.Name
                    Call Validating_Controls(sender)

            End Select

            Call Calculation()
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

            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                'Case <ColumnIndex>
                '<Executable Code>
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

            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                'Case <ColumnIndex>
                'Call Calculation()
            End Select
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
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col1InstallmentAmount
                        DGL1.Item(Col1InstallmentAmount, mRowIndex).Value = Format(Val(DGL1.Item(Col1InstallmentAmount, mRowIndex).Value), "0.00")
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
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    'Case Col1YesNo
                    '    If DGL1.Item(mColumnIndex, e.RowIndex).Value.ToString.Trim = AgLibrary.ClsConstant.StrUnCheckedValue Then
                    '        If DGL1.Item(Col1SectionLeftOnDate, e.RowIndex).Value <> "" Then
                    '            MsgBox("Please Don't Uncheck the Student!...")
                    '            e.Cancel = True : Exit Sub
                    '        End If
                    '    End If
                End Select
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
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
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1IsInActive
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(DGL1, mColumnIndex)
                        Call Calculation()
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL1.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1IsInActive
                    Call AgL.ProcSetCheckColumnCellValue(DGL1, mColumnIndex)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)

        Try
            Select Case sender.name
                Case DGL1.Name
                    sender(Col1IsInActive, sender.Rows.Count - 1).Value = AgLibrary.ClsConstant.StrUnCheckedValue

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, DGL1.Columns(ColSNo).Index)

        Call Calculation()
    End Sub

    Private Sub Calculation()
        Dim bIntI% = 0

        If Topctrl1.Mode = "Browse" Then Exit Sub

        '<Executbale code>

        LblValTotalAmount.Text = ""

        If Val(TxtInstallmentAmount.Text) > 0 Then
            TxtTotalInstallments.Text = Format(Val(TxtDueAmount.Text) / Val(TxtInstallmentAmount.Text), "0")
        End If

        For bIntI = 0 To DGL1.Rows.Count - 1
            If DGL1.Item(Col1IsInActive, bIntI).Value Is Nothing Then DGL1.Item(Col1IsInActive, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
            If DGL1.Item(Col1IsInActive, bIntI).Value.ToString.Trim = "" Then DGL1.Item(Col1IsInActive, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue

            If DGL1.Item(Col1InstallmentDate, bIntI).Value Is Nothing Then DGL1.Item(Col1InstallmentDate, bIntI).Value = ""
            If DGL1.Item(Col1TempInstallmentDate, bIntI).Value Is Nothing Then DGL1.Item(Col1TempInstallmentDate, bIntI).Value = ""
            If DGL1.Item(Col1InstallmentAmount, bIntI).Value Is Nothing Then DGL1.Item(Col1InstallmentAmount, bIntI).Value = ""

            DGL1.Item(Col1TotalAmount, bIntI).Value = ""

            If DGL1.Item(Col1InstallmentDate, bIntI).Value.ToString.Trim = "" Then
                DGL1.Item(Col1InstallmentDate, bIntI).Value = DGL1.Item(Col1TempInstallmentDate, bIntI).Value
            End If


            If DGL1.Item(Col1InstallmentDate, bIntI).Value.ToString.Trim <> "" _
                And Val(DGL1.Item(Col1InstallmentAmount, bIntI).Value) > 0 Then

                LblValTotalAmount.Text = Format(Val(LblValTotalAmount.Text) + Val(DGL1.Item(Col1InstallmentAmount, bIntI).Value), "0.00")
                DGL1.Item(Col1TotalAmount, bIntI).Value = LblValTotalAmount.Text

                DGL1.Item(Col1RemindBeforeDays, bIntI).Value = Val(TxtRemindBeforeDays.Text)
                DGL1.Item(Col1RemindAfterDays, bIntI).Value = Val(TxtRemindAfterDays.Text)

            End If
        Next
    End Sub

    Private Sub Validating_Controls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtEntryDate.Name
                If TxtEntryDate.Text.Trim = "" Then TxtEntryDate.Text = AgL.PubLoginDate
                TxtEntryDate.Text = AgL.RetFinancialYearDate(TxtEntryDate.Text.ToString)

            Case TxtAdmissionDocId.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    TxtSubCode.AgSelectedValue = ""
                    TxtAdmissionId.Text = ""
                    TxtDueAmount.Text = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")


                        TxtSubCode.AgSelectedValue = AgL.XNull(DrTemp(0)("StudentCode"))
                        TxtAdmissionId.Text = AgL.XNull(DrTemp(0)("Admission Id"))

                        If TxtAdmissionDocId.Text.Trim <> "" And Val(TxtDueAmount.Text) = 0 Then
                            mQry = "SELECT IsNull(Sum(Fd.NetBalance),0) AS NetBalance " & _
                                    " FROM ViewSch_FeeDue Fd " & _
                                    " WHERE Fd.AdmissionDocId  = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " "

                            TxtDueAmount.Text = Format(AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar), "0.00")
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Try
            Select Case sender.Name
                Case BtnFill.Name
                    If AgL.RequiredField(TxtDueAmount, LblDueAmount.Text, True) Then Exit Sub
                    If AgL.RequiredField(TxtTotalInstallments, LblTotalInstallments.Text, True) Then Exit Sub
                    If AgL.RequiredField(TxtInstallmentStartDate, LblInstallmentStartDate.Text, True) Then Exit Sub

                    Call ProcCreateInstallments()
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcCreateInstallments()
        Dim bDblTempTotalAmt As Double = 0, bDblFirstInstallment As Double = 0
        Dim bIntI% = 0
        Try
            Me.Cursor = Cursors.WaitCursor
            DGL1.RowCount = 1 : DGL1.Rows.Clear()


            If Val(TxtInstallmentAmount.Text) = 0 Then
                TxtInstallmentAmount.Text = Int(Val(TxtDueAmount.Text) / Val(TxtTotalInstallments.Text))
            End If

            bDblFirstInstallment = TxtInstallmentAmount.Text

            bDblTempTotalAmt = Val(TxtInstallmentAmount.Text) * Val(TxtTotalInstallments.Text)

            If bDblTempTotalAmt < Val(TxtDueAmount.Text) Then
                bDblFirstInstallment = bDblFirstInstallment + (Val(TxtDueAmount.Text) - bDblTempTotalAmt)
            End If

            For bIntI = 0 To Val(TxtTotalInstallments.Text) - 1
                DGL1.Rows.Add()

                DGL1.Item(ColSNo, bIntI).Value = bIntI + 1
                DGL1.Item(Col1RemindBeforeDays, bIntI).Value = Val(TxtRemindBeforeDays.Text)
                DGL1.Item(Col1RemindAfterDays, bIntI).Value = Val(TxtRemindAfterDays.Text)


                If bIntI = 0 Then
                    DGL1.Item(Col1InstallmentAmount, bIntI).Value = Format(bDblFirstInstallment, "0.00")
                    DGL1.Item(Col1InstallmentDate, bIntI).Value = TxtInstallmentStartDate.Text
                Else
                    DGL1.Item(Col1InstallmentAmount, bIntI).Value = Format(Val(TxtInstallmentAmount.Text), "0.00")
                    DGL1.Item(Col1InstallmentDate, bIntI).Value = Format(DateAdd(DateInterval.Month, bIntI, CDate(TxtInstallmentStartDate.Text)), AgLibrary.ClsConstant.DateFormat_ShortDate)
                End If

                DGL1.Item(Col1TempInstallmentDate, bIntI).Value = DGL1.Item(Col1InstallmentDate, bIntI).Value

                LblValTotalAmount.Text = Format(Val(LblValTotalAmount.Text) + Val(DGL1.Item(Col1InstallmentAmount, bIntI).Value), "0.00")
                DGL1.Item(Col1TotalAmount, bIntI).Value = LblValTotalAmount.Text
            Next bIntI

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


End Class