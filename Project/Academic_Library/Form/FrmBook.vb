Public Class FrmBook
    Inherits AgTemplate.TempItem

    Dim mQry$ = ""
    Protected WithEvents TxtBookDescription As AgControls.AgTextBox
    Protected WithEvents LblBookDescription As System.Windows.Forms.Label

    Dim mCDSearchCode As String

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtWriter = New AgControls.AgTextBox
        Me.LblWriter = New System.Windows.Forms.Label
        Me.TxtPublisher = New AgControls.AgTextBox
        Me.LblPublisher = New System.Windows.Forms.Label
        Me.TxtSeries = New AgControls.AgTextBox
        Me.LblSeries = New System.Windows.Forms.Label
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubject = New System.Windows.Forms.Label
        Me.TxtVolume = New AgControls.AgTextBox
        Me.LblVolume = New System.Windows.Forms.Label
        Me.TxtLanguage = New AgControls.AgTextBox
        Me.LblLanguage = New System.Windows.Forms.Label
        Me.TxtISBN = New AgControls.AgTextBox
        Me.LblISBN = New System.Windows.Forms.Label
        Me.TxtBookType = New AgControls.AgTextBox
        Me.LblBookType = New System.Windows.Forms.Label
        Me.TxtSearchKeyWords = New AgControls.AgTextBox
        Me.LblSearchKeyWords = New System.Windows.Forms.Label
        Me.TxtCDAlmira = New AgControls.AgTextBox
        Me.LblCDAlmira = New System.Windows.Forms.Label
        Me.TxtCDShelf = New AgControls.AgTextBox
        Me.LblCDShelf = New System.Windows.Forms.Label
        Me.TxtWithCD = New AgControls.AgTextBox
        Me.LblWithCD = New System.Windows.Forms.Label
        Me.TxtAlmira = New AgControls.AgTextBox
        Me.LblAlmira = New System.Windows.Forms.Label
        Me.TxtShelf = New AgControls.AgTextBox
        Me.LblShelf = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.TxtScrapCategory = New AgControls.AgTextBox
        Me.LblScrapCategory = New System.Windows.Forms.Label
        Me.TxtBookDescription = New AgControls.AgTextBox
        Me.LblBookDescription = New System.Windows.Forms.Label
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
        Me.LblDescription.Location = New System.Drawing.Point(176, 110)
        '
        'TxtDescription
        '
        Me.TxtDescription.Location = New System.Drawing.Point(302, 109)
        Me.TxtDescription.MaxLength = 100
        Me.TxtDescription.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(286, 114)
        '
        'TxtUnit
        '
        Me.TxtUnit.Location = New System.Drawing.Point(17, 259)
        Me.TxtUnit.Size = New System.Drawing.Size(132, 18)
        Me.TxtUnit.TabIndex = 5
        Me.TxtUnit.Visible = False
        '
        'LblManualCodeReq
        '
        Me.LblManualCodeReq.Location = New System.Drawing.Point(773, 135)
        Me.LblManualCodeReq.Visible = False
        '
        'TxtManualCode
        '
        Me.TxtManualCode.AgMandatory = False
        Me.TxtManualCode.Location = New System.Drawing.Point(751, 146)
        Me.TxtManualCode.Size = New System.Drawing.Size(43, 18)
        Me.TxtManualCode.TabIndex = 2
        Me.TxtManualCode.Visible = False
        '
        'LblManualCode
        '
        Me.LblManualCode.Location = New System.Drawing.Point(748, 117)
        Me.LblManualCode.Visible = False
        '
        'TxtUPCCode
        '
        Me.TxtUPCCode.Location = New System.Drawing.Point(104, 118)
        Me.TxtUPCCode.Size = New System.Drawing.Size(46, 18)
        Me.TxtUPCCode.Visible = False
        '
        'LblUPCCode
        '
        Me.LblUPCCode.Location = New System.Drawing.Point(9, 121)
        Me.LblUPCCode.Visible = False
        '
        'TxtSalesTaxPostingGroup
        '
        Me.TxtSalesTaxPostingGroup.Location = New System.Drawing.Point(104, 71)
        Me.TxtSalesTaxPostingGroup.Size = New System.Drawing.Size(62, 18)
        Me.TxtSalesTaxPostingGroup.Visible = False
        '
        'LblSalesTaxPostingGroup
        '
        Me.LblSalesTaxPostingGroup.Location = New System.Drawing.Point(2, 72)
        Me.LblSalesTaxPostingGroup.Visible = False
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(12, 338)
        Me.Pnl1.Size = New System.Drawing.Size(120, 37)
        '
        'LblUnit
        '
        Me.LblUnit.Location = New System.Drawing.Point(27, 240)
        Me.LblUnit.Visible = False
        '
        'TxtItemGroup
        '
        Me.TxtItemGroup.Location = New System.Drawing.Point(85, 137)
        Me.TxtItemGroup.Size = New System.Drawing.Size(65, 18)
        Me.TxtItemGroup.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(4, 142)
        '
        'TxtExciseGroup
        '
        Me.TxtExciseGroup.Location = New System.Drawing.Point(104, 47)
        Me.TxtExciseGroup.Size = New System.Drawing.Size(62, 18)
        '
        'LblExciseGroup
        '
        Me.LblExciseGroup.Location = New System.Drawing.Point(11, 47)
        '
        'TxtEntryTaxGroup
        '
        Me.TxtEntryTaxGroup.Location = New System.Drawing.Point(122, 94)
        Me.TxtEntryTaxGroup.Size = New System.Drawing.Size(44, 18)
        '
        'LblEntryTaxGroup
        '
        Me.LblEntryTaxGroup.Location = New System.Drawing.Point(9, 95)
        '
        'Topctrl1
        '
        Me.Topctrl1.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 409)
        Me.GroupBox1.Size = New System.Drawing.Size(862, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(14, 419)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(148, 419)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(554, 419)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(401, 419)
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(704, 419)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(278, 419)
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
        Me.TxtWriter.Location = New System.Drawing.Point(302, 209)
        Me.TxtWriter.MaxLength = 100
        Me.TxtWriter.Name = "TxtWriter"
        Me.TxtWriter.Size = New System.Drawing.Size(385, 18)
        Me.TxtWriter.TabIndex = 9
        '
        'LblWriter
        '
        Me.LblWriter.AutoSize = True
        Me.LblWriter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWriter.Location = New System.Drawing.Point(176, 210)
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
        Me.TxtPublisher.Location = New System.Drawing.Point(302, 229)
        Me.TxtPublisher.MaxLength = 100
        Me.TxtPublisher.Name = "TxtPublisher"
        Me.TxtPublisher.Size = New System.Drawing.Size(385, 18)
        Me.TxtPublisher.TabIndex = 10
        '
        'LblPublisher
        '
        Me.LblPublisher.AutoSize = True
        Me.LblPublisher.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPublisher.Location = New System.Drawing.Point(176, 230)
        Me.LblPublisher.Name = "LblPublisher"
        Me.LblPublisher.Size = New System.Drawing.Size(62, 16)
        Me.LblPublisher.TabIndex = 864
        Me.LblPublisher.Text = "Publisher"
        '
        'TxtSeries
        '
        Me.TxtSeries.AgMandatory = False
        Me.TxtSeries.AgMasterHelp = True
        Me.TxtSeries.AgNumberLeftPlaces = 0
        Me.TxtSeries.AgNumberNegetiveAllow = False
        Me.TxtSeries.AgNumberRightPlaces = 0
        Me.TxtSeries.AgPickFromLastValue = False
        Me.TxtSeries.AgRowFilter = ""
        Me.TxtSeries.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSeries.AgSelectedValue = Nothing
        Me.TxtSeries.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSeries.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSeries.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSeries.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSeries.Location = New System.Drawing.Point(302, 129)
        Me.TxtSeries.MaxLength = 20
        Me.TxtSeries.Name = "TxtSeries"
        Me.TxtSeries.Size = New System.Drawing.Size(183, 18)
        Me.TxtSeries.TabIndex = 3
        '
        'LblSeries
        '
        Me.LblSeries.AutoSize = True
        Me.LblSeries.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSeries.Location = New System.Drawing.Point(176, 130)
        Me.LblSeries.Name = "LblSeries"
        Me.LblSeries.Size = New System.Drawing.Size(45, 16)
        Me.LblSeries.TabIndex = 870
        Me.LblSeries.Text = "Series"
        '
        'TxtSubject
        '
        Me.TxtSubject.AgMandatory = True
        Me.TxtSubject.AgMasterHelp = False
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
        Me.TxtSubject.Location = New System.Drawing.Point(302, 69)
        Me.TxtSubject.MaxLength = 100
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(385, 18)
        Me.TxtSubject.TabIndex = 0
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(176, 70)
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
        Me.TxtVolume.Location = New System.Drawing.Point(555, 129)
        Me.TxtVolume.MaxLength = 5
        Me.TxtVolume.Name = "TxtVolume"
        Me.TxtVolume.Size = New System.Drawing.Size(132, 18)
        Me.TxtVolume.TabIndex = 4
        '
        'LblVolume
        '
        Me.LblVolume.AutoSize = True
        Me.LblVolume.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVolume.Location = New System.Drawing.Point(490, 130)
        Me.LblVolume.Name = "LblVolume"
        Me.LblVolume.Size = New System.Drawing.Size(52, 16)
        Me.LblVolume.TabIndex = 874
        Me.LblVolume.Text = "Volume"
        '
        'TxtLanguage
        '
        Me.TxtLanguage.AgMandatory = False
        Me.TxtLanguage.AgMasterHelp = True
        Me.TxtLanguage.AgNumberLeftPlaces = 8
        Me.TxtLanguage.AgNumberNegetiveAllow = False
        Me.TxtLanguage.AgNumberRightPlaces = 2
        Me.TxtLanguage.AgPickFromLastValue = False
        Me.TxtLanguage.AgRowFilter = ""
        Me.TxtLanguage.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLanguage.AgSelectedValue = Nothing
        Me.TxtLanguage.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLanguage.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtLanguage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLanguage.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLanguage.Location = New System.Drawing.Point(555, 169)
        Me.TxtLanguage.MaxLength = 50
        Me.TxtLanguage.Name = "TxtLanguage"
        Me.TxtLanguage.Size = New System.Drawing.Size(132, 18)
        Me.TxtLanguage.TabIndex = 7
        '
        'LblLanguage
        '
        Me.LblLanguage.AutoSize = True
        Me.LblLanguage.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLanguage.Location = New System.Drawing.Point(490, 169)
        Me.LblLanguage.Name = "LblLanguage"
        Me.LblLanguage.Size = New System.Drawing.Size(64, 16)
        Me.LblLanguage.TabIndex = 873
        Me.LblLanguage.Text = "Language"
        '
        'TxtISBN
        '
        Me.TxtISBN.AgMandatory = False
        Me.TxtISBN.AgMasterHelp = True
        Me.TxtISBN.AgNumberLeftPlaces = 0
        Me.TxtISBN.AgNumberNegetiveAllow = False
        Me.TxtISBN.AgNumberRightPlaces = 0
        Me.TxtISBN.AgPickFromLastValue = False
        Me.TxtISBN.AgRowFilter = ""
        Me.TxtISBN.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtISBN.AgSelectedValue = Nothing
        Me.TxtISBN.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtISBN.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtISBN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtISBN.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtISBN.Location = New System.Drawing.Point(302, 169)
        Me.TxtISBN.MaxLength = 20
        Me.TxtISBN.Name = "TxtISBN"
        Me.TxtISBN.Size = New System.Drawing.Size(183, 18)
        Me.TxtISBN.TabIndex = 6
        '
        'LblISBN
        '
        Me.LblISBN.AutoSize = True
        Me.LblISBN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblISBN.Location = New System.Drawing.Point(176, 170)
        Me.LblISBN.Name = "LblISBN"
        Me.LblISBN.Size = New System.Drawing.Size(38, 16)
        Me.LblISBN.TabIndex = 878
        Me.LblISBN.Text = "ISBN"
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
        Me.TxtBookType.Location = New System.Drawing.Point(302, 89)
        Me.TxtBookType.MaxLength = 100
        Me.TxtBookType.Name = "TxtBookType"
        Me.TxtBookType.Size = New System.Drawing.Size(385, 18)
        Me.TxtBookType.TabIndex = 1
        '
        'LblBookType
        '
        Me.LblBookType.AutoSize = True
        Me.LblBookType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBookType.Location = New System.Drawing.Point(176, 90)
        Me.LblBookType.Name = "LblBookType"
        Me.LblBookType.Size = New System.Drawing.Size(66, 16)
        Me.LblBookType.TabIndex = 877
        Me.LblBookType.Text = "BookType"
        '
        'TxtSearchKeyWords
        '
        Me.TxtSearchKeyWords.AgMandatory = False
        Me.TxtSearchKeyWords.AgMasterHelp = True
        Me.TxtSearchKeyWords.AgNumberLeftPlaces = 8
        Me.TxtSearchKeyWords.AgNumberNegetiveAllow = False
        Me.TxtSearchKeyWords.AgNumberRightPlaces = 2
        Me.TxtSearchKeyWords.AgPickFromLastValue = False
        Me.TxtSearchKeyWords.AgRowFilter = ""
        Me.TxtSearchKeyWords.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSearchKeyWords.AgSelectedValue = Nothing
        Me.TxtSearchKeyWords.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSearchKeyWords.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSearchKeyWords.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSearchKeyWords.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearchKeyWords.Location = New System.Drawing.Point(302, 249)
        Me.TxtSearchKeyWords.MaxLength = 0
        Me.TxtSearchKeyWords.Multiline = True
        Me.TxtSearchKeyWords.Name = "TxtSearchKeyWords"
        Me.TxtSearchKeyWords.Size = New System.Drawing.Size(385, 62)
        Me.TxtSearchKeyWords.TabIndex = 11
        '
        'LblSearchKeyWords
        '
        Me.LblSearchKeyWords.AutoSize = True
        Me.LblSearchKeyWords.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSearchKeyWords.Location = New System.Drawing.Point(176, 250)
        Me.LblSearchKeyWords.Name = "LblSearchKeyWords"
        Me.LblSearchKeyWords.Size = New System.Drawing.Size(118, 16)
        Me.LblSearchKeyWords.TabIndex = 880
        Me.LblSearchKeyWords.Text = "Search Key Words"
        '
        'TxtCDAlmira
        '
        Me.TxtCDAlmira.AgMandatory = False
        Me.TxtCDAlmira.AgMasterHelp = False
        Me.TxtCDAlmira.AgNumberLeftPlaces = 0
        Me.TxtCDAlmira.AgNumberNegetiveAllow = False
        Me.TxtCDAlmira.AgNumberRightPlaces = 0
        Me.TxtCDAlmira.AgPickFromLastValue = False
        Me.TxtCDAlmira.AgRowFilter = ""
        Me.TxtCDAlmira.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCDAlmira.AgSelectedValue = Nothing
        Me.TxtCDAlmira.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCDAlmira.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCDAlmira.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCDAlmira.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCDAlmira.Location = New System.Drawing.Point(437, 333)
        Me.TxtCDAlmira.MaxLength = 20
        Me.TxtCDAlmira.Name = "TxtCDAlmira"
        Me.TxtCDAlmira.Size = New System.Drawing.Size(90, 18)
        Me.TxtCDAlmira.TabIndex = 15
        '
        'LblCDAlmira
        '
        Me.LblCDAlmira.AutoSize = True
        Me.LblCDAlmira.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCDAlmira.Location = New System.Drawing.Point(364, 334)
        Me.LblCDAlmira.Name = "LblCDAlmira"
        Me.LblCDAlmira.Size = New System.Drawing.Size(67, 16)
        Me.LblCDAlmira.TabIndex = 884
        Me.LblCDAlmira.Text = "CD Almira"
        '
        'TxtCDShelf
        '
        Me.TxtCDShelf.AgMandatory = False
        Me.TxtCDShelf.AgMasterHelp = False
        Me.TxtCDShelf.AgNumberLeftPlaces = 8
        Me.TxtCDShelf.AgNumberNegetiveAllow = False
        Me.TxtCDShelf.AgNumberRightPlaces = 2
        Me.TxtCDShelf.AgPickFromLastValue = False
        Me.TxtCDShelf.AgRowFilter = ""
        Me.TxtCDShelf.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCDShelf.AgSelectedValue = Nothing
        Me.TxtCDShelf.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCDShelf.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCDShelf.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCDShelf.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCDShelf.Location = New System.Drawing.Point(597, 333)
        Me.TxtCDShelf.MaxLength = 100
        Me.TxtCDShelf.Name = "TxtCDShelf"
        Me.TxtCDShelf.Size = New System.Drawing.Size(90, 18)
        Me.TxtCDShelf.TabIndex = 16
        '
        'LblCDShelf
        '
        Me.LblCDShelf.AutoSize = True
        Me.LblCDShelf.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCDShelf.Location = New System.Drawing.Point(533, 334)
        Me.LblCDShelf.Name = "LblCDShelf"
        Me.LblCDShelf.Size = New System.Drawing.Size(59, 16)
        Me.LblCDShelf.TabIndex = 883
        Me.LblCDShelf.Text = "CD Shelf"
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
        Me.TxtWithCD.Location = New System.Drawing.Point(302, 333)
        Me.TxtWithCD.MaxLength = 100
        Me.TxtWithCD.Name = "TxtWithCD"
        Me.TxtWithCD.Size = New System.Drawing.Size(56, 18)
        Me.TxtWithCD.TabIndex = 14
        '
        'LblWithCD
        '
        Me.LblWithCD.AutoSize = True
        Me.LblWithCD.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWithCD.Location = New System.Drawing.Point(176, 334)
        Me.LblWithCD.Name = "LblWithCD"
        Me.LblWithCD.Size = New System.Drawing.Size(57, 16)
        Me.LblWithCD.TabIndex = 886
        Me.LblWithCD.Text = "With CD"
        '
        'TxtAlmira
        '
        Me.TxtAlmira.AgMandatory = False
        Me.TxtAlmira.AgMasterHelp = False
        Me.TxtAlmira.AgNumberLeftPlaces = 0
        Me.TxtAlmira.AgNumberNegetiveAllow = False
        Me.TxtAlmira.AgNumberRightPlaces = 0
        Me.TxtAlmira.AgPickFromLastValue = False
        Me.TxtAlmira.AgRowFilter = ""
        Me.TxtAlmira.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAlmira.AgSelectedValue = Nothing
        Me.TxtAlmira.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAlmira.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAlmira.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAlmira.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAlmira.Location = New System.Drawing.Point(302, 313)
        Me.TxtAlmira.MaxLength = 20
        Me.TxtAlmira.Name = "TxtAlmira"
        Me.TxtAlmira.Size = New System.Drawing.Size(225, 18)
        Me.TxtAlmira.TabIndex = 12
        '
        'LblAlmira
        '
        Me.LblAlmira.AutoSize = True
        Me.LblAlmira.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAlmira.Location = New System.Drawing.Point(176, 314)
        Me.LblAlmira.Name = "LblAlmira"
        Me.LblAlmira.Size = New System.Drawing.Size(45, 16)
        Me.LblAlmira.TabIndex = 890
        Me.LblAlmira.Text = "Almira"
        '
        'TxtShelf
        '
        Me.TxtShelf.AgMandatory = False
        Me.TxtShelf.AgMasterHelp = False
        Me.TxtShelf.AgNumberLeftPlaces = 8
        Me.TxtShelf.AgNumberNegetiveAllow = False
        Me.TxtShelf.AgNumberRightPlaces = 2
        Me.TxtShelf.AgPickFromLastValue = False
        Me.TxtShelf.AgRowFilter = ""
        Me.TxtShelf.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtShelf.AgSelectedValue = Nothing
        Me.TxtShelf.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtShelf.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtShelf.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtShelf.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtShelf.Location = New System.Drawing.Point(597, 313)
        Me.TxtShelf.MaxLength = 100
        Me.TxtShelf.Name = "TxtShelf"
        Me.TxtShelf.Size = New System.Drawing.Size(90, 18)
        Me.TxtShelf.TabIndex = 13
        '
        'LblShelf
        '
        Me.LblShelf.AutoSize = True
        Me.LblShelf.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblShelf.Location = New System.Drawing.Point(532, 314)
        Me.LblShelf.Name = "LblShelf"
        Me.LblShelf.Size = New System.Drawing.Size(37, 16)
        Me.LblShelf.TabIndex = 889
        Me.LblShelf.Text = "Shelf"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(286, 77)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 896
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'TxtScrapCategory
        '
        Me.TxtScrapCategory.AgMandatory = False
        Me.TxtScrapCategory.AgMasterHelp = False
        Me.TxtScrapCategory.AgNumberLeftPlaces = 0
        Me.TxtScrapCategory.AgNumberNegetiveAllow = False
        Me.TxtScrapCategory.AgNumberRightPlaces = 0
        Me.TxtScrapCategory.AgPickFromLastValue = False
        Me.TxtScrapCategory.AgRowFilter = ""
        Me.TxtScrapCategory.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtScrapCategory.AgSelectedValue = Nothing
        Me.TxtScrapCategory.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtScrapCategory.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtScrapCategory.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtScrapCategory.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtScrapCategory.Location = New System.Drawing.Point(302, 189)
        Me.TxtScrapCategory.MaxLength = 20
        Me.TxtScrapCategory.Name = "TxtScrapCategory"
        Me.TxtScrapCategory.Size = New System.Drawing.Size(385, 18)
        Me.TxtScrapCategory.TabIndex = 8
        '
        'LblScrapCategory
        '
        Me.LblScrapCategory.AutoSize = True
        Me.LblScrapCategory.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblScrapCategory.Location = New System.Drawing.Point(176, 190)
        Me.LblScrapCategory.Name = "LblScrapCategory"
        Me.LblScrapCategory.Size = New System.Drawing.Size(98, 16)
        Me.LblScrapCategory.TabIndex = 898
        Me.LblScrapCategory.Text = "Scrap Category"
        '
        'TxtBookDescription
        '
        Me.TxtBookDescription.AgMandatory = False
        Me.TxtBookDescription.AgMasterHelp = True
        Me.TxtBookDescription.AgNumberLeftPlaces = 0
        Me.TxtBookDescription.AgNumberNegetiveAllow = False
        Me.TxtBookDescription.AgNumberRightPlaces = 0
        Me.TxtBookDescription.AgPickFromLastValue = False
        Me.TxtBookDescription.AgRowFilter = ""
        Me.TxtBookDescription.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBookDescription.AgSelectedValue = Nothing
        Me.TxtBookDescription.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBookDescription.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBookDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBookDescription.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBookDescription.Location = New System.Drawing.Point(302, 149)
        Me.TxtBookDescription.MaxLength = 20
        Me.TxtBookDescription.Name = "TxtBookDescription"
        Me.TxtBookDescription.Size = New System.Drawing.Size(385, 18)
        Me.TxtBookDescription.TabIndex = 5
        '
        'LblBookDescription
        '
        Me.LblBookDescription.AutoSize = True
        Me.LblBookDescription.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBookDescription.Location = New System.Drawing.Point(176, 150)
        Me.LblBookDescription.Name = "LblBookDescription"
        Me.LblBookDescription.Size = New System.Drawing.Size(107, 16)
        Me.LblBookDescription.TabIndex = 900
        Me.LblBookDescription.Text = "Book Description"
        '
        'FrmBook
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 466)
        Me.Controls.Add(Me.TxtBookDescription)
        Me.Controls.Add(Me.LblBookDescription)
        Me.Controls.Add(Me.TxtScrapCategory)
        Me.Controls.Add(Me.LblScrapCategory)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.TxtAlmira)
        Me.Controls.Add(Me.LblAlmira)
        Me.Controls.Add(Me.TxtShelf)
        Me.Controls.Add(Me.LblShelf)
        Me.Controls.Add(Me.TxtWithCD)
        Me.Controls.Add(Me.LblWithCD)
        Me.Controls.Add(Me.TxtCDAlmira)
        Me.Controls.Add(Me.LblCDAlmira)
        Me.Controls.Add(Me.TxtCDShelf)
        Me.Controls.Add(Me.LblCDShelf)
        Me.Controls.Add(Me.TxtSearchKeyWords)
        Me.Controls.Add(Me.LblSearchKeyWords)
        Me.Controls.Add(Me.TxtISBN)
        Me.Controls.Add(Me.LblISBN)
        Me.Controls.Add(Me.TxtBookType)
        Me.Controls.Add(Me.LblBookType)
        Me.Controls.Add(Me.TxtVolume)
        Me.Controls.Add(Me.LblVolume)
        Me.Controls.Add(Me.TxtLanguage)
        Me.Controls.Add(Me.LblLanguage)
        Me.Controls.Add(Me.TxtSeries)
        Me.Controls.Add(Me.LblSeries)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.LblSubject)
        Me.Controls.Add(Me.TxtWriter)
        Me.Controls.Add(Me.LblWriter)
        Me.Controls.Add(Me.TxtPublisher)
        Me.Controls.Add(Me.LblPublisher)
        Me.LogLineTableCsv = "ItemBuyer_Log"
        Me.LogTableName = "Item_LOG"
        Me.MainLineTableCsv = "ItemBuyer"
        Me.MainTableName = "Item"
        Me.Name = "FrmBook"
        Me.Text = "Other Material Master"
        Me.Controls.SetChildIndex(Me.LblPublisher, 0)
        Me.Controls.SetChildIndex(Me.TxtPublisher, 0)
        Me.Controls.SetChildIndex(Me.LblWriter, 0)
        Me.Controls.SetChildIndex(Me.TxtWriter, 0)
        Me.Controls.SetChildIndex(Me.LblSubject, 0)
        Me.Controls.SetChildIndex(Me.TxtSubject, 0)
        Me.Controls.SetChildIndex(Me.LblSeries, 0)
        Me.Controls.SetChildIndex(Me.TxtSeries, 0)
        Me.Controls.SetChildIndex(Me.LblLanguage, 0)
        Me.Controls.SetChildIndex(Me.TxtLanguage, 0)
        Me.Controls.SetChildIndex(Me.LblVolume, 0)
        Me.Controls.SetChildIndex(Me.TxtVolume, 0)
        Me.Controls.SetChildIndex(Me.LblBookType, 0)
        Me.Controls.SetChildIndex(Me.TxtBookType, 0)
        Me.Controls.SetChildIndex(Me.LblISBN, 0)
        Me.Controls.SetChildIndex(Me.TxtISBN, 0)
        Me.Controls.SetChildIndex(Me.LblSearchKeyWords, 0)
        Me.Controls.SetChildIndex(Me.TxtSearchKeyWords, 0)
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
        Me.Controls.SetChildIndex(Me.Label1, 0)
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
        Me.Controls.SetChildIndex(Me.LblCDShelf, 0)
        Me.Controls.SetChildIndex(Me.TxtCDShelf, 0)
        Me.Controls.SetChildIndex(Me.LblCDAlmira, 0)
        Me.Controls.SetChildIndex(Me.TxtCDAlmira, 0)
        Me.Controls.SetChildIndex(Me.LblWithCD, 0)
        Me.Controls.SetChildIndex(Me.TxtWithCD, 0)
        Me.Controls.SetChildIndex(Me.LblShelf, 0)
        Me.Controls.SetChildIndex(Me.TxtShelf, 0)
        Me.Controls.SetChildIndex(Me.LblAlmira, 0)
        Me.Controls.SetChildIndex(Me.TxtAlmira, 0)
        Me.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.Controls.SetChildIndex(Me.LblScrapCategory, 0)
        Me.Controls.SetChildIndex(Me.TxtScrapCategory, 0)
        Me.Controls.SetChildIndex(Me.LblBookDescription, 0)
        Me.Controls.SetChildIndex(Me.TxtBookDescription, 0)
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
    Protected WithEvents TxtSeries As AgControls.AgTextBox
    Protected WithEvents LblSeries As System.Windows.Forms.Label
    Protected WithEvents TxtSubject As AgControls.AgTextBox
    Protected WithEvents LblSubject As System.Windows.Forms.Label
    Protected WithEvents TxtVolume As AgControls.AgTextBox
    Protected WithEvents LblVolume As System.Windows.Forms.Label
    Protected WithEvents TxtLanguage As AgControls.AgTextBox
    Protected WithEvents LblLanguage As System.Windows.Forms.Label
    Protected WithEvents TxtISBN As AgControls.AgTextBox
    Protected WithEvents LblISBN As System.Windows.Forms.Label
    Protected WithEvents TxtBookType As AgControls.AgTextBox
    Protected WithEvents LblBookType As System.Windows.Forms.Label
    Protected WithEvents TxtSearchKeyWords As AgControls.AgTextBox
    Protected WithEvents LblSearchKeyWords As System.Windows.Forms.Label
    Protected WithEvents TxtCDAlmira As AgControls.AgTextBox
    Protected WithEvents LblCDAlmira As System.Windows.Forms.Label
    Protected WithEvents TxtCDShelf As AgControls.AgTextBox
    Protected WithEvents LblCDShelf As System.Windows.Forms.Label
    Protected WithEvents TxtWithCD As AgControls.AgTextBox
    Protected WithEvents LblWithCD As System.Windows.Forms.Label
    Protected WithEvents TxtPublisher As AgControls.AgTextBox
    Protected WithEvents LblWriter As System.Windows.Forms.Label
    Protected WithEvents TxtWriter As AgControls.AgTextBox
    Protected WithEvents TxtAlmira As AgControls.AgTextBox
    Protected WithEvents LblAlmira As System.Windows.Forms.Label
    Protected WithEvents TxtShelf As AgControls.AgTextBox
    Protected WithEvents LblShelf As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Protected WithEvents TxtScrapCategory As AgControls.AgTextBox
    Protected WithEvents LblScrapCategory As System.Windows.Forms.Label
