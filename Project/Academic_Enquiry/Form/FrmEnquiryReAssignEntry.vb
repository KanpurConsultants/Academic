Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmEnquiryReAssignEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mBlnIsRecordsExists As Boolean = False

    Dim mObjClsMain As New ClsMain(AgL, PLib)
    Dim mStrColumnName$ = ""


    Public Const ColSNo As String = "S. No."

    'Grid1
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1Tick As String = "Tick"
    Protected Const Col1EnquiryDocId As String = "Enquiry DocId"
    Protected Const Col1EnquiryNo As String = "Enquiry No"
    Protected Const Col1EnquiryDate As String = "Enquiry Date"
    Protected Const Col1EnquiryBy As String = "Enquiry By"
    Protected Const Col1EnquiryMode As String = "Enquiry Mode"
    Protected Const Col1Candidate As String = "Candidate"
    Protected Const Col1TransferFrom As String = "Transfer From"
    Protected Const Col1AssignTo As String = "Assign To"
   
    ''=====================================================================
    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"

    Private Enum FilterType
        Similer
        Dissimilar
        Remove
    End Enum

    Public Property EntryMode() As String
        Get
            EntryMode = _EntryMode
        End Get
        Set(ByVal value As String)
            _EntryMode = value
        End Set
    End Property

    Public Property FormLocation() As System.Drawing.Point
        Get
            FormLocation = _FormLocation
        End Get
        Set(ByVal value As System.Drawing.Point)
            _FormLocation = value
        End Set
    End Property
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Dim StrUPVar As String = "A***", DTUP As DataTable = Nothing
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        DTMaster = Nothing : mObjClsMain = Nothing
    End Sub

    Private Sub IniGrid()
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgCheckColumn(Dgl1, Col1Tick, 60, Col1Tick, True)
            .AddAgTextColumn(Dgl1, Col1EnquiryDocId, 60, 20, Col1EnquiryDocId, False, False, False)
            .AddAgTextColumn(Dgl1, Col1EnquiryNo, 110, 20, Col1EnquiryNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1EnquiryDate, 80, 20, Col1EnquiryDate, True, True, False)
            .AddAgTextColumn(Dgl1, Col1EnquiryBy, 140, 20, Col1EnquiryBy, True, True, False)
            .AddAgTextColumn(Dgl1, Col1EnquiryMode, 90, 20, Col1EnquiryMode, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Candidate, 140, 20, Col1Candidate, True, True, False)
            .AddAgTextColumn(Dgl1, Col1TransferFrom, 140, 20, Col1TransferFrom, True, True, False)
            .AddAgTextColumn(Dgl1, Col1AssignTo, 150, 20, Col1AssignTo, True, False, False)
        End With
        Dgl1.RowTemplate.Height = 20
        ''==============================================================================
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.ColumnHeadersHeight = 40
        Dgl1.AllowUserToAddRows = False
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
        Dgl1.ContextMenuStrip = CMnu
        Dgl1.AgSkipReadOnlyColumns = True
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 Then
            Topctrl1.TopKey_Down(e)
        End If


        If Me.ActiveControl IsNot Nothing Then
            If Me.ActiveControl.Name <> Topctrl1.Name And _
                Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub
    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            AgL.WinSetting(Me, 650, 1000, _FormLocation.Y, _FormLocation.X)
            AgL.GridDesign(Dgl1)
            IniGrid()
            Topctrl1.ChangeAgGridState(Dgl1, False)
            FIniMaster()
            Ini_List()
            DispText()

            _EntryMode = "Add"
            If AgL.StrCmp(_EntryMode, "Add") Then
                Topctrl1.FButtonClick(0)
            Else
                MoveRec()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr$ = " WHERE 1=2 "

        mQry = "SELECT H.DocId AS SearchCode " & _
                " FROM Enquiry_Enquiry H  With (NoLock) " & mCondStr

        Topctrl1.FIniForm(DTMaster, AgL.GcnRead, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code, Code as Name From Sch_EnquiryMode "
            TxtEnquiryMode.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT E.SubCode AS Code, SG.DispName AS Employee, Sg.LogInUser, " & _
                  " CASE WHEN E.DateOfResign IS NOT NULL THEN 'Yes' ELSE 'No' END AS IsLeft, " & _
                  " E.DateOfResign As [Resign Date] " & _
                  " FROM Pay_Employee E With (NoLock)" & _
                  " LEFT JOIN SubGroup SG With (NoLock) ON SG.SubCode=E.SubCode  " & _
                  " WHERE 1=1 " & _
                  " ORDER BY SG.DispName  "
            TxtAssignedTo.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)
            TxtTransferFrom.AgHelpDataSet(3) = TxtAssignedTo.AgHelpDataSet.Copy
            Dgl1.AgHelpDataSet(Col1TransferFrom, 3) = TxtAssignedTo.AgHelpDataSet.Copy
            Dgl1.AgHelpDataSet(Col1AssignTo, 3) = TxtAssignedTo.AgHelpDataSet.Copy


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        '<Executable code>
        BlankText()
        DispText(True)

        TxtSelectAll.Text = "Yes"
        Call ProcValidatingControl(TxtSelectAll)

        TxtEnquiryMode.Focus()
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        '<Executable code>
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
        DispText(False)
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        '<Executable code>
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        '<Executable code>
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        '<Executable Code>
    End Sub

    Public Sub ProcRefreshForm()
        FIniMaster(0, 1)
        Topctrl1_tbRef()
        MoveRec()
    End Sub

    Public Sub MoveRec()
        '<Executable code>
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        Dgl1.Rows.Clear()
        mSearchCode = "" : mBlnIsRecordsExists = False

        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            '<Executable Code>
        End If
    End Sub

    Private Sub FClear()
        DTStruct.Clear()
    End Sub

    Private Sub FAddRowStructure()
        Dim DRStruct As DataRow
        Try
            DRStruct = DTStruct.NewRow
            DTStruct.Rows.Add(DRStruct)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Try
            Call Calculation()

            AgCL.AgBlankNothingCells(Dgl1)

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim bStrFilter$ = ""
        Try
            Select Case sender.name

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSelectAll.Validating, TxtSelectTopRows.Validating, TxtAssignedTo.Validating, TxtEnquiryMode.Validating, _
        TxtTransferFrom.Validating
        Try
            Select Case sender.name
                Case TxtSelectAll.Name, TxtSelectTopRows.Name
                    Call ProcValidatingControl(sender)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim bIntI% = 0

        With Dgl1
            For bIntI = 0 To .Rows.Count - 1
                If .Item(Col1Tick, bIntI).Value Is Nothing Then .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                If .Item(Col1Tick, bIntI).Value = "" Then .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                If AgL.XNull(.AgSelectedValue(Col1AssignTo, bIntI)) <> "" Then
                    If .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue Then
                        Dgl1.AgSelectedValue(Col1AssignTo, bIntI) = ""
                    End If
                Else
                    If .Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                        If TxtAssignedTo.Text.Trim <> "" Then
                            Dgl1.AgSelectedValue(Col1AssignTo, bIntI) = TxtAssignedTo.AgSelectedValue
                        End If
                    End If
                End If
            Next
        End With

    End Sub

    Private Sub ProcFillGrid()

        Dim DsTemp As DataSet = Nothing
        Dim bCondStr$ = "Where 1=1 "
        Dim I As Integer = 0

        Try

            bCondStr += " And IsNull(H.IsClosed,0) = 0 "

            If TxtEnquiryMode.Text.Trim <> "" Then
                bCondStr += " And H.EnquiryMode = " & AgL.Chk_Text(TxtEnquiryMode.AgSelectedValue) & " "
            End If

            If TxtTransferFrom.Text.Trim <> "" Then
                bCondStr += " And H.AssignedTo = " & AgL.Chk_Text(TxtTransferFrom.AgSelectedValue) & " "
            Else
                bCondStr += " And H.AssignedTo Is Null "
            End If

            mQry = "SELECT H.DocId AS Code, " & AgL.V_No_Field("H.DocId") & " As [Enquiry No],H.V_Date AS [Enquiry Date], SG.DispName AS [Enquiry By], " & _
                    " isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS Name, " & _
                    " H.EnquiryMode AS [Enquiry Mode],C.CityName AS City,isnull(H.IsClosed,0)  AS IsClosed, " & _
                    " H.Employee As EmployeeCode, H.AssignedTo As AssignedToCode, Sg.LogInUser As EmployeeUser, E2.LogInUser As AssignedToUser,E2..DispName AS [Assign To]  " & _
                    " FROM Enquiry_Enquiry H  With (NoLock) " & _
                    " LEFT JOIN SubGroup SG With (NoLock) ON SG.SubCode=H.Employee " & _
                    " LEFT JOIN SubGroup E2 With (NoLock) ON E2.SubCode=H.AssignedTo " & _
                    " LEFT JOIN City C With (NoLock) ON C.CityCode=H.CityCode  " & _
                    "" & bCondStr & ""
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        Dgl1.Rows.Add()

                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count

                        If AgL.StrCmp(TxtSelectAll.Text, "Yes") Then
                            If TxtAssignedTo.Text.Trim <> "" Then
                                Dgl1.Item(Col1Tick, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                            Else
                                Dgl1.Item(Col1Tick, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                            End If
                        Else
                            If I < Val(TxtSelectTopRows.Text) Then
                                Dgl1.Item(Col1Tick, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                            Else
                                Dgl1.Item(Col1Tick, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                            End If
                        End If

                        Dgl1.Item(Col1EnquiryDocId, I).Value = AgL.XNull(.Rows(I)("Code"))
                        Dgl1.Item(Col1EnquiryNo, I).Value = AgL.XNull(.Rows(I)("Enquiry No"))
                        Dgl1.Item(Col1EnquiryDate, I).Value = Format(AgL.XNull(.Rows(I)("Enquiry Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        Dgl1.Item(Col1EnquiryBy, I).Value = AgL.XNull(.Rows(I)("Enquiry By"))
                        Dgl1.Item(Col1EnquiryMode, I).Value = AgL.XNull(.Rows(I)("Enquiry Mode"))
                        Dgl1.Item(Col1Candidate, I).Value = AgL.XNull(.Rows(I)("Name"))
                        Dgl1.AgSelectedValue(Col1TransferFrom, I) = AgL.XNull(.Rows(I)("AssignedToCode"))

                        If Dgl1.Item(Col1Tick, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                            Dgl1.AgSelectedValue(Col1AssignTo, I) = AgL.XNull(TxtAssignedTo.AgSelectedValue)
                        End If

                    Next
                    Dgl1.CurrentCell = Dgl1(Col1AssignTo, 0) : Dgl1.Focus()
                End If
            End With

            Call Calculation()
        Catch ex As Exception
            Dgl1.DataSource = Nothing

            MsgBox(ex.Message)
        Finally

            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnFillGrid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillGrid.Click
        Try
            Call ProcFillGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Dim mTrans As Boolean = False
        Dim bIntI% = 0
        Dim I As Integer
        Try
            Me.Cursor = Cursors.WaitCursor

            If MsgBox("Are You Sure To Update?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = MsgBoxResult.No Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            With Dgl1
                For I = 0 To .Rows.Count - 1
                    If AgL.XNull(.AgSelectedValue(Col1AssignTo, I)) <> "" _
                        And AgL.XNull(.Item(Col1Tick, bIntI).Value).ToString = AgLibrary.ClsConstant.StrCheckedValue Then

                        mQry = " UPDATE Enquiry_Enquiry " & _
                                   " SET  AssignedTo = " & AgL.Chk_Text(.AgSelectedValue(Col1AssignTo, I)) & " " & _
                                   " WHERE DocId = " & AgL.Chk_Text(.Item(Col1EnquiryDocId, I).Value) & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With

            AgL.ETrans.Commit()
            mTrans = False

            MsgBox("Update Completed!...")

            If Topctrl1.Mode = "Add" Then
                Topctrl1.FButtonClick(0)
            End If

        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Dgl1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""

            With Dgl1
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col1AssignTo
                        If Dgl1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                            Dgl1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                            Dgl1.Item(Col1Tick, mRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                        Else
                            If Dgl1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                                DrTemp = Dgl1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
                                Dgl1.Item(Col1Tick, mRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue
                            End If
                            DrTemp = Nothing
                        End If
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Tick
                    If e.KeyCode = Keys.Space Then
                        AgCL.ProcSetCheckColumnCellValue(Dgl1, Dgl1.Columns(Col1Tick).Index)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgl1.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Tick
                    AgCL.ProcSetCheckColumnCellValue(Dgl1, Dgl1.Columns(Col1Tick).Index)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub MnuExportToExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _
            MnuExportToExcel.Click
        Dim bStrFileName$ = ""
        Try
            Select Case sender.name
                Case MnuExportToExcel.Name
                    If MsgBox("Want to Export Grid Data", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Export Grid?...") = vbNo Then Exit Sub
                    bStrFileName = AgControls.Export.GetFileName(My.Computer.FileSystem.SpecialDirectories.Desktop)

                    If bStrFileName.Trim <> "" Then
                        Call AgControls.Export.exportExcel(Dgl1, bStrFileName, Dgl1.Handle)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtAssignedTo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtAssignedTo.Validating, TxtTransferFrom.Validating
        Try
            Select Case sender.NAME
                Case TxtAssignedTo.Name, TxtTransferFrom.Name
                    If TxtAssignedTo.AgSelectedValue <> "" Then
                        If TxtAssignedTo.AgSelectedValue = TxtTransferFrom.AgSelectedValue Then
                            MsgBox("Assign To And Transfer From Should Not Be Same !")
                            TxtAssignedTo.Focus()
                            Exit Sub
                        End If
                    End If
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnChargeDuw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub ProcValidatingControl(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtSelectAll.Name, TxtSelectTopRows.Name
                If AgL.StrCmp(TxtSelectAll.Text, "Yes") Then
                    TxtSelectTopRows.Text = ""
                End If
        End Select
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellValueChanged
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Tick
                    Call Calculation()
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class

