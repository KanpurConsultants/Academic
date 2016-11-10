Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRoomType
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Facilities As Byte = 1

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2Charge As Byte = 1
    Private Const Col2Amount As Byte = 2
    Private Const Col2ChargeType As Byte = 3
    Private Const Col2DueMonth As Byte = 4
    Private Const Col2IsOnceInLife As Byte = 5
    Private Const Col2IsFirstTimeRequired As Byte = 6



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
        ''================< Facilities Data Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1Facilities", 430, 100, "Facilities", True, False, False, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)



        ''==============================================================================
        ''================< Charges Data Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "DGL2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "DGL2Charge", 200, 20, "Charge", True, False, False, True)
            .AddAgNumberColumn(DGL2, "Dgl2Amount", 80, 5, 0, False, "Amount", True, False, True)
            .AddAgTextColumn(DGL2, "DGL2ChargeType", 100, 20, "Charge Type", True, False, False, True)
            .AddAgListColumn(DGL2, "JAN,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC,NA", "DGL2DueMonth", 70, "JAN,FEB,MAR,APR,MAY,JUN,JUL,AUG,SEP,OCT,NOV,DEC,NA", "Due Month", True, False)
            .AddAgCheckBoxColumn(DGL2, "Dgl2IsOnceInLife", 70, "Once In Life", True, False)
            .AddAgCheckBoxColumn(DGL2, "Dgl2IsFirstTimeRequired", 90, "First TimeRequired", True, False)

        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 40

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

    Private Sub FrmRoomType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            AgL.WinSetting(Me, 450, 880, 0, 0)
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

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = " Select HRT.Code As SearchCode " & _
                " From Ht_RoomType HRT " & _
                " Where " & AgL.PubSiteCondition("HRT.Site_Code", AgL.PubSiteCode) & ""
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()

        mQry = " Select HRT.Code  As Code, HRT.ManualCode As Name From Ht_RoomType HRT " & _
                " Where " & AgL.PubSiteCondition("HRT.Site_Code", AgL.PubSiteCode) & " Order By ManualCode"
        TxtManualCode.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select HRT.Code  As Code, HRT.Description As Name From Ht_RoomType HRT " & _
                " Where " & AgL.PubSiteCondition("HRT.Site_Code", AgL.PubSiteCode) & "  Order By Description"
        TxtDescription.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT HC.SubCode AS Code,Sg.Name  as Description , Sg.ManualCode " & _
                " FROM Ht_Charge HC " & _
                " LEFT JOIN SubGroup Sg ON HC.SubCode=Sg.SubCode "

        DGL2.AgHelpDataSet(Col2Charge, 1, Tc1.Top + Tp1.Top) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT FT.Code AS Code,FT.Code AS Description " & _
                " FROM Sch_FeeType FT "

        DGL2.AgHelpDataSet(Col2ChargeType, 0, Tc1.Top + Tp1.Top) = AgL.FillData(mQry, AgL.GCn)


    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtManualCode.Focus()
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

                    AgL.Dman_ExecuteNonQry(" Delete From Ht_RoomTypeCharge Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry(" Delete From Ht_RoomType1 Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry(" Delete From Ht_RoomType Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)


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
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = " Select HRT.Code As SearchCode, HRT.ManualCode As [Manual Code],  HRT.Description As [Description]" & _
                                " From  Ht_RoomType HRT " & _
                                " Where " & AgL.PubSiteCondition("HRT.Site_Code", AgL.PubSiteCode) & ""

            AgL.PubFindQryOrdBy = "[Manual Code]"


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
        'Dim ds As New DataSet
        'Dim strQry As String = ""
        'Try
        '    Me.Cursor = Cursors.WaitCursor
        '    AgL.PubReportTitle = "Customer Category 1 Master"
        '    If Not DTMaster.Rows.Count > 0 Then
        '        MsgBox("No Records Found to Print!!!", vbInformation, "Information")
        '        Me.Cursor = Cursors.Default
        '        Exit Sub
        '    End If


        '    'strQry = " Select HRT.ManualCode As [Manual Code],  HRT.Description As [Description], HRT.Charges " & _
        '    '            " From Ht_RoomType HRT " & _
        '    '            " Where " & AgL.PubSiteCondition("HRT.Site_Code", AgL.PubSiteCode) & ""

        '    strQry = "SELECT Rt.Code, Rt.Description, Rt.ManualCode, Rt.Div_Code, Rt.Site_Code, " & _
        '                " Rt.PreparedBy, Rt.U_EntDt, Rt.U_AE, Rt.Edit_Date, Rt.ModifiedBy, " & _
        '                " Rt1.Sr, Rt1.Facilities, Rtc.Sr, Rtc.Charge, Vc.ChargeName, Rtc.Amount, Rtc.ChargeType, " & _
        '                " Rtc.DueMonth,  " & _
        '                " CASE isnull(Rtc.IsOnceInLife,0) WHEN 1 THEN 'Y' ELSE 'N' END , " & _
        '                " CASE isnull(Rtc.IsFirstTimeRequired,0) WHEN 1 THEN 'Y' ELSE 'N' END " & _
        '                " FROM Ht_RoomType Rt " & _
        '                " LEFT JOIN Ht_RoomType1 Rt1 ON Rt.Code=Rt1.Code " & _
        '                " LEFT JOIN Ht_RoomTypeCharge Rtc ON Rt.Code=Rtc.Code " & _
        '                " LEFT JOIN ViewHt_Charge Vc ON Rtc.Charge=Vc.SubCode " & _
        '                " Where " & AgL.PubSiteCondition("Rt.Site_Code", AgL.PubSiteCode) & ""





        '    AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
        '    AgL.ADMain.Fill(ds)
        '    Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
        '    mPrnHnd.DataSetToPrint = ds
        '    mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
        '    mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
        '    mPrnHnd.ReportTitle = "Customer Category 1 Master"
        '    mPrnHnd.TableIndex = 0
        '    mPrnHnd.PageSetupDialog(True)
        '    mPrnHnd.PrintPreview()
        '    Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        'Catch Ex As Exception
        '    MsgBox(Ex.Message)
        'End Try
        'Me.Cursor = Cursors.Default
        Call PrintDocument()
    End Sub

    Private Sub PrintDocument()
        Dim mQry1 As String = ""
        Dim mQry2 As String = ""
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim DsRep1 As New DataSet
        Dim DsRep2 As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = "Room Type"
            RepName = "Hostel_RoomType" : RepTitle = "Room Type"

            mQry = " SELECT Rt.Code, Rt.Description, Rt.ManualCode, Rt.Div_Code, Rt.Site_Code, Rt.PreparedBy, " & _
                    " Rt.U_EntDt, Rt.U_AE, Rt.Edit_Date, Rt.ModifiedBy " & _
                    " FROM Ht_RoomType Rt " & _
                    " LEFT JOIN SiteMast S ON Rt.Site_Code=S.Code " & _
                    "WHERE Rt.Code='" & mSearchCode & "'"

            mQry1 = "SELECT Rt1.Sr, Rt1.Facilities FROM Ht_RoomType1 Rt1 " & _
                    "WHERE Rt1.Code='" & mSearchCode & "'"

            mQry2 = "SELECT Rtc.Sr, Rtc.Charge, Vc.ChargeName, " & _
                    " Rtc.Amount, Rtc.ChargeType,  Rtc.DueMonth,    " & _
                    " CASE isnull(Rtc.IsOnceInLife,0) WHEN 1 THEN 'Y' ELSE 'N' END  as IsOnceInLife,   " & _
                    " CASE isnull(Rtc.IsFirstTimeRequired,0) WHEN 1 THEN 'Y' ELSE 'N' END  as IsFirstTimeRequired  " & _
                    " FROM dbo.Ht_RoomTypeCharge Rtc " & _
                    " LEFT JOIN ViewHt_Charge Vc ON Rtc.Charge=Vc.SubCode   " & _
                    "WHERE Rtc.Code='" & mSearchCode & "'"


            DsRep = AgL.FillData(mQry, AgL.GCn)

            DsRep1 = AgL.FillData(mQry1, AgL.GCn)
            DsRep2 = AgL.FillData(mQry2, AgL.GCn)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Hostel & "\" & RepName & ".ttx", True)
            AgPL.CreateFieldDefFile1(DsRep1, PLib.PubReportPath_Hostel & "\" & RepName & "1.ttx", True)
            AgPL.CreateFieldDefFile1(DsRep2, PLib.PubReportPath_Hostel & "\" & RepName & "2.ttx", True)

            mCrd.Load(PLib.PubReportPath_Hostel & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))

            mCrd.OpenSubreport("SUBREP1").Database.Tables(0).SetDataSource(DsRep1.Tables(0))
            mCrd.OpenSubreport("SUBREP2").Database.Tables(0).SetDataSource(DsRep2.Tables(0))

            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd

            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim I As Integer, Sr As Integer

        Try
            MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then

                mQry = " INSERT INTO Ht_RoomType (Code,Description,ManualCode," & _
                        " Div_Code,Site_Code,PreparedBy,U_EntDt,U_AE) " & _
                        " Values ('" & mSearchCode & "', " & AgL.Chk_Text(TxtDescription.Text) & ", " & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
                        " '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = " UPDATE Ht_RoomType SET " & _
                        " Description =" & AgL.Chk_Text(TxtDescription.Text) & ",ManualCode =  " & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, "Short Date") & "',ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE Code ='" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If Topctrl1.Mode = "Edit" Then
                mQry = " Delete From Ht_RoomType1 Where Code = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = " Delete From Ht_RoomTypeCharge Where Code = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Sr = 1
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Facilities, I).Value <> "" Then
                        mQry = " INSERT INTO Ht_RoomType1 ( Code, Sr, Facilities ) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & Sr & ", " & AgL.Chk_Text(.Item(Col1Facilities, I).Value) & " )"

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        Sr = Sr + 1
                    End If
                Next I
            End With

            Sr = 1
            With DGL2
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2Charge, I).Value <> "" Then

                        mQry = "INSERT INTO dbo.Ht_RoomTypeCharge(Code,	Sr,	Charge,	Amount,	" & _
                                " ChargeType,DueMonth, IsOnceInLife, IsFirstTimeRequired)" & _
                                " VALUES ('" & mSearchCode & "',	" & Sr & ",	" & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col2Charge, I)) & " ," & _
                                " " & .Item(Col2Amount, I).Value & " ,	" & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col2ChargeType, I)) & "," & _
                                " " & AgL.Chk_Text(.Item(Col2DueMonth, I).Value) & "," & _
                                " " & IIf(.Item(Col2IsOnceInLife, I).Value, 1, 0) & " ," & _
                                " " & IIf(.Item(Col2IsFirstTimeRequired, I).Value, 1, 0) & " ) "

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        Sr = Sr + 1
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
                mQry = " SELECT * From Ht_RoomType " & _
                        " Where Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtManualCode.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                        TxtDescription.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                    End If
                End With

                mQry = " Select HRT1.* " & _
                        " From Ht_RoomType1 HRT1 " & _
                        " Where HRT1.Code = '" & mSearchCode & "' " & _
                        " Order By HRT1.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        DGL1.RowCount = 1 : DGL1.Rows.Clear()
                        For I = 0 To .Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.Item(Col1Facilities, I).Value = AgL.XNull(.Rows(I)("Facilities"))
                        Next
                    End If
                End With

                mQry = "SELECT HRTC.*" & _
                        " FROM Ht_RoomTypeCharge HRTC  " & _
                        " WHERE Code='" & mSearchCode & "'"

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        DGL2.RowCount = 1 : DGL2.Rows.Clear()
                        For I = 0 To .Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count - 1
                            DGL2.AgSelectedValue(Col2Charge, I) = AgL.XNull(.Rows(I)("Charge"))
                            DGL2.Item(Col2Amount, I).Value = AgL.XNull(.Rows(I)("Amount"))
                            DGL2.AgSelectedValue(Col2ChargeType, I) = AgL.XNull(.Rows(I)("ChargeType"))
                            DGL2.Item(Col2DueMonth, I).Value = AgL.XNull(.Rows(I)("DueMonth"))
                            DGL2.Item(Col2IsOnceInLife, I).Value = AgL.XNull(.Rows(I)("IsOnceInLife"))
                            DGL2.Item(Col2IsFirstTimeRequired, I).Value = AgL.XNull(.Rows(I)("IsFirstTimeRequired"))
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
            DsTemp = Nothing
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
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

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
       TxtManualCode.Validating, TxtDescription.Validating
        Try
            Select Case sender.NAME
                Case TxtDescription.Name
                    If TxtDescription.Text.Trim = "" Then TxtDescription.Text = TxtManualCode.Text

            End Select

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

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating, DGL2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case Col1Facilities
                '    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                '        DGL1.Item(Col1Facilities, mRowIndex).Value = ""
                '    Else
                '        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                '            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                '                DGL1.Item(Col1Facilities, mRowIndex).Value = AgL.XNull(.Item("Facilities", .CurrentCell.RowIndex).Value)
                '            End With
                '        End If
                '    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown, DGL2.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded, DGL2.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved, DGL2.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, Col_SNo)
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0
        Try

            If AgL.RequiredField(TxtManualCode, "Manual Code") Then Exit Function
            If AgL.RequiredField(TxtDescription, "Description") Then Exit Function

            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Ht_RoomType Where ManualCode='" & TxtManualCode.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Ht_RoomType Where Description='" & TxtDescription.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Function

                mSearchCode = AgL.GetMaxId("Ht_RoomType", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 6, True, True, , AgL.Gcn_ConnectionString)
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Ht_RoomType Where ManualCode='" & TxtManualCode.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Ht_RoomType Where Description='" & TxtDescription.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Function
            End If

            With DGL2
                For I = 0 To DGL2.RowCount - 1
                    If .Item(Col2Charge, I).Value IsNot Nothing Then
                        If CBool(.Item(Col2IsOnceInLife, I).Value) And Not AgL.StrCmp(.Item(Col2ChargeType, I).Value.ToString, "Yearly") Then
                            MsgBox("""Once In Life"" Type Charges Are Yearly Type.........!", MsgBoxStyle.Information) : .CurrentCell = DGL2(Col2ChargeType, I) : DGL2.Focus()
                            Exit Function
                        End If

                        If CBool(.Item(Col2IsFirstTimeRequired, I).Value) And AgL.StrCmp(.Item(Col2ChargeType, I).Value.ToString, "Monthly") Then
                            MsgBox("""First Time Required"" Type Charges Are Not Monthly type.........!", MsgBoxStyle.Information) : .CurrentCell = DGL2(Col2ChargeType, I) : DGL2.Focus()
                            Exit Function
                        End If
                    End If
                Next
            End With


            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1Facilities) Then Exit Function

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function
End Class