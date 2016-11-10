Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmStreamYearSemesterFee
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1_Fee As Byte = 1
    Private Const Col1_Amount As Byte = 2
    Private Const Col1_Code As Byte = 3

    Dim mQry As String = "", mSearchCode As String = ""

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
        AgL.AddAgDataGrid(DGL1, Pnl1)
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1Fee", 250, 50, "Fee Head", True, False, False)
            .AddAgNumberColumn(DGL1, "Dgl1Amount", 100, 8, 2, False, "Amount", True, False, True)
            .AddAgTextColumn(DGL1, "Dgl1Code", 100, 50, "Code", False, False, False)
        End With

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
            AgL.WinSetting(Me, 600, 880, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr$ = ""

        mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " "

        mQry = "SELECT S.Code  As SearchCode FROM ViewSch_StreamYearSemester S " & mCondStr
        Topctrl1.FIniForm(DTMaster, AGL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        mQry = "SELECT S.Code, S.StreamYearSemesterDesc " & _
                " FROM ViewSch_StreamYearSemester S " & _
                " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY S.StreamYearSemesterDesc "
        TxtDescription.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
        TxtCopyFrom.AgHelpDataSet = TxtDescription.AgHelpDataSet.Copy


        mQry = "Select F.Code , S.Name As Name " & _
                " From Sch_Fee F " & _
                " Left Join SubGroup S On F.Code = S.SubCode " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "S.Site_Code", AgL.PubSiteCode, "S.CommonAc") & " " & _
                " Order By S.Name "
        DGL1.AgHelpDataSet(Col1_Fee) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        DGL1.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        MsgBox("Delete is Not Possible in Entry " & vbCrLf & "Remove All Fees One By One.")
    End Sub
    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub


    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        DGL1.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try
            AgL.PubFindQry = "SELECT VSem.Code , VSem.StreamYearSemesterDesc , VYear.SessionProgrammeStreamYearDesc , VYear.SessionProgrammeStream, " & _
                                " CASE WHEN VSemFee.StreamYearSemester IS Not NULL THEN 'Yes' ELSE 'No' END AS [Fee Defined], VSemFee.TotalFee [Total Fees] " & _
                                " FROM ViewSch_StreamYearSemester VSem " & _
                                " LEFT JOIN ViewSch_SessionProgrammeStreamYear VYear ON VSem.SessionProgrammeStreamYear = VYear.SessionProgrammeStreamYearCode " & _
                                " LEFT JOIN (SELECT SemFee.StreamYearSemester, IsNull(Sum(SemFee.Amount),0) As TotalFee " & _
                                "               FROM Sch_StreamYearSemesterFee SemFee " & _
                                "               Group By SemFee.StreamYearSemester) VSemFee ON VSem.Code = VSemFee.StreamYearSemester " & _
                                " Where " & AgL.PubSiteCondition("VSem.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQryOrdBy = "[StreamYearSemesterDesc]"


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
            AgL.PubReportTitle = "Unit Master"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = "SELECT S.Code, S.StreamYearSemesterDesc, Convert(nVarchar,S.SemesterStartDate,3) as SemesterStartDate, F.ManualCode [Fee ManualCode], F.DispName AS [Fee Description], SF.Amount, F.FeeNature, F.Refundable      " & _
                        " FROM ViewSch_StreamYearSemester S  " & _
                        " LEFT JOIN Sch_StreamYearSemesterFee SF ON S.Code =Sf.StreamYearSemester  " & _
                        " LEFT JOIN ViewSch_Fee F ON SF.Fee = F.Code  " & _
                        " WHERE S.Code ='" & mSearchCode & "' " & _
                        " ORDER BY S.StreamYearSemesterDesc "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)

            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Unit Master"
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
        Dim I As Integer, mSr As Integer = 0
        Dim mTrans As Boolean = False
        Dim bStreamYearSemesterFeeCode As String

        Try
            MastPos = BMBMaster.Position

            Call Calculation()

            If AgCL.AgCheckMandatory(Me) = False Then Exit Sub


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Edit" Then
                mQry = "Update Sch_StreamYearSemester Set SemesterStartDate = " & AgL.ConvertDate(TxtYearStartDate.Text) & " Where Code='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            With DGL1
                mSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1_Code, I).Value <> "" Then
                        If .Item(Col1_Fee, I).Value <> "" Then
                            mQry = "UPDATE dbo.Sch_StreamYearSemesterFee " & _
                                   "SET Fee = " & AgL.Chk_Text(.AgSelectedValue(Col1_Fee, I)) & ",Amount = " & Val(.Item(Col1_Amount, I).Value) & " " & _
                                   "Where Code = '" & .Item(Col1_Code, I).Value & "'"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            mQry = "Delete From dbo.Sch_StreamYearSemesterFee Where Code = '" & .Item(Col1_Code, I).Value & "' "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If .Item(Col1_Fee, I).Value <> "" Then
                            bStreamYearSemesterFeeCode = AgL.GetMaxId("Sch_StreamYearSemesterFee", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)
                            mQry = "Insert Into Sch_StreamYearSemesterFee(Code, StreamYearSemester, Fee, Amount) Values(" & _
                                    " " & AgL.Chk_Text(bStreamYearSemesterFeeCode) & ", " & AgL.Chk_Text(TxtDescription.AgSelectedValue) & ", " & AgL.Chk_Text(.AgSelectedValue(Col1_Fee, I)) & "," & Val(.Item(Col1_Amount, I).Value) & " )"
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
                mQry = "SELECT Y.Code, Y.SemesterStartDate, Y.StreamYearSemesterDesc, Y.SemesterStartDate, V.TotalFee " & _
                        " FROM ViewSch_StreamYearSemester Y " & _
                        " Left Join (Select F.StreamYearSemester, IsNull(Sum(F.Amount),0) As TotalFee " & _
                        "               From Sch_StreamYearSemesterFee F " & _
                        "               Where F.StreamYearSemester = '" & mSearchCode & "' " & _
                        "               Group By F.StreamYearSemester ) As V On V.StreamYearSemester = Y.Code " & _
                        " Where Y.Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AGL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDescription.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))                        
                        TxtYearStartDate.Text = AgL.XNull(.Rows(0)("SemesterStartDate"))
                        TxtTotalFee.Text = Format(AgL.VNull(.Rows(0)("TotalFee")), "0.00")
                    End If
                End With

                mQry = "Select F.* " & _
                        " From Sch_StreamYearSemesterFee F " & _
                        " Where F.StreamYearSemester='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1_Fee, I) = AgL.XNull(.Rows(I)("FEE"))
                            DGL1.Item(Col1_Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.Item(Col1_Code, I).Value = AgL.XNull(.Rows(I)("Code"))                            
                        Next I
                    End If
                End With

            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                Topctrl1.tAdd = False
                Topctrl1.tDel = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtDescription.Enabled = False
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

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
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

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

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


    Private Sub TxtCopyFrom_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtCopyFrom.Validating, TxtDescription.Validating, TxtTotalFee.Validating, TxtYearStartDate.Validating
        Try
            Select Case sender.name
                Case TxtCopyFrom.Name
                    FillCopyDetail(TxtCopyFrom.AgSelectedValue)
            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub FillCopyDetail(ByVal StreamYearSemester As String)
        Dim I As Integer
        Dim DsTemp As DataSet



        If StreamYearSemester.Trim = "" Then
            Exit Sub
        Else
            If DGL1.RowCount > 1 Then
                If MsgBox("Do you Sure to Copy Detail From -- " & TxtCopyFrom.Text, MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub
            End If
        End If


        mQry = "Select F.* " & _
                "From Sch_StreamYearSemesterFee F " & _
                "Where F.StreamYearSemester='" & StreamYearSemester & "'"
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            DGL1.RowCount = 1
            DGL1.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                    DGL1.Rows.Add()
                    DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                    DGL1.AgSelectedValue(Col1_Fee, I) = AgL.XNull(.Rows(I)("FEE"))
                    DGL1.Item(Col1_Amount, I).Value = AgL.VNull(.Rows(I)("Amount"))                    
                Next I
            End If
        End With
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub


        TxtTotalFee.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1_Fee, I).Value Is Nothing Then .Item(Col1_Fee, I).Value = ""
                If .Item(Col1_Amount, I).Value Is Nothing Then .Item(Col1_Amount, I).Value = ""

                If .Item(Col1_Fee, I).Value <> "" Then
                    TxtTotalFee.Text = Format(Val(TxtTotalFee.Text) + Val(.Item(Col1_Amount, I).Value), "0.00")
                End If
            Next
        End With

    End Sub
End Class
