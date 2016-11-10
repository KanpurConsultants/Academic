Imports System.Data.SqlClient
Public Class FrmScholarshipHeadWise
    Private DTMaster As New DataTable()
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Public Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Public Const Col1FeeCode As Byte = 1
    Public Const Col1Scholarship As Byte = 2
    
    Dim mFeeCodeStr As String = "", mFeeHeadStr As String = "", mScholarshipStr As String = ""
    Dim mDblTotalScholarshipAmount As Double = 0

    Dim mFeeCodeStrArr() As String = Nothing
    Dim mScholarshipStrArr() As String = Nothing

    Public Property FeeHeadStr() As String
        Get
            FeeHeadStr = mFeeHeadStr
        End Get
        Set(ByVal value As String)
            mFeeHeadStr = value
        End Set
    End Property

    Public Property FeeCodeStr() As String
        Get
            FeeCodeStr = mFeeCodeStr
        End Get
        Set(ByVal value As String)
            mFeeCodeStr = value
        End Set
    End Property

    Public Property ScholarshipStr() As String
        Get
            ScholarshipStr = mScholarshipStr
        End Get
        Set(ByVal value As String)
            mScholarshipStr = value
        End Set
    End Property

    Public Property DblTotalScholarshipAmount() As Double
        Get
            DblTotalScholarshipAmount = mDblTotalScholarshipAmount
        End Get
        Set(ByVal value As Double)
            mDblTotalScholarshipAmount = value
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
            .AddAgTextColumn(DGL1, "DGL1FeeCode", 300, 50, "FeeCode", True, False)
            .AddAgNumberColumn(DGL1, "DGL1ScholarShip", 100, 8, 2, False, "ScholarShip", True, False, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 30
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
            Call ProcFillScholarship()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select F.Code, F.Name as [Fee], F.ManualCode " & _
                    " From ViewSch_Fee F " & _
                    " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "F.Site_Code", AgL.PubSiteCode, "F.CommonAc") & " " & _
                    " Order By F.Name "
            DGL1.AgHelpDataSet(Col1FeeCode) = AgL.FillData(mQry, AgL.GCn)

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

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0
        Dim bDblTotalScholarshipAmt As Double = 0
        Dim bFeeCodeStr As String = "", bFeeStr As String = "", bScholarshipStr As String = ""

        Try
            If AgL.RequiredField(TxtSite_Code, "Site/Branch") Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1FeeCode & "") Then Exit Function

            bDblTotalScholarshipAmt = 0
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1FeeCode, I).Value <> "" Then
                        If .Item(Col1Scholarship, I).Value = "" Then
                            MsgBox("Scholarship Is 0 At Row No : " & .Item(Col_SNo, I).Value & " ", MsgBoxStyle.Information)
                            .CurrentCell = DGL1(Col1Scholarship, I) : DGL1.Focus() : Exit Function
                        Else
                            bFeeStr += IIf(bFeeStr.Trim = "", .Item(Col1FeeCode, I).Value, "," + .Item(Col1FeeCode, I).Value)
                            bFeeCodeStr += .AgSelectedValue(Col1FeeCode, I) + ","
                            bScholarshipStr += .Item(Col1Scholarship, I).Value + ","
                            bDblTotalScholarshipAmt += Val(.Item(Col1Scholarship, I).Value)
                        End If
                    End If
                Next
            End With

            mFeeHeadStr = bFeeStr
            mFeeCodeStr = bFeeCodeStr
            mScholarshipStr = bScholarshipStr
            mDblTotalScholarshipAmount = bDblTotalScholarshipAmt

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub ProcFillScholarship()
        Dim I As Integer = 0
        Try
            If mFeeCodeStr <> "" Then
                mFeeCodeStrArr = Split(mFeeCodeStr, ",")
            End If

            If mScholarshipStr <> "" Then
                mScholarshipStrArr = Split(mScholarshipStr, ",")
            End If

            With DGL1
                If mFeeCodeStrArr IsNot Nothing Then
                    For I = 0 To mFeeCodeStrArr.Length - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.RowCount - 1
                        If mFeeCodeStrArr IsNot Nothing Then
                            If I <= mFeeCodeStrArr.Length - 1 Then
                                DGL1.AgSelectedValue(Col1FeeCode, I) = mFeeCodeStrArr(I)
                                DGL1.Item(Col1Scholarship, I).Value = mScholarshipStrArr(I)
                            End If
                        End If
                    Next
                End If              
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnChargeDuw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Click
        If Not Data_Validation() Then Exit Sub
        Me.Visible = False
    End Sub
End Class