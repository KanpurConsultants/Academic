Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Imports System.Data.SqlClient

Public Class FrmEmployeeMaster
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""
    Dim mGroupNature As String = "", mNature As String = ""
    Dim Photo_Byte As Byte(), EmployeeSignature_Byte As Byte()

    Dim Agl As AgLibrary.ClsMain
    Dim mMasterType As String = "NA"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable, ByVal AgLibVar As AgLibrary.ClsMain)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Agl = AgLibVar
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Public Property MasterType() As String
        Get
            Return mMasterType
        End Get
        Set(ByVal value As String)
            mMasterType = value
        End Set
    End Property

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Agl.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
    End Sub

    Private Sub IniGrid()

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
            Agl.WinSetting(Me, 600, 950, 0, 0)
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
        mQry = " SELECT CED.SubCode AS SearchCode " & _
                " FROM CommonEmployeeDetail CED  " & _
                " Where CED.MasterType=" & Agl.Chk_Text(mMasterType) & ""


        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)

    End Sub

    Sub Ini_List()
        Try
            mQry = "Select Code As Code, Name As Name From SiteMast " & _
                    " Where 1=1 Order By Name"
            TxtSite_Code.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = "Select SubCode  As Code, Name As Name From SubGroup with(NOLOCK) " & _
                " Order By Name"
            TxtName.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

            mQry = " SELECT CED.SubCode AS Code,SG.DispName AS Name" & _
                    " FROM CommonEmployeeDetail CED " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=CED.SubCode " & _
                    " WHERE CED.MasterType = " & Agl.Chk_Text(mMasterType) & " Order By Name"

            TxtDispName.AgHelpDataSet = Agl.FillData(mQry, Agl.GCn)

            mQry = " SELECT CED.SubCode AS Code,SG.ManualCode AS Name" & _
                " FROM CommonEmployeeDetail CED " & _
                " LEFT JOIN SubGroup SG ON SG.SubCode=CED.SubCode " & _
                " WHERE CED.MasterType = " & Agl.Chk_Text(mMasterType) & " Order By Name"

            TxtManualCode.AgHelpDataSet = Agl.FillData(mQry, Agl.GCn)

            mQry = "Select CityCode As Code, CityName As Name From City " & _
                " Order By CityName"
            txtCity.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)


            mQry = "SELECT A.GroupCode AS Code, A.GroupName AS Name, A.GroupNature , A.Nature  " & _
                    " FROM AcGroup A " & _
                    " WHERE LEFT(MainGrCode," & AgLibrary.ClsConstant.MainGRLenSundryCreditors & ")='" & AgLibrary.ClsConstant.MainGRCodeSundryCreditors & "' AND " & _
                    " MainGrLen > " & AgLibrary.ClsConstant.MainGRLenSundryCreditors & " AND AliasYn = 'N'"
            TxtGroupCode.AgHelpDataSet(2) = Agl.FillData(mQry, Agl.GCn)


            mQry = "Select 'Team Leader' As Code, 'Team Leader' as Name  "
            mQry = mQry & " Union All Select 'Team Member' As Code, 'Team Member' as Name  "
            TxtRank.AgHelpDataSet = Agl.FillData(mQry, Agl.GCn)


            mQry = "Select SubCode as Code, Name From SubGroup Where Rank='Team Leader' Order by Name"
            TxtUnderEmployee.AgHelpDataSet = Agl.FillData(mQry, Agl.GCn)


            AgCL.IniAgHelpList(TxtDepartment, "Marketing,Production,Admin,Support,Misclaneous ")

            mQry = "SELECT Code, Description FROM dbo.CommonMaster1 WHERE ModuleType ='" & Module_Type_DManager & "' AND MasterType ='" & Master_Type_CostCenter & "' ORDER BY Description  "
            TxtCostCenter.AgHelpDataSet = Agl.FillData(mQry, Agl.GCn)


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText()
        TxtSite_Code.AgSelectedValue = AgL.PubSiteCode
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbDel() Handles Topctrl1.tbDel
        Dim BlnTrans As Boolean = False
        Dim GCnCmd As New SqlClient.SqlCommand
        Dim MastPos As Long
        Dim mTrans As Boolean = False

        Try
            MastPos = BMBMaster.Position

            If Agl.PubMoveRecApplicable And BMBMaster.Position >= 0 Then
                If MsgBox("Are You Sure To Delete This Record?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = vbYes Then


                    Agl.ECmd = Agl.GCn.CreateCommand
                    Agl.ETrans = Agl.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
                    Agl.ECmd.Transaction = Agl.ETrans
                    mTrans = True

                    Agl.Dman_ExecuteNonQry("Delete From SubGroup_Image Where SubCode='" & mSearchCode & "'", Agl.GCn, Agl.ECmd)
                    Agl.Dman_ExecuteNonQry("Delete From CommonEmployeeDetail Where SubCode='" & mSearchCode & "'", Agl.GCn, Agl.ECmd)
                    Agl.Dman_ExecuteNonQry("Delete From SubGroup Where SubCode='" & mSearchCode & "'", Agl.GCn, Agl.ECmd)

                    Call Agl.LogTableEntry(mSearchCode, Me.Text, "D", Agl.PubMachineName, Agl.PubUserName, Agl.PubLoginDate, Agl.GCn, Agl.ECmd)

                    Agl.SynchroniseSiteOnLineData(Agl, Agl.GCn, Agl.Gcn_ConnectionString, Agl.GcnSite_ConnectionString, Agl.ECmd)

                    Agl.ETrans.Commit()
                    mTrans = False

                    FIniMaster(1)
                    Topctrl1_tbRef()
                    MoveRec()
                End If
            End If
        Catch Ex As Exception
            If mTrans = True Then Agl.ETrans.Rollback()
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub
    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText()
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try

            Agl.PubFindQry = " SELECT CED.SubCode AS SearchCode,SG.ManualCode AS [Employee ID NO],SG.Name AS [Employee Name], " & _
                    " SG.Add1 AS Address1,SG.Add2 AS Address2,SG.Add3 AS Address3,C.CityName AS City ,SG.Mobile AS [Mobile No.] " & _
                    " FROM CommonEmployeeDetail CED " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=CED.SubCode " & _
                    " LEFT JOIN City C ON C.CityCode=SG.CityCode " & _
                    " WHERE CED.MasterType = " & Agl.Chk_Text(mMasterType) & " "

            Agl.PubFindQryOrdBy = "[Employee Name]"

            '*************** common code start *****************
            Agl.PubObjFrmFind = New AgLibrary.frmFind(Agl)
            Agl.PubObjFrmFind.ShowDialog()
            Agl.PubObjFrmFind = Nothing
            If Agl.PubSearchRow <> " Then" Then
                Agl.PubDRFound = DTMaster.Rows.Find(Agl.PubSearchRow)
                BMBMaster.Position = DTMaster.Rows.IndexOf(Agl.PubDRFound)
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

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Try
            MastPos = BMBMaster.Position

            If Not Data_Validation() Then Exit Sub

            Agl.ECmd = Agl.GCn.CreateCommand
            Agl.ETrans = Agl.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            Agl.ECmd.Transaction = Agl.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mSearchCode = Agl.CreateSubGroup(Agl, Agl.GCn, Agl.ECmd, Agl.Gcn_ConnectionString, TxtDispName.Text, TxtManualCode.Text, TxtGroupCode.AgSelectedValue, mGroupNature, mNature, AgLibrary.ClsConstant.EmployeeType, TxtSite_Code.AgSelectedValue)

                mQry = "Insert Into SubGroup_Image(Subcode, Photo, Signature) Values('" & mSearchCode & "', Null, Null )"
                Agl.Dman_ExecuteNonQry(mQry, Agl.GCn, Agl.ECmd)


                mQry = " INSERT INTO CommonEmployeeDetail	(SubCode,MasterType,Salary)" & _
                   " VALUES ('" & mSearchCode & "', " & Agl.Chk_Text(mMasterType) & ", " & Val(TxtSalary.Text) & " )"
                Agl.Dman_ExecuteNonQry(mQry, Agl.GCn, Agl.ECmd)
            Else
                mQry = "Update SubGroup Set U_AE = 'E', Edit_Date = '" & Format(Agl.PubLoginDate, "Short Date") & "', ModifiedBy = '" & Agl.PubUserName & "' Where SubCode = '" & mSearchCode & "' "
                Agl.Dman_ExecuteNonQry(mQry, Agl.GCn, Agl.ECmd)


                mQry = " UPDATE CommonEmployeeDetail " & _
                        " SET MasterType=" & Agl.Chk_Text(mMasterType) & "," & _
                        " Salary = " & Val(TxtSalary.Text) & " " & _
                        " WHERE SubCode = '" & mSearchCode & "'"

                Agl.Dman_ExecuteNonQry(mQry, Agl.GCn, Agl.ECmd)
            End If

            mQry = "UPDATE SubGroup SET Name = " & Agl.Chk_Text(TxtName.Text) & ",	DispName = " & Agl.Chk_Text(TxtDispName.Text) & ",	GroupCode = '" & TxtGroupCode.AgSelectedValue & "', " & _
                     " GroupNature ='" & mGroupNature & "',	Nature = '" & mNature & "',	Add1 = " & Agl.Chk_Text(TxtAdd1.Text) & ",	Add2 = " & Agl.Chk_Text(TxtAdd2.Text) & ",Add3 = " & Agl.Chk_Text(TxtAdd3.Text) & ",	 " & _
                     " CityCode = " & Agl.Chk_Text(txtCity.AgSelectedValue) & ", PIN = " & Val(TxtPin.Text) & ",	Phone =" & Agl.Chk_Text(TxtPhone.Text) & ",	Mobile = " & Agl.Chk_Text(TxtMobile.Text) & ",	" & _
                     " PAN = " & Agl.Chk_Text(TxtPanNo.Text) & ", " & _
                     " DOB = " & Agl.ConvertDate(TxtDob.Text) & ", " & _
                     " EMail = " & Agl.Chk_Text(TxtEMail.Text) & ", " & _
                     " Rank = " & Agl.Chk_Text(TxtRank.AgSelectedValue) & ",  " & _
                     " UnderSubCode=" & Agl.Chk_Text(TxtUnderEmployee.AgSelectedValue) & ", Department=" & Agl.Chk_Text(TxtDepartment.AgSelectedValue) & ", " & _
                     " CostCenter = " & Agl.Chk_Text(TxtCostCenter.AgSelectedValue) & ", " & _
                     " CommonAc = 1 " & _
                     " WHERE SubCode = '" & mSearchCode & "'"
            Agl.Dman_ExecuteNonQry(mQry, Agl.GCn, Agl.ECmd)

            Call Agl.LogTableEntry(mSearchCode, Me.Text, Agl.MidStr(Topctrl1.Mode, 0, 1), Agl.PubMachineName, Agl.PubUserName, Agl.PubLoginDate, Agl.GCn, Agl.ECmd)

            Agl.SynchroniseSiteOnLineData(Agl, Agl.GCn, Agl.Gcn_ConnectionString, Agl.GcnSite_ConnectionString, Agl.ECmd)

            Agl.ETrans.Commit()
            mTrans = False

            Update_Picture("SubGroup_Image", "Photo", "Where Subcode = '" & mSearchCode & "'", Photo_Byte)
            Update_Picture("SubGroup_Image", "Signature", "Where Subcode = '" & mSearchCode & "'", EmployeeSignature_Byte)

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
            If mTrans = True Then Agl.ETrans.Rollback()
            MsgBox(ex.Message)
        End Try
    End Sub
    Sub Update_Picture(ByVal mTable As String, ByVal mColumn As String, ByVal mCondition As String, ByVal ByteArr As Byte())
        If ByteArr Is Nothing Then Exit Sub
        Dim sSQL As String = "Update " & mTable & " Set " & mColumn & "=@pic " & mCondition

        Dim cmd As SqlCommand = New SqlCommand(sSQL, Agl.GCn)
        Dim Pic As SqlParameter = New SqlParameter("@pic", SqlDbType.Image)
        Pic.Value = ByteArr
        cmd.Parameters.Add(Pic)
        cmd.ExecuteNonQuery()
    End Sub
    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Try
            FClear()
            BlankText()
            If Agl.PubMoveRecApplicable And BMBMaster.Position >= 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select SubGroup.* " & _
                    " From SubGroup Where SubCode='" & mSearchCode & "'"
                DsTemp = Agl.FillData(mQry, Agl.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        TxtSite_Code.AgSelectedValue = Agl.XNull(.Rows(0)("Site_Code"))
                        TxtManualCode.AgSelectedValue = Agl.XNull(.Rows(0)("SubCode"))
                        TxtName.AgSelectedValue = Agl.XNull(.Rows(0)("SubCode"))
                        TxtDispName.AgSelectedValue = Agl.XNull(.Rows(0)("SubCode"))
                        TxtGroupCode.AgSelectedValue = Agl.XNull(.Rows(0)("GroupCode"))
                        TxtAdd1.Text = Agl.XNull(.Rows(0)("Add1"))
                        TxtAdd2.Text = Agl.XNull(.Rows(0)("Add2"))
                        TxtAdd3.Text = Agl.XNull(.Rows(0)("Add3"))
                        txtCity.AgSelectedValue = Agl.XNull(.Rows(0)("CityCode"))
                        TxtMobile.Text = Agl.XNull(.Rows(0)("Mobile"))
                        TxtPhone.Text = Agl.XNull(.Rows(0)("Phone"))
                        TxtPin.Text = Agl.XNull(.Rows(0)("Pin"))
                        TxtPanNo.Text = Agl.XNull(.Rows(0)("PAN"))
                        TxtEMail.Text = Agl.XNull(.Rows(0)("EMail"))
                        TxtDob.Text = Agl.RetDate(Agl.XNull(.Rows(0)("DOB")))
                        TxtRank.AgSelectedValue = Agl.XNull(.Rows(0)("Rank"))
                        TxtUnderEmployee.AgSelectedValue = Agl.XNull(.Rows(0)("UnderSubcode"))
                        TxtCostCenter.AgSelectedValue = Agl.XNull(.Rows(0)("CostCenter"))
                        TxtDepartment.AgSelectedValue = Agl.XNull(.Rows(0)("Department"))
                        TxtPrepared.Text = Agl.XNull(.Rows(0)("U_Name"))
                        TxtModified.Text = Agl.XNull(.Rows(0)("ModifiedBy"))
                        GroupBox4.Visible = IIf(TxtModified.Text.Trim <> "", True, False)

                    End If

                    DsTemp = Nothing
                    mQry = "Select Dd.* " & _
                        " From CommonEmployeeDetail Dd Where SubCode='" & mSearchCode & "'"
                    DsTemp = Agl.FillData(mQry, Agl.GCn)
                    With DsTemp.Tables(0)
                        If .Rows.Count > 0 Then

                            TxtSalary.Text = Format(Agl.VNull(.Rows(0)("Salary")), "0.00")
                        End If
                    End With

                    DsTemp = Nothing

                    mQry = "Select Im.* " & _
                            " From SubGroup_Image Im Where Subcode='" & mSearchCode & "'"
                    DsTemp = Agl.FillData(mQry, Agl.GCn)
                    With DsTemp.Tables(0)
                        If .Rows.Count > 0 Then
                            If Not IsDBNull(.Rows(0)("Photo")) Then
                                Photo_Byte = DirectCast(.Rows(0)("Photo"), Byte())
                                Show_Picture(PicPhoto, Photo_Byte)
                            End If

                            If Not IsDBNull(.Rows(0)("Signature")) Then
                                EmployeeSignature_Byte = DirectCast(.Rows(0)("Signature"), Byte())
                                Show_Picture(PicEmployeeSignature, EmployeeSignature_Byte)
                            End If
                        End If
                    End With
                End With

            Else
                BlankText()
            End If
            Topctrl1.FSetDispRec(BMBMaster)
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DsTemp = Nothing
        End Try
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
        PicPhoto.Image = Nothing : Photo_Byte = Nothing
        PicEmployeeSignature.Image = Nothing : EmployeeSignature_Byte = Nothing
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
        TxtName.Enabled = False
        TxtSite_Code.Enabled = False
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

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) _
        Handles TxtName.Validating, TxtGroupCode.Validating, _
                 TxtAdd1.Validating, TxtAdd2.Validating, TxtAdd3.Validating, TxtManualCode.Validating, TxtDispName.Validating, _
                 TxtEMail.Validating, TxtPanNo.Validating, TxtMobile.Validating, TxtPhone.Validating

        Try
            Select Case sender.NAME
                Case TxtDispName.Name, TxtManualCode.Name
                    TxtName.Text = TxtDispName.Text + Space(1) + "{" + TxtManualCode.Text + "}"

                Case TxtGroupCode.Name
                    If Me.Controls("HelpDg") IsNot Nothing And CType(Me.Controls("HelpDg"), AgControls.AgDataGrid).CurrentCell IsNot Nothing Then
                        With CType(Me.Controls("HelpDg"), AgControls.AgDataGrid)
                            mGroupNature = Agl.XNull(.Item("GroupNature", .CurrentCell.RowIndex).Value)
                            mNature = Agl.XNull(.Item("Nature", .CurrentCell.RowIndex).Value)
                        End With
                    End If

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function Data_Validation() As Boolean
        Try
            If Agl.RequiredField(TxtManualCode, "Code") Then Exit Function
            If Agl.RequiredField(TxtDispName, "Display Name") Then Exit Function
            If AgL.RequiredField(TxtName, "Name") Then Exit Function
            If Agl.RequiredField(TxtGroupCode, "A/c Group") Then Exit Function
            If Agl.RequiredField(TxtAdd1, "Address") Then Exit Function
            If Agl.RequiredField(txtCity, "City") Then Exit Function

            If AgL.RequiredField(TxtDob, "Date of Birth") Then Exit Function

            If Not Agl.IsValid_EMailId(TxtEMail, "Email ID") Then Exit Function



            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where ManualCode='" & TxtManualCode.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Employee Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function

                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where DispName='" & TxtDispName.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then If MsgBox("Employee Display Name Already Exist!..." & vbCrLf & "Want to Continue!", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then TxtDispName.Focus() : Exit Function

                AgL.ECmd = AgL.Dman_Execute("Select count(*) From SubGroup Where Name='" & TxtName.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Employee Name Already Exist!") : TxtDispName.Focus() : Exit Function

            Else
                Agl.ECmd = Agl.Dman_Execute("Select count(*) From SubGroup Where ManualCode='" & TxtManualCode.Text & "' And SubCode<>'" & mSearchCode & "' ", Agl.GCn)
                If Agl.ECmd.ExecuteScalar() > 0 Then MsgBox("Employee Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function

                Agl.ECmd = Agl.Dman_Execute("Select count(*) From SubGroup Where DispName='" & TxtDispName.Text & "' And SubCode<>'" & mSearchCode & "' ", Agl.GCn)
                If Agl.ECmd.ExecuteScalar() > 0 Then If MsgBox("Employee Display Name Already Exist!..." & vbCrLf & "Want to Continue!", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then TxtDispName.Focus() : Exit Function

                Agl.ECmd = Agl.Dman_Execute("Select count(*) From SubGroup Where Name='" & TxtName.Text & "' And SubCode<>'" & mSearchCode & "' ", Agl.GCn)
                If Agl.ECmd.ExecuteScalar() > 0 Then MsgBox("Employee Name Already Exist!") : TxtDispName.Focus() : Exit Function
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub PictureBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicPhoto.DoubleClick, PicEmployeeSignature.DoubleClick
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Select Case sender.Name
            Case PicPhoto.Name
                AgL.GetPicture(sender, Photo_Byte)

            Case PicEmployeeSignature.Name
                Agl.GetPicture(sender, EmployeeSignature_Byte)
        End Select
    End Sub

    Sub Show_Picture(ByVal PicBox As PictureBox, ByVal B As Byte())
        Dim Mem As MemoryStream
        Dim Img As Image

        Mem = New MemoryStream(B)
        Img = Image.FromStream(Mem)
        PicBox.Image = Img
    End Sub
End Class
