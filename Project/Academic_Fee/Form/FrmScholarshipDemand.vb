Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmScholarshipDemand
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1AdmissionDocId As Byte = 1
    Private Const Col1SessionProgrammeStreamYear As Byte = 2
    Private Const Col1FamilyIncome As Byte = 3
    Private Const Col1DemandAmount As Byte = 4

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
            .AddAgTextColumn(DGL1, "DGL1AdmissionDocId", 350, 10, "Student", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1SessionProgrammeStreamYear", 60, 10, "Year", True, True, False)
            .AddAgNumberColumn(DGL1, "DGL1FamilyIncome", 100, 8, 2, False, "Family Income", True, True, True)
            .AddAgNumberColumn(DGL1, "DGL1DemandAmount", 100, 8, 2, False, "Demand Amount", True, False, True)
        End With
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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Sd.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("Sd.Site_Code", AgL.PubSiteCode) & " "

            mQry = "Select Sd.DocId As SearchCode " & _
                    " From Sch_ScholarShipDemand Sd " & _
                    " LEFT JOIN Voucher_Type Vt ON Sd.V_Type = Vt.V_Type " & _
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
                  " Where Vt.NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ScholarshipDemand) & "" & _
                  " Order By Description"
            TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT P.Code, P.ManualCode FROM Sch_Programme P " & _
                    " Where " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY P.ManualCode "
            TxtProgramme.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT C.Code, C.ManualCode FROM Sch_Category C "
            TxtCategory.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Y.Code, Y.YearSerial FROM Sch_SessionProgrammeStreamYear Y"
            DGL1.AgHelpDataSet(Col1SessionProgrammeStreamYear, 1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Vp.AdmissionDocId As Code, V1.StudentName As [Student Name], " & _
                   " V1.AdmissionID, V1.Student As StudentCode, " & _
                   " Vp.FromStreamYearSemester AS StreamYearSemesterCode, S.FamilyIncome, S.Category   " & _
                   " FROM (SELECT P.* FROM Sch_AdmissionPromotion P WHERE P.PromotionDate IS NULL) Vp " & _
                   " LEFT JOIN ViewSch_Admission V1 ON Vp.AdmissionDocId = V1.DocId " & _
                   " LEFT JOIN Sch_Student S ON V1.Student = S.SubCode  " & _
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


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    AgL.Dman_ExecuteNonQry("Delete From Sch_ScholarShipDemand1 Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_ScholarShipDemand Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("Sd.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                                 " And " & AgL.PubSiteCondition("Sd.Site_Code", AgL.PubSiteCode) & " "

            AgL.PubFindQry = "Select Sd.DocId As SearchCode, " & AgL.V_No_Field("Sd.DocId") & " As [Voucher No], " & _
                            " C.ManualCode AS Category, P.ManualCode AS Programme, Sd.TotalDemandAmount As [Total Demand], S.Name AS [Site Name] " & _
                            " From Sch_ScholarShipDemand Sd " & _
                            " LEFT JOIN SiteMast S ON Sd.Site_Code = S.Code " & _
                            " LEFT JOIN Sch_Programme P ON P.Code = Sd.Programme " & _
                            " LEFT JOIN Sch_Category C ON C.Code = Sd.Category " & mCondStr & " "

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


            RepName = "Academic_Main_ScholarshipDemand"
            RepTitle = "Scholarship Demand List"

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = " SELECT " & AgL.V_No_Field("D.DocId") & " As [Demand No], D.DocId, D.Div_Code, D.Site_Code, D.V_Date, D.V_Type, D.V_Prefix, D.V_No, " & _
                        " D.Category, D.Programme, D.TotalDemandAmount, D.Remark, D.PreparedBy, D.U_EntDt, " & _
                        " D.U_AE, D.Edit_Date, D.ModifiedBy, D.RowId, D.UpLoadDate, D.ApprovedBy, D.ApprovedDate, " & _
                        " D.GPX1, D.GPX2, D.GPN1, D.GPN2, " & _
                        " D1.Sr, D1.AdmissionDocId, D1.SessionProgrammeStreamYear,  " & _
                        " D1.FamilyIncome, D1.DemandAmount, C.Description AS CategoryDesc,  " & _
                        " C.ManualCode AS CategoryManualCode, P.Description AS ProgrammeDesc, " & _
                        " P.ManualCode AS ProgrammeManualCode, Va.Student AS StudentCode, Va.StudentName, " & _
                        " Vsy.SessionProgrammeStreamYearDesc , Vsy.YearSerial, Va.StudentDispName, Va.StudentManualCode, " & _
                        " vA.FatherName , vA.MotherName, sps.StreamManualCode " & _
                        " FROM Sch_ScholarShipDemand D " & _
                        " LEFT JOIN Sch_ScholarShipDemand1 D1 ON D.DocId = D1.DocId " & _
                        " LEFT JOIN Sch_Category C ON D.Category = C.Code " & _
                        " LEFT JOIN Sch_Programme P ON D.Programme = P.Code " & _
                        " LEFT JOIN ViewSch_Admission Va ON D1.AdmissionDocId = Va.DocId " & _
                        " LEFT JOIN ViewSch_SessionProgrammeStreamYear Vsy ON D1.SessionProgrammeStreamYear = Vsy.SessionProgrammeStreamYearCode " & _
                        " LEFT JOIN ViewSch_SessionProgrammeStream sps ON vsy.SessionProgrammeStreamCode = sps.Code " & _
                        " WHERE D.DocId = '" & mDocId & "' "

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

    Private Sub Topctrl_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim bSr As Integer = 0, I As Integer = 0
        Dim mTrans As Boolean = False
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_ScholarShipDemand(DocId, Div_Code, Site_Code, V_Date, V_Type, " & _
                        " V_Prefix, V_No, Category,	Programme, TotalDemandAmount, Remark, PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtCategory.AgSelectedValue) & ", " & AgL.Chk_Text(TxtProgramme.AgSelectedValue) & ", " & _
                        " " & Val(TxtTotalDemandAmount.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"


                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_ScholarShipDemand " & _
                        " SET  " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " Category = " & AgL.Chk_Text(TxtCategory.AgSelectedValue) & ", " & _
                        " Programme = " & AgL.Chk_Text(TxtProgramme.AgSelectedValue) & ", " & _
                        " TotalDemandAmount = " & Val(TxtTotalDemandAmount.Text) & ", " & _
                        " U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & mSearchCode & "' "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                mQry = "DELETE FROM Sch_ScholarShipDemand1 WHERE DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            bSr = 0
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1AdmissionDocId, I).Value <> "" And Val(DGL1.Item(Col1DemandAmount, I).Value) > 0 Then
                        bSr += 1
                        mQry = "INSERT INTO Sch_ScholarShipDemand1(DocId, Sr, " & _
                                " AdmissionDocId, SessionProgrammeStreamYear, FamilyIncome, DemandAmount) " & _
                                " VALUES ('" & mSearchCode & "',	" & _
                                " " & Val(bSr) & ",	" & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1SessionProgrammeStreamYear, I)) & ",	" & _
                                " " & Val(.Item(Col1FamilyIncome, I).Value) & ", " & Val(.Item(Col1DemandAmount, I).Value) & ")"

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

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

                If MsgBox("Want To Print Document?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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
        Dim mTransFlag As Boolean = False
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
                mQry = "Select Sd.*, Vt.NCat " & _
                        " From Sch_ScholarShipDemand Sd " & _
                        " Left Join Voucher_Type Vt On Sd.V_Type = Vt.V_Type " & _
                        " Where Sd.DocId='" & mSearchCode & "'"

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

                        TxtCategory.AgSelectedValue = AgL.XNull(.Rows(0)("Category"))
                        TxtProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("Programme"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        TxtTotalDemandAmount.Text = Format(AgL.VNull(.Rows(0)("TotalDemandAmount")), "0.00")
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With


                mQry = "SELECT Sd1.* " & _
                        " FROM Sch_ScholarShipDemand1 Sd1 " & _
                        " LEFT JOIN Viewsch_Admission Va On Sd1.AdmissionDocId = Va.DocId " & _
                        " Where Sd1.DocId='" & mSearchCode & "' " & _
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
                            DGL1.AgSelectedValue(Col1SessionProgrammeStreamYear, I) = AgL.XNull(.Rows(I)("SessionProgrammeStreamYear"))
                            DGL1.Item(Col1FamilyIncome, I).Value = Format(AgL.VNull(.Rows(I)("FamilyIncome")), "0.".PadRight(2 + 2, "0"))
                            DGL1.Item(Col1DemandAmount, I).Value = Format(AgL.VNull(.Rows(I)("DemandAmount")), "0.".PadRight(2 + 2, "0"))
                        Next I
                    End If
                End With
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                mQry = "SELECT isnull(count(Sr.DemandDocId),0) AS Cnt  " & _
                      " FROM Sch_ScholarShipReceive Sr " & _
                      " WHERE Sr.DemandDocId = '" & mSearchCode & "'"
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then mTransFlag = True
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
            'Topctrl1.tPrn = False
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = ""

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
        TxtTotalDemandAmount.ReadOnly = True

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
            TxtCategory.Enabled = False
            TxtProgramme.Enabled = False
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
        TxtV_Type.Enter
        Try
            Select Case sender.name
                Case TxtV_Type.Name

            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtDocId.Validating, TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_Date.Validating, TxtV_No.Validating, _
        TxtProgramme.Validating

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

        TxtTotalDemandAmount.Text = 0
        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1DemandAmount, I).Value Is Nothing Then .Item(Col1DemandAmount, I).Value = ""
                If .Item(Col1FamilyIncome, I).Value Is Nothing Then .Item(Col1FamilyIncome, I).Value = ""
                If .Item(Col1AdmissionDocId, I).Value <> "" And Val(DGL1.Item(Col1DemandAmount, I).Value) > 0 Then
                    TxtTotalDemandAmount.Text = Format(Val(TxtTotalDemandAmount.Text) + Val(.Item(Col1DemandAmount, I).Value), "0.00")
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
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate, "Voucher Date") Then Exit Function
            If AgL.RequiredField(TxtProgramme, "Student") Then Exit Function

            If AgCL.AgIsBlankGrid(DGL1, Col1AdmissionDocId) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1AdmissionDocId & "") Then Exit Function

            For I = 0 To DGL1.Rows.Count - 1
                If DGL1.Item(Col1AdmissionDocId, I).Value <> "" Then
                    If Val(DGL1.Item(Col1DemandAmount, I).Value) = 0 Then
                        If MsgBox("Demand Amount Is 0 At Row No " & DGL1.Item(Col_SNo, I).Value & "!..." & vbCrLf & "Do You Want To Continue?...", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "") = MsgBoxResult.No Then
                            DGL1.CurrentCell = DGL1.Item(Col1DemandAmount, I) : DGL1.Focus() : Exit Function
                        End If
                    End If
                End If
            Next

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
                    DGL1.AgRowFilter(Col1AdmissionDocId) = " StreamYearSemesterCode = '" & TxtProgramme.AgSelectedValue & "'"
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
                        If DGL1.AgSelectedValue(Col1AdmissionDocId, mRowIndex) = "" And DGL1.Item(Col1AdmissionDocId, mRowIndex).Value = "" Then
                            DGL1.Item(Col1FamilyIncome, mRowIndex).Value = ""
                        Else
                            If DGL1.AgHelpDataSet(Col1AdmissionDocId) IsNot Nothing Then
                                DrTemp = DGL1.AgHelpDataSet(Col1AdmissionDocId).Tables(0).Select("Code = " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, mRowIndex)) & "")
                                DGL1.Item(Col1FamilyIncome, mRowIndex).Value = Format(AgL.VNull(DrTemp(0)("FamilyIncome")), "0.00")
                            End If
                        End If
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
        Dim bQryStrScholarShipParameter$ = ""
        Try

            bQryStrScholarShipParameter = "SELECT TOP 1 Sp.* FROM Sch_ScholarShipParameter Sp " & _
                                            " WHERE Sp.MasterType = '" & Academic_ProjLib.ClsMain.MasterType_ScholarshipParameter & "'  " & _
                                            " AND Sp.ModuleType = '" & Academic_Objects.ClsConstant.Module_Academic_Fee & "' " & _
                                            " AND Sp.ApplicableFrom <= " & AgL.ConvertDate(TxtV_Date.Text) & " " & _
                                            " AND Sp.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                                            " ORDER BY Sp.ApplicableFrom DESC "


            mQry = "SELECT Va.DocId As AdmissionDocId, Vsys.SessionProgrammeStreamYear, " & _
                         " S.FamilyIncome, " & _
                         " CASE WHEN isnull(S.FamilyIncome,0) <= isnull(SP1.FamilyIncome,0) THEN SP1.ScholarShip ELSE 0 END AS DemandAmount " & _
                         " FROM (" & bQryStrScholarShipParameter & ") vSp " & _
                         " LEFT JOIN ViewSch_Admission vA On vSp.Site_Code = vA.Site_Code " & _
                         " LEFT JOIN Sch_Student S ON Va.Student = S.SubCode " & _
                         " LEFT JOIN ViewSch_StreamYearSemester Vsys ON Vsys.Code = Va.CurrentSemester " & _
                         " LEFT JOIN Sch_ScholarShipParameter1 SP1 ON vSp.Code = Sp1.Code And S.Category = Sp1.Category And Sp1.Programme = Vsys.ProgrammeCode And Sp1.ProgrammeYear = Vsys.YearSerial " & _
                         " " & _
                         " Where Va.Site_Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " " & _
                         " AND Sp1.Programme = '" & TxtProgramme.AgSelectedValue & "'  " & _
                         " AND S.Category = '" & TxtCategory.AgSelectedValue & "'  " & _
                         " AND CASE WHEN isnull(S.FamilyIncome,0) <= isnull(SP1.FamilyIncome,0) THEN SP1.ScholarShip ELSE 0 END <> 0 " & _
                         " AND vA.DocId NOT IN (Select D1.AdmissionDocId " & _
                         "                               FROM Sch_ScholarShipDemand1 D1 " & _
                         "                               WHERE D1.AdmissionDocId = vA.DocId " & _
                         "                               AND D1.SessionProgrammeStreamYear = Vsys.SessionProgrammeStreamYear " & _
                         "                               AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", "D1.DocId <> '" & mSearchCode & "'") & ") " & _
                         " Order By Va.StudentName  "

            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                DGL1.RowCount = 1
                DGL1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL1.AgSelectedValue(Col1SessionProgrammeStreamYear, I) = AgL.XNull(.Rows(I)("SessionProgrammeStreamYear"))
                        DGL1.Item(Col1FamilyIncome, I).Value = Format(AgL.VNull(.Rows(I)("FamilyIncome")), "0.".PadRight(2 + 2, "0"))
                        DGL1.Item(Col1DemandAmount, I).Value = Format(AgL.VNull(.Rows(I)("DemandAmount")), "0.".PadRight(2 + 2, "0"))
                    Next I
                Else
                    MsgBox("No Records Exists", MsgBoxStyle.Information)
                End If
            End With
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
        End Try

    End Sub

    Private Sub BtnFillStudents_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFillStudents.Click
        Call ProcFillStudents()
    End Sub
End Class
