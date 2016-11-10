<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExpense
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
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.TxtOnEveryKms = New AgControls.AgTextBox
        Me.LblOnEveryKms = New System.Windows.Forms.Label
        Me.TxtOnEveryDays = New AgControls.AgTextBox
        Me.LblOnEveryDays = New System.Windows.Forms.Label
        Me.LblExpenseTypeReq = New System.Windows.Forms.Label
        Me.TxtExpenseType = New AgControls.AgTextBox
        Me.LblExpenseType = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(286, 127)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Ä"
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
        Me.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescription.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(302, 119)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(325, 18)
        Me.TxtDescription.TabIndex = 0
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(187, 121)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(92, 15)
        Me.LblDescription.TabIndex = 14
        Me.LblDescription.Text = "Expense Name"
        '
        'TxtOnEveryKms
        '
        Me.TxtOnEveryKms.AgMandatory = False
        Me.TxtOnEveryKms.AgMasterHelp = False
        Me.TxtOnEveryKms.AgNumberLeftPlaces = 8
        Me.TxtOnEveryKms.AgNumberNegetiveAllow = False
        Me.TxtOnEveryKms.AgNumberRightPlaces = 0
        Me.TxtOnEveryKms.AgPickFromLastValue = False
        Me.TxtOnEveryKms.AgRowFilter = ""
        Me.TxtOnEveryKms.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOnEveryKms.AgSelectedValue = Nothing
        Me.TxtOnEveryKms.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOnEveryKms.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtOnEveryKms.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOnEveryKms.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOnEveryKms.Location = New System.Drawing.Point(302, 159)
        Me.TxtOnEveryKms.Name = "TxtOnEveryKms"
        Me.TxtOnEveryKms.Size = New System.Drawing.Size(100, 18)
        Me.TxtOnEveryKms.TabIndex = 2
        Me.TxtOnEveryKms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblOnEveryKms
        '
        Me.LblOnEveryKms.AutoSize = True
        Me.LblOnEveryKms.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOnEveryKms.Location = New System.Drawing.Point(187, 162)
        Me.LblOnEveryKms.Name = "LblOnEveryKms"
        Me.LblOnEveryKms.Size = New System.Drawing.Size(93, 13)
        Me.LblOnEveryKms.TabIndex = 17
        Me.LblOnEveryKms.Text = "On Every Kms."
        '
        'TxtOnEveryDays
        '
        Me.TxtOnEveryDays.AgMandatory = False
        Me.TxtOnEveryDays.AgMasterHelp = False
        Me.TxtOnEveryDays.AgNumberLeftPlaces = 8
        Me.TxtOnEveryDays.AgNumberNegetiveAllow = False
        Me.TxtOnEveryDays.AgNumberRightPlaces = 0
        Me.TxtOnEveryDays.AgPickFromLastValue = False
        Me.TxtOnEveryDays.AgRowFilter = ""
        Me.TxtOnEveryDays.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOnEveryDays.AgSelectedValue = Nothing
        Me.TxtOnEveryDays.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOnEveryDays.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtOnEveryDays.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOnEveryDays.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOnEveryDays.Location = New System.Drawing.Point(527, 159)
        Me.TxtOnEveryDays.Name = "TxtOnEveryDays"
        Me.TxtOnEveryDays.Size = New System.Drawing.Size(100, 18)
        Me.TxtOnEveryDays.TabIndex = 3
        Me.TxtOnEveryDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblOnEveryDays
        '
        Me.LblOnEveryDays.AutoSize = True
        Me.LblOnEveryDays.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOnEveryDays.Location = New System.Drawing.Point(412, 162)
        Me.LblOnEveryDays.Name = "LblOnEveryDays"
        Me.LblOnEveryDays.Size = New System.Drawing.Size(93, 13)
        Me.LblOnEveryDays.TabIndex = 19
        Me.LblOnEveryDays.Text = "On Every Days"
        '
        'LblExpenseTypeReq
        '
        Me.LblExpenseTypeReq.AutoSize = True
        Me.LblExpenseTypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblExpenseTypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblExpenseTypeReq.Location = New System.Drawing.Point(286, 147)
        Me.LblExpenseTypeReq.Name = "LblExpenseTypeReq"
        Me.LblExpenseTypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblExpenseTypeReq.TabIndex = 23
        Me.LblExpenseTypeReq.Text = "Ä"
        '
        'TxtExpenseType
        '
        Me.TxtExpenseType.AgMandatory = True
        Me.TxtExpenseType.AgMasterHelp = False
        Me.TxtExpenseType.AgNumberLeftPlaces = 0
        Me.TxtExpenseType.AgNumberNegetiveAllow = False
        Me.TxtExpenseType.AgNumberRightPlaces = 0
        Me.TxtExpenseType.AgPickFromLastValue = False
        Me.TxtExpenseType.AgRowFilter = ""
        Me.TxtExpenseType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtExpenseType.AgSelectedValue = Nothing
        Me.TxtExpenseType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtExpenseType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtExpenseType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtExpenseType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtExpenseType.Location = New System.Drawing.Point(302, 139)
        Me.TxtExpenseType.MaxLength = 50
        Me.TxtExpenseType.Name = "TxtExpenseType"
        Me.TxtExpenseType.Size = New System.Drawing.Size(325, 18)
        Me.TxtExpenseType.TabIndex = 1
        '
        'LblExpenseType
        '
        Me.LblExpenseType.AutoSize = True
        Me.LblExpenseType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblExpenseType.Location = New System.Drawing.Point(187, 141)
        Me.LblExpenseType.Name = "LblExpenseType"
        Me.LblExpenseType.Size = New System.Drawing.Size(84, 15)
        Me.LblExpenseType.TabIndex = 22
        Me.LblExpenseType.Text = "Expense Type"
        '
        'FrmExpense
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 266)
        Me.Controls.Add(Me.LblExpenseTypeReq)
        Me.Controls.Add(Me.TxtExpenseType)
        Me.Controls.Add(Me.LblExpenseType)
        Me.Controls.Add(Me.TxtOnEveryDays)
        Me.Controls.Add(Me.LblOnEveryDays)
        Me.Controls.Add(Me.TxtOnEveryKms)
        Me.Controls.Add(Me.LblOnEveryKms)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.KeyPreview = True
        Me.Name = "FrmExpense"
        Me.Text = "Expense Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents TxtOnEveryKms As AgControls.AgTextBox
    Friend WithEvents LblOnEveryKms As System.Windows.Forms.Label
    Friend WithEvents TxtOnEveryDays As AgControls.AgTextBox
    Friend WithEvents LblOnEveryDays As System.Windows.Forms.Label
    Friend WithEvents LblExpenseTypeReq As System.Windows.Forms.Label
    Friend WithEvents TxtExpenseType As AgControls.AgTextBox
    Friend WithEvents LblExpenseType As System.Windows.Forms.Label
End Class
