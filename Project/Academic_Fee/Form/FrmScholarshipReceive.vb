Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmScholarshipReceive
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1AdmissionDocId As Byte = 1
    Private Const Col1DemandAmount As Byte = 2
    Private Const Col1ReceiveAmount As Byte = 3
    Private Const Col1DifferenceAmount As Byte = 4
    Private Const Col1FeeReceiveDocId As Byte = 5
    Private Const Col1BtnAdjust As Byte = 6
    Private Const Col1FeeDue1List As Byte = 7
    Private Const Col1AmounntList As Byte = 8
    Private Const Col1FeeReceive1CodeList As Byte = 9
    Private Const Col1FeeAdjustedAmount As Byte = 10
    Private Const Col1SubCode As Byte = 11
    Private Const Col1IsAdjustFee As Byte = 12
    Private Const Col1RowId As Byte = 13

    Public mIsFeeAdjusted_Yes = "Yes"
    Public mIsFeeAdjusted_No = "No"

    Dim PaymentRec As AgLibrary.ClsMain.PaymentDetail = Nothing
    Dim mObjFrmPaymentDetail As AgLibrary.FrmPaymentDetail = Nothing

    Dim _FormType As eFormType
    Dim mBlnIsScholarshipAdjustmentEntry As Boolean = False

    Public Enum eFormType
        ScholarshipReceiveEntry
        ScholarshipAdjustmentEntry
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
            .AddAgTextColumn(DGL1, "DGL1AdmissionDocId", 340, 10, "Student Name", True, True, False)
            .AddAgNumberColumn(DGL1, "DGL1DemandAmount", 100, 8, 2, False, "Demand Amount", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1ReceiveAmount", 100, 8, 2, False, "Receive Amount", True, mBlnIsScholarshipAdjustmentEntry, True)
            .AddAgNumberColumn(DGL1, "DGL1DifferenceAmount", 100, 8, 2, False, "Difference Amount", True, True, True)
            .AddAgTextColumn(DGL1, "DGL1FeeReceiveDocId", 60, 10, "FeeReceiveDocId", False, True, False)
            .AddAgButtonColumn(DGL1, "BtnFeeReceipt", 50, "Adjust Fee", mBlnIsScholarshipAdjustmentEntry, False, , , , "Webdings", 10, "6")
            .AddAgTextColumn(DGL1, "Dgl1FeeDue1Str", 80, 50, "FeeDue1Str", False, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AmountStr", 240, 50, "AmountStr", False, True, False)
            .AddAgTextColumn(DGL1, "Dgl1FeeReceive1Str", 80, 50, "FeeReceive11Str", False, True, False)
            .AddAgNumberColumn(DGL1, "DGL1FeeReceiveAmount", 90, 8, 2, False, "FeeReceiveAmount", False, True, True)
            .AddAgTextColumn(DGL1, "Dgl1SubCode", 80, 50, "SubCode", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1IsAdjustFee", 80, 50, "Is Fee Adjusted?", mBlnIsScholarshipAdjustmentEntry, True, False)
            .AddAgNumberColumn(DGL1, "DGL1RowId", 90, 8, 0, False, "RowId", False, True, True)
        End With
        If _FormType = eFormType.ScholarshipReceiveEntry Then
            Pnl1.Width = 700
            Pnl1.Left = TxtV_Type.Left
            LblReceiveDetail.Left = Pnl1.Left
        End If
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False
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
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, TxtScholarshipAc.AgSelectedValue, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
                AgL.PubObjFrmPaymentDetail.ShowDialog()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec

                TxtReceiveAmount.Text = Format(Val(PaymentRec.TotalAmount), "0.00")

                'If Val(TxtReceiveAmount.Text) <> Val(TxtTotalReceiveAmount.Text) Then
                '    MsgBox("Receive Amount Is Not Equal To Rs. """ & Val(TxtTotalReceiveAmount.Text) & """")
                'End If

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
            AgL.WinSetting(Me, 650, 900, 0, 0)

            If _FormType = eFormType.ScholarshipAdjustmentEntry Then
                mBlnIsScholarshipAdjustmentEntry = True
            Else
                mBlnIsScholarshipAdjustmentEntry = False
            End If

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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Sr.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("Sr.Site_Code", AgL.PubSiteCode) & " "

            If _FormType = eFormType.ScholarshipAdjustmentEntry Then
                mCondStr += " And IsNull(Sr.ApprovedBy,'')<>'' "
            End If

            mQry = "Select Sr.DocId As SearchCode " & _
                    " From Sch_ScholarShipReceive Sr " & _
                    " LEFT JOIN Voucher_Type Vt ON Sr.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type Vt " & _
                  " Where Vt.NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ScholarshipReceive) & "" & _
                  " Order By Description"
            TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            'mQry = "Select Sd.DocId As Code, " & AgL.V_No_Field("Sd.DocId") & " As [Demand No], Sd.V_Date as DemandDate " & _
            '       " FROM Sch_ScholarShipDemand Sd " & _
            '       " Where " & AgL.PubSiteCondition("Sd.Site_Code", AgL.PubSiteCode) & " " & _
            '       " Order By Sd.V_Date "

            mQry = "SELECT D.DocId AS Code , " & AgL.V_No_Field("Max(D.DocId)") & " As [Demand No], " & _
                    " Max(V1.DemandDocId) As DemandDocId , Max(D.V_Date) as DemandDate , " & _
                    " IsNull(Sum(V1.TotalReceiveAmount),0) As TotalReceiveAmount, " & _
                    " IsNull(Max(D.TotalDemandAmount),0) As TotalDemandAmount " & _
                    " FROM Sch_ScholarShipDemand D " & _
                    " LEFT JOIN (SELECT R.DemandDocId , R.TotalReceiveAmount FROM Sch_ScholarShipReceive R ) AS V1 " & _
                    " ON D.DocId = V1.DemandDocId " & _
                    " Where " & AgL.PubSiteCondition("D.Site_Code", AgL.PubSiteCode) & " " & _
                    " GROUP BY D.DocId "

            TxtDemandDocId.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

            'mQry = "SELECT Vp.AdmissionDocId As Code, V1.StudentName As [Student Name], " & _
            '       " V1.AdmissionID, V1.Student As StudentCode, " & _
            '       " Vp.FromStreamYearSemester AS StreamYearSemesterCode, S.FamilyIncome, S.Category   " & _
            '       " FROM (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.PromotionDate IS NULL) Vp " & _
            '       " LEFT JOIN ViewSch_Admission V1 ON Vp.AdmissionDocId = V1.DocId " & _
            '       " LEFT JOIN Sch_Student S ON V1.Student = S.SubCode  " & _
            '       " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
            '       " Order By V1.StudentName "


            mQry = "Select V1.DocId As Code, V1.StudentName As [Student Name], " & _
                    " V1.AdmissionID, V1.Student As StudentCode " & _
                    " FROM ViewSch_Admission V1 " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By V1.StudentName "

            DGL1.AgHelpDataSet(Col1AdmissionDocId, 1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Sg.SubCode Code, Sg.Name " & _
                " FROM SubGroup Sg " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""
            TxtScholarshipAc.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbDelBackup()
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bFeeReceiveDocId$ = ""
        Dim bFeeReceiveDocIdArr() As String = Nothing
        Dim I As Integer = 0

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            If mSearchCode <> "" Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, TxtScholarshipAc.AgSelectedValue, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                    AgL.PubObjFrmPaymentDetail.DeletePaymentDetail(AgL.GCn, AgL.ECmd)
                    AgL.PubObjFrmPaymentDetail = Nothing

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    mQry = "DECLARE @bColumnStr NVARCHAR(MAX) " & _
                           " SET @bColumnStr = ''  " & _
                           " SELECT @bColumnStr = @bColumnStr +   " & _
                           " CASE WHEN  V1.FeeReceiveDocId IS NULL THEN  '' ELSE ',' + V1.FeeReceiveDocId END   " & _
                           " FROM " & _
                           " (SELECT FeeReceiveDocId  FROM Sch_ScholarShipReceive1 WITH (Nolock)" & _
                           " WHERE DocId ='" & mSearchCode & "' And FeeReceiveDocId is Not Null) AS V1 " & _
                           " SELECT CASE WHEN IsNull(@bColumnStr,'') <> ''  " & _
                           " THEN SubString(@bColumnStr,2, Len(@bColumnStr)-1) Else '' END  AS Header_GUID  "

                    bFeeReceiveDocId = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
                    bFeeReceiveDocIdArr = Split(bFeeReceiveDocId, ",")


                    AgL.Dman_ExecuteNonQry("Delete From Sch_ScholarShipReceive1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    For I = 0 To bFeeReceiveDocIdArr.Length - 1

                        AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, bFeeReceiveDocIdArr(I).ToString)

                        mQry = "DELETE FROM Sch_FeeReceive1 " & _
                                " WHERE DocId = " & AgL.Chk_Text(bFeeReceiveDocIdArr(I).ToString) & "  "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        mQry = "DELETE FROM Sch_FeeReceive " & _
                                " WHERE DocId = " & AgL.Chk_Text(bFeeReceiveDocIdArr(I).ToString) & "  "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    Next


                    AgL.Dman_ExecuteNonQry("Delete From Sch_ScholarShipReceive Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bFeeReceiveDocId$ = "", bEntryMode$ = AgLibrary.ClsConstant.EntryMode_Delete
        Dim bFeeReceiveDocIdArr() As String = Nothing
        Dim I As Integer = 0

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position


            If mSearchCode <> "" Then
                If _FormType = eFormType.ScholarshipReceiveEntry Then
                    If FunIsScholarshipAdjusted()  Then
                        MsgBox("Permission Denied!..." & vbCrLf & "Related Record Exists in Scholarship Adjustment Entry!...")
                        Exit Sub
                    End If
                End If

                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then
                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    If _FormType = eFormType.ScholarshipReceiveEntry Then
                        If TxtApproved.Text.Trim <> "" Then
                            bEntryMode = "U"

                            mQry = "Update Sch_ScholarShipReceiveDocIdDetail " & _
                                    " Set " & _
                                    " LedgerMDocId = Null " & _
                                    " Where DocId = '" & mSearchCode & "' "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                            mQry = "Update Sch_ScholarShipReceive Set ApprovedBy=Null, ApprovedDate=Null Where DocId='" & mSearchCode & "' "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            AgL.Dman_ExecuteNonQry("Delete From Sch_ScholarShipReceiveDocIdDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                            AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, TxtScholarshipAc.AgSelectedValue, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                            AgL.PubObjFrmPaymentDetail.DeletePaymentDetail(AgL.GCn, AgL.ECmd)
                            AgL.PubObjFrmPaymentDetail = Nothing

                            AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                            AgL.Dman_ExecuteNonQry("Delete From Sch_ScholarShipReceive1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                            AgL.Dman_ExecuteNonQry("Delete From Sch_ScholarShipReceive Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                        End If

                    ElseIf _FormType = eFormType.ScholarshipAdjustmentEntry Then
                        mQry = "DECLARE @bColumnStr NVARCHAR(MAX) " & _
                               " SET @bColumnStr = ''  " & _
                               " SELECT @bColumnStr = @bColumnStr +   " & _
                               " CASE WHEN  V1.FeeReceiveDocId IS NULL THEN  '' ELSE ',' + V1.FeeReceiveDocId END   " & _
                               " FROM " & _
                               " (SELECT FeeReceiveDocId  FROM Sch_ScholarShipReceive1 WITH (Nolock)" & _
                               " WHERE DocId ='" & mSearchCode & "' And FeeReceiveDocId is Not Null) AS V1 " & _
                               " SELECT CASE WHEN IsNull(@bColumnStr,'') <> ''  " & _
                               " THEN SubString(@bColumnStr,2, Len(@bColumnStr)-1) Else '' END  AS Header_GUID  "

                        bFeeReceiveDocId = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
                        bFeeReceiveDocIdArr = Split(bFeeReceiveDocId, ",")

                        mQry = "UPDATE dbo.Sch_ScholarShipReceive1 " & _
                                " SET FeeReceiveDocId = Null " & _
                                " WHERE DocId = '" & mSearchCode & "' "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        For I = 0 To bFeeReceiveDocIdArr.Length - 1
                            AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, bFeeReceiveDocIdArr(I).ToString)

                            mQry = "DELETE FROM Sch_FeeReceive1 " & _
                                    " WHERE DocId = " & AgL.Chk_Text(bFeeReceiveDocIdArr(I).ToString) & "  "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            mQry = "DELETE FROM Sch_FeeReceive " & _
                                    " WHERE DocId = " & AgL.Chk_Text(bFeeReceiveDocIdArr(I).ToString) & "  "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Next
                    End If


                    Call AgL.LogTableEntry(mSearchCode, Me.Text, bEntryMode, AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Sr.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                                 " And " & AgL.PubSiteCondition("Sr.Site_Code", AgL.PubSiteCode) & " "

            If _FormType = eFormType.ScholarshipAdjustmentEntry Then
                mCondStr += " And IsNull(Sr.ApprovedBy,'')<>'' "
            End If

            AgL.PubFindQry = "Select Sr.DocId As SearchCode, " & AgL.V_No_Field("Sr.DocId") & " As [Voucher No], " & _
                                " S.Name AS [Site Name], " & _
                                " " & AgL.V_No_Field("Sr.DemandDocId") & " As [Demand No],  Sr.TotalReceiveAmount, " & _
                                " Sr.PreparedBy, Sr.U_EntDt, Sr.Edit_Date, Sr.ModifiedBy, Sr.ApprovedBy, Sr.ApprovedDate " & _
                                " From Sch_ScholarShipReceive Sr " & _
                                " LEFT JOIN SiteMast S ON Sr.Site_Code = S.Code " & _
                                " " & mCondStr & " "
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

    Private Sub Topctrl_tbSaveBackup()
        Dim MastPos As Long
        Dim bSr As Integer = 0, I As Integer = 0, J As Integer = 0
        Dim mTrans As Boolean = False
        Dim bFeeDue1StrArr() As String = Nothing, bAmountStrArr() As String = Nothing, bFeeReceive1CodeStrArr() As String = Nothing
        Dim bFeeReceiveObj As New Struct_FeeReceive, bFeeReceive1Obj() As Struct_FeeReceive1 = Nothing
        Dim GcnRead As SqlClient.SqlConnection
        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_ScholarShipReceive(DocId, Div_Code, Site_Code, V_Date, V_Type, " & _
                        " V_Prefix, V_No, DemandDocId, TotalReceiveAmount, Remark, ScholarshipAc, PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtDemandDocId.AgSelectedValue) & ", " & _
                        " " & Val(TxtTotalReceiveAmount.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & AgL.Chk_Text(TxtScholarshipAc.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_ScholarShipReceive " & _
                        " SET  " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " DemandDocId = " & AgL.Chk_Text(TxtDemandDocId.AgSelectedValue) & ", " & _
                        " TotalReceiveAmount = " & Val(TxtReceiveAmount.Text) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " ScholarshipAc = " & AgL.Chk_Text(TxtScholarshipAc.AgSelectedValue) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & mSearchCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                mQry = "DELETE FROM Sch_ScholarShipReceive1 WHERE DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            bSr = 0
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1AdmissionDocId, I).Value <> "" Then
                        bSr += 1
                        mQry = "INSERT INTO Sch_ScholarShipReceive1(DocId, Sr, " & _
                                " AdmissionDocId, DemandAmount, ReceiveAmount, DifferenceAmount) " & _
                                " VALUES ('" & mSearchCode & "',	" & _
                                " " & Val(bSr) & ",	" & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & ", " & _
                                " " & Val(.Item(Col1DemandAmount, I).Value) & ", " & Val(.Item(Col1ReceiveAmount, I).Value) & "," & _
                                " " & Val(.Item(Col1DifferenceAmount, I).Value) & ")"

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        If .Item(Col1IsAdjustFee, I).Value = mIsFeeAdjusted_Yes Or .Item(Col1FeeReceiveDocId, I).Value <> "" Then
                            Call ProcCreateFeeReceiveStructure(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bFeeReceiveObj, bFeeReceive1Obj, I)
                            Call ProcSaveFeeReceiveDetail(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bFeeReceiveObj, bFeeReceive1Obj, I, .Item(Col1FeeReceiveDocId, I).Value, .Item(Col1IsAdjustFee, I).Value)
                            Call FunFeeReceiveAccountPosting(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bFeeReceiveObj, .Item(Col1IsAdjustFee, I).Value)

                            mQry = "UPDATE dbo.Sch_ScholarShipReceive1 " & _
                                    " SET FeeReceiveDocId = " & IIf(bFeeReceiveObj.DocId <> "", "'" & bFeeReceiveObj.DocId & "'", "NULL") & "" & _
                                    " WHERE DocId = '" & mSearchCode & "' And Sr = " & Val(bSr) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            AgL.UpdateVoucherCounter(bFeeReceiveObj.DocId, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                            Call AgL.LogTableEntry(bFeeReceiveObj.DocId, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, Me.Text)


                        End If
                    End If
                Next I
            End With

            AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, TxtScholarshipAc.AgSelectedValue, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
            AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
            If Not AgL.PubObjFrmPaymentDetail.SavePaymentDetail(PaymentRec, AgL.GCn, AgL.ECmd) Then Err.Raise(1, , "Save Error")

            Call AccountPosting()
            AgL.PubObjFrmPaymentDetail = Nothing

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

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim bSr As Integer = 0, I As Integer = 0, J As Integer = 0
        Dim mTrans As Boolean = False
        Dim bFeeDue1StrArr() As String = Nothing, bAmountStrArr() As String = Nothing, bFeeReceive1CodeStrArr() As String = Nothing
        Dim bFeeReceiveObj As New Struct_FeeReceive, bFeeReceive1Obj() As Struct_FeeReceive1 = Nothing
        Dim GcnRead As SqlClient.SqlConnection
        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If _FormType = eFormType.ScholarshipReceiveEntry Then
                If Topctrl1.Mode = "Add" Then
                    mQry = "INSERT INTO Sch_ScholarShipReceive(DocId, Div_Code, Site_Code, V_Date, V_Type, " & _
                            " V_Prefix, V_No, DemandDocId, TotalReceiveAmount, Remark, ScholarshipAc, PreparedBy, U_EntDt, U_AE) " & _
                            " VALUES ( " & _
                            " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                            " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                            " " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ", " & _
                            " " & AgL.Chk_Text(TxtDemandDocId.AgSelectedValue) & ", " & _
                            " " & Val(TxtTotalReceiveAmount.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & AgL.Chk_Text(TxtScholarshipAc.AgSelectedValue) & ", " & _
                            " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"

                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                Else
                    mQry = "Update Sch_ScholarShipReceive " & _
                            " SET  " & _
                            " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                            " DemandDocId = " & AgL.Chk_Text(TxtDemandDocId.AgSelectedValue) & ", " & _
                            " TotalReceiveAmount = " & Val(TxtReceiveAmount.Text) & ", " & _
                            " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                            " ScholarshipAc = " & AgL.Chk_Text(TxtScholarshipAc.AgSelectedValue) & ", " & _
                            " U_AE = 'E', " & _
                            " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                            " ModifiedBy = '" & AgL.PubUserName & "' " & _
                            " WHERE DocId = '" & mSearchCode & "' "                    
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If

                If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                    mQry = "DELETE FROM Sch_ScholarShipReceive1 WHERE DocId = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If
            End If

            bSr = 0
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1AdmissionDocId, I).Value <> "" Then
                        If _FormType = eFormType.ScholarshipReceiveEntry Then
                            bSr += 1
                            mQry = "INSERT INTO Sch_ScholarShipReceive1(DocId, Sr, " & _
                                    " AdmissionDocId, DemandAmount, ReceiveAmount, DifferenceAmount) " & _
                                    " VALUES ('" & mSearchCode & "',	" & _
                                    " " & Val(bSr) & ",	" & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & ", " & _
                                    " " & Val(.Item(Col1DemandAmount, I).Value) & ", " & Val(.Item(Col1ReceiveAmount, I).Value) & "," & _
                                    " " & Val(.Item(Col1DifferenceAmount, I).Value) & ")"

                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        ElseIf _FormType = eFormType.ScholarshipAdjustmentEntry Then
                            If .Item(Col1IsAdjustFee, I).Value = mIsFeeAdjusted_Yes Or .Item(Col1FeeReceiveDocId, I).Value <> "" Then
                                Call ProcCreateFeeReceiveStructure(AgL.GCn, AgL.ECmd, GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bFeeReceiveObj, bFeeReceive1Obj, I)
                                Call ProcSaveFeeReceiveDetail(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bFeeReceiveObj, bFeeReceive1Obj, I, .Item(Col1FeeReceiveDocId, I).Value, .Item(Col1IsAdjustFee, I).Value)
                                Call FunFeeReceiveAccountPosting(AgL.GCn, AgL.ECmd, AgL.GcnRead, AgL.Gcn_ConnectionString, Topctrl1.Mode, bFeeReceiveObj, .Item(Col1IsAdjustFee, I).Value)

                                mQry = "UPDATE dbo.Sch_ScholarShipReceive1 " & _
                                        " SET FeeReceiveDocId = " & IIf(bFeeReceiveObj.DocId <> "", "'" & bFeeReceiveObj.DocId & "'", "NULL") & "" & _
                                        " WHERE DocId = '" & mSearchCode & "' And RowId = " & Val(.Item(Col1RowId, I).Value) & " "
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                                AgL.UpdateVoucherCounter(bFeeReceiveObj.DocId, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                                Call AgL.LogTableEntry(bFeeReceiveObj.DocId, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, Me.Text)
                            End If
                        End If

                    End If
                Next I
            End With

            If _FormType = eFormType.ScholarshipReceiveEntry Then
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, TxtScholarshipAc.AgSelectedValue, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
                If Not AgL.PubObjFrmPaymentDetail.SavePaymentDetail(PaymentRec, AgL.GCn, AgL.ECmd) Then Err.Raise(1, , "Save Error")
                mObjFrmPaymentDetail = AgL.PubObjFrmPaymentDetail
                AgL.PubObjFrmPaymentDetail = Nothing

                If Topctrl1.Mode = "Add" Then
                    mQry = "INSERT INTO Sch_ScholarShipReceiveDocIdDetail ( DocId, PaymentDetailDocId ) VALUES ( " & _
                            " '" & mSearchCode & "', '" & mSearchCode & "')"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If
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
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing, DsTemp1 As DataSet = Nothing
        Dim MastPos As Long
        Dim mTransFlag As Boolean = False, bBlnDeleteFlag As Boolean = False
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
                mQry = "Select Sr.*, Vt.NCat " & _
                        " From Sch_ScholarShipReceive Sr " & _
                        " Left Join Voucher_Type Vt On Sr.V_Type = Vt.V_Type " & _
                        " Where Sr.DocId='" & mSearchCode & "'"

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

                        TxtDemandDocId.AgSelectedValue = AgL.XNull(.Rows(0)("DemandDocId"))
                        LblDemandDocId.Tag = AgL.XNull(.Rows(0)("DemandDocId"))

                        TxtReceiveAmount.Text = Format(AgL.VNull(.Rows(0)("TotalReceiveAmount")), "0.00")
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtScholarshipAc.AgSelectedValue = AgL.XNull(.Rows(0)("ScholarshipAc"))

                        TxtApproved.Text = AgL.XNull(.Rows(0)("ApprovedBy"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With


                mQry = "SELECT Sr1.*, Va.Student As SubCode " & _
                        " FROM Sch_ScholarShipReceive1 Sr1 " & _
                        " LEFT JOIN Viewsch_Admission Va On Sr1.AdmissionDocId = Va.DocId " & _
                        " Where Sr1.DocId='" & mSearchCode & "' " & _
                        " ORDER BY Va.StudentName "

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                            DGL1.Item(Col1DemandAmount, I).Value = Format(AgL.VNull(.Rows(I)("DemandAmount")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1ReceiveAmount, I).Value = Format(AgL.VNull(.Rows(I)("ReceiveAmount")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1DifferenceAmount, I).Value = Format(AgL.VNull(.Rows(I)("DifferenceAmount")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1FeeReceiveDocId, I).Value = AgL.XNull(.Rows(I)("FeeReceiveDocId"))
                            DGL1.Item(Col1SubCode, I).Value = AgL.XNull(.Rows(I)("SubCode"))
                            DGL1.Item(Col1IsAdjustFee, I).Value = IIf(AgL.XNull(.Rows(I)("FeeReceiveDocId")) <> "", mIsFeeAdjusted_Yes, mIsFeeAdjusted_No)
                            DGL1.Item(Col1RowId, I).Value = AgL.VNull(.Rows(I)("RowId"))

                            mQry = "DECLARE @bColumnStr1 NVARCHAR(MAX) " & _
                                    " DECLARE @bColumnStr2 NVARCHAR(MAX)      " & _
                                    " DECLARE @bColumnStr3 NVARCHAR(MAX) " & _
                                    " DECLARE @bColumnStr4 FLOAT " & _
                                    " SET @bColumnStr1 = ''  " & _
                                    " SET @bColumnStr2 = ''   " & _
                                    " SET @bColumnStr3 = ''       " & _
                                    " SET @bColumnStr4 = 0 " & _
                                    " SELECT  " & _
                                    " @bColumnStr1 = @bColumnStr1 +        " & _
                                    " CASE WHEN  V1.FeeReceive1Code IS NULL THEN  '' ELSE ',' + V1.FeeReceive1Code  END,     " & _
                                    " @bColumnStr2 = @bColumnStr2 +   " & _
                                    " CASE WHEN  V1.FeeDue1 IS NULL THEN  '' ELSE ',' + V1.FeeDue1  END ,     " & _
                                    " @bColumnStr3 = @bColumnStr3 +      " & _
                                    " CASE WHEN V1.NetAmount IS NULL THEN  '' ELSE ',' + V1.NetAmount  END, " & _
                                    " @bColumnStr4 = V1.TotalReceiveAmount " & _
                                    " FROM " & _
                                    " (SELECT Fr.TotalLineNetAmount AS TotalReceiveAmount, Fr1.Code AS FeeReceive1Code,  " & _
                                    " Fr1.FeeDue1, convert(NVARCHAR,  Fr1.NetAmount) AS NetAmount " & _
                                    " FROM Sch_FeeReceive Fr " & _
                                    " LEFT JOIN Sch_FeeReceive1  Fr1 ON Fr.DocId = Fr1.DocId   " & _
                                    " WHERE Fr.DocId = '" & DGL1.Item(Col1FeeReceiveDocId, I).Value & "' ) AS V1      " & _
                                    " SELECT CASE WHEN IsNull(@bColumnStr1,'') <> ''   " & _
                                    " THEN SubString(@bColumnStr1,2, Len(@bColumnStr1)-1) Else '' END  AS FeeReceive1CodeList,     " & _
                                    " CASE WHEN IsNull(@bColumnStr2,'') <> ''       " & _
                                    " THEN SubString(@bColumnStr2,2, Len(@bColumnStr2)-1) Else '' END  AS FeeDue1List,     " & _
                                    " CASE WHEN IsNull(@bColumnStr3,'') <> ''       " & _
                                    " THEN SubString(@bColumnStr3,2, Len(@bColumnStr3)-1) Else '' END  AS NetAmountList , " & _
                                    " @bColumnStr4 AS TotalReceiveAmount  "

                            DsTemp1 = AgL.FillData(mQry, AgL.GCn)

                            DGL1.Item(Col1FeeDue1List, I).Value = AgL.XNull(DsTemp1.Tables(0).Rows(0)("FeeDue1List"))
                            DGL1.Item(Col1AmounntList, I).Value = AgL.XNull(DsTemp1.Tables(0).Rows(0)("NetAmountList"))
                            DGL1.Item(Col1FeeReceive1CodeList, I).Value = AgL.XNull(DsTemp1.Tables(0).Rows(0)("FeeReceive1CodeList"))
                            DGL1.Item(Col1FeeAdjustedAmount, I).Value = Format(AgL.VNull(DsTemp1.Tables(0).Rows(0)("TotalReceiveAmount")), "0.00")

                        Next I
                    End If
                End With


                'Payment Detail Moverec Common
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, TxtScholarshipAc.AgSelectedValue, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                AgL.PubObjFrmPaymentDetail.FillPaymentRec()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec
                mObjFrmPaymentDetail = AgL.PubObjFrmPaymentDetail
                AgL.PubObjFrmPaymentDetail = Nothing

                'Code For Calculating Totals
                With DGL1
                    For I = 0 To .Rows.Count - 1
                        If .Item(Col1AdmissionDocId, I).Value <> "" Then
                            TxtTotalReceiveAmount.Text = Format(Val(TxtTotalReceiveAmount.Text) + Val(.Item(Col1ReceiveAmount, I).Value), "0.00")
                        End If
                    Next
                End With
                'End Code

            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                bBlnDeleteFlag = False

                If _FormType = eFormType.ScholarshipReceiveEntry Then
                    If TxtApproved.Text.Trim <> "" Then
                        If Not FunIsScholarshipAdjusted() Then
                            bBlnDeleteFlag = AgL.FunHaveControlPermission(Academic_Objects.ClsConstant.Module_Academic_Fee, Me.Text, AgL.PubUserName, GroupBox1.Text)
                        End If

                        mTransFlag = True
                        BtnApproved.Enabled = False

                    Else
                        BtnApproved.Enabled = GroupBox1.Enabled
                    End If
                End If

                If mTransFlag Then
                    Topctrl1.tEdit = False
                    Topctrl1.tDel = bBlnDeleteFlag
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
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = ""
        PaymentRec = Nothing : mObjFrmPaymentDetail = Nothing
        LblDemandDocId.Tag = ""

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
        TxtDocId.ReadOnly = True
        TxtTotalReceiveAmount.ReadOnly = True

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
            TxtDemandDocId.Enabled = False
            BtnFillStudents.Enabled = False
        End If

        If _FormType = eFormType.ScholarshipAdjustmentEntry Then
            Topctrl1.tAdd = False
            BtnFillStudents.Enabled = False

            GroupBox1.Visible = False
            TxtRemark.Visible = False
            LblRemark.Visible = False
            BtnFillStudents.Visible = False

            If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                TxtV_Date.Enabled = False
                TxtScholarshipAc.Enabled = False
                TxtReceiveAmount.Enabled = False
                TxtRemark.Enabled = False
            End If
        ElseIf _FormType = eFormType.ScholarshipReceiveEntry Then
            GroupBox1.Visible = True
            TxtRemark.Visible = True
            LblRemark.Visible = True
            BtnFillStudents.Visible = True
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
        TxtV_Type.Enter, TxtDemandDocId.Enter, TxtV_Date.Enter
        Try
            Select Case sender.name
                Case TxtDemandDocId.Name
                    TxtDemandDocId.AgRowFilter = "(DemandDate <= " & AgL.Chk_Text(TxtV_Date.Text) & " And TotalReceiveAmount < TotalDemandAmount) Or Code  = '" & LblDemandDocId.Tag & "' "

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtDocId.Validating, TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_Date.Validating, TxtV_No.Validating, _
        TxtDemandDocId.Validating

        Dim DtTemp As DataTable = Nothing
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
                    TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text.ToString)

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
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub
        TxtTotalReceiveAmount.Text = 0
        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1DemandAmount, I).Value Is Nothing Then .Item(Col1DemandAmount, I).Value = ""
                If .Item(Col1ReceiveAmount, I).Value Is Nothing Then .Item(Col1ReceiveAmount, I).Value = ""
                If .Item(Col1DifferenceAmount, I).Value Is Nothing Then .Item(Col1DifferenceAmount, I).Value = ""
                If .Item(Col1AdmissionDocId, I).Value <> "" Then
                    .Item(Col1DifferenceAmount, I).Value = Format(Val(.Item(Col1DemandAmount, I).Value) - Val(.Item(Col1ReceiveAmount, I).Value), "0.00")
                    TxtTotalReceiveAmount.Text = Format(Val(TxtTotalReceiveAmount.Text) + Val(.Item(Col1ReceiveAmount, I).Value), "0.00")
                End If
            Next
        End With
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If AgL.RequiredField(TxtDemandDocId, "Deman No.") Then Exit Function

            If AgCL.AgIsBlankGrid(DGL1, Col1AdmissionDocId) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1AdmissionDocId & "") Then Exit Function

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1AdmissionDocId, I).Value <> "" Then
                        If Val(.Item(Col1ReceiveAmount, I).Value) < Val(.Item(Col1FeeAdjustedAmount, I).Value) Then
                            MsgBox("Scholarship Amount Is Less Than Adjusted Amount At Row No """ & DGL1.Item(Col_SNo, I).Value & """  ", MsgBoxStyle.Information)
                            DGL1.CurrentCell = DGL1.Item(Col1ReceiveAmount, I) : Exit Function
                        End If
                    End If
                Next
            End With

            If Val(TxtReceiveAmount.Text) <> Val(TxtTotalReceiveAmount.Text) Then
                MsgBox("Total Amount Is Not Equal To Total receive Amount", MsgBoxStyle.Information) : Exit Function
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

        BtnFillStudents.Enabled = True

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


    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1AdmissionDocId
                    DGL1.AgRowFilter(Col1AdmissionDocId) = " StreamYearSemesterCode = '" & TxtDemandDocId.AgSelectedValue & "'"
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
        Dim DsTemp As DataSet = Nothing
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .CurrentCell.ColumnIndex
                    Case Col1AdmissionDocId
                        'If DGL1.AgSelectedValue(Col1AdmissionDocId, mRowIndex) = "" And DGL1.Item(Col1AdmissionDocId, mRowIndex).Value = "" Then
                        '    DGL1.Item(Col1FamilyIncome, mRowIndex).Value = ""
                        'Else
                        '    If DGL1.AgHelpDataSet(Col1AdmissionDocId) IsNot Nothing Then
                        '        DrTemp = DGL1.AgHelpDataSet(Col1AdmissionDocId).Tables(0).Select("Code = " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, mRowIndex)) & "")
                        '        DGL1.Item(Col1FamilyIncome, mRowIndex).Value = Format(AgL.VNull(DrTemp(0)("FamilyIncome")), "0.00")
                        '    End If
                        'End If
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

    Private Sub ProcFillStudents()
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer = 0
        Dim bTotalAmount As Double = 0
        Try

            If AgL.RequiredField(TxtReceiveAmount) Then Exit Sub
            bTotalAmount = Val(TxtReceiveAmount.Text)
            mQry = "SELECT Sd1.AdmissionDocId, Sd1.DemandAmount, Va.Student as SubCode, '" & mIsFeeAdjusted_No & "' as IsFeeAdjusted   " & _
                    " FROM Sch_ScholarShipDemand1 Sd1	 " & _
                    " LEFT JOIN ViewSch_Admission va ON Sd1.AdmissionDocId = va.DocId " & _
                    " WHERE Sd1.DocId = '" & TxtDemandDocId.AgSelectedValue & "' " & _
                    " ORDER BY va.studentname "

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL1.RowCount = 1
                DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL1.Item(Col1DemandAmount, I).Value = Format(AgL.VNull(.Rows(I)("DemandAmount")), "0.".PadRight(2 + 2, "0"))
                        'DGL1.Item(Col1ReceiveAmount, I).Value = Format(AgL.VNull(.Rows(I)("DemandAmount")), "0.".PadRight(2 + 2, "0"))
                        DGL1.Item(Col1ReceiveAmount, I).Value = Format(IIf(Val(bTotalAmount) > AgL.VNull(.Rows(I)("DemandAmount")), AgL.VNull(.Rows(I)("DemandAmount")), bTotalAmount), "0.00")
                        bTotalAmount = IIf(bTotalAmount - AgL.VNull(.Rows(I)("DemandAmount")) >= 0, bTotalAmount - AgL.VNull(.Rows(I)("DemandAmount")), 0)
                        DGL1.Item(Col1SubCode, I).Value = AgL.XNull(.Rows(I)("SubCode"))
                        DGL1.Item(Col1IsAdjustFee, I).Value = AgL.XNull(.Rows(I)("IsFeeAdjusted"))
                    Next I
                Else
                    MsgBox("No Records Exists", MsgBoxStyle.Information)
                End If
            End With
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFillStudents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillStudents.Click
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Try
            Select Case sender.name
                Case BtnFillStudents.Name
                    Call ProcFillStudents()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer = 0, J As Integer = 0
        Dim mNarr As String = "", mCommonNarr$ = "", bContraSub$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        
        mCommonNarr = TxtRemark.Text
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        If AgL.PubObjFrmPaymentDetail.AccountPosting(PaymentRec, AgL.GCn, AgL.Gcn_ConnectionString, AgL.ECmd, LedgAry, mCommonNarr) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

    End Function

    Private Sub DGL1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellContentClick
        Dim FrmObj As Form
        Dim DtTemp As DataSet = Nothing
        Dim I As Integer = 0
        Dim bTotalAmt As Double = 0
        Dim bFeeDue1Str As String = "", bAmountStr As String = "", bQry As String = ""
        Dim bFeeDue1StrArr() As String = Nothing, bAmountStrArr() As String = Nothing
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1BtnAdjust
                    If DGL1.Item(Col1FeeReceiveDocId, mRowIndex).Value = "" Then
                        'bQry = "SELECT VFd.FeeDue1Code, VFd.NetBalance + IsNull(V1.ReceiveAmount,0) As NetBalance " & _
                        '        " FROM ViewSch_FeeDue VFd " & _
                        '        " Left Join (SELECT Fr1.FeeDue1 AS FeeDue1Code, IsNULL(Sum(Fr1.Amount),0) AS ReceiveAmount, IsNULL(Sum(Fr1.Discount),0) AS Discount, IsNULL(Sum(Fr1.NetAmount),0) AS NetReceiveAmount FROM dbo.Sch_FeeReceive1 Fr1 Where Fr1.DocId = " & AgL.Chk_Text(IIf(Topctrl1.Mode = "Add", "", mSearchCode)) & "  GROUP BY Fr1.FeeDue1 ) V1 On VFd.FeeDue1Code = V1.FeeDue1Code " & _
                        '        " WHERE VFd.NetBalance + IsNull(V1.ReceiveAmount,0) > 0 " & _
                        '        " AND VFd.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " " & _
                        '        " AND IsNull(Vfd.IsReversePosted,0) = 0 " & _
                        '        " AND VFd.AdmissionDocId = " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1AdmissionDocId, mRowIndex)) & " " & _
                        '        " Order By Vfd.V_Date "

                        bQry = "SELECT VFd.FeeDue1Code, VFd.NetBalance As NetBalance " & _
                                " FROM ViewSch_FeeDue VFd " & _
                                " WHERE VFd.NetBalance > 0 " & _
                                " AND VFd.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " " & _
                                " AND IsNull(Vfd.IsReversePosted,0) = 0 " & _
                                " AND VFd.AdmissionDocId = " & AgL.Chk_Text(DGL1.AgSelectedValue(Col1AdmissionDocId, mRowIndex)) & " " & _
                                " Order By Vfd.V_Date "
                        DtTemp = AgL.FillData(bQry, AgL.GCn)

                        If DtTemp.Tables(0).Rows.Count = 0 Then
                            If MsgBox("No Due Exists To Receive!..." + vbCrLf + "Do You Want To Take Advance ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then
                                DGL1.Item(Col1IsAdjustFee, mRowIndex).Value = mIsFeeAdjusted_Yes
                            Else
                                DGL1.Item(Col1IsAdjustFee, mRowIndex).Value = mIsFeeAdjusted_No
                            End If
                            Exit Sub
                        End If
                    End If

                    If DGL1.Item(Col1FeeDue1List, mRowIndex).Value Is Nothing Then DGL1.Item(Col1FeeDue1List, mRowIndex).Value = ""
                    If DGL1.Item(Col1AmounntList, mRowIndex).Value Is Nothing Then DGL1.Item(Col1AmounntList, mRowIndex).Value = ""

                    bFeeDue1StrArr = Split(DGL1.Item(Col1FeeDue1List, mRowIndex).Value.ToString, ",")

                    FrmObj = New FrmScholarshipAdjustHeadWise()
                    If FrmObj IsNot Nothing Then
                        CType(FrmObj, FrmScholarshipAdjustHeadWise).FeeDue1Str = DGL1.Item(Col1FeeDue1List, mRowIndex).Value
                        CType(FrmObj, FrmScholarshipAdjustHeadWise).AmountStr = DGL1.Item(Col1AmounntList, mRowIndex).Value
                        CType(FrmObj, FrmScholarshipAdjustHeadWise).ScholarshipAmt = Val(DGL1.Item(Col1ReceiveAmount, mRowIndex).Value)
                        CType(FrmObj, FrmScholarshipAdjustHeadWise).DueQry = bQry
                    End If
                    FrmObj.StartPosition = FormStartPosition.CenterScreen

                    FrmObj.ShowDialog()

                    With CType(FrmObj, FrmScholarshipAdjustHeadWise).DGL1
                        For I = 0 To .Rows.Count - 1
                            If .Item(1, I).Value <> "" And Val(.Item(2, I).Value) <> 0 Then
                                bFeeDue1Str += IIf(bFeeDue1Str.Trim = "", .AgSelectedValue(1, I), "," + .AgSelectedValue(1, I))
                                bAmountStr += .Item(2, I).Value + ","
                                bTotalAmt += .Item(2, I).Value
                            End If
                        Next
                    End With
                    DGL1.Item(Col1FeeDue1List, mRowIndex).Value = bFeeDue1Str
                    DGL1.Item(Col1AmounntList, mRowIndex).Value = bAmountStr
                    DGL1.Item(Col1FeeAdjustedAmount, mRowIndex).Value = bTotalAmt

                    If bFeeDue1Str.ToString.Trim <> "" Then
                        DGL1.Item(Col1IsAdjustFee, mRowIndex).Value = mIsFeeAdjusted_Yes
                    Else
                        DGL1.Item(Col1IsAdjustFee, mRowIndex).Value = mIsFeeAdjusted_No
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcCreateFeeReceiveStructure(ByVal bConn As SqlConnection, ByVal bCmd As SqlCommand, _
                                              ByVal bConnRead As SqlClient.SqlConnection, _
                                              ByVal bConnectionString As String, ByVal bEntryMode As String, _
                                              ByRef bFeeReceiveObj As Struct_FeeReceive, _
                                              ByRef bFeeReceive1Obj() As Struct_FeeReceive1, _
                                              ByVal bRowIndex As Integer)

        Dim J As Integer, mFlagBln As Boolean = False
        Dim bSite_Code$ = "", bDiv_Code$ = "", bV_Type$ = "", bV_Prefix$ = "", bV_No As Long = 0, bV_Date$ = "", bSearchCode$ = ""
        Dim bTotalAmount As Double = 0
        Dim bQry$ = ""
        Dim bFeeDue1StrArr() As String = Nothing, bAmountStrArr() As String = Nothing, bFeeReceive1CodeStrArr() As String = Nothing

        bSite_Code = TxtSite_Code.AgSelectedValue
        bDiv_Code = AgL.PubDivCode
        bV_Date = Format(TxtV_Date.Text, "Short Date")

        If DGL1.Item(Col1FeeReceiveDocId, bRowIndex).Value = "" And bV_Date.Trim <> "" And bSite_Code.Trim <> "" Then
            bQry = "Select Vt.V_Type " & _
                    " From Voucher_Type Vt With (NoLock) " & _
                    " Where Vt.NCat = '" & Academic_ProjLib.ClsMain.NCat_FeeReceiveAdjustment & "' "

            bV_Type = AgL.XNull(AgL.Dman_Execute(bQry, bConnRead).ExecuteScalar)
            bSearchCode = AgL.GetDocId(bV_Type, CStr(bV_No), CDate(bV_Date), bConnRead, bDiv_Code, bSite_Code)
        Else
            bSearchCode = DGL1.Item(Col1FeeReceiveDocId, bRowIndex).Value
            bV_Type = AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherType)
        End If

        If bSearchCode.Trim = "" Then Err.Raise(1, , "Error in Fee Receive Search Code Generation!...")

        bV_No = Val(AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        bV_Prefix = AgL.DeCodeDocID(bSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)


        If DGL1.Item(Col1FeeDue1List, bRowIndex).Value <> "" Then bFeeDue1StrArr = Split(DGL1.Item(Col1FeeDue1List, bRowIndex).Value.ToString, ",")
        If DGL1.Item(Col1AmounntList, bRowIndex).Value <> "" Then bAmountStrArr = Split(DGL1.Item(Col1AmounntList, bRowIndex).Value.ToString, ",")
        If DGL1.Item(Col1FeeReceive1CodeList, bRowIndex).Value <> "" Then bFeeReceive1CodeStrArr = Split(DGL1.Item(Col1FeeReceive1CodeList, bRowIndex).Value.ToString, ",")

        If bFeeDue1StrArr IsNot Nothing Then
            For J = 0 To bFeeDue1StrArr.Length - 1
                If mFlagBln = False Then
                    J = 0
                    mFlagBln = True
                Else
                    J = UBound(bFeeReceive1Obj) + 1
                End If
                ReDim Preserve bFeeReceive1Obj(J)
                If bFeeReceive1CodeStrArr IsNot Nothing Then bFeeReceive1Obj(J).Code = bFeeReceive1CodeStrArr(J)
                bFeeReceive1Obj(J).DocId = mSearchCode
                bFeeReceive1Obj(J).FeeDue1 = bFeeDue1StrArr(J)
                bFeeReceive1Obj(J).Amount = Val(bAmountStrArr(J))
                bFeeReceive1Obj(J).NetAmount = Val(bAmountStrArr(J))
            Next
        Else
            bFeeReceive1Obj = Nothing
        End If

        With bFeeReceiveObj
            .DocId = bSearchCode
            .Div_Code = AgL.PubDivCode
            .Site_Code = TxtSite_Code.AgSelectedValue
            .V_Date = TxtV_Date.Text
            .V_Type = bV_Type
            .V_Prefix = bV_Prefix
            .V_No = Val(bV_No)
            .TotalLineAmount = Val(DGL1.Item(Col1FeeAdjustedAmount, bRowIndex).Value)
            .TotalLineDiscount = 0
            .TotalLineNetAmount = Val(DGL1.Item(Col1FeeAdjustedAmount, bRowIndex).Value) - .TotalLineDiscount
            .SubTotal1 = Val(.TotalLineNetAmount)
            .ScholarShipAmount = Val(DGL1.Item(Col1ReceiveAmount, bRowIndex).Value)
            .SubTotal2 = Val(.SubTotal1) - Val(.ScholarShipAmount)
            .DiscountAmount = 0
            .TotalNetAmount = Val(.SubTotal2) - Val(.DiscountAmount)

            If Val(.ScholarShipAmount) > Val(.SubTotal1) Then
                .AdvanceCarriedForward = Val(.ScholarShipAmount) - Val(.SubTotal1)
                .IsManageFee = 0
            Else
                .AdvanceCarriedForward = 0
                .IsManageFee = 1
            End If


            .AdmissionDocId = DGL1.AgSelectedValue(Col1AdmissionDocId, bRowIndex)
            .SubCode = DGL1.Item(Col1SubCode, bRowIndex).Value
            .ScholarShipAmount = Val(DGL1.Item(Col1ReceiveAmount, bRowIndex).Value)
            .Remark = "Scholarship Adjusted"
        End With
    End Sub

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


                            Call ProcApproveVoucher(TxtApproved.Text, mApprovedDate)

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

    Private Sub ProcApproveVoucher(ByVal StrApprovedBy As String, ByVal StrApprovedDate As String)

        mQry = "Update Sch_ScholarShipReceive Set ApprovedBy='" & StrApprovedBy & "', ApprovedDate=" & AgL.Chk_Text(StrApprovedDate) & " Where DocId='" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = "Update Sch_ScholarShipReceiveDocIdDetail " & _
                " Set " & _
                " LedgerMDocId = Null " & _
                " Where DocId = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        AgL.PubObjFrmPaymentDetail = mObjFrmPaymentDetail
        Call AccountPosting()

        mQry = "Update Sch_ScholarShipReceiveDocIdDetail " & _
                " Set " & _
                " LedgerMDocId = '" & mSearchCode & "' " & _
                " Where DocId = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


        Call AgL.LogTableEntry(mSearchCode, Me.Text, AgLibrary.ClsConstant.EntryMode_Varified, AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , TxtV_Date.Text, , , Val(TxtReceiveAmount.Text), TxtSite_Code.AgSelectedValue, AgL.PubDivCode)
    End Sub


    Private Function FunIsScholarshipAdjusted() As Boolean
        Dim bBlnReturnFlag As Boolean = False

        mQry = "SELECT IsNull(Count(*),0) AS Cnt " & _
                " FROM Sch_ScholarShipReceive1 SRecv1 With (NoLock) " & _
                " WHERE SRecv1.FeeReceiveDocId IS NOT NULL "
        If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
            bBlnReturnFlag = True
        Else
            bBlnReturnFlag = False
        End If

        Return bBlnReturnFlag
    End Function

    End Class
