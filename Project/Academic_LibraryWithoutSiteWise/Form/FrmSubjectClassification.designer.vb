<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSubjectClassification
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
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.RbtUnAssigned = New System.Windows.Forms.RadioButton
        Me.RbtAll = New System.Windows.Forms.RadioButton
        Me.RbtAssigned = New System.Windows.Forms.RadioButton
        Me.BtnClose = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TxtForSubject = New AgControls.AgTextBox
        Me.LblForSubject = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.SuspendLayout()
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(5, 71)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(436, 364)
        Me.Pnl1.TabIndex = 735
        '
        'RbtUnAssigned
        '
        Me.RbtUnAssigned.AutoSize = True
        Me.RbtUnAssigned.BackColor = System.Drawing.Color.Transparent
        Me.RbtUnAssigned.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtUnAssigned.ForeColor = System.Drawing.Color.Maroon
        Me.RbtUnAssigned.Location = New System.Drawing.Point(80, 5)
        Me.RbtUnAssigned.Name = "RbtUnAssigned"
        Me.RbtUnAssigned.Size = New System.Drawing.Size(101, 17)
        Me.RbtUnAssigned.TabIndex = 815
        Me.RbtUnAssigned.TabStop = True
        Me.RbtUnAssigned.Text = "UnAssigned"
        Me.RbtUnAssigned.UseVisualStyleBackColor = False
        '
        'RbtAll
        '
        Me.RbtAll.AutoSize = True
        Me.RbtAll.BackColor = System.Drawing.Color.Transparent
        Me.RbtAll.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtAll.ForeColor = System.Drawing.Color.Maroon
        Me.RbtAll.Location = New System.Drawing.Point(5, 5)
        Me.RbtAll.Name = "RbtAll"
        Me.RbtAll.Size = New System.Drawing.Size(42, 17)
        Me.RbtAll.TabIndex = 814
        Me.RbtAll.TabStop = True
        Me.RbtAll.Text = "All"
        Me.RbtAll.UseVisualStyleBackColor = False
        '
        'RbtAssigned
        '
        Me.RbtAssigned.AutoSize = True
        Me.RbtAssigned.BackColor = System.Drawing.Color.Transparent
        Me.RbtAssigned.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtAssigned.ForeColor = System.Drawing.Color.Maroon
        Me.RbtAssigned.Location = New System.Drawing.Point(213, 5)
        Me.RbtAssigned.Name = "RbtAssigned"
        Me.RbtAssigned.Size = New System.Drawing.Size(84, 17)
        Me.RbtAssigned.TabIndex = 816
        Me.RbtAssigned.TabStop = True
        Me.RbtAssigned.Text = "Assigned"
        Me.RbtAssigned.UseVisualStyleBackColor = False
        '
        'BtnClose
        '
        Me.BtnClose.BackColor = System.Drawing.Color.Transparent
        Me.BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClose.Location = New System.Drawing.Point(387, 451)
        Me.BtnClose.Name = "BtnClose"
        Me.BtnClose.Size = New System.Drawing.Size(54, 23)
        Me.BtnClose.TabIndex = 818
        Me.BtnClose.Text = "Close"
        Me.BtnClose.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(5, 442)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(441, 4)
        Me.GroupBox1.TabIndex = 819
        Me.GroupBox1.TabStop = False
        '
        'TxtForSubject
        '
        Me.TxtForSubject.AgMandatory = False
        Me.TxtForSubject.AgMasterHelp = False
        Me.TxtForSubject.AgNumberLeftPlaces = 8
        Me.TxtForSubject.AgNumberNegetiveAllow = False
        Me.TxtForSubject.AgNumberRightPlaces = 2
        Me.TxtForSubject.AgPickFromLastValue = False
        Me.TxtForSubject.AgRowFilter = ""
        Me.TxtForSubject.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForSubject.AgSelectedValue = Nothing
        Me.TxtForSubject.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForSubject.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtForSubject.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForSubject.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForSubject.Location = New System.Drawing.Point(92, 29)
        Me.TxtForSubject.MaxLength = 50
        Me.TxtForSubject.Name = "TxtForSubject"
        Me.TxtForSubject.Size = New System.Drawing.Size(284, 15)
        Me.TxtForSubject.TabIndex = 820
        '
        'LblForSubject
        '
        Me.LblForSubject.AutoSize = True
        Me.LblForSubject.BackColor = System.Drawing.Color.Transparent
        Me.LblForSubject.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
        Me.LblForSubject.Location = New System.Drawing.Point(2, 30)
        Me.LblForSubject.Name = "LblForSubject"
        Me.LblForSubject.Size = New System.Drawing.Size(82, 13)
        Me.LblForSubject.TabIndex = 821
        Me.LblForSubject.Text = "For Subject"
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(2, 59)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(443, 4)
        Me.GroupBox2.TabIndex = 822
        Me.GroupBox2.TabStop = False
        '
        'FrmSubjectClassification
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(446, 478)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtForSubject)
        Me.Controls.Add(Me.LblForSubject)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BtnClose)
        Me.Controls.Add(Me.RbtAssigned)
        Me.Controls.Add(Me.RbtUnAssigned)
        Me.Controls.Add(Me.RbtAll)
        Me.Controls.Add(Me.Pnl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSubjectClassification"
        Me.Text = "Define Subject Classification"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents RbtUnAssigned As System.Windows.Forms.RadioButton
    Friend WithEvents RbtAll As System.Windows.Forms.RadioButton
    Friend WithEvents RbtAssigned As System.Windows.Forms.RadioButton
    Protected WithEvents BtnClose As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Protected WithEvents TxtForSubject As AgControls.AgTextBox
    Protected WithEvents LblForSubject As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
