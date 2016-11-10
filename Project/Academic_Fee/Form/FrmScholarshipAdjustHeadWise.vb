Imports System.Data.SqlClient
Public Class FrmScholarshipAdjustHeadWise
    Private DTMaster As New DataTable()
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Public Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1FeeDue1 As Byte = 1
    Private Const Col1Amount As Byte = 2

    Public mFeeDue1Str As String = ""
    Public mAmountStr As String = ""
    Public mVDate As String = ""
    Public mAdmissionDocId As String = ""
    Public mScholarshipAmt As Double = 0
    Public mDueQry As String = ""

    Dim mFeeDue1StrArr() As String = Nothing
    Dim mAmountStrArr() As String = Nothing

    Public Property ScholarshipAmt() As Double
        Get
            ScholarshipAmt = mScholarshipAmt
        End Get
        Set(ByVal value As Double)
            mScholarshipAmt = value
        End Set
    End Property

    Public Property DueQry() As String
        Get
            DueQry = mDueQry
        End Get
        Set(ByVal value As String)
            mDueQry = value
        End Set
    End Property

    Public Property AmountStr() As String
        Get
            AmountStr = mAmountStr
        End Get
        Set(ByVal value As String)
            mAmountStr = value
        End Set
    End Property

    Public Property FeeDue1Str() As String
        Get
            FeeDue1Str = mFeeDue1Str
        End Get
        Set(ByVal value As String)
            mFeeDue1Str = value
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
            .AddAgTextColumn(DGL1, "DGL1FeeDue1", 255, 50, "Fee", True, True)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 95, 8, 2, False, "Amount", True, False, True)
        End With
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
            If mFeeDue1Str = "" Then
                Call ProcFillFee(mAdmissionDocId, mVDate)
            Else
                Call ProcFillAmount()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Ini_List()
        Try
            mQry = "SELECT Fd1.Code, SgF.Name AS [Fee Name], Fd.V_Date AS [Due Date], " & _
                    " Fd1.Amount, Fd1.AdmissionDocId, Fd1.Fee AS FeeCode " & _
                    " FROM Sch_FeeDue1 Fd1 " & _
                    " LEFT JOIN Sch_FeeDue Fd ON Fd1.DocId = Fd.DocId " & _
                    " LEFT JOIN SubGroup SgF ON Fd1.Fee = SgF.SubCode " & _
                    " Where Fd.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " And " & _
                    " " & AgL.PubSiteCondition("Fd.Site_Code", AgL.PubSiteCode) & " "
            DGL1.AgHelpDataSet(Col1FeeDue1, 3) = AgL.FillData(mQry, AgL.GCn)

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
        Dim I As Integer = 0, bAmt As Double = 0
        Try
            If AgL.RequiredField(TxtSite_Code, "Site/Branch") Then Exit Function
            'If AgCL.AgIsDuplicate(DGL1, "" & Col1FeeDue1 & "") Then Exit Function

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1FeeDue1, I).Value <> "" Then
                        bAmt += .Item(Col1Amount, I).Value
                    End If
                Next
            End With
            If bAmt > mScholarshipAmt Then
                MsgBox("Adjusted Fee Amt Is Greater Than Scholarship Amount", MsgBoxStyle.Information)
                Exit Function
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub ProcFillAmount()
        Dim I As Integer = 0
        Try
            If mFeeDue1Str <> "" Then
                mFeeDue1StrArr = Split(mFeeDue1Str, ",")
            End If

            If mAmountStr <> "" Then
                mAmountStrArr = Split(mAmountStr, ",")
            End If

            With DGL1
                If mFeeDue1StrArr IsNot Nothing Then
                    For I = 0 To mFeeDue1StrArr.Length - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.RowCount
                        If mFeeDue1StrArr IsNot Nothing Then
                            If I <= mFeeDue1StrArr.Length - 1 Then
                                DGL1.AgSelectedValue(Col1FeeDue1, I) = mFeeDue1StrArr(I)
                                DGL1.Item(Col1Amount, I).Value = mAmountStrArr(I)
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
        Me.Close()
    End Sub

    Private Sub ProcFillFee(ByVal bAdmissionDocId As String, ByVal bVDate As String)
        Dim DtTemp As DataTable, DtTemp1 As DataTable
        Dim I As Integer
        Dim bAdvanceAmount As Double = 0
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub
            If mDueQry = "" Then Exit Sub


            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            'mQry = "SELECT VFd.FeeDue1Code, VFd.NetBalance + IsNull(V1.ReceiveAmount,0) As NetBalance " & _
            '        " FROM ViewSch_FeeDue VFd " & _
            '        " Left Join (SELECT Fr1.FeeDue1 AS FeeDue1Code, IsNULL(Sum(Fr1.Amount),0) AS ReceiveAmount, IsNULL(Sum(Fr1.Discount),0) AS Discount, IsNULL(Sum(Fr1.NetAmount),0) AS NetReceiveAmount FROM dbo.Sch_FeeReceive1 Fr1 Where Fr1.DocId = " & AgL.Chk_Text(IIf(Topctrl1.Mode = "Add", "", mSearchCode)) & "  GROUP BY Fr1.FeeDue1 ) V1 On VFd.FeeDue1Code = V1.FeeDue1Code " & _
            '        " WHERE VFd.NetBalance + IsNull(V1.ReceiveAmount,0) > 0 " & _
            '        " AND VFd.V_Date <= " & AgL.ConvertDate(bVDate) & " " & _
            '        " AND IsNull(Vfd.IsReversePosted,0) = 0 " & _
            '        " AND VFd.AdmissionDocId = " & AgL.Chk_Text(bAdmissionDocId) & " " & _
            '        " Order By Vfd.V_Date "

            DtTemp = AgL.FillData(mDueQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1FeeDue1, I) = AgL.XNull(.Rows(I)("FeeDue1Code"))
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("NetBalance")), "0.00")
                    Next I
                Else
                    MsgBox("No Fee Exists To Receive!...")
                    Me.Close()
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            DtTemp1 = Nothing
        End Try
    End Sub
End Class