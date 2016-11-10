Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmEnquiryEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mTransFlag As Boolean = False, mBlnImprtFromExcelFlag As Boolean = False

    Dim mObjClsMain As New ClsMain(AgL, PLib)

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode
    Dim mTmStrEmployee$ = ""
    Dim mStrRegisterationDocId As String = "", mStrAdmissionDocId As String = ""

    Private Const Col_SNo As Byte = 0

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2Class As Byte = 1
    Private Const Col2University As Byte = 2
    Private Const Col2EnrollmentNo As Byte = 3
    Private Const Col2YearOfPassing As Byte = 4
    Private Const Col2Subjects As Byte = 5
    Private Const Col2Result As Byte = 6
    Private Const Col2TotalPercentage As Byte = 7
    Private Const Col2FillSubjectMarks As Byte = 8
    Private Const Col2MeritPercentage As Byte = 9
    Private Const Col2Remark As Byte = 10
    Private Const Col2SubjectList As Byte = 11
    Private Const Col2MarksList As Byte = 12
    Private Const Col2PercentageList As Byte = 13

    Public Class HelpDataSet
        Public Shared EnquiryMode As DataSet = Nothing
    End Class

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
        ''================< Academic Data Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "DGL2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "DGL2Class", 120, 50, "Class/Standard", True, False, False)
            .AddAgTextColumn(DGL2, "DGL2University", 150, 50, "Board/University", True, False, False)
            .AddAgTextColumn(DGL2, "DGL2EnrollmentNo", 100, 20, "Enrollment No", True, False, False)
            .AddAgNumberColumn(DGL2, "DGL2YearOfPassing", 60, 4, 0, False, "Year", True, False, True)
            .AddAgTextColumn(DGL2, "DGL2Subjects", 120, 255, "Subjects", True, False, False)
            .AddAgTextColumn(DGL2, "DGL2Result", 80, 20, "Result", True, False, False)
            .AddAgNumberColumn(DGL2, "DGL2TotalPercentage", 50, 2, 2, False, "Total %", True, False, True)
            .AddAgButtonColumn(DGL2, "DGL2FillSubSection", 50, "Merit Marks", True, False, , , , "Webdings", 10, "6")
            .AddAgNumberColumn(DGL2, "DGL2MeritPercentage", 50, 2, 2, False, "% For Merit", True, False, True)
            .AddAgTextColumn(DGL2, "DGL2Remark", 130, 255, "Merit Remark", True, False, False)
            .AddAgTextColumn(DGL2, "DGL2SubjectList", 150, 255, "Subject List", False, True, False)
            .AddAgTextColumn(DGL2, "DGL2MarksList", 150, 255, "Marks List", False, True, False)
            .AddAgTextColumn(DGL2, "DGL2PercentageList", 150, 255, "Percentage List", False, True, False)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 40
        DGL2.AgSkipReadOnlyColumns = True
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
            AgL.GridDesign(DGL2)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL2, False)
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
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " "

            If Not (AgL.StrCmp(AgL.PubUserName, "SA") Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName) Or AgL.PubIsUserAdmin) Then
                mCondStr += " AND (H.PreparedBy ='" & AgL.PubUserName & "' " & _
                                    " Or IsNull(E1.LogInUser,'') = '" & AgL.PubUserName & "' " & _
                                    " Or IsNull(E2.LogInUser,'') = '" & AgL.PubUserName & "' " & _
                                    " ) "
            End If

            mQry = "Select H.DocId As SearchCode " & _
                    " From Enquiry_Enquiry H " & _
                    " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                    " Left JOIN SubGroup E1 ON E1.SubCode = H.Employee " & _
                    " Left JOIN SubGroup E2 ON E2.SubCode = H.AssignedTo  " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
            TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
                  " Where NCat = " & AgL.Chk_Text(ClsMain.Temp_NCat.Enquiry) & "" & _
                  " Order By Description"
            TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT O.Code , O.Description Occupation " & _
                    " FROM Sch_Occupation O " & _
                    " ORDER BY O.Description "
            TxtFatherOccupation.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)
            TxtMotherOccupation.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            TxtCategory.AgHelpDataSet(0) = AgL.FillData("SELECT C.Code , C.ManualCode AS Name FROM Sch_Category C Order By C.ManualCode ", AgL.GCn)

            mQry = "SELECT DISTINCT E.Nationality AS Code, E.Nationality AS Name FROM Enquiry_Enquiry E WHERE IsNull(E.Nationality,'') <> '' ORDER BY E.Nationality"
            TxtNationality.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT R.Code, R.Description AS Religion FROM Sch_Religion R ORDER BY R.Description "
            TxtReligion.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Vs.Code , VS.SessionProgramme Name, " & _
                    " vs.Session, vs.Programme " & _
                    " FROM ViewSch_SessionProgramme VS " & _
                    " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY VS.SessionProgramme "
            TxtSessionProgramme.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT Vs.Code, VS.SessionProgrammeStream As Name, " & _
                    " vS.TotalSeats As [Total Seats], VS.SessionProgramme " & _
                    " FROM ViewSch_SessionProgrammeStream VS " & _
                    " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                    " ORDER BY VS.SessionProgrammeStream "
            TxtSessionProgrammeStream.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ManualCode AS Session " & _
                    " FROM Sch_Session S " & _
                    " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By S.ManualCode "
            TxtSession.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ManualCode AS Stream " & _
                    " FROM Sch_Stream S " & _
                    " WHERE " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By S.ManualCode "
            TxtStream.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT P.Code, P.ManualCode AS Programme " & _
                    " FROM Sch_Programme P " & _
                    " WHERE " & AgL.PubSiteCondition("P.Site_Code", AgL.PubSiteCode) & " " & _
                    " Order By P.ManualCode "
            TxtProgramme.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT E.SubCode AS Code, SG.DispName AS Employee, Sg.LogInUser, " & _
                    " CASE WHEN E.DateOfResign IS NOT NULL THEN 'Yes' ELSE 'No' END AS IsLeft, " & _
                    " E.DateOfResign As [Resign Date] " & _
                    " FROM Pay_Employee E " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=E.SubCode  " & _
                    " WHERE 1=1 " & _
                    " ORDER BY SG.DispName  "
            TxtEmployee.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)
            TxtAssignedTo.AgHelpDataSet(3) = TxtEmployee.AgHelpDataSet.Copy

            'mQry = " SELECT '" & ClsMain.EnquiryMode.EMail & "' AS Code ,'" & ClsMain.EnquiryMode.EMail & "' AS Name " & _
            '        " UNION ALL " & _
            '        " SELECT '" & ClsMain.EnquiryMode.Phone & "' AS Code ,'" & ClsMain.EnquiryMode.Phone & "' AS Name " & _
            '        " UNION ALL " & _
            '        " SELECT '" & ClsMain.EnquiryMode.SMS & "' AS Code ,'" & ClsMain.EnquiryMode.SMS & "' AS Name " & _
            '        " UNION ALL " & _
            '        " SELECT '" & ClsMain.EnquiryMode.WalkingAtOffice & "' AS Code ,'" & ClsMain.EnquiryMode.WalkingAtOffice & "' AS Name "
            'TxtEnquiryMode.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            AgCL.IniAgHelpList(TxtSex, "Male,Female")

            mQry = "SELECT U.Code , U.ManualCode [Board/University] FROM Sch_University U ORDER BY U.ManualCode "
            DGL2.AgHelpDataSet(Col2University) = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT DISTINCT E.FatherNamePrefix AS CODE, e.FatherNamePrefix AS Prefix " & _
                    " FROM Enquiry_Enquiry E WHERE E.FatherNamePrefix IS NOT NULL  "
            TxtFatherNamePrefix.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT DISTINCT E.MotherNamePrefix  AS CODE, e.MotherNamePrefix AS Prefix  " & _
                    " FROM Enquiry_Enquiry E WHERE E.FatherNamePrefix IS NOT NULL "
            TxtMotherNamePrefix.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT Distinct R.DocId AS Code,R.ReferenceNo  FROM Enquiry_Enquiry R " & _
               " WHERE R.ReferenceNo IS NOT NULL "
            TxtReferenceNo.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)


            Call IniDataSet_EnquiryMode()
            Call IniHelp_EnquiryMode()
            Call IniCityHelp()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IniCityHelp()
        Try
            mQry = "SELECT C.CityCode Code, C.CityName AS City " & _
                    " FROM City C " & _
                    " ORDER BY  C.CityName "
            TxtCityCode.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl_tbDel() Handles Topctrl1.tbDel

        Call FunTransFLag()
        If mTransFlag = True Then
            MsgBox(" Entry can not Change !")
            Topctrl1.FButtonClick(14, True)
        End If

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

                    AgL.Dman_ExecuteNonQry("Delete From Enquiry_MeritMarks Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Enquiry_AcademicDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Enquiry_Enquiry Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        If mStrAdmissionDocId.Trim <> "" Then
            MsgBox("Student Is Admitted!")
            Topctrl1.FButtonClick(14, True)
            Exit Sub
        End If

        If mStrRegisterationDocId.Trim <> "" Then
            MsgBox("Student Is Registered!")
            Topctrl1.FButtonClick(14, True)
            Exit Sub
        End If

        Call FunTransFLag()
        If mTransFlag = True Then
            MsgBox(" Entry can not Change !")
            Topctrl1.FButtonClick(14, True)
            Exit Sub
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
                mCondStr += " AND (H.PreparedBy ='" & AgL.PubUserName & "' " & _
                                    " Or IsNull(Sg.LogInUser,'') = '" & AgL.PubUserName & "' " & _
                                    " Or IsNull(E2.LogInUser,'') = '" & AgL.PubUserName & "' " & _
                                    " ) "
            End If


            AgL.PubFindQry = " SELECT  H.DocId AS SearchCode, " & AgL.V_No_Field("H.DocId") & " As [Enquiry No],H.V_Date AS [" & LblV_Date.Text & "], H.EnquiryMode AS [Enquiry Mode], " & _
                                " SG.DispName AS [" & LblEmployee.Text & "], E2.DispName AS [" & LblAssignedTo.Text & "], " & _
                                " S.ManualCode AS [Session], P.ManualCode AS [Programme], Stream.ManualCode AS [Stream], " & _
                                " isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS Name, " & _
                                " C.CityName AS City, H.Mobile, H.EMail,H.Status, H.PreparedBy, H.ModifiedBy " & _
                                " FROM Enquiry_Enquiry H " & _
                                " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee  " & _
                                " Left JOIN SubGroup E2 ON E2.SubCode = H.AssignedTo  " & _
                                " LEFT JOIN Sch_Session S ON S.Code=H.Session " & _
                                " LEFT JOIN Sch_Programme P ON P.Code=H.Programme " & _
                                " LEFT JOIN Sch_Stream Stream ON Stream.Code=H.Stream " & _
                                " LEFT JOIN City C ON C.CityCode=H.CityCode " & _
                                " " & mCondStr & " "

            AgL.PubFindQryOrdBy = " Convert(SmallDateTime,[" & LblV_Date.Text & "]) Desc, [Enquiry No] "


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
                mQry = " INSERT INTO Enquiry_Enquiry ( DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, " & _
                        " EnquiryMode, Employee, SessionProgramme, SessionProgrammeStream, FirstName, MiddleName, LastName, " & _
                        " Add1, Add2, CityCode, PIN, Phone, Mobile, EMail, Sex, DOB, " & _
                        " Nationality, Religion, Category, FatherName, FatherNamePrefix, MotherName, " & _
                        " MotherNamePrefix, FatherOccupation, FatherIncome, FamilyIncome, MotherOccupation, MotherIncome, " & _
                        " Status, Remark, AssignedTo, Session, Programme, Stream, " & _
                        " PreparedBy, U_EntDt, U_AE ,ReferenceNo ) " & _
                        " VALUES  ( '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & "," & Val(TxtV_No.Text) & ",  " & _
                        " " & AgL.Chk_Text(TxtEnquiryMode.Text) & ", " & AgL.Chk_Text(TxtEmployee.AgSelectedValue) & ", " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & ", " & AgL.Chk_Text(TxtFirstName.Text) & ", " & AgL.Chk_Text(TxtMiddleName.Text) & ", " & AgL.Chk_Text(TxtLastName.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtAdd1.Text) & ", " & AgL.Chk_Text(TxtAdd2.Text) & ", " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtPin.Text) & ", " & AgL.Chk_Text(TxtPhone.Text) & ", " & AgL.Chk_Text(TxtMobile.Text) & "," & AgL.Chk_Text(TxtEMail.Text) & "," & AgL.Chk_Text(TxtSex.Text) & ", " & AgL.ConvertDate(TxtDOB.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtNationality.Text) & ", " & AgL.Chk_Text(TxtReligion.AgSelectedValue) & ", " & AgL.Chk_Text(TxtCategory.AgSelectedValue) & ", " & AgL.Chk_Text(TxtFatherName.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtFatherNamePrefix.Text) & ", " & AgL.Chk_Text(TxtMotherName.Text) & ", " & AgL.Chk_Text(TxtMotherNamePrefix.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtFatherOccupation.AgSelectedValue) & ", " & Val(TxtFatherIncome.Text) & "," & Val(TxtFamilyIncome.Text) & ", " & AgL.Chk_Text(TxtMotherOccupation.AgSelectedValue) & ", " & _
                        " " & Val(TxtMotherIncome.Text) & ", " & AgL.Chk_Text(TxtStatus.Text) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & AgL.Chk_Text(TxtAssignedTo.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ", " & AgL.Chk_Text(TxtProgramme.AgSelectedValue) & ", " & AgL.Chk_Text(TxtStream.AgSelectedValue) & ", " & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A' ," & AgL.Chk_Text(TxtReferenceNo.Text) & " )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            Else
                mQry = " UPDATE Enquiry_Enquiry " & _
                        " SET EnquiryMode = " & AgL.Chk_Text(TxtEnquiryMode.Text) & ", " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " Employee = " & AgL.Chk_Text(TxtEmployee.AgSelectedValue) & ", " & _
                        " SessionProgramme = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & ", " & _
                        " SessionProgrammeStream = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & ", " & _
                        " FirstName = " & AgL.Chk_Text(TxtFirstName.Text) & ", " & _
                        " MiddleName = " & AgL.Chk_Text(TxtMiddleName.Text) & ", " & _
                        " LastName = " & AgL.Chk_Text(TxtLastName.Text) & ", " & _
                        " Add1 = " & AgL.Chk_Text(TxtAdd1.Text) & ", " & _
                        " Add2 = " & AgL.Chk_Text(TxtAdd2.Text) & ", " & _
                        " CityCode = " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & ", " & _
                        " PIN = " & AgL.Chk_Text(TxtPin.Text) & ", " & _
                        " Phone = " & AgL.Chk_Text(TxtPhone.Text) & ", " & _
                        " Mobile = " & AgL.Chk_Text(TxtMobile.Text) & ", " & _
                        " EMail =" & AgL.Chk_Text(TxtEMail.Text) & ", " & _
                        " Sex = " & AgL.Chk_Text(TxtSex.Text) & ", " & _
                        " DOB = " & AgL.ConvertDate(TxtDOB.Text) & ", " & _
                        " Nationality = " & AgL.Chk_Text(TxtNationality.Text) & ", " & _
                        " Religion = " & AgL.Chk_Text(TxtReligion.AgSelectedValue) & ", " & _
                        " Category = " & AgL.Chk_Text(TxtCategory.AgSelectedValue) & ", " & _
                        " FatherName = " & AgL.Chk_Text(TxtFatherName.Text) & ", " & _
                        " FatherNamePrefix = " & AgL.Chk_Text(TxtFatherNamePrefix.Text) & ", " & _
                        " MotherName = " & AgL.Chk_Text(TxtMotherName.Text) & ", " & _
                        " MotherNamePrefix = " & AgL.Chk_Text(TxtMotherNamePrefix.Text) & ", " & _
                        " FatherOccupation = " & AgL.Chk_Text(TxtFatherOccupation.AgSelectedValue) & ", " & _
                        " FatherIncome = " & Val(TxtFatherIncome.Text) & ", " & _
                        " FamilyIncome = " & Val(TxtFamilyIncome.Text) & ", " & _
                        " MotherOccupation = " & AgL.Chk_Text(TxtMotherOccupation.AgSelectedValue) & ", " & _
                        " MotherIncome = " & Val(TxtMotherIncome.Text) & ", " & _
                        " Remark = " & AgL.Chk_Text(TxtRemark.Text) & ", " & _
                        " AssignedTo = " & AgL.Chk_Text(TxtAssignedTo.AgSelectedValue) & ", " & _
                        " Session = " & AgL.Chk_Text(TxtSession.AgSelectedValue) & ", " & _
                        " Programme = " & AgL.Chk_Text(TxtProgramme.AgSelectedValue) & ", " & _
                        " Stream = " & AgL.Chk_Text(TxtStream.AgSelectedValue) & ", " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', " & _
                        " U_AE = 'E'," & _
                        " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & "," & _
                        " ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " WHERE DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Enquiry_MeritMarks Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "Delete From Enquiry_AcademicDetail Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DGL2
                mSr = 0
                For I = 0 To .Rows.Count - 1
                    If DGL2.Item(Col2SubjectList, I).Value Is Nothing Then DGL2.Item(Col2SubjectList, I).Value = ""
                    If DGL2.Item(Col2MarksList, I).Value Is Nothing Then DGL2.Item(Col2MarksList, I).Value = ""
                    If DGL2.Item(Col2PercentageList, I).Value Is Nothing Then DGL2.Item(Col2PercentageList, I).Value = ""
                    bStrArrSubject = Nothing : bStrArrMarks = Nothing : bStrArrPercentage = Nothing

                    If .Item(Col2Class, I).Value <> "" Then
                        mSr = mSr + 1

                        mQry = " INSERT INTO Enquiry_AcademicDetail ( DocId, Sr, Class, University, EnrollmentNo, " & _
                                " YearOfPassing, Subjects, Result, TotalPercentage, MeritPercentage, Remark ) " & _
                                " VALUES  ( '" & mSearchCode & "', " & mSr & ", " & AgL.Chk_Text(.Item(Col2Class, I).Value) & ", " & AgL.Chk_Text(.AgSelectedValue(Col2University, I)) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col2EnrollmentNo, I).Value) & ", " & Val(.Item(Col2YearOfPassing, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col2Subjects, I).Value) & ", " & AgL.Chk_Text(.Item(Col2Result, I).Value) & ", " & _
                                " " & Val(.Item(Col2TotalPercentage, I).Value) & ", " & Val(.Item(Col2MeritPercentage, I).Value) & ", " & AgL.Chk_Text(.Item(Col2Remark, I).Value) & " ) "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        If .Item(Col2SubjectList, I).Value.ToString <> "" Then
                            bStrArrSubject = Split(.Item(Col2SubjectList, I).Value.ToString, ",")
                        End If

                        If .Item(Col2MarksList, I).Value.ToString <> "" Then
                            bStrArrMarks = Split(.Item(Col2MarksList, I).Value.ToString, ",")
                        End If

                        If .Item(Col2PercentageList, I).Value.ToString <> "" Then
                            bStrArrPercentage = Split(.Item(Col2PercentageList, I).Value.ToString, ",")
                        End If

                        bIntSrMarks = 0
                        If bStrArrSubject IsNot Nothing Then
                            For bIntJ = 0 To bStrArrSubject.Length - 1
                                bIntSrMarks += 1

                                mQry = "INSERT INTO Enquiry_MeritMarks (DocId, ClassSr, Sr, Subject, Marks, Percentage) " & _
                                        " VALUES ('" & mSearchCode & "', " & mSr & ", " & bIntSrMarks & ", " & AgL.Chk_Text(bStrArrSubject(bIntJ)) & ", " & _
                                        " " & Val(bStrArrMarks(bIntJ)) & ", " & Val(bStrArrPercentage(bIntJ)) & ") "
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            Next
                        End If
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

                mTmStrEmployee = TxtEmployee.AgSelectedValue

                Topctrl1.FButtonClick(0)

                'If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                '    Call PrintDocument(mDocId)
                'End If

                Exit Sub
            Else
                mTmV_Type = "" : mTmV_Prefix = "" : mTmV_Date = "" : mTmV_NCat = ""
                mTmStrEmployee = ""

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
                mQry = "Select R.*, Vt.NCat " & _
                        " From Enquiry_Enquiry R " & _
                        " Left Join Voucher_Type Vt On R.V_Type = Vt.V_Type " & _
                        " Where R.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDocId.Text = mSearchCode
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                        TxtV_No.Text = Format(AgL.VNull(.Rows(0)("V_No")), "0.".PadRight(+2, "0"))
                        LblV_Type.Tag = AgL.XNull(.Rows(0)("NCat"))


                        mStrAdmissionDocId = AgL.XNull(AgL.Dman_Execute("SELECT A.DocId FROM Sch_Admission A With (NoLock) WHERE A.EnquiryDocId = '" & mSearchCode & "'", AgL.GcnRead).ExecuteScalar)
                        mStrRegisterationDocId = AgL.XNull(AgL.Dman_Execute("SELECT A.DocId FROM Sch_Registration A With (NoLock) WHERE A.EnquiryDocId = '" & mSearchCode & "'", AgL.GcnRead).ExecuteScalar)

                        TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgramme"))
                        TxtSessionProgrammeStream.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgrammeStream"))

                        TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))

                        TxtSession.AgSelectedValue = AgL.XNull(.Rows(0)("Session"))
                        TxtProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("Programme"))
                        TxtStream.AgSelectedValue = AgL.XNull(.Rows(0)("Stream"))

                        TxtEmployee.AgSelectedValue = AgL.XNull(.Rows(0)("Employee"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))
                        TxtEnquiryMode.Text = AgL.XNull(.Rows(0)("EnquiryMode"))
                        TxtFirstName.Text = AgL.XNull(.Rows(0)("FirstName"))
                        TxtMiddleName.Text = AgL.XNull(.Rows(0)("MiddleName"))
                        TxtLastName.Text = AgL.XNull(.Rows(0)("LastName"))
                        TxtAdd1.Text = AgL.XNull(.Rows(0)("Add1"))
                        TxtAdd2.Text = AgL.XNull(.Rows(0)("Add2"))
                        TxtCityCode.AgSelectedValue = AgL.XNull(.Rows(0)("CityCode"))
                        TxtPin.Text = AgL.XNull(.Rows(0)("Pin"))
                        TxtPhone.Text = AgL.XNull(.Rows(0)("Phone"))
                        TxtMobile.Text = AgL.XNull(.Rows(0)("Mobile"))
                        TxtEMail.Text = AgL.XNull(.Rows(0)("EMail"))
                        TxtSex.Text = AgL.XNull(.Rows(0)("Sex"))
                        TxtNationality.Text = AgL.XNull(.Rows(0)("Nationality"))
                        TxtReligion.AgSelectedValue = AgL.XNull(.Rows(0)("Religion"))
                        TxtCategory.AgSelectedValue = AgL.XNull(.Rows(0)("Category"))
                        TxtFatherName.Text = AgL.XNull(.Rows(0)("FatherName"))
                        TxtFatherNamePrefix.Text = AgL.XNull(.Rows(0)("FatherNamePrefix"))
                        TxtMotherName.Text = AgL.XNull(.Rows(0)("MotherName"))
                        TxtMotherNamePrefix.Text = AgL.XNull(.Rows(0)("MotherNamePrefix"))
                        TxtDOB.Text = Format(AgL.XNull(.Rows(0)("DOB")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtFatherOccupation.AgSelectedValue = AgL.XNull(.Rows(0)("FatherOccupation"))
                        TxtMotherOccupation.AgSelectedValue = AgL.XNull(.Rows(0)("MotherOccupation"))

                        TxtFatherIncome.Text = Format(AgL.VNull(.Rows(0)("FatherIncome")), "0.00")
                        TxtMotherIncome.Text = Format(AgL.VNull(.Rows(0)("MotherIncome")), "0.00")
                        TxtFamilyIncome.Text = Format(AgL.VNull(.Rows(0)("FamilyIncome")), "0.00")

                        TxtAssignedTo.AgSelectedValue = AgL.XNull(.Rows(0)("AssignedTo"))




                        TxtStatus.Text = AgL.XNull(.Rows(0)("Status"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)

                    End If
                End With


                mQry = "Select Ad.* " & _
                        " From Enquiry_AcademicDetail Ad " & _
                        " Where Ad.DocId = '" & mSearchCode & "' " & _
                        " Order By Ad.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        DGL2.RowCount = 1 : DGL2.Rows.Clear()
                        For I = 0 To .Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col_SNo, I).Value = AgL.VNull(.Rows(I)("Sr"))
                            DGL2.Item(Col2Class, I).Value = AgL.XNull(.Rows(I)("Class"))
                            DGL2.AgSelectedValue(Col2University, I) = AgL.XNull(.Rows(I)("University"))
                            DGL2.Item(Col2EnrollmentNo, I).Value = AgL.XNull(.Rows(I)("EnrollmentNo"))
                            DGL2.Item(Col2YearOfPassing, I).Value = AgL.VNull(.Rows(I)("YearOfPassing"))
                            DGL2.Item(Col2Subjects, I).Value = AgL.XNull(.Rows(I)("Subjects"))
                            DGL2.Item(Col2Result, I).Value = AgL.XNull(.Rows(I)("Result"))
                            DGL2.Item(Col2TotalPercentage, I).Value = Format(AgL.VNull(.Rows(I)("TotalPercentage")), "0.00")
                            DGL2.Item(Col2MeritPercentage, I).Value = Format(AgL.VNull(.Rows(I)("MeritPercentage")), "0.00")
                            DGL2.Item(Col2Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))

                            mQry = "SELECT M.* " & _
                                    " FROM Enquiry_MeritMarks M " & _
                                    " WHERE M.DocId = '" & mSearchCode & "' " & _
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

                            DGL2.Item(Col2SubjectList, I).Value = bStrSubjectList
                            DGL2.Item(Col2MarksList, I).Value = bStrMarksList
                            DGL2.Item(Col2PercentageList, I).Value = bStrPercentageList
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
        DGL2.RowCount = 1 : DGL2.Rows.Clear()

        mTransFlag = False : mBlnImprtFromExcelFlag = False
        mStrAdmissionDocId = "" : mStrRegisterationDocId = ""

        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If

        If mTmStrEmployee.Trim <> "" Then
            TxtEmployee.AgSelectedValue = mTmStrEmployee
        End If
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False : TxtFamilyIncome.Enabled = False
        TxtStatus.Enabled = False : TxtEmployee.Enabled = False

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
        TxtV_Type.Enter, TxtSessionProgrammeStream.Enter, TxtSessionProgramme.Enter, TxtEmployee.Enter, _
        TxtAssignedTo.Enter

        Try
            Select Case sender.name
                Case TxtSessionProgrammeStream.Name
                    If TxtSessionProgramme.AgSelectedValue Is Nothing Then TxtSessionProgramme.AgSelectedValue = ""
                    TxtSessionProgrammeStream.AgRowFilter = " SessionProgramme = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "

                Case TxtEmployee.Name, TxtAssignedTo.Name
                    sender.AgRowFilter = " IsLeft = 'No' "
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtV_Type.Validating, TxtV_No.Validating, TxtV_Date.Validating, _
          TxtSite_Code.Validating, TxtSessionProgrammeStream.Validating, TxtRemark.Validating, _
          TxtReligion.Validating, TxtPhone.Validating, TxtFatherOccupation.Validating, TxtNationality.Validating, _
          TxtMotherNamePrefix.Validating, TxtMotherName.Validating, TxtMobile.Validating, TxtMiddleName.Validating, TxtLastName.Validating, _
          TxtFirstName.Validating, TxtFatherNamePrefix.Validating, TxtFatherName.Validating, _
          TxtFatherIncome.Validating, TxtMotherIncome.Validating, _
          TxtDocId.Validating, TxtDOB.Validating, TxtCityCode.Validating, TxtCategory.Validating, _
          TxtEmployee.Validating, TxtAdd2.Validating, TxtAdd1.Validating, TxtSessionProgramme.Validating, TxtAssignedTo.Validating, _
          TxtSession.Validating, TxtProgramme.Validating, TxtStream.Validating, TxtEnquiryMode.Validating

        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    Call ProcValidatingControl(sender)

                Case TxtV_Date.Name
                    Call ProcValidatingControl(sender)
                Case TxtEnquiryMode.Name
                    Call ProcValidatingControl(sender)
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
        TxtFamilyIncome.Text = Format(Val(TxtFatherIncome.Text) + Val(TxtMotherIncome.Text), "0.00")


    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStrModule$ = ""
        Dim bStrName As String
        Dim DrTemp As DataRow() = Nothing
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function
            If AgL.RequiredField(TxtEnquiryMode, LblEnquiryMode.Text) Then Exit Function
            If AgL.RequiredField(TxtEmployee, LblEmployee.Text) Then Exit Function
            If AgL.RequiredField(TxtSession, LblSession.Text) Then Exit Function
            If AgL.RequiredField(TxtFirstName, LblFirstName.Text) Then Exit Function

            If Not AgL.IsValid_EMailId(TxtEMail, "Email ID") Then Exit Function


            If mBlnImprtFromExcelFlag = False Then
                If TxtAssignedTo.Text.Trim = "" Then
                    If MsgBox("" & LblAssignedTo.Text & " Is not defined!" & vbCrLf & "Do you want to self assign?...", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                        TxtAssignedTo.AgSelectedValue = TxtEmployee.AgSelectedValue
                    End If
                End If

                If TxtReferenceNo.Text.Trim = "" Then
                    If MsgBox("" & LblReferenceNo.Text & " is Blank!..." & vbCrLf & "Do You Want To Auto Assign It?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Validation Check") = MsgBoxResult.Yes Then
                        TxtReferenceNo.Text = AgL.ConvertDocId(mSearchCode)
                    End If
                End If
                If AgL.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then Exit Function
                If Topctrl1.Mode = "Add" Then
                    AgL.ECmd = AgL.Dman_Execute("Select count(*) From Enquiry_Enquiry Where ReferenceNo='" & TxtReferenceNo.Text & "' ", AgL.GCn)
                    If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Reference No. Already Exist!") : TxtReferenceNo.Focus() : Exit Function
                Else
                    AgL.ECmd = AgL.Dman_Execute("Select count(*) From Enquiry_Enquiry Where ReferenceNo='" & TxtReferenceNo.Text & "' And DocId<>'" & mSearchCode & "' ", AgL.GCn)
                    If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Reference No. Already Exist!") : TxtReferenceNo.Focus() : Exit Function
                End If

            End If

            If TxtSessionProgramme.Text <> "" Then
                DrTemp = TxtSessionProgramme.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & "")
                If DrTemp.Length > 0 Then
                    If Not AgL.StrCmp(TxtSession.AgSelectedValue, AgL.XNull(DrTemp(0)("Session"))) Then
                        TxtSessionProgramme.AgSelectedValue = ""
                    Else
                        If Not AgL.StrCmp(TxtProgramme.AgSelectedValue, AgL.XNull(DrTemp(0)("Programme"))) Then
                            TxtSessionProgramme.AgSelectedValue = ""
                        End If
                    End If
                Else
                    TxtSessionProgramme.AgSelectedValue = ""
                End If
            End If
            If DrTemp IsNot Nothing Then DrTemp = Nothing


            If TxtSessionProgrammeStream.Text <> "" Then
                DrTemp = TxtSessionProgrammeStream.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & "")
                If DrTemp.Length > 0 Then
                    If Not AgL.StrCmp(TxtSessionProgramme.AgSelectedValue, AgL.XNull(DrTemp(0)("SessionProgramme"))) Then
                        TxtSessionProgramme.AgSelectedValue = ""
                    Else
                        If Not AgL.StrCmp(TxtProgramme.AgSelectedValue, AgL.XNull(DrTemp(0)("Programme"))) Then
                            TxtSessionProgramme.AgSelectedValue = ""
                        End If
                    End If
                Else
                    TxtSessionProgramme.AgSelectedValue = ""
                End If
            End If
            If DrTemp IsNot Nothing Then DrTemp = Nothing


            If TxtDOB.Text.Trim <> "" Then
                If CDate(TxtDOB.Text) >= CDate(TxtV_Date.Text) Then
                    MsgBox("Date Of Birth Is Not Correct!...")
                    TxtDOB.Focus()
                    If mBlnImprtFromExcelFlag = False Then Exit Function
                End If
            End If

            bStrName = TxtFirstName.Text + TxtMiddleName.Text + TxtLastName.Text
            If bStrName.Length > 100 Then
                MsgBox("Name Can not more than 100 !")
                TxtFirstName.Focus() : Exit Function
            End If

            AgCL.AgBlankNothingCells(DGL2)

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If TxtDocId.Text.Trim = "" Then TxtDocId.Text = mSearchCode
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
        TxtStatus.Text = ClsMain.EnquiryStatus.NewEnquiry

        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            DrTemp = TxtV_Type.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RegistrationEntry) & "")
            If DrTemp.Length > 0 Then
                TxtV_Type.AgSelectedValue = Academic_ProjLib.ClsMain.NCat_RegistrationEntry
                LblV_Type.Tag = ClsMain.Temp_NCat.Enquiry
            Else
                TxtV_Type.AgSelectedValue = ""
                LblV_Type.Tag = ""
            End If
            DrTemp = Nothing

            TxtV_Type.Enabled = True
        End If

        If mTmStrEmployee.Trim = "" Then
            DrTemp = TxtEmployee.AgHelpDataSet.Tables(0).Select("LogInUser = " & AgL.Chk_Text(AgL.PubUserName) & "")
            If DrTemp.Length > 0 Then
                TxtEmployee.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
            End If
            DrTemp = Nothing
        End If

        Call ProcValidatingControl(TxtV_Date)

        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled Then TxtV_Type.Focus() Else TxtEnquiryMode.Focus()
        Else
            TxtEnquiryMode.Focus()
        End If
    End Sub

    Private Sub DGL2_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL2.CellContentClick
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Dim FrmObj As Form

        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            Select Case DGL2.CurrentCell.ColumnIndex
                Case Col2FillSubjectMarks
                    If DGL2.Item(Col2SubjectList, mRowIndex).Value Is Nothing Then DGL2.Item(Col2SubjectList, mRowIndex).Value = ""
                    If DGL2.Item(Col2MarksList, mRowIndex).Value Is Nothing Then DGL2.Item(Col2MarksList, mRowIndex).Value = ""
                    If DGL2.Item(Col2PercentageList, mRowIndex).Value Is Nothing Then DGL2.Item(Col2PercentageList, mRowIndex).Value = ""

                    FrmObj = New FrmSubjectMarks()
                    CType(FrmObj, FrmSubjectMarks).StrSubjectList = DGL2.Item(Col2SubjectList, mRowIndex).Value
                    CType(FrmObj, FrmSubjectMarks).StrMarksList = DGL2.Item(Col2MarksList, mRowIndex).Value
                    CType(FrmObj, FrmSubjectMarks).StrPercentageList = DGL2.Item(Col2PercentageList, mRowIndex).Value
                    CType(FrmObj, FrmSubjectMarks).DblNetPercentage = Val(DGL2.Item(Col2MeritPercentage, mRowIndex).Value)

                    FrmObj.ShowDialog()
                    DGL2.Item(Col2SubjectList, mRowIndex).Value = CType(FrmObj, FrmSubjectMarks).StrSubjectList
                    DGL2.Item(Col2MarksList, mRowIndex).Value = CType(FrmObj, FrmSubjectMarks).StrMarksList
                    DGL2.Item(Col2PercentageList, mRowIndex).Value = CType(FrmObj, FrmSubjectMarks).StrPercentageList
                    DGL2.Item(Col2MeritPercentage, mRowIndex).Value = Format(CType(FrmObj, FrmSubjectMarks).DblNetPercentage, "0.00")
                    FrmObj = Nothing
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL2.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FunTransFLag()
        mTransFlag = False
        If mSearchCode.Trim <> "" Then
            mQry = " SELECT Count(* ) FROM Enquiry_FollowUp H " & _
                    " WHERE H.EnquiryDocId = " & AgL.Chk_Text(mSearchCode) & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then mTransFlag = True
        Else
            mTransFlag = False
        End If
    End Sub

    Private Sub ProcValidatingControl(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtV_Type.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    LblV_Type.Tag = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
                    End If
                End If
                DrTemp = Nothing

            Case TxtV_Date.Name
                If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate
                TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text.ToString)

            Case TxtEnquiryMode.Name
                If TxtEnquiryMode.AgMasterHelp Then
                    If AgL.XNull(TxtEnquiryMode.Text).ToString.Trim <> "" Then
                        DrTemp = TxtEnquiryMode.AgHelpDataSet.Tables(0).Select("Name = " & AgL.Chk_Text(TxtEnquiryMode.Text) & "")
                        If DrTemp.Length > 0 Then
                            TxtEnquiryMode.Tag = AgL.XNull(DrTemp(0)("Code"))
                        Else
                            TxtEnquiryMode.Tag = ""
                            If MsgBox("Are You Sure To Create " & TxtEnquiryMode.Text & " : """ & TxtEnquiryMode.Text & """?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                Dim GcnRead As SqlClient.SqlConnection = AgL.FunGetReadConnection()
                                If mObjClsMain.FunCreateEnquiryMode(TxtEnquiryMode.Text, GcnRead) Then
                                    TxtEnquiryMode.Tag = TxtEnquiryMode.Text
                                    Call IniDataSet_EnquiryMode() : Call IniHelp_EnquiryMode()
                                End If
                                If GcnRead IsNot Nothing Then GcnRead.Dispose()
                            Else
                                TxtEnquiryMode.AgSelectedValue = ""
                            End If
                        End If

                        If AgL.XNull(TxtEnquiryMode.Tag).ToString.Trim <> "" Then
                            TxtEnquiryMode.AgMasterHelp = False
                        End If
                    End If
                End If

        End Select

    End Sub

    Public Sub IniDataSet_EnquiryMode()
        Try
            mQry = "SELECT H.Code, H.Code AS Name FROM Sch_EnquiryMode H With (NoLock) ORDER BY H.Code"
            HelpDataSet.EnquiryMode = AgL.FillData(mQry, AgL.GcnRead)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub IniHelp_EnquiryMode()
        Try
            TxtEnquiryMode.AgHelpDataSet(0) = HelpDataSet.EnquiryMode.Copy
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub BtnImprtFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprtFromExcel.Click
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim FW As System.IO.StreamWriter = New System.IO.StreamWriter("C:\ImportLog.Txt", False, System.Text.Encoding.Default)
        Dim StrErrLog As String = ""
        Dim DrTemp As DataRow() = Nothing


        mQry = "                  Select '' as Srl, 'ID' as [Field Name],'NUMBER' as [Data Type], 8 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Enquiry Date' as [Field Name],'DATETIME' as [Data Type], 0 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Enquiry Mode' as [Field Name],'Text' as [Data Type], 20 as [Length] , 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Enquiry By' as [Field Name],'Text' as [Data Type], 10 as [Length]  , 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Assigned To' as [Field Name],'Text' as [Data Type], 10 as [Length]  , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Session' as [Field Name],'Text' as [Data Type], 5 as [Length]  , 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Programme' as [Field Name],'Text' as [Data Type], 20 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Stream' as [Field Name],'Text' as [Data Type], 20 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'First Name' as [Field Name],'Text' as [Data Type], 100 as [Length]  , 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Middle Name' as [Field Name],'Text' as [Data Type], 100 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Last Name' as [Field Name],'Text' as [Data Type], 100 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Address Row1' as [Field Name],'Text' as [Data Type], 50 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Address Row2' as [Field Name],'Text' as [Data Type], 50 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'City' as [Field Name],'Text' as [Data Type], 50 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'PIN' as [Field Name],'Text' as [Data Type], 6 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Phone' as [Field Name],'Text' as [Data Type], 35 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Mobile' as [Field Name],'Text' as [Data Type], 35 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'EMail' as [Field Name],'Text' as [Data Type], 40 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Sex' as [Field Name],'Text' as [Data Type], 6 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'DOB' as [Field Name],'DATETIME' as [Data Type], 0 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Nationality' as [Field Name],'Text' as [Data Type], 50 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Religion' as [Field Name],'Text' as [Data Type], 50 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Category' as [Field Name],'Text' as [Data Type], 20 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Father Name' as [Field Name],'Text' as [Data Type], 100 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Mother Name' as [Field Name],'Text' as [Data Type], 100 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Father Occupation' as [Field Name],'Text' as [Data Type], 50 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Mother Occupation' as [Field Name],'Text' as [Data Type], 50 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Father Income' as [Field Name],'NUMBER' as [Data Type], 0 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Mother Income' as [Field Name],'NUMBER' as [Data Type], 0 as [Length]   , 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Remark' as [Field Name],'Text' as [Data Type], 255 as [Length]   , 'No' As [Mandatory] "


        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Dim ObjFrmImport As New FrmImportFromExcel
        ObjFrmImport.LblTitle.Text = "Enquiry Import"
        ObjFrmImport.Dgl1.DataSource = DtTemp
        ObjFrmImport.ShowDialog()

        If Not AgL.StrCmp(ObjFrmImport.UserAction, "OK") Then Exit Sub
        'If Not ObjFrmImport.P_DsExcelData Is Nothing Then Exit Sub

        DtTemp = ObjFrmImport.P_DsExcelData.Tables(0)
        For I = 0 To DtTemp.Rows.Count - 1
            Topctrl1.FButtonClick(0)

            mBlnImprtFromExcelFlag = True

            TxtV_Date.Text = Format(AgL.XNull(DtTemp.Rows(I)("Enquiry Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)

            TxtRemark.Text = AgL.XNull(DtTemp.Rows(I)("Remark"))
            TxtFirstName.Text = AgL.XNull(DtTemp.Rows(I)("First Name"))
            TxtMiddleName.Text = AgL.XNull(DtTemp.Rows(I)("Middle Name"))
            TxtLastName.Text = AgL.XNull(DtTemp.Rows(I)("Last Name"))
            TxtAdd1.Text = AgL.XNull(DtTemp.Rows(I)("Address Row1"))
            TxtAdd2.Text = AgL.XNull(DtTemp.Rows(I)("Address Row2"))

            TxtPin.Text = AgL.XNull(DtTemp.Rows(I)("Pin"))
            TxtPhone.Text = AgL.XNull(DtTemp.Rows(I)("Phone"))
            TxtMobile.Text = AgL.XNull(DtTemp.Rows(I)("Mobile"))
            TxtEMail.Text = AgL.XNull(DtTemp.Rows(I)("EMail"))
            TxtSex.Text = AgL.XNull(DtTemp.Rows(I)("Sex"))
            TxtFatherName.Text = AgL.XNull(DtTemp.Rows(I)("Father Name"))
            TxtMotherName.Text = AgL.XNull(DtTemp.Rows(I)("Mother Name"))
            TxtDOB.Text = Format(AgL.XNull(DtTemp.Rows(I)("DOB")), AgLibrary.ClsConstant.DateFormat_ShortDate)

            TxtFatherIncome.Text = Format(AgL.VNull(DtTemp.Rows(I)("Father Income")), "0.00")
            TxtMotherIncome.Text = Format(AgL.VNull(DtTemp.Rows(I)("Mother Income")), "0.00")
            TxtFamilyIncome.Text = Format(Val(TxtFatherIncome.Text) + Val(TxtMotherIncome.Text), "0.00")

            TxtNationality.Text = AgL.XNull(DtTemp.Rows(I)("Nationality"))

            DrTemp = TxtSession.AgHelpDataSet.Tables(0).Select("Session = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Session"))) & "")
            If DrTemp.Length > 0 Then
                TxtSession.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
            End If
            DrTemp = Nothing

            DrTemp = TxtProgramme.AgHelpDataSet.Tables(0).Select("Programme = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Programme"))) & "")
            If DrTemp.Length > 0 Then
                TxtProgramme.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
            End If
            DrTemp = Nothing

            DrTemp = TxtStream.AgHelpDataSet.Tables(0).Select("Stream = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Stream"))) & "")
            If DrTemp.Length > 0 Then
                TxtStream.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
            End If
            DrTemp = Nothing

            DrTemp = TxtEmployee.AgHelpDataSet.Tables(0).Select("LogInUser = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Enquiry By"))) & "")
            If DrTemp.Length > 0 Then
                TxtEmployee.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
            End If
            DrTemp = Nothing

            DrTemp = TxtAssignedTo.AgHelpDataSet.Tables(0).Select("LogInUser = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Assigned To"))) & "")
            If DrTemp.Length > 0 Then
                TxtAssignedTo.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
            End If
            DrTemp = Nothing

            DrTemp = TxtEnquiryMode.AgHelpDataSet.Tables(0).Select("Name = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Enquiry Mode"))) & "")
            If DrTemp.Length > 0 Then
                TxtEnquiryMode.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
            End If
            DrTemp = Nothing


            If AgL.XNull(DtTemp.Rows(I)("City")).ToString.Trim <> "" Then
                DrTemp = TxtCityCode.AgHelpDataSet.Tables(0).Select("City = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("City"))) & "")
                If DrTemp.Length > 0 Then
                    TxtCityCode.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                Else
                    LblCity.Tag = mObjClsMain.FunCreateCity(AgL.XNull(DtTemp.Rows(I)("City")), AgL.GCn)
                    Call IniCityHelp()
                    TxtCityCode.AgSelectedValue = AgL.XNull(LblCity.Tag)
                End If
                DrTemp = Nothing
            End If

            If AgL.XNull(DtTemp.Rows(I)("Religion")).ToString.Trim <> "" Then
                DrTemp = TxtReligion.AgHelpDataSet.Tables(0).Select("Religion = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Religion"))) & "")
                If DrTemp.Length > 0 Then
                    TxtReligion.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                End If
                DrTemp = Nothing
            End If

            If AgL.XNull(DtTemp.Rows(I)("Category")).ToString.Trim <> "" Then
                DrTemp = TxtCategory.AgHelpDataSet.Tables(0).Select("Name = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Category"))) & "")
                If DrTemp.Length > 0 Then
                    TxtCategory.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                End If
                DrTemp = Nothing

            End If

            If AgL.XNull(DtTemp.Rows(I)("Father Occupation")).ToString.Trim <> "" Then
                DrTemp = TxtFatherOccupation.AgHelpDataSet.Tables(0).Select("Occupation = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Father Occupation"))) & "")
                If DrTemp.Length > 0 Then
                    TxtFatherOccupation.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                End If
                DrTemp = Nothing
            End If

            If AgL.XNull(DtTemp.Rows(I)("Mother Occupation")).ToString.Trim <> "" Then
                DrTemp = TxtMotherOccupation.AgHelpDataSet.Tables(0).Select("Occupation = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Mother Occupation"))) & "")
                If DrTemp.Length > 0 Then
                    TxtMotherOccupation.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                End If
                DrTemp = Nothing
            End If

            ''===========< Finally >==============
            Topctrl1.FButtonClick(13)
            ''===========< ******* >==============
        Next
        If StrErrLog <> "" Then MsgBox(StrErrLog)

        FW.Close()

        mBlnImprtFromExcelFlag = False
    End Sub

    Private Sub BtnEnquiryMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEnquiryMode.Click
        Try
            TxtEnquiryMode.AgMasterHelp = True
            TxtEnquiryMode.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
