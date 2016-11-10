Public Class FrmUndyedYarnPlan
    Inherits AgTemplate_Production.TempMaterialPlan
    Dim mQry$ = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
        Me.EntryNCat = ClsMain.Temp_NCat.UndyedYarnPlan
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
        Me.Panel1.Location = New System.Drawing.Point(4, 330)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 190)
        Me.Pnl1.Size = New System.Drawing.Size(972, 140)
        '
        'BtnFill
        '
        Me.BtnFill.Location = New System.Drawing.Point(841, 68)
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(5, 382)
        Me.Pnl2.Size = New System.Drawing.Size(972, 160)
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(5, 542)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Visible = False
        '
        'Label33
        '
        Me.Label33.Size = New System.Drawing.Size(82, 16)
        Me.Label33.Text = "Total Area :"
        Me.Label33.Visible = False
        '
        'LinkLabel5
        '
        Me.LinkLabel5.Location = New System.Drawing.Point(5, 361)
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 168)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(832, 580)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 580)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 580)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 580)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 580)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 570)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(300, 580)
        '
        'LblPrefix
        '
        Me.LblPrefix.Visible = False
        '
        'FrmUndyedYarnPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(984, 626)
        Me.LogLineTableCsv = "MaterialPlanForDetail_Log,MaterialPlanDetail_Log"
        Me.LogTableName = "MaterialPlan_Log"
        Me.MainLineTableCsv = "MaterialPlanForDetail,MaterialPlanDetail"
        Me.MainTableName = "MaterialPlan"
        Me.Name = "FrmUndyedYarnPlan"
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
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.YarnSKU & "' "
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
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmCarpetMaterialPlan_BaseFunction_IniGrid1() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).HeaderText = "Yarn SKU"
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False

        Dgl2.Columns(Col2Item).HeaderText = "Yarn"
        Dgl2.Columns(Col2BomQty).HeaderText = "Total Consumption Qty"
    End Sub

    Private Sub FrmCarpetMaterialPlan_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmCarpetMaterialPlan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 660, 992, 0, 0)
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        FillYarnSku()
        FillOtherMaterialConsumption()
        Calculation()
    End Sub


    Protected Sub FillOtherMaterialConsumption()
        Dim I As Integer = 0
        Dim bQry$ = ""
        Dim DsTemp As DataSet = Nothing
        Dim bTempTable$ = ""
        Try
            bTempTable = AgL.GetGUID(AgL.GCn).ToString
            mQry = "CREATE TABLE [#" & bTempTable & "] " & _
                    " (Item NVARCHAR(10), TotalConsumptionQty Float, " & _
                    " StockInHand Float, PendingPurchaseOrderQty Float, IssuedAgainstProductionPlan Float)  "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            With Dgl1
                For I = 0 To .Rows.Count - 1
                    mQry = "INSERT INTO [#" & bTempTable & "] (Item,TotalConsumptionQty) " & _
                            " SELECT Y.Code, " & Val(.Item(Col1Qty, I).Value) & "" & _
                            " FROM RUG_YarnSKU Y " & _
                            " WHERE Yarn = (SELECT Yarn " & _
                            "               FROM RUG_YarnSKU " & _
                            "               WHERE Code = '" & .AgSelectedValue(Col1Item, I) & "') " & _
                            " AND SHADE = '" & DtRug_Enviro.Rows(0)("DefaultUndyedShade") & "'"

                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                Next
            End With

            mQry = "Select C.Item From [#" & bTempTable & "] C Group By C.Item "
            DsTemp = AgL.FillData(mQry, AgL.GCn)

            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        mQry = "INSERT INTO [#" & bTempTable & "](Item,StockInHand) " & _
                                " SELECT S.Item, Sum(IsNull(S.Qty_Rec,0)) - Sum(IsNull(S.Qty_Iss,0)) As StockInHand " & _
                                " FROM Stock S " & _
                                " WHERE S.Item = '" & AgL.XNull(.Rows(I)("Item")) & "' " & _
                                " GROUP BY S.Item "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                    Next I
                End If
            End With

            mQry = "INSERT INTO [#" & bTempTable & "](Item, IssuedAgainstProductionPlan, PendingPurchaseOrderQty) " & _
                    " SELECT Mpd.Item, IsNull(Sum(Mpd.UserMaterialPlanQty),0) - IsNull(Sum(Mpd.ProdIssQty),0), " & _
                    " IsNull(Sum(Mpd.PurchOrdQty),0) - IsNull(Sum(Mpd.PurchQty),0) " & _
                    " FROM MaterialPlan Mp " & _
                    " LEFT JOIN MaterialPlanDetail Mpd ON Mp.DocID = Mpd.DocId " & _
                    " WHERE Mp.ProdPlan <> '" & TxtProductionPlanNo.AgSelectedValue & "' " & _
                    " GROUP BY Mpd.Item "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            mQry = "SELECT T.Item, Sum(IsNull(TotalConsumptionQty,0)) As BomQty, " & _
                    " Sum(IsNull(StockInHand,0)) As StockQty, " & _
                    " Sum(IsNull(PendingPurchaseOrderQty,0)) As PendingPurchaseOrderQty, " & _
                    " Sum(IsNull(IssuedAgainstProductionPlan,0)) As IssuedQty_ProdPlan " & _
                    " From [#" & bTempTable & "] T " & _
                    " Group By T.Item " & _
                    " HAVING Sum(IsNull(TotalConsumptionQty,0)) > 0 "

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                Dgl2.RowCount = 1
                Dgl2.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        Dgl2.Rows.Add()
                        Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count
                        Dgl2.AgSelectedValue(Col2Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl2.Item(Col2BomQty, I).Value = Format(AgL.VNull(.Rows(I)("BomQty")), "0.000")
                        Dgl2.Item(Col2StockQty, I).Value = Format(AgL.VNull(.Rows(I)("StockQty")), "0.000")
                        Dgl2.Item(Col2PendingPurchaseOrderQty, I).Value = Format(AgL.VNull(.Rows(I)("PendingPurchaseOrderQty")), "0.000")
                        Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value = Format(AgL.VNull(.Rows(I)("IssuedQty_ProdPlan")), "0.000")
                        Dgl2.Item(Col2ComputerMaterialPlanQty, I).Value = Format(IIf(Val(Dgl2.Item(Col2BomQty, I).Value) - (IIf(Val(Dgl2.Item(Col2StockQty, I).Value) - Val(Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value) > 0, Val(Dgl2.Item(Col2StockQty, I).Value) - Val(Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value), 0)) > 0, Val(Dgl2.Item(Col2BomQty, I).Value) - (IIf(Val(Dgl2.Item(Col2StockQty, I).Value) - Val(Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value) > 0, Val(Dgl2.Item(Col2StockQty, I).Value) - Val(Dgl2.Item(Col2IssuedQty_ProdPlan, I).Value), 0)), 0), "0.000")
                        Dgl2.Item(Col2UserMaterialPlanQty, I).Value = Format(Val(Dgl2.Item(Col2ComputerMaterialPlanQty, I).Value), "0.000")
                        Validating_Material(Dgl2.AgSelectedValue(Col2Item, I), I)
                    Next I
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Protected Sub FillYarnSku()
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0
        Try
            mQry = "SELECT Mpd.Item, Mpd.UserMaterialPlanQty As UserProdPlanQty, Mpd.Unit, " & _
                    " Mpd.MeasurePerPcs, Mpd.MeasureUnit, Mpd.UserMaterialPlanMeasure As TotalMeasure " & _
                    " FROM MaterialPlan Mp " & _
                    " LEFT JOIN MaterialPlanDetail Mpd ON Mp.DocID = Mpd.DocId " & _
                    " LEFT JOIN Item I ON Mpd.Item = I.Code " & _
                    " WHERE Mp.ProdPlan =  '" & TxtProductionPlanNo.AgSelectedValue & "'" & _
                    " AND I.ItemType = '" & ClsMain.ItemType.YarnSKU & "' "

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                Dgl1.RowCount = 1
                Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("UserProdPlanQty"))
                        Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                        Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                        Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                    Next I
                End If
            End With
            Dgl1.Tag = TxtProductionPlanNo.AgSelectedValue
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
