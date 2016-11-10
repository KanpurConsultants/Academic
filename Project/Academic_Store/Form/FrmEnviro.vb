Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmEnviro
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

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
            AgL.WinSetting(Me, 550, 897, 0, 0)
            IniGrid()
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
            Topctrl1.tEdit = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "Select Site_Code As SearchCode " & _
                " From Store_Enviro " & _
                " Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & ""
        Topctrl1.FIniForm(DTMaster, AgL.Gcn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        mQry = "Select Sg.SubCode As Code, Sg.Name As Name From SubGroup Sg " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                " Order By Sg.Name"
        AgCL.IniAgHelpList(AgL.GCn, CboPurchaseAc, mQry, "Name", "Code")
        AgCL.IniAgHelpList(AgL.GCn, CboPurchaseAdditionAc, mQry, "Name", "Code")
        AgCL.IniAgHelpList(AgL.GCn, CboPurchaseDeductionAc, mQry, "Name", "Code")
        AgCL.IniAgHelpList(AgL.GCn, CboPurchaseAddition_HAc, mQry, "Name", "Code")
        AgCL.IniAgHelpList(AgL.GCn, CboPurchaseDeduction_HAc, mQry, "Name", "Code")
        AgCL.IniAgHelpList(AgL.GCn, CboSaleAc, mQry, "Name", "Code")
        AgCL.IniAgHelpList(AgL.GCn, CboSaleAdditionAc, mQry, "Name", "Code")
        AgCL.IniAgHelpList(AgL.GCn, CboSaleDeductionAc, mQry, "Name", "Code")
        AgCL.IniAgHelpList(AgL.GCn, CbosaleAddition_HAc, mQry, "Name", "Code")
        AgCL.IniAgHelpList(AgL.GCn, CboSaleDeduction_HAc, mQry, "Name", "Code")

        mQry = "Select Code As Code,  ManualCode Name " & _
                " From Store_Godown " & _
                " Where 1=1 " & _
                " Order By ManualCode"
        TxtGodown.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
        mQry = "SELECT P.Description AS Code, P.Description AS Name, " & _
                  " IsNull(P.Active,0) AS Active " & _
                  " FROM PostingGroupSalesTaxItem P With (NoLock)" & _
                  " Order By P.Description "
        TxtSalesTaxGroupItem.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GcnRead)


        mQry = "SELECT P.Description AS Code, P.Description AS Name, " & _
                " IsNull(P.Active,0) AS Active " & _
                " FROM PostingGroupSalesTaxParty P With (NoLock)" & _
                " Order By P.Description "
        TxtSalesTaxGroupParty.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GcnRead)

    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        CboPurchaseAc.Focus()
    End Sub
    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        'Dim BlnTrans As Boolean = False
        'Dim GCnCmd As New SqlClient.SqlCommand
        'Dim MastPos As Long
        'Dim mTrans As Boolean = False


        'Try
        '    MastPos = BMBMaster.Position


        '    If DTMaster.Rows.Count > 0 Then
        '        If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


        '            AgL.ECmd = AgL.Gcn.CreateCommand
        '            AgL.ETrans = AgL.Gcn.BeginTransaction(IsolationLevel.ReadCommitted)
        '            AgL.ECmd.Transaction = AgL.ETrans
        '            mTrans = True
        '            AgL.Dman_ExecuteNonQry("Delete From Enviro Where ID='" & mSearchCode & "'", AgL.Gcn, AgL.ECmd)


        '            Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.Gcn, AgL.ECmd)

        '            AgL.ETrans.Commit()
        '            mTrans = False


        '            FIniMaster(1)
        '            Topctrl1_tbRef()
        '            MoveRec()
        '        End If
        '    End If
        'Catch Ex As Exception
        '    If mTrans = True Then AgL.ETrans.Rollback()
        '    MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        'End Try
    End Sub
    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub


    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        CboPurchaseAc.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = "Select  Site_Code As SearchCode,  SubGroup1.Name As [Cash A/c],  SubGroup2.Name As [Bank A/c],  SubGroup3.Name As [TDS A/c]  From  Store_Enviro  Left Join  SubGroup SubGroup1 On SubGroup1.SubCode = Store_Enviro.mmCashAc  Left Join  SubGroup SubGroup2 On SubGroup2.SubCode = Enviro.BankAc  Left Join  SubGroup SubGroup3 On SubGroup3.SubCode = Enviro.TdsAc "


            AgL.PubFindQryOrdBy = "[Cash A/c]"



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

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Try
            MastPos = BMBMaster.Position

            If AgL.RequiredField(CboPurchaseAc) Then Exit Sub


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Store_Enviro " & _
                        " (Site_Code,PurchaseAc,PurchaseAdditionAc,PurchaseDeductionAc,PurchaseAddition_HAc,PurchaseDeduction_HAc,SaleAc,SaleAdditionAc,SaleDeductionAc,SaleAddition_HAc,SaleDeduction_HAc,PurchaseAddition_Text,PurchaseDeduction_Text,PurchaseAddition_H_Text,PurchaseDeduction_H_Text,SaleAddition_Text,SaleDeduction_Text,SaleAddition_H_Text,SaleDeduction_H_Text,Item_Nature1_Text,Item_Nature2_Text, ItemBatch_Text, Godown, " & _
                        " PreparedBy, U_EntDt, U_AE , SalesTaxGroupItem, SalesTaxGroupParty,IsItemNature) " & _
                        " VALUES " & _
                        " (" & AgL.Chk_Text(AgL.PubSiteCode) & "," & AgL.Chk_Text(CboPurchaseAc.SelectedValue) & "," & AgL.Chk_Text(CboPurchaseAdditionAc.SelectedValue) & "," & AgL.Chk_Text(CboPurchaseDeductionAc.SelectedValue) & "," & AgL.Chk_Text(CboPurchaseAddition_HAc.SelectedValue) & "," & AgL.Chk_Text(CboPurchaseDeduction_HAc.SelectedValue) & "," & AgL.Chk_Text(CboSaleAc.SelectedValue) & "," & AgL.Chk_Text(CboSaleAdditionAc.SelectedValue) & "," & AgL.Chk_Text(CboSaleDeductionAc.SelectedValue) & "," & AgL.Chk_Text(CbosaleAddition_HAc.SelectedValue) & "," & AgL.Chk_Text(CboSaleDeduction_HAc.SelectedValue) & "," & AgL.Chk_Text(TxtPurchaseAdditionText.Text) & "," & AgL.Chk_Text(TxtPurchaseDeductionText.Text) & "," & AgL.Chk_Text(TxtPurchaseAdditionHeaderText.Text) & "," & AgL.Chk_Text(TxtPurchaseDeductionHeaderText.Text) & "," & AgL.Chk_Text(TxtSaleAdditionText.Text) & "," & AgL.Chk_Text(TxtSaleDeductionText.Text) & "," & AgL.Chk_Text(TxtSaleAddition_HText.Text) & "," & AgL.Chk_Text(TxtSaleDeduction_HText.Text) & "," & AgL.Chk_Text(TxtItemNature1Text.Text) & "," & AgL.Chk_Text(TxtItemNature2Text.Text) & "," & AgL.Chk_Text(TxtItemBatchText.Text) & ", " & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A', " & AgL.Chk_Text(TxtSalesTaxGroupItem.AgSelectedValue) & "," & AgL.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & "," & IIf(AgL.StrCmp(TxtIsItemNature.Text, "Yes"), 1, 0) & ")"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else

                mQry = "If Not Exists (Select * from Store_Enviro Where Site_Code = '" & AgL.PubSiteCode & "') "

                mQry = mQry & " INSERT INTO Store_Enviro " & _
                    "(Site_Code,PurchaseAc,PurchaseAdditionAc,PurchaseDeductionAc,PurchaseAddition_HAc,PurchaseDeduction_HAc,SaleAc,SaleAdditionAc,SaleDeductionAc,SaleAddition_HAc,SaleDeduction_HAc,PurchaseAddition_Text,PurchaseDeduction_Text,PurchaseAddition_H_Text,PurchaseDeduction_H_Text,SaleAddition_Text,SaleDeduction_Text,SaleAddition_H_Text,SaleDeduction_H_Text,Item_Nature1_Text,Item_Nature2_Text, ItemBatch_Text, Godown, " & _
                    " PreparedBy, U_EntDt, U_AE, SalesTaxGroupItem, SalesTaxGroupParty ,IsItemNature) " & _
                    " VALUES " & _
                    " (" & AgL.Chk_Text(AgL.PubSiteCode) & "," & AgL.Chk_Text(CboPurchaseAc.SelectedValue) & "," & AgL.Chk_Text(CboPurchaseAdditionAc.SelectedValue) & "," & AgL.Chk_Text(CboPurchaseDeductionAc.SelectedValue) & "," & AgL.Chk_Text(CboPurchaseAddition_HAc.SelectedValue) & "," & AgL.Chk_Text(CboPurchaseDeduction_HAc.SelectedValue) & "," & AgL.Chk_Text(CboSaleAc.SelectedValue) & "," & AgL.Chk_Text(CboSaleAdditionAc.SelectedValue) & "," & AgL.Chk_Text(CboSaleDeductionAc.SelectedValue) & "," & AgL.Chk_Text(CbosaleAddition_HAc.SelectedValue) & "," & AgL.Chk_Text(CboSaleDeduction_HAc.SelectedValue) & "," & AgL.Chk_Text(TxtPurchaseAdditionText.Text) & "," & AgL.Chk_Text(TxtPurchaseDeductionText.Text) & "," & AgL.Chk_Text(TxtPurchaseAdditionHeaderText.Text) & "," & AgL.Chk_Text(TxtPurchaseDeductionHeaderText.Text) & "," & AgL.Chk_Text(TxtSaleAdditionText.Text) & "," & AgL.Chk_Text(TxtSaleDeductionText.Text) & "," & AgL.Chk_Text(TxtSaleAddition_HText.Text) & "," & AgL.Chk_Text(TxtSaleDeduction_HText.Text) & "," & AgL.Chk_Text(TxtItemNature1Text.Text) & "," & AgL.Chk_Text(TxtItemNature2Text.Text) & "," & AgL.Chk_Text(TxtItemBatchText.Text) & ", " & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A', " & AgL.Chk_Text(TxtSalesTaxGroupItem.AgSelectedValue) & "," & AgL.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & "," & IIf(AgL.StrCmp(TxtIsItemNature.Text, "Yes"), 1, 0) & ")"

                mQry = mQry & " Else "
                mQry = mQry & " UPDATE Store_Enviro " & _
                        " SET PurchaseAc = " & AgL.Chk_Text(CboPurchaseAc.SelectedValue) & ", " & _
                         " PurchaseAdditionAc = " & AgL.Chk_Text(CboPurchaseAdditionAc.SelectedValue) & ", " & _
                         " PurchaseDeductionAc = " & AgL.Chk_Text(CboPurchaseDeductionAc.SelectedValue) & ", " & _
                         " PurchaseAddition_HAc = " & AgL.Chk_Text(CboPurchaseAddition_HAc.SelectedValue) & ", " & _
                         " PurchaseDeduction_HAc = " & AgL.Chk_Text(CboPurchaseDeduction_HAc.SelectedValue) & ", " & _
                         " SaleAc = " & AgL.Chk_Text(CboSaleAc.SelectedValue) & ", " & _
                         " SaleAdditionAc = " & AgL.Chk_Text(CboSaleAdditionAc.SelectedValue) & ", " & _
                         " SaleDeductionAc = " & AgL.Chk_Text(CboSaleDeductionAc.SelectedValue) & ", " & _
                         " SaleAddition_HAc = " & AgL.Chk_Text(CbosaleAddition_HAc.SelectedValue) & ", " & _
                         " SaleDeduction_HAc = " & AgL.Chk_Text(CboSaleDeduction_HAc.SelectedValue) & ", " & _
                         " PurchaseAddition_Text = " & AgL.Chk_Text(TxtPurchaseAdditionText.Text) & ", " & _
                         " PurchaseDeduction_Text = " & AgL.Chk_Text(TxtPurchaseDeductionText.Text) & ", " & _
                         " PurchaseAddition_H_Text = " & AgL.Chk_Text(TxtPurchaseAdditionHeaderText.Text) & ", " & _
                         " PurchaseDeduction_H_Text = " & AgL.Chk_Text(TxtPurchaseDeductionHeaderText.Text) & ", " & _
                         " SaleAddition_Text =" & AgL.Chk_Text(TxtSaleAdditionText.Text) & ", " & _
                         " SaleDeduction_Text = " & AgL.Chk_Text(TxtSaleDeductionText.Text) & ", " & _
                         " SaleAddition_H_Text = " & AgL.Chk_Text(TxtSaleAddition_HText.Text) & ", " & _
                         " SaleDeduction_H_Text = " & AgL.Chk_Text(TxtSaleDeduction_HText.Text) & ", " & _
                         " Item_Nature1_Text = " & AgL.Chk_Text(TxtItemNature1Text.Text) & ", " & _
                         " Item_Nature2_Text = " & AgL.Chk_Text(TxtItemNature2Text.Text) & ", " & _
                         " ItemBatch_Text = " & AgL.Chk_Text(TxtItemBatchText.Text) & ", " & _
                         " Godown = " & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ", " & _
                         " ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                         " Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ", " & _
                        " SalesTaxGroupParty = " & AgL.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & ", " & _
                        " SalesTaxGroupItem = " & AgL.Chk_Text(TxtSalesTaxGroupItem.AgSelectedValue) & ", " & _
                        " IsItemNature = " & IIf(AgL.StrCmp(TxtIsItemNature.Text, "Yes"), 1, 0) & ", " & _
                         " U_AE = 'E' " & _
                         " Where Site_Code = '" & AgL.PubSiteCode & "'"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)



            AgL.ETrans.Commit()
            mTrans = False

            Call IniDtStore_Enviro()

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
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select Enviro.* " & _
                    " From  Store_Enviro Enviro Where Site_Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.Gcn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        CboPurchaseAc.SelectedValue = AgL.XNull(.Rows(0)("PurchaseAc"))
                        CboPurchaseAdditionAc.SelectedValue = AgL.XNull(.Rows(0)("PurchaseAdditionAc"))
                        CboPurchaseDeductionAc.SelectedValue = AgL.XNull(.Rows(0)("PurchaseDeductionAc"))
                        CboPurchaseAddition_HAc.SelectedValue = AgL.XNull(.Rows(0)("PurchaseAddition_HAc"))
                        CboPurchaseDeduction_HAc.SelectedValue = AgL.XNull(.Rows(0)("PurchaseDeduction_HAc"))
                        CboSaleAc.SelectedValue = AgL.XNull(.Rows(0)("SaleAc"))
                        CboSaleAdditionAc.SelectedValue = AgL.XNull(.Rows(0)("SaleAdditionAc"))
                        CboSaleDeductionAc.SelectedValue = AgL.XNull(.Rows(0)("SaleDeductionAc"))
                        CbosaleAddition_HAc.SelectedValue = AgL.XNull(.Rows(0)("SaleAddition_HAc"))
                        CboSaleDeduction_HAc.SelectedValue = AgL.XNull(.Rows(0)("SaleDeduction_HAc"))
                        TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))
                        TxtSalesTaxGroupItem.AgSelectedValue = AgL.XNull(.Rows(0)("SalesTaxGroupItem"))
                        TxtIsItemNature.Text = IIf(AgL.VNull(.Rows(0)("IsItemNature")), "Yes", "No")

                        TxtPurchaseAdditionText.Text = AgL.XNull(.Rows(0)("PurchaseAddition_Text"))
                        TxtPurchaseDeductionText.Text = AgL.XNull(.Rows(0)("PurchaseDeduction_Text"))
                        TxtPurchaseAdditionHeaderText.Text = AgL.XNull(.Rows(0)("PurchaseAddition_H_Text"))
                        TxtPurchaseDeductionHeaderText.Text = AgL.XNull(.Rows(0)("PurchaseDeduction_H_Text"))
                        TxtSaleAdditionText.Text = AgL.XNull(.Rows(0)("SaleAddition_Text"))
                        TxtSaleDeductionText.Text = AgL.XNull(.Rows(0)("SaleDeduction_Text"))
                        TxtSaleAddition_HText.Text = AgL.XNull(.Rows(0)("SaleAddition_H_Text"))
                        TxtSaleDeduction_HText.Text = AgL.XNull(.Rows(0)("SaleDeduction_H_Text"))
                        TxtItemNature1Text.Text = AgL.XNull(.Rows(0)("Item_Nature1_Text"))
                        TxtItemNature2Text.Text = AgL.XNull(.Rows(0)("Item_Nature2_Text"))
                        TxtItemBatchText.Text = AgL.XNull(.Rows(0)("ItemBatch_Text"))
                        TxtGodown.AgSelectedValue = AgL.XNull(.Rows(0)("Godown"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
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
            Topctrl1.tDel = False : Topctrl1.tPrn = False : Topctrl1.tAdd = False
        End Try
    End Sub
    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
        TcEnviro.SelectedTab = TpAcParameter
        TxtIsItemNature.Text = "No"

    End Sub
    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls

        TxtPrepared.Enabled = False : TxtModified.Enabled = False
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
End Class 
