Public Class FrmCarpetPurchaseQuotation
    Inherits AgTemplate.TempPurchQuotation

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        ' Me.EntryNCat = AgTemplate_Purchase.ClsMain.Temp_NCat.PurchaseQuotation
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Visible = True
        '
        'LblBillingType
        '
        Me.LblBillingType.Visible = True
        '
        'Label33
        '
        Me.Label33.Size = New System.Drawing.Size(82, 16)
        Me.Label33.Text = "Total Area :"
        '
        'FrmCarpetPurchaseQuotation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(972, 547)
        Me.LogLineTableCsv = "PurchQuotationDetail_Log"
        Me.LogTableName = "PurchQuotation_Log"
        Me.MainLineTableCsv = "PurchQuotationDetail"
        Me.MainTableName = "PurchQuotation"
        Me.Name = "FrmCarpetPurchaseQuotation"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private Sub FrmYarnSKUOpeningStock_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).HeaderText = "Carpet Sku"
        Dgl1.Columns(Col1MeasurePerPcs).HeaderText = "Area Per Pcs"
        Dgl1.Columns(Col1TotalMeasure).HeaderText = "Total Area"
        Dgl1.Columns(Col1MeasureUnit).HeaderText = "Area Unit"

        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
    End Sub

    Private Sub FrmCarpetPurchaseIndent_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer = 0
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0")
        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    .Item(Col1Qty, I).Value = Format(Val(.Item(Col1Qty, I).Value), "0")
                End If
            Next
        End With
    End Sub

    Private Sub FrmYarnSKUOpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 581, 980)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.Book & "' "
        End Select
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

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
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

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtBillingType.AgSelectedValue = "Area"
    End Sub
End Class
