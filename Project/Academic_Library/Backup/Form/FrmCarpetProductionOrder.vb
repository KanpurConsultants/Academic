Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCarpetProductionOrder
    Inherits AgTemplate_Production.TempProductionOrder

    Protected Const Col1Design As String = "Design"
    Protected Const Col1Size As String = "Size"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = AgTemplate_Production.ClsMain.Temp_NCat.ProductionOrder
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.CarpetSKU & "' "
        End Select
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

    Private Shadows Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim mQry As String
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = "SELECT D.ManualCode As Design, S.Description As Size, S.YardArea As AreaPerPcs  " & _
                   " FROM RUG_CarpetSku CS  " & _
                   " LEFT JOIN RUG_Design D ON Cs.Design = D.Code    " & _
                   " LEFT JOIN Rug_Size S ON Cs.Size = S.Code  " & _
                   " WHERE CS.Code = '" & Code & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1Design, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Design"))
                Dgl1.Item(Col1Size, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Size"))
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.VNull(DtTemp.Rows(0)("AreaPerPcs"))
            Else
                Dgl1.Item(Col1Design, mRow).Value = ""
                Dgl1.Item(Col1Size, mRow).Value = ""
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub FrmCarpetSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        With AgCL
            .AddAgTextColumn(Dgl1, Col1Design, 100, 0, Col1Design, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Size, 100, 0, Col1Size, True, True, False)
        End With

        Dgl1.Columns(Col1Item).HeaderText = "Carpet SKU"
        Dgl1.Columns(Col1MeasurePerPcs).HeaderText = "Area Per Pcs"
        Dgl1.Columns(Col1TotalMeasure).HeaderText = "Total Area"

        Dgl1.Columns(Col1Design).DisplayIndex = 2
        Dgl1.Columns(Col1Size).DisplayIndex = 3
    End Sub

    Private Sub FrmCarpetSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer = 0
        For I = 0 To Dgl1.Rows.Count - 1
            Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)
        Next
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
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
        'TxtDeliveryDate
        '
        Me.TxtDeliveryDate.Location = New System.Drawing.Point(504, 63)
        Me.TxtDeliveryDate.TabIndex = 5
        '
        'LblDeliveryDate
        '
        Me.LblDeliveryDate.Location = New System.Drawing.Point(382, 64)
        '
        'TxtDueDate
        '
        Me.TxtDueDate.AgMandatory = True
        Me.TxtDueDate.Location = New System.Drawing.Point(227, 83)
        Me.TxtDueDate.Size = New System.Drawing.Size(149, 18)
        Me.TxtDueDate.TabIndex = 6
        '
        'LblDueDate
        '
        Me.LblDueDate.Location = New System.Drawing.Point(115, 84)
        '
        'TxtSaleOrderNo
        '
        Me.TxtSaleOrderNo.AgMasterHelp = False
        Me.TxtSaleOrderNo.Location = New System.Drawing.Point(227, 63)
        Me.TxtSaleOrderNo.Size = New System.Drawing.Size(149, 18)
        Me.TxtSaleOrderNo.TabIndex = 4
        '
        'LblSaleOrderNo
        '
        Me.LblSaleOrderNo.Location = New System.Drawing.Point(115, 65)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(40, 404)
        Me.Panel1.Size = New System.Drawing.Size(839, 23)
        '
        'LblTotalQty
        '
        Me.LblTotalQty.Location = New System.Drawing.Point(453, 2)
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.Location = New System.Drawing.Point(374, 2)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(40, 211)
        Me.Pnl1.Size = New System.Drawing.Size(839, 193)
        Me.Pnl1.TabIndex = 1
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Location = New System.Drawing.Point(733, 2)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgMandatory = False
        Me.TxtRemarks.Location = New System.Drawing.Point(227, 103)
        Me.TxtRemarks.Size = New System.Drawing.Size(426, 18)
        Me.TxtRemarks.TabIndex = 7
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(115, 105)
        '
        'LblDueDateReq
        '
        Me.LblDueDateReq.Location = New System.Drawing.Point(211, 89)
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(645, 2)
        Me.Label33.Size = New System.Drawing.Size(82, 16)
        Me.Label33.Text = "Total Area :"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Location = New System.Drawing.Point(701, 108)
        Me.BtnFill.Size = New System.Drawing.Size(130, 23)
        Me.BtnFill.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(747, 447)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(581, 447)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(415, 447)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 447)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 447)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 443)
        Me.GroupBox1.Size = New System.Drawing.Size(936, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(285, 447)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(382, 44)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(504, 43)
        Me.TxtV_No.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(211, 49)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(115, 44)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(488, 29)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(227, 43)
        Me.TxtV_Date.Size = New System.Drawing.Size(149, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(382, 25)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(504, 23)
        Me.TxtV_Type.TabIndex = 1
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(211, 29)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(115, 24)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgMandatory = True
        Me.TxtSite_Code.Location = New System.Drawing.Point(227, 23)
        Me.TxtSite_Code.Size = New System.Drawing.Size(149, 18)
        Me.TxtSite_Code.TabIndex = 0
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(442, 44)
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(40, 47)
        Me.TabControl1.Size = New System.Drawing.Size(839, 158)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(831, 132)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(918, 41)
        '
        'FrmCarpetProductionOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(918, 488)
        Me.EntryNCat = "PRO"
        Me.LogLineTableCsv = "ProdOrderDetail_LOG"
        Me.LogTableName = "ProdOrder_Log"
        Me.MainLineTableCsv = "ProdOrderDetail"
        Me.MainTableName = "ProdOrder"
        Me.Name = "FrmCarpetProductionOrder"
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

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0
        Try
            With Dgl1
                For I = 0 To .Rows.Count - 1
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)
                Next
            End With
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmCarpetProductionOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AgL.WinSetting(Me, 522, 926, 0, 0)
    End Sub

    'Code by Satyam on 17/06/2011
    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            If FrmType = ClsMain.EntryPointType.Main Then
                AgL.PubReportTitle = "Production Order"
                RepName = "Rug_ProductionOrder_Print" : RepTitle = "Production Order"
                bTableName = "ProdOrder" : bSecTableName = "ProdOrderDetail PO1 ON PO1.DocID =PO.DocID"
                bCondstr = "WHERE PO.DocID='" & SearchCode & "'"
            Else
                AgL.PubReportTitle = "Production Order Log"
                RepName = "Rug_ProductionOrder_Print" : RepTitle = "Production Order Log"
                bTableName = "ProdOrder_Log" : bSecTableName = "ProdOrderDetail_Log  PO1 ON PO1.UID =PO.UID "
                bCondstr = "WHERE PO.UID='" & SearchCode & "'"

            End If

            strQry = " SELECT  PO.DocID, PO.V_Type, PO.V_Prefix, PO.V_Date, PO.V_No, PO.Div_Code, PO.Site_Code, " & _
                        " PO.SaleOrder, PO.DueDate, PO.TotalQty, PO.TotalMeasure, PO.Remarks, " & _
                        " PO.EntryBy, PO.EntryDate, PO.EntryType, PO.EntryStatus, PO.ApproveBy, PO.ApproveDate, PO.MoveToLog, PO.MoveToLogDate, PO.IsDeleted, PO.Status, PO.UID, " & _
                        " PO1.Sr, PO1.Item, PO1.Qty, PO1.Unit, PO1.MeasurePerPcs, PO1.TotalMeasure As TotalMeasureLine, PO1.MeasureUnit, PO1.ProdPlanQty, PO1.ProdPlanMeasure, PO1.UID, " & _
                        " SM.Name AS SiteName,I.Description AS ItemDesc,RD.Description AS DesignDesc,RS.Description AS SizeDesc, " & _
                        " VtP.Description AS ProductionType,VtS.Description AS SaleOrderType, SO.V_No AS SaleOrderNo " & _
                        " FROM " & bTableName & " PO " & _
                        " LEFT JOIN " & bSecTableName & " " & _
                        " LEFT JOIN SiteMast SM ON  SM.Code=PO.Site_Code  " & _
                        " LEFT JOIN Item I ON I.Code=PO1.Item " & _
                        " LEFT JOIN RUG_CarpetSku CS ON CS.Code=PO1.Item  " & _
                        " LEFT JOIN RUG_Design RD ON RD.Code=CS.Design  " & _
                        " LEFT JOIN Rug_Size RS ON RS.Code=CS.Size  " & _
                        " LEFT JOIN Voucher_Type VtP ON Vtp.V_Type=PO.V_Type " & _
                        " LEFT JOIN SaleOrder SO ON SO.DocID=PO.SaleOrder  " & _
                        " LEFT JOIN Voucher_Type VtS ON Vts.Category=SO.V_Type " & _
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

    End Sub 'End Code by Satyam on 17/06/2011
End Class
