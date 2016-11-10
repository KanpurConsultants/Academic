Imports System.Data.SqlClient
Public Class FrmAdvanceReminder
    Private DTMaster As New DataTable()
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Public Const Col1AdmissionDocId As String = "AdmissionDocId"
    Public Const Col1StudentName As String = "Student Name"
    Public Const Col1Advance As String = "Advance"
    Public Const Col1DueAmount As String = "Due Amount"
    Public Const Col1BtnAdjust As Byte = 0

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
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
            'AgL.WinSetting(Me, 297, 333, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            'Topctrl1.ChangeAgGridState(DGL1, False)
            Ini_List()
            DispText()
            Topctrl1.Mode = "Add"
            Call ProcFillAdvance()
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
                Case Col1AdmissionDocId
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

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSite_Code.Validating
        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                '<Executable Code>
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

    Private Sub ProcFillAdvance()
        Dim DsTemp As DataSet = Nothing
        Dim bQry$ = ""
        Dim I As Integer = 0
        Dim ObjRepFormGlobal As AgLibrary.RepFormGlobal
        Dim CRepProc As ClsReportProcedures
        Try
            ObjRepFormGlobal = New AgLibrary.RepFormGlobal(AgL)
            CRepProc = New ClsReportProcedures(ObjRepFormGlobal)

            TxtV_Date.Text = AgL.PubLoginDate

            bQry = "SELECT VfeeDue.AdmissionDocId , isnull(sum(VfeeDue.TillDate_NetBalance),0) AS CurrentDueAmount  " & _
                    " FROM (" & CRepProc.FunGetFeeDueStr(TxtV_Date.Text, TxtV_Date.Text) & ") As VFeeDue " & _
                    " GROUP BY VfeeDue.AdmissionDocId "

            mQry = "Select Adm.DocId as AdmissionDocId, Adm.StudentName as [Student Name], isnull(V1.Advance ,0) AS Advance, VMain.CurrentDueAmount as [Due Amount]  " & _
                    " From ViewSch_Admission Adm   " & _
                    " Left Join " & _
                    "       (SELECT Fr.AdmissionDocId, IsNull(Sum(Fr.AdvanceCarriedForward),0) - IsNull(Sum(Fr.Advance),0) - IsNull(Sum(vFRef.ExcessRefund),0) AS Advance   " & _
                    "       FROM Sch_FeeReceive Fr   " & _
                    "       Left Join (SELECT vFRef1.FeeReceiveDocId, IsNull(Sum(vFref1.ExcessRefund),0) AS ExcessRefund    " & _
                    "                   FROM Sch_FeeRefund FRef   " & _
                    "                   INNER JOIN " & _
                    "                   (SELECT FRef1.DocId, FRef1.FeeReceiveDocId, Sum(FRef1.NetAmount) AS ExcessRefund " & _
                    "                   FROM Sch_FeeRefund1 FRef1 " & _
                    "                   WHERE FRef1.ReturnHeadType = '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' " & _
                    "                   GROUP BY FRef1.DocId, FRef1.FeeReceiveDocId " & _
                    "                   ) vFref1 ON FRef.DocId = vFref1.DocId " & _
                    "                   Where FRef.V_Date <=  " & AgL.ConvertDate(TxtV_Date.Text) & " " & _
                    "                   GROUP BY vFRef1.FeeReceiveDocId) As vFRef On Fr.DocId = vFRef.FeeReceiveDocId   " & _
                    " Where Fr.V_Date <=  " & AgL.ConvertDate(TxtV_Date.Text) & " " & _
                    " GROUP BY Fr.AdmissionDocId) As V1 " & _
                    " On Adm.DocId = V1.AdmissionDocId " & _
                    " LEFT JOIN (" & bQry & ") as VMain On Adm.DocId = VMain.AdmissionDocId  " & _
                    " WHERE isnull(V1.Advance ,0) > 0 " & _
                    " AND " & AgL.PubSiteCondition("Adm.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY Adm.StudentName "

            DsTemp = AgL.FillData(mQry, AgL.GCn)

            DGL1.DataSource = DsTemp.Tables(0)

            Call AdjustGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            CRepProc = Nothing : ObjRepFormGlobal = Nothing
        End Try
    End Sub

    Private Sub DGL1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellContentClick
        Dim FrmObj As Form
        Dim I As Integer = 0
        Dim MdiObj As New MDIMain
        Dim StrUserPermission As String
        Dim DTUP As New DataTable
        Dim CFOpen As New ClsFunction
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1BtnAdjust
                    StrUserPermission = AgIniVar.FunGetUserPermission("Fee", MdiObj.MnuFmFeeReceiveEntry.Name, MdiObj.MnuFmFeeReceiveEntry.Text, DTUP)
                    FrmObj = New FrmFeeReceiveEntry(StrUserPermission, DTUP)
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmFeeReceiveEntry).AdmissionDocId = DGL1.Item(Col1AdmissionDocId, DGL1.CurrentRow.Index).Value
                        FrmObj.MdiParent = Me.MdiParent
                        FrmObj.Show()
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
                .Columns(Col1AdmissionDocId).Visible = False
                .Columns(Col1StudentName).ReadOnly = True
                .Columns(Col1Advance).ReadOnly = True
                .Columns(Col1DueAmount).ReadOnly = True
                .Columns(Col1StudentName).Width = 350
                .Columns(Col1Advance).Width = 120
                .Columns(Col1DueAmount).Width = 120
                AgCL.AddAgButtonColumn(DGL1, "BtnOpenFeeReceipt", 30, " ", True, False, , , , "Webdings", 10, "6")

                bObjCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
                .Columns(Col1Advance).DefaultCellStyle = bObjCellStyle
                .Columns(Col1DueAmount).DefaultCellStyle = bObjCellStyle
                bObjCellStyle = Nothing
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)

    End Sub
End Class