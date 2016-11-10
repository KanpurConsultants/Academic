<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTimeSlot
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
        Me.TxtDuration = New AgControls.AgTextBox
        Me.LblDuration = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.DtpStartTime = New System.Windows.Forms.DateTimePicker
        Me.LblStartTime = New System.Windows.Forms.Label
        Me.LblStartTimeReq = New System.Windows.Forms.Label
        Me.DtpEndTime = New System.Windows.Forms.DateTimePicker
        Me.LblEndTime = New System.Windows.Forms.Label
        Me.LblEndTimeReq = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TxtDuration
        '
        Me.TxtDuration.AgMandatory = True
        Me.TxtDuration.AgMasterHelp = True
        Me.TxtDuration.AgNumberLeftPlaces = 3
        Me.TxtDuration.AgNumberNegetiveAllow = False
        Me.TxtDuration.AgNumberRightPlaces = 0
        Me.TxtDuration.AgPickFromLastValue = False
        Me.TxtDuration.AgRowFilter = ""
        Me.TxtDuration.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDuration.AgSelectedValue = Nothing
        Me.TxtDuration.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDuration.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtDuration.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDuration.Location = New System.Drawing.Point(349, 156)
        Me.TxtDuration.MaxLength = 50
        Me.TxtDuration.Name = "TxtDuration"
        Me.TxtDuration.ReadOnly = True
        Me.TxtDuration.Size = New System.Drawing.Size(61, 21)
        Me.TxtDuration.TabIndex = 3
        Me.TxtDuration.TabStop = False
        '
        'LblDuration
        '
        Me.LblDuration.AutoSize = True
        Me.LblDuration.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDuration.Location = New System.Drawing.Point(255, 159)
        Me.LblDuration.Name = "LblDuration"
        Me.LblDuration.Size = New System.Drawing.Size(215, 13)
        Me.LblDuration.TabIndex = 13
        Me.LblDuration.Text = "Slot Duration                    (Minutes)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(336, 119)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 11
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
        Me.TxtDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(349, 112)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(325, 21)
        Me.TxtDescription.TabIndex = 0
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(255, 115)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(71, 13)
        Me.LblDescription.TabIndex = 9
        Me.LblDescription.Text = "Description"
        '
        'DtpStartTime
        '
        Me.DtpStartTime.CustomFormat = "HH:mm"
        Me.DtpStartTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpStartTime.Location = New System.Drawing.Point(349, 134)
        Me.DtpStartTime.Name = "DtpStartTime"
        Me.DtpStartTime.ShowUpDown = True
        Me.DtpStartTime.Size = New System.Drawing.Size(61, 21)
        Me.DtpStartTime.TabIndex = 1
        '
        'LblStartTime
        '
        Me.LblStartTime.AutoSize = True
        Me.LblStartTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStartTime.Location = New System.Drawing.Point(255, 137)
        Me.LblStartTime.Name = "LblStartTime"
        Me.LblStartTime.Size = New System.Drawing.Size(67, 13)
        Me.LblStartTime.TabIndex = 280
        Me.LblStartTime.Text = "Start Time"
        '
        'LblStartTimeReq
        '
        Me.LblStartTimeReq.AutoSize = True
        Me.LblStartTimeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblStartTimeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStartTimeReq.Location = New System.Drawing.Point(336, 141)
        Me.LblStartTimeReq.Name = "LblStartTimeReq"
        Me.LblStartTimeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblStartTimeReq.TabIndex = 279
        Me.LblStartTimeReq.Text = "Ä"
        '
        'DtpEndTime
        '
        Me.DtpEndTime.CustomFormat = "HH:mm"
        Me.DtpEndTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtpEndTime.Location = New System.Drawing.Point(613, 134)
        Me.DtpEndTime.Name = "DtpEndTime"
        Me.DtpEndTime.ShowUpDown = True
        Me.DtpEndTime.Size = New System.Drawing.Size(61, 21)
        Me.DtpEndTime.TabIndex = 2
        '
        'LblEndTime
        '
        Me.LblEndTime.AutoSize = True
        Me.LblEndTime.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEndTime.Location = New System.Drawing.Point(531, 138)
        Me.LblEndTime.Name = "LblEndTime"
        Me.LblEndTime.Size = New System.Drawing.Size(60, 13)
        Me.LblEndTime.TabIndex = 278
        Me.LblEndTime.Text = "End Time"
        '
        'LblEndTimeReq
        '
        Me.LblEndTimeReq.AutoSize = True
        Me.LblEndTimeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblEndTimeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblEndTimeReq.Location = New System.Drawing.Point(597, 141)
        Me.LblEndTimeReq.Name = "LblEndTimeReq"
        Me.LblEndTimeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblEndTimeReq.TabIndex = 277
        Me.LblEndTimeReq.Text = "Ä"
        '
        'FrmTimeSlot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 266)
        Me.Controls.Add(Me.DtpStartTime)
        Me.Controls.Add(Me.LblStartTime)
        Me.Controls.Add(Me.LblStartTimeReq)
        Me.Controls.Add(Me.DtpEndTime)
        Me.Controls.Add(Me.LblEndTime)
        Me.Controls.Add(Me.LblEndTimeReq)
        Me.Controls.Add(Me.TxtDuration)
        Me.Controls.Add(Me.LblDuration)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmTimeSlot"
        Me.Text = "Time Slot Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtDuration As AgControls.AgTextBox
    Friend WithEvents LblDuration As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents DtpStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblStartTime As System.Windows.Forms.Label
    Friend WithEvents LblStartTimeReq As System.Windows.Forms.Label
    Friend WithEvents DtpEndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents LblEndTime As System.Windows.Forms.Label
    Friend WithEvents LblEndTimeReq As System.Windows.Forms.Label
End Class
