Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmPeriodicalRecdYearly
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = ""
    Public mSearchCode As String = ""
    Dim ClsRep As ClsReportProcedures

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1Item As String = "Bimonthly General & Periodical"
    Protected Const Col1SubscribedQty As String = "Subs Qty"
    Protected Const Col1BiMonth1 As String = "BiMonth1"
    Protected Const Col1BiMonth2 As String = "BiMonth2"
    Protected Const Col1BiMonth3 As String = "BiMonth3"
    Protected Const Col1BiMonth4 As String = "BiMonth4"
    Protected Const Col1BiMonth5 As String = "BiMonth5"
    Protected Const Col1BiMonth6 As String = "BiMonth6"

    Protected Const Col1QtyBiMonth1 As String = "QtyBiMonth1"
    Protected Const Col1QtyBiMonth2 As String = "QtyBiMonth2"
    Protected Const Col1QtyBiMonth3 As String = "QtyBiMonth3"
    Protected Const Col1QtyBiMonth4 As String = "QtyBiMonth4"
    Protected Const Col1QtyBiMonth5 As String = "QtyBiMonth5"
    Protected Const Col1QtyBiMonth6 As String = "QtyBiMonth6"
    
    'Temp Columns For DGL1
    Protected Const Col1XBiMonth1 As String = "XBiMonth1"
    Protected Const Col1XBiMonth2 As String = "XBiMonth2"
    Protected Const Col1XBiMonth3 As String = "XBiMonth3"
    Protected Const Col1XBiMonth4 As String = "XBiMonth4"
    Protected Const Col1XBiMonth5 As String = "XBiMonth5"
    Protected Const Col1XBiMonth6 As String = "XBiMonth6"

    Protected Const Col1XQtyBiMonth1 As String = "XQtyBiMonth1"
    Protected Const Col1XQtyBiMonth2 As String = "XQtyBiMonth2"
    Protected Const Col1XQtyBiMonth3 As String = "XQtyBiMonth3"
    Protected Const Col1XQtyBiMonth4 As String = "XQtyBiMonth4"
    Protected Const Col1XQtyBiMonth5 As String = "XQtyBiMonth5"
    Protected Const Col1XQtyBiMonth6 As String = "XQtyBiMonth6"
    'End DGL1


    Public WithEvents Dgl2 As New AgControls.AgDataGrid
    Protected Const Col2Item As String = "Quarterly General & Periodical"
    Protected Const Col2SubscribedQty As String = "Subs Qty"
    Protected Const Col2Quarter1 As String = "Quarter1"
    Protected Const Col2Quarter2 As String = "Quarter2"
    Protected Const Col2Quarter3 As String = "Quarter3"
    Protected Const Col2Quarter4 As String = "Quarter4"

    Protected Const Col2QtyQuarter1 As String = "QtyQuarter1"
    Protected Const Col2QtyQuarter2 As String = "QtyQuarter2"
    Protected Const Col2QtyQuarter3 As String = "QtyQuarter3"
    Protected Const Col2QtyQuarter4 As String = "QtyQuarter4"

    Protected Const Col2XQuarter1 As String = "XQuarter1"
    Protected Const Col2XQuarter2 As String = "XQuarter2"
    Protected Const Col2XQuarter3 As String = "XQuarter3"
    Protected Const Col2XQuarter4 As String = "XQuarter4"

    Protected Const Col2XQtyQuarter1 As String = "XQtyQuarter1"
    Protected Const Col2XQtyQuarter2 As String = "XQtyQuarter2"
    Protected Const Col2XQtyQuarter3 As String = "XQtyQuarter3"
    Protected Const Col2XQtyQuarter4 As String = "XQtyQuarter4"



    Public WithEvents Dgl3 As New AgControls.AgDataGrid
    Protected Const Col3Item As String = "HalfYearly General & Periodical"
    Protected Const Col3SubscribedQty As String = "Subs Qty"
    Protected Const Col3HalfYear1 As String = "HalfYear1"
    Protected Const Col3HalfYear2 As String = "HalfYear2"

    Protected Const Col3QtyHalfYear1 As String = "QtyHalfYear1"
    Protected Const Col3QtyHalfYear2 As String = "QtyHalfYear2"

    Protected Const Col3XHalfYear1 As String = "XHalfYear1"
    Protected Const Col3XHalfYear2 As String = "XHalfYear2"

    Protected Const Col3XQtyHalfYear1 As String = "XQtyHalfYear1"
    Protected Const Col3XQtyHalfYear2 As String = "XQtyHalfYear2"

    Public WithEvents Dgl4 As New AgControls.AgDataGrid
    Protected Const Col4Item As String = "Yearly General & Periodical"
    Protected Const Col4SubscribedQty As String = "Subs Qty"
    Protected Const Col4ReceiveDate As String = "Receive Date"
    Protected Const Col4XReceiveDate As String = "XReceive Date"
    Protected Const Col4Qty As String = "Qty"
    Protected Const Col4XQty As String = "XQty"

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

        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 185, 0, Col1Item, True, True)
            .AddAgNumberColumn(Dgl1, Col1SubscribedQty, 40, 4, 0, False, Col1SubscribedQty, True, True)
            .AddAgDateColumn(Dgl1, Col1BiMonth1, 78, Col1BiMonth1, True, False)
            .AddAgDateColumn(Dgl1, Col1BiMonth2, 78, Col1BiMonth2, True, False)
            .AddAgDateColumn(Dgl1, Col1BiMonth3, 78, Col1BiMonth3, True, False)
            .AddAgDateColumn(Dgl1, Col1BiMonth4, 78, Col1BiMonth4, True, False)
            .AddAgDateColumn(Dgl1, Col1BiMonth5, 78, Col1BiMonth5, True, False)
            .AddAgDateColumn(Dgl1, Col1BiMonth6, 78, Col1BiMonth6, True, False)

            .AddAgNumberColumn(Dgl1, Col1QtyBiMonth1, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl1, Col1QtyBiMonth2, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl1, Col1QtyBiMonth3, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl1, Col1QtyBiMonth4, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl1, Col1QtyBiMonth5, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl1, Col1QtyBiMonth6, 40, 4, 0, False, "Qty")


            .AddAgDateColumn(Dgl1, Col1XBiMonth1, 80, Col1XBiMonth1, False, False)
            .AddAgDateColumn(Dgl1, Col1XBiMonth2, 80, Col1XBiMonth2, False, False)
            .AddAgDateColumn(Dgl1, Col1XBiMonth3, 80, Col1XBiMonth3, False, False)
            .AddAgDateColumn(Dgl1, Col1XBiMonth4, 80, Col1XBiMonth4, False, False)
            .AddAgDateColumn(Dgl1, Col1XBiMonth5, 80, Col1XBiMonth5, False, False)
            .AddAgDateColumn(Dgl1, Col1XBiMonth6, 80, Col1XBiMonth6, False, False)

            .AddAgNumberColumn(Dgl1, Col1XQtyBiMonth1, 40, 4, 0, False, Col1XQtyBiMonth1, False)
            .AddAgNumberColumn(Dgl1, Col1XQtyBiMonth2, 40, 4, 0, False, Col1XQtyBiMonth2, False)
            .AddAgNumberColumn(Dgl1, Col1XQtyBiMonth3, 40, 4, 0, False, Col1XQtyBiMonth3, False)
            .AddAgNumberColumn(Dgl1, Col1XQtyBiMonth4, 40, 4, 0, False, Col1XQtyBiMonth4, False)
            .AddAgNumberColumn(Dgl1, Col1XQtyBiMonth5, 40, 4, 0, False, Col1XQtyBiMonth5, False)
            .AddAgNumberColumn(Dgl1, Col1XQtyBiMonth6, 40, 4, 0, False, Col1XQtyBiMonth6, False)


        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Pnl1.Anchor = Dgl1.Anchor
        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AllowUserToAddRows = False


        With AgCL
            .AddAgTextColumn(Dgl2, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Item, 110, 0, Col2Item, True, True)
            .AddAgNumberColumn(Dgl2, Col2SubscribedQty, 40, 4, 0, False, Col2SubscribedQty, True, True)
            .AddAgDateColumn(Dgl2, Col2Quarter1, 78, Col2Quarter1, True, False)
            .AddAgDateColumn(Dgl2, Col2Quarter2, 78, Col2Quarter2, True, False)
            .AddAgDateColumn(Dgl2, Col2Quarter3, 78, Col2Quarter3, True, False)
            .AddAgDateColumn(Dgl2, Col2Quarter4, 78, Col2Quarter4, True, False)

            .AddAgNumberColumn(Dgl2, Col2QtyQuarter1, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl2, Col2QtyQuarter2, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl2, Col2QtyQuarter3, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl2, Col2QtyQuarter4, 40, 4, 0, False, "Qty")


            .AddAgDateColumn(Dgl2, Col2XQuarter1, 80, Col2XQuarter1, False, False)
            .AddAgDateColumn(Dgl2, Col2XQuarter2, 80, Col2XQuarter2, False, False)
            .AddAgDateColumn(Dgl2, Col2XQuarter3, 80, Col2XQuarter3, False, False)
            .AddAgDateColumn(Dgl2, Col2XQuarter4, 80, Col2XQuarter4, False, False)

            .AddAgNumberColumn(Dgl2, Col2XQtyQuarter1, 40, 4, 0, False, Col2XQtyQuarter1, False)
            .AddAgNumberColumn(Dgl2, Col2XQtyQuarter2, 40, 4, 0, False, Col2XQtyQuarter2, False)
            .AddAgNumberColumn(Dgl2, Col2XQtyQuarter3, 40, 4, 0, False, Col2XQtyQuarter3, False)
            .AddAgNumberColumn(Dgl2, Col2XQtyQuarter4, 40, 4, 0, False, Col2XQtyQuarter4, False)

        End With
        AgL.AddAgDataGrid(Dgl2, Pnl2)
        Dgl2.EnableHeadersVisualStyles = False
        Dgl2.Anchor = AnchorStyles.None
        Pnl2.Anchor = Dgl2.Anchor
        Dgl2.ColumnHeadersHeight = 35
        Dgl2.AllowUserToAddRows = False


        With AgCL
            .AddAgTextColumn(Dgl3, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl3, Col3Item, 190, 0, Col3Item, True, True)
            .AddAgNumberColumn(Dgl3, Col3SubscribedQty, 65, 4, 0, False, Col3SubscribedQty, True, True)
            .AddAgDateColumn(Dgl3, Col3HalfYear1, 140, Col3HalfYear1, True, False)
            .AddAgDateColumn(Dgl3, Col3HalfYear2, 140, Col3HalfYear2, True, False)

            .AddAgNumberColumn(Dgl3, Col3QtyHalfYear1, 40, 4, 0, False, "Qty")
            .AddAgNumberColumn(Dgl3, Col3QtyHalfYear2, 40, 4, 0, False, "Qty")

            .AddAgDateColumn(Dgl3, Col3XHalfYear1, 125, Col3XHalfYear1, False, False)
            .AddAgDateColumn(Dgl3, Col3XHalfYear2, 125, Col3XHalfYear2, False, False)

            .AddAgNumberColumn(Dgl3, Col3XQtyHalfYear1, 40, 4, 0, False, Col3XQtyHalfYear1, False)
            .AddAgNumberColumn(Dgl3, Col3XQtyHalfYear2, 40, 4, 0, False, Col3XQtyHalfYear2, False)
        End With
        AgL.AddAgDataGrid(Dgl3, Pnl3)
        Dgl3.EnableHeadersVisualStyles = False
        Dgl3.Anchor = AnchorStyles.None
        Pnl3.Anchor = Dgl3.Anchor
        Dgl3.ColumnHeadersHeight = 25
        Dgl3.AllowUserToAddRows = False

        With AgCL
            .AddAgTextColumn(Dgl4, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl4, Col4Item, 105, 0, Col4Item, True, True)
            .AddAgNumberColumn(Dgl4, Col4SubscribedQty, 40, 4, 0, False, Col4SubscribedQty, True, True)
            .AddAgDateColumn(Dgl4, Col4ReceiveDate, 78, Col4ReceiveDate, True, False)
            .AddAgDateColumn(Dgl4, Col4XReceiveDate, 105, Col4XReceiveDate, False, False)

            .AddAgNumberColumn(Dgl4, Col4Qty, 30, 4, 0, False, Col4Qty)
            .AddAgNumberColumn(Dgl4, Col4XQty, 40, 4, 0, False, Col4XQty, False)
        End With
        AgL.AddAgDataGrid(Dgl4, Pnl4)
        Dgl4.EnableHeadersVisualStyles = False
        Dgl4.Anchor = AnchorStyles.None
        Pnl4.Anchor = Dgl4.Anchor
        Dgl4.ColumnHeadersHeight = 35
        Dgl4.AllowUserToAddRows = False

        Call ProcSetDispIndex()
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = (Keys.S And e.Control) Then
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
            AgL.WinSetting(Me, 660, 1020, 0, 0)
            AgL.GridDesign(Dgl1)
            AgL.GridDesign(Dgl2)
            AgL.GridDesign(Dgl3)
            AgL.GridDesign(Dgl4)
            IniGrid()
            Topctrl1.ChangeAgGridState(Dgl1, False)
            Topctrl1.ChangeAgGridState(Dgl2, False)
            Topctrl1.ChangeAgGridState(Dgl3, False)
            Topctrl1.ChangeAgGridState(Dgl4, False)
            If AgL.PubMoveRecApplicable Then FIniMaster()
            Ini_List()
            'DispText()
            ProcInitializeDate()
            FindMove(FunGetSearchCode(LblV_Date.Tag))
            'MoveRec()
            TxtV_Date.Enabled = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr As String


        If AgL.PubMoveRecApplicable Then
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("C.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("C.Site_Code", AgL.PubSiteCode) & " " & _
                            " And Vt.NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.GeneralPeriodicalYearlyRecd) & ""

            mQry = "Select C.DocId As SearchCode " & _
                    " From PurchChallan C " & _
                    " LEFT JOIN Voucher_Type Vt ON C.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
                  " Where NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.GeneralPeriodicalYearlyRecd) & ""
            TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                     " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                     " I.MeasureUnit, I.Measure As MeasurePerPcs, 0 As Rate, 1 As PendingQty, I.Status " & _
                     " FROM Item I"
            Dgl1.AgHelpDataSet(Col1Item, 8) = AgL.FillData(mQry, AgL.GCn)
            Dgl2.AgHelpDataSet(Col2Item, 8) = AgL.FillData(mQry, AgL.GCn)
            Dgl3.AgHelpDataSet(Col3Item, 8) = AgL.FillData(mQry, AgL.GCn)
            Dgl4.AgHelpDataSet(Col4Item, 8) = AgL.FillData(mQry, AgL.GCn)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbEdit() Handles Topctrl1.tbEdit
        'DispText(True)
    End Sub

    Private Sub Topctrl_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, J As Integer, bSr As Integer
        Dim mTrans As Boolean = False
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO PurchChallan(DocID,	V_Type, V_Prefix, V_Date, V_No, Div_Code, " & _
                        " Site_Code, EntryBy, EntryDate) " & _
                        " VALUES(" & AgL.Chk_Text(mSearchCode) & ",  " & _
                        " " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(LblPrefix.Text) & ", " & AgL.Chk_Text(LblV_Date.Tag) & ", " & _
                        " " & Val(TxtV_No.Text) & ", " & _
                        " '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ") "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            mQry = "SELECT IsNull(Max(Sr),0)  FROM PurchChallanDetail With (NoLock) WHERE DocId = '" & mSearchCode & "'"
            bSr = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar

            With Dgl1
                For I = 0 To .Rows.Count - 1
                    For J = .Columns(Col1BiMonth1).Index To .Columns(Col1BiMonth6).Index
                        If .Item(Col1Item, I).Value <> "" Then
                            If (Not AgL.StrCmp(.Item(.Columns(J).Name, I).Value, .Item("X" & .Columns(J).Name, I).Value) _
                                Or Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) <> Val(.Item("X" & FunGetQtyColName(.Columns(J).Name), I).Value)) Then
                                If .Item("X" & .Columns(J).Name, I).Value = "" Then
                                    bSr += 1
                                    mQry = "INSERT INTO PurchChallanDetail(DocId, Sr, Item, Qty, " & _
                                            " Unit, V_Date, Edition, SysEdition) " & _
                                            " VALUES ( " & _
                                            " " & AgL.Chk_Text(mSearchCode) & ", " & Val(bSr) & ", " & _
                                            " " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & ", " & _
                                            " " & Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) & ", 'pcs', " & _
                                            " " & AgL.Chk_Text(.Item(J, I).Value) & ", " & _
                                            " " & AgL.Chk_Text(FunGetEdition(.Columns(J).Name, ClsMain.Recurrance.Bimonthly)) & ", " & _
                                            " " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Bimonthly)) & " " & _
                                            " )"
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                Else
                                    If .Item(.Columns(J).Name, I).Value <> "" Then
                                        mQry = "UPDATE PurchChallanDetail " & _
                                                " SET V_Date = " & AgL.Chk_Text(.Item(J, I).Value) & ", " & _
                                                " Qty = " & Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) & " " & _
                                                " WHERE DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Bimonthly)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    Else
                                        mQry = "Delete From PurchChallanDetail " & _
                                                " Where DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Bimonthly)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next I
            End With


            With Dgl2
                For I = 0 To .Rows.Count - 1
                    For J = .Columns(Col2Quarter1).Index To .Columns(Col2Quarter4).Index
                        If .Item(Col2Item, I).Value <> "" Then
                            If (Not AgL.StrCmp(.Item(.Columns(J).Name, I).Value, .Item("X" & .Columns(J).Name, I).Value) _
                                Or Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) <> Val(.Item("X" & FunGetQtyColName(.Columns(J).Name), I).Value)) Then
                                If .Item("X" & .Columns(J).Name, I).Value = "" Then
                                    bSr += 1
                                    mQry = "INSERT INTO PurchChallanDetail(DocId, Sr, Item, Qty, " & _
                                            " Unit, V_Date, Edition, SysEdition) " & _
                                            " VALUES ( " & _
                                            " " & AgL.Chk_Text(mSearchCode) & ", " & Val(bSr) & ", " & _
                                            " " & AgL.Chk_Text(.AgSelectedValue(Col2Item, I)) & ", " & _
                                            " " & Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) & ", 'pcs', " & _
                                            " " & AgL.Chk_Text(.Item(J, I).Value) & ", " & _
                                            " " & AgL.Chk_Text(FunGetEdition(.Columns(J).Name, ClsMain.Recurrance.Quarterly)) & ", " & _
                                            " " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Quarterly)) & " " & _
                                            " )"
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                Else
                                    If .Item(.Columns(J).Name, I).Value <> "" Then
                                        mQry = "UPDATE PurchChallanDetail " & _
                                                " SET V_Date = " & AgL.Chk_Text(.Item(J, I).Value) & ", " & _
                                                " Qty = " & Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) & " " & _
                                                " WHERE DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col2Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Quarterly)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    Else
                                        mQry = "Delete From PurchChallanDetail " & _
                                                " Where DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col2Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.Quarterly)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next I
            End With

            With Dgl3
                For I = 0 To .Rows.Count - 1
                    For J = .Columns(Col3HalfYear1).Index To .Columns(Col3HalfYear2).Index
                        If .Item(Col3Item, I).Value <> "" Then
                            If (Not AgL.StrCmp(.Item(.Columns(J).Name, I).Value, .Item("X" & .Columns(J).Name, I).Value) _
                                Or Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) <> Val(.Item("X" & FunGetQtyColName(.Columns(J).Name), I).Value)) Then
                                If .Item("X" & .Columns(J).Name, I).Value = "" Then
                                    bSr += 1
                                    mQry = "INSERT INTO PurchChallanDetail(DocId, Sr, Item, Qty, Unit, V_Date, Edition, SysEdition) " & _
                                            " VALUES ( " & _
                                            " " & AgL.Chk_Text(mSearchCode) & ", " & Val(bSr) & ", " & _
                                            " " & AgL.Chk_Text(.AgSelectedValue(Col3Item, I)) & ", " & _
                                            " " & Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) & ", 'pcs', " & _
                                            " " & AgL.Chk_Text(.Item(J, I).Value) & ", " & _
                                            " " & AgL.Chk_Text(FunGetEdition(.Columns(J).Name, ClsMain.Recurrance.HalfYearly)) & ", " & _
                                            " " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.HalfYearly)) & " " & _
                                            " )"
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                Else
                                    If .Item(.Columns(J).Name, I).Value <> "" Then
                                        mQry = "UPDATE PurchChallanDetail " & _
                                                " SET V_Date = " & AgL.Chk_Text(.Item(J, I).Value) & ", " & _
                                                " Qty = " & Val(.Item(FunGetQtyColName(.Columns(J).Name), I).Value) & " " & _
                                                " WHERE DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col3Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.HalfYearly)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    Else
                                        mQry = "Delete From PurchChallanDetail " & _
                                                " Where DocId = '" & mSearchCode & "' " & _
                                                " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col3Item, I)) & " " & _
                                                " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(.Columns(J).Name, ClsMain.Recurrance.HalfYearly)) & "  "
                                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                    End If
                                End If
                            End If
                        End If
                    Next
                Next I
            End With

            With Dgl4
                For I = 0 To .Rows.Count - 1
                    If .Item(Col4Item, I).Value <> "" Then
                        If (Not AgL.StrCmp(.Item(Col4ReceiveDate, I).Value, .Item(Col4XReceiveDate, I).Value) _
                            Or Val(.Item(Col4Qty, I).Value) <> Val(.Item(Col4XQty, I).Value)) Then
                            If .Item(Col4XReceiveDate, I).Value = "" Then
                                bSr += 1
                                mQry = "INSERT INTO PurchChallanDetail(DocId, Sr, Item, Qty, Unit, V_Date, Edition, SysEdition) " & _
                                        " VALUES ( " & _
                                        " " & AgL.Chk_Text(mSearchCode) & ", " & Val(bSr) & ", " & _
                                        " " & AgL.Chk_Text(.AgSelectedValue(Col4Item, I)) & ", " & _
                                        " " & Val(.Item(Col4Qty, I).Value) & ", 'pcs', " & _
                                        " " & AgL.Chk_Text(.Item(Col4ReceiveDate, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(FunGetEdition(Col4ReceiveDate, ClsMain.Recurrance.Annually)) & ", " & _
                                        " " & AgL.Chk_Text(FunGetSysEdition(Col4ReceiveDate, ClsMain.Recurrance.Annually)) & " " & _
                                        " )"
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            Else
                                If .Item(Col4ReceiveDate, I).Value <> "" Then
                                    mQry = "UPDATE PurchChallanDetail " & _
                                            " SET V_Date = " & AgL.Chk_Text(.Item(Col4ReceiveDate, I).Value) & ",  " & _
                                            " Qty = " & Val(.Item(Col4Qty, I).Value) & " " & _
                                            " WHERE DocId = '" & mSearchCode & "' " & _
                                            " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col4Item, I)) & " " & _
                                            " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(Col4ReceiveDate, ClsMain.Recurrance.Annually)) & "  "
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                Else
                                    mQry = "Delete From PurchChallanDetail " & _
                                            " Where DocId = '" & mSearchCode & "' " & _
                                            " And Item  = " & AgL.Chk_Text(.AgSelectedValue(Col4Item, I)) & " " & _
                                            " And SysEdition = " & AgL.Chk_Text(FunGetSysEdition(Col4ReceiveDate, ClsMain.Recurrance.Annually)) & "  "
                                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                                End If
                            End If
                        End If
                    End If
                Next I
            End With

            Call ProcPostStock(AgL.GCn, AgL.ECmd)

            AgL.UpdateVoucherCounter(mSearchCode, CDate(LblV_Date.Tag), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            mTmV_Type = "" : mTmV_Prefix = "" : mTmV_Date = "" : mTmV_NCat = ""

            Topctrl1.SetDisp(True)
            If AgL.PubMoveRecApplicable Then MoveRec()

            'If Topctrl1.Mode = "Add" Then
            '    Topctrl1.LblDocId.Text = mSearchCode

            '    mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

            '    Topctrl1.FButtonClick(0)
            '    Exit Sub
            'Else
            '    mTmV_Type = "" : mTmV_Prefix = "" : mTmV_Date = "" : mTmV_NCat = ""

            '    Topctrl1.SetDisp(True)
            '    If AgL.PubMoveRecApplicable Then MoveRec()
            'End If

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
        Dim bStreamYearSemester$ = ""
        Dim I As Integer = 0, J As Integer = 0, K As Integer = 0
        Dim ColName$ = "", XColName$ = "", QtyColName$ = "", XQtyColName$ = ""

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
            'mSearchCode = FunGetSearchCode(LblV_Date.Tag)
            If mSearchCode <> "" Then
                mQry = "Select C.*, Vt.NCat " & _
                          " From PurchChallan C " & _
                          " Left Join Voucher_Type Vt On C.V_Type = Vt.V_Type " & _
                          " Where C.DocId = '" & mSearchCode & "' "

                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = mSearchCode
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        LblV_Date.Tag = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtV_Date.Text = CDate(LblV_Date.Tag).ToString("yyyy")
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(+2, "0"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCat"))
                    End If
                End With

                mQry = "SELECT S.General AS Item, V1.V_Date, V1.SysEdition, S.Qty As SubscribedQty, V1.Qty   " & _
                        " FROM Lib_Subscription S " & _
                        " Left Join " & _
                        " 	(SELECT Cd.Item, Cd.V_Date, Cd.SysEdition, IsNull(Cd.Qty,0) As Qty " & _
                        " 	FROM PurchChallanDetail Cd " & _
                        " 	LEFT JOIN Lib_Generals G ON Cd.Item = G.Code " & _
                        " 	WHERE Cd.DocId = '" & mSearchCode & "'  " & _
                        " 	AND G.Recurrance = '" & ClsMain.Recurrance.Bimonthly & "' ) " & _
                        " AS V1 ON S.General = V1.Item " & _
                        " WHERE (Year('" & LblV_Date.Tag & "') BETWEEN Year(S.FromDate) AND Year(S.ToDate) " & _
                        " Or S.ToDate Is NULL) " & _
                        " AND S.Recurrance = '" & ClsMain.Recurrance.Bimonthly & "' " & _
                        " Order By S.General "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    K = 0
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            If K < .Rows.Count Then
                                Dgl1.Rows.Add()
                                Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count
                                Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(K)("Item"))
                                Dgl1.Item(Col1SubscribedQty, I).Value = AgL.VNull(.Rows(K)("SubscribedQty"))
                                For J = 0 To .Rows.Count - 1
                                    If Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(J)("Item")) Then
                                        If AgL.XNull(.Rows(J)("SysEdition")) <> "" Then
                                            ColName = FunGetColumnName(AgL.XNull(.Rows(J)("SysEdition")), ClsMain.Recurrance.Bimonthly)
                                            XColName = "X" & ColName
                                            QtyColName = FunGetQtyColName(ColName)
                                            XQtyColName = "X" & QtyColName
                                            Dgl1.Item(ColName, I).Value = AgL.XNull(.Rows(J)("V_Date"))
                                            Dgl1.Item(XColName, I).Value = AgL.XNull(.Rows(J)("V_Date"))
                                            Dgl1.Item(QtyColName, I).Value = AgL.VNull(.Rows(J)("Qty"))
                                            Dgl1.Item(XQtyColName, I).Value = AgL.VNull(.Rows(J)("Qty"))
                                        End If
                                        K = K + 1
                                    End If
                                Next
                            End If
                        Next I
                    End If
                End With

                mQry = "SELECT S.General AS Item, V1.V_Date, V1.SysEdition, S.Qty As SubscribedQty, V1.Qty   " & _
                        " FROM Lib_Subscription S " & _
                        " Left Join " & _
                        " 	(SELECT Cd.Item, Cd.V_Date, Cd.SysEdition, IsNull(Cd.Qty,0) As Qty " & _
                        " 	FROM PurchChallanDetail Cd " & _
                        " 	LEFT JOIN Lib_Generals G ON Cd.Item = G.Code " & _
                        " 	WHERE Cd.DocId = '" & mSearchCode & "'  " & _
                        " 	AND G.Recurrance = '" & ClsMain.Recurrance.Quarterly & "' ) " & _
                        " AS V1 ON S.General = V1.Item " & _
                        " WHERE (Year('" & LblV_Date.Tag & "') BETWEEN Year(S.FromDate) AND Year(S.ToDate) " & _
                        " Or S.ToDate Is NULL) " & _
                        " AND S.Recurrance = '" & ClsMain.Recurrance.Quarterly & "' " & _
                        " Order By S.General "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl2.RowCount = 1
                    Dgl2.Rows.Clear()
                    K = 0
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            If K < .Rows.Count Then
                                Dgl2.Rows.Add()
                                Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count
                                Dgl2.AgSelectedValue(Col2Item, I) = AgL.XNull(.Rows(K)("Item"))
                                Dgl2.Item(Col2SubscribedQty, I).Value = AgL.VNull(.Rows(K)("SubscribedQty"))
                                For J = 0 To .Rows.Count - 1
                                    If Dgl2.AgSelectedValue(Col2Item, I) = AgL.XNull(.Rows(J)("Item")) Then
                                        If AgL.XNull(.Rows(J)("SysEdition")) <> "" Then
                                            ColName = FunGetColumnName(AgL.XNull(.Rows(J)("SysEdition")), ClsMain.Recurrance.Quarterly)
                                            XColName = "X" & ColName
                                            QtyColName = FunGetQtyColName(ColName)
                                            XQtyColName = "X" & QtyColName
                                            Dgl2.Item(ColName, I).Value = AgL.XNull(.Rows(J)("V_Date"))
                                            Dgl2.Item(XColName, I).Value = AgL.XNull(.Rows(J)("V_Date"))
                                            Dgl2.Item(QtyColName, I).Value = AgL.VNull(.Rows(J)("Qty"))
                                            Dgl2.Item(XQtyColName, I).Value = AgL.VNull(.Rows(J)("Qty"))
                                        End If
                                        K = K + 1
                                    End If
                                Next
                            End If
                        Next I
                    End If
                End With

                mQry = "SELECT S.General AS Item, V1.V_Date, V1.SysEdition, S.Qty As SubscribedQty, V1.Qty " & _
                        " FROM Lib_Subscription S " & _
                        " Left Join " & _
                        " 	(SELECT Cd.Item, Cd.V_Date, Cd.SysEdition, IsNull(Cd.Qty,0) As Qty " & _
                        " 	FROM PurchChallanDetail Cd " & _
                        " 	LEFT JOIN Lib_Generals G ON Cd.Item = G.Code " & _
                        " 	WHERE Cd.DocId = '" & mSearchCode & "'  " & _
                        " 	AND G.Recurrance = '" & ClsMain.Recurrance.HalfYearly & "' ) " & _
                        " AS V1 ON S.General = V1.Item " & _
                        " WHERE (Year('" & LblV_Date.Tag & "') BETWEEN Year(S.FromDate) AND Year(S.ToDate) " & _
                        " Or S.ToDate Is NULL) " & _
                        " AND S.Recurrance = '" & ClsMain.Recurrance.HalfYearly & "' " & _
                        " Order By S.General "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl3.RowCount = 1
                    Dgl3.Rows.Clear()
                    K = 0
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            If K < .Rows.Count Then
                                Dgl3.Rows.Add()
                                Dgl3.Item(ColSNo, I).Value = Dgl3.Rows.Count
                                Dgl3.AgSelectedValue(Col3Item, I) = AgL.XNull(.Rows(K)("Item"))
                                Dgl3.Item(Col3SubscribedQty, I).Value = AgL.VNull(.Rows(K)("SubscribedQty"))
                                For J = 0 To .Rows.Count - 1
                                    If Dgl3.AgSelectedValue(Col3Item, I) = AgL.XNull(.Rows(J)("Item")) Then
                                        If AgL.XNull(.Rows(J)("SysEdition")) <> "" Then
                                            ColName = FunGetColumnName(AgL.XNull(.Rows(J)("SysEdition")), ClsMain.Recurrance.HalfYearly)
                                            XColName = "X" & ColName
                                            QtyColName = FunGetQtyColName(ColName)
                                            XQtyColName = "X" & QtyColName
                                            Dgl3.Item(ColName, I).Value = AgL.XNull(.Rows(J)("V_Date"))
                                            Dgl3.Item(XColName, I).Value = AgL.XNull(.Rows(J)("V_Date"))
                                            Dgl3.Item(QtyColName, I).Value = AgL.VNull(.Rows(J)("Qty"))
                                            Dgl3.Item(XQtyColName, I).Value = AgL.VNull(.Rows(J)("Qty"))
                                        End If
                                        K = K + 1
                                    End If
                                Next
                            End If
                        Next I
                    End If
                End With

                mQry = "SELECT S.General AS Item, V1.V_Date, V1.SysEdition, S.Qty As SubscribedQty, V1.Qty " & _
                        " FROM Lib_Subscription S " & _
                        " Left Join " & _
                        " 	(SELECT Cd.Item, Cd.V_Date, Cd.SysEdition, IsNull(Cd.Qty,0) As Qty   " & _
                        " 	FROM PurchChallanDetail Cd " & _
                        " 	LEFT JOIN Lib_Generals G ON Cd.Item = G.Code " & _
                        " 	WHERE Cd.DocId = '" & mSearchCode & "'  " & _
                        " 	AND G.Recurrance = '" & ClsMain.Recurrance.Annually & "' ) " & _
                        " AS V1 ON S.General = V1.Item " & _
                        " WHERE (Year('" & LblV_Date.Tag & "') BETWEEN Year(S.FromDate) AND Year(S.ToDate) Or S.ToDate Is NULL) " & _
                        " AND S.Recurrance = '" & ClsMain.Recurrance.Annually & "' " & _
                        " Order By S.General "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl4.RowCount = 1
                    Dgl4.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            Dgl4.Rows.Add()
                            Dgl4.Item(ColSNo, I).Value = Dgl4.Rows.Count
                            Dgl4.AgSelectedValue(Col4Item, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl4.Item(Col4ReceiveDate, I).Value = AgL.XNull(.Rows(I)("V_Date"))
                            Dgl4.Item(Col4XReceiveDate, I).Value = AgL.XNull(.Rows(I)("V_Date"))
                            Dgl4.Item(Col4Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl4.Item(Col4XQty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl4.Item(Col4SubscribedQty, I).Value = AgL.VNull(.Rows(I)("SubscribedQty"))
                        Next I
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
            If Strings.Mid(Topctrl1.Tag, 2, 1) = "E" Then Topctrl1.FButtonClick(1)
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = ""
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
        Dgl3.RowCount = 1 : Dgl3.Rows.Clear()
        Dgl4.RowCount = 1 : Dgl4.Rows.Clear()
        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.CurrentCell.ColumnIndex

                'Case Col1PurjaDocId
                '    Call IniPurjaHelp(False, TxtJobWorker.AgSelectedValue)

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl2.RowsAdded, Dgl3.RowsAdded, Dgl4.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
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
        TxtDocId.Validating, TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_Date.Validating, TxtV_No.Validating

        Dim DtTemp As DataTable = Nothing
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
                        End If
                    End If

                Case TxtV_Date.Name
                    ProcInitializeDate()
                    If FunGetSearchCode(LblV_Date.Tag) = "" Then
                        If Strings.Mid(Topctrl1.Tag, 1, 1) = "A" Then
                            Topctrl1.FButtonClick(0, True)
                            ProcInitializeForm()
                        Else
                            MsgBox("Permission Denied...!", MsgBoxStyle.Information)
                            MoveRec()
                        End If
                    Else
                        FindMove(FunGetSearchCode(LblV_Date.Tag))
                        'Topctrl1.FButtonClick(1, True)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bFlag As Boolean = False
        Dim bStudentCode$ = ""
        Try

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type, LblV_Type.Text) Then Exit Function
            If AgL.RequiredField(TxtV_Date, LblV_Date.Text) Then Exit Function
            'If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function

            AgCL.AgBlankNothingCells(Dgl1)


            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            With Dgl1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1BiMonth1, I).Value <> "" And Val(.Item(Col1QtyBiMonth1, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1QtyBiMonth1, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col1BiMonth1, I).Value = "" And Val(.Item(Col1QtyBiMonth1, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1BiMonth1, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col1BiMonth2, I).Value <> "" And Val(.Item(Col1QtyBiMonth2, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1QtyBiMonth2, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col1BiMonth2, I).Value = "" And Val(.Item(Col1QtyBiMonth2, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1BiMonth2, I) : .Focus()
                        Exit Function
                    End If


                    If .Item(Col1BiMonth3, I).Value <> "" And Val(.Item(Col1QtyBiMonth3, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1QtyBiMonth3, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col1BiMonth3, I).Value = "" And Val(.Item(Col1QtyBiMonth3, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1BiMonth3, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col1BiMonth4, I).Value <> "" And Val(.Item(Col1QtyBiMonth4, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1QtyBiMonth4, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col1BiMonth4, I).Value = "" And Val(.Item(Col1QtyBiMonth4, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1BiMonth4, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col1BiMonth5, I).Value <> "" And Val(.Item(Col1QtyBiMonth5, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1QtyBiMonth5, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col1BiMonth5, I).Value = "" And Val(.Item(Col1QtyBiMonth5, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1BiMonth5, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col1BiMonth6, I).Value <> "" And Val(.Item(Col1QtyBiMonth6, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1QtyBiMonth6, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col1BiMonth6, I).Value = "" And Val(.Item(Col1QtyBiMonth6, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col1BiMonth6, I) : .Focus()
                        Exit Function
                    End If
                Next
            End With


            With Dgl2
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2Quarter1, I).Value <> "" And Val(.Item(Col2QtyQuarter1, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2QtyQuarter1, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Quarter1, I).Value = "" And Val(.Item(Col2QtyQuarter1, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2Quarter1, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Quarter2, I).Value <> "" And Val(.Item(Col2QtyQuarter2, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2QtyQuarter2, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Quarter2, I).Value = "" And Val(.Item(Col2QtyQuarter2, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2Quarter2, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Quarter3, I).Value <> "" And Val(.Item(Col2QtyQuarter3, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2QtyQuarter3, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Quarter3, I).Value = "" And Val(.Item(Col2QtyQuarter3, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2Quarter3, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Quarter4, I).Value <> "" And Val(.Item(Col2QtyQuarter4, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2QtyQuarter4, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col2Quarter4, I).Value = "" And Val(.Item(Col2QtyQuarter4, I).Value) <> 0 Then
                        MsgBox("Date Is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col2Quarter4, I) : .Focus()
                        Exit Function
                    End If
                Next
            End With

            With Dgl3
                For I = 0 To .Rows.Count - 1
                    If .Item(Col3HalfYear1, I).Value <> "" And Val(.Item(Col3QtyHalfYear1, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col3QtyHalfYear1, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col3HalfYear1, I).Value = "" And Val(.Item(Col3QtyHalfYear1, I).Value) <> 0 Then
                        MsgBox("Date is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col3HalfYear1, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col3HalfYear2, I).Value <> "" And Val(.Item(Col3QtyHalfYear2, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col3QtyHalfYear2, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col3HalfYear2, I).Value = "" And Val(.Item(Col3QtyHalfYear2, I).Value) <> 0 Then
                        MsgBox("Date is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col3HalfYear2, I) : .Focus()
                        Exit Function
                    End If
                Next
            End With

            With Dgl4
                For I = 0 To .Rows.Count - 1
                    If .Item(Col4ReceiveDate, I).Value <> "" And Val(.Item(Col4Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col4Qty, I) : .Focus()
                        Exit Function
                    End If

                    If .Item(Col4ReceiveDate, I).Value = "" And Val(.Item(Col4Qty, I).Value) <> 0 Then
                        MsgBox("Date is Blank At Row No " & .Item(ColSNo, I).Value & "  ", MsgBoxStyle.Information)
                        .CurrentCell = .Item(Col4ReceiveDate, I) : .Focus()
                        Exit Function
                    End If
                Next
            End With

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(LblV_Date.Tag), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
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

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            TxtV_Type.Enabled = True
        End If


        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled = True Then TxtV_Type.Focus()
        End If

        If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And LblV_Date.Tag.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
            mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(LblV_Date.Tag), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            TxtDocId.Text = mSearchCode
            TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
            LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
        End If

    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub ProcInitializeForm()
        'If TxtV_Date.Text <> "" Then
        '    TxtV_Date.Text = CDate(TxtV_Date.Text).ToString("yyyy")
        '    LblV_Date.Tag = "01/Jan/" & TxtV_Date.Text
        'End If
        Call ProcFillItems(Dgl1, Col1Item, Col1SubscribedQty, ClsMain.Recurrance.Bimonthly)
        Call ProcFillItems(Dgl2, Col2Item, Col2SubscribedQty, ClsMain.Recurrance.Quarterly)
        Call ProcFillItems(Dgl3, Col3Item, Col3SubscribedQty, ClsMain.Recurrance.HalfYearly)
        Call ProcFillItems(Dgl4, Col4Item, Col4SubscribedQty, ClsMain.Recurrance.Annually)
    End Sub

    Private Sub ProcFillItems(ByVal DGL As AgControls.AgDataGrid, ByVal ColIndexItem As String, ByVal ColIndexSubscribedQty As String, ByVal Recurrance As String)
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer
        Try
            mQry = "SELECT S.General AS Item, S.Qty As SubscribedQty " & _
                    " FROM Lib_Subscription S " & _
                    " WHERE (Year('" & LblV_Date.Tag & "') BETWEEN Year(S.FromDate) AND Year(S.ToDate) " & _
                    " Or S.ToDate Is Null) " & _
                    " AND S.Recurrance = '" & Recurrance & "' "

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL.RowCount = 1
                DGL.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        DGL.Rows.Add()
                        DGL.Item(ColSNo, I).Value = DGL.Rows.Count
                        DGL.AgSelectedValue(ColIndexItem, I) = AgL.XNull(.Rows(I)("Item"))
                        DGL.Item(ColIndexSubscribedQty, I).Value = AgL.XNull(.Rows(I)("SubscribedQty"))
                    Next I
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FunGetReceiptDate(ByVal ColName As String) As String
        Dim ReceiptDate$ = ""
        Try
            ReceiptDate = ColName + "/" + TxtV_Date.Text
            FunGetReceiptDate = ReceiptDate
        Catch ex As Exception
            FunGetReceiptDate = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function FunGetEdition(ByVal ColName As String, ByVal Recurrance As String) As String
        Dim Edition$ = ""
        Try
            Select Case Recurrance
                Case ClsMain.Recurrance.Bimonthly
                    Select Case ColName
                        Case Col1BiMonth1
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.BiMonth1

                        Case Col1BiMonth2
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.BiMonth2

                        Case Col1BiMonth3
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.BiMonth3

                        Case Col1BiMonth4
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.BiMonth4

                        Case Col1BiMonth5
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.BiMonth5

                        Case Col1BiMonth6
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.BiMonth6
                    End Select

                Case ClsMain.Recurrance.Quarterly
                    Select Case ColName
                        Case Col2Quarter1
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.Quarter1

                        Case Col2Quarter2
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.Quarter2

                        Case Col2Quarter3
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.Quarter3

                        Case Col2Quarter4
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.Quarter4
                    End Select

                Case ClsMain.Recurrance.HalfYearly
                    Select Case ColName
                        Case Col3HalfYear1
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.HalfYear1

                        Case Col3HalfYear2
                            Edition = TxtV_Date.Text + "/" + ClsMain.Temp_SysEdition.HalfYear2
                    End Select

                Case ClsMain.Recurrance.Annually
                    Edition = TxtV_Date.Text
            End Select
            FunGetEdition = Edition
        Catch ex As Exception
            FunGetEdition = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function FunGetSysEdition(ByVal ColName As String, ByVal Recurrance As String) As String
        Dim SysEdition$ = ""
        Try
            Select Case Recurrance
                Case ClsMain.Recurrance.Bimonthly
                    Select Case ColName
                        Case Col1BiMonth1
                            SysEdition = ClsMain.Temp_SysEdition.BiMonth1

                        Case Col1BiMonth2
                            SysEdition = ClsMain.Temp_SysEdition.BiMonth2

                        Case Col1BiMonth3
                            SysEdition = ClsMain.Temp_SysEdition.BiMonth3

                        Case Col1BiMonth4
                            SysEdition = ClsMain.Temp_SysEdition.BiMonth4

                        Case Col1BiMonth5
                            SysEdition = ClsMain.Temp_SysEdition.BiMonth5

                        Case Col1BiMonth6
                            SysEdition = ClsMain.Temp_SysEdition.BiMonth6
                    End Select

                Case ClsMain.Recurrance.Quarterly
                    Select Case ColName
                        Case Col2Quarter1
                            SysEdition = ClsMain.Temp_SysEdition.Quarter1

                        Case Col2Quarter2
                            SysEdition = ClsMain.Temp_SysEdition.Quarter2

                        Case Col2Quarter3
                            SysEdition = ClsMain.Temp_SysEdition.Quarter3

                        Case Col2Quarter4
                            SysEdition = ClsMain.Temp_SysEdition.Quarter4
                    End Select

                Case ClsMain.Recurrance.HalfYearly
                    Select Case ColName
                        Case Col3HalfYear1
                            SysEdition = ClsMain.Temp_SysEdition.HalfYear1

                        Case Col3HalfYear2
                            SysEdition = ClsMain.Temp_SysEdition.HalfYear2
                    End Select

                Case ClsMain.Recurrance.Annually
                    SysEdition = TxtV_Date.Text

            End Select
            FunGetSysEdition = SysEdition
        Catch ex As Exception
            FunGetSysEdition = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function FunGetColumnName(ByVal SysEdition As String, ByVal Recurrance As String) As String
        Dim ColumnName$ = ""
        Try
            Select Case Recurrance
                Case ClsMain.Recurrance.Bimonthly
                    Select Case SysEdition
                        Case ClsMain.Temp_SysEdition.BiMonth1
                            ColumnName = Col1BiMonth1

                        Case ClsMain.Temp_SysEdition.BiMonth2
                            ColumnName = Col1BiMonth2

                        Case ClsMain.Temp_SysEdition.BiMonth3
                            ColumnName = Col1BiMonth3

                        Case ClsMain.Temp_SysEdition.BiMonth4
                            ColumnName = Col1BiMonth4

                        Case ClsMain.Temp_SysEdition.BiMonth5
                            ColumnName = Col1BiMonth5

                        Case ClsMain.Temp_SysEdition.BiMonth6
                            ColumnName = Col1BiMonth6
                    End Select


                Case ClsMain.Recurrance.Quarterly
                    Select Case SysEdition
                        Case ClsMain.Temp_SysEdition.Quarter1
                            ColumnName = Col2Quarter1

                        Case ClsMain.Temp_SysEdition.Quarter2
                            ColumnName = Col2Quarter2

                        Case ClsMain.Temp_SysEdition.Quarter3
                            ColumnName = Col2Quarter3

                        Case ClsMain.Temp_SysEdition.Quarter4
                            ColumnName = Col2Quarter4
                    End Select

                Case ClsMain.Recurrance.HalfYearly
                    Select Case SysEdition
                        Case ClsMain.Temp_SysEdition.HalfYear1
                            ColumnName = Col3HalfYear1

                        Case ClsMain.Temp_SysEdition.HalfYear2
                            ColumnName = Col3HalfYear2
                    End Select
            End Select
            FunGetColumnName = ColumnName
        Catch ex As Exception
            FunGetColumnName = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Call Topctrl_tbSave()
    End Sub

    Private Function FunGetSearchCode(ByVal VDate As String) As String
        Dim bSearchCode$ = ""
        Try
            mQry = "SELECT C.DocID " & _
                    " FROM PurchChallan C " & _
                    " LEFT JOIN Voucher_Type Vt ON C.V_Type = Vt.V_Type " & _
                    " WHERE C.V_Date = '" & VDate & "' " & _
                    " And Vt.NCat = '" & ClsMain.Temp_NCat.GeneralPeriodicalYearlyRecd & "' "
            bSearchCode = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar
            FunGetSearchCode = bSearchCode
        Catch ex As Exception
            FunGetSearchCode = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Public Sub FindMove(ByVal bDocId As String)
        Dim Cnt As Integer = 0
        Try
            If bDocId <> "" Then
                AgL.PubSearchRow = bDocId
                If AgL.PubMoveRecApplicable Then
                    AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                    BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                End If
                Call MoveRec()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcInitializeDate()
        Try
            If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
            If TxtV_Date.Text <> "" Then
                TxtV_Date.Text = CDate(TxtV_Date.Text).ToString("yyyy")
                LblV_Date.Tag = "01/Apr/" & TxtV_Date.Text

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcPostStock(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
        Try
            mQry = "DELETE From Stock Where DocId = '" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            mQry = "INSERT INTO Stock(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, Item, Qty_Rec, Unit, Edition) " & _
                    " SELECT Cd.DocId, Cd.Sr, C.V_Type, C.V_Prefix, Cd.V_Date, C.V_No, C.Div_Code, C.Site_Code, Cd.Item, Cd.Qty, Cd.Unit, Cd.Edition " & _
                    " FROM PurchChallan C With (NoLock)" & _
                    " LEFT JOIN PurchChallanDetail Cd  With (NoLock) ON C.DocID = Cd.DocId " & _
                    " WHERE Cd.DocId = '" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FunGetQtyColName(ByVal ColName As String)
        Try
            FunGetQtyColName = "Qty" & ColName
        Catch ex As Exception
            FunGetQtyColName = ""
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub ProcSetDispIndex()
        Try
            With Dgl1
                .Columns(Col1QtyBiMonth1).DisplayIndex = .Columns(Col1BiMonth1).DisplayIndex + 1
                .Columns(Col1QtyBiMonth2).DisplayIndex = .Columns(Col1BiMonth2).DisplayIndex + 1
                .Columns(Col1QtyBiMonth3).DisplayIndex = .Columns(Col1BiMonth3).DisplayIndex + 1
                .Columns(Col1QtyBiMonth4).DisplayIndex = .Columns(Col1BiMonth4).DisplayIndex + 1
                .Columns(Col1QtyBiMonth5).DisplayIndex = .Columns(Col1BiMonth5).DisplayIndex + 1
                .Columns(Col1QtyBiMonth6).DisplayIndex = .Columns(Col1BiMonth6).DisplayIndex + 1
            End With

            With Dgl2
                .Columns(Col2QtyQuarter1).DisplayIndex = .Columns(Col2Quarter1).DisplayIndex + 1
                .Columns(Col2QtyQuarter2).DisplayIndex = .Columns(Col2Quarter2).DisplayIndex + 1
                .Columns(Col2QtyQuarter3).DisplayIndex = .Columns(Col2Quarter3).DisplayIndex + 1
                .Columns(Col2QtyQuarter4).DisplayIndex = .Columns(Col2Quarter4).DisplayIndex + 1
            End With

            With Dgl3
                .Columns(Col3QtyHalfYear1).DisplayIndex = .Columns(Col3HalfYear1).DisplayIndex + 1
                .Columns(Col3QtyHalfYear2).DisplayIndex = .Columns(Col3HalfYear2).DisplayIndex + 1
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            With Dgl1
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col1BiMonth1
                        .Item(Col1QtyBiMonth1, mRowIndex).Value = Val(.Item(Col1SubscribedQty, mRowIndex).Value)

                    Case Col1BiMonth2
                        .Item(Col1QtyBiMonth2, mRowIndex).Value = Val(.Item(Col1SubscribedQty, mRowIndex).Value)

                    Case Col1BiMonth3
                        .Item(Col1QtyBiMonth3, mRowIndex).Value = Val(.Item(Col1SubscribedQty, mRowIndex).Value)

                    Case Col1BiMonth4
                        .Item(Col1QtyBiMonth4, mRowIndex).Value = Val(.Item(Col1SubscribedQty, mRowIndex).Value)

                    Case Col1BiMonth5
                        .Item(Col1QtyBiMonth5, mRowIndex).Value = Val(.Item(Col1SubscribedQty, mRowIndex).Value)

                    Case Col1BiMonth6
                        .Item(Col1QtyBiMonth6, mRowIndex).Value = Val(.Item(Col1SubscribedQty, mRowIndex).Value)
                End Select
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl2.CurrentCell.RowIndex
            mColumnIndex = Dgl2.CurrentCell.ColumnIndex

            If Dgl2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl2.Item(mColumnIndex, mRowIndex).Value = ""
            With Dgl2
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col2Quarter1
                        .Item(Col2QtyQuarter1, mRowIndex).Value = Val(.Item(Col2SubscribedQty, mRowIndex).Value)

                    Case Col2Quarter2
                        .Item(Col2QtyQuarter2, mRowIndex).Value = Val(.Item(Col2SubscribedQty, mRowIndex).Value)

                    Case Col2Quarter3
                        .Item(Col2QtyQuarter3, mRowIndex).Value = Val(.Item(Col2SubscribedQty, mRowIndex).Value)

                    Case Col2Quarter4
                        .Item(Col2QtyQuarter4, mRowIndex).Value = Val(.Item(Col2SubscribedQty, mRowIndex).Value)
                End Select
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Dgl3_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl3.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl3.CurrentCell.RowIndex
            mColumnIndex = Dgl3.CurrentCell.ColumnIndex

            If Dgl3.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl3.Item(mColumnIndex, mRowIndex).Value = ""
            With Dgl3
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col3HalfYear1
                        .Item(Col3QtyHalfYear1, mRowIndex).Value = Val(.Item(Col3SubscribedQty, mRowIndex).Value)

                    Case Col3HalfYear2
                        .Item(Col3QtyHalfYear2, mRowIndex).Value = Val(.Item(Col3SubscribedQty, mRowIndex).Value)
                End Select
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl4_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl4.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl4.CurrentCell.RowIndex
            mColumnIndex = Dgl4.CurrentCell.ColumnIndex

            If Dgl4.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl4.Item(mColumnIndex, mRowIndex).Value = ""
            With Dgl4
                Select Case .Columns(.CurrentCell.ColumnIndex).Name
                    Case Col4ReceiveDate
                        .Item(Col4Qty, mRowIndex).Value = Val(.Item(Col4SubscribedQty, mRowIndex).Value)
                End Select
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class