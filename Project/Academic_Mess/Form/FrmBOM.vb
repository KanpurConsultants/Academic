Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmBOM
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Col1Item As String = "Item"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1ConsumptionPer As String = "Consumption %"

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
                .AddAgTextColumn(DGL1, Col1Item, 280, 0, Col1Item, True, False, False)
                .AddAgTextColumn(DGL1, Col1Unit, 80, 0, Col1Unit, True, True, False)
                .AddAgNumberColumn(DGL1, Col1ConsumptionPer, 90, 3, 2, False, Col1ConsumptionPer, True, False, True)
                .AddAgNumberColumn(DGL1, Col1Qty, 100, 8, 3, False, Col1Qty, True, False, True)
            End With
            AgL.AddAgDataGrid(DGL1, Pnl1)
            DGL1.EnableHeadersVisualStyles = False
            DGL1.AgSkipReadOnlyColumns = True
            DGL1.Anchor = AnchorStyles.None
            PnlFooter.Anchor = DGL1.Anchor
            DGL1.ColumnHeadersHeight = 40

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
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
        Catch ex As Exception

        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Try
            If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
            If Me.ActiveControl Is Nothing Then Exit Sub
            AgL.CheckQuote(e)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 600, 1000, 0, 0)
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
        mQry = "Select H.Code As SearchCode " & _
                " From Store_Bom H  With (NoLock) " & _
                " Where 1=1 And MasterType = " & AgL.Chk_Text(ItemType) & "  "
        Topctrl1.FIniForm(DTMaster, AgL.GcnRead, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name " & _
                    " From SiteMast With (NoLock) " & _
                    " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "Select Div_Code, Div_Name From Division  With (NoLock) Order By Div_Name"
            TxtDivision.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "Select I.code As Code, I.Description As Name, I.Unit, I.Nature, I.MasterType " & _
                    " From Store_Item I  With (NoLock) " & _
                    " Where I.MasterType = " & AgL.Chk_Text(ItemType) & " " & _
                    " Order By I.Description"
            TxtForItem.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GcnRead)
            DGL1.AgHelpDataSet(Col1Item, 3) = TxtForItem.AgHelpDataSet.Copy

            mQry = "Select U.Code As Code, U.Code As Name " & _
                    " From Store_Unit U  With (NoLock) " & _
                    " Order By U.Code "
            TxtForUnit.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)
            DGL1.AgHelpDataSet(Col1Unit, 0) = TxtForUnit.AgHelpDataSet.Copy

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        Try
            BlankText()
            DispText(True)

            TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
            TxtDivision.AgSelectedValue = AgL.PubDivCode

            TxtForItem.Focus()
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

                    mQry = "Delete From Store_BomDetail Where Code = '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    mQry = "Delete From Store_Bom Where CODE = '" & mSearchCode & "'"
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
        TxtForItem.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        Try
            AgL.PubFindQry = "SELECT H.Code AS SearchCode, " & _
                                " I.Description As [" & LblForItem.Text & "], " & _
                                " H.ForQty As [" & LblForQty.Text & "], " & _
                                " H.ForWeight As [" & LblForWeight.Text & "] " & _
                                " FROM Store_BOM H " & _
                                " LEFT JOIN Store_Item I ON I.Code = H.ForItem  " & _
                                " Where H.MasterType = " & AgL.Chk_Text(ItemType) & " "

            AgL.PubFindQryOrdBy = "[" & LblForItem.Text & "]"


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
        Dim bIntI As Integer = 0, bIntSr% = 0
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
                mQry = "INSERT INTO dbo.Store_BOM (" & _
                        " Code, Description, MasterType, ForItem, ForUnit, ForQty, ForWeight, TotalQty, " & _
                        " Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ( " & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & _
                        " " & AgL.Chk_Text(TxtDescription.Text) & ",  " & _
                        " " & AgL.Chk_Text(ItemType) & ", " & _
                        " " & AgL.Chk_Text(TxtForItem.AgSelectedValue) & ",  " & _
                        " " & AgL.Chk_Text(TxtForUnit.AgSelectedValue) & ",  " & _
                        " " & Val(TxtForQty.Text) & ", " & _
                        " " & Val(TxtForWeight.Text) & ", " & _
                        " " & Val(LblValTotalQty.Text) & ",  " & _
                        " " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ",  " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & "," & AgL.ConvertDate(AgL.PubLoginDate) & ",'A') "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "UPDATE dbo.Store_BOM " & _
                        " SET Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                        " MasterType = " & AgL.Chk_Text(ItemType) & ", " & _
                        " ForItem = " & AgL.Chk_Text(TxtForItem.AgSelectedValue) & ", " & _
                        " ForUnit = " & AgL.Chk_Text(TxtForUnit.AgSelectedValue) & ", " & _
                        " ForQty = " & Val(TxtForQty.Text) & ", " & _
                        " ForWeight = " & Val(TxtForWeight.Text) & ", " & _
                        " TotalQty = " & Val(LblValTotalQty.Text) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ", " & _
                        " ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & "  " & _
                        " Where Code = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                mQry = "Delete From Store_BomDetail Where Code = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bIntSr = 0

                For bIntI = 0 To .Rows.Count - 1
                    If .Item(Col1Item, bIntI).Value.ToString.Trim <> "" Then
                        bIntSr += 1

                        mQry = "INSERT INTO dbo.Store_BomDetail ( " & _
                                " Code, Sr, Item, Unit, Qty, ConsumptionPer) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & bIntSr & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1Item, bIntI)) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1Unit, bIntI)) & ", " & _
                                " " & Val(.Item(Col1Qty, bIntI).Value) & ", " & _
                                " " & Val(.Item(Col1ConsumptionPer, bIntI).Value) & " " & _
                                " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next bIntI
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
        Dim bIntI As Integer
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select H.* " & _
                        " From Store_Bom H With (NoLock) " & _
                        " Where H.Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GcnRead)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtForItem.AgSelectedValue = AgL.XNull(.Rows(0)("ForItem"))
                        TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                        TxtForUnit.AgSelectedValue = AgL.XNull(.Rows(0)("ForUnit"))
                        TxtForQty.Text = Format(AgL.VNull(.Rows(0)("ForQty")), "0.000")
                        TxtForWeight.Text = Format(AgL.VNull(.Rows(0)("ForWeight")), "0.000")
                        LblValTotalQty.Text = Format(AgL.VNull(.Rows(0)("TotalQty")), "0.000")

                        TxtDivision.AgSelectedValue = AgL.XNull(.Rows(0)("Div_Code"))
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))


                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select L.* " & _
                        " From Store_BomDetail L  With (NoLock) " & _
                        " Where L.Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GcnRead)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For bIntI = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, bIntI).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1Item, bIntI) = AgL.XNull(.Rows(bIntI)("Item"))
                            DGL1.AgSelectedValue(Col1Unit, bIntI) = AgL.XNull(.Rows(bIntI)("Unit"))
                            DGL1.Item(Col1Qty, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("Qty")), "0.000")
                            DGL1.Item(Col1ConsumptionPer, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("ConsumptionPer")), "0.00")
                        Next bIntI
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

        TxtForQty.Text = 1 : TxtForWeight.Text = 1

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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
         TxtForUnit.Enter, TxtForItem.Enter, TxtForQty.Enter, TxtDivision.Enter, _
         TxtSite_Code.Enter, TxtForWeight.Enter

        Dim bStrRowFilter$ = ""

        Try
            Select Case sender.name
                Case TxtForItem.Name
                    bStrRowFilter = " 1=1 "
                    bStrRowFilter += " And MasterType = '" & ClsMain.ItemType.Mess & "' "
                    bStrRowFilter += " And Nature = '" & ClsMain.ItemNature.Finished & "' "

                    TxtForItem.AgRowFilter = bStrRowFilter
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
         TxtForUnit.Validating, TxtForItem.Validating, TxtForQty.Validating, TxtDivision.Validating, _
         TxtSite_Code.Validating, TxtForWeight.Validating

        Try
            Select Case sender.NAME
                Case TxtForItem.Name
                    Call ProcValidatingControls(sender)

            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bIntI As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtForItem, LblForItem.Text) Then Exit Function
            If AgL.RequiredField(TxtForQty, LblForQty.Text, True) Then Exit Function
            If AgL.RequiredField(TxtForWeight, LblForWeight.Text, True) Then Exit Function
            If AgL.RequiredField(TxtForUnit, LblForUnit.Text) Then Exit Function

            TxtDescription.Text = TxtForItem.Text

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Item).Index) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & DGL1.Columns(Col1Item).Index & "") Then Exit Function

            For bIntI = 0 To DGL1.RowCount - 1
                If DGL1.Item(Col1Qty, bIntI).Value Is Nothing Then DGL1.Item(Col1Qty, bIntI).Value = ""

                If DGL1.Item(Col1Item, bIntI).Value <> "" Then
                    If Val(DGL1.Item(Col1Qty, bIntI).Value) = 0 Then
                        MsgBox("Item Quantity Is Required At Row No. : " & DGL1.Item(ColSNo, bIntI).Value & "!...")
                        DGL1.CurrentCell = DGL1(Col1Qty, bIntI) : DGL1.Focus() : Exit Function
                    End If
                End If
            Next

            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Store_Bom Where ForItem ='" & TxtForItem.AgSelectedValue & "' And MasterType = " & AgL.Chk_Text(ItemType) & " ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("BOM Already Exist!") : TxtForItem.Focus() : Exit Function

                mSearchCode = AgL.GetMaxId("Store_Bom", "Code", AgL.GCn, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Store_Bom Where ForItem='" & TxtForItem.AgSelectedValue & "'  And MasterType = " & AgL.Chk_Text(ItemType) & " And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtForItem.Focus() : Exit Function
            End If

            
            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function
    ' **********   code by satyam on 18/9/2010

    Private Sub PrintDocument()
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor

            'AgL.PubReportTitle = Me.Text

            'RepName = "Store_ItemMaster" : RepTitle = "Item Master"

            'mQry = " SELECT i.Code,i.Description,i.ManualCode,i.ItemGroup,i.PcsPerCase,i.ReOrderLevel,i.MRP," & _
            '       " i.PurchaseRate,i.Div_Code,i.Site_Code,i.PreparedBy,i.U_EntDt,i.U_AE,i.Edit_Date,i.ModifiedBy,i.SaleRate," & _
            '       " ig.Description as ItemGroup,ig.ManualCode as GroupCode,ig.ItemCategory,ic.Description as Category,ic.ManualCode as CategoryCode,u.Description as unit" & _
            '       " FROM Store_Item i" & _
            '       " LEFT JOIN Store_ItemGroup ig ON i.ItemGroup=ig.Code" & _
            '       " LEFT JOIN Store_Unit u ON i.unit=u.Code" & _
            '       " LEFT JOIN Store_ItemCategory ic ON ig.ItemCategory=ic.Code " & _
            '       " Where I.MasterType = " & AgL.Chk_Text(ItemType) & " "

            'DsRep = AgL.FillData(mQry, AgL.GCn)



            'AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath_Store & "\" & RepName & ".ttx", True)

            'mCrd.Load(AgL.PubReportPath_Store & "\" & RepName & ".rpt")
            'mCrd.SetDataSource(DsRep.Tables(0))


            'CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd

            'PLib.Formula_Set(mCrd, RepTitle)
            'AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            'Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    ' **********   End code by satyam on 18/9/2010

    Public Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    DGL1.AgRowFilter(mColumnIndex) = " MasterType = '" & ClsMain.ItemType.Mess & "' "
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
                    Case Col1Item
                        If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                            DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                            DGL1.AgSelectedValue(Col1Unit, mRowIndex) = ""
                        Else
                            If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
                                DGL1.AgSelectedValue(Col1Unit, mRowIndex) = AgL.XNull(DrTemp(0)("Unit"))
                            End If
                            DrTemp = Nothing
                        End If
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Public Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
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

    Sub Calculation()
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

        Dim bIntI% = 0

        LblValTotalQty.Text = ""
        
        For bIntI = 0 To DGL1.RowCount - 1
            If DGL1.Item(Col1Item, bIntI).Value Is Nothing Then DGL1.Item(Col1Item, bIntI).Value = ""
            If DGL1.Item(Col1Unit, bIntI).Value Is Nothing Then DGL1.Item(Col1Unit, bIntI).Value = ""
            If DGL1.Item(Col1Qty, bIntI).Value Is Nothing Then DGL1.Item(Col1Qty, bIntI).Value = ""

            If DGL1.Item(Col1Item, bIntI).Value <> "" Then
                If Val(DGL1.Item(Col1ConsumptionPer, bIntI).Value) > 0 Then
                    DGL1.Item(Col1Qty, bIntI).Value = Format(Val(TxtForWeight.Text) * Val(DGL1.Item(Col1ConsumptionPer, bIntI).Value) * 0.01, "0.000")
                End If

                LblValTotalQty.Text = Val(LblValTotalQty.Text) + Val(DGL1.Item(Col1Qty, bIntI).Value)
            End If
        Next
        LblValTotalQty.Text = Format(Val(LblValTotalQty.Text), "0.000")
    End Sub

    Private Function ProcValidatingControls(ByVal Sender As Object) As Boolean
        Dim bBlnReturn As Boolean = False
        Dim DrTemp As DataRow() = Nothing

        Try
            Select Case Sender.Name
                Case TxtForItem.Name
                    If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                        Sender.AgSelectedValue = ""
                        TxtDescription.Text = ""
                        TxtForUnit.AgSelectedValue = ""
                    Else
                        If Sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                            TxtDescription.Text = AgL.XNull(DrTemp(0)("Name"))
                            TxtForUnit.AgSelectedValue = AgL.XNull(DrTemp(0)("Unit"))
                        End If
                    End If
                    DrTemp = Nothing
            End Select

            bBlnReturn = True
        Catch ex As Exception
            bBlnReturn = False
            MsgBox(ex.Message)
        Finally
            ProcValidatingControls = bBlnReturn
        End Try
    End Function
End Class
