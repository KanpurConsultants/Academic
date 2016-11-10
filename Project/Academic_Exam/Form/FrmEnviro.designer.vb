<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEnviro
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
        Me.components = New System.ComponentModel.Container
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TpAcParameter = New System.Windows.Forms.TabPage
        Me.TxtDiscountAc = New AgControls.AgTextBox
        Me.LblDiscountAc = New System.Windows.Forms.Label
        Me.TxtFeeAdjustmentAc = New AgControls.AgTextBox
        Me.LblFeeAdjustmentAc = New System.Windows.Forms.Label
        Me.TcEnviro = New System.Windows.Forms.TabControl
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TxtAcGroup_Student = New AgControls.AgTextBox
        Me.LblAcGroup_Student = New System.Windows.Forms.Label
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.GroupBox4.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.TpAcParameter.SuspendLayout()
        Me.TcEnviro.SuspendLayout()
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
        Me.Topctrl1.TabIndex = 2
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
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(674, 462)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 201
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
        '
        'TxtModified
        '
        Me.TxtModified.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtModified.BackColor = System.Drawing.Color.White
        Me.TxtModified.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtModified.Enabled = False
        Me.TxtModified.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModified.Location = New System.Drawing.Point(15, 21)
        Me.TxtModified.Name = "TxtModified"
        Me.TxtModified.ReadOnly = True
        Me.TxtModified.Size = New System.Drawing.Size(158, 18)
        Me.TxtModified.TabIndex = 0
        Me.TxtModified.TabStop = False
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(7, 462)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 200
        Me.GrpUP.TabStop = False
        Me.GrpUP.Tag = "TR"
        Me.GrpUP.Text = "Prepared By "
        '
        'TxtPrepared
        '
        Me.TxtPrepared.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtPrepared.BackColor = System.Drawing.Color.White
        Me.TxtPrepared.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrepared.Enabled = False
        Me.TxtPrepared.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrepared.Location = New System.Drawing.Point(15, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.ReadOnly = True
        Me.TxtPrepared.Size = New System.Drawing.Size(158, 18)
        Me.TxtPrepared.TabIndex = 0
        Me.TxtPrepared.TabStop = False
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(0, 451)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 4)
        Me.GroupBox2.TabIndex = 202
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'TpAcParameter
        '
        Me.TpAcParameter.Controls.Add(Me.Label2)
        Me.TpAcParameter.Controls.Add(Me.Label1)
        Me.TpAcParameter.Controls.Add(Me.Label35)
        Me.TpAcParameter.Controls.Add(Me.TxtAcGroup_Student)
        Me.TpAcParameter.Controls.Add(Me.LblAcGroup_Student)
        Me.TpAcParameter.Controls.Add(Me.TxtDiscountAc)
        Me.TpAcParameter.Controls.Add(Me.LblDiscountAc)
        Me.TpAcParameter.Controls.Add(Me.TxtFeeAdjustmentAc)
        Me.TpAcParameter.Controls.Add(Me.LblFeeAdjustmentAc)
        Me.TpAcParameter.Location = New System.Drawing.Point(4, 22)
        Me.TpAcParameter.Name = "TpAcParameter"
        Me.TpAcParameter.Padding = New System.Windows.Forms.Padding(3)
        Me.TpAcParameter.Size = New System.Drawing.Size(666, 319)
        Me.TpAcParameter.TabIndex = 0
        Me.TpAcParameter.Text = "A/c Parameter"
        Me.TpAcParameter.UseVisualStyleBackColor = True
        '
        'TxtDiscountAc
        '
        Me.TxtDiscountAc.AgMandatory = True
        Me.TxtDiscountAc.AgMasterHelp = False
        Me.TxtDiscountAc.AgNumberLeftPlaces = 0
        Me.TxtDiscountAc.AgNumberNegetiveAllow = False
        Me.TxtDiscountAc.AgNumberRightPlaces = 0
        Me.TxtDiscountAc.AgPickFromLastValue = False
        Me.TxtDiscountAc.AgRowFilter = ""
        Me.TxtDiscountAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDiscountAc.AgSelectedValue = Nothing
        Me.TxtDiscountAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDiscountAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDiscountAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiscountAc.Location = New System.Drawing.Point(255, 48)
        Me.TxtDiscountAc.MaxLength = 10
        Me.TxtDiscountAc.Name = "TxtDiscountAc"
        Me.TxtDiscountAc.Size = New System.Drawing.Size(341, 21)
        Me.TxtDiscountAc.TabIndex = 6
        '
        'LblDiscountAc
        '
        Me.LblDiscountAc.AutoSize = True
        Me.LblDiscountAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiscountAc.Location = New System.Drawing.Point(62, 52)
        Me.LblDiscountAc.Name = "LblDiscountAc"
        Me.LblDiscountAc.Size = New System.Drawing.Size(82, 13)
        Me.LblDiscountAc.TabIndex = 28
        Me.LblDiscountAc.Text = "Discount A/C"
        '
        'TxtFeeAdjustmentAc
        '
        Me.TxtFeeAdjustmentAc.AgMandatory = True
        Me.TxtFeeAdjustmentAc.AgMasterHelp = False
        Me.TxtFeeAdjustmentAc.AgNumberLeftPlaces = 0
        Me.TxtFeeAdjustmentAc.AgNumberNegetiveAllow = False
        Me.TxtFeeAdjustmentAc.AgNumberRightPlaces = 0
        Me.TxtFeeAdjustmentAc.AgPickFromLastValue = False
        Me.TxtFeeAdjustmentAc.AgRowFilter = ""
        Me.TxtFeeAdjustmentAc.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFeeAdjustmentAc.AgSelectedValue = Nothing
        Me.TxtFeeAdjustmentAc.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFeeAdjustmentAc.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFeeAdjustmentAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFeeAdjustmentAc.Location = New System.Drawing.Point(255, 70)
        Me.TxtFeeAdjustmentAc.MaxLength = 10
        Me.TxtFeeAdjustmentAc.Name = "TxtFeeAdjustmentAc"
        Me.TxtFeeAdjustmentAc.Size = New System.Drawing.Size(341, 21)
        Me.TxtFeeAdjustmentAc.TabIndex = 5
        '
        'LblFeeAdjustmentAc
        '
        Me.LblFeeAdjustmentAc.AutoSize = True
        Me.LblFeeAdjustmentAc.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFeeAdjustmentAc.Location = New System.Drawing.Point(62, 74)
        Me.LblFeeAdjustmentAc.Name = "LblFeeAdjustmentAc"
        Me.LblFeeAdjustmentAc.Size = New System.Drawing.Size(119, 13)
        Me.LblFeeAdjustmentAc.TabIndex = 26
        Me.LblFeeAdjustmentAc.Text = "Fee Adjustment A/c"
        '
        'TcEnviro
        '
        Me.TcEnviro.Controls.Add(Me.TpAcParameter)
        Me.TcEnviro.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TcEnviro.Location = New System.Drawing.Point(99, 100)
        Me.TcEnviro.Name = "TcEnviro"
        Me.TcEnviro.SelectedIndex = 0
        Me.TcEnviro.Size = New System.Drawing.Size(674, 345)
        Me.TcEnviro.TabIndex = 1
        '
        'TxtAcGroup_Student
        '
        Me.TxtAcGroup_Student.AgMandatory = True
        Me.TxtAcGroup_Student.AgMasterHelp = False
        Me.TxtAcGroup_Student.AgNumberLeftPlaces = 0
        Me.TxtAcGroup_Student.AgNumberNegetiveAllow = False
        Me.TxtAcGroup_Student.AgNumberRightPlaces = 0
        Me.TxtAcGroup_Student.AgPickFromLastValue = False
        Me.TxtAcGroup_Student.AgRowFilter = ""
        Me.TxtAcGroup_Student.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAcGroup_Student.AgSelectedValue = Nothing
        Me.TxtAcGroup_Student.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAcGroup_Student.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAcGroup_Student.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAcGroup_Student.Location = New System.Drawing.Point(255, 26)
        Me.TxtAcGroup_Student.MaxLength = 10
        Me.TxtAcGroup_Student.Name = "TxtAcGroup_Student"
        Me.TxtAcGroup_Student.Size = New System.Drawing.Size(341, 21)
        Me.TxtAcGroup_Student.TabIndex = 29
        '
        'LblAcGroup_Student
        '
        Me.LblAcGroup_Student.AutoSize = True
        Me.LblAcGroup_Student.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAcGroup_Student.Location = New System.Drawing.Point(62, 30)
        Me.LblAcGroup_Student.Name = "LblAcGroup_Student"
        Me.LblAcGroup_Student.Size = New System.Drawing.Size(113, 13)
        Me.LblAcGroup_Student.TabIndex = 30
        Me.LblAcGroup_Student.Text = "Student A/c Group"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label35.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label35.Location = New System.Drawing.Point(242, 33)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(10, 7)
        Me.Label35.TabIndex = 511
        Me.Label35.Text = "Ä"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(242, 55)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 512
        Me.Label1.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(242, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 513
        Me.Label2.Text = "Ä"
        '
        'TxtSite_Code
        '
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
        Me.TxtSite_Code.BackColor = System.Drawing.SystemColors.Control
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(319, 57)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(293, 21)
        Me.TxtSite_Code.TabIndex = 509
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(216, 61)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 510
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'FrmEnviro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 516)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TcEnviro)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmEnviro"
        Me.Text = "Enviro Settings"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.TpAcParameter.ResumeLayout(False)
        Me.TpAcParameter.PerformLayout()
        Me.TcEnviro.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TpAcParameter As System.Windows.Forms.TabPage
    Friend WithEvents TcEnviro As System.Windows.Forms.TabControl
    Friend WithEvents TxtDiscountAc As AgControls.AgTextBox
    Friend WithEvents LblDiscountAc As System.Windows.Forms.Label
    Friend WithEvents TxtFeeAdjustmentAc As AgControls.AgTextBox
    Friend WithEvents LblFeeAdjustmentAc As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TxtAcGroup_Student As AgControls.AgTextBox
    Friend WithEvents LblAcGroup_Student As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
End Class
