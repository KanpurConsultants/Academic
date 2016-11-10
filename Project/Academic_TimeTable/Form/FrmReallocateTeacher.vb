Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmReallocateTeacher
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1TimeSlot As Byte = 1
    Private Const Col1ClassSection As Byte = 2
    Private Const Col1ClassSectionSubSection As Byte = 3
    Private Const Col1TimeTableSubject As Byte = 4
    Private Const Col1IsEngageTimeSlot As Byte = 5
    Private Const Col1Subject As Byte = 6
    Private Const Col1ReallocateTeacher As Byte = 7
    Private Const Col1SubjectCode As Byte = 8
    Private Const Col1TimeTable As Byte = 9

    Dim mTeacherHelpFlag As Boolean = False, mReallocateTeacherHelpFlag As Boolean = False

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
            .AddAgTextColumn(DGL1, "DGL1SNo", 30, 5, "S. No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1TimeSlot", 80, 8, "Time Slot", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1ClassSection", 90, 8, "Class/Section", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1ClassSectionSubSection", 80, 8, "Sub-Section", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1TimeTableSubject", 200, 8, "Scheduled Subject", True, True, False)
            .AddAgCheckColumn(DGL1, "Dgl1IsEngageTimeSlot", 60, "Engage Time", True)
            .AddAgTextColumn(DGL1, "Dgl1Subject", 200, 8, "Reallocated Subject", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1ReallocateTeacher", 190, 8, "Reallocated Teacher", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1SubjectCode", 320, 8, "Subject Code", False, True, False)
            .AddAgTextColumn(DGL1, "Dgl1TimeTable", 320, 8, "TimeTable Code", False, True, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = False
        DGL1.AgSkipReadOnlyColumns = True
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
            AgL.WinSetting(Me, 650, 1000, 0, 0)
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
                    " From TT_ReallocateTeacher T " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                          " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ClassSectionDesc, S.SessionCode " & _
                    " FROM ViewSch_ClassSection S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY S.ClassSectionDesc "
            DGL1.AgHelpDataSet(Col1ClassSection, 1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT W.Code , W.ManualCode  FROM Sch_WeekDay W ORDER BY W.Code "
            TxtWeekDay.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

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
            DGL1.AgHelpDataSet(Col1TimeTableSubject) = DGL1.AgHelpDataSet(Col1Subject).Copy

            Call IniTeacherHelp()
            Call IniReallocateTeacherHelp()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub IniReallocateTeacherHelp(Optional ByVal bRowIndex As Integer = -1)
        Dim bView1Qry$ = "", bView2Qry$ = "", bCondStr$ = ""

        mQry = ""
        If bRowIndex < 0 Then
            If mReallocateTeacherHelpFlag = False Then
                mQry = "SELECT E.SubCode AS Code, Sg.Name " & _
                        " FROM Pay_Employee E " & _
                        " LEFT JOIN SubGroup Sg ON E.SubCode = Sg.SubCode " & _
                        " WHERE (IsNull(E.IsTeachingStaff,0)<>0 or IsNull(E.CanTakeClass,0)<>0) And " & _
                        " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                        " ORDER BY Sg.Name "
                mReallocateTeacherHelpFlag = True
            End If
        Else
            mReallocateTeacherHelpFlag = False

            If DGL1.Item(Col1SubjectCode, bRowIndex).Value Is Nothing Then DGL1.Item(Col1SubjectCode, bRowIndex).Value = ""
            If DGL1.Item(Col1IsEngageTimeSlot, bRowIndex).Value Is Nothing Then DGL1.Item(Col1IsEngageTimeSlot, bRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue

            bView1Qry = FunGetTimeTableQuery(TxtReallocationDate.Text, Val(TxtWeekDay.AgSelectedValue))
            bView2Qry = "SELECT T1.Teacher FROM (" & bView1Qry & ") V1 Left Join TT_TimeTable1 T1 On V1.Code = T1.Code WHERE T1.TimeSlot = '" & DGL1.AgSelectedValue(Col1TimeSlot, bRowIndex) & "' " & _
                           " UNION ALL " & _
                           " SELECT A1.Employee AS Teacher FROM Pay_DayAttendance A LEFT JOIN Pay_DayAttendance1 A1 ON A.Code = A1.Code WHERE A.A_Date = " & AgL.ConvertDate(TxtReallocationDate.Text) & " AND IsNull(A1.IsPresent,0) = 0 " & _
                           " UNION ALL " & _
                           " SELECT R1.ReallocateTeacher AS Teacher FROM TT_ReallocateTeacher R LEFT JOIN TT_ReallocateTeacher1 R1 ON R.Code = R1.Code WHERE R.ReallocationDate = " & AgL.ConvertDate(TxtReallocationDate.Text) & " AND R1.TimeSlot = '" & DGL1.AgSelectedValue(Col1TimeSlot, bRowIndex) & "' And " & IIf(Topctrl1.Mode = "Add", " 1=1 ", " R.Code <> '" & mSearchCode & "' ") & " "
            bView2Qry = " Select Distinct V2.Teacher From (" & bView2Qry & ") V2 "


            mQry = "SELECT T.SubCode As Code, Sg.Name " & _
               " FROM Pay_TeacherSubject T " & _
               " LEFT JOIN SubGroup Sg ON T.SubCode = Sg.SubCode " & _
               " WHERE T.Subject = '" & DGL1.Item(Col1SubjectCode, bRowIndex).Value & "' And " & _
               " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", TxtSite_Code.AgSelectedValue, "Sg.CommonAc") & " And " & _
               " T.SubCode Not In ( " & bView2Qry & " ) " & _
               " ORDER BY Sg.Name "

        End If
        If mQry.Trim <> "" Then DGL1.AgHelpDataSet(Col1ReallocateTeacher) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Sub IniTeacherHelp(Optional ByVal bAllRecords As Boolean = True)
        mQry = ""

        If bAllRecords = True Then
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
            mQry = "SELECT A1.Employee AS Code, Sg.Name " & _
                    " FROM Pay_DayAttendance A " & _
                    " LEFT JOIN Pay_DayAttendance1 A1 ON A.Code = A1.Code " & _
                    " LEFT JOIN SubGroup Sg ON A1.Employee = Sg.SubCode " & _
                    " WHERE A.A_Date = " & AgL.ConvertDate(TxtReallocationDate.Text) & " AND IsNull(A1.IsPresent,0)=0 And " & _
                    " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                    " ORDER BY Sg.Name "

        End If
        If mQry.Trim <> "" Then TxtTeacher.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
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

                    AgL.Dman_ExecuteNonQry("Delete From TT_ReallocateTeacher1 Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From TT_ReallocateTeacher Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        TxtReallocationDate.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("T.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQry = "SELECT T.Code AS SearchCode, S.Name AS [Site Name], " & AgL.ConvertDateField("T.ReallocationDate") & " As [Reallocation Date] , " & _
                                " Sg.Name Teacher, W.Description As [Week Day] " & _
                                " FROM TT_ReallocateTeacher T " & _
                                " LEFT JOIN SiteMast S on T.Site_Code = S.Code  " & _
                                " LEFT JOIN Sch_WeekDay W ON Datepart(WeekDay, T.ReallocationDate) = W.Code  " & _
                                " LEFT JOIN SubGroup Sg ON T.Teacher = Sg.SubCode  " & _
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
        mTeacherHelpFlag = False : mReallocateTeacherHelpFlag = False
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
                mQry = "INSERT INTO TT_ReallocateTeacher (Code, ReallocationDate, Teacher, Remark, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', " & AgL.ConvertDate(TxtReallocationDate.Text) & ", " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtRemark.Text) & ", '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update TT_ReallocateTeacher " & _
                        " SET " & _
                        " ReallocationDate = " & AgL.ConvertDate(TxtReallocationDate.Text) & ", " & _
                        " Teacher = " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE Code = '" & mSearchCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            If Topctrl1.Mode = "Edit" Then
                AgL.Dman_ExecuteNonQry("Delete From TT_ReallocateTeacher1 Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1TimeSlot, I).Value <> "" And .Item(Col1Subject, I).Value <> "" Then
                        bSr += 1

                        mQry = "INSERT INTO TT_ReallocateTeacher1 ( " & _
                                " Code, Sr, TimeSlot, TimeTable, ClassSectionSubSection, Subject, ReallocateTeacher,IsEngageTimeSlot,TimeTableSubject ) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & bSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1TimeSlot, I)) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1TimeTable, I).Value) & ", " & AgL.Chk_Text(.AgSelectedValue(Col1ClassSectionSubSection, I)) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1Subject, I)) & ", " & AgL.Chk_Text(.AgSelectedValue(Col1ReallocateTeacher, I)) & ", " & _
                                " " & IIf(AgL.StrCmp(.Item(Col1IsEngageTimeSlot, I).Value, AgLibrary.ClsConstant.StrCheckedValue), 1, 0) & "," & AgL.Chk_Text(.AgSelectedValue(Col1TimeTableSubject, I)) & " )"

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
                Call IniReallocateTeacherHelp()

                mQry = "Select T.*, Datepart(WeekDay, T.ReallocationDate) As WeekDay " & _
                        " From TT_ReallocateTeacher T " & _
                        " Where T.Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtWeekDay.AgSelectedValue = AgL.VNull(.Rows(0)("WeekDay"))
                        TxtReallocationDate.Text = Format(AgL.XNull(.Rows(0)("ReallocationDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtTeacher.AgSelectedValue = AgL.XNull(.Rows(0)("Teacher"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select R1.*, T.ClassSection " & _
                        " From TT_ReallocateTeacher1 R1 " & _
                        " LEFT JOIN TT_TimeTable T ON R1.TimeTable = T.Code " & _
                        " LEFT JOIN Sch_TimeSlot Ts ON R1.TimeSlot = Ts.Code " & _
                        " Where R1.Code = '" & mSearchCode & "'" & _
                        " ORDER BY Ts.StartTime "
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1TimeSlot, I) = AgL.XNull(.Rows(I)("TimeSlot"))
                            DGL1.AgSelectedValue(Col1ClassSection, I) = AgL.XNull(.Rows(I)("ClassSection"))
                            DGL1.AgSelectedValue(Col1ClassSectionSubSection, I) = AgL.XNull(.Rows(I)("ClassSectionSubSection"))
                            DGL1.AgSelectedValue(Col1ReallocateTeacher, I) = AgL.XNull(.Rows(I)("ReallocateTeacher"))
                            DGL1.AgSelectedValue(Col1Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                            DGL1.Item(Col1SubjectCode, I).Value = AgL.XNull(.Rows(I)("Subject"))
                            DGL1.AgSelectedValue(Col1TimeTableSubject, I) = AgL.XNull(.Rows(I)("TimeTableSubject"))
                            DGL1.Item(Col1TimeTable, I).Value = AgL.XNull(.Rows(I)("TimeTable"))
                            If AgL.VNull(.Rows(I)("IsEngageTimeSlot")) Then
                                DGL1.Item(Col1IsEngageTimeSlot, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                            End If

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

        DGL1.RowCount = 1 : DGL1.Rows.Clear()

    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
        TxtWeekDay.Enabled = False

        If Topctrl1.Mode = "Edit" Then
            TxtReallocationDate.Enabled = False
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
                Case Col1ClassSectionSubSection
                    DGL1.AgRowFilter(Col1ClassSectionSubSection) = " ClassSection = '" & DGL1.AgSelectedValue(Col1ClassSection, mRowIndex) & "'"

                Case Col1ReallocateTeacher
                    If DGL1.Item(Col1SubjectCode, mRowIndex).Value Is Nothing Then DGL1.Item(Col1SubjectCode, mRowIndex).Value = ""
                    Call IniReallocateTeacherHelp(mRowIndex)
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

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1IsEngageTimeSlot
                    If AgL.StrCmp(DGL1.Item(Col1IsEngageTimeSlot, mRowIndex).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                        DGL1.Item(Col1Subject, mRowIndex).ReadOnly = False
                    Else
                        DGL1.Item(Col1Subject, mRowIndex).ReadOnly = True
                    End If
                    Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub
    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Subject
                    If DGL1.Item(Col1SubjectCode, mRowIndex).Value Is Nothing Then DGL1.Item(Col1SubjectCode, mRowIndex).Value = ""

                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        '<Executable Code>
                        DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                        DGL1.Item(Col1SubjectCode, mRowIndex).Value = ""
                    Else
                        If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                            DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
                            DGL1.Item(Col1SubjectCode, mRowIndex).Value = AgL.XNull(DrTemp(0)("Code"))
                        End If
                        DrTemp = Nothing
                    End If

                Case Col1ReallocateTeacher
                    If DGL1.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL1.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        DGL1.AgSelectedValue(mColumnIndex, mRowIndex) = ""
                    Else
                        If DGL1.AgHelpDataSet(mColumnIndex) IsNot Nothing Then
                            DrTemp = DGL1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(DGL1.AgSelectedValue(mColumnIndex, mRowIndex)) & "")
                            'DGL1.Item(Col1SubjectCode, mRowIndex).Value = AgL.VNull(DrTemp(0)("Code"))
                        End If
                        DrTemp = Nothing
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
        TxtSite_Code.Enter, TxtRemark.Enter, TxtReallocationDate.Enter, TxtTeacher.Enter, _
         TxtRemark.Enter, TxtWeekDay.Enter

        Try
            Select Case sender.name
                Case TxtTeacher.Name
                    Call IniTeacherHelp(False)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtRemark.Validating, TxtReallocationDate.Validating, TxtRemark.Validating, _
         TxtWeekDay.Validating, TxtTeacher.Validating

        Try
            Select Case sender.NAME
                Case TxtReallocationDate.Name
                    If TxtReallocationDate.Text.ToString.Trim = "" Then TxtReallocationDate.Text = AgL.PubLoginDate
                    TxtWeekDay.AgSelectedValue = CDate(TxtReallocationDate.Text).DayOfWeek + 1
            End Select

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
                If .Item(Col1TimeTableSubject, I).Value Is Nothing Then .Item(Col1TimeTableSubject, I).Value = ""

                If Not AgL.StrCmp(DGL1.Item(Col1IsEngageTimeSlot, I).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                    DGL1.AgSelectedValue(Col1Subject, I) = DGL1.AgSelectedValue(Col1TimeTableSubject, I)
                    DGL1.Item(Col1SubjectCode, I).Value = DGL1.AgSelectedValue(Col1TimeTableSubject, I)                    
                End If
            Next
        End With
    End Sub


    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bBlnFlag As Boolean = False
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtReallocationDate, "Apply Date") Then Exit Function
            If AgL.RequiredField(TxtTeacher, "Teacher") Then Exit Function
            If AgL.RequiredField(TxtWeekDay, "Week Day") Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1Subject) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1TimeSlot & "") Then Exit Function

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1TimeSlot, I).Value Is Nothing Then .Item(Col1TimeSlot, I).Value = ""
                    If .Item(Col1Subject, I).Value Is Nothing Then .Item(Col1Subject, I).Value = ""
                    If .Item(Col1ClassSectionSubSection, I).Value Is Nothing Then .Item(Col1ClassSectionSubSection, I).Value = ""
                    If DGL1.Item(Col1ReallocateTeacher, I).Value Is Nothing Then DGL1.Item(Col1ReallocateTeacher, I).Value = ""

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


                    If DGL1.Item(Col1TimeTableSubject, I).Value <> "" Then
                        If DGL1.Item(Col1ReallocateTeacher, I).Value.ToString.Trim <> "" Then
                            If Not bBlnFlag Then bBlnFlag = True
                        End If
                    End If
                Next

                If Not bBlnFlag Then
                    MsgBox("Fill Atleast One Reallocate Teacher !...")
                    DGL1.CurrentCell = DGL1(Col1ReallocateTeacher, 0) : DGL1.Focus() : Exit Function
                End If

            End With

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            mQry = "SELECT IsNull(count(*),0) Cnt " & _
                    " FROM TT_ReallocateTeacher R With (NoLock) " & _
                    " WHERE " & _
                    " R.ReallocationDate = " & AgL.ConvertDate(TxtReallocationDate.Text) & " And " & _
                    " R.Teacher = " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & " And " & _
                    " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " R.Code <> '" & mSearchCode & "' ") & " "
            AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GCn)
            If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Reallocation Record Already Exists For Selected Parameters!...") : TxtReallocationDate.Focus() : Exit Function


            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetMaxId("TT_ReallocateTeacher", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)
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
        TxtReallocationDate.Focus()
    End Sub


    Private Sub ProcFillDaySchedule()
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim bView1Qry$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            If AgL.RequiredField(TxtSite_Code) Then Exit Sub
            If AgL.RequiredField(TxtReallocationDate, "Apply Date") Then Exit Sub
            If AgL.RequiredField(TxtTeacher, "Teacher") Then Exit Sub
            If AgL.RequiredField(TxtWeekDay, "Week Day") Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            bView1Qry = FunGetTimeTableQuery(TxtReallocationDate.Text, Val(TxtWeekDay.AgSelectedValue))

            mQry = "SELECT V1.ClassSection, T1.* " & _
                    " FROM (" & bView1Qry & ") V1 " & _
                    " Left Join TT_TimeTable1 T1 On V1.Code = T1.Code " & _
                    " Left Join Sch_TimeSlot Ts On T1.TimeSlot = Ts.Code " & _
                    " WHERE T1.Teacher = " & AgL.Chk_Text(TxtTeacher.AgSelectedValue) & " " & _
                    " Order By Ts.StartTime "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1TimeSlot, I) = AgL.XNull(.Rows(I)("TimeSlot"))
                        DGL1.AgSelectedValue(Col1ClassSection, I) = AgL.XNull(.Rows(I)("ClassSection"))
                        DGL1.AgSelectedValue(Col1ClassSectionSubSection, I) = AgL.XNull(.Rows(I)("ClassSectionSubSection"))
                        DGL1.AgSelectedValue(Col1Subject, I) = AgL.XNull(.Rows(I)("Subject"))
                        DGL1.Item(Col1SubjectCode, I).Value = AgL.XNull(.Rows(I)("Subject"))
                        DGL1.AgSelectedValue(Col1TimeTableSubject, I) = AgL.XNull(.Rows(I)("Subject"))
                        DGL1.Item(Col1TimeTable, I).Value = AgL.XNull(.Rows(I)("Code"))
                        DGL1.AgSelectedValue(Col1ReallocateTeacher, I) = ""
                        DGL1.Item(Col1IsEngageTimeSlot, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                    Next I
                Else
                    MsgBox(TxtTeacher.Text & " Is Not Alloted Any Period!...")
                End If
            End With

            DGL1.CurrentCell = DGL1(Col1ReallocateTeacher, 0) : DGL1.Focus()

        Catch ex As Exception
            MsgBox(ex.Message)
            DGL1.RowCount = 1 : DGL1.Rows.Clear()
        Finally
            DtTemp = Nothing
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
                Case Col1IsEngageTimeSlot
                    Call AgCL.ProcSetCheckColumnCellValue(DGL1, Col1IsEngageTimeSlot)
                    Calculation()
            End Select

        Catch ex As Exception
        End Try
    End Sub

    'Private Function FunGetWeekDayTimeTableQuery() As String
    '    Dim bView1Qry$
    '    bView1Qry = "SELECT T.* FROM " & _
    '                    " ( " & _
    '                    " SELECT V1.ClassSection, Max(V1.ApplyDate) AS ApplyDate " & _
    '                    " FROM  " & _
    '                    " ( " & _
    '                    " SELECT T.ClassSection + Convert(VARCHAR,T.ApplyDate) AS Code,  " & _
    '                    " Max(T.ClassSection) AS ClassSection , " & _
    '                    " Max(T.ApplyDate) AS ApplyDate " & _
    '                    " FROM TT_TimeTable T " & _
    '                    " WHERE T.WeekDay = " & Val(TxtWeekDay.AgSelectedValue) & " AND T.ApplyDate <= " & AgL.ConvertDate(TxtReallocationDate.Text) & " " & _
    '                    " GROUP BY T.ClassSection + Convert(VARCHAR,T.ApplyDate) " & _
    '                    " ) V1 " & _
    '                    " GROUP BY V1.ClassSection " & _
    '                    " ) AS V2 " & _
    '                    " INNER JOIN TT_TimeTable T ON V2.ClassSection = T.ClassSection AND V2.ApplyDate = T.ApplyDate  "

    '    FunGetWeekDayTimeTableQuery = bView1Qry
    'End Function

    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillDaySchedule.Click
        Try
            Select Case sender.name
                Case BtnFillDaySchedule.Name
                    If MsgBox("Are You Sure To Fill Day Schedule?" & vbCrLf & "This Will Make Empty Day Schedule Grid!...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub
                    Call ProcFillDaySchedule()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
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
                Case Col1IsEngageTimeSlot
                    If e.KeyCode = Keys.Space Then
                        AgCL.ProcSetCheckColumnCellValue(DGL1, Col1IsEngageTimeSlot)
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGL1.CellFormatting
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = e.RowIndex
            mColumnIndex = e.ColumnIndex

            If DGL1.Item(Col1IsEngageTimeSlot, mRowIndex).Value Is Nothing Then DGL1.Item(Col1IsEngageTimeSlot, mRowIndex).Value = ""
            If DGL1.Item(Col1IsEngageTimeSlot, mRowIndex).Value.ToString.Trim = "" Then DGL1.Item(Col1IsEngageTimeSlot, mRowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue



            If DGL1.Item(Col1IsEngageTimeSlot, mRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                DGL1.Item(Col1Subject, mRowIndex).Style.ForeColor = Color.Black
                DGL1.Item(Col1Subject, mRowIndex).Style.BackColor = Color.White
            Else
                DGL1.Item(Col1Subject, mRowIndex).Style.ForeColor = Color.Black
                DGL1.Item(Col1Subject, mRowIndex).Style.BackColor = Color.LightYellow
            End If

        Catch ex As Exception

        End Try

    End Sub
End Class

