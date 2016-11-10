Imports System.Data.SqlClient
Imports System

Module MdlFunction
    Public Function FOpenIni(ByVal StrIniPath As String, ByVal StrUserName As String, ByVal StrPassword As String) As Boolean
        Dim StrGetPassword As String = ""
        Dim OLECmd As New OleDb.OleDbCommand
        Dim BlnRtn As Boolean
        Dim ECmd As SqlClient.SqlCommand

        BlnRtn = False
        Try
            AgL.PubServerName = AgL.INIRead(StrIniPath, "Server", "Offline", "")

            If AgL.PubServerName.Trim <> "" Then
                If Not IsConnectionAvailable() Then
                    If MsgBox("Internet is Not Available. Do you want to Run Software Offline?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                        AgL.PubServerName = AgL.INIRead(StrIniPath, "Server", "Offline", "")
                    Else
                        FOpenIni = False
                        Exit Function
                    End If
                Else
                    AgL.PubServerName = AgL.INIRead(StrIniPath, "Server", "Name", "")
                    AgL.PubSqlServerSite = AgL.XNull(AgL.INIRead(StrIniPath, "Server", "Offline", ""))
                    If AgL.PubSqlServerSite <> "" Then
                        AgL.PubOfflineApplicable = True
                    End If

                End If
            Else
                AgL.PubServerName = AgL.INIRead(StrIniPath, "Server", "Name", "")
            End If


            AgL.PubDBUserSQL = AgL.INIRead(mIniPath, "Security", "User", "SA")
            AgL.PubDBPasswordSQL = AgL.DCODIFY(AgL.INIRead(mIniPath, "Security", "Password", ""))

            AgL.PubReportPath = AgL.INIRead(StrIniPath, "Reports", "Path", Library_Login.My.Application.Info.DirectoryPath + "\Reports")
            AgL.PubReportFaPath = AgL.INIRead(StrIniPath, "Reports", "Accounts", AgL.PubReportPath)
            AgL.PubCompanyDBName = AgL.INIRead(StrIniPath, "CompanyInfo", "Path", "")
            AgL.PubChkPasswordSQL = AgL.INIRead(StrIniPath, "Security", "PasswordSQL", "")
            AgL.PubChkPasswordAccess = AgL.INIRead(StrIniPath, "Security", "PasswordAccess", "")
            AgL.PubSiteCodeActual = AgL.INIRead(StrIniPath, "Site", "Site", "")
            AgL.PubDataBackUpPath = AgL.INIRead(StrIniPath, "Backup", "BackupPath", "")

            AgL.PubReportPath_CommonData = AgL.INIRead(StrIniPath, "Reports", "CommonData", AgL.PubReportPath)
            AgL.PubReportPath_Utility = AgL.INIRead(StrIniPath, "Reports", "Utility", AgL.PubReportPath)
            AgL.PubReportPath_Store = AgL.INIRead(StrIniPath, "Reports", "Store", AgL.PubReportPath)

            AgL.PubReportPath_SMS = AgL.INIRead(StrIniPath, "Reports", "SMS", AgL.PubReportPath)
            AgL.PubReportPath_EMail = AgL.INIRead(StrIniPath, "Reports", "EMail", AgL.PubReportPath)


            AgL.PubMoveRecApplicable = True


            AgIniVar = New AgLibrary.ClsIniVariables(AgL)

            BlnRtn = AgIniVar.FOpenIni(StrUserName, StrPassword)

            If Not AgL.PubIsUserActive Then
                MsgBox("Not An Active User! ")
                BlnRtn = False
            End If


            OLECmd = Nothing
        Catch Ex As Exception
            BlnRtn = False
            MsgBox(Ex.Message, MsgBoxStyle.Information, AgLibrary.ClsMain.PubMsgTitleInfo)
        Finally
            ECmd = Nothing
            PLib = New Academic_ProjLib.ClsMain(AgL)
            AgPL = New AgLibrary.ClsPrinting(AgL)

            PLib.PubReportPath_Academic_Main = AgL.INIRead(StrIniPath, "Reports", "Academic", AgL.PubReportPath)
            PLib.PubReportPath_TimeTable = AgL.INIRead(StrIniPath, "Reports", "TimeTable", AgL.PubReportPath)
            PLib.PubReportPath_Exam = AgL.INIRead(StrIniPath, "Reports", "Exam", AgL.PubReportPath)
            PLib.PubReportPath_Hostel = AgL.INIRead(StrIniPath, "Reports", "Hostel", AgL.PubReportPath)
            FOpenIni = BlnRtn
        End Try

    End Function


#Region "Menu Design"
    Public Sub FAddMenu_Windows(ByVal MD As MDIMain, ByVal MenuStrip1 As MenuStrip)
        Dim TSMI_Item As ToolStripMenuItem
        Dim TSSP_Item As ToolStripSeparator

        MenuStrip1.Items.Add("Windows")
        MenuStrip1.Items(MenuStrip1.Items.Count - 1).Name = "CWDS_Windows"
        MenuStrip1.Items(MenuStrip1.Items.Count - 1).Tag = "CWDS"     'CWSD Stands For Common Windows 
        FAddHandler(MenuStrip1.Items(MenuStrip1.Items.Count - 1), MD)
        MenuStrip1.MdiWindowListItem = MenuStrip1.Items(MenuStrip1.Items.Count - 1)

        TSMI_Item = New ToolStripMenuItem("Cascade")
        TSMI_Item.Name = "CWDS_Cascade"
        TSMI_Item.Tag = "CWDS"
        FAddHandler(TSMI_Item, MD)
        DirectCast(MenuStrip1.Items(MenuStrip1.Items.Count - 1), ToolStripMenuItem).DropDownItems.Add(TSMI_Item)

        TSMI_Item = New ToolStripMenuItem("Tile Horizontal")
        TSMI_Item.Name = "CWDS_TileHorizontal"
        TSMI_Item.Tag = "CWDS"
        FAddHandler(TSMI_Item, MD)
        DirectCast(MenuStrip1.Items(MenuStrip1.Items.Count - 1), ToolStripMenuItem).DropDownItems.Add(TSMI_Item)

        TSMI_Item = New ToolStripMenuItem("Tile Vertical")
        TSMI_Item.Name = "CWDS_TileVertical"
        TSMI_Item.Tag = "CWDS"
        FAddHandler(TSMI_Item, MD)
        DirectCast(MenuStrip1.Items(MenuStrip1.Items.Count - 1), ToolStripMenuItem).DropDownItems.Add(TSMI_Item)

        TSSP_Item = New ToolStripSeparator()
        TSSP_Item.Name = "CWDS_SP1"
        TSSP_Item.Tag = "CWDS"
        DirectCast(MenuStrip1.Items(MenuStrip1.Items.Count - 1), ToolStripMenuItem).DropDownItems.Add(TSSP_Item)

        TSMI_Item = New ToolStripMenuItem("Close All")
        TSMI_Item.Name = "CWDS_CloseAll"
        TSMI_Item.Tag = "CWDS"
        FAddHandler(TSMI_Item, MD)
        DirectCast(MenuStrip1.Items(MenuStrip1.Items.Count - 1), ToolStripMenuItem).DropDownItems.Add(TSMI_Item)

        TSMI_Item = New ToolStripMenuItem("Exit")
        TSMI_Item.Name = "CWDS_Exit"
        TSMI_Item.Tag = "CWDS"
        FAddHandler(TSMI_Item, MD)
        DirectCast(MenuStrip1.Items(MenuStrip1.Items.Count - 1), ToolStripMenuItem).DropDownItems.Add(TSMI_Item)
    End Sub

    Public Sub FAddMenu(ByVal MD As MDIMain, Optional ByVal StrModule As String = "")
        Dim MenuStrip1 As New MenuStrip
        Dim ADTemp As OleDb.OleDbDataAdapter = Nothing
        Dim DTTemp As New DataTable
        Dim DTTemp1 As New DataTable
        Dim mParentMenu As String
        Dim I As Integer, Cnt As Integer
        Dim TSMIParent As ToolStripMenuItem

        FRemoveMenu(MD)
        DTTemp = AgL.FillData("Select P.UserName+P.MnuName+P.MnuModule as SearchKey, 	P.UserName,P.MnuModule,P.MnuName,P.MnuText,P.SNo,P.MnuLevel,P.Parent,P.Permission,P.ReportFor,P.Active,P.RowId,P.UpLoadDate,User_Module.MainStreamCode,User_Module.GroupLevel From User_Permission P Left Join (Select MnuName+MnuModule As SearchKey,MainStreamCode, GroupLevel From User_Permission Where UserName='SA') As User_Module On P.MnuName+P.MnuModule=User_Module.SearchKey Where P.UserName='" & IIf(AgL.StrCmp(AgL.PubUserName, AgLibrary.ClsConstant.PubSuperUserName), "SA", AgL.PubUserName) & "' And IsNull(P.Active,'Y')='Y' And IsNull(P.Permission,'****') <> '****' Order By User_Module.MainStreamCode", AgL.ECompConn).Tables(0)

        Try
            For I = 0 To DTTemp.Rows.Count - 1
                StrModule = AgL.XNull(DTTemp.Rows(I)("MnuModule"))
                If StrModule = "Utility" And AgL.XNull(DTTemp.Rows(I).Item("MnuName")) = "MnuStructure" Then
                    Exit For
                End If
                Select Case Len(AgL.XNull(DTTemp.Rows(I)("MainStreamCode")))
                    Case 3
                        mParentMenu = AgL.XNull(DTTemp.Rows(I).Item("MnuName"))
                        MenuStrip1.Items.Add(AgL.XNull(DTTemp.Rows(I).Item("MnuText")))
                        MenuStrip1.Items(Cnt).Name = AgL.XNull(DTTemp.Rows(I).Item("MnuName"))
                        MenuStrip1.Items(Cnt).Tag = AgL.XNull(DTTemp.Rows(I).Item("ReportFor"))
                        MenuStrip1.Items(Cnt).ToolTipText = StrModule
                        FAddHandler(MenuStrip1.Items(Cnt), MD)

                        TSMIParent = DirectCast(MenuStrip1.Items(Cnt), ToolStripMenuItem)
                        FAddChildMenu(TSMIParent, AgL.XNull(DTTemp.Rows(I).Item("MnuName")), DTTemp, StrModule, MD)
                        Cnt += 1
                End Select

            Next
            FAddMenu_Windows(MD, MenuStrip1)
            MD.Controls.Add(MenuStrip1)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub FAddChildMenu(ByVal TSMI As ToolStripMenuItem, ByVal ParentName As String, ByVal DtMenu As DataTable, ByVal StrModule As String, ByVal MD As MDIMain)
        Dim PkCol(1) As DataColumn
        Dim PkCol1(1) As DataColumn
        Dim DtSubMenu As DataTable
        Dim DtSubMenu1 As DataTable
        Dim TSMI_Item As ToolStripMenuItem = Nothing
        Dim StrTemp As String
        Dim I As Integer

        Try

            DtSubMenu = DtMenu.Copy
            DtSubMenu1 = DtMenu.Copy

            PkCol(0) = DtSubMenu.Columns(0)
            DtSubMenu.PrimaryKey = PkCol

            PkCol1(0) = DtSubMenu1.Columns(0)
            DtSubMenu1.PrimaryKey = PkCol1

            DtSubMenu.DefaultView.RowFilter = Nothing
            DtSubMenu.DefaultView.RowFilter = "[Parent] = '" + ParentName + "' And [MnuModule] = '" & StrModule & "' "

            For I = 0 To DtSubMenu.DefaultView.Count - 1
                StrTemp = AgL.XNull(DtSubMenu.DefaultView.Item(I)("MnuText"))
                TSMI_Item = New ToolStripMenuItem(StrTemp)
                StrTemp = AgL.XNull(DtSubMenu.DefaultView.Item(I)("MnuName"))
                TSMI_Item.Name = StrTemp
                TSMI_Item.Tag = AgL.XNull(DtSubMenu.DefaultView.Item(I)("ReportFor"))
                TSMI_Item.ToolTipText = StrModule
                FAddHandler(TSMI_Item, MD)


                DtSubMenu1.DefaultView.RowFilter = Nothing
                DtSubMenu1.DefaultView.RowFilter = "[Parent] = '" + TSMI_Item.Name + "' And [MnuModule] = '" & StrModule & "' "

                If DtSubMenu1.DefaultView.Count > 0 Then
                    FAddChildMenu(TSMI_Item, AgL.XNull(DtSubMenu.DefaultView.Item(I)("MnuName")), DtMenu, StrModule, MD)
                End If
                TSMI.DropDownItems.Add(TSMI_Item)
            Next

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            'TSMI_Item = Nothing
        End Try
    End Sub


    Private Sub FRemoveHandler(ByVal MnuStrp As MenuStrip, ByVal MD As MDIMain)
        RemoveHandler MnuStrp.Click, AddressOf MD.FMenuItem_Click
    End Sub

    Private Sub FRemoveHandler(ByVal TSMI_Var As ToolStripMenuItem, ByVal MD As MDIMain)
        RemoveHandler TSMI_Var.Click, AddressOf MD.FMenuItem_Click
    End Sub

    Private Sub FAddHandler(ByVal MnuStrp As MenuStrip, ByVal MD As MDIMain)
        FRemoveHandler(MnuStrp, MD)
        AddHandler MnuStrp.Click, AddressOf MD.FMenuItem_Click
    End Sub

    Private Sub FAddHandler(ByVal TSMI_Var As ToolStripMenuItem, ByVal MD As MDIMain)
        FRemoveHandler(TSMI_Var, MD)
        AddHandler TSMI_Var.Click, AddressOf MD.FMenuItem_Click
    End Sub

    Private Sub FAddTSMI(ByVal MnuStrp As MenuStrip, ByVal Index As Integer, ByVal StrUser As String, _
    ByVal StrParent As String, ByVal StrModule As String, ByVal MD As MDIMain)
        Dim ADTemp As OleDb.OleDbDataAdapter = Nothing
        Dim DTTemp As New DataTable
        Dim DTTemp1 As New DataTable
        Dim I As Integer
        Dim TSMI_Item As ToolStripMenuItem
        Dim StrTemp As String

        StrTemp = "Select * From User_Permission Where UserName='" & StrUser & "' And Parent='" & StrParent & "' And MnuModule='" & StrModule & "' And IsNull(Active,'Y')='Y'  And IsNull(Permission,'****') <> '****'  Order By SNo"
        DTTemp = AgL.FillData(StrTemp, AgL.ECompConn).Tables(0)
        For I = 0 To DTTemp.Rows.Count - 1
            Try
                StrTemp = AgL.XNull(DTTemp.Rows(I).Item("MnuText"))
                TSMI_Item = New ToolStripMenuItem(StrTemp)
                StrTemp = AgL.XNull(DTTemp.Rows(I).Item("MnuName"))
                TSMI_Item.Name = StrTemp
                TSMI_Item.Tag = AgL.XNull(DTTemp.Rows(I).Item("ReportFor"))
                TSMI_Item.ToolTipText = StrModule
                FAddHandler(TSMI_Item, MD)

                DTTemp1.Clear()
                DTTemp1 = AgL.FillData("Select * From User_Permission Where UserName='" & StrUser & "' And MnuName='" & AgL.XNull(DTTemp.Rows(I).Item("MnuName")) & "' And MnuModule='" & StrModule & "' And IsNull(Active,'Y')='Y' And IsNull(Permission,'****') <> '****'  Order By SNo", AgL.ECompConn).Tables(0)
                'If DTTemp1.Rows.Count > 0 Then
                'FAddTSMI_DropDown(TSMI_Item, StrUser, AgL.XNull(DTTemp.Rows(I).Item("MnuName")), StrModule, MD)
                'End If

                'DirectCast(MnuStrp.Items(Index), ToolStripMenuItem).DropDownItems.Add(TSMI_Item)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                TSMI_Item = Nothing
            End Try
        Next
    End Sub

    Private Sub FAddTSMI_DropDown(ByVal TSMI_Var As ToolStripMenuItem, ByVal StrUser As String, _
        ByVal StrParent As String, ByVal StrModule As String, ByVal MD As MDIMain)
        Dim TSMI_Item As ToolStripMenuItem
        Dim ADTemp As OleDb.OleDbDataAdapter = Nothing
        Dim DTTemp As New DataTable
        Dim I As Integer
        Dim StrTemp As String
        Dim DTTemp1 As New DataTable

        DTTemp = AgL.FillData("Select * From User_Permission Where UserName='" & StrUser & "' And Parent='" & StrParent & "' And MnuModule='" & StrModule & "' And IsNull(Active,'Y')='Y' And IsNull(Permission,'****') <> '****'  Order By SNo", AgL.ECompConn).Tables(0)
        For I = 0 To DTTemp.Rows.Count - 1
            Try
                StrTemp = AgL.XNull(DTTemp.Rows(I).Item("MnuText"))
                TSMI_Item = New ToolStripMenuItem(StrTemp)
                StrTemp = AgL.XNull(DTTemp.Rows(I).Item("MnuName"))
                TSMI_Item.Name = StrTemp
                TSMI_Item.Tag = AgL.XNull(DTTemp.Rows(I).Item("ReportFor"))
                TSMI_Item.ToolTipText = StrModule
                FAddHandler(TSMI_Item, MD)

                DTTemp1.Clear()
                DTTemp1 = AgL.FillData("Select * From User_Permission Where UserName='" & StrUser & "' And MnuName='" & AgL.XNull(DTTemp.Rows(I).Item("MnuName")) & "' And MnuModule='" & StrModule & "' And IsNull(Active,'Y')='Y' Order By SNo", AgL.ECompConn).Tables(0)
                If DTTemp1.Rows.Count > 0 Then
                    FAddTSMI_DropDown(TSMI_Item, StrUser, AgL.XNull(DTTemp.Rows(I).Item("MnuName")), StrModule, MD)
                End If

                TSMI_Var.DropDownItems.Add(TSMI_Item)
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            Finally
                TSMI_Item = Nothing
            End Try
        Next
    End Sub

    '======================= Remove MDI Menu ======================
    Public Sub FRemoveMenu(ByVal ObjFor As MDIMain)
        Dim Mnu As Object

        For Each Mnu In ObjFor.Controls
            If Mnu.GetType.ToString = "System.Windows.Forms.MenuStrip" Then
                'FRemoveMenu(Mnu, ObjFor)
                ObjFor.Controls.Remove(Mnu)
                'FRemoveHandler(Mnu, ObjFor)
            End If
        Next
    End Sub

    Public Sub FRemoveMenu(ByRef MnuStrp As MenuStrip, ByVal ObjFor As Object)
        Dim TSI_Main As ToolStripItem
        Dim TSMI_Main As ToolStripMenuItem

        For Each TSI_Main In MnuStrp.Items
            If TSI_Main.GetType.ToString = "System.Windows.Forms.ToolStripMenuItem" Then
                TSMI_Main = TSI_Main
                FRemoveMenu(TSMI_Main.DropDownItems, ObjFor)
            End If
        Next

    End Sub

    Public Sub FRemoveMenu(ByRef Menus As ToolStripItemCollection, ByVal ObjFor As MDIMain)
        Dim TSI_Main As ToolStripItem
        Dim TSMI_Main As ToolStripMenuItem

        For Each TSI_Main In Menus
            If TSI_Main.GetType.ToString = "System.Windows.Forms.ToolStripMenuItem" Then
                TSMI_Main = TSI_Main
                FRemoveMenu(TSMI_Main.DropDownItems, ObjFor)
            End If
            Menus.Remove(TSI_Main)
        Next
    End Sub

#End Region


    Public Function IsConnectionAvailable() As Boolean
        Try
            If My.Computer.Network.Ping("www.google.com", 1000) Then
                IsConnectionAvailable = True
            End If
        Catch
        End Try

    End Function


    Public Sub ProcUpdateInActiveMenu()
        Dim bQry$ = "", bInActiveMenuList$ = ""
        Dim bIsRoomCharges As Boolean = False
        Dim mQry As String = ""

        Dim MDI_Common_Master As New Common_Master.MDIMain
        Dim MDI_Utility As New Utility.MDIMain
        Dim MDI_Financial_Account As New AgAccounts.MDIMain
        Dim MDI_Scholar_Common As New Scholar_Common.MDIMain

        Try
            '=========================================================================================================================
            '==========< In-Active Financial Account Menu >===============================================================================
            '=========================================================================================================================
            'bInActiveMenuList = "" & AgL.Chk_Text(MDI_Financial_Account.MnuNarrationMaster.Name) & ""

            'If Not AgLibrary.ClsConstant.IsOldFaVoucherEntryActive Then
            '    bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuVoucherEntry.Name) & ""
            'End If

            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuACAjdustmentEntry.Name) & ""

            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuCmDivisionMaster.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuCmSiteMaster.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuCmCompanyMaster.Name) & ""

            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuCmCountryMaster.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuCmStateMaster.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuCmCityMaster.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuCmBankMaster.Name) & ""

            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuCmTaxPermitFormMaster.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuCmBankBranchMaster.Name) & ""

            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuAgeingAnalysisOfDebtors.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuOutstandingReportForDebtors.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuChequeClearedRegister.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Financial_Account.MnuChequeNotClearedRegister.Name) & ""

            If bInActiveMenuList.Trim <> "" Then Call ProcExecuteUpdateInActiveMenuQuery(AgLibrary.ClsConstant.Module_Financial_Accounts, bInActiveMenuList) : bInActiveMenuList = ""
            '=========================================================================================================================

            '=========================================================================================================================
            '==========< In-Active Common Master Menu >===============================================================================
            '=========================================================================================================================
            bInActiveMenuList = "" & AgL.Chk_Text(MDI_Common_Master.MnuCommonData.Name) & ""

            '** FA Transaction Menu **
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuFATransaction.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuFinancialAccountOpening.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuVoucherEntry.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuVoucherEntryAuthenticated.Name) & ""

            '** Common Master Menu **
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuDivisionMaster.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuSiteMaster.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuCityMaster.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuStateMaster.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuCountryMaster.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuBankMaster.Name) & ""

            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuFinancialAcMaster.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuTaxPermitFormMaster.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuBankBranchMaster.Name) & ""

            '** Transaction Menu **
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuTransaction.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuPaymentVoucher.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuPaymentVoucherEntry.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuPaymentVoucherEntryAuthenticated.Name) & ""

            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuReceiptVoucher.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuReceiptVoucherEntry.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuReceiptVoucherEntryAuthenticated.Name) & ""

            '** Reports Menu **
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuReports.Name) & ""

            '** Utility Menu **
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuUtility.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuVoucherPrefixMaster.Name) & ""
            bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Common_Master.MnuVoucherTypeMaster.Name) & ""

            If bInActiveMenuList.Trim <> "" Then Call ProcExecuteUpdateInActiveMenuQuery(AgLibrary.ClsConstant.Module_Common_Master, bInActiveMenuList) : bInActiveMenuList = ""
            '=========================================================================================================================

            ''=========================================================================================================================
            ''==========< In-Active Utility Menu >===============================================================================
            ''=========================================================================================================================
            ''<<<< Transaction Menu >>>>
            'bInActiveMenuList = "" & AgL.Chk_Text(MDI_Utility.MnuDataSynchronisation.Name) & ""
            ''<<<< ******************* >>>>

            ''<<<< System Control Menu >>>>
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Utility.MnuSystemControl.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Utility.MnuTableKeys.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Utility.MnuReportMaster.Name) & ""
            ''<<<< ******************* >>>>

            ''<<<< System Control Menu >>>>
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Utility.MnuDatabaseManagement.Name) & ""
            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Utility.MnuDataNotSynchronised.Name) & ""
            ''<<<< ******************* >>>>

            'If bInActiveMenuList.Trim <> "" Then Call ProcExecuteUpdateInActiveMenuQuery(ClsConstant.Module_Utility, bInActiveMenuList) : bInActiveMenuList = ""
            ''=========================================================================================================================

            '=========================================================================================================================
            '==========< In-Active Academic Common Menu >===============================================================================
            '=========================================================================================================================
            If Not AgL.PubBlnIsBankMasterActive Then
                bInActiveMenuList += IIf(bInActiveMenuList.Trim = "", "", ", ") & AgL.Chk_Text(MDI_Scholar_Common.MnuBankMaster.Name) & ""
            End If

            If Academic_ProjLib.ClsMain.IsModuleActive_FinancialAccount Then
                bInActiveMenuList += IIf(bInActiveMenuList.Trim = "", "", ", ") & AgL.Chk_Text(MDI_Scholar_Common.MnuLedgerAcMaster.Name) & ""
            End If

            If bInActiveMenuList.Trim <> "" Then Call ProcExecuteUpdateInActiveMenuQuery(Scholar_Common.ClsMain.ModuleName, bInActiveMenuList) : bInActiveMenuList = ""
            '=========================================================================================================================



            '=========================================================================================================================
            '==========< In-Active Academic Exam Menu >===============================================================================
            '=========================================================================================================================

            '=========================================================================================================================

            '=========================================================================================================================
            '==========< In-Active Academic Time Table Menu >===============================================================================
            '=========================================================================================================================
            'bInActiveMenuList = "" & AgL.Chk_Text(MDI_Academic_TimeTable.MnuUtility.Name) & ""

            'bInActiveMenuList += ", " & AgL.Chk_Text(MDI_Academic_TimeTable.MnuEnvironmentSettings.Name) & ""

            'If bInActiveMenuList.Trim <> "" Then Call ProcExecuteUpdateInActiveMenuQuery(ClsConstant.Module_Academic_TimeTable, bInActiveMenuList) : bInActiveMenuList = ""
            '=========================================================================================================================


            '=========================================================================================================================
            '==========< In-Active Academic Hostel Menu >===============================================================================
            '=========================================================================================================================

            If AgL.IsFieldExist("IsRoomCharges", "Company", AgL.GCn) Then
                mQry = "Select C.IsRoomCharges From Company C With (NoLock) Where C.Comp_Code ='" & AgL.PubCompCode & "'"
                bIsRoomCharges = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar)
            End If
            If bIsRoomCharges = False Then



            End If
            '=========================================================================================================================


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcExecuteUpdateInActiveMenuQuery(ByVal bMnuModule As String, ByVal bInActiveMenuList As String)
        Dim bQry$ = ""

        bQry = "UPDATE User_Permission SET Active = 'N' " & _
                " WHERE MnuModule = " & AgL.Chk_Text(bMnuModule) & " AND " & _
                " MnuName In (" & bInActiveMenuList & ")"
        AgL.Dman_ExecuteNonQry(bQry, AgL.ECompConn)

    End Sub
End Module