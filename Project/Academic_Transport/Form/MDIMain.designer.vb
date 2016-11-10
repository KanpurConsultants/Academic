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
        Me.MnuTransport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMasters = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuVehicleMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDriverMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPickupPointMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRouteMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExpenseMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMemberMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTransactions = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuVehicleRouteAllotmentEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAttendanceEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuVehicleMaintenanceExpenseEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMaintenanceExpenseReminder = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuVehicleGateEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUtility = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnvironmentSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDriverRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuVehicleRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuVehicleRouteChart = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMemberRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAttendanceRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuVehicleMaintenanceExpenseRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuVehicleLogRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuTransport})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(967, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuTransport
        '
        Me.MnuTransport.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMasters, Me.MnuTransactions, Me.MnuReports, Me.MnuUtility})
        Me.MnuTransport.Name = "MnuTransport"
        Me.MnuTransport.Size = New System.Drawing.Size(66, 20)
        Me.MnuTransport.Text = "Transport"
        '
        'MnuMasters
        '
        Me.MnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuVehicleMaster, Me.MnuDriverMaster, Me.MnuPickupPointMaster, Me.MnuRouteMaster, Me.MnuExpenseMaster, Me.MnuMemberMaster})
        Me.MnuMasters.Name = "MnuMasters"
        Me.MnuMasters.Size = New System.Drawing.Size(152, 22)
        Me.MnuMasters.Text = "Masters"
        '
        'MnuVehicleMaster
        '
        Me.MnuVehicleMaster.Name = "MnuVehicleMaster"
        Me.MnuVehicleMaster.Size = New System.Drawing.Size(178, 22)
        Me.MnuVehicleMaster.Text = "Vehicle Master"
        '
        'MnuDriverMaster
        '
        Me.MnuDriverMaster.Name = "MnuDriverMaster"
        Me.MnuDriverMaster.Size = New System.Drawing.Size(178, 22)
        Me.MnuDriverMaster.Text = "Driver Master"
        '
        'MnuPickupPointMaster
        '
        Me.MnuPickupPointMaster.Name = "MnuPickupPointMaster"
        Me.MnuPickupPointMaster.Size = New System.Drawing.Size(178, 22)
        Me.MnuPickupPointMaster.Text = "Pickup Point Master"
        '
        'MnuRouteMaster
        '
        Me.MnuRouteMaster.Name = "MnuRouteMaster"
        Me.MnuRouteMaster.Size = New System.Drawing.Size(178, 22)
        Me.MnuRouteMaster.Text = "Route Master"
        '
        'MnuExpenseMaster
        '
        Me.MnuExpenseMaster.Name = "MnuExpenseMaster"
        Me.MnuExpenseMaster.Size = New System.Drawing.Size(178, 22)
        Me.MnuExpenseMaster.Text = "Expense Master"
        '
        'MnuMemberMaster
        '
        Me.MnuMemberMaster.Name = "MnuMemberMaster"
        Me.MnuMemberMaster.Size = New System.Drawing.Size(178, 22)
        Me.MnuMemberMaster.Text = "Member Master"
        '
        'MnuTransactions
        '
        Me.MnuTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuVehicleRouteAllotmentEntry, Me.MnuAttendanceEntry, Me.MnuVehicleMaintenanceExpenseEntry, Me.MnuMaintenanceExpenseReminder, Me.MnuVehicleGateEntry})
        Me.MnuTransactions.Name = "MnuTransactions"
        Me.MnuTransactions.Size = New System.Drawing.Size(152, 22)
        Me.MnuTransactions.Text = "Transactions"
        '
        'MnuVehicleRouteAllotmentEntry
        '
        Me.MnuVehicleRouteAllotmentEntry.Name = "MnuVehicleRouteAllotmentEntry"
        Me.MnuVehicleRouteAllotmentEntry.Size = New System.Drawing.Size(262, 22)
        Me.MnuVehicleRouteAllotmentEntry.Text = "Vehicle Route Allotment Entry"
        '
        'MnuAttendanceEntry
        '
        Me.MnuAttendanceEntry.Name = "MnuAttendanceEntry"
        Me.MnuAttendanceEntry.Size = New System.Drawing.Size(262, 22)
        Me.MnuAttendanceEntry.Text = "Attendance Entry"
        '
        'MnuVehicleMaintenanceExpenseEntry
        '
        Me.MnuVehicleMaintenanceExpenseEntry.Name = "MnuVehicleMaintenanceExpenseEntry"
        Me.MnuVehicleMaintenanceExpenseEntry.Size = New System.Drawing.Size(262, 22)
        Me.MnuVehicleMaintenanceExpenseEntry.Text = "Vehicle Maintenance / Expense Entry"
        '
        'MnuMaintenanceExpenseReminder
        '
        Me.MnuMaintenanceExpenseReminder.Name = "MnuMaintenanceExpenseReminder"
        Me.MnuMaintenanceExpenseReminder.Size = New System.Drawing.Size(262, 22)
        Me.MnuMaintenanceExpenseReminder.Text = "Maintenance / Expense Reminder"
        '
        'MnuVehicleGateEntry
        '
        Me.MnuVehicleGateEntry.Name = "MnuVehicleGateEntry"
        Me.MnuVehicleGateEntry.Size = New System.Drawing.Size(262, 22)
        Me.MnuVehicleGateEntry.Text = "Vehicle Gate Entry"
        '
        'MnuReports
        '
        Me.MnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuDriverRegister, Me.MnuVehicleRegister, Me.MnuVehicleRouteChart, Me.MnuMemberRegister, Me.MnuAttendanceRegister, Me.MnuVehicleMaintenanceExpenseRegister, Me.MnuVehicleLogRegister})
        Me.MnuReports.Name = "MnuReports"
        Me.MnuReports.Size = New System.Drawing.Size(152, 22)
        Me.MnuReports.Text = "Reports"
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
        'MnuDriverRegister
        '
        Me.MnuDriverRegister.Name = "MnuDriverRegister"
        Me.MnuDriverRegister.Size = New System.Drawing.Size(276, 22)
        Me.MnuDriverRegister.Tag = "Report"
        Me.MnuDriverRegister.Text = "Driver Register"
        '
        'MnuVehicleRegister
        '
        Me.MnuVehicleRegister.Name = "MnuVehicleRegister"
        Me.MnuVehicleRegister.Size = New System.Drawing.Size(276, 22)
        Me.MnuVehicleRegister.Tag = "Report"
        Me.MnuVehicleRegister.Text = "Vehicle Register"
        '
        'MnuVehicleRouteChart
        '
        Me.MnuVehicleRouteChart.Name = "MnuVehicleRouteChart"
        Me.MnuVehicleRouteChart.Size = New System.Drawing.Size(276, 22)
        Me.MnuVehicleRouteChart.Tag = "Report"
        Me.MnuVehicleRouteChart.Text = "Vehicle Route Chart"
        '
        'MnuMemberRegister
        '
        Me.MnuMemberRegister.Name = "MnuMemberRegister"
        Me.MnuMemberRegister.Size = New System.Drawing.Size(276, 22)
        Me.MnuMemberRegister.Tag = "Report"
        Me.MnuMemberRegister.Text = "Member Register"
        '
        'MnuAttendanceRegister
        '
        Me.MnuAttendanceRegister.Name = "MnuAttendanceRegister"
        Me.MnuAttendanceRegister.Size = New System.Drawing.Size(276, 22)
        Me.MnuAttendanceRegister.Tag = "Report"
        Me.MnuAttendanceRegister.Text = "Attendance Register"
        '
        'MnuVehicleMaintenanceExpenseRegister
        '
        Me.MnuVehicleMaintenanceExpenseRegister.Name = "MnuVehicleMaintenanceExpenseRegister"
        Me.MnuVehicleMaintenanceExpenseRegister.Size = New System.Drawing.Size(276, 22)
        Me.MnuVehicleMaintenanceExpenseRegister.Tag = "Report"
        Me.MnuVehicleMaintenanceExpenseRegister.Text = "Vehicle Maintenance / Expense Register"
        '
        'MnuVehicleLogRegister
        '
        Me.MnuVehicleLogRegister.Name = "MnuVehicleLogRegister"
        Me.MnuVehicleLogRegister.Size = New System.Drawing.Size(276, 22)
        Me.MnuVehicleLogRegister.Tag = "Report"
        Me.MnuVehicleLogRegister.Text = "Vehicle Log Register"
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
        Me.Text = "Transport"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Public WithEvents MnuTransport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEnvironmentSettings As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMasters As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuTransactions As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuReports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuUtility As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuVehicleMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuDriverMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuPickupPointMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuRouteMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuExpenseMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAttendanceEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuVehicleMaintenanceExpenseEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuVehicleRouteAllotmentEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMaintenanceExpenseReminder As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMemberMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuVehicleGateEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuDriverRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuVehicleRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuVehicleRouteChart As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMemberRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAttendanceRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuVehicleMaintenanceExpenseRegister As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuVehicleLogRegister As System.Windows.Forms.ToolStripMenuItem

End Class
