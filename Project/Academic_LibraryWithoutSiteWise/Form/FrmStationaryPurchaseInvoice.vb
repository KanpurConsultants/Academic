Public Class FrmStationaryPurchaseInvoice
    Inherits AgTemplate.TempPurchInvoice

    Dim mQry$ = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.InvoiceStationary
        Me.ChallanTypeStr = "'" & ClsMain.Temp_NCat.GRStationary & "'"
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
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(388, 442)
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(7, 138)
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(401, 442)
        Me.PnlCShowGrid.Size = New System.Drawing.Size(10, 140)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(7, 418)
        Me.Panel1.Size = New System.Drawing.Size(853, 23)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(7, 226)
        Me.Pnl1.Size = New System.Drawing.Size(853, 192)
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(485, 445)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(372, 131)
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(949, 27)
        Me.TxtStructure.Size = New System.Drawing.Size(18, 18)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(884, 28)
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(903, 74)
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(29, 18)
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(887, 60)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Location = New System.Drawing.Point(951, 44)
        Me.TxtBillingType.Size = New System.Drawing.Size(12, 18)
        Me.TxtBillingType.Visible = False
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(887, 44)
        Me.Label32.Visible = False
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(950, 6)
        Me.TxtCurrency.Size = New System.Drawing.Size(17, 18)
        Me.TxtCurrency.Visible = False
        '
        'LblCurrency
        '
        Me.LblCurrency.Location = New System.Drawing.Point(884, 6)
        Me.LblCurrency.Visible = False
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(563, 27)
        Me.Pnl2.Size = New System.Drawing.Size(283, 97)
        '
        'BtnFill
        '
        Me.BtnFill.Location = New System.Drawing.Point(786, 0)
        Me.BtnFill.Size = New System.Drawing.Size(60, 23)
        '
        'LblChallans
        '
        Me.LblChallans.Location = New System.Drawing.Point(561, 7)
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(7, 205)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(761, 585)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(590, 585)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(292, 585)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(152, 585)
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(887, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(456, 585)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(0, 42)
        Me.TabControl1.Size = New System.Drawing.Size(868, 160)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(860, 134)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(869, 41)
        '
        'FrmStationaryPurchaseInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(869, 626)
        Me.LogLineTableCsv = "PurchInvoiceDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"
        Me.LogTableName = "PurchInvoice_Log"
        Me.MainLineTableCsv = "PurchInvoiceDetail,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchInvoice"
        Me.Name = "FrmStationaryPurchaseInvoice"
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

    Private Sub FrmBookPurchaseOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0")
    End Sub

    Private Sub FrmBookPurchaseOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).HeaderText = "Stationary Item"

        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1MeasureUnit).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
        Dgl1.Columns(Col1TotalDocMeasure).Visible = False

        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
        CType(Dgl1.Columns(Col1DocQty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) += " And ItemType In ('" & ClsMain.ItemType.Stationary & "') "
        End Select
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmBookPurchaseOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 658, 875, 0, 0)
    End Sub
End Class
