Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmItemGroup
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

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
            AgL.WinSetting(Me, 300, 880, 0, 0)
            IniGrid()
            If AgL.PubMoveRecApplicable Then FIniMaster()
            Ini_List()
            DispText(False)
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim bCondStr$ = " Where 1=1 "

        bCondStr += " And MasterType = " & AgL.Chk_Text(ItemType) & " "

        If AgL.PubMoveRecApplicable Then
            mQry = "Select Store_ItemGroup.Code As SearchCode " & _
                    " From Store_ItemGroup " & bCondStr
            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        mQry = "Select Code  As Code, ManualCode As Name From Store_ItemGroup Where MasterType = " & AgL.Chk_Text(ItemType) & " " & _
            "  Order By ManualCode"
        TxtManualCode.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code  As Code, Description As Name From Store_ItemGroup Where MasterType = " & AgL.Chk_Text(ItemType) & "" & _
            "  Order By Description"
        TxtDescription.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code  As Code, Description As Name From Store_ItemCategory Where MasterType = " & AgL.Chk_Text(ItemType) & " " & _
            "  Order By Description"
        TxtItemCategory.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtDescription.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False


        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            If mSearchCode.Trim <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then
                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True
                    AgL.Dman_ExecuteNonQry("Delete From Store_ItemGroup Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)


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
        TxtDescription.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        Dim bCondStr$ = " Where 1=1 "
        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try
            bCondStr += " And MasterType = " & AgL.Chk_Text(ItemType) & " "
            AgL.PubFindQry = "Select  Store_ItemGroup.Code As SearchCode,  Store_ItemGroup.Description As [" & LblDescription.Text & "]  From  Store_ItemGroup " & bCondStr


            AgL.PubFindQryOrdBy = "[" & LblDescription.Text & "]"


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

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        Dim ds As New DataSet
        Dim strQry As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Item Group List"

            If AgL.PubMoveRecApplicable Then
                If Not DTMaster.Rows.Count > 0 Then
                    MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            strQry = "Select row_number() OVER (ORDER BY Store_ItemGroup.Code) As [S.No.], Store_ItemGroup.Description As [Description]  From  Store_ItemGroup Where MasterType = " & AgL.Chk_Text(ItemType) & " "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Item Group List"
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
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If AgL.RequiredField(TxtDescription) Then Exit Sub

            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Store_ItemGroup Where Description='" & TxtDescription.Text & "' And MasterType = " & AgL.Chk_Text(ItemType) & " ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Item Group Already Exist!") : TxtDescription.Focus() : Exit Sub

                mSearchCode = AgL.GetMaxId("Store_ItemGroup", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 6, True, True, , AgL.Gcn_ConnectionString)

                TxtManualCode.Text = mSearchCode
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Store_ItemGroup Where ManualCode='" & TxtManualCode.Text & "' And Code<>'" & mSearchCode & "'  And MasterType = " & AgL.Chk_Text(ItemType) & " ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Sub

                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Store_ItemGroup Where Description='" & TxtDescription.Text & "' And Code<>'" & mSearchCode & "'  And MasterType = " & AgL.Chk_Text(ItemType) & " ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Sub
            End If



            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = "Insert Into Store_ItemGroup (Code, ManualCode, Description, ItemCategory, MasterType, Div_Code, Site_Code, U_EntDt, PreparedBy, U_AE) " & _
                        " Values(" & _
                        " '" & mSearchCode & "', " & AgL.Chk_Text(TxtManualCode.Text) & ", " & AgL.Chk_Text(TxtDescription.Text) & ", " & AgL.Chk_Text(TxtItemCategory.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(ItemType) & ", " & _
                        " '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', '" & AgL.PubUserName & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Store_ItemGroup Set ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & ", Description = " & AgL.Chk_Text(TxtDescription.Text) & ", ItemCategory = " & AgL.Chk_Text(TxtItemCategory.AgSelectedValue) & ", " & _
                        " Edit_Date='" & Format(AgL.PubLoginDate, "Short Date") & "', ModifiedBy = '" & AgL.PubUserName & "', U_AE = 'E' Where Code='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl1_tbRef()
            End If

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                If AgL.PubMoveRecApplicable Then MoveRec()
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

            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If

            If mSearchCode.Trim <> "" Then
                mQry = "Select Store_ItemGroup.* " & _
                        " From Store_ItemGroup " & _
                        " Where Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtManualCode.Text = AgL.XNull(.Rows(0)("ManualCode"))

                        TxtDescription.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                        TxtItemCategory.AgSelectedValue = AgL.XNull(.Rows(0)("ItemCategory"))
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
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes()
        mSearchCode = ""
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
        TxtDescription.Validating, TxtManualCode.Validating, TxtItemCategory.Validating

        Try
            Select Case sender.NAME
                Case TxtDescription.Name
                    If TxtDescription.Text.Trim = "" Then TxtDescription.Text = TxtManualCode.Text
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
