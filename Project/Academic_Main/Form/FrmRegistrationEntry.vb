Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmRegistrationEntry
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode
    Dim mIsCancelled As Boolean = False, mIsAdmitted As Boolean = False

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Fee As Byte = 1
    Private Const Col1Amount As Byte = 2
    Private Const Col1Discount As Byte = 3
    Private Const Col1NetAmount As Byte = 4

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2Class As Byte = 1
    Private Const Col2University As Byte = 2
    Private Const Col2EnrollmentNo As Byte = 3
    Private Const Col2YearOfPassing As Byte = 4
    Private Const Col2Subjects As Byte = 5
    Private Const Col2Result As Byte = 6
    Private Const Col2TotalPercentage As Byte = 7
    Private Const Col2FillSubjectMarks As Byte = 8
    Private Const Col2PCMPercentage As Byte = 9
    Private Const Col2Remark As Byte = 10
    Private Const Col2SubjectList As Byte = 11
    Private Const Col2MarksList As Byte = 12
    Private Const Col2PercentageList As Byte = 13

    Public WithEvents DGL3 As New AgControls.AgDataGrid
    Private Const Col3Status As Byte = 1
    Private Const Col3StatusDate As Byte = 2
    Private Const Col3ProgrammStream As Byte = 3
    
    Public WithEvents DGLFooter As New AgControls.AgDataGrid
    Private Const DFC_Description As Byte = 0
    Private Const DFC_Amount As Byte = 1
    Private Const DFR_TotalAmount As Byte = 0
    Private Const DFR_TotalDiscount As Byte = 1
    Private Const DFR_TotalNetAmount As Byte = 2

    'Private Const ColSelect As Byte = 0
    Private Const ColStreamName As Byte = 1
    Private Const ColStreamCode As Byte = 2
    Private Const ColTotalSeats As Byte = 3
    Private Const ColTotalAdmissions As Byte = 4
    Private Const ColAvailableSeats As Byte = 5


    Dim PaymentRec As AgLibrary.ClsMain.PaymentDetail = Nothing
    Dim mObjFrmPaymentDetail As AgLibrary.FrmPaymentDetail = Nothing
    Dim mMaxFeeAc$ = ""

    Dim mBlnIsUserCanApprove As Boolean = False, mBlnIsAutoApproved As Boolean = False
    Dim _FormType As eFormType

    Public Enum eFormType
        RegistrationEntry
        RegistrationEntryAuthenticated
    End Enum

    Public Property FormType() As eFormType
        Get
            FormType = _FormType
        End Get
        Set(ByVal value As eFormType)
            _FormType = value
        End Set
    End Property

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
            .AddAgTextColumn(DGL1, "DGL1SNo", 30, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "DGL1Fee", 180, 8, "Fee Head", True, False, False)
            .AddAgNumberColumn(DGL1, "DGL1Amount", 100, 8, 2, False, "Fee Amount", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1Discount", 80, 8, 2, False, "Discount", True, False, True)
            .AddAgNumberColumn(DGL1, "DGL1NetAmount", 100, 8, 2, False, "Net Amount", True, True, True)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)

        ''==============================================================================
        ''================< Academic Data Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "DGL2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "DGL2Class", 120, 50, "Class/Standard", True, False, False, True)
            .AddAgTextColumn(DGL2, "DGL2University", 150, 50, "Board/University", True, False, False)
            .AddAgTextColumn(DGL2, "DGL2EnrollmentNo", 100, 20, "Enrollment No", True, False, False)
            .AddAgNumberColumn(DGL2, "DGL2YearOfPassing", 60, 4, 0, False, "Year", True, False, True)
            .AddAgTextColumn(DGL2, "DGL2Subjects", 120, 255, "Subjects", True, False, False)
            .AddAgTextColumn(DGL2, "DGL2Result", 80, 20, "Result", True, False, False)
            .AddAgNumberColumn(DGL2, "DGL2TotalPercentage", 50, 2, 2, False, "Total %", True, False, True)
            .AddAgButtonColumn(DGL2, "DGL2FillSubSection", 60, "Merit Marks", True, False, , , , "Webdings", 10, "6")
            .AddAgNumberColumn(DGL2, "DGL2PCMPercentage", 50, 2, 2, False, "% For Merit", True, False, True)
            .AddAgTextColumn(DGL2, "DGL2Remark", 80, 255, "Merit Remark", True, False, False)
            .AddAgTextColumn(DGL2, "DGL2SubjectList", 150, 255, "Subject List", False, True, False)
            .AddAgTextColumn(DGL2, "DGL2MarksList", 150, 255, "Marks List", False, True, False)
            .AddAgTextColumn(DGL2, "DGL2PercentageList", 150, 255, "Percentage List", False, True, False)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 40

        With AgCL
            .AddAgTextColumn(DGL3, "DGL3SNo", 40, 5, "S.No.", True, True, False)
            '.AddAgListColumn(DGL3, PubRegistrationStatusStr, "Col3Status", 150, PubRegistrationStatusStr, "Status", True, False, )
            .AddAgTextColumn(DGL3, "PubRegistrationStatusStr", 150, 50, "Status", True, False, False)
            .AddAgDateColumn(DGL3, "Col3Statusdate", 100, "Status Date", True, False, False)
            .AddAgTextColumn(DGL3, "Col3ProgrammStream", 150, 50, "Programme (Stream)", True, False, False)
            
        End With
        AgL.AddAgDataGrid(DGL3, Pnl3)
        DGL3.ColumnHeadersHeight = 20


        ''==============================================================================
        ''================< Footer Data Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGLFooter, "DGLFDescription", 140, 5, "Description", True, True, False)
            .AddAgTextColumn(DGLFooter, "DGLFAmount", 100, 30, "Amount", True, True, True)
        End With
        AgL.AddAgDataGrid(DGLFooter, PnlFooter)
        DGLFooter.RowCount = 4
        DGLFooter.AllowUserToAddRows = False
        DGLFooter.Item(DFC_Description, DFR_TotalAmount).Value = "Amount".ToUpper
        DGLFooter.Item(DFC_Description, DFR_TotalDiscount).Value = "(-) Discount".ToUpper
        DGLFooter.Item(DFC_Description, DFR_TotalNetAmount).Value = "Net Amount".ToUpper

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

            If e.KeyCode <> Keys.Return And Me.ActiveControl.Name = TxtReceiveAmount.Name Then
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, mMaxFeeAc, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
                AgL.PubObjFrmPaymentDetail.ShowDialog()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec

                TxtReceiveAmount.Text = Format(Val(PaymentRec.TotalAmount), "0.00")

                If Val(TxtReceiveAmount.Text) <> Val(DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value) Then
                    MsgBox("Receive Amount Is Not Equal To Rs. """ & Val(DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value) & """")
                End If

                Call Calculation()
                AgL.PubObjFrmPaymentDetail = Nothing
            End If
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
            AgL.WinSetting(Me, 680, 950, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGL3)
            AgL.GridDesign(DGLFooter)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            Topctrl1.ChangeAgGridState(DGL3, False)
            Topctrl1.ChangeAgGridState(DGLFooter, False)
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

            If _FormType = eFormType.RegistrationEntry Then
                mCondStr += " And IsNull(R.ApprovedBy,'')='' "
            ElseIf _FormType = eFormType.RegistrationEntryAuthenticated Then
                mCondStr += " And IsNull(R.ApprovedBy,'')<>'' "
            End If

            mQry = "Select R.DocId As SearchCode " & _
                    " From Sch_Registration R " & _
                    " LEFT JOIN Voucher_Type Vt ON R.V_Type = Vt.V_Type " & _
                    " " & mCondStr & " "

            Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
        End If
    End Sub

    Sub Ini_List()
        Dim MDI As New MDIMain
        mBlnIsUserCanApprove = AgL.FunHaveControlPermission(FunGetModuleName, MDI.MnuAmRegistrationEntry.Text, AgL.PubUserName, GroupBox1.Text)

        mQry = "Select Code As Code, Name As Name From SiteMast " & _
              " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & "  Order By Name"
        TxtSite_Code.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select V_Type As Code, Description As Name, NCat From Voucher_Type " & _
              " Where NCat = " & AgL.Chk_Text(Academic_ProjLib.ClsMain.NCat_RegistrationEntry) & "" & _
              " Order By Description"
        TxtV_Type.AgHelpDataSet(1, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT S.SubCode AS Code, Sg.Name, S.FirstName, S.MiddleName, S.LastName, S.Sex, S.NationalityCode, " & _
                  " S.Occupation, S.MotherName, S.MotherNamePrefix, S.FamilyIncome, S.Religion, S.Category, S.IsInternationalStudent," & _
                  " S.PassportNo, S.VisaExpiryDate, S.VisaType, S.EnglishProficiency_IELTS, S.EnglishProficiency_TOEFL, " & _
                  " S.EnglishProficiency_Others, S.BloodGroup, Sg.FatherNamePrefix , Sg.FatherName, Sg.Add1 , Sg.Add2 , Sg.Add3 ," & _
                  " Sg.CityCode, Sg.PIN , Sg.Phone , Sg.Mobile , Sg.EMail, Sg.DOB, " & _
                  " S.FatherCompany, S.FatherCompanyAddress, S.FatherDesignation, S.MotherOccupation, S.MotherCompany, S.MotherCompanyAddress, " & _
                  " S.MotherDesignation, S.MotherIncome, S.MarkOfId, S.TAdd1, S.TAdd2, S.TAdd3, S.TCityCode, S.TPin, S.TPhone, S.TMobile, S.TFax,  S.LocalGuardian, " & _
                  " Sg.PAdd1, Sg.PAdd2, Sg.PAdd3, Sg.PCityCode, Sg.PPin, Sg.PPhone, Sg.PMobile, Sg.PFax, S.FatherIncome " & _
                  " From Sch_Student S " & _
                  " Left Join SubGroup Sg On Sg.SubCode = S.SubCode " & _
                  " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                  " Order By Sg.Name "
        TxtStudent.AgHelpDataSet(57, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)


        mQry = "SELECT DISTINCT s.RankRemark AS code , s.RankRemark AS Name " & _
                " FROM Sch_Registration s " & _
                " WHERE IsNull(s.RankRemark,'') <> '' "
        TxtRankRemark.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT DISTINCT s.RankRemark2 AS code , s.RankRemark2 AS Name " & _
                " FROM Sch_Registration s " & _
                " WHERE IsNull(s.RankRemark2,'') <> '' "
        TxtRankRemark2.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT C.CityCode Code, C.CityName AS City, S.ShortName AS State, C1.Name AS Country " & _
                " FROM City C " & _
                " LEFT JOIN State S ON C.State_Code = S.State_Code " & _
                " LEFT JOIN Country C1 ON S.CountryCode = C1.Code " & _
                " ORDER BY C1.Name, C.CityName "
        TxtCityCode.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)
        TxtPCityCode.AgHelpDataSet(0, Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)
        TxtTCityCode.AgHelpDataSet(0, Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT O.Code , O.Description Occupation " & _
                " FROM Sch_Occupation O " & _
                " ORDER BY O.Description "
        TxtOccupation.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)
        TxtMotherOccupation.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT DISTINCT V.Designation AS Code, V.Designation AS Name " & _
                " FROM (" & _
                " SELECT DISTINCT S.FatherDesignation AS Designation FROM Sch_RegistrationStudentDetail S WHERE IsNull(S.FatherDesignation,'') <> '' " & _
                " UNION ALL " & _
                " SELECT DISTINCT S.MotherDesignation AS Designation FROM Sch_RegistrationStudentDetail S WHERE IsNull(S.MotherDesignation,'') <> '' " & _
                " ) As V ORDER BY V.Designation "
        TxtFatherDesignation.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)
        TxtMotherDesignation.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        TxtCategory.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData("SELECT C.Code , C.ManualCode AS Name FROM Sch_Category C Order By C.ManualCode ", AgL.GCn)

        mQry = "SELECT N.NationalityCode AS Code, N.Nationaliy  FROM Nationality N ORDER BY N.Nationaliy "
        TxtNationalityCode.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT R.Code, R.Description AS Religion FROM Sch_Religion R ORDER BY R.Description "
        TxtReligion.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Vs.Code , VS.SessionProgramme Name " & _
                " FROM ViewSch_SessionProgramme VS " & _
                " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY VS.SessionProgramme "
        TxtSessionProgramme.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Vs.Code , VS.SessionProgrammeStream As Name, vS.TotalSeats As [Total Seats], IsNull(vP.TotalAdmissions,0) AS [Total Admissions], " & _
                " vS.TotalSeats - IsNull(vP.TotalAdmissions,0) AS AvailableSeats, VS.SessionProgramme " & _
                " FROM ViewSch_SessionProgrammeStream VS " & _
                " Left Join " & _
                " (SELECT Sem.SessionProgrammeStreamCode, Count(P.FromStreamYearSemester) AS TotalAdmissions " & _
                " FROM Sch_AdmissionPromotion P " & _
                " LEFT JOIN ViewSch_StreamYearSemester Sem ON Sem.Code = P.FromStreamYearSemester  " & _
                " WHERE P.PromotionDate Is NULL " & _
                " GROUP BY Sem.SessionProgrammeStreamCode " & _
                " ) vP ON vS.Code = vP.SessionProgrammeStreamCode " & _
                " Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & " " & _
                " ORDER BY VS.SessionProgrammeStream "
        TxtSessionProgrammeStream.AgHelpDataSet(1, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)


        mQry = "SELECT Vs.Code , VS.SessionProgrammeStream As Name, sVS.SeatsForRegistration As [Total Seats], " & _
               " IsNull(vP.Noofseat,0) AS [Total Allotment],  sVS.SeatsForRegistration - IsNull(vP.Noofseat,0) AS AvailableSeats,  " & _
               " VS.SessionProgramme  FROM  ViewSch_SessionProgrammeStream vs Left Join  Sch_SessionProgrammeStream sVS  ON vs.Code=svs.code " & _
               " LEFT JOIN   (SELECT SessionProgrammeStream AS SessionProgrammeStreamCode ,sum(Noofseat) AS Noofseat FROM  " & _
               " (SELECT docid,SessionProgrammeStream, max(statusdate) AS VDate  ,1 AS Noofseat FROM Sch_RegistrationStatus " & _
               " WHERE SessionProgrammeStream IS NOT NULL GROUP BY docid,SessionProgrammeStream ) AS v GROUP BY SessionProgrammeStream) " & _
               " vP ON vS.Code = vP.SessionProgrammeStreamCode  Where " & AgL.PubSiteCondition("Vs.Site_Code", AgL.PubSiteCode) & "      ORDER BY VS.SessionProgrammeStream "

        DGL3.AgHelpDataSet(Col3ProgrammStream, 1, Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)


        mQry = "SELECT CODE ,NAME FROM (select " & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_Registered) & " as code," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_Registered) & " as name " & _
                "Union All select " & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_SeatAllotedByManagement) & " as code," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_SeatAllotedByManagement) & " as name " & _
                "Union All select " & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_SeatAllotedBySeeUptu) & " as code," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_SeatAllotedBySeeUptu) & " as name " & _
                "Union All select " & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_AdmittedByManagement) & " as code," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_AdmittedByManagement) & " as name " & _
                "Union All select " & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_AdmittedBySeeUptu) & " as code," & AgL.Chk_Text(Academic_ProjLib.ClsMain.RegistrationStatus_AdmittedBySeeUptu) & " as name) " & _
                "  AS V  "

        DGL3.AgHelpDataSet(Col3Status, 0, Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)


        mQry = "SELECT N.Code , N.Description AS Name FROM Sch_AdmissionNature N ORDER BY N.Description "
        TxtAdmissionNature.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT R.DocId AS Code,R.ManualRegNo  FROM Sch_Registration R " & _
                " WHERE R.ManualRegNo IS NOT NULL "
        TxtManualRegNo.AgHelpDataSet(0, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        AgCL.IniAgHelpList(TxtBloodGroup, "A+,A-,B+,B-,AB+,AB-,O+,O-")
        AgCL.IniAgHelpList(TxtSex, "Male,Female")

        mQry = "SELECT F.Code, Sg.Name, F.FeeNature " & _
                " FROM Sch_Fee F " & _
                " LEFT JOIN SubGroup Sg ON Sg.SubCode = F.Code " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " And " & _
                " F.FeeNature  NOT IN ('" & Academic_ProjLib.ClsMain.FeeNature_LateFee & "', '" & Academic_ProjLib.ClsMain.FeeNature_Fine & "') " & _
                " ORDER BY F.FeeNature , Sg.Name "
        DGL1.AgHelpDataSet(Col1Fee, 1, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT U.Code , U.ManualCode [Board/University] FROM Sch_University U ORDER BY U.ManualCode "
        DGL2.AgHelpDataSet(Col2University, , Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)


        If AgL.IsTableExist("Enquiry_Enquiry", AgL.GCn) Then
            mQry = "SELECT H.DocId AS Code," & AgL.V_No_Field("H.DocId") & " As [Enquiry No], SG.DispName AS [Enquiry By], " & _
                    " isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS Name, " & _
                    " H.Status, H.EnquiryMode AS [Enquiry Mode],C.CityName AS City,isnull(H.IsClosed,0)  AS IsClosed, " & _
                    " H.V_Date As EnquiryDate, H.Employee As EmployeeCode, H.AssignedTo As AssignedToCode,  " & _
                    " R.DocId As RegistrationDocId, A.DocId As AdmissionDocId " & _
                    " FROM Enquiry_Enquiry H  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee " & _
                    " LEFT JOIN SubGroup E2 ON E2.SubCode=H.AssignedTo " & _
                    " LEFT JOIN City C ON C.CityCode=H.CityCode  " & _
                    " LEFT JOIN Sch_Registration R ON H.DocId = R.EnquiryDocId " & _
                    " LEFT JOIN Sch_Admission A ON H.DocId = A.EnquiryDocId " & _
                    " Where H.V_Date <= " & AgL.ConvertDate(AgL.PubEndDate) & " " & _
                    " Order By H.V_Date Desc, H.DocId "
            TxtEnquiryDocId.AgHelpDataSet(8, Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)
        End If
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

                    AgL.Dman_ExecuteNonQry("Delete From Sch_RegistrationPaymentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, mMaxFeeAc, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                    AgL.PubObjFrmPaymentDetail.DeletePaymentDetail(AgL.GCn, AgL.ECmd)
                    AgL.PubObjFrmPaymentDetail = Nothing

                    AgL.LedgerUnPost(AgL.GCn, AgL.ECmd, mSearchCode)

                    AgL.Dman_ExecuteNonQry("Delete From Sch_RegistrationFee Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_RegistrationStudentDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_RegistrationMeritMarks Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_RegistrationAcademicDetail Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)                    
                    AgL.Dman_ExecuteNonQry("Delete From Sch_RegistrationStream Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_RegistrationStatus Where DocId = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_Registration Where DocId='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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
        DispText(True)
        TxtV_Date.Focus()
    End Sub

    Private Sub Topctrl_tbFind() Handles Topctrl1.tbFind
        Dim mCondStr As String

        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub

        Try
            mCondStr = " Where 1=1 " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                            " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " "

            If _FormType = eFormType.RegistrationEntry Then
                mCondStr += " And IsNull(R.ApprovedBy,'')='' "
            ElseIf _FormType = eFormType.RegistrationEntryAuthenticated Then
                mCondStr += " And IsNull(R.ApprovedBy,'')<>'' "
            End If

            AgL.PubFindQry = "SELECT R.DocId As SearchCode, " & AgL.V_No_Field("R.DocId") & " As [Voucher No], Sd.FirstName  + space(1) + IsNULL(Sd.MiddleName , '')  + space(1) + Sd.LastName AS Student, " & _
                                " S.Name AS [Site Name], Vt.Description AS [Voucher Type], R.V_Date, R.TotalAmount, R.TotalDiscount, " & _
                                " R.TotalNetAmount, Vs.SessionProgrammeStream AS [Programme (Stream)], N.Description As AdmissionNature, R.Remark, Sd.Phone, Sd.Mobile  , Sd.EMail " & _
                                " FROM dbo.Sch_Registration R " & _
                                " LEFT JOIN Sch_RegistrationStudentDetail Sd ON R.DocId = Sd.DocId " & _
                                " LEFT JOIN ViewSch_SessionProgrammeStream Vs ON R.SessionProgrammeStream = Vs.Code " & _
                                " LEFT JOIN Sch_AdmissionNature N ON R.AdmissionNature = N.Code " & _
                                " LEFT JOIN Voucher_Type Vt ON R.V_Type = Vt.V_Type " & _
                                " LEFT JOIN SiteMast S ON R.Site_Code = S.Code " & mCondStr

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
        Dim bReceiptType As String = ""
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Try

            If MsgBox("Print Summary?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then
                bReceiptType = "Summary"
            Else
                bReceiptType = "Detail"
            End If
            Me.Cursor = Cursors.WaitCursor

            AgL.PubReportTitle = "Registration Receipt"
            RepName = "Academic_RegistrationReceipt" : RepTitle = AgL.PubReportTitle

            If mDocId = "" Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strQry = "SELECT FR.DocId, " & AgL.V_No_Field("FR.DocID") & " as DocID_Print,FR.Div_Code,FR.Site_Code,FR.V_Date,FR.V_Type,FR.V_Prefix,FR.V_No,FR.TotalAmount,FR.TotalDiscount,FR.TotalNetAmount,FR.Remark,FR.PreparedBy,FR.U_EntDt,FR.U_AE,FR.Edit_Date,FR.ModifiedBy,FR.RowId,FR.UpLoadDate, " & _
                    "FR1.Fee AS Line_Fee,FR1.Amount AS Line_Amount,FR1.Discount AS Line_Discount,FR1.NetAmount AS Line_NetAmount,F.Name AS Fee_Description,Sd.FirstName, Sd.MiddleName, Sd.LastName, Sd.Student AS StudentCode,Sd.FatherName , Sd.Add1, Sd.Add2, Sd.Add3, City.CityName, Sd.PIN, Sd.Mobile, Sd.Phone, Sd.EMail,sd.DOB, " & _
                    "PD.CashAc, PD.CashAmount, PD.BankAc, PD.BankAmount, PD.Bank_Code, PD.Chq_No, PD.Chq_Date, PD.Clg_Date, PD.CardAc, PD.CardAmount, PD.CardBank_Code, PD.Card_No, PD.AcTransferBankAc, PD.AcTransferAmount, PD.AcTransferBank_Code, PD.TotalAmount, PD.AcTransferAcNo, PD.PartyDrCr, (CASE WHEN PD.CashAmount>0 THEN 'Cash' WHEN PD.BankAmount>0 THEN 'Cheque / DD' WHEN PD.CardAmount>0 THEN 'Credit / Debit Card' WHEN PD.AcTransferAmount>0 THEN 'A/c Transfer' END) AS PaymentMode, " & _
                    "PD.CashAmount+PD.BankAmount+PD.BankAmount2+PD.BankAmount3+PD.CardAmount+PD.AcTransferAmount AS PaymentAmount,PD.BankAc2, PD.BankAmount2, PD.Bank_Code2, PD.Chq_No2, PD.Chq_Date2, PD.Clg_Date2,PD.BankAc3, PD.BankAmount3, PD.Bank_Code3, PD.Chq_No3, PD.Chq_Date3, PD.Clg_Date3,b1.bank_name as Bank1,b2.bank_name as Bank2,b3.bank_name as Bank3,  " & _
                    "S.Photo As SitePhoto,SGT.Name As TransferAc,BT.Bank_Name AS TransferBankName," & AgL.Chk_Text(bReceiptType) & " AS ReceiptType " & _
                    "FROM (Select * From dbo.Sch_Registration Where DocId = '" & mDocId & "' ) FR " & _
                    "LEFT JOIN Sch_RegistrationStudentDetail  Sd WITH (NoLock) ON Sd.DocId = Fr.DocId " & _
                    "LEFT Join dbo.Sch_RegistrationFee FR1 ON FR.DocId =FR1.DocId " & _
                    "Left Join SiteMast S On FR.Site_Code =  S.Code " & _
                    "LEFT JOIN City ON Sd.CityCode = City.CityCode  " & _
                    "LEFT JOIN ViewSch_Fee F ON FR1.Fee =F.Code  " & _
                    "LEFT JOIN dbo.PaymentDetail PD ON Fr.DocId =PD.DocId  " & _
                    "Left Join Bank b1 on pd.bank_code=b1.bank_code  " & _
                    "Left Join Bank b2 on pd.bank_code2=b2.bank_code  " & _
                    "Left Join Bank b3 on pd.bank_code3=b3.bank_code  " & _
                    "LEFT JOIN SubGroup SGT ON SGT.SubCode=PD.AcTransferBankAc " & _
                    " LEFT JOIN bank BT ON BT.Bank_Code=PD.AcTransferBank_Code "




            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)


            AgPL.CreateFieldDefFile1(DsRep, PLib.PubReportPath_Academic_Main & "\" & RepName & ".ttx", True)

            ''''''''''IF CUSTOMER NEED SOME CHANGE IN FORMAT OF A REPORT'''''''''''
            ''''''''''CUTOMIZE REPORT CAN BE CREATED WITHOUT CHANGE IN CODE''''''''
            ''''''''''WITH ADDING 6 CHAR OF COMPANY NAME AND 4 CHAR OF CITY NAME'''
            ''''''''''WITHOUT SPACES IN EXISTING REPORT NAME''''''''''''''''''''''''''''''''''''''
            RepName = AgPL.GetRepNameCustomize(RepName, PLib.PubReportPath_Academic_Main)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''

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
        Dim I As Integer, mSr As Integer, bIntJ As Integer = 0, bIntSrMarks As Integer = 0
        Dim mTrans As Boolean = False
        Dim bStrApprovedDate$ = ""
        Dim bStrArrSubject() As String = Nothing, bStrArrMarks() As String = Nothing, bStrArrPercentage() As String = Nothing


        mSr = 0
        Try
            If AgL.PubMoveRecApplicable Then MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub

            If mBlnIsUserCanApprove Then bStrApprovedDate = AgL.GetDateTime(AgL.GCn)

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            mTrans = True
            If Topctrl1.Mode = "Add" Then



                mQry = "INSERT INTO Sch_Registration ( DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, TotalAmount, " & _
                        " TotalDiscount, TotalNetAmount, SessionProgramme, SessionProgrammeStream, AdmissionNature, Remark,Rank_No,RankRemark,RollNo,Rank_No2,RankRemark2,RollNo2,ManualRegNo, " & _
                        " PreparedBy, U_EntDt, U_AE,RankMarks1,RankMarks2,RankMaxMarks1,RankMaxMarks2, EnquiryDocId) " & _
                        " VALUES  ( " & _
                        " '" & mSearchCode & "', '" & AgL.PubDivCode & "', " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                        " " & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & "," & _
                        " " & Val(TxtV_No.Text) & ", " & Val(DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value) & ", " & Val(DGLFooter.Item(DFC_Amount, DFR_TotalDiscount).Value) & "," & _
                        " " & Val(DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value) & ", " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & ", " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtAdmissionNature.AgSelectedValue) & ", " & AgL.Chk_Text(TxtRemark.Text) & ", " & Val(TxtRank.Text) & "," & AgL.Chk_Text(TxtRankRemark.Text) & "," & AgL.Chk_Text(TxtRollNo.Text) & ", " & Val(TxtRank2.Text) & "," & AgL.Chk_Text(TxtRankRemark2.Text) & "," & AgL.Chk_Text(TxtRollNo2.Text) & "," & AgL.Chk_Text(TxtManualRegNo.Text) & "," & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', 'A', " & Val(TxtRank1Marks.Text) & " , " & Val(TxtRank2Marks.Text) & " , " & Val(txtRankMaxMarks1.Text) & " , " & Val(txtRankMaxMarks2.Text) & ", " & AgL.Chk_Text(TxtEnquiryDocId.AgSelectedValue) & " )"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "INSERT INTO Sch_RegistrationStudentDetail (DocId, FirstName, MiddleName, LastName) " & _
                                       " VALUES ( " & _
                                       " '" & mSearchCode & "', " & AgL.Chk_Text(TxtFirstName.Text) & ", " & AgL.Chk_Text(TxtMiddleName.Text) & ", " & _
                                       " " & AgL.Chk_Text(TxtLastName.Text) & ")"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            Else

                mQry = "UPDATE Sch_Registration SET " & _
                        " V_Date = " & AgL.ConvertDate(TxtV_Date.Text) & ", TotalAmount = " & Val(DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value) & ", " & _
                        " TotalDiscount = " & Val(DGLFooter.Item(DFC_Amount, DFR_TotalDiscount).Value) & ", TotalNetAmount = " & Val(DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value) & ", " & _
                        " SessionProgrammeStream = " & AgL.Chk_Text(TxtSessionProgrammeStream.AgSelectedValue) & ", AdmissionNature = " & AgL.Chk_Text(TxtAdmissionNature.AgSelectedValue) & ", " & _
                        " SessionProgramme = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & ", Remark = " & AgL.Chk_Text(TxtRemark.Text) & " , " & _
                        " Rank_No=" & Val(TxtRank.Text) & ",RankRemark=" & AgL.Chk_Text(TxtRankRemark.Text) & ",RollNo=" & AgL.Chk_Text(TxtRollNo.Text) & ",ManualRegNo=" & AgL.Chk_Text(TxtManualRegNo.Text) & ", " & _
                        " Rank_No2=" & Val(TxtRank2.Text) & ",RankRemark2=" & AgL.Chk_Text(TxtRankRemark2.Text) & ",RollNo2=" & AgL.Chk_Text(TxtRollNo2.Text) & ", " & _
                        " EnquiryDocId = " & AgL.Chk_Text(TxtEnquiryDocId.AgSelectedValue) & "," & _
                        " U_AE = 'E', Edit_Date = '" & Format(AgL.PubLoginDate, AgLibrary.ClsConstant.DateFormat_ShortDate) & "', ModifiedBy = '" & AgL.PubUserName & "',RankMarks1=" & Val(TxtRank1Marks.Text) & " , RankMarks2=" & Val(TxtRank2Marks.Text) & ", RankMaxMarks1=" & Val(txtRankMaxMarks1.Text) & " ,RankMaxMarks2= " & Val(txtRankMaxMarks2.Text) & " " & _
                        " Where DocId = '" & mSearchCode & "'"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            mQry = "Update Sch_RegistrationStudentDetail Set " & _
                    " IsNewStudent = " & IIf(AgL.StrCmp(TxtIsNewStudent.Text, "Yes"), 1, 0) & ", Student = " & AgL.Chk_Text(TxtStudent.AgSelectedValue) & ", FirstName = " & AgL.Chk_Text(TxtFirstName.Text) & "," & _
                    " MiddleName = " & AgL.Chk_Text(TxtMiddleName.Text) & ", LastName = " & AgL.Chk_Text(TxtLastName.Text) & ", Add1 = " & AgL.Chk_Text(TxtAdd1.Text) & "," & _
                    " Add2 = " & AgL.Chk_Text(TxtAdd2.Text) & ", CityCode = " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & ", Pin = " & AgL.Chk_Text(TxtPin.Text) & "," & _
                    " Phone = " & AgL.Chk_Text(TxtPhone.Text) & ", Mobile = " & AgL.Chk_Text(TxtMobile.Text) & ", EMail = " & AgL.Chk_Text(TxtEMail.Text) & ", " & _
                    " Sex = " & AgL.Chk_Text(TxtSex.Text) & ", NationalityCode = " & AgL.Chk_Text(TxtNationalityCode.AgSelectedValue) & ", Occupation = " & AgL.Chk_Text(TxtOccupation.AgSelectedValue) & ", " & _
                    " DOB = " & AgL.ConvertDate(TxtDOB.Text) & ", FatherName = " & AgL.Chk_Text(TxtFatherName.Text) & ", FatherNamePrefix = " & AgL.Chk_Text(TxtFatherNamePrefix.Text) & ", " & _
                    " MotherName = " & AgL.Chk_Text(TxtMotherName.Text) & ", MotherNamePrefix = " & AgL.Chk_Text(TxtMotherNamePrefix.Text) & ", FamilyIncome = " & Val(TxtFamilyIncome.Text) & ", Religion = " & AgL.Chk_Text(TxtReligion.AgSelectedValue) & ", " & _
                    " Category = " & AgL.Chk_Text(TxtCategory.AgSelectedValue) & ", IsInternationalStudent = " & IIf(AgL.StrCmp(TxtIsInternationalStudent.Text, "Yes"), 1, 0) & ", PassportNo = " & AgL.Chk_Text(TxtPassportNo.Text) & ", " & _
                    " VisaExpiryDate = " & AgL.ConvertDate(TxtVisaExpiryDate.Text) & ", VisaType = " & AgL.Chk_Text(TxtVisaType.Text) & ", " & _
                    " EnglishProficiency_IELTS = " & IIf(OptEnglishProficiency_IELTS.Checked, 1, 0) & ", EnglishProficiency_TOEFL = " & IIf(OptEnglishProficiency_TOEFL.Checked, 1, 0) & ", " & _
                    " Englishproficiency_Others = " & AgL.Chk_Text(TxtEnglishProficiency_Others.Text) & ", BloodGroup = " & AgL.Chk_Text(TxtBloodGroup.Text) & ", " & _
                    " FatherCompany = " & AgL.Chk_Text(TxtFatherCompany.Text) & ", FatherCompanyAddress = " & AgL.Chk_Text(TxtFatherCompanyAddress.Text) & ", FatherDesignation = " & AgL.Chk_Text(TxtFatherDesignation.Text) & ", MotherOccupation = " & AgL.Chk_Text(TxtMotherOccupation.AgSelectedValue) & ", " & _
                    " MotherCompany = " & AgL.Chk_Text(TxtMotherCompany.Text) & ", MotherCompanyAddress = " & AgL.Chk_Text(TxtMotherCompanyAddress.Text) & ", MotherDesignation = " & AgL.Chk_Text(TxtMotherDesignation.Text) & ", MotherIncome = " & Val(TxtMotherIncome.Text) & ", " & _
                    " TAdd1 = " & AgL.Chk_Text(TxtTAdd1.Text) & ", TAdd2 = " & AgL.Chk_Text(TxtTAdd2.Text) & ", TCityCode = " & AgL.Chk_Text(TxtTCityCode.AgSelectedValue) & ", TPin = " & AgL.Chk_Text(TxtTPin.Text) & ", TPhone = " & AgL.Chk_Text(TxtTPhone.Text) & ", TMobile = " & AgL.Chk_Text(TxtTMobile.Text) & ", " & _
                    " PAdd1 = " & AgL.Chk_Text(TxtPAdd1.Text) & ", PAdd2 = " & AgL.Chk_Text(TxtPAdd2.Text) & ", PCityCode = " & AgL.Chk_Text(TxtPCityCode.AgSelectedValue) & ", PPin = " & AgL.Chk_Text(TxtPPin.Text) & ", PPhone = " & AgL.Chk_Text(TxtPPhone.Text) & ", PMobile = " & AgL.Chk_Text(TxtPMobile.Text) & ", " & _
                    " LocalGuardian = " & AgL.Chk_Text(TxtLocalGuardian.Text) & ", FatherIncome = " & Val(TxtFatherIncome.Text) & ", ScholarshipApplied = " & IIf(AgL.StrCmp(TxtScholarshipApplied.Text, "Yes"), 1, 0) & " " & _
                    " Where DocId = '" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)



            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Sch_RegistrationFee Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If


            With DGL1
                mSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Fee, I).Value <> "" Then
                        mSr = mSr + 1

                        mQry = "INSERT INTO Sch_RegistrationFee ( DocId, Sr, Fee, Amount, Discount, NetAmount ) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & mSr & ", " & AgL.Chk_Text(.AgSelectedValue(Col1Fee, I)) & ", " & _
                                " " & Val(.Item(Col1Amount, I).Value) & ", " & Val(.Item(Col1Discount, I).Value) & "," & _
                                " " & Val(.Item(Col1NetAmount, I).Value) & ") "

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With



            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Sch_RegistrationStatus Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If



            With DGL3
                mSr = 0
                For I = 0 To .Rows.Count - 1
                    If .Item(Col3Status, I).Value <> "" Then
                        mSr = mSr + 1

                        mQry = " INSERT INTO dbo.Sch_RegistrationStatus " & _
                            " (DocId,Sr,Status,StatusDate,SessionProgrammeStream)" & _
                            " VALUES ('" & mSearchCode & "', " & mSr & "," & AgL.Chk_Text(.Item(Col3Status, I).Value) & "," & AgL.ConvertDate(.Item(Col3StatusDate, I).Value.ToString) & "," & AgL.Chk_Text(.AgSelectedValue(Col3ProgrammStream, I)) & ") "

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With




            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Sch_RegistrationMeritMarks Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "Delete From Sch_RegistrationAcademicDetail Where DocId = '" & mSearchCode & "'"
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

                        mQry = "INSERT INTO Sch_RegistrationAcademicDetail ( DocId, Sr, Class, University, EnrollmentNo, YearOfPassing, Subjects, Result, TotalPercentage, PCMPercentage, Remark) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & mSr & ", " & AgL.Chk_Text(.Item(Col2Class, I).Value) & ", " & AgL.Chk_Text(.AgSelectedValue(Col2University, I)) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col2EnrollmentNo, I).Value) & ", " & Val(.Item(Col2YearOfPassing, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col2Subjects, I).Value) & ", " & AgL.Chk_Text(.Item(Col2Result, I).Value) & ", " & _
                                " " & Val(.Item(Col2TotalPercentage, I).Value) & ", " & Val(.Item(Col2PCMPercentage, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col2Remark, I).Value) & ")"
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

                                mQry = "INSERT INTO dbo.Sch_RegistrationMeritMarks (DocId, ClassSr, Sr, Subject, Marks, Percentage) " & _
                                        " VALUES ('" & mSearchCode & "', " & mSr & ", " & bIntSrMarks & ", " & AgL.Chk_Text(bStrArrSubject(bIntJ)) & ", " & _
                                        " " & Val(bStrArrMarks(bIntJ)) & ", " & Val(bStrArrPercentage(bIntJ)) & ") "
                                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            Next
                        End If
                    End If
                Next I
            End With

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Sch_RegistrationStream Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            With DglStream
                For I = 0 To .Rows.Count - 1
                    If .Item(Col_SNo, I).Value Is Nothing Then .Item(Col_SNo, I).Value = ""
                    If .Item(ColStreamName, I).Value Is Nothing Then .Item(ColStreamName, I).Value = ""
                    If .Item(ColStreamCode, I).Value Is Nothing Then .Item(ColStreamCode, I).Value = ""

                    If Val(.Item(Col_SNo, I).Value) > 0 And .Item(ColStreamName, I).Value.ToString.Trim <> "" Then
                        mQry = "INSERT INTO Sch_RegistrationStream ( DocId, Sr, SessionProgrammeStream) " & _
                                " VALUES ( " & _
                                " " & AgL.Chk_Text(mSearchCode) & ", " & Val(.Item(Col_SNo, I).Value) & ", " & AgL.Chk_Text(.Item(ColStreamCode, I).Value) & ")"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next I
            End With

            If Topctrl1.Mode = "Edit" Then
                mQry = "Update Sch_RegistrationPaymentDetail Set PaymentDocId = Null Where DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, mMaxFeeAc, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
            AgL.PubObjFrmPaymentDetail.PubPaymentRec = PaymentRec
            If Not AgL.PubObjFrmPaymentDetail.SavePaymentDetail(PaymentRec, AgL.GCn, AgL.ECmd) Then Err.Raise(1, , "Save Error")
            mObjFrmPaymentDetail = AgL.PubObjFrmPaymentDetail
            AgL.PubObjFrmPaymentDetail = Nothing

            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO Sch_RegistrationPaymentDetail ( DocId, PaymentDocId, LedgerMDocId) VALUES ( " & _
                        " '" & mSearchCode & "', '" & mSearchCode & "',Null )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Sch_RegistrationPaymentDetail Set PaymentDocId = '" & mSearchCode & "' Where DocId = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If mBlnIsUserCanApprove Then Call ProcApproveVoucher(AgL.PubUserName, bStrApprovedDate, mBlnIsUserCanApprove)

            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False


            Try
                If AgLibrary.ClsConstant.IsSmsActive Then
                    Dim bStrSMS$ = "", bStrMobileNo$ = "", bStrCategory$ = ""
                    Dim bDtSmsEvent As DataTable = Nothing

                    mQry = "SELECT E.* FROM Sms_Event E  WITH (NoLock) WHERE E.Event = '" & ClsMain.SmsEvent.StudentRegistration & "'"
                    bDtSmsEvent = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

                    If bDtSmsEvent.Rows.Count > 0 Then
                        bStrSMS = AgL.XNull(bDtSmsEvent.Rows(0)("Message")).ToString
                        bStrCategory = AgL.XNull(bDtSmsEvent.Rows(0)("Category")).ToString
                    End If
                    If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()

                    If TxtMobile.Text.Trim <> "" Then
                        If TxtMobile.Text.Trim.Length >= 10 Then
                            bStrMobileNo = AgL.MidStr(TxtMobile.Text, 0, 10)
                        End If
                    End If

                    If bStrSMS.Trim <> "" And bStrMobileNo.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, TxtV_Date.Text, bStrCategory, AgL.XNull(TxtStudent.AgSelectedValue).ToString, bStrMobileNo, TxtV_Date.Text, bStrSMS)
                        Call AgL.SendSms(AgL)
                    End If
                End If
            Catch ex As Exception

            End Try

            If AgL.PubMoveRecApplicable Then
                FIniMaster(0, 1)
                Topctrl_tbRef()
            End If

            Dim mDocId As String = mSearchCode

            If Topctrl1.Mode = "Add" Then
                Topctrl1.LblDocId.Text = mSearchCode

                mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

                Topctrl1.FButtonClick(0)

                If MsgBox("Want To Print Receipt?...", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
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
                        " From ViewSch_Registration R " & _
                        " Left Join Voucher_Type Vt On R.V_Type = Vt.V_Type " & _
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
                        TxtSessionProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgramme"))
                        TxtSessionProgrammeStream.AgSelectedValue = AgL.XNull(.Rows(0)("SessionProgrammeStream"))
                        TxtAdmissionNature.AgSelectedValue = AgL.XNull(.Rows(0)("AdmissionNature"))
                        TxtRemark.Text = AgL.XNull(.Rows(0)("Remark"))

                        DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value = Format(AgL.VNull(.Rows(0)("TotalAmount")), "0.00")
                        DGLFooter.Item(DFC_Amount, DFR_TotalDiscount).Value = Format(AgL.VNull(.Rows(0)("TotalDiscount")), "0.00")
                        DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value = Format(AgL.VNull(.Rows(0)("TotalNetAmount")), "0.00")
                        TxtReceiveAmount.Text = Format(AgL.VNull(.Rows(0)("TotalNetAmount")), "0.00")

                        mIsCancelled = AgL.VNull(.Rows(0)("IsCancelled"))
                        mIsAdmitted = AgL.VNull(.Rows(0)("IsAdmited"))

                        TxtEnquiryDocId.AgSelectedValue = AgL.XNull(.Rows(0)("EnquiryDocId"))
                        LblEnquiryDocId.Tag = AgL.XNull(.Rows(0)("EnquiryDocId"))

                        TxtRank.Text = AgL.VNull(.Rows(0)("Rank_No"))
                        TxtRankRemark.Text = AgL.XNull(.Rows(0)("RankRemark"))
                        TxtRollNo.Text = AgL.XNull(.Rows(0)("RollNo"))

                        TxtRank2.Text = AgL.VNull(.Rows(0)("Rank_No2"))
                        TxtRankRemark2.Text = AgL.XNull(.Rows(0)("RankRemark2"))
                        TxtRollNo2.Text = AgL.XNull(.Rows(0)("RollNo2"))
                        TxtRank1Marks.Text = AgL.VNull(.Rows(0)("RankMarks1"))
                        TxtRank2Marks.Text = AgL.VNull(.Rows(0)("RankMarks2"))



                        txtRankMaxMarks1.Text = AgL.VNull(.Rows(0)("RankMaxMarks1"))
                        txtRankMaxMarks2.Text = AgL.VNull(.Rows(0)("RankMaxMarks2"))


                        TxtManualRegNo.Text = AgL.XNull(.Rows(0)("ManualRegNo"))

                        mBlnIsAutoApproved = AgL.VNull(.Rows(0)("IsAutoApproved"))

                        TxtApproved.Text = AgL.XNull(.Rows(0)("ApprovedBy"))
                        TxtPrepared.Text = AgL.XNull(.Rows(0)("PreparedBy"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)

                    End If
                End With


                mQry = "Select Sd.* " & _
                        " From Sch_RegistrationStudentDetail Sd " & _
                        " Where Sd.DocId = '" & mSearchCode & "' "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    TxtIsNewStudent.Text = IIf(AgL.VNull(.Rows(0)("IsNewStudent")), "Yes", "No")
                    TxtStudent.AgSelectedValue = AgL.XNull(.Rows(0)("Student"))
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
                    TxtNationalityCode.AgSelectedValue = AgL.XNull(.Rows(0)("NationalityCode"))
                    TxtReligion.AgSelectedValue = AgL.XNull(.Rows(0)("Religion"))
                    TxtCategory.AgSelectedValue = AgL.XNull(.Rows(0)("Category"))
                    TxtIsInternationalStudent.Text = IIf(AgL.VNull(.Rows(0)("IsInternationalStudent")), "Yes", "No")
                    TxtScholarshipApplied.Text = IIf(AgL.VNull(.Rows(0)("ScholarshipApplied")), "Yes", "No")
                    TxtPassportNo.Text = AgL.XNull(.Rows(0)("PassportNo"))
                    TxtVisaExpiryDate.Text = Format(AgL.XNull(.Rows(0)("VisaExpiryDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                    TxtVisaType.Text = AgL.XNull(.Rows(0)("VisaType"))
                    OptEnglishProficiency_IELTS.Checked = AgL.VNull(.Rows(0)("EnglishProficiency_IELTS"))
                    OptEnglishProficiency_TOEFL.Checked = AgL.VNull(.Rows(0)("EnglishProficiency_TOEFL"))
                    OptEnglishProficiency_Others.Checked = IIf(AgL.XNull(.Rows(0)("EnglishProficiency_Others")).ToString.Trim = "", False, True)
                    TxtEnglishProficiency_Others.Text = AgL.XNull(.Rows(0)("EnglishProficiency_Others"))
                    TxtBloodGroup.Text = AgL.XNull(.Rows(0)("BloodGroup"))


                    TxtPAdd1.Text = AgL.XNull(.Rows(0)("pAdd1"))
                    TxtPAdd2.Text = AgL.XNull(.Rows(0)("pAdd2"))
                    TxtPCityCode.AgSelectedValue = AgL.XNull(.Rows(0)("PCityCode"))
                    TxtPPin.Text = AgL.VNull(.Rows(0)("pPin"))
                    TxtPPhone.Text = AgL.XNull(.Rows(0)("pPhone"))
                    TxtPMobile.Text = AgL.XNull(.Rows(0)("pMobile"))

                    TxtLocalGuardian.Text = AgL.XNull(.Rows(0)("LocalGuardian"))
                    TxtTAdd1.Text = AgL.XNull(.Rows(0)("TAdd1"))
                    TxtTAdd2.Text = AgL.XNull(.Rows(0)("TAdd2"))
                    TxtTCityCode.AgSelectedValue = AgL.XNull(.Rows(0)("TCityCode"))
                    TxtTPhone.Text = AgL.XNull(.Rows(0)("TPhone"))
                    TxtTPin.Text = AgL.VNull(.Rows(0)("TPin"))
                    TxtTMobile.Text = AgL.XNull(.Rows(0)("TMobile"))

                    TxtFatherName.Text = AgL.XNull(.Rows(0)("FatherName"))
                    TxtFatherNamePrefix.Text = AgL.XNull(.Rows(0)("FatherNamePrefix"))
                    TxtMotherName.Text = AgL.XNull(.Rows(0)("MotherName"))
                    TxtMotherNamePrefix.Text = AgL.XNull(.Rows(0)("MotherNamePrefix"))
                    TxtDOB.Text = Format(AgL.XNull(.Rows(0)("DOB")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                    TxtOccupation.AgSelectedValue = AgL.XNull(.Rows(0)("Occupation"))
                    TxtMotherOccupation.AgSelectedValue = AgL.XNull(.Rows(0)("MotherOccupation"))
                    TxtFatherCompany.Text = AgL.XNull(.Rows(0)("FatherCompany"))
                    TxtFatherCompanyAddress.Text = AgL.XNull(.Rows(0)("FatherCompanyAddress"))
                    TxtFatherDesignation.Text = AgL.XNull(.Rows(0)("FatherDesignation"))
                    TxtMotherCompany.Text = AgL.XNull(.Rows(0)("MotherCompany"))
                    TxtMotherCompanyAddress.Text = AgL.XNull(.Rows(0)("MotherCompanyAddress"))
                    TxtMotherDesignation.Text = AgL.XNull(.Rows(0)("MotherDesignation"))

                    TxtFatherIncome.Text = Format(AgL.VNull(.Rows(0)("FatherIncome")), "0.00")
                    TxtMotherIncome.Text = Format(AgL.VNull(.Rows(0)("MotherIncome")), "0.00")
                    TxtFamilyIncome.Text = Format(AgL.VNull(.Rows(0)("FamilyIncome")), "0.00")

                End With

                mQry = "Select Rf.* " & _
                        " From Sch_RegistrationFee Rf " & _
                        " Where Rf.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)

                With DsTemp.Tables(0)
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.AgSelectedValue(Col1Fee, I) = AgL.XNull(.Rows(I)("Fee"))
                            DGL1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            DGL1.Item(Col1Discount, I).Value = Format(AgL.VNull(.Rows(I)("Discount")), "0.00")
                            DGL1.Item(Col1NetAmount, I).Value = Format(AgL.VNull(.Rows(I)("NetAmount")), "0.00")

                            If bNetAmount < AgL.VNull(.Rows(I)("NetAmount")) Then
                                mMaxFeeAc = AgL.XNull(.Rows(I)("Fee"))
                            End If

                        Next I
                    End If
                End With

                mQry = "Select Ad.* " & _
                        " From Sch_RegistrationAcademicDetail Ad " & _
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
                            DGL2.Item(Col2PCMPercentage, I).Value = Format(AgL.VNull(.Rows(I)("PCMPercentage")), "0.00")
                            DGL2.Item(Col2Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))

                            mQry = "SELECT M.* " & _
                                    " FROM Sch_RegistrationMeritMarks M " & _
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

                mQry = "Select Ad.* " & _
                      " From Sch_RegistrationStatus Ad " & _
                      " Where Ad.DocId = '" & mSearchCode & "' " & _
                      " Order By Ad.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        DGL3.RowCount = 1 : DGL3.Rows.Clear()
                        For I = 0 To .Rows.Count - 1
                            DGL3.Rows.Add()
                            DGL3.Item(Col_SNo, I).Value = DGL3.Rows.Count - 1
                            DGL3.Item(Col3Status, I).Value = AgL.XNull(.Rows(I)("Status"))
                            DGL3.AgSelectedValue(Col3ProgrammStream, I) = AgL.XNull(.Rows(I)("SessionProgrammeStream"))
                            DGL3.Item(Col3StatusDate, I).Value = AgL.XNull(.Rows(I)("StatusDate"))
                        Next
                    End If
                End With


                DglStream.Tag = AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue)
                mQry = "SELECT  Rs.Sr AS [Order], VS.SessionProgrammeStream Stream, Vs.Code " & _
                        " FROM Sch_RegistrationStream Rs " & _
                        " Left Join ViewSch_SessionProgrammeStream VS On Rs.SessionProgrammeStream = Vs.Code " & _
                        " Where Rs.DocId = '" & mSearchCode & "' " & _
                        " UNION ALL " & _
                        " SELECT 0 AS [Order], VS.SessionProgrammeStream Stream, Vs.Code " & _
                        " FROM ViewSch_SessionProgrammeStream Vs " & _
                        " LEFT JOIN Sch_RegistrationStream Rs ON Rs.SessionProgrammeStream = Vs.Code And Rs.DocId = '" & mSearchCode & "' " & _
                        " Where Vs.SessionProgramme = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " And " & _
                        " Rs.SessionProgrammeStream IS NULL "
                DTbl = CType(AgL.FillData(mQry, AgL.GCn), DataSet).Tables(0)
                DglStream.DataSource = DTbl

                Call IniStreamGrid()

                If DTbl.Rows.Count = 0 Then
                    BtnStream.Tag = 0
                Else
                    If TxtSessionProgrammeStream.Text.Trim = "" Then BtnStream.Tag = 1
                End If

                ''Payment Detail Moverec Common
                AgL.PubObjFrmPaymentDetail = New AgLibrary.FrmPaymentDetail(AgL, Topctrl1.Mode, mSearchCode, CDate(TxtV_Date.Text), TxtSite_Code.AgSelectedValue, mMaxFeeAc, "Cr", AgLibrary.FrmPaymentDetail.TransactionType.Received)
                AgL.PubObjFrmPaymentDetail.FillPaymentRec()
                PaymentRec = AgL.PubObjFrmPaymentDetail.PubPaymentRec
                mObjFrmPaymentDetail = AgL.PubObjFrmPaymentDetail
                AgL.PubObjFrmPaymentDetail = Nothing
            Else
                BlankText()
            End If
            If AgL.PubMoveRecApplicable Then Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If mIsCancelled Then mTransFlag = True

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

            Call DispUpText()
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : LblPrefix.Text = "" : mMaxFeeAc = "" : mIsCancelled = False : mBlnIsAutoApproved = False : mIsAdmitted = False
        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
        DGL3.RowCount = 1 : DGL3.Rows.Clear()

        Call BlankFooterGrid()
        PaymentRec = Nothing : mObjFrmPaymentDetail = Nothing

        TxtScholarshipApplied.Text = "No" : TxtIsNewStudent.Text = "Yes"

        DglStream.DataSource = Nothing : DglStream.Visible = False : BtnStream.Tag = 0
        Tc1.SelectedTab = Tp1
        If mTmV_Type.Trim <> "" Then
            TxtV_Type.AgSelectedValue = mTmV_Type
            LblPrefix.Text = mTmV_Prefix : LblV_Type.Tag = mTmV_NCat
            TxtV_Date.Text = mTmV_Date
        End If
    End Sub

    Private Sub BlankFooterGrid()
        DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value = ""
        DGLFooter.Item(DFC_Amount, DFR_TotalDiscount).Value = ""
        DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value = ""
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        TxtEnquiryDocId.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Enquiry
        LblEnquiryDocId.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Enquiry

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False

            Call ProcManageStudentDetailControls(Not AgL.StrCmp(TxtIsNewStudent.Text, "Yes"))
        End If

        Call DispUpText(Enb)        
    End Sub

    Private Sub DispUpText(Optional ByVal Enb As Boolean = False)
        If _FormType = eFormType.RegistrationEntryAuthenticated Then
            GroupBox1.Visible = True : BtnApproved.Enabled = False
            Topctrl1.tAdd = False

            If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
                If Not mBlnIsUserCanApprove Then
                    DGL1.ReadOnly = Enb : TxtReceiveAmount.Enabled = False
                End If
            End If
        ElseIf _FormType = eFormType.RegistrationEntry Then
            GroupBox1.Visible = True
        End If
    End Sub

    Private Sub ProcManageStudentDetailControls(ByVal mReadOnlyBln As Boolean)
        TxtFirstName.ReadOnly = mReadOnlyBln
        TxtMiddleName.ReadOnly = mReadOnlyBln
        TxtLastName.ReadOnly = mReadOnlyBln
        TxtSex.ReadOnly = mReadOnlyBln
        TxtFatherNamePrefix.ReadOnly = mReadOnlyBln
        TxtFatherName.ReadOnly = mReadOnlyBln
        TxtMotherName.ReadOnly = mReadOnlyBln
        TxtMotherNamePrefix.ReadOnly = mReadOnlyBln
        TxtFamilyIncome.ReadOnly = mReadOnlyBln
        TxtPassportNo.ReadOnly = mReadOnlyBln
        TxtVisaExpiryDate.ReadOnly = mReadOnlyBln
        TxtVisaType.ReadOnly = mReadOnlyBln
        OptEnglishProficiency_IELTS.Enabled = Not mReadOnlyBln
        OptEnglishProficiency_TOEFL.Enabled = Not mReadOnlyBln
        TxtEnglishProficiency_Others.ReadOnly = Not mReadOnlyBln
        OptEnglishProficiency_Others.Enabled = Not mReadOnlyBln
        TxtNationalityCode.ReadOnly = mReadOnlyBln
        TxtOccupation.ReadOnly = mReadOnlyBln
        TxtReligion.ReadOnly = mReadOnlyBln
        TxtCategory.ReadOnly = mReadOnlyBln
        TxtIsInternationalStudent.ReadOnly = mReadOnlyBln
        TxtBloodGroup.ReadOnly = mReadOnlyBln
        TxtDOB.ReadOnly = mReadOnlyBln
        TxtAdd1.ReadOnly = mReadOnlyBln
        TxtAdd2.ReadOnly = mReadOnlyBln
        TxtPhone.ReadOnly = mReadOnlyBln
        TxtMobile.ReadOnly = mReadOnlyBln
        TxtCityCode.ReadOnly = mReadOnlyBln
        TxtPin.ReadOnly = mReadOnlyBln
        TxtEMail.ReadOnly = mReadOnlyBln
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL1.CurrentCell.ColumnIndex
                Case Col1Fee
                    'Call IniItemHelp(False, DGL1.AgSelectedValue(Col1BarCode, mRowIndex))
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL3.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            If DGL3.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL3.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case DGL3.CurrentCell.ColumnIndex
                'Case Col1Fee
                'Call IniItemHelp(False, DGL1.AgSelectedValue(Col1BarCode, mRowIndex))
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

    Private Sub Dgl3_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL3.CellValueChanged
        Dim mRowIndex As Integer, mColumnIndex As Integer
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            Select Case DGL3.CurrentCell.ColumnIndex
                'Case <ColumnIndex>
                'Call Calculation()
            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                If sender.Name <> DGL2.Name Then
                    sender.CurrentRow.Selected = True
                End If
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub


    Private Sub DGL3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL3.KeyDown
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
                Case Col1Fee
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


    Private Sub DGL3_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL3.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            If DGL3.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL3.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL3.CurrentCell.ColumnIndex
                Case Col3ProgrammStream
                    If DGL3.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL3.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
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

    Private Sub DglStream_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DglStream.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DglStream.CurrentCell.RowIndex
            mColumnIndex = DglStream.CurrentCell.ColumnIndex

            If DglStream.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DglStream.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DglStream.CurrentCell.ColumnIndex
                Case Col_SNo
                    If Val(DglStream.Item(Col_SNo, mRowIndex).Value) > 0 Then
                        DglStream.Item(Col_SNo, mRowIndex).Value = Format(Val(DglStream.Item(Col_SNo, mRowIndex).Value), "0")
                    Else
                        DglStream.Item(Col_SNo, mRowIndex).Value = ""
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


    Private Sub DGL3_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL3.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, Col_SNo)

        If DGL1.Rows.Count = 1 And Topctrl1.Mode = "Add" Then
            If DGL1.Item(Col1Fee, 0).Value Is Nothing Then DGL1.Item(Col1Fee, 0).Value = ""
            If DGL1.Item(Col1Fee, 0).Value.ToString.Trim = "" Then
                If TxtV_Type.Enabled = False Then TxtV_Type.Enabled = True
            End If
        End If

        Call Calculation()
    End Sub


    Private Sub DGL3_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL3.RowsRemoved
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
        TxtV_Type.Enter, TxtSessionProgrammeStream.Enter, TxtSessionProgramme.Enter, TxtEnquiryDocId.Enter

        Dim bStrFilter$ = ""
        Try
            Select Case sender.name
                Case TxtEnquiryDocId.Name
                    If TxtEnquiryDocId.AgHelpDataSet IsNot Nothing Then
                        bStrFilter = " 1=1 "
                        bStrFilter += " And EnquiryDate <= " & AgL.ConvertDate(TxtV_Date.Text) & " "
                        TxtEnquiryDocId.AgRowFilter = bStrFilter
                    End If

                Case TxtSessionProgrammeStream.Name
                    If TxtSessionProgramme.AgSelectedValue Is Nothing Then TxtSessionProgramme.AgSelectedValue = ""
                    TxtSessionProgrammeStream.AgRowFilter = " SessionProgramme = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "
                    'Case <Sender>.Name
                    '<Executable code>
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
          TxtV_Type.Validating, TxtVisaType.Validating, TxtVisaExpiryDate.Validating, TxtV_No.Validating, TxtV_Date.Validating, _
          TxtStudent.Validating, TxtSite_Code.Validating, TxtSessionProgrammeStream.Validating, TxtRemark.Validating, _
          TxtReligion.Validating, TxtPhone.Validating, TxtPassportNo.Validating, TxtOccupation.Validating, TxtNationalityCode.Validating, _
          TxtMotherNamePrefix.Validating, TxtMotherName.Validating, TxtMobile.Validating, TxtMiddleName.Validating, TxtLastName.Validating, _
          TxtIsInternationalStudent.Validating, TxtFirstName.Validating, TxtFatherNamePrefix.Validating, TxtFatherName.Validating, _
          TxtFatherIncome.Validating, TxtMotherIncome.Validating, TxtFamilyIncome.Validating, TxtEnglishProficiency_Others.Validating, _
          TxtDocId.Validating, TxtDOB.Validating, TxtCityCode.Validating, TxtCategory.Validating, TxtBloodGroup.Validating, _
          TxtAdmissionNature.Validating, TxtAdd2.Validating, TxtAdd1.Validating, TxtSessionProgramme.Validating, TxtScholarshipApplied.Validating, _
          OptEnglishProficiency_TOEFL.Validating, OptEnglishProficiency_Others.Validating, OptEnglishProficiency_IELTS.Validating, _
          TxtEnquiryDocId.Validating

        Try
            Select Case sender.NAME
                Case TxtEnquiryDocId.Name
                    Call Validating_Controls(sender)

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

                Case TxtStudent.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtIsNewStudent.Text = "Yes"
                        Call ProcManageStudentDetailControls(False)
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                TxtIsNewStudent.Text = "No"
                                TxtFirstName.Text = AgL.XNull(.Item("FirstName", .CurrentCell.RowIndex).Value)
                                TxtMiddleName.Text = AgL.XNull(.Item("MiddleName", .CurrentCell.RowIndex).Value)
                                TxtLastName.Text = AgL.XNull(.Item("LastName", .CurrentCell.RowIndex).Value)
                                TxtSex.Text = AgL.XNull(.Item("Sex", .CurrentCell.RowIndex).Value)
                                TxtFatherNamePrefix.Text = AgL.XNull(.Item("FatherNamePrefix", .CurrentCell.RowIndex).Value)
                                TxtFatherName.Text = AgL.XNull(.Item("FatherName", .CurrentCell.RowIndex).Value)
                                TxtMotherName.Text = AgL.XNull(.Item("MotherName", .CurrentCell.RowIndex).Value)
                                TxtMotherNamePrefix.Text = AgL.XNull(.Item("MotherNamePrefix", .CurrentCell.RowIndex).Value)
                                TxtLocalGuardian.Text = AgL.XNull(.Item("LocalGuardian", .CurrentCell.RowIndex).Value)
                                TxtOccupation.AgSelectedValue = AgL.XNull(.Item("Occupation", .CurrentCell.RowIndex).Value)
                                TxtFatherDesignation.Text = AgL.XNull(.Item("FatherDesignation", .CurrentCell.RowIndex).Value)
                                TxtFatherCompany.Text = AgL.XNull(.Item("FatherCompany", .CurrentCell.RowIndex).Value)
                                TxtFatherCompanyAddress.Text = AgL.XNull(.Item("FatherCompanyAddress", .CurrentCell.RowIndex).Value)
                                TxtMotherOccupation.AgSelectedValue = AgL.XNull(.Item("MotherOccupation", .CurrentCell.RowIndex).Value)
                                TxtMotherDesignation.Text = AgL.XNull(.Item("MotherDesignation", .CurrentCell.RowIndex).Value)
                                TxtMotherCompany.Text = AgL.XNull(.Item("MotherCompany", .CurrentCell.RowIndex).Value)
                                TxtMotherCompanyAddress.Text = AgL.XNull(.Item("MotherCompanyAddress", .CurrentCell.RowIndex).Value)
                                TxtFatherIncome.Text = Format(AgL.VNull(.Item("FatherIncome", .CurrentCell.RowIndex).Value), "0.00")
                                TxtMotherIncome.Text = Format(AgL.VNull(.Item("MotherIncome", .CurrentCell.RowIndex).Value), "0.00")
                                TxtFamilyIncome.Text = Format(AgL.VNull(.Item("FamilyIncome", .CurrentCell.RowIndex).Value), "0.00")

                                TxtPassportNo.Text = AgL.XNull(.Item("PassportNo", .CurrentCell.RowIndex).Value)
                                TxtVisaExpiryDate.Text = AgL.RetDate(AgL.XNull(.Item("VisaExpiryDate", .CurrentCell.RowIndex).Value))
                                TxtVisaType.Text = AgL.XNull(.Item("VisaType", .CurrentCell.RowIndex).Value)
                                OptEnglishProficiency_IELTS.Checked = AgL.VNull(.Item("EnglishProficiency_IELTS", .CurrentCell.RowIndex).Value)
                                OptEnglishProficiency_TOEFL.Checked = AgL.VNull(.Item("EnglishProficiency_TOEFL", .CurrentCell.RowIndex).Value)
                                TxtEnglishProficiency_Others.Text = AgL.XNull(.Item("EnglishProficiency_Others", .CurrentCell.RowIndex).Value)
                                OptEnglishProficiency_Others.Checked = IIf(TxtEnglishProficiency_Others.Text.Trim <> "", True, False)
                                TxtNationalityCode.AgSelectedValue = AgL.XNull(.Item("NationalityCode", .CurrentCell.RowIndex).Value)
                                TxtReligion.AgSelectedValue = AgL.XNull(.Item("Religion", .CurrentCell.RowIndex).Value)
                                TxtCategory.AgSelectedValue = AgL.XNull(.Item("Category", .CurrentCell.RowIndex).Value)
                                TxtIsInternationalStudent.Text = IIf(AgL.VNull(.Item("IsInternationalStudent", .CurrentCell.RowIndex).Value), "Yes", "No")
                                TxtBloodGroup.Text = AgL.XNull(.Item("BloodGroup", .CurrentCell.RowIndex).Value)
                                TxtDOB.Text = AgL.RetDate(AgL.XNull(.Item("DOB", .CurrentCell.RowIndex).Value))
                                TxtAdd1.Text = AgL.XNull(.Item("Add1", .CurrentCell.RowIndex).Value)
                                TxtAdd2.Text = AgL.XNull(.Item("Add2", .CurrentCell.RowIndex).Value)
                                TxtPhone.Text = AgL.XNull(.Item("Phone", .CurrentCell.RowIndex).Value)
                                TxtMobile.Text = AgL.XNull(.Item("Mobile", .CurrentCell.RowIndex).Value)
                                TxtCityCode.AgSelectedValue = AgL.XNull(.Item("CityCode", .CurrentCell.RowIndex).Value)
                                TxtPin.Text = AgL.XNull(.Item("PIN", .CurrentCell.RowIndex).Value)
                                TxtEMail.Text = AgL.XNull(.Item("EMail", .CurrentCell.RowIndex).Value)
                                TxtTAdd1.Text = AgL.XNull(.Item("TAdd1", .CurrentCell.RowIndex).Value)
                                TxtTAdd2.Text = AgL.XNull(.Item("TAdd2", .CurrentCell.RowIndex).Value)
                                TxtTPhone.Text = AgL.XNull(.Item("TPhone", .CurrentCell.RowIndex).Value)
                                TxtTMobile.Text = AgL.XNull(.Item("TMobile", .CurrentCell.RowIndex).Value)
                                TxtTCityCode.AgSelectedValue = AgL.XNull(.Item("TCityCode", .CurrentCell.RowIndex).Value)
                                TxtTPin.Text = AgL.XNull(.Item("TPIN", .CurrentCell.RowIndex).Value)
                                TxtPAdd1.Text = AgL.XNull(.Item("PAdd1", .CurrentCell.RowIndex).Value)
                                TxtPAdd2.Text = AgL.XNull(.Item("PAdd2", .CurrentCell.RowIndex).Value)
                                TxtPPhone.Text = AgL.XNull(.Item("PPhone", .CurrentCell.RowIndex).Value)
                                TxtPMobile.Text = AgL.XNull(.Item("PMobile", .CurrentCell.RowIndex).Value)
                                TxtPCityCode.AgSelectedValue = AgL.XNull(.Item("PCityCode", .CurrentCell.RowIndex).Value)
                                TxtPPin.Text = AgL.XNull(.Item("PPIN", .CurrentCell.RowIndex).Value)

                                Call ProcManageStudentDetailControls(True)
                            End With
                        End If
                    End If



                Case TxtIsInternationalStudent.Name
                    If AgL.StrCmp(TxtIsInternationalStudent.Text, "Yes") Then
                        TxtPassportNo.ReadOnly = False : TxtVisaType.ReadOnly = False : TxtVisaExpiryDate.ReadOnly = False
                    Else
                        TxtPassportNo.ReadOnly = True : TxtVisaType.ReadOnly = True : TxtVisaExpiryDate.ReadOnly = True
                        TxtPassportNo.Text = "" : TxtVisaType.Text = "" : TxtVisaExpiryDate.Text = ""
                    End If

                Case TxtEnglishProficiency_Others.Name, OptEnglishProficiency_Others.Name
                    If OptEnglishProficiency_Others.Checked = False Then
                        TxtEnglishProficiency_Others.ReadOnly = True
                        TxtEnglishProficiency_Others.Text = ""
                    Else
                        TxtEnglishProficiency_Others.ReadOnly = False
                    End If

                Case TxtSessionProgrammeStream.Name
                    If Val(BtnStream.Tag) Then TxtSessionProgrammeStream.AgSelectedValue = ""
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

        Call BlankFooterGrid()
        TxtFamilyIncome.Text = Format(Val(TxtFatherIncome.Text) + Val(TxtMotherIncome.Text), "0.00")

        With DGL1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""

                If .Item(Col1Fee, I).Value <> "" Then
                    .Item(Col1NetAmount, I).Value = Format(Val(.Item(Col1Amount, I).Value) - Val(.Item(Col1Discount, I).Value), "0.00")

                    If bNetAmount < Val(.Item(Col1NetAmount, I).Value) Then
                        mMaxFeeAc = .AgSelectedValue(Col1Fee, I)
                    End If

                    'Footer Detail
                    DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value = Format(Val(DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value) + Val(.Item(Col1Amount, I).Value), "0.00")
                    DGLFooter.Item(DFC_Amount, DFR_TotalDiscount).Value = Format(Val(DGLFooter.Item(DFC_Amount, DFR_TotalDiscount).Value) + Val(.Item(Col1Discount, I).Value), "0.00")
                    DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value = Format(Val(DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value) + Val(.Item(Col1NetAmount, I).Value), "0.00")
                End If
            Next
        End With

    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStrModule$ = ""
        Try
            Call Calculation()

            Tc1.SelectedTab = Tp1
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type) Then Exit Function
            If AgL.RequiredField(TxtV_Date, "Voucher Date") Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function

            If AgL.RequiredField(TxtSessionProgramme, "Programme") Then Exit Function
            If TxtSessionProgrammeStream.Text.Trim = "" And Val(BtnStream.Tag) = 0 Then MsgBox("Programme (Stream) Can't Be Blank!...") : TxtSessionProgrammeStream.Focus() : Exit Function
            If Not AgL.IsValid_EMailId(TxtEMail, "Email ID") Then Exit Function

            If TxtDOB.Text.Trim <> "" Then
                If CDate(TxtDOB.Text) >= CDate(TxtV_Date.Text) Then
                    MsgBox("Date Of Birth Is Not Correct!...")
                    TxtDOB.Focus() : Exit Function
                End If
            End If


            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsBlankGrid(DGL1, Col1Fee) Then Exit Function
            If AgCL.AgIsDuplicate(DGL1, "" & Col1Fee & "") Then Exit Function

            If Val(DGLFooter.Item(DFC_Amount, DFR_TotalAmount).Value) <= 0 Then
                MsgBox("Total Amount Can't Be Blank!...")
                DGL1.CurrentCell = DGL1(Col1Amount, 0) : DGL1.Focus()
                Exit Function
            End If

            If Val(TxtReceiveAmount.Text) <> Val(DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value) Then
                MsgBox("Receive Amount Is Not Equal To Rs. """ & Val(DGLFooter.Item(DFC_Amount, DFR_TotalNetAmount).Value) & """")
                TxtReceiveAmount.Focus() : Exit Function
            End If

            Tc1.SelectedTab = Tp2
            AgCL.AgBlankNothingCells(DGL2)
            If AgCL.AgIsBlankGrid(DGL2, Col2Class) Then Tc1.SelectedTab = Tp2 : DGL2.Focus() : Exit Function
            If AgCL.AgIsDuplicate(DGL2, "" & Col2Class & "") Then Tc1.SelectedTab = Tp2 : DGL2.Focus() : Exit Function

            If AgCL.AgIsBlankGrid(DGL3, Col3Status) Then Exit Function

            Tc1.SelectedTab = Tp1

            '================================================================================================================================================================
            '===================< Search Code Create >=======================================================================================================================
            '=========================< Start >==============================================================================================================================
            '================================================================================================================================================================
            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mSearchCode <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                    TxtDocId.Text = mSearchCode
                End If
            End If
            '================================================================================================================================================================
            '===================< Search Code Create >=======================================================================================================================
            '=========================< End >==============================================================================================================================
            '================================================================================================================================================================

            '================================================================================================================================================================
            '===================< Manual Code Create >=======================================================================================================================
            '=========================< Start >==============================================================================================================================
            '================================================================================================================================================================
            If TxtManualRegNo.Text.Trim = "" Then
                If MsgBox("" & LblManualRegNo.Text & " is Blank!..." & vbCrLf & "Do You Want To Auto Assign It?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Validation Check") = MsgBoxResult.Yes Then
                    TxtManualRegNo.Text = AgL.ConvertDocId(mSearchCode)
                End If
            End If
            If AgL.RequiredField(TxtManualRegNo, LblManualRegNo.Text) Then Exit Function
            'Code By satyam on 26/03/2011
            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_Registration Where ManualRegNo='" & TxtManualRegNo.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Reg. No. Already Exist!") : TxtManualRegNo.Focus() : Exit Function
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Sch_Registration Where ManualRegNo='" & TxtManualRegNo.Text & "' And DocId<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Reg. No. Already Exist!") : TxtManualRegNo.Focus() : Exit Function
            End If
            'End Code By satyam on 26/03/2011
            '================================================================================================================================================================
            '===================< Manual Code Create >=======================================================================================================================
            '=========================< End >==============================================================================================================================
            '================================================================================================================================================================


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
                LblV_Type.Tag = Academic_ProjLib.ClsMain.NCat_RegistrationEntry
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

    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec = Nothing
        Dim I As Integer, J As Integer
        Dim mNarr As String = "", mCommonNarr$ = "", bContraSub$ = ""
        Dim mVNo As Long = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
        Dim GcnRead As SqlClient.SqlConnection
        Dim DtTemp As DataTable


        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        I = 0
        ReDim Preserve LedgAry(I)

        If Val(PaymentRec.TotalAmount) > 0 Then

            With PaymentRec
                If .CashAmount > 0 Then
                    bContraSub = .CashAc

                ElseIf .BankAmount > 0 Then
                    bContraSub = .BankAc

                ElseIf .BankAmount2 > 0 Then
                    bContraSub = .BankAc2

                ElseIf .BankAmount3 > 0 Then
                    bContraSub = .BankAc3

                ElseIf .CardAmount > 0 Then
                    bContraSub = .CardAc

                ElseIf .AcTransferAmount > 0 Then
                    bContraSub = .AcTransferBankAc

                End If
            End With

            mQry = "SELECT Rf.Fee, Max(Sg.Name) As FeeName, Sum(Rf.NetAmount) AS NetAmount " & _
                    " FROM Sch_RegistrationFee Rf With (NoLock) " & _
                    " Left Join SubGroup Sg With (NoLock) On Rf.Fee = Sg.SubCode " & _
                    " WHERE Rf.DocId = '" & mSearchCode & "' " & _
                    " GROUP BY Rf.Fee "
            DtTemp = AgL.FillData(mQry, GcnRead).Tables(0)
            With DtTemp
                For J = 0 To .Rows.Count - 1
                    mNarr = "Being " & AgL.XNull(.Rows(J)("FeeName")) & " of Rs. " & AgL.VNull(.Rows(J)("NetAmount")) & " Received."

                    I = UBound(LedgAry) + 1
                    ReDim Preserve LedgAry(I)

                    LedgAry(I).SubCode = AgL.XNull(.Rows(J)("Fee"))
                    LedgAry(I).ContraSub = bContraSub
                    LedgAry(I).AmtDr = 0
                    LedgAry(I).AmtCr = Val(Format(AgL.VNull(.Rows(J)("NetAmount")), "0.00"))
                    LedgAry(I).Narration = mNarr
                Next
            End With
        End If

        mCommonNarr = ""
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        If AgL.PubObjFrmPaymentDetail.AccountPosting(PaymentRec, AgL.GCn, AgL.Gcn_ConnectionString, AgL.ECmd, LedgAry, mCommonNarr, False) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If

        If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If


        GcnRead.Close()
        GcnRead.Dispose()
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCopyPermanentAddress.Click, BtnCopyLocalAddress.Click
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Select Case sender.name
            Case BtnCopyPermanentAddress.Name
                TxtPAdd1.Text = TxtAdd1.Text
                TxtPAdd2.Text = TxtAdd2.Text
                TxtPCityCode.AgSelectedValue = TxtCityCode.AgSelectedValue
                TxtPPin.Text = TxtPin.Text

            Case BtnCopyLocalAddress.Name
                TxtTAdd1.Text = TxtAdd1.Text
                TxtTAdd2.Text = TxtAdd2.Text
                TxtTCityCode.AgSelectedValue = TxtCityCode.AgSelectedValue
                TxtTPin.Text = TxtPin.Text
        End Select
    End Sub

    Private Sub BtnStream_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnStream.Click
        Dim mCondStr As String = ""
        Dim DTbl As DataTable = Nothing
        Dim I As Integer, J As Integer
        Try
            If DglStream.Visible = True Then
                With DglStream
                    BtnStream.Tag = 0
                    For I = 0 To .Rows.Count - 1
                        If .Item(Col_SNo, I).Value Is Nothing Then .Item(Col_SNo, I).Value = ""
                        If Val(.Item(Col_SNo, I).Value) = 0 Then .Item(Col_SNo, I).Value = ""
                        If .Item(ColStreamName, I).Value Is Nothing Then .Item(ColStreamName, I).Value = ""
                        If .Item(ColStreamCode, I).Value Is Nothing Then .Item(ColStreamCode, I).Value = ""

                        If Val(.Item(Col_SNo, I).Value) > 0 And .Item(ColStreamName, I).Value.ToString.Trim <> "" Then
                            For J = I + 1 To .Rows.Count - 1
                                If .Item(Col_SNo, J).Value Is Nothing Then .Item(Col_SNo, J).Value = ""
                                If Val(.Item(Col_SNo, J).Value) = 0 Then .Item(Col_SNo, J).Value = ""
                                If .Item(ColStreamName, J).Value Is Nothing Then .Item(ColStreamName, J).Value = ""

                                If Val(.Item(Col_SNo, J).Value) > 0 And .Item(ColStreamName, J).Value.ToString.Trim <> "" Then
                                    If Val(.Item(Col_SNo, J).Value) = Val(.Item(Col_SNo, I).Value) Then
                                        BtnStream.Tag = 0
                                        MsgBox("Duplicate Order No. Exists For Stream : """ & .Item(ColStreamName, J).Value & """!...")
                                        DglStream.CurrentCell = DglStream(Col_SNo, J) : DglStream.Focus() : Exit Sub
                                    End If
                                End If
                            Next
                            If Val(BtnStream.Tag) = 0 Then BtnStream.Tag = 1
                        End If
                    Next I
                End With

                DglStream.Visible = False
                Exit Sub
            Else
                If AgL.XNull(TxtSessionProgramme.AgSelectedValue) = AgL.XNull(DglStream.Tag) Then
                    If Val(BtnStream.Tag) = 1 Then
                        DglStream.Top = TxtSessionProgrammeStream.Top + TxtSessionProgrammeStream.Height
                        DglStream.Left = TxtSessionProgrammeStream.Left

                        DglStream.Visible = True
                        Exit Sub
                    End If
                End If
            End If

            DglStream.DataSource = Nothing
            If TxtSessionProgrammeStream.Text.Trim <> "" Then MsgBox("Stream Selection Is Not Permitted!...") : TxtSessionProgrammeStream.Focus() : Exit Sub
            If AgL.RequiredField(TxtSessionProgramme, "Programme") Then Exit Sub

            DglStream.Tag = TxtSessionProgramme.AgSelectedValue
            mCondStr = " Where Vs.SessionProgramme = " & AgL.Chk_Text(TxtSessionProgramme.AgSelectedValue) & " "

            mQry = "Select v1.[Order], v1.Stream, v1.Code, v1.TotalSeats As [Total Seats], IsNull(vP.TotalAdmissions,0) AS [Total Admissions], " & _
                       " v1.TotalSeats - IsNull(vP.TotalAdmissions,0) AS [Available Seats] " & _
                       " From( " & _
                       " SELECT  Rs.Sr AS [Order], VS.SessionProgrammeStream Stream, Vs.Code, vS.TotalSeats " & _
                       " FROM Sch_RegistrationStream Rs " & _
                       " Left Join ViewSch_SessionProgrammeStream VS On Rs.SessionProgrammeStream = Vs.Code " & _
                       " " & mCondStr & " And " & IIf(Topctrl1.Mode = "Add", " 1=2 ", " Rs.DocId = '" & mSearchCode & "' ") & " " & _
                       " UNION ALL " & _
                       " SELECT 0 AS [Order], VS.SessionProgrammeStream Stream, Vs.Code, vS.TotalSeats " & _
                       " FROM ViewSch_SessionProgrammeStream Vs " & _
                       " " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), "", " LEFT JOIN Sch_RegistrationStream Rs ON Rs.SessionProgrammeStream = Vs.Code AND " & IIf(Topctrl1.Mode = "Add", " 1=1 ", " Rs.DocId = '" & mSearchCode & "' ") & " ") & " " & _
                       " " & mCondStr & " AND " & IIf(Topctrl1.Mode = "Add", " 1=1 ", " Rs.SessionProgrammeStream IS NULL ") & "" & _
                       " ) v1 Left Join " & _
                       " (SELECT Sem.SessionProgrammeStreamCode, Count(P.FromStreamYearSemester) AS TotalAdmissions " & _
                       " FROM Sch_AdmissionPromotion P " & _
                       " LEFT JOIN ViewSch_StreamYearSemester Sem ON Sem.Code = P.FromStreamYearSemester  " & _
                       " WHERE P.PromotionDate Is NULL " & _
                       " GROUP BY Sem.SessionProgrammeStreamCode " & _
                       " ) vP ON v1.Code = vP.SessionProgrammeStreamCode " & _
                       " "
            DTbl = CType(AgL.FillData(mQry, AgL.GCn), DataSet).Tables(0)
            DglStream.DataSource = DTbl

            Call IniStreamGrid()

            If DTbl.Rows.Count = 0 Then
                BtnStream.Tag = 0 : DglStream.Tag = ""
                MsgBox("Streams Are Not Available!...", , Me.Text)
            Else
                DglStream.Top = TxtSessionProgrammeStream.Top + TxtSessionProgrammeStream.Height
                DglStream.Left = TxtSessionProgrammeStream.Left
                DglStream.Visible = True
            End If

        Catch ex As Exception
            DglStream.DataSource = Nothing
            MsgBox(ex.Message)
        Finally
            DTbl = Nothing
        End Try
    End Sub

    Private Sub IniStreamGrid()
        Dim I As Integer
        With DglStream
            .Columns(Col_SNo).Width = 50
            .Columns(ColStreamName).Width = 170
            .Columns(ColStreamCode).Visible = False
            .RowHeadersVisible = False
            .AllowUserToAddRows = False

            For I = 1 To .Columns.Count - 1
                .Columns(I).ReadOnly = True
            Next

            For I = 0 To .Rows.Count - 1
                If .Item(Col_SNo, I).Value Is Nothing Then .Item(Col_SNo, I).Value = ""
                If Val(.Item(Col_SNo, I).Value) = 0 Then .Item(Col_SNo, I).Value = ""
            Next

        End With
    End Sub

    Private Sub TxtRollNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtRollNo.TextChanged

    End Sub

    Private Sub Label62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label62.Click

    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Pnl3.Paint

    End Sub

    Private Sub DGL5_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
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
                    CType(FrmObj, FrmSubjectMarks).DblNetPercentage = Val(DGL2.Item(Col2PCMPercentage, mRowIndex).Value)

                    FrmObj.ShowDialog()
                    DGL2.Item(Col2SubjectList, mRowIndex).Value = CType(FrmObj, FrmSubjectMarks).StrSubjectList
                    DGL2.Item(Col2MarksList, mRowIndex).Value = CType(FrmObj, FrmSubjectMarks).StrMarksList
                    DGL2.Item(Col2PercentageList, mRowIndex).Value = CType(FrmObj, FrmSubjectMarks).StrPercentageList
                    DGL2.Item(Col2PCMPercentage, mRowIndex).Value = Format(CType(FrmObj, FrmSubjectMarks).DblNetPercentage, "0.00")
                    FrmObj = Nothing
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub BtnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) _
    Handles BtnApproved.Click
        Dim mTrans As Boolean = False
        Dim mApprovedDate$ = ""

        Select Case sender.name
            Case BtnApproved.Name
                Try
                    If Topctrl1.Mode = "Browse" Then
                        If MsgBox("Are You Sure To Approve Record", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Approved Confirmation...") = MsgBoxResult.No Then Exit Sub

                        If mSearchCode <> "" Then
                            ''=======================Approval Start======================================

                            TxtApproved.Text = AgL.PubUserName
                            mApprovedDate = AgL.GetDateTime(AgL.GCn)

                            AgL.ECmd = AgL.GCn.CreateCommand
                            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                            AgL.ECmd.Transaction = AgL.ETrans
                            mTrans = True


                            Call ProcApproveVoucher(TxtApproved.Text, mApprovedDate, False)

                            ''===========================================================================

                            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                            AgL.ETrans.Commit()
                            mTrans = False

                            MsgBox("Voucher Approved Successfully.", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                            If AgL.PubMoveRecApplicable Then
                                FIniMaster(0, 1) : Topctrl_tbRef()
                            End If
                            MoveRec()
                        End If
                    End If
                Catch ex As Exception
                    If mTrans = True Then AgL.ETrans.Rollback()
                    MsgBox(ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                End Try
        End Select
    End Sub

    Private Sub ProcApproveVoucher(ByVal StrApprovedBy As String, ByVal StrApprovedDate As String, ByVal BlnIsAutoApproved As Boolean)

        mQry = "Update Sch_Registration Set ApprovedBy='" & StrApprovedBy & "', ApprovedDate=" & AgL.Chk_Text(StrApprovedDate) & ", IsAutoApproved = " & IIf(BlnIsAutoApproved, 1, 0) & " Where DocId='" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


        mQry = "Update Sch_RegistrationPaymentDetail " & _
                " Set " & _
                " LedgerMDocId = Null " & _
                " Where DocId = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


        AgL.PubObjFrmPaymentDetail = mObjFrmPaymentDetail
        Call AccountPosting()

        mQry = "Update Sch_RegistrationPaymentDetail " & _
                " Set " & _
                " LedgerMDocId = '" & mSearchCode & "' " & _
                " Where DocId = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


        Call AgL.LogTableEntry(mSearchCode, Me.Text, AgLibrary.ClsConstant.EntryMode_Varified, AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , TxtV_Date.Text, , , Val(TxtReceiveAmount.Text), TxtSite_Code.AgSelectedValue, AgL.PubDivCode)
    End Sub

    Private Function FunGetModuleName() As String
        Dim bStrReturn$ = ""
        Try
            If Academic_ProjLib.ClsMain.IsModuleActive_AcademicMain Then
                bStrReturn = Academic_Objects.ClsConstant.Module_Academic_Main
            ElseIf Academic_ProjLib.ClsMain.IsModuleActive_FeeModule Then
                bStrReturn = Academic_Objects.ClsConstant.Module_Academic_Fee
            Else
                bStrReturn = ""
            End If
        Catch ex As Exception
            bStrReturn = ""
        Finally
            FunGetModuleName = bStrReturn
        End Try
    End Function

    Private Sub BtnFindEnqury_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnFindEnqury.Click
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

            mQry = "SELECT H.DocId AS Code, " & AgL.V_No_Field("H.DocId") & " As [Enquiry No], " & AgL.ConvertDateField("H.V_Date") & " As [Enquiry Date], " & _
                                " isnull(H.FirstName,'') +' '+ isnull(H.MiddleName,'') +' '+ isnull(H.LastName,'') AS [Person Name], " & _
                                " C.CityName AS City, " & _
                                " SG.DispName AS [Enquiry By], H.EnquiryMode AS [Enquiry Mode], E2.DispName AS [Enquiry Assign To], " & _
                                " CASE WHEN isnull(H.IsClosed,0) <> 0 THEN 'Yes' ELSE 'No' End  AS [Is Closed], H.Status  " & _
                                " FROM Enquiry_Enquiry H  " & _
                                " LEFT JOIN SubGroup SG ON SG.SubCode=H.Employee " & _
                                " LEFT JOIN SubGroup E2 ON E2.SubCode=H.AssignedTo " & _
                                " LEFT JOIN City C ON C.CityCode=H.CityCode " & _
                                " Where H.V_Date <= " & AgL.ConvertDate(TxtV_Date.Text) & " "
            AgL.PubFindQry = mQry
            AgL.PubFindQryOrdBy = "Convert(SmallDateTime, [Enquiry Date]) Desc, [Enquiry No]"

            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing

            If AgL.PubSearchRow <> "" Then
                TxtEnquiryDocId.AgSelectedValue = AgL.PubSearchRow
                Call Validating_Controls(TxtEnquiryDocId)
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub


    Private Sub Validating_Controls(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtEnquiryDocId.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        'TxtCostCenter.AgSelectedValue = AgL.XNull(DrTemp(0)("Cost Center"))

                        'If AgL.XNull(DrTemp(0)("RegistrationDocId")).ToString.Trim <> "" Then
                        '    If AgL.StrCmp(AgL.XNull(DrTemp(0)("RegistrationDocId")), mSearchCode) Then

                        '    End If
                        'End If


                    End If
                End If
        End Select
    End Sub
End Class
