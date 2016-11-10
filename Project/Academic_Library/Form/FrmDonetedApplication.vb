Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmDonatedApplication
    Inherits AgTemplate.TempTransaction
    Public mQry$
    Dim mTransFlag As Boolean = False

    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1Item As String = "Book"
    Protected Const Col1Writer As String = "Writer"
    Protected Const Col1Publisher As String = "Publisher"
    Protected WithEvents TxtMonthlyParentsIncome As AgControls.AgTextBox
    Protected WithEvents LblMonthlyFamIncome As System.Windows.Forms.Label
    Protected WithEvents TxtSubjectofStudent As AgControls.AgTextBox
    Protected WithEvents LblSubjectofStudent As System.Windows.Forms.Label
    Protected WithEvents TxtAttestedbyStaff As AgControls.AgTextBox
    Protected WithEvents LblAttestedbyStaff As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasureTextReq As System.Windows.Forms.Label
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label


    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.GRDonatedBooks
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.TxtMemberName = New AgControls.AgTextBox
        Me.LblMemberName = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalMeasure = New System.Windows.Forms.Label
        Me.LblTotalMeasureTextReq = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.MemberCardNoReq = New System.Windows.Forms.Label
        Me.TxtMemberCardNo = New AgControls.AgTextBox
        Me.LblMemberCardNo = New System.Windows.Forms.Label
        Me.TxtMonthlyParentsIncome = New AgControls.AgTextBox
        Me.LblMonthlyFamIncome = New System.Windows.Forms.Label
        Me.TxtSubjectofStudent = New AgControls.AgTextBox
        Me.LblSubjectofStudent = New System.Windows.Forms.Label
        Me.TxtAttestedbyStaff = New AgControls.AgTextBox
        Me.LblAttestedbyStaff = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(718, 465)
        Me.GroupBox2.Size = New System.Drawing.Size(148, 40)
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Location = New System.Drawing.Point(29, 19)
        Me.TxtStatus.Tag = ""
        '
        'CmdStatus
        '
        Me.CmdStatus.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(596, 465)
        Me.GBoxMoveToLog.Size = New System.Drawing.Size(148, 40)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 19)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(142, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'CmdMoveToLog
        '
        Me.CmdMoveToLog.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(421, 465)
        Me.GBoxApprove.Size = New System.Drawing.Size(148, 40)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Location = New System.Drawing.Point(29, 19)
        Me.TxtApproveBy.Tag = ""
        '
        'CmdDiscard
        '
        Me.CmdDiscard.Size = New System.Drawing.Size(26, 19)
        '
        'CmdApprove
        '
        Me.CmdApprove.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(145, 465)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(11, 465)
        Me.GrpUP.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 461)
        Me.GroupBox1.Size = New System.Drawing.Size(895, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(287, 465)
        Me.GBoxDivision.Size = New System.Drawing.Size(114, 40)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Location = New System.Drawing.Point(3, 19)
        Me.TxtDivision.Tag = ""
        '
        'TxtDocId
        '
        Me.TxtDocId.AgSelectedValue = ""
        Me.TxtDocId.BackColor = System.Drawing.Color.White
        Me.TxtDocId.Tag = ""
        Me.TxtDocId.Text = ""
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(422, 35)
        Me.LblV_No.Size = New System.Drawing.Size(96, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Application No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(533, 33)
        Me.TxtV_No.Size = New System.Drawing.Size(194, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(301, 40)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(163, 35)
        Me.LblV_Date.Size = New System.Drawing.Size(103, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Application Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(524, 21)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(317, 33)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(422, 16)
        Me.LblV_Type.Size = New System.Drawing.Size(104, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Application Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(533, 14)
        Me.TxtV_Type.Size = New System.Drawing.Size(194, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(301, 20)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(163, 16)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(317, 14)
        Me.TxtSite_Code.Size = New System.Drawing.Size(100, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(20, 35)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(3, 20)
        Me.TabControl1.Size = New System.Drawing.Size(873, 186)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.TxtAttestedbyStaff)
        Me.TP1.Controls.Add(Me.LblAttestedbyStaff)
        Me.TP1.Controls.Add(Me.TxtSubjectofStudent)
        Me.TP1.Controls.Add(Me.LblSubjectofStudent)
        Me.TP1.Controls.Add(Me.TxtMonthlyParentsIncome)
        Me.TP1.Controls.Add(Me.LblMonthlyFamIncome)
        Me.TP1.Controls.Add(Me.LblMemberCardNo)
        Me.TP1.Controls.Add(Me.MemberCardNoReq)
        Me.TP1.Controls.Add(Me.TxtMemberCardNo)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.TxtMemberName)
        Me.TP1.Controls.Add(Me.LblMemberName)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(865, 160)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMemberName, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMemberName, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMemberCardNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.MemberCardNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMemberCardNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMonthlyFamIncome, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMonthlyParentsIncome, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSubjectofStudent, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSubjectofStudent, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAttestedbyStaff, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAttestedbyStaff, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(877, 41)
        Me.Topctrl1.TabIndex = 2
        '
        'Dgl1
        '
        Me.Dgl1.AgMandatoryColumn = 0
        Me.Dgl1.AgReadOnlyColumnColor = System.Drawing.Color.Ivory
        Me.Dgl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Dgl1.CancelEditingControlValidating = False
        Me.Dgl1.Location = New System.Drawing.Point(0, 0)
        Me.Dgl1.Name = "Dgl1"
        Me.Dgl1.Size = New System.Drawing.Size(240, 150)
        Me.Dgl1.TabIndex = 0
        '
        'TxtMemberName
        '
        Me.TxtMemberName.AgMandatory = False
        Me.TxtMemberName.AgMasterHelp = False
        Me.TxtMemberName.AgNumberLeftPlaces = 8
        Me.TxtMemberName.AgNumberNegetiveAllow = False
        Me.TxtMemberName.AgNumberRightPlaces = 2
        Me.TxtMemberName.AgPickFromLastValue = False
        Me.TxtMemberName.AgRowFilter = ""
        Me.TxtMemberName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberName.AgSelectedValue = Nothing
        Me.TxtMemberName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMemberName.Enabled = False
        Me.TxtMemberName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberName.Location = New System.Drawing.Point(533, 71)
        Me.TxtMemberName.MaxLength = 50
        Me.TxtMemberName.Name = "TxtMemberName"
        Me.TxtMemberName.Size = New System.Drawing.Size(194, 18)
        Me.TxtMemberName.TabIndex = 6
        '
        'LblMemberName
        '
        Me.LblMemberName.AutoSize = True
        Me.LblMemberName.BackColor = System.Drawing.Color.Transparent
        Me.LblMemberName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberName.Location = New System.Drawing.Point(422, 73)
        Me.LblMemberName.Name = "LblMemberName"
        Me.LblMemberName.Size = New System.Drawing.Size(93, 16)
        Me.LblMemberName.TabIndex = 706
        Me.LblMemberName.Text = "Member Name"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalMeasure)
        Me.Panel1.Controls.Add(Me.LblTotalMeasureTextReq)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Location = New System.Drawing.Point(8, 416)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(864, 21)
        Me.Panel1.TabIndex = 694
        Me.Panel1.Visible = False
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.AutoSize = True
        Me.LblTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalMeasure.Location = New System.Drawing.Point(499, 2)
        Me.LblTotalMeasure.Name = "LblTotalMeasure"
        Me.LblTotalMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalMeasure.TabIndex = 672
        Me.LblTotalMeasure.Text = "."
        Me.LblTotalMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalMeasureTextReq
        '
        Me.LblTotalMeasureTextReq.AutoSize = True
        Me.LblTotalMeasureTextReq.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasureTextReq.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalMeasureTextReq.Location = New System.Drawing.Point(388, 2)
        Me.LblTotalMeasureTextReq.Name = "LblTotalMeasureTextReq"
        Me.LblTotalMeasureTextReq.Size = New System.Drawing.Size(106, 16)
        Me.LblTotalMeasureTextReq.TabIndex = 671
        Me.LblTotalMeasureTextReq.Text = "Total Measure :"
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalQty.Location = New System.Drawing.Point(94, 3)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 668
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.AutoSize = True
        Me.LblTotalQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQtyText.Location = New System.Drawing.Point(9, 3)
        Me.LblTotalQtyText.Name = "LblTotalQtyText"
        Me.LblTotalQtyText.Size = New System.Drawing.Size(73, 16)
        Me.LblTotalQtyText.TabIndex = 667
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(6, 233)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(865, 183)
        Me.Pnl1.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(163, 130)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgMandatory = False
        Me.TxtRemarks.AgMasterHelp = False
        Me.TxtRemarks.AgNumberLeftPlaces = 0
        Me.TxtRemarks.AgNumberNegetiveAllow = False
        Me.TxtRemarks.AgNumberRightPlaces = 0
        Me.TxtRemarks.AgPickFromLastValue = False
        Me.TxtRemarks.AgRowFilter = ""
        Me.TxtRemarks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemarks.AgSelectedValue = Nothing
        Me.TxtRemarks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemarks.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemarks.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemarks.Location = New System.Drawing.Point(317, 128)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(410, 18)
        Me.TxtRemarks.TabIndex = 10
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(5, 213)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(159, 20)
        Me.LinkLabel1.TabIndex = 731
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Donation Following Items"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'MemberCardNoReq
        '
        Me.MemberCardNoReq.AutoSize = True
        Me.MemberCardNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.MemberCardNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.MemberCardNoReq.Location = New System.Drawing.Point(301, 78)
        Me.MemberCardNoReq.Name = "MemberCardNoReq"
        Me.MemberCardNoReq.Size = New System.Drawing.Size(10, 7)
        Me.MemberCardNoReq.TabIndex = 732
        Me.MemberCardNoReq.Text = "Ä"
        '
        'TxtMemberCardNo
        '
        Me.TxtMemberCardNo.AgMandatory = True
        Me.TxtMemberCardNo.AgMasterHelp = False
        Me.TxtMemberCardNo.AgNumberLeftPlaces = 8
        Me.TxtMemberCardNo.AgNumberNegetiveAllow = False
        Me.TxtMemberCardNo.AgNumberRightPlaces = 2
        Me.TxtMemberCardNo.AgPickFromLastValue = False
        Me.TxtMemberCardNo.AgRowFilter = ""
        Me.TxtMemberCardNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberCardNo.AgSelectedValue = Nothing
        Me.TxtMemberCardNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberCardNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberCardNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMemberCardNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberCardNo.Location = New System.Drawing.Point(317, 71)
        Me.TxtMemberCardNo.MaxLength = 20
        Me.TxtMemberCardNo.Name = "TxtMemberCardNo"
        Me.TxtMemberCardNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtMemberCardNo.TabIndex = 5
        '
        'LblMemberCardNo
        '
        Me.LblMemberCardNo.AutoSize = True
        Me.LblMemberCardNo.BackColor = System.Drawing.Color.Transparent
        Me.LblMemberCardNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberCardNo.Location = New System.Drawing.Point(163, 73)
        Me.LblMemberCardNo.Name = "LblMemberCardNo"
        Me.LblMemberCardNo.Size = New System.Drawing.Size(110, 16)
        Me.LblMemberCardNo.TabIndex = 731
        Me.LblMemberCardNo.Text = "Member Card No."
        '
        'TxtMonthlyParentsIncome
        '
        Me.TxtMonthlyParentsIncome.AgMandatory = False
        Me.TxtMonthlyParentsIncome.AgMasterHelp = False
        Me.TxtMonthlyParentsIncome.AgNumberLeftPlaces = 8
        Me.TxtMonthlyParentsIncome.AgNumberNegetiveAllow = False
        Me.TxtMonthlyParentsIncome.AgNumberRightPlaces = 2
        Me.TxtMonthlyParentsIncome.AgPickFromLastValue = False
        Me.TxtMonthlyParentsIncome.AgRowFilter = ""
        Me.TxtMonthlyParentsIncome.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMonthlyParentsIncome.AgSelectedValue = Nothing
        Me.TxtMonthlyParentsIncome.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMonthlyParentsIncome.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMonthlyParentsIncome.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMonthlyParentsIncome.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMonthlyParentsIncome.Location = New System.Drawing.Point(317, 90)
        Me.TxtMonthlyParentsIncome.MaxLength = 50
        Me.TxtMonthlyParentsIncome.Name = "TxtMonthlyParentsIncome"
        Me.TxtMonthlyParentsIncome.Size = New System.Drawing.Size(100, 18)
        Me.TxtMonthlyParentsIncome.TabIndex = 7
        '
        'LblMonthlyFamIncome
        '
        Me.LblMonthlyFamIncome.AutoSize = True
        Me.LblMonthlyFamIncome.BackColor = System.Drawing.Color.Transparent
        Me.LblMonthlyFamIncome.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMonthlyFamIncome.Location = New System.Drawing.Point(163, 92)
        Me.LblMonthlyFamIncome.Name = "LblMonthlyFamIncome"
        Me.LblMonthlyFamIncome.Size = New System.Drawing.Size(149, 16)
        Me.LblMonthlyFamIncome.TabIndex = 734
        Me.LblMonthlyFamIncome.Text = "Monthly Parents Income"
        '
        'TxtSubjectofStudent
        '
        Me.TxtSubjectofStudent.AgMandatory = False
        Me.TxtSubjectofStudent.AgMasterHelp = True
        Me.TxtSubjectofStudent.AgNumberLeftPlaces = 8
        Me.TxtSubjectofStudent.AgNumberNegetiveAllow = False
        Me.TxtSubjectofStudent.AgNumberRightPlaces = 2
        Me.TxtSubjectofStudent.AgPickFromLastValue = False
        Me.TxtSubjectofStudent.AgRowFilter = ""
        Me.TxtSubjectofStudent.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSubjectofStudent.AgSelectedValue = Nothing
        Me.TxtSubjectofStudent.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSubjectofStudent.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSubjectofStudent.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSubjectofStudent.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubjectofStudent.Location = New System.Drawing.Point(533, 90)
        Me.TxtSubjectofStudent.MaxLength = 100
        Me.TxtSubjectofStudent.Name = "TxtSubjectofStudent"
        Me.TxtSubjectofStudent.Size = New System.Drawing.Size(194, 18)
        Me.TxtSubjectofStudent.TabIndex = 8
        '
        'LblSubjectofStudent
        '
        Me.LblSubjectofStudent.AutoSize = True
        Me.LblSubjectofStudent.BackColor = System.Drawing.Color.Transparent
        Me.LblSubjectofStudent.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSubjectofStudent.Location = New System.Drawing.Point(422, 92)
        Me.LblSubjectofStudent.Name = "LblSubjectofStudent"
        Me.LblSubjectofStudent.Size = New System.Drawing.Size(115, 16)
        Me.LblSubjectofStudent.TabIndex = 736
        Me.LblSubjectofStudent.Text = "Subject of Student"
        '
        'TxtAttestedbyStaff
        '
        Me.TxtAttestedbyStaff.AgMandatory = False
        Me.TxtAttestedbyStaff.AgMasterHelp = False
        Me.TxtAttestedbyStaff.AgNumberLeftPlaces = 8
        Me.TxtAttestedbyStaff.AgNumberNegetiveAllow = False
        Me.TxtAttestedbyStaff.AgNumberRightPlaces = 2
        Me.TxtAttestedbyStaff.AgPickFromLastValue = False
        Me.TxtAttestedbyStaff.AgRowFilter = ""
        Me.TxtAttestedbyStaff.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAttestedbyStaff.AgSelectedValue = Nothing
        Me.TxtAttestedbyStaff.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAttestedbyStaff.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtAttestedbyStaff.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAttestedbyStaff.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAttestedbyStaff.Location = New System.Drawing.Point(317, 109)
        Me.TxtAttestedbyStaff.MaxLength = 100
        Me.TxtAttestedbyStaff.Name = "TxtAttestedbyStaff"
        Me.TxtAttestedbyStaff.Size = New System.Drawing.Size(410, 18)
        Me.TxtAttestedbyStaff.TabIndex = 9
        '
        'LblAttestedbyStaff
        '
        Me.LblAttestedbyStaff.AutoSize = True
        Me.LblAttestedbyStaff.BackColor = System.Drawing.Color.Transparent
        Me.LblAttestedbyStaff.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAttestedbyStaff.Location = New System.Drawing.Point(163, 111)
        Me.LblAttestedbyStaff.Name = "LblAttestedbyStaff"
        Me.LblAttestedbyStaff.Size = New System.Drawing.Size(105, 16)
        Me.LblAttestedbyStaff.TabIndex = 738
        Me.LblAttestedbyStaff.Text = "Attested by Staff"
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.AgMandatory = False
        Me.TxtReferenceNo.AgMasterHelp = True
        Me.TxtReferenceNo.AgNumberLeftPlaces = 8
        Me.TxtReferenceNo.AgNumberNegetiveAllow = False
        Me.TxtReferenceNo.AgNumberRightPlaces = 2
        Me.TxtReferenceNo.AgPickFromLastValue = False
        Me.TxtReferenceNo.AgRowFilter = ""
        Me.TxtReferenceNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtReferenceNo.AgSelectedValue = Nothing
        Me.TxtReferenceNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtReferenceNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtReferenceNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReferenceNo.Location = New System.Drawing.Point(317, 52)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(410, 18)
        Me.TxtReferenceNo.TabIndex = 4
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(163, 54)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(86, 16)
        Me.LblReferenceNo.TabIndex = 740
        Me.LblReferenceNo.Text = "Reference No"
        '
        'FrmDonatedApplication
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(877, 506)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "FrmDonatedApplication"
        Me.Text = "Template Sale Order"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents TxtMemberName As AgControls.AgTextBox
    Protected WithEvents LblMemberName As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents MemberCardNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtMemberCardNo As AgControls.AgTextBox
    Protected WithEvents LblMemberCardNo As System.Windows.Forms.Label
#End Region

    Private Sub TempRequisition_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Lib_DonationApp"
        LogTableName = "Lib_DonationApp_Log"
        MainLineTableCsv = "Lib_DonationAppDetail"
        LogLineTableCsv = "Lib_DonationAppDetail_Log"
        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmTempRequisition_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
               " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select R.DocID As SearchCode " & _
            " From Lib_DonationApp R " & _
            " Left Join Voucher_Type Vt On R.V_Type = Vt.V_Type  " & _
            " Where IsNull(R.IsDeleted,0) = 0  " & mCondStr & "  Order By R.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmTempRequisition_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = "Select R.UID As SearchCode " & _
               " From Lib_DonationApp_Log R " & _
               " Left Join Voucher_Type Vt On R.V_Type = Vt.V_Type  " & _
               " Where R.EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By R.EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT R.DocID AS SearchCode, Vt.Description AS [Entry Type], R.V_Date AS [Entry Date], " & _
                            " R.V_No AS [Entry No], R.ReferenceNo AS [Reference No], M.MemberCardNo AS [Member Card No],SG.DispName AS [Member Name], " & _
                            " R.Subject, SG1.DispName AS [Attested By Staff], Remarks  " & _
                            " FROM Lib_DonationApp R " & _
                            " LEFT JOIN Voucher_type Vt ON R.V_Type = Vt.V_Type " & _
                            " LEFT JOIN Lib_Member M ON M.SubCode = R.Member " & _
                            " LEFT JOIN SubGroup SG ON SG.SubCode = R.Member " & _
                            " LEFT JOIN SubGroup SG1 ON SG1.SubCode = R.AttestedByStaff " & _
                            " Where 1=1 " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT R.UID AS SearchCode, Vt.Description AS [Entry Type], R.V_Date AS [Entry Date], " & _
                            " R.V_No AS [Entry No], R.ReferenceNo AS [Reference No], M.MemberCardNo AS [Member Card No],SG.DispName AS [Member Name], " & _
                            " R.Subject, SG1.DispName AS [Attested By Staff], Remarks  " & _
                            " FROM Lib_DonationApp_Log R " & _
                            " LEFT JOIN Voucher_type Vt ON R.V_Type = Vt.V_Type " & _
                            " LEFT JOIN Lib_Member M ON M.SubCode = R.Member " & _
                            " LEFT JOIN SubGroup SG ON SG.SubCode = R.Member " & _
                            " LEFT JOIN SubGroup SG1 ON SG1.SubCode = R.AttestedByStaff " & _
                            " Where R.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid

        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 35, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 250, 0, Col1Item, True, False)
            .AddAgTextColumn(Dgl1, Col1Writer, 250, 0, Col1Writer, True, True)
            .AddAgTextColumn(Dgl1, Col1Publisher, 250, 0, Col1Publisher, True, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35
        'Dgl1.Anchor = AnchorStyles.None
        'Panel1.Anchor = Dgl1.Anchor
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer


        mQry = " UPDATE Lib_DonationApp_Log " & _
                " SET Member = " & AgL.Chk_Text(TxtMemberCardNo.AgSelectedValue) & ", " & _
                " MonthlyIncome = " & Val(TxtMonthlyParentsIncome.Text) & ", " & _
                " Subject = " & AgL.Chk_Text(TxtSubjectofStudent.Text) & ", " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " AttestedByStaff = " & AgL.Chk_Text(TxtAttestedbyStaff.AgSelectedValue) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                " Where UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Lib_DonationAppDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mSr += 1
                    mQry = " INSERT INTO Lib_DonationAppDetail_Log	(	DocId,	Sr,	Book,	UID	) " & _
                          " VALUES 	(	" & AgL.Chk_Text(mInternalCode) & "," & mSr & ", " & _
                          "	" & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & " , " & AgL.Chk_Text(mSearchCode) & " ) "

                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select R.* " & _
                " From Lib_DonationApp R " & _
                " Where R.DocID = '" & SearchCode & "'"
        Else
            mQry = "Select R.* " & _
                " From Lib_DonationApp_Log R " & _
                " Where R.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtMemberCardNo.AgSelectedValue = AgL.XNull(.Rows(0)("Member"))
                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                TxtMonthlyParentsIncome.Text = Format(AgL.VNull(.Rows(0)("MonthlyIncome")), "0.00")
                TxtSubjectofStudent.Text = AgL.XNull(.Rows(0)("Subject"))
                TxtAttestedbyStaff.AgSelectedValue = AgL.XNull(.Rows(0)("AttestedByStaff"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                Validating_MemberCard(TxtMemberCardNo.AgSelectedValue)
                '-------------------------------------------------------------
                'Line Records are showing in First Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * Lib_DonationAppDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from Lib_DonationAppDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Book"))
                            Validating_Item(Dgl1.AgSelectedValue(Col1Item, I), I)
                        Next I
                    End If
                End With
                Calculation()
                '-------------------------------------------------------------
            End If
        End With
    End Sub

    Private Sub FrmTempRequisition_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgL.WinSetting(Me, 540, 885)
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = " SELECT M.SubCode AS Code,M.MemberCardNo AS [Member Card No],SG.DispName AS MemberName ,isnull(SG.IsDeleted,0) AS IsDeleted, SG.Div_Code , " & _
                " isnull(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status " & _
                " FROM Lib_Member M " & _
                " LEFT JOIN SubGroup SG ON SG.SubCode=M.SubCode " & _
                " Where " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & " "
        TxtMemberCardNo.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT SG.SubCode AS Code,SG.DispName ,isnull(SG.IsDeleted,0) AS IsDeleted, SG.Div_Code , " & _
               " isnull(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status " & _
               " FROM Pay_Employee E " & _
               " LEFT JOIN SubGroup SG ON SG.SubCode=E.SubCode " & _
               " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
        TxtAttestedbyStaff.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup ,B.Writer,B.Publisher, " & _
                " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, I.Measure, MeasureUnit " & _
                " FROM Item I" & _
                " LEFT JOIN Lib_Book B ON B.Code=I.Code "
        Dgl1.AgHelpDataSet(Col1Item, 10) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT DISTINCT M.Subject AS Code,M.Subject,SG.Div_Code, isnull(SG.IsDeleted,0) AS IsDeleted,  " & _
                " isnull(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status " & _
                " FROM Lib_Member M " & _
                " LEFT JOIN SubGroup SG ON SG.SubCode=M.SubCode " & _
                " WHERE M.Subject IS NOT NULL  " & _
                " and " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & " "
        TxtSubjectofStudent.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                ' Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' "

        End Select
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0 : LblTotalMeasure.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                'Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1ReqQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.00")
                'Footer(Calculation)
                'LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1ReqQty, I).Value)
                'LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
                LblTotalQty.Text = Val(LblTotalQty.Text)
                LblTotalMeasure.Text = Val(LblTotalMeasure.Text)
            End If
        Next
        LblTotalMeasure.Text = Format(Val(LblTotalMeasure.Text), "0.000")
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0

        If AgL.RequiredField(TxtMemberCardNo, LblMemberCardNo.Text) Then passed = False : Exit Sub

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub
        If AgCL.AgIsDuplicate(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub

    End Sub

    Private Sub FrmTempRequisition_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        LblTotalMeasure.Text = 0 : LblTotalQty.Text = 0
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles _
    TxtV_Type.Validating, TxtMemberName.Validating, TxtMemberCardNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtMemberCardNo.Name
                    Validating_MemberCard(TxtMemberCardNo.AgSelectedValue)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_MemberCard(ByVal Code As String)

        Dim DrTemp As DataRow() = Nothing
        If TxtMemberCardNo.Text <> "" Then
            DrTemp = TxtMemberCardNo.AgHelpDataSet.Tables(0).Select(" Code = '" & Code & "' ")
            If DrTemp.Length > 0 Then
                TxtMemberName.Text = AgL.XNull(DrTemp(0)("MemberName"))
            Else
                TxtMemberName.Text = ""
            End If
        End If
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtMemberCardNo.Enter, TxtMemberName.Enter
        Try
            Select Case sender.name

                Case TxtMemberCardNo.Name, TxtAttestedbyStaff.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND " & ClsMain.RetDivFilterStr & ""

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Writer, mRow).Value = ""
                Dgl1.Item(Col1Publisher, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.Item(Col1Writer, mRow).Value = AgL.XNull(DrTemp(0)("Writer"))
                    Dgl1.Item(Col1Publisher, mRow).Value = AgL.XNull(DrTemp(0)("Publisher"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmDonatedApplication_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtMemberName.Enabled = False
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bCondstr As String = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Book Donation Application"
            RepName = "Lib_BookDonationApplication_Print" : RepTitle = "Book Donation Application"
            bCondstr = "WHERE H.DocID='" & mInternalCode & "'"

            strQry = " SELECT  H.DocID,H.V_Type + ' - ' + Convert(NVARCHAR(5),H.V_No) AS VoucherNo, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code,H.Site_Code, H.Member, " & _
                    " H.MonthlyIncome, H.Subject, H.AttestedByStaff, H.Remarks, H.ReferenceNo,SM.Name AS SiteName, " & _
                    " SG.DispName AS AttestByName, L.Book,I.Description AS bookName,B.Writer ,B.Publisher, M.MemberCardNo ,  " & _
                    " SGM.DispName AS MemberName " & _
                    " FROM Lib_DonationApp H " & _
                    " LEFT JOIN Lib_DonationAppDetail L ON L.DocId=H.DocID  " & _
                    " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                    " LEFT JOIN SubGroup SG ON SG.SubCode=H.AttestedByStaff  " & _
                    " LEFT JOIN Item I ON I.Code=L.Book  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=I.Code " & _
                    " LEFT JOIN Lib_Member M ON M.SubCode=H.Member " & _
                    " LEFT JOIN SubGroup SGM ON SGM.SubCode=H.Member  " & _
                    " " & bCondstr & " "

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)
            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            AgPL.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
End Class
