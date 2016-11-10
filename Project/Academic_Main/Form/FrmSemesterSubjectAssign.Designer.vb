<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSemesterSubjectAssign
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
        Me.LblSubjectList = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.TxtStreamyearSemester = New AgControls.AgTextBox
        Me.LblStreamyearSemester = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtClassSection = New AgControls.AgTextBox
        Me.LblClassSection = New System.Windows.Forms.Label
        Me.TxtAdmissionDocId = New AgControls.AgTextBox
        Me.LblStudentName = New System.Windows.Forms.Label
        Me.LblStreamyearSemesterReq = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblSubjectList
        '
        Me.LblSubjectList.BackColor = System.Drawing.Color.Cornsilk
        Me.LblSubjectList.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubjectList.Location = New System.Drawing.Point(0, 0)
        Me.LblSubjectList.Name = "LblSubjectList"
        Me.LblSubjectList.Size = New System.Drawing.Size(968, 27)
        Me.LblSubjectList.TabIndex = 10
        Me.LblSubjectList.Text = "Student List"
        Me.LblSubjectList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Location = New System.Drawing.Point(822, 92)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(158, 29)
        Me.BtnFill.TabIndex = 5
        Me.BtnFill.Text = "Fill &Student"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'TxtStreamyearSemester
        '
        Me.TxtStreamyearSemester.AgMandatory = True
        Me.TxtStreamyearSemester.AgMasterHelp = False
        Me.TxtStreamyearSemester.AgNumberLeftPlaces = 0
        Me.TxtStreamyearSemester.AgNumberNegetiveAllow = False
        Me.TxtStreamyearSemester.AgNumberRightPlaces = 0
        Me.TxtStreamyearSemester.AgPickFromLastValue = False
        Me.TxtStreamyearSemester.AgRowFilter = ""
        Me.TxtStreamyearSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStreamyearSemester.AgSelectedValue = Nothing
        Me.TxtStreamyearSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStreamyearSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStreamyearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStreamyearSemester.Location = New System.Drawing.Point(305, 50)
        Me.TxtStreamyearSemester.MaxLength = 123
        Me.TxtStreamyearSemester.Name = "TxtStreamyearSemester"
        Me.TxtStreamyearSemester.Size = New System.Drawing.Size(325, 21)
        Me.TxtStreamyearSemester.TabIndex = 1
        '
        'LblStreamyearSemester
        '
        Me.LblStreamyearSemester.AutoSize = True
        Me.LblStreamyearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamyearSemester.Location = New System.Drawing.Point(176, 54)
        Me.LblStreamyearSemester.Name = "LblStreamyearSemester"
        Me.LblStreamyearSemester.Size = New System.Drawing.Size(62, 13)
        Me.LblStreamyearSemester.TabIndex = 674
        Me.LblStreamyearSemester.Text = "Semester"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LblSubjectList)
        Me.Panel1.Location = New System.Drawing.Point(12, 125)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(968, 28)
        Me.Panel1.TabIndex = 673
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(12, 153)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(968, 443)
        Me.Pnl1.TabIndex = 6
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
        Me.Topctrl1.Size = New System.Drawing.Size(992, 41)
        Me.Topctrl1.TabIndex = 7
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
        Me.TxtClassSection.AgMandatory = False
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
        Me.TxtClassSection.Location = New System.Drawing.Point(305, 73)
        Me.TxtClassSection.MaxLength = 50
        Me.TxtClassSection.Name = "TxtClassSection"
        Me.TxtClassSection.Size = New System.Drawing.Size(325, 21)
        Me.TxtClassSection.TabIndex = 2
        '
        'LblClassSection
        '
        Me.LblClassSection.AutoSize = True
        Me.LblClassSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSection.Location = New System.Drawing.Point(176, 76)
        Me.LblClassSection.Name = "LblClassSection"
        Me.LblClassSection.Size = New System.Drawing.Size(85, 13)
        Me.LblClassSection.TabIndex = 680
        Me.LblClassSection.Text = "Class/Section"
        '
        'TxtAdmissionDocId
        '
        Me.TxtAdmissionDocId.AgMandatory = False
        Me.TxtAdmissionDocId.AgMasterHelp = False
        Me.TxtAdmissionDocId.AgNumberLeftPlaces = 0
        Me.TxtAdmissionDocId.AgNumberNegetiveAllow = False
        Me.TxtAdmissionDocId.AgNumberRightPlaces = 0
        Me.TxtAdmissionDocId.AgPickFromLastValue = False
        Me.TxtAdmissionDocId.AgRowFilter = ""
        Me.TxtAdmissionDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdmissionDocId.AgSelectedValue = Nothing
        Me.TxtAdmissionDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdmissionDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdmissionDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionDocId.Location = New System.Drawing.Point(305, 96)
        Me.TxtAdmissionDocId.MaxLength = 123
        Me.TxtAdmissionDocId.Name = "TxtAdmissionDocId"
        Me.TxtAdmissionDocId.Size = New System.Drawing.Size(325, 21)
        Me.TxtAdmissionDocId.TabIndex = 3
        '
        'LblStudentName
        '
        Me.LblStudentName.AutoSize = True
        Me.LblStudentName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStudentName.Location = New System.Drawing.Point(176, 100)
        Me.LblStudentName.Name = "LblStudentName"
        Me.LblStudentName.Size = New System.Drawing.Size(88, 13)
        Me.LblStudentName.TabIndex = 682
        Me.LblStudentName.Text = "Student Name"
        '
        'LblStreamyearSemesterReq
        '
        Me.LblStreamyearSemesterReq.AutoSize = True
        Me.LblStreamyearSemesterReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblStreamyearSemesterReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStreamyearSemesterReq.Location = New System.Drawing.Point(292, 57)
        Me.LblStreamyearSemesterReq.Name = "LblStreamyearSemesterReq"
        Me.LblStreamyearSemesterReq.Size = New System.Drawing.Size(10, 7)
        Me.LblStreamyearSemesterReq.TabIndex = 683
        Me.LblStreamyearSemesterReq.Text = "Ä"
        '
        'FrmSemesterSubjectAssign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.LblStreamyearSemesterReq)
        Me.Controls.Add(Me.TxtAdmissionDocId)
        Me.Controls.Add(Me.TxtClassSection)
        Me.Controls.Add(Me.LblStudentName)
        Me.Controls.Add(Me.LblClassSection)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.TxtStreamyearSemester)
        Me.Controls.Add(Me.LblStreamyearSemester)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSemesterSubjectAssign"
        Me.Text = "Semester Subject Assign Entry"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblSubjectList As System.Windows.Forms.Label
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Friend WithEvents TxtStreamyearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamyearSemester As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtClassSection As AgControls.AgTextBox
    Friend WithEvents LblClassSection As System.Windows.Forms.Label
    Friend WithEvents TxtAdmissionDocId As AgControls.AgTextBox
    Friend WithEvents LblStudentName As System.Windows.Forms.Label
    Friend WithEvents LblStreamyearSemesterReq As System.Windows.Forms.Label
End Class
