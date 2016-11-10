<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDI_Attendance
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
        Me.MnuMemberMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTransactions = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMemberLeaveEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAttendanceEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUtility = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnvironmentSettings = New System.Windows.Forms.ToolStripMenuItem
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
        Me.MnuMess.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMasters, Me.MnuTransactions, Me.MnuUtility})
        Me.MnuMess.Name = "MnuMess"
        Me.MnuMess.Size = New System.Drawing.Size(43, 20)
        Me.MnuMess.Text = "Mess"
        '
        'MnuMasters
        '
        Me.MnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMemberMaster})
        Me.MnuMasters.Name = "MnuMasters"
        Me.MnuMasters.Size = New System.Drawing.Size(152, 22)
        Me.MnuMasters.Text = "Masters"
        '
        'MnuMemberMaster
        '
        Me.MnuMemberMaster.Name = "MnuMemberMaster"
        Me.MnuMemberMaster.Size = New System.Drawing.Size(159, 22)
        Me.MnuMemberMaster.Text = "Member Master"
        '
        'MnuTransactions
        '
        Me.MnuTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMemberLeaveEntry, Me.MnuAttendanceEntry})
        Me.MnuTransactions.Name = "MnuTransactions"
        Me.MnuTransactions.Size = New System.Drawing.Size(152, 22)
        Me.MnuTransactions.Text = "Transactions"
        '
        'MnuMemberLeaveEntry
        '
        Me.MnuMemberLeaveEntry.Name = "MnuMemberLeaveEntry"
        Me.MnuMemberLeaveEntry.Size = New System.Drawing.Size(184, 22)
        Me.MnuMemberLeaveEntry.Text = "Member Leave Entry"
        '
        'MnuAttendanceEntry
        '
        Me.MnuAttendanceEntry.Name = "MnuAttendanceEntry"
        Me.MnuAttendanceEntry.Size = New System.Drawing.Size(184, 22)
        Me.MnuAttendanceEntry.Text = "Attendance Entry"
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
        'MDI_Attendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(967, 663)
        Me.Controls.Add(Me.MnuMain)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MnuMain
        Me.Name = "MDI_Attendance"
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
    Public WithEvents MnuUtility As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMemberMaster As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMemberLeaveEntry As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuAttendanceEntry As System.Windows.Forms.ToolStripMenuItem

End Class
