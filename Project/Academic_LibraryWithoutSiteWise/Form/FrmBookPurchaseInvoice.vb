Public Class FrmBookPurchaseInvoice
    Inherits AgTemplate.TempPurchInvoice

    Dim mQry$ = ""

    Protected Const Col1Writer As String = "Writer"
    Protected Const Col1Publisher As String = "Publisher"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.InvoiceBooks
        Me.ChallanTypeStr = "'" & ClsMain.Temp_NCat.GRNewBooks & "','" & ClsMain.Temp_NCat.GROldBooks & "','" & ClsMain.Temp_NCat.GRRareBooks & "'"
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
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(147, 433)
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(175, 134)
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(328, 433)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(6, 407)
        Me.Panel1.Size = New System.Drawing.Size(867, 23)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(6, 202)
        Me.Pnl1.Size = New System.Drawing.Size(867, 205)
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(491, 434)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(382, 133)
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(949, 28)
        Me.TxtStructure.Size = New System.Drawing.Size(18, 18)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(884, 29)
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(924, 85)
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(25, 18)
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(884, 69)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Location = New System.Drawing.Point(945, 48)
        Me.TxtBillingType.Size = New System.Drawing.Size(31, 18)
        Me.TxtBillingType.Visible = False
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(885, 48)
        Me.Label32.Visible = False
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(945, 10)
        Me.TxtCurrency.Size = New System.Drawing.Size(25, 18)
        Me.TxtCurrency.Visible = False
        '
        'LblCurrency
        '
        Me.LblCurrency.Location = New System.Drawing.Point(885, 8)
        Me.LblCurrency.Visible = False
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(547, 28)
        Me.Pnl2.Size = New System.Drawing.Size(283, 98)
        '
        'BtnFill
        '
        Me.BtnFill.Location = New System.Drawing.Point(767, 3)
        Me.BtnFill.Size = New System.Drawing.Size(62, 20)
        Me.BtnFill.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LblChallans
        '
        Me.LblChallans.Location = New System.Drawing.Point(547, 8)
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 182)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(830, 573)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(612, 577)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(304, 577)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(164, 577)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 573)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 569)
        Me.GroupBox1.Size = New System.Drawing.Size(897, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(475, 577)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(-3, 19)
        Me.TabControl1.Size = New System.Drawing.Size(882, 161)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(874, 135)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(879, 41)
        '
        'FrmBookPurchaseInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(879, 618)
        Me.LogLineTableCsv = "PurchInvoiceDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"
        Me.LogTableName = "PurchInvoice_Log"
        Me.MainLineTableCsv = "PurchInvoiceDetail,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchInvoice"
        Me.Name = "FrmBookPurchaseInvoice"
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
        Dgl1.Columns(Col1Item).HeaderText = "Book"

        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1MeasureUnit).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
        Dgl1.Columns(Col1TotalDocMeasure).Visible = False

        With AgCL
            .AddAgTextColumn(Dgl1, Col1Writer, 150, 100, Col1Writer, True, True)
            .AddAgTextColumn(Dgl1, Col1Publisher, 150, 100, Col1Publisher, True, True)
        End With
        Dgl1.Columns(Col1Writer).DisplayIndex = 3
        Dgl1.Columns(Col1Publisher).DisplayIndex = 4

        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
        CType(Dgl1.Columns(Col1DocQty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
    End Sub

    Private Sub FrmBookQuatation_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        I = 0
        For I = 0 To Dgl1.Rows.Count - 1
            Validating_BookItem(Dgl1.AgSelectedValue(Col1Item, I), I)
        Next
    End Sub

    Private Sub Dgl1_ItemEditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
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

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        Dim FrmObj As Form
        Dim DTUP As New DataTable
        Dim StrUserPermission As String = ""
        Try
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
            If e.Control Or e.Shift Or e.Alt Then Exit Sub

            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            'If AgL.StrCmp(AgL.MidStr(AgL.PubCompName, 0, 3), "SIR") Then Exit Sub

            If Dgl1.CurrentCell.ColumnIndex = Dgl1.Columns(Col1Item).Index Then
                If e.KeyCode = Keys.Insert Then
                    StrUserPermission = "AEDP"
                    mQry = "  Select 'Status' As UP "
                    DTUP = AgL.FillData(mQry, AgL.GCn).Tables(0)
                    FrmObj = New FrmBookItemGenerate(StrUserPermission, DTUP)


                    FrmObj.ShowDialog()

                    Ini_List()

                    'Topctrl1_tbref()
                    Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex) = CType(FrmObj, FrmBookItemGenerate).mInternalCode

                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex), Dgl1.CurrentCell.RowIndex)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Writer, mRow).Value = ""
                Dgl1.Item(Col1Publisher, mRow).Value = ""


            Else
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Writer, mRow).Value = AgL.XNull(DrTemp(0)("Writer"))
                    Dgl1.Item(Col1Publisher, mRow).Value = AgL.XNull(DrTemp(0)("Publisher"))
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(DrTemp(0)("Rate"))

                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
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
        End Select
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmBookPurchaseOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 650, 885, 0, 0)
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Dim I As Integer = 0
        With Dgl1
            For I = 0 To .Rows.Count - 1
                Validating_BookItem(.AgSelectedValue(Col1Item, I), I)
            Next
        End With
    End Sub

    Private Sub FrmBookPurchaseInvoice_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = "SELECT I.Code, I.Description, B.Writer, B.Publisher, S.Description As SubjectName, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
               " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
               " I.MeasureUnit, I.Measure As MeasurePerPcs, b.rate As Rate, 1 As PendingQty, I.Status " & _
               " FROM Lib_Book B " & _
               " LEFT JOIN Item I ON B.Code = I.Code " & _
               " LEFT JOIN Lib_Subject S On B.Subject  = S.Code "
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmBookPurchaseInvoice_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        FrmBookPurchaseInvoice_BaseFunction_CreateHelpDataSet()
        Dgl1.AgHelpDataSet(Col1Item, 10) = HelpDataSet.Item
    End Sub
End Class
