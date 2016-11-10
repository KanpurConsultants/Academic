Public Class FrmOtherMaterialTransferReceive
    Inherits TempStockTransferReceive
    Dim mQry As String = ""

    Protected Const Col1ItemGroup As String = "Item Group"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.OtherMaterialTransferReceive
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
        TxtToGodown.AgSelectedValue = RetDefaultGodown(AgL.PubSiteCode, AgL.PubDivCode, ClsMain.ItemType.OtherMaterial)
    End Sub

    Private Sub FrmOtherMaterialTransferReceive_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT S.DocID AS Code, Vt.Description + '/' + convert(NVARCHAR,S.V_No)  AS IssueNo, " & _
              " IsNULL(S.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status, " & _
              " S.MoveToLog, IsNull(S.IsDeleted ,0) AS IsDeleted, " & _
              " S.V_Date AS IssueDate, S.Div_Code, S.FromGodown, V1.DocId AS ReceiveDocId " & _
              " FROM StockHead S " & _
              " LEFT JOIN ( " & _
              "   Select St.DocId, St.ReferenceDocID " & _
              " 	FROM StockHead St " & _
              " 	LEFT JOIN Voucher_Type V ON St.V_Type = V.V_Type " & _
              " 	WHERE IsNull(St.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
              " 	AND V.NCat = '" & EntryNCat & "' " & _
              " ) AS V1 ON S.DocId = V1.ReferenceDocId " & _
              " LEFT JOIN Voucher_Type Vt ON S.V_Type = Vt.V_Type " & _
              " WHERE Vt.NCat = '" & ClsMain.Temp_NCat.OtherMaterialTransferIssue & "' "

        TxtIssueNo.AgHelpDataSet(7, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
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
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.OtherMaterial & "' "
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

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Dim I As Integer = 0
        Try
            With Dgl1
                For I = 0 To .Rows.Count - 1
                    If .AgSelectedValue(Col1Item, I) <> "" Then
                        Validating_Item(.AgSelectedValue(Col1Item, I), I)
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
