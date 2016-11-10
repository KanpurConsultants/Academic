<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoom
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
        Me.LblToatlBed = New System.Windows.Forms.Label
        Me.LblBank_TotalBedReq = New System.Windows.Forms.Label
        Me.LblLocation = New System.Windows.Forms.Label
        Me.LblBank_RoomTypeReq = New System.Windows.Forms.Label
        Me.TxtRoomType = New AgControls.AgTextBox
        Me.LblRoomType = New System.Windows.Forms.Label
        Me.LblBuildingFloorReq = New System.Windows.Forms.Label
        Me.LblRoomNoSuffixReq = New System.Windows.Forms.Label
        Me.LblRoomNoSuffix = New System.Windows.Forms.Label
        Me.TxtBuildingFloor = New AgControls.AgTextBox
        Me.LblBuildingFloor = New System.Windows.Forms.Label
        Me.TxtLocation = New AgControls.AgTextBox
        Me.LblIsAttendanceMarksReq = New System.Windows.Forms.Label
        Me.TxtIsRoomAllocatable = New AgControls.AgTextBox
        Me.LblIsRoomAllocatable = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblRoomNo = New System.Windows.Forms.Label
        Me.TxtRoomNoSuffix = New AgControls.AgTextBox
        Me.TxtTotalBrd = New AgControls.AgTextBox
        Me.TxtRoomNoPrefix = New AgControls.AgTextBox
        Me.LblRoomNoPrefix = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
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
        'LblToatlBed
        '
        Me.LblToatlBed.AutoSize = True
        Me.LblToatlBed.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToatlBed.Location = New System.Drawing.Point(189, 220)
        Me.LblToatlBed.Name = "LblToatlBed"
        Me.LblToatlBed.Size = New System.Drawing.Size(152, 13)
        Me.LblToatlBed.TabIndex = 24
        Me.LblToatlBed.Text = "Room Capacity (In Beds)"
        '
        'LblBank_TotalBedReq
        '
        Me.LblBank_TotalBedReq.AutoSize = True
        Me.LblBank_TotalBedReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBank_TotalBedReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBank_TotalBedReq.Location = New System.Drawing.Point(345, 222)
        Me.LblBank_TotalBedReq.Name = "LblBank_TotalBedReq"
        Me.LblBank_TotalBedReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBank_TotalBedReq.TabIndex = 23
        Me.LblBank_TotalBedReq.Text = "Ä"
        '
        'LblLocation
        '
        Me.LblLocation.AutoSize = True
        Me.LblLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLocation.Location = New System.Drawing.Point(189, 198)
        Me.LblLocation.Name = "LblLocation"
        Me.LblLocation.Size = New System.Drawing.Size(54, 13)
        Me.LblLocation.TabIndex = 22
        Me.LblLocation.Text = "Location"
        '
        'LblBank_RoomTypeReq
        '
        Me.LblBank_RoomTypeReq.AutoSize = True
        Me.LblBank_RoomTypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBank_RoomTypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBank_RoomTypeReq.Location = New System.Drawing.Point(345, 179)
        Me.LblBank_RoomTypeReq.Name = "LblBank_RoomTypeReq"
        Me.LblBank_RoomTypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBank_RoomTypeReq.TabIndex = 21
        Me.LblBank_RoomTypeReq.Text = "Ä"
        '
        'TxtRoomType
        '
        Me.TxtRoomType.AgMandatory = True
        Me.TxtRoomType.AgMasterHelp = False
        Me.TxtRoomType.AgNumberLeftPlaces = 0
        Me.TxtRoomType.AgNumberNegetiveAllow = False
        Me.TxtRoomType.AgNumberRightPlaces = 0
        Me.TxtRoomType.AgPickFromLastValue = False
        Me.TxtRoomType.AgRowFilter = ""
        Me.TxtRoomType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRoomType.AgSelectedValue = Nothing
        Me.TxtRoomType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoomType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRoomType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoomType.Location = New System.Drawing.Point(358, 172)
        Me.TxtRoomType.MaxLength = 50
        Me.TxtRoomType.Name = "TxtRoomType"
        Me.TxtRoomType.Size = New System.Drawing.Size(325, 21)
        Me.TxtRoomType.TabIndex = 3
        '
        'LblRoomType
        '
        Me.LblRoomType.AutoSize = True
        Me.LblRoomType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoomType.Location = New System.Drawing.Point(189, 176)
        Me.LblRoomType.Name = "LblRoomType"
        Me.LblRoomType.Size = New System.Drawing.Size(72, 13)
        Me.LblRoomType.TabIndex = 19
        Me.LblRoomType.Text = "Room Type"
        '
        'LblBuildingFloorReq
        '
        Me.LblBuildingFloorReq.AutoSize = True
        Me.LblBuildingFloorReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBuildingFloorReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBuildingFloorReq.Location = New System.Drawing.Point(345, 114)
        Me.LblBuildingFloorReq.Name = "LblBuildingFloorReq"
        Me.LblBuildingFloorReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBuildingFloorReq.TabIndex = 16
        Me.LblBuildingFloorReq.Text = "Ä"
        '
        'LblRoomNoSuffixReq
        '
        Me.LblRoomNoSuffixReq.AutoSize = True
        Me.LblRoomNoSuffixReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblRoomNoSuffixReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblRoomNoSuffixReq.Location = New System.Drawing.Point(608, 135)
        Me.LblRoomNoSuffixReq.Name = "LblRoomNoSuffixReq"
        Me.LblRoomNoSuffixReq.Size = New System.Drawing.Size(10, 7)
        Me.LblRoomNoSuffixReq.TabIndex = 14
        Me.LblRoomNoSuffixReq.Text = "Ä"
        '
        'LblRoomNoSuffix
        '
        Me.LblRoomNoSuffix.AutoSize = True
        Me.LblRoomNoSuffix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoomNoSuffix.Location = New System.Drawing.Point(481, 132)
        Me.LblRoomNoSuffix.Name = "LblRoomNoSuffix"
        Me.LblRoomNoSuffix.Size = New System.Drawing.Size(96, 13)
        Me.LblRoomNoSuffix.TabIndex = 11
        Me.LblRoomNoSuffix.Text = "Room No Suffix"
        '
        'TxtBuildingFloor
        '
        Me.TxtBuildingFloor.AgMandatory = True
        Me.TxtBuildingFloor.AgMasterHelp = False
        Me.TxtBuildingFloor.AgNumberLeftPlaces = 0
        Me.TxtBuildingFloor.AgNumberNegetiveAllow = False
        Me.TxtBuildingFloor.AgNumberRightPlaces = 0
        Me.TxtBuildingFloor.AgPickFromLastValue = False
        Me.TxtBuildingFloor.AgRowFilter = ""
        Me.TxtBuildingFloor.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBuildingFloor.AgSelectedValue = Nothing
        Me.TxtBuildingFloor.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBuildingFloor.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBuildingFloor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBuildingFloor.Location = New System.Drawing.Point(358, 106)
        Me.TxtBuildingFloor.MaxLength = 50
        Me.TxtBuildingFloor.Name = "TxtBuildingFloor"
        Me.TxtBuildingFloor.Size = New System.Drawing.Size(325, 21)
        Me.TxtBuildingFloor.TabIndex = 0
        '
        'LblBuildingFloor
        '
        Me.LblBuildingFloor.AutoSize = True
        Me.LblBuildingFloor.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuildingFloor.Location = New System.Drawing.Point(189, 110)
        Me.LblBuildingFloor.Name = "LblBuildingFloor"
        Me.LblBuildingFloor.Size = New System.Drawing.Size(84, 13)
        Me.LblBuildingFloor.TabIndex = 12
        Me.LblBuildingFloor.Text = "Building Floor"
        '
        'TxtLocation
        '
        Me.TxtLocation.AgMandatory = False
        Me.TxtLocation.AgMasterHelp = False
        Me.TxtLocation.AgNumberLeftPlaces = 0
        Me.TxtLocation.AgNumberNegetiveAllow = False
        Me.TxtLocation.AgNumberRightPlaces = 0
        Me.TxtLocation.AgPickFromLastValue = False
        Me.TxtLocation.AgRowFilter = ""
        Me.TxtLocation.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLocation.AgSelectedValue = Nothing
        Me.TxtLocation.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLocation.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtLocation.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLocation.Location = New System.Drawing.Point(358, 194)
        Me.TxtLocation.MaxLength = 100
        Me.TxtLocation.Name = "TxtLocation"
        Me.TxtLocation.Size = New System.Drawing.Size(325, 21)
        Me.TxtLocation.TabIndex = 4
        '
        'LblIsAttendanceMarksReq
        '
        Me.LblIsAttendanceMarksReq.AutoSize = True
        Me.LblIsAttendanceMarksReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblIsAttendanceMarksReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblIsAttendanceMarksReq.Location = New System.Drawing.Point(594, 223)
        Me.LblIsAttendanceMarksReq.Name = "LblIsAttendanceMarksReq"
        Me.LblIsAttendanceMarksReq.Size = New System.Drawing.Size(10, 7)
        Me.LblIsAttendanceMarksReq.TabIndex = 718
        Me.LblIsAttendanceMarksReq.Text = "Ä"
        '
        'TxtIsRoomAllocatable
        '
        Me.TxtIsRoomAllocatable.AgMandatory = True
        Me.TxtIsRoomAllocatable.AgMasterHelp = False
        Me.TxtIsRoomAllocatable.AgNumberLeftPlaces = 0
        Me.TxtIsRoomAllocatable.AgNumberNegetiveAllow = False
        Me.TxtIsRoomAllocatable.AgNumberRightPlaces = 0
        Me.TxtIsRoomAllocatable.AgPickFromLastValue = False
        Me.TxtIsRoomAllocatable.AgRowFilter = ""
        Me.TxtIsRoomAllocatable.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsRoomAllocatable.AgSelectedValue = Nothing
        Me.TxtIsRoomAllocatable.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsRoomAllocatable.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsRoomAllocatable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsRoomAllocatable.Location = New System.Drawing.Point(606, 216)
        Me.TxtIsRoomAllocatable.MaxLength = 50
        Me.TxtIsRoomAllocatable.Name = "TxtIsRoomAllocatable"
        Me.TxtIsRoomAllocatable.Size = New System.Drawing.Size(77, 21)
        Me.TxtIsRoomAllocatable.TabIndex = 6
        '
        'LblIsRoomAllocatable
        '
        Me.LblIsRoomAllocatable.AutoSize = True
        Me.LblIsRoomAllocatable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsRoomAllocatable.Location = New System.Drawing.Point(465, 220)
        Me.LblIsRoomAllocatable.Name = "LblIsRoomAllocatable"
        Me.LblIsRoomAllocatable.Size = New System.Drawing.Size(121, 13)
        Me.LblIsRoomAllocatable.TabIndex = 717
        Me.LblIsRoomAllocatable.Text = "Is Room Allocatable"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(345, 157)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 721
        Me.Label1.Text = "Ä"
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
        Me.TxtDescription.Location = New System.Drawing.Point(358, 150)
        Me.TxtDescription.MaxLength = 20
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(325, 21)
        Me.TxtDescription.TabIndex = 2
        '
        'LblRoomNo
        '
        Me.LblRoomNo.AutoSize = True
        Me.LblRoomNo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoomNo.Location = New System.Drawing.Point(190, 154)
        Me.LblRoomNo.Name = "LblRoomNo"
        Me.LblRoomNo.Size = New System.Drawing.Size(59, 13)
        Me.LblRoomNo.TabIndex = 720
        Me.LblRoomNo.Text = "Room No"
        '
        'TxtRoomNoSuffix
        '
        Me.TxtRoomNoSuffix.AgMandatory = True
        Me.TxtRoomNoSuffix.AgMasterHelp = True
        Me.TxtRoomNoSuffix.AgNumberLeftPlaces = 3
        Me.TxtRoomNoSuffix.AgNumberNegetiveAllow = False
        Me.TxtRoomNoSuffix.AgNumberRightPlaces = 0
        Me.TxtRoomNoSuffix.AgPickFromLastValue = False
        Me.TxtRoomNoSuffix.AgRowFilter = ""
        Me.TxtRoomNoSuffix.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRoomNoSuffix.AgSelectedValue = Nothing
        Me.TxtRoomNoSuffix.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoomNoSuffix.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtRoomNoSuffix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoomNoSuffix.Location = New System.Drawing.Point(621, 128)
        Me.TxtRoomNoSuffix.MaxLength = 3
        Me.TxtRoomNoSuffix.Name = "TxtRoomNoSuffix"
        Me.TxtRoomNoSuffix.Size = New System.Drawing.Size(62, 21)
        Me.TxtRoomNoSuffix.TabIndex = 1
        Me.TxtRoomNoSuffix.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtTotalBrd
        '
        Me.TxtTotalBrd.AgMandatory = True
        Me.TxtTotalBrd.AgMasterHelp = True
        Me.TxtTotalBrd.AgNumberLeftPlaces = 3
        Me.TxtTotalBrd.AgNumberNegetiveAllow = False
        Me.TxtTotalBrd.AgNumberRightPlaces = 0
        Me.TxtTotalBrd.AgPickFromLastValue = False
        Me.TxtTotalBrd.AgRowFilter = ""
        Me.TxtTotalBrd.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalBrd.AgSelectedValue = Nothing
        Me.TxtTotalBrd.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalBrd.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalBrd.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalBrd.Location = New System.Drawing.Point(358, 216)
        Me.TxtTotalBrd.MaxLength = 50
        Me.TxtTotalBrd.Name = "TxtTotalBrd"
        Me.TxtTotalBrd.Size = New System.Drawing.Size(62, 21)
        Me.TxtTotalBrd.TabIndex = 5
        Me.TxtTotalBrd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtRoomNoPrefix
        '
        Me.TxtRoomNoPrefix.AgMandatory = True
        Me.TxtRoomNoPrefix.AgMasterHelp = True
        Me.TxtRoomNoPrefix.AgNumberLeftPlaces = 0
        Me.TxtRoomNoPrefix.AgNumberNegetiveAllow = False
        Me.TxtRoomNoPrefix.AgNumberRightPlaces = 0
        Me.TxtRoomNoPrefix.AgPickFromLastValue = False
        Me.TxtRoomNoPrefix.AgRowFilter = ""
        Me.TxtRoomNoPrefix.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRoomNoPrefix.AgSelectedValue = Nothing
        Me.TxtRoomNoPrefix.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoomNoPrefix.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRoomNoPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoomNoPrefix.Location = New System.Drawing.Point(358, 128)
        Me.TxtRoomNoPrefix.MaxLength = 15
        Me.TxtRoomNoPrefix.Name = "TxtRoomNoPrefix"
        Me.TxtRoomNoPrefix.ReadOnly = True
        Me.TxtRoomNoPrefix.Size = New System.Drawing.Size(116, 21)
        Me.TxtRoomNoPrefix.TabIndex = 722
        '
        'LblRoomNoPrefix
        '
        Me.LblRoomNoPrefix.AutoSize = True
        Me.LblRoomNoPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoomNoPrefix.Location = New System.Drawing.Point(190, 132)
        Me.LblRoomNoPrefix.Name = "LblRoomNoPrefix"
        Me.LblRoomNoPrefix.Size = New System.Drawing.Size(96, 13)
        Me.LblRoomNoPrefix.TabIndex = 723
        Me.LblRoomNoPrefix.Text = "Room No Prefix"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(345, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 724
        Me.Label2.Text = "Ä"
        '
        'FrmRoom
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 366)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtRoomNoPrefix)
        Me.Controls.Add(Me.LblRoomNoPrefix)
        Me.Controls.Add(Me.TxtTotalBrd)
        Me.Controls.Add(Me.TxtRoomNoSuffix)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblRoomNo)
        Me.Controls.Add(Me.LblIsAttendanceMarksReq)
        Me.Controls.Add(Me.TxtIsRoomAllocatable)
        Me.Controls.Add(Me.LblIsRoomAllocatable)
        Me.Controls.Add(Me.TxtLocation)
        Me.Controls.Add(Me.LblToatlBed)
        Me.Controls.Add(Me.LblBank_TotalBedReq)
        Me.Controls.Add(Me.LblLocation)
        Me.Controls.Add(Me.LblBank_RoomTypeReq)
        Me.Controls.Add(Me.TxtRoomType)
        Me.Controls.Add(Me.LblRoomType)
        Me.Controls.Add(Me.LblBuildingFloorReq)
        Me.Controls.Add(Me.LblRoomNoSuffixReq)
        Me.Controls.Add(Me.LblRoomNoSuffix)
        Me.Controls.Add(Me.TxtBuildingFloor)
        Me.Controls.Add(Me.LblBuildingFloor)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRoom"
        Me.Text = "Room Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblToatlBed As System.Windows.Forms.Label
    Friend WithEvents LblBank_TotalBedReq As System.Windows.Forms.Label
    Friend WithEvents LblLocation As System.Windows.Forms.Label
    Friend WithEvents LblBank_RoomTypeReq As System.Windows.Forms.Label
    Friend WithEvents TxtRoomType As AgControls.AgTextBox
    Friend WithEvents LblRoomType As System.Windows.Forms.Label
    Friend WithEvents LblBuildingFloorReq As System.Windows.Forms.Label
    Friend WithEvents LblRoomNoSuffixReq As System.Windows.Forms.Label
    Friend WithEvents LblRoomNoSuffix As System.Windows.Forms.Label
    Friend WithEvents TxtBuildingFloor As AgControls.AgTextBox
    Friend WithEvents LblBuildingFloor As System.Windows.Forms.Label
    Friend WithEvents TxtLocation As AgControls.AgTextBox
    Friend WithEvents LblIsAttendanceMarksReq As System.Windows.Forms.Label
    Friend WithEvents TxtIsRoomAllocatable As AgControls.AgTextBox
    Friend WithEvents LblIsRoomAllocatable As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblRoomNo As System.Windows.Forms.Label
    Friend WithEvents TxtRoomNoSuffix As AgControls.AgTextBox
    Friend WithEvents TxtTotalBrd As AgControls.AgTextBox
    Friend WithEvents TxtRoomNoPrefix As AgControls.AgTextBox
    Friend WithEvents LblRoomNoPrefix As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
