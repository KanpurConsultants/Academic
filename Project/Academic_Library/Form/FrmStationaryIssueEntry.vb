Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmStationaryIssueEntry
    Inherits TempStockAdjustmentIssue
    Protected WithEvents LblIssuedTo As System.Windows.Forms.Label
    Protected WithEvents TxtIssuedTo As AgControls.AgTextBox
    Protected WithEvents MemberCardNoReq As System.Windows.Forms.Label
    Dim mQry$ = ""


    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.StationaryAdjustmentIssue
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtIssuedTo = New AgControls.AgTextBox
        Me.LblIssuedTo = New System.Windows.Forms.Label
        Me.MemberCardNoReq = New System.Windows.Forms.Label
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
        'TxtFromGodown
        '
        Me.TxtFromGodown.Location = New System.Drawing.Point(802, 25)
        Me.TxtFromGodown.Size = New System.Drawing.Size(40, 18)
        Me.TxtFromGodown.TabIndex = 586
        Me.TxtFromGodown.Visible = False
        '
        'LblFromGodown
        '
        Me.LblFromGodown.Location = New System.Drawing.Point(724, 24)
        Me.LblFromGodown.Size = New System.Drawing.Size(55, 16)
        Me.LblFromGodown.Text = "Godown"
        Me.LblFromGodown.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(4, 371)
        Me.Panel1.Size = New System.Drawing.Size(863, 23)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 210)
        Me.Pnl1.Size = New System.Drawing.Size(863, 161)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Visible = False
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(4, 415)
        Me.TxtRemarks.TabIndex = 2
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(4, 397)
        '
        'LblFromGodownReq
        '
        Me.LblFromGodownReq.Location = New System.Drawing.Point(785, 27)
        Me.LblFromGodownReq.Visible = False
        '
        'Label33
        '
        Me.Label33.Visible = False
        '
        'LblToGodownReq
        '
        Me.LblToGodownReq.Location = New System.Drawing.Point(787, 12)
        Me.LblToGodownReq.Visible = False
        '
        'TxtToGodown
        '
        Me.TxtToGodown.Location = New System.Drawing.Point(803, 6)
        Me.TxtToGodown.Size = New System.Drawing.Size(36, 18)
        Me.TxtToGodown.TabIndex = 4526
        Me.TxtToGodown.Visible = False
        '
        'LblToGodown
        '
        Me.LblToGodown.Location = New System.Drawing.Point(715, 7)
        Me.LblToGodown.Visible = False
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(484, 399)
        '
        'LblMaterialPlanForFollowingItems
        '
        Me.LblMaterialPlanForFollowingItems.Location = New System.Drawing.Point(4, 189)
        '
        'TxtOrderBy
        '
        Me.TxtOrderBy.Location = New System.Drawing.Point(264, 79)
        Me.TxtOrderBy.Size = New System.Drawing.Size(411, 18)
        Me.TxtOrderBy.TabIndex = 5
        '
        'LblOrderBy
        '
        Me.LblOrderBy.Location = New System.Drawing.Point(152, 81)
        Me.LblOrderBy.Size = New System.Drawing.Size(66, 16)
        Me.LblOrderBy.Text = "Issued By"
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(887, 4)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(394, 40)
        Me.LblV_No.Size = New System.Drawing.Size(63, 16)
        Me.LblV_No.Text = "Issue No."
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(488, 39)
        Me.TxtV_No.Size = New System.Drawing.Size(187, 18)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(248, 45)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(152, 40)
        Me.LblV_Date.Size = New System.Drawing.Size(70, 16)
        Me.LblV_Date.Text = "Issue Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(468, 25)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(264, 39)
        Me.TxtV_Date.Size = New System.Drawing.Size(120, 18)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(394, 21)
        Me.LblV_Type.Size = New System.Drawing.Size(71, 16)
        Me.LblV_Type.Text = "Issue Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(488, 19)
        Me.TxtV_Type.Size = New System.Drawing.Size(187, 18)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(248, 25)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(152, 20)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(264, 19)
        Me.TxtSite_Code.Size = New System.Drawing.Size(120, 18)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(-3, 42)
        Me.TabControl1.Size = New System.Drawing.Size(875, 144)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.MemberCardNoReq)
        Me.TP1.Controls.Add(Me.TxtIssuedTo)
        Me.TP1.Controls.Add(Me.LblIssuedTo)
        Me.TP1.Size = New System.Drawing.Size(867, 118)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblFromGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtFromGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblFromGodownReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblToGodownReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblToGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtToGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblOrderBy, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtOrderBy, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblIssuedTo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtIssuedTo, 0)
        Me.TP1.Controls.SetChildIndex(Me.MemberCardNoReq, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(869, 41)
        Me.Topctrl1.TabIndex = 3
        '
        'TxtIssuedTo
        '
        Me.TxtIssuedTo.AgMandatory = True
        Me.TxtIssuedTo.AgMasterHelp = False
        Me.TxtIssuedTo.AgNumberLeftPlaces = 0
        Me.TxtIssuedTo.AgNumberNegetiveAllow = False
        Me.TxtIssuedTo.AgNumberRightPlaces = 0
        Me.TxtIssuedTo.AgPickFromLastValue = False
        Me.TxtIssuedTo.AgRowFilter = ""
        Me.TxtIssuedTo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIssuedTo.AgSelectedValue = Nothing
        Me.TxtIssuedTo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIssuedTo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtIssuedTo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIssuedTo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIssuedTo.Location = New System.Drawing.Point(264, 59)
        Me.TxtIssuedTo.MaxLength = 20
        Me.TxtIssuedTo.Name = "TxtIssuedTo"
        Me.TxtIssuedTo.Size = New System.Drawing.Size(411, 18)
        Me.TxtIssuedTo.TabIndex = 4
        '
        'LblIssuedTo
        '
        Me.LblIssuedTo.AutoSize = True
        Me.LblIssuedTo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIssuedTo.Location = New System.Drawing.Point(152, 60)
        Me.LblIssuedTo.Name = "LblIssuedTo"
        Me.LblIssuedTo.Size = New System.Drawing.Size(64, 16)
        Me.LblIssuedTo.TabIndex = 869
        Me.LblIssuedTo.Text = "Issued To"
        '
        'MemberCardNoReq
        '
        Me.MemberCardNoReq.AutoSize = True
        Me.MemberCardNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.MemberCardNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MemberCardNoReq.Location = New System.Drawing.Point(248, 67)
        Me.MemberCardNoReq.Name = "MemberCardNoReq"
        Me.MemberCardNoReq.Size = New System.Drawing.Size(10, 7)
        Me.MemberCardNoReq.TabIndex = 4527
        Me.MemberCardNoReq.Text = "Ä"
        '
        'FrmStationaryIssueEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(869, 562)
        Me.LogLineTableCsv = "Stock_LOG,Structure_TransFooter_Log"
        Me.LogTableName = "StockHead_Log"
        Me.MainLineTableCsv = "Stock,Structure_TransFooter"
        Me.MainTableName = "StockHead"
        Me.Name = "FrmStationaryIssueEntry"
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

    Private Sub FrmWriteoffBooks_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) = True Then passed = False : Exit Sub
        If AgCL.AgIsDuplicate(Dgl1, CStr(Dgl1.Columns(Col1Item).Index)) = True Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If FunRetStock(.AgSelectedValue(Col1Item, I), mInternalCode) < Val(.Item(Col1Qty, I).Value) Then
                        MsgBox("Current Stock Of " & .Item(Col1Item, I).Value & " Is Less Than " & .Item(Col1Qty, I).Value & ".Can't Proceed", MsgBoxStyle.Information)
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub FrmOtherMaterialTransferIssue_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtFromGodown.AgSelectedValue = RetDefaultGodown(AgL.PubSiteCode, AgL.PubDivCode, ClsMain.ItemType.Book)
    End Sub

    Private Sub FrmYarnSKUOpeningStock_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid

        Dgl1.Columns(Col1Item).HeaderText = "Stationary"
        Dgl1.Columns(Col1Process).Visible = False
        Dgl1.Columns(Col1Status).Visible = False
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False

        Dgl1.Columns(Col1Item).Width = 250
        Dgl1.Columns(Col1Qty).Width = 100
        Dgl1.Columns(Col1Unit).Width = 100
        Dgl1.Columns(Col1Remark).Width = 250
        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0

    End Sub

    Private Sub FrmYarnSKUOpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 596, 885)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
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

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Dim DrTemp As DataRow() = Nothing
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.Stationary & "'  "

        End Select
    End Sub

    Private Sub FrmWriteoffBooks_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0")
    End Sub

    Private Sub FrmStationaryIssueEntry_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = " SELECT SG.SubCode AS Code,SG.DispName ,isnull(SG.IsDeleted,0) AS IsDeleted, SG.Div_Code , " & _
              " isnull(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status " & _
              " FROM Pay_Employee E " & _
              " LEFT JOIN SubGroup SG ON SG.SubCode=E.SubCode " & _
              " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
        TxtOrderBy.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
        TxtIssuedTo.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = TxtOrderBy.AgHelpDataSet.Copy
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtOrderBy.Enter, TxtIssuedTo.Enter
        Try
            Select Case sender.name
                Case TxtOrderBy.Name, TxtIssuedTo.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND " & ClsMain.RetDivFilterStr & ""

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmStationaryIssueEntry_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = " UPDATE StockHead_Log " & _
            " SET " & _
            " SubCode = " & AgL.Chk_Text(TxtIssuedTo.AgSelectedValue) & " " & _
            " Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmStationaryIssueEntry_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From StockHead H " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                " From StockHead_Log H " & _
                " Where H.UID='" & SearchCode & "'"

        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtIssuedTo.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
            End If
        End With
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Stationary Issue"
            RepName = "Lib_StationaryIssue_Print" : RepTitle = "Stationary Issue"
            bCondstr = "WHERE H.DocID='" & mInternalCode & "'"

            strQry = " SELECT H.DocID,H.V_Type,H.V_Prefix,H.V_Date,H.V_No,H.Div_Code,H.Site_Code, " & _
                    " H.SubCode,H.FromProcess,H.ToProcess,H.FromGodown,H.ToGodown,H.TotalQty,H.TotalMeasure, " & _
                    " H.Amount,H.Addition,H.Deduction,H.NetAmount,H.Remarks,SM.Name AS SiteName, " & _
                    " L.Item_UID,L.Item,L.Godown,L.Qty_Iss, L.Unit,L.Remarks AS LineRemark,SG.DispName AS OrderByName,SGI.DispName AS IssuedToName, " & _
                    " I.Description AS ItemDesc  " & _
                    " FROM StockHead H " & _
                    " LEFT JOIN Stock L ON L.DocID=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.OrderBy  " & _
                    " LEFT JOIN SubGroup SGI ON SGI.SubCode=H.SubCode  " & _
                    " LEFT JOIN Item I ON I.Code =L.Item  " & _
                    " LEFT JOIN Voucher_Type Vt ON H.V_Type=Vt.V_Type " & _
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
