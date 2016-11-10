Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports System.IO

Public Class FrmDriver
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mGroupNature As String = "", mNature As String = ""
    Dim Photo_Byte As Byte(), StudentSignature_Byte As Byte()
    Dim _StrMasterType$ = ""

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


    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()
        '<Executable Code>
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
            _StrMasterType = Academic_ProjLib.ClsMain.MasterType.Driver

            AgL.WinSetting(Me, 550, 880, 0, 0)
            IniGrid()
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
                " Where E.MasterType = '" & Academic_ProjLib.ClsMain.MasterType.Driver & "' And " & _
                " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & ""
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Sub Ini_List()
        mQry = "Select Code As Code, Name As Name From SiteMast " & _
               " Where 1=1 Order By Name"
        TxtSite_Code.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT DISTINCT DispName AS code, DispName AS Name " & _
                " FROM SubGroup " & _
                " WHERE isnull(DispName,'')<>'' " & _
                " order by DispName "
        TxtDispName.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select SubCode  As Code, ManualCode As Name " & _
                " From SubGroup " & _
                " WHERE isnull(ManualCode,'')<>'' " & _
                " Order By ManualCode"
        TxtManualCode.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT city.CityCode AS code, City.CityName AS Name " & _
               " FROM City " & _
               " Order by  city.cityname "
        TxtCityCode.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select  Code  As Code, ManualCode As Name From Sch_Category " & _
                  "  Order By Description"
        TxtCategory.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select  Code  As Code, Description As Name From Sch_Religion " & _
           "  Order By Description"
        TxtReligion.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        AgCL.IniAgHelpList(TxtSex, "Male,Female")

        AgCL.IniAgHelpList(TxtBloodGroup, "A+,A-,B+,B-,AB+,AB-,O+,O-")



        mQry = "SELECT DISTINCT FatherNamePrefix AS code,FatherNamePrefix AS Name " & _
                " FROM SubGroup " & _
                " WHERE isnull(FatherNamePrefix,'')<>'' " & _
                " order by FatherNamePrefix "
        TxtFatherNamePrefix.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT A.GroupCode AS Code, A.GroupName AS Name, A.GroupNature , A.Nature, MainGrCode  " & _
                " FROM AcGroup A " & _
                " WHERE LEFT(MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ")='" & AgLibrary.ClsConstant.MainGRCodeSundryCreditors & "' AND " & _
                " MainGrLen >= " & AgLibrary.ClsConstant.MainGRLenSundryCreditors & " AND AliasYn = 'N'"
        TxtGroupCode.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        Dim DrTemp As DataRow() = Nothing

        BlankText()
        DispText(True)
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode

        DrTemp = TxtGroupCode.AgHelpDataSet.Tables(0).Select("MainGrCode = " & AgL.Chk_Text(AgLibrary.ClsConstant.MainGRCodeSundryCreditors) & "")
        If DrTemp.Length > 0 Then
            TxtGroupCode.AgSelectedValue = AgL.XNull(DrTemp(0)("Code"))
            ProcValidatingControl(TxtGroupCode)
        End If

        TxtDispName.Focus()
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

                    AgL.Dman_ExecuteNonQry("Delete From Pay_Employee Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From SubGroup_Image Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Subgroup Where SubCode='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "D", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

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
        TxtDispName.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try

            AgL.PubFindQry = "Select E.SubCode As SearchCode, Sg.DispName As [" & LblDispName.Text & "], Sg.ManualCode As [" & LblManualCode.Text & "], " & _
                                " E.Sex as [Male/Female], Sg.Fathername as [Father Name], " & AgL.ConvertDateField("E.DateOfJoin") & "  As [Joining Date], " & _
                                " " & AgL.ConvertDateField("E.DateOfResign") & " As [Resign Date], E.ResignRemark As [Region Remark],  " & _
                                " " & AgL.ConvertDateField("Sg.DOB") & " As [Birth Date] " & _
                                " From  Pay_Employee E " & _
                                " Left join SubGroup Sg On E.SubCode = Sg.SubCode " & _
                                " Where E.MasterType = '" & Academic_ProjLib.ClsMain.MasterType.Driver & "' And " & _
                                " " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "

            AgL.PubFindQryOrdBy = "[" & LblDispName.Text & "]"

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


            strQry = "Select Sg.Name As [Teacher Name], " & _
                             " Sg.Fathername as [Father Name], " & _
                             " city.cityname as [City Name] " & _
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
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True

            If Topctrl1.Mode = "Add" Then
                mSearchCode = AgL.CreateSubGroup(AgL, AgL.GCn, AgL.ECmd, AgL.Gcn_ConnectionString, TxtDispName.Text, TxtManualCode.Text, TxtGroupCode.AgSelectedValue, mGroupNature, mNature, AgLibrary.ClsConstant.SubGroupType_Other, TxtSite_Code.AgSelectedValue)

                mQry = "Insert Into SubGroup_Image(Subcode, Photo, Signature) Values('" & mSearchCode & "', Null, Null )"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "INSERT INTO Pay_Employee ( SubCode, MasterType, DateOfJoin, DateOfResign, " & _
                        " ResignRemark, Sex, BloodGroup, Religion, Category, IsTeachingStaff " & _
                        " ) " & _
                        " VALUES  ( " & _
                        " '" & mSearchCode & "', " & AgL.Chk_Text(_StrMasterType) & ", " & _
                        " " & AgL.ConvertDate(TxtDateOfJoin.Text) & ", " & AgL.ConvertDate(TxtDateOfResign.Text) & ", " & AgL.Chk_Text(TxtResignRemark.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtSex.Text) & ", " & AgL.Chk_Text(TxtBloodGroup.Text) & ", " & AgL.Chk_Text(TxtReligion.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtCategory.AgSelectedValue) & ", " & IIf(AgL.StrCmp(TxtIsTeachingStaff.Text, "Yes"), 1, 0) & ")"

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update SubGroup Set U_AE = 'E', Edit_Date = '" & Format(AgL.PubLoginDate, "Short Date") & "', ModifiedBy = '" & AgL.PubUserName & "' Where SubCode = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = "UPDATE Pay_Employee SET " & _
                        " MasterType = " & AgL.Chk_Text(_StrMasterType) & ", " & _
                        " DateOfJoin = " & AgL.ConvertDate(TxtDateOfJoin.Text) & ", " & _
                        " DateOfResign = " & AgL.ConvertDate(TxtDateOfResign.Text) & ", " & _
                        " ResignRemark = " & AgL.Chk_Text(TxtResignRemark.Text) & ", " & _
                        " Sex = " & AgL.Chk_Text(TxtSex.Text) & ", BloodGroup = " & AgL.Chk_Text(TxtBloodGroup.Text) & ", Religion = " & AgL.Chk_Text(TxtReligion.AgSelectedValue) & ", " & _
                        " Category = " & AgL.Chk_Text(TxtCategory.AgSelectedValue) & ", " & _
                        " IsTeachingStaff = " & IIf(AgL.StrCmp(TxtIsTeachingStaff.Text, "Yes"), 1, 0) & " " & _
                        " WHERE SubCode = '" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            mQry = "UPDATE SubGroup SET " & _
                    " ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & " , " & _
                    " Name = " & AgL.Chk_Text(TxtName.Text) & ", " & _
                    " DispName = " & AgL.Chk_Text(TxtDispName.Text) & "," & _
                    " GroupCode = '" & TxtGroupCode.AgSelectedValue & "', " & _
                    " GroupNature ='" & mGroupNature & "'," & _
                    " Nature = '" & mNature & "'," & _
                    " Add1 = " & AgL.Chk_Text(TxtAdd1.Text) & "," & _
                    " Add2 = " & AgL.Chk_Text(TxtAdd2.Text) & ",	 " & _
                    " CityCode = " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & "," & _
                    " PIN = " & Val(TxtPin.Text) & "," & _
                    " Phone =" & AgL.Chk_Text(TxtPhone.Text) & "," & _
                    " Mobile = " & AgL.Chk_Text(TxtMobile.Text) & ",	" & _
                    " PAN = " & AgL.Chk_Text(TxtPanNo.Text) & "," & _
                    " FatherName = " & AgL.Chk_Text(TxtFatherName.Text) & "," & _
                    " FatherNamePrefix = " & AgL.Chk_Text(TxtFatherNamePrefix.Text) & ", " & _
                    " DOB = " & AgL.ConvertDate(TxtDOB.Text) & "," & _
                    " EMail = " & AgL.Chk_Text(TxtEMail.Text) & ", " & _
                    " CommonAc = " & IIf(AgL.StrCmp(TxtCommonAc.Text, "Yes"), 1, 0) & " " & _
                    " WHERE SubCode = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()
            mTrans = False

            Update_Picture("SubGroup_Image", "Photo", "Where Subcode = '" & mSearchCode & "'", Photo_Byte)
            Update_Picture("SubGroup_Image", "Signature", "Where Subcode = '" & mSearchCode & "'", StudentSignature_Byte)

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

    Public Sub MoveRec()
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
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
                        TxtDispName.Text = AgL.XNull(.Rows(0)("DispName"))
                        TxtCommonAc.Text = IIf(AgL.VNull(.Rows(0)("CommonAc")), "Yes", "No")
                        TxtAdd1.Text = AgL.XNull(.Rows(0)("Add1"))
                        TxtAdd2.Text = AgL.XNull(.Rows(0)("Add2"))
                        TxtCityCode.AgSelectedValue = AgL.XNull(.Rows(0)("CityCode"))
                        TxtPanNo.Text = AgL.XNull(.Rows(0)("Pan"))
                        TxtPhone.Text = AgL.XNull(.Rows(0)("Phone"))
                        TxtPin.Text = AgL.VNull(.Rows(0)("Pin"))
                        TxtMobile.Text = AgL.XNull(.Rows(0)("Mobile"))
                        TxtEMail.Text = AgL.XNull(.Rows(0)("EMail"))
                        TxtDOB.Text = Format(AgL.XNull(.Rows(0)("DOB")), AgLibrary.ClsConstant.DateFormat_ShortDate)
                        TxtFatherName.Text = AgL.XNull(.Rows(0)("FatherName"))
                        TxtFatherNamePrefix.Text = AgL.XNull(.Rows(0)("FatherNamePrefix"))

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
                        TxtSex.Text = AgL.XNull(.Rows(0)("Sex"))
                        TxtReligion.AgSelectedValue = AgL.XNull(.Rows(0)("Religion"))
                        TxtCategory.AgSelectedValue = AgL.XNull(.Rows(0)("Category"))
                        TxtIsTeachingStaff.Text = IIf(AgL.VNull(.Rows(0)("IsTeachingStaff")), "Yes", "No")
                        TxtBloodGroup.Text = AgL.XNull(.Rows(0)("BloodGroup"))
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
        mSearchCode = "" : TxtIsTeachingStaff.Text = "No" : TxtCommonAc.Text = "No"


        PicPhoto.Image = Nothing : Photo_Byte = Nothing
        PicStudentSignature.Image = Nothing : StudentSignature_Byte = Nothing
    End Sub


    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtSite_Code.Enabled = False
        TxtName.Enabled = False
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
            If AgL.RequiredField(TxtSite_Code) Then Exit Function
            If AgL.RequiredField(TxtGroupCode, LblGroupCode.Text) Then Exit Function
            If AgL.RequiredField(TxtCommonAc, "Is Common A/c?") Then Exit Function
            If AgL.RequiredField(TxtDispName, LblDispName.Text) Then Exit Function
            If AgL.RequiredField(TxtManualCode, LblManualCode.Text) Then Exit Function

            If Not FunIsValidDateOfBirth() Then Exit Function
            If Not FunIsValidDateOfJoin() Then Exit Function
            If Not FunIsValidDateOfResign() Then Exit Function

            If TxtDateOfResign.Text.Trim <> "" Then If AgL.RequiredField(TxtResignRemark, "Resign Remark") Then Exit Function

            If TxtManualCode.Text.Trim <> "" Then
                TxtName.Text = TxtDispName.Text + Space(1) + "{" + TxtManualCode.Text + "}"
            Else
                TxtName.Text = TxtDispName.Text
            End If


            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where ManualCode='" & TxtManualCode.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where ManualCode='" & TxtManualCode.Text & "' And SubCode<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function
            End If


            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function


    Private Function IsNameExist(ByVal StrName As String) As Boolean
        Dim bBlnReturn As Boolean = False
        Try

        Catch ex As Exception

        End Try
    End Function



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

    Private Sub TxtIsInternationalStudent_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtSite_Code.Validating, TxtName.Validating, TxtIsTeachingStaff.Validating, TxtDispName.Validating, _
        TxtGroupCode.Validating, TxtManualCode.Validating, TxtDOB.Validating, TxtDateOfJoin.Validating, TxtResignRemark.Validating, TxtReligion.Validating, _
        TxtCategory.Validating, TxtSex.Validating, TxtBloodGroup.Validating, TxtAdd1.Validating, TxtAdd2.Validating, TxtCityCode.Validating, TxtPin.Validating, _
        TxtEMail.Validating, TxtPanNo.Validating, TxtPhone.Validating, TxtMobile.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtGroupCode.Name
                    ProcValidatingControl(sender)

                Case TxtIsTeachingStaff.Name
                    If TxtIsTeachingStaff.Text.Trim = "" Then TxtIsTeachingStaff.Text = "Yes"

                Case TxtDispName.Name, TxtManualCode.Name, TxtName.Name
                    TxtName.Text = TxtDispName.Text + Space(1) + "{" + TxtManualCode.Text + "}"

                Case TxtDOB.Name
                    Call FunIsValidDateOfBirth()

                Case TxtDateOfJoin.Name
                    Call FunIsValidDateOfJoin()

                Case TxtDateOfResign.Name
                    Call FunIsValidDateOfResign()

            End Select

            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Sub Calculation()
        Dim I As Integer = 0
        If Topctrl1.Mode = "Browse" Then Exit Sub

        'With DGL1
        '    For I = 0 To .Rows.Count - 1
        '        If .Item(Col1NetAmount, I).Value Is Nothing Then .Item(Col1NetAmount, I).Value = ""

        '        If .Item(Col1Fee, I).Value <> "" Then
        '            .Item(Col1NetAmount, I).Value = Format(Val(.Item(Col1Amount, I).Value) - Val(.Item(Col1Discount, I).Value), "0.00")
        '        End If
        '    Next
        'End With
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
        End Select
    End Sub
End Class