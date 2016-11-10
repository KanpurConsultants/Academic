<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStudentSubjectChange
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
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LblStudentNameReq = New System.Windows.Forms.Label
        Me.TxtAdmissionDocId = New AgControls.AgTextBox
        Me.LblStudentName = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblSubjectList = New System.Windows.Forms.Label
        Me.LblStreamyearSemesterReq = New System.Windows.Forms.Label
        Me.TxtStreamyearSemester = New AgControls.AgTextBox
        Me.LblStreamyearSemester = New System.Windows.Forms.Label
        Me.BtnFillSubject = New System.Windows.Forms.Button
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
        Me.Topctrl1.TabIndex = 4
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
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(149, 161)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(609, 393)
        Me.Pnl1.TabIndex = 3
        '
        'LblStudentNameReq
        '
        Me.LblStudentNameReq.AutoSize = True
        Me.LblStudentNameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblStudentNameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStudentNameReq.Location = New System.Drawing.Point(303, 66)
        Me.LblStudentNameReq.Name = "LblStudentNameReq"
        Me.LblStudentNameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblStudentNameReq.TabIndex = 661
        Me.LblStudentNameReq.Text = "Ä"
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
        Me.TxtAdmissionDocId.Location = New System.Drawing.Point(316, 58)
        Me.TxtAdmissionDocId.MaxLength = 123
        Me.TxtAdmissionDocId.Name = "TxtAdmissionDocId"
        Me.TxtAdmissionDocId.Size = New System.Drawing.Size(350, 21)
        Me.TxtAdmissionDocId.TabIndex = 0
        '
        'LblStudentName
        '
        Me.LblStudentName.AutoSize = True
        Me.LblStudentName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStudentName.Location = New System.Drawing.Point(202, 62)
        Me.LblStudentName.Name = "LblStudentName"
        Me.LblStudentName.Size = New System.Drawing.Size(88, 13)
        Me.LblStudentName.TabIndex = 660
        Me.LblStudentName.Text = "Student Name"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LblSubjectList)
        Me.Panel1.Location = New System.Drawing.Point(149, 131)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(609, 28)
        Me.Panel1.TabIndex = 662
        '
        'LblSubjectList
        '
        Me.LblSubjectList.BackColor = System.Drawing.Color.Cornsilk
        Me.LblSubjectList.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubjectList.Location = New System.Drawing.Point(0, 1)
        Me.LblSubjectList.Name = "LblSubjectList"
        Me.LblSubjectList.Size = New System.Drawing.Size(606, 27)
        Me.LblSubjectList.TabIndex = 10
        Me.LblSubjectList.Text = "Subject List"
        Me.LblSubjectList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblStreamyearSemesterReq
        '
        Me.LblStreamyearSemesterReq.AutoSize = True
        Me.LblStreamyearSemesterReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblStreamyearSemesterReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStreamyearSemesterReq.Location = New System.Drawing.Point(303, 88)
        Me.LblStreamyearSemesterReq.Name = "LblStreamyearSemesterReq"
        Me.LblStreamyearSemesterReq.Size = New System.Drawing.Size(10, 7)
        Me.LblStreamyearSemesterReq.TabIndex = 665
        Me.LblStreamyearSemesterReq.Text = "Ä"
        '
        'TxtStreamyearSemester
        '
        Me.TxtStreamyearSemester.AgMandatory = False
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
        Me.TxtStreamyearSemester.Location = New System.Drawing.Point(316, 80)
        Me.TxtStreamyearSemester.MaxLength = 123
        Me.TxtStreamyearSemester.Name = "TxtStreamyearSemester"
        Me.TxtStreamyearSemester.Size = New System.Drawing.Size(350, 21)
        Me.TxtStreamyearSemester.TabIndex = 1
        '
        'LblStreamyearSemester
        '
        Me.LblStreamyearSemester.AutoSize = True
        Me.LblStreamyearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamyearSemester.Location = New System.Drawing.Point(202, 84)
        Me.LblStreamyearSemester.Name = "LblStreamyearSemester"
        Me.LblStreamyearSemester.Size = New System.Drawing.Size(55, 13)
        Me.LblStreamyearSemester.TabIndex = 664
        Me.LblStreamyearSemester.Text = "Smester"
        '
        'BtnFillSubject
        '
        Me.BtnFillSubject.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillSubject.Location = New System.Drawing.Point(675, 78)
        Me.BtnFillSubject.Name = "BtnFillSubject"
        Me.BtnFillSubject.Size = New System.Drawing.Size(83, 23)
        Me.BtnFillSubject.TabIndex = 2
        Me.BtnFillSubject.Text = "Fill &Subject"
        Me.BtnFillSubject.UseVisualStyleBackColor = True
        '
        'FrmStudentSubjectChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 592)
        Me.Controls.Add(Me.BtnFillSubject)
        Me.Controls.Add(Me.LblStreamyearSemesterReq)
        Me.Controls.Add(Me.TxtStreamyearSemester)
        Me.Controls.Add(Me.LblStreamyearSemester)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblStudentNameReq)
        Me.Controls.Add(Me.TxtAdmissionDocId)
        Me.Controls.Add(Me.LblStudentName)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmStudentSubjectChange"
        Me.Text = "Subject Change"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents LblStudentNameReq As System.Windows.Forms.Label
    Friend WithEvents TxtAdmissionDocId As AgControls.AgTextBox
    Friend WithEvents LblStudentName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LblSubjectList As System.Windows.Forms.Label
    Friend WithEvents LblStreamyearSemesterReq As System.Windows.Forms.Label
    Friend WithEvents TxtStreamyearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamyearSemester As System.Windows.Forms.Label
    Friend WithEvents BtnFillSubject As System.Windows.Forms.Button
End Class
