<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmployeeDayAttendance
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
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.LblA_DateReq = New System.Windows.Forms.Label
        Me.TxtA_Date = New AgControls.AgTextBox
        Me.LblA_Date = New System.Windows.Forms.Label
        Me.LblTotalPresent = New System.Windows.Forms.Label
        Me.TxtTotalPresent = New AgControls.AgTextBox
        Me.LblTotalAbsent = New System.Windows.Forms.Label
        Me.TxtTotalAbsent = New AgControls.AgTextBox
        Me.LblTotalEmployee = New System.Windows.Forms.Label
        Me.TxtTotalEmployee = New AgControls.AgTextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.GBoxImportFromExcel = New System.Windows.Forms.GroupBox
        Me.TxtToDate = New AgControls.AgTextBox
        Me.BtnImprtFromDB = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtFromDate = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GBoxImportFromExcel.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnFillStudent
        '
        Me.BtnFillStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillStudent.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillStudent.Location = New System.Drawing.Point(578, 118)
        Me.BtnFillStudent.Name = "BtnFillStudent"
        Me.BtnFillStudent.Size = New System.Drawing.Size(100, 23)
        Me.BtnFillStudent.TabIndex = 2
        Me.BtnFillStudent.Text = "&Fill Teacher"
        Me.BtnFillStudent.UseVisualStyleBackColor = True
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(286, 60)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 531
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(170, 57)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(70, 15)
        Me.LblSite_Code.TabIndex = 532
        Me.LblSite_Code.Text = "Branch/Site"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(299, 52)
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
        Me.TxtRemark.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtRemark.TabIndex = 5
        Me.TxtRemark.Text = "TxtRemark"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 526)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 15)
        Me.Label12.TabIndex = 4
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
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.TxtModified)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox4.Location = New System.Drawing.Point(674, 559)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 527
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(178, 141)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(500, 375)
        Me.Pnl1.TabIndex = 3
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
        Me.Topctrl1.TabIndex = 6
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
        'LblA_DateReq
        '
        Me.LblA_DateReq.AutoSize = True
        Me.LblA_DateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblA_DateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblA_DateReq.Location = New System.Drawing.Point(286, 79)
        Me.LblA_DateReq.Name = "LblA_DateReq"
        Me.LblA_DateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblA_DateReq.TabIndex = 543
        Me.LblA_DateReq.Text = "Ä"
        '
        'TxtA_Date
        '
        Me.TxtA_Date.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtA_Date.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtA_Date.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtA_Date.Location = New System.Drawing.Point(299, 72)
        Me.TxtA_Date.MaxLength = 11
        Me.TxtA_Date.Name = "TxtA_Date"
        Me.TxtA_Date.Size = New System.Drawing.Size(100, 18)
        Me.TxtA_Date.TabIndex = 1
        '
        'LblA_Date
        '
        Me.LblA_Date.AutoSize = True
        Me.LblA_Date.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblA_Date.Location = New System.Drawing.Point(170, 76)
        Me.LblA_Date.Name = "LblA_Date"
        Me.LblA_Date.Size = New System.Drawing.Size(97, 15)
        Me.LblA_Date.TabIndex = 542
        Me.LblA_Date.Text = "Attendance Date"
        '
        'LblTotalPresent
        '
        Me.LblTotalPresent.AutoSize = True
        Me.LblTotalPresent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalPresent.Location = New System.Drawing.Point(682, 485)
        Me.LblTotalPresent.Name = "LblTotalPresent"
        Me.LblTotalPresent.Size = New System.Drawing.Size(80, 15)
        Me.LblTotalPresent.TabIndex = 545
        Me.LblTotalPresent.Text = "Total Present"
        '
        'TxtTotalPresent
        '
        Me.TxtTotalPresent.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalPresent.AgMandatory = False
        Me.TxtTotalPresent.AgMasterHelp = False
        Me.TxtTotalPresent.AgNumberLeftPlaces = 8
        Me.TxtTotalPresent.AgNumberNegetiveAllow = False
        Me.TxtTotalPresent.AgNumberRightPlaces = 0
        Me.TxtTotalPresent.AgPickFromLastValue = False
        Me.TxtTotalPresent.AgRowFilter = ""
        Me.TxtTotalPresent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalPresent.AgSelectedValue = Nothing
        Me.TxtTotalPresent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalPresent.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalPresent.BackColor = System.Drawing.Color.White
        Me.TxtTotalPresent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTotalPresent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalPresent.Location = New System.Drawing.Point(766, 482)
        Me.TxtTotalPresent.MaxLength = 11
        Me.TxtTotalPresent.Name = "TxtTotalPresent"
        Me.TxtTotalPresent.ReadOnly = True
        Me.TxtTotalPresent.Size = New System.Drawing.Size(100, 18)
        Me.TxtTotalPresent.TabIndex = 544
        Me.TxtTotalPresent.TabStop = False
        Me.TxtTotalPresent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalAbsent
        '
        Me.LblTotalAbsent.AutoSize = True
        Me.LblTotalAbsent.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAbsent.Location = New System.Drawing.Point(682, 505)
        Me.LblTotalAbsent.Name = "LblTotalAbsent"
        Me.LblTotalAbsent.Size = New System.Drawing.Size(75, 15)
        Me.LblTotalAbsent.TabIndex = 547
        Me.LblTotalAbsent.Text = "Total Absent"
        '
        'TxtTotalAbsent
        '
        Me.TxtTotalAbsent.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalAbsent.AgMandatory = False
        Me.TxtTotalAbsent.AgMasterHelp = False
        Me.TxtTotalAbsent.AgNumberLeftPlaces = 8
        Me.TxtTotalAbsent.AgNumberNegetiveAllow = False
        Me.TxtTotalAbsent.AgNumberRightPlaces = 0
        Me.TxtTotalAbsent.AgPickFromLastValue = False
        Me.TxtTotalAbsent.AgRowFilter = ""
        Me.TxtTotalAbsent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalAbsent.AgSelectedValue = Nothing
        Me.TxtTotalAbsent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalAbsent.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalAbsent.BackColor = System.Drawing.Color.White
        Me.TxtTotalAbsent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTotalAbsent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalAbsent.Location = New System.Drawing.Point(766, 502)
        Me.TxtTotalAbsent.MaxLength = 11
        Me.TxtTotalAbsent.Name = "TxtTotalAbsent"
        Me.TxtTotalAbsent.ReadOnly = True
        Me.TxtTotalAbsent.Size = New System.Drawing.Size(100, 18)
        Me.TxtTotalAbsent.TabIndex = 546
        Me.TxtTotalAbsent.TabStop = False
        Me.TxtTotalAbsent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblTotalEmployee
        '
        Me.LblTotalEmployee.AutoSize = True
        Me.LblTotalEmployee.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalEmployee.Location = New System.Drawing.Point(682, 526)
        Me.LblTotalEmployee.Name = "LblTotalEmployee"
        Me.LblTotalEmployee.Size = New System.Drawing.Size(34, 15)
        Me.LblTotalEmployee.TabIndex = 549
        Me.LblTotalEmployee.Text = "Total"
        '
        'TxtTotalEmployee
        '
        Me.TxtTotalEmployee.AgAllowUserToEnableMasterHelp = False
        Me.TxtTotalEmployee.AgMandatory = False
        Me.TxtTotalEmployee.AgMasterHelp = False
        Me.TxtTotalEmployee.AgNumberLeftPlaces = 8
        Me.TxtTotalEmployee.AgNumberNegetiveAllow = False
        Me.TxtTotalEmployee.AgNumberRightPlaces = 0
        Me.TxtTotalEmployee.AgPickFromLastValue = False
        Me.TxtTotalEmployee.AgRowFilter = ""
        Me.TxtTotalEmployee.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalEmployee.AgSelectedValue = Nothing
        Me.TxtTotalEmployee.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalEmployee.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalEmployee.BackColor = System.Drawing.Color.White
        Me.TxtTotalEmployee.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTotalEmployee.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalEmployee.Location = New System.Drawing.Point(766, 522)
        Me.TxtTotalEmployee.MaxLength = 11
        Me.TxtTotalEmployee.Name = "TxtTotalEmployee"
        Me.TxtTotalEmployee.ReadOnly = True
        Me.TxtTotalEmployee.Size = New System.Drawing.Size(100, 18)
        Me.TxtTotalEmployee.TabIndex = 548
        Me.TxtTotalEmployee.TabStop = False
        Me.TxtTotalEmployee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(175, 121)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(107, 20)
        Me.LinkLabel1.TabIndex = 740
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "TEACHER LIST"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GBoxImportFromExcel
        '
        Me.GBoxImportFromExcel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GBoxImportFromExcel.BackColor = System.Drawing.Color.Transparent
        Me.GBoxImportFromExcel.Controls.Add(Me.TxtToDate)
        Me.GBoxImportFromExcel.Controls.Add(Me.BtnImprtFromDB)
        Me.GBoxImportFromExcel.Controls.Add(Me.Label2)
        Me.GBoxImportFromExcel.Controls.Add(Me.TxtFromDate)
        Me.GBoxImportFromExcel.Controls.Add(Me.Label1)
        Me.GBoxImportFromExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GBoxImportFromExcel.Font = New System.Drawing.Font("Courier New", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GBoxImportFromExcel.ForeColor = System.Drawing.Color.Maroon
        Me.GBoxImportFromExcel.Location = New System.Drawing.Point(639, 45)
        Me.GBoxImportFromExcel.Name = "GBoxImportFromExcel"
        Me.GBoxImportFromExcel.Size = New System.Drawing.Size(221, 64)
        Me.GBoxImportFromExcel.TabIndex = 903
        Me.GBoxImportFromExcel.TabStop = False
        Me.GBoxImportFromExcel.Tag = "UP"
        Me.GBoxImportFromExcel.Text = "Import"
        '
        'TxtToDate
        '
        Me.TxtToDate.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtToDate.Location = New System.Drawing.Point(69, 38)
        Me.TxtToDate.MaxLength = 11
        Me.TxtToDate.Name = "TxtToDate"
        Me.TxtToDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtToDate.TabIndex = 1
        '
        'BtnImprtFromDB
        '
        Me.BtnImprtFromDB.BackColor = System.Drawing.Color.White
        Me.BtnImprtFromDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprtFromDB.Image = Global.Academic_TimeTable.My.Resources.Resources.update_database
        Me.BtnImprtFromDB.Location = New System.Drawing.Point(176, 19)
        Me.BtnImprtFromDB.Name = "BtnImprtFromDB"
        Me.BtnImprtFromDB.Size = New System.Drawing.Size(36, 34)
        Me.BtnImprtFromDB.TabIndex = 2
        Me.BtnImprtFromDB.TabStop = False
        Me.BtnImprtFromDB.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(5, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 907
        Me.Label2.Text = "To Date "
        '
        'TxtFromDate
        '
        Me.TxtFromDate.AgAllowUserToEnableMasterHelp = False
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
        Me.TxtFromDate.Location = New System.Drawing.Point(69, 18)
        Me.TxtFromDate.MaxLength = 11
        Me.TxtFromDate.Name = "TxtFromDate"
        Me.TxtFromDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtFromDate.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 15)
        Me.Label1.TabIndex = 905
        Me.Label1.Text = "From Date"
        '
        'FrmEmployeeDayAttendance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 616)
        Me.Controls.Add(Me.GBoxImportFromExcel)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.LblTotalEmployee)
        Me.Controls.Add(Me.TxtTotalEmployee)
        Me.Controls.Add(Me.LblTotalAbsent)
        Me.Controls.Add(Me.TxtTotalAbsent)
        Me.Controls.Add(Me.LblTotalPresent)
        Me.Controls.Add(Me.TxtTotalPresent)
        Me.Controls.Add(Me.LblA_Date)
        Me.Controls.Add(Me.TxtA_Date)
        Me.Controls.Add(Me.LblA_DateReq)
        Me.Controls.Add(Me.BtnFillStudent)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmEmployeeDayAttendance"
        Me.Text = "Employee Day Attendance"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GBoxImportFromExcel.ResumeLayout(False)
        Me.GBoxImportFromExcel.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblA_DateReq As System.Windows.Forms.Label
    Friend WithEvents TxtA_Date As AgControls.AgTextBox
    Friend WithEvents LblA_Date As System.Windows.Forms.Label
    Friend WithEvents LblTotalPresent As System.Windows.Forms.Label
    Friend WithEvents TxtTotalPresent As AgControls.AgTextBox
    Friend WithEvents LblTotalAbsent As System.Windows.Forms.Label
    Friend WithEvents TxtTotalAbsent As AgControls.AgTextBox
    Friend WithEvents LblTotalEmployee As System.Windows.Forms.Label
    Friend WithEvents TxtTotalEmployee As AgControls.AgTextBox
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Public WithEvents GBoxImportFromExcel As System.Windows.Forms.GroupBox
    Public WithEvents BtnImprtFromDB As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TxtFromDate As AgControls.AgTextBox
    Friend WithEvents TxtToDate As AgControls.AgTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
