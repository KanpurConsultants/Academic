Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmBooksReceived
    Inherits AgTemplate.TempGr

    Dim mQry$ = ""

    Protected Const Col1Writer As String = "Writer"
    Protected Const Col1Publisher As String = "Publisher"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        'Me.EntryNCat = "" & ClsMain.Temp_NCat.GRNewBooks & "," & ClsMain.Temp_NCat.GROldBooks & "," & ClsMain.Temp_NCat.GRRareBooks & "," & ClsMain.Temp_NCat.GRDonatedBooks & ""
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
        Me.LblVendor.Location = New System.Drawing.Point(189, 46)
        '
        'TxtVendor
        '
        Me.TxtVendor.Location = New System.Drawing.Point(301, 46)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(285, 53)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(5, 382)
        Me.Panel1.Size = New System.Drawing.Size(869, 23)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(5, 221)
        Me.Pnl1.Size = New System.Drawing.Size(869, 161)
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(496, 407)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(378, 144)
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
        Me.TxtRemarks.Location = New System.Drawing.Point(301, 126)
        Me.TxtRemarks.Size = New System.Drawing.Size(377, 18)
        Me.TxtRemarks.TabIndex = 11
        Me.TxtRemarks.Text = "`"
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(189, 127)
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(301, 66)
        Me.TxtReferenceNo.Text = "`"
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.Location = New System.Drawing.Point(189, 66)
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
        Me.TxtTransport.Location = New System.Drawing.Point(301, 106)
        Me.TxtTransport.Size = New System.Drawing.Size(129, 18)
        Me.TxtTransport.TabIndex = 9
        Me.TxtTransport.Text = "`"
        '
        'LblTransport
        '
        Me.LblTransport.Location = New System.Drawing.Point(189, 106)
        '
        'TxtVendorDocDate
        '
        Me.TxtVendorDocDate.Location = New System.Drawing.Point(502, 86)
        Me.TxtVendorDocDate.Size = New System.Drawing.Size(176, 18)
        Me.TxtVendorDocDate.TabIndex = 8
        '
        'LvlVendorDocDate
        '
        Me.LvlVendorDocDate.Location = New System.Drawing.Point(434, 86)
        Me.LvlVendorDocDate.Size = New System.Drawing.Size(35, 16)
        Me.LvlVendorDocDate.Text = "Date"
        '
        'TxtVendorDocNo
        '
        Me.TxtVendorDocNo.Location = New System.Drawing.Point(301, 86)
        Me.TxtVendorDocNo.Size = New System.Drawing.Size(129, 18)
        Me.TxtVendorDocNo.TabIndex = 7
        Me.TxtVendorDocNo.Text = "`"
        '
        'LblVendorDocNo
        '
        Me.LblVendorDocNo.Location = New System.Drawing.Point(189, 86)
        '
        'TxtGodown
        '
        Me.TxtGodown.Location = New System.Drawing.Point(502, 106)
        Me.TxtGodown.Size = New System.Drawing.Size(176, 18)
        Me.TxtGodown.TabIndex = 10
        Me.TxtGodown.Text = "`"
        '
        'LblGodown
        '
        Me.LblGodown.Location = New System.Drawing.Point(434, 106)
        '
        'TxtPurchOrder
        '
        Me.TxtPurchOrder.Location = New System.Drawing.Point(502, 66)
        '
        'LblOrderNo
        '
        Me.LblOrderNo.Location = New System.Drawing.Point(434, 67)
        '
        'BtnFill
        '
        Me.BtnFill.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(630, 66)
        Me.BtnFill.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnFill.Size = New System.Drawing.Size(48, 20)
        Me.BtnFill.TabStop = False
        Me.BtnFill.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnFill.UseVisualStyleBackColor = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(5, 201)
        '
        'BtnRemoveFilter
        '
        Me.BtnRemoveFilter.FlatAppearance.BorderColor = System.Drawing.Color.Black
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(363, 411)
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(21, 140)
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(390, 411)
        Me.PnlCShowGrid.Size = New System.Drawing.Size(15, 140)
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.Visible = False
        '
        'RbtChallanDirect
        '
        Me.RbtChallanDirect.Location = New System.Drawing.Point(720, 100)
        Me.RbtChallanDirect.Size = New System.Drawing.Size(80, 17)
        Me.RbtChallanDirect.Text = "GR Direct"
        '
        'RbtChallanForOrder
        '
        Me.RbtChallanForOrder.Location = New System.Drawing.Point(720, 123)
        Me.RbtChallanForOrder.Size = New System.Drawing.Size(101, 17)
        Me.RbtChallanForOrder.Text = "GR For Order"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(830, 557)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 557)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(343, 557)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(185, 557)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 557)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 553)
        Me.GroupBox1.Size = New System.Drawing.Size(897, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(518, 557)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(407, 27)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(515, 26)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(285, 32)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(189, 27)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(485, 12)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(301, 26)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(407, 8)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(515, 6)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(285, 12)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(189, 7)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(301, 6)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(467, 27)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(0, 19)
        Me.TabControl1.Size = New System.Drawing.Size(879, 176)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(871, 150)
        Me.TP1.Text = "`"
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(879, 41)
        Me.Topctrl1.TabIndex = 2
        '
        'FrmBooksReceived
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(879, 598)
        Me.LogLineTableCsv = "PurchChallanDetail_LOG,Stock_Log,Structure_TransFooter_Log,Structure_TransLine_Lo" & _
            "g"
        Me.LogTableName = "PurchChallan_Log"
        Me.MainLineTableCsv = "PurchChallanDetail,Stock,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchChallan"
        Me.Name = "FrmBooksReceived"
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

    Private Sub FrmBooksReceived_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        RbtChallanDirect.Checked = True
    End Sub

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
        Dgl1.Columns(Col1LotNo).Visible = False

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
            mQry = " SELECT B.Writer,B.Publisher,b.rate   FROM Lib_Book B " & _
                    " WHERE B.Code = '" & Code & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1Writer, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Writer"))
                Dgl1.Item(Col1Publisher, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Publisher"))
                Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(DtTemp.Rows(0)("Rate"))
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
                If Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = "" Then Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = "1=1"
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

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPurchOrder.Enter, TxtVendor.Enter
        Select Case sender.name
            Case TxtPurchOrder.Name
                TxtPurchOrder.AgRowFilter += " And NCat = '" & ClsMain.Temp_NCat.BookPurchaseOrder & "' "

                'Case TxtVendor.Name
                '    If TxtV_Type.AgSelectedValue = ClsMain.Temp_NCat.GRNewBooks Then
                '        TxtVendor.AgRowFilter = " VendorCode Is Not Null "
                '    Else
                '        TxtVendor.AgRowFilter = ""
                '    End If
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

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Book Receive"
            RepName = "Lib_BookReceive_Print" : RepTitle = "Book Receive"
            bCondstr = "WHERE H.DocID='" & mInternalCode & "'"

            strQry = " SELECT  H.DocID, H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo,H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.Currency, H.SalesTaxGroupParty, H.Structure, " & _
                    " H.BillingType, H.VendorDocNo, H.VendorDocDate, H.Transport, H.Godown, H.Remarks, " & _
                    " H.TotalQty, H.TotalMeasure, H.TotalAmount, H.EntryBy, H.Status, " & _
                    " L.Sr, L.PurchOrder, L.Item, L.SalesTaxGroupItem, L.DocQty, L.RejQty, L.Qty, " & _
                    " L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalRejMeasure, L.TotalMeasure, " & _
                    " L.Rate, L.Amount, L.InvoicedQty, L.InvoicedMeasure,SG.DispName AS VendorName,SG.Add1,SG.Add2 ,SG.Add3,SG.CityCode ,SG.Mobile, " & _
                    " C.CityName ,I.Description AS ItemName,B.Writer,B.Publisher,SF.*, SL.* , " & _
                    " PO.V_Type AS OrderType,PO.V_No AS OrderNo,PO.V_Type + ' - ' + Convert(NVARCHAR(5),PO.V_No) AS POrderNo,SM.Name AS SiteName,PID.DocId AS InvoiceId " & _
                    " FROM PurchChallan H " & _
                    " LEFT JOIN PurchChallanDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.GRNewBooks) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.GRNewBooks) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Vendor  " & _
                    " LEFT JOIN Godown G ON G.Code=H.Godown  " & _
                    " LEFT JOIN City C ON C.CityCode =SG.CityCode  " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN PurchOrder PO ON PO.DocId=L.PurchOrder  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=I.Code " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code " & _
                    " LEFT JOIN PurchInvoiceDetail PID ON PID.PurchChallan = L.DocId AND PID.Item=L.Item " & _
                    " " & bCondstr & " "

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)
            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            AgPL.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        Dim FrmObj As Form
        Dim DTUP As New DataTable
        Dim StrUserPermission As String = ""
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
            If e.Control Or e.Shift Or e.Alt Then Exit Sub

            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex


            If Dgl1.CurrentCell.ColumnIndex = Dgl1.Columns(Col1Item).Index Then
                If e.KeyCode = Keys.Insert Then
                    If Dgl1.CurrentCell.RowIndex = Dgl1.RowCount - 1 Then
                        Dgl1.Rows.Add()

                        Dgl1.CurrentCell = Dgl1(Col1Item, mRowIndex)
                        Dgl1.Item(ColSNo, mRowIndex).Value = mRowIndex + 1
                    End If

                    StrUserPermission = "AEDP"
                    mQry = "  Select 'Status' As UP "
                    DTUP = AgL.FillData(mQry, AgL.GCn).Tables(0)
                    FrmObj = New FrmBookItemGenerate(StrUserPermission, DTUP)


                    FrmObj.ShowDialog()

                    Ini_List()

                    'Topctrl1_tbref()
                    Dgl1.AgSelectedValue(Col1Item, mRowIndex) = CType(FrmObj, FrmBookItemGenerate).mInternalCode

                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)

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
                Dgl1.Item(Col1Rate, mRow).Value = ""

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

    Private Sub FrmBooksReceived_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = "SELECT I.Code, I.Description, B.Writer, B.Publisher, S.Description As SubjectName, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                 " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                 " I.MeasureUnit, I.Measure As MeasurePerPcs,b.rate As Rate, 1 As PendingQty, " & _
                 " IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, '' As PurchOrder " & _
                 " FROM Item I " & _
                 " LEFT JOIN  Lib_Book B On I.Code = B.Code " & _
                 " LEFT JOIN Lib_Subject S On B.Subject  = S.Code "
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Pod.Item AS Code, I.Description AS Item, B.Writer, B.Publisher, " & _
                    " S.Description As SubjectName, I.Unit, I.ItemType, " & _
                    " Pod.SalesTaxGroupItem As  SalesTaxPostingGroup, IsNull(Po.IsDeleted ,0) AS IsDeleted,  " & _
                    " Po.Div_Code, Pod.MeasureUnit, Pod.MeasurePerPcs, Pod.Rate, Pod.Qty - Pod.ShippedQty As PendingQty, " & _
                    " IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status,b.rate , " & _
                    " Po.DocId As PurchOrder  " & _
                    " FROM PurchOrderDetail Pod " & _
                    " LEFT JOIN PurchOrder Po On Pod.DocId = Po.DocId " & _
                    " LEFT JOIN Item I ON Pod.Item = I.Code " & _
                    " LEFT JOIN Lib_Book B On I.Code = B.Code " & _
                    " LEFT JOIN Lib_Subject S On B.Subject  = S.Code "
        HelpDataSet.PurchOrderItem = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmBooksReceived_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        FrmBooksReceived_BaseFunction_CreateHelpDataSet()
        Dgl1.AgHelpDataSet(Col1Item, 10) = HelpDataSet.Item  'HelpDataSet.PurchOrderItem
    End Sub

End Class
