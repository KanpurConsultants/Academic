Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSubjectClassification
    Dim mQry$ = ""

    Public WithEvents Dgl1 As New AgControls.AgDataGrid

    Protected Const ColSNo As String = "S.No."
    Protected Const Col1SubjectCode As String = "SubjectCode"
    Protected Const Col1Subject As String = "Subject"
    Protected Const Col1UnderSubjectCode As String = "UnderSubjectCode"
    Protected Const Col1UnderSubject As String = "Under Subject"

    Dim DtMaster As DataTable = Nothing

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        '    'AgL.FPaintForm(Me, e, 0)
        '    'Me.BackColor = Color.White
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
            AgL.WinSetting(Me, 512, 454, 0, 0)
            AgL.GridDesign(Dgl1)
            IniGrid()
            IniList()
            ProcFill()
            RbtAll.Checked = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IniGrid()
        With AgCL
            .AddAgTextColumn(Dgl1, Col1UnderSubject, 200, 20, Col1UnderSubject, True, False, False)
        End With

        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AllowUserToAddRows = False
    End Sub

    Private Sub IniList()
        Try
            mQry = " SELECT H.Code AS Code, H.Description AS Subject FROM Lib_Subject H "
            TxtForSubject.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)
            Dgl1.AgHelpDataSet(Col1UnderSubject) = TxtForSubject.AgHelpDataSet
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ProcFill()
        Try
            mQry = " SELECT H.Code AS SubjectCode, H.Description AS Subject, H.UnderSubject As UnderSubjectCode " & _
                    " FROM Lib_Subject H " & _
                    " LEFT JOIN Lib_Subject L On H.UnderSubject = L.Code " & _
                    " Order By H.Description "
            DtMaster = AgL.FillData(mQry, AgL.GCn).Tables(0)
            Dgl1.DataSource = DtMaster

            ProcAdjustIssueGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub ProcFilterGrid()
        Dim bConStr$ = ""
        Try
            If RbtAll.Checked Then
                DtMaster.DefaultView.RowFilter = "1=1"
            ElseIf RbtAssigned.Checked Then
                DtMaster.DefaultView.RowFilter = " UnderSubjectCode Is Not Null "
            ElseIf RbtUnAssigned.Checked Then
                DtMaster.DefaultView.RowFilter = " UnderSubjectCode Is Null "
            End If

            If TxtForSubject.AgSelectedValue <> "" Then
                DtMaster.DefaultView.RowFilter += " And UnderSubjectCode  = '" & TxtForSubject.AgSelectedValue & "' "
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub RbtAll_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbtAll.Click, RbtUnAssigned.Click, RbtAssigned.Click
        ProcFilterGrid()
    End Sub

    Private Sub TxtForSubject_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtForSubject.Validating
        ProcFilterGrid()
    End Sub

    Private Sub ProcAdjustIssueGrid()
        Dim I As Integer = 0
        Try
            With Dgl1
                .Columns(Col1SubjectCode).Visible = False
                .Columns(Col1UnderSubjectCode).Visible = False

                .Columns(Col1Subject).Width = 214

                .Columns(Col1Subject).ReadOnly = True

                .Columns(Col1UnderSubject).DisplayIndex = 3
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        Dim mRowIndex As Integer = 0
        Dim mColumnIndex As Integer = 0
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1UnderSubject
                    If Dgl1.Item(Col1SubjectCode, mRowIndex).Value = Dgl1.AgSelectedValue(Col1UnderSubject, mRowIndex) Then
                        MsgBox("Subject And UnderSubject Can't Be Equal...!", MsgBoxStyle.Information)
                        Dgl1.AgSelectedValue(Col1UnderSubject, mRowIndex) = ""
                        Exit Sub
                    End If
                    Call ProcSave(Dgl1.Item(Col1SubjectCode, mRowIndex).Value, Dgl1.AgSelectedValue(Col1UnderSubject, mRowIndex))
                    Dgl1.Item(Col1UnderSubjectCode, mRowIndex).Value = Dgl1.AgSelectedValue(Col1UnderSubject, mRowIndex)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcSave(ByVal SubjectCode As String, ByVal UnderSubjectCode As String)
        Try
            

            mQry = " UPDATE Lib_Subject SET UnderSubject = " & AgL.Chk_Text(UnderSubjectCode) & " " & _
                    " WHERE Code = '" & SubjectCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    '' Private Sub dataGridView1_CellFormatting(ByVal sender As Object, _
    ''ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) _
    ''    Handles Dgl1.CellFormatting
    ''     'Dgl1.AgSelectedValue(Col1UnderSubject, e.RowIndex) = AgL.XNull(Dgl1.Item(Col1UnderSubjectCode, e.RowIndex).Value)
    '' End Sub

    Private Sub Dgl1_DataBindingComplete(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewBindingCompleteEventArgs) Handles Dgl1.DataBindingComplete
        Dim I As Integer
        With Dgl1
            For I = 0 To .Rows.Count - 1
                Dgl1.AgSelectedValue(Col1UnderSubject, I) = AgL.XNull(Dgl1.Item(Col1UnderSubjectCode, I).Value)
            Next
        End With
        'Dim Obj()
        'Dgl1.Columns.CopyTo(Obj, Dgl1.Columns(Col1UnderSubjectCode).Index)
        'Dim Col As DataGridViewTextBoxColumn
        'Col = Dgl1.Columns(Col1UnderSubjectCode).Clone
        'Dgl1.Columns.Add(Col)
    End Sub

    Private Sub BtnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class
