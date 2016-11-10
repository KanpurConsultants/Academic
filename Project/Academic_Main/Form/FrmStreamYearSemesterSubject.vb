Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmStreamYearSemesterSubject

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1_Subject As Byte = 1
    Private Const Col1_ManualCode As Byte = 2
    Private Const Col1_PaperID As Byte = 3
    Private Const Col1_MinCreditHours As Byte = 4
    Private Const Col1_IsElectiveSubject As Byte = 5
    Private Const Col1_Code As Byte = 6

    Dim mQry As String = "", mSearchCode As String = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        AgL.AddAgDataGrid(DGL1, Pnl1)

        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1Subject", 350, 50, "Subject", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1ManualCode", 150, 20, "Manual Code", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1PaperID", 80, 20, "Paper ID", True, False, False)
            .AddAgNumberColumn(DGL1, "Dgl1MinCreditHours", 80, 3, 2, False, "Credit Hours", True, False, True)
            .AddAgListColumn(DGL1, "Yes,No", "Dgl1IsElectiveHours", 60, "Yes,No", "Elective (Yes/No)", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1Code", 100, 50, "Code", False, False, False)
        End With
        DGL1.ColumnHeadersHeight = 40
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F4 Or e.KeyCode = (Keys.F And e.Control) Or e.KeyCode = (Keys.P And e.Control) _
        Or e.KeyCode = (Keys.S And e.Control) Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 _
        Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.End Then
            Topctrl1.TopKey_Down(e)
        End If


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

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 600, 880, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr$ = ""

        mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " "

        mQry = "SELECT Code  As SearchCode FROM ViewSch_StreamYearSemester " & mCondStr
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        mQry = "SELECT Sem.Code, Sem.StreamYearSemesterDesc as Name " & _
                " FROM ViewSch_StreamYearSemester Sem " & _
                " Where " & AgL.PubSiteCondition("Sem.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By Sem.StreamYearSemesterDesc"
        TxtDescription.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
        TxtCopyFrom.AgHelpDataSet = TxtDescription.AgHelpDataSet.Copy


        mQry = "Select S.Code  As Code, S.Description As Name, S.ManualCode " & _
                " From Sch_Subject S " & _
                " Order By S.Description "
        DGL1.AgHelpDataSet(Col1_Subject, 1) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        DGL1.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False


        Try
            MastPos = BMBMaster.Position


            If DTMaster.Rows.Count > 0 Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True


                    mQry = "Delete From Sch_SemesterSubject Where StreamYearSemester = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                    AgL.ETrans.Commit()
                    mTrans = False


                    FIniMaster(1)
                    Topctrl1_tbRef()
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub


    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtCopyFrom.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try

            AgL.PubFindQry = "SELECT Sem.Code , Sem.StreamYearSemesterDesc AS Semester, Y.SessionProgrammeStream, Y.YearSerial, Y.SessionProgrammeStreamYearDesc, " & _
                                " CASE WHEN V1.StreamYearSemester IS NOT NULL THEN 'Yes'  ELSE 'No' END AS  [Subject Defined] " & _
                                " FROM ViewSch_StreamYearSemester Sem " & _
                                " LEFT JOIN (SELECT DISTINCT Sub.StreamYearSemester FROM Sch_SemesterSubject Sub) V1 ON Sem.Code = V1.StreamYearSemester " & _
                                " LEFT JOIN ViewSch_SessionProgrammeStreamYear Y ON Sem.SessionProgrammeStreamYear = Y.SessionProgrammeStreamYearCode " & _
                                " Where " & AgL.PubSiteCondition("Sem.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQryOrdBy = "[Semester]"

            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub
    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub
    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        Dim ds As New DataSet
        Dim strQry As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Semester Subject List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = "SELECT Sem.StreamYearSemesterDesc AS  Semester, Sem.SemesterStartDate [Sem.Start Dt], Sj.Description AS Subject, S.ManualCode AS [Subject Code], S.PaperID, S.MinCreditHours AS [Credit Hours], (CASE When S.IsElectiveSubject=1 THEN 'Yes' ELSE 'No' END) AS Elective  " & _
                    "FROM Sch_SemesterSubject S  " & _
                    "LEFT JOIN ViewSch_StreamYearSemester Sem ON S.StreamYearSemester =Sem.Code   " & _
                    "LEFT JOIN Sch_Subject Sj ON S.Subject =Sj.Code " & _
                    "Where StreamYearSemester ='" & mSearchCode & "' "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Semester Subject List"
            mPrnHnd.TableIndex = 0
            mPrnHnd.PageSetupDialog(True)
            mPrnHnd.PrintPreview()
            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, mSr As Integer = 0
        Dim mTrans As Boolean = False
        Dim SemesterSubjectCode As String

        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Edit" Then
                mQry = "Update Sch_StreamYearSemester Set SemesterStartDate = " & AgL.ConvertDate(TxtYearStartDate.Text) & " Where Code='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            With DGL1
                mSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1_Code, I).Value <> "" Then
                        If .Item(Col1_Subject, I).Value <> "" Then
                            mQry = "UPDATE dbo.Sch_SemesterSubject " & _
                                    "SET Subject = " & AgL.Chk_Text(.AgSelectedValue(Col1_Subject, I)) & ", " & _
                                    "	ManualCode = " & AgL.Chk_Text(.Item(Col1_ManualCode, I).Value) & ", " & _
                                    "	PaperID = " & AgL.Chk_Text(.Item(Col1_PaperID, I).Value) & ", " & _
                                    "	MinCreditHours = " & Val(.Item(Col1_MinCreditHours, I).Value) & ", " & _
                                    "	IsElectiveSubject = " & IIf(AgL.StrCmp(.Item(Col1_IsElectiveSubject, I).Value.ToString, "Yes"), 1, 0) & " " & _
                                    "WHERE Code = '" & .Item(Col1_Code, I).Value & "'"

                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            mQry = "Delete From dbo.Sch_SemesterSubject Where Code = '" & .Item(Col1_Code, I).Value & "' "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If .Item(Col1_Subject, I).Value <> "" Then
                            SemesterSubjectCode = AgL.GetMaxId("Sch_SemesterSubject", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)
                            mQry = "INSERT INTO Sch_SemesterSubject	 " & _
                                    "(Code,StreamYearSemester,Subject,ManualCode,PaperID,MinCreditHours,IsElectiveSubject) " & _
                                    "VALUES (" & AgL.Chk_Text(SemesterSubjectCode) & "," & AgL.Chk_Text(TxtDescription.AgSelectedValue) & "," & AgL.Chk_Text(.AgSelectedValue(Col1_Subject, I)) & "," & AgL.Chk_Text(.Item(Col1_ManualCode, I).Value) & ", " & _
                                    "" & AgL.Chk_Text(.Item(Col1_PaperID, I).Value) & "," & Val(.Item(Col1_MinCreditHours, I).Value) & "," & IIf(AgL.StrCmp(.Item(Col1_IsElectiveSubject, I).Value.ToString, "Yes"), 1, 0) & " ) "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    End If
                Next I
            End With


            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)


            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()
            mTrans = False
            FIniMaster(0, 1)
            Topctrl1_tbRef()
            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                MoveRec()
            End If
        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Dim I As Integer
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "SELECT Sem.Code, Sem.StreamYearSemesterDesc, Sem.SemesterStartDate    FROM ViewSch_StreamYearSemester Sem WHERE Code ='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDescription.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))                        
                        TxtYearStartDate.Text = AgL.XNull(.Rows(0)("SemesterStartDate"))
                    End If
                End With

                mQry = "SELECT * FROM Sch_SemesterSubject S WHERE S.StreamYearSemester ='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1_Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                            DGL1.Item(Col1_ManualCode, I).Value = AgL.XNull(.Rows(I)("ManualCode"))
                            DGL1.Item(Col1_PaperID, I).Value = AgL.XNull(.Rows(I)("PaperID"))
                            DGL1.Item(Col1_PaperID, I).Value = AgL.XNull(.Rows(I)("PaperID"))
                            DGL1.Item(Col1_MinCreditHours, I).Value = AgL.VNull(.Rows(I)("MinCreditHours"))
                            DGL1.Item(Col1_IsElectiveSubject, I).Value = IIf(AgL.VNull(.Rows(I)("IsElectiveSubject")), "Yes", "No")
                            DGL1.Item(Col1_Code, I).Value = AgL.XNull(.Rows(I)("Code"))
                        Next I
                    End If
                End With

            Else
                BlankText()
            End If
            Topctrl1.tAdd = False


            Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
        End Try
    End Sub
    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtDescription.Enabled = False
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

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1_Subject
                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        DGL1.Item(Col1_ManualCode, mRowIndex).Value = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                DGL1.Item(Col1_ManualCode, mRowIndex).Value = AgL.XNull(.Item("ManualCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGL1.EditingControlShowing
        If Topctrl1.Mode = "Browse" Then Exit Sub
        If TypeOf e.Control Is ComboBox Then
            e.Control.Text = ""
        End If
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub

        Try
            Select Case sender.CurrentCell.ColumnIndex
                'Case <Dgl_Column>
                '    <Executable Code>
            End Select
        Catch Ex As NullReferenceException
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, Col_SNo)
    End Sub


    Private Sub TxtCopyFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCopyFrom.Validating
        Select Case sender.name
            Case TxtCopyFrom.Name
                FillCopyDetail(TxtCopyFrom.AgSelectedValue)
        End Select

    End Sub


    Sub FillCopyDetail(ByVal StreamYearSemester As String)
        Dim I As Integer
        Dim DsTemp As DataSet



        If StreamYearSemester.Trim = "" Then
            Exit Sub
        Else
            If DGL1.RowCount > 1 Then
                If MsgBox("Do you Sure to Copy Detail From -- " & TxtCopyFrom.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If
        End If


        mQry = "SELECT * FROM Sch_SemesterSubject S WHERE S.StreamYearSemester ='" & StreamYearSemester & "'"
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            DGL1.RowCount = 1
            DGL1.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                    DGL1.Rows.Add()
                    DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                    DGL1.AgSelectedValue(Col1_Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                    DGL1.Item(Col1_ManualCode, I).Value = AgL.XNull(.Rows(I)("ManualCode"))
                    DGL1.Item(Col1_PaperID, I).Value = AgL.XNull(.Rows(I)("PaperID"))
                    DGL1.Item(Col1_PaperID, I).Value = AgL.XNull(.Rows(I)("PaperID"))
                    DGL1.Item(Col1_MinCreditHours, I).Value = AgL.VNull(.Rows(I)("MinCreditHours"))
                    DGL1.Item(Col1_IsElectiveSubject, I).Value = IIf(AgL.VNull(.Rows(I)("IsElectiveSubject")), "Yes", "No")
                Next I
            End If
        End With
    End Sub

    Private Function Data_Validation() As Boolean
        Try
            If AgCL.AgCheckMandatory(Me) = False Then Exit Function


            If Topctrl1.Mode = "Edit" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_StreamYearSemester Where DatePart(Month, SemesterStartDate) = DatePart(Month,'" & TxtYearStartDate.Text & "')  And DatePart(Year, SemesterStartDate)=DatePart(Year,'" & TxtYearStartDate.Text & "') And Code<>'" & mSearchCode & "' And SessionProgrammeStreamYear In (Select SessionProgrammeStreamYear From Sch_StreamYearSemester Where Code = '" & mSearchCode & "') ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Year Already Exist!") : TxtDescription.Focus() : Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1_Subject) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1_Subject & "") Then Exit Function

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function
End Class
