Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmStationaryQuatation
    Inherits AgTemplate.TempPurchQuotation
    Dim DsItem As DataSet

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.StationaryQuotation
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
        'TxtVendor
        '
        Me.TxtVendor.Location = New System.Drawing.Point(300, 48)
        '
        'LblVendor
        '
        Me.LblVendor.Location = New System.Drawing.Point(184, 49)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(5, 373)
        Me.Panel1.Size = New System.Drawing.Size(868, 21)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(5, 186)
        Me.Pnl1.Size = New System.Drawing.Size(868, 186)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(300, 87)
        Me.TxtRemarks.Size = New System.Drawing.Size(389, 18)
        Me.TxtRemarks.TabIndex = 7
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(184, 89)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Location = New System.Drawing.Point(390, 3)
        Me.LblTotalMeasure.Visible = False
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(279, 3)
        Me.Label33.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(5, 165)
        '
        'TxtVendorCity
        '
        Me.TxtVendorCity.Location = New System.Drawing.Point(892, 32)
        Me.TxtVendorCity.Size = New System.Drawing.Size(48, 18)
        Me.TxtVendorCity.Visible = False
        '
        'LblVendorCity
        '
        Me.LblVendorCity.Location = New System.Drawing.Point(762, 33)
        Me.LblVendorCity.Visible = False
        '
        'LblVendorReq
        '
        Me.LblVendorReq.Location = New System.Drawing.Point(284, 55)
        '
        'TxtVendorCountry
        '
        Me.TxtVendorCountry.Location = New System.Drawing.Point(886, 13)
        Me.TxtVendorCountry.Size = New System.Drawing.Size(54, 18)
        Me.TxtVendorCountry.Visible = False
        '
        'LblVendorCountry
        '
        Me.LblVendorCountry.Location = New System.Drawing.Point(762, 9)
        Me.LblVendorCountry.Visible = False
        '
        'LblCurrency
        '
        Me.LblCurrency.Location = New System.Drawing.Point(762, 54)
        Me.LblCurrency.Visible = False
        '
        'TxtCurrency
        '
        Me.TxtCurrency.Location = New System.Drawing.Point(887, 54)
        Me.TxtCurrency.Size = New System.Drawing.Size(53, 18)
        Me.TxtCurrency.Visible = False
        '
        'LblVendorQuoteNo
        '
        Me.LblVendorQuoteNo.Location = New System.Drawing.Point(184, 67)
        '
        'TxtVendorQuoteNo
        '
        Me.TxtVendorQuoteNo.Location = New System.Drawing.Point(300, 67)
        Me.TxtVendorQuoteNo.Size = New System.Drawing.Size(130, 18)
        Me.TxtVendorQuoteNo.TabIndex = 5
        '
        'LblVendorQuoteDate
        '
        Me.LblVendorQuoteDate.Location = New System.Drawing.Point(441, 67)
        '
        'TxtVendorQuoteDate
        '
        Me.TxtVendorQuoteDate.Location = New System.Drawing.Point(559, 67)
        Me.TxtVendorQuoteDate.Size = New System.Drawing.Size(130, 18)
        Me.TxtVendorQuoteDate.TabIndex = 6
        '
        'TxtTermsAndConditions
        '
        Me.TxtTermsAndConditions.Size = New System.Drawing.Size(410, 127)
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(712, 165)
        Me.TxtStructure.Size = New System.Drawing.Size(103, 18)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(645, 165)
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(509, 401)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(362, 143)
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.Location = New System.Drawing.Point(729, 3)
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.Location = New System.Drawing.Point(618, 3)
        '
        'TxtBillingType
        '
        Me.TxtBillingType.Location = New System.Drawing.Point(883, 73)
        Me.TxtBillingType.Size = New System.Drawing.Size(57, 18)
        '
        'LblBillingType
        '
        Me.LblBillingType.Location = New System.Drawing.Point(762, 73)
        '
        'LblPostingGroupSalesTaxParty
        '
        Me.LblPostingGroupSalesTaxParty.Location = New System.Drawing.Point(762, 96)
        Me.LblPostingGroupSalesTaxParty.Visible = False
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(878, 92)
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(62, 18)
        Me.TxtSalesTaxGroupParty.Visible = False
        '
        'LblIndentNo
        '
        Me.LblIndentNo.Location = New System.Drawing.Point(14, 69)
        Me.LblIndentNo.Size = New System.Drawing.Size(63, 16)
        Me.LblIndentNo.TabIndex = 779
        Me.LblIndentNo.Text = "Indent No"
        Me.LblIndentNo.Visible = False
        '
        'TxtIndentNo
        '
        Me.TxtIndentNo.AgNumberLeftPlaces = 0
        Me.TxtIndentNo.AgNumberRightPlaces = 0
        Me.TxtIndentNo.Location = New System.Drawing.Point(96, 68)
        Me.TxtIndentNo.MaxLength = 100
        Me.TxtIndentNo.Size = New System.Drawing.Size(58, 18)
        Me.TxtIndentNo.TabIndex = 5
        Me.TxtIndentNo.Visible = False
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(27, 140)
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(429, 420)
        Me.PnlCShowGrid.Size = New System.Drawing.Size(30, 140)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(726, 557)
        Me.GroupBox2.Size = New System.Drawing.Size(143, 40)
        '
        'TxtStatus
        '
        Me.TxtStatus.Size = New System.Drawing.Size(111, 18)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(564, 557)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(402, 557)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(141, 557)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(8, 557)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 553)
        Me.GroupBox1.Size = New System.Drawing.Size(897, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(274, 557)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(441, 29)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(559, 28)
        Me.TxtV_No.Size = New System.Drawing.Size(130, 18)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(284, 34)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(184, 29)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(539, 12)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(300, 28)
        Me.TxtV_Date.Size = New System.Drawing.Size(130, 18)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(441, 10)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(559, 8)
        Me.TxtV_Type.Size = New System.Drawing.Size(130, 18)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(284, 14)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(184, 10)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(300, 8)
        Me.TxtSite_Code.Size = New System.Drawing.Size(130, 18)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(66, 18)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(-4, 19)
        Me.TabControl1.Size = New System.Drawing.Size(885, 140)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(877, 114)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(879, 41)
        '
        'FrmStationaryQuatation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(879, 598)
        Me.LogLineTableCsv = "PurchQuotationDetail_Log,Structure_TransFooter_Log,Structure_TransLine_Log"
        Me.LogTableName = "PurchQuotation_Log"
        Me.MainLineTableCsv = "PurchQuotationDetail,Structure_TransFooter,Structure_TransLine"
        Me.MainTableName = "PurchQuotation"
        Me.Name = "FrmStationaryQuatation"
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

    Private Sub FrmBookQuatation_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0")
    End Sub

    Private Sub FrmBookQuatation_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        Dgl1.AgHelpDataSet(Col1Item, 22, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Item
    End Sub

    Private Sub FrmBookQuatation_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).HeaderText = "Stationary Item"
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1MeasureUnit).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
        Dgl1.Columns(Col1IndentNo).Visible = False

        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
    End Sub

    Private Sub FrmBookRequisition_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "UPDATE PurchQuotation_Log " & _
                " SET PurchIndent = " & AgL.Chk_Text(TxtIndentNo.AgSelectedValue) & " " & _
                " WHERE UID = " & AgL.Chk_Text(mSearchCode) & " "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmBookQuatation_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select P.* " & _
                " From PurchQuotation P " & _
                " Where P.DocID = '" & SearchCode & "'"
        Else
            mQry = "Select P.* " & _
                " From PurchQuotation_Log P " & _
                " Where P.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtIndentNo.AgSelectedValue = AgL.XNull(.Rows(0)("PurchIndent"))
            End If
        End With
    End Sub

    Private Sub FrmBookQuatation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AgL.WinSetting(Me, 630, 885, 0, 0)
        DsItem = Dgl1.AgHelpDataSet(Col1Item)
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
                    If Dgl1.AgSelectedValue(Col1Item, mRowIndex) = "" And Dgl1.Item(Col1Item, mRowIndex).Value = "" Then
                        Dgl1.Item(Col1Qty, mRowIndex).Value = 0
                    Else
                        If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                            DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, mRowIndex)) & "")
                            If TxtIndentNo.AgSelectedValue <> "" And TxtIndentNo.Text <> "" Then
                                Dgl1.Item(Col1Qty, mRowIndex).Value = AgL.XNull(DrTemp(0)("Qty"))
                            End If
                        End If
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtIndentNo_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIndentNo.Enter
        TxtIndentNo.AgRowFilter = " IsDeleted = 0 And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Stationary Purchase Indent"
            RepName = "Lib_StationaryPurchQuatation_Print" : RepTitle = "Stationary Purchase Quotation"
            bCondstr = "WHERE H.DocID='" & mInternalCode & "'"


            strQry = " SELECT  H.DocID, H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.Vendor, H.VendorName, H.Currency, H.Structure, H.BillingType, H.VendorQuoteNo, H.VendorQuoteDate, " & _
                    " H.TermsAndConditions, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, H.PostingGroupSalesTaxParty, H.PurchIndent, " & _
                    " L.Item, L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalMeasure AS LineTotalMeasure, " & _
                    " L.Rate, L.Amount, L.PostingGroupSalesTaxItem, L.OrdQty, L.OrdMeasure, L.PurchQty, L.PurchMeasure, " & _
                    " I.Description AS ItemDesc,B.Writer ,B.Publisher,SM.Name AS SiteName,SF.*, SL.* , P.V_No AS IndentNo, P.V_Type AS IndentType  " & _
                    " FROM PurchQuotation H " & _
                    " LEFT JOIN PurchQuotationDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQueryFooter(AgL, ClsMain.Temp_NCat.BookPurchaseQuotation) & ") As SF On H.DocId = SF.DocId " & _
                    " LEFT JOIN (" & AgStructure.AgCalcGrid.AgStructureSubQuery(AgL, ClsMain.Temp_NCat.BookPurchaseQuotation) & ") As SL On L.DocId = SL.DocId And L.Sr = Sl.TSr " & _
                    " LEFT JOIN Item I ON I.Code=L.Item  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=L.Item  " & _
                    " LEFT JOIN PurchIndent P ON P.DocId=H.PurchIndent  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
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

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) += " And ItemType In ('" & ClsMain.ItemType.Stationary & "') "
        End Select
    End Sub
End Class
