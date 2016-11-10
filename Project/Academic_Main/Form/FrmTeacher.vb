Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmTeacher
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = "", mDisplayName As String = ""
    Dim mGroupNature As String = "", mNature As String = ""
    Dim Photo_Byte As Byte(), StudentSignature_Byte As Byte()

    Dim mBlnIsTransportMemberExists As Boolean = False
    Dim mBlnIsMessMemberExists As Boolean = False
    Dim mBlnIsLibraryMemberExists As Boolean = False
    Dim mBlnExists_SubGroupLog As Boolean = False

    Dim mObjClsMain As New ClsMain(AgL, PLib)
    Dim mObjStructLibraryMember As ClsMain.StructLibraryMember = Nothing
    Dim mObjStructTransportMember As ClsMain.StructTransportMember = Nothing
    Dim mObjStructMessMember As ClsMain.StructMessMember = Nothing

    Private Const Col_SNo As Byte = 0
    Public WithEvents DGL1 As New AgControls.AgDataGrid
    Private Const Col1Class As Byte = 1
    Private Const Col1University As Byte = 2
    Private Const Col1Institute As Byte = 3
    Private Const Col1EnrollmentNo As Byte = 4
    Private Const Col1YearOfPassing As Byte = 5
    Private Const Col1Subjects As Byte = 6
    Private Const Col1Result As Byte = 7
    Private Const Col1TotalPercentage As Byte = 8
    Private Const Col1MeritPercentage As Byte = 9
    Private Const Col1Learning As Byte = 10
    Private Const Col1Specialization As Byte = 11
    Private Const Col1Remark As Byte = 12


    Public WithEvents DGL2 As New AgControls.AgDataGrid
    Private Const Col2SubjectCode As Byte = 1
    Private Const Col2SubjectType As Byte = 2


    Public WithEvents DGL3 As New AgControls.AgDataGrid
    Protected Const Col3Description As String = "Document"
    Protected Const Col3BtnAttachment As String = ""
    Protected Const Col3ByteArray As String = "Byte Array"
    Protected Const Col3FileName As String = "File Name"

    Dim _StrMasterType$ = ""
    Dim mFrmObjTransportInfo As Form = Nothing
    Dim FormLocation As New System.Drawing.Point(0, 0)
    Public Property MasterType() As String
        Get
            Return _StrMasterType
        End Get
        Set(ByVal value As String)
            _StrMasterType = value
        End Set
    End Property

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub FrmTeacher_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

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
            .AddAgTextColumn(DGL1, "Dgl1Class", 120, 50, "Class/Standard", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1University", 150, 50, "Board/University", True, False, False)
            .AddAgTextColumn(DGL1, "Col1Institute", 80, 100, "Institute Name ", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1EnrollmentNo", 100, 20, "Enrollment No", True, False, False)
            .AddAgNumberColumn(DGL1, "Dgl1YearOfPassing", 50, 4, 0, False, "Year", True, False, True)
            .AddAgTextColumn(DGL1, "Dgl1Subjects", 120, 255, "Subjects", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1Result", 60, 20, "Result", True, False, False)
            .AddAgNumberColumn(DGL1, "Dgl1TotalPercentage", 50, 2, 2, False, "Total %", True, False, True)
            .AddAgNumberColumn(DGL1, "Dgl1MeritPercentage", 40, 2, 2, False, "% For Merit", False, False, True)
            .AddAgTextColumn(DGL1, "Dgl1Learning", 80, 255, "Learning", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1Specialization", 80, 20, "Specialization", True, False, False)
            .AddAgTextColumn(DGL1, "Dgl1Remark", 80, 100, "Remark", True, False, False)

            'Col1Institute
        End With
        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AgSkipReadOnlyColumns = True

        ''==============================================================================
        ''================< Subject Data Grid >========================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL2, "DGL2SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL2, "DGL2Subject", 350, 73, "Subject", True, False, False)
            .AddAgTextColumn(DGL2, "DGL2SubjectType", 80, 20, "Subject Type", True, True, False)
        End With
        AgL.AddAgDataGrid(DGL2, Pnl2)
        DGL2.ColumnHeadersHeight = 40
        DGL2.AgSkipReadOnlyColumns = True

        ''==============================================================================
        ''================< Document Data Grid >=============================================
        ''==============================================================================
        With AgCL
            .AddAgTextColumn(DGL3, "DGL3SNo", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(DGL3, Col3Description, 250, 255, Col3Description, True, False, False)
            .AddAgButtonColumn(DGL3, Col3BtnAttachment, 40, Col3BtnAttachment, True, False, , , , "Webdings", 10, "6")
            .AddAgTextColumn(DGL3, Col3FileName, 150, 255, Col3FileName, True, True, False)
            .AddAgImageColumn(DGL3, Col3ByteArray, 100, Col3ByteArray, False, True, False)
        End With
        AgL.AddAgDataGrid(DGL3, Pnl3)
        DGL3.AgSkipReadOnlyColumns = True


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
            _StrMasterType = Academic_ProjLib.ClsMain.MasterType.Teacher

            mBlnExists_SubGroupLog = AgL.IsTableExist("SubGroup_Log", AgL.GCn)

            TxtLibraryMemberType.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Library
            LblLibraryMemberType.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Library

            TxtlibrarySite.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Library
            lblLibrarySite.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Library

            TxtIsTransport.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Transport
            lblIsTransport.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Transport

            TxtIsMess.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Mess
            lblIsMess.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Mess
            txtMessJoinDt.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Mess
            lblMessjoinDt.Visible = Academic_ProjLib.ClsMain.IsModuleActive_Mess

            AgL.WinSetting(Me, 660, 940, 0, 0)
            AgL.GridDesign(DGL1)
            AgL.GridDesign(DGL2)
            AgL.GridDesign(DGL3)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            Topctrl1.ChangeAgGridState(DGL2, False)
            Topctrl1.ChangeAgGridState(DGL3, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "Select E.Subcode As SearchCode " & _
                " From Pay_Employee E " & _
                " Left Join SubGroup Sg On Sg.SubCode = E.SubCode " & _
                " Where E.MasterType = " & AgL.Chk_Text(MasterType) & " And " & _
                " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                   " Where 1=1 Order By Name"
            TxtSite_Code.AgHelpDataSet(0, Tc2.Top + TpPersonal.Top, Tc2.Left + TpPersonal.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                  " Where 1=1 and isnull(IsLibrary,'')<>0 Order By Name"
            TxtlibrarySite.AgHelpDataSet(0, Tc2.Top + TpPersonal.Top, Tc2.Left + TpPersonal.Left) = AgL.FillData(mQry, AgL.GCn)


            mQry = "Select SubCode  As Code, ManualCode As Name From SubGroup " & _
                "  Order By ManualCode"
            TxtManualCode.AgHelpDataSet(0, Tc2.Top + TpPersonal.Top, Tc2.Left + TpPersonal.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT city.CityCode AS code,City.CityName AS Name,State.State_Desc AS [State]," & _
                   " Country.Name AS Country FROM City " & _
                   " LEFT JOIN State ON city.State_Code=State.State_Code " & _
                   " LEFT JOIN Country ON State.CountryCode=Country.Code Order by  city.cityname "
            TxtCityCode.AgHelpDataSet(0, Tc2.Top + TpPersonal.Top, Tc2.Left + TpPersonal.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select  Code  As Code, ManualCode As Name From Sch_Category " & _
                      "  Order By Description"
            TxtCategory.AgHelpDataSet(0, Tc2.Top + TpPersonal.Top, Tc2.Left + TpPersonal.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select  Code  As Code, Description As Name From Sch_Religion " & _
               "  Order By Description"
            TxtReligion.AgHelpDataSet(0, Tc2.Top + TpPersonal.Top, Tc2.Left + TpPersonal.Left) = AgL.FillData(mQry, AgL.GCn)

            AgCL.IniAgHelpList(TxtSex, "Male,Female")
            AgCL.IniAgHelpList(TxtSalaryMode, "Cash,Bank")

            AgCL.IniAgHelpList(TxtBloodGroup, "A+,A-,B+,B-,AB+,AB-,O+,O-")

            mQry = "SELECT DISTINCT FatherNamePrefix AS code,FatherNamePrefix AS Name FROM " & _
                  " SubGroup WHERE isnull(FatherNamePrefix,'')<>'' order by FatherNamePrefix "
            TxtFatherNamePrefix.AgHelpDataSet(0, Tc2.Top + TpPersonal.Top, Tc2.Left + TpPersonal.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT A.GroupCode AS Code, A.GroupName AS Name, A.GroupNature , A.Nature  " & _
                    " FROM AcGroup A " & _
                    " WHERE LEFT(MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ")='" & AgLibrary.ClsConstant.MainGRCodeSundryCreditors & "' AND " & _
                    " MainGrLen > " & AgLibrary.ClsConstant.MainGRLenSundryCreditors & " AND AliasYn = 'N'"
            TxtGroupCode.AgHelpDataSet(2, Tc2.Top + TpPersonal.Top, Tc2.Left + TpPersonal.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code , S.Description AS Subject, S.SubjectType [Subject Type] FROM Sch_Subject S  ORDER BY S.Description "
            DGL2.AgHelpDataSet(Col2SubjectCode, , Tc1.Top + Tp1.Top, Tc1.Left + Tp1.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT U.Code , U.ManualCode [Board/University] FROM Sch_University U ORDER BY U.ManualCode "
            DGL1.AgHelpDataSet(Col1University, , Tc1.Top + Tp2.Top, Tc1.Left + Tp2.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT P.Code AS Code, P.ManualCode AS Programme FROM Sch_Programme P"
            TxtProgramme.AgHelpDataSet(0, Tc2.Top + TpPersonal.Top, Tc2.Left + TpPersonal.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT S.Code, S.ManualCode AS Name FROM Sch_Stream S ORDER BY S.ManualCode"
            TxtStream.AgHelpDataSet(0, Tc2.Top + TpPersonal.Top, Tc2.Left + TpPersonal.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT P.Code, P.Description AS Name FROM Sch_ProgrammeNature P ORDER BY P.Description"
            TxtProgrammeNature.AgHelpDataSet(0, Tc2.Top + TpOthers.Top, Tc2.Left + TpOthers.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT E.Designation AS Code, E.Designation FROM Pay_Employee E WHERE E.Designation IS NOT NULL"
            TxtDesignation.AgHelpDataSet(0, Tc2.Top + TpOthers.Top, Tc2.Left + TpOthers.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT DISTINCT E.CommonSubject AS Code, E.CommonSubject As Name FROM Pay_Employee E WHERE IsNull(E.CommonSubject,'') <> '' Order By E.CommonSubject "
            TxtCommonSubject.AgHelpDataSet(0, Tc2.Top + TpOthers.Top, Tc2.Left + TpOthers.Left) = AgL.FillData(mQry, AgL.GCn)


            mQry = "SELECT U.USER_NAME AS Code, U.USER_NAME AS Name, " & _
                    " CASE WHEN IsNull(U.Admin,'N')  = 'Y' THEN 'Yes' ELSE 'No' END AS IsAdmin, " & _
                    " CASE WHEN IsNull(U.IsActive,1)  <> 0 THEN 'Yes' ELSE 'No' END AS IsActive " & _
                    " FROM UserMast U "
            TxtLogInUser.AgHelpDataSet(2, Tc2.Top + Tp1.Top, Tc2.Left + Tp1.Left) = AgL.FillData(mQry, AgL.ECompConn)

            AgCL.IniAgHelpList(TxtShift, "1st Shift,2nd Shift")
            AgCL.IniAgHelpList(TxtPayScale, "Consolidated,5th Pay Scale,6th Pay Scale")
            AgCL.IniAgHelpList(TxtAppointmentType, "Regular,Adhoc,Contract")

            mQry = "SELECT T.Code, T.Description, " & _
                    " CASE WHEN IsNull(T.IsDeleted,0) <> 0 THEN 'Yes' ELSE 'No' END AS IsDeleted " & _
                    " FROM Lib_MemberType T With (NoLock) Where " & AgL.PubSiteCondition("T.Site_Code", AgL.PubSiteCode) & "" & _
                    " ORDER BY T.Description "
            TxtLibraryMemberType.AgHelpDataSet(1, Tc2.Top + TpPersonal.Top, Tc2.Left + TpPersonal.Left) = AgL.FillData(mQry, AgL.GcnRead)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        BlankText()
        DispText(True)
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False


        Try
            MastPos = BMBMaster.Position


            If DTMaster.Rows.Count > 0 Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then

                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True

                    ''==========================================================================================================================================
                    ''==================================< Delete From Library Member Start >====================================================================
                    ''==========================================================================================================================================
                    AgL.Dman_ExecuteNonQry("Delete From Lib_Member Where SubCode = " & AgL.Chk_Text(mSearchCode) & "", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Lib_Member_Log Where SubCode = " & AgL.Chk_Text(mSearchCode) & "", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Tp_Member Where SubCode = " & AgL.Chk_Text(mSearchCode) & "", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Tp_Member_Log Where SubCode = " & AgL.Chk_Text(mSearchCode) & "", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Mess_Member Where SubCode = " & AgL.Chk_Text(mSearchCode) & "", AgL.GCn, AgL.ECmd)
                    ''==========================================================================================================================================
                    ''==========================================================================================================================================
                    ''==================================< Delete From Library Member End >====================================================================
                    ''==========================================================================================================================================

                    AgL.Dman_ExecuteNonQry("Delete From Pay_TeacherSubject Where Subcode = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Pay_EmployeeAcademicDetail Where Subcode = '" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Pay_Employee Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From SubGroup_Image Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Subgroup Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From SubGroup_Log Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
                    AgL.ETrans.Commit()
                    mTrans = False

                    If AgL.XNull(AgL.PubImageDBName).ToString.Trim <> "" Then
                        mQry = "Delete From SubGroup_BLOB " & _
                                " Where SubCode = " & AgL.Chk_Text(mSearchCode) & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GcnImage)
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
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try

            AgL.PubFindQry = "Select E.SubCode As SearchCode, Sg.DispName As [Employee Name], Sg.ManualCode As [" & LblManualCode.Text & "],  " & _
                                " Case When IsNull(E.IsTeachingStaff,0) <> 0 Then 'Yes' Else 'No' End As [" & LblIsTeachingStaff.Text & "]," & _
                                " E.FirstName as [First Name],E.MiddleName as [Middle Name], E.Lastname as [Last Name], " & _
                                " E.Sex as [Male/Female],Sg.Fathername as [Father Name], " & _
                                " E.MotherName, E.Designation, E.Shift,  E.SalaryMode, E.PayScale, Sg.LogInUser " & _
                                " From  Pay_Employee E " & _
                                " Left join SubGroup Sg On E.SubCode = Sg.SubCode " & _
                                " Where E.MasterType = " & AgL.Chk_Text(MasterType) & " And " & _
                                " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""

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
            AgL.PubReportTitle = "Teacher List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = "Select Sg.Name As [Employee Name], " & _
                             " Sg.Fathername as [Father Name], " & _
                             " city.cityname as [City Name], " & _
                             " Case When IsNull(E.IsTeachingStaff,0) <> 0 Then 'Yes' Else 'No' End As [" & LblIsTeachingStaff.Text & "] " & _
                             " From  Pay_Employee E " & _
                             " Left join SubGroup Sg On E.SubCode = Sg.SubCode " & _
                             " left join city on Sg.citycode=city.citycode " & _
                             " Where IsNull(E.IsTeachingStaff,0) <> 0 And " & _
                             " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " " & _
                             " Order By Sg.Name"

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Teacher List"
            mPrnHnd.TableIndex = 0
            mPrnHnd.PageSetupDialog(True)
            mPrnHnd.PrintPreview()
            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim I As Integer, Sr As Integer, bIntTotalTables% = 0
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

                mQry = "Insert Into SubGroup_Image(Subcode, Photo, Signature) Values('" & mSearchCode & "', Null, Null )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "INSERT INTO Pay_Employee ( SubCode, MasterType, FirstName, MiddleName, LastName, DateOfJoin, DateOfResign, " & _
                        " ResignRemark, Sex, BloodGroup, Religion, Category, IsTeachingStaff, " & _
                        " MotherName, Designation, Shift, ProgrammeNature, SalaryMode, PayScale, " & _
                        " WorkExperience, TeachingExperience, ResearchExperience, IndustryExperience, " & _
                        " BankAcNo, BankName, BankBranch, IfscCode, TotalPGProjectsGuided, TotalDoctorateProjectsGuided, " & _
                        " TotalPapersPublishedInNationalJournals, TotalPapersPublishedInInternationalJournals, " & _
                        " TotalBooksPublished, TotalInternationalConferencesAttended, TotalNationalConferencesAttended, " & _
                        " TotalPapersInNationalConference, TotalPapersInInternationalConference, " & _
                        " TotalShortTermCoursesAttended, TotalWorkshopsAttended, TotalSeminarsAttended, " & _
                        " IsCommonSubjectTeacher, IsCommonSubjectBeingTaught, CommonSubject, AppointmentType, Programme, Stream, Title,CanTakeClass) " & _
                        " VALUES  ( " & _
                        " '" & mSearchCode & "', " & AgL.Chk_Text(_StrMasterType) & ", " & AgL.Chk_Text(TxtFirstName.Text) & "," & AgL.Chk_Text(TxtMiddleName.Text) & "," & AgL.Chk_Text(TxtLastName.Text) & ", " & _
                        " " & AgL.ConvertDate(TxtDateOfJoin.Text) & ", " & AgL.ConvertDate(TxtDateOfResign.Text) & ", " & AgL.Chk_Text(TxtResignRemark.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtSex.Text) & ", " & AgL.Chk_Text(TxtBloodGroup.Text) & ", " & AgL.Chk_Text(TxtReligion.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtCategory.AgSelectedValue) & ", " & IIf(AgL.StrCmp(TxtIsTeachingStaff.Text, "Yes"), 1, 0) & ", " & _
                        " " & AgL.Chk_Text(TxtMotherName.Text) & " , " & AgL.Chk_Text(TxtDesignation.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtShift.Text) & ", " & AgL.Chk_Text(TxtProgrammeNature.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtSalaryMode.Text) & ", " & AgL.Chk_Text(TxtPayScale.Text) & ", " & _
                        " " & Val(TxtWorkingExperience.Text) & ", " & Val(TxtTeachingExperience.Text) & ", " & _
                        " " & Val(TxtResearchExperience.Text) & ", " & Val(TxtIndustryExperience.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtBankAcNo.Text) & ", " & AgL.Chk_Text(TxtBankName.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtBankBranch.Text) & ", " & AgL.Chk_Text(TxtIfscCode.Text) & ", " & _
                        " " & Val(TxtTotalPGProjectsGuided.Text) & ", " & Val(TxtTotalDoctorateProjectsGuided.Text) & ", " & _
                        " " & Val(TxtIsPapersPublishedInNationalJournals.Text) & ", " & _
                        " " & IIf(AgL.StrCmp(TxtIsPapersPublishedInInternationalJournals.Text, "Yes"), 1, 0) & ", " & _
                        " " & Val(TxtTotalBooksPublished.Text) & ", " & _
                        " " & Val(TxtIsInternationalConferencesAttended.Text) & ", " & _
                        " " & Val(TxtIsNationalConferencesAttended.Text) & ", " & _
                        " " & Val(TxtIsPapersInNationalConference.Text) & ", " & _
                        " " & Val(TxtIsPapersInInternationalConference.Text) & ", " & _
                        " " & Val(TxtIsShortTermCoursesAttended.Text) & ", " & _
                        " " & Val(TxtIsWorkshopsAttended.Text) & ", " & _
                        " " & Val(TxtIsSeminarsAttended.Text) & ", " & _
                        " " & IIf(AgL.StrCmp(TxtIsCommonSubjectTeacher.Text, "Yes"), 1, 0) & ", " & _
                        " " & IIf(AgL.StrCmp(TxtIsCommonSubjectBeingTaught.Text, "Yes"), 1, 0) & ", " & _
                        " " & AgL.Chk_Text(TxtCommonSubject.Text) & ",  " & _
                        " " & AgL.Chk_Text(TxtAppointmentType.Text) & ",  " & _
                        " " & AgL.Chk_Text(TxtProgramme.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtStream.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtTitle.Text) & ", " & _
                        " " & IIf(AgL.StrCmp(txtCanTakeClass.Text, "Yes"), 1, 0) & " " & _
                        " )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                If mBlnExists_SubGroupLog Then
                    If AgL.FunCreateSubGroup_Log(AgL.GCn, AgL.ECmd, mSearchCode).Trim = "" Then Err.Raise(1, , "")
                End If

            Else
                If mBlnExists_SubGroupLog Then
                    If AgL.FunCreateSubGroup_Log(AgL.GCn, AgL.ECmd, mSearchCode).Trim = "" Then Err.Raise(1, , "")
                End If


                mQry = "Update SubGroup Set U_AE = 'E', Edit_Date = '" & Format(AgL.PubLoginDate, "Short Date") & "', ModifiedBy = '" & AgL.PubUserName & "' Where SubCode = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "UPDATE Pay_Employee SET " & _
                        " MasterType = " & AgL.Chk_Text(_StrMasterType) & ", " & _
                        " FirstName = " & AgL.Chk_Text(TxtFirstName.Text) & ",MiddleName = " & AgL.Chk_Text(TxtMiddleName.Text) & ",	LastName =" & AgL.Chk_Text(TxtLastName.Text) & ", " & _
                        " DateOfJoin = " & AgL.ConvertDate(TxtDateOfJoin.Text) & ", DateOfResign = " & AgL.ConvertDate(TxtDateOfResign.Text) & ", ResignRemark = " & AgL.Chk_Text(TxtResignRemark.Text) & ", " & _
                        " Sex = " & AgL.Chk_Text(TxtSex.Text) & ", BloodGroup = " & AgL.Chk_Text(TxtBloodGroup.Text) & ", Religion = " & AgL.Chk_Text(TxtReligion.AgSelectedValue) & ", " & _
                        " Category = " & AgL.Chk_Text(TxtCategory.AgSelectedValue) & ", " & _
                        " IsTeachingStaff = " & IIf(AgL.StrCmp(TxtIsTeachingStaff.Text, "Yes"), 1, 0) & ", " & _
                        " MotherName = " & AgL.Chk_Text(TxtMotherName.Text) & ", " & _
                        " Designation = " & AgL.Chk_Text(TxtDesignation.Text) & ", " & _
                        " Shift = " & AgL.Chk_Text(TxtShift.Text) & ", " & _
                        " ProgrammeNature = " & AgL.Chk_Text(TxtProgrammeNature.AgSelectedValue) & ", " & _
                        " SalaryMode = " & AgL.Chk_Text(TxtSalaryMode.Text) & ", " & _
                        " PayScale = " & AgL.Chk_Text(TxtPayScale.Text) & ", " & _
                        " WorkExperience = " & Val(TxtWorkingExperience.Text) & ", " & _
                        " TeachingExperience = " & Val(TxtTeachingExperience.Text) & ", " & _
                        " ResearchExperience = " & Val(TxtResearchExperience.Text) & ", " & _
                        " IndustryExperience = " & Val(TxtIndustryExperience.Text) & ", " & _
                        " BankAcNo = " & AgL.Chk_Text(TxtBankAcNo.Text) & ", " & _
                        " BankName = " & AgL.Chk_Text(TxtBankName.Text) & ", " & _
                        " BankBranch = " & AgL.Chk_Text(TxtBankBranch.Text) & ", " & _
                        " IfscCode = " & AgL.Chk_Text(TxtIfscCode.Text) & ", " & _
                        " TotalPGProjectsGuided = " & Val(TxtTotalPGProjectsGuided.Text) & ", " & _
                        " TotalDoctorateProjectsGuided = " & Val(TxtTotalDoctorateProjectsGuided.Text) & ", " & _
                        " TotalPapersPublishedInNationalJournals = " & Val(TxtIsPapersPublishedInNationalJournals.Text) & ", " & _
                        " TotalPapersPublishedInInternationalJournals = " & Val(TxtIsPapersPublishedInInternationalJournals.Text) & ", " & _
                        " TotalBooksPublished = " & Val(TxtTotalBooksPublished.Text) & ", " & _
                        " TotalInternationalConferencesAttended = " & Val(TxtIsInternationalConferencesAttended.Text) & ", " & _
                        " TotalNationalConferencesAttended = " & Val(TxtIsNationalConferencesAttended.Text) & ", " & _
                        " TotalPapersInNationalConference = " & Val(TxtIsPapersInNationalConference.Text) & ", " & _
                        " TotalPapersInInternationalConference = " & Val(TxtIsPapersInInternationalConference.Text) & ", " & _
                        " TotalShortTermCoursesAttended = " & Val(TxtIsShortTermCoursesAttended.Text) & ", " & _
                        " TotalWorkshopsAttended = " & Val(TxtIsWorkshopsAttended.Text) & ", " & _
                        " TotalSeminarsAttended = " & Val(TxtIsSeminarsAttended.Text) & ", " & _
                        " IsCommonSubjectTeacher = " & IIf(AgL.StrCmp(TxtIsCommonSubjectTeacher.Text, "Yes"), 1, 0) & ", " & _
                        " IsCommonSubjectBeingTaught = " & IIf(AgL.StrCmp(TxtIsCommonSubjectBeingTaught.Text, "Yes"), 1, 0) & ", " & _
                        " CommonSubject = " & AgL.Chk_Text(TxtCommonSubject.Text) & ", " & _
                        " AppointmentType = " & AgL.Chk_Text(TxtAppointmentType.Text) & ", " & _
                        " Programme = " & AgL.Chk_Text(TxtProgramme.AgSelectedValue) & ", " & _
                        " Stream = " & AgL.Chk_Text(TxtStream.AgSelectedValue) & " , " & _
                        " Title=" & AgL.Chk_Text(TxtTitle.Text) & ", " & _
                        " CanTakeClass = " & IIf(AgL.StrCmp(txtCanTakeClass.Text, "Yes"), 1, 0) & " " & _
                        " WHERE SubCode = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If mBlnExists_SubGroupLog Then
                bIntTotalTables = 2
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

                mQry = "UPDATE " & bStrTableName & " SET ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & " , Name = " & AgL.Chk_Text(TxtName.Text) & ",	DispName = " & AgL.Chk_Text(mDisplayName) & ",	GroupCode = '" & TxtGroupCode.AgSelectedValue & "', " & _
                         " GroupNature ='" & mGroupNature & "',	Nature = '" & mNature & "',	Add1 = " & AgL.Chk_Text(TxtAdd1.Text) & ",	Add2 = " & AgL.Chk_Text(TxtAdd2.Text) & ",	 " & _
                         " CityCode = " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & ", PIN = " & Val(TxtPin.Text) & ",	Phone =" & AgL.Chk_Text(TxtPhone.Text) & ",	Mobile = " & AgL.Chk_Text(TxtMobile.Text) & ",	" & _
                         " PAN = " & AgL.Chk_Text(TxtPanNo.Text) & ", FatherName = " & AgL.Chk_Text(TxtFatherName.Text) & ", FatherNamePrefix = " & AgL.Chk_Text(TxtFatherNamePrefix.Text) & ", " & _
                         " DOB = " & AgL.ConvertDate(TxtDOB.Text) & ", EMail = " & AgL.Chk_Text(TxtEMail.Text) & ", " & _
                         " CommonAc = " & IIf(AgL.StrCmp(TxtCommonAc.Text, "Yes"), 1, 0) & ", " & _
                         " LogInUser = " & AgL.Chk_Text(TxtLogInUser.AgSelectedValue) & ", " & _
                         " MarriageDate = " & AgL.Chk_Text(TxtMarriageDate.Text) & ", " & _
                         " Sex = " & AgL.Chk_Text(TxtSex.Text) & ", " & _
                         " MotherName = " & AgL.Chk_Text(TxtMotherName.Text) & " ,AttendanceCode = " & AgL.Chk_Text(TxtAttendanceCode.Text) & " " & _
                         " WHERE SubCode = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Next


            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Pay_EmployeeAcademicDetail Where Subcode = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Sr = 1
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Class, I).Value <> "" Then
                        mQry = "INSERT INTO Pay_EmployeeAcademicDetail ( SubCode, Sr, Class, University, EnrollmentNo, " & _
                                " YearOfPassing, Subjects, Result, TotalPercentage, MeritPercentage, Learning, Specialization, Remark,Institute) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & Sr & ", " & AgL.Chk_Text(.Item(Col1Class, I).Value) & ", " & AgL.Chk_Text(.AgSelectedValue(Col1University, I)) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1EnrollmentNo, I).Value) & ", " & Val(.Item(Col1YearOfPassing, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Subjects, I).Value) & ", " & AgL.Chk_Text(.Item(Col1Result, I).Value) & ", " & _
                                " " & Val(.Item(Col1TotalPercentage, I).Value) & ", " & Val(.Item(Col1MeritPercentage, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Learning, I).Value) & ", " & AgL.Chk_Text(.Item(Col1Specialization, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Remark, I).Value) & ", " & AgL.Chk_Text(.Item(Col1Institute, I).Value) & ")"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        Sr = Sr + 1
                    End If
                Next I
            End With

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Pay_TeacherSubject Where Subcode = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Sr = 1
            With DGL2
                For I = 0 To .Rows.Count - 1
                    If .Item(Col2SubjectCode, I).Value <> "" Then
                        mQry = "INSERT INTO Pay_TeacherSubject ( SubCode, Sr, Subject ) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & Sr & ", " & AgL.Chk_Text(.AgSelectedValue(Col2SubjectCode, I)) & " )"

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        Sr = Sr + 1
                    End If
                Next I
            End With


            If Academic_ProjLib.ClsMain.IsModuleActive_Library Then
                mObjStructLibraryMember = Nothing
                If Not FunCreateLibraryMemberStructure(mObjStructLibraryMember, mBlnIsLibraryMemberExists) Then Exit Sub

                If Not mObjClsMain.FunSaveLibraryMember(mObjStructLibraryMember, AgL.GCn, AgL.ECmd, IIf(mBlnIsLibraryMemberExists, "Edit", "Add")) Then
                    Err.Raise(1, , "")
                End If
            End If

            '************** Rati 20/Apr/2012 ************************
            If Academic_ProjLib.ClsMain.IsModuleActive_Transport Then
                If AgL.StrCmp(TxtIsTransport.Text, "Yes") Then
                    If Not mObjClsMain.FunSaveTransportMember(mObjStructTransportMember, AgL.GCn, AgL.ECmd, IIf(mBlnIsTransportMemberExists, "Edit", "Add")) Then
                        Err.Raise(1, , "")
                    End If
                End If
            End If

            If Academic_ProjLib.ClsMain.IsModuleActive_Mess Then
                If AgL.StrCmp(TxtIsMess.Text, "Yes") Then
                    If Not mObjClsMain.FunSaveMessMember(mObjStructMessMember, AgL.GCn, AgL.ECmd, IIf(mBlnIsMessMemberExists, "Edit", "Add")) Then
                        Err.Raise(1, , "")
                    End If
                End If
            End If

            '**************************************

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)
            AgL.ETrans.Commit()
            mTrans = False

            Update_Picture("SubGroup_Image", "Photo", "Where Subcode = '" & mSearchCode & "'", Photo_Byte)
            Update_Picture("SubGroup_Image", "Signature", "Where Subcode = '" & mSearchCode & "'", StudentSignature_Byte)


            Call ProcSaveSubGroup_BLOB()


            FIniMaster(0, 1)
            Topctrl1_tbRef()
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

    Sub Update_Picture(ByVal mTable As String, ByVal mColumn As String, ByVal mCondition As String, ByVal ByteArr As Byte())
        If ByteArr Is Nothing Then Exit Sub
        Dim sSQL As String = "Update " & mTable & " Set " & mColumn & "=@pic " & mCondition

        Dim cmd As SqlCommand = New SqlCommand(sSQL, AgL.GCn)
        Dim Pic As SqlParameter = New SqlParameter("@pic", SqlDbType.Image)
        Pic.Value = ByteArr
        cmd.Parameters.Add(Pic)
        cmd.ExecuteNonQuery()
    End Sub

    Sub ProcSaveSubGroup_BLOB()
        Dim ByteArr As Byte() = Nothing
        Dim bCondStr$ = " Where 1=1 "
        Dim GcnRead As SqlConnection = Nothing
        Dim bIntSr% = 0, bIntI% = 0

        Try
            If AgL.XNull(AgL.PubImageDBName).ToString.Trim <> "" Then
                GcnRead = AgL.FunGetReadConnection(AgL.GCnImage_ConnectionString)

                mQry = "Delete From SubGroup_BLOB " & _
                        " Where SubCode = " & AgL.Chk_Text(mSearchCode) & " "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnImage)

                With DGL3
                    For bIntI = 0 To .Rows.Count - 1
                        Try
                            ByteArr = DGL3.Item(Col3ByteArray, bIntI).Value
                        Catch ex As Exception

                        End Try


                        If AgL.XNull(DGL3.Item(Col3Description, bIntI).Value).ToString.Trim <> "" _
                            And AgL.XNull(DGL3.Item(Col3FileName, bIntI).Value).ToString.Trim <> "" _
                            And ByteArr IsNot Nothing Then

                            bIntSr += 1

                            bCondStr = " Where 1=1 "
                            bCondStr += " And SubCode = " & AgL.Chk_Text(mSearchCode) & " "
                            bCondStr += " And Sr = " & bIntSr & " "

                            mQry = "INSERT INTO dbo.SubGroup_BLOB (SubCode, Sr, Description, FileName) " & _
                                    " VALUES (" & AgL.Chk_Text(mSearchCode) & ", " & bIntSr & ", " & _
                                    " " & AgL.Chk_Text(DGL3.Item(Col3Description, bIntI).Value) & ", " & _
                                    " " & AgL.Chk_Text(DGL3.Item(Col3FileName, bIntI).Value) & " " & _
                                    " )"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GcnImage)

                            mQry = "Update SubGroup_BLOB Set BLOB=@pic " & bCondStr

                            Dim cmd As SqlCommand = New SqlCommand(mQry, AgL.GcnImage)
                            Dim Pic As SqlParameter = New SqlParameter("@pic", SqlDbType.Image)
                            Pic.Value = ByteArr
                            cmd.Parameters.Add(Pic)
                            cmd.ExecuteNonQuery()
                        End If
                    Next
                End With
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Dim DTbl As DataTable = Nothing
        Dim DTRTbl As DataTable = Nothing
        Dim MastPos As Long
        Dim I As Integer
        Dim mTransFlag As Boolean = False
      

        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select S.* " & _
                        " From SubGroup S " & _
                        " Where S.SubCode='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_code"))
                        TxtManualCode.Text = AgL.XNull(.Rows(0)("ManualCode"))
                        TxtGroupCode.AgSelectedValue = AgL.XNull(.Rows(0)("GroupCode"))
                        mGroupNature = AgL.XNull(.Rows(0)("GroupNature"))
                        mNature = AgL.XNull(.Rows(0)("Nature"))
                        TxtName.Text = AgL.XNull(.Rows(0)("Name"))
                        mDisplayName = AgL.XNull(.Rows(0)("DispName"))
                        TxtCommonAc.Text = IIf(AgL.VNull(.Rows(0)("CommonAc")), "Yes", "No")
                        TxtAdd1.Text = AgL.XNull(.Rows(0)("Add1"))
                        TxtAdd2.Text = AgL.XNull(.Rows(0)("Add2"))
                        TxtCityCode.AgSelectedValue = AgL.XNull(.Rows(0)("CityCode"))
                        TxtPanNo.Text = AgL.XNull(.Rows(0)("Pan"))
                        TxtPhone.Text = AgL.XNull(.Rows(0)("Phone"))
                        TxtPin.Text = AgL.VNull(.Rows(0)("Pin"))
                        TxtMobile.Text = AgL.XNull(.Rows(0)("Mobile"))
                        TxtEMail.Text = AgL.XNull(.Rows(0)("EMail"))
                        TxtAttendanceCode.Text = AgL.XNull(.Rows(0)("AttendanceCode"))
                        TxtDOB.Text = Format(AgL.XNull(.Rows(0)("DOB")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtMarriageDate.Text = Format(AgL.XNull(.Rows(0)("MarriageDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                        TxtFatherName.Text = AgL.XNull(.Rows(0)("FatherName"))
                        TxtFatherNamePrefix.Text = AgL.XNull(.Rows(0)("FatherNamePrefix"))

                        TxtLogInUser.AgSelectedValue = AgL.XNull(.Rows(0)("LogInUser"))

                        If TxtCityCode.Text.ToString.Trim = "" Or TxtCityCode.AgSelectedValue.Trim = "" Then
                            TxtState.Text = ""
                        Else
                            If TxtCityCode.AgHelpDataSet IsNot Nothing Then
                                DrTemp = TxtCityCode.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & "")
                                TxtState.Text = AgL.XNull(DrTemp(0)("State"))
                            End If
                        End If

                        mQry = "SELECT M.* FROM Lib_Member M With (NoLock) WHERE M.SubCode = " & AgL.Chk_Text(mSearchCode) & " "
                        DTbl = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                        If DTbl.Rows.Count > 0 Then
                            TxtLibraryMemberType.AgSelectedValue = AgL.XNull(DTbl.Rows(0)("MemberType"))
                            TxtlibrarySite.AgSelectedValue = AgL.XNull(DTbl.Rows(0)("Site_Code"))
                        End If
                        If DTbl IsNot Nothing Then DTbl.Dispose()


                        mQry = "SELECT M.* FROM tp_Member M With (NoLock) WHERE M.SubCode = " & AgL.Chk_Text(mSearchCode) & " "
                        DTRTbl = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                        If DTRTbl.Rows.Count > 0 Then
                            mFrmObjTransportInfo = New FrmTransportInfo()
                            Call CType(mFrmObjTransportInfo, FrmTransportInfo).Ini_List()

                            TxtIsTransport.Text = "Yes"

                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtMemberCardNo.Text = AgL.XNull(DTRTbl.Rows(0)("MemberCardNo"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardPrefix.Text = AgL.XNull(DTRTbl.Rows(0)("CardPrefix"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text = AgL.VNull(DTRTbl.Rows(0)("CardSrNo"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtValidTillDate.Text = AgL.XNull(DTRTbl.Rows(0)("ValidTillDate"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtVehicle.AgSelectedValue = AgL.XNull(DTRTbl.Rows(0)("Vehicle"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtSeatNo.Text = AgL.XNull(DTRTbl.Rows(0)("SeatNo"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtRoute.AgSelectedValue = AgL.XNull(DTRTbl.Rows(0)("Route"))
                            CType(mFrmObjTransportInfo, FrmTransportInfo).TxtPickUpPoint.AgSelectedValue = AgL.XNull(DTRTbl.Rows(0)("PickUpPoint"))
                        End If
                        If DTRTbl IsNot Nothing Then DTRTbl.Dispose()

                        mQry = "SELECT M.* FROM Mess_Member M With (NoLock) WHERE M.SubCode = " & AgL.Chk_Text(AgL.XNull(mSearchCode)) & " "
                        DTbl = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                        If DTbl.Rows.Count > 0 Then
                            TxtIsMess.Text = "Yes"
                            txtMessJoinDt.Text = Format(AgL.XNull(DTbl.Rows(0)("JoiningDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        End If
                        If DTbl IsNot Nothing Then DTbl.Dispose()


                        TxtPrepared.Text = AgL.XNull(.Rows(0)("U_Name"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    End If
                End With

                mQry = "Select E.* " & _
                        " From Pay_Employee E " & _
                        " Where E.SubCode='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtDateOfJoin.Text = Format(AgL.XNull(.Rows(0)("DateOfJoin")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtDateOfResign.Text = Format(AgL.XNull(.Rows(0)("DateOfResign")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtResignRemark.Text = AgL.XNull(.Rows(0)("ResignRemark"))
                        TxtFirstName.Text = AgL.XNull(.Rows(0)("FirstName"))
                        TxtMiddleName.Text = AgL.XNull(.Rows(0)("MiddleName"))
                        TxtLastName.Text = AgL.XNull(.Rows(0)("LastName"))
                        TxtSex.Text = AgL.XNull(.Rows(0)("Sex"))
                        TxtReligion.AgSelectedValue = AgL.XNull(.Rows(0)("Religion"))
                        TxtCategory.AgSelectedValue = AgL.XNull(.Rows(0)("Category"))
                        TxtIsTeachingStaff.Text = IIf(AgL.VNull(.Rows(0)("IsTeachingStaff")), "Yes", "No")
                        txtCanTakeClass.Text = IIf(AgL.VNull(.Rows(0)("CanTakeClass")), "Yes", "No")
                        TxtBloodGroup.Text = AgL.XNull(.Rows(0)("BloodGroup"))
                        TxtTitle.Text = AgL.XNull(.Rows(0)("Title"))
                        TxtMotherName.Text = AgL.XNull(.Rows(0)("MotherName"))
                        TxtDesignation.Text = AgL.XNull(.Rows(0)("Designation"))
                        TxtShift.Text = AgL.XNull(.Rows(0)("Shift"))
                        TxtProgrammeNature.AgSelectedValue = AgL.XNull(.Rows(0)("ProgrammeNature"))
                        TxtSalaryMode.Text = AgL.XNull(.Rows(0)("SalaryMode"))
                        TxtPayScale.Text = AgL.XNull(.Rows(0)("PayScale"))

                        TxtWorkingExperience.Text = AgL.VNull(.Rows(0)("WorkExperience"))
                        TxtTeachingExperience.Text = AgL.VNull(.Rows(0)("TeachingExperience"))
                        TxtResearchExperience.Text = AgL.VNull(.Rows(0)("ResearchExperience"))
                        TxtIndustryExperience.Text = AgL.VNull(.Rows(0)("IndustryExperience"))

                        TxtBankAcNo.Text = AgL.XNull(.Rows(0)("BankAcNo"))
                        TxtBankName.Text = AgL.XNull(.Rows(0)("BankName"))
                        TxtBankBranch.Text = AgL.XNull(.Rows(0)("BankBranch"))
                        TxtIfscCode.Text = AgL.XNull(.Rows(0)("IfscCode"))

                        TxtTotalPGProjectsGuided.Text = AgL.VNull(.Rows(0)("TotalPGProjectsGuided"))
                        TxtTotalDoctorateProjectsGuided.Text = AgL.VNull(.Rows(0)("TotalDoctorateProjectsGuided"))
                        TxtTotalBooksPublished.Text = AgL.VNull(.Rows(0)("TotalBooksPublished"))

                        TxtIsPapersPublishedInNationalJournals.Text = AgL.VNull(.Rows(0)("TotalPapersPublishedInNationalJournals"))
                        TxtIsPapersPublishedInInternationalJournals.Text = AgL.VNull(.Rows(0)("TotalPapersPublishedInInternationalJournals"))
                        TxtIsInternationalConferencesAttended.Text = AgL.VNull(.Rows(0)("TotalInternationalConferencesAttended"))
                        TxtIsNationalConferencesAttended.Text = AgL.VNull(.Rows(0)("TotalNationalConferencesAttended"))
                        TxtIsPapersInNationalConference.Text = AgL.VNull(.Rows(0)("TotalPapersInNationalConference"))
                        TxtIsPapersInInternationalConference.Text = AgL.VNull(.Rows(0)("TotalPapersInInternationalConference"))
                        TxtIsShortTermCoursesAttended.Text = AgL.VNull(.Rows(0)("TotalShortTermCoursesAttended"))
                        TxtIsWorkshopsAttended.Text = AgL.VNull(.Rows(0)("TotalWorkshopsAttended"))
                        TxtIsSeminarsAttended.Text = AgL.VNull(.Rows(0)("TotalSeminarsAttended"))

                        TxtIsCommonSubjectTeacher.Text = IIf(AgL.VNull(.Rows(0)("IsCommonSubjectTeacher")) = 0, "No", "Yes")
                        TxtIsCommonSubjectBeingTaught.Text = IIf(AgL.VNull(.Rows(0)("IsCommonSubjectBeingTaught")) = 0, "No", "Yes")
                        TxtCommonSubject.Text = AgL.XNull(.Rows(0)("CommonSubject"))
                        TxtAppointmentType.Text = AgL.XNull(.Rows(0)("AppointmentType"))
                        TxtProgramme.AgSelectedValue = AgL.XNull(.Rows(0)("Programme"))
                        TxtStream.AgSelectedValue = AgL.XNull(.Rows(0)("Stream"))
                    End If
                End With

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


                mQry = "Select Ad.* " & _
                        " From Pay_EmployeeAcademicDetail Ad " & _
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
                            DGL1.Item(Col1Institute, I).Value = AgL.XNull(.Rows(I)("Institute"))
                            DGL1.Item(Col1EnrollmentNo, I).Value = AgL.XNull(.Rows(I)("EnrollmentNo"))
                            DGL1.Item(Col1YearOfPassing, I).Value = AgL.VNull(.Rows(I)("YearOfPassing"))
                            DGL1.Item(Col1Subjects, I).Value = AgL.XNull(.Rows(I)("Subjects"))
                            DGL1.Item(Col1Result, I).Value = AgL.XNull(.Rows(I)("Result"))
                            DGL1.Item(Col1TotalPercentage, I).Value = Format(AgL.VNull(.Rows(I)("TotalPercentage")), "0.00")
                            DGL1.Item(Col1MeritPercentage, I).Value = Format(AgL.VNull(.Rows(I)("MeritPercentage")), "0.00")
                            DGL1.Item(Col1Learning, I).Value = AgL.XNull(.Rows(I)("Learning"))
                            DGL1.Item(Col1Specialization, I).Value = AgL.XNull(.Rows(I)("Specialization"))
                            DGL1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))

                        Next
                    End If
                End With

                mQry = "Select Ts.*, S.SubjectType " & _
                        " From Pay_TeacherSubject Ts " & _
                        " Left Join Sch_Subject S On Ts.Subject = S.Code " & _
                        " Where Ts.SubCode = '" & mSearchCode & "' " & _
                        " Order By Ts.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        DGL2.RowCount = 1 : DGL2.Rows.Clear()
                        For I = 0 To .Rows.Count - 1
                            DGL2.Rows.Add()
                            DGL2.Item(Col_SNo, I).Value = DGL2.Rows.Count - 1
                            DGL2.AgSelectedValue(Col2SubjectCode, I) = AgL.XNull(.Rows(I)("Subject"))
                            DGL2.Item(Col2SubjectType, I).Value = AgL.XNull(.Rows(I)("SubjectType"))
                        Next
                    End If
                End With

                If AgL.XNull(AgL.PubImageDBName).ToString.Trim <> "" Then
                    mQry = "SELECT B.* " & _
                            " FROM SubGroup_BLOB B With (NoLock) " & _
                            " WHERE B.SubCode = " & AgL.Chk_Text(mSearchCode) & " " & _
                            " Order By B.Sr "
                    DsTemp = AgL.FillData(mQry, AgL.GcnImage)
                    With DsTemp.Tables(0)
                        DGL3.RowCount = 1 : DGL3.Rows.Clear()
                        If .Rows.Count > 0 Then
                            For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                                DGL3.Rows.Add()
                                DGL3.Item(Col_SNo, I).Value = DGL3.Rows.Count - 1
                                DGL3.Item(Col3Description, I).Value = AgL.XNull(.Rows(I)("Description"))
                                If Not IsDBNull(.Rows(I)("BLOB")) Then
                                    DGL3.Item(Col3ByteArray, I).Value = .Rows(I)("BLOB")
                                    DGL3.Item(Col3FileName, I).Value = AgL.XNull(.Rows(I)("FileName"))
                                End If
                            Next I
                        End If
                    End With
                End If

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
            If DsTemp IsNot Nothing Then DsTemp.Dispose()
            If DTbl IsNot Nothing Then DTbl.Dispose()
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : mDisplayName = "" : TxtIsTeachingStaff.Text = "Yes" : TxtCommonAc.Text = "Yes" : txtCanTakeClass.Text = "Yes" : TxtIsTransport.Text = "No" : TxtIsMess.Text = "No"

        mBlnIsLibraryMemberExists = False
        TxtIsCommonSubjectTeacher.Text = "No" : TxtIsCommonSubjectBeingTaught.Text = "No"

        PicPhoto.Image = Nothing : Photo_Byte = Nothing
        PicStudentSignature.Image = Nothing : StudentSignature_Byte = Nothing
        mObjStructLibraryMember = Nothing

        DGL1.RowCount = 1 : DGL1.Rows.Clear()
        DGL2.RowCount = 1 : DGL2.Rows.Clear()
        DGL3.RowCount = 1 : DGL3.Rows.Clear()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
        TxtName.Enabled = False
        TxtState.ReadOnly = True


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
        Try
            Tc1.SelectedTab = Tp1
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtFirstName) Then Exit Function
            'If AgL.RequiredField(TxtLastName) Then Exit Function
            If AgL.RequiredField(TxtGroupCode) Then Exit Function
            If AgL.RequiredField(TxtCommonAc, "Is Common A/c?") Then Exit Function
            If AgL.RequiredField(TxtIsTeachingStaff, LblIsTeachingStaff.Text) Then Exit Function
            If AgL.RequiredField(txtCanTakeClass, lblCanTakeClass.Text) Then Exit Function


            If Not AgL.IsValid_EMailId(TxtEMail, "Email ID") Then Exit Function

            If Academic_ProjLib.ClsMain.IsModuleActive_Library Then
                If AgL.RequiredField(TxtLibraryMemberType, LblLibraryMemberType.Text) Then Exit Function
            End If

            If Academic_ProjLib.ClsMain.IsModuleActive_Transport Then
                If AgL.StrCmp(TxtIsTransport.Text, "Yes") Then
                    mObjStructTransportMember = Nothing
                    If Not FunCreateTransportMemberStructure(mObjStructTransportMember, mBlnIsTransportMemberExists) Then Exit Function
                End If
            End If

            If Academic_ProjLib.ClsMain.IsModuleActive_Mess Then
                If AgL.StrCmp(TxtIsMess.Text, "Yes") Then
                    mObjStructMessMember = Nothing
                    If Not FunCreateMessMemberStructure(mObjStructMessMember, mBlnIsMessMemberExists) Then Exit Function
                End If
            End If

            If Not FunIsValidDateOfBirth() Then Exit Function
            If Not FunIsValidDateOfJoin() Then Exit Function
            If Not FunIsValidDateOfResign() Then Exit Function

            If TxtDateOfResign.Text.Trim <> "" Then If AgL.RequiredField(TxtResignRemark, "Resign Remark") Then Exit Function

            Tc1.SelectedTab = Tp2
            AgCL.AgBlankNothingCells(DGL1)
            If AgCL.AgIsDuplicate(DGL1, "" & Col1Class & "") Then Exit Function

            Tc1.SelectedTab = Tp1
            AgCL.AgBlankNothingCells(DGL2)
            If AgCL.AgIsDuplicate(DGL2, "" & Col2SubjectCode & "") Then Exit Function

            If TxtLogInUser.Text.Trim <> "" Then
                mQry = "SELECT IsNull(COUNT(*),0) As Cnt " & _
                        " FROM SubGroup H " & _
                        " WHERE H.LogInUser = " & AgL.Chk_Text(TxtLogInUser.AgSelectedValue) & " " & _
                        " AND " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.SubCode <> '" & mSearchCode & "' ") & " "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then
                    MsgBox("Log in user is already alloted!...")
                    TxtLogInUser.Focus()
                    Exit Function
                End If
            End If

            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where ManualCode='" & TxtManualCode.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where ManualCode='" & TxtManualCode.Text & "' And SubCode<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function
            End If
            mDisplayName = TxtFirstName.Text + IIf(TxtMiddleName.Text.Trim = "", "", Space(1)) + TxtMiddleName.Text + Space(1) + TxtLastName.Text
            TxtName.Text = TxtFirstName.Text + IIf(TxtMiddleName.Text.Trim = "", "", Space(1)) + TxtMiddleName.Text + Space(1) + TxtLastName.Text + Space(1) + "{" + TxtManualCode.Text + "}"


            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function
    Private Function FunCreateTransportMemberStructure(ByRef ObjStructTransportMember As ClsMain.StructTransportMember, ByRef BlnIsMemberExists As Boolean) As Boolean
        Dim bBlnRerurn As Boolean = False
        Dim DrTemp As DataRow() = Nothing
        Dim bDtMember As DataTable = Nothing
        Try
            ObjStructTransportMember = New ClsMain.StructTransportMember()
            ObjStructTransportMember.ProcBlankStruct()


            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                BlnIsMemberExists = False
                '**************Rati 21/Apr/2012************
                CType(mFrmObjTransportInfo, FrmTransportInfo).MemberCardNo()
                If CType(mFrmObjTransportInfo, FrmTransportInfo).MemberCardNo() <> CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text And CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text.Trim <> "" Then
                    MsgBox("Card SrNo : " & CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text & " Already Exist New Card SrNo Alloted : " & CType(mFrmObjTransportInfo, FrmTransportInfo).MemberCardNo() & "")
                    CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text = CType(mFrmObjTransportInfo, FrmTransportInfo).MemberCardNo()
                End If
                '*********
            Else
                mQry = "SELECT M.* FROM Tp_Member M WHERE M.SubCode = " & AgL.Chk_Text(mSearchCode) & " "
                bDtMember = AgL.FillData(mQry, AgL.GCn).Tables(0)

                If bDtMember.Rows.Count > 0 Then
                    BlnIsMemberExists = True
                Else
                    BlnIsMemberExists = False
                End If
            End If

            With ObjStructTransportMember
                .StrSubCode = mSearchCode
                .StrStuent = ""
                .StrEmployee = mSearchCode
                .StrMemberCardNo = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtMemberCardNo.Text
                .StrCardPrefix = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardPrefix.Text
                .StrCardSrNo = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtCardSrNo.Text
                .StrValidTillDate = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtValidTillDate.Text
                .StrVehicle = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtVehicle.AgSelectedValue
                .StrSeatno = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtSeatNo.Text
                .StrRoute = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtRoute.AgSelectedValue
                .StrPickupPoint = CType(mFrmObjTransportInfo, FrmTransportInfo).TxtPickUpPoint.AgSelectedValue

                If BlnIsMemberExists Then
                    .StrUID = AgL.XNull(bDtMember.Rows(0)("UID").ToString)
                    .StrMemberCardNo = AgL.XNull(bDtMember.Rows(0)("MemberCardNo"))
                    .StrCardPrefix = AgL.XNull(bDtMember.Rows(0)("CardPrefix"))
                    .StrCardSrNo = AgL.XNull(bDtMember.Rows(0)("CardSrNo"))
                    .StrValidTillDate = AgL.XNull(bDtMember.Rows(0)("ValidTillDate"))
                    .StrVehicle = AgL.XNull(bDtMember.Rows(0)("Vehicle"))
                    .StrSeatno = AgL.XNull(bDtMember.Rows(0)("SeatNo"))
                    .StrRoute = AgL.XNull(bDtMember.Rows(0)("Route"))
                    .StrPickupPoint = AgL.XNull(bDtMember.Rows(0)("PickUpPoint"))
                End If
            End With

            bBlnRerurn = True
        Catch ex As Exception
            bBlnRerurn = False
        Finally
            FunCreateTransportMemberStructure = bBlnRerurn
        End Try
    End Function
    Private Function FunCreateMessMemberStructure(ByRef ObjStructMessMember As ClsMain.StructMessMember, ByRef BlnIsMemberExists As Boolean) As Boolean
        Dim bBlnRerurn As Boolean = False
        Dim DrTemp As DataRow() = Nothing
        Dim bDtMember As DataTable = Nothing
        Try
            ObjStructMessMember = New ClsMain.StructMessMember()
            ObjStructMessMember.ProcBlankStruct()


            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                BlnIsMemberExists = False
            Else
                mQry = "SELECT M.* FROM Mess_Member M WHERE M.SubCode = " & AgL.Chk_Text(mSearchCode) & " "
                bDtMember = AgL.FillData(mQry, AgL.GCn).Tables(0)

                If bDtMember.Rows.Count > 0 Then
                    BlnIsMemberExists = True
                Else
                    BlnIsMemberExists = False
                End If
            End If

            With ObjStructMessMember
                .StrSubCode = mSearchCode
                .StrStuent = ""
                .StrEmployee = mSearchCode
                .StrMemberType = ClsMain.MemberType.Employee
                .StrJoinDate = txtMessJoinDt.Text

                If BlnIsMemberExists Then
                    .StrJoinDate = AgL.XNull(bDtMember.Rows(0)("JoiningDate"))
                End If
            End With

            bBlnRerurn = True
        Catch ex As Exception
            bBlnRerurn = False
        Finally
            FunCreateMessMemberStructure = bBlnRerurn
        End Try
    End Function

    Private Sub ProcAssignValuesToStructLibraryMember(ByRef bTempStruct_LibraryMaster As Academic_ProjLib.ClsMain.Struct_LibraryMaster, ByVal bEntryMode As String)
        With bTempStruct_LibraryMaster
            .Member_Name = TxtName.Text
            .Member_Type = "Employee"
            .Father_Name = TxtFatherName.Text
            .Employee = mSearchCode
            .Sex = TxtSex.Text
            .U_Name = AgL.PubUserName
            .U_EntDt = AgL.PubLoginDate
            .U_AE = AgL.MidStr(bEntryMode, 0, 1)

            If Topctrl1.Mode = "Add" Then
                .Member_Code = PLib.FunGetLibraryMemberCode(AgL.GcnLibrary)
            Else
                mQry = "Select Member_Code From " & AgL.PubLibraryDbName & ".dbo.Library_Member Where Employee = '" & mSearchCode & "' "
                .Member_Code = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnLibrary).ExecuteScalar)
            End If
        End With
    End Sub

    Private Function FunIsValidDateOfBirth() As Boolean
        Dim bResult As Boolean = True
        If TxtDOB.Text.Trim <> "" Then
            If CDate(TxtDOB.Text) >= CDate(AgL.PubLoginDate) Then
                bResult = False
                MsgBox("Date Of Birth Is Not Valid!...")
                TxtDOB.Focus()
            End If
        End If

        FunIsValidDateOfBirth = bResult
    End Function

    Private Function FunIsValidDateOfJoin() As Boolean
        Dim bResult As Boolean = True
        If TxtDOB.Text.Trim <> "" And TxtDateOfJoin.Text.Trim <> "" And FunIsValidDateOfBirth() = True Then
            If CDate(TxtDateOfJoin.Text) <= CDate(TxtDOB.Text) Then
                bResult = False
                MsgBox("Date Of Join Is Not Valid!...")
                TxtDateOfJoin.Focus()
            End If
        End If

        FunIsValidDateOfJoin = bResult
    End Function

    Private Function FunIsValidDateOfResign() As Boolean
        Dim bResult As Boolean = True
        If TxtDateOfResign.Text.Trim <> "" Then
            If TxtDOB.Text.Trim <> "" And TxtDateOfJoin.Text.Trim <> "" And FunIsValidDateOfJoin() = True Then
                If CDate(TxtDateOfResign.Text) <= CDate(TxtDateOfJoin.Text) Then
                    bResult = False
                    MsgBox("Date Of Resign Is Not Valid!...")
                    TxtDateOfResign.Focus()
                End If
            End If
        End If

        FunIsValidDateOfResign = bResult
    End Function

    Private Sub PictureBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicPhoto.DoubleClick, PicStudentSignature.DoubleClick
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Select Case sender.Name
            Case PicPhoto.Name
                AgL.GetPicture(sender, Photo_Byte)

            Case PicStudentSignature.Name
                AgL.GetPicture(sender, StudentSignature_Byte)
        End Select
    End Sub

    Sub Show_Picture(ByVal PicBox As PictureBox, ByVal B As Byte())
        Dim Mem As MemoryStream
        Dim Img As Image

        Mem = New MemoryStream(B)
        Img = Image.FromStream(Mem)
        PicBox.Image = Img
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtSite_Code.Enter, TxtName.Enter, TxtIsTeachingStaff.Enter, TxtFirstName.Enter, TxtMiddleName.Enter, TxtLastName.Enter, _
        TxtGroupCode.Enter, TxtManualCode.Enter, TxtDOB.Enter, TxtDateOfJoin.Enter, TxtResignRemark.Enter, TxtReligion.Enter, _
        TxtCategory.Enter, TxtSex.Enter, TxtBloodGroup.Enter, TxtAdd1.Enter, TxtAdd2.Enter, TxtCityCode.Enter, TxtPin.Enter, _
        TxtEMail.Enter, TxtPanNo.Enter, TxtPhone.Enter, TxtMobile.Enter, TxtLibraryMemberType.Enter, txtCanTakeClass.Enter
        Try
            Select Case sender.name
                Case TxtLibraryMemberType.Name
                    TxtLibraryMemberType.AgRowFilter = " IsDeleted = 'No' "

            End Select
            Call Calculation()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtName.Validating, TxtIsTeachingStaff.Validating, TxtFirstName.Validating, TxtMiddleName.Validating, TxtLastName.Validating, _
        TxtGroupCode.Validating, TxtManualCode.Validating, TxtDOB.Validating, TxtDateOfJoin.Validating, TxtResignRemark.Validating, TxtReligion.Validating, _
        TxtCategory.Validating, TxtSex.Validating, TxtBloodGroup.Validating, TxtAdd1.Validating, TxtAdd2.Validating, TxtCityCode.Validating, TxtPin.Validating, _
        TxtEMail.Validating, TxtPanNo.Validating, TxtPhone.Validating, TxtMobile.Validating, TxtLibraryMemberType.Validating, txtCanTakeClass.Validating, TxtIsTransport.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtGroupCode.Name
                    If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                        With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                            mGroupNature = AgL.XNull(.Item("GroupNature", .CurrentCell.RowIndex).Value)
                            mNature = AgL.XNull(.Item("Nature", .CurrentCell.RowIndex).Value)
                        End With
                    End If

                Case TxtIsTransport.Name
                    Dim FrmObj As Form = Nothing
                    If mFrmObjTransportInfo Is Nothing Then
                        If AgL.StrCmp(TxtIsTransport.Text, "Yes") Then
                            FrmObj = New FrmTransportInfo
                        End If
                    Else
                        FrmObj = mFrmObjTransportInfo
                    End If
                    If FrmObj IsNot Nothing Then
                        FormLocation.Y = TxtIsTransport.Top : FormLocation.X = 200
                        CType(FrmObj, FrmTransportInfo).EntryMode = Topctrl1.Mode
                        CType(FrmObj, FrmTransportInfo).FormLocation = FormLocation
                        CType(FrmObj, FrmTransportInfo).FrmObj = mFrmObjTransportInfo
                        FrmObj.ShowDialog()
                        mFrmObjTransportInfo = FrmObj
                        TxtIsTransport.Tag = FrmObj
                    End If

                Case TxtIsTeachingStaff.Name
                    If TxtIsTeachingStaff.Text.Trim = "" Then TxtIsTeachingStaff.Text = "Yes"

                Case txtCanTakeClass.Name
                    If txtCanTakeClass.Text.Trim = "" Then txtCanTakeClass.Text = "Yes"

                Case TxtFirstName.Name, TxtLastName.Name, TxtMiddleName.Name, TxtManualCode.Name, TxtName.Name
                    TxtName.Text = TxtFirstName.Text + IIf(TxtMiddleName.Text.Trim = "", "", Space(1)) + TxtMiddleName.Text + Space(1) + TxtLastName.Text + Space(1) + "{" + TxtManualCode.Text + "}"

                Case TxtDOB.Name
                    Call FunIsValidDateOfBirth()

                Case TxtDateOfJoin.Name
                    Call FunIsValidDateOfJoin()

                Case TxtDateOfResign.Name
                    Call FunIsValidDateOfResign()

                Case TxtCityCode.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        TxtState.Text = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtState.Text = AgL.XNull(DrTemp(0)("State"))
                        End If
                    End If
            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

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

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DGL1.KeyDown, DGL2.KeyDown, DGL3.KeyDown
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

    Private Sub DGL2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DGL2.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = DGL2.CurrentCell.RowIndex
            mColumnIndex = DGL2.CurrentCell.ColumnIndex

            If DGL2.Item(mColumnIndex, mRowIndex).Value Is Nothing Then DGL2.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case DGL2.CurrentCell.ColumnIndex
                Case Col2SubjectCode
                    If DGL2.Item(mColumnIndex, mRowIndex).Value.ToString.Trim = "" Or DGL2.AgSelectedValue(mColumnIndex, mRowIndex).Trim = "" Then
                        DGL2.Item(Col2SubjectType, mRowIndex).Value = ""
                    Else
                        If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                            With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                                DGL2.Item(Col2SubjectType, mRowIndex).Value = AgL.XNull(.Item("Subject Type", .CurrentCell.RowIndex).Value)
                            End With
                        End If
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded, DGL2.RowsAdded, DGL3.RowsAdded
        sender(Col_SNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved, DGL2.RowsRemoved, DGL3.RowsRemoved
        Try
            DTStruct.Rows.Remove(DTStruct.Rows.Item(e.RowIndex))
        Catch ex As Exception
        End Try
        AgL.FSetSNo(sender, 0)

        Call Calculation()
    End Sub

    Private Sub DGL3_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGL3.CellContentClick
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim OpenPicDialogBox As OpenFileDialog
        Dim ImagePath$ = "", sFilePath As String = ""
        Dim bBlnNewImageFlag As Boolean = False
        Dim fByte As Byte() = Nothing
        Try
            mRowIndex = DGL3.CurrentCell.RowIndex
            mColumnIndex = DGL3.CurrentCell.ColumnIndex

            Select Case DGL3.Columns(DGL3.CurrentCell.ColumnIndex).Name
                Case Col3BtnAttachment
                    If DGL3.Item(Col3ByteArray, mRowIndex).Value Is Nothing Then DGL3.Item(Col3ByteArray, mRowIndex).Value = ""
                    If DGL3.Item(Col3FileName, mRowIndex).Value Is Nothing Then DGL3.Item(Col3FileName, mRowIndex).Value = ""

                    If DGL3.Item(Col3ByteArray, mRowIndex).Value.ToString.Trim <> "" Then
                        bBlnNewImageFlag = False
                        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then
                            If AgL.XNull(DGL3.Item(Col3FileName, mRowIndex).Value).ToString.Trim <> "" Then
                                sFilePath = Environment.GetFolderPath(Environment.SpecialFolder.Cookies) + "\" + DGL3.Item(Col3FileName, mRowIndex).Value.ToString
                                Call SaveToFile(sFilePath, DGL3.Item(Col3ByteArray, mRowIndex).Value)
                                System.Diagnostics.Process.Start(sFilePath)
                            End If

                        Else
                            If MsgBox("Want To Change Image?", MsgBoxStyle.YesNo + MsgBoxStyle.Question + MsgBoxStyle.DefaultButton2) = MsgBoxResult.Yes Then
                                bBlnNewImageFlag = True
                            End If
                        End If
                    Else
                        If Not AgL.StrCmp(Topctrl1.Mode, "Browse") Then bBlnNewImageFlag = True
                    End If

                    If bBlnNewImageFlag Then
                        OpenPicDialogBox = New OpenFileDialog

                        OpenPicDialogBox.Title = "Set Image File"
                        OpenPicDialogBox.Filter = "PDF Files(*.pdf)|*.pdf"

                        ImagePath = My.Application.Info.DirectoryPath
                        OpenPicDialogBox.InitialDirectory = ImagePath
                        OpenPicDialogBox.DefaultExt = "*.pdf"
                        OpenPicDialogBox.FilterIndex = 1

                        OpenPicDialogBox.FileName = ""

                        If OpenPicDialogBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub


                        sFilePath = OpenPicDialogBox.FileName
                        If OpenPicDialogBox.FileName.ToString.Trim = "" Then
                            DGL3.Item(Col3FileName, mRowIndex).Value = ""
                        Else
                            DGL3.Item(Col3FileName, mRowIndex).Value = AgL.MidStr(OpenPicDialogBox.FileName, InStrRev(OpenPicDialogBox.FileName, "\"), OpenPicDialogBox.FileName.Length - InStrRev(OpenPicDialogBox.FileName, "\"))
                        End If

                    End If

                    If bBlnNewImageFlag = True Then
                        If sFilePath = "" Then Exit Sub

                        fByte = GetFromFile(sFilePath)
                        DGL3.Item(Col3ByteArray, mRowIndex).Value = fByte
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        If TxtIsTeachingStaff.Text = "Yes" Then
            txtCanTakeClass.Text = "Yes"
        End If
        'With DGL1
        '    For I = 0 To .Rows.Count - 1
        '        If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""

        '        If .Item(Col1Fee, I).Value <> "" Then
        '            .Item(Col1NetAmount, I).Value = Format(Val(.Item(Col1Amount, I).Value) - Val(.Item(Col1Discount, I).Value), "0.00")
        '        End If
        '    Next
        'End With
    End Sub

    Public Function GetFromFile(ByVal filePath As String) As Byte()

        If Not File.Exists(filePath) Then Return Nothing

        Dim fs As New FileStream(filePath, FileMode.Open, FileAccess.Read)

        Dim br As New BinaryReader(fs)

        Dim fByte As Byte() = br.ReadBytes(CInt(fs.Length))

        br.Close() : fs.Close()

        Return fByte

    End Function

    Public Sub SaveToFile(ByVal filePath As String, ByVal bFile As Byte())
        Dim fs As New FileStream(filePath, FileMode.Create)

        Dim bw As New BinaryWriter(fs)

        bw.Write(bFile)

        bw.Flush() : bw.Close() : bw = Nothing

        fs.Close() : fs = Nothing

    End Sub

    Private Function FunCreateLibraryMemberStructure(ByRef ObjStructLibraryMember As ClsMain.StructLibraryMember, ByRef BlnIsMemberExists As Boolean) As Boolean
        Dim bBlnRerurn As Boolean = False
        Dim DrTemp As DataRow() = Nothing
        Dim bDtMember As DataTable = Nothing
        Try
            ObjStructLibraryMember = New ClsMain.StructLibraryMember()
            ObjStructLibraryMember.ProcBlankStruct()


            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                BlnIsMemberExists = False
            Else
                mQry = "SELECT M.* FROM Lib_Member M With (NoLock) WHERE M.SubCode = " & AgL.Chk_Text(mSearchCode) & " "
                bDtMember = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

                If bDtMember.Rows.Count > 0 Then
                    BlnIsMemberExists = True
                Else
                    BlnIsMemberExists = False
                End If
            End If

            With ObjStructLibraryMember
                .StrSubCode = mSearchCode
                .StrStuent = ""
                .StrEmployee = mSearchCode
                .StrMemberType = TxtLibraryMemberType.AgSelectedValue
                .StrAdmissionNo = ""
                .StrMotherName = TxtMotherName.Text
                .StrManualCode = TxtManualCode.Text
                .StrClass = ""
                .StrSession = ""
                .StrSiteCode = TxtlibrarySite.AgSelectedValue

                If BlnIsMemberExists Then
                    .StrUID = AgL.XNull(bDtMember.Rows(0)("UID").ToString)

                    If Not (AgL.StrCmp(.StrClass, AgL.XNull(bDtMember.Rows(0)("Class"))) _
                        And AgL.StrCmp(.StrSession, AgL.XNull(bDtMember.Rows(0)("Session")))) _
                        Or AgL.XNull(bDtMember.Rows(0)("MemberCardNo")).ToString.Trim = "" Then

                        .StrMemberCardNo = mObjClsMain.FunGetMemberCardNo(.StrClass, .StrSession, .StrManualCode)
                    Else
                        .StrMemberCardNo = AgL.XNull(bDtMember.Rows(0)("MemberCardNo"))
                    End If
                Else
                    .StrMemberCardNo = mObjClsMain.FunGetMemberCardNo(.StrClass, .StrSession, .StrManualCode)
                End If
            End With

            bBlnRerurn = True
        Catch ex As Exception
            bBlnRerurn = False
        Finally
            FunCreateLibraryMemberStructure = bBlnRerurn
        End Try
    End Function

    
End Class