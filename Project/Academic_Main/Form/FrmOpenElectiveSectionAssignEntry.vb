Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmOpenElectiveSectionAssignEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mBlnIsSubSectiionExists As Boolean = False

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1AdmissionDocId As Byte = 1
    Private Const Col1AdmissionID As Byte = 2
    Private Const Col1YesNo As Byte = 3
    Private Const Col1SectionLeftOnDate As Byte = 4
    Private Const Col1SectionLeftOnDate1 As Byte = 5
    Private Const Col1ClassSectionSubSection As Byte = 6

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
            .AddAgTextColumn(DGL1, "DGL1SNo", 30, 5, "S. No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionDocId", 350, 8, "Student", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1AdmissionId", 250, 8, "Admission ID", True, True, False)
            AgL.AddCheckColumn(DGL1, "Dgl1YesNo", 60, 50, "Yes/No", True, True)
            .AddAgDateColumn(DGL1, "Dgl1LeftOnDate", 100, "Left On Date", True, False, False)
            .AddAgDateColumn(DGL1, "Dgl1LeftOnDate1", 100, "Left On Date1", False, False, False)
            .AddAgTextColumn(DGL1, "DGL1ClassSectionSubSection", 40, 5, "Sub-Section", False, True, False)
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
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " "

            mQry = "Select S.Code As SearchCode " & _
                    " From Sch_ClassSectionOpenElectiveSemester S " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                          " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ClassSectionDesc, S.SessionProgramme As SessionProgrammeCode " & _
                    " FROM ViewSch_ClassSection S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " And S.IsOpenElectiveSection <> 0 " & _
                    " ORDER BY S.ClassSectionDesc "
            TxtClassSection.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code , S.StreamYearSemesterDesc AS Name, S.SessionProgrammeCode " & _
                    " FROM ViewSch_StreamYearSemester S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY S.StreamYearSemesterDesc "
            TxtStreamYearSemester.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

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
                If mBlnIsSubSectiionExists Then MsgBox("Permission Denied." & vbCrLf & "Sub-Section Is Assigned!...", MsgBoxStyle.Information, "Delete Record") : Exit Sub

                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then
                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans

                    mTrans = True

                    AgL.Dman_ExecuteNonQry("Delete From Sch_ClassSectionOpenElectiveSemesterAdmission Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_ClassSectionOpenElectiveSemester Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        TxtClassSection.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 And " & AgL.PubSiteCondition("CS.Site_Code", AgL.PubSiteCode) & " "


            AgL.PubFindQry = "Select CS.Code As SearchCode, S.Name AS [Site Name], V1.ClassSectionDesc, V1.SessionProgrammeDesc, V2.StreamYearSemesterDesc, Cs.TotalStudent  " & _
                            " From Sch_ClassSectionOpenElectiveSemester CS " & _
                            " LEFT JOIN SiteMast S ON Cs.Site_Code = S.Code " & _
                            " Left Join ViewSch_ClassSection V1 On Cs.ClassSection = V1.Code " & _
                            " Left Join ViewSch_StreamYearSemester V2 On Cs.StreamYearSemester = V2.Code " & _
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
                mQry = "INSERT INTO Sch_ClassSectionOpenElectiveSemester ( Code, ClassSection, StreamYearSemester, TotalStudent, Remark, " & _
                        " Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE ) " & _
                        " VALUES ( " & _
                        " '" & mSearchCode & "', " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                        " " & Val(TxtTotalStudent.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "UPDATE Sch_ClassSectionOpenElectiveSemester SET " & _
                        " ClassSection = " & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & ", StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & "," & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", TotalStudent = " & Val(TxtTotalStudent.Text) & ", " & _
                        " U_AE = 'E', Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE Code = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            If Topctrl1.Mode = "Edit" Then
                AgL.Dman_ExecuteNonQry("Delete From Sch_ClassSectionOpenElectiveSemesterAdmission Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
            End If

            With DGL1
                bSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1AdmissionDocId, I).Value <> "" And .Item(Col1YesNo, I).Value.ToString.Trim = AgLibrary.ClsConstant.StrCheckedValue Then
                        bSr += 1
                        mQry = "INSERT INTO Sch_ClassSectionOpenElectiveSemesterAdmission ( " & _
                                " Code, Sr, AdmissionDocId, SectionLeftOnDate, ClassSectionSubSection) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & bSr & ", " & _
                                " " & AgL.Chk_Text(.AgSelectedValue(Col1AdmissionDocId, I)) & ", " & _
                                " " & AgL.ConvertDate(.Item(Col1SectionLeftOnDate, I).Value.ToString) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1ClassSectionSubSection, I).Value) & " " & _
                                " )"
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
                mQry = "Select S.*, C.SessionProgramme As SessionProgrammeCode " & _
                        " From Sch_ClassSectionOpenElectiveSemester S " & _
                        " Left Join Sch_ClassSection C On S.ClassSection = C.Code " & _
                        " Where S.Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtClassSection.AgSelectedValue = AgL.XNull(.Rows(0)("ClassSection"))
                        TxtStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        TxtTotalStudent.Text = AgL.VNull(.Rows(0)("TotalStudent"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        LblClassSection.Tag = AgL.XNull(.Rows(0)("SessionProgrammeCode"))
                        LblStreamYearSemester.Tag = AgL.XNull(.Rows(0)("SessionProgrammeCode"))

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With



                mQry = "Select Sa.*, V1.AdmissionID " & _
                        " From Sch_ClassSectionOpenElectiveSemesterAdmission Sa " & _
                        " LEFT JOIN ViewSch_Admission V1 ON Sa.AdmissionDocId = V1.DocId " & _
                        " Where Sa.Code = '" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                            DGL1.Item(Col1AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))
                            DGL1.Item(Col1YesNo, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                            DGL1.Item(Col1SectionLeftOnDate, I).Value = Format(AgL.XNull(.Rows(I)("SectionLeftOnDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL1.Item(Col1SectionLeftOnDate1, I).Value = Format(AgL.XNull(.Rows(I)("SectionLeftOnDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            DGL1.Item(Col1ClassSectionSubSection, I).Value = AgL.XNull(.Rows(I)("ClassSectionSubSection"))
                            If mBlnIsSubSectiionExists = False And AgL.XNull(.Rows(I)("ClassSectionSubSection")).ToString.Trim <> "" Then mBlnIsSubSectiionExists = True
                        Next I
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
        mSearchCode = ""
        mBlnIsSubSectiionExists = False
        TxtSelectAll.Text = "Yes"
        DGL1.RowCount = 1 : DGL1.Rows.Clear()

    End Sub



    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False

        If Topctrl1.Mode = "Edit" Then
            TxtClassSection.Enabled = False
            TxtStreamYearSemester.Enabled = False
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
                Case Col1YesNo
                    Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

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

                    Case Col1SectionLeftOnDate
                        If DGL1.Item(Col1SectionLeftOnDate1, mRowIndex).Value Is Nothing Then DGL1.Item(Col1SectionLeftOnDate1, mRowIndex).Value = ""

                        If DGL1.Item(Col1SectionLeftOnDate, mRowIndex).Value.ToString.Trim <> DGL1.Item(Col1SectionLeftOnDate1, mRowIndex).Value.ToString.Trim And DGL1.Item(Col1SectionLeftOnDate1, mRowIndex).Value.ToString.Trim <> "" Then
                            DGL1.Item(Col1SectionLeftOnDate, mRowIndex).Value = DGL1.Item(Col1SectionLeftOnDate1, mRowIndex).Value
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
                    Case Col1YesNo
                        If DGL1.Item(Col1SectionLeftOnDate, mRowIndex).Value Is Nothing Then DGL1.Item(Col1SectionLeftOnDate, mRowIndex).Value = ""
                        If DGL1.Item(Col1ClassSectionSubSection, mRowIndex).Value Is Nothing Then DGL1.Item(Col1ClassSectionSubSection, mRowIndex).Value = ""

                        If DGL1.Item(mColumnIndex, e.RowIndex).Value.ToString.Trim = "" Then DGL1.Item(mColumnIndex, e.RowIndex).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                        If DGL1.Item(mColumnIndex, e.RowIndex).Value.ToString.Trim <> AgLibrary.ClsConstant.StrUnCheckedValue Then
                            If DGL1.Item(Col1SectionLeftOnDate, e.RowIndex).Value <> "" Then
                                MsgBox("Please Don't Uncheck the Student!...")
                                e.Cancel = True : Exit Sub
                            ElseIf DGL1.Item(Col1ClassSectionSubSection, e.RowIndex).Value.ToString.Trim <> "" Then
                                MsgBox("Please Don't Uncheck the Student." & vbCrLf & "Sub-Section Is Assinged!...")
                                e.Cancel = True : Exit Sub
                            End If
                        End If

                    Case Col1SectionLeftOnDate
                        DGL1.Item(mColumnIndex, mRowIndex).Value = AgL.RetFinancialYearDate(DGL1.Item(mColumnIndex, mRowIndex).Value.ToString)

                End Select
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1YesNo
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(DGL1, Col1YesNo)
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
                Case Col1YesNo
                    Call AgL.ProcSetCheckColumnCellValue(DGL1, Col1YesNo)
            End Select
            Calculation()
        Catch ex As Exception
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
        TxtSite_Code.Enter, TxtClassSection.Enter, TxtStreamYearSemester.Enter, TxtRemark.Enter
        Try
            Select Case sender.name
                Case TxtStreamYearSemester.Name
                    TxtStreamYearSemester.AgRowFilter = " SessionProgrammeCode = " & AgL.Chk_Text(LblClassSection.Tag.ToString) & " "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
           TxtSite_Code.Validating, TxtRemark.Validating, TxtClassSection.Validating, TxtStreamYearSemester.Validating


        Try
            Select Case sender.NAME
                Case TxtClassSection.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblClassSection.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblClassSection.Tag = AgL.XNull(.Item("SessionProgrammeCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

                Case TxtStreamYearSemester.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblStreamYearSemester.Tag = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                LblStreamYearSemester.Tag = AgL.XNull(.Item("SessionProgrammeCode", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If

            End Select

            If Not AgL.StrCmp(LblClassSection.Tag.ToString, LblStreamYearSemester.Tag.ToString) Then
                TxtStreamYearSemester.AgSelectedValue = ""
                LblStreamYearSemester.Tag = ""
            End If

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        TxtTotalStudent.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1AdmissionDocId, I).Value Is Nothing Then .Item(Col1AdmissionDocId, I).Value = ""
                If .Item(Col1YesNo, I).Value Is Nothing Then .Item(Col1YesNo, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                If .Item(Col1YesNo, I).Value.ToString.Trim = "" Then .Item(Col1YesNo, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue

                If .Item(Col1AdmissionDocId, I).Value <> "" And .Item(Col1YesNo, I).Value.ToString.Trim = AgLibrary.ClsConstant.StrCheckedValue Then
                    TxtTotalStudent.Text = Val(TxtTotalStudent.Text) + 1
                End If
            Next
        End With

        TxtTotalStudent.Text = Format(Val(TxtTotalStudent.Text), "0")
    End Sub


    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtClassSection, "Class/Section") Then Exit Function
            If AgL.RequiredField(TxtStreamYearSemester, "Semester") Then Exit Function

            If Not AgL.StrCmp(LblClassSection.Tag.ToString, LblStreamYearSemester.Tag.ToString) Then
                MsgBox("Stream/Year/Semester Is Not Valid!...") : TxtStreamYearSemester.Focus() : Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1AdmissionDocId) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1AdmissionDocId & "") Then Exit Function

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1AdmissionDocId, I).Value Is Nothing Then .Item(Col1AdmissionDocId, I).Value = ""
                    If .Item(Col1YesNo, I).Value Is Nothing Then .Item(Col1YesNo, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                    If .Item(Col1ClassSectionSubSection, I).Value Is Nothing Then .Item(Col1ClassSectionSubSection, I).Value = ""

                    If .Item(Col1AdmissionDocId, I).Value <> "" Then
                        If .Item(Col1YesNo, I).Value.ToString.Trim <> AgLibrary.ClsConstant.StrCheckedValue _
                            And .Item(Col1SectionLeftOnDate, I).Value.ToString.Trim <> "" Then

                            MsgBox("Please Select The Student At Row No. : " & .Item(Col_SNo, I).Value.ToString & "!...")
                            DGL1.CurrentCell = DGL1(Col1YesNo, I) : DGL1.Focus() : Exit Function
                        End If
                    End If

                    If .Item(Col1YesNo, I).Value.ToString.Trim <> AgLibrary.ClsConstant.StrCheckedValue _
                        And .Item(Col1ClassSectionSubSection, I).Value.ToString.Trim <> "" Then

                        MsgBox("Please Select The Student At Row No. : " & .Item(Col_SNo, I).Value.ToString & "!..." & vbCrLf & "As Sub-Section is Assigned.")
                        DGL1.CurrentCell = DGL1(Col1YesNo, I) : DGL1.Focus() : Exit Function
                    End If

                Next
            End With

            If AgL.RequiredField(TxtTotalStudent, "Total Student", True) Then DGL1.CurrentCell = DGL1(Col1YesNo, 0) : DGL1.Focus() : Exit Function

            If Not AgCL.AgCheckMandatory(Me) Then Exit Function


            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetMaxId("Sch_ClassSectionOpenElectiveSemester", "Code", AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue, 8, True, True, , AgL.Gcn_ConnectionString)
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

        TxtClassSection.Focus()
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
        Dim DtSection As DataTable
        Dim I As Integer
        Dim bQryAdmissionPromotion$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            DGL1.RowCount = 1 : DGL1.Rows.Clear()

            If AgL.RequiredField(TxtSite_Code) Then Exit Sub
            If AgL.RequiredField(TxtClassSection) Then Exit Sub
            If AgL.RequiredField(TxtStreamYearSemester) Then Exit Sub

            If Not AgL.StrCmp(LblClassSection.Tag.ToString, LblStreamYearSemester.Tag.ToString) Then
                MsgBox("Stream/Year/Semester Is Not Valid!...") : TxtStreamYearSemester.Focus() : Exit Sub
            End If


            bQryAdmissionPromotion = " SELECT P.* " & _
                                        " FROM Sch_AdmissionPromotion P " & _
                                        " WHERE " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " P.PromotionDate IS NULL ", " CASE WHEN P.PromotionDate IS NULL THEN GetDate() ELSE P.PromotionDate END IS Not Null ") & " " & _
                                        " And P.FromStreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "

            mQry = "SELECT Vp.AdmissionDocId, V1.AdmissionID, Convert(Bit, " & IIf(AgL.StrCmp(TxtSelectAll.Text, "Yes"), 1, 0) & " ) AS YesNo " & _
                    " FROM (" & bQryAdmissionPromotion & ") Vp " & _
                    " LEFT JOIN ViewSch_Admission V1 ON Vp.AdmissionDocId = V1.DocId " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", TxtSite_Code.AgSelectedValue) & " " & _
                    " AND V1.Status <> '" & Academic_ProjLib.ClsMain.AdmissionStatus_Ex & "' " & _
                    " AND V1.LeavingDate IS NULL " & _
                    " Order By V1.StudentName "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                DGL1.RowCount = 1 : DGL1.Rows.Clear()

                If .Rows.Count > 0 Then
                    TxtClassSection.Enabled = False
                    TxtStreamYearSemester.Enabled = False

                    For I = 0 To DtTemp.Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1AdmissionDocId, I) = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        DGL1.Item(Col1AdmissionID, I).Value = AgL.XNull(.Rows(I)("AdmissionID"))
                        DGL1.Item(Col1YesNo, I).Value = IIf(AgL.VNull(.Rows(I)("YesNo")), AgLibrary.ClsConstant.StrCheckedValue, AgLibrary.ClsConstant.StrUnCheckedValue)

                        mQry = "SELECT Sa.ClassSectionSubSection " & _
                      " FROM Sch_ClassSectionOpenElectiveSemester S " & _
                      " LEFT JOIN Sch_ClassSectionOpenElectiveSemesterAdmission Sa ON S.Code = Sa.Code " & _
                      " Where Sa.AdmissionDocID = '" & DGL1.AgSelectedValue(Col1AdmissionDocId, I) & "' " & _
                      " AND S.ClassSection =" & AgL.Chk_Text(TxtClassSection.AgSelectedValue) & " " & _
                      " AND Sa.SectionLeftOnDate Is NULL "
                        DtSection = AgL.FillData(mQry, AgL.GCn).Tables(0)
                        If DtSection.Rows.Count > 0 Then
                            DGL1.Item(Col1ClassSectionSubSection, I).Value = AgL.XNull(DtSection.Rows(0)("ClassSectionSubSection"))
                        End If

                    Next I

                    DGL1.CurrentCell = DGL1(Col1YesNo, 0) : DGL1.Focus()
                Else
                    TxtClassSection.Enabled = True
                    TxtStreamYearSemester.Enabled = True

                    MsgBox("No Student Record Exists!...")
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

    
   
End Class
