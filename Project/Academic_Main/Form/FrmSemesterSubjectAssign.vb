Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmSemesterSubjectAssign
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Protected Const Dgl1GridName As String = "Dgl1"

    Protected Const Col1Tick As String = "Tick"
    Protected Const Col1StudentName As String = "Student Name"
    Protected Const Col1StudentCode As String = "Student Code"
    Protected Const Col1ClassSectionDesc As String = "Section"
    Protected Const Col1StreamYearSemesterDesc As String = "Semester"
    Protected Const Col1SubjectName As String = "Subject"
    Protected Const Col1ManualCode As String = "Manual Code"
    Protected Const Col1PaperID As String = "Paper ID"
    Protected Const Col1MinCreditHours As String = "Credit Hrs."
    Protected Const Col1IsElectiveSubject As String = "Elective Subject"
    Protected Const Col1IsSubjectSelected As String = "TempIsSubjectSelected"
    Protected Const Col1SemesterSubjectCode As String = "SemesterSubjectCode"
    Protected Const Col1SemesterSubjectRowId As String = "SemesterSubjectRowId"
    Protected Const Col1AdmissionDocIdCode As String = "AdmissionDocId"
    Protected Const Col1SubjectCode As String = "SubjectCode"
    Protected Const Col1StreamYearSemesterCode As String = "Semester Code"
    Protected Const Col1ClassSectionCode As String = "ClassSectionCode"


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
            '.AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            '.AddAgCheckColumn(DGL1, Col1Tick, 50, Col1Tick, True)
            '.AddAgTextColumn(DGL1, Col1StudentName, 250, 0, Col1StudentName, True, True, False)
            '.AddAgTextColumn(DGL1, Col1StudentCode, 100, 0, Col1StudentCode, False, True, False)
            '.AddAgTextColumn(DGL1, Col1ClassSectionDesc, 150, 0, Col1ClassSectionDesc, True, True, False)
            '.AddAgTextColumn(DGL1, Col1StreamYearSemesterDesc, 200, 0, Col1StreamYearSemesterDesc, True, True, False)
            '.AddAgTextColumn(DGL1, Col1SubjectName, 100, 0, Col1SubjectName, False, True, False)
            '.AddAgTextColumn(DGL1, Col1ManualCode, 100, 0, Col1ManualCode, True, True, False)
            '.AddAgTextColumn(DGL1, Col1PaperID, 80, 0, Col1PaperID, True, True, False)
            '.AddAgNumberColumn(DGL1, Col1MinCreditHours, 80, 8, 2, False, Col1MinCreditHours, True, True, True)
            '.AddAgTextColumn(DGL1, Col1IsElectiveSubject, 100, 0, Col1IsElectiveSubject, False, True, False)
            '.AddAgTextColumn(DGL1, Col1IsSubjectSelected, 100, 0, Col1IsSubjectSelected, False, True, False)
            '.AddAgTextColumn(DGL1, Col1SemesterSubjectCode, 100, 0, Col1SemesterSubjectCode, False, True, False)
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
            mQry = "SELECT Vp.AdmissionDocId As Code, V1.StudentName As [Student Name], V1.AdmissionID, " & _
                   " V1.Student As StudentCode, " & _
                   " Vp.FromStreamYearSemester AS StreamYearSemesterCode " & _
                   " FROM (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.PromotionDate IS NULL) Vp " & _
                   " LEFT JOIN ViewSch_Admission V1 ON Vp.AdmissionDocId = V1.DocId " & _
                   " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                   " Order By V1.StudentName "
            TxtAdmissionDocId.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT vSem.Code, vSem.StreamYearSemesterDesc AS Semester,  " & _
                   " vSem.SessionProgrammeStreamCode, vSem.SessionProgrammeCode, vSem.SemesterSerialNo, " & _
                   " vSem.SessionStartDate, vSem.StreamCode, vSem.ProgrammeCode " & _
                   " FROM ViewSch_StreamYearSemester vSem " & _
                   " Where " & AgL.PubSiteCondition("vSem.Site_Code", AgL.PubSiteCode) & " " & _
                   " Order By vSem.SessionProgrammeDesc, Vsem.StreamManualCode, vSem.SemesterStartDate "
            TxtStreamyearSemester.AgHelpDataSet(6) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ClassSectionDesc as [Calass-Section] " & _
                    " FROM ViewSch_ClassSection S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY S.ClassSectionDesc "
            TxtClassSection.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

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


            AgL.PubFindQry = "SELECT  DISTINCT S.DocID  + Ss.StreamYearSemester AS SearchCode ," & _
                                " A.StudentName, Sem.StreamYearSemesterDesc " & _
                                " FROM Sch_AdmissionSubject S " & _
                                " LEFT JOIN Sch_SemesterSubject Ss ON S.SemesterSubject = Ss.Code" & _
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
        Call PrintDocument(mSearchCode)
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
        Try
            Me.Cursor = Cursors.WaitCursor

            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            DGL1.Sort(DGL1.Columns(Col1StudentName), System.ComponentModel.ListSortDirection.Ascending)

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True

            With DGL1

                For bIntI = 0 To .Rows.Count - 1
                    If AgL.XNull(.Item(Col1StudentName, bIntI).Value).ToString.Trim <> "" _
                        And AgL.StrCmp(AgL.XNull(.Item(Col1IsSubjectSelected, bIntI).Value).ToString, "Yes") Then

                        mQry = "SELECT IsNull(Max(AdmSub.Sr),0) AS MaxId " & _
                                " FROM Sch_AdmissionSubject AdmSub WITH (NoLock) " & _
                                " WHERE AdmSub.DocId = " & AgL.Chk_Text(.Item(Col1AdmissionDocIdCode, bIntI).Value) & ""
                        bIntSr = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) + 1

                        mQry = "INSERT INTO Sch_AdmissionSubject ( DocId, Sr, SemesterSubject) " & _
                                " VALUES ( " & _
                                " " & AgL.Chk_Text(.Item(Col1AdmissionDocIdCode, bIntI).Value) & ", " & _
                                " " & bIntSr & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1SemesterSubjectCode, bIntI).Value) & " " & _
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

        DGL1.DataSource = Nothing
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtAdmissionDocId.Enabled = False
            TxtStreamyearSemester.Enabled = False
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
         TxtStreamyearSemester.Enter, TxtClassSection.Enter, TxtAdmissionDocId.Enter
        Try
            Select Case sender.name
                Case TxtStreamyearSemester.Name
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
         TxtStreamyearSemester.Validating, TxtClassSection.Validating, TxtAdmissionDocId.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME

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

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

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
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Tick
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(DGL1, mColumnIndex)
                        Call Calculation()
                    End If
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Dgl1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL1.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.Columns(DGL1.CurrentCell.ColumnIndex).Name
                Case Col1Tick
                    Call AgL.ProcSetCheckColumnCellValue(DGL1, mColumnIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        'sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)

        'Try
        '    Select Case sender.name
        '        Case DGL1.Name
        '            sender(Col1Tick, sender.Rows.Count - 1).Value = AgLibrary.ClsConstant.StrUnCheckedValue
        '    End Select
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        'AgL.FSetSNo(sender, 0)
    End Sub

    Private Sub BtnFillSubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Try
            Select Case sender.name
                Case BtnFill.Name
                    If AgL.RequiredField(TxtStreamyearSemester, LblStreamyearSemester.Text) Then Exit Sub

                    TxtStreamyearSemester.Enabled = False
                    TxtClassSection.Enabled = False
                    TxtAdmissionDocId.Enabled = False

                    Call ProcFillStudent_SemesterSubject()

            End Select
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub ProcFillStudent_SemesterSubject()
        Dim bDtTemp As DataTable = Nothing
        Dim bCondStrMain$ = " Where 1=1 ", bCondStr$ = " Where 1=1 "
        Dim bStrHeaderQry$ = "", bStrMainQry$ = ""

        Dim bStrViewClassSectionSemesterAdmission$ = "", bStrViewOpenElectiveSemesterAdmission$ = "", bStrTempViewSectionAdmission$ = ""
        Dim bBlnIsOpenElectiveSection As Boolean = False

        Try
            Me.Cursor = Cursors.WaitCursor

            DGL1.DataSource = Nothing
            DGL1.Columns.Clear()

            bCondStrMain += " And A.LeavingDate IS NULL "
            bCondStrMain += " And vSemSub.StreamYearSemester = " & AgL.Chk_Text(TxtStreamyearSemester.AgSelectedValue) & " "
            bCondStrMain += " AND AdmSub.DocId IS NULL "


            If TxtAdmissionDocId.Text.Trim <> "" Then
                bCondStrMain += " And vP.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " "
            End If

            If TxtClassSection.Text.Trim <> "" Then
                bCondStrMain += " And Csa.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " "
            End If

            bStrViewClassSectionSemesterAdmission = "SELECT vCsa3.* " & _
                                                    " FROM (SELECT vCsa1.* FROM ViewSch_ClassSectionSemesterAdmission vCsa1 " & _
                                                    " INNER JOIN " & _
                                                    " (SELECT vCsa.ClassSection , Max(vCsa.SemesterStartDate) AS SemesterStartDate " & _
                                                    " FROM ViewSch_ClassSectionSemesterAdmission vCsa  " & _
                                                    " GROUP BY vCsa.ClassSection  " & _
                                                    " ) vCsa2 ON vCsa1.ClassSection = vCsa2.ClassSection AND vCsa1.SemesterStartDate = vCsa2.SemesterStartDate) vCsa3 " & _
                                                    " WHERE vCsa3.SectionLeftOnDate IS NULL "

            bStrViewOpenElectiveSemesterAdmission = "SELECT vOCsa3.* " & _
                                                    " FROM (SELECT vOCsa1.* FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa1 " & _
                                                    " INNER JOIN " & _
                                                    " (SELECT vOCsa.ClassSection , Max(vOCsa.SemesterStartDate) AS SemesterStartDate " & _
                                                    " FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa  " & _
                                                    " GROUP BY vOCsa.ClassSection  " & _
                                                    " ) vOCsa2 ON vOCsa1.ClassSection = vOCsa2.ClassSection AND vOCsa1.SemesterStartDate = vOCsa2.SemesterStartDate) vOCsa3 " & _
                                                    " WHERE vOCsa3.SectionLeftOnDate IS NULL "

            mQry = "SELECT S.IsOpenElectiveSection FROM Sch_ClassSection S WHERE S.Code = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & "  "
            bBlnIsOpenElectiveSection = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)

            If bBlnIsOpenElectiveSection Then
                bStrTempViewSectionAdmission = bStrViewOpenElectiveSemesterAdmission
            Else
                bStrTempViewSectionAdmission = bStrViewClassSectionSemesterAdmission
            End If

            bStrMainQry = "SELECT vSemSub.*, A.DocId AS AdmissionDocId, A.Student As StudentCode," & _
                            " A.StudentName, A.StudentDispName, A.StudentManualCode, " & _
                            " vP.FromStreamYearSemester, " & _
                            " Csa.ClassSection As ClassSectionCode, Csa.ClassSectionDesc, " & _
                            " Convert(Bit,Case When AdmSub.DocId Is Null Then 0 Else 1 End) as IsSubjectSelected " & _
                            " FROM (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.ToStreamYearSemester IS NULL And P.FromStreamYearSemester = " & AgL.Chk_Text(TxtStreamyearSemester.AgSelectedValue) & ") vP " & _
                            " LEFT JOIN (" & bStrTempViewSectionAdmission & ") Csa On vP.AdmissionDocId = Csa.AdmissionDocId " & _
                            " LEFT JOIN ViewSch_Admission A ON A.DocId = vP.AdmissionDocId " & _
                            " LEFT JOIN (SELECT SemSub.* FROM ViewSch_SemesterSubject AS SemSub WHERE IsNull(SemSub.IsElectiveSubject,0) = 0 ) AS vSemSub ON vSemSub.StreamYearSemester = vP.FromStreamYearSemester " & _
                            " LEFT JOIN Sch_AdmissionSubject AdmSub ON vSemSub.Code = AdmSub.SemesterSubject AND AdmSub.DocId = vP.AdmissionDocId " & _
                            " "
            bStrMainQry += bCondStrMain


            bStrHeaderQry = " Select " & _
                            " vMain.StudentName As [" & Col1StudentName & "], " & _
                            " vMain.StudentCode As [" & Col1StudentCode & "], " & _
                            " vMain.StreamYearSemesterDesc As [" & Col1StreamYearSemesterDesc & "], " & _
                            " vMain.ClassSectionDesc As [" & Col1ClassSectionDesc & "], " & _
                            " vMain.SubjectDisplayName As [" & Col1SubjectName & "], " & _
                            " vMain.ManualCode As [" & Col1ManualCode & "], " & _
                            " vMain.PaperId As [" & Col1PaperID & "], " & _
                            " vMain.MinCreditHours As [" & Col1MinCreditHours & "], " & _
                            " Case When IsNull(vMain.IsElectiveSubject,0) <> 0 Then 'Yes' Else 'No' End As [" & Col1IsElectiveSubject & "], " & _
                            " Case When IsNull(vMain.IsElectiveSubject,0) <> 0 Then 'No' Else 'Yes' End As [" & Col1IsSubjectSelected & "], " & _
                            " vMain.AdmissionDocId As [" & Col1AdmissionDocIdCode & "], " & _
                            " vMain.Subject As [" & Col1SubjectCode & "], " & _
                            " vMain.FromStreamYearSemester As [" & Col1StreamYearSemesterCode & "], " & _
                            " vMain.ClassSectionCode As [" & Col1ClassSectionCode & "], " & _
                            " vMain.Code As [" & Col1SemesterSubjectCode & "], " & _
                            " vMain.RowId As [" & Col1SemesterSubjectRowId & "] " & _
                            " From (" & bStrMainQry & ") vMain "


            mQry = "Select vH.* " & _
                    " From (" & bStrHeaderQry & ") as vH " & _
                    " " & bCondStr & " Order By [" & Col1StudentName & "], [" & Col1SemesterSubjectRowId & "] "
            bDtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            DGL1.DataSource = bDtTemp

            If bDtTemp.Rows.Count = 0 Then
                If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                    TxtStreamyearSemester.Enabled = True
                    TxtClassSection.Enabled = True
                    TxtAdmissionDocId.Enabled = True
                    TxtStreamyearSemester.Focus()
                End If
                MsgBox("No Record Exists for Selected Parameter!...")
            End If


            Call AdjustGrid()

        Catch ex As Exception
            DGL1.DataSource = Nothing
            MsgBox(ex.Message)
        Finally
            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub AdjustGrid()
        Try
            With DGL1
                .Columns(Col1SemesterSubjectCode).Visible = False : .Columns(Col1SemesterSubjectCode).Width = 80
                .Columns(Col1SemesterSubjectRowId).Visible = False : .Columns(Col1SemesterSubjectRowId).Width = 80
                .Columns(Col1StudentName).Visible = True : .Columns(Col1StudentName).Width = 180
                .Columns(Col1ClassSectionDesc).Visible = True : .Columns(Col1ClassSectionDesc).Width = 120
                .Columns(Col1StreamYearSemesterDesc).Visible = True : .Columns(Col1StreamYearSemesterDesc).Width = 200
                .Columns(Col1SubjectName).Visible = True : .Columns(Col1SubjectName).Width = 200
                .Columns(Col1ManualCode).Visible = True : .Columns(Col1ManualCode).Width = 80
                .Columns(Col1PaperID).Visible = True : .Columns(Col1PaperID).Width = 50
                .Columns(Col1MinCreditHours).Visible = True : .Columns(Col1MinCreditHours).Width = 50 : .Columns(Col1MinCreditHours).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                .Columns(Col1IsElectiveSubject).Visible = True : .Columns(Col1IsElectiveSubject).Width = 40
                .Columns(Col1IsSubjectSelected).Visible = False : .Columns(Col1IsSubjectSelected).Width = 40
                .Columns(Col1StudentCode).Visible = False : .Columns(Col1StudentCode).Width = 80
                .Columns(Col1AdmissionDocIdCode).Visible = False : .Columns(Col1AdmissionDocIdCode).Width = 80
                .Columns(Col1SubjectCode).Visible = False : .Columns(Col1SubjectCode).Width = 80
                .Columns(Col1StreamYearSemesterCode).Visible = False : .Columns(Col1StreamYearSemesterCode).Width = 80
                .Columns(Col1ClassSectionCode).Visible = False : .Columns(Col1ClassSectionCode).Width = 80


                DGL1.ColumnHeadersHeight = 40
                DGL1.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke
                DGL1.AllowUserToAddRows = False
                DGL1.EnableHeadersVisualStyles = False

                DGL1.ReadOnly = True
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim bIntI% = 0

        'With DGL1
        '    For bIntI = 0 To .Rows.Count - 1
        '        If DGL1.Item(Col1Tick, bIntI).Value Is Nothing Then DGL1.Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
        '        If DGL1.Item(Col1Tick, bIntI).Value.ToString.Trim = "" Then DGL1.Item(Col1Tick, bIntI).Value = AgLibrary.ClsConstant.StrUnCheckedValue
        '    Next
        'End With
    End Sub
End Class
