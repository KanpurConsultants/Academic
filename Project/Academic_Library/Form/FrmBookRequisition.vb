Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmBookRequisition
    Inherits AgTemplate.TempRequisition

    Protected Const Col1BtnNewBook As String = "New Book"
    Protected Const Col1Writer As String = "Writer"
    Protected Const Col1Publisher As String = "Publisher"
    Protected Const Col1Edition As String = "Edition"

    Protected EditionHelpDataSet As DataSet = Nothing

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        'Me.EntryNCat = ClsMain.Temp_NCat.BookRequisition
        Me.EntryNCat = "" & ClsMain.Temp_NCat.BookRequisition & "," & ClsMain.Temp_NCat.NewBookRequisition & ""
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
        'TxtDepartment
        '
        Me.TxtDepartment.Location = New System.Drawing.Point(32, 82)
        Me.TxtDepartment.Size = New System.Drawing.Size(87, 18)
        Me.TxtDepartment.Visible = False
        '
        'LblDepartment
        '
        Me.LblDepartment.Location = New System.Drawing.Point(27, 63)
        Me.LblDepartment.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(1, 390)
        Me.Panel1.Size = New System.Drawing.Size(863, 21)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(1, 202)
        Me.Pnl1.Size = New System.Drawing.Size(863, 188)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(303, 86)
        Me.TxtRemarks.TabIndex = 5
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(176, 88)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Visible = False
        '
        'Label33
        '
        Me.Label33.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(1, 180)
        '
        'LblRequisitionBYReq
        '
        Me.LblRequisitionBYReq.Location = New System.Drawing.Point(287, 71)
        '
        'TxtRequisitionBy
        '
        Me.TxtRequisitionBy.Location = New System.Drawing.Point(303, 66)
        '
        'LblRequisitionBy
        '
        Me.LblRequisitionBy.Location = New System.Drawing.Point(176, 66)
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(885, 4)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(409, 47)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(519, 46)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(287, 52)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(176, 47)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(510, 33)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(303, 46)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(409, 28)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(519, 26)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(287, 32)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(176, 28)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(303, 26)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(0, 17)
        Me.TabControl1.Size = New System.Drawing.Size(863, 160)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(855, 134)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(867, 41)
        '
        'FrmBookRequisition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(867, 504)
        Me.LogLineTableCsv = "PurchIndentDetail_Log"
        Me.LogTableName = "PurchIndent_Log"
        Me.MainLineTableCsv = "PurchIndentDetail"
        Me.MainTableName = "PurchIndent"
        Me.Name = "FrmBookRequisition"
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

    Private Sub FrmBookRequisition_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        AgCL.AgBlankNothingCells(Dgl1)
    End Sub

    Private Sub FrmBookRequisition_BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTransLine
        mQry = " UPDATE RequisitionDetail_Log " & _
                " SET Edition = '" & Dgl1.Item(Col1Edition, mGridRow).Value & "' " & _
                " Where UID = '" & SearchCode & "' And Sr = " & Val(Sr) & ""
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmBookRequisition_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0")
    End Sub

    Private Sub FrmYarnSKUOpeningStock_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid


        Dgl1.Columns(Col1Item).HeaderText = "Book"
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1MeasureUnit).Visible = False
        Dgl1.Columns(Col1TotalMeasure).Visible = False

        With AgCL
            .AddAgButtonColumn(Dgl1, Col1BtnNewBook, 30, " ", True, False, , , , "Webdings", 10, "6")
            .AddAgTextColumn(Dgl1, Col1Writer, 140, 100, Col1Writer, True, True)
            .AddAgTextColumn(Dgl1, Col1Publisher, 140, 100, Col1Publisher, True, True)
            .AddAgTextColumn(Dgl1, Col1Edition, 90, 20, Col1Edition, True, False, False)
        End With

        Dgl1.Columns(Col1BtnNewBook).DisplayIndex = 2
        Dgl1.Columns(Col1Writer).DisplayIndex = 3
        Dgl1.Columns(Col1Publisher).DisplayIndex = 4
        Dgl1.Columns(Col1Edition).DisplayIndex = 5

        CType(Dgl1.Columns(Col1ReqQty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
    End Sub

    Private Sub FrmBookRequisition_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer = 0
        For I = 0 To Dgl1.Rows.Count - 1
            Dgl1.Item(Col1ReqQty, I).Value = Format(Dgl1.Item(Col1ReqQty, I).Value, "0")
            Validating_BookItem(Dgl1.AgSelectedValue(Col1Item, I), I)
        Next
        Call ProcAdjustEdition(TxtV_Type.AgSelectedValue)
    End Sub

    Private Sub FrmYarnSKUOpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 538, 885)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND ItemType IN( '" & ClsMain.ItemType.Book & "','" & ClsMain.ItemType.Generals & "') "
        End Select
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
                    If Dgl1.AgSelectedValue(Col1Item, mRowIndex) = "" And Dgl1.Item(Col1Item, mRowIndex).Value = "" Then
                        Dgl1.AgSelectedValue(Col1Writer, mRowIndex) = ""
                        Dgl1.AgSelectedValue(Col1Publisher, mRowIndex) = ""
                    Else
                        If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                            DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, mRowIndex)) & "")
                            Validating_BookItem(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
                        End If
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellContentClick
        Dim FrmObj As Form = Nothing
        Dim bColumnIndex As Integer = 0
        Dim bRowIndex As Integer = 0
        Dim I As Integer = 0
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

            bColumnIndex = Dgl1.CurrentCell.ColumnIndex
            bRowIndex = Dgl1.CurrentCell.RowIndex

            Select Case Dgl1.Columns(e.ColumnIndex).Name
                Case Col1BtnNewBook
                    If Dgl1.CurrentCell.RowIndex = Dgl1.RowCount - 1 Then
                        Dgl1.Rows.Add()

                        Dgl1.CurrentCell = Dgl1(Col1Item, bRowIndex)
                        Dgl1.Item(ColSNo, bRowIndex).Value = bRowIndex + 1
                    End If

                    Call ProcCreateNewBook(bRowIndex)
            End Select

            Call Calculation()
        Catch ex As Exception
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

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Book Requisition"
            RepName = "Lib_BookRequisition_Print" : RepTitle = "Book Requisition"
            bTableName = "Requisition" : bSecTableName = "RequisitionDetail R1 ON R1.DocID =R.DocID"
            bCondstr = "WHERE R.DocID='" & mInternalCode & "'"

            strQry = " SELECT  R.DocID, R.V_Type, R.V_Prefix, R.V_Date, R.V_No, R.Div_Code, R.Site_Code," & _
                    " R.Department, SG.DispName AS RequisitionBy, R.Remarks, R.TotalQty, R.TotalMeasure, R.EntryBy, " & _
                    " R.EntryDate, R.EntryType, R.EntryStatus, R.ApproveBy, R.ApproveDate, R.MoveToLog, " & _
                    " R.MoveToLogDate, R.IsDeleted, R.Status, R.UID, " & _
                    " R1.Sr, R1.Item, R1.Qty, R1.Unit, R1.MeasurePerPcs, R1.MeasureUnit, " & _
                    " R1.TotalMeasure, R1.RequireDate, R1.UID, R1.PurchaseIndent, " & _
                    " SM.Name AS SiteName,I.Description AS ItemDesc, I.Unit,B.Writer,B.Publisher  " & _
                    " FROM " & bTableName & " R " & _
                    " LEFT JOIN " & bSecTableName & " " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=R.Site_Code  " & _
                    " LEFT JOIN Item I ON I.Code=R1.Item  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=I.Code " & _
                    " LEFT JOIN SUBGROUP SG ON SG.SubCode=R.RequisitionBy " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type=R.V_Type  " & _
                    " " & bCondstr & ""

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

    Private Sub FrmBookRequisition_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtRequisitionBy.AgHelpDataSet(5, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = RequisitionByHelpDataSet
        Dgl1.AgHelpDataSet(Col1Edition, , , , , True) = EditionHelpDataSet
        Dgl1.AgHelpDataSet(Col1Item, 23) = ItemHelpDataSet
    End Sub

    Private Sub FrmBookRequisition_BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer) Handles Me.BaseFunction_MoveRecLine
        Dim DsTemp As DataSet = Nothing
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * from RequisitionDetail where DocId = '" & SearchCode & "' And Sr = " & Val(Sr) & "  "
        Else
            mQry = "Select * from RequisitionDetail_Log where UID = '" & SearchCode & "' And Sr = " & Val(Sr) & "  "
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                Dgl1.Item(Col1Edition, mGridRow).Value = AgL.XNull(.Rows(0)("Edition"))
            End If
        End With
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating
        Select Case sender.NAME
            Case TxtV_Type.Name
                Call ProcAdjustEdition(TxtV_Type.AgSelectedValue)
        End Select
    End Sub

    Private Sub ProcAdjustEdition(ByVal NCat As String)
        Try
            If NCat = ClsMain.Temp_NCat.NewBookRequisition Then
                Dgl1.Columns(Col1Edition).Visible = False
            Else
                Dgl1.Columns(Col1Edition).Visible = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmBookRequisition_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = " SELECT M.SubCode AS Code,SG.DispName AS MemberName ,isnull(SG.IsDeleted,0) AS IsDeleted, SG.Div_Code , " & _
                " isnull(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status ,M.MemberType,M.ReminderRemark " & _
                " FROM Lib_Member M " & _
                " LEFT JOIN SubGroup SG ON SG.SubCode=M.SubCode " & _
                " Where " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & " "
        RequisitionByHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT  L.Edition AS Code, L.Edition  FROM RequisitionDetail L WHERE L.Edition IS NOT NULL "
        EditionHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        IniItemHelpDataSet()
    End Sub

    Private Sub IniItemHelpDataSet()
        Try
            mQry = "SELECT I.Code, I.Description , B.Writer, B.Publisher, S.Description As SubjectName, I.Unit, " & _
                    " I.ItemType, I.DisplayName, I.SalesTaxPostingGroup , " & _
                    " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                    " B.Series, B.Subject, B.Volume, B.Language, B.ISBN, " & _
                    " B.WithCD, B.GodownCD, B.GodownSectionCD, " & _
                    " ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                    " I.Measure, i.MeasureUnit, B.Writer, B.Publisher, B.Series, B.WithCD, " & _
                    " S.Prefix, B.CD_ItemCode As CdItemCode " & _
                    " FROM Lib_Book B " & _
                    " LEFT JOIN Item I ON B.Code = I.Code " & _
                    " LEFT JOIN Lib_Subject S On B.Subject  = S.Code "
            ItemHelpDataSet = AgL.FillData(mQry, AgL.GCn)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcCreateNewBook(ByVal bRowIndex As Integer)
        Dim FrmObj As Form = Nothing
        Try
            FrmObj = New FrmNewBook()
            CType(FrmObj, FrmNewBook).EntryMode = Topctrl1.Mode

            CType(FrmObj, FrmNewBook).Book = Dgl1.AgSelectedValue(Col1Item, bRowIndex)
            CType(FrmObj, FrmNewBook).Publisher = AgL.XNull(Dgl1.Item(Col1Publisher, bRowIndex).Value)
            CType(FrmObj, FrmNewBook).Writer = AgL.XNull(Dgl1.Item(Col1Writer, bRowIndex).Value)

            FrmObj.ShowDialog()

            If CType(FrmObj, FrmNewBook).mIsOkClicked Then
                Dgl1.AgSelectedValue(Col1Item, bRowIndex) = ""
                Dgl1.Item(Col1Publisher, bRowIndex).Value = ""
                Dgl1.Item(Col1Writer, bRowIndex).Value = ""

                If CType(FrmObj, FrmNewBook).TxtBook.Text <> "" Then
                    IniItemHelpDataSet()
                    Ini_List()
                    Dgl1.AgSelectedValue(Col1Item, bRowIndex) = CType(FrmObj, FrmNewBook).TxtBook.AgSelectedValue
                    Dgl1.Item(Col1Publisher, bRowIndex).Value = CType(FrmObj, FrmNewBook).TxtPublisher.Text
                    Dgl1.Item(Col1Writer, bRowIndex).Value = CType(FrmObj, FrmNewBook).TxtWriter.Text

                    If AgL.XNull(Dgl1.Item(Col1ReqDate, bRowIndex).Value).ToString.Trim = "" Then
                        Dgl1.Item(Col1ReqDate, bRowIndex).Value = TxtV_Date.Text
                    End If
                End If


                Validating_BookItem(Dgl1.AgSelectedValue(Col1Item, bRowIndex), bRowIndex)
                Call Calculation()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
