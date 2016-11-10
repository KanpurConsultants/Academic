Public Class MDIMain
    Private Sub MDIMain_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Dim mCount As Integer = 0
        If e.KeyCode = Keys.Escape Then
            For Each ChildForm As Form In Me.MdiChildren
                mCount = mCount + 1
            Next

            If mCount = 0 Then
                If MsgBox("Do You Want to Exit?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                    'End
                End If
            End If
        End If
    End Sub

    Private Sub MDIMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If AgL Is Nothing Then
            'If FOpenIni(StrPath + IniName, AgLibrary.ClsConstant.PubSuperUserName, AgLibrary.ClsConstant.PubSuperUserPassword) Then
            If FOpenIni(StrPath + IniName, "SA", "") Then
                AgIniVar.FOpenConnection("1", "1", False)
            End If

            'Dim ClsObj As New ClsMain(AgL)
            'ClsObj.UpdateTableInitialiser()
            'ClsObj.UpdateTableStructure(AgL.PubMdlTable)
            'AgL.FExecuteDBScript(AgL.PubMdlTable)
            'ClsObj = Nothing

            'Dim ClsObj As New ClsMain(AgL)
            'ClsObj.UpdateTableStructure(AgL.PubMdlTable)
            'AgL.FExecuteDBScript(AgL.PubMdlTable)
            'ClsObj.UpdateTableInitialiser()
            'ClsObj = Nothing

            Call IniDtEnviro()
        End If
    End Sub

    Private Sub MnuProductionPlanningMaster_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) _
                                                                Handles MnuProductionPlanningMaster.DropDownItemClicked, _
                                                                MnuReports.DropDownItemClicked, _
                                                                MnuProdPlanningMasterMain.DropDownItemClicked, _
                                                                MnuProdPlanReportsMain.DropDownItemClicked, _
                                                                MnuSalesTransactionsLog.DropDownItemClicked, _
                                                                MnuSalesTransactionsMain.DropDownItemClicked, _
                                                                MnuProductionTransactionsLog.DropDownItemClicked, _
                                                                MnuProductionTransactionsMain.DropDownItemClicked, _
                                                                MnuInventoryTransactionsLog.DropDownItemClicked, _
                                                                MnuInventoryTransactionsMain.DropDownItemClicked, _
                                                                MnuInventoryMasterLog.DropDownItemClicked, _
                                                                MnuInventoryMasterMain.DropDownItemClicked, _
                                                                MnuReportsMain.DropDownItemClicked, _
                                                                MnuProductionReportsLog.DropDownItemClicked, _
                                                                MnuProductionReportsMain.DropDownItemClicked, _
                                                                MnuSalesReportsLog.DropDownItemClicked, _
                                                                MnuSalesReportsMain.DropDownItemClicked





        Dim FrmObj As Form
        Dim CFOpen As New ClsFunction
        Dim bIsEntryPoint As Boolean

        If e.ClickedItem.Tag Is Nothing Then e.ClickedItem.Tag = ""
        If e.ClickedItem.Tag.Trim = "" Then
            bIsEntryPoint = True
        Else
            bIsEntryPoint = False
        End If

        FrmObj = CFOpen.FOpen(e.ClickedItem.Name, e.ClickedItem.Text, bIsEntryPoint)
        If FrmObj IsNot Nothing Then
            FrmObj.MdiParent = Me
            FrmObj.Show()
            FrmObj = Nothing
        End If
    End Sub

    Private Sub MnuQualityMasterLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuQualityMasterLog.Click

    End Sub

    Private Sub MnuProductionPlanningMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuProductionPlanningMaster.Click

    End Sub

    Private Sub MnuReports_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MnuReports.Click

    End Sub

    Private Sub InventoryManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryManagementToolStripMenuItem.Click

    End Sub
End Class
