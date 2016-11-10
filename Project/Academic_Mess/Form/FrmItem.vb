Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmItem
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Item_Nature1 As Byte = 1
    Private Const Col1Code As Byte = 2

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2Item_Nature2 As Byte = 1
    Private Const Col2Code As Byte = 2

    Dim _StrItemType$ = ""

    Public Property ItemType() As String
        Get
            ItemType = _StrItemType
        End Get
        Set(ByVal value As String)
            _StrItemType = value
        End Set
    End Property

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub FrmissueReceive_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

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
            .AddAgTextColumn(DGL1, "DGL1Item_Nature1", 200, 20, ClsMain.Item_Nature1_Description, True, False, False)
            .AddAgTextColumn(DGL1, "DGL1Code", 40, 10, "Code", False, True, False)
        End With
        DGL1.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom)
        AgL.FSetSNo(DGL1, Col_SNo)
        DGL1.TabIndex = Pnl1.TabIndex
        DGL1.ColumnHeadersDefaultCellStyle.Font = New Font(New FontFamily("Arial"), 9)
        DGL1.DefaultCellStyle.Font = New Font(New FontFamily("Arial"), 8)
        DGL1.ColumnHeadersHeight = 25
        DGL1.Visible = False

        DGL2.Height = Pnl2.Height
        DGL2.Width = Pnl2.Width
        DGL2.Top = Pnl2.Top
        DGL2.Left = Pnl2.Left
        Pnl2.Visible = False
        Controls.Add(DGL2)
        DGL2.Visible = True
        DGL2.BringToFront()
        With AgCL
            .AddAgTextColumn(DGL2, "DGL2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "DGL2Item_Nature2", 200, 20, ClsMain.Item_Nature2_Description, True, False, False)
            .AddAgTextColumn(DGL2, "DGL2Code", 40, 10, "Code", False, True, False)
        End With
        DGL2.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom)
        AgL.FSetSNo(DGL2, Col_SNo)
        DGL2.TabIndex = Pnl2.TabIndex
        DGL2.ColumnHeadersDefaultCellStyle.Font = New Font(New FontFamily("Arial"), 9)
        DGL2.DefaultCellStyle.Font = New Font(New FontFamily("Arial"), 8)
        DGL2.ColumnHeadersHeight = 25
        DGL2.Visible = False
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
            AgL.WinSetting(Me, 450, 880, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
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
        mQry = "Select Code As SearchCode " & _
                " From Store_Item " & _
                " Where 1=1 And MasterType = " & AgL.Chk_Text(ItemType) & "  "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
             " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Distinct I.ManualCode As Code, I.ManualCode As Name " & _
                    " From Store_Item I " & _
                    " Where I.MasterType = " & AgL.Chk_Text(ItemType) & " " & _
                    " And IsNull(I.ManualCode,'') <> '' " & _
                    " Order By I.ManualCode"
            TxtManualCode.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Distinct I.DisplayName As Code, I.DisplayName As Name " & _
                    " From Store_Item I " & _
                    " Where I.MasterType = " & AgL.Chk_Text(ItemType) & " " & _
                    " And IsNull(I.DisplayName,'') <> '' " & _
                    " Order By I.DisplayName"
            TxtDisplayName.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select I.code As Code, I.Description As Name " & _
                    " From Store_Item I " & _
                    " Where I.MasterType = " & AgL.Chk_Text(ItemType) & " " & _
                    " Order By I.Description"
            TxtDescription.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select U.Code As Code, U.Code As Name " & _
                    " From Store_Unit U " & _
                    " Order By U.Code "
            TxtUnit.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " Select '" & ClsMain.ItemNature.RawMaterial & "' as Code, '" & ClsMain.ItemNature.RawMaterial & "' as Name " & _
                    " Union All " & _
                    " Select '" & ClsMain.ItemNature.SemiFinished & "' as Code, '" & ClsMain.ItemNature.SemiFinished & "' as Name " & _
                    " Union All " & _
                    " Select '" & ClsMain.ItemNature.Finished & "' as Code, '" & ClsMain.ItemNature.Finished & "' as Name "
            TxtNature.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Ig.code As Code, Ig.Description As Name " & _
                    " From Store_Itemgroup Ig " & _
                    " Where Ig.MasterType = " & AgL.Chk_Text(ItemType) & " " & _
                    " Order By Ig.Description"
            TxtItemGroup.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Ig.code As Code, Ig.Description As Name " & _
                    " From Store_ItemCategory Ig " & _
                    " Where Ig.MasterType = " & AgL.Chk_Text(ItemType) & " " & _
                    " Order By Ig.Description"
            TxtItemCategory.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT P.Description AS Code, P.Description AS Name, " & _
                    " IsNull(P.Active,0) AS Active " & _
                    " FROM PostingGroupSalesTaxItem P With (NoLock)" & _
                    " Order By P.Description "
            TxtSalesTaxPostingGroup.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GcnRead)

            'Changed by akash on date 18-9-10
            mQry = "SELECT DISTINCT N1.Description AS Code , N1.Description AS Name   " & _
                   "FROM Store_Item_Nature1 N1 ORDER BY N1.Code  "
            DGL1.AgHelpDataSet(Col1Item_Nature1, , , , , True) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT N1.Description AS Code , N1.Description AS Name   " & _
                   "FROM Store_Item_Nature2 N1 ORDER BY N1.Code  "
            DGL2.AgHelpDataSet(Col1Item_Nature1, , , , , True) = AgL.FillData(mQry, AgL.GCn)
            'End change
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        Try
            BlankText()
            DispText(True)

            If DtMess_Enviro.Rows.Count = 0 Then
                MsgBox("Please Define Environment Settings!...", MsgBoxStyle.Information)
                Topctrl1.FButtonClick(14, True)
                Exit Sub
            End If

            TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
            TxtSalesTaxPostingGroup.AgSelectedValue = AgL.XNull(DtMess_Enviro.Rows(0)("SalesTaxGroupItem"))

            TxtManualCode.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    mQry = "Delete From Store_Item_Nature1 Where Item = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Delete From Store_Item_Nature2 Where Item = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Delete From Store_Item Where CODE = '" & mSearchCode & "'"
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
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try
            AgL.PubFindQry = "Select H.Code As SearchCode, H.DisplayName As [" & LblDisplayName.Text & "], " & _
                                " H.ManualCode As [" & LblManualCode.Text & "], H.Description, " & _
                                " G.Description AS [Item Group], C.Description As [Item Category], H.Nature, H.Unit, " & _
                                " H.PurchaseRate, H.SaleRate, H.MRP, H.Site_Code " & _
                                " From  Store_Item H WITH (NoLock) " & _
                                " LEFT JOIN Store_ItemCategory C WITH (NoLock) ON C.Code = H.ItemCategory  " & _
                                " LEFT JOIN Store_ItemGroup G WITH (NoLock) ON G.Code = H.ItemGroup  " & _
                                " Where H.MasterType = " & AgL.Chk_Text(ItemType) & " "

            AgL.PubFindQryOrdBy = "[" & LblDisplayName.Text & "]"


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
        Call PrintDocument()
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer
        Dim mTrans As Boolean = False
        Dim bItem_Nature1Code$ = "", bItem_Nature2Code$ = ""
        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO dbo.Store_Item ( " & _
                        " Code, Description, ManualCode, ItemGroup, Unit, PcsPerCase, ReOrderLevel, " & _
                        " MRP, PurchaseRate, SaleRate, DisplayName, ItemCategory, MasterType, Nature,  " & _
                        " SalesTaxPostingGroup, " & _
                        " Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES( " & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(TxtDescription.Text) & ", " & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtItemGroup.AgSelectedValue) & ", " & AgL.Chk_Text(TxtUnit.AgSelectedValue) & ", " & Val(TxtPcsPerCase.Text) & ", " & _
                        " " & Val(TxtReOrderLevel.Text) & ", " & Val(TxtMRP.Text) & ", " & Val(TxtPurchaseRate.Text) & ", " & Val(TxtSaleRate.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtDisplayName.Text) & ", " & AgL.Chk_Text(TxtItemCategory.AgSelectedValue) & ", " & AgL.Chk_Text(ItemType) & ", " & _
                        " " & AgL.Chk_Text(TxtNature.Text) & ", " & AgL.Chk_Text(TxtSalesTaxPostingGroup.AgSelectedValue) & " ," & _
                        " " & AgL.Chk_Text(AgL.PubDivCode) & ",  " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & "," & AgL.ConvertDate(AgL.PubLoginDate) & ",'A') "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "UPDATE Store_Item " & _
                        " SET " & _
                        " ItemCategory =  " & AgL.Chk_Text(TxtItemCategory.AgSelectedValue) & ", " & _
                        " ItemGroup =  " & AgL.Chk_Text(TxtItemGroup.AgSelectedValue) & ", " & _
                        " Unit =  " & AgL.Chk_Text(TxtUnit.AgSelectedValue) & ", " & _
                        " DisplayName =" & AgL.Chk_Text(TxtDisplayName.Text) & ", " & _
                        " Description =" & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                        " Manualcode=" & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
                        " PurchaseRate=" & Val(TxtPurchaseRate.Text) & "," & _
                        " SaleRate=" & Val(TxtSaleRate.Text) & ", " & _
                        " PcsPerCase=" & Val(TxtPcsPerCase.Text) & "," & _
                        " ReOrderLevel=" & Val(TxtReOrderLevel.Text) & ", " & _
                        " MRP=" & Val(TxtMRP.Text) & ",Nature=" & AgL.Chk_Text(TxtNature.Text) & ", " & _
                        " SalesTaxPostingGroup =  " & AgL.Chk_Text(TxtSalesTaxPostingGroup.AgSelectedValue) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ", " & _
                        " ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & "  " & _
                        " Where Code = '" & mSearchCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Code, I).Value = "" Then
                        If .Item(Col1Item_Nature1, I).Value.ToString.Trim <> "" Then
                            bItem_Nature1Code = AgL.GetMaxId("Store_Item_Nature1", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)

                            mQry = "INSERT INTO Store_Item_Nature1 ( " & _
                                    " Code, Item, Description	) " & _
                                    " VALUES ( " & _
                                    " '" & bItem_Nature1Code & "', '" & mSearchCode & "', " & _
                                    " " & AgL.Chk_Text(.Item(Col1Item_Nature1, I).Value) & ")"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If .Item(Col1Item_Nature1, I).Value.ToString.Trim <> "" Then
                            mQry = "UPDATE Store_Item_Nature1 SET " & _
                                    " Description = " & AgL.Chk_Text(.Item(Col1Item_Nature1, I).Value) & " " & _
                                    " WHERE Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            mQry = "Delete From Store_Item_Nature1 Where Code = '" & .Item(Col1Code, I).Value & "'"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    End If
                Next I
            End With


            With DGL2
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2Code, I).Value = "" Then
                        If .Item(Col2Item_Nature2, I).Value.ToString.Trim <> "" Then
                            bItem_Nature2Code = AgL.GetMaxId("Store_Item_Nature2", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)

                            mQry = "INSERT INTO Store_Item_Nature2 ( " & _
                                    " Code, Item, Description	) " & _
                                    " VALUES ( " & _
                                    " '" & bItem_Nature2Code & "', '" & mSearchCode & "', " & _
                                    " " & AgL.Chk_Text(.Item(Col2Item_Nature2, I).Value) & ")"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If .Item(Col2Item_Nature2, I).Value.ToString.Trim <> "" Then
                            mQry = "UPDATE Store_Item_Nature2 SET " & _
                                    " Description = " & AgL.Chk_Text(.Item(Col2Item_Nature2, I).Value) & " " & _
                                    " WHERE Code = " & AgL.Chk_Text(.Item(Col2Code, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            mQry = "Delete From Store_Item_Nature2 Where Code = '" & .Item(Col2Code, I).Value & "'"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
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
                mQry = "Select SI.* " & _
                        " From Store_Item Si " & _
                        " Where SI.Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtDisplayName.Text = AgL.XNull(.Rows(0)("DisplayName"))
                        TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                        TxtManualCode.Text = AgL.XNull(.Rows(0)("Manualcode"))
                        TxtItemCategory.AgSelectedValue = AgL.XNull(.Rows(0)("ItemCategory"))
                        TxtItemGroup.AgSelectedValue = AgL.XNull(.Rows(0)("ItemGroup"))
                        TxtUnit.AgSelectedValue = AgL.XNull(.Rows(0)("Unit"))
                        TxtPurchaseRate.Text = Format(AgL.VNull(.Rows(0)("PurchaseRate")), "0.00")
                        TxtSaleRate.Text = Format(AgL.VNull(.Rows(0)("SaleRate")), "0.00")
                        TxtMRP.Text = Format(AgL.VNull(.Rows(0)("MRP")), "0.00")
                        TxtReOrderLevel.Text = AgL.VNull(.Rows(0)("ReOrderLevel"))
                        TxtPcsPerCase.Text = AgL.VNull(.Rows(0)("PcsPerCase"))
                        TxtNature.Text = AgL.XNull(.Rows(0)("Nature"))
                        TxtSalesTaxPostingGroup.AgSelectedValue = AgL.XNull(.Rows(0)("SalesTaxPostingGroup"))


                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)

                    End If
                End With

                mQry = "Select SN.* " & _
                        " From Store_Item_Nature1 SN " & _
                        " Where Sn.Item='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.Item(Col1Item_Nature1, I).Value = AgL.XNull(.Rows(I)("Description"))
                            DGL1.Item(Col1Code, I).Value = AgL.XNull(.Rows(I)("Code"))
                        Next I
                    End If
                End With


                mQry = "Select SN.* " & _
                       " From Store_Item_Nature2 SN " & _
                       " Where Sn.Item='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL2.RowCount = 1
                    DGL2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count - 1
                            DGL2.Item(Col2Item_Nature2, I).Value = AgL.XNull(.Rows(I)("Description"))
                            DGL2.Item(Col2Code, I).Value = AgL.XNull(.Rows(I)("Code"))
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
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes()
        mSearchCode = ""

        TxtPcsPerCase.Text = 1


        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Item_Nature1

            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL2_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL2.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL2.CurrentCell.ColumnIndex
                Case Col2Item_Nature2

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

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL2.CurrentCell.ColumnIndex
            End Select


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

    Private Sub DGL2_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGL2.EditingControlShowing
        If Topctrl1.Mode = "Browse" Then Exit Sub
        If TypeOf e.Control Is ComboBox Then
            e.Control.Text = ""
        End If
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown, DGL2.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
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
         TxtItemGroup.Enter, TxtSalesTaxPostingGroup.Enter
        Try
            Select Case sender.name
                Case TxtSalesTaxPostingGroup.Name
                    TxtSalesTaxPostingGroup.AgRowFilter = " Active <> 0 "

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtItemGroup.Validating, TxtUnit.Validating, TxtDescription.Validating, TxtManualCode.Validating, TxtMRP.Validating, _
        TxtSaleRate.Validating, TxtPurchaseRate.Validating, TxtPcsPerCase.Validating, TxtSite_Code.Validating, TxtDisplayName.Validating, _
        TxtItemCategory.Validating, TxtSalesTaxPostingGroup.Validating

        Try
            Select Case sender.NAME
                Case TxtSaleRate.Name
                    If TxtMRP.Text Is Nothing Then TxtMRP.Text = ""

                Case TxtDisplayName.Name, TxtManualCode.Name
                    If TxtDisplayName.Text = "" Then TxtDisplayName.Text = TxtManualCode.Text

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0
        Try
            TxtDescription.Text = TxtDisplayName.Text
            If AgL.RequiredField(TxtDisplayName, LblDisplayName.Text) Then Exit Function
            If AgL.RequiredField(TxtManualCode, LblManualCode.Text) Then Exit Function
            If AgL.RequiredField(TxtItemCategory, LblItemCategory.Text) Then Exit Function
            If AgL.RequiredField(TxtItemGroup, LblItemGroup.Text) Then Exit Function
            If AgL.RequiredField(TxtNature, LblNature.Text) Then Exit Function
            If AgL.RequiredField(TxtUnit, LblUnit.Text) Then Exit Function

            If Val(TxtPcsPerCase.Text) = 0 Then TxtPcsPerCase.Text = 1

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsDuplicate(DGL1, "" & Col1Item_Nature1 & "") Then Exit Function

            AgCL.AgBlankNothingCells(DGL2)
            If AgCL.AgIsDuplicate(DGL2, "" & Col2Item_Nature2 & "") Then Exit Function


            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Store_Item Where ManualCode='" & TxtManualCode.Text & "' And MasterType = " & AgL.Chk_Text(ItemType) & " ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function

                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Store_Item Where DisplayName='" & TxtDisplayName.Text & "'  And MasterType = " & AgL.Chk_Text(ItemType) & " ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then
                    If MsgBox("Item Name Already Exist!" & vbCrLf & "Do You Want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                        TxtDescription.Text = TxtDisplayName.Text + "-" + TxtManualCode.Text
                    Else
                        TxtDisplayName.Focus() : Exit Function
                    End If
                End If


                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Store_Item Where Description='" & TxtDescription.Text & "'  And MasterType = " & AgL.Chk_Text(ItemType) & " ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Function

                mSearchCode = AgL.GetMaxId("Store_Item", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Store_Item Where ManualCode='" & TxtManualCode.Text & "'  And MasterType = " & AgL.Chk_Text(ItemType) & " And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function


                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Store_Item Where DisplayName='" & TxtDisplayName.Text & "'  And MasterType = " & AgL.Chk_Text(ItemType) & " And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then
                    If MsgBox("Item Name Already Exist!" & vbCrLf & "Do You Want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                        TxtDescription.Text = TxtDisplayName.Text + "-" + TxtManualCode.Text
                    Else
                        TxtDisplayName.Focus() : Exit Function
                    End If
                End If

                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Store_Item Where Description='" & TxtDescription.Text & "'  And MasterType = " & AgL.Chk_Text(ItemType) & " And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Function
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function
    ' **********   code by satyam on 18/9/2010

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

            AgL.PubReportTitle = "other information"
            RepName = "Store_ItemMaster" : RepTitle = "Item Master"

            mQry = " SELECT i.Code,i.Description,i.ManualCode,i.ItemGroup,i.PcsPerCase,i.ReOrderLevel,i.MRP," & _
                   " i.PurchaseRate,i.Div_Code,i.Site_Code,i.PreparedBy,i.U_EntDt,i.U_AE,i.Edit_Date,i.ModifiedBy,i.SaleRate," & _
                   " ig.Description as ItemGroup,ig.ManualCode as GroupCode,ig.ItemCategory,ic.Description as Category,ic.ManualCode as CategoryCode,u.Description as unit" & _
                   " FROM Store_Item i" & _
                   " LEFT JOIN Store_ItemGroup ig ON i.ItemGroup=ig.Code" & _
                   " LEFT JOIN Store_Unit u ON i.unit=u.Code" & _
                   " LEFT JOIN Store_ItemCategory ic ON ig.ItemCategory=ic.Code " & _
                   " Where I.MasterType = " & AgL.Chk_Text(ItemType) & " "

            mQry1 = "SELECT item,'" & ClsMain.Item_Nature1_Description & "' AS nature1,description FROM Store_Item_Nature1"
            mQry2 = "SELECT item,'" & ClsMain.Item_Nature2_Description & "' AS nature2,description FROM Store_Item_Nature2"

            DsRep = AgL.FillData(mQry, AgL.GCn)

            DsRep1 = AgL.FillData(mQry1, AgL.GCn)
            DsRep2 = AgL.FillData(mQry2, AgL.GCn)


            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath_Store & "\" & RepName & ".ttx", True)
            AgPL.CreateFieldDefFile1(DsRep1, AgL.PubReportPath_Store & "\" & RepName & "1.ttx", True)
            AgPL.CreateFieldDefFile1(DsRep2, AgL.PubReportPath_Store & "\" & RepName & "2.ttx", True)

            mCrd.Load(AgL.PubReportPath_Store & "\" & RepName & ".rpt")
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
    ' **********   End code by satyam on 18/9/2010

End Class
