Public Class MDI_Lib
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
                'If FOpenIni(StrPath + IniName, "SA", "") Then
                AgIniVar.FOpenConnection("1", "1", False)
            End If



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
            'clsObjTemplate.UpdateTableStructurePurchase(AgL.PubMdlTable)
            'clsObjTemplate.UpdateTableStructureFA(AgL.PubMdlTable)

            'AgL.FExecuteDBScript(AgL.PubMdlTable, AgL.GCn)

            ClsObj.UpdateTableInitialiser()
            'clsObjStruct.UpdateTableInitialiser()
            'clsObjTemplate.UpdateTableInitialiser()


            ClsMain.ProcFillSearchDataSet()
            Dim FrmObj As Form
            FrmObj = New FrmSearchPanel()
            FrmObj.MdiParent = Me
            FrmObj.Show()
        End If
    End Sub

    Private Sub Mnu_DropDownItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MnuMaster.DropDownItemClicked, _
                                                                            MnuBookPurchase.DropDownItemClicked, _
                                                                            MnuReportsPurchase.DropDownItemClicked, _
                                                                            MnuBookIssue.DropDownItemClicked, _
                                                                            MnuReportsBookIssue.DropDownItemClicked, _
                                                                            MnuStationaryPurchase.DropDownItemClicked, _
                                                                            MnuReportsStationaryPurchase.DropDownItemClicked, _
                                                                            MnuScrapSales.DropDownItemClicked, _
                                                                            MnuReportsScrapSales.DropDownItemClicked, _
                                                                            MnuDonatedBooks.DropDownItemClicked, _
                                                                            MnuReportsDonatedBooks.DropDownItemClicked, _
                                                                            MnuGeneralsPeriodicals.DropDownItemClicked, _
                                                                            MnuReportsGenerals.DropDownItemClicked, _
                                                                            MnuSearchPanel.DropDownItemClicked, _
                                                                            MnuMasterReports.DropDownItemClicked, _
                                                                            MnuBinding.DropDownItemClicked, _
                                                                            MnuBindingReports.DropDownItemClicked, _
                                                                            MnuMemberVisit.DropDownItemClicked




        Dim FrmObj As Form
        Dim CFOpen As New ClsFunction
        Dim bIsEntryPoint As Boolean

        If e.ClickedItem.Tag Is Nothing Then e.ClickedItem.Tag = ""
        If e.ClickedItem.Tag.Trim = "" Then
            bIsEntryPoint = True
        Else
            bIsEntryPoint = False
        End If

        FrmObj = CFOpen.FOpen_Lib(e.ClickedItem.Name, e.ClickedItem.Text, bIsEntryPoint)
        If FrmObj IsNot Nothing Then
            FrmObj.MdiParent = Me
            FrmObj.Show()
            FrmObj = Nothing
        End If
    End Sub

    Private Sub MnuSearchPanel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MnuSearchPanel.Click
        Dim FrmObj As Form
        Dim CFOpen As New ClsFunction

        FrmObj = CFOpen.FOpen_Lib(MnuSearchPanel.Name, MnuSearchPanel.Text, True)
        If FrmObj IsNot Nothing Then
            FrmObj.MdiParent = Me

            FrmObj.Show()
            FrmObj = Nothing
        End If
    End Sub

End Class
