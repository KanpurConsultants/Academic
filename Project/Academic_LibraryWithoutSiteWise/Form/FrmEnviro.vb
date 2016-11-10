Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmEnviro
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1ReceiptType As String = "Receipt Type"
    Protected Const Col1AccessionNoPrefix As String = "Accession No Prefix"
    Protected Const Col1BookUidSufix As String = "Book Uid Sufix"

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
            .AddAgTextColumn(Dgl1, Col1ReceiptType, 150, 20, Col1ReceiptType, True, False, False)
            .AddAgTextColumn(Dgl1, Col1AccessionNoPrefix, 150, 5, Col1AccessionNoPrefix, True, False, False)
            .AddAgTextColumn(Dgl1, Col1BookUidSufix, 150, 5, Col1BookUidSufix, True, False, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Dgl1.ColumnHeadersHeight = 25
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F4 Or e.KeyCode = (Keys.F And e.Control) Or e.KeyCode = (Keys.P And e.Control) _
        Or e.KeyCode = (Keys.S And e.Control) Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 _
        Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.End Then
            Topctrl1.TopKey_Down(e)
        End If


        If Me.ActiveControl IsNot Nothing Then
            If Me.ActiveControl.Name <> Topctrl1.Name And _
                Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid)  Then
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
            AgL.WinSetting(Me, 550, 880, 0, 0)
            AgL.GridDesign(Dgl1)
            IniGrid()
            Topctrl1.ChangeAgGridState(Dgl1, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "Select E.Site_Code As SearchCode " & _
        " From Lib_Enviro E " & _
        " Where " & AgL.PubSiteCondition("E.Site_Code", AgL.PubSiteCode) & ""
        Topctrl1.FIniForm(DTMaster, AgL.Gcn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
               " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT A.GroupCode AS Code, A.GroupName AS Name, A.GroupNature , A.Nature  " & _
                  " FROM AcGroup A " & _
                  " WHERE LEFT(MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") in ('" & AgLibrary.ClsConstant.MainGRCodeSundryCreditors & "' , '" & AgLibrary.ClsConstant.MainGRCodeSundryDebtors & "') " & _
                  " AND MainGrLen >= " & AgLibrary.ClsConstant.MainGRLenSundryCreditors & " " & _
                  " AND AliasYn = 'N'"
        TxtMemberACGroup.AgHelpDataSet(2, TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = AgL.FillData(mQry, AgL.GCn)
        TxtEmployeeAcGroup.AgHelpDataSet(2, TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = TxtMemberACGroup.AgHelpDataSet

        mQry = " SELECT BT.Code,BT.Description AS [Book Type],BT.Suffix, " & _
                " isnull(BT.IsDeleted,0) AS IsDeleted,ISNULL(Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status,BT.Div_Code " & _
                " FROM Lib_BookType BT "
        TxtDefaultBookType.AgHelpDataSet(4, TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Code,Code AS Unit FROM Unit "
        TxtDefaultUnit.AgHelpDataSet(0, TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT SG.SubCode AS Code ,SG.DispName AS [Purchase A/C] , " & _
                " isnull(SG.IsDeleted,0) AS IsDeleted,ISNULL(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status,SG.Div_Code " & _
                " FROM SubGroup SG " & _
                " WHERE Nature ='Purchase'"
        TxtPurchaseAc.AgHelpDataSet(3, TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Vt.V_Type AS Code, Vt.Description AS ReceiptType FROM Voucher_Type Vt "
        Dgl1.AgHelpDataSet(Col1ReceiptType, , TcEnviro.Top + TpAcParameter.Top, TcEnviro.Left + TpAcParameter.Left) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtMemberACGroup.Focus()
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

                    AgL.Dman_ExecuteNonQry("Delete From Lib_Enviro Where Site_Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Lib_ReceiptTypePrefix Where Site_Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)


                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.ETrans.Commit()
                    mTrans = False

                    FIniMaster(1)
                    Topctrl1_tbRef()
                    Call IniDtLib_Enviro()

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
        TcEnviro.SelectedTab = TpAcParameter
        TxtMemberACGroup.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = " Select  E.Site_Code As SearchCode,  S.Name As [Site Name],AG.GroupName AS [Group Name], " & _
                                " BT.Description AS [Default Book Type],E.DefaultLanguage AS [Default Language],E.DefaultUnit AS [Default Unit], PurchaseAC AS [Purchase A/C]" & _
                                " From Lib_Enviro E " & _
                                " Left Join SiteMast S On E.Site_Code = S.Code " & _
                                " LEFT JOIN AcGroup AG ON AG.GroupCode= E.MemberACGroup " & _
                                " LEFT JOIN Lib_BookType BT ON BT.Code=E.DefaultBookType "


            AgL.PubFindQryOrdBy = "[Site Name]"

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
        Dim I As Integer = 0, mSr As Integer = 0
        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = " INSERT INTO Lib_Enviro	(Site_Code,	MemberACGroup, EmployeeAcGroup, DefaultBookType, DefaultLanguage, DefaultUnit ,	PurchaseAC, Div_Code, " & _
                        " PreparedBy,U_EntDt,	U_AE,ReturnReminderBefore,IsAutoBookID	) " & _
                        " VALUES (" & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & AgL.Chk_Text(TxtMemberACGroup.AgSelectedValue) & ", " & AgL.Chk_Text(TxtEmployeeAcGroup.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtDefaultBookType.AgSelectedValue) & "," & AgL.Chk_Text(TxtDefaultLanguage.Text) & " ," & AgL.Chk_Text(TxtDefaultUnit.AgSelectedValue) & " ," & AgL.Chk_Text(TxtPurchaseAc.AgSelectedValue) & " ," & _
                        " '" & AgL.PubDivCode & "', '" & AgL.PubUserName & "', " & AgL.ConvertDate(AgL.PubLoginDate) & ", 'A'," & Val(TxtBookReturn.Text) & "," & IIf(AgL.StrCmp(txtIsAutoBookID.Text, "Yes"), 1, 0) & " ) "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = " UPDATE Lib_Enviro " & _
                        " SET " & _
                        " MemberACGroup = " & AgL.Chk_Text(TxtMemberACGroup.AgSelectedValue) & ", " & _
                        " EmployeeAcGroup = " & AgL.Chk_Text(TxtEmployeeAcGroup.AgSelectedValue) & ", " & _
                        " DefaultBookType = " & AgL.Chk_Text(TxtDefaultBookType.AgSelectedValue) & ", " & _
                        " DefaultLanguage = " & AgL.Chk_Text(TxtDefaultLanguage.Text) & ", " & _
                        " DefaultUnit = " & AgL.Chk_Text(TxtDefaultUnit.Text) & ", " & _
                        " PurchaseAC = " & AgL.Chk_Text(TxtPurchaseAc.AgSelectedValue) & ", " & _
                        " ReturnReminderBefore = " & Val(TxtBookReturn.Text) & ", " & _
                        " U_AE = 'E', " & _
                        " IsAutoBookID = " & IIf(AgL.StrCmp(txtIsAutoBookID.Text, "Yes"), 1, 0) & ", " & _
                        " Edit_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & ", " & _
                        " ModifiedBy = " & AgL.Chk_Text(AgL.PubUserName) & "  " & _
                        " Where Site_Code = '" & TxtSite_Code.AgSelectedValue & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            mQry = "Delete From Lib_ReceiptTypePrefix Where Site_Code = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            With Dgl1
                For I = 0 To .RowCount - 1
                    If .Item(Col1ReceiptType, I).Value <> "" Then
                        mSr += 1
                        mQry = "INSERT INTO dbo.Lib_ReceiptTypePrefix (Site_Code, Sr, ReceiptType, " & _
                                " AccessionNoPrefix, BookUidSufix) " & _
                                " VALUES (" & AgL.Chk_Text(mSearchCode) & ", " & Val(mSr) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1ReceiptType, I)) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1AccessionNoPrefix, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1BookUidSufix, I).Value) & ")"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With


            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()

            mTrans = False
            FIniMaster(0, 1)
            Topctrl1_tbRef()

            Call IniDtLib_Enviro()

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
        Dim I As Integer = 0
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select E.* " & _
                        " From Lib_Enviro E " & _
                        " Where E.Site_Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtMemberACGroup.AgSelectedValue = AgL.XNull(.Rows(0)("MemberACGroup"))
                        TxtEmployeeAcGroup.AgSelectedValue = AgL.XNull(.Rows(0)("EmployeeAcGroup"))
                        TxtDefaultBookType.AgSelectedValue = AgL.XNull(.Rows(0)("DefaultBookType"))
                        TxtDefaultLanguage.Text = AgL.XNull(.Rows(0)("DefaultLanguage"))
                        TxtDefaultUnit.Text = AgL.XNull(.Rows(0)("DefaultUnit"))
                        TxtPurchaseAc.AgSelectedValue = AgL.XNull(.Rows(0)("PurchaseAC"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        TxtBookReturn.Text = AgL.VNull(.Rows(0)("ReturnReminderBefore"))
                        txtIsAutoBookID.Text = IIf(AgL.VNull(.Rows(0)("IsAutoBookID")), "Yes", "No")
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select R.* from Lib_ReceiptTypePrefix R " & _
                         " Where R.Site_Code = '" & mSearchCode & "' "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.AgSelectedValue(Col1ReceiptType, I) = AgL.XNull(.Rows(I)("ReceiptType"))
                            Dgl1.Item(Col1AccessionNoPrefix, I).Value = AgL.XNull(.Rows(I)("AccessionNoPrefix"))
                            Dgl1.Item(Col1BookUidSufix, I).Value = AgL.XNull(.Rows(I)("BookUidSufix"))
                        Next I
                    End If
                End With
                Topctrl1.tAdd = False
            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            Topctrl1.tDel = False : Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
        txtIsAutoBookID.Text = "No"
        TcEnviro.SelectedTab = TpAcParameter
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
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

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = ""
        Try
            If AgL.RequiredField(TxtSite_Code, "Branch/Site") Then Exit Function

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function


            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    TxtMemberACGroup.Enter, TxtDefaultBookType.Enter, TxtDefaultLanguage.Enter, TxtDefaultUnit.Enter, TxtPurchaseAc.Enter
        Try
            Select Case sender.name
                Case TxtDefaultBookType.Name, TxtPurchaseAc.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND " & ClsMain.RetDivFilterStr & ""
            End Select
        Catch ex As Exception
        End Try
    End Sub
End Class
