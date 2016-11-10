Imports System.Data.SqlClient
Public Class FrmInstallmentReminder
    Private DTMaster As New DataTable()
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1BtnReminder As String = "Reminder"
    Protected Const Col1DueInstallmentUid As String = "DueInstallmentUid"
    Protected Const Col1DueInstallmentSr As String = "DueInstallmentSr"
    Protected Const Col1StudentName As String = "Student"
    Protected Const Col1AdmissionID As String = "Admission Id"
    Protected Const Col1InstallmentDate As String = "Installment Date"
    Protected Const Col1InstallmentAmount As String = "Installment"
    Protected Const Col1AdmissionDocId As String = "AdmissionDocId"
    Protected Const Col1SubCode As String = "SubCode"

    Dim mBlnRefreshFlag As Boolean = False

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub FrmFollowupReminder_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            If mBlnRefreshFlag Then
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

    Private Sub ProcFillGrid()
        Dim DsTemp As DataSet = Nothing
        Dim bStrHeaderQry$ = ""
        Dim bCondStrMain$ = " Where 1=1 ", bCondStr$ = " Where 1=1 "

        Dim I As Integer = 0
        Dim ObjRepFormGlobal As AgLibrary.RepFormGlobal
        Dim CRepProc As ClsReportProcedures
        Try
            ObjRepFormGlobal = New AgLibrary.RepFormGlobal(AgL)
            CRepProc = New ClsReportProcedures(ObjRepFormGlobal)

            If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate

            DGL1.DataSource = Nothing
            DGL1.Columns.Clear()


            bCondStrMain += " AND H.InActiveDate IS NULL " & _
                            " And IsNull(L.InstallmentAmount,0) > 0 " & _
                            " AND L.InstallmentDate IS NOT NULL " & _
                            " AND " & AgL.ConvertDate(TxtV_Date.Text) & " BETWEEN  Dateadd(day, L.RemindBeforeDays * -1, L.InstallmentDate) AND Dateadd(day, L.RemindAfterDays , L.InstallmentDate) "
            bCondStrMain += " And IsNull(L.IsInActive,0) = 0 "
            bCondStrMain += " And A.Site_Code = " & AgL.Chk_Text(AgL.PubSiteCode) & " "

            bStrHeaderQry = "SELECT Convert(NVARCHAR(36), L.UID) As [" & Col1DueInstallmentUid & "], " & _
                            " L.Sr As [" & Col1DueInstallmentSr & "], " & _
                            " A.StudentName As [" & Col1StudentName & "], " & _
                            " A.AdmissionID As [" & Col1AdmissionID & "], " & _
                            " " & AgL.ConvertDateField("L.InstallmentDate") & " As [" & Col1InstallmentDate & "], " & _
                            " Convert(Numeric(18,2),L.InstallmentAmount) As [" & Col1InstallmentAmount & "], " & _
                            " H.AdmissionDocId As [" & Col1AdmissionDocId & "], " & _
                            " H.SubCode As [" & Col1SubCode & "]  " & _
                            " FROM (Sch_DueInstallment H " & _
                            " INNER JOIN Sch_DueInstallment1 L ON H.UID = L.UID) " & _
                            " LEFT JOIN ViewSch_Admission A ON A.DocId = H.AdmissionDocId  " & _
                            " " & bCondStrMain & " "

            mQry = "Select vH.* " & _
                    " From (" & bStrHeaderQry & ") as vH " & _
                    " " & bCondStr & " Order By Convert(SmallDateTime,[" & Col1InstallmentDate & "]) "
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
        Dim StrUserPermission As String
        Dim DTUP As New DataTable
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1BtnReminder
                    StrUserPermission = AgIniVar.FunGetUserPermission(Academic_Objects.ClsConstant.Module_Academic_Fee, MdiObj.MnuFmFeeReceiveEntry.Name, MdiObj.MnuFmFeeReceiveEntry.Text, DTUP)
                    If StrUserPermission.IndexOf("A") >= 0 Then
                        FrmObj = New FrmFeeReceiveEntry(StrUserPermission, DTUP)
                    End If
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmFeeReceiveEntry).AdmissionDocId = AgL.XNull(DGL1.Item(Col1AdmissionDocId, DGL1.CurrentRow.Index).Value)
                        CType(FrmObj, FrmFeeReceiveEntry).DueInstallmentUId = AgL.XNull(DGL1.Item(Col1DueInstallmentUid, DGL1.CurrentRow.Index).Value.ToString)
                        CType(FrmObj, FrmFeeReceiveEntry).DueInstallmentSr = AgL.VNull(DGL1.Item(Col1DueInstallmentSr, DGL1.CurrentRow.Index).Value.ToString)
                        CType(FrmObj, FrmFeeReceiveEntry).InstallmentAmount = AgL.VNull(DGL1.Item(Col1InstallmentAmount, DGL1.CurrentRow.Index).Value.ToString)

                        CType(FrmObj, FrmFeeReceiveEntry).EntryMode = "Add"

                        FrmObj.Text = MdiObj.MnuFmFeeReceiveEntry.Text
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
                .Columns(Col1DueInstallmentUid).Visible = False : .Columns(Col1DueInstallmentUid).Width = 80
                .Columns(Col1DueInstallmentSr).Visible = False : .Columns(Col1DueInstallmentSr).Width = 80
                .Columns(Col1StudentName).Visible = True : .Columns(Col1StudentName).Width = 200
                .Columns(Col1AdmissionID).Visible = True : .Columns(Col1AdmissionID).Width = 150
                .Columns(Col1InstallmentDate).Visible = True : .Columns(Col1InstallmentDate).Width = 80
                .Columns(Col1InstallmentAmount).Visible = True : .Columns(Col1InstallmentAmount).Width = 100 : .Columns(Col1InstallmentAmount).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(Col1AdmissionDocId).Visible = False : .Columns(Col1AdmissionDocId).Width = 80
                .Columns(Col1SubCode).Visible = False : .Columns(Col1SubCode).Width = 80

                AgCL.AddAgButtonColumn(DGL1, Col1BtnReminder, 30, " ", True, False, , , , "Webdings", 10, "6")
                bObjCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
                bObjCellStyle = Nothing


                DGL1.ColumnHeadersHeight = 50
                DGL1.AllowUserToAddRows = False
                DGL1.EnableHeadersVisualStyles = False

                DGL1.ReadOnly = True
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class