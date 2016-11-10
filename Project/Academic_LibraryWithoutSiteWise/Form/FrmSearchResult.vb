Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSearchResult
    Dim mQry$ = ""

    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Public WithEvents Dgl2 As New AgControls.AgDataGrid
    Public WithEvents Dgl3 As New AgControls.AgDataGrid

    Dim DTIssueDetail As DataTable = Nothing
    Dim DTRequistionDetail As DataTable = Nothing

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        'AgL.FPaintForm(Me, e, 0)
        Me.BackColor = Color.White
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.ActiveControl IsNot Nothing Then
            If Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Me.Close()
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 660, 885, 0, 0)
            AgL.GridDesign(Dgl1)
            AgL.GridDesign(Dgl2)
            AgL.GridDesign(Dgl3)
            IniGrid()
            RbtPendingToReceive.Checked = True : RbtPendingToIndent.Checked = True
            ProcFillIssueDetail()
            ProcFillRequistionDetail()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IniGrid()
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Dgl1.ColumnHeadersHeight = 35
        'Dgl1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Dgl1.AllowUserToAddRows = False
        'Dgl1.AllowUserToResizeColumns = True
        Dgl1.ReadOnly = True
        Dgl1.AllowUserToOrderColumns = True
        Dgl1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dgl1.ColumnHeadersDefaultCellStyle.Font = New Font(New FontFamily("Arial"), 9)
        Dgl1.DefaultCellStyle.Font = New Font(New FontFamily("Arial"), 8)

        AgL.AddAgDataGrid(Dgl2, Pnl2)
        Dgl2.EnableHeadersVisualStyles = False
        Dgl2.Anchor = AnchorStyles.None
        Dgl2.ColumnHeadersHeight = 35
        Dgl2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Dgl2.AllowUserToAddRows = False
        Dgl2.AllowUserToResizeColumns = True
        Dgl2.ReadOnly = True
        Dgl2.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dgl2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Dgl2.ColumnHeadersDefaultCellStyle.Font = New Font(New FontFamily("Arial"), 9)
        Dgl2.DefaultCellStyle.Font = New Font(New FontFamily("Arial"), 8)

        AgL.AddAgDataGrid(Dgl3, Panel2)
        Dgl3.EnableHeadersVisualStyles = False
        Dgl3.Anchor = AnchorStyles.None
        Dgl3.ColumnHeadersHeight = 35
        Dgl3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Dgl3.AllowUserToAddRows = False
        Dgl3.AllowUserToResizeColumns = True
        Dgl3.ReadOnly = True
        Dgl3.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dgl3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells
        Dgl3.ColumnHeadersDefaultCellStyle.Font = New Font(New FontFamily("Arial"), 9)
        Dgl3.DefaultCellStyle.Font = New Font(New FontFamily("Arial"), 8)
    End Sub

    Public Sub ProcShowResult(ByVal DTMaster As DataTable)
        Try
            Dgl1.DataSource = DTMaster
            Call ProcAdjustMainGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcChangeLables(ByVal bRow As Integer)
        Try
            With Dgl1
                LblBookCode.Text = AgL.XNull(.Item("BookCode", bRow).Value)
                LblTitle.Text = AgL.XNull(.Item("BookTitle", bRow).Value)
                LblNoOfBooks.Text = AgL.VNull(.Item("No Of Books", bRow).Value)
                LblCurrentStock.Text = AgL.VNull(.Item("Current Stock", bRow).Value)
                LblRequistion.Text = AgL.VNull(.Item("Required Qty", bRow).Value)
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

        Private Sub Dgl1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.RowEnter
        Try
            Call ProcChangeLables(e.RowIndex)
            Call ProcFilterIssueLineDetail(DTIssueDetail, AgL.XNull(Dgl1.Item("ItemCode", e.RowIndex).Value))
            Call ProcFilterRequistionLineDetail(DTRequistionDetail, AgL.XNull(Dgl1.Item("ItemCode", e.RowIndex).Value))
            Calulation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcAdjustMainGrid()
        Dim I As Integer = 0
        Try
            With Dgl1
                .Columns("SubjectCode").Visible = False
                .Columns("BookTypeCode").Visible = False
                '.Columns("AccessionNo").Visible = False
                '.Columns("BookId").Visible = False
                .Columns("ItemCode").Visible = False
                .Columns("BookCode").Visible = False
                .Columns("SearchKeywords").Visible = False
                .Columns("MsCode").Visible = False

                .Columns("No Of Books").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Current Stock").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Required Qty").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns("No Of Books").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Current Stock").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns("Required Qty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight

                .Columns("Required Qty").HeaderText = "Req Qty"
                .Columns("Subject").Width = 90
                .Columns("BookType").Width = 75
                .Columns("No Of Books").Width = 50
                .Columns("Current Stock").Width = 50
                .Columns("Required Qty").Width = 35
                .Columns("ISBN").Width = 40
                .Columns("Publisher").Width = 120
                .Columns("Writer").Width = 90
                .Columns("BookCode").Width = 75
                .Columns("BookTitle").Width = 140
                .Columns("Edition").Width = 45
                .Columns("MsCode").Width = 80
                .Columns("Almira").Width = 70
                .Columns("Shelf").Width = 40

                For I = 0 To .Columns.Count - 1
                    .Columns(I).SortMode = DataGridViewColumnSortMode.NotSortable
                Next

            End With
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillIssueDetail()
        Try
            mQry = "SELECT " & _
                    " Case When Vt.NCat = '" & ClsMain.Temp_NCat.BookIssueReceive & "' Then 'Member Issue' Else " & _
                    " 'Binder Issue' End As [Issue Type], " & _
                    " I.V_Type  + '-' + Convert(NVARCHAR,I.V_No) AS [Issue No], I.V_Date As [Issue Date] , " & _
                    " IsNull(Sg.DispName,Sg1.DispName) As [Member / Vendor], " & _
                    " M.MemberCardNo As [Member Card No], " & _
                    " Id.ToReturnDate As [To Return Date], DateDiff(Day,getdate(), Id.ToReturnDate) As AfterDays, " & _
                    " Id.Book As BookCode, Id.ReturnDate, Id.Book_UID As [Book Id], Id.AccessionNo As [Accession No] " & _
                    " FROM Lib_BookIssueDetail Id  " & _
                    " LEFT JOIN Lib_BookIssue I ON Id.DocId = I.DocID " & _
                    " LEFT JOIN SubGroup Sg ON I.Member = Sg.SubCode " & _
                    " LEFT JOIN SubGroup Sg1 On I.Vendor = Sg1.SubCode " & _
                    " LEFT JOIN Lib_Member M ON Sg.SubCode = M.SubCode " & _
                    " LEFT JOIN Voucher_Type Vt On I.V_Type = Vt.V_Type "


            '" WHERE ReturnDocId Is Not Null "

            DTIssueDetail = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillRequistionDetail()
        Try
            mQry = "SELECT Vt.Description As [Requistion Type], R.V_Type + '-' + Convert(NVARCHAR,R.V_No) AS RequistionNo, R.V_Date As [Requistion Date] ,  " & _
                    " Sg.DispName AS [Member Name], M.MemberCardNo As [Member Card No], " & _
                    " Rd.Item AS BookCode, Rd.PurchaseIndent, Rd.IssueDocID " & _
                    " FROM RequisitionDetail Rd " & _
                    " LEFT JOIN Requisition R ON Rd.DocId = R.DocID " & _
                    " LEFT JOIN SubGroup Sg ON R.RequisitionBy = Sg.SubCode " & _
                    " LEFT JOIN Lib_Member M ON Sg.SubCode  = M.SubCode " & _
                    " LEFT JOIN Voucher_Type Vt On R.V_Type = Vt.V_Type "
            DTRequistionDetail = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFilterIssueLineDetail(ByVal DTable As DataTable, ByVal BookCode As String)
        Try
            If RbtAllIssued.Checked = True Then
                DTable.DefaultView.RowFilter = " BookCode = '" & BookCode & "' "
            Else
                DTable.DefaultView.RowFilter = " BookCode = '" & BookCode & "' And ReturnDate Is Null "
            End If

            Dgl2.DataSource = DTable.DefaultView.Table
            ProcAdjustIssueGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFilterRequistionLineDetail(ByVal DTable As DataTable, ByVal BookCode As String)
        Try
            If RbtAllRequistion.Checked = True Then
                DTable.DefaultView.RowFilter = " BookCode = '" & BookCode & "' "
            Else
                DTable.DefaultView.RowFilter = " BookCode = '" & BookCode & "' And PurchaseIndent Is Null And IssueDocID Is Null "
            End If

            Dgl3.DataSource = DTable.DefaultView.Table
            ProcAdjustRequistionGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcAdjustIssueGrid()
        Dim I As Integer = 0
        Try
            With Dgl2
                .Columns("BookCode").Visible = False
                .Columns("AfterDays").Visible = False
                .Columns("Issue No").Visible = False
                .Columns("ReturnDate").Visible = False
                For I = 0 To .Columns.Count - 1
                    .Columns(I).SortMode = DataGridViewColumnSortMode.NotSortable
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcAdjustRequistionGrid()
        Dim I As Integer = 0
        Try
            With Dgl3
                .Columns("BookCode").Visible = False
                .Columns("RequistionNo").Visible = False
                .Columns("PurchaseIndent").Visible = False
                .Columns("IssueDocID").Visible = False
                For I = 0 To .Columns.Count - 1
                        .Columns(I).SortMode = DataGridViewColumnSortMode.NotSortable
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calulation()
        LblToBeReturnToday.Text = 0 : LblToBeReturnTommorow.Text = 0 : LblToBeReturnDayAfterTommorow.Text = 0
        Dim I As Integer = 0
        Try
            With Dgl2
                For I = 0 To .Rows.Count - 1
                    If AgL.XNull(.Item("Issue No", I).Value) <> "" Then
                        If AgL.VNull(.Item("AfterDays", I).Value) = 0 Then
                            LblToBeReturnToday.Text = Val(LblToBeReturnToday.Text) + 1
                        End If

                        If AgL.VNull(.Item("AfterDays", I).Value) = 1 Then
                            LblToBeReturnTommorow.Text = Val(LblToBeReturnTommorow.Text) + 1
                        End If

                        If AgL.VNull(.Item("AfterDays", I).Value) = 2 Then
                            LblToBeReturnDayAfterTommorow.Text = Val(LblToBeReturnDayAfterTommorow.Text) + 1
                        End If
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RbtAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbtAllIssued.Click, RbtPendingToReceive.Click, RbtAllRequistion.Click, RbtPendingToIndent.Click
        Try
            Select Case sender.Name
                Case RbtAllIssued.Name, RbtPendingToReceive.Name
                    Call ProcFilterIssueLineDetail(DTIssueDetail, AgL.XNull(Dgl1.Item("ItemCode", Dgl1.CurrentRow.Index).Value))

                Case RbtAllRequistion.Name, RbtPendingToIndent.Name
                    Call ProcFilterRequistionLineDetail(DTRequistionDetail, AgL.XNull(Dgl1.Item("ItemCode", Dgl1.CurrentRow.Index).Value))

            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class
