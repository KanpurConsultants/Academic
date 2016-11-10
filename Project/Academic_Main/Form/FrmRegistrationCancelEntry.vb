Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmRegistrationCancelEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Fee As Byte = 1
    Private Const Col1Amount As Byte = 2
    Private Const Col1Discount As Byte = 3
    Private Const Col1NetAmount As Byte = 4
    Private Const Col1RefundableYesNo As Byte = 5


    Public WithEvents DGLFooter As New AgControls.AgDataGrid
    Private Const DFC_Description As Byte = 0
    Private Const DFC_Amount As Byte = 1

    Private Const DFR_TotalAmount As Byte = 0
    Private Const DFR_TotalDiscount As Byte = 1
    Private Const DFR_TotalNetAmount As Byte = 2
    Private Const DFR_TotalRefundableAmount As Byte = 3

    Dim PaymentRec As AgLibrary.ClsMain.PaymentDetail = Nothing
    Dim mObjFrmPaymentDetail As AgLibrary.FrmPaymentDetail = Nothing
    Dim mMaxFeeAc$ = ""



    Dim mBlnIsAutoApproved As Boolean = False
    Dim _FormType As eFormType

    Public Enum eFormType
        RegistrationCancelEntry
        RegistrationCancelEntryAuthenticated
    End Enum

    Public Property FormType() As eFormType
        Get
            FormType = _FormType
        End Get
        Set(ByVal value As eFormType)
            _FormType = value
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
        ''================< Fee Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1Fee", 320, 8, "Fee Head", True, True, False)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 100, 8, 2, False, "Fee Amount", False, True, True)
            .AddAgNumberColumn(DGL1, "DGL1Discount", 80, 8, 2, False, "Discount", False, True, True)
            .AddAgNumberColumn(DGL1, "DGL1NetAmount", 100, 8, 2, False, "Net Amount", True, True, True)
            .AddAgYesNoColumn(DGL1, "DGL1RefundableYesNo", 100, "Refundable (Yes/No)", True, True, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40

        ''==============================================================================
        ''================< Footer Data Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGLFooter, "DGLFDescription", 190, 5, "Description", True, True, False)
            .AddAgTextColumn(DGLFooter, "DGLFAmount", 100, 30, "Amount", True, True, True)
        End With
        AgL.AddAgDataGrid(DGLFooter, PnlFooter)
        DGLFooter.RowCount = 5
        DGLFooter.AllowUserToAddRows = False
        DGLFooter.Item(DFC_Description, DFR_TotalAmount).Value = "Amount".ToUpper
        DGLFooter.Item(DFC_Description, DFR_TotalDiscount).Value = "(-) Discount".ToUpper
        DGLFooter.Item(DFC_Description, DFR_TotalNetAmount).Value = "Net Amount".ToUpper
        DGLFooter.Item(DFC_Description, DFR_TotalRefundableAmount).Value = "Refundable Amount".ToUpper
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
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, mMaxFeeAc, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
                AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
                AgL.PubObjFrmPaymentDetail.ShowDialog()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec

                TxtRefundAmount.Text = Format(Val(PaymentRec.TotalAmount), "0.00")

                If Val(TxtRefundAmount.Text) <> Val(DGLFooter.Item(DFC_Amount, DFR_TotalRefundableAmount).Value) Then
                    MsgBox("Refund Amount Is Not Equal To Rs. """ & Val(DGLFooter.Item(DFC_Amount, DFR_TotalRefundableAmount).Value) & """")
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
            AgL.WinSetting(Me, 550, 950, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGLFooter)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGLFooter, False)
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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Rc.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("Rc.Site_Code", AgL.PubSiteCode) & " "

            If _FormType = eFormType.RegistrationCancelEntry Then
                mCondStr += " And IsNull(Rc.ApprovedBy,'')='' "
            ElseIf _FormType = eFormType.RegistrationCancelEntryAuthenticated Then
                mCondStr += " And IsNull(Rc.ApprovedBy,'')<>'' "
            End If


            mQry = "Select Rc.DocId As SearchCode " & _
                    " From Sch_RegistrationCancel Rc " & _
                    " LEFT JOIN Voucher_Type Vt ON Rc.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
              " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RegistrationCancelEntry) & "" & _
              " Order By Description"
        TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)


        mQry = "SELECT R.DocId As Code, " & AgL.V_No_Field("R.DocId") & " As [Voucher No], R.V_Date, R.FirstName, " & _
                " R.MiddleName ,R.LastName, R.StudentCode, R.MotherNamePrefix , R.MotherName , " & _
                " R.FatherNamePrefix , R.FatherName , R.IsNewStudent, CASE WHEN IsNull(R.IsCancelled,0)  <> 0 THEN 'Yes' ELSE 'No' END AS IsCancelledYesNo,  " & _
                " R.SessionProgramme, R.AdmissionNature, R.TotalAmount , R.TotalDiscount , R.TotalNetAmount, R.IsAdmited " & _
                " FROM ViewSch_Registration R " & _
                " WHERE " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & _
                " And IsNull(R.IsAdmited,0) = 0 " & _
                " And R.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " "
        TxtRegistrationDocId.AgHelpDataSet(15) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.SubCode AS Code, Sg.Name " & _
                  " From Sch_Student S " & _
                  " Left Join SubGroup Sg On Sg.SubCode = S.SubCode " & _
                  " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                  " Order By Sg.Name "
        TxtStudent.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Vs.Code , VS.SessionProgramme Name " & _
                " FROM ViewSch_SessionProgramme VS " & _
                " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY VS.SessionProgramme"
        TxtSessionProgramme.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT N.Code , N.Description AS Name FROM Sch_AdmissionNature N ORDER BY N.Description "
        TxtAdmissionNature.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT F.Code, Sg.Name, F.FeeNature, F.Refundable " & _
                " FROM Sch_Fee F " & _
                " LEFT JOIN SubGroup Sg ON Sg.SubCode = F.Code " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " And " & _
                " F.FeeNature  NOT IN ('" & Academic_ProjLib.ClsMain.FeeNature_LateFee & "', '" & Academic_ProjLib.ClsMain.FeeNature_Fine & "') " & _
                " ORDER BY F.FeeNature , Sg.Name "
        DGL1.AgHelpDataSet(Col1Fee, 2) = AgL.FillData(mQry, AgL.GCn)

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

                    AgL.Dman_ExecuteNonQry("Delete From Sch_RegistrationCancelPaymentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)


                    AgL.Dman_ExecuteNonQry("Delete From Sch_RegistrationStatus Where DocId=" & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & " and Status =" & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_Cancelled) & " ", AgL.GCn, AgL.ECmd)


                    AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, mMaxFeeAc, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
                    AgL.PubObjFrmPaymentDetail.DeletePaymentDetail(AgL.GCn, AgL.ECmd)
                    AgL.PubObjFrmPaymentDetail = Nothing

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    AgL.Dman_ExecuteNonQry("Delete From Sch_RegistrationCancel Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        DispText(False)
    End Sub

    Private Sub Topctrl_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtV_Date.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMasteRc.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Rc.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("Rc.Site_Code", AgL.PubSiteCode) & " "

            If _FormType = eFormType.RegistrationCancelEntry Then
                mCondStr += " And IsNull(Rc.ApprovedBy,'')='' "
            ElseIf _FormType = eFormType.RegistrationCancelEntryAuthenticated Then
                mCondStr += " And IsNull(Rc.ApprovedBy,'')<>'' "
            End If


            AgL.PubFindQry = "SELECT Rc.DocId As SearchCode, " & AgL.V_No_Field("Rc.DocId") & " As [Voucher No], " & AgL.V_No_Field("R.DocId") & " [Registration VNo], Sd.FirstName  + space(1) + IsNULL(Sd.MiddleName , '')  + space(1) + Sd.LastName AS Student, " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], Rc.V_Date, Rc.RefundAmount, " & _
                                " Vs.SessionProgrammeStream AS [Programme (Stream)], N.Description As AdmissionNature, Rc.Remark, Sd.Phone, Sd.Mobile  , Sd.EMail " & _
                                " FROM dbo.Sch_RegistrationCancel Rc " & _
                                " LEFT JOIN Voucher_Type Vt ON Rc.V_Type = Vt.V_Type " & _
                                " LEFT JOIN SiteMast S ON Rc.Site_Code = S.Code " & _
                                " Left Join Sch_Registration R On Rc.RegistrationDocId = R.DocId " & _
                                " LEFT JOIN Sch_RegistrationStudentDetail Sd ON R.DocId = Sd.DocId " & _
                                " LEFT JOIN ViewSch_SessionProgrammeStream Vs ON R.SessionProgrammeStream = Vs.Code " & _
                                " LEFT JOIN Sch_AdmissionNature N ON R.AdmissionNature = N.Code " & mCondStr

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
            'Me.Cursor = Cursors.WaitCursor

            'AgL.PubReportTitle = "Sale Bill"
            'RepName = "SaleInvoice" : RepTitle = "Sale Invoice"

            'If mDocId = "" Then
            '    MsgBox("No Records Found to Print!!!", vbInformation, "Information")
            '    Me.Cursor = Cursors.Default
            '    Exit Sub
            'End If

            'strQry = "SELECT S.DocId,Vt.Description AS V_TypeDesc,S.V_Prefix,S.V_No,S.V_Date, " & _
            '            "S.SaleOrderDocId,S.SaleDocId,S.CashCredit,C.Name As Customer_AC,S.PartyName, " & _
            '            "S.Add1,S.Add2,S.Add3,S.CityCode,SMan.Name AS SalesMan_Name,Astro.Name AS Astrologer_Name, " & _
            '            "S.Amount AS Amount_H,S.Scheme AS SchemeAmt_H, " & _
            '            "S.Addition AS Addition_H,S.Deduction AS Deduction_H,S.TaxableAmt AS TaxableAmt_H, " & _
            '            "S.TaxPer AS TaxPer_H,S.TaxAmt AS TaxAmt_H,S.AdditionalTaxPer AS AdditionalTaxPer_H, " & _
            '            "S.AdditionalTaxAmt AS AdditionalTaxAmt_H,S.Labour AS Labour_H, " & _
            '            "S.AdditionAfterTax_Per AS AdditionAfterTax_Per_H,S.AdditionAfterTax AS AdditionAfterTax_H, " & _
            '            "S.DeductionAfterTax_Per AS DeductionAfterTax_Per_H,S.DeductionAfterTax AS DeductionAfterTax_H, " & _
            '            "S.TotalAmount AS TotalAmount_H,S.RoundOff AS RoundOff_H,S.NetAmount AS NetAmount_H, " & _
            '            "S.Advance AS Advance_H,S.Balance AS Balance_H,S.Remark AS Remark_H,S.PreparedBy, " & _
            '            "S.U_EntDt,S.U_AE,S.Edit_Date,S.ModifiedBy,Stk.Sr,Stk.OrderDocId,Stk.ReferenceDocID, " & _
            '            "Stk.BarCode,Scheme.Description AS SchemeDescription,Stk.Item,(Case When Stk.ItemDesc Is Null Then I.Description Else Stk.ItemDesc End) As ItemDesc, U.Description As Unit, " & _
            '            "TFL.Description AS TaxForm_L,Stk.SchemeYn,Stk.GroupReceiveQty,Stk.GroupIssueQty,Stk.ReceiveQty, " & _
            '            "Stk.IssueQty,Stk.PrintQty,Stk.Rate,Stk.Amount,Stk.Addition,Stk.Deduction,Stk.TaxableAmt, " & _
            '            "Stk.TaxPer,Stk.TaxAmt,Stk.AdditionalTaxPer,Stk.AdditionalTaxAmt,Stk.AdditionAfterTax, " & _
            '            "Stk.DeductionAfterTax, Stk.NetAmount, Stk.CentralTaxAmt, Stk.LandedRate, Stk.LandedAmount, Stk.Remark, Site.Name As SiteName " & _
            '            "FROM Sale S " & _
            '            "LEFT JOIN Stock Stk ON S.DocId = Stk.DocId " & _
            '            "LEFT JOIN Voucher_Type Vt ON s.V_Type =Vt.V_Type " & _
            '            "LEFT JOIN SubGroup C ON S.Customer = C.SubCode " & _
            '            "LEFT JOIN SubGroup SMan ON S.SalesMan = SMan.SubCode " & _
            '            "LEFT JOIN SubGroup Astro ON S.Astrologer  = Astro.SubCode " & _
            '            " " & _
            '            "LEFT JOIN SCHEME ON Stk.Scheme = Scheme.Code " & _
            '            "LEFT JOIN TaxForm TfL ON Stk.TaxForm =TFL.Code " & _
            '            "Left Join Item I On Stk.Item = I.Code " & _
            '            "Left Join Unit U On I.Unit = U.Code " & _
            '            "Left Join SiteMast Site On I.Site_Code = Site.Code " & _
            '            "Where S.DocId = '" & mDocId & "' "


            'AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            'AgL.ADMain.Fill(DsRep)


            'AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic & "\" & RepName & ".ttx", True)
            'mCrd.Load(PLib.PubReportPath_Academic & "\" & RepName & ".rpt")
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
        Dim mTrans As Boolean = False
        Dim bStrApprovedDate$ = ""
        Dim bDtDatble As DataTable
        Dim mRegsr As Integer
        Dim j As Integer
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub

            If mBlnIsAutoApproved Then bStrApprovedDate = AgL.GetDateTime(AgL.GCn)

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_RegistrationCancel( " & _
                        " DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, " & _
                        " RegistrationDocId, RefundAmount, Remark, " & _
                        " PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & ", " & Val(TxtRefundAmount.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_RegistrationCancel " & _
                        " SET " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " RegistrationDocId = " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & ", " & _
                        " RefundAmount = " & Val(TxtRefundAmount.Text) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            mQry = "select max(sr) as msr from Sch_RegistrationStatus With (NoLock)  where docid=" & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & " "
            bDtDatble = AgL.FillData(mQry, AgL.GcnRead).tABLES(0)
            mRegsr = 0
            With bDtDatble
                For j = 0 To .Rows.Count - 1
                    mRegsr = .Rows(j)("msr") + 1
                Next
            End With

            If mRegsr = 0 Then
                mRegsr = 1
            End If

            If Topctrl1.Mode = "Add" Then
                mQry = " INSERT INTO dbo.Sch_RegistrationStatus " & _
                        " (DocId,Sr,Status,StatusDate,SessionProgrammeStream)" & _
                        " VALUES ( " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & " , " & mRegsr & "," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_Cancelled) & "," & AgL.ConvertDate(TxtV_Date.Text) & "," & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " ) "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If FormType = eFormType.RegistrationCancelEntry Then
                If Topctrl1.Mode = "Edit" Then
                    mQry = "Update Sch_RegistrationCancelPaymentDetail Set PaymentDocId = Null Where DocId = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If

                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, mMaxFeeAc, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
                AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
                If Not AgL.PubObjFrmPaymentDetail.SavePaymentDetail(PaymentRec, AgL.GCn, AgL.ECmd) Then Err.Raise(1, , "Save Error")
                mObjFrmPaymentDetail = AgL.PubObjFrmPaymentDetail
                AgL.PubObjFrmPaymentDetail = Nothing

                If Topctrl1.Mode = "Add" Then
                    mQry = "INSERT INTO Sch_RegistrationCancelPaymentDetail ( DocId, PaymentDocId, LedgerMDocId ) VALUES ( " & _
                            " '" & mSearchCode & "', '" & mSearchCode & "', Null )"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                Else
                    mQry = "Update Sch_RegistrationCancelPaymentDetail Set PaymentDocId = '" & mSearchCode & "' Where DocId = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If

                If mBlnIsAutoApproved Then Call ProcApproveVoucher(AgL.PubUserName, bStrApprovedDate, mBlnIsAutoApproved)
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
        Dim I As Integer
        Dim mTransFlag As Boolean = False
        Dim bNetAmount As Double = 0

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
                mQry = "Select Rc.*, Vt.NCat, R.SessionProgramme, R.AdmissionNature,  " & _
                        " R.TotalAmount, R.TotalDiscount, R.TotalNetAmount, R.V_Date As RegistrationVDate " & _
                        " From Sch_RegistrationCancel Rc " & _
                        " Left Join Voucher_Type Vt On Rc.V_Type = Vt.V_Type " & _
                        " Left Join Sch_Registration R On Rc.RegistrationDocId = R.DocId " & _
                        " Where Rc.DocId='" & mSearchCode & "'"
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

                        TxtRegistrationDocId.AgSelectedValue = AgL.XNull(.Rows(0)("RegistrationDocId"))
                        LblRegistrationDocId.Tag = Format(AgL.XNull(.Rows(0)("RegistrationVDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgramme"))
                        TxtAdmissionNature.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionNature"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value = Format(AgL.VNull(.Rows(0)("TotalAmount")), "0.00")
                        DGLFooter.Item(DFC_Amount, DFR_TotalDiscount).Value = Format(AgL.VNull(.Rows(0)("TotalDiscount")), "0.00")
                        DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value = Format(AgL.VNull(.Rows(0)("TotalNetAmount")), "0.00")
                        DGLFooter.Item(DFC_Amount, DFR_TotalRefundableAmount).Value = Format(AgL.VNull(.Rows(0)("RefundAmount")), "0.00")
                        TxtRefundAmount.Text = Format(AgL.VNull(.Rows(0)("RefundAmount")), "0.00")

                        mBlnIsAutoApproved = AgL.VNull(.Rows(0)("IsAutoApproved"))

                        TxtApproved.Text = AgL.XNull(.Rows(0)("ApprovedBy"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)

                    End If
                End With


                mQry = "Select Sd.* " & _
                        " From Sch_RegistrationStudentDetail Sd " & _
                        " Where Sd.DocId = " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & " "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    TxtIsNewStudent.Text = IIf(AgL.VNull(.Rows(0)("IsNewStudent")), "Yes", "No")
                    TxtStudent.AgSelectedValue = AgL.XNull(.Rows(0)("Student"))
                    TxtFirstName.Text = AgL.XNull(.Rows(0)("FirstName"))
                    TxtMiddleName.Text = AgL.XNull(.Rows(0)("MiddleName"))
                    TxtLastName.Text = AgL.XNull(.Rows(0)("LastName"))

                    TxtFatherName.Text = AgL.XNull(.Rows(0)("FatherName"))
                    TxtFatherNamePrefix.Text = AgL.XNull(.Rows(0)("FatherNamePrefix"))
                    TxtMotherName.Text = AgL.XNull(.Rows(0)("MotherName"))
                    TxtMotherNamePrefix.Text = AgL.XNull(.Rows(0)("MotherNamePrefix"))
                End With

                mQry = "Select Rf.*, F.Refundable " & _
                        " From Sch_RegistrationFee Rf " & _
                        " Left Join Sch_Fee F On Rf.Fee = F.Code " & _
                        " Where Rf.DocId=" & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & " "
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.Item(Col1Discount, I).Value = Format(AgL.VNull(.Rows(I)("Discount")), "0.00")
                            DGL1.Item(Col1NetAmount, I).Value = Format(AgL.VNull(.Rows(I)("NetAmount")), "0.00")
                            DGL1.Item(Col1RefundableYesNo, I).Value = IIf(AgL.VNull(.Rows(I)("Refundable")), "Yes", "No")

                            If bNetAmount < AgL.VNull(.Rows(I)("NetAmount")) And AgL.VNull(.Rows(I)("Refundable")) Then
                                mMaxFeeAc = AgL.XNull(.Rows(I)("Fee"))
                            End If

                        Next I
                    End If
                End With

                ''Payment Detail Moverec Common
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, mMaxFeeAc, "Dr", AgLibrary.FrmPaymentDetail.TransactionType.Payment)
                AgL.PubObjFrmPaymentDetail.FillPaymentRec()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec
                mObjFrmPaymentDetail = AgL.PubObjFrmPaymentDetail
                AgL.PubObjFrmPaymentDetail = Nothing
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If mTransFlag Then
                    Topctrl1.tEdit = False
                    Topctrl1.tDel = False
                Else
                    If FormType = eFormType.RegistrationCancelEntryAuthenticated Then
                        Topctrl1.tAdd = False
                    End If
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
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = "" : mMaxFeeAc = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Call BlankFooterGrid()

        mBlnIsAutoApproved = False

        PaymentRec = Nothing : mObjFrmPaymentDetail = Nothing

        TxtIsNewStudent.Text = "Yes"

        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub BlankFooterGrid(Optional ByVal bIsCalculationCall As Boolean = False)
        DGLFooter.Item(DFC_Amount, DFR_TotalRefundableAmount).Value = ""

        If Not bIsCalculationCall Then
            DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value = ""
            DGLFooter.Item(DFC_Amount, DFR_TotalDiscount).Value = ""
            DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value = ""
        End If
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        TxtSessionProgramme.Enabled = False
        TxtStudent.Enabled = False : TxtAdmissionNature.Enabled = False
        TxtFirstName.Enabled = False : TxtMiddleName.Enabled = False : TxtLastName.Enabled = False
        TxtFatherName.Enabled = False : TxtFatherNamePrefix.Enabled = False
        TxtMotherName.Enabled = False : TxtMotherNamePrefix.Enabled = False

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
            TxtRegistrationDocId.Enabled = False
        End If

        If _FormType = eFormType.RegistrationCancelEntryAuthenticated Then
            GroupBox1.Visible = True : BtnApproved.Enabled = False
            Topctrl1.tAdd = False

            If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                DGL1.ReadOnly = Enb : TxtRefundAmount.Enabled = False
            End If
        ElseIf _FormType = eFormType.RegistrationCancelEntry Then
            GroupBox1.Visible = True
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
                Case Col1Fee
                    'Call IniItemHelp(False, DGL1.AgSelectedValue(Col1BarCode, mRowIndex))
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Dgl1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            Select Case Dgl1.CurrentCell.ColumnIndex
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
                Case Col1Fee
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
            If DGL1.Item(Col1Fee, 0).Value Is Nothing Then DGL1.Item(Col1Fee, 0).Value = ""
            If DGL1.Item(Col1Fee, 0).Value.ToString.Trim = "" Then
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
        TxtV_Type.Enter, TxtRefundAmount.Enter, TxtRegistrationDocId.Enter

        Try
            Select Case sender.name
                Case TxtRegistrationDocId.Name
                    TxtRegistrationDocId.AgRowFilter = " V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " " & _
                                                        " " & IIf(Topctrl1.Mode = "Add", " And IsCancelledYesNo = 'No' ", "") & " "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtDocId.Validating, TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_No.Validating, TxtV_Date.Validating, _
          TxtRegistrationDocId.Validating, TxtRemark.Validating, TxtRefundAmount.Validating

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
                    TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text.ToString)

                Case TxtRegistrationDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblRegistrationDocId.Tag = ""

                        TxtIsNewStudent.Text = ""
                        TxtStudent.AgSelectedValue = ""
                        TxtSessionProgramme.AgSelectedValue = ""
                        TxtAdmissionNature.AgSelectedValue = ""
                        TxtFirstName.Text = ""
                        TxtMiddleName.Text = ""
                        TxtLastName.Text = ""
                        TxtFatherNamePrefix.Text = ""
                        TxtFatherName.Text = ""
                        TxtMotherName.Text = ""
                        TxtMotherNamePrefix.Text = ""

                        DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value = ""
                        DGLFooter.Item(DFC_Amount, DFR_TotalDiscount).Value = ""
                        DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblRegistrationDocId.Tag = Format(AgL.XNull(.Item("V_Date", .CurrentCell.RowIndex).Value), AgLibrary.ClsConstant.DateFormat_ShortDate)


                                TxtIsNewStudent.Text = IIf(AgL.VNull(.Item("IsNewStudent", .CurrentCell.RowIndex).Value), "Yes", "No")
                                TxtStudent.AgSelectedValue = AgL.XNull(.Item("StudentCode", .CurrentCell.RowIndex).Value)
                                TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Item("SessionProgramme", .CurrentCell.RowIndex).Value)
                                TxtAdmissionNature.AgSelectedValue = AgL.XNull(.Item("AdmissionNature", .CurrentCell.RowIndex).Value)
                                TxtFirstName.Text = AgL.XNull(.Item("FirstName", .CurrentCell.RowIndex).Value)
                                TxtMiddleName.Text = AgL.XNull(.Item("MiddleName", .CurrentCell.RowIndex).Value)
                                TxtLastName.Text = AgL.XNull(.Item("LastName", .CurrentCell.RowIndex).Value)
                                TxtFatherNamePrefix.Text = AgL.XNull(.Item("FatherNamePrefix", .CurrentCell.RowIndex).Value)
                                TxtFatherName.Text = AgL.XNull(.Item("FatherName", .CurrentCell.RowIndex).Value)
                                TxtMotherName.Text = AgL.XNull(.Item("MotherName", .CurrentCell.RowIndex).Value)
                                TxtMotherNamePrefix.Text = AgL.XNull(.Item("MotherNamePrefix", .CurrentCell.RowIndex).Value)

                                DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value = Format(AgL.VNull(.Item("TotalAmount", .CurrentCell.RowIndex).Value), "0.00")
                                DGLFooter.Item(DFC_Amount, DFR_TotalDiscount).Value = Format(AgL.VNull(.Item("TotalDiscount", .CurrentCell.RowIndex).Value), "0.00")
                                DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value = Format(AgL.VNull(.Item("TotalNetAmount", .CurrentCell.RowIndex).Value), "0.00")

                            End With
                        End If
                    End If

                    Call ProcFillFeeDetail()
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

    Private Sub ProcFillFeeDetail()
        Dim DtTemp As DataTable = Nothing
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            mQry = "Select Rf.*, F.Refundable " & _
                    " From Sch_Registration R " & _
                    " Left Join Sch_RegistrationFee Rf On Rf.DocId = R.DocId " & _
                    " Left Join Sch_Fee F On Rf.Fee = F.Code " & _
                    " Where Rf.DocId=" & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & ""
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                        DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                        DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        DGL1.Item(Col1Discount, I).Value = Format(AgL.VNull(.Rows(I)("Discount")), "0.00")
                        DGL1.Item(Col1NetAmount, I).Value = Format(AgL.VNull(.Rows(I)("NetAmount")), "0.00")
                        DGL1.Item(Col1RefundableYesNo, I).Value = IIf(AgL.VNull(.Rows(I)("Refundable")), "Yes", "No")
                    Next I
                Else
                    MsgBox("Fee Detail Not Exists!...")
                End If
            End With
        Catch ex As Exception
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
            MsgBox(ex.Message)
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        Dim bNetAmount As Double = 0

        If Topctrl1.Mode = "Browse" Then Exit Sub

        Call BlankFooterGrid(True)

        mMaxFeeAc = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""
                If .Item(Col1RefundableYesNo, I).Value Is Nothing Then .Item(Col1RefundableYesNo, I).Value = ""

                If .Item(Col1Fee, I).Value <> "" Then
                    If AgL.StrCmp(.Item(Col1RefundableYesNo, I).Value, "Yes") Then
                        If bNetAmount < Val(.Item(Col1NetAmount, I).Value) Then
                            mMaxFeeAc = .AgSelectedValue(Col1Fee, I)
                        End If

                        'Footer Detail
                        DGLFooter.Item(DFC_Amount, DFR_TotalRefundableAmount).Value = Format(Val(DGLFooter.Item(DFC_Amount, DFR_TotalRefundableAmount).Value) + Val(.Item(Col1NetAmount, I).Value), "0.00")
                    End If
                End If
            Next
        End With

    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bFeeDetailFlag As Boolean = False
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtRegistrationDocId, "Registraton Vr. No.") Then Exit Function

            If CDate(TxtV_Date.Text) < CDate(LblRegistrationDocId.Tag) Then
                MsgBox("Voucher Date Can't Be Less Than From """ & LblRegistrationDocId.Tag & """")
                TxtV_Date.Focus() : Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL1)
            With DGL1
                bFeeDetailFlag = False
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""
                    If .Item(Col1RefundableYesNo, I).Value Is Nothing Then .Item(Col1RefundableYesNo, I).Value = ""

                    If .Item(Col1Fee, I).Value <> "" Then
                        If AgL.StrCmp(.Item(Col1RefundableYesNo, I).Value, "Yes") Then
                            If Val(.Item(Col1NetAmount, I).Value) > 0 And bFeeDetailFlag = False Then bFeeDetailFlag = True : Exit For
                        End If
                    End If
                Next

                If Not bFeeDetailFlag Then
                    If MsgBox("Fee Detail Not Exists!..." & vbCrLf & "Want To Continue?...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then TxtRegistrationDocId.Focus() : Exit Function

                Else
                    If Val(DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value) <= 0 Then
                        MsgBox("Refund Amount Can't Be Blank!...")
                        TxtRegistrationDocId.Focus() : Exit Function
                    End If
                End If
            End With

            If Val(TxtRefundAmount.Text) <> Val(DGLFooter.Item(DFC_Amount, DFR_TotalRefundableAmount).Value) Then
                MsgBox("Refund Amount Is Not Equal To Rs. """ & Val(DGLFooter.Item(DFC_Amount, DFR_TotalRefundableAmount).Value) & """")
                TxtRefundAmount.Focus() : Exit Function
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
            If TxtV_Type.Enabled Then TxtV_Type.Focus() Else TxtV_Date.Focus()
        Else
            TxtV_Date.Focus()
        End If

    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer, J As Integer
        Dim mNarr As String = "", mCommonNarr$ = "", bContraSub$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        Dim GcnRead As SqlClient.SqlConnection
        Dim DtTemp As DataTable


        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        I = 0
        ReDim Preserve LedgAry(I)

        If Val(PaymentRec.TotalAmount) > 0 Then

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

            mQry = "SELECT Rf.Fee, Max(Sg.Name) As FeeName, Sum(Rf.NetAmount) AS NetAmount " & _
                    " FROM Sch_RegistrationFee Rf With (NoLock) " & _
                    " Left Join Sch_Fee F  With (NoLock) On Rf.Fee = F.Code " & _
                    " Left Join SubGroup Sg With (NoLock) On F.Code = Sg.SubCode " & _
                    " WHERE Rf.DocId = " & AgL.Chk_Text(TxtRegistrationDocId.AgSelectedValue) & " And " & _
                    " IsNull(F.Refundable,0) <> 0 " & _
                    " GROUP BY Rf.Fee "
            DtTemp = AgL.FillData(mQry, GcnRead).Tables(0)
            With DtTemp
                For J = 0 To .Rows.Count - 1
                    mNarr = "Being " & AgL.XNull(.Rows(J)("FeeName")) & " of Rs. " & AgL.VNull(.Rows(J)("NetAmount")) & " Refuned."

                    I = UBound(LedgAry) + 1
                    ReDim Preserve LedgAry(I)

                    LedgAry(I).SubCode = AgL.XNull(.Rows(J)("Fee"))
                    LedgAry(I).ContraSub = bContraSub
                    LedgAry(I).AmtDr = Val(Format(AgL.VNull(.Rows(J)("NetAmount")), "0.00"))
                    LedgAry(I).AmtCr = 0
                    LedgAry(I).Narration = mNarr
                Next
            End With

            mCommonNarr = TxtRemark.Text
            If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

            If AgL.PubObjFrmPaymentDetail.AccountPosting(PaymentRec, AgL.GCn, AgL.Gcn_ConnectionString, AgL.ECmd, LedgAry, mCommonNarr, False) = False Then
                AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
            End If

            If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
                AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
            End If
        Else
            '=====================================================================
            '==========< Unpost Ledger Posting >==================================
            '=========< If Refund Amount Is Zero >================================
            '=====================================================================
            AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)
            '=====================================================================
        End If



        GcnRead.Close()
        GcnRead.Dispose()
    End Function


    Private Sub BtnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnApproved.Click
        Dim mTrans As Boolean = False
        Dim mApprovedDate$ = ""

        Select Case sender.name
            Case BtnApproved.Name
                Try
                    If Topctrl1.Mode = "Browse" Then
                        If MsgBox("Are You Sure To Approve Record", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Approved Confirmation...") = MsgBoxResult.No Then Exit Sub

                        If mSearchCode <> "" Then
                            ''=======================Approval Start======================================

                            TxtApproved.Text = AgL.PubUserName
                            mApprovedDate = AgL.GetDateTime(AgL.GCn)

                            AgL.ECmd = AgL.GCn.CreateCommand
                            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                            AgL.ECmd.Transaction = AgL.ETrans
                            mTrans = True


                            Call ProcApproveVoucher(TxtApproved.Text, mApprovedDate, False)

                            ''===========================================================================

                            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                            AgL.ETrans.Commit()
                            mTrans = False

                            MsgBox("Voucher Approved Successfully.", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                            If AgL.PubMoveRecApplicable Then
                                FIniMaster(0, 1) : Topctrl_tbRef()
                            End If
                            MoveRec()
                        End If
                    End If
                Catch ex As Exception
                    If mTrans = True Then AgL.ETrans.Rollback()
                    MsgBox(ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                End Try
        End Select
    End Sub

    Private Sub ProcApproveVoucher(ByVal StrApprovedBy As String, ByVal StrApprovedDate As String, ByVal BlnIsAutoApproved As Boolean)

        mQry = "Update Sch_RegistrationCancel Set ApprovedBy='" & StrApprovedBy & "', ApprovedDate=" & AgL.Chk_Text(StrApprovedDate) & ", IsAutoApproved = " & IIf(BlnIsAutoApproved, 1, 0) & " Where DocId='" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        AgL.PubObjFrmPaymentDetail = mObjFrmPaymentDetail
        Call AccountPosting()

        mQry = "Update Sch_RegistrationCancelPaymentDetail " & _
                " Set " & _
                " LedgerMDocId = '" & mSearchCode & "' " & _
                " Where DocId = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        Call AgL.LogTableEntry(mSearchCode, Me.Text, AgLibrary.ClsConstant.EntryMode_Varified, AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , TxtV_Date.Text, , , Val(TxtRefundAmount.Text), TxtSite_Code.AgSelectedValue, AgL.PubDivCode)
    End Sub

End Class
