Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmMemberVisit
    Public DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable

    Dim mQry As String = ""
    Public mSearchCode As String = "", mStrUid As String = ""

    'Dim mBlnIsOpenEntryExists As Boolean = False
    Dim mBlnIsCloseRecord As Boolean = False, mBlnIsClosed As Boolean = False

    Dim mTmV_Type$ = "", mTmV_Prefix$ = "", mTmV_Date$ = "", mTmV_NCat$ = ""             'Variables Holds Value During Add Mode

    Dim _FormLocation As New System.Drawing.Point(0, 0)
    Dim _EntryMode As String = "Browse"

    Public Class HelpDataSet
        'Public Shared OpenEntryNo As DataSet = Nothing
    End Class


    Public Property EntryMode() As String
        Get
            EntryMode = _EntryMode
        End Get
        Set(ByVal value As String)
            _EntryMode = value
        End Set
    End Property

    Public Property FormLocation() As System.Drawing.Point
        Get
            FormLocation = _FormLocation
        End Get
        Set(ByVal value As System.Drawing.Point)
            _FormLocation = value
        End Set
    End Property

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        DTMaster = Nothing
    End Sub

    Public Sub IniGrid()

    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F2 Or e.KeyCode = Keys.F3 Or e.KeyCode = Keys.F4 Or e.KeyCode = (Keys.F And e.Control) _
                    Or e.KeyCode = (Keys.S And e.Control) Or e.KeyCode = Keys.Escape Or e.KeyCode = Keys.F5 Or e.KeyCode = Keys.F10 Then
                Topctrl1.TopKey_Down(e)
            End If

            If Me.ActiveControl IsNot Nothing Then
                If Me.ActiveControl.Name <> Topctrl1.Name And _
                    Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                    If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
                End If

                'If e.KeyCode = Keys.Insert Then OpenLinkForm(Me.ActiveControl)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            AgL.WinSetting(Me, 330, 880, _FormLocation.Y, _FormLocation.X)

            IniGrid()
            FIniMaster()
            Ini_List()
            DispText()

            _EntryMode = "Add"
            If AgL.StrCmp(_EntryMode, "Add") Then
                Topctrl1.FButtonClick(0)
            Else
                MoveRec()
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "SELECT G.DocID AS SearchCode FROM GateInOut G WHERE 1=2"
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select V_Type as Code, Description, NCat From Voucher_Type Where NCat = '" & ClsMain.Temp_NCat.MemberVisit & "' "
            TxtV_Type.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Div_Code, Div_Name From Division Order By Div_Name"
            TxtDivision.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select Code, ManualCode, Name, Active From SiteMast Order By ManualCode"
            TxtSite_Code.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT M.SubCode AS Code,Sg.DispName,Sg.ManualCode,SG.Name," & _
              " isnull(SG.IsDeleted,0) AS IsDeleted, SG.Div_Code , " & _
              " isnull(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status  " & _
              " FROM Lib_Member M " & _
              " LEFT JOIN SubGroup SG ON SG.SubCode=M.SubCode " & _
              " Where " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & " "
            TxtParty.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)


            mQry = "Select '" & ClsMain.InOut.GateIn & "' As Code, '" & ClsMain.InOut.GateIn & "' As Name " & _
                    " UNION ALL " & _
                    " Select '" & ClsMain.InOut.GateOut & "' As Code, '" & ClsMain.InOut.GateOut & "' As Name "
            TxtInOut.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

            mQry = "SELECT H.DocID AS Code, H.Manual_RefNo AS [Open No], " & _
                    " Sg.DispName AS [Member Name], H.VehicleNo AS [Vehicle No], H.VehicleType,  " & _
                    " CASE WHEN H.Close_Date IS NOT NULL THEN 'Yes' ELSE 'No' END AS IsClose, " & _
                    " H.InOut AS [Open Type], H.MeterReading, H.SubCode " & _
                    " FROM GateInOut H " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode = H.SubCode " & _
                    " Where H.V_Date <= " & AgL.ConvertDate(AgL.PubLoginDate) & " " & _
                    " ORDER BY Convert(SMALLDATETIME,Convert(VARCHAR,H.V_Date,106) + space(1) + H.V_Time) DESC "
            TxtOpenManualNo.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        Dim bStrDateTime As String = ""
        BlankText()
        DispText(True)

        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtDivision.AgSelectedValue = AgL.PubDivCode

        TxtInOut.Text = ClsMain.InOut.GateIn : mBlnIsCloseRecord = False

        If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
            TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
            LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
            TxtV_Type.Enabled = False
        Else
            TxtV_Type.Enabled = True
        End If


        mQry = " SELECT getdate ()"
        bStrDateTime = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar().ToString
        TxtV_Date.Text = Format(bStrDateTime, AgLibrary.ClsConstant.DateFormat_ShortDate)
        TxtEntryTime.Text = CDate(bStrDateTime).TimeOfDay.ToString.Substring(0, 5)
        TxtDateValue.Text = CDate(bStrDateTime).Year.ToString.Substring(2, 2) + CDate(bStrDateTime).Month.ToString.PadLeft(2, "0") + CDate(bStrDateTime).Date.ToString.Substring(0, 2).PadLeft(2, "0")

        mQry = " SELECT ISNULL(Max(substring(Manual_RefNo,7,4)),0) + 1  FROM GateInOut " & _
                " WHERE substring(Manual_RefNo,1,6)='" & TxtDateValue.Text & "' "
        TxtManualNo.Text = TxtDateValue.Text + AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar().ToString.PadLeft(4, "0")

        TxtParty.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False

        Try
            MastPos = BMBMaster.Position

            If mSearchCode.Trim <> "" Then
                If mBlnIsCloseRecord = False And mBlnIsClosed = True Then
                    MsgBox("Permission Denied!...")
                    Exit Sub
                End If

                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then
                    AgL.ECmd = AgL.GCn.CreateCommand
                    AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    AgL.ECmd.Transaction = AgL.ETrans
                    mTrans = True


                    If mBlnIsCloseRecord Then
                        mQry = " UPDATE GateInOut " & _
                                " SET " & _
                                " EntryDate = " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                                " EntryType = 'Edit', " & _
                                " Close_Date = Null, " & _
                                " Close_Time = Null, " & _
                                " Close_MeterReading = Null, " & _
                                " Close_EntryBy = Null, " & _
                                " Close_Remarks = Null " & _
                                " Where DocId = '" & mSearchCode & "'"
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                    Else
                        mQry = "DELETE FROM GateInOut WHERE DocID = " & mSearchCode & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                        mQry = "DELETE FROM GateInOut_Log WHERE DocID = " & mSearchCode & " "
                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
                    End If


                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, TxtInOut.Text)

                    AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

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
        DispText(True)
        TxtMeterReading.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Dim bCondStr = " Where 1=1 "
        Try

            bCondStr += " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & ""
            bCondStr += " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & ""
            bCondStr += " And H.V_Type in('" & ClsMain.Temp_NCat.MemberVisit & "')"

            AgL.PubFindQry = " SELECT H.DocID  + '1' AS SearchCode, " & _
                                " H.InOut As [In/ Out], H.Manual_RefNo AS [Open Entry No], " & _
                                " H.V_Date AS EntryDate, H.V_Time AS EntryTime,Sg.DispName as Member,   " & _
                                "  H.Remarks AS [Remark], " & _
                                " CASE WHEN H.Close_Date IS NOT NULL THEN 'Yes' ELSE 'No' END AS [Is Closed] " & _
                                " FROM dbo.GateInOut H " & _
                                " Left Join SubGroup Sg On Sg.Subcode = H.SubCode  " & _
                                " " & bCondStr & " " & _
                                " UNION ALL  " & _
                                " SELECT H.DocID  + '2' AS SearchCode,  " & _
                                " CASE IsNull(H.InOut,'') WHEN '" & ClsMain.InOut.GateOut & "' THEN '" & ClsMain.InOut.GateIn & "' WHEN '" & ClsMain.InOut.GateIn & "' THEN '" & ClsMain.InOut.GateOut & "' END AS [In/ Out],  " & _
                                " H.Manual_RefNo AS [Open Entry No],  " & _
                                " H.Close_Date AS EntryDate, H.Close_Time AS EntryTime,  " & _
                                " Sg.DispName as Member,   " & _
                                " H.Close_Remarks AS [Remark], " & _
                                " CASE WHEN H.Close_Date IS NOT NULL THEN 'Yes' ELSE 'No' END AS [Is Closed] " & _
                                " FROM dbo.GateInOut " & _
                                " H Left Join SubGroup Sg On Sg.Subcode = H.SubCode" & _
                                " " & bCondStr & " And H.Close_Date IS NOT NULL "

            AgL.PubFindQryOrdBy = "EntryDate DESC, SearchCode"

            ' *************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> "" Then

                If AgL.StrCmp(AgL.PubSearchRow.Substring(21, 1), "2") Then
                    mBlnIsCloseRecord = True
                Else
                    mBlnIsCloseRecord = False
                End If

                'AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                'BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
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
        '<Executable Code>
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


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            If Not mBlnIsCloseRecord Then
                If Topctrl1.Mode = "Add" Then
                    mQry = "INSERT INTO GateInOut (DocId, Div_Code, Site_Code, V_Date, V_Type, " & _
                        " V_Prefix, V_No, UID, " & _
                        " EntryBy, EntryDate, EntryType, EntryStatus, Status " & _
                        " ) " & _
                        " VALUES (" & _
                        " " & AgL.Chk_Text(mSearchCode) & ", '" & TxtDivision.AgSelectedValue & "',  " & _
                        " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & "," & AgL.ConvertDate(TxtV_Date.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & AgL.Chk_Text(LblPrefix.Text) & ", " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(mStrUid) & "," & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", 'Add', 'Open', 'Active' )"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If


                mQry = " UPDATE GateInOut " & _
                        " SET " & _
                        " InOut = " & AgL.Chk_Text(TxtInOut.Text) & ", " & _
                        " V_Date = " & AgL.Chk_Text(TxtV_Date.Text) & ", " & _
                        " V_Time = " & AgL.Chk_Text(TxtEntryTime.Text) & ", " & _
                        " SubCode = " & AgL.Chk_Text(TxtParty.AgSelectedValue) & ", " & _
                        " Manual_RefNo = " & AgL.Chk_Text(TxtManualNo.Text) & ", " & _
                        " VehicleType = " & AgL.Chk_Text(TxtMemberType.Text) & ", " & _
                        " VehicleNo = " & AgL.Chk_Text(TxtVehicleNo.Text) & ", " & _
                        " Driver = " & AgL.Chk_Text("") & ", " & _
                        " MeterReading = " & Val(TxtMeterReading.Text) & ", " & _
                        " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                        " EntryBy = " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                        " EntryDate = " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                        " EntryType = " & AgL.Chk_Text(Topctrl1.Mode) & " " & _
                        " Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = " UPDATE GateInOut " & _
                        " SET " & _
                        " EntryDate = " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & _
                        " EntryType = 'Edit', " & _
                        " Close_Date = " & AgL.Chk_Text(TxtV_Date.Text) & ", " & _
                        " Close_Time = " & AgL.Chk_Text(TxtEntryTime.Text) & ", " & _
                        " Close_MeterReading = " & Val(TxtMeterReading.Text) & ", " & _
                        " Close_EntryBy = " & AgL.Chk_Text(TxtCloseEntryBy.Text) & ", " & _
                        " Close_Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                        " Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            End If

            If TxtVehicleNo.Text.Trim <> "" Then
                mQry = "UPDATE Tp_Vehicle SET MeterReading = " & Val(TxtMeterReading.Text) & " " & _
                        " WHERE RegistrationNo = " & AgL.Chk_Text(TxtVehicleNo.Text) & " " & _
                        " AND MeterReading  < " & Val(TxtMeterReading.Text) & ""
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            AgL.UpdateVoucherCounter(mSearchCode, CDate(TxtV_Date.Text), AgL.GCn, AgL.ECmd, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, False)

            '--------------------------------------------------------------
            'Create a log entry of each activity like add, edit delete print
            '--------------------------------------------------------------
            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , TxtV_Date.Text, , , , TxtSite_Code.AgSelectedValue, TxtDivision.AgSelectedValue)
            '--------------------------------------------------------------

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False


            FIniMaster(0, 1)
            Topctrl1_tbRef()

            '--------------------------------------------------------
            'Set newly feeded record as current record
            'go to add mode once again
            '--------------------------------------------------------
            Topctrl1.LblDocId.Text = mSearchCode

            mTmV_Type = TxtV_Type.AgSelectedValue : mTmV_Prefix = LblPrefix.Text : mTmV_Date = TxtV_Date.Text : mTmV_NCat = LblV_Type.Tag

            Topctrl1.FButtonClick(0)
            Exit Sub



        Catch ex As Exception
            If mTrans = True Then AgL.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim DrTemp As DataRow() = Nothing
        Dim MastPos As Long = 0
        Try
            BlankText()

            If AgL.XNull(AgL.PubSearchRow).ToString.Trim <> "" Then
                mSearchCode = AgL.PubSearchRow.Substring(0, 21)
            End If

            If mSearchCode.Trim <> "" Then
                mQry = "Select H.* " & _
                        " From GateInOut As H " & _
                        " Where H.DocId='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    '---------------------------------------------------
                    'Common code for all entry and approval management
                    '---------------------------------------------------
                    TxtDocId.Text = AgL.XNull(.Rows(0)("DocID"))
                    TxtV_Type.AgSelectedValue = AgL.XNull(.Rows(0)("V_Type"))

                    Validating_Controls(TxtV_Type)
                    LblPrefix.Text = AgL.XNull(.Rows(0)("V_Prefix"))
                    TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                    TxtDivision.AgSelectedValue = AgL.XNull(.Rows(0)("Div_Code"))
                    TxtV_No.Text = AgL.VNull(.Rows(0)("V_No"))
                    TxtParty.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                    '---------------------------------------------------



                    TxtMemberType.Text = AgL.XNull(.Rows(0)("VehicleType"))

                    TxtVehicleNo.Text = AgL.XNull(.Rows(0)("VehicleNo"))
                    

                    TxtManualNo.Text = AgL.XNull(.Rows(0)("Manual_RefNo"))
                  

                    If mBlnIsCloseRecord Then
                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("Close_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtEntryTime.Text = AgL.XNull(.Rows(0)("Close_Time"))
                        TxtMeterReading.Text = Format(AgL.VNull(.Rows(0)("Close_MeterReading")), "0.00")

                        TxtRemarks.Text = AgL.XNull(.Rows(0)("Close_Remarks"))

                        If AgL.StrCmp(AgL.XNull(.Rows(0)("InOut")), ClsMain.InOut.GateIn) Then
                            TxtInOut.Text = ClsMain.InOut.GateOut
                        Else
                            TxtInOut.Text = ClsMain.InOut.GateIn
                        End If

                    Else
                        TxtV_Date.Text = Format(AgL.XNull(.Rows(0)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtEntryTime.Text = AgL.XNull(.Rows(0)("V_Time"))
                        TxtInOut.Text = AgL.XNull(.Rows(0)("InOut"))
                        TxtMeterReading.Text = Format(AgL.VNull(.Rows(0)("MeterReading")), "0.00")
                        TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                    End If

                    mBlnIsClosed = IIf(AgL.XNull(.Rows(0)("Close_Date")).ToString.Trim <> "", True, False)

                End With

            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)

            If mSearchCode.Trim <> "" Then
                Topctrl1.tEdit = IIf(InStr(Topctrl1.Tag, "E") > 0, True, False)
                Topctrl1.tDel = IIf(InStr(Topctrl1.Tag, "D") > 0, True, False)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
            Topctrl1.tFind = True
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""

        mBlnIsClosed = False
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False : TxtV_No.Enabled = False
        TxtEntryTime.Enabled = False : TxtV_Date.Enabled = False
        TxtInOut.Enabled = False : TxtDriverName.Enabled = False
        TxtMemberType.Enabled = False : TxtVehicleName.Enabled = False
        TxtManualNo.Enabled = False

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtV_Type.Enabled = False

            If mBlnIsClosed Or mBlnIsCloseRecord Then
                TxtVehicleNo.Enabled = False
                TxtParty.Enabled = False
                TxtManualNo.Enabled = False
            End If

        End If
    End Sub

    Sub Calculation()
        '<Executale Code>
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtDocId.Validating, TxtSite_Code.Validating, TxtV_Type.Validating, TxtV_Date.Validating, TxtV_No.Validating, _
        TxtParty.Validating, TxtVehicleName.Validating, TxtVehicleNo.Validating, _
        TxtMemberType.Validating, TxtRemarks.Validating, TxtInOut.Validating, TxtOpenManualNo.Validating
        Dim DrTemp As DataRow() = Nothing

        Try
            Select Case sender.name
                Case TxtInOut.Name
                    Validating_Controls(sender)

                Case TxtVehicleNo.Name
                    Validating_Controls(sender)

                Case TxtParty.Name
                    Validating_Controls(sender)

                Case TxtOpenManualNo.Name
                    Validating_Controls(sender)
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TxtV_Type.Enter, TxtParty.Enter, TxtVehicleName.Enter, TxtVehicleNo.Enter, _
        TxtMemberType.Enter, TxtRemarks.Enter

        Dim bStrFilter$ = ""
        Try
            Select Case sender.name
                Case TxtParty.Name
                    TxtParty.AgRowFilter = " IsDeleted = 0 "

                Case TxtOpenManualNo.Name
                    TxtOpenManualNo.AgRowFilter = " IsClose = 'No' "

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0, J As Integer = 0
        Dim bStudentCode$ = ""
        Try
            Dim ChildDataPassed As Boolean = True

            Call Calculation()
            If AgL.RequiredField(TxtSite_Code, "Site/Branch") Then Exit Function
            'If AgL.RequiredField(TxtV_Type, LblV_Type.Text) Then Exit Function
            If AgL.RequiredField(TxtV_Date, LblV_Date.Text) Then Exit Function
            If Not AgL.IsValidDate(TxtV_Date, AgL.PubStartDate, AgL.PubEndDate) Then Exit Function


            'If Not AgCL.AgCheckMandatory(Me) Then Exit Function


            If Topctrl1.Mode = "Add" Then
                If mBlnIsCloseRecord = False Then
                    If TxtOpenManualNo.Text.Trim <> "" Then
                        mBlnIsCloseRecord = True
                    End If
                End If

                If Not mBlnIsCloseRecord Then
                    TxtDateValue.Text = CDate(TxtV_Date.Text).Year.ToString.Substring(2, 2) + CDate(TxtV_Date.Text).Month.ToString.PadLeft(2, "0") + CDate(TxtV_Date.Text).Date.ToString.Substring(0, 2).PadLeft(2, "0")

                    mQry = " SELECT ISNULL(Max(substring(Manual_RefNo,7,4)),0) + 1  FROM GateInOut " & _
                            " WHERE substring(Manual_RefNo,1,6)='" & TxtDateValue.Text & "' "
                    TxtManualNo.Text = TxtDateValue.Text + AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar().ToString.PadLeft(4, "0")


                    mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue)
                    TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
                    LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)

                    If mSearchCode <> TxtDocId.Text And TxtDocId.Text.Trim <> "" Then
                        MsgBox("DocId : " & TxtDocId.Text & " Already Exist New DocId Alloted : " & mSearchCode & "")
                        TxtDocId.Text = mSearchCode
                    End If

                    mStrUid = AgL.XNull(AgL.GetGUID(AgL.Gcn_ConnectionString).ToString)
                Else
                    TxtCloseEntryBy.Text = AgL.PubUserName
                    mSearchCode = TxtOpenManualNo.AgSelectedValue
                End If
            End If

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

    'Public Overridable Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
    '    BlankText()
    '    DispText(True)

    '    TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
    '    TxtDivision.AgSelectedValue = AgL.PubDivCode

    '    If TxtV_Type.AgHelpDataSet.Tables(0).Rows.Count = 1 Then
    '        TxtV_Type.AgSelectedValue = TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("Code")
    '        LblV_Type.Tag = AgL.XNull(TxtV_Type.AgHelpDataSet.Tables(0).Rows(0)("NCat"))
    '        TxtV_Type.Enabled = False
    '    Else
    '        TxtV_Type.Enabled = True
    '    End If

    '    TxtV_Date.Text = AgL.PubLoginDate
    '    TxtV_Date.Text = AgL.RetFinancialYearDate(TxtV_Date.Text.ToString)

    '    If mTmV_Type.Trim = "" Then
    '        If TxtV_Type.Enabled = True Then TxtV_Type.Focus()
    '    End If

    '    If Topctrl1.Mode = "Add" And TxtV_Type.AgSelectedValue.Trim <> "" And TxtV_Date.Text.Trim <> "" And TxtSite_Code.Text.Trim <> "" And TxtDivision.Text.Trim <> "" Then
    '        mSearchCode = AgL.GetDocId(TxtV_Type.AgSelectedValue, CStr(TxtV_No.Text), CDate(TxtV_Date.Text), AgL.GCn, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue)
    '        TxtDocId.Text = mSearchCode
    '        TxtV_No.Text = Val(AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherNo))
    '        LblPrefix.Text = AgL.DeCodeDocID(mSearchCode, AgLibrary.ClsMain.DocIdPart.VoucherPrefix)
    '    End If

    '    TxtVehicleNo.Focus()
    'End Sub

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Public Function Validating_Controls(ByVal Sender As Object) As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim bBlnIsClosed As Boolean = False

        Select Case Sender.Name
            Case TxtV_Type.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    LblV_Type.Tag = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        LblV_Type.Tag = AgL.XNull(DrTemp(0)("NCat"))
                    End If
                End If

            Case TxtParty.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        'TxtDriverName.Text = AgL.XNull(DrTemp(0)("DispName"))
                    End If
                End If
                DrTemp = Nothing

                If TxtOpenManualNo.AgHelpDataSet.Tables(0).Rows.Count > 0 Then
                    DrTemp = TxtOpenManualNo.AgHelpDataSet.Tables(0).Select("[SubCode] = " & AgL.Chk_Text(TxtParty.AgSelectedValue) & "")
                    If DrTemp.Length > 0 Then
                        bBlnIsClosed = AgL.StrCmp("Yes", AgL.XNull(DrTemp(0)("IsClose")))

                        If Not bBlnIsClosed Then
                            TxtOpenManualNo.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
                            TxtManualNo.Text = AgL.XNull(DrTemp(0)("Open No"))

                            If AgL.StrCmp(AgL.XNull(DrTemp(0)("Open Type")), ClsMain.InOut.GateOut) Then
                                TxtInOut.Text = ClsMain.InOut.GateIn
                            Else
                                TxtInOut.Text = ClsMain.InOut.GateOut
                            End If
                        End If
                    Else
                        bBlnIsClosed = False
                        TxtOpenManualNo.AgSelectedValue = ""
                    End If

                    If TxtOpenManualNo.Text.Trim <> "" Then
                        TxtParty.Enabled = False
                    Else
                        TxtParty.Enabled = True
                    End If
                End If


            Case TxtVehicleNo.Name
                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    Sender.AgSelectedValue = ""
                    TxtVehicleName.Text = ""
                    TxtMeterReading.Text = ""
                    TxtMemberType.Text = ""
                    LblVehicleNo.Tag = ""

                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        LblVehicleNo.Tag = AgL.XNull(DrTemp(0)("VehicleCode"))
                        TxtVehicleName.Text = AgL.XNull(DrTemp(0)("Vehicle Name"))
                        TxtMeterReading.Text = IIf(AgL.VNull(DrTemp(0)("MeterReading")) > 0, Format(AgL.VNull(DrTemp(0)("MeterReading")), "0.00"), "")
                        TxtMemberType.Text = AgL.XNull(DrTemp(0)("Vehicle Type"))
                    End If
                End If
                DrTemp = Nothing

        End Select

        Validating_Controls = True
    End Function

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub
End Class