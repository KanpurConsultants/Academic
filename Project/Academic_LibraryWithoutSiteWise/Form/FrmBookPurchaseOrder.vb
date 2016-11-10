Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmBookPurchaseOrder
    Inherits AgTemplate.TempPurchaseOrder
    Protected Const Col1Writer As String = "Writer"
    Protected Const Col1Publisher As String = "Publisher"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.BookPurchaseOrder
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Panel1.SuspendLayout()
        Me.TPShipping.SuspendLayout()
        Me.PnlSettings.SuspendLayout()
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
        Me.LblVendor.Location = New System.Drawing.Point(68, 59)
        '
        'TxtVendorOrderCancelDate
        '
        Me.TxtVendorOrderCancelDate.Location = New System.Drawing.Point(693, 119)
        Me.TxtVendorOrderCancelDate.TabIndex = 14
        '
        'LblVendorCancelDate
        '
        Me.LblVendorCancelDate.Location = New System.Drawing.Point(577, 120)
        '
        'TxtVendorDeliveryDate
        '
        Me.TxtVendorDeliveryDate.Location = New System.Drawing.Point(693, 99)
        Me.TxtVendorDeliveryDate.Size = New System.Drawing.Size(104, 18)
        Me.TxtVendorDeliveryDate.TabIndex = 13
        '
        'LblVendorDeliveryDate
        '
        Me.LblVendorDeliveryDate.Location = New System.Drawing.Point(577, 100)
        '
        'TxtVendorOrderDate
        '
        Me.TxtVendorOrderDate.Location = New System.Drawing.Point(693, 79)
        Me.TxtVendorOrderDate.TabIndex = 12
        '
        'LvlVendoOrdDate
        '
        Me.LvlVendoOrdDate.Location = New System.Drawing.Point(577, 80)
        '
        'TxtVendorOrdNo
        '
        Me.TxtVendorOrdNo.Location = New System.Drawing.Point(693, 59)
        Me.TxtVendorOrdNo.Size = New System.Drawing.Size(104, 18)
        Me.TxtVendorOrdNo.TabIndex = 11
        '
        'LblVendorOrdNo
        '
        Me.LblVendorOrdNo.Location = New System.Drawing.Point(577, 60)
        '
        'TxtVendor
        '
        Me.TxtVendor.Location = New System.Drawing.Point(192, 59)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(178, 66)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(68, 79)
        '
        'TxtSaleToPartyAdd1
        '
        Me.TxtSaleToPartyAdd1.Location = New System.Drawing.Point(192, 79)
        '
        'TxtSaleToPartyAdd2
        '
        Me.TxtSaleToPartyAdd2.Location = New System.Drawing.Point(192, 99)
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(68, 120)
        '
        'TxtSaleToPartyCity
        '
        Me.TxtSaleToPartyCity.Location = New System.Drawing.Point(192, 119)
        Me.TxtSaleToPartyCity.Size = New System.Drawing.Size(147, 18)
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 178)
        Me.Label7.Visible = False
        '
        'TxtSaleToPartyState
        '
        Me.TxtSaleToPartyState.Location = New System.Drawing.Point(120, 178)
        Me.TxtSaleToPartyState.Visible = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(257, 179)
        Me.Label8.Visible = False
        '
        'TxtSaleToPartyCountry
        '
        Me.TxtSaleToPartyCountry.Location = New System.Drawing.Point(351, 178)
        Me.TxtSaleToPartyCountry.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(-3, 381)
        Me.Panel1.Size = New System.Drawing.Size(872, 23)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(0, 234)
        Me.Pnl1.Size = New System.Drawing.Size(869, 147)
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(178, 126)
        '
        'TxtTermsAndConditions
        '
        Me.TxtTermsAndConditions.Location = New System.Drawing.Point(8, 427)
        Me.TxtTermsAndConditions.Size = New System.Drawing.Size(383, 71)
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(507, 413)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(358, 156)
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(5, 408)
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(882, 166)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(815, 178)
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(811, 34)
        Me.TxtCurrency.Size = New System.Drawing.Size(38, 18)
        Me.TxtCurrency.Visible = False
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(796, 18)
        Me.Label28.Visible = False
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(762, 177)
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(661, 177)
        '
        'TPShipping
        '
        Me.TPShipping.Size = New System.Drawing.Size(864, 177)
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.Location = New System.Drawing.Point(627, 0)
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.Location = New System.Drawing.Point(523, 0)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(192, 139)
        Me.TxtRemarks.Size = New System.Drawing.Size(605, 18)
        Me.TxtRemarks.TabIndex = 15
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(68, 140)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Location = New System.Drawing.Point(619, 176)
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(503, 176)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Location = New System.Drawing.Point(382, 39)
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(398, 41)
        '
        'TxtAgent
        '
        Me.TxtAgent.Location = New System.Drawing.Point(956, 145)
        '
        'LblAgent
        '
        Me.LblAgent.Location = New System.Drawing.Point(908, 145)
        '
        'TxtPriceMode
        '
        Me.TxtPriceMode.Location = New System.Drawing.Point(801, 80)
        Me.TxtPriceMode.Size = New System.Drawing.Size(57, 18)
        Me.TxtPriceMode.Visible = False
        '
        'LblPriceMode
        '
        Me.LblPriceMode.Location = New System.Drawing.Point(794, 60)
        Me.LblPriceMode.Visible = False
        '
        'LblStockTotalMeasure
        '
        Me.LblStockTotalMeasure.Location = New System.Drawing.Point(565, 37)
        '
        'LblTotalStockMeasureText
        '
        Me.LblTotalStockMeasureText.Location = New System.Drawing.Point(382, 38)
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.Location = New System.Drawing.Point(469, 119)
        Me.TxtReferenceNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtReferenceNo.TabIndex = 8
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.Location = New System.Drawing.Point(345, 119)
        '
        'TxtIndentNo
        '
        Me.TxtIndentNo.Location = New System.Drawing.Point(693, 39)
        Me.TxtIndentNo.Size = New System.Drawing.Size(104, 18)
        Me.TxtIndentNo.TabIndex = 10
        '
        'LblIndentNo
        '
        Me.LblIndentNo.Location = New System.Drawing.Point(577, 40)
        '
        'TxtQutationNo
        '
        Me.TxtQutationNo.Location = New System.Drawing.Point(693, 19)
        Me.TxtQutationNo.Size = New System.Drawing.Size(104, 18)
        Me.TxtQutationNo.TabIndex = 9
        '
        'LblQutationNo
        '
        Me.LblQutationNo.Location = New System.Drawing.Point(577, 20)
        '
        'PnlSettings
        '
        Me.PnlSettings.Location = New System.Drawing.Point(121, 454)
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 213)
        '
        'TxtPaymentTerms
        '
        Me.TxtPaymentTerms.Size = New System.Drawing.Size(382, 49)
        Me.TxtPaymentTerms.TabIndex = 3
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(467, 429)
        Me.PnlCShowGrid.Size = New System.Drawing.Size(28, 140)
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(400, 431)
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(27, 140)
        '
        'BtnFill
        '
        Me.BtnFill.Visible = False
        '
        'LblReferenceReq
        '
        Me.LblReferenceReq.Location = New System.Drawing.Point(453, 125)
        '
        'RbtPOForIndent
        '
        Me.RbtPOForIndent.Location = New System.Drawing.Point(299, 160)
        '
        'RbtPODirect
        '
        Me.RbtPODirect.Location = New System.Drawing.Point(192, 160)
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(887, 4)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(298, 40)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(406, 39)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(176, 45)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(68, 40)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(376, 25)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(192, 39)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(298, 21)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(406, 19)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(176, 25)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(68, 20)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(192, 19)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(358, 40)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(-3, 6)
        Me.TabControl1.Size = New System.Drawing.Size(872, 203)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(864, 177)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(869, 41)
        Me.Topctrl1.TabIndex = 4
        '
        'FrmBookPurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(869, 616)
        Me.LogLineTableCsv = "PurchOrderDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"
        Me.LogTableName = "PurchOrder_Log"
        Me.MainLineTableCsv = "PurchOrderDetail,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchOrder"
        Me.Name = "FrmBookPurchaseOrder"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.TPShipping.ResumeLayout(False)
        Me.TPShipping.PerformLayout()
        Me.PnlSettings.ResumeLayout(False)
        Me.PnlSettings.PerformLayout()
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

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmBookPurchaseOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).HeaderText = "Book"
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1MeasureUnit).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False

        With AgCL
            .AddAgTextColumn(Dgl1, Col1Writer, 150, 100, Col1Writer, True, True)
            .AddAgTextColumn(Dgl1, Col1Publisher, 150, 100, Col1Publisher, True, True)
        End With
        Dgl1.Columns(Col1Writer).DisplayIndex = 3
        Dgl1.Columns(Col1Publisher).DisplayIndex = 4

        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
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

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType In ('" & ClsMain.ItemType.Book & "','" & ClsMain.ItemType.Generals & "') AND IsDeleted = 0 And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "
        End Select
    End Sub

    Private Sub FrmBookPurchaseOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 650, 885, 0, 0)
        TabControl1.TabPages.Remove(TPShipping)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Book Purchase Order"
            RepName = "Lib_BookPurchOrder_Print" : RepTitle = "Book Purchase Order"
            bCondstr = "WHERE H.DocID='" & mInternalCode & "'"

            strQry = " SELECT  H.DocID,H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.VendorName, H.VendorAdd1, H.VendorAdd2, H.VendorCity, H.VendorCityName, H.VendorState, H.VendorCountry, " & _
                    " H.PurchQuotaion, H.PurchIndent,  H.TermsAndConditions, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, H.VendorOrderNo,H.VendorOrderDate," & _
                    " H.IsDeleted, L.PurchIndent AS LinePurchIndent, L.Item, L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalMeasure AS LineTotalMeasure, L.Rate, L.Amount ," & _
                    " I.Description AS ItemDesc, B.Writer,B.Publisher ,SM.Name AS SiteName ,SF.*, SL.* , P.V_Type AS IndentType,isnull(V1.ChallanQty,0) AS ChallanQty " & _
                    " FROM PurchOrder H " & _
                    " LEFT JOIN PurchOrderDetail L ON L.DocId=H.DocID " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.BookPurchaseOrder) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.BookPurchaseOrder) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=I.Code  " & _
                    " LEFT JOIN PurchIndent P on P.DocId=L.PurchIndent " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type " & _
                    " LEFT JOIN " & _
                    "  ( " & _
                    " SELECT PC.PurchOrder,PC.Item,sum(PC.Qty) AS ChallanQty  " & _
                    " FROM PurchChallanDetail PC " & _
                    " WHERE PC.PurchOrder IS NOT NULL  " & _
                    " GROUP BY PC.PurchOrder,PC.Item " & _
                    "  )V1 ON V1.PurchOrder=L.DocId AND V1.Item=L.Item " & _
                   " " & bCondstr & ""

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

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtQutationNo.Enter
        Try
            Select Case sender.name
                Case TxtQutationNo.Name
                    TxtQutationNo.AgRowFilter += " And NCat = '" & ClsMain.Temp_NCat.BookPurchaseQuotation & "' "
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class
