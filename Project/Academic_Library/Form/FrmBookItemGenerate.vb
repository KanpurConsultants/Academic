Public Class FrmBookItemGenerate
    Inherits AgTemplate.TempItem

    Dim mQry$ = ""
    Protected WithEvents TxtBookType As AgControls.AgTextBox
    Protected WithEvents LblBookType As System.Windows.Forms.Label

    Dim mCDSearchCode As String
    Protected WithEvents LblUnderSubject As System.Windows.Forms.Label
    Protected WithEvents TxtUnderSubject As AgControls.AgTextBox
    Protected WithEvents LblPrefix As System.Windows.Forms.Label
    Protected WithEvents TxtPrefix As AgControls.AgTextBox
    Dim mIsOkButtonClick As Boolean = False

    Dim mSubjectSearchCode$ = "", mSubjectInternalCode$ = ""
    Public WithEvents lblPlace As System.Windows.Forms.Label
    Public WithEvents TxtPlace As AgControls.AgTextBox
    Public WithEvents LblPages As System.Windows.Forms.Label
    Public WithEvents TxtPages As AgControls.AgTextBox
    Public WithEvents TxtPublicationYear As AgControls.AgTextBox
    Public WithEvents lblRate As System.Windows.Forms.Label
    Public WithEvents TXtRate As AgControls.AgTextBox
    Public WithEvents LblPublicationYear As System.Windows.Forms.Label

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        'Topctrl1.SetDisp(False)
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtWriter = New AgControls.AgTextBox
        Me.LblWriter = New System.Windows.Forms.Label
        Me.TxtPublisher = New AgControls.AgTextBox
        Me.LblPublisher = New System.Windows.Forms.Label
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubject = New System.Windows.Forms.Label
        Me.TxtVolume = New AgControls.AgTextBox
        Me.LblVolume = New System.Windows.Forms.Label
        Me.TxtWithCD = New AgControls.AgTextBox
        Me.LblWithCD = New System.Windows.Forms.Label
        Me.LblSubjectReq = New System.Windows.Forms.Label
        Me.TxtBookName = New AgControls.AgTextBox
        Me.LblBookName = New System.Windows.Forms.Label
        Me.BtnOk = New System.Windows.Forms.Button
        Me.BtnCancel = New System.Windows.Forms.Button
        Me.TxtBookType = New AgControls.AgTextBox
        Me.LblBookType = New System.Windows.Forms.Label
        Me.LblUnderSubject = New System.Windows.Forms.Label
        Me.TxtUnderSubject = New AgControls.AgTextBox
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.TxtPrefix = New AgControls.AgTextBox
        Me.lblPlace = New System.Windows.Forms.Label
        Me.TxtPlace = New AgControls.AgTextBox
        Me.LblPages = New System.Windows.Forms.Label
        Me.TxtPages = New AgControls.AgTextBox
        Me.TxtPublicationYear = New AgControls.AgTextBox
        Me.LblPublicationYear = New System.Windows.Forms.Label
        Me.lblRate = New System.Windows.Forms.Label
        Me.TXtRate = New AgControls.AgTextBox
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LblDescription
        '
        Me.LblDescription.Location = New System.Drawing.Point(5, 25)
        Me.LblDescription.Size = New System.Drawing.Size(107, 16)
        Me.LblDescription.Text = "Book Description"
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(131, 25)
        Me.TxtDescription.Size = New System.Drawing.Size(314, 18)
        Me.TxtDescription.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(115, 29)
        '
        'TxtUnit
        '
        Me.TxtUnit.Location = New System.Drawing.Point(896, 453)
        Me.TxtUnit.Size = New System.Drawing.Size(132, 18)
        Me.TxtUnit.TabIndex = 5
        Me.TxtUnit.Visible = False
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.Location = New System.Drawing.Point(791, 297)
        Me.LblManualCodeReq.Visible = False
        '
        'TxtManualCode
        '
        Me.TxtManualCode.AgMandatory = False
        Me.TxtManualCode.Location = New System.Drawing.Point(769, 308)
        Me.TxtManualCode.Size = New System.Drawing.Size(43, 18)
        Me.TxtManualCode.TabIndex = 2
        Me.TxtManualCode.Visible = False
        '
        'LblManualCode
        '
        Me.LblManualCode.Location = New System.Drawing.Point(766, 279)
        Me.LblManualCode.Visible = False
        '
        'TxtUPCCode
        '
        Me.TxtUPCCode.Location = New System.Drawing.Point(972, 413)
        Me.TxtUPCCode.Size = New System.Drawing.Size(46, 18)
        Me.TxtUPCCode.Visible = False
        '
        'LblUPCCode
        '
        Me.LblUPCCode.Location = New System.Drawing.Point(881, 397)
        Me.LblUPCCode.Visible = False
        '
        'TxtSalesTaxPostingGroup
        '
        Me.TxtSalesTaxPostingGroup.Location = New System.Drawing.Point(947, 366)
        Me.TxtSalesTaxPostingGroup.Size = New System.Drawing.Size(62, 18)
        Me.TxtSalesTaxPostingGroup.Visible = False
        '
        'LblSalesTaxPostingGroup
        '
        Me.LblSalesTaxPostingGroup.Location = New System.Drawing.Point(723, 350)
        Me.LblSalesTaxPostingGroup.Visible = False
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(597, 78)
        Me.Pnl1.Size = New System.Drawing.Size(120, 37)
        '
        'LblUnit
        '
        Me.LblUnit.Location = New System.Drawing.Point(917, 434)
        Me.LblUnit.Visible = False
        '
        'TxtItemGroup
        '
        Me.TxtItemGroup.Location = New System.Drawing.Point(944, 318)
        Me.TxtItemGroup.Size = New System.Drawing.Size(65, 18)
        Me.TxtItemGroup.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(881, 413)
        '
        'TxtExciseGroup
        '
        Me.TxtExciseGroup.Location = New System.Drawing.Point(947, 342)
        Me.TxtExciseGroup.Size = New System.Drawing.Size(62, 18)
        '
        'LblExciseGroup
        '
        Me.LblExciseGroup.Location = New System.Drawing.Point(931, 226)
        '
        'TxtEntryTaxGroup
        '
        Me.TxtEntryTaxGroup.Location = New System.Drawing.Point(965, 389)
        Me.TxtEntryTaxGroup.Size = New System.Drawing.Size(44, 18)
        '
        'LblEntryTaxGroup
        '
        Me.LblEntryTaxGroup.Location = New System.Drawing.Point(845, 350)
        '
        'Topctrl1
        '
        Me.Topctrl1.Dock = System.Windows.Forms.DockStyle.None
        Me.Topctrl1.Location = New System.Drawing.Point(647, 174)
        Me.Topctrl1.Size = New System.Drawing.Size(42, 36)
        Me.Topctrl1.TabIndex = 7
        Me.Topctrl1.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 147)
        Me.GroupBox1.Size = New System.Drawing.Size(452, 8)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(571, 79)
        Me.GrpUP.Visible = False
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(583, 62)
        Me.GBoxEntryType.Visible = False
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(855, 141)
        Me.GBoxMoveToLog.Visible = False
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(702, 141)
        Me.GBoxApprove.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(704, 141)
        Me.GroupBox2.Visible = False
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(487, 152)
        Me.GBoxDivision.Visible = False
        '
        'TxtWriter
        '
        Me.TxtWriter.AgMandatory = False
        Me.TxtWriter.AgMasterHelp = True
        Me.TxtWriter.AgNumberLeftPlaces = 0
        Me.TxtWriter.AgNumberNegetiveAllow = False
        Me.TxtWriter.AgNumberRightPlaces = 0
        Me.TxtWriter.AgPickFromLastValue = False
        Me.TxtWriter.AgRowFilter = ""
        Me.TxtWriter.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtWriter.AgSelectedValue = Nothing
        Me.TxtWriter.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtWriter.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtWriter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtWriter.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWriter.Location = New System.Drawing.Point(131, 65)
        Me.TxtWriter.MaxLength = 100
        Me.TxtWriter.Name = "TxtWriter"
        Me.TxtWriter.Size = New System.Drawing.Size(130, 18)
        Me.TxtWriter.TabIndex = 5
        '
        'LblWriter
        '
        Me.LblWriter.AutoSize = True
        Me.LblWriter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWriter.Location = New System.Drawing.Point(5, 66)
        Me.LblWriter.Name = "LblWriter"
        Me.LblWriter.Size = New System.Drawing.Size(43, 16)
        Me.LblWriter.TabIndex = 866
        Me.LblWriter.Text = "Writer"
        '
        'TxtPublisher
        '
        Me.TxtPublisher.AgMandatory = False
        Me.TxtPublisher.AgMasterHelp = True
        Me.TxtPublisher.AgNumberLeftPlaces = 8
        Me.TxtPublisher.AgNumberNegetiveAllow = False
        Me.TxtPublisher.AgNumberRightPlaces = 2
        Me.TxtPublisher.AgPickFromLastValue = False
        Me.TxtPublisher.AgRowFilter = ""
        Me.TxtPublisher.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPublisher.AgSelectedValue = Nothing
        Me.TxtPublisher.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPublisher.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPublisher.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPublisher.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPublisher.Location = New System.Drawing.Point(131, 85)
        Me.TxtPublisher.MaxLength = 100
        Me.TxtPublisher.Name = "TxtPublisher"
        Me.TxtPublisher.Size = New System.Drawing.Size(130, 18)
        Me.TxtPublisher.TabIndex = 7
        '
        'LblPublisher
        '
        Me.LblPublisher.AutoSize = True
        Me.LblPublisher.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPublisher.Location = New System.Drawing.Point(5, 86)
        Me.LblPublisher.Name = "LblPublisher"
        Me.LblPublisher.Size = New System.Drawing.Size(62, 16)
        Me.LblPublisher.TabIndex = 864
        Me.LblPublisher.Text = "Publisher"
        '
        'TxtSubject
        '
        Me.TxtSubject.AgMandatory = True
        Me.TxtSubject.AgMasterHelp = True
        Me.TxtSubject.AgNumberLeftPlaces = 8
        Me.TxtSubject.AgNumberNegetiveAllow = False
        Me.TxtSubject.AgNumberRightPlaces = 2
        Me.TxtSubject.AgPickFromLastValue = False
        Me.TxtSubject.AgRowFilter = ""
        Me.TxtSubject.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubject.AgSelectedValue = Nothing
        Me.TxtSubject.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubject.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubject.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubject.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubject.Location = New System.Drawing.Point(131, 105)
        Me.TxtSubject.MaxLength = 100
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(189, 18)
        Me.TxtSubject.TabIndex = 9
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(5, 107)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(52, 16)
        Me.LblSubject.TabIndex = 869
        Me.LblSubject.Text = "Subject"
        '
        'TxtVolume
        '
        Me.TxtVolume.AgMandatory = False
        Me.TxtVolume.AgMasterHelp = True
        Me.TxtVolume.AgNumberLeftPlaces = 0
        Me.TxtVolume.AgNumberNegetiveAllow = False
        Me.TxtVolume.AgNumberRightPlaces = 0
        Me.TxtVolume.AgPickFromLastValue = False
        Me.TxtVolume.AgRowFilter = ""
        Me.TxtVolume.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVolume.AgSelectedValue = Nothing
        Me.TxtVolume.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVolume.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVolume.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVolume.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVolume.Location = New System.Drawing.Point(369, 5)
        Me.TxtVolume.MaxLength = 5
        Me.TxtVolume.Name = "TxtVolume"
        Me.TxtVolume.Size = New System.Drawing.Size(76, 18)
        Me.TxtVolume.TabIndex = 1
        '
        'LblVolume
        '
        Me.LblVolume.AutoSize = True
        Me.LblVolume.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVolume.Location = New System.Drawing.Point(311, 5)
        Me.LblVolume.Name = "LblVolume"
        Me.LblVolume.Size = New System.Drawing.Size(52, 16)
        Me.LblVolume.TabIndex = 874
        Me.LblVolume.Text = "Volume"
        '
        'TxtWithCD
        '
        Me.TxtWithCD.AgMandatory = False
        Me.TxtWithCD.AgMasterHelp = True
        Me.TxtWithCD.AgNumberLeftPlaces = 8
        Me.TxtWithCD.AgNumberNegetiveAllow = False
        Me.TxtWithCD.AgNumberRightPlaces = 2
        Me.TxtWithCD.AgPickFromLastValue = False
        Me.TxtWithCD.AgRowFilter = ""
        Me.TxtWithCD.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtWithCD.AgSelectedValue = Nothing
        Me.TxtWithCD.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtWithCD.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtWithCD.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtWithCD.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWithCD.Location = New System.Drawing.Point(389, 105)
        Me.TxtWithCD.MaxLength = 100
        Me.TxtWithCD.Name = "TxtWithCD"
        Me.TxtWithCD.Size = New System.Drawing.Size(55, 18)
        Me.TxtWithCD.TabIndex = 10
        '
        'LblWithCD
        '
        Me.LblWithCD.AutoSize = True
        Me.LblWithCD.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWithCD.Location = New System.Drawing.Point(326, 106)
        Me.LblWithCD.Name = "LblWithCD"
        Me.LblWithCD.Size = New System.Drawing.Size(57, 16)
        Me.LblWithCD.TabIndex = 886
        Me.LblWithCD.Text = "With CD"
        '
        'LblSubjectReq
        '
        Me.LblSubjectReq.AutoSize = True
        Me.LblSubjectReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubjectReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubjectReq.Location = New System.Drawing.Point(115, 113)
        Me.LblSubjectReq.Name = "LblSubjectReq"
        Me.LblSubjectReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubjectReq.TabIndex = 896
        Me.LblSubjectReq.Text = "Ä"
        '
        'TxtBookName
        '
        Me.TxtBookName.AgMandatory = False
        Me.TxtBookName.AgMasterHelp = True
        Me.TxtBookName.AgNumberLeftPlaces = 0
        Me.TxtBookName.AgNumberNegetiveAllow = False
        Me.TxtBookName.AgNumberRightPlaces = 0
        Me.TxtBookName.AgPickFromLastValue = False
        Me.TxtBookName.AgRowFilter = ""
        Me.TxtBookName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBookName.AgSelectedValue = Nothing
        Me.TxtBookName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBookName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBookName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBookName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBookName.Location = New System.Drawing.Point(131, 5)
        Me.TxtBookName.MaxLength = 45
        Me.TxtBookName.Name = "TxtBookName"
        Me.TxtBookName.Size = New System.Drawing.Size(175, 18)
        Me.TxtBookName.TabIndex = 0
        '
        'LblBookName
        '
        Me.LblBookName.AutoSize = True
        Me.LblBookName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBookName.Location = New System.Drawing.Point(5, 5)
        Me.LblBookName.Name = "LblBookName"
        Me.LblBookName.Size = New System.Drawing.Size(76, 16)
        Me.LblBookName.TabIndex = 900
        Me.LblBookName.Text = "Book Name"
        '
        'BtnOk
        '
        Me.BtnOk.BackColor = System.Drawing.Color.Transparent
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOk.Location = New System.Drawing.Point(333, 157)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(54, 23)
        Me.BtnOk.TabIndex = 14
        Me.BtnOk.Text = "OK"
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'BtnCancel
        '
        Me.BtnCancel.BackColor = System.Drawing.Color.Transparent
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Location = New System.Drawing.Point(390, 157)
        Me.BtnCancel.Name = "BtnCancel"
        Me.BtnCancel.Size = New System.Drawing.Size(54, 23)
        Me.BtnCancel.TabIndex = 15
        Me.BtnCancel.Text = "Cancel"
        Me.BtnCancel.UseVisualStyleBackColor = False
        '
        'TxtBookType
        '
        Me.TxtBookType.AgMandatory = False
        Me.TxtBookType.AgMasterHelp = False
        Me.TxtBookType.AgNumberLeftPlaces = 8
        Me.TxtBookType.AgNumberNegetiveAllow = False
        Me.TxtBookType.AgNumberRightPlaces = 2
        Me.TxtBookType.AgPickFromLastValue = False
        Me.TxtBookType.AgRowFilter = ""
        Me.TxtBookType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBookType.AgSelectedValue = Nothing
        Me.TxtBookType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBookType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBookType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBookType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBookType.Location = New System.Drawing.Point(131, 45)
        Me.TxtBookType.MaxLength = 100
        Me.TxtBookType.Name = "TxtBookType"
        Me.TxtBookType.Size = New System.Drawing.Size(130, 18)
        Me.TxtBookType.TabIndex = 3
        '
        'LblBookType
        '
        Me.LblBookType.AutoSize = True
        Me.LblBookType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBookType.Location = New System.Drawing.Point(5, 46)
        Me.LblBookType.Name = "LblBookType"
        Me.LblBookType.Size = New System.Drawing.Size(66, 16)
        Me.LblBookType.TabIndex = 904
        Me.LblBookType.Text = "BookType"
        '
        'LblUnderSubject
        '
        Me.LblUnderSubject.AutoSize = True
        Me.LblUnderSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUnderSubject.Location = New System.Drawing.Point(5, 127)
        Me.LblUnderSubject.Name = "LblUnderSubject"
        Me.LblUnderSubject.Size = New System.Drawing.Size(90, 16)
        Me.LblUnderSubject.TabIndex = 907
        Me.LblUnderSubject.Text = "Under Subject"
        '
        'TxtUnderSubject
        '
        Me.TxtUnderSubject.AgMandatory = False
        Me.TxtUnderSubject.AgMasterHelp = False
        Me.TxtUnderSubject.AgNumberLeftPlaces = 8
        Me.TxtUnderSubject.AgNumberNegetiveAllow = False
        Me.TxtUnderSubject.AgNumberRightPlaces = 2
        Me.TxtUnderSubject.AgPickFromLastValue = False
        Me.TxtUnderSubject.AgRowFilter = ""
        Me.TxtUnderSubject.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtUnderSubject.AgSelectedValue = Nothing
        Me.TxtUnderSubject.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtUnderSubject.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtUnderSubject.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtUnderSubject.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUnderSubject.Location = New System.Drawing.Point(131, 125)
        Me.TxtUnderSubject.MaxLength = 100
        Me.TxtUnderSubject.Name = "TxtUnderSubject"
        Me.TxtUnderSubject.Size = New System.Drawing.Size(130, 18)
        Me.TxtUnderSubject.TabIndex = 11
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.Location = New System.Drawing.Point(259, 127)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(28, 16)
        Me.LblPrefix.TabIndex = 908
        Me.LblPrefix.Text = "Pre"
        '
        'TxtPrefix
        '
        Me.TxtPrefix.AgMandatory = False
        Me.TxtPrefix.AgMasterHelp = True
        Me.TxtPrefix.AgNumberLeftPlaces = 8
        Me.TxtPrefix.AgNumberNegetiveAllow = False
        Me.TxtPrefix.AgNumberRightPlaces = 2
        Me.TxtPrefix.AgPickFromLastValue = False
        Me.TxtPrefix.AgRowFilter = ""
        Me.TxtPrefix.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPrefix.AgSelectedValue = Nothing
        Me.TxtPrefix.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPrefix.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPrefix.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrefix.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrefix.Location = New System.Drawing.Point(287, 126)
        Me.TxtPrefix.MaxLength = 100
        Me.TxtPrefix.Name = "TxtPrefix"
        Me.TxtPrefix.Size = New System.Drawing.Size(33, 18)
        Me.TxtPrefix.TabIndex = 12
        '
        'lblPlace
        '
        Me.lblPlace.AutoSize = True
        Me.lblPlace.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlace.Location = New System.Drawing.Point(267, 65)
        Me.lblPlace.Name = "lblPlace"
        Me.lblPlace.Size = New System.Drawing.Size(89, 16)
        Me.lblPlace.TabIndex = 914
        Me.lblPlace.Text = "Place Of Pub."
        '
        'TxtPlace
        '
        Me.TxtPlace.AgMandatory = False
        Me.TxtPlace.AgMasterHelp = True
        Me.TxtPlace.AgNumberLeftPlaces = 8
        Me.TxtPlace.AgNumberNegetiveAllow = False
        Me.TxtPlace.AgNumberRightPlaces = 2
        Me.TxtPlace.AgPickFromLastValue = False
        Me.TxtPlace.AgRowFilter = ""
        Me.TxtPlace.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPlace.AgSelectedValue = Nothing
        Me.TxtPlace.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPlace.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPlace.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPlace.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPlace.Location = New System.Drawing.Point(369, 65)
        Me.TxtPlace.MaxLength = 20
        Me.TxtPlace.Name = "TxtPlace"
        Me.TxtPlace.Size = New System.Drawing.Size(75, 18)
        Me.TxtPlace.TabIndex = 6
        '
        'LblPages
        '
        Me.LblPages.AutoSize = True
        Me.LblPages.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPages.Location = New System.Drawing.Point(267, 85)
        Me.LblPages.Name = "LblPages"
        Me.LblPages.Size = New System.Drawing.Size(45, 16)
        Me.LblPages.TabIndex = 913
        Me.LblPages.Text = "Pages"
        '
        'TxtPages
        '
        Me.TxtPages.AgMandatory = False
        Me.TxtPages.AgMasterHelp = False
        Me.TxtPages.AgNumberLeftPlaces = 8
        Me.TxtPages.AgNumberNegetiveAllow = False
        Me.TxtPages.AgNumberRightPlaces = 0
        Me.TxtPages.AgPickFromLastValue = False
        Me.TxtPages.AgRowFilter = ""
        Me.TxtPages.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPages.AgSelectedValue = Nothing
        Me.TxtPages.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPages.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtPages.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPages.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPages.Location = New System.Drawing.Point(369, 85)
        Me.TxtPages.MaxLength = 20
        Me.TxtPages.Name = "TxtPages"
        Me.TxtPages.Size = New System.Drawing.Size(75, 18)
        Me.TxtPages.TabIndex = 8
        '
        'TxtPublicationYear
        '
        Me.TxtPublicationYear.AgMandatory = False
        Me.TxtPublicationYear.AgMasterHelp = False
        Me.TxtPublicationYear.AgNumberLeftPlaces = 8
        Me.TxtPublicationYear.AgNumberNegetiveAllow = False
        Me.TxtPublicationYear.AgNumberRightPlaces = 2
        Me.TxtPublicationYear.AgPickFromLastValue = False
        Me.TxtPublicationYear.AgRowFilter = ""
        Me.TxtPublicationYear.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPublicationYear.AgSelectedValue = Nothing
        Me.TxtPublicationYear.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPublicationYear.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPublicationYear.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPublicationYear.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPublicationYear.Location = New System.Drawing.Point(369, 45)
        Me.TxtPublicationYear.MaxLength = 20
        Me.TxtPublicationYear.Name = "TxtPublicationYear"
        Me.TxtPublicationYear.Size = New System.Drawing.Size(76, 18)
        Me.TxtPublicationYear.TabIndex = 4
        '
        'LblPublicationYear
        '
        Me.LblPublicationYear.AutoSize = True
        Me.LblPublicationYear.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPublicationYear.Location = New System.Drawing.Point(267, 47)
        Me.LblPublicationYear.Name = "LblPublicationYear"
        Me.LblPublicationYear.Size = New System.Drawing.Size(103, 16)
        Me.LblPublicationYear.TabIndex = 912
        Me.LblPublicationYear.Text = "Publication Year"
        '
        'lblRate
        '
        Me.lblRate.AutoSize = True
        Me.lblRate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRate.Location = New System.Drawing.Point(333, 127)
        Me.lblRate.Name = "lblRate"
        Me.lblRate.Size = New System.Drawing.Size(35, 16)
        Me.lblRate.TabIndex = 916
        Me.lblRate.Text = "Rate"
        '
        'TXtRate
        '
        Me.TXtRate.AgMandatory = False
        Me.TXtRate.AgMasterHelp = False
        Me.TXtRate.AgNumberLeftPlaces = 8
        Me.TXtRate.AgNumberNegetiveAllow = False
        Me.TXtRate.AgNumberRightPlaces = 2
        Me.TXtRate.AgPickFromLastValue = False
        Me.TXtRate.AgRowFilter = ""
        Me.TXtRate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TXtRate.AgSelectedValue = Nothing
        Me.TXtRate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TXtRate.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TXtRate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TXtRate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXtRate.Location = New System.Drawing.Point(389, 125)
        Me.TXtRate.MaxLength = 20
        Me.TXtRate.Name = "TXtRate"
        Me.TXtRate.Size = New System.Drawing.Size(55, 18)
        Me.TXtRate.TabIndex = 13
        '
        'FrmBookItemGenerate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(456, 188)
        Me.Controls.Add(Me.lblRate)
        Me.Controls.Add(Me.TXtRate)
        Me.Controls.Add(Me.lblPlace)
        Me.Controls.Add(Me.TxtPlace)
        Me.Controls.Add(Me.LblPages)
        Me.Controls.Add(Me.TxtPages)
        Me.Controls.Add(Me.TxtPublicationYear)
        Me.Controls.Add(Me.LblPublicationYear)
        Me.Controls.Add(Me.LblUnderSubject)
        Me.Controls.Add(Me.TxtUnderSubject)
        Me.Controls.Add(Me.LblPrefix)
        Me.Controls.Add(Me.TxtPrefix)
        Me.Controls.Add(Me.TxtVolume)
        Me.Controls.Add(Me.LblPublisher)
        Me.Controls.Add(Me.TxtPublisher)
        Me.Controls.Add(Me.LblWriter)
        Me.Controls.Add(Me.TxtWriter)
        Me.Controls.Add(Me.LblSubject)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.LblVolume)
        Me.Controls.Add(Me.LblWithCD)
        Me.Controls.Add(Me.TxtWithCD)
        Me.Controls.Add(Me.LblSubjectReq)
        Me.Controls.Add(Me.LblBookName)
        Me.Controls.Add(Me.TxtBookName)
        Me.Controls.Add(Me.LblBookType)
        Me.Controls.Add(Me.TxtBookType)
        Me.Controls.Add(Me.BtnCancel)
        Me.Controls.Add(Me.BtnOk)
        Me.LogLineTableCsv = "ItemBuyer_Log"
        Me.LogTableName = "Item_LOG"
        Me.MainLineTableCsv = "ItemBuyer"
        Me.MainTableName = "Item"
        Me.Name = "FrmBookItemGenerate"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Book Master"
        Me.Controls.SetChildIndex(Me.BtnOk, 0)
        Me.Controls.SetChildIndex(Me.BtnCancel, 0)
        Me.Controls.SetChildIndex(Me.TxtDescription, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.LblDescription, 0)
        Me.Controls.SetChildIndex(Me.TxtBookType, 0)
        Me.Controls.SetChildIndex(Me.LblBookType, 0)
        Me.Controls.SetChildIndex(Me.TxtBookName, 0)
        Me.Controls.SetChildIndex(Me.LblBookName, 0)
        Me.Controls.SetChildIndex(Me.LblSubjectReq, 0)
        Me.Controls.SetChildIndex(Me.TxtWithCD, 0)
        Me.Controls.SetChildIndex(Me.LblWithCD, 0)
        Me.Controls.SetChildIndex(Me.LblVolume, 0)
        Me.Controls.SetChildIndex(Me.TxtSubject, 0)
        Me.Controls.SetChildIndex(Me.LblSubject, 0)
        Me.Controls.SetChildIndex(Me.TxtWriter, 0)
        Me.Controls.SetChildIndex(Me.LblWriter, 0)
        Me.Controls.SetChildIndex(Me.TxtPublisher, 0)
        Me.Controls.SetChildIndex(Me.LblPublisher, 0)
        Me.Controls.SetChildIndex(Me.TxtVolume, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.LblUnit, 0)
        Me.Controls.SetChildIndex(Me.TxtUnit, 0)
        Me.Controls.SetChildIndex(Me.LblManualCode, 0)
        Me.Controls.SetChildIndex(Me.TxtManualCode, 0)
        Me.Controls.SetChildIndex(Me.LblManualCodeReq, 0)
        Me.Controls.SetChildIndex(Me.LblUPCCode, 0)
        Me.Controls.SetChildIndex(Me.TxtUPCCode, 0)
        Me.Controls.SetChildIndex(Me.LblSalesTaxPostingGroup, 0)
        Me.Controls.SetChildIndex(Me.TxtSalesTaxPostingGroup, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtItemGroup, 0)
        Me.Controls.SetChildIndex(Me.LblExciseGroup, 0)
        Me.Controls.SetChildIndex(Me.TxtExciseGroup, 0)
        Me.Controls.SetChildIndex(Me.LblEntryTaxGroup, 0)
        Me.Controls.SetChildIndex(Me.TxtEntryTaxGroup, 0)
        Me.Controls.SetChildIndex(Me.TxtPrefix, 0)
        Me.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.Controls.SetChildIndex(Me.TxtUnderSubject, 0)
        Me.Controls.SetChildIndex(Me.LblUnderSubject, 0)
        Me.Controls.SetChildIndex(Me.LblPublicationYear, 0)
        Me.Controls.SetChildIndex(Me.TxtPublicationYear, 0)
        Me.Controls.SetChildIndex(Me.TxtPages, 0)
        Me.Controls.SetChildIndex(Me.LblPages, 0)
        Me.Controls.SetChildIndex(Me.TxtPlace, 0)
        Me.Controls.SetChildIndex(Me.lblPlace, 0)
        Me.Controls.SetChildIndex(Me.TXtRate, 0)
        Me.Controls.SetChildIndex(Me.lblRate, 0)
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
    Protected WithEvents LblPublisher As System.Windows.Forms.Label
    Protected WithEvents TxtSubject As AgControls.AgTextBox
    Protected WithEvents LblSubject As System.Windows.Forms.Label
    Protected WithEvents TxtVolume As AgControls.AgTextBox
    Protected WithEvents LblVolume As System.Windows.Forms.Label
    Protected WithEvents TxtWithCD As AgControls.AgTextBox
    Protected WithEvents LblWithCD As System.Windows.Forms.Label
    Protected WithEvents TxtPublisher As AgControls.AgTextBox
    Protected WithEvents LblWriter As System.Windows.Forms.Label
    Protected WithEvents TxtWriter As AgControls.AgTextBox
    Friend WithEvents LblSubjectReq As System.Windows.Forms.Label
    Protected WithEvents TxtBookName As AgControls.AgTextBox
    Protected WithEvents LblBookName As System.Windows.Forms.Label
    Protected WithEvents BtnOk As System.Windows.Forms.Button
    Protected WithEvents BtnCancel As System.Windows.Forms.Button
