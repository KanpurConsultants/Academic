<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBuildingFloorMaster
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
        Me.LblBank_NameReq = New System.Windows.Forms.Label
        Me.TxtBuilding = New AgControls.AgTextBox
        Me.LblBuilding = New System.Windows.Forms.Label
        Me.TxtFloor = New AgControls.AgTextBox
        Me.LblFloor = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtTotalRooms = New AgControls.AgTextBox
        Me.LabelTotalRooms = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.BtnFillRooms = New System.Windows.Forms.Button
        Me.LblTotalPassStudent = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtRoomPrefix = New AgControls.AgTextBox
        Me.LblRoomPrefix = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(327, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Ä"
        '
        'LblBank_NameReq
        '
        Me.LblBank_NameReq.AutoSize = True
        Me.LblBank_NameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBank_NameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBank_NameReq.Location = New System.Drawing.Point(327, 88)
        Me.LblBank_NameReq.Name = "LblBank_NameReq"
        Me.LblBank_NameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBank_NameReq.TabIndex = 46
        Me.LblBank_NameReq.Text = "Ä"
        '
        'TxtBuilding
        '
        Me.TxtBuilding.AgMandatory = True
        Me.TxtBuilding.AgMasterHelp = False
        Me.TxtBuilding.AgNumberLeftPlaces = 0
        Me.TxtBuilding.AgNumberNegetiveAllow = False
        Me.TxtBuilding.AgNumberRightPlaces = 0
        Me.TxtBuilding.AgPickFromLastValue = False
        Me.TxtBuilding.AgRowFilter = ""
        Me.TxtBuilding.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuilding.AgSelectedValue = Nothing
        Me.TxtBuilding.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuilding.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuilding.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuilding.Location = New System.Drawing.Point(340, 83)
        Me.TxtBuilding.MaxLength = 20
        Me.TxtBuilding.Name = "TxtBuilding"
        Me.TxtBuilding.Size = New System.Drawing.Size(305, 21)
        Me.TxtBuilding.TabIndex = 0
        '
        'LblBuilding
        '
        Me.LblBuilding.AutoSize = True
        Me.LblBuilding.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuilding.Location = New System.Drawing.Point(227, 86)
        Me.LblBuilding.Name = "LblBuilding"
        Me.LblBuilding.Size = New System.Drawing.Size(52, 13)
        Me.LblBuilding.TabIndex = 43
        Me.LblBuilding.Text = "Building"
        '
        'TxtFloor
        '
        Me.TxtFloor.AgMandatory = True
        Me.TxtFloor.AgMasterHelp = False
        Me.TxtFloor.AgNumberLeftPlaces = 0
        Me.TxtFloor.AgNumberNegetiveAllow = False
        Me.TxtFloor.AgNumberRightPlaces = 0
        Me.TxtFloor.AgPickFromLastValue = False
        Me.TxtFloor.AgRowFilter = ""
        Me.TxtFloor.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFloor.AgSelectedValue = Nothing
        Me.TxtFloor.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFloor.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFloor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFloor.Location = New System.Drawing.Point(340, 105)
        Me.TxtFloor.MaxLength = 50
        Me.TxtFloor.Name = "TxtFloor"
        Me.TxtFloor.Size = New System.Drawing.Size(305, 21)
        Me.TxtFloor.TabIndex = 1
        '
        'LblFloor
        '
        Me.LblFloor.AutoSize = True
        Me.LblFloor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFloor.Location = New System.Drawing.Point(227, 108)
        Me.LblFloor.Name = "LblFloor"
        Me.LblFloor.Size = New System.Drawing.Size(35, 13)
        Me.LblFloor.TabIndex = 42
        Me.LblFloor.Text = "Floor"
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(327, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 51
        Me.Label2.Text = "Ä"
        '
        'TxtTotalRooms
        '
        Me.TxtTotalRooms.AgMandatory = True
        Me.TxtTotalRooms.AgMasterHelp = True
        Me.TxtTotalRooms.AgNumberLeftPlaces = 3
        Me.TxtTotalRooms.AgNumberNegetiveAllow = False
        Me.TxtTotalRooms.AgNumberRightPlaces = 0
        Me.TxtTotalRooms.AgPickFromLastValue = False
        Me.TxtTotalRooms.AgRowFilter = ""
        Me.TxtTotalRooms.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalRooms.AgSelectedValue = Nothing
        Me.TxtTotalRooms.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalRooms.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalRooms.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalRooms.Location = New System.Drawing.Point(340, 127)
        Me.TxtTotalRooms.MaxLength = 50
        Me.TxtTotalRooms.Name = "TxtTotalRooms"
        Me.TxtTotalRooms.Size = New System.Drawing.Size(93, 21)
        Me.TxtTotalRooms.TabIndex = 2
        Me.TxtTotalRooms.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelTotalRooms
        '
        Me.LabelTotalRooms.AutoSize = True
        Me.LabelTotalRooms.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTotalRooms.Location = New System.Drawing.Point(227, 130)
        Me.LabelTotalRooms.Name = "LabelTotalRooms"
        Me.LabelTotalRooms.Size = New System.Drawing.Size(78, 13)
        Me.LabelTotalRooms.TabIndex = 49
        Me.LabelTotalRooms.Text = "Total Rooms"
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(42, 201)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(791, 254)
        Me.Pnl1.TabIndex = 5
        '
        'BtnFillRooms
        '
        Me.BtnFillRooms.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillRooms.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillRooms.Location = New System.Drawing.Point(711, 176)
        Me.BtnFillRooms.Name = "BtnFillRooms"
        Me.BtnFillRooms.Size = New System.Drawing.Size(122, 23)
        Me.BtnFillRooms.TabIndex = 4
        Me.BtnFillRooms.Text = "&Fill Rooms"
        Me.BtnFillRooms.UseVisualStyleBackColor = True
        '
        'LblTotalPassStudent
        '
        Me.LblTotalPassStudent.AutoSize = True
        Me.LblTotalPassStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalPassStudent.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalPassStudent.Location = New System.Drawing.Point(39, 184)
        Me.LblTotalPassStudent.Name = "LblTotalPassStudent"
        Me.LblTotalPassStudent.Size = New System.Drawing.Size(92, 13)
        Me.LblTotalPassStudent.TabIndex = 705
        Me.LblTotalPassStudent.Text = "Room Details :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(545, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 7)
        Me.Label3.TabIndex = 708
        Me.Label3.Text = "Ä"
        '
        'TxtRoomPrefix
        '
        Me.TxtRoomPrefix.AgMandatory = True
        Me.TxtRoomPrefix.AgMasterHelp = False
        Me.TxtRoomPrefix.AgNumberLeftPlaces = 3
        Me.TxtRoomPrefix.AgNumberNegetiveAllow = False
        Me.TxtRoomPrefix.AgNumberRightPlaces = 0
        Me.TxtRoomPrefix.AgPickFromLastValue = False
        Me.TxtRoomPrefix.AgRowFilter = ""
        Me.TxtRoomPrefix.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRoomPrefix.AgSelectedValue = Nothing
        Me.TxtRoomPrefix.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoomPrefix.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRoomPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoomPrefix.Location = New System.Drawing.Point(561, 127)
        Me.TxtRoomPrefix.MaxLength = 50
        Me.TxtRoomPrefix.Name = "TxtRoomPrefix"
        Me.TxtRoomPrefix.Size = New System.Drawing.Size(84, 21)
        Me.TxtRoomPrefix.TabIndex = 3
        '
        'LblRoomPrefix
        '
        Me.LblRoomPrefix.AutoSize = True
        Me.LblRoomPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoomPrefix.Location = New System.Drawing.Point(462, 130)
        Me.LblRoomPrefix.Name = "LblRoomPrefix"
        Me.LblRoomPrefix.Size = New System.Drawing.Size(77, 13)
        Me.LblRoomPrefix.TabIndex = 706
        Me.LblRoomPrefix.Text = "Room Prefix"
        '
        'FrmBuildingFloorMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 496)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtRoomPrefix)
        Me.Controls.Add(Me.LblRoomPrefix)
        Me.Controls.Add(Me.LblTotalPassStudent)
        Me.Controls.Add(Me.BtnFillRooms)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtTotalRooms)
        Me.Controls.Add(Me.LabelTotalRooms)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblBank_NameReq)
        Me.Controls.Add(Me.TxtBuilding)
        Me.Controls.Add(Me.LblBuilding)
        Me.Controls.Add(Me.TxtFloor)
        Me.Controls.Add(Me.LblFloor)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmBuildingFloorMaster"
        Me.Text = "Building Floor Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblBank_NameReq As System.Windows.Forms.Label
    Friend WithEvents TxtBuilding As AgControls.AgTextBox
    Friend WithEvents LblBuilding As System.Windows.Forms.Label
    Friend WithEvents TxtFloor As AgControls.AgTextBox
    Friend WithEvents LblFloor As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalRooms As AgControls.AgTextBox
    Friend WithEvents LabelTotalRooms As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents BtnFillRooms As System.Windows.Forms.Button
    Friend WithEvents LblTotalPassStudent As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtRoomPrefix As AgControls.AgTextBox
    Friend WithEvents LblRoomPrefix As System.Windows.Forms.Label
End Class