#End Region

    Private Sub FrmBook_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        If TxtWithCD.Text = "Yes" Then
            Call ProcSaveCDItem(True, Conn, Cmd)
        Else
            Call ProcSaveCDItem(False, Conn, Cmd)
        End If
    End Sub

    Private Sub FrmBook_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        TxtManualCode.Text = mInternalCode

        If AgL.RequiredField(TxtManualCode, LblManualCode.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtSubject, LblSubject.Text) Then passed = False : Exit Sub

        If TxtWithCD.Text = "No" Then
            TxtCDAlmira.Text = "" : TxtCDAlmira.AgSelectedValue = "" : TxtCDShelf.Text = ""
        End If

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

    Public Overrides Sub FrmYarn_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Book & "'  " & AgL.RetDivisionCondition(AgL, "I.Div_Code") & " "
        AgL.PubFindQry = "SELECT I.UID, S.Description AS Subject,BT.Description AS [Book Type], " & _
                        " I.ManualCode as [Book Code], " & _
                        " I.Description [Book Name], " & _
                        " B.Series, B.Volume, B.ISBN, B.Language, Sc.Description As ScrapCategory, " & _
                        " B.Writer, B.Publisher, " & _
                        " B.SearchKeyWords AS [Search Key Words], " & _
                        " G.Description As Almira, I.GodownSection As Shelf, " & _
                        " Case When IsNull(B.WithCd,0) = 0 Then 'No' Else 'Yes' End As WithCD, " & _
                        " G1.Description As [Cd Almira], B.GodownSectionCD As [CD Shelf] " & _
                        " FROM Item_Log I " & _
                        " LEFT JOIN Lib_Book_Log B ON B.UID=I.UID " & _
                        " LEFT JOIN Lib_BookType BT ON BT.Code=B.BookType " & _
                        " LEFT JOIN Lib_Subject S ON S.Code=B.Subject " & _
                        " LEFT JOIN Lib_ScrapCategory Sc On B.ScrapCategory = Sc.Code  " & _
                        " LEFT JOIN Godown G On I.Godown = G.Code " & _
                        " LEFT JOIN Godown G1 On B.GodownCD = G1.Code " & mConStr & _
                        " And I.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'  "
        AgL.PubFindQryOrdBy = "[Book Name]"
    End Sub

    Public Overrides Sub FrmYarn_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        mConStr = "WHERE 1=1 And I.ItemType = '" & ClsMain.ItemType.Book & "'  " & AgL.RetDivisionCondition(AgL, "I.Div_Code") & " "
        AgL.PubFindQry = "SELECT I.Code, I.ManualCode as [Book Code], I.Description [Book Description], " & _
                        " I.Unit,BL.Writer ,BL.Publisher,BL.Series ,S.Description AS Subject, " & _
                        " BL.Volume,BL.Language,BL.ISBN,BT.Description AS [Book Type],BL.SearchKeyWords AS [Search Key Words]" & _
                        " FROM Item I " & _
                        " LEFT JOIN Lib_Book BL ON BL.Code=I.Code " & _
                        " LEFT JOIN Lib_BookType BT ON BT.Code=BL.BookType " & _
                        " LEFT JOIN Lib_Subject S ON S.Code=BL.Subject  " & mConStr & _
                        " And IsNull(I.IsDeleted,0)=0 "
        AgL.PubFindQryOrdBy = "[Book Description]"
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

    Private Sub FrmYarn_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "UPDATE Item_Log " & _
                " SET " & _
                " ItemType = " & AgL.Chk_Text(ClsMain.ItemType.Book) & " , " & _
                " Godown = " & AgL.Chk_Text(TxtAlmira.AgSelectedValue) & " , " & _
                " GodownSection = " & AgL.Chk_Text(TxtShelf.Text) & "  " & _
                " Where UID = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        If Topctrl1.Mode = "Add" Then
            mQry = " INSERT INTO Lib_Book_Log(	Code,	Writer,	Publisher,	Series,	Subject,	Volume,	Language, ScrapCategory," & _
                    " ISBN,	BookType,	SearchKeyWords,	WithCD,	GodownCD,	GodownSectionCD,	UID	,BookCodeValue,	BookCodePrefix,	BookCodeSuffix, BookDescription) " & _
                    " VALUES 	( '" & mInternalCode & "'," & AgL.Chk_Text(TxtWriter.Text) & ",	" & AgL.Chk_Text(TxtPublisher.Text) & "," & AgL.Chk_Text(TxtSeries.Text) & ",	" & AgL.Chk_Text(TxtSubject.AgSelectedValue) & "," & AgL.Chk_Text(TxtVolume.Text) & ", " & _
                    " " & AgL.Chk_Text(TxtLanguage.Text) & "," & AgL.Chk_Text(TxtScrapCategory.AgSelectedValue) & "," & AgL.Chk_Text(TxtISBN.Text) & "," & AgL.Chk_Text(TxtBookType.AgSelectedValue) & ",	" & AgL.Chk_Text(TxtSearchKeyWords.Text) & ", " & _
                    " " & IIf(TxtWithCD.Text = "Yes", 1, 0) & "," & AgL.Chk_Text(TxtCDAlmira.AgSelectedValue) & "," & AgL.Chk_Text(TxtCDShelf.Text) & ",'" & SearchCode & "', " & _
                    " " & Val(LblManualCode.Tag) & " ," & AgL.Chk_Text(LblSubject.Tag) & "," & AgL.Chk_Text(LblBookType.Tag) & "," & AgL.Chk_Text(TxtBookDescription.Text) & ")"
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
        Else
            mQry = " UPDATE Lib_Book_Log " & _
                     " SET Code = '" & mInternalCode & "', " & _
                     " Writer = " & AgL.Chk_Text(TxtWriter.Text) & ", " & _
                     " BookCodeValue = " & Val(LblManualCode.Tag) & ", " & _
                     " BookCodePrefix = " & AgL.Chk_Text(LblSubject.Tag) & ", " & _
                     " BookCodeSuffix = " & AgL.Chk_Text(LblBookType.Tag) & ", " & _
                     " Publisher = " & AgL.Chk_Text(TxtPublisher.Text) & ", " & _
                     " Series = " & AgL.Chk_Text(TxtSeries.Text) & ", " & _
                     " Subject = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & ", " & _
                     " Volume = " & AgL.Chk_Text(TxtVolume.Text) & ", " & _
                     " Language = " & AgL.Chk_Text(TxtLanguage.Text) & ", " & _
                     " ISBN = " & AgL.Chk_Text(TxtISBN.Text) & ", " & _
                     " BookType = " & AgL.Chk_Text(TxtBookType.AgSelectedValue) & ", " & _
                     " ScrapCategory = " & AgL.Chk_Text(TxtScrapCategory.AgSelectedValue) & ", " & _
                     " SearchKeyWords = " & AgL.Chk_Text(TxtSearchKeyWords.Text) & ", " & _
                     " BookDescription = " & AgL.Chk_Text(TxtBookDescription.Text) & ", " & _
                     " WithCD = " & IIf(TxtWithCD.Text = "Yes", 1, 0) & ", " & _
                     " GodownCD = " & AgL.Chk_Text(TxtCDAlmira.AgSelectedValue) & ", " & _
                     " GodownSectionCD = " & AgL.Chk_Text(TxtCDShelf.Text) & " " & _
                     " WHERE 	UID ='" & SearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
        End If

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
                    'mQry = "SELECT COUNT(*) FROM Item With (NoLock) WHERE Description='" & TxtDescription.Text & "' + '-CD' And Code<>'" & mCDSearchCode & "' "
                    'AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GcnRead)
                    'If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("CD Description Already Exist!") : TxtDescription.Focus() : Exit Sub

                    mQry = " UPDATE Item " & _
                            " SET ManualCode = " & AgL.Chk_Text(TxtManualCode.Text) & " + '-CD', " & _
                            " Description = " & AgL.Chk_Text(TxtDescription.Text) & " + '-CD', " & _
                            " Godown = " & AgL.Chk_Text(TxtCDAlmira.AgSelectedValue) & ", " & _
                            " GodownSection = " & AgL.Chk_Text(TxtCDShelf.AgSelectedValue) & ", " & _
                            " EntryType = " & AgL.Chk_Text(TxtEntryType.Text) & " " & _
                            " WHERE Code= '" & mCDSearchCode & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                Else
                    'AgL.ECmd = AgL.Dman_Execute("SELECT COUNT(*) FROM Item With (NoLock) WHERE Description='" & TxtDescription.Text & "' + '-CD' ", AgL.GcnRead)
                    'If AgL.ECmd.ExecuteScalar() > 0 Then MsgBox("CD Description Already Exist!") : TxtDescription.Focus() : Exit Sub

                    mCDSearchCode = AgL.GetMaxId("Item", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True)

                    mQry = " INSERT INTO Item (Code, ManualCode, Description,ItemType, " & _
                            " EntryBy, EntryDate, EntryType, ApproveBy, ApproveDate, Status,  " & _
                            " Div_Code, Godown, GodownSection) " & _
                            " VALUES ('" & mCDSearchCode & "'," & AgL.Chk_Text(TxtManualCode.Text) & " + '-CD' , " & AgL.Chk_Text(TxtDescription.Text) & " + '-CD'," & AgL.Chk_Text(ClsMain.ItemType.CD) & ", " & _
                            " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', " & AgL.Chk_Text(TxtEntryType.Text) & ",  " & _
                            " '" & AgL.PubUserName & "', '" & Format(AgL.PubLoginDate, "Short Date") & "', " & AgL.Chk_Text(ClsMain.LogStatus.LogOpen) & ", '" & AgL.PubDivCode & "',  " & _
                            " " & AgL.Chk_Text(TxtCDAlmira.AgSelectedValue) & ", " & AgL.Chk_Text(TxtCDShelf.Text) & " ) "
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
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmDesignConsumption_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AgL.WinSetting(Me, 500, 870, 0, 0)

        If DtLib_Enviro.Rows.Count = 0 Then
            MsgBox("Fill Enviro", MsgBoxStyle.Information)
        End If
        TxtBookDescription.MaxLength = 100
    End Sub

    Private Sub FrmOtherMaterial_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        Dgl1.Visible = False
        TxtUnit.Enabled = False
        TxtBookDescription.Enabled = False
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    TxtDescription.Enter, TxtManualCode.Enter, TxtCDShelf.Enter, TxtCDAlmira.Enter, TxtAlmira.Enter, TxtShelf.Enter, TxtSubject.Enter, TxtBookType.Enter
        Try
            Select Case sender.name
                Case TxtManualCode.Name, TxtDescription.Name
                    sender.AgRowFilter = " ItemType =  '" & ClsMain.ItemType.Book & "' And " & ClsMain.RetDivFilterStr & "  "

                Case TxtCDShelf.Name
                    If TxtCDAlmira.AgSelectedValue <> "" Then
                        sender.AgRowFilter = " GodownCode = " & AgL.Chk_Text(TxtCDAlmira.AgSelectedValue) & " "
                    End If

                Case TxtShelf.Name
                    If TxtAlmira.AgSelectedValue <> "" Then
                        sender.AgRowFilter = " GodownCode = " & AgL.Chk_Text(TxtAlmira.AgSelectedValue) & " "
                    End If

                Case TxtBookType.Name, TxtSubject.Name, TxtCDAlmira.Name, TxtAlmira.Name, TxtScrapCategory.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND " & ClsMain.RetDivFilterStr & ""
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmOtherMaterial_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec

        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = " SELECT B.* ,I.Godown ,I.GodownSection " & _
                    " FROM Lib_Book B " & _
                    " LEFT JOIN Item I ON I.Code=B.Code " & _
                    " Where B.Code='" & SearchCode & "' "
        Else
            mQry = " SELECT BL.* ,IL.Godown ,IL.GodownSection " & _
                    " FROM Lib_Book_Log BL " & _
                    " LEFT JOIN Item_Log IL ON BL.UID=IL.UID " & _
                    " Where BL.UID='" & SearchCode & "' "
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))
                TxtWriter.Text = AgL.XNull(.Rows(0)("Writer"))

                LblManualCode.Tag = AgL.VNull(.Rows(0)("BookCodeValue"))
                LblSubject.Tag = AgL.XNull(.Rows(0)("BookCodePrefix"))
                LblBookType.Tag = AgL.XNull(.Rows(0)("BookCodeSuffix"))

                TxtPublisher.Text = AgL.XNull(.Rows(0)("Publisher"))
                TxtSeries.Text = AgL.XNull(.Rows(0)("Series"))
                TxtSubject.AgSelectedValue = AgL.XNull(.Rows(0)("Subject"))
                TxtVolume.Text = AgL.XNull(.Rows(0)("Volume"))
                TxtLanguage.Text = AgL.XNull(.Rows(0)("Language"))
                TxtISBN.Text = AgL.XNull(.Rows(0)("ISBN"))
                TxtBookType.AgSelectedValue = AgL.XNull(.Rows(0)("BookType"))
                TxtScrapCategory.AgSelectedValue = AgL.XNull(.Rows(0)("ScrapCategory"))
                TxtSearchKeyWords.Text = AgL.XNull(.Rows(0)("SearchKeyWords"))
                TxtCDAlmira.AgSelectedValue = AgL.XNull(.Rows(0)("GodownCD"))
                TxtCDShelf.Text = AgL.XNull(.Rows(0)("GodownSectionCD"))
                TxtWithCD.Text = IIf(AgL.VNull(.Rows(0)("WithCD")) = 0, "No", "Yes")


                TxtBookDescription.Text = AgL.XNull(.Rows(0)("BookDescription"))
                TxtAlmira.AgSelectedValue = AgL.XNull(.Rows(0)("Godown"))
                TxtShelf.Text = AgL.XNull(.Rows(0)("GodownSection"))
                mCDSearchCode = AgL.XNull(.Rows(0)("CD_ItemCode"))
            End If
        End With
        Topctrl1.tPrn = False
    End Sub

    Private Sub FrmBook_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = " SELECT S.Code,S.Description AS Subject,S.Prefix,S.Div_Code,IsNull( S.IsDeleted,0) as IsDeleted, " & _
                 " ISNULL(S.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status  " & _
                 " FROM Lib_Subject S " & _
                 " Order By S.Description"
        TxtSubject.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT B.Language AS Code,B.Language  FROM Lib_Book B WHERE B.Language IS NOT NULL"
        TxtLanguage.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT BT.Code,BT.Description AS [Book Type],BT.Suffix, " & _
           " isnull(BT.IsDeleted,0) AS IsDeleted,ISNULL(Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status,BT.Div_Code " & _
           " FROM Lib_BookType BT "
        TxtBookType.AgHelpDataSet(4) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT BT.Code,BT.Description AS [Book Type], " & _
               " isnull(BT.IsDeleted,0) AS IsDeleted,ISNULL(Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status,BT.Div_Code " & _
               " FROM Lib_ScrapCategory BT "
        TxtScrapCategory.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT B.Writer  AS Code,B.Writer  FROM Lib_Book B WHERE B.Writer IS NOT NULL "
        TxtWriter.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT B.Publisher  AS Code,B.Publisher  FROM Lib_Book B WHERE B.Publisher IS NOT NULL "
        TxtPublisher.AgHelpDataSet(0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT G.Code ,G.Description AS Godown ,G.Div_Code,IsNull( G.IsDeleted,0) as IsDeleted, " & _
                " ISNULL(G.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status  " & _
                " FROM Godown G " & _
                " Order By G.Description"
        TxtCDAlmira.AgHelpDataSet(3) = AgL.FillData(mQry, AgL.GCn)
        TxtAlmira.AgHelpDataSet(3) = TxtCDAlmira.AgHelpDataSet.Copy()

        mQry = " SELECT 	Section AS Code , Section , Code AS GodownCode  FROM GodownSection "
        TxtCDShelf.AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)
        TxtShelf.AgHelpDataSet(1) = TxtCDShelf.AgHelpDataSet.Copy()

    End Sub

    Private Sub FrmBook_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainLineTableCsv = "Lib_Book"
        LogLineTableCsv = "Lib_Book_LOG"
        LblManualCode.Text = "Book Code"
        LblDescription.Text = "Book Name"
        LblBookDescription.Text = "Book Description"
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
    TxtSubject.Validating, TxtBookType.Validating, TxtWithCD.Validating, TxtCDAlmira.Validating, TxtCDShelf.Validating, TxtDescription.Validating, TxtVolume.Validating

        Dim DrTemp As DataRow() = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtSubject.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblSubject.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtSubject.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtSubject.AgSelectedValue) & "")
                            LblSubject.Tag = AgL.XNull(DrTemp(0)("Prefix")).ToString
                            ProcGetAlmira(TxtSubject.AgSelectedValue)
                        End If
                    End If

                Case TxtBookType.Name
                    If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                        LblBookType.Tag = ""
                    Else
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtBookType.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(TxtBookType.AgSelectedValue) & "")
                            LblBookType.Tag = AgL.XNull(DrTemp(0)("Suffix")).ToString
                        End If
                    End If

                Case TxtWithCD.Name
                    If AgL.StrCmp(TxtWithCD.Text, "Yes") Then
                        TxtCDAlmira.Focus()
                    Else
                        Topctrl1.Focus()
                    End If

                Case TxtDescription.Name, TxtVolume.Name
                    TxtBookDescription.Text = TxtDescription.Text.ToCharArray & " " & TxtVolume.Text.ToString
            End Select

            'If LblSubject.Tag <> "" And LblBookType.Tag <> "" Then
            GetManualCode()
            ' End If

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
        TxtSubject.Focus()
        TxtWithCD.Text = "No"
    End Sub

    Private Sub FrmBook_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        If DtLib_Enviro.Rows.Count > 0 Then
            TxtBookType.AgSelectedValue = AgL.XNull(DtLib_Enviro.Rows(0)("DefaultBookType"))
            TxtUnit.AgSelectedValue = AgL.XNull(DtLib_Enviro.Rows(0)("DefaultUnit"))
            TxtLanguage.Text = AgL.XNull(DtLib_Enviro.Rows(0)("DefaultLanguage"))
        End If
    End Sub

    Private Sub ProcGetAlmira(ByVal Subject As String)
        Dim DtTemp As DataTable = Nothing
        Try
            If Subject = "" Then Exit Sub
            mQry = " SELECT Sd.Godown, Sd.GodownSection FROM Lib_SubjectDetail Sd WHERE Sd.Code = '" & Subject & "'  "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                If .Rows.Count > 0 Then
                    TxtAlmira.AgSelectedValue = AgL.XNull(.Rows(0)("Godown"))
                    TxtShelf.Text = AgL.XNull(.Rows(0)("GodownSection"))
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmBook_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        If TxtWithCD.Text = "Yes" Then
            Call ProcSaveCDItem(True, Conn, Cmd)
        Else
            Call ProcSaveCDItem(False, Conn, Cmd)
        End If
    End Sub
End Class
