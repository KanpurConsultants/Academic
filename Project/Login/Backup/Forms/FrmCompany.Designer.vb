<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCompany
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
        Me.PnlMain = New System.Windows.Forms.Panel
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.BtnOk = New System.Windows.Forms.Button
        Me.LblLeft = New System.Windows.Forms.Label
        Me.LblRight = New System.Windows.Forms.Label
        Me.PcbTop = New System.Windows.Forms.PictureBox
        Me.LblBottom = New System.Windows.Forms.Label
        CType(Me.PcbTop, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PnlMain
        '
        Me.PnlMain.Location = New System.Drawing.Point(23, 72)
        Me.PnlMain.Name = "PnlMain"
        Me.PnlMain.Size = New System.Drawing.Size(692, 304)
        Me.PnlMain.TabIndex = 0
        '
        'BtnCancel
        '
        Me.BtnCancel.AutoEllipsis = True
        Me.BtnCancel.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnCancel.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.BtnCancel.Location = New System.Drawing.Point(648, 383)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(84, 24)
        Me.BtnCancel.TabIndex = 2
        Me.BtnCancel.Text = "&Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'BtnOk
        '
        Me.BtnOk.AutoEllipsis = True
        Me.BtnOk.BackColor = System.Drawing.Color.WhiteSmoke
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnOk.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.BtnOk.Location = New System.Drawing.Point(559, 383)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(84, 24)
        Me.BtnOk.TabIndex = 1
        Me.BtnOk.Text = "&Ok"
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'LblLeft
        '
        Me.LblLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.LblLeft.Location = New System.Drawing.Point(0, 71)
        Me.LblLeft.Name = "LblLeft"
        Me.LblLeft.Size = New System.Drawing.Size(21, 306)
        Me.LblLeft.TabIndex = 14
        '
        'LblRight
        '
        Me.LblRight.Dock = System.Windows.Forms.DockStyle.Right
        Me.LblRight.Location = New System.Drawing.Point(717, 71)
        Me.LblRight.Name = "LblRight"
        Me.LblRight.Size = New System.Drawing.Size(21, 306)
        Me.LblRight.TabIndex = 15
        '
        'PcbTop
        '
        Me.PcbTop.Dock = System.Windows.Forms.DockStyle.Top
        Me.PcbTop.Image = Global.Vidya.My.Resources.Resources.Title_Bar
        Me.PcbTop.Location = New System.Drawing.Point(0, 0)
        Me.PcbTop.Name = "PcbTop"
        Me.PcbTop.Size = New System.Drawing.Size(738, 71)
        Me.PcbTop.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PcbTop.TabIndex = 12
        Me.PcbTop.TabStop = False
        '
        'LblBottom
        '
        Me.LblBottom.BackColor = System.Drawing.Color.Transparent
        Me.LblBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.LblBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBottom.ForeColor = System.Drawing.Color.White
        Me.LblBottom.Image = Global.Vidya.My.Resources.Resources.rollerpaint_textured_walls_800x800111
        Me.LblBottom.Location = New System.Drawing.Point(0, 377)
        Me.LblBottom.Name = "LblBottom"
        Me.LblBottom.Size = New System.Drawing.Size(738, 38)
        Me.LblBottom.TabIndex = 13
        Me.LblBottom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FrmCompany
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(738, 415)
        Me.ControlBox = False
        Me.Controls.Add(Me.LblRight)
        Me.Controls.Add(Me.LblLeft)
        Me.Controls.Add(Me.PcbTop)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.PnlMain)
        Me.Controls.Add(Me.LblBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FrmCompany"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.PcbTop, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PnlMain As System.Windows.Forms.Panel
    Friend WithEvents BtnCancel As System.Windows.Forms.Button
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents PcbTop As System.Windows.Forms.PictureBox
    Friend WithEvents LblBottom As System.Windows.Forms.Label
    Friend WithEvents LblLeft As System.Windows.Forms.Label
    Friend WithEvents LblRight As System.Windows.Forms.Label
End Class
