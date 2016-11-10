<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSessionProgrammeStreamOC
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
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.LblFromDateReq = New System.Windows.Forms.Label
        Me.TxtFromDate = New AgControls.AgTextBox
        Me.LblFromDate = New System.Windows.Forms.Label
        Me.LblUptoDate = New System.Windows.Forms.Label
        Me.TxtUptoDate = New AgControls.AgTextBox
        Me.TxtSessionProgrammeStream = New AgControls.AgTextBox
        Me.LblSessionProgrammeStream = New System.Windows.Forms.Label
        Me.TxtOC = New AgControls.AgTextBox
        Me.LblOC = New System.Windows.Forms.Label
        Me.TxtSession = New AgControls.AgTextBox
        Me.LblSession = New System.Windows.Forms.Label
        Me.LblSessionReq = New System.Windows.Forms.Label
        Me.LblSessionProgrammeStreamReq = New System.Windows.Forms.Label
        Me.LblOcReq = New System.Windows.Forms.Label
        Me.GrpUP.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(318, 127)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 531
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(146, 124)
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(333, 120)
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
        Me.TxtRemark.Location = New System.Drawing.Point(333, 230)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(325, 21)
        Me.TxtRemark.TabIndex = 6
        Me.TxtRemark.Text = "TxtRemark"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(146, 234)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Remark"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(-4, 343)
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
        Me.GrpUP.Location = New System.Drawing.Point(11, 353)
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
        Me.GroupBox4.Location = New System.Drawing.Point(674, 353)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 527
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Tag = "TR"
        Me.GroupBox4.Text = "Modified By "
        Me.GroupBox4.Visible = False
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
        Me.Topctrl1.TabIndex = 7
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
        'LblFromDateReq
        '
        Me.LblFromDateReq.AutoSize = True
        Me.LblFromDateReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblFromDateReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblFromDateReq.Location = New System.Drawing.Point(318, 215)
        Me.LblFromDateReq.Name = "LblFromDateReq"
        Me.LblFromDateReq.Size = New System.Drawing.Size(10, 7)
        Me.LblFromDateReq.TabIndex = 543
        Me.LblFromDateReq.Text = "Ä"
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
        Me.TxtFromDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromDate.Location = New System.Drawing.Point(333, 208)
        Me.TxtFromDate.MaxLength = 11
        Me.TxtFromDate.Name = "TxtFromDate"
        Me.TxtFromDate.Size = New System.Drawing.Size(100, 21)
        Me.TxtFromDate.TabIndex = 4
        '
        'LblFromDate
        '
        Me.LblFromDate.AutoSize = True
        Me.LblFromDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFromDate.Location = New System.Drawing.Point(146, 212)
        Me.LblFromDate.Name = "LblFromDate"
        Me.LblFromDate.Size = New System.Drawing.Size(67, 13)
        Me.LblFromDate.TabIndex = 542
        Me.LblFromDate.Text = "From Date"
        '
        'LblUptoDate
        '
        Me.LblUptoDate.AutoSize = True
        Me.LblUptoDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblUptoDate.Location = New System.Drawing.Point(485, 212)
        Me.LblUptoDate.Name = "LblUptoDate"
        Me.LblUptoDate.Size = New System.Drawing.Size(64, 13)
        Me.LblUptoDate.TabIndex = 545
        Me.LblUptoDate.Text = "Upto Date"
        '
        'TxtUptoDate
        '
        Me.TxtUptoDate.AgMandatory = False
        Me.TxtUptoDate.AgMasterHelp = False
        Me.TxtUptoDate.AgNumberLeftPlaces = 0
        Me.TxtUptoDate.AgNumberNegetiveAllow = False
        Me.TxtUptoDate.AgNumberRightPlaces = 0
        Me.TxtUptoDate.AgPickFromLastValue = False
        Me.TxtUptoDate.AgRowFilter = ""
        Me.TxtUptoDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtUptoDate.AgSelectedValue = Nothing
        Me.TxtUptoDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtUptoDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtUptoDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtUptoDate.Location = New System.Drawing.Point(558, 208)
        Me.TxtUptoDate.MaxLength = 11
        Me.TxtUptoDate.Name = "TxtUptoDate"
        Me.TxtUptoDate.Size = New System.Drawing.Size(100, 21)
        Me.TxtUptoDate.TabIndex = 5
        '
        'TxtSessionProgrammeStream
        '
        Me.TxtSessionProgrammeStream.AgMandatory = True
        Me.TxtSessionProgrammeStream.AgMasterHelp = False
        Me.TxtSessionProgrammeStream.AgNumberLeftPlaces = 0
        Me.TxtSessionProgrammeStream.AgNumberNegetiveAllow = False
        Me.TxtSessionProgrammeStream.AgNumberRightPlaces = 0
        Me.TxtSessionProgrammeStream.AgPickFromLastValue = False
        Me.TxtSessionProgrammeStream.AgRowFilter = ""
        Me.TxtSessionProgrammeStream.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSessionProgrammeStream.AgSelectedValue = Nothing
        Me.TxtSessionProgrammeStream.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSessionProgrammeStream.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSessionProgrammeStream.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSessionProgrammeStream.Location = New System.Drawing.Point(333, 164)
        Me.TxtSessionProgrammeStream.MaxLength = 50
        Me.TxtSessionProgrammeStream.Name = "TxtSessionProgrammeStream"
        Me.TxtSessionProgrammeStream.Size = New System.Drawing.Size(325, 21)
        Me.TxtSessionProgrammeStream.TabIndex = 2
        Me.TxtSessionProgrammeStream.Text = "AgTextBox2"
        '
        'LblSessionProgrammeStream
        '
        Me.LblSessionProgrammeStream.AutoSize = True
        Me.LblSessionProgrammeStream.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSessionProgrammeStream.Location = New System.Drawing.Point(146, 168)
        Me.LblSessionProgrammeStream.Name = "LblSessionProgrammeStream"
        Me.LblSessionProgrammeStream.Size = New System.Drawing.Size(170, 13)
        Me.LblSessionProgrammeStream.TabIndex = 546
        Me.LblSessionProgrammeStream.Text = "Session/Programme/Stream"
        '
        'TxtOC
        '
        Me.TxtOC.AgMandatory = True
        Me.TxtOC.AgMasterHelp = False
        Me.TxtOC.AgNumberLeftPlaces = 0
        Me.TxtOC.AgNumberNegetiveAllow = False
        Me.TxtOC.AgNumberRightPlaces = 0
        Me.TxtOC.AgPickFromLastValue = False
        Me.TxtOC.AgRowFilter = ""
        Me.TxtOC.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOC.AgSelectedValue = Nothing
        Me.TxtOC.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOC.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOC.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOC.Location = New System.Drawing.Point(333, 186)
        Me.TxtOC.MaxLength = 123
        Me.TxtOC.Name = "TxtOC"
        Me.TxtOC.Size = New System.Drawing.Size(325, 21)
        Me.TxtOC.TabIndex = 3
        Me.TxtOC.Text = "AgTextBox3"
        '
        'LblOC
        '
        Me.LblOC.AutoSize = True
        Me.LblOC.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOC.Location = New System.Drawing.Point(146, 190)
        Me.LblOC.Name = "LblOC"
        Me.LblOC.Size = New System.Drawing.Size(62, 13)
        Me.LblOC.TabIndex = 548
        Me.LblOC.Text = "OC Name"
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
        Me.TxtSession.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSession.Location = New System.Drawing.Point(333, 142)
        Me.TxtSession.MaxLength = 50
        Me.TxtSession.Name = "TxtSession"
        Me.TxtSession.Size = New System.Drawing.Size(100, 21)
        Me.TxtSession.TabIndex = 1
        Me.TxtSession.Text = "AgTextBox2"
        '
        'LblSession
        '
        Me.LblSession.AutoSize = True
        Me.LblSession.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSession.Location = New System.Drawing.Point(146, 146)
        Me.LblSession.Name = "LblSession"
        Me.LblSession.Size = New System.Drawing.Size(51, 13)
        Me.LblSession.TabIndex = 550
        Me.LblSession.Text = "Session"
        '
        'LblSessionReq
        '
        Me.LblSessionReq.AutoSize = True
        Me.LblSessionReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSessionReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSessionReq.Location = New System.Drawing.Point(318, 149)
        Me.LblSessionReq.Name = "LblSessionReq"
        Me.LblSessionReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSessionReq.TabIndex = 552
        Me.LblSessionReq.Text = "Ä"
        '
        'LblSessionProgrammeStreamReq
        '
        Me.LblSessionProgrammeStreamReq.AutoSize = True
        Me.LblSessionProgrammeStreamReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSessionProgrammeStreamReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSessionProgrammeStreamReq.Location = New System.Drawing.Point(318, 171)
        Me.LblSessionProgrammeStreamReq.Name = "LblSessionProgrammeStreamReq"
        Me.LblSessionProgrammeStreamReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSessionProgrammeStreamReq.TabIndex = 553
        Me.LblSessionProgrammeStreamReq.Text = "Ä"
        '
        'LblOcReq
        '
        Me.LblOcReq.AutoSize = True
        Me.LblOcReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblOcReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblOcReq.Location = New System.Drawing.Point(318, 193)
        Me.LblOcReq.Name = "LblOcReq"
        Me.LblOcReq.Size = New System.Drawing.Size(10, 7)
        Me.LblOcReq.TabIndex = 554
        Me.LblOcReq.Text = "Ä"
        '
        'FrmSessionProgrammeStreamOC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 416)
        Me.Controls.Add(Me.LblOcReq)
        Me.Controls.Add(Me.LblSessionProgrammeStreamReq)
        Me.Controls.Add(Me.LblSessionReq)
        Me.Controls.Add(Me.TxtSession)
        Me.Controls.Add(Me.LblSession)
        Me.Controls.Add(Me.TxtOC)
        Me.Controls.Add(Me.LblOC)
        Me.Controls.Add(Me.TxtSessionProgrammeStream)
        Me.Controls.Add(Me.LblSessionProgrammeStream)
        Me.Controls.Add(Me.LblUptoDate)
        Me.Controls.Add(Me.TxtUptoDate)
        Me.Controls.Add(Me.LblFromDate)
        Me.Controls.Add(Me.TxtFromDate)
        Me.Controls.Add(Me.LblFromDateReq)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmSessionProgrammeStreamOC"
        Me.Text = "OC Assign Entry"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
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
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblFromDateReq As System.Windows.Forms.Label
    Friend WithEvents TxtFromDate As AgControls.AgTextBox
    Friend WithEvents LblFromDate As System.Windows.Forms.Label
    Friend WithEvents LblUptoDate As System.Windows.Forms.Label
    Friend WithEvents TxtUptoDate As AgControls.AgTextBox
    Friend WithEvents TxtSessionProgrammeStream As AgControls.AgTextBox
    Friend WithEvents LblSessionProgrammeStream As System.Windows.Forms.Label
    Friend WithEvents TxtOC As AgControls.AgTextBox
    Friend WithEvents LblOC As System.Windows.Forms.Label
    Friend WithEvents TxtSession As AgControls.AgTextBox
    Friend WithEvents LblSession As System.Windows.Forms.Label
    Friend WithEvents LblSessionReq As System.Windows.Forms.Label
    Friend WithEvents LblSessionProgrammeStreamReq As System.Windows.Forms.Label
    Friend WithEvents LblOcReq As System.Windows.Forms.Label
End Class
