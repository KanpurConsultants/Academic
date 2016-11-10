Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCampusCompanyMaster
    Private DTMaster As New DataTable()
    Public BMBMaster As BindingManagerBase
    Private KEAMainKeyCode As System.Windows.Forms.KeyEventArgs
    Private DTStruct As New DataTable
    Dim mQry As String = "", mSearchCode As String = ""

    Public Const ColSNo As String = "S. No."

    Public WithEvents DGL1 As New AgControls.AgDataGrid

    Protected Const Col1Person As String = "Person"
    Protected Const Col1Designation As String = "Designation"
    Protected Const Col1Phone As String = "Phone"
    Protected Const Col1Mobile As String = "Mobile"
    Protected Const Col1Email As String = "E-Mail"
    Protected Const Col1HierarchyNo As String = "Hierarchy No"


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

    Private Sub IniGrid()
        With AgCL
            .AddAgTextColumn(DGL1, ColSNo, 30, 5, ColSNo, True, True, False)
            .AddAgTextColumn(DGL1, Col1Person, 170, 0, Col1Person, True, False, False)
            .AddAgTextColumn(DGL1, Col1Designation, 110, 0, Col1Designation, True, False, False)
            .AddAgTextColumn(DGL1, Col1Phone, 110, 0, Col1Phone, True, False, False)
            .AddAgTextColumn(DGL1, Col1Mobile, 110, 0, Col1Mobile, True, False, False)
            .AddAgTextColumn(DGL1, Col1Email, 170, 0, Col1Email, True, False, False)
            .AddAgNumberColumn(DGL1, Col1HierarchyNo, 70, 8, 0, False, Col1HierarchyNo, True, False, True)

        End With

        AgL.AddAgDataGrid(DGL1, Pnl1)
        DGL1.ColumnHeadersHeight = 40
        DGL1.AllowUserToAddRows = True

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
    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            AgL.WinSetting(Me, 514, 880, 0, 0)
            AgL.GridDesign(DGL1)
            IniGrid()
            Topctrl1.ChangeAgGridState(DGL1, False)
            FIniMaster()
            Ini_List()
            DispText()
            MoveRec()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub FIniMaster(Optional ByVal BytDel As Byte = 0, Optional ByVal BytRefresh As Byte = 1)
        mQry = "Select Campus_Company.Code As SearchCode " & _
                " From Campus_Company " & _
                " Where " & AgL.PubSiteCondition("Site_Code", AgL.PubSiteCode) & ""
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub


    Sub Ini_List()
        Try

            'mQry = "Select Distinct ManualCode As Code, ManualCode As Name From Campus_Company With (NoLock) " & _
            '        "where isnull(ManualCode,'')<>'' Order By ManualCode"
            'txtManualCode.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "Select Code  As Code, Description As Name From Campus_Company With (NoLock) " & _
                    " Order By Description"
            TxtDescription.AgHelpDataSet = AgL.FillData(mQry, AgL.GcnRead)

            mQry = "SELECT city.CityCode AS code,City.CityName AS Name,State.State_Desc AS State," & _
                     " Country.Name AS Country FROM City With (NoLock) " & _
                     " LEFT JOIN State With (NoLock) ON city.State_Code=State.State_Code " & _
                     " LEFT JOIN Country With (NoLock) ON State.CountryCode=Country.Code Order by  city.cityname "
            TxtCityCode.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GcnRead)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        BlankText()
        DispText(True)
        TxtDescription.Focus()
        DGL1.Rows.Clear()
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

                    AgL.Dman_ExecuteNonQry("Delete From Campus_Company Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)
                    AgL.Dman_ExecuteNonQry("Delete From Campus_Company1 Where Code='" & mSearchCode & "'", AgL.GCn, AgL.ECmd)


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
        TxtDescription.Focus()
    End Sub


    Private Sub Topctrl1_tbFind() Handles Topctrl1.tbFind
        'If DTMaster.Rows.Count <= 0 Then MsgBox("No Records To Search.", vbInformation, AgLibrary.ClsMain.PubMsgTitleInfo) : Exit Sub
        Try


            AgL.PubFindQry = "Select S.Code As SearchCode, S.ManualCode As [Manual Code],  S.Description As [Name], " & _
                                " S.Phone As [Phone],S.Mobile,S.Segment,S.Rank " & _
                                " From  Campus_Company S " & _
                                " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & ""

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
            'Me.Cursor = Cursors.WaitCursor
            'AgL.PubReportTitle = "Programme List"
            'If Not DTMaster.Rows.Count > 0 Then
            '    MsgBox("No Records Found to Print!!!", vbInformation, "Information")
            '    Me.Cursor = Cursors.Default
            '    Exit Sub
            'End If

            ''Code Change by Satyam on 11/03/2011
            'strQry = " Select S.ManualCode As [Manual Code],  S.Description As [Description], N.Description as [Programme Nature], S.ProgrammeDuration as [Programme Duration], S.Semesters, S.SemesterDuration As [Semester Duration] From  Campus_Company S Left Join Campus_CompanyNature N On S.ProgrammeNature = N.Code " & _
            '            " Where " & AgL.PubSiteCondition("S.Site_Code", AgL.PubSiteCode) & ""
            ''End Code Change by Satyam on 11/03/2011
            'AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            'AgL.ADMain.Fill(ds)
            'Dim mPrnHnd As New AgLibrary.PrintHandler(AgL)
            'mPrnHnd.DataSetToPrint = ds
            'mPrnHnd.LineThreshold = ds.Tables(0).Rows.Count - 1
            'mPrnHnd.NumberOfColumns = ds.Tables(0).Columns.Count - 1
            'mPrnHnd.ReportTitle = "Programme List"
            'mPrnHnd.TableIndex = 0
            'mPrnHnd.PageSetupDialog(True)
            'mPrnHnd.PrintPreview()
            'Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Topctrl1_tbSave() Handles Topctrl1.tbSave
        Dim MastPos As Long
        Dim mTrans As Boolean = False
        Dim I As Integer, Sr As Integer
        Try
            MastPos = BMBMaster.Position

            If AgCL.AgCheckMandatory(Me) = False Then Exit Sub


            If Topctrl1.Mode = "Add" Then
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Campus_Company with (NoLock) Where ManualCode='" & TxtManualCode.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Short Name Already Exist!") : TxtManualCode.Focus() : Exit Sub
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Campus_Company with (NoLock) Where Description='" & TxtDescription.Text & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Sub

                mSearchCode = AgL.GetMaxId("Campus_Company", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 6, True, True, , AgL.Gcn_ConnectionString)
            Else
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Campus_Company with (NoLock) Where ManualCode='" & TxtManualCode.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Short Name Already Exist!") : TxtManualCode.Focus() : Exit Sub
                AgL.ECmd = AgL.Dman_Execute("Select count(*) From Campus_Company with (NoLock) Where Description='" & TxtDescription.Text & "' And Code<>'" & mSearchCode & "' ", AgL.GCn)
                If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("Description Already Exist!") : TxtDescription.Focus() : Exit Sub
            End If



            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans
            mTrans = True


            If Topctrl1.Mode = "Add" Then
                mQry = "Insert Into Campus_Company (Code, ManualCode, Description, Add1, Add2, CityCode,PIN,Phone,Mobile,WebSite,Email,Segment,Rank, Div_Code, Site_Code, U_EntDt, PreparedBy, U_AE) Values('" & mSearchCode & "', " & AgL.Chk_Text(TxtManualCode.Text) & ", " & AgL.Chk_Text(TxtDescription.Text) & ", " & AgL.Chk_Text(TxtAdd1.Text) & ", " & AgL.Chk_Text(TxtAdd2.Text) & ", " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & ", " & AgL.Chk_Text(TxtPin.Text) & ", " & AgL.Chk_Text(TxtPhone.Text) & ", " & AgL.Chk_Text(TxtMobile.Text) & ", " & AgL.Chk_Text(TxtWebSite.Text) & ", " & AgL.Chk_Text(TxtEMail.Text) & ", " & AgL.Chk_Text(TxtSegment.Text) & ", " & Val(TxtRank.Text) & ",  '" & AgL.PubDivCode & "', '" & AgL.PubSiteCode & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', '" & AgL.PubUserName & "', 'A') "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            Else
                mQry = "Update Campus_Company Set ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & ", Description = " & AgL.Chk_Text(TxtDescription.Text) & ", Add1 = " & AgL.Chk_Text(TxtAdd1.Text) & ", Add2 = " & AgL.Chk_Text(TxtAdd2.Text) & ", CityCode = " & AgL.Chk_Text(TxtCityCode.AgSelectedValue) & ", PIN = " & AgL.Chk_Text(TxtPin.Text) & ", Phone = " & AgL.Chk_Text(TxtPhone.Text) & ", Mobile = " & AgL.Chk_Text(TxtMobile.Text) & ", WebSite = " & AgL.Chk_Text(TxtWebSite.Text) & ", Email = " & AgL.Chk_Text(TxtEMail.Text) & ", Segment = " & AgL.Chk_Text(TxtSegment.Text) & ", Rank = " & AgL.VNull(TxtRank.Text) & ", Edit_Date='" & Format(AgL.PubLoginDate, "Short Date") & "', ModifiedBy = '" & AgL.PubUserName & "' , U_AE = 'E' Where Code='" & mSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If Topctrl1.Mode = "Edit" Then
                mQry = "Delete From Campus_Company1 Where code = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            Sr = 1
            With DGL1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Person, I).Value <> "" Then
                        mQry = "INSERT INTO Campus_Company1 ( Code, Sr, Person, Designation, Phone, Mobile, Email, Hierarchy) " & _
                                " VALUES ( " & _
                                " '" & mSearchCode & "', " & Sr & ", " & AgL.Chk_Text(.Item(Col1Person, I).Value) & ",  " & _
                                " " & AgL.Chk_Text(.Item(Col1Designation, I).Value) & ", " & _
                                " " & AgL.Chk_Text(.Item(Col1Phone, I).Value) & ", " & AgL.Chk_Text(.Item(Col1Mobile, I).Value) & ", " & _
                                  " " & AgL.Chk_Text(.Item(Col1Email, I).Value) & "," & _
                                " " & Val(.Item(Col1HierarchyNo, I).Value) & ")"

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                        Sr = Sr + 1
                    End If
                Next I
            End With



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
    Public Sub MoveRec()
        Dim DsTemp As DataSet = Nothing
        Dim MastPos As Long
        Dim I As Integer

        Try
            FClear()
            BlankText()
            If DTMaster.Rows.Count > 0 Then
                MastPos = BMBMaster.Position
                mSearchCode = DTMaster.Rows(MastPos)("SearchCode")
                mQry = "Select Campus_Company.* " & _
                    " From Campus_Company Where Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then

                        TxtDescription.AgSelectedValue = AgL.XNull(.Rows(0)("Code"))
                        TxtManualCode.Text = AgL.XNull(.Rows(0)("ManualCode"))
                        TxtAdd1.Text = AgL.XNull(.Rows(0)("Add1"))
                        TxtAdd2.Text = AgL.XNull(.Rows(0)("Add2"))
                        TxtCityCode.AgSelectedValue = AgL.XNull(.Rows(0)("CityCode"))
                        TxtPin.Text = AgL.XNull(.Rows(0)("PIN"))
                        TxtPhone.Text = AgL.XNull(.Rows(0)("Phone"))
                        TxtMobile.Text = AgL.XNull(.Rows(0)("Mobile"))
                        TxtWebSite.Text = AgL.XNull(.Rows(0)("WebSite"))
                        TxtEMail.Text = AgL.XNull(.Rows(0)("Email"))
                        TxtSegment.Text = AgL.XNull(.Rows(0)("Segment"))
                        TxtRank.Text = AgL.XNull(.Rows(0)("Rank"))


                    End If
                End With

                mQry = "Select * From Campus_Company1 Where Code='" & mSearchCode & "'"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    DGL1.RowCount = 1
                    DGL1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            DGL1.Rows.Add()
                            DGL1.Item(ColSNo, I).Value = DGL1.Rows.Count - 1
                            DGL1.Item(Col1Person, I).Value = AgL.XNull(.Rows(I)("Person"))
                            DGL1.Item(Col1Designation, I).Value = AgL.XNull(.Rows(I)("Designation"))
                            DGL1.Item(Col1Phone, I).Value = AgL.XNull(.Rows(I)("Phone"))
                            DGL1.Item(Col1Mobile, I).Value = AgL.XNull(.Rows(I)("Mobile"))
                            DGL1.Item(Col1Email, I).Value = AgL.XNull(.Rows(I)("Email"))
                            DGL1.Item(Col1HierarchyNo, I).Value = AgL.VNull(.Rows(I)("Hierarchy"))
                          
                        Next I
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
    Private Sub FAddRowStructure()
        Dim DRStruct As DataRow
        Try
            DRStruct = DTStruct.NewRow
            DTStruct.Rows.Add(DRStruct)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
        TxtDescription.Validating, TxtAdd1.Validating, TxtAdd2.Validating, TxtCityCode.Validating, TxtEMail.Validating, TxtMobile.Validating, TxtPhone.Validating, TxtPin.Validating, TxtRank.Validating, TxtSegment.Validating, TxtWebSite.Validating, txtManualCode.Validating
        Try
            Select Case sender.NAME
                'Case TxtDescription.Name
                '    If TxtDescription.Text.Trim = "" Then TxtDescription.Text = TxtManualCode.Text

            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGL1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub
    Private Sub DGL1_RowsRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DGL1.RowsRemoved
        AgL.FSetSNo(sender, 0)
    End Sub

End Class
