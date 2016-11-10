Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmSemesterFeeAssign
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Dgl1GridName As String = "Dgl1"

    Protected Const Col1AdmissionDocId As String = "Student"
    Protected Const Col1AdmissionId As String = "Admission Id"
    Protected Const Col1StreamYearSemester As String = "Semester"
    Protected Const Col1FeeHead As String = "Fee Head"
    Protected Const Col1OldFeeAmt As String = "Prv. Fee Amt."
    Protected Const Col1ReFeeAmt As String = "Fee Amt."
   


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
        ''==============================================================================
        ''================< Student List >==============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1AdmissionDocId, 200, 0, Col1AdmissionDocId, True, True, False)
            .AddAgTextColumn(DGL1, Col1AdmissionId, 160, 0, Col1AdmissionId, True, True, False)
            .AddAgTextColumn(DGL1, Col1StreamYearSemester, 180, 0, Col1StreamYearSemester, True, True, False)
            .AddAgTextColumn(DGL1, Col1FeeHead, 170, 20, Col1FeeHead, True, True, False)
            .AddAgTextColumn(DGL1, Col1OldFeeAmt, 90, 20, Col1OldFeeAmt, True, True, False)
            .AddAgTextColumn(DGL1, Col1ReFeeAmt, 90, 20, Col1ReFeeAmt, True, False, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.Name = Dgl1GridName
        DGL1.AgSkipReadOnlyColumns = True
        DGL1.AllowUserToAddRows = False
        ''==============================================================================
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Or e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F4 Or e.KeyCode = (Keys.F And e.Control) Or e.KeyCode = (Keys.P And e.Control) _
        Or e.KeyCode = (Keys.S And e.Control) Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 _
        Or e.KeyCode = Keys.Home Or e.KeyCode = Keys.PageUp Or e.KeyCode = Keys.PageDown Or e.KeyCode = Keys.End Then
            Topctrl1.TopKey_Down(e)
        End If

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
            If Topctrl1.Mode = "Browse" Then Exit Sub
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
            AgL.WinSetting(Me, 650, 1000, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            If AgL.PubMoveRecApplicable Then FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        If AgL.PubMoveRecApplicable Then
            mQry = "SELECT A.DocId AS SearchCode FROM Sch_Admission A WHERE 1=2 "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "SELECT A.DocID As Code, Sg.Name, Sg.ManualCode, " & _
                    " A.CurrentSemester, A.Status, " & _
                    " CASE WHEN A.LeavingDate IS NOT NULL THEN 'No' ELSE 'Yes' END AS IsActive " & _
                    " FROM Sch_Admission A WITH (NoLock) " & _
                    " LEFT JOIN SubGroup Sg WITH (NoLock) ON A.Student = Sg.SubCode  " & _
                    " ORDER BY Sg.Name"
            TxtAdmissionDocId.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)
            DGL1.AgHelpDataSet(Col1AdmissionDocId, 4) = TxtAdmissionDocId.AgHelpDataSet.Copy


            mQry = "SELECT vSem.Code, vSem.StreamYearSemesterDesc AS Semester,  " & _
                   " vSem.SessionProgrammeStreamCode, vSem.SessionProgrammeCode, vSem.SemesterSerialNo, " & _
                   " vSem.SessionStartDate, vSem.StreamCode, vSem.ProgrammeCode " & _
                   " FROM ViewSch_StreamYearSemester vSem " & _
                   " Where " & AgL.PubSiteCondition("vSem.Site_Code", AgL.PubSiteCode) & " " & _
                   " Order By vSem.SessionProgrammeDesc, Vsem.StreamManualCode, vSem.SemesterStartDate "
            TxtStreamyearSemester.AgHelpDataSet(6) = AgL.FillData(mQry, AgL.GCn)
            DGL1.AgHelpDataSet(Col1StreamYearSemester, 6) = TxtStreamyearSemester.AgHelpDataSet.Copy


            mQry = "Select F.Code, F.Name as [Fee], F.ManualCode " & _
                              " From ViewSch_Fee F " & _
                              " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "F.Site_Code", AgL.PubSiteCode, "F.CommonAc") & " " & _
                              " Order By F.Name "
            TxtFee.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)
            DGL1.AgHelpDataSet(Col1FeeHead, 1) = TxtFee.AgHelpDataSet.Copy

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        '<Executable Code>
    End Sub

    Private Sub Topctrl_tbDiscard() Handles Topctrl1.tbDiscard
        If AgL.PubMoveRecApplicable Then FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtAdmissionDocId.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            'mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("P.PromotionDate", AgL.PubStartDate, AgL.PubEndDate) & _
            '                     " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            mCondStr = " Where 1=1  " & _
                                 " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "


            AgL.PubFindQry = "SELECT  DISTINCT S.DocID  AS SearchCode,SG.DispName as fee ," & _
                                " A.StudentName, Sem.StreamYearSemesterDesc " & _
                                " FROM Sch_AdmissionFeeDetail S " & _
                                " LEFT JOIN Subgroup SG ON S.Fee = SG.SubCode" & _
                                " LEFT JOIN ViewSch_StreamYearSemester Sem ON Ss.StreamYearSemester = Sem.Code " & _
                                " LEFT JOIN ViewSch_Admission A On S.DocId = A.DocId " & _
                                " " & mCondStr & " "

            AgL.PubFindQryOrdBy = "[SearchCode]"


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

    Private Sub Topctrl_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl_tbPrn() Handles Topctrl1.tbPrn
        'Call PrintDocument(mSearchCode)
    End Sub

    Private Sub PrintDocument(ByVal mDocId As String)
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor


            'RepName = "Academic_Main_Advance"

            'If mDocId = "" Then
            '    MsgBox("No Records Found to Print!!!", vbInformation, "Information")
            '    Me.Cursor = Cursors.Default
            '    Exit Sub
            'End If


            'strQry = " SELECT FR.DocId, Convert(nVarChar, Convert(Numeric, Right(FR.DocID, 8))) + '/' + RTrim(LTrim(SubString(FR.DocID, 9, 5))) + '/' + RTrim(LTrim(SubString(FR.DocID, 4, 5))) + '/' + RTrim(LTrim(SubString(FR.DocID, 1, 1))) + '/' + Left(FR.DocID, 1)  as DocID_Print," & _
            '         " FR.Div_Code,FR.Site_Code,FR.V_Date,FR.V_Type,FR.V_Prefix,FR.V_No,FR.Remark,FR.PreparedBy,FR.U_EntDt,FR.U_AE,FR.Edit_Date,FR.ModifiedBy,FR.ReceiveAmount,FR.AdmissionDocId,  " & _
            '         " Stu.name As Student_Name, stu.FatherName , Stu.Add1, Stu.Add1, stu.CityName , Adm.EnrollmentNo ,Adm.admissionid, " & _
            '         " PD.CashAc, PD.CashAmount, PD.BankAc, PD.BankAmount, PD.Bank_Code, PD.Chq_No, PD.Chq_Date, PD.Clg_Date, PD.CardAc, PD.CardAmount, PD.CardBank_Code, PD.Card_No, PD.AcTransferBankAc, PD.AcTransferAmount, PD.AcTransferBank_Code, PD.TotalAmount, PD.AcTransferAcNo, PD.PartyDrCr, (CASE WHEN PD.CashAmount>0 THEN 'Cash' WHEN PD.BankAmount>0 THEN 'Cheque / DD' WHEN PD.CardAmount>0 THEN 'Credit / Debit Card' WHEN PD.AcTransferAmount>0 THEN 'A/c Transfer' END) AS PaymentMode, " & _
            '         " PD.CashAmount+PD.BankAmount+PD.BankAmount1+PD.BankAmount3+PD.CardAmount+PD.AcTransferAmount AS PaymentAmount,PD.BankAc1, PD.BankAmount1, PD.Bank_Code1, PD.Chq_No1, PD.Chq_Date1, PD.Clg_Date1,PD.BankAc3, PD.BankAmount3, PD.Bank_Code3, PD.Chq_No3, PD.Chq_Date3, PD.Clg_Date3,b1.bank_name as Bank1,b1.bank_name as Bank1,b3.bank_name as Bank3,SGT.Name As TransferAc,BT.Bank_Name AS TransferBankName " & _
            '         " FROM (Select * From Sch_Advance Where DocId ='" & mDocId & "' ) FR " & _
            '         " LEFT JOIN PaymentDetail PD ON Fr.DocId =PD.DocId " & _
            '         " LEFT JOIN ViewSch_Admission  Adm ON FR.AdmissionDocId = Adm.DocId  " & _
            '         " LEFT JOIN ViewSch_Student Stu ON Adm.Student =stu.SubCode  " & _
            '         " Left Join Bank b1 on pd.bank_code=b1.bank_code  " & _
            '         " Left Join Bank b1 on pd.bank_code1=b1.bank_code  " & _
            '         " Left Join Bank b3 on pd.bank_code3=b3.bank_code  " & _
            '         " LEFT JOIN SubGroup SGT ON SGT.SubCode=PD.AcTransferBankAc " & _
            '         " LEFT JOIN bank BT ON BT.Bank_Code=PD.AcTransferBank_Code "
            'AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            'AgL.ADMain.Fill(DsRep)


            'AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)

            '''''''''''IF CUSTOMER NEED SOME CHANGE IN FORMAT OF A REPORT'''''''''''
            '''''''''''CUTOMIZE REPORT CAN BE CREATED WITHOUT CHANGE IN CODE''''''''
            '''''''''''WITH ADDING 6 CHAR OF COMPANY NAME AND 4 CHAR OF CITY NAME'''
            '''''''''''WITHOUT SPACES IN EXISTING REPORT NAME''''''''''''''''''''''''''''''''''''''
            'RepName = AgPL.GetRepNameCustomize(RepName, PLib.PubReportPath_Academic_Main)

            'mCrd.Load(PLib.PubReportPath_Academic_Main & "\" & RepName & ".rpt")
            'mCrd.SetDataSource(DsRep.Tables(0))
            'CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            'PLib.Formula_Set(mCrd, RepTitle)
            'AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            'Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim bIntSr As Integer = 0, bIntI As Integer = 0
        Dim mTrans As Boolean = False
        Dim bCondStr$ = ""
        Try
            Me.Cursor = Cursors.WaitCursor

            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True

            If TxtAdmissionDocId.Text.Trim <> "" Then
                bCondStr += " AND DocID = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " "
            End If

            If TxtFee.Text.Trim <> "" Then
                bCondStr += " AND Fee = " & AgL.Chk_Text(TxtFee.AgSelectedValue) & " "
            End If

            AgL.Dman_ExecuteNonQry("Delete From Sch_AdmissionFeeDetail Where StreamYearSemester= " & AgL.Chk_Text(TxtStreamyearSemester.AgSelectedValue) & bCondStr & " ", AgL.GCn, AgL.ECmd)


            With DGL1

                For bIntI = 0 To .Rows.Count - 1
                    If DGL1.Item(Col1AdmissionDocId, bIntI).Value.ToString.Trim <> "" Then

                        mQry = "SELECT IsNull(Max(AdmSub.Sr),0) AS MaxId " & _
                                " FROM Sch_AdmissionFeeDetail AdmSub WITH (NoLock) " & _
                                " WHERE AdmSub.DocId = " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, bIntI)) & ""
                        bIntSr = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) + 1

                        mQry = "INSERT INTO Sch_AdmissionFeeDetail ( DocId, Sr,StreamYearSemester, Fee,Amount) " & _
                                " VALUES ( " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, bIntI)) & ", " & _
                                " " & bIntSr & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1StreamYearSemester, bIntI)) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1FeeHead, bIntI)) & ", " & _
                                " " & Val(.Item(Col1ReFeeAmt, bIntI).Value) & "" & _
                                " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next bIntI
            End With

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode

                Topctrl1.FButtonClick(0)

                'If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    Call PrintDocument(mDocId)
                'End If

                Exit Sub
            Else

                Topctrl1.SetDisp(True)
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If

            If ex.Message.Trim <> "" Then MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim MastPos As Long
        Dim mTransFlag As Boolean = False
        Dim I As Integer = 0

        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

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

            If mSearchCode <> "" Then
                '<Executable Code>
            Else
                BlankText()
            End If

            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If mTransFlag Then
                    Topctrl1.tEdit = False
                    Topctrl1.tDel = False
                Else
                    If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                    If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            DTbl = Nothing
            Topctrl1.tPrn = False
            Topctrl1.tEdit = False
            Topctrl1.tDel = False
            Topctrl1.tFind = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls

        TxtTotalAmt.Enabled = False

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            '<Executable code>
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
         TxtStreamyearSemester.Enter, TxtFee.Enter, TxtAdmissionDocId.Enter
        Try
            Select Case sender.name
                Case TxtAdmissionDocId.Name
                    TxtAdmissionDocId.AgRowFilter = " CurrentSemester = " & AgL.Chk_Text(TxtStreamyearSemester.AgSelectedValue) & " "

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
         TxtStreamyearSemester.Validating, TxtFee.Validating, TxtAdmissionDocId.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Dim bQryStr$ = ""

        Try
            Select Case sender.NAME
                Case TxtStreamyearSemester.Name
                    bQryStr$ = "SELECT IsNull(Sum(A.Amount),0) As TotalFee " & _
                                " FROM Sch_StreamYearSemesterFee A WITH (NoLock) " & _
                                " WHERE A.StreamYearSemester =  " & AgL.Chk_Text(TxtStreamyearSemester.AgSelectedValue) & ""
                    TxtTotalAmt.Text = AgL.VNull(AgL.Dman_Execute(bQryStr$, AgL.GCn).ExecuteScalar)

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtStreamyearSemester, LblStreamyearSemester.Text) Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtStreamyearSemester.Focus()
    End Sub

    Private Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim DsTemp As DataSet = Nothing
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                'case <ColumnIndex>
                '<Executable Code>
            End Select
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

            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                'case <ColumnIndex>
                '<Executable Code>
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        Dim mRowIndex As Integer, mColumnIndex As Integer

        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub

        If Topctrl1.Mode = "Browse" Then Exit Sub

        mRowIndex = DGL1.CurrentCell.RowIndex
        mColumnIndex = DGL1.CurrentCell.ColumnIndex
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)

    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
      AgL.FSetSNo(sender, 0)
    End Sub

    Private Sub BtnFillSubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Try
            Select Case sender.name
                Case BtnFill.Name
                    If AgL.RequiredField(TxtStreamyearSemester, LblStreamyearSemester.Text) Then Exit Sub

                    Call ProcFillStudent_Fee()

            End Select
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub ProcFillStudent_Fee()
        Dim DtTemp As DataTable
        Dim bCondStr = " Where 1=1 "
        Dim I As Integer = 0
        Dim bQryStr$ = ""

        Try
            Me.Cursor = Cursors.WaitCursor

            DGL1.RowCount = 1 : DGL1.Rows.Clear()
          
            If TxtAdmissionDocId.Text.Trim <> "" Then
                bCondStr += " AND V1.DocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " "
            End If

            If TxtFee.Text.Trim <> "" Then
                bCondStr += " AND SF.Fee = " & AgL.Chk_Text(TxtFee.AgSelectedValue) & " "
            End If


            mQry = "SELECT V1.DocId as AdmissionDocId, V1.AdmissionId, V1.CurrentSemester, V1.Student, SF.Fee, IsNull(Af.Amount,0) As PreviousAmt, SF.Amount " & _
                     " FROM ((SELECT A.* FROM Sch_Admission A WITH (NoLock) WHERE A.CurrentSemester =  " & AgL.Chk_Text(TxtStreamyearSemester.AgSelectedValue) & ") AS V1  " & _
                     " Inner Join (SELECT * FROM Sch_StreamYearSemesterFee SemFee WITH (NoLock) WHERE SemFee.StreamYearSemester = " & AgL.Chk_Text(TxtStreamyearSemester.AgSelectedValue) & ") SF  on V1.CurrentSemester=SF.StreamYearSemester) " & _
                     " Left Join Sch_AdmissionFeeDetail Af With (NoLock) on Af.DocId = V1.DocId And Af.StreamYearSemester=SF.StreamYearSemester And Af.Fee = SF.Fee " & _
                     " " & bCondStr & " " & _
                     " Order by V1.AdmissionId, SF.Fee "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()


                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(ColSNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL1.Item(Col1AdmissionId, I).Value = AgL.XNull(.Rows(I)("AdmissionId"))
                        DGL1.AgSelectedValue(Col1StreamYearSemester, I) = AgL.XNull(.Rows(I)("CurrentSemester"))
                        DGL1.AgSelectedValue(Col1FeeHead, I) = AgL.XNull(.Rows(I)("Fee"))
                        DGL1.Item(Col1OldFeeAmt, I).Value = Format(AgL.VNull(.Rows(I)("PreviousAmt")), "0.00")
                    Next I
                    DGL1.CurrentCell = DGL1(Col1ReFeeAmt, 0) : DGL1.Focus()
                Else

                    MsgBox("No Student Record Exists!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Calculation()
        If Topctrl1.Mode = "Browse" Then Exit Sub      
    End Sub
End Class
