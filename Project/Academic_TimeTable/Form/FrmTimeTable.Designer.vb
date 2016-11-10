<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTimeTable
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
        Me.LblClassSectionReq = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.TxtRemark = New AgControls.AgTextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtClassSection = New AgControls.AgTextBox
        Me.LblClassSection = New System.Windows.Forms.Label
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.LblApplyDateReq = New System.Windows.Forms.Label
        Me.TxtApplyDate = New AgControls.AgTextBox
        Me.LblApplyDate = New System.Windows.Forms.Label
        Me.LblWeekDayReq = New System.Windows.Forms.Label
        Me.TxtWeekDay = New AgControls.AgTextBox
        Me.LblWeekDay = New System.Windows.Forms.Label
        Me.LblSession = New System.Windows.Forms.Label
        Me.LblSessionReq = New System.Windows.Forms.Label
        Me.TxtSession = New AgControls.AgTextBox
        Me.TxtCopyFrom = New AgControls.AgTextBox
        Me.LblCopyFrom = New System.Windows.Forms.Label
        Me.BtnFillTimeSlot = New System.Windows.Forms.Button
        Me.LblIsAllTimeSlot = New System.Windows.Forms.Label
        Me.TxtIsAllTimeSlot = New AgControls.AgTextBox
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblClassSectionReq
        '
        Me.LblClassSectionReq.AutoSize = True
        Me.LblClassSectionReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblClassSectionReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblClassSectionReq.Location = New System.Drawing.Point(542, 87)
        Me.LblClassSectionReq.Name = "LblClassSectionReq"
        Me.LblClassSectionReq.Size = New System.Drawing.Size(10, 7)
        Me.LblClassSectionReq.TabIndex = 535
        Me.LblClassSectionReq.Text = "Ä"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(317, 67)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 531
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(201, 64)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 532
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(330, 59)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
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
        Me.TxtRemark.Location = New System.Drawing.Point(76, 522)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(325, 18)
        Me.TxtRemark.TabIndex = 10
        Me.TxtRemark.Text = "TxtRemark"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 526)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 15)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "&Remark"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(-4, 549)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 4)
        Me.GroupBox2.TabIndex = 525
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
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
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(8, 559)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 526
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
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LightCyan
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(837, 27)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Day Schedule"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(672, 559)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 527
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(21, 170)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(837, 28)
        Me.Panel1.TabIndex = 524
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(22, 199)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(836, 312)
        Me.Pnl1.TabIndex = 8
        '
        'TxtClassSection
        '
        Me.TxtClassSection.AgMandatory = True
        Me.TxtClassSection.AgMasterHelp = False
        Me.TxtClassSection.AgNumberLeftPlaces = 0
        Me.TxtClassSection.AgNumberNegetiveAllow = False
        Me.TxtClassSection.AgNumberRightPlaces = 0
        Me.TxtClassSection.AgPickFromLastValue = False
        Me.TxtClassSection.AgRowFilter = ""
        Me.TxtClassSection.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClassSection.AgSelectedValue = Nothing
        Me.TxtClassSection.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClassSection.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClassSection.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtClassSection.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassSection.Location = New System.Drawing.Point(555, 79)
        Me.TxtClassSection.MaxLength = 50
        Me.TxtClassSection.Name = "TxtClassSection"
        Me.TxtClassSection.Size = New System.Drawing.Size(100, 18)
        Me.TxtClassSection.TabIndex = 2
        '
        'LblClassSection
        '
        Me.LblClassSection.AutoSize = True
        Me.LblClassSection.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSection.Location = New System.Drawing.Point(451, 82)
        Me.LblClassSection.Name = "LblClassSection"
        Me.LblClassSection.Size = New System.Drawing.Size(84, 15)
        Me.LblClassSection.TabIndex = 520
        Me.LblClassSection.Text = "Class/Section"
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
        'LblApplyDateReq
        '
        Me.LblApplyDateReq.AutoSize = True
        Me.LblApplyDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblApplyDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblApplyDateReq.Location = New System.Drawing.Point(542, 106)
        Me.LblApplyDateReq.Name = "LblApplyDateReq"
        Me.LblApplyDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblApplyDateReq.TabIndex = 543
        Me.LblApplyDateReq.Text = "Ä"
        '
        'TxtApplyDate
        '
        Me.TxtApplyDate.AgMandatory = True
        Me.TxtApplyDate.AgMasterHelp = False
        Me.TxtApplyDate.AgNumberLeftPlaces = 0
        Me.TxtApplyDate.AgNumberNegetiveAllow = False
        Me.TxtApplyDate.AgNumberRightPlaces = 0
        Me.TxtApplyDate.AgPickFromLastValue = False
        Me.TxtApplyDate.AgRowFilter = ""
        Me.TxtApplyDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtApplyDate.AgSelectedValue = Nothing
        Me.TxtApplyDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtApplyDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtApplyDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtApplyDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApplyDate.Location = New System.Drawing.Point(555, 99)
        Me.TxtApplyDate.MaxLength = 11
        Me.TxtApplyDate.Name = "TxtApplyDate"
        Me.TxtApplyDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtApplyDate.TabIndex = 4
        '
        'LblApplyDate
        '
        Me.LblApplyDate.AutoSize = True
        Me.LblApplyDate.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblApplyDate.Location = New System.Drawing.Point(451, 103)
        Me.LblApplyDate.Name = "LblApplyDate"
        Me.LblApplyDate.Size = New System.Drawing.Size(65, 15)
        Me.LblApplyDate.TabIndex = 542
        Me.LblApplyDate.Text = "Apply Date"
        '
        'LblWeekDayReq
        '
        Me.LblWeekDayReq.AutoSize = True
        Me.LblWeekDayReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblWeekDayReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblWeekDayReq.Location = New System.Drawing.Point(317, 107)
        Me.LblWeekDayReq.Name = "LblWeekDayReq"
        Me.LblWeekDayReq.Size = New System.Drawing.Size(10, 7)
        Me.LblWeekDayReq.TabIndex = 546
        Me.LblWeekDayReq.Text = "Ä"
        '
        'TxtWeekDay
        '
        Me.TxtWeekDay.AgMandatory = True
        Me.TxtWeekDay.AgMasterHelp = False
        Me.TxtWeekDay.AgNumberLeftPlaces = 0
        Me.TxtWeekDay.AgNumberNegetiveAllow = False
        Me.TxtWeekDay.AgNumberRightPlaces = 0
        Me.TxtWeekDay.AgPickFromLastValue = False
        Me.TxtWeekDay.AgRowFilter = ""
        Me.TxtWeekDay.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtWeekDay.AgSelectedValue = Nothing
        Me.TxtWeekDay.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtWeekDay.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtWeekDay.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtWeekDay.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtWeekDay.Location = New System.Drawing.Point(330, 99)
        Me.TxtWeekDay.MaxLength = 50
        Me.TxtWeekDay.Name = "TxtWeekDay"
        Me.TxtWeekDay.Size = New System.Drawing.Size(100, 18)
        Me.TxtWeekDay.TabIndex = 3
        '
        'LblWeekDay
        '
        Me.LblWeekDay.AutoSize = True
        Me.LblWeekDay.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblWeekDay.Location = New System.Drawing.Point(201, 102)
        Me.LblWeekDay.Name = "LblWeekDay"
        Me.LblWeekDay.Size = New System.Drawing.Size(62, 15)
        Me.LblWeekDay.TabIndex = 545
        Me.LblWeekDay.Text = "Week Day"
        '
        'LblSession
        '
        Me.LblSession.AutoSize = True
        Me.LblSession.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSession.Location = New System.Drawing.Point(201, 82)
        Me.LblSession.Name = "LblSession"
        Me.LblSession.Size = New System.Drawing.Size(53, 15)
        Me.LblSession.TabIndex = 548
        Me.LblSession.Text = "Session"
        '
        'LblSessionReq
        '
        Me.LblSessionReq.AutoSize = True
        Me.LblSessionReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSessionReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSessionReq.Location = New System.Drawing.Point(317, 87)
        Me.LblSessionReq.Name = "LblSessionReq"
        Me.LblSessionReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSessionReq.TabIndex = 549
        Me.LblSessionReq.Text = "Ä"
        '
        'TxtSession
        '
        Me.TxtSession.AgMandatory = True
        Me.TxtSession.AgMasterHelp = False
        Me.TxtSession.AgNumberLeftPlaces = 0
        Me.TxtSession.AgNumberNegetiveAllow = False
        Me.TxtSession.AgNumberRightPlaces = 0
        Me.TxtSession.AgPickFromLastValue = False
        Me.TxtSession.AgRowFilter = ""
        Me.TxtSession.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSession.AgSelectedValue = Nothing
        Me.TxtSession.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSession.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSession.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSession.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSession.Location = New System.Drawing.Point(330, 79)
        Me.TxtSession.MaxLength = 50
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(100, 18)
        Me.TxtSession.TabIndex = 1
        '
        'TxtCopyFrom
        '
        Me.TxtCopyFrom.AgMandatory = False
        Me.TxtCopyFrom.AgMasterHelp = False
        Me.TxtCopyFrom.AgNumberLeftPlaces = 0
        Me.TxtCopyFrom.AgNumberNegetiveAllow = False
        Me.TxtCopyFrom.AgNumberRightPlaces = 0
        Me.TxtCopyFrom.AgPickFromLastValue = False
        Me.TxtCopyFrom.AgRowFilter = ""
        Me.TxtCopyFrom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCopyFrom.AgSelectedValue = Nothing
        Me.TxtCopyFrom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCopyFrom.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCopyFrom.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCopyFrom.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCopyFrom.Location = New System.Drawing.Point(330, 119)
        Me.TxtCopyFrom.MaxLength = 50
        Me.TxtCopyFrom.Name = "TxtCopyFrom"
        Me.TxtCopyFrom.Size = New System.Drawing.Size(325, 18)
        Me.TxtCopyFrom.TabIndex = 5
        '
        'LblCopyFrom
        '
        Me.LblCopyFrom.AutoSize = True
        Me.LblCopyFrom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCopyFrom.Location = New System.Drawing.Point(201, 122)
        Me.LblCopyFrom.Name = "LblCopyFrom"
        Me.LblCopyFrom.Size = New System.Drawing.Size(67, 15)
        Me.LblCopyFrom.TabIndex = 551
        Me.LblCopyFrom.Text = "Copy From"
        '
        'BtnFillTimeSlot
        '
        Me.BtnFillTimeSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillTimeSlot.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillTimeSlot.Location = New System.Drawing.Point(555, 140)
        Me.BtnFillTimeSlot.Name = "BtnFillTimeSlot"
        Me.BtnFillTimeSlot.Size = New System.Drawing.Size(100, 27)
        Me.BtnFillTimeSlot.TabIndex = 7
        Me.BtnFillTimeSlot.Text = "&Fill Time Slot"
        Me.BtnFillTimeSlot.UseVisualStyleBackColor = True
        '
        'LblIsAllTimeSlot
        '
        Me.LblIsAllTimeSlot.AutoSize = True
        Me.LblIsAllTimeSlot.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsAllTimeSlot.Location = New System.Drawing.Point(201, 142)
        Me.LblIsAllTimeSlot.Name = "LblIsAllTimeSlot"
        Me.LblIsAllTimeSlot.Size = New System.Drawing.Size(96, 15)
        Me.LblIsAllTimeSlot.TabIndex = 553
        Me.LblIsAllTimeSlot.Text = "Is All Time-Slot?"
        '
        'TxtIsAllTimeSlot
        '
        Me.TxtIsAllTimeSlot.AgMandatory = False
        Me.TxtIsAllTimeSlot.AgMasterHelp = False
        Me.TxtIsAllTimeSlot.AgNumberLeftPlaces = 0
        Me.TxtIsAllTimeSlot.AgNumberNegetiveAllow = False
        Me.TxtIsAllTimeSlot.AgNumberRightPlaces = 0
        Me.TxtIsAllTimeSlot.AgPickFromLastValue = False
        Me.TxtIsAllTimeSlot.AgRowFilter = ""
        Me.TxtIsAllTimeSlot.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsAllTimeSlot.AgSelectedValue = Nothing
        Me.TxtIsAllTimeSlot.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsAllTimeSlot.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsAllTimeSlot.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIsAllTimeSlot.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsAllTimeSlot.Location = New System.Drawing.Point(330, 139)
        Me.TxtIsAllTimeSlot.MaxLength = 3
        Me.TxtIsAllTimeSlot.Name = "TxtIsAllTimeSlot"
        Me.TxtIsAllTimeSlot.Size = New System.Drawing.Size(100, 18)
        Me.TxtIsAllTimeSlot.TabIndex = 6
        '
        'FrmTimeTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 616)
        Me.Controls.Add(Me.TxtIsAllTimeSlot)
        Me.Controls.Add(Me.LblIsAllTimeSlot)
        Me.Controls.Add(Me.BtnFillTimeSlot)
        Me.Controls.Add(Me.TxtCopyFrom)
        Me.Controls.Add(Me.LblCopyFrom)
        Me.Controls.Add(Me.LblSessionReq)
        Me.Controls.Add(Me.TxtSession)
        Me.Controls.Add(Me.LblSession)
        Me.Controls.Add(Me.LblWeekDayReq)
        Me.Controls.Add(Me.TxtWeekDay)
        Me.Controls.Add(Me.LblWeekDay)
        Me.Controls.Add(Me.LblApplyDate)
        Me.Controls.Add(Me.TxtApplyDate)
        Me.Controls.Add(Me.LblApplyDateReq)
        Me.Controls.Add(Me.LblClassSectionReq)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtClassSection)
        Me.Controls.Add(Me.LblClassSection)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmTimeTable"
        Me.Text = "Time Table"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblClassSectionReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtClassSection As AgControls.AgTextBox
    Friend WithEvents LblClassSection As System.Windows.Forms.Label
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblApplyDateReq As System.Windows.Forms.Label
    Friend WithEvents TxtApplyDate As AgControls.AgTextBox
    Friend WithEvents LblApplyDate As System.Windows.Forms.Label
    Friend WithEvents LblWeekDayReq As System.Windows.Forms.Label
    Friend WithEvents TxtWeekDay As AgControls.AgTextBox
    Friend WithEvents LblWeekDay As System.Windows.Forms.Label
    Friend WithEvents LblSession As System.Windows.Forms.Label
    Friend WithEvents LblSessionReq As System.Windows.Forms.Label
    Friend WithEvents TxtSession As AgControls.AgTextBox
    Friend WithEvents TxtCopyFrom As AgControls.AgTextBox
    Friend WithEvents LblCopyFrom As System.Windows.Forms.Label
    Friend WithEvents BtnFillTimeSlot As System.Windows.Forms.Button
    Friend WithEvents LblIsAllTimeSlot As System.Windows.Forms.Label
    Friend WithEvents TxtIsAllTimeSlot As AgControls.AgTextBox
End Class
