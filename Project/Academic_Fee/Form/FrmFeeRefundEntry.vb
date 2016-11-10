Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmFeeRefundEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    'Grid-1 Column Index Constants
    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Select As Byte = 1
    Private Const Col1FeeReceiveDocId As Byte = 2
    Private Const Col1FeeReceive1 As Byte = 3
    Private Const Col1ReturnHeadType As Byte = 4
    Private Const Col1FeeDue1 As Byte = 5
    Private Const Col1FeeGroup As Byte = 6
    Private Const Col1FeeNature As Byte = 7
    Private Const Col1Amount As Byte = 8
    Private Const Col1NetAmount As Byte = 9
    Private Const Col1RegistrationGrossAmt As Byte = 10
    Private Const Col1RegistrationAmount As Byte = 11
    Private Const Col1RefundableYesNo As Byte = 12
    Private Const Col1Code As Byte = 13

    'Grid-2 Column Index Constants
    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2Select As Byte = 1
    Private Const Col2FeeReceiveDocId As Byte = 2
    Private Const Col2FeeReceiveVDate As Byte = 3
    Private Const Col2ReceiveAmount As Byte = 4
    Private Const Col2AdvanceCarriedForward As Byte = 5
    Private Const Col2RegistrationAdjustmentAmount As Byte = 6
    Private Const Col2ReceiveLessRefundAmount As Byte = 7
    Private Const Col2TotalRefundAmount As Byte = 8
    Private Const Col2TotalExcessRefund As Byte = 9
    Private Const Col2TotalRegistrationAmountRefund As Byte = 10


    Public WithEvents DGLFooter1 As New AgControls.AgDataGrid
    '=============== <Column Index> ========================
    Private Const DFC_Description As Byte = 0
    Private Const DFC_Percentage As Byte = 1
    Private Const DFC_Amount As Byte = 2

    '=============== <Row Index> ===========================
    Private Const DF1R_TotalLineAmount As Byte = 0
    Private Const DF1R_TotalFeeRefund As Byte = 1
    Private Const DF1R_ExcessRefund As Byte = 2
    Private Const DF1R_RegistrationAmountRefund As Byte = 3
    Private Const DF1R_TotalLineNetAmount As Byte = 4

    Dim PaymentRec As AgLibrary.ClsMain.PaymentDetail = Nothing

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
            AgL.AddCheckColumn(DGL1, "Dgl1Select", 60, 1, "Select", True, True)
            .AddAgTextColumn(DGL1, "DGL1FeeReceiveDocId", 170, 21, "Receive No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1FeeReceive1", 340, 8, "Fee Head", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1ReturnHeadType", 80, 50, "Head Type", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1FeeDue1", 180, 8, "Fee Due1 Code", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1FeeGroup", 100, 8, "Fee Group", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1FeeNature", 60, 8, "Fee Nature", False, True, False)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 100, 8, 2, False, "Amount", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1NetAmount", 100, 8, 2, False, "Refund Amount", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1RegistrationGrossAmt", 100, 8, 2, False, "Reg. Amt.", False, True, True)
            .AddAgNumberColumn(DGL1, "Dgl1RegistrationAmount", 100, 8, 2, False, "Reg. Ref.", False, True, True)
            .AddAgTextColumn(DGL1, "DGL1RefundableYesNo", 30, 1, "Refundable (Yes/No)", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1Code", 30, 10, "Code", False, True, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False

        ''==============================================================================
        ''================< Fee Receive Voucher Data Grid >=============================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "DGL2SNo", 40, 5, "S.No.", True, True, False)
            AgL.AddCheckColumn(DGL2, "Dgl2Select", 60, 1, "Select", True, True)
            .AddAgTextColumn(DGL2, "DGL2FeeReceiveDocId", 200, 8, "Receive No.", True, True, False)
            .AddAgDateColumn(DGL2, "DGL2FeeReceiveVDate", 80, "Receive Date", True, True, False)
            .AddAgNumberColumn(DGL2, "DGL2ReceiveAmount", 80, 8, 2, False, "Receive Amount", True, True, True)
            .AddAgNumberColumn(DGL2, "DGL2AdvanceCarriedForward", 80, 8, 2, False, "Advance C/F", True, True, True)
            .AddAgNumberColumn(DGL2, "DGL2RegistrationAdjustmentAmount", 80, 8, 2, False, "Reg. Adj.", True, True, True)
            .AddAgNumberColumn(DGL2, "DGL2ReceiveLessRefundAmount", 80, 8, 2, False, "Receive (-) Refund", False, True, True)
            .AddAgNumberColumn(DGL2, "DGL2TotalRefundAmount", 80, 8, 2, False, "Total Refund", True, True, True)
            .AddAgNumberColumn(DGL2, "DGL2TotalExcessRefund", 80, 8, 2, False, "Tot. Advance Refund", True, True, True)
            .AddAgNumberColumn(DGL2, "DGL2TotalRegistrationAmountRefund", 80, 8, 2, False, "Tot. Reg. Refund", True, True, True)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 40
        DGL2.AllowUserToAddRows = False


        ''==============================================================================
        ''================< Footer Data Grid-1 >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGLFooter1, "DGLF1Description", 180, 5, "Description", True, True, False)
            .AddAgNumberColumn(DGLFooter1, "DGLF1Percentage", 40, 2, 2, False, " % ", False, True, True)
            .AddAgNumberColumn(DGLFooter1, "DGLF1Amount", 100, 8, 2, False, "Amount", True, True, True)
        End With
        AgL.AddAgDataGrid(DGLFooter1, PnlFooter1)
        DGLFooter1.RowCount = 6
        DGLFooter1.AllowUserToAddRows = False
        DGLFooter1.Item(DFC_Description, DF1R_TotalLineAmount).Value = "Gross Amount".ToUpper
        DGLFooter1.Item(DFC_Description, DF1R_TotalFeeRefund).Value = "Fee Refund".ToUpper
        DGLFooter1.Item(DFC_Description, DF1R_ExcessRefund).Value = "Excess Refund".ToUpper
        DGLFooter1.Item(DFC_Description, DF1R_RegistrationAmountRefund).Value = "Reg. Amount Refund".ToUpper
        DGLFooter1.Item(DFC_Description, DF1R_TotalLineNetAmount).Value = "Net Refund Amount".ToUpper

        'DGLFooter1.CurrentCell = DGLFooter1(DFC_Amount, DF1R_RegistrationAmountRefund)
        'DGLFooter1.CurrentCell.Style.BackColor = Color.White
        'DGLFooter1.CurrentCell.Style.ForeColor = Color.Black
        DGLFooter1.Rows(DF1R_RegistrationAmountRefund).Visible = False
        DGLFooter1.Visible = False
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

            If e.KeyCode <> Keys.Return And Me.ActiveControl.Name = TxtRefundAmount.Name Then
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
                AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
                AgL.PubObjFrmPaymentDetail.ShowDialog()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec

                TxtRefundAmount.Text = Format(Val(PaymentRec.TotalAmount), "0.00")

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
            AgL.WinSetting(Me, 650, 950, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGLFooter1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            Topctrl1.ChangeAgGridState(DGLFooter1, False)
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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("FRef.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("FRef.Site_Code", AgL.PubSiteCode) & " "

            mQry = "Select FRef.DocId As SearchCode " & _
                    " From Sch_FeeRefund FRef " & _
                    " LEFT JOIN Voucher_Type Vt ON FRef.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                          " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
                  " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeRefund) & "" & _
                  " Order By Description"
            TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V1.DocId As Code, V1.StudentName As [Student Name], V1.AdmissionID, V1.Student As StudentCode " & _
                    " FROM ViewSch_Admission V1 " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By V1.StudentName "
            TxtAdmissionDocId.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT FRec1.Code, F.Name AS [Fee Name], FRec1.V_Date AS [Receive VDate], FRec1.FeeReceiveLessRefundAmount As Amount, " & _
                    " FRec1.AdmissionDocId, FRec1.FeeCode, F.FeeNature, Fg.Description AS FeeGroup, F.Refundable " & _
                    " FROM ViewSch_FeeReceive1 FRec1 " & _
                    " LEFT JOIN ViewSch_Fee F ON FRec1.FeeCode = F.Code " & _
                    " LEFT JOIN Sch_FeeGroup Fg ON F.FeeGroup = Fg.Code " & _
                    " Where FRec1.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " And " & _
                    " " & AgL.PubSiteCondition("FRec1.Site_Code", AgL.PubSiteCode) & " "
            DGL1.AgHelpDataSet(Col1FeeReceive1, 7) = AgL.FillData(mQry, AgL.GCn)

            Call IniFeeReceiveDocIdHelp()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IniFeeReceiveDocIdHelp()
        mQry = "Select Fr.DocId As Code, " & AgL.V_No_Field("Fr.DocId") & " [Voucher No], " & _
                " Fr.ReceiveAmount, Fr.AdvanceCarriedForward, Fr.V_Date, Fr.AdmissionDocId, " & _
                " Fr.ReceiveLessRefundAmount, Fr.RefundAmount As TotalRefundAmount, " & _
                " Fr.ExcessRefund As TotalExcessRefund, Fr.IsAdjustableReceipt, " & _
                " Fr.AdjustmentAmount As RegistrationAdjustmentAmount " & _
                " FROM ViewSch_FeeReceive Fr " & _
                " Left Join Voucher_Type Vt On Fr.V_Type = Vt.V_Type " & _
                " Where Vt.NCat In (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceive) & "," & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceiveAdjustment) & "," & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) & ") And " & _
                " " & AgL.PubSiteCondition("Fr.Site_Code", AgL.PubSiteCode) & "  " & _
                " Order By Fr.DocId "
        DGL1.AgHelpDataSet(Col1FeeReceiveDocId, 7) = AgL.FillData(mQry, AgL.GCn)
        DGL2.AgHelpDataSet(Col2FeeReceiveDocId, 7) = AgL.FillData(mQry, AgL.GCn)
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

                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeRefundPaymentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
                    AgL.PubObjFrmPaymentDetail.DeletePaymentDetail(AgL.GCn, AgL.ECmd)
                    AgL.PubObjFrmPaymentDetail = Nothing

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeRefund1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeRefund Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("FRef.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("FRef.Site_Code", AgL.PubSiteCode) & " "


            AgL.PubFindQry = "SELECT FRef.DocId As SearchCode, " & AgL.V_No_Field("FRef.DocId") & " As [Voucher No], " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], FRef.V_Date, FRef.RefundAmount AS [Refund Amount], " & _
                                " VAdm.StudentName as [Student], VAdm.AdmissionID, FRef.Remark " & _
                                " FROM Sch_FeeRefund FRef " & _
                                " LEFT JOIN Voucher_Type Vt ON FRef.V_Type = Vt.V_Type " & _
                                " LEFT JOIN SiteMast S ON FRef.Site_Code = S.Code " & _
                                " Left Join ViewSch_Admission VAdm On FRef.AdmissionDocId = VAdm.DocId " & mCondStr

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
        Call Ini_List()
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

            AgL.PubReportTitle = "Fee Refund "
            RepName = "Academic_Main_FeeRefund" : RepTitle = "Fee Refund"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If



            strQry = " SELECT FR.DocId, Convert(nVarChar, Convert(Numeric, Right(FR.DocID, 8))) + '/' + RTrim(LTrim(SubString(FR.DocID, 9, 5))) + '/' + RTrim(LTrim(SubString(FR.DocID, 4, 5))) + '/' + RTrim(LTrim(SubString(FR.DocID, 2, 2))) + '/' + Left(FR.DocID, 1)  as DocID_Print, " & _
                     " FR.Div_Code,FR.Site_Code,FR.V_Date,FR.V_Type,FR.V_Prefix,FR.V_No,FR.TotalLineAmount,FR.TotalLineNetAmount,FR.Remark,FR.PreparedBy,FR.U_EntDt,FR.U_AE,FR.Edit_Date,FR.ModifiedBy,FR.IsManageFee,FR.Refundamount, SFR.AdmissionDocId,  " & _
                     " FR1.Code AS Line_Code,FR1.Amount AS Line_Amount,FR1.NetAmount AS Line_NetAmount,   F.Dispname AS Fee_Description,    Adm.DocId, Adm.RegistrationDocId, Adm.AdmissionID, Stu.name As Student_Name, stu.FatherName , Stu.Add1, Stu.Add2, stu.CityName , " & _
                     " Adm.EnrollmentNo , PD.CashAc, PD.CashAmount, PD.BankAc, PD.BankAmount, PD.Bank_Code, PD.Chq_No, PD.Chq_Date, PD.Clg_Date, PD.CardAc, PD.CardAmount, PD.CardBank_Code, PD.Card_No, PD.AcTransferBankAc, PD.AcTransferAmount, PD.AcTransferBank_Code, " & _
                     " PD.TotalAmount, PD.AcTransferAcNo, PD.PartyDrCr, (CASE WHEN PD.CashAmount>0 THEN 'Cash' WHEN PD.BankAmount>0 THEN 'Cheque / DD' WHEN PD.CardAmount>0 THEN 'Credit / Debit Card' WHEN PD.AcTransferAmount>0 THEN 'A/c Transfer' END) AS PaymentMode, " & _
                     " PD.CashAmount+PD.BankAmount+PD.CardAmount+PD.AcTransferAmount AS PaymentAmount " & _
                     " FROM (Select * From dbo.Sch_FeeRefund Where DocId = '" & mDocId & "' ) FR " & _
                     " LEFT Join Sch_FeeRefund1 FR1 ON FR.DocId =FR1.DocId " & _
                     " LEFT JOIN ViewSch_FeeDue FSD ON fr1.code=fsd.feedue1code " & _
                     " LEFT JOIN viewSch_Fee F ON fsd.feecode =F.Code   " & _
                     " LEFT JOIN dbo.PaymentDetail PD ON Fr.DocId =PD.DocId  " & _
                     " LEFT JOIN Sch_FeeReceive SFR ON FR1.feereceivedocid=sfr.docid " & _
                     " LEFT JOIN ViewSch_Admission  Adm ON Fr.AdmissionDocId = Adm.DocId " & _
                     " LEFT JOIN ViewSch_Student Stu ON Adm.Student =stu.SubCode  "


            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)
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
        Dim I As Integer
        Dim mTrans As Boolean = False
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim bFeeRefund1Code$ = ""

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_FeeRefund ( " & _
                        " 	DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No,  " & _
                        " 	TotalLineAmount, TotalLineNetAmount, IsManageFee, " & _
                        " 	RefundAmount, ExcessRefund, Remark, RegistrationAmountRefund, " & _
                        " 	TotalFeeRefund, AdmissionDocId, " & _
                        "   PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ", " & _
                        " " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) & ", " & _
                        " " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & ", " & IIf(AgL.StrCmp(TxtIsManageFee.Text, "Yes"), 1, 0) & ",  " & _
                        " " & Val(TxtRefundAmount.Text) & ", " & Val(DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value) & ", " & AgL.Chk_Text(TxtRemark.Text) & ",  " & _
                        " " & Val(DGLFooter1.Item(DFC_Amount, DF1R_RegistrationAmountRefund).Value) & ", " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalFeeRefund).Value) & ", " & _
                        " " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & "," & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_FeeRefund " & _
                        " SET " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " TotalLineAmount = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) & ", " & _
                        " TotalLineNetAmount = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & ", " & _
                        " IsManageFee = " & IIf(AgL.StrCmp(TxtIsManageFee.Text, "Yes"), 1, 0) & ", " & _
                        " RefundAmount = " & Val(TxtRefundAmount.Text) & ", " & _
                        " ExcessRefund = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " RegistrationAmountRefund = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_RegistrationAmountRefund).Value) & ", " & _
                        " AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                        " TotalFeeRefund = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalFeeRefund).Value) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If DGL1.Item(Col1Select, I).Value.ToString.Trim = AgLibrary.ClsConstant.StrCheckedValue Then
                        If .Item(Col1Code, I).Value = "" Then
                            If .Item(Col1FeeReceiveDocId, I).Value <> "" And Val(.Item(Col1NetAmount, I).Value) > 0 Then
                                bFeeRefund1Code = AgL.GetMaxId("Sch_FeeRefund1", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)

                                mQry = "INSERT INTO Sch_FeeRefund1 ( " & _
                                        " 	Code, DocId, FeeReceive1, Amount, NetAmount, FeeReceiveDocId, ReturnHeadType, RegistrationAmount ) " & _
                                        " VALUES ( " & _
                                        " 	'" & bFeeRefund1Code & "', '" & mSearchCode & "', " & _
                                        "   " & AgL.Chk_Text(.AgSelectedValue(Col1FeeReceive1, I)) & ", " & _
                                        "   " & Val(.Item(Col1Amount, I).Value) & ", " & _
                                        "   " & Val(.Item(Col1NetAmount, I).Value) & ", " & _
                                        "   " & AgL.Chk_Text(.AgSelectedValue(Col1FeeReceiveDocId, I)) & ", " & _
                                        "   " & AgL.Chk_Text(.Item(Col1ReturnHeadType, I).Value) & ", " & _
                                        "   " & Val(.Item(Col1RegistrationAmount, I).Value) & " " & _
                                        " ) "
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            End If
                        Else
                            If .Item(Col1FeeReceiveDocId, I).Value <> "" Then
                                mQry = "Update Sch_FeeRefund1 " & _
                                        " SET " & _
                                        " 	FeeReceive1 = " & AgL.Chk_Text(.AgSelectedValue(Col1FeeReceive1, I)) & ", " & _
                                        " 	Amount = " & Val(.Item(Col1Amount, I).Value) & ", " & _
                                        " 	NetAmount = " & Val(.Item(Col1NetAmount, I).Value) & ", " & _
                                        " 	RegistrationAmount = " & Val(.Item(Col1RegistrationAmount, I).Value) & ", " & _
                                        "   FeeReceiveDocId = " & AgL.Chk_Text(.AgSelectedValue(Col1FeeReceiveDocId, I)) & ", " & _
                                        "   ReturnHeadType = " & AgL.Chk_Text(.Item(Col1ReturnHeadType, I).Value) & " " & _
                                        " WHERE Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & " "
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            Else
                                mQry = "Delete From Sch_FeeRefund1 Where Code = '" & .Item(Col1Code, I).Value & "'"
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            End If
                        End If
                    Else
                        mQry = "Delete From Sch_FeeRefund1 Where Code = '" & .Item(Col1Code, I).Value & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

            AgL.Dman_ExecuteNonQry("Delete From Sch_FeeRefundPaymentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

            AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
            AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
            If Not AgL.PubObjFrmPaymentDetail.SavePaymentDetail(PaymentRec, AgL.GCn, AgL.ECmd) Then Err.Raise(1, , "Save Error")
            If Not AgL.PubObjFrmPaymentDetail.AccountPosting(PaymentRec, AgL.GCn, AgL.Gcn_ConnectionString, AgL.ECmd, LedgAry, TxtRemark.Text) Then Err.Raise(1, , "Error in Ledger Posting")

            AgL.PubObjFrmPaymentDetail = Nothing

            mQry = "INSERT INTO Sch_FeeRefundPaymentDetail ( DocId, LedgerMDocId ) VALUES ( " & _
                    " '" & mSearchCode & "', '" & mSearchCode & "' )"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)


            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            Else
                Call IniFeeReceiveDocIdHelp()
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode

                mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

                Topctrl1.FButtonClick(0)

                If MsgBox("Want To Print Voucher?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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
        Dim I As Integer
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
                mQry = "Select FRef.*, Vt.NCat, Adm.Student, Adm.AdmissionId " & _
                       " From Sch_FeeRefund FRef " & _
                       " Left Join Voucher_Type Vt On FRef.V_Type = Vt.V_Type " & _
                       " Left Join Sch_Admission Adm On FRef.AdmissionDocId = Adm.DocId " & _
                       " Where FRef.DocId='" & mSearchCode & "'"
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

                        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = Format(AgL.VNull(.Rows(0)("TotalLineAmount")), "0.00")
                        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = Format(AgL.VNull(.Rows(0)("TotalLineNetAmount")), "0.00")
                        DGLFooter1.Item(DFC_Amount, DF1R_TotalFeeRefund).Value = Format(AgL.VNull(.Rows(0)("TotalFeeRefund")), "0.00")
                        DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value = Format(AgL.VNull(.Rows(0)("ExcessRefund")), "0.00")

                        TxtIsManageFee.Text = IIf(AgL.VNull(.Rows(0)("IsManageFee")), "Yes", "No")

                        DGLFooter1.Item(DFC_Amount, DF1R_RegistrationAmountRefund).Value = Format(AgL.VNull(.Rows(0)("RegistrationAmountRefund")), "0.00")

                        TxtRefundAmount.Text = Format(AgL.VNull(.Rows(0)("RefundAmount")), "0.00")

                        LblValTotalLineAmount.Text = IIf(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) = 0, "-", DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value)
                        LblValTotalLineNetAmount.Text = IIf(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) = 0, "-", DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value)
                        LblValTotalFeeRefund.Text = IIf(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalFeeRefund).Value) = 0, "-", DGLFooter1.Item(DFC_Amount, DF1R_TotalFeeRefund).Value)
                        LblValExcessRefund.Text = IIf(Val(DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value) = 0, "-", DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value)


                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select vFRef1.FeeReceiveDocId, Adm.Student, Adm.AdmissionId, FRef.AdmissionDocId, " & _
                        " IsNull(Fr.ReceiveAmount,0) As ReceiveAmount, Fr.V_Date As FeeReceiveVDate, " & _
                        " IsNull(Fr.RefundAmount,0) - IsNull(vFRef1.FeeRefund,0) As TotalRefundAmount, " & _
                        " IsNull(Fr.ExcessRefund,0) - IsNull(vFRef1.AdvanceRefund,0) As TotalExcessRefund, " & _
                        " IsNull(Fr.ReceiveLessRefundAmount,0) + IsNull(Fr.RefundAmount,0) As ReceiveLessRefundAmount," & _
                        " IsNull(Fr.AdvanceCarriedForward,0) As AdvanceCarriedForward, " & _
                        " IsNull(Fr.AdjustmentAmount,0) As RegistrationAdjustmentAmount, " & _
                        " IsNull(Fr.RegistrationAmountRefund,0) - IsNull(vFRef1.RegistrationAmountRefund,0) As TotalRegistrationAmountRefund " & _
                        " FROM Sch_FeeRefund FRef " & _
                        " INNER JOIN (SELECT FRef1.DocId, FRef1.FeeReceiveDocId, " & _
                        " Sum(CASE FRef1.ReturnHeadType WHEN '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' THEN 0 ELSE FRef1.NetAmount END) AS FeeRefund,  " & _
                        " Sum(CASE FRef1.ReturnHeadType WHEN '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' THEN FRef1.NetAmount ELSE 0 END) AS AdvanceRefund, " & _
                        " IsNull(Sum(FRef1.RegistrationAmount),0) AS RegistrationAmountRefund " & _
                        " FROM Sch_FeeRefund1 FRef1 " & _
                        " WHERE FRef1.DocId = '" & mSearchCode & "' " & _
                        " GROUP BY FRef1.DocId, FRef1.FeeReceiveDocId) vFRef1 ON FRef.DocId = vFRef1.DocId " & _
                        " Left Join ViewSch_FeeReceive Fr ON vFRef1.FeeReceiveDocId = Fr.DocId   " & _
                        " Left Join Sch_Admission Adm On FRef.AdmissionDocId = Adm.DocId   " & _
                        " Where FRef.DocId = '" & mSearchCode & "' " & _
                        " Order By Fr.V_Date Desc, Fr.RowId "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL2.RowCount = 1 : DGL2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count

                            DGL2.Item(Col2Select, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                            DGL2.AgSelectedValue(Col2FeeReceiveDocId, I) = AgL.XNull(.Rows(I)("FeeReceiveDocId"))
                            DGL2.Item(Col2FeeReceiveVDate, I).Value = Format(AgL.XNull(.Rows(I)("FeeReceiveVDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL2.Item(Col2ReceiveAmount, I).Value = Format(AgL.VNull(.Rows(I)("ReceiveAmount")), "0.00")
                            DGL2.Item(Col2AdvanceCarriedForward, I).Value = Format(AgL.VNull(.Rows(I)("AdvanceCarriedForward")), "0.00")
                            DGL2.Item(Col2ReceiveLessRefundAmount, I).Value = Format(AgL.VNull(.Rows(I)("ReceiveLessRefundAmount")), "0.00")
                            DGL2.Item(Col2TotalRefundAmount, I).Value = Format(AgL.VNull(.Rows(I)("TotalRefundAmount")), "0.00")
                            DGL2.Item(Col2TotalExcessRefund, I).Value = Format(AgL.VNull(.Rows(I)("TotalExcessRefund")), "0.00")
                            DGL2.Item(Col2RegistrationAdjustmentAmount, I).Value = Format(AgL.VNull(.Rows(I)("RegistrationAdjustmentAmount")), "0.00")
                            DGL2.Item(Col2TotalRegistrationAmountRefund, I).Value = Format(AgL.VNull(.Rows(I)("TotalRegistrationAmountRefund")), "0.00")
                        Next
                    End If
                End With


                mQry = "Select FRef1.*, FRec.V_Date, FRec1.FeeDue1 As FeeDue1Code, " & _
                        " F.FeeNature, Fg.Description AS FeeGroup, F.Refundable  " & _
                        " From Sch_FeeRefund1 FRef1 " & _
                        " LEFT JOIN Sch_FeeReceive FRec ON FRec.DocId = FRef1.FeeReceiveDocId " & _
                        " LEFT JOIN ViewSch_FeeReceive1 FRec1 ON FRef1.FeeReceive1 = FRec1.Code " & _
                        " Left Join ViewSch_Fee F On FRec1.FeeCode = F.Code " & _
                        " LEFT JOIN Sch_FeeGroup Fg ON F.FeeGroup = Fg.Code " & _
                        " Where FRef1.DocId='" & mSearchCode & "' " & _
                        " Order By FRec.V_Date, FRef1.RowId "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.Item(Col1Select, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                            DGL1.Item(Col1Code, I).Value = AgL.XNull(.Rows(I)("Code"))
                            DGL1.AgSelectedValue(Col1FeeReceiveDocId, I) = AgL.XNull(.Rows(I)("FeeReceiveDocId"))
                            DGL1.AgSelectedValue(Col1FeeReceive1, I) = AgL.XNull(.Rows(I)("FeeReceive1"))
                            DGL1.Item(Col1ReturnHeadType, I).Value = AgL.XNull(.Rows(I)("ReturnHeadType"))
                            DGL1.Item(Col1FeeDue1, I).Value = AgL.XNull(.Rows(I)("FeeDue1Code"))
                            DGL1.Item(Col1FeeGroup, I).Value = AgL.XNull(.Rows(I)("FeeGroup"))
                            DGL1.Item(Col1FeeNature, I).Value = AgL.XNull(.Rows(I)("FeeNature"))
                            DGL1.Item(Col1RefundableYesNo, I).Value = AgL.VNull(.Rows(I)("Refundable"))

                            DGL1.Item(Col1NetAmount, I).Value = Format(AgL.VNull(.Rows(I)("NetAmount")), "0.00")
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.Item(Col1RegistrationGrossAmt, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.Item(Col1RegistrationAmount, I).Value = Format(AgL.VNull(.Rows(I)("RegistrationAmount")), "0.00")
                        Next I
                        BtnFillFee.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                    End If
                End With

                ''Payment Detail Moverec Common
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAdmissionDocId.Tag, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
                AgL.PubObjFrmPaymentDetail.FillPaymentRec()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec
                AgL.PubObjFrmPaymentDetail = Nothing
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            DTbl = Nothing
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = ""

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()

        Call BlankFooterGrid()
        PaymentRec = Nothing

        TxtIsManageFee.Text = "No" : BtnFillFee.Tag = ""
        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub BlankFooterGrid(Optional ByVal bIsCalculationCall As Boolean = False)
        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = "" : DGLFooter1.Item(DFC_Percentage, DF1R_TotalLineNetAmount).Value = ""
        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = "" : DGLFooter1.Item(DFC_Percentage, DF1R_TotalLineAmount).Value = ""
        DGLFooter1.Item(DFC_Amount, DF1R_TotalFeeRefund).Value = "" : DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value = ""
        DGLFooter1.Item(DFC_Amount, DF1R_RegistrationAmountRefund).Value = ""

        If Not bIsCalculationCall Then
            '<Executable Code>
        End If
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        BtnFillFee.Enabled = Enb : BtnFillFeeReceiveVoucher.Enabled = Enb

        If Enb Then
            If DGLFooter1.Rows(DF1R_RegistrationAmountRefund).Visible = True Then
                DGLFooter1.CurrentCell = DGLFooter1(DFC_Amount, DF1R_RegistrationAmountRefund)
                DGLFooter1.CurrentCell.ReadOnly = False
            End If
        End If

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
            TxtAdmissionDocId.Enabled = False
            '=========================================================
            '===========< BtnFillFee Will Remain Disable >============
            '======< As Code Generated in FeeRefund1 Table >=========
            '=========================================================
            BtnFillFeeReceiveVoucher.Enabled = False
            BtnFillFee.Enabled = False
            '=========================================================
        End If
    End Sub


    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1FeeReceive1
                    'DGL1.AgRowFilter(Col1FeeReceive1) = " Code = " & AgL.Chk_Text(TxtFeeReceiveDocId.AgSelectedValue) & ""
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
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Select
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(DGL1, Col1Select)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
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
                    Case Col1NetAmount
                        If DGL1.Item(Col1Select, mRowIndex).Value Is Nothing Then DGL1.Item(Col1Select, mRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                        If Val(DGL1.Item(Col1NetAmount, e.RowIndex).Value) > Val(DGL1.Item(Col1Amount, e.RowIndex).Value) Then
                            DGL1.Item(Col1NetAmount, mRowIndex).Value = Format(Val(DGL1.Item(Col1Amount, mRowIndex).Value), "0.00")
                        End If

                        DGL1.Item(mColumnIndex, mRowIndex).Value = Format(Val(DGL1.Item(mColumnIndex, mRowIndex).Value), "0.00")

                    Case Col1Select
                        If DGL1.Item(Col1Select, mRowIndex).Value Is Nothing Then DGL1.Item(Col1Select, mRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Select
                    Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGL1.CellValidating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .CurrentCell.ColumnIndex
                    Case Col1NetAmount
                        If DGL1.Item(Col1Select, mRowIndex).Value Is Nothing Then DGL1.Item(Col1Select, mRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                End Select
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL1.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Select
                    Call AgL.ProcSetCheckColumnCellValue(DGL1, Col1Select)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded, DGL2.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, Col_SNo)

        If DGL1.Rows.Count = 1 And Topctrl1.Mode = "Add" Then
            If DGL1.Item(Col1FeeReceive1, 0).Value Is Nothing Then DGL1.Item(Col1FeeReceive1, 0).Value = ""
            If DGL1.Item(Col1FeeReceive1, 0).Value.ToString.Trim = "" Then
                If TxtV_Type.Enabled = False Then TxtV_Type.Enabled = True
            End If
        End If

        Call Calculation()
    End Sub

    Private Sub DGL2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL2.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            Select Case DGL2.CurrentCell.ColumnIndex
                Case Col1Select
                    If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                        If e.KeyCode = Keys.Space Then
                            AgL.ProcSetCheckColumnCellValue(DGL2, Col2Select)
                        End If
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL2_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL2.CellEndEdit
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL2
                Select Case .CurrentCell.ColumnIndex
                    Case Col2Select
                        If DGL2.Item(Col2Select, mRowIndex).Value Is Nothing Then DGL2.Item(Col2Select, mRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                        If DGL2.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Then DGL2.Item(mColumnIndex, mRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                End Select
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL2.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            Select Case DGL2.CurrentCell.ColumnIndex
                Case Col2Select
                    Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL2_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGL2.CellValidating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL2
                Select Case .CurrentCell.ColumnIndex
                    'Case <ColumnIndex>
                    '<Executable Code>
                End Select
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DGL2.CellMouseUp
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL2.CurrentCell.ColumnIndex
                Case Col2Select
                    If AgL.StrCmp(Topctrl1.Mode, "Add") Then Call AgL.ProcSetCheckColumnCellValue(DGL2, Col2Select)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL2_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL2.RowsRemoved
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
        TxtSite_Code.Enter, TxtDocId.Enter, TxtV_Date.Enter, TxtV_No.Enter, TxtV_Type.Enter, _
        TxtAdmissionDocId.Enter, TxtAdmissionID.Enter, TxtIsManageFee.Enter, _
        TxtRemark.Enter
        Try
            Select Case sender.name
                'Case sender.Name
                '<Executable Code>

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtDocId.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtV_Date.Validating, _
          TxtAdmissionDocId.Validating, TxtSite_Code.Validating, TxtRemark.Validating, TxtAdmissionID.Validating, _
           TxtIsManageFee.Validating, TxtRefundAmount.Validating

        Dim DrTemp As DataRow() = Nothing

        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblV_Type.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
                        End If
                        DrTemp = Nothing
                    End If

                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                    TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text.ToString)

                Case TxtAdmissionDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtAdmissionID.Text = ""
                        LblAdmissionDocId.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtAdmissionID.Text = AgL.XNull(DrTemp(0)("AdmissionID"))
                            LblAdmissionDocId.Tag = AgL.XNull(DrTemp(0)("StudentCode"))
                        End If
                        DrTemp = Nothing
                    End If


                Case TxtIsManageFee.Name
                    Call ProcManageFee()

            End Select

            Call Calculation()
            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mSearchCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Call BlankFooterGrid(True)

        LblValTotalLineAmount.Text = "" : LblValTotalLineNetAmount.Text = ""
        LblValTotalFeeRefund.Text = "" : LblValExcessRefund.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""
                If .Item(Col1Amount, I).Value Is Nothing Then .Item(Col1Amount, I).Value = ""
                If .Item(Col1FeeReceive1, I).Value Is Nothing Then .Item(Col1FeeReceive1, I).Value = ""
                If .Item(Col1ReturnHeadType, I).Value Is Nothing Then .Item(Col1ReturnHeadType, I).Value = ""
                If .Item(Col1Select, I).Value Is Nothing Then .Item(Col1Select, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                If DGL1.Item(Col1Select, I).Value.ToString.Trim = "" Then DGL1.Item(Col1Select, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                If DGL1.Item(Col1Select, I).Value.ToString.Trim = AgLibrary.ClsConstant.StrCheckedValue And _
                    .Item(Col1FeeReceiveDocId, I).Value <> "" Then
                    'Footer Detail
                    DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) + Val(.Item(Col1Amount, I).Value), "0.00")
                    DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) + Val(.Item(Col1NetAmount, I).Value), "0.00")

                    If AgL.StrCmp(.Item(Col1ReturnHeadType, I).Value, Academic_ProjLib.ClsMain.ReturnHeadType_Advance) Then
                        DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value) + Val(.Item(Col1NetAmount, I).Value), "0.00")
                    Else
                        DGLFooter1.Item(DFC_Amount, DF1R_TotalFeeRefund).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalFeeRefund).Value) + Val(.Item(Col1NetAmount, I).Value), "0.00")
                    End If

                    If Val(.Item(Col1RegistrationAmount, I).Value) > 0 Then
                        DGL1.Item(Col1RegistrationAmount, I).Value = Format(Val(DGL1.Item(Col1NetAmount, I).Value), "0.00")
                        DGLFooter1.Item(DFC_Amount, DF1R_RegistrationAmountRefund).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_RegistrationAmountRefund).Value) + Val(.Item(Col1RegistrationAmount, I).Value), "0.00")
                    Else
                        DGL1.Item(Col1RegistrationAmount, I).Value = ""
                    End If

                End If
            Next
        End With

        LblValTotalLineAmount.Text = IIf(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) = 0, "-", DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value)
        LblValTotalLineNetAmount.Text = IIf(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) = 0, "-", DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value)
        LblValTotalFeeRefund.Text = IIf(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalFeeRefund).Value) = 0, "-", DGLFooter1.Item(DFC_Amount, DF1R_TotalFeeRefund).Value)
        LblValExcessRefund.Text = IIf(Val(DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value) = 0, "-", DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value)
    End Sub

    Private Sub ProcManageFee()
        Dim I As Integer = 0
        Dim bTotal As Double = 0, bDiffAmount As Double = 0

        If Topctrl1.Mode = "Browse" Then Exit Sub

        bDiffAmount = Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) - Val(TxtRefundAmount.Text)

        If AgL.StrCmp(TxtIsManageFee.Text, "Yes") Then
            If bDiffAmount <= 0 Then
                TxtIsManageFee.Text = "No"
            Else
                With DGL1
                    For I = .Rows.Count - 1 To 0 Step -1
                        If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""

                        If .Item(Col1FeeReceiveDocId, I).Value <> "" _
                            And Val(.Item(Col1Amount, I).Value) > 0 _
                            And .Item(Col1Select, I).Value.ToString.Trim = AgLibrary.ClsConstant.StrCheckedValue Then
                            If bDiffAmount >= bTotal + Val(.Item(Col1Amount, I).Value) Then
                                bTotal += Val(.Item(Col1Amount, I).Value)
                                .Item(Col1NetAmount, I).Value = ""
                            ElseIf bTotal < bDiffAmount Then
                                .Item(Col1NetAmount, I).Value = Format(Val(.Item(Col1Amount, I).Value) - (bDiffAmount - bTotal), "0.00")
                                bTotal = bDiffAmount
                            Else
                                Exit For
                            End If
                        End If

                    Next
                End With
            End If
        End If
        Call Calculation()
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bNetAdvance As Double = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtAdmissionDocId, "Student") Then Exit Function
            If AgL.RequiredField(TxtRefundAmount, "Refund Amount", True) Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""
                    If .Item(Col1Amount, I).Value Is Nothing Then .Item(Col1Amount, I).Value = ""
                    If .Item(Col1FeeReceive1, I).Value Is Nothing Then .Item(Col1FeeReceive1, I).Value = ""
                    If .Item(Col1ReturnHeadType, I).Value Is Nothing Then .Item(Col1ReturnHeadType, I).Value = ""

                    If DGL1.Item(Col1Select, I).Value.ToString.Trim = AgLibrary.ClsConstant.StrCheckedValue And _
                        .Item(Col1FeeReceiveDocId, I).Value <> "" Then

                        If Val(.Item(Col1NetAmount, I).Value) > Val(.Item(Col1Amount, I).Value) Then
                            MsgBox("Refund Amount Is Greater Than From Rs. " & Format(Val(.Item(Col1Amount, I).Value), "0.00") & " At Row No. : " & Val(.Item(Col_SNo, I).Value) & "!...", MsgBoxStyle.Information, "Validation Check")
                            DGL1.CurrentCell = DGL1(Col1NetAmount, I) : DGL1.Focus() : Exit Function
                        End If
                    End If
                Next
            End With

            If BtnFillFee.Tag.ToString.Trim <> "" Then
                If CDate(TxtV_Date.Text) < CDate(BtnFillFee.Tag) Then
                    MsgBox("Voucher Date Can't Be Less Than From " & BtnFillFee.Tag & "!...")
                    TxtV_Date.Focus()
                    Exit Function
                End If
            End If

            If Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) < 0 Then
                MsgBox("Net Fee Can't Be < 0 (Zero)!...")
                DGL1.CurrentCell = DGL1(Col1NetAmount, 0) : DGL1.Focus()
                Exit Function
            End If

            If Val(TxtRefundAmount.Text) > Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) Then
                MsgBox("Refund Amount Can't Be Greater Than From Rs. " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & "!...")
                TxtRefundAmount.Focus() : Exit Function
            ElseIf Val(TxtRefundAmount.Text) < Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) Then
                MsgBox("Refund Amount Can't Be Less Than From Rs. " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & "!...")
                TxtRefundAmount.Focus() : Exit Function
            End If


            If AgL.StrCmp(TxtIsManageFee.Text, "Yes") _
                And Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) = Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) Then
                MsgBox("Manage Fee Can't Be ""Yes""!...")
                TxtIsManageFee.Focus() : Exit Function
            End If

            mQry = "SELECT Sum(FRecv.AdvanceCarriedForward - FRecv.Advance  - IsNull(vFRef.ExcessRefund,0)) AS NetAdvance " & _
                    " FROM Sch_FeeReceive FRecv " & _
                    " LEFT JOIN ( " & _
                    " SELECT FRef1.FeeReceiveDocId ,  " & _
                    " Sum(CASE FRef1.ReturnHeadType WHEN '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' THEN FRef1.NetAmount ELSE 0 END) AS ExcessRefund  " & _
                    " FROM Sch_FeeRefund1 FRef1 With (NoLock)  " & _
                    " WHERE " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " FRef1.DocId <> '" & mSearchCode & "' ") & " " & _
                    " GROUP BY FRef1.FeeReceiveDocId " & _
                    " ) AS vFRef ON FRecv.DocId = vFRef.FeeReceiveDocId " & _
                    " WHERE FRecv.AdmissionDocId = '" & TxtAdmissionDocId.AgSelectedValue & "' " & _
                    " GROUP BY FRecv.AdmissionDocId "
            bNetAdvance = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)

            If Val(DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value) > bNetAdvance Then
                MsgBox("Excess Refund Amount Is Greater Than From Rs. """ & Format(bNetAdvance, "0.00") & """!...", MsgBoxStyle.Information, "Validation Check")
                TxtRefundAmount.Focus() : Exit Function
            End If

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            'If AgL.XNull(DtSch_Enviro.Rows(0)("DiscountAc")).ToString.Trim = "" Then MsgBox("Define Discount A/c In Environment Settings!...") : Exit Function
            'If AgL.XNull(DtSch_Enviro.Rows(0)("FeeAdjustmentAc")).ToString.Trim = "" Then MsgBox("Define Fee Adjustment A/c In Environment Settings!...") : Exit Function

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
            TxtV_Type.Enabled = False
        End If
        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled = True Then TxtV_Type.Focus() Else TxtV_Date.Focus()
        Else
            TxtV_Date.Focus()
        End If

    End Sub

    Private Sub BtnFillFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillFee.Click, BtnFillFeeReceiveVoucher.Click
        Try
            Select Case sender.name
                Case BtnFillFee.Name
                    Call ProcFillFee()

                Case BtnFillFeeReceiveVoucher.Name
                    Call ProcFillFeeReceiveVoucher()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillFee()
        Dim DtTemp As DataTable, DtTemp1 As DataTable
        Dim I As Integer
        Dim bStrFeeReceiveDocIdList$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            TxtIsManageFee.Text = "No"
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            BtnFillFee.Tag = ""

            If AgL.RequiredField(TxtV_Date) Then Exit Sub
            If AgL.RequiredField(TxtAdmissionDocId) Then Exit Sub

            With DGL2
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2Select, I).Value.ToString = AgLibrary.ClsConstant.StrCheckedValue _
                        And .Item(Col2FeeReceiveDocId, I).Value.ToString.Trim <> "" Then

                        If bStrFeeReceiveDocIdList.Trim = "" Then
                            bStrFeeReceiveDocIdList = AgL.Chk_Text(.AgSelectedValue(Col2FeeReceiveDocId, I))
                        Else
                            bStrFeeReceiveDocIdList += "," + AgL.Chk_Text(.AgSelectedValue(Col2FeeReceiveDocId, I))
                        End If
                    End If
                Next
            End With

            If bStrFeeReceiveDocIdList.Trim = "" Then
                MsgBox("Please Select Fee Receive Vouchers To Return!...")
                If DGL2.Rows.Count > 0 Then
                    DGL2.CurrentCell = DGL2(Col2Select, 0) : DGL2.Focus()
                End If
                Exit Sub
            End If

            mQry = "SELECT '" & Academic_ProjLib.ClsMain.ReturnHeadType_Fee & "' As ReturnHeadType, FRec1.Code AS FeeReceive1Code, FRec1.DocId As FeeReceiveDocId, FRec1.FeeDue1 As FeeDue1Code, " & _
                    " FRec1.FeeReceiveLessRefundAmount + IsNull(VFRef1.NetAmount,0) AS Amount, FRec1.V_Date, " & _
                    " F.FeeNature, Fg.Description AS FeeGroup, F.Refundable, FRec1.RowId As RowId, FRec1.FeeRegistrationRefund " & _
                    " FROM ViewSch_FeeReceive1 FRec1 " & _
                    " LEFT JOIN (SELECT FRef1.* FROM Sch_FeeRefund1 FRef1 WHERE " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=2 ", " FRef1.DocId = '" & mSearchCode & "' ") & " )  VFref1 ON FRec1.Code = VFRef1.FeeReceive1 " & _
                    " Left Join ViewSch_Fee F On FRec1.FeeCode = F.Code " & _
                    " LEFT JOIN Sch_FeeGroup Fg ON F.FeeGroup = Fg.Code " & _
                    " WHERE Frec1.DocId in (" & bStrFeeReceiveDocIdList & ") And " & _
                    " FRec1.FeeReceiveLessRefundAmount + IsNull(VFRef1.Amount,0) > 0 "
            mQry += " UNION ALL " & _
                    " SELECT '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' As ReturnHeadType, Null AS FeeReceive1Code, FRec.DocId As FeeReceiveDocId, Null As FeeDue1Code, " & _
                    " FRec.AdvanceCarriedForward - FRec.ExcessRefund + IsNull(VFRef1.NetAmount,0) AS Amount, FRec.V_Date, " & _
                    " Null As FeeNature, Null AS FeeGroup, Convert(bit,1) As Refundable, 9999 As RowId, 0 As FeeRegistrationRefund " & _
                    " FROM ViewSch_FeeReceive FRec " & _
                    " LEFT JOIN (SELECT FRef1.* FROM Sch_FeeRefund1 FRef1 WHERE FRef1.ReturnHeadType = '" & Academic_ProjLib.ClsMain.ReturnHeadType_Advance & "' And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=2 ", " FRef1.DocId = '" & mSearchCode & "' ") & " )  VFref1 ON FRec.DocId = VFRef1.FeeReceiveDocId " & _
                    " WHERE FRec.DocId in (" & bStrFeeReceiveDocIdList & ") And " & _
                    " FRec.AdvanceCarriedForward - FRec.ExcessRefund + IsNull(VFRef1.NetAmount,0) > 0 " & _
                    " Order By V_Date, FeeReceiveDocId, RowId "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    TxtAdmissionDocId.Enabled = False

                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.Item(Col1Select, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                        DGL1.Item(Col1ReturnHeadType, I).Value = AgL.XNull(.Rows(I)("ReturnHeadType"))
                        DGL1.AgSelectedValue(Col1FeeReceiveDocId, I) = AgL.XNull(.Rows(I)("FeeReceiveDocId"))
                        DGL1.AgSelectedValue(Col1FeeReceive1, I) = AgL.XNull(.Rows(I)("FeeReceive1Code"))
                        DGL1.Item(Col1FeeDue1, I).Value = AgL.XNull(.Rows(I)("FeeDue1Code"))
                        DGL1.Item(Col1FeeGroup, I).Value = AgL.XNull(.Rows(I)("FeeGroup"))
                        DGL1.Item(Col1FeeNature, I).Value = AgL.XNull(.Rows(I)("FeeNature"))
                        DGL1.Item(Col1RefundableYesNo, I).Value = AgL.VNull(.Rows(I)("Refundable"))

                        DGL1.Item(Col1NetAmount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")

                        If AgL.StrCmp(AgL.XNull(.Rows(I)("ReturnHeadType")), Academic_ProjLib.ClsMain.ReturnHeadType_Fee) Then
                            DGL1.Item(Col1RegistrationGrossAmt, I).Value = Format(AgL.VNull(.Rows(I)("Amount")) - AgL.VNull(.Rows(I)("FeeRegistrationRefund")), "0.00")
                        Else
                            DGL1.Item(Col1RegistrationGrossAmt, I).Value = ""
                        End If
                        DGL1.Item(Col1RegistrationAmount, I).Value = DGL1.Item(Col1RegistrationGrossAmt, I).Value
                    Next I

                    BtnFillFee.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                Else
                    TxtAdmissionDocId.Enabled = True

                    MsgBox("No Fee Exists To Refund!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            DtTemp1 = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Sub ProcFillFeeReceiveVoucher()
        Dim DtTemp As DataTable, DtTemp1 As DataTable
        Dim I As Integer
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL2.RowCount = 1 : DGL2.Rows.Clear()

            If AgL.RequiredField(TxtSite_Code, "Branch/Site") Then Exit Sub
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Sub
            If AgL.RequiredField(TxtAdmissionDocId, "Student") Then Exit Sub

            mQry = "Select Fr.DocId, Fr.V_Date, Fr.ReceiveAmount, Fr.AdvanceCarriedForward, " & _
                    " Fr.ReceiveLessRefundAmount, Fr.RefundAmount As TotalRefundAmount, " & _
                    " Fr.ExcessRefund As TotalExcessRefund, Fr.IsAdjustableReceipt, " & _
                    " Fr.AdjustmentAmount As RegistrationAdjustmentAmount, " & _
                    " IsNull(Fr.RegistrationAmountRefund,0) As TotalRegistrationAmountRefund " & _
                    " FROM ViewSch_FeeReceive Fr " & _
                    " Left Join Voucher_Type Vt On Fr.V_Type = Vt.V_Type " & _
                    " Where Vt.NCat In (" & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceive) & "," & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceiveAdjustment) & "," & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_OpeningAdvanceFee) & ") " & _
                    " And Fr.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                    " And Fr.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " " & _
                    " And Fr.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " " & _
                    " And ((Fr.ReceiveAmount - Fr.RefundAmount) <> 0 OR (Fr.AdvanceCarriedForward - Fr.ExcessRefund) <> 0 Or (IsNull(Fr.AdjustmentAmount,0) - IsNull(Fr.RegistrationAmountRefund,0) ) <> 0) " & _
                    " Order By Fr.V_Date Desc, Fr.RowId "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL2.RowCount = 1 : DGL2.Rows.Clear()
                If .Rows.Count > 0 Then
                    TxtAdmissionDocId.Enabled = False

                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL2.Rows.Add()
                        DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count

                        DGL2.Item(Col2Select, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                        DGL2.AgSelectedValue(Col2FeeReceiveDocId, I) = AgL.XNull(.Rows(I)("DocId"))
                        DGL2.Item(Col2FeeReceiveVDate, I).Value = Format(AgL.XNull(.Rows(I)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        DGL2.Item(Col2ReceiveAmount, I).Value = Format(AgL.VNull(.Rows(I)("ReceiveAmount")), "0.00")
                        DGL2.Item(Col2AdvanceCarriedForward, I).Value = Format(AgL.VNull(.Rows(I)("AdvanceCarriedForward")), "0.00")
                        DGL2.Item(Col2ReceiveLessRefundAmount, I).Value = Format(AgL.VNull(.Rows(I)("ReceiveLessRefundAmount")), "0.00")
                        DGL2.Item(Col2TotalRefundAmount, I).Value = Format(AgL.VNull(.Rows(I)("TotalRefundAmount")), "0.00")
                        DGL2.Item(Col2TotalExcessRefund, I).Value = Format(AgL.VNull(.Rows(I)("TotalExcessRefund")), "0.00")
                        DGL2.Item(Col2RegistrationAdjustmentAmount, I).Value = Format(AgL.VNull(.Rows(I)("RegistrationAdjustmentAmount")), "0.00")
                        DGL2.Item(Col2TotalRegistrationAmountRefund, I).Value = Format(AgL.VNull(.Rows(I)("TotalRegistrationAmountRefund")), "0.00")
                    Next I
                Else
                    TxtAdmissionDocId.Enabled = True

                    MsgBox("No Fee Receive Voucher Exists To Refund!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL2.RowCount = 1 : DGL2.Rows.Clear()
        Finally
            DtTemp = Nothing
            DtTemp1 = Nothing
            Call Calculation()
        End Try
    End Sub

End Class
