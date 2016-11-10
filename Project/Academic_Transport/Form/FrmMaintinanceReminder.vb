Imports System.Data.SqlClient
Public Class FrmMaintinanceReminder
    Private DTMaster As New DataTable()
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const BtnVehicleMaintenanceExpense As String = "Maintenance Expense"
    Protected Const Col1VehicleCode As String = "Vehicle Code"
    Protected Const Col1VehilceNo As String = "Vehicle No"
    Protected Const Col1VehilceName As String = "Vehicle Name"
    Protected Const Col1VehilceType As String = "Vehicle Type"
    Protected Const Col1VehilceModal As String = "Vehicle Model"
    Protected Const Col1ExpenseName As String = "Due Head"
    Protected Const Col1ExpenseCode As String = "Expense Code"
    Protected Const Col1ExpenseType As String = "Due Head Type"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1DueOnDate As String = "Due On Date"
    Protected Const Col1DueOnMeterReading As String = "Due On Reading"
    Protected Const Col1CurrentMeterReading As String = "Current Reading"


    Dim mBlnRefreshFlag As Boolean = False

    Private Enum FilterType
        Similer
        Dissimilar
        Remove
    End Enum

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub FrmFollowupReminder_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Dim bIntI% = 0
        Try
            If mBlnRefreshFlag Then
                For bIntI = 0 To Me.OwnedForms.Length - 1
                    Me.OwnedForms(bIntI).Dispose()
                Next

                Call ProcFillGrid()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        ''==============================================================================
        ''================< Fee Due Data Grid >====================================
        ''==============================================================================

        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 30
        DGL1.AllowUserToAddRows = False
        DGL1.ContextMenuStrip = CMnu
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Topctrl1.TopKey_Down(e)
        End If
        If Me.ActiveControl IsNot Nothing Then
            If Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If

            'If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)
        End If
    End Sub

    Private Sub OpenLinkForm(ByVal Sender As Object)

        Try
            Me.Cursor = Cursors.WaitCursor
            'If Topctrl1.Mode = "Browse" Then Exit Sub

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
            AgL.GridDesign(DGL1)
            IniGrid()
            Ini_List()
            DispText()
            Topctrl1.Mode = "Add"
            Call ProcFillGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Ini_List()
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub BlankText()
        Topctrl1.BlankTextBoxes(Me)
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                'Case Col1AdmissionDocId
                '<Executable Code>
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                'Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            'sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        Dim DrTemp As DataRow() = Nothing
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                '<Executable Code>
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        'sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        'AgL.FSetSNo(sender, Col_SNo)
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSite_Code.Enter
        Try
            Select Case sender.name
                '<Executable Code>
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSite_Code.Validating, TxtV_Date.Validating
        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                    Call ProcFillGrid()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub

    Private Sub BtnChargeDuw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        DGL1.DataSource = Nothing
        DGL1.Columns.Clear()
        Me.Visible = False
    End Sub

    Private Sub ProcFillGrid(Optional ByVal StrFilterField As String = "", _
                                        Optional ByVal StrFilterValue As String = "", _
                                        Optional ByVal eFilterType As FilterType = FilterType.Remove)
        Dim DsTemp As DataSet = Nothing
        Dim bStrHeaderQry$ = ""
        Dim bCondStrMain$ = " Where 1=1 ", bCondStr$ = " Where 1=1 "
        Dim bStrToDate$ = ""
        Dim I As Integer = 0
        Dim ObjRepFormGlobal As AgLibrary.RepFormGlobal
        Dim CRepProc As ClsReportProcedures
        Try
            ObjRepFormGlobal = New AgLibrary.RepFormGlobal(AgL)
            CRepProc = New ClsReportProcedures(ObjRepFormGlobal)

            If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate

            DGL1.DataSource = Nothing
            DGL1.Columns.Clear()

            If eFilterType = FilterType.Similer Then
                If StrFilterField.Trim <> "" Then
                    bCondStr += " And vH.[" & StrFilterField & "] = " & AgL.Chk_Text(StrFilterValue) & " "
                End If
            ElseIf eFilterType = FilterType.Dissimilar Then
                If StrFilterField.Trim <> "" Then
                    bCondStr += " And vH.[" & StrFilterField & "] <> " & AgL.Chk_Text(StrFilterValue) & " "
                End If
            End If

            bCondStrMain += " And (((isnull(H.MeterReading,0) + isnull(E.OnEveryKms,0)) >= isnull(M.NextMeterReading,0)) "
            bCondStrMain += " OR (DateAdd(Day, isnull(E.OnEveryDays,0),'" & CDate(AgL.PubLoginDate) & "' )>=M.NextDate)) "

            bStrHeaderQry = " SELECT DISTINCT " & _
                                " L.Code AS [" & Col1VehicleCode & "], " & _
                                " H.RegistrationNo AS [" & Col1VehilceNo & "],  " & _
                                " E.Description AS [" & Col1ExpenseName & "],  " & _
                                " L.ExpenseType As [" & Col1ExpenseType & "],  " & _
                                " L.DueOnDate AS [" & Col1DueOnDate & "],  " & _
                                " L.DueOnMeterReading AS [" & Col1DueOnMeterReading & "],  " & _
                                " H.MeterReading AS [" & Col1CurrentMeterReading & "], " & _
                                " H.Description AS [" & Col1VehilceName & "],  " & _
                                " H.VehicleType As [" & Col1VehilceType & "], " & _
                                " H.VehicleModel As [" & Col1VehilceModal & "], " & _
                                " L.Remark As [" & Col1Remark & "], " & _
                                " L.Expense As [" & Col1ExpenseCode & "] " & _
                                " FROM (Select v1.* From Tp_Vehicle1 As v1 With (NoLock) Where (v1.DueOnDate IS NOT NULL  OR v1.DueOnMeterReading > 0 ) ) As L " & _
                                " LEFT JOIN Tp_Vehicle H ON H.Code = L.Code  " & _
                                " LEFT JOIN Tp_Expense E ON E.Code = L.Expense  " & _
                                 " LEFT JOIN Tp_MaintenanceExpenseEntry1 M WITH (NoLock) ON E.Code = M.Expense  " & _
                                " " & bCondStrMain & " "

            mQry = "Select vH.* " & _
                    " From (" & bStrHeaderQry & ") as vH " & _
                    " " & bCondStr & " Order By IsNull(Convert(SmallDateTime,[" & Col1DueOnDate & "])," & AgL.ConvertDate(AgL.PubLoginDate) & "), IsNull(Convert(Numeric(18,2), [" & Col1DueOnMeterReading & "]),0)  "
            DsTemp = AgL.FillData(mQry, AgL.GCn)

            DGL1.DataSource = DsTemp.Tables(0)
            Call AdjustGrid()
        Catch ex As Exception
            DGL1.DataSource = Nothing
            MsgBox(ex.Message)
        Finally
            CRepProc = Nothing : ObjRepFormGlobal = Nothing
            mBlnRefreshFlag = False
        End Try
    End Sub

    Private Sub DGL1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellContentClick
        Dim FrmObj As Form = Nothing
        Dim MdiObj As New MDIMain
        Dim StrUserPermission As String = ""
        Dim DTUP As New DataTable
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case BtnVehicleMaintenanceExpense
                    StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, MdiObj.MnuVehicleMaintenanceExpenseEntry.Name, MdiObj.MnuVehicleMaintenanceExpenseEntry.Text, DTUP)
                    If StrUserPermission.IndexOf("A") >= 0 Then
                        FrmObj = New FrmVehicleMaintenanceExpense(StrUserPermission, DTUP)
                    End If
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmVehicleMaintenanceExpense).VehicleCode = AgL.XNull(DGL1.Item(Col1VehicleCode, DGL1.CurrentRow.Index).Value)
                        CType(FrmObj, FrmVehicleMaintenanceExpense).ExpenseCode = AgL.XNull(DGL1.Item(Col1ExpenseCode, DGL1.CurrentRow.Index).Value)
                        CType(FrmObj, FrmVehicleMaintenanceExpense).DueOnDate = AgL.XNull(DGL1.Item(Col1DueOnDate, DGL1.CurrentRow.Index).Value)
                        CType(FrmObj, FrmVehicleMaintenanceExpense).DueOnMeterReading = AgL.VNull(DGL1.Item(Col1DueOnMeterReading, DGL1.CurrentRow.Index).Value)
                        CType(FrmObj, FrmVehicleMaintenanceExpense).EntryMode = "Add"

                        FrmObj.Text = MdiObj.MnuVehicleMaintenanceExpenseEntry.Text
                        FrmObj.Owner = Me
                        FrmObj.MdiParent = Me.MdiParent

                        FrmObj.Show()

                        mBlnRefreshFlag = True
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub AdjustGrid()
        Dim bObjCellStyle As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Try
            With DGL1
                .Columns(Col1VehicleCode).Visible = False : .Columns(Col1VehicleCode).Width = 0
                .Columns(Col1VehilceNo).Visible = True : .Columns(Col1VehilceNo).Width = 120
                .Columns(Col1VehilceName).Visible = True : .Columns(Col1VehilceName).Width = 120
                .Columns(Col1VehilceModal).Visible = True : .Columns(Col1VehilceModal).Width = 100

                .Columns(Col1ExpenseName).Visible = True : .Columns(Col1ExpenseName).Width = 120
                .Columns(Col1ExpenseType).Visible = True : .Columns(Col1ExpenseType).Width = 80
                .Columns(Col1Remark).Visible = False
                .Columns(Col1ExpenseCode).Visible = False

                .Columns(Col1DueOnDate).Visible = True : .Columns(Col1DueOnDate).Width = 80
                .Columns(Col1DueOnMeterReading).Visible = True : .Columns(Col1DueOnMeterReading).Width = 80 : .Columns(Col1DueOnMeterReading).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(Col1CurrentMeterReading).Visible = True : .Columns(Col1CurrentMeterReading).Width = 80 : .Columns(Col1CurrentMeterReading).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                AgCL.AddAgButtonColumn(DGL1, BtnVehicleMaintenanceExpense, 30, " ", True, False, , , , "Webdings", 10, "6")
                bObjCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
                bObjCellStyle = Nothing


                DGL1.ColumnHeadersHeight = 50
                DGL1.AllowUserToAddRows = False
                DGL1.EnableHeadersVisualStyles = False

                DGL1.Columns(Col1Remark).DefaultCellStyle.WrapMode = DataGridViewTriState.True
                DGL1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders

                DGL1.ReadOnly = True
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CMnu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
                mnuFilterSame.Click, mnuFilterNotSame.Click, mnuRemoveFilter.Click
        Dim bStrFilterField$ = "", bStrFilterValue$ = ""
        Try

            If DGL1.DataSource IsNot Nothing Then
                If DGL1.CurrentCell Is Nothing Then
                    If DGL1.Rows.Count > 0 Then
                        DGL1.CurrentCell = DGL1(Col1VehilceNo, 0)
                    End If
                End If
            End If

            If DGL1.CurrentCell IsNot Nothing Then
                bStrFilterField = DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                bStrFilterValue = AgL.XNull(DGL1.Item(DGL1.CurrentCell.ColumnIndex, DGL1.CurrentCell.RowIndex).Value)
            End If

            Select Case sender.name
                Case mnuFilterSame.Name
                    Call ProcFillGrid(bStrFilterField, bStrFilterValue, FilterType.Similer)

                Case mnuFilterNotSame.Name
                    Call ProcFillGrid(bStrFilterField, bStrFilterValue, FilterType.Dissimilar)

                Case mnuRemoveFilter.Name
                    Call ProcFillGrid("", "", FilterType.Remove)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
End Class