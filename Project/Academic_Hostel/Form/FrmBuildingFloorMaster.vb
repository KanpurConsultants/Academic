Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmBuildingFloorMaster
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Description As Byte = 1
    Private Const Col1RoomType As Byte = 2
    Private Const Col1Location As Byte = 3
    Private Const Col1TotalBed As Byte = 4
    Private Const Col1IsRoomAllocatable As Byte = 5
    Private Const Col1RoomNoSuffix As Byte = 6


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
        ''================< Rooms Grid >====================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1Description", 130, 20, "Description", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1RoomType", 130, 20, "Room Type", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1Location", 280, 100, "Location", True, False, False)
            .AddAgNumberColumn(DGL1, "Dgl1TotalBed", 100, 3, 0, False, "Room Capacity (In Beds)", True, False, True)
            .AddAgCheckBoxColumn(DGL1, "Dgl1IsRoomAllocatable", 100, "Room Allocatable", True, False)
            .AddAgNumberColumn(DGL1, "Dgl1RoomNoSuffix", 100, 5, 0, False, "Room No Suffix", False, True, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False
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
            AgL.WinSetting(Me, 530, 880, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            FIniMaster()
            Ini_List()
            DispText(False)
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "Select Code As SearchCode " & _
                " From Ht_BuildingFloor  "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        mQry = "Select Code  As Code, Description As Name " & _
                " From Ht_Building  " & _
                " Order By ManualCode"
        TxtBuilding.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code  As Code, Description As Name " & _
                " From Ht_Floor  " & _
                " Order By Description"
        TxtFloor.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT HRT.Code, HRT.Description, HRT.ManualCode AS [Manual code] " & _
                " FROM Ht_RoomType HRT " & _
                " Where " & AgL.PubSiteCondition("HRT.Site_Code", AgL.PubSiteCode) & "" & _
                " Order By Description"
        DGL1.AgHelpDataSet(Col1RoomType, 1) = AgL.FillData(mQry, AgL.GCn)

    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtBuilding.Focus()
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
                    AgL.Dman_ExecuteNonQry(" Delete From Ht_Room Where BuildingFloor='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Ht_BuildingFloor  Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        TxtBuilding.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = " SELECT HBF.Code, HB.ManualCode AS Building,	HF.Description AS Floor, HBF.TotalRooms as [Total Room]" & _
                                " FROM Ht_BuildingFloor HBF " & _
                                " LEFT JOIN Ht_Building HB ON HB.Code = HBF.Building  " & _
                                " LEFT JOIN Ht_Floor HF ON HF.Code =HBF.Floor "

            AgL.PubFindQryOrdBy = "[Building]"


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
            AgL.PubReportTitle = "Building Floor List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = " SELECT HB.ManualCode AS Building,	HF.Description AS Floor, HBF.TotalRooms As [Total Rooms]" & _
                              " FROM Ht_BuildingFloor HBF " & _
                              " LEFT JOIN Ht_Building HB ON HB.Code = HBF.Building  " & _
                              " LEFT JOIN Ht_Floor HF ON HF.Code =HBF.Floor "


            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Building Floor List"
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
        Dim I As Integer
        Dim bRoomCode As String
        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = " INSERT INTO Ht_BuildingFloor ( Code, Building, Floor, TotalRooms ) " & _
                         " VALUES " & _
                         " ('" & mSearchCode & "', " & AgL.Chk_Text(TxtBuilding.AgSelectedValue) & ", " & AgL.Chk_Text(TxtFloor.AgSelectedValue) & " , " & AgL.Chk_Text(TxtTotalRooms.Text) & " ) "
                     
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else

                mQry = " UPDATE Ht_BuildingFloor SET " & _
                        " Building = " & AgL.Chk_Text(TxtBuilding.AgSelectedValue) & ", " & _
                        " Floor = " & AgL.Chk_Text(TxtFloor.AgSelectedValue) & ", " & _
                        " TotalRooms = " & AgL.Chk_Text(TxtTotalRooms.Text) & " " & _
                        " Where Code='" & mSearchCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Ht_Room Where BuildingFloor='" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                For I = 0 To .Rows.Count - 1
                    bRoomCode = AgL.GetMaxId("Ht_Room", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)

                    If .Item(Col1Description, I).Value IsNot Nothing And .Item(Col1RoomType, I).Value IsNot Nothing And .Item(Col1TotalBed, I).Value IsNot Nothing Then
                        mQry = " INSERT INTO Ht_Room (Code,Description, RoomNoPrefix, RoomNoSuffix, BuildingFloor," & _
                                " RoomType,Location,TotalBed,IsRoomAllocatable, " & _
                                " Div_Code,Site_Code,PreparedBy,U_EntDt,U_AE ) " & _
                                " VALUES ( " & _
                                " " & AgL.Chk_Text(bRoomCode) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Description, I).Value) & " , " & _
                                " " & AgL.Chk_Text(TxtRoomPrefix.Text) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1RoomNoSuffix, I).Value) & " , " & _
                                " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(.AgSelectedValue(Col1RoomType, I)) & ", " & AgL.Chk_Text(.Item(Col1Location, I).Value) & " , " & _
                                " " & Val(.Item(Col1TotalBed, I).Value) & "," & Val(.Item(Col1IsRoomAllocatable, I).Value) & ", " & _
                                " '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', 'A' " & _
                                "  ) "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
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

            If Topctrl1.Mode = "Add" Then
                mSearchCode = ""
            End If
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Try
            If AgL.RequiredField(TxtBuilding, "Building") Then Exit Function
            If AgL.RequiredField(TxtFloor, "Floor") Then Exit Function
            If AgL.RequiredField(TxtTotalRooms, "Total Room") Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)

            If Topctrl1.Mode = "Add" Then
                mQry = " SELECT count(*) FROM Ht_BuildingFloor " & _
                         "WHERE Building = " & AgL.Chk_Text(TxtBuilding.AgSelectedValue) & " AND Floor = " & AgL.Chk_Text(TxtFloor.AgSelectedValue) & " "
                AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Building Floor is Already Exist!") : Exit Function

                mSearchCode = AgL.GetMaxId("Ht_BuildingFloor", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)

            Else
                mQry = " SELECT count(*) FROM Ht_BuildingFloor " & _
                          "WHERE Building = " & AgL.Chk_Text(TxtBuilding.AgSelectedValue) & " AND Floor = " & AgL.Chk_Text(TxtFloor.AgSelectedValue) & " And Code<>'" & mSearchCode & "' "
                AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Building Floor is Already Exist!") : Exit Function
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Dim I As Integer
        Dim mTransFlag As Boolean = False
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select * From Ht_BuildingFloor " & _
                        " Where Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtBuilding.AgSelectedValue = AgL.XNull(.Rows(0)("Building"))
                        TxtFloor.AgSelectedValue = AgL.XNull(.Rows(0)("Floor"))
                        TxtTotalRooms.Text = AgL.VNull(.Rows(0)("TotalRooms"))
                      End If
                End With

                mQry = " SELECT HR.* " & _
                        " FROM Ht_Room HR  " & _
                        " LEFT JOIN Ht_BuildingFloor HBF ON HBF.Code =HR.BuildingFloor  " & _
                        " WHERE HR.BuildingFloor  = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        TxtRoomPrefix.Text = AgL.XNull(.Rows(0)("RoomNoPrefix"))
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.Item(Col1Description, I).Value = AgL.XNull(.Rows(I)("Description"))
                            DGL1.Item(Col1RoomNoSuffix, I).Value = AgL.XNull(.Rows(I)("RoomNoSuffix"))

                            DGL1.AgSelectedValue(Col1RoomType, I) = AgL.XNull(.Rows(I)("RoomType"))
                            DGL1.Item(Col1Location, I).Value = AgL.XNull(.Rows(I)("Location"))
                            DGL1.Item(Col1TotalBed, I).Value = AgL.VNull(.Rows(I)("TotalBed"))
                            DGL1.Item(Col1IsRoomAllocatable, I).Value = AgL.VNull(.Rows(I)("IsRoomAllocatable"))
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

        mSearchCode = ""
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        BtnFillRooms.Enabled = Enb
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


    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillRooms.Click
        Call ProcFillRoomDetails()
    End Sub



    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Description
                    'Call IniItemHelp(False, DGL1.AgSelectedValue(Col1BarCode, mRowIndex))
            End Select

        Catch ex As Exception

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
            End Select
            'Call Calculation()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        'Dim DrTemp as DataRow()
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                '<Executable Code>
            End Select
            'Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
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


    Public Sub ProcFillRoomDetails()
        Dim I As Integer, bIntRoomNoSuffix% = 0
        If AgL.RequiredField(TxtRoomPrefix, "Room Prefix") Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub


        bIntRoomNoSuffix = 0
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        For I = 0 To Val(TxtTotalRooms.Text) - 1
            DGL1.Rows.Add()

            bIntRoomNoSuffix += 1
            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
            DGL1.Item(Col1RoomNoSuffix, I).Value = bIntRoomNoSuffix.ToString
            DGL1.Item(Col1Description, I).Value = TxtRoomPrefix.Text & bIntRoomNoSuffix.ToString
            DGL1.Item(Col1IsRoomAllocatable, I).Value = 1
        Next I
    End Sub
End Class