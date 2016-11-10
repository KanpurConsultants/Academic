Public Class FrmSize1
    Inherits AgTemplate.TempMaster
    Dim mQry$

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtFeetLength = New AgControls.AgTextBox
        Me.LblFeetLength = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblShapeReq = New System.Windows.Forms.Label
        Me.TxtShape = New AgControls.AgTextBox
        Me.LblShape = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.TxtFeetWidth = New AgControls.AgTextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtFeetArea = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtMeterArea = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtMeterWidth = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtMeterLength = New AgControls.AgTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtYardArea = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtYardWidth = New AgControls.AgTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtYardLength = New AgControls.AgTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtKFeetArea = New AgControls.AgTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtKFeetWidth = New AgControls.AgTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtKFeetLength = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtKMeterArea = New AgControls.AgTextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtKMeterWidth = New AgControls.AgTextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtKMeterLength = New AgControls.AgTextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtKYardArea = New AgControls.AgTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.TxtKYardWidth = New AgControls.AgTextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtKYardLength = New AgControls.AgTextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtKhapSizeDescription = New AgControls.AgTextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtStencilSizeDescription = New AgControls.AgTextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.Label31 = New System.Windows.Forms.Label
        Me.TxtSYardArea = New AgControls.AgTextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.TxtSYardWidth = New AgControls.AgTextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.TxtSYardLength = New AgControls.AgTextBox
        Me.Label34 = New System.Windows.Forms.Label
        Me.TxtSMeterArea = New AgControls.AgTextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.TxtSMeterWidth = New AgControls.AgTextBox
        Me.Label36 = New System.Windows.Forms.Label
        Me.TxtSMeterLength = New AgControls.AgTextBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.TxtSFeetArea = New AgControls.AgTextBox
        Me.Label38 = New System.Windows.Forms.Label
        Me.TxtSFeetWidth = New AgControls.AgTextBox
        Me.Label39 = New System.Windows.Forms.Label
        Me.TxtSFeetLength = New AgControls.AgTextBox
        Me.Label40 = New System.Windows.Forms.Label
        Me.TxtFeetDiameter = New AgControls.AgTextBox
        Me.LblDiameterFeet = New System.Windows.Forms.Label
        Me.TxtKFeetDiameter = New AgControls.AgTextBox
        Me.LblKhapDiameterFeet = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 32
        Me.Topctrl1.tAdd = False
        Me.Topctrl1.tDel = False
        Me.Topctrl1.tEdit = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(899, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(14, 425)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(553, 425)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 23)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(133, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(399, 425)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Tag = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(703, 425)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(275, 425)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Tag = ""
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Tag = ""
        '
        'TxtFeetLength
        '
        Me.TxtFeetLength.AgMandatory = True
        Me.TxtFeetLength.AgMasterHelp = True
        Me.TxtFeetLength.AgNumberLeftPlaces = 8
        Me.TxtFeetLength.AgNumberNegetiveAllow = False
        Me.TxtFeetLength.AgNumberRightPlaces = 2
        Me.TxtFeetLength.AgPickFromLastValue = False
        Me.TxtFeetLength.AgRowFilter = ""
        Me.TxtFeetLength.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFeetLength.AgSelectedValue = Nothing
        Me.TxtFeetLength.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFeetLength.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtFeetLength.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFeetLength.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFeetLength.Location = New System.Drawing.Point(301, 113)
        Me.TxtFeetLength.MaxLength = 20
        Me.TxtFeetLength.Name = "TxtFeetLength"
        Me.TxtFeetLength.Size = New System.Drawing.Size(72, 18)
        Me.TxtFeetLength.TabIndex = 1
        '
        'LblFeetLength
        '
        Me.LblFeetLength.AutoSize = True
        Me.LblFeetLength.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFeetLength.Location = New System.Drawing.Point(133, 115)
        Me.LblFeetLength.Name = "LblFeetLength"
        Me.LblFeetLength.Size = New System.Drawing.Size(68, 16)
        Me.LblFeetLength.TabIndex = 682
        Me.LblFeetLength.Text = "Size Feet "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(285, 101)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 666
        Me.Label1.Text = "Ä"
        '
        'LblShapeReq
        '
        Me.LblShapeReq.AutoSize = True
        Me.LblShapeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblShapeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblShapeReq.Location = New System.Drawing.Point(78, 67)
        Me.LblShapeReq.Name = "LblShapeReq"
        Me.LblShapeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblShapeReq.TabIndex = 664
        Me.LblShapeReq.Text = "Ä"
        Me.LblShapeReq.Visible = False
        '
        'TxtShape
        '
        Me.TxtShape.AgMandatory = False
        Me.TxtShape.AgMasterHelp = True
        Me.TxtShape.AgNumberLeftPlaces = 0
        Me.TxtShape.AgNumberNegetiveAllow = False
        Me.TxtShape.AgNumberRightPlaces = 0
        Me.TxtShape.AgPickFromLastValue = False
        Me.TxtShape.AgRowFilter = ""
        Me.TxtShape.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShape.AgSelectedValue = Nothing
        Me.TxtShape.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShape.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShape.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShape.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShape.Location = New System.Drawing.Point(94, 62)
        Me.TxtShape.MaxLength = 20
        Me.TxtShape.Multiline = True
        Me.TxtShape.Name = "TxtShape"
        Me.TxtShape.Size = New System.Drawing.Size(129, 20)
        Me.TxtShape.TabIndex = 0
        Me.TxtShape.Visible = False
        '
        'LblShape
        '
        Me.LblShape.AutoSize = True
        Me.LblShape.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShape.Location = New System.Drawing.Point(26, 62)
        Me.LblShape.Name = "LblShape"
        Me.LblShape.Size = New System.Drawing.Size(45, 16)
        Me.LblShape.TabIndex = 660
        Me.LblShape.Text = "Shape"
        Me.LblShape.Visible = False
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
        Me.TxtDescription.Location = New System.Drawing.Point(301, 93)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(367, 18)
        Me.TxtDescription.TabIndex = 0
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(133, 96)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(103, 16)
        Me.LblDescription.TabIndex = 661
        Me.LblDescription.Text = "Size Description"
        '
        'TxtFeetWidth
        '
        Me.TxtFeetWidth.AgMandatory = True
        Me.TxtFeetWidth.AgMasterHelp = True
        Me.TxtFeetWidth.AgNumberLeftPlaces = 8
        Me.TxtFeetWidth.AgNumberNegetiveAllow = False
        Me.TxtFeetWidth.AgNumberRightPlaces = 2
        Me.TxtFeetWidth.AgPickFromLastValue = False
        Me.TxtFeetWidth.AgRowFilter = ""
        Me.TxtFeetWidth.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFeetWidth.AgSelectedValue = Nothing
        Me.TxtFeetWidth.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFeetWidth.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtFeetWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFeetWidth.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFeetWidth.Location = New System.Drawing.Point(407, 113)
        Me.TxtFeetWidth.MaxLength = 20
        Me.TxtFeetWidth.Name = "TxtFeetWidth"
        Me.TxtFeetWidth.Size = New System.Drawing.Size(72, 18)
        Me.TxtFeetWidth.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(378, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(23, 16)
        Me.Label2.TabIndex = 684
        Me.Label2.Text = " X "
        '
        'TxtFeetArea
        '
        Me.TxtFeetArea.AgMandatory = True
        Me.TxtFeetArea.AgMasterHelp = True
        Me.TxtFeetArea.AgNumberLeftPlaces = 10
        Me.TxtFeetArea.AgNumberNegetiveAllow = False
        Me.TxtFeetArea.AgNumberRightPlaces = 2
        Me.TxtFeetArea.AgPickFromLastValue = False
        Me.TxtFeetArea.AgRowFilter = ""
        Me.TxtFeetArea.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFeetArea.AgSelectedValue = Nothing
        Me.TxtFeetArea.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFeetArea.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtFeetArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFeetArea.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFeetArea.Location = New System.Drawing.Point(595, 113)
        Me.TxtFeetArea.MaxLength = 20
        Me.TxtFeetArea.Name = "TxtFeetArea"
        Me.TxtFeetArea.Size = New System.Drawing.Size(73, 18)
        Me.TxtFeetArea.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(487, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 16)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Area Sq. Feet"
        '
        'TxtMeterArea
        '
        Me.TxtMeterArea.AgMandatory = True
        Me.TxtMeterArea.AgMasterHelp = True
        Me.TxtMeterArea.AgNumberLeftPlaces = 10
        Me.TxtMeterArea.AgNumberNegetiveAllow = False
        Me.TxtMeterArea.AgNumberRightPlaces = 2
        Me.TxtMeterArea.AgPickFromLastValue = False
        Me.TxtMeterArea.AgRowFilter = ""
        Me.TxtMeterArea.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMeterArea.AgSelectedValue = Nothing
        Me.TxtMeterArea.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMeterArea.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMeterArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMeterArea.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMeterArea.Location = New System.Drawing.Point(595, 153)
        Me.TxtMeterArea.MaxLength = 20
        Me.TxtMeterArea.Name = "TxtMeterArea"
        Me.TxtMeterArea.Size = New System.Drawing.Size(73, 18)
        Me.TxtMeterArea.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(487, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 692
        Me.Label4.Text = "Area Sq. Meter"
        '
        'TxtMeterWidth
        '
        Me.TxtMeterWidth.AgMandatory = True
        Me.TxtMeterWidth.AgMasterHelp = True
        Me.TxtMeterWidth.AgNumberLeftPlaces = 8
        Me.TxtMeterWidth.AgNumberNegetiveAllow = False
        Me.TxtMeterWidth.AgNumberRightPlaces = 2
        Me.TxtMeterWidth.AgPickFromLastValue = False
        Me.TxtMeterWidth.AgRowFilter = ""
        Me.TxtMeterWidth.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMeterWidth.AgSelectedValue = Nothing
        Me.TxtMeterWidth.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMeterWidth.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMeterWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMeterWidth.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMeterWidth.Location = New System.Drawing.Point(407, 153)
        Me.TxtMeterWidth.MaxLength = 20
        Me.TxtMeterWidth.Name = "TxtMeterWidth"
        Me.TxtMeterWidth.Size = New System.Drawing.Size(72, 18)
        Me.TxtMeterWidth.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(378, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(23, 16)
        Me.Label5.TabIndex = 690
        Me.Label5.Text = " X "
        '
        'TxtMeterLength
        '
        Me.TxtMeterLength.AgMandatory = True
        Me.TxtMeterLength.AgMasterHelp = True
        Me.TxtMeterLength.AgNumberLeftPlaces = 8
        Me.TxtMeterLength.AgNumberNegetiveAllow = False
        Me.TxtMeterLength.AgNumberRightPlaces = 2
        Me.TxtMeterLength.AgPickFromLastValue = False
        Me.TxtMeterLength.AgRowFilter = ""
        Me.TxtMeterLength.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMeterLength.AgSelectedValue = Nothing
        Me.TxtMeterLength.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMeterLength.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMeterLength.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMeterLength.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMeterLength.Location = New System.Drawing.Point(301, 153)
        Me.TxtMeterLength.MaxLength = 20
        Me.TxtMeterLength.Name = "TxtMeterLength"
        Me.TxtMeterLength.Size = New System.Drawing.Size(72, 18)
        Me.TxtMeterLength.TabIndex = 5
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(133, 155)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 688
        Me.Label6.Text = "Size Meter"
        '
        'TxtYardArea
        '
        Me.TxtYardArea.AgMandatory = True
        Me.TxtYardArea.AgMasterHelp = True
        Me.TxtYardArea.AgNumberLeftPlaces = 10
        Me.TxtYardArea.AgNumberNegetiveAllow = False
        Me.TxtYardArea.AgNumberRightPlaces = 2
        Me.TxtYardArea.AgPickFromLastValue = False
        Me.TxtYardArea.AgRowFilter = ""
        Me.TxtYardArea.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtYardArea.AgSelectedValue = Nothing
        Me.TxtYardArea.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtYardArea.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtYardArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtYardArea.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYardArea.Location = New System.Drawing.Point(595, 173)
        Me.TxtYardArea.MaxLength = 20
        Me.TxtYardArea.Name = "TxtYardArea"
        Me.TxtYardArea.Size = New System.Drawing.Size(73, 18)
        Me.TxtYardArea.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(487, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 16)
        Me.Label7.TabIndex = 698
        Me.Label7.Text = "Area Sq. Yard"
        '
        'TxtYardWidth
        '
        Me.TxtYardWidth.AgMandatory = True
        Me.TxtYardWidth.AgMasterHelp = True
        Me.TxtYardWidth.AgNumberLeftPlaces = 8
        Me.TxtYardWidth.AgNumberNegetiveAllow = False
        Me.TxtYardWidth.AgNumberRightPlaces = 2
        Me.TxtYardWidth.AgPickFromLastValue = False
        Me.TxtYardWidth.AgRowFilter = ""
        Me.TxtYardWidth.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtYardWidth.AgSelectedValue = Nothing
        Me.TxtYardWidth.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtYardWidth.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtYardWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtYardWidth.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYardWidth.Location = New System.Drawing.Point(407, 173)
        Me.TxtYardWidth.MaxLength = 20
        Me.TxtYardWidth.Name = "TxtYardWidth"
        Me.TxtYardWidth.Size = New System.Drawing.Size(72, 18)
        Me.TxtYardWidth.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(378, 177)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 16)
        Me.Label8.TabIndex = 696
        Me.Label8.Text = " X "
        '
        'TxtYardLength
        '
        Me.TxtYardLength.AgMandatory = True
        Me.TxtYardLength.AgMasterHelp = True
        Me.TxtYardLength.AgNumberLeftPlaces = 8
        Me.TxtYardLength.AgNumberNegetiveAllow = False
        Me.TxtYardLength.AgNumberRightPlaces = 2
        Me.TxtYardLength.AgPickFromLastValue = False
        Me.TxtYardLength.AgRowFilter = ""
        Me.TxtYardLength.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtYardLength.AgSelectedValue = Nothing
        Me.TxtYardLength.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtYardLength.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtYardLength.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtYardLength.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtYardLength.Location = New System.Drawing.Point(301, 173)
        Me.TxtYardLength.MaxLength = 20
        Me.TxtYardLength.Name = "TxtYardLength"
        Me.TxtYardLength.Size = New System.Drawing.Size(72, 18)
        Me.TxtYardLength.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(133, 175)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 16)
        Me.Label9.TabIndex = 694
        Me.Label9.Text = "Size Yard"
        '
        'TxtKFeetArea
        '
        Me.TxtKFeetArea.AgMandatory = True
        Me.TxtKFeetArea.AgMasterHelp = True
        Me.TxtKFeetArea.AgNumberLeftPlaces = 10
        Me.TxtKFeetArea.AgNumberNegetiveAllow = False
        Me.TxtKFeetArea.AgNumberRightPlaces = 2
        Me.TxtKFeetArea.AgPickFromLastValue = False
        Me.TxtKFeetArea.AgRowFilter = ""
        Me.TxtKFeetArea.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKFeetArea.AgSelectedValue = Nothing
        Me.TxtKFeetArea.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKFeetArea.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtKFeetArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKFeetArea.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKFeetArea.Location = New System.Drawing.Point(595, 213)
        Me.TxtKFeetArea.MaxLength = 20
        Me.TxtKFeetArea.Name = "TxtKFeetArea"
        Me.TxtKFeetArea.Size = New System.Drawing.Size(73, 18)
        Me.TxtKFeetArea.TabIndex = 14
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(487, 214)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 16)
        Me.Label10.TabIndex = 704
        Me.Label10.Text = "Area Sq. Feet"
        '
        'TxtKFeetWidth
        '
        Me.TxtKFeetWidth.AgMandatory = True
        Me.TxtKFeetWidth.AgMasterHelp = True
        Me.TxtKFeetWidth.AgNumberLeftPlaces = 8
        Me.TxtKFeetWidth.AgNumberNegetiveAllow = False
        Me.TxtKFeetWidth.AgNumberRightPlaces = 2
        Me.TxtKFeetWidth.AgPickFromLastValue = False
        Me.TxtKFeetWidth.AgRowFilter = ""
        Me.TxtKFeetWidth.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKFeetWidth.AgSelectedValue = Nothing
        Me.TxtKFeetWidth.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKFeetWidth.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtKFeetWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKFeetWidth.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKFeetWidth.Location = New System.Drawing.Point(407, 213)
        Me.TxtKFeetWidth.MaxLength = 20
        Me.TxtKFeetWidth.Name = "TxtKFeetWidth"
        Me.TxtKFeetWidth.Size = New System.Drawing.Size(72, 18)
        Me.TxtKFeetWidth.TabIndex = 13
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(378, 217)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(23, 16)
        Me.Label11.TabIndex = 702
        Me.Label11.Text = " X "
        '
        'TxtKFeetLength
        '
        Me.TxtKFeetLength.AgMandatory = True
        Me.TxtKFeetLength.AgMasterHelp = True
        Me.TxtKFeetLength.AgNumberLeftPlaces = 8
        Me.TxtKFeetLength.AgNumberNegetiveAllow = False
        Me.TxtKFeetLength.AgNumberRightPlaces = 2
        Me.TxtKFeetLength.AgPickFromLastValue = False
        Me.TxtKFeetLength.AgRowFilter = ""
        Me.TxtKFeetLength.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKFeetLength.AgSelectedValue = Nothing
        Me.TxtKFeetLength.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKFeetLength.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtKFeetLength.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKFeetLength.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKFeetLength.Location = New System.Drawing.Point(301, 213)
        Me.TxtKFeetLength.MaxLength = 20
        Me.TxtKFeetLength.Name = "TxtKFeetLength"
        Me.TxtKFeetLength.Size = New System.Drawing.Size(72, 18)
        Me.TxtKFeetLength.TabIndex = 12
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(133, 215)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 16)
        Me.Label12.TabIndex = 700
        Me.Label12.Text = "Khap Size Feet "
        '
        'TxtKMeterArea
        '
        Me.TxtKMeterArea.AgMandatory = True
        Me.TxtKMeterArea.AgMasterHelp = True
        Me.TxtKMeterArea.AgNumberLeftPlaces = 10
        Me.TxtKMeterArea.AgNumberNegetiveAllow = False
        Me.TxtKMeterArea.AgNumberRightPlaces = 2
        Me.TxtKMeterArea.AgPickFromLastValue = False
        Me.TxtKMeterArea.AgRowFilter = ""
        Me.TxtKMeterArea.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKMeterArea.AgSelectedValue = Nothing
        Me.TxtKMeterArea.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKMeterArea.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtKMeterArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKMeterArea.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKMeterArea.Location = New System.Drawing.Point(595, 253)
        Me.TxtKMeterArea.MaxLength = 20
        Me.TxtKMeterArea.Name = "TxtKMeterArea"
        Me.TxtKMeterArea.Size = New System.Drawing.Size(73, 18)
        Me.TxtKMeterArea.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(487, 254)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 16)
        Me.Label13.TabIndex = 710
        Me.Label13.Text = "Area Sq. Meter"
        '
        'TxtKMeterWidth
        '
        Me.TxtKMeterWidth.AgMandatory = True
        Me.TxtKMeterWidth.AgMasterHelp = True
        Me.TxtKMeterWidth.AgNumberLeftPlaces = 8
        Me.TxtKMeterWidth.AgNumberNegetiveAllow = False
        Me.TxtKMeterWidth.AgNumberRightPlaces = 2
        Me.TxtKMeterWidth.AgPickFromLastValue = False
        Me.TxtKMeterWidth.AgRowFilter = ""
        Me.TxtKMeterWidth.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKMeterWidth.AgSelectedValue = Nothing
        Me.TxtKMeterWidth.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKMeterWidth.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtKMeterWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKMeterWidth.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKMeterWidth.Location = New System.Drawing.Point(407, 253)
        Me.TxtKMeterWidth.MaxLength = 20
        Me.TxtKMeterWidth.Name = "TxtKMeterWidth"
        Me.TxtKMeterWidth.Size = New System.Drawing.Size(72, 18)
        Me.TxtKMeterWidth.TabIndex = 17
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(378, 257)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(23, 16)
        Me.Label14.TabIndex = 708
        Me.Label14.Text = " X "
        '
        'TxtKMeterLength
        '
        Me.TxtKMeterLength.AgMandatory = True
        Me.TxtKMeterLength.AgMasterHelp = True
        Me.TxtKMeterLength.AgNumberLeftPlaces = 8
        Me.TxtKMeterLength.AgNumberNegetiveAllow = False
        Me.TxtKMeterLength.AgNumberRightPlaces = 2
        Me.TxtKMeterLength.AgPickFromLastValue = False
        Me.TxtKMeterLength.AgRowFilter = ""
        Me.TxtKMeterLength.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKMeterLength.AgSelectedValue = Nothing
        Me.TxtKMeterLength.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKMeterLength.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtKMeterLength.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKMeterLength.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKMeterLength.Location = New System.Drawing.Point(301, 253)
        Me.TxtKMeterLength.MaxLength = 20
        Me.TxtKMeterLength.Name = "TxtKMeterLength"
        Me.TxtKMeterLength.Size = New System.Drawing.Size(72, 18)
        Me.TxtKMeterLength.TabIndex = 16
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(133, 257)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(105, 16)
        Me.Label15.TabIndex = 706
        Me.Label15.Text = "Khap Size Meter"
        '
        'TxtKYardArea
        '
        Me.TxtKYardArea.AgMandatory = True
        Me.TxtKYardArea.AgMasterHelp = True
        Me.TxtKYardArea.AgNumberLeftPlaces = 10
        Me.TxtKYardArea.AgNumberNegetiveAllow = False
        Me.TxtKYardArea.AgNumberRightPlaces = 2
        Me.TxtKYardArea.AgPickFromLastValue = False
        Me.TxtKYardArea.AgRowFilter = ""
        Me.TxtKYardArea.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKYardArea.AgSelectedValue = Nothing
        Me.TxtKYardArea.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKYardArea.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtKYardArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKYardArea.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKYardArea.Location = New System.Drawing.Point(595, 273)
        Me.TxtKYardArea.MaxLength = 20
        Me.TxtKYardArea.Name = "TxtKYardArea"
        Me.TxtKYardArea.Size = New System.Drawing.Size(73, 18)
        Me.TxtKYardArea.TabIndex = 21
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(487, 275)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 16)
        Me.Label16.TabIndex = 716
        Me.Label16.Text = "Area Sq. Yard"
        '
        'TxtKYardWidth
        '
        Me.TxtKYardWidth.AgMandatory = True
        Me.TxtKYardWidth.AgMasterHelp = True
        Me.TxtKYardWidth.AgNumberLeftPlaces = 8
        Me.TxtKYardWidth.AgNumberNegetiveAllow = False
        Me.TxtKYardWidth.AgNumberRightPlaces = 2
        Me.TxtKYardWidth.AgPickFromLastValue = False
        Me.TxtKYardWidth.AgRowFilter = ""
        Me.TxtKYardWidth.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKYardWidth.AgSelectedValue = Nothing
        Me.TxtKYardWidth.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKYardWidth.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtKYardWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKYardWidth.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKYardWidth.Location = New System.Drawing.Point(407, 273)
        Me.TxtKYardWidth.MaxLength = 20
        Me.TxtKYardWidth.Name = "TxtKYardWidth"
        Me.TxtKYardWidth.Size = New System.Drawing.Size(72, 18)
        Me.TxtKYardWidth.TabIndex = 20
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(378, 278)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(23, 16)
        Me.Label17.TabIndex = 714
        Me.Label17.Text = " X "
        '
        'TxtKYardLength
        '
        Me.TxtKYardLength.AgMandatory = True
        Me.TxtKYardLength.AgMasterHelp = True
        Me.TxtKYardLength.AgNumberLeftPlaces = 8
        Me.TxtKYardLength.AgNumberNegetiveAllow = False
        Me.TxtKYardLength.AgNumberRightPlaces = 2
        Me.TxtKYardLength.AgPickFromLastValue = False
        Me.TxtKYardLength.AgRowFilter = ""
        Me.TxtKYardLength.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKYardLength.AgSelectedValue = Nothing
        Me.TxtKYardLength.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKYardLength.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtKYardLength.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKYardLength.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKYardLength.Location = New System.Drawing.Point(301, 273)
        Me.TxtKYardLength.MaxLength = 20
        Me.TxtKYardLength.Name = "TxtKYardLength"
        Me.TxtKYardLength.Size = New System.Drawing.Size(72, 18)
        Me.TxtKYardLength.TabIndex = 19
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(133, 275)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(98, 16)
        Me.Label18.TabIndex = 712
        Me.Label18.Text = "Khap Size Yard"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label19.Location = New System.Drawing.Point(285, 121)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 7)
        Me.Label19.TabIndex = 717
        Me.Label19.Text = "Ä"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label20.Location = New System.Drawing.Point(285, 161)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(10, 7)
        Me.Label20.TabIndex = 718
        Me.Label20.Text = "Ä"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label21.Location = New System.Drawing.Point(285, 180)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(10, 7)
        Me.Label21.TabIndex = 719
        Me.Label21.Text = "Ä"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label22.Location = New System.Drawing.Point(285, 221)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(10, 7)
        Me.Label22.TabIndex = 720
        Me.Label22.Text = "Ä"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label23.Location = New System.Drawing.Point(285, 261)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 7)
        Me.Label23.TabIndex = 721
        Me.Label23.Text = "Ä"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label24.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label24.Location = New System.Drawing.Point(285, 280)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(10, 7)
        Me.Label24.TabIndex = 722
        Me.Label24.Text = "Ä"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label25.Location = New System.Drawing.Point(285, 201)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(10, 7)
        Me.Label25.TabIndex = 725
        Me.Label25.Text = "Ä"
        '
        'TxtKhapSizeDescription
        '
        Me.TxtKhapSizeDescription.AgMandatory = True
        Me.TxtKhapSizeDescription.AgMasterHelp = True
        Me.TxtKhapSizeDescription.AgNumberLeftPlaces = 0
        Me.TxtKhapSizeDescription.AgNumberNegetiveAllow = False
        Me.TxtKhapSizeDescription.AgNumberRightPlaces = 0
        Me.TxtKhapSizeDescription.AgPickFromLastValue = False
        Me.TxtKhapSizeDescription.AgRowFilter = ""
        Me.TxtKhapSizeDescription.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKhapSizeDescription.AgSelectedValue = Nothing
        Me.TxtKhapSizeDescription.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKhapSizeDescription.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtKhapSizeDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKhapSizeDescription.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKhapSizeDescription.Location = New System.Drawing.Point(301, 193)
        Me.TxtKhapSizeDescription.MaxLength = 50
        Me.TxtKhapSizeDescription.Name = "TxtKhapSizeDescription"
        Me.TxtKhapSizeDescription.Size = New System.Drawing.Size(367, 18)
        Me.TxtKhapSizeDescription.TabIndex = 11
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(133, 195)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(137, 16)
        Me.Label26.TabIndex = 724
        Me.Label26.Text = "Khap Size Description"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label27.Location = New System.Drawing.Point(285, 301)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(10, 7)
        Me.Label27.TabIndex = 728
        Me.Label27.Text = "Ä"
        '
        'TxtStencilSizeDescription
        '
        Me.TxtStencilSizeDescription.AgMandatory = True
        Me.TxtStencilSizeDescription.AgMasterHelp = True
        Me.TxtStencilSizeDescription.AgNumberLeftPlaces = 0
        Me.TxtStencilSizeDescription.AgNumberNegetiveAllow = False
        Me.TxtStencilSizeDescription.AgNumberRightPlaces = 0
        Me.TxtStencilSizeDescription.AgPickFromLastValue = False
        Me.TxtStencilSizeDescription.AgRowFilter = ""
        Me.TxtStencilSizeDescription.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStencilSizeDescription.AgSelectedValue = Nothing
        Me.TxtStencilSizeDescription.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStencilSizeDescription.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStencilSizeDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStencilSizeDescription.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStencilSizeDescription.Location = New System.Drawing.Point(301, 293)
        Me.TxtStencilSizeDescription.MaxLength = 50
        Me.TxtStencilSizeDescription.Name = "TxtStencilSizeDescription"
        Me.TxtStencilSizeDescription.Size = New System.Drawing.Size(367, 18)
        Me.TxtStencilSizeDescription.TabIndex = 22
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(133, 296)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(147, 16)
        Me.Label28.TabIndex = 727
        Me.Label28.Text = "Stencil Size Description"
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label29.Location = New System.Drawing.Point(285, 360)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(10, 7)
        Me.Label29.TabIndex = 749
        Me.Label29.Text = "Ä"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label30.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label30.Location = New System.Drawing.Point(285, 341)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(10, 7)
        Me.Label30.TabIndex = 748
        Me.Label30.Text = "Ä"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label31.Location = New System.Drawing.Point(285, 321)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(10, 7)
        Me.Label31.TabIndex = 747
        Me.Label31.Text = "Ä"
        '
        'TxtSYardArea
        '
        Me.TxtSYardArea.AgMandatory = True
        Me.TxtSYardArea.AgMasterHelp = True
        Me.TxtSYardArea.AgNumberLeftPlaces = 10
        Me.TxtSYardArea.AgNumberNegetiveAllow = False
        Me.TxtSYardArea.AgNumberRightPlaces = 2
        Me.TxtSYardArea.AgPickFromLastValue = False
        Me.TxtSYardArea.AgRowFilter = ""
        Me.TxtSYardArea.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSYardArea.AgSelectedValue = Nothing
        Me.TxtSYardArea.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSYardArea.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSYardArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSYardArea.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSYardArea.Location = New System.Drawing.Point(595, 353)
        Me.TxtSYardArea.MaxLength = 20
        Me.TxtSYardArea.Name = "TxtSYardArea"
        Me.TxtSYardArea.Size = New System.Drawing.Size(73, 18)
        Me.TxtSYardArea.TabIndex = 31
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(487, 355)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(89, 16)
        Me.Label32.TabIndex = 746
        Me.Label32.Text = "Area Sq. Yard"
        '
        'TxtSYardWidth
        '
        Me.TxtSYardWidth.AgMandatory = True
        Me.TxtSYardWidth.AgMasterHelp = True
        Me.TxtSYardWidth.AgNumberLeftPlaces = 8
        Me.TxtSYardWidth.AgNumberNegetiveAllow = False
        Me.TxtSYardWidth.AgNumberRightPlaces = 2
        Me.TxtSYardWidth.AgPickFromLastValue = False
        Me.TxtSYardWidth.AgRowFilter = ""
        Me.TxtSYardWidth.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSYardWidth.AgSelectedValue = Nothing
        Me.TxtSYardWidth.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSYardWidth.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSYardWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSYardWidth.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSYardWidth.Location = New System.Drawing.Point(407, 353)
        Me.TxtSYardWidth.MaxLength = 20
        Me.TxtSYardWidth.Name = "TxtSYardWidth"
        Me.TxtSYardWidth.Size = New System.Drawing.Size(72, 18)
        Me.TxtSYardWidth.TabIndex = 30
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(378, 358)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(23, 16)
        Me.Label33.TabIndex = 745
        Me.Label33.Text = " X "
        '
        'TxtSYardLength
        '
        Me.TxtSYardLength.AgMandatory = True
        Me.TxtSYardLength.AgMasterHelp = True
        Me.TxtSYardLength.AgNumberLeftPlaces = 8
        Me.TxtSYardLength.AgNumberNegetiveAllow = False
        Me.TxtSYardLength.AgNumberRightPlaces = 2
        Me.TxtSYardLength.AgPickFromLastValue = False
        Me.TxtSYardLength.AgRowFilter = ""
        Me.TxtSYardLength.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSYardLength.AgSelectedValue = Nothing
        Me.TxtSYardLength.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSYardLength.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSYardLength.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSYardLength.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSYardLength.Location = New System.Drawing.Point(301, 353)
        Me.TxtSYardLength.MaxLength = 20
        Me.TxtSYardLength.Name = "TxtSYardLength"
        Me.TxtSYardLength.Size = New System.Drawing.Size(72, 18)
        Me.TxtSYardLength.TabIndex = 29
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(133, 358)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(108, 16)
        Me.Label34.TabIndex = 744
        Me.Label34.Text = "Stencil Size Yard"
        '
        'TxtSMeterArea
        '
        Me.TxtSMeterArea.AgMandatory = True
        Me.TxtSMeterArea.AgMasterHelp = True
        Me.TxtSMeterArea.AgNumberLeftPlaces = 10
        Me.TxtSMeterArea.AgNumberNegetiveAllow = False
        Me.TxtSMeterArea.AgNumberRightPlaces = 2
        Me.TxtSMeterArea.AgPickFromLastValue = False
        Me.TxtSMeterArea.AgRowFilter = ""
        Me.TxtSMeterArea.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSMeterArea.AgSelectedValue = Nothing
        Me.TxtSMeterArea.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSMeterArea.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSMeterArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSMeterArea.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSMeterArea.Location = New System.Drawing.Point(595, 333)
        Me.TxtSMeterArea.MaxLength = 20
        Me.TxtSMeterArea.Name = "TxtSMeterArea"
        Me.TxtSMeterArea.Size = New System.Drawing.Size(73, 18)
        Me.TxtSMeterArea.TabIndex = 28
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(487, 334)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(96, 16)
        Me.Label35.TabIndex = 743
        Me.Label35.Text = "Area Sq. Meter"
        '
        'TxtSMeterWidth
        '
        Me.TxtSMeterWidth.AgMandatory = True
        Me.TxtSMeterWidth.AgMasterHelp = True
        Me.TxtSMeterWidth.AgNumberLeftPlaces = 8
        Me.TxtSMeterWidth.AgNumberNegetiveAllow = False
        Me.TxtSMeterWidth.AgNumberRightPlaces = 2
        Me.TxtSMeterWidth.AgPickFromLastValue = False
        Me.TxtSMeterWidth.AgRowFilter = ""
        Me.TxtSMeterWidth.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSMeterWidth.AgSelectedValue = Nothing
        Me.TxtSMeterWidth.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSMeterWidth.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSMeterWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSMeterWidth.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSMeterWidth.Location = New System.Drawing.Point(407, 333)
        Me.TxtSMeterWidth.MaxLength = 20
        Me.TxtSMeterWidth.Name = "TxtSMeterWidth"
        Me.TxtSMeterWidth.Size = New System.Drawing.Size(72, 18)
        Me.TxtSMeterWidth.TabIndex = 27
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(378, 337)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(23, 16)
        Me.Label36.TabIndex = 742
        Me.Label36.Text = " X "
        '
        'TxtSMeterLength
        '
        Me.TxtSMeterLength.AgMandatory = True
        Me.TxtSMeterLength.AgMasterHelp = True
        Me.TxtSMeterLength.AgNumberLeftPlaces = 8
        Me.TxtSMeterLength.AgNumberNegetiveAllow = False
        Me.TxtSMeterLength.AgNumberRightPlaces = 2
        Me.TxtSMeterLength.AgPickFromLastValue = False
        Me.TxtSMeterLength.AgRowFilter = ""
        Me.TxtSMeterLength.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSMeterLength.AgSelectedValue = Nothing
        Me.TxtSMeterLength.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSMeterLength.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSMeterLength.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSMeterLength.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSMeterLength.Location = New System.Drawing.Point(301, 333)
        Me.TxtSMeterLength.MaxLength = 20
        Me.TxtSMeterLength.Name = "TxtSMeterLength"
        Me.TxtSMeterLength.Size = New System.Drawing.Size(72, 18)
        Me.TxtSMeterLength.TabIndex = 26
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(133, 337)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(115, 16)
        Me.Label37.TabIndex = 741
        Me.Label37.Text = "Stencil Size Meter"
        '
        'TxtSFeetArea
        '
        Me.TxtSFeetArea.AgMandatory = True
        Me.TxtSFeetArea.AgMasterHelp = True
        Me.TxtSFeetArea.AgNumberLeftPlaces = 10
        Me.TxtSFeetArea.AgNumberNegetiveAllow = False
        Me.TxtSFeetArea.AgNumberRightPlaces = 2
        Me.TxtSFeetArea.AgPickFromLastValue = False
        Me.TxtSFeetArea.AgRowFilter = ""
        Me.TxtSFeetArea.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSFeetArea.AgSelectedValue = Nothing
        Me.TxtSFeetArea.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSFeetArea.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSFeetArea.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSFeetArea.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSFeetArea.Location = New System.Drawing.Point(595, 313)
        Me.TxtSFeetArea.MaxLength = 20
        Me.TxtSFeetArea.Name = "TxtSFeetArea"
        Me.TxtSFeetArea.Size = New System.Drawing.Size(73, 18)
        Me.TxtSFeetArea.TabIndex = 25
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(487, 314)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(89, 16)
        Me.Label38.TabIndex = 740
        Me.Label38.Text = "Area Sq. Feet"
        '
        'TxtSFeetWidth
        '
        Me.TxtSFeetWidth.AgMandatory = True
        Me.TxtSFeetWidth.AgMasterHelp = True
        Me.TxtSFeetWidth.AgNumberLeftPlaces = 8
        Me.TxtSFeetWidth.AgNumberNegetiveAllow = False
        Me.TxtSFeetWidth.AgNumberRightPlaces = 2
        Me.TxtSFeetWidth.AgPickFromLastValue = False
        Me.TxtSFeetWidth.AgRowFilter = ""
        Me.TxtSFeetWidth.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSFeetWidth.AgSelectedValue = Nothing
        Me.TxtSFeetWidth.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSFeetWidth.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSFeetWidth.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSFeetWidth.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSFeetWidth.Location = New System.Drawing.Point(407, 313)
        Me.TxtSFeetWidth.MaxLength = 20
        Me.TxtSFeetWidth.Name = "TxtSFeetWidth"
        Me.TxtSFeetWidth.Size = New System.Drawing.Size(72, 18)
        Me.TxtSFeetWidth.TabIndex = 24
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(378, 317)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(23, 16)
        Me.Label39.TabIndex = 739
        Me.Label39.Text = " X "
        '
        'TxtSFeetLength
        '
        Me.TxtSFeetLength.AgMandatory = True
        Me.TxtSFeetLength.AgMasterHelp = True
        Me.TxtSFeetLength.AgNumberLeftPlaces = 8
        Me.TxtSFeetLength.AgNumberNegetiveAllow = False
        Me.TxtSFeetLength.AgNumberRightPlaces = 2
        Me.TxtSFeetLength.AgPickFromLastValue = False
        Me.TxtSFeetLength.AgRowFilter = ""
        Me.TxtSFeetLength.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSFeetLength.AgSelectedValue = Nothing
        Me.TxtSFeetLength.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSFeetLength.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtSFeetLength.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSFeetLength.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSFeetLength.Location = New System.Drawing.Point(301, 313)
        Me.TxtSFeetLength.MaxLength = 20
        Me.TxtSFeetLength.Name = "TxtSFeetLength"
        Me.TxtSFeetLength.Size = New System.Drawing.Size(72, 18)
        Me.TxtSFeetLength.TabIndex = 23
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(133, 317)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(112, 16)
        Me.Label40.TabIndex = 738
        Me.Label40.Text = "Stencil Size Feet "
        '
        'TxtFeetDiameter
        '
        Me.TxtFeetDiameter.AgMandatory = True
        Me.TxtFeetDiameter.AgMasterHelp = True
        Me.TxtFeetDiameter.AgNumberLeftPlaces = 10
        Me.TxtFeetDiameter.AgNumberNegetiveAllow = False
        Me.TxtFeetDiameter.AgNumberRightPlaces = 2
        Me.TxtFeetDiameter.AgPickFromLastValue = False
        Me.TxtFeetDiameter.AgRowFilter = ""
        Me.TxtFeetDiameter.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFeetDiameter.AgSelectedValue = Nothing
        Me.TxtFeetDiameter.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFeetDiameter.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtFeetDiameter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFeetDiameter.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFeetDiameter.Location = New System.Drawing.Point(301, 133)
        Me.TxtFeetDiameter.MaxLength = 20
        Me.TxtFeetDiameter.Name = "TxtFeetDiameter"
        Me.TxtFeetDiameter.Size = New System.Drawing.Size(178, 18)
        Me.TxtFeetDiameter.TabIndex = 4
        '
        'LblDiameterFeet
        '
        Me.LblDiameterFeet.AutoSize = True
        Me.LblDiameterFeet.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiameterFeet.Location = New System.Drawing.Point(133, 135)
        Me.LblDiameterFeet.Name = "LblDiameterFeet"
        Me.LblDiameterFeet.Size = New System.Drawing.Size(94, 16)
        Me.LblDiameterFeet.TabIndex = 750
        Me.LblDiameterFeet.Text = "Perimeter Feet"
        '
        'TxtKFeetDiameter
        '
        Me.TxtKFeetDiameter.AgMandatory = True
        Me.TxtKFeetDiameter.AgMasterHelp = True
        Me.TxtKFeetDiameter.AgNumberLeftPlaces = 10
        Me.TxtKFeetDiameter.AgNumberNegetiveAllow = False
        Me.TxtKFeetDiameter.AgNumberRightPlaces = 2
        Me.TxtKFeetDiameter.AgPickFromLastValue = False
        Me.TxtKFeetDiameter.AgRowFilter = ""
        Me.TxtKFeetDiameter.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKFeetDiameter.AgSelectedValue = Nothing
        Me.TxtKFeetDiameter.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKFeetDiameter.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtKFeetDiameter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKFeetDiameter.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKFeetDiameter.Location = New System.Drawing.Point(301, 233)
        Me.TxtKFeetDiameter.MaxLength = 20
        Me.TxtKFeetDiameter.Name = "TxtKFeetDiameter"
        Me.TxtKFeetDiameter.Size = New System.Drawing.Size(178, 18)
        Me.TxtKFeetDiameter.TabIndex = 15
        '
        'LblKhapDiameterFeet
        '
        Me.LblKhapDiameterFeet.AutoSize = True
        Me.LblKhapDiameterFeet.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblKhapDiameterFeet.Location = New System.Drawing.Point(133, 235)
        Me.LblKhapDiameterFeet.Name = "LblKhapDiameterFeet"
        Me.LblKhapDiameterFeet.Size = New System.Drawing.Size(128, 16)
        Me.LblKhapDiameterFeet.TabIndex = 752
        Me.LblKhapDiameterFeet.Text = "Khap Perimeter Feet"
        '
        'FrmSize
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(857, 469)
        Me.Controls.Add(Me.TxtKFeetDiameter)
        Me.Controls.Add(Me.LblKhapDiameterFeet)
        Me.Controls.Add(Me.TxtFeetDiameter)
        Me.Controls.Add(Me.LblDiameterFeet)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.TxtSYardArea)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.TxtSYardWidth)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.TxtSYardLength)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.TxtSMeterArea)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.TxtSMeterWidth)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.TxtSMeterLength)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.TxtSFeetArea)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.TxtSFeetWidth)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.TxtSFeetLength)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.TxtStencilSizeDescription)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.TxtKhapSizeDescription)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TxtKYardArea)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TxtKYardWidth)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtKYardLength)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TxtKMeterArea)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtKMeterWidth)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtKMeterLength)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TxtKFeetArea)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtKFeetWidth)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtKFeetLength)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtYardArea)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtYardWidth)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtYardLength)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtMeterArea)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtMeterWidth)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtMeterLength)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtFeetArea)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtFeetWidth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtFeetLength)
        Me.Controls.Add(Me.LblFeetLength)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblShapeReq)
        Me.Controls.Add(Me.TxtShape)
        Me.Controls.Add(Me.LblShape)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Name = "FrmSize"
        Me.Text = "Quality Master"
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.LblDescription, 0)
        Me.Controls.SetChildIndex(Me.TxtDescription, 0)
        Me.Controls.SetChildIndex(Me.LblShape, 0)
        Me.Controls.SetChildIndex(Me.TxtShape, 0)
        Me.Controls.SetChildIndex(Me.LblShapeReq, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.LblFeetLength, 0)
        Me.Controls.SetChildIndex(Me.TxtFeetLength, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtFeetWidth, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtFeetArea, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtMeterLength, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtMeterWidth, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtMeterArea, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.TxtYardLength, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.TxtYardWidth, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.TxtYardArea, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.TxtKFeetLength, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.TxtKFeetWidth, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.TxtKFeetArea, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.TxtKMeterLength, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.TxtKMeterWidth, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.TxtKMeterArea, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.TxtKYardLength, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.TxtKYardWidth, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.TxtKYardArea, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.Label21, 0)
        Me.Controls.SetChildIndex(Me.Label22, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.Label26, 0)
        Me.Controls.SetChildIndex(Me.TxtKhapSizeDescription, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.Controls.SetChildIndex(Me.TxtStencilSizeDescription, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.Label40, 0)
        Me.Controls.SetChildIndex(Me.TxtSFeetLength, 0)
        Me.Controls.SetChildIndex(Me.Label39, 0)
        Me.Controls.SetChildIndex(Me.TxtSFeetWidth, 0)
        Me.Controls.SetChildIndex(Me.Label38, 0)
        Me.Controls.SetChildIndex(Me.TxtSFeetArea, 0)
        Me.Controls.SetChildIndex(Me.Label37, 0)
        Me.Controls.SetChildIndex(Me.TxtSMeterLength, 0)
        Me.Controls.SetChildIndex(Me.Label36, 0)
        Me.Controls.SetChildIndex(Me.TxtSMeterWidth, 0)
        Me.Controls.SetChildIndex(Me.Label35, 0)
        Me.Controls.SetChildIndex(Me.TxtSMeterArea, 0)
        Me.Controls.SetChildIndex(Me.Label34, 0)
        Me.Controls.SetChildIndex(Me.TxtSYardLength, 0)
        Me.Controls.SetChildIndex(Me.Label33, 0)
        Me.Controls.SetChildIndex(Me.TxtSYardWidth, 0)
        Me.Controls.SetChildIndex(Me.Label32, 0)
        Me.Controls.SetChildIndex(Me.TxtSYardArea, 0)
        Me.Controls.SetChildIndex(Me.Label31, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.Label29, 0)
        Me.Controls.SetChildIndex(Me.LblDiameterFeet, 0)
        Me.Controls.SetChildIndex(Me.TxtFeetDiameter, 0)
        Me.Controls.SetChildIndex(Me.LblKhapDiameterFeet, 0)
        Me.Controls.SetChildIndex(Me.TxtKFeetDiameter, 0)
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblShape As System.Windows.Forms.Label
    Friend WithEvents TxtShape As AgControls.AgTextBox
    Friend WithEvents LblShapeReq As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblFeetLength As System.Windows.Forms.Label
    Friend WithEvents TxtFeetWidth As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtFeetArea As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtMeterArea As AgControls.AgTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TxtMeterWidth As AgControls.AgTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtMeterLength As AgControls.AgTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtYardArea As AgControls.AgTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtYardWidth As AgControls.AgTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtYardLength As AgControls.AgTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtKFeetArea As AgControls.AgTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtKFeetWidth As AgControls.AgTextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtKFeetLength As AgControls.AgTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtKMeterArea As AgControls.AgTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtKMeterWidth As AgControls.AgTextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtKMeterLength As AgControls.AgTextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TxtKYardArea As AgControls.AgTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TxtKYardWidth As AgControls.AgTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TxtKYardLength As AgControls.AgTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents TxtKhapSizeDescription As AgControls.AgTextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents TxtStencilSizeDescription As AgControls.AgTextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents TxtSYardArea As AgControls.AgTextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TxtSYardWidth As AgControls.AgTextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents TxtSYardLength As AgControls.AgTextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TxtSMeterArea As AgControls.AgTextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TxtSMeterWidth As AgControls.AgTextBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents TxtSMeterLength As AgControls.AgTextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents TxtSFeetArea As AgControls.AgTextBox
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents TxtSFeetWidth As AgControls.AgTextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents TxtSFeetLength As AgControls.AgTextBox
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents TxtFeetDiameter As AgControls.AgTextBox
    Friend WithEvents LblDiameterFeet As System.Windows.Forms.Label
    Friend WithEvents TxtKFeetDiameter As AgControls.AgTextBox
    Friend WithEvents LblKhapDiameterFeet As System.Windows.Forms.Label
    Friend WithEvents TxtFeetLength As AgControls.AgTextBox


#End Region

    Private Sub FrmYarn_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        'If AgL.RequiredField(TxtShape, "Short Name") Then Exit Sub
        'If AgL.RequiredField(TxtDescription, "Description") Then Exit Sub

        If TxtDescription.Text.Trim = "" Then Err.Raise(1, , "Size Description Is Required!")

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Rug_Size Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Size Description Already Exist!")

            mQry = "Select count(*) From Rug_Size_Log Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & " And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Size Description Already Exists in Log File")
        Else
            mQry = "Select count(*) From Rug_Size Where Description='" & TxtDescription.Text & "' And Code<>'" & mInternalCode & "'  And " & ClsMain.RetDivFilterStr & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Size Description Already Exist!")

            mQry = "Select count(*) From Rug_Size_Log Where Description = '" & TxtDescription.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Size Description Already Exists in Log File")
        End If
    End Sub

    Private Sub FrmYarn_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        AgL.PubFindQry = "SELECT UID, Description [Size Description], " & _
                        " Shape, FeetLength, FeetWidth, FeetArea, MeterLength, MeterWidth, MeterArea, YardLength, YardWidth, YardArea, KFeetLength, KFeetWidth, KFeetArea, KMeterLength, KMeterWidth, KMeterArea, KYardLength, KYardWidth, KYardArea " & _
                        " FROM Rug_Size_Log " & mConStr & _
                        " And EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Size Description]"
    End Sub

    Private Sub FrmYarn_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        AgL.PubFindQry = "SELECT Code, Description [Size Description], " & _
                            " Shape, FeetLength, FeetWidth, FeetArea, MeterLength, MeterWidth, MeterArea, YardLength, YardWidth, YardArea, KFeetLength, KFeetWidth, KFeetArea, KMeterLength, KMeterWidth, KMeterArea, KYardLength, KYardWidth, KYardArea " & _
                            " FROM Rug_Size " & mConStr & _
                            " And IsNull(IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Size Description]"
    End Sub

    Private Sub FrmYarn_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Rug_Size"
        LogTableName = "Rug_Size_LOG"
    End Sub

    Private Sub FrmYarn_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "UPDATE dbo.Rug_Size_Log " & _
                " SET Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                " Shape = " & AgL.Chk_Text(TxtShape.Text) & ", " & _
                " FeetLength = " & Val(TxtFeetLength.Text) & ", " & _
                " FeetWidth = " & Val(TxtFeetWidth.Text) & ", " & _
                " FeetArea = " & Val(TxtFeetArea.Text) & ", " & _
                " FeetDiameter = " & Val(TxtFeetDiameter.Text) & ", " & _
                " MeterLength = " & Val(TxtMeterLength.Text) & ", " & _
                " MeterWidth = " & Val(TxtMeterWidth.Text) & ", " & _
                " MeterArea = " & Val(TxtMeterArea.Text) & ", " & _
                " YardLength = " & Val(TxtYardLength.Text) & ", " & _
                " YardWidth = " & Val(TxtYardWidth.Text) & ", " & _
                " YardArea = " & Val(TxtYardArea.Text) & ", " & _
                " KFeetLength = " & Val(TxtKFeetLength.Text) & ", " & _
                " KFeetWidth = " & Val(TxtKFeetWidth.Text) & ", " & _
                " KFeetArea = " & Val(TxtKFeetArea.Text) & ", " & _
                " KFeetDiameter = " & Val(TxtKFeetDiameter.Text) & ", " & _
                " KMeterLength = " & Val(TxtKMeterLength.Text) & ", " & _
                " KMeterWidth = " & Val(TxtKMeterWidth.Text) & ", " & _
                " KMeterArea = " & Val(TxtKMeterArea.Text) & ", " & _
                " KYardLength = " & Val(TxtKYardLength.Text) & ", " & _
                " KYardWidth = " & Val(TxtKYardWidth.Text) & ", " & _
                " KYardArea = " & Val(TxtKYardArea.Text) & "," & _
                " KhapSizeDescription = " & AgL.Chk_Text(TxtKhapSizeDescription.Text) & ", " & _
                " StencilSizeDescription = " & AgL.Chk_Text(TxtStencilSizeDescription.Text) & ", " & _
                " SFeetLength = " & Val(TxtSFeetLength.Text) & ", " & _
                " SFeetWidth = " & Val(TxtSFeetWidth.Text) & ", " & _
                " SFeetArea = " & Val(TxtSFeetArea.Text) & ", " & _
                " SMeterLength = " & Val(TxtSMeterLength.Text) & ", " & _
                " SMeterWidth = " & Val(TxtSMeterWidth.Text) & ", " & _
                " SMeterArea = " & Val(TxtSMeterArea.Text) & ", " & _
                " SYardLength = " & Val(TxtSYardLength.Text) & ", " & _
                " SYardWidth = " & Val(TxtSYardWidth.Text) & ", " & _
                " SYardArea = " & Val(TxtSYardArea.Text) & "" & _
                " Where UID = '" & SearchCode & "' "

        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub FrmQuality1_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtMeterLength.Enabled = False : TxtMeterWidth.Enabled = False : TxtMeterArea.Enabled = False
        TxtYardLength.Enabled = False : TxtYardWidth.Enabled = False : TxtYardArea.Enabled = False
        TxtKMeterLength.Enabled = False : TxtKMeterWidth.Enabled = False : TxtKMeterArea.Enabled = False
        TxtKYardLength.Enabled = False : TxtKYardWidth.Enabled = False : TxtKYardArea.Enabled = False
        TxtSMeterLength.Enabled = False : TxtSMeterWidth.Enabled = False : TxtSMeterArea.Enabled = False
        TxtSYardLength.Enabled = False : TxtSYardWidth.Enabled = False : TxtSYardArea.Enabled = False
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select Code, Description As Name , Div_Code From Rug_Size  " & _
            "  Order By Description"
        TxtDescription.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        'mQry = "Select Code, KhapSizeDescription As Name , Div_Code From Rug_Size  " & _
        '    "  Order By KhapSizeDescription"
        'TxtKhapSizeDescription.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        'mQry = "Select Code, StencilSizeDescription As Name , Div_Code From Rug_Size  " & _
        '    "  Order By StencilSizeDescription"
        'TxtStencilSizeDescription.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select  Distinct Shape as Code, Shape As [Shape], Div_Code " & _
                " From Rug_Size " & _
                " WHERE Shape Is Not Null " & _
                " Order By Shape"
        TxtShape.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select Code As SearchCode " & _
                " From Rug_Size " & mConStr & _
                " And IsNull(IsDeleted,0)=0 " & _
                " Order By Description "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select UID As SearchCode " & _
               " From Rug_Size_log " & mConStr & _
               " And EntryStatus='" & LogStatus.LogOpen & "' " & _
               " Order By Description"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * " & _
                " From Rug_Size Where Code='" & SearchCode & "'"
        Else
            mQry = "Select * " & _
                " From Rug_Size_Log Where UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                TxtShape.Text = AgL.XNull(.Rows(0)("Shape"))

                TxtFeetLength.Text = Format(AgL.VNull(.Rows(0)("FeetLength")), "0.00")
                TxtFeetWidth.Text = Format(AgL.VNull(.Rows(0)("FeetWidth")), "0.00")
                TxtFeetArea.Text = Format(AgL.VNull(.Rows(0)("FeetArea")), "0.00")
                TxtFeetDiameter.Text = Format(AgL.VNull(.Rows(0)("FeetDiameter")), "0.00")

                TxtMeterLength.Text = Format(AgL.VNull(.Rows(0)("MeterLength")), "0.00")
                TxtMeterWidth.Text = Format(AgL.VNull(.Rows(0)("MeterWidth")), "0.00")
                TxtMeterArea.Text = Format(AgL.VNull(.Rows(0)("MeterArea")), "0.00")

                TxtYardLength.Text = Format(AgL.VNull(.Rows(0)("YardLength")), "0.00")
                TxtYardWidth.Text = Format(AgL.VNull(.Rows(0)("YardWidth")), "0.00")
                TxtYardArea.Text = Format(AgL.VNull(.Rows(0)("YardArea")), "0.00")

                TxtKFeetLength.Text = Format(AgL.VNull(.Rows(0)("KFeetLength")), "0.00")
                TxtKFeetWidth.Text = Format(AgL.VNull(.Rows(0)("KFeetWidth")), "0.00")
                TxtKFeetArea.Text = Format(AgL.VNull(.Rows(0)("KFeetArea")), "0.00")
                TxtKFeetDiameter.Text = Format(AgL.VNull(.Rows(0)("KFeetDiameter")), "0.00")

                TxtKMeterLength.Text = Format(AgL.VNull(.Rows(0)("KMeterLength")), "0.00")
                TxtKMeterWidth.Text = Format(AgL.VNull(.Rows(0)("KMeterWidth")), "0.00")
                TxtKMeterArea.Text = Format(AgL.VNull(.Rows(0)("KMeterArea")), "0.00")

                TxtKYardLength.Text = Format(AgL.VNull(.Rows(0)("KYardLength")), "0.00")
                TxtKYardWidth.Text = Format(AgL.VNull(.Rows(0)("KYardWidth")), "0.00")
                TxtKYardArea.Text = Format(AgL.VNull(.Rows(0)("KYardArea")), "0.00")

                TxtKhapSizeDescription.Text = AgL.XNull(.Rows(0)("KhapSizeDescription"))
                TxtStencilSizeDescription.Text = AgL.XNull(.Rows(0)("StencilSizeDescription"))

                TxtSFeetLength.Text = Format(AgL.VNull(.Rows(0)("SFeetLength")), "0.00")
                TxtSFeetWidth.Text = Format(AgL.VNull(.Rows(0)("SFeetWidth")), "0.00")
                TxtSFeetArea.Text = Format(AgL.VNull(.Rows(0)("SFeetArea")), "0.00")

                TxtSMeterLength.Text = Format(AgL.VNull(.Rows(0)("SMeterLength")), "0.00")
                TxtSMeterWidth.Text = Format(AgL.VNull(.Rows(0)("SMeterWidth")), "0.00")
                TxtSMeterArea.Text = Format(AgL.VNull(.Rows(0)("SMeterArea")), "0.00")

                TxtSYardLength.Text = Format(AgL.VNull(.Rows(0)("SYardLength")), "0.00")
                TxtSYardWidth.Text = Format(AgL.VNull(.Rows(0)("SYardWidth")), "0.00")
                TxtSYardArea.Text = Format(AgL.VNull(.Rows(0)("SYardArea")), "0.00")
            End If
            Calculation()
        End With
        Topctrl1.tPrn = False
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtDescription.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        TxtDescription.Focus()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
    End Sub

    Private Sub FrmYarn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 503, 865, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtShape.Enter, TxtDescription.Enter, TxtFeetLength.Enter
        Try
            Select Case sender.name
                Case TxtShape.Name, TxtDescription.Name
                    sender.AgRowFilter = ClsMain.RetDivFilterStr
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtDescription.Validating, TxtShape.Validating, _
                                    TxtFeetLength.Validating, TxtFeetWidth.Validating, TxtFeetArea.Validating, _
                                    TxtMeterLength.Validating, TxtMeterWidth.Validating, TxtMeterArea.Validating, _
                                    TxtYardLength.Validating, TxtYardWidth.Validating, TxtYardArea.Validating, _
                                    TxtKFeetLength.Validating, TxtKFeetWidth.Validating, TxtKFeetArea.Validating, _
                                    TxtKMeterLength.Validating, TxtKMeterWidth.Validating, TxtKMeterArea.Validating, _
                                    TxtKYardLength.Validating, TxtKYardWidth.Validating, TxtKYardArea.Validating, _
                                    TxtKhapSizeDescription.Validating, TxtStencilSizeDescription.Validating, _
                                    TxtSFeetLength.Validating, TxtSFeetWidth.Validating, TxtSFeetArea.Validating, _
                                    TxtSMeterLength.Validating, TxtSMeterWidth.Validating, TxtSMeterArea.Validating, _
                                    TxtSYardLength.Validating, TxtSYardWidth.Validating, TxtSYardArea.Validating


        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                'Case TxtFeetLength.Name
                '    If Val(TxtKFeetLength.Text) = 0 Then TxtKFeetLength.Text = TxtFeetLength.Text

                'Case TxtMeterLength.Name
                '    If Val(TxtKMeterLength.Text) = 0 Then TxtKMeterLength.Text = TxtMeterLength.Text

                'Case TxtYardLength.Name
                '    If Val(TxtKYardLength.Text) = 0 Then TxtKYardLength.Text = TxtYardLength.Text

                'Case TxtFeetWidth.Name
                '    If Val(TxtKFeetWidth.Text) = 0 Then TxtKFeetWidth.Text = TxtFeetWidth.Text

                'Case TxtMeterWidth.Name
                '    If Val(TxtKMeterWidth.Text) = 0 Then TxtKMeterWidth.Text = TxtMeterWidth.Text

                'Case TxtYardWidth.Name
                '    If Val(TxtKYardWidth.Text) = 0 Then TxtKYardWidth.Text = TxtYardWidth.Text
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function GetYardFromInch(ByVal Value As Double) As Double
        GetYardFromInch = Format(Value * 0.0277777778, "0.00")
    End Function

    Private Function GetMeterFromInch(ByVal Value As Double) As Double
        GetMeterFromInch = Format(Value * 0.0254, "0.00")
    End Function

    Private Function GetFeetFromInch(ByVal Value As Double) As Double
        Dim mTemp As Double
        Value = Format(Value, "0.00")
        mTemp = Format(Value / 144, "0.00")

        GetFeetFromInch = mTemp
    End Function

    Private Function GetInchFromFeet(ByVal Value As Double) As Double
        Dim mTemp As Double
        GetInchFromFeet = AgL.Dman_Execute("Select Floor(" & Value & ")", AgL.GCn).ExecuteScalar
        mTemp = GetInchFromFeet
        GetInchFromFeet = Format(Value - GetInchFromFeet, "0.00")
        GetInchFromFeet = Format(GetInchFromFeet * 100, "0.00")
        GetInchFromFeet = Format(mTemp * 12 + GetInchFromFeet, "0.00")
    End Function


    Private Sub FrmQuality1_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim myInt As Double
        Dim myFrcation As Double
        TxtMeterLength.Text = Format(Val(TxtFeetLength.Text) * 0.3048, "0.00")  'Format(GetMeterFromInch(GetInchFromFeet(Val(TxtFeetLength.Text))), "0.00")
        TxtMeterWidth.Text = Format(Val(TxtFeetWidth.Text) * 0.3048, "0.00")    'Format(GetMeterFromInch(GetInchFromFeet(Val(TxtFeetWidth.Text))), "0.00")


        TxtYardLength.Text = Format(Val(TxtFeetLength.Text) * 0.333333333, "0.00")  'Format(GetYardFromInch(GetInchFromFeet(Val(TxtFeetLength.Text))), "0.00")
        TxtYardWidth.Text = Format(Val(TxtFeetWidth.Text) * 0.333333333, "0.00") 'Format(GetYardFromInch(GetInchFromFeet(Val(TxtFeetWidth.Text))), "0.00")

        'Code By Akash On Date 30-06-2011
        If Val(TxtKFeetLength.Text) = 0 Then TxtKFeetLength.Text = Format(IIf(Val(TxtFeetLength.Text) - 0.083 > 0, Val(TxtFeetLength.Text) - 0.083, 0), "0.00")
        If Val(TxtKFeetWidth.Text) = 0 Then TxtKFeetWidth.Text = Format(IIf(Val(TxtFeetWidth.Text) - 0.083 > 0, Val(TxtFeetWidth.Text) - 0.083, 0), "0.00")
        If Val(TxtSFeetLength.Text) = 0 Then TxtSFeetLength.Text = Format(Val(TxtFeetLength.Text) + 0.083, "0.00")
        If Val(TxtSFeetWidth.Text) = 0 Then TxtSFeetWidth.Text = Format(Val(TxtFeetWidth.Text) + 0.083, "0.00")

        ''End Code

        TxtKMeterLength.Text = Format(Val(TxtKFeetLength.Text) * 0.3048, "0.00") 'Format(GetMeterFromInch(GetInchFromFeet(Val(TxtKFeetLength.Text))), "0.00")
        TxtKMeterWidth.Text = Format(Val(TxtKFeetWidth.Text) * 0.3048, "0.00") 'Format(GetMeterFromInch(GetInchFromFeet(Val(TxtKFeetWidth.Text))), "0.00")

        TxtKYardLength.Text = Format(Val(TxtKFeetLength.Text) * 0.333333333, "0.00") 'Format(GetYardFromInch(GetInchFromFeet(Val(TxtKFeetLength.Text))), "0.00")
        TxtKYardWidth.Text = Format(Val(TxtFeetWidth.Text) * 0.333333333, "0.00") 'Format(GetYardFromInch(GetInchFromFeet(Val(TxtKFeetWidth.Text))), "0.00")

        'Code By Akash On Date 30-06-2011
        If Val(TxtSFeetLength.Text) = 0 Then TxtSFeetLength.Text = Format(Val(TxtFeetLength.Text), "0.00")
        If Val(TxtSFeetWidth.Text) = 0 Then TxtSFeetWidth.Text = Format(Val(TxtFeetWidth.Text), "0.00")

        TxtSMeterLength.Text = Format(Val(TxtSFeetLength.Text) * 0.3048, "0.00")   'Format(Val(TxtMeterLength.Text), "0.00")
        TxtSMeterWidth.Text = Format(Val(TxtSFeetWidth.Text) * 0.3048, "0.00") 'Format(Val(TxtMeterWidth.Text), "0.00")

        TxtSYardLength.Text = Format(Val(TxtSFeetLength.Text) * 0.333333333, "0.00")  'Format(Val(TxtYardLength.Text), "0.00")
        TxtSYardWidth.Text = Format(Val(TxtSFeetWidth.Text) * 0.333333333, "0.00") 'Format(Val(TxtYardWidth.Text), "0.00")
        'End Code

        TxtFeetArea.Text = Format(Val(TxtFeetLength.Text) * Val(TxtFeetWidth.Text), "0.00")
        TxtMeterArea.Text = Math.Round(Val(TxtFeetArea.Text) * 0.09290304, 2) 'Format(Val(TxtMeterLength.Text) * Val(TxtMeterWidth.Text), "0.00")
        TxtYardArea.Text = Math.Round(Val(TxtFeetArea.Text) * 0.111111111, 2) 'Format(Val(TxtYardLength.Text) * Val(TxtYardWidth.Text), "0.00")

        TxtKFeetArea.Text = Format(Val(TxtKFeetLength.Text) * Val(TxtKFeetWidth.Text), "0.00")
        TxtKMeterArea.Text = Math.Round(Val(TxtKFeetArea.Text) * 0.09290304, 2) 'Format(Val(TxtKMeterLength.Text) * Val(TxtKMeterWidth.Text), "0.00")
        TxtKYardArea.Text = Math.Round(Val(TxtKFeetArea.Text) * 0.111111111, 2)
        'Conversion of Gaz & Girah
        myInt = Int(Val(TxtKYardArea.Text))
        myFrcation = Val(TxtKYardArea.Text) - Int(Val(TxtKYardArea.Text))
        myFrcation = myFrcation * 16
        myFrcation = Int(myFrcation)
        myFrcation = myFrcation / 16
        TxtKYardArea.Text = myInt + myFrcation

        TxtSFeetArea.Text = Format(Val(TxtSFeetLength.Text) * Val(TxtSFeetWidth.Text), "0.00")
        TxtSMeterArea.Text = Math.Round(Val(TxtSFeetArea.Text) * 0.09290304, 2) 'Format(Val(TxtSMeterLength.Text) * Val(TxtSMeterWidth.Text), "0.00")
        TxtSYardArea.Text = Math.Round(Val(TxtSFeetArea.Text) * 0.111111111, 2)

        TxtFeetDiameter.Text = Format(2 * Val(TxtFeetLength.Text) + 2 * Val(TxtFeetWidth.Text), "0.00")
        TxtKFeetDiameter.Text = Format(2 * Val(TxtKFeetLength.Text) + 2 * Val(TxtKFeetWidth.Text), "0.00")

    End Sub
End Class
