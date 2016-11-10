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
        Me.MnuExam = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMasters = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExamTypeMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSemesterExamMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuTransactions = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuExamCreationEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSubjectMarksEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuConsolidatedSubjectMarks = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMarkSheet = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStudentsHavingMarksGreaterThanADefinedPercentage = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStudentsHavingMarksLessThanADefinedPercentage = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuGAIAReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStatementOfMarks = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUtility = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEnvironmentSettings = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuHallTicket = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuExam})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(967, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuExam
        '
        Me.MnuExam.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMasters, Me.MnuTransactions, Me.MnuReports, Me.MnuUtility})
        Me.MnuExam.Name = "MnuExam"
        Me.MnuExam.Size = New System.Drawing.Size(45, 20)
        Me.MnuExam.Text = "Exam"
        '
        'MnuMasters
        '
        Me.MnuMasters.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuExamTypeMaster, Me.MnuSemesterExamMaster})
        Me.MnuMasters.Name = "MnuMasters"
        Me.MnuMasters.Size = New System.Drawing.Size(152, 22)
        Me.MnuMasters.Text = "Masters"
        '
        'MnuExamTypeMaster
        '
        Me.MnuExamTypeMaster.Name = "MnuExamTypeMaster"
        Me.MnuExamTypeMaster.Size = New System.Drawing.Size(195, 22)
        Me.MnuExamTypeMaster.Text = "Exam Type Master"
        '
        'MnuSemesterExamMaster
        '
        Me.MnuSemesterExamMaster.Name = "MnuSemesterExamMaster"
        Me.MnuSemesterExamMaster.Size = New System.Drawing.Size(195, 22)
        Me.MnuSemesterExamMaster.Text = "Semester Exam Master"
        '
        'MnuTransactions
        '
        Me.MnuTransactions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuExamCreationEntry, Me.MnuSubjectMarksEntry, Me.MnuConsolidatedSubjectMarks})
        Me.MnuTransactions.Name = "MnuTransactions"
        Me.MnuTransactions.Size = New System.Drawing.Size(152, 22)
        Me.MnuTransactions.Text = "Transactions"
        '
        'MnuExamCreationEntry
        '
        Me.MnuExamCreationEntry.Name = "MnuExamCreationEntry"
        Me.MnuExamCreationEntry.Size = New System.Drawing.Size(217, 22)
        Me.MnuExamCreationEntry.Text = "Exam Creation Entry"
        '
        'MnuSubjectMarksEntry
        '
        Me.MnuSubjectMarksEntry.Name = "MnuSubjectMarksEntry"
        Me.MnuSubjectMarksEntry.Size = New System.Drawing.Size(217, 22)
        Me.MnuSubjectMarksEntry.Text = "Subject Marks Entry"
        '
        'MnuConsolidatedSubjectMarks
        '
        Me.MnuConsolidatedSubjectMarks.Name = "MnuConsolidatedSubjectMarks"
        Me.MnuConsolidatedSubjectMarks.Size = New System.Drawing.Size(217, 22)
        Me.MnuConsolidatedSubjectMarks.Text = "Consolidated Subject Marks"
        '
        'MnuReports
        '
        Me.MnuReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMarkSheet, Me.MnuStudentsHavingMarksGreaterThanADefinedPercentage, Me.MnuStudentsHavingMarksLessThanADefinedPercentage, Me.MnuGAIAReport, Me.MnuStatementOfMarks, Me.MnuHallTicket})
        Me.MnuReports.Name = "MnuReports"
        Me.MnuReports.Size = New System.Drawing.Size(152, 22)
        Me.MnuReports.Text = "Reports"
        '
        'MnuMarkSheet
        '
        Me.MnuMarkSheet.Name = "MnuMarkSheet"
        Me.MnuMarkSheet.Size = New System.Drawing.Size(370, 22)
        Me.MnuMarkSheet.Tag = "Exam"
        Me.MnuMarkSheet.Text = "Mark Sheet "
        '
        'MnuStudentsHavingMarksGreaterThanADefinedPercentage
        '
        Me.MnuStudentsHavingMarksGreaterThanADefinedPercentage.Name = "MnuStudentsHavingMarksGreaterThanADefinedPercentage"
        Me.MnuStudentsHavingMarksGreaterThanADefinedPercentage.Size = New System.Drawing.Size(370, 22)
        Me.MnuStudentsHavingMarksGreaterThanADefinedPercentage.Tag = "Exam"
        Me.MnuStudentsHavingMarksGreaterThanADefinedPercentage.Text = "Students Having Marks Greater Than A Defined Percentage"
        '
        'MnuStudentsHavingMarksLessThanADefinedPercentage
        '
        Me.MnuStudentsHavingMarksLessThanADefinedPercentage.Name = "MnuStudentsHavingMarksLessThanADefinedPercentage"
        Me.MnuStudentsHavingMarksLessThanADefinedPercentage.Size = New System.Drawing.Size(370, 22)
        Me.MnuStudentsHavingMarksLessThanADefinedPercentage.Tag = "Exam"
        Me.MnuStudentsHavingMarksLessThanADefinedPercentage.Text = "Students Having Marks Less Than A Defined Percentage"
        '
        'MnuGAIAReport
        '
        Me.MnuGAIAReport.Name = "MnuGAIAReport"
        Me.MnuGAIAReport.Size = New System.Drawing.Size(370, 22)
        Me.MnuGAIAReport.Tag = "Exam"
        Me.MnuGAIAReport.Text = "GAIA Report"
        '
        'MnuStatementOfMarks
        '
        Me.MnuStatementOfMarks.Name = "MnuStatementOfMarks"
        Me.MnuStatementOfMarks.Size = New System.Drawing.Size(370, 22)
        Me.MnuStatementOfMarks.Tag = "Exam"
        Me.MnuStatementOfMarks.Text = "Statement Of Marks"
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
        'MnuHallTicket
        '
        Me.MnuHallTicket.Name = "MnuHallTicket"
        Me.MnuHallTicket.Size = New System.Drawing.Size(370, 22)
        Me.MnuHallTicket.Tag = "Report"
        Me.MnuHallTicket.Text = "Hall Ticket"
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
        Me.Text = "Exam"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExam As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMasters As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuTransactions As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuReports As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuExamTypeMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSemesterExamMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuExamCreationEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSubjectMarksEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMarkSheet As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuUtility As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuEnvironmentSettings As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStudentsHavingMarksGreaterThanADefinedPercentage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStudentsHavingMarksLessThanADefinedPercentage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuConsolidatedSubjectMarks As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGAIAReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStatementOfMarks As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuHallTicket As System.Windows.Forms.ToolStripMenuItem

End Class
