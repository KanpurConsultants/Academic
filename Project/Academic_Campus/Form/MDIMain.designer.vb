<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuMess = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMasters = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuCapmusCompanyMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTransactions = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSessionCompanyEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPlacementEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReports = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStudentSelectedList = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSessionWiseStudentSelectedList = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCompanyWiseStudentSelectedList = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSemesterWiseStudentSelectedList = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuDateWiseStudentSelectedList = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPlacementGraphSessionWise = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUtility = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnvironmentSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuCompanyInformationRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMess})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(967, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuMess
        '
        Me.MnuMess.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMasters, Me.MnuTransactions, Me.MnuReports, Me.MnuUtility})
        Me.MnuMess.Name = "MnuMess"
        Me.MnuMess.Size = New System.Drawing.Size(57, 20)
        Me.MnuMess.Text = "Campus"
        '
        'MnuMasters
        '
        Me.MnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuCapmusCompanyMaster})
        Me.MnuMasters.Name = "MnuMasters"
        Me.MnuMasters.Size = New System.Drawing.Size(152, 22)
        Me.MnuMasters.Text = "Masters"
        '
        'MnuCapmusCompanyMaster
        '
        Me.MnuCapmusCompanyMaster.Name = "MnuCapmusCompanyMaster"
        Me.MnuCapmusCompanyMaster.Size = New System.Drawing.Size(207, 22)
        Me.MnuCapmusCompanyMaster.Text = "Campus Company Master"
        '
        'MnuTransactions
        '
        Me.MnuTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuSessionCompanyEntry, Me.mnuPlacementEntry})
        Me.MnuTransactions.Name = "MnuTransactions"
        Me.MnuTransactions.Size = New System.Drawing.Size(152, 22)
        Me.MnuTransactions.Text = "Transactions"
        '
        'mnuSessionCompanyEntry
        '
        Me.mnuSessionCompanyEntry.Name = "mnuSessionCompanyEntry"
        Me.mnuSessionCompanyEntry.Size = New System.Drawing.Size(198, 22)
        Me.mnuSessionCompanyEntry.Text = "Session Company Entry"
        '
        'mnuPlacementEntry
        '
        Me.mnuPlacementEntry.Name = "mnuPlacementEntry"
        Me.mnuPlacementEntry.Size = New System.Drawing.Size(198, 22)
        Me.mnuPlacementEntry.Text = "Placement Entry"
        '
        'MnuReports
        '
        Me.MnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuStudentSelectedList, Me.mnuSessionWiseStudentSelectedList, Me.mnuCompanyWiseStudentSelectedList, Me.mnuSemesterWiseStudentSelectedList, Me.mnuDateWiseStudentSelectedList, Me.mnuPlacementGraphSessionWise, Me.mnuCompanyInformationRegister})
        Me.MnuReports.Name = "MnuReports"
        Me.MnuReports.Size = New System.Drawing.Size(152, 22)
        Me.MnuReports.Text = "Reports"
        '
        'mnuStudentSelectedList
        '
        Me.mnuStudentSelectedList.Name = "mnuStudentSelectedList"
        Me.mnuStudentSelectedList.Size = New System.Drawing.Size(260, 22)
        Me.mnuStudentSelectedList.Tag = "Report"
        Me.mnuStudentSelectedList.Text = "Student Selected List"
        '
        'mnuSessionWiseStudentSelectedList
        '
        Me.mnuSessionWiseStudentSelectedList.Name = "mnuSessionWiseStudentSelectedList"
        Me.mnuSessionWiseStudentSelectedList.Size = New System.Drawing.Size(260, 22)
        Me.mnuSessionWiseStudentSelectedList.Tag = "Report"
        Me.mnuSessionWiseStudentSelectedList.Text = "Session Wise Student Selected List"
        '
        'mnuCompanyWiseStudentSelectedList
        '
        Me.mnuCompanyWiseStudentSelectedList.Name = "mnuCompanyWiseStudentSelectedList"
        Me.mnuCompanyWiseStudentSelectedList.Size = New System.Drawing.Size(260, 22)
        Me.mnuCompanyWiseStudentSelectedList.Tag = "Report"
        Me.mnuCompanyWiseStudentSelectedList.Text = "Company Wise Student Selected List"
        '
        'mnuSemesterWiseStudentSelectedList
        '
        Me.mnuSemesterWiseStudentSelectedList.Name = "mnuSemesterWiseStudentSelectedList"
        Me.mnuSemesterWiseStudentSelectedList.Size = New System.Drawing.Size(260, 22)
        Me.mnuSemesterWiseStudentSelectedList.Tag = "Report"
        Me.mnuSemesterWiseStudentSelectedList.Text = "Semester Wise Student Selected List"
        '
        'mnuDateWiseStudentSelectedList
        '
        Me.mnuDateWiseStudentSelectedList.Name = "mnuDateWiseStudentSelectedList"
        Me.mnuDateWiseStudentSelectedList.Size = New System.Drawing.Size(260, 22)
        Me.mnuDateWiseStudentSelectedList.Tag = "Report"
        Me.mnuDateWiseStudentSelectedList.Text = "Date Wise Student Selected List"
        '
        'mnuPlacementGraphSessionWise
        '
        Me.mnuPlacementGraphSessionWise.Name = "mnuPlacementGraphSessionWise"
        Me.mnuPlacementGraphSessionWise.Size = New System.Drawing.Size(260, 22)
        Me.mnuPlacementGraphSessionWise.Tag = "Report"
        Me.mnuPlacementGraphSessionWise.Text = "Placement Graph Session Wise"
        '
        'MnuUtility
        '
        Me.MnuUtility.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEnvironmentSettings})
        Me.MnuUtility.Name = "MnuUtility"
        Me.MnuUtility.Size = New System.Drawing.Size(152, 22)
        Me.MnuUtility.Text = "Utility"
        Me.MnuUtility.Visible = False
        '
        'MnuEnvironmentSettings
        '
        Me.MnuEnvironmentSettings.Name = "MnuEnvironmentSettings"
        Me.MnuEnvironmentSettings.Size = New System.Drawing.Size(187, 22)
        Me.MnuEnvironmentSettings.Text = "Environment Settings"
        '
        'mnuCompanyInformationRegister
        '
        Me.mnuCompanyInformationRegister.Name = "mnuCompanyInformationRegister"
        Me.mnuCompanyInformationRegister.Size = New System.Drawing.Size(260, 22)
        Me.mnuCompanyInformationRegister.Tag = "Report"
        Me.mnuCompanyInformationRegister.Text = "Company Information Register"
        '
        'MDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(967, 663)
        Me.Controls.Add(Me.MnuMain)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MnuMain
        Me.Name = "MDIMain"
        Me.Text = "Campus"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Public WithEvents MnuMess As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEnvironmentSettings As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMasters As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuTransactions As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuUtility As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuCapmusCompanyMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSessionCompanyEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlacementEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuStudentSelectedList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSessionWiseStudentSelectedList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCompanyWiseStudentSelectedList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPlacementGraphSessionWise As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSemesterWiseStudentSelectedList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuDateWiseStudentSelectedList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuCompanyInformationRegister As System.Windows.Forms.ToolStripMenuItem

End Class
