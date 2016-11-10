Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRoomChargeDue

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1AllotmentDocId As Byte = 1
    Private Const Col1Charge As Byte = 2
    Private Const Col1Amount As Byte = 3
    Private Const Col1Code As Byte = 4

    Dim mMonthYear$ = ""

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
        AgL.AddAgDataGrid(DGL1, Pnl1)
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 50, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1AllotmetDocId", 180, 8, "Member Name", True, False, False)
            .AddAgTextColumn(DGL1, "DGL1Charge", 200, 30, "Charge Head", True, False, False)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 100, 8, 3, False, "Amount", True, False, True)
            .AddAgTextColumn(DGL1, "DGL1Code", 100, 8, "Code", False, False, False)
        End With
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
            AgL.WinSetting(Me, 615, 881, 0, 0)
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
        If AgL.PubMoveRecApplicable Then

            mQry = "Select HT.DocId As SearchCode " & _
                    " From Ht_ChargeDue HT " & _
                    " Left Join Voucher_Type Vt On Ht.V_Type = Vt.V_Type " & _
                    " Where 1=1 " & AgL.CondStrFinancialYear("HT.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                    " And " & AgL.PubSiteCondition("Ht.Site_Code", AgL.PubSiteCode) & " " & _
                    " And Vt.NCat in (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeDue) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeOpeningDue) & " , " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue) & ")"

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub


    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
                " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Vt.V_Type As Code, Vt.Description As [Voucher Type], Vt.Category, Vt.Ncat " & _
                " From Voucher_Type Vt " & _
                " where Vt.NCat in (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeDue) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeOpeningDue) & " , " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue) & ")" & _
                " Order By Vt.Description"
        TxtV_Type.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT VRA.DocId AS Code,VRA.MemberName AS MemberName,VRA.FatherName , Vra.LeftDate " & _
                " FROM ViewHt_RoomAllotment VRA " & _
                " Where " & AgL.PubSiteCondition("VRA.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By VRA.MemberDispName "
        DGL1.AgHelpDataSet(Col1AllotmentDocId, 1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT C.SubCode,Sg.Name AS Charge , Sg.ManualCode" & _
                " FROM Ht_Charge C " & _
                " LEFT JOIN SubGroup Sg ON C.SubCode=Sg.SubCode " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "C.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                " Order By Sg.Name "
        DGL1.AgHelpDataSet(Col1Charge, 1) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        Dim DrTemp As DataRow() = Nothing
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtDocId.Enabled = False
        TxtSite_Code.Enabled = False
        TxtAmount.Enabled = False

        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.ReadOnly = True
            TxtV_Date.Focus()
        Else
            TxtV_Type.ReadOnly = False
            TxtV_Type.Focus()
        End If

        'Code BY Akash on date 18-11-10
        If mAllotmentDocId.Trim <> "" Then
            TxtV_Type.Focus()
            If TxtV_Type.AgHelpDataSet IsNot Nothing Then
                DrTemp = TxtV_Type.AgHelpDataSet.Tables(0).Select("NCat <> " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue) & " ")
                TxtV_Type.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
            End If
            DGL1.AgSelectedValue(Col1AllotmentDocId, 0) = mAllotmentDocId
            TxtMonthStartDate.Text = CDate(AgL.PubLoginDate).ToString("MMM/yyyy")
            TxtV_Date.Focus()
        End If

        'End Code


    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
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

                    AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeDueLedgerM Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    AgL.Dman_ExecuteNonQry("Delete From HT_ChargeDue1 Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From HT_ChargeDue Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                    AgL.ETrans.Commit()
                    mTrans = False

                    If AgL.PubMoveRecApplicable Then
                        FIniMaster(1)
                        Topctrl1_tbRef()
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

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        If AgL.PubMoveRecApplicable Then FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub


    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtV_Date.Focus()
        TxtDocId.Enabled = False
        TxtSite_Code.Enabled = False
        TxtAmount.Enabled = False

        TxtV_No.Enabled = False
        TxtV_Type.Enabled = False

    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = "SELECT Cd.DocId as SearchCode, S.Name As [Site/Branch Name],  Convert(nVarChar,Cd.V_Date,3) As [Voucher Date], " & _
                                " " & AgL.V_No_Field("CD.DocId") & " As [Voucher No.], " & AgL.ConvertMonthYearField("Cd.MonthStartDate") & " as [Month Year],Cd.TotalAmount as [Total Amount], Cd.Remark " & _
                                " FROM Ht_ChargeDue Cd " & _
                                " LEFT JOIN SiteMast S ON Cd.Site_Code=S.Code " & _
                                " Left Join Voucher_Type Vt On Cd.V_Type = Vt.V_Type  " & _
                                " Where 1=1 " & AgL.CondStrFinancialYear("Cd.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                                " And " & AgL.PubSiteCondition("Cd.Site_Code", AgL.PubSiteCode) & " " & _
                                " And Vt.NCat in (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeDue) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeOpeningDue) & " , " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue) & ")"


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

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl_tbPrn() Handles Topctrl1.tbPrn
        Call PrintDocument(mSearchCode)
    End Sub

    Private Sub PrintDocument(ByVal mDocId As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = "Room Charge Due"
            RepName = "Hostel_RoomChargeDue" : RepTitle = "Room Charge Due"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = "SELECT Vcd.DocId, Vcd.Div_Code, Vcd.Site_Code, Vcd.V_Date, Vcd.V_Type, Vcd.V_Prefix, " & _
                    " Vcd.V_No, Vcd.MonthStartDate, Vcd.TotalAmount, Vcd.Remark, Vcd.PreparedBy, Vcd.U_EntDt, " & _
                    " Vcd.U_AE, Vcd.Edit_Date, Vcd.ModifiedBy, Vcd.ChargeDue1Code, Vcd.AllotmentDocId, " & _
                    " Vcd.ChargeCode, Vcd.DueAmount, Vcd.ChargeName, Vcd.ChargeManualCode, Vcd.ChargeDispName, " & _
                    " Vra.MemberName, Vra.MemberDispName, Sm.Name " & _
                    " FROM dbo.ViewHt_ChargeDue Vcd " & _
                    " LEFT JOIN ViewHt_RoomAllotment Vra ON Vcd.AllotmentDocId = Vra.DocId  " & _
                    " LEFT JOIN SiteMast Sm ON Vcd.Site_Code=Sm.Code " & _
                    " WHERE Vcd.DocId = '" & mSearchCode & "' "



            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Hostel & "\" & RepName & ".ttx", True)
            mCrd.Load(PLib.PubReportPath_Hostel & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, mSr As Integer = 0, J As Integer
        Dim mTrans As Boolean = False, mFlagBln As Boolean = False
        Dim bChargeDueObj As New Struct_ChargeDue, bChargeDue1Obj() As Struct_ChargeDue1 = Nothing
        Dim GcnRead As SqlClient.SqlConnection

        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            With bChargeDueObj
                .DocId = mSearchCode
                .Div_Code = AgL.PubDivCode
                .Site_Code = TxtSite_Code.AgSelectedValue
                .V_Type = TxtV_Type.AgSelectedValue
                .V_Prefix = LblPrefix.Text
                .V_No = Val(TxtV_No.Text)
                .V_Date = TxtV_Date.Text
                .Remark = TxtRemark.Text
                .TotalAmount = Val(TxtAmount.Text)
                '.MonthStartDate = TxtMonthStartDate.Text
                .MonthStartDate = LblMonthStartDate.Tag
            End With

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If mFlagBln = False Then
                        J = 0
                        mFlagBln = True
                    Else
                        J = UBound(bChargeDue1Obj) + 1
                    End If
                    ReDim Preserve bChargeDue1Obj(J)

                    bChargeDue1Obj(J).Code = .Item(Col1Code, I).Value
                    bChargeDue1Obj(J).DocId = mSearchCode
                    bChargeDue1Obj(J).AllotmentDocId = .AgSelectedValue(Col1AllotmentDocId, I)
                    bChargeDue1Obj(J).Charge = .AgSelectedValue(Col1Charge, I)
                    bChargeDue1Obj(J).Amount = Val(.Item(Col1Amount, I).Value)
                Next
            End With


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            Call ProcSaveChargeDueDetail(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bChargeDueObj, bChargeDue1Obj)
            Call FunChargeDueAccountPosting(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bChargeDueObj, AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_RoomChargeOpeningDue))

            Call AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            Call AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False
            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl1_tbRef()
            End If
            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                mAllotmentDocId = ""
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
        Dim mTransFlag As Boolean = False
        Dim MastPos As Long
        Dim I As Integer
        Try
            FClear()
            BlankText()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Count > 0 Then
                    MastPos = BMBMaster.Position
                    mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                Else
                    mSearchCode = ""
                End If
            Else
                mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then

                mQry = "Select CD.*, Vt.NCat " & _
                        " From Ht_ChargeDue CD " & _
                        " Left Join Voucher_Type Vt On CD.V_Type = Vt.V_Type " & _
                        " Where CD.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)

                    If .Rows.Count > 0 Then
                        TxtDocId.Text = AgL.XNull(.Rows(0)("DocId"))
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Date.Text = AgL.RetDate(AgL.XNull(.Rows(0)("V_Date")))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(0 + 2, "0"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCAt"))
                        LblMonthStartDate.Tag = AgL.RetDate(AgL.XNull(.Rows(0)("MonthStartDate")))
                        TxtMonthStartDate.Text = CDate(LblMonthStartDate.Tag).ToString("MMM/yyyy")
                        mMonthYear = CDate(LblMonthStartDate.Tag).ToString("MMM/yyyy")
                        'TxtMonthStartDate.Text = AgL.RetDate(AgL.XNull(.Rows(0)("MonthStartDate")))
                        TxtAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select st.* From Ht_ChargeDue1 st " & _
                        " Where st.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1AllotmentDocId, I) = AgL.XNull(.Rows(I)("AllotmentDocId"))
                            DGL1.AgSelectedValue(Col1Charge, I) = AgL.XNull(.Rows(I)("Charge"))
                            DGL1.Item(Col1Amount, I).Value = AgL.VNull(.Rows(I)("Amount"))
                            DGL1.Item(Col1Code, I).Value = AgL.XNull(.Rows(I)("Code"))
                            'Code By Akash on date 15-11-10
                            If mTransFlag = False Then
                                mQry = "SELECT count(Cr1.ChargeDue1) AS Cnt FROM Ht_ChargeReceive1 Cr1 WHERE Cr1.ChargeDue1='" & DGL1.Item(Col1Code, I).Value & "'"
                                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then mTransFlag = True
                            End If
                            'End Code
                        Next I
                    End If
                End With
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)
            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue) Then
                DGL1.ReadOnly = True
            Else
                DGL1.ReadOnly = False
            End If



            If mTransFlag Then
                Topctrl1.tEdit = False
                Topctrl1.tDel = False
            Else
                If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes()
        mSearchCode = "" : LblPrefix.Text = ""

        LblV_Type.Tag = ""
        BtnFill.Tag = ""
        mMonthYear = "" : LblMonthStartDate.Tag = ""

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtV_No.Enabled = False
        TxtSite_Code.Enabled = False
        If Topctrl1.Mode = "Edit" Then
            TxtV_Type.Enabled = False : TxtMonthStartDate.Enabled = False : BtnFill.Enabled = False
        Else
            BtnFill.Enabled = True
        End If
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex
            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                'Case Col1AdmissionDocId
                '    DGL1.AgRowFilter(Col1AdmissionDocId) = " CurrentSemesterCode = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "

                Case Col1AllotmentDocId
                    DGL1.AgRowFilter(Col1AllotmentDocId) = " LeftDate IS NULL "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating

        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim Munit As String
        Munit = ""
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGL1.EditingControlShowing
        If Topctrl1.Mode = "Browse" Then Exit Sub
        If TypeOf e.Control Is ComboBox Then
            e.Control.Text = ""
        End If
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub

        Try
            Select Case sender.CurrentCell.ColumnIndex
                'Case <Dgl_Column>
                '    <Executable Code>
            End Select
        Catch Ex As NullReferenceException
        Catch Ex As Exception
            MsgBox(Ex.Message)
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

        If DGL1.Rows.Count = 1 And Topctrl1.Mode = "Add" Then
            If DGL1.Item(Col1Charge, 0).Value Is Nothing Then DGL1.Item(Col1Charge, 0).Value = ""
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
         TxtV_Type.Enter
        Try
            Select Case sender.name
                'Case TxtAcCode.Name
                '    Call IniAccountHelp(False)

                Case TxtV_Type.Name
                    If BtnFill.Tag <> "" Then
                        TxtV_Type.AgRowFilter = " NCat = " & AgL.Chk_Text(BtnFill.Tag) & " "
                    ElseIf mAllotmentDocId.Trim <> "" Then
                        TxtV_Type.AgRowFilter = " NCat <> " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue) & " "
                    Else
                        TxtV_Type.AgRowFilter = ""
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
           TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_Type.Validating, TxtMonthStartDate.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblV_Type.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtV_Type.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & "")
                            LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
                            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue) Then
                                DGL1.ReadOnly = True
                            Else
                                DGL1.ReadOnly = False
                            End If
                        End If
                    End If

                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate

                Case TxtMonthStartDate.Name
                    If TxtMonthStartDate.Text.Trim = "" Then
                        LblMonthStartDate.Tag = ""
                    Else
                        'LblMonthStartDate.Tag = TxtMonthStartDate.Text
                        TxtMonthStartDate.Text = CDate(TxtMonthStartDate.Text).ToString("MMM/yyyy")
                        LblMonthStartDate.Tag = CDate(TxtMonthStartDate.Text).ToString("01/MMM/yyyy")


                    End If
            End Select



            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mSearchCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim mPostAC As String = ""
        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()
        Try
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function


            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue) Then
                'mQry = "SELECT count(Cd.V_Type) AS Cnt " & _
                '        " FROM Ht_ChargeDue Cd " & _
                '        " WHERE Cd.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                '        " AND Cd.V_Type='" & Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue & "' AND Cd.MonthStartDate='" & CDate(LblMonthStartDate.Tag) & "' " & _
                '        " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Cd.DocId <> '" & mSearchCode & "' ") & " "
                'If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) > 0 Then MsgBox("Charges For """ & TxtMonthStartDate.Text & """ Are Already Due.......!", MsgBoxStyle.Information) : TxtMonthStartDate.Focus() : Exit Function

                If FunIsChargeDueExists() Then MsgBox("Charges For """ & TxtMonthStartDate.Text & """ Are Already Due.......!", MsgBoxStyle.Information) : TxtMonthStartDate.Focus() : Exit Function
                If Not (AgL.StrCmp(mMonthYear, TxtMonthStartDate.Text)) Then MsgBox(" Invalid Month/Year.....! ", MsgBoxStyle.Information) : TxtMonthStartDate.Focus() : Exit Function
            End If

            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_RoomChargeOpeningDue) Then
                If CDate(TxtV_Date.Text) > CDate(AgL.PubStartDate) Then
                    MsgBox("Voucher Date Can't Be Greater Than From " & AgL.PubStartDate & "!...")
                    TxtV_Date.Focus() : Exit Function
                End If
            End If


            If AgCL.AgIsBlankGrid(DGL1, Col1Charge) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1AllotmentDocId & "," & Col1Charge & "") Then Exit Function



            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mSearchCode <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                    TxtDocId.Text = mSearchCode
                End If
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        TxtAmount.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1AllotmentDocId, I).Value <> "" And .Item(Col1Charge, I).Value <> "" Then
                    TxtAmount.Text = Format(Val(TxtAmount.Text) + Val(.Item(Col1Amount, I).Value), "0.00")
                End If
            Next
        End With
    End Sub

    Private Sub ProcFillCharge()
        Dim DtTemp As DataTable, DtTemp1 As DataTable
        Dim I As Integer
        Dim bAdvanceAmount As Double = 0
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            'TxtIsManageCharge.Text = "No"
            If AgL.RequiredField(TxtMonthStartDate) Then Exit Sub
            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_RoomChargeDue) Then Exit Sub
            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            
            If FunIsChargeDueExists() Then MsgBox("Charges For """ & TxtMonthStartDate.Text & """ Are Already Due.......!", MsgBoxStyle.Information) : TxtMonthStartDate.Focus() : Exit Sub


            'mQry = "SELECT RT.AllotmentDocId,RTC.Charge,RTC.Amount, RTC.RoomTransfer " & _
            '        " FROM Ht_RoomTransferCharge RTC   " & _
            '        " LEFT JOIN Ht_RoomTransfer RT ON RTC.RoomTransfer=RT.Code   " & _
            '        " LEFT JOIN Sch_FeeType FT ON RTC.ChargeType=FT.Code   " & _
            '        " WHERE (RTC.DueMonth='" & CDate(TxtMonthStartDate.Text).ToString("MMM") & "' OR FT.Months=1)  " & _
            '        " AND  " & _
            '        " RTC.Charge NOT IN  " & _
            '        " 				(SELECT CD1.Charge " & _
            '        " 				FROM Ht_ChargeDue1 CD1  " & _
            '        " 				LEFT JOIN Ht_RoomTransfer RT1 ON RT1.AllotmentDocId=CD1.AllotmentDocId " & _
            '        " 				LEFT JOIN Ht_RoomTransferCharge RTC1 ON RTC1.Charge=CD1.Charge " & _
            '        "               WHERE(RTC.Charge = CD1.Charge) " & _
            '        " 				AND CD1.AllotmentDocId=RT.AllotmentDocId AND RTC1.IsOnceInLife=1) "


            'mQry = "SELECT RT.AllotmentDocId,RTC.Charge,RTC.Amount, RTC.RoomTransfer " & _
            '        " FROM Ht_RoomTransferCharge RTC   " & _
            '        " LEFT JOIN Ht_RoomTransfer RT ON RTC.RoomTransfer=RT.Code   " & _
            '        " LEFT JOIN Sch_FeeType FT ON RTC.ChargeType=FT.Code   " & _
            '        " WHERE RT.TransferDate IS NULL " & _
            '        " AND (RTC.DueMonth='" & CDate(TxtMonthStartDate.Text).ToString("MMM") & "' OR FT.Months=1)  " & _
            '        " AND  " & _
            '        " RTC.Charge NOT IN  " & _
            '        " 				(SELECT CD1.Charge " & _
            '        " 				FROM Ht_ChargeDue1 CD1  " & _
            '        "               WHERE RTC.Charge = CD1.Charge " & _
            '        " 				AND CD1.AllotmentDocId=RT.AllotmentDocId AND IsNull(RTC.IsOnceInLife,0) <> 0 ) "


            'Code By Akash on date 15-11-10

            'If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue) Then
            '    DGL1.ReadOnly = True
            'Else
            '    DGL1.ReadOnly = False
            'End If

            'End Code


            mQry = "SELECT RT.AllotmentDocId, RTC.Charge, RTC.Amount, RTC.RoomTransfer " & _
                    " FROM ViewHt_RoomTransfer RT " & _
                    " INNER Join  " & _
                    " ( " & _
                    " SELECT Max(Rt1.ChargeStartDate) AS ChargeStartDate, Rt1.AllotmentDocId   " & _
                    " FROM Ht_RoomTransfer Rt1 " & _
                    " WHERE Rt1.ChargeStartDate <= '" & AgL.RetMonthEndDate(CDate(LblMonthStartDate.Tag)) & "' " & _
                    " GROUP BY Rt1.AllotmentDocId " & _
                    " ) vRt ON Rt.AllotmentDocId = vRt.AllotmentDocId AND vRt.ChargeStartDate = Rt.ChargeStartDate " & _
                    " LEFT JOIN Ht_RoomTransferCharge RTC ON RTC.RoomTransfer=RT.Code " & _
                    " LEFT JOIN Sch_FeeType FT ON RTC.ChargeType=FT.Code " & _
                    " WHERE (RTC.DueMonth='" & CDate(LblMonthStartDate.Tag).ToString("MMM") & "' OR FT.Months=1) " & _
                    " AND RTC.Charge NOT IN " & _
                    "    				(SELECT CD1.Charge " & _
                    "    				FROM Ht_ChargeDue1 CD1 " & _
                    " 					LEFT JOIN Ht_ChargeDue Cd ON Cd.DocId=Cd1.DocId " & _
                    "    				WHERE RTC.Charge = CD1.Charge " & _
                    "    				AND CD1.AllotmentDocId=RT.AllotmentDocId " & _
                    "    				AND IsNull(RTC.IsOnceInLife,0) <> 0 ) " & _
                    " AND CASE WHEN Rt.LeftDate IS NULL Then '" & AgL.RetMonthEndDate(CDate(LblMonthStartDate.Tag)) & "' ELSE Rt.LeftDate END >= '" & AgL.RetMonthEndDate(CDate(LblMonthStartDate.Tag)) & "' " & _
                    " AND Rt.AllotmentDocId NOT IN (SELECT Ra.DocId  " & _
                    "		                        FROM Ht_RoomAllotment Ra  " & _
                    "		                        WHERE " & AgL.ConvertMonthYearField("Ra.V_Date") & " ='" & CDate(LblMonthStartDate.Tag).ToString("MMM/yyyy") & "' ) "


            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                        DGL1.AgSelectedValue(Col1AllotmentDocId, I) = AgL.XNull(.Rows(I)("AllotmentDocId"))
                        DGL1.AgSelectedValue(Col1Charge, I) = AgL.XNull(.Rows(I)("Charge"))
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                    Next I
                    'Code by Akash on date 15-11-10
                    BtnFill.Tag = LblV_Type.Tag
                    mMonthYear = TxtMonthStartDate.Text
                    'End Code
                Else
                    MsgBox("No Charge Exists To Due!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            DtTemp1 = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Call ProcFillCharge()
    End Sub

    Private Function FunIsChargeDueExists() As Boolean
        Dim bFlag As Boolean = False

        mQry = "SELECT count(Cd.V_Type) AS Cnt " & _
                " FROM Ht_ChargeDue Cd " & _
                " WHERE Cd.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                " AND Cd.V_Type='" & Academic_ProjLib.ClsMain.NCat_RoomChargeMonthlyDue & "' AND Cd.MonthStartDate='" & CDate(LblMonthStartDate.Tag) & "' " & _
                " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Cd.DocId <> '" & mSearchCode & "' ") & " "

        If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) > 0 Then bFlag = True

        FunIsChargeDueExists = bFlag
    End Function
End Class