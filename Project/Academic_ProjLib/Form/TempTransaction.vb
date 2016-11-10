Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class TempTransaction
    Public Event BaseFunction_MoveRec(ByVal SearchCode As String)
    Public Event BaseFunction_PostMoveRec(ByVal SearchCode As String)
    Public Event BaseFunction_IniGrid()
    Public Event BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte)
    Public Event BaseFunction_FIniList()
    Public Event BaseEvent_Data_Validation(ByRef Passed As Boolean)
    Public Event BaseFunction_CreateHelpDataSet()

    Public Event BaseFunction_Calculation()
    Public Event BaseFunction_BlankText()
    Public Event BaseFunction_DispText(ByVal Enb As Boolean)

    Public Event BaseEvent_Find()
    Public Event BaseEvent_Form_PreLoad()
    Public Event BaseEvent_Save_PreTrans(ByVal SearchCode As String)
    Public Event BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
    Public Event BaseEvent_Save_PostTrans(ByVal SearchCode As String)
    Public Event BaseEvent_Approve_PreTrans(ByVal SearchCode As String)
    Public Event BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
    Public Event BaseEvent_Approve_PostTrans(ByVal SearchCode As String)
    Public Event BaseEvent_Topctrl_tbAdd()
    Public Event BaseEvent_Topctrl_tbEdit()
    Public Event BaseEvent_Delete_PreTrans(ByVal SearchCode As String)
    Public Event BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
    Public Event BaseEvent_Delete_PostTrans(ByVal SearchCode As String)
    Public Event BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String)
    Public Event BaseEvent_Topctrl_tbRef()
    Public Event BaseEvent_Topctrl_tbDiscard()


    Public DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable

    Dim mAglObj As AgLibrary.ClsMain

    Dim mQry As String = ""
    Public mSearchCode As String = ""
    Dim mBlnIsApproved As Boolean = False

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode


    Dim mNCatList As String
    Dim mMainTableName As String
    Dim mMainLineTableCSV As String
    Dim ArrMainLineTable As String()

    Dim _FormType As eFormType
    Dim _BlnIsApprovalApply As Boolean = False

    Public Enum eFormType
        Main
        Approved
    End Enum

    Public Property AglObj() As AgLibrary.ClsMain
        Get
            AglObj = mAglObj
        End Get
        Set(ByVal value As AgLibrary.ClsMain)
            mAglObj = value
        End Set
    End Property

    Public Property FormType() As eFormType
        Get
            FormType = _FormType
        End Get
        Set(ByVal value As eFormType)
            _FormType = value

            If _FormType = eFormType.Approved Then
                If _BlnIsApprovalApply = False Then Me.BlnIsApprovalApply = True
            End If
        End Set
    End Property

    Public Property BlnIsApprovalApply() As Boolean
        Get
            Return _BlnIsApprovalApply
        End Get
        Set(ByVal value As Boolean)
            _BlnIsApprovalApply = value
        End Set
    End Property


    Public Property EntryNCatList() As String
        Get
            Return mNCatList
        End Get
        Set(ByVal value As String)
            mNCatList = value
        End Set
    End Property


    Public Property MainLineTableCsv() As String
        Get
            Return mMainLineTableCSV
        End Get
        Set(ByVal value As String)
            mMainLineTableCSV = value

            ArrMainLineTable = Split(mMainLineTableCSV, ",")
        End Set
    End Property


    Public Property MainTableName() As String
        Get
            Return mMainTableName
        End Get
        Set(ByVal value As String)
            mMainTableName = value
        End Set
    End Property

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Public Sub IniGrid()
        RaiseEvent BaseFunction_IniGrid()
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

            'If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgLObj.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            '----------------------------------------------------------
            '-----This Event will Contain TableName Property Assignment
            '----------------------------------------------------------
            RaiseEvent BaseEvent_Form_PreLoad()
            '----------------------------------------------------------
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            CreateHelpDataSets()
            IniGrid()
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
            AglObj.WinSetting(Me, 650, 1000, 0, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        RaiseEvent BaseFunction_FIniMast(BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()
        Try
            mQry = "Select V_Type as Code, Description, NCat From Voucher_Type With (NoLock) Where NCat In (" & mNCatList & ") "
            TxtV_Type.AgHelpDataSet(1, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = AglObj.FillData(mQry, AglObj.GCn)

            mQry = "Select Div_Code, Div_Name From Division  With (NoLock) Order By Div_Name"
            TxtDivision.AgHelpDataSet = AglObj.FillData(mQry, GcnRead)

            mQry = "Select Code, ManualCode, Name, Active From SiteMast  With (NoLock)  Order By ManualCode"
            TxtSite_Code.AgHelpDataSet(2, Tc1.Top + TP1.Top, Tc1.Left + TP1.Left) = AglObj.FillData(mQry, GcnRead)

            RaiseEvent BaseFunction_FIniList()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try
    End Sub

    Private Sub CreateHelpDataSets()
        RaiseEvent BaseFunction_CreateHelpDataSet()
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)

        TxtSite_Code.AgSelectedValue = AglObj.PubSiteCode
        TxtDivision.AgSelectedValue = AgLObj.PubDivCode

        TxtV_Date.Text = AglObj.PubLoginDate
        TxtV_Date.Text = AglObj.RetFinancialYearDate(TxtV_Date.Text.ToString)
        TxtV_Date.Focus()
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

                    RaiseEvent BaseEvent_Delete_PreTrans(mSearchCode)

                    AglObj.ECmd = AglObj.GCn.CreateCommand
                    AglObj.ETrans = AglObj.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AglObj.ECmd.Transaction = AglObj.ETrans
                    mTrans = True

                    RaiseEvent BaseEvent_Topctrl_tbDel(mSearchCode, AglObj.GCn, AglObj.ECmd)

                    Call AglObj.LogTableEntry(mSearchCode, Me.Text, "D", AglObj.PubMachineName, AglObj.PubUserName, AglObj.PubLoginDate, AglObj.GCn, AglObj.ECmd)

                    AglObj.SynchroniseSiteOnLineData(AglObj, AglObj.GCn, AglObj.Gcn_ConnectionString, AglObj.GcnSite_ConnectionString, AglObj.ECmd)

                    AglObj.ETrans.Commit()
                    mTrans = False

                    RaiseEvent BaseEvent_Delete_PostTrans(mSearchCode)

                    FIniMaster(1)
                    Topctrl1_tbRef()
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AgLObj.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()

        RaiseEvent BaseEvent_Topctrl_tbDiscard()
    End Sub


    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtV_Date.Focus()
        RaiseEvent BaseEvent_Topctrl_tbEdit()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try
            RaiseEvent BaseEvent_Find()


            '*************** common code start *****************
            AglObj.PubObjFrmFind = New AgLibrary.frmFind(AglObj)
            AgLObj.PubObjFrmFind.ShowDialog()
            AgLObj.PubObjFrmFind = Nothing
            If AgLObj.PubSearchRow <> "" Then
                AgLObj.PubDRFound = DTMaster.Rows.Find(AgLObj.PubSearchRow)
                BMBMaster.Position = DTMaster.Rows.IndexOf(AgLObj.PubDRFound)
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        CreateHelpDataSets()
        Ini_List()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        RaiseEvent BaseEvent_Topctrl_tbPrn(mSearchCode)
    End Sub


    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim bApprovedDate = ""

        Try
            MastPos = BMBMaster.Position

            bApprovedDate = AglObj.GetDateTime(AglObj.GcnRead)
            '---------------------------------------------------
            'Any type of validation like Required field, Duplicate Check etc.
            'are to be write in Data_Validation function.
            '----------------------------------------------------
            If Data_Validation() = False Then Exit Sub
            '----------------------------------------------------

            RaiseEvent BaseEvent_Save_PreTrans(mSearchCode)

            AgLObj.ECmd = AgLObj.GCn.CreateCommand
            AgLObj.ETrans = AgLObj.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgLObj.ECmd.Transaction = AgLObj.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO " & mMainTableName & " (DocId, Div_Code, Site_Code, V_Date, V_Type, " & _
                        " V_Prefix, V_No, PreparedBy, U_EntDt, U_AE) " & _
                        " VALUES (" & _
                        " " & AglObj.Chk_Text(mSearchCode) & ", '" & TxtDivision.AgSelectedValue & "',  " & _
                        " " & AglObj.Chk_Text(TxtSite_Code.AgSelectedValue) & "," & AglObj.ConvertDate(TxtV_Date.Text) & ", " & _
                        " " & AglObj.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AglObj.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ", " & _
                        " " & AglObj.Chk_Text(AglObj.PubUserName) & ", " & AglObj.Chk_Text(AglObj.GetDateTime(AglObj.GcnRead)) & ", 'A')"

                AgLObj.Dman_ExecuteNonQry(mQry, AgLObj.GCn, AgLObj.ECmd)
            Else
                mQry = "Update " & mMainTableName & " Set " & _
                        " V_Date = " & AgLObj.ConvertDate(TxtV_Date.Text) & ", " & _
                        " V_Prefix = " & AgLObj.Chk_Text(LblPrefix.Text) & ", " & _
                        " V_No = " & Val(TxtV_No.Text) & ", " & _
                        " ModifiedBy = " & AgLObj.Chk_Text(AgLObj.PubUserName) & ", " & _
                        " Edit_Date = " & AgLObj.Chk_Text(AgLObj.GetDateTime(AgLObj.GcnRead)) & ", " & _
                        " U_AE = 'E' " & _
                        " Where DocId = " & AgLObj.Chk_Text(mSearchCode) & " "

                AgLObj.Dman_ExecuteNonQry(mQry, AgLObj.GCn, AgLObj.ECmd)

            End If

            RaiseEvent BaseEvent_Save_InTrans(mSearchCode, AgLObj.GCn, AgLObj.ECmd)


            AglObj.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AglObj.GCn, AglObj.ECmd, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, False)

            '--------------------------------------------------------------
            'Create a log entry of each activity like add, edit delete print
            '--------------------------------------------------------------
            Call AgLObj.LogTableEntry(mSearchCode, Me.Text, AgLObj.MidStr(Topctrl1.Mode, 0, 1), AgLObj.PubMachineName, AgLObj.PubUserName, AgLObj.PubLoginDate, AgLObj.GCn, AgLObj.ECmd, , TxtV_Date.Text, , , , TxtSite_Code.AgSelectedValue, TxtDivision.AgSelectedValue)
            '--------------------------------------------------------------

            AglObj.SynchroniseSiteOnLineData(AglObj, AglObj.GCn, AglObj.Gcn_ConnectionString, AglObj.GcnSite_ConnectionString, AglObj.ECmd)

            'Start Code By Satyam on 01/08/2011
            If FormType = eFormType.Main And BlnIsApprovalApply = False Then
                Call ProcApproveVoucher(AglObj.PubUserName, bApprovedDate)
            End If
            'End Code By Satyam on 01/08/2011

            AgLObj.ETrans.Commit()
            mTrans = False


            RaiseEvent BaseEvent_Save_PostTrans(mSearchCode)


            FIniMaster(0, 1)
            Topctrl1_tbRef()



            If Topctrl1.Mode = "Add" Then
                '--------------------------------------------------------
                'Set newly feeded record as current record
                'go to add mode once again
                '--------------------------------------------------------

                Topctrl1.LblDocId.Text = mSearchCode

                mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

                Topctrl1.FButtonClick(0)
                Exit Sub
            Else
                mTmV_Type = "" : mTmV_Prefix = "" : mTmV_Date = "" : mTmV_NCat = ""

                Topctrl1.SetDisp(True)
                If AgLObj.PubMoveRecApplicable Then MoveRec()
            End If



        Catch ex As Exception
            If mTrans = True Then AgLObj.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub




    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Dim GcnRead As SqlClient.SqlConnection = AglObj.FunGetReadConnection()

        Try
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position

                mSearchCode = DTMaster.Rows(MastPos)("SearchCode").ToString

                mQry = "Select T.DocID, T.Div_Code, T.Site_Code, T.V_Type, T.V_Prefix, T.V_No, T.V_Date, " & _
                        " T.PreparedBy, T.U_EntDt, T.U_AE, T.Edit_Date, T.ModifiedBy, T.ApprovedBy, T.ApprovedDate " & _
                        " From " & mMainTableName & " As T With (NoLock) " & _
                        " Where T.DocId='" & mSearchCode & "'"
                DsTemp = AglObj.FillData(mQry, GcnRead)
                With DsTemp.Tables(0)
                    '---------------------------------------------------
                    'Common code for all entry and approval management
                    '---------------------------------------------------
                    TxtDocId.Text = AgLObj.XNull(.Rows(0)("DocID"))
                    TxtV_Type.AgSelectedValue = AgLObj.XNull(.Rows(0)("V_Type"))

                    Validating_VType(TxtV_Type)
                    LblPrefix.Text = AglObj.XNull(.Rows(0)("V_Prefix"))
                    TxtSite_Code.AgSelectedValue = AglObj.XNull(.Rows(0)("Site_Code"))
                    TxtDivision.AgSelectedValue = AgLObj.XNull(.Rows(0)("Div_Code"))
                    TxtV_No.Text = AgLObj.VNull(.Rows(0)("V_No"))
                    TxtV_Date.Text = AgLObj.XNull(.Rows(0)("V_Date"))

                    If AglObj.XNull(.Rows(0)("ApprovedDate")).ToString.Trim <> "" Then
                        mBlnIsApproved = True
                    Else
                        mBlnIsApproved = False
                    End If

                    TxtApproved.Text = AgLObj.XNull(.Rows(0)("ApprovedBy"))
                    TxtPrepared.Text = AgLObj.XNull(.Rows(0)("PreparedBy"))
                    TxtModified.Text = AgLObj.XNull(.Rows(0)("ModifiedBy"))
                    GBoxModified.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                    '---------------------------------------------------
                End With

                RaiseEvent BaseFunction_MoveRec(mSearchCode)
            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)

            RaiseEvent BaseFunction_PostMoveRec(mSearchCode)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DsTemp IsNot Nothing Then DsTemp.Dispose()
            If GcnRead IsNot Nothing Then GcnRead.Dispose()
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : mBlnIsApproved = False
        RaiseEvent BaseFunction_BlankText()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False

        If AgLObj.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False
        End If

        If BlnIsApprovalApply Then
            If FormType = eFormType.Approved Then
                GBoxApproved.Visible = True
                Topctrl1.tAdd = False : Topctrl1.tEdit = False
            ElseIf FormType = eFormType.Main Then
                GBoxApproved.Visible = True
            End If
        End If

        RaiseEvent BaseFunction_DispText(Enb)
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
                    End If

                    If mBlnIsApproved Then
                        MsgBox("Record is already Approved!...", MsgBoxStyle.Information)
                        Err.Raise(1, , "")
                    End If


                    If mSearchCode <> "" Then
                        RaiseEvent BaseEvent_Approve_PreTrans(mSearchCode)

                        ''=======================Approval Start======================================

                        TxtApproved.Text = AgLObj.PubUserName
                        mApprovedDate = AgLObj.GetDateTime(AgLObj.GCn)

                        AgLObj.ECmd = AgLObj.GCn.CreateCommand
                        AgLObj.ETrans = AgLObj.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                        AgLObj.ECmd.Transaction = AgLObj.ETrans
                        mTrans = True


                        Call ProcApproveVoucher(TxtApproved.Text, mApprovedDate)

                        ''===========================================================================

                        AglObj.SynchroniseSiteOnLineData(AglObj, AglObj.GCn, AglObj.Gcn_ConnectionString, AglObj.GcnSite_ConnectionString, AglObj.ECmd)
                        AgLObj.ETrans.Commit()
                        mTrans = False

                        RaiseEvent BaseEvent_Approve_PostTrans(mSearchCode)

                        MsgBox("Voucher Approved Successfully.", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                        If AgLObj.PubMoveRecApplicable Then
                            FIniMaster(0, 1) : Topctrl1_tbRef()
                        End If
                        MoveRec()
                    End If

                Catch ex As Exception
                    If mTrans = True Then AglObj.ETrans.Rollback()
                    If ex.Message.Trim <> "" Then
                        MsgBox(ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                    End If
                End Try
        End Select
    End Sub

    Private Sub ProcApproveVoucher(ByVal StrApprovedBy As String, ByVal StrApprovedDate As String)

        mQry = "Update " & mMainTableName & " Set ApprovedBy='" & StrApprovedBy & "', ApprovedDate=" & AglObj.Chk_Text(StrApprovedDate) & " Where DocId='" & mSearchCode & "' "
        AgLObj.Dman_ExecuteNonQry(mQry, AgLObj.GCn, AgLObj.ECmd)

        RaiseEvent BaseEvent_Approve_InTrans(mSearchCode, AgLObj.GCn, AgLObj.ECmd)

        Call AgLObj.LogTableEntry(mSearchCode, Me.Text, AgLibrary.ClsConstant.EntryMode_Varified, AgLObj.PubMachineName, AgLObj.PubUserName, AgLObj.PubLoginDate, AgLObj.GCn, AgLObj.ECmd, , TxtV_Date.Text, , , , TxtSite_Code.AgSelectedValue, TxtDivision.AgSelectedValue)
    End Sub

    Sub Calculation()
        RaiseEvent BaseFunction_Calculation()
    End Sub


    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtDocId.Validating, TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_Date.Validating, TxtV_No.Validating

        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    Validating_VType(sender)

                Case TxtV_Date.Name
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgLObj.PubLoginDate
                    TxtV_Date.Text = AgLObj.RetFinancialYearDate(TxtV_Date.Text.ToString)
            End Select

            Call Calculation()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DtTemp IsNot Nothing Then DtTemp.Dispose()
        End Try
    End Sub

    Public Sub Validating_VType(ByVal Sender As Object)
        Dim DrTemp As DataRow() = Nothing

        If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
            LblV_Type.Tag = ""
        Else
            If Sender.AgHelpDataSet IsNot Nothing Then
                DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgLObj.Chk_Text(Sender.AgSelectedValue) & "")
                LblV_Type.Tag = AgLObj.XNull(DrTemp(0)("NCat"))
            End If
        End If

    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = ""
        Try
            Dim ChildDataPassed As Boolean = True

            Call Calculation()
            If AglObj.RequiredField(TxtSite_Code, "Site/Branch") Then Exit Function
            If AgLObj.RequiredField(TxtV_Type, LblV_Type.Text) Then Exit Function
            If AgLObj.RequiredField(TxtV_Date, LblV_Date.Text) Then Exit Function
            If Not AgLObj.IsValidDate(TxtV_Date, AgLObj.PubStartDate, AgLObj.PubEndDate) Then Exit Function


            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AglObj.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AglObj.GCn, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AglObj.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AglObj.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mSearchCode <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                    TxtDocId.Text = mSearchCode
                End If
            End If

            RaiseEvent BaseEvent_Data_Validation(ChildDataPassed)
            If ChildDataPassed Then
                Data_Validation = True
            Else
                Data_Validation = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Public Overridable Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)

        TxtSite_Code.AgSelectedValue = AglObj.PubSiteCode
        TxtDivision.AgSelectedValue = AglObj.PubDivCode

        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AglObj.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            TxtV_Type.Enabled = True
        End If

        TxtV_Date.Text = AglObj.PubLoginDate
        TxtV_Date.Text = AglObj.RetFinancialYearDate(TxtV_Date.Text.ToString)

        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled = True Then TxtV_Type.Focus()
        End If

        '==================================================================================================================================================================================
        '==============< Raise Add Event >=================================================================================================================================================
        '===================< Start >=================================================================================================================================================
        '==================================================================================================================================================================================
        RaiseEvent BaseEvent_Topctrl_tbAdd()
        '==================================================================================================================================================================================
        '==============< Raise Add Event >=================================================================================================================================================
        '===================< End >=================================================================================================================================================
        '==================================================================================================================================================================================


        If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" And TxtDivision.Text.Trim <> "" Then
            mSearchCode = AglObj.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AglObj.GCn, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue)
            TxtDocId.Text = mSearchCode
            TxtV_No.Text = Val(AglObj.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
            LblPrefix.Text = AglObj.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
        End If
    End Sub

    Public Sub FindMove(ByVal bDocId As String)
        Try
            If bDocId <> "" Then
                AglObj.PubSearchRow = bDocId
                If AglObj.PubMoveRecApplicable Then
                    AglObj.PubDRFound = DTMaster.Rows.Find(AglObj.PubSearchRow)
                    BMBMaster.Position = DTMaster.Rows.IndexOf(AglObj.PubDRFound)
                End If
                Call MoveRec()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub
End Class