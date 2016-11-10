Public Class FrmBuildingMaster
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AGL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Form_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        DTMaster = Nothing
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
        AGL.CheckQuote(e)
    End Sub

    Private Sub IniGrid()
    End Sub

    Private Sub FrmBuildingMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            AgL.WinSetting(Me, 400, 880, 0, 0)
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

        mQry = " Select HB.Code As SearchCode " & _
                " From Ht_Building HB" & _
                " Where " & AgL.PubSiteCondition("HB.Site_Code", AgL.PubSiteCode) & ""
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)

    End Sub

    Sub Ini_List()

        mQry = " Select Code  As Code, ManualCode As Name " & _
                " From Ht_Building " & _
                " Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " " & _
                " Order By ManualCode "
        TxtManualCode.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select Code  As Code, Description As Name " & _
                " From Ht_Building " & _
                " Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & " " & _
                " Order By Description"
        TxtDescription.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select Code As Code,ManualCode As [Hostel Name],Description " & _
                " From Ht_Hostel" & _
                " Where " & AgL.PubSiteCondition("Ht_Hostel.Site_Code", AgL.PubSiteCode) & "" & _
                " Order By ManualCode"
        TxtHostel.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        AgCL.IniAgHelpList(TxtNature, "Male,Female,Both")

    End Sub

    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")

                mQry = " SELECT HB.* " & _
                        " FROM Ht_Building HB " & _
                        " Where HB.Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)

                    If .Rows.Count > 0 Then

                        TxtManualCode.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                        TxtDescription.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                        TxtHostel.AgSelectedValue = AgL.XNull(.Rows(0)("Hostel"))
                        TxtNature.Text = AgL.XNull(.Rows(0)("Nature"))
                        TxtLocation.Text = AgL.XNull(.Rows(0)("Location"))
                        TxtContactPerson.Text = AgL.XNull(.Rows(0)("ContactPerson"))
                        TxtPhone.Text = AgL.XNull(.Rows(0)("Phone"))
                        TxtMobile.Text = AgL.XNull(.Rows(0)("Mobile"))
                        TxtFax.Text = AgL.XNull(.Rows(0)("Fax"))
                        TxtEMail.Text = AgL.XNull(.Rows(0)("Email"))


                    End If
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
    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbDiscard() Handles Topctrl1.tbDiscard
        FIniMaster(0, 0)
        Topctrl1.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        DispText(True)
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbRef() Handles Topctrl1.tbRef
        Ini_List()
    End Sub

    Private Sub BlankText()
        If Topctrl1.Mode <> "Add" Then Topctrl1.BlankTextBoxes(Me)
        mSearchCode = ""
    End Sub

    Private Sub DispText(Optional ByVal Enb As Boolean = False)
        'Coding To Enable/Disable Controls
    End Sub

    Private Sub FClear()
        DTStruct.Clear()
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

                    AgL.Dman_ExecuteNonQry(" Delete From Ht_Building Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)

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

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Try
            MastPos = BMBMaster.Position
            If Not Data_Validation() Then Exit Sub

            'If AgCL.AgCheckMandatory(Me) = False 

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then

                mQry = " INSERT INTO Ht_Building(Code, Description, ManualCode, Hostel, Nature, " & _
                        " Location, ContactPerson, Phone, Mobile, Fax, Email, " & _
                        " Div_Code, Site_Code, PreparedBy, U_EntDate, U_AE )" & _
                        " Values('" & mSearchCode & "', " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtManualCode.Text) & ", " & AgL.Chk_Text(TxtHostel.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtNature.AgSelectedValue) & ", " & AgL.Chk_Text(TxtLocation.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtContactPerson.Text) & ", " & AgL.Chk_Text(TxtPhone.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtMobile.Text) & ", " & AgL.Chk_Text(TxtFax.Text) & ", " & _
                        " " & AgL.Chk_Text(TxtEMail.Text) & ", '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "'," & _
                        " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', 'A') "

                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            Else
                mQry = " UPDATE dbo.Ht_Building SET " & _
                        " Description =  " & AgL.Chk_Text(TxtDescription.Text) & ",	" & _
                        " ManualCode =" & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
                        " Hostel =  " & AgL.Chk_Text(TxtHostel.AgSelectedValue) & ",	Nature = " & AgL.Chk_Text(TxtNature.Text) & ", " & _
                        " Location = " & AgL.Chk_Text(TxtLocation.Text) & ",ContactPerson = " & AgL.Chk_Text(TxtContactPerson.Text) & ", " & _
                        " Phone = " & AgL.Chk_Text(TxtPhone.Text) & ",	Mobile = " & AgL.Chk_Text(TxtMobile.Text) & ", " & _
                        " Fax = " & AgL.Chk_Text(TxtFax.Text) & ",	Email = " & AgL.Chk_Text(TxtEMail.Text) & ",U_AE = 'E', " & _
                        " Edit_Date = '" & Format(AgL.PubLoginDate, "Short Date") & "',ModifiedBy = '" & AgL.PubUserName & "' " & _
                        " Where Code='" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If




            Call AgL.LogTableEntry(mSearchCode, Me.Text, AgL.MidStr(Topctrl1.Mode, 0, 1), AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)


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

    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = " SELECT HB.Code AS SearchCode,Hb.ManualCode AS [Manual Code],Hb.Description,HH.Description AS [Hostel Name], " & _
                             " Hb.Nature ,hb.ContactPerson AS [Contact Person],HB.Phone,Hb.Mobile,hb.Fax,Hb.Email " & _
                             " FROM Ht_Building HB " & _
                             " LEFT JOIN Ht_Hostel HH ON HH.Code =Hb.Hostel  " & _
                             " Where " & AgL.PubSiteCondition("Hb.Site_Code", AgL.PubSiteCode) & ""

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

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
        Dim ds As New DataSet
        Dim strQry As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Building List"
            If Not DTMaster.Rows.Count > 0 Then
                MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                Me.Cursor = Cursors.Default
                Exit Sub
            End If


            strQry = " SELECT HB.ManualCode AS Building, HB.Description, HH.Description AS [Hostel Name], HB.Nature, HB.Location, HB.ContactPerson, HB.Phone, HB.Mobile, HB.Fax, HB.Email " & _
                     " FROM Ht_Building HB " & _
                     " LEFT JOIN Ht_Hostel HH ON HH.Code =Hb.Hostel  " & _
                     " Where " & AgL.PubSiteCondition("Hb.Site_Code", AgL.PubSiteCode) & ""

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(ds)
            Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            mPrnHnd.DataSetToPrint = ds
            mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            mPrnHnd.ReportTitle = "Building List"
            mPrnHnd.TableIndex = 0
            mPrnHnd.PageSetupDialog(True)
            mPrnHnd.PrintPreview()
            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Function Data_Validation() As Boolean
        Try

            If AgL.RequiredField(TxtManualCode, "Manual Code") Then Exit Function
            If AgL.RequiredField(TxtDescription, "Description") Then Exit Function
            If AgL.RequiredField(TxtHostel, "Hostel") Then Exit Function
            If AgL.RequiredField(TxtNature, "Nature") Then Exit Function
            If AgL.RequiredField(TxtContactPerson, "Contact Person") Then Exit Function
            If Not AgL.IsValid_EMailId(TxtEMail, "EMail ID") Then Exit Function


            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Ht_Building Where ManualCode='" & TxtManualCode.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Ht_Building Where Description='" & TxtDescription.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Function

                mSearchCode = AgL.GetMaxId("Ht_Building", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 6, True, True, , AgL.Gcn_ConnectionString)
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Ht_Building Where ManualCode='" & TxtManualCode.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Manual Code Already Exist!") : TxtManualCode.Focus() : Exit Function
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Ht_Building Where Description='" & TxtDescription.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Function
            End If

            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False

        End Try
    End Function

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs)
        Try
            Select Case sender.NAME

                Case TxtDescription.Name
                    If TxtDescription.Text.Trim = "" Then TxtDescription.Text = TxtManualCode.Text

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class