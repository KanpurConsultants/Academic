Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmBookIssueToBranch
    Inherits TempStockTransferIssue

    Protected Const Col1BookId As String = "Book ID"
    Protected Const Col1TempBookId As String = "Temp Book ID"
    Protected Const Col1Writer As String = "Writer"
    Protected Const Col1Publisher As String = "Publisher"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.BranchTransfer
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
        'LblFromGodown
        '
        Me.LblFromSite.Size = New System.Drawing.Size(83, 16)
        Me.LblFromSite.Text = "From Branch"
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(7, 371)
        Me.Panel1.Visible = False
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(7, 204)
        '
        'LblToGodown
        '
        Me.LblToSite.Size = New System.Drawing.Size(67, 16)
        Me.LblToSite.Text = "To Branch"
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(477, 399)
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(895, 4)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(7, 43)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(877, 41)
        '
        'FrmBookIssueToBranch
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(877, 562)
        Me.LogLineTableCsv = "Stock_LOG,StockProcess_LOG,Structure_TransFooter_Log"
        Me.LogTableName = "StockHead_Log"
        Me.MainLineTableCsv = "Stock,StockProcess,Structure_TransFooter"
        Me.MainTableName = "StockHead"
        Me.Name = "FrmBookIssueToBranch"
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

    Private Sub FrmBookIssueToBranch_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer, mSr As Integer
        If 1 = 2 Then

        Else

            With Dgl1
                For I = 0 To .RowCount - 1
                    If .Item(Col1BookId, I).Value <> "" Or .Item(Col1TempBookId, I).Value <> "" Then
                        mSr += 1
                        If .Item(Col1TempBookId, I).Value <> "" Then
                            mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 1 " & _
                                    " WHERE Book_UID = " & AgL.Chk_Text(Dgl1.Item(Col1TempBookId, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                        End If

                        If .Item(Col1BookId, I).Value <> "" Then
                            mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 0 " & _
                                    " WHERE Book_UID = " & AgL.Chk_Text(Dgl1.Item(Col1BookId, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                        End If
                    End If
                Next
            End With

        End If
    End Sub

    Private Sub FrmBookIssueToBranch_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1BookId).Index) = True Then passed = False : Exit Sub
        If AgCL.AgIsDuplicate(Dgl1, CStr(Dgl1.Columns(Col1BookId).Index)) = True Then passed = False : Exit Sub
    End Sub

    Private Sub FrmBookIssueToBranch_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        mQry = "Update stock_log set Item_UID='" & Dgl1.Item(Col1BookId, mGridRow).Value & "' where UID='" & SearchCode & "' and Sr=" & Sr & ""
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmBookIssueToBranch_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        Call IniBookIDHelp(True)


    End Sub

    Private Sub FrmYarnSKUOpeningStock_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.Columns(Col1Item).HeaderText = "Book"
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1MeasureUnit).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False
        Dgl1.Columns(Col1Process).Visible = False
        Dgl1.Columns(Col1Status).Visible = False
        Dgl1.Columns(Col1Qty).Visible = False

        With AgCL
            .AddAgTextColumn(Dgl1, Col1BookId, 140, 20, Col1BookId, True, False)
            .AddAgTextColumn(Dgl1, Col1TempBookId, 140, 20, Col1TempBookId, False, False)
            .AddAgTextColumn(Dgl1, Col1Writer, 160, 100, Col1Writer, True, True)
            .AddAgTextColumn(Dgl1, Col1Publisher, 160, 100, Col1Publisher, True, True)
        End With
        Dgl1.Columns(Col1BookId).DisplayIndex = 1
        Dgl1.Columns(Col1Item).DisplayIndex = 2
        Dgl1.Columns(Col1Writer).DisplayIndex = 3
        Dgl1.Columns(Col1Publisher).DisplayIndex = 4

        CType(Dgl1.Columns(Col1Qty), AgControls.AgTextColumn).AgNumberRightPlaces = 0


        FrmBookIssueToBranch_BaseFunction_FIniList()
    End Sub

    Private Sub FrmBookIssueToBranch_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer = 0
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * from Stock where DocId = '" & SearchCode & "' Order By Sr"
        Else
            mQry = "Select * from Stock_Log where UID = '" & SearchCode & "' Order By Sr"
        End If

        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            Dgl1.RowCount = 1
            Dgl1.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                    Dgl1.Rows.Add()
                    Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                    Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                    Dgl1.AgSelectedValue(Col1Process, I) = AgL.XNull(.Rows(I)("Process"))
                    Dgl1.Item(Col1Status, I).Value = AgL.XNull(.Rows(I)("Status"))
                    Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty_Iss"))
                    Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                    Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                    Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("Measure_Iss"))
                    Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                    Dgl1.Item(Col1Rate, I).Value = AgL.VNull(.Rows(I)("Rate"))
                    Dgl1.Item(Col1Amount, I).Value = AgL.VNull(.Rows(I)("Amount"))
                    Dgl1.Item(Col1BookId, I).Value = AgL.XNull(.Rows(I)("Item_UID"))
                    Dgl1.Item(Col1TempBookId, I).Value = AgL.XNull(.Rows(I)("Item_UID"))
                Next I
            End If
        End With

        For I = 0 To Dgl1.Rows.Count - 1
            Dgl1.Item(Col1Qty, I).Value = Format(Dgl1.Item(Col1Qty, I).Value, "0")
            Validating_BookItem(Dgl1.AgSelectedValue(Col1Item, I), I)
        Next
    End Sub

    Private Sub FrmBookIssueToBranch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 600, 900)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Public Sub IniBookIDHelp(Optional ByVal All_Records As Boolean = True, Optional ByVal bGodownCode As String = "")
        If All_Records = True Then
            mQry = " SELECT A.Book_UID AS Code,A.Book_UID AS [Book ID],I.Description AS [Book Name],A.Book,A.AccessionNo,A.Edition,A.Writer,A.Publisher,A.IsInStock , I.Unit ," & _
                    " IsNull(AH.IsDeleted ,0) AS IsDeleted, AH.Div_Code, ISNULL(AH.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status " & _
                    " FROM Lib_AccessionDetail A " & _
                    " LEFT JOIN Lib_Accession Ad ON Ad.DocID = A.DocID " & _
                    " LEFT JOIN Item I ON I.Code=A.Book  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=I.Code  " & _
                    " LEFT JOIN Lib_Accession AH ON AH.DocID=A.DocId " & _
                    " Where " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & " "
            Dgl1.AgHelpDataSet(Col1BookId, 11) = AgL.FillData(mQry, AgL.GCn)
            Dgl1.AgHelpDataSet(Col1TempBookId, 11) = AgL.FillData(mQry, AgL.GCn)
        Else
            If bGodownCode <> "" Then
                mQry = " SELECT A.Book_UID AS Code,A.Book_UID AS [Book ID],I.Description AS [Book Name],A.Book,A.AccessionNo,A.Edition,A.Writer,A.Publisher,A.IsInStock , I.Unit ," & _
                        " IsNull(AH.IsDeleted ,0) AS IsDeleted, AH.Div_Code, ISNULL(AH.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status " & _
                        " FROM Lib_AccessionDetail A " & _
                        " LEFT JOIN Lib_Accession Ad ON Ad.DocID = A.DocID " & _
                        " LEFT JOIN Item I ON I.Code=A.Book  " & _
                        " LEFT JOIN Lib_Book B ON B.Code=I.Code  " & _
                        " LEFT JOIN Lib_Accession AH ON AH.DocID=A.DocId " & _
                        " Where " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & " "
                Dgl1.AgHelpDataSet(Col1BookId, 11) = AgL.FillData(mQry, AgL.GCn)
            End If
        End If
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND ItemType IN( '" & ClsMain.ItemType.Book & "','" & ClsMain.ItemType.Generals & "') "

            Case Col1BookId
                'If TxtFromSite.AgSelectedValue <> "" Then
                '    IniBookIDHelp(False, TxtFromSite.AgSelectedValue)
                'Else
                '    IniBookIDHelp(True)
                'End If

                If Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex) <> "" And Dgl1.AgSelectedValue(Col1BookId, Dgl1.CurrentCell.RowIndex) = "" Then
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1BookId).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "'  " & _
                        " AND Book =" & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex)) & " AND (IsInStock = 1 OR Code=" & AgL.Chk_Text(Dgl1.Item(Col1BookId, Dgl1.CurrentCell.RowIndex).Value) & ")"
                Else
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1BookId).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "'  " & _
                        " AND (IsInStock = 1 OR Code=" & AgL.Chk_Text(Dgl1.Item(Col1BookId, Dgl1.CurrentCell.RowIndex).Value) & ")"
                End If


        End Select
    End Sub

    Private Sub Validating_BookId(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1BookId, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1BookId, mRow).ToString.Trim = "" Then
                Dgl1.AgSelectedValue(Col1Item, mRow) = ""
                Dgl1.Item(Col1Writer, mRow).Value = ""
                Dgl1.Item(Col1Publisher, mRow).Value = ""
                Dgl1.Item(Col1Unit, mRow).Value = ""
                Dgl1.Item(Col1Qty, mRow).Value = 0
            Else
                If Dgl1.AgHelpDataSet(Col1BookId) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1BookId).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.AgSelectedValue(Col1Item, mRow) = AgL.XNull(DrTemp(0)("Book"))
                    Dgl1.Item(Col1Writer, mRow).Value = AgL.XNull(DrTemp(0)("Writer"))
                    Dgl1.Item(Col1Publisher, mRow).Value = AgL.XNull(DrTemp(0)("Publisher"))
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
                    Dgl1.Item(Col1Qty, mRow).Value = 1
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Shadows Sub Validating_BookItem(ByVal Code As String, ByVal mRow As Integer)
        Dim mQry As String
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = " SELECT B.Writer,B.Publisher   FROM Lib_Book B " & _
                    " WHERE B.Code = '" & Code & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1Writer, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Writer"))
                Dgl1.Item(Col1Publisher, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Publisher"))
            Else
                Dgl1.Item(Col1Writer, mRow).Value = ""
                Dgl1.Item(Col1Publisher, mRow).Value = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
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
                Case Col1BookId
                    Validating_BookId(Dgl1.AgSelectedValue(Col1BookId, mRowIndex), mRowIndex)

                Case Col1Item
                    Validating_BookItem(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Book Issue To Branch"
            RepName = "Lib_BookTransfer_Print" : RepTitle = "Book Issue To Branch"
            bCondstr = "WHERE H.DocID='" & mInternalCode & "'"

            strQry = " SELECT H.DocID,H.V_Type,H.V_Prefix,H.V_Date,H.V_No,H.Div_Code,H.Site_Code, " & _
                    " H.SubCode,H.FromProcess,H.ToProcess,H.FromGodown,H.ToGodown,H.TotalQty,H.TotalMeasure, " & _
                    " H.Amount,H.Addition,H.Deduction,H.NetAmount,H.Remarks,SM.Name AS SiteName, " & _
                    " L.Item_UID,L.Item,L.Godown,L.Unit,L.Remarks AS LineRemark,SG.DispName AS OrderByName, " & _
                    " I.Description AS ItemDesc,B.Writer ,B.Publisher , " & _
                    " GF.Description AS FromGoodownDesc ,GT.Description AS ToGoodownDesc " & _
                    " FROM StockHead H " & _
                    " LEFT JOIN Stock L ON L.DocID=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.OrderBy  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=L.Item  " & _
                    " LEFT JOIN Item I ON I.Code =L.Item  " & _
                    " LEFT JOIN Godown GF ON GF.Code=H.FromGodown  " & _
                    " LEFT JOIN Godown GT ON GT.Code=H.ToGodown  " & _
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



    Private Sub FrmBookIssueToBranch_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        Dim I As Integer, mSr As Integer

        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1BookId, I).Value <> "" Then
                    mSr += 1
                    If .AgSelectedValue(Col1TempBookId, I) <> "" Then
                        mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 1 " & _
                                " WHERE Book_UID = " & AgL.Chk_Text(Dgl1.Item(Col1TempBookId, I).Value) & " "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    End If
                End If
            Next
        End With

    End Sub
End Class
