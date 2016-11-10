Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRoomLeft
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mObjClsMain As New ClsMain(AgL, PLib)

    Dim mAllotmentDocId$ = ""

    Public Property AllotmentDocId() As String
        Get
            AllotmentDocId = mAllotmentDocId
        End Get
        Set(ByVal value As String)
            mAllotmentDocId = value
        End Set
    End Property

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
            AgL.WinSetting(Me, 431, 895, 0, 0)
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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("HRL.LeftDate", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("HRL.Site_Code", AgL.PubSiteCode) & " "

            mQry = "Select HRL.AllotmentDocId As SearchCode " & _
                    " From Ht_RoomLeft HRL " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()


        mQry = "SELECT Vra.DocId AS Code, Vra.MemberName, Vra.FatherName, Vra.MemberDispName, " & _
                " Rt.Room AS CurrentRoom, Rt.AllotmentDate, Vra.LeftDate " & _
                " FROM ViewHt_RoomAllotment Vra " & _
                " LEFT JOIN Ht_RoomTransfer Rt ON Vra.DocId=Rt.AllotmentDocId " & _
                " Where " & AgL.PubSiteCondition("Vra.Site_Code", AgL.PubSiteCode) & " " & _
                " AND Rt.TransferDate Is NULL "

        TxtAllotmentDocId.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT VHR.Code,VHR.BuildingFloorRoomDesc AS RoomDescription,VHR.TotalBed  " & _
                " FROM ViewHt_Room VHR  " & _
                " Where " & AgL.PubSiteCondition("VHR.Site_Code", AgL.PubSiteCode) & " "

        TxtRoom.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)
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

                    AgL.Dman_ExecuteNonQry("Delete From Ht_RoomLeft Where AllotmentDocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        TxtAllotmentDocId.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Rl.LeftDate", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("Rl.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQry = "SELECT Sg.DispName As [Member Name], " & _
                                " Vr.BuildingFloorRoomDesc AS Room,Rl.LeftDate, Rl.LeftRemark " & _
                                " FROM Ht_RoomLeft Rl " & _
                                " LEFT JOIN Ht_RoomTransfer Rt ON Rl.AllotmentDocId=Rt.AllotmentDocId  " & _
                                " AND Rt.AllotmentType ='" & AllotmentType_Allotment & "' " & _
                                " LEFT JOIN SubGroup Sg ON Rt.SubCode=Sg.SubCode " & _
                                " LEFT JOIN ViewHt_Room Vr ON Rl.Room=Vr.Code  " & _
                                " " & mCondStr & ""



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

    Private Sub Topctrl_tbPrn() Handles Topctrl1.tbPrn
        Call PrintDocument(mSearchCode)
    End Sub

    Private Sub PrintDocument(ByVal mDocId As String)
        Dim ds As New DataSet
        Dim strQry As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Room Left"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = " SELECT  Rl.LeftDate AS [Left Date], Rl.LeftRemark AS [Left Remark], " & _
                     " S.Name as [Site Name ], " & _
                     " Vra.MemberDispName As [Member Name], Vr.BuildingFloorRoomDesc AS [Building/Floor/Room], Vr.HostelDesc AS Hostel" & _
                     " FROM dbo.Ht_RoomLeft Rl " & _
                     " LEFT JOIN ViewHt_RoomAllotment Vra ON Rl.AllotmentDocId = Vra.DocId " & _
                     " LEFT JOIN ViewHt_Room Vr ON Rl.Room = Vr.Code   " & _
                     " LEFT JOIN SiteMast S ON Rl.Site_Code = S.Code " & _
                     " WHERE Rl.AllotmentDocId = '" & mSearchCode & "'"

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Room Left"
            mPrnHnd.TableIndex = 0
            mPrnHnd.PageSetupDialog(True)
            mPrnHnd.PrintPreview()
            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        Me.Cursor = Cursors.Default



    End Sub


    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bAmount As Double = 0

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then

                mQry = "INSERT INTO dbo.Ht_RoomLeft(AllotmentDocId, Room, LeftDate, LeftRemark," & _
                        " Div_Code,Site_Code,PreparedBy,U_EntDt,U_AE) " & _
                        " VALUES('" & mSearchCode & "', " & AgL.Chk_Text(TxtRoom.AgSelectedValue) & "," & _
                        " " & AgL.ConvertDate(TxtLeftDate.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & "," & _
                        " '" & AgL.PubDivCode & "','" & AgL.PubSiteCode & "','" & AgL.PubUserName & "',   " & _
                        " '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "','A') "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else

                mQry = "UPDATE dbo.Ht_RoomLeft " & _
                         " SET Room = " & AgL.Chk_Text(TxtRoom.AgSelectedValue) & ", " & _
                         " LeftDate = " & AgL.ConvertDate(TxtLeftDate.Text) & ", " & _
                         " LeftRemark = " & AgL.Chk_Text(TxtRemark.Text) & "," & _
                         " U_AE = 'E', " & _
                         " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                         " ModifiedBy = '" & AgL.PubUserName & "' " & _
                         " WHERE AllotmentDocId = '" & mSearchCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            '===============================================================================================================================================
            '==================< Update Current Room >==================================================================================================
            '===========================< Start >===========================================================================================================
            '===============================================================================================================================================
            If Not mObjClsMain.FunUpdateCurrentRoom(mSearchCode, AgL.GCn, AgL.ECmd) Then
                Err.Raise(1, , "Error In Current Room Updating!...")
            End If
            '===============================================================================================================================================
            '==================< Update Current Room >==================================================================================================
            '===========================< End >=============================================================================================================
            '===============================================================================================================================================

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
                mAllotmentDocId = ""

                Topctrl1.FButtonClick(0)

                'If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    Call PrintDocument(mDocId)
                'End If

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
        Dim DrTemp As DataRow() = Nothing
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
                mQry = "SELECT Hrl.*,Hrt.SubCode  " & _
                        " FROM Ht_RoomLeft Hrl " & _
                        " LEFT JOIN Ht_RoomTransfer Hrt ON Hrl.AllotmentDocId=Hrt.AllotmentDocId  " & _
                        " WHERE Hrl.AllotmentDocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtAllotmentDocId.AgSelectedValue = AgL.XNull(.Rows(0)("AllotmentDocId"))
                        TxtRoom.AgSelectedValue = AgL.XNull(.Rows(0)("Room"))
                        TxtLeftDate.Text = Format(AgL.XNull(.Rows(0)("LeftDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtRemark.Text = AgL.XNull(.Rows(0)("LeftRemark"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)


                        If TxtAllotmentDocId.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtAllotmentDocId.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & "")
                            LblAllotmentDocId.Tag = AgL.XNull(DrTemp(0)("CurrentRoom"))
                            LblAllotmentDocIdReq.Tag = AgL.XNull(DrTemp(0)("AllotmentDate"))
                        End If

                    End If
                End With
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

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
        TxtRoom.Enabled = False
        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then TxtAllotmentDocId.Enabled = False

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
           TxtAllotmentDocId.Enter, TxtRoom.Enter, TxtRemark.Enter
        Try
            Select Case sender.name

                Case TxtAllotmentDocId.Name
                    TxtAllotmentDocId.AgRowFilter = " LeftDate IS NULL "

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtAllotmentDocId.Validating, TxtRoom.Validating, TxtRemark.Validating, TxtLeftDate.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtAllotmentDocId.Name

                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblAllotmentDocId.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtAllotmentDocId.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & "")
                            LblAllotmentDocId.Tag = AgL.XNull(DrTemp(0)("CurrentRoom"))
                            TxtRoom.AgSelectedValue = LblAllotmentDocId.Tag
                            LblAllotmentDocIdReq.Tag = AgL.XNull(DrTemp(0)("AllotmentDate"))
                        End If
                    End If

                Case TxtLeftDate.Name
                    If TxtLeftDate.Text.Trim = "" Then TxtLeftDate.Text = AgL.PubLoginDate

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Try

            If AgL.RequiredField(TxtAllotmentDocId) Then Exit Function
            If AgL.RequiredField(TxtRoom, "Room") Then Exit Function
            If AgL.RequiredField(TxtLeftDate, "Left Date") Then Exit Function
            If Not AgL.IsValidDate(TxtLeftDate, AgL.PubStartDate, AgL.PubEndDate, "Left Date") Then Exit Function
            mSearchCode = TxtAllotmentDocId.AgSelectedValue

            If Not AgL.StrCmp(TxtRoom.AgSelectedValue, LblAllotmentDocId.Tag) Then
                MsgBox("'" & TxtAllotmentDocId.Text & "' does not belongs to '" & TxtRoom.Text & "' ...", MsgBoxStyle.Information) : TxtRoom.Focus() : TxtRoom.AgSelectedValue = LblAllotmentDocId.Tag : Exit Function
            End If

            If CDate(TxtLeftDate.Text) < CDate(LblAllotmentDocIdReq.Tag) Then
                MsgBox("Left Date Can't Be Less Than From " & LblAllotmentDocIdReq.Tag & "!...")
                TxtLeftDate.Focus()
                Exit Function
            End If

            mQry = "SELECT count(CD1.Code) AS Cnt " & _
                    " FROM Ht_ChargeDue1 CD1  " & _
                    " LEFT JOIN Ht_ChargeDue CD ON CD.DocId=CD1.DocId " & _
                    " WHERE CD1.Code NOT IN (SELECT CR1.ChargeDue1  " & _
                    " 						FROM Ht_ChargeReceive CR  " & _
                    " 						LEFT JOIN Ht_ChargeReceive1 CR1 ON CR.DocId=CR1.DocId  " & _
                    " 						WHERE CR.AllotmentDocId=" & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " )  " & _
                    " AND CD.V_Date <= " & AgL.ConvertDate(TxtLeftDate.Text) & " " & _
                    " AND CD1.AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " "

            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar() > 0 Then MsgBox("'" & TxtAllotmentDocId.Text & "' Can't Left The Hostel." + vbCrLf + "There is an Outstanding Amount.....!", MsgBoxStyle.Information) : TxtAllotmentDocId.Focus() : Exit Function

            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                mQry = "SELECT isnull(count(HRT.AllotmentDocId),0) AS Cnt  " & _
                        " FROM Ht_RoomLeft HRT " & _
                        " WHERE HRT.AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar() > 0 Then MsgBox("'" & TxtAllotmentDocId.Text & "' has already left the hostel.....!", MsgBoxStyle.Information) : TxtAllotmentDocId.Focus() : Exit Function
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
        TxtAllotmentDocId.Focus()

        If mAllotmentDocId.Trim <> "" Then
            TxtAllotmentDocId.Focus()
            TxtAllotmentDocId.AgSelectedValue = mAllotmentDocId
            TxtLeftDate.Focus()
        End If
    End Sub

    'Private Sub ProcFillRoomLeftDetail()
    '    Dim DrTemp As DataRow() = Nothing
    '    If Topctrl1.Mode = "Browse" Then Exit Sub
    '    If mAllotmentDocId.Trim = "" Then Exit Sub
    '    Dim DtTemp As DataTable = Nothing

    '    Try
    '        TxtAllotmentDocId.AgSelectedValue = mAllotmentDocId
    '        If TxtAllotmentDocId.AgHelpDataSet IsNot Nothing Then
    '            DrTemp = TxtAllotmentDocId.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & "")
    '            LblAllotmentDocId.Tag = AgL.XNull(DrTemp(0)("CurrentRoom"))
    '            TxtRoom.AgSelectedValue = LblAllotmentDocId.Tag
    '            LblAllotmentDocIdReq.Tag = AgL.XNull(DrTemp(0)("AllotmentDate"))
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally
    '        DtTemp = Nothing
    '    End Try
    'End Sub
End Class