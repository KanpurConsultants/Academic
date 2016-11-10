<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStudentAttendance
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
        Me.BtnFillStudent = New System.Windows.Forms.Button
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
        Me.LblTimeSlotReq = New System.Windows.Forms.Label
        Me.TxtTimeSlot = New AgControls.AgTextBox
        Me.LblTimeSlot = New System.Windows.Forms.Label
        Me.LblA_DateReq = New System.Windows.Forms.Label
        Me.TxtA_Date = New AgControls.AgTextBox
        Me.LblA_Date = New System.Windows.Forms.Label
        Me.LblClassRoomReq = New System.Windows.Forms.Label
        Me.TxtClassRoom = New AgControls.AgTextBox
        Me.LblClassRoom = New System.Windows.Forms.Label
        Me.LblTeacherReq = New System.Windows.Forms.Label
        Me.TxtTeacher = New AgControls.AgTextBox
        Me.LblTeacher = New System.Windows.Forms.Label
        Me.LblSubjectReq = New System.Windows.Forms.Label
        Me.TxtSubject = New AgControls.AgTextBox
        Me.LblSubject = New System.Windows.Forms.Label
        Me.TxtClassSectionSubSection = New AgControls.AgTextBox
        Me.LblClassSectionSubSection = New System.Windows.Forms.Label
        Me.TxtSubjectType = New AgControls.AgTextBox
        Me.LblSubjectType = New System.Windows.Forms.Label
        Me.LblSubjectTypeReq = New System.Windows.Forms.Label
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
        Me.LblClassSectionReq.Location = New System.Drawing.Point(317, 111)
        Me.LblClassSectionReq.Name = "LblClassSectionReq"
        Me.LblClassSectionReq.Size = New System.Drawing.Size(10, 7)
        Me.LblClassSectionReq.TabIndex = 535
        Me.LblClassSectionReq.Text = "Ä"
        '
        'BtnFillStudent
        '
        Me.BtnFillStudent.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillStudent.Location = New System.Drawing.Point(661, 162)
        Me.BtnFillStudent.Name = "BtnFillStudent"
        Me.BtnFillStudent.Size = New System.Drawing.Size(138, 28)
        Me.BtnFillStudent.TabIndex = 9
        Me.BtnFillStudent.Text = "&Fill Student"
        Me.BtnFillStudent.UseVisualStyleBackColor = True
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
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(201, 64)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
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
        Me.TxtSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSite_Code.Location = New System.Drawing.Point(330, 59)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(325, 21)
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
        Me.TxtRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemark.Location = New System.Drawing.Point(76, 522)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(325, 21)
        Me.TxtRemark.TabIndex = 12
        Me.TxtRemark.Text = "TxtRemark"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 526)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 11
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
        Me.Label2.BackColor = System.Drawing.Color.Cornsilk
        Me.Label2.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(720, 27)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Student List"
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
        Me.Panel1.Location = New System.Drawing.Point(76, 197)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(720, 28)
        Me.Panel1.TabIndex = 524
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(76, 225)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(720, 290)
        Me.Pnl1.TabIndex = 10
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
        Me.TxtClassSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassSection.Location = New System.Drawing.Point(330, 103)
        Me.TxtClassSection.MaxLength = 50
        Me.TxtClassSection.Name = "TxtClassSection"
        Me.TxtClassSection.Size = New System.Drawing.Size(100, 21)
        Me.TxtClassSection.TabIndex = 3
        '
        'LblClassSection
        '
        Me.LblClassSection.AutoSize = True
        Me.LblClassSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSection.Location = New System.Drawing.Point(201, 106)
        Me.LblClassSection.Name = "LblClassSection"
        Me.LblClassSection.Size = New System.Drawing.Size(85, 13)
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
        Me.Topctrl1.TabIndex = 13
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
        'LblTimeSlotReq
        '
        Me.LblTimeSlotReq.AutoSize = True
        Me.LblTimeSlotReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTimeSlotReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTimeSlotReq.Location = New System.Drawing.Point(542, 88)
        Me.LblTimeSlotReq.Name = "LblTimeSlotReq"
        Me.LblTimeSlotReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTimeSlotReq.TabIndex = 540
        Me.LblTimeSlotReq.Text = "Ä"
        '
        'TxtTimeSlot
        '
        Me.TxtTimeSlot.AgMandatory = True
        Me.TxtTimeSlot.AgMasterHelp = False
        Me.TxtTimeSlot.AgNumberLeftPlaces = 0
        Me.TxtTimeSlot.AgNumberNegetiveAllow = False
        Me.TxtTimeSlot.AgNumberRightPlaces = 0
        Me.TxtTimeSlot.AgPickFromLastValue = False
        Me.TxtTimeSlot.AgRowFilter = ""
        Me.TxtTimeSlot.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTimeSlot.AgSelectedValue = Nothing
        Me.TxtTimeSlot.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTimeSlot.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTimeSlot.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTimeSlot.Location = New System.Drawing.Point(555, 81)
        Me.TxtTimeSlot.MaxLength = 50
        Me.TxtTimeSlot.Name = "TxtTimeSlot"
        Me.TxtTimeSlot.Size = New System.Drawing.Size(100, 21)
        Me.TxtTimeSlot.TabIndex = 2
        '
        'LblTimeSlot
        '
        Me.LblTimeSlot.AutoSize = True
        Me.LblTimeSlot.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTimeSlot.Location = New System.Drawing.Point(452, 85)
        Me.LblTimeSlot.Name = "LblTimeSlot"
        Me.LblTimeSlot.Size = New System.Drawing.Size(61, 13)
        Me.LblTimeSlot.TabIndex = 539
        Me.LblTimeSlot.Text = "Time Slot"
        '
        'LblA_DateReq
        '
        Me.LblA_DateReq.AutoSize = True
        Me.LblA_DateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblA_DateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblA_DateReq.Location = New System.Drawing.Point(317, 88)
        Me.LblA_DateReq.Name = "LblA_DateReq"
        Me.LblA_DateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblA_DateReq.TabIndex = 543
        Me.LblA_DateReq.Text = "Ä"
        '
        'TxtA_Date
        '
        Me.TxtA_Date.AgMandatory = True
        Me.TxtA_Date.AgMasterHelp = False
        Me.TxtA_Date.AgNumberLeftPlaces = 0
        Me.TxtA_Date.AgNumberNegetiveAllow = False
        Me.TxtA_Date.AgNumberRightPlaces = 0
        Me.TxtA_Date.AgPickFromLastValue = False
        Me.TxtA_Date.AgRowFilter = ""
        Me.TxtA_Date.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtA_Date.AgSelectedValue = Nothing
        Me.TxtA_Date.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtA_Date.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtA_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtA_Date.Location = New System.Drawing.Point(330, 81)
        Me.TxtA_Date.MaxLength = 11
        Me.TxtA_Date.Name = "TxtA_Date"
        Me.TxtA_Date.Size = New System.Drawing.Size(100, 21)
        Me.TxtA_Date.TabIndex = 1
        '
        'LblA_Date
        '
        Me.LblA_Date.AutoSize = True
        Me.LblA_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblA_Date.Location = New System.Drawing.Point(201, 85)
        Me.LblA_Date.Name = "LblA_Date"
        Me.LblA_Date.Size = New System.Drawing.Size(102, 13)
        Me.LblA_Date.TabIndex = 542
        Me.LblA_Date.Text = "Attendance Date"
        '
        'LblClassRoomReq
        '
        Me.LblClassRoomReq.AutoSize = True
        Me.LblClassRoomReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblClassRoomReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblClassRoomReq.Location = New System.Drawing.Point(317, 134)
        Me.LblClassRoomReq.Name = "LblClassRoomReq"
        Me.LblClassRoomReq.Size = New System.Drawing.Size(10, 7)
        Me.LblClassRoomReq.TabIndex = 546
        Me.LblClassRoomReq.Text = "Ä"
        '
        'TxtClassRoom
        '
        Me.TxtClassRoom.AgMandatory = True
        Me.TxtClassRoom.AgMasterHelp = False
        Me.TxtClassRoom.AgNumberLeftPlaces = 0
        Me.TxtClassRoom.AgNumberNegetiveAllow = False
        Me.TxtClassRoom.AgNumberRightPlaces = 0
        Me.TxtClassRoom.AgPickFromLastValue = False
        Me.TxtClassRoom.AgRowFilter = ""
        Me.TxtClassRoom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClassRoom.AgSelectedValue = Nothing
        Me.TxtClassRoom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClassRoom.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClassRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassRoom.Location = New System.Drawing.Point(330, 125)
        Me.TxtClassRoom.MaxLength = 50
        Me.TxtClassRoom.Name = "TxtClassRoom"
        Me.TxtClassRoom.Size = New System.Drawing.Size(100, 21)
        Me.TxtClassRoom.TabIndex = 5
        '
        'LblClassRoom
        '
        Me.LblClassRoom.AutoSize = True
        Me.LblClassRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassRoom.Location = New System.Drawing.Point(201, 128)
        Me.LblClassRoom.Name = "LblClassRoom"
        Me.LblClassRoom.Size = New System.Drawing.Size(75, 13)
        Me.LblClassRoom.TabIndex = 545
        Me.LblClassRoom.Text = "Class Room"
        '
        'LblTeacherReq
        '
        Me.LblTeacherReq.AutoSize = True
        Me.LblTeacherReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTeacherReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTeacherReq.Location = New System.Drawing.Point(317, 155)
        Me.LblTeacherReq.Name = "LblTeacherReq"
        Me.LblTeacherReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTeacherReq.TabIndex = 549
        Me.LblTeacherReq.Text = "Ä"
        '
        'TxtTeacher
        '
        Me.TxtTeacher.AgMandatory = True
        Me.TxtTeacher.AgMasterHelp = False
        Me.TxtTeacher.AgNumberLeftPlaces = 0
        Me.TxtTeacher.AgNumberNegetiveAllow = False
        Me.TxtTeacher.AgNumberRightPlaces = 0
        Me.TxtTeacher.AgPickFromLastValue = False
        Me.TxtTeacher.AgRowFilter = ""
        Me.TxtTeacher.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTeacher.AgSelectedValue = Nothing
        Me.TxtTeacher.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTeacher.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTeacher.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTeacher.Location = New System.Drawing.Point(330, 147)
        Me.TxtTeacher.MaxLength = 50
        Me.TxtTeacher.Name = "TxtTeacher"
        Me.TxtTeacher.Size = New System.Drawing.Size(325, 21)
        Me.TxtTeacher.TabIndex = 7
        '
        'LblTeacher
        '
        Me.LblTeacher.AutoSize = True
        Me.LblTeacher.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTeacher.Location = New System.Drawing.Point(201, 150)
        Me.LblTeacher.Name = "LblTeacher"
        Me.LblTeacher.Size = New System.Drawing.Size(53, 13)
        Me.LblTeacher.TabIndex = 548
        Me.LblTeacher.Text = "Teacher"
        '
        'LblSubjectReq
        '
        Me.LblSubjectReq.AutoSize = True
        Me.LblSubjectReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubjectReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubjectReq.Location = New System.Drawing.Point(317, 177)
        Me.LblSubjectReq.Name = "LblSubjectReq"
        Me.LblSubjectReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubjectReq.TabIndex = 552
        Me.LblSubjectReq.Text = "Ä"
        '
        'TxtSubject
        '
        Me.TxtSubject.AgMandatory = True
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
        Me.TxtSubject.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubject.Location = New System.Drawing.Point(330, 169)
        Me.TxtSubject.MaxLength = 50
        Me.TxtSubject.Name = "TxtSubject"
        Me.TxtSubject.Size = New System.Drawing.Size(325, 21)
        Me.TxtSubject.TabIndex = 8
        '
        'LblSubject
        '
        Me.LblSubject.AutoSize = True
        Me.LblSubject.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubject.Location = New System.Drawing.Point(201, 172)
        Me.LblSubject.Name = "LblSubject"
        Me.LblSubject.Size = New System.Drawing.Size(50, 13)
        Me.LblSubject.TabIndex = 551
        Me.LblSubject.Text = "Subject"
        '
        'TxtClassSectionSubSection
        '
        Me.TxtClassSectionSubSection.AgMandatory = False
        Me.TxtClassSectionSubSection.AgMasterHelp = False
        Me.TxtClassSectionSubSection.AgNumberLeftPlaces = 0
        Me.TxtClassSectionSubSection.AgNumberNegetiveAllow = False
        Me.TxtClassSectionSubSection.AgNumberRightPlaces = 0
        Me.TxtClassSectionSubSection.AgPickFromLastValue = False
        Me.TxtClassSectionSubSection.AgRowFilter = ""
        Me.TxtClassSectionSubSection.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtClassSectionSubSection.AgSelectedValue = Nothing
        Me.TxtClassSectionSubSection.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtClassSectionSubSection.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtClassSectionSubSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtClassSectionSubSection.Location = New System.Drawing.Point(555, 103)
        Me.TxtClassSectionSubSection.MaxLength = 50
        Me.TxtClassSectionSubSection.Name = "TxtClassSectionSubSection"
        Me.TxtClassSectionSubSection.Size = New System.Drawing.Size(100, 21)
        Me.TxtClassSectionSubSection.TabIndex = 4
        '
        'LblClassSectionSubSection
        '
        Me.LblClassSectionSubSection.AutoSize = True
        Me.LblClassSectionSubSection.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClassSectionSubSection.Location = New System.Drawing.Point(452, 107)
        Me.LblClassSectionSubSection.Name = "LblClassSectionSubSection"
        Me.LblClassSectionSubSection.Size = New System.Drawing.Size(75, 13)
        Me.LblClassSectionSubSection.TabIndex = 554
        Me.LblClassSectionSubSection.Text = "Sub Section"
        '
        'TxtSubjectType
        '
        Me.TxtSubjectType.AgMandatory = True
        Me.TxtSubjectType.AgMasterHelp = False
        Me.TxtSubjectType.AgNumberLeftPlaces = 0
        Me.TxtSubjectType.AgNumberNegetiveAllow = False
        Me.TxtSubjectType.AgNumberRightPlaces = 0
        Me.TxtSubjectType.AgPickFromLastValue = False
        Me.TxtSubjectType.AgRowFilter = ""
        Me.TxtSubjectType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubjectType.AgSelectedValue = Nothing
        Me.TxtSubjectType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubjectType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubjectType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubjectType.Location = New System.Drawing.Point(555, 125)
        Me.TxtSubjectType.MaxLength = 50
        Me.TxtSubjectType.Name = "TxtSubjectType"
        Me.TxtSubjectType.Size = New System.Drawing.Size(100, 21)
        Me.TxtSubjectType.TabIndex = 6
        '
        'LblSubjectType
        '
        Me.LblSubjectType.AutoSize = True
        Me.LblSubjectType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubjectType.Location = New System.Drawing.Point(452, 129)
        Me.LblSubjectType.Name = "LblSubjectType"
        Me.LblSubjectType.Size = New System.Drawing.Size(82, 13)
        Me.LblSubjectType.TabIndex = 556
        Me.LblSubjectType.Text = "Subject Type"
        '
        'LblSubjectTypeReq
        '
        Me.LblSubjectTypeReq.AutoSize = True
        Me.LblSubjectTypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSubjectTypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSubjectTypeReq.Location = New System.Drawing.Point(542, 132)
        Me.LblSubjectTypeReq.Name = "LblSubjectTypeReq"
        Me.LblSubjectTypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSubjectTypeReq.TabIndex = 557
        Me.LblSubjectTypeReq.Text = "Ä"
        '
        'FrmStudentAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 616)
        Me.Controls.Add(Me.TxtSubjectType)
        Me.Controls.Add(Me.LblSubjectType)
        Me.Controls.Add(Me.LblSubjectTypeReq)
        Me.Controls.Add(Me.TxtClassSectionSubSection)
        Me.Controls.Add(Me.LblClassSectionSubSection)
        Me.Controls.Add(Me.TxtTimeSlot)
        Me.Controls.Add(Me.LblTimeSlot)
        Me.Controls.Add(Me.LblSubjectReq)
        Me.Controls.Add(Me.LblTimeSlotReq)
        Me.Controls.Add(Me.TxtSubject)
        Me.Controls.Add(Me.LblA_Date)
        Me.Controls.Add(Me.LblSubject)
        Me.Controls.Add(Me.TxtA_Date)
        Me.Controls.Add(Me.LblTeacherReq)
        Me.Controls.Add(Me.LblA_DateReq)
        Me.Controls.Add(Me.TxtTeacher)
        Me.Controls.Add(Me.LblTeacher)
        Me.Controls.Add(Me.LblClassRoomReq)
        Me.Controls.Add(Me.TxtClassRoom)
        Me.Controls.Add(Me.LblClassRoom)
        Me.Controls.Add(Me.LblClassSectionReq)
        Me.Controls.Add(Me.BtnFillStudent)
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
        Me.Name = "FrmStudentAttendance"
        Me.Text = "FrmStudentAttendance"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LblClassSectionReq As System.Windows.Forms.Label
    Friend WithEvents BtnFillStudent As System.Windows.Forms.Button
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
    Friend WithEvents LblTimeSlotReq As System.Windows.Forms.Label
    Friend WithEvents TxtTimeSlot As AgControls.AgTextBox
    Friend WithEvents LblTimeSlot As System.Windows.Forms.Label
    Friend WithEvents LblA_DateReq As System.Windows.Forms.Label
    Friend WithEvents TxtA_Date As AgControls.AgTextBox
    Friend WithEvents LblA_Date As System.Windows.Forms.Label
    Friend WithEvents LblClassRoomReq As System.Windows.Forms.Label
    Friend WithEvents TxtClassRoom As AgControls.AgTextBox
    Friend WithEvents LblClassRoom As System.Windows.Forms.Label
    Friend WithEvents LblTeacherReq As System.Windows.Forms.Label
    Friend WithEvents TxtTeacher As AgControls.AgTextBox
    Friend WithEvents LblTeacher As System.Windows.Forms.Label
    Friend WithEvents LblSubjectReq As System.Windows.Forms.Label
    Friend WithEvents TxtSubject As AgControls.AgTextBox
    Friend WithEvents LblSubject As System.Windows.Forms.Label
    Friend WithEvents TxtClassSectionSubSection As AgControls.AgTextBox
    Friend WithEvents LblClassSectionSubSection As System.Windows.Forms.Label
    Friend WithEvents TxtSubjectType As AgControls.AgTextBox
    Friend WithEvents LblSubjectType As System.Windows.Forms.Label
    Friend WithEvents LblSubjectTypeReq As System.Windows.Forms.Label
End Class
