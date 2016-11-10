<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMemberStatus
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
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.BtnChargeDue = New System.Windows.Forms.Button
        Me.BtnViewLastRecipt = New System.Windows.Forms.Button
        Me.BtnChargeReceive = New System.Windows.Forms.Button
        Me.BtnRoomTransfer = New System.Windows.Forms.Button
        Me.BtnRoomLeft = New System.Windows.Forms.Button
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.Pnl1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Pnl1
        '
        Me.Pnl1.Controls.Add(Me.Topctrl1)
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(12, 7)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(708, 247)
        Me.Pnl1.TabIndex = 10
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Location = New System.Drawing.Point(3, 203)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(63, 41)
        Me.Topctrl1.TabIndex = 712
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
        'BtnChargeDue
        '
        Me.BtnChargeDue.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnChargeDue.Location = New System.Drawing.Point(12, 260)
        Me.BtnChargeDue.Name = "BtnChargeDue"
        Me.BtnChargeDue.Size = New System.Drawing.Size(100, 23)
        Me.BtnChargeDue.TabIndex = 11
        Me.BtnChargeDue.Text = "Charge Due"
        Me.BtnChargeDue.UseVisualStyleBackColor = True
        '
        'BtnViewLastRecipt
        '
        Me.BtnViewLastRecipt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnViewLastRecipt.Location = New System.Drawing.Point(164, 260)
        Me.BtnViewLastRecipt.Name = "BtnViewLastRecipt"
        Me.BtnViewLastRecipt.Size = New System.Drawing.Size(100, 23)
        Me.BtnViewLastRecipt.TabIndex = 12
        Me.BtnViewLastRecipt.Text = "View Last Recipt"
        Me.BtnViewLastRecipt.UseVisualStyleBackColor = True
        '
        'BtnChargeReceive
        '
        Me.BtnChargeReceive.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnChargeReceive.Location = New System.Drawing.Point(316, 260)
        Me.BtnChargeReceive.Name = "BtnChargeReceive"
        Me.BtnChargeReceive.Size = New System.Drawing.Size(100, 23)
        Me.BtnChargeReceive.TabIndex = 13
        Me.BtnChargeReceive.Text = "Charge Receive"
        Me.BtnChargeReceive.UseVisualStyleBackColor = True
        '
        'BtnRoomTransfer
        '
        Me.BtnRoomTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnRoomTransfer.Location = New System.Drawing.Point(468, 260)
        Me.BtnRoomTransfer.Name = "BtnRoomTransfer"
        Me.BtnRoomTransfer.Size = New System.Drawing.Size(100, 23)
        Me.BtnRoomTransfer.TabIndex = 14
        Me.BtnRoomTransfer.Text = "Room Transfer"
        Me.BtnRoomTransfer.UseVisualStyleBackColor = True
        '
        'BtnRoomLeft
        '
        Me.BtnRoomLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnRoomLeft.Location = New System.Drawing.Point(620, 260)
        Me.BtnRoomLeft.Name = "BtnRoomLeft"
        Me.BtnRoomLeft.Size = New System.Drawing.Size(100, 23)
        Me.BtnRoomLeft.TabIndex = 15
        Me.BtnRoomLeft.Text = "Room Left"
        Me.BtnRoomLeft.UseVisualStyleBackColor = True
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
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(270, 262)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(30, 21)
        Me.TxtSite_Code.TabIndex = 713
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        Me.TxtSite_Code.Visible = False
        '
        'FrmMemberStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(732, 290)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.BtnRoomLeft)
        Me.Controls.Add(Me.BtnRoomTransfer)
        Me.Controls.Add(Me.BtnChargeReceive)
        Me.Controls.Add(Me.BtnViewLastRecipt)
        Me.Controls.Add(Me.BtnChargeDue)
        Me.Controls.Add(Me.Pnl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmMemberStatus"
        Me.Text = "FrmMemberStatus"
        Me.Pnl1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents BtnChargeDue As System.Windows.Forms.Button
    Friend WithEvents BtnViewLastRecipt As System.Windows.Forms.Button
    Friend WithEvents BtnChargeReceive As System.Windows.Forms.Button
    Friend WithEvents BtnRoomTransfer As System.Windows.Forms.Button
    Friend WithEvents BtnRoomLeft As System.Windows.Forms.Button
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
End Class
