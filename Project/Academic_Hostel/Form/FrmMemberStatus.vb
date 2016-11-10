Imports System.Data.SqlClient
Public Class FrmMemberStatus
    Private DTMaster As New DataTable()
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1AllotmentDocId As Byte = 1
    Private Const Col1Category As Byte = 2
    Private Const Col1Room As Byte = 3
    Private Const Col1Semester As Byte = 4

    Private Const Col1OpeningBalance As Byte = 5
    Private Const Col1ChargeDue As Byte = 6
    Private Const Col1ChargeReceive As Byte = 7
    Private Const Col1ChargeRefund As Byte = 8
    Private Const Col1UnAdjustedAdvance As Byte = 9
    Private Const Col1NetBalance As Byte = 10
    Private Const Col1ActualNetBalance As Byte = 11

    Dim mRoom$ = ""
    Dim mFlag As Integer

    Public Property Room() As String
        Get
            Room = mRoom
        End Get
        Set(ByVal value As String)
            mRoom = value
        End Set
    End Property

    Public Sub New()
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
        ''==============================================================================
        ''================< Member Data Grid >====================================
        ''==============================================================================

        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1AllotmentDocId", 200, 50, "Member Name", True, True, False, True)
            .AddAgTextColumn(DGL1, "DGL1Category", 150, 50, "Category", True, True, False, True)
            .AddAgTextColumn(DGL1, "DGL1Room", 150, 50, "Room", True, True, False, True)
            .AddAgTextColumn(DGL1, "DGL1Semester", 200, 50, "Semester", True, True, False, True)

            .AddAgNumberColumn(DGL1, "DGL1OpeningBalance", 70, 8, 2, False, "Opening Balance", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1ChargeDue", 70, 8, 2, False, "Charge Due", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1ChargeReceive", 70, 8, 2, False, "Charge Receive", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1ChargeRefund", 70, 8, 2, False, "Charge Refund", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1UnAdjustedAdvance", 80, 8, 2, False, "UnAdjusted Advance", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1NetBalance", 70, 8, 2, False, "Net Balance", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1ActualNetBalance", 80, 8, 2, False, "Actual NetBalance", True, True, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False
        DGL1.RowsDefaultCellStyle.BackColor = Color.White
        DGL1.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue
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

    Private Sub OpenLinkForm(ByVal Sender As Object)
        Dim FrmObj As Form
        Dim StrUserPermission As String
        Dim DTUP As New DataTable
        Dim CFOpen As New ClsFunction
        Dim MdiObj As New MDIMain
        Try
            Me.Cursor = Cursors.WaitCursor
            'If Topctrl1.Mode = "Browse" Then Exit Sub
            Select Case Sender.name
                'Case <Sender>.Name
                'PObj.FOpen_LinkForm_Common_Master("MnuCustomerMaster", "Customer Master", Me.MdiParent)
                Case BtnChargeDue.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Hostel(MdiObj.MnuRoomChargeDueEntry.Name, MdiObj.MnuRoomChargeDueEntry.Text, Me.MdiParent)
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmRoomChargeDue).AllotmentDocId = DGL1.AgSelectedValue(Col1AllotmentDocId, DGL1.CurrentRow.Index)
                    End If

                Case BtnChargeReceive.Name

                    FrmObj = PObj.FOpen_LinkForm_Academic_Hostel(MdiObj.MnuRoomChargeReceive.Name, MdiObj.MnuRoomChargeReceive.Text, Me.MdiParent)
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmRoomChargeReceive).AllotmentDocId = DGL1.AgSelectedValue(Col1AllotmentDocId, DGL1.CurrentRow.Index)
                    End If

                Case BtnRoomLeft.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Hostel(MdiObj.MnuRoomLeft.Name, MdiObj.MnuRoomLeft.Text, Me.MdiParent)
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmRoomLeft).AllotmentDocId = DGL1.AgSelectedValue(Col1AllotmentDocId, DGL1.CurrentRow.Index)
                    End If

                Case BtnRoomTransfer.Name
                    FrmObj = PObj.FOpen_LinkForm_Academic_Hostel(MdiObj.MnuRoomTransfer.Name, MdiObj.MnuRoomTransfer.Text, Me.MdiParent)
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmRoomTransfer).AllotmentDocId = DGL1.AgSelectedValue(Col1AllotmentDocId, DGL1.CurrentRow.Index)
                    End If

                Case BtnViewLastRecipt.Name
                    If FunGetLastReceive(DGL1.AgSelectedValue(Col1AllotmentDocId, DGL1.CurrentRow.Index)) <> "" Then
                        StrUserPermission = AgIniVar.FunGetUserPermission(Academic_Objects.ClsConstant.Module_Academic_Hostel, MdiObj.MnuRoomChargeReceive.Name, MdiObj.MnuRoomChargeReceive.Text, DTUP)
                        StrUserPermission = StrUserPermission.Replace("A", "*").Replace("E", "*").Replace("D", "*")
                        FrmObj = New FrmRoomChargeReceive(StrUserPermission, DTUP)
                        If FrmObj IsNot Nothing Then
                            FrmObj.MdiParent = Me.MdiParent
                            FrmObj.Show()
                            CType(FrmObj, FrmRoomChargeReceive).FindMove(FunGetLastReceive(DGL1.AgSelectedValue(Col1AllotmentDocId, DGL1.CurrentRow.Index)))
                            FrmObj = Nothing
                        End If
                    Else
                        MsgBox("No Recipt Record Exists For " & DGL1.Item(Col1AllotmentDocId, DGL1.CurrentRow.Index).Value & " ", MsgBoxStyle.Information)
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            MdiObj = Nothing
        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 324, 740, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Ini_List()
            DispText()
            Call ProcFillMemberStatus(Room)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub Ini_List()
        mQry = "SELECT Vrt.AllotmentDocId, Vrt.MemberName AS MemberName, Vrt.FatherName, Vrt.Room AS MemberCurrentRoomCode, " & _
                " Vrt.BuildingFloorCode, Vrt.BuildingCode, Vrt.HostelCode, Vrt.FloorNo " & _
                " FROM ViewHt_RoomTransfer Vrt " & _
                " Where " & AgL.PubSiteCondition("Vrt.Site_Code", AgL.PubSiteCode) & " " & _
                " AND Vrt.TransferDate Is NULL And Vrt.LeftDate Is NULL "
        DGL1.AgHelpDataSet(Col1AllotmentDocId, 1) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub BlankText()
        Topctrl1.BlankTextBoxes(Me)
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSite_Code.Enter
        Try
            Select Case sender.name
                '<Executable Code>
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSite_Code.Validating
        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                '<Executable Code>
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        'Try
        '    'If AgCL.AgCheckMandatory(Me) = False Then Exit Function

        '    If AgL.RequiredField(TxtSite_Code, "Site/Branch") Then Exit Function
        '    If AgL.RequiredField(TxtHostel, "Hostel") Then Exit Function
        '    If AgL.RequiredField(TxtBuilding, "Building") Then Exit Function

        '    If Not AgL.StrCmp(TxtHostel.AgSelectedValue.ToString, LblBuilding.Tag) Then
        '        MsgBox("Check Building Detail!...")
        '        TxtBuilding.Focus()
        '        LblBuilding.Tag = ""
        '    End If

        '    If Not AgL.StrCmp(TxtBuilding.AgSelectedValue.ToString, LblBuildingFloor.Tag) Then
        '        TxtBuildingFloor.AgSelectedValue = ""
        '        LblBuildingFloor.Tag = ""
        '    End If

        '    If TxtRoom.Text.Trim <> "" Then
        '        If Not AgL.StrCmp(TxtBuildingFloor.AgSelectedValue.ToString, LblRoom.Tag) Then
        '            TxtRoom.AgSelectedValue = ""
        '            LblRoom.Tag = ""
        '        End If
        '    End If

        '    Data_Validation = True
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Data_Validation = False
        'End Try
    End Function

    Private Sub ProcFillMemberStatus(ByVal RoomNo As String)
        Dim DsTemp As DataSet = Nothing
        Dim bCondStr As String = ""
        Dim I As Integer
        Try
            bCondStr = "Where 1=1 "
            bCondStr = bCondStr & "AND RT.Site_Code=" & AgL.Chk_Text(AgL.PubSiteCode) & "  "
            'bCondStr = bCondStr & "AND V1.CurrentRoomCode = " & AgL.Chk_Text(RoomNo) & " "

            mQry = " Select V1.*, IsNull(V1.NetBalance,0) -IsNull(V1.NetAdvanceTillDate,0) AS ActualNetBalance, " & _
                    " Sem.StreamYearSemesterDesc AS CurrentStreamYearSemesterDesc " & _
                    " From (" & FunGetMemberOutstandingQry(AgL.PubLoginDate, AgL.PubLoginDate, bCondStr) & ") as  V1 " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON V1.CurrentStramYearSemesterCode = Sem.Code " & _
                    " Where V1.CurrentRoomCode = " & AgL.Chk_Text(RoomNo) & " "


            DsTemp = AgL.FillData(mQry, AgL.GCn)


            With DsTemp.Tables(0)
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1AllotmentDocId, I) = AgL.XNull(.Rows(I)("AllotmentDocId"))
                        DGL1.Item(Col1Category, I).Value = AgL.XNull(.Rows(I)("CategoryDesc"))
                        DGL1.Item(Col1Room, I).Value = AgL.XNull(.Rows(I)("CurrentBuildingFloorRoomDesc"))
                        DGL1.Item(Col1Semester, I).Value = AgL.XNull(.Rows(I)("CurrentStreamYearSemesterDesc"))

                        DGL1.Item(Col1OpeningBalance, I).Value = Format(AgL.VNull(.Rows(I)("OpeningBalance")), "0.00")
                        DGL1.Item(Col1ChargeDue, I).Value = Format(AgL.VNull(.Rows(I)("CurrentDueAmount")), "0.00")
                        DGL1.Item(Col1ChargeReceive, I).Value = Format(AgL.VNull(.Rows(I)("CurrentReceiveAmount")), "0.00")
                        DGL1.Item(Col1ChargeRefund, I).Value = Format(AgL.VNull(.Rows(I)("CurrentRefundAmount")), "0.00")
                        DGL1.Item(Col1UnAdjustedAdvance, I).Value = Format(AgL.VNull(.Rows(I)("NetAdvanceTillDate")), "0.00")
                        DGL1.Item(Col1NetBalance, I).Value = Format(AgL.VNull(.Rows(I)("NetBalance")), "0.00")
                        DGL1.Item(Col1ActualNetBalance, I).Value = Format(AgL.VNull(.Rows(I)("ActualNetBalance")), "0.00")
                    Next I
                End If
            End With






            'mQry = "SELECT Vrt.AllotmentDocId, Sg.CategoryDesc, Vrt.BuildingFloorRoomDesc, Vsys.StreamYearSemesterDesc " & _
            '        " FROM ViewHt_RoomTransfer Vrt  " & _
            '        " LEFT JOIN ViewHt_SubGroup Sg ON vrt.MemberCode = Sg.SubCode " & _
            '        " LEFT JOIN Sch_Admission A ON Vrt.MemberCode = A.Student " & _
            '        " LEFT JOIN ViewSch_AdmissionPromotion Vap ON A.DocId=Vap.AdmissionDocId AND Vap.PromotionDate IS NULL  " & _
            '        " LEFT JOIN ViewSch_StreamYearSemester Vsys ON Vap.FromStreamYearSemester = Vsys.Code " & _
            '        " WHERE Vrt.TransferDate Is NULL And Vrt.LeftDate Is NULL AND Vrt.Room ='" & RoomNo & "'  "

            'DsTemp = AgL.FillData(mQry, AgL.GCn)

            'With DsTemp.Tables(0)
            '    DGL1.RowCount = 1 : DGL1.Rows.Clear()
            '    If .Rows.Count > 0 Then
            '        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
            '            DGL1.Rows.Add()
            '            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
            '            DGL1.AgSelectedValue(Col1AllotmentDocId, I) = AgL.XNull(.Rows(I)("AllotmentDocId"))
            '            DGL1.Item(Col1Category, I).Value = AgL.XNull(.Rows(I)("CategoryDesc"))
            '            DGL1.Item(Col1Room, I).Value = AgL.XNull(.Rows(I)("BuildingFloorRoomDesc"))
            '            DGL1.Item(Col1Semester, I).Value = AgL.XNull(.Rows(I)("StreamYearSemesterDesc"))
            '        Next I
            '    End If
            'End With





            'With DsTemp.Tables(0)
            '    DGL1.RowCount = 1 : DGL1.Rows.Clear()
            '    If .Rows.Count > 0 Then
            '        For I = 0 To .Rows.Count - 1
            '            DGL1.Rows.Add()
            '            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
            '            DGL1.AgSelectedValue(Col1AllotmentDocId, I) = AgL.XNull(.Rows(I)("AllotmentDocId"))
            '            DGL1.Item(Col1Category, I).Value = AgL.XNull(.Rows(I)("CategoryDesc"))
            '            DGL1.Item(Col1Room, I).Value = AgL.XNull(.Rows(I)("BuildingFloorRoomDesc"))
            '            DGL1.Item(Col1Semester, I).Value = AgL.XNull(.Rows(I)("StreamYearSemesterDesc"))
            '        Next I
            '    End If
            'End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DsTemp = Nothing
        End Try
    End Sub


    Private Sub BtnChargeDuw_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnChargeDue.Click, BtnChargeReceive.Click, BtnRoomLeft.Click, BtnRoomTransfer.Click, BtnViewLastRecipt.Click
        Call OpenLinkForm(Me.ActiveControl)
    End Sub

    Public Function FunGetLastReceive(ByVal bAllotmentDocId As String) As String
        Dim bLastReceiveDocId As String = ""
        Try
            mQry = "SELECT Cr.DocId " & _
                    " FROM Ht_ChargeReceive Cr " & _
                    " WHERE Cr.V_Date=(SELECT max(C.V_Date) AS LastReceiveDate  " & _
                    " 				    FROM Ht_ChargeReceive C  " & _
                    " 				    WHERE C.AllotmentDocId='" & bAllotmentDocId & "') " & _
                    " AND Cr.RowId =(SELECT max(C1.RowId) " & _
                    "                FROM Ht_ChargeReceive C1 " & _
                    "                WHERE C1.AllotmentDocId='" & bAllotmentDocId & "') " & _
                    " AND Cr.AllotmentDocId='" & bAllotmentDocId & "' "
            bLastReceiveDocId = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar()
        Catch ex As Exception
            MsgBox(ex.Message)
            bLastReceiveDocId = ""
        Finally
            FunGetLastReceive = bLastReceiveDocId
        End Try
    End Function
End Class