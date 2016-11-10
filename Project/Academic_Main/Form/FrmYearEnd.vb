Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmYearEnd
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mObjClsMain As New ClsMain(AgL, PLib)

    Private Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Dgl1GridName As String = "Dgl1"

    Protected Const Col1Comp_Code As String = "Company Code"
    Protected Const Col1Comp_Name As String = "Company"
    Protected Const Col1Start_Dt As String = "Start Date"
    Protected Const Col1End_Dt As String = "End Date"
    Protected Const Col1CentralData_Path As String = "Data Path"
    Protected Const Col1DbPrefix As String = "DB Prefix"
    Protected Const Col1Div_Code As String = "Division Code"

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"

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

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Dim StrUPVar As String = "A***", DTUP As DataTable = Nothing
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing : mObjClsMain = Nothing
    End Sub

    Private Sub IniGrid()
        '<Executable Code>
        AgL.AddAgDataGrid(DGL1, Pnl1)
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 Then
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
            AgL.WinSetting(Me, 400, 500, _FormLocation.Y, _FormLocation.X)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            FIniMaster()
            Ini_List()
            DispText()

            _EntryMode = "Add"
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
        Dim bCondStr$ = " WHERE 1=2 "
        mQry = "Select User_Name As SearchCode " & _
                " From UserMast U  With (NoLock) " & bCondStr
        Topctrl1.FIniForm(DTMaster, AgL.GcnRead, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            '<Executable code>
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        Dim bStrTempCostCenter$ = ""
        BlankText()
        DispText(True)

        If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.PubIsUserAdmin) Then
            MsgBox("Permission Denied!...")
            Topctrl1.FButtonClick(14, True)
            Exit Sub
        End If

        Call BtnFill.Focus()
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        '<Executable code>
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
        DispText(False)
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        '<Executable code>
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        '<Executable code>
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        '<Executblae Code>
    End Sub

    Public Sub ProcRefreshForm()
        FIniMaster(0, 1)
        Topctrl1_tbRef()
        MoveRec()
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, bDtTemp As DataTable = Nothing
        Dim MastPos As Long
        Dim mTransFlag As Boolean = False

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
                '<Executable Code>
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

        mSearchCode = ""

        DGL1.DataSource = Nothing
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
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
        Try
            Call Calculation()

            If DGL1.Rows.Count = 0 Then MsgBox("No Record Exists!...") : Exit Function

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs)

        Try
            Select Case sender.name
                'Case TxtCostCenter.Name
                '    sender.AgRowFilter = " IsActive = 'Yes' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
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

    Private Sub Calculation()
        If Topctrl1.Mode = "Browse" Then Exit Sub

        '<Executbale code>
    End Sub

    Private Sub Validating_Controls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            'Case TxtCostCenter.Name
            '    If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
            '        LblCostCenter.Tag = ""
            '    Else
            '        If Sender.AgHelpDataSet IsNot Nothing Then
            '            DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
            '            LblCostCenter.Tag = AgL.XNull(DrTemp(0)("MainStreamCode"))
            '        End If
            '    End If
            '    DrTemp = Nothing
        End Select
    End Sub

    Private Sub BtnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
        Handles BtnOk.Click, BtnExit.Click, BtnFill.Click
        Try
            Select Case sender.name
                Case BtnFill.Name
                    If Not (AgL.StrCmp("SA", AgL.PubUserName) Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then MsgBox("Permission Denied!...") : Exit Sub

                    Call ProcFill()

                Case BtnOk.Name
                    BtnExit.Enabled = False
                    BtnFill.Enabled = False

                    If AgL.StrCmp(AgL.PubDivisionDBName, AgL.PubCompanyDBName) Then
                        Call ProcYearEndUpdation()
                    Else
                        Call ProcUpdateVoucherPrefix()
                    End If

                    BtnFill.Enabled = True
                    BtnExit.Enabled = True

                Case BtnExit.Name
                    Me.Close()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            BtnFill.Enabled = True
            BtnExit.Enabled = True
        End Try
    End Sub

    Private Sub ProcFill()
        Dim bDtTemp As DataTable = Nothing
        Dim bIntI% = 0
        Try
            DGL1.DataSource = Nothing

            mQry = "SELECT " & _
                    " C.Comp_Code As [" & Col1Comp_Code & "], " & _
                    " C.Comp_Name As [" & Col1Comp_Name & "], " & _
                    " C.Start_Dt As [" & Col1Start_Dt & "], " & _
                    " C.End_Dt As [" & Col1End_Dt & "], " & _
                    " C.Div_Code As [" & Col1Div_Code & "], " & _
                    " C.DbPrefix As [" & Col1DbPrefix & "], " & _
                    " C.CentralData_Path As [" & Col1CentralData_Path & "] " & _
                    " FROM ( " & _
                    " 	Select Max(Company.Start_Dt) AS Start_Dt, Company.Comp_Name " & _
                    " 	From Company With (NoLock) " & _
                    " 	WHERE IsNull(Company.DeletedYN,'N') <> 'Y' " & _
                    " 	AND Company.Start_Dt = " & AgL.ConvertDate(AgL.PubStartDate) & " " & _
                    "   Group by Company.Comp_Name " & _
                    " 	) AS vC  " & _
                    " INNER JOIN Company C With (NoLock) ON C.Comp_Name = vC.Comp_Name AND C.Start_Dt = vC.Start_Dt " & _
                    " WHERE IsNull(C.DeletedYN,'N') <> 'Y' " & _
                    " AND C.Start_Dt = " & AgL.ConvertDate(AgL.PubStartDate) & " " & _
                    " ORDER BY IsNull(Convert(Numeric,C.Comp_Code),0) "
            bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            DGL1.DataSource = bDtTemp
            IniGridTaskList()
        Catch ex As Exception
            DGL1.DataSource = Nothing
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IniGridTaskList()
        If Dgl1.DataSource IsNot Nothing Then

            DGL1.Columns(Col1Comp_Code).Visible = True : DGL1.Columns(Col1Comp_Code).Width = 50
            DGL1.Columns(Col1Comp_Name).Visible = True : DGL1.Columns(Col1Comp_Name).Width = 200
            DGL1.Columns(Col1Start_Dt).Visible = True : DGL1.Columns(Col1Start_Dt).Width = 80
            DGL1.Columns(Col1End_Dt).Visible = True : DGL1.Columns(Col1End_Dt).Width = 80
            DGL1.Columns(Col1CentralData_Path).Visible = True : DGL1.Columns(Col1CentralData_Path).Width = 100
            DGL1.Columns(Col1DbPrefix).Visible = True : DGL1.Columns(Col1DbPrefix).Width = 100
            DGL1.Columns(Col1Div_Code).Visible = True : DGL1.Columns(Col1Div_Code).Width = 50
            ' ''==============================================================================

            Dgl1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders
            DGL1.ColumnHeadersHeight = 40
            Dgl1.AllowUserToAddRows = False
            Dgl1.EnableHeadersVisualStyles = False
            Dgl1.ReadOnly = True
        End If
    End Sub

    Public Sub ProcYearEndUpdation()
        Dim mQry$ = ""
        Dim I As Integer
        Dim DtCompany As DataTable = Nothing
        Dim bComp_Code As String, bStrPrefix$ = ""
        Dim mTrans As Boolean = False

        Try
            Me.Cursor = Cursors.WaitCursor

            If Not (AgL.StrCmp("SA", AgL.PubUserName) Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then MsgBox("Permission Denied!...") : Exit Sub

            If Not AgL.StrCmp(AgL.PubDivisionDBName, AgL.PubCompanyDBName ) Then
                MsgBox("Current Company Is Not Main Company!....")
                Exit Sub
            End If

            If MsgBox("Are You Sure to Run Year End Updation?...", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub

            If Not Data_Validation() Then Exit Sub

            MsgBox("Please Take Database Backup", MsgBoxStyle.Information)

            Dim FrmObj As Form
            FrmObj = New AgLibrary.FrmBackupDatase(AgL)
            FrmObj.ShowDialog()
            FrmObj = Nothing

            mQry = "SELECT C.* " & _
                    " FROM ( " & _
                    " 	Select Max(Company.Start_Dt) AS Start_Dt, Company.Comp_Name " & _
                    " 	From Company With (NoLock) " & _
                    " 	WHERE IsNull(Company.DeletedYN,'N') <> 'Y' " & _
                    " 	AND Company.Start_Dt = " & AgL.ConvertDate(AgL.PubStartDate) & " " & _
                    "   Group by Company.Comp_Name " & _
                    " 	) AS vC  " & _
                    " INNER JOIN Company C With (NoLock) ON C.Comp_Name = vC.Comp_Name AND C.Start_Dt = vC.Start_Dt " & _
                    " WHERE IsNull(C.DeletedYN,'N') <> 'Y' " & _
                    " AND C.Start_Dt = " & AgL.ConvertDate(AgL.PubStartDate) & " " & _
                    " ORDER BY IsNull(Convert(Numeric,C.Comp_Code),0) "
            DtCompany = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

            PgBar.Minimum = 0 : PgBar.Maximum = DtCompany.Rows.Count - 1

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True

            bStrPrefix = Year(DateAdd(DateInterval.Year, 1, CDate(AgL.PubStartDate)))

            mQry = "SELECT COUNT(*) FROM Voucher_Prefix_Type T With (NoLock) WHERE T.V_Prefix = '" & bStrPrefix & "'"
            If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar = 0 Then
                mQry = "INSERT INTO Voucher_Prefix_Type (V_Prefix,Description) VALUES ('" & bStrPrefix & "','" & bStrPrefix & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            For I = 0 To DtCompany.Rows.Count - 1
                PgBar.Value = I

                mQry = "SELECT COUNT(*) FROM Company C WITH (NoLock) " & _
                        " WHERE IsNull(C.DeletedYN,'N') <> 'Y' " & _
                        " AND C.Comp_Name = '" & DtCompany.Rows(I)("Comp_Name") & "' " & _
                        " AND C.Start_Dt = '" & DateAdd(DateInterval.Year, 1, CDate(AgL.PubStartDate)) & "' "
                If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar = 0 Then
                    mQry = "Select IsNull(Max(Convert(Numeric,Comp_Code)),0)+1 From Company With (NoLock) Where IsNumeric(Comp_code)>0   "
                    bComp_Code = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar

                    mQry = "Insert Into Company (Comp_Code, Div_Code, Comp_Name, CentralData_Path, PrevDBName, DbPrefix, Repo_Path, Start_Dt, End_Dt, address1, address2, city, pin, phone, fax, lstno, lstdate, cstno, cstdate, cyear, pyear, SerialKeyNo, SName, EMail, Gram, Desc1, Desc2, Desc3, ECCCode, ExDivision, ExRegNo, ExColl, ExRange, Desc4, VatNo, VatDate, TinNo, Site_Code, LogSiteCode, PANNo, State, U_Name, U_EntDt, U_AE, DeletedYN, Country, V_Prefix, NotificationNo, WorkAddress1, WorkAddress2, WorkCity, WorkCountry, WorkPin, WorkPhone, WorkFax, WebServer, WebUser, WebPassword, Webdatabase, UpLoadDate, UseSiteNameAsCompanyName,ImageDBName) " & _
                           " SELECT Top 1 '" & bComp_Code & "' as  Comp_Code, Div_Code, Comp_Name, CentralData_Path, CentralData_Path As PrevDBName, DbPrefix, Repo_Path, '" & DateAdd(DateInterval.Year, 1, CDate(AgL.PubStartDate)) & "' as Start_Dt, '" & DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 2, CDate(AgL.PubStartDate))) & "'  as End_Dt, address1, address2, city, pin, phone, fax, lstno, lstdate, cstno, cstdate, '" & Year(DateAdd(DateInterval.Year, 1, CDate(AgL.PubStartDate))) & "-' + '" & Year(DateAdd(DateInterval.Year, 2, CDate(AgL.PubStartDate))) & "' cyear, cyear As pyear, SerialKeyNo, SName, EMail, Gram, Desc1, Desc2, Desc3, ECCCode, ExDivision, ExRegNo, ExColl, ExRange, Desc4, VatNo, VatDate, TinNo, Site_Code, LogSiteCode, PANNo, State, U_Name, U_EntDt, U_AE, DeletedYN, Country, V_Prefix, NotificationNo, WorkAddress1, WorkAddress2, WorkCity, WorkCountry, WorkPin, WorkPhone, WorkFax, WebServer, WebUser, WebPassword, Webdatabase, UpLoadDate, UseSiteNameAsCompanyName,ImageDBName " & _
                           " FROM dbo.Company Where Comp_Code = '" & DtCompany.Rows(I)("Comp_Code") & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    If AgL.StrCmp(AgL.PubDivisionDBName, AgL.PubCompanyDBName) Then
                        mQry = "Select Count(*) From Voucher_Prefix With (NoLock) " & _
                                " Where Prefix = '" & Year(DateAdd(DateInterval.Year, 1, CDate(AgL.PubStartDate))) & "' "
                        If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar = 0 Then
                            mQry = " INSERT INTO Voucher_Prefix  (V_Type, Date_From, Prefix, Start_Srl_No, Date_To, Site_Code, Div_Code, Comp_Code) " & _
                                   " SELECT V_Type, '" & DateAdd(DateInterval.Year, 1, CDate(AgL.PubStartDate)) & "' as Date_From, '" & bStrPrefix & "' as  Prefix, 0 as Start_Srl_No, '" & DateAdd(DateInterval.Day, -1, DateAdd(DateInterval.Year, 2, CDate(AgL.PubStartDate))) & "'  as Date_To, Site_Code, Div_Code, '" & bComp_Code & "' As Comp_Code " & _
                                   " FROM dbo.Voucher_Prefix With (NoLock) " & _
                                   " WHERE Prefix ='" & Year(CDate(AgL.PubStartDate)) & "' "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    End If
                End If

            Next

            Call AgL.LogTableEntry(bStrPrefix, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)


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
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

            MsgBox("Process Completed.", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If

            MsgBox(ex.Message)
        Finally
            If DtCompany IsNot Nothing Then DtCompany.Dispose()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub ProcUpdateVoucherPrefix()
        Dim mQry$ = "", bCondStr1$ = "", bCondStr2$ = ""
        Dim I As Integer
        Dim DtCompany As DataTable = Nothing
        Dim bComp_Code As String, bStrPrefix$ = ""
        Dim mTrans As Boolean = False

        Try
            Me.Cursor = Cursors.WaitCursor

            If AgL.StrCmp(AgL.PubDivisionDBName, AgL.PubCompanyDBName) Then
                MsgBox("Current Company Is a Main Company!....")
                Exit Sub
            End If

            If Not (AgL.StrCmp("SA", AgL.PubUserName) Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then MsgBox("Permission Denied!...") : Exit Sub

            If MsgBox("Are You Sure to Run Update Voucher Prefix?...", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub

            If Not Data_Validation() Then Exit Sub

            MsgBox("Please Take Database Backup", MsgBoxStyle.Information)

            Dim FrmObj As Form
            FrmObj = New AgLibrary.FrmBackupDatase(AgL)
            FrmObj.ShowDialog()
            FrmObj = Nothing

            bCondStr1 = " AND Company.CentralData_Path = " & AgL.Chk_Text(AgL.PubDBName) & " "
            bCondStr2 = " AND C.CentralData_Path = " & AgL.Chk_Text(AgL.PubDBName) & " "

            mQry = "SELECT C.* " & _
                    " FROM ( " & _
                    " 	Select Max(Company.Start_Dt) AS Start_Dt, Company.Comp_Name " & _
                    " 	From Company With (NoLock) " & _
                    " 	WHERE IsNull(Company.DeletedYN,'N') <> 'Y' " & _
                    " 	AND Company.Start_Dt = '" & AgL.PubStartDate & "' " & _
                    "   " & bCondStr1 & " " & _
                    "   Group by Company.Comp_Name " & _
                    " 	) AS vC  " & _
                    " INNER JOIN Company C With (NoLock) ON C.Comp_Name = vC.Comp_Name AND C.Start_Dt = vC.Start_Dt " & _
                    " WHERE IsNull(C.DeletedYN,'N') <> 'Y' " & _
                    " AND C.Start_Dt = '" & AgL.PubStartDate & "' " & _
                    " " & bCondStr2 & " " & _
                    " AND C.Start_Dt = " & AgL.ConvertDate(AgL.PubStartDate) & bCondStr2 & " " & _
                    " ORDER BY IsNull(Convert(Numeric,C.Comp_Code),0) "
            DtCompany = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

            PgBar.Minimum = 0 : PgBar.Maximum = DtCompany.Rows.Count - 1

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True

            bStrPrefix = Year(CDate(AgL.PubStartDate))

            mQry = "SELECT COUNT(*) FROM Voucher_Prefix_Type T With (NoLock) WHERE T.V_Prefix = '" & bStrPrefix & "'"
            If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar = 0 Then
                mQry = "INSERT INTO Voucher_Prefix_Type (V_Prefix,Description) VALUES ('" & bStrPrefix & "','" & bStrPrefix & "')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            For I = 0 To DtCompany.Rows.Count - 1
                PgBar.Value = I

                If Not AgL.StrCmp(AgL.PubDivisionDBName, AgL.PubCompanyDBName) Then
                    bComp_Code = DtCompany.Rows(I)("Comp_Code")

                    mQry = "Select Count(*) From Voucher_Prefix With (NoLock) " & _
                            " Where Prefix = '" & bStrPrefix & "' "
                    If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar = 0 Then
                        mQry = " INSERT INTO Voucher_Prefix  (V_Type, Date_From, Prefix, Start_Srl_No, Date_To, Site_Code, Div_Code, Comp_Code) " & _
                               " SELECT V_Type, '" & AgL.PubStartDate & "' as Date_From, '" & bStrPrefix & "' as  Prefix, 0 as Start_Srl_No, '" & AgL.PubEndDate & "'  as Date_To, Site_Code, Div_Code, '" & bComp_Code & "' As Comp_Code " & _
                               " FROM dbo.Voucher_Prefix With (NoLock) " & _
                               " WHERE Prefix ='" & Year(DateAdd(DateInterval.Year, -1, CDate(AgL.PubStartDate))) & "' "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If

                End If
            Next

            Call AgL.LogTableEntry(bStrPrefix, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, "Update Voucher Prefix")


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
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

            MsgBox("Process Completed.", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If

            MsgBox(ex.Message)
        Finally
            If DtCompany IsNot Nothing Then DtCompany.Dispose()
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class