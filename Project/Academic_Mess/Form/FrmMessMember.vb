Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class FrmMessMember
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Dim mGroupNature$ = "", mNature$ = ""

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        Try
            '<Executable Code>
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
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
            CreateHelpDataSets()
            IniGrid()
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
            'AgL.WinSetting(Me, 500, 1000, 0, 0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        Dim bCondStr$ = " Where 1=1 "

        bCondStr += " And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "

        mQry = "Select H.SubCode As SearchCode " & _
                " From Mess_Member P With (NoLock) " & _
                " Left Join SubGroup H With (NoLock) On H.SubCode = P.SubCode " & _
                " " & bCondStr & " "
        Topctrl1.FIniForm(DTMaster, AgL.GcnRead, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast  With (NoLock) " & _
                            " Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "Select Div_Code, Div_Name From Division  With (NoLock) Order By Div_Name"
            TxtDivision.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)

            mQry = " SELECT H.Subcode AS Code, SG.DispName AS Name, SG.ManualCode, " & _
                    " '" & ClsMain.MemberType.Student & "' As [Member Type], " & _
                    " SG.FatherName, Sg.MotherName, SG.Add1, SG.Add2, SG.Add3, SG.CityCode, SG.CountryCode, " & _
                    " SG.Mobile, SG.FAX, SG.EMail, Sg.GroupCode, Sg.Party_Type, A.CurrentSemester, Sg.Name As MemberName " & _
                    " FROM Sch_Student H  With (NoLock)  " & _
                    " LEFT JOIN SubGroup Sg With (NoLock) ON Sg.SubCode=H.SubCode  " & _
                    " Left Join Sch_Admission A  With (NoLock) ON A.Student = H.SubCode  " & _
                    " UNION ALL " & _
                    " SELECT H.Subcode AS Code, SG.DispName AS Name, SG.ManualCode, " & _
                    " '" & ClsMain.MemberType.Employee & "' As [Member Type], " & _
                    " SG.FatherName, Sg.MotherName, SG.Add1, SG.Add2, SG.Add3, SG.CityCode, SG.CountryCode, " & _
                    " SG.Mobile, SG.FAX, SG.EMail, Sg.GroupCode, Sg.Party_Type, '' As CurrentSemester, Sg.Name As MemberName " & _
                    " FROM Pay_Employee H  With (NoLock) " & _
                    " LEFT JOIN SubGroup Sg  With (NoLock) ON Sg.SubCode=H.SubCode  "
            TxtMemberName.AgHelpDataSet(15) = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "Select Distinct DispName As Code, DispName As Name " & _
                    " From SubGroup  With (NoLock) " & _
                    " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " " & _
                    " And IsNull(DispName,'') <> '' " & _
                    " Order By DispName"
            TxtDispName.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "Select ManualCode As Code, ManualCode As Name " & _
                    " From SubGroup  With (NoLock) " & _
                    " Where IsNull(ManualCode,'')<>'' Order By ManualCode"
            TxtManualCode.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)


            mQry = "Select CityCode As Code, CityName As Name From City  With (NoLock) " & _
                " Order By CityName"
            TxtCityCode.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "Select Distinct FatherNamePrefix  As Code, FatherNamePrefix As Name From SubGroup With (NoLock)  " & _
                    " Where IsNull(FatherNamePrefix,'')<>'' " & _
                    " Order By FatherNamePrefix"
            TxtFatherNamePrefix.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT S.Code, S.StreamYearSemesterDesc AS Name, " & _
                    " S.StreamCode, S.Semester, S.SessionCode, S.ProgrammeCode, S.YearSerial " & _
                    " FROM ViewSch_StreamYearSemester S With (NoLock) " & _
                    " Order By S.StreamYearSemesterDesc "
            TxtStreamYearSemester.AgHelpDataSet(5) = AgL.FillData(mQry, AgL.GcnRead)

            mQry = " Select '" & ClsMain.MemberType.Student & "' As Code, '" & ClsMain.MemberType.Student & "' As Name " & _
                    " Union All " & _
                    " Select '" & ClsMain.MemberType.Employee & "' As Code, '" & ClsMain.MemberType.Employee & "' As Name "
            TxtMemberType.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GcnRead)

            Call IniAcGroupHelp()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub IniAcGroupHelp()
        Dim bCondStr$ = " Where 1=1 "
        Try
            bCondStr += " And AliasYn = 'N' "

            bCondStr += " And LEFT(MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ") in ('" & AgLibrary.ClsConstant.MainGRCodeSundryCreditors & "' , '" & AgLibrary.ClsConstant.MainGRCodeSundryDebtors & "') " & _
                        " AND MainGrLen >= " & AgLibrary.ClsConstant.MainGRLenSundryCreditors & " "

            mQry = "SELECT A.GroupCode AS Code, A.GroupName AS Name, A.GroupNature , A.Nature  " & _
                      " FROM AcGroup A With (NoLock) " & bCondStr
            TxtAcGroup.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GcnRead)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub CreateHelpDataSets()
        '<Executable Code>
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        Try
            BlankText()
            DispText(True)

            TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
            TxtDivision.AgSelectedValue = AgL.PubDivCode

            TxtJoiningDate.Text = AgL.PubLoginDate

            TxtJoiningDate.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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

                    AgL.Dman_ExecuteNonQry("Delete From Mess_Member Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , , mSearchCode, TxtMemberName.Text, TxtSite_Code.AgSelectedValue, AgL.PubDivCode)

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
        Try
            DispText(True)
            TxtJoiningDate.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        Dim bCondStr$ = " Where 1=1 "

        Try
            bCondStr += " And " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Site_Code", AgL.PubSiteCode, "CommonAc") & " "

            AgL.PubFindQry = "Select  H.SubCode As SearchCode, " & _
                                " H.Name As [" & LblMemberName.Text & "],  " & _
                                " " & AgL.ConvertDateField("P.JoiningDate") & " As [" & LblJoiningDate.Text & "], " & _
                                " H.ManualCode As [" & LblManualCode.Text & "], " & _
                                " H.DispName As [" & LblDispName.Text & "], " & _
                                " IsNull(H.Add1,'') + Space(1) +  IsNull(H.Add2,'') + Space(1) + IsNull(H.Add3,'') As [" & LblAdd1.Text & "],  " & _
                                " City.CityName As [" & LblCityCode.Text & "], " & _
                                " H.Phone As [Phone No.],  " & _
                                " H.Mobile As [Mobile No.], " & _
                                " H.FatherName As [" & LblFatherName.Text & "], " & _
                                " H.MotherName As [" & LblMotherName.Text & "], " & _
                                " " & AgL.ConvertDateField("P.InActiveDate") & " As [" & LblInActiveDate.Text & "] " & _
                                " From Mess_Member P With (NoLock) " & _
                                " Left Join SubGroup H With (NoLock) On H.SubCode = P.SubCode " & _
                                " Left Join  City  With (NoLock) On City.CityCode = H.CityCode " & _
                                " " & bCondStr & " "
            AgL.PubFindQryOrdBy = "Convert(SmallDateTime,[" & LblJoiningDate.Text & "]) Desc, [" & LblMemberName.Text & "]"

            '*************** common code start *****************
            AgL.PubObjFrmFind = New AgLibrary.frmFind(AgL)
            AgL.PubObjFrmFind.ShowDialog()
            AgL.PubObjFrmFind = Nothing
            If AgL.PubSearchRow <> " Then" Then
                AgL.PubDRFound = DTMaster.Rows.Find(AgL.PubSearchRow)
                BMBMaster.Position = DTMaster.Rows.IndexOf(AgL.PubDRFound)
                MoveRec()
            End If
            '*************** common code end  *****************
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        '<Executable Code>
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

            bApprovedDate = AgL.GetDateTime(AgL.GcnRead)

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

            mQry = "Update SubGroup Set Name = " & AgL.Chk_Text(TxtName.Text) & ", DispName = " & AgL.Chk_Text(TxtDispName.Text) & ", " & _
                    " GroupCode=" & AgL.Chk_Text(TxtAcGroup.AgSelectedValue) & ",GroupNature=" & AgL.Chk_Text(mGroupNature) & ",Nature=" & AgL.Chk_Text(mNature) & ", " & _
                    " ManualCode=" & AgL.Chk_Text(TxtManualCode.Text) & ",  " & _
                    " Add1 = " & AgL.Chk_Text(TxtAdd1.Text) & ",  " & _
                    " Add2 = " & AgL.Chk_Text(TxtAdd2.Text) & ", " & _
                    " Add3 = " & AgL.Chk_Text(TxtAdd3.Text) & ", " & _
                    " CityCode = " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & "," & _
                    " Phone = " & AgL.Chk_Text(TxtPhone.Text) & ", " & _
                    " Mobile = " & AgL.Chk_Text(TxtMobile.Text) & ", " & _
                    " DOB=" & AgL.ConvertDate(TxtDob.Text) & ", " & _
                    " FatherNamePrefix=" & AgL.Chk_Text(TxtFatherNamePrefix.Text) & ", " & _
                    " FatherName=" & AgL.Chk_Text(TxtFatherName.Text) & ", " & _
                    " MotherName=" & AgL.Chk_Text(TxtMotherName.Text) & ", " & _
                    " EMail = " & AgL.Chk_Text(TxtEMail.Text) & ", " & _
                    " CommonAc = " & IIf(AgL.StrCmp(TxtCommonAc.Text, "Yes"), 1, 0) & ", " & _
                    " Fax = " & AgL.Chk_Text(TxtPhone.Text) & ", " & _
                    " Pin = " & AgL.Chk_Text(TxtPin.Text) & ", " & _
                    " U_AE='E', " & _
                    " Edit_Date='" & Format(AgL.PubLoginDate, "Short Date") & "', " & _
                    " ModifiedBy = '" & AgL.PubUserName & "' " & _
                    " Where SubCode='" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            If Topctrl1.Mode = "Add" Then
                mQry = "INSERT INTO dbo.Mess_Member (" & _
                        " SubCode, Student, Employee, MemberType, JoiningDate, InActiveDate, MessAttendanceCode) " & _
                        " VALUES (" & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & _
                        " " & AgL.Chk_Text(TxtStudentCode.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtEmployeeCode.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtMemberType.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtJoiningDate.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtInActiveDate.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtMessAttendanceCode.Text) & " " & _
                        " ) "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "UPDATE dbo.Mess_Member " & _
                        " SET " & _
                        " 	Student = " & AgL.Chk_Text(TxtStudentCode.Text) & ", " & _
                        " 	Employee = " & AgL.Chk_Text(TxtEmployeeCode.Text) & ", " & _
                        " 	MemberType = " & AgL.Chk_Text(TxtMemberType.Text) & ", " & _
                        " 	JoiningDate = " & AgL.Chk_Text(TxtJoiningDate.Text) & ", " & _
                        " 	InActiveDate = " & AgL.Chk_Text(TxtInActiveDate.Text) & ", " & _
                        "   MessAttendanceCode = " & AgL.Chk_Text(TxtMessAttendanceCode.Text) & " " & _
                        " Where SubCode='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd, , , mSearchCode, TxtMemberName.Text, TxtSite_Code.AgSelectedValue, AgL.PubDivCode)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

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

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim bDtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
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
                DsTemp = AgL.FillData(mQry, AgL.GcnRead)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = AgL.XNull(.Rows(0)("Site_Code"))
                        TxtDivision.AgSelectedValue = AgL.XNull(.Rows(0)("Div_Code"))
                        TxtCommonAc.Text = IIf(AgL.VNull(.Rows(0)("CommonAc")), "Yes", "No")

                        TxtMemberName.AgSelectedValue = AgL.XNull(.Rows(0)("SubCode"))
                        TxtDispName.Text = AgL.XNull(.Rows(0)("DispName"))
                        TxtManualCode.Text = AgL.XNull(.Rows(0)("ManualCode"))
                        TxtAcGroup.AgSelectedValue = AgL.XNull(.Rows(0)("GroupCode"))
                        mGroupNature = AgL.XNull(.Rows(0)("GroupNature"))
                        mNature = AgL.XNull(.Rows(0)("Nature"))

                        TxtFatherNamePrefix.Text = AgL.XNull(.Rows(0)("FatherNamePrefix"))
                        TxtFatherName.Text = AgL.XNull(.Rows(0)("FatherName"))
                        TxtMotherName.Text = AgL.XNull(.Rows(0)("MotherName"))
                        TxtAdd1.Text = AgL.XNull(.Rows(0)("Add1"))
                        TxtAdd2.Text = AgL.XNull(.Rows(0)("Add2"))
                        TxtAdd3.Text = AgL.XNull(.Rows(0)("Add3"))
                        TxtPin.Text = AgL.XNull(.Rows(0)("Pin"))
                        TxtCityCode.AgSelectedValue = AgL.XNull(.Rows(0)("CityCode"))
                        TxtPhone.Text = AgL.XNull(.Rows(0)("Phone"))
                        TxtMobile.Text = AgL.XNull(.Rows(0)("Mobile"))
                        TxtFax.Text = AgL.XNull(.Rows(0)("Fax"))

                        TxtEMail.Text = AgL.XNull(.Rows(0)("EMail"))
                        TxtDob.Text = Format(AgL.XNull(.Rows(0)("DOB")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                        TxtPrepared.Text = AgL.XNull(.Rows(0)("U_Name"))
                        TxtModified.Text = AgL.XNull(.Rows(0)("ModifiedBy"))
                        GBoxModified.Visible = IIf(TxtModified.Text.Trim <> "", True, False)
                        '---------------------------------------------------
                    End If
                End With

                If mSearchCode.Trim <> "" Then
                    mQry = "SELECT P.* FROM Mess_Member P WITH (NoLock) WHERE P.SubCode = '" & mSearchCode & "' "
                    bDtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                    With bDtTemp
                        If .Rows.Count > 0 Then
                            TxtJoiningDate.Text = Format(AgL.XNull(.Rows(0)("JoiningDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            TxtInActiveDate.Text = Format(AgL.XNull(.Rows(0)("InActiveDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                            TxtStudentCode.Text = AgL.XNull(.Rows(0)("Student"))
                            TxtEmployeeCode.Text = AgL.XNull(.Rows(0)("Employee"))
                            TxtMemberType.Text = AgL.XNull(.Rows(0)("MemberType"))
                            txtReminderRemark.Text = AgL.XNull(.Rows(0)("ReminderRemark"))
                            TxtMessAttendanceCode.Text = AgL.XNull(.Rows(0)("MessAttendanceCode"))

                            If AgL.XNull(.Rows(0)("Student")).ToString.Trim <> "" Then
                                DrTemp = TxtMemberName.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtMemberName.AgSelectedValue) & "")
                                If DrTemp.Length > 0 Then
                                    TxtStreamYearSemester.AgSelectedValue = AgL.XNull(DrTemp(0)("CurrentSemester"))
                                End If
                            End If


                        End If
                    End With
                End If
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

        TxtCommonAc.Text = "Yes"
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
        TxtManualCode.Enabled = False

        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then
            TxtMemberType.Enabled = False
            TxtMemberName.Enabled = False
            TxtStreamYearSemester.Enabled = False
        End If
    End Sub

    Sub Calculation()
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        '<Executable Code>
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

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles TxtSite_Code.Enter, TxtDispName.Enter, TxtMemberName.Enter, TxtManualCode.Enter, _
        TxtCityCode.Enter, TxtAdd1.Enter, TxtAdd2.Enter, TxtAdd3.Enter, _
        TxtMobile.Enter, TxtPhone.Enter, TxtEMail.Enter, TxtFatherName.Enter, _
        TxtFatherNamePrefix.Enter, TxtAcGroup.Enter, TxtInActiveDate.Enter, TxtDob.Enter, _
        TxtMemberType.Enter, TxtMemberName.Enter, TxtStreamYearSemester.Enter, _
        TxtStudentCode.Enter, TxtEmployeeCode.Enter, TxtMessAttendanceCode.Enter

        Dim bStrFilter$ = ""

        Try
            Select Case sender.name
                Case TxtStreamYearSemester.Name
                    If Not AgL.StrCmp(TxtMemberType.Text, ClsMain.MemberType.Student) Then
                        bStrFilter = " 1=2 "
                    Else
                        bStrFilter = " 1=1 "
                    End If
                    sender.AgRowFilter = bStrFilter

                Case TxtMemberName.Name
                    bStrFilter = " 1=1 "
                    bStrFilter += " And [Member Type] = " & AgL.Chk_Text(TxtMemberType.Text) & " "

                    If AgL.StrCmp(TxtMemberType.Text, ClsMain.MemberType.Student) Then
                        bStrFilter += " And CurrentSemester = " & AgL.Chk_Text(TxtStreamYearSemester.AgSelectedValue) & " "
                    End If

                    sender.AgRowFilter = bStrFilter
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles TxtSite_Code.Validating, TxtDispName.Validating, TxtManualCode.Validating, _
                TxtCityCode.Validating, TxtAdd1.Validating, TxtAdd2.Validating, TxtAdd3.Validating, _
                TxtMobile.Validating, TxtPhone.Validating, TxtEMail.Validating, TxtFatherName.Validating, _
                TxtFatherNamePrefix.Validating, TxtAcGroup.Validating, TxtInActiveDate.Validating, TxtDob.Validating, _
                TxtMemberType.Validating, TxtMemberName.Validating, TxtStreamYearSemester.Validating, _
                TxtStudentCode.Validating, TxtEmployeeCode.Validating, TxtJoiningDate.Validating, TxtMessAttendanceCode.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtAcGroup.Name
                    Call Validating_Controls(sender)

                Case TxtJoiningDate.Name
                    If TxtJoiningDate.Text.Trim = "" Then TxtJoiningDate.Text = AgL.PubLoginDate

                Case TxtInActiveDate.Name
                    Call Validating_Controls(sender)

                Case TxtMemberName.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        sender.AgSelectedValue = ""
                        TxtManualCode.Text = ""
                        TxtName.Text = ""
                        TxtDispName.Text = ""
                        TxtFatherName.Text = ""
                        TxtMotherName.Text = ""
                        TxtAdd1.Text = ""
                        TxtAdd2.Text = ""
                        TxtAdd3.Text = ""
                        TxtCityCode.AgSelectedValue = ""
                        TxtEMail.Text = ""
                        TxtFax.Text = ""
                        TxtPhone.Text = ""

                        TxtEmployeeCode.Text = ""
                        TxtStudentCode.Text = ""
                        TxtAcGroup.AgSelectedValue = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtManualCode.Text = AgL.XNull(DrTemp(0)("ManualCode"))
                            TxtName.Text = AgL.XNull(DrTemp(0)("MemberName"))
                            TxtDispName.Text = AgL.XNull(DrTemp(0)("Name"))
                            TxtFatherName.Text = AgL.XNull(DrTemp(0)("FatherName"))
                            TxtMotherName.Text = AgL.XNull(DrTemp(0)("MotherName"))
                            TxtAdd1.Text = AgL.XNull(DrTemp(0)("Add1"))
                            TxtAdd2.Text = AgL.XNull(DrTemp(0)("Add2"))
                            TxtAdd3.Text = AgL.XNull(DrTemp(0)("Add3"))
                            TxtCityCode.AgSelectedValue = AgL.XNull(DrTemp(0)("CityCode"))
                            TxtEMail.Text = AgL.XNull(DrTemp(0)("EMail"))
                            TxtFax.Text = AgL.XNull(DrTemp(0)("FAX"))
                            TxtPhone.Text = AgL.XNull(DrTemp(0)("Mobile"))
                            TxtAcGroup.AgSelectedValue = AgL.XNull(DrTemp(0)("GroupCode"))

                            If AgL.StrCmp(AgL.XNull(DrTemp(0)("Member Type")), ClsMain.MemberType.Employee) Then
                                TxtEmployeeCode.Text = TxtMemberName.AgSelectedValue
                                TxtStudentCode.Text = ""

                            ElseIf AgL.StrCmp(AgL.XNull(DrTemp(0)("Member Type")), ClsMain.MemberType.Student) Then
                                TxtEmployeeCode.Text = ""
                                TxtStudentCode.Text = TxtMemberName.AgSelectedValue

                            Else
                                TxtEmployeeCode.Text = ""
                                TxtStudentCode.Text = ""
                            End If
                        End If
                    End If

                    Call Validating_Controls(TxtAcGroup)

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
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        mGroupNature = AgL.XNull(DrTemp(0)("GroupNature"))
                        mNature = AgL.XNull(DrTemp(0)("Nature"))
                    End If
                End If
                DrTemp = Nothing

        End Select

        Validating_Controls = True
    End Function

    Private Function Data_Validation() As Boolean
        Try
            Call Calculation()

            If AgL.RequiredField(TxtSite_Code, LblSite_Code.Text) Then Exit Function
            If AgL.RequiredField(TxtJoiningDate, LblJoiningDate.Text) Then Exit Function
            If AgL.RequiredField(TxtMemberType, LblMemberType.Text) Then Exit Function
            If AgL.RequiredField(TxtMemberName, LblMemberName.Text) Then Exit Function
            If AgL.RequiredField(TxtDispName, LblDispName.Text) Then Exit Function
            If AgL.RequiredField(TxtManualCode, LblManualCode.Text) Then Exit Function
            If AgL.RequiredField(TxtAcGroup, LblAcGroup.Text) Then Exit Function

            If TxtEMail.Text.Trim <> "" Then If Not AgL.IsValid_EMailId(TxtEMail, "EMail ID") Then Exit Function

            If TxtDob.Text.Trim <> "" Then
                If CDate(TxtDob.Text) >= CDate(TxtJoiningDate.Text) Then
                    MsgBox("Date of Birth >= Joining Date!...", MsgBoxStyle.Information, "Validation Check")
                    TxtDob.Focus() : Exit Function
                End If
            End If

            If TxtInActiveDate.Text.Trim <> "" Then
                If CDate(TxtJoiningDate.Text) > CDate(TxtInActiveDate.Text) Then
                    MsgBox("Inactive Date < Joining Date!...", MsgBoxStyle.Information, "Validation Check")
                    TxtInActiveDate.Focus() : Exit Function
                End If

                If TxtDob.Text.Trim <> "" Then
                    If CDate(TxtDob.Text) >= CDate(TxtInActiveDate.Text) Then
                        MsgBox("Please Check Inactive Date!...", MsgBoxStyle.Information, "Validation Check")
                        TxtInActiveDate.Focus() : Exit Function
                    End If
                End If
            End If

            If TxtMessAttendanceCode.Text.Trim <> "" Then
                mQry = "SELECT IsNull(COUNT(*),0) AS Cnt " & _
                        " FROM Mess_Member H With (NoLock) " & _
                        " WHERE H.MessAttendanceCode = " & AgL.Chk_Text(TxtMessAttendanceCode.Text) & " " & _
                        " And " & IIf(AgL.StrCmp(Topctrl1.Mode, "Add"), " 1=1 ", " H.SubCode <> " & AgL.Chk_Text(TxtMemberName.AgSelectedValue) & "") & " "
                If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
                    MsgBox("Attendance Code Already Exists!...") : TxtMessAttendanceCode.Focus() : Exit Function
                End If
            End If

            If AgL.StrCmp(Topctrl1.Mode, "Add") Then
                mSearchCode = TxtMemberName.AgSelectedValue

                mQry = "SELECT IsNull(COUNT(*),0) AS Cnt FROM Mess_Member H With (NoLock) WHERE H.SubCode = " & AgL.Chk_Text(TxtMemberName.AgSelectedValue) & " "
                If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
                    MsgBox("Member Already Exists!...") : Exit Function
                End If
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function


    Public Sub FindMove(ByVal SearchCode As String)
        Try
            If SearchCode <> "" Then
                AgL.PubSearchRow = SearchCode
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

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

End Class
