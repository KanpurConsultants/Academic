Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmAdvance
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode


    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1GUID As Byte = 1
    Private Const Col1Fee As Byte = 2
    Private Const Col1ReceiveAmount As Byte = 3
    Private Const Col1Remark As Byte = 4

    Dim PaymentRec As AgLibrary.ClsMain.PaymentDetail = Nothing

    Dim mFeeReceiveDocId$ = ""

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
        ''================< Fee Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1GUID", 250, 8, "GUID", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1Fee", 240, 10, "Fee Head", True, False, False)
            .AddAgNumberColumn(DGL1, "DGL1ReceiveAmount", 100, 8, 2, False, "Receive Amount", True, False, True)
            .AddAgTextColumn(DGL1, "DGL1Remark", 295, 255, "Remark", True, False, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
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

            If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)

            If e.KeyCode <> Keys.Return And Me.ActiveControl.Name = TxtReceiveAmount.Name Then
                If Not AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvance) And LblV_Type.Tag.ToString.Trim <> "" Then
                    'Code By Akash On Date 17-3-2011
                    If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_AdvanceReceive) Then AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                    If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_ReceiveEntry) Then AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, DGL1.AgSelectedValue(Col1Fee, 0), "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                    'End Code
                    AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
                    AgL.PubObjFrmPaymentDetail.ShowDialog()
                    PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec

                    TxtReceiveAmount.Text = Format(Val(PaymentRec.TotalAmount), "0.00")
                    If Val(TxtReceiveAmount.Text) <> Val(TxtTotalAmt.Text) Then
                        MsgBox("Receive Amount Is Not Equal To '" & Val(TxtTotalAmt.Text) & "' ")
                    End If
                End If

                Call Calculation()
                AgL.PubObjFrmPaymentDetail = Nothing
            End If
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
            AgL.WinSetting(Me, 626, 880, 0, 0)
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
            mCondStr = " Where ARec.V_Date Between Case Vt.NCat When " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvance) & " Then " & AgL.ConvertDate(CDate(AgL.PubStartDate).AddDays(-1)) & " Else " & AgL.ConvertDate(AgL.PubStartDate) & "  End  And " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                            " And " & AgL.PubSiteCondition("ARec.Site_Code", AgL.PubSiteCode) & " " & _
                            " And Vt.NCat In (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_AdvanceReceive) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvance) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ReceiveEntry) & ") "

            mQry = "Select ARec.DocId As SearchCode " & _
                    " From Sch_Advance ARec " & _
                    " LEFT JOIN Voucher_Type Vt ON ARec.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V_Type As Code, Description As Name, NCat, IsNull(Vt.Affect_FA,0) As Affect_FA From Voucher_Type Vt " & _
                  " Where Vt.NCat In (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_AdvanceReceive) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvance) & ",  " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ReceiveEntry) & ")" & _
                  " Order By Description"
            TxtV_Type.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V1.DocId As Code, V1.StudentName As [Student Name], V1.AdmissionID, " & _
                    " V1.Student As StudentCode, V1.LeavingDate, V1.V_Date As AdmissionDate " & _
                    " FROM ViewSch_Admission V1 " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " And " & _
                    " V1.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                    " Order By V1.StudentName "
            TxtAdmissionDocId.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select F.Code, F.Name as [Fee], F.ManualCode " & _
                    " From ViewSch_Fee F " & _
                    " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "F.Site_Code", AgL.PubSiteCode, "F.CommonAc") & " " & _
                    " AND F.FeeNature In (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.FeeNature_Fine) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.FeeNature_LateFee) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.FeeNature_Others) & ") " & _
                    " Order By F.Name "
            DGL1.AgHelpDataSet(Col1Fee) = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            If mSearchCode <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdvancePaymentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_AdvanceOpeningLedgerM Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    'Code By Akash On Date 17-3-11
                    If Not AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvance) Then
                        If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_AdvanceReceive) Then AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                        If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_ReceiveEntry) Then AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, DGL1.AgSelectedValue(Col1Fee, 0), "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                        AgL.PubObjFrmPaymentDetail.DeletePaymentDetail(AgL.GCn, AgL.ECmd)
                        AgL.PubObjFrmPaymentDetail = Nothing
                    End If
                    'End Code

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    AgL.Dman_ExecuteNonQry("Delete From Sch_ReceiveDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_Advance Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

                    AgL.ETrans.Commit()
                    mTrans = False

                    If AgL.PubMoveRecApplicable Then
                        FIniMaster(1)
                        Topctrl_tbRef()
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

    Private Sub Topctrl_tbDiscard() Handles Topctrl1.tbDiscard
        If AgL.PubMoveRecApplicable Then FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtV_Date.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where ARec.V_Date Between Case Vt.NCat When " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvance) & " Then " & AgL.ConvertDate(CDate(AgL.PubStartDate).AddDays(-1)) & " Else " & AgL.ConvertDate(AgL.PubStartDate) & "  End  And " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                            " And " & AgL.PubSiteCondition("ARec.Site_Code", AgL.PubSiteCode) & " " & _
                            " And Vt.NCat In (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_AdvanceReceive) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvance) & ", " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ReceiveEntry) & ") "


            AgL.PubFindQry = "SELECT ARec.DocId As SearchCode, " & AgL.V_No_Field("ARec.DocId") & " As [Voucher No], " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], ARec.V_Date, ARec.ReceiveAmount AS [Receive Amount], " & _
                                " VAdm.StudentName as [Student], VAdm.AdmissionID, ARec.Remark " & _
                                " FROM dbo.Sch_Advance ARec " & _
                                " LEFT JOIN Voucher_Type Vt ON ARec.V_Type = Vt.V_Type " & _
                                " LEFT JOIN SiteMast S ON ARec.Site_Code = S.Code " & _
                                " Left Join ViewSch_Admission VAdm On ARec.AdmissionDocId = VAdm.DocId " & mCondStr

            AgL.PubFindQryOrdBy = "[Voucher No]"


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

            'Code By satyam on 17/03/2011
            If Academic_ProjLib.ClsMain.IsClient_MIT Then
                AgL.PubReportTitle = "Receipt "
                RepTitle = "Receipt"
            Else
                AgL.PubReportTitle = "Advance Receipt "
                RepTitle = "Advance Receipt"
            End If
            'End Code By satyam on 17/03/2011

            RepName = "Academic_Main_Advance"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " SELECT FR.DocId, Convert(nVarChar, Convert(Numeric, Right(FR.DocID, 8))) + '/' + RTrim(LTrim(SubString(FR.DocID, 9, 5))) + '/' + RTrim(LTrim(SubString(FR.DocID, 4, 5))) + '/' + RTrim(LTrim(SubString(FR.DocID, 2, 2))) + '/' + Left(FR.DocID, 1)  as DocID_Print," & _
                     " FR.Div_Code,FR.Site_Code,FR.V_Date,FR.V_Type,FR.V_Prefix,FR.V_No,FR.Remark,FR.PreparedBy,FR.U_EntDt,FR.U_AE,FR.Edit_Date,FR.ModifiedBy,FR.ReceiveAmount,FR.AdmissionDocId,  " & _
                     " Stu.name As Student_Name, stu.FatherName , Stu.Add1, Stu.Add2, stu.CityName , Adm.EnrollmentNo ,Adm.admissionid, " & _
                     " PD.CashAc, PD.CashAmount, PD.BankAc, PD.BankAmount, PD.Bank_Code, PD.Chq_No, PD.Chq_Date, PD.Clg_Date, PD.CardAc, PD.CardAmount, PD.CardBank_Code, PD.Card_No, PD.AcTransferBankAc, PD.AcTransferAmount, PD.AcTransferBank_Code, PD.TotalAmount, PD.AcTransferAcNo, PD.PartyDrCr, (CASE WHEN PD.CashAmount>0 THEN 'Cash' WHEN PD.BankAmount>0 THEN 'Cheque / DD' WHEN PD.CardAmount>0 THEN 'Credit / Debit Card' WHEN PD.AcTransferAmount>0 THEN 'A/c Transfer' END) AS PaymentMode, " & _
                     " PD.CashAmount+PD.BankAmount+PD.BankAmount2+PD.BankAmount3+PD.CardAmount+PD.AcTransferAmount AS PaymentAmount,PD.BankAc2, PD.BankAmount2, PD.Bank_Code2, PD.Chq_No2, PD.Chq_Date2, PD.Clg_Date2,PD.BankAc3, PD.BankAmount3, PD.Bank_Code3, PD.Chq_No3, PD.Chq_Date3, PD.Clg_Date3,b1.bank_name as Bank1,b2.bank_name as Bank2,b3.bank_name as Bank3,SGT.Name As TransferAc,BT.Bank_Name AS TransferBankName " & _
                     " FROM (Select * From Sch_Advance Where DocId ='" & mDocId & "' ) FR " & _
                     " LEFT JOIN PaymentDetail PD ON Fr.DocId =PD.DocId " & _
                     " LEFT JOIN ViewSch_Admission  Adm ON FR.AdmissionDocId = Adm.DocId  " & _
                     " LEFT JOIN ViewSch_Student Stu ON Adm.Student =stu.SubCode  " & _
                     " Left Join Bank b1 on pd.bank_code=b1.bank_code  " & _
                     " Left Join Bank b2 on pd.bank_code2=b2.bank_code  " & _
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
        Dim bAmount As Double = 0
        Dim bGUID$ = ""
        Dim bBlnAffect_FA As Boolean = True

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            bBlnAffect_FA = AgL.FunIsVTypeAffect_FA(TxtV_Type.AgSelectedValue, AgL.Gcn_ConnectionString)

            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvance) Then
                bAmount = Val(TxtOpeningAdvance.Text)
            Else
                bAmount = Val(TxtReceiveAmount.Text)
            End If

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO dbo.Sch_Advance ( " & _
                        " DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, " & _
                        " AdmissionDocId, ReceiveAmount, Remark,  " & _
                        " PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & bAmount & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_Advance " & _
                        " SET  " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " ReceiveAmount = " & bAmount & ", " & _
                        " AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & mSearchCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            'Code By Akash On Date 17-3-2011
            bSr = 0
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1GUID, I).Value = "" Then
                        If .Item(Col1Fee, I).Value <> "" Then
                            bSr += 1
                            bGUID = AgL.GetGUID(AgL.GcnRead).ToString
                            mQry = "INSERT INTO Sch_ReceiveDetail(Guid, DocId, Fee, ReceiveAmount, Remark) " & _
                                    " VALUES(" & AgL.Chk_Text(bGUID) & ", " & _
                                    " '" & mSearchCode & "', " & AgL.Chk_Text(.AgSelectedValue(Col1Fee, I)) & ", " & _
                                    " " & Val(.Item(Col1ReceiveAmount, I).Value) & ", " & _
                                    " " & AgL.Chk_Text(.Item(Col1Remark, I).Value) & ")"

                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If .Item(Col1Fee, I).Value <> "" Then
                            bSr += 1
                            mQry = "UPDATE Sch_ReceiveDetail " & _
                                    " SET " & _
                                    " Fee = " & AgL.Chk_Text(.AgSelectedValue(Col1Fee, I)) & ", " & _
                                    " ReceiveAmount = " & Val(.Item(Col1ReceiveAmount, I).Value) & ", " & _
                                    " Remark = " & AgL.Chk_Text(.Item(Col1Remark, I).Value) & " " & _
                                    " WHERE GUID = " & AgL.Chk_Text(.Item(Col1GUID, I).Value) & " "

                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            mQry = "Delete From Sch_ReceiveDetail Where GUID = '" & .Item(Col1GUID, I).Value & "'"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    End If
                Next I
            End With
            'End Code

            AgL.Dman_ExecuteNonQry("Delete From Sch_AdvancePaymentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
            AgL.Dman_ExecuteNonQry("Delete From Sch_AdvanceOpeningLedgerM Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

            'Code By Akash On Date 17-3-11
            If Not AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvance) Then
                If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_AdvanceReceive) Then AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_ReceiveEntry) Then AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, DGL1.AgSelectedValue(Col1Fee, 0), "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
                If Not AgL.PubObjFrmPaymentDetail.SavePaymentDetail(PaymentRec, AgL.GCn, AgL.ECmd) Then Err.Raise(1, , "Save Error")
            End If
            'End Code

            Call AccountPosting()

            AgL.PubObjFrmPaymentDetail = Nothing

            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvance) Then
                mQry = "INSERT INTO Sch_AdvanceOpeningLedgerM ( DocId, LedgerMDocId ) VALUES ( " & _
                        " '" & mSearchCode & "',  " & AgL.Chk_Text(IIf(bBlnAffect_FA, mSearchCode, "")) & " )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "INSERT INTO Sch_AdvancePaymentDetail ( DocId, LedgerMDocId ) VALUES ( " & _
                        " '" & mSearchCode & "', " & AgL.Chk_Text(IIf(bBlnAffect_FA, mSearchCode, "")) & " )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)

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

                mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

                Topctrl1.FButtonClick(0)

                If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    Call PrintDocument(mDocId)
                End If

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
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Position < 0 Then Exit Sub
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
            Else
                If AgL.PubSearchRow <> "" Then mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then
                mQry = "Select ARec.*, Vt.NCat, Adm.Student, Adm.AdmissionId, Fra.FeeReceiveDocId " & _
                        " From Sch_Advance ARec " & _
                        " Left Join Voucher_Type Vt On ARec.V_Type = Vt.V_Type " & _
                        " Left Join Sch_Admission Adm On ARec.AdmissionDocId = Adm.DocId " & _
                        " Left Join Sch_FeeReceiveAdvance Fra On ARec.DocId = Fra.AdvanceDocId " & _
                        " Where ARec.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = mSearchCode
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblV_Date.Tag = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(+2, "0"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCat"))

                        TxtAdmissionDocId.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionDocId"))
                        LblAdmissionDocId.Tag = AgL.XNull(.Rows(0)("Student"))
                        TxtAdmissionID.Text = AgL.XNull(.Rows(0)("AdmissionID"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvance) Then
                            TxtOpeningAdvance.Text = Format(AgL.VNull(.Rows(0)("ReceiveAmount")), "0.00")
                            TxtReceiveAmount.Text = ""
                        Else
                            TxtReceiveAmount.Text = Format(AgL.VNull(.Rows(0)("ReceiveAmount")), "0.00")
                            TxtOpeningAdvance.Text = ""
                        End If

                        TxtTotalAmt.Text = Format(AgL.VNull(.Rows(0)("ReceiveAmount")), "0.00")

                        mFeeReceiveDocId = AgL.XNull(.Rows(0)("FeeReceiveDocId"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                'Code By Akash On Date 17-3-2011
                mQry = "SELECT Rd.* FROM Sch_ReceiveDetail Rd " & _
                        " Where Rd.DocId='" & mSearchCode & "'"

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.Item(Col1GUID, I).Value = AgL.XNull(.Rows(I)("GUID"))
                            DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                            DGL1.Item(Col1ReceiveAmount, I).Value = Format(AgL.VNull(.Rows(I)("ReceiveAmount")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))
                        Next I
                    End If
                End With

                ''Payment Detail Moverec Common
                If Not AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvance) Then
                    If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_AdvanceReceive) Then AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                    If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_ReceiveEntry) Then AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, DGL1.AgSelectedValue(Col1Fee, 0), "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                    AgL.PubObjFrmPaymentDetail.FillPaymentRec()
                    PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec
                    AgL.PubObjFrmPaymentDetail = Nothing
                End If
                'End Code
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If mFeeReceiveDocId.Trim <> "" Then mTransFlag = True

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
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = "" : mFeeReceiveDocId = ""

        PaymentRec = Nothing

        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
        End If

        If AgL.StrCmp(Topctrl1.Mode, "Edit") And Not AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_ReceiveEntry) Then
            DGL1.ReadOnly = True
        Else
            DGL1.ReadOnly = False
            DGL1.Columns(Col_SNo).ReadOnly = True
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
        TxtV_Type.Enter, TxtReceiveAmount.Enter, TxtOpeningAdvance.Enter
        Try
            Select Case sender.name
                Case TxtV_Type.Name
                    If AgL.StrCmp(Topctrl1.Mode, "Add") Then TxtV_Type.AgRowFilter = "NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ReceiveEntry) & " "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtDocId.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtV_Date.Validating, _
          TxtAdmissionDocId.Validating, TxtSite_Code.Validating, TxtRemark.Validating, TxtAdmissionID.Validating, _
          TxtReceiveAmount.Validating, TxtOpeningAdvance.Validating


        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblV_Type.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblV_Type.Tag = AgL.XNull(.Item("NCat", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                    If Not AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvance) Then
                        TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text.ToString)
                    End If

                Case TxtAdmissionDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtAdmissionID.Text = ""
                        LblAdmissionDocId.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                TxtAdmissionID.Text = AgL.XNull(.Item("AdmissionID", .CurrentCell.RowIndex).Value)
                                LblAdmissionDocId.Tag = AgL.XNull(.Item("StudentCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If
            End Select

            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mSearchCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvance) Then
            TxtOpeningAdvance.Text = Format(Val(TxtOpeningAdvance.Text), "0.00")
            TxtReceiveAmount.Text = ""
        Else
            TxtReceiveAmount.Text = Format(Val(TxtReceiveAmount.Text), "0.00")
            TxtOpeningAdvance.Text = ""
        End If

        If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_ReceiveEntry) Then
            TxtTotalAmt.Text = 0
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1ReceiveAmount, I).Value Is Nothing Then .Item(Col1ReceiveAmount, I).Value = ""
                    If .Item(Col1Fee, I).Value <> "" Then
                        TxtTotalAmt.Text = Format(Val(TxtTotalAmt.Text) + Val(.Item(Col1ReceiveAmount, I).Value), "0.00")
                    End If
                Next
            End With
        End If
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function            
            If AgL.RequiredField(TxtAdmissionDocId, "Student") Then Exit Function


            If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvance) Then
                If CDate(TxtV_Date.Text) > CDate(AgL.PubStartDate) Then
                    MsgBox("Voucher Date Can't Be Greater Than From " & AgL.PubStartDate & "!...")
                    TxtV_Date.Focus() : Exit Function
                ElseIf CDate(TxtV_Date.Text) < CDate(AgL.PubStartDate).AddDays(-1) Then
                    MsgBox("Voucher Date Can't Be Less Than From " & Format(CDate(AgL.PubStartDate).AddDays(-1), AgLibrary.ClsConstant.DateFormat_ShortDate) & "!...")
                    TxtV_Date.Focus() : Exit Function
                End If

                If Val(TxtReceiveAmount.Text) > 0 Then MsgBox("Receive Amount Can't Be Greater Than Zero!...") : TxtReceiveAmount.Focus()
                If AgL.RequiredField(TxtOpeningAdvance, "Opening Amount", True) Then Exit Function
            ElseIf AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_AdvanceReceive) Then
                If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function

                If Val(TxtOpeningAdvance.Text) > 0 Then MsgBox("Opening Amount Can't Be Greater Than Zero!...") : TxtOpeningAdvance.Focus()
                If AgL.RequiredField(TxtReceiveAmount, "Receive Amount", True) Then Exit Function
            ElseIf AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_ReceiveEntry) Then
                If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
                If Val(TxtOpeningAdvance.Text) > 0 Then MsgBox("Opening Amount Can't Be Greater Than Zero!...") : TxtOpeningAdvance.Focus()
                If AgL.RequiredField(TxtReceiveAmount, "Receive Amount", True) Then Exit Function
                If AgCL.AgIsBlankGrid(DGL1, Col1Fee) Then Exit Function
                If AgCL.AgIsDuplicate(DGL1, "" & Col1Fee & "") Then Exit Function

                For I = 0 To DGL1.Rows.Count - 1
                    If DGL1.Item(Col1Fee, I).Value <> "" Then
                        If Val(DGL1.Item(Col1ReceiveAmount, I).Value) = 0 Then
                            MsgBox("Received Amount Is 0 At Row No " & DGL1.Item(Col_SNo, I).Value & " ", MsgBoxStyle.Information)
                            DGL1.CurrentCell = DGL1.Item(Col1ReceiveAmount, I) : DGL1.Focus() : Exit Function
                        End If
                    End If
                Next

                If Val(TxtReceiveAmount.Text) <> Val(TxtTotalAmt.Text) Then
                    MsgBox("Receive Amount Is Not Equal To '" & Val(TxtTotalAmt.Text) & "' ", MsgBoxStyle.Information) : TxtReceiveAmount.Focus() : Exit Function
                End If
                
            End If
            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mSearchCode <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                    TxtDocId.Text = mSearchCode
                End If
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode

        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            TxtV_Type.Enabled = True
        End If
        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled = True Then TxtV_Type.Focus() Else TxtV_Date.Focus()
        Else
            TxtV_Date.Focus()
        End If

    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer = 0, J As Integer = 0
        Dim mNarr As String = "", mCommonNarr$ = "", bContraSub$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        Dim GcnRead As SqlClient.SqlConnection


        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        mCommonNarr = TxtRemark.Text
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        If AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_OpeningAdvance) Then
            If Val(TxtOpeningAdvance.Text) > 0 Then
                mNarr = ""
                If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

                I = 0
                ReDim Preserve LedgAry(I)

                LedgAry(I).SubCode = LblAdmissionDocId.Tag
                LedgAry(I).ContraSub = ""
                LedgAry(I).AmtDr = 0
                LedgAry(I).AmtCr = Val(TxtOpeningAdvance.Text)
                LedgAry(I).Narration = mNarr
            End If
            If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, True, AgL.Gcn_ConnectionString) = False Then
                AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
            End If
        ElseIf AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_AdvanceReceive) Then
            If AgL.PubObjFrmPaymentDetail.AccountPosting(PaymentRec, AgL.GCn, AgL.Gcn_ConnectionString, AgL.ECmd, LedgAry, mCommonNarr) = False Then
                AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
            End If
        ElseIf AgL.StrCmp(LblV_Type.Tag, Academic_ProjLib.ClsMain.NCat_ReceiveEntry) Then
            'Code BY Akash On Date 17-3-2011
            I = 0
            ReDim Preserve LedgAry(I)
            With PaymentRec
                If .CashAmount > 0 Then
                    bContraSub = .CashAc

                ElseIf .BankAmount > 0 Then
                    bContraSub = .BankAc

                ElseIf .BankAmount2 > 0 Then
                    bContraSub = .BankAc2

                ElseIf .BankAmount3 > 0 Then
                    bContraSub = .BankAc3

                ElseIf .CardAmount > 0 Then
                    bContraSub = .CardAc

                ElseIf .AcTransferAmount > 0 Then
                    bContraSub = .AcTransferBankAc
                End If
            End With

            For J = 0 To DGL1.Rows.Count - 1
                If DGL1.Item(Col1Fee, I).Value <> "" Then
                    If AgL.VNull(DGL1.Item(Col1ReceiveAmount, I).Value) > 0 Then
                        I = UBound(LedgAry) + 1
                        ReDim Preserve LedgAry(I)
                        LedgAry(I).SubCode = DGL1.AgSelectedValue(Col1Fee, J)
                        LedgAry(I).ContraSub = bContraSub
                        LedgAry(I).AmtDr = 0
                        LedgAry(I).AmtCr = DGL1.Item(Col1ReceiveAmount, J).Value
                        LedgAry(I).Narration = mNarr
                    End If
                End If
            Next
            mCommonNarr = "Being Amount Received From " & TxtAdmissionDocId.Text
            If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

            If AgL.PubObjFrmPaymentDetail.AccountPosting(PaymentRec, AgL.GCn, AgL.Gcn_ConnectionString, AgL.ECmd, LedgAry, mCommonNarr, False) = False Then
                AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
            End If

            If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
                AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
            End If
            'End Code
        End If

        GcnRead.Close()
        GcnRead.Dispose()
    End Function


    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                'Case Col1Fee
                '    DGL1.AgRowFilter(Col1FeeDue1) = " AdmissionDocId = '" & TxtAdmissionDocId.AgSelectedValue & "'"
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

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                '<Executable Code>
            End Select
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
End Class
