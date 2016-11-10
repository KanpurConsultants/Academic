Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCarpetMaterialPlan
    Inherits AgTemplate_Production.TempMaterialPlan

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
        Me.EntryNCat = AgTemplate_Production.ClsMain.Temp_NCat.MaterialPlan
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
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(0, 329)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(0, 190)
        Me.Pnl1.Size = New System.Drawing.Size(972, 138)
        '
        'BtnFill
        '
        Me.BtnFill.Location = New System.Drawing.Point(837, 67)
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(1, 384)
        Me.Pnl2.Size = New System.Drawing.Size(972, 147)
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(1, 533)
        '
        'Label33
        '
        Me.Label33.Size = New System.Drawing.Size(81, 16)
        Me.Label33.Text = "Total Area :"
        '
        'LinkLabel5
        '
        Me.LinkLabel5.Location = New System.Drawing.Point(4, 358)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(828, 574)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(649, 574)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(462, 574)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(146, 574)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(12, 574)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(-2, 570)
        Me.GroupBox1.Size = New System.Drawing.Size(994, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(296, 574)
        '
        'LblPrefix
        '
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Size = New System.Drawing.Size(964, 122)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(956, 96)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(976, 41)
        '
        'FrmCarpetMaterialPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(976, 622)
        Me.LogLineTableCsv = "MaterialPlanForDetail_Log,MaterialPlanDetail_Log"
        Me.LogTableName = "MaterialPlan_Log"
        Me.MainLineTableCsv = "MaterialPlanForDetail,MaterialPlanDetail"
        Me.MainTableName = "MaterialPlan"
        Me.Name = "FrmCarpetMaterialPlan"
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

    Private Sub FrmCarpetMaterialPlan_BaseFunction_IniGrid1() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).HeaderText = "Carpet SKU"
        Dgl1.Columns(Col1MeasurePerPcs).HeaderText = "Area Per Pcs"
        Dgl1.Columns(Col1TotalMeasure).HeaderText = "Total Area"

        Dgl2.Columns(Col2Item).HeaderText = "Yarn SKU"
        Dgl2.Columns(Col2BomQty).HeaderText = "Total Consumption Qty"
    End Sub

    Private Sub FrmCarpetMaterialPlan_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
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

    Private Sub FrmCarpetMaterialPlan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 660, 992, 0, 0)
    End Sub

    'Code by Satyam on 23/06/2011
    Private Sub FrmMaterialPlan_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim DsRep1 As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = "", strQry1 As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bThirdTableName As String = ""
        Dim bCondstr As String = "", bCondstr1 As String = ""
        Dim bMaterialType As String = ""
        bMaterialType = "Yarn SKU"
        Try
            Me.Cursor = Cursors.WaitCursor
            If FrmType = ClsMain.EntryPointType.Main Then
                AgL.PubReportTitle = "Material Plan"
                RepName = "Rug_MaterialPlan_Print" : RepTitle = "Material Plan"
                bTableName = "MaterialPlan" : bSecTableName = "MaterialPlanDetail MP1 ON MP1.DocID =MP.DocId "
                bThirdTableName = "MaterialPlanForDetail"
                bCondstr = "WHERE MP.DocID='" & SearchCode & "'" : bCondstr1 = "WHERE MD.DocID='" & SearchCode & "'"
            Else
                AgL.PubReportTitle = "Material Plan Log"
                RepName = "Rug_MaterialPlan_Print" : RepTitle = "Material Plan Log"
                bTableName = "MaterialPlan_Log" : bSecTableName = "MaterialPlanDetail_Log  MP1 ON MP1.UID =MP.UID "
                bThirdTableName = "MaterialPlanForDetail_Log"
                bCondstr = "WHERE MP.UID='" & SearchCode & "'" : bCondstr1 = "WHERE MD.UID='" & SearchCode & "'"

            End If

            strQry = " SELECT MP.DocID, MP.V_Type, MP.V_Prefix, MP.V_Date, MP.V_No, MP.Div_Code, MP.Site_Code, MP.ProdPlan,  MP.TotalQty, MP.TotalMeasure, " & _
                        " MP.TotalComputerConsumptionPlanQty, MP.TotalUserConsumptionPlanQty, MP.Remarks,  MP.EntryBy, MP.EntryDate, MP.EntryType, MP.EntryStatus, " & _
                        " MP.ApproveBy, MP.ApproveDate, MP.MoveToLog, MP.MoveToLogDate,  MP.IsDeleted, MP.Status, MP.UID,  MP1.Sr, MP1.Item, MP1.BomQty, MP1.Unit, " & _
                        " MP1.StockQty, MP1.IssuedQty_ProdPlan, MP1.ComputerMaterialPlanQty,  MP1.ComputerMaterialPlanMeasure, MP1.UserMaterialPlanQty, MP1.UserMaterialPlanMeasure, " & _
                        " MP1.UserMaterialPlanRemarks, MP1.MeasurePerPcs,  MP1.MeasureUnit, MP1.PurchOrdQty, MP1.PurchOrdMeasure, MP1.PurchQty, MP1.PurchMeasure, " & _
                        " MP1.ProdIssQty, MP1.ProdIssMeasure, MP1.UID,  Vt.Description AS PlanType,SM.ManualCode AS SiteName,I.Description AS ItemDesc, " & _
                        " VtP.Description AS PlanType,PP.V_No AS PlanNo,'" & bMaterialType & "' AS MaterialType " & _
                        " FROM " & bTableName & " MP " & _
                        " LEFT JOIN " & bSecTableName & " " & _
                        " LEFT JOIN Voucher_Type Vt ON Vt.V_Type =MP.V_Type  " & _
                        " LEFT JOIN SiteMast SM ON SM.Code=MP.Site_Code  " & _
                        " LEFT JOIN Item I ON I.Code=MP1.Item  " & _
                        " LEFT JOIN ProdPlan PP ON PP.DocID=MP.ProdPlan  " & _
                        " LEFT JOIN Voucher_Type VtP ON VtP.V_Type=PP.V_Type  " & _
                        " " & bCondstr & ""

            strQry1 = " SELECT  MD.DocId, MD.Sr, MD.Item, MD.Qty, MD.Unit, MD.MeasurePerPcs, MD.TotalMeasure, " & _
                        " MD.MeasureUnit,MD.UID,I.Description AS ItemDesc " & _
                        " FROM " & bThirdTableName & " MD " & _
                        " LEFT JOIN Item I ON I.Code=MD.Item " & _
                        " " & bCondstr1 & ""

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry1, AgL.GCn)
            AgL.ADMain.Fill(DsRep1)
            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            AgPL.CreateFieldDefFile1(DsRep1, AgL.PubReportPath & "\" & RepName & "1.ttx", True)
            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            mCrd.OpenSubreport("SUBREP1").Database.Tables(0).SetDataSource(DsRep1.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            AgPL.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub 'End Code by Satyam on 23/06/2011
End Class
