Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class TempParty
    Public Event BaseFunction_MoveRec(ByVal SearchCode As String)
    Public Event BaseFunction_IniGrid()
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
    Public Event BaseEvent_Topctrl_tbDel(ByVal SearchCode As String, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
    Public Event BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String)
    Public Event BaseEvent_Topctrl_tbRef()
    Public Event BaseEvent_Topctrl_tbDiscard()

    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""


    Dim mParty_Type As Integer = 0
    Dim mGroupNature$ = "", mNature$ = ""
    Dim _StrMasterType$ = "", _StrMsCode$ = ""

    Dim mAglObj As AgLibrary.ClsMain
    Dim _FormType As eFormType
    Dim _BlnIsApprovalApply As Boolean = False
    Dim _StrSalesTaxPostingGroup As String = ""
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

    Public Property SalesTaxPostingGroup() As String
        Get
            SalesTaxPostingGroup = _StrSalesTaxPostingGroup
        End Get
        Set(ByVal value As String)
            _StrSalesTaxPostingGroup = value
        End Set
    End Property

#Region "SubGroup Properties"
    Public Property MsCode() As String
        Get
            MsCode = _StrMsCode
        End Get
        Set(ByVal value As String)
            _StrMsCode = value
        End Set
    End Property

    Public Property Party_Type() As Integer
        Get
            Party_Type = mParty_Type
        End Get
        Set(ByVal value As Integer)
            mParty_Type = value

            If mParty_Type = 0 Then mParty_Type = AgLibrary.ClsConstant.SubGroupType_Other
        End Set
    End Property

    Public Property MasterType() As String
        Get
            MasterType = _StrMasterType
        End Get
        Set(ByVal value As String)
            _StrMasterType = value
        End Set
    End Property
