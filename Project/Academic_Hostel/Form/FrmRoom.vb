Public Class FrmRoom
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
        AGL.FPaintForm(Me, e, Topctrl1.Height)
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
        End If
    End Sub


    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AGL.CheckQuote(e)
    End Sub

    Private Sub FrmRoom_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            AgL.WinSetting(Me, 400, 880, 0, 0)
            IniGrid()
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = " Select HR.Code As SearchCode " & _
                " From Ht_Room HR " & _
                " Where " & AgL.PubSiteCondition("HR.Site_Code", AgL.PubSiteCode) & ""
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        mQry = " Select HR.Code  As Code, HR.Description As Name From Ht_Room HR " & _
                " Where " & AgL.PubSiteCondition("HR.Site_Code", AgL.PubSiteCode) & " Order By Description"
        TxtDescription.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT HBF.Code, HB.Description+'\'+HF.Description AS [Buiding Floor], " & _
                " HBF.TotalRooms AS [Total Rooms], R.RoomNoPrefix " & _
                " FROM Ht_BuildingFloor HBF " & _
                " LEFT JOIN Ht_Building HB ON HB.Code =HBF.Building  " & _
                " LEFT JOIN Ht_Floor HF ON HF.Code =HBF.Floor  " & _
                " LEFT JOIN Ht_Room R ON HBF.Code = R.BuildingFloor "
        TxtBuildingFloor.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT HRT.Code, HRT.Description, HRT.ManualCode AS [Manual code] FROM Ht_RoomType HRT " & _
                " Where " & AgL.PubSiteCondition("HRT.Site_Code", AgL.PubSiteCode) & "" & _
                " Order By Description"
        TxtRoomType.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtBuildingFloor.Focus()
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

                    AgL.Dman_ExecuteNonQry(" Delete From Ht_Room Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        TxtBuildingFloor.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = " SELECT HR.Code, HR.Description ,HB.Description +'\'+HF.Description AS  [Building Floor], HRT.Description AS [Room Type], HR.Location, HR.TotalBed as [Total Bed]" & _
                             " FROM Ht_Room HR " & _
                             " LEFT JOIN Ht_BuildingFloor HBF ON HBF.Code=HR.BuildingFloor  " & _
                             " LEFT JOIN Ht_Building HB ON HBF.Building =HB.Code  " & _
                             " LEFT JOIN Ht_Floor HF ON HBF.Floor =HF.Code  " & _
                             " LEFT JOIN Ht_RoomType HRT ON HR.RoomType =HRT.Code  " & _
                             " Where " & AgL.PubSiteCondition("HR.Site_Code", AgL.PubSiteCode) & ""

            AgL.PubFindQryOrdBy = "[Description]"


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
            AgL.PubReportTitle = "Room List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = " SELECT HR.Description As Room,HB.Description +'\'+HF.Description AS  [Building Floor], HRT.Description AS [Room Type], HR.Location, HR.TotalBed as [Total Bed]" & _
                        " FROM Ht_Room HR " & _
                        " LEFT JOIN Ht_BuildingFloor HBF ON HBF.Code=HR.BuildingFloor  " & _
                        " LEFT JOIN Ht_Building HB ON HBF.Building =HB.Code  " & _
                        " LEFT JOIN Ht_Floor HF ON HBF.Floor =HF.Code  " & _
                        " LEFT JOIN Ht_RoomType HRT ON HR.RoomType =HRT.Code  " & _
                        " Where " & AgL.PubSiteCondition("HR.Site_Code", AgL.PubSiteCode) & ""

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Room List"
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
        Dim mTrans As Boolean = False
        Try
            MastPos = BMBMaster.Position

            If AgCL.AgCheckMandatory(Me) = False Then Exit Sub
            If Not Data_Validation() Then Exit Sub


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then




                mQry = " INSERT INTO Ht_Room (Code,Description, RoomNoPrefix, RoomNoSuffix, BuildingFloor,RoomType,Location,TotalBed, IsRoomAllocatable, Div_Code,Site_Code,PreparedBy,U_EntDt,U_AE ) " & _
                         " Values ('" & mSearchCode & "', " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                         " " & AgL.Chk_Text(TxtRoomNoPrefix.Text) & ", " & AgL.Chk_Text(TxtRoomNoSuffix.Text) & " , " & _
                         " " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & ", " & _
                         " " & AgL.Chk_Text(TxtRoomType.AgSelectedValue) & ", " & _
                         " " & AgL.Chk_Text(TxtLocation.Text) & "," & Val(TxtTotalBrd.Text) & "," & _
                         " " & IIf(AgL.StrCmp(TxtIsRoomAllocatable.Text, "Yes"), 1, 0) & ", " & _
                         " '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', 'A')  "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = " UPDATE dbo.Ht_Room SET " & _
                         " Description = " & AgL.Chk_Text(TxtDescription.Text) & ",	" & _
                         " RoomNoPrefix = " & AgL.Chk_Text(TxtRoomNoPrefix.Text) & " , " & _
                         " RoomNoSuffix = " & AgL.Chk_Text(TxtRoomNoSuffix.Text) & " , " & _
                         " BuildingFloor = " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & ", " & _
                         " RoomType = " & AgL.Chk_Text(TxtRoomType.AgSelectedValue) & ", " & _
                         " Location = " & AgL.Chk_Text(TxtLocation.Text) & ", " & _
                         " TotalBed = " & Val(TxtTotalBrd.Text) & ", " & _
                         " IsRoomAllocatable = " & IIf(AgL.StrCmp(TxtIsRoomAllocatable.Text, "Yes"), 1, 0) & ", " & _
                         " U_AE = 'E', " & _
                         " Edit_Date = '" & Format(AgL.PubLoginDate, "Short Date") & "',	ModifiedBy = '" & AgL.PubUserName & "'" & _
                         " Where Code='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
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

    Private Function Data_Validation() As Boolean
        Try
            Dim bTotalRoom As Integer
            If AgCL.AgCheckMandatory(Me) = False Then Exit Function


            If AgL.RequiredField(TxtBuildingFloor, "Building Floor") Then Exit Function
            If AgL.RequiredField(TxtRoomNoSuffix, "RoomNoSuffix") Then Exit Function
            If AgL.RequiredField(TxtRoomType, "Room Type") Then Exit Function
            If AgL.RequiredField(TxtTotalBrd, "Total Bed") Then Exit Function
            bTotalRoom = Val(LblBuildingFloor.Tag)
            'mQry = " SELECT TotalRooms FROM Ht_BuildingFloor WHERE Code = " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & " "
            'AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
            'bTotalRoom = AgL.ECmd.ExecuteScalar()
            mQry = " SELECT count(*) FROM Ht_Room WHERE BuildingFloor = " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Code <> '" & mSearchCode & "' ") & " "
            AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
            If AgL.ECmd.ExecuteScalar() + 1 > bTotalRoom Then MsgBox("All The Rooms For """ & TxtBuildingFloor.Text & """ Are Already Created.....!", MsgBoxStyle.Information) : Exit Function

            If Topctrl1.Mode = "Add" Then

                mQry = " SELECT count(*) FROM Ht_Room " & _
                         "WHERE Description =" & AgL.Chk_Text(TxtRoomNoSuffix.Text) & " AND BuildingFloor= " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & " "
                AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Room Already Exists.........!", MsgBoxStyle.Information) : Exit Function

                mSearchCode = AgL.GetMaxId("Ht_Room", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)
            Else
                mQry = " SELECT count(*) FROM Ht_Room " & _
                        "WHERE Description =" & AgL.Chk_Text(TxtRoomNoSuffix.Text) & " AND BuildingFloor= " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & " And Code<>'" & mSearchCode & "' "
                AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Room is Already Exist........!", MsgBoxStyle.Information) : Exit Function

            End If


            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim DrTemp As DataRow()
        Dim MastPos As Long
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = " SELECT * From Ht_Room " & _
                        "Where Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDescription.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                        TxtBuildingFloor.AgSelectedValue = AgL.XNull(.Rows(0)("BuildingFloor"))
                        TxtRoomNoSuffix.Text = AgL.XNull(.Rows(0)("RoomNoSuffix"))
                        TxtRoomType.AgSelectedValue = AgL.XNull(.Rows(0)("RoomType"))
                        TxtLocation.Text = AgL.XNull(.Rows(0)("Location"))
                        TxtTotalBrd.Text = AgL.VNull(.Rows(0)("TotalBed"))
                        TxtIsRoomAllocatable.Text = IIf(AgL.VNull(.Rows(0)("IsRoomAllocatable")), "Yes", "No")
                        If TxtBuildingFloor.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtBuildingFloor.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & "")
                            LblBuildingFloor.Tag = AgL.XNull(DrTemp(0)("Total Rooms"))
                            'Code By Akash on Date 13-11-10
                            'LblBuildingFloorReq.Tag = AgL.XNull(DrTemp(0)("RoomNoPrefix"))
                            TxtRoomNoPrefix.Text = AgL.XNull(DrTemp(0)("RoomNoPrefix"))
                            'End Code
                        End If

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
        mSearchCode = ""
        TxtIsRoomAllocatable.Text = "Yes"
        TxtDescription.Enabled = False
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

    Private Sub Control_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
    TxtBuildingFloor.Validating, TxtLocation.Validating, TxtRoomType.Validating, TxtRoomNoSuffix.Validating, TxtDescription.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtBuildingFloor.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblBuildingFloor.Tag = ""
                        LblBuildingFloorReq.Tag = ""

                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtBuildingFloor.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & "")
                            LblBuildingFloor.Tag = AgL.VNull(DrTemp(0)("Total Rooms"))
                            'Code By Akash on date 13-11-10
                            'LblBuildingFloorReq.Tag = AgL.XNull(DrTemp(0)("RoomNoPrefix"))
                            TxtRoomNoPrefix.Text = AgL.XNull(DrTemp(0)("RoomNoPrefix"))
                            'End code
                        End If
                    End If

                Case TxtRoomNoSuffix.Name
                    If sender.text.ToString.Trim = "" Then
                        TxtDescription.Text = ""
                    Else
                        TxtDescription.Text = TxtRoomNoPrefix.Text & TxtRoomNoSuffix.Text
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub
End Class