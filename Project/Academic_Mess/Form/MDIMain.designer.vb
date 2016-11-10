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
        Me.MnuUnitMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemGroupMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemCategory = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuGodownMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSupplierMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemBOMMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMemberMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTransactions = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchaseEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchaseReturnEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMessMenuCreateEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMemberLeaveEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAttendanceEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExtraPersonEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMessConsumptionEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStockAdjustmentEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchaseRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchaseReturnRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStockRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMessMenu = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUtility = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnvironmentSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuMessAttendanceRegister = New System.Windows.Forms.ToolStripMenuItem
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
        Me.MnuMess.Size = New System.Drawing.Size(43, 20)
        Me.MnuMess.Text = "Mess"
        '
        'MnuMasters
        '
        Me.MnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuUnitMaster, Me.MnuItemGroupMaster, Me.MnuItemCategory, Me.MnuItemMaster, Me.MnuGodownMaster, Me.MnuSupplierMaster, Me.MnuItemBOMMaster, Me.MnuMemberMaster})
        Me.MnuMasters.Name = "MnuMasters"
        Me.MnuMasters.Size = New System.Drawing.Size(152, 22)
        Me.MnuMasters.Text = "Masters"
        '
        'MnuUnitMaster
        '
        Me.MnuUnitMaster.Name = "MnuUnitMaster"
        Me.MnuUnitMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuUnitMaster.Text = "Unit Master"
        '
        'MnuItemGroupMaster
        '
        Me.MnuItemGroupMaster.Name = "MnuItemGroupMaster"
        Me.MnuItemGroupMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuItemGroupMaster.Text = "Item Group Master"
        '
        'MnuItemCategory
        '
        Me.MnuItemCategory.Name = "MnuItemCategory"
        Me.MnuItemCategory.Size = New System.Drawing.Size(191, 22)
        Me.MnuItemCategory.Text = "Item Category Master"
        '
        'MnuItemMaster
        '
        Me.MnuItemMaster.Name = "MnuItemMaster"
        Me.MnuItemMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuItemMaster.Text = "Item Master"
        '
        'MnuGodownMaster
        '
        Me.MnuGodownMaster.Name = "MnuGodownMaster"
        Me.MnuGodownMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuGodownMaster.Text = "Godown Master"
        '
        'MnuSupplierMaster
        '
        Me.MnuSupplierMaster.Name = "MnuSupplierMaster"
        Me.MnuSupplierMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuSupplierMaster.Text = "Supplier Master"
        '
        'MnuItemBOMMaster
        '
        Me.MnuItemBOMMaster.Name = "MnuItemBOMMaster"
        Me.MnuItemBOMMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuItemBOMMaster.Text = "Item BOM Master"
        '
        'MnuMemberMaster
        '
        Me.MnuMemberMaster.Name = "MnuMemberMaster"
        Me.MnuMemberMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuMemberMaster.Text = "Member Master"
        '
        'MnuTransactions
        '
        Me.MnuTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuPurchaseEntry, Me.MnuPurchaseReturnEntry, Me.MnuMessMenuCreateEntry, Me.MnuMemberLeaveEntry, Me.MnuAttendanceEntry, Me.MnuExtraPersonEntry, Me.MnuMessConsumptionEntry, Me.MnuStockAdjustmentEntry})
        Me.MnuTransactions.Name = "MnuTransactions"
        Me.MnuTransactions.Size = New System.Drawing.Size(152, 22)
        Me.MnuTransactions.Text = "Transactions"
        '
        'MnuPurchaseEntry
        '
        Me.MnuPurchaseEntry.Name = "MnuPurchaseEntry"
        Me.MnuPurchaseEntry.Size = New System.Drawing.Size(203, 22)
        Me.MnuPurchaseEntry.Text = "Purchase Entry"
        '
        'MnuPurchaseReturnEntry
        '
        Me.MnuPurchaseReturnEntry.Name = "MnuPurchaseReturnEntry"
        Me.MnuPurchaseReturnEntry.Size = New System.Drawing.Size(203, 22)
        Me.MnuPurchaseReturnEntry.Text = "Purchase Return Entry"
        '
        'MnuMessMenuCreateEntry
        '
        Me.MnuMessMenuCreateEntry.Name = "MnuMessMenuCreateEntry"
        Me.MnuMessMenuCreateEntry.Size = New System.Drawing.Size(203, 22)
        Me.MnuMessMenuCreateEntry.Text = "Mess Menu Create Entry"
        '
        'MnuMemberLeaveEntry
        '
        Me.MnuMemberLeaveEntry.Name = "MnuMemberLeaveEntry"
        Me.MnuMemberLeaveEntry.Size = New System.Drawing.Size(203, 22)
        Me.MnuMemberLeaveEntry.Text = "Member Leave Entry"
        '
        'MnuAttendanceEntry
        '
        Me.MnuAttendanceEntry.Name = "MnuAttendanceEntry"
        Me.MnuAttendanceEntry.Size = New System.Drawing.Size(203, 22)
        Me.MnuAttendanceEntry.Text = "Attendance Entry"
        '
        'MnuExtraPersonEntry
        '
        Me.MnuExtraPersonEntry.Name = "MnuExtraPersonEntry"
        Me.MnuExtraPersonEntry.Size = New System.Drawing.Size(203, 22)
        Me.MnuExtraPersonEntry.Text = "Extra Person Entry"
        '
        'MnuMessConsumptionEntry
        '
        Me.MnuMessConsumptionEntry.Name = "MnuMessConsumptionEntry"
        Me.MnuMessConsumptionEntry.Size = New System.Drawing.Size(203, 22)
        Me.MnuMessConsumptionEntry.Text = "Mess Consumption Entry"
        '
        'MnuStockAdjustmentEntry
        '
        Me.MnuStockAdjustmentEntry.Name = "MnuStockAdjustmentEntry"
        Me.MnuStockAdjustmentEntry.Size = New System.Drawing.Size(203, 22)
        Me.MnuStockAdjustmentEntry.Text = "Stock Adjustment Entry"
        '
        'MnuReports
        '
        Me.MnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuPurchaseRegister, Me.MnuPurchaseReturnRegister, Me.MnuStockRegister, Me.MnuMessMenu, Me.mnuMessAttendanceRegister})
        Me.MnuReports.Name = "MnuReports"
        Me.MnuReports.Size = New System.Drawing.Size(152, 22)
        Me.MnuReports.Text = "Reports"
        '
        'MnuPurchaseRegister
        '
        Me.MnuPurchaseRegister.Name = "MnuPurchaseRegister"
        Me.MnuPurchaseRegister.Size = New System.Drawing.Size(211, 22)
        Me.MnuPurchaseRegister.Tag = "Report"
        Me.MnuPurchaseRegister.Text = "Purchase Register"
        '
        'MnuPurchaseReturnRegister
        '
        Me.MnuPurchaseReturnRegister.Name = "MnuPurchaseReturnRegister"
        Me.MnuPurchaseReturnRegister.Size = New System.Drawing.Size(211, 22)
        Me.MnuPurchaseReturnRegister.Tag = "Report"
        Me.MnuPurchaseReturnRegister.Text = "Purchase Return Register"
        '
        'MnuStockRegister
        '
        Me.MnuStockRegister.Name = "MnuStockRegister"
        Me.MnuStockRegister.Size = New System.Drawing.Size(211, 22)
        Me.MnuStockRegister.Tag = "Reports"
        Me.MnuStockRegister.Text = "Stock Register"
        '
        'MnuMessMenu
        '
        Me.MnuMessMenu.Name = "MnuMessMenu"
        Me.MnuMessMenu.Size = New System.Drawing.Size(211, 22)
        Me.MnuMessMenu.Tag = "Reports"
        Me.MnuMessMenu.Text = "Mess Menu"
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
        'mnuMessAttendanceRegister
        '
        Me.mnuMessAttendanceRegister.Name = "mnuMessAttendanceRegister"
        Me.mnuMessAttendanceRegister.Size = New System.Drawing.Size(211, 22)
        Me.mnuMessAttendanceRegister.Tag = "Report"
        Me.mnuMessAttendanceRegister.Text = "Mess Attendance Register"
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
        Me.Text = "Mess"
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
    Public WithEvents MnuReports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuUtility As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuItemMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuUnitMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuItemGroupMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuItemCategory As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuGodownMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuPurchaseEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuPurchaseReturnEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuSupplierMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMessMenuCreateEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuItemBOMMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMemberMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMemberLeaveEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAttendanceEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuExtraPersonEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMessConsumptionEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuStockAdjustmentEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuPurchaseRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuPurchaseReturnRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStockRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMessMenu As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuMessAttendanceRegister As System.Windows.Forms.ToolStripMenuItem

End Class
