Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmBarCodePrint
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs

    Dim mQry$ = "", mSearchCode$ = "", mHeaderTable$ = ""
    Dim mIsPackingBarCode As Boolean = False

    Private Const Col1Select As String = "Select"
    Private Const Col1BookId As String = "Book Id"
    Private Const Col1AccessionNo As String = "Accession No"
    Private Const Col1BookCode As String = "Book Code"
    Private Const Col1BookTitle As String = "Book Title"
    Private Const Col1CallNo As String = "Call No"


    Public Property BarCodeDocId() As String
        Get
            BarCodeDocId = mSearchCode
        End Get
        Set(ByVal value As String)
            mSearchCode = value
        End Set
    End Property

    Public Property IsPackingBarCode() As Boolean
        Get
            IsPackingBarCode = mIsPackingBarCode
        End Get
        Set(ByVal value As Boolean)
            mIsPackingBarCode = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, "***P", Nothing)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub FrmBarCodePrint_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            FIniMaster()
            DispText()
            IniGrid()
            Inilist()
            AgL.GridDesign(Dgl1)
            Dgl1.MultiSelect = True
            Call MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr$ = " Where 1=1 "
        mQry = "SELECT I.TABLE_NAME FROM INFORMATION_SCHEMA.Tables I WHERE 1=2"
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        With AgCL
            .AddAgCheckColumn(Dgl1, Col1Select, 60, Col1Select, True)
            .AddAgTextColumn(Dgl1, Col1BookId, 100, 0, Col1BookId, True, False)
            .AddAgTextColumn(Dgl1, Col1AccessionNo, 100, 0, Col1AccessionNo, True, False)
            .AddAgTextColumn(Dgl1, Col1BookTitle, 290, 0, Col1BookTitle, True, True)
            .AddAgTextColumn(Dgl1, Col1BookCode, 110, 0, Col1BookCode, True, True)
            .AddAgTextColumn(Dgl1, Col1CallNo, 110, 0, Col1CallNo, True, True)

        End With
        Dgl1.EnableHeadersVisualStyles = False
    End Sub

    Private Sub Inilist()
        Try
            mQry = " SELECT Ad.Book_UID AS Code, Ad.Book_UID AS BookId, Ad.AccessionNo , I.ManualCode AS BookCode, " & _
                    " I.Description AS BookTitle ,Ad.CallNo " & _
                    " FROM Lib_AccessionDetail Ad " & _
                    " LEFT JOIN Lib_Accession A ON Ad.DocID = A.DocID " & _
                    " LEFT JOIN Item I ON Ad.Book = I.Code " & _
                    " Where " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "
            Dgl1.AgHelpDataSet(Col1BookId) = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT Ad.Book_UID AS Code,Ad.AccessionNo , Ad.Book_UID AS BookId,  I.ManualCode AS BookCode, " & _
                   " I.Description AS BookTitle ,Ad.CallNo " & _
                   " FROM Lib_AccessionDetail Ad " & _
                   " LEFT JOIN Lib_Accession A ON Ad.DocID = A.DocID " & _
                   " LEFT JOIN Item I ON Ad.Book = I.Code " & _
                   " Where " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "
            Dgl1.AgHelpDataSet(Col1AccessionNo) = AgL.FillData(mQry, AgL.GCn)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.ActiveControl IsNot Nothing Then
            If Me.ActiveControl.Name <> Topctrl1.Name And _
                Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub MoveRec()
        Dim DtTemp As DataTable
        Dim I As Integer = 0
        Try
            BlankText()
            If mSearchCode.Trim <> "" Then
                mQry = "SELECT Ad.Book_UID , Ad.AccessionNo , " & _
                        " I.Description As BookTitle, I.ManualCode As BookCode,Ad.CallNo  " & _
                        " FROM Lib_AccessionDetail Ad " & _
                        " LEFT JOIN Item I ON Ad.Book = I.Code " & _
                        " Where Ad.DocId ='" & mSearchCode & "' "

                DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

                With DtTemp
                    Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
                    For I = 0 To .Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(Col1Select, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                        Dgl1.Item(Col1BookId, I).Value = AgL.XNull(.Rows(I)("Book_UID"))
                        Dgl1.Item(Col1AccessionNo, I).Value = AgL.XNull(.Rows(I)("AccessionNo"))
                        Dgl1.Item(Col1BookCode, I).Value = AgL.XNull(.Rows(I)("BookCode"))
                        Dgl1.Item(Col1BookTitle, I).Value = AgL.XNull(.Rows(I)("BookTitle"))
                        Dgl1.Item(Col1CallNo, I).Value = AgL.XNull(.Rows(I)("CallNo"))
                    Next
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub DispText()
        'Coding To Enable/Disable Controls
        TxtSkipLables.Enabled = True
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes()
        DGL1.DataSource = Nothing
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click, BtnExit.Click
        Try
            Select Case sender.name
                Case BtnPrint.Name
                    Call PrintReport()

                Case BtnExit.Name
                    Me.Dispose()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub PrintReport()
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim DsRep As DataSet = Nothing
        Dim I As Integer
        Try
            Me.Cursor = Cursors.WaitCursor


            RepName = "RepBarCode" : RepTitle = "Item Barcode"

            If Val(TxtSkipLables.Text) > 0 Then
                For I = 1 To Val(TxtSkipLables.Text)
                    If strQry.Trim <> "" Then strQry = strQry & " UNION ALL "
                    strQry = strQry & " Select null As [Book_Uid], " & _
                            " Null As AccessionNo, Null As BookCode, Null As BookTitle "
                Next
            End If

            With Dgl1
                For I = 0 To .Rows.Count - 1
                    If AgL.StrCmp(.Item(Col1Select, I).Value, AgLibrary.ClsConstant.StrCheckedValue) _
                        And .Item(Col1BookId, I).Value <> "" Then
                        If strQry.Trim <> "" Then strQry = strQry & " UNION ALL "
                        strQry = strQry & " Select " & AgL.Chk_Text(.Item(Col1BookId, I).Value) & " As [Book_Uid], " & _
                                " " & AgL.Chk_Text(.Item(Col1AccessionNo, I).Value) & " As AccessionNo, " & _
                                " " & AgL.Chk_Text(.Item(Col1BookCode, I).Value) & " As BookCode, " & _
                                " " & AgL.Chk_Text(.Item(Col1BookTitle, I).Value) & " As BookTitle, " & _
                                " " & AgL.Chk_Text(.Item(Col1CallNo, I).Value) & " As CallNo "
                    End If
                Next
            End With

            If strQry.Trim <> "" Then
                DsRep = AgL.FillData(strQry, AgL.GCn)
                AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
                ''''''''''IF CUSTOMER NEED SOME CHANGE IN FORMAT OF A REPORT'''''''''''
                ''''''''''CUTOMIZE REPORT CAN BE CREATED WITHOUT CHANGE IN CODE''''''''
                ''''''''''WITH ADDING 6 CHAR OF COMPANY NAME AND 4 CHAR OF CITY NAME'''
                ''''''''''WITHOUT SPACES IN EXISTING REPORT NAME''''''''''''''''''''''''''''''''''''''
                RepName = AgPL.GetRepNameCustomize(RepName, AgL.PubReportPath)
                '''''''''''''''''''''''''''''''''''''''''''''''''''''

                mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
                mCrd.SetDataSource(DsRep.Tables(0))
                CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
                AgPL.Formula_Set(mCrd, RepTitle)
                AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)
                Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            DsRep = Nothing
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1AccessionNo
                    If AgL.XNull(Dgl1.Item(Col1BookId, mRowIndex).Value).ToString.Trim <> "" Then
                        Dgl1.AgRowFilter(mColumnIndex) = " Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1BookId, mRowIndex)) & " "
                    Else
                        Dgl1.AgRowFilter(mColumnIndex) = ""
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        'If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Try
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col1Select
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(sender, sender.Columns(sender.Columns(sender.CurrentCell.ColumnIndex).Name).Index)
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgl1.CellMouseUp
        'If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = sender.CurrentCell.RowIndex
            mColumnIndex = sender.CurrentCell.ColumnIndex

            If sender.Item(mColumnIndex, mRowIndex).Value Is Nothing Then sender.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col1Select
                    Call AgL.ProcSetCheckColumnCellValue(sender, sender.Columns(sender.Columns(sender.CurrentCell.ColumnIndex).Name).Index)
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded
        Dgl1.Item(Col1Select, e.RowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue
    End Sub

    Protected Overridable Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1BookId
                    If Dgl1.Item(Col1BookId, mRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1BookId, mRowIndex).ToString.Trim = "" Then
                        Dgl1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                        Dgl1.AgSelectedValue(Col1AccessionNo, mRowIndex) = ""
                        Dgl1.Item(Col1BookTitle, mRowIndex).Value = ""
                        Dgl1.Item(Col1BookCode, mRowIndex).Value = ""
                        Dgl1.Item(Col1CallNo, mRowIndex).Value = ""
                    Else
                        If Dgl1.AgHelpDataSet(Col1BookId) IsNot Nothing Then
                            DrTemp = Dgl1.AgHelpDataSet(Col1BookId).Tables(0).Select("Code = '" & Dgl1.Item(Col1BookId, mRowIndex).Value & "'")
                            Dgl1.AgSelectedValue(Col1AccessionNo, mRowIndex) = AgL.XNull(DrTemp(0)("Code"))
                            Dgl1.Item(Col1BookTitle, mRowIndex).Value = AgL.XNull(DrTemp(0)("BookTitle"))
                            Dgl1.Item(Col1BookCode, mRowIndex).Value = AgL.XNull(DrTemp(0)("BookCode"))
                            Dgl1.Item(Col1CallNo, mRowIndex).Value = AgL.XNull(DrTemp(0)("CallNo"))
                        End If
                    End If

                Case Col1AccessionNo
                    If Dgl1.Item(Col1AccessionNo, mRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1AccessionNo, mRowIndex).ToString.Trim = "" Then
                        Dgl1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                        Dgl1.AgSelectedValue(Col1BookId, mRowIndex) = ""
                        Dgl1.Item(Col1BookTitle, mRowIndex).Value = ""
                        Dgl1.Item(Col1BookCode, mRowIndex).Value = ""
                        Dgl1.Item(Col1CallNo, mRowIndex).Value = ""
                    Else
                        If Dgl1.AgHelpDataSet(Col1AccessionNo) IsNot Nothing Then
                            DrTemp = Dgl1.AgHelpDataSet(Col1AccessionNo).Tables(0).Select("AccessionNo = '" & Dgl1.Item(Col1AccessionNo, mRowIndex).Value & "'")
                            Dgl1.AgSelectedValue(Col1BookId, mRowIndex) = AgL.XNull(DrTemp(0)("Code"))
                            Dgl1.Item(Col1BookTitle, mRowIndex).Value = AgL.XNull(DrTemp(0)("BookTitle"))
                            Dgl1.Item(Col1BookCode, mRowIndex).Value = AgL.XNull(DrTemp(0)("BookCode"))
                            Dgl1.Item(Col1CallNo, mRowIndex).Value = AgL.XNull(DrTemp(0)("CallNo"))
                        End If
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class