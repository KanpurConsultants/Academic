Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmStationaryPurchOrder
    Inherits AgTemplate.TempPurchaseOrder

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.StationaryPurchaseOrder
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
        Me.LblVendor.Location = New System.Drawing.Point(6, 47)
        '
        'TxtVendorOrderCancelDate
        '
        Me.TxtVendorOrderCancelDate.Location = New System.Drawing.Point(764, 26)
        Me.TxtVendorOrderCancelDate.Size = New System.Drawing.Size(97, 18)
        Me.TxtVendorOrderCancelDate.TabIndex = 12
        '
        'LblVendorCancelDate
        '
        Me.LblVendorCancelDate.Location = New System.Drawing.Point(653, 27)
        '
        'TxtVendorDeliveryDate
        '
        Me.TxtVendorDeliveryDate.Location = New System.Drawing.Point(564, 26)
        Me.TxtVendorDeliveryDate.Size = New System.Drawing.Size(86, 18)
        Me.TxtVendorDeliveryDate.TabIndex = 11
        '
        'LblVendorDeliveryDate
        '
        Me.LblVendorDeliveryDate.Location = New System.Drawing.Point(438, 27)
        '
        'TxtVendorOrderDate
        '
        Me.TxtVendorOrderDate.Location = New System.Drawing.Point(764, 5)
        Me.TxtVendorOrderDate.Size = New System.Drawing.Size(97, 18)
        Me.TxtVendorOrderDate.TabIndex = 10
        '
        'LvlVendoOrdDate
        '
        Me.LvlVendoOrdDate.Location = New System.Drawing.Point(652, 6)
        '
        'TxtVendorOrdNo
        '
        Me.TxtVendorOrdNo.Location = New System.Drawing.Point(564, 6)
        Me.TxtVendorOrdNo.Size = New System.Drawing.Size(86, 18)
        Me.TxtVendorOrdNo.TabIndex = 9
        '
        'LblVendorOrdNo
        '
        Me.LblVendorOrdNo.Location = New System.Drawing.Point(438, 7)
        '
        'TxtVendor
        '
        Me.TxtVendor.Location = New System.Drawing.Point(107, 47)
        Me.TxtVendor.Size = New System.Drawing.Size(321, 18)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(93, 54)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 67)
        '
        'TxtSaleToPartyAdd1
        '
        Me.TxtSaleToPartyAdd1.Location = New System.Drawing.Point(107, 67)
        Me.TxtSaleToPartyAdd1.Size = New System.Drawing.Size(321, 18)
        '
        'TxtSaleToPartyAdd2
        '
        Me.TxtSaleToPartyAdd2.Location = New System.Drawing.Point(107, 87)
        Me.TxtSaleToPartyAdd2.Size = New System.Drawing.Size(321, 18)
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(6, 108)
        '
        'TxtSaleToPartyCity
        '
        Me.TxtSaleToPartyCity.Location = New System.Drawing.Point(107, 107)
        Me.TxtSaleToPartyCity.Size = New System.Drawing.Size(100, 18)
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(15, 184)
        Me.Label7.Visible = False
        '
        'TxtSaleToPartyState
        '
        Me.TxtSaleToPartyState.Location = New System.Drawing.Point(127, 184)
        Me.TxtSaleToPartyState.Visible = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(264, 185)
        Me.Label8.Visible = False
        '
        'TxtSaleToPartyCountry
        '
        Me.TxtSaleToPartyCountry.Location = New System.Drawing.Point(358, 184)
        Me.TxtSaleToPartyCountry.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(5, 390)
        Me.Panel1.Size = New System.Drawing.Size(872, 23)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(5, 208)
        Me.Pnl1.Size = New System.Drawing.Size(872, 182)
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(93, 114)
        '
        'TxtTermsAndConditions
        '
        Me.TxtTermsAndConditions.Location = New System.Drawing.Point(4, 435)
        Me.TxtTermsAndConditions.Size = New System.Drawing.Size(392, 63)
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(514, 417)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(347, 154)
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(4, 416)
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(901, 185)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(834, 186)
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(452, 89)
        Me.TxtCurrency.Size = New System.Drawing.Size(46, 18)
        Me.TxtCurrency.Visible = False
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(459, 91)
        Me.Label28.Visible = False
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(781, 185)
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(680, 185)
        '
        'TPShipping
        '
        Me.TPShipping.Size = New System.Drawing.Size(874, 137)
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.Location = New System.Drawing.Point(703, 3)
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.Location = New System.Drawing.Point(599, 3)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(564, 66)
        Me.TxtRemarks.Multiline = True
        Me.TxtRemarks.Size = New System.Drawing.Size(297, 58)
        Me.TxtRemarks.TabIndex = 15
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(438, 67)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Location = New System.Drawing.Point(638, 184)
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(522, 184)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Location = New System.Drawing.Point(333, 40)
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(222, 40)
        '
        'TxtAgent
        '
        Me.TxtAgent.Location = New System.Drawing.Point(931, 165)
        '
        'LblAgent
        '
        Me.LblAgent.Location = New System.Drawing.Point(883, 165)
        '
        'TxtPriceMode
        '
        Me.TxtPriceMode.Location = New System.Drawing.Point(487, 91)
        Me.TxtPriceMode.Size = New System.Drawing.Size(32, 18)
        Me.TxtPriceMode.Visible = False
        '
        'LblPriceMode
        '
        Me.LblPriceMode.Location = New System.Drawing.Point(465, 89)
        Me.LblPriceMode.Visible = False
        '
        'LblStockTotalMeasure
        '
        Me.LblStockTotalMeasure.Location = New System.Drawing.Point(565, 46)
        '
        'LblTotalStockMeasureText
        '
        Me.LblTotalStockMeasureText.Location = New System.Drawing.Point(416, 46)
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.Location = New System.Drawing.Point(331, 107)
        Me.TxtReferenceNo.Size = New System.Drawing.Size(97, 18)
        Me.TxtReferenceNo.TabIndex = 8
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.Location = New System.Drawing.Point(214, 108)
        '
        'TxtIndentNo
        '
        Me.TxtIndentNo.Location = New System.Drawing.Point(764, 47)
        Me.TxtIndentNo.Size = New System.Drawing.Size(97, 18)
        Me.TxtIndentNo.TabIndex = 14
        '
        'LblIndentNo
        '
        Me.LblIndentNo.Location = New System.Drawing.Point(656, 45)
        '
        'TxtQutationNo
        '
        Me.TxtQutationNo.Location = New System.Drawing.Point(564, 46)
        Me.TxtQutationNo.Size = New System.Drawing.Size(86, 18)
        Me.TxtQutationNo.TabIndex = 13
        '
        'LblQutationNo
        '
        Me.LblQutationNo.Location = New System.Drawing.Point(438, 47)
        '
        'PnlSettings
        '
        Me.PnlSettings.Location = New System.Drawing.Point(172, 442)
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(5, 188)
        '
        'TxtPaymentTerms
        '
        Me.TxtPaymentTerms.Size = New System.Drawing.Size(387, 49)
        Me.TxtPaymentTerms.TabIndex = 3
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(466, 437)
        Me.PnlCShowGrid.Size = New System.Drawing.Size(21, 140)
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(449, 437)
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(10, 140)
        '
        'BtnFill
        '
        Me.BtnFill.Visible = False
        '
        'LblReferenceReq
        '
        Me.LblReferenceReq.Location = New System.Drawing.Point(315, 114)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(832, 583)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 583)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 583)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 583)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 583)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 579)
        Me.GroupBox1.Size = New System.Drawing.Size(897, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(300, 583)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(213, 28)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(321, 27)
        Me.TxtV_No.Size = New System.Drawing.Size(107, 18)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(91, 33)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(6, 28)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(291, 13)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(107, 27)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(213, 9)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(321, 7)
        Me.TxtV_Type.Size = New System.Drawing.Size(107, 18)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(91, 13)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(6, 8)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(107, 7)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(273, 28)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(-3, 19)
        Me.TabControl1.Size = New System.Drawing.Size(882, 163)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(874, 137)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(879, 41)
        Me.Topctrl1.TabIndex = 4
        '
        'FrmStationaryPurchOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(879, 618)
        Me.LogLineTableCsv = "PurchOrderDetail_LOG,Structure_TransFooter_Log,Structure_TransLine_Log"
        Me.LogTableName = "PurchOrder_Log"
        Me.MainLineTableCsv = "PurchOrderDetail,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchOrder"
        Me.Name = "FrmStationaryPurchOrder"
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

    Private Sub FrmStationaryPurchOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        RbtPODirect.Checked = True
    End Sub

    Private Sub FrmStationaryPurchOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0")
    End Sub

    Private Sub FrmBookPurchaseOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).HeaderText = "Stationary"
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1MeasureUnit).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False

        Dgl1.Columns(Col1Item).Width = 250
        Dgl1.Columns(Col1Qty).Width = 100
        Dgl1.Columns(Col1Unit).Width = 100
        Dgl1.Columns(Col1Rate).Width = 100
        Dgl1.Columns(Col1Amount).Width = 100


        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
    End Sub

    Private Sub FrmStationaryPurchOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 650, 885, 0, 0)
        TabControl1.TabPages.Remove(TPShipping)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType In ('" & ClsMain.ItemType.Stationary & "') AND IsDeleted = 0 And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "
        End Select
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Stationary Purchase Order"
            RepName = "Lib_StationaryPurchOrder_Print" : RepTitle = "Stationary Purchase Order"
            bCondstr = "WHERE H.DocID='" & mInternalCode & "'"


            strQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.VendorName, H.VendorAdd1, H.VendorAdd2, H.VendorCity, H.VendorCityName, H.VendorState, H.VendorCountry, " & _
                    " H.PurchQuotaion, H.PurchIndent,  H.TermsAndConditions, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount,H.VendorOrderNo,H.VendorOrderDate, " & _
                    " H.IsDeleted, L.PurchIndent AS LinePurchIndent, L.Item, L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalMeasure AS LineTotalMeasure, L.Rate, L.Amount ," & _
                    " I.Description AS ItemDesc, SM.Name AS SiteName ,SF.*, SL.* , P.V_No AS IndentNo, P.V_Type AS IndentType,isnull(V1.ChallanQty,0) AS ChallanQty " & _
                    " FROM PurchOrder H " & _
                    " LEFT JOIN PurchOrderDetail L ON L.DocId=H.DocID " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.StationaryPurchaseOrder) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.StationaryPurchaseOrder) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
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
                    TxtQutationNo.AgRowFilter += " And NCat = '" & ClsMain.Temp_NCat.StationaryQuotation & "' "
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class
