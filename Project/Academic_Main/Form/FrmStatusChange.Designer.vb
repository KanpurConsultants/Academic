<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStatusChange
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStatusChange))
        Me.Topctrl1 = New Topctrl.Topctrl
        Me.LblAdmissionDocIdReq = New System.Windows.Forms.Label
        Me.TxtAdmissionID = New AgControls.AgTextBox
        Me.LblAdmissionID = New System.Windows.Forms.Label
        Me.TxtAdmissionDocId = New AgControls.AgTextBox
        Me.LblAdmissionDocId = New System.Windows.Forms.Label
        Me.LblIsStreamChangeReq = New System.Windows.Forms.Label
        Me.TxtIsStreamChange = New AgControls.AgTextBox
        Me.LblIsStreamChange = New System.Windows.Forms.Label
        Me.LblStatus = New System.Windows.Forms.Label
        Me.TxtStatus = New AgControls.AgTextBox
        Me.LblStreamYearSemester = New System.Windows.Forms.Label
        Me.TxtStreamYearSemester = New AgControls.AgTextBox
        Me.Tc1 = New System.Windows.Forms.TabControl
        Me.Tp3 = New System.Windows.Forms.TabPage
        Me.GrpReversePost = New System.Windows.Forms.GroupBox
        Me.BtnFillDues = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.TxtTotalAmount = New AgControls.AgTextBox
        Me.LblV_No = New System.Windows.Forms.Label
        Me.TxtDocId = New AgControls.AgTextBox
        Me.TxtV_No = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtRemark = New AgControls.AgTextBox
        Me.LblPrefix = New System.Windows.Forms.Label
        Me.LblV_TypeReq = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Pnl3 = New System.Windows.Forms.Panel
        Me.LblV_Type = New System.Windows.Forms.Label
        Me.TxtSite_Code = New AgControls.AgTextBox
        Me.TxtV_Type = New AgControls.AgTextBox
        Me.Tp1 = New System.Windows.Forms.TabPage
        Me.LblFeeDetail = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Tp2 = New System.Windows.Forms.TabPage
        Me.Label110 = New System.Windows.Forms.Label
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.TxtV_Date = New AgControls.AgTextBox
        Me.LblV_Date = New System.Windows.Forms.Label
        Me.LblNewSemesterFee = New System.Windows.Forms.Label
        Me.TxtNewSemesterFee = New AgControls.AgTextBox
        Me.BtnFillDetail = New System.Windows.Forms.Button
        Me.LblNewStreamYearSemester = New System.Windows.Forms.Label
        Me.TxtNewStreamYearSemester = New AgControls.AgTextBox
        Me.TxtNewStatus = New AgControls.AgTextBox
        Me.LblNewStatus = New System.Windows.Forms.Label
        Me.TxtIsNewStatusAfterPromotion = New AgControls.AgTextBox
        Me.LblIsNewStatusAfterPromotion = New System.Windows.Forms.Label
        Me.LblSemesterLastTransactionDate = New System.Windows.Forms.Label
        Me.TxtSemesterLastTransactionDate = New AgControls.AgTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BtnApproved = New System.Windows.Forms.Button
        Me.TxtApproved = New System.Windows.Forms.TextBox
        Me.GrpUP = New System.Windows.Forms.GroupBox
        Me.TxtPrepared = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TxtModified = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Tc1.SuspendLayout()
        Me.Tp3.SuspendLayout()
        Me.GrpReversePost.SuspendLayout()
        Me.Tp1.SuspendLayout()
        Me.Tp2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
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
        Me.Topctrl1.Size = New System.Drawing.Size(934, 41)
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
        'LblAdmissionDocIdReq
        '
        Me.LblAdmissionDocIdReq.AutoSize = True
        Me.LblAdmissionDocIdReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblAdmissionDocIdReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblAdmissionDocIdReq.Location = New System.Drawing.Point(112, 70)
        Me.LblAdmissionDocIdReq.Name = "LblAdmissionDocIdReq"
        Me.LblAdmissionDocIdReq.Size = New System.Drawing.Size(10, 7)
        Me.LblAdmissionDocIdReq.TabIndex = 660
        Me.LblAdmissionDocIdReq.Text = "Ä"
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
        Me.TxtAdmissionID.ForeColor = System.Drawing.Color.Blue
        Me.TxtAdmissionID.Location = New System.Drawing.Point(125, 82)
        Me.TxtAdmissionID.MaxLength = 21
        Me.TxtAdmissionID.Name = "TxtAdmissionID"
        Me.TxtAdmissionID.ReadOnly = True
        Me.TxtAdmissionID.Size = New System.Drawing.Size(293, 21)
        Me.TxtAdmissionID.TabIndex = 1
        Me.TxtAdmissionID.TabStop = False
        Me.TxtAdmissionID.Text = "TxtAdmissionID"
        '
        'LblAdmissionID
        '
        Me.LblAdmissionID.AutoSize = True
        Me.LblAdmissionID.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmissionID.ForeColor = System.Drawing.Color.Blue
        Me.LblAdmissionID.Location = New System.Drawing.Point(21, 86)
        Me.LblAdmissionID.Name = "LblAdmissionID"
        Me.LblAdmissionID.Size = New System.Drawing.Size(83, 13)
        Me.LblAdmissionID.TabIndex = 659
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
        Me.TxtAdmissionDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAdmissionDocId.Location = New System.Drawing.Point(125, 60)
        Me.TxtAdmissionDocId.MaxLength = 123
        Me.TxtAdmissionDocId.Name = "TxtAdmissionDocId"
        Me.TxtAdmissionDocId.Size = New System.Drawing.Size(293, 21)
        Me.TxtAdmissionDocId.TabIndex = 0
        '
        'LblAdmissionDocId
        '
        Me.LblAdmissionDocId.AutoSize = True
        Me.LblAdmissionDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAdmissionDocId.Location = New System.Drawing.Point(21, 64)
        Me.LblAdmissionDocId.Name = "LblAdmissionDocId"
        Me.LblAdmissionDocId.Size = New System.Drawing.Size(51, 13)
        Me.LblAdmissionDocId.TabIndex = 658
        Me.LblAdmissionDocId.Text = "Student"
        '
        'LblIsStreamChangeReq
        '
        Me.LblIsStreamChangeReq.AutoSize = True
        Me.LblIsStreamChangeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblIsStreamChangeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblIsStreamChangeReq.Location = New System.Drawing.Point(862, 67)
        Me.LblIsStreamChangeReq.Name = "LblIsStreamChangeReq"
        Me.LblIsStreamChangeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblIsStreamChangeReq.TabIndex = 669
        Me.LblIsStreamChangeReq.Text = "Ä"
        '
        'TxtIsStreamChange
        '
        Me.TxtIsStreamChange.AgMandatory = True
        Me.TxtIsStreamChange.AgMasterHelp = False
        Me.TxtIsStreamChange.AgNumberLeftPlaces = 0
        Me.TxtIsStreamChange.AgNumberNegetiveAllow = False
        Me.TxtIsStreamChange.AgNumberRightPlaces = 0
        Me.TxtIsStreamChange.AgPickFromLastValue = False
        Me.TxtIsStreamChange.AgRowFilter = ""
        Me.TxtIsStreamChange.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsStreamChange.AgSelectedValue = Nothing
        Me.TxtIsStreamChange.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsStreamChange.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsStreamChange.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsStreamChange.Location = New System.Drawing.Point(877, 60)
        Me.TxtIsStreamChange.MaxLength = 3
        Me.TxtIsStreamChange.Name = "TxtIsStreamChange"
        Me.TxtIsStreamChange.Size = New System.Drawing.Size(45, 21)
        Me.TxtIsStreamChange.TabIndex = 5
        Me.TxtIsStreamChange.Text = "IsStreamChange"
        '
        'LblIsStreamChange
        '
        Me.LblIsStreamChange.AutoSize = True
        Me.LblIsStreamChange.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsStreamChange.Location = New System.Drawing.Point(731, 64)
        Me.LblIsStreamChange.Name = "LblIsStreamChange"
        Me.LblIsStreamChange.Size = New System.Drawing.Size(118, 13)
        Me.LblIsStreamChange.TabIndex = 668
        Me.LblIsStreamChange.Text = "Is Stream Change?"
        '
        'LblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStatus.Location = New System.Drawing.Point(20, 108)
        Me.LblStatus.Name = "LblStatus"
        Me.LblStatus.Size = New System.Drawing.Size(43, 13)
        Me.LblStatus.TabIndex = 666
        Me.LblStatus.Text = "Status"
        '
        'TxtStatus
        '
        Me.TxtStatus.AgMandatory = True
        Me.TxtStatus.AgMasterHelp = False
        Me.TxtStatus.AgNumberLeftPlaces = 0
        Me.TxtStatus.AgNumberNegetiveAllow = False
        Me.TxtStatus.AgNumberRightPlaces = 0
        Me.TxtStatus.AgPickFromLastValue = False
        Me.TxtStatus.AgRowFilter = ""
        Me.TxtStatus.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStatus.AgSelectedValue = Nothing
        Me.TxtStatus.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStatus.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStatus.ForeColor = System.Drawing.Color.Blue
        Me.TxtStatus.Location = New System.Drawing.Point(125, 104)
        Me.TxtStatus.MaxLength = 20
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(293, 21)
        Me.TxtStatus.TabIndex = 2
        '
        'LblStreamYearSemester
        '
        Me.LblStreamYearSemester.AutoSize = True
        Me.LblStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblStreamYearSemester.Location = New System.Drawing.Point(20, 129)
        Me.LblStreamYearSemester.Name = "LblStreamYearSemester"
        Me.LblStreamYearSemester.Size = New System.Drawing.Size(62, 13)
        Me.LblStreamYearSemester.TabIndex = 664
        Me.LblStreamYearSemester.Text = "Semester"
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
        Me.TxtStreamYearSemester.Location = New System.Drawing.Point(125, 125)
        Me.TxtStreamYearSemester.MaxLength = 0
        Me.TxtStreamYearSemester.Name = "TxtStreamYearSemester"
        Me.TxtStreamYearSemester.Size = New System.Drawing.Size(293, 21)
        Me.TxtStreamYearSemester.TabIndex = 3
        '
        'Tc1
        '
        Me.Tc1.Controls.Add(Me.Tp3)
        Me.Tc1.Controls.Add(Me.Tp1)
        Me.Tc1.Controls.Add(Me.Tp2)
        Me.Tc1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tc1.Location = New System.Drawing.Point(12, 181)
        Me.Tc1.Name = "Tc1"
        Me.Tc1.SelectedIndex = 0
        Me.Tc1.Size = New System.Drawing.Size(918, 357)
        Me.Tc1.TabIndex = 10
        '
        'Tp3
        '
        Me.Tp3.Controls.Add(Me.GrpReversePost)
        Me.Tp3.Controls.Add(Me.Label2)
        Me.Tp3.Controls.Add(Me.TxtTotalAmount)
        Me.Tp3.Controls.Add(Me.LblV_No)
        Me.Tp3.Controls.Add(Me.TxtDocId)
        Me.Tp3.Controls.Add(Me.TxtV_No)
        Me.Tp3.Controls.Add(Me.Label7)
        Me.Tp3.Controls.Add(Me.TxtRemark)
        Me.Tp3.Controls.Add(Me.LblPrefix)
        Me.Tp3.Controls.Add(Me.LblV_TypeReq)
        Me.Tp3.Controls.Add(Me.Label1)
        Me.Tp3.Controls.Add(Me.Pnl3)
        Me.Tp3.Controls.Add(Me.LblV_Type)
        Me.Tp3.Controls.Add(Me.TxtSite_Code)
        Me.Tp3.Controls.Add(Me.TxtV_Type)
        Me.Tp3.Location = New System.Drawing.Point(4, 22)
        Me.Tp3.Name = "Tp3"
        Me.Tp3.Size = New System.Drawing.Size(910, 331)
        Me.Tp3.TabIndex = 4
        Me.Tp3.Text = "Reverse Dues"
        Me.Tp3.UseVisualStyleBackColor = True
        '
        'GrpReversePost
        '
        Me.GrpReversePost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpReversePost.Controls.Add(Me.BtnFillDues)
        Me.GrpReversePost.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpReversePost.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpReversePost.ForeColor = System.Drawing.Color.Maroon
        Me.GrpReversePost.Location = New System.Drawing.Point(729, 8)
        Me.GrpReversePost.Name = "GrpReversePost"
        Me.GrpReversePost.Size = New System.Drawing.Size(163, 50)
        Me.GrpReversePost.TabIndex = 691
        Me.GrpReversePost.TabStop = False
        Me.GrpReversePost.Tag = "UP"
        Me.GrpReversePost.Text = "Fill Fee For Reverse Posting"
        '
        'BtnFillDues
        '
        Me.BtnFillDues.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BtnFillDues.Location = New System.Drawing.Point(11, 17)
        Me.BtnFillDues.Name = "BtnFillDues"
        Me.BtnFillDues.Size = New System.Drawing.Size(141, 23)
        Me.BtnFillDues.TabIndex = 3
        Me.BtnFillDues.Text = "Fill Dues"
        Me.BtnFillDues.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(655, 304)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 433
        Me.Label2.Text = "Total Amount"
        '
        'TxtTotalAmount
        '
        Me.TxtTotalAmount.AgMandatory = True
        Me.TxtTotalAmount.AgMasterHelp = False
        Me.TxtTotalAmount.AgNumberLeftPlaces = 8
        Me.TxtTotalAmount.AgNumberNegetiveAllow = False
        Me.TxtTotalAmount.AgNumberRightPlaces = 0
        Me.TxtTotalAmount.AgPickFromLastValue = False
        Me.TxtTotalAmount.AgRowFilter = ""
        Me.TxtTotalAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTotalAmount.AgSelectedValue = Nothing
        Me.TxtTotalAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTotalAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtTotalAmount.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotalAmount.Location = New System.Drawing.Point(755, 300)
        Me.TxtTotalAmount.Name = "TxtTotalAmount"
        Me.TxtTotalAmount.Size = New System.Drawing.Size(137, 21)
        Me.TxtTotalAmount.TabIndex = 432
        Me.TxtTotalAmount.Text = "TxtTotalAmount"
        Me.TxtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LblV_No
        '
        Me.LblV_No.AutoSize = True
        Me.LblV_No.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_No.Location = New System.Drawing.Point(493, 19)
        Me.LblV_No.Name = "LblV_No"
        Me.LblV_No.Size = New System.Drawing.Size(47, 13)
        Me.LblV_No.TabIndex = 682
        Me.LblV_No.Text = "Vr. No."
        '
        'TxtDocId
        '
        Me.TxtDocId.AgMandatory = False
        Me.TxtDocId.AgMasterHelp = False
        Me.TxtDocId.AgNumberLeftPlaces = 0
        Me.TxtDocId.AgNumberNegetiveAllow = False
        Me.TxtDocId.AgNumberRightPlaces = 0
        Me.TxtDocId.AgPickFromLastValue = False
        Me.TxtDocId.AgRowFilter = ""
        Me.TxtDocId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDocId.AgSelectedValue = Nothing
        Me.TxtDocId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDocId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDocId.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDocId.Location = New System.Drawing.Point(431, 297)
        Me.TxtDocId.MaxLength = 21
        Me.TxtDocId.Name = "TxtDocId"
        Me.TxtDocId.ReadOnly = True
        Me.TxtDocId.Size = New System.Drawing.Size(71, 21)
        Me.TxtDocId.TabIndex = 671
        Me.TxtDocId.TabStop = False
        Me.TxtDocId.Text = "TxtDocId"
        Me.TxtDocId.Visible = False
        '
        'TxtV_No
        '
        Me.TxtV_No.AgMandatory = True
        Me.TxtV_No.AgMasterHelp = False
        Me.TxtV_No.AgNumberLeftPlaces = 8
        Me.TxtV_No.AgNumberNegetiveAllow = False
        Me.TxtV_No.AgNumberRightPlaces = 0
        Me.TxtV_No.AgPickFromLastValue = False
        Me.TxtV_No.AgRowFilter = ""
        Me.TxtV_No.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_No.AgSelectedValue = Nothing
        Me.TxtV_No.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_No.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtV_No.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_No.Location = New System.Drawing.Point(602, 15)
        Me.TxtV_No.Name = "TxtV_No"
        Me.TxtV_No.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_No.TabIndex = 2
        Me.TxtV_No.Text = "TxtV_No"
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(18, 303)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 13)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Remark"
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
        Me.TxtRemark.Location = New System.Drawing.Point(76, 300)
        Me.TxtRemark.MaxLength = 150
        Me.TxtRemark.Name = "TxtRemark"
        Me.TxtRemark.Size = New System.Drawing.Size(325, 21)
        Me.TxtRemark.TabIndex = 6
        Me.TxtRemark.Text = "TxtRemark"
        '
        'LblPrefix
        '
        Me.LblPrefix.AutoSize = True
        Me.LblPrefix.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPrefix.ForeColor = System.Drawing.Color.Blue
        Me.LblPrefix.Location = New System.Drawing.Point(537, 19)
        Me.LblPrefix.Name = "LblPrefix"
        Me.LblPrefix.Size = New System.Drawing.Size(56, 13)
        Me.LblPrefix.TabIndex = 677
        Me.LblPrefix.Text = "LblPrefix"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.AutoSize = True
        Me.LblV_TypeReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblV_TypeReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblV_TypeReq.Location = New System.Drawing.Point(110, 22)
        Me.LblV_TypeReq.Name = "LblV_TypeReq"
        Me.LblV_TypeReq.Size = New System.Drawing.Size(10, 7)
        Me.LblV_TypeReq.TabIndex = 1
        Me.LblV_TypeReq.Text = "Ä"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(18, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 13)
        Me.Label1.TabIndex = 622
        Me.Label1.Text = "Select Fee Head(s) For Reverse Posting:"
        '
        'Pnl3
        '
        Me.Pnl3.Location = New System.Drawing.Point(18, 61)
        Me.Pnl3.Name = "Pnl3"
        Me.Pnl3.Size = New System.Drawing.Size(874, 230)
        Me.Pnl3.TabIndex = 4
        '
        'LblV_Type
        '
        Me.LblV_Type.AutoSize = True
        Me.LblV_Type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Type.Location = New System.Drawing.Point(18, 19)
        Me.LblV_Type.Name = "LblV_Type"
        Me.LblV_Type.Size = New System.Drawing.Size(86, 13)
        Me.LblV_Type.TabIndex = 679
        Me.LblV_Type.Text = "Voucher Type"
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
        Me.TxtSite_Code.Location = New System.Drawing.Point(508, 297)
        Me.TxtSite_Code.MaxLength = 2
        Me.TxtSite_Code.Name = "TxtSite_Code"
        Me.TxtSite_Code.ReadOnly = True
        Me.TxtSite_Code.Size = New System.Drawing.Size(71, 21)
        Me.TxtSite_Code.TabIndex = 672
        Me.TxtSite_Code.TabStop = False
        Me.TxtSite_Code.Text = "TxtSite_Code"
        Me.TxtSite_Code.Visible = False
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgMandatory = True
        Me.TxtV_Type.AgMasterHelp = False
        Me.TxtV_Type.AgNumberLeftPlaces = 0
        Me.TxtV_Type.AgNumberNegetiveAllow = False
        Me.TxtV_Type.AgNumberRightPlaces = 0
        Me.TxtV_Type.AgPickFromLastValue = False
        Me.TxtV_Type.AgRowFilter = ""
        Me.TxtV_Type.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_Type.AgSelectedValue = Nothing
        Me.TxtV_Type.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_Type.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtV_Type.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_Type.Location = New System.Drawing.Point(123, 15)
        Me.TxtV_Type.MaxLength = 5
        Me.TxtV_Type.Name = "TxtV_Type"
        Me.TxtV_Type.Size = New System.Drawing.Size(293, 21)
        Me.TxtV_Type.TabIndex = 0
        Me.TxtV_Type.Text = "TxtV_Type"
        '
        'Tp1
        '
        Me.Tp1.Controls.Add(Me.LblFeeDetail)
        Me.Tp1.Controls.Add(Me.Pnl1)
        Me.Tp1.Location = New System.Drawing.Point(4, 22)
        Me.Tp1.Name = "Tp1"
        Me.Tp1.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp1.Size = New System.Drawing.Size(910, 331)
        Me.Tp1.TabIndex = 0
        Me.Tp1.Text = "Fee Detail"
        Me.Tp1.UseVisualStyleBackColor = True
        '
        'LblFeeDetail
        '
        Me.LblFeeDetail.AutoSize = True
        Me.LblFeeDetail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFeeDetail.ForeColor = System.Drawing.Color.Blue
        Me.LblFeeDetail.Location = New System.Drawing.Point(21, 15)
        Me.LblFeeDetail.Name = "LblFeeDetail"
        Me.LblFeeDetail.Size = New System.Drawing.Size(69, 13)
        Me.LblFeeDetail.TabIndex = 621
        Me.LblFeeDetail.Text = "Fee Detail:"
        '
        'Pnl1
        '
        Me.Pnl1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Pnl1.Location = New System.Drawing.Point(24, 30)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(875, 282)
        Me.Pnl1.TabIndex = 1
        '
        'Tp2
        '
        Me.Tp2.Controls.Add(Me.Label110)
        Me.Tp2.Controls.Add(Me.Pnl2)
        Me.Tp2.Location = New System.Drawing.Point(4, 22)
        Me.Tp2.Name = "Tp2"
        Me.Tp2.Padding = New System.Windows.Forms.Padding(3)
        Me.Tp2.Size = New System.Drawing.Size(910, 331)
        Me.Tp2.TabIndex = 1
        Me.Tp2.Text = "Subject Detail"
        Me.Tp2.UseVisualStyleBackColor = True
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label110.ForeColor = System.Drawing.Color.Blue
        Me.Label110.Location = New System.Drawing.Point(3, 14)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(92, 13)
        Me.Label110.TabIndex = 594
        Me.Label110.Text = "Subject Detail:"
        '
        'Pnl2
        '
        Me.Pnl2.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Pnl2.Location = New System.Drawing.Point(7, 30)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(886, 282)
        Me.Pnl2.TabIndex = 24
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
        Me.TxtV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_Date.ForeColor = System.Drawing.Color.Blue
        Me.TxtV_Date.Location = New System.Drawing.Point(822, 82)
        Me.TxtV_Date.MaxLength = 20
        Me.TxtV_Date.Name = "TxtV_Date"
        Me.TxtV_Date.Size = New System.Drawing.Size(100, 21)
        Me.TxtV_Date.TabIndex = 7
        '
        'LblV_Date
        '
        Me.LblV_Date.AutoSize = True
        Me.LblV_Date.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblV_Date.Location = New System.Drawing.Point(732, 86)
        Me.LblV_Date.Name = "LblV_Date"
        Me.LblV_Date.Size = New System.Drawing.Size(92, 13)
        Me.LblV_Date.TabIndex = 672
        Me.LblV_Date.Text = "New Status Dt."
        '
        'LblNewSemesterFee
        '
        Me.LblNewSemesterFee.AutoSize = True
        Me.LblNewSemesterFee.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewSemesterFee.Location = New System.Drawing.Point(495, 130)
        Me.LblNewSemesterFee.Name = "LblNewSemesterFee"
        Me.LblNewSemesterFee.Size = New System.Drawing.Size(114, 13)
        Me.LblNewSemesterFee.TabIndex = 684
        Me.LblNewSemesterFee.Text = "New Semester Fee"
        '
        'TxtNewSemesterFee
        '
        Me.TxtNewSemesterFee.AgMandatory = True
        Me.TxtNewSemesterFee.AgMasterHelp = False
        Me.TxtNewSemesterFee.AgNumberLeftPlaces = 8
        Me.TxtNewSemesterFee.AgNumberNegetiveAllow = False
        Me.TxtNewSemesterFee.AgNumberRightPlaces = 2
        Me.TxtNewSemesterFee.AgPickFromLastValue = False
        Me.TxtNewSemesterFee.AgRowFilter = ""
        Me.TxtNewSemesterFee.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtNewSemesterFee.AgSelectedValue = Nothing
        Me.TxtNewSemesterFee.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtNewSemesterFee.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtNewSemesterFee.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNewSemesterFee.Location = New System.Drawing.Point(629, 126)
        Me.TxtNewSemesterFee.Name = "TxtNewSemesterFee"
        Me.TxtNewSemesterFee.Size = New System.Drawing.Size(100, 21)
        Me.TxtNewSemesterFee.TabIndex = 683
        Me.TxtNewSemesterFee.Text = "0.00"
        Me.TxtNewSemesterFee.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'BtnFillDetail
        '
        Me.BtnFillDetail.Location = New System.Drawing.Point(751, 152)
        Me.BtnFillDetail.Name = "BtnFillDetail"
        Me.BtnFillDetail.Size = New System.Drawing.Size(164, 23)
        Me.BtnFillDetail.TabIndex = 9
        Me.BtnFillDetail.Text = "Fill Fee && Subject &Detail"
        Me.BtnFillDetail.UseVisualStyleBackColor = True
        '
        'LblNewStreamYearSemester
        '
        Me.LblNewStreamYearSemester.AutoSize = True
        Me.LblNewStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewStreamYearSemester.Location = New System.Drawing.Point(496, 108)
        Me.LblNewStreamYearSemester.Name = "LblNewStreamYearSemester"
        Me.LblNewStreamYearSemester.Size = New System.Drawing.Size(90, 13)
        Me.LblNewStreamYearSemester.TabIndex = 632
        Me.LblNewStreamYearSemester.Text = "New Semester"
        '
        'TxtNewStreamYearSemester
        '
        Me.TxtNewStreamYearSemester.AgMandatory = False
        Me.TxtNewStreamYearSemester.AgMasterHelp = False
        Me.TxtNewStreamYearSemester.AgNumberLeftPlaces = 0
        Me.TxtNewStreamYearSemester.AgNumberNegetiveAllow = False
        Me.TxtNewStreamYearSemester.AgNumberRightPlaces = 0
        Me.TxtNewStreamYearSemester.AgPickFromLastValue = False
        Me.TxtNewStreamYearSemester.AgRowFilter = ""
        Me.TxtNewStreamYearSemester.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtNewStreamYearSemester.AgSelectedValue = Nothing
        Me.TxtNewStreamYearSemester.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtNewStreamYearSemester.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtNewStreamYearSemester.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNewStreamYearSemester.Location = New System.Drawing.Point(629, 104)
        Me.TxtNewStreamYearSemester.MaxLength = 0
        Me.TxtNewStreamYearSemester.Name = "TxtNewStreamYearSemester"
        Me.TxtNewStreamYearSemester.Size = New System.Drawing.Size(293, 21)
        Me.TxtNewStreamYearSemester.TabIndex = 8
        '
        'TxtNewStatus
        '
        Me.TxtNewStatus.AgMandatory = True
        Me.TxtNewStatus.AgMasterHelp = False
        Me.TxtNewStatus.AgNumberLeftPlaces = 0
        Me.TxtNewStatus.AgNumberNegetiveAllow = False
        Me.TxtNewStatus.AgNumberRightPlaces = 0
        Me.TxtNewStatus.AgPickFromLastValue = False
        Me.TxtNewStatus.AgRowFilter = ""
        Me.TxtNewStatus.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtNewStatus.AgSelectedValue = Nothing
        Me.TxtNewStatus.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtNewStatus.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtNewStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNewStatus.ForeColor = System.Drawing.Color.Blue
        Me.TxtNewStatus.Location = New System.Drawing.Point(629, 82)
        Me.TxtNewStatus.MaxLength = 20
        Me.TxtNewStatus.Name = "TxtNewStatus"
        Me.TxtNewStatus.Size = New System.Drawing.Size(100, 21)
        Me.TxtNewStatus.TabIndex = 6
        '
        'LblNewStatus
        '
        Me.LblNewStatus.AutoSize = True
        Me.LblNewStatus.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNewStatus.Location = New System.Drawing.Point(496, 86)
        Me.LblNewStatus.Name = "LblNewStatus"
        Me.LblNewStatus.Size = New System.Drawing.Size(78, 13)
        Me.LblNewStatus.TabIndex = 632
        Me.LblNewStatus.Text = "New Status*"
        '
        'TxtIsNewStatusAfterPromotion
        '
        Me.TxtIsNewStatusAfterPromotion.AgMandatory = False
        Me.TxtIsNewStatusAfterPromotion.AgMasterHelp = False
        Me.TxtIsNewStatusAfterPromotion.AgNumberLeftPlaces = 0
        Me.TxtIsNewStatusAfterPromotion.AgNumberNegetiveAllow = False
        Me.TxtIsNewStatusAfterPromotion.AgNumberRightPlaces = 0
        Me.TxtIsNewStatusAfterPromotion.AgPickFromLastValue = False
        Me.TxtIsNewStatusAfterPromotion.AgRowFilter = ""
        Me.TxtIsNewStatusAfterPromotion.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIsNewStatusAfterPromotion.AgSelectedValue = Nothing
        Me.TxtIsNewStatusAfterPromotion.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIsNewStatusAfterPromotion.AgValueType = AgControls.AgTextBox.TxtValueType.YesNo_Value
        Me.TxtIsNewStatusAfterPromotion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIsNewStatusAfterPromotion.Location = New System.Drawing.Point(684, 60)
        Me.TxtIsNewStatusAfterPromotion.MaxLength = 3
        Me.TxtIsNewStatusAfterPromotion.Name = "TxtIsNewStatusAfterPromotion"
        Me.TxtIsNewStatusAfterPromotion.Size = New System.Drawing.Size(45, 21)
        Me.TxtIsNewStatusAfterPromotion.TabIndex = 4
        '
        'LblIsNewStatusAfterPromotion
        '
        Me.LblIsNewStatusAfterPromotion.AutoSize = True
        Me.LblIsNewStatusAfterPromotion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIsNewStatusAfterPromotion.Location = New System.Drawing.Point(496, 64)
        Me.LblIsNewStatusAfterPromotion.Name = "LblIsNewStatusAfterPromotion"
        Me.LblIsNewStatusAfterPromotion.Size = New System.Drawing.Size(186, 13)
        Me.LblIsNewStatusAfterPromotion.TabIndex = 645
        Me.LblIsNewStatusAfterPromotion.Text = "Is New Status After Promotion?"
        '
        'LblSemesterLastTransactionDate
        '
        Me.LblSemesterLastTransactionDate.AutoSize = True
        Me.LblSemesterLastTransactionDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSemesterLastTransactionDate.ForeColor = System.Drawing.SystemColors.ControlText
        Me.LblSemesterLastTransactionDate.Location = New System.Drawing.Point(19, 149)
        Me.LblSemesterLastTransactionDate.Name = "LblSemesterLastTransactionDate"
        Me.LblSemesterLastTransactionDate.Size = New System.Drawing.Size(101, 13)
        Me.LblSemesterLastTransactionDate.TabIndex = 685
        Me.LblSemesterLastTransactionDate.Text = "Last Trans. Date"
        '
        'TxtSemesterLastTransactionDate
        '
        Me.TxtSemesterLastTransactionDate.AgMandatory = True
        Me.TxtSemesterLastTransactionDate.AgMasterHelp = False
        Me.TxtSemesterLastTransactionDate.AgNumberLeftPlaces = 0
        Me.TxtSemesterLastTransactionDate.AgNumberNegetiveAllow = False
        Me.TxtSemesterLastTransactionDate.AgNumberRightPlaces = 0
        Me.TxtSemesterLastTransactionDate.AgPickFromLastValue = False
        Me.TxtSemesterLastTransactionDate.AgRowFilter = ""
        Me.TxtSemesterLastTransactionDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSemesterLastTransactionDate.AgSelectedValue = Nothing
        Me.TxtSemesterLastTransactionDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSemesterLastTransactionDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtSemesterLastTransactionDate.BackColor = System.Drawing.Color.White
        Me.TxtSemesterLastTransactionDate.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSemesterLastTransactionDate.ForeColor = System.Drawing.Color.Blue
        Me.TxtSemesterLastTransactionDate.Location = New System.Drawing.Point(125, 146)
        Me.TxtSemesterLastTransactionDate.MaxLength = 20
        Me.TxtSemesterLastTransactionDate.Name = "TxtSemesterLastTransactionDate"
        Me.TxtSemesterLastTransactionDate.ReadOnly = True
        Me.TxtSemesterLastTransactionDate.Size = New System.Drawing.Size(100, 21)
        Me.TxtSemesterLastTransactionDate.TabIndex = 686
        Me.TxtSemesterLastTransactionDate.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.BtnApproved)
        Me.GroupBox1.Controls.Add(Me.TxtApproved)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(735, 550)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox1.TabIndex = 690
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Tag = "UP"
        Me.GroupBox1.Text = "Approved By "
        Me.GroupBox1.Visible = False
        '
        'BtnApproved
        '
        Me.BtnApproved.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnApproved.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.BtnApproved.Image = CType(resources.GetObject("BtnApproved.Image"), System.Drawing.Image)
        Me.BtnApproved.Location = New System.Drawing.Point(8, 19)
        Me.BtnApproved.Name = "BtnApproved"
        Me.BtnApproved.Size = New System.Drawing.Size(23, 23)
        Me.BtnApproved.TabIndex = 36
        Me.BtnApproved.UseVisualStyleBackColor = True
        '
        'TxtApproved
        '
        Me.TxtApproved.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtApproved.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApproved.Location = New System.Drawing.Point(36, 21)
        Me.TxtApproved.Name = "TxtApproved"
        Me.TxtApproved.Size = New System.Drawing.Size(142, 18)
        Me.TxtApproved.TabIndex = 0
        Me.TxtApproved.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GrpUP
        '
        Me.GrpUP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GrpUP.Controls.Add(Me.TxtPrepared)
        Me.GrpUP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpUP.Font = New System.Drawing.Font("Arial", 9.75!)
        Me.GrpUP.ForeColor = System.Drawing.Color.Maroon
        Me.GrpUP.Location = New System.Drawing.Point(12, 550)
        Me.GrpUP.Name = "GrpUP"
        Me.GrpUP.Size = New System.Drawing.Size(186, 51)
        Me.GrpUP.TabIndex = 688
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
        Me.GroupBox4.Location = New System.Drawing.Point(396, 550)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(186, 51)
        Me.GroupBox4.TabIndex = 689
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
        Me.GroupBox2.Location = New System.Drawing.Point(-4, 540)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(942, 4)
        Me.GroupBox2.TabIndex = 687
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Tag = ""
        '
        'FrmStatusChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(934, 612)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GrpUP)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TxtSemesterLastTransactionDate)
        Me.Controls.Add(Me.LblSemesterLastTransactionDate)
        Me.Controls.Add(Me.LblNewSemesterFee)
        Me.Controls.Add(Me.TxtIsNewStatusAfterPromotion)
        Me.Controls.Add(Me.TxtNewSemesterFee)
        Me.Controls.Add(Me.TxtV_Date)
        Me.Controls.Add(Me.LblIsNewStatusAfterPromotion)
        Me.Controls.Add(Me.LblV_Date)
        Me.Controls.Add(Me.BtnFillDetail)
        Me.Controls.Add(Me.Tc1)
        Me.Controls.Add(Me.LblNewStreamYearSemester)
        Me.Controls.Add(Me.LblIsStreamChangeReq)
        Me.Controls.Add(Me.TxtNewStreamYearSemester)
        Me.Controls.Add(Me.TxtIsStreamChange)
        Me.Controls.Add(Me.TxtNewStatus)
        Me.Controls.Add(Me.LblIsStreamChange)
        Me.Controls.Add(Me.LblNewStatus)
        Me.Controls.Add(Me.LblStatus)
        Me.Controls.Add(Me.TxtStatus)
        Me.Controls.Add(Me.LblStreamYearSemester)
        Me.Controls.Add(Me.TxtStreamYearSemester)
        Me.Controls.Add(Me.LblAdmissionDocIdReq)
        Me.Controls.Add(Me.TxtAdmissionID)
        Me.Controls.Add(Me.LblAdmissionID)
        Me.Controls.Add(Me.TxtAdmissionDocId)
        Me.Controls.Add(Me.LblAdmissionDocId)
        Me.Controls.Add(Me.Topctrl1)
        Me.KeyPreview = True
        Me.Name = "FrmStatusChange"
        Me.Text = "Status Change"
        Me.Tc1.ResumeLayout(False)
        Me.Tp3.ResumeLayout(False)
        Me.Tp3.PerformLayout()
        Me.GrpReversePost.ResumeLayout(False)
        Me.Tp1.ResumeLayout(False)
        Me.Tp1.PerformLayout()
        Me.Tp2.ResumeLayout(False)
        Me.Tp2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Topctrl1 As Topctrl.Topctrl
    Friend WithEvents LblAdmissionDocIdReq As System.Windows.Forms.Label
    Friend WithEvents TxtAdmissionID As AgControls.AgTextBox
    Friend WithEvents LblAdmissionID As System.Windows.Forms.Label
    Friend WithEvents TxtAdmissionDocId As AgControls.AgTextBox
    Friend WithEvents LblAdmissionDocId As System.Windows.Forms.Label
    Friend WithEvents LblIsStreamChangeReq As System.Windows.Forms.Label
    Friend WithEvents TxtIsStreamChange As AgControls.AgTextBox
    Friend WithEvents LblIsStreamChange As System.Windows.Forms.Label
    Friend WithEvents LblStatus As System.Windows.Forms.Label
    Friend WithEvents TxtStatus As AgControls.AgTextBox
    Friend WithEvents LblStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents TxtStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents Tc1 As System.Windows.Forms.TabControl
    Friend WithEvents Tp1 As System.Windows.Forms.TabPage
    Friend WithEvents LblFeeDetail As System.Windows.Forms.Label
    Friend WithEvents Pnl1 As System.Windows.Forms.Panel
    Friend WithEvents BtnFillDetail As System.Windows.Forms.Button
    Friend WithEvents LblNewStreamYearSemester As System.Windows.Forms.Label
    Friend WithEvents TxtNewStreamYearSemester As AgControls.AgTextBox
    Friend WithEvents TxtNewStatus As AgControls.AgTextBox
    Friend WithEvents LblNewStatus As System.Windows.Forms.Label
    Friend WithEvents TxtIsNewStatusAfterPromotion As AgControls.AgTextBox
    Friend WithEvents LblIsNewStatusAfterPromotion As System.Windows.Forms.Label
    Friend WithEvents LblNewSemesterFee As System.Windows.Forms.Label
    Friend WithEvents TxtNewSemesterFee As AgControls.AgTextBox
    Friend WithEvents TxtDocId As AgControls.AgTextBox
    Friend WithEvents LblV_No As System.Windows.Forms.Label
    Friend WithEvents TxtV_No As AgControls.AgTextBox
    Friend WithEvents LblV_TypeReq As System.Windows.Forms.Label
    Friend WithEvents LblV_Type As System.Windows.Forms.Label
    Friend WithEvents TxtV_Type As AgControls.AgTextBox
    Friend WithEvents TxtSite_Code As AgControls.AgTextBox
    Friend WithEvents LblPrefix As System.Windows.Forms.Label
    Friend WithEvents Tp3 As System.Windows.Forms.TabPage
    Friend WithEvents Pnl3 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TxtRemark As AgControls.AgTextBox
    Friend WithEvents BtnFillDues As System.Windows.Forms.Button
    Friend WithEvents TxtV_Date As AgControls.AgTextBox
    Friend WithEvents LblV_Date As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TxtTotalAmount As AgControls.AgTextBox
    Friend WithEvents Tp2 As System.Windows.Forms.TabPage
    Friend WithEvents Label110 As System.Windows.Forms.Label
    Friend WithEvents Pnl2 As System.Windows.Forms.Panel
    Friend WithEvents LblSemesterLastTransactionDate As System.Windows.Forms.Label
    Friend WithEvents TxtSemesterLastTransactionDate As AgControls.AgTextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BtnApproved As System.Windows.Forms.Button
    Friend WithEvents TxtApproved As System.Windows.Forms.TextBox
    Friend WithEvents GrpUP As System.Windows.Forms.GroupBox
    Friend WithEvents TxtPrepared As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TxtModified As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GrpReversePost As System.Windows.Forms.GroupBox
End Class
