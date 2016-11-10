Public Class FrmQuality1
    Inherits AgTemplate.TempMaster

    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Private Const ColSNo As Byte = 0
    Private Const Col1OtherMaterial As Byte = 1
    Private Const Col1QtyPerSqrYard As Byte = 2
    Private Const Col1Unit As Byte = 3


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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtFringes = New AgControls.AgTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtClipping = New AgControls.AgTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtWashingType = New AgControls.AgTextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtTuftPerSqrInch = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtPileHeight = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtPileWeight = New AgControls.AgTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtConstruction = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtStdRugWeight = New AgControls.AgTextBox
        Me.LblRate = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblBank_NameReq = New System.Windows.Forms.Label
        Me.TxtManualCode = New AgControls.AgTextBox
        Me.LblShortName = New System.Windows.Forms.Label
        Me.TxtDescription = New AgControls.AgTextBox
        Me.LblDescription = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(862, 41)
        Me.Topctrl1.TabIndex = 11
        Me.Topctrl1.tAdd = False
        Me.Topctrl1.tDel = False
        Me.Topctrl1.tEdit = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New System.Drawing.Size(904, 4)
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
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Tag = ""
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Tag = ""
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Tag = ""
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(126, 364)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(613, 23)
        Me.Panel1.TabIndex = 685
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalQty.Location = New System.Drawing.Point(488, 3)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 660
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label11.Location = New System.Drawing.Point(409, 3)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(73, 16)
        Me.Label11.TabIndex = 659
        Me.Label11.Text = "Total Qty :"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(126, 235)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(613, 128)
        Me.Pnl1.TabIndex = 10
        '
        'TxtFringes
        '
        Me.TxtFringes.AgMandatory = False
        Me.TxtFringes.AgMasterHelp = False
        Me.TxtFringes.AgNumberLeftPlaces = 0
        Me.TxtFringes.AgNumberNegetiveAllow = False
        Me.TxtFringes.AgNumberRightPlaces = 0
        Me.TxtFringes.AgPickFromLastValue = False
        Me.TxtFringes.AgRowFilter = ""
        Me.TxtFringes.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFringes.AgSelectedValue = Nothing
        Me.TxtFringes.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFringes.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFringes.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFringes.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFringes.Location = New System.Drawing.Point(605, 171)
        Me.TxtFringes.MaxLength = 15
        Me.TxtFringes.Multiline = True
        Me.TxtFringes.Name = "TxtFringes"
        Me.TxtFringes.Size = New System.Drawing.Size(134, 20)
        Me.TxtFringes.TabIndex = 8
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(484, 172)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(51, 16)
        Me.Label10.TabIndex = 683
        Me.Label10.Text = "Fringes"
        '
        'TxtClipping
        '
        Me.TxtClipping.AgMandatory = False
        Me.TxtClipping.AgMasterHelp = False
        Me.TxtClipping.AgNumberLeftPlaces = 0
        Me.TxtClipping.AgNumberNegetiveAllow = False
        Me.TxtClipping.AgNumberRightPlaces = 0
        Me.TxtClipping.AgPickFromLastValue = False
        Me.TxtClipping.AgRowFilter = ""
        Me.TxtClipping.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClipping.AgSelectedValue = Nothing
        Me.TxtClipping.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClipping.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClipping.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtClipping.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClipping.Location = New System.Drawing.Point(342, 193)
        Me.TxtClipping.MaxLength = 30
        Me.TxtClipping.Multiline = True
        Me.TxtClipping.Name = "TxtClipping"
        Me.TxtClipping.Size = New System.Drawing.Size(397, 20)
        Me.TxtClipping.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(123, 193)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 16)
        Me.Label9.TabIndex = 682
        Me.Label9.Text = "Clipping"
        '
        'TxtWashingType
        '
        Me.TxtWashingType.AgMandatory = False
        Me.TxtWashingType.AgMasterHelp = False
        Me.TxtWashingType.AgNumberLeftPlaces = 0
        Me.TxtWashingType.AgNumberNegetiveAllow = False
        Me.TxtWashingType.AgNumberRightPlaces = 0
        Me.TxtWashingType.AgPickFromLastValue = False
        Me.TxtWashingType.AgRowFilter = ""
        Me.TxtWashingType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtWashingType.AgSelectedValue = Nothing
        Me.TxtWashingType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtWashingType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtWashingType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtWashingType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWashingType.Location = New System.Drawing.Point(342, 171)
        Me.TxtWashingType.MaxLength = 30
        Me.TxtWashingType.Multiline = True
        Me.TxtWashingType.Name = "TxtWashingType"
        Me.TxtWashingType.Size = New System.Drawing.Size(129, 20)
        Me.TxtWashingType.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(123, 170)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(91, 16)
        Me.Label8.TabIndex = 681
        Me.Label8.Text = "Washing Type"
        '
        'TxtTuftPerSqrInch
        '
        Me.TxtTuftPerSqrInch.AgMandatory = False
        Me.TxtTuftPerSqrInch.AgMasterHelp = True
        Me.TxtTuftPerSqrInch.AgNumberLeftPlaces = 8
        Me.TxtTuftPerSqrInch.AgNumberNegetiveAllow = False
        Me.TxtTuftPerSqrInch.AgNumberRightPlaces = 0
        Me.TxtTuftPerSqrInch.AgPickFromLastValue = False
        Me.TxtTuftPerSqrInch.AgRowFilter = ""
        Me.TxtTuftPerSqrInch.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTuftPerSqrInch.AgSelectedValue = Nothing
        Me.TxtTuftPerSqrInch.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTuftPerSqrInch.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTuftPerSqrInch.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTuftPerSqrInch.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTuftPerSqrInch.Location = New System.Drawing.Point(605, 149)
        Me.TxtTuftPerSqrInch.MaxLength = 0
        Me.TxtTuftPerSqrInch.Multiline = True
        Me.TxtTuftPerSqrInch.Name = "TxtTuftPerSqrInch"
        Me.TxtTuftPerSqrInch.Size = New System.Drawing.Size(134, 20)
        Me.TxtTuftPerSqrInch.TabIndex = 6
        Me.TxtTuftPerSqrInch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(484, 153)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(107, 16)
        Me.Label7.TabIndex = 680
        Me.Label7.Text = "Tuft per Sqr. Inch"
        '
        'TxtPileHeight
        '
        Me.TxtPileHeight.AgMandatory = False
        Me.TxtPileHeight.AgMasterHelp = True
        Me.TxtPileHeight.AgNumberLeftPlaces = 8
        Me.TxtPileHeight.AgNumberNegetiveAllow = False
        Me.TxtPileHeight.AgNumberRightPlaces = 2
        Me.TxtPileHeight.AgPickFromLastValue = False
        Me.TxtPileHeight.AgRowFilter = ""
        Me.TxtPileHeight.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPileHeight.AgSelectedValue = Nothing
        Me.TxtPileHeight.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPileHeight.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtPileHeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPileHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPileHeight.Location = New System.Drawing.Point(342, 149)
        Me.TxtPileHeight.MaxLength = 0
        Me.TxtPileHeight.Multiline = True
        Me.TxtPileHeight.Name = "TxtPileHeight"
        Me.TxtPileHeight.Size = New System.Drawing.Size(129, 20)
        Me.TxtPileHeight.TabIndex = 5
        Me.TxtPileHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(123, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 16)
        Me.Label5.TabIndex = 679
        Me.Label5.Text = "Pile Height (Soot)"
        '
        'TxtPileWeight
        '
        Me.TxtPileWeight.AgMandatory = True
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
        Me.TxtPileWeight.Location = New System.Drawing.Point(605, 127)
        Me.TxtPileWeight.MaxLength = 0
        Me.TxtPileWeight.Multiline = True
        Me.TxtPileWeight.Name = "TxtPileWeight"
        Me.TxtPileWeight.Size = New System.Drawing.Size(134, 20)
        Me.TxtPileWeight.TabIndex = 4
        Me.TxtPileWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(484, 131)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(107, 16)
        Me.Label6.TabIndex = 678
        Me.Label6.Text = "Pile Weight (Kg.)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(326, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 677
        Me.Label4.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(590, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 676
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
        Me.TxtConstruction.Location = New System.Drawing.Point(605, 83)
        Me.TxtConstruction.MaxLength = 0
        Me.TxtConstruction.Multiline = True
        Me.TxtConstruction.Name = "TxtConstruction"
        Me.TxtConstruction.Size = New System.Drawing.Size(134, 20)
        Me.TxtConstruction.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(484, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 675
        Me.Label3.Text = "Construction"
        '
        'TxtStdRugWeight
        '
        Me.TxtStdRugWeight.AgMandatory = True
        Me.TxtStdRugWeight.AgMasterHelp = True
        Me.TxtStdRugWeight.AgNumberLeftPlaces = 8
        Me.TxtStdRugWeight.AgNumberNegetiveAllow = False
        Me.TxtStdRugWeight.AgNumberRightPlaces = 3
        Me.TxtStdRugWeight.AgPickFromLastValue = False
        Me.TxtStdRugWeight.AgRowFilter = ""
        Me.TxtStdRugWeight.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStdRugWeight.AgSelectedValue = Nothing
        Me.TxtStdRugWeight.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStdRugWeight.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtStdRugWeight.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStdRugWeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStdRugWeight.Location = New System.Drawing.Point(342, 127)
        Me.TxtStdRugWeight.MaxLength = 0
        Me.TxtStdRugWeight.Multiline = True
        Me.TxtStdRugWeight.Name = "TxtStdRugWeight"
        Me.TxtStdRugWeight.Size = New System.Drawing.Size(129, 20)
        Me.TxtStdRugWeight.TabIndex = 3
        Me.TxtStdRugWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblRate
        '
        Me.LblRate.AutoSize = True
        Me.LblRate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRate.Location = New System.Drawing.Point(123, 129)
        Me.LblRate.Name = "LblRate"
        Me.LblRate.Size = New System.Drawing.Size(204, 16)
        Me.LblRate.TabIndex = 669
        Me.LblRate.Text = "Std Rug Weight per Sqr Yard(KG)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(326, 113)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 666
        Me.Label1.Text = "Ä"
        '
        'LblBank_NameReq
        '
        Me.LblBank_NameReq.AutoSize = True
        Me.LblBank_NameReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblBank_NameReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblBank_NameReq.Location = New System.Drawing.Point(326, 88)
        Me.LblBank_NameReq.Name = "LblBank_NameReq"
        Me.LblBank_NameReq.Size = New System.Drawing.Size(10, 7)
        Me.LblBank_NameReq.TabIndex = 664
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
        Me.TxtManualCode.Location = New System.Drawing.Point(342, 83)
        Me.TxtManualCode.MaxLength = 20
        Me.TxtManualCode.Multiline = True
        Me.TxtManualCode.Name = "TxtManualCode"
        Me.TxtManualCode.Size = New System.Drawing.Size(129, 20)
        Me.TxtManualCode.TabIndex = 0
        '
        'LblShortName
        '
        Me.LblShortName.AutoSize = True
        Me.LblShortName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShortName.Location = New System.Drawing.Point(123, 86)
        Me.LblShortName.Name = "LblShortName"
        Me.LblShortName.Size = New System.Drawing.Size(83, 16)
        Me.LblShortName.TabIndex = 660
        Me.LblShortName.Text = "Quality Code"
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
        Me.TxtDescription.Location = New System.Drawing.Point(342, 105)
        Me.TxtDescription.MaxLength = 50
        Me.TxtDescription.Multiline = True
        Me.TxtDescription.Name = "TxtDescription"
        Me.TxtDescription.Size = New System.Drawing.Size(397, 20)
        Me.TxtDescription.TabIndex = 2
        '
        'LblDescription
        '
        Me.LblDescription.AutoSize = True
        Me.LblDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDescription.Location = New System.Drawing.Point(123, 108)
        Me.LblDescription.Name = "LblDescription"
        Me.LblDescription.Size = New System.Drawing.Size(118, 16)
        Me.LblDescription.TabIndex = 661
        Me.LblDescription.Text = "Quality Description"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(590, 137)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(10, 7)
        Me.Label12.TabIndex = 686
        Me.Label12.Text = "Ä"
        '
        'FrmQuality1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 469)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtFringes)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.TxtClipping)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtWashingType)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TxtTuftPerSqrInch)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtPileHeight)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtPileWeight)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TxtConstruction)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtStdRugWeight)
        Me.Controls.Add(Me.LblRate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblBank_NameReq)
        Me.Controls.Add(Me.TxtManualCode)
        Me.Controls.Add(Me.LblShortName)
        Me.Controls.Add(Me.TxtDescription)
        Me.Controls.Add(Me.LblDescription)
        Me.Name = "FrmQuality1"
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
        Me.Controls.SetChildIndex(Me.LblShortName, 0)
        Me.Controls.SetChildIndex(Me.TxtManualCode, 0)
        Me.Controls.SetChildIndex(Me.LblBank_NameReq, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.LblRate, 0)
        Me.Controls.SetChildIndex(Me.TxtStdRugWeight, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtConstruction, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtPileWeight, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtPileHeight, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.TxtTuftPerSqrInch, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.TxtWashingType, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.TxtClipping, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.TxtFringes, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LblDescription As System.Windows.Forms.Label
    Friend WithEvents TxtDescription As AgControls.AgTextBox
    Friend WithEvents LblShortName As System.Windows.Forms.Label
    Friend WithEvents TxtManualCode As AgControls.AgTextBox
    Friend WithEvents LblBank_NameReq As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblRate As System.Windows.Forms.Label
    Friend WithEvents TxtStdRugWeight As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtConstruction As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtPileWeight As AgControls.AgTextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtPileHeight As AgControls.AgTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtTuftPerSqrInch As AgControls.AgTextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtWashingType As AgControls.AgTextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtClipping As AgControls.AgTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TxtFringes As AgControls.AgTextBox
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents LblTotalQty As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label

#End Region

    Private Sub FrmQuality1_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        'If AgL.RequiredField(TxtManualCode, "Short Name") Then Exit Sub
        'If AgL.RequiredField(TxtDescription, "Description") Then Exit Sub

        If TxtManualCode.Text.Trim = "" Then Err.Raise(1, , "Short Name Is Required!")
        If TxtDescription.Text.Trim = "" Then Err.Raise(1, , "Description Is Required!")

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Rug_Quality Where ManualCode='" & TxtManualCode.Text & "'  And " & ClsMain.RetDivFilterStr & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Quality  Code Already Exist!")

            mQry = "Select count(*) From Rug_Quality Where Description='" & TxtDescription.Text & "'  And " & ClsMain.RetDivFilterStr & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Quality  Description Already Exist!")

            mQry = "Select count(*) From Rug_Quality_Log Where ManualCode = '" & TxtManualCode.Text & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Quality Code Already Exists in Log File")

            mQry = "Select count(*) From Rug_Quality_Log Where Description='" & TxtDescription.Text & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Quality Description Already Exists in Log File")
        Else
            mQry = "Select count(*) From Rug_Quality Where ManualCode='" & TxtManualCode.Text & "' And Code<>'" & mInternalCode & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Quality  Code Already Exist!")

            mQry = "Select count(*) From Rug_Quality Where Description='" & TxtDescription.Text & "' And Code<>'" & mInternalCode & "'  And " & ClsMain.RetDivFilterStr & " "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Quality  Description Already Exist!")

            mQry = "Select count(*) From Rug_Quality_Log Where ManualCode = '" & TxtManualCode.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Quality Code Already Exists in Log File")

            mQry = "Select count(*) From Rug_Quality_Log Where Description = '" & TxtDescription.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then Err.Raise(1, , "Quality Description Already Exists in Log File")
        End If
    End Sub

    Private Sub FrmQuality1_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        AgL.PubFindQry = "SELECT UID, ManualCode as [Quality Code], Description [Quality Description], " & _
                        " Construction, StdRugWeight as [Std. Rug Weight], PileWeight as [Pile Weight], " & _
                        " PileHeight as [Pile Height], TuftPerSqrInch as [Tuft Per Sqr Inch], " & _
                        " WashingType as [Washing Type], Clipping, Fringes, TotalQty as [Total Qty] " & _
                        " FROM RUG_Quality_Log " & mConStr & _
                        " And EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "

        AgL.PubFindQryOrdBy = "[Quality Code]"
    End Sub

    Private Sub FrmQuality1_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        AgL.PubFindQry = "SELECT Code, ManualCode as [Quality Code], Description [Quality Description], " & _
                        " Construction, StdRugWeight as [Std. Rug Weight], " & _
                        " PileWeight as [Pile Weight], PileHeight as [Pile Height], " & _
                        " TuftPerSqrInch as [Tuft Per Sqr Inch], WashingType as [Washing Type], Clipping, " & _
                        " Fringes, TotalQty as [Total Qty] " & _
                        " FROM RUG_Quality " & mConStr & _
                        " And IsNull(IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Quality Code]"
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "RUG_QUALITY"
        LogTableName = "RUG_QUALITY_LOG"
        MainLineTableCsv = "RUG_QUALITYDETAIL"
        LogLineTableCsv = "RUG_QUALITYDETAIL_LOG"
    End Sub

    Private Sub FrmQuality1_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans

        mQry = "Update RUG_Quality_Log " & _
        "   SET  " & _
        "	ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & ", " & _
        "	Description = " & AgL.Chk_Text(TxtDescription.Text) & ", " & _
        "	Construction = " & AgL.Chk_Text(TxtConstruction.AgSelectedValue) & ", " & _
        "	StdRugWeight = " & Val(TxtStdRugWeight.Text) & ", " & _
        "	PileWeight = " & Val(TxtPileWeight.Text) & ", " & _
        "	PileHeight = " & Val(TxtPileHeight.Text) & ", " & _
        "	TuftPerSqrInch = " & Val(TxtTuftPerSqrInch.Text) & ", " & _
        "	WashingType = " & AgL.Chk_Text(TxtWashingType.AgSelectedValue) & ", " & _
        "	Clipping = " & AgL.Chk_Text(TxtClipping.AgSelectedValue) & ", " & _
        "	Fringes = " & AgL.Chk_Text(TxtFringes.AgSelectedValue) & ", " & _
        "	TotalQty = " & Val(LblTotalQty.Text) & " " & _
        " Where UID = '" & SearchCode & "' "

        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


        mQry = "Delete From Rug_QualityDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)


        Dim I As Integer
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1OtherMaterial, I).Value <> "" Then
                    mQry = "INSERT INTO dbo.RUG_QualityDetail_Log (UID, Code, Sr, OtherMaterial, QtyPerSqrYard, Unit) " & _
                           "VALUES (" & AgL.Chk_Text(SearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & Val(I) & ", " & AgL.Chk_Text(.AgSelectedValue(Col1OtherMaterial, I)) & ", " & Val(.Item(Col1QtyPerSqrYard, I).Value) & ",  " & AgL.Chk_Text(.Item(Col1Unit, I).Value) & ")"
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If
            Next
        End With


    End Sub

    Private Sub FrmQuality1_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub FrmQuality1_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim i As Integer
        LblTotalQty.Text = "0"
        With Dgl1
            For i = 0 To Dgl1.RowCount - 1
                If .Item(Col1OtherMaterial, i).Value <> "" Then
                    LblTotalQty.Text = Val(LblTotalQty.Text) + Val(.Item(Col1QtyPerSqrYard, i).Value)
                End If
            Next
            LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")
        End With

    End Sub

    Private Sub FrmQuality1_BaseFunction_DispText() Handles Me.BaseFunction_DispText

    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select  Code, ManualCode As [Quality Code], Div_Code  From Rug_Quality " & _
    "  Order By ManualCode"
        TxtManualCode.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code, Description As Name , Div_Code From Rug_Quality  " & _
            "  Order By Description"
        TxtDescription.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code, Description, Unit , Div_Code, Status, IsNull(IsDeleted,0) as IsDeleted " & _
               "From ITEM  Where ItemType = '" & ClsMain.ItemType.OtherMaterial & "' Order By Description"
        Dgl1.AgHelpDataSet(Col1OtherMaterial, 2) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code, Code as Name, IsNull(IsDeleted,0) as IsDeleted From Rug_Construction Order By Code "
        TxtConstruction.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code, Code As Description, Div_Code From WashingType  Order By Code"
        TxtWashingType.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        mQry = "Select Code, Code As Description, Div_Code From ClippingType Order By Code"
        TxtClipping.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)

        'TxtWashingType.AgHelpDataSet = AgL.FillData(ClsMain.HelpQueries.WashingType, AgL.GCn)
        'TxtClipping.AgHelpDataSet = AgL.FillData(ClsMain.HelpQueries.ClippingType, AgL.GCn)

        TxtFringes.AgHelpDataSet = AgL.FillData(ClsMain.HelpQueries.FringesType, AgL.GCn)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select Code As SearchCode " & _
            " From Rug_Quality " & mConStr & _
            " And IsNull(IsDeleted,0)=0 Order By ManualCode "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select UID As SearchCode " & _
               " From Rug_Quality_Log " & mConStr & _
               " And EntryStatus='" & LogStatus.LogOpen & "' Order By ManualCode"
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        With AgCL
            .AddAgTextColumn(Dgl1, "S.No.", 40, 5, "S.No.", True, True, False)
            .AddAgTextColumn(Dgl1, "Other Material", 270, 0, "Other Material", True, False, False)
            .AddAgNumberColumn(Dgl1, "Qty per Sqr. Yard", 120, 8, 3, False, "Qty per Sqr. Yard", True, False, True)
            .AddAgTextColumn(Dgl1, "Unit", 80, 0, "Unit", True, True, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.BackgroundColor = Color.White
        Dgl1.Anchor = AnchorStyles.None
        Panel1.Anchor = Dgl1.Anchor

        'Dim RctVar As Rectangle
        'Dim LGBBaseBackGround As System.Drawing.Drawing2D.LinearGradientBrush
        'Dim e As System.Windows.Forms.PaintEventArgs

        'RctVar = New Rectangle(0, 0, Panel1.Width, Panel1.Height)
        'LGBBaseBackGround = New System.Drawing.Drawing2D.LinearGradientBrush(RctVar, Color.Gray, _
        '                    Color.WhiteSmoke, System.Drawing.Drawing2D.LinearGradientMode.Vertical)

        'e.Graphics.FillRectangle(LGBBaseBackGround, RctVar)

    End Sub

    Private Sub FrmQuality1_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * " & _
                " From Rug_Quality Where Code='" & SearchCode & "'"
        Else
            mQry = "Select * " & _
                " From Rug_Quality_Log Where UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)


        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtManualCode.Text = AgL.XNull(.Rows(0)("ManualCode"))
                TxtDescription.Text = AgL.XNull(.Rows(0)("Description"))
                TxtConstruction.AgSelectedValue = AgL.XNull(.Rows(0)("Construction"))
                TxtStdRugWeight.Text = Format(AgL.VNull(.Rows(0)("StdRugWeight")), "0.000")
                TxtPileWeight.Text = Format(AgL.VNull(.Rows(0)("PileWeight")), "0.000")
                TxtPileHeight.Text = Format(AgL.VNull(.Rows(0)("PileHeight")), "0.00")
                TxtTuftPerSqrInch.Text = AgL.VNull(.Rows(0)("TuftPerSqrInch"))
                TxtWashingType.AgSelectedValue = AgL.XNull(.Rows(0)("WashingType"))
                TxtClipping.AgSelectedValue = AgL.XNull(.Rows(0)("Clipping"))
                TxtFringes.AgSelectedValue = AgL.XNull(.Rows(0)("Fringes"))
                LblTotalQty.Text = Format(AgL.VNull(.Rows(0)("TotalQty")), "0.000")

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                Dim I As Integer
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from Rug_QualityDetail where Code = '" & SearchCode & "'"
                Else
                    mQry = "Select * from Rug_QualityDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If


                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1OtherMaterial, I) = AgL.XNull(.Rows(I)("OtherMaterial"))
                            Dgl1.Item(Col1QtyPerSqrYard, I).Value = Format(AgL.VNull(.Rows(I)("QtyPerSqrYard")), "0.000")
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Next I
                    End If
                End With
                Calculation()
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

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow()

        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""

            Select Case Dgl1.CurrentCell.ColumnIndex
                Case Col1OtherMaterial
                    DrTemp = Dgl1.AgHelpDataSet(mColumnIndex).Tables(0).Select("Code = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1OtherMaterial, mRowIndex)) & "")
                    If DrTemp.Length > 0 Then
                        Dgl1.Item(Col1Unit, mRowIndex).Value = AgL.XNull(DrTemp(0)("Unit"))
                    End If
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmQuality1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.GridDesign(Dgl1)
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgL.WinSetting(Me, 505, 880, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtManualCode.Enter, TxtDescription.Enter, TxtClipping.Enter, TxtWashingType.Enter, TxtConstruction.Enter
        Try
            Select Case sender.name
                Case TxtManualCode.Name, TxtDescription.Name, TxtWashingType.Name, TxtClipping.Name
                    sender.AgRowFilter = ClsMain.RetDivFilterStr
                Case TxtConstruction.Name
                    sender.AgRowFilter = " IsDeleted = 0 "
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex

            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.CurrentCell.ColumnIndex
                Case Col1OtherMaterial
                    Dgl1.AgRowFilter(Col1OtherMaterial) = ClsMain.RetDivFilterStr
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub Dgl1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Dgl1.KeyPress

    End Sub
End Class
