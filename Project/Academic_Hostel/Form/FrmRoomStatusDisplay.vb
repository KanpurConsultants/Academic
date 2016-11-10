Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRoomStatusDisplay

    Private DTMaster As New DataTable()
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Room1 As Byte = 1
    Private Const Col1Room2 As Byte = 2
    Private Const Col1Room3 As Byte = 3
    Private Const Col1Room4 As Byte = 4
    Private Const Col1Room5 As Byte = 5
    Private Const Col1Room6 As Byte = 6
    Private Const Col1Room7 As Byte = 7
    Private Const Col1Room8 As Byte = 8
    Private Const Col1Room9 As Byte = 9
    Private Const Col1Room10 As Byte = 10


    ''============< Room Status Constants >==================================
    Public Const mRoomStatus_NonAllocable As String = "Non Allocable"
    Public Const mRoomStatus_Occupied As String = "Occupied"
    Public Const mRoomStatus_PartiallyOccupied As String = "Partially Occupied"
    Public Const mRoomStatus_Vacant As String = "Vacant"
    ''============< *************** >==================================h

    Dim mTotalFloor As Integer
    Dim mFloorNo As Integer

    Private Enum RoomStauts
        Occupied
        PartiallyOccupied
        Vacant
        NonAllocatable
    End Enum

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        Dim J As Integer

        ''==============================================================================
        ''================< Room Charge Data Grid >====================================
        ''==============================================================================

        DGL1.DefaultCellStyle.SelectionBackColor = Color.Cyan
        DGL1.DefaultCellStyle.SelectionForeColor = Color.Black
        'DGL1.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        'DGL1.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(1, Byte))

        DGL1.BackgroundColor = Color.White
        DGL1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        With AgCL
            'Code By Akash (Onle If Condition)
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", False, True, False)
            If TxtBuildingFloor.AgSelectedValue = "" Then
                For J = 1 To mTotalFloor
                    .AddAgTextColumn(DGL1, "DGL1Floor" & J.ToString, 70, 62, "Floor - " & J.ToString, True, True)
                Next
            Else
                .AddAgTextColumn(DGL1, "DGL1Floor" & J.ToString, 70, 62, "Floor - " & mFloorNo.ToString, True, True)
            End If
            'End Code

        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False
        DGL1.RowHeadersVisible = False
        DGL1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DGL1.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        DGL1.RowTemplate.Height = 70
        DGL1.AllowUserToResizeColumns = False
        DGL1.AllowUserToResizeRows = False
        DGL1.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F5 Then
            Topctrl1.TopKey_Down(e)
        End If
        If Me.ActiveControl IsNot Nothing Then
            If Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If

            'If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)
        End If
    End Sub

    Private Sub OpenLinkForm()
        Dim FrmObj As Form
        Dim CFOpen As New ClsFunction
        Try
            Me.Cursor = Cursors.WaitCursor
            'If Topctrl1.Mode = "Browse" Then Exit Sub
            Select Case AgL.MidStr(DGL1.CurrentCell.Tag, 10, DGL1.CurrentCell.Tag.ToString.Length - 10)
                'Case <Sender>.Name
                'PObj.FOpen_LinkForm_Common_Master("MnuCustomerMaster", "Customer Master", Me.MdiParent)

                Case Val(RoomStauts.Vacant).ToString
                    Dim MdiObj As New MDIMain
                    FrmObj = PObj.FOpen_LinkForm_Academic_Hostel(MdiObj.MnuRoomAllotment.Name, MdiObj.MnuRoomAllotment.Text, Me.MdiParent)
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmRoomAllotment).RoomCode = AgL.MidStr(DGL1.CurrentCell.Tag, 0, 10)
                    End If
                    MdiObj = Nothing

                Case Val(RoomStauts.NonAllocatable).ToString
                    MsgBox("Non Allocable!...", MsgBoxStyle.Information)

                Case Else
                    FrmObj = New FrmMemberStatus()
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmMemberStatus).Room = AgL.MidStr(DGL1.CurrentCell.Tag, 0, 10)
                    End If
                    FrmObj.MdiParent = Me.MdiParent
                    FrmObj.Show()
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
            AgL.WinSetting(Me, 673, 880, 0, 0)
            'AgL.GridDesign(DGL1)
            'IniGrid()
            'Topctrl1.ChangeAgGridState(DGL1, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr As String

        mCondStr = " Where " & AgL.PubSiteCondition("B.Site_Code", AgL.PubSiteCode) & " "

        mQry = "SELECT B.Code As SearchCode " & _
                " FROM Ht_Building B " & mCondStr

        DTMaster = AgL.FillData(mQry, AgL.GCn).Tables(0)
    End Sub

    Sub Ini_List()

        mQry = "Select Code As Code, Name As Name " & _
                " From SiteMast " & _
                " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " " & _
                " Order By Name "
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT H.Code AS Code, H.Description AS Name " & _
                " FROM Ht_Hostel H " & _
                " Where " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " "
        TxtHostel.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT B.Code, B.Description As [Building Name], B.Nature, B.Hostel AS HostelCode, vBf.TotalFloor " & _
                " FROM Ht_Building B " & _
                " Left Join (SELECT Count(Bf.FloorNo) As TotalFloor , Bf.Building  FROM ViewHt_BuildingFloor Bf GROUP BY Bf.Building) As vBf On vBf.Building = B.Code " & _
                " Where " & AgL.PubSiteCondition("B.Site_Code", AgL.PubSiteCode) & " "
        TxtBuilding.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Vb.Code AS Code, Vb.BuildingFloorDesc AS [Building/Floor], " & _
                " Vb.Building AS BuildingCode, Vb.Floor AS FloorCode, Vb.HostelCode, Vb.FloorNo " & _
                " FROM ViewHt_BuildingFloor Vb " & _
                " Where " & AgL.PubSiteCondition("Vb.Site_Code", AgL.PubSiteCode) & " "
        TxtBuildingFloor.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Rt.Code, Rt.Description AS RoomTypeDesc, Rt.ManualCode AS RoomTypeManualCode  " & _
                " FROM Ht_RoomType Rt " & _
                " Where " & AgL.PubSiteCondition("Rt.Site_Code", AgL.PubSiteCode) & " "
        TxtRoomType.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Vhr.Code,Vhr.BuildingFloorRoomDesc AS [Room Description],Vhr.TotalBed as RoomCapacity ," & _
                " Vhr.HostelCode, Vhr.RoomType, Vhr.BuildingFloor As BuildingFloorCode, Vhr.BuildingCode, Vhr.HostelCode, F.FloorNo  " & _
                " FROM ViewHt_Room Vhr  " & _
                " LEFT JOIN Ht_Floor F On Vhr.FloorCode = F.Code  " & _
                " Where " & AgL.PubSiteCondition("Vhr.Site_Code", AgL.PubSiteCode) & " "
        TxtRoom.AgHelpDataSet(6) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Vrt.AllotmentDocId, Vrt.MemberName AS MemberName, Vrt.FatherName, Vrt.Room AS MemberCurrentRoomCode, " & _
                " Vrt.BuildingFloorCode, Vrt.BuildingCode, Vrt.HostelCode, Vrt.FloorNo , Vrt.RoomTypeCode " & _
                " FROM ViewHt_RoomTransfer Vrt " & _
                " Where " & AgL.PubSiteCondition("Vrt.Site_Code", AgL.PubSiteCode) & " " & _
                " AND Vrt.TransferDate Is NULL And Vrt.LeftDate Is NULL "
        TxtMemberName.AgHelpDataSet(6) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Dim I As Integer = 0
        Dim bStreamYearSemester$ = "", bToStreamYearSemester$ = "", bLastSessionProgrammeStreamCode$ = ""
        Dim mTransFlag As Boolean = False, bIsStatusChanged As Boolean = False

        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            FClear()
            BlankText()

            If DTMaster.Rows.Count > 0 Then mSearchCode = DTMaster.Rows(0)("SearchCode")

            If mSearchCode <> "" Then
                mQry = "SELECT  B.*, vBf.TotalFloor " & _
                        " FROM Ht_Building B " & _
                        " Left Join (SELECT Count(Bf.FloorNo) As TotalFloor , Bf.Building  FROM ViewHt_BuildingFloor Bf GROUP BY Bf.Building) As vBf On vBf.Building = B.Code " & _
                        " WHERE B.Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtHostel.AgSelectedValue = AgL.XNull(.Rows(0)("Hostel"))
                        TxtBuilding.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                        LblBuilding.Tag = AgL.XNull(.Rows(0)("Hostel"))

                        mTotalFloor = AgL.VNull(.Rows(0)("TotalFloor"))

                    End If
                End With

                DGL1.Columns.Clear()
                Call IniGrid()

                Call ProcFillRoomStatus()
            Else
                BlankText()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            DTbl = Nothing
            'Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub BlankText()
        Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : mTotalFloor = 0
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
    End Sub

    Private Sub DGL1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellDoubleClick
        Call OpenLinkForm()
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                'Call IniItemHelp(False, DGL1.AgSelectedValue(Col1BarCode, mRowIndex))
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                'Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            'sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        Dim DrTemp As DataRow() = Nothing
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""


            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                '<Executalbe Code>
            End Select

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
         TxtRoom.Enter, TxtBuildingFloor.Enter, TxtHostel.Enter, TxtBuilding.Enter, TxtMemberName.Enter, TxtSite_Code.Enter, TxtRoomType.Enter
        Try
            Select Case sender.name
                Case TxtBuilding.Name
                    If TxtHostel.Text.ToString.Trim <> "" Then
                        TxtBuilding.AgRowFilter = " HostelCode = " & AgL.Chk_Text(TxtHostel.AgSelectedValue) & " "
                    Else
                        TxtBuilding.AgRowFilter = ""
                    End If


                Case TxtBuildingFloor.Name
                    If TxtBuilding.Text.ToString.Trim <> "" Then
                        TxtBuildingFloor.AgRowFilter = " BuildingCode = " & AgL.Chk_Text(TxtBuilding.AgSelectedValue) & " "
                    Else
                        TxtBuildingFloor.AgRowFilter = ""
                    End If

                Case TxtRoom.Name
                    'If TxtBuildingFloor.Text.ToString.Trim <> "" Then
                    '    TxtRoom.AgRowFilter = " BuildingFloorCode = " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & " "
                    'Else
                    '    TxtRoom.AgRowFilter = ""
                    'End If
                    If TxtRoomType.Text.ToString.Trim <> "" And TxtBuildingFloor.Text.ToString.Trim <> "" Then
                        TxtRoom.AgRowFilter = " RoomType = " & AgL.Chk_Text(TxtRoomType.AgSelectedValue) & " And BuildingFloorCode = " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & " "
                    ElseIf TxtRoomType.Text.ToString.Trim <> "" And TxtBuildingFloor.Text.ToString.Trim = "" Then
                        TxtRoom.AgRowFilter = " RoomType = " & AgL.Chk_Text(TxtRoomType.AgSelectedValue) & " "
                    ElseIf TxtRoomType.Text.ToString.Trim = "" And TxtBuildingFloor.Text.ToString.Trim <> "" Then
                        TxtRoom.AgRowFilter = " BuildingFloorCode = " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & " "
                    Else
                        TxtRoom.AgRowFilter = ""
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtRoom.Validating, TxtBuilding.Validating, TxtBuildingFloor.Validating, TxtHostel.Validating, TxtMemberName.Validating, TxtSite_Code.Validating, TxtRoomType.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtBuilding.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        mTotalFloor = 0
                        LblBuilding.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtBuilding.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            mTotalFloor = AgL.VNull(DrTemp(0)("TotalFloor"))
                            LblBuilding.Tag = AgL.XNull(DrTemp(0)("HostelCode"))
                            TxtHostel.AgSelectedValue = AgL.XNull(DrTemp(0)("HostelCode"))
                        End If
                    End If

                Case TxtBuildingFloor.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblBuildingFloor.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtBuildingFloor.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            LblBuildingFloor.Tag = AgL.XNull(DrTemp(0)("BuildingCode"))
                            mFloorNo = AgL.VNull(DrTemp(0)("FloorNo"))
                            TxtHostel.AgSelectedValue = AgL.XNull(DrTemp(0)("HostelCode"))
                            TxtBuilding.AgSelectedValue = AgL.XNull(DrTemp(0)("BuildingCode")) : LblBuilding.Tag = AgL.XNull(DrTemp(0)("HostelCode"))
                        End If
                    End If

                Case TxtRoom.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblRoom.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtRoom.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            LblRoom.Tag = AgL.XNull(DrTemp(0)("BuildingFloorCode"))
                            mFloorNo = AgL.VNull(DrTemp(0)("FloorNo"))
                            TxtHostel.AgSelectedValue = AgL.XNull(DrTemp(0)("HostelCode"))
                            TxtBuilding.AgSelectedValue = AgL.XNull(DrTemp(0)("BuildingCode")) : LblBuilding.Tag = AgL.XNull(DrTemp(0)("HostelCode"))
                            TxtBuildingFloor.AgSelectedValue = AgL.XNull(DrTemp(0)("BuildingFloorCode")) : LblBuildingFloor.Tag = AgL.XNull(DrTemp(0)("BuildingCode"))
                            TxtRoomType.AgSelectedValue = AgL.XNull(DrTemp(0)("RoomType")) : LblRoomType.Tag = AgL.XNull(DrTemp(0)("RoomType"))
                        End If
                    End If

                Case TxtMemberName.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblMemberName.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtMemberName.AgHelpDataSet.Tables(0).Select("AllotmentDocId = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            LblMemberName.Tag = AgL.XNull(DrTemp(0)("MemberCurrentRoomCode"))
                            mFloorNo = AgL.VNull(DrTemp(0)("FloorNo"))
                            TxtHostel.AgSelectedValue = AgL.XNull(DrTemp(0)("HostelCode"))
                            TxtBuilding.AgSelectedValue = AgL.XNull(DrTemp(0)("BuildingCode")) : LblBuilding.Tag = AgL.XNull(DrTemp(0)("HostelCode"))
                            TxtBuildingFloor.AgSelectedValue = AgL.XNull(DrTemp(0)("BuildingFloorCode")) : LblBuildingFloor.Tag = AgL.XNull(DrTemp(0)("BuildingCode"))
                            TxtRoom.AgSelectedValue = AgL.XNull(DrTemp(0)("MemberCurrentRoomCode")) : LblRoom.Tag = AgL.XNull(DrTemp(0)("BuildingFloorCode"))
                            TxtRoomType.AgSelectedValue = AgL.XNull(DrTemp(0)("RoomTypeCode")) : LblRoomType.Tag = AgL.XNull(DrTemp(0)("RoomTypeCode"))
                        End If
                    End If


            End Select


            If Not AgL.StrCmp(TxtHostel.AgSelectedValue.ToString, LblBuilding.Tag) Then
                TxtBuilding.AgSelectedValue = ""
                LblBuilding.Tag = ""
            End If

            If Not AgL.StrCmp(TxtBuilding.AgSelectedValue.ToString, LblBuildingFloor.Tag) Then
                TxtBuildingFloor.AgSelectedValue = ""
                LblBuildingFloor.Tag = ""
            End If

            If Not AgL.StrCmp(TxtBuildingFloor.AgSelectedValue.ToString, LblRoom.Tag) Then
                TxtRoom.AgSelectedValue = ""
                LblRoom.Tag = ""
            End If

            If Not AgL.StrCmp(TxtRoom.AgSelectedValue.ToString, LblMemberName.Tag) Then
                TxtMemberName.AgSelectedValue = ""
                LblMemberName.Tag = ""
            End If

            If Not AgL.StrCmp(TxtRoomType.AgSelectedValue.ToString, LblRoomType.Tag) Then
                TxtRoom.AgSelectedValue = ""
                LblRoomType.Tag = ""
            End If

            If TxtBuildingFloor.AgSelectedValue = "" Then
                TxtRoomType.AgSelectedValue = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub


    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillRoomStatus.Click
        Try
            Call ProcFillRoomStatus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Try
            'If AgCL.AgCheckMandatory(Me) = False Then Exit Function

            If AgL.RequiredField(TxtSite_Code, "Site/Branch") Then Exit Function
            If AgL.RequiredField(TxtHostel, "Hostel") Then Exit Function
            If AgL.RequiredField(TxtBuilding, "Building") Then Exit Function

            If Not AgL.StrCmp(TxtHostel.AgSelectedValue.ToString, LblBuilding.Tag) Then
                MsgBox("Check Building Detail!...")
                TxtBuilding.Focus()
                LblBuilding.Tag = ""
            End If

            If Not AgL.StrCmp(TxtBuilding.AgSelectedValue.ToString, LblBuildingFloor.Tag) Then
                TxtBuildingFloor.AgSelectedValue = ""
                LblBuildingFloor.Tag = ""
            End If

            If TxtRoom.Text.Trim <> "" Then
                If Not AgL.StrCmp(TxtBuildingFloor.AgSelectedValue.ToString, LblRoom.Tag) Then
                    TxtRoom.AgSelectedValue = ""
                    LblRoom.Tag = ""
                End If
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub ProcFillRoomStatus()
        Dim DtTemp As DataTable, DtFloor As DataTable, DtMemberDetails As DataTable

        Dim I As Integer, J As Integer, K As Integer
        Dim bCondStr$ = "", bCondStr1$ = ""
        Dim bRowIndex As Integer, bColIndex As Integer, bFloorNo As Integer = -9999
        Try
            DGL1.RowCount = 1 : DGL1.Rows.Clear() : DGL1.Columns.Clear()

            If Not Data_Validation() Then Exit Sub

            Call IniGrid()

            bCondStr1 = " WHERE Bf.Building = '" & TxtBuilding.AgSelectedValue & "' "
            If TxtBuildingFloor.Text.Trim <> "" Then bCondStr1 += " And Bf.Code = " & AgL.Chk_Text(TxtBuildingFloor.AgSelectedValue) & ""

            mQry = "SELECT Bf.Code As BuildingFloorCode, Bf.Floor AS FloorCode, Bf.FloorNo, " & _
                    " Bf.Building AS BuildingCode " & _
                    " FROM ViewHt_BuildingFloor Bf " & _
                    " " & bCondStr1 & ""
            DtFloor = AgL.FillData(mQry, AgL.GCn).Tables(0)

            bColIndex = 0
            For J = 0 To DtFloor.Rows.Count - 1
                If DtFloor.Rows.Count > 0 Then
                    bRowIndex = 0

                    bCondStr = " Where R.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ""
                    bCondStr += " And R.HostelCode = " & AgL.Chk_Text(TxtHostel.AgSelectedValue) & ""
                    bCondStr += " And R.BuildingCode = " & AgL.Chk_Text(TxtBuilding.AgSelectedValue) & ""
                    bCondStr += " And R.BuildingFloor = " & AgL.Chk_Text(AgL.XNull(DtFloor.Rows(J)("BuildingFloorCode"))) & ""

                    If TxtRoomType.Text.Trim <> "" Then bCondStr += " And R.RoomType = " & AgL.Chk_Text(TxtRoomType.AgSelectedValue) & ""
                    If TxtRoom.Text.Trim <> "" Then bCondStr += " And R.Code = " & AgL.Chk_Text(TxtRoom.AgSelectedValue) & ""


                    mQry = "SELECT  DISTINCT R.Code as RoomCode, R.Description AS RoomShortDesc, " & _
                            " isnull(V1.TotalAllotment,0) AS MembersInRoom, " & _
                            " R.TotalBed AS BedsInRoom,  " & _
                            " R.Div_Code, R.Site_Code,  Si.Name As Site_Name,  R.BuildingFloorRoomDesc,  " & _
                            " R.RoomTypeDesc, R.Location,  R.BuildingDesc, R.BuildingManualCode, R.BuildingNature, " & _
                            " R.FloorDesc,  R.FloorNo, R.BuildingFloorDesc, R.HostelCode, R.HostelDesc, " & _
                            " R.HostelManualCode , R.IsRoomAllocatable, " & _
                            " Case When IsNull(R.IsRoomAllocatable,0) = 0 Then '" & mRoomStatus_NonAllocable & "' Else " & _
                            " Case When (IsNull(R.TotalBed,0) - IsNull(V1.TotalAllotment,0)) = 0 And IsNull(V1.TotalAllotment,0) > 0 Then '" & mRoomStatus_Occupied & "' Else " & _
                            " Case When (IsNull(R.TotalBed,0) - IsNull(V1.TotalAllotment,0)) > 0 And IsNull(V1.TotalAllotment,0) > 0 Then '" & mRoomStatus_PartiallyOccupied & "' Else " & _
                            " Case When (IsNull(R.TotalBed,0) - IsNull(V1.TotalAllotment,0)) > 0 And IsNull(V1.TotalAllotment,0) = 0 Then '" & mRoomStatus_Vacant & "' End End End End As StatusType " & _
                            " FROM ViewHt_Room R " & _
                            " LEFT JOIN ViewHt_RoomTransfer Vrt ON R.Code = Vrt.Room " & _
                            " LEFT JOIN (SELECT Vrt1.Room , isnull(count(Vrt1.AllotmentDocId),0) AS TotalAllotment  " & _
                            " 			FROM ViewHt_RoomTransfer Vrt1 " & _
                            "           WHERE(Vrt1.TransferDate Is NULL And Vrt1.LeftDate Is NULL) " & _
                            " 			GROUP BY Vrt1.Room) AS V1 " & _
                            " 			ON Vrt.Room=V1.Room " & _
                            " LEFT JOIN SiteMast SI ON Si.Code= R.Site_Code    " & _
                            " " & bCondStr & " Order By R.FloorNo "

                 


                    DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

                    'Code By Akash 

                    mQry = "SELECT Vrt.Room AS RoomCode, Vrt.MemberDispName, Vrt.Mobile, " & _
                           " Vra.MemberType, Vra.Add1, Vra.Add2, Vra.Add3, Vsys.StreamYearSemesterDesc as CurrentSemsterDescription  " & _
                           " FROM ViewHt_RoomTransfer Vrt " & _
                           " LEFT JOIN ViewHt_RoomAllotment Vra ON Vrt.AllotmentDocId=Vra.DocId " & _
                           " LEFT JOIN ViewSch_Admission Va ON Vrt.SubCode = Va.Student " & _
                           " LEFT JOIN ViewSch_AdmissionPromotion Vap ON Va.DocId = Vap.AdmissionDocId AND Vap.PromotionDate IS NULL " & _
                           " LEFT JOIN ViewSch_StreamYearSemester Vsys ON Vap.FromStreamYearSemester = Vsys.Code " & _
                           " Where Vrt.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                           " And Vrt.HostelCode = " & AgL.Chk_Text(TxtHostel.AgSelectedValue) & " " & _
                           " And Vrt.BuildingCode = " & AgL.Chk_Text(TxtBuilding.AgSelectedValue) & " " & _
                           " And Vrt.BuildingFloorCode = " & AgL.Chk_Text(AgL.XNull(DtFloor.Rows(J)("BuildingFloorCode"))) & " " & _
                           " AND Vrt.TransferDate Is NULL And Vrt.LeftDate Is NULL "


                    DtMemberDetails = AgL.FillData(mQry, AgL.GCn).Tables(0)

                    'End Code

                    With DtTemp
                        If .Rows.Count > 0 Then
                            For I = 0 To DtTemp.Rows.Count - 1
                                If bFloorNo <> AgL.VNull(DtFloor.Rows(J)("FloorNo")) Then bFloorNo = AgL.VNull(DtFloor.Rows(J)("FloorNo")) : bColIndex += 1
                                If DGL1.Rows.Count <= I Then DGL1.Rows.Add()
                                bRowIndex = I

                                DGL1.Item(Col_SNo, I).Value = I + 1

                                DGL1.Item(bColIndex, bRowIndex).Value = AgL.XNull(.Rows(I)("RoomShortDesc"))

                                DGL1.CurrentCell = DGL1(bColIndex, bRowIndex)
                                DGL1.CurrentCell.ToolTipText = "Room Capacity : " + AgL.VNull(.Rows(I)("BedsInRoom")).ToString + vbCrLf + "Total Allotment : " + AgL.VNull(.Rows(I)("MembersInRoom")).ToString

                                'Code By Akash 
                                If AgL.StrCmp(AgL.XNull(.Rows(I)("StatusType")), mRoomStatus_NonAllocable) Then
                                    DGL1.CurrentCell.Style.BackColor = TxtNonAllocable.BackColor  'Color.DarkGray
                                    DGL1.CurrentCell.Style.ForeColor = Color.White
                                    DGL1.CurrentCell.ToolTipText = mRoomStatus_NonAllocable
                                    DGL1.CurrentCell.Tag = AgL.XNull(.Rows(I)("RoomCode")) + Val(RoomStauts.NonAllocatable).ToString
                                ElseIf AgL.StrCmp(AgL.XNull(.Rows(I)("StatusType")), mRoomStatus_Occupied) Then
                                    DGL1.CurrentCell.Style.BackColor = TxtOccupied.BackColor  'Color.Silver
                                    DGL1.CurrentCell.Style.ForeColor = Color.White
                                    DGL1.CurrentCell.Tag = AgL.XNull(.Rows(I)("RoomCode")) + Val(RoomStauts.Occupied).ToString
                                ElseIf AgL.StrCmp(AgL.XNull(.Rows(I)("StatusType")), mRoomStatus_PartiallyOccupied) Then
                                    DGL1.CurrentCell.Style.BackColor = TxtPartiallyOccupied.BackColor 'Color.LightGray
                                    DGL1.CurrentCell.Tag = AgL.XNull(.Rows(I)("RoomCode")) + Val(RoomStauts.PartiallyOccupied).ToString
                                ElseIf AgL.StrCmp(AgL.XNull(.Rows(I)("StatusType")), mRoomStatus_Vacant) Then
                                    DGL1.CurrentCell.Style.BackColor = TxtVacant.BackColor 'Color.Snow
                                    DGL1.CurrentCell.Tag = AgL.XNull(.Rows(I)("RoomCode")) + Val(RoomStauts.Vacant).ToString
                                End If
                                'End Code

                                'Code By Akash 
                                If DtMemberDetails.Rows.Count > 0 Then
                                    For K = 0 To DtMemberDetails.Rows.Count - 1
                                        If Not AgL.StrCmp(AgL.XNull(.Rows(I)("StatusType")), mRoomStatus_NonAllocable) And AgL.XNull(DtTemp.Rows(I)("RoomCode")) = AgL.XNull(DtMemberDetails.Rows(K)("RoomCode")) Then
                                            DGL1.CurrentCell.ToolTipText += vbCrLf + vbCrLf + "Member Name : " + AgL.XNull(DtMemberDetails.Rows(K)("MemberDispName")).ToString + vbCrLf + "Member Type : " + AgL.XNull(DtMemberDetails.Rows(K)("MemberType")).ToString + vbCrLf + "Semester : " + AgL.XNull(DtMemberDetails.Rows(K)("CurrentSemsterDescription")).ToString + vbCrLf + "Contact No : " + AgL.XNull(DtMemberDetails.Rows(K)("Mobile")).ToString + vbCrLf + "Address : " + AgL.XNull(DtMemberDetails.Rows(K)("Add1")).ToString + " " + AgL.XNull(DtMemberDetails.Rows(K)("Add2")).ToString + " " + AgL.XNull(DtMemberDetails.Rows(K)("Add3")).ToString
                                        End If
                                    Next
                                End If
                                'End Code
                            Next I

                        Else
                            MsgBox("No Rooms Exists To Display...1", MsgBoxStyle.Information)
                        End If
                    End With

                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            DtFloor = Nothing

        End Try
    End Sub

   
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class