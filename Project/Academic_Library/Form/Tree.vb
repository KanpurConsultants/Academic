Imports System.Windows.Forms

Public Class Tree
    Public StrCurrentModule As String


    '    Dim Cls_Rug_main As New RUG_Main.ClsMain(AgL)
    '    Dim Cls_Rug_Utility As New RUG_Utility.ClsMain(AgL)
    '    Dim Cls_AgTemplate As New AgTemplate.ClsMain(AgL)
    '    Dim Cls_AgStructure As New AgStructure.ClsMain(AgL)

    '    Dim ClsMF As New AgLibrary.ClsMDIFunctions(AgL)


    '    Public Sub FMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '        Dim FrmObj As Form = Nothing
    '        Dim StrType As String = ""

    '        If FMenuItem_Windows(sender) Then Exit Sub

    '        If sender.tag Is Nothing Then
    '            StrType = ""
    '        Else
    '            StrType = sender.tag
    '        End If

    '        If sender.ToolTipText IsNot Nothing Then
    '            StrCurrentModule = sender.ToolTipText
    '        End If

    '        Select Case Trim(UCase(StrCurrentModule))


    '            Case Trim(UCase(RUG_Main.ClsMain.ModuleName))
    '                If StrType.Trim = "" Then
    '                    FrmObj = Cls_Rug_main.CFOpen.FOpen(sender.NAME, sender.TEXT, True)
    '                ElseIf Not AgL.StrCmp(StrType.Trim, "CWDS") Then
    '                    FrmObj = Cls_Rug_main.CFOpen.FOpen(sender.NAME, sender.TEXT, False)
    '                End If

    '            Case Trim(UCase(RUG_Utility.ClsMain.ModuleName))
    '                If StrType.Trim = "" Then
    '                    FrmObj = Cls_Rug_Utility.CFOpen.FOpen(sender.NAME, sender.TEXT, True)
    '                ElseIf Not AgL.StrCmp(StrType.Trim, "CWDS") Then
    '                    FrmObj = Cls_Rug_Utility.CFOpen.FOpen(sender.NAME, sender.TEXT, False)
    '                End If


    '            Case Else
    '                FrmObj = Nothing
    '        End Select
    '        If IsNothing(FrmObj) Then Exit Sub
    '        FrmObj.MdiParent = Me
    '        AgL.PubSearchRow = ""
    '        FrmObj.Show()
    '        FrmObj = Nothing

    '    End Sub

    '    Sub FOpenMenuClicked(ByVal ModuleName As String, ByVal MnuName As String, ByVal MnuText As String, ByVal MnuType As String)
    '        Dim FrmObj As Form = Nothing
    '        Select Case Trim(UCase(ModuleName))


    '            Case Trim(UCase(RUG_Main.ClsMain.ModuleName))
    '                If MnuType.Trim = "" Then
    '                    FrmObj = Cls_Rug_main.CFOpen.FOpen(MnuName, MnuText, True)
    '                ElseIf Not AgL.StrCmp(MnuType.Trim, "CWDS") Then
    '                    FrmObj = Cls_Rug_main.CFOpen.FOpen(MnuName, MnuText, False)
    '                End If

    '            Case Trim(UCase(RUG_Utility.ClsMain.ModuleName))
    '                If MnuType.Trim = "" Then
    '                    FrmObj = Cls_Rug_Utility.CFOpen.FOpen(MnuName, MnuText, True)
    '                ElseIf Not AgL.StrCmp(MnuType.Trim, "CWDS") Then
    '                    FrmObj = Cls_Rug_Utility.CFOpen.FOpen(MnuName, MnuText, False)
    '                End If


    '            Case Else
    '                FrmObj = Nothing
    '        End Select
    '        If IsNothing(FrmObj) Then Exit Sub
    '        FrmObj.MdiParent = Me
    '        AgL.PubSearchRow = ""
    '        TbcMain.Width = 25
    '        FrmObj.Show()
    '        FrmObj = Nothing

    '    End Sub


    '    Public Function FMenuItem_Windows(ByVal Sender) As Boolean
    '        Dim BlnFlagRtn As Boolean = False

    '        If UCase(Trim(Sender.Tag)) = "CWDS" Then
    '            Select Case UCase(Trim(Sender.Text))
    '                Case UCase(Trim("Cascade"))
    '                    Me.LayoutMdi(MdiLayout.Cascade)
    '                    BlnFlagRtn = True
    '                Case UCase(Trim("Tile Horizontal"))
    '                    Me.LayoutMdi(MdiLayout.TileHorizontal)
    '                    BlnFlagRtn = True
    '                Case UCase(Trim("Tile Vertical"))
    '                    Me.LayoutMdi(MdiLayout.TileVertical)
    '                    BlnFlagRtn = True
    '                Case UCase(Trim("Close All"))
    '                    For Each ChildForm As Form In Me.MdiChildren
    '                        ChildForm.Close()
    '                    Next
    '                    BlnFlagRtn = True
    '                Case UCase(Trim("Exit"))
    '                    Me.Dispose()
    '            End Select
    '        End If
    '        Return BlnFlagRtn
    '    End Function






    '    Private Sub FManageMDI()
    '        Dim GCnCmd As New SqlClient.SqlCommand

    '        If Not (AgL.StrCmp("SA", AgL.PubUserName) Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then MsgBox("Permission Denied!...") : Exit Sub

    '        If MsgBox("Are You To Run Manage MDI Tool?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = MsgBoxResult.No Then Exit Sub

    '        GCnCmd.Connection = AgL.ECompConn
    '        GCnCmd.CommandText = "Delete From User_Permission Where UserName='SA'"
    '        GCnCmd.ExecuteNonQuery()


    '        ClsMF.FGenerate_UP(New RUG_Main.MDIMain, RUG_Main.ClsMain.ModuleName, 0, RUG_Main.ClsMain.ModuleName, GCnCmd)
    '        ClsMF.FGenerate_UP(New RUG_Utility.MDIMain, RUG_Utility.ClsMain.ModuleName, 0, RUG_Utility.ClsMain.ModuleName, GCnCmd)

    '        ClsMF.FUpdateUserGroupLevels(AgL.GCn, GCnCmd)
    '        ClsMF.FManageEntryPointPermission(AgL.GCn, GCnCmd)


    '        MsgBox("Process Completed." & vbCrLf & "Please Reload the Software!...", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo) : End
    '    End Sub

    '    Private Sub FManageUserControl()
    '        Dim GCnCmd As New SqlClient.SqlCommand

    '        If Not (AgL.StrCmp("SA", AgL.PubUserName) Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then MsgBox("Permission Denied!...") : Exit Sub

    '        If MsgBox("Are You To Run Manage User Control Tool?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = MsgBoxResult.No Then Exit Sub

    '        GCnCmd.Connection = AgL.ECompConn
    '        GCnCmd.CommandText = "Delete From User_Control_Permission Where UserName='SA'"
    '        GCnCmd.ExecuteNonQuery()


    '        ClsMF.FGenerate_UP_Control(Cls_Rug_main, RUG_Main.ClsMain.ModuleName, GCnCmd)
    '        ClsMF.FGenerate_UP_Control(Cls_Rug_Utility, RUG_Utility.ClsMain.ModuleName, GCnCmd)

    '        MsgBox("Process Completed.", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
    '    End Sub

    '    Private Sub MDIMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
    '        Do Until TbcMain.Width <= 25
    '            TbcMain.Width = TbcMain.Width - 40
    '        Loop
    '        TbcMain.Width = 25
    '    End Sub

    '    Private Sub MDIMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
    '        FrmDivisionSelection.Dispose()
    '        FrmLogin.Dispose()
    '        End
    '    End Sub

    '    Private Sub MDIMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '        Dim mQry$ = ""
    '        Try
    '            TbcMain.Width = 25
    '            TSSL_User.Text = "User : " & AgL.PubUserName
    '            TSSL_Company.Text = AgL.PubCompName
    '            TSSL_Site.Text = "Site/Branch : " & AgL.PubSiteName
    '            TSSL_OnlineOffLine.Text = IIf(AgL.PubOfflineApplicable, " [Online]", " [Offline]")

    '            mQry = "SELECT D.Div_Name FROM Division D WHERE D.Div_Code = '" & AgL.PubDivCode & "' "
    '            TSSL_Division.Text = "Division : " & AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar

    '            AgL.AllowTableLog(True, AgL.GCn)
    '            AgL.PubIsLogInProjectActive = False
    '            If AgL.PubOfflineApplicable Then AgL.AllowTableLog(True, AgL.GcnSite)

    '            Call UpdateTableStructure()

    '            AgL.ECmd = AgL.GCn.CreateCommand
    '            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
    '            AgL.ECmd.Transaction = AgL.ETrans

    '            AgL.SynchroniseSiteOffineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

    '            AgL.ETrans.Commit()

    '            AgL.ECmd = AgL.GCn.CreateCommand
    '            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
    '            AgL.ECmd.Transaction = AgL.ETrans

    '            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

    '            AgL.ETrans.Commit()


    '            AgL.AllowTableLog(True, AgL.GCn)
    '            If AgL.PubOfflineApplicable Then AgL.AllowTableLog(True, AgL.GcnSite)

    '            Me.Text = Me.Text
    '        Catch ex As Exception
    '            MsgBox(ex.Message & "   Can't Load Software")
    '            End
    '        End Try

    '    End Sub



    '    Private Sub MDIMain_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
    '        If IsNothing(ActiveMdiChild) Then Exit Sub
    '        If UCase(ActiveMdiChild.Name) <> UCase("RepView") Then
    '            Me.ActiveMdiChild.WindowState = FormWindowState.Normal
    '        End If
    '    End Sub


    '    Private Sub TSSL_Btn_ManageMDI_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    '    Handles TSSL_Btn_ManageMDI.Click, TSSL_Btn_ManageUserControl.Click, TSSL_Btn_UpdateTableStructure.Click, TSSL_UpdateTableStructureWebToolStripMenuItem.Click

    '        Select Case sender.Name
    '            Case TSSL_Btn_ManageMDI.Name
    '                FManageMDI()

    '            Case TSSL_Btn_ManageUserControl.Name
    '                FManageUserControl()

    '            Case TSSL_Btn_UpdateTableStructure.Name
    '                If Not (AgL.StrCmp("SA", AgL.PubUserName) Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then MsgBox("Permission Denied!...") : Exit Sub

    '                If MsgBox("Are You Sure to Update Table Structure?...", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub

    '                MsgBox("Please Take Database Backup", MsgBoxStyle.Information)
    '                Dim FrmObj As Form
    '                FrmObj = New AgLibrary.FrmBackupDatase(AgL)
    '                FrmObj.ShowDialog()

    '                'AgL.PubMdlTable(0) = New AgLibrary.ClsMain.LITable
    '                Cls_AgStructure.UpdateTableStructure(AgL.PubMdlTable)
    '                Cls_AgTemplate.UpdateTableStructure(AgL.PubMdlTable)
    '                Cls_Rug_main.UpdateTableStructure(AgL.PubMdlTable)
    '                Cls_Rug_Utility.UpdateTableStructure(AgL.PubMdlTable)

    '                AgL.FExecuteDBScript(AgL.PubMdlTable, AgL.GCn)

    '                Cls_AgTemplate.UpdateTableInitialiser()
    '                Cls_Rug_main.UpdateTableInitialiser()
    '                Cls_Rug_Utility.UpdateTableInitialiser()
    '                Cls_AgStructure.UpdateTableInitialiser()

    '                MsgBox("Please Reload the Software!...") : End

    '            Case TSSL_UpdateTableStructureWebToolStripMenuItem.Name
    '                If Not (AgL.StrCmp("SA", AgL.PubUserName) Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then MsgBox("Permission Denied!...") : Exit Sub
    '                If MsgBox("Is Machine : " & AgL.PubMachineName & " Connected to Internet?...", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub
    '                'Cls_SID.UpdateTableStructureWeb()

    '                MsgBox("Update Table Structure Web Completed!")
    '        End Select
    '    End Sub

    '    Private Sub ReconnectDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSL_Btn_ReconnectDatabase.Click
    '        If Not FOpenIni(StrPath + "\" + IniName, AgL.PubUserName, AgL.PubUserPassword) Then
    '            MsgBox("Can't Connect to Database")
    '        Else
    '            AgIniVar.FOpenConnection(AgL.PubCompCode, AgL.PubSiteCode)
    '            AgIniVar.ProcSwapSiteCompanyDetail()
    '        End If
    '    End Sub

    '#Region "Update Table Structure"
    '    Sub UpdateTableStructure()
    '        Call AddNewTable()

    '        Call AddNewField()

    '        Call DeleteField()

    '        Call EditField()

    '        Call CreateVType()

    '        Call CreateView()
    '    End Sub

    '    Sub AddNewField()
    '        Dim mQry$ = ""
    '        Try
    '            ''============================< Table Name >====================================================
    '            '<Executable Code>
    '            ''============================< ************************* >=====================================
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Sub DeleteField()
    '        Try
    '            '<Executable Code>
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Sub EditField()
    '        Try
    '            '<Executable Code>
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try

    '    End Sub

    '    Sub AddNewTable()
    '        Dim mQry As String = ""
    '        Try
    '            '<Executable Code>
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub CreateVType()
    '        Try
    '            '<Executable Code>
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub

    '    Private Sub CreateView()
    '        Dim mQry$ = ""
    '        '' Note Write Each View in Separate <Try---Catch> Section
    '        Try
    '            'mQry = "CREATE VIEW dbo.Library_Member As " & _
    '            '        " SELECT Lm.*, Sg.Name AS Member_Name, Sg.DispName AS MemberDispName, Sg.ManualCode MemberManualCode, Sg.FatherName AS Father_Name, " & _
    '            '        " CASE Lm.Member_Type WHEN  'Student' THEN Lm.Member_Code ELSE NULL END AS Student, " & _
    '            '        " CASE Lm.Member_Type WHEN  'Employee' THEN Lm.Member_Code ELSE NULL END AS Employee, " & _
    '            '        " Sg.Div_Code, Sg.Site_Code, Sg.CommonAc " & _
    '            '        " FROM VbLib_Library_Member Lm " & _
    '            '        " LEFT JOIN SubGroup Sg ON Sg.SubCode = Lm.Member_Code "

    '            'AgL.IsViewExist("Library_Member", AgL.GCn, True)
    '            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

    '            'If AgL.PubOfflineApplicable Then
    '            '    AgL.IsViewExist("Library_Member", AgL.GcnSite, True)
    '            '    AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
    '            'End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub
    '#End Region

    '    Private Sub TspMenu_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)

    '    End Sub


    '    Private Sub AgSideBar1_Click(ByVal sender As Object, ByVal e As AgControls.OutlookStyleControls.AgSideBar.ButtonClickEventArgs) Handles AgSideBar1.Click
    '        Dim mButtonIndex As Integer
    '        TreeView1.Nodes.Clear()
    '        mButtonIndex = AgSideBar1.Buttons.IndexOf(e.SelectedButton)
    '        TreeView1.Tag = MdlFunction.ArrButtonModuleName(mButtonIndex)
    '        Fill_PermissionTree(TreeView1.Tag, AgSideBar1.Buttons(mButtonIndex).Tag)
    '    End Sub

    '    Public Sub Fill_PermissionTree(ByVal ModuleName As String, ByVal MSCode As String, Optional ByVal TNode As TreeNode = Nothing)
    '        Dim DtTemp As DataTable
    '        Dim I As Integer
    '        DtTemp = MdlFunction.DtMenu.Copy
    '        Dim mTNode As New TreeNode


    '        DtTemp.DefaultView.RowFilter = " mnuModule = '" & ModuleName & "' And substring(MainStreamCode,1," & Len(MSCode) & ")='" & MSCode & "' and Len(MainStreamCode)=" & Len(MSCode) + 3 & " "
    '        For I = 0 To DtTemp.DefaultView.Count - 1
    '            If TNode Is Nothing Then
    '                TreeView1.Nodes.Add(DtTemp.DefaultView.Item(I)("MnuText"))
    '                TreeView1.Nodes(TreeView1.Nodes.Count - 1).Name = DtTemp.DefaultView.Item(I)("MnuName")
    '                TreeView1.Nodes(TreeView1.Nodes.Count - 1).Tag = DtTemp.DefaultView.Item(I)("ReportFor")
    '                TreeView1.Nodes(TreeView1.Nodes.Count - 1).ImageIndex = 0

    '            Else
    '                TNode.Nodes.Add(DtTemp.DefaultView.Item(I)("MnuText"))
    '                TNode.Nodes(TNode.Nodes.Count - 1).Name = DtTemp.DefaultView.Item(I)("MnuName")
    '                TNode.Nodes(TNode.Nodes.Count - 1).Tag = DtTemp.DefaultView.Item(I)("ReportFor")

    '            End If
    '            mTNode = TreeView1.Nodes(TreeView1.Nodes.Count - 1)

    '            Fill_PermissionTree(ModuleName, DtTemp.DefaultView.Item(I)("MainStreamCode"), mTNode)
    '        Next
    '    End Sub

    '    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect
    '        Try
    '            If sender.SelectedNode IsNot Nothing Then
    '                FOpenMenuClicked(sender.tag, sender.SelectedNode.name, sender.SelectedNode.text, AgL.XNull(sender.SelectedNode.tag))

    '            End If
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '        End Try
    '    End Sub



    '    Private Sub MDIMain_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    '        'If e.Location.X < splitter1.Location.X Then
    '        '    Do Until TbcMain.Width >= 300
    '        '        TbcMain.Width = TbcMain.Width + 20
    '        '    Loop
    '        'Else
    '        '    Do Until TbcMain.Width <= 25
    '        '        TbcMain.Width = TbcMain.Width - 40
    '        '    Loop
    '        '    TbcMain.Width = 25
    '        'End If
    '    End Sub



    '    Private Sub TbcMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TbcMain.Click
    '        If TbcMain.Width <= 25 Then
    '            Do Until TbcMain.Width >= 250
    '                TbcMain.Width = TbcMain.Width + 20
    '            Loop
    '        Else
    '            Do Until TbcMain.Width <= 25
    '                TbcMain.Width = TbcMain.Width - 60

    '            Loop
    '            TbcMain.Width = 25
    '        End If
    '    End Sub

End Class
