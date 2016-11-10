<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubjectSwap
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubject = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtSemester = New AgControls.AgTextBox
        Me.LblSemester = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtSemsterSwap = New AgControls.AgTextBox
        Me.LblSemesterSwap = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtSubjectSwap = New AgControls.AgTextBox
        Me.LblSubjectSwap = New System.Windows.Forms.Label
        Me.BtnSave = New System.Windows.Forms.Button
        Me.BtnExit = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(144, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Ä"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(42, 125)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(443, 217)
        Me.Pnl1.TabIndex = 5
        '
        'TxtSubject
        '
        Me.TxtSubject.AgMandatory = True
        Me.TxtSubject.AgMasterHelp = False
        Me.TxtSubject.AgNumberLeftPlaces = 0
        Me.TxtSubject.AgNumberNegetiveAllow = False
        Me.TxtSubject.AgNumberRightPlaces = 0
        Me.TxtSubject.AgPickFromLastValue = False
        Me.TxtSubject.AgRowFilter = ""
        Me.TxtSubject.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtSubject.AgSelectedValue = Nothing
        Me.TxtSubject.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubject.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubject.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubject.Location = New System.Drawing.Point(160, 54)
        Me.TxtSubject.MaxLength = 0
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(244, 21)
        Me.TxtSubject.TabIndex = 1
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(40, 58)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(50, 13)
        Me.LblSubject.TabIndex = 4
        Me.LblSubject.Text = "Subject"
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(410, 98)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(75, 23)
        Me.BtnFill.TabIndex = 4
        Me.BtnFill.Text = "&Fill"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(144, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Ä"
        '
        'TxtSemester
        '
        Me.TxtSemester.AgMandatory = True
        Me.TxtSemester.AgMasterHelp = False
        Me.TxtSemester.AgNumberLeftPlaces = 0
        Me.TxtSemester.AgNumberNegetiveAllow = False
        Me.TxtSemester.AgNumberRightPlaces = 0
        Me.TxtSemester.AgPickFromLastValue = False
        Me.TxtSemester.AgRowFilter = ""
        Me.TxtSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtSemester.AgSelectedValue = Nothing
        Me.TxtSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSemester.Location = New System.Drawing.Point(160, 32)
        Me.TxtSemester.MaxLength = 0
        Me.TxtSemester.Name = "TxtSemester"
        Me.TxtSemester.Size = New System.Drawing.Size(244, 21)
        Me.TxtSemester.TabIndex = 0
        '
        'LblSemester
        '
        Me.LblSemester.AutoSize = True
        Me.LblSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSemester.Location = New System.Drawing.Point(40, 33)
        Me.LblSemester.Name = "LblSemester"
        Me.LblSemester.Size = New System.Drawing.Size(62, 13)
        Me.LblSemester.TabIndex = 8
        Me.LblSemester.Text = "Semester"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(144, 82)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Ä"
        '
        'TxtSemsterSwap
        '
        Me.TxtSemsterSwap.AgMandatory = True
        Me.TxtSemsterSwap.AgMasterHelp = False
        Me.TxtSemsterSwap.AgNumberLeftPlaces = 0
        Me.TxtSemsterSwap.AgNumberNegetiveAllow = False
        Me.TxtSemsterSwap.AgNumberRightPlaces = 0
        Me.TxtSemsterSwap.AgPickFromLastValue = False
        Me.TxtSemsterSwap.AgRowFilter = ""
        Me.TxtSemsterSwap.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtSemsterSwap.AgSelectedValue = Nothing
        Me.TxtSemsterSwap.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSemsterSwap.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSemsterSwap.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSemsterSwap.Location = New System.Drawing.Point(160, 76)
        Me.TxtSemsterSwap.MaxLength = 0
        Me.TxtSemsterSwap.Name = "TxtSemsterSwap"
        Me.TxtSemsterSwap.Size = New System.Drawing.Size(244, 21)
        Me.TxtSemsterSwap.TabIndex = 2
        '
        'LblSemesterSwap
        '
        Me.LblSemesterSwap.AutoSize = True
        Me.LblSemesterSwap.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSemesterSwap.Location = New System.Drawing.Point(40, 80)
        Me.LblSemesterSwap.Name = "LblSemesterSwap"
        Me.LblSemesterSwap.Size = New System.Drawing.Size(97, 13)
        Me.LblSemesterSwap.TabIndex = 11
        Me.LblSemesterSwap.Text = "Semester Swap"
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Location = New System.Drawing.Point(474, 2)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(47, 41)
        Me.Topctrl1.TabIndex = 14
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
        Me.Topctrl1.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(144, 104)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 7)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Ä"
        '
        'TxtSubjectSwap
        '
        Me.TxtSubjectSwap.AgMandatory = True
        Me.TxtSubjectSwap.AgMasterHelp = False
        Me.TxtSubjectSwap.AgNumberLeftPlaces = 0
        Me.TxtSubjectSwap.AgNumberNegetiveAllow = False
        Me.TxtSubjectSwap.AgNumberRightPlaces = 0
        Me.TxtSubjectSwap.AgPickFromLastValue = False
        Me.TxtSubjectSwap.AgRowFilter = ""
        Me.TxtSubjectSwap.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtSubjectSwap.AgSelectedValue = Nothing
        Me.TxtSubjectSwap.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubjectSwap.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubjectSwap.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubjectSwap.Location = New System.Drawing.Point(160, 98)
        Me.TxtSubjectSwap.MaxLength = 0
        Me.TxtSubjectSwap.Name = "TxtSubjectSwap"
        Me.TxtSubjectSwap.Size = New System.Drawing.Size(244, 21)
        Me.TxtSubjectSwap.TabIndex = 3
        '
        'LblSubjectSwap
        '
        Me.LblSubjectSwap.AutoSize = True
        Me.LblSubjectSwap.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubjectSwap.Location = New System.Drawing.Point(40, 102)
        Me.LblSubjectSwap.Name = "LblSubjectSwap"
        Me.LblSubjectSwap.Size = New System.Drawing.Size(50, 13)
        Me.LblSubjectSwap.TabIndex = 16
        Me.LblSubjectSwap.Text = "Subject"
        '
        'BtnSave
        '
        Me.BtnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.Location = New System.Drawing.Point(329, 348)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(75, 23)
        Me.BtnSave.TabIndex = 6
        Me.BtnSave.Text = "&Save"
        Me.BtnSave.UseVisualStyleBackColor = True
        '
        'BtnExit
        '
        Me.BtnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(410, 348)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(75, 23)
        Me.BtnExit.TabIndex = 7
        Me.BtnExit.Text = "E&xit"
        Me.BtnExit.UseVisualStyleBackColor = True
        '
        'FrmSubjectSwap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 380)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnSave)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtSubjectSwap)
        Me.Controls.Add(Me.LblSubjectSwap)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtSemsterSwap)
        Me.Controls.Add(Me.LblSemesterSwap)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtSemester)
        Me.Controls.Add(Me.LblSemester)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.LblSubject)
        Me.KeyPreview = True
        Me.Name = "FrmSubjectSwap"
        Me.Text = "FrmSubjectSwap"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtSubject As AgControls.AgTextBox
    Friend WithEvents LblSubject As System.Windows.Forms.Label
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtSemester As AgControls.AgTextBox
    Friend WithEvents LblSemester As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSemsterSwap As AgControls.AgTextBox
    Friend WithEvents LblSemesterSwap As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtSubjectSwap As AgControls.AgTextBox
    Friend WithEvents LblSubjectSwap As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents BtnExit As System.Windows.Forms.Button
End Class
