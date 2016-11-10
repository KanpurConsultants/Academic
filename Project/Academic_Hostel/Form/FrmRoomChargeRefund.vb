Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRoomChargeRefund

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1ChargeReceive1 As Byte = 1
    Private Const Col1ChargeDue1 As Byte = 2
    Private Const Col1ChargeGroup As Byte = 3
    Private Const Col1ChargeNature As Byte = 4
    Private Const Col1Amount As Byte = 5
    Private Const Col1NetAmount As Byte = 6
    Private Const Col1Code As Byte = 7


    Public WithEvents DGLFooter1 As New AgControls.AgDataGrid
    '=============== <Column Index> ========================
    Private Const DFC_Description As Byte = 0
    Private Const DFC_Percentage As Byte = 1
    Private Const DFC_Amount As Byte = 2

    '=============== <Row Index> ===========================
    Private Const DF1R_TotalLineAmount As Byte = 0
    Private Const DF1R_TotalLineNetAmount As Byte = 1
    Private Const DF1R_ExcessRefund As Byte = 2

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
        ''================< Charge Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1ChargeReceive1", 220, 8, "Charge Head", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1ChargeDue1", 180, 8, "Charge Due1 Code", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1ChargeGroup", 100, 8, "Charge Group", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1ChargeNature", 60, 8, "Charge Nature", True, True, False)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 80, 8, 2, False, "Amount", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1NetAmount", 80, 8, 2, False, "Refund Amount", True, False, True)
            .AddAgTextColumn(DGL1, "DGL1Code", 30, 10, "Code", False, True, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False


        ''==============================================================================
        ''================< Footer Data Grid-1 >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGLFooter1, "DGLF1Description", 180, 5, "Description", True, True, False)
            .AddAgNumberColumn(DGLFooter1, "DGLF1Percentage", 40, 2, 2, False, " % ", False, True, True)
            .AddAgNumberColumn(DGLFooter1, "DGLF1Amount", 100, 8, 2, False, "Amount", True, True, True)
        End With
        AgL.AddAgDataGrid(DGLFooter1, PnlFooter1)
        DGLFooter1.RowCount = 4
        DGLFooter1.AllowUserToAddRows = False
        DGLFooter1.Item(DFC_Description, DF1R_TotalLineAmount).Value = "Gross Amount".ToUpper
        DGLFooter1.Item(DFC_Description, DF1R_TotalLineNetAmount).Value = "Net Amount".ToUpper
        DGLFooter1.Item(DFC_Description, DF1R_ExcessRefund).Value = "Excess Refund".ToUpper
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
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAllotmentDocId.Tag, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
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
            AgL.WinSetting(Me, 600, 950, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGLFooter1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("CR.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("CR.Site_Code", AgL.PubSiteCode) & " "

            mQry = "Select CR.DocId As SearchCode " & _
                    " From Ht_ChargeRefund CR " & _
                    " LEFT JOIN Voucher_Type Vt ON CR.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
              " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeRefund) & "" & _
              " Order By Description"
        TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select V1.DocId As Code, V1.MemberName As [Member Name], V1.FatherName, " & _
                " V1.MemberCode As MemberCode, V1.LeftDate " & _
                " FROM ViewHt_RoomAllotment V1 " & _
                " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By V1.MemberName "
        TxtAllotmentDocId.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT CRec1.Code, C.ChargeName AS [Charge Name], CRec1.V_Date AS [Receive VDate], " & _
               " CRec1.ChargeReceiveLessRefundAmount As Amount, " & _
               " CRec1.AllotmentDocId, CRec1.ChargeCode, C.ChargeNature, Cg.Description AS ChargeGroup" & _
               " FROM ViewHt_ChargeReceive1 CRec1 " & _
               " LEFT JOIN ViewHt_Charge C ON CRec1.ChargeCode = C.SubCode " & _
               " LEFT JOIN Ht_ChargeGroup Cg ON C.ChargeGroup = Cg.Code " & _
               " Where CRec1.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " And " & _
               " " & AgL.PubSiteCondition("CRec1.Site_Code", AgL.PubSiteCode) & " "

        DGL1.AgHelpDataSet(Col1ChargeReceive1, 7) = AgL.FillData(mQry, AgL.GCn)

        Call IniChargeReceiveDocIdHelp()
    End Sub

    Private Sub IniChargeReceiveDocIdHelp()

        'mQry = "Select Fr.DocId As Code, " & AgL.V_No_Field("Fr.DocId") & " [Voucher No], " & _
        '        " Fr.ReceiveAmount, Fr.AdvanceCarriedForward, Fr.V_Date, Fr.AdmissionDocId, " & _
        '        " Fr.ReceiveLessRefundAmount, Fr.RefundAmount As TotalRefundAmount " & _
        '        " FROM ViewSch_FeeReceive Fr " & _
        '        " Left Join Voucher_Type Vt On Fr.V_Type = Vt.V_Type " & _
        '        " Where Vt.NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_FeeReceive) & " And " & _
        '        " " & AgL.PubSiteCondition("Fr.Site_Code", AgL.PubSiteCode) & "  " & _
        '        " Order By Fr.DocId "


        'mQry = "Select Cr.DocId As Code, " & AgL.V_No_Field("Cr.DocId") & " [Voucher No], " & _
        '        " Cr.ReceiveAmount, Cr.AdvanceCarriedForward, Cr.V_Date, Cr.AllotmentDocId, " & _
        '        " Cr.ReceiveLessRefundAmount, Fr.RefundAmount As TotalRefundAmount " & _
        '        " FROM Ht_ChargeReceive Cr " & _
        '        " Left Join Voucher_Type Vt On Cr.V_Type = Vt.V_Type " & _
        '        " Where Vt.NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeReceive) & " And " & _
        '        " " & AgL.PubSiteCondition("Cr.Site_Code", AgL.PubSiteCode) & "  " & _
        '        " Order By Cr.DocId "


        mQry = "SELECT CRec.DocId As Code, " & AgL.V_No_Field("CRec.DocId") & " [Voucher No], " & _
                " CRec.ReceiveAmount, CRec.AdvanceCarriedForward, CRec.V_Date, CRec.AllotmentDocId, " & _
                " CRec.ReceiveAmount - IsNull(VRef.RefundAmount,0) AS ReceiveLessRefundAmount, " & _
                " isnull(VRef.RefundAmount,0) AS TotalRefundAmount " & _
                " FROM Ht_ChargeReceive CRec " & _
                " Left Join Voucher_Type Vt On CRec.V_Type = Vt.V_Type " & _
                " Left Join  " & _
                " 	        (SELECT Cref.ChargeReceiveDocId,sum(Cref.RefundAmount) AS RefundAmount " & _
                " 	        FROM Ht_ChargeRefund Cref " & _
                " 	        GROUP BY Cref.ChargeReceiveDocId) VRef " & _
                " ON CRec.DocId = VRef.ChargeReceiveDocId " & _
                " Where Vt.NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeReceive) & " And " & _
                " " & AgL.PubSiteCondition("CRec.Site_Code", AgL.PubSiteCode) & "  " & _
                " Order By CRec.DocId "

        TxtChargeReceiveDocId.AgHelpDataSet(6) = AgL.FillData(mQry, AgL.GCn)

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

                    AgL.Dman_ExecuteNonQry("Delete From ht_ChargeRefundPaymentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAllotmentDocId.Tag, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
                    AgL.PubObjFrmPaymentDetail.DeletePaymentDetail(AgL.GCn, AgL.ECmd)
                    AgL.PubObjFrmPaymentDetail = Nothing

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeRefund1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeRefund Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("CRef.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("CRef.Site_Code", AgL.PubSiteCode) & " "


            AgL.PubFindQry = "SELECT Cref.DocId As SearchCode, " & AgL.V_No_Field("Cref.DocId") & " As [Voucher No], " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], Cref.V_Date, Cref.RefundAmount AS [Refund Amount], " & _
                                " VAl.MemberName as [Member Name], " & AgL.V_No_Field("Cr.DocId") & " As [Receipt VNo], Cref.Remark " & _
                                " FROM Ht_ChargeRefund CRef " & _
                                " Left Join Ht_ChargeReceive Cr On Cref.ChargeReceiveDocId = Cr.DocId " & _
                                " LEFT JOIN Voucher_Type Vt ON Cref.V_Type = Vt.V_Type " & _
                                " LEFT JOIN SiteMast S ON Cref.Site_Code = S.Code " & _
                                " Left Join ViewHt_RoomAllotment VAl On Cr.AllotmentDocId = VAl.DocId " & mCondStr

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

            'AgL.PubReportTitle = "Charge Refund "
            RepName = "Hostel_ChargeRefund" : RepTitle = "Charge Refund Recipt"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " SELECT CR.DocId," & AgL.V_No_Field("CR.DocId") & "  as DocID_Print, " & _
                        " CR.Div_Code,CR.Site_Code,CR.V_Date,CR.V_Type,CR.V_Prefix,CR.V_No,CR.TotalLineAmount," & _
                         " CR.TotalLineNetAmount,CR.Remark,CR.PreparedBy,CR.U_EntDt,CR.U_AE,CR.Edit_Date," & _
                         " CR.ModifiedBy,CR.IsManageCharge,CR.Refundamount as ReceiveAmount,HCR.AllotmentDocId,  " & _
                         " CR1.Code AS Line_Code,CR1.Amount AS Line_Amount,CR1.NetAmount AS Line_NetAmount,   " & _
                         " C.ChargeName AS Charge_Description, Adm.DocId,  Adm.DocID, Adm.MemberName ,Adm.MemberDispName , Adm.FatherName , Adm.Add1, Adm.Add2, Adm.Add3,Adm.CityName , " & _
                         " PD.CashAc, PD.CashAmount, PD.BankAc, PD.BankAmount, PD.Bank_Code, PD.Chq_No, PD.Chq_Date, PD.Clg_Date, PD.CardAc, PD.CardAmount, PD.CardBank_Code, PD.Card_No, PD.AcTransferBankAc, PD.AcTransferAmount, PD.AcTransferBank_Code, PD.TotalAmount, PD.AcTransferAcNo, PD.PartyDrCr, (CASE WHEN PD.CashAmount>0 THEN 'Cash' WHEN PD.BankAmount>0 THEN 'Cheque / DD' WHEN PD.CardAmount>0 THEN 'Credit / Debit Card' WHEN PD.AcTransferAmount>0 THEN 'A/c Transfer' END) AS PaymentMode,  " & _
                         " PD.CashAmount+PD.BankAmount+PD.BankAmount2+PD.BankAmount3+PD.CardAmount+PD.AcTransferAmount AS PaymentAmount,PD.BankAc2, PD.BankAmount2, PD.Bank_Code2, PD.Chq_No2, PD.Chq_Date2, PD.Clg_Date2,PD.BankAc3, PD.BankAmount3, PD.Bank_Code3, PD.Chq_No3, PD.Chq_Date3, PD.Clg_Date3,b1.bank_name as Bank1,b2.bank_name as Bank2,b3.bank_name as Bank3,SGT.Name As TransferAc,BT.Bank_Name AS TransferBankName  " & _
                         " FROM (Select * " & _
                         "      From Ht_ChargeRefund Where DocId = '" & mDocId & "' ) CR " & _
                         " LEFT Join Ht_ChargeRefund1 CR1 ON CR.DocId =CR1.DocId  " & _
                         " LEFT JOIN ViewHt_ChargeDue CSD ON Cr1.code=Csd.Chargedue1code " & _
                         " LEFT JOIN viewHt_Charge C ON CSD.Chargecode =C.SubCode    " & _
                         " LEFT JOIN PaymentDetail PD ON Cr.DocId =PD.DocId  " & _
                         " Left Join Bank b1 on pd.bank_code=b1.bank_code   " & _
                         " Left Join Bank b2 on pd.bank_code2=b2.bank_code   " & _
                         " Left Join Bank b3 on pd.bank_code3=b3.bank_code   " & _
                         " LEFT JOIN Ht_ChargeReceive HCR ON CR.Chargereceivedocid=HCR.docid " & _
                         " LEFT JOIN ViewHt_RoomAllotment  Adm ON HCR.AllotmentDocId = Adm.DocId  " & _
                         " LEFT JOIN SubGroup SGT ON SGT.SubCode=PD.AcTransferBankAc " & _
                         " LEFT JOIN bank BT ON BT.Bank_Code=PD.AcTransferBank_Code "


            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Hostel & "\" & RepName & ".ttx", True)
            mCrd.Load(PLib.PubReportPath_Hostel & "\" & RepName & ".rpt")
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
        Dim bChargeRefund1Code$ = ""

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Ht_ChargeRefund ( " & _
                        " DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No,  " & _
                        " ChargeReceiveDocId, TotalLineAmount, TotalLineNetAmount, IsManageCharge, " & _
                        " RefundAmount, ExcessRefund, Remark,  " & _
                        " PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtChargeReceiveDocId.AgSelectedValue) & ", " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) & ", " & _
                        " " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & ", " & IIf(AgL.StrCmp(TxtIsManageCharge.Text, "Yes"), 1, 0) & ",  " & _
                        " " & Val(TxtRefundAmount.Text) & ", " & Val(DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value) & ", " & AgL.Chk_Text(TxtRemark.Text) & ",  " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else

                mQry = "Update Ht_ChargeRefund " & _
                        " SET " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " ChargeReceiveDocId = " & AgL.Chk_Text(TxtChargeReceiveDocId.AgSelectedValue) & ", " & _
                        " TotalLineAmount = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) & ", " & _
                        " TotalLineNetAmount = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & ", " & _
                        " IsManageCharge = " & IIf(AgL.StrCmp(TxtIsManageCharge.Text, "Yes"), 1, 0) & ", " & _
                        " RefundAmount = " & Val(TxtRefundAmount.Text) & ", " & _
                        " ExcessRefund = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Code, I).Value = "" Then
                        If .Item(Col1ChargeReceive1, I).Value <> "" And Val(.Item(Col1NetAmount, I).Value) > 0 Then
                            bChargeRefund1Code = AgL.GetMaxId("Ht_ChargeRefund1", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)

                            mQry = "INSERT INTO Ht_ChargeRefund1 ( " & _
                                    " Code, DocId, ChargeReceive1, Amount, NetAmount ) " & _
                                    " VALUES ( " & _
                                    " '" & bChargeRefund1Code & "', '" & mSearchCode & "', " & _
                                    " " & AgL.Chk_Text(.AgSelectedValue(Col1ChargeReceive1, I)) & ", " & _
                                    " " & Val(.Item(Col1Amount, I).Value) & ", " & Val(.Item(Col1NetAmount, I).Value) & ") "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If .Item(Col1ChargeReceive1, I).Value <> "" Then
                            mQry = "Update Ht_ChargeRefund1 " & _
                                    " SET " & _
                                    " ChargeReceive1 = " & AgL.Chk_Text(.AgSelectedValue(Col1ChargeReceive1, I)) & ", " & _
                                    " Amount = " & Val(.Item(Col1Amount, I).Value) & ", " & _
                                    " NetAmount = " & Val(.Item(Col1NetAmount, I).Value) & " " & _
                                    " WHERE Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            mQry = "Delete From Ht_ChargeRefund1 Where Code = '" & .Item(Col1Code, I).Value & "'"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    End If
                Next I
            End With

            AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeRefundPaymentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

            AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAllotmentDocId.Tag, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
            AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
            If Not AgL.PubObjFrmPaymentDetail.SavePaymentDetail(PaymentRec, AgL.GCn, AgL.ECmd) Then Err.Raise(1, , "Save Error")
            If Not AgL.PubObjFrmPaymentDetail.AccountPosting(PaymentRec, AgL.GCn, AgL.Gcn_ConnectionString, AgL.ECmd, LedgAry, TxtRemark.Text) Then Err.Raise(1, , "Error in Ledger Posting")



            AgL.PubObjFrmPaymentDetail = Nothing

            mQry = "INSERT INTO Ht_ChargeRefundPaymentDetail ( DocId, LedgerMDocId ) VALUES ( " & _
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
                Call IniChargeReceiveDocIdHelp()
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
        Dim I As Integer
        Dim mTransFlag As Boolean = False
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
                'mQry = "Select FRef.*, Vt.NCat, Adm.Student, Adm.AdmissionId, Fr.AdmissionDocId, " & _
                '        " IsNull(Fr.ReceiveAmount,0) As ReceiveAmount, IsNull(Fr.RefundAmount,0) - IsNull(FRef.RefundAmount,0) As TotalRefundAmount, Fr.V_Date As FeeReceiveVDate " & _
                '        " From Sch_FeeRefund FRef " & _
                '        " Left Join ViewSch_FeeReceive Fr ON FRef.FeeReceiveDocId = Fr.DocId " & _
                '        " Left Join Voucher_Type Vt On FRef.V_Type = Vt.V_Type " & _
                '        " Left Join Sch_Admission Adm On Fr.AdmissionDocId = Adm.DocId " & _
                '        " Where FRef.DocId='" & mSearchCode & "'"


                mQry = "SELECT CRef.*, Vt.NCat, Ra.MemberName, Crec.AllotmentDocId ,Ra.MemberCode , " & _
                        " IsNull(Crec.ReceiveAmount,0) As ReceiveAmount, " & _
                        " IsNull(VRef.RefundAmount,0) - IsNull(CRef.RefundAmount,0) As TotalRefundAmount,  " & _
                        " CRec.V_Date As ChargeReceiveVDate  " & _
                        " FROM Ht_ChargeRefund CRef  " & _
                        " LEFT JOIN Ht_ChargeReceive CRec ON CRef.ChargeReceiveDocId=CRec.DocId " & _
                        " LEFT JOIN Voucher_Type Vt ON CRef.V_Type=Vt.V_Type " & _
                        " LEFT JOIN ViewHt_RoomAllotment Ra ON CRec.AllotmentDocId=Ra.DocId " & _
                        " LEFT JOIN (" & _
                        " 		 SELECT Cref.ChargeReceiveDocId,sum(Cref.RefundAmount) AS RefundAmount   " & _
                        "        FROM Ht_ChargeRefund Cref   " & _
                        "        GROUP BY Cref.ChargeReceiveDocId) VRef   " & _
                        " ON CRec.DocId=VRef.ChargeReceiveDocId  " & _
                        " Where CRef.DocId='" & mSearchCode & "'"

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

                        TxtAllotmentDocId.AgSelectedValue = AgL.XNull(.Rows(0)("AllotmentDocId"))
                        LblAllotmentDocId.Tag = AgL.XNull(.Rows(0)("MemberCode"))

                        TxtChargeReceiveDocId.AgSelectedValue = AgL.XNull(.Rows(0)("ChargeReceiveDocId"))
                        LblChargeReceiveDocId.Tag = AgL.XNull(.Rows(0)("AllotmentDocId"))
                        LblChargeReceiveDocIdReq.Tag = Format(AgL.XNull(.Rows(0)("ChargeReceiveVDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = Format(AgL.VNull(.Rows(0)("TotalLineAmount")), "0.00")
                        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = Format(AgL.VNull(.Rows(0)("TotalLineNetAmount")), "0.00")

                        DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value = Format(AgL.VNull(.Rows(0)("ExcessRefund")), "0.00")

                        TxtIsManageCharge.Text = IIf(AgL.VNull(.Rows(0)("IsManageCharge")), "Yes", "No")
                        TxtReceiveAmount.Text = Format(AgL.VNull(.Rows(0)("ReceiveAmount")), "0.00")
                        TxtTotalRefundAmount.Text = Format(AgL.VNull(.Rows(0)("TotalRefundAmount")), "0.00")

                        TxtRefundAmount.Text = Format(AgL.VNull(.Rows(0)("RefundAmount")), "0.00")
                        LblRefundAmount.Tag = Format(AgL.VNull(.Rows(0)("RefundAmount")), "0.00")

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "SELECT CRef1.*, CRec1.V_Date, CRec1.ChargeDue1 As ChargeDue1Code, " & _
                        " C.ChargeNature, Cg.Description AS ChargeGroup " & _
                        " FROM Ht_ChargeRefund1 CRef1  " & _
                        " LEFT JOIN ViewHt_ChargeReceive1 CRec1 ON CRef1.ChargeReceive1=CRec1.Code  " & _
                        " LEFT JOIN ViewHt_Charge C ON CRec1.ChargeCode=C.SubCode  " & _
                        " LEFT JOIN Ht_ChargeGroup Cg ON C.ChargeGroup=Cg.Code  " & _
                        " Where CRef1.DocId='" & mSearchCode & "' " & _
                        " Order By CRec1.V_Date"




                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.Item(Col1Code, I).Value = AgL.XNull(.Rows(I)("Code"))
                            DGL1.AgSelectedValue(Col1ChargeReceive1, I) = AgL.XNull(.Rows(I)("ChargeReceive1"))
                            DGL1.Item(Col1ChargeDue1, I).Value = AgL.XNull(.Rows(I)("ChargeDue1Code"))
                            DGL1.Item(Col1ChargeGroup, I).Value = AgL.XNull(.Rows(I)("ChargeGroup"))
                            DGL1.Item(Col1ChargeNature, I).Value = AgL.XNull(.Rows(I)("ChargeNature"))
                            'DGL1.Item(Col1RefundableYesNo, I).Value = AgL.VNull(.Rows(I)("Refundable"))

                            DGL1.Item(Col1NetAmount, I).Value = Format(AgL.VNull(.Rows(I)("NetAmount")), "0.00")
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        Next I
                        BtnFillCharge.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                    End If
                End With

                ' ''Payment Detail Moverec Common
                'AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAllotmentDocId.Tag, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
                'AgL.PubObjFrmPaymentDetail.FillPaymentRec()
                'PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec
                'AgL.PubObjFrmPaymentDetail = Nothing


                ''Payment Detail Moverec Common
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAllotmentDocId.Tag, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
                AgL.PubObjFrmPaymentDetail.FillPaymentRec()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec
                AgL.PubObjFrmPaymentDetail = Nothing

            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)


            If mSearchCode.Trim <> "" Then
                mQry = "SELECT isnull(count(Hrt.AllotmentDocId),0) AS Cnt  " & _
                      " FROM Ht_RoomLeft Hrt " & _
                      " WHERE Hrt.AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then mTransFlag = True
            End If

            If mTransFlag Then
                Topctrl1.tEdit = False
                Topctrl1.tDel = False
            Else
                If InStr(Topctrl1.Tag, "E") > 0 Then Topctrl1.tEdit = True
                If InStr(Topctrl1.Tag, "D") > 0 Then Topctrl1.tDel = True
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
        mSearchCode = "" : LblPrefix.Text = ""

        DGL1.RowCount = 1 : DGL1.Rows.Clear()

        Call BlankFooterGrid()
        PaymentRec = Nothing

        TxtIsManageCharge.Text = "No" : BtnFillCharge.Tag = ""
        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub BlankFooterGrid(Optional ByVal bIsCalculationCall As Boolean = False)
        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = "" : DGLFooter1.Item(DFC_Percentage, DF1R_TotalLineNetAmount).Value = ""
        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = "" : DGLFooter1.Item(DFC_Percentage, DF1R_TotalLineAmount).Value = ""
        DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value = ""

        If Not bIsCalculationCall Then
            'DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value = "" 
        End If
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        BtnFillCharge.Enabled = Enb

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
            TxtAllotmentDocId.Enabled = False
            TxtChargeReceiveDocId.Enabled = False

            '=========================================================
            '===========< BtnFillFee Will Remain Disable >============
            '======< As Code Generated in FeeRefund1 Table >=========
            '=========================================================
            BtnFillCharge.Enabled = False
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
                Case Col1ChargeReceive1
                    DGL1.AgRowFilter(Col1ChargeReceive1) = " Code = " & AgL.Chk_Text(TxtChargeReceiveDocId.AgSelectedValue) & ""
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
        Dim DrTemp As DataRow() = Nothing
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex

                Case Col1ChargeReceive1
                    If DGL1.AgHelpDataSet(Col1ChargeReceive1) IsNot Nothing Then
                        'DrTemp = DGL1.AgHelpDataSet(Col1ChargeType).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1ChargeType, mRowIndex)) & "")
                        'DGL1.Item(Col1ChargeTypeMonths, mRowIndex).Value = AgL.XNull(DrTemp(0)("Months"))
                    End If


                    'Case Col1ChargeReceive1
                    '    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                    '        'DGL1.Item(Col1_ManualCode, mRowIndex).Value = ""
                    '    Else
                    '        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                    '            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                    '                'DGL1.Item(Col1_ManualCode, mRowIndex).Value = AgL.XNull(.Item("Name", .CurrentCell.RowIndex).Value)
                    '            End With
                    '        End If
                    '    End If

                Case Col1NetAmount
                    If Val(DGL1.Item(Col1NetAmount, mRowIndex).Value) > Val(DGL1.Item(Col1Amount, mRowIndex).Value) Then
                        DGL1.Item(Col1NetAmount, mRowIndex).Value = Format(Val(DGL1.Item(Col1Amount, mRowIndex).Value), "0.00")
                        MsgBox(DGL1.Item(Col1ChargeReceive1, mRowIndex).Value.ToString + " Can't Be Greater Than From " & Format(Val(DGL1.Item(Col1Amount, mRowIndex).Value)) & "")
                    Else
                        DGL1.Item(mColumnIndex, mRowIndex).Value = Format(Val(DGL1.Item(mColumnIndex, mRowIndex).Value), "0.00")
                    End If

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

        If DGL1.Rows.Count = 1 And Topctrl1.Mode = "Add" Then
            If DGL1.Item(Col1ChargeReceive1, 0).Value Is Nothing Then DGL1.Item(Col1ChargeReceive1, 0).Value = ""
            If DGL1.Item(Col1ChargeReceive1, 0).Value.ToString.Trim = "" Then
                If TxtV_Type.Enabled = False Then TxtV_Type.Enabled = True
            End If
        End If

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
        TxtAllotmentDocId.Enter, TxtChargeReceiveDocId.Enter, TxtIsManageCharge.Enter, _
        TxtRemark.Enter, TxtReceiveAmount.Enter
        Try
            Select Case sender.name
                Case TxtAllotmentDocId.Name
                    TxtAllotmentDocId.AgRowFilter = " LeftDate IS NULL "

                Case TxtChargeReceiveDocId.Name
                    TxtChargeReceiveDocId.AgRowFilter = " AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " And  (ReceiveLessRefundAmount - " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), 0, Val(LblRefundAmount.Tag)) & ") > 0 AND V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & "  "
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtDocId.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtV_Date.Validating, _
          TxtAllotmentDocId.Validating, TxtSite_Code.Validating, TxtRemark.Validating, _
          TxtReceiveAmount.Validating, TxtIsManageCharge.Validating, TxtChargeReceiveDocId.Validating

        Dim DrTemp As DataRow() = Nothing

        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblV_Type.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtV_Type.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & "")
                            LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
                        End If
                    End If


                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate

                    'Case TxtAllotmentDocId.Name
                    '    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                    '        TxtAdmissionID.Text = ""
                    '        LblAllotmentDocId.Tag = ""
                    '    Else
                    '        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                    '            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                    '                TxtAdmissionID.Text = AgL.XNull(.Item("AdmissionID", .CurrentCell.RowIndex).Value)
                    '                LblAllotmentDocId.Tag = AgL.XNull(.Item("StudentCode", .CurrentCell.RowIndex).Value)
                    '            End With
                    '        End If
                    '    End If



                Case TxtAllotmentDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblAllotmentDocId.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtAllotmentDocId.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & "")
                            LblAllotmentDocId.Tag = AgL.XNull(DrTemp(0)("MemberCode"))
                        End If
                    End If



                    'Case TxtChargeReceiveDocId.Name
                    '    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                    '        TxtReceiveAmount.Text = ""
                    '        TxtTotalRefundAmount.Text = ""
                    '        LblChargeReceiveDocId.Tag = ""
                    '        LblChargeReceiveDocIdReq.Tag = ""
                    '    Else
                    '        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                    '            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                    '                TxtReceiveAmount.Text = Format(AgL.VNull(.Item("ReceiveAmount", .CurrentCell.RowIndex).Value), "0.00")
                    '                TxtTotalRefundAmount.Text = Format(AgL.VNull(.Item("TotalRefundAmount", .CurrentCell.RowIndex).Value) - Val(LblRefundAmount.Tag), "0.00")
                    '                LblChargeReceiveDocId.Tag = AgL.XNull(.Item("AdmissionDocId", .CurrentCell.RowIndex).Value)
                    '                LblChargeReceiveDocIdReq.Tag = Format(AgL.XNull(.Item("V_Date", .CurrentCell.RowIndex).Value), AgLibrary.ClsConstant.DateFormat_ShortDate)
                    '            End With
                    '        End If
                    '    End If

                Case TxtChargeReceiveDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtReceiveAmount.Text = ""
                        TxtTotalRefundAmount.Text = ""
                        LblChargeReceiveDocId.Tag = ""
                        LblChargeReceiveDocIdReq.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtChargeReceiveDocId.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtChargeReceiveDocId.AgSelectedValue) & "")
                            TxtReceiveAmount.Text = AgL.XNull(DrTemp(0)("ReceiveAmount"))
                            TxtTotalRefundAmount.Text = AgL.XNull(DrTemp(0)("TotalRefundAmount"))
                            LblChargeReceiveDocId.Tag = AgL.XNull(DrTemp(0)("AllotmentDocId"))
                            LblChargeReceiveDocIdReq.Tag = AgL.XNull(DrTemp(0)("V_Date"))

                        End If
                    End If


                Case TxtIsManageCharge.Name
                    Call ProcManageFee()
            End Select

            Call Calculation()
            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mSearchCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

            If Not AgL.StrCmp(TxtAllotmentDocId.AgSelectedValue, LblChargeReceiveDocId.Tag) Then
                TxtChargeReceiveDocId.AgSelectedValue = ""
                TxtReceiveAmount.Text = ""
                LblChargeReceiveDocId.Tag = ""
                LblChargeReceiveDocIdReq.Tag = ""
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Call BlankFooterGrid(True)

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""
                If .Item(Col1Amount, I).Value Is Nothing Then .Item(Col1Amount, I).Value = ""

                If .Item(Col1ChargeReceive1, I).Value <> "" Then
                    'Footer Detail
                    DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) + Val(.Item(Col1Amount, I).Value), "0.00")
                    DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) + Val(.Item(Col1NetAmount, I).Value), "0.00")
                End If
            Next
        End With

        If Val(TxtRefundAmount.Text) > Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) Then
            DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value = Format(Val(TxtRefundAmount.Text) - Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value), "0.00")
        Else
            DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value = ""
        End If

    End Sub

    Private Sub ProcManageFee()
        Dim I As Integer = 0
        Dim bTotal As Double = 0, bDiffAmount As Double = 0

        If Topctrl1.Mode = "Browse" Then Exit Sub

        bDiffAmount = Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) - Val(TxtRefundAmount.Text)

        If AgL.StrCmp(TxtIsManageCharge.Text, "Yes") Then
            If bDiffAmount <= 0 Then
                TxtIsManageCharge.Text = "No"
            Else
                With DGL1
                    For I = .Rows.Count - 1 To 0 Step -1
                        If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""

                        If .Item(Col1ChargeReceive1, I).Value <> "" And Val(.Item(Col1Amount, I).Value) > 0 Then
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
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtAllotmentDocId, "Student") Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1ChargeReceive1) Then Exit Function
            'If AgCL.AgIsDuplicate(DGL1, "" & Col1ChargeReceive1 & "") Then Exit Function

            If BtnFillCharge.Tag.ToString.Trim <> "" Then
                If CDate(TxtV_Date.Text) < CDate(BtnFillCharge.Tag) Then
                    MsgBox("Voucher Date Can't Be Less Than From " & BtnFillCharge.Tag & "!...")
                    TxtV_Date.Focus()
                    Exit Function
                End If
            End If

            If Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) <= 0 Then
                MsgBox("Net Charge Can't Be <= 0 (Zero)!...")
                DGL1.CurrentCell = DGL1(Col1NetAmount, 0) : DGL1.Focus()
                Exit Function
            End If

            If Val(TxtRefundAmount.Text) + Val(TxtTotalRefundAmount.Text) > Val(TxtReceiveAmount.Text) Then
                MsgBox("Fee Refund Amount Can't Be Greater Than From Rs. """ & Val(TxtReceiveAmount.Text) - Val(TxtTotalRefundAmount.Text) & """")
                TxtRefundAmount.Focus() : Exit Function
            End If

            If AgL.StrCmp(TxtIsManageCharge.Text, "Yes") And Val(DGLFooter1.Item(DFC_Amount, DF1R_ExcessRefund).Value) > 0 Then
                MsgBox("Manage Charge Can't Be ""Yes""!...")
                TxtIsManageCharge.Focus() : Exit Function
            End If

            If Val(TxtRefundAmount.Text) < Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) Then
                MsgBox("Refund Amount Is Not Equal To Rs. """ & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & """")
                TxtRefundAmount.Focus() : Exit Function
            ElseIf Val(TxtRefundAmount.Text) > Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) Then
                If MsgBox("Refund Amount Is Greater Than From Rs. """ & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & """" & vbCrLf & "Do You Want To Refund Excess!...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                    TxtRefundAmount.Focus() : Exit Function
                End If
            End If

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            If AgL.XNull(DtHt_Enviro.Rows(0)("DiscountAc")).ToString.Trim = "" Then MsgBox("Define Discount A/c In Environment Settings!...") : Exit Function
            'If AgL.XNull(DtSch_Enviro.Rows(0)("ChargeAdjustmentAc")).ToString.Trim = "" Then MsgBox("Define Charge Adjustment A/c In Environment Settings!...") : Exit Function

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

    Private Sub BtnFillFee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillCharge.Click
        Try
            Select Case sender.name
                Case BtnFillCharge.Name
                    Call ProcFillCharge()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillCharge()
        Dim DtTemp As DataTable, DtTemp1 As DataTable
        Dim I As Integer
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            TxtIsManageCharge.Text = "No"
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            BtnFillCharge.Tag = ""

            If AgL.RequiredField(TxtV_Date) Then Exit Sub
            If AgL.RequiredField(TxtAllotmentDocId) Then Exit Sub
            If AgL.RequiredField(TxtChargeReceiveDocId) Then Exit Sub

            'mQry = "SELECT FRec1.Code AS FeeReceive1Code, FRec1.DocId FeeReceiveDocId, FRec1.FeeDue1 As FeeDue1Code, " & _
            '        " FRec1.FeeReceiveLessRefundAmount + IsNull(VFRef1.Amount,0) AS Amount, FRec1.V_Date, " & _
            '        " F.FeeNature, Fg.Description AS FeeGroup, F.Refundable " & _
            '        " FROM ViewSch_FeeReceive1 FRec1 " & _
            '        " LEFT JOIN (SELECT FRef1.* FROM Sch_FeeRefund1 FRef1 WHERE " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=2 ", " FRef1.DocId = '" & mSearchCode & "' ") & " )  VFref1 ON FRec1.Code = VFRef1.FeeReceive1 " & _
            '        " Left Join ViewSch_Fee F On FRec1.FeeCode = F.Code " & _
            '        " LEFT JOIN Sch_FeeGroup Fg ON F.FeeGroup = Fg.Code " & _
            '        " WHERE Frec1.DocId = " & AgL.Chk_Text(TxtChargeReceiveDocId.AgSelectedValue) & " And " & _
            '        " FRec1.FeeReceiveLessRefundAmount + IsNull(VFRef1.Amount,0) > 0 " & _
            '        " Order By FRec1.V_Date "


            mQry = "SELECT CRec1.Code AS ChargeReceive1Code, CRec1.DocId ChargeReceiveDocId, " & _
                    " CRec1.ChargeDue1 As ChargeDue1Code, " & _
                    " CRec1.ChargeReceiveLessRefundAmount + IsNull(VCRef1.Amount,0) AS Amount, CRec1.V_Date, " & _
                    " C.ChargeNature, Cg.Description AS ChargeGroup " & _
                    " FROM ViewHt_ChargeReceive1 CRec1 " & _
                    " LEFT JOIN (SELECT CRef1.* FROM Ht_ChargeRefund1 CRef1 " & _
                    "           WHERE " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=2 ", " CRef1.DocId = '" & mSearchCode & "' ") & " )  VCref1 " & _
                    " ON CRec1.Code = VCRef1.ChargeReceive1 " & _
                    " Left Join ViewHt_Charge C On CRec1.ChargeCode = C.SubCode " & _
                    " LEFT JOIN Ht_ChargeGroup Cg ON C.ChargeGroup = Cg.Code " & _
                    " WHERE Crec1.DocId = " & AgL.Chk_Text(TxtChargeReceiveDocId.AgSelectedValue) & " And " & _
                    " CRec1.ChargeReceiveLessRefundAmount + IsNull(VCRef1.Amount,0) > 0 " & _
                    " Order By CRec1.V_Date "



            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp

                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    TxtAllotmentDocId.Enabled = False

                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1ChargeReceive1, I) = AgL.XNull(.Rows(I)("ChargeReceive1Code"))
                        DGL1.Item(Col1ChargeDue1, I).Value = AgL.XNull(.Rows(I)("ChargeDue1Code"))
                        DGL1.Item(Col1ChargeGroup, I).Value = AgL.XNull(.Rows(I)("ChargeGroup"))
                        DGL1.Item(Col1ChargeNature, I).Value = AgL.XNull(.Rows(I)("ChargeNature"))
                        'DGL1.Item(Col1RefundableYesNo, I).Value = AgL.VNull(.Rows(I)("Refundable"))

                        DGL1.Item(Col1NetAmount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                    Next I

                    BtnFillCharge.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                Else
                    TxtAllotmentDocId.Enabled = True

                    MsgBox("No Fee Exists To Receive!...")
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

End Class