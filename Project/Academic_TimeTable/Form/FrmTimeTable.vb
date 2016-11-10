Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmTimeTable
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1TimeSlot As Byte = 1
    Private Const Col1ClassSectionSubSection As Byte = 2
    Private Const Col1Subject As Byte = 3
    Private Const Col1Teacher As Byte = 4
    Private Const Col1SubjectCode As Byte = 5

    Dim mTeacherHelpFlag As Boolean = False

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
        ''================< Time Table Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1TimeSlot", 100, 8, "Time Slot", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1ClassSectionSubSection", 100, 8, "Sub-Section", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1Subject", 320, 8, "Subject", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1Teacher", 250, 8, "Teacher", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1SubjectCode", 320, 8, "Subject Code", False, True, False)
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
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("T.Site_Code", AgL.PubSiteCode) & " "

            mQry = "Select T.Code As SearchCode " & _
                    " From TT_TimeTable T " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code , S.ManualCode  FROM Sch_Session S ORDER BY S.StartDate "
            TxtSession.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ClassSectionDesc, S.SessionCode, S.SessionProgramme As SessionProgrammeCode " & _
                    " FROM ViewSch_ClassSection S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY S.ClassSectionDesc "
            TxtClassSection.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT W.Code , W.ManualCode  FROM Sch_WeekDay W ORDER BY W.Code "
            TxtWeekDay.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT T.Code, V1.ClassSectionDesc [Class/Section], D.Description AS [Week Day], T.ApplyDate , T.Site_Code, V1.SessionProgramme As SessionProgrammeCode " & _
                    " FROM TT_TimeTable T " & _
                    " LEFT JOIN ViewSch_ClassSection V1 ON T.ClassSection = V1.Code  " & _
                    " LEFT JOIN Sch_WeekDay D ON T.WeekDay = D.Code " & _
                    " WHERE " & AgL.PubSiteCondition("T.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY V1.ClassSectionDesc , T.ApplyDate Desc "
            TxtCopyFrom.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select S.Code As Code, S.Description As [Time Slot], " & AgL.ConvertTimeField("S.StartTime") & " As [Start Time], " & _
                    " " & AgL.ConvertTimeField("S.EndTime") & " As [End Time], S.Duration as [Duration]  " & _
                    " From  Sch_TimeSlot S "
            DGL1.AgHelpDataSet(Col1TimeSlot) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT V1.Code , V1.ClassSectionSubSectionDesc , V1.ClassSection " & _
                    " FROM ViewSch_ClassSectionSubSection V1 " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By V1.V1.ClassSectionSubSectionDesc "
            DGL1.AgHelpDataSet(Col1ClassSectionSubSection, 1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code , S.Description AS Subject, S.SubjectType [Subject Type] " & _
                    " FROM Sch_Subject S " & _
                    " ORDER BY S.Description "
            DGL1.AgHelpDataSet(Col1Subject) = AgL.FillData(mQry, AgL.GCn)

            Call IniTeacherHelp()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub IniTeacherHelp(Optional ByVal bRowIndex As Integer = -1)
        Dim bView1Qry$ = "", bView2Qry$ = ""

        mQry = ""

        If bRowIndex < 0 Then
            If mTeacherHelpFlag = False Then
                mQry = "SELECT E.SubCode AS Code, Sg.Name " & _
                        " FROM Pay_Employee E " & _
                        " LEFT JOIN SubGroup Sg ON E.SubCode = Sg.SubCode " & _
                        " WHERE (IsNull(E.IsTeachingStaff,0)<>0 or IsNull(E.CanTakeClass,0)<>0) And " & _
                        " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                        " ORDER BY Sg.Name "
                mTeacherHelpFlag = True
            End If
        Else
            mTeacherHelpFlag = False
            If DGL1.Item(Col1SubjectCode, bRowIndex).Value Is Nothing Then DGL1.Item(Col1SubjectCode, bRowIndex).Value = ""

            bView1Qry = FunGetTimeTableQuery(TxtApplyDate.Text, Val(TxtWeekDay.AgSelectedValue))
            bView2Qry = "SELECT T1.Teacher FROM (" & bView1Qry & ") V1 Left Join TT_TimeTable1 T1 On V1.Code = T1.Code WHERE T1.TimeSlot = '" & DGL1.AgSelectedValue(Col1TimeSlot, bRowIndex) & "' And " & IIf(Topctrl1.Mode = "Add", " 1=1 ", " V1.Code <> '" & mSearchCode & "' ") & " " & _
                           " UNION ALL " & _
                           " SELECT A1.Employee AS Teacher FROM Pay_DayAttendance A LEFT JOIN Pay_DayAttendance1 A1 ON A.Code = A1.Code WHERE A.A_Date = " & AgL.ConvertDate(TxtApplyDate.Text) & " AND A1.IsPresent = 0 " & _
                           " UNION ALL " & _
                           " SELECT R1.ReallocateTeacher AS Teacher FROM TT_ReallocateTeacher R LEFT JOIN TT_ReallocateTeacher1 R1 ON R.Code = R1.Code WHERE R.ReallocationDate = " & AgL.ConvertDate(TxtApplyDate.Text) & " AND R1.TimeSlot = '" & DGL1.AgSelectedValue(Col1TimeSlot, bRowIndex) & "' "
            bView2Qry = " Select Distinct V2.Teacher From (" & bView2Qry & ") V2 "

            mQry = "SELECT T.SubCode As Code, Sg.Name " & _
                    " FROM Pay_TeacherSubject T " & _
                    " LEFT JOIN SubGroup Sg ON T.SubCode = Sg.SubCode " & _
                    " WHERE T.Subject = '" & DGL1.Item(Col1SubjectCode, bRowIndex).Value & "' And " & _
                    " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", TxtSite_Code.AgSelectedValue, "Sg.CommonAc") & " And " & _
                    " T.SubCode Not In ( " & bView2Qry & " ) " & _
                    " ORDER BY Sg.Name "

        End If
        If mQry.Trim <> "" Then DGL1.AgHelpDataSet(Col1Teacher) = AgL.FillData(mQry, AgL.GCn)
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

                    AgL.Dman_ExecuteNonQry("Delete From TT_TimeTable1 Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From TT_TimeTable Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        TxtApplyDate.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("T.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQry = "SELECT T.Code AS SearchCode, S.Name AS [Site Name], " & AgL.ConvertDateField("T.ApplyDate") & " As [Apply Date] , " & _
                                " Cs.ClassSectionDesc [Class/Section], " & _
                                " W.Description " & _
                                " FROM TT_TimeTable T " & _
                                " LEFT JOIN SiteMast S on T.Site_Code = S.Code  " & _
                                " LEFT JOIN Sch_WeekDay W ON T.WeekDay = W.Code  " & _
                                " LEFT JOIN ViewSch_ClassSection Cs ON T.ClassSection = Cs.Code  " & _
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
        mTeacherHelpFlag = False
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
                mQry = "insert into TT_TimeTable ( Code, ClassSection, WeekDay, ApplyDate, Remark, IsAllTimeSlot, " & _
                        " Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE ) " & _
                        " values ( " & _
                        " '" & mSearchCode & "', " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & IIf(AgL.VNull(TxtWeekDay.AgSelectedValue) = 0, "Null", Val(TxtWeekDay.AgSelectedValue)) & ", " & _
                        " " & AgL.ConvertDate(TxtApplyDate.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " " & IIf(AgL.StrCmp(TxtIsAllTimeSlot.Text, "Yes"), 1, 0) & "," & _
                        " '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update TT_TimeTable " & _
                        " Set  " & _
                        " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & _
                        " WeekDay = " & IIf(AgL.VNull(TxtWeekDay.AgSelectedValue) = 0, "Null", Val(TxtWeekDay.AgSelectedValue)) & ", " & _
                        " ApplyDate = " & AgL.ConvertDate(TxtApplyDate.Text) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " IsAllTimeSlot = " & IIf(AgL.StrCmp(TxtIsAllTimeSlot.Text, "Yes"), 1, 0) & "," & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE Code = '" & mSearchCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            If Topctrl1.Mode = "Edit" Then
                AgL.Dman_ExecuteNonQry("Delete From TT_TimeTable1 Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1TimeSlot, I).Value <> "" And .Item(Col1Subject, I).Value <> "" And .Item(Col1Teacher, I).Value <> "" Then
                        bSr += 1

                        mQry = "insert into TT_TimeTable1 ( Code, Sr, TimeSlot, ClassSectionSubSection, Subject, Teacher ) " & _
                                " VALUES ( '" & mSearchCode & "', " & bSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1TimeSlot, I)) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1ClassSectionSubSection, I)) & "," & AgL.Chk_Text(.AgSelectedValue(Col1Subject, I)) & "," & AgL.Chk_Text(.AgSelectedValue(Col1Teacher, I)) & " )"

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

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

                Topctrl1.FButtonClick(0)

                'If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    Call PrintDocument(mDocId)
                'End If

                Exit Sub
            Else
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
                Call IniTeacherHelp()

                mQry = "Select T.*, C.SessionCode, C.SessionProgramme As SessionProgrammeCode " & _
                        " From TT_TimeTable T " & _
                        " Left Join ViewSch_ClassSection C On T.ClassSection = C.Code " & _
                        " Where T.Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtSession.AgSelectedValue = AgL.XNull(.Rows(0)("SessionCode"))
                        LblClassSection.Tag = AgL.XNull(.Rows(0)("SessionCode"))
                        LblClassSectionReq.Tag = ""
                        TxtClassSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSection"))
                        TxtWeekDay.AgSelectedValue = AgL.VNull(.Rows(0)("WeekDay"))
                        TxtApplyDate.Text = Format(AgL.XNull(.Rows(0)("ApplyDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtIsAllTimeSlot.Text = IIf(AgL.VNull(.Rows(0)("IsAllTimeSlot")), "Yes", "No")

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = " Select V1.TimeSlot AS TimeSlotCode, " & _
                        " V1.ClassSectionSubSection, " & _
                        " V1.Teacher, " & _
                        " V1.Subject, " & _
                        " Ts.StartTime " & _
                        " From (SELECT T1.* FROM TT_TimeTable1 T1 With (NoLock) WHERE T1.Code = '" & mSearchCode & "') V1 " & _
                        " LEFT JOIN Sch_TimeSlot Ts With (NoLock) ON V1.TimeSlot = Ts.Code " & _
                        " UNION ALL " & _
                        " Select Ts.Code AS TimeSlotCode, " & _
                        " Null As ClassSectionSubSection, " & _
                        " Null As Teacher, " & _
                        " Null As Subject, " & _
                        " Ts.StartTime " & _
                        " From Sch_TimeSlot Ts With (NoLock) " & _
                        " LEFT JOIN (SELECT T1.* FROM TT_TimeTable1 T1 With (NoLock) WHERE T1.Code = '" & mSearchCode & "') V1 ON V1.TimeSlot = Ts.Code " & _
                        " Where V1.TimeSlot Is Null " & _
                        " And " & IIf(AgL.StrCmp(TxtIsAllTimeSlot.Text, "Yes"), " " & AgL.PubSiteCondition("Ts.Site_Code", TxtSite_Code.AgSelectedValue) & " ", " 1=1 ") & "  " & _
                        " ORDER BY StartTime "

                DsTemp = AgL.FillData(mQry, AgL.GcnRead)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1TimeSlot, I) = AgL.XNull(.Rows(I)("TimeSlotCode"))
                            DGL1.AgSelectedValue(Col1ClassSectionSubSection, I) = AgL.XNull(.Rows(I)("ClassSectionSubSection"))
                            DGL1.AgSelectedValue(Col1Teacher, I) = AgL.XNull(.Rows(I)("Teacher"))
                            DGL1.AgSelectedValue(Col1Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                            DGL1.Item(Col1SubjectCode, I).Value = AgL.XNull(.Rows(I)("Subject"))
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
        TxtIsAllTimeSlot.Text = "Yes"

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub



    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False

        If Topctrl1.Mode = "Edit" Then
            TxtSession.Enabled = False
            TxtClassSection.Enabled = False
            TxtWeekDay.Enabled = False
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
                Case Col1ClassSectionSubSection
                    DGL1.AgRowFilter(Col1ClassSectionSubSection) = " ClassSection = '" & TxtClassSection.AgSelectedValue & "'"

                Case Col1Teacher
                    If DGL1.Item(Col1SubjectCode, mRowIndex).Value Is Nothing Then DGL1.Item(Col1SubjectCode, mRowIndex).Value = ""
                    Call IniTeacherHelp(mRowIndex)
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
                '<Executable Code>
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
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
                Case Col1Subject                    
                    If DGL1.Item(Col1SubjectCode, mRowIndex).Value Is Nothing Then DGL1.Item(Col1SubjectCode, mRowIndex).Value = ""

                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        DGL1.Item(Col1SubjectCode, mRowIndex).Value = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                If Not AgL.StrCmp(DGL1.Item(Col1SubjectCode, mRowIndex).Value, AgL.XNull(.Item("Code", .CurrentCell.RowIndex).Value)) Then
                                    DGL1.AgSelectedValue(Col1Teacher, mRowIndex) = ""
                                    DGL1.Item(Col1SubjectCode, mRowIndex).Value = AgL.XNull(.Item("Code", .CurrentCell.RowIndex).Value)
                                End If

                                If TxtSession.Enabled Then TxtSession.Enabled = False
                                If TxtClassSection.Enabled Then TxtClassSection.Enabled = False
                            End With
                        End If
                    End If

                Case Col1Teacher
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

        If Topctrl1.Mode <> "Browse" And DGL1.Rows.Count = 1 Then
            If DGL1.Item(Col1Subject, 0).Value Is Nothing Then DGL1.Item(Col1Subject, 0).Value = ""
            If Topctrl1.Mode = "Add" Then If TxtSession.Enabled = False Then TxtSession.Enabled = True
            If TxtClassSection.Enabled = False Then TxtClassSection.Enabled = True
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
        TxtSite_Code.Enter, TxtClassSection.Enter, TxtRemark.Enter, TxtApplyDate.Enter, _
        TxtSession.Enter, TxtRemark.Enter, TxtWeekDay.Enter, TxtCopyFrom.Enter

        Try
            Select Case sender.name
                Case TxtClassSection.Name
                    TxtClassSection.AgRowFilter = "SessionCode = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & " "

                Case TxtCopyFrom.Name
                    TxtCopyFrom.AgRowFilter = "SessionProgrammeCode = " & AgL.Chk_Text(LblClassSectionReq.Tag) & ""
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtRemark.Validating, TxtClassSection.Validating, TxtApplyDate.Validating, TxtRemark.Validating, _
        TxtSession.Validating, TxtWeekDay.Validating, TxtCopyFrom.Validating

        Try
            Select Case sender.NAME
                Case TxtApplyDate.Name
                    If TxtApplyDate.Text.ToString.Trim = "" Then TxtApplyDate.Text = AgL.PubLoginDate

                Case TxtClassSection.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblClassSection.Tag = ""
                        LblClassSectionReq.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblClassSection.Tag = AgL.XNull(.Item("SessionCode", .CurrentCell.RowIndex).Value)
                                LblClassSectionReq.Tag = AgL.XNull(.Item("SessionProgrammeCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtCopyFrom.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblCopyFrom.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblCopyFrom.Tag = AgL.XNull(.Item("SessionProgrammeCode", .CurrentCell.RowIndex).Value)
                                If AgL.StrCmp(LblCopyFrom.Tag, LblClassSectionReq.Tag) Then Call ProcCopyDaySchedule(TxtCopyFrom.AgSelectedValue)
                            End With
                        End If
                    End If

            End Select

            If Not AgL.StrCmp(LblClassSection.Tag, TxtSession.AgSelectedValue) Then
                TxtClassSection.AgSelectedValue = "" : LblClassSection.Tag = ""
            End If

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        'With DGL1
        '    For I = 0 To .Rows.Count - 1
        '        If .Item(Col1AdmissionDocId, I).Value Is Nothing Then .Item(Col1AdmissionDocId, I).Value = ""
        '        If .Item(Col1YesNo, I).Value Is Nothing Then .Item(Col1YesNo, I).Value = ""

        '        If .Item(Col1AdmissionDocId, I).Value <> "" And AgL.StrCmp(.Item(Col1YesNo, I).Value.ToString, "Yes") Then
        '            TxtTotalStudent.Text = Val(TxtTotalStudent.Text) + 1
        '        End If
        '    Next
        'End With
    End Sub


    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtApplyDate, "Apply Date") Then Exit Function
            If AgL.RequiredField(TxtSession, "Section") Then Exit Function
            If AgL.RequiredField(TxtClassSection, "Class/Section") Then Exit Function
            If AgL.RequiredField(TxtWeekDay, "Week Day") Then Exit Function

            If Not AgL.StrCmp(LblClassSection.Tag, TxtSession.AgSelectedValue) Then
                MsgBox("Class/Section Is Not Belonging To Selected Session!...")
                TxtClassSection.Focus() : Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1Subject) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1TimeSlot & "," & Col1ClassSectionSubSection & "") Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1TimeSlot & "," & Col1Teacher & "") Then Exit Function

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1TimeSlot, I).Value Is Nothing Then .Item(Col1TimeSlot, I).Value = ""
                    If .Item(Col1Subject, I).Value Is Nothing Then .Item(Col1Subject, I).Value = ""
                    If .Item(Col1ClassSectionSubSection, I).Value Is Nothing Then .Item(Col1ClassSectionSubSection, I).Value = ""

                    If .Item(Col1TimeSlot, I).Value <> "" Then
                        For J = I + 1 To .Rows.Count - 1
                            If AgL.StrCmp(.Item(Col1TimeSlot, I).Value, .Item(Col1TimeSlot, J).Value) Then
                                If .Item(Col1ClassSectionSubSection, I).Value.ToString.Trim = "" Then
                                    MsgBox("Sub-Section Is Not Required At Row No. " & .Item(Col_SNo, J).Value & "")
                                    DGL1.CurrentCell = DGL1(Col1ClassSectionSubSection, J) : DGL1.Focus() : Exit Function
                                ElseIf .Item(Col1ClassSectionSubSection, J).Value.ToString.Trim = "" Then
                                    MsgBox("Sub-Section Is Not Required At Row No. " & .Item(Col_SNo, I).Value & "")
                                    DGL1.CurrentCell = DGL1(Col1ClassSectionSubSection, I) : DGL1.Focus() : Exit Function
                                End If
                            End If
                        Next
                    End If
                Next
            End With

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            mQry = "SELECT IsNull(count(*),0) Cnt " & _
                    " FROM TT_TimeTable T " & _
                    " WHERE " & _
                    " T.ApplyDate = " & AgL.ConvertDate(TxtApplyDate.Text) & " And " & _
                    " T.ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " And " & _
                    " T.WeekDay = " & Val(TxtWeekDay.AgSelectedValue) & " And " & _
                    " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " T.Code <> '" & mSearchCode & "' ") & " "
            AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
            If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Time Table Already Exists For Selected Parameters!...") : TxtApplyDate.Focus() : Exit Function


            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetMaxId("TT_TimeTable", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)
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
        TxtIsAllTimeSlot.Text = "Yes"
        Call ProcFillTimeSlot()
        TxtSession.Focus()
    End Sub


    Private Sub ProcFillTimeSlot()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim mCondStr$ = " Where 1=1 "
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If Not AgL.StrCmp(TxtIsAllTimeSlot.Text, "Yes") Then
                mCondStr += " And " & AgL.PubSiteCondition("T.Site_Code", TxtSite_Code.AgSelectedValue) & " "
            End If


            mQry = "SELECT T.Code As TimeSlot FROM Sch_TimeSlot T " & mCondStr & " ORDER BY StartTime "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                        DGL1.AgSelectedValue(Col1TimeSlot, I) = AgL.XNull(.Rows(I)("TimeSlot"))
                    Next I
                Else
                    MsgBox("Please Create Time Slots For Time Table!...")
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub ProcCopyDaySchedule(ByVal bTimeTableCode As String)
        Dim DtTemp As DataTable
        Dim I As Integer
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            mQry = "Select V1.* , Ts.Code AS TimeSlotCode " & _
                    " From Sch_TimeSlot Ts " & _
                    " LEFT JOIN (SELECT * FROM TT_TimeTable1 T1 WHERE T1.Code = '" & bTimeTableCode & "') V1 ON V1.TimeSlot = Ts.Code  " & _
                    " ORDER BY Ts.StartTime"
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                        DGL1.AgSelectedValue(Col1TimeSlot, I) = AgL.XNull(.Rows(I)("TimeSlotCode"))
                        DGL1.AgSelectedValue(Col1ClassSectionSubSection, I) = AgL.XNull(.Rows(I)("ClassSectionSubSection"))
                        DGL1.AgSelectedValue(Col1Teacher, I) = AgL.XNull(.Rows(I)("Teacher"))
                        DGL1.AgSelectedValue(Col1Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                        DGL1.Item(Col1SubjectCode, I).Value = AgL.XNull(.Rows(I)("Subject"))
                    Next I
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillTimeSlot.Click
        Try
            Select Case sender.name
                Case BtnFillTimeSlot.Name
                    If MsgBox("Are You Sure To Fill Time Slot?" & vbCrLf & "This Will Make Empty Day Schedule Grid!...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub
                    Call ProcFillTimeSlot()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class

