Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmSessionProgrammeStreamOC
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
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
        ''==============================================================================
        ''================< Executable Code >=============================================
        ''==============================================================================
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

            If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)
        End If
    End Sub

    Private Sub OpenLinkForm(ByVal Sender As Object)
        Try
            Me.Cursor = Cursors.WaitCursor
            If Topctrl1.Mode = "Browse" Then Exit Sub
            Select Case Sender.name
                'Case <Sender>.Name
                'PObj.FOpen_LinkForm_Common_Master("MnuCustomerMaster", "Customer Master", Me.MdiParent)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 450, 880, 0, 0)
            IniGrid()
            If AgL.PubMoveRecApplicable Then FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr As String


        If AgL.PubMoveRecApplicable Then
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " "

            mQry = "Select S.Code As SearchCode " & _
                    " From Sch_SessionProgrammeStreamOC S " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT E.SubCode AS Code, Sg.Name " & _
                " FROM Pay_Employee E " & _
                " LEFT JOIN SubGroup Sg ON E.SubCode = Sg.SubCode " & _
                " WHERE (IsNull(E.IsTeachingStaff,0)<>0 or IsNull(E.CanTakeClass,0)<>0) And " & _
                " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                " ORDER BY Sg.Name "
        TxtOC.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.Code, S.ManualCode AS Name, S.StartDate " & _
                " FROM Sch_Session S " & _
                " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY S.ManualCode "
        TxtSession.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.Code, S.SessionProgrammeStream AS Name, S.SessionCode " & _
                " FROM ViewSch_SessionProgrammeStream S " & _
                " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By S.SessionProgrammeStream "
        TxtSessionProgrammeStream.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            If mSearchCode <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    AgL.Dman_ExecuteNonQry("Delete From Sch_SessionProgrammeStreamOC Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

                    AgL.ETrans.Commit()
                    mTrans = False

                    If AgL.PubMoveRecApplicable Then
                        FIniMaster(1)
                        Topctrl_tbRef()
                    Else
                        AgL.PubSearchRow = ""
                    End If
                    MoveRec()

                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl_tbDiscard() Handles Topctrl1.tbDiscard
        If AgL.PubMoveRecApplicable Then FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtFromDate.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("So.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQry = "SELECT So.Code AS SearchCode, S.SessionProgrammeStream AS [Session/Programme/Stream] , Sg.Name AS [OC Name] , So.FromDate , So.UptoDate , " & _
                                " Sm.Name AS [Site Name], S.SessionManualCode AS Session , S.ProgrammeManualCode AS Programme, S.StreamManualCode AS Stream " & _
                                " FROM Sch_SessionProgrammeStreamOC So " & _
                                " LEFT JOIN SiteMast Sm on So.Site_Code = Sm.Code " & _
                                " LEFT JOIN ViewSch_SessionProgrammeStream S ON So.SessionProgrammeStream = S.Code " & _
                                " LEFT JOIN SubGroup Sg ON So.OC = Sg.SubCode " & _
                                " " & mCondStr & " "

            AgL.PubFindQryOrdBy = "[SearchCode]"


            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                If AgL.PubMoveRecApplicable Then
                    AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                    BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                End If
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        Dim ds As New DataSet
        Dim strQry As String = "", mCondStr$ = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "OC Assign Detail"
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("So.Site_Code", AgL.PubSiteCode) & " "

            strQry = "SELECT S.SessionProgrammeStream AS [Session/Programme/Stream] , Sg.Name AS [OC Name] , So.FromDate , So.UptoDate " & _
                                " FROM Sch_SessionProgrammeStreamOC So " & _
                                " LEFT JOIN SiteMast Sm on So.Site_Code = Sm.Code " & _
                                " LEFT JOIN ViewSch_SessionProgrammeStream S ON So.SessionProgrammeStream = S.Code " & _
                                " LEFT JOIN SubGroup Sg ON So.OC = Sg.SubCode " & _
                                " " & mCondStr & " " & _
                                " Order By S.SessionProgrammeStream, So.FromDate "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "OC Assign Detail"
            mPrnHnd.TableIndex = 0
            mPrnHnd.PageSetupDialog(True)
            mPrnHnd.PrintPreview()
            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_SessionProgrammeStreamOC " & _
                        " ( " & _
                        " Code, SessionProgrammeStream, OC, FromDate, UptoDate, Remark, " & _
                        " Div_Code, Site_Code, " & _
                        " PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES " & _
                        " ( " & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtOC.AgSelectedValue) & ", " & AgL.ConvertDate(TxtFromDate.Text) & ", " & _
                        " " & AgL.ConvertDate(TxtUptoDate.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_SessionProgrammeStreamOC " & _
                        " SET " & _
                        " 	SessionProgrammeStream = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & ", " & _
                        " 	OC = " & AgL.Chk_Text(TxtOC.AgSelectedValue) & ", " & _
                        " 	FromDate = " & AgL.ConvertDate(TxtFromDate.Text) & ", " & _
                        " 	UptoDate = " & AgL.ConvertDate(TxtUptoDate.Text) & ", " & _
                        " 	Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " 	U_AE = 'E', " & _
                        " 	Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " 	ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE Code = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)


            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode

                Topctrl1.FButtonClick(0)

                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If

            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim MastPos As Long
        Dim mTransFlag As Boolean = False

        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            FClear()
            BlankText()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then
                mQry = "Select So.*, St.SessionCode, S.StartDate " & _
                        " From Sch_SessionProgrammeStreamOC So " & _
                        " Left Join ViewSch_SessionProgrammeStream St On St.Code = So.SessionProgrammeStream " & _
                        " Left Join Sch_Session S On St.SessionCode = S.Code " & _
                        " Where So.Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtSession.AgSelectedValue = AgL.XNull(.Rows(0)("SessionCode"))

                        TxtSessionProgrammeStream.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgrammeStream"))
                        LblSessionProgrammeStream.Tag = AgL.XNull(.Rows(0)("SessionCode"))

                        TxtOC.AgSelectedValue = AgL.XNull(.Rows(0)("OC"))
                        TxtFromDate.Text = Format(AgL.XNull(.Rows(0)("FromDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblFromDate.Tag = Format(AgL.XNull(.Rows(0)("StartDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                        TxtUptoDate.Text = Format(AgL.XNull(.Rows(0)("UptoDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                mQry = "Select IsNull(count(*),0) Cnt " & _
                        " From Sch_SessionProgrammeStreamOC So " & _
                        " Where So.SessionProgrammeStream = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " And " & _
                        " So.FromDate > " & AgL.ConvertDate(TxtUptoDate.Text) & " And So.UptoDate Is Null "
                AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then mTransFlag = True

                If mTransFlag Then
                    Topctrl1.tEdit = False
                    Topctrl1.tDel = False
                Else
                    If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                    If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            DTbl = Nothing
            'Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
    End Sub



    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtSite_Code.Enter, TxtRemark.Enter, TxtFromDate.Enter, TxtUptoDate.Enter, TxtSession.Enter, _
        TxtSessionProgrammeStream.Enter, TxtOC.Enter


        Try
            Select Case sender.name
                Case TxtSessionProgrammeStream.Name
                    TxtSessionProgrammeStream.AgRowFilter = " SessionCode = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & " "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtRemark.Validating, TxtFromDate.Validating, TxtUptoDate.Validating, TxtSession.Validating, _
        TxtSessionProgrammeStream.Validating, TxtOC.Validating

        Try
            Select Case sender.NAME
                Case TxtFromDate.Name
                    If TxtFromDate.Text.ToString.Trim = "" Then TxtFromDate.Text = LblFromDate.Tag

                Case TxtSession.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        '<Executable Code>
                        LblFromDate.Tag = ""

                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblFromDate.Tag = Format(AgL.XNull(.Item("StartDate", .CurrentCell.RowIndex).Value), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            End With
                        End If
                    End If

                Case TxtSessionProgrammeStream.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        '<Executable Code>
                        LblSessionProgrammeStream.Tag = ""

                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblSessionProgrammeStream.Tag = AgL.XNull(.Item("SessionCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

            End Select

            If Not AgL.StrCmp(TxtSession.AgSelectedValue, LblSessionProgrammeStream.Tag) Then
                TxtSessionProgrammeStream.AgSelectedValue = ""
                LblSessionProgrammeStream.Tag = ""
            End If

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        If Topctrl1.Mode = "Browse" Then Exit Sub
    End Sub


    Private Function Data_Validation() As Boolean
        Dim bUpToDate As String = ""
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtSession, "Session") Then Exit Function
            If AgL.RequiredField(TxtSessionProgrammeStream, "Session/Programme/Stream") Then Exit Function
            If AgL.RequiredField(TxtOC, "OC Name") Then Exit Function
            If AgL.RequiredField(TxtFromDate, "From Date") Then Exit Function


            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            If Not AgL.StrCmp(TxtSession.AgSelectedValue, LblSessionProgrammeStream.Tag) Then
                MsgBox("Session/Programme/Stream Is Mismatching!...") : TxtSessionProgrammeStream.Focus() : Exit Function
            End If

            If CDate(TxtFromDate.Text) < CDate(LblFromDate.Tag) Then
                MsgBox("From Date Can't Be Less Than From " & LblFromDate.Tag & "")
                TxtFromDate.Focus() : Exit Function
            End If

            If TxtUptoDate.Text.Trim <> "" Then
                If CDate(TxtUptoDate.Text) <= CDate(TxtFromDate.Text) Then
                    MsgBox("Upto Date Can't Be Less Than Or Equal To From " & TxtFromDate.Text & "")
                    TxtUptoDate.Focus() : Exit Function
                End If
            End If

            If Topctrl1.Mode = "Add" Then
                mQry = "Select IsNull(count(*),0) Cnt " & _
                        " From Sch_SessionProgrammeStreamOC So " & _
                        " Where So.SessionProgrammeStream = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " And " & _
                        " So.UptoDate Is Null "
                AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("An OC Is Already Active!...") : TxtFromDate.Focus() : Exit Function
            End If

            mQry = "Select Max(So.UpToDate) As UpToDate " & _
                    " From Sch_SessionProgrammeStreamOC So " & _
                    " Where So.SessionProgrammeStream = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " And " & _
                    " So.UptoDate >= " & AgL.ConvertDate(TxtFromDate.Text) & " And " & _
                    " " & IIf(Topctrl1.Mode = "Add", " 1=1 ", " So.Code <> '" & mSearchCode & "' ") & " "
            AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
            bUpToDate = AgL.XNull(AgL.ECmd.ExecuteScalar())

            If bUpToDate.ToString.Trim <> "" Then
                MsgBox("From Date Must Be Greater Than From " & bUpToDate & "!...") : TxtFromDate.Focus() : Exit Function
            End If


            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetMaxId("Sch_SessionProgrammeStreamOC", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 6, True, True, , AgL.Gcn_ConnectionString)
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode

        TxtSession.Focus()
    End Sub

End Class

