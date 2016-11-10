<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubSectionAssignEntry
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
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtClassSection = New AgControls.AgTextBox
        Me.LblClassSection = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.BtnFillStudent = New System.Windows.Forms.Button
        Me.LblClassSectionReq = New System.Windows.Forms.Label
        Me.LblTotalStudent = New System.Windows.Forms.Label
        Me.TxtTotalStudent = New AgControls.AgTextBox
        Me.LblClassSectionSubSectionReq = New System.Windows.Forms.Label
        Me.TxtClassSectionSubSection = New AgControls.AgTextBox
        Me.LblClassSectionSubSection = New System.Windows.Forms.Label
        Me.TxtSelectAll = New AgControls.AgTextBox
        Me.LblSelectAll = New System.Windows.Forms.Label
        Me.LblSelectAllReq = New System.Windows.Forms.Label
        Me.LblStreamYearSemesterReq = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Topctrl1.Location = New System.Drawing.Point(0, 0)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(872, 41)
        Me.Topctrl1.TabIndex = 6
        Me.Topctrl1.tAdd = True
        Me.Topctrl1.tCancel = True
        Me.Topctrl1.tDel = True
        Me.Topctrl1.tDiscard = False
        Me.Topctrl1.tEdit = True
        Me.Topctrl1.tExit = True
        Me.Topctrl1.tFind = True
        Me.Topctrl1.tFirst = True
        Me.Topctrl1.tLast = True
        Me.Topctrl1.tNext = True
        Me.Topctrl1.tPrev = True
        Me.Topctrl1.tPrn = True
        Me.Topctrl1.tRef = True
        Me.Topctrl1.tSave = False
        Me.Topctrl1.tSite = True
        '
        'TxtClassSection
        '
        Me.TxtClassSection.AgAllowUserToEnableMasterHelp = False
        Me.TxtClassSection.AgMandatory = True
        Me.TxtClassSection.AgMasterHelp = False
        Me.TxtClassSection.AgNumberLeftPlaces = 0
        Me.TxtClassSection.AgNumberNegetiveAllow = False
        Me.TxtClassSection.AgNumberRightPlaces = 0
        Me.TxtClassSection.AgPickFromLastValue = False
        Me.TxtClassSection.AgRowFilter = ""
        Me.TxtClassSection.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClassSection.AgSelectedValue = Nothing
        Me.TxtClassSection.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClassSection.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClassSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassSection.Location = New System.Drawing.Point(332, 97)
        Me.TxtClassSection.MaxLength = 50
        Me.TxtClassSection.Name = "TxtClassSection"
        Me.TxtClassSection.Size = New System.Drawing.Size(325, 21)
        Me.TxtClassSection.TabIndex = 1
        '
        'LblClassSection
        '
        Me.LblClassSection.AutoSize = True
        Me.LblClassSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSection.Location = New System.Drawing.Point(180, 100)
        Me.LblClassSection.Name = "LblClassSection"
        Me.LblClassSection.Size = New System.Drawing.Size(85, 13)
        Me.LblClassSection.TabIndex = 16
        Me.LblClassSection.Text = "Class/Section"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(183, 174)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(474, 28)
        Me.Panel1.TabIndex = 20
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Cornsilk
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(474, 27)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Student List"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(183, 203)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(474, 387)
        Me.Pnl1.TabIndex = 5
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(319, 61)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 511
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(180, 58)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 512
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgAllowUserToEnableMasterHelp = False
        Me.TxtSite_Code.AgMandatory = False
        Me.TxtSite_Code.AgMasterHelp = False
        Me.TxtSite_Code.AgNumberLeftPlaces = 0
        Me.TxtSite_Code.AgNumberNegetiveAllow = False
        Me.TxtSite_Code.AgNumberRightPlaces = 0
        Me.TxtSite_Code.AgPickFromLastValue = False
        Me.TxtSite_Code.AgRowFilter = ""
        Me.TxtSite_Code.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSite_Code.AgSelectedValue = Nothing
        Me.TxtSite_Code.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSite_Code.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(332, 53)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 21)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'BtnFillStudent
        '
        Me.BtnFillStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillStudent.Location = New System.Drawing.Point(534, 142)
        Me.BtnFillStudent.Name = "BtnFillStudent"
        Me.BtnFillStudent.Size = New System.Drawing.Size(123, 27)
        Me.BtnFillStudent.TabIndex = 4
        Me.BtnFillStudent.Text = "&Fill Student"
        Me.BtnFillStudent.UseVisualStyleBackColor = True
        '
        'LblClassSectionReq
        '
        Me.LblClassSectionReq.AutoSize = True
        Me.LblClassSectionReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblClassSectionReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblClassSectionReq.Location = New System.Drawing.Point(319, 105)
        Me.LblClassSectionReq.Name = "LblClassSectionReq"
        Me.LblClassSectionReq.Size = New System.Drawing.Size(10, 7)
        Me.LblClassSectionReq.TabIndex = 515
        Me.LblClassSectionReq.Text = "Ä"
        '
        'LblTotalStudent
        '
        Me.LblTotalStudent.AutoSize = True
        Me.LblTotalStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalStudent.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalStudent.Location = New System.Drawing.Point(660, 573)
        Me.LblTotalStudent.Name = "LblTotalStudent"
        Me.LblTotalStudent.Size = New System.Drawing.Size(83, 13)
        Me.LblTotalStudent.TabIndex = 516
        Me.LblTotalStudent.Text = "Total Student"
        '
        'TxtTotalStudent
        '
        Me.TxtTotalStudent.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalStudent.AgMandatory = False
        Me.TxtTotalStudent.AgMasterHelp = False
        Me.TxtTotalStudent.AgNumberLeftPlaces = 8
        Me.TxtTotalStudent.AgNumberNegetiveAllow = False
        Me.TxtTotalStudent.AgNumberRightPlaces = 0
        Me.TxtTotalStudent.AgPickFromLastValue = False
        Me.TxtTotalStudent.AgRowFilter = ""
        Me.TxtTotalStudent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalStudent.AgSelectedValue = Nothing
        Me.TxtTotalStudent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalStudent.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalStudent.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalStudent.Location = New System.Drawing.Point(749, 569)
        Me.TxtTotalStudent.MaxLength = 255
        Me.TxtTotalStudent.Name = "TxtTotalStudent"
        Me.TxtTotalStudent.ReadOnly = True
        Me.TxtTotalStudent.Size = New System.Drawing.Size(100, 21)
        Me.TxtTotalStudent.TabIndex = 517
        Me.TxtTotalStudent.Text = "AgTextBox1"
        Me.TxtTotalStudent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblClassSectionSubSectionReq
        '
        Me.LblClassSectionSubSectionReq.AutoSize = True
        Me.LblClassSectionSubSectionReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblClassSectionSubSectionReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblClassSectionSubSectionReq.Location = New System.Drawing.Point(319, 127)
        Me.LblClassSectionSubSectionReq.Name = "LblClassSectionSubSectionReq"
        Me.LblClassSectionSubSectionReq.Size = New System.Drawing.Size(10, 7)
        Me.LblClassSectionSubSectionReq.TabIndex = 520
        Me.LblClassSectionSubSectionReq.Text = "Ä"
        '
        'TxtClassSectionSubSection
        '
        Me.TxtClassSectionSubSection.AgAllowUserToEnableMasterHelp = False
        Me.TxtClassSectionSubSection.AgMandatory = True
        Me.TxtClassSectionSubSection.AgMasterHelp = False
        Me.TxtClassSectionSubSection.AgNumberLeftPlaces = 0
        Me.TxtClassSectionSubSection.AgNumberNegetiveAllow = False
        Me.TxtClassSectionSubSection.AgNumberRightPlaces = 0
        Me.TxtClassSectionSubSection.AgPickFromLastValue = False
        Me.TxtClassSectionSubSection.AgRowFilter = ""
        Me.TxtClassSectionSubSection.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClassSectionSubSection.AgSelectedValue = Nothing
        Me.TxtClassSectionSubSection.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClassSectionSubSection.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClassSectionSubSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassSectionSubSection.Location = New System.Drawing.Point(332, 119)
        Me.TxtClassSectionSubSection.MaxLength = 50
        Me.TxtClassSectionSubSection.Name = "TxtClassSectionSubSection"
        Me.TxtClassSectionSubSection.Size = New System.Drawing.Size(325, 21)
        Me.TxtClassSectionSubSection.TabIndex = 2
        '
        'LblClassSectionSubSection
        '
        Me.LblClassSectionSubSection.AutoSize = True
        Me.LblClassSectionSubSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSectionSubSection.Location = New System.Drawing.Point(180, 122)
        Me.LblClassSectionSubSection.Name = "LblClassSectionSubSection"
        Me.LblClassSectionSubSection.Size = New System.Drawing.Size(76, 13)
        Me.LblClassSectionSubSection.TabIndex = 519
        Me.LblClassSectionSubSection.Text = "Sub-Section"
        '
        'TxtSelectAll
        '
        Me.TxtSelectAll.AgAllowUserToEnableMasterHelp = False
        Me.TxtSelectAll.AgMandatory = True
        Me.TxtSelectAll.AgMasterHelp = False
        Me.TxtSelectAll.AgNumberLeftPlaces = 0
        Me.TxtSelectAll.AgNumberNegetiveAllow = False
        Me.TxtSelectAll.AgNumberRightPlaces = 0
        Me.TxtSelectAll.AgPickFromLastValue = False
        Me.TxtSelectAll.AgRowFilter = ""
        Me.TxtSelectAll.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSelectAll.AgSelectedValue = Nothing
        Me.TxtSelectAll.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSelectAll.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtSelectAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectAll.Location = New System.Drawing.Point(332, 142)
        Me.TxtSelectAll.MaxLength = 3
        Me.TxtSelectAll.Name = "TxtSelectAll"
        Me.TxtSelectAll.Size = New System.Drawing.Size(48, 21)
        Me.TxtSelectAll.TabIndex = 3
        '
        'LblSelectAll
        '
        Me.LblSelectAll.AutoSize = True
        Me.LblSelectAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectAll.Location = New System.Drawing.Point(180, 146)
        Me.LblSelectAll.Name = "LblSelectAll"
        Me.LblSelectAll.Size = New System.Drawing.Size(108, 13)
        Me.LblSelectAll.TabIndex = 524
        Me.LblSelectAll.Text = "Select All Student"
        '
        'LblSelectAllReq
        '
        Me.LblSelectAllReq.AutoSize = True
        Me.LblSelectAllReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSelectAllReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSelectAllReq.Location = New System.Drawing.Point(319, 150)
        Me.LblSelectAllReq.Name = "LblSelectAllReq"
        Me.LblSelectAllReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSelectAllReq.TabIndex = 525
        Me.LblSelectAllReq.Text = "Ä"
        '
        'LblStreamYearSemesterReq
        '
        Me.LblStreamYearSemesterReq.AutoSize = True
        Me.LblStreamYearSemesterReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblStreamYearSemesterReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStreamYearSemesterReq.Location = New System.Drawing.Point(319, 79)
        Me.LblStreamYearSemesterReq.Name = "LblStreamYearSemesterReq"
        Me.LblStreamYearSemesterReq.Size = New System.Drawing.Size(10, 7)
        Me.LblStreamYearSemesterReq.TabIndex = 528
        Me.LblStreamYearSemesterReq.Text = "Ä"
        '
        'TxtStreamYearSemester
        '
        Me.TxtStreamYearSemester.AgAllowUserToEnableMasterHelp = False
        Me.TxtStreamYearSemester.AgMandatory = True
        Me.TxtStreamYearSemester.AgMasterHelp = False
        Me.TxtStreamYearSemester.AgNumberLeftPlaces = 0
        Me.TxtStreamYearSemester.AgNumberNegetiveAllow = False
        Me.TxtStreamYearSemester.AgNumberRightPlaces = 0
        Me.TxtStreamYearSemester.AgPickFromLastValue = False
        Me.TxtStreamYearSemester.AgRowFilter = ""
        Me.TxtStreamYearSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStreamYearSemester.AgSelectedValue = Nothing
        Me.TxtStreamYearSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStreamYearSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(332, 75)
        Me.TxtStreamYearSemester.MaxLength = 50
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(325, 21)
        Me.TxtStreamYearSemester.TabIndex = 526
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(180, 78)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(138, 13)
        Me.LblStreamYearSemester.TabIndex = 527
        Me.LblStreamYearSemester.Text = "Stream Year Semester"
        '
        'FrmSubSectionAssignEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 616)
        Me.Controls.Add(Me.LblStreamYearSemesterReq)
        Me.Controls.Add(Me.TxtStreamYearSemester)
        Me.Controls.Add(Me.LblStreamYearSemester)
        Me.Controls.Add(Me.LblSelectAllReq)
        Me.Controls.Add(Me.TxtSelectAll)
        Me.Controls.Add(Me.LblSelectAll)
        Me.Controls.Add(Me.BtnFillStudent)
        Me.Controls.Add(Me.LblClassSectionSubSectionReq)
        Me.Controls.Add(Me.TxtClassSectionSubSection)
        Me.Controls.Add(Me.LblClassSectionSubSection)
        Me.Controls.Add(Me.TxtTotalStudent)
        Me.Controls.Add(Me.LblTotalStudent)
        Me.Controls.Add(Me.LblClassSectionReq)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtClassSection)
        Me.Controls.Add(Me.LblClassSection)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSubSectionAssignEntry"
        Me.Text = "Sub-Section Assign Entry"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtClassSection As AgControls.AgTextBox
    Friend WithEvents LblClassSection As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel

    Private Sub FrmClassSectionSemesterAdmission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents BtnFillStudent As System.Windows.Forms.Button
    Friend WithEvents LblClassSectionReq As System.Windows.Forms.Label
    Friend WithEvents LblTotalStudent As System.Windows.Forms.Label
    Friend WithEvents TxtTotalStudent As AgControls.AgTextBox
    Friend WithEvents LblClassSectionSubSectionReq As System.Windows.Forms.Label
    Friend WithEvents TxtClassSectionSubSection As AgControls.AgTextBox
    Friend WithEvents LblClassSectionSubSection As System.Windows.Forms.Label
    Friend WithEvents TxtSelectAll As AgControls.AgTextBox
    Friend WithEvents LblSelectAll As System.Windows.Forms.Label
    Friend WithEvents LblSelectAllReq As System.Windows.Forms.Label
    Friend WithEvents LblStreamYearSemesterReq As System.Windows.Forms.Label
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamYearSemester As System.Windows.Forms.Label
End Class
