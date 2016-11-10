<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSemesterFeeAssign
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
        Me.BtnFill = New System.Windows.Forms.Button
        Me.TxtStreamyearSemester = New AgControls.AgTextBox
        Me.LblStreamyearSemester = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtFee = New AgControls.AgTextBox
        Me.LblFee = New System.Windows.Forms.Label
        Me.TxtAdmissionDocId = New AgControls.AgTextBox
        Me.LblStudentName = New System.Windows.Forms.Label
        Me.LblStreamyearSemesterReq = New System.Windows.Forms.Label
        Me.TxtTotalAmt = New AgControls.AgTextBox
        Me.lbltotal = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(877, 123)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(103, 29)
        Me.BtnFill.TabIndex = 5
        Me.BtnFill.Text = "Fill &Student"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'TxtStreamyearSemester
        '
        Me.TxtStreamyearSemester.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtStreamyearSemester.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStreamyearSemester.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStreamyearSemester.Location = New System.Drawing.Point(320, 50)
        Me.TxtStreamyearSemester.MaxLength = 123
        Me.TxtStreamyearSemester.Name = "TxtStreamyearSemester"
        Me.TxtStreamyearSemester.Size = New System.Drawing.Size(325, 19)
        Me.TxtStreamyearSemester.TabIndex = 0
        '
        'LblStreamyearSemester
        '
        Me.LblStreamyearSemester.AutoSize = True
        Me.LblStreamyearSemester.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamyearSemester.Location = New System.Drawing.Point(191, 54)
        Me.LblStreamyearSemester.Name = "LblStreamyearSemester"
        Me.LblStreamyearSemester.Size = New System.Drawing.Size(61, 15)
        Me.LblStreamyearSemester.TabIndex = 674
        Me.LblStreamyearSemester.Text = "Semester"
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(12, 152)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(968, 444)
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
        'TxtFee
        '
        Me.TxtFee.AgAllowUserToEnableMasterHelp = False
        Me.TxtFee.AgMandatory = False
        Me.TxtFee.AgMasterHelp = False
        Me.TxtFee.AgNumberLeftPlaces = 0
        Me.TxtFee.AgNumberNegetiveAllow = False
        Me.TxtFee.AgNumberRightPlaces = 0
        Me.TxtFee.AgPickFromLastValue = False
        Me.TxtFee.AgRowFilter = ""
        Me.TxtFee.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFee.AgSelectedValue = Nothing
        Me.TxtFee.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFee.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFee.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFee.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFee.Location = New System.Drawing.Point(320, 71)
        Me.TxtFee.MaxLength = 50
        Me.TxtFee.Name = "TxtFee"
        Me.TxtFee.Size = New System.Drawing.Size(325, 19)
        Me.TxtFee.TabIndex = 1
        '
        'LblFee
        '
        Me.LblFee.AutoSize = True
        Me.LblFee.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFee.Location = New System.Drawing.Point(191, 74)
        Me.LblFee.Name = "LblFee"
        Me.LblFee.Size = New System.Drawing.Size(61, 15)
        Me.LblFee.TabIndex = 680
        Me.LblFee.Text = "Fee Head"
        '
        'TxtAdmissionDocId
        '
        Me.TxtAdmissionDocId.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtAdmissionDocId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdmissionDocId.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionDocId.Location = New System.Drawing.Point(320, 92)
        Me.TxtAdmissionDocId.MaxLength = 123
        Me.TxtAdmissionDocId.Name = "TxtAdmissionDocId"
        Me.TxtAdmissionDocId.Size = New System.Drawing.Size(325, 19)
        Me.TxtAdmissionDocId.TabIndex = 2
        '
        'LblStudentName
        '
        Me.LblStudentName.AutoSize = True
        Me.LblStudentName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStudentName.Location = New System.Drawing.Point(191, 96)
        Me.LblStudentName.Name = "LblStudentName"
        Me.LblStudentName.Size = New System.Drawing.Size(86, 15)
        Me.LblStudentName.TabIndex = 682
        Me.LblStudentName.Text = "Student Name"
        '
        'LblStreamyearSemesterReq
        '
        Me.LblStreamyearSemesterReq.AutoSize = True
        Me.LblStreamyearSemesterReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblStreamyearSemesterReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblStreamyearSemesterReq.Location = New System.Drawing.Point(307, 57)
        Me.LblStreamyearSemesterReq.Name = "LblStreamyearSemesterReq"
        Me.LblStreamyearSemesterReq.Size = New System.Drawing.Size(10, 7)
        Me.LblStreamyearSemesterReq.TabIndex = 683
        Me.LblStreamyearSemesterReq.Text = "Ä"
        '
        'TxtTotalAmt
        '
        Me.TxtTotalAmt.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalAmt.AgMandatory = False
        Me.TxtTotalAmt.AgMasterHelp = False
        Me.TxtTotalAmt.AgNumberLeftPlaces = 0
        Me.TxtTotalAmt.AgNumberNegetiveAllow = False
        Me.TxtTotalAmt.AgNumberRightPlaces = 0
        Me.TxtTotalAmt.AgPickFromLastValue = False
        Me.TxtTotalAmt.AgRowFilter = ""
        Me.TxtTotalAmt.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalAmt.AgSelectedValue = Nothing
        Me.TxtTotalAmt.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalAmt.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTotalAmt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTotalAmt.Enabled = False
        Me.TxtTotalAmt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalAmt.Location = New System.Drawing.Point(320, 113)
        Me.TxtTotalAmt.MaxLength = 123
        Me.TxtTotalAmt.Name = "TxtTotalAmt"
        Me.TxtTotalAmt.Size = New System.Drawing.Size(115, 19)
        Me.TxtTotalAmt.TabIndex = 3
        '
        'lbltotal
        '
        Me.lbltotal.AutoSize = True
        Me.lbltotal.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltotal.Location = New System.Drawing.Point(191, 117)
        Me.lbltotal.Name = "lbltotal"
        Me.lbltotal.Size = New System.Drawing.Size(97, 15)
        Me.lbltotal.TabIndex = 685
        Me.lbltotal.Text = "Total Sem. Fees"
        '
        'FrmSemesterFeeAssign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(992, 616)
        Me.Controls.Add(Me.TxtTotalAmt)
        Me.Controls.Add(Me.lbltotal)
        Me.Controls.Add(Me.LblStreamyearSemesterReq)
        Me.Controls.Add(Me.TxtAdmissionDocId)
        Me.Controls.Add(Me.TxtFee)
        Me.Controls.Add(Me.LblStudentName)
        Me.Controls.Add(Me.LblFee)
        Me.Controls.Add(Me.BtnFill)
        Me.Controls.Add(Me.TxtStreamyearSemester)
        Me.Controls.Add(Me.LblStreamyearSemester)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSemesterFeeAssign"
        Me.Text = "Semester Subject Assign Entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnFill As System.Windows.Forms.Button
    Friend WithEvents TxtStreamyearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamyearSemester As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtFee As AgControls.AgTextBox
    Friend WithEvents LblFee As System.Windows.Forms.Label
    Friend WithEvents TxtAdmissionDocId As AgControls.AgTextBox
    Friend WithEvents LblStudentName As System.Windows.Forms.Label
    Friend WithEvents LblStreamyearSemesterReq As System.Windows.Forms.Label
    Friend WithEvents TxtTotalAmt As AgControls.AgTextBox
    Friend WithEvents lbltotal As System.Windows.Forms.Label
End Class
