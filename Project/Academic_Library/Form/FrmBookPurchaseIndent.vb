Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmBookPurchaseIndent
    Inherits AgTemplate.TempPurchIndentReq

    Protected Const Col2Writer As String = "Writer"
    Protected Const Col2Publisher As String = "Publisher"
    Protected Const Col1Writer As String = "Writer"
    Protected Const Col1Publisher As String = "Publisher"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.BookIndent
        Me.RequistionNCat = "'" & ClsMain.Temp_NCat.NewBookRequisition & "'"
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Panel2.SuspendLayout()
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
        'PnlReq
        '
        Me.PnlReq.Location = New System.Drawing.Point(0, 184)
        Me.PnlReq.Size = New System.Drawing.Size(871, 122)
        '
        'BtnFillIndentDetail
        '
        Me.BtnFillIndentDetail.Location = New System.Drawing.Point(725, 333)
        '
        'BtnFillRequisition
        '
        Me.BtnFillRequisition.Location = New System.Drawing.Point(725, 160)
        '
        'LinkLabel2
        '
        Me.LinkLabel2.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel2.Location = New System.Drawing.Point(0, 161)
        '
        'Panel2
        '
        Me.Panel2.Location = New System.Drawing.Point(0, 306)
        Me.Panel2.Size = New System.Drawing.Size(973, 21)
        Me.Panel2.Visible = True
        '
        'LblTotalReqMeasureQty
        '
        Me.LblTotalReqMeasureQty.Visible = False
        '
        'LblTotalMeasureTextReq
        '
        Me.LblTotalMeasureTextReq.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(0, 495)
        Me.Panel1.Size = New System.Drawing.Size(974, 21)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(0, 356)
        Me.Pnl1.Size = New System.Drawing.Size(871, 138)
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
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.Location = New System.Drawing.Point(0, 333)
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(907, 4)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(0, 19)
        Me.TabControl1.Size = New System.Drawing.Size(871, 139)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(863, 113)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(869, 41)
        '
        'FrmBookPurchaseIndent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(869, 566)
        Me.LogLineTableCsv = "PurchIndentDetail_Log,PurchIndentReq_Log"
        Me.LogTableName = "PurchIndent_Log"
        Me.MainLineTableCsv = "PurchIndentDetail,PurchIndentReq"
        Me.MainTableName = "PurchIndent"
        Me.Name = "FrmBookPurchaseIndent"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
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

    Private Sub FrmBoolPurchaseIndent1_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0")
        LblTotalReqQty.Text = Format(Val(LblTotalReqQty.Text), "0")
    End Sub

    Private Sub FrmYarnSKUOpeningStock_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid

        Dgl1.Columns(Col1Item).HeaderText = "Book"
        Dgl1.Columns(Col1MeasurePerPcs).Visible = False
        Dgl1.Columns(Col1MeasureUnit).Visible = False
        Dgl1.Columns(Col1TotalIndentMeasure).Visible = False
        With AgCL
            .AddAgTextColumn(Dgl1, Col1Writer, 130, 100, Col1Writer, True, True)
            .AddAgTextColumn(Dgl1, Col1Publisher, 130, 100, Col1Publisher, True, True)
        End With
        Dgl1.Columns(Col1Writer).DisplayIndex = 2
        Dgl1.Columns(Col1Publisher).DisplayIndex = 3
        CType(Dgl1.Columns(Col1ReqQty), AgControls.AgTextColumn).AgNumberRightPlaces = 0
        CType(Dgl1.Columns(Col1IndentQty), AgControls.AgTextColumn).AgNumberRightPlaces = 0

        Dgl2.Columns(Col2Item).HeaderText = "Book"
        Dgl2.Columns(Col2MeasurePerPcs).Visible = False
        Dgl2.Columns(Col2MeasureUnit).Visible = False
        Dgl2.Columns(Col2TotalReqMeasure).Visible = False
        With AgCL
            .AddAgTextColumn(Dgl2, Col2Writer, 130, 100, Col2Writer, True, True)
            .AddAgTextColumn(Dgl2, Col2Publisher, 130, 100, Col2Publisher, True, True)
        End With
        Dgl2.Columns(Col2Writer).DisplayIndex = 3
        Dgl2.Columns(Col2Publisher).DisplayIndex = 4
        CType(Dgl2.Columns(Col2ReqQty), AgControls.AgTextColumn).AgNumberRightPlaces = 0

    End Sub

    Private Sub FrmBookPurchaseIndent_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer = 0
        For I = 0 To Dgl2.Rows.Count - 1
            Validating_BookItem(Dgl2.AgSelectedValue(Col2Item, I), I, Dgl2)
        Next

        For I = 0 To Dgl1.Rows.Count - 1
            Validating_BookItem(Dgl1.AgSelectedValue(Col1Item, I), I, Dgl1)
        Next
    End Sub

    Private Sub Dgl2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl2.CellEnter
        If Dgl2.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl2.Columns(Dgl2.CurrentCell.ColumnIndex).Name
            Case Col2Item
                Dgl2.AgRowFilter(Dgl2.Columns(Col2Item).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND ItemType IN( '" & ClsMain.ItemType.Book & "','" & ClsMain.ItemType.Generals & "') "

            Case Col2RequisionNo
                Dgl2.AgRowFilter(Dgl2.Columns(Col2RequisionNo).Index) = " NCat = '" & ClsMain.Temp_NCat.NewBookRequisition & "' "
        End Select
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " ItemType IN( '" & ClsMain.ItemType.Book & "','" & ClsMain.ItemType.Generals & "') AND IsDeleted = 0 And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "
        End Select
    End Sub


    Private Sub Validating_BookItem(ByVal Code As String, ByVal mRow As Integer, ByVal mGrid As AgControls.AgDataGrid)
        Dim mQry As String
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = " SELECT B.Writer,B.Publisher   FROM Lib_Book B " & _
                    " WHERE B.Code = '" & Code & "' "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            If DtTemp.Rows.Count > 0 Then
                mGrid.Item(Col1Writer, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Writer"))
                mGrid.Item(Col1Publisher, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Publisher"))
            Else
                mGrid.Item(Col1Writer, mRow).Value = ""
                mGrid.Item(Col1Publisher, mRow).Value = ""
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
                Case Col1Item
                    If Dgl1.AgSelectedValue(Col1Item, mRowIndex) = "" And Dgl1.Item(Col1Item, mRowIndex).Value = "" Then
                        Dgl1.AgSelectedValue(Col1Writer, mRowIndex) = ""
                        Dgl1.AgSelectedValue(Col1Publisher, mRowIndex) = ""
                    Else
                        If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                            DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, mRowIndex)) & "")
                            Validating_BookItem(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex, Dgl1)

                        End If
                    End If

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl2.CurrentCell.RowIndex
            mColumnIndex = Dgl2.CurrentCell.ColumnIndex
            If Dgl2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl2.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl2.Columns(Dgl2.CurrentCell.ColumnIndex).Name
                Case Col2Item
                    If Dgl2.AgSelectedValue(Col2Item, mRowIndex) = "" And Dgl2.Item(Col1Item, mRowIndex).Value = "" Then
                        Dgl2.AgSelectedValue(Col2Writer, mRowIndex) = ""
                        Dgl2.AgSelectedValue(Col2Publisher, mRowIndex) = ""
                    Else
                        If Dgl2.AgHelpDataSet(Col2Item) IsNot Nothing Then
                            DrTemp = Dgl2.AgHelpDataSet(Col2Item).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl2.AgSelectedValue(Col2Item, mRowIndex)) & "")
                            Validating_BookItem(Dgl2.AgSelectedValue(Col2Item, mRowIndex), mRowIndex, Dgl2)

                        End If
                    End If
                Case Col2RequisionNo
                    If Dgl2.AgSelectedValue(Col2Item, mRowIndex) = "" And Dgl2.Item(Col1Item, mRowIndex).Value = "" Then
                        Dgl2.AgSelectedValue(Col2Writer, mRowIndex) = ""
                        Dgl2.AgSelectedValue(Col2Publisher, mRowIndex) = ""
                    Else
                        If Dgl2.AgHelpDataSet(Col2Item) IsNot Nothing Then
                            DrTemp = Dgl2.AgHelpDataSet(Col2Item).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl2.AgSelectedValue(Col2Item, mRowIndex)) & "")
                            Validating_BookItem(Dgl2.AgSelectedValue(Col2Item, mRowIndex), mRowIndex, Dgl2)

                        End If
                    End If

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFillRequisition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillRequisition.Click
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim I As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            With Dgl2
                For I = 0 To Dgl2.RowCount - 1
                    If .AgSelectedValue(Col2Item, I) <> "" Then
                        Validating_BookItem(Dgl2.AgSelectedValue(Col2Item, I), I, Dgl2)
                    End If
                Next I
            End With
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFillIndentDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillIndentDetail.Click
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim I As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            With Dgl1
                For I = 0 To Dgl1.RowCount - 1
                    If .AgSelectedValue(Col1Item, I) <> "" Then
                        Validating_BookItem(Dgl1.AgSelectedValue(Col1Item, I), I, Dgl1)
                    End If
                Next I
            End With
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmBoolPurchaseIndent1_Load_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AgL.WinSetting(Me, 600, 885)
    End Sub
    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Book Purchase Indent"
            RepName = "Lib_BookPurchIndent_Print" : RepTitle = "Book Purchase Indent"
            bTableName = "PurchIndent" : bSecTableName = "PurchIndentDetail P1 ON P1.DocID =P.DocID"
            bCondstr = "WHERE P.DocID='" & mInternalCode & "'"


            strQry = " SELECT  P.DocID, P.V_Type, P.V_Prefix, P.V_Date, P.V_No, P.Div_Code, P.Site_Code, " & _
                    " P.Department, P.Indentor, P.Remarks, P.TotalQty, P.TotalMeasure, P.EntryBy, P.EntryDate, " & _
                    " P.EntryType, P.EntryStatus, P.ApproveBy, P.ApproveDate, P.MoveToLog, P.MoveToLogDate, P.IsDeleted, P.Status, P.UID, " & _
                    " P1.Sr, P1.Item, P1.CurrentStock, P1.ReqQty, P1.IndentQty, P1.Unit,P1.MeasurePerPcs, P1.MeasureUnit,  " & _
                    " P1.TotalReqMeasure AS LineTotalMeasure, P1.TotalIndentMeasure AS LineTotalIndentMeasure, P1.OrdQty, P1.OrdMeasure, " & _
                    " P1.PurchQty, P1.PurchMeasure, P1.RequireDate,SM.Name AS SiteName,I.Description AS ItemDesc, " & _
                    " B.Writer, B.Publisher " & _
                    " FROM " & bTableName & " P " & _
                    " LEFT JOIN " & bSecTableName & "  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=P.Site_Code  " & _
                    " LEFT JOIN Item I ON I.Code=P1.Item  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=P1.Item " & _
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

    Private Sub FrmBookPurchaseIndent_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtIndentor.AgHelpDataSet(, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = IndentorHelpDataSet
    End Sub

    Private Sub FrmBookPurchaseIndent_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = "SELECT E.SubCode AS Code, S.DispName AS [Employee Name], S.ManualCode AS [Employee Code]   " & _
                " FROM Pay_Employee E " & _
                " LEFT JOIN Subgroup S ON E.SubCode = S.SubCode  " & _
                " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "S.Site_Code", AgL.PubSiteCode, "S.CommonAc") & " "
        IndentorHelpDataSet = AgL.FillData(mQry, AgL.GCn)
    End Sub
End Class
