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
            If FOpenIni(StrPath + IniName, AgLibrary.ClsConstant.PubSuperUserName, AgLibrary.ClsConstant.PubSuperUserPassword) Then
                AgIniVar.FOpenConnection("1", "1", False)
            End If

            'Dim ClsObj As New ClsMain(AgL, PLib)
            'ClsObj.UpdateTableStructure()
            'ClsObj = Nothing

            Dim ClsObj As New ClsMain(AgL)
            Dim clsObjStruct As New AgStructure.ClsMain(AgL)
            Dim clsObjTemplate As New AgTemplate.ClsMain(AgL)

            'ClsObj.UpdateTableStructure(AgL.PubMdlTable)
            'clsObjStruct.UpdateTableStructure(AgL.PubMdlTable)
            'clsObjTemplate.UpdateTableStructure(AgL.PubMdlTable)
            'clsObjTemplate.UpdateTableStructurePurchase(AgL.PubMdlTable)
            'clsObjTemplate.UpdateTableStructureForm(AgL.PubMdlTable)

            'ClsObj.UpdateTableStructure(AgL.PubMdlTable)
            'clsObjStruct.UpdateTableStructure(AgL.PubMdlTable)
            'clsObjTemplate.UpdateTableStructure(AgL.PubMdlTable)

            'AgL.FExecuteDBScript(AgL.PubMdlTable, AgL.GCn)

            ClsObj.UpdateTableInitialiser()
            'clsObjStruct.UpdateTableInitialiser()
            'clsObjTemplate.UpdateTableInitialiser()

            Call IniDtEnviro()
        End If
    End Sub

    Private Sub MnuReports_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles _
    MnuReports.DropDownItemClicked
        Dim FrmObj As AgLibrary.RepFormGlobal
        Dim CFOpen As New ClsFunction

        FrmObj = CFOpen.FOpen(e.ClickedItem.Name, e.ClickedItem.Text, False)
        If FrmObj IsNot Nothing Then
            FrmObj.MdiParent = Me
            FrmObj.Show()
            FrmObj = Nothing
        End If
    End Sub


    Private Sub MnuTransactions_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles _
        MnuMasters.DropDownItemClicked, MnuTransactions.DropDownItemClicked, MnuUtility.DropDownItemClicked

        Dim FrmObj As Form
        Dim CFOpen As New ClsFunction

        FrmObj = CFOpen.FOpen(e.ClickedItem.Name, e.ClickedItem.Text)
        If FrmObj IsNot Nothing Then
            FrmObj.MdiParent = Me
            FrmObj.Show()
            FrmObj = Nothing
        End If

    End Sub

End Class
