Imports System.Data.SqlClient
Public Class FrmSubjectMarks
    Private DTMaster As New DataTable()
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Public Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Public Const Col1Subject As Byte = 1
    Public Const Col1Marks As Byte = 2
    Public Const Col1Percentage As Byte = 3


    Dim mStrSubjectList As String = "", mStrMarksList As String = "", mStrPercentageList As String = ""
    Dim mStrArrSubject() As String = Nothing, mStrArrMarks() As String = Nothing, mStrArrPercentage() As String = Nothing

    Dim _mIsReadOnly As Boolean = False
    Dim mDblNetPercentage As Double = 0


    Public Property StrSubjectList() As String
        Get
            StrSubjectList = mStrSubjectList
        End Get
        Set(ByVal value As String)
            mStrSubjectList = value
        End Set
    End Property

    Public Property StrPercentageList() As String
        Get
            StrPercentageList = mStrPercentageList
        End Get
        Set(ByVal value As String)
            mStrPercentageList = value
        End Set
    End Property

    Public Property StrMarksList() As String
        Get
            StrMarksList = mStrMarksList
        End Get
        Set(ByVal value As String)
            mStrMarksList = value
        End Set
    End Property

    Public Property DblNetPercentage() As Double
        Get
            DblNetPercentage = mDblNetPercentage
        End Get
        Set(ByVal value As Double)
            mDblNetPercentage = value
        End Set
    End Property

    Public Property BoolIsReadonly() As Boolean
        Get
            BoolIsReadonly = _mIsReadOnly
        End Get
        Set(ByVal value As Boolean)
            _mIsReadOnly = value
        End Set
    End Property

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
        ''================< Member Data Grid >====================================
        ''==============================================================================

        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1Subject", 200, 50, "Subject", True, False)
            .AddAgNumberColumn(DGL1, "DGL1Marks", 100, 3, 2, False, "Marks", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Percentage", 100, 2, 2, False, "%", True, False, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 30
        DGL1.ReadOnly = _mIsReadOnly
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
            Call ProcFillSubjectMarks()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Ini_List()
        Try
            '<Executable Code>

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
            sender.CurrentRow.Selected = True
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

            End Select

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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Select Case sender.name
                '<Executable Code>
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
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

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, bIntTotalSubjects As Integer = 0
        Dim bStrSubjectList As String = "", bStrMarksList As String = "", bStrPercentageList As String = ""
        Dim bDblTotalMarks As Double = 0, bDblTotalPercentage As Double = 0
        Try
            If AgCL.AgIsDuplicate(DGL1, "" & Col1Subject & "") Then Exit Function

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Subject, I).Value Is Nothing Then .Item(Col1Subject, I).Value = ""
                    If .Item(Col1Marks, I).Value Is Nothing Then .Item(Col1Marks, I).Value = ""
                    If .Item(Col1Percentage, I).Value Is Nothing Then .Item(Col1Percentage, I).Value = ""

                    If .Item(Col1Subject, I).Value <> "" Then
                        If Val(.Item(Col1Marks, I).Value) = 0 Then
                            MsgBox("Marks Is 0 At Row No : " & .Item(Col_SNo, I).Value & " ", MsgBoxStyle.Information)
                            .CurrentCell = DGL1(Col1Marks, I) : DGL1.Focus() : Exit Function
                        End If

                        If Val(.Item(Col1Percentage, I).Value) = 0 Then
                            MsgBox("Percentage Is 0 At Row No : " & .Item(Col_SNo, I).Value & " ", MsgBoxStyle.Information)
                            .CurrentCell = DGL1(Col1Percentage, I) : DGL1.Focus() : Exit Function
                        End If

                        bStrSubjectList += IIf(bStrSubjectList.Trim = "", .Item(Col1Subject, I).Value.ToString, "," + .Item(Col1Subject, I).Value.ToString)
                        bStrMarksList += IIf(bStrMarksList.Trim = "", .Item(Col1Marks, I).Value.ToString, "," + .Item(Col1Marks, I).Value.ToString)
                        bStrPercentageList += IIf(bStrPercentageList.Trim = "", .Item(Col1Percentage, I).Value.ToString, "," + .Item(Col1Percentage, I).Value.ToString)

                        bIntTotalSubjects += 1
                        bDblTotalMarks += Val(.Item(Col1Marks, I).Value)
                        bDblTotalPercentage += Val(.Item(Col1Percentage, I).Value)
                    End If
                Next
            End With

            mStrSubjectList = bStrSubjectList
            mStrMarksList = bStrMarksList
            mStrPercentageList = bStrPercentageList

            If bDblTotalMarks > 0 Then
                mDblNetPercentage = bDblTotalPercentage / bIntTotalSubjects
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub ProcFillSubjectMarks()
        Dim I As Integer = 0
        Try
            If mStrSubjectList <> "" Then
                mStrArrSubject = Split(mStrSubjectList, ",")
            End If

            If mStrMarksList <> "" Then
                mStrArrMarks = Split(mStrMarksList, ",")
            End If

            If mStrPercentageList <> "" Then
                mStrArrPercentage = Split(mStrPercentageList, ",")
            End If

            With DGL1
                If mStrArrSubject IsNot Nothing Then
                    For I = 0 To mStrArrSubject.Length - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.RowCount - 1
                        DGL1.Item(Col1Subject, I).Value = mStrArrSubject(I)

                        If mStrArrMarks IsNot Nothing Then
                            If I <= mStrArrMarks.Length - 1 Then
                                DGL1.Item(Col1Marks, I).Value = mStrArrMarks(I)
                            End If
                        End If

                        If mStrArrPercentage IsNot Nothing Then
                            If I <= mStrArrPercentage.Length - 1 Then
                                DGL1.Item(Col1Percentage, I).Value = mStrArrPercentage(I)
                            End If
                        End If

                    Next
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnChargeDuw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Click, BtnCancel.Click
        Select Case sender.Name
            Case BtnOk.Name
                If Not Data_Validation() Then Exit Sub
                Me.Visible = False
            Case BtnCancel.Name
                Me.Visible = False
        End Select

    End Sub
End Class