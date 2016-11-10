Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmOtherMaterialTransferIssue
    Inherits AgTemplate.TempStockTransferIssue

    Protected Const Col1ItemGroup As String = "Item Group"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.BookTransferIssue
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
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Visible = False
        '
        'Label33
        '
        Me.Label33.Visible = False
        '
        'FrmOtherMaterialTransferIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(901, 562)
        Me.LogLineTableCsv = "Stock_LOG,StockProcess_LOG,Structure_TransFooter_Log"
        Me.LogTableName = "StockHead_Log"
        Me.MainLineTableCsv = "Stock,StockProcess,Structure_TransFooter"
        Me.MainTableName = "StockHead"
        Me.Name = "FrmOtherMaterialTransferIssue"
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

    Private Sub FrmOtherMaterialTransferIssue_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtFromGodown.AgSelectedValue = RetDefaultGodown(AgL.PubSiteCode, AgL.PubDivCode, ClsMain.ItemType.Book)
    End Sub

    Private Sub FrmYarnSKUOpeningStock_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        AgCL.AddAgTextColumn(Dgl1, Col1ItemGroup, 150, 0, Col1ItemGroup, True, True)
        Dgl1.Columns(Col1ItemGroup).DisplayIndex = 2
        Dgl1.Columns(Col1Item).HeaderText = "Other Material"
        Dgl1.Columns(Col1Process).Visible = False
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
    End Sub

    Private Sub FrmYarnSKUTransferIssue_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer = 0
        For I = 0 To Dgl1.Rows.Count - 1
            Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)
        Next
    End Sub

    Private Sub FrmYarnSKUOpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 596, 909)
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
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.Book & "' "
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

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            If FrmType = ClsMain.EntryPointType.Main Then
                AgL.PubReportTitle = "Other Material Transfer Issue"
                RepName = "Rug_OtherMaterialTrsnsferIssue_Print" : RepTitle = "Other Material Transfer Issue"
                bTableName = "StockHead" : bSecTableName = "Stock S ON Sh.DocID = S.DocID"
                bCondstr = "WHERE Sh.DocID='" & SearchCode & "'"
            Else
                AgL.PubReportTitle = "Other Material Transfer Issue Log"
                RepName = "Rug_OtherMaterialTrsnsferIssue_Print" : RepTitle = "Other Material Transfer Issue Log"
                bTableName = "StockHead_Log" : bSecTableName = "Stock_Log  S ON Sh.UID = S.UID "
                bCondstr = "WHERE Sh.UID='" & SearchCode & "'"
            End If
            bCondstr += "And Vt.NCat = '" & ClsMain.Temp_NCat.BookTransferIssue & "' "

            strQry = "SELECT Sh.DocID, Sh.V_Type, Sh.V_Prefix, Sh.V_Date, Sh.V_No, Sh.Div_Code, " & _
                        " Sh.Site_Code, Sh.SubCode, Sh.FromProcess, Sh.ToProcess, Sh.FromGodown, Sh.ToGodown, " & _
                        " Sh.TotalQty, Sh.TotalMeasure, Sh.Amount, Sh.Addition, Sh.Deduction, Sh.NetAmount, " & _
                        " Sh.Remarks, Sh.IsDeleted, Sh.EntryBy, Sh.EntryDate, Sh.EntryType, Sh.EntryStatus, " & _
                        " Sh.ApproveBy, Sh.ApproveDate, Sh.MoveToLog, Sh.MoveToLogDate, Sh.Status, " & _
                        " Sh.UID, Sh.ReferenceDocID, Sh.Structure, " & _
                        " S.Sr, S.SubCode, S.Currency, S.SalesTaxGroupParty, S.Structure, " & _
                        " S.BillingType, S.Item, S.ProcessGroup, S.Godown, S.Qty_Iss, S.Qty_Rec, " & _
                        " S.Unit, S.MeasurePerPcs, S.Measure_Iss, S.Measure_Rec, S.MeasureUnit, " & _
                        " S.Rate, S.Amount, S.Addition, S.Deduction,S.NetAmount, S.Remarks, " & _
                        " S.Status As StockStatus, S.Process, S.FIFORate, S.FIFOAmt, S.AVGRate, S.AVGAmt, " & _
                        " S.Cost, S.Doc_Qty, S.ReferenceDocID,  " & _
                        " Vt.Description + '/' + Convert(NVARCHAR,Sh.V_No) AS TransferNo, " & _
                        " Sg.DisptName AS StockHeadAccountName, Vc.NCatDescription AS FromProcessDesc, " & _
                        " Vc1.NCatDescription AS ToProcessDesc, G.Description AS FromGodownDesc, " & _
                        " G1.Description AS ToGodownDesc, Sg1.Name AS StockAccountName, " & _
                        " I.Description As ItemDesc, Vc.NCatDescription As StockProcess, I.ItemGroup " & _
                        " FROM " & bTableName & " Sh " & _
                        " LEFT JOIN " & bSecTableName & " " & _
                        " LEFT JOIN Voucher_Type Vt ON S.V_Type = Vt.V_Type " & _
                        " LEFT JOIN SiteMast Sm ON Sh.Site_Code = Sm.Code " & _
                        " LEFT JOIN SubGroup Sg ON Sh.SubCode = Sg.SubCode " & _
                        " LEFT JOIN VoucherCat Vc ON Sh.FromProcess = Vc.NCat  " & _
                        " LEFT JOIN VoucherCat Vc1 ON Sh.ToProcess = Vc1.NCat " & _
                        " LEFT JOIN Godown G ON Sh.FromGodown = G.Code " & _
                        " LEFT JOIN Godown G1 ON Sh.ToGodown = G1.Code " & _
                        " LEFT JOIN SubGroup Sg1 ON S.SubCode = Sg1.SubCode " & _
                        " LEFT JOIN Item I On S.Item = I.Code " & _
                        " LEFT JOIN VoucherCat Vc2 On S.Process = Vc.NCat " & _
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
End Class