#End Region

    Private Sub FrmBook_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        If TxtWithCD.Text = "Yes" Then
            Call ProcSaveCDItem(True, Conn, Cmd)
        Else
            Call ProcSaveCDItem(False, Conn, Cmd)
        End If
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Book & "'  " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select I.Code As SearchCode " & _
            " From Item I " & mConStr & _
            " And IsNull(I.IsDeleted,0)=0 Order By I.Description "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Book & "'  " & AgL.RetDivisionCondition(AgL, "Div_Code") & " "
        mQry = "Select I.UID As SearchCode " & _
               " From Item_log I " & mConStr & _
               " And I.EntryStatus='" & LogStatus.LogOpen & "' Order By I.Description "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmBook_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        TxtManualCode.Text = mInternalCode

        If AgL.RequiredField(TxtManualCode, LblManualCode.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtSubject, LblSubject.Text) Then passed = False : Exit Sub

        If Val(TxtManualCode.Text) <> 0 Then
            LblManualCode.Tag = TxtManualCode.Text
            TxtManualCode.Text = " " & LblSubject.Tag.ToString() & "" & TxtManualCode.Text & " " & LblBookType.Tag.ToString() & ""
        Else
            If Strings.Left(TxtManualCode.Text.Trim.ToString(), Len(LblSubject.Tag)) <> LblSubject.Tag Or Strings.Right(TxtManualCode.Text.Trim.ToString(), Len(LblBookType.Tag)) <> LblBookType.Tag Then
                ' Or Val(Strings.Mid(TxtManualCode.Text.Trim.ToString(), Len(LblSubject.Tag) + 1, Len(TxtManualCode.Text.Trim) - Len(LblBookType.Tag) - Len(LblSubject.Tag))) = 0 Then
                'Err.Raise(1, , "Item Code Format is Not Valid !")
            End If
            ' MsgBox(Strings.Mid(TxtManualCode.Text.Trim.ToString(), Len(LblSubject.Tag) + 1, Len(TxtManualCode.Text.Trim) - Len(LblBookType.Tag) - Len(LblSubject.Tag)))
        End If

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Item Where ManualCode ='" & TxtManualCode.Text & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Item Code Already Exist!") : passed = False : Exit Sub

            mQry = "Select count(*) From Item_Log Where ManualCode = '" & TxtManualCode.Text & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Item Code Already Exists in Log File") : passed = False : Exit Sub
        Else
            mQry = "Select count(*) From Item Where ManualCode ='" & TxtManualCode.Text & "' And Code<>'" & mInternalCode & "' And " & ClsMain.RetDivFilterStr & "  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Item Code Already Exist!") : passed = False : Exit Sub

            mQry = "Select count(*) From Item_Log Where ManualCode = '" & TxtManualCode.Text & "' And UID <>'" & mSearchCode & "' And " & ClsMain.RetDivFilterStr & "  And EntryStatus='" & ClsMain.LogStatus.LogOpen & "' and IsNull(MoveToLog,'')=''  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then MsgBox("Item Code Already Exists in Log File") : passed = False : Exit Sub
        End If
    End Sub

    Private Sub FrmYarn_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        ProcSaveSubject(Conn, Cmd)

        mQry = "UPDATE Item_Log " & _
                " SET " & _
                " ItemType = " & AgL.Chk_Text(ClsMain.ItemType.Book) & "  " & _
                " Where UID = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = " INSERT INTO Lib_Book_Log(UID, Code, Writer, Publisher, Subject, Volume,	WithCD, BookType, BookDescription,PlaceOfPub,PubYear,pages,Rate) " & _
                " VALUES('" & mSearchCode & "','" & mInternalCode & "'," & AgL.Chk_Text(TxtWriter.Text) & ",	 " & _
                " " & AgL.Chk_Text(TxtPublisher.Text) & ", " & _
                " " & AgL.Chk_Text(IIf(TxtSubject.AgSelectedValue <> "", TxtSubject.AgSelectedValue, mSubjectInternalCode)) & ", " & _
                " " & AgL.Chk_Text(TxtVolume.Text) & ", " & IIf(TxtWithCD.Text = "Yes", 1, 0) & ", " & _
                " " & AgL.Chk_Text(TxtBookType.AgSelectedValue) & ", " & _
                " " & AgL.Chk_Text(TxtBookName.Text) & " ," & AgL.Chk_Text(TxtPlace.Text) & "," & AgL.Chk_Text(TxtPublicationYear.Text) & "," & Val(TxtPages.Text) & " ," & Val(TXtRate.Text) & "   " & _
                " ) "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub ProcSaveCDItem(ByVal bWithCD As Boolean, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand)
        If bWithCD = True Then
            If TxtEntryType.Text = "Delete" Then
                mQry = " UPDATE Item " & _
                        " SET IsDeleted = 1 " & _
                        " WHERE Code= '" & mCDSearchCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            Else
                If mCDSearchCode <> "" Then
                    mQry = " UPDATE Item " & _
                            " SET ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & " + '-CD', " & _
                            " Description = " & AgL.Chk_Text(TxtDescription.Text) & " + '-CD', " & _
                            " EntryType = " & AgL.Chk_Text(TxtEntryType.Text) & " " & _
                            " WHERE Code= '" & mCDSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                Else
                    mCDSearchCode = AgL.GetMaxId("Item", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True)

                    mQry = " INSERT INTO Item (Code, ManualCode, Description,ItemType, " & _
                            " EntryBy, EntryDate, EntryType, ApproveBy, ApproveDate, Status,  " & _
                            " Div_Code) " & _
                            " VALUES ('" & mCDSearchCode & "'," & AgL.Chk_Text(TxtManualCode.Text) & " + '-CD' , " & AgL.Chk_Text(TxtDescription.Text) & " + '-CD'," & AgL.Chk_Text(ClsMain.ItemType.CD) & ", " & _
                            " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', " & AgL.Chk_Text(TxtEntryType.Text) & ",  " & _
                            " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', " & AgL.Chk_Text(ClsMain.LogStatus.LogOpen) & ", '" & AgL.PubDivCode & "') "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            End If

            mQry = " UPDATE Lib_Book_Log SET CD_ItemCode = " & AgL.Chk_Text(mCDSearchCode) & " " & _
                    " WHERE Code =" & AgL.Chk_Text(mInternalCode) & "  "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

            mQry = " UPDATE Lib_Book SET CD_ItemCode = " & AgL.Chk_Text(mCDSearchCode) & " " & _
                    " WHERE Code =" & AgL.Chk_Text(mInternalCode) & "  "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        Else
            mQry = " UPDATE Item " & _
                " SET IsDeleted = 1 " & _
                " WHERE Code= '" & mCDSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

            mQry = " UPDATE Lib_Book_Log SET CD_ItemCode = NULL " & _
                    " WHERE Code =" & AgL.Chk_Text(mInternalCode) & "  "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

            mQry = " UPDATE Lib_Book SET CD_ItemCode = NULL " & _
                    " WHERE Code =" & AgL.Chk_Text(mInternalCode) & "  "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Private Sub FrmDesignConsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Topctrl1.FButtonClick(0, False)
        If DtLib_Enviro.Rows.Count = 0 Then
            MsgBox("Fill Enviro", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub FrmOtherMaterial_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        Dgl1.Visible = False
        TxtUnit.Enabled = False
        TxtDescription.Enabled = False
        TxtWithCD.Text = "No"
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtDescription.Enter, TxtManualCode.Enter, TxtSubject.Enter
        Try
            Select Case sender.name
                Case TxtManualCode.Name, TxtDescription.Name
                    sender.AgRowFilter = " ItemType =  '" & ClsMain.ItemType.Book & "' And " & ClsMain.RetDivFilterStr & "  "
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmBook_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = " SELECT S.Code,S.Description AS Subject,S.Prefix,S.Div_Code,IsNull( S.IsDeleted,0) as IsDeleted, " & _
                 " ISNULL(S.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status  " & _
                 " FROM Lib_Subject S " & _
                 " Order By S.Description"
        TxtSubject.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)
        TxtUnderSubject.AgHelpDataSet(4) = TxtSubject.AgHelpDataSet

        mQry = " SELECT DISTINCT B.Writer  AS Code,B.Writer  FROM Lib_Book B WHERE B.Writer IS NOT NULL "
        TxtWriter.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT B.Publisher  AS Code,B.Publisher  FROM Lib_Book B WHERE B.Publisher IS NOT NULL "
        TxtPublisher.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT BT.Code,BT.Description AS [Book Type],BT.Suffix, " & _
           " isnull(BT.IsDeleted,0) AS IsDeleted,ISNULL(Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status,BT.Div_Code " & _
           " FROM Lib_BookType BT "
        TxtBookType.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT  H.BookDescription AS Code, H.BookDescription AS BookName  " & _
             " FROM Lib_Book H  " & _
             " WHERE H.BookDescription IS NOT NULL "
        TxtBookName.AgHelpDataSet() = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Distinct L.Place AS Code, L.Place  FROM Lib_AccessionHead L WHERE L.Place IS NOT NULL "
        TxtPlace.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT I.Code, I.Description , B.Writer, B.Publisher, S.Description As SubjectName, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                " B.Series, B.Subject, B.Volume, B.Language, B.ISBN, " & _
                " B.WithCD, B.GodownCD, B.GodownSectionCD, " & _
                " ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, " & _
                " I.Measure, i.MeasureUnit, B.Writer, B.Publisher, B.Series, B.WithCD, " & _
                " S.Prefix, B.CD_ItemCode As CdItemCode,b.BookType,b.PlaceOfPub,b.PubYear,b.pages,B.rate " & _
                " FROM Item I " & _
                " LEFT JOIN Lib_Book B ON I.Code = B.Code " & _
                " LEFT JOIN Lib_Subject S On B.Subject  = S.Code "
        TxtDescription.AgHelpDataSet(29) = AgL.FillData(mQry, AgL.GCn)

    End Sub

    Private Sub FrmBook_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainLineTableCsv = "Lib_Book"
        LogLineTableCsv = "Lib_Book_LOG"
        LblManualCode.Text = "Book Code"
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtSubject.Validating, TxtWithCD.Validating, TxtDescription.Validating, TxtVolume.Validating, TxtUnderSubject.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtSubject.Name
                    Call Validating_Controls(sender)

                Case TxtUnderSubject.Name
                    Call Validating_Controls(sender)

                Case TxtBookName.Name, TxtVolume.Name
                    TxtDescription.Text = TxtBookName.Text.ToString & " " & TxtVolume.Text.ToString

            End Select
            GetManualCode()
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub GetManualCode()
        If AgL.StrCmp(Topctrl1.Mode, "Edit") Then Exit Sub
        mQry = " SELECT isnull(max(B.BookCodeValue),0) +1 AS BookCodeValue " & _
                " FROM Lib_Book_Log B " & _
                " WHERE B.BookCodePrefix = " & AgL.Chk_Text(LblSubject.Tag) & " AND B.BookCodeSuffix = " & AgL.Chk_Text(LblBookType.Tag) & ""
        LblManualCode.Tag = AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar.ToString()
        TxtManualCode.Text = "" & LblSubject.Tag.ToString() & "" & LblManualCode.Tag & "" & LblBookType.Tag.ToString() & ""
    End Sub

    Private Sub Topctrl_tbAdd() Handles Topctrl1.tbAdd
        'TxtSubject.Focus()
        'TxtWithCD.Text = "No"
    End Sub

    Private Sub FrmBook_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        If DtLib_Enviro.Rows.Count > 0 Then
            TxtBookType.AgSelectedValue = AgL.XNull(DtLib_Enviro.Rows(0)("DefaultBookType"))
            TxtUnit.AgSelectedValue = AgL.XNull(DtLib_Enviro.Rows(0)("DefaultUnit"))
        End If
    End Sub

    Private Sub BtnOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnOk.Click, BtnCancel.Click
        Try
            Select Case sender.Name
                Case BtnOk.Name
                    If AgL.RequiredField(TxtSubject, LblSubject.Text) Then Exit Sub
                    Call Validating_Controls(TxtDescription)

                    If AgL.XNull(TxtDescription.AgSelectedValue).ToString.Trim = "" Then
                        Topctrl1.FButtonClick(13)
                        Topctrl1.FButtonClick(14, True)
                    End If

                    mIsOkButtonClick = True
                    Me.Close()

                Case BtnCancel.Name
                    Me.Close()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcSaveSubject(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

        Try
            If TxtSubject.Text <> "" And TxtSubject.AgSelectedValue = "" Then
                mSubjectSearchCode = AgL.GetGUID(AgL.GCn).ToString
                mSubjectInternalCode = AgL.GetMaxId("Lib_Subject_Log", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, , AgL.Gcn_ConnectionString)

                mQry = " INSERT INTO Lib_Subject_Log(UID, Code, Description, UnderSubject, Prefix, " & _
                        " EntryBy, EntryDate, EntryType, EntryStatus, Status, Div_Code ) " & _
                        " VALUES (" & AgL.Chk_Text(mSubjectSearchCode) & ", " & AgL.Chk_Text(mSubjectInternalCode) & ",  " & _
                        " " & AgL.Chk_Text(TxtSubject.Text) & ", " & AgL.Chk_Text(TxtUnderSubject.AgSelectedValue) & ", " & _
                        " " & AgL.Chk_Text(TxtPrefix.Text) & ", " & _
                        " " & AgL.Chk_Text(AgL.PubUserName) & ", " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ",  " & _
                        " " & AgL.Chk_Text(Topctrl1.Mode) & ", " & AgL.Chk_Text(LogStatus.LogOpen) & ",  " & _
                        " " & AgL.Chk_Text(TxtStatus.Text) & ", " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ") "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                mQry = " INSERT INTO Lib_Subject SELECT * FROM Lib_Subject_Log WHERE Code = '" & mSubjectInternalCode & "' "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmBookItemGenerate_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        If TxtWithCD.Text = "Yes" Then
            Call ProcSaveCDItem(True, Conn, Cmd)
        Else
            Call ProcSaveCDItem(False, Conn, Cmd)
        End If
    End Sub

    Public Function Validating_Controls(ByVal Sender As Object) As Boolean
        Dim DrTemp As DataRow() = Nothing

        Select Case Sender.Name
            Case TxtSubject.Name
                If AgL.XNull(Sender.text).ToString.Trim <> "" Or AgL.XNull(Sender.AgSelectedValue).ToString.Trim = "" Then
                    DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Subject = " & AgL.Chk_Text(Sender.Text) & "")
                    If DrTemp.Length > 0 Then
                        Sender.tag = AgL.XNull(DrTemp(0)("Code"))
                    Else
                        Sender.tag = ""
                    End If
                End If

                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    LblSubject.Tag = ""
                    LblSubjectReq.Tag = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        LblSubjectReq.Tag = TxtSubject.AgSelectedValue
                        LblSubject.Tag = AgL.XNull(DrTemp(0)("Prefix")).ToString
                    End If
                End If

            Case TxtUnderSubject.Name
                If AgL.XNull(Sender.text).ToString.Trim <> "" Or AgL.XNull(Sender.AgSelectedValue).ToString.Trim = "" Then
                    DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Subject = " & AgL.Chk_Text(Sender.Text) & "")
                    If DrTemp.Length > 0 Then
                        Sender.tag = AgL.XNull(DrTemp(0)("Code"))
                    Else
                        Sender.tag = ""
                    End If
                End If

                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    LblUnderSubject.Tag = ""
                    TxtPrefix.Text = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        LblUnderSubject.Tag = TxtUnderSubject.AgSelectedValue
                        TxtPrefix.Text = AgL.XNull(DrTemp(0)("Prefix")).ToString
                    End If
                End If

            Case TxtDescription.Name
                If AgL.XNull(Sender.text).ToString.Trim <> "" Or AgL.XNull(Sender.AgSelectedValue).ToString.Trim = "" Then
                    DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Description = " & AgL.Chk_Text(Sender.Text) & "")
                    If DrTemp.Length > 0 Then
                        Sender.tag = AgL.XNull(DrTemp(0)("Code"))
                    Else
                        Sender.tag = ""
                    End If
                End If

                If Sender.text.ToString.Trim = "" Or Sender.AgSelectedValue.Trim = "" Then
                    LblDescription.Tag = ""
                Else
                    If Sender.AgHelpDataSet IsNot Nothing Then
                        DrTemp = Sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(Sender.AgSelectedValue) & "")
                        LblDescription.Tag = TxtDescription.AgSelectedValue
                        mInternalCode = TxtDescription.AgSelectedValue
                    End If
                End If

        End Select

        Validating_Controls = True
    End Function
End Class
