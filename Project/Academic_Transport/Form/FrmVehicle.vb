Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmVehicle
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""


    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1ExpenseType As String = "Expense Type"
    Private Const Col1Expense As String = "Expense Head"
    Private Const Col1DueOnDate As String = "Due Date"
    Private Const Col1DueOnMeterReading As String = "Due On Reading"
    Private Const Col1Remark As String = "Remark"

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
        Try
            With AgCL
                .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
                .AddAgTextColumn(DGL1, Col1ExpenseType, 80, 0, Col1ExpenseType, True, False, False)
                .AddAgTextColumn(DGL1, Col1Expense, 130, 0, Col1Expense, True, False, False)
                .AddAgDateColumn(DGL1, Col1DueOnDate, 80, Col1DueOnDate, True, False, False)
                .AddAgNumberColumn(DGL1, Col1DueOnMeterReading, 60, 8, 0, False, Col1DueOnMeterReading, True, False, True)
                .AddAgTextColumn(DGL1, Col1Remark, 105, 255, Col1Remark, True, False, False)
            End With
            AgL.AddAgDataGrid(DGL1, Pnl1)
            DGL1.EnableHeadersVisualStyles = False
            DGL1.Anchor = AnchorStyles.None
            DGL1.ColumnHeadersHeight = 50
            DGL1.AgSkipReadOnlyColumns = True
            Topctrl1.ChangeAgGridState(DGL1, Not AgL.StrCmp(Topctrl1.Mode, "Browse"))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
            AgL.WinSetting(Me, 500, 990, 0, 0)
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
        mQry = "Select Tp_Vehicle.Code As SearchCode " & _
                " From Tp_Vehicle "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                "  Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Code  As Code, RegistrationNo As Name " & _
                " From Tp_Vehicle " & _
                " Order By RegistrationNo"
            TxtRegistrationNo.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Description As Code, Description As Name " & _
                    " From Tp_Vehicle " & _
                    " Where IsNull(Description,'') <> '' " & _
                    " Order By Description"
            TxtDescription.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT V.VehicleModel AS Code , V.VehicleModel AS Description " & _
                    " FROM Tp_Vehicle V " & _
                    " Where IsNull(V.VehicleModel,'') <> '' " & _
                    " Order By VehicleModel"
            TxtVehicleModel.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select CityCode As Code, CityName As Name From City " & _
                "  Order By CityName"
            TxtOwnerCity.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT V.VehicleType AS Code , V.VehicleType AS Name " & _
                    " FROM Tp_Vehicle V " & _
                    " Where IsNull(V.VehicleType,'') <> '' " & _
                    " Order By VehicleType"
            TxtVehicleType.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            AgCL.IniAgHelpList(TxtOwnRented, "" & ClsMain.OwnRental.Own & "," & ClsMain.OwnRental.Rental & "")

            mQry = "SELECT E.Code, E.Description AS Expense, E.ExpenseType AS [Expense Type], " & _
                    " E.OnEveryKms, E.OnEveryDays " & _
                    " FROM Tp_Expense E " & _
                    " ORDER BY E.Description"
            DGL1.AgHelpDataSet(Col1Expense, 3) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Et.Code, Et.Code AS Name FROM Tp_ExpenseType Et ORDER BY Et.Code"
            DGL1.AgHelpDataSet(Col1ExpenseType) = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtRegistrationNo.Focus()
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

                    mQry = "Delete From Tp_Vehicle1 Where Code = " & AgL.Chk_Text(mSearchCode) & " "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    AgL.Dman_ExecuteNonQry("Delete From Tp_Vehicle Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , , , , , AgL.PubSiteCode, AgL.PubDivCode)

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
        TxtRegistrationNo.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try

            AgL.PubFindQry = "SELECT V.Code AS SearchCode, S.Name AS [" & LblSite_Code.Text & "], " & _
                            " V.RegistrationNo as [" & LblRegistrationNo.Text & "], " & _
                            " V.Description As [" & LblDescription.Text & "] , " & _
                            " V.VehicleModel as [" & LblVehicleModel.Text & "], V.ChassisNo as [Chassis No],  " & _
                            " V.EngineNo as [Engine No], V.SeatingCapacity as [Seating Capacity], " & _
                            " V.VehicleType as [" & LblVehicleType.Text & "] , " & _
                            " V.OwnerName  as [" & LblOwnerName.Text & "], " & _
                            " IsNull(V.OwnerAdd1,'') + Space(1) + IsNull(V.OwnerAdd2,'') + Space(1) +IsNull(V.OwnerAdd3,'') as [" & LblOwnerAdd1.Text & "], " & _
                            " City.CityName As [" & LblOwnerCity.Text & "] " & _
                            " FROM Tp_Vehicle V " & _
                            " LEFT JOIN SiteMast S ON V.Site_Code = S.Code " & _
                            " LEFT JOIN City ON City.CityCode = V.OwnerCity "


            AgL.PubFindQryOrdBy = "[" & LblSite_Code.Text & "], [" & LblRegistrationNo.Text & "]"


            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> " Then" Then
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
            AgL.PubReportTitle = "Vehicle Master"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = "Select V.RegistrationNo As [Registration No.],   " & _
                        " V.Description As [" & LblDescription.Text & "],  " & _
                        " V.VehicleType As [Vehicle Type],  " & _
                        " V.VehicleModel As [Vehicle Model],  " & _
                        " V.ChassisNo As [Chassis No.],  V.EngineNo As [Engine No.]  " & _
                        " From  Tp_Vehicle V " & _
                        " Left Join  SiteMast SiteMast1 On SiteMast1.Code = V.Site_Code "

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Vehicle Master"
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
        Dim bIntI%, bIntSr%
        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            'TxtValueForInsurance

            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Tp_Vehicle(Code, RegistrationNo, Description, Div_Code, " & _
                        " Site_Code, VehicleType, VehicleModel, " & _
                        " ChassisNo, EngineNo, SeatingCapacity, OwnRented, OwnerName, OwnerAdd1, " & _
                        " OwnerAdd2, OwnerAdd3, OwnerCity, Mileage, MeterReading, " & _
                        " PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ('" & mSearchCode & "'," & AgL.Chk_Text(TxtRegistrationNo.Text) & ", " & _
                        "  " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                        " '" & AgL.PubDivCode & "', " & _
                        " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtVehicleType.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtVehicleModel.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtChassisNo.Text) & ", " & AgL.Chk_Text(TxtEngineNo.Text) & "," & _
                        " " & Val(TxtSeatingCapacity.Text) & ", " & AgL.Chk_Text(TxtOwnRented.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtOwnerName.Text) & ", " & AgL.Chk_Text(TxtOwnerAdd1.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtOwnerAdd2.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtOwnerAdd3.Text) & ", " & AgL.Chk_Text(TxtOwnerCity.AgSelectedValue) & "," & _
                        " " & Val(TxtMileage.Text) & ", " & Val(TxtMeterReading.Text) & "," & _
                        " '" & AgL.PubUserName & "','" & Format(AgL.PubLoginDate, "Short Date") & "', 'A')"



                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Tp_Vehicle Set " & _
                        " RegistrationNo = " & AgL.Chk_Text(TxtRegistrationNo.Text) & ", " & _
                        " Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                        " VehicleType = " & AgL.Chk_Text(TxtVehicleType.Text) & ", " & _
                        " VehicleModel = " & AgL.Chk_Text(TxtVehicleModel.Text) & ", " & _
                        " Mileage =" & Val(TxtMileage.Text) & ", " & _
                        " MeterReading =" & Val(TxtMeterReading.Text) & ", " & _
                        " ChassisNo = " & AgL.Chk_Text(TxtChassisNo.Text) & ", " & _
                        " EngineNo = " & AgL.Chk_Text(TxtEngineNo.Text) & ", " & _
                        " SeatingCapacity =" & Val(TxtSeatingCapacity.Text) & ", " & _
                        " OwnRented = " & AgL.Chk_Text(TxtOwnRented.Text) & ", " & _
                        " OwnerName = " & AgL.Chk_Text(TxtOwnerName.Text) & ", " & _
                        " OwnerAdd1 = " & AgL.Chk_Text(TxtOwnerAdd1.Text) & "," & _
                        " OwnerAdd2 = " & AgL.Chk_Text(TxtOwnerAdd2.Text) & ", " & _
                        " OwnerAdd3 = " & AgL.Chk_Text(TxtOwnerAdd3.Text) & ", " & _
                        " OwnerCity = " & AgL.Chk_Text(TxtOwnerCity.AgSelectedValue) & ", " & _
                        " Edit_Date='" & Format(AgL.PubLoginDate, "Short Date") & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "', U_AE = 'E'" & _
                        " Where Code='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                mQry = "Delete From Tp_Vehicle1 Where Code = " & AgL.Chk_Text(mSearchCode) & " "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bIntSr = 0

                For bIntI = 0 To .Rows.Count - 1
                    If .Item(Col1ExpenseType, bIntI).Value.ToString.Trim <> "" Then
                        bIntSr += 1

                        mQry = "INSERT INTO dbo.Tp_Vehicle1 (Code, Sr, Expense, ExpenseType, DueOnDate, DueOnMeterReading, Remark) " & _
                                " VALUES (" & _
                                " " & AgL.Chk_Text(mSearchCode) & ", " & _
                                " " & bIntSr & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1Expense, bIntI)) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1ExpenseType, bIntI).Value) & ", " & _
                                " " & AgL.ConvertDate(.Item(Col1DueOnDate, bIntI).Value.ToString) & ", " & _
                                " " & Val(.Item(Col1DueOnMeterReading, bIntI).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1ExpenseType, bIntI).Value) & " " & _
                                " ) "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With


            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , , , , , AgL.PubSiteCode, AgL.PubDivCode)
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
        Dim bDtTemp As DataTable = Nothing
        Dim MastPos As Long
        Dim bIntI%
        Try
            FClear()
            BlankText()

            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select H.* " & _
                    " From Tp_Vehicle H " & _
                    " Where H.Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtRegistrationNo.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                        TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                        TxtVehicleType.Text = AgL.XNull(.Rows(0)("VehicleType"))
                        TxtVehicleModel.Text = AgL.XNull(.Rows(0)("VehicleModel"))
                        TxtMileage.Text = Format(AgL.VNull(.Rows(0)("Mileage")), "0.".PadRight(0 + 2, "0"))
                        TxtMeterReading.Text = Format(AgL.VNull(.Rows(0)("MeterReading")), "0.00")
                        TxtChassisNo.Text = AgL.XNull(.Rows(0)("ChassisNo"))
                        TxtEngineNo.Text = AgL.XNull(.Rows(0)("EngineNo"))
                        TxtSeatingCapacity.Text = Format(AgL.VNull(.Rows(0)("SeatingCapacity")), "0.".PadRight(0 + 2, "0"))
                        TxtOwnRented.Text = AgL.XNull(.Rows(0)("OwnRented"))
                        TxtOwnerName.Text = AgL.XNull(.Rows(0)("OwnerName"))
                        TxtOwnerAdd1.Text = AgL.XNull(.Rows(0)("OwnerAdd1"))
                        TxtOwnerAdd2.Text = AgL.XNull(.Rows(0)("OwnerAdd2"))
                        TxtOwnerAdd3.Text = AgL.XNull(.Rows(0)("OwnerAdd3"))
                        TxtOwnerCity.AgSelectedValue = AgL.XNull(.Rows(0)("OwnerCity"))
                    End If
                End With

                mQry = "SELECT L.* FROM Tp_Vehicle1 L " & _
                        " WHERE L.Code = '" & mSearchCode & "' " & _
                        " ORDER BY L.DueOnDate, L.Sr"
                bDtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                With bDtTemp
                    If .Rows.Count > 0 Then
                        For bIntI = 0 To .Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1

                            DGL1.AgSelectedValue(Col1Expense, bIntI) = AgL.XNull(.Rows(bIntI)("Expense"))
                            DGL1.Item(Col1ExpenseType, bIntI).Value = AgL.XNull(.Rows(bIntI)("ExpenseType"))
                            DGL1.Item(Col1DueOnDate, bIntI).Value = Format(AgL.XNull(.Rows(bIntI)("DueOnDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL1.Item(Col1DueOnMeterReading, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("DueOnMeterReading")), "0")
                            DGL1.Item(Col1Remark, bIntI).Value = AgL.XNull(.Rows(bIntI)("Remark"))
                        Next
                    End If
                End With

            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DsTemp IsNot Nothing Then DsTemp.Dispose()
            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes()
        mSearchCode = ""
        TxtOwnRented.Text = ClsMain.OwnRental.Own

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
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

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
       Handles _
 _
           TxtOwnRented.Validating

        Try
            Select Case sender.NAME
                '<Executable Code>
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        If Topctrl1.Mode = "Browse" Then Exit Sub
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI%

        Call Calculation()

        If AgL.RequiredField(TxtSite_Code) Then Exit Function
        If AgL.RequiredField(TxtRegistrationNo, LblRegistrationNo.Text) Then Exit Function
        If AgL.RequiredField(TxtDescription, LblDescription.Text) Then Exit Function
        If AgL.RequiredField(TxtOwnRented, LblOwnRented.Text) Then Exit Function

        AgCL.AgBlankNothingCells(DGL1)

        With DGL1
            For bIntI = 0 To .Rows.Count - 1
                If .Item(Col1ExpenseType, bIntI).Value.ToString.Trim <> "" Then
                    If .Item(Col1Expense, bIntI).Value.ToString.Trim = "" Then
                        MsgBox("Expense Head Is Blank At Row No. : " & .Item(ColSNo, bIntI).Value & "!...")
                        DGL1.CurrentCell = DGL1(Col1Expense, bIntI)
                        DGL1.Focus() : Exit Function
                    End If
                End If
            Next
        End With

        If Topctrl1.Mode = "Add" Then

            AgL.ECmd = AgL.Dman_Execute("Select count(*) From Tp_Vehicle Where Description='" & TxtDescription.Text & "' ", AgL.GCn)
            If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Function

            AgL.ECmd = AgL.Dman_Execute("Select count(*) From Tp_Vehicle Where RegistrationNo='" & TxtRegistrationNo.Text & "' ", AgL.GCn)
            If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Registration No Already Exist!") : TxtRegistrationNo.Focus() : Exit Function

            mSearchCode = AgL.GetMaxId("Tp_Vehicle", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True)
        Else
            AgL.ECmd = AgL.Dman_Execute("Select count(*) From Tp_Vehicle Where Description='" & TxtDescription.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
            If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Function

            AgL.ECmd = AgL.Dman_Execute("Select count(*) From Tp_Vehicle Where RegistrationNo='" & TxtRegistrationNo.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
            If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Registration No Already Exist!") : TxtRegistrationNo.Focus() : Exit Function
        End If

        ''====RETRUN VALUE==============================================================================================================================================================
        Data_Validation = True
    End Function

    Private Sub TxtRegistrationNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtRegistrationNo.Validating

        Select Case sender.name
            Case TxtRegistrationNo.Name

        End Select
    End Sub

    Public Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Expense
                    DGL1.AgRowFilter(DGL1.Columns(Col1Expense).Index) = " [Expense Type] = " & AgL.Chk_Text(DGL1.Item(Col1ExpenseType, mRowIndex).Value) & " "
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    'Case <ColumnIndex>
                    '<Executable Code>
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, 0)

        Call Calculation()
    End Sub
End Class

