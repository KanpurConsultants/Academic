Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmDonatedBookIssue
    Inherits TempBookIssue

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.DonatedBookIssue
    End Sub

    Private Sub FrmDonatedBookIssue_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgL.RequiredField(TxtMemberCardNo, LblMemberCardNo.Text) Then passed = False : Exit Sub
        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1BookId).Index) Then passed = False : Exit Sub
    End Sub

    Private Sub FrmDonatedBookIssue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AgL.WinSetting(Me, 580, 885)
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Panel1.SuspendLayout()
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
        'LblMemberType
        '
        Me.LblMemberType.Location = New System.Drawing.Point(463, 51)
        '
        'TxtTransactionBy
        '
        Me.TxtTransactionBy.Location = New System.Drawing.Point(597, 90)
        Me.TxtTransactionBy.Size = New System.Drawing.Size(135, 18)
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(5, 470)
        Me.Panel1.Size = New System.Drawing.Size(872, 21)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(7, 228)
        Me.Pnl1.Size = New System.Drawing.Size(870, 242)
        '
        'LinkLabel1
        '
        Me.LinkLabel1.Location = New System.Drawing.Point(8, 206)
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(895, 4)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(463, 33)
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(575, 21)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(463, 16)
        '
        'TabControl1
        '
        Me.TabControl1.Size = New System.Drawing.Size(873, 186)
        '
        'TP1
        '
        Me.TP1.Size = New System.Drawing.Size(865, 160)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(877, 41)
        '
        'FrmDonatedBookIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(877, 546)
        Me.LogLineTableCsv = "Lib_BookIssueDetail_Log,Stock_Log"
        Me.LogTableName = "Lib_BookIssue_Log"
        Me.MainLineTableCsv = "Lib_BookIssueDetail,Stock"
        Me.MainTableName = "Lib_BookIssue"
        Me.Name = "FrmDonatedBookIssue"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Donated Book Issue"
            RepName = "Lib_DonatedBookIssue_Print" : RepTitle = "Donated Book Issue"
            bCondstr = "WHERE H.DocID='" & mInternalCode & "'"

            strQry = " SELECT  H.DocID,H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                    " H.Member, H.DonationApp, H.TransactionBy, H.MemberRemarks, H.Remarks, " & _
                    " L.Book_UID, L.Book, L.ForDays, L.ToReturnDate, L.ReturnDocId, " & _
                    " L.ReturnDate, L.Status, L.FinePerDay, L.FineAmount, L.Remarks AS LineRemark, L.Edition, " & _
                    " SM.Name AS SiteName,M.MemberCardNo ,SG.DispName AS MemberName,SG.DispName AS MemberDispName, " & _
                    " DA.V_Type AS DAV_Type,DA.V_No AS DAV_No,DA.V_Type + ' - ' + Convert(NVARCHAR(5),DA.V_No) AS ApplicationNo,SGT.Name AS TransByName,SGT.DispName AS TransByDispName, " & _
                    " I.Description AS BookDesc,B.Writer ,B.Publisher,  " & _
                    " R.V_Type AS RetV_Type, R.V_No AS RetV_No,R.V_Type + ' - ' + Convert(NVARCHAR(5),R.V_No) AS ReturnNo " & _
                    " FROM Lib_BookIssue H " & _
                    " LEFT JOIN Lib_BookIssueDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code =H.Site_Code  " & _
                    " LEFT JOIN Lib_Member M ON M.SubCode=H.Member  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode =H.Member  " & _
                    " LEFT JOIN Lib_DonationApp DA ON DA.DocID=H.DonationApp  " & _
                    " LEFT JOIN SubGroup SGT ON SGT.SubCode=H.TransactionBy  " & _
                    " LEFT JOIN Item I ON I.Code=L.Book  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=L.Book  " & _
                    " LEFT JOIN Lib_BookIssue R ON R.DocID=L.ReturnDocId " & _
                    " LEFT JOIN Voucher_Type Vt ON H.V_Type=Vt.V_Type " & _
                     " " & bCondstr & " "

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

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub
End Class
