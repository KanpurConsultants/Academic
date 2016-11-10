Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmFollowupEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Dim mBlnIsEnquiryClosed As Boolean = False


    Private Const Col_SNo As Byte = 0

    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Remark As Byte = 1

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2FollowupNo As Byte = 1
    Private Const Col2FollowupDate As Byte = 2
    Private Const Col2FollowupBy As Byte = 3
    Private Const Col2PersonMeet As Byte = 4
    Private Const Col2FollowupDetail As Byte = 5
    Private Const Col2FollowerRemark As Byte = 6

    Public WithEvents DGL3 As New AgControls.AgDataGrid
    Private Const Col3Class As Byte = 1
    Private Const Col3University As Byte = 2
    Private Const Col3EnrollmentNo As Byte = 3
    Private Const Col3YearOfPassing As Byte = 4
    Private Const Col3Subjects As Byte = 5
    Private Const Col3Result As Byte = 6
    Private Const Col3TotalPercentage As Byte = 7
    Private Const Col3FillSubjectMarks As Byte = 8
    Private Const Col3MeritPercentage As Byte = 9
    Private Const Col3Remark As Byte = 10
    Private Const Col3SubjectList As Byte = 11
    Private Const Col3MarksList As Byte = 12
    Private Const Col3PercentageList As Byte = 13


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
        ''================< Folloup Detail Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1Remark", 350, 255, "Remark", True, False, False, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        ' DGL1.ColumnHeadersHeight = 40

        ''==============================================================================
        ''================< Folloup History Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "DGL2SNo", 30, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "DGL2FollowupNo", 120, 21, "Followup No.", False, False, False, True)
            .AddAgDateColumn(DGL2, "DGL2FollowupDate", 85, "Date", True, False, False)
            .AddAgTextColumn(DGL2, "DGL2FollowupBy", 120, 100, "Followup By", True, False, False, True)
            .AddAgTextColumn(DGL2, "DGL2PersonMet", 120, 100, "Person Met", True, False, False, True)
            .AddAgTextColumn(DGL2, "DGL2FollowupDetail", 200, 255, "Followup Detail", True, False, False, True)
            .AddAgTextColumn(DGL2, "DGL2FollowerRemark", 350, 255, "Follower Remark", True, False, False, True)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ReadOnly = True
        DGL2.AllowUserToAddRows = False

        DGL2.Columns(Col2FollowerRemark).DefaultCellStyle.WrapMode = DataGridViewTriState.True
        DGL2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders

        ''==============================================================================
        ''================< Academic Data Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL3, "DGL3SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL3, "DGL3Class", 120, 50, "Class/Standard", True, False, False, True)
            .AddAgTextColumn(DGL3, "DGL3University", 150, 50, "Board/University", True, False, False)
            .AddAgTextColumn(DGL3, "DGL3EnrollmentNo", 100, 20, "Enrollment No", True, False, False)
            .AddAgNumberColumn(DGL3, "DGL3YearOfPassing", 60, 4, 0, False, "Year", True, False, True)
            .AddAgTextColumn(DGL3, "DGL3Subjects", 120, 255, "Subjects", True, False, False)
            .AddAgTextColumn(DGL3, "DGL3Result", 80, 20, "Result", True, False, False)
            .AddAgNumberColumn(DGL3, "DGL3TotalPercentage", 50, 2, 2, False, "Total %", True, False, True)
            .AddAgButtonColumn(DGL3, "DGL3FillSubSection", 50, "Merit Marks", True, False, , , , "Webdings", 10, "6")
            .AddAgNumberColumn(DGL3, "DGL3MeritPercentage", 50, 2, 2, False, "% For Merit", True, False, True)
            .AddAgTextColumn(DGL3, "DGL3Remark", 110, 255, "Merit Remark", True, False, False)
            .AddAgTextColumn(DGL3, "DGL3SubjectList", 150, 255, "Subject List", False, True, False)
            .AddAgTextColumn(DGL3, "DGL3MarksList", 150, 255, "Marks List", False, True, False)
            .AddAgTextColumn(DGL3, "DGL3PercentageList", 150, 255, "Percentage List", False, True, False)
        End With
        AgL.AddAgDataGrid(DGL3, Pnl3)
        DGL3.ReadOnly = True
        DGL3.AllowUserToAddRows = False
        DGL3.ColumnHeadersHeight = 40

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
            AgL.WinSetting(Me, 650, 1020, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGL3)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            Topctrl1.ChangeAgGridState(DGL3, False)
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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " "

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName) Or AgL.PubIsUserAdmin) Then
                mCondStr = mCondStr & " AND R.PreparedBy ='" & AgL.PubUserName & "' "
            End If

            mQry = "Select R.DocId As SearchCode " & _
                    " From Enquiry_FollowUp R " & _
                    " LEFT JOIN Voucher_Type Vt ON R.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        'mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
        '      " Where NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.EnquiryFollowUp) & "" & _
        '      " Order By Description"
        TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT H.DocId AS Code," & AgL.V_No_Field("H.DocId") & " As [Enquiry No],SG.DispName AS Employee, " & _
                " isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS Name, " & _
                " H.EnquiryMode AS [Enquiry Mode],C.CityName AS City,isnull(H.IsClosed,0)  AS IsClosed " & _
                " FROM Enquiry_Enquiry H  " & _
                " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee " & _
                " LEFT JOIN City C ON C.CityCode=H.CityCode  "
        TxtEnquiryNo.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT E.SubCode AS Code,SG.DispName AS Employee  " & _
                " FROM Pay_Employee E " & _
                " LEFT JOIN SubGroup SG ON SG.SubCode=E.SubCode  " & _
                " WHERE isnull(E.IsTeachingStaff, 0) = 0 " & _
                " ORDER BY SG.DispName  "
        TxtEmployee.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        'mQry = " SELECT '" & ClsMain.EnquiryMode.EMail & "' AS Code ,'" & ClsMain.EnquiryMode.EMail & "' AS Name " & _
        '        " UNION ALL " & _
        '        " SELECT '" & ClsMain.EnquiryMode.Phone & "' AS Code ,'" & ClsMain.EnquiryMode.Phone & "' AS Name " & _
        '        " UNION ALL " & _
        '        " SELECT '" & ClsMain.EnquiryMode.SMS & "' AS Code ,'" & ClsMain.EnquiryMode.SMS & "' AS Name "
        'TxtFollowupMode.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If mSearchCode <> "" Then

                If mBlnIsEnquiryClosed Then
                    If ChkEnquiryClose.Checked = False Then
                        MsgBox(" Entry can not Change !")
                        Topctrl1.FButtonClick(14, True)
                    End If
                End If

                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then

                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    'mQry = " UPDATE Enquiry_Enquiry " & _
                    '        " SET Status = " & AgL.Chk_Text(ClsMain.EnquiryStatus.EnquiryFollowUp) & ", " & _
                    '        " IsClosed = 0 " & _
                    '        " WHERE DocId= " & AgL.Chk_Text(LblEnquiryNoReq.Tag) & " "
                    'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    AgL.Dman_ExecuteNonQry("Delete From Enquiry_FollowUp1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Enquiry_FollowUp Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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

        If mBlnIsEnquiryClosed Then
            If ChkEnquiryClose.Checked = False Then
                MsgBox(" Entry can not Change !")
                Topctrl1.FButtonClick(14, True)
            End If
        End If

        DispText(True)
        TxtV_Date.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " "

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName) Or AgL.PubIsUserAdmin) Then
                mCondStr = mCondStr & " AND H.PreparedBy ='" & AgL.PubUserName & "' "
            End If

            AgL.PubFindQry = " SELECT H.DocId AS SearchCode," & AgL.V_No_Field("H.DocId") & " As [Followup No],H.V_Date AS [Followup Date],SG.DispName AS [Followup BY], " & _
                                " " & AgL.V_No_Field("H.EnquiryDocId") & " As [Enquiry No],isnull(E.FirstName,'') +' '+ isnull(E.MiddleName,'') +' '+ isnull(E.LastName,'') AS Name, " & _
                                " H.PersonMet AS [Person Met],H.Remark AS [Follower Remark],CASE WHEN isnull(H.IsClosed,0) = 0 THEN 'No' ELSE 'Yes' END AS [Enquiry Closed]  " & _
                                " FROM Enquiry_FollowUp H " & _
                                " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee  " & _
                                " LEFT JOIN Enquiry_Enquiry E ON E.DocId=H.EnquiryDocId " & _
                                " " & mCondStr & " "

            AgL.PubFindQryOrdBy = "[Followup No]"


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
        Dim I As Integer, mSr As Integer, bIntJ As Integer = 0, bIntSrMarks As Integer = 0
        Dim mTrans As Boolean = False
        Dim bStrArrSubject() As String = Nothing, bStrArrMarks() As String = Nothing, bStrArrPercentage() As String = Nothing


        mSr = 0
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then

                mQry = " INSERT INTO Enquiry_FollowUp ( DocId, Div_Code, Site_Code, V_Date, " & _
                        " V_Type, V_Prefix, V_No, Employee, EnquiryDocId, FollowupMode, " & _
                        " PersonMet, NextFollowUpDate, Remark,IsClosed, PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES  ( '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & "," & Val(TxtV_No.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtEmployee.AgSelectedValue) & ", " & AgL.Chk_Text(TxtEnquiryNo.AgSelectedValue) & ",  " & AgL.Chk_Text(TxtFollowupMode.Text) & ",  " & _
                        " " & AgL.Chk_Text(TxtPersonMeet.Text) & ", " & AgL.ConvertDate(txtNextFollowupDate.Text) & "," & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " " & IIf(ChkEnquiryClose.Checked = True, 1, 0) & ", '" & AgL.PubUserName & "', " & _
                        " '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A' ) "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            Else
                mQry = " UPDATE Enquiry_FollowUp " & _
                        " SET Employee = " & AgL.Chk_Text(TxtEmployee.AgSelectedValue) & ", " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " EnquiryDocId = " & AgL.Chk_Text(TxtEnquiryNo.AgSelectedValue) & ", " & _
                        " FollowupMode = " & AgL.Chk_Text(TxtFollowupMode.Text) & ", " & _
                        " PersonMet = " & AgL.Chk_Text(TxtPersonMeet.Text) & ", " & _
                        " NextFollowUpDate = " & AgL.ConvertDate(txtNextFollowupDate.Text) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " IsClosed = " & IIf(ChkEnquiryClose.Checked = True, 1, 0) & ", " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " U_AE = 'E'," & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If LblEnquiryNoReq.Tag <> "" Then
                'mQry = " UPDATE Enquiry_Enquiry " & _
                '        " SET Status = " & AgL.Chk_Text(ClsMain.EnquiryStatus.EnquiryFollowUp) & ", " & _
                '        " IsClosed = 0 " & _
                '        " WHERE DocId= " & AgL.Chk_Text(LblEnquiryNoReq.Tag) & " "
                'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            'mQry = " UPDATE Enquiry_Enquiry " & _
            '        " SET Status = " & IIf(ChkEnquiryClose.Checked = True, AgL.Chk_Text(ClsMain.EnquiryStatus.EnquiryClosed), AgL.Chk_Text(ClsMain.EnquiryStatus.EnquiryFollowUp)) & ", " & _
            '        " IsClosed = " & IIf(ChkEnquiryClose.Checked = True, 1, 0) & " " & _
            '        " WHERE DocId= " & AgL.Chk_Text(TxtEnquiryNo.AgSelectedValue) & " "
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Enquiry_FollowUp1 Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                mSr = 0
                For I = 0 To .Rows.Count - 1

                    If .Item(Col1Remark, I).Value <> "" Then
                        mSr = mSr + 1

                        mQry = " INSERT INTO Enquiry_FollowUp1 ( DocId, Sr, Remark ) " & _
                                " VALUES ( '" & mSearchCode & "', " & mSr & ", " & AgL.Chk_Text(.Item(Col1Remark, I).Value) & " ) "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    End If
                Next I
            End With

            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If Academic_ProjLib.ClsMain.IsClient_MIT Then
                Call AgL.SendSms(AgL)
            End If


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
        Dim I As Integer, bIntJ As Integer = 0
        Dim bNetAmount As Double = 0
        Dim mTransFlag As Boolean = False
        Dim bStrSubjectList As String = "", bStrMarksList As String = "", bStrPercentageList As String = ""

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
                mQry = "Select R.*, Vt.NCat, E.IsClosed As IsClosedMainEnquiry " & _
                        " From Enquiry_FollowUp R " & _
                        " Left Join Voucher_Type Vt On R.V_Type = Vt.V_Type " & _
                        " Left Join Enquiry_Enquiry E On E.docId = R.EnquiryDocId " & _
                        " Where R.DocId='" & mSearchCode & "'"
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

                        mBlnIsEnquiryClosed = AgL.VNull(.Rows(0)("IsClosedMainEnquiry"))
                        TxtEnquiryNo.AgSelectedValue = AgL.XNull(.Rows(0)("EnquiryDocId"))
                        LblEnquiryNoReq.Tag = AgL.XNull(.Rows(0)("EnquiryDocId"))
                        ChkEnquiryClose.Checked = AgL.XNull(.Rows(0)("IsClosed"))
                        txtNextFollowupDate.Text = Format(AgL.XNull(.Rows(0)("NextFollowUpDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtEmployee.AgSelectedValue = AgL.XNull(.Rows(0)("Employee"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtFollowupMode.Text = AgL.XNull(.Rows(0)("FollowupMode"))
                        TxtPersonMeet.Text = AgL.XNull(.Rows(0)("PersonMet"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)

                        If TxtEnquiryNo.AgSelectedValue <> "" Then
                            Call ProcFillEnquiryDetail(TxtEnquiryNo.AgSelectedValue)
                            Call ProcFillFollowupHistory(TxtEnquiryNo.AgSelectedValue)
                        End If

                        Call ProcEnquiryStatus()
                    End If
                End With



                mQry = "Select Ad.* " & _
                        " From Enquiry_FollowUp1 Ad " & _
                        " Where Ad.DocId = '" & mSearchCode & "' " & _
                        " Order By Ad.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        DGL1.RowCount = 1 : DGL1.Rows.Clear()
                        For I = 0 To .Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = AgL.VNull(.Rows(I)("Sr"))
                            DGL1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))
                        Next
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
            Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = ""
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()

        mBlnIsEnquiryClosed = False

        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False
        TxtName.Enabled = False : TxtfatherName.Enabled = False
        TxtAdd1.Enabled = False : TxtSex.Enabled = False
        TxtCityCode.Enabled = False : TxtPhone.Enabled = False
        TxtMobile.Enabled = False : TxtPin.Enabled = False
        TxtEMail.Enabled = False : TxtEnqDate.Enabled = False

        TxtFatherOccupation.Enabled = False : TxtMotherOccupation.Enabled = False
        TxtFatherIncome.Enabled = False : TxtMotherIncome.Enabled = False
        TxtMotherName.Enabled = False : TxtCategory.Enabled = False

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
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
        TxtV_Type.Enter, TxtEnquiryNo.Enter
        Try
            Select Case sender.name
                Case TxtEnquiryNo.Name
                    TxtEnquiryNo.AgRowFilter = " ( IsClosed =0 OR Code= " & AgL.Chk_Text(TxtEnquiryNo.AgSelectedValue) & " ) "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ProcEnquirySearch()
        If Topctrl1.Mode <> "Browse" Then
            Dim mCondStr As String
            Try
                mCondStr = " Where 1=1 "

                AgL.PubFindQry = " SELECT  H.DocId AS SearchCode, " & AgL.V_No_Field("H.DocId") & " As [Enquiry No],H.V_Date AS [Enquiry Date], H.EnquiryMode AS [Enquiry Mode], " & _
                                    " SG.DispName AS Employee, VP.SessionProgramme AS [Session Programme],  " & _
                                    " VPS.SessionProgrammeStream AS [Session Programme Stream],  " & _
                                    " isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS Name, " & _
                                    " C.CityName AS City, H.Mobile, H.EMail " & _
                                    " FROM Enquiry_Enquiry H " & _
                                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee  " & _
                                    " LEFT JOIN ViewSch_SessionProgramme VP ON VP.Code=H.SessionProgramme  " & _
                                    " LEFT JOIN ViewSch_SessionProgrammeStream VPS ON VPS.Code=H.SessionProgrammeStream  " & _
                                    " LEFT JOIN City C ON C.CityCode=H.CityCode " & _
                                    " WHERE isnull(H.IsClosed,0) = 0 "
                AgL.PubFindQryOrdBy = "[Enquiry No]"


                '*************** common code start *****************
                AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
                AgL.PubObjFrmFind.ShowDialog()
                AgL.PubObjFrmFind = Nothing
                If AgL.PubSearchRow <> "" Then
                    TxtEnquiryNo.AgSelectedValue = AgL.PubSearchRow
                    Call ProcFillEnquiryDetail(AgL.PubSearchRow)
                    Call ProcFillFollowupHistory(AgL.PubSearchRow)
                End If
                '*************** common code end  *****************
            Catch Ex As Exception
                MsgBox(Ex.Message)
            End Try
        End If
    End Sub

    Private Sub ProcFillEnquiryDetail(ByVal bEnquiryDocId As String)
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim I As Integer, bIntJ As Integer = 0
        Dim bStrSubjectList As String = "", bStrMarksList As String = "", bStrPercentageList As String = ""
        If bEnquiryDocId <> "" Then
            mQry = "  SELECT  H.DocId AS SearchCode, H.V_Date AS EnquiryDate, " & _
                    " isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS Name,  C.CityName AS City, H.Mobile, H.EMail, " & _
                    " ISNULL(H.Add1,'')+' '+ ISNULL(H.Add2,'') AS Address, H.PIN, H.Phone, H.FatherName, " & _
                    " H.Sex,OP.Description AS FatherOccupation,H.MotherName,OM.Description AS MotherOccupation, " & _
                    " H.FatherIncome ,H.MotherIncome ,SC.Description AS Category  " & _
                    " FROM Enquiry_Enquiry H   " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee    " & _
                    " LEFT JOIN City C ON C.CityCode=H.CityCode " & _
                    " LEFT JOIN Sch_Occupation OP ON OP.Code=H.FatherOccupation  " & _
                    " LEFT JOIN Sch_Occupation OM ON OM.Code=H.MotherOccupation " & _
                    " LEFT JOIN Sch_Category SC ON SC.Code=H.Category  " & _
                    " WHERE H.DocId= " & AgL.Chk_Text(bEnquiryDocId) & " "
            DsTemp = AgL.FillData(mQry, AgL.GCn)

            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    TxtEnquiryNo.AgSelectedValue = AgL.XNull(.Rows(0)("SearchCode"))
                    TxtEnqDate.Text = Format(AgL.XNull(.Rows(0)("EnquiryDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                    TxtName.Text = AgL.XNull(.Rows(0)("Name"))
                    TxtSex.Text = AgL.XNull(.Rows(0)("Sex"))
                    TxtfatherName.Text = AgL.XNull(.Rows(0)("FatherName"))
                    TxtMotherName.Text = AgL.XNull(.Rows(0)("MotherName"))
                    TxtFatherOccupation.Text = AgL.XNull(.Rows(0)("FatherOccupation"))
                    TxtMotherOccupation.Text = AgL.XNull(.Rows(0)("MotherOccupation"))
                    TxtAdd1.Text = AgL.XNull(.Rows(0)("Address"))
                    TxtCategory.Text = AgL.XNull(.Rows(0)("Category"))
                    TxtCityCode.Text = AgL.XNull(.Rows(0)("City"))
                    TxtMobile.Text = AgL.XNull(.Rows(0)("Mobile"))
                    TxtPhone.Text = AgL.XNull(.Rows(0)("Phone"))
                    TxtEMail.Text = AgL.XNull(.Rows(0)("EMail"))
                    TxtPin.Text = AgL.XNull(.Rows(0)("Pin"))
                    TxtFatherIncome.Text = Format(AgL.VNull(.Rows(0)("FatherIncome")), "0.00")
                    TxtMotherIncome.Text = Format(AgL.VNull(.Rows(0)("MotherIncome")), "0.00")
                End If
            End With

            mQry = "Select Ad.*,U.Description AS UniversityDesc " & _
                    " From Enquiry_AcademicDetail Ad " & _
                    " LEFT JOIN Sch_University U ON U.Code =Ad.University " & _
                    " Where Ad.DocId = '" & bEnquiryDocId & "' " & _
                    " Order By Ad.Sr "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    DGL3.RowCount = 1 : DGL3.Rows.Clear()
                    For I = 0 To .Rows.Count - 1
                        DGL3.Rows.Add()
                        DGL3.Item(Col_SNo, I).Value = AgL.VNull(.Rows(I)("Sr"))
                        DGL3.Item(Col3Class, I).Value = AgL.XNull(.Rows(I)("Class"))
                        DGL3.Item(Col3University, I).Value = AgL.XNull(.Rows(I)("UniversityDesc"))
                        DGL3.Item(Col3EnrollmentNo, I).Value = AgL.XNull(.Rows(I)("EnrollmentNo"))
                        DGL3.Item(Col3YearOfPassing, I).Value = AgL.VNull(.Rows(I)("YearOfPassing"))
                        DGL3.Item(Col3Subjects, I).Value = AgL.XNull(.Rows(I)("Subjects"))
                        DGL3.Item(Col3Result, I).Value = AgL.XNull(.Rows(I)("Result"))
                        DGL3.Item(Col3TotalPercentage, I).Value = Format(AgL.VNull(.Rows(I)("TotalPercentage")), "0.00")
                        DGL3.Item(Col3MeritPercentage, I).Value = Format(AgL.VNull(.Rows(I)("MeritPercentage")), "0.00")
                        DGL3.Item(Col3Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))

                        mQry = "SELECT M.* " & _
                                " FROM Enquiry_MeritMarks M " & _
                                " WHERE M.DocId = '" & bEnquiryDocId & "' " & _
                                " AND M.ClassSr = " & AgL.VNull(.Rows(I)("Sr")) & " " & _
                                " ORDER BY M.Sr "
                        DTbl = CType(AgL.FillData(mQry, AgL.GCn), DataSet).Tables(0)

                        bStrSubjectList = "" : bStrMarksList = "" : bStrSubjectList = ""
                        If DTbl.Rows.Count > 0 Then
                            For bIntJ = 0 To DTbl.Rows.Count - 1
                                bStrSubjectList += IIf(bStrSubjectList.Trim = "", AgL.XNull(DTbl.Rows(bIntJ)("Subject")).ToString, "," + AgL.XNull(DTbl.Rows(bIntJ)("Subject")).ToString)
                                bStrMarksList += IIf(bStrMarksList.Trim = "", AgL.VNull(DTbl.Rows(bIntJ)("Marks")).ToString, "," + AgL.VNull(DTbl.Rows(bIntJ)("Marks")).ToString)
                                bStrPercentageList += IIf(bStrPercentageList.Trim = "", AgL.VNull(DTbl.Rows(bIntJ)("Percentage")).ToString, "," + AgL.VNull(DTbl.Rows(bIntJ)("Percentage")).ToString)
                            Next
                        End If
                        DTbl.Dispose() : DTbl = Nothing

                        DGL3.Item(Col3SubjectList, I).Value = bStrSubjectList
                        DGL3.Item(Col3MarksList, I).Value = bStrMarksList
                        DGL3.Item(Col3PercentageList, I).Value = bStrPercentageList
                    Next
                End If
            End With

        End If
    End Sub

    Private Sub ProcFillFollowupHistory(ByVal bEnquiryDocid As String)
        Dim DsTemp As DataSet = Nothing
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        Dim I = 0
        mQry = " SELECT F.DocId," & AgL.V_No_Field("F.DocId") & " AS FollowupNo,F.V_Date ,SG.dispName AS FollowupBy, " & _
                " F.PersonMet ,F.Remark AS FollowerRemark,F1.Remark AS FollowupDetail  " & _
                " FROM Enquiry_FollowUp F " & _
                " LEFT JOIN SubGroup SG ON SG.SubCode=F.Employee  " & _
                " LEFT JOIN Enquiry_FollowUp1 F1 ON F1.DocId=F.DocId " & _
                " WHERE F.EnquiryDocId = " & AgL.Chk_Text(bEnquiryDocid) & " " & _
                " AND F.V_Date < '" & CDate(TxtV_Date.Text) & "' " & _
                " ORDER BY F.V_Date DESC "
        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            DGL2.RowCount = 1 : DGL2.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To .Rows.Count - 1
                    DGL2.Rows.Add()
                    DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count
                    DGL2.Item(Col2FollowupNo, I).Value = AgL.XNull(.Rows(I)("FollowupNo"))
                    DGL2.Item(Col2FollowupBy, I).Value = AgL.XNull(.Rows(I)("FollowupBy"))
                    DGL2.Item(Col2PersonMeet, I).Value = AgL.XNull(.Rows(I)("PersonMet"))
                    DGL2.Item(Col2FollowupDate, I).Value = AgL.XNull(.Rows(I)("V_Date"))
                    DGL2.Item(Col2FollowupDetail, I).Value = AgL.XNull(.Rows(I)("FollowupDetail"))

                    If I > 0 Then
                        If DGL2.Item(Col2FollowupNo, I).Value = DGL2.Item(Col2FollowupNo, I - 1).Value Then
                            DGL2.Item(Col2FollowerRemark, I).Value = ""
                        Else
                            DGL2.Item(Col2FollowerRemark, I).Value = AgL.XNull(.Rows(I)("FollowerRemark"))
                        End If
                    Else
                        DGL2.Item(Col2FollowerRemark, I).Value = AgL.XNull(.Rows(I)("FollowerRemark"))
                    End If
                Next
            End If
        End With
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtV_Type.Validating, TxtV_No.Validating, TxtV_Date.Validating, _
           TxtSite_Code.Validating, TxtRemark.Validating, _
           TxtPhone.Validating, TxtEnquiryNo.Validating, _
        TxtMobile.Validating, TxtfatherName.Validating, TxtName.Validating, _
        TxtDocId.Validating, TxtCityCode.Validating, _
        TxtEmployee.Validating, TxtAdd1.Validating, TxtEnquiryNo.Validating

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

                Case TxtEnquiryNo.Name
                    If TxtEnquiryNo.AgSelectedValue <> "" Then
                        Call ProcFillEnquiryDetail(TxtEnquiryNo.AgSelectedValue)
                        Call ProcFillFollowupHistory(TxtEnquiryNo.AgSelectedValue)
                    End If

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
        Dim bNetAmount As Double = 0

        If Topctrl1.Mode = "Browse" Then Exit Sub

        'Call BlankFooterGrid()
        ' TxtFamilyIncome.Text = Format(Val(TxtFatherIncome.Text) + Val(TxtMotherIncome.Text), "0.00")


    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStrModule$ = ""
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, LblV_Date.Text) Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtEmployee, LblEmployee.Text) Then Exit Function
            If AgL.RequiredField(TxtFollowupMode, LblFollowupMode.Text) Then Exit Function
            If AgL.RequiredField(TxtEnquiryNo, "Enquiry No.") Then Exit Function
            'If AgL.RequiredField(TxtPersonMeet, LblPersonMeet.Text) Then Exit Function
            If AgL.RequiredField(TxtRemark, LblRemark.Text) Then Exit Function
            If Not AgL.IsValid_EMailId(TxtEMail, "Email ID") Then Exit Function


            AgCL.AgBlankNothingCells(DGL1)
            ' If Not AgCL.AgCheckMandatory(Me) Then Exit Function
            If AgCL.AgIsBlankGrid(DGL1, DGL1.Columns(Col1Remark).Index) Then Exit Function

            If txtNextFollowupDate.Text = "" And ChkEnquiryClose.Checked = False Then
                MsgBox("Next Followup Date is a required field!") : txtNextFollowupDate.Focus() : Exit Function
            End If

            If txtNextFollowupDate.Text <> "" Then
                If CDate(TxtV_Date.Text) >= CDate(txtNextFollowupDate.Text) Then
                    MsgBox("Next Followup Date should be greater than " & LblV_Date.Text & " !") : txtNextFollowupDate.Focus() : Exit Function
                End If
            End If

            If txtNextFollowupDate.Text <> "" And ChkEnquiryClose.Checked = True Then
                MsgBox("Next Followup Date is not allowed") : txtNextFollowupDate.Focus() : Exit Function
            End If

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
        Dim DrTemp As DataRow() = Nothing

        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            DrTemp = TxtV_Type.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RegistrationEntry) & "")
            If DrTemp IsNot Nothing Then
                TxtV_Type.AgSelectedValue = Academic_ProjLib.ClsMain.NCat_RegistrationEntry
                LblV_Type.Tag = "" 'ClsMain.Temp_NCat.Enquiry
            Else
                TxtV_Type.AgSelectedValue = ""
                LblV_Type.Tag = ""
            End If
            DrTemp = Nothing

            TxtV_Type.Enabled = True
        End If
        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled Then TxtV_Type.Focus() Else TxtV_Date.Focus()
        Else
            TxtV_Date.Focus()
        End If

        ChkEnquiryClose.Checked = False
        Call ProcEnquiryStatus()
        mQry = " SELECT TOP 1 H.Employee  FROM Enquiry_FollowUp H " & _
          " ORDER BY H.V_No DESC ,H.V_Date DESC "
        TxtEmployee.AgSelectedValue = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar()

        TxtV_Date.Text = AgL.PubLoginDate
        TxtFollowupMode.Focus()

    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub BtnEnquirySearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnquirySearch.Click
        ProcEnquirySearch()
    End Sub


    Private Sub DGL3_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL3.CellContentClick
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Dim FrmObj As Form = Nothing

        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            Select Case DGL3.CurrentCell.ColumnIndex
                Case Col3FillSubjectMarks
                    If DGL3.Item(Col3SubjectList, mRowIndex).Value Is Nothing Then DGL3.Item(Col3SubjectList, mRowIndex).Value = ""
                    If DGL3.Item(Col3MarksList, mRowIndex).Value Is Nothing Then DGL3.Item(Col3MarksList, mRowIndex).Value = ""
                    If DGL3.Item(Col3PercentageList, mRowIndex).Value Is Nothing Then DGL3.Item(Col3PercentageList, mRowIndex).Value = ""

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL3_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL3.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub ProcEnquiryStatus()
        If ChkEnquiryClose.Checked = True Then
            ChkEnquiryClose.ForeColor = Color.Red
        ElseIf ChkEnquiryClose.Checked = False Then
            ChkEnquiryClose.ForeColor = Color.Green
        End If
    End Sub

    Private Sub ChkEnquiryClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkEnquiryClose.Click
        Try
            Select Case sender.name
                Case ChkEnquiryClose.Name
                    If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
                    Call ProcEnquiryStatus()

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
