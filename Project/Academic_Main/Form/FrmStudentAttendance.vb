Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmStudentAttendance
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mTmA_Date$ = "", mTmTeacher$ = "", mTmTimeSlot$ = "", mTmClassSection$ = "", mTmClassRoom$ = "", mTmSubjectType$ = "", mTmSubject$ = ""            'Variables Holds Value During Add Mode

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1AdmissionDocId As Byte = 1
    Private Const Col1AdmissionID As Byte = 2
    Private Const Col1IsPresent As Byte = 3
    Private Const Col1IsLeaveTaken As Byte = 4

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
        ''================< Student Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 30, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionDocId", 300, 8, "Student", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionId", 200, 8, "Admission ID", True, True, False)
            '.AddAgListColumn(DGL1, "Yes,No", "Dgl1YesNo", 80, "Yes,No", "Present (Yes/No)", True, False, False)
            AgL.AddCheckColumn(DGL1, "Dgl1YesNo", 60, 50, "Present (Yes/No)", True, True)
            .AddAgListColumn(DGL1, "Yes,No", "Dgl1IsLeaveTaken", 80, "1,0", "Leave Taken", True, True, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False
        DGL1.EnableHeadersVisualStyles = False
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
            AgL.WinSetting(Me, 650, 880, 0, 0)
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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("S.A_Date", AgL.PubStartDate, AgL.PubEndDate) & " " & _
                        " And " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " "

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
                mCondStr += " And S.PreparedBy = '" & AgL.PubUserName & "' "
            End If

            mQry = "Select S.Code As SearchCode " & _
                    " From Sch_StudentAttendance S " & _
                    " " & mCondStr & " "
            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub


    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT R.Code , R.Description [Room Description], R.ManualCode , R.Capacity " & _
                    " FROM Sch_ClassRoom R " & _
                    " ORDER BY R.Description "
            TxtClassRoom.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ClassSectionDesc " & _
                    " FROM ViewSch_ClassSection S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY S.ClassSectionDesc "
            TxtClassSection.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)


            mQry = "SELECT S.Code , S.SubSection, S.ClassSection " & _
                    " FROM ViewSch_ClassSectionSubSection S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY S.ClassSectionSubSectionDesc"
            TxtClassSectionSubSection.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select S.Code As Code, S.Description As [Time Slot], " & AgL.ConvertTimeField("S.StartTime") & " As [Start Time], " & _
                    " " & AgL.ConvertTimeField("S.EndTime") & " As [End Time], S.Duration as [Duration]  " & _
                    " From  Sch_TimeSlot S "
            TxtTimeSlot.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT E.SubCode AS Code, Sg.Name, Sg.LogInUser " & _
                    " FROM Pay_Employee E " & _
                    " LEFT JOIN SubGroup Sg ON E.SubCode = Sg.SubCode " & _
                    " WHERE (IsNull(E.IsTeachingStaff,0)<>0 or IsNull(E.CanTakeClass,0)<>0) And " & _
                    " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                    " ORDER BY Sg.Name "
            TxtTeacher.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code , S.Description AS Subject, S.SubjectType [Subject Type] " & _
                    " FROM Sch_Subject S " & _
                    " ORDER BY S.Description "
            TxtSubject.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            AgCL.IniAgHelpList(TxtSubjectType, "Theory,Practical")

            mQry = "SELECT Vp.AdmissionDocId As Code, V1.StudentName As [Student Name], V1.AdmissionID, V1.Student As StudentCode, " & _
                    " Vp.FromStreamYearSemester AS StreamYearSemesterCode " & _
                    " FROM (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.PromotionDate IS NULL) Vp " & _
                    " LEFT JOIN ViewSch_Admission V1 ON Vp.AdmissionDocId = V1.DocId " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By V1.StudentName "
            DGL1.AgHelpDataSet(Col1AdmissionDocId, 1) = AgL.FillData(mQry, AgL.GCn)

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

                    If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.PubIsUserAdmin) Then
                        If FunIsDateLock(TxtA_Date.Text) Then
                            MsgBox("Permission Denied!...", MsgBoxStyle.Information, "Date Lock")
                            Exit Sub
                        End If
                    End If

                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    AgL.Dman_ExecuteNonQry("Delete From Sch_StudentAttendance1 Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_StudentAttendance Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.PubIsUserAdmin) Then
            If FunIsDateLock(TxtA_Date.Text) Then
                MsgBox("Permission Denied!...", MsgBoxStyle.Information, "Date Lock")
                Topctrl1.FButtonClick(14, True)
                Exit Sub
            End If
        End If

        DispText(True)
        TxtA_Date.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("A.A_Date", AgL.PubStartDate, AgL.PubEndDate) & " " & _
                        " And " & AgL.PubSiteCondition("A.Site_Code", AgL.PubSiteCode) & " "

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
                mCondStr += " And A.PreparedBy = '" & AgL.PubUserName & "' "
            End If

            ''''mCondStr = " Where A.Code IN ('A100001727', 'A100001749', 'A100001765', 'A100001780', 'A100001797', 'A100001803', 'A100005076', 'A100007404', 'A100008102') "

            AgL.PubFindQry = "SELECT A.Code AS SearchCode, " & AgL.ConvertDateField("A.A_Date") & " As [Attendance Date] , " & _
                                " T.Description AS [Time Slot], Cs.ClassSectionDesc [Class/Section], Ss.SubSection As [Sub-Section], " & _
                                " R.Description AS [Room Name], Subj.Description AS Subject, Subj.SubjectType AS [Subject Type], S.Name AS [Site Name],  " & _
                                " A.PreparedBy AS [Entry By], A.U_EntDt AS [Entry Date], A.ModifiedBy AS [Edit By], A.Edit_Date AS [Edit Date] " & _
                                " FROM Sch_StudentAttendance A " & _
                                " LEFT JOIN SiteMast S on A.Site_Code = S.Code  " & _
                                " LEFT JOIN Sch_TimeSlot T ON A.TimeSlot = T.Code  " & _
                                " LEFT JOIN ViewSch_ClassSection Cs ON A.ClassSection = Cs.Code  " & _
                                " LEFT JOIN Sch_ClassSectionSubSection SS On A.ClassSectionSubSection = Ss.Code " & _
                                " LEFT JOIN Sch_ClassRoom R ON A.ClassRoom = R.Code  " & _
                                " LEFT JOIN Sch_Subject Subj ON A.Subject = Subj.Code " & _
                                " " & mCondStr & " "

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
        Dim I As Integer, bSr As Integer = 0
        Dim mTrans As Boolean = False

        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_StudentAttendance ( Code, A_Date, TimeSlot, ClassSection, ClassRoom, Subject, " & _
                        " Teacher, Remark, ClassSectionSubSection, " & _
                        " Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', " & AgL.ConvertDate(TxtA_Date.Text) & ", " & AgL.Chk_Text(TxtTimeSlot.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & AgL.Chk_Text(TxtClassRoom.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ", " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtRemark.Text) & ", " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & ", " & _
                        " '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_StudentAttendance " & _
                        " SET  " & _
                        " 	A_Date = " & AgL.ConvertDate(TxtA_Date.Text) & ", " & _
                        " 	TimeSlot = " & AgL.Chk_Text(TxtTimeSlot.AgSelectedValue) & ", " & _
                        " 	ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & _
                        " 	ClassRoom = " & AgL.Chk_Text(TxtClassRoom.AgSelectedValue) & ", " & _
                        " 	Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ", " & _
                        " 	Teacher = " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & ", " & _
                        " 	Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        "   ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & ", " & _
                        " 	U_AE = 'E', " & _
                        " 	Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " 	ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE Code = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            If Topctrl1.Mode = "Edit" Then
                AgL.Dman_ExecuteNonQry("Delete From Sch_StudentAttendance1 Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1AdmissionDocId, I).Value <> "" Then
                        bSr += 1

                        mQry = "INSERT INTO Sch_StudentAttendance1 ( " & _
                                " Code, Sr, AdmissionDocId, IsPresent ) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & bSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & "," & _
                                " " & IIf(AgL.StrCmp(.Item(Col1IsPresent, I).Value.ToString, AgLibrary.ClsConstant.StrCheckedValue), 1, 0) & " )"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)


            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            If Topctrl1.Mode = "Add" Then
                Call ProcCreateSms(Academic_Main.ClsMain.SmsEvent.StudentAttendance)
            End If

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode

                mTmA_Date = TxtA_Date.Text : mTmTeacher = TxtTeacher.AgSelectedValue
                mTmTimeSlot = TxtTimeSlot.AgSelectedValue : mTmClassSection = TxtClassSection.AgSelectedValue
                mTmClassRoom = TxtClassRoom.AgSelectedValue : mTmSubjectType = TxtSubjectType.Text : mTmSubject = TxtSubject.AgSelectedValue

                Topctrl1.FButtonClick(0)

                'If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    Call PrintDocument(mDocId)
                'End If

                Exit Sub
            Else
                mTmA_Date = "" : mTmTeacher = "" : mTmTimeSlot = "" : mTmClassSection = "" : mTmClassRoom = "" : mTmSubject = ""

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

    Private Sub ProcCreateSms(ByVal StrEvent As String)
        Dim bDtMain As DataTable = Nothing
        Dim bDtSem As DataTable = Nothing
        Dim bDtHOD As DataTable = Nothing
        Dim bIntSmsBeforeDays% = 7, bIntI% = 0
        Dim bStrSMS$ = "", bStrStuMobileNo$ = "", bStrCategory$ = "", bStrSmsDate$ = "", bStrSubCode$ = "", bStrTeacherMobileNo$ = "", bStrParentMobileNo$ = "", bStrMDMobileNo$ = "", bStrHODMDMobileNo$ = "", bStrStudentName$ = "", bStrHodSubCode$ = ""
        Dim bStrSmsQry$ = "", bStrMainTable$ = "", bStrMainField$ = ""
        Dim bDtSmsEvent As DataTable = Nothing

        Try
            Me.Cursor = Cursors.WaitCursor
            If Not AgLibrary.ClsConstant.IsSmsActive Then Exit Sub

            If AgL.StrCmp(StrEvent, Academic_Main.ClsMain.SmsEvent.StudentAttendance) Then
                bStrMainTable = "Sch_StudentAttendance"
                bStrMainField = "T.A_Date"
            End If

            mQry = "SELECT E.* FROM Sms_Event E  WITH (NoLock) WHERE E.Event = '" & StrEvent & "'"
            bDtSmsEvent = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            If bDtSmsEvent.Rows.Count > 0 Then
                bStrSMS = AgL.XNull(bDtSmsEvent.Rows(0)("Message")).ToString
                bStrCategory = AgL.XNull(bDtSmsEvent.Rows(0)("Category")).ToString
            End If
            If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()
            If bStrSMS.Trim = "" Then Exit Sub

            mQry = "SELECT SD.Student, Sg.Name As StudentName, " & _
                    " T.A_Date AS V_Date, " & _
                    " Right(IsNull(Sg.Mobile,''),10) AS StudentMobile ," & _
                    " Right(IsNull(TT.Mobile,''),10) AS TeacherMobile, " & _
                    " Right(IsNull(Sg.PMobile,''),10) AS ParentMobile, " & _
                    " Right(IsNull(SS.Mobile,''),10) AS MDMobile, " & _
                    " sd.CurrentSemester, T.Teacher As TeacherCode " & _
                    " FROM (" & bStrMainTable & " T WITH (NoLock) " & _
                    " LEFT JOIN Sch_StudentAttendance1 ST WITH (noLock) ON T.code=ST.code  " & _
                    " LEFT JOIN Sch_Admission SD WITH (noLock) ON ST.AdmissionDocId=SD.DocID " & _
                    " LEFT JOIN SiteMast SS  WITH (NoLock) ON SS.Code = T.Site_Code " & _
                    " INNER JOIN SubGroup TT WITH (NoLock) ON T.Teacher = TT.SubCode " & _
                    " INNER JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = SD.Student)  " & _
                    " WHERE T.Code = '" & mSearchCode & "'  " & _
                    " AND Len(Sg.Mobile) >= 10 " & _
                    " And Sg.Mobile Is NOT Null  AND Isnull(ST.ISPresent,0)=0 "
            bDtMain = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            If bDtMain.Rows.Count > 0 Then
                For bIntI = 0 To bDtMain.Rows.Count - 1
                    bStrSubCode = AgL.XNull(bDtMain.Rows(bIntI)("Student"))
                    bStrStuMobileNo$ = AgL.XNull(bDtMain.Rows(bIntI)("StudentMobile"))
                    bStrTeacherMobileNo = AgL.XNull(bDtMain.Rows(bIntI)("TeacherMobile"))
                    bStrParentMobileNo = AgL.XNull(bDtMain.Rows(bIntI)("ParentMobile"))
                    bStrMDMobileNo$ = AgL.XNull(bDtMain.Rows(bIntI)("MDMobile"))
                    bStrSmsDate = Format(AgL.XNull(bDtMain.Rows(bIntI)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                    mQry = "SELECT Sem.SessionProgrammeStreamCode  FROM ViewSch_StreamYearSemester Sem WHERE Code ='" & AgL.XNull(bDtMain.Rows(bIntI)("CurrentSemester")) & "'"
                    bDtSem = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                    mQry = "SELECT TOP 1 Sg.SubCode , Right(IsNull(Sg.Mobile,''),10) AS HODMobile " & _
                            " FROM Sch_SessionProgrammeStreamOC Oc WITH (NoLock) " & _
                            " LEFT JOIN SubGroup Sg WITH (NoLock)  ON Oc.OC = SG.SubCode " & _
                            " WHERE Oc.SessionProgrammeStream = '" & AgL.XNull(bDtSem.Rows(0)("SessionProgrammeStreamCode")) & "' " & _
                            " AND '" & bStrSmsDate & "' BETWEEN  Oc.FromDate AND IsNull(Oc.UptoDate,'" & bStrSmsDate & "')" & _
                            " ORDER BY Oc.FromDate Desc "
                    bDtHOD = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                    If bDtHOD.Rows.Count > 0 Then
                        bStrHodSubCode = AgL.XNull(bDtHOD.Rows(0)("SubCode"))
                        bStrHODMDMobileNo = AgL.XNull(bDtHOD.Rows(0)("HODMobile"))
                    End If


                    bStrSMS = bStrStudentName + Space(1) + "Is Absent On : " + bStrSmsDate

                    If bStrSMS.Trim <> "" And bStrStuMobileNo$.Trim <> "" And bStrSmsDate.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, bStrSmsDate, bStrCategory, bStrSubCode, bStrStuMobileNo$, AgL.PubLoginDate, bStrSMS)
                    End If

                    If bStrSMS.Trim <> "" And bStrTeacherMobileNo.Trim <> "" And bStrSmsDate.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, bStrSmsDate, bStrCategory, AgL.XNull(bDtMain.Rows(bIntI)("TeacherCode")), bStrTeacherMobileNo, AgL.PubLoginDate, bStrSMS)
                    End If

                    If bStrSMS.Trim <> "" And bStrParentMobileNo.Trim <> "" And bStrSmsDate.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, bStrSmsDate, bStrCategory, bStrSubCode, bStrParentMobileNo, AgL.PubLoginDate, bStrSMS)
                    End If

                    If bStrSMS.Trim <> "" And bStrMDMobileNo$.Trim <> "" And bStrSmsDate.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, bStrSmsDate, bStrCategory, "", bStrMDMobileNo$, AgL.PubLoginDate, bStrSMS)
                    End If

                    If bStrSMS.Trim <> "" And bStrHODMDMobileNo.Trim <> "" And bStrSmsDate.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, bStrSmsDate, bStrCategory, bStrHodSubCode, bStrHODMDMobileNo, AgL.PubLoginDate, bStrSMS)
                    End If
                Next

                Call AgL.SendSms(AgL)
            End If
            If bDtMain IsNot Nothing Then bDtMain.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            If bDtMain IsNot Nothing Then bDtMain.Dispose()
            If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()
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
                mQry = "Select A.*, S.SubjectType " & _
                        " From Sch_StudentAttendance A " & _
                        " LEFT JOIN Sch_Subject S ON A.Subject = S.Code " & _
                        " Where A.Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtClassSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSection"))
                        TxtClassSectionSubSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSectionSubSection"))
                        LblClassSectionSubSection.Tag = AgL.XNull(.Rows(0)("ClassSection"))
                        TxtTimeSlot.AgSelectedValue = AgL.XNull(.Rows(0)("TimeSlot"))
                        TxtClassRoom.AgSelectedValue = AgL.XNull(.Rows(0)("ClassRoom"))
                        TxtTeacher.AgSelectedValue = AgL.XNull(.Rows(0)("Teacher"))
                        TxtSubjectType.Text = AgL.XNull(.Rows(0)("SubjectType"))
                        LblSubject.Tag = AgL.XNull(.Rows(0)("SubjectType"))
                        TxtSubject.AgSelectedValue = AgL.XNull(.Rows(0)("Subject"))

                        TxtA_Date.Text = Format(AgL.XNull(.Rows(0)("A_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select Sa.*, A.AdmissionID, " & _
                        " Convert(BIT,CASE WHEN V1.AdmissionDocId IS NULL THEN 0 ELSE 1 END) AS IsLeaveTaken " & _
                        " From Sch_StudentAttendance1 Sa " & _
                        " LEFT JOIN ViewSch_Admission A ON Sa.AdmissionDocId = A.DocId " & _
                        " LEFT JOIN ( " & _
                        "           SELECT DISTINCT " & AgL.ConvertDate(TxtA_Date.Text) & " AS LeaveDate, L.AdmissionDocId  " & _
                        "           FROM Sch_StudentLeave L " & _
                        "           WHERE " & AgL.ConvertDate(TxtA_Date.Text) & " BETWEEN L.FromDate AND L.ToDate " & _
                        " ) AS V1 ON Sa.AdmissionDocId = V1.AdmissionDocId " & _
                        " Where Sa.Code = '" & mSearchCode & "' " & _
                        " Order By Sa.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                            DGL1.Item(Col1AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))
                            DGL1.Item(Col1IsPresent, I).Value = IIf(AgL.VNull(.Rows(I)("IsPresent")), AgLibrary.ClsConstant.StrCheckedValue, AgLibrary.ClsConstant.StrUnCheckedValue)
                            DGL1.Item(Col1IsLeaveTaken, I).Value = IIf(AgL.VNull(.Rows(I)("IsLeaveTaken")), "Yes", "No")

                            ProcSetPresentCellColour(I)
                        Next I
                    End If
                End With
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)
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
        mSearchCode = ""

        If mTmA_Date.Trim <> "" Then
            TxtA_Date.Text = mTmA_Date
            TxtTimeSlot.AgSelectedValue = mTmTimeSlot
            TxtClassSection.AgSelectedValue = mTmClassSection
            TxtClassRoom.AgSelectedValue = mTmClassRoom
            TxtSubjectType.Text = mTmSubjectType
            TxtSubject.AgSelectedValue = mTmSubject : Call Validating_Controls(TxtSubject)
            TxtTeacher.AgSelectedValue = mTmTeacher
        End If

        DGL1.RowCount = 1 : DGL1.Rows.Clear()

    End Sub



    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False

        TxtClassSection.Enabled = Enb
        TxtClassSectionSubSection.Enabled = Enb
        TxtSubject.Enabled = Enb

        If Topctrl1.Mode = "Edit" Then
            TxtClassSection.Enabled = False
            TxtClassSectionSubSection.Enabled = False
            TxtSubjectType.Enabled = False
            TxtSubject.Enabled = False
            TxtTeacher.Enabled = False
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
                    'DGL1.AgRowFilter(AdmissionDocId) = " And AdmissionDocId = '" & TxtStreamYearSemester.AgSelectedValue & "'"
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
                Case Col1IsPresent
                    Call Calculation()
                    ProcSetPresentCellColour(mRowIndex)
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        Dim mRowIndex As Integer, mColumnIndex As Integer

        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub

        mRowIndex = DGL1.CurrentCell.RowIndex
        mColumnIndex = DGL1.CurrentCell.ColumnIndex

        Try
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1IsPresent
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(DGL1, Col1IsPresent)
                        ProcSetPresentCellColour(mRowIndex)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
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
                Case Col1IsPresent
                    Call AgL.ProcSetCheckColumnCellValue(DGL1, Col1IsPresent)
                    ProcSetPresentCellColour(mRowIndex)
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub

    'Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
    '    If Topctrl1.Mode = "Browse" Then Exit Sub
    '    Dim mRowIndex As Integer, mColumnIndex As Integer
    '    Try
    '        mRowIndex = DGL1.CurrentCell.RowIndex
    '        mColumnIndex = DGL1.CurrentCell.ColumnIndex

    '        If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

    '        Select Case DGL1.CurrentCell.ColumnIndex
    '            Case Col1AdmissionDocId
    '                If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
    '                    'DGL1.Item(Col1_ManualCode, mRowIndex).Value = ""
    '                Else
    '                    If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
    '                        With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
    '                            'DGL1.Item(Col1_ManualCode, mRowIndex).Value = AgL.XNull(.Item("Name", .CurrentCell.RowIndex).Value)
    '                        End With
    '                    End If
    '                End If

    '        End Select
    '        Call Calculation()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

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
                    Case Col1AdmissionDocId
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

    Private Sub DGL1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DGL1.CellValidating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            With DGL1
                Select Case .CurrentCell.ColumnIndex
                    Case Col1IsPresent
                        If DGL1.Item(Col1IsLeaveTaken, mRowIndex).Value Is Nothing Then DGL1.Item(Col1IsLeaveTaken, mRowIndex).Value = ""

                        If DGL1.Item(mColumnIndex, e.RowIndex).Value.ToString = AgLibrary.ClsConstant.StrCheckedValue And AgL.StrCmp(DGL1.Item(Col1IsLeaveTaken, e.RowIndex).Value.ToString, "Yes") Then
                            If MsgBox("" & DGL1.Item(Col1AdmissionDocId, mRowIndex).Value & " is On Leave!..." & vbCrLf & "Do You Want to Continue?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then
                                e.Cancel = True : Exit Sub
                            End If
                        End If
                End Select
            End With

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
        TxtSite_Code.Enter, TxtClassSection.Enter, TxtRemark.Enter, TxtClassSection.Enter, TxtA_Date.Enter, TxtClassRoom.Enter, _
        TxtTeacher.Enter, TxtSubject.Enter, TxtTimeSlot.Enter, TxtClassSectionSubSection.Enter, TxtSubjectType.Enter

        Dim bStrFilter As String = ""

        Try
            Select Case sender.name
                Case TxtTeacher.Name
                    bStrFilter = " 1=1 "

                    If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
                        bStrFilter += " And LogInUser = '" & AgL.PubUserName & "' "
                    End If

                    TxtTeacher.AgRowFilter = bStrFilter

                Case TxtClassSectionSubSection.Name
                    TxtClassSectionSubSection.AgRowFilter = " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " "

                Case TxtSubject.Name
                    TxtSubject.AgRowFilter = " [Subject Type] = " & AgL.Chk_Text(TxtSubjectType.Text) & " "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtRemark.Validating, TxtClassSection.Validating, TxtA_Date.Validating, TxtClassRoom.Validating, _
        TxtTeacher.Validating, TxtSubject.Validating, TxtTimeSlot.Validating, TxtClassSectionSubSection.Validating

        Try
            Select Case sender.NAME
                Case TxtA_Date.Name
                    If TxtA_Date.Text.ToString.Trim = "" Then TxtA_Date.Text = AgL.PubLoginDate
                    TxtA_Date.Text = AgL.RetFinancialYearDate(TxtA_Date.Text.ToString)

                Case TxtClassSectionSubSection.Name
                    Call Validating_Controls(sender)

                Case TxtSubject.Name
                    Call Validating_Controls(sender)

            End Select

            If Not AgL.StrCmp(TxtClassSection.AgSelectedValue, LblClassSectionSubSection.Tag) Then
                LblClassSectionSubSection.Tag = ""
                TxtClassSectionSubSection.AgSelectedValue = ""
            End If

            If Not AgL.StrCmp(TxtSubjectType.Text, LblSubject.Tag) Then
                LblSubject.Tag = ""
                TxtSubject.AgSelectedValue = ""
            End If

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1AdmissionDocId, I).Value Is Nothing Then .Item(Col1AdmissionDocId, I).Value = ""
                If .Item(Col1IsPresent, I).Value Is Nothing Then .Item(Col1IsPresent, I).Value = ""
                If .Item(Col1IsPresent, I).Value.ToString.Trim = "" Then .Item(Col1IsPresent, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
            Next
        End With
    End Sub

    Private Sub ProcSetPresentCellColour(ByVal IntRowIndex As Integer)
        Try
            If DGL1.Item(Col1IsPresent, IntRowIndex).Value Is Nothing Then DGL1.Item(Col1IsPresent, IntRowIndex).Value = ""
            If DGL1.Item(Col1IsPresent, IntRowIndex).Value.ToString.Trim = "" Then DGL1.Item(Col1IsPresent, IntRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue


            DGL1.CurrentCell = DGL1(Col1IsPresent, IntRowIndex)

            DGL1.CurrentCell.Style.BackColor = Color.White
            If DGL1.Item(Col1IsPresent, IntRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                DGL1.CurrentCell.Style.ForeColor = Color.Blue
            Else
                DGL1.CurrentCell.Style.ForeColor = Color.Red
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function CommonData_Validation() As Boolean
        Try
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtA_Date, "Attendance Date") Then Exit Function
            If AgL.RequiredField(TxtTimeSlot, "Time Slot") Then Exit Function
            If AgL.RequiredField(TxtClassSection, "Class/Section") Then Exit Function
            If AgL.RequiredField(TxtClassRoom, "Class Room") Then Exit Function
            If AgL.RequiredField(TxtSubjectType, "Subject Type") Then Exit Function
            If AgL.RequiredField(TxtTeacher, "Teacher") Then Exit Function
            If AgL.RequiredField(TxtSubject, "Subject") Then Exit Function

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.PubIsUserAdmin) Then
                If FunIsDateLock(TxtA_Date.Text) Then
                    MsgBox("Permission Denied!...", MsgBoxStyle.Information, "Date Lock")
                    Topctrl1.FButtonClick(14, True)
                    Exit Function
                End If
            End If


            If Not AgL.StrCmp(TxtClassSection.AgSelectedValue, LblClassSectionSubSection.Tag) And TxtClassSectionSubSection.Text.Trim <> "" Then
                MsgBox("Please Check Sub-Section Detail!...") : TxtClassSectionSubSection.Focus() : Exit Function
            End If

            If Not AgL.StrCmp(TxtSubjectType.Text, LblSubject.Tag) Then
                MsgBox("Please Check Subject Detail!...") : TxtSubject.Focus() : Exit Function
            End If


            CommonData_Validation = True
        Catch ex As Exception
            CommonData_Validation = False
            MsgBox(ex.Message)
        End Try
    End Function

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            Call Calculation()

            If Not CommonData_Validation() Then Exit Function



            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1AdmissionDocId) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1AdmissionDocId & "") Then Exit Function

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1AdmissionDocId, I).Value.ToString.Trim <> "" Then

                        If AgL.StrCmp(.Item(Col1IsLeaveTaken, I).Value, "Yes") And _
                            AgL.StrCmp(.Item(Col1IsPresent, I).Value, AgLibrary.ClsConstant.StrCheckedValue) Then

                            If MsgBox("" & .Item(Col1AdmissionDocId, I).Value & " Is On Leave!..." & vbCrLf & "Want To Check Attendance?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Validation Check") = MsgBoxResult.No Then
                                DGL1.CurrentCell = DGL1(Col1IsPresent, I)
                                DGL1.Focus() : Exit Function
                            End If
                        End If
                    End If
                Next
            End With

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            mQry = "Select IsNull(count(*),0) Cnt " & _
                    " From Sch_StudentAttendance A " & _
                    " Where A.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " And " & _
                    " A.A_Date = " & AgL.ConvertDate(TxtA_Date.Text) & " And " & _
                    " A.TimeSlot = " & AgL.Chk_Text(TxtTimeSlot.AgSelectedValue) & " And " & _
                    " A.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " And " & _
                    " A.ClassSectionSubSection Is Null And " & _
                    " A.ClassRoom = " & AgL.Chk_Text(TxtClassRoom.AgSelectedValue) & " And " & _
                    " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " A.Code <> '" & mSearchCode & "' ") & " "
            AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
            If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Attendance Already Exist For Class/Section : " & TxtClassSection.Text & "!") : TxtA_Date.Focus() : Exit Function

            mQry = "Select IsNull(count(*),0) Cnt " & _
                    " From Sch_StudentAttendance A " & _
                    " Where A.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " And " & _
                    " A.A_Date = " & AgL.ConvertDate(TxtA_Date.Text) & " And " & _
                    " A.TimeSlot = " & AgL.Chk_Text(TxtTimeSlot.AgSelectedValue) & " And " & _
                    " A.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " And " & _
                    " A.ClassSectionSubSection = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " And " & _
                    " A.ClassRoom = " & AgL.Chk_Text(TxtClassRoom.AgSelectedValue) & " And " & _
                    " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " A.Code <> '" & mSearchCode & "' ") & " "
            AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
            If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Attendance Already Exist!") : TxtA_Date.Focus() : Exit Function

            mQry = "Select IsNull(count(*),0) Cnt " & _
                    " From Sch_StudentAttendance A " & _
                    " Where A.A_Date = " & AgL.ConvertDate(TxtA_Date.Text) & " And " & _
                    " A.TimeSlot = " & AgL.Chk_Text(TxtTimeSlot.AgSelectedValue) & " And " & _
                    " A.Teacher = " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & " And " & _
                    " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " A.Code <> '" & mSearchCode & "' ") & " "
            AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
            If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Teacher Is Not Free For Selected Time Slot!") : TxtTeacher.Focus() : Exit Function

            mQry = "Select IsNull(count(*),0) Cnt " & _
                    " From Sch_StudentAttendance A " & _
                    " Where A.A_Date = " & AgL.ConvertDate(TxtA_Date.Text) & " And " & _
                    " A.TimeSlot = " & AgL.Chk_Text(TxtTimeSlot.AgSelectedValue) & " And " & _
                    " A.Teacher = " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & " And " & _
                    " A.Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & " And " & _
                    " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " A.Code <> '" & mSearchCode & "' ") & " "
            AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
            If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Teacher Is Not Free For Selected Subject!") : TxtTeacher.Focus() : Exit Function


            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetMaxId("Sch_StudentAttendance", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)
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

        If mTmTeacher.Trim = "" Then
            If TxtTeacher.AgHelpDataSet IsNot Nothing Then
                DrTemp = TxtTeacher.AgHelpDataSet.Tables(0).Select("LogInUser = '" & AgL.PubUserName & "'")
                If DrTemp.Length > 0 Then
                    TxtTeacher.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                Else
                    MsgBox("Please Define Login User in Teacher Master!...")
                End If
                DrTemp = Nothing
            End If
        End If

        If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then
            TxtTeacher.Enabled = False
        End If

        TxtA_Date.Focus()
    End Sub


    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillStudent.Click
        Try
            Select Case sender.name
                Case BtnFillStudent.Name
                    Call ProcFillStudent()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillStudent()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim bCondStr$ = "", bStrViewClassSectionSemesterAdmission$ = "", bStrViewOpenElectiveSemesterAdmission$ = "", bStrTempViewSectionAdmission$ = ""
        Dim bBlnIsOpenElectiveSection As Boolean = False
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If Not CommonData_Validation() Then Exit Sub


            bStrViewClassSectionSemesterAdmission = "SELECT vCsa3.* " & _
                                                    " FROM (SELECT vCsa1.* FROM ViewSch_ClassSectionSemesterAdmission vCsa1 " & _
                                                    " INNER JOIN " & _
                                                    " (SELECT vCsa.ClassSection , Max(vCsa.SemesterStartDate) AS SemesterStartDate " & _
                                                    " FROM ViewSch_ClassSectionSemesterAdmission vCsa  " & _
                                                    " GROUP BY vCsa.ClassSection  " & _
                                                    " ) vCsa2 ON vCsa1.ClassSection = vCsa2.ClassSection AND vCsa1.SemesterStartDate = vCsa2.SemesterStartDate) vCsa3 " & _
                                                    " WHERE vCsa3.SectionLeftOnDate IS NULL "

            bStrViewOpenElectiveSemesterAdmission = "SELECT vOCsa3.* " & _
                                                    " FROM (SELECT vOCsa1.* FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa1 " & _
                                                    " INNER JOIN " & _
                                                    " (SELECT vOCsa.ClassSection , Max(vOCsa.SemesterStartDate) AS SemesterStartDate " & _
                                                    " FROM ViewSch_ClassSectionOpenElectiveSemesterAdmission vOCsa  " & _
                                                    " GROUP BY vOCsa.ClassSection  " & _
                                                    " ) vOCsa2 ON vOCsa1.ClassSection = vOCsa2.ClassSection AND vOCsa1.SemesterStartDate = vOCsa2.SemesterStartDate) vOCsa3 " & _
                                                    " WHERE vOCsa3.SectionLeftOnDate IS NULL "



            mQry = "SELECT S.IsOpenElectiveSection FROM Sch_ClassSection S WHERE S.Code = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & "  "
            bBlnIsOpenElectiveSection = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)

            If bBlnIsOpenElectiveSection Then
                bStrTempViewSectionAdmission = bStrViewOpenElectiveSemesterAdmission
            Else
                bStrTempViewSectionAdmission = bStrViewClassSectionSemesterAdmission
            End If

            bCondStr = " WHERE " & AgL.PubSiteCondition("Csa.Site_Code", TxtSite_Code.AgSelectedValue) & " And " & _
                        " Csa.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " AND " & _
                        " Ads.SubjectCode = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & " "

            bCondStr += " AND A.Status <> '" & Academic_ProjLib.ClsMain.AdmissionStatus_Ex & "' AND A.LeavingDate IS NULL "

            bCondStr += " And A.V_Date <= " & AgL.ConvertDate(TxtA_Date.Text) & " "

            If TxtClassSectionSubSection.Text.Trim <> "" Then
                bCondStr += " And Csa.ClassSectionSubSectionCode = " & AgL.Chk_Text(TxtClassSectionSubSection.AgSelectedValue) & " "
            End If


            mQry = "SELECT Csa.AdmissionDocId , Csa.AdmissionID , vAp.FromStreamYearSemester As StreamYearSemester, Ads.SubjectCode, " & _
                   " Convert(BIT,CASE WHEN V1.AdmissionDocId IS NULL THEN 0 ELSE 1 END) AS IsLeaveTaken " & _
                   " FROM (SELECT * FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) vAp " & _
                   " LEFT JOIN (" & bStrTempViewSectionAdmission & ") Csa On vAp.AdmissionDocId = Csa.AdmissionDocId " & _
                   " LEFT JOIN ViewSch_Admission A ON A.DocId = vAp.AdmissionDocId " & _
                   " LEFT JOIN ViewSch_AdmissionSubject Ads ON Csa.AdmissionDocId = Ads.AdmissionDocId AND vAp.FromStreamYearSemester = Ads.StreamYearSemester " & _
                   " LEFT JOIN ViewSch_StreamYearSemester Sem ON Sem.Code = vAp.FromStreamYearSemester " & _
                   " LEFT JOIN ( " & _
                   "           SELECT DISTINCT " & AgL.ConvertDate(TxtA_Date.Text) & " AS LeaveDate, L.AdmissionDocId  " & _
                   "           FROM Sch_StudentLeave L " & _
                   "           WHERE " & AgL.ConvertDate(TxtA_Date.Text) & " BETWEEN L.FromDate AND L.ToDate " & _
                   " ) AS V1 ON A.DocId = V1.AdmissionDocId " & _
                   " " & bCondStr & "  " & _
                   " Order By Sem.StreamManualCode, Csa.StudentName "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If .Rows.Count > 0 Then
                    TxtClassSection.Enabled = False
                    TxtSubject.Enabled = False

                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL1.Item(Col1AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))
                        DGL1.Item(Col1IsPresent, I).Value = IIf(AgL.VNull(.Rows(I)("IsLeaveTaken")), AgLibrary.ClsConstant.StrUnCheckedValue, AgLibrary.ClsConstant.StrCheckedValue)
                        DGL1.Item(Col1IsLeaveTaken, I).Value = IIf(AgL.VNull(.Rows(I)("IsLeaveTaken")), "Yes", "No")
                    Next I
                Else
                    TxtClassSection.Enabled = True
                    TxtSubject.Enabled = True

                    MsgBox("No Student Record Exists For Attendance!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
            Call Calculation()
        End Try
    End Sub

    Private Sub Validating_Controls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtClassSectionSubSection.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    LblClassSectionSubSection.Tag = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        LblClassSectionSubSection.Tag = AgL.XNull(DrTemp(0)("ClassSection"))
                    End If
                End If
                DrTemp = Nothing

            Case TxtSubject.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    LblSubject.Tag = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        LblSubject.Tag = AgL.XNull(DrTemp(0)("Subject Type"))
                    End If
                End If
                DrTemp = Nothing

        End Select

    End Sub
End Class

