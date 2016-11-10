Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmReverseFeeDue
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1FeeDue1 As Byte = 1
    Private Const Col1TempFeeDue1 As Byte = 2
    Private Const Col1FeeCode As Byte = 3
    Private Const Col1Amount As Byte = 4
    Private Const Col1Guid As Byte = 5

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
        AgL.AddAgDataGrid(DGL1, Pnl1)
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 50, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1FeeDue1", 300, 30, "Fee Head", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1TempFeeDue1", 300, 30, "TempFeeDue1", False, True, False)
            .AddAgTextColumn(DGL1, "DGL1Fee", 100, 10, "FeeCode", False, True, False)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 100, 8, 3, False, "Amount", True, True, True)
            .AddAgTextColumn(DGL1, "DGL1Guid", 100, 8, "Guid", False, False, False)
        End With

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
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 600, 880, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim mCondStr$ = ""

        If AgL.PubMoveRecApplicable Then
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("St.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("St.Site_Code", AgL.PubSiteCode) & " " & _
                            " And Vt.NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ReverseFeeDue) & ""

            mQry = "Select ST.DocId As SearchCode " & _
                    " From Sch_ReverseFeeDue ST " & _
                    " Left Join Voucher_Type Vt On St.V_Type = Vt.V_Type " & mCondStr

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                    " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Vt.V_Type As Code, Vt.Description As [Voucher Type], Vt.Category, Vt.Ncat " & _
                    " From Voucher_Type Vt " & _
                     " where Vt.NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ReverseFeeDue) & " " & _
                    " Order By Vt.Description"
            TxtV_Type.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.StreamYearSemesterDesc " & _
                    " FROM ViewSch_StreamYearSemester S " & _
                    " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " ORDER BY S.StreamYearSemesterDesc "
            TxtStreamYearSemester.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V1.DocId As Code, V1.StudentName As [Student Name], P.CurrentSemesterCode, V1.Student As StudentCode " & _
                    " FROM ViewSch_Admission V1 " & _
                    " LEFT JOIN (SELECT Ap.AdmissionDocId, Ap.FromStreamYearSemester AS CurrentSemesterCode FROM Sch_AdmissionPromotion Ap WHERE Ap.PromotionDate IS NULL) P ON V1.DocId = P.AdmissionDocId " & _
                    " Where " & AgL.PubSiteCondition("V1.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By V1.StudentName "
            TxtAdmissionDocId.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Fd1.Code, SgF.Name AS [Fee Name], Fd.V_Date AS [Due Date], Fd1.Amount, Fd1.AdmissionDocId, Fd1.Fee AS FeeCode " & _
                    " FROM Sch_FeeDue1 Fd1 " & _
                    " LEFT JOIN Sch_FeeDue Fd ON Fd1.DocId = Fd.DocId " & _
                    " LEFT JOIN SubGroup SgF ON Fd1.Fee = SgF.SubCode " & _
                    " Where Fd.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " And " & _
                    " " & AgL.PubSiteCondition("Fd.Site_Code", AgL.PubSiteCode) & " "
            DGL1.AgHelpDataSet(Col1FeeDue1, 3) = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode

        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.ReadOnly = True
            TxtV_Date.Focus()
        Else
            TxtV_Type.ReadOnly = False
            TxtV_Type.Focus()
        End If

    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
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

                    mQry = "Update Sch_FeeDue1 " & _
                            " SET Sch_FeeDue1.IsReversePosted = 0 " & _
                            " FROM Sch_ReverseFeeDue1 " & _
                            " WHERE Sch_ReverseFeeDue1.FeeDue1 = Sch_FeeDue1.Code " & _
                            " AND Sch_ReverseFeeDue1.DocId = '" & mSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                    AgL.Dman_ExecuteNonQry("Delete From Sch_FeeReverseDueLedgerM Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    AgL.Dman_ExecuteNonQry("Delete From Sch_ReverseFeeDue1 Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_ReverseFeeDue Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                    AgL.ETrans.Commit()
                    mTrans = False

                    If AgL.PubMoveRecApplicable Then
                        FIniMaster(1)
                        Topctrl1_tbRef()
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

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        If AgL.PubMoveRecApplicable Then FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub


    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)

        TxtV_Date.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr$ = ""

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("St.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("St.Site_Code", AgL.PubSiteCode) & " " & _
                            " And Vt.NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_ReverseFeeDue) & ""

            AgL.PubFindQry = "Select  St.DocId As SearchCode, A.StudentName AS [Student], A.AdmissionID, A.RollNo, A.EnrollmentNo, " & _
                                " Convert(nVarChar,ST.V_Date,3) As [Voucher Date], " & _
                                " " & AgL.V_No_Field("ST.DocId") & " As [Voucher No.], S.StreamYearSemesterDesc as [Semester], " & _
                                " St.TotalAmount as [Total Amount], Vt.Description AS [Voucher Type], ST.Remark as Remark, SiteMast.Name As [Site/Branch Name] " & _
                                " From  Sch_RevrseFeeDue ST " & _
                                " LEFT JOIN ViewSch_Admission A ON A.DocId = St.AdmissionDocId " & _
                                " Left Join  SiteMast  On SiteMast.Code = ST.Site_Code " & _
                                " Left Join Voucher_Type Vt On St.V_Type = Vt.V_Type " & _
                                " LEFT JOIN ViewSch_StreamYearSemester S ON ST.StreamYearSemester=S.Code " & mCondStr

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

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        'Dim mCrd As New ReportDocument
        'Dim mCrd1 As New ReportDocument
        'Dim ReportView As New AgLibrary.RepView
        'Dim DsRep As New DataSet
        'Dim DsRep1 As New DataSet
        'Dim strQry As String = "", strQry1 As String = "", RepName As String = "", RepTitle As String = ""
        'Try
        '    Me.Cursor = Cursors.WaitCursor
        '    AgL.PubReportTitle = " Stock Adjustment "
        '    If mSearchCode = "" Then
        '        MsgBox("No Records Found to Print!!!", vbInformation, "Information")
        '        Me.Cursor = Cursors.Default
        '        Exit Sub
        '    End If



        'SELECT FD.DocId, CONVERT(NVARCHAR,FD.V_Date,3) AS [V Date], S.Name AS [Student Name], F.name AS [Fee Description], FD1.Amount 
        'FROM Sch_FeeDue FD
        'LEFT JOIN Sch_FeeDue1  FD1 ON FD.DocId =FD1.DocId  
        'LEFT JOIN ViewSch_Student S ON FD1.Student = S.SubCode 
        'LEFT JOIN ViewSch_Fee F ON FD1.Fee = F.Code 

        '    strQry = " SELECT StockAdjustment.V_Type,StockAdjustment.V_No,StockAdjustment.V_Date, " & _
        '             " StockAdjustment.PartyName,StockAdjustment.add1,StockAdjustment.add2,StockAdjustment.add3,city.CityName," & _
        '             " fs.Name AS fromsite ,sg.Name AS agaistac,Item.Description AS ItemName, " & _
        '             " Stock.IssueQty AS qty,Stock.Amount,Stock.Amount AS ItemAmount,StockAdjustment.Amount AS BillAmt,Voucher_Type.Description AS vDESCRIPATION,StockAdjustment.remark " & _
        '             "            FROM StockAdjustment " & _
        '             " LEFT JOIN Stock ON StockAdjustment.DocId=Stock.DocId " & _
        '             " LEFT JOIN SiteMast Fs ON StockAdjustment.Site_Code=fs.Code " & _
        '             " LEFT JOIN SubGroup sg ON StockAdjustment.Customer=sg.SubCode " & _
        '             " LEFT JOIN Item ON Stock.Item=Item.Code " & _
        '             " LEFT JOIN City ON StockAdjustment.CityCode=city.CityCode " & _
        '             " LEFT JOIN Voucher_Type ON Voucher_Type.V_Type=StockAdjustment.V_Type " & _
        '             " Where StockAdjustment.DocId = '" & mSearchCode & "' "

        '    AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
        '    AgL.ADMain.Fill(DsRep)

        '    RepName = "StockAdjustment" : RepTitle = "Stock Adjustment "
        '    AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Sale & "\" & RepName & ".ttx", True)
        '    mCrd.Load(PLib.PubReportPath_Sale & "\" & RepName & ".rpt")
        '    mCrd.SetDataSource(DsRep.Tables(0))
        '    CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
        '    PLib.Formula_Set(mCrd, RepTitle)
        '    AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)
        '    Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        'Catch Ex As Exception
        '    MsgBox(Ex.Message)
        'Finally
        '    Me.Cursor = Cursors.Default
        'End Try

    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim I As Integer, mSr As Integer = 0
        Dim mTrans As Boolean = False, mFlagBln As Boolean = False
        Dim bStrReverseFeeDue1Guid$ = ""
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
                mQry = "INSERT INTO dbo.Sch_ReverseFeeDue (DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, " & _
                        " AdmissionDocId, StreamYearSemester, TotalAmount, Remark, " & _
                        " PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES ('" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text.ToString) & ", " & Val(TxtV_No.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                        " " & Val(TxtTotalAmount.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A' )"
            Else
                mQry = "Update dbo.Sch_ReverseFeeDue " & _
                        " SET  " & _
                        " 	V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " 	AdmissionDocId = " & AgL.Chk_Text(TxtAdmissionDocId.AgSelectedValue) & ", " & _
                        " 	StreamYearSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & ", " & _
                        " 	TotalAmount = " & Val(TxtTotalAmount.Text) & ", " & _
                        " 	Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " 	U_AE = 'E', " & _
                        " 	Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " 	ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & mSearchCode & "' "
            End If
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Guid, I).Value = "" Then
                        If .Item(Col1FeeDue1, I).Value <> "" Then
                            bStrReverseFeeDue1Guid = AgL.GetGUID(AgL.GcnRead).ToString

                            mQry = "INSERT INTO dbo.Sch_ReverseFeeDue1 (" & _
                                    " Guid, DocId, FeeDue1, Amount) " & _
                                    " VALUES (" & _
                                    " " & AgL.Chk_Text(bStrReverseFeeDue1Guid) & ", " & AgL.Chk_Text(mSearchCode) & ", " & _
                                    " " & AgL.Chk_Text(.AgSelectedValue(Col1FeeDue1, I)) & ", " & Val(.Item(Col1Amount, I).Value) & ")"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            mQry = "UPDATE Sch_FeeDue1 SET IsReversePosted = 1 WHERE Code = " & AgL.Chk_Text(.AgSelectedValue(Col1FeeDue1, I)) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        End If
                    Else
                        If .Item(Col1FeeDue1, I).Value <> "" Then
                            mQry = "Update dbo.Sch_ReverseFeeDue1 " & _
                                    " SET " & _
                                    " 	FeeDue1 = " & AgL.Chk_Text(.AgSelectedValue(Col1FeeDue1, I)) & ", " & _
                                    " 	Amount = " & Val(.Item(Col1Amount, I).Value) & " " & _
                                    " WHERE Guid = " & AgL.Chk_Text(.Item(Col1Guid, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            mQry = "UPDATE Sch_FeeDue1 SET IsReversePosted = 1 WHERE Code = " & AgL.Chk_Text(.AgSelectedValue(Col1FeeDue1, I)) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Else
                            mQry = "Delete From Sch_ReverseFeeDue1 Where Guid = '" & .Item(Col1Guid, I).Value & "'"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                            mQry = "UPDATE Sch_FeeDue1 SET IsReversePosted = 0 WHERE Code = " & AgL.Chk_Text(.Item(Col1TempFeeDue1, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    End If
                Next I
            End With

            AgL.Dman_ExecuteNonQry("Delete From Sch_ReverseFeeDueLedgerM Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

            Call AccountPosting()

            mQry = "INSERT INTO Sch_ReverseFeeDueLedgerM ( DocId, LedgerMDocId) VALUES ( " & _
                    " '" & mSearchCode & "', '" & mSearchCode & "' )"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            Call AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            Call AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False
            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl1_tbRef()
            End If
            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode
                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                MoveRec()
            End If
        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim bDrTemp As DataRow() = Nothing
        Dim MastPos As Long
        Dim I As Integer
        Try
            FClear()
            BlankText()
            If AgL.PubMoveRecApplicable Then
                If BMBMaster.Count > 0 Then
                    MastPos = BMBMaster.Position
                    mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                Else
                    mSearchCode = ""
                End If
            Else
                mSearchCode = AgL.PubSearchRow
            End If
            If mSearchCode <> "" Then

                mQry = "Select ST.*, Vt.NCat " & _
                        " From Sch_ReverseFeeDue ST " & _
                        " Left Join Voucher_Type Vt On st.V_Type = Vt.V_Type " & _
                        " Where st.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = AgL.XNull(.Rows(0)("DocId"))
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(0 + 2, "0"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCAt"))
                        TxtAdmissionDocId.AgSelectedValue = AgL.XNull(.Rows(I)("AdmissionDocId"))
                        bDrTemp = TxtAdmissionDocId.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(AgL.XNull(.Rows(I)("AdmissionDocId"))) & "")
                        LblAdmissionDocId.Tag = AgL.XNull(bDrTemp(0)("StudentCode"))

                        TxtStreamYearSemester.AgSelectedValue = AgL.XNull(.Rows(0)("StreamYearSemester"))
                        TxtTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With




                mQry = "Select Rfd1.*, Fd.V_Date AS DueDate, Fd1.Fee AS FeeCode, vFr1.ReceiveDate " & _
                        " From Sch_ReverseFeeDue1 Rfd1 " & _
                        " LEFT JOIN Sch_FeeDue1 Fd1 ON Fd1.Code = Rfd1.FeeDue1 " & _
                        " LEFT JOIN Sch_FeeDue Fd ON Fd.DocId = Fd1.DocId " & _
                        " Left Join (SELECT Fr1.FeeDue1, Sum(Fr1.Amount) AS Amount, Max(Fr.V_Date) AS ReceiveDate " & _
                        " FROM Sch_FeeReceive1 Fr1 " & _
                        " LEFT JOIN Sch_FeeReceive  Fr ON Fr1.DocId = Fr.DocId  " & _
                        " GROUP BY Fr1.FeeDue1  " & _
                        " ) vFr1 ON Fd1.Code = vFr1.FeeDue1 " & _
                        " Where Rfd1.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count
                            DGL1.AgSelectedValue(Col1FeeDue1, I) = AgL.XNull(.Rows(I)("FeeDue1"))
                            DGL1.Item(Col1TempFeeDue1, I).Value = AgL.XNull(.Rows(I)("FeeDue1"))
                            DGL1.Item(Col1FeeCode, I).Value = AgL.XNull(.Rows(I)("FeeCode"))

                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.Item(Col1Guid, I).Value = AgL.XNull(.Rows(I)("GUID"))

                            If BtnFill.Tag.ToString.Trim = "" Then
                                BtnFill.Tag = Format(AgL.XNull(.Rows(I)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            Else
                                If CDate(Format(AgL.XNull(.Rows(I)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)) > CDate(TxtV_Date.Text) Then
                                    BtnFill.Tag = Format(AgL.XNull(.Rows(I)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                                End If
                            End If

                            If AgL.XNull(.Rows(I)("ReceiveDate")).ToString.Trim <> "" Then
                                If CDate(Format(AgL.XNull(.Rows(I)("ReceiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)) > CDate(TxtV_Date.Text) Then
                                    BtnFill.Tag = Format(AgL.XNull(.Rows(I)("ReceiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                                End If
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
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes()
        mSearchCode = "" : LblPrefix.Text = ""

        LblV_Type.Tag = "" : BtnFill.Tag = ""

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtDocId.Enabled = False
        TxtV_No.Enabled = False
        TxtSite_Code.Enabled = False
        TxtStreamYearSemester.Enabled = False

        TxtTotalAmount.Enabled = False
        BtnFill.Enabled = Enb

        If Topctrl1.Mode = "Edit" Then
            TxtV_Type.Enabled = False
            TxtAdmissionDocId.Enabled = False
            BtnFill.Enabled = False
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
                'Case Col1AdmissionDocId
                '    DGL1.AgRowFilter(Col1AdmissionDocId) = " CurrentSemesterCode = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL1.EditingControl_Validating

        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim Munit As String
        Munit = ""
        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL1.CurrentCell.ColumnIndex

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_EditingControlShowing(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGL1.EditingControlShowing
        If Topctrl1.Mode = "Browse" Then Exit Sub
        If TypeOf e.Control Is ComboBox Then
            e.Control.Text = ""
        End If
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                'sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub

        Try
            Select Case sender.CurrentCell.ColumnIndex
                'Case <Dgl_Column>
                '    <Executable Code>
            End Select
        Catch Ex As NullReferenceException
        Catch Ex As Exception
            MsgBox(Ex.Message)
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
                'Case TxtAcCode.Name
                '    Call IniAccountHelp(False)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtV_Date.Validating, TxtV_Type.Validating, TxtStreamYearSemester.Validating, TxtAdmissionDocId.Validating

        Dim bDrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblV_Type.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            bDrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            LblV_Type.Tag = AgL.XNull(bDrTemp(0)("NCat"))
                        End If
                    End If

                Case TxtAdmissionDocId.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtStreamYearSemester.AgSelectedValue = ""
                        LblAdmissionDocId.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            bDrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtStreamYearSemester.AgSelectedValue = AgL.XNull(bDrTemp(0)("CurrentSemesterCode"))
                            LblAdmissionDocId.Tag = AgL.XNull(bDrTemp(0)("StudentCode"))
                        End If
                    End If

                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                    TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text.ToString)

            End Select



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

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim mPostAC As String = ""
        Dim GcnRead As New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()
        Try
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtAdmissionDocId, "Student") Then Exit Function
            If AgL.RequiredField(TxtStreamYearSemester, "Semester") Then TxtAdmissionDocId.Focus() : Exit Function

            If AgCL.AgIsBlankGrid(DGL1, Col1FeeDue1) Then Exit Function

            If CDate(TxtV_Date.Text) < CDate(BtnFill.Tag) Then
                MsgBox("Voucher Data Can't Be Less Than From " & BtnFill.Tag & "!...")
                TxtV_Date.Focus() : Exit Function
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


    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        TxtTotalAmount.Text = ""

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1FeeDue1, I).Value <> "" Then
                    TxtTotalAmount.Text = Format(Val(TxtTotalAmount.Text) + Val(.Item(Col1Amount, I).Value), "0.00")
                End If
            Next
        End With
    End Sub

    Private Sub BtnFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Dim bDtTemp As DataTable = Nothing
        Dim bIntI As Integer
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Sub
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Sub
            If AgL.RequiredField(TxtAdmissionDocId, "Student") Then Exit Sub

            mQry = "SELECT Fd1.Code As FeeDue1Code, Fd1.Fee AS FeeCode, Fd1.Amount As DueAmount, Fd.V_Date As DueDate, vFr1.ReceiveDate   " & _
                    " FROM Sch_FeeDue1 Fd1 " & _
                    " LEFT JOIN Sch_FeeDue Fd ON Fd.DocId = Fd1.DocId " & _
                    " Left Join (SELECT Fr1.FeeDue1, Sum(Fr1.Amount) AS Amount, Max(Fr.V_Date) AS ReceiveDate " & _
                    " FROM Sch_FeeReceive1 Fr1 " & _
                    " LEFT JOIN Sch_FeeReceive  Fr ON Fr1.DocId = Fr.DocId  " & _
                    " GROUP BY Fr1.FeeDue1  " & _
                    " ) vFr1 ON Fd1.Code = vFr1.FeeDue1 " & _
                    " WHERE IsNull(Fd1.IsReversePostable,0) <> 0 " & _
                    " AND Fd1.AdmissionDocId = '" & TxtAdmissionDocId.AgSelectedValue & "' " & _
                    " AND Fd.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " "
            bDtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)


            With bDtTemp
                If .Rows.Count > 0 Then
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    TxtAdmissionDocId.Enabled = False

                    For bIntI = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, bIntI).Value = DGL1.Rows.Count
                        DGL1.AgSelectedValue(Col1FeeDue1, bIntI) = AgL.XNull(.Rows(bIntI)("FeeDue1Code"))
                        DGL1.Item(Col1TempFeeDue1, bIntI).Value = AgL.XNull(.Rows(bIntI)("FeeDue1Code"))
                        DGL1.Item(Col1FeeCode, bIntI).Value = AgL.XNull(.Rows(bIntI)("FeeCode"))
                        DGL1.Item(Col1Amount, bIntI).Value = Format(AgL.VNull(.Rows(bIntI)("DueAmount")), "0.00")

                        If BtnFill.Tag.ToString.Trim = "" Then
                            BtnFill.Tag = Format(AgL.XNull(.Rows(bIntI)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        Else
                            If CDate(Format(AgL.XNull(.Rows(bIntI)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)) > CDate(TxtV_Date.Text) Then
                                BtnFill.Tag = Format(AgL.XNull(.Rows(bIntI)("DueDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            End If
                        End If

                        If AgL.XNull(.Rows(bIntI)("ReceiveDate")).ToString.Trim <> "" Then
                            If CDate(Format(AgL.XNull(.Rows(bIntI)("ReceiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)) > CDate(TxtV_Date.Text) Then
                                BtnFill.Tag = Format(AgL.XNull(.Rows(bIntI)("ReceiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            End If
                        End If
                    Next
                Else
                    MsgBox("No Fee Due Records Exists For Reverse Posting!...")
                    TxtAdmissionDocId.Enabled = True
                End If
            End With

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
        End Try
    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer, bIntJ As Integer
        Dim mNarr As String = "", mCommonNarr$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        Dim bDtTemp As DataTable = Nothing


        I = 0
        ReDim Preserve LedgAry(I)

        mQry = "SELECT Fd1.Fee as FeeCode, Convert(Numeric(18,2),IsNull(Sum(Rfd1.Amount),0)) AS Amount, Max(Sg.Name) as FeeHead " & _
                " FROM Sch_ReverseFeeDue1 Rfd1 WITH (NoLock) " & _
                " LEFT JOIN Sch_FeeDue1 Fd1 WITH (NoLock) ON Fd1.Code = Rfd1.FeeDue1  " & _
                " LEFT JOIN SubGroup Sg WITH (NoLock) ON Fd1.Fee = Sg.SubCode " & _
                " WHERE Rfd1.DocId = '" & mSearchCode & "'  " & _
                " GROUP BY Fd1.Fee "
        bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

        With bDtTemp
            If .Rows.Count > 0 Then
                mNarr = "Being Reverse Fee Due Of Rs. " & Format(Val(TxtTotalAmount.Text), "0.00") & "."
                If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)


                LedgAry(I).SubCode = LblAdmissionDocId.Tag
                LedgAry(I).ContraSub = .Rows(bIntJ)("FeeCode")
                LedgAry(I).AmtDr = 0
                LedgAry(I).AmtCr = Val(TxtTotalAmount.Text)
                LedgAry(I).Narration = mNarr

                For bIntJ = 0 To .Rows.Count - 1
                    I = UBound(LedgAry) + 1
                    ReDim Preserve LedgAry(I)

                    mNarr = "Being " & .Rows(bIntJ)("FeeHead") & " Of Rs. " & Format(AgL.VNull(.Rows(bIntJ)("Amount")), "0.00") & " Reverse Posted."
                    If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)

                    LedgAry(I).SubCode = .Rows(bIntJ)("FeeCode")
                    LedgAry(I).ContraSub = LblAdmissionDocId.Tag
                    LedgAry(I).AmtDr = AgL.VNull(.Rows(bIntJ)("Amount"))
                    LedgAry(I).AmtCr = 0
                    LedgAry(I).Narration = mNarr
                Next
            End If
        End With

        mCommonNarr = TxtRemark.Text
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

        If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
    End Function
End Class
