Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSessionProgramme

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Stream As Byte = 1
    Private Const Col1Seats As Byte = 2
    Private Const Col1SeatsForRegistration As Byte = 3
    Private Const Col1Code As Byte = 4


    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2Stream As Byte = 1
    Private Const Col2YearSerial As Byte = 2
    Private Const Col2YearStartDate As Byte = 3
    Private Const Col2Code As Byte = 4    


    Public WithEvents DGL3 As New AgControls.AgDataGrid
    Private Const Col3Year As Byte = 1
    Private Const Col3Semester As Byte = 2
    Private Const Col3SemesterStartDate As Byte = 3
    Private Const Col3Code As Byte = 4


    Dim DtSessionProgrammeStreamYear As DataTable


    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub FrmSessionProgramme_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub


    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AGL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub
    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub


    Private Sub IniGrid()
        AgL.AddAgDataGrid(DGL1, Pnl1)
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1Stream", 250, 0, "Stream", True, False, False)
            .AddAgNumberColumn(DGL1, "DGL1TotalSeats", 100, 8, 0, False, "Total Seats", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1SeatsForRegistration", 100, 8, 0, False, "Seats For Registration", True, False, True)
            .AddAgTextColumn(DGL1, "DGL1Code", 180, 0, "Code", False, False, False)
        End With


        AgL.AddAgDataGrid(DGL2, Pnl2)
        With AgCL
            .AddAgTextColumn(DGL2, "DGL2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "DGL2SessionProgrammeStream", 150, 0, "Stream", True, True, False)
            .AddAgTextColumn(DGL2, "DGL2Year", 100, 0, "Year", True, True, False)
            .AddAgDateColumn(DGL2, "DGL2YearStartDate", 80, "Year Start Dt", True, True)
            .AddAgTextColumn(DGL2, "DGL2Code", 180, 0, "Code", False, True, False)
        End With
        DGL2.AllowUserToAddRows = False


        AgL.AddAgDataGrid(DGL3, Pnl3)
        With AgCL
            .AddAgTextColumn(dgl3, "dgl3SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL3, "dgl3Year", 150, 0, "Year", True, True, False)
            .AddAgTextColumn(DGL3, "dgl3Semester", 100, 0, "Semester", True, True, False)
            .AddAgDateColumn(DGL3, "dgl3YearStartDate", 80, "Start Dt", True, True)
            .AddAgTextColumn(DGL3, "dgl3Code", 180, 0, "Code", False, True, False)
        End With
        DGL3.AllowUserToAddRows = False

        'DgL.AddAgDataGrid(DGL2, Pnl2)
        'DGL2.AllowUserToAddRows = False
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
        AGL.CheckQuote(e)
    End Sub
    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 650, 880, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGL3)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            Topctrl1.ChangeAgGridState(DGL3, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        Try
            If DtSessionProgrammeStreamYear IsNot Nothing Then
                If DGL1.CurrentCell IsNot Nothing Then
                    DtSessionProgrammeStreamYear.DefaultView.RowFilter = "SessionProgrammeStream = '" & DGL1.Item(Col1Code, DGL1.CurrentCell.RowIndex).Value & "'"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub DGL1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.RowEnter
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


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr$ = ""

        mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " "

        mQry = "Select P.Code As SearchCode " & _
                " From Sch_SessionProgramme P " & mCondStr
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()

        mQry = "Select Code  As Code, ManualCode As Name, StartDate From Sch_Session " & _
            "  Order By ManualCode"
        TxtSession.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code  As Code, ManualCode As Name, ProgrammeDuration, Semesters, SemesterDuration " & _
                " From Sch_Programme P " & _
                " Where " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By ManualCode"
        TxtProgramme.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code  As Code, ManualCode As Name " & _
                " From Sch_Stream " & _
                " Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " " & _
                " Order By ManualCode"
        DGL1.AgHelpDataSet(Col1Stream, 0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Y.SessionProgrammeStreamYearCode AS Code, CONVERT(NVARCHAR,Y.YearSerial) AS YearSerial " & _
                " FROM viewSch_SessionProgrammeStreamYear Y " & _
                " Where " & AgL.PubSiteCondition("Y.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY Y.YearSerial "
        DGL2.AgHelpDataSet(Col2YearSerial) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.code, S.SessionProgrammeStream  " & _
                " FROM ViewSch_SessionProgrammeStream S " & _
                " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY S.SessionProgrammeStream "
        DGL2.AgHelpDataSet(Col2Stream) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Y.SessionProgrammeStreamYearCode AS Code, Y.SessionProgrammeStreamYearDesc " & _
                " FROM ViewSch_SessionProgrammeStreamYear Y " & _
                " Where " & AgL.PubSiteCondition("Y.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY Y.SessionProgrammeStreamYearDesc "
        DGL3.AgHelpDataSet(Col3Year) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.code, S.Description  FROM Sch_Semester S ORDER BY S.Description "
        DGL3.AgHelpDataSet(Col3Semester) = AgL.FillData(mQry, AgL.GCn)

    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSession.Focus()
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


                    AgL.Dman_ExecuteNonQry("Delete From Sch_StreamYearSemester Where SessionProgrammeStreamYear In (Select Code From Sch_SessionProgrammeStreamYear Where SessionProgrammeStream In (Select Code From Sch_SessionProgrammeStream Where SessionProgramme In( '" & mSearchCode & "')))", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From  Sch_SessionProgrammeStreamYear Where SessionProgrammeStream In (Select Code From Sch_SessionProgrammeStream Where SessionProgramme In( '" & mSearchCode & "'))", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From  Sch_SessionProgrammeStream Where SessionProgramme In( '" & mSearchCode & "')", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_SessionProgramme Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        TxtSession.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try
            AgL.PubFindQry = "Select  SP.Code As SearchCode,  S.ManualCode As [Session], P.ManualCode as [Programme]  " & _
                                " From  Sch_SessionProgramme SP " & _
                                " Left Join Sch_Session S On SP.Session = S.Code " & _
                                " Left Join Sch_Programme P On SP.Programme = P.Code " & _
                                " Where " & AgL.PubSiteCondition("Sp.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQryOrdBy = "[Session]"

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
            AgL.PubReportTitle = "Session Program List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = "Select  S.Description As [Session], P.Description as [Programme]  " & _
                        " From  Sch_SessionProgramme SP " & _
                        " Left Join Sch_Session S On SP.Session = S.Code " & _
                        " Left Join Sch_Programme P On SP.Programme = P.Code " & _
                        " Where " & AgL.PubSiteCondition("Sp.Site_Code", AgL.PubSiteCode) & " "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Session Program List"
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
        Dim Sr As Integer, I As Integer
        Dim J As Integer
        Dim K As Integer
        Dim mTrans As Boolean = False
        Dim DtSemesters As DataTable
        Dim GcnRead As SqlClient.SqlConnection

        Dim bSessionProgrammeStreamCode As String
        Dim bSessionProgrammeStreamYearCode As String
        Dim bSessionProgrammeStreamYearSemesterCode As String

        Try
            MastPos = BMBMaster.Position


            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1Stream) Then Exit Sub            
            If AgCL.AgIsDuplicate(DGL1, "" & Col1Stream & "") Then Exit Sub
            If Not AgCL.AgCheckMandatory(Me) Then Exit Sub



            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_SessionProgramme Where Session='" & TxtSession.AgSelectedValue & "' And Programme = '" & TxtProgramme.AgSelectedValue & "'  ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Session / Programme Already Exist!") : TxtSession.Focus() : Exit Sub

                mSearchCode = AgL.GetMaxId("Sch_SessionProgramme", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 6, True, True, , AgL.Gcn_ConnectionString)
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_SessionProgramme Where Session='" & TxtSession.AgSelectedValue & "' And Programme = '" & TxtProgramme.AgSelectedValue & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Session / Programme Already Exist!") : TxtSession.Focus() : Exit Sub
            End If


            mQry = "Select Top " & Val(TxtSemesters.Text) & " * From Sch_Semester Order By SerialNo"
            DtSemesters = AgL.FillData(mQry, AgL.GCn).Tables(0)



            GcnRead = New SqlClient.SqlConnection
            GcnRead.ConnectionString = AgL.Gcn_ConnectionString
            GcnRead.Open()


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = "Insert Into Sch_SessionProgramme (Code, Session, Programme, Div_Code, Site_Code, U_EntDt, PreparedBy, U_AE) Values('" & mSearchCode & "', " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ", " & AgL.Chk_Text(TxtProgramme.AgSelectedValue) & ",  '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', '" & AgL.PubUserName & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_SessionProgramme Set Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ", Programme = " & AgL.Chk_Text(TxtProgramme.AgSelectedValue) & ", Edit_Date='" & Format(AgL.PubLoginDate, "Short Date") & "', ModifiedBy = '" & AgL.PubUserName & "', U_AE = 'E' Where Code='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If



            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Code, I).Value <> "" Then
                        If .Item(Col1Stream, I).Value <> "" Then
                            mQry = "Update dbo.Sch_SessionProgrammeStream " & _
                                 "Set Stream = " & AgL.Chk_Text(.AgSelectedValue(Col1Stream, I)) & ", " & _
                                 " TotalSeats = " & Val(.Item(Col1Seats, I).Value) & ", " & _
                                 " SeatsForRegistration = " & Val(.Item(Col1SeatsForRegistration, I).Value) & " " & _
                                 " Where Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & ""
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            mQry = "Delete From dbo.Sch_SessionProgrammeStream " & _
                                 "Where Code = " & Val(.Item(Col1Code, I).Value) & ""
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            For J = 0 To Dgl2.Rows.Count - 1
                                If AgL.StrCmp(DGL1.Item(Col1Code, I).Value, DGL2.AgSelectedValue(Col2Stream, J)) Then
                                    mQry = "Delete From dbo.Sch_SessionProgrammeStreamYear Where Code = " & Val(DGL2.Item(Col2Code, J).Value) & " "
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                End If
                            Next
                        End If
                    Else
                        If .Item(Col1Stream, I).Value <> "" Then
                            bSessionProgrammeStreamCode = AgL.GetMaxId("Sch_SessionProgrammeStream", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 6, True, True, , AgL.Gcn_ConnectionString)
                            mQry = " INSERT INTO dbo.Sch_SessionProgrammeStream " & _
                                   " (Code, SessionProgramme, Stream, TotalSeats, SeatsForRegistration) " & _
                                   " VALUES (" & AgL.Chk_Text(bSessionProgrammeStreamCode) & ", " & AgL.Chk_Text(mSearchCode) & "," & AgL.Chk_Text(.AgSelectedValue(Col1Stream, I)) & ", " & _
                                   " " & Val(.Item(Col1Seats, I).Value) & ", " & Val(.Item(Col1SeatsForRegistration, I).Value) & " )"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            Sr += 1


                            For J = 0 To CInt(Val(TxtProgrammeDuration.Text)) - 1
                                bSessionProgrammeStreamYearCode = AgL.GetMaxId("Sch_SessionProgrammeStreamYear", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 6, True, True, , AgL.Gcn_ConnectionString)
                                mQry = "INSERT INTO dbo.Sch_SessionProgrammeStreamYear " & _
                                    "(Code, SessionProgrammeStream,YearSerial,YearStartDate) " & _
                                    "VALUES (" & AgL.Chk_Text(bSessionProgrammeStreamYearCode) & "," & AgL.Chk_Text(bSessionProgrammeStreamCode) & "," & J + 1 & "," & AgL.ConvertDate(DateAdd(DateInterval.Year, J, CDate(TxtSessionStartDate.Text))) & ") "
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                                For K = 0 To Val(TxtSemesters.Text) - 1
                                    If DateAdd(DateInterval.Year, J + 1, CDate(TxtSessionStartDate.Text)) > DateAdd(DateInterval.Month, K * Val(TxtSemesterDuration.Text), CDate(TxtSessionStartDate.Text)) And DateAdd(DateInterval.Year, J, CDate(TxtSessionStartDate.Text)) <= DateAdd(DateInterval.Month, K * Val(TxtSemesterDuration.Text), CDate(TxtSessionStartDate.Text)) Then
                                        bSessionProgrammeStreamYearSemesterCode = AgL.GetMaxId("Sch_StreamYearSemester", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)
                                        mQry = "INSERT INTO dbo.Sch_StreamYearSemester " & _
                                            "(Code,SessionProgrammeStreamYear,Semester,SemesterStartDate) " & _
                                            "VALUES (" & AgL.Chk_Text(bSessionProgrammeStreamYearSemesterCode) & "," & AgL.Chk_Text(bSessionProgrammeStreamYearCode) & "," & AgL.Chk_Text(DtSemesters.Rows(K)("Code")) & "," & AgL.ConvertDate(DateAdd(DateInterval.Month, K * Val(TxtSemesterDuration.Text), CDate(TxtSessionStartDate.Text))) & ")"
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    End If
                                Next
                            Next
                        End If
                    End If
                Next I
            End With




            If Topctrl1.Mode = "Edit" Then
                With DGL2
                    For I = 0 To .Rows.Count - 1
                        mQry = "UPDATE dbo.Sch_SessionProgrammeStreamYear " & _
                               "SET  YearStartDate = " & AgL.ConvertDate(.Item(Col2YearStartDate, I).Value.ToString) & " " & _
                               "WHERE Code = '" & .Item(Col2Code, I).Value & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    Next
                End With

                With DGL3
                    For I = 0 To .Rows.Count - 1
                        mQry = "UPDATE dbo.Sch_StreamYearSemester " & _
                                "SET SessionProgrammeStreamYear = " & AgL.Chk_Text(.AgSelectedValue(Col3Year, I)) & ", " & _
                                "Semester = " & AgL.Chk_Text(.AgSelectedValue(Col3Semester, I)) & ",SemesterStartDate = " & AgL.Chk_Text(.Item(Col3SemesterStartDate, I).Value) & " " & _
                                "WHERE Code = '" & .Item(Col3Code, I).Value & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    Next
                End With

            End If






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
        Dim I As Integer
        Dim MastPos As Long
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select SP.Session, SP.Programme, SP.ProgrammeDuration, SP.SessionStartDate, Sp.ProgrammeSemesters, SP.ProgrammeSemesterDuration " & _
                    " From ViewSch_SessionProgramme  SP " & _
                    "Where Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSession.AgSelectedValue = AgL.XNull(.Rows(0)("Session"))
                        TxtProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("Programme"))
                        TxtProgrammeDuration.Text = AgL.VNull(.Rows(0)("ProgrammeDuration"))
                        TxtSessionStartDate.Text = AgL.XNull(.Rows(0)("SessionStartDate"))
                        TxtSemesters.Text = AgL.VNull(.Rows(0)("ProgrammeSemesters"))
                        TxtSemesterDuration.Text = AgL.VNull(.Rows(0)("ProgrammeSemesterDuration"))
                    End If
                End With


                mQry = "Select * From Sch_SessionProgrammeStream Where SessionProgramme='" & mSearchCode & "' Order By RowID"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1Stream, I) = AgL.XNull(.Rows(I)("Stream"))
                            DGL1.Item(Col1Seats, I).Value = AgL.VNull(.Rows(I)("TotalSeats"))
                            DGL1.Item(Col1SeatsForRegistration, I).Value = AgL.VNull(.Rows(I)("SeatsForRegistration"))
                            DGL1.Item(Col1Code, I).Value = .Rows(I)("Code")
                        Next I
                    End If
                End With



                mQry = "Select Spsy.Code, SPSY.YearStartDate, SPSY.SessionProgrammeStream From Sch_SessionProgrammeStreamYear SPSY  Where SessionProgrammeStream In (Select Code From Sch_SessionProgrammeStream Where SessionProgramme='" & mSearchCode & "') Order By SessionProgrammeStream, YearSerial"
                DtSessionProgrammeStreamYear = AgL.FillData(mQry, AgL.GCn).Tables(0)

                With DtSessionProgrammeStreamYear
                    DGL2.RowCount = 1
                    DGL2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count
                            DGL2.AgSelectedValue(Col2Stream, I) = AgL.XNull(.Rows(I)("SessionProgrammeStream"))
                            DGL2.AgSelectedValue(Col2YearSerial, I) = AgL.XNull(.Rows(I)("Code"))
                            DGL2.Item(Col2YearStartDate, I).Value = AgL.XNull(.Rows(I)("YearStartDate"))
                            DGL2.Item(Col2Code, I).Value = .Rows(I)("Code")
                        Next I
                    End If
                End With



                mQry = "SELECT Code,SessionProgrammeStreamYear,Semester,SemesterStartDate FROM dbo.Sch_StreamYearSemester Where SessionProgrammeStreamYear In (Select Code From Sch_SessionProgrammeStreamYear Where SessionProgrammeStream In (Select Code From Sch_SessionProgrammeStream Where SessionProgramme In( '" & mSearchCode & "'))) ORDER BY RowId "
                DtSessionProgrammeStreamYear = AgL.FillData(mQry, AgL.GCn).Tables(0)

                With DtSessionProgrammeStreamYear
                    Dgl3.RowCount = 1
                    Dgl3.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            Dgl3.Rows.Add()
                            Dgl3.Item(Col_SNo, I).Value = Dgl3.Rows.Count
                            DGL3.AgSelectedValue(Col3Year, I) = AgL.XNull(.Rows(I)("SessionProgrammeStreamYear"))
                            DGL3.AgSelectedValue(Col3Semester, I) = AgL.XNull(.Rows(I)("Semester"))
                            DGL3.Item(Col3SemesterStartDate, I).Value = AgL.RetDate(AgL.XNull(.Rows(I)("SemesterStartDate")))
                            DGL3.Item(Col3Code, I).Value = .Rows(I)("Code")
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
            DtSessionProgrammeStreamYear = Nothing
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
        DGL3.RowCount = 1 : DGL3.Rows.Clear()
        mSearchCode = ""

    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
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

    Private Sub TxtProgramme_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtProgramme.Validating, TxtSession.Validating
        Select Case sender.name
            Case TxtProgramme.Name
                If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                    With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                        TxtProgrammeDuration.Text = AgL.VNull(.Item("ProgrammeDuration", .CurrentCell.RowIndex).Value)
                        TxtSemesters.Text = AgL.VNull(.Item("Semesters", .CurrentCell.RowIndex).Value)
                        TxtSemesterDuration.Text = AgL.VNull(.Item("SemesterDuration", .CurrentCell.RowIndex).Value)
                    End With
                End If
            Case TxtSession.Name
                If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                    With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                        TxtSessionStartDate.Text = AgL.XNull(.Item("StartDate", .CurrentCell.RowIndex).Value)
                    End With
                End If

        End Select

    End Sub
End Class
