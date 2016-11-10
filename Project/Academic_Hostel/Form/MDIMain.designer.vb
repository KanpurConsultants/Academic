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
        Me.MnuAcademicHostel = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMasters = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuHostelMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuBuildingMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuFloorMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuBuildingFloorMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomType = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuChargeGroupMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuChargeMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTransactions = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomAllotment = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomTransfer = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomLeft = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAdvanceReceiveEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomChargeDueEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomChargeReceive = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomCbargeRefundEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomAllotmentRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomTransferRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomLeftRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuAdvanceChargeRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuChargeDueRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuChargeReceiveRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuChargeRefundRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomStatusReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMemberWiseOutstandingSummary = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUtility = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnvironmentSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRoomStatusDisplay = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMemberRegister = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuAcademicHostel})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(967, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuAcademicHostel
        '
        Me.MnuAcademicHostel.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMasters, Me.MnuTransactions, Me.MnuReports, Me.MnuUtility, Me.MnuRoomStatusDisplay})
        Me.MnuAcademicHostel.Name = "MnuAcademicHostel"
        Me.MnuAcademicHostel.Size = New System.Drawing.Size(49, 20)
        Me.MnuAcademicHostel.Text = "Hostel"
        '
        'MnuMasters
        '
        Me.MnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuHostelMaster, Me.MnuBuildingMaster, Me.MnuFloorMaster, Me.MnuBuildingFloorMaster, Me.MnuRoomType, Me.MnuRoomMaster, Me.MnuChargeGroupMaster, Me.MnuChargeMaster})
        Me.MnuMasters.Name = "MnuMasters"
        Me.MnuMasters.Size = New System.Drawing.Size(183, 22)
        Me.MnuMasters.Text = "Masters"
        '
        'MnuHostelMaster
        '
        Me.MnuHostelMaster.Name = "MnuHostelMaster"
        Me.MnuHostelMaster.Size = New System.Drawing.Size(188, 22)
        Me.MnuHostelMaster.Text = "Hostel Master"
        '
        'MnuBuildingMaster
        '
        Me.MnuBuildingMaster.Name = "MnuBuildingMaster"
        Me.MnuBuildingMaster.Size = New System.Drawing.Size(188, 22)
        Me.MnuBuildingMaster.Text = "Building Master"
        '
        'MnuFloorMaster
        '
        Me.MnuFloorMaster.Name = "MnuFloorMaster"
        Me.MnuFloorMaster.Size = New System.Drawing.Size(188, 22)
        Me.MnuFloorMaster.Text = "Floor Master"
        '
        'MnuBuildingFloorMaster
        '
        Me.MnuBuildingFloorMaster.Name = "MnuBuildingFloorMaster"
        Me.MnuBuildingFloorMaster.Size = New System.Drawing.Size(188, 22)
        Me.MnuBuildingFloorMaster.Text = "Building Floor Master"
        '
        'MnuRoomType
        '
        Me.MnuRoomType.Name = "MnuRoomType"
        Me.MnuRoomType.Size = New System.Drawing.Size(188, 22)
        Me.MnuRoomType.Text = "Room Type Master"
        '
        'MnuRoomMaster
        '
        Me.MnuRoomMaster.Name = "MnuRoomMaster"
        Me.MnuRoomMaster.Size = New System.Drawing.Size(188, 22)
        Me.MnuRoomMaster.Text = "Room Master"
        '
        'MnuChargeGroupMaster
        '
        Me.MnuChargeGroupMaster.Name = "MnuChargeGroupMaster"
        Me.MnuChargeGroupMaster.Size = New System.Drawing.Size(188, 22)
        Me.MnuChargeGroupMaster.Text = "Charge Group Master"
        '
        'MnuChargeMaster
        '
        Me.MnuChargeMaster.Name = "MnuChargeMaster"
        Me.MnuChargeMaster.Size = New System.Drawing.Size(188, 22)
        Me.MnuChargeMaster.Text = "Charge Master"
        '
        'MnuTransactions
        '
        Me.MnuTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuRoomAllotment, Me.MnuRoomTransfer, Me.MnuRoomLeft, Me.MnuAdvanceReceiveEntry, Me.MnuRoomChargeDueEntry, Me.MnuRoomChargeReceive, Me.MnuRoomCbargeRefundEntry})
        Me.MnuTransactions.Name = "MnuTransactions"
        Me.MnuTransactions.Size = New System.Drawing.Size(183, 22)
        Me.MnuTransactions.Text = "Transactions"
        '
        'MnuRoomAllotment
        '
        Me.MnuRoomAllotment.Name = "MnuRoomAllotment"
        Me.MnuRoomAllotment.Size = New System.Drawing.Size(220, 22)
        Me.MnuRoomAllotment.Text = "Room Allotment"
        '
        'MnuRoomTransfer
        '
        Me.MnuRoomTransfer.Name = "MnuRoomTransfer"
        Me.MnuRoomTransfer.Size = New System.Drawing.Size(220, 22)
        Me.MnuRoomTransfer.Text = "Room Transfer"
        '
        'MnuRoomLeft
        '
        Me.MnuRoomLeft.Name = "MnuRoomLeft"
        Me.MnuRoomLeft.Size = New System.Drawing.Size(220, 22)
        Me.MnuRoomLeft.Text = "Room Left"
        '
        'MnuAdvanceReceiveEntry
        '
        Me.MnuAdvanceReceiveEntry.Name = "MnuAdvanceReceiveEntry"
        Me.MnuAdvanceReceiveEntry.Size = New System.Drawing.Size(220, 22)
        Me.MnuAdvanceReceiveEntry.Text = "Advance Receive Entry"
        '
        'MnuRoomChargeDueEntry
        '
        Me.MnuRoomChargeDueEntry.Name = "MnuRoomChargeDueEntry"
        Me.MnuRoomChargeDueEntry.Size = New System.Drawing.Size(220, 22)
        Me.MnuRoomChargeDueEntry.Text = "Room Charge Due Entry"
        '
        'MnuRoomChargeReceive
        '
        Me.MnuRoomChargeReceive.Name = "MnuRoomChargeReceive"
        Me.MnuRoomChargeReceive.Size = New System.Drawing.Size(220, 22)
        Me.MnuRoomChargeReceive.Text = "Room Charge Receive Entry"
        '
        'MnuRoomCbargeRefundEntry
        '
        Me.MnuRoomCbargeRefundEntry.Name = "MnuRoomCbargeRefundEntry"
        Me.MnuRoomCbargeRefundEntry.Size = New System.Drawing.Size(220, 22)
        Me.MnuRoomCbargeRefundEntry.Text = "Room Charge Refund Entry"
        '
        'MnuReports
        '
        Me.MnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuRoomAllotmentRegister, Me.MnuRoomTransferRegister, Me.MnuRoomLeftRegister, Me.MnuAdvanceChargeRegister, Me.MnuChargeDueRegister, Me.MnuChargeReceiveRegister, Me.MnuChargeRefundRegister, Me.MnuRoomStatusReport, Me.MnuMemberWiseOutstandingSummary, Me.MnuMemberRegister})
        Me.MnuReports.Name = "MnuReports"
        Me.MnuReports.Size = New System.Drawing.Size(183, 22)
        Me.MnuReports.Text = "Reports"
        '
        'MnuRoomAllotmentRegister
        '
        Me.MnuRoomAllotmentRegister.Name = "MnuRoomAllotmentRegister"
        Me.MnuRoomAllotmentRegister.Size = New System.Drawing.Size(258, 22)
        Me.MnuRoomAllotmentRegister.Tag = "Hostel"
        Me.MnuRoomAllotmentRegister.Text = "Room Allotment Register"
        '
        'MnuRoomTransferRegister
        '
        Me.MnuRoomTransferRegister.Name = "MnuRoomTransferRegister"
        Me.MnuRoomTransferRegister.Size = New System.Drawing.Size(258, 22)
        Me.MnuRoomTransferRegister.Tag = "Hostel"
        Me.MnuRoomTransferRegister.Text = "Room Transfer Register"
        '
        'MnuRoomLeftRegister
        '
        Me.MnuRoomLeftRegister.Name = "MnuRoomLeftRegister"
        Me.MnuRoomLeftRegister.Size = New System.Drawing.Size(258, 22)
        Me.MnuRoomLeftRegister.Tag = "Hostel"
        Me.MnuRoomLeftRegister.Text = "Room Left Register"
        '
        'MnuAdvanceChargeRegister
        '
        Me.MnuAdvanceChargeRegister.Name = "MnuAdvanceChargeRegister"
        Me.MnuAdvanceChargeRegister.Size = New System.Drawing.Size(258, 22)
        Me.MnuAdvanceChargeRegister.Tag = "Hostel"
        Me.MnuAdvanceChargeRegister.Text = "Advance Charge Register"
        '
        'MnuChargeDueRegister
        '
        Me.MnuChargeDueRegister.Name = "MnuChargeDueRegister"
        Me.MnuChargeDueRegister.Size = New System.Drawing.Size(258, 22)
        Me.MnuChargeDueRegister.Tag = "Hostel"
        Me.MnuChargeDueRegister.Text = "Charge Due Register"
        '
        'MnuChargeReceiveRegister
        '
        Me.MnuChargeReceiveRegister.Name = "MnuChargeReceiveRegister"
        Me.MnuChargeReceiveRegister.Size = New System.Drawing.Size(258, 22)
        Me.MnuChargeReceiveRegister.Tag = "Hostel"
        Me.MnuChargeReceiveRegister.Text = "Charge Receive Register"
        '
        'MnuChargeRefundRegister
        '
        Me.MnuChargeRefundRegister.Name = "MnuChargeRefundRegister"
        Me.MnuChargeRefundRegister.Size = New System.Drawing.Size(258, 22)
        Me.MnuChargeRefundRegister.Tag = "Hostel"
        Me.MnuChargeRefundRegister.Text = "Charge Refund Register"
        '
        'MnuRoomStatusReport
        '
        Me.MnuRoomStatusReport.Name = "MnuRoomStatusReport"
        Me.MnuRoomStatusReport.Size = New System.Drawing.Size(258, 22)
        Me.MnuRoomStatusReport.Tag = "Hostel"
        Me.MnuRoomStatusReport.Text = "Room Status Report"
        '
        'MnuMemberWiseOutstandingSummary
        '
        Me.MnuMemberWiseOutstandingSummary.Name = "MnuMemberWiseOutstandingSummary"
        Me.MnuMemberWiseOutstandingSummary.Size = New System.Drawing.Size(258, 22)
        Me.MnuMemberWiseOutstandingSummary.Tag = "Hostel"
        Me.MnuMemberWiseOutstandingSummary.Text = "Member Wise Outstanding Summary"
        '
        'MnuUtility
        '
        Me.MnuUtility.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuEnvironmentSettings})
        Me.MnuUtility.Name = "MnuUtility"
        Me.MnuUtility.Size = New System.Drawing.Size(183, 22)
        Me.MnuUtility.Text = "Utility"
        '
        'MnuEnvironmentSettings
        '
        Me.MnuEnvironmentSettings.Name = "MnuEnvironmentSettings"
        Me.MnuEnvironmentSettings.Size = New System.Drawing.Size(187, 22)
        Me.MnuEnvironmentSettings.Text = "Environment Settings"
        '
        'MnuRoomStatusDisplay
        '
        Me.MnuRoomStatusDisplay.Name = "MnuRoomStatusDisplay"
        Me.MnuRoomStatusDisplay.Size = New System.Drawing.Size(183, 22)
        Me.MnuRoomStatusDisplay.Text = "Room Status Display"
        '
        'MnuMemberRegister
        '
        Me.MnuMemberRegister.Name = "MnuMemberRegister"
        Me.MnuMemberRegister.Size = New System.Drawing.Size(258, 22)
        Me.MnuMemberRegister.Tag = "Report"
        Me.MnuMemberRegister.Text = "Member Register"
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
        Me.Text = "Hostel                                                                           " & _
            "                                                                              "
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAcademicHostel As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMasters As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuTransactions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUtility As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEnvironmentSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBuildingMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomAllotment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuHostelMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuFloorMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuBuildingFloorMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomLeft As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomTransfer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuChargeGroupMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuChargeMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomChargeDueEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomChargeReceive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomCbargeRefundEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAdvanceReceiveEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomAllotmentRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomTransferRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomLeftRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuChargeDueRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuAdvanceChargeRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuChargeReceiveRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuChargeRefundRegister As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomStatusReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMemberWiseOutstandingSummary As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRoomStatusDisplay As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMemberRegister As System.Windows.Forms.ToolStripMenuItem

End Class
