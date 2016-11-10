Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports RUG_Main.ClsMain.LogStatus
Imports System.IO
Public Class FrmDesign
    Inherits AgTemplate.TempMaster

    Dim mQry$
    Friend WithEvents LinkLabel5 As System.Windows.Forms.LinkLabel
    Friend WithEvents LinkLabel6 As System.Windows.Forms.LinkLabel
    Dim Photo_Byte As Byte()

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtCarpetColour = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtQualityCode = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtCarpetCollection = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtCarpetStyle = New AgControls.AgTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtConstruction = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtPileWeight = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblBank_NameReq = New System.Windows.Forms.Label
        Me.TxtManualCode = New AgControls.AgTextBox
        Me.LblShortName = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.PicPhoto = New System.Windows.Forms.PictureBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.TxtDesignConsumption = New AgControls.AgTextBox
        Me.LblDesignConsumption = New System.Windows.Forms.Label
        Me.LinkLabel5 = New System.Windows.Forms.LinkLabel
        Me.LinkLabel6 = New System.Windows.Forms.LinkLabel
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicPhoto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(887, 41)
        Me.Topctrl1.TabIndex = 20
        Me.Topctrl1.tAdd = False
        Me.Topctrl1.tDel = False
        Me.Topctrl1.tEdit = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 475)
        Me.GroupBox1.Size = New System.Drawing.Size(929, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(14, 479)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(143, 479)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(553, 479)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(399, 479)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Tag = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(703, 479)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(275, 479)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(285, 168)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(10, 7)
        Me.Label10.TabIndex = 694
        Me.Label10.Text = "Ä"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(564, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 7)
        Me.Label9.TabIndex = 693
        Me.Label9.Text = "Ä"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(564, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 7)
        Me.Label8.TabIndex = 692
        Me.Label8.Text = "Ä"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(285, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 691
        Me.Label4.Text = "Ä"
        '
        'TxtCarpetColour
        '
        Me.TxtCarpetColour.AgMandatory = True
        Me.TxtCarpetColour.AgMasterHelp = True
        Me.TxtCarpetColour.AgNumberLeftPlaces = 8
        Me.TxtCarpetColour.AgNumberNegetiveAllow = False
        Me.TxtCarpetColour.AgNumberRightPlaces = 2
        Me.TxtCarpetColour.AgPickFromLastValue = False
        Me.TxtCarpetColour.AgRowFilter = ""
        Me.TxtCarpetColour.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCarpetColour.AgSelectedValue = Nothing
        Me.TxtCarpetColour.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCarpetColour.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCarpetColour.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCarpetColour.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCarpetColour.Location = New System.Drawing.Point(300, 161)
        Me.TxtCarpetColour.MaxLength = 20
        Me.TxtCarpetColour.Multiline = True
        Me.TxtCarpetColour.Name = "TxtCarpetColour"
        Me.TxtCarpetColour.Size = New System.Drawing.Size(129, 20)
        Me.TxtCarpetColour.TabIndex = 681
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(160, 165)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(87, 16)
        Me.Label7.TabIndex = 690
        Me.Label7.Text = "Carpet Colour"
        '
        'TxtQualityCode
        '
        Me.TxtQualityCode.AgMandatory = True
        Me.TxtQualityCode.AgMasterHelp = False
        Me.TxtQualityCode.AgNumberLeftPlaces = 8
        Me.TxtQualityCode.AgNumberNegetiveAllow = False
        Me.TxtQualityCode.AgNumberRightPlaces = 3
        Me.TxtQualityCode.AgPickFromLastValue = False
        Me.TxtQualityCode.AgRowFilter = ""
        Me.TxtQualityCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtQualityCode.AgSelectedValue = Nothing
        Me.TxtQualityCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtQualityCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtQualityCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtQualityCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQualityCode.Location = New System.Drawing.Point(582, 161)
        Me.TxtQualityCode.MaxLength = 20
        Me.TxtQualityCode.Multiline = True
        Me.TxtQualityCode.Name = "TxtQualityCode"
        Me.TxtQualityCode.Size = New System.Drawing.Size(134, 20)
        Me.TxtQualityCode.TabIndex = 683
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(435, 165)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(83, 16)
        Me.Label12.TabIndex = 689
        Me.Label12.Text = "Quality Code"
        '
        'TxtCarpetCollection
        '
        Me.TxtCarpetCollection.AgMandatory = True
        Me.TxtCarpetCollection.AgMasterHelp = True
        Me.TxtCarpetCollection.AgNumberLeftPlaces = 8
        Me.TxtCarpetCollection.AgNumberNegetiveAllow = False
        Me.TxtCarpetCollection.AgNumberRightPlaces = 2
        Me.TxtCarpetCollection.AgPickFromLastValue = False
        Me.TxtCarpetCollection.AgRowFilter = ""
        Me.TxtCarpetCollection.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCarpetCollection.AgSelectedValue = Nothing
        Me.TxtCarpetCollection.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCarpetCollection.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCarpetCollection.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCarpetCollection.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCarpetCollection.Location = New System.Drawing.Point(300, 139)
        Me.TxtCarpetCollection.MaxLength = 20
        Me.TxtCarpetCollection.Multiline = True
        Me.TxtCarpetCollection.Name = "TxtCarpetCollection"
        Me.TxtCarpetCollection.Size = New System.Drawing.Size(129, 20)
        Me.TxtCarpetCollection.TabIndex = 678
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(160, 143)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(107, 16)
        Me.Label5.TabIndex = 688
        Me.Label5.Text = "Carpet Collection"
        '
        'TxtCarpetStyle
        '
        Me.TxtCarpetStyle.AgMandatory = True
        Me.TxtCarpetStyle.AgMasterHelp = True
        Me.TxtCarpetStyle.AgNumberLeftPlaces = 8
        Me.TxtCarpetStyle.AgNumberNegetiveAllow = False
        Me.TxtCarpetStyle.AgNumberRightPlaces = 3
        Me.TxtCarpetStyle.AgPickFromLastValue = False
        Me.TxtCarpetStyle.AgRowFilter = ""
        Me.TxtCarpetStyle.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCarpetStyle.AgSelectedValue = Nothing
        Me.TxtCarpetStyle.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCarpetStyle.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCarpetStyle.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCarpetStyle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCarpetStyle.Location = New System.Drawing.Point(582, 139)
        Me.TxtCarpetStyle.MaxLength = 20
        Me.TxtCarpetStyle.Multiline = True
        Me.TxtCarpetStyle.Name = "TxtCarpetStyle"
        Me.TxtCarpetStyle.Size = New System.Drawing.Size(134, 20)
        Me.TxtCarpetStyle.TabIndex = 680
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(435, 143)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 16)
        Me.Label6.TabIndex = 687
        Me.Label6.Text = "Carpet Style"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(564, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 686
        Me.Label2.Text = "Ä"
        '
        'TxtConstruction
        '
        Me.TxtConstruction.AgMandatory = True
        Me.TxtConstruction.AgMasterHelp = False
        Me.TxtConstruction.AgNumberLeftPlaces = 0
        Me.TxtConstruction.AgNumberNegetiveAllow = False
        Me.TxtConstruction.AgNumberRightPlaces = 0
        Me.TxtConstruction.AgPickFromLastValue = False
        Me.TxtConstruction.AgRowFilter = ""
        Me.TxtConstruction.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtConstruction.AgSelectedValue = Nothing
        Me.TxtConstruction.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtConstruction.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtConstruction.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtConstruction.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtConstruction.Location = New System.Drawing.Point(580, 95)
        Me.TxtConstruction.MaxLength = 0
        Me.TxtConstruction.Multiline = True
        Me.TxtConstruction.Name = "TxtConstruction"
        Me.TxtConstruction.Size = New System.Drawing.Size(136, 20)
        Me.TxtConstruction.TabIndex = 675
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(435, 98)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 685
        Me.Label3.Text = "Construction"
        '
        'TxtPileWeight
        '
        Me.TxtPileWeight.AgMandatory = False
        Me.TxtPileWeight.AgMasterHelp = True
        Me.TxtPileWeight.AgNumberLeftPlaces = 8
        Me.TxtPileWeight.AgNumberNegetiveAllow = False
        Me.TxtPileWeight.AgNumberRightPlaces = 3
        Me.TxtPileWeight.AgPickFromLastValue = False
        Me.TxtPileWeight.AgRowFilter = ""
        Me.TxtPileWeight.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPileWeight.AgSelectedValue = Nothing
        Me.TxtPileWeight.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPileWeight.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtPileWeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPileWeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPileWeight.Location = New System.Drawing.Point(300, 183)
        Me.TxtPileWeight.MaxLength = 0
        Me.TxtPileWeight.Multiline = True
        Me.TxtPileWeight.Name = "TxtPileWeight"
        Me.TxtPileWeight.Size = New System.Drawing.Size(129, 20)
        Me.TxtPileWeight.TabIndex = 684
        Me.TxtPileWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(285, 125)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 679
        Me.Label1.Text = "Ä"
        '
        'LblBank_NameReq
        '
        Me.LblBank_NameReq.AutoSize = True
        Me.LblBank_NameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBank_NameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBank_NameReq.Location = New System.Drawing.Point(285, 105)
        Me.LblBank_NameReq.Name = "LblBank_NameReq"
        Me.LblBank_NameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBank_NameReq.TabIndex = 676
        Me.LblBank_NameReq.Text = "Ä"
        '
        'TxtManualCode
        '
        Me.TxtManualCode.AgMandatory = True
        Me.TxtManualCode.AgMasterHelp = True
        Me.TxtManualCode.AgNumberLeftPlaces = 0
        Me.TxtManualCode.AgNumberNegetiveAllow = False
        Me.TxtManualCode.AgNumberRightPlaces = 0
        Me.TxtManualCode.AgPickFromLastValue = False
        Me.TxtManualCode.AgRowFilter = ""
        Me.TxtManualCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtManualCode.AgSelectedValue = Nothing
        Me.TxtManualCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtManualCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtManualCode.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtManualCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManualCode.Location = New System.Drawing.Point(300, 95)
        Me.TxtManualCode.MaxLength = 20
        Me.TxtManualCode.Multiline = True
        Me.TxtManualCode.Name = "TxtManualCode"
        Me.TxtManualCode.Size = New System.Drawing.Size(129, 20)
        Me.TxtManualCode.TabIndex = 673
        '
        'LblShortName
        '
        Me.LblShortName.AutoSize = True
        Me.LblShortName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShortName.Location = New System.Drawing.Point(160, 98)
        Me.LblShortName.Name = "LblShortName"
        Me.LblShortName.Size = New System.Drawing.Size(82, 16)
        Me.LblShortName.TabIndex = 672
        Me.LblShortName.Text = "Design Code"
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
        Me.TxtDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDescription.Location = New System.Drawing.Point(300, 117)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Multiline = True
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(416, 20)
        Me.TxtDescription.TabIndex = 677
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(160, 120)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(117, 16)
        Me.LblDescription.TabIndex = 674
        Me.LblDescription.Text = "Design Description"
        '
        'PicPhoto
        '
        Me.PicPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PicPhoto.Location = New System.Drawing.Point(163, 258)
        Me.PicPhoto.Name = "PicPhoto"
        Me.PicPhoto.Size = New System.Drawing.Size(553, 211)
        Me.PicPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicPhoto.TabIndex = 695
        Me.PicPhoto.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(160, 187)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(107, 16)
        Me.Label13.TabIndex = 698
        Me.Label13.Text = "Pile Weight (Kg.)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(564, 191)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 7)
        Me.Label11.TabIndex = 701
        Me.Label11.Text = "Ä"
        Me.Label11.Visible = False
        '
        'TxtDesignConsumption
        '
        Me.TxtDesignConsumption.AgMandatory = False
        Me.TxtDesignConsumption.AgMasterHelp = False
        Me.TxtDesignConsumption.AgNumberLeftPlaces = 0
        Me.TxtDesignConsumption.AgNumberNegetiveAllow = False
        Me.TxtDesignConsumption.AgNumberRightPlaces = 0
        Me.TxtDesignConsumption.AgPickFromLastValue = False
        Me.TxtDesignConsumption.AgRowFilter = ""
        Me.TxtDesignConsumption.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDesignConsumption.AgSelectedValue = Nothing
        Me.TxtDesignConsumption.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDesignConsumption.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDesignConsumption.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDesignConsumption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDesignConsumption.Location = New System.Drawing.Point(582, 183)
        Me.TxtDesignConsumption.MaxLength = 0
        Me.TxtDesignConsumption.Multiline = True
        Me.TxtDesignConsumption.Name = "TxtDesignConsumption"
        Me.TxtDesignConsumption.Size = New System.Drawing.Size(134, 20)
        Me.TxtDesignConsumption.TabIndex = 699
        Me.TxtDesignConsumption.Visible = False
        '
        'LblDesignConsumption
        '
        Me.LblDesignConsumption.AutoSize = True
        Me.LblDesignConsumption.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDesignConsumption.Location = New System.Drawing.Point(435, 186)
        Me.LblDesignConsumption.Name = "LblDesignConsumption"
        Me.LblDesignConsumption.Size = New System.Drawing.Size(128, 16)
        Me.LblDesignConsumption.TabIndex = 700
        Me.LblDesignConsumption.Text = "Design Consumption"
        Me.LblDesignConsumption.Visible = False
        '
        'LinkLabel5
        '
        Me.LinkLabel5.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LinkLabel5.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel5.LinkColor = System.Drawing.Color.White
        Me.LinkLabel5.Location = New System.Drawing.Point(162, 229)
        Me.LinkLabel5.Name = "LinkLabel5"
        Me.LinkLabel5.Size = New System.Drawing.Size(105, 23)
        Me.LinkLabel5.TabIndex = 702
        Me.LinkLabel5.TabStop = True
        Me.LinkLabel5.Text = "Design Image"
        Me.LinkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LinkLabel6
        '
        Me.LinkLabel6.BackColor = System.Drawing.Color.White
        Me.LinkLabel6.Enabled = False
        Me.LinkLabel6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel6.LinkColor = System.Drawing.Color.White
        Me.LinkLabel6.Location = New System.Drawing.Point(166, 233)
        Me.LinkLabel6.Name = "LinkLabel6"
        Me.LinkLabel6.Size = New System.Drawing.Size(105, 23)
        Me.LinkLabel6.TabIndex = 703
        Me.LinkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmDesign
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(887, 523)
        Me.Controls.Add(Me.LinkLabel5)
        Me.Controls.Add(Me.LinkLabel6)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TxtDesignConsumption)
        Me.Controls.Add(Me.LblDesignConsumption)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.PicPhoto)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtCarpetColour)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtQualityCode)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtCarpetCollection)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtCarpetStyle)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtConstruction)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtPileWeight)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblBank_NameReq)
        Me.Controls.Add(Me.TxtManualCode)
        Me.Controls.Add(Me.LblShortName)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Name = "FrmDesign"
        Me.Text = "Design Master"
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
        Me.Controls.SetChildIndex(Me.LblShortName, 0)
        Me.Controls.SetChildIndex(Me.TxtManualCode, 0)
        Me.Controls.SetChildIndex(Me.LblBank_NameReq, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtPileWeight, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtConstruction, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtCarpetStyle, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtCarpetCollection, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.TxtQualityCode, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.TxtCarpetColour, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.PicPhoto, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.LblDesignConsumption, 0)
        Me.Controls.SetChildIndex(Me.TxtDesignConsumption, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel6, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel5, 0)
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
        CType(Me.PicPhoto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents PicPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblShortName As System.Windows.Forms.Label
    Friend WithEvents TxtManualCode As AgControls.AgTextBox
    Friend WithEvents LblBank_NameReq As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtPileWeight As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtConstruction As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtCarpetStyle As AgControls.AgTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtCarpetCollection As AgControls.AgTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtQualityCode As AgControls.AgTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtCarpetColour As AgControls.AgTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TxtDesignConsumption As AgControls.AgTextBox
    Friend WithEvents LblDesignConsumption As System.Windows.Forms.Label
#End Region

    Private Sub FrmYarn_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        'If AgL.RequiredField(TxtManualCode, "Short Name") Then Exit Sub
        'If AgL.RequiredField(TxtDescription, "Description") Then Exit Sub

        If TxtManualCode.Text.Trim = "" Then Err.Raise(1, , "Short Name Is Required!")
        If TxtDescription.Text.Trim = "" Then Err.Raise(1, , "Description Is Required!")

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Rug_Design Where ManualCode='" & TxtManualCode.Text & "'  And " & ClsMain.RetDivFilterStr & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Design Code Already Exist!")

            mQry = "Select count(*) From Rug_Design Where Description='" & TxtDescription.Text & "'  And " & ClsMain.RetDivFilterStr & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Design  Description Already Exist!")

            mQry = "Select count(*) From Rug_Design_Log Where ManualCode='" & TxtManualCode.Text & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Design Code Already Exists in Log File")

            mQry = "Select count(*) From Rug_Design_Log Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Design Description Already Exists in Log File")
        Else
            mQry = "Select count(*) From Rug_Design Where ManualCode='" & TxtManualCode.Text & "' And Code<>'" & mInternalCode & "' And " & ClsMain.RetDivFilterStr & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Design Code Already Exist!")

            mQry = "Select count(*) From Rug_Design Where Description='" & TxtDescription.Text & "' And Code<>'" & mInternalCode & "'  And " & ClsMain.RetDivFilterStr & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Design  Description Already Exist!")

            mQry = "Select count(*) From Rug_Design_Log Where ManualCode = '" & TxtManualCode.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Design Code Already Exists in Log File")

            mQry = "Select count(*) From Rug_Design_Log Where Description = '" & TxtDescription.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Design Description Already Exists in Log File")
        End If
    End Sub

    Private Sub FrmYarn_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        AgL.PubFindQry = "SELECT UID, ManualCode as DesignShortName, Description [Design Description], " & _
                        " Construction, Carpet_Collection, Carpet_Style, Carpet_Colour " & _
                        " FROM Rug_Design_Log " & mConStr & _
                        " And EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Design Description]"
    End Sub

    Private Sub FrmYarn_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        AgL.PubFindQry = "SELECT Code, ManualCode as DesignShortName, Description [Design Description], " & _
                            " Construction, Carpet_Collection, Carpet_Style, Carpet_Colour " & _
                            " FROM Rug_Design " & mConStr & _
                            " And IsNull(IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Design Description]"
    End Sub

    Private Sub FrmYarn_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "RUG_Design"
        LogTableName = "RUG_Design_Log"
        MainLineTableCsv = "RUG_DesignDetail,RUG_DesignImage"
        LogLineTableCsv = "RUG_DesignDetail_LOG,RUG_DesignImage_Log"
    End Sub

    Private Sub FrmYarn_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = " UPDATE RUG_Design_Log " & _
                " SET ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
                " Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
                " Construction = " & AgL.Chk_Text(TxtConstruction.Text) & ", " & _
                " Carpet_Collection = " & AgL.Chk_Text(TxtCarpetCollection.Text) & ", " & _
                " Carpet_Style = " & AgL.Chk_Text(TxtCarpetStyle.Text) & ", " & _
                " Carpet_Colour = " & AgL.Chk_Text(TxtCarpetColour.Text) & ", " & _
                " QualityCode = " & AgL.Chk_Text(TxtQualityCode.AgSelectedValue) & ", " & _
                " PileWeight = " & Val(TxtPileWeight.Text) & ", " & _
                " Bom = " & AgL.Chk_Text(TxtDesignConsumption.AgSelectedValue) & " " & _
                " Where UID = '" & SearchCode & "' "

        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = "Delete From Rug_DesignImage_Log Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = "Insert Into Rug_DesignImage_Log(UID, Code, Photo) Values('" & mSearchCode & "', '" & mInternalCode & "', Null)"
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub FrmDesign_BaseEvent_Save_PostTrans(ByVal SearchCode As String) Handles Me.BaseEvent_Save_PostTrans
        Call Update_Picture("RUG_DesignImage_Log", "Photo", "Where UID = '" & mSearchCode & "'", Photo_Byte)
    End Sub

    Private Sub FrmQuality1_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        PicPhoto.Image = Nothing
        Photo_Byte = Nothing
    End Sub

    Private Sub FrmQuality1_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation

    End Sub

    Private Sub FrmQuality1_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtPileWeight.Enabled = False
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select  Code, ManualCode As [Quality Code], Div_Code " & _
             " From Rug_Design " & _
             " Order By ManualCode"
        TxtManualCode.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code, Description As Name, Div_Code " & _
            " From Rug_Design " & _
            " Order By Description"
        TxtDescription.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT D.Carpet_Collection  AS Code," & _
                " D.Carpet_Collection, Div_Code  " & _
                " FROM RUG_Design D " & _
                " ORDER BY D.Carpet_Collection "
        TxtCarpetCollection.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT D.Carpet_Style  AS Code,D.Carpet_Style, Div_Code  " & _
                " FROM RUG_Design D ORDER BY D.Carpet_Style "
        TxtCarpetStyle.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT D.Carpet_Colour AS Code," & _
                " D.Carpet_Colour , Div_Code   FROM RUG_Design D ORDER BY D.Carpet_Colour "
        TxtCarpetColour.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Q.Code ,Q.ManualCode AS [Quality Code],Q.Description AS [Quality Description], " & _
                " Q.Construction, Q.StdRugWeight, Q.PileWeight, Q.Div_Code, Q.Status, IsNull(Q.IsDeleted,0) as IsDeleted  " & _
                " FROM RUG_Quality Q ORDER BY Q.ManualCode "
        TxtQualityCode.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code, Code as Name, IsNull(IsDeleted,0) as IsDeleted From Rug_Construction Order By Code "
        TxtConstruction.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT B.Code ,B.Description AS [Bom Description], " & _
                " B.Div_Code, B.IsDeleted, B.Status  " & _
                " FROM Bom B ORDER BY B.Description "
        TxtDesignConsumption.AgHelpDataSet(2) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select Code As SearchCode " & _
                " From RUG_Design " & mConStr & _
                " And IsNull(IsDeleted,0)=0 " & _
                " Order By Description "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select UID As SearchCode " & _
               " From RUG_Design_Log " & mConStr & _
               " And EntryStatus='" & LogStatus.LogOpen & "' " & _
               " Order By Description"
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet
        Dim DrTemp As DataRow() = Nothing

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * " & _
                " From RUG_Design Where Code='" & SearchCode & "'"
        Else
            mQry = "Select * " & _
                " From RUG_Design_Log Where UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtManualCode.Text = AgL.XNull(.Rows(0)("ManualCode"))
                TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                TxtConstruction.AgSelectedValue = AgL.XNull(.Rows(0)("Construction"))
                TxtQualityCode.AgSelectedValue = AgL.XNull(.Rows(0)("QualityCode"))
                TxtPileWeight.Text = Format(AgL.VNull(.Rows(0)("PileWeight")), "0.000")
                TxtCarpetStyle.Text = AgL.XNull(.Rows(0)("Carpet_Style"))
                TxtCarpetCollection.Text = AgL.XNull(.Rows(0)("Carpet_Collection"))
                TxtCarpetColour.Text = AgL.XNull(.Rows(0)("Carpet_Colour"))
                TxtDesignConsumption.AgSelectedValue = AgL.XNull(.Rows(0)("Bom"))


                '-------------------------------------------------------------
                'Image Show
                '-------------------------------------------------------------

                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select Im.* " & _
                            " From Rug_DesignImage Im Where Code='" & mSearchCode & "'"
                Else
                    mQry = "Select Im.* " & _
                            " From Rug_DesignImage_Log Im Where UID='" & mSearchCode & "'"
                End If
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    If .Rows.Count > 0 Then
                        If Not IsDBNull(.Rows(0)("Photo")) Then
                            Photo_Byte = DirectCast(.Rows(0)("Photo"), Byte())
                            Show_Picture(PicPhoto, Photo_Byte)
                        End If
                    End If
                End With
                '-------------------------------------------------------------
                '-------------------------------------------------------------
            End If
        End With
        Topctrl1.tPrn = False
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        TxtManualCode.Focus()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
    End Sub

    Private Sub FrmYarn_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 600, 920, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub PictureBox_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PicPhoto.DoubleClick
        If Topctrl1.Mode = "Browse" Then Exit Sub

        Select Case sender.Name
            Case PicPhoto.Name
                AgL.GetPicture(sender, Photo_Byte)
        End Select
    End Sub

    Sub Show_Picture(ByVal PicBox As PictureBox, ByVal B As Byte())
        Dim Mem As MemoryStream
        Dim Img As Image

        Mem = New MemoryStream(B)
        Img = Image.FromStream(Mem)
        PicBox.Image = Img
    End Sub

    Sub Update_Picture(ByVal mTable As String, ByVal mColumn As String, ByVal mCondition As String, ByVal ByteArr As Byte())
        If ByteArr Is Nothing Then Exit Sub
        Dim sSQL As String = "Update " & mTable & " Set " & mColumn & "=@pic " & mCondition

        Dim cmd As SqlCommand = New SqlCommand(sSQL, AgL.GCn)
        Dim Pic As SqlParameter = New SqlParameter("@pic", SqlDbType.Image)
        Pic.Value = ByteArr
        cmd.Parameters.Add(Pic)
        cmd.ExecuteNonQuery()
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtManualCode.Enter, TxtDescription.Enter, TxtQualityCode.Enter, TxtConstruction.Enter, TxtCarpetCollection.Enter, TxtCarpetStyle.Enter, TxtCarpetColour.Enter, TxtPileWeight.Enter, TxtDesignConsumption.Enter
        Try
            Select Case sender.name
                Case TxtManualCode.Name, TxtDescription.Name, TxtCarpetCollection.Name, TxtQualityCode.Name, TxtCarpetStyle.Name, TxtCarpetColour.Name, TxtQualityCode.Name
                    sender.AgRowFilter = ClsMain.RetDivFilterStr

                Case TxtQualityCode.Name
                    sender.AgRowFilter = "Status='" & AgTemplate.ClsMain.EntryStatus.Active & "'    And  IsDeleted = 0 And " & ClsMain.RetDivFilterStr & ""
                Case TxtConstruction.Name
                    sender.AgRowFilter = "IsDeleted = 0 "
                Case TxtDesignConsumption.Name
                    sender.AgRowFilter = "Status='" & AgTemplate.ClsMain.EntryStatus.Active & "'    And  IsDeleted = 0 And " & ClsMain.RetDivFilterStr & ""

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TxtQualityCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtQualityCode.Validating, TxtConstruction.Validating, TxtCarpetCollection.Validating, TxtCarpetStyle.Validating, TxtCarpetColour.Validating, TxtPileWeight.Validating
        Dim DrTemp As DataRow()
        Select Case sender.name
            Case TxtQualityCode.Name
                If sender.text.ToString.Trim <> "" Then
                    If sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                        TxtPileWeight.Text = AgL.VNull(DrTemp(0)("PileWeight"))
                    End If
                End If
        End Select
    End Sub
End Class
