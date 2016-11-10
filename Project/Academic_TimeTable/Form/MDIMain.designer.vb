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
        Me.MnuTimeTable = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMasters = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTimeTableMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTransactions = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTeacherAttendance = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReallocateTeacherEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuLeaveEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuLeaveEntryAuthenticated = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTimeTableReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTeacherTimeTableReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReallocatedTeacherReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTeacherAttendanceReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuTimeTable})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(967, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuTimeTable
        '
        Me.MnuTimeTable.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMasters, Me.MnuTransactions, Me.MnuReports})
        Me.MnuTimeTable.Name = "MnuTimeTable"
        Me.MnuTimeTable.Size = New System.Drawing.Size(70, 20)
        Me.MnuTimeTable.Text = "Time Table"
        '
        'MnuMasters
        '
        Me.MnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuTimeTableMaster})
        Me.MnuMasters.Name = "MnuMasters"
        Me.MnuMasters.Size = New System.Drawing.Size(152, 22)
        Me.MnuMasters.Text = "Masters"
        '
        'MnuTimeTableMaster
        '
        Me.MnuTimeTableMaster.Name = "MnuTimeTableMaster"
        Me.MnuTimeTableMaster.Size = New System.Drawing.Size(172, 22)
        Me.MnuTimeTableMaster.Text = "Time Table Master"
        '
        'MnuTransactions
        '
        Me.MnuTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuTeacherAttendance, Me.MnuReallocateTeacherEntry, Me.MnuLeaveEntry, Me.MnuLeaveEntryAuthenticated})
        Me.MnuTransactions.Name = "MnuTransactions"
        Me.MnuTransactions.Size = New System.Drawing.Size(152, 22)
        Me.MnuTransactions.Text = "Transactions"
        '
        'MnuTeacherAttendance
        '
        Me.MnuTeacherAttendance.AccessibleDescription = "Import"
        Me.MnuTeacherAttendance.Name = "MnuTeacherAttendance"
        Me.MnuTeacherAttendance.Size = New System.Drawing.Size(225, 22)
        Me.MnuTeacherAttendance.Text = "Teacher Attendance"
        '
        'MnuReallocateTeacherEntry
        '
        Me.MnuReallocateTeacherEntry.Name = "MnuReallocateTeacherEntry"
        Me.MnuReallocateTeacherEntry.Size = New System.Drawing.Size(225, 22)
        Me.MnuReallocateTeacherEntry.Text = "Reallocate Teacher Entry"
        '
        'MnuLeaveEntry
        '
        Me.MnuLeaveEntry.AccessibleDescription = "Approved By "
        Me.MnuLeaveEntry.Name = "MnuLeaveEntry"
        Me.MnuLeaveEntry.Size = New System.Drawing.Size(225, 22)
        Me.MnuLeaveEntry.Text = "Leave Entry"
        '
        'MnuLeaveEntryAuthenticated
        '
        Me.MnuLeaveEntryAuthenticated.AccessibleDescription = "ZZZZZ"
        Me.MnuLeaveEntryAuthenticated.Name = "MnuLeaveEntryAuthenticated"
        Me.MnuLeaveEntryAuthenticated.Size = New System.Drawing.Size(225, 22)
        Me.MnuLeaveEntryAuthenticated.Text = "Leave Entry  [Authenticated]"
        '
        'MnuReports
        '
        Me.MnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuTimeTableReport, Me.MnuTeacherTimeTableReport, Me.MnuReallocatedTeacherReport, Me.MnuTeacherAttendanceReport})
        Me.MnuReports.Name = "MnuReports"
        Me.MnuReports.Size = New System.Drawing.Size(152, 22)
        Me.MnuReports.Text = "Reports"
        '
        'MnuTimeTableReport
        '
        Me.MnuTimeTableReport.Name = "MnuTimeTableReport"
        Me.MnuTimeTableReport.Size = New System.Drawing.Size(219, 22)
        Me.MnuTimeTableReport.Tag = "Time Table"
        Me.MnuTimeTableReport.Text = "Time Table Report"
        '
        'MnuTeacherTimeTableReport
        '
        Me.MnuTeacherTimeTableReport.Name = "MnuTeacherTimeTableReport"
        Me.MnuTeacherTimeTableReport.Size = New System.Drawing.Size(219, 22)
        Me.MnuTeacherTimeTableReport.Tag = "Time Table"
        Me.MnuTeacherTimeTableReport.Text = "Teacher Time Table Report"
        '
        'MnuReallocatedTeacherReport
        '
        Me.MnuReallocatedTeacherReport.Name = "MnuReallocatedTeacherReport"
        Me.MnuReallocatedTeacherReport.Size = New System.Drawing.Size(219, 22)
        Me.MnuReallocatedTeacherReport.Tag = "Time Table"
        Me.MnuReallocatedTeacherReport.Text = "Reallocated Teacher Report"
        '
        'MnuTeacherAttendanceReport
        '
        Me.MnuTeacherAttendanceReport.Name = "MnuTeacherAttendanceReport"
        Me.MnuTeacherAttendanceReport.Size = New System.Drawing.Size(219, 22)
        Me.MnuTeacherAttendanceReport.Tag = "Time Table"
        Me.MnuTeacherAttendanceReport.Text = "Teacher Attendance Report"
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
        Me.Text = "Time Table"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTimeTable As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMasters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTransactions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Public WithEvents MnuTeacherAttendance As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuReallocateTeacherEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuTimeTableMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuTimeTableReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuTeacherTimeTableReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuReallocatedTeacherReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuTeacherAttendanceReport As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuLeaveEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuLeaveEntryAuthenticated As System.Windows.Forms.ToolStripMenuItem

End Class
