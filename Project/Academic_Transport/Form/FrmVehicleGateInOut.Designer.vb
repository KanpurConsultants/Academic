<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVehicleGateInOut
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.LblVehicleNoReq = New System.Windows.Forms.Label
        Me.TxtMeterReading = New AgControls.AgTextBox
        Me.LblMeterReading = New System.Windows.Forms.Label
        Me.LblVehicleName = New System.Windows.Forms.Label
        Me.TxtVehicleName = New AgControls.AgTextBox
        Me.LblParty = New System.Windows.Forms.Label
        Me.TxtParty = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LblVehicleNo = New System.Windows.Forms.Label
        Me.TxtVehicleNo = New AgControls.AgTextBox
        Me.LblPartyReq = New System.Windows.Forms.Label
        Me.TxtVehicleType = New AgControls.AgTextBox
        Me.LblVehicleType = New System.Windows.Forms.Label
        Me.LblInOutReq = New System.Windows.Forms.Label
        Me.TxtInOut = New AgControls.AgTextBox
        Me.LblInOut = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.TxtV_No = New AgControls.AgTextBox
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.TxtV_Type = New AgControls.AgTextBox
        Me.LblV_Type = New System.Windows.Forms.Label
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.LblV_TypeReq = New System.Windows.Forms.Label
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.LblV_No = New System.Windows.Forms.Label
        Me.TxtDivision = New AgControls.AgTextBox
        Me.TxtDocId = New AgControls.AgTextBox
        Me.LblDocId = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblManualNo = New System.Windows.Forms.Label
        Me.TxtManualNo = New AgControls.AgTextBox
        Me.TxtEntryTime = New AgControls.AgTextBox
        Me.TxtDriverName = New AgControls.AgTextBox
        Me.LblDriverName = New System.Windows.Forms.Label
        Me.LblOpenManualNo = New System.Windows.Forms.Label
        Me.TxtOpenManualNo = New AgControls.AgTextBox
        Me.TxtDateValue = New AgControls.AgTextBox
        Me.TxtCloseEntryBy = New AgControls.AgTextBox
        Me.TxtOpenMeterReading = New AgControls.AgTextBox
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'LblVehicleNoReq
        '
        Me.LblVehicleNoReq.AutoSize = True
        Me.LblVehicleNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblVehicleNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblVehicleNoReq.Location = New System.Drawing.Point(243, 124)
        Me.LblVehicleNoReq.Name = "LblVehicleNoReq"
        Me.LblVehicleNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblVehicleNoReq.TabIndex = 841
        Me.LblVehicleNoReq.Text = "Ä"
        '
        'TxtMeterReading
        '
        Me.TxtMeterReading.AgMandatory = False
        Me.TxtMeterReading.AgMasterHelp = True
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
        Me.TxtMeterReading.Location = New System.Drawing.Point(259, 138)
        Me.TxtMeterReading.MaxLength = 20
        Me.TxtMeterReading.Name = "TxtMeterReading"
        Me.TxtMeterReading.Size = New System.Drawing.Size(126, 18)
        Me.TxtMeterReading.TabIndex = 6
        Me.TxtMeterReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblMeterReading
        '
        Me.LblMeterReading.AutoSize = True
        Me.LblMeterReading.BackColor = System.Drawing.Color.Transparent
        Me.LblMeterReading.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMeterReading.Location = New System.Drawing.Point(143, 139)
        Me.LblMeterReading.Name = "LblMeterReading"
        Me.LblMeterReading.Size = New System.Drawing.Size(87, 15)
        Me.LblMeterReading.TabIndex = 840
        Me.LblMeterReading.Text = "Meter Reading"
        '
        'LblVehicleName
        '
        Me.LblVehicleName.AutoSize = True
        Me.LblVehicleName.BackColor = System.Drawing.Color.Transparent
        Me.LblVehicleName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVehicleName.Location = New System.Drawing.Point(408, 120)
        Me.LblVehicleName.Name = "LblVehicleName"
        Me.LblVehicleName.Size = New System.Drawing.Size(84, 15)
        Me.LblVehicleName.TabIndex = 839
        Me.LblVehicleName.Text = "Vehicle Name"
        '
        'TxtVehicleName
        '
        Me.TxtVehicleName.AgMandatory = False
        Me.TxtVehicleName.AgMasterHelp = True
        Me.TxtVehicleName.AgNumberLeftPlaces = 8
        Me.TxtVehicleName.AgNumberNegetiveAllow = False
        Me.TxtVehicleName.AgNumberRightPlaces = 2
        Me.TxtVehicleName.AgPickFromLastValue = False
        Me.TxtVehicleName.AgRowFilter = ""
        Me.TxtVehicleName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicleName.AgSelectedValue = Nothing
        Me.TxtVehicleName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicleName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicleName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicleName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicleName.Location = New System.Drawing.Point(506, 118)
        Me.TxtVehicleName.MaxLength = 20
        Me.TxtVehicleName.Name = "TxtVehicleName"
        Me.TxtVehicleName.Size = New System.Drawing.Size(152, 18)
        Me.TxtVehicleName.TabIndex = 5
        '
        'LblParty
        '
        Me.LblParty.AutoSize = True
        Me.LblParty.BackColor = System.Drawing.Color.Transparent
        Me.LblParty.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblParty.Location = New System.Drawing.Point(143, 160)
        Me.LblParty.Name = "LblParty"
        Me.LblParty.Size = New System.Drawing.Size(39, 15)
        Me.LblParty.TabIndex = 834
        Me.LblParty.Text = "Driver"
        '
        'TxtParty
        '
        Me.TxtParty.AgMandatory = True
        Me.TxtParty.AgMasterHelp = False
        Me.TxtParty.AgNumberLeftPlaces = 8
        Me.TxtParty.AgNumberNegetiveAllow = False
        Me.TxtParty.AgNumberRightPlaces = 2
        Me.TxtParty.AgPickFromLastValue = False
        Me.TxtParty.AgRowFilter = ""
        Me.TxtParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtParty.AgSelectedValue = Nothing
        Me.TxtParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtParty.Location = New System.Drawing.Point(259, 158)
        Me.TxtParty.MaxLength = 50
        Me.TxtParty.Name = "TxtParty"
        Me.TxtParty.Size = New System.Drawing.Size(399, 18)
        Me.TxtParty.TabIndex = 8
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(143, 180)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(58, 15)
        Me.Label30.TabIndex = 835
        Me.Label30.Text = "Remarks"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgMandatory = False
        Me.TxtRemarks.AgMasterHelp = False
        Me.TxtRemarks.AgNumberLeftPlaces = 0
        Me.TxtRemarks.AgNumberNegetiveAllow = False
        Me.TxtRemarks.AgNumberRightPlaces = 0
        Me.TxtRemarks.AgPickFromLastValue = False
        Me.TxtRemarks.AgRowFilter = ""
        Me.TxtRemarks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemarks.AgSelectedValue = Nothing
        Me.TxtRemarks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemarks.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemarks.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemarks.Location = New System.Drawing.Point(259, 178)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Multiline = True
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(399, 50)
        Me.TxtRemarks.TabIndex = 9
        '
        'LblVehicleNo
        '
        Me.LblVehicleNo.AutoSize = True
        Me.LblVehicleNo.BackColor = System.Drawing.Color.Transparent
        Me.LblVehicleNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVehicleNo.Location = New System.Drawing.Point(143, 120)
        Me.LblVehicleNo.Name = "LblVehicleNo"
        Me.LblVehicleNo.Size = New System.Drawing.Size(69, 15)
        Me.LblVehicleNo.TabIndex = 836
        Me.LblVehicleNo.Text = "Vehicle No."
        '
        'TxtVehicleNo
        '
        Me.TxtVehicleNo.AgMandatory = True
        Me.TxtVehicleNo.AgMasterHelp = False
        Me.TxtVehicleNo.AgNumberLeftPlaces = 8
        Me.TxtVehicleNo.AgNumberNegetiveAllow = False
        Me.TxtVehicleNo.AgNumberRightPlaces = 2
        Me.TxtVehicleNo.AgPickFromLastValue = False
        Me.TxtVehicleNo.AgRowFilter = ""
        Me.TxtVehicleNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicleNo.AgSelectedValue = Nothing
        Me.TxtVehicleNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicleNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicleNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicleNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicleNo.Location = New System.Drawing.Point(259, 118)
        Me.TxtVehicleNo.MaxLength = 20
        Me.TxtVehicleNo.Name = "TxtVehicleNo"
        Me.TxtVehicleNo.Size = New System.Drawing.Size(126, 18)
        Me.TxtVehicleNo.TabIndex = 4
        '
        'LblPartyReq
        '
        Me.LblPartyReq.AutoSize = True
        Me.LblPartyReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblPartyReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblPartyReq.Location = New System.Drawing.Point(243, 164)
        Me.LblPartyReq.Name = "LblPartyReq"
        Me.LblPartyReq.Size = New System.Drawing.Size(10, 7)
        Me.LblPartyReq.TabIndex = 837
        Me.LblPartyReq.Text = "Ä"
        '
        'TxtVehicleType
        '
        Me.TxtVehicleType.AgMandatory = False
        Me.TxtVehicleType.AgMasterHelp = True
        Me.TxtVehicleType.AgNumberLeftPlaces = 8
        Me.TxtVehicleType.AgNumberNegetiveAllow = False
        Me.TxtVehicleType.AgNumberRightPlaces = 2
        Me.TxtVehicleType.AgPickFromLastValue = False
        Me.TxtVehicleType.AgRowFilter = ""
        Me.TxtVehicleType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicleType.AgSelectedValue = Nothing
        Me.TxtVehicleType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicleType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicleType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicleType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicleType.Location = New System.Drawing.Point(506, 138)
        Me.TxtVehicleType.MaxLength = 20
        Me.TxtVehicleType.Name = "TxtVehicleType"
        Me.TxtVehicleType.Size = New System.Drawing.Size(152, 18)
        Me.TxtVehicleType.TabIndex = 7
        '
        'LblVehicleType
        '
        Me.LblVehicleType.AutoSize = True
        Me.LblVehicleType.BackColor = System.Drawing.Color.Transparent
        Me.LblVehicleType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVehicleType.Location = New System.Drawing.Point(408, 140)
        Me.LblVehicleType.Name = "LblVehicleType"
        Me.LblVehicleType.Size = New System.Drawing.Size(76, 15)
        Me.LblVehicleType.TabIndex = 838
        Me.LblVehicleType.Text = "Vehicle Type"
        '
        'LblInOutReq
        '
        Me.LblInOutReq.AutoSize = True
        Me.LblInOutReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblInOutReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblInOutReq.Location = New System.Drawing.Point(243, 84)
        Me.LblInOutReq.Name = "LblInOutReq"
        Me.LblInOutReq.Size = New System.Drawing.Size(10, 7)
        Me.LblInOutReq.TabIndex = 844
        Me.LblInOutReq.Text = "Ä"
        '
        'TxtInOut
        '
        Me.TxtInOut.AgMandatory = True
        Me.TxtInOut.AgMasterHelp = False
        Me.TxtInOut.AgNumberLeftPlaces = 8
        Me.TxtInOut.AgNumberNegetiveAllow = False
        Me.TxtInOut.AgNumberRightPlaces = 2
        Me.TxtInOut.AgPickFromLastValue = False
        Me.TxtInOut.AgRowFilter = ""
        Me.TxtInOut.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtInOut.AgSelectedValue = Nothing
        Me.TxtInOut.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtInOut.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtInOut.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtInOut.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInOut.Location = New System.Drawing.Point(259, 78)
        Me.TxtInOut.MaxLength = 20
        Me.TxtInOut.Name = "TxtInOut"
        Me.TxtInOut.Size = New System.Drawing.Size(126, 18)
        Me.TxtInOut.TabIndex = 0
        '
        'LblInOut
        '
        Me.LblInOut.AutoSize = True
        Me.LblInOut.BackColor = System.Drawing.Color.Transparent
        Me.LblInOut.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblInOut.Location = New System.Drawing.Point(144, 80)
        Me.LblInOut.Name = "LblInOut"
        Me.LblInOut.Size = New System.Drawing.Size(45, 15)
        Me.LblInOut.TabIndex = 843
        Me.LblInOut.Text = "In / Out"
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
        Me.Topctrl1.Size = New System.Drawing.Size(874, 41)
        Me.Topctrl1.TabIndex = 10
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
        'TxtV_No
        '
        Me.TxtV_No.AgMandatory = True
        Me.TxtV_No.AgMasterHelp = False
        Me.TxtV_No.AgNumberLeftPlaces = 8
        Me.TxtV_No.AgNumberNegetiveAllow = False
        Me.TxtV_No.AgNumberRightPlaces = 0
        Me.TxtV_No.AgPickFromLastValue = False
        Me.TxtV_No.AgRowFilter = ""
        Me.TxtV_No.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_No.AgSelectedValue = Nothing
        Me.TxtV_No.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_No.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtV_No.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtV_No.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_No.Location = New System.Drawing.Point(780, 87)
        Me.TxtV_No.Name = "TxtV_No"
        Me.TxtV_No.Size = New System.Drawing.Size(94, 18)
        Me.TxtV_No.TabIndex = 849
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtV_No.Visible = False
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(668, 48)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 854
        Me.LblSite_Code.Text = "Branch/Site"
        Me.LblSite_Code.Visible = False
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(736, 88)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(58, 16)
        Me.LblPrefix.TabIndex = 850
        Me.LblPrefix.Text = "LblPrefix"
        Me.LblPrefix.Visible = False
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
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(774, 47)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.Size = New System.Drawing.Size(100, 18)
        Me.TxtSite_Code.TabIndex = 846
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Visible = False
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(758, 53)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 851
        Me.LblSite_CodeReq.Text = "Ä"
        Me.LblSite_CodeReq.Visible = False
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgMandatory = True
        Me.TxtV_Type.AgMasterHelp = False
        Me.TxtV_Type.AgNumberLeftPlaces = 0
        Me.TxtV_Type.AgNumberNegetiveAllow = False
        Me.TxtV_Type.AgNumberRightPlaces = 0
        Me.TxtV_Type.AgPickFromLastValue = False
        Me.TxtV_Type.AgRowFilter = ""
        Me.TxtV_Type.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_Type.AgSelectedValue = Nothing
        Me.TxtV_Type.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_Type.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtV_Type.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtV_Type.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_Type.Location = New System.Drawing.Point(774, 67)
        Me.TxtV_Type.MaxLength = 5
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(100, 18)
        Me.TxtV_Type.TabIndex = 847
        Me.TxtV_Type.Visible = False
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(668, 68)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(63, 15)
        Me.LblV_Type.TabIndex = 852
        Me.LblV_Type.Text = "Entry Type"
        Me.LblV_Type.Visible = False
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgMandatory = True
        Me.TxtV_Date.AgMasterHelp = False
        Me.TxtV_Date.AgNumberLeftPlaces = 0
        Me.TxtV_Date.AgNumberNegetiveAllow = False
        Me.TxtV_Date.AgNumberRightPlaces = 0
        Me.TxtV_Date.AgPickFromLastValue = False
        Me.TxtV_Date.AgRowFilter = ""
        Me.TxtV_Date.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_Date.AgSelectedValue = Nothing
        Me.TxtV_Date.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_Date.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtV_Date.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtV_Date.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_Date.Location = New System.Drawing.Point(506, 98)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 18)
        Me.TxtV_Date.TabIndex = 2
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.AutoSize = True
        Me.LblV_TypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblV_TypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblV_TypeReq.Location = New System.Drawing.Point(758, 73)
        Me.LblV_TypeReq.Name = "LblV_TypeReq"
        Me.LblV_TypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblV_TypeReq.TabIndex = 856
        Me.LblV_TypeReq.Text = "Ä"
        Me.LblV_TypeReq.Visible = False
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(408, 100)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(63, 15)
        Me.LblV_Date.TabIndex = 853
        Me.LblV_Date.Text = "Entry Date"
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(674, 88)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(56, 15)
        Me.LblV_No.TabIndex = 855
        Me.LblV_No.Text = "Entry No."
        Me.LblV_No.Visible = False
        '
        'TxtDivision
        '
        Me.TxtDivision.AgMandatory = False
        Me.TxtDivision.AgMasterHelp = False
        Me.TxtDivision.AgNumberLeftPlaces = 0
        Me.TxtDivision.AgNumberNegetiveAllow = False
        Me.TxtDivision.AgNumberRightPlaces = 0
        Me.TxtDivision.AgPickFromLastValue = False
        Me.TxtDivision.AgRowFilter = ""
        Me.TxtDivision.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDivision.AgSelectedValue = Nothing
        Me.TxtDivision.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDivision.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDivision.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDivision.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDivision.Location = New System.Drawing.Point(774, 128)
        Me.TxtDivision.MaxLength = 2
        Me.TxtDivision.Name = "TxtDivision"
        Me.TxtDivision.Size = New System.Drawing.Size(100, 18)
        Me.TxtDivision.TabIndex = 858
        Me.TxtDivision.TabStop = False
        Me.TxtDivision.Text = "Division"
        Me.TxtDivision.Visible = False
        '
        'TxtDocId
        '
        Me.TxtDocId.AgMandatory = False
        Me.TxtDocId.AgMasterHelp = False
        Me.TxtDocId.AgNumberLeftPlaces = 0
        Me.TxtDocId.AgNumberNegetiveAllow = False
        Me.TxtDocId.AgNumberRightPlaces = 0
        Me.TxtDocId.AgPickFromLastValue = False
        Me.TxtDocId.AgRowFilter = ""
        Me.TxtDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDocId.AgSelectedValue = Nothing
        Me.TxtDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDocId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDocId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDocId.Location = New System.Drawing.Point(815, 148)
        Me.TxtDocId.MaxLength = 21
        Me.TxtDocId.Name = "TxtDocId"
        Me.TxtDocId.Size = New System.Drawing.Size(54, 18)
        Me.TxtDocId.TabIndex = 859
        Me.TxtDocId.TabStop = False
        Me.TxtDocId.Text = "HELLO WORLD"
        Me.TxtDocId.Visible = False
        '
        'LblDocId
        '
        Me.LblDocId.AutoSize = True
        Me.LblDocId.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocId.Location = New System.Drawing.Point(768, 150)
        Me.LblDocId.Name = "LblDocId"
        Me.LblDocId.Size = New System.Drawing.Size(41, 16)
        Me.LblDocId.TabIndex = 860
        Me.LblDocId.Text = "DocId"
        Me.LblDocId.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(243, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 863
        Me.Label1.Text = "Ä"
        '
        'LblManualNo
        '
        Me.LblManualNo.AutoSize = True
        Me.LblManualNo.BackColor = System.Drawing.Color.Transparent
        Me.LblManualNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualNo.Location = New System.Drawing.Point(143, 99)
        Me.LblManualNo.Name = "LblManualNo"
        Me.LblManualNo.Size = New System.Drawing.Size(56, 15)
        Me.LblManualNo.TabIndex = 862
        Me.LblManualNo.Text = "Entry No."
        '
        'TxtManualNo
        '
        Me.TxtManualNo.AgMandatory = True
        Me.TxtManualNo.AgMasterHelp = False
        Me.TxtManualNo.AgNumberLeftPlaces = 8
        Me.TxtManualNo.AgNumberNegetiveAllow = False
        Me.TxtManualNo.AgNumberRightPlaces = 2
        Me.TxtManualNo.AgPickFromLastValue = False
        Me.TxtManualNo.AgRowFilter = ""
        Me.TxtManualNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtManualNo.AgSelectedValue = Nothing
        Me.TxtManualNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtManualNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtManualNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtManualNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManualNo.Location = New System.Drawing.Point(259, 98)
        Me.TxtManualNo.MaxLength = 20
        Me.TxtManualNo.Name = "TxtManualNo"
        Me.TxtManualNo.Size = New System.Drawing.Size(126, 18)
        Me.TxtManualNo.TabIndex = 1
        '
        'TxtEntryTime
        '
        Me.TxtEntryTime.AgMandatory = False
        Me.TxtEntryTime.AgMasterHelp = True
        Me.TxtEntryTime.AgNumberLeftPlaces = 8
        Me.TxtEntryTime.AgNumberNegetiveAllow = False
        Me.TxtEntryTime.AgNumberRightPlaces = 2
        Me.TxtEntryTime.AgPickFromLastValue = False
        Me.TxtEntryTime.AgRowFilter = ""
        Me.TxtEntryTime.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEntryTime.AgSelectedValue = Nothing
        Me.TxtEntryTime.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEntryTime.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEntryTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEntryTime.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEntryTime.Location = New System.Drawing.Point(610, 98)
        Me.TxtEntryTime.MaxLength = 20
        Me.TxtEntryTime.Name = "TxtEntryTime"
        Me.TxtEntryTime.Size = New System.Drawing.Size(48, 18)
        Me.TxtEntryTime.TabIndex = 3
        '
        'TxtDriverName
        '
        Me.TxtDriverName.AgMandatory = False
        Me.TxtDriverName.AgMasterHelp = False
        Me.TxtDriverName.AgNumberLeftPlaces = 0
        Me.TxtDriverName.AgNumberNegetiveAllow = False
        Me.TxtDriverName.AgNumberRightPlaces = 0
        Me.TxtDriverName.AgPickFromLastValue = False
        Me.TxtDriverName.AgRowFilter = ""
        Me.TxtDriverName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDriverName.AgSelectedValue = Nothing
        Me.TxtDriverName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDriverName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDriverName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDriverName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDriverName.Location = New System.Drawing.Point(771, 108)
        Me.TxtDriverName.MaxLength = 50
        Me.TxtDriverName.Name = "TxtDriverName"
        Me.TxtDriverName.Size = New System.Drawing.Size(103, 18)
        Me.TxtDriverName.TabIndex = 865
        Me.TxtDriverName.Visible = False
        '
        'LblDriverName
        '
        Me.LblDriverName.AutoSize = True
        Me.LblDriverName.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDriverName.Location = New System.Drawing.Point(675, 108)
        Me.LblDriverName.Name = "LblDriverName"
        Me.LblDriverName.Size = New System.Drawing.Size(76, 15)
        Me.LblDriverName.TabIndex = 866
        Me.LblDriverName.Text = "Driver Name"
        Me.LblDriverName.Visible = False
        '
        'LblOpenManualNo
        '
        Me.LblOpenManualNo.AutoSize = True
        Me.LblOpenManualNo.BackColor = System.Drawing.Color.Transparent
        Me.LblOpenManualNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOpenManualNo.Location = New System.Drawing.Point(709, 204)
        Me.LblOpenManualNo.Name = "LblOpenManualNo"
        Me.LblOpenManualNo.Size = New System.Drawing.Size(59, 15)
        Me.LblOpenManualNo.TabIndex = 868
        Me.LblOpenManualNo.Text = "Open No."
        Me.LblOpenManualNo.Visible = False
        '
        'TxtOpenManualNo
        '
        Me.TxtOpenManualNo.AgMandatory = True
        Me.TxtOpenManualNo.AgMasterHelp = False
        Me.TxtOpenManualNo.AgNumberLeftPlaces = 8
        Me.TxtOpenManualNo.AgNumberNegetiveAllow = False
        Me.TxtOpenManualNo.AgNumberRightPlaces = 2
        Me.TxtOpenManualNo.AgPickFromLastValue = False
        Me.TxtOpenManualNo.AgRowFilter = ""
        Me.TxtOpenManualNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOpenManualNo.AgSelectedValue = Nothing
        Me.TxtOpenManualNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOpenManualNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOpenManualNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOpenManualNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOpenManualNo.Location = New System.Drawing.Point(741, 202)
        Me.TxtOpenManualNo.MaxLength = 20
        Me.TxtOpenManualNo.Name = "TxtOpenManualNo"
        Me.TxtOpenManualNo.Size = New System.Drawing.Size(136, 18)
        Me.TxtOpenManualNo.TabIndex = 867
        Me.TxtOpenManualNo.Visible = False
        '
        'TxtDateValue
        '
        Me.TxtDateValue.AgMandatory = True
        Me.TxtDateValue.AgMasterHelp = False
        Me.TxtDateValue.AgNumberLeftPlaces = 8
        Me.TxtDateValue.AgNumberNegetiveAllow = False
        Me.TxtDateValue.AgNumberRightPlaces = 2
        Me.TxtDateValue.AgPickFromLastValue = False
        Me.TxtDateValue.AgRowFilter = ""
        Me.TxtDateValue.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDateValue.AgSelectedValue = Nothing
        Me.TxtDateValue.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDateValue.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDateValue.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDateValue.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDateValue.Location = New System.Drawing.Point(774, 182)
        Me.TxtDateValue.MaxLength = 20
        Me.TxtDateValue.Name = "TxtDateValue"
        Me.TxtDateValue.Size = New System.Drawing.Size(103, 18)
        Me.TxtDateValue.TabIndex = 869
        Me.TxtDateValue.Visible = False
        '
        'TxtCloseEntryBy
        '
        Me.TxtCloseEntryBy.AgMandatory = False
        Me.TxtCloseEntryBy.AgMasterHelp = True
        Me.TxtCloseEntryBy.AgNumberLeftPlaces = 8
        Me.TxtCloseEntryBy.AgNumberNegetiveAllow = False
        Me.TxtCloseEntryBy.AgNumberRightPlaces = 2
        Me.TxtCloseEntryBy.AgPickFromLastValue = False
        Me.TxtCloseEntryBy.AgRowFilter = ""
        Me.TxtCloseEntryBy.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCloseEntryBy.AgSelectedValue = Nothing
        Me.TxtCloseEntryBy.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCloseEntryBy.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCloseEntryBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCloseEntryBy.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCloseEntryBy.Location = New System.Drawing.Point(725, 223)
        Me.TxtCloseEntryBy.MaxLength = 20
        Me.TxtCloseEntryBy.Name = "TxtCloseEntryBy"
        Me.TxtCloseEntryBy.Size = New System.Drawing.Size(152, 18)
        Me.TxtCloseEntryBy.TabIndex = 870
        Me.TxtCloseEntryBy.Text = "TxtCloseEntryBy"
        Me.TxtCloseEntryBy.Visible = False
        '
        'TxtOpenMeterReading
        '
        Me.TxtOpenMeterReading.AgMandatory = False
        Me.TxtOpenMeterReading.AgMasterHelp = True
        Me.TxtOpenMeterReading.AgNumberLeftPlaces = 8
        Me.TxtOpenMeterReading.AgNumberNegetiveAllow = False
        Me.TxtOpenMeterReading.AgNumberRightPlaces = 2
        Me.TxtOpenMeterReading.AgPickFromLastValue = False
        Me.TxtOpenMeterReading.AgRowFilter = ""
        Me.TxtOpenMeterReading.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOpenMeterReading.AgSelectedValue = Nothing
        Me.TxtOpenMeterReading.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOpenMeterReading.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtOpenMeterReading.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOpenMeterReading.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOpenMeterReading.Location = New System.Drawing.Point(796, 167)
        Me.TxtOpenMeterReading.MaxLength = 20
        Me.TxtOpenMeterReading.Name = "TxtOpenMeterReading"
        Me.TxtOpenMeterReading.Size = New System.Drawing.Size(66, 18)
        Me.TxtOpenMeterReading.TabIndex = 875
        Me.TxtOpenMeterReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TxtOpenMeterReading.Visible = False
        '
        'FrmVehicleGateInOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 298)
        Me.Controls.Add(Me.TxtOpenMeterReading)
        Me.Controls.Add(Me.TxtCloseEntryBy)
        Me.Controls.Add(Me.TxtDateValue)
        Me.Controls.Add(Me.LblOpenManualNo)
        Me.Controls.Add(Me.TxtOpenManualNo)
        Me.Controls.Add(Me.TxtDriverName)
        Me.Controls.Add(Me.LblDriverName)
        Me.Controls.Add(Me.TxtEntryTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblManualNo)
        Me.Controls.Add(Me.TxtManualNo)
        Me.Controls.Add(Me.TxtDocId)
        Me.Controls.Add(Me.LblDocId)
        Me.Controls.Add(Me.TxtDivision)
        Me.Controls.Add(Me.TxtV_No)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.LblPrefix)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.TxtV_Type)
        Me.Controls.Add(Me.LblV_Type)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.LblV_TypeReq)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.LblV_No)
        Me.Controls.Add(Me.Topctrl1)
        Me.Controls.Add(Me.LblInOutReq)
        Me.Controls.Add(Me.TxtInOut)
        Me.Controls.Add(Me.LblInOut)
        Me.Controls.Add(Me.LblVehicleNoReq)
        Me.Controls.Add(Me.TxtMeterReading)
        Me.Controls.Add(Me.LblMeterReading)
        Me.Controls.Add(Me.LblVehicleName)
        Me.Controls.Add(Me.TxtVehicleName)
        Me.Controls.Add(Me.LblParty)
        Me.Controls.Add(Me.TxtParty)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.TxtRemarks)
        Me.Controls.Add(Me.LblVehicleNo)
        Me.Controls.Add(Me.TxtVehicleNo)
        Me.Controls.Add(Me.LblPartyReq)
        Me.Controls.Add(Me.TxtVehicleType)
        Me.Controls.Add(Me.LblVehicleType)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmVehicleGateInOut"
        Me.Text = "Vehicle In/Out Entry"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents LblVehicleNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtMeterReading As AgControls.AgTextBox
    Protected WithEvents LblMeterReading As System.Windows.Forms.Label
    Protected WithEvents LblVehicleName As System.Windows.Forms.Label
    Protected WithEvents TxtVehicleName As AgControls.AgTextBox
    Protected WithEvents LblParty As System.Windows.Forms.Label
    Protected WithEvents TxtParty As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents LblVehicleNo As System.Windows.Forms.Label
    Protected WithEvents TxtVehicleNo As AgControls.AgTextBox
    Protected WithEvents LblPartyReq As System.Windows.Forms.Label
    Protected WithEvents TxtVehicleType As AgControls.AgTextBox
    Protected WithEvents LblVehicleType As System.Windows.Forms.Label
    Protected WithEvents LblInOutReq As System.Windows.Forms.Label
    Protected WithEvents TxtInOut As AgControls.AgTextBox
    Protected WithEvents LblInOut As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Public WithEvents TxtV_No As AgControls.AgTextBox
    Public WithEvents LblSite_Code As System.Windows.Forms.Label
    Public WithEvents LblPrefix As System.Windows.Forms.Label
    Public WithEvents TxtSite_Code As AgControls.AgTextBox
    Public WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Public WithEvents TxtV_Type As AgControls.AgTextBox
    Public WithEvents LblV_Type As System.Windows.Forms.Label
    Public WithEvents TxtV_Date As AgControls.AgTextBox
    Public WithEvents LblV_TypeReq As System.Windows.Forms.Label
    Public WithEvents LblV_Date As System.Windows.Forms.Label
    Public WithEvents LblV_No As System.Windows.Forms.Label
    Public WithEvents TxtDivision As AgControls.AgTextBox
    Public WithEvents TxtDocId As AgControls.AgTextBox
    Public WithEvents LblDocId As System.Windows.Forms.Label
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents LblManualNo As System.Windows.Forms.Label
    Protected WithEvents TxtManualNo As AgControls.AgTextBox
    Protected WithEvents TxtEntryTime As AgControls.AgTextBox
    Protected WithEvents TxtDriverName As AgControls.AgTextBox
    Protected WithEvents LblDriverName As System.Windows.Forms.Label
    Protected WithEvents LblOpenManualNo As System.Windows.Forms.Label
    Protected WithEvents TxtOpenManualNo As AgControls.AgTextBox
    Protected WithEvents TxtDateValue As AgControls.AgTextBox
    Protected WithEvents TxtCloseEntryBy As AgControls.AgTextBox
    Protected WithEvents TxtOpenMeterReading As AgControls.AgTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
End Class
