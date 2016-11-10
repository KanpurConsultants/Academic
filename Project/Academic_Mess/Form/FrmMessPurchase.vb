Public Class FrmMessPurchase
    Inherits Academic_ProjLib.TempPurchase

    Public Sub New(ByVal StrUserPermission, ByVal DTUP)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUserPermission, DTUP)
        Topctrl1.SetDisp(True)

        Me.AglObj = AgL
        Me.EntryNCatList = "" & AgL.Chk_Text(ClsMain.Temp_NCat.MessPurchase) & ""
    End Sub

    Private Sub FrmPurchase_BaseFunction_IniGrid()
        With DGL1
            .Columns(Col1BatchNo).Visible = False
            .Columns(Col1DocQty).Visible = False
        End With
    End Sub

#Region "Form Designer"
    Private Sub InitializeComponent()
        Me.PnlFooter.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.Tc1.SuspendLayout()
        Me.TP1.SuspendLayout()
        Me.GBoxApproved.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxModified.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.TabIndex = 0
        '
        'LblV_No
        '
        Me.LblV_No.Size = New System.Drawing.Size(82, 15)
        Me.LblV_No.Text = "Purchase No."
        '
        'LblV_Date
        '
        Me.LblV_Date.Size = New System.Drawing.Size(89, 15)
        Me.LblV_Date.Text = "Purchase Date"
        '
        'LblV_Type
        '
        Me.LblV_Type.Size = New System.Drawing.Size(89, 15)
        Me.LblV_Type.Text = "Purchase Type"
        '
        'TP1
        '
        Me.TP1.Text = "Purchase Detail"
        '
        'FrmPurchase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.MainTableName = "Store_Purchase"
        Me.Name = "FrmPurchase"
        Me.PnlFooter.ResumeLayout(False)
        Me.PnlFooter.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.Tc1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        Me.GBoxApproved.ResumeLayout(False)
        Me.GBoxApproved.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxModified.ResumeLayout(False)
        Me.GBoxModified.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private Sub FrmPurchase_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtSalesTaxGroupParty.AgSelectedValue = AglObj.XNull(DtMess_Enviro.Rows(0)("SalesTaxGroupParty"))
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1SalesTaxGroupItem
                    DGL1.AgRowFilter(mColumnIndex) = " Active <> 0 "

                Case Col1Item
                    DGL1.AgRowFilter(mColumnIndex) = " MasterType = '" & ClsMain.ItemType.Mess & "' "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col1Item
                        If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                            DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                            DGL1.AgSelectedValue(Col1Unit, mRowIndex) = ""
                            DGL1.Item(Col1Rate, mRowIndex).Value = ""
                            DGL1.AgSelectedValue(Col1SalesTaxGroupItem, mRowIndex) = ""
                        Else
                            If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AglObj.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
                                DGL1.AgSelectedValue(Col1Unit, mRowIndex) = AglObj.XNull(DrTemp(0)("Unit"))
                                DGL1.Item(Col1Rate, mRowIndex).Value = Format(AglObj.VNull(DrTemp(0)("PurchaseRate")), "0.00")
                                DGL1.AgSelectedValue(Col1SalesTaxGroupItem, mRowIndex) = AglObj.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                            End If
                            DrTemp = Nothing
                        End If

                    Case Col1DocQty
                        If DGL1.Item(Col1Qty, mRowIndex).Value Is Nothing Then DGL1.Item(Col1Qty, mRowIndex).Value = ""

                        If Val(DGL1.Item(Col1Qty, mRowIndex).Value) = 0 _
                            And Val(DGL1.Item(Col1DocQty, mRowIndex).Value) > 0 Then

                            DGL1.Item(Col1Qty, mRowIndex).Value = DGL1.Item(Col1DocQty, mRowIndex).Value
                        End If
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
