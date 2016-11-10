Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmStationaryReceived
    Inherits AgTemplate.TempGr

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.GRStationary
        Me.IsPostStock = True
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
        Me.LblVendor.Location = New System.Drawing.Point(133, 46)
        '
        'TxtVendor
        '
        Me.TxtVendor.Location = New System.Drawing.Point(256, 46)
        Me.TxtVendor.Size = New System.Drawing.Size(406, 18)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(240, 53)
        '
        'Panel1
        '
        Me.Panel1.Size = New System.Drawing.Size(861, 23)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 218)
        Me.Pnl1.Size = New System.Drawing.Size(860, 159)
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(483, 412)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(374, 135)
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(888, 177)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(821, 177)
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(768, 177)
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(664, 177)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(256, 126)
        Me.TxtRemarks.Size = New System.Drawing.Size(406, 18)
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(133, 127)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Location = New System.Drawing.Point(622, 177)
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(506, 177)
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.Location = New System.Drawing.Point(256, 66)
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.Location = New System.Drawing.Point(133, 66)
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(113, 174)
        Me.TxtCurrency.Visible = False
        '
        'LblCurrency
        '
        Me.LblCurrency.Location = New System.Drawing.Point(5, 175)
        Me.LblCurrency.Visible = False
        '
        'TxtTransport
        '
        Me.TxtTransport.Location = New System.Drawing.Point(257, 106)
        Me.TxtTransport.Size = New System.Drawing.Size(405, 18)
        '
        'LblTransport
        '
        Me.LblTransport.Location = New System.Drawing.Point(133, 106)
        '
        'TxtVendorDocDate
        '
        Me.TxtVendorDocDate.Location = New System.Drawing.Point(499, 86)
        Me.TxtVendorDocDate.Size = New System.Drawing.Size(163, 18)
        '
        'LvlVendorDocDate
        '
        Me.LvlVendorDocDate.Location = New System.Drawing.Point(391, 86)
        Me.LvlVendorDocDate.Size = New System.Drawing.Size(35, 16)
        Me.LvlVendorDocDate.Text = "Date"
        '
        'TxtVendorDocNo
        '
        Me.TxtVendorDocNo.Location = New System.Drawing.Point(257, 86)
        Me.TxtVendorDocNo.Size = New System.Drawing.Size(129, 18)
        '
        'LblVendorDocNo
        '
        Me.LblVendorDocNo.Location = New System.Drawing.Point(133, 86)
        '
        'TxtGodown
        '
        Me.TxtGodown.Location = New System.Drawing.Point(760, 65)
        Me.TxtGodown.Size = New System.Drawing.Size(23, 18)
        Me.TxtGodown.Visible = False
        '
        'LblGodown
        '
        Me.LblGodown.Location = New System.Drawing.Point(687, 65)
        Me.LblGodown.Visible = False
        '
        'TxtPurchOrder
        '
        Me.TxtPurchOrder.Location = New System.Drawing.Point(499, 66)
        Me.TxtPurchOrder.Size = New System.Drawing.Size(112, 18)
        '
        'LblOrderNo
        '
        Me.LblOrderNo.Location = New System.Drawing.Point(391, 67)
        '
        'BtnFill
        '
        Me.BtnFill.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnFill.Location = New System.Drawing.Point(614, 67)
        Me.BtnFill.Size = New System.Drawing.Size(48, 17)
        Me.BtnFill.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 197)
        '
        'TxtGateEntryNo
        '
        Me.TxtGateEntryNo.Location = New System.Drawing.Point(121, 460)
        '
        'LblGateEntryNo
        '
        Me.LblGateEntryNo.Location = New System.Drawing.Point(9, 461)
        '
        'TxtTruckNo
        '
        Me.TxtTruckNo.Location = New System.Drawing.Point(121, 480)
        '
        'LblTruckNo
        '
        Me.LblTruckNo.Location = New System.Drawing.Point(9, 481)
        '
        'TxtForm
        '
        Me.TxtForm.Location = New System.Drawing.Point(121, 500)
        '
        'LblForm
        '
        Me.LblForm.Location = New System.Drawing.Point(9, 501)
        '
        'TxtFormNo
        '
        Me.TxtFormNo.Location = New System.Drawing.Point(121, 520)
        '
        'LblFormNo
        '
        Me.LblFormNo.Location = New System.Drawing.Point(9, 521)
        '
        'TxtTransporter
        '
        Me.TxtTransporter.Location = New System.Drawing.Point(121, 440)
        Me.TxtTransporter.Visible = True
        '
        'LblTransporter
        '
        Me.LblTransporter.Location = New System.Drawing.Point(8, 440)
        Me.LblTransporter.Visible = True
        '
        'BtnRemoveFilter
        '
        Me.BtnRemoveFilter.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnRemoveFilter.Location = New System.Drawing.Point(329, 519)
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(371, 414)
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(16, 140)
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(400, 412)
        Me.PnlCShowGrid.Size = New System.Drawing.Size(19, 140)
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(240, 71)
        '
        'TxtLrNo
        '
        Me.TxtLrNo.Location = New System.Drawing.Point(121, 420)
        '
        'LblLrNo
        '
        Me.LblLrNo.Location = New System.Drawing.Point(9, 421)
        '
        'TxtLrDate
        '
        Me.TxtLrDate.Location = New System.Drawing.Point(271, 420)
        '
        'LblLrDate
        '
        Me.LblLrDate.Location = New System.Drawing.Point(201, 422)
        '
        'RbtChallanDirect
        '
        Me.RbtChallanDirect.Location = New System.Drawing.Point(677, 125)
        '
        'RbtChallanForOrder
        '
        Me.RbtChallanForOrder.Location = New System.Drawing.Point(677, 103)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(793, 558)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(617, 558)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(300, 558)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(159, 558)
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(887, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(478, 558)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(391, 27)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(499, 26)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(240, 32)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(133, 27)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(469, 12)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(256, 26)
        Me.TxtV_Date.Size = New System.Drawing.Size(129, 18)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(391, 8)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(499, 6)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(240, 12)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(133, 7)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(256, 6)
        Me.TxtSite_Code.Size = New System.Drawing.Size(129, 18)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(451, 27)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(-3, 20)
        Me.TabControl1.Size = New System.Drawing.Size(872, 175)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(864, 149)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(869, 41)
        '
        'FrmStationaryReceived
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(869, 599)
        Me.LogLineTableCsv = "PurchChallanDetail_LOG,Stock_Log,Structure_TransFooter_Log,Structure_TransLine_Lo" & _
            "g"
        Me.LogTableName = "PurchChallan_Log"
        Me.MainLineTableCsv = "PurchChallanDetail,Stock,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchChallan"
        Me.Name = "FrmStationaryReceived"
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
        Dgl1.Columns(Col1Item).HeaderText = "Stationary Item"

        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1MeasureUnit).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
        Dgl1.Columns(Col1TotalDocMeasure).Visible = False
        Dgl1.Columns(Col1TotalRejMeasure).Visible = False


        Dgl1.Columns(Col1PurchOrder).Width = 100
        Dgl1.Columns(Col1Item).Width = 240
        Dgl1.Columns(Col1DocQty).Width = 70
        Dgl1.Columns(Col1Qty).Width = 70
        Dgl1.Columns(Col1RejQty).Width = 80
        Dgl1.Columns(Col1Rate).Width = 80
        Dgl1.Columns(Col1Amount).Width = 100

        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
        CType(Dgl1.Columns(Col1DocQty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
        CType(Dgl1.Columns(Col1RejQty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) += " And ItemType In ('" & ClsMain.ItemType.Stationary & "') "

            Case Col1PurchOrder
                Dgl1.AgRowFilter(Dgl1.Columns(Col1PurchOrder).Index) += " And NCat = '" & ClsMain.Temp_NCat.StationaryPurchaseOrder & "' "
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
                TxtPurchOrder.AgRowFilter += " And NCat = '" & ClsMain.Temp_NCat.StationaryPurchaseOrder & "'"
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
            AgL.PubReportTitle = "Stationary Receive"
            RepName = "Lib_StationaryReceive_Print" : RepTitle = "Stationary Receive"
            bCondstr = "WHERE H.DocID='" & mInternalCode & "'"

            strQry = " SELECT  H.DocID, H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo,H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.ReferenceNo, H.Vendor, H.Currency, H.SalesTaxGroupParty, H.Structure, " & _
                    " H.BillingType, H.VendorDocNo, H.VendorDocDate, H.Transport, H.Godown, H.Remarks, " & _
                    " H.TotalQty, H.TotalMeasure, H.TotalAmount, H.EntryBy, H.Status, " & _
                    " L.Sr, L.PurchOrder, L.Item, L.SalesTaxGroupItem, L.DocQty, L.RejQty, L.Qty, " & _
                    " L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalRejMeasure, L.TotalMeasure, " & _
                    " L.Rate, L.Amount, L.InvoicedQty, L.InvoicedMeasure,SG.DispName AS VendorName,SG.Add1,SG.Add2 ,SG.Add3,SG.CityCode ,SG.Mobile, " & _
                    " C.CityName ,I.Description AS ItemName,SF.*, SL.* , " & _
                    " PO.V_Type AS OrderType,PO.V_No AS OrderNo,PO.V_Type + ' - ' + Convert(NVARCHAR(5),PO.V_No) AS POrderNo,SM.Name AS SiteName,PID.DocId AS InvoiceId " & _
                    " FROM PurchChallan H " & _
                    " LEFT JOIN PurchChallanDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.GRStationary) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.GRStationary) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Vendor  " & _
                    " LEFT JOIN Godown G ON G.Code=H.Godown  " & _
                    " LEFT JOIN City C ON C.CityCode =SG.CityCode  " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN PurchOrder PO ON PO.DocId=L.PurchOrder  " & _
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
End Class
