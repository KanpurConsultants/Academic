<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStudentLeave
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
        Me.LblFromDate = New System.Windows.Forms.Label
        Me.TxtFromDate = New AgControls.AgTextBox
        Me.LblFromDateReq = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.LblToDate = New System.Windows.Forms.Label
        Me.TxtToDate = New AgControls.AgTextBox
        Me.LblToDateReq = New System.Windows.Forms.Label
        Me.TxtAdmissionID = New AgControls.AgTextBox
        Me.LblAdmissionID = New System.Windows.Forms.Label
        Me.TxtAdmissionDocId = New AgControls.AgTextBox
        Me.LblAdmissionDocId = New System.Windows.Forms.Label
        Me.LblAdmissionDocIdReq = New System.Windows.Forms.Label
        Me.LblTotalDays = New System.Windows.Forms.Label
        Me.TxtTotalDays = New AgControls.AgTextBox
        Me.TxtPurposeOfLeave = New AgControls.AgTextBox
        Me.LblPurposeOfLeave = New System.Windows.Forms.Label
        Me.TxtLeavePassedBy = New AgControls.AgTextBox
        Me.LblLeavePassedBy = New System.Windows.Forms.Label
        Me.TxtLeaveApprovedBy = New AgControls.AgTextBox
        Me.LblLeaveApprovedBy = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblPurposeOfLeaveReq = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblFromDate
        '
        Me.LblFromDate.AutoSize = True
        Me.LblFromDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFromDate.Location = New System.Drawing.Point(183, 157)
        Me.LblFromDate.Name = "LblFromDate"
        Me.LblFromDate.Size = New System.Drawing.Size(65, 15)
        Me.LblFromDate.TabIndex = 549
        Me.LblFromDate.Text = "From Date"
        '
        'TxtFromDate
        '
        Me.TxtFromDate.AgMandatory = True
        Me.TxtFromDate.AgMasterHelp = False
        Me.TxtFromDate.AgNumberLeftPlaces = 0
        Me.TxtFromDate.AgNumberNegetiveAllow = False
        Me.TxtFromDate.AgNumberRightPlaces = 0
        Me.TxtFromDate.AgPickFromLastValue = False
        Me.TxtFromDate.AgRowFilter = ""
        Me.TxtFromDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFromDate.AgSelectedValue = Nothing
        Me.TxtFromDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFromDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtFromDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFromDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromDate.Location = New System.Drawing.Point(325, 153)
        Me.TxtFromDate.MaxLength = 11
        Me.TxtFromDate.Name = "TxtFromDate"
        Me.TxtFromDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtFromDate.TabIndex = 3
        '
        'LblFromDateReq
        '
        Me.LblFromDateReq.AutoSize = True
        Me.LblFromDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblFromDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblFromDateReq.Location = New System.Drawing.Point(312, 160)
        Me.LblFromDateReq.Name = "LblFromDateReq"
        Me.LblFromDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblFromDateReq.TabIndex = 550
        Me.LblFromDateReq.Text = "Ä"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(312, 121)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 547
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(183, 118)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 548
        Me.LblSite_Code.Text = "Branch/Site"
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
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSite_Code.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(325, 113)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(350, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
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
        Me.Topctrl1.TabIndex = 11
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
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(183, 277)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 15)
        Me.Label12.TabIndex = 554
        Me.Label12.Text = "Remark"
        '
        'LblToDate
        '
        Me.LblToDate.AutoSize = True
        Me.LblToDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToDate.Location = New System.Drawing.Point(493, 157)
        Me.LblToDate.Name = "LblToDate"
        Me.LblToDate.Size = New System.Drawing.Size(50, 15)
        Me.LblToDate.TabIndex = 557
        Me.LblToDate.Text = "To Date"
        '
        'TxtToDate
        '
        Me.TxtToDate.AgMandatory = True
        Me.TxtToDate.AgMasterHelp = False
        Me.TxtToDate.AgNumberLeftPlaces = 0
        Me.TxtToDate.AgNumberNegetiveAllow = False
        Me.TxtToDate.AgNumberRightPlaces = 0
        Me.TxtToDate.AgPickFromLastValue = False
        Me.TxtToDate.AgRowFilter = ""
        Me.TxtToDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtToDate.AgSelectedValue = Nothing
        Me.TxtToDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtToDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtToDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtToDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToDate.Location = New System.Drawing.Point(575, 153)
        Me.TxtToDate.MaxLength = 11
        Me.TxtToDate.Name = "TxtToDate"
        Me.TxtToDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtToDate.TabIndex = 4
        '
        'LblToDateReq
        '
        Me.LblToDateReq.AutoSize = True
        Me.LblToDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblToDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblToDateReq.Location = New System.Drawing.Point(561, 160)
        Me.LblToDateReq.Name = "LblToDateReq"
        Me.LblToDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblToDateReq.TabIndex = 558
        Me.LblToDateReq.Text = "Ä"
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
        Me.TxtAdmissionID.BackColor = System.Drawing.Color.White
        Me.TxtAdmissionID.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdmissionID.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionID.ForeColor = System.Drawing.Color.Blue
        Me.TxtAdmissionID.Location = New System.Drawing.Point(325, 193)
        Me.TxtAdmissionID.MaxLength = 21
        Me.TxtAdmissionID.Name = "TxtAdmissionID"
        Me.TxtAdmissionID.ReadOnly = True
        Me.TxtAdmissionID.Size = New System.Drawing.Size(350, 18)
        Me.TxtAdmissionID.TabIndex = 6
        Me.TxtAdmissionID.TabStop = False
        Me.TxtAdmissionID.Text = "TxtAdmissionID"
        '
        'LblAdmissionID
        '
        Me.LblAdmissionID.AutoSize = True
        Me.LblAdmissionID.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmissionID.ForeColor = System.Drawing.Color.Blue
        Me.LblAdmissionID.Location = New System.Drawing.Point(183, 197)
        Me.LblAdmissionID.Name = "LblAdmissionID"
        Me.LblAdmissionID.Size = New System.Drawing.Size(81, 15)
        Me.LblAdmissionID.TabIndex = 649
        Me.LblAdmissionID.Text = "Admission ID"
        '
        'TxtAdmissionDocId
        '
        Me.TxtAdmissionDocId.AgMandatory = True
        Me.TxtAdmissionDocId.AgMasterHelp = False
        Me.TxtAdmissionDocId.AgNumberLeftPlaces = 0
        Me.TxtAdmissionDocId.AgNumberNegetiveAllow = False
        Me.TxtAdmissionDocId.AgNumberRightPlaces = 0
        Me.TxtAdmissionDocId.AgPickFromLastValue = False
        Me.TxtAdmissionDocId.AgRowFilter = ""
        Me.TxtAdmissionDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAdmissionDocId.AgSelectedValue = Nothing
        Me.TxtAdmissionDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAdmissionDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAdmissionDocId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAdmissionDocId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionDocId.Location = New System.Drawing.Point(325, 173)
        Me.TxtAdmissionDocId.MaxLength = 123
        Me.TxtAdmissionDocId.Name = "TxtAdmissionDocId"
        Me.TxtAdmissionDocId.Size = New System.Drawing.Size(350, 18)
        Me.TxtAdmissionDocId.TabIndex = 5
        '
        'LblAdmissionDocId
        '
        Me.LblAdmissionDocId.AutoSize = True
        Me.LblAdmissionDocId.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmissionDocId.Location = New System.Drawing.Point(183, 177)
        Me.LblAdmissionDocId.Name = "LblAdmissionDocId"
        Me.LblAdmissionDocId.Size = New System.Drawing.Size(49, 15)
        Me.LblAdmissionDocId.TabIndex = 648
        Me.LblAdmissionDocId.Text = "Student"
        '
        'LblAdmissionDocIdReq
        '
        Me.LblAdmissionDocIdReq.AutoSize = True
        Me.LblAdmissionDocIdReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAdmissionDocIdReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAdmissionDocIdReq.Location = New System.Drawing.Point(312, 183)
        Me.LblAdmissionDocIdReq.Name = "LblAdmissionDocIdReq"
        Me.LblAdmissionDocIdReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAdmissionDocIdReq.TabIndex = 655
        Me.LblAdmissionDocIdReq.Text = "Ä"
        '
        'LblTotalDays
        '
        Me.LblTotalDays.AutoSize = True
        Me.LblTotalDays.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDays.ForeColor = System.Drawing.Color.Blue
        Me.LblTotalDays.Location = New System.Drawing.Point(493, 137)
        Me.LblTotalDays.Name = "LblTotalDays"
        Me.LblTotalDays.Size = New System.Drawing.Size(65, 15)
        Me.LblTotalDays.TabIndex = 657
        Me.LblTotalDays.Text = "Total Days"
        '
        'TxtTotalDays
        '
        Me.TxtTotalDays.AgMandatory = True
        Me.TxtTotalDays.AgMasterHelp = False
        Me.TxtTotalDays.AgNumberLeftPlaces = 8
        Me.TxtTotalDays.AgNumberNegetiveAllow = False
        Me.TxtTotalDays.AgNumberRightPlaces = 0
        Me.TxtTotalDays.AgPickFromLastValue = False
        Me.TxtTotalDays.AgRowFilter = ""
        Me.TxtTotalDays.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalDays.AgSelectedValue = Nothing
        Me.TxtTotalDays.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalDays.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalDays.BackColor = System.Drawing.Color.White
        Me.TxtTotalDays.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTotalDays.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalDays.ForeColor = System.Drawing.Color.Blue
        Me.TxtTotalDays.Location = New System.Drawing.Point(575, 133)
        Me.TxtTotalDays.Name = "TxtTotalDays"
        Me.TxtTotalDays.ReadOnly = True
        Me.TxtTotalDays.Size = New System.Drawing.Size(100, 18)
        Me.TxtTotalDays.TabIndex = 2
        Me.TxtTotalDays.TabStop = False
        Me.TxtTotalDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtPurposeOfLeave
        '
        Me.TxtPurposeOfLeave.AgMandatory = True
        Me.TxtPurposeOfLeave.AgMasterHelp = False
        Me.TxtPurposeOfLeave.AgNumberLeftPlaces = 0
        Me.TxtPurposeOfLeave.AgNumberNegetiveAllow = False
        Me.TxtPurposeOfLeave.AgNumberRightPlaces = 0
        Me.TxtPurposeOfLeave.AgPickFromLastValue = False
        Me.TxtPurposeOfLeave.AgRowFilter = ""
        Me.TxtPurposeOfLeave.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPurposeOfLeave.AgSelectedValue = Nothing
        Me.TxtPurposeOfLeave.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPurposeOfLeave.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPurposeOfLeave.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPurposeOfLeave.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPurposeOfLeave.Location = New System.Drawing.Point(325, 213)
        Me.TxtPurposeOfLeave.MaxLength = 100
        Me.TxtPurposeOfLeave.Name = "TxtPurposeOfLeave"
        Me.TxtPurposeOfLeave.Size = New System.Drawing.Size(350, 18)
        Me.TxtPurposeOfLeave.TabIndex = 7
        '
        'LblPurposeOfLeave
        '
        Me.LblPurposeOfLeave.AutoSize = True
        Me.LblPurposeOfLeave.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPurposeOfLeave.Location = New System.Drawing.Point(183, 217)
        Me.LblPurposeOfLeave.Name = "LblPurposeOfLeave"
        Me.LblPurposeOfLeave.Size = New System.Drawing.Size(103, 15)
        Me.LblPurposeOfLeave.TabIndex = 658
        Me.LblPurposeOfLeave.Text = "Purpose of Leave"
        '
        'TxtLeavePassedBy
        '
        Me.TxtLeavePassedBy.AgMandatory = True
        Me.TxtLeavePassedBy.AgMasterHelp = False
        Me.TxtLeavePassedBy.AgNumberLeftPlaces = 0
        Me.TxtLeavePassedBy.AgNumberNegetiveAllow = False
        Me.TxtLeavePassedBy.AgNumberRightPlaces = 0
        Me.TxtLeavePassedBy.AgPickFromLastValue = False
        Me.TxtLeavePassedBy.AgRowFilter = ""
        Me.TxtLeavePassedBy.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLeavePassedBy.AgSelectedValue = Nothing
        Me.TxtLeavePassedBy.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLeavePassedBy.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtLeavePassedBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLeavePassedBy.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLeavePassedBy.Location = New System.Drawing.Point(325, 233)
        Me.TxtLeavePassedBy.MaxLength = 123
        Me.TxtLeavePassedBy.Name = "TxtLeavePassedBy"
        Me.TxtLeavePassedBy.Size = New System.Drawing.Size(350, 18)
        Me.TxtLeavePassedBy.TabIndex = 8
        '
        'LblLeavePassedBy
        '
        Me.LblLeavePassedBy.AutoSize = True
        Me.LblLeavePassedBy.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLeavePassedBy.Location = New System.Drawing.Point(183, 237)
        Me.LblLeavePassedBy.Name = "LblLeavePassedBy"
        Me.LblLeavePassedBy.Size = New System.Drawing.Size(66, 15)
        Me.LblLeavePassedBy.TabIndex = 660
        Me.LblLeavePassedBy.Text = "Passed By"
        '
        'TxtLeaveApprovedBy
        '
        Me.TxtLeaveApprovedBy.AgMandatory = True
        Me.TxtLeaveApprovedBy.AgMasterHelp = False
        Me.TxtLeaveApprovedBy.AgNumberLeftPlaces = 0
        Me.TxtLeaveApprovedBy.AgNumberNegetiveAllow = False
        Me.TxtLeaveApprovedBy.AgNumberRightPlaces = 0
        Me.TxtLeaveApprovedBy.AgPickFromLastValue = False
        Me.TxtLeaveApprovedBy.AgRowFilter = ""
        Me.TxtLeaveApprovedBy.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLeaveApprovedBy.AgSelectedValue = Nothing
        Me.TxtLeaveApprovedBy.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLeaveApprovedBy.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtLeaveApprovedBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLeaveApprovedBy.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLeaveApprovedBy.Location = New System.Drawing.Point(325, 253)
        Me.TxtLeaveApprovedBy.MaxLength = 123
        Me.TxtLeaveApprovedBy.Name = "TxtLeaveApprovedBy"
        Me.TxtLeaveApprovedBy.Size = New System.Drawing.Size(350, 18)
        Me.TxtLeaveApprovedBy.TabIndex = 9
        '
        'LblLeaveApprovedBy
        '
        Me.LblLeaveApprovedBy.AutoSize = True
        Me.LblLeaveApprovedBy.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLeaveApprovedBy.Location = New System.Drawing.Point(183, 257)
        Me.LblLeaveApprovedBy.Name = "LblLeaveApprovedBy"
        Me.LblLeaveApprovedBy.Size = New System.Drawing.Size(74, 15)
        Me.LblLeaveApprovedBy.TabIndex = 664
        Me.LblLeaveApprovedBy.Text = "Approved By"
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
        Me.TxtRemark.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemark.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemark.Location = New System.Drawing.Point(325, 273)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(350, 18)
        Me.TxtRemark.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(312, 242)
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
        Me.Label5.Location = New System.Drawing.Point(312, 265)
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
        Me.LblPurposeOfLeaveReq.Location = New System.Drawing.Point(312, 222)
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
        Me.Label2.Location = New System.Drawing.Point(312, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 671
        Me.Label2.Text = "Ä"
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(183, 138)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(63, 15)
        Me.LblV_Date.TabIndex = 670
        Me.LblV_Date.Text = "Entry Date"
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
        Me.TxtV_Date.Location = New System.Drawing.Point(325, 133)
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 18)
        Me.TxtV_Date.TabIndex = 1
        Me.TxtV_Date.Text = "TxtV_Date"
        '
        'FrmStudentLeave
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 466)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.LblPurposeOfLeaveReq)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtLeaveApprovedBy)
        Me.Controls.Add(Me.LblLeaveApprovedBy)
        Me.Controls.Add(Me.TxtLeavePassedBy)
        Me.Controls.Add(Me.LblLeavePassedBy)
        Me.Controls.Add(Me.TxtPurposeOfLeave)
        Me.Controls.Add(Me.LblPurposeOfLeave)
        Me.Controls.Add(Me.LblTotalDays)
        Me.Controls.Add(Me.TxtTotalDays)
        Me.Controls.Add(Me.LblAdmissionDocIdReq)
        Me.Controls.Add(Me.TxtAdmissionID)
        Me.Controls.Add(Me.LblAdmissionID)
        Me.Controls.Add(Me.TxtAdmissionDocId)
        Me.Controls.Add(Me.LblAdmissionDocId)
        Me.Controls.Add(Me.LblToDate)
        Me.Controls.Add(Me.TxtToDate)
        Me.Controls.Add(Me.LblToDateReq)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.LblFromDate)
        Me.Controls.Add(Me.TxtFromDate)
        Me.Controls.Add(Me.LblFromDateReq)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.Name = "FrmStudentLeave"
        Me.Text = "Student Leave Entry"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblFromDate As System.Windows.Forms.Label
    Friend WithEvents TxtFromDate As AgControls.AgTextBox
    Friend WithEvents LblFromDateReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents LblToDate As System.Windows.Forms.Label
    Friend WithEvents TxtToDate As AgControls.AgTextBox
    Friend WithEvents LblToDateReq As System.Windows.Forms.Label
    Friend WithEvents TxtAdmissionID As AgControls.AgTextBox
    Friend WithEvents LblAdmissionID As System.Windows.Forms.Label
    Friend WithEvents TxtAdmissionDocId As AgControls.AgTextBox
    Friend WithEvents LblAdmissionDocId As System.Windows.Forms.Label
    Friend WithEvents LblAdmissionDocIdReq As System.Windows.Forms.Label
    Friend WithEvents LblTotalDays As System.Windows.Forms.Label
    Friend WithEvents TxtTotalDays As AgControls.AgTextBox
    Friend WithEvents TxtPurposeOfLeave As AgControls.AgTextBox
    Friend WithEvents LblPurposeOfLeave As System.Windows.Forms.Label
    Friend WithEvents TxtLeavePassedBy As AgControls.AgTextBox
    Friend WithEvents LblLeavePassedBy As System.Windows.Forms.Label
    Friend WithEvents TxtLeaveApprovedBy As AgControls.AgTextBox
    Friend WithEvents LblLeaveApprovedBy As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents LblPurposeOfLeaveReq As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblV_Date As System.Windows.Forms.Label
    Friend WithEvents TxtV_Date As AgControls.AgTextBox
End Class
