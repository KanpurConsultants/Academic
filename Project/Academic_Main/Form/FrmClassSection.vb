Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmClassSection

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Section As Byte = 1
    Private Const Col1IsOpenElectiveSection As Byte = 2
    Private Const Col1TotalSubSection As Byte = 3
    Private Const Col1FillSubSection As Byte = 4
    Private Const Col1SubSectionList As Byte = 5
    Private Const Col1SubSectionCodeList As Byte = 6
    Private Const Col1Code As Byte = 7
    Private Const Col1TempIsOpenElectiveSection As Byte = 8

    ''Grid Dgl2 Constants =========================================
    Private Const Col2SubSection As Byte = 1
    Private Const Col2Code As Byte = 2

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        StrUPVar = StrUPVar.Replace("A", "*")
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
            .AddAgTextColumn(DGL1, "DGL1Secion", 60, 5, "Section", True, False, False)
            .AddAgCheckBoxColumn(DGL1, "Dgl1IsOpenElectiveSection", 70, "Open Elective", True, False)
            .AddAgNumberColumn(DGL1, "Dgl1TotalSubSection", 70, 2, 0, False, "Total Subsection", True, False, True)
            .AddAgButtonColumn(DGL1, "DGL1FillSubSection", 30, " ", True, False, , , , "Webdings", 10, "6")
            .AddAgTextColumn(DGL1, "DGL1SubSectionList", 200, 255, "Subsection List", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1SubSectionCodeList", 180, 0, "Code", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1Code", 180, 0, "Code", False, True, False)
            .AddAgCheckBoxColumn(DGL1, "Dgl1TempIsOpenElectiveSection", 70, "Open Elective", False, True)
        End With
        DGL1.ColumnHeadersHeight = 40

        'AgL.AddAgDataGrid(DGL2, Pnl2)
        With AgCL
            .AddAgTextColumn(DGL2, "DGL2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(Dgl2, "DGL2SubSecion", 100, 5, "Sub Section", True, True, False)
            .AddAgTextColumn(DGL2, "DGL2Code", 180, 0, "Code", False, True, False)
        End With
        Dgl2.ColumnHeadersHeight = 40
        Dgl2.AllowUserToAddRows = False

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
            AgL.WinSetting(Me, 500, 880, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
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
                'Case <ColumnIndex>
                '<Executable Code>
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded, DGL2.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, Col_SNo)
    End Sub

    Private Sub DGL1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellContentClick
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1FillSubSection
                    If DGL1.Item(Col1SubSectionList, mRowIndex).Value Is Nothing Then DGL1.Item(Col1SubSectionList, mRowIndex).Value = ""
                    If DGL1.Item(Col1SubSectionCodeList, mRowIndex).Value Is Nothing Then DGL1.Item(Col1SubSectionCodeList, mRowIndex).Value = ""


                    If Dgl2.Visible = False Then
                        ProcShowSubSectionGrid(mRowIndex)
                    Else
                        ProcHideSubSectionGrid(mRowIndex)
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                '<Executable Code>
                'Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr$ = ""

        mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " "

        mQry = "SELECT P.Code As SearchCode FROM ViewSch_SessionProgramme P " & mCondStr
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        mQry = "SELECT P.Code , P.SessionProgramme AS Name " & _
                " FROM ViewSch_SessionProgramme P " & _
                " Where 1=1 And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY P.SessionProgramme"
        TxtSessionProgramme.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)
    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSessionProgramme.Focus()
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

                    mQry = "Delete From Sch_ClassSectionSubSection " & _
                            " Where ClassSection In (Select Code From Sch_ClassSection With (NoLock) Where SessionProgramme = '" & mSearchCode & "' )"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    AgL.Dman_ExecuteNonQry("Delete From  Sch_ClassSection Where SessionProgramme = '" & mSearchCode & "' ", AgL.GCn, AgL.ECmd)

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
        TxtSessionProgramme.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try

            AgL.PubFindQry = "Select  P.Code As SearchCode, Max(P.SessionProgramme) As [Session/Programme], Count(S.Code) AS [Total Section] " & _
                                " From  ViewSch_SessionProgramme P " & _
                                " LEFT JOIN ViewSch_ClassSection S ON P.Code = S.SessionProgramme " & _
                                " Where 1=1 And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                                " GROUP BY P.Code "

            AgL.PubFindQryOrdBy = "[Session/Programme]"

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
            AgL.PubReportTitle = "Section List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = " Select C.SessionProgramme As [Session/Programme],C.SessionDescription AS Session,C.ProgrammeDescription AS Program " & _
                        " From  ViewSch_SessionProgramme C " & _
                        " Where 1=1 And " & AgL.PubSiteCondition("C.Site_Code", AgL.PubSiteCode) & " Order By C.Session "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Section List"
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
        Dim I As Integer
        Dim mTrans As Boolean = False
        Dim GcnRead As SqlClient.SqlConnection

        Dim bClassSectionCode As String

        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub


            GcnRead = New SqlClient.SqlConnection
            GcnRead.ConnectionString = AgL.Gcn_ConnectionString
            GcnRead.Open()


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Code, I).Value <> "" Then
                        If .Item(Col1Section, I).Value <> "" Then
                            mQry = "UPDATE Sch_ClassSection SET Section = " & AgL.Chk_Text(.Item(Col1Section, I).Value) & ", " & _
                                    " IsOpenElectiveSection = " & IIf(CBool(.Item(Col1IsOpenElectiveSection, I).Value), 1, 0) & " " & _
                                    " WHERE Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            Call ProcSaveSubSection(I)

                        Else
                            mQry = "Delete From Sch_ClassSectionSubSection " & _
                                    " Where ClassSection = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & ""
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            mQry = "Delete From Sch_ClassSection " & _
                                    " Where Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & ""
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If .Item(Col1Section, I).Value <> "" Then
                            bClassSectionCode = AgL.GetMaxId("Sch_ClassSection", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)

                            mQry = "INSERT INTO Sch_ClassSection ( Code, SessionProgramme, Section, IsOpenElectiveSection) " & _
                                    " VALUES ( " & _
                                    " " & AgL.Chk_Text(bClassSectionCode) & ", " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(.Item(Col1Section, I).Value) & ", " & _
                                    " " & IIf(CBool(.Item(Col1IsOpenElectiveSection, I).Value), 1, 0) & " )"

                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            Call ProcSaveSubSection(I, bClassSectionCode)
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


    Private Sub ProcSaveSubSection(ByVal bRowIndex As Integer, Optional ByVal bClassSectionCode As String = "")
        Dim J As Integer
        Dim bCodeStr() As String = Nothing, bSubSectionStr() As String = Nothing
        Dim bSubSectionCode$ = ""

        With DGL1
            bCodeStr = Split(DGL1.Item(Col1SubSectionCodeList, bRowIndex).Value.ToString, ",")
            bSubSectionStr = Split(DGL1.Item(Col1SubSectionList, bRowIndex).Value.ToString, ",")

            If bClassSectionCode.Trim = "" Then bClassSectionCode = .Item(Col1Code, bRowIndex).Value

            If Val(.Item(Col1TotalSubSection, bRowIndex).Value) > 0 Then
                For J = 0 To bSubSectionStr.Length - 1
                    If bCodeStr(J).Trim <> "" Then
                        If bSubSectionStr(J).Trim <> "" Then
                            mQry = "UPDATE Sch_ClassSectionSubSection " & _
                                    " SET ClassSection =  " & AgL.Chk_Text(.Item(Col1Code, bRowIndex).Value) & ", " & _
                                    " SubSection = " & AgL.Chk_Text(bSubSectionStr(J)) & " " & _
                                    " WHERE Code = " & AgL.Chk_Text(bCodeStr(J)) & ""
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            mQry = "Delete From Sch_ClassSectionSubSection " & _
                                    " Where Code = " & AgL.Chk_Text(bCodeStr(J)) & ""
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If bSubSectionStr(J).Trim <> "" Then
                            bSubSectionCode = AgL.GetMaxId("Sch_ClassSectionSubSection", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)

                            mQry = "INSERT INTO dbo.Sch_ClassSectionSubSection ( " & _
                                    " Code, ClassSection, SubSection ) " & _
                                    " VALUES ( " & _
                                    " " & AgL.Chk_Text(bSubSectionCode) & ", " & AgL.Chk_Text(bClassSectionCode) & ", " & AgL.Chk_Text(bSubSectionStr(J)) & " )"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    End If
                Next
            Else
                mQry = "Delete From Sch_ClassSectionSubSection " & _
                        " Where ClassSection = " & AgL.Chk_Text(.Item(Col1Code, bRowIndex).Value) & ""
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If
        End With
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim DtTemp As DataTable = Nothing
        Dim I As Integer, J As Integer
        Dim MastPos As Long
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")

                TxtSessionProgramme.AgSelectedValue = mSearchCode

                mQry = "Select * From Sch_ClassSection Where SessionProgramme = '" & mSearchCode & "' Order By RowID "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.Item(Col1Section, I).Value = AgL.XNull(.Rows(I)("Section"))
                            DGL1.Item(Col1Code, I).Value = .Rows(I)("Code")
                            DGL1.Item(Col1IsOpenElectiveSection, I).Value = AgL.VNull(.Rows(I)("IsOpenElectiveSection"))
                            DGL1.Item(Col1TempIsOpenElectiveSection, I).Value = AgL.VNull(.Rows(I)("IsOpenElectiveSection"))

                            DGL1.Item(Col1TotalSubSection, I).Value = ""
                            DGL1.Item(Col1SubSectionList, I).Value = ""
                            DGL1.Item(Col1SubSectionCodeList, I).Value = ""


                            mQry = "Select S.* " & _
                                    " From Sch_ClassSectionSubSection S " & _
                                    " Where S.ClassSection = " & AgL.Chk_Text(.Rows(I)("Code")) & " " & _
                                    " Order By S.RowId "
                            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                            If DtTemp.Rows.Count > 0 Then
                                DGL1.Item(Col1TotalSubSection, I).Value = DtTemp.Rows.Count

                                For J = 0 To DtTemp.Rows.Count - 1
                                    DGL1.Item(Col1SubSectionList, I).Value += IIf(DGL1.Item(Col1SubSectionList, I).Value.ToString.Trim = "", AgL.XNull(DtTemp.Rows(J)("SubSection")), "," + AgL.XNull(DtTemp.Rows(J)("SubSection")))
                                    DGL1.Item(Col1SubSectionCodeList, I).Value += IIf(DGL1.Item(Col1SubSectionCodeList, I).Value.ToString.Trim = "", AgL.XNull(DtTemp.Rows(J)("Code")), "," + AgL.XNull(DtTemp.Rows(J)("Code")))
                                Next
                            End If
                        Next I
                    End If
                End With



            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Dgl2.RowCount = 1 : Dgl2.Rows.Clear() : Dgl2.Tag = -1
        mSearchCode = ""
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        Dgl2.Visible = False

        If Topctrl1.Mode = "Edit" Then
            TxtSessionProgramme.Enabled = False
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

    Private Sub TxtProgramme_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            Select Case sender.name
                'Case sender.Name
                '<Executable Code>
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            If AgL.RequiredField(TxtSessionProgramme, "Session/Programme") Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1Section) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1Section & "") Then Exit Function

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function


            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1IsOpenElectiveSection, I).Value Is Nothing Then .Item(Col1IsOpenElectiveSection, I).Value = False

                    Try
                        If .Item(Col1IsOpenElectiveSection, I).Value = "" Then .Item(Col1IsOpenElectiveSection, I).Value = False
                    Catch ex As Exception

                    End Try
                    If .Item(Col1Code, I).Value Is Nothing Then .Item(Col1Code, I).Value = ""

                    If Topctrl1.Mode = "Edit" Then
                        If .Item(Col1Code, I).Value.ToString.Trim <> "" Then
                            If CBool(.Item(Col1IsOpenElectiveSection, I).Value) <> CBool(.Item(Col1TempIsOpenElectiveSection, I).Value) Then
                                If CBool(.Item(Col1TempIsOpenElectiveSection, I).Value) Then
                                    mQry = "SELECT IsNull(Count(A.Code),0) Cnt " & _
                                            " FROM Sch_ClassSectionOpenElectiveSemesterAdmission A " & _
                                            " WHERE A.Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & ""
                                    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Record Exists For Open Elective Section : " & .Item(Col1Section, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1IsOpenElectiveSection, I) : DGL1.Focus() : Exit Function
                                Else
                                    mQry = "SELECT IsNull(Count(A.Code),0) Cnt " & _
                                            " FROM Sch_ClassSectionSemesterAdmission A " & _
                                            " WHERE A.Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & ""
                                    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Record Exists For Section : " & .Item(Col1Section, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1IsOpenElectiveSection, I) : DGL1.Focus() : Exit Function
                                End If
                            End If
                        End If
                    End If
                Next
            End With

            If Dgl2.Visible = True Then
                If Val(Dgl2.Tag) < 0 Then
                    Dgl2.Visible = False

                Else
                    MsgBox("Please Close Subsection Grid!...")
                    DGL1.CurrentCell = DGL1(Col1FillSubSection, CInt(Val(Dgl2.Tag))) : DGL1.Focus()
                    Exit Function
                End If
            End If


            If Topctrl1.Mode = "Add" Then
                mSearchCode = TxtSessionProgramme.AgSelectedValue
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub ProcShowSubSectionGrid(ByVal bRowIndex As Integer)
        Dim bCodeStr() As String = Nothing, bSubSectionStr() As String = Nothing
        Dim bSubSectionName$ = ""
        Dim bFlag As Boolean = False
        Dim I As Integer, bTotalRowsCnt As Integer, bTotalSubSection As Integer



        Dgl2.Visible = True : Dgl2.Tag = bRowIndex
        bTotalSubSection = Val(DGL1.Item(Col1TotalSubSection, bRowIndex).Value)

        bCodeStr = Split(DGL1.Item(Col1SubSectionCodeList, bRowIndex).Value.ToString, ",")
        bSubSectionStr = Split(DGL1.Item(Col1SubSectionList, bRowIndex).Value.ToString, ",")


        Dgl2.RowCount = 1 : Dgl2.Rows.Clear()

        If bCodeStr.Length > bTotalSubSection Then
            bTotalRowsCnt = bCodeStr.Length
            bFlag = True
        Else
            bTotalRowsCnt = bTotalSubSection
        End If


        For I = 0 To bTotalRowsCnt - 1
            Dgl2.Rows.Add()
            Dgl2.Item(Col_SNo, I).Value = Dgl2.Rows.Count

            bSubSectionName = DGL1.Item(Col1Section, bRowIndex).Value.ToString + (I + 1).ToString

            If bFlag = True And I >= bTotalSubSection Then bSubSectionName = ""

            Dgl2.Item(Col2SubSection, I).Value = bSubSectionName
            Dgl2.Item(Col2Code, I).Value = ""
            If I < bCodeStr.Length Then
                If bCodeStr(I).Trim <> "" Then
                    Dgl2.Item(Col2Code, I).Value = bCodeStr(I)
                End If
            End If
        Next
    End Sub

    Private Sub ProcHideSubSectionGrid(ByVal bRowIndex As Integer)
        Dim I As Integer
        Dim bSubSectionList$ = "", bCodeList$ = ""

        If bRowIndex <> Val(Dgl2.Tag) Then MsgBox("Invalid Action!...") : Exit Sub
        With Dgl2
            For I = 0 To .Rows.Count - 1
                If .Item(Col2SubSection, I).Value Is Nothing Then .Item(Col2SubSection, I).Value = ""
                If .Item(Col2Code, I).Value Is Nothing Then .Item(Col2Code, I).Value = ""

                If .Item(Col2Code, I).Value.ToString.Trim <> "" Or .Item(Col2SubSection, I).Value.ToString.Trim <> "" Then
                    bSubSectionList += IIf(bSubSectionList.Trim = "", .Item(Col2SubSection, I).Value, "," + .Item(Col2SubSection, I).Value)
                    bCodeList += .Item(Col2Code, I).Value.ToString + ","
                End If
            Next
        End With

        DGL1.Item(Col1SubSectionList, bRowIndex).Value = bSubSectionList

        If bCodeList.Trim <> "" Then
            bCodeList = AgL.MidStr(bCodeList, 0, bCodeList.Length - 1)
        End If

        DGL1.Item(Col1SubSectionCodeList, bRowIndex).Value = bCodeList
        Dgl2.Visible = False : Dgl2.Tag = -1
    End Sub

End Class
