Public Class FrmBookIssue
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
    Protected Const Col2BtnReplacedBook As String = "Replace Book"
    Protected Const Col2ReplcementBookId As String = "Replace Book ID"
    Protected Const Col2ReplcementAccessionNo As String = "Replace Accession No"
    Protected Const Col2ReplcementBook As String = "Replacement Book"

    Protected Const Status_Received As String = "Received"
    Protected Const Status_Lost As String = "Lost"
    Protected Const Status_Replaced As String = "Replaced"

    Protected WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Pnl2 As System.Windows.Forms.Panel
    Public WithEvents TxtWriteOffDocId As AgControls.AgTextBox
    Public WithEvents TxtAccessionDocId As AgControls.AgTextBox

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

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.TxtAccessionDocId = New AgControls.AgTextBox
        Me.TxtWriteOffDocId = New AgControls.AgTextBox
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
        Me.TP1.Controls.Add(Me.TxtWriteOffDocId)
        Me.TP1.Controls.Add(Me.TxtAccessionDocId)
        Me.TP1.Size = New System.Drawing.Size(866, 160)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMemberName, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMemberName, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMemberCardNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMemberCardNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMemberCardNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMemberType, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMemberType, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblApplicationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtApplicationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTransactionBy, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTransactionBy, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMemberRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMemberRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAccessionDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtWriteOffDocId, 0)
        '
        'Topctrl1
        '
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
        'TxtAccessionDocId
        '
        Me.TxtAccessionDocId.AgAllowUserToEnableMasterHelp = False
        Me.TxtAccessionDocId.AgMandatory = False
        Me.TxtAccessionDocId.AgMasterHelp = False
        Me.TxtAccessionDocId.AgNumberLeftPlaces = 8
        Me.TxtAccessionDocId.AgNumberNegetiveAllow = False
        Me.TxtAccessionDocId.AgNumberRightPlaces = 2
        Me.TxtAccessionDocId.AgPickFromLastValue = False
        Me.TxtAccessionDocId.AgRowFilter = ""
        Me.TxtAccessionDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAccessionDocId.AgSelectedValue = Nothing
        Me.TxtAccessionDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAccessionDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAccessionDocId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAccessionDocId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAccessionDocId.Location = New System.Drawing.Point(760, 29)
        Me.TxtAccessionDocId.MaxLength = 20
        Me.TxtAccessionDocId.Name = "TxtAccessionDocId"
        Me.TxtAccessionDocId.Size = New System.Drawing.Size(74, 18)
        Me.TxtAccessionDocId.TabIndex = 743
        Me.TxtAccessionDocId.Visible = False
        '
        'TxtWriteOffDocId
        '
        Me.TxtWriteOffDocId.AgAllowUserToEnableMasterHelp = False
        Me.TxtWriteOffDocId.AgMandatory = False
        Me.TxtWriteOffDocId.AgMasterHelp = False
        Me.TxtWriteOffDocId.AgNumberLeftPlaces = 8
        Me.TxtWriteOffDocId.AgNumberNegetiveAllow = False
        Me.TxtWriteOffDocId.AgNumberRightPlaces = 2
        Me.TxtWriteOffDocId.AgPickFromLastValue = False
        Me.TxtWriteOffDocId.AgRowFilter = ""
        Me.TxtWriteOffDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtWriteOffDocId.AgSelectedValue = Nothing
        Me.TxtWriteOffDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtWriteOffDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtWriteOffDocId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtWriteOffDocId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWriteOffDocId.Location = New System.Drawing.Point(760, 52)
        Me.TxtWriteOffDocId.MaxLength = 20
        Me.TxtWriteOffDocId.Name = "TxtWriteOffDocId"
        Me.TxtWriteOffDocId.Size = New System.Drawing.Size(74, 18)
        Me.TxtWriteOffDocId.TabIndex = 744
        Me.TxtWriteOffDocId.Visible = False
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
#End Region

    Private Sub FrmBookIssue_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer, mSr As Integer
        If 1 = 2 Then
        Else
            'With Dgl2
            '    For I = 0 To .RowCount - 1
            '        If .Item(Col2BookId, I).Value <> "" Or .Item(Col2TempBookId, I).Value <> "" Then
            '            mSr += 1
            '            If .Item(Col2TempBookId, I).Value <> "" Then
            '                mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 0 " & _
            '                        " WHERE Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2TempBookId, I).Value) & " "
            '                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            '            End If

            '            If .Item(Col2BookId, I).Value <> "" Then
            '                mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 1 " & _
            '                        " WHERE Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2BookId, I).Value) & " "
            '                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            '            End If
            '        End If
            '    Next
            'End With
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

                        mQry = " UPDATE Lib_BookIssueDetail " & _
                                " SET ReturnDocId = Null , " & _
                                " ReturnDate = Null, " & _
                                " Status = Null, " & _
                                " FinePerDay = 0, " & _
                                " FineAmount = 0, " & _
                                " ReplacementBookId = Null, " & _
                                " ReplacementAccessionNo = Null, " & _
                                " ReplacementBook = Null, " & _
                                " Remarks =Null " & _
                                " WHERE DocId = " & AgL.Chk_Text(Dgl2.Item(Col2IssueDocId, I).Value) & "  " & _
                                " AND Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2BookId, I).Value) & " "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                    End If
                End If
            Next
        End With


        mQry = " Delete From Lib_AccessionDetail Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Lib_AccessionDetail_Log Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Lib_Accession_Log Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Lib_Accession Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Stock_Log Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Stock Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Stock Where DocId = '" & TxtWriteOffDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Stock_Log Where DocId = '" & TxtWriteOffDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From StockHead Where DocId = '" & TxtWriteOffDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From StockHead_Log Where DocId = '" & TxtWriteOffDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    End Sub

    Private Sub FrmBookIssue_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer, J As Integer
        Dim bBookIssueCount As Integer
        Dim bBookReturnCount As Integer, TotalIssed As Integer = 0
        Dim bDtTemp As DataTable = Nothing

        bBookIssueCount = 0

        TxtApplicationNo.AgSelectedValue = ""
        If AgL.RequiredField(TxtMemberCardNo, LblMemberCardNo.Text) Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1BookId, I).Value <> "" Then
                    bBookIssueCount += 1
                End If
            Next
        End With


        mQry = "SELECT M.IssueLockFromDate, M.IssueLockTillDate, M.IssueLockReason " & _
                " FROM Lib_Member M With (NoLock) " & _
                " WHERE M.SubCode = " & AgL.Chk_Text(TxtMemberCardNo.AgSelectedValue) & " "
        bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
        If bDtTemp.Rows.Count > 0 Then
            If bBookIssueCount > 0 Then
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
                    bBookReturnCount += 1
                End If

                If AgL.StrCmp(.Item(Col2Status, I).Value, Status_Replaced) Then
                    If AgL.XNull(.Item(Col2ReplcementBookId, I).Value).ToString.Trim = "" Then
                        MsgBox("Book is Replaced. Replacement Book Id is Required", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2BtnReplacedBook, I) : Dgl2.Focus()
                        passed = False : Exit Sub
                    End If

                    If AgL.XNull(.Item(Col2ReplcementAccessionNo, I).Value).ToString.Trim = "" Then
                        MsgBox("Book is Replaced. Replacement Accession is Required", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2BtnReplacedBook, I) : Dgl2.Focus()
                        passed = False : Exit Sub
                    End If

                    For J = I + 1 To .Rows.Count - 1
                        If AgL.StrCmp(AgL.XNull(.Item(Col2ReplcementBookId, I).Value).ToString, AgL.XNull(.Item(Col2ReplcementBookId, J).Value).ToString) Then
                            MsgBox("Duplicate Book Id at Row No. : " & .Item(ColSNo, J).Value & "!...", MsgBoxStyle.Information)
                            .CurrentCell = .Item(Col2BtnReplacedBook, J) : Dgl2.Focus()
                            passed = False : Exit Sub
                        End If
                    Next
                End If
            Next
        End With

        If (bBookReturnCount + bBookIssueCount) < 1 Then
            MsgBox("No Transaction Data in Grid")
            passed = False : Exit Sub
        End If

        ''***********************************

        mQry = "SELECT Count(*) AS Book " & _
                " FROM Lib_BookIssue  B " & _
                " LEFT JOIN Lib_BookIssueDetail BT ON BT.DocId = B.DocID " & _
                " WHERE B.Member= " & AgL.Chk_Text(TxtMemberCardNo.AgSelectedValue) & "  And BT.Book_UID IS NOT NULL  AND BT.ReturnDate IS NULL And " & IIf(Topctrl1.Mode = "Add", " 1=1 ", " B.DocId <> '" & mInternalCode & "' ") & ""
        TotalIssed = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar

        '********************************************

        mQry = "SELECT  Mt.BooksAllowed FROM Lib_MemberType MT " & _
              " WHERE  MT.Code =  " & AgL.Chk_Text(TxtMemberType.AgSelectedValue) & " "
        bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
        If bBookIssueCount > 0 Then
            If ((bBookIssueCount + TotalIssed) - bBookReturnCount) > AgL.VNull(bDtTemp.Rows(0).Item("BooksAllowed")) Then
                MsgBox("Books Issued To " & TxtMemberName.Text & " Exceeds the Allowed limit.", MsgBoxStyle.Exclamation)
                Dgl1.CurrentCell = Dgl1.Item(Col1BookId, Dgl1.CurrentCell.RowIndex) : Dgl1.Focus()
                passed = False : Exit Sub
            End If
        End If

    End Sub

    Private Sub FrmBookIssue_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        AgL.GridDesign(Dgl2)
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
        Dgl2.AgHelpDataSet(Col2ReplcementBook, 11) = AgL.FillData(mQry, AgL.GCn)

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
            .AddAgButtonColumn(Dgl2, Col2BtnReplacedBook, 70, "Replace Book", True, False, , , , "Webdings", 10, "6")
            .AddAgTextColumn(Dgl2, Col2ReplcementBookId, 100, 20, Col2ReplcementBookId, True, True)
            .AddAgTextColumn(Dgl2, Col2ReplcementAccessionNo, 100, 0, Col2ReplcementAccessionNo, True, True)
            .AddAgTextColumn(Dgl2, Col2ReplcementBook, 100, 0, Col2ReplcementBook, True, True)
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

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From Lib_BookIssue H " & _
                " Where H.DocID = '" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                " From Lib_BookIssue_Log H " & _
                " Where H.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtWriteOffDocId.Text = AgL.XNull(.Rows(0)("WriteOffDocId"))
                TxtAccessionDocId.Text = AgL.XNull(.Rows(0)("AccessionDocId"))
            End If
        End With

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
                    Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count
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
                    Dgl2.Item(Col2ReplcementBookId, I).Value = AgL.XNull(.Rows(I)("ReplacementBookId"))
                    Dgl2.Item(Col2ReplcementAccessionNo, I).Value = AgL.XNull(.Rows(I)("ReplacementAccessionNo"))
                    Dgl2.AgSelectedValue(Col2ReplcementBook, I) = AgL.XNull(.Rows(I)("ReplacementBook"))

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
        Try
            Select Case Dgl2.Columns(Dgl2.CurrentCell.ColumnIndex).Name
                Case Col2Status
                    If Not AgL.StrCmp(Dgl2.Item(Col2Status, Dgl2.CurrentCell.RowIndex).Value, Status_Replaced) Then
                        Dgl2.Item(Col2ReplcementBookId, Dgl2.CurrentCell.RowIndex).Value = ""
                        Dgl2.Item(Col2ReplcementAccessionNo, Dgl2.CurrentCell.RowIndex).Value = ""
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
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

    Private Sub Dgl2_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl2.CellContentClick
        Dim FrmObj As Form = Nothing
        Dim bColumnIndex As Integer = 0
        Dim bRowIndex As Integer = 0
        Dim I As Integer = 0
        Try
            bColumnIndex = Dgl2.CurrentCell.ColumnIndex
            bRowIndex = Dgl2.CurrentCell.RowIndex

            Select Case Dgl2.Columns(e.ColumnIndex).Name
                Case Col2BtnReplacedBook
                    If AgL.StrCmp(Dgl2.Item(Col2Status, Dgl2.CurrentCell.RowIndex).Value, Status_Replaced) Then
                        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                            Call ProcCreateNewBook(bRowIndex)
                        End If
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProcCreateNewBook(ByVal bRowIndex As Integer)
        Dim FrmObj As AccessionEntry = Nothing
        Dim DTUP As DataTable = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl2.Item(Col2BtnReplacedBook, bRowIndex).Tag Is Nothing Then
                FrmObj = New AccessionEntry()
            Else
                FrmObj = Dgl2.Item(Col2BtnReplacedBook, bRowIndex).Tag
            End If

            If Dgl2.Item(Col2BtnReplacedBook, bRowIndex).Tag Is Nothing Then
                If AgL.XNull(Dgl2.Item(Col2ReplcementBookId, bRowIndex).Value).ToString.Trim <> "" Then
                    mQry = " SELECT L.Book_UID, L.AccessionNo, L.Book, L.Writer, L.Writer, L.Publisher, L.ISBN, L.Edition, L.Pages , " & _
                            " L.Language, L.PublicationYear, L.ISBN, L.Edition, L.Pages, L.MRP, L.Rate, L.Place,  " & _
                            " L.WithCD, L.Godown, L.GodownSection, L.Subject, L.Volume, L.Series, L.Rate, L.Mrp " & _
                            " FROM Lib_AccessionDetail L  " & _
                            " WHERE L.Book_Uid = '" & Dgl2.Item(Col2ReplcementBookId, bRowIndex).Value & "' "
                    DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                    With DtTemp
                        If .Rows.Count > 0 Then
                            CType(FrmObj, AccessionEntry).EntryMode = Topctrl1.Mode
                            CType(FrmObj, AccessionEntry).TxtAccno.Text = Dgl2.Item(Col2ReplcementAccessionNo, bRowIndex).Value
                            CType(FrmObj, AccessionEntry).TxtBook_UID.Text = Dgl2.Item(Col2ReplcementBookId, bRowIndex).Value
                            CType(FrmObj, AccessionEntry).Book = AgL.XNull(.Rows(0)("Book"))
                            CType(FrmObj, AccessionEntry).almira = AgL.XNull(.Rows(0)("Godown"))
                            CType(FrmObj, AccessionEntry).Subject = AgL.XNull(.Rows(0)("Subject"))
                            CType(FrmObj, AccessionEntry).Publisher = AgL.XNull(.Rows(0)("Publisher"))
                            CType(FrmObj, AccessionEntry).Writer = AgL.XNull(.Rows(0)("Writer"))
                            CType(FrmObj, AccessionEntry).Volume = AgL.XNull(.Rows(0)("Volume"))
                            CType(FrmObj, AccessionEntry).Language = AgL.XNull(.Rows(0)("Language"))
                            CType(FrmObj, AccessionEntry).PublicationYear = AgL.XNull(.Rows(0)("PublicationYear"))
                            CType(FrmObj, AccessionEntry).ISBN = AgL.XNull(.Rows(0)("ISBN"))
                            CType(FrmObj, AccessionEntry).Series = AgL.XNull(.Rows(0)("Series"))
                            CType(FrmObj, AccessionEntry).WithCD = AgL.XNull(.Rows(0)("WithCD"))
                            CType(FrmObj, AccessionEntry).Rate = AgL.VNull(.Rows(0)("Rate"))
                            CType(FrmObj, AccessionEntry).Mrp = AgL.VNull(.Rows(0)("Mrp"))
                            CType(FrmObj, AccessionEntry).Pages = AgL.VNull(.Rows(0)("Pages"))
                            CType(FrmObj, AccessionEntry).place = AgL.XNull(.Rows(0)("place"))
                        End If
                    End With
                End If
            End If
            FrmObj.StartPosition = FormStartPosition.CenterScreen
            FrmObj.ShowDialog()

            Dgl2.Item(Col2BtnReplacedBook, bRowIndex).Tag = FrmObj


            If CType(FrmObj, AccessionEntry).mIsOkClicked Then
                Ini_List()
                Dgl2.Item(Col2ReplcementBookId, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtBook_UID.Text
                Dgl2.Item(Col2ReplcementAccessionNo, bRowIndex).Value = CType(FrmObj, AccessionEntry).TxtAccno.Text
                Dgl2.AgSelectedValue(Col2ReplcementBook, bRowIndex) = CType(FrmObj, AccessionEntry).TxtBook.AgSelectedValue
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
                            " ReplacementBookId = " & AgL.Chk_Text(Dgl2.Item(Col2ReplcementBookId, I).Value) & ", " & _
                            " ReplacementAccessionNo = " & AgL.Chk_Text(Dgl2.Item(Col2ReplcementAccessionNo, I).Value) & ", " & _
                            " ReplacementBook = " & AgL.Chk_Text(Dgl2.AgSelectedValue(Col2ReplcementBook, I)) & ", " & _
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

                    mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 1 " & _
                            " WHERE Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2BookId, I).Value) & " "
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

        Call ProcWriteOffBook(Conn, Cmd)
        Call ProcCreateNewAccession(Conn, Cmd)

        mQry = " UPDATE dbo.Lib_BookIssue_Log " & _
               " SET AccessionDocId = " & AgL.Chk_Text(TxtAccessionDocId.Text) & ", " & _
               " WriteOffDocId = " & AgL.Chk_Text(TxtWriteOffDocId.Text) & " " & _
               " WHERE UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Public Sub ProcWriteOffBook(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
        Dim I As Integer = 0, mSr As Integer = 0
        Dim bStructStock As AgTemplate.ClsMain.StructStock = Nothing
        Dim bIsReplaced As Boolean = False

        With Dgl2
            For I = 0 To .Rows.Count - 1
                If AgL.StrCmp(.Item(Col2Status, I).Value, Status_Lost) Or AgL.StrCmp(.Item(Col2Status, I).Value, Status_Replaced) Then
                    bIsReplaced = True
                    Exit For
                End If
            Next
        End With
        If bIsReplaced = False Then Exit Sub


        Dim bWriteOffInternalCode$ = "", bWriteOffSearhCode$ = "", bWriteOffV_Type$ = "", bWriteOffV_Prefix$ = ""
        Dim bWriteOffV_No As Long = 0

        mQry = " Delete From Stock Where DocId = '" & TxtWriteOffDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Stock_Log Where DocId = '" & TxtWriteOffDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From StockHead Where DocId = '" & TxtWriteOffDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From StockHead_Log Where DocId = '" & TxtWriteOffDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        bWriteOffSearhCode = AgL.GetGUID(AgL.GCn).ToString
        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            mQry = " Select Vt.V_Type From Voucher_Type Vt With (NoLock) Where Vt.NCat = '" & ClsMain.Temp_NCat.WriteOffBooks & "'   "
            bWriteOffV_Type = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            bWriteOffInternalCode = AgL.GetDocId(bWriteOffV_Type, bWriteOffV_No, CDate(TxtV_Date.Text), AgL.GcnRead, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            TxtWriteOffDocId.Text = bWriteOffInternalCode
        End If

        bWriteOffV_No = Val(AgL.DeCodeDocID(TxtWriteOffDocId.Text, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        bWriteOffV_Prefix = AgL.DeCodeDocID(TxtWriteOffDocId.Text, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
        bWriteOffV_Type = AgL.DeCodeDocID(TxtWriteOffDocId.Text, AgLibrary.ClsMain.DocIdPart.VoucherType)

        mQry = " INSERT INTO StockHead_Log(DocID, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                 " Remarks, EntryBy, EntryDate, EntryType, EntryStatus, Status, UID) " & _
                 " VALUES " & _
                 " ( " & _
                 " '" & TxtWriteOffDocId.Text & "', " & _
                 " " & AgL.Chk_Text(bWriteOffV_Type) & ", " & _
                 " " & AgL.Chk_Text(bWriteOffV_Prefix) & ", " & _
                 " " & AgL.Chk_Text(TxtV_Date.Text) & ", " & _
                 " " & Val(bWriteOffV_No) & ", " & _
                 " " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ", " & _
                 " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                 " " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                 " " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                 " " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                 " " & AgL.Chk_Text(Topctrl1.Mode) & ", " & AgL.Chk_Text(LogStatus.LogOpen) & ", " & _
                 " " & AgL.Chk_Text(TxtStatus.Text) & ", " & _
                 " " & AgL.Chk_Text(bWriteOffSearhCode) & " " & _
                 " ) "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        With Dgl2
            For I = 0 To .Rows.Count - 1
                If .Item(Col2Book, I).Value <> "" Then
                    If AgL.StrCmp(.Item(Col2Status, I).Value, Status_Lost) Or AgL.StrCmp(.Item(Col2Status, I).Value, Status_Replaced) Then
                        mSr = mSr + 1
                        mQry = " INSERT INTO Stock_Log(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, " & _
                                " Site_Code, Item, Item_uid, Qty_Iss, Unit,	UID, Edition) " & _
                                " VALUES( " & _
                                " " & AgL.Chk_Text(TxtWriteOffDocId.Text) & ", " & _
                                " " & Val(mSr) & ", " & _
                                " " & AgL.Chk_Text(bWriteOffV_Type) & ", " & _
                                " " & AgL.Chk_Text(bWriteOffV_Prefix) & ", " & _
                                " " & AgL.Chk_Text(TxtV_Date.Text) & ", " & _
                                " " & Val(bWriteOffV_No) & ", " & _
                                " " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ", " & _
                                " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                                " " & AgL.Chk_Text(Dgl2.AgSelectedValue(Col2Book, I)) & ", " & _
                                " " & AgL.Chk_Text(Dgl2.Item(Col2BookId, I).Value) & ", " & _
                                " 1, " & _
                                " " & AgL.Chk_Text(Dgl2.Item(Col2Unit, I).Value) & ", " & _
                                " " & AgL.Chk_Text(bWriteOffSearhCode) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Edition, I).Value) & " " & _
                                " ) "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                        mQry = " UPDATE Lib_AccessionDetail " & _
                               " SET IsInStock = 0 " & _
                               " Where Book_UID = " & AgL.Chk_Text(.Item(Col1BookId, I).Value) & " "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    End If
                End If
            Next
        End With

        mQry = " INSERT INTO StockHead(DocID, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                " OrderBy,SubCode,	FromProcess,	ToProcess,	FromGodown,	ToGodown,	TotalQty, " & _
                " TotalMeasure,	Amount,	Addition,	Deduction,	NetAmount,	Remarks, " & _
                " IsDeleted,	EntryBy,	EntryDate,	EntryType,	EntryStatus,	ApproveBy,	ApproveDate, " & _
                " MoveToLog,	MoveToLogDate,	Status,	UID,	ReferenceDocID,	Structure,	ToSite_Code,ManualRefNo) " & _
                " SELECT DocID, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                " OrderBy,SubCode,	FromProcess,	ToProcess,	FromGodown,	ToGodown,	TotalQty, " & _
                " TotalMeasure,	Amount,	Addition,	Deduction,	NetAmount,	Remarks, " & _
                " IsDeleted,	EntryBy,	EntryDate,	EntryType,	EntryStatus,	ApproveBy,	ApproveDate, " & _
                " MoveToLog,	MoveToLogDate,	Status,	UID,	ReferenceDocID,	Structure,	ToSite_Code,ManualRefNo " & _
                " FROM StockHead_Log " & _
                " WHERE DocID = '" & TxtWriteOffDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " INSERT INTO Stock(DocID,Sr,V_Type,	V_Prefix,	V_Date,	V_No,	Div_Code, " & _
                " Site_Code,	SubCode,	Currency,	SalesTaxGroupParty,	Structure,	BillingType, " & _
                " Item,	Item_UID,	ProcessGroup,	Godown,	Qty_Iss,	Qty_Rec,	Unit, " & _
                " MeasurePerPcs,	Measure_Iss,	Measure_Rec,	MeasureUnit,	Rate,	Amount, " & _
                " Addition,	Deduction,	NetAmount,	Remarks,	Process,	Status,	UID, " & _
                " FIFORate,	FIFOAmt,	AVGRate,	AVGAmt,	Cost,	Doc_Qty,	ReferenceDocID, " & _
                " Edition,	LotNo) " & _
                " SELECT DocID,Sr,V_Type,	V_Prefix,	V_Date,	V_No,	Div_Code, " & _
                " Site_Code,	SubCode,	Currency,	SalesTaxGroupParty,	Structure,	BillingType, " & _
                " Item,	Item_UID,	ProcessGroup,	Godown,	Qty_Iss,	Qty_Rec,	Unit, " & _
                " MeasurePerPcs,	Measure_Iss,	Measure_Rec,	MeasureUnit,	Rate,	Amount, " & _
                " Addition,	Deduction,	NetAmount,	Remarks,	Process,	Status,	UID, " & _
                " FIFORate,	FIFOAmt,	AVGRate,	AVGAmt,	Cost,	Doc_Qty,	ReferenceDocID, " & _
                " Edition,	LotNo " & _
                " FROM Stock_Log " & _
                " WHERE DocId = '" & TxtWriteOffDocId.Text & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        Call AgL.UpdateVoucherCounter(TxtWriteOffDocId.Text, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
        Call AgL.LogTableEntry(bWriteOffSearhCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub ProcCreateNewAccession(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
        Dim bAccessionInternalCode$ = "", bAccessionSearhCode$ = "", bAccessionV_Type$ = "", bAccessionV_Prefix$ = ""
        Dim bAccessionV_No As Long = 0
        Dim mSr As Integer = 0, I As Integer = 0
        Dim bIsReplaced As Boolean = False

        With Dgl2
            For I = 0 To .Rows.Count - 1
                If AgL.StrCmp(.Item(Col2Status, I).Value, Status_Replaced) Then
                    bIsReplaced = True
                    Exit For
                End If
            Next
        End With
        If bIsReplaced = False Then Exit Sub

        mQry = " Delete From Lib_AccessionDetail Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Lib_AccessionDetail_Log Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Lib_Accession_Log Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Lib_Accession Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Stock_Log Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From Stock Where DocId = '" & TxtAccessionDocId.Text & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        bAccessionSearhCode = AgL.GetGUID(AgL.GCn).ToString
        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            mQry = " Select Vt.V_Type From Voucher_Type Vt With (NoLock) Where Vt.NCat = '" & ClsMain.Temp_NCat.Accession & "'   "
            bAccessionV_Type = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            bAccessionInternalCode = AgL.GetDocId(bAccessionV_Type, bAccessionV_No, CDate(TxtV_Date.Text), AgL.GcnRead, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            TxtAccessionDocId.Text = bAccessionInternalCode
        End If

        bAccessionV_No = Val(AgL.DeCodeDocID(TxtAccessionDocId.Text, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        bAccessionV_Prefix = AgL.DeCodeDocID(TxtAccessionDocId.Text, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
        bAccessionV_Type = AgL.DeCodeDocID(TxtAccessionDocId.Text, AgLibrary.ClsMain.DocIdPart.VoucherType)

        mQry = " INSERT INTO Lib_Accession_Log (DocID, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                " TransactionBy, Remarks, EntryBy, EntryDate, EntryType, EntryStatus, Status, UID) " & _
                " VALUES " & _
                " ( " & _
                " '" & TxtAccessionDocId.Text & "', " & _
                " " & AgL.Chk_Text(bAccessionV_Type) & ", " & _
                " " & AgL.Chk_Text(bAccessionV_Prefix) & ", " & _
                " " & AgL.Chk_Text(TxtV_Date.Text) & ", " & _
                " " & Val(bAccessionV_No) & ", " & _
                " " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ", " & _
                " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                " " & AgL.Chk_Text(TxtTransactionBy.AgSelectedValue) & ", " & _
                " " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                " " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                " " & AgL.Chk_Text(Topctrl1.Mode) & ", " & AgL.Chk_Text(LogStatus.LogOpen) & ", " & _
                " " & AgL.Chk_Text(TxtStatus.Text) & ", " & _
                " " & AgL.Chk_Text(bAccessionSearhCode) & " " & _
                " ) "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        For I = 0 To Dgl2.Rows.Count - 1
            If Dgl2.Item(Col2Book, I).Value <> "" Then
                If AgL.StrCmp(Dgl2.Item(Col2Status, I).Value, Status_Replaced) Then
                    mSr = mSr + 1
                    mQry = "INSERT INTO Lib_AccessionDetail_Log	(UID, DocId, Sr, AccessionNo, Book_UID, Book, IsInStock) " & _
                            " VALUES(" & AgL.Chk_Text(bAccessionSearhCode) & ", " & AgL.Chk_Text(TxtAccessionDocId.Text) & ", " & _
                            " " & mSr & ", " & AgL.Chk_Text(Dgl2.Item(Col2ReplcementAccessionNo, I).Value) & ", " & _
                            " " & AgL.Chk_Text(Dgl2.Item(Col2ReplcementBookId, I).Value) & ", " & _
                            " " & AgL.Chk_Text(Dgl2.AgSelectedValue(Col2ReplcementBook, I)) & ", 1)"
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                    mQry = " UPDATE Lib_AccessionDetail_Log " & _
                            " SET " & _
                            " Lib_AccessionDetail_Log.Writer = Lib_Book.Writer , " & _
                            " Lib_AccessionDetail_Log.Publisher = Lib_Book.Publisher, " & _
                            " Lib_AccessionDetail_Log.Series = Lib_Book.Series,  " & _
                            " Lib_AccessionDetail_Log.Subject = Lib_Book.Subject,  " & _
                            " Lib_AccessionDetail_Log.Volume = Lib_Book.Volume,  " & _
                            " Lib_AccessionDetail_Log.Language = Lib_Book.Language,  " & _
                            " Lib_AccessionDetail_Log.ISBN = Lib_Book.ISBN,  " & _
                            " Lib_AccessionDetail_Log.Pages = Lib_Book.Pages,  " & _
                            " Lib_AccessionDetail_Log.Rate = Lib_Book.Rate,  " & _
                            " Lib_AccessionDetail_Log.WithCD = Lib_Book.WithCD, " & _
                            " Lib_AccessionDetail_Log.Place = Lib_Book.PlaceOfPub " & _
                            " FROM Lib_Book  " & _
                            " WHERE Lib_AccessionDetail_Log.Book = Lib_Book.Code " & _
                            " AND Lib_AccessionDetail_Log.Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2ReplcementBookId, I).Value) & " "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            End If
        Next

        mQry = " INSERT INTO Lib_Accession(DocID,	V_Type,	V_Prefix,	V_Date,	V_No,	Div_Code, " & _
                " Site_Code,	ReceiptNo,	TransactionBy,	Remarks,	EntryBy,	EntryDate, " & _
                " EntryType,	EntryStatus,	ApproveBy,	ApproveDate,	MoveToLog,	MoveToLogDate, " & _
                " IsDeleted,	Status) " & _
                " SELECT 	DocID,	V_Type,	V_Prefix,	V_Date,	V_No,	Div_Code,	Site_Code, " & _
                " ReceiptNo,	TransactionBy,	Remarks,	EntryBy,	EntryDate,	EntryType, " & _
                " EntryStatus,	ApproveBy,	ApproveDate,	MoveToLog,	MoveToLogDate, " & _
                " IsDeleted,	Status " & _
                " FROM Lib_Accession_Log " & _
                " WHERE DocID = '" & TxtAccessionDocId.Text & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " INSERT INTO Lib_AccessionDetail(DocId, Sr, AccessionNoPrefix, AccessionNo_Sr, AccessionNoSufix, " & _
                " AccessionNo, BookIDPrefix, BookID_Sr, BookIDSufix, Book_UID, Book, Writer, Publisher, " & _
                " Series,	Subject,	Volume,	Language,	ISBN,	Edition,	Pages,	MRP,	Rate, " & _
                " WithCD,	Godown,	GodownSection,	RefAccessionNo,	Remarks,	IsInStock,	WriteOff, " & _
                " PublicationYear,	Place,	CallNo) " & _
                " SELECT DocId, Sr, AccessionNoPrefix, AccessionNo_Sr, AccessionNoSufix, " & _
                " AccessionNo, BookIDPrefix, BookID_Sr, BookIDSufix, Book_UID, Book, Writer, Publisher, " & _
                " Series,	Subject,	Volume,	Language,	ISBN,	Edition,	Pages,	MRP,	Rate, " & _
                " WithCD,	Godown,	GodownSection,	RefAccessionNo,	Remarks,	IsInStock,	WriteOff, " & _
                " PublicationYear,	Place,	CallNo " & _
                " FROM Lib_AccessionDetail_Log " & _
                " WHERE DocId = '" & TxtAccessionDocId.Text & "'  "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "INSERT INTO Stock_Log(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
              " SubCode, Item, Godown, Qty_Rec, Unit, Remarks, Edition,  Item_UID, UID) " & _
              " SELECT Ad.DocId, Ad.Sr, A.V_Type, A.V_Prefix, A.V_Date, A.V_No, A.Div_Code, A.Site_Code, " & _
              " A.TransactionBy, Ad.Book, Ad.Godown, 1, 'Pcs', Ad.Remarks, Ad.Edition, Ad.Book_UID, A.UID " & _
              " FROM Lib_AccessionDetail_Log Ad With (NoLock)  " & _
              " LEFT JOIN Lib_Accession_Log A  With (NoLock) ON Ad.DocId = A.DocID " & _
              " WHERE A.DocId = '" & TxtAccessionDocId.Text & "'  "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "INSERT INTO Stock(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                " SubCode, Item, Godown, Qty_Rec, Unit, Remarks, Edition,  Item_UID, UID) " & _
                " SELECT Ad.DocId, Ad.Sr, A.V_Type, A.V_Prefix, A.V_Date, A.V_No, A.Div_Code, A.Site_Code, " & _
                " A.TransactionBy, Ad.Book, Ad.Godown, 1, 'Pcs', Ad.Remarks, Ad.Edition, Ad.Book_UID, A.UID " & _
                " FROM Lib_AccessionDetail Ad With (NoLock)  " & _
                " LEFT JOIN Lib_Accession A  With (NoLock) ON Ad.DocId = A.DocID " & _
                " WHERE A.DocId = '" & TxtAccessionDocId.Text & "'  "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        Call AgL.UpdateVoucherCounter(TxtAccessionDocId.Text, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
        Call AgL.LogTableEntry(bAccessionSearhCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
    End Sub
End Class
