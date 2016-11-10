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
        Me.MnuRugUtility = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUserMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUserLoginPasswardChange = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuStructureMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuHeadMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStructurePostingHead = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTransaction = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUserPermission = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUserControlPermission = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUserTarget = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSitePermission = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUserWiseEntryReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUserWiseEntryTargetReport = New System.Windows.Forms.ToolStripMenuItem
        Me.UserWiseEntryActionReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuBackupDatabase = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuRugUtility})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(965, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuRugUtility
        '
        Me.MnuRugUtility.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMaster, Me.MnuTransaction, Me.MnuReports, Me.MnuBackupDatabase})
        Me.MnuRugUtility.Name = "MnuRugUtility"
        Me.MnuRugUtility.Size = New System.Drawing.Size(46, 20)
        Me.MnuRugUtility.Text = "Utility"
        '
        'MnuMaster
        '
        Me.MnuMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuUserMaster, Me.MnuUserLoginPasswardChange, Me.mnuStructureMaster, Me.mnuHeadMaster, Me.MnuStructurePostingHead})
        Me.MnuMaster.Name = "MnuMaster"
        Me.MnuMaster.Size = New System.Drawing.Size(168, 22)
        Me.MnuMaster.Text = "Master"
        '
        'MnuUserMaster
        '
        Me.MnuUserMaster.Name = "MnuUserMaster"
        Me.MnuUserMaster.Size = New System.Drawing.Size(224, 22)
        Me.MnuUserMaster.Text = "User Master"
        '
        'MnuUserLoginPasswardChange
        '
        Me.MnuUserLoginPasswardChange.Name = "MnuUserLoginPasswardChange"
        Me.MnuUserLoginPasswardChange.Size = New System.Drawing.Size(224, 22)
        Me.MnuUserLoginPasswardChange.Text = "User Login Password Change"
        '
        'mnuStructureMaster
        '
        Me.mnuStructureMaster.Name = "mnuStructureMaster"
        Me.mnuStructureMaster.Size = New System.Drawing.Size(224, 22)
        Me.mnuStructureMaster.Text = "Structure Master"
        '
        'mnuHeadMaster
        '
        Me.mnuHeadMaster.Name = "mnuHeadMaster"
        Me.mnuHeadMaster.Size = New System.Drawing.Size(224, 22)
        Me.mnuHeadMaster.Text = "Head Master"
        '
        'MnuStructurePostingHead
        '
        Me.MnuStructurePostingHead.Name = "MnuStructurePostingHead"
        Me.MnuStructurePostingHead.Size = New System.Drawing.Size(224, 22)
        Me.MnuStructurePostingHead.Text = "Structure Posting Head"
        '
        'MnuTransaction
        '
        Me.MnuTransaction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuUserPermission, Me.MnuUserControlPermission, Me.MnuUserTarget, Me.MnuSitePermission})
        Me.MnuTransaction.Name = "MnuTransaction"
        Me.MnuTransaction.Size = New System.Drawing.Size(168, 22)
        Me.MnuTransaction.Text = "Transaction"
        '
        'MnuUserPermission
        '
        Me.MnuUserPermission.Name = "MnuUserPermission"
        Me.MnuUserPermission.Size = New System.Drawing.Size(198, 22)
        Me.MnuUserPermission.Text = "User Permission"
        '
        'MnuUserControlPermission
        '
        Me.MnuUserControlPermission.Name = "MnuUserControlPermission"
        Me.MnuUserControlPermission.Size = New System.Drawing.Size(198, 22)
        Me.MnuUserControlPermission.Text = "User Control Permission"
        '
        'MnuUserTarget
        '
        Me.MnuUserTarget.Name = "MnuUserTarget"
        Me.MnuUserTarget.Size = New System.Drawing.Size(198, 22)
        Me.MnuUserTarget.Text = "User Target"
        '
        'MnuSitePermission
        '
        Me.MnuSitePermission.Name = "MnuSitePermission"
        Me.MnuSitePermission.Size = New System.Drawing.Size(198, 22)
        Me.MnuSitePermission.Text = "Site Permission"
        '
        'MnuReports
        '
        Me.MnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuUserWiseEntryReport, Me.MnuUserWiseEntryTargetReport, Me.UserWiseEntryActionReport})
        Me.MnuReports.Name = "MnuReports"
        Me.MnuReports.Size = New System.Drawing.Size(168, 22)
        Me.MnuReports.Text = "Reports"
        '
        'MnuUserWiseEntryReport
        '
        Me.MnuUserWiseEntryReport.Name = "MnuUserWiseEntryReport"
        Me.MnuUserWiseEntryReport.Size = New System.Drawing.Size(233, 22)
        Me.MnuUserWiseEntryReport.Tag = "UTILITY"
        Me.MnuUserWiseEntryReport.Text = "User Wise Entry Report"
        '
        'MnuUserWiseEntryTargetReport
        '
        Me.MnuUserWiseEntryTargetReport.Name = "MnuUserWiseEntryTargetReport"
        Me.MnuUserWiseEntryTargetReport.Size = New System.Drawing.Size(233, 22)
        Me.MnuUserWiseEntryTargetReport.Tag = "UTILITY"
        Me.MnuUserWiseEntryTargetReport.Text = "User Wise Entry Target Report"
        '
        'UserWiseEntryActionReport
        '
        Me.UserWiseEntryActionReport.Name = "UserWiseEntryActionReport"
        Me.UserWiseEntryActionReport.Size = New System.Drawing.Size(233, 22)
        Me.UserWiseEntryActionReport.Tag = "Report"
        Me.UserWiseEntryActionReport.Text = "User Wise Entry Action Report"
        '
        'MnuBackupDatabase
        '
        Me.MnuBackupDatabase.Name = "MnuBackupDatabase"
        Me.MnuBackupDatabase.Size = New System.Drawing.Size(168, 22)
        Me.MnuBackupDatabase.Text = "Backup Database"
        '
        'MDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(965, 661)
        Me.Controls.Add(Me.MnuMain)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MnuMain
        Me.Name = "MDIMain"
        Me.Text = "Academic Utility"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuRugUtility As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuUserMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuTransaction As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuUserPermission As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuUserControlPermission As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuUserTarget As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuSitePermission As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUserWiseEntryReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUserWiseEntryTargetReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuBackupDatabase As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuStructurePostingHead As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuUserLoginPasswardChange As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuStructureMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents mnuHeadMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserWiseEntryActionReport As System.Windows.Forms.ToolStripMenuItem

End Class
