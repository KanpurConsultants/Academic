Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmPurchase

    Dim mAglObj As AgLibrary.ClsMain

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = "", mNCatStr As String = ""


    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1PurchOrder As Byte = 1
    Protected Const Col1TempItem As Byte = 2
    Protected Const Col1Orderuid As Byte = 3
    Protected Const Col1GRNNo As Byte = 4
    Protected Const Col1GRNuid As Byte = 5
    Private Const Col1Item As Byte = 6
    Private Const Col1ItemDescription As Byte = 7
    Private Const Col1Batch As Byte = 8
    Private Const Col1ItemNature1 As Byte = 9
    Private Const Col1ItemNature2 As Byte = 10
    Private Const Col1Godown As Byte = 11
    Private Const Col1Qty As Byte = 12
    Private Const Col1Rate As Byte = 13
    Private Const Col1Amount As Byte = 14
    Private Const Col1Addition As Byte = 15
    Private Const Col1Deduction As Byte = 16
    Private Const Col1NetAmount As Byte = 17
    Private Const Col1Addition_H As Byte = 18
    Private Const Col1Deduction_H As Byte = 19
    Private Const Col1LandedAmount As Byte = 20

    'Const by akash on date 18-9-10
    Private FormType As Byte
    Private Const PurchaseEntry As Byte = 0
    Private Const PurchaseEntryAuthenticated As Byte = 1

    Public Class HelpDataSet
        Public Shared PurchOrder As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared PurchOrderItem As DataSet = Nothing
        Public Shared PurchGRN As DataSet = Nothing
        Public Shared PurchGRNItem As DataSet = Nothing
    End Class

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
    Public Property AglObj() As AgLibrary.ClsMain
        Get
            AglObj = mAglObj
        End Get
        Set(ByVal value As AgLibrary.ClsMain)
            mAglObj = value
        End Set
    End Property

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
            .AddAgTextColumn(DGL1, "Order No", 110, 0, "Order No", False, False, False)
            .AddAgTextColumn(DGL1, "Order UID", 110, 0, "Order UID", False, False, False)
            .AddAgTextColumn(DGL1, "GRN No", 110, 0, "GRN No", False, False, False)
            .AddAgTextColumn(DGL1, "GRN UID", 110, 0, "GRN UID", False, False, False)
            .AddAgTextColumn(DGL1, "Temp Item", 200, 0, "Temp Item", False, False, False)
            .AddAgTextColumn(DGL1, "DGL1Item", 150, 50, "Item", True, False, False)
            .AddAgTextColumn(DGL1, "DGL1Item", 180, 255, "Item Description", True, False, False)
            .AddAgTextColumn(DGL1, "DGL1Batch", 60, 20, ClsVar.Item_Batch_Description, True, False, False)

            If DtStore_Enviro.Rows.Count > 0 Then
                If AgL.VNull(DtStore_Enviro.Rows(0)("IsItemNature")) Then
                    .AddAgTextColumn(DGL1, "DGL1ItemNature1", 80, 20, ClsVar.Item_Nature1_Description, True, False, False)
                    .AddAgTextColumn(DGL1, "DGL1ItemNature2", 80, 20, ClsVar.Item_Nature2_Description, True, False, False)
                Else
                    .AddAgTextColumn(DGL1, "DGL1ItemNature1", 80, 20, ClsVar.Item_Nature1_Description, False, False, False)
                    .AddAgTextColumn(DGL1, "DGL1ItemNature2", 80, 20, ClsVar.Item_Nature2_Description, False, False, False)
                End If
            End If

            .AddAgTextColumn(DGL1, "DGL1Godown", 80, 20, "Godown", True, False, False)
            .AddAgNumberColumn(DGL1, "DGL1Qty", 60, 8, 3, False, "Qty", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Rate", 60, 8, 3, False, "Rate", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 80, 8, 2, False, "Amount", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Addition", 60, 8, 2, False, "Addition", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Deduction", 60, 8, 2, False, "Deduction", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1NetAmount", 80, 8, 2, False, "Net Amount", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1Addition_H", 100, 8, 2, False, "Addition_H", False, True, True)
            .AddAgNumberColumn(DGL1, "DGL1Deduction_H", 100, 8, 2, False, "Deduction_H", False, True, True)
            .AddAgNumberColumn(DGL1, "DGL1LandedAmount", 100, 8, 2, False, "Landed Amount", False, True, True)
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
            'Changed by Akash on date 18-9-10
            If AgL.StrCmp(Me.Text, "Purchase Entry") Then
                FormType = PurchaseEntry
            ElseIf AgL.StrCmp(Me.Text, "Purchase Entry {Authenticated}") Then
                FormType = PurchaseEntryAuthenticated
            End If
            'end change 
            AglObj = AgL

            mNCatStr = "" & AgL.Chk_Text(ClsVar.NCat_StorePurchase) & ""
            AgL.WinSetting(Me, 650, 950, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            FIniMaster()
            CreateHelpDataSet()
            Ini_List()
            DispText(False)
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        'Code by Akash on date 18-9-10
        Dim bCondStr As String = ""
        If FormType = PurchaseEntry Then
            bCondStr = " AND P.ApprovedDate IS  NULL "
        ElseIf FormType = PurchaseEntryAuthenticated Then
            bCondStr = " AND P.ApprovedDate IS NOT NULL"
        End If
        'End Change


        mQry = "Select P.DocId As SearchCode " & _
                " From Store_Purchase P " & _
                " Left Join Voucher_Type Vt On P.V_Type = Vt.V_Type " & _
                " Where 1=1 " & AgL.CondStrFinancialYear("P.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                " And Vt.NCat In (" & mNCatStr & ") " & bCondStr
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
                " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Vt.V_Type As Code, Vt.Description As [Voucher Type], Vt.NCat " & _
                " From Voucher_Type Vt " & _
                " Where Vt.NCat In (" & mNCatStr & ") " & _
                " Order By Vt.Description"
        TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Sg.SubCode As Code, Sg.Name As Name, City.CityName, Sg.Add1, Sg.Add2, Sg.Add3, Sg.Nature " & _
                " From ViewSubGroup Sg " & _
                " Left Join City On Sg.CityCode = City.CityCode " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                " And (Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryCreditors) & " Or " & _
                "       Left(Sg.MainGrCodeS," & AgLibrary.ClsConstant.MainGRLenCashInHand & ") = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeCashInHand) & ") " & _
                " Order By SG.Name "
        TxtAcCode.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code As Code,  Description As Department " & _
                " From Sch_Department " & _
                " Where 1=1 " & _
                " Order By Description"
        TxtDepartment.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Store_Item.code As Code, Store_Item.Description As Name, Store_Item.PurchaseRate,s.Stock,store_unit.Description as Unit   " & _
               " From Store_Item LEFT JOIN  (SELECT item,sum(isnull(qty_rec,0))-sum(isnull(qty_iss,0)) AS Stock   FROM Store_Stock GROUP BY item) s ON Store_Item.Code=s.item    left join store_unit on Store_Item.Unit=store_unit.code Where 1=1  and  Store_Item.MasterType = '" & ClsMain.ItemType.Store & "' " & _
              " Order By Store_Item.Description "
        DGL1.AgHelpDataSet(Col1Item) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code As Code,  ManualCode Name " & _
                " From Store_Godown " & _
                " Where 1=1 " & _
                " Order By ManualCode"
        DGL1.AgHelpDataSet(Col1Godown) = AgL.FillData(mQry, AgL.GCn)

        TxtPurchOrder.AgHelpDataSet(5) = HelpDataSet.PurchOrder
        DGL1.AgHelpDataSet(Col1PurchOrder, 5) = HelpDataSet.PurchOrder
        TxtGRNNo.AgHelpDataSet(5) = HelpDataSet.PurchGRN
        DGL1.AgHelpDataSet(Col1GRNNo, 5) = HelpDataSet.PurchGRN

        Call IniItemNature1Help()
        Call IniItemNature2Help()
        Call IniItemList()
        Call IniItemGRNList()
        IniBatchHelp()
    End Sub
    Private Sub CreateHelpDataSet()


        mQry = "SELECT Po.DocID AS Code, Po.V_Type + '-' + Convert(NVARCHAR, Po.V_No) AS [Purch. Order No],Po.V_Date AS [Order Date], " & _
                " PO.ReferenceNo AS [Manual No], PO.SubCode as Vendor , " & _
                " Vt.NCat, Po.Div_Code ,  " & _
                " Po.V_Date As PurchaseOrderDate " & _
                " FROM Store_PurchOrder Po " & _
                " Left Join " & _
                " ( " & _
                " SELECT Pod.DocId, IsNull(Sum(Pod.Qty),0) AS PendingQty " & _
                " FROM Store_PurchOrderDetail Pod  " & _
                " GROUP BY Pod.DocId) AS V1 ON Po.DocId = V1.DocId " & _
                " LEFT JOIN Voucher_Type Vt On Po.V_Type = Vt.V_Type  " & _
                " LEFT JOIN SubGroup Sg On  PO.SubCode = Sg.SubCode "
        HelpDataSet.PurchOrder = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Po.DocID AS Code, Po.V_Type + '-' + Convert(NVARCHAR, Po.V_No) AS [GRN No],Po.V_Date AS [GRN Date], " & _
              " PO.ReferenceNo AS [Manual No], PO.ACCode as Vendor , " & _
              " Vt.NCat, Po.Div_Code ,  " & _
              " Po.V_Date As PurchaseGRNDate " & _
              " FROM Store_GRN Po " & _
              " Left Join " & _
              " ( " & _
              " SELECT Pod.DocId, IsNull(Sum(Pod.Qty),0) AS PendingQty " & _
              " FROM Store_GrnDetail Pod  " & _
              " GROUP BY Pod.DocId) AS V1 ON Po.DocId = V1.DocId " & _
              " LEFT JOIN Voucher_Type Vt On Po.V_Type = Vt.V_Type  " & _
              " LEFT JOIN SubGroup Sg On  PO.AcCode = Sg.SubCode "
        HelpDataSet.PurchGRN = AgL.FillData(mQry, AgL.GCn)


        mQry = "Select Store_Item.code As Code, Store_Item.Description As Name, Store_Item.PurchaseRate,s.Stock,store_unit.Description as Unit  " & _
               " From Store_Item LEFT JOIN  (SELECT item,sum(isnull(qty_rec,0))-sum(isnull(qty_iss,0)) AS Stock   FROM Store_Stock GROUP BY item) s ON Store_Item.Code=s.item    left join store_unit on Store_Item.Unit=store_unit.code Where 1=1  and  Store_Item.MasterType = '" & ClsMain.ItemType.Store & "' " & _
              " Order By Store_Item.Description "
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Pod.Item AS Code, I.Description AS Name, " & _
                       " I.Unit,  " & _
                       " Po.Div_Code,  Pod.Rate as PurchaseRate, Pod.Qty   As PendingQty, " & _
                       " Po.DocId As PurchOrder , Pod.DocId AS OrderDocId,Pod.Uid as OrderUID " & _
                       " FROM Store_PurchOrderDetail Pod " & _
                       " LEFT JOIN Store_PurchOrder Po On Pod.DocId = Po.DocId " & _
                       " LEFT JOIN Store_Item I ON Pod.Item = I.Code " & _
                        " Where I.MasterType = '" & ClsMain.ItemType.Store & "'"
        HelpDataSet.PurchOrderItem = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Pod.Item AS Code, I.Description AS Name, " & _
                     " I.Unit,  " & _
                     " Po.Div_Code,  Pod.Rate as PurchaseRate, Pod.Qty   As PendingQty, " & _
                     " Po.DocId As PurchGRN , Pod.DocId AS GRNDocId,Pod.Uid as GRNUID " & _
                     " FROM Store_GrnDetail Pod " & _
                     " LEFT JOIN Store_GRN Po On Pod.DocId = Po.DocId " & _
                     " LEFT JOIN Store_Item I ON Pod.Item = I.Code " & _
                    " Where I.MasterType = '" & ClsMain.ItemType.Store & "'"
        HelpDataSet.PurchGRNItem = AgL.FillData(mQry, AgL.GCn)


    End Sub
    Private Sub IniItemList(Optional ByVal All_Records As Boolean = True)
        If All_Records Then
            DGL1.AgHelpDataSet(Col1Item, 2) = HelpDataSet.Item
        Else
            DGL1.AgHelpDataSet(Col1Item, 6) = HelpDataSet.PurchOrderItem
        End If
    End Sub
    Private Sub IniItemGRNList(Optional ByVal All_Records As Boolean = True)
        If All_Records Then
            DGL1.AgHelpDataSet(Col1Item, 2) = HelpDataSet.Item
        Else
            DGL1.AgHelpDataSet(Col1Item, 6) = HelpDataSet.PurchGRNItem
        End If
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
        DGL1.AgHelpDataSet(Col1ItemNature2, 1) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    'Code by Akash on date 22-9-10
    Private Sub IniBatchHelp(Optional ByVal All_Records As Boolean = True)
        If All_Records = True Then
            mQry = "Select DISTINCT Item+Batchno As Code, Batchno " & _
                   " From store_Stock where batchno is not null " & _
                   " Order By Batchno "
        Else
            mQry = "Select DISTINCT store_Stock.Item+store_Stock.Batchno As Code, store_Stock.Batchno ,s.Stock  From store_Stock  " & _
                  " LEFT JOIN (SELECT item,Batchno,sum(isnull(qty_rec,0))-sum(isnull(qty_iss,0)) AS Stock FROM Store_Stock GROUP BY item,Batchno) s ON (store_Stock.batchno=s.batchno and store_Stock.item=s.item )" & _
                  " Where store_Stock.Item = '" & DGL1.AgSelectedValue(Col1Item, DGL1.CurrentCell.RowIndex) & "' and  store_Stock.batchno is not null and s.Stock >0" & _
                  " Order By store_Stock.Batchno "

        End If
        DGL1.AgHelpDataSet(Col1Batch, , , , , True) = AgL.FillData(mQry, AgL.GCn)
    End Sub   'End of code by akash 

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        RbtPODirect.Checked = True
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

                    AgL.Dman_ExecuteNonQry("Delete From Store_PurchaseLedgerM Where DocId = '" & mSearchCode & "' ", AgL.GCn, AgL.ECmd)

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    mQry = "Delete From Store_PurchaseStock Where DocId = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Delete From Store_Stock  Where DocId = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Delete From Store_StockHeader  Where DocId = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Delete From Store_Purchase Where DocId = '" & mSearchCode & "'"
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
            'Code by Akash on date 18-9-10
            Dim bCondStr As String = ""
            If FormType = PurchaseEntry Then
                bCondStr = " AND P.ApprovedDate IS  NULL "
            ElseIf FormType = PurchaseEntryAuthenticated Then
                bCondStr = " AND P.ApprovedDate IS NOT NULL"
            End If
            'End Change


            AgL.PubFindQry = "Select  P.DocId As SearchCode, S.Name As [Site/Branch Name], Convert(nVarChar,P.V_Date,3) As [Vr. Date], " & _
                                " Vt.Description As [Vr. Type], Convert(VarChar,P.V_No) As [Voucher No], P.V_Prefix as [Voucher Prefix], P.ReferenceNo As [" & LblRefNo.Text & "], Sg.Name As [A/c Name]  " & _
                                " From  Store_Purchase P " & _
                                " Left Join  SiteMast S On S.Code = P.Site_Code " & _
                                " Left Join  Voucher_Type Vt On Vt.V_Type = P.V_Type " & _
                                " Left Join  SubGroup Sg On Sg.SubCode = P.AcCode " & _
                                " Where 1=1 " & AgL.CondStrFinancialYear("P.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                                " And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                                " And Vt.NCat In (" & mNCatStr & ") " & bCondStr

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
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            'Me.Cursor = Cursors.WaitCursor
            'AgL.PubReportTitle = "Purchase Bill"
            'If Not DTMaster.Rows.Count > 0 Then
            '    MsgBox("No Records Found to Print!!!", vbInformation, "Information")
            '    Me.Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'strQry = " Select Tmr.DocId,Tmr.Site_Code,Tmr.V_Type,Tmr.V_Prefix,Tmr.V_No,Tmr.V_Date, " & _
            '             " Tmr.TripBillDocId,Tmr.AcCode,Tmr.TotalAmount,Tmr.TDS,Tmr.OtherDeduction,Tmr.LatePenalty,Tmr.TotalNetAmount, " & _
            '             " Tb.CustomerAc, IsNull(Tb.TotalNetAmount,0) TripBillAmount, Tb.V_Date As TripBill_Date, " & _
            '             " Sg.Add1, Sg.Add2, Sg.Add3, City.CityName, Sg1.Nature As AcNature, Vt.Category,St.Name AS SiteName,Sg.Name AS customerName,Tmr1.Remark, " & _
            '             " Tp.THC_No,Tp.THC_Date,Vt.Description,Tmr1.ChqNo,Tmr1.ChqDate From TripMoneyReceipt Tmr " & _
            '             " Left Join TripBill Tb On Tmr.TripBillDocId=Tb.DocId " & _
            '             " Left Join TripMoneyReceipt1 Tmr1 ON Tmr.DocId =Tmr1.DocId " & _
            '             " Left Join Trip Tp ON Tp.DocId =Tmr1.TripDocId  " & _
            '             " Left Join SubGroup Sg On Sg.SubCode=Tb.CustomerAc " & _
            '             " Left Join City On Sg.CityCode=City.CityCode " & _
            '             " Left Join SubGroup Sg1 On Sg1.SubCode=Tmr.AcCode " & _
            '             " Left Join Voucher_Type Vt On Tmr.V_Type=Vt.V_Type " & _
            '             " Left Join SiteMast St ON St.Code = Tmr.Site_Code " & _
            '             " Where Tmr.DocId='" & mSearchCode & "'"

            'AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            'AgL.ADMain.Fill(DsRep)

            'RepName = "TripMoneyReceipt" : RepTitle = "Trip Money Receipt"
            'AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            'mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            'mCrd.SetDataSource(DsRep.Tables(0))
            'CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            ''PLib.Formula_Set(mCrd, RepTitle)
            'AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            'Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, mSr As Integer = 0
        Dim mTrans As Boolean = False
        Try
            MastPos = BMBMaster.Position

            Calculation()
            If Not Data_Validation() Then Exit Sub




            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then

                mQry = "INSERT INTO Store_Purchase " & _
                        " (DocId,Div_Code,Site_Code,V_Type,V_Prefix, " & _
                        " V_No,V_Date,PartyBillNo,PartyBillDate,AcCode, " & _
                        " Amount,Addition,Deduction,NetAmount,Addition_H, " & _
                        " Deduction_H,InvoiceAmount, Remark, Department, " & _
                        " PreparedBy,U_EntDt,U_AE,OrderDocId,IsAgainstOrder,ReferenceNo,GRNDocId,IsAgainstGRN) " & _
                        " VALUES " & _
                        " (" & AgL.Chk_Text(TxtDocId.Text) & ", " & AgL.Chk_Text(AgL.PubDivCode) & ", " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & ", " & _
                        " " & Val(TxtV_No.Text) & "," & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtPartyBillNo.Text) & ", " & AgL.ConvertDate(TxtPartyBillDate.Text) & ", " & AgL.Chk_Text(TxtAcCode.AgSelectedValue) & ", " & _
                        " " & Val(TxtAmount.Text) & ", " & Val(TxtAddition.Text) & ", " & Val(TxtDeduction.Text) & ", " & Val(TxtNetAmount.Text) & "," & Val(TxtAddition_H.Text) & ", " & _
                        " " & Val(TxtDeduction_H.Text) & "," & Val(TxtInvoiceAmount.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & AgL.Chk_Text(TxtDepartment.AgSelectedValue) & " ," & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & "," & AgL.ConvertDate(AgL.PubLoginDate) & ",'A'," & AgL.Chk_Text(TxtPurchOrder.AgSelectedValue) & "," & IIf(RbtPOForOrder.Checked, 1, 0) & "," & AgL.Chk_Text(TxtRefNo.Text) & "," & AgL.Chk_Text(TxtGRNNo.AgSelectedValue) & "," & IIf(RbtGRNForPur.Checked, 1, 0) & ")"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "INSERT INTO Store_StockHeader (DocId, PreparedBy, U_EntDt, U_AE) " & _
                        " Values (" & _
                        " '" & mSearchCode & "', " & AgL.Chk_Text(AgL.PubUserName) & "," & AgL.ConvertDate(AgL.PubLoginDate) & ",'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "UPDATE Store_Purchase " & _
                        " SET V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", PartyBillNo = " & AgL.Chk_Text(TxtPartyBillNo.Text) & ", PartyBillDate = " & AgL.ConvertDate(TxtPartyBillDate.Text) & ", " & _
                        " AcCode = " & AgL.Chk_Text(TxtAcCode.AgSelectedValue) & ", Amount = " & Val(TxtAmount.Text) & ", Addition = " & Val(TxtAddition.Text) & ",	Deduction = " & Val(TxtDeduction.Text) & ",	NetAmount = " & Val(TxtNetAmount.Text) & ", " & _
                        " Addition_H = " & Val(TxtAddition_H.Text) & ", Deduction_H = " & Val(TxtDeduction_H.Text) & ", InvoiceAmount = " & Val(TxtInvoiceAmount.Text) & ", Remark =" & AgL.Chk_Text(TxtRemark.Text) & ", Department = " & AgL.Chk_Text(TxtDepartment.AgSelectedValue) & ", " & _
                        " U_AE = 'E',	Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ",	ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & ",  " & _
                        " OrderDocId = " & AgL.Chk_Text(TxtPurchOrder.AgSelectedValue) & ", " & _
                        " GRNDocId = " & AgL.Chk_Text(TxtGRNNo.AgSelectedValue) & ", " & _
                        " IsAgainstGRN=  " & IIf(RbtGRNForPur.Checked, 1, 0) & " , " & _
                        " IsAgainstOrder=  " & IIf(RbtPOForOrder.Checked, 1, 0) & " ,  ReferenceNo=" & AgL.Chk_Text(TxtRefNo.Text) & "" & _
                        " Where DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "Update Store_StockHeader Set " & _
                        " ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                        " Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ", " & _
                        " U_AE = 'E' " & _
                        " Where DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                AgL.Dman_ExecuteNonQry("Delete From Store_PurchaseLedgerM Where DocId = '" & mSearchCode & "' ", AgL.GCn, AgL.ECmd)
            End If


            If Topctrl1.Mode = "Edit" Then
                AgL.Dman_ExecuteNonQry("Delete From Store_PurchaseStock Where DocId = '" & mSearchCode & "' ", AgL.GCn, AgL.ECmd)
                AgL.Dman_ExecuteNonQry("Delete From Store_Stock Where DocId = '" & mSearchCode & "' ", AgL.GCn, AgL.ECmd)
            End If


            With DGL1
                mSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        mSr = mSr + 1

                        mQry = "INSERT INTO Store_Stock " & _
                                " ( " & _
                                " DocId,Sr,Div_Code,Site_Code,V_Type, " & _
                                " V_Prefix,V_No,V_Date,Item,ItemDescription,Item_Nature1, " & _
                                " Item_Nature2,BatchNo,Qty_Rec,Rate,Amount, " & _
                                " Addition,Deduction,NetAmount,Addition_H,Deduction_H, " & _
                                " LandedAmount, Godown,OrderDocId,OrderUID ,GRNDocId,GRNUID" & _
                                " ) " & _
                                " VALUES " & _
                                " ( " & _
                                " " & AgL.Chk_Text(mSearchCode) & "," & mSr & "," & AgL.Chk_Text(AgL.PubDivCode) & "," & AgL.Chk_Text(AgL.PubSiteCode) & "," & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                                " " & AgL.Chk_Text(LblPrefix.Text) & "," & AgL.Chk_Text(TxtV_No.Text) & "," & AgL.ConvertDate(TxtV_Date.Text) & "," & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & "," & AgL.Chk_Text(.Item(Col1ItemDescription, I).Value) & ", " & AgL.Chk_Text(.AgSelectedValue(Col1ItemNature1, I)) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1ItemNature2, I)) & "," & AgL.Chk_Text(.Item(Col1Batch, I).Value) & "," & Val(.Item(Col1Qty, I).Value) & "," & Val(.Item(Col1Rate, I).Value) & "," & Val(.Item(Col1Amount, I).Value) & ", " & _
                                " " & Val(.Item(Col1Addition, I).Value) & "," & Val(.Item(Col1Deduction, I).Value) & "," & Val(.Item(Col1NetAmount, I).Value) & "," & Val(.Item(Col1Addition_H, I).Value) & "," & Val(.Item(Col1Deduction_H, I).Value) & ", " & _
                                " " & Val(.Item(Col1LandedAmount, I).Value) & ", " & AgL.Chk_Text(.AgSelectedValue(Col1Godown, I)) & " ," & AgL.Chk_Text(DGL1.AgSelectedValue(Col1PurchOrder, I)) & "," & AglObj.Chk_Text(DGL1.Item(Col1Orderuid, I).Value) & "," & AgL.Chk_Text(DGL1.AgSelectedValue(Col1GRNNo, I)) & "," & AglObj.Chk_Text(DGL1.Item(Col1GRNuid, I).Value) & " " & _
                                " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "update store_item set purchaseRate=" & Val(.Item(Col1Rate, I).Value) & " where  code=" & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


                    End If
                Next I
            End With

            mQry = "INSERT INTO Store_PurchaseStock (DocId) Values ('" & mSearchCode & "') "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            'changed by akash on date 17-9-10

            'Call AccountPosting()
            'mQry = "INSERT INTO Store_PurchaseLedgerM (DocId) Values ('" & mSearchCode & "') "
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            'end change 

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
                Call IniItemNature1Help()
                Call IniItemNature2Help()

                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select P.*, S.Add1, S.Add2, S.Add3, C.CityName, Vt.NCat " & _
                      "From Store_Purchase P " & _
                      "Left Join Voucher_Type Vt On P.V_Type = Vt.V_Type " & _
                      "Left Join Subgroup S On P.AcCode = S.SubCode " & _
                      "Left Join City C On S.CityCode = C.CityCode " & _
                      "Where P.DocId = '" & mSearchCode & "' "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = AgL.XNull(.Rows(0)("DocId"))
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Date.Text = AgL.RetDate(AgL.XNull(.Rows(0)("V_Date")))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCat"))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(0 + 2, "0"))
                        TxtPartyBillNo.Text = AgL.XNull(.Rows(0)("PartyBillNo"))
                        TxtPartyBillDate.Text = AgL.RetDate(AgL.XNull(.Rows(0)("PartyBillDate")))
                        TxtDepartment.AgSelectedValue = AgL.XNull(.Rows(0)("Department"))
                        TxtAcCode.AgSelectedValue = AgL.XNull(.Rows(0)("AcCode"))
                        TxtAddress1.Text = AgL.XNull(.Rows(0)("Add1"))
                        TxtAddress2.Text = AgL.XNull(.Rows(0)("Add2"))
                        TxtAddress3.Text = AgL.XNull(.Rows(0)("Add3"))
                        TxtCity.Text = AgL.XNull(.Rows(0)("CityName"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        TxtAmount.Text = Format(AgL.VNull(.Rows(0)("Amount")), "0.00")
                        TxtAddition.Text = Format(AgL.VNull(.Rows(0)("Addition")), "0.00")
                        TxtDeduction.Text = Format(AgL.VNull(.Rows(0)("Deduction")), "0.00")
                        TxtNetAmount.Text = Format(AgL.VNull(.Rows(0)("NetAmount")), "0.00")
                        TxtAddition_H.Text = Format(AgL.VNull(.Rows(0)("Addition_H")), "0.00")
                        TxtDeduction_H.Text = Format(AgL.VNull(.Rows(0)("Deduction_H")), "0.00")
                        TxtInvoiceAmount.Text = Format(AgL.VNull(.Rows(0)("InvoiceAmount")), "0.00")
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtRefNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                        LblRefNo.Tag = AgL.XNull(.Rows(0)("ReferenceNo"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        TxtApproved.Text = AgL.XNull(.Rows(0)("ApprovedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)

                        TxtPurchOrder.AgSelectedValue = AgL.XNull(.Rows(0)("OrderDocId"))
                        If AgL.VNull(.Rows(0)("IsAgainstOrder")) Then
                            RbtPOForOrder.Checked = True
                            RbtPODirect.Checked = False
                        Else
                            RbtPOForOrder.Checked = False
                            RbtPODirect.Checked = True
                        End If
                        TxtGRNNo.AgSelectedValue = AgL.XNull(.Rows(0)("GRNDocId"))
                        If AgL.VNull(.Rows(0)("IsAgainstGRN")) Then
                            RbtGRNForPur.Checked = True
                        Else
                            RbtGRNForPur.Checked = False
                        End If


                    End If
                End With

                mQry = "Select S.* " & _
                    " From Store_Stock S " & _
                    " Where S.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1Item, I) = .Rows(I)("Item")
                            DGL1.Item(Col1ItemDescription, I).Value = AgL.XNull(.Rows(I)("ItemDescription"))
                            DGL1.AgSelectedValue(Col1PurchOrder, I) = AgL.XNull(.Rows(I)("OrderDocId"))
                            DGL1.Item(Col1Orderuid, I).Value = AglObj.XNull(.Rows(I)("OrderUID").ToString)
                            DGL1.AgSelectedValue(Col1GRNNo, I) = AgL.XNull(.Rows(I)("GRNDocId"))
                            DGL1.Item(Col1GRNuid, I).Value = AglObj.XNull(.Rows(I)("GRNUID").ToString)
                            DGL1.AgSelectedValue(Col1TempItem, I) = AgL.XNull(.Rows(I)("Item"))
                            DGL1.Item(Col1Batch, I).Value = AgL.XNull(.Rows(I)("BatchNo"))
                            DGL1.AgSelectedValue(Col1ItemNature1, I) = AgL.XNull(.Rows(I)("Item_Nature1"))
                            DGL1.AgSelectedValue(Col1ItemNature2, I) = AgL.XNull(.Rows(I)("Item_Nature2"))
                            DGL1.AgSelectedValue(Col1Godown, I) = AgL.XNull(.Rows(I)("Godown"))
                            DGL1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty_Rec"))
                            DGL1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1Addition, I).Value = Format(AgL.VNull(.Rows(I)("Addition")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1Deduction, I).Value = Format(AgL.VNull(.Rows(I)("Deduction")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1NetAmount, I).Value = Format(AgL.VNull(.Rows(I)("NetAmount")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1Addition_H, I).Value = Format(AgL.VNull(.Rows(I)("Addition_H")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1Deduction_H, I).Value = Format(AgL.VNull(.Rows(I)("Deduction_H")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1LandedAmount, I).Value = Format(AgL.VNull(.Rows(I)("LandedAmount")), "0.".PadRight(2 + 2, "0"))

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

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        LblAddition.Text = ClsVar.PurchaseAddition_Text
        LblDeduction.Text = ClsVar.PurchaseDeduction_Text
        LblAddition_H.Text = ClsVar.PurchaseAddition_H_Text
        LblDeduction_H.Text = ClsVar.PurchaseDeduction_H_Text

        TxtV_No.Enabled = False
        TxtAddress1.Enabled = False
        TxtAddress2.Enabled = False
        TxtAddress3.Enabled = False
        TxtCity.Enabled = False
        TxtNetAmount.Enabled = False
        TxtAmount.Enabled = False
        TxtAddition.Enabled = False
        TxtDeduction.Enabled = False
        TxtSite_Code.Enabled = False

        'Code by Akash on date 18-9-10
        If Topctrl1.Mode = "Browse" Then GroupBox1.Visible = True
        If FormType = PurchaseEntryAuthenticated Then Topctrl1.tAdd = False : Topctrl1.tEdit = False
        'End Change                                     

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

                Case Col1Item
                    If TxtPurchOrder.AgSelectedValue <> "" And RbtPOForOrder.Checked = True Then
                        Call IniItemList(False)
                        DGL1.AgRowFilter(DGL1.Columns(Col1Item).Index) = " PurchOrder = '" & TxtPurchOrder.AgSelectedValue & "' "
                    ElseIf RbtPOForOrder.Checked Then
                        Call IniItemList(False)
                        DGL1.AgRowFilter(DGL1.Columns(Col1Item).Index) = " PurchOrder = '" & DGL1.AgSelectedValue(Col1PurchOrder, mRowIndex) & "' "
                    ElseIf TxtGRNNo.AgSelectedValue <> "" And RbtGRNForPur.Checked = True Then
                        Call IniItemGRNList(False)
                        DGL1.AgRowFilter(DGL1.Columns(Col1Item).Index) = " PurchGRN = '" & TxtGRNNo.AgSelectedValue & "' "
                    ElseIf RbtGRNForPur.Checked Then
                        Call IniItemGRNList(False)
                        DGL1.AgRowFilter(DGL1.Columns(Col1Item).Index) = " PurchGRN = '" & DGL1.AgSelectedValue(Col1GRNNo, mRowIndex) & "' "
                    Else
                        Call IniItemList()
                        DGL1.AgRowFilter(DGL1.Columns(Col1Item).Index) = " Name Is Not Null "
                    End If

                Case Col1PurchOrder
                    DGL1.AgRowFilter(DGL1.Columns(Col1PurchOrder).Index) = "  PurchaseOrderDate <= '" & TxtV_Date.Text & "' "

                Case Col1GRNNo
                    DGL1.AgRowFilter(DGL1.Columns(Col1GRNNo).Index) = "  PurchaseGRNDate <= '" & TxtV_Date.Text & "' "


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
                        DGL1.AgSelectedValue(Col1PurchOrder, mRowIndex) = ""
                        DGL1.AgSelectedValue(Col1Item, mRowIndex) = ""
                        DGL1.Item(Col1Orderuid, mRowIndex).Value = ""
                    Else
                        'If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                        '    With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)

                        '    End With
                        'End If

                        If DGL1.AgDataRow IsNot Nothing Then
                            If RbtPOForOrder.Checked Then
                                DGL1.AgSelectedValue(Col1PurchOrder, mRowIndex) = AgL.XNull(DGL1.AgDataRow.Cells("OrderDocId").Value)
                                DGL1.Item(Col1Orderuid, mRowIndex).Value = AglObj.XNull(DGL1.AgDataRow.Cells("OrderUID").Value.ToString)
                            End If
                            If RbtGRNForPur.Checked Then
                                DGL1.AgSelectedValue(Col1GRNNo, mRowIndex) = AgL.XNull(DGL1.AgDataRow.Cells("GRNDocId").Value)
                                DGL1.Item(Col1GRNuid, mRowIndex).Value = AglObj.XNull(DGL1.AgDataRow.Cells("GRNUID").Value.ToString)
                            End If
                            DGL1.Item(Col1Rate, mRowIndex).Value = AgL.XNull(DGL1.AgDataRow.Cells("PurchaseRate").Value)
                            DGL1.Item(Col1ItemDescription, mRowIndex).Value = AgL.XNull(DGL1.AgDataRow.Cells("Name").Value)

                        End If

                    End If
                Case Col1Amount
                    If DGL1.Item(Col1Qty, mRowIndex).Value > 0 Then
                        DGL1.Item(Col1Rate, mRowIndex).Value = Format(Val(DGL1.Item(Col1Amount, mRowIndex).Value) / Val(DGL1.Item(Col1Qty, mRowIndex).Value), "0.000")
                    End If


                Case Col1PurchOrder
                    e.Cancel = Not Validate_PurchOrder(DGL1, DGL1.CurrentCell.RowIndex)

                Case Col1GRNNo
                    e.Cancel = Not Validate_PurchGRN(DGL1, DGL1.CurrentCell.RowIndex)


            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function Validate_PurchOrder(ByVal Sender As Object, Optional ByVal RowIndex As Integer = 0) As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            Select Case Sender.Name
                Case DGL1.Name
                    If DGL1.AgSelectedValue(Col1PurchOrder, RowIndex) <> "" Then
                        DrTemp = DGL1.AgHelpDataSet(Col1PurchOrder).Tables(0).Select("Code = '" & DGL1.AgSelectedValue(Col1PurchOrder, RowIndex) & "' ")
                    End If
                    Validate_PurchOrder = True

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    Private Function Validate_PurchGRN(ByVal Sender As Object, Optional ByVal RowIndex As Integer = 0) As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            Select Case Sender.Name
                Case DGL1.Name
                    If DGL1.AgSelectedValue(Col1GRNNo, RowIndex) <> "" Then
                        DrTemp = DGL1.AgHelpDataSet(Col1GRNNo).Tables(0).Select("Code = '" & DGL1.AgSelectedValue(Col1GRNNo, RowIndex) & "' ")
                    End If
                    Validate_PurchGRN = True

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function


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

        If DGL1.Rows.Count = 1 And Topctrl1.Mode = "Add" Then
            If DGL1.Item(Col1Item, 0).Value Is Nothing Then DGL1.Item(Col1Item, 0).Value = ""
            If DGL1.Item(Col1Item, 0).Value.ToString.Trim = "" Then
                If TxtPartyBillNo.Enabled = False Then TxtPartyBillNo.Enabled = True
            End If
        End If

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
        TxtAcCode.Enter, TxtV_Type.Enter
        Try
            Select Case sender.name
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
           TxtSite_Code.Validating, TxtV_Date.Validating, TxtPartyBillNo.Validating, TxtV_Type.Validating, _
           TxtAcCode.Validating, TxtAmount.Validating, TxtAddition.Validating, TxtAddition_H.Validating, TxtDeduction.Validating, _
           TxtDeduction_H.Validating, TxtInvoiceAmount.Validating, TxtNetAmount.Validating, TxtPurchOrder.Validating, TxtRefNo.Validating, TxtGRNNo.Validating
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

                Case TxtAcCode.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblAcCode.Tag = ""
                        TxtAddress1.Text = ""
                        TxtAddress2.Text = ""
                        TxtAddress3.Text = ""
                        TxtCity.Text = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblAcCode.Tag = AgL.XNull(.Item("Nature", .CurrentCell.RowIndex).Value)
                                TxtAddress1.Text = AgL.XNull(.Item("Add1", .CurrentCell.RowIndex).Value)
                                TxtAddress2.Text = AgL.XNull(.Item("Add2", .CurrentCell.RowIndex).Value)
                                TxtAddress3.Text = AgL.XNull(.Item("Add3", .CurrentCell.RowIndex).Value)
                                TxtCity.Text = AgL.XNull(.Item("CityName", .CurrentCell.RowIndex).Value)

                            End With
                        End If
                    End If

                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                    TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text)


                Case TxtGRNNo.Name
                    If TxtGRNNo.Text.ToString.Trim = "" Then
                        TxtGRNNo.AgSelectedValue = ""
                        RbtPODirect.Checked = True
                    Else
                        RbtGRNForPur.Checked = True
                    End If


                Case TxtPurchOrder.Name
                    If TxtPurchOrder.Text.ToString.Trim = "" And TxtGRNNo.Text.ToString.Trim = "" Then
                        TxtPurchOrder.AgSelectedValue = ""
                        RbtPODirect.Checked = True
                    ElseIf TxtPurchOrder.Text.ToString.Trim <> "" And TxtGRNNo.Text.ToString.Trim = "" Then
                        RbtPOForOrder.Checked = True
                    End If

               
            End Select

            Call Calculation()

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

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtPartyBillNo) Then Exit Function
            If AgL.RequiredField(TxtDepartment) Then Exit Function
            If AgL.RequiredField(TxtAcCode) Then Exit Function
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtRefNo, LblRefNo.Text) Then Exit Function
            'If AgL.RequiredField(TxtInvoiceAmount, "Invoice Amount", True) Then DGL1.CurrentCell = DGL1(Col1Rate, 0) : DGL1.Focus() : Exit Function

            If TxtPartyBillDate.Text.Trim <> "" Then
                If CDate(TxtPartyBillDate.Text) > CDate(TxtV_Date.Text) Then
                    MsgBox("Bill Date Can't Be greater than from Voucher Date!...") : TxtPartyBillDate.Focus() : Exit Function
                End If
            End If

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1Item) Then Exit Function
            ' If AgCL.AgIsDuplicate(DGL1, "" & Col1Item & ", " & Col1Batch & "," & Col1ItemNature1 & "," & Col1ItemNature2 & "," & Col1Godown & "") Then Exit Function
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Item, I).Value.ToString.Trim <> "" Then
                        'If Val(.Item(Col1Amount, I).Value) = 0 Then MsgBox("Amount Is Blank Or Zero At Row No. " & .Item(Col_SNo, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1Qty, I) : DGL1.Focus() : Exit Function
                        'If Val(.Item(Col1NetAmount, I).Value) = 0 Then MsgBox("Net Amount Is Blank Or Zero At Row No. " & .Item(Col_SNo, I).Value & " ") : DGL1.CurrentCell = DGL1(Col1Deduction, I) : DGL1.Focus() : Exit Function
                    End If
                Next
            End With
            '######
            'If PLib.PubTdsAc.Trim = "" Then MsgBox("Define TDS A/c in Environment Settings") : Exit Function
            'If PLib.PubAdditionAc.Trim = "" Then MsgBox("Define Addition A/c in Environment Settings") : Exit Function
            'If PLib.PubDeductionAc.Trim = "" Then MsgBox("Define Deduction A/c in Environment Settings") : Exit Function
            'If PLib.PubLatePenaltyAc.Trim = "" Then MsgBox("Define Late Penalty A/c in Environment Settings") : Exit Function

            If AgL.XNull(DtStore_Enviro.Rows(0)("Godown")).ToString.Trim = "" Then MsgBox("Define Godown In Environment Settings!...") : Exit Function

            'Code By Rati on 15/06/2012
            If TxtRefNo.Text.Trim <> "" Then
                mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                        " FROM Store_Purchase H With (NoLock) " & _
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
        Dim mLineMultiplier As Double

        TxtAmount.Text = ""
        TxtAddition.Text = ""
        TxtDeduction.Text = ""
        TxtNetAmount.Text = ""
        TxtInvoiceAmount.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value Is Nothing Then .Item(Col1Item, I).Value = ""
                If .Item(Col1Batch, I).Value Is Nothing Then .Item(Col1Batch, I).Value = ""
                If .Item(Col1ItemNature1, I).Value Is Nothing Then .Item(Col1ItemNature1, I).Value = ""
                If .Item(Col1ItemNature2, I).Value Is Nothing Then .Item(Col1ItemNature2, I).Value = ""
                If .Item(Col1Qty, I).Value Is Nothing Then .Item(Col1Qty, I).Value = ""
                If .Item(Col1Rate, I).Value Is Nothing Then .Item(Col1Rate, I).Value = ""
                If .Item(Col1Amount, I).Value Is Nothing Then .Item(Col1Amount, I).Value = ""
                If .Item(Col1Addition, I).Value Is Nothing Then .Item(Col1Addition, I).Value = ""
                If .Item(Col1Deduction, I).Value Is Nothing Then .Item(Col1Deduction, I).Value = ""
                If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""
                If .Item(Col1Godown, I).Value Is Nothing Then .Item(Col1Godown, I).Value = ""


                If .Item(Col1Item, I).Value.ToString <> "" Then
                    .Item(Col1Amount, I).Value = Format(Val(.Item(Col1Qty, I).Value) * Val(.Item(Col1Rate, I).Value), "0.00")
                    .Item(Col1NetAmount, I).Value = Format(Val(.Item(Col1Amount, I).Value) + Val(.Item(Col1Addition, I).Value) - Val(.Item(Col1Deduction, I).Value), "0.00")


                    If .Item(Col1Godown, I).Value.ToString.Trim = "" Then
                        .AgSelectedValue(Col1Godown, I) = AgL.XNull(DtStore_Enviro.Rows(0)("Godown"))
                    End If

                    TxtAmount.Text = Val(TxtAmount.Text) + Val(.Item(Col1Amount, I).Value)
                    TxtAddition.Text = Val(TxtAddition.Text) + Val(.Item(Col1Addition, I).Value)
                    TxtDeduction.Text = Val(TxtDeduction.Text) + Val(.Item(Col1Deduction, I).Value)
                    TxtNetAmount.Text = Val(TxtNetAmount.Text) + Val(.Item(Col1NetAmount, I).Value)
                End If

            Next
        End With



        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value.ToString <> "" Then
                    mLineMultiplier = Val(.Item(Col1Amount, I).Value) / Val(TxtAmount.Text)
                    .Item(Col1Addition_H, I).Value = Format(Val(TxtAddition_H.Text) * mLineMultiplier, "0.00")
                    .Item(Col1Deduction_H, I).Value = Format(Val(TxtDeduction_H.Text) * mLineMultiplier, "0.00")
                    .Item(Col1LandedAmount, I).Value = Format(Val(.Item(Col1NetAmount, I).Value) + Val(.Item(Col1Addition_H, I).Value) - Val(.Item(Col1Deduction_H, I).Value), "0.00")
                End If
            Next
        End With


        TxtInvoiceAmount.Text = Val(TxtNetAmount.Text) + Val(TxtAddition_H.Text) - Val(TxtDeduction_H.Text)


        TxtAmount.Text = Format(Val(TxtAmount.Text), "0.00")
        TxtAddition.Text = Format(Val(TxtAddition.Text), "0.00")
        TxtDeduction.Text = Format(Val(TxtDeduction.Text), "0.00")
        TxtNetAmount.Text = Format(Val(TxtNetAmount.Text), "0.00")
        TxtAddition_H.Text = Format(Val(TxtAddition_H.Text), "0.00")
        TxtDeduction_H.Text = Format(Val(TxtDeduction_H.Text), "0.00")
        TxtInvoiceAmount.Text = Format(Val(TxtInvoiceAmount.Text), "0.00")
    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer = 0, J As Integer = 0, K As Integer = 0
        Dim mNarr As String = "", mCommNarr As String = ""

        Dim mVNo As Long = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))

        AccountPosting = True


        I = 0
        ReDim Preserve LedgAry(I)

        LedgAry(I).SubCode = TxtAcCode.AgSelectedValue
        LedgAry(I).ContraSub = ClsVar.PurchaseAc
        LedgAry(I).AmtDr = 0
        LedgAry(I).AmtCr = Val(TxtInvoiceAmount.Text)
        LedgAry(I).Narration = ""

        If Val(TxtAmount.Text) > 0 Then
            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = ClsVar.PurchaseAc
            LedgAry(I).ContraSub = TxtAcCode.AgSelectedValue
            LedgAry(I).AmtDr = Val(TxtAmount.Text)
            LedgAry(I).AmtCr = 0
            LedgAry(I).Narration = ""
        End If

        If Val(TxtAddition.Text) > 0 Then
            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = ClsVar.PurchaseAdditionAc
            LedgAry(I).ContraSub = TxtAcCode.AgSelectedValue
            LedgAry(I).AmtDr = Val(TxtAddition.Text)
            LedgAry(I).AmtCr = 0
            LedgAry(I).Narration = ""
        End If

        If Val(TxtDeduction.Text) > 0 Then
            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = ClsVar.PurchaseDeductionAc
            LedgAry(I).ContraSub = ClsVar.PurchaseAc
            LedgAry(I).AmtDr = 0
            LedgAry(I).AmtCr = Val(TxtDeduction.Text)
            LedgAry(I).Narration = ""
        End If

        If Val(TxtAddition_H.Text) > 0 Then
            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = ClsVar.PurchaseAddition_HAc
            LedgAry(I).ContraSub = TxtAcCode.AgSelectedValue
            LedgAry(I).AmtDr = Val(TxtAddition_H.Text)
            LedgAry(I).AmtCr = 0
            LedgAry(I).Narration = ""
        End If

        If Val(TxtDeduction_H.Text) > 0 Then
            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = ClsVar.PurchaseDeduction_HAc
            LedgAry(I).ContraSub = ClsVar.PurchaseAc
            LedgAry(I).AmtDr = 0
            LedgAry(I).AmtCr = Val(TxtDeduction_H.Text)
            LedgAry(I).Narration = ""
        End If


        If TxtRemark.Text.Trim = "" Then
            mCommNarr = "Being Goods Purchased From """ & TxtAcCode.Text & """ Agt. Voucher Date " & TxtV_Date.Text & " Voucher No " & " & AgL.ConvertDocId(mSearchCode)"
        Else
            mCommNarr = TxtRemark.Text
        End If
        If mCommNarr.Length > 255 Then mCommNarr = AgL.MidStr(mCommNarr, 0, 255)

        If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommNarr, , AgL.Gcn_ConnectionString) = False Then
            AccountPosting = False
            Err.Raise(1, "Error in Ledger Posting")
        End If

    End Function


    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtAddition_H.Validating
        Select Case sender.Name
            Case TxtAddition_H.Name, TxtDeduction_H.Name
                Calculation()
        End Select
    End Sub
    'code by akash on date 17-9-10
    Private Sub BtnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnApproved.Click
        Dim mTrans As Boolean = False
        Try
            If Topctrl1.Mode = "Browse" Then
                If MsgBox("Are You Sure To Approve Record", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Approved Confirmation...") = MsgBoxResult.No Then Exit Sub

                If DTMaster.Rows.Count > 0 Then
                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True

                    Call AccountPosting()

                    mQry = "INSERT INTO Store_PurchaseLedgerM (DocId) Values ('" & mSearchCode & "') "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    AgL.ECmd.CommandText = "Update Store_Purchase Set ApprovedBy='" & AgL.PubUserName & "', " & _
                                           "ApprovedDate='" & AgL.PubLoginDate & "' WHERE DocId = '" & mSearchCode & "'    "

                    AgL.ECmd.ExecuteNonQuery()

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, AgLibrary.ClsConstant.EntryMode_Varified, AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , TxtV_Date.Text, TxtAcCode.AgSelectedValue, TxtAcCode.Text, Val(TxtInvoiceAmount.Text), TxtSite_Code.AgSelectedValue, AgL.PubDivCode)

                    AgL.ETrans.Commit()
                    mTrans = False

                    MsgBox("Document Saved Successfully.", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                End If
                FIniMaster(0, 1) : Topctrl1_tbRef() : MoveRec()

            End If
        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
