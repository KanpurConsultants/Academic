Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmStudentFeeChange
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1StreamYearSemester As Byte = 1
    Private Const Col1Fee As Byte = 2
    Private Const Col1Amount As Byte = 3

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
        ''================< Semester/Fee Data Grid >====================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1StreamYearSemester", 200, 50, "Semester", False, True, False, True)
            .AddAgTextColumn(DGL1, "DGL1Fee", 300, 50, "Fee Head", True, False, False, False)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 120, 8, 2, False, "Amount", True, False, True, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
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
            AgL.WinSetting(Me, 616, 880, 0, 0)
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
        Dim mCondStr As String


        If AgL.PubMoveRecApplicable Then
            mCondStr = " Where 1=1 And A.V_Date < ='" & AgL.PubEndDate & "'" & _
                         " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            mQry = "SELECT DISTINCT  F.DocId + F.StreamYearSemester AS SearchCode " & _
                    " FROM Sch_AdmissionFeeDetail F " & _
                    " LEFT JOIN Sch_Admission A ON F.DocId = A.DocId " & mCondStr

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

            mQry = "SELECT Vs.Code, Vs.StreamYearSemesterDesc AS Semester " & _
                    " FROM ViewSch_StreamYearSemester Vs " & _
                    " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY Vs.SemesterStartDate , Vs.StreamYearSemesterDesc "
            DGL1.AgHelpDataSet(Col1StreamYearSemester) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT F.Code, Sg.DispName [Fee Head], F.FeeNature, F.Refundable " & _
                  " FROM Sch_Fee F " & _
                  " LEFT JOIN SubGroup Sg ON Sg.SubCode = F.Code " & _
                  " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " And " & _
                  " F.FeeNature  NOT IN ('" & Academic_ProjLib.ClsMain.FeeNature_LateFee & "', '" & Academic_ProjLib.ClsMain.FeeNature_Fine & "') " & _
                  " ORDER BY F.FeeNature , Sg.Name "
            DGL1.AgHelpDataSet(Col1Fee) = AgL.FillData(mQry, AgL.GCn)

            IniSemesterHelpList()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IniSemesterHelpList(Optional ByVal All_Receords As Boolean = True, Optional ByVal bAdmissionDocId As String = "")
        If All_Receords Then
            mQry = "SELECT Sem.Code, Sem.StreamYearSemesterDesc FROM ViewSch_StreamYearSemester Sem"
        Else
            mQry = "SELECT Sem.Code , Sem.StreamYearSemesterDesc " & _
                    " FROM " & _
                    " (SELECT P.FromStreamYearSemester AS StreamYearSemester, S.SessionProgrammeStreamCode  " & _
                    " FROM Sch_AdmissionPromotion P " & _
                    " LEFT JOIN ViewSch_StreamYearSemester S ON P.FromStreamYearSemester = S.Code " & _
                    " WHERE P.PromotionDate Is NULL " & _
                    " AND P.AdmissionDocId = '" & bAdmissionDocId & "') AS V1 " & _
                    " LEFT JOIN ViewSch_StreamYearSemester Sem ON V1.SessionProgrammeStreamCode = Sem.SessionProgrammeStreamCode "
        End If
        TxtStreamyearSemester.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        'Dim BlnTrans As Boolean = False
        'Dim GCnCmd As New SqlClient.SqlCommand
        'Dim MastPos As Long
        'Dim mTrans As Boolean = False

        'Try
        '    If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


        '    If mSearchCode <> "" Then
        '        If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


        '            AgL.ECmd = AgL.GCn.CreateCommand
        '            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
        '            AgL.ECmd.Transaction = AgL.ETrans

        '            mTrans = True

        '            AgL.Dman_ExecuteNonQry("Delete From Sch_ScholarShipDemand1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
        '            AgL.Dman_ExecuteNonQry("Delete From Sch_ScholarShipDemand Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

        '            Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

        '            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

        '            AgL.ETrans.Commit()
        '            mTrans = False

        '            If AgL.PubMoveRecApplicable Then
        '                FIniMaster(1)
        '                Topctrl_tbRef()
        '            Else
        '                AgL.PubSearchRow = ""
        '            End If
        '            MoveRec()

        '        End If
        '    End If
        'Catch Ex As Exception
        '    If mTrans = True Then AgL.ETrans.Rollback()
        '    MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        'End Try
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
            mCondStr = " Where 1=1  And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "


            AgL.PubFindQry = "SELECT F.DocID  + F.StreamYearSemester AS SearchCode ," & _
                                " Max(A.StudentName) As Student, Max(Sem.StreamYearSemesterDesc) As Semester, Sum(F.Amount) As [Total Fees] " & _
                                " FROM Sch_AdmissionFeeDetail F " & _
                                " LEFT JOIN ViewSch_StreamYearSemester Sem ON F.StreamYearSemester = Sem.Code " & _
                                " LEFT JOIN ViewSch_Admission A On F.DocId = A.DocId " & _
                                " " & mCondStr & " " & _
                                " Group By F.DocId + F.StreamYearSemester "

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


            RepName = "Academic_Main_Advance"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " SELECT FR.DocId, Convert(nVarChar, Convert(Numeric, Right(FR.DocID, 8))) + '/' + RTrim(LTrim(SubString(FR.DocID, 9, 5))) + '/' + RTrim(LTrim(SubString(FR.DocID, 4, 5))) + '/' + RTrim(LTrim(SubString(FR.DocID, 1, 1))) + '/' + Left(FR.DocID, 1)  as DocID_Print," & _
                     " FR.Div_Code,FR.Site_Code,FR.V_Date,FR.V_Type,FR.V_Prefix,FR.V_No,FR.Remark,FR.PreparedBy,FR.U_EntDt,FR.U_AE,FR.Edit_Date,FR.ModifiedBy,FR.ReceiveAmount,FR.AdmissionDocId,  " & _
                     " Stu.name As Student_Name, stu.FatherName , Stu.Add1, Stu.Add1, stu.CityName , Adm.EnrollmentNo ,Adm.admissionid, " & _
                     " PD.CashAc, PD.CashAmount, PD.BankAc, PD.BankAmount, PD.Bank_Code, PD.Chq_No, PD.Chq_Date, PD.Clg_Date, PD.CardAc, PD.CardAmount, PD.CardBank_Code, PD.Card_No, PD.AcTransferBankAc, PD.AcTransferAmount, PD.AcTransferBank_Code, PD.TotalAmount, PD.AcTransferAcNo, PD.PartyDrCr, (CASE WHEN PD.CashAmount>0 THEN 'Cash' WHEN PD.BankAmount>0 THEN 'Cheque / DD' WHEN PD.CardAmount>0 THEN 'Credit / Debit Card' WHEN PD.AcTransferAmount>0 THEN 'A/c Transfer' END) AS PaymentMode, " & _
                     " PD.CashAmount+PD.BankAmount+PD.BankAmount1+PD.BankAmount3+PD.CardAmount+PD.AcTransferAmount AS PaymentAmount,PD.BankAc1, PD.BankAmount1, PD.Bank_Code1, PD.Chq_No1, PD.Chq_Date1, PD.Clg_Date1,PD.BankAc3, PD.BankAmount3, PD.Bank_Code3, PD.Chq_No3, PD.Chq_Date3, PD.Clg_Date3,b1.bank_name as Bank1,b1.bank_name as Bank1,b3.bank_name as Bank3,SGT.Name As TransferAc,BT.Bank_Name AS TransferBankName " & _
                     " FROM (Select * From Sch_Advance Where DocId ='" & mDocId & "' ) FR " & _
                     " LEFT JOIN PaymentDetail PD ON Fr.DocId =PD.DocId " & _
                     " LEFT JOIN ViewSch_Admission  Adm ON FR.AdmissionDocId = Adm.DocId  " & _
                     " LEFT JOIN ViewSch_Student Stu ON Adm.Student =stu.SubCode  " & _
                     " Left Join Bank b1 on pd.bank_code=b1.bank_code  " & _
                     " Left Join Bank b1 on pd.bank_code1=b1.bank_code  " & _
                     " Left Join Bank b3 on pd.bank_code3=b3.bank_code  " & _
                     " LEFT JOIN SubGroup SGT ON SGT.SubCode=PD.AcTransferBankAc " & _
                     " LEFT JOIN bank BT ON BT.Bank_Code=PD.AcTransferBank_Code "
            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)

            ''''''''''IF CUSTOMER NEED SOME CHANGE IN FORMAT OF A REPORT'''''''''''
            ''''''''''CUTOMIZE REPORT CAN BE CREATED WITHOUT CHANGE IN CODE''''''''
            ''''''''''WITH ADDING 6 CHAR OF COMPANY NAME AND 4 CHAR OF CITY NAME'''
            ''''''''''WITHOUT SPACES IN EXISTING REPORT NAME''''''''''''''''''''''''''''''''''''''
            RepName = AgPL.GetRepNameCustomize(RepName, PLib.PubReportPath_Academic_Main)

            mCrd.Load(PLib.PubReportPath_Academic_Main & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            PLib.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mDocId, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim bSr As Integer = 0, I As Integer = 0
        Dim mTrans As Boolean = False
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True

            mQry = "Delete From Sch_AdmissionFeeDetail Where DocId = '" & TxtAdmissionDocId.AgSelectedValue & "'And StreamYearSemester = '" & TxtStreamyearSemester.AgSelectedValue & "'"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            With DGL1
                bSr = AgL.Dman_Execute("SELECT IsNull(max(S.Sr),0) as Sr FROM Sch_AdmissionFeeDetail S With (NoLock) WHERE S.DocId = '" & TxtAdmissionDocId.AgSelectedValue & "'", AgL.GcnRead).ExecuteScalar()
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1StreamYearSemester, I).Value.ToString.Trim <> "" _
                        And .Item(Col1Fee, I).Value.ToString.Trim <> "" _
                        And Val(.Item(Col1Amount, I).Value) > 0 Then

                        bSr = bSr + 1
                        mQry = "INSERT INTO Sch_AdmissionFeeDetail ( DocId, Sr, StreamYearSemester, Fee, Amount ) " & _
                                " VALUES ( " & _
                                " " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & bSr & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1StreamYearSemester, I)) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1Fee, I)) & ", " & _
                                " " & Val(.Item(Col1Amount, I).Value) & " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With


            AgL.UpdateVoucherCounter(mSearchCode, CDate(AgL.PubLoginDate), AgL.GCn, AgL.ECmd, AgL.PubDivCode, AgL.PubSiteCode)

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

                'mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

                Topctrl1.FButtonClick(0)

                'If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    Call PrintDocument(mDocId)
                'End If

                Exit Sub
            Else
                mTmV_Type = "" : mTmV_Prefix = "" : mTmV_Date = "" : mTmV_NCat = ""

                Topctrl1.SetDisp(True)
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If

        Catch ex As Exception
            If mTrans = True Then
                AgL.ETrans.Rollback()
            End If

            MsgBox(ex.Message)
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
            Call IniSemesterHelpList()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then

                mQry = "SELECT F.DocId As AdmissionDocId, F.StreamYearSemester, Sum(F.Amount) As TotalFee " & _
                        " FROM Sch_AdmissionFeeDetail F " & _
                        " Where F.DocId + F.StreamYearSemester = '" & mSearchCode & "' " & _
                        " Group By F.DocId, F.StreamYearSemester "
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtAdmissionDocId.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionDocId"))
                        TxtStreamyearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamyearSemester"))
                        TxtTotalFee.Text = Format(AgL.VNull(.Rows(0)("TotalFee")), "0.00")
                    End If
                End With

                mQry = "Select Af.* " & _
                        " From Sch_AdmissionFeeDetail Af " & _
                        " Where AF.DocId + AF.StreamYearSemester  ='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1StreamYearSemester, I) = AgL.XNull(.Rows(I)("StreamYearSemester"))
                            DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        Next I
                    End If
                End With
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
            Topctrl1.tPrn = False : Topctrl1.tDel = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" ': LblPrefix.Text = ""

        If mTmV_Type.Trim <> "" Then
            'TxtV_Type.AgSelectedValue = mTmV_Type
            'LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            'TxtV_Date.Text = mTmV_Date
        End If
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtAdmissionDocId.Enter, TxtStreamyearSemester.Enter
        Try
            Select Case sender.name
                Case TxtStreamyearSemester.Name
                    Call IniSemesterHelpList(False, TxtAdmissionDocId.AgSelectedValue)

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)

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
            If AgCL.AgIsBlankGrid(DGL1, Col1Fee) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1Fee & "") Then Exit Function
            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtAdmissionDocId.Focus()
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
        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                'Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub DGL1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .CurrentCell.ColumnIndex
                    Case Col1Fee
                        If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                            '<Executable Code>
                            DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                        Else
                            If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")

                                'DGL1.Item(Col1AdmissionID, mRowIndex).Value = AgL.VNull(DrTemp(0)("AdmissionID"))
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

    Private Sub ProcFillFee()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim bCondStr$ = "", bNewSemesterStartDate$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            mQry = "SELECT Sf.StreamYearSemester, Sf.Fee, Sf.Amount, Sem.SemesterStartDate, Sem.StreamYearSemesterDesc " & _
                      " FROM Sch_StreamYearSemesterFee Sf " & _
                      " LEFT JOIN ViewSch_StreamYearSemester Sem ON Sf.StreamYearSemester = Sem.Code " & _
                      " Where Sf.StreamYearSemester = '" & TxtStreamyearSemester.AgSelectedValue & "' " & _
                      " ORDER BY Sem.SemesterStartDate , Sem.StreamYearSemesterDesc, Sf.RowId "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                        DGL1.AgSelectedValue(Col1StreamYearSemester, I) = AgL.XNull(.Rows(I)("StreamYearSemester"))
                        DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                    Next I
                End If
            End With

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub BtnFillSubject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFilFee.Click
        Call ProcFillFee()
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub
        TxtTotalFee.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1StreamYearSemester, I).Value Is Nothing Then .Item(Col1StreamYearSemester, I).Value = ""
                If .Item(Col1Fee, I).Value Is Nothing Then .Item(Col1Fee, I).Value = ""
                If .Item(Col1Amount, I).Value Is Nothing Then .Item(Col1Amount, I).Value = ""

                If .Item(Col1StreamYearSemester, I).Value.ToString.Trim = "" Then .AgSelectedValue(Col1StreamYearSemester, I) = TxtStreamyearSemester.AgSelectedValue

                If .Item(Col1Fee, I).Value.ToString.Trim <> "" And Val(.Item(Col1Amount, I).Value) > 0 Then
                    TxtTotalFee.Text = Format(Val(TxtTotalFee.Text) + Val(.Item(Col1Amount, I).Value), "0.00")
                End If
            Next
        End With

    End Sub
End Class
