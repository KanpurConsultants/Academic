Public Class FrmDonatedBooksReceived
    Inherits AgTemplate.TempGr

    Protected Const Col1Writer As String = "Writer"
    Protected Const Col1Publisher As String = "Publisher"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.GRDonatedBooks
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
        'LblVendor
        '
        Me.LblVendor.Location = New System.Drawing.Point(168, 53)
        Me.LblVendor.Size = New System.Drawing.Size(76, 16)
        Me.LblVendor.Text = "Donated By"
        '
        'TxtVendor
        '
        Me.TxtVendor.Location = New System.Drawing.Point(301, 53)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(285, 60)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(6, 377)
        Me.Panel1.Size = New System.Drawing.Size(853, 23)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(6, 207)
        Me.Pnl1.Size = New System.Drawing.Size(853, 170)
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(491, 407)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(368, 144)
        Me.PnlCalcGrid.Visible = False
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(894, 163)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(827, 163)
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(774, 163)
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(670, 163)
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.Location = New System.Drawing.Point(459, 4)
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.Location = New System.Drawing.Point(360, 3)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(301, 93)
        Me.TxtRemarks.Size = New System.Drawing.Size(377, 18)
        Me.TxtRemarks.Text = "`"
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(168, 94)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Location = New System.Drawing.Point(628, 163)
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(512, 163)
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.Location = New System.Drawing.Point(301, 72)
        Me.TxtReferenceNo.Text = "`"
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.Location = New System.Drawing.Point(168, 73)
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(768, 209)
        Me.TxtCurrency.Visible = False
        '
        'LblCurrency
        '
        Me.LblCurrency.Location = New System.Drawing.Point(666, 210)
        Me.LblCurrency.Visible = False
        '
        'TxtTransport
        '
        Me.TxtTransport.Location = New System.Drawing.Point(813, 77)
        Me.TxtTransport.Size = New System.Drawing.Size(42, 18)
        Me.TxtTransport.Text = "`"
        Me.TxtTransport.Visible = False
        '
        'LblTransport
        '
        Me.LblTransport.Location = New System.Drawing.Point(701, 77)
        Me.LblTransport.Visible = False
        '
        'TxtVendorDocDate
        '
        Me.TxtVendorDocDate.Location = New System.Drawing.Point(792, 32)
        Me.TxtVendorDocDate.Size = New System.Drawing.Size(42, 18)
        Me.TxtVendorDocDate.Visible = False
        '
        'LvlVendorDocDate
        '
        Me.LvlVendorDocDate.Location = New System.Drawing.Point(760, 33)
        Me.LvlVendorDocDate.Size = New System.Drawing.Size(35, 16)
        Me.LvlVendorDocDate.Text = "Date"
        Me.LvlVendorDocDate.Visible = False
        '
        'TxtVendorDocNo
        '
        Me.TxtVendorDocNo.Location = New System.Drawing.Point(813, 53)
        Me.TxtVendorDocNo.Size = New System.Drawing.Size(45, 18)
        Me.TxtVendorDocNo.Text = "`"
        Me.TxtVendorDocNo.Visible = False
        '
        'LblVendorDocNo
        '
        Me.LblVendorDocNo.Location = New System.Drawing.Point(701, 53)
        Me.LblVendorDocNo.Visible = False
        '
        'TxtGodown
        '
        Me.TxtGodown.Location = New System.Drawing.Point(502, 73)
        Me.TxtGodown.Size = New System.Drawing.Size(176, 18)
        Me.TxtGodown.Text = "`"
        '
        'LblGodown
        '
        Me.LblGodown.Location = New System.Drawing.Point(434, 74)
        '
        'TxtPurchOrder
        '
        Me.TxtPurchOrder.Location = New System.Drawing.Point(766, 12)
        Me.TxtPurchOrder.Size = New System.Drawing.Size(23, 18)
        Me.TxtPurchOrder.Visible = False
        '
        'LblOrderNo
        '
        Me.LblOrderNo.Location = New System.Drawing.Point(698, 13)
        Me.LblOrderNo.Visible = False
        '
        'BtnFill
        '
        Me.BtnFill.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(792, 12)
        Me.BtnFill.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnFill.Size = New System.Drawing.Size(48, 20)
        Me.BtnFill.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnFill.UseVisualStyleBackColor = False
        Me.BtnFill.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 187)
        '
        'TxtTransporter
        '
        Me.TxtTransporter.Visible = True
        '
        'LblTransporter
        '
        Me.LblTransporter.Visible = True
        '
        'BtnRemoveFilter
        '
        Me.BtnRemoveFilter.FlatAppearance.BorderColor = System.Drawing.Color.Black
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(372, 408)
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(8, 140)
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(391, 408)
        Me.PnlCShowGrid.Size = New System.Drawing.Size(14, 140)
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(285, 78)
        '
        'RbtChallanDirect
        '
        Me.RbtChallanDirect.Location = New System.Drawing.Point(437, 115)
        '
        'RbtChallanForOrder
        '
        Me.RbtChallanForOrder.Location = New System.Drawing.Point(301, 115)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(343, 558)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(185, 558)
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(887, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(518, 558)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(407, 34)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(515, 33)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(285, 39)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(168, 34)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(485, 19)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(301, 33)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(407, 15)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(515, 13)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(285, 19)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(168, 14)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(301, 13)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(467, 34)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(0, 20)
        Me.TabControl1.Size = New System.Drawing.Size(869, 161)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(861, 135)
        Me.TP1.Text = "`"
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(869, 41)
        '
        'FrmDonatedBooksReceived
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(869, 599)
        Me.LogLineTableCsv = "PurchChallanDetail_LOG,Stock_Log,Structure_TransFooter_Log,Structure_TransLine_Lo" & _
            "g"
        Me.LogTableName = "PurchChallan_Log"
        Me.MainLineTableCsv = "PurchChallanDetail,Stock,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchChallan"
        Me.Name = "FrmDonatedBooksReceived"
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

    Private Sub FrmBookPurchaseOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0")
    End Sub

    Private Sub FrmBookPurchaseOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).HeaderText = "Book"

        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1MeasureUnit).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
        Dgl1.Columns(Col1TotalDocMeasure).Visible = False
        Dgl1.Columns(Col1TotalRejMeasure).Visible = False
        Dgl1.Columns(Col1DocQty).Visible = False
        Dgl1.Columns(Col1RejQty).Visible = False
        Dgl1.Columns(Col1Rate).Visible = False
        Dgl1.Columns(Col1Amount).Visible = False
        Dgl1.Columns(Col1PurchOrder).Visible = False
        AgCalcGrid1.Visible = False

        With AgCL
            .AddAgTextColumn(Dgl1, Col1Writer, 110, 100, Col1Writer, True, True)
            .AddAgTextColumn(Dgl1, Col1Publisher, 110, 100, Col1Publisher, True, True)
        End With
        Dgl1.Columns(Col1Writer).DisplayIndex = 3
        Dgl1.Columns(Col1Publisher).DisplayIndex = 4

        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
        CType(Dgl1.Columns(Col1DocQty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
        CType(Dgl1.Columns(Col1RejQty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
    End Sub

    Private Sub FrmBookQuatation_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        I = 0
        For I = 0 To Dgl1.Rows.Count - 1
            Validating_BookItem(Dgl1.AgSelectedValue(Col1Item, I), I)
        Next
    End Sub

    Private Sub Dgl1_ItemEditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    If Dgl1.AgSelectedValue(Col1Item, mRowIndex) = "" And Dgl1.Item(Col1Item, mRowIndex).Value = "" Then
                        Dgl1.AgSelectedValue(Col1Writer, mRowIndex) = ""
                        Dgl1.AgSelectedValue(Col1Publisher, mRowIndex) = ""
                        Dgl1.Item(Col1Qty, mRowIndex).Value = 0
                    Else
                        If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                            DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, mRowIndex)) & "")
                            Validating_BookItem(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
                        End If
                    End If

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Shadows Sub Validating_BookItem(ByVal Code As String, ByVal mRow As Integer)
        Dim mQry As String
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = " SELECT B.Writer,B.Publisher   FROM Lib_Book B " & _
                    " WHERE B.Code = '" & Code & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1Writer, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Writer"))
                Dgl1.Item(Col1Publisher, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Publisher"))
            Else
                Dgl1.Item(Col1Writer, mRow).Value = ""
                Dgl1.Item(Col1Publisher, mRow).Value = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) += " And ItemType In ('" & ClsMain.ItemType.Book & "') "

            Case Col1PurchOrder
                Dgl1.AgRowFilter(Dgl1.Columns(Col1PurchOrder).Index) += " And NCat = '" & ClsMain.Temp_NCat.BookPurchaseOrder & "' "
        End Select
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmBookPurchaseOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 633, 885, 0, 0)
    End Sub

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPurchOrder.Enter
        Select Case sender.name
            Case TxtPurchOrder.Name
                TxtPurchOrder.AgRowFilter += " And NCat = '" & ClsMain.Temp_NCat.BookPurchaseOrder & "' "
        End Select
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Dim I As Integer = 0
        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    Call Validating_BookItem(.AgSelectedValue(Col1Item, I), I)
                End If
            Next
        End With
    End Sub
End Class
