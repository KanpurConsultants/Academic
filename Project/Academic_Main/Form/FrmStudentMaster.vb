Imports CrystatlDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmStudentMaster
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = "", mDisplayName As String = ""
    Dim mGroupNature As String = "", mNature As String = ""
    Dim Photo_Byte As Byte(), StudentSignature_Byte As Byte(), ParentSignature1_Byte As Byte()
    Dim mParentSignature1Flag As Boolean, mBlnImprtFromExcelFlag As Boolean = False

    Dim mObjClsMain As New ClsMain(AgL, PLib)

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Class As Byte = 1
    Private Const Col1University As Byte = 2
    Private Const Col1EnrollmentNo As Byte = 3
    Private Const Col1YearOfPassing As Byte = 4
    Private Const Col1Subjects As Byte = 5
    Private Const Col1Result As Byte = 6
    Private Const Col1TotalPercentage As Byte = 7
    Private Const Col1PCMPercentage As Byte = 8
    Private Const Col1Remark As Byte = 9

    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2AsOnDate As Byte = 1
    Private Const Col2FatherIncome As Byte = 2
    Private Const Col2MotherIncome As Byte = 3
    Private Const Col2FamilyIncome As Byte = 4
    Private Const Col2FatherOccupation As Byte = 5
    Private Const Col2FatherCompany As Byte = 6
    Private Const Col2FatherCompanyAddress As Byte = 7
    Private Const Col2FatherDesignation As Byte = 8
    Private Const Col2MotherOccupation As Byte = 9
    Private Const Col2MotherCompany As Byte = 10
    Private Const Col2MotherCompanyAddress As Byte = 11
    Private Const Col2MotherDesignation As Byte = 12

    Dim mBlnExists_SubGroupLog As Boolean = False
    Dim mRegistrationDocId$ = "", mAsOnDate$ = ""
    Dim mStruct_LibraryMaster As Academic_ProjLib.ClsMain.Struct_LibraryMaster = Nothing

    Public Property RegistrationDocId() As String
        Get
            RegistrationDocId = mRegistrationDocId
        End Get
        Set(ByVal value As String)
            mRegistrationDocId = value
        End Set
    End Property

    Public Property AsOnDate() As String
        Get
            AsOnDate = mAsOnDate$
        End Get
        Set(ByVal value As String)
            mAsOnDate$ = value
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
        ''================< Academic Data Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL1, "DGL1SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL1, "Dgl1Class", 120, 50, "Class/Standard", True, False, False, True)
            .AddAgTextColumn(DGL1, "Dgl1University", 150, 50, "Board/University", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1EnrollmentNo", 100, 20, "Enrollment No", True, False, False)
            .AddAgNumberColumn(DGL1, "Dgl1YearOfPassing", 60, 4, 0, False, "Year", True, False, True)
            .AddAgTextColumn(DGL1, "Dgl1Subjects", 120, 255, "Subjects", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1Result", 80, 20, "Result", True, False, False)
            .AddAgNumberColumn(DGL1, "Dgl1TotalPercentage", 50, 2, 2, False, "Total %", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1PCMPercentage", 50, 2, 2, False, "% For Merit", True, False, True)
            .AddAgTextColumn(DGL1, "Dgl1Remark", 80, 255, "Remark", True, False, False)
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40

        ''==============================================================================
        ''==================< Income Data Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "DGL2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgDateColumn(DGL2, "As On Date", 100, "As On Date", True, True, False)
            .AddAgNumberColumn(DGL2, "Father Income", 100, 8, 2, False, "Father Income", True, True, True)
            .AddAgNumberColumn(DGL2, "Mother Income", 100, 8, 2, False, "Mother Income", True, True, True)
            .AddAgNumberColumn(DGL2, "Family Income", 100, 8, 2, False, "Family Income", True, True, True)
            .AddAgTextColumn(DGL2, "Father Occupation", 150, 50, "Father Occupation", True, True, False)
            .AddAgTextColumn(DGL2, "Father Company", 150, 100, "Father Company", True, True, False)
            .AddAgTextColumn(DGL2, "Father Company Address", 150, 100, "Father Company Address", True, True, False)
            .AddAgTextColumn(DGL2, "Father Designation", 100, 50, "Father Designation", True, True, False)
            .AddAgTextColumn(DGL2, "Mother Occupation", 150, 50, "Mother Occupation", True, True, False)
            .AddAgTextColumn(DGL2, "Mother Company", 150, 100, "Mother Company", True, True, False)
            .AddAgTextColumn(DGL2, "Mother Company Address", 150, 100, "Mother Company Address", True, True, False)
            .AddAgTextColumn(DGL2, "Mother Designation", 100, 50, "Mother Designation", True, True, False)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 40
        DGL2.AllowUserToAddRows = False
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
            mBlnExists_SubGroupLog = AgL.IsTableExist("SubGroup_Log", AgL.GCn)

            AgL.WinSetting(Me, 650, 950, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "Select S.Subcode As SearchCode " & _
                " From Sch_Student S " & _
                " Left Join SubGroup Sg On Sg.SubCode = S.SubCode " & _
                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                           " Where 1=1  Order By Name"
            TxtSite_Code.AgHelpDataSet(0, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)


            mQry = "Select SubCode  As Code, ManualCode As Name From SubGroup " & _
                "  Order By ManualCode"
            TxtManualCode.AgHelpDataSet(0, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select NationalityCode  As Code, Nationaliy As Name From Nationality " & _
               "  Order By Nationaliy"
            TxtNationalityCode.AgHelpDataSet(0, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)


            mQry = "Select Code  As Code, Name As Name From Country " & _
                    " Order By Name"
            TxtCountryCode.AgHelpDataSet(0, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)
            TxtPCountryCode.AgHelpDataSet(0, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)


            mQry = "Select  Code  As Code, Description As Name From Sch_Occupation " & _
                "  Order By Description"
            TxtOccupation.AgHelpDataSet(0, TC1.Top + Tp2.Top, TC1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)
            TxtMotherOccupation.AgHelpDataSet(0, TC1.Top + Tp2.Top, TC1.Left + Tp2.Left) = TxtOccupation.AgHelpDataSet.Copy
            DGL2.AgHelpDataSet(Col2FatherOccupation, TC1.Top + Tp2.Top, TC1.Left + Tp2.Left) = TxtOccupation.AgHelpDataSet.Copy
            DGL2.AgHelpDataSet(Col2MotherOccupation, TC1.Top + Tp2.Top, TC1.Left + Tp2.Left) = TxtOccupation.AgHelpDataSet.Copy

            mQry = "SELECT DISTINCT V.Designation AS Code, V.Designation AS Name " & _
                    " FROM (" & _
                    " SELECT DISTINCT S.FatherDesignation AS Designation FROM Sch_Student S WHERE IsNull(S.FatherDesignation,'') <> '' " & _
                    " UNION ALL " & _
                    " SELECT DISTINCT S.MotherDesignation AS Designation FROM Sch_Student S WHERE IsNull(S.MotherDesignation,'') <> '' " & _
                    " ) As V ORDER BY V.Designation "
            TxtFatherDesignation.AgHelpDataSet(0, TC1.Top + Tp2.Top, TC1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)
            TxtMotherDesignation.AgHelpDataSet(0, TC1.Top + Tp2.Top, TC1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)
            DGL2.AgHelpDataSet(Col2FatherDesignation, TC1.Top + Tp2.Top, TC1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)
            DGL2.AgHelpDataSet(Col2MotherDesignation, TC1.Top + Tp2.Top, TC1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select  Code  As Code, ManualCode As Name From Sch_Category " & _
                      "  Order By Description"
            TxtCategory.AgHelpDataSet(0, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)


            mQry = "Select  Code  As Code, Description As Name From Sch_Religion " & _
               "  Order By Description"
            TxtReligion.AgHelpDataSet(0, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

            AgCL.IniAgHelpList(TxtSex, "Male,Female")

            AgCL.IniAgHelpList(TxtBloodGroup, "A+,A-,B+,B-,AB+,AB-,O+,O-")

            mQry = "SELECT DISTINCT FatherNamePrefix AS code,FatherNamePrefix AS Name FROM " & _
                  " SubGroup WHERE isnull(FatherNamePrefix,'')<>'' order by FatherNamePrefix "
            TxtFatherNamePrefix.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT MotherNamePrefix AS code,MotherNamePrefix AS Name FROM " & _
                   " Sch_Student WHERE isnull(MotherNamePrefix,'')<>'' order by MotherNamePrefix "
            TxtMotherNamePrefix.AgHelpDataSet(0, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT U.Code , U.ManualCode [Board/University] FROM Sch_University U ORDER BY U.ManualCode "
            DGL1.AgHelpDataSet(Col1University, , TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT A.GroupCode AS Code, A.GroupName AS Name, A.GroupNature , A.Nature  " & _
                    " FROM AcGroup A " & _
                    " WHERE LEFT(MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryDebtors & ")='" & AgLibrary.ClsConstant.MainGRCodeSundryDebtors & "' AND " & _
                    " MainGrLen > " & AgLibrary.ClsConstant.MainGRLenSundryDebtors & " AND AliasYn = 'N'"
            TxtGroupCode.AgHelpDataSet(2, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

            Call IniCityHelp()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IniCityHelp()
        Try
            mQry = "SELECT city.CityCode AS code,City.CityName AS Name,State.State_Desc AS State," & _
                   " Country.Name AS Country FROM City " & _
                   " LEFT JOIN State ON city.State_Code=State.State_Code " & _
                   " LEFT JOIN Country ON State.CountryCode=Country.Code Order by  city.cityname "
            TxtCityCode.AgHelpDataSet(0, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)
            TxtPCityCode.AgHelpDataSet(0, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = TxtCityCode.AgHelpDataSet.Copy
            TxtTCityCode.AgHelpDataSet(0, TC1.Top + Tp1.Top, TC1.Left + Tp1.Left) = TxtCityCode.AgHelpDataSet.Copy
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd        
        BlankText()
        DispText(True)

        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode

        If AgL.VNull(DtSch_Enviro.Rows(0)("IsAutoAcManualCode")) Then
            TxtManualCode.Text = FunGetManualCode()
            TxtManualCodePrefix.Visible = True
            lblManualCodePrefix.Visible = True
            TxtManualCodeSr.Visible = True
            lblManualCodeSr.Visible = True

        Else
            TxtManualCodePrefix.Visible = False
            lblManualCodePrefix.Visible = False
            TxtManualCodeSr.Visible = False
            lblManualCodeSr.Visible = False
        End If

        If TxtManualCode.Enabled Then
            TxtManualCode.Focus()
        Else
            TxtFirstName.Focus()
        End If

        If mRegistrationDocId.Trim <> "" Then
            Call ProcFillRegistrationStudentDetail()
        End If
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False, bBlnFamilyIncomeFlag As Boolean = False


        Try
            MastPos = BMBMaster.Position

            If DTMaster.Rows.Count > 0 Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then

                    mQry = "SELECT Count(*) AS Cnt " & _
                            " FROM Sch_StudentFamilyIncome I WITH (NoLock) " & _
                            " WHERE I.Student = '" & mSearchCode & "' "
                    bBlnFamilyIncomeFlag = IIf(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 1, True, False)

                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True

                    If Not bBlnFamilyIncomeFlag Then
                        AgL.Dman_ExecuteNonQry("DELETE FROM Sch_StudentFamilyIncome WHERE Student = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    End If

                    AgL.Dman_ExecuteNonQry("Delete From Sch_StudentAcademicDetail Where Subcode = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_StudentParentImage Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_Student Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From SubGroup_Image Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_StudentParentImage Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Sch_StudentAcademicDetail Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Subgroup Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    If mBlnExists_SubGroupLog Then
                        AgL.Dman_ExecuteNonQry("DELETE FROM SubGroup_Image_Log Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                        AgL.Dman_ExecuteNonQry("DELETE FROM SubGroup_Log Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    End If


                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                    AgL.ETrans.Commit()
                    mTrans = False

                    If AgL.XNull(AgL.PubImageDBName).ToString.Trim <> "" Then
                        Try
                            mQry = "Delete From SubGroup_BLOB " & _
                                    " Where SubCode = " & AgL.Chk_Text(mSearchCode) & " "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GcnImage)
                        Catch ex As Exception

                        End Try
                    End If

                    FIniMaster(1)
                    Topctrl1_tbRef()
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        If TxtManualCode.Enabled Then
            TxtManualCode.Focus()
        Else
            TxtFirstName.Focus()
        End If
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try

            AgL.PubFindQry = "Select S.SubCode As SearchCode, Sg.ManualCode As [Manual Code],  Sg.Name As [Name], " & _
                                " Ag.GroupName As [" & LblGroupCode.Text & "], " & _
                                " S.FirstName as [First Name],S.MiddleName as [Middle Name], " & _
                                " S.Lastname as [Last Name],S.Sex as [Male/Female],Sg.Fathername as [Father Name],S.MotherName as [Mother Name]" & _
                                " From  Sch_Student S With (NoLock) " & _
                                " Left join SubGroup Sg With (NoLock) On S.SubCode = Sg.SubCode " & _
                                " LEFT JOIN AcGroup Ag ON Ag.GroupCode = Sg.GroupCode " & _
                                " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "

            AgL.PubFindQryOrdBy = "[Manual Code]"


            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then
                AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
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
        Dim ds As New DataSet
        Dim strQry As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Student List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = "Select Sg.Name As [Student Name], " & _
                             " Sg.Fathername as [Father Name], " & _
                             " city.cityname as [City Name] " & _
                             " From  Sch_Student S " & _
                             " Left join SubGroup SG On S.SubCode = Sg.SubCode " & _
                             " left join city on Sg.citycode=city.citycode " & _
                             " Where 1=1 And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                             " Order By Sg.Name"

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Student List"
            mPrnHnd.TableIndex = 0
            mPrnHnd.PageSetupDialog(True)
            mPrnHnd.PrintPreview()
            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim I As Integer, Sr As Integer, bIntTotalTables As Integer
        Dim bIncomeDueObj As New Academic_ProjLib.ClsMain.Struct_StudentFamilyIncome
        Dim bStrTableName$ = ""


        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.CreateSubGroup(AgL, AgL.GCn, AgL.ECmd, AgL.Gcn_ConnectionString, mDisplayName, TxtManualCode.Text, TxtGroupCode.AgSelectedValue, mGroupNature, mNature, AgLibrary.ClsConstant.SubGroupType_Other, TxtSite_Code.AgSelectedValue)

                mQry = "UPDATE SubGroup " & _
                        " SET Name = " & AgL.Chk_Text(txtName.Text) & ", DispName = " & AgL.Chk_Text(mDisplayName) & ",	GroupCode = '" & TxtGroupCode.AgSelectedValue & "', " & _
                        " GroupNature ='" & mGroupNature & "',	Nature = '" & mNature & "',	Add1 = " & AgL.Chk_Text(TxtAdd1.Text) & ",	Add2 = " & AgL.Chk_Text(TxtAdd2.Text) & ",	 " & _
                        " CityCode = " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & ",	CountryCode =" & AgL.Chk_Text(TxtCountryCode.AgSelectedValue) & ",	PIN = " & Val(TxtPin.Text) & ",	Phone =" & AgL.Chk_Text(TxtPhone.Text) & ",	Mobile = " & AgL.Chk_Text(TxtMobile.Text) & ",		EMail = " & AgL.Chk_Text(TxtEMail.Text) & ", " & _
                        " PAN = " & AgL.Chk_Text(TxtPanNo.Text) & ", PAdd1 =  " & AgL.Chk_Text(TxtPAdd1.Text) & ",	PAdd2 =  " & AgL.Chk_Text(TxtPAdd2.Text) & ",	PCityCode = " & AgL.Chk_Text(TxtPCityCode.AgSelectedValue) & ", " & _
                        " PCountryCode = " & AgL.Chk_Text(TxtPCountryCode.AgSelectedValue) & ",	PPin = " & Val(TxtPPin.Text) & ",	PPhone = " & AgL.Chk_Text(TxtPPhone.Text) & ",	PMobile = " & AgL.Chk_Text(TxtPMobile.Text) & ",	FatherName = " & AgL.Chk_Text(TxtFatherName.Text) & ", " & _
                        " FatherNamePrefix = " & AgL.Chk_Text(TxtFatherNamePrefix.Text) & ", DOB = " & AgL.ConvertDate(TxtDOB.Text) & ", " & _
                        " MotherName =" & AgL.Chk_Text(TxtMotherName.Text) & ", " & _
                        " CommonAc = " & IIf(AgL.StrCmp(TxtCommonAc.Text, "Yes"), 1, 0) & ", " & _
                        " ManualCodePrefix=" & AgL.Chk_Text(TxtManualCodePrefix.Text) & ", " & _
                        " ManualCodeSr=" & AgL.VNull(TxtManualCodeSr.Text) & " " & _
                        " WHERE SUBcODE= '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "Insert Into SubGroup_Image(Subcode, Photo, Signature) Values('" & mSearchCode & "', Null, Null )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "INSERT INTO Sch_Student(subCode,FirstName,MiddleName,LastName,Sex,NationalityCode,Occupation, " & _
                       " MotherName,MotherNamePrefix,FamilyIncome,Religion,Category,IsInternationalStudent,PassportNo, " & _
                       " VisaExpiryDate,VisaType, BloodGroup, FatherCompany, FatherCompanyAddress, FatherDesignation, " & _
                       " MotherOccupation, MotherCompany, MotherCompanyAddress, MotherDesignation, MotherIncome, " & _
                       " TAdd1, TAdd2, TCityCode, TPin, TPhone, TMobile, LocalGuardian, FatherIncome, " & _
                       " EnglishProficiency_IELTS, EnglishProficiency_TOEFL, Englishproficiency_Others " & _
                       " ) VALUES( " & _
                       " '" & mSearchCode & "'," & AgL.Chk_Text(TxtFirstName.Text) & "," & AgL.Chk_Text(TxtMiddleName.Text) & "," & AgL.Chk_Text(TxtLastName.Text) & "," & AgL.Chk_Text(TxtSex.Text) & "," & AgL.Chk_Text(TxtNationalityCode.AgSelectedValue) & "," & AgL.Chk_Text(TxtOccupation.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtMotherName.Text) & "," & AgL.Chk_Text(TxtMotherNamePrefix.Text) & "," & Val(TxtFamilyIncome.Text) & "," & AgL.Chk_Text(TxtReligion.AgSelectedValue) & "," & AgL.Chk_Text(TxtCategory.AgSelectedValue) & "," & IIf(TxtIsInternationalStudent.Text = "Yes", 1, 0) & ", " & _
                        " " & AgL.Chk_Text(TxtPassportNo.Text) & "," & AgL.ConvertDate(TxtVisaExpiryDate.Text) & "," & AgL.Chk_Text(TxtVisaType.Text) & ", " & AgL.Chk_Text(TxtBloodGroup.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtFatherCompany.Text) & ", " & AgL.Chk_Text(TxtFatherCompanyAddress.Text) & ", " & AgL.Chk_Text(TxtFatherDesignation.Text) & ", " & AgL.Chk_Text(TxtMotherOccupation.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtMotherCompany.Text) & ", " & AgL.Chk_Text(TxtMotherCompanyAddress.Text) & ", " & AgL.Chk_Text(TxtMotherDesignation.Text) & ", " & Val(TxtMotherIncome.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtTAdd1.Text) & ", " & AgL.Chk_Text(TxtTAdd2.Text) & ", " & AgL.Chk_Text(TxtTCityCode.AgSelectedValue) & ", " & AgL.Chk_Text(TxtTPin.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtTPhone.Text) & ", " & AgL.Chk_Text(TxtTMobile.Text) & ", " & AgL.Chk_Text(TxtLocalGuardian.Text) & ", " & Val(TxtFatherIncome.Text) & ", " & _
                        " " & IIf(OptEnglishProficiency_IELTS.Checked, 1, 0) & ", " & IIf(OptEnglishProficiency_TOEFL.Checked, 1, 0) & ", " & AgL.Chk_Text(TxtEnglishProficiency_Others.Text) & " " & _
                        " ) "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "INSERT INTO Sch_StudentParentImage ( SubCode, Signature1) VALUES ('" & mSearchCode & "', Null)"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                If mRegistrationDocId.Trim <> "" Then
                    mQry = "UPDATE Sch_RegistrationStudentDetail SET Student = '" & mSearchCode & "' " & _
                            " WHERE DocId = '" & mRegistrationDocId & "' AND Student IS NULL "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If

                If mBlnExists_SubGroupLog Then
                    If AgL.FunCreateSubGroup_Log(AgL.GCn, AgL.ECmd, mSearchCode).Trim = "" Then Err.Raise(1, , "")
                End If


            Else
                If mBlnExists_SubGroupLog Then
                    bIntTotalTables = 2
                    If AgL.FunCreateSubGroup_Log(AgL.GCn, AgL.ECmd, mSearchCode).Trim = "" Then Err.Raise(1, , "")
                Else
                    bIntTotalTables = 1
                End If

                For I = 1 To bIntTotalTables

                    If mBlnExists_SubGroupLog Then
                        If I = 1 Then
                            bStrTableName = "SubGroup_Log"
                        Else
                            bStrTableName = "SubGroup"
                        End If
                    Else
                        bStrTableName = "SubGroup"
                    End If


                    mQry = "UPDATE " & bStrTableName & " SET ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & ",	Name = " & AgL.Chk_Text(txtName.Text) & ",	DispName = " & AgL.Chk_Text(mDisplayName) & ",	GroupCode = '" & TxtGroupCode.AgSelectedValue & "', " & _
                             " GroupNature ='" & mGroupNature & "',	Nature = '" & mNature & "',	Add1 = " & AgL.Chk_Text(TxtAdd1.Text) & ",	Add2 = " & AgL.Chk_Text(TxtAdd2.Text) & ",	 " & _
                             " CityCode = " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & ",	CountryCode =" & AgL.Chk_Text(TxtCountryCode.AgSelectedValue) & ",	PIN = " & Val(TxtPin.Text) & ",	Phone =" & AgL.Chk_Text(TxtPhone.Text) & ",	Mobile = " & AgL.Chk_Text(TxtMobile.Text) & ",		EMail = " & AgL.Chk_Text(TxtEMail.Text) & ", " & _
                             " PAN = " & AgL.Chk_Text(TxtPanNo.Text) & ",		PAdd1 =  " & AgL.Chk_Text(TxtPAdd1.Text) & ",	PAdd2 =  " & AgL.Chk_Text(TxtPAdd2.Text) & ",	PCityCode = " & AgL.Chk_Text(TxtPCityCode.AgSelectedValue) & ", " & _
                             " PCountryCode = " & AgL.Chk_Text(TxtPCountryCode.AgSelectedValue) & ",	PPin = " & Val(TxtPPin.Text) & ",	PPhone = " & AgL.Chk_Text(TxtPPhone.Text) & ",	PMobile = " & AgL.Chk_Text(TxtPMobile.Text) & ",	FatherName = " & AgL.Chk_Text(TxtFatherName.Text) & ", " & _
                             " FatherNamePrefix = " & AgL.Chk_Text(TxtFatherNamePrefix.Text) & ",	DOB = " & AgL.ConvertDate(TxtDOB.Text) & ", " & _
                             " MotherName =" & AgL.Chk_Text(TxtMotherName.Text) & ", " & _
                             " Sex = " & AgL.Chk_Text(TxtSex.Text) & ", " & _
                             " CommonAc = " & IIf(AgL.StrCmp(TxtCommonAc.Text, "Yes"), 1, 0) & ", " & _
                             " ManualCodePrefix=" & AgL.Chk_Text(TxtManualCodePrefix.Text) & ", " & _
                             " ManualCodeSr=" & AgL.VNull(TxtManualCodeSr.Text) & " " & _
                             " WHERE SUBcODE= '" & mSearchCode & "'"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                Next

                mQry = " UPDATE Sch_Student SET 	FirstName = " & AgL.Chk_Text(TxtFirstName.Text) & ",MiddleName = " & AgL.Chk_Text(TxtMiddleName.Text) & ",	LastName =" & AgL.Chk_Text(TxtLastName.Text) & ",	Sex = " & AgL.Chk_Text(TxtSex.Text) & "," & _
                       " NationalityCode = " & AgL.Chk_Text(TxtNationalityCode.AgSelectedValue) & ",Occupation =" & AgL.Chk_Text(TxtOccupation.AgSelectedValue) & ",MotherName =" & AgL.Chk_Text(TxtMotherName.Text) & ",	MotherNamePrefix = " & AgL.Chk_Text(TxtMotherNamePrefix.Text) & "," & _
                       " FamilyIncome =" & Val(TxtFamilyIncome.Text) & ",	Religion =" & AgL.Chk_Text(TxtReligion.AgSelectedValue) & ",	Category = " & AgL.Chk_Text(TxtCategory.AgSelectedValue) & ",	IsInternationalStudent = " & IIf(TxtIsInternationalStudent.Text = "Yes", 1, 0) & ", " & _
                       " PassportNo =" & AgL.Chk_Text(TxtPassportNo.Text) & ",	VisaExpiryDate =" & AgL.ConvertDate(TxtVisaExpiryDate.Text) & ",	VisaType = " & AgL.Chk_Text(TxtVisaType.Text) & ", 	BloodGroup = " & AgL.Chk_Text(TxtBloodGroup.Text) & ", " & _
                       " FatherCompany = " & AgL.Chk_Text(TxtFatherCompany.Text) & ", FatherCompanyAddress = " & AgL.Chk_Text(TxtFatherCompanyAddress.Text) & ", FatherDesignation = " & AgL.Chk_Text(TxtFatherDesignation.Text) & ", MotherOccupation = " & AgL.Chk_Text(TxtMotherOccupation.AgSelectedValue) & ", " & _
                       " MotherCompany = " & AgL.Chk_Text(TxtMotherCompany.Text) & ", MotherCompanyAddress = " & AgL.Chk_Text(TxtMotherCompanyAddress.Text) & ", MotherDesignation = " & AgL.Chk_Text(TxtMotherDesignation.Text) & ", MotherIncome = " & Val(TxtMotherIncome.Text) & ", " & _
                       " TAdd1 = " & AgL.Chk_Text(TxtTAdd1.Text) & ", TAdd2 = " & AgL.Chk_Text(TxtTAdd2.Text) & ", TCityCode = " & AgL.Chk_Text(TxtTCityCode.AgSelectedValue) & ", TPin = " & AgL.Chk_Text(TxtTPin.Text) & ", TPhone = " & AgL.Chk_Text(TxtTPhone.Text) & ", " & _
                       " TMobile = " & AgL.Chk_Text(TxtTMobile.Text) & ", LocalGuardian = " & AgL.Chk_Text(TxtLocalGuardian.Text) & ", FatherIncome = " & Val(TxtFatherIncome.Text) & ", Englishproficiency_Others = " & AgL.Chk_Text(TxtEnglishProficiency_Others.Text) & ",  " & _
                       " EnglishProficiency_IELTS = " & IIf(OptEnglishProficiency_IELTS.Checked, 1, 0) & ", EnglishProficiency_TOEFL = " & IIf(OptEnglishProficiency_TOEFL.Checked, 1, 0) & " " & _
                       " WHERE SubCode= '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                If mParentSignature1Flag Then
                    mQry = "INSERT INTO Sch_StudentParentImage ( SubCode, Signature1) VALUES ('" & mSearchCode & "', Null)"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If
            End If

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Sch_StudentAcademicDetail Where Subcode = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Sr = 1
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Class, I).Value <> "" Then
                        mQry = "INSERT INTO Sch_StudentAcademicDetail ( SubCode, Sr, Class, University, EnrollmentNo, YearOfPassing, Subjects, Result, TotalPercentage, PCMPercentage, Remark) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & Sr & ", " & AgL.Chk_Text(.Item(Col1Class, I).Value) & ", " & AgL.Chk_Text(.AgSelectedValue(Col1University, I)) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1EnrollmentNo, I).Value) & ", " & Val(.Item(Col1YearOfPassing, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Subjects, I).Value) & ", " & AgL.Chk_Text(.Item(Col1Result, I).Value) & ", " & _
                                " " & Val(.Item(Col1TotalPercentage, I).Value) & ", " & Val(.Item(Col1PCMPercentage, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Remark, I).Value) & ")"

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        Sr = Sr + 1
                    End If
                Next I
            End With


            'Code By Akash On Date 26-3-11
            If Val(TxtFamilyIncome.Text) > 0 Then
                With bIncomeDueObj
                    .GUID = IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), AgL.GetGUID(AgL.GcnRead).ToString, LblAsOnDate.Tag)
                    .Student = mSearchCode
                    .AsOnDate = TxtAsOnDate.Text
                    .FatherIncome = Val(TxtFatherIncome.Text)
                    .MotherIncome = Val(TxtMotherIncome.Text)
                    .FamilyIncome = Val(TxtFamilyIncome.Text)
                    .FatherOccupation = TxtOccupation.AgSelectedValue
                    .FatherCompany = TxtFatherCompany.Text
                    .FatherCompanyAddress = TxtFatherCompanyAddress.Text
                    .FatherDesignation = TxtFatherDesignation.Text
                    .MotherOccupation = TxtMotherOccupation.AgSelectedValue
                    .MotherCompany = TxtMotherCompany.Text
                    .MotherCompanyAddress = TxtMotherCompanyAddress.Text
                    .MotherDesignation = TxtMotherDesignation.Text
                    .Div_Code = AgL.PubDivCode
                    .Site_Code = TxtSite_Code.AgSelectedValue
                End With
                Call PLib.ProcSaveFamilyIncome(AgL.GCn, AgL.ECmd, Topctrl1.Mode, bIncomeDueObj)
            End If
            'End Code

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()
            mTrans = False

            Update_Picture("SubGroup_Image", "Photo", "Where Subcode = '" & mSearchCode & "'", Photo_Byte)
            Update_Picture("SubGroup_Image", "Signature", "Where Subcode = '" & mSearchCode & "'", StudentSignature_Byte)
            Update_Picture("Sch_StudentParentImage", "Signature1", "Where Subcode = '" & mSearchCode & "'", ParentSignature1_Byte)

            If mBlnExists_SubGroupLog Then
                Update_Picture("SubGroup_Image_Log", "Photo", "Where Subcode = '" & mSearchCode & "'", Photo_Byte)
                Update_Picture("SubGroup_Image_Log", "Signature", "Where Subcode = '" & mSearchCode & "'", StudentSignature_Byte)
            End If

            FIniMaster(0, 1)
            Topctrl1_tbRef()
            If Topctrl1.Mode = "Add" Then
                mRegistrationDocId = ""
                Topctrl1.LblDocId.Text = mSearchCode
                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                Topctrl1.SetDisp(True)
                MoveRec()
            End If
        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            If ex.Message.Trim <> "" Then MsgBox(ex.Message)
        End Try
    End Sub

    Sub Update_Picture(ByVal mTable As String, ByVal mColumn As String, ByVal mCondition As String, ByVal ByteArr As Byte())
        If ByteArr Is Nothing Then Exit Sub
        Dim sSQL As String = "Update " & mTable & " Set " & mColumn & "=@pic " & mCondition

        Dim cmd As SqlCommand = New SqlCommand(sSQL, AgL.GCn)
        Dim Pic As SqlParameter = New SqlParameter("@pic", SqlDbType.Image)
        Pic.Value = ByteArr
        cmd.Parameters.Add(Pic)
        cmd.ExecuteNonQuery()
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Dim I As Integer
        Dim mTransFlag As Boolean = False
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select F.*, S.* " & _
                        " From Sch_Student F " & _
                        " Left join SubGroup S On F.SubCode = S.SubCode " & _
                        " Where F.SubCode='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_code"))
                        TxtManualCode.Text = AgL.XNull(.Rows(0)("ManualCode"))
                        TxtManualCodePrefix.Text = AgL.XNull(.Rows(0)("ManualCodePrefix"))
                        TxtManualCodeSr.Text = AgL.VNull(.Rows(0)("ManualCodeSr"))

                        TxtGroupCode.AgSelectedValue = AgL.XNull(.Rows(0)("GroupCode"))
                        mGroupNature = AgL.XNull(.Rows(0)("GroupNature"))
                        mNature = AgL.XNull(.Rows(0)("Nature"))

                        TxtFirstName.Text = AgL.XNull(.Rows(0)("FirstName"))
                        TxtMiddleName.Text = AgL.XNull(.Rows(0)("MiddleName"))
                        TxtLastName.Text = AgL.XNull(.Rows(0)("LastName"))
                        TxtSex.Text = AgL.XNull(.Rows(0)("Sex"))
                        txtName.Text = AgL.XNull(.Rows(0)("Name"))
                        TxtCommonAc.Text = IIf(AgL.VNull(.Rows(0)("CommonAc")), "Yes", "No")

                        TxtNationalityCode.AgSelectedValue = AgL.XNull(.Rows(0)("NationalityCode"))
                        TxtReligion.AgSelectedValue = AgL.XNull(.Rows(0)("Religion"))
                        TxtCategory.AgSelectedValue = AgL.XNull(.Rows(0)("Category"))
                        TxtIsInternationalStudent.Text = IIf(AgL.VNull(.Rows(0)("IsInternationalStudent")), "Yes", "No")
                        TxtPassportNo.Text = AgL.XNull(.Rows(0)("PassportNo"))
                        TxtVisaExpiryDate.Text = Format(AgL.XNull(.Rows(0)("VisaExpiryDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtVisaType.Text = AgL.XNull(.Rows(0)("VisaType"))
                        TxtBloodGroup.Text = AgL.XNull(.Rows(0)("BloodGroup"))
                        TxtAdd1.Text = AgL.XNull(.Rows(0)("Add1"))
                        TxtAdd2.Text = AgL.XNull(.Rows(0)("Add2"))
                        TxtCityCode.AgSelectedValue = AgL.XNull(.Rows(0)("CityCode"))
                        TxtCountryCode.AgSelectedValue = AgL.XNull(.Rows(0)("CountryCode"))

                        TxtPanNo.Text = AgL.XNull(.Rows(0)("Pan"))
                        TxtPhone.Text = AgL.XNull(.Rows(0)("Phone"))
                        TxtPin.Text = AgL.VNull(.Rows(0)("Pin"))
                        TxtMobile.Text = AgL.XNull(.Rows(0)("Mobile"))
                        TxtEMail.Text = AgL.XNull(.Rows(0)("EMail"))
                        TxtPAdd1.Text = AgL.XNull(.Rows(0)("pAdd1"))
                        TxtPAdd2.Text = AgL.XNull(.Rows(0)("pAdd2"))
                        TxtPCityCode.AgSelectedValue = AgL.XNull(.Rows(0)("PCityCode"))
                        TxtPCountryCode.AgSelectedValue = AgL.XNull(.Rows(0)("pCountryCode"))
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
                        TxtDOB.Text = Format(AgL.XNull(.Rows(0)("DOB")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                        TxtFatherName.Text = AgL.XNull(.Rows(0)("FatherName"))
                        TxtFatherNamePrefix.Text = AgL.XNull(.Rows(0)("FatherNamePrefix"))
                        TxtMotherName.Text = AgL.XNull(.Rows(0)("MotherName"))
                        TxtMotherNamePrefix.Text = AgL.XNull(.Rows(0)("MotherNamePrefix"))


                        OptEnglishProficiency_IELTS.Checked = AgL.VNull(.Rows(0)("EnglishProficiency_IELTS"))
                        OptEnglishProficiency_TOEFL.Checked = AgL.VNull(.Rows(0)("EnglishProficiency_TOEFL"))
                        OptEnglishProficiency_Others.Checked = IIf(AgL.XNull(.Rows(0)("EnglishProficiency_Others")).ToString.Trim = "", False, True)
                        TxtEnglishProficiency_Others.Text = AgL.XNull(.Rows(0)("EnglishProficiency_Others"))


                        TxtPrepared.Text = AgL.XNull(.Rows(0)("U_Name"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                'Code By Akash On Date 28-3-11

                mQry = "SELECT Sfi.* " & _
                        " FROM Sch_StudentFamilyIncome Sfi   " & _
                        " WHERE Sfi.AsOnDate = (SELECT max(I.AsOnDate) FROM Sch_StudentFamilyIncome I " & _
                        " 					    WHERE I.Student = '" & mSearchCode & "')  " & _
                        " AND Sfi.Student = '" & mSearchCode & "' "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then

                        LblAsOnDate.Tag = AgL.XNull(.Rows(0)("GUID"))
                        TxtAsOnDate.Text = Format(AgL.XNull(.Rows(0)("AsOnDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                        TxtOccupation.AgSelectedValue = AgL.XNull(.Rows(0)("FatherOccupation"))
                        TxtFatherCompany.Text = AgL.XNull(.Rows(0)("FatherCompany"))
                        TxtFatherCompanyAddress.Text = AgL.XNull(.Rows(0)("FatherCompanyAddress"))
                        TxtFatherDesignation.Text = AgL.XNull(.Rows(0)("FatherDesignation"))

                        TxtMotherOccupation.AgSelectedValue = AgL.XNull(.Rows(0)("MotherOccupation"))
                        TxtMotherCompany.Text = AgL.XNull(.Rows(0)("MotherCompany"))
                        TxtMotherCompanyAddress.Text = AgL.XNull(.Rows(0)("MotherCompanyAddress"))
                        TxtMotherDesignation.Text = AgL.XNull(.Rows(0)("MotherDesignation"))

                        TxtFatherIncome.Text = Format(AgL.VNull(.Rows(0)("FatherIncome")), "0.00")
                        TxtMotherIncome.Text = Format(AgL.VNull(.Rows(0)("MotherIncome")), "0.00")
                        TxtFamilyIncome.Text = Format(AgL.VNull(.Rows(0)("FamilyIncome")), "0.00")
                    End If
                End With


                'End Code

                mQry = "Select Im.* " & _
                        " From SubGroup_Image Im Where Subcode='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        If Not IsDBNull(.Rows(0)("Photo")) Then
                            Photo_Byte = DirectCast(.Rows(0)("Photo"), Byte())
                            Show_Picture(PicPhoto, Photo_Byte)
                        End If

                        If Not IsDBNull(.Rows(0)("Signature")) Then
                            StudentSignature_Byte = DirectCast(.Rows(0)("Signature"), Byte())
                            Show_Picture(PicStudentSignature, StudentSignature_Byte)
                        End If
                    End If
                End With

                mQry = "Select Im.* " & _
                        " From Sch_StudentParentImage Im Where Subcode='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        If Not IsDBNull(.Rows(0)("Signature1")) Then
                            ParentSignature1_Byte = DirectCast(.Rows(0)("Signature1"), Byte())
                            Show_Picture(PicParentSignature1, ParentSignature1_Byte)
                        End If
                    End If
                End With

                mQry = "Select Ad.* " & _
                        " From Sch_StudentAcademicDetail Ad " & _
                        " Where Ad.SubCode = '" & mSearchCode & "' " & _
                        " Order By Ad.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        DGL1.RowCount = 1 : DGL1.Rows.Clear()
                        For I = 0 To .Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(Col_SNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.Item(Col1Class, I).Value = AgL.XNull(.Rows(I)("Class"))
                            DGL1.AgSelectedValue(Col1University, I) = AgL.XNull(.Rows(I)("University"))
                            DGL1.Item(Col1EnrollmentNo, I).Value = AgL.XNull(.Rows(I)("EnrollmentNo"))
                            DGL1.Item(Col1YearOfPassing, I).Value = AgL.VNull(.Rows(I)("YearOfPassing"))
                            DGL1.Item(Col1Subjects, I).Value = AgL.XNull(.Rows(I)("Subjects"))
                            DGL1.Item(Col1Result, I).Value = AgL.XNull(.Rows(I)("Result"))
                            DGL1.Item(Col1TotalPercentage, I).Value = Format(AgL.VNull(.Rows(I)("TotalPercentage")), "0.00")
                            DGL1.Item(Col1PCMPercentage, I).Value = Format(AgL.VNull(.Rows(I)("PCMPercentage")), "0.00")
                            DGL1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))
                        Next
                    End If
                End With
                Call ProcFillStudentFamilyIncomeGrid(mSearchCode)
            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                If Not AgL.StrCmp(TxtSite_Code.AgSelectedValue, AgL.PubSiteCode) Then mTransFlag = True

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
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : mDisplayName = "" : TxtCommonAc.Text = "Yes"

        PicPhoto.Image = Nothing : Photo_Byte = Nothing
        PicStudentSignature.Image = Nothing : StudentSignature_Byte = Nothing
        PicParentSignature1.Image = Nothing : ParentSignature1_Byte = Nothing

        mParentSignature1Flag = False : mBlnImprtFromExcelFlag = False

        mStruct_LibraryMaster = Nothing

        LblAsOnDate.Tag = ""

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
    End Sub

    Private Sub IsInterNation_Val()
        If TxtIsInternationalStudent.Text = "Yes" Then
            TxtPassportNo.Enabled = True
            TxtVisaType.Enabled = True
            TxtVisaExpiryDate.Enabled = True
        Else
            TxtPassportNo.Enabled = False
            TxtVisaType.Enabled = False
            TxtVisaExpiryDate.Enabled = False

            TxtPassportNo.Text = ""
            TxtVisaType.Text = ""
            TxtVisaExpiryDate.Text = ""
        End If

    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls

        TxtSite_Code.Enabled = False
        txtName.Enabled = False
        TxtPassportNo.Enabled = False
        TxtVisaType.Enabled = False
        TxtVisaExpiryDate.Enabled = False

        If AgL.VNull(DtSch_Enviro.Rows(0)("IsAutoAcManualCode")) Then
            TxtManualCode.Enabled = False
            TxtManualCodePrefix.Visible = True
            lblManualCodePrefix.Visible = True
            TxtManualCodeSr.Visible = True
            lblManualCodeSr.Visible = True
        Else
            TxtManualCodePrefix.Visible = False
            lblManualCodePrefix.Visible = False
            TxtManualCodeSr.Visible = False
            lblManualCodeSr.Visible = False
        End If

        If Topctrl1.Mode = "Edit" Then
            '<Executable Code>
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

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStrTmManualCode$ = ""
        Try
            TC1.SelectedTab = Tp1
            If AgL.RequiredField(TxtSite_Code, LblSite_Code.Text) Then Exit Function
            If AgL.RequiredField(TxtFirstName, LblFirstName.Text) Then Exit Function
            If AgL.RequiredField(TxtGroupCode, LblGroupCode.Text) Then Exit Function
            If AgL.RequiredField(TxtCommonAc, "Is Common A/c?") Then Exit Function

            AgCL.AgBlankNothingCells(DGL1)
            If mBlnImprtFromExcelFlag = False Then
                If AgL.RequiredField(TxtDOB, "DOB Date") Then Exit Function
                If Not AgL.IsValid_EMailId(TxtEMail, "Email ID") Then Exit Function

                TC1.SelectedTab = Tp2
                If AgCL.AgIsBlankGrid(DGL1, Col1Class) Then Exit Function
                If AgCL.AgIsDuplicate(DGL1, "" & Col1Class & "") Then Exit Function
            End If


            '================================================================================================================================================================
            '===================< Manual Code Create >=======================================================================================================================
            '=========================< Start >==============================================================================================================================
            '================================================================================================================================================================
            bStrTmManualCode = TxtManualCode.Text
            If TxtManualCode.Text.Trim = "" Then
                If mBlnImprtFromExcelFlag Then
                    TxtManualCode.Text = FunGetManualCode()
                Else
                    If AgL.VNull(DtSch_Enviro.Rows(0)("IsAutoAcManualCode")) Then
                        TxtManualCode.Text = FunGetManualCode()
                    End If
                End If
            Else
                If AgL.VNull(DtSch_Enviro.Rows(0)("IsAutoAcManualCode")) Then
                    If Topctrl1.Mode = "Add" Then
                        TxtManualCode.Text = FunGetManualCode()

                        If bStrTmManualCode <> TxtManualCode.Text And bStrTmManualCode.Trim <> "" Then
                            'MsgBox("" & LblManualCode.Text & " : " & bStrTmManualCode & " Already Exist New " & LblManualCode.Text & " Alloted : " & TxtManualCode.Text & "")
                        End If
                    End If
                End If
            End If
            If AgL.RequiredField(TxtManualCode, LblManualCode.Text) Then Exit Function
            '================================================================================================================================================================
            '===================< Manual Code Create >=======================================================================================================================
            '=========================< End >==============================================================================================================================
            '================================================================================================================================================================



            TC1.SelectedTab = Tp1
            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where ManualCode='" & TxtManualCode.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where ManualCode='" & TxtManualCode.Text & "' And SubCode<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function

                AgL.ECmd = AgL.Dman_Execute("Select IsNull(count(*),0) Cnt From Sch_StudentParentImage Where SubCode = '" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then mParentSignature1Flag = False Else mParentSignature1Flag = True
            End If

            mDisplayName = TxtFirstName.Text + IIf(TxtMiddleName.Text.Trim = "", "", Space(1)) + TxtMiddleName.Text + Space(1) + TxtLastName.Text
            txtName.Text = mDisplayName + Space(1) + "{" + TxtManualCode.Text + "}"


            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Function FunGetManualCode() As String
        Dim bStrReturn As String = ""
        Try

            mQry = "SELECT IsNull(Left(H.ManualCode,12),'') AS Prefix " & _
                " FROM SiteMast H WITH (NoLock) " & _
                " WHERE H.Code = " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & " "

            TxtManualCodePrefix.Text = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar)

            mQry = "SELECT IsNull(Max(Convert(NUMERIC,LEFT(H.ManualCodeSr,8))),0) AS MaxId " & _
                  " FROM SubGroup H WITH (NoLock) " & _
                  " WHERE H.ManualCodePrefix = " & AgL.Chk_Text(TxtManualCodePrefix.Text) & " "

            TxtManualCodeSr.Text = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) + 1

            bStrReturn = TxtManualCodePrefix.Text & TxtManualCodeSr.Text


        Catch ex As Exception
            bStrReturn = ""
            MsgBox(ex.Message)
        Finally
            FunGetManualCode = bStrReturn
        End Try
    End Function
    Private Sub ProcAssignValuesToStructLibraryMember(ByRef bTempStruct_LibraryMaster As Academic_ProjLib.ClsMain.Struct_LibraryMaster, ByVal bEntryMode As String)
        With bTempStruct_LibraryMaster
            .Member_Name = txtName.Text
            .Member_Type = "Student"
            .Father_Name = TxtFatherName.Text
            .Student = mSearchCode
            .Sex = TxtSex.Text
            .U_Name = AgL.PubUserName
            .U_EntDt = AgL.PubLoginDate
            .U_AE = AgL.MidStr(bEntryMode, 0, 1)

            If Topctrl1.Mode = "Add" Then
                .Member_Code = PLib.FunGetLibraryMemberCode(AgL.GcnLibrary)
            Else
                mQry = "Select Member_Code From " & AgL.PubLibraryDbName & ".dbo.Library_Member Where Student = '" & mSearchCode & "' "
                .Member_Code = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnLibrary).ExecuteScalar)
            End If
        End With
    End Sub


    Private Sub PictureBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicPhoto.DoubleClick, PicStudentSignature.DoubleClick, PicParentSignature1.DoubleClick
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Select Case sender.Name
            Case PicPhoto.Name
                AgL.GetPicture(sender, Photo_Byte)

            Case PicStudentSignature.Name
                AgL.GetPicture(sender, StudentSignature_Byte)

            Case PicParentSignature1.Name
                AgL.GetPicture(sender, ParentSignature1_Byte)
        End Select
    End Sub

    Sub Show_Picture(ByVal PicBox As PictureBox, ByVal B As Byte())
        Dim Mem As MemoryStream
        Dim Img As Image

        Mem = New MemoryStream(B)
        Img = Image.FromStream(Mem)
        PicBox.Image = Img
    End Sub

    Private Sub TxtIsInternationalStudent_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtIsInternationalStudent.Validating, TxtFirstName.Validating, TxtMiddleName.Validating, TxtLastName.Validating, TxtManualCode.Validating, _
        TxtGroupCode.Validating, TxtFatherIncome.Validating, TxtMotherIncome.Validating, TxtFamilyIncome.Validating, _
        OptEnglishProficiency_TOEFL.Validating, OptEnglishProficiency_Others.Validating, OptEnglishProficiency_IELTS.Validating, TxtEnglishProficiency_Others.Validating, TxtManualCodePrefix.Validating, TxtManualCodeSr.Validating

        Try
            Select Case sender.name
                Case TxtGroupCode.Name
                    Call ProcValidatingControl(sender)

                Case TxtIsInternationalStudent.Name
                    Call IsInterNation_Val()

                Case TxtFirstName.Name, TxtLastName.Name, TxtMiddleName.Name, TxtManualCode.Name
                    If AgL.StrCmp(sender.Name, TxtManualCode.Name) Then
                        If TxtManualCode.Text.Trim = "" Then
                            TxtManualCode.Text = FunGetManualCode()
                        End If
                    End If
                    txtName.Text = TxtFirstName.Text + IIf(TxtMiddleName.Text.Trim = "", "", Space(1)) + TxtMiddleName.Text + Space(1) + TxtLastName.Text + Space(1) + "{" + TxtManualCode.Text + "}"

                Case TxtEnglishProficiency_Others.Name, OptEnglishProficiency_Others.Name
                    If OptEnglishProficiency_Others.Checked = False Then
                        TxtEnglishProficiency_Others.ReadOnly = True
                        TxtEnglishProficiency_Others.Text = ""
                    Else
                        TxtEnglishProficiency_Others.ReadOnly = False
                    End If

                Case TxtManualCodePrefix.Name, TxtManualCodeSr.Name
                    TxtManualCode.Text = TxtManualCodePrefix.Text & TxtManualCodeSr.Text

            End Select

            If TxtAsOnDate.Text.Trim = "" Then TxtAsOnDate.Text = AgL.PubLoginDate

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

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

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = DGL1.CurrentCell.RowIndex
            mColumnIndex = DGL1.CurrentCell.ColumnIndex

            If DGL1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL1.Item(mColumnIndex, mRowIndex).Value = ""
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
                Case Col1University
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

        Call Calculation()
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        TxtFamilyIncome.Text = Format(Val(TxtFatherIncome.Text) + Val(TxtMotherIncome.Text), "0.00")

        'With DGL1
        '    For I = 0 To .Rows.Count - 1
        '        If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""

        '        If .Item(Col1Fee, I).Value <> "" Then
        '            .Item(Col1NetAmount, I).Value = Format(Val(.Item(Col1Amount, I).Value) - Val(.Item(Col1Discount, I).Value), "0.00")
        '        End If
        '    Next
        'End With

    End Sub

    Private Sub ProcFillRegistrationStudentDetail()
        If Topctrl1.Mode = "Browse" Then Exit Sub
        If mRegistrationDocId.Trim = "" Then Exit Sub
        Dim DtTemp As DataTable = Nothing
        Dim DsTemp As DataSet = Nothing, DTbl As DataTable = Nothing
        Dim I As Integer, bIntJ As Integer = 0

        Try
            mQry = "Select Sd.*  " & _
                    " From Sch_RegistrationStudentDetail Sd " & _
                    " Where Sd.DocId = '" & mRegistrationDocId & "' "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
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

                TxtAsOnDate.Text = mAsOnDate
            End With

            mQry = "Select Ad.* " & _
                       " From Sch_RegistrationAcademicDetail Ad " & _
                       " Where Ad.DocId = '" & mRegistrationDocId & "' " & _
                       " Order By Ad.Sr "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    DGL1.RowCount = 1 : DGL1.Rows.Clear()
                    For I = 0 To .Rows.Count - 1
                        DGL1.Rows.Add()
                        DGL1.Item(Col_SNo, I).Value = AgL.VNull(.Rows(I)("Sr"))
                        DGL1.Item(Col1Class, I).Value = AgL.XNull(.Rows(I)("Class"))
                        DGL1.AgSelectedValue(Col1University, I) = AgL.XNull(.Rows(I)("University"))
                        DGL1.Item(Col1EnrollmentNo, I).Value = AgL.XNull(.Rows(I)("EnrollmentNo"))
                        DGL1.Item(Col1YearOfPassing, I).Value = AgL.VNull(.Rows(I)("YearOfPassing"))
                        DGL1.Item(Col1Subjects, I).Value = AgL.XNull(.Rows(I)("Subjects"))
                        DGL1.Item(Col1Result, I).Value = AgL.XNull(.Rows(I)("Result"))
                        DGL1.Item(Col1TotalPercentage, I).Value = Format(AgL.VNull(.Rows(I)("TotalPercentage")), "0.00")
                        DGL1.Item(Col1PCMPercentage, I).Value = Format(AgL.VNull(.Rows(I)("PCMPercentage")), "0.00")
                        DGL1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))
                    Next
                End If
            End With

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub ProcFillStudentFamilyIncomeGrid(ByVal bStrStudentCode As String)
        Dim DsTemp As DataSet = Nothing
        Dim I As Integer

        DGL2.RowCount = 1 : DGL2.Rows.Clear()

        If bStrStudentCode.Trim <> "" Then
            mQry = "Select Si.* " & _
                    " From Sch_StudentFamilyIncome Si " & _
                    " Where Si.Student = " & AgL.Chk_Text(bStrStudentCode) & " " & _
                    " Order By Si.AsOnDate "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    DGL2.RowCount = 1 : DGL2.Rows.Clear()
                    For I = 0 To .Rows.Count - 1
                        DGL2.Rows.Add()
                        DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count
                        DGL2.Item(Col2AsOnDate, I).Value = Format(AgL.XNull(.Rows(I)("AsOnDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        DGL2.AgSelectedValue(Col2FatherOccupation, I) = AgL.XNull(.Rows(I)("FatherOccupation"))
                        DGL2.AgSelectedValue(Col2MotherOccupation, I) = AgL.XNull(.Rows(I)("MotherOccupation"))

                        DGL2.Item(Col2FatherCompany, I).Value = AgL.XNull(.Rows(I)("FatherCompany"))
                        DGL2.Item(Col2FatherCompanyAddress, I).Value = AgL.XNull(.Rows(I)("FatherCompanyAddress"))
                        DGL2.Item(Col2FatherDesignation, I).Value = AgL.XNull(.Rows(I)("FatherDesignation"))

                        DGL2.Item(Col2MotherCompany, I).Value = AgL.XNull(.Rows(I)("MotherCompany"))
                        DGL2.Item(Col2MotherCompanyAddress, I).Value = AgL.XNull(.Rows(I)("MotherCompanyAddress"))
                        DGL2.Item(Col2MotherDesignation, I).Value = AgL.XNull(.Rows(I)("MotherDesignation"))

                        DGL2.Item(Col2FatherIncome, I).Value = Format(AgL.VNull(.Rows(I)("FatherIncome")), "0.00")
                        DGL2.Item(Col2MotherIncome, I).Value = Format(AgL.VNull(.Rows(I)("MotherIncome")), "0.00")
                        DGL2.Item(Col2FamilyIncome, I).Value = Format(AgL.VNull(.Rows(I)("FamilyIncome")), "0.00")
                    Next
                End If
            End With
        End If

        If DsTemp IsNot Nothing Then DsTemp.Dispose()
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub BtnImprtFromExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnImprtFromExcel.Click
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim FW As System.IO.StreamWriter = New System.IO.StreamWriter("C:\ImportLog.Txt", False, System.Text.Encoding.Default)
        Dim StrErrLog As String = ""
        Dim DrTemp As DataRow() = Nothing


        mQry = "                  Select '' as Srl, 'Manual Code' as [Field Name],'Text' as [Data Type], 20 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'First Name' as [Field Name],'Text' as [Data Type], 49 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Middle Name' as [Field Name],'Text' as [Data Type], 24 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Last Name' as [Field Name],'Text' as [Data Type], 25 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Account Group' as [Field Name],'Text' as [Data Type], 50 as [Length], 'Yes' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Address Row1' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Address Row2' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'City' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'PIN' as [Field Name],'Text' as [Data Type], 6 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Phone' as [Field Name],'Text' as [Data Type], 35 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Mobile' as [Field Name],'Text' as [Data Type], 35 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'EMail' as [Field Name],'Text' as [Data Type], 40 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Sex' as [Field Name],'Text' as [Data Type], 6 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'DOB' as [Field Name],'DATETIME' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Religion' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Category' as [Field Name],'Text' as [Data Type], 20 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Father Name' as [Field Name],'Text' as [Data Type], 100 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Mother Name' as [Field Name],'Text' as [Data Type], 100 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Father Occupation' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Mother Occupation' as [Field Name],'Text' as [Data Type], 50 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Father Income' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Mother Income' as [Field Name],'NUMBER' as [Data Type], 0 as [Length], 'No' As [Mandatory] "
        mQry = mQry + " Union All Select '' as Srl, 'Income Date' as [Field Name],'DATETIME' as [Data Type], 0 as [Length], 'No' As [Mandatory] "


        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
        Dim ObjFrmImport As New FrmImportFromExcel
        ObjFrmImport.LblTitle.Text = "Student Import"
        ObjFrmImport.Dgl1.DataSource = DtTemp
        ObjFrmImport.ShowDialog()

        If Not AgL.StrCmp(ObjFrmImport.UserAction, "OK") Then Exit Sub

        DtTemp = ObjFrmImport.P_DsExcelData.Tables(0)
        For I = 0 To DtTemp.Rows.Count - 1
            Topctrl1.FButtonClick(0)

            mBlnImprtFromExcelFlag = True

            TxtManualCode.Text = AgL.XNull(DtTemp.Rows(I)("Manual Code"))
            TxtFirstName.Text = AgL.XNull(DtTemp.Rows(I)("First Name"))
            TxtMiddleName.Text = AgL.XNull(DtTemp.Rows(I)("Middle Name"))
            TxtLastName.Text = AgL.XNull(DtTemp.Rows(I)("Last Name"))

            mDisplayName = TxtFirstName.Text + IIf(TxtMiddleName.Text.Trim = "", "", Space(1)) + TxtMiddleName.Text + Space(1) + TxtLastName.Text
            txtName.Text = mDisplayName + Space(1) + "{" + TxtManualCode.Text + "}"


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
            If Val(TxtFamilyIncome.Text) > 0 And TxtAsOnDate.Text.Trim = "" Then
                If AgL.XNull(DtTemp.Rows(I)("Income Date")).ToString.Trim = "" Then
                    TxtAsOnDate.Text = AgL.PubLoginDate
                Else
                    TxtAsOnDate.Text = Format(AgL.XNull(DtTemp.Rows(I)("Income Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                End If
            End If

            If AgL.XNull(DtTemp.Rows(I)("Account Group")).ToString.Trim = "" Then
                TxtGroupCode.AgSelectedValue = AgL.XNull(DtSch_Enviro.Rows(0)("AcGroup_Student"))
            Else
                DrTemp = TxtGroupCode.AgHelpDataSet.Tables(0).Select("Name = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Account Group"))) & "")
                If DrTemp.Length > 0 Then
                    TxtGroupCode.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                End If
                DrTemp = Nothing
            End If
            Call ProcValidatingControl(TxtGroupCode)


            If AgL.XNull(DtTemp.Rows(I)("City")).ToString.Trim <> "" Then
                DrTemp = TxtCityCode.AgHelpDataSet.Tables(0).Select("Name = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("City"))) & "")
                If DrTemp.Length > 0 Then
                    TxtCityCode.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                Else
                    LblCityCode.Tag = mObjClsMain.FunCreateCity(AgL.XNull(DtTemp.Rows(I)("City")), AgL.GCn)
                    Call IniCityHelp()
                    TxtCityCode.AgSelectedValue = AgL.XNull(LblCityCode.Tag)
                End If
                DrTemp = Nothing
            End If

            If AgL.XNull(DtTemp.Rows(I)("Religion")).ToString.Trim <> "" Then
                DrTemp = TxtReligion.AgHelpDataSet.Tables(0).Select("Name = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Religion"))) & "")
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
                DrTemp = TxtOccupation.AgHelpDataSet.Tables(0).Select("Name = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Father Occupation"))) & "")
                If DrTemp.Length > 0 Then
                    TxtOccupation.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                End If
                DrTemp = Nothing
            End If

            If AgL.XNull(DtTemp.Rows(I)("Mother Occupation")).ToString.Trim <> "" Then
                DrTemp = TxtMotherOccupation.AgHelpDataSet.Tables(0).Select("Name = " & AgL.Chk_Text(AgL.XNull(DtTemp.Rows(I)("Mother Occupation"))) & "")
                If DrTemp.Length > 0 Then
                    TxtMotherOccupation.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                End If
                DrTemp = Nothing
            End If

            ''===========< Finally >==============
            Topctrl1.FButtonClick(13)
            ''===========< ******* >==============
        Next
        If StrErrLog <> "" Then
            MsgBox(StrErrLog)
        Else
            MsgBox("Import Process Completed.", MsgBoxStyle.Information, Me.Text)
        End If


        FW.Close()

        mBlnImprtFromExcelFlag = False

        ''======< At Last Move To Browse Mode >=======
        Topctrl1.FButtonClick(14, True)
    End Sub

    Private Sub ProcValidatingControl(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtGroupCode.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    mGroupNature = ""
                    mNature = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        mGroupNature = AgL.XNull(DrTemp(0)("GroupNature"))
                        mNature = AgL.XNull(DrTemp(0)("Nature"))
                    End If
                End If
                DrTemp = Nothing

        End Select
    End Sub
End Class
