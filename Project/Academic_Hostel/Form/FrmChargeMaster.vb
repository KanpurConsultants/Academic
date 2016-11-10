Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmChargeMaster

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
            AgL.WinSetting(Me, 350, 880, 0, 0)
            IniGrid()
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "Select Ht_Charge.SubCode As SearchCode " & _
                " From Ht_Charge " & _
                " Left Join SubGroup Sg On Sg.SubCode = Ht_Charge.SubCode " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()

        mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT F.SubCode as Code, Sg.ManualCode Name " & _
                  " From Ht_Charge F " & _
                  " Left Join SubGroup Sg On Sg.SubCode = F.SubCode " & _
                  " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                  " Order By Sg.ManualCode "
        TxtManualCode.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT F.SubCode as Code, Sg.DispName As [Display Name] " & _
                  " From Ht_Charge F " & _
                  " Left Join SubGroup Sg On Sg.SubCode = F.SubCode " & _
                  " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                  " Order By Sg.DispName "
        TxtDispName.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT F.SubCode as Code, Sg.Name " & _
                  " From Ht_Charge F " & _
                  " Left Join SubGroup Sg On Sg.SubCode = F.SubCode " & _
                  " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                  " Order By Sg.Name "
        TxtName.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code As Code, Description As Name From Ht_ChargeGroup " & _
            "  Order By Description"
        TxtChargeGroup.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        'AgCL.IniAgHelpList(TxtChargeNature, "" & ChargeNature_Charge & "," & ChargeNature_Fine & "," & ChargeNature_Security & "")

        AgCL.IniAgHelpList(TxtChargeNature, "" & PubChargeNatureStr & "")

        mQry = "SELECT G.GroupCode AS Code, G.GroupName AS Name, G.Nature, G.GroupNature  FROM AcGroup G ORDER BY G.GroupName "
        TxtAcGroup.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)
    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
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

                    AgL.Dman_ExecuteNonQry("Delete From Ht_Charge Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Subgroup Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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


            AgL.PubFindQry = "Select F.SubCode As SearchCode, S.ManualCode As [Manual Code],  " & _
                                " S.Name As [Description], Cg.Description AS ChargeGroup, F.ChargeNature " & _
                                " From  Ht_Charge F " & _
                                " Left Join SubGroup S On F.SubCode = S.SubCode  " & _
                                " LEFT JOIN Ht_ChargeGroup Cg ON F.ChargeGroup=Cg.Code " & _
                                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "S.Site_Code", AgL.PubSiteCode, "S.CommonAc") & ""



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
        Dim ds As New DataSet
        Dim strQry As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Charge List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = " SELECT SG.ManualCode AS Charge,SG.Name As Description,Cg.Description As [Charge Group ], " & _
                        " C.ChargeNature As [Charge Nature]" & _
                        " FROM Ht_Charge C   " & _
                        " LEFT JOIN SubGroup SG ON SG.SubCode=C.SubCode  " & _
                        " LEFT JOIN Ht_ChargeGroup Cg ON C.ChargeGroup=Cg.Code   "

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Charge List"
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
            MastPos = BMBMaster.Position

            TxtName.Text = TxtDispName.Text + Space(1) + "{" + TxtManualCode.Text + "}"

            If AgCL.AgCheckMandatory(Me) = False Then Exit Sub

            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where ManualCode='" & TxtManualCode.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Sub
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where Name='" & TxtDispName.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDispName.Focus() : Exit Sub
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where ManualCode='" & TxtManualCode.Text & "' And SubCode<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Sub
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where Name='" & TxtDispName.Text & "' And SubCode<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDispName.Focus() : Exit Sub
            End If



            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True



            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.CreateSubGroup(AgL, AgL.GCn, AgL.ECmd, AgL.Gcn_ConnectionString, TxtDispName.Text, TxtManualCode.Text, TxtAcGroup.AgSelectedValue, TxtGroupNature.Text, TxtNature.Text, AgLibrary.ClsConstant.SubGroupType_Other, TxtSite_Code.AgSelectedValue)

                mQry = "Insert Into Ht_Charge (SubCode, ChargeGroup, ChargeNature, Div_Code, Site_Code, U_EntDt, PreparedBy, U_AE) " & _
                        " Values('" & mSearchCode & "', " & AgL.Chk_Text(TxtChargeGroup.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtChargeNature.Text) & ", '" & AgL.PubDivCode & "', '" & TxtSite_Code.AgSelectedValue & "', " & _
                        " '" & Format(AgL.PubLoginDate, "Short Date") & "', '" & AgL.PubUserName & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update SubGroup Set ManualCode= " & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
                        " Name=" & AgL.Chk_Text(TxtName.Text) & ", " & _
                        " DispName = " & AgL.Chk_Text(TxtDispName.Text) & ", " & _
                        " GroupCode = " & AgL.Chk_Text(TxtAcGroup.AgSelectedValue) & ", " & _
                        " GroupNature = " & AgL.Chk_Text(TxtGroupNature.Text) & ", " & _
                        " Nature=" & AgL.Chk_Text(TxtNature.Text) & " Where SubCode = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


                mQry = "Update Ht_Charge Set " & _
                        " ChargeGroup= " & AgL.Chk_Text(TxtChargeGroup.AgSelectedValue) & "," & _
                        " ChargeNature= " & AgL.Chk_Text(TxtChargeNature.Text) & "," & _
                        " Edit_Date='" & Format(AgL.PubLoginDate, "Short Date") & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "', U_AE = 'E' Where SubCode='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If



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
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select F.*, S.Name, S.GroupNature, S.Nature, S.Site_Code ,S.GroupCode" & _
                        " From Ht_Charge F " & _
                        " Left join SubGroup S On F.SubCode = S.SubCode " & _
                        " Where F.SubCode='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtManualCode.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                        TxtName.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                        TxtDispName.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                        TxtChargeGroup.AgSelectedValue = AgL.XNull(.Rows(0)("ChargeGroup"))
                        TxtChargeNature.AgSelectedValue = AgL.XNull(.Rows(0)("ChargeNature"))
                        TxtAcGroup.AgSelectedValue = AgL.XNull(.Rows(0)("GroupCode"))
                        TxtGroupNature.Text = AgL.XNull(.Rows(0)("GroupNature"))
                        TxtNature.Text = AgL.XNull(.Rows(0)("Nature"))
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

    Private Sub TxtAcGroup_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
         TxtName.Validating, TxtDispName.Validating, TxtManualCode.Validating, TxtChargeGroup.Validating, _
        TxtChargeNature.Validating, TxtNature.Validating, TxtGroupNature.Validating, TxtAcGroup.Validating

        Select Case sender.name
            Case TxtManualCode.Name, TxtDispName.Name, TxtName.Name
                TxtName.Text = TxtDispName.Text + Space(1) + "{" + TxtManualCode.Text + "}"
            Case TxtAcGroup.Name
                If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                    With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                        TxtGroupNature.Text = AgL.XNull(.Item("GroupNature", .CurrentCell.RowIndex).Value)
                        TxtNature.Text = AgL.XNull(.Item("Nature", .CurrentCell.RowIndex).Value)
                    End With
                End If
        End Select
    End Sub
End Class