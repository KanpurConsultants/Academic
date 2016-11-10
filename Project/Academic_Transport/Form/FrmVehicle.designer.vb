<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehicle
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
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.LblDescriptionReq = New System.Windows.Forms.Label
        Me.TxtVehicleModel = New AgControls.AgTextBox
        Me.LblVehicleModel = New System.Windows.Forms.Label
        Me.TxtMileage = New AgControls.AgTextBox
        Me.LblMileage = New System.Windows.Forms.Label
        Me.TxtRegistrationNo = New AgControls.AgTextBox
        Me.LblRegistrationNo = New System.Windows.Forms.Label
        Me.TxtChassisNo = New AgControls.AgTextBox
        Me.LblChassisNo = New System.Windows.Forms.Label
        Me.TxtEngineNo = New AgControls.AgTextBox
        Me.LblEngineNo = New System.Windows.Forms.Label
        Me.LblSeatingCapacity = New System.Windows.Forms.Label
        Me.LblOwnRented = New System.Windows.Forms.Label
        Me.TxtOwnerName = New AgControls.AgTextBox
        Me.LblOwnerName = New System.Windows.Forms.Label
        Me.TxtOwnerAdd1 = New AgControls.AgTextBox
        Me.LblOwnerAdd1 = New System.Windows.Forms.Label
        Me.TxtOwnerAdd2 = New AgControls.AgTextBox
        Me.TxtOwnerAdd3 = New AgControls.AgTextBox
        Me.TxtOwnerCity = New AgControls.AgTextBox
        Me.LblOwnerCity = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblOwnRentedReq = New System.Windows.Forms.Label
        Me.TxtSeatingCapacity = New AgControls.AgTextBox
        Me.TxtOwnRented = New AgControls.AgTextBox
        Me.TxtVehicleType = New AgControls.AgTextBox
        Me.LblVehicleType = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LinkLblTitle = New System.Windows.Forms.LinkLabel
        Me.TxtMeterReading = New AgControls.AgTextBox
        Me.LblMeterReading = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Topctrl1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.Topctrl1.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Topctrl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Topctrl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Topctrl1.Location = New System.Drawing.Point(0, 0)
        Me.Topctrl1.Mode = "Browse"
        Me.Topctrl1.Name = "Topctrl1"
        Me.Topctrl1.Size = New System.Drawing.Size(982, 41)
        Me.Topctrl1.TabIndex = 14
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
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgMandatory = True
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
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(147, 67)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(300, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Text = "TxtSite_Code"
        Me.TxtSite_Code.Visible = False
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(26, 67)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(107, 15)
        Me.LblSite_Code.TabIndex = 0
        Me.LblSite_Code.Text = "Site/Branch Name"
        Me.LblSite_Code.Visible = False
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
        Me.TxtDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDescription.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(347, 87)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(100, 18)
        Me.TxtDescription.TabIndex = 1
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(248, 89)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(84, 15)
        Me.LblDescription.TabIndex = 0
        Me.LblDescription.Text = "Vehicle Name"
        '
        'LblDescriptionReq
        '
        Me.LblDescriptionReq.AutoSize = True
        Me.LblDescriptionReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblDescriptionReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblDescriptionReq.Location = New System.Drawing.Point(332, 93)
        Me.LblDescriptionReq.Name = "LblDescriptionReq"
        Me.LblDescriptionReq.Size = New System.Drawing.Size(10, 7)
        Me.LblDescriptionReq.TabIndex = 0
        Me.LblDescriptionReq.Text = "Ä"
        '
        'TxtVehicleModel
        '
        Me.TxtVehicleModel.AgMandatory = False
        Me.TxtVehicleModel.AgMasterHelp = True
        Me.TxtVehicleModel.AgNumberLeftPlaces = 0
        Me.TxtVehicleModel.AgNumberNegetiveAllow = False
        Me.TxtVehicleModel.AgNumberRightPlaces = 0
        Me.TxtVehicleModel.AgPickFromLastValue = False
        Me.TxtVehicleModel.AgRowFilter = ""
        Me.TxtVehicleModel.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicleModel.AgSelectedValue = Nothing
        Me.TxtVehicleModel.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicleModel.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicleModel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicleModel.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicleModel.Location = New System.Drawing.Point(347, 107)
        Me.TxtVehicleModel.MaxLength = 50
        Me.TxtVehicleModel.Name = "TxtVehicleModel"
        Me.TxtVehicleModel.Size = New System.Drawing.Size(100, 18)
        Me.TxtVehicleModel.TabIndex = 3
        '
        'LblVehicleModel
        '
        Me.LblVehicleModel.AutoSize = True
        Me.LblVehicleModel.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVehicleModel.Location = New System.Drawing.Point(248, 108)
        Me.LblVehicleModel.Name = "LblVehicleModel"
        Me.LblVehicleModel.Size = New System.Drawing.Size(83, 15)
        Me.LblVehicleModel.TabIndex = 0
        Me.LblVehicleModel.Text = "Vehicle Model"
        '
        'TxtMileage
        '
        Me.TxtMileage.AgMandatory = False
        Me.TxtMileage.AgMasterHelp = False
        Me.TxtMileage.AgNumberLeftPlaces = 3
        Me.TxtMileage.AgNumberNegetiveAllow = False
        Me.TxtMileage.AgNumberRightPlaces = 0
        Me.TxtMileage.AgPickFromLastValue = False
        Me.TxtMileage.AgRowFilter = ""
        Me.TxtMileage.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMileage.AgSelectedValue = Nothing
        Me.TxtMileage.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMileage.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMileage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMileage.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMileage.Location = New System.Drawing.Point(147, 147)
        Me.TxtMileage.Name = "TxtMileage"
        Me.TxtMileage.Size = New System.Drawing.Size(100, 18)
        Me.TxtMileage.TabIndex = 6
        Me.TxtMileage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblMileage
        '
        Me.LblMileage.AutoSize = True
        Me.LblMileage.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMileage.Location = New System.Drawing.Point(26, 149)
        Me.LblMileage.Name = "LblMileage"
        Me.LblMileage.Size = New System.Drawing.Size(50, 15)
        Me.LblMileage.TabIndex = 0
        Me.LblMileage.Text = "Mileage"
        '
        'TxtRegistrationNo
        '
        Me.TxtRegistrationNo.AgMandatory = True
        Me.TxtRegistrationNo.AgMasterHelp = True
        Me.TxtRegistrationNo.AgNumberLeftPlaces = 0
        Me.TxtRegistrationNo.AgNumberNegetiveAllow = False
        Me.TxtRegistrationNo.AgNumberRightPlaces = 0
        Me.TxtRegistrationNo.AgPickFromLastValue = False
        Me.TxtRegistrationNo.AgRowFilter = ""
        Me.TxtRegistrationNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRegistrationNo.AgSelectedValue = Nothing
        Me.TxtRegistrationNo.AgTxtCase = AgControls.AgTextBox.TxtCase.Upper_Case
        Me.TxtRegistrationNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRegistrationNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRegistrationNo.Location = New System.Drawing.Point(147, 87)
        Me.TxtRegistrationNo.MaxLength = 20
        Me.TxtRegistrationNo.Name = "TxtRegistrationNo"
        Me.TxtRegistrationNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtRegistrationNo.TabIndex = 0
        '
        'LblRegistrationNo
        '
        Me.LblRegistrationNo.AutoSize = True
        Me.LblRegistrationNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistrationNo.Location = New System.Drawing.Point(26, 89)
        Me.LblRegistrationNo.Name = "LblRegistrationNo"
        Me.LblRegistrationNo.Size = New System.Drawing.Size(96, 15)
        Me.LblRegistrationNo.TabIndex = 0
        Me.LblRegistrationNo.Text = "Registration No."
        '
        'TxtChassisNo
        '
        Me.TxtChassisNo.AgMandatory = False
        Me.TxtChassisNo.AgMasterHelp = False
        Me.TxtChassisNo.AgNumberLeftPlaces = 0
        Me.TxtChassisNo.AgNumberNegetiveAllow = False
        Me.TxtChassisNo.AgNumberRightPlaces = 0
        Me.TxtChassisNo.AgPickFromLastValue = False
        Me.TxtChassisNo.AgRowFilter = ""
        Me.TxtChassisNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtChassisNo.AgSelectedValue = Nothing
        Me.TxtChassisNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtChassisNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtChassisNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtChassisNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChassisNo.Location = New System.Drawing.Point(347, 127)
        Me.TxtChassisNo.MaxLength = 25
        Me.TxtChassisNo.Name = "TxtChassisNo"
        Me.TxtChassisNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtChassisNo.TabIndex = 5
        '
        'LblChassisNo
        '
        Me.LblChassisNo.AutoSize = True
        Me.LblChassisNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChassisNo.Location = New System.Drawing.Point(248, 130)
        Me.LblChassisNo.Name = "LblChassisNo"
        Me.LblChassisNo.Size = New System.Drawing.Size(76, 15)
        Me.LblChassisNo.TabIndex = 0
        Me.LblChassisNo.Text = "Chassis No."
        '
        'TxtEngineNo
        '
        Me.TxtEngineNo.AgMandatory = False
        Me.TxtEngineNo.AgMasterHelp = False
        Me.TxtEngineNo.AgNumberLeftPlaces = 0
        Me.TxtEngineNo.AgNumberNegetiveAllow = False
        Me.TxtEngineNo.AgNumberRightPlaces = 0
        Me.TxtEngineNo.AgPickFromLastValue = False
        Me.TxtEngineNo.AgRowFilter = ""
        Me.TxtEngineNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEngineNo.AgSelectedValue = Nothing
        Me.TxtEngineNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEngineNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEngineNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEngineNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEngineNo.Location = New System.Drawing.Point(147, 127)
        Me.TxtEngineNo.MaxLength = 25
        Me.TxtEngineNo.Name = "TxtEngineNo"
        Me.TxtEngineNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtEngineNo.TabIndex = 4
        '
        'LblEngineNo
        '
        Me.LblEngineNo.AutoSize = True
        Me.LblEngineNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblEngineNo.Location = New System.Drawing.Point(26, 129)
        Me.LblEngineNo.Name = "LblEngineNo"
        Me.LblEngineNo.Size = New System.Drawing.Size(68, 15)
        Me.LblEngineNo.TabIndex = 0
        Me.LblEngineNo.Text = "Engine No."
        '
        'LblSeatingCapacity
        '
        Me.LblSeatingCapacity.AutoSize = True
        Me.LblSeatingCapacity.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeatingCapacity.Location = New System.Drawing.Point(248, 150)
        Me.LblSeatingCapacity.Name = "LblSeatingCapacity"
        Me.LblSeatingCapacity.Size = New System.Drawing.Size(97, 13)
        Me.LblSeatingCapacity.TabIndex = 0
        Me.LblSeatingCapacity.Text = "Seating Cap~ty"
        '
        'LblOwnRented
        '
        Me.LblOwnRented.AutoSize = True
        Me.LblOwnRented.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOwnRented.Location = New System.Drawing.Point(26, 170)
        Me.LblOwnRented.Name = "LblOwnRented"
        Me.LblOwnRented.Size = New System.Drawing.Size(71, 15)
        Me.LblOwnRented.TabIndex = 0
        Me.LblOwnRented.Text = "Own/Rental"
        '
        'TxtOwnerName
        '
        Me.TxtOwnerName.AgMandatory = False
        Me.TxtOwnerName.AgMasterHelp = False
        Me.TxtOwnerName.AgNumberLeftPlaces = 0
        Me.TxtOwnerName.AgNumberNegetiveAllow = False
        Me.TxtOwnerName.AgNumberRightPlaces = 0
        Me.TxtOwnerName.AgPickFromLastValue = False
        Me.TxtOwnerName.AgRowFilter = ""
        Me.TxtOwnerName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerName.AgSelectedValue = Nothing
        Me.TxtOwnerName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerName.Location = New System.Drawing.Point(147, 187)
        Me.TxtOwnerName.MaxLength = 100
        Me.TxtOwnerName.Name = "TxtOwnerName"
        Me.TxtOwnerName.Size = New System.Drawing.Size(300, 18)
        Me.TxtOwnerName.TabIndex = 9
        '
        'LblOwnerName
        '
        Me.LblOwnerName.AutoSize = True
        Me.LblOwnerName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOwnerName.Location = New System.Drawing.Point(26, 193)
        Me.LblOwnerName.Name = "LblOwnerName"
        Me.LblOwnerName.Size = New System.Drawing.Size(80, 15)
        Me.LblOwnerName.TabIndex = 0
        Me.LblOwnerName.Text = "Owner Name"
        '
        'TxtOwnerAdd1
        '
        Me.TxtOwnerAdd1.AgMandatory = False
        Me.TxtOwnerAdd1.AgMasterHelp = False
        Me.TxtOwnerAdd1.AgNumberLeftPlaces = 0
        Me.TxtOwnerAdd1.AgNumberNegetiveAllow = False
        Me.TxtOwnerAdd1.AgNumberRightPlaces = 0
        Me.TxtOwnerAdd1.AgPickFromLastValue = False
        Me.TxtOwnerAdd1.AgRowFilter = ""
        Me.TxtOwnerAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerAdd1.AgSelectedValue = Nothing
        Me.TxtOwnerAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerAdd1.Location = New System.Drawing.Point(147, 207)
        Me.TxtOwnerAdd1.MaxLength = 50
        Me.TxtOwnerAdd1.Name = "TxtOwnerAdd1"
        Me.TxtOwnerAdd1.Size = New System.Drawing.Size(300, 18)
        Me.TxtOwnerAdd1.TabIndex = 10
        '
        'LblOwnerAdd1
        '
        Me.LblOwnerAdd1.AutoSize = True
        Me.LblOwnerAdd1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOwnerAdd1.Location = New System.Drawing.Point(26, 213)
        Me.LblOwnerAdd1.Name = "LblOwnerAdd1"
        Me.LblOwnerAdd1.Size = New System.Drawing.Size(92, 15)
        Me.LblOwnerAdd1.TabIndex = 0
        Me.LblOwnerAdd1.Text = "Owner Address"
        '
        'TxtOwnerAdd2
        '
        Me.TxtOwnerAdd2.AgMandatory = False
        Me.TxtOwnerAdd2.AgMasterHelp = False
        Me.TxtOwnerAdd2.AgNumberLeftPlaces = 0
        Me.TxtOwnerAdd2.AgNumberNegetiveAllow = False
        Me.TxtOwnerAdd2.AgNumberRightPlaces = 0
        Me.TxtOwnerAdd2.AgPickFromLastValue = False
        Me.TxtOwnerAdd2.AgRowFilter = ""
        Me.TxtOwnerAdd2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerAdd2.AgSelectedValue = Nothing
        Me.TxtOwnerAdd2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerAdd2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerAdd2.Location = New System.Drawing.Point(147, 227)
        Me.TxtOwnerAdd2.MaxLength = 50
        Me.TxtOwnerAdd2.Name = "TxtOwnerAdd2"
        Me.TxtOwnerAdd2.Size = New System.Drawing.Size(300, 18)
        Me.TxtOwnerAdd2.TabIndex = 11
        '
        'TxtOwnerAdd3
        '
        Me.TxtOwnerAdd3.AgMandatory = False
        Me.TxtOwnerAdd3.AgMasterHelp = False
        Me.TxtOwnerAdd3.AgNumberLeftPlaces = 0
        Me.TxtOwnerAdd3.AgNumberNegetiveAllow = False
        Me.TxtOwnerAdd3.AgNumberRightPlaces = 0
        Me.TxtOwnerAdd3.AgPickFromLastValue = False
        Me.TxtOwnerAdd3.AgRowFilter = ""
        Me.TxtOwnerAdd3.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerAdd3.AgSelectedValue = Nothing
        Me.TxtOwnerAdd3.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerAdd3.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerAdd3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerAdd3.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerAdd3.Location = New System.Drawing.Point(147, 271)
        Me.TxtOwnerAdd3.MaxLength = 50
        Me.TxtOwnerAdd3.Name = "TxtOwnerAdd3"
        Me.TxtOwnerAdd3.Size = New System.Drawing.Size(100, 18)
        Me.TxtOwnerAdd3.TabIndex = 12
        Me.TxtOwnerAdd3.Text = "TxtOwnerAdd3"
        Me.TxtOwnerAdd3.Visible = False
        '
        'TxtOwnerCity
        '
        Me.TxtOwnerCity.AgMandatory = False
        Me.TxtOwnerCity.AgMasterHelp = False
        Me.TxtOwnerCity.AgNumberLeftPlaces = 0
        Me.TxtOwnerCity.AgNumberNegetiveAllow = False
        Me.TxtOwnerCity.AgNumberRightPlaces = 0
        Me.TxtOwnerCity.AgPickFromLastValue = False
        Me.TxtOwnerCity.AgRowFilter = ""
        Me.TxtOwnerCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerCity.AgSelectedValue = Nothing
        Me.TxtOwnerCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerCity.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerCity.Location = New System.Drawing.Point(147, 247)
        Me.TxtOwnerCity.MaxLength = 6
        Me.TxtOwnerCity.Name = "TxtOwnerCity"
        Me.TxtOwnerCity.Size = New System.Drawing.Size(300, 18)
        Me.TxtOwnerCity.TabIndex = 13
        '
        'LblOwnerCity
        '
        Me.LblOwnerCity.AutoSize = True
        Me.LblOwnerCity.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOwnerCity.Location = New System.Drawing.Point(26, 251)
        Me.LblOwnerCity.Name = "LblOwnerCity"
        Me.LblOwnerCity.Size = New System.Drawing.Size(66, 15)
        Me.LblOwnerCity.TabIndex = 0
        Me.LblOwnerCity.Text = "Owner City"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(132, 92)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Ä"
        '
        'LblOwnRentedReq
        '
        Me.LblOwnRentedReq.AutoSize = True
        Me.LblOwnRentedReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblOwnRentedReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblOwnRentedReq.Location = New System.Drawing.Point(132, 173)
        Me.LblOwnRentedReq.Name = "LblOwnRentedReq"
        Me.LblOwnRentedReq.Size = New System.Drawing.Size(10, 7)
        Me.LblOwnRentedReq.TabIndex = 125
        Me.LblOwnRentedReq.Text = "Ä"
        '
        'TxtSeatingCapacity
        '
        Me.TxtSeatingCapacity.AgMandatory = False
        Me.TxtSeatingCapacity.AgMasterHelp = False
        Me.TxtSeatingCapacity.AgNumberLeftPlaces = 3
        Me.TxtSeatingCapacity.AgNumberNegetiveAllow = False
        Me.TxtSeatingCapacity.AgNumberRightPlaces = 0
        Me.TxtSeatingCapacity.AgPickFromLastValue = False
        Me.TxtSeatingCapacity.AgRowFilter = ""
        Me.TxtSeatingCapacity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSeatingCapacity.AgSelectedValue = Nothing
        Me.TxtSeatingCapacity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSeatingCapacity.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSeatingCapacity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSeatingCapacity.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSeatingCapacity.Location = New System.Drawing.Point(347, 147)
        Me.TxtSeatingCapacity.Name = "TxtSeatingCapacity"
        Me.TxtSeatingCapacity.Size = New System.Drawing.Size(100, 18)
        Me.TxtSeatingCapacity.TabIndex = 7
        Me.TxtSeatingCapacity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtOwnRented
        '
        Me.TxtOwnRented.AgMandatory = True
        Me.TxtOwnRented.AgMasterHelp = False
        Me.TxtOwnRented.AgNumberLeftPlaces = 0
        Me.TxtOwnRented.AgNumberNegetiveAllow = False
        Me.TxtOwnRented.AgNumberRightPlaces = 0
        Me.TxtOwnRented.AgPickFromLastValue = False
        Me.TxtOwnRented.AgRowFilter = ""
        Me.TxtOwnRented.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnRented.AgSelectedValue = Nothing
        Me.TxtOwnRented.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnRented.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnRented.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnRented.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnRented.Location = New System.Drawing.Point(147, 167)
        Me.TxtOwnRented.MaxLength = 6
        Me.TxtOwnRented.Name = "TxtOwnRented"
        Me.TxtOwnRented.Size = New System.Drawing.Size(100, 18)
        Me.TxtOwnRented.TabIndex = 8
        '
        'TxtVehicleType
        '
        Me.TxtVehicleType.AgMandatory = False
        Me.TxtVehicleType.AgMasterHelp = True
        Me.TxtVehicleType.AgNumberLeftPlaces = 0
        Me.TxtVehicleType.AgNumberNegetiveAllow = False
        Me.TxtVehicleType.AgNumberRightPlaces = 0
        Me.TxtVehicleType.AgPickFromLastValue = False
        Me.TxtVehicleType.AgRowFilter = ""
        Me.TxtVehicleType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicleType.AgSelectedValue = Nothing
        Me.TxtVehicleType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicleType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicleType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicleType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicleType.Location = New System.Drawing.Point(147, 107)
        Me.TxtVehicleType.MaxLength = 20
        Me.TxtVehicleType.Name = "TxtVehicleType"
        Me.TxtVehicleType.Size = New System.Drawing.Size(100, 18)
        Me.TxtVehicleType.TabIndex = 2
        '
        'LblVehicleType
        '
        Me.LblVehicleType.AutoSize = True
        Me.LblVehicleType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVehicleType.Location = New System.Drawing.Point(26, 111)
        Me.LblVehicleType.Name = "LblVehicleType"
        Me.LblVehicleType.Size = New System.Drawing.Size(76, 15)
        Me.LblVehicleType.TabIndex = 126
        Me.LblVehicleType.Text = "Vehicle Type"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(458, 87)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(512, 233)
        Me.Pnl1.TabIndex = 127
        '
        'LinkLblTitle
        '
        Me.LinkLblTitle.AutoSize = True
        Me.LinkLblTitle.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLblTitle.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLblTitle.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLblTitle.LinkColor = System.Drawing.Color.White
        Me.LinkLblTitle.Location = New System.Drawing.Point(457, 66)
        Me.LinkLblTitle.Name = "LinkLblTitle"
        Me.LinkLblTitle.Size = New System.Drawing.Size(176, 18)
        Me.LinkLblTitle.TabIndex = 937
        Me.LinkLblTitle.TabStop = True
        Me.LinkLblTitle.Text = "Maintinance Due Dates:"
        '
        'TxtMeterReading
        '
        Me.TxtMeterReading.AgMandatory = False
        Me.TxtMeterReading.AgMasterHelp = False
        Me.TxtMeterReading.AgNumberLeftPlaces = 8
        Me.TxtMeterReading.AgNumberNegetiveAllow = False
        Me.TxtMeterReading.AgNumberRightPlaces = 2
        Me.TxtMeterReading.AgPickFromLastValue = False
        Me.TxtMeterReading.AgRowFilter = ""
        Me.TxtMeterReading.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMeterReading.AgSelectedValue = Nothing
        Me.TxtMeterReading.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMeterReading.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMeterReading.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMeterReading.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMeterReading.Location = New System.Drawing.Point(347, 167)
        Me.TxtMeterReading.Name = "TxtMeterReading"
        Me.TxtMeterReading.Size = New System.Drawing.Size(100, 18)
        Me.TxtMeterReading.TabIndex = 939
        Me.TxtMeterReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblMeterReading
        '
        Me.LblMeterReading.AutoSize = True
        Me.LblMeterReading.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMeterReading.Location = New System.Drawing.Point(248, 170)
        Me.LblMeterReading.Name = "LblMeterReading"
        Me.LblMeterReading.Size = New System.Drawing.Size(89, 13)
        Me.LblMeterReading.TabIndex = 938
        Me.LblMeterReading.Text = "Meter Reading"
        '
        'FrmVehicle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(982, 466)
        Me.Controls.Add(Me.TxtMeterReading)
        Me.Controls.Add(Me.LblMeterReading)
        Me.Controls.Add(Me.LinkLblTitle)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtVehicleType)
        Me.Controls.Add(Me.LblVehicleType)
        Me.Controls.Add(Me.LblOwnRentedReq)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Controls.Add(Me.LblDescriptionReq)
        Me.Controls.Add(Me.TxtVehicleModel)
        Me.Controls.Add(Me.LblVehicleModel)
        Me.Controls.Add(Me.TxtMileage)
        Me.Controls.Add(Me.LblMileage)
        Me.Controls.Add(Me.TxtRegistrationNo)
        Me.Controls.Add(Me.LblRegistrationNo)
        Me.Controls.Add(Me.TxtChassisNo)
        Me.Controls.Add(Me.LblChassisNo)
        Me.Controls.Add(Me.TxtEngineNo)
        Me.Controls.Add(Me.LblEngineNo)
        Me.Controls.Add(Me.TxtSeatingCapacity)
        Me.Controls.Add(Me.LblSeatingCapacity)
        Me.Controls.Add(Me.TxtOwnRented)
        Me.Controls.Add(Me.LblOwnRented)
        Me.Controls.Add(Me.TxtOwnerName)
        Me.Controls.Add(Me.LblOwnerName)
        Me.Controls.Add(Me.TxtOwnerAdd1)
        Me.Controls.Add(Me.LblOwnerAdd1)
        Me.Controls.Add(Me.TxtOwnerAdd2)
        Me.Controls.Add(Me.TxtOwnerAdd3)
        Me.Controls.Add(Me.TxtOwnerCity)
        Me.Controls.Add(Me.LblOwnerCity)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmVehicle"
        Me.Text = "Vehicle Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents LblDescriptionReq As System.Windows.Forms.Label
    Friend WithEvents TxtVehicleModel As AgControls.AgTextBox
    Friend WithEvents LblVehicleModel As System.Windows.Forms.Label
    Friend WithEvents TxtMileage As AgControls.AgTextBox
    Friend WithEvents LblMileage As System.Windows.Forms.Label
    Friend WithEvents TxtRegistrationNo As AgControls.AgTextBox
    Friend WithEvents LblRegistrationNo As System.Windows.Forms.Label
    Friend WithEvents TxtChassisNo As AgControls.AgTextBox
    Friend WithEvents LblChassisNo As System.Windows.Forms.Label
    Friend WithEvents TxtEngineNo As AgControls.AgTextBox
    Friend WithEvents LblEngineNo As System.Windows.Forms.Label
    Friend WithEvents LblSeatingCapacity As System.Windows.Forms.Label
    Friend WithEvents LblOwnRented As System.Windows.Forms.Label
    Friend WithEvents TxtOwnerName As AgControls.AgTextBox
    Friend WithEvents LblOwnerName As System.Windows.Forms.Label
    Friend WithEvents TxtOwnerAdd1 As AgControls.AgTextBox
    Friend WithEvents LblOwnerAdd1 As System.Windows.Forms.Label
    Friend WithEvents TxtOwnerAdd2 As AgControls.AgTextBox
    Friend WithEvents TxtOwnerAdd3 As AgControls.AgTextBox
    Friend WithEvents TxtOwnerCity As AgControls.AgTextBox
    Friend WithEvents LblOwnerCity As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblOwnRentedReq As System.Windows.Forms.Label
    Friend WithEvents TxtSeatingCapacity As AgControls.AgTextBox
    Friend WithEvents TxtOwnRented As AgControls.AgTextBox
    Friend WithEvents TxtVehicleType As AgControls.AgTextBox
    Friend WithEvents LblVehicleType As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents LinkLblTitle As System.Windows.Forms.LinkLabel
    Friend WithEvents TxtMeterReading As AgControls.AgTextBox
    Friend WithEvents LblMeterReading As System.Windows.Forms.Label
End Class
