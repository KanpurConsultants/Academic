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
        Me.MnuStore = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMasters = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemCategoryMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemGroup = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUnitMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuGodownMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSupplier = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTransaction = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRequisition = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPurchaseIndentEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPurchaseOrder = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuGRNEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchaseEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchaseEntryAuthenticated = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSaleEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSaleEntryAuthenticated = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuOpeningStockEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemIssueEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemReceiveEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReports = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRequisitionRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPurchaseIndentRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPurchaseOrderRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuGRNRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSaleRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSaleSummary = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchaseRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchaseSummary = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStockRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStockSummary = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuIssueRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFixedAssetsRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUtility = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnvironmentSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuVehicleGateEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuStore})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(967, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuStore
        '
        Me.MnuStore.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMasters, Me.MnuTransaction, Me.MnuReports, Me.MnuUtility})
        Me.MnuStore.Name = "MnuStore"
        Me.MnuStore.Size = New System.Drawing.Size(45, 20)
        Me.MnuStore.Text = "Store"
        '
        'MnuMasters
        '
        Me.MnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuItemCategoryMaster, Me.MnuItemGroup, Me.MnuUnitMaster, Me.MnuItem, Me.MnuGodownMaster, Me.mnuSupplier})
        Me.MnuMasters.Name = "MnuMasters"
        Me.MnuMasters.Size = New System.Drawing.Size(152, 22)
        Me.MnuMasters.Text = "Masters"
        '
        'MnuItemCategoryMaster
        '
        Me.MnuItemCategoryMaster.Name = "MnuItemCategoryMaster"
        Me.MnuItemCategoryMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuItemCategoryMaster.Text = "Item Category Master"
        '
        'MnuItemGroup
        '
        Me.MnuItemGroup.Name = "MnuItemGroup"
        Me.MnuItemGroup.Size = New System.Drawing.Size(191, 22)
        Me.MnuItemGroup.Text = "Item Group Master"
        '
        'MnuUnitMaster
        '
        Me.MnuUnitMaster.Name = "MnuUnitMaster"
        Me.MnuUnitMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuUnitMaster.Text = "Unit Master"
        '
        'MnuItem
        '
        Me.MnuItem.Name = "MnuItem"
        Me.MnuItem.Size = New System.Drawing.Size(191, 22)
        Me.MnuItem.Text = "Item Master"
        '
        'MnuGodownMaster
        '
        Me.MnuGodownMaster.Name = "MnuGodownMaster"
        Me.MnuGodownMaster.Size = New System.Drawing.Size(191, 22)
        Me.MnuGodownMaster.Text = "Godown Master"
        '
        'mnuSupplier
        '
        Me.mnuSupplier.Name = "mnuSupplier"
        Me.mnuSupplier.Size = New System.Drawing.Size(191, 22)
        Me.mnuSupplier.Text = "Supplier Master"
        '
        'MnuTransaction
        '
        Me.MnuTransaction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRequisition, Me.mnuPurchaseIndentEntry, Me.mnuPurchaseOrder, Me.MnuVehicleGateEntry, Me.MnuGRNEntry, Me.MnuPurchaseEntry, Me.MnuPurchaseEntryAuthenticated, Me.MnuSaleEntry, Me.MnuSaleEntryAuthenticated, Me.MnuOpeningStockEntry, Me.MnuItemIssueEntry, Me.MnuItemReceiveEntry})
        Me.MnuTransaction.Name = "MnuTransaction"
        Me.MnuTransaction.Size = New System.Drawing.Size(152, 22)
        Me.MnuTransaction.Text = "Transaction"
        '
        'mnuRequisition
        '
        Me.mnuRequisition.Name = "mnuRequisition"
        Me.mnuRequisition.Size = New System.Drawing.Size(239, 22)
        Me.mnuRequisition.Text = "Requisition Entry"
        '
        'mnuPurchaseIndentEntry
        '
        Me.mnuPurchaseIndentEntry.Name = "mnuPurchaseIndentEntry"
        Me.mnuPurchaseIndentEntry.Size = New System.Drawing.Size(239, 22)
        Me.mnuPurchaseIndentEntry.Text = "Purchase Indent Entry"
        '
        'mnuPurchaseOrder
        '
        Me.mnuPurchaseOrder.Name = "mnuPurchaseOrder"
        Me.mnuPurchaseOrder.Size = New System.Drawing.Size(239, 22)
        Me.mnuPurchaseOrder.Text = "Purchse Order Entry"
        '
        'MnuGRNEntry
        '
        Me.MnuGRNEntry.Name = "MnuGRNEntry"
        Me.MnuGRNEntry.Size = New System.Drawing.Size(239, 22)
        Me.MnuGRNEntry.Text = "GRN Entry"
        '
        'MnuPurchaseEntry
        '
        Me.MnuPurchaseEntry.AccessibleDescription = "Approved By "
        Me.MnuPurchaseEntry.Name = "MnuPurchaseEntry"
        Me.MnuPurchaseEntry.Size = New System.Drawing.Size(239, 22)
        Me.MnuPurchaseEntry.Text = "Purchase Entry"
        '
        'MnuPurchaseEntryAuthenticated
        '
        Me.MnuPurchaseEntryAuthenticated.AccessibleDescription = "ZZZZZ"
        Me.MnuPurchaseEntryAuthenticated.Name = "MnuPurchaseEntryAuthenticated"
        Me.MnuPurchaseEntryAuthenticated.Size = New System.Drawing.Size(239, 22)
        Me.MnuPurchaseEntryAuthenticated.Text = "Purchase Entry {Authenticated}"
        '
        'MnuSaleEntry
        '
        Me.MnuSaleEntry.AccessibleDescription = "Approved By "
        Me.MnuSaleEntry.Name = "MnuSaleEntry"
        Me.MnuSaleEntry.Size = New System.Drawing.Size(239, 22)
        Me.MnuSaleEntry.Text = "Sale Entry"
        '
        'MnuSaleEntryAuthenticated
        '
        Me.MnuSaleEntryAuthenticated.AccessibleDescription = "ZZZZZ"
        Me.MnuSaleEntryAuthenticated.Name = "MnuSaleEntryAuthenticated"
        Me.MnuSaleEntryAuthenticated.Size = New System.Drawing.Size(239, 22)
        Me.MnuSaleEntryAuthenticated.Text = "Sale Entry {Authenticated}"
        '
        'MnuOpeningStockEntry
        '
        Me.MnuOpeningStockEntry.Name = "MnuOpeningStockEntry"
        Me.MnuOpeningStockEntry.Size = New System.Drawing.Size(239, 22)
        Me.MnuOpeningStockEntry.Text = "Opening Stock Entry"
        '
        'MnuItemIssueEntry
        '
        Me.MnuItemIssueEntry.Name = "MnuItemIssueEntry"
        Me.MnuItemIssueEntry.Size = New System.Drawing.Size(239, 22)
        Me.MnuItemIssueEntry.Text = "Item Issue Entry"
        '
        'MnuItemReceiveEntry
        '
        Me.MnuItemReceiveEntry.Name = "MnuItemReceiveEntry"
        Me.MnuItemReceiveEntry.Size = New System.Drawing.Size(239, 22)
        Me.MnuItemReceiveEntry.Text = "Item Receive Entry"
        '
        'MnuReports
        '
        Me.MnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuRequisitionRegister, Me.mnuPurchaseIndentRegister, Me.mnuPurchaseOrderRegister, Me.MnuGRNRegister, Me.MnuSaleRegister, Me.MnuSaleSummary, Me.MnuPurchaseRegister, Me.MnuPurchaseSummary, Me.MnuStockRegister, Me.MnuStockSummary, Me.MnuIssueRegister, Me.MnuFixedAssetsRegister})
        Me.MnuReports.Name = "MnuReports"
        Me.MnuReports.Size = New System.Drawing.Size(152, 22)
        Me.MnuReports.Text = "Reports"
        '
        'mnuRequisitionRegister
        '
        Me.mnuRequisitionRegister.Name = "mnuRequisitionRegister"
        Me.mnuRequisitionRegister.Size = New System.Drawing.Size(207, 22)
        Me.mnuRequisitionRegister.Text = "Requisition Register"
        '
        'mnuPurchaseIndentRegister
        '
        Me.mnuPurchaseIndentRegister.Name = "mnuPurchaseIndentRegister"
        Me.mnuPurchaseIndentRegister.Size = New System.Drawing.Size(207, 22)
        Me.mnuPurchaseIndentRegister.Text = "Purchase Indent Register"
        '
        'mnuPurchaseOrderRegister
        '
        Me.mnuPurchaseOrderRegister.Name = "mnuPurchaseOrderRegister"
        Me.mnuPurchaseOrderRegister.Size = New System.Drawing.Size(207, 22)
        Me.mnuPurchaseOrderRegister.Text = "Purchase Order Register"
        '
        'MnuGRNRegister
        '
        Me.MnuGRNRegister.Name = "MnuGRNRegister"
        Me.MnuGRNRegister.Size = New System.Drawing.Size(207, 22)
        Me.MnuGRNRegister.Tag = "Report"
        Me.MnuGRNRegister.Text = "GRN Register"
        '
        'MnuSaleRegister
        '
        Me.MnuSaleRegister.Name = "MnuSaleRegister"
        Me.MnuSaleRegister.Size = New System.Drawing.Size(207, 22)
        Me.MnuSaleRegister.Tag = "Report"
        Me.MnuSaleRegister.Text = "Sale Register"
        '
        'MnuSaleSummary
        '
        Me.MnuSaleSummary.Name = "MnuSaleSummary"
        Me.MnuSaleSummary.Size = New System.Drawing.Size(207, 22)
        Me.MnuSaleSummary.Tag = "Report"
        Me.MnuSaleSummary.Text = "Sale Summary"
        '
        'MnuPurchaseRegister
        '
        Me.MnuPurchaseRegister.Name = "MnuPurchaseRegister"
        Me.MnuPurchaseRegister.Size = New System.Drawing.Size(207, 22)
        Me.MnuPurchaseRegister.Tag = "Report"
        Me.MnuPurchaseRegister.Text = "Purchase Register"
        '
        'MnuPurchaseSummary
        '
        Me.MnuPurchaseSummary.Name = "MnuPurchaseSummary"
        Me.MnuPurchaseSummary.Size = New System.Drawing.Size(207, 22)
        Me.MnuPurchaseSummary.Tag = "Report"
        Me.MnuPurchaseSummary.Text = "Purchase Summary"
        '
        'MnuStockRegister
        '
        Me.MnuStockRegister.Name = "MnuStockRegister"
        Me.MnuStockRegister.Size = New System.Drawing.Size(207, 22)
        Me.MnuStockRegister.Tag = "Report"
        Me.MnuStockRegister.Text = "Stock Register"
        '
        'MnuStockSummary
        '
        Me.MnuStockSummary.Name = "MnuStockSummary"
        Me.MnuStockSummary.Size = New System.Drawing.Size(207, 22)
        Me.MnuStockSummary.Tag = "Report"
        Me.MnuStockSummary.Text = "Stock Summary"
        '
        'MnuIssueRegister
        '
        Me.MnuIssueRegister.Name = "MnuIssueRegister"
        Me.MnuIssueRegister.Size = New System.Drawing.Size(207, 22)
        Me.MnuIssueRegister.Tag = "Report"
        Me.MnuIssueRegister.Text = "Issue Register"
        '
        'MnuFixedAssetsRegister
        '
        Me.MnuFixedAssetsRegister.Name = "MnuFixedAssetsRegister"
        Me.MnuFixedAssetsRegister.Size = New System.Drawing.Size(207, 22)
        Me.MnuFixedAssetsRegister.Tag = "Report"
        Me.MnuFixedAssetsRegister.Text = "Fixed Assets Register"
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
        'MnuVehicleGateEntry
        '
        Me.MnuVehicleGateEntry.Name = "MnuVehicleGateEntry"
        Me.MnuVehicleGateEntry.Size = New System.Drawing.Size(239, 22)
        Me.MnuVehicleGateEntry.Text = "Gate Pass Entry"
        '
        'MDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(967, 586)
        Me.Controls.Add(Me.MnuMain)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MnuMain
        Me.Name = "MDIMain"
        Me.Text = "Store Data Entry"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMasters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuItemGroup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTransaction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPurchaseEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSaleEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSaleRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSaleSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPurchaseRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPurchaseSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStockRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStockSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUtility As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEnvironmentSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuItemCategoryMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUnitMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGodownMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuOpeningStockEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuItemIssueEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuItemReceiveEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPurchaseEntryAuthenticated As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSaleEntryAuthenticated As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuIssueRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuFixedAssetsRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRequisition As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPurchaseIndentEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuSupplier As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPurchaseOrder As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRequisitionRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPurchaseIndentRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuPurchaseOrderRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGRNEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGRNRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuVehicleGateEntry As System.Windows.Forms.ToolStripMenuItem

End Class
