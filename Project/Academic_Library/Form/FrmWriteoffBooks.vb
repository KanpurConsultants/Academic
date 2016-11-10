Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmWriteoffBooks
    Inherits TempStockAdjustmentIssue
    Protected Const Col1AccessionNo As String = "Accession No"
    Protected Const Col1BookId As String = "Book Id"
    Protected Const Col1Edition As String = "Edition"
    Protected Const Col1Writer As String = "Writer"
    Protected Const Col1Publisher As String = "Publisher"
    Protected Const Col1BookIdX As String = "Book IdX"

    Dim mQry$ = ""


    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.WriteOffBooks
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
        'TxtFromGodown
        '
        Me.TxtFromGodown.Location = New System.Drawing.Point(802, 25)
        Me.TxtFromGodown.Size = New System.Drawing.Size(40, 18)
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
        Me.Pnl1.Location = New System.Drawing.Point(4, 195)
        Me.Pnl1.Size = New System.Drawing.Size(863, 176)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Visible = False
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(4, 415)
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
        Me.LblMaterialPlanForFollowingItems.Location = New System.Drawing.Point(4, 175)
        Me.LblMaterialPlanForFollowingItems.Size = New System.Drawing.Size(114, 19)
        Me.LblMaterialPlanForFollowingItems.Text = "Write Off Items"
        '
        'TxtOrderBy
        '
        Me.TxtOrderBy.Location = New System.Drawing.Point(264, 59)
        Me.TxtOrderBy.Size = New System.Drawing.Size(429, 18)
        '
        'LblOrderBy
        '
        Me.LblOrderBy.Location = New System.Drawing.Point(150, 61)
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(887, 4)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(394, 40)
        Me.LblV_No.Size = New System.Drawing.Size(83, 16)
        Me.LblV_No.Text = "Write Off No."
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(506, 38)
        Me.TxtV_No.Size = New System.Drawing.Size(187, 18)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(248, 45)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(150, 40)
        Me.LblV_Date.Size = New System.Drawing.Size(90, 16)
        Me.LblV_Date.Text = "Write Off Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(487, 25)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(264, 39)
        Me.TxtV_Date.Size = New System.Drawing.Size(120, 18)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(394, 21)
        Me.LblV_Type.Size = New System.Drawing.Size(91, 16)
        Me.LblV_Type.Text = "Write Off Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(506, 17)
        Me.TxtV_Type.Size = New System.Drawing.Size(187, 18)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(248, 25)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(150, 20)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(264, 19)
        Me.TxtSite_Code.Size = New System.Drawing.Size(120, 18)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(-3, 42)
        Me.TabControl1.Size = New System.Drawing.Size(875, 125)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(867, 99)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(869, 41)
        '
        'FrmWriteoffBooks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(869, 562)
        Me.LogLineTableCsv = "Stock_LOG,Structure_TransFooter_Log"
        Me.LogTableName = "StockHead_Log"
        Me.MainLineTableCsv = "Stock,Structure_TransFooter"
        Me.MainTableName = "StockHead"
        Me.Name = "FrmWriteoffBooks"
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
        If AgCL.AgIsDuplicate(Dgl1, CStr(Dgl1.Columns(Col1Item).Index) + "," + CStr(Dgl1.Columns(Col1BookId).Index)) = True Then passed = False : Exit Sub
    End Sub

    Private Sub FrmOtherMaterialTransferIssue_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtFromGodown.AgSelectedValue = RetDefaultGodown(AgL.PubSiteCode, AgL.PubDivCode, ClsMain.ItemType.Book)
    End Sub

    Private Sub FrmWriteoffBooks_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT A.Book_UID AS Code, A.Book_UID AS BookId, A.AccessionNo AS [Accession No],  " & _
                " A.Book, A.Edition, IsNull(A.IsInStock,0) As IsInStock " & _
                " FROM Lib_AccessionDetail A " & _
                " LEFT JOIN Lib_Accession Ad ON Ad.DocID = A.DocID " & _
                " Where " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & " "
        Dgl1.AgHelpDataSet(Col1BookId, 3) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT A.Book_UID AS Code, A.AccessionNo AS [Accession No], A.Book_UID AS BookId,  " & _
                " A.Book, A.Edition, IsNull(A.IsInStock,0) As IsInStock " & _
                " FROM Lib_AccessionDetail A " & _
                " LEFT JOIN Lib_Accession Ad ON Ad.DocID = A.DocID " & _
                " Where " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & " "
        Dgl1.AgHelpDataSet(Col1AccessionNo, 3) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Distinct A.Edition AS Code, A.Edition AS Edition " & _
                " FROM Lib_AccessionDetail A " & _
                " LEFT JOIN Lib_Accession Ad ON Ad.DocID = A.DocID " & _
                " Where A.Edition Is Not Null and " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & ""
        Dgl1.AgHelpDataSet(Col1Edition) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Sg.SubCode As Code, Sg.DispName As Name  " & _
                " From Pay_Employee E " & _
                " LEFT JOIN SubGroup Sg On E.SubCode = Sg.SubCode " & _
                " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
        TxtOrderBy.AgHelpDataSet(, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

    End Sub


    Private Sub FrmYarnSKUOpeningStock_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        AgCL.AddAgTextColumn(Dgl1, Col1AccessionNo, 80, 20, Col1AccessionNo, True, False)
        AgCL.AddAgTextColumn(Dgl1, Col1BookId, 80, 0, Col1BookId, True, False)
        AgCL.AddAgTextColumn(Dgl1, Col1Edition, 60, 0, Col1Edition, True, False)
        AgCL.AddAgTextColumn(Dgl1, Col1Writer, 120, 0, Col1Writer, True, True)
        AgCL.AddAgTextColumn(Dgl1, Col1Publisher, 150, 0, Col1Publisher, True, True)
        AgCL.AddAgTextColumn(Dgl1, Col1BookIdX, 80, 0, Col1BookIdX, False, False)

        Dgl1.Columns(Col1AccessionNo).DisplayIndex = 1
        Dgl1.Columns(Col1BookId).DisplayIndex = 2
        Dgl1.Columns(Col1Edition).DisplayIndex = 4
        Dgl1.Columns(Col1Writer).DisplayIndex = 5
        Dgl1.Columns(Col1Publisher).DisplayIndex = 6

        Dgl1.Columns(Col1Item).HeaderText = "Book Title"
        Dgl1.Columns(Col1Process).Visible = False
        Dgl1.Columns(Col1Status).Visible = False
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
        Dgl1.Columns(Col1Unit).Visible = False
        Dgl1.Columns(Col1Qty).Visible = False
        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0

        FrmWriteoffBooks_BaseFunction_FIniList()
    End Sub

    Private Sub FrmYarnSKUTransferIssue_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim i As Integer = 0
        For i = 0 To Dgl1.Rows.Count - 1
            ValidatingBook_Item(Dgl1.AgSelectedValue(Col1Item, i), i)
        Next
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
                Case Col1AccessionNo
                    If Dgl1.Item(Col1AccessionNo, mRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1AccessionNo, mRowIndex).ToString.Trim = "" Then
                        Dgl1.AgSelectedValue(Col1AccessionNo, mRowIndex) = ""
                        Dgl1.AgSelectedValue(Col1Item, mRowIndex) = ""
                        Dgl1.AgSelectedValue(Col1BookId, mRowIndex) = ""
                        Dgl1.Item(Col1Edition, mRowIndex).Value = ""
                    Else
                        If Dgl1.AgHelpDataSet(Col1AccessionNo) IsNot Nothing Then
                            DrTemp = Dgl1.AgHelpDataSet(Col1AccessionNo).Tables(0).Select("Code = '" & Dgl1.AgSelectedValue(Col1AccessionNo, mRowIndex) & "'")
                            Dgl1.AgSelectedValue(Col1BookId, mRowIndex) = AgL.XNull(DrTemp(0)("Code"))
                            Dgl1.AgSelectedValue(Col1Item, mRowIndex) = AgL.XNull(DrTemp(0)("Book"))
                            Dgl1.Item(Col1Edition, mRowIndex).Value = AgL.XNull(DrTemp(0)("Edition"))
                            Dgl1.Item(Col1Qty, mRowIndex).Value = 1
                            ValidatingBook_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
                        End If
                    End If

                Case Col1BookId
                    If Dgl1.Item(Col1BookId, mRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1BookId, mRowIndex).ToString.Trim = "" Then
                        Dgl1.AgSelectedValue(Col1Item, mRowIndex) = ""
                        Dgl1.Item(Col1Edition, mRowIndex).Value = ""
                    Else
                        If Dgl1.AgHelpDataSet(Col1BookId) IsNot Nothing Then
                            DrTemp = Dgl1.AgHelpDataSet(Col1BookId).Tables(0).Select("Code = '" & Dgl1.Item(Col1BookId, mRowIndex).Value & "'")

                            If AgL.XNull(Dgl1.Item(Col1AccessionNo, mRowIndex).Value).ToString.Trim = "" Then
                                Dgl1.AgSelectedValue(Col1AccessionNo, mRowIndex) = AgL.XNull(DrTemp(0)("Code"))
                            End If
                            Dgl1.AgSelectedValue(Col1Item, mRowIndex) = AgL.XNull(DrTemp(0)("Book"))
                            Dgl1.Item(Col1Edition, mRowIndex).Value = AgL.XNull(DrTemp(0)("Edition"))
                            Dgl1.Item(Col1Qty, mRowIndex).Value = 1
                            ValidatingBook_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
                        End If
                    End If

                Case Col1Item
                    ValidatingBook_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
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
                If Dgl1.Item(Col1BookId, Dgl1.CurrentCell.RowIndex).Value <> "" Then
                    If Dgl1.AgHelpDataSet(Col1BookId) IsNot Nothing Then
                        DrTemp = Dgl1.AgHelpDataSet(Col1BookId).Tables(0).Select("Code = '" & Dgl1.Item(Col1BookId, Dgl1.CurrentCell.RowIndex).Value & "'")
                        Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.Book & "' And Code = '" & AgL.XNull(DrTemp(0)("Book")) & "'   "
                    End If
                Else
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType = '" & ClsMain.ItemType.Book & "'  "
                End If

            Case Col1AccessionNo
                If Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex) <> "" Then
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1AccessionNo).Index) = " Book = '" & Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex) & "' And (IsInStock <> 0 Or Code = '" & Dgl1.Item(Col1BookIdX, Dgl1.CurrentCell.RowIndex).Value & "')  "
                Else
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1AccessionNo).Index) = " (IsInStock <> 0  Or Code = '" & Dgl1.Item(Col1BookIdX, Dgl1.CurrentCell.RowIndex).Value & "') "
                End If

            Case Col1BookId
                If Dgl1.AgSelectedValue(Col1AccessionNo, Dgl1.CurrentCell.RowIndex) <> "" Then
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1BookId).Index) = " Code = '" & Dgl1.AgSelectedValue(Col1AccessionNo, Dgl1.CurrentCell.RowIndex) & "' And (IsInStock <> 0 Or Code = '" & Dgl1.Item(Col1BookIdX, Dgl1.CurrentCell.RowIndex).Value & "')  "
                Else
                    If Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex) <> "" Then
                        Dgl1.AgRowFilter(Dgl1.Columns(Col1BookId).Index) = " Book = '" & Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex) & "' And (IsInStock <> 0 Or Code = '" & Dgl1.Item(Col1BookIdX, Dgl1.CurrentCell.RowIndex).Value & "')  "
                    Else
                        Dgl1.AgRowFilter(Dgl1.Columns(Col1BookId).Index) = " (IsInStock <> 0  Or Code = '" & Dgl1.Item(Col1BookIdX, Dgl1.CurrentCell.RowIndex).Value & "') "
                    End If
                End If

            Case Col1Edition
                If Dgl1.Item(Col1BookId, Dgl1.CurrentCell.RowIndex).Value <> "" Then
                    If Dgl1.AgHelpDataSet(Col1BookId) IsNot Nothing Then
                        DrTemp = Dgl1.AgHelpDataSet(Col1BookId).Tables(0).Select("Code = '" & Dgl1.Item(Col1BookId, Dgl1.CurrentCell.RowIndex).Value & "'")
                        Dgl1.AgRowFilter(Dgl1.Columns(Col1Edition).Index) = " Code = '" & AgL.XNull(DrTemp(0)("Edition")) & "'  "
                    End If
                Else
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Edition).Index) = ""
                End If
        End Select
    End Sub

    Private Shadows Sub ValidatingBook_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim mQry As String = ""
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = "SELECT A.Writer, A.Publisher " & _
                    " FROM Lib_AccessionDetail A " & _
                    " Where Book = '" & Code & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1Writer, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Writer"))
                Dgl1.Item(Col1Publisher, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Publisher"))
            Else
                Dgl1.Item(Col1Writer, mRow).Value = ""
                Dgl1.Item(Col1Publisher, mRow).Value = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function (" & Me.Name & ") ")
        End Try
    End Sub

    Private Sub FrmWriteoffBooks_BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer) Handles Me.BaseFunction_MoveRecLine
        Dim DsTemp As DataSet = Nothing
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select Item_UID, Edition from Stock " & _
                    " Where DocId = '" & SearchCode & "' " & _
                    " And Sr = " & Val(Sr) & "" & _
                    " Order By Sr "
        Else
            mQry = "Select Item_UID, Edition from Stock_Log " & _
                    " Where UID = '" & SearchCode & "' " & _
                    " And Sr = " & Val(Sr) & "" & _
                    " Order By Sr "
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                Dgl1.AgSelectedValue(Col1AccessionNo, mGridRow) = AgL.XNull(.Rows(0)("Item_UID"))
                Dgl1.Item(Col1BookId, mGridRow).Value = AgL.XNull(.Rows(0)("Item_UID"))
                Dgl1.Item(Col1Edition, mGridRow).Value = AgL.XNull(.Rows(0)("Edition"))
                Dgl1.Item(Col1BookIdX, mGridRow).Value = AgL.XNull(.Rows(0)("Item_UID"))
            End If
        End With
    End Sub

    Private Sub FrmWriteoffBooks_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        With Dgl1
            If .Item(Col1Item, mGridRow).Value <> "" Then
                mQry = "UPDATE Stock_Log " & _
                        " SET " & _
                        " Edition = " & AgL.Chk_Text(.Item(Col1Edition, mGridRow).Value) & ", " & _
                        " Item_UID = " & AgL.Chk_Text(.Item(Col1BookId, mGridRow).Value) & " " & _
                        " WHERE UID = '" & SearchCode & "' " & _
                        " And Sr = " & Val(Sr) & ""
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If
        End With
    End Sub

    Private Sub FrmWriteoffBooks_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer = 0
        Dim IsInStock As Byte = 0
        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1BookId, I).Value <> "" Then

                    mQry = "SELECT IsNull(Sum(S.Qty_Iss),0) " & _
                            " FROM Stock S WITH (NoLock) " & _
                            " LEFT JOIN StockHead Sh  WITH (NoLock) ON Sh.DocID = S.DocID " & _
                            " WHERE S.Item_UID = '" & .Item(Col1BookId, I).Value & "' " & _
                            " And IsNull(Sh.IsDeleted,0) = 0 "

                    If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar = 0 Then
                        IsInStock = 1
                    Else
                        IsInStock = 0
                    End If

                    mQry = " UPDATE Lib_AccessionDetail " & _
                            " SET IsInStock = " & Val(IsInStock) & " " & _
                            " Where Book_UID = " & AgL.Chk_Text(.Item(Col1BookId, I).Value) & " "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmWriteoffBooks_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0")
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try
            mQry = " Select Count(*) From Lib_BookIssue H Where H.WriteOffDocId = '" & TxtDocId.Text & "'"
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                MsgBox("Write Off Is Created For Replacement.Can't Modify Entry!", MsgBoxStyle.Exclamation)
                FGetRelationalData = True
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub TempPurchInvoiceCommon_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub TempPurchInvoiceCommon_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub
End Class
