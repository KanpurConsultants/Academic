Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class TempTransaction

    Public Event BaseFunction_MoveRec(ByVal SearchCode As String)
    Public Event BaseFunction_IniGrid()
    Public Event BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte)
    Public Event BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte)
    Public Event BaseFunction_FIniList()
    Public Event BaseFunction_CreateHelpDataSet()
    Public Event BaseEvent_Data_Validation(ByRef passed As Boolean)

    Public Event BaseFunction_Calculation()
    Public Event BaseFunction_BlankText()
    Public Event BaseFunction_DispText()

    Public Event BaseEvent_FindMain()
    Public Event BaseEvent_FindLog()
    Public Event BaseEvent_Form_PreLoad()
    Public Event BaseEvent_Save_PreTrans(ByVal SearchCode As String)
    Public Event BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
    Public Event BaseEvent_Save_PostTrans(ByVal SearchCode As String)
    Public Event BaseEvent_Approve_PreTrans(ByVal SearchCode As String)
    Public Event BaseEvent_ApproveDeletion_PreTrans(ByVal SearchCode As String)
    Public Event BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
    Public Event BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
    Public Event BaseEvent_Approve_PostTrans(ByVal SearchCode As String)
    Public Event BaseEvent_ApproveDeletion_PostTrans(ByVal SearchCode As String)
    Public Event BaseEvent_Topctrl_tbAdd()
    Public Event BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean)
    Public Event BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean)
    Public Event BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String)
    Public Event BaseEvent_Topctrl_tbRef()


    Public DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable


    Dim mQry As String = ""
    Public mSearchCode As String = "", mInternalCode As String = ""


    Dim ClsRep As ClsReportProcedures


    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode


    Dim mNCAT As String
    Dim mFrmType As EntryPointType = EntryPointType.Log
    Dim mMainTableName As String
    Dim mLogTableName As String
    Dim mMainLineTableCSV As String
    Dim mLogLineTableCSV As String
    Dim ArrMainLineTable As String()
    Dim ArrLogLineTable As String()
    Protected mLogSystem As Boolean = False

    Public Enum EntryPointType
        Main
        Log
    End Enum

    Public Class LogStatus
        Public Const LogOpen As String = "Open"
        Public Const LogDiscard As String = "Discard"
        Public Const LogApproved As String = "Approved"
    End Class

    Public Property EntryNCat() As String
        Get
            Return Replace(Replace(mNCAT, " ", ""), ",", "','")
        End Get
        Set(ByVal value As String)
            mNCAT = value
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

    Public Property LogLineTableCsv() As String
        Get
            Return mLogLineTableCSV
        End Get
        Set(ByVal value As String)
            mLogLineTableCSV = value

            ArrLogLineTable = Split(mLogLineTableCSV, ",")
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

    Public Property LogTableName() As String
        Get
            Return mLogTableName
        End Get
        Set(ByVal value As String)
            mLogTableName = value
        End Set
    End Property

    Public Property FrmType() As EntryPointType
        Get
            Return mFrmType
        End Get
        Set(ByVal value As EntryPointType)
            mFrmType = value
        End Set
    End Property

    Public Property LogSystem() As Boolean
        Get
            Return mLogSystem
        End Get
        Set(ByVal value As Boolean)
            mLogSystem = value
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
        AgL.CheckQuote(e)
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
            AgL.WinSetting(Me, 660, 992, 0, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)

        If FrmType = EntryPointType.Main Then
            '---------------------------------------
            'Condition when Entry point Type is Main
            '---------------------------------------
            RaiseEvent BaseFunction_FIniMast(BytDel, BytRefresh)
        Else
            '---------------------------------------
            'Condition when Entry point Type is LOG
            '---------------------------------------
            RaiseEvent BaseFunction_FIniMastLog(BytDel, BytRefresh)
        End If

    End Sub

    Sub Ini_List()
        Try
            mQry = "Select V_Type as Code, Description, NCat From Voucher_Type Where NCat In ('" & EntryNCat & "') "
            TxtV_Type.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Div_Code, Div_Name From Division Order By Div_Name"
            TxtDivision.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Code, ManualCode, Name From SiteMast Order By ManualCode"
            TxtSite_Code.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select '" & ClsMain.EntryStatus.Active & "' As Code, '" & ClsMain.EntryStatus.Active & "' As Description " & _
                    " Union All Select '" & ClsMain.EntryStatus.Cancelled & "' As Code, '" & ClsMain.EntryStatus.Cancelled & "' As Description "
            TxtStatus.AgHelpDataSet(0, GroupBox2.Top - 150, GroupBox2.Left) = AgL.FillData(mQry, AgL.GCn)

            RaiseEvent BaseFunction_FIniList()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
    '    BlankText()
    '    DispText(True)
    '    TxtDivision.AgSelectedValue = AgL.PubDivCode
    '    TxtStatus.Text = ClsMain.EntryStatus.Active
    '    TxtV_Date.Text = AgL.PubLoginDate
    '    TxtV_Date.Focus()
    'End Sub


    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim InstancePassed As Boolean = True

        Try
            MastPos = BMBMaster.Position


            If Not AgL.StrCmp(TxtDivision.AgSelectedValue, AgL.PubDivCode) Then
                MsgBox("Different Division Record. Can't Modify!", MsgBoxStyle.OkOnly, "Validation") : Exit Sub
            End If


            RaiseEvent BaseEvent_Topctrl_tbDel(InstancePassed)
            If Not InstancePassed Then Exit Sub


            If DTMaster.Rows.Count > 0 Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True


                    AgL.Dman_ExecuteNonQry("Update " & LogTableName & " Set EntryType='Delete', EntryBy=" & AgL.Chk_Text(AgL.PubUserName) & ", EntryDate = " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & " Where UID='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

                    If Not LogSystem Then
                        TxtEntryType.Text = "Delete"
                        RaiseEvent BaseEvent_ApproveDeletion_PreTrans(mSearchCode)
                        ProcApporve(AgL.GCn, AgL.ECmd)
                        RaiseEvent BaseEvent_ApproveDeletion_PostTrans(mSearchCode)
                    End If

                    AgL.ETrans.Commit()
                    mTrans = False

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
        Dim InstancePassed As Boolean = True

        RaiseEvent BaseEvent_Topctrl_tbEdit(InstancePassed)
        If Not InstancePassed Then
            Topctrl1.FButtonClick(14, True)            
            Exit Sub
        End If

        If AgL.StrCmp(TxtDivision.AgSelectedValue, AgL.PubDivCode) Then
            DispText(True)
            TxtV_Date.Focus()

        Else
            Topctrl1.FButtonClick(14, True)
            MsgBox("Different Division Record. Can't Modify!", MsgBoxStyle.OkOnly, "Validation") : Exit Sub
        End If
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try
            If FrmType = EntryPointType.Main Then
                '---------------------------------------
                'Condition when Entry point Type is Main
                '---------------------------------------
                RaiseEvent BaseEvent_FindMain()
            Else
                '---------------------------------------
                'Condition when Entry point Type is LOG
                '---------------------------------------
                RaiseEvent BaseEvent_FindLog()
            End If



            Dim Frmbj As FrmReportWindow = New FrmReportWindow(AgL.PubFindQry, Me.Text & " Find")
            Frmbj.ShowDialog()
            AgL.PubSearchRow = Frmbj.DGL1.Item(0, Frmbj.DGL1.CurrentRow.Index).Value.ToString
            If AgL.PubSearchRow <> "" Then
                AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                MoveRec()
            End If


            ''*************** common code start *****************
            'AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            'AgL.PubObjFrmFind.ShowDialog()
            'AgL.PubObjFrmFind = Nothing
            'If AgL.PubSearchRow <> "" Then
            '    AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
            '    BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
            '    MoveRec()
            'End If
            ''*************** common code end  *****************
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

        Try
            MastPos = BMBMaster.Position

            '---------------------------------------------------
            'Any type of validation like Required field, Duplicate Check etc.
            'are to be write in Data_Validation function.
            '----------------------------------------------------
            If Data_Validation() = False Then Exit Sub
            '----------------------------------------------------

            RaiseEvent BaseEvent_Save_PreTrans(mSearchCode)

            If Not LogSystem Then
                RaiseEvent BaseEvent_Approve_PreTrans(mSearchCode)
            End If

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO " & LogTableName & " (UID, DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, EntryBy, EntryDate,  EntryType, EntryStatus, Status) " & _
                        "VALUES (" & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", '" & TxtDivision.AgSelectedValue & "',  " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & "," & AgL.ConvertDate(TxtV_Date.Text) & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & ",  " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & AgL.Chk_Text(Topctrl1.Mode) & ", " & AgL.Chk_Text(LogStatus.LogOpen) & ", " & AgL.Chk_Text(TxtStatus.Text) & " )"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update " & LogTableName & " Set V_Date=" & AgL.Chk_Text(TxtV_Date.Text) & ", EntryBy = " & AgL.Chk_Text(AgL.PubUserName) & ", EntryDate = " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ",  EntryType = " & AgL.Chk_Text(Topctrl1.Mode) & ", EntryStatus=" & AgL.Chk_Text(LogStatus.LogOpen) & " " & _
                       " Where UID = " & AgL.Chk_Text(mSearchCode) & "  "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            RaiseEvent BaseEvent_Save_InTrans(mSearchCode, AgL.GCn, AgL.ECmd)

            AgL.UpdateVoucherCounter(mInternalCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)

            '--------------------------------------------------------------
            'Create a log entry of each activity like add, edit delete print
            '--------------------------------------------------------------
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
            '--------------------------------------------------------------



            '--------------------------------------------------------------
            'If not using Log System then approve record automatic on each save
            '--------------------------------------------------------------
            If Not LogSystem Then
                Call ProcApporve(AgL.GCn, AgL.ECmd)                
            End If
            '--------------------------------------------------------------

            AgL.ETrans.Commit()
            mTrans = False

            RaiseEvent BaseEvent_Save_PostTrans(mSearchCode)

            If Not LogSystem Then
                RaiseEvent BaseEvent_Approve_PostTrans(mSearchCode)
            End If

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
                If AgL.PubMoveRecApplicable Then MoveRec()
            End If
        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        Finally
        End Try
    End Sub




    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Try
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position

                mSearchCode = DTMaster.Rows(MastPos)("SearchCode").ToString



                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select DocID, Div_Code, Site_Code, V_Type, V_Prefix, V_No, V_Date, EntryBy, EntryType, ApproveBy, MoveToLog, Status " & _
                        " From " & MainTableName & " Where DocId='" & mSearchCode & "'"
                Else
                    mQry = "Select DocID, Div_Code, Site_Code, V_Type, V_Prefix, V_No, V_Date, EntryBy, EntryType, ApproveBy, MoveToLog, Status " & _
                        " From " & LogTableName & " Where UID='" & mSearchCode & "'"
                End If
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    '---------------------------------------------------
                    'Common code for all entry and approval management
                    '---------------------------------------------------
                    mInternalCode = AgL.XNull(.Rows(0)("DocID"))
                    TxtDocId.Text = AgL.XNull(.Rows(0)("DocID"))
                    TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))
                    Validating_VType(TxtV_Type)
                    LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                    TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                    TxtDivision.AgSelectedValue = AgL.XNull(.Rows(0)("Div_Code"))
                    TxtV_No.Text = AgL.VNull(.Rows(0)("V_No"))
                    TxtV_Date.Text = AgL.XNull(.Rows(0)("V_Date"))
                    TxtStatus.Text = AgL.XNull(.Rows(0)("Status"))
                    TxtEntryBy.Text = AgL.XNull(.Rows(0)("EntryBy"))
                    TxtEntryType.Text = AgL.XNull(.Rows(0)("EntryType"))
                    TxtApproveBy.Text = AgL.XNull(.Rows(0)("ApproveBy"))
                    TxtMoveToLog.Text = AgL.XNull(.Rows(0)("MoveToLog"))
                    CmdApprove.Enabled = CBool(TxtApproveBy.Text.ToString = "" And GBoxApprove.Enabled)
                    CmdMoveToLog.Enabled = CBool(TxtMoveToLog.Text.ToString = "" And GBoxMoveToLog.Enabled)

                    If AgL.StrCmp(TxtStatus.Text, "Active") Then
                        CmdStatus.Image = My.Resources.Lock
                    Else
                        CmdStatus.Image = My.Resources.UnLock
                    End If
                    '---------------------------------------------------
                End With

                RaiseEvent BaseFunction_MoveRec(mSearchCode)
            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            TxtStatus.Enabled = True
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = "" : mInternalCode = ""
        RaiseEvent BaseFunction_BlankText()
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        If FrmType = EntryPointType.Main Then
            Topctrl1.tAdd = False
            Topctrl1.tEdit = False
            Topctrl1.tDel = False
            CmdApprove.Visible = False
            CmdDiscard.Visible = False
            CmdStatus.Visible = False
            GBoxApprove.Text = "Approved By"
        Else
            CmdMoveToLog.Visible = False
        End If


        If Not mLogSystem Then
            GBoxApprove.Visible = False
            GBoxMoveToLog.Visible = False
            GBoxEntryType.Left = 240
            GBoxDivision.Left = 470
        End If


        TxtSite_Code.Enabled = False
        TxtV_No.Enabled = False

        If Topctrl1.Mode <> "Add" Then
            TxtV_Type.Enabled = False
        End If

        RaiseEvent BaseFunction_DispText()
    End Sub

    Function RetMain2LogTableColStr(ByVal MainTableName As String, ByVal LogTableName As String) As String
        Dim mQry$
        mQry = "DECLARE @ColStr VARCHAR(Max) " & _
        "SET @ColStr='' " & _
        "SELECT @ColStr=@ColStr + '" & MainTableName & ".' + C.COLUMN_NAME + ' = " & LogTableName & ".' + C.COLUMN_NAME  + ',' " & _
        "FROM INFORMATION_SCHEMA.COLUMNS C  " & _
        "WHERE C.TABLE_NAME ='" & LogTableName & "' " & _
        "AND C.COLUMN_NAME NOT IN ('UID', 'DocID', 'V_Type', 'V_Prefix', 'V_No', 'Div_Code', 'Site_Code', 'EntryBy', 'EntryDate', 'ApproveBy', 'ApproveDate', 'EntryType', 'EntryStatus', 'MoveToLog', 'MoveToLogDate', 'RowID') " & _
        "IF LEN(@ColStr)>0 SET @ColStr=substring (@ColStr,1,len(@ColStr)-1) " & _
        " SELECT @ColStr "
        RetMain2LogTableColStr = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
    End Function


    Function RetLog2MainTableColStr(ByVal MainTableName As String, ByVal LogTableName As String) As String
        Dim mQry$
        mQry = "DECLARE @ColStr VARCHAR(Max) " & _
        "SET @ColStr='' " & _
        "SELECT @ColStr=@ColStr + '" & LogTableName & ".' + C.COLUMN_NAME + ' = " & MainTableName & ".' + C.COLUMN_NAME  + ',' " & _
        "FROM INFORMATION_SCHEMA.COLUMNS C  " & _
        "WHERE C.TABLE_NAME ='" & MainTableName & "' " & _
        "AND C.COLUMN_NAME NOT IN ('UID','DocID', 'EntryBy', 'EntryDate', 'ApproveBy', 'ApproveDate', 'EntryType', 'EntryStatus', 'MoveToLog', 'MoveToLogDate', 'IsDeleted', 'RowId') " & _
        "IF LEN(@ColStr)>0 SET @ColStr=substring (@ColStr,1,len(@ColStr)-1) " & _
        " SELECT @ColStr "
        RetLog2MainTableColStr = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
    End Function

    Function RetColStr(ByVal TableName As String) As String
        Dim mQry$
        mQry = "DECLARE @ColStr VARCHAR(Max) " & _
        "SET @ColStr='' " & _
        "SELECT @ColStr=@ColStr +  C.COLUMN_NAME  + ',' " & _
        "FROM INFORMATION_SCHEMA.COLUMNS C  " & _
        "WHERE C.TABLE_NAME ='" & TableName & "' " & _
        "AND C.COLUMN_NAME NOT IN ('UID', 'IsDeleted', 'RowID') " & _
        "IF LEN(@ColStr)>0 SET @ColStr=substring (@ColStr,1,len(@ColStr)-1) " & _
        " SELECT @ColStr "
        RetColStr = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
    End Function

    Private Sub CmdApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdApprove.Click
        Dim mTrans As Boolean
        Dim I As Integer

        '--------------------------------------------------------------
        '*****  This section will work only if it is a log form  ******
        '--------------------------------------------------------------

        If TxtEntryBy.Text = "" Then
            MsgBox("No Action is done on this record. Can't Approve!", MsgBoxStyle.OkOnly, "Approve")
            Exit Sub
        End If


        Try
            If Not AgL.StrCmp(TxtEntryType.Text, "Delete") Then
                RaiseEvent BaseEvent_Approve_PreTrans(mSearchCode)
            Else
                RaiseEvent BaseEvent_ApproveDeletion_PreTrans(mSearchCode)
            End If


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Not AgL.StrCmp(TxtEntryType.Text, "Delete") Then


                '----------------------------------------------------------
                'Find this record in main table if found then
                'update old record other wise insert new record
                '----------------------------------------------------------
                mQry = " Select Count(*) from " & MainTableName & " Where DocID ='" & mInternalCode & "' "
                If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar = 0 Then
                    mQry = "INSERT INTO " & MainTableName & " (UID, DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, EntryBy, EntryDate,  EntryType, EntryStatus, MoveToLog, MoveToLogDate, ApproveBy, ApproveDate) " & _
                           "Select UID, DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, EntryBy, EntryDate,  EntryType, EntryStatus, Null, Null, " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & " From " & LogTableName & " Where UID = '" & mSearchCode & "' "

                Else
                    mQry = "UPDATE " & MainTableName & " " & _
                    "   SET  " & _
                    "" & MainTableName & ".EntryBy =  " & LogTableName & ".entryby, " & _
                    "" & MainTableName & ".EntryType =  " & LogTableName & ".entryType, " & _
                    "" & MainTableName & ".EntryDate =  " & LogTableName & ".entrydate, " & _
                    "" & MainTableName & ".ApproveBy =  " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                    "" & MainTableName & ".ApproveDate =  " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                    "" & MainTableName & ".MoveToLog =  NULL, " & _
                    "" & MainTableName & ".MoveToLogDate =  NULL " & _
                    "From " & LogTableName & " " & _
                    "Where " & MainTableName & ".DocID = " & LogTableName & ".DocId " & _
                    "And " & LogTableName & ".UID = '" & mSearchCode & "'"

                End If
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)



                mQry = "UPDATE " & MainTableName & " " & _
                "   SET  " & RetMain2LogTableColStr(MainTableName, LogTableName) & _
                " From " & LogTableName & " " & _
                "Where " & MainTableName & ".DocId = " & LogTableName & ".DocID " & _
                "And " & LogTableName & ".UID = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)




                '--------------------------------------------------------------
                'Line Records will be always deleted and insert from Log Table
                'exceptionally it is referentially integrated with any other table
                '--------------------------------------------------------------
                If ArrMainLineTable IsNot Nothing Then
                    For I = 0 To UBound(ArrMainLineTable)
                        If ArrMainLineTable(I) <> "" Then
                            mQry = "Delete from " & ArrMainLineTable(I) & " Where DocID ='" & mInternalCode & "'"
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                            mQry = "Insert Into " & ArrMainLineTable(I) & " (" & RetColStr(ArrMainLineTable(I)) & ") " & _
                                 "SELECT " & RetColStr(ArrMainLineTable(I)) & " " & _
                                 "FROM " & ArrLogLineTable(I) & " Where UID = '" & mSearchCode & "' "
                            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                        End If
                    Next
                End If
                '--------------------------------------------------------------


                RaiseEvent BaseEvent_Approve_InTrans(mSearchCode, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update " & MainTableName & " Set IsDeleted=1, ApproveBy = " & AgL.Chk_Text(AgL.PubUserName) & ", ApproveDate=" & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", EntryStatus = " & AgL.Chk_Text(LogStatus.LogApproved) & "  where DocID = '" & mInternalCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                RaiseEvent BaseEvent_ApproveDeletion_InTrans(mSearchCode, AgL.GCn, AgL.ECmd)
            End If






            '----------------------------------------------
            'Update that entry is transferred to main table
            '----------------------------------------------
            If LogSystem Then
                mQry = "Update " & LogTableName & " Set ApproveBy = " & AgL.Chk_Text(AgL.PubUserName) & ", ApproveDate=" & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", EntryStatus = " & AgL.Chk_Text(LogStatus.LogApproved) & " Where UID = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If
            '----------------------------------------------



            '----------------------------------------------
            AgL.ETrans.Commit()
            mTrans = False


            If Not AgL.StrCmp(TxtEntryType.Text, "Delete") Then
                RaiseEvent BaseEvent_Approve_PostTrans(mSearchCode)
            Else
                RaiseEvent BaseEvent_ApproveDeletion_PostTrans(mSearchCode)
            End If

            FIniMaster()
            MoveRec()

        Catch ex As Exception
            If mTrans Then AgL.ETrans.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Approval")
        End Try
    End Sub

    Sub ProcApporve(ByVal mConn As SqlClient.SqlConnection, ByVal mCmd As SqlClient.SqlCommand)
        Dim DtTemp As DataTable = Nothing
        Dim I As Integer


        If Not AgL.StrCmp(TxtEntryType.Text, "Delete") Then


            '----------------------------------------------------------
            'Find this record in main table if found then
            'update old record other wise insert new record
            '----------------------------------------------------------
            mQry = " Select Count(*) from " & MainTableName & " With (NoLock) Where DocID ='" & mInternalCode & "' "
            If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar = 0 Then
                mQry = "INSERT INTO " & MainTableName & " (UID, DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, EntryBy, EntryDate,  EntryType, EntryStatus, MoveToLog, MoveToLogDate, ApproveBy, ApproveDate) " & _
                       "Select UID, DocId, Div_Code, Site_Code, V_Date, V_Type, V_Prefix, V_No, EntryBy, EntryDate,  EntryType, EntryStatus, Null, Null, " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & " From " & LogTableName & " Where UID = '" & mSearchCode & "' "

            Else
                mQry = "UPDATE " & MainTableName & " " & _
                "   SET  " & _
                "" & MainTableName & ".EntryBy =  " & LogTableName & ".entryby, " & _
                "" & MainTableName & ".EntryType =  " & LogTableName & ".entryType, " & _
                "" & MainTableName & ".EntryDate =  " & LogTableName & ".entrydate, " & _
                "" & MainTableName & ".ApproveBy =  " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                "" & MainTableName & ".ApproveDate =  " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                "" & MainTableName & ".MoveToLog =  NULL, " & _
                "" & MainTableName & ".MoveToLogDate =  NULL " & _
                "From " & LogTableName & " " & _
                "Where " & MainTableName & ".DocID = " & LogTableName & ".DocId " & _
                "And " & LogTableName & ".UID = '" & mSearchCode & "'"

            End If
            AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)



            mQry = "UPDATE " & MainTableName & " " & _
            "   SET  " & RetMain2LogTableColStr(MainTableName, LogTableName) & _
            " From " & LogTableName & " " & _
            "Where " & MainTableName & ".DocId = " & LogTableName & ".DocID " & _
            "And " & LogTableName & ".UID = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)




            '--------------------------------------------------------------
            'Line Records will be always deleted and insert from Log Table
            'exceptionally it is referentially integrated with any other table
            '--------------------------------------------------------------
            If ArrMainLineTable IsNot Nothing Then
                For I = 0 To UBound(ArrMainLineTable)
                    If ArrMainLineTable(I) <> "" Then
                        mQry = "Delete from " & ArrMainLineTable(I) & " Where DocID ='" & mInternalCode & "'"
                        AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)
                        mQry = "Insert Into " & ArrMainLineTable(I) & " (" & RetColStr(ArrMainLineTable(I)) & ") " & _
                             "SELECT " & RetColStr(ArrMainLineTable(I)) & " " & _
                             "FROM " & ArrLogLineTable(I) & " Where UID = '" & mSearchCode & "' "
                        AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)
                    End If
                Next
            End If
            '--------------------------------------------------------------




            '----------------------------------------------
            'Update that entry is transferred to main table
            '----------------------------------------------
            If LogSystem Then
                mQry = "Update " & LogTableName & " Set ApproveBy = " & AgL.Chk_Text(AgL.PubUserName) & ", ApproveDate=" & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", EntryStatus = " & AgL.Chk_Text(LogStatus.LogApproved) & " Where UID = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)
            End If
            '----------------------------------------------

            RaiseEvent BaseEvent_Approve_InTrans(mSearchCode, mConn, mCmd)
        Else
            If LogSystem Then
                mQry = "Update " & MainTableName & " Set IsDeleted=1, ApproveBy = " & AgL.Chk_Text(AgL.PubUserName) & ", ApproveDate=" & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", EntryStatus = " & AgL.Chk_Text(LogStatus.LogApproved) & "  where DocID = '" & mInternalCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)
            Else
                '--------------------------------------------------------------
                'Line Records will be always deleted
                'exceptionally it is referentially integrated with any other table
                '--------------------------------------------------------------

                RaiseEvent BaseEvent_ApproveDeletion_InTrans(mSearchCode, mConn, mCmd)

                If ArrLogLineTable IsNot Nothing Then
                    For I = 0 To UBound(ArrLogLineTable)
                        If ArrLogLineTable(I) <> "" Then
                            mQry = "Delete from " & ArrLogLineTable(I) & " Where UID ='" & mSearchCode & "'"
                            AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)
                        End If
                    Next
                End If

                If ArrMainLineTable IsNot Nothing Then
                    For I = 0 To UBound(ArrMainLineTable)
                        If ArrMainLineTable(I) <> "" Then
                            mQry = "Delete from " & ArrMainLineTable(I) & " Where DocID ='" & mInternalCode & "'"
                            AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)
                        End If
                    Next
                End If
                '--------------------------------------------------------------
                mQry = "Delete from " & LogTableName & " Where UID ='" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)


                mQry = "Delete from " & MainTableName & " Where DocID ='" & mInternalCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)

            End If



            mQry = "Update " & LogTableName & " Set ApproveBy = " & AgL.Chk_Text(AgL.PubUserName) & ", ApproveDate=" & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", EntryStatus = " & AgL.Chk_Text(LogStatus.LogApproved) & " Where UID = '" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, mConn, mCmd)


        End If







    End Sub



    Private Sub CmdMoveToLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdMoveToLog.Click
        Dim mTrans As Boolean
        Dim mGuid$
        Dim I As Integer
        '--------------------------------------------------------------
        '*****  This section will work only if it is a Main form  ******
        '--------------------------------------------------------------
        If FrmType = EntryPointType.Log Then Exit Sub
        '--------------------------------------------------------------



        Try
            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            '----------------------------------------------------------
            'Create new GUID. Insert a new record in log table with OPEN status            
            '----------------------------------------------------------

            mGuid = AgL.GetGUID(AgL.GcnRead).ToString


            mQry = "INSERT INTO " & LogTableName & " (UID, DocId, EntryBy, EntryDate, EntryType, EntryStatus, MoveToLog, MoveToLogDate) " & _
                       "Select '" & mGuid & "', " & AgL.Chk_Text(mSearchCode) & ", NULL, NULL, NULL, " & AgL.Chk_Text(LogStatus.LogOpen) & ", " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & " From " & MainTableName & " Where DocID = '" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)



            mQry = "Update " & LogTableName & " " & _
                   "Set  " & RetLog2MainTableColStr(MainTableName, LogTableName) & _
                   " From " & MainTableName & "  " & _
                   " Where " & LogTableName & ".UID = '" & mGuid & "' And " & LogTableName & ".DocID = " & MainTableName & ".DocId "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


            If ArrMainLineTable IsNot Nothing Then
                For I = 0 To UBound(ArrMainLineTable)
                    If ArrMainLineTable(I) <> "" Then
                        mQry = "Insert Into " & ArrLogLineTable(I) & " (UID, " & RetColStr(ArrLogLineTable(I)) & ") " & _
                             "SELECT '" & mGuid & "', " & RetColStr(ArrLogLineTable(I)) & " " & _
                             "FROM " & ArrMainLineTable(I) & " Where DocID = '" & mSearchCode & "' "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    End If
                Next
            End If



            '--------------------------------------------------------------




            '----------------------------------------------
            'Update that entry is transferred to main table
            '----------------------------------------------
            mQry = "Update " & MainTableName & " Set MoveToLog = " & AgL.Chk_Text(AgL.PubUserName) & ", MoveToLogDate=" & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & " Where DocId = '" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            '----------------------------------------------


            TxtMoveToLog.Text = AgL.PubUserName
            CmdMoveToLog.Enabled = False


            '----------------------------------------------------------

            AgL.ETrans.Commit()
            mTrans = False

        Catch ex As Exception
            If mTrans Then AgL.ETrans.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Approval")
        End Try
    End Sub


    Sub Calculation()
        RaiseEvent BaseFunction_Calculation()
    End Sub


    Private Sub PicDiscardBy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdDiscard.Click
        Dim mTrans As Boolean


        '--------------------------------------------------------------
        '*****  This section will work only if it is a log form  ******
        '--------------------------------------------------------------


        Try
            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True



            '----------------------------------------------
            'Update that entry is transferred to main table
            '----------------------------------------------

            mQry = "Update " & LogTableName & " Set EntryStatus = " & AgL.Chk_Text(LogStatus.LogDiscard) & " Where UID = '" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


            mQry = "Update " & MainTableName & " Set EntryStatus = " & AgL.Chk_Text(LogStatus.LogDiscard) & ",MoveToLog = NULL, MoveToLogDate=NULL Where DocID = '" & mInternalCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            '----------------------------------------------


            AgL.ETrans.Commit()
            mTrans = False


            FIniMaster()
            MoveRec()

        Catch ex As Exception
            If mTrans Then AgL.ETrans.Rollback()
            MsgBox(ex.Message, MsgBoxStyle.OkOnly, "Discard")

        End Try


    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdStatus.Click
    '    If FrmType = EntryPointType.Log Then
    '        If mSearchCode <> "" Then
    '            If MsgBox("Sure to change status of selected record?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '                TxtEntryBy.Text = AgL.PubUserName
    '                TxtEntryType.Text = "STATUS"
    '                If AgL.StrCmp(TxtStatus.Text, "Inactive") Then
    '                    TxtStatus.Text = "Active"
    '                Else
    '                    TxtStatus.Text = "Inactive"
    '                End If
    '                mQry = "Update " & LogTableName & " Set Status = " & AgL.Chk_Text(TxtStatus.Text) & ", EntryBy = " & AgL.Chk_Text(TxtEntryBy.Text) & ", EntryDate = " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", EntryType = " & AgL.Chk_Text(TxtEntryType.Text) & " Where UID = '" & mSearchCode & "' "
    '                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
    '            End If
    '        End If
    '    Else
    '        MsgBox("Status Can be changed on Log Entry Only.")
    '    End If
    'End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdStatus.Click
        If FrmType = EntryPointType.Log Then
            If mSearchCode <> "" Then
                If MsgBox("Sure to change status of selected record?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    TxtEntryBy.Text = AgL.PubUserName
                    TxtEntryType.Text = "STATUS"

                    mQry = "Update " & LogTableName & " " & _
                            " Set " & _
                            " Status = " & AgL.Chk_Text(IIf(TxtStatus.Text = "", ClsMain.EntryStatus.Active, TxtStatus.Text)) & ", " & _
                            " EntryBy = " & AgL.Chk_Text(TxtEntryBy.Text) & ", " & _
                            " EntryDate = " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                            " EntryType = " & AgL.Chk_Text(TxtEntryType.Text) & " " & _
                            " Where UID = '" & mSearchCode & "' "

                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                End If
            End If
        Else
            MsgBox("Status Can be changed on Log Entry Only.")
        End If
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
                    If TxtV_Date.Text.Trim = "" Then TxtV_Date.Text = AgL.PubLoginDate

            End Select

            Call Calculation()

            If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
                mInternalCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtDocId.Text = mInternalCode
                TxtV_No.Text = Val(AgL.DeCodeDocID(mInternalCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mInternalCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
            End If

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
                DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
            End If
        End If

    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = ""
        Try
            Dim ChildDataPassed As Boolean = True

            Call Calculation()

            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtV_Type, LblV_Type.Text) Then Exit Function
            If AgL.RequiredField(TxtV_Date, LblV_Date.Text) Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function


            If Not AgCL.AgCheckMandatory(Me) Then Exit Function

            If Topctrl1.Mode = "Add" Then

                mSearchCode = AgL.GetGUID(AgL.GCn).ToString
                mInternalCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
                TxtV_No.Text = Val(AgL.DeCodeDocID(mInternalCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                LblPrefix.Text = AgL.DeCodeDocID(mInternalCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                If mInternalCode <> TxtDocId.Text Then
                    MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mInternalCode & "")
                    TxtDocId.Text = mInternalCode
                End If
            End If

            If Topctrl1.Mode = "Add" Then
                mQry = "Select count(*) From " & LogTableName & " Where DocID='" & mInternalCode & "' And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' "
                If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Entry No. Already Exists in Log File")
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
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtDivision.AgSelectedValue = AgL.PubDivCode
        TxtStatus.Text = ClsMain.EntryStatus.Active
        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            TxtV_Type.Enabled = True
        End If

        TxtV_Date.Text = AgL.PubLoginDate
        TxtV_Date.Focus()

        If mTmV_Type.Trim = "" Then
            If TxtV_Type.Enabled = True Then TxtV_Type.Focus()
        End If

        If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" Then
            mInternalCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, AgL.PubDivCode, TxtSite_Code.AgSelectedValue)
            TxtDocId.Text = mInternalCode
            TxtV_No.Text = Val(AgL.DeCodeDocID(mInternalCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
            LblPrefix.Text = AgL.DeCodeDocID(mInternalCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
        End If
        RaiseEvent BaseEvent_Topctrl_tbAdd()
    End Sub

    Private Sub CreateHelpDataSets()
        RaiseEvent BaseFunction_CreateHelpDataSet()
    End Sub

    Public Sub FindMove(ByVal bDocId As String)
        Try
            If bDocId <> "" Then
                AgL.PubSearchRow = bDocId
                If AgL.PubMoveRecApplicable Then
                    AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                    BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                End If
                Call MoveRec()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class