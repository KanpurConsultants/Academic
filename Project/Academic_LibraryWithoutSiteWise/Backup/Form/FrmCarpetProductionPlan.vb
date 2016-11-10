Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCarpetProductionPlan
    Inherits AgTemplate_Production.TempProductionPlan

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
        Me.EntryNCat = AgTemplate_Production.ClsMain.Temp_NCat.ProductionPlan
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        'TxtProductionOrderNo
        '
        Me.TxtProductionOrderNo.Location = New System.Drawing.Point(332, 67)
        Me.TxtProductionOrderNo.Size = New System.Drawing.Size(176, 18)
        '
        'LblProductionOrderNo
        '
        Me.LblProductionOrderNo.Location = New System.Drawing.Point(180, 68)
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Panel1.Location = New System.Drawing.Point(4, 467)
        Me.Panel1.Size = New System.Drawing.Size(973, 23)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 191)
        Me.Pnl1.Size = New System.Drawing.Size(972, 276)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(332, 87)
        Me.TxtRemarks.Size = New System.Drawing.Size(453, 18)
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(180, 88)
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Location = New System.Drawing.Point(880, 82)
        '
        'LblProductionOrderNoReq
        '
        Me.LblProductionOrderNoReq.Location = New System.Drawing.Point(316, 73)
        '
        'LblDueDateReq
        '
        Me.LblDueDateReq.Location = New System.Drawing.Point(620, 73)
        '
        'TxtDueDate
        '
        Me.TxtDueDate.Location = New System.Drawing.Point(636, 67)
        '
        'LblDueDate
        '
        Me.LblDueDate.Location = New System.Drawing.Point(514, 68)
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(4, 497)
        Me.Panel2.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(832, 532)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 532)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 532)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 532)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 532)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 524)
        Me.GroupBox1.Size = New System.Drawing.Size(1002, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(300, 532)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(514, 48)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(636, 47)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(316, 53)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(180, 49)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(620, 33)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(332, 47)
        Me.TxtV_Date.Size = New System.Drawing.Size(176, 18)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(514, 29)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(636, 27)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(316, 33)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(180, 29)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(332, 27)
        Me.TxtSite_Code.Size = New System.Drawing.Size(176, 18)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(574, 48)
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(8, 41)
        Me.TabControl1.Size = New System.Drawing.Size(965, 147)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(957, 121)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(984, 41)
        '
        'FrmCarpetProductionPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(984, 578)
        Me.LogLineTableCsv = "ProdPlanDetail_Log"
        Me.LogTableName = "ProdPlan_Log"
        Me.MainLineTableCsv = "ProdPlanDetail"
        Me.MainTableName = "ProdPlan"
        Me.Name = "FrmCarpetProductionPlan"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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
            mQry = "SELECT S.Description As Size, S.YardArea As AreaPerPcs  " & _
                   " FROM RUG_CarpetSku CS  " & _
                   " LEFT JOIN Rug_Size S ON Cs.Size = S.Code  " & _
                   " WHERE CS.Code = '" & Code & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.VNull(DtTemp.Rows(0)("AreaPerPcs"))
            Else
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = 0
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub FrmCarpetSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).HeaderText = "Carpet SKU"
        Dgl1.Columns(Col1MeasurePerPcs).HeaderText = "Area Per Pcs"
        Dgl1.Columns(Col1TotalMeasure).HeaderText = "Total Area"
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

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
        AgL.WinSetting(Me, 625, 992, 0, 0)
    End Sub


    'Code by Satyam on 21/06/2011
    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            If FrmType = ClsMain.EntryPointType.Main Then
                AgL.PubReportTitle = "Production Plan"
                RepName = "Rug_ProductionPlan_Print" : RepTitle = "Production Plan"
                bTableName = "ProdPlan" : bSecTableName = "ProdPlanDetail PP1 ON PP1.DocID =PP.DocId "
                bCondstr = "WHERE PP.DocID='" & SearchCode & "'"
            Else
                AgL.PubReportTitle = "Production Plan Log"
                RepName = "Rug_ProductionPlan_Print" : RepTitle = "Production Plan Log"
                bTableName = "ProdPlan_Log" : bSecTableName = "ProdPlanDetail_Log  PP1 ON PP1.UID =PP.UID "
                bCondstr = "WHERE PP.UID='" & SearchCode & "'"

            End If

            strQry = " SELECT  PP.DocID, PP.V_Type, PP.V_Prefix, PP.V_Date, PP.V_No, PP.Div_Code, PP.Site_Code, " & _
                        " PP.ProdOrder, PP.DueDate, PP.TotalQty, PP.TotalMeasure, PP.Remarks, PP.EntryBy, PP.EntryDate, PP.EntryType,  " & _
                        " PP.EntryStatus, PP.ApproveBy, PP.ApproveDate, PP.MoveToLog, PP.MoveToLogDate, PP.IsDeleted, PP.Status, PP.UID, " & _
                        " PP1.Sr, PP1.Item, PP1.Qty, PP1.Unit, PP1.StkQty_Finished, PP1.StkQty_SemiFinished, " & _
                        " PP1.StkQtyReq_OpenSaleOrder, PP1.ExcessQty_Finished, PP1.ExcessQty_SemiFinished, PP1.ComputerProdPlanQty, " & _
                        " PP1.ComputerProdPlanMeasure, PP1.UserPurchPlanQty, PP1.UserPurchPlanMeasure, PP1.UserProdPlanQty, PP1.UserProdPlanMeasure, " & _
                        " PP1.UserProdPlanRemarks, PP1.MeasurePerPcs, PP1.MeasureUnit, PP1.ProdIssQty, PP1.ProdIssMeasure, PP1.ProdRecQty,  " & _
                        " PP1.ProdRecMeasure, PP1.UID AS LineUID, PP1.TotalMeasure, I.Description AS ItemDesc,Vt.Description AS PlanType, " & _
                        " PO.V_No AS OrderNo,VtO.Description AS OrderType " & _
                        " FROM " & bTableName & " PP " & _
                        " LEFT JOIN " & bSecTableName & " " & _
                        " LEFT JOIN Item I ON I.Code=PP1.Item  " & _
                        " LEFT JOIN Voucher_Type Vt ON Vt.V_Type =PP.V_Type " & _
                        " LEFT JOIN ProdOrder PO ON PO.DocID=PP.ProdOrder " & _
                        " LEFT JOIN Voucher_Type VtO ON VtO.V_Type=PO.V_Type " & _
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

    End Sub 'End Code by Satyam on 21/06/2011

End Class
