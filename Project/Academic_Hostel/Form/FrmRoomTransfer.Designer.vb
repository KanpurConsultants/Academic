<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRoomTransfer
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
        Me.LblRoomRequired = New System.Windows.Forms.Label
        Me.TxtRoom = New AgControls.AgTextBox
        Me.LblRoom = New System.Windows.Forms.Label
        Me.LblAllotmentDocIdReq = New System.Windows.Forms.Label
        Me.TxtAllotmentDocId = New AgControls.AgTextBox
        Me.LblAllotmentDocId = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.LblTransferDate = New System.Windows.Forms.Label
        Me.TxtTransferDate = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblChargeStartDate = New System.Windows.Forms.Label
        Me.TxtChargeStartDate = New AgControls.AgTextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BtnFillCharges = New System.Windows.Forms.Button
        Me.LblChargeDetails = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblRemark = New System.Windows.Forms.Label
        Me.LblSite_CodeReq = New System.Windows.Forms.Label
        Me.LblSite_Code = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtHostel = New AgControls.AgTextBox
        Me.LblHostel = New System.Windows.Forms.Label
        Me.TxtCurrentRoom = New AgControls.AgTextBox
        Me.LblCurrentRoom = New System.Windows.Forms.Label
        Me.LblAllotmentDate = New System.Windows.Forms.Label
        Me.TxtAllotmentDate = New AgControls.AgTextBox
        Me.LblRoomType = New System.Windows.Forms.Label
        Me.TxtRoomType = New AgControls.AgTextBox
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
        Me.Topctrl1.Size = New System.Drawing.Size(883, 41)
        Me.Topctrl1.TabIndex = 9
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
        'LblRoomRequired
        '
        Me.LblRoomRequired.AutoSize = True
        Me.LblRoomRequired.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblRoomRequired.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblRoomRequired.Location = New System.Drawing.Point(554, 115)
        Me.LblRoomRequired.Name = "LblRoomRequired"
        Me.LblRoomRequired.Size = New System.Drawing.Size(10, 7)
        Me.LblRoomRequired.TabIndex = 670
        Me.LblRoomRequired.Text = "Ä"
        '
        'TxtRoom
        '
        Me.TxtRoom.AgMandatory = True
        Me.TxtRoom.AgMasterHelp = False
        Me.TxtRoom.AgNumberLeftPlaces = 0
        Me.TxtRoom.AgNumberNegetiveAllow = False
        Me.TxtRoom.AgNumberRightPlaces = 0
        Me.TxtRoom.AgPickFromLastValue = False
        Me.TxtRoom.AgRowFilter = ""
        Me.TxtRoom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRoom.AgSelectedValue = Nothing
        Me.TxtRoom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoom.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoom.Location = New System.Drawing.Point(567, 107)
        Me.TxtRoom.MaxLength = 50
        Me.TxtRoom.Name = "TxtRoom"
        Me.TxtRoom.Size = New System.Drawing.Size(300, 21)
        Me.TxtRoom.TabIndex = 3
        '
        'LblRoom
        '
        Me.LblRoom.AutoSize = True
        Me.LblRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoom.Location = New System.Drawing.Point(450, 109)
        Me.LblRoom.Name = "LblRoom"
        Me.LblRoom.Size = New System.Drawing.Size(40, 13)
        Me.LblRoom.TabIndex = 669
        Me.LblRoom.Text = "Room"
        '
        'LblAllotmentDocIdReq
        '
        Me.LblAllotmentDocIdReq.AutoSize = True
        Me.LblAllotmentDocIdReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAllotmentDocIdReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAllotmentDocIdReq.Location = New System.Drawing.Point(108, 118)
        Me.LblAllotmentDocIdReq.Name = "LblAllotmentDocIdReq"
        Me.LblAllotmentDocIdReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAllotmentDocIdReq.TabIndex = 668
        Me.LblAllotmentDocIdReq.Text = "Ä"
        '
        'TxtAllotmentDocId
        '
        Me.TxtAllotmentDocId.AgMandatory = True
        Me.TxtAllotmentDocId.AgMasterHelp = False
        Me.TxtAllotmentDocId.AgNumberLeftPlaces = 0
        Me.TxtAllotmentDocId.AgNumberNegetiveAllow = False
        Me.TxtAllotmentDocId.AgNumberRightPlaces = 0
        Me.TxtAllotmentDocId.AgPickFromLastValue = False
        Me.TxtAllotmentDocId.AgRowFilter = ""
        Me.TxtAllotmentDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAllotmentDocId.AgSelectedValue = Nothing
        Me.TxtAllotmentDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAllotmentDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAllotmentDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAllotmentDocId.Location = New System.Drawing.Point(121, 111)
        Me.TxtAllotmentDocId.MaxLength = 50
        Me.TxtAllotmentDocId.Name = "TxtAllotmentDocId"
        Me.TxtAllotmentDocId.Size = New System.Drawing.Size(300, 21)
        Me.TxtAllotmentDocId.TabIndex = 1
        '
        'LblAllotmentDocId
        '
        Me.LblAllotmentDocId.AutoSize = True
        Me.LblAllotmentDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAllotmentDocId.Location = New System.Drawing.Point(12, 113)
        Me.LblAllotmentDocId.Name = "LblAllotmentDocId"
        Me.LblAllotmentDocId.Size = New System.Drawing.Size(90, 13)
        Me.LblAllotmentDocId.TabIndex = 667
        Me.LblAllotmentDocId.Text = "Member Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(554, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(10, 7)
        Me.Label2.TabIndex = 673
        Me.Label2.Text = "Ä"
        '
        'LblTransferDate
        '
        Me.LblTransferDate.AutoSize = True
        Me.LblTransferDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTransferDate.Location = New System.Drawing.Point(450, 130)
        Me.LblTransferDate.Name = "LblTransferDate"
        Me.LblTransferDate.Size = New System.Drawing.Size(86, 13)
        Me.LblTransferDate.TabIndex = 672
        Me.LblTransferDate.Text = "Transfer Date"
        '
        'TxtTransferDate
        '
        Me.TxtTransferDate.AgMandatory = True
        Me.TxtTransferDate.AgMasterHelp = False
        Me.TxtTransferDate.AgNumberLeftPlaces = 0
        Me.TxtTransferDate.AgNumberNegetiveAllow = False
        Me.TxtTransferDate.AgNumberRightPlaces = 0
        Me.TxtTransferDate.AgPickFromLastValue = False
        Me.TxtTransferDate.AgRowFilter = ""
        Me.TxtTransferDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTransferDate.AgSelectedValue = Nothing
        Me.TxtTransferDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTransferDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtTransferDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransferDate.Location = New System.Drawing.Point(567, 129)
        Me.TxtTransferDate.Name = "TxtTransferDate"
        Me.TxtTransferDate.Size = New System.Drawing.Size(91, 21)
        Me.TxtTransferDate.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(779, 137)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 676
        Me.Label1.Text = "Ä"
        '
        'LblChargeStartDate
        '
        Me.LblChargeStartDate.AutoSize = True
        Me.LblChargeStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChargeStartDate.Location = New System.Drawing.Point(670, 134)
        Me.LblChargeStartDate.Name = "LblChargeStartDate"
        Me.LblChargeStartDate.Size = New System.Drawing.Size(109, 13)
        Me.LblChargeStartDate.TabIndex = 675
        Me.LblChargeStartDate.Text = "Charge Start Mth."
        '
        'TxtChargeStartDate
        '
        Me.TxtChargeStartDate.AgMandatory = True
        Me.TxtChargeStartDate.AgMasterHelp = False
        Me.TxtChargeStartDate.AgNumberLeftPlaces = 0
        Me.TxtChargeStartDate.AgNumberNegetiveAllow = False
        Me.TxtChargeStartDate.AgNumberRightPlaces = 0
        Me.TxtChargeStartDate.AgPickFromLastValue = False
        Me.TxtChargeStartDate.AgRowFilter = ""
        Me.TxtChargeStartDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtChargeStartDate.AgSelectedValue = Nothing
        Me.TxtChargeStartDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtChargeStartDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtChargeStartDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChargeStartDate.Location = New System.Drawing.Point(792, 129)
        Me.TxtChargeStartDate.Name = "TxtChargeStartDate"
        Me.TxtChargeStartDate.Size = New System.Drawing.Size(75, 21)
        Me.TxtChargeStartDate.TabIndex = 5
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 502)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 678
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
        Me.GroupBox4.Location = New System.Drawing.Point(692, 502)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 679
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
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(0, 492)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(880, 4)
        Me.GroupBox2.TabIndex = 677
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'BtnFillCharges
        '
        Me.BtnFillCharges.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillCharges.Location = New System.Drawing.Point(618, 192)
        Me.BtnFillCharges.Name = "BtnFillCharges"
        Me.BtnFillCharges.Size = New System.Drawing.Size(100, 23)
        Me.BtnFillCharges.TabIndex = 6
        Me.BtnFillCharges.Text = "Fill &Charges"
        Me.BtnFillCharges.UseVisualStyleBackColor = True
        '
        'LblChargeDetails
        '
        Me.LblChargeDetails.AutoSize = True
        Me.LblChargeDetails.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblChargeDetails.ForeColor = System.Drawing.Color.Blue
        Me.LblChargeDetails.Location = New System.Drawing.Point(165, 201)
        Me.LblChargeDetails.Name = "LblChargeDetails"
        Me.LblChargeDetails.Size = New System.Drawing.Size(101, 13)
        Me.LblChargeDetails.TabIndex = 685
        Me.LblChargeDetails.Text = "Charge Details :"
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(168, 216)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(550, 231)
        Me.Pnl1.TabIndex = 7
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
        Me.TxtRemark.Location = New System.Drawing.Point(110, 456)
        Me.TxtRemark.MaxLength = 255
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(317, 21)
        Me.TxtRemark.TabIndex = 8
        '
        'LblRemark
        '
        Me.LblRemark.AutoSize = True
        Me.LblRemark.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemark.Location = New System.Drawing.Point(19, 459)
        Me.LblRemark.Name = "LblRemark"
        Me.LblRemark.Size = New System.Drawing.Size(52, 13)
        Me.LblRemark.TabIndex = 687
        Me.LblRemark.Text = "&Remark"
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.AutoSize = True
        Me.LblSite_CodeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblSite_CodeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(108, 97)
        Me.LblSite_CodeReq.Name = "LblSite_CodeReq"
        Me.LblSite_CodeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblSite_CodeReq.TabIndex = 689
        Me.LblSite_CodeReq.Text = "Ä"
        '
        'LblSite_Code
        '
        Me.LblSite_Code.AutoSize = True
        Me.LblSite_Code.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSite_Code.Location = New System.Drawing.Point(12, 92)
        Me.LblSite_Code.Name = "LblSite_Code"
        Me.LblSite_Code.Size = New System.Drawing.Size(74, 13)
        Me.LblSite_Code.TabIndex = 690
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(121, 89)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(300, 21)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(554, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 7)
        Me.Label3.TabIndex = 693
        Me.Label3.Text = "Ä"
        '
        'TxtHostel
        '
        Me.TxtHostel.AgMandatory = True
        Me.TxtHostel.AgMasterHelp = False
        Me.TxtHostel.AgNumberLeftPlaces = 0
        Me.TxtHostel.AgNumberNegetiveAllow = False
        Me.TxtHostel.AgNumberRightPlaces = 0
        Me.TxtHostel.AgPickFromLastValue = False
        Me.TxtHostel.AgRowFilter = ""
        Me.TxtHostel.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtHostel.AgSelectedValue = Nothing
        Me.TxtHostel.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtHostel.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtHostel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHostel.Location = New System.Drawing.Point(567, 85)
        Me.TxtHostel.MaxLength = 50
        Me.TxtHostel.Name = "TxtHostel"
        Me.TxtHostel.Size = New System.Drawing.Size(300, 21)
        Me.TxtHostel.TabIndex = 2
        '
        'LblHostel
        '
        Me.LblHostel.AutoSize = True
        Me.LblHostel.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHostel.Location = New System.Drawing.Point(450, 88)
        Me.LblHostel.Name = "LblHostel"
        Me.LblHostel.Size = New System.Drawing.Size(42, 13)
        Me.LblHostel.TabIndex = 692
        Me.LblHostel.Text = "Hostel"
        '
        'TxtCurrentRoom
        '
        Me.TxtCurrentRoom.AgMandatory = True
        Me.TxtCurrentRoom.AgMasterHelp = False
        Me.TxtCurrentRoom.AgNumberLeftPlaces = 0
        Me.TxtCurrentRoom.AgNumberNegetiveAllow = False
        Me.TxtCurrentRoom.AgNumberRightPlaces = 0
        Me.TxtCurrentRoom.AgPickFromLastValue = False
        Me.TxtCurrentRoom.AgRowFilter = ""
        Me.TxtCurrentRoom.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCurrentRoom.AgSelectedValue = Nothing
        Me.TxtCurrentRoom.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCurrentRoom.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCurrentRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrentRoom.Location = New System.Drawing.Point(121, 133)
        Me.TxtCurrentRoom.MaxLength = 50
        Me.TxtCurrentRoom.Name = "TxtCurrentRoom"
        Me.TxtCurrentRoom.Size = New System.Drawing.Size(300, 21)
        Me.TxtCurrentRoom.TabIndex = 694
        '
        'LblCurrentRoom
        '
        Me.LblCurrentRoom.AutoSize = True
        Me.LblCurrentRoom.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrentRoom.Location = New System.Drawing.Point(12, 134)
        Me.LblCurrentRoom.Name = "LblCurrentRoom"
        Me.LblCurrentRoom.Size = New System.Drawing.Size(88, 13)
        Me.LblCurrentRoom.TabIndex = 695
        Me.LblCurrentRoom.Text = "Current Room"
        '
        'LblAllotmentDate
        '
        Me.LblAllotmentDate.AutoSize = True
        Me.LblAllotmentDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAllotmentDate.Location = New System.Drawing.Point(12, 155)
        Me.LblAllotmentDate.Name = "LblAllotmentDate"
        Me.LblAllotmentDate.Size = New System.Drawing.Size(92, 13)
        Me.LblAllotmentDate.TabIndex = 698
        Me.LblAllotmentDate.Text = "Allotment Date" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'TxtAllotmentDate
        '
        Me.TxtAllotmentDate.AgMandatory = True
        Me.TxtAllotmentDate.AgMasterHelp = False
        Me.TxtAllotmentDate.AgNumberLeftPlaces = 0
        Me.TxtAllotmentDate.AgNumberNegetiveAllow = False
        Me.TxtAllotmentDate.AgNumberRightPlaces = 0
        Me.TxtAllotmentDate.AgPickFromLastValue = False
        Me.TxtAllotmentDate.AgRowFilter = ""
        Me.TxtAllotmentDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAllotmentDate.AgSelectedValue = Nothing
        Me.TxtAllotmentDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAllotmentDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtAllotmentDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAllotmentDate.Location = New System.Drawing.Point(121, 155)
        Me.TxtAllotmentDate.Name = "TxtAllotmentDate"
        Me.TxtAllotmentDate.ReadOnly = True
        Me.TxtAllotmentDate.Size = New System.Drawing.Size(96, 21)
        Me.TxtAllotmentDate.TabIndex = 697
        Me.TxtAllotmentDate.TabStop = False
        '
        'LblRoomType
        '
        Me.LblRoomType.AutoSize = True
        Me.LblRoomType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRoomType.Location = New System.Drawing.Point(242, 159)
        Me.LblRoomType.Name = "LblRoomType"
        Me.LblRoomType.Size = New System.Drawing.Size(72, 13)
        Me.LblRoomType.TabIndex = 700
        Me.LblRoomType.Text = "Room Type"
        '
        'TxtRoomType
        '
        Me.TxtRoomType.AgMandatory = True
        Me.TxtRoomType.AgMasterHelp = False
        Me.TxtRoomType.AgNumberLeftPlaces = 0
        Me.TxtRoomType.AgNumberNegetiveAllow = False
        Me.TxtRoomType.AgNumberRightPlaces = 0
        Me.TxtRoomType.AgPickFromLastValue = False
        Me.TxtRoomType.AgRowFilter = ""
        Me.TxtRoomType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRoomType.AgSelectedValue = Nothing
        Me.TxtRoomType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRoomType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRoomType.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRoomType.Location = New System.Drawing.Point(325, 155)
        Me.TxtRoomType.MaxLength = 20
        Me.TxtRoomType.Name = "TxtRoomType"
        Me.TxtRoomType.ReadOnly = True
        Me.TxtRoomType.Size = New System.Drawing.Size(96, 21)
        Me.TxtRoomType.TabIndex = 699
        Me.TxtRoomType.TabStop = False
        '
        'FrmRoomTransfer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(883, 559)
        Me.Controls.Add(Me.LblRoomType)
        Me.Controls.Add(Me.TxtRoomType)
        Me.Controls.Add(Me.LblAllotmentDate)
        Me.Controls.Add(Me.TxtAllotmentDate)
        Me.Controls.Add(Me.TxtCurrentRoom)
        Me.Controls.Add(Me.LblCurrentRoom)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtHostel)
        Me.Controls.Add(Me.LblHostel)
        Me.Controls.Add(Me.LblSite_CodeReq)
        Me.Controls.Add(Me.LblSite_Code)
        Me.Controls.Add(Me.TxtSite_Code)
        Me.Controls.Add(Me.TxtRemark)
        Me.Controls.Add(Me.LblRemark)
        Me.Controls.Add(Me.BtnFillCharges)
        Me.Controls.Add(Me.LblChargeDetails)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LblChargeStartDate)
        Me.Controls.Add(Me.TxtChargeStartDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LblTransferDate)
        Me.Controls.Add(Me.TxtTransferDate)
        Me.Controls.Add(Me.LblRoomRequired)
        Me.Controls.Add(Me.TxtRoom)
        Me.Controls.Add(Me.LblRoom)
        Me.Controls.Add(Me.LblAllotmentDocIdReq)
        Me.Controls.Add(Me.TxtAllotmentDocId)
        Me.Controls.Add(Me.LblAllotmentDocId)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FrmRoomTransfer"
        Me.Text = "Room Transfer"
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblRoomRequired As System.Windows.Forms.Label
    Friend WithEvents TxtRoom As AgControls.AgTextBox
    Friend WithEvents LblRoom As System.Windows.Forms.Label
    Friend WithEvents LblAllotmentDocIdReq As System.Windows.Forms.Label
    Friend WithEvents TxtAllotmentDocId As AgControls.AgTextBox
    Friend WithEvents LblAllotmentDocId As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblTransferDate As System.Windows.Forms.Label
    Friend WithEvents TxtTransferDate As AgControls.AgTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LblChargeStartDate As System.Windows.Forms.Label
    Friend WithEvents TxtChargeStartDate As AgControls.AgTextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnFillCharges As System.Windows.Forms.Button
    Friend WithEvents LblChargeDetails As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents LblRemark As System.Windows.Forms.Label
    Friend WithEvents LblSite_CodeReq As System.Windows.Forms.Label
    Friend WithEvents LblSite_Code As System.Windows.Forms.Label
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtHostel As AgControls.AgTextBox
    Friend WithEvents LblHostel As System.Windows.Forms.Label
    Friend WithEvents TxtCurrentRoom As AgControls.AgTextBox
    Friend WithEvents LblCurrentRoom As System.Windows.Forms.Label
    Friend WithEvents LblAllotmentDate As System.Windows.Forms.Label
    Friend WithEvents TxtAllotmentDate As AgControls.AgTextBox
    Friend WithEvents LblRoomType As System.Windows.Forms.Label
    Friend WithEvents TxtRoomType As AgControls.AgTextBox
End Class
