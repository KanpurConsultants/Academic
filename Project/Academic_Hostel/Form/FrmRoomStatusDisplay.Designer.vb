<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoomStatusDisplay
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
        Me.TxtHostel = New AgControls.AgTextBox
        Me.LblHostel = New System.Windows.Forms.Label
        Me.TxtRoom = New AgControls.AgTextBox
        Me.LblRoom = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtBuildingFloor = New AgControls.AgTextBox
        Me.LblBuildingFloor = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BtnFillRoomStatus = New System.Windows.Forms.Button
        Me.LblBuildingReq = New System.Windows.Forms.Label
        Me.TxtBuilding = New AgControls.AgTextBox
        Me.LblBuilding = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblSelectedRoom = New System.Windows.Forms.Label
        Me.TxtSelectedRoom = New AgControls.AgTextBox
        Me.LblNonAllocable = New System.Windows.Forms.Label
        Me.TxtNonAllocable = New AgControls.AgTextBox
        Me.LblVacant = New System.Windows.Forms.Label
        Me.TxtVacant = New AgControls.AgTextBox
        Me.LblPartiallyOccupied = New System.Windows.Forms.Label
        Me.TxtPartiallyOccupied = New AgControls.AgTextBox
        Me.LblOccupied = New System.Windows.Forms.Label
        Me.TxtOccupied = New AgControls.AgTextBox
        Me.TxtMemberName = New AgControls.AgTextBox
        Me.LblMemberName = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.TxtRoomType = New AgControls.AgTextBox
        Me.LblRoomType = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtHostel
        '
        Me.TxtHostel.AgMandatory = True
        Me.TxtHostel.AgMasterHelp = False
        Me.TxtHostel.AgNumberLeftPlaces = 0
        Me.TxtHostel.AgNumberNegetiveAllow = False
        Me.TxtHostel.AgNumberRightPlaces = 0
        Me.TxtHostel.AgPickFromLastValue = False
        Me.TxtHostel.AgRowFilter = ""
        Me.TxtHostel.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtHostel.AgSelectedValue = Nothing
        Me.TxtHostel.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtHostel.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtHostel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHostel.Location = New System.Drawing.Point(136, 10)
        Me.TxtHostel.MaxLength = 50
        Me.TxtHostel.Name = "TxtHostel"
        Me.TxtHostel.Size = New System.Drawing.Size(293, 21)
        Me.TxtHostel.TabIndex = 0
        '
        'LblHostel
        '
        Me.LblHostel.AutoSize = True
        Me.LblHostel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHostel.Location = New System.Drawing.Point(26, 14)
        Me.LblHostel.Name = "LblHostel"
        Me.LblHostel.Size = New System.Drawing.Size(42, 13)
        Me.LblHostel.TabIndex = 693
        Me.LblHostel.Text = "Hostel"
        '
        'TxtRoom
        '
        Me.TxtRoom.AgMandatory = False
        Me.TxtRoom.AgMasterHelp = False
        Me.TxtRoom.AgNumberLeftPlaces = 0
        Me.TxtRoom.AgNumberNegetiveAllow = False
        Me.TxtRoom.AgNumberRightPlaces = 0
        Me.TxtRoom.AgPickFromLastValue = False
        Me.TxtRoom.AgRowFilter = ""
        Me.TxtRoom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtRoom.AgSelectedValue = Nothing
        Me.TxtRoom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoom.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoom.Location = New System.Drawing.Point(560, 31)
        Me.TxtRoom.MaxLength = 50
        Me.TxtRoom.Name = "TxtRoom"
        Me.TxtRoom.Size = New System.Drawing.Size(293, 21)
        Me.TxtRoom.TabIndex = 4
        '
        'LblRoom
        '
        Me.LblRoom.AutoSize = True
        Me.LblRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoom.Location = New System.Drawing.Point(448, 35)
        Me.LblRoom.Name = "LblRoom"
        Me.LblRoom.Size = New System.Drawing.Size(40, 13)
        Me.LblRoom.TabIndex = 691
        Me.LblRoom.Text = "Room"
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(26, 118)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(827, 492)
        Me.Pnl1.TabIndex = 7
        '
        'TxtBuildingFloor
        '
        Me.TxtBuildingFloor.AgMandatory = False
        Me.TxtBuildingFloor.AgMasterHelp = False
        Me.TxtBuildingFloor.AgNumberLeftPlaces = 0
        Me.TxtBuildingFloor.AgNumberNegetiveAllow = False
        Me.TxtBuildingFloor.AgNumberRightPlaces = 0
        Me.TxtBuildingFloor.AgPickFromLastValue = False
        Me.TxtBuildingFloor.AgRowFilter = ""
        Me.TxtBuildingFloor.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtBuildingFloor.AgSelectedValue = Nothing
        Me.TxtBuildingFloor.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuildingFloor.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuildingFloor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuildingFloor.Location = New System.Drawing.Point(136, 54)
        Me.TxtBuildingFloor.MaxLength = 50
        Me.TxtBuildingFloor.Name = "TxtBuildingFloor"
        Me.TxtBuildingFloor.Size = New System.Drawing.Size(293, 21)
        Me.TxtBuildingFloor.TabIndex = 2
        '
        'LblBuildingFloor
        '
        Me.LblBuildingFloor.AutoSize = True
        Me.LblBuildingFloor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuildingFloor.Location = New System.Drawing.Point(26, 59)
        Me.LblBuildingFloor.Name = "LblBuildingFloor"
        Me.LblBuildingFloor.Size = New System.Drawing.Size(84, 13)
        Me.LblBuildingFloor.TabIndex = 704
        Me.LblBuildingFloor.Text = "Building Floor"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(121, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 694
        Me.Label1.Text = "Ä"
        '
        'BtnFillRoomStatus
        '
        Me.BtnFillRoomStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.BtnFillRoomStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillRoomStatus.Location = New System.Drawing.Point(696, 77)
        Me.BtnFillRoomStatus.Name = "BtnFillRoomStatus"
        Me.BtnFillRoomStatus.Size = New System.Drawing.Size(157, 41)
        Me.BtnFillRoomStatus.TabIndex = 6
        Me.BtnFillRoomStatus.Text = "Fill Status"
        Me.BtnFillRoomStatus.UseVisualStyleBackColor = True
        '
        'LblBuildingReq
        '
        Me.LblBuildingReq.AutoSize = True
        Me.LblBuildingReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBuildingReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBuildingReq.Location = New System.Drawing.Point(121, 39)
        Me.LblBuildingReq.Name = "LblBuildingReq"
        Me.LblBuildingReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBuildingReq.TabIndex = 709
        Me.LblBuildingReq.Text = "Ä"
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
        Me.TxtBuilding.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtBuilding.AgSelectedValue = Nothing
        Me.TxtBuilding.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuilding.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuilding.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuilding.Location = New System.Drawing.Point(136, 32)
        Me.TxtBuilding.MaxLength = 50
        Me.TxtBuilding.Name = "TxtBuilding"
        Me.TxtBuilding.Size = New System.Drawing.Size(293, 21)
        Me.TxtBuilding.TabIndex = 1
        '
        'LblBuilding
        '
        Me.LblBuilding.AutoSize = True
        Me.LblBuilding.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuilding.Location = New System.Drawing.Point(26, 36)
        Me.LblBuilding.Name = "LblBuilding"
        Me.LblBuilding.Size = New System.Drawing.Size(52, 13)
        Me.LblBuilding.TabIndex = 708
        Me.LblBuilding.Text = "Building"
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Location = New System.Drawing.Point(-2, 197)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(22, 41)
        Me.Topctrl1.TabIndex = 711
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
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LblSelectedRoom)
        Me.Panel1.Controls.Add(Me.TxtSelectedRoom)
        Me.Panel1.Controls.Add(Me.LblNonAllocable)
        Me.Panel1.Controls.Add(Me.TxtNonAllocable)
        Me.Panel1.Controls.Add(Me.LblVacant)
        Me.Panel1.Controls.Add(Me.TxtVacant)
        Me.Panel1.Controls.Add(Me.LblPartiallyOccupied)
        Me.Panel1.Controls.Add(Me.TxtPartiallyOccupied)
        Me.Panel1.Controls.Add(Me.LblOccupied)
        Me.Panel1.Controls.Add(Me.TxtOccupied)
        Me.Panel1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(26, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(668, 39)
        Me.Panel1.TabIndex = 713
        '
        'LblSelectedRoom
        '
        Me.LblSelectedRoom.AutoSize = True
        Me.LblSelectedRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSelectedRoom.ForeColor = System.Drawing.Color.Blue
        Me.LblSelectedRoom.Location = New System.Drawing.Point(556, 12)
        Me.LblSelectedRoom.Name = "LblSelectedRoom"
        Me.LblSelectedRoom.Size = New System.Drawing.Size(102, 13)
        Me.LblSelectedRoom.TabIndex = 721
        Me.LblSelectedRoom.Text = ": Selected Room"
        '
        'TxtSelectedRoom
        '
        Me.TxtSelectedRoom.AgMandatory = True
        Me.TxtSelectedRoom.AgMasterHelp = False
        Me.TxtSelectedRoom.AgNumberLeftPlaces = 0
        Me.TxtSelectedRoom.AgNumberNegetiveAllow = False
        Me.TxtSelectedRoom.AgNumberRightPlaces = 0
        Me.TxtSelectedRoom.AgPickFromLastValue = False
        Me.TxtSelectedRoom.AgRowFilter = ""
        Me.TxtSelectedRoom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSelectedRoom.AgSelectedValue = Nothing
        Me.TxtSelectedRoom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSelectedRoom.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSelectedRoom.BackColor = System.Drawing.Color.Cyan
        Me.TxtSelectedRoom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSelectedRoom.Enabled = False
        Me.TxtSelectedRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSelectedRoom.Location = New System.Drawing.Point(519, 4)
        Me.TxtSelectedRoom.MaxLength = 50
        Me.TxtSelectedRoom.Multiline = True
        Me.TxtSelectedRoom.Name = "TxtSelectedRoom"
        Me.TxtSelectedRoom.ReadOnly = True
        Me.TxtSelectedRoom.Size = New System.Drawing.Size(30, 29)
        Me.TxtSelectedRoom.TabIndex = 720
        '
        'LblNonAllocable
        '
        Me.LblNonAllocable.AutoSize = True
        Me.LblNonAllocable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNonAllocable.ForeColor = System.Drawing.Color.Blue
        Me.LblNonAllocable.Location = New System.Drawing.Point(412, 12)
        Me.LblNonAllocable.Name = "LblNonAllocable"
        Me.LblNonAllocable.Size = New System.Drawing.Size(93, 13)
        Me.LblNonAllocable.TabIndex = 719
        Me.LblNonAllocable.Text = ": Non Allocable"
        '
        'TxtNonAllocable
        '
        Me.TxtNonAllocable.AgMandatory = True
        Me.TxtNonAllocable.AgMasterHelp = False
        Me.TxtNonAllocable.AgNumberLeftPlaces = 0
        Me.TxtNonAllocable.AgNumberNegetiveAllow = False
        Me.TxtNonAllocable.AgNumberRightPlaces = 0
        Me.TxtNonAllocable.AgPickFromLastValue = False
        Me.TxtNonAllocable.AgRowFilter = ""
        Me.TxtNonAllocable.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtNonAllocable.AgSelectedValue = Nothing
        Me.TxtNonAllocable.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtNonAllocable.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtNonAllocable.BackColor = System.Drawing.Color.DarkGray
        Me.TxtNonAllocable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtNonAllocable.Enabled = False
        Me.TxtNonAllocable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNonAllocable.Location = New System.Drawing.Point(375, 4)
        Me.TxtNonAllocable.MaxLength = 50
        Me.TxtNonAllocable.Multiline = True
        Me.TxtNonAllocable.Name = "TxtNonAllocable"
        Me.TxtNonAllocable.ReadOnly = True
        Me.TxtNonAllocable.Size = New System.Drawing.Size(30, 29)
        Me.TxtNonAllocable.TabIndex = 716
        '
        'LblVacant
        '
        Me.LblVacant.AutoSize = True
        Me.LblVacant.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVacant.ForeColor = System.Drawing.Color.Blue
        Me.LblVacant.Location = New System.Drawing.Point(314, 12)
        Me.LblVacant.Name = "LblVacant"
        Me.LblVacant.Size = New System.Drawing.Size(55, 13)
        Me.LblVacant.TabIndex = 718
        Me.LblVacant.Text = ": Vacant"
        '
        'TxtVacant
        '
        Me.TxtVacant.AgMandatory = False
        Me.TxtVacant.AgMasterHelp = False
        Me.TxtVacant.AgNumberLeftPlaces = 0
        Me.TxtVacant.AgNumberNegetiveAllow = False
        Me.TxtVacant.AgNumberRightPlaces = 0
        Me.TxtVacant.AgPickFromLastValue = False
        Me.TxtVacant.AgRowFilter = ""
        Me.TxtVacant.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVacant.AgSelectedValue = Nothing
        Me.TxtVacant.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVacant.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVacant.BackColor = System.Drawing.Color.LightGreen
        Me.TxtVacant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtVacant.Enabled = False
        Me.TxtVacant.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVacant.Location = New System.Drawing.Point(278, 4)
        Me.TxtVacant.MaxLength = 50
        Me.TxtVacant.Multiline = True
        Me.TxtVacant.Name = "TxtVacant"
        Me.TxtVacant.ReadOnly = True
        Me.TxtVacant.Size = New System.Drawing.Size(30, 29)
        Me.TxtVacant.TabIndex = 9
        '
        'LblPartiallyOccupied
        '
        Me.LblPartiallyOccupied.AutoSize = True
        Me.LblPartiallyOccupied.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPartiallyOccupied.ForeColor = System.Drawing.Color.Blue
        Me.LblPartiallyOccupied.Location = New System.Drawing.Point(154, 12)
        Me.LblPartiallyOccupied.Name = "LblPartiallyOccupied"
        Me.LblPartiallyOccupied.Size = New System.Drawing.Size(118, 13)
        Me.LblPartiallyOccupied.TabIndex = 717
        Me.LblPartiallyOccupied.Text = ": Partially Occupied"
        '
        'TxtPartiallyOccupied
        '
        Me.TxtPartiallyOccupied.AgMandatory = False
        Me.TxtPartiallyOccupied.AgMasterHelp = False
        Me.TxtPartiallyOccupied.AgNumberLeftPlaces = 0
        Me.TxtPartiallyOccupied.AgNumberNegetiveAllow = False
        Me.TxtPartiallyOccupied.AgNumberRightPlaces = 0
        Me.TxtPartiallyOccupied.AgPickFromLastValue = False
        Me.TxtPartiallyOccupied.AgRowFilter = ""
        Me.TxtPartiallyOccupied.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPartiallyOccupied.AgSelectedValue = Nothing
        Me.TxtPartiallyOccupied.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPartiallyOccupied.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPartiallyOccupied.BackColor = System.Drawing.Color.Yellow
        Me.TxtPartiallyOccupied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPartiallyOccupied.Enabled = False
        Me.TxtPartiallyOccupied.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartiallyOccupied.Location = New System.Drawing.Point(118, 4)
        Me.TxtPartiallyOccupied.MaxLength = 50
        Me.TxtPartiallyOccupied.Multiline = True
        Me.TxtPartiallyOccupied.Name = "TxtPartiallyOccupied"
        Me.TxtPartiallyOccupied.ReadOnly = True
        Me.TxtPartiallyOccupied.Size = New System.Drawing.Size(30, 29)
        Me.TxtPartiallyOccupied.TabIndex = 8
        '
        'LblOccupied
        '
        Me.LblOccupied.AutoSize = True
        Me.LblOccupied.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOccupied.ForeColor = System.Drawing.Color.Blue
        Me.LblOccupied.Location = New System.Drawing.Point(44, 12)
        Me.LblOccupied.Name = "LblOccupied"
        Me.LblOccupied.Size = New System.Drawing.Size(68, 13)
        Me.LblOccupied.TabIndex = 716
        Me.LblOccupied.Text = ": Occupied"
        '
        'TxtOccupied
        '
        Me.TxtOccupied.AgMandatory = False
        Me.TxtOccupied.AgMasterHelp = False
        Me.TxtOccupied.AgNumberLeftPlaces = 0
        Me.TxtOccupied.AgNumberNegetiveAllow = False
        Me.TxtOccupied.AgNumberRightPlaces = 0
        Me.TxtOccupied.AgPickFromLastValue = False
        Me.TxtOccupied.AgRowFilter = ""
        Me.TxtOccupied.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOccupied.AgSelectedValue = Nothing
        Me.TxtOccupied.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOccupied.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOccupied.BackColor = System.Drawing.Color.Red
        Me.TxtOccupied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtOccupied.Enabled = False
        Me.TxtOccupied.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOccupied.Location = New System.Drawing.Point(8, 4)
        Me.TxtOccupied.MaxLength = 50
        Me.TxtOccupied.Multiline = True
        Me.TxtOccupied.Name = "TxtOccupied"
        Me.TxtOccupied.ReadOnly = True
        Me.TxtOccupied.Size = New System.Drawing.Size(30, 29)
        Me.TxtOccupied.TabIndex = 7
        '
        'TxtMemberName
        '
        Me.TxtMemberName.AgMandatory = False
        Me.TxtMemberName.AgMasterHelp = False
        Me.TxtMemberName.AgNumberLeftPlaces = 0
        Me.TxtMemberName.AgNumberNegetiveAllow = False
        Me.TxtMemberName.AgNumberRightPlaces = 0
        Me.TxtMemberName.AgPickFromLastValue = False
        Me.TxtMemberName.AgRowFilter = ""
        Me.TxtMemberName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtMemberName.AgSelectedValue = Nothing
        Me.TxtMemberName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberName.Location = New System.Drawing.Point(560, 53)
        Me.TxtMemberName.MaxLength = 50
        Me.TxtMemberName.Name = "TxtMemberName"
        Me.TxtMemberName.Size = New System.Drawing.Size(293, 21)
        Me.TxtMemberName.TabIndex = 5
        '
        'LblMemberName
        '
        Me.LblMemberName.AutoSize = True
        Me.LblMemberName.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberName.Location = New System.Drawing.Point(448, 57)
        Me.LblMemberName.Name = "LblMemberName"
        Me.LblMemberName.Size = New System.Drawing.Size(90, 13)
        Me.LblMemberName.TabIndex = 715
        Me.LblMemberName.Text = "Member Name"
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(-2, 160)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(22, 21)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        Me.TxtSite_Code.Visible = False
        '
        'TxtRoomType
        '
        Me.TxtRoomType.AgMandatory = False
        Me.TxtRoomType.AgMasterHelp = False
        Me.TxtRoomType.AgNumberLeftPlaces = 0
        Me.TxtRoomType.AgNumberNegetiveAllow = False
        Me.TxtRoomType.AgNumberRightPlaces = 0
        Me.TxtRoomType.AgPickFromLastValue = False
        Me.TxtRoomType.AgRowFilter = ""
        Me.TxtRoomType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.TxtRoomType.AgSelectedValue = Nothing
        Me.TxtRoomType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoomType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRoomType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoomType.Location = New System.Drawing.Point(560, 9)
        Me.TxtRoomType.MaxLength = 50
        Me.TxtRoomType.Name = "TxtRoomType"
        Me.TxtRoomType.Size = New System.Drawing.Size(293, 21)
        Me.TxtRoomType.TabIndex = 3
        '
        'LblRoomType
        '
        Me.LblRoomType.AutoSize = True
        Me.LblRoomType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoomType.Location = New System.Drawing.Point(448, 13)
        Me.LblRoomType.Name = "LblRoomType"
        Me.LblRoomType.Size = New System.Drawing.Size(68, 13)
        Me.LblRoomType.TabIndex = 717
        Me.LblRoomType.Text = "RoomType"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Panel2.Location = New System.Drawing.Point(26, 612)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(406, 22)
        Me.Panel2.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(376, 13)
        Me.Label2.TabIndex = 716
        Me.Label2.Text = "Double-Click On The Cell to View Further Related Details."
        '
        'FrmRoomStatusDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 639)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.TxtRoomType)
        Me.Controls.Add(Me.LblRoomType)
        Me.Controls.Add(Me.TxtMemberName)
        Me.Controls.Add(Me.LblMemberName)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LblBuildingReq)
        Me.Controls.Add(Me.TxtBuilding)
        Me.Controls.Add(Me.LblBuilding)
        Me.Controls.Add(Me.BtnFillRoomStatus)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtBuildingFloor)
        Me.Controls.Add(Me.LblBuildingFloor)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtHostel)
        Me.Controls.Add(Me.LblHostel)
        Me.Controls.Add(Me.TxtRoom)
        Me.Controls.Add(Me.LblRoom)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRoomStatusDisplay"
        Me.Text = "Room Status Display"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtHostel As AgControls.AgTextBox
    Friend WithEvents LblHostel As System.Windows.Forms.Label
    Friend WithEvents TxtRoom As AgControls.AgTextBox
    Friend WithEvents LblRoom As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtBuildingFloor As AgControls.AgTextBox
    Friend WithEvents LblBuildingFloor As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnFillRoomStatus As System.Windows.Forms.Button
    Friend WithEvents LblBuildingReq As System.Windows.Forms.Label
    Friend WithEvents TxtBuilding As AgControls.AgTextBox
    Friend WithEvents LblBuilding As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TxtPartiallyOccupied As AgControls.AgTextBox
    Friend WithEvents TxtOccupied As AgControls.AgTextBox
    Friend WithEvents TxtVacant As AgControls.AgTextBox
    Friend WithEvents TxtMemberName As AgControls.AgTextBox
    Friend WithEvents LblMemberName As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents TxtNonAllocable As AgControls.AgTextBox
    Friend WithEvents TxtSelectedRoom As AgControls.AgTextBox
    Friend WithEvents LblSelectedRoom As System.Windows.Forms.Label
    Friend WithEvents LblNonAllocable As System.Windows.Forms.Label
    Friend WithEvents LblVacant As System.Windows.Forms.Label
    Friend WithEvents LblPartiallyOccupied As System.Windows.Forms.Label
    Friend WithEvents LblOccupied As System.Windows.Forms.Label
    Friend WithEvents TxtRoomType As AgControls.AgTextBox
    Friend WithEvents LblRoomType As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
