Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmWriteoffGenerals
    Inherits TempStockAdjustmentIssue

    Protected Const Col1GeneralId As String = "General Id"
    Protected Const Col1Edition As String = "Edition"

    Friend WithEvents Pnl2 As System.Windows.Forms.Panel
    Friend WithEvents BtnFill As System.Windows.Forms.Button

    Protected WithEvents Dgl2 As New AgControls.AgDataGrid
    Protected Const Col2General As String = "General"
    Protected Const Col2FromDate As String = "From Date"
    Protected Const Col2ToDate As String = "To Date"
    Protected Const Col2Qty As String = "Qty"
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel


    Dim mQry$ = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.WriteOffGenerals
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.BtnFill = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
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
        Me.TxtFromGodown.Location = New System.Drawing.Point(562, 9)
        Me.TxtFromGodown.Size = New System.Drawing.Size(29, 18)
        Me.TxtFromGodown.Visible = False
        '
        'LblFromGodown
        '
        Me.LblFromGodown.Location = New System.Drawing.Point(538, 10)
        Me.LblFromGodown.Size = New System.Drawing.Size(55, 16)
        Me.LblFromGodown.Text = "Godown"
        Me.LblFromGodown.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(4, 553)
        Me.Panel1.Size = New System.Drawing.Size(595, 23)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 191)
        Me.Pnl1.Size = New System.Drawing.Size(595, 362)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Visible = False
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(605, 191)
        Me.TxtRemarks.Size = New System.Drawing.Size(260, 384)
        Me.TxtRemarks.TabIndex = 2
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(317, 174)
        Me.Label30.Visible = False
        '
        'LblFromGodownReq
        '
        Me.LblFromGodownReq.Location = New System.Drawing.Point(605, 14)
        Me.LblFromGodownReq.Visible = False
        '
        'Label33
        '
        Me.Label33.Visible = False
        '
        'LblToGodownReq
        '
        Me.LblToGodownReq.Location = New System.Drawing.Point(558, 12)
        Me.LblToGodownReq.Visible = False
        '
        'TxtToGodown
        '
        Me.TxtToGodown.Location = New System.Drawing.Point(555, 10)
        Me.TxtToGodown.Size = New System.Drawing.Size(25, 18)
        Me.TxtToGodown.Visible = False
        '
        'LblToGodown
        '
        Me.LblToGodown.Location = New System.Drawing.Point(527, 5)
        Me.LblToGodown.Visible = False
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(856, 427)
        Me.PnlCalcGrid.Size = New System.Drawing.Size(11, 116)
        '
        'TxtStructure
        '
        Me.TxtStructure.Location = New System.Drawing.Point(562, 4)
        Me.TxtStructure.Size = New System.Drawing.Size(32, 18)
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(530, 12)
        '
        'LblMaterialPlanForFollowingItems
        '
        Me.LblMaterialPlanForFollowingItems.Location = New System.Drawing.Point(4, 171)
        Me.LblMaterialPlanForFollowingItems.Size = New System.Drawing.Size(114, 19)
        Me.LblMaterialPlanForFollowingItems.Text = "Write Off Items"
        '
        'TxtOrderBy
        '
        Me.TxtOrderBy.Location = New System.Drawing.Point(122, 92)
        Me.TxtOrderBy.Size = New System.Drawing.Size(233, 18)
        Me.TxtOrderBy.TabIndex = 4
        '
        'LblOrderBy
        '
        Me.LblOrderBy.Location = New System.Drawing.Point(8, 94)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(746, 585)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(582, 585)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(415, 585)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 585)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 585)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 581)
        Me.GroupBox1.Size = New System.Drawing.Size(887, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(285, 585)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(10, 74)
        Me.LblV_No.Size = New System.Drawing.Size(83, 16)
        Me.LblV_No.Text = "Write Off No."
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(122, 72)
        Me.TxtV_No.Size = New System.Drawing.Size(233, 18)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(106, 38)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(8, 33)
        Me.LblV_Date.Size = New System.Drawing.Size(90, 16)
        Me.LblV_Date.Text = "Write Off Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(103, 60)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(122, 32)
        Me.TxtV_Date.Size = New System.Drawing.Size(233, 18)
        Me.TxtV_Date.TabIndex = 1
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(10, 56)
        Me.LblV_Type.Size = New System.Drawing.Size(91, 16)
        Me.LblV_Type.Text = "Write Off Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(122, 52)
        Me.TxtV_Type.Size = New System.Drawing.Size(233, 18)
        Me.TxtV_Type.TabIndex = 2
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(106, 18)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(8, 13)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(122, 12)
        Me.TxtSite_Code.Size = New System.Drawing.Size(233, 18)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(533, 5)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(-3, 19)
        Me.TabControl1.Size = New System.Drawing.Size(875, 148)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.Pnl2)
        Me.TP1.Controls.Add(Me.BtnFill)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Size = New System.Drawing.Size(867, 122)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblOrderBy, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblToGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtToGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblFromGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtFromGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtOrderBy, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblFromGodownReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblToGodownReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.BtnFill, 0)
        Me.TP1.Controls.SetChildIndex(Me.Pnl2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(869, 41)
        Me.Topctrl1.TabIndex = 3
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(367, 31)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(497, 79)
        Me.Pnl2.TabIndex = 5
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Location = New System.Drawing.Point(803, 9)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(60, 21)
        Me.BtnFill.TabIndex = 6
        Me.BtnFill.Text = "Fill"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(364, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(129, 15)
        Me.Label1.TabIndex = 732
        Me.Label1.Text = "Journals To Write Off"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(605, 170)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(263, 19)
        Me.LinkLabel1.TabIndex = 804
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Remark"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmWriteoffGenerals
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(869, 626)
        Me.Controls.Add(Me.LinkLabel1)
        Me.LogLineTableCsv = "Stock_LOG,Structure_TransFooter_Log"
        Me.LogTableName = "StockHead_Log"
        Me.MainLineTableCsv = "Stock,Structure_TransFooter"
        Me.MainTableName = "StockHead"
        Me.Name = "FrmWriteoffGenerals"
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
        Me.Controls.SetChildIndex(Me.LblMaterialPlanForFollowingItems, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
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
        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) = True Then passed = False : Exit Sub
    End Sub

    Private Sub FrmOtherMaterialTransferIssue_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtFromGodown.AgSelectedValue = RetDefaultGodown(AgL.PubSiteCode, AgL.PubDivCode, ClsMain.ItemType.Book)
    End Sub

    Private Sub FrmWriteoffBooks_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT Ad.Book_UID AS Code, Ad.Book_UID AS BookId, Ad.Book, Ad.Edition, IsNull(IsInStock,0) As IsInStock FROM Lib_AccessionDetail AD LEFT JOIN Lib_Accession A ON Ad.DocID = A.DocID  Where " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "
        Dgl1.AgHelpDataSet(Col1GeneralId, 3) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Distinct A.Edition AS Code, A.Edition AS Edition " & _
                " FROM Lib_AccessionDetail A LEFT JOIN Lib_Accession Ad ON Ad.DocID = A.DocID  Where A.Edition Is Not Null and " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & " "
        Dgl1.AgHelpDataSet(Col1Edition) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT I.Code, I.Description AS General, I.ItemType " & _
                " FROM Item I "
        Dgl2.AgHelpDataSet(Col2General, , TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Sg.SubCode As Code, Sg.DispName As Name  " & _
                " From Pay_Employee E " & _
                " LEFT JOIN SubGroup Sg On E.SubCode = Sg.SubCode " & _
                " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
        TxtOrderBy.AgHelpDataSet(, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub FrmYarnSKUOpeningStock_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        AgCL.AddAgTextColumn(Dgl1, Col1GeneralId, 70, 0, Col1GeneralId, True, False)
        AgCL.AddAgTextColumn(Dgl1, Col1Edition, 110, 0, Col1Edition, True, False)

        Dgl1.Columns(Col1Edition).DisplayIndex = 3
        Dgl1.Columns(Col1GeneralId).DisplayIndex = 1

        Dgl1.Columns(Col1Item).HeaderText = "General"
        Dgl1.Columns(Col1Item).Width = 160
        Dgl1.Columns(Col1Remark).Width = 180
        Dgl1.Columns(Col1Process).Visible = False
        Dgl1.Columns(Col1Status).Visible = False
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
        Dgl1.Columns(Col1Unit).Visible = False
        Dgl1.Columns(Col1Qty).Visible = False
        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0

        Dgl1.ColumnHeadersHeight = 25

        Dgl2.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl2, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl2, Col2General, 200, 0, Col2General, True, False, False)
            .AddAgDateColumn(Dgl2, Col2FromDate, 80, Col2FromDate, True, False)
            .AddAgDateColumn(Dgl2, Col2ToDate, 80, Col2ToDate, True, False)
            .AddAgNumberColumn(Dgl2, Col2Qty, 40, 5, 0, False, Col2Qty, True, True)
        End With
        AgL.AddAgDataGrid(Dgl2, Pnl2)
        Dgl2.EnableHeadersVisualStyles = False
        Dgl2.ColumnHeadersHeight = 25
        FrmWriteoffBooks_BaseFunction_FIniList()
    End Sub


    Private Sub FrmYarnSKUOpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 660, 877)
        Topctrl1.ChangeAgGridState(Dgl2, False)
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
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.Generals & "' "
        End Select
    End Sub

    Private Sub FrmWriteoffBooks_BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer) Handles Me.BaseFunction_MoveRecLine
        Dim DsTemp As DataSet = Nothing
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select Edition from Stock " & _
                    " Where DocId = '" & SearchCode & "' " & _
                    " And Sr = " & Val(Sr) & "" & _
                    " Order By Sr "
        Else
            mQry = "Select Edition from Stock_Log " & _
                    " Where UID = '" & SearchCode & "' " & _
                    " And Sr = " & Val(Sr) & "" & _
                    " Order By Sr "
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                Dgl1.Item(Col1Edition, mGridRow).Value = AgL.XNull(.Rows(0)("Edition"))
            End If
        End With
    End Sub

    Private Sub FrmWriteoffBooks_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        With Dgl1
            If .Item(Col1Item, mGridRow).Value <> "" Then
                mQry = "UPDATE Stock_Log " & _
                        " SET " & _
                        " Edition = " & AgL.Chk_Text(.Item(Col1Edition, mGridRow).Value) & " " & _
                        " WHERE UID = '" & SearchCode & "' " & _
                        " And Sr = " & Val(Sr) & ""
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If
        End With
    End Sub

    Private Sub FrmWriteoffBooks_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0")
    End Sub

    Private Sub FrmGeneralsWriteoff_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        AgL.GridDesign(Dgl2)
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Dim I As Integer = 0, J As Integer = 0, K As Integer = 0
        Dim DtTemp As DataTable = Nothing
        Try
            For J = 0 To Dgl2.Rows.Count - 1
                If Dgl2.Item(Col2General, J).Value <> "" Then
                    mQry = "SELECT Ad.Book_UID As GeneralId, Ad.Book As Item , Ad.Edition, 1 As Qty " & _
                            " FROM Lib_AccessionDetail Ad " & _
                            " LEFT JOIN Lib_Accession A On Ad.DocId = A.DocId " & _
                            " WHERE A.V_Date BETWEEN '" & Dgl2.Item(Col2FromDate, J).Value & "' AND '" & Dgl2.Item(Col2ToDate, J).Value & "' " & _
                            " And Ad.Book = '" & Dgl2.AgSelectedValue(Col2General, J) & "' " & _
                            " And Ad.IsInStock <> 0 "
                    DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

                    With DtTemp
                        If .Rows.Count > 0 Then
                            If J = 0 Then
                                Dgl1.RowCount = 1
                                Dgl1.Rows.Clear()
                            End If

                            For I = 0 To .Rows.Count - 1
                                Dgl1.Rows.Add()
                                Dgl1.Item(ColSNo, K).Value = Dgl1.Rows.Count - 1
                                Dgl1.Item(Col1GeneralId, K).Value = AgL.XNull(.Rows(I)("GeneralId"))
                                Dgl1.AgSelectedValue(Col1Item, K) = AgL.XNull(.Rows(I)("Item"))
                                Dgl1.Item(Col1Qty, K).Value = AgL.VNull(.Rows(I)("Qty"))
                                Dgl1.Item(Col1Edition, K).Value = AgL.XNull(.Rows(I)("Edition"))
                                K = K + 1
                            Next I
                        End If
                    End With
                End If
            Next
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmWriteoffGenerals_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            BtnFill.Enabled = True
            Dgl2.ReadOnly = False
        Else
            BtnFill.Enabled = False
            Dgl2.ReadOnly = True
        End If
    End Sub

    Private Sub DGL2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl2.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub Dgl2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl2.CellEnter
        Dim DrTemp As DataRow() = Nothing
        If Dgl2.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl2.Columns(Dgl2.CurrentCell.ColumnIndex).Name
            Case Col2General
                Dgl2.AgRowFilter(Dgl2.Columns(Col2General).Index) = " ItemType = '" & ClsMain.ItemType.Generals & "' "
        End Select
    End Sub

    Private Sub FrmWriteoffBooks_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer = 0
        Dim IsInStock As Byte = 0
        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1GeneralId, I).Value <> "" Then

                    mQry = "SELECT IsNull(Sum(S.Qty_Iss),0) " & _
                            " FROM Stock S WITH (NoLock) " & _
                            " LEFT JOIN StockHead Sh  WITH (NoLock) ON Sh.DocID = S.DocID " & _
                            " WHERE S.Item_UID = '" & .Item(Col1GeneralId, I).Value & "' " & _
                            " And IsNull(Sh.IsDeleted,0) = 0 "

                    If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar = 0 Then
                        IsInStock = 1
                    Else
                        IsInStock = 0
                    End If

                    mQry = " UPDATE Lib_AccessionDetail " & _
                            " SET IsInStock = " & Val(IsInStock) & " " & _
                            " Where Book_UID = " & AgL.Chk_Text(.Item(Col1GeneralId, I).Value) & " "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
    End Sub
End Class
