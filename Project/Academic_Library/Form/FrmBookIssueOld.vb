Public Class FrmBookIssueOld
    Inherits TempBookIssue
    Public WithEvents Dgl2 As New AgControls.AgDataGrid
    Protected Const Col2IssueDocId As String = "IssueDocId"
    Protected Const Col2Received As String = "Received"
    Protected Const Col2Status As String = "Status"
    Protected Const Col2AccessionNo As String = "Accession No"
    Protected Const Col2BookId As String = "Book ID"
    Protected Const Col2TempBookId As String = "Temp Book ID"
    Protected Const Col2Book As String = "Book"
    Protected Const Col2Writer As String = "Writer"
    Protected Const Col2Publisher As String = "Publisher"
    Protected Const Col2Edition As String = "Edition"
    Protected Const Col2Qty As String = "Qty"
    Protected Const Col2Unit As String = "Unit"
    Protected Const Col2ForDays As String = "For Days"
    Protected Const Col2DateToReturn As String = "Date To Return"
    Protected Const Col2DateofReturn As String = "Date of Return"
    Protected Const Col2FinePerDay As String = "Fine / Day"
    Protected Const Col2FineAmount As String = "Fine Amount"
    Protected Const Col2Remark As String = "Remark"

    Protected Const Status_Received As String = "Received"
    Protected Const Status_Lost As String = "Lost"
    Protected Const Status_Replaced As String = "Replaced"

    Protected WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Pnl2 As System.Windows.Forms.Panel

    Dim mMemberCardNo$ = ""

    Public Property MemberCardNo() As String
        Get
            MemberCardNo = mMemberCardNo
        End Get
        Set(ByVal value As String)
            mMemberCardNo = value
        End Set
    End Property

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.BookIssueReceive
    End Sub

    Private Sub InitializeComponent()
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
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
        'TxtMemberName
        '
        Me.TxtMemberName.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(8, 548)
        Me.Panel1.Size = New System.Drawing.Size(864, 21)
        Me.Panel1.Visible = True
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(11, 228)
        Me.Pnl1.Size = New System.Drawing.Size(861, 147)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.TabIndex = 9
        '
        'LblTotalQty
        '
        Me.LblTotalQty.Visible = False
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 205)
        '
        'TxtMemberCardNo
        '
        '
        'TxtMemberType
        '
        Me.TxtMemberType.TabIndex = 5
        '
        'LblMemberType
        '
        Me.LblMemberType.Location = New System.Drawing.Point(479, 51)
        '
        'TxtApplicationNo
        '
        Me.TxtApplicationNo.Location = New System.Drawing.Point(13, 109)
        Me.TxtApplicationNo.Visible = False
        '
        'LblApplicationNo
        '
        Me.LblApplicationNo.Location = New System.Drawing.Point(17, 92)
        Me.LblApplicationNo.Visible = False
        '
        'TxtTransactionBy
        '
        Me.TxtTransactionBy.Location = New System.Drawing.Point(322, 90)
        Me.TxtTransactionBy.Size = New System.Drawing.Size(410, 18)
        Me.TxtTransactionBy.TabIndex = 7
        '
        'LblTransactionBy
        '
        Me.LblTransactionBy.Location = New System.Drawing.Point(168, 92)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Location = New System.Drawing.Point(766, 2)
        '
        'LblTotalMeasureTextReq
        '
        Me.LblTotalMeasureTextReq.Location = New System.Drawing.Point(655, 2)
        Me.LblTotalMeasureTextReq.Size = New System.Drawing.Size(80, 16)
        Me.LblTotalMeasureTextReq.Text = "Total Fine :"
        '
        'TxtMemberRemark
        '
        Me.TxtMemberRemark.TabIndex = 8
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(748, 575)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(594, 575)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(421, 575)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(145, 575)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(11, 575)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 571)
        Me.GroupBox1.Size = New System.Drawing.Size(895, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(287, 575)
        '
        'TabControl1
        '
        Me.TabControl1.Size = New System.Drawing.Size(874, 186)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(866, 160)
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Topctrl1.Size = New System.Drawing.Size(877, 41)
        Me.Topctrl1.TabIndex = 3
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(11, 401)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(860, 146)
        Me.Pnl2.TabIndex = 2
        '
        'LinkLabel2
        '
        Me.LinkLabel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Location = New System.Drawing.Point(8, 378)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(118, 20)
        Me.LinkLabel2.TabIndex = 733
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Book Return Detail"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmBookIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(877, 616)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Pnl2)
        Me.LogLineTableCsv = "Lib_BookIssueDetail_Log,Stock_Log"
        Me.LogTableName = "Lib_BookIssue_Log"
        Me.MainLineTableCsv = "Lib_BookIssueDetail,Stock"
        Me.MainTableName = "Lib_BookIssue"
        Me.Name = "FrmBookIssue"
        Me.Text = "Book Issue"
        Me.Controls.SetChildIndex(Me.Pnl2, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel2, 0)
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

    Private Sub FrmBookIssue_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer, mSr As Integer
        If 1 = 2 Then
        Else
            With Dgl2
                For I = 0 To .RowCount - 1
                    If .Item(Col2BookId, I).Value <> "" Or .Item(Col2TempBookId, I).Value <> "" Then
                        mSr += 1
                        If .Item(Col2TempBookId, I).Value <> "" Then
                            mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 0 " & _
                                    " WHERE Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2TempBookId, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                        End If

                        If .Item(Col2BookId, I).Value <> "" Then
                            mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 1 " & _
                                    " WHERE Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2BookId, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                        End If
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub FrmBookIssue_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        Dim I As Integer, mSr As Integer

        With Dgl2
            For I = 0 To .RowCount - 1
                If .Item(Col2BookId, I).Value <> "" Then
                    mSr += 1
                    If .Item(Col2TempBookId, I).Value <> "" Then
                        mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 0 " & _
                                " WHERE Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2TempBookId, I).Value) & " "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    End If
                End If
            Next
        End With

    End Sub

    Private Sub FrmBookIssue_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer
        Dim bBookReceiveCount As Integer
        Dim bDtTemp As DataTable = Nothing

        bBookReceiveCount = 0

        TxtApplicationNo.AgSelectedValue = ""
        If AgL.RequiredField(TxtMemberCardNo, LblMemberCardNo.Text) Then passed = False : Exit Sub




        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1BookId, I).Value <> "" Then
                    bBookReceiveCount += 1
                End If
            Next
        End With
        mQry = "SELECT M.IssueLockFromDate, M.IssueLockTillDate, M.IssueLockReason " & _
                " FROM Lib_Member M With (NoLock) " & _
                " WHERE M.SubCode = " & AgL.Chk_Text(TxtMemberCardNo.AgSelectedValue) & " "
        bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
        If bDtTemp.Rows.Count > 0 Then
            If bBookReceiveCount > 0 Then
                If TxtV_Date.Text.Trim <> "" _
                    And AgL.XNull(bDtTemp.Rows(0)("IssueLockFromDate")).ToString.Trim <> "" _
                    And AgL.XNull(bDtTemp.Rows(0)("IssueLockTillDate")).ToString.Trim <> "" Then

                    If CDate(TxtV_Date.Text) >= CDate(AgL.XNull(bDtTemp.Rows(0)("IssueLockFromDate")).ToString) _
                        And CDate(TxtV_Date.Text) <= CDate(AgL.XNull(bDtTemp.Rows(0)("IssueLockTillDate")).ToString) Then

                        MsgBox("Issue Is Lock Is Locked Due To : " & vbCrLf & AgL.XNull(bDtTemp.Rows(0)("IssueLockReason")) & "")
                        TxtV_Date.Focus()
                        passed = False : Exit Sub
                    End If
                End If
            End If
        End If


        With Dgl2
            For I = 0 To .RowCount - 1
                If .Item(Col2BookId, I).Value <> "" And Dgl2.Item(Col2Received, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                    bBookReceiveCount += 1
                End If
            Next
        End With

        If bBookReceiveCount < 1 Then
            MsgBox("No Transaction Data in Grid")
            passed = False : Exit Sub
        End If

        If Val(LblTotalQty.Text) > Val(LblMemberType.Tag) Then
            MsgBox("Books Issued To " & TxtMemberName.Text & " Exceeds the limit Allowed To him.")
            passed = False : Exit Sub
        End If
    End Sub

    Private Sub FrmBookIssue_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        AgL.GridDesign(Dgl2)
    End Sub

    Private Sub FrmBookIssue_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim StructDue As ClsMain.Dues = Nothing
        Dim I As Integer, mSr As Integer
        With Dgl2
            For I = 0 To .RowCount - 1
                If .Item(Col2BookId, I).Value <> "" And Dgl2.Item(Col2Received, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                    mSr += 1
                    mMainSr += 1
                    mQry = " UPDATE Lib_BookIssueDetail " & _
                            " SET ReturnDocId = " & AgL.Chk_Text(mInternalCode) & " , " & _
                            " ReturnDate = " & AgL.ConvertDate(Dgl2.Item(Col2DateofReturn, I).Value.ToString) & ", " & _
                            " Status = " & AgL.Chk_Text(Dgl2.Item(Col2Status, I).Value) & ", " & _
                            " FinePerDay = " & Val(Dgl2.Item(Col2FinePerDay, I).Value) & ", " & _
                            " FineAmount = " & Val(Dgl2.Item(Col2FineAmount, I).Value) & ", " & _
                            " Remarks = " & AgL.Chk_Text(Dgl2.Item(Col2Remark, I).Value) & " " & _
                            " WHERE DocId = " & AgL.Chk_Text(Dgl2.Item(Col2IssueDocId, I).Value) & "  " & _
                            " AND Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2BookId, I).Value) & " "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                    mQry = " INSERT INTO Stock_Log (DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, " & _
                            " Site_Code, SubCode, Item, Qty_Rec, Unit, Remarks, Edition,UID ) " & _
                            " VALUES (" & AgL.Chk_Text(mInternalCode) & ", " & mMainSr & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                            " " & AgL.Chk_Text(LblPrefix.Text) & ", " & AgL.ConvertDate(TxtV_Date.Text) & ",  " & _
                            " " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(AgL.PubDivCode) & ", " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                            " " & AgL.Chk_Text(TxtTransactionBy.AgSelectedValue) & ", " & AgL.Chk_Text(Dgl2.AgSelectedValue(Col2Book, I)) & ", " & Val(Dgl2.Item(Col2Qty, I).Value) & ",  " & _
                            " " & AgL.Chk_Text(Dgl2.Item(Col2Unit, I).Value) & ", " & AgL.Chk_Text(TxtRemarks.Text) & ", " & AgL.Chk_Text(Dgl2.Item(Col2Edition, I).Value) & "," & AgL.Chk_Text(mSearchCode) & "  ) "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


                End If
            Next
        End With

        If Val(LblTotalMeasure.Text) > 0 Then
            With StructDue
                .DocID = mInternalCode
                .Sr = 1
                .V_Type = TxtV_Type.AgSelectedValue
                .V_Prefix = LblPrefix.Text
                .V_Date = TxtV_Date.Text
                .V_No = Val(TxtV_No.Text)
                .Div_Code = TxtDivision.AgSelectedValue
                .Site_Code = TxtSite_Code.AgSelectedValue
                .SubCode = TxtMemberCardNo.AgSelectedValue
                .Narration = ""
                .ReceivableAmount = LblTotalMeasure.Text
                .AdjustedAmount = 0
                .EntryBy = AgL.PubUserName
                .EntryDate = AgL.GetDateTime(AgL.GcnRead)
                .EntryType = Topctrl1.Mode
                .EntryStatus = LogStatus.LogOpen
                .IsDeleted = 0
                .Status = TxtStatus.Text
                .UID = mSearchCode
            End With
            Call ClsMain.ProcPostInDues(Conn, Cmd, StructDue)
        End If


    End Sub

    Private Sub FrmBookIssue_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
        LblTotalMeasure.Text = 0 : LblTotalQty.Text = 0
    End Sub

    Private Sub FrmBookIssue_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer
        Dim bLateDays As Double

        LblTotalQty.Text = 0 : LblTotalMeasure.Text = 0

        For I = 0 To Dgl2.RowCount - 1
            bLateDays = 0
            If Dgl2.Item(Col2BookId, I).Value <> "" And Dgl2.Item(Col2Received, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                If Dgl2.Item(Col2DateToReturn, I).Value <> "" And Dgl2.Item(Col2DateofReturn, I).Value <> "" Then
                    If CDate(Dgl2.Item(Col2DateToReturn, I).Value) < CDate(Dgl2.Item(Col2DateofReturn, I).Value) Then
                        bLateDays = DateDiff(DateInterval.Day, CDate(Dgl2.Item(Col2DateToReturn, I).Value), CDate(Dgl2.Item(Col2DateofReturn, I).Value))
                    End If
                End If
            End If
            If Val(Dgl2.Item(Col2FineAmount, I).Value) = 0 Then
                Dgl2.Item(Col2FineAmount, I).Value = bLateDays * Val(Dgl2.Item(Col2FinePerDay, I).Value)
            End If
            LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl2.Item(Col2FineAmount, I).Value)
            LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl2.Item(Col2Qty, I).Value)
        Next

        LblTotalMeasure.Text = Format(Val(LblTotalMeasure.Text), "0.000")
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")

    End Sub

    Private Sub FrmBookIssue_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup ,B.Writer,B.Publisher,B.BookType, " & _
                " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, I.Measure, MeasureUnit " & _
                " FROM Item I" & _
                " LEFT JOIN Lib_Book B ON B.Code=I.Code "
        Dgl2.AgHelpDataSet(Col2Book, 11) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT " & AgL.Chk_Text(Status_Received) & " AS Code, " & AgL.Chk_Text(Status_Received) & " AS Name " & _
                " UNION ALL " & _
                " SELECT " & AgL.Chk_Text(Status_Replaced) & " AS Code, " & AgL.Chk_Text(Status_Replaced) & " AS Name " & _
                " UNION ALL " & _
                " SELECT " & AgL.Chk_Text(Status_Lost) & " AS Code, " & AgL.Chk_Text(Status_Lost) & " AS Name "
        Dgl2.AgHelpDataSet(Col2Status, 0) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmBookIssue_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        LblV_No.Text = "Entry No."
        LblV_Date.Text = "Entry Date"
        LblV_Type.Text = "Entry Type"

        Dgl2.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl2, ColSNo, 35, 5, ColSNo, False, True, False)
            .AddAgTextColumn(Dgl2, Col2IssueDocId, 100, 21, Col2IssueDocId, False, False)
            .AddAgCheckColumn(Dgl2, Col2Received, 60, Col2Received, True)
            .AddAgTextColumn(Dgl2, Col2Status, 100, 15, Col2Status, True, False, False)
            .AddAgTextColumn(Dgl2, Col2AccessionNo, 100, 20, Col2AccessionNo, True, True)
            .AddAgTextColumn(Dgl2, Col2BookId, 100, 20, Col2BookId, True, True)
            .AddAgTextColumn(Dgl2, Col2TempBookId, 100, 20, Col2TempBookId, False, True)
            .AddAgTextColumn(Dgl2, Col2Book, 170, 0, Col2Book, True, True)
            .AddAgTextColumn(Dgl2, Col2Edition, 80, 20, Col2Edition, True, True)
            .AddAgNumberColumn(Dgl2, Col2Qty, 50, 5, 0, False, Col2Qty, False, True, True)
            .AddAgTextColumn(Dgl2, Col2Unit, 80, 20, Col2Unit, False, False)
            .AddAgNumberColumn(Dgl2, Col2ForDays, 50, 5, 0, False, Col2ForDays, True, True, True)
            .AddAgDateColumn(Dgl2, Col2DateToReturn, 80, Col2DateToReturn, True, True)
            .AddAgDateColumn(Dgl2, Col2DateofReturn, 80, Col2DateofReturn, True, True)
            .AddAgNumberColumn(Dgl2, Col2FinePerDay, 50, 5, 0, False, Col2FinePerDay, True, False, True)
            .AddAgNumberColumn(Dgl2, Col2FineAmount, 80, 5, 0, False, Col2FineAmount, True, False, True)
            .AddAgTextColumn(Dgl2, Col2Remark, 120, 255, Col2Remark, True, False)
            .AddAgTextColumn(Dgl2, Col2Writer, 170, 0, Col2Writer, True, True)
            .AddAgTextColumn(Dgl2, Col2Publisher, 170, 0, Col2Publisher, True, True)

        End With

        Dgl2.Columns(Col2Received).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)

        AgL.AddAgDataGrid(Dgl2, Pnl2)
        Dgl2.EnableHeadersVisualStyles = False
        Dgl2.ColumnHeadersHeight = 35
        Dgl2.AllowUserToAddRows = False


        'Dgl1.Anchor = AnchorStyles.None
        'Panel1.Anchor = Dgl1.Anchor
    End Sub

    Private Sub FrmBookIssue_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet

        '-------------------------------------------------------------
        'Line Records are showing in First Grid
        '-------------------------------------------------------------
        mQry = " Select BI.* ,B.Writer ,B.Publisher  FROM Lib_BookIssueDetail BI " & _
                " LEFT JOIN Lib_Book B  ON B.Code=BI.Book  " & _
                " where ReturnDocId = '" & mInternalCode & "' Order By Sr"

        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            Dgl2.RowCount = 1
            Dgl2.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                    Dgl2.Rows.Add()
                    Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count - 1
                    Dgl2.Item(Col2Received, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                    Dgl2.Item(Col2IssueDocId, I).Value = AgL.XNull(.Rows(I)("DocId"))
                    Dgl2.Item(Col1AccessionNo, I).Value = AgL.XNull(.Rows(I)("AccessionNo"))
                    Dgl2.Item(Col1BookId, I).Value = AgL.XNull(.Rows(I)("Book_UID"))
                    Dgl2.AgSelectedValue(Col2Book, I) = AgL.XNull(.Rows(I)("Book"))
                    Dgl2.Item(Col2Edition, I).Value = AgL.XNull(.Rows(I)("Edition"))
                    Dgl2.Item(Col2Status, I).Value = AgL.XNull(.Rows(I)("Status"))
                    Dgl2.Item(Col2DateToReturn, I).Value = AgL.XNull(.Rows(I)("ToReturnDate"))
                    Dgl2.Item(Col2DateofReturn, I).Value = AgL.XNull(.Rows(I)("ReturnDate"))
                    Dgl2.Item(Col2TempBookId, I).Value = AgL.XNull(.Rows(I)("Book_UID"))
                    Dgl2.Item(Col2ForDays, I).Value = AgL.VNull(.Rows(I)("ForDays"))
                    Dgl2.Item(Col2FinePerDay, I).Value = AgL.VNull(.Rows(I)("FinePerDay"))
                    Dgl2.Item(Col2FineAmount, I).Value = AgL.VNull(.Rows(I)("FineAmount"))
                    Dgl2.Item(Col2Remark, I).Value = AgL.XNull(.Rows(I)("Remarks"))
                    Dgl2.Item(Col2Writer, I).Value = AgL.XNull(.Rows(I)("Writer"))
                    Dgl2.Item(Col2Publisher, I).Value = AgL.XNull(.Rows(I)("Publisher"))
                    Dgl2.Item(Col2Qty, I).Value = 1

                    If Dgl2.Item(Col2DateToReturn, I).Value <> "" Then
                        If CDate(Dgl2.Item(Col2DateToReturn, I).Value) <= AgL.PubLoginDate Then
                            Dgl2.Rows(I).DefaultCellStyle.ForeColor = System.Drawing.Color.Red
                        Else
                            Dgl2.Rows(I).DefaultCellStyle.ForeColor = System.Drawing.Color.Black
                        End If
                    End If
                Next I
            End If
        End With
        Calculation()
        '-------------------------------------------------------------
    End Sub


    Private Sub FrmBookIssue_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 650, 885)
        Call ProcOpenFromSearchPanel()
    End Sub

    Private Sub Dgl2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl2.EditingControl_Validating
        Call Calculation()
    End Sub

    Private Sub DGL2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl2.RowsAdded
        Dim I As Integer = 0
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
        Try
            With Dgl2
                For I = .Columns(Col2Received).Index To .Columns(Col2Received).Index
                    If .Columns(I).Name <> ColSNo Then
                        sender.Item(I, sender.Rows.Count - 1).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                    End If
                Next
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProcFillReceiveGrid(ByVal bMemberCode As String)
        Dim DtTemp As DataTable
        Dim I As Integer
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub
            If AgL.StrCmp(Topctrl1.Mode, "Edit") Then Exit Sub

            mQry = " SELECT H.DocID AS IssueDocId,H.Member,L.Book_UID ,L.Book ,I.Unit, I.Description AS BookName,B.Writer,B.Publisher,L.Edition ,L.ForDays, " & _
                    " L.ToReturnDate,BTD.FinePerDay, L.AccessionNo " & _
                    " FROM Lib_BookIssue H " & _
                    " LEFT JOIN Lib_BookIssueDetail L ON H.DocID=L.DocId  " & _
                    " LEFT JOIN Item I ON I.Code=L.Book  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=L.Book  " & _
                    " LEFT JOIN Lib_Member M ON M.SubCode=H.Member " & _
                    " LEFT JOIN Lib_BookTypeDetail BTD ON BTD.Code=B.BookType AND BTD.MemberType =M.MemberType   " & _
                    " WHERE H.Member = " & AgL.Chk_Text(bMemberCode) & "  AND L.ReturnDocId IS NULL " & _
                    " AND isnull(H.IsDeleted,0)=0 AND L.Book_UID IS NOT NULL " & _
                    " AND isnull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                    " ORDER BY L.ToReturnDate "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        Dgl2.Rows.Add()
                        Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count
                        Dgl2.Item(Col2Received, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                        Dgl2.Item(Col2IssueDocId, I).Value = AgL.XNull(.Rows(I)("IssueDocId"))
                        Dgl2.Item(Col2AccessionNo, I).Value = AgL.XNull(.Rows(I)("AccessionNo"))
                        Dgl2.Item(Col2BookId, I).Value = AgL.XNull(.Rows(I)("Book_UID"))
                        Dgl2.AgSelectedValue(Col2Book, I) = AgL.XNull(.Rows(I)("Book"))
                        Dgl2.Item(Col2Writer, I).Value = AgL.XNull(.Rows(I)("Writer"))
                        Dgl2.Item(Col2Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl2.Item(Col2Publisher, I).Value = AgL.XNull(.Rows(I)("Publisher"))
                        Dgl2.Item(Col2Edition, I).Value = AgL.XNull(.Rows(I)("Edition"))
                        Dgl2.Item(Col2ForDays, I).Value = AgL.VNull(.Rows(I)("ForDays"))
                        Dgl2.Item(Col2DateToReturn, I).Value = AgL.XNull(.Rows(I)("ToReturnDate"))
                        Dgl2.Item(Col2DateofReturn, I).Value = TxtV_Date.Text
                        Dgl2.Item(Col2FinePerDay, I).Value = Format(AgL.VNull(.Rows(I)("FinePerDay")), "0.00")
                        Dgl2.Item(Col2Qty, I).Value = 1

                        If Dgl2.Item(Col2DateToReturn, I).Value <> "" Then
                            If CDate(Dgl2.Item(Col2DateToReturn, I).Value) <= CDate(Dgl2.Item(Col2DateofReturn, I).Value) Then
                                Dgl2.Rows(I).DefaultCellStyle.ForeColor = System.Drawing.Color.Red
                            Else
                                Dgl2.Rows(I).DefaultCellStyle.ForeColor = System.Drawing.Color.Black
                            End If
                        End If

                    Next I
                End If
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub TxtControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtMemberCardNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtMemberCardNo.Name
                    If TxtMemberCardNo.AgSelectedValue <> "" Then
                        ProcFillReceiveGrid(TxtMemberCardNo.AgSelectedValue)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub DGL2_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgl2.CellMouseUp
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = sender.CurrentCell.RowIndex
            mColumnIndex = sender.CurrentCell.ColumnIndex

            If sender.Item(mColumnIndex, mRowIndex).Value Is Nothing Then sender.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col2Received
                    Call AgL.ProcSetCheckColumnCellValue(sender, Dgl2.CurrentCell.ColumnIndex)
            End Select
        Catch ex As Exception
            'MsgBox(ex.Message)
            If Dgl2.Item(Col2Received, mRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                Dgl2.Item(Col2Status, mRowIndex).Value = Status_Received
                Call Calculation()
            Else
                Dgl2.Item(Col2Status, mRowIndex).Value = ""
                Call Calculation()
            End If
        End Try
    End Sub

    Private Sub ProcOpenFromSearchPanel()
        Try
            If mMemberCardNo = "" Then Exit Sub
            Topctrl1.FButtonClick(0)
            TxtMemberCardNo.AgSelectedValue = mMemberCardNo
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl2.KeyDown
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        Dim mRowIndex As Integer = 0, mColumnIndex As Integer = 0
        Try
            mRowIndex = sender.CurrentCell.RowIndex
            mColumnIndex = sender.CurrentCell.ColumnIndex
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col2Received
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(sender, mColumnIndex)
                    End If
            End Select
        Catch ex As Exception
            If Dgl2.Item(Col2Received, mRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                Dgl2.Item(Col2Status, mRowIndex).Value = Status_Received
                Call Calculation()
            Else
                Dgl2.Item(Col2Status, mRowIndex).Value = ""
                Call Calculation()
            End If
        End Try
    End Sub
End Class
