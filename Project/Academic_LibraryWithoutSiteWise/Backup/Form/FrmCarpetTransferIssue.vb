Public Class FrmCarpetTransferIssue
    Inherits TempStockTransferIssue


    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = AgTemplate_Common.ClsMain.Temp_NCat.StockTransferIssue

    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()


    End Sub
#End Region

    Private Sub FrmOtherMaterialTransferIssue_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtFromGodown.AgSelectedValue = RetDefaultGodown(AgL.PubSiteCode, AgL.PubDivCode, ClsMain.ItemType.CarpetSKU)
    End Sub

    Private Sub FrmCarpetOpeningStock_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).HeaderText = "Carpet SKU"
        Dgl1.Columns(Col1MeasurePerPcs).HeaderText = "Area Per Pcs"
        Dgl1.Columns(Col1TotalMeasure).HeaderText = "Total Area"
    End Sub

    Private Sub FrmCarpetOpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 596, 909)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And ItemType = '" & ClsMain.ItemType.CarpetSKU & "' "

        End Select
    End Sub

    Private Shadows Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim mQry As String
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = " SELECT S.YardArea     " & _
                   " FROM RUG_CarpetSku CS  " & _
                   " LEFT JOIN Rug_Size S ON Cs.Size = S.Code  " & _
                   " WHERE CS.Code = '" & Code & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.XNull(DtTemp.Rows(0)("YardArea"))
            Else
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function (" & Me.Name & ") ")
        End Try
    End Sub
End Class
