<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubject
    Inherits System.Windows.Forms.Form
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If Disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.          [Ag]
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtManualCode = New AgControls.AgTextBox
        Me.LblManualCode = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.LblBank_NameReq = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtDisplayName = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtSubjectType = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtSubjectGroup = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.LblIsGeneralProficiencyReq = New System.Windows.Forms.Label
        Me.TxtIsGeneralProficiency = New AgControls.AgTextBox
        Me.LblIsGeneralProficiency = New System.Windows.Forms.Label
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
        'TxtManualCode
        '
        Me.TxtManualCode.AgMandatory = True
        Me.TxtManualCode.AgMasterHelp = True
        Me.TxtManualCode.AgNumberLeftPlaces = 0
        Me.TxtManualCode.AgNumberNegetiveAllow = False
        Me.TxtManualCode.AgNumberRightPlaces = 0
        Me.TxtManualCode.AgPickFromLastValue = False
        Me.TxtManualCode.AgRowFilter = ""
        Me.TxtManualCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtManualCode.AgSelectedValue = Nothing
        Me.TxtManualCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtManualCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtManualCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManualCode.Location = New System.Drawing.Point(339, 110)
        Me.TxtManualCode.MaxLength = 20
        Me.TxtManualCode.Name = "TxtManualCode"
        Me.TxtManualCode.Size = New System.Drawing.Size(176, 21)
        Me.TxtManualCode.TabIndex = 0
        '
        'LblManualCode
        '
        Me.LblManualCode.AutoSize = True
        Me.LblManualCode.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualCode.Location = New System.Drawing.Point(236, 114)
        Me.LblManualCode.Name = "LblManualCode"
        Me.LblManualCode.Size = New System.Drawing.Size(81, 13)
        Me.LblManualCode.TabIndex = 0
        Me.LblManualCode.Text = "Manual Code"
        '
        'TxtDescription
        '
        Me.TxtDescription.AgMandatory = True
        Me.TxtDescription.AgMasterHelp = True
        Me.TxtDescription.AgNumberLeftPlaces = 0
        Me.TxtDescription.AgNumberNegetiveAllow = False
        Me.TxtDescription.AgNumberRightPlaces = 0
        Me.TxtDescription.AgPickFromLastValue = False
        Me.TxtDescription.AgRowFilter = ""
        Me.TxtDescription.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDescription.AgSelectedValue = Nothing
        Me.TxtDescription.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDescription.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(339, 156)
        Me.TxtDescription.MaxLength = 123
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(325, 21)
        Me.TxtDescription.TabIndex = 2
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(236, 160)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(71, 13)
        Me.LblDescription.TabIndex = 0
        Me.LblDescription.Text = "Description"
        '
        'LblBank_NameReq
        '
        Me.LblBank_NameReq.AutoSize = True
        Me.LblBank_NameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBank_NameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBank_NameReq.Location = New System.Drawing.Point(323, 117)
        Me.LblBank_NameReq.Name = "LblBank_NameReq"
        Me.LblBank_NameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBank_NameReq.TabIndex = 2
        Me.LblBank_NameReq.Text = "Ä"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(323, 163)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(323, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Ä"
        '
        'TxtDisplayName
        '
        Me.TxtDisplayName.AgMandatory = True
        Me.TxtDisplayName.AgMasterHelp = True
        Me.TxtDisplayName.AgNumberLeftPlaces = 0
        Me.TxtDisplayName.AgNumberNegetiveAllow = False
        Me.TxtDisplayName.AgNumberRightPlaces = 0
        Me.TxtDisplayName.AgPickFromLastValue = False
        Me.TxtDisplayName.AgRowFilter = ""
        Me.TxtDisplayName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDisplayName.AgSelectedValue = Nothing
        Me.TxtDisplayName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDisplayName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDisplayName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDisplayName.Location = New System.Drawing.Point(339, 133)
        Me.TxtDisplayName.MaxLength = 100
        Me.TxtDisplayName.Name = "TxtDisplayName"
        Me.TxtDisplayName.Size = New System.Drawing.Size(325, 21)
        Me.TxtDisplayName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(236, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Display Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(323, 186)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Ä"
        '
        'TxtSubjectType
        '
        Me.TxtSubjectType.AgMandatory = True
        Me.TxtSubjectType.AgMasterHelp = False
        Me.TxtSubjectType.AgNumberLeftPlaces = 0
        Me.TxtSubjectType.AgNumberNegetiveAllow = False
        Me.TxtSubjectType.AgNumberRightPlaces = 0
        Me.TxtSubjectType.AgPickFromLastValue = False
        Me.TxtSubjectType.AgRowFilter = ""
        Me.TxtSubjectType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubjectType.AgSelectedValue = Nothing
        Me.TxtSubjectType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubjectType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubjectType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubjectType.Location = New System.Drawing.Point(339, 179)
        Me.TxtSubjectType.MaxLength = 20
        Me.TxtSubjectType.Name = "TxtSubjectType"
        Me.TxtSubjectType.Size = New System.Drawing.Size(99, 21)
        Me.TxtSubjectType.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(236, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Subject Type"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(323, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 7)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Ä"
        '
        'TxtSubjectGroup
        '
        Me.TxtSubjectGroup.AgMandatory = True
        Me.TxtSubjectGroup.AgMasterHelp = False
        Me.TxtSubjectGroup.AgNumberLeftPlaces = 0
        Me.TxtSubjectGroup.AgNumberNegetiveAllow = False
        Me.TxtSubjectGroup.AgNumberRightPlaces = 0
        Me.TxtSubjectGroup.AgPickFromLastValue = False
        Me.TxtSubjectGroup.AgRowFilter = ""
        Me.TxtSubjectGroup.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubjectGroup.AgSelectedValue = Nothing
        Me.TxtSubjectGroup.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubjectGroup.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubjectGroup.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubjectGroup.Location = New System.Drawing.Point(339, 202)
        Me.TxtSubjectGroup.MaxLength = 50
        Me.TxtSubjectGroup.Name = "TxtSubjectGroup"
        Me.TxtSubjectGroup.Size = New System.Drawing.Size(325, 21)
        Me.TxtSubjectGroup.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(236, 206)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Subject Group"
        '
        'LblIsGeneralProficiencyReq
        '
        Me.LblIsGeneralProficiencyReq.AutoSize = True
        Me.LblIsGeneralProficiencyReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblIsGeneralProficiencyReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblIsGeneralProficiencyReq.Location = New System.Drawing.Point(606, 186)
        Me.LblIsGeneralProficiencyReq.Name = "LblIsGeneralProficiencyReq"
        Me.LblIsGeneralProficiencyReq.Size = New System.Drawing.Size(10, 7)
        Me.LblIsGeneralProficiencyReq.TabIndex = 15
        Me.LblIsGeneralProficiencyReq.Text = "Ä"
        '
        'TxtIsGeneralProficiency
        '
        Me.TxtIsGeneralProficiency.AgMandatory = True
        Me.TxtIsGeneralProficiency.AgMasterHelp = False
        Me.TxtIsGeneralProficiency.AgNumberLeftPlaces = 0
        Me.TxtIsGeneralProficiency.AgNumberNegetiveAllow = False
        Me.TxtIsGeneralProficiency.AgNumberRightPlaces = 0
        Me.TxtIsGeneralProficiency.AgPickFromLastValue = False
        Me.TxtIsGeneralProficiency.AgRowFilter = ""
        Me.TxtIsGeneralProficiency.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsGeneralProficiency.AgSelectedValue = Nothing
        Me.TxtIsGeneralProficiency.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsGeneralProficiency.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsGeneralProficiency.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsGeneralProficiency.Location = New System.Drawing.Point(618, 179)
        Me.TxtIsGeneralProficiency.MaxLength = 20
        Me.TxtIsGeneralProficiency.Name = "TxtIsGeneralProficiency"
        Me.TxtIsGeneralProficiency.Size = New System.Drawing.Size(46, 21)
        Me.TxtIsGeneralProficiency.TabIndex = 4
        '
        'LblIsGeneralProficiency
        '
        Me.LblIsGeneralProficiency.AutoSize = True
        Me.LblIsGeneralProficiency.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsGeneralProficiency.Location = New System.Drawing.Point(437, 183)
        Me.LblIsGeneralProficiency.Name = "LblIsGeneralProficiency"
        Me.LblIsGeneralProficiency.Size = New System.Drawing.Size(172, 13)
        Me.LblIsGeneralProficiency.TabIndex = 14
        Me.LblIsGeneralProficiency.Text = "General Proficiency (Yes/No)"
        '
        'FrmSubject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 366)
        Me.Controls.Add(Me.LblIsGeneralProficiencyReq)
        Me.Controls.Add(Me.TxtIsGeneralProficiency)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtSubjectGroup)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtSubjectType)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtDisplayName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblBank_NameReq)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtManualCode)
        Me.Controls.Add(Me.LblManualCode)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Controls.Add(Me.LblIsGeneralProficiency)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSubject"
        Me.Text = "Fee Group Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtManualCode As AgControls.AgTextBox
    Friend WithEvents LblManualCode As System.Windows.Forms.Label
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents LblBank_NameReq As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtDisplayName As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtSubjectType As AgControls.AgTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtSubjectGroup As AgControls.AgTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LblIsGeneralProficiencyReq As System.Windows.Forms.Label
    Friend WithEvents TxtIsGeneralProficiency As AgControls.AgTextBox
    Friend WithEvents LblIsGeneralProficiency As System.Windows.Forms.Label
End Class
