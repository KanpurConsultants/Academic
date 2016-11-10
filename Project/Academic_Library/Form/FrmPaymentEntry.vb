Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmPaymentEntry
    Inherits AgTemplate.TempPayment
    
    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.Payment
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(146, 247)
        Me.Pnl2.Size = New System.Drawing.Size(586, 217)
        '
        'TxtChqDate
        '
        Me.TxtChqDate.Location = New System.Drawing.Point(533, 131)
        '
        'LblChqDate
        '
        Me.LblChqDate.Location = New System.Drawing.Point(425, 129)
        '
        'TxtChqNo
        '
        Me.TxtChqNo.Location = New System.Drawing.Point(319, 131)
        '
        'LblChqNo
        '
        Me.LblChqNo.Location = New System.Drawing.Point(200, 132)
        '
        'TxtCashBank
        '
        Me.TxtCashBank.Location = New System.Drawing.Point(533, 111)
        '
        'LblCashBank
        '
        Me.LblCashBank.Location = New System.Drawing.Point(425, 110)
        '
        'LblSubCodeReq
        '
        Me.LblSubCodeReq.Location = New System.Drawing.Point(303, 57)
        '
        'TxtSubCode
        '
        Me.TxtSubCode.Location = New System.Drawing.Point(319, 51)
        '
        'LblSUbCode
        '
        Me.LblSUbCode.Location = New System.Drawing.Point(200, 52)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(319, 151)
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(200, 152)
        '
        'TxtNetAmount
        '
        Me.TxtNetAmount.BackColor = System.Drawing.Color.White
        Me.TxtNetAmount.Location = New System.Drawing.Point(533, 91)
        Me.TxtNetAmount.ReadOnly = True
        '
        'LblNetAmount
        '
        Me.LblNetAmount.Location = New System.Drawing.Point(425, 91)
        '
        'TxtPaidAmount
        '
        Me.TxtPaidAmount.Location = New System.Drawing.Point(533, 71)
        '
        'LblPaidAmount
        '
        Me.LblPaidAmount.Location = New System.Drawing.Point(425, 72)
        '
        'TxtCurrBalance
        '
        Me.TxtCurrBalance.Location = New System.Drawing.Point(319, 71)
        '
        'lblCurrBalance
        '
        Me.lblCurrBalance.Location = New System.Drawing.Point(200, 72)
        '
        'TxtDiscount
        '
        Me.TxtDiscount.Location = New System.Drawing.Point(319, 91)
        '
        'LblDiscount
        '
        Me.LblDiscount.Location = New System.Drawing.Point(200, 92)
        '
        'TxtCashBankAc
        '
        Me.TxtCashBankAc.Location = New System.Drawing.Point(319, 111)
        '
        'LblCashBankAc
        '
        Me.LblCashBankAc.Location = New System.Drawing.Point(200, 112)
        '
        'LblPaidAmountReq
        '
        Me.LblPaidAmountReq.Location = New System.Drawing.Point(517, 78)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(425, 32)
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(533, 31)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(303, 37)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(200, 32)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(517, 17)
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(319, 31)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(425, 13)
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(533, 11)
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(303, 17)
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(200, 12)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Location = New System.Drawing.Point(319, 11)
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(485, 32)
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(-3, 19)
        '
        'FrmPaymentEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(879, 515)
        Me.LogLineTableCsv = "DuesPaymentDetail_Log"
        Me.LogTableName = "DuesPayment_Log"
        Me.MainLineTableCsv = "DuesPaymentDetail"
        Me.MainTableName = "DuesPayment"
        Me.Name = "FrmPaymentEntry"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region

    Private Sub FrmPaymentEntry_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgL.PubDtEnviro.Rows.Count > 0 Then
            If AgL.VNull(AgL.PubDtEnviro.Rows(0)("IsLinkWithFA")) <> 0 Then
                If AgL.RequiredField(TxtCashBankAc, LblCashBankAc.Text) Then passed = False : Exit Sub
            End If
        End If
    End Sub
    Private Sub FrmPaymentEntry_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Money Receipt/Payment"
            RepName = "Lib_MoneyReceiptPayment_Print" : RepTitle = AgL.PubReportTitle
            bCondstr = "WHERE H.DocID='" & mInternalCode & "'"


            strQry = " SELECT  H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code,     " & _
                    " H.SubCode, H.CurrBalance, H.PaidAmount,H.Discount,H.NetAmount,H.CashBank,H.CashBankAc, " & _
                    " H.ChqNo,H.ChqDate,H.Remark,H.TransactionType,  H.PartyName,H.PartyAddress,H.PartyCity, " & _
                    " DP.ReferenceDocID,DP.Amount AS LogAmount,DP.CurrBalance AS logCurrBalance,DP.PaidAmount AS LogPaidAmt, " & _
                    " DP.Discount AS LogDiscount,DP.NetAmount AS LogNetAmount,DV.Div_Name AS Division, " & _
                    " SM.Name AS SiteName,SG.Name AS PartyName ,B.Name AS Bank, IsNull(D.ReceivableAmount,0) AS BillAmount,IsNull(D.AdjustedAmount,0) AS PaidAmt," & _
                    " D.V_Type  + '-' + convert(NVARCHAR, D.V_No) as DueNo," & AgL.V_No_Field("H.DocID") & " as DocID_Print" & _
                    " FROM DuesPayment H " & _
                    " LEFT JOIN DuesPaymentDetail DP WITH (NoLock) ON Dp.DocId=H.DocID   " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN Division DV ON DV.Div_Code =H.Div_Code   " & _
                    " LEFT JOIN SubGroup SG WITH (NoLock) ON DP.SubCode=SG.SubCode   " & _
                    " Left Join SubGroup b WITH (NoLock) on DP.CashBankAc =b.SubCode   " & _
                    " LEFT JOIN dues D ON Dp.ReferenceDocID + Convert(VARCHAR,Dp.Reference_Sr) = D.DocID + Convert(VARCHAR,D.Sr)    " & _
                    " LEFT JOIN Voucher_Type Vt ON Vt.V_Type= H.V_Type  " & _
                    " " & bCondstr & ""

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)
            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            AgPL.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrmBookQuatation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 547, 885, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub
End Class
