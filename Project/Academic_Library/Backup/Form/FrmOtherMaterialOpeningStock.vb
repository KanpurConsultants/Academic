Public Class FrmOtherMaterialOpeningStock
    Inherits AgTemplate_Common.TempStockAdjustment

    Protected Const Col1ItemGroup As String = "Item Group"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.OtherMaterialStockOpening
        Me.StockNature = AgTemplate_Common.TempStockAdjustment.StockEffect.StkIn
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
        'TxtGodown
        '
        Me.TxtGodown.Location = New System.Drawing.Point(260, 79)
        Me.TxtGodown.Size = New System.Drawing.Size(436, 18)
        '
        'LblSaleOrderNo
        '
        Me.LblSaleOrderNo.Location = New System.Drawing.Point(148, 81)
        '
        'LblTotalQty
        '
        Me.LblTotalQty.Location = New System.Drawing.Point(463, 3)
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.Location = New System.Drawing.Point(378, 3)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Location = New System.Drawing.Point(125, 3)
        Me.LblTotalMeasure.Visible = False
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(260, 99)
        Me.TxtRemarks.Size = New System.Drawing.Size(436, 18)
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(148, 101)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(242, 87)
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(14, 3)
        Me.Label33.Size = New System.Drawing.Size(82, 16)
        Me.Label33.Text = "Total Area :"
        Me.Label33.Visible = False
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.Location = New System.Drawing.Point(796, 3)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(685, 3)
        '
        'TxtAcName
        '
        Me.TxtAcName.Location = New System.Drawing.Point(260, 59)
        Me.TxtAcName.Size = New System.Drawing.Size(436, 18)
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(148, 61)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(366, 40)
        Me.LblV_No.Size = New System.Drawing.Size(80, 16)
        Me.LblV_No.Text = "Opening No."
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(488, 39)
        Me.TxtV_No.Size = New System.Drawing.Size(208, 18)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(244, 45)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(148, 40)
        Me.LblV_Date.Size = New System.Drawing.Size(87, 16)
        Me.LblV_Date.Text = "Opening Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(472, 25)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(260, 39)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(366, 21)
        Me.LblV_Type.Size = New System.Drawing.Size(88, 16)
        Me.LblV_Type.Text = "Opening Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(488, 19)
        Me.TxtV_Type.Size = New System.Drawing.Size(208, 18)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(244, 25)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(148, 20)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(260, 19)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(766, 39)
        '
        'FrmYarnSKUOpeningStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(901, 458)
        Me.EntryNCat = "PRO"
        Me.LogLineTableCsv = "Stock_LOG"
        Me.LogTableName = "StockHead_Log"
        Me.MainLineTableCsv = "Stock"
        Me.MainTableName = "StockHead"
        Me.Name = "FrmYarnSKUOpeningStock"
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

    End Sub


#End Region

    Private Sub FrmYarnSKUTransferIssue_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer = 0
        For I = 0 To Dgl1.Rows.Count - 1
            Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)
        Next
    End Sub

    Private Sub FrmYarnSKUOpeningStock_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        AgCL.AddAgTextColumn(Dgl1, Col1ItemGroup, 150, 0, Col1ItemGroup, True, True)
        Dgl1.Columns(Col1ItemGroup).DisplayIndex = 2
        Dgl1.Columns(Col1Item).HeaderText = "Other Material"
        Dgl1.Columns(Col1Process).Visible = False
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
    End Sub

    Private Sub FrmYarnSKUOpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 492, 910)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub


    Protected Shadows Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
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
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.OtherMaterial & "' "

        End Select
    End Sub

    Private Shadows Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim mQry As String = ""
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = "Select ItemGroup From Item Where Code = '" & Code & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1ItemGroup, mRow).Value = AgL.XNull(DtTemp.Rows(0)("ItemGroup"))
            Else
                Dgl1.Item(Col1ItemGroup, mRow).Value = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function (" & Me.Name & ") ")
        End Try
    End Sub
End Class
