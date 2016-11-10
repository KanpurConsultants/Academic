Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmDepartment
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = "", mMainStreamCode As String = ""
    Dim mGroupLevel As Integer = 0, mTotalChildren As Integer = 0

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub


    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AGL.FPaintForm(Me, e, Topctrl1.Height)
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
        AGL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 400, 880, 0, 0)
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
        mQry = "Select Sch_Department.Code As SearchCode " & _
        " From Sch_Department "
        Topctrl1.FIniForm(DTMaster, AGL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        mQry = "Select Code  As Code, ManualCode As Name From Sch_Department " & _
            "  Order By ManualCode"
        TxtManualCode.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code  As Code, Description As Name From Sch_Department " & _
            "  Order By Description"
        TxtDescription.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
        TxtParentCode.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
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


                    AgL.ECmd = AGL.GCn.CreateCommand
                    AgL.ETrans = AGL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True

                    AgL.Dman_ExecuteNonQry("Delete From Sch_Department Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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


            AgL.PubFindQry = "Select Sch_Department.Code As SearchCode, Sch_Department.ManualCode As [Manual Code],  Sch_Department.Description As [Description]  From  Sch_Department "


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
            AgL.PubReportTitle = "Department List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = " Select SD.ManualCode As [Manual Code],  SD.Description As [Description],SD1.Description AS [Parent Department] " & _
                        " From  Sch_Department SD  " & _
                        " LEFT JOIN Sch_Department SD1 ON SD1.Code=SD.ParentCode "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Department List"
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

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = "Insert Into Sch_Department (Code, ManualCode, Description, ParentCode, MainStreamCode, GroupLevel, " & _
                        " Div_Code, Site_Code, U_EntDt, PreparedBy, U_AE) " & _
                        " Values( " & _
                        " '" & mSearchCode & "', " & AgL.Chk_Text(TxtManualCode.Text) & ", " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtParentCode.AgSelectedValue) & " , '" & mMainStreamCode & "', " & mGroupLevel & "," & _
                        " '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', '" & AgL.PubUserName & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_Department Set " & _
                        " ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
                        " Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                        " ParentCode = " & AgL.Chk_Text(TxtParentCode.AgSelectedValue) & ", " & _
                        " MainStreamCode = '" & mMainStreamCode & "', " & _
                        " GroupLevel  = " & mGroupLevel & "," & _
                        " Edit_Date='" & Format(AgL.PubLoginDate, "Short Date") & "', ModifiedBy = '" & AgL.PubUserName & "', U_AE = 'E' Where Code='" & mSearchCode & "' "
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

            If Topctrl1.Mode = "Add" Then
                mSearchCode = "" : mMainStreamCode = "" : mGroupLevel = 0
            End If
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim bTotalRecords As Integer = 0
        Dim bGenMainStreamCodeFlag As Boolean = False
        Try
            If AgCL.AgCheckMandatory(Me) = False Then Exit Function

            bTotalRecords = AgL.Dman_Execute("Select IsNull(Count(*),0) Cnt From Sch_Department D", AgL.GCn).ExecuteScalar

            If bTotalRecords > 0 Then
                If AgL.RequiredField(TxtParentCode) Then Exit Function
            End If

            If AgL.StrCmp(TxtDescription.Text, TxtParentCode.Text) Then
                MsgBox("In Valid Parent Department!...") : TxtParentCode.Focus() : Exit Function
            End If

            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_Department Where ManualCode='" & TxtManualCode.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function

                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_Department Where Description='" & TxtDescription.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Function

                bGenMainStreamCodeFlag = True

                mSearchCode = AgL.GetMaxId("Sch_Department", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 6, True, True, , AgL.Gcn_ConnectionString)
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_Department Where ManualCode='" & TxtManualCode.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function

                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_Department Where Description='" & TxtDescription.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Function

                If Not AgL.StrCmp(LblParentCode.Tag, TxtParentCode.AgSelectedValue) Then
                    mTotalChildren = AgL.Dman_Execute("Select TotalChildren From ViewSch_Department Where Code = '" & mSearchCode & "' ", AgL.GCn).ExecuteScalar

                    If mTotalChildren > 0 Then
                        MsgBox("Parent Can't Be Change!" & vbCrLf & "As Children Exists For " & TxtDescription.Text & "!...")
                        MsgBox("Existing Parent Is Re-Assigning For " & TxtDescription.Text & "!...")
                        TxtParentCode.AgSelectedValue = LblParentCode.Tag
                        Exit Function
                    Else
                        bGenMainStreamCodeFlag = True
                    End If
                End If
            End If

            If bGenMainStreamCodeFlag Then
                mMainStreamCode = GetMainStreamCode(TxtParentCode.AgSelectedValue)

                If bTotalRecords = 0 Then
                    mGroupLevel = 1
                Else
                    If mMainStreamCode.Trim.Length = 3 Then MsgBox("Root Department Already Exists!...") : TxtParentCode.Focus() : Exit Function

                    AgL.ECmd = AgL.Dman_Execute("Select IsNull(GroupLevel,0) As GroupLevel From Sch_Department Where Code='" & TxtParentCode.AgSelectedValue & "' ", AgL.GCn)
                    mGroupLevel = AgL.VNull(AgL.ECmd.ExecuteScalar()) + 1
                End If
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Dim mTransFlag As Boolean = False
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select D.* " & _
                        " From ViewSch_Department D " & _
                        " Where Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AGL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtManualCode.AgSelectedValue = AGL.XNull(.Rows(0)("Code"))
                        TxtDescription.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                        TxtParentCode.AgSelectedValue = AgL.XNull(.Rows(0)("ParentCode"))
                        LblParentCode.Tag = AgL.XNull(.Rows(0)("ParentCode"))

                        mMainStreamCode = AgL.XNull(.Rows(0)("MainStreamCode"))
                        mGroupLevel = AgL.VNull(.Rows(0)("GroupLevel"))
                        mTotalChildren = AgL.VNull(.Rows(0)("TotalChildren"))
                    End If
                End With
            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If mTotalChildren > 0 Then mTransFlag = True

                If mTransFlag Then
                    'Topctrl1.tEdit = False
                    Topctrl1.tDel = False
                Else
                    'If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                    If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
        End Try
    End Sub
    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : mMainStreamCode = "" : mGroupLevel = 0 : mTotalChildren = 0
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        If Topctrl1.Mode = "Edit" Then
            If mMainStreamCode.Trim.Length = 3 Then
                TxtParentCode.Enabled = False
            Else
                If mTotalChildren > 0 Then TxtParentCode.Enabled = False
            End If
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
        TxtManualCode.Enter, TxtDescription.Enter, TxtParentCode.Enter
        Try
            Select Case sender.name
                Case TxtParentCode.Name
                    'TxtParentCode.AgRowFilter = " Code  <> " & AgL.Chk_Text(TxtDescription.AgSelectedValue) & " "
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
       TxtManualCode.Validating, TxtDescription.Validating, TxtParentCode.Validating
        Try
            Select Case sender.NAME
                Case TxtDescription.Name
                    If TxtDescription.Text.Trim = "" Then TxtDescription.Text = TxtManualCode.Text

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetMainStreamCode(Optional ByVal bParentCode As String = "") As String
        Dim TmMainStreamCode As String = "", mParentMainStreamCode As String = ""
        Dim DsTemp As DataSet
        Dim I As Integer = 0, J As Integer = 0

        Try
            If DTMaster.Rows.Count = 0 Then
                TmMainStreamCode = PLib.PubIniMainStreamCode
            Else
                If bParentCode = "" Then
                    TmMainStreamCode = ""
                Else
                    AgL.ECmd = AgL.Dman_Execute("Select MainStreamCode From Sch_Department Where Code='" & bParentCode & "' ", AgL.GCn)
                    mParentMainStreamCode = AgL.XNull(AgL.ECmd.ExecuteScalar())
                    If mParentMainStreamCode.Trim <> "" Then
                        mQry = "Select Convert(Numeric,Right(MainStreamCode,3)) As Cnt From Sch_Department " & _
                                " Where Left(MainStreamCode," & mParentMainStreamCode.Length & ")='" & mParentMainStreamCode & "' And " & _
                                " Len(MainStreamCode)=" & mParentMainStreamCode.Length + 3 & " " & _
                                " Order By Convert(Numeric,Right(MainStreamCode,3)) "
                        DsTemp = AgL.FillData(mQry, AgL.GCn)

                        With DsTemp.Tables(0)
                            If .Rows.Count = 0 Then
                                TmMainStreamCode = mParentMainStreamCode + "001"
                            ElseIf .Rows.Count = 999 Then
                                TmMainStreamCode = ""
                            Else
                                For I = 0 To .Rows.Count - 1
                                    J = I + 1
                                    If J <> .Rows(I)("Cnt") Then
                                        TmMainStreamCode = mParentMainStreamCode + J.ToString.PadLeft(3, "0")
                                        Exit For
                                    Else
                                        If TmMainStreamCode.Trim = "" And I = .Rows.Count - 1 Then
                                            J = J + 1
                                            TmMainStreamCode = mParentMainStreamCode + J.ToString.PadLeft(3, "0")
                                        End If
                                    End If
                                Next
                            End If
                        End With
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            TmMainStreamCode = ""
        Finally
            DsTemp = Nothing
            GetMainStreamCode = TmMainStreamCode
        End Try
    End Function

End Class
