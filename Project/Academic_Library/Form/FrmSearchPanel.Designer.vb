<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSearchPanel
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
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubject = New System.Windows.Forms.Label
        Me.TxtBookType = New AgControls.AgTextBox
        Me.LblBookType = New System.Windows.Forms.Label
        Me.TxtBookCode = New AgControls.AgTextBox
        Me.LblBookCode = New System.Windows.Forms.Label
        Me.TxtBookTitle = New AgControls.AgTextBox
        Me.LblBookTitle = New System.Windows.Forms.Label
        Me.TxtISBN = New AgControls.AgTextBox
        Me.LblISBN = New System.Windows.Forms.Label
        Me.TxtWriter = New AgControls.AgTextBox
        Me.LblWriter = New System.Windows.Forms.Label
        Me.TxtPublisher = New AgControls.AgTextBox
        Me.LblPublisher = New System.Windows.Forms.Label
        Me.TxtSearchKeyword = New AgControls.AgTextBox
        Me.LblSearchKeyword = New System.Windows.Forms.Label
        Me.BtnOk = New System.Windows.Forms.Button
        Me.BtnClear = New System.Windows.Forms.Button
        Me.TxtBookID = New AgControls.AgTextBox
        Me.LblBookID = New System.Windows.Forms.Label
        Me.TxtAccessionNo = New AgControls.AgTextBox
        Me.LblAccessionNo = New System.Windows.Forms.Label
        Me.BtnRefresh = New System.Windows.Forms.Button
        Me.RbtAnd = New System.Windows.Forms.RadioButton
        Me.RbtOr = New System.Windows.Forms.RadioButton
        Me.TxtMemberCardNo = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.ChkClassificationWise = New System.Windows.Forms.CheckBox
        Me.TxtSubjectClassification = New AgControls.AgTextBox
        Me.LblSubjectClassification = New System.Windows.Forms.Label
        Me.TxtCallNo = New AgControls.AgTextBox
        Me.LblCallNo = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'TxtSubject
        '
        Me.TxtSubject.AgMandatory = False
        Me.TxtSubject.AgMasterHelp = False
        Me.TxtSubject.AgNumberLeftPlaces = 0
        Me.TxtSubject.AgNumberNegetiveAllow = False
        Me.TxtSubject.AgNumberRightPlaces = 0
        Me.TxtSubject.AgPickFromLastValue = False
        Me.TxtSubject.AgRowFilter = ""
        Me.TxtSubject.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubject.AgSelectedValue = Nothing
        Me.TxtSubject.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubject.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubject.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSubject.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubject.Location = New System.Drawing.Point(-1, 119)
        Me.TxtSubject.MaxLength = 20
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(129, 22)
        Me.TxtSubject.TabIndex = 1
        '
        'LblSubject
        '
        Me.LblSubject.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(78, 99)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(50, 15)
        Me.LblSubject.TabIndex = 777
        Me.LblSubject.Text = "Subject"
        '
        'TxtBookType
        '
        Me.TxtBookType.AgMandatory = False
        Me.TxtBookType.AgMasterHelp = False
        Me.TxtBookType.AgNumberLeftPlaces = 0
        Me.TxtBookType.AgNumberNegetiveAllow = False
        Me.TxtBookType.AgNumberRightPlaces = 0
        Me.TxtBookType.AgPickFromLastValue = False
        Me.TxtBookType.AgRowFilter = ""
        Me.TxtBookType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBookType.AgSelectedValue = Nothing
        Me.TxtBookType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBookType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBookType.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBookType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBookType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBookType.Location = New System.Drawing.Point(-1, 161)
        Me.TxtBookType.MaxLength = 20
        Me.TxtBookType.Name = "TxtBookType"
        Me.TxtBookType.Size = New System.Drawing.Size(129, 22)
        Me.TxtBookType.TabIndex = 2
        '
        'LblBookType
        '
        Me.LblBookType.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblBookType.AutoSize = True
        Me.LblBookType.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBookType.Location = New System.Drawing.Point(62, 144)
        Me.LblBookType.Name = "LblBookType"
        Me.LblBookType.Size = New System.Drawing.Size(66, 15)
        Me.LblBookType.TabIndex = 779
        Me.LblBookType.Text = "Book Type"
        '
        'TxtBookCode
        '
        Me.TxtBookCode.AgMandatory = False
        Me.TxtBookCode.AgMasterHelp = False
        Me.TxtBookCode.AgNumberLeftPlaces = 0
        Me.TxtBookCode.AgNumberNegetiveAllow = False
        Me.TxtBookCode.AgNumberRightPlaces = 0
        Me.TxtBookCode.AgPickFromLastValue = False
        Me.TxtBookCode.AgRowFilter = ""
        Me.TxtBookCode.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBookCode.AgSelectedValue = Nothing
        Me.TxtBookCode.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBookCode.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBookCode.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBookCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBookCode.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBookCode.Location = New System.Drawing.Point(140, 188)
        Me.TxtBookCode.MaxLength = 20
        Me.TxtBookCode.Name = "TxtBookCode"
        Me.TxtBookCode.Size = New System.Drawing.Size(129, 22)
        Me.TxtBookCode.TabIndex = 3
        Me.TxtBookCode.Visible = False
        '
        'LblBookCode
        '
        Me.LblBookCode.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblBookCode.AutoSize = True
        Me.LblBookCode.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBookCode.Location = New System.Drawing.Point(201, 169)
        Me.LblBookCode.Name = "LblBookCode"
        Me.LblBookCode.Size = New System.Drawing.Size(68, 15)
        Me.LblBookCode.TabIndex = 781
        Me.LblBookCode.Text = "Book Code"
        Me.LblBookCode.Visible = False
        '
        'TxtBookTitle
        '
        Me.TxtBookTitle.AgMandatory = False
        Me.TxtBookTitle.AgMasterHelp = False
        Me.TxtBookTitle.AgNumberLeftPlaces = 0
        Me.TxtBookTitle.AgNumberNegetiveAllow = False
        Me.TxtBookTitle.AgNumberRightPlaces = 0
        Me.TxtBookTitle.AgPickFromLastValue = False
        Me.TxtBookTitle.AgRowFilter = ""
        Me.TxtBookTitle.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBookTitle.AgSelectedValue = Nothing
        Me.TxtBookTitle.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBookTitle.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBookTitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBookTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBookTitle.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBookTitle.Location = New System.Drawing.Point(-1, 202)
        Me.TxtBookTitle.MaxLength = 20
        Me.TxtBookTitle.Name = "TxtBookTitle"
        Me.TxtBookTitle.Size = New System.Drawing.Size(129, 22)
        Me.TxtBookTitle.TabIndex = 3
        '
        'LblBookTitle
        '
        Me.LblBookTitle.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblBookTitle.AutoSize = True
        Me.LblBookTitle.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBookTitle.Location = New System.Drawing.Point(65, 186)
        Me.LblBookTitle.Name = "LblBookTitle"
        Me.LblBookTitle.Size = New System.Drawing.Size(63, 15)
        Me.LblBookTitle.TabIndex = 783
        Me.LblBookTitle.Text = "Book Title"
        '
        'TxtISBN
        '
        Me.TxtISBN.AgMandatory = False
        Me.TxtISBN.AgMasterHelp = False
        Me.TxtISBN.AgNumberLeftPlaces = 0
        Me.TxtISBN.AgNumberNegetiveAllow = False
        Me.TxtISBN.AgNumberRightPlaces = 0
        Me.TxtISBN.AgPickFromLastValue = False
        Me.TxtISBN.AgRowFilter = ""
        Me.TxtISBN.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtISBN.AgSelectedValue = Nothing
        Me.TxtISBN.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtISBN.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtISBN.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtISBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtISBN.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtISBN.Location = New System.Drawing.Point(-1, 246)
        Me.TxtISBN.MaxLength = 20
        Me.TxtISBN.Name = "TxtISBN"
        Me.TxtISBN.Size = New System.Drawing.Size(129, 22)
        Me.TxtISBN.TabIndex = 4
        '
        'LblISBN
        '
        Me.LblISBN.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblISBN.AutoSize = True
        Me.LblISBN.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblISBN.Location = New System.Drawing.Point(94, 227)
        Me.LblISBN.Name = "LblISBN"
        Me.LblISBN.Size = New System.Drawing.Size(34, 15)
        Me.LblISBN.TabIndex = 785
        Me.LblISBN.Text = "ISBN"
        '
        'TxtWriter
        '
        Me.TxtWriter.AgMandatory = False
        Me.TxtWriter.AgMasterHelp = False
        Me.TxtWriter.AgNumberLeftPlaces = 0
        Me.TxtWriter.AgNumberNegetiveAllow = False
        Me.TxtWriter.AgNumberRightPlaces = 0
        Me.TxtWriter.AgPickFromLastValue = False
        Me.TxtWriter.AgRowFilter = ""
        Me.TxtWriter.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtWriter.AgSelectedValue = Nothing
        Me.TxtWriter.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtWriter.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtWriter.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtWriter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtWriter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWriter.Location = New System.Drawing.Point(-1, 290)
        Me.TxtWriter.MaxLength = 20
        Me.TxtWriter.Name = "TxtWriter"
        Me.TxtWriter.Size = New System.Drawing.Size(129, 22)
        Me.TxtWriter.TabIndex = 5
        '
        'LblWriter
        '
        Me.LblWriter.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblWriter.AutoSize = True
        Me.LblWriter.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWriter.Location = New System.Drawing.Point(85, 271)
        Me.LblWriter.Name = "LblWriter"
        Me.LblWriter.Size = New System.Drawing.Size(43, 15)
        Me.LblWriter.TabIndex = 787
        Me.LblWriter.Text = "Writer"
        '
        'TxtPublisher
        '
        Me.TxtPublisher.AgMandatory = False
        Me.TxtPublisher.AgMasterHelp = False
        Me.TxtPublisher.AgNumberLeftPlaces = 0
        Me.TxtPublisher.AgNumberNegetiveAllow = False
        Me.TxtPublisher.AgNumberRightPlaces = 0
        Me.TxtPublisher.AgPickFromLastValue = False
        Me.TxtPublisher.AgRowFilter = ""
        Me.TxtPublisher.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPublisher.AgSelectedValue = Nothing
        Me.TxtPublisher.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPublisher.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPublisher.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPublisher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtPublisher.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPublisher.Location = New System.Drawing.Point(-1, 333)
        Me.TxtPublisher.MaxLength = 20
        Me.TxtPublisher.Name = "TxtPublisher"
        Me.TxtPublisher.Size = New System.Drawing.Size(129, 22)
        Me.TxtPublisher.TabIndex = 6
        '
        'LblPublisher
        '
        Me.LblPublisher.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblPublisher.AutoSize = True
        Me.LblPublisher.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPublisher.Location = New System.Drawing.Point(67, 315)
        Me.LblPublisher.Name = "LblPublisher"
        Me.LblPublisher.Size = New System.Drawing.Size(61, 15)
        Me.LblPublisher.TabIndex = 789
        Me.LblPublisher.Text = "Publisher"
        '
        'TxtSearchKeyword
        '
        Me.TxtSearchKeyword.AgMandatory = False
        Me.TxtSearchKeyword.AgMasterHelp = False
        Me.TxtSearchKeyword.AgNumberLeftPlaces = 0
        Me.TxtSearchKeyword.AgNumberNegetiveAllow = False
        Me.TxtSearchKeyword.AgNumberRightPlaces = 0
        Me.TxtSearchKeyword.AgPickFromLastValue = False
        Me.TxtSearchKeyword.AgRowFilter = ""
        Me.TxtSearchKeyword.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSearchKeyword.AgSelectedValue = Nothing
        Me.TxtSearchKeyword.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSearchKeyword.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSearchKeyword.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSearchKeyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSearchKeyword.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSearchKeyword.Location = New System.Drawing.Point(-1, 376)
        Me.TxtSearchKeyword.MaxLength = 20
        Me.TxtSearchKeyword.Name = "TxtSearchKeyword"
        Me.TxtSearchKeyword.Size = New System.Drawing.Size(129, 22)
        Me.TxtSearchKeyword.TabIndex = 7
        '
        'LblSearchKeyword
        '
        Me.LblSearchKeyword.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblSearchKeyword.AutoSize = True
        Me.LblSearchKeyword.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSearchKeyword.Location = New System.Drawing.Point(27, 358)
        Me.LblSearchKeyword.Name = "LblSearchKeyword"
        Me.LblSearchKeyword.Size = New System.Drawing.Size(101, 15)
        Me.LblSearchKeyword.TabIndex = 791
        Me.LblSearchKeyword.Text = "Search Keyword"
        '
        'BtnOk
        '
        Me.BtnOk.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BtnOk.BackColor = System.Drawing.SystemColors.HighlightText
        Me.BtnOk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnOk.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnOk.Location = New System.Drawing.Point(-3, 612)
        Me.BtnOk.Name = "BtnOk"
        Me.BtnOk.Size = New System.Drawing.Size(33, 23)
        Me.BtnOk.TabIndex = 11
        Me.BtnOk.Text = "Ok"
        Me.BtnOk.UseVisualStyleBackColor = False
        '
        'BtnClear
        '
        Me.BtnClear.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BtnClear.BackColor = System.Drawing.SystemColors.HighlightText
        Me.BtnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnClear.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnClear.Location = New System.Drawing.Point(84, 612)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(49, 23)
        Me.BtnClear.TabIndex = 13
        Me.BtnClear.Text = "Clear"
        Me.BtnClear.UseVisualStyleBackColor = False
        '
        'TxtBookID
        '
        Me.TxtBookID.AgMandatory = False
        Me.TxtBookID.AgMasterHelp = False
        Me.TxtBookID.AgNumberLeftPlaces = 0
        Me.TxtBookID.AgNumberNegetiveAllow = False
        Me.TxtBookID.AgNumberRightPlaces = 0
        Me.TxtBookID.AgPickFromLastValue = False
        Me.TxtBookID.AgRowFilter = ""
        Me.TxtBookID.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBookID.AgSelectedValue = Nothing
        Me.TxtBookID.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBookID.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBookID.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtBookID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtBookID.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBookID.Location = New System.Drawing.Point(-1, 420)
        Me.TxtBookID.MaxLength = 20
        Me.TxtBookID.Name = "TxtBookID"
        Me.TxtBookID.Size = New System.Drawing.Size(129, 22)
        Me.TxtBookID.TabIndex = 8
        '
        'LblBookID
        '
        Me.LblBookID.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblBookID.AutoSize = True
        Me.LblBookID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBookID.Location = New System.Drawing.Point(78, 401)
        Me.LblBookID.Name = "LblBookID"
        Me.LblBookID.Size = New System.Drawing.Size(50, 15)
        Me.LblBookID.TabIndex = 793
        Me.LblBookID.Text = "Book ID"
        '
        'TxtAccessionNo
        '
        Me.TxtAccessionNo.AgMandatory = False
        Me.TxtAccessionNo.AgMasterHelp = False
        Me.TxtAccessionNo.AgNumberLeftPlaces = 0
        Me.TxtAccessionNo.AgNumberNegetiveAllow = False
        Me.TxtAccessionNo.AgNumberRightPlaces = 0
        Me.TxtAccessionNo.AgPickFromLastValue = False
        Me.TxtAccessionNo.AgRowFilter = ""
        Me.TxtAccessionNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAccessionNo.AgSelectedValue = Nothing
        Me.TxtAccessionNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAccessionNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAccessionNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtAccessionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtAccessionNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAccessionNo.Location = New System.Drawing.Point(-1, 464)
        Me.TxtAccessionNo.MaxLength = 20
        Me.TxtAccessionNo.Name = "TxtAccessionNo"
        Me.TxtAccessionNo.Size = New System.Drawing.Size(129, 22)
        Me.TxtAccessionNo.TabIndex = 9
        '
        'LblAccessionNo
        '
        Me.LblAccessionNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblAccessionNo.AutoSize = True
        Me.LblAccessionNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAccessionNo.Location = New System.Drawing.Point(40, 445)
        Me.LblAccessionNo.Name = "LblAccessionNo"
        Me.LblAccessionNo.Size = New System.Drawing.Size(88, 15)
        Me.LblAccessionNo.TabIndex = 795
        Me.LblAccessionNo.Text = "Accession No."
        '
        'BtnRefresh
        '
        Me.BtnRefresh.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.BtnRefresh.BackColor = System.Drawing.SystemColors.HighlightText
        Me.BtnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRefresh.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefresh.Location = New System.Drawing.Point(28, 612)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(61, 23)
        Me.BtnRefresh.TabIndex = 12
        Me.BtnRefresh.Text = "Refresh"
        Me.BtnRefresh.UseVisualStyleBackColor = False
        '
        'RbtAnd
        '
        Me.RbtAnd.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.RbtAnd.AutoSize = True
        Me.RbtAnd.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtAnd.Location = New System.Drawing.Point(10, 3)
        Me.RbtAnd.Name = "RbtAnd"
        Me.RbtAnd.Size = New System.Drawing.Size(47, 19)
        Me.RbtAnd.TabIndex = 14
        Me.RbtAnd.TabStop = True
        Me.RbtAnd.Text = "And"
        Me.RbtAnd.UseVisualStyleBackColor = True
        '
        'RbtOr
        '
        Me.RbtOr.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.RbtOr.AutoSize = True
        Me.RbtOr.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.RbtOr.Location = New System.Drawing.Point(70, 3)
        Me.RbtOr.Name = "RbtOr"
        Me.RbtOr.Size = New System.Drawing.Size(39, 19)
        Me.RbtOr.TabIndex = 15
        Me.RbtOr.TabStop = True
        Me.RbtOr.Text = "Or"
        Me.RbtOr.UseVisualStyleBackColor = True
        '
        'TxtMemberCardNo
        '
        Me.TxtMemberCardNo.AgMandatory = False
        Me.TxtMemberCardNo.AgMasterHelp = False
        Me.TxtMemberCardNo.AgNumberLeftPlaces = 0
        Me.TxtMemberCardNo.AgNumberNegetiveAllow = False
        Me.TxtMemberCardNo.AgNumberRightPlaces = 0
        Me.TxtMemberCardNo.AgPickFromLastValue = False
        Me.TxtMemberCardNo.AgRowFilter = ""
        Me.TxtMemberCardNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberCardNo.AgSelectedValue = Nothing
        Me.TxtMemberCardNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberCardNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberCardNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtMemberCardNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberCardNo.Location = New System.Drawing.Point(-1, 48)
        Me.TxtMemberCardNo.MaxLength = 20
        Me.TxtMemberCardNo.Name = "TxtMemberCardNo"
        Me.TxtMemberCardNo.Size = New System.Drawing.Size(129, 22)
        Me.TxtMemberCardNo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 15)
        Me.Label1.TabIndex = 800
        Me.Label1.Text = "Member Card No."
        '
        'ChkClassificationWise
        '
        Me.ChkClassificationWise.AutoSize = True
        Me.ChkClassificationWise.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ChkClassificationWise.Location = New System.Drawing.Point(15, 76)
        Me.ChkClassificationWise.Name = "ChkClassificationWise"
        Me.ChkClassificationWise.Size = New System.Drawing.Size(113, 19)
        Me.ChkClassificationWise.TabIndex = 801
        Me.ChkClassificationWise.Text = "Hierarchy Wise"
        Me.ChkClassificationWise.UseVisualStyleBackColor = True
        '
        'TxtSubjectClassification
        '
        Me.TxtSubjectClassification.AgMandatory = False
        Me.TxtSubjectClassification.AgMasterHelp = False
        Me.TxtSubjectClassification.AgNumberLeftPlaces = 0
        Me.TxtSubjectClassification.AgNumberNegetiveAllow = False
        Me.TxtSubjectClassification.AgNumberRightPlaces = 0
        Me.TxtSubjectClassification.AgPickFromLastValue = False
        Me.TxtSubjectClassification.AgRowFilter = ""
        Me.TxtSubjectClassification.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubjectClassification.AgSelectedValue = Nothing
        Me.TxtSubjectClassification.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubjectClassification.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubjectClassification.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtSubjectClassification.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSubjectClassification.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubjectClassification.Location = New System.Drawing.Point(-1, 565)
        Me.TxtSubjectClassification.MaxLength = 20
        Me.TxtSubjectClassification.Name = "TxtSubjectClassification"
        Me.TxtSubjectClassification.Size = New System.Drawing.Size(129, 22)
        Me.TxtSubjectClassification.TabIndex = 10
        '
        'LblSubjectClassification
        '
        Me.LblSubjectClassification.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblSubjectClassification.AutoSize = True
        Me.LblSubjectClassification.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubjectClassification.Location = New System.Drawing.Point(44, 533)
        Me.LblSubjectClassification.Name = "LblSubjectClassification"
        Me.LblSubjectClassification.Size = New System.Drawing.Size(84, 30)
        Me.LblSubjectClassification.TabIndex = 804
        Me.LblSubjectClassification.Text = "Subject " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Classification" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.LblSubjectClassification.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'TxtCallNo
        '
        Me.TxtCallNo.AgMandatory = False
        Me.TxtCallNo.AgMasterHelp = False
        Me.TxtCallNo.AgNumberLeftPlaces = 0
        Me.TxtCallNo.AgNumberNegetiveAllow = False
        Me.TxtCallNo.AgNumberRightPlaces = 0
        Me.TxtCallNo.AgPickFromLastValue = False
        Me.TxtCallNo.AgRowFilter = ""
        Me.TxtCallNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCallNo.AgSelectedValue = Nothing
        Me.TxtCallNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCallNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCallNo.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtCallNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtCallNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCallNo.Location = New System.Drawing.Point(-1, 508)
        Me.TxtCallNo.MaxLength = 20
        Me.TxtCallNo.Name = "TxtCallNo"
        Me.TxtCallNo.Size = New System.Drawing.Size(129, 22)
        Me.TxtCallNo.TabIndex = 805
        '
        'LblCallNo
        '
        Me.LblCallNo.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.LblCallNo.AutoSize = True
        Me.LblCallNo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCallNo.Location = New System.Drawing.Point(79, 489)
        Me.LblCallNo.Name = "LblCallNo"
        Me.LblCallNo.Size = New System.Drawing.Size(49, 15)
        Me.LblCallNo.TabIndex = 806
        Me.LblCallNo.Text = "Call No."
        '
        'FrmSearchPanel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(127, 634)
        Me.Controls.Add(Me.TxtCallNo)
        Me.Controls.Add(Me.LblCallNo)
        Me.Controls.Add(Me.TxtSubjectClassification)
        Me.Controls.Add(Me.LblSubjectClassification)
        Me.Controls.Add(Me.ChkClassificationWise)
        Me.Controls.Add(Me.TxtMemberCardNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RbtOr)
        Me.Controls.Add(Me.RbtAnd)
        Me.Controls.Add(Me.BtnRefresh)
        Me.Controls.Add(Me.TxtAccessionNo)
        Me.Controls.Add(Me.LblAccessionNo)
        Me.Controls.Add(Me.TxtBookID)
        Me.Controls.Add(Me.LblBookID)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnOk)
        Me.Controls.Add(Me.TxtSearchKeyword)
        Me.Controls.Add(Me.LblSearchKeyword)
        Me.Controls.Add(Me.TxtPublisher)
        Me.Controls.Add(Me.LblPublisher)
        Me.Controls.Add(Me.TxtWriter)
        Me.Controls.Add(Me.LblWriter)
        Me.Controls.Add(Me.TxtISBN)
        Me.Controls.Add(Me.LblISBN)
        Me.Controls.Add(Me.TxtBookTitle)
        Me.Controls.Add(Me.LblBookTitle)
        Me.Controls.Add(Me.TxtBookCode)
        Me.Controls.Add(Me.LblBookCode)
        Me.Controls.Add(Me.TxtBookType)
        Me.Controls.Add(Me.LblBookType)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.LblSubject)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.KeyPreview = True
        Me.Name = "FrmSearchPanel"
        Me.Text = "Catalog Search"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents TxtSubject As AgControls.AgTextBox
    Protected WithEvents LblSubject As System.Windows.Forms.Label
    Protected WithEvents TxtBookType As AgControls.AgTextBox
    Protected WithEvents LblBookType As System.Windows.Forms.Label
    Protected WithEvents TxtBookCode As AgControls.AgTextBox
    Protected WithEvents LblBookCode As System.Windows.Forms.Label
    Protected WithEvents TxtBookTitle As AgControls.AgTextBox
    Protected WithEvents LblBookTitle As System.Windows.Forms.Label
    Protected WithEvents TxtISBN As AgControls.AgTextBox
    Protected WithEvents LblISBN As System.Windows.Forms.Label
    Protected WithEvents TxtWriter As AgControls.AgTextBox
    Protected WithEvents LblWriter As System.Windows.Forms.Label
    Protected WithEvents TxtPublisher As AgControls.AgTextBox
    Protected WithEvents LblPublisher As System.Windows.Forms.Label
    Protected WithEvents TxtSearchKeyword As AgControls.AgTextBox
    Protected WithEvents LblSearchKeyword As System.Windows.Forms.Label
    Friend WithEvents BtnOk As System.Windows.Forms.Button
    Friend WithEvents BtnClear As System.Windows.Forms.Button
    Protected WithEvents TxtBookID As AgControls.AgTextBox
    Protected WithEvents LblBookID As System.Windows.Forms.Label
    Protected WithEvents TxtAccessionNo As AgControls.AgTextBox
    Protected WithEvents LblAccessionNo As System.Windows.Forms.Label
    Friend WithEvents BtnRefresh As System.Windows.Forms.Button
    Friend WithEvents RbtAnd As System.Windows.Forms.RadioButton
    Friend WithEvents RbtOr As System.Windows.Forms.RadioButton
    Protected WithEvents TxtMemberCardNo As AgControls.AgTextBox
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ChkClassificationWise As System.Windows.Forms.CheckBox
    Protected WithEvents TxtSubjectClassification As AgControls.AgTextBox
    Protected WithEvents LblSubjectClassification As System.Windows.Forms.Label
    Protected WithEvents TxtCallNo As AgControls.AgTextBox
    Protected WithEvents LblCallNo As System.Windows.Forms.Label
End Class
