Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System

Public Class MDIMain
    Public StrCurrentModule As String

    Dim Cls_ComnMast As New Common_Master.ClsMain(AgL)
    Dim Cls_Utility As New Utility.ClsMain(AgL)
    Dim Cls_Fa As New AgAccounts.ClsMain(AgL)

    Dim Cls_SMS As New SMS.ClsMain(AgL)
    Dim Cls_EMail As New EMail.ClsMain(AgL)

    Dim Cls_Scholar_Common As New Scholar_Common.ClsMain(AgL, PLib)
    Dim Cls_Academic_UtilityMain As New Academic_UtilityMain.ClsMain(AgL)

    '========================================================================
    '=============< Library Module >=========================================
    '========================================================================
    Dim Cls_AgTemplate As New AgTemplate.ClsMain(AgL)
    Dim Cls_AgStructure As New AgStructure.ClsMain(AgL)
    Dim Cls_AgCustomFields As New AgCustomFields.ClsMain(AgL)

    Dim Cls_Academic_Library As New Academic_Library.ClsMain(AgL)
    Dim Cls_Academic_Utility As New Academic_Utility.ClsMain(AgL)
    '========================================================================

    Dim ClsMF As New AgLibrary.ClsMDIFunctions(AgL)

    Dim Photo_Byte As Byte()
    Dim mQry$ = ""

    Public Sub FMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim FrmObj As Form = Nothing
        Dim StrType As String = ""

        If FMenuItem_Windows(sender) Then Exit Sub
        TbcMain.Width = 23

        If sender.tag Is Nothing Then
            StrType = ""
        Else
            StrType = sender.tag
        End If

        If sender.ToolTipText IsNot Nothing Then
            StrCurrentModule = sender.ToolTipText
        End If

        Select Case Trim(UCase(StrCurrentModule))
            Case Trim(UCase(mCommon_Master))
                If StrType.Trim = "" Then
                    FrmObj = Cls_ComnMast.CFOpen.FOpen(sender.NAME, sender.TEXT, True)
                ElseIf Not AgL.StrCmp(StrType.Trim, "CWDS") Then
                    FrmObj = Cls_ComnMast.CFOpen.FOpen(sender.NAME, sender.TEXT, False)
                End If

            Case Trim(UCase(mFinancial_Accounts))
                Dim objAccountsClsFunction As New AgAccounts.ClsFunction
                FrmObj = objAccountsClsFunction.FOpen(sender.NAME, sender.TEXT)


                'Case Trim(UCase(mUtility))
                '    If StrType.Trim = "" Then
                '        FrmObj = Cls_Utility.CFOpen.FOpen(sender.NAME, sender.TEXT, True)
                '    ElseIf Not AgL.StrCmp(StrType.Trim, "CWDS") Then
                '        FrmObj = Cls_Utility.CFOpen.FOpen(sender.NAME, sender.TEXT, False)
                '    End If

            Case Trim(UCase(Academic_UtilityMain.ClsMain.ModuleName))
                If StrType.Trim = "" Then
                    FrmObj = Cls_Academic_UtilityMain.CFOpen.FOpen(sender.NAME, sender.TEXT, True)
                ElseIf Not AgL.StrCmp(StrType.Trim, "CWDS") Then
                    FrmObj = Cls_Academic_UtilityMain.CFOpen.FOpen(sender.NAME, sender.TEXT, False)
                End If

            Case Trim(UCase(Scholar_Common.ClsMain.ModuleName))
                If StrType.Trim = "" Then
                    FrmObj = Cls_Scholar_Common.CFOpen.FOpen(sender.NAME, sender.TEXT, True)
                ElseIf Not AgL.StrCmp(StrType.Trim, "CWDS") Then
                    FrmObj = Cls_Scholar_Common.CFOpen.FOpen(sender.NAME, sender.TEXT, False)
                End If

            Case Trim(UCase(Academic_Library.ClsMain.ModuleName))
                If StrType.Trim = "" Then
                    FrmObj = Cls_Academic_Library.CFOpen.FOpen(sender.NAME, sender.TEXT, True)
                ElseIf Not AgL.StrCmp(StrType.Trim, "CWDS") Then
                    FrmObj = Cls_Academic_Library.CFOpen.FOpen(sender.NAME, sender.TEXT, False)
                End If

            Case Else
                FrmObj = Nothing
        End Select
        If IsNothing(FrmObj) Then Exit Sub
        FrmObj.MdiParent = Me
        AgL.PubSearchRow = ""
        FrmObj.Show()
        FrmObj = Nothing
    End Sub

    Public Function FMenuItem_Windows(ByVal Sender) As Boolean
        Dim BlnFlagRtn As Boolean = False

        If UCase(Trim(Sender.Tag)) = "CWDS" Then
            Select Case UCase(Trim(Sender.Text))
                Case UCase(Trim("Cascade"))
                    Me.LayoutMdi(MdiLayout.Cascade)
                    BlnFlagRtn = True
                Case UCase(Trim("Tile Horizontal"))
                    Me.LayoutMdi(MdiLayout.TileHorizontal)
                    BlnFlagRtn = True
                Case UCase(Trim("Tile Vertical"))
                    Me.LayoutMdi(MdiLayout.TileVertical)
                    BlnFlagRtn = True
                Case UCase(Trim("Close All"))
                    For Each ChildForm As Form In Me.MdiChildren
                        ChildForm.Close()
                    Next
                    BlnFlagRtn = True
                Case UCase(Trim("Exit"))
                    Me.Dispose()
            End Select
        End If
        Return BlnFlagRtn
    End Function

    Private Sub TsbMasters_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
        TsbFA.Click, TsbUtility.Click, TsbComnMast.Click

        Try
            Select Case sender.name
                Case TsbFA.Name
                    FAddMenu(Me, "FA")
                    StrCurrentModule = mFinancial_Accounts

                Case TsbUtility.Name
                    FAddMenu(Me, mUtility)
                    StrCurrentModule = mUtility

                Case TsbComnMast.Name
                    FAddMenu(Me, mCommon_Master)
                    StrCurrentModule = mCommon_Master
            End Select

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        End Try
    End Sub

    Private Sub TbcMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TbcMain.Click
        If TbcMain.Width = 23 Then
            TbcMain.Width = 285
        Else
            TbcMain.Width = 23
        End If
    End Sub

    Private Sub FManageMDI()
        Dim GCnCmd As New SqlClient.SqlCommand

        If Not (AgL.StrCmp("SA", AgL.PubUserName) Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then MsgBox("Permission Denied!...") : Exit Sub

        If MsgBox("Are You To Run Manage MDI Tool?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = MsgBoxResult.No Then Exit Sub

        GCnCmd.Connection = AgL.ECompConn
        GCnCmd.CommandText = "Delete From User_Permission Where UserName='SA'"
        GCnCmd.ExecuteNonQuery()

        If Academic_ProjLib.ClsMain.IsModuleActive_FinancialAccount Then ClsMF.FGenerate_UP(New AgAccounts.MDIMain1, "FA", 0, "FA", GCnCmd)
        'If Academic_ProjLib.ClsMain.IsModuleActive_CommonMaster Then ClsMF.FGenerate_UP(New Common_Master.MDIMain, mCommon_Master, 0, mCommon_Master, GCnCmd)

        Call ClsMF.FGenerate_UP(New Scholar_Common.MDIMain, Scholar_Common.ClsMain.ModuleName, 0, Scholar_Common.ClsMain.ModuleName, GCnCmd)

        If Academic_ProjLib.ClsMain.IsModuleActive_Library Then ClsMF.FGenerate_UP(New Academic_Library.MDIMain, Academic_Library.ClsMain.ModuleName, 0, Academic_Library.ClsMain.ModuleName, GCnCmd)
        If Academic_ProjLib.ClsMain.IsModuleActive_Utility Then ClsMF.FGenerate_UP(New Academic_UtilityMain.MDIMain, Academic_UtilityMain.ClsMain.ModuleName, 0, Academic_UtilityMain.ClsMain.ModuleName, GCnCmd)

        If AgLibrary.ClsConstant.IsSmsActive _
            Or AgLibrary.ClsConstant.IsEMailActive Then


        End If

        ClsMF.FUpdateUserGroupLevels(AgL.GCn, GCnCmd)

        ClsMF.FManageEntryPointPermission(AgL.GCn, GCnCmd)

        '==================================================================================================================================================================================================
        '==========< Update In-Active Menu In User_Permission Table >======================================================================================================================================
        '==================================================================================================================================================================================================
        ProcUpdateInActiveMenu()
        '==================================================================================================================================================================================================

        MsgBox("Process Completed." & vbCrLf & "Please Reload the Software!...", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo) : End
    End Sub

    Private Sub FManageUserControl()
        Dim GCnCmd As New SqlClient.SqlCommand
        Try
            If Not (AgL.StrCmp("SA", AgL.PubUserName) Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then MsgBox("Permission Denied!...") : Exit Sub

            If MsgBox("Are You To Run Manage User Control Tool?", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, AgLibrary.ClsMain.PubMsgTitleInfo) = MsgBoxResult.No Then Exit Sub

            AgLibrary.ClsConstant.BlnManageUserControl = True

            GCnCmd.Connection = AgL.ECompConn
            GCnCmd.CommandText = "Delete From User_Control_Permission Where UserName='SA'"
            GCnCmd.ExecuteNonQuery()

            If Academic_ProjLib.ClsMain.IsModuleActive_FinancialAccount Then ClsMF.FGenerate_UP_Control(Cls_Fa, mFinancial_Accounts, GCnCmd)
            'If Academic_ProjLib.ClsMain.IsModuleActive_Utility Then ClsMF.FGenerate_UP_Control(Cls_Utility, mUtility, GCnCmd)
            If Academic_ProjLib.ClsMain.IsModuleActive_Utility Then ClsMF.FGenerate_UP_Control(Cls_Academic_UtilityMain, Academic_UtilityMain.ClsMain.ModuleName, GCnCmd)

            If AgLibrary.ClsConstant.IsSmsActive Or AgLibrary.ClsConstant.IsEMailActive Then
            End If

            Call ClsMF.FGenerate_UP_Control(Cls_Scholar_Common, Scholar_Common.ClsMain.ModuleName, GCnCmd)
            If Academic_ProjLib.ClsMain.IsModuleActive_Library Then ClsMF.FGenerate_UP_Control(Cls_Academic_Library, Academic_Library.ClsMain.ModuleName, GCnCmd)

            MsgBox("Process Completed." & vbCrLf & "Please Reload the Software!...", MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo) : End
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            AgLibrary.ClsConstant.BlnManageUserControl = False
        End Try
    End Sub

    Private Sub MDIMain_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        FrmDivisionSelection.Dispose()
        FrmLogin.Dispose()
        End
    End Sub

    Private Sub MDIMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim StrUserPermission$ = ""
        Dim DTUP As DataTable = Nothing
        Dim FrmObj As Form = Nothing
        Dim bDtTemp As DataTable = Nothing

        Try
            AgL.PubMdiParent = Me

            TbcMain.Width = 23

            TSSL_User.Text = "User : " & AgL.PubUserName : TSSL_User.AutoSize = True
            TSSL_Company.Text = AgL.PubRegOfficeName
            TSSL_Site.Text = "Site/Branch : " & AgL.PubSiteName
            TSSL_OnlineOffLine.Text = IIf(AgL.PubOfflineApplicable, " [Online]", " [Offline]")
            TSSL_CurrentYear.Text = CDate(AgL.PubStartDate).Year.ToString + "-" + CDate(AgL.PubEndDate).Year.ToString

            AgL.AllowTableLog(True, AgL.GCn)
            If AgL.PubOfflineApplicable Then AgL.AllowTableLog(True, AgL.GcnSite)

            TSSL_ChangeMDIImage.Visible = AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)
            TSSL_SendSMS.Visible = AgLibrary.ClsConstant.IsSmsActive

            Call UpdateTableStructure()



            If AgL.IsFieldExist("MdiImage", "Company", AgL.ECompConn) Then
                mQry = "Select C.MdiImage From Company C Where C.Comp_Code ='" & AgL.PubCompCode & "'"
                bDtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                With bDtTemp
                    If .Rows.Count > 0 Then
                        If Not IsDBNull(.Rows(0)("MdiImage")) Then
                            Photo_Byte = DirectCast(.Rows(0)("MdiImage"), Byte())
                            Show_Picture(Photo_Byte)
                        End If
                    End If
                End With
                If bDtTemp IsNot Nothing Then bDtTemp.Dispose()
            End If


            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            AgL.SynchroniseSiteOffineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()

            AgL.ECmd = AgL.GCn.CreateCommand
            AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
            AgL.ECmd.Transaction = AgL.ETrans

            AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

            AgL.ETrans.Commit()


            AgL.AllowTableLog(True, AgL.GCn)
            If AgL.PubOfflineApplicable Then AgL.AllowTableLog(True, AgL.GcnSite)


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

     

      

        Try
            Me.Cursor = Cursors.WaitCursor

         
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub MDIMain_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
        If IsNothing(ActiveMdiChild) Then Exit Sub
        AgL.PubActiveMdiChild = Me.ActiveMdiChild

        If UCase(ActiveMdiChild.Name) <> UCase("RepView") Then
            Me.ActiveMdiChild.WindowState = FormWindowState.Normal
        End If
    End Sub


    Private Sub TSSL_Btn_ManageMDI_Click(ByVal sender As Object, ByVal e As System.EventArgs) _
    Handles TSSL_Btn_ManageMDI.Click, TSSL_Btn_ManageUserControl.Click, TSSL_Btn_UpdateTableStructure.Click, _
    TSSL_UpdateTableStructureWebToolStripMenuItem.Click, TSSL_Student.Click, TSSL_ChangeMDIImage.Click, _
    TSSL_SendSMS.Click

        Dim FrmObj As Form = Nothing
        Dim StrUserPermission As String = ""
        Dim DTUP As DataTable = Nothing
        Try
            Me.Cursor = Cursors.WaitCursor

            Select Case sender.Name
             

                Case TSSL_Btn_ManageMDI.Name
                    FManageMDI()

                Case TSSL_Btn_ManageUserControl.Name
                    FManageUserControl()

                Case TSSL_Btn_UpdateTableStructure.Name
                    If Not (AgL.StrCmp("SA", AgL.PubUserName) Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then MsgBox("Permission Denied!...") : Exit Sub

                    If MsgBox("Are You Sure to Update Table Structure?...", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub
                    Cls_Utility.UpdateTableStructure()
                    Cls_Fa.UpdateTableStructure()
                    Cls_ComnMast.UpdateTableStructure()


                    'Update Table Structure Start
                    Cls_AgStructure.UpdateTableStructure(AgL.PubMdlTable)
                    Cls_AgCustomFields.UpdateTableStructure(AgL.PubMdlTable)
                    Cls_AgTemplate.UpdateTableStructure(AgL.PubMdlTable)
                    Cls_AgTemplate.UpdateTableStructureFA(AgL.PubMdlTable)
                    Cls_AgTemplate.UpdateTableStructurePurchase(AgL.PubMdlTable)
                    Cls_AgTemplate.UpdateTableStructureForm(AgL.PubMdlTable)
                    Cls_AgTemplate.UpdateTableStructureSales(AgL.PubMdlTable)
                    Cls_Academic_Library.UpdateTableStructure(AgL.PubMdlTable)
                    Cls_Academic_Utility.UpdateTableStructure(AgL.PubMdlTable)
                    Cls_Academic_UtilityMain.UpdateTableStructure(AgL.PubMdlTable)

                    'Cls_Scholar_Main.UpdateTableStructure(AgL.PubMdlTable)
               

                    AgL.FExecuteDBScript(AgL.PubMdlTable, AgL.GCn)
                    'Update Table Structure End



                    'Update Table Initialiser Start
                    Cls_AgTemplate.UpdateTableInitialiser()
                    Cls_Academic_Library.UpdateTableInitialiser()
                    Cls_Academic_Utility.UpdateTableInitialiser()
                    Cls_Academic_UtilityMain.UpdateTableInitialiser()
                    Cls_AgStructure.UpdateTableInitialiser()
                    Cls_AgCustomFields.UpdateTableInitialiser()

                 
                    Cls_Scholar_Common.UpdateTableStructure()
                 


                    Cls_SMS.UpdateTableStructure()
                    Cls_EMail.UpdateTableStructure()
                    'Update Table Initialiser End


                    MsgBox("Please Reload the Software!...") : End

                Case TSSL_UpdateTableStructureWebToolStripMenuItem.Name
                    If Not (AgL.StrCmp("SA", AgL.PubUserName) Or AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName)) Then MsgBox("Permission Denied!...") : Exit Sub
                    If MsgBox("Is Machine : " & AgL.PubMachineName & " Connected to Internet?...", MsgBoxStyle.Question + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2) = MsgBoxResult.No Then Exit Sub
                    'Cls_SID.UpdateTableStructureWeb()

                    MsgBox("Update Table Structure Web Completed!")

                Case TSSL_ChangeMDIImage.Name
                    If Not AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName) Then MsgBox("Permission Denied!...") : Exit Sub

                    Call GetPicture(Photo_Byte)
                    Update_Picture("Company", "MdiImage", "Where Comp_Code = '" & AgL.PubCompCode & "'", Photo_Byte)

                Case TSSL_SendSMS.Name
                    If AgLibrary.ClsConstant.IsSmsActive Then
                        Call AgL.SendSms(AgL)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ReconnectDatabaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSSL_Btn_ReconnectDatabase.Click
        If Not FOpenIni(StrPath + "\" + IniName, AgL.PubUserName, AgL.PubUserPassword) Then
            MsgBox("Can't Connect to Database")
        Else
            AgIniVar.FOpenConnection(AgL.PubCompCode, AgL.PubSiteCode)
            AgIniVar.ProcSwapSiteCompanyDetail()
        End If

        TSSL_OnlineOffLine.Text = IIf(AgL.PubOfflineApplicable, " [Online]", " [Offline]")

        AgL.AllowTableLog(True, AgL.GCn)
        If AgL.PubOfflineApplicable Then AgL.AllowTableLog(True, AgL.GcnSite)

        AgL.ECmd = AgL.GCn.CreateCommand
        AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
        AgL.ECmd.Transaction = AgL.ETrans

        AgL.SynchroniseSiteOffineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

        AgL.ETrans.Commit()

        AgL.ECmd = AgL.GCn.CreateCommand
        AgL.ETrans = AgL.GCn.BeginTransaction(IsolationLevel.ReadCommitted)
        AgL.ECmd.Transaction = AgL.ETrans

        AgL.SynchroniseSiteOnLineData(AgL, AgL.GCn, AgL.Gcn_ConnectionString, AgL.GcnSite_ConnectionString, AgL.ECmd)

        AgL.ETrans.Commit()

        AgL.AllowTableLog(True, AgL.GCn)
        If AgL.PubOfflineApplicable Then AgL.AllowTableLog(True, AgL.GcnSite)
    End Sub

#Region "Update Table Structure"
    Sub UpdateTableStructure()
        Call AddNewTable()

        Call AddNewField()

        Call DeleteField()

        Call EditField()

        Call CreateVType()

        Call CreateView()
    End Sub

    Sub AddNewField()
        Dim mQry$ = ""
        Try
            ''============================< Table Name >====================================================
            '<Executable Code>
            ''============================< ************************* >=====================================

            ''================================<< Company >>====================================================================
            AgL.AddNewField(AgL.GCn, "Company", "MdiImage", "Image")
            AgL.AddNewField(AgL.GCn, "Company", "ImageDbName", "nVarChar(50)")
            AgL.AddNewField(AgL.GCn, "Company", "IsScholar", "bit", 0)
            AgL.AddNewField(AgL.GCn, "Company", "IsRoomCharges", "bit", 0)

            ''============================<< ************ >>================================================================

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub DeleteField()
        Try
            '<Executable Code>
            'ControlPermissionGroups
            'User_Permission            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub EditField()
        Try
            '<Executable Code>
            AgL.EditField("User_Permission", "ControlPermissionGroups", "nvarchar(max)", AgL.ECompConn)
            AgL.EditField("Login_Log", "U_EntDt", "DateTime", AgL.ECompConn, False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub AddNewTable()
        Dim mQry As String = ""

        '=================================================< ***************************** >===================================================
        '===============================================< VbLibrary Module Data Tables Start>=================================================
        '=================================================< ***************************** >===================================================
        Try
            mQry = "CREATE TABLE dbo.VbLib_Library_Member " & _
                    " ( " & _
                    " Member_Code NVARCHAR (10) NOT NULL, " & _
                    " Member_Type NVARCHAR (10) NOT NULL, " & _
                    " Sex         NVARCHAR (6) NULL, " & _
                    " CardNo      NVARCHAR (20) NULL, " & _
                    " U_Name      NVARCHAR (10) CONSTRAINT DF_VbLib_Library_Member_U_Name DEFAULT ('') NULL, " & _
                    " U_EntDt     SMALLDATETIME NULL, " & _
                    " U_AE        NVARCHAR (1) CONSTRAINT DF_VbLib_Library_Member_U_AE DEFAULT ('') NULL, " & _
                    " CONSTRAINT PK_VbLib_Library_Member PRIMARY KEY (Member_Code), " & _
                    " CONSTRAINT FK_VbLib_Library_Member_SubGroup FOREIGN KEY (Member_Code) REFERENCES dbo.SubGroup (SubCode) " & _
                    " )"
            If Not AgL.IsTableExist("VbLib_Library_Member", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_Library_Member", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.VbLib_Book_Mast " & _
                    " ( " & _
                    " Book_Code       NVARCHAR (10) NOT NULL, " & _
                    " Book_Name       NVARCHAR (50) NOT NULL, " & _
                    " Book_Type       NVARCHAR (15) NOT NULL, " & _
                    " Department_Code NVARCHAR (8) NULL, " & _
                    " Subject_Code    NVARCHAR (8) NULL, " & _
                    " Remark          NVARCHAR (255) NULL, " & _
                    " Div_Code        NVARCHAR (1) NOT NULL, " & _
                    " Site_Code       NVARCHAR (2) NOT NULL, " & _
                    " U_Name          NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt         SMALLDATETIME NOT NULL, " & _
                    " U_AE            NVARCHAR (1) NOT NULL, " & _
                    " CONSTRAINT PK_VbLib_Book_Mast PRIMARY KEY (Book_Code), " & _
                    " CONSTRAINT IX_VbLib_Book_Mast UNIQUE (Book_Name), " & _
                    " CONSTRAINT FK_VbLib_Book_Mast_Sch_Department FOREIGN KEY (Department_Code) REFERENCES dbo.Sch_Department (Code), " & _
                    " CONSTRAINT FK_VbLib_Book_Mast_Sch_Subject FOREIGN KEY (Subject_Code) REFERENCES dbo.Sch_Subject (Code), " & _
                    " CONSTRAINT FK_VbLib_Book_Mast_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("VbLib_Book_Mast", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_Book_Mast", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.VbLib_Publisher_Mast " & _
                    " ( " & _
                    " Publisher_Code NVARCHAR (10) NOT NULL, " & _
                    " Publisher_Name NVARCHAR (123) NOT NULL, " & _
                    " Div_Code       NVARCHAR (1) NOT NULL, " & _
                    " Site_Code      NVARCHAR (2) NOT NULL, " & _
                    " U_Name         NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt        SMALLDATETIME NOT NULL, " & _
                    " U_AE           NVARCHAR (1) NOT NULL, " & _
                    " CONSTRAINT PK_VbLib_Publisher_Mast PRIMARY KEY (Publisher_Code), " & _
                    " CONSTRAINT IX_VbLib_Publisher_Mast UNIQUE (Publisher_Name), " & _
                    " CONSTRAINT FK_VbLib_Publisher_Mast_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("VbLib_Publisher_Mast", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_Publisher_Mast", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.VbLib_Writer_Mast " & _
                    " ( " & _
                    " Writer_Code NVARCHAR (10) NOT NULL, " & _
                    " Writer_Name NVARCHAR (123) NOT NULL, " & _
                    " Div_Code    NVARCHAR (1) NOT NULL, " & _
                    " Site_Code   NVARCHAR (2) NOT NULL, " & _
                    " U_Name      NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt     SMALLDATETIME NOT NULL, " & _
                    " U_AE        NVARCHAR (1) NOT NULL, " & _
                    " CONSTRAINT PK_VbLib_Writer_Mast PRIMARY KEY (Writer_Code), " & _
                    " CONSTRAINT IX_VbLib_Writer_Mast UNIQUE (Writer_Name), " & _
                    " CONSTRAINT FK_VbLib_Writer_Mast_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"
            If Not AgL.IsTableExist("VbLib_Writer_Mast", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_Writer_Mast", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.VbLib_Almira_Mast " & _
                    " ( " & _
                    " Almira_Code NVARCHAR (8) NOT NULL, " & _
                    " Almira_Name NVARCHAR (50) NOT NULL, " & _
                    " Remark      NVARCHAR (50) NULL, " & _
                    " Div_Code    NVARCHAR (1) NOT NULL, " & _
                    " Site_Code   NVARCHAR (2) NOT NULL, " & _
                    " U_Name      NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt     SMALLDATETIME NOT NULL, " & _
                    " U_AE        NVARCHAR (1) NOT NULL, " & _
                    " CONSTRAINT PK_VbLib_Almira_Mast PRIMARY KEY (Almira_Code), " & _
                    " CONSTRAINT IX_VbLib_Almira_Mast UNIQUE (Almira_Name), " & _
                    " CONSTRAINT FK_VbLib_Almira_Mast_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code) " & _
                    " )"

            If Not AgL.IsTableExist("VbLib_Almira_Mast", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_Almira_Mast", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.VbLib_Purchase " & _
                    " ( " & _
                    " DocId          NVARCHAR (21) NOT NULL, " & _
                    " Div_Code       NVARCHAR (1) NOT NULL, " & _
                    " Site_Code      NVARCHAR (2) NOT NULL, " & _
                    " V_Type         NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix       NVARCHAR (5) NOT NULL, " & _
                    " V_Date         SMALLDATETIME NOT NULL, " & _
                    " V_No           BIGINT NOT NULL, " & _
                    " Cash_Credit    NVARCHAR (6) NOT NULL, " & _
                    " Bill_Date      SMALLDATETIME NOT NULL, " & _
                    " Bill_No        NVARCHAR (20) CONSTRAINT DF_VbLib_Purchase_Bill_No DEFAULT ('') NOT NULL, " & _
                    " PartyCode      NVARCHAR (10) CONSTRAINT DF_VbLib_Purchase_PartyCode DEFAULT ('') NOT NULL, " & _
                    " Total_Books    FLOAT CONSTRAINT DF_VbLib_Purchase_Total_Books DEFAULT ((0)) NOT NULL, " & _
                    " Gross_Amount   FLOAT CONSTRAINT DF_VbLib_Purchase_Gross_Amount DEFAULT ((0)) NOT NULL, " & _
                    " Discount       FLOAT CONSTRAINT DF_VbLib_Purchase_Discount DEFAULT ((0)) NOT NULL, " & _
                    " Add_Per        FLOAT CONSTRAINT DF_VbLib_Purchase_Add_Per DEFAULT ((0)) NOT NULL, " & _
                    " Addition       FLOAT CONSTRAINT DF_VbLib_Purchase_Addition DEFAULT ((0)) NOT NULL, " & _
                    " Other_Disc_Per FLOAT CONSTRAINT DF_VbLib_Purchase_Other_Disc_Per DEFAULT ((0)) NOT NULL, " & _
                    " Other_Discount FLOAT CONSTRAINT DF_VbLib_Purchase_Other_Discount DEFAULT ((0)) NOT NULL, " & _
                    " ROff           FLOAT CONSTRAINT DF_VbLib_Purchase_ROff DEFAULT ((0)) NOT NULL, " & _
                    " Net_Amount     FLOAT CONSTRAINT DF_VbLib_Purchase_Net_Amount DEFAULT ((0)) NOT NULL, " & _
                    " Remark         NVARCHAR (255) CONSTRAINT DF_VbLib_Purchase_Remark DEFAULT ('') NULL, " & _
                    " U_Name         NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt        SMALLDATETIME NOT NULL, " & _
                    " U_AE           NVARCHAR (1) NOT NULL, " & _
                    " CONSTRAINT PK_VbLib_Purchase PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_VbLib_Purchase UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_VbLib_Purchase_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_VbLib_Purchase_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_VbLib_Purchase_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_VbLib_Purchase_SubGroup FOREIGN KEY (PartyCode) REFERENCES dbo.SubGroup (SubCode) " & _
                    " )"
            If Not AgL.IsTableExist("VbLib_Purchase", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_Purchase", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.VbLib_Stock " & _
                    " ( " & _
                    " DocId          NVARCHAR (21) NOT NULL, " & _
                    " SNo            INT NOT NULL, " & _
                    " Div_Code       NVARCHAR (1) NOT NULL, " & _
                    " Site_Code      NVARCHAR (2) NOT NULL, " & _
                    " V_Type         NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix       NVARCHAR (5) NOT NULL, " & _
                    " V_Date         SMALLDATETIME NOT NULL, " & _
                    " V_No           BIGINT CONSTRAINT DF_VbLib_Stock_V_No DEFAULT ((0)) NOT NULL, " & _
                    " Book_Code      NVARCHAR (10) NOT NULL, " & _
                    " Publisher_Code NVARCHAR (10) NULL, " & _
                    " Writer_Code    NVARCHAR (10) NULL, " & _
                    " Recv_Qty       FLOAT CONSTRAINT DF_VbLib_Stock_Recv_Qty DEFAULT ((0)) NOT NULL, " & _
                    " Iss_Qty        FLOAT CONSTRAINT DF_VbLib_Stock_Iss_Qty DEFAULT ((0)) NOT NULL, " & _
                    " Ret_Qty        FLOAT CONSTRAINT DF_VbLib_Stock_Ret_Qty DEFAULT ((0)) NOT NULL, " & _
                    " Rate           FLOAT CONSTRAINT DF_VbLib_Stock_Rate DEFAULT ((0)) NOT NULL, " & _
                    " GAmount        FLOAT CONSTRAINT DF_VbLib_Stock_GAmount DEFAULT ((0)) NOT NULL, " & _
                    " Disc_Per       FLOAT CONSTRAINT DF_VbLib_Stock_Disc_Per DEFAULT ((0)) NOT NULL, " & _
                    " Disc_Amt       FLOAT CONSTRAINT DF_VbLib_Stock_Disc_Amt DEFAULT ((0)) NOT NULL, " & _
                    " NetAmount      FLOAT CONSTRAINT DF_VbLib_Stock_NetAmount DEFAULT ((0)) NOT NULL, " & _
                    " U_Name         NVARCHAR (10) NULL, " & _
                    " U_EntDt        SMALLDATETIME NULL, " & _
                    " U_AE           NVARCHAR (1) NULL, " & _
                    " CONSTRAINT PK_VbLib_Stock PRIMARY KEY (DocId,SNo), " & _
                    " CONSTRAINT IX_VbLib_Stock UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No,SNo), " & _
                    " CONSTRAINT FK_VbLib_Stock_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_VbLib_Stock_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_VbLib_Stock_VbLib_Book_Mast FOREIGN KEY (Book_Code) REFERENCES dbo.VbLib_Book_Mast (Book_Code), " & _
                    " CONSTRAINT FK_VbLib_Stock_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_VbLib_Stock_VbLib_Publisher_Mast FOREIGN KEY (Publisher_Code) REFERENCES dbo.VbLib_Publisher_Mast (Publisher_Code), " & _
                    " CONSTRAINT FK_VbLib_Stock_VbLib_Writer_Mast FOREIGN KEY (Writer_Code) REFERENCES dbo.VbLib_Writer_Mast (Writer_Code) " & _
                    " )"
            If Not AgL.IsTableExist("VbLib_Stock", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_Stock", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.VbLib_BookAccessEntry " & _
                    " ( " & _
                    " DocId       NVARCHAR (21) NOT NULL, " & _
                    " Div_Code    NVARCHAR (1) NOT NULL, " & _
                    " Site_Code   NVARCHAR (2) NOT NULL, " & _
                    " V_Type      NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix    NVARCHAR (5) NOT NULL, " & _
                    " V_Date      SMALLDATETIME NOT NULL, " & _
                    " V_No        BIGINT NOT NULL, " & _
                    " Purch_DocId NVARCHAR (21) NULL, " & _
                    " PartyCode   NVARCHAR (10) NULL, " & _
                    " Book_Type   NVARCHAR (15) NOT NULL, " & _
                    " Total_Books FLOAT CONSTRAINT DF_VbLib_BookAccessEntry_Total_Books DEFAULT ((0)) NOT NULL, " & _
                    " Remark      NVARCHAR (255) CONSTRAINT DF_VbLib_BookAccessEntry_Remark DEFAULT ('') NULL, " & _
                    " Recv_Date   SMALLDATETIME NULL, " & _
                    " U_Name      NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt     SMALLDATETIME NOT NULL, " & _
                    " U_AE        NVARCHAR (1) NOT NULL, " & _
                    " CONSTRAINT PK_VbLib_BookAccessEntry PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_VbLib_BookAccessEntry UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry_SubGroup FOREIGN KEY (PartyCode) REFERENCES dbo.SubGroup (SubCode), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry_VbLib_Purchase FOREIGN KEY (Purch_DocId) REFERENCES dbo.VbLib_Purchase (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("VbLib_BookAccessEntry", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_BookAccessEntry", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        Try
            mQry = "CREATE TABLE dbo.VbLib_BookIssueEntry " & _
                    " ( " & _
                    " DocId          NVARCHAR (21) NOT NULL, " & _
                    " Div_Code       NVARCHAR (1) NOT NULL, " & _
                    " Site_Code      NVARCHAR (2) NOT NULL, " & _
                    " V_Type         NVARCHAR (5) NOT NULL, " & _
                    " V_Prefix       NVARCHAR (5) NOT NULL, " & _
                    " V_Date         SMALLDATETIME NOT NULL, " & _
                    " V_No           BIGINT NOT NULL, " & _
                    " Academic_Year  NVARCHAR (8) NOT NULL, " & _
                    " Provisional_No NVARCHAR (20) NULL, " & _
                    " Borrower       NVARCHAR (10) NULL, " & _
                    " Issued_Books   FLOAT CONSTRAINT DF_VbLib_BookIssueEntry_Issued_Books DEFAULT ((0)) NOT NULL, " & _
                    " ReIssued_Books FLOAT CONSTRAINT DF_VbLib_BookIssueEntry_ReIssued_Books DEFAULT ((0)) NOT NULL, " & _
                    " Returned_Books FLOAT CONSTRAINT DF_VbLib_BookIssueEntry_Returned_Books DEFAULT ((0)) NOT NULL, " & _
                    " Balance_Books  FLOAT CONSTRAINT DF_VbLib_BookIssueEntry_Balance_Books DEFAULT ((0)) NOT NULL, " & _
                    " Fine_Due       FLOAT CONSTRAINT DF_VbLib_BookIssueEntry_Fine_Due DEFAULT ((0)) NOT NULL, " & _
                    " Fine_Received  FLOAT CONSTRAINT DF_VbLib_BookIssueEntry_Fine_Received DEFAULT ((0)) NOT NULL, " & _
                    " Fine_Discount  FLOAT CONSTRAINT DF_VbLib_BookIssueEntry_Fine_Discount DEFAULT ((0)) NOT NULL, " & _
                    " Fine_Balance   FLOAT CONSTRAINT DF_VbLib_BookIssueEntry_Fine_Balance DEFAULT ((0)) NOT NULL, " & _
                    " U_Name         NVARCHAR (10) CONSTRAINT DF_VbLib_BookIssueEntry_U_Name DEFAULT ('') NULL, " & _
                    " U_EntDt        SMALLDATETIME NULL, " & _
                    " U_AE           NVARCHAR (1) CONSTRAINT DF_VbLib_BookIssueEntry_U_AE DEFAULT ('') NULL, " & _
                    " CONSTRAINT PK_VbLib_BookIssueEntry PRIMARY KEY (DocId), " & _
                    " CONSTRAINT IX_VbLib_BookIssueEntry UNIQUE (Div_Code,Site_Code,V_Type,V_Prefix,V_No), " & _
                    " CONSTRAINT FK_VbLib_BookIssueEntry_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_VbLib_BookIssueEntry_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_VbLib_BookIssueEntry_Voucher_Prefix_Type FOREIGN KEY (V_Prefix) REFERENCES dbo.Voucher_Prefix_Type (V_Prefix), " & _
                    " CONSTRAINT FK_VbLib_BookIssueEntry_Sch_Session FOREIGN KEY (Academic_Year) REFERENCES dbo.Sch_Session (Code), " & _
                    " CONSTRAINT FK_VbLib_BookIssueEntry_VbLib_Library_Member FOREIGN KEY (Borrower) REFERENCES dbo.VbLib_Library_Member (Member_Code) " & _
                    " ) "
            If Not AgL.IsTableExist("VbLib_BookIssueEntry", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_BookIssueEntry", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.VbLib_BookAccessEntry1 " & _
                    " ( " & _
                    " DocId          NVARCHAR (21) NOT NULL, " & _
                    " SNo            INT NOT NULL, " & _
                    " V_Type         NVARCHAR (5) NOT NULL, " & _
                    " V_Date         SMALLDATETIME NOT NULL, " & _
                    " V_No           BIGINT CONSTRAINT DF_VbLib_BookAccessEntry1_V_No DEFAULT ((0)) NOT NULL, " & _
                    " BookNo         NVARCHAR (15) CONSTRAINT DF_VbLib_BookAccessEntry1_BookNo DEFAULT ('') NOT NULL, " & _
                    " Book_Code      NVARCHAR (10) NOT NULL, " & _
                    " Publisher_Code NVARCHAR (10) NULL, " & _
                    " Writer_Code    NVARCHAR (10) NULL, " & _
                    " Pub_Year       NVARCHAR (9) NULL, " & _
                    " Book_Pages     INT CONSTRAINT DF_VbLib_BookAccessEntry1_Book_Pages DEFAULT ((0)) NOT NULL, " & _
                    " Book_Price     FLOAT CONSTRAINT DF_VbLib_BookAccessEntry1_Book_Price DEFAULT ((0)) NOT NULL, " & _
                    " Almira_Code    NVARCHAR (8) CONSTRAINT DF_VbLib_BookAccessEntry1_Almira_Code DEFAULT ('') NOT NULL, " & _
                    " IssuedYN       BIT CONSTRAINT DF_VbLib_BookAccessEntry1_IssuedYN DEFAULT ((0)) NOT NULL, " & _
                    " Issue_DocId    NVARCHAR (21) NULL, " & _
                    " Remark         NVARCHAR (50) CONSTRAINT DF_VbLib_BookAccessEntry1_Remark DEFAULT ('') NULL, " & _
                    " CONSTRAINT PK_VbLib_BookAccessEntry1 PRIMARY KEY (DocId,SNo), " & _
                    " CONSTRAINT IX_VbLib_BookAccessEntry1 UNIQUE (BookNo), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry1_VbLib_BookAccessEntry FOREIGN KEY (DocId) REFERENCES dbo.VbLib_BookAccessEntry (DocId), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry1_VbLib_Book_Mast FOREIGN KEY (Book_Code) REFERENCES dbo.VbLib_Book_Mast (Book_Code), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry1_Voucher_Type FOREIGN KEY (V_Type) REFERENCES dbo.Voucher_Type (V_Type), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry1_VbLib_Writer_Mast FOREIGN KEY (Writer_Code) REFERENCES dbo.VbLib_Writer_Mast (Writer_Code), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry1_VbLib_Publisher_Mast FOREIGN KEY (Publisher_Code) REFERENCES dbo.VbLib_Publisher_Mast (Publisher_Code), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry1_VbLib_Almira_Mast FOREIGN KEY (Almira_Code) REFERENCES dbo.VbLib_Almira_Mast (Almira_Code), " & _
                    " CONSTRAINT FK_VbLib_BookAccessEntry1_VbLib_BookIssueEntry FOREIGN KEY (Issue_DocId) REFERENCES dbo.VbLib_BookIssueEntry (DocId) " & _
                    " )"
            If Not AgL.IsTableExist("VbLib_BookAccessEntry1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_BookAccessEntry1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.VbLib_BookIssueEntry1 " & _
                    " ( " & _
                    " DocId                   NVARCHAR (21) NOT NULL, " & _
                    " BookNo                  NVARCHAR (15) NOT NULL, " & _
                    " V_Type                  NVARCHAR (5) NOT NULL, " & _
                    " V_Date                  SMALLDATETIME NOT NULL, " & _
                    " V_No                    BIGINT CONSTRAINT DF_VbLib_BookIssueEntry1_V_No DEFAULT ((0)) NOT NULL, " & _
                    " Issued_Book_Condition   NVARCHAR (35) NULL, " & _
                    " Estimated_Ret_Days      INT CONSTRAINT DF_VbLib_BookIssueEntry1_Estimated_Ret_Days DEFAULT ((0)) NULL, " & _
                    " Estimated_Ret_Date      SMALLDATETIME NULL, " & _
                    " ReIssue_Date            SMALLDATETIME NULL, " & _
                    " ReIssue_Counter         INT CONSTRAINT DF_VbLib_BookIssueEntry1_ReIssue_Counter DEFAULT ((0)) NULL, " & _
                    " Return_Date             SMALLDATETIME NULL, " & _
                    " Returned_Book_Condition NVARCHAR (35) NULL, " & _
                    " Late_Fine               FLOAT CONSTRAINT DF_VbLib_BookIssueEntry1_Late_Fine DEFAULT ((0)) NOT NULL, " & _
                    " Discount                FLOAT CONSTRAINT DF_VbLib_BookIssueEntry1_Discount DEFAULT ((0)) NOT NULL, " & _
                    " Fine_Recv               FLOAT CONSTRAINT DF_VbLib_BookIssueEntry1_Fine_Recv DEFAULT ((0)) NOT NULL, " & _
                    " Remark                  NVARCHAR (50) CONSTRAINT DF_VbLib_BookIssueEntry1_Remark DEFAULT ('') NULL, " & _
                    " U_Name                  NVARCHAR (10) CONSTRAINT DF_VbLib_BookIssueEntry1_U_Name DEFAULT ('') NULL, " & _
                    " U_EntDt                 SMALLDATETIME NULL, " & _
                    " U_AE                    NVARCHAR (1) CONSTRAINT DF_VbLib_BookIssueEntry1_U_AE DEFAULT ('') NULL, " & _
                    " CONSTRAINT PK_VbLib_BookIssueEntry1 PRIMARY KEY (DocId,BookNo), " & _
                    " CONSTRAINT FK_VbLib_BookIssueEntry1_VbLib_BookIssueEntry FOREIGN KEY (DocId) REFERENCES dbo.VbLib_BookIssueEntry (DocId), " & _
                    " CONSTRAINT FK_VbLib_BookIssueEntry1_VbLib_BookAccessEntry1 FOREIGN KEY (BookNo) REFERENCES dbo.VbLib_BookAccessEntry1 (BookNo) " & _
                    " )"
            If Not AgL.IsTableExist("VbLib_BookIssueEntry1", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_BookIssueEntry1", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            mQry = "CREATE TABLE dbo.VbLib_Enviro " & _
                    " ( " & _
                    " Site_Code             NVARCHAR (2) NOT NULL, " & _
                    " Purch_Ac              NVARCHAR (10) NULL, " & _
                    " Cash_Acc              NVARCHAR (10) NULL, " & _
                    " FineAc                NVARCHAR (10) NULL, " & _
                    " Esti_Book_Return_Days FLOAT CONSTRAINT DF_VbLib_Enviro_Esti_Book_Return_Days DEFAULT ((0)) NOT NULL, " & _
                    " LibFinePerDay         FLOAT CONSTRAINT DF_VbLib_Enviro_LibFinePerDay DEFAULT ((0)) NOT NULL, " & _
                    " BookCnt               FLOAT CONSTRAINT DF_VbLib_Enviro_BookCnt DEFAULT ((0)) NOT NULL, " & _
                    " MagazineCnt           FLOAT CONSTRAINT DF_VbLib_Enviro_MagazineCnt DEFAULT ((0)) NOT NULL, " & _
                    " Div_Code              NVARCHAR (1) NOT NULL, " & _
                    " PreparedBy            NVARCHAR (10) NOT NULL, " & _
                    " U_EntDt               DATETIME NOT NULL, " & _
                    " U_AE                  NVARCHAR (1) NULL, " & _
                    " Edit_Date             DATETIME NULL, " & _
                    " ModifiedBy            NVARCHAR (10) NULL, " & _
                    " CONSTRAINT PK_VbLib_Enviro PRIMARY KEY (Site_Code), " & _
                    " CONSTRAINT FK_VbLib_Enviro_SiteMast FOREIGN KEY (Site_Code) REFERENCES dbo.SiteMast (Code), " & _
                    " CONSTRAINT FK_VbLib_Enviro_SubGroup FOREIGN KEY (Cash_Acc) REFERENCES dbo.SubGroup (SubCode), " & _
                    " CONSTRAINT FK_VbLib_Enviro_SubGroup1 FOREIGN KEY (Purch_Ac) REFERENCES dbo.SubGroup (SubCode), " & _
                    " CONSTRAINT FK_VbLib_Enviro_SubGroup2 FOREIGN KEY (FineAc) REFERENCES dbo.SubGroup (SubCode) " & _
                    " )"
            If Not AgL.IsTableExist("VbLib_Enviro", AgL.GCn) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)
            If AgL.PubOfflineApplicable Then If Not AgL.IsTableExist("VbLib_Enviro", AgL.GcnSite) Then AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '=================================================< ***************************** >===================================================
        '===============================================< VbLibrary Module Data Tables End>===================================================
        '=================================================< ***************************** >===================================================

    End Sub

    Private Sub CreateVType()
        Try
            '=================================================< ***************************** >===================================================
            '===============================================< VbLibrary Module Voucher Type Start>================================================
            '=================================================< ***************************** >===================================================

            '===================================================< Book Receive Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_VbLib_BookReceiveEntry, Academic_ProjLib.ClsMain.Cat_VbLib_Library, "Book Receive Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_VbLib_BookReceiveEntry, Academic_ProjLib.ClsMain.Cat_VbLib_Library, Academic_ProjLib.ClsMain.NCat_VbLib_BookReceiveEntry, "Book Receive Entry", Academic_ProjLib.ClsMain.NCat_VbLib_BookReceiveEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Magazine Receive Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_VbLib_MagazineReceiveEntry, Academic_ProjLib.ClsMain.Cat_VbLib_Library, "Magazine Receive Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_VbLib_MagazineReceiveEntry, Academic_ProjLib.ClsMain.Cat_VbLib_Library, Academic_ProjLib.ClsMain.NCat_VbLib_MagazineReceiveEntry, "Magazine Receive Entry", Academic_ProjLib.ClsMain.NCat_VbLib_MagazineReceiveEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Issue/Receive Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_VbLib_IssueReceiveEntry, Academic_ProjLib.ClsMain.Cat_VbLib_Library, "Issue/Receive Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_VbLib_IssueReceiveEntry, Academic_ProjLib.ClsMain.Cat_VbLib_Library, Academic_ProjLib.ClsMain.NCat_VbLib_IssueReceiveEntry, "Issue/Receive Entry", Academic_ProjLib.ClsMain.NCat_VbLib_IssueReceiveEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '===================================================< Purchase Entry V_Type >===================================================
            AgL.CreateNCat(AgL.GCn, Academic_ProjLib.ClsMain.NCat_VbLib_PurchaseEntry, Academic_ProjLib.ClsMain.Cat_VbLib_Library, "Purchase Entry", AgL.PubSiteCode)
            AgL.CreateVType(AgL.GCn, Academic_ProjLib.ClsMain.NCat_VbLib_PurchaseEntry, Academic_ProjLib.ClsMain.Cat_VbLib_Library, Academic_ProjLib.ClsMain.NCat_VbLib_PurchaseEntry, "Purchase Entry", Academic_ProjLib.ClsMain.NCat_VbLib_PurchaseEntry, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)

            '=================================================< ***************************** >===================================================
            '===============================================< VbLibrary Module Voucher Type End>==================================================
            '=================================================< ***************************** >===================================================

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub CreateView()
        Dim mQry$ = ""
        '' Note Write Each View in Separate <Try---Catch> Section
        '=================================================< ***************************** >===================================================
        '==============================================< VbLibrary Module View Creation Start>================================================
        '=================================================< ***************************** >===================================================
        Try
            mQry = "CREATE VIEW dbo.Library_Member As " & _
                    " SELECT Lm.*, Sg.Name AS Member_Name, Sg.DispName AS MemberDispName, Sg.ManualCode MemberManualCode, Sg.FatherName AS Father_Name, " & _
                    " CASE Lm.Member_Type WHEN  'Student' THEN Lm.Member_Code ELSE NULL END AS Student, " & _
                    " CASE Lm.Member_Type WHEN  'Employee' THEN Lm.Member_Code ELSE NULL END AS Employee, " & _
                    " Sg.Div_Code, Sg.Site_Code, Sg.CommonAc " & _
                    " FROM VbLib_Library_Member Lm " & _
                    " LEFT JOIN SubGroup Sg ON Sg.SubCode = Lm.Member_Code "

            AgL.IsViewExist("Library_Member", AgL.GCn, True)
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

            If AgL.PubOfflineApplicable Then
                AgL.IsViewExist("Library_Member", AgL.GcnSite, True)
                AgL.Dman_ExecuteNonQry(mQry, AgL.GcnSite)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '=================================================< ***************************** >===================================================
        '==============================================< VbLibrary Module View Creation End>================================================== 
        '=================================================< ***************************** >===================================================
    End Sub
#End Region

    Public Sub GetPicture(ByRef ByteArr As Byte(), Optional ByVal ImagePath As String = "")
        Dim OpenPicDialogBox As OpenFileDialog
        Dim Mem As System.IO.MemoryStream
        Dim Img As Image


        OpenPicDialogBox = New OpenFileDialog

        OpenPicDialogBox.Title = "Set Image File"
        OpenPicDialogBox.Filter = "JPG Files(*.jpg)|*.jpg|JPEG Files(*.jpeg)|*.jpeg" & _
                                "|Gif Files(*.gif)|*.gif|Bitmap Files(*.bmp)|*.bmp"

        If ImagePath.Trim = "" Then ImagePath = My.Application.Info.DirectoryPath
        OpenPicDialogBox.InitialDirectory = ImagePath
        OpenPicDialogBox.DefaultExt = "*.jpeg"
        OpenPicDialogBox.FilterIndex = 1


        OpenPicDialogBox.FileName = ""


        If OpenPicDialogBox.ShowDialog = Windows.Forms.DialogResult.Cancel Then Exit Sub

        Dim sFilePath As String
        sFilePath = OpenPicDialogBox.FileName
        If sFilePath = "" Then Exit Sub


        If System.IO.File.Exists(sFilePath) = False Then
            Exit Sub
        Else
            ByteArr = Get_ImageFile_Binary(sFilePath)
            Mem = New System.IO.MemoryStream(ByteArr)
            Img = Image.FromStream(Mem)

            'mPictureBox.Image = Img
            'mPictureBox.Tag = sFilePath

            Me.BackgroundImage = Img
        End If
    End Sub

    Public Function Get_ImageFile_Binary(ByVal mImageFilePath As String) As Byte()
        Dim FS As System.IO.FileStream = New System.IO.FileStream(mImageFilePath.ToString(), System.IO.FileMode.Open)
        Dim ImgByte As Byte() = New Byte(FS.Length) {}
        FS.Read(ImgByte, 0, FS.Length)

        FS.Close()
        Get_ImageFile_Binary = ImgByte
    End Function

    Sub Update_Picture(ByVal mTable As String, ByVal mColumn As String, ByVal mCondition As String, ByVal ByteArr As Byte())
        If ByteArr Is Nothing Then Exit Sub
        Dim sSQL As String = "Update " & mTable & " Set " & mColumn & "=@pic " & mCondition

        Dim cmd As SqlCommand = New SqlCommand(sSQL, AgL.GCn)
        Dim Pic As SqlParameter = New SqlParameter("@pic", SqlDbType.Image)
        Pic.Value = ByteArr
        cmd.Parameters.Add(Pic)
        cmd.ExecuteNonQuery()
    End Sub


    Sub Show_Picture(ByVal B As Byte())
        Dim Mem As System.IO.MemoryStream
        Dim Img As Image

        Mem = New System.IO.MemoryStream(B)
        Img = Image.FromStream(Mem)
        Me.BackgroundImage = Img
    End Sub

    Private Sub ProcCreateSms(ByVal StrEvent As String)
        Dim bDtMain As DataTable = Nothing
        Dim bIntSmsBeforeDays% = 7, bIntI% = 0
        Dim bStrSMS$ = "", bStrMobileNo$ = "", bStrCategory$ = "", bStrSubCode$ = "", bStrSmsDate$ = "", bStrFromDate$ = "", bStrToDate$ = ""
        Dim bStrSmsQry$ = "", bStrMainTable$ = "", bStrMainField$ = ""
        Dim bDtSmsEvent As DataTable = Nothing

        Try
            Me.Cursor = Cursors.WaitCursor
            If Not AgLibrary.ClsConstant.IsSmsActive Then Exit Sub


            bStrFromDate = AgL.PubLoginDate
            bStrToDate = Format(DateAdd(DateInterval.Day, bIntSmsBeforeDays, CDate(AgL.PubLoginDate)), AgLibrary.ClsConstant.DateFormat_ShortDate)


            mQry = "SELECT E.* FROM Sms_Event E  WITH (NoLock) WHERE E.Event = '" & StrEvent & "'"
            bDtSmsEvent = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

            If bDtSmsEvent.Rows.Count > 0 Then
                bStrSMS = AgL.XNull(bDtSmsEvent.Rows(0)("Message")).ToString
                bStrCategory = AgL.XNull(bDtSmsEvent.Rows(0)("Category")).ToString
            End If
            If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()


            bStrSmsQry = "SELECT S.SubCode, S.MsgDate, S.Status FROM Sms_Trans S WITH (NoLock) " & _
                            " WHERE S.Category = '" & bStrCategory & "' " & _
                            " And S.MsgDate Between " & AgL.Chk_Text(bStrFromDate) & " AND " & AgL.Chk_Text(bStrToDate) & " "

            mQry = "SELECT T.SubCode, " & _
                    " Convert(SMALLDATETIME,LEFT(Convert(VARCHAR," & bStrMainField & ",106),7)+'" & CDate(AgL.PubLoginDate).Year.ToString & "') AS MsgDate, " & _
                    " Right(IsNull(Sg.Mobile,''),10) AS Mobile " & _
                    " FROM (" & bStrMainTable & " T WITH (NoLock) " & _
                    " INNER JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = T.SubCode) " & _
                    " Left Join (" & bStrSmsQry & ") As vS On vS.SubCode = T.SubCode And vS.MsgDate = Convert(SMALLDATETIME,LEFT(Convert(VARCHAR," & bStrMainField & ",106),7)+'" & CDate(AgL.PubLoginDate).Year.ToString & "') " & _
                    " WHERE " & bStrMainField & " IS NOT NULL  " & _
                    " AND Len(Sg.Mobile) >= 10 " & _
                    " AND Convert(SMALLDATETIME,LEFT(Convert(VARCHAR," & bStrMainField & ",106),7)+'" & CDate(AgL.PubLoginDate).Year.ToString & "') BETWEEN " & AgL.Chk_Text(bStrFromDate) & " AND " & AgL.Chk_Text(bStrToDate) & " " & _
                    " And vS.SubCode Is Null "
            bDtMain = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            If bDtMain.Rows.Count > 0 Then
                For bIntI = 0 To bDtMain.Rows.Count - 1
                    bStrSubCode = AgL.XNull(bDtMain.Rows(bIntI)("SubCode"))
                    bStrMobileNo = AgL.XNull(bDtMain.Rows(bIntI)("Mobile"))
                    bStrSmsDate = Format(AgL.XNull(bDtMain.Rows(bIntI)("MsgDate")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                    If bStrSMS.Trim <> "" And bStrMobileNo.Trim <> "" And bStrSmsDate.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, bStrSmsDate, bStrCategory, bStrSubCode, bStrMobileNo, AgL.PubLoginDate, bStrSMS)
                    End If
                Next
            End If
            If bDtMain IsNot Nothing Then bDtMain.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            If bDtMain IsNot Nothing Then bDtMain.Dispose()
            If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()
        End Try
    End Sub

    Private Sub ProcCreateSmsBookReturnReminder(ByVal StrEvent As String)
        Dim bDtMain As DataTable = Nothing
        Dim bDtEnviro As DataTable = Nothing
        Dim bIntSmsBeforeDays% = 0, bIntI% = 0
        Dim bStrSMS$ = "", bStrMobileNo$ = "", bStrCategory$ = "", bStrSubCode$ = "", bStrSmsDate$ = "", bStrFromDate$ = "", bStrToDate$ = ""
        Dim bStrSmsQry$ = "", bStrMainTable$ = "", bStrMainField$ = ""
        Dim bDtSmsEvent As DataTable = Nothing

        Try
            Me.Cursor = Cursors.WaitCursor
            If Not AgLibrary.ClsConstant.IsSmsActive Then Exit Sub

            mQry = "select ReturnReminderBefore from Lib_Enviro  with (NoLock)"
            bDtEnviro = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            If bDtEnviro.Rows.Count > 0 Then
                bIntSmsBeforeDays = AgL.VNull(bDtEnviro.Rows(0)("ReturnReminderBefore"))
            End If

            bStrFromDate = AgL.PubLoginDate
            bStrToDate = Format(DateAdd(DateInterval.Day, bIntSmsBeforeDays, CDate(AgL.PubLoginDate)), AgLibrary.ClsConstant.DateFormat_ShortDate)

            If AgL.StrCmp(StrEvent, Academic_Library.ClsMain.SmsEvent.BookReturn_Reminder) Then
                bStrMainTable = "Lib_BookIssue"
                bStrMainField = "B.ToReturnDate"
            End If

            mQry = "SELECT E.* FROM Sms_Event E  WITH (NoLock) WHERE E.Event = '" & StrEvent & "'"
            bDtSmsEvent = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

            If bDtSmsEvent.Rows.Count > 0 Then
                bStrSMS = AgL.XNull(bDtSmsEvent.Rows(0)("Message")).ToString
                bStrCategory = AgL.XNull(bDtSmsEvent.Rows(0)("Category")).ToString
            End If
            If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()

            bStrSmsQry = "SELECT S.SubCode, S.V_Date, S.Status FROM Sms_Trans S WITH (NoLock) " & _
                            " WHERE S.Category = '" & bStrCategory & "' " & _
                            " And S.V_Date Between " & AgL.Chk_Text(bStrFromDate) & " AND " & AgL.Chk_Text(bStrToDate) & " "

            mQry = "SELECT T.Member, " & _
                    " '" & AgL.PubLoginDate & "' As V_Date, " & _
                    " Max(Right(IsNull(Sg.Mobile,''),10)) AS Mobile " & _
                    " FROM (" & bStrMainTable & " T WITH (NoLock) " & _
                    " INNER JOIN SubGroup Sg WITH (NoLock) ON Sg.SubCode = T.Member " & _
                    " INNER JOIN Lib_BookIssueDetail b WITH (noLock) ON T.DocID=b.DocId) " & _
                    " Left Join (" & bStrSmsQry & ") As vS On vS.SubCode = T.Member And vS.V_Date = " & AgL.ConvertDate(AgL.PubLoginDate) & " " & _
                    " WHERE " & bStrMainField & " IS NOT NULL  " & _
                    " AND Len(Sg.Mobile) >= 10 " & _
                    " AND " & bStrMainField & " <= " & AgL.Chk_Text(bStrToDate) & " " & _
                    " And vS.SubCode Is Null AND b.ReturnDate IS null " & _
                    " Group By T.Member "
            bDtMain = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            If bDtMain.Rows.Count > 0 Then
                For bIntI = 0 To bDtMain.Rows.Count - 1
                    bStrSubCode = AgL.XNull(bDtMain.Rows(bIntI)("Member"))
                    bStrMobileNo = AgL.XNull(bDtMain.Rows(bIntI)("Mobile"))
                    bStrSmsDate = Format(AgL.XNull(bDtMain.Rows(bIntI)("V_Date")), AgLibrary.ClsConstant.DateFormat_ShortDate)

                    If bStrSMS.Trim <> "" And bStrMobileNo.Trim <> "" And bStrSmsDate.Trim <> "" Then
                        AgL.ProcSmsSave(AgL.GCn, AgL.ECmd, bStrSmsDate, bStrCategory, bStrSubCode, bStrMobileNo, AgL.PubLoginDate, bStrSMS)
                    End If
                Next
            End If
            If bDtMain IsNot Nothing Then bDtMain.Dispose()


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            Me.Cursor = Cursors.Default
            If bDtMain IsNot Nothing Then bDtMain.Dispose()
            If bDtSmsEvent IsNot Nothing Then bDtSmsEvent.Dispose()
        End Try
    End Sub


    Public Shared Function FunRetLinkForm_CommonMaster(ByVal MasterName As String, ByVal StrUserPermission As String, Optional ByVal DTUP As DataTable = Nothing) As Form
        Dim bCls_ComnMast As Common_Master.ClsMain = Nothing
        Dim Mdi As Scholar_Common.MDIMain = New Scholar_Common.MDIMain
        Dim FrmObj As Form = Nothing
        Dim DtTemp As DataTable = Nothing
        Dim MnuName$ = "", MnuText$ = "", mQry$ = ""

        Try

            bCls_ComnMast = New Common_Master.ClsMain(AgL)

            Select Case MasterName
                'Case EntryPointName.City
                '    MnuName = Mdi.MnuCityMaster.Name
                '    MnuText = Mdi.MnuCityMaster.Text

                'Case EntryPointName.State
                '    MnuName = Mdi.MnuStateMaster.Name
                '    MnuText = Mdi.MnuStateMaster.Text

                'Case EntryPointName.Country
                '    MnuName = Mdi.MnuCountryMaster.Name
                '    MnuText = Mdi.MnuCountryMaster.Text

                Case EntryPointName.LedgerMaster
                    MnuName = Mdi.MnuLedgerAcMaster.Name
                    MnuText = Mdi.MnuLedgerAcMaster.Text

                Case EntryPointName.Division
                    MnuName = Mdi.MnuDivisionMaster.Name
                    MnuText = Mdi.MnuDivisionMaster.Text

                Case EntryPointName.Company
                    MnuName = Mdi.MnuCompanyMaster.Name
                    MnuText = Mdi.MnuCompanyMaster.Text

                Case EntryPointName.Bank
                    MnuName = Mdi.MnuBankMaster.Name
                    MnuText = Mdi.MnuBankMaster.Text




                Case Else
                    MnuName = "" : MnuText = ""
            End Select

            If MnuName.Trim <> "" Then
                FrmObj = bCls_ComnMast.CFOpen.FOpen(MnuName, MnuText, True, StrUserPermission, DTUP)
            End If


            FunRetLinkForm_CommonMaster = FrmObj
        Catch ex As Exception
            FunRetLinkForm_CommonMaster = Nothing
            MsgBox(ex.Message)
        Finally
            bCls_ComnMast = Nothing
        End Try
    End Function

    Public Class EntryPointName
        Public Const City As String = "City"
        Public Const State As String = "State"
        Public Const Country As String = "Country"
        Public Const LedgerMaster As String = "LedgerMaster"
        Public Const Division As String = "Division"
        Public Const Site As String = "Site"
        Public Const Company As String = "Company"
        Public Const Bank As String = "Bank"

    End Class
End Class
