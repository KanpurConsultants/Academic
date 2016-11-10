Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmissueReceive
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = "", mNCatStr As String = "", mIssueReceiveStr As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1IssueReceive As Byte = 1
    Private Const Col1Item As Byte = 2
    Private Const Col1ItemDescription As Byte = 3
    Private Const Col1Batch As Byte = 4
    Private Const Col1ItemNature1 As Byte = 5
    Private Const Col1ItemNature2 As Byte = 6
    Private Const Col1Godown As Byte = 7
    Private Const Col1Qty As Byte = 8
    Private Const Col1Rate As Byte = 9
    Private Const Col1Amount As Byte = 10

    Private Const OpeningStockEntry As Byte = 1
    Private Const ItemReceiveEntry As Byte = 2
    Private Const ItemIssueEntry As Byte = 3
    Dim FormType As Byte = 0

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
        DGL1.Height = Pnl1.Height
        DGL1.Width = Pnl1.Width
        DGL1.Top = Pnl1.Top
        DGL1.Left = Pnl1.Left
        Pnl1.Visible = False
        Controls.Add(DGL1)
        DGL1.Visible = True
        DGL1.BringToFront()
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgListColumn(DGL1, "Issue,Receive", "Dgl1IssueReceive", 100, "Issue,Receive", "Issue/Receive", False, True)
            .AddAgTextColumn(DGL1, "DGL1Item", 200, 50, "Item", True, False, False)
            .AddAgTextColumn(DGL1, "DGL1Item", 180, 255, "Item Description", True, False, False)

            .AddAgTextColumn(DGL1, "DGL1Batch", 80, 20, ClsVar.Item_Batch_Description, True, False, False)

            If DtStore_Enviro.Rows.Count > 0 Then
                If AgL.VNull(DtStore_Enviro.Rows(0)("IsItemNature")) Then
                    .AddAgTextColumn(DGL1, "DGL1ItemNature1", 80, 20, ClsVar.Item_Nature1_Description, True, False, False)
                    .AddAgTextColumn(DGL1, "DGL1ItemNature2", 80, 20, ClsVar.Item_Nature2_Description, True, False, False)
                Else
                    .AddAgTextColumn(DGL1, "DGL1ItemNature1", 80, 20, ClsVar.Item_Nature1_Description, False, False, False)
                    .AddAgTextColumn(DGL1, "DGL1ItemNature2", 80, 20, ClsVar.Item_Nature2_Description, False, False, False)
                End If
            End If

            .AddAgTextColumn(DGL1, "DGL1Godown", 100, 20, "Godown", True, True, False)
            .AddAgNumberColumn(DGL1, "DGL1Qty", 60, 8, 3, False, "Qty", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Rate", 80, 8, 3, False, "Rate", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 80, 8, 2, False, "Amount", True, True, True)
        End With
        DGL1.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom)
        AgL.FSetSNo(DGL1, Col_SNo)
        DGL1.TabIndex = Pnl1.TabIndex
        DGL1.ColumnHeadersDefaultCellStyle.Font = New Font(New FontFamily("Arial"), 9)
        DGL1.DefaultCellStyle.Font = New Font(New FontFamily("Arial"), 8)
        DGL1.ColumnHeadersHeight = 40
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
            If AgL.StrCmp(Me.Text, "Item Receive Entry") Then
                FormType = ItemReceiveEntry
                mNCatStr = "" & AgL.Chk_Text(ClsVar.NCat_StoreReceive) & ""
                mIssueReceiveStr = "Receive"
                LblDepartment.Text = "Department (Recv.)"
                LblDepartment2.Text = "Department (Issue)"
                LblIssueReceiveDetail.Text = "Receive Detail"
                lblFromGodown.Text = "Godown (Recv.)"
                lblToGodown.Text = "Godown (Issue)"

            ElseIf AgL.StrCmp(Me.Text, "Item Issue Entry") Then
                FormType = ItemIssueEntry
                mNCatStr = "" & AgL.Chk_Text(ClsVar.NCat_StoreIssue) & ""
                mIssueReceiveStr = "Issue"
                LblDepartment.Text = "Department (Issue)"
                LblDepartment2.Text = "Department (Recv.)"
                LblIssueReceiveDetail.Text = "Issue Detail"
                lblFromGodown.Text = "Godown (Issue)"
                lblToGodown.Text = "Godown (Recv.)"

            ElseIf AgL.StrCmp(Me.Text, "Opening Stock Entry") Then
                FormType = OpeningStockEntry
                mNCatStr = "" & AgL.Chk_Text(ClsVar.NCat_StoreOpening) & ""
                mIssueReceiveStr = "Receive"
                LblDepartment.Text = "Department"
                LblIssueReceiveDetail.Text = "Opening Stock Detail"

                TxtDepartment2.Visible = False : LblDepartment2.Visible = False
                TxtFrmGodown.Visible = False : lblFromGodown.Visible = False
                TxtToGodown.Visible = False : lblToGodown.Visible = False
                TxtAcCode.Visible = False : LblAcCode.Visible = False : LblAcCodeReq.Visible = False
            End If

            AgL.WinSetting(Me, 650, 950, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            FIniMaster()
            Ini_List()
            DispText(False)
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "Select SSA.DocId As SearchCode " & _
                " From Store_StockAdjustment SSA " & _
                " Left Join Voucher_Type Vt On Ssa.V_Type = Vt.V_Type " & _
                " Where 1=1 " & AgL.CondStrFinancialYear("SSA.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                " And " & AgL.PubSiteCondition("SSA.Site_Code", AgL.PubSiteCode) & " " & _
                " And Vt.NCat in (" & mNCatStr & ") "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
                " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Vt.V_Type As Code, Vt.Description As [Voucher Type], Vt.NCat " & _
                " From Voucher_Type Vt " & _
                " Where Vt.NCat in (" & mNCatStr & ") " & _
                " Order By Vt.Description"
        TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Sg.SubCode As Code, Sg.Name As Name, City.CityName, Sg.Add1, Sg.Add2, Sg.Add3, Sg.Nature " & _
                " From ViewSubGroup Sg " & _
                " Left Join City On Sg.CityCode = City.CityCode " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                " And (Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryCreditors) & " Or " & _
                "       Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenSundryDebtors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryDebtors) & ") " & _
                " Order By SG.Name "
        TxtAcCode.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code As Code,  Description As Department " & _
                " From Sch_Department " & _
                " Where 1=1 " & _
                " Order By Description"
        TxtDepartment.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
        TxtDepartment2.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code As Code,  ManualCode Name " & _
                " From Store_Godown " & _
                " Where 1=1 " & _
                " Order By ManualCode"
        DGL1.AgHelpDataSet(Col1Godown) = AgL.FillData(mQry, AgL.GCn)
        TxtFrmGodown.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
        TxtToGodown.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        Call IniLineHelp()
    End Sub



    Private Sub IniLineHelp(Optional ByVal All_Records As Boolean = True)
        Dim mCondStr As String = "", mView1 As String = ""

        'mQry = "Select code As Code, Description, PurchaseRate " & _
        '      " From store_Item " & _
        '      " Order By Description "

        mQry = "Select Store_Item.code As Code, Store_Item.Description As Name, Store_Item.PurchaseRate,s.Stock,store_unit.Description as Unit   " & _
        " From Store_Item LEFT JOIN  (SELECT item,sum(isnull(qty_rec,0))-sum(isnull(qty_iss,0)) AS Stock   FROM Store_Stock GROUP BY item) s ON Store_Item.Code=s.item    left join store_unit on Store_Item.Unit=store_unit.code Where 1=1  and  Store_Item.MasterType = '" & ClsMain.ItemType.Store & "' " & _
       " Order By Store_Item.Description "


        DGL1.AgHelpDataSet(Col1Item) = AgL.FillData(mQry, AgL.GCn)

        Call IniBatchHelp(True)
        Call IniItemNature1Help(True)
        Call IniItemNature2Help(True)
    End Sub

    Private Sub IniBatchHelp(Optional ByVal All_Records As Boolean = True)
        Dim bIsMasterHelp As Boolean = False

        If FormType = ItemReceiveEntry Or FormType = OpeningStockEntry Then
            bIsMasterHelp = True
        Else
            bIsMasterHelp = False
        End If

        If All_Records = True Then
            mQry = "Select DISTINCT Item+Batchno As Code, Batchno " & _
                   " From store_Stock where batchno is not null " & _
                   " Order By Batchno "
        Else
            'mQry = "Select DISTINCT Item+Batchno As Code, Batchno " & _
            '      " From store_Stock" & _
            '      " Where Item = '" & DGL1.AgSelectedValue(Col1Item, DGL1.CurrentCell.RowIndex) & "' and batchno is not null " & _
            '      " Order By Batchno "

            mQry = "Select DISTINCT store_Stock.Item+store_Stock.Batchno As Code, store_Stock.Batchno ,s.Stock  From store_Stock  " & _
                 " LEFT JOIN (SELECT item,Batchno,sum(isnull(qty_rec,0))-sum(isnull(qty_iss,0)) AS Stock FROM Store_Stock GROUP BY item,Batchno) s ON (store_Stock.batchno=s.batchno and store_Stock.item=s.item  )" & _
                 " Where store_Stock.Item = '" & DGL1.AgSelectedValue(Col1Item, DGL1.CurrentCell.RowIndex) & "' and  store_Stock.batchno is not null and s.Stock >0 " & _
                 " Order By store_Stock.Batchno "

        End If
        DGL1.AgHelpDataSet(Col1Batch, , , , , bIsMasterHelp) = AgL.FillData(mQry, AgL.GCn)


    End Sub

    Private Sub IniItemNature1Help(Optional ByVal All_Records As Boolean = True)
        Dim mCondStr As String = "", mView1 As String = ""

        If Not All_Records Then
            mCondStr = " And Item = '" & DGL1.AgSelectedValue(Col1Item, DGL1.CurrentCell.RowIndex) & "' "
        End If

        mQry = "Select Code, Description, Item " & _
                " From Store_Item_Nature1 " & _
                " Where 1=1 " & mCondStr & _
                " Order By Description "
        DGL1.AgHelpDataSet(Col1ItemNature1, 1) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub IniItemNature2Help(Optional ByVal All_Records As Boolean = True)
        Dim mCondStr As String = "", mView1 As String = ""

        If Not All_Records Then
            mCondStr = " And Item = '" & DGL1.AgSelectedValue(Col1Item, DGL1.CurrentCell.RowIndex) & "' "
        End If

        mQry = "Select Code, Description, Item " & _
                " From Store_Item_Nature2 " & _
                " Where 1=1 " & mCondStr & _
                " Order By Description "
        DGL1.AgHelpDataSet(Col1ItemNature2) = AgL.FillData(mQry, AgL.GCn)
    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode

        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            TxtV_Type.Enabled = True
        End If

        If TxtV_Type.Enabled Then TxtV_Type.Focus() Else TxtV_Date.Focus()
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

                    mQry = "Delete From Store_StockAdjustmentStockHeader Where DocId = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Delete From Store_Stock  Where DocId = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Delete From Store_StockHeader  Where DocId = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Delete From Store_StockAdjustment Where DocId = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

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
        TxtV_Date.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = "Select  ssa.DocId As SearchCode,  SiteMast.Name As [Site/Branch Name],  Convert(nVarChar,SSA.V_Date,3) As [Vr. Date], " & _
                                " SSA.V_No As [Voucher No.], SSA.ReferenceNo As [" & LblRefNo.Text & "],  Vt.Description As [Voucher Type]  " & _
                                " From  Store_StockAdjustment SSA " & _
                                " Left Join SiteMast  On SiteMast.Code = ssa.Site_Code " & _
                                " Left Join Voucher_Type Vt On Vt.V_Type = ssa.V_Type " & _
                                " Where 1=1 " & AgL.CondStrFinancialYear("SSA.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                                " And " & AgL.PubSiteCondition("SSA.Site_Code", AgL.PubSiteCode) & " " & _
                                " And Vt.NCat in (" & mNCatStr & ") "

            AgL.PubFindQryOrdBy = "[SearchCode]"


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

    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, mSr As Integer = 0
        Dim mTrans As Boolean = False
        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Store_StockAdjustment " & _
                        " ( DocId, Div_Code, Site_Code, V_Type, V_Prefix, V_No, V_Date, " & _
                        " AcCode, Amount, Remark, Department, Department2, " & _
                        " PreparedBy, U_EntDt, U_AE ,ReferenceNo,Godown1,Godown2) " & _
                        " VALUES ( " & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(AgL.PubDivCode) & ", " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ", " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtAcCode.AgSelectedValue) & ", " & Val(TxtAmount.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & AgL.Chk_Text(TxtDepartment.AgSelectedValue) & ", " & AgL.Chk_Text(TxtDepartment2.AgSelectedValue) & "," & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A'," & AgL.Chk_Text(TxtRefNo.Text) & ", " & AgL.Chk_Text(TxtFrmGodown.AgSelectedValue) & ", " & AgL.Chk_Text(TxtToGodown.AgSelectedValue) & ")"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "INSERT INTO Store_StockHeader (DocId, PreparedBy, U_EntDt, U_AE) " & _
                        " Values (" & _
                        " '" & mSearchCode & "', " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Store_StockAdjustment " & _
                        " SET " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " AcCode = " & AgL.Chk_Text(TxtAcCode.AgSelectedValue) & ", " & _
                        " Amount = " & Val(TxtAmount.Text) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " Department = " & AgL.Chk_Text(TxtDepartment.AgSelectedValue) & "," & _
                        " Department2 = " & AgL.Chk_Text(TxtDepartment2.AgSelectedValue) & "," & _
                        " Godown1 = " & AgL.Chk_Text(TxtFrmGodown.AgSelectedValue) & "," & _
                        " Godown2 = " & AgL.Chk_Text(TxtToGodown.AgSelectedValue) & "," & _
                        " U_AE = 'E', " & _
                        " Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ", " & _
                        " ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                        " ReferenceNo=" & AgL.Chk_Text(TxtRefNo.Text) & " " & _
                        "Where DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "Update Store_StockHeader Set " & _
                        " ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                        " Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ", " & _
                        " U_AE = 'E' " & _
                        " Where DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Store_StockAdjustmentStockHeader Where DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "Delete From Store_Stock Where Docid = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                mSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        mSr = mSr + 1

                        mQry = "INSERT INTO Store_Stock " & _
                                " ( " & _
                                " DocId, Sr, Div_Code, Site_Code, V_Type, " & _
                                " V_Prefix, V_No, V_Date, IssueReceive, Item,ItemDescription, Item_Nature1, " & _
                                " Item_Nature2, BatchNo, " & IIf(.Item(Col1IssueReceive, I).Value = "Issue", "Qty_Iss", "Qty_Rec") & ", Rate, Amount, " & _
                                " Addition,Deduction,NetAmount,Addition_H,Deduction_H, LandedAmount, Godown " & _
                                " ) " & _
                                " VALUES " & _
                                " ( " & _
                                " " & AgL.Chk_Text(mSearchCode) & "," & mSr & "," & AgL.Chk_Text(AgL.PubDivCode) & "," & AgL.Chk_Text(AgL.PubSiteCode) & "," & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                                " " & AgL.Chk_Text(LblPrefix.Text) & "," & AgL.Chk_Text(TxtV_No.Text) & "," & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(.Item(Col1IssueReceive, I).Value) & "," & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & "," & AgL.Chk_Text(.Item(Col1ItemDescription, I).Value) & ", " & AgL.Chk_Text(.AgSelectedValue(Col1ItemNature1, I)) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1ItemNature2, I)) & "," & AgL.Chk_Text(.Item(Col1Batch, I).Value) & "," & Val(.Item(Col1Qty, I).Value) & "," & Val(.Item(Col1Rate, I).Value) & "," & Val(.Item(Col1Amount, I).Value) & ", " & _
                                " 0, 0," & Val(.Item(Col1Amount, I).Value) & ", 0, 0, 0, " & AgL.Chk_Text(.AgSelectedValue(Col1Godown, I)) & " " & _
                                " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

            mQry = "INSERT INTO Store_StockAdjustmentStockHeader (DocId) Values ('" & mSearchCode & "') "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)

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

                Call IniLineHelp()

                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select SSA.*, Vt.NCat " & _
                        " From Store_StockAdjustment SSA " & _
                        " Left Join Voucher_Type Vt On SSA.V_Type = Vt.V_Type " & _
                        " Where SSA.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = AgL.XNull(.Rows(0)("DocId"))
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Date.Text = AgL.RetDate(AgL.XNull(.Rows(0)("V_Date")))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(0 + 2, "0"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCat"))
                        TxtRefNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                        LblRefNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))

                        TxtDepartment.AgSelectedValue = AgL.XNull(.Rows(0)("Department"))
                        TxtDepartment2.AgSelectedValue = AgL.XNull(.Rows(0)("Department2"))
                        TxtFrmGodown.AgSelectedValue = AgL.XNull(.Rows(0)("Godown1"))
                        TxtToGodown.AgSelectedValue = AgL.XNull(.Rows(0)("Godown2"))

                        TxtAcCode.AgSelectedValue = AgL.XNull(.Rows(0)("AcCode"))
                        TxtAmount.Text = Format(AgL.VNull(.Rows(0)("Amount")), "0.00")
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select ss.* " & _
                        " From Store_Stock SS " & _
                        " Where SS.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1IssueReceive, I) = AgL.XNull(.Rows(I)("IssueReceive"))
                            DGL1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                            DGL1.Item(Col1ItemDescription, I).Value = AgL.XNull(.Rows(I)("ItemDescription"))

                            DGL1.AgSelectedValue(Col1Godown, I) = AgL.XNull(.Rows(I)("Godown"))
                            DGL1.Item(Col1Batch, I).Value = AgL.XNull(.Rows(I)("BatchNo"))
                            DGL1.AgSelectedValue(Col1ItemNature1, I) = AgL.XNull(.Rows(I)("Item_Nature1"))
                            DGL1.AgSelectedValue(Col1ItemNature2, I) = AgL.XNull(.Rows(I)("Item_Nature2"))

                            If AgL.XNull(.Rows(I)("IssueReceive")) = "Issue" Then
                                DGL1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty_Iss"))
                            ElseIf AgL.XNull(.Rows(I)("IssueReceive")) = "Receive" Then
                                DGL1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty_Rec"))
                            End If

                            DGL1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.".PadRight(2 + 2, "0"))
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
            Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes()
        mSearchCode = "" : LblPrefix.Text = ""

        LblV_Type.Tag = ""

        If FormType = OpeningStockEntry Then
            TxtV_Date.Text = AgL.PubStartDate
        End If

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtV_No.Enabled = False
        TxtSite_Code.Enabled = False
        TxtAmount.Enabled = False

        If Topctrl1.Mode = "Edit" Then
            TxtV_Type.Enabled = False
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
                Case Col1ItemNature1
                    Call IniItemNature1Help(False)

                Case Col1ItemNature2
                    Call IniItemNature2Help(False)

                Case Col1Batch
                    Call IniBatchHelp(False)
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Item
                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        DGL1.Item(Col1Batch, mRowIndex).Value = ""
                        DGL1.AgSelectedValue(Col1ItemNature1, mRowIndex) = ""
                        DGL1.AgSelectedValue(Col1ItemNature2, mRowIndex) = ""
                        DGL1.Item(Col1Rate, mRowIndex).Value = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                DGL1.Item(Col1Rate, mRowIndex).Value = AgL.VNull(.Item("PurchaseRate", .CurrentCell.RowIndex).Value)
                                DGL1.Item(Col1ItemDescription, mRowIndex).Value = DGL1.Item(Col1Item, mRowIndex).Value

                            End With
                        End If
                    End If
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
                sender.CurrentRow.Selected = True
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

        Call Calculation()
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
         TxtV_Type.Enter, TxtFrmGodown.Enter, TxtToGodown.Enter
        Try
            Select Case sender.name
                Case TxtToGodown.Name
                    TxtToGodown.AgRowFilter = " Code not in (" & AgL.Chk_Text(TxtFrmGodown.AgSelectedValue) & ")"

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_Type.Validating, TxtDocId.Validating, TxtAcCode.Validating, TxtRemark.Validating, _
        TxtAmount.Validating, TxtRefNo.Validating, TxtFrmGodown.Validating, TxtToGodown.Validating
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblV_Type.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblV_Type.Tag = AgL.XNull(.Item("NCat", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If


                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                    TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text)
            End Select

            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mSearchCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

            If Topctrl1.Mode = "Add" And TxtDocId.Text.Trim <> "" And AgL.XNull(LblRefNo.Tag).ToString.Trim = "" Then
                TxtRefNo.Text = AgL.ConvertDocId(mSearchCode)
                LblRefNo.Tag = AgL.ConvertDocId(mSearchCode)
            End If

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            'If AgL.RequiredField(TxtDepartment, LblDepartment.Text) Then Exit Function
            If AgL.RequiredField(TxtRefNo, LblRefNo.Text) Then Exit Function

            If FormType = ItemReceiveEntry Or FormType = ItemIssueEntry Then
                'If AgL.RequiredField(TxtDepartment2, LblDepartment2.Text) Then Exit Function
                If AgL.RequiredField(TxtAcCode, LblAcCode.Text) Then Exit Function

                If AgL.XNull(TxtDepartment2.Text).ToString.Trim <> "" Then
                    If AgL.StrCmp(AgL.XNull(TxtDepartment.Text).ToString.Trim, AgL.XNull(TxtDepartment2.Text).ToString.Trim) Then
                        MsgBox("Both Department Can't Be Same!...")
                        TxtDepartment2.Focus() : Exit Function
                    End If
                End If
                
            End If

            If FormType = OpeningStockEntry Then
                If CDate(TxtV_Date.Text) > CDate(AgL.PubStartDate) Then
                    MsgBox("Voucher Date Can't Be Greater Than From " & AgL.PubStartDate & "!...")
                    TxtV_Date.Focus() : Exit Function
                End If
            Else
                If AgL.RequiredField(TxtAcCode, "Party Name") Then Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1Item) Then Exit Function
            ' If AgCL.AgIsDuplicate(DGL1, "" & Col1Item & ", " & Col1Batch & "," & Col1ItemNature1 & "," & Col1ItemNature2 & "," & Col1Godown & "") Then Exit Function

            If AgL.XNull(DtStore_Enviro.Rows(0)("Godown")).ToString.Trim = "" Then MsgBox("Define Godown In Environment Settings!...") : Exit Function

            'Code By Rati on 15/06/2012
            If TxtRefNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Store_StockAdjustment H With (NoLock) " & _
                        " WHERE H.ReferenceNo = " & AgL.Chk_Text(TxtRefNo.Text) & " " & _
                        " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.DocId <> " & AgL.Chk_Text(mSearchCode) & " ") & " "
                If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
                    MsgBox(LblRefNo.Text & " Already Exists!...")
                    TxtRefNo.Focus() : Exit Function
                End If
            End If
            '***********************************

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
                If .Item(Col1Item, I).Value Is Nothing Then .Item(Col1Item, I).Value = ""
                If .Item(Col1Batch, I).Value Is Nothing Then .Item(Col1Batch, I).Value = ""
                If .Item(Col1ItemNature1, I).Value Is Nothing Then .Item(Col1ItemNature1, I).Value = ""
                If .Item(Col1ItemNature2, I).Value Is Nothing Then .Item(Col1ItemNature2, I).Value = ""
                If .Item(Col1Qty, I).Value Is Nothing Then .Item(Col1Qty, I).Value = ""
                If .Item(Col1Rate, I).Value Is Nothing Then .Item(Col1Rate, I).Value = ""
                If .Item(Col1Amount, I).Value Is Nothing Then .Item(Col1Amount, I).Value = ""
                If .Item(Col1Godown, I).Value Is Nothing Then .Item(Col1Godown, I).Value = ""

                If .Item(Col1Item, I).Value.ToString <> "" Then
                    .Item(Col1IssueReceive, I).Value = mIssueReceiveStr
                    .Item(Col1Amount, I).Value = Format(Val(.Item(Col1Qty, I).Value) * Val(.Item(Col1Rate, I).Value), "0.00")

                    If AgL.XNull(TxtFrmGodown.Text).ToString.Trim = "" Then
                        .AgSelectedValue(Col1Godown, I) = AgL.XNull(DtStore_Enviro.Rows(0)("Godown"))
                    Else
                        .AgSelectedValue(Col1Godown, I) = AgL.XNull(TxtFrmGodown.AgSelectedValue)
                    End If

                    TxtAmount.Text = Val(TxtAmount.Text) + Val(.Item(Col1Amount, I).Value)
                End If
            Next
        End With

        TxtAmount.Text = Format(Val(TxtAmount.Text), "0.00")
    End Sub

End Class
