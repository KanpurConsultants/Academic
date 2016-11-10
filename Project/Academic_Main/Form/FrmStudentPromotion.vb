Imports CrystalDecisions.CrystalReports.Engine
Imports system.Data.SqlClient

Public Class FrmStudentPromotion
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mFeeDueDocId As String = ""

    Dim mObjClsMain As New ClsMain(AgL, PLib)

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1AdmissionDocId As Byte = 1
    Private Const Col1AdmissionID As Byte = 2
    Private Const Col1YesNo As Byte = 3

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        ''==============================================================================
        ''================< Student Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionDocId", 300, 8, "Student", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionId", 170, 8, "Admission ID", True, True, False)
            '.AddAgCheckBoxColumn(DGL1, "Dgl1YesNo", 60, "Yes/No", True, False)
            AgL.AddCheckColumn(DGL1, "Dgl1YesNo", 60, 50, "Yes/No", True, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False
        DGL1.MultiSelect = True

    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.ActiveControl IsNot Nothing Then
            If Me.ActiveControl.Name <> Topctrl1.Name And _
                Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If

            If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)
        End If
    End Sub

    Private Sub OpenLinkForm(ByVal Sender As Object)
        Try
            Me.Cursor = Cursors.WaitCursor
            Select Case Sender.name
                'Case <Sender>.Name
                'PObj.FOpen_LinkForm_Common_Master("MnuCustomerMaster", "Customer Master", Me.MdiParent)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 650, 880, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, True)
            Ini_List()
            DispText()
            BlankText()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT P.Code , P.SessionProgramme AS Name " & _
                " FROM ViewSch_SessionProgramme P " & _
                " Where 1=1 And " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY P.SessionProgramme"
        TxtSessionProgramme.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.Code, S.SessionProgrammeStream AS Name, S.SessionProgramme AS SessionProgrammeCode " & _
                " FROM ViewSch_SessionProgrammeStream S " & _
                " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY S.SessionProgrammeStream "
        TxtSessionProgrammeStream.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.Code , S.StreamYearSemesterDesc AS Name, S.SessionProgrammeCode, S.SessionProgrammeStreamCode, S.SemesterSerialNo " & _
                " FROM ViewSch_StreamYearSemester S " & _
                " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " ORDER BY S.StreamYearSemesterDesc "
        TxtFromStreamYearSemester.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)
        TxtToStreamYearSemester.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT V1.DocId As Code, V1.StudentName As [Student Name], V1.AdmissionID, V1.RollNo, V1.Student As StudentCode " & _
                " FROM ViewSch_Admission V1 " & _
                " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By V1.StudentName "
        DGL1.AgHelpDataSet(Col1AdmissionDocId, 2) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    

    Private Sub ProcSavePromotedStudent()
        Dim I As Integer, bSr As Integer = 0
        Dim mTrans As Boolean = False
        Dim bFeeDueObj As New Academic_ProjLib.ClsMain.Struct_FeeDue, bFeeDue1Obj() As Academic_ProjLib.ClsMain.Struct_FeeDue1 = Nothing

        Dim GcnRead As SqlClient.SqlConnection

        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()


        Try
            If Not Data_Validation() Then Exit Sub

            bFeeDueObj.StreamYearSemesterDesc = TxtToStreamYearSemester.Text
            ProcCreateFeeDueStructure(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, bFeeDueObj, bFeeDue1Obj, mFeeDueDocId)

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True

            With DGL1
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1AdmissionDocId, I).Value.ToString.Trim <> "" And .Item(Col1YesNo, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                        mQry = "Update Sch_AdmissionPromotion " & _
                                " SET  " & _
                                " PromotionDate = " & AgL.ConvertDate(TxtPromotionDate.Text) & ", " & _
                                " ToStreamYearSemester = " & AgL.Chk_Text(TxtToStreamYearSemester.AgSelectedValue) & ", " & _
                                " PromotionType = '" & Academic_ProjLib.ClsMain.PromotionType_Promotion & "', " & _
                                " U_AE = 'E', " & _
                                " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                                " ModifiedBy = '" & AgL.PubUserName & "' " & _
                                " WHERE " & _
                                " AdmissionDocId = " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & " AND  " & _
                                " FromStreamYearSemester = " & AgL.Chk_Text(TxtFromStreamYearSemester.AgSelectedValue) & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "Select IsNull(Max(Sr),0) Sr From Sch_AdmissionPromotion With (NoLock) " & _
                                " Where " & _
                                " AdmissionDocId = " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & " "
                        bSr = AgL.VNull(AgL.Dman_Execute(mQry, GcnRead).ExecuteScalar) + 1

                        mQry = "INSERT INTO Sch_AdmissionPromotion " & _
                                " (AdmissionDocId, Sr, FromStreamYearSemester, PromotionDate, ToStreamYearSemester, PromotionType, " & _
                                " PreparedBy, U_EntDt, U_AE ) " & _
                                " VALUES ( " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & ", " & bSr & ", " & _
                                " " & AgL.Chk_Text(TxtToStreamYearSemester.AgSelectedValue) & ", Null, Null, Null, " & _
                                " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A' ) "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        '===============================================================================================================================================
                        '==================< Update Current Semester >==================================================================================================
                        '===========================< Start >===========================================================================================================
                        '===============================================================================================================================================
                        If Not mObjClsMain.FunUpdateCurrentSemester(.AgSelectedValue(Col1AdmissionDocId, I), AgL.GCn, AgL.ECmd) Then
                            Err.Raise(1, , "Error In Current Semester Updating!...")
                        End If
                        '===============================================================================================================================================
                        '==================< Update Current Semester >==================================================================================================
                        '===========================< End >=============================================================================================================
                        '===============================================================================================================================================

                    End If
                Next I
            End With

            If bFeeDue1Obj IsNot Nothing Then
                Call PLib.ProcSaveFeeDueDetail(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, "Add", bFeeDueObj, bFeeDue1Obj)
                Call PLib.FunFeeDueAccountPosting(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, "Add", bFeeDueObj)

                AgL.UpdateVoucherCounter(mFeeDueDocId, CDate(TxtPromotionDate.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)

                Call AgL.LogTableEntry(mFeeDueDocId, Me.Text, AgLibrary.ClsConstant.EntryMode_Add, AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
            End If



            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            Call BlankText()
        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If

            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcCreateFeeDueStructure(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, ByVal bConnRead As SqlClient.SqlConnection, ByVal bConnectionString As String, _
                                                    ByRef bFeeDueObj As Academic_ProjLib.ClsMain.Struct_FeeDue, ByRef bFeeDue1Obj() As Academic_ProjLib.ClsMain.Struct_FeeDue1, ByRef bFeeDueDocId As String)

        Dim I As Integer, J As Integer, K As Integer, mFlagBln As Boolean = False
        Dim bSite_Code$ = "", bDiv_Code$ = AgL.PubDivCode, bV_Type$ = "", bV_Prefix$ = "", bV_No As Long = 0, bSearchCode$ = "", bAdmissionDocId$ = ""
        Dim bV_Date As String, bStreamYearSemester As String
        Dim bDtTable As DataTable
        Dim bQry$ = ""
        Dim bTotalAmount As Double = 0

        bV_Date = TxtPromotionDate.Text
        bSite_Code = TxtSite_Code.AgSelectedValue
        bStreamYearSemester = TxtToStreamYearSemester.AgSelectedValue

        If bV_Date.Trim <> "" And bSite_Code.Trim <> "" Then
            bQry = "Select Vt.V_Type From Voucher_Type Vt With (NoLock) " & _
                    " Where Vt.NCat = '" & Academic_ProjLib.ClsMain.NCat_FeeDue & "' "
            bV_Type = AgL.XNull(AgL.Dman_Execute(bQry, bConnRead).ExecuteScalar)

            bSearchCode = AgL.GetDocId(bV_Type, CStr(bV_No), CDate(bV_Date), bConnRead, bDiv_Code, bSite_Code)
            mFeeDueDocId = bSearchCode
        End If


        If bSearchCode.Trim = "" Then Err.Raise(1, , "Error in Fee Due Search Code Generation!...")

        bV_No = Val(AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        bV_Prefix = AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

        For K = 0 To DGL1.Rows.Count - 1
            If DGL1.Item(Col1AdmissionDocId, K).Value.ToString.Trim <> "" And DGL1.Item(Col1YesNo, K).Value.ToString.Trim = AgLibrary.ClsConstant.StrCheckedValue Then
                bAdmissionDocId = DGL1.AgSelectedValue(Col1AdmissionDocId, K)

                bQry = "SELECT Adm.DocId AS AdmissionDocId, Adm.Site_Code , Adm.Div_Code, Adm.Student , Adm.AdmissionID , " & _
                        " Adm.V_Date, AdmFee.* " & _
                        " FROM Sch_Admission Adm WITH (NoLock) " & _
                        " LEFT JOIN Sch_AdmissionFeeDetail AdmFee WITH (NoLock) ON Adm.DocId = AdmFee.DocId " & _
                        " Where Adm.DocId = '" & bAdmissionDocId & "' And AdmFee.StreamYearSemester = '" & bStreamYearSemester & "' And " & _
                        " Adm.Site_Code = '" & bSite_Code & "' "
                bDtTable = AgL.FillData(bQry, bConnRead).Tables(0)

                With bDtTable
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            If mFlagBln = False Then
                                J = 0
                                mFlagBln = True
                            Else
                                J = UBound(bFeeDue1Obj) + 1
                            End If
                            ReDim Preserve bFeeDue1Obj(J)

                            bFeeDue1Obj(J).Code = ""
                            bFeeDue1Obj(J).DocId = bSearchCode
                            bFeeDue1Obj(J).AdmissionDocId = bAdmissionDocId
                            bFeeDue1Obj(J).Fee = AgL.XNull(.Rows(I)("Fee"))
                            bFeeDue1Obj(J).Amount = AgL.VNull(.Rows(I)("Amount"))

                            bTotalAmount += AgL.VNull(.Rows(I)("Amount"))
                        Next
                    End If
                End With
            End If
        Next

        If bTotalAmount = 0 Then        
            If MsgBox("Fee Due Amount is Zero!" & vbCrLf & "Do You Want To Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Validation Check") = MsgBoxResult.No Then
                Err.Raise(1, , "Fee Due Amount Can't Be Zero!...")
            End If
        End If

        bFeeDueObj.DocId = bSearchCode
        bFeeDueObj.Div_Code = bDiv_Code
        bFeeDueObj.Site_Code = bSite_Code
        bFeeDueObj.V_Type = bV_Type
        bFeeDueObj.V_Prefix = bV_Prefix
        bFeeDueObj.V_No = bV_No
        bFeeDueObj.V_Date = bV_Date
        bFeeDueObj.Remark = ""
        bFeeDueObj.TotalAmount = bTotalAmount
        bFeeDueObj.StreamYearSemester = bStreamYearSemester

    End Sub

    Public Sub MoveRec()
        Dim DtTemp As DataTable
        Dim I As Integer
        Try
            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If Not CommonData_Validation() Then Exit Sub

            mQry = "SELECT A.DocId As AdmissionDocId, A.AdmissionID, A.Student As StudentCode " & _
                    " FROM ViewSch_Admission A " & _
                    " LEFT JOIN (SELECT Ap.* FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) P ON A.DocId = P.AdmissionDocId  " & _
                    " Where A.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " And " & _
                    " A.LeavingDate IS NULL And P.FromStreamYearSemester = " & AgL.Chk_Text(TxtFromStreamYearSemester.AgSelectedValue) & " " & _
                    " Order By A.StudentName "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If .Rows.Count > 0 Then
                    TxtSessionProgramme.Enabled = False
                    TxtSessionProgrammeStream.Enabled = False
                    TxtFromStreamYearSemester.Enabled = False
                    TxtToStreamYearSemester.Enabled = False

                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL1.Item(Col1AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))
                        If AgL.StrCmp(TxtSelectAll.Text, "Yes") Then
                            DGL1.Item(Col1YesNo, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                        Else
                            DGL1.Item(Col1YesNo, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                        End If
                    Next I

                    DGL1.CurrentCell = DGL1(Col1YesNo, 0) : DGL1.Focus()
                Else
                    TxtSessionProgramme.Enabled = True
                    TxtSessionProgrammeStream.Enabled = True
                    TxtFromStreamYearSemester.Enabled = True
                    TxtToStreamYearSemester.Enabled = True

                    MsgBox("No Student Record Exists!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Sub BlankText()
        Topctrl1.BlankTextBoxes(Me)
        mFeeDueDocId = ""
        TxtSelectAll.Text = "Yes"

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode

        TxtSessionProgramme.Enabled = True
        TxtSessionProgrammeStream.Enabled = True
        TxtFromStreamYearSemester.Enabled = True
        TxtToStreamYearSemester.Enabled = True
    End Sub



    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
    End Sub


    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1AdmissionDocId
                    'DGL1.AgRowFilter(AdmissionDocId) = " And AdmissionDocId = '" & TxtStreamYearSemester.AgSelectedValue & "'"
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        mRowIndex = DGL1.CurrentCell.RowIndex
        mColumnIndex = DGL1.CurrentCell.ColumnIndex
        Try
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1YesNo
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(DGL1, Col1YesNo)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1AdmissionDocId
                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        'DGL1.Item(Col1_ManualCode, mRowIndex).Value = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                'DGL1.Item(Col1_ManualCode, mRowIndex).Value = AgL.XNull(.Item("Name", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        'If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1YesNo
                    Call Calculation()
            End Select

        Catch ex As Exception

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
        TxtSite_Code.Enter, TxtSessionProgramme.Enter, TxtSessionProgrammeStream.Enter, TxtFromStreamYearSemester.Enter, _
        TxtSelectAll.Enter, TxtPromotionDate.Enter, TxtToStreamYearSemester.Enter
        Try
            Select Case sender.name
                Case TxtSessionProgrammeStream.Name
                    TxtSessionProgrammeStream.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "

                Case TxtFromStreamYearSemester.Name
                    TxtFromStreamYearSemester.AgRowFilter = " SessionProgrammeStreamCode = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " "

                Case TxtToStreamYearSemester.Name
                    TxtToStreamYearSemester.AgRowFilter = " SessionProgrammeStreamCode = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & " And SemesterSerialNo = " & Val(LblFromStreamYearSemesterReq.Tag) + 1 & " "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
           TxtSite_Code.Validating, TxtSessionProgramme.Validating, TxtSessionProgrammeStream.Validating, TxtFromStreamYearSemester.Validating, _
           TxtSelectAll.Validating, TxtPromotionDate.Validating, TxtToStreamYearSemester.Validating

        Try
            Select Case sender.NAME
                Case TxtSessionProgrammeStream.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblSessionProgrammeStream.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblSessionProgrammeStream.Tag = AgL.XNull(.Item("SessionProgrammeCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtFromStreamYearSemester.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblFromStreamYearSemester.Tag = ""
                        LblFromStreamYearSemesterReq.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblFromStreamYearSemester.Tag = AgL.XNull(.Item("SessionProgrammeStreamCode", .CurrentCell.RowIndex).Value)
                                LblFromStreamYearSemesterReq.Tag = AgL.VNull(.Item("SemesterSerialNo", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtToStreamYearSemester.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblToStreamYearSemester.Tag = ""
                        LblToStreamYearSemesterReq.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblToStreamYearSemester.Tag = AgL.XNull(.Item("SessionProgrammeStreamCode", .CurrentCell.RowIndex).Value)
                                LblToStreamYearSemesterReq.Tag = AgL.VNull(.Item("SemesterSerialNo", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtPromotionDate.Name
                    If TxtPromotionDate.Text.Trim = "" Then TxtPromotionDate.Text = AgL.PubLoginDate
                    TxtPromotionDate.Text = AgL.RetFinancialYearDate(TxtPromotionDate.Text.ToString)

            End Select

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblSessionProgrammeStream.Tag.ToString) Then
                TxtSessionProgrammeStream.AgSelectedValue = ""
                LblSessionProgrammeStream.Tag = ""
            End If

            If Not AgL.StrCmp(TxtSessionProgrammeStream.AgSelectedValue, LblFromStreamYearSemester.Tag.ToString) Then
                TxtFromStreamYearSemester.AgSelectedValue = ""
                LblFromStreamYearSemester.Tag = ""
                LblFromStreamYearSemesterReq.Tag = ""
            End If

            If Not AgL.StrCmp(TxtSessionProgrammeStream.AgSelectedValue, LblToStreamYearSemester.Tag.ToString) Or _
                Val(LblFromStreamYearSemesterReq.Tag) >= Val(LblToStreamYearSemesterReq.Tag) Then

                TxtToStreamYearSemester.AgSelectedValue = ""
                LblToStreamYearSemester.Tag = ""
                LblToStreamYearSemesterReq.Tag = ""
            End If

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0

        TxtTotalStudent.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1AdmissionDocId, I).Value Is Nothing Then .Item(Col1AdmissionDocId, I).Value = ""
                If .Item(Col1YesNo, I).Value Is Nothing Then .Item(Col1YesNo, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                If .Item(Col1YesNo, I).Value.ToString.Trim = "" Then .Item(Col1YesNo, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                If .Item(Col1AdmissionDocId, I).Value <> "" Then
                    If .Item(Col1YesNo, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                        TxtTotalStudent.Text = Val(TxtTotalStudent.Text) + 1
                    End If
                End If
            Next
        End With

        TxtTotalStudent.Text = Format(Val(TxtTotalStudent.Text), "0")
    End Sub


    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            Call Calculation()

            If Not CommonData_Validation() Then Exit Function

            'AgCL.AgBlankNothingCells(DGL1)
            'If AgCL.AgIsBlankGrid(DGL1, Col1AdmissionDocId) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1AdmissionDocId & "") Then Exit Function

            If AgL.RequiredField(TxtTotalStudent, "Total Student", True) Then DGL1.CurrentCell = DGL1(Col1YesNo, 0) : DGL1.Focus() : Exit Function

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Function CommonData_Validation() As Boolean
        Try
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtSessionProgramme, "Session/Programme") Then Exit Function
            If AgL.RequiredField(TxtSessionProgrammeStream, "Session/Programme/Stream") Then Exit Function
            If AgL.RequiredField(TxtFromStreamYearSemester, "Stream/Year/Semester") Then Exit Function
            If AgL.RequiredField(TxtPromotionDate, "Promotion Date") Then Exit Function
            If Not AgL.IsValidDate(TxtPromotionDate, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function

            If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, LblSessionProgrammeStream.Tag.ToString) Then
                MsgBox("Session/Programme/Stream Is Not Valid!...") : TxtSessionProgrammeStream.Focus() : Exit Function
            End If

            If Not AgL.StrCmp(TxtSessionProgrammeStream.AgSelectedValue, LblFromStreamYearSemester.Tag.ToString) Then
                MsgBox("From Stream/Year/Semester Is Not Valid!...") : TxtFromStreamYearSemester.Focus() : Exit Function
            End If

            If Not AgL.StrCmp(TxtSessionProgrammeStream.AgSelectedValue, LblToStreamYearSemester.Tag.ToString) Or _
                Val(LblFromStreamYearSemesterReq.Tag) >= Val(LblToStreamYearSemesterReq.Tag) Then

                MsgBox("To Stream/Year/Semester Is Not Valid!...") : TxtToStreamYearSemester.Focus() : Exit Function
            End If

            CommonData_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            CommonData_Validation = False
        End Try

    End Function

    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillStudent.Click, BtnSave.Click, BtnExit.Click
        Try
            Select Case sender.name
                Case BtnFillStudent.Name
                    Call MoveRec()

                Case BtnSave.Name
                    Call ProcSavePromotedStudent()

                Case BtnExit.Name
                    Me.Dispose()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub DGL1_CellStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellStateChangedEventArgs) Handles DGL1.CellStateChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                'Case Col1YesNo
                '    <Executable Code>
            End Select
            Call Calculation()
        Catch ex As Exception

        End Try
    End Sub



    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL1.CellMouseUp
        'If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1YesNo
                    Call AgL.ProcSetCheckColumnCellValue(DGL1, Col1YesNo)

            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub
End Class
