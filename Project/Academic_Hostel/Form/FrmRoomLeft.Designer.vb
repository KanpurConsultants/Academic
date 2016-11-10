<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoomLeft
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
        Me.LblLeftDateRequired = New System.Windows.Forms.Label
        Me.LblLeftDate = New System.Windows.Forms.Label
        Me.TxtLeftDate = New AgControls.AgTextBox
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.LblRoomRequired = New System.Windows.Forms.Label
        Me.TxtRoom = New AgControls.AgTextBox
        Me.LblRoom = New System.Windows.Forms.Label
        Me.LblAllotmentDocIdReq = New System.Windows.Forms.Label
        Me.TxtAllotmentDocId = New AgControls.AgTextBox
        Me.LblAllotmentDocId = New System.Windows.Forms.Label
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        Me.Topctrl1.Size = New System.Drawing.Size(887, 41)
        Me.Topctrl1.TabIndex = 3
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
        'LblLeftDateRequired
        '
        Me.LblLeftDateRequired.AutoSize = True
        Me.LblLeftDateRequired.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblLeftDateRequired.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblLeftDateRequired.Location = New System.Drawing.Point(322, 176)
        Me.LblLeftDateRequired.Name = "LblLeftDateRequired"
        Me.LblLeftDateRequired.Size = New System.Drawing.Size(10, 7)
        Me.LblLeftDateRequired.TabIndex = 653
        Me.LblLeftDateRequired.Text = "Ä"
        '
        'LblLeftDate
        '
        Me.LblLeftDate.AutoSize = True
        Me.LblLeftDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLeftDate.Location = New System.Drawing.Point(193, 169)
        Me.LblLeftDate.Name = "LblLeftDate"
        Me.LblLeftDate.Size = New System.Drawing.Size(59, 13)
        Me.LblLeftDate.TabIndex = 652
        Me.LblLeftDate.Text = "Left Date"
        '
        'TxtLeftDate
        '
        Me.TxtLeftDate.AgMandatory = True
        Me.TxtLeftDate.AgMasterHelp = False
        Me.TxtLeftDate.AgNumberLeftPlaces = 0
        Me.TxtLeftDate.AgNumberNegetiveAllow = False
        Me.TxtLeftDate.AgNumberRightPlaces = 0
        Me.TxtLeftDate.AgPickFromLastValue = False
        Me.TxtLeftDate.AgRowFilter = ""
        Me.TxtLeftDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLeftDate.AgSelectedValue = Nothing
        Me.TxtLeftDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLeftDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtLeftDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLeftDate.Location = New System.Drawing.Point(338, 165)
        Me.TxtLeftDate.Name = "TxtLeftDate"
        Me.TxtLeftDate.Size = New System.Drawing.Size(355, 21)
        Me.TxtLeftDate.TabIndex = 2
        '
        'TxtRemark
        '
        Me.TxtRemark.AgMandatory = False
        Me.TxtRemark.AgMasterHelp = False
        Me.TxtRemark.AgNumberLeftPlaces = 0
        Me.TxtRemark.AgNumberNegetiveAllow = False
        Me.TxtRemark.AgNumberRightPlaces = 0
        Me.TxtRemark.AgPickFromLastValue = False
        Me.TxtRemark.AgRowFilter = ""
        Me.TxtRemark.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemark.AgSelectedValue = Nothing
        Me.TxtRemark.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemark.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemark.Location = New System.Drawing.Point(338, 187)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(355, 21)
        Me.TxtRemark.TabIndex = 3
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(193, 191)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(52, 13)
        Me.LblRemark.TabIndex = 655
        Me.LblRemark.Text = "&Remark"
        '
        'LblRoomRequired
        '
        Me.LblRoomRequired.AutoSize = True
        Me.LblRoomRequired.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblRoomRequired.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblRoomRequired.Location = New System.Drawing.Point(322, 152)
        Me.LblRoomRequired.Name = "LblRoomRequired"
        Me.LblRoomRequired.Size = New System.Drawing.Size(10, 7)
        Me.LblRoomRequired.TabIndex = 668
        Me.LblRoomRequired.Text = "Ä"
        '
        'TxtRoom
        '
        Me.TxtRoom.AgMandatory = True
        Me.TxtRoom.AgMasterHelp = False
        Me.TxtRoom.AgNumberLeftPlaces = 0
        Me.TxtRoom.AgNumberNegetiveAllow = False
        Me.TxtRoom.AgNumberRightPlaces = 0
        Me.TxtRoom.AgPickFromLastValue = False
        Me.TxtRoom.AgRowFilter = ""
        Me.TxtRoom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRoom.AgSelectedValue = Nothing
        Me.TxtRoom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoom.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoom.Location = New System.Drawing.Point(338, 143)
        Me.TxtRoom.MaxLength = 50
        Me.TxtRoom.Name = "TxtRoom"
        Me.TxtRoom.Size = New System.Drawing.Size(355, 21)
        Me.TxtRoom.TabIndex = 1
        '
        'LblRoom
        '
        Me.LblRoom.AutoSize = True
        Me.LblRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoom.Location = New System.Drawing.Point(193, 147)
        Me.LblRoom.Name = "LblRoom"
        Me.LblRoom.Size = New System.Drawing.Size(40, 13)
        Me.LblRoom.TabIndex = 667
        Me.LblRoom.Text = "Room"
        '
        'LblAllotmentDocIdReq
        '
        Me.LblAllotmentDocIdReq.AutoSize = True
        Me.LblAllotmentDocIdReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAllotmentDocIdReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAllotmentDocIdReq.Location = New System.Drawing.Point(322, 128)
        Me.LblAllotmentDocIdReq.Name = "LblAllotmentDocIdReq"
        Me.LblAllotmentDocIdReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAllotmentDocIdReq.TabIndex = 666
        Me.LblAllotmentDocIdReq.Text = "Ä"
        '
        'TxtAllotmentDocId
        '
        Me.TxtAllotmentDocId.AgMandatory = True
        Me.TxtAllotmentDocId.AgMasterHelp = False
        Me.TxtAllotmentDocId.AgNumberLeftPlaces = 0
        Me.TxtAllotmentDocId.AgNumberNegetiveAllow = False
        Me.TxtAllotmentDocId.AgNumberRightPlaces = 0
        Me.TxtAllotmentDocId.AgPickFromLastValue = False
        Me.TxtAllotmentDocId.AgRowFilter = ""
        Me.TxtAllotmentDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAllotmentDocId.AgSelectedValue = Nothing
        Me.TxtAllotmentDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAllotmentDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAllotmentDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAllotmentDocId.Location = New System.Drawing.Point(337, 121)
        Me.TxtAllotmentDocId.MaxLength = 50
        Me.TxtAllotmentDocId.Name = "TxtAllotmentDocId"
        Me.TxtAllotmentDocId.Size = New System.Drawing.Size(355, 21)
        Me.TxtAllotmentDocId.TabIndex = 0
        '
        'LblAllotmentDocId
        '
        Me.LblAllotmentDocId.AutoSize = True
        Me.LblAllotmentDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAllotmentDocId.Location = New System.Drawing.Point(193, 125)
        Me.LblAllotmentDocId.Name = "LblAllotmentDocId"
        Me.LblAllotmentDocId.Size = New System.Drawing.Size(90, 13)
        Me.LblAllotmentDocId.TabIndex = 665
        Me.LblAllotmentDocId.Text = "Member Name"
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 328)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 670
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
        Me.TxtPrepared.Location = New System.Drawing.Point(14, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.ReadOnly = True
        Me.TxtPrepared.Size = New System.Drawing.Size(158, 18)
        Me.TxtPrepared.TabIndex = 0
        Me.TxtPrepared.TabStop = False
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(689, 328)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 671
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
        Me.TxtModified.Location = New System.Drawing.Point(13, 21)
        Me.TxtModified.Name = "TxtModified"
        Me.TxtModified.ReadOnly = True
        Me.TxtModified.Size = New System.Drawing.Size(158, 18)
        Me.TxtModified.TabIndex = 0
        Me.TxtModified.TabStop = False
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(0, 318)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 4)
        Me.GroupBox2.TabIndex = 669
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'FrmRoomLeft
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(887, 397)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.LblRoomRequired)
        Me.Controls.Add(Me.TxtRoom)
        Me.Controls.Add(Me.LblRoom)
        Me.Controls.Add(Me.LblAllotmentDocIdReq)
        Me.Controls.Add(Me.TxtAllotmentDocId)
        Me.Controls.Add(Me.LblAllotmentDocId)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.LblRemark)
        Me.Controls.Add(Me.LblLeftDateRequired)
        Me.Controls.Add(Me.LblLeftDate)
        Me.Controls.Add(Me.TxtLeftDate)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRoomLeft"
        Me.Text = "Room Left"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblLeftDateRequired As System.Windows.Forms.Label
    Friend WithEvents LblLeftDate As System.Windows.Forms.Label
    Friend WithEvents TxtLeftDate As AgControls.AgTextBox
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents LblRemark As System.Windows.Forms.Label
    Friend WithEvents LblRoomRequired As System.Windows.Forms.Label
    Friend WithEvents TxtRoom As AgControls.AgTextBox
    Friend WithEvents LblRoom As System.Windows.Forms.Label
    Friend WithEvents LblAllotmentDocIdReq As System.Windows.Forms.Label
    Friend WithEvents TxtAllotmentDocId As AgControls.AgTextBox
    Friend WithEvents LblAllotmentDocId As System.Windows.Forms.Label
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