#End Region

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        Try
            RaiseEvent BaseFunction_IniGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
        AglObj.CheckQuote(e)
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
            'AglObj.WinSetting(Me, 500, 1000, 0, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim bCondStr$ = " Where 1=1 "

        bCondStr += " And IsNull(H.Party_Type,0) = " & mParty_Type & " "
        bCondStr += " And " & AglObj.PubSiteConditionCommonAc(AglObj.PubIsHo, "Site_Code", AglObj.PubSiteCode, "CommonAc") & " "

        If MasterType.Trim <> "" Then
            bCondStr += " And IsNull(P.MasterType,'') = '" & MasterType & "' "
        End If

        If BlnIsApprovalApply Then
            If FormType = eFormType.Main Then
                bCondStr += " And H.ApprovedDate Is Null "
            ElseIf FormType = eFormType.Approved Then
                bCondStr += " And H.ApprovedDate Is Not Null "
            End If
        End If

        mQry = "Select H.SubCode As SearchCode " & _
                " From Party P With (NoLock) " & _
                " Left Join SubGroup H With (NoLock) On H.SubCode = P.SubCode " & _
                " " & bCondStr & " "
        Topctrl1.FIniForm(DTMaster, AglObj.GcnRead, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast  With (NoLock) " & _
                            " Where " & AglObj.PubSiteCondition("Code", AglObj.PubSiteCode) & " Order By Name"
            TxtSite_Code.AgHelpDataSet = AglObj.FillData(mQry, AglObj.GcnRead)

            mQry = "Select Div_Code, Div_Name From Division  With (NoLock) Order By Div_Name"
            TxtDivision.AgHelpDataSet = AglObj.FillData(mQry, AglObj.GcnRead)

            mQry = "Select SubCode  As Code, Name As Name " & _
                    " From SubGroup  With (NoLock) " & _
                    " Where " & AglObj.PubSiteConditionCommonAc(AglObj.PubIsHo, "Site_Code", AglObj.PubSiteCode, "CommonAc") & " " & _
                    " Order By Name"
            TxtName.AgHelpDataSet = AglObj.FillData(mQry, AglObj.GcnRead)

            mQry = "Select Distinct DispName As Code, DispName As Name " & _
                    " From SubGroup  With (NoLock) " & _
                    " Where " & AglObj.PubSiteConditionCommonAc(AglObj.PubIsHo, "Site_Code", AglObj.PubSiteCode, "CommonAc") & " " & _
                    " And IsNull(DispName,'') <> '' " & _
                    " Order By DispName"
            TxtDispName.AgHelpDataSet = AglObj.FillData(mQry, AglObj.GcnRead)

            mQry = "Select ManualCode As Code, ManualCode As Name " & _
                    " From SubGroup  With (NoLock) " & _
                    " Where IsNull(ManualCode,'')<>'' Order By ManualCode"
            TxtManualCode.AgHelpDataSet = AglObj.FillData(mQry, AglObj.GcnRead)


            mQry = "Select CityCode As Code, CityName As Name From City  With (NoLock) " & _
                " Order By CityName"
            TxtCityCode.AgHelpDataSet = AglObj.FillData(mQry, AglObj.GcnRead)

            mQry = "Select Distinct FatherNamePrefix  As Code, FatherNamePrefix As Name From SubGroup With (NoLock)  " & _
                    " Where IsNull(FatherNamePrefix,'')<>'' " & _
                    " Order By FatherNamePrefix"
            TxtFatherNamePrefix.AgHelpDataSet = AglObj.FillData(mQry, AglObj.GcnRead)

            mQry = "SELECT P.Description AS Code, P.Description AS Name, " & _
                    " IsNull(P.Active,0) AS Active " & _
                    " FROM PostingGroupSalesTaxParty P With (NoLock)" & _
                    " Order By P.Description "
            TxtSalesTaxPostingGroup.AgHelpDataSet(1) = AglObj.FillData(mQry, AglObj.GcnRead)

            Call IniAcGroupHelp()

            RaiseEvent BaseFunction_FIniList()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IniAcGroupHelp()
        Dim bCondStr$ = " Where 1=1 "
        Try
            bCondStr += " And AliasYn = 'N' "

            If MsCode.Trim = "" Then
                bCondStr += " And LEFT(MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") in ('" & AgLibrary.ClsConstant.MainGRCodeSundryCreditors & "' , '" & AgLibrary.ClsConstant.MainGRCodeSundryDebtors & "') " & _
                            " AND MainGrLen >= " & AgLibrary.ClsConstant.MainGRLenSundryCreditors & " "
            Else

                bCondStr += " And LEFT(MainGrCode," & MsCode.Length & ") = '" & MsCode & "' " & _
                            " AND MainGrLen >= " & MsCode.Length & " "
            End If

            mQry = "SELECT A.GroupCode AS Code, A.GroupName AS Name, A.GroupNature , A.Nature  " & _
                      " FROM AcGroup A With (NoLock) " & bCondStr
            TxtAcGroup.AgHelpDataSet(2) = AglObj.FillData(mQry, AglObj.GcnRead)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateHelpDataSets()
        RaiseEvent BaseFunction_CreateHelpDataSet()
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AglObj.PubSiteCode
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
                    AglObj.ECmd = AglObj.GCn.CreateCommand
                    AglObj.ETrans = AglObj.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AglObj.ECmd.Transaction = AglObj.ETrans
                    mTrans = True

                    RaiseEvent BaseEvent_Topctrl_tbDel(mSearchCode, AglObj.GCn, AglObj.ECmd)

                    AglObj.Dman_ExecuteNonQry("Delete From Party Where SubCode='" & mSearchCode & "'", AglObj.GCn, AglObj.ECmd)
                    AglObj.Dman_ExecuteNonQry("Delete From SubGroup Where SubCode='" & mSearchCode & "'", AglObj.GCn, AglObj.ECmd)

                    Call AglObj.LogTableEntry(mSearchCode, Me.Text, "D", AglObj.PubMachineName, AglObj.PubUserName, AglObj.PubLoginDate, AglObj.GCn, AglObj.ECmd, , , mSearchCode, mParty_Type, TxtSite_Code.AgSelectedValue, AglObj.PubDivCode)

                    AglObj.SynchroniseSiteOnLineData(AglObj, AglObj.GCn, AglObj.Gcn_ConnectionString, AglObj.GcnSite_ConnectionString, AglObj.ECmd)

                    AglObj.ETrans.Commit()
                    mTrans = False
                    FIniMaster(1)
                    Topctrl1_tbRef()
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then AglObj.ETrans.Rollback()
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
        TxtManualCode.Focus()

        RaiseEvent BaseEvent_Topctrl_tbEdit()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        'Dim bCondStr$ = " Where 1=1 "

        'bCondStr += " And IsNull(H.Party_Type,0) = " & mParty_Type & " "
        'bCondStr += " And " & AglObj.PubSiteConditionCommonAc(AglObj.PubIsHo, "Site_Code", AglObj.PubSiteCode, "CommonAc") & " "

        'If MasterType.Trim <> "" Then
        '    bCondStr += " And IsNull(P.MasterType,'') = '" & MasterType & "' "
        'End If

        Try
            RaiseEvent BaseEvent_Find()

            'AglObj.PubFindQry = "Select  H.SubCode As SearchCode, H.ManualCode As [" & LblManualCode.Text & "], H.Name As [" & LblName.Text & "],  H.DispName As [" & LblDispName.Text & "], " & _
            '                    " IsNull(H.Add1,'') + Space(1) +  IsNull(H.Add2,'') + Space(1) + IsNull(H.Add3,'') As [" & LblAdd1.Text & "],  City.CityName As [" & LblCityCode.Text & "], " & _
            '                    " H.Phone As [Phone No.],  H.Mobile As [Mobile No.] " & _
            '                    " From Party P With (NoLock) " & _
            '                    " Left Join SubGroup H With (NoLock) On H.SubCode = P.SubCode " & _
            '                    " Left Join  City  With (NoLock) On City.CityCode = H.CityCode " & _
            '                    " " & bCondStr & " "
            'AglObj.PubFindQryOrdBy = "[" & LblName.Text & "]"




            '*************** common code start *****************
            AglObj.PubObjFrmFind = New AgLibrary.frmFind(AglObj)
            AglObj.PubObjFrmFind.ShowDialog()
            AglObj.PubObjFrmFind = Nothing
            If AglObj.PubSearchRow <> " Then" Then
                AglObj.PubDRFound = DTMaster.Rows.Find(AglObj.PubSearchRow)
                BMBMaster.Position = DTMaster.Rows.IndexOf(AglObj.PubDRFound)
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        RaiseEvent BaseEvent_Topctrl_tbPrn(mSearchCode)
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        CreateHelpDataSets()
        Ini_List()
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


            AglObj.ECmd = AglObj.GCn.CreateCommand
            AglObj.ETrans = AglObj.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AglObj.ECmd.Transaction = AglObj.ETrans
            mTrans = True

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AglObj.CreateSubGroup(AglObj, AglObj.GCn, AglObj.ECmd, AglObj.Gcn_ConnectionString, TxtDispName.Text, TxtManualCode.Text, TxtAcGroup.AgSelectedValue, mGroupNature, mNature, mParty_Type, TxtSite_Code.AgSelectedValue)
                If mSearchCode.Trim = "" Then Err.Raise(1, , "Fatel Error!" & vbCrLf & "Error In SubCode Generation!")
            Else
                mQry = "Update SubGroup " & _
                        " Set " & _
                        " U_AE='E', " & _
                        " Edit_Date='" & Format(AglObj.PubLoginDate, "Short Date") & "', " & _
                        " ModifiedBy = '" & AglObj.PubUserName & "' " & _
                        " Where SubCode='" & mSearchCode & "' "
                AglObj.Dman_ExecuteNonQry(mQry, AglObj.GCn, AglObj.ECmd)
            End If

            mQry = "Update SubGroup Set Name = " & AglObj.Chk_Text(TxtName.Text) & ", DispName = " & AglObj.Chk_Text(TxtDispName.Text) & ", " & _
                    " GroupCode=" & AglObj.Chk_Text(TxtAcGroup.AgSelectedValue) & ",GroupNature=" & AglObj.Chk_Text(mGroupNature) & ",Nature=" & AglObj.Chk_Text(mNature) & ", " & _
                    " ManualCode=" & AglObj.Chk_Text(TxtManualCode.Text) & ", Add1 = " & AglObj.Chk_Text(TxtAdd1.Text) & ", Add2 = " & AglObj.Chk_Text(TxtAdd2.Text) & ", Add3 = " & AglObj.Chk_Text(TxtAdd3.Text) & ", CityCode = " & AglObj.Chk_Text(TxtCityCode.AgSelectedValue) & "," & _
                    " Phone = " & AglObj.Chk_Text(TxtPhone.Text) & ", Mobile = " & AglObj.Chk_Text(TxtMobile.Text) & ", DOB=" & AglObj.ConvertDate(TxtDob.Text) & ", FatherNamePrefix=" & AglObj.Chk_Text(TxtFatherNamePrefix.Text) & ", FatherName=" & AglObj.Chk_Text(TxtFatherName.Text) & ", " & _
                    " EMail = " & AglObj.Chk_Text(TxtEMail.Text) & ", CommonAc = " & IIf(AglObj.StrCmp(TxtCommonAc.Text, "Yes"), 1, 0) & ", " & _
                    " Fax = " & AglObj.Chk_Text(TxtPhone.Text) & ", " & _
                    " Pin = " & AglObj.Chk_Text(TxtPin.Text) & ", " & _
                    " ActiveYN = " & AglObj.Chk_Text(IIf(AglObj.StrCmp(TxtActiveYN.Text, "No"), "N", "Y")) & ", " & _
                    " SalesTaxPostingGroup = " & AglObj.Chk_Text(TxtSalesTaxPostingGroup.AgSelectedValue) & " " & _
                    " Where SubCode='" & mSearchCode & "' "
            AglObj.Dman_ExecuteNonQry(mQry, AglObj.GCn, AglObj.ECmd)

            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO dbo.Party (SubCode, MasterType, InActiveDate) " & _
                        " VALUES ( " & _
                        " " & AglObj.Chk_Text(mSearchCode) & ", " & _
                        " " & AglObj.Chk_Text(MasterType) & ", " & _
                        " " & AglObj.Chk_Text(TxtInActiveDate.Text) & " " & _
                        " )"
                AglObj.Dman_ExecuteNonQry(mQry, AglObj.GCn, AglObj.ECmd)
            Else
                mQry = "UPDATE dbo.Party " & _
                        " SET " & _
                        " 	MasterType = " & AglObj.Chk_Text(MasterType) & ", " & _
                        " 	InActiveDate = " & AglObj.Chk_Text(TxtInActiveDate.Text) & " " & _
                        " Where SubCode='" & mSearchCode & "' "
                AglObj.Dman_ExecuteNonQry(mQry, AglObj.GCn, AglObj.ECmd)
            End If

            RaiseEvent BaseEvent_Save_InTrans(mSearchCode, AglObj.GCn, AglObj.ECmd)

            Call AglObj.LogTableEntry(mSearchCode, Me.Text, AglObj.MidStr(Topctrl1.Mode, 0, 1), AglObj.PubMachineName, AglObj.PubUserName, AglObj.PubLoginDate, AglObj.GCn, AglObj.ECmd, , , mSearchCode, mParty_Type, TxtSite_Code.AgSelectedValue, AglObj.PubDivCode)

            AglObj.SynchroniseSiteOnLineData(AglObj, AglObj.GCn, AglObj.Gcn_ConnectionString, AglObj.GcnSite_ConnectionString, AglObj.ECmd)

            If FormType = eFormType.Main And BlnIsApprovalApply = False Then
                Call ProcApproveVoucher(AglObj.PubUserName, bApprovedDate)
            End If

            AglObj.ETrans.Commit()
            mTrans = False


            RaiseEvent BaseEvent_Save_PostTrans(mSearchCode)

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
            If mTrans = True Then AglObj.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim bDtTemp As DataTable = Nothing
        Dim MastPos As Long
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select H.* " & _
                        " From SubGroup H With (NoLock) " & _
                        " Where SubCode='" & mSearchCode & "'"
                DsTemp = AglObj.FillData(mQry, AglObj.GcnRead)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AglObj.XNull(.Rows(0)("Site_Code"))
                        TxtDivision.AgSelectedValue = AglObj.XNull(.Rows(0)("Div_Code"))
                        TxtCommonAc.Text = IIf(AglObj.VNull(.Rows(0)("CommonAc")), "Yes", "No")

                        TxtName.AgSelectedValue = AglObj.XNull(.Rows(0)("SubCode"))
                        TxtDispName.Text = AglObj.XNull(.Rows(0)("DispName"))
                        TxtManualCode.Text = AglObj.XNull(.Rows(0)("ManualCode"))
                        TxtAcGroup.AgSelectedValue = AglObj.XNull(.Rows(0)("GroupCode"))
                        mGroupNature = AglObj.XNull(.Rows(0)("GroupNature"))
                        mNature = AglObj.XNull(.Rows(0)("Nature"))

                        TxtActiveYN.Text = IIf(AglObj.StrCmp(AglObj.XNull(.Rows(0)("ActiveYN")).ToString, "N"), "No", "Yes")

                        TxtFatherNamePrefix.Text = AglObj.XNull(.Rows(0)("FatherNamePrefix"))
                        TxtFatherName.Text = AglObj.XNull(.Rows(0)("FatherName"))
                        TxtAdd1.Text = AglObj.XNull(.Rows(0)("Add1"))
                        TxtAdd2.Text = AglObj.XNull(.Rows(0)("Add2"))
                        TxtAdd3.Text = AglObj.XNull(.Rows(0)("Add3"))
                        TxtCityCode.AgSelectedValue = AglObj.XNull(.Rows(0)("CityCode"))
                        TxtPhone.Text = AglObj.XNull(.Rows(0)("Phone"))
                        TxtMobile.Text = AglObj.XNull(.Rows(0)("Mobile"))
                        TxtFax.Text = AglObj.XNull(.Rows(0)("Fax"))

                        TxtEMail.Text = AglObj.XNull(.Rows(0)("EMail"))
                        TxtDob.Text = Format(AglObj.XNull(.Rows(0)("DOB")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtSalesTaxPostingGroup.AgSelectedValue = AglObj.XNull(.Rows(0)("SalesTaxPostingGroup"))

                        TxtApproved.Text = AglObj.XNull(.Rows(0)("ApprovedBy"))
                        TxtPrepared.Text = AglObj.XNull(.Rows(0)("U_Name"))
                        TxtModified.Text = AglObj.XNull(.Rows(0)("ModifiedBy"))
                        GBoxModified.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                        '---------------------------------------------------
                    End If
                End With

                If mSearchCode.Trim <> "" Then
                    mQry = "SELECT P.* FROM Party P WITH (NoLock) WHERE P.SubCode = '" & mSearchCode & "' "
                    bDtTemp = AglObj.FillData(mQry, AglObj.GcnRead).Tables(0)
                    With bDtTemp
                        If .Rows.Count > 0 Then
                            TxtInActiveDate.Text = Format(AglObj.XNull(.Rows(0)("InActiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        End If
                    End With
                End If

                RaiseEvent BaseFunction_MoveRec(mSearchCode)
            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If DsTemp IsNot Nothing Then DsTemp.Dispose()
            If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""

        TxtCommonAc.Text = "Yes" : TxtActiveYN.Text = "Yes"
        RaiseEvent BaseFunction_BlankText()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
        TxtName.Enabled = False
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


                    If mSearchCode <> "" Then
                        RaiseEvent BaseEvent_Approve_PreTrans(mSearchCode)

                        ''=======================Approval Start======================================

                        TxtApproved.Text = AglObj.PubUserName
                        mApprovedDate = AglObj.GetDateTime(AglObj.GCn)

                        AglObj.ECmd = AglObj.GCn.CreateCommand
                        AglObj.ETrans = AglObj.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                        AglObj.ECmd.Transaction = AglObj.ETrans
                        mTrans = True


                        Call ProcApproveVoucher(TxtApproved.Text, mApprovedDate)

                        ''===========================================================================

                        AglObj.SynchroniseSiteOnLineData(AglObj, AglObj.GCn, AglObj.Gcn_ConnectionString, AglObj.GcnSite_ConnectionString, AglObj.ECmd)
                        AglObj.ETrans.Commit()
                        mTrans = False

                        RaiseEvent BaseEvent_Approve_PostTrans(mSearchCode)

                        MsgBox("Party Approved Successfully.", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
                        If AglObj.PubMoveRecApplicable Then
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

        mQry = "Update SubGroup Set ApprovedBy='" & StrApprovedBy & "', ApprovedDate=" & AglObj.Chk_Text(StrApprovedDate) & " Where SubCode='" & mSearchCode & "' "
        AglObj.Dman_ExecuteNonQry(mQry, AglObj.GCn, AglObj.ECmd)

        RaiseEvent BaseEvent_Approve_InTrans(mSearchCode, AglObj.GCn, AglObj.ECmd)

        Call AglObj.LogTableEntry(mSearchCode, Me.Text, AgLibrary.ClsConstant.EntryMode_Varified, AglObj.PubMachineName, AglObj.PubUserName, AglObj.PubLoginDate, AglObj.GCn, AglObj.ECmd, , , , , , TxtSite_Code.AgSelectedValue, TxtDivision.AgSelectedValue)
    End Sub

    Sub Calculation()
        RaiseEvent BaseFunction_Calculation()
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
        TxtSalesTaxPostingGroup.Enter
        Try
            Select Case sender.name
                Case TxtSalesTaxPostingGroup.Name
                    TxtSalesTaxPostingGroup.AgRowFilter = " Active <> 0 "

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles TxtSite_Code.Validating, TxtDispName.Validating, TxtName.Validating, TxtManualCode.Validating, _
                TxtCityCode.Validating, TxtAdd1.Validating, TxtAdd2.Validating, TxtAdd3.Validating, _
                TxtMobile.Validating, TxtPhone.Validating, TxtEMail.Validating, TxtFatherName.Validating, _
                TxtFatherNamePrefix.Validating, TxtAcGroup.Validating, TxtInActiveDate.Validating
        Try
            Select Case sender.NAME
                Case TxtAcGroup.Name
                    Call Validating_Controls(sender)

                Case TxtInActiveDate.Name
                    Call Validating_Controls(sender)

                Case TxtDispName.Name, TxtManualCode.Name
                    'TxtName.Text = TxtDispName.Text + Space(1) + "{" + TxtManualCode.Text + "}"
                    TxtName.Text = TxtDispName.Text
            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Validating_Controls(ByVal Sender As Object) As Boolean
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtAcGroup.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    mGroupNature = ""
                    mNature = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AglObj.Chk_Text(Sender.AgSelectedValue) & "")
                        mGroupNature = AglObj.XNull(DrTemp(0)("GroupNature"))
                        mNature = AglObj.XNull(DrTemp(0)("Nature"))
                    End If
                End If
                DrTemp = Nothing



            Case TxtInActiveDate.Name
                TxtActiveYN.Text = IIf(TxtInActiveDate.Text.Trim <> "", "No", "Yes")

        End Select

        Validating_Controls = True
    End Function

    Private Function Data_Validation() As Boolean
        Try
            Dim ChildDataPassed As Boolean = True

            Call Calculation()

            If AglObj.RequiredField(TxtSite_Code, LblSite_Code.Text) Then Exit Function
            If AglObj.RequiredField(TxtDispName, LblDispName.Text) Then Exit Function
            If AglObj.RequiredField(TxtManualCode, LblManualCode.Text) Then Exit Function
            If AglObj.RequiredField(TxtName, LblName.Text) Then Exit Function
            If AglObj.RequiredField(TxtAcGroup, LblAcGroup.Text) Then Exit Function

            If TxtEMail.Text.Trim <> "" Then If Not AglObj.IsValid_EMailId(TxtEMail, "EMail ID") Then Exit Function

            TxtActiveYN.Text = IIf(TxtInActiveDate.Text.Trim <> "", "No", "Yes")

            If AglObj.StrCmp(Topctrl1.Mode, "Add") Then
                AglObj.ECmd = AglObj.Dman_Execute("Select count(*) From SubGroup With (NoLock) Where ManualCode='" & TxtManualCode.Text & "' ", AglObj.GcnRead)
                If AglObj.ECmd.ExecuteScalar() > 0 Then MsgBox("Party ID Already Exist!") : TxtManualCode.Focus() : Exit Function

                AglObj.ECmd = AglObj.Dman_Execute("Select count(*) From SubGroup  With (NoLock) Where DispName='" & TxtDispName.Text & "' ", AglObj.GcnRead)
                If AglObj.ECmd.ExecuteScalar() > 0 Then
                    TxtName.Text = TxtDispName.Text + Space(1) + "{" + TxtManualCode.Text + "}"
                    If MsgBox("Display Name Already Exist!..." & vbCrLf & "Want to Continue!", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then TxtDispName.Focus() : Exit Function
                End If



                AglObj.ECmd = AglObj.Dman_Execute("Select count(*) From SubGroup  With (NoLock) Where Name='" & TxtName.Text & "' ", AglObj.GcnRead)
                If AglObj.ECmd.ExecuteScalar() > 0 Then MsgBox("Name Already Exist!") : TxtDispName.Focus() : Exit Function
            Else
                AglObj.ECmd = AglObj.Dman_Execute("Select count(*) From SubGroup  With (NoLock) Where ManualCode='" & TxtManualCode.Text & "' And SubCode<>'" & mSearchCode & "' ", AglObj.GcnRead)
                If AglObj.ECmd.ExecuteScalar() > 0 Then MsgBox("Party ID Already Exist!") : TxtManualCode.Focus() : Exit Function

                AglObj.ECmd = AglObj.Dman_Execute("Select count(*) From SubGroup  With (NoLock) Where DispName='" & TxtDispName.Text & "' And SubCode<>'" & mSearchCode & "' ", AglObj.GcnRead)
                If AglObj.ECmd.ExecuteScalar() > 0 Then
                    TxtName.Text = TxtDispName.Text + Space(1) + "{" + TxtManualCode.Text + "}"
                    If MsgBox("Display Name Already Exist!..." & vbCrLf & "Want to Continue!", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then TxtDispName.Focus() : Exit Function
                End If

                AglObj.ECmd = AglObj.Dman_Execute("Select count(*) From SubGroup  With (NoLock) Where Name='" & TxtName.Text & "' And SubCode<>'" & mSearchCode & "' ", AglObj.GcnRead)
                If AglObj.ECmd.ExecuteScalar() > 0 Then MsgBox("Name Already Exist!") : TxtDispName.Focus() : Exit Function
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

        If TxtAcGroup.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtAcGroup.AgSelectedValue = TxtAcGroup.AgHelpDataSet.Tables(0).Rows(0)("Code")
            Call Validating_Controls(TxtAcGroup)

            TxtAcGroup.Enabled = False
        Else
            TxtAcGroup.Enabled = True
        End If


        TxtSalesTaxPostingGroup.AgSelectedValue = AglObj.XNull(SalesTaxPostingGroup)

        '==================================================================================================================================================================================
        '==============< Raise Add Event >=================================================================================================================================================
        '===================< Start >=================================================================================================================================================
        '==================================================================================================================================================================================
        RaiseEvent BaseEvent_Topctrl_tbAdd()
        '==================================================================================================================================================================================
        '==============< Raise Add Event >=================================================================================================================================================
        '===================< End >=================================================================================================================================================
        '==================================================================================================================================================================================
    End Sub

    Public Sub FindMove(ByVal SearchCode As String)
        Try
            If SearchCode <> "" Then
                AglObj.PubSearchRow = SearchCode
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
