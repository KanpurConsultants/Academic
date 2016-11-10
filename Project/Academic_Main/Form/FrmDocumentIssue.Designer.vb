<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDocumentIssue
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtAdmissionID = New AgControls.AgTextBox
        Me.LblAdmissionID = New System.Windows.Forms.Label
        Me.TxtDocumentType = New AgControls.AgTextBox
        Me.LblDocumentType = New System.Windows.Forms.Label
        Me.TxtIssuedTo = New AgControls.AgTextBox
        Me.LblIssuedTo = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblPurposeOfLeaveReq = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblIssueDate = New System.Windows.Forms.Label
        Me.TxtIssueDate = New AgControls.AgTextBox
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubject = New System.Windows.Forms.Label
        Me.TxtBodyText = New AgControls.AgTextBox
        Me.LblBodyText = New System.Windows.Forms.Label
        Me.TxtFooterRemark = New AgControls.AgTextBox
        Me.LblFooterRemark = New System.Windows.Forms.Label
        Me.TxtPurpose = New AgControls.AgTextBox
        Me.LblPurpose = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(0, 390)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 4)
        Me.GroupBox2.TabIndex = 551
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 403)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 552
        Me.GrpUP.TabStop = False
        Me.GrpUP.Tag = "TR"
        Me.GrpUP.Text = "Prepared By "
        '
        'TxtPrepared
        '
        Me.TxtPrepared.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtPrepared.BackColor = System.Drawing.Color.White
        Me.TxtPrepared.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPrepared.Enabled = False
        Me.TxtPrepared.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPrepared.Location = New System.Drawing.Point(14, 21)
        Me.TxtPrepared.Name = "TxtPrepared"
        Me.TxtPrepared.ReadOnly = True
        Me.TxtPrepared.Size = New System.Drawing.Size(158, 18)
        Me.TxtPrepared.TabIndex = 0
        Me.TxtPrepared.TabStop = False
        Me.TxtPrepared.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(676, 403)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 553
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
        '
        'TxtModified
        '
        Me.TxtModified.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TxtModified.BackColor = System.Drawing.Color.White
        Me.TxtModified.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtModified.Enabled = False
        Me.TxtModified.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModified.Location = New System.Drawing.Point(13, 21)
        Me.TxtModified.Name = "TxtModified"
        Me.TxtModified.ReadOnly = True
        Me.TxtModified.Size = New System.Drawing.Size(158, 18)
        Me.TxtModified.TabIndex = 0
        Me.TxtModified.TabStop = False
        Me.TxtModified.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(190, 338)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 554
        Me.Label12.Text = "Remark"
        '
        'TxtAdmissionID
        '
        Me.TxtAdmissionID.AgMandatory = False
        Me.TxtAdmissionID.AgMasterHelp = False
        Me.TxtAdmissionID.AgNumberLeftPlaces = 0
        Me.TxtAdmissionID.AgNumberNegetiveAllow = False
        Me.TxtAdmissionID.AgNumberRightPlaces = 0
        Me.TxtAdmissionID.AgPickFromLastValue = False
        Me.TxtAdmissionID.AgRowFilter = ""
        Me.TxtAdmissionID.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdmissionID.AgSelectedValue = Nothing
        Me.TxtAdmissionID.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdmissionID.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdmissionID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionID.ForeColor = System.Drawing.Color.Black
        Me.TxtAdmissionID.Location = New System.Drawing.Point(332, 131)
        Me.TxtAdmissionID.MaxLength = 21
        Me.TxtAdmissionID.Name = "TxtAdmissionID"
        Me.TxtAdmissionID.Size = New System.Drawing.Size(350, 21)
        Me.TxtAdmissionID.TabIndex = 2
        Me.TxtAdmissionID.Text = "TxtAdmissionID"
        '
        'LblAdmissionID
        '
        Me.LblAdmissionID.AutoSize = True
        Me.LblAdmissionID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmissionID.ForeColor = System.Drawing.Color.Black
        Me.LblAdmissionID.Location = New System.Drawing.Point(190, 135)
        Me.LblAdmissionID.Name = "LblAdmissionID"
        Me.LblAdmissionID.Size = New System.Drawing.Size(88, 13)
        Me.LblAdmissionID.TabIndex = 649
        Me.LblAdmissionID.Text = "Student Name"
        '
        'TxtDocumentType
        '
        Me.TxtDocumentType.AgMandatory = True
        Me.TxtDocumentType.AgMasterHelp = False
        Me.TxtDocumentType.AgNumberLeftPlaces = 0
        Me.TxtDocumentType.AgNumberNegetiveAllow = False
        Me.TxtDocumentType.AgNumberRightPlaces = 0
        Me.TxtDocumentType.AgPickFromLastValue = False
        Me.TxtDocumentType.AgRowFilter = ""
        Me.TxtDocumentType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDocumentType.AgSelectedValue = Nothing
        Me.TxtDocumentType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDocumentType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDocumentType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDocumentType.Location = New System.Drawing.Point(332, 87)
        Me.TxtDocumentType.MaxLength = 50
        Me.TxtDocumentType.Name = "TxtDocumentType"
        Me.TxtDocumentType.Size = New System.Drawing.Size(350, 21)
        Me.TxtDocumentType.TabIndex = 0
        '
        'LblDocumentType
        '
        Me.LblDocumentType.AutoSize = True
        Me.LblDocumentType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDocumentType.Location = New System.Drawing.Point(190, 90)
        Me.LblDocumentType.Name = "LblDocumentType"
        Me.LblDocumentType.Size = New System.Drawing.Size(97, 13)
        Me.LblDocumentType.TabIndex = 658
        Me.LblDocumentType.Text = "Document Type"
        '
        'TxtIssuedTo
        '
        Me.TxtIssuedTo.AgMandatory = True
        Me.TxtIssuedTo.AgMasterHelp = True
        Me.TxtIssuedTo.AgNumberLeftPlaces = 0
        Me.TxtIssuedTo.AgNumberNegetiveAllow = False
        Me.TxtIssuedTo.AgNumberRightPlaces = 0
        Me.TxtIssuedTo.AgPickFromLastValue = False
        Me.TxtIssuedTo.AgRowFilter = ""
        Me.TxtIssuedTo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIssuedTo.AgSelectedValue = Nothing
        Me.TxtIssuedTo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIssuedTo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtIssuedTo.BackColor = System.Drawing.SystemColors.Window
        Me.TxtIssuedTo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIssuedTo.Location = New System.Drawing.Point(332, 153)
        Me.TxtIssuedTo.MaxLength = 123
        Me.TxtIssuedTo.Name = "TxtIssuedTo"
        Me.TxtIssuedTo.Size = New System.Drawing.Size(350, 21)
        Me.TxtIssuedTo.TabIndex = 3
        '
        'LblIssuedTo
        '
        Me.LblIssuedTo.AutoSize = True
        Me.LblIssuedTo.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIssuedTo.Location = New System.Drawing.Point(190, 156)
        Me.LblIssuedTo.Name = "LblIssuedTo"
        Me.LblIssuedTo.Size = New System.Drawing.Size(121, 13)
        Me.LblIssuedTo.TabIndex = 660
        Me.LblIssuedTo.Text = "Student Disp. Name"
        '
        'TxtStreamYearSemester
        '
        Me.TxtStreamYearSemester.AgMandatory = True
        Me.TxtStreamYearSemester.AgMasterHelp = False
        Me.TxtStreamYearSemester.AgNumberLeftPlaces = 0
        Me.TxtStreamYearSemester.AgNumberNegetiveAllow = False
        Me.TxtStreamYearSemester.AgNumberRightPlaces = 0
        Me.TxtStreamYearSemester.AgPickFromLastValue = False
        Me.TxtStreamYearSemester.AgRowFilter = ""
        Me.TxtStreamYearSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStreamYearSemester.AgSelectedValue = Nothing
        Me.TxtStreamYearSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStreamYearSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(332, 175)
        Me.TxtStreamYearSemester.MaxLength = 50
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(350, 21)
        Me.TxtStreamYearSemester.TabIndex = 4
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(190, 178)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(138, 13)
        Me.LblStreamYearSemester.TabIndex = 664
        Me.LblStreamYearSemester.Text = "Stream Year Semester"
        '
        'TxtRemark
        '
        Me.TxtRemark.AgMandatory = False
        Me.TxtRemark.AgMasterHelp = False
        Me.TxtRemark.AgNumberLeftPlaces = 0
        Me.TxtRemark.AgNumberNegetiveAllow = False
        Me.TxtRemark.AgNumberRightPlaces = 0
        Me.TxtRemark.AgPickFromLastValue = False
        Me.TxtRemark.AgRowFilter = ""
        Me.TxtRemark.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemark.AgSelectedValue = Nothing
        Me.TxtRemark.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemark.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemark.Location = New System.Drawing.Point(332, 335)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 21)
        Me.TxtRemark.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(316, 162)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 666
        Me.Label4.Text = "Ä"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(316, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 667
        Me.Label5.Text = "Ä"
        '
        'LblPurposeOfLeaveReq
        '
        Me.LblPurposeOfLeaveReq.AutoSize = True
        Me.LblPurposeOfLeaveReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblPurposeOfLeaveReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblPurposeOfLeaveReq.Location = New System.Drawing.Point(316, 96)
        Me.LblPurposeOfLeaveReq.Name = "LblPurposeOfLeaveReq"
        Me.LblPurposeOfLeaveReq.Size = New System.Drawing.Size(10, 7)
        Me.LblPurposeOfLeaveReq.TabIndex = 668
        Me.LblPurposeOfLeaveReq.Text = "Ä"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(316, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 671
        Me.Label2.Text = "Ä"
        '
        'LblIssueDate
        '
        Me.LblIssueDate.AutoSize = True
        Me.LblIssueDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIssueDate.Location = New System.Drawing.Point(190, 112)
        Me.LblIssueDate.Name = "LblIssueDate"
        Me.LblIssueDate.Size = New System.Drawing.Size(69, 13)
        Me.LblIssueDate.TabIndex = 670
        Me.LblIssueDate.Text = "Issue Date"
        '
        'TxtIssueDate
        '
        Me.TxtIssueDate.AgMandatory = True
        Me.TxtIssueDate.AgMasterHelp = False
        Me.TxtIssueDate.AgNumberLeftPlaces = 0
        Me.TxtIssueDate.AgNumberNegetiveAllow = False
        Me.TxtIssueDate.AgNumberRightPlaces = 0
        Me.TxtIssueDate.AgPickFromLastValue = False
        Me.TxtIssueDate.AgRowFilter = ""
        Me.TxtIssueDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIssueDate.AgSelectedValue = Nothing
        Me.TxtIssueDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIssueDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtIssueDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIssueDate.Location = New System.Drawing.Point(332, 109)
        Me.TxtIssueDate.Name = "TxtIssueDate"
        Me.TxtIssueDate.Size = New System.Drawing.Size(100, 21)
        Me.TxtIssueDate.TabIndex = 1
        Me.TxtIssueDate.Text = "TxtV_Date"
        '
        'TxtSubject
        '
        Me.TxtSubject.AgMandatory = True
        Me.TxtSubject.AgMasterHelp = True
        Me.TxtSubject.AgNumberLeftPlaces = 0
        Me.TxtSubject.AgNumberNegetiveAllow = False
        Me.TxtSubject.AgNumberRightPlaces = 0
        Me.TxtSubject.AgPickFromLastValue = False
        Me.TxtSubject.AgRowFilter = ""
        Me.TxtSubject.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubject.AgSelectedValue = Nothing
        Me.TxtSubject.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubject.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubject.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubject.Location = New System.Drawing.Point(332, 197)
        Me.TxtSubject.MaxLength = 255
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(350, 21)
        Me.TxtSubject.TabIndex = 5
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(190, 200)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(50, 13)
        Me.LblSubject.TabIndex = 673
        Me.LblSubject.Text = "Subject"
        '
        'TxtBodyText
        '
        Me.TxtBodyText.AgMandatory = False
        Me.TxtBodyText.AgMasterHelp = True
        Me.TxtBodyText.AgNumberLeftPlaces = 0
        Me.TxtBodyText.AgNumberNegetiveAllow = False
        Me.TxtBodyText.AgNumberRightPlaces = 0
        Me.TxtBodyText.AgPickFromLastValue = False
        Me.TxtBodyText.AgRowFilter = ""
        Me.TxtBodyText.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBodyText.AgSelectedValue = Nothing
        Me.TxtBodyText.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBodyText.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBodyText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBodyText.Location = New System.Drawing.Point(332, 219)
        Me.TxtBodyText.MaxLength = 500
        Me.TxtBodyText.Multiline = True
        Me.TxtBodyText.Name = "TxtBodyText"
        Me.TxtBodyText.Size = New System.Drawing.Size(350, 71)
        Me.TxtBodyText.TabIndex = 6
        '
        'LblBodyText
        '
        Me.LblBodyText.AutoSize = True
        Me.LblBodyText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBodyText.Location = New System.Drawing.Point(190, 222)
        Me.LblBodyText.Name = "LblBodyText"
        Me.LblBodyText.Size = New System.Drawing.Size(65, 13)
        Me.LblBodyText.TabIndex = 675
        Me.LblBodyText.Text = "Body Text"
        '
        'TxtFooterRemark
        '
        Me.TxtFooterRemark.AgMandatory = False
        Me.TxtFooterRemark.AgMasterHelp = True
        Me.TxtFooterRemark.AgNumberLeftPlaces = 0
        Me.TxtFooterRemark.AgNumberNegetiveAllow = False
        Me.TxtFooterRemark.AgNumberRightPlaces = 0
        Me.TxtFooterRemark.AgPickFromLastValue = False
        Me.TxtFooterRemark.AgRowFilter = ""
        Me.TxtFooterRemark.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFooterRemark.AgSelectedValue = Nothing
        Me.TxtFooterRemark.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFooterRemark.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFooterRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFooterRemark.Location = New System.Drawing.Point(332, 291)
        Me.TxtFooterRemark.MaxLength = 255
        Me.TxtFooterRemark.Name = "TxtFooterRemark"
        Me.TxtFooterRemark.Size = New System.Drawing.Size(350, 21)
        Me.TxtFooterRemark.TabIndex = 7
        '
        'LblFooterRemark
        '
        Me.LblFooterRemark.AutoSize = True
        Me.LblFooterRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFooterRemark.Location = New System.Drawing.Point(190, 294)
        Me.LblFooterRemark.Name = "LblFooterRemark"
        Me.LblFooterRemark.Size = New System.Drawing.Size(92, 13)
        Me.LblFooterRemark.TabIndex = 677
        Me.LblFooterRemark.Text = "Footer Remark"
        '
        'TxtPurpose
        '
        Me.TxtPurpose.AgMandatory = False
        Me.TxtPurpose.AgMasterHelp = True
        Me.TxtPurpose.AgNumberLeftPlaces = 0
        Me.TxtPurpose.AgNumberNegetiveAllow = False
        Me.TxtPurpose.AgNumberRightPlaces = 0
        Me.TxtPurpose.AgPickFromLastValue = False
        Me.TxtPurpose.AgRowFilter = ""
        Me.TxtPurpose.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPurpose.AgSelectedValue = Nothing
        Me.TxtPurpose.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPurpose.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPurpose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPurpose.Location = New System.Drawing.Point(332, 313)
        Me.TxtPurpose.MaxLength = 255
        Me.TxtPurpose.Name = "TxtPurpose"
        Me.TxtPurpose.Size = New System.Drawing.Size(350, 21)
        Me.TxtPurpose.TabIndex = 8
        '
        'LblPurpose
        '
        Me.LblPurpose.AutoSize = True
        Me.LblPurpose.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPurpose.Location = New System.Drawing.Point(190, 316)
        Me.LblPurpose.Name = "LblPurpose"
        Me.LblPurpose.Size = New System.Drawing.Size(53, 13)
        Me.LblPurpose.TabIndex = 679
        Me.LblPurpose.Text = "Purpose"
        '
        'FrmDocumentIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 466)
        Me.Controls.Add(Me.TxtPurpose)
        Me.Controls.Add(Me.LblPurpose)
        Me.Controls.Add(Me.TxtFooterRemark)
        Me.Controls.Add(Me.LblFooterRemark)
        Me.Controls.Add(Me.TxtBodyText)
        Me.Controls.Add(Me.LblBodyText)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.LblSubject)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblIssueDate)
        Me.Controls.Add(Me.TxtIssueDate)
        Me.Controls.Add(Me.LblPurposeOfLeaveReq)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtStreamYearSemester)
        Me.Controls.Add(Me.LblStreamYearSemester)
        Me.Controls.Add(Me.TxtIssuedTo)
        Me.Controls.Add(Me.LblIssuedTo)
        Me.Controls.Add(Me.TxtDocumentType)
        Me.Controls.Add(Me.LblDocumentType)
        Me.Controls.Add(Me.TxtAdmissionID)
        Me.Controls.Add(Me.LblAdmissionID)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmDocumentIssue"
        Me.Text = "Document Issue"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TxtAdmissionID As AgControls.AgTextBox
    Friend WithEvents LblAdmissionID As System.Windows.Forms.Label
    Friend WithEvents TxtDocumentType As AgControls.AgTextBox
    Friend WithEvents LblDocumentType As System.Windows.Forms.Label
    Friend WithEvents TxtIssuedTo As AgControls.AgTextBox
    Friend WithEvents LblIssuedTo As System.Windows.Forms.Label
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblPurposeOfLeaveReq As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblIssueDate As System.Windows.Forms.Label
    Friend WithEvents TxtIssueDate As AgControls.AgTextBox
    Friend WithEvents TxtSubject As AgControls.AgTextBox
    Friend WithEvents LblSubject As System.Windows.Forms.Label
    Friend WithEvents TxtBodyText As AgControls.AgTextBox
    Friend WithEvents LblBodyText As System.Windows.Forms.Label
    Friend WithEvents TxtFooterRemark As AgControls.AgTextBox
    Friend WithEvents LblFooterRemark As System.Windows.Forms.Label
    Friend WithEvents TxtPurpose As AgControls.AgTextBox
    Friend WithEvents LblPurpose As System.Windows.Forms.Label
End Class
