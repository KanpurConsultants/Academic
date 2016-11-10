<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStudentFeeChange
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
        Me.LblFeeList = New System.Windows.Forms.Label
        Me.LblStreamyearSemesterReq = New System.Windows.Forms.Label
        Me.TxtStreamyearSemester = New AgControls.AgTextBox
        Me.LblStreamyearSemester = New System.Windows.Forms.Label
        Me.BtnFilFee = New System.Windows.Forms.Button
        Me.TxtTotalFee = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
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
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(196, 140)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(481, 401)
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
        Me.Panel1.Controls.Add(Me.LblFeeList)
        Me.Panel1.Location = New System.Drawing.Point(196, 110)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(481, 28)
        Me.Panel1.TabIndex = 662
        '
        'LblFeeList
        '
        Me.LblFeeList.BackColor = System.Drawing.Color.Cornsilk
        Me.LblFeeList.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFeeList.Location = New System.Drawing.Point(0, 1)
        Me.LblFeeList.Name = "LblFeeList"
        Me.LblFeeList.Size = New System.Drawing.Size(481, 27)
        Me.LblFeeList.TabIndex = 10
        Me.LblFeeList.Text = "Fee List"
        Me.LblFeeList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'BtnFilFee
        '
        Me.BtnFilFee.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFilFee.Location = New System.Drawing.Point(675, 78)
        Me.BtnFilFee.Name = "BtnFilFee"
        Me.BtnFilFee.Size = New System.Drawing.Size(83, 23)
        Me.BtnFilFee.TabIndex = 2
        Me.BtnFilFee.Text = "Fill &Fee"
        Me.BtnFilFee.UseVisualStyleBackColor = True
        '
        'TxtTotalFee
        '
        Me.TxtTotalFee.AgMandatory = True
        Me.TxtTotalFee.AgMasterHelp = True
        Me.TxtTotalFee.AgNumberLeftPlaces = 8
        Me.TxtTotalFee.AgNumberNegetiveAllow = False
        Me.TxtTotalFee.AgNumberRightPlaces = 2
        Me.TxtTotalFee.AgPickFromLastValue = False
        Me.TxtTotalFee.AgRowFilter = ""
        Me.TxtTotalFee.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalFee.AgSelectedValue = Nothing
        Me.TxtTotalFee.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalFee.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalFee.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalFee.Location = New System.Drawing.Point(577, 547)
        Me.TxtTotalFee.MaxLength = 50
        Me.TxtTotalFee.Name = "TxtTotalFee"
        Me.TxtTotalFee.ReadOnly = True
        Me.TxtTotalFee.Size = New System.Drawing.Size(100, 21)
        Me.TxtTotalFee.TabIndex = 5
        Me.TxtTotalFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Blue
        Me.Label4.Location = New System.Drawing.Point(512, 550)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Total &Fee"
        '
        'FrmStudentFeeChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 592)
        Me.Controls.Add(Me.TxtTotalFee)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.BtnFilFee)
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
        Me.Name = "FrmStudentFeeChange"
        Me.Text = "FrmAdvance"
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
    Friend WithEvents LblFeeList As System.Windows.Forms.Label
    Friend WithEvents LblStreamyearSemesterReq As System.Windows.Forms.Label
    Friend WithEvents TxtStreamyearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamyearSemester As System.Windows.Forms.Label
    Friend WithEvents BtnFilFee As System.Windows.Forms.Button
    Friend WithEvents TxtTotalFee As AgControls.AgTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
