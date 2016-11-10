Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmRoomChargeReceive

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = "", mRegistrationDocId$ = ""
    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode
    Dim mRefundAmount As Double = 0, mAdvanceBroughtForward As Double = 0

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1MonthYear As Byte = 1
    Private Const Col1ChargeDue1 As Byte = 2
    Private Const Col1Amount As Byte = 3
    Private Const Col1Discount As Byte = 4
    Private Const Col1NetAmount As Byte = 5
    Private Const Col1TempAmount As Byte = 6
    Private Const Col1Code As Byte = 7

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2AdvanceDocId As Byte = 1
    Private Const Col2AdvanceVDate As Byte = 2
    Private Const Col2AdvanceReceive As Byte = 3
    Private Const Col2AdjustYesNo As Byte = 4

    Public WithEvents DGLFooter1 As New AgControls.AgDataGrid
    '=============== <Column Index> ========================
    Private Const DFC_Description As Byte = 0
    Private Const DFC_Percentage As Byte = 1
    Private Const DFC_Amount As Byte = 2

    '=============== <Row Index> ===========================
    Private Const DF1R_TotalLineAmount As Byte = 0
    Private Const DF1R_TotalLineDiscount As Byte = 1
    Private Const DF1R_TotalLineNetAmount As Byte = 2


    Public WithEvents DGLFooter2 As New AgControls.AgDataGrid

    '=============== <Row Index> ===========================
    Private Const DF2R_TotalAdvanceAdjusted As Byte = 0
    Private Const DF2R_Advance As Byte = 1
    Private Const DF2R_SubTotal1 As Byte = 2
    Private Const DF2R_Discount As Byte = 3
    Private Const DF2R_TotalNetAmount As Byte = 4
    Private Const DF2R_AdvanceCarriedForward As Byte = 5

    Dim PaymentRec As AgLibrary.ClsMain.PaymentDetail = Nothing

    Dim mAllotmentDocId$ = ""

    Public Property AllotmentDocId() As String
        Get
            AllotmentDocId = mAllotmentDocId
        End Get
        Set(ByVal value As String)
            mAllotmentDocId = value
        End Set
    End Property

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
            .AddAgTextColumn(DGL1, "DGL1MonthYear", 90, 8, "Month/Year", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1ChargeDue1", 200, 8, "Charge Head", True, True, False)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 100, 8, 2, False, "Charge Amount", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Discount", 70, 8, 2, False, "Discount", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1NetAmount", 100, 8, 2, False, "Net Amount", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1TempAmount", 100, 8, 2, False, "Charge Amount (Temp)", False, True, True)
            .AddAgTextColumn(DGL1, "DGL1Code", 30, 10, "Code", False, True, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False

        ''==============================================================================
        ''================< Advance Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "Dgl2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "Dgl2AdvanceDocId", 150, 8, "Voucher No", True, True, False)
            .AddAgDateColumn(DGL2, "Dgl2AdvanceVDate", 80, "Voucher Date", True, True, False)
            .AddAgNumberColumn(DGL2, "Dgl2AdvanceReceive", 100, 8, 2, False, "Advance", True, True, True)
            .AddAgCheckBoxColumn(DGL2, "Dgl2AdjustYesNo", 60, "Adjust (Yes/No)", True, False, False)
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
        DGLFooter1.RowCount = 4
        DGLFooter1.AllowUserToAddRows = False
        DGLFooter1.Item(DFC_Description, DF1R_TotalLineAmount).Value = "Charge Amount".ToUpper
        DGLFooter1.Item(DFC_Description, DF1R_TotalLineDiscount).Value = "(-) Charge Discount".ToUpper
        DGLFooter1.Item(DFC_Description, DF1R_TotalLineNetAmount).Value = "Net Charge".ToUpper

        ''==============================================================================
        ''================< Footer Data Grid-2 >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGLFooter2, "DGLF2Description", 140, 5, "Description", True, True, False)
            .AddAgNumberColumn(DGLFooter2, "DGLF2Percentage", 40, 2, 2, False, " % ", True, True, True)
            .AddAgNumberColumn(DGLFooter2, "DGLF2Amount", 100, 8, 2, False, "Amount", True, True, True)
        End With
        AgL.AddAgDataGrid(DGLFooter2, PnlFooter2)
        DGLFooter2.RowCount = 7
        DGLFooter2.AllowUserToAddRows = False
        DGLFooter2.Item(DFC_Description, DF2R_TotalAdvanceAdjusted).Value = "(-) Advance Adjusted ".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_Advance).Value = "(-) Advance B/F ".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_SubTotal1).Value = "Sub Total-1".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_Discount).Value = "(-) Discount".ToUpper
        'Code By Akaash On Date 15-11-10
        DGLFooter2.Item(DFC_Amount, DF2R_Discount).Style.BackColor = Color.White
        DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Style.BackColor = Color.White
        'End Code
        DGLFooter2.Item(DFC_Description, DF2R_TotalNetAmount).Value = "Net Amount".ToUpper
        DGLFooter2.Item(DFC_Description, DF2R_AdvanceCarriedForward).Value = "Advance C/F".ToUpper
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
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAllotmentDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
                AgL.PubObjFrmPaymentDetail.ShowDialog()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec

                TxtReceiveAmount.Text = Format(Val(PaymentRec.TotalAmount), "0.00")

                If Val(TxtReceiveAmount.Text) <> Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) Then
                    MsgBox("Receive Amount Is Not Equal To Rs. """ & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) & """")
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
            AgL.WinSetting(Me, 650, 950, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGLFooter1)
            AgL.GridDesign(DGLFooter2)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            Topctrl1.ChangeAgGridState(DGLFooter1, False)
            Topctrl1.ChangeAgGridState(DGLFooter2, False)
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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Cr.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("Cr.Site_Code", AgL.PubSiteCode) & " "

            mQry = "Select Cr.DocId As SearchCode " & _
                    " From Ht_ChargeReceive Cr " & _
                    " LEFT JOIN Voucher_Type Vt ON Cr.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
              " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RoomChargeReceive) & "" & _
              " Order By Description"
        TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT VRA.DocId AS Code,Vra.MemberName, Vra.FatherName,Vra.MemberDispName, Vra.MemberCode, Vra.LeftDate " & _
                " FROM ViewHt_RoomAllotment VRA " & _
                " Where " & AgL.PubSiteCondition("VRA.Site_Code", AgL.PubSiteCode) & " " & _
                " Order By VRA.MemberDispName "

        TxtAllotmentDocId.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Cd1.Code,Sgf.Name AS [Charge Name],Cd.V_Date AS [Due DATE],Cd1.Amount, " & _
               " Cd1.AllotmentDocId,Cd1.Charge AS ChargeCode " & _
               " FROM Ht_ChargeDue1 Cd1 " & _
               " LEFT JOIN Ht_ChargeDue Cd ON Cd1.DocId=Cd.DocId " & _
               " LEFT JOIN SubGroup Sgf ON Cd1.Charge=Sgf.SubCode " & _
               " Where Cd.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " And " & _
               " " & AgL.PubSiteCondition("Cd.Site_Code", AgL.PubSiteCode) & " "

        DGL1.AgHelpDataSet(Col1ChargeDue1, 3) = AgL.FillData(mQry, AgL.GCn)


        mQry = "SELECT ARec.DocId Code, " & AgL.V_No_Field("ARec.DocId") & " As [Voucher No], " & _
              " ARec.V_Date , ARec.ReceiveAmount " & _
              " FROM Ht_Advance ARec " & _
              " Where ARec.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " And " & _
              " " & AgL.PubSiteCondition("ARec.Site_Code", AgL.PubSiteCode) & " "

        DGL2.AgHelpDataSet(Col2AdvanceDocId, 2) = AgL.FillData(mQry, AgL.GCn)
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

                    AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeReceivePaymentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAllotmentDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                    AgL.PubObjFrmPaymentDetail.DeletePaymentDetail(AgL.GCn, AgL.ECmd)
                    AgL.PubObjFrmPaymentDetail = Nothing

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeReceiveAdvance Where ChargeReceiveDocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeReceive1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeReceive Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Fr.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("Fr.Site_Code", AgL.PubSiteCode) & " "


            AgL.PubFindQry = "SELECT Cr.DocId As SearchCode, " & AgL.V_No_Field("Cr.DocId") & " As [Voucher No], " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], Cr.V_Date, Cr.ReceiveAmount AS [Receive Amount], " & _
                                " VAL.MemberDispName as [Member Name], Cr.Remark " & _
                                " FROM Ht_ChargeReceive Cr " & _
                                " LEFT JOIN Voucher_Type Vt ON Cr.V_Type = Vt.V_Type " & _
                                " LEFT JOIN SiteMast S ON Cr.Site_Code = S.Code " & _
                                " Left Join ViewHt_RoomAllotment VAL On Cr.AllotmentDocId=VAL.DocId  "

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

            AgL.PubReportTitle = "Charge Receipt"
            RepName = "Hostel_ChargeReceipt" : RepTitle = "Charge Receipt"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = " SELECT CR.DocId," & AgL.V_No_Field("CR.DocID") & " as DocID_Print, CR.Div_Code,CR.Site_Code,CR.V_Date,CR.V_Type,CR.V_Prefix,CR.V_No,CR.AllotmentDocId,CR.TotalLineAmount,CR.TotalLineDiscount,CR.TotalLineNetAmount,CR.AdvanceBroughtForward,CR.TotalAdvanceAdjusted, " & _
                       " CR.SubTotal1,CR.DiscountPer,CR.DiscountAmount,CR.TotalNetAmount,CR.IsManageCharge,CR.ReceiveAmount,CR.AdvanceCarriedForward,CR.Remark,CR.PreparedBy,CR.U_EntDt,CR.U_AE,CR.Edit_Date,CR.ModifiedBy, " & _
                       " CR1.Code AS Line_Code,CR1.ChargeDue1 AS Line_ChargeDue,CR1.Amount AS Line_Amount,CR1.Discount AS Line_Discount,CR1.NetAmount AS Line_NetAmount, CD1.DocId AS DocID_ChargeDue, CD.V_Date as ChargeDue_V_Date, CD1.Charge, C.ChargeName AS Charge_Description, CD1.Amount AS AmountDue, " & _
                       " Adm.DocId AS Allotment_DocId,Adm.MemberCode,Adm.MemberName,Adm.MemberDispName,Adm.MemberType,Adm.FatherName,Adm.Phone,Adm.Mobile,Adm.FAX,Adm.EMail,Adm.Add1,Adm.Add2,Adm.Add3,Adm.PIN,Adm.CityName,Adm.State_Desc, " & _
                       " PD.CashAc, PD.CashAmount, PD.BankAc, PD.BankAmount, PD.Bank_Code, PD.Chq_No, PD.Chq_Date, PD.Clg_Date, PD.CardAc, PD.CardAmount, PD.CardBank_Code, PD.Card_No, PD.AcTransferBankAc, PD.AcTransferAmount, PD.AcTransferBank_Code, PD.TotalAmount, PD.AcTransferAcNo, PD.PartyDrCr, (CASE WHEN PD.CashAmount>0 THEN 'Cash' WHEN PD.BankAmount>0 THEN 'Cheque / DD' WHEN PD.CardAmount>0 THEN 'Credit / Debit Card' WHEN PD.AcTransferAmount>0 THEN 'A/c Transfer' END) AS PaymentMode,  " & _
                       " PD.CashAmount+PD.BankAmount+PD.BankAmount2+PD.BankAmount3+PD.CardAmount+PD.AcTransferAmount AS PaymentAmount,PD.BankAc2, PD.BankAmount2, PD.Bank_Code2, PD.Chq_No2, PD.Chq_Date2, PD.Clg_Date2,PD.BankAc3, PD.BankAmount3, PD.Bank_Code3, PD.Chq_No3, PD.Chq_Date3, PD.Clg_Date3,b1.bank_name as Bank1,b2.bank_name as Bank2,b3.bank_name as Bank3, Cd.MonthStartDate,SGT.Name As TransferAc,BT.Bank_Name AS TransferBankName  " & _
                       " FROM ( Select * From Ht_ChargeReceive  Where DocId = '" & mDocId & "' ) CR  " & _
                       " LEFT Join Ht_ChargeReceive1 CR1 ON CR.DocId =CR1.DocId   " & _
                       " LEFT JOIN Ht_ChargeDue1 CD1 ON CR1.ChargeDue1 =CD1.Code   " & _
                       " LEFT JOIN Ht_ChargeDue CD ON CD1.DocId  =CD.DocId   " & _
                       " LEFT JOIN ViewHt_Charge  C ON CD1.Charge =C.SubCode   " & _
                       " LEFT JOIN PaymentDetail PD ON CR.DocId =PD.DocId   " & _
                       " LEFT JOIN ViewHt_RoomAllotment   Adm ON CR.AllotmentDocId = Adm.DocId   " & _
                       " Left Join Bank b1 on pd.bank_code=b1.bank_code   " & _
                       " Left Join Bank b2 on pd.bank_code2=b2.bank_code   " & _
                       " Left Join Bank b3 on pd.bank_code3=b3.bank_code   " & _
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
        Dim I As Integer, bSr As Integer = 0
        Dim mTrans As Boolean = False
        Dim bChargeReceive1Code$ = ""

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then

                mQry = "INSERT INTO dbo.Ht_ChargeReceive(DocId, Div_Code, Site_Code, V_Date, V_Type, " & _
                        " V_Prefix, V_No, AllotmentDocId, TotalLineAmount, TotalLineDiscount, TotalLineNetAmount, " & _
                        " AdvanceBroughtForward, TotalAdvanceAdjusted, SubTotal1, DiscountPer, DiscountAmount, " & _
                        " TotalNetAmount, IsManageCharge, ReceiveAmount, AdvanceCarriedForward, Remark, " & _
                        " PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ('" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ",  " & _
                        " " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & ", " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) & "," & _
                        " " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value) & ", " & _
                        " " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) & "," & _
                        " " & IIf(AgL.StrCmp(TxtIsManageCharge.Text, "Yes"), 1, 0) & ", " & _
                        " " & Val(TxtReceiveAmount.Text) & ", " & _
                        " " & Val(DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value) & ", " & _
                        " " & AgL.Chk_Text(TxtRemark.Text) & " , " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            Else

                mQry = "UPDATE dbo.Ht_ChargeReceive  " & _
                        " SET " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ",  " & _
                        " AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " ,  " & _
                        " TotalLineAmount = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) & ", " & _
                        " TotalLineDiscount = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value) & ", " & _
                        " TotalLineNetAmount = " & Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) & ", " & _
                        " AdvanceBroughtForward = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value) & ", " & _
                        " TotalAdvanceAdjusted = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value) & ", " & _
                        " SubTotal1 = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value) & ", " & _
                        " DiscountPer = " & Val(DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value) & ", " & _
                        " DiscountAmount = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value) & ", " & _
                        " TotalNetAmount = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) & ", " & _
                        " IsManageCharge = " & IIf(AgL.StrCmp(TxtIsManageCharge.Text, "Yes"), 1, 0) & ", " & _
                        " ReceiveAmount = " & Val(TxtReceiveAmount.Text) & ", " & _
                        " AdvanceCarriedForward = " & Val(DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value) & ", " & _
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
                        If .Item(Col1ChargeDue1, I).Value <> "" And Val(.Item(Col1Amount, I).Value) > 0 Then
                            bChargeReceive1Code = AgL.GetMaxId("Ht_ChargeReceive1", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)

                            mQry = "INSERT INTO dbo.Ht_ChargeReceive1(Code, DocId, ChargeDue1, Amount, Discount, NetAmount) " & _
                                    " VALUES ('" & bChargeReceive1Code & "', '" & mSearchCode & "', " & AgL.Chk_Text(.AgSelectedValue(Col1ChargeDue1, I)) & "," & _
                                    " " & Val(.Item(Col1Amount, I).Value) & " , " & Val(.Item(Col1Discount, I).Value) & ", " & Val(.Item(Col1NetAmount, I).Value) & " ) "

                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Else
                        If .Item(Col1ChargeDue1, I).Value <> "" Then
                            mQry = "UPDATE Ht_ChargeReceive1 SET " & _
                                    " ChargeDue1 = " & AgL.Chk_Text(.AgSelectedValue(Col1ChargeDue1, I)) & ", " & _
                                    " Amount = " & Val(.Item(Col1Amount, I).Value) & ", " & _
                                    " Discount = " & Val(.Item(Col1Discount, I).Value) & ", " & _
                                    " NetAmount = " & Val(.Item(Col1NetAmount, I).Value) & " " & _
                                    " WHERE Code = " & AgL.Chk_Text(.Item(Col1Code, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            mQry = "Delete From Ht_ChargeReceive1 Where Code = '" & .Item(Col1Code, I).Value & "'"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    End If
                Next I
            End With

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Ht_ChargeReceiveAdvance Where ChargeReceiveDocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL2
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2AdvanceDocId, I).Value <> "" And CBool(.Item(Col2AdjustYesNo, I).Value) Then
                        bSr += 1

                        mQry = "INSERT INTO Ht_ChargeReceiveAdvance ( " & _
                                " ChargeReceiveDocId, Sr, ChargeAdvanceDocId ) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & bSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col2AdvanceDocId, I)) & " ) "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End With


            AgL.Dman_ExecuteNonQry("Delete From Ht_ChargeReceivePaymentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

            AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAllotmentDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
            AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
            If Not AgL.PubObjFrmPaymentDetail.SavePaymentDetail(PaymentRec, AgL.GCn, AgL.ECmd) Then Err.Raise(1, , "Save Error")

            Call AccountPosting()

            AgL.PubObjFrmPaymentDetail = Nothing

            mQry = "INSERT INTO Ht_ChargeReceivePaymentDetail ( DocId, LedgerMDocId ) VALUES ( " & _
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
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                mAllotmentDocId = ""

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

                mQry = "SELECT CR.*,Vt.NCat ,VRA.MemberCode " & _
                        " FROM Ht_ChargeReceive CR " & _
                        " Left Join Voucher_Type Vt On CR.V_Type = Vt.V_Type " & _
                        " LEFT JOIN ViewHt_RoomAllotment VRA ON CR.AllotmentDocId=VRA.DocId " & _
                        " Where Cr.DocId='" & mSearchCode & "'"

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
                        'TxtAdmissionID.Text = AgL.XNull(.Rows(0)("AdmissionID"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        'mRegistrationDocId = AgL.XNull(.Rows(0)("RegistrationDocId"))
                        'mRefundAmount = AgL.VNull(.Rows(0)("RefundAmount"))

                        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = Format(AgL.VNull(.Rows(0)("TotalLineAmount")), "0.00")
                        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value = Format(AgL.VNull(.Rows(0)("TotalLineDiscount")), "0.00")
                        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = Format(AgL.VNull(.Rows(0)("TotalLineNetAmount")), "0.00")

                        DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value = Format(AgL.VNull(.Rows(0)("TotalAdvanceAdjusted")), "0.00")
                        DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value = Format(AgL.VNull(.Rows(0)("AdvanceBroughtForward")), "0.00")
                        mAdvanceBroughtForward = AgL.VNull(.Rows(0)("AdvanceBroughtForward"))
                        DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value = Format(AgL.VNull(.Rows(0)("SubTotal1")), "0.00")
                        'DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value = Format(AgL.VNull(.Rows(0)("AdjustmentAmount")), "0.00")
                        'DGLFooter2.Item(DFC_Amount, DF2R_SubTotal2).Value = Format(AgL.VNull(.Rows(0)("SubTotal2")), "0.00")
                        DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value = Format(AgL.VNull(.Rows(0)("DiscountPer")), "0.00")
                        DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value = Format(AgL.VNull(.Rows(0)("DiscountAmount")), "0.00")
                        DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value = Format(AgL.VNull(.Rows(0)("TotalNetAmount")), "0.00")
                        DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value = Format(AgL.VNull(.Rows(0)("AdvanceCarriedForward")), "0.00")

                        TxtIsManageCharge.Text = IIf(AgL.VNull(.Rows(0)("IsManageCharge")), "Yes", "No")
                        TxtReceiveAmount.Text = Format(AgL.VNull(.Rows(0)("ReceiveAmount")), "0.00")

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With


                mQry = " SELECT CR1.*,CD.V_Date, Cd.MonthStartDate " & _
                        " FROM Ht_ChargeReceive1 CR1 " & _
                        " LEFT JOIN Ht_ChargeDue1 CD1 ON CR1.ChargeDue1=CD1.Code " & _
                        " LEFT JOIN Ht_ChargeDue CD ON CD.DocId=CD1.DocId " & _
                        " Where Cr1.DocId='" & mSearchCode & "'"


                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.Item(Col1Code, I).Value = AgL.XNull(.Rows(I)("Code"))
                            'Code by akash on date 16-11-10
                            DGL1.Item(Col1MonthYear, I).Value = CDate(AgL.XNull(.Rows(I)("MonthStartDate"))).ToString("MMM/yyyy")
                            'End Code
                            DGL1.AgSelectedValue(Col1ChargeDue1, I) = AgL.XNull(.Rows(I)("ChargeDue1"))
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.Item(Col1TempAmount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.Item(Col1Discount, I).Value = Format(AgL.VNull(.Rows(I)("Discount")), "0.00")
                            DGL1.Item(Col1NetAmount, I).Value = Format(AgL.VNull(.Rows(I)("NetAmount")), "0.00")
                        Next I
                        BtnFillCharge.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                    End If
                End With

                'mQry = "Select Fra.*, ARec.V_Date, ARec.ReceiveAmount, ARec.IsAdjusted  " & _
                '        " From Sch_ChargeReceiveAdvance Fra " & _
                '        " Left Join ViewSch_AdvanceReceive ARec On FRa.AdvanceDocId = ARec.DocId " & _
                '        " Where Fra.ChargeReceiveDocId = '" & mSearchCode & "' " & _
                '        " Order By ARec.V_Date "


                'mQry = "SELECT A.DocId AS Code,A.V_Date,A.ReceiveAmount, " & _
                '        " Convert(BIT,CASE WHEN Cra.ChargeAdvanceDocId IS NULL THEN 0 ELSE 1 END) AS IsAdjusted " & _
                '        " FROM Ht_Advance A " & _
                '        " LEFT JOIN Ht_ChargeReceiveAdvance CRA ON A.DocId=CRA.ChargeAdvanceDocId " & _
                '        " Where Cra.ChargeReceiveDocId = '" & mSearchCode & "' " & _
                '        " Order By A.V_Date "

                mQry = "SELECT CRA.ChargeAdvanceDocId,A.V_Date,A.ReceiveAmount,  " & _
                        " Convert(BIT,CASE WHEN Cra.ChargeAdvanceDocId IS NULL THEN 0 ELSE 1 END) AS IsAdjusted  " & _
                        " FROM Ht_ChargeReceiveAdvance CRA  " & _
                        " LEFT JOIN Ht_Advance A ON CRA.ChargeAdvanceDocId=A.DocId  " & _
                        " WHERE CRA.ChargeReceiveDocId = '" & mSearchCode & "' " & _
                        " Order By A.V_Date "


                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL2.RowCount = 1 : DGL2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count
                            DGL2.AgSelectedValue(Col2AdvanceDocId, I) = AgL.XNull(.Rows(I)("ChargeAdvanceDocId"))
                            DGL2.Item(Col2AdvanceVDate, I).Value = Format(AgL.XNull(.Rows(I)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL2.Item(Col2AdvanceReceive, I).Value = Format(AgL.VNull(.Rows(I)("ReceiveAmount")), "0.00")
                            DGL2.Item(Col2AdjustYesNo, I).Value = AgL.VNull(.Rows(I)("IsAdjusted"))
                        Next I
                        BtnFillAdvanceVoucher.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                    End If
                End With

                ''Payment Detail Moverec Common
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, LblAllotmentDocId.Tag, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                AgL.PubObjFrmPaymentDetail.FillPaymentRec()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec
                AgL.PubObjFrmPaymentDetail = Nothing
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                mQry = "SELECT isnull(count(CRef.DocId),0) AS Cnt " & _
                        " FROM Ht_ChargeRefund CRef " & _
                        " WHERE CRef.ChargeReceiveDocId='" & mSearchCode & "' "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                    mTransFlag = True
                Else
                    mQry = "SELECT isnull(count(Hrt.AllotmentDocId),0) AS Cnt  " & _
                          " FROM Ht_RoomLeft Hrt " & _
                          " WHERE Hrt.AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " "
                    If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then mTransFlag = True
                End If
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
        mSearchCode = "" : LblPrefix.Text = "" : mRegistrationDocId = ""
        mRefundAmount = 0 : mAdvanceBroughtForward = 0

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()

        Call BlankFooterGrid()
        PaymentRec = Nothing


        TxtIsManageCharge.Text = "No" : BtnFillCharge.Tag = "" : BtnFillAdvanceVoucher.Tag = ""
        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub BlankFooterGrid(Optional ByVal bIsCalculationCall As Boolean = False)
        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = "" : DGLFooter1.Item(DFC_Percentage, DF1R_TotalLineAmount).Value = ""
        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value = "" : DGLFooter1.Item(DFC_Percentage, DF1R_TotalLineDiscount).Value = ""
        DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = "" : DGLFooter1.Item(DFC_Percentage, DF1R_TotalLineNetAmount).Value = ""

        'DGLFooter2.Item(DFC_Percentage, DF2R_AdjustmentAmount).Value = ""

        DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_TotalAdvanceAdjusted).Value = ""
        DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_SubTotal1).Value = ""
        'DGLFooter2.Item(DFC_Amount, DF2R_SubTotal2).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_SubTotal2).Value = ""
        DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_TotalNetAmount).Value = ""
        DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_AdvanceCarriedForward).Value = ""

        If Not bIsCalculationCall Then
            DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_Advance).Value = ""
            'DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_AdjustmentAmount).Value = ""
            DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value = "" : DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value = ""
        End If
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        BtnFillCharge.Enabled = Enb

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
            TxtAllotmentDocId.Enabled = False
            '=========================================================
            '===========< BtnFillCharge Will Remain Disable >============
            '======< As Code Generated in ChargeReceive1 Table >=========
            '=========================================================
            BtnFillCharge.Enabled = False
            '=========================================================
        End If

        If Enb Then
            DGLFooter2.CurrentCell = DGLFooter2(DFC_Percentage, DF2R_Discount) : DGLFooter2.CurrentCell.ReadOnly = False
            DGLFooter2.CurrentCell = DGLFooter2(DFC_Amount, DF2R_Discount) : DGLFooter2.CurrentCell.ReadOnly = False
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
                Case Col1ChargeDue1
                    DGL1.AgRowFilter(Col1ChargeDue1) = " AllotmentDocId = '" & TxtAllotmentDocId.AgSelectedValue & "'"
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

    Private Sub DGL2_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL2.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            Select Case DGL2.CurrentCell.ColumnIndex
                Case Col2AdjustYesNo
                    Call Calculation()
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
                Case Col1ChargeDue1
                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        'DGL1.Item(Col1ChargeDue1Code, mRowIndex).Value = ""
                    Else

                        If DGL1.AgHelpDataSet(Col1ChargeDue1) IsNot Nothing Then
                            '<Executable Code>
                        End If
                    End If


                Case Col1Amount
                    If Val(DGL1.Item(Col1Amount, mRowIndex).Value) > Val(DGL1.Item(Col1TempAmount, mRowIndex).Value) Then
                        DGL1.Item(Col1Amount, mRowIndex).Value = Format(Val(DGL1.Item(Col1TempAmount, mRowIndex).Value), "0.00")
                        MsgBox(DGL1.Item(Col1ChargeDue1, mRowIndex).Value.ToString + " Can't Be Greater Than From " & Format(Val(DGL1.Item(Col1TempAmount, mRowIndex).Value)) & "")
                    Else
                        DGL1.Item(mColumnIndex, mRowIndex).Value = Format(Val(DGL1.Item(mColumnIndex, mRowIndex).Value), "0.00")
                    End If

                Case Col1Discount
                    If Val(DGL1.Item(Col1Discount, mRowIndex).Value) > Val(DGL1.Item(Col1Amount, mRowIndex).Value) Then
                        DGL1.Item(Col1Discount, mRowIndex).Value = ""
                        MsgBox("Discount On " & DGL1.Item(Col1ChargeDue1, mRowIndex).Value.ToString & " Is Not Valid!...")
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
            If DGL1.Item(Col1ChargeDue1, 0).Value Is Nothing Then DGL1.Item(Col1ChargeDue1, 0).Value = ""
            If DGL1.Item(Col1ChargeDue1, 0).Value.ToString.Trim = "" Then
                If TxtV_Type.Enabled = False Then TxtV_Type.Enabled = True
            End If
        End If

        Call Calculation()
    End Sub

    Private Sub DGLFooter2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGLFooter2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGLFooter2.CurrentCell.RowIndex
            mColumnIndex = DGLFooter2.CurrentCell.ColumnIndex

            If DGLFooter2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGLFooter2.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGLFooter2.CurrentCell.ColumnIndex
                Case DFC_Percentage, DFC_Amount
                    DGLFooter2.Item(mColumnIndex, mRowIndex).Value = Format(Val(DGLFooter2.Item(mColumnIndex, mRowIndex).Value), "0.00")
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
        TxtV_Type.Enter, TxtAllotmentDocId.Enter, TxtDocId.Enter, TxtIsManageCharge.Enter, TxtReceiveAmount.Enter, TxtRemark.Enter, _
        TxtSite_Code.Enter, TxtV_Date.Enter, TxtV_No.Enter, TxtV_Type.Enter
        Try
            Select Case sender.name
                Case TxtAllotmentDocId.Name
                    TxtAllotmentDocId.AgRowFilter = " LeftDate IS NULL "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtDocId.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtV_Date.Validating, _
          TxtAllotmentDocId.Validating, TxtSite_Code.Validating, TxtRemark.Validating, _
          TxtReceiveAmount.Validating, TxtIsManageCharge.Validating

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

                Case TxtAllotmentDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblAllotmentDocId.Tag = ""
                    Else
                        'If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                        '    With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                        '        LblAllotmentDocId.Tag = AgL.XNull(.Item("MemberCode", .CurrentCell.RowIndex).Value)
                        '    End With
                        'End If

                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtAllotmentDocId.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & "")
                            LblAllotmentDocId.Tag = AgL.XNull(DrTemp(0)("MemberCode"))
                        End If

                    End If

                Case TxtIsManageCharge.Name
                    Call ProcManageCharge()
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

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""

                If .Item(Col1ChargeDue1, I).Value <> "" Then
                    .Item(Col1NetAmount, I).Value = Format(Val(.Item(Col1Amount, I).Value) - Val(.Item(Col1Discount, I).Value), "0.00")
                    'Footer Detail
                    DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineAmount).Value) + Val(.Item(Col1Amount, I).Value), "0.00")
                    DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value) + Val(.Item(Col1Discount, I).Value), "0.00")
                    DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) + Val(.Item(Col1NetAmount, I).Value), "0.00")
                End If
            Next
        End With

        With DGL2
            For I = 0 To .Rows.Count - 1
                If .Item(Col2AdvanceReceive, I).Value Is Nothing Then .Item(Col2AdvanceReceive, I).Value = ""
                If .Item(Col2AdjustYesNo, I).Value Is Nothing Then .Item(Col2AdjustYesNo, I).Value = ""

                Try
                    If .Item(Col2AdjustYesNo, I).Value = "" Then .Item(Col2AdjustYesNo, I).Value = False
                Catch ex As Exception

                End Try

                If .Item(Col2AdvanceDocId, I).Value <> "" And CBool(.Item(Col2AdjustYesNo, I).Value) Then
                    'Footer Detail
                    DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value = Format(Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value) + Val(.Item(Col2AdvanceReceive, I).Value), "0.00")
                End If
            Next
        End With

        DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value = Format(Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) - Val(DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value) - Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalAdvanceAdjusted).Value), "0.00")
        'DGLFooter2.Item(DFC_Amount, DF2R_SubTotal2).Value = Format(Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value) - Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value), "0.00")

        If Val(DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value) > 0 Then
            DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value = Format(Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value) * Val(DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value) * 0.01, "0.00")
        End If
        DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value = Format(Val(DGLFooter2.Item(DFC_Amount, DF2R_SubTotal1).Value) - Val(DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value), "0.00")

        If Val(TxtReceiveAmount.Text) > Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) Then
            DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value = Format(Val(TxtReceiveAmount.Text) - Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value), "0.00")
        Else
            DGLFooter2.Item(DFC_Amount, DF2R_AdvanceCarriedForward).Value = ""
        End If

    End Sub

    Private Sub ProcManageCharge()
        Dim I As Integer = 0
        Dim bTotal As Double = 0, bDiffAmount As Double = 0

        If Topctrl1.Mode = "Browse" Then Exit Sub

        bDiffAmount = Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) - Val(TxtReceiveAmount.Text)

        If AgL.StrCmp(TxtIsManageCharge.Text, "Yes") Then
            If bDiffAmount <= 0 Then
                TxtIsManageCharge.Text = "No"
            Else
                If Val(DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value) > 0 Then DGLFooter2.Item(DFC_Percentage, DF2R_Discount).Value = ""

                With DGL1
                    For I = .Rows.Count - 1 To 0 Step -1
                        If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""

                        If .Item(Col1ChargeDue1, I).Value <> "" And Val(.Item(Col1NetAmount, I).Value) > 0 Then
                            If bDiffAmount >= bTotal + Val(.Item(Col1NetAmount, I).Value) Then
                                bTotal += Val(.Item(Col1NetAmount, I).Value)
                                .Item(Col1Amount, I).Value = Format(Val(.Item(Col1Amount, I).Value) - Val(.Item(Col1NetAmount, I).Value), "0.00")
                            ElseIf bTotal < bDiffAmount Then
                                .Item(Col1Amount, I).Value = Format(Val(.Item(Col1Amount, I).Value) - (bDiffAmount - bTotal), "0.00")
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
            If AgL.RequiredField(TxtAllotmentDocId, "MemberName") Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1ChargeDue1) Then Exit Function
            'If AgCL.AgIsDuplicate(DGL1, "" & Col1ChargeDue1Code & "") Then Exit Function

            If BtnFillCharge.Tag.ToString.Trim <> "" Then
                If CDate(TxtV_Date.Text) < CDate(BtnFillCharge.Tag) Then
                    MsgBox("Voucher Date Can't Be Less Than From " & BtnFillCharge.Tag & "!...")
                    TxtV_Date.Focus()
                    Exit Function
                End If
            End If

            If BtnFillAdvanceVoucher.Tag.ToString.Trim <> "" Then
                If CDate(TxtV_Date.Text) < CDate(BtnFillAdvanceVoucher.Tag) Then
                    MsgBox("Voucher Date Can't Be Less Than From " & BtnFillAdvanceVoucher.Tag & "!...")
                    TxtV_Date.Focus()
                    Exit Function
                End If
            End If

            If Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineNetAmount).Value) <= 0 Then
                MsgBox("Net Charge Can't Be <= 0 (Zero)!...")
                DGL1.CurrentCell = DGL1(Col1Amount, 0) : DGL1.Focus()
                Exit Function
            End If


            If Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) <= 0 Then
                MsgBox("Net Charge Can't Be <= 0 (Zero)!...")
                DGL1.CurrentCell = DGL1(Col1Amount, 0) : DGL1.Focus()
                Exit Function
            End If

            If Val(TxtReceiveAmount.Text) < Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) Then
                MsgBox("Receive Amount Is Not Equal To Rs. """ & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) & """")
                TxtReceiveAmount.Focus() : Exit Function
            ElseIf Val(TxtReceiveAmount.Text) > Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) Then
                If MsgBox("Receive Amount Is Greater Than From Rs. """ & Val(DGLFooter2.Item(DFC_Amount, DF2R_TotalNetAmount).Value) & """" & vbCrLf & "Do You Want To Receive Advance!...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                    TxtReceiveAmount.Focus() : Exit Function
                End If
            End If

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            'If Val(DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value) > 0 Then
            '    mQry = "Select IsNull(Count(*),0) As Cnt " & _
            '            " From Sch_ChargeReceiveRegistration FrReg " & _
            '            " Where FrReg.RegistrationDocId = " & AgL.Chk_Text(mRegistrationDocId) & "  And " & _
            '            " " & IIf(Topctrl1.Mode = "Edit", " FrReg.ChargeReceiveDocId <> '" & mSearchCode & "' ", " 1=1 ") & " "

            '    If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) > 0 Then
            '        MsgBox("Please Fill Grid Again As Registration Amount Is Adjusted In Another Receipt!...")
            '        BtnFillCharge.Focus() : Exit Function
            '    End If
            'End If

            If AgL.XNull(DtHt_Enviro.Rows(0)("DiscountAc")).ToString.Trim = "" Then MsgBox("Define Discount A/c In Environment Settings!...") : Exit Function

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

        If mAllotmentDocId.Trim <> "" Then
            TxtAllotmentDocId.Focus()
            TxtAllotmentDocId.AgSelectedValue = mAllotmentDocId
            Call ProcFillCharge()
            TxtV_Date.Focus()
            TxtReceiveAmount.Focus()
        End If
    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer
        Dim mNarr As String = "", mCommonNarr$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        Dim GcnRead As SqlClient.SqlConnection
        Dim bTotalDiscount As Double


        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()


        bTotalDiscount = Val(DGLFooter1.Item(DFC_Amount, DF1R_TotalLineDiscount).Value) + Val(DGLFooter2.Item(DFC_Amount, DF2R_Discount).Value)

        I = 0
        ReDim Preserve LedgAry(I)

        If bTotalDiscount > 0 Then
            mNarr = "Being Total Discount Of Rs. " & Format(bTotalDiscount, "0.00") & " Provided!..."
            If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = AgL.XNull(DtHt_Enviro.Rows(0)("DiscountAc"))
            LedgAry(I).ContraSub = LblAllotmentDocId.Tag
            LedgAry(I).AmtDr = bTotalDiscount
            LedgAry(I).AmtCr = 0
            LedgAry(I).Narration = mNarr

            I = UBound(LedgAry) + 1
            ReDim Preserve LedgAry(I)

            LedgAry(I).SubCode = LblAllotmentDocId.Tag
            LedgAry(I).ContraSub = AgL.XNull(DtHt_Enviro.Rows(0)("DiscountAc"))
            LedgAry(I).AmtDr = 0
            LedgAry(I).AmtCr = bTotalDiscount
            LedgAry(I).Narration = mNarr

        End If


        mCommonNarr = TxtRemark.Text
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        If AgL.PubObjFrmPaymentDetail.AccountPosting(PaymentRec, AgL.GCn, AgL.Gcn_ConnectionString, AgL.ECmd, LedgAry, mCommonNarr) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

        If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

        GcnRead.Close()
        GcnRead.Dispose()
    End Function

    Private Sub BtnFillCharge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillCharge.Click, BtnFillAdvanceVoucher.Click
        Try
            Select Case sender.name
                Case BtnFillCharge.Name
                    Call ProcFillCharge()

                Case BtnFillAdvanceVoucher.Name
                    Call ProcFillAdvanceVoucher()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillCharge()
        Dim DtTemp As DataTable, DtTemp1 As DataTable
        Dim I As Integer
        Dim bAdvanceAmount As Double = 0
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            TxtIsManageCharge.Text = "No"
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            BtnFillCharge.Tag = ""

            If AgL.RequiredField(TxtV_Date) Then Exit Sub
            If AgL.RequiredField(TxtAllotmentDocId) Then Exit Sub

            'mQry = "SELECT VFd.ChargeDue1Code, VFd.NetBalance + IsNull(V1.ReceiveAmount,0) As NetBalance, VFd.V_Date " & _
            '        " FROM ViewSch_ChargeDue VFd " & _
            '        " Left Join (SELECT Fr1.ChargeDue1 AS ChargeDue1Code, IsNULL(Sum(Fr1.Amount),0) AS ReceiveAmount, IsNULL(Sum(Fr1.Discount),0) AS Discount, IsNULL(Sum(Fr1.NetAmount),0) AS NetReceiveAmount FROM dbo.Sch_ChargeReceive1 Fr1 Where Fr1.DocId = " & AgL.Chk_Text(IIf(Topctrl1.Mode = "Add", "", mSearchCode)) & "  GROUP BY Fr1.ChargeDue1 ) V1 On VFd.ChargeDue1Code = V1.ChargeDue1Code " & _
            '        " WHERE VFd.NetBalance + IsNull(V1.ReceiveAmount,0) > 0 AND VFd.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " AND " & _
            '        " VFd.AdmissionDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " " & _
            '        " Order By Vfd.V_Date "

            mQry = " SELECT CD1.Code AS ChargeDue1Code, CD1.Amount as NetBalance, CD.V_Date, CD.MonthStartDate   " & _
                    " FROM Ht_ChargeDue1 CD1 " & _
                    " LEFT JOIN Ht_ChargeDue CD ON CD.DocId=CD1.DocId " & _
                    " WHERE CD1.Code NOT IN (SELECT CR1.ChargeDue1 " & _
                    " 						FROM Ht_ChargeReceive CR " & _
                    " 						LEFT JOIN Ht_ChargeReceive1 CR1 ON CR.DocId=CR1.DocId " & _
                    "						WHERE CR.AllotmentDocId=" & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " ) " & _
                    " AND CD.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " " & _
                    " AND CD1.AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " "


            'mQry = "SELECT CD1.Code AS ChargeDue1Code,CD1.Amount as NetBalance,CD.V_Date  " & _
            '        " FROM Ht_ChargeDue1 CD1 " & _
            '        " LEFT JOIN Ht_ChargeDue CD ON CD1.DocId=CD.DocId  " & _
            '        " LEFT JOIN Ht_RoomAllotmentChargeDue RACD ON CD.DocId = RACD.ChargeDueDocId " & _
            '        " LEFT JOIN Ht_RoomTransfer RT ON RACD.AllotmentDocId=RT.AllotmentDocId " & _
            '        " LEFT JOIN Ht_RoomTransferCharge RTC ON RTC.RoomTransfer=RT.Code " & _
            '        " LEFT JOIN Sch_ChargeType FT ON RTC.Charge=FT.Code " & _
            '        " WHERE (CD.MonthStartDate =" & AgL.ConvertDate(TxtV_Date.Text) & " OR FT.Months=1 OR RTC.IsOnceInLife=1) " & _
            '        " AND CD1.Code NOT IN (SELECT CR1.ChargeDue1  " & _
            '        " 						FROM Ht_ChargeReceive CR " & _
            '        " 						LEFT JOIN Ht_ChargeReceive1 CR1 ON CR.DocId=CR1.DocId " & _
            '        " 						WHERE CR.AllotmentDocId=" & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " ) " & _
            '        " AND CD1.AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & "   "



            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    TxtAllotmentDocId.Enabled = False

                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        'Code by akash on date 16-11-10
                        DGL1.Item(Col1MonthYear, I).Value = CDate(AgL.XNull(.Rows(I)("MonthStartDate"))).ToString("MMM/yyyy")
                        'End Code
                        DGL1.AgSelectedValue(Col1ChargeDue1, I) = AgL.XNull(.Rows(I)("ChargeDue1Code"))
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("NetBalance")), "0.00")
                        DGL1.Item(Col1TempAmount, I).Value = Format(AgL.VNull(.Rows(I)("NetBalance")), "0.00")
                    Next I
                    BtnFillCharge.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                    'mQry = "SELECT Reg.DocId, IsNULL(Sum(Reg.NetAmount),0) TotalNetAmount " & _
                    '        " FROM Sch_RegistrationCharge Reg   " & _
                    '        " LEFT JOIN Sch_Charge F ON Reg.Charge = F.Code  " & _
                    '        " LEFT JOIN Sch_Admission Adm ON Reg.DocId = Adm.RegistrationDocId    " & _
                    '        " LEFT JOIN Sch_ChargeReceiveRegistration FrReg ON Reg.DocId = FrReg.RegistrationDocId    " & _
                    '        " WHERE Adm.DocId = '" & TxtAdmissionDocId.AgSelectedValue & "' AND IsNull(F.Refundable,0)<>0 AND " & _
                    '        " " & IIf(Topctrl1.Mode = "Add", " FrReg.RegistrationDocId IS Null ", " Reg.DocId = " & AgL.Chk_Text(mRegistrationDocId) & " ") & "  " & _
                    '        " GROUP BY Reg.DocId "
                    'DtTemp1 = AgL.FillData(mQry, AgL.GCn).Tables(0)
                    'With DtTemp1
                    '    If .Rows.Count > 0 Then
                    '        mRegistrationDocId = AgL.XNull(.Rows(0)("DocId"))
                    '        DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value = Format(AgL.VNull(.Rows(0)("TotalNetAmount")), "0.00")
                    '    Else
                    '        mRegistrationDocId = ""
                    '        DGLFooter2.Item(DFC_Amount, DF2R_AdjustmentAmount).Value = ""
                    '    End If
                    '    .Dispose()
                    'End With

                    bAdvanceAmount = FunGetAdvanceAmount()
                    DGLFooter2.Item(DFC_Amount, DF2R_Advance).Value = Format(bAdvanceAmount, "0.00")

                Else
                    TxtAllotmentDocId.Enabled = True

                    MsgBox("No Charge Exists To Receive!...")
                End If
            End With

            Call ProcFillAdvanceVoucher()
        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            BtnFillCharge.Tag = ""
        Finally
            DtTemp = Nothing
            DtTemp1 = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Sub ProcFillAdvanceVoucher()
        Dim DtTemp As DataTable, DtTemp1 As DataTable
        Dim I As Integer
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL2.RowCount = 1 : DGL2.Rows.Clear()
            BtnFillAdvanceVoucher.Tag = ""

            If AgL.RequiredField(TxtV_Date) Then Exit Sub
            If AgL.RequiredField(TxtAllotmentDocId) Then Exit Sub

            'mQry = "SELECT ARec.DocId As AdvanceDocId, ARec.V_Date, ARec.ReceiveAmount, ARec.IsAdjusted " & _
            '        " FROM ViewSch_AdvanceReceive ARec " & _
            '        " WHERE ARec.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " AND " & _
            '        " ARec.AdmissionDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " And " & _
            '        " " & IIf(Topctrl1.Mode = "Add", " ARec.ChargeReceiveDocId IS NULL ", " CASE WHEN ARec.ChargeReceiveDocId IS NULL THEN '" & mSearchCode & "' ELSE ARec.ChargeReceiveDocId END = '" & mSearchCode & "' ") & " " & _
            '        " Order By ARec.V_Date "


            mQry = "SELECT ARec.DocId As AdvanceDocId, ARec.V_Date, ARec.ReceiveAmount, " & _
                  " Convert(BIT,CASE WHEN CRA.ChargeAdvanceDocId IS NULL THEN 0 ELSE 1 END) AS IsAdjusted " & _
                  " FROM Ht_Advance ARec " & _
                  " LEFT JOIN Ht_ChargeReceiveAdvance CRA ON ARec.DocId=CRA.ChargeAdvanceDocId " & _
                  " WHERE ARec.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " AND " & _
                  " ARec.AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " And " & _
                  " " & IIf(Topctrl1.Mode = "Add", " CRA.ChargeReceiveDocId IS NULL ", " CASE WHEN ARec.ChargeReceiveDocId IS NULL THEN '" & mSearchCode & "' ELSE CRA.ChargeReceiveDocId END = '" & mSearchCode & "' ") & " " & _
                  " Order By ARec.V_Date "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL2.RowCount = 1 : DGL2.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL2.Rows.Add()
                        DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count
                        DGL2.AgSelectedValue(Col2AdvanceDocId, I) = AgL.XNull(.Rows(I)("AdvanceDocId"))
                        DGL2.Item(Col2AdvanceVDate, I).Value = Format(AgL.XNull(.Rows(I)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        DGL2.Item(Col2AdvanceReceive, I).Value = Format(AgL.VNull(.Rows(I)("ReceiveAmount")), "0.00")
                        DGL2.Item(Col2AdjustYesNo, I).Value = AgL.VNull(.Rows(I)("IsAdjusted"))
                    Next I
                    BtnFillAdvanceVoucher.Tag = Format(AgL.XNull(.Rows(.Rows.Count - 1)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL2.RowCount = 1 : DGL2.Rows.Clear()
            BtnFillAdvanceVoucher.Tag = ""
        Finally
            DtTemp = Nothing
            DtTemp1 = Nothing
            Call Calculation()
        End Try
    End Sub
    Private Function FunGetAdvanceAmount() As Double
        Dim bAdvanceAmount As Double = 0
        Try
            'mQry = "Select Case When IsNull(Sum(V2.NetAdvance),0) >= IsNull(Sum(V1.Advance),0) Then IsNull(Sum(V1.Advance),0) Else IsNull(Sum(V2.NetAdvance),0) End As NetAdvance " & _
            '        " From Sch_Admission Adm " & _
            '        " Left Join " & _
            '        "           (SELECT Fr.AdmissionDocId, IsNull(Sum(Fr.AdvanceCarriedForward),0) - IsNull(Sum(Fr.Advance),0) AS Advance " & _
            '        "           FROM Sch_ChargeReceive Fr " & _
            '        "           Where Fr.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " And Fr.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Fr.DocId <> '" & mSearchCode & "' ") & " " & _
            '        "           GROUP BY Fr.AdmissionDocId) As V1 On Adm.DocId = V1.AdmissionDocId " & _
            '        " Left Join " & _
            '        "           (SELECT Fr.AdmissionDocId, IsNull(Sum(Fr.AdvanceCarriedForward),0) - IsNull(Sum(Fr.Advance),0) AS NetAdvance " & _
            '        "           FROM Sch_ChargeReceive Fr " & _
            '        "           Where Fr.AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Fr.DocId <> '" & mSearchCode & "' ") & " " & _
            '        "           GROUP BY Fr.AdmissionDocId) As V2 On Adm.DocId = V2.AdmissionDocId " & _
            '        " Where Adm.DocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & " " & _
            '        " Group By Adm.DocId "



            'mQry = "Select Case When IsNull(Sum(V2.NetAdvance),0) >= IsNull(Sum(V1.Advance),0) Then IsNull(Sum(V1.Advance),0) Else IsNull(Sum(V2.NetAdvance),0) End As NetAdvance " & _
            '     " From HT_Allotment Adm " & _
            '     " Left Join " & _
            '     "           (SELECT Fr.AllotmentDocId, IsNull(Sum(Fr.AdvanceCarriedForward),0) - IsNull(Sum(Fr.AdvanceBroughtForward),0) AS Advance " & _
            '     "           FROM Ht_ChargeReceive Fr " & _
            '     "           Where Fr.AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " And Fr.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Fr.DocId <> '" & mSearchCode & "' ") & " " & _
            '     "           GROUP BY Fr.AllotmentDocId) As V1 On Adm.DocId = V1.AllotmentDocId " & _
            '     " Left Join " & _
            '     "           (SELECT Fr.AllotmentDocId, IsNull(Sum(Fr.AdvanceCarriedForward),0) - IsNull(Sum(Fr.AdvanceBroughtForward),0) AS NetAdvance " & _
            '     "           FROM Sch_ChargeReceive Fr " & _
            '     "           Where Fr.AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " Fr.DocId <> '" & mSearchCode & "' ") & " " & _
            '     "           GROUP BY Fr.AllotmentDocId) As V2 On Adm.DocId = V2.AllotmentDocId " & _
            '     " Where Adm.DocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " " & _
            '     " Group By Adm.DocId "


            mQry = "Select  " & _
                    " Case When IsNull(Sum(V2.NetAdvance),0) >= IsNull(Sum(V1.Advance),0) Then IsNull(Sum(V1.Advance),0)   " & _
                    " Else IsNull(Sum(V2.NetAdvance),0) End As NetAdvance    " & _
                    " From HT_RoomAllotment Adm    " & _
                    " Left Join   " & _
                    "      (SELECT Fr.AllotmentDocId,   " & _
                    "      IsNull(Sum(Fr.AdvanceCarriedForward),0) - IsNull(Sum(Fr.AdvanceBroughtForward),0) AS Advance " & _
                    "      FROM Ht_ChargeReceive Fr " & _
                    "      Where Fr.AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " " & _
                    "      And Fr.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " And  1 = 1 " & _
                    "      GROUP BY Fr.AllotmentDocId) As V1 " & _
                    " On Adm.DocId = V1.AllotmentDocId    " & _
                    " Left Join   " & _
                    "       (SELECT Fr.AllotmentDocId,   " & _
                    "       IsNull(Sum(Fr.AdvanceCarriedForward),0) - IsNull(Sum(Fr.AdvanceBroughtForward),0) AS NetAdvance " & _
                    "       FROM Ht_ChargeReceive Fr " & _
                    "       Where Fr.AllotmentDocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " And  1=1 " & _
                    "       GROUP BY Fr.AllotmentDocId) As V2 " & _
                    " On Adm.DocId = V2.AllotmentDocId " & _
                    " Where Adm.DocId = " & AgL.Chk_Text(TxtAllotmentDocId.AgSelectedValue) & " Group By Adm.DocId   "




            bAdvanceAmount = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
        Catch ex As Exception
            bAdvanceAmount = 0
            MsgBox(ex.Message)
        Finally
            FunGetAdvanceAmount = bAdvanceAmount
        End Try
    End Function

    Public Sub FindMove(ByVal mDocId As String)
        Try
            If mDocId <> "" Then
                AgL.PubSearchRow = mDocId
                If AgL.PubMoveRecApplicable Then
                    AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                    BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                End If
                Call MoveRec()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class