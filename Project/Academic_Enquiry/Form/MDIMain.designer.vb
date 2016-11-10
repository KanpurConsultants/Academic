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
        Me.MnuEnquiry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMasters = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuProspectusMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuGodownMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSupplierMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTransactions = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnquiryEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEnquiryAssignEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnquiryFollowup = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnquiryFollowupReminder = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuProspectusPurchase = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuProspectusSale = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuProspectusStockAdjustment = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnquiryReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnquiryFollowupReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnquiryCloseRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuProspectusPurchaseRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuProspectusSaleRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUtility = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnvironmentSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuProspectusStockRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEnquiry})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(967, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuEnquiry
        '
        Me.MnuEnquiry.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMasters, Me.MnuTransactions, Me.MnuReports, Me.MnuUtility})
        Me.MnuEnquiry.Name = "MnuEnquiry"
        Me.MnuEnquiry.Size = New System.Drawing.Size(55, 20)
        Me.MnuEnquiry.Text = "Enquiry"
        '
        'MnuMasters
        '
        Me.MnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuProspectusMaster, Me.MnuGodownMaster, Me.MnuSupplierMaster})
        Me.MnuMasters.Name = "MnuMasters"
        Me.MnuMasters.Size = New System.Drawing.Size(152, 22)
        Me.MnuMasters.Text = "Masters"
        '
        'mnuProspectusMaster
        '
        Me.mnuProspectusMaster.Name = "mnuProspectusMaster"
        Me.mnuProspectusMaster.Size = New System.Drawing.Size(174, 22)
        Me.mnuProspectusMaster.Text = "Prospectus Master"
        '
        'MnuGodownMaster
        '
        Me.MnuGodownMaster.Name = "MnuGodownMaster"
        Me.MnuGodownMaster.Size = New System.Drawing.Size(174, 22)
        Me.MnuGodownMaster.Text = "Godown Master"
        '
        'MnuSupplierMaster
        '
        Me.MnuSupplierMaster.Name = "MnuSupplierMaster"
        Me.MnuSupplierMaster.Size = New System.Drawing.Size(174, 22)
        Me.MnuSupplierMaster.Text = "Supplier Master"
        '
        'MnuTransactions
        '
        Me.MnuTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEnquiryEntry, Me.mnuEnquiryAssignEntry, Me.MnuEnquiryFollowup, Me.MnuEnquiryFollowupReminder, Me.mnuProspectusPurchase, Me.mnuProspectusSale, Me.mnuProspectusStockAdjustment})
        Me.MnuTransactions.Name = "MnuTransactions"
        Me.MnuTransactions.Size = New System.Drawing.Size(152, 22)
        Me.MnuTransactions.Text = "Transactions"
        '
        'MnuEnquiryEntry
        '
        Me.MnuEnquiryEntry.Name = "MnuEnquiryEntry"
        Me.MnuEnquiryEntry.Size = New System.Drawing.Size(225, 22)
        Me.MnuEnquiryEntry.Text = "Enquiry Entry"
        '
        'mnuEnquiryAssignEntry
        '
        Me.mnuEnquiryAssignEntry.Name = "mnuEnquiryAssignEntry"
        Me.mnuEnquiryAssignEntry.Size = New System.Drawing.Size(225, 22)
        Me.mnuEnquiryAssignEntry.Text = "Enquiry Assign Entry"
        '
        'MnuEnquiryFollowup
        '
        Me.MnuEnquiryFollowup.Name = "MnuEnquiryFollowup"
        Me.MnuEnquiryFollowup.Size = New System.Drawing.Size(225, 22)
        Me.MnuEnquiryFollowup.Text = "Enquiry Followup"
        '
        'MnuEnquiryFollowupReminder
        '
        Me.MnuEnquiryFollowupReminder.Name = "MnuEnquiryFollowupReminder"
        Me.MnuEnquiryFollowupReminder.Size = New System.Drawing.Size(225, 22)
        Me.MnuEnquiryFollowupReminder.Text = "Enquiry Followup Reminder"
        '
        'mnuProspectusPurchase
        '
        Me.mnuProspectusPurchase.Name = "mnuProspectusPurchase"
        Me.mnuProspectusPurchase.Size = New System.Drawing.Size(225, 22)
        Me.mnuProspectusPurchase.Text = "Prospectus Purchase"
        '
        'mnuProspectusSale
        '
        Me.mnuProspectusSale.Name = "mnuProspectusSale"
        Me.mnuProspectusSale.Size = New System.Drawing.Size(225, 22)
        Me.mnuProspectusSale.Text = "Prospectus Sale"
        '
        'mnuProspectusStockAdjustment
        '
        Me.mnuProspectusStockAdjustment.Name = "mnuProspectusStockAdjustment"
        Me.mnuProspectusStockAdjustment.Size = New System.Drawing.Size(225, 22)
        Me.mnuProspectusStockAdjustment.Text = "Prospectus Stock Adjustment"
        '
        'MnuReports
        '
        Me.MnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEnquiryReport, Me.MnuEnquiryFollowupReport, Me.MnuEnquiryCloseRegister, Me.mnuProspectusPurchaseRegister, Me.mnuProspectusSaleRegister, Me.mnuProspectusStockRegister})
        Me.MnuReports.Name = "MnuReports"
        Me.MnuReports.Size = New System.Drawing.Size(152, 22)
        Me.MnuReports.Text = "Reports"
        '
        'MnuEnquiryReport
        '
        Me.MnuEnquiryReport.Name = "MnuEnquiryReport"
        Me.MnuEnquiryReport.Size = New System.Drawing.Size(228, 22)
        Me.MnuEnquiryReport.Tag = "Report"
        Me.MnuEnquiryReport.Text = "Enquiry Report"
        '
        'MnuEnquiryFollowupReport
        '
        Me.MnuEnquiryFollowupReport.Name = "MnuEnquiryFollowupReport"
        Me.MnuEnquiryFollowupReport.Size = New System.Drawing.Size(228, 22)
        Me.MnuEnquiryFollowupReport.Tag = "Report"
        Me.MnuEnquiryFollowupReport.Text = "Enquiry Followup Report"
        '
        'MnuEnquiryCloseRegister
        '
        Me.MnuEnquiryCloseRegister.Name = "MnuEnquiryCloseRegister"
        Me.MnuEnquiryCloseRegister.Size = New System.Drawing.Size(228, 22)
        Me.MnuEnquiryCloseRegister.Tag = "report"
        Me.MnuEnquiryCloseRegister.Text = "Enquiry Close Register"
        '
        'mnuProspectusPurchaseRegister
        '
        Me.mnuProspectusPurchaseRegister.Name = "mnuProspectusPurchaseRegister"
        Me.mnuProspectusPurchaseRegister.Size = New System.Drawing.Size(228, 22)
        Me.mnuProspectusPurchaseRegister.Tag = "Report"
        Me.mnuProspectusPurchaseRegister.Text = "Prospectus Purchase Register"
        '
        'mnuProspectusSaleRegister
        '
        Me.mnuProspectusSaleRegister.Name = "mnuProspectusSaleRegister"
        Me.mnuProspectusSaleRegister.Size = New System.Drawing.Size(228, 22)
        Me.mnuProspectusSaleRegister.Tag = "Report"
        Me.mnuProspectusSaleRegister.Text = "Prospectus Sale Register"
        '
        'MnuUtility
        '
        Me.MnuUtility.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEnvironmentSettings})
        Me.MnuUtility.Name = "MnuUtility"
        Me.MnuUtility.Size = New System.Drawing.Size(152, 22)
        Me.MnuUtility.Text = "Utility"
        '
        'MnuEnvironmentSettings
        '
        Me.MnuEnvironmentSettings.Name = "MnuEnvironmentSettings"
        Me.MnuEnvironmentSettings.Size = New System.Drawing.Size(187, 22)
        Me.MnuEnvironmentSettings.Text = "Environment Settings"
        '
        'mnuProspectusStockRegister
        '
        Me.mnuProspectusStockRegister.Name = "mnuProspectusStockRegister"
        Me.mnuProspectusStockRegister.Size = New System.Drawing.Size(228, 22)
        Me.mnuProspectusStockRegister.Tag = "Report"
        Me.mnuProspectusStockRegister.Text = "Prospectus Stock Register"
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
        Me.Text = "Enquiry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Public WithEvents MnuEnquiry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuTransactions As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuReports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuEnquiryFollowupReminder As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuEnquiryEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuEnquiryFollowup As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuEnquiryReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuEnquiryFollowupReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEnquiryAssignEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEnquiryCloseRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMasters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProspectusMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProspectusPurchase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGodownMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUtility As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEnvironmentSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSupplierMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProspectusSale As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProspectusPurchaseRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProspectusSaleRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProspectusStockAdjustment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuProspectusStockRegister As System.Windows.Forms.ToolStripMenuItem

End Class
