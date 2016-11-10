Public Class TempBookIssue
    Inherits AgTemplate.TempTransaction
    Public mQry$
    Dim mTransFlag As Boolean = False
    Public mMainSr As Integer
    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1AccessionNo As String = "Accession No"
    Protected Const Col1BookId As String = "Book ID"
    Protected Const Col1Book As String = "Book"
    Protected Const Col1Writer As String = "Writer"
    Protected Const Col1Publisher As String = "Publisher"
    Protected Const Col1Edition As String = "Edition"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1ForDays As String = "For Days"
    Protected Const Col1DateToReturn As String = "Date To Return"
    Protected Const Col1TempBookId As String = "Temp Book ID"
    Protected Const Col1TempBook As String = "Temp Book"
    Protected Const Col1ReturnDocId As String = "ReturnDocId"
    Protected Const Col1RequisitionDocId As String = "RequisitionDocId"

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
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
        Me.LblMemberCardNoReq = New System.Windows.Forms.Label
        Me.TxtMemberCardNo = New AgControls.AgTextBox
        Me.LblMemberCardNo = New System.Windows.Forms.Label
        Me.TxtMemberType = New AgControls.AgTextBox
        Me.LblMemberType = New System.Windows.Forms.Label
        Me.TxtApplicationNo = New AgControls.AgTextBox
        Me.LblApplicationNo = New System.Windows.Forms.Label
        Me.TxtTransactionBy = New AgControls.AgTextBox
        Me.LblTransactionBy = New System.Windows.Forms.Label
        Me.TxtMemberRemark = New AgControls.AgTextBox
        Me.LblMemberRemark = New System.Windows.Forms.Label
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
        Me.GroupBox2.Location = New System.Drawing.Point(756, 505)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(596, 505)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(421, 505)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(145, 505)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(11, 505)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 501)
        Me.GroupBox1.Size = New System.Drawing.Size(930, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(287, 505)
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
        Me.LblV_No.Location = New System.Drawing.Point(479, 35)
        Me.LblV_No.Size = New System.Drawing.Size(96, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Application No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(597, 33)
        Me.TxtV_No.Size = New System.Drawing.Size(135, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(306, 40)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(168, 35)
        Me.LblV_Date.Size = New System.Drawing.Size(103, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Application Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(581, 21)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(322, 33)
        Me.TxtV_Date.Size = New System.Drawing.Size(135, 18)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(479, 16)
        Me.LblV_Type.Size = New System.Drawing.Size(104, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Application Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(597, 14)
        Me.TxtV_Type.Size = New System.Drawing.Size(135, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(306, 20)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(168, 16)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(322, 14)
        Me.TxtSite_Code.Size = New System.Drawing.Size(135, 18)
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
        Me.TabControl1.Size = New System.Drawing.Size(908, 186)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtMemberRemark)
        Me.TP1.Controls.Add(Me.LblMemberRemark)
        Me.TP1.Controls.Add(Me.TxtTransactionBy)
        Me.TP1.Controls.Add(Me.LblTransactionBy)
        Me.TP1.Controls.Add(Me.TxtApplicationNo)
        Me.TP1.Controls.Add(Me.LblApplicationNo)
        Me.TP1.Controls.Add(Me.TxtMemberType)
        Me.TP1.Controls.Add(Me.LblMemberType)
        Me.TP1.Controls.Add(Me.LblMemberCardNo)
        Me.TP1.Controls.Add(Me.LblMemberCardNoReq)
        Me.TP1.Controls.Add(Me.TxtMemberCardNo)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.TxtMemberName)
        Me.TP1.Controls.Add(Me.LblMemberName)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(900, 160)
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
        Me.TP1.Controls.SetChildIndex(Me.LblMemberCardNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMemberCardNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMemberType, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMemberType, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblApplicationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtApplicationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTransactionBy, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTransactionBy, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblMemberRemark, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMemberRemark, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(912, 41)
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
        Me.TxtMemberName.Location = New System.Drawing.Point(322, 71)
        Me.TxtMemberName.MaxLength = 50
        Me.TxtMemberName.Name = "TxtMemberName"
        Me.TxtMemberName.Size = New System.Drawing.Size(410, 18)
        Me.TxtMemberName.TabIndex = 5
        '
        'LblMemberName
        '
        Me.LblMemberName.AutoSize = True
        Me.LblMemberName.BackColor = System.Drawing.Color.Transparent
        Me.LblMemberName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberName.Location = New System.Drawing.Point(168, 73)
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
        Me.Panel1.Location = New System.Drawing.Point(8, 476)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(899, 21)
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
        Me.Pnl1.Location = New System.Drawing.Point(14, 228)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(886, 242)
        Me.Pnl1.TabIndex = 1
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(168, 130)
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
        Me.TxtRemarks.Location = New System.Drawing.Point(322, 128)
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
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(12, 206)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(118, 20)
        Me.LinkLabel1.TabIndex = 731
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Book Issue Detail"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblMemberCardNoReq
        '
        Me.LblMemberCardNoReq.AutoSize = True
        Me.LblMemberCardNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblMemberCardNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblMemberCardNoReq.Location = New System.Drawing.Point(306, 59)
        Me.LblMemberCardNoReq.Name = "LblMemberCardNoReq"
        Me.LblMemberCardNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblMemberCardNoReq.TabIndex = 732
        Me.LblMemberCardNoReq.Text = "Ä"
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
        Me.TxtMemberCardNo.Location = New System.Drawing.Point(322, 52)
        Me.TxtMemberCardNo.MaxLength = 20
        Me.TxtMemberCardNo.Name = "TxtMemberCardNo"
        Me.TxtMemberCardNo.Size = New System.Drawing.Size(135, 18)
        Me.TxtMemberCardNo.TabIndex = 4
        '
        'LblMemberCardNo
        '
        Me.LblMemberCardNo.AutoSize = True
        Me.LblMemberCardNo.BackColor = System.Drawing.Color.Transparent
        Me.LblMemberCardNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberCardNo.Location = New System.Drawing.Point(168, 54)
        Me.LblMemberCardNo.Name = "LblMemberCardNo"
        Me.LblMemberCardNo.Size = New System.Drawing.Size(110, 16)
        Me.LblMemberCardNo.TabIndex = 731
        Me.LblMemberCardNo.Text = "Member Card No."
        '
        'TxtMemberType
        '
        Me.TxtMemberType.AgMandatory = False
        Me.TxtMemberType.AgMasterHelp = False
        Me.TxtMemberType.AgNumberLeftPlaces = 8
        Me.TxtMemberType.AgNumberNegetiveAllow = False
        Me.TxtMemberType.AgNumberRightPlaces = 2
        Me.TxtMemberType.AgPickFromLastValue = False
        Me.TxtMemberType.AgRowFilter = ""
        Me.TxtMemberType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberType.AgSelectedValue = Nothing
        Me.TxtMemberType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMemberType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberType.Location = New System.Drawing.Point(597, 52)
        Me.TxtMemberType.MaxLength = 50
        Me.TxtMemberType.Name = "TxtMemberType"
        Me.TxtMemberType.Size = New System.Drawing.Size(135, 18)
        Me.TxtMemberType.TabIndex = 6
        '
        'LblMemberType
        '
        Me.LblMemberType.AutoSize = True
        Me.LblMemberType.BackColor = System.Drawing.Color.Transparent
        Me.LblMemberType.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberType.Location = New System.Drawing.Point(488, 51)
        Me.LblMemberType.Name = "LblMemberType"
        Me.LblMemberType.Size = New System.Drawing.Size(87, 16)
        Me.LblMemberType.TabIndex = 734
        Me.LblMemberType.Text = "Member Type"
        '
        'TxtApplicationNo
        '
        Me.TxtApplicationNo.AgMandatory = False
        Me.TxtApplicationNo.AgMasterHelp = False
        Me.TxtApplicationNo.AgNumberLeftPlaces = 8
        Me.TxtApplicationNo.AgNumberNegetiveAllow = False
        Me.TxtApplicationNo.AgNumberRightPlaces = 2
        Me.TxtApplicationNo.AgPickFromLastValue = False
        Me.TxtApplicationNo.AgRowFilter = ""
        Me.TxtApplicationNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtApplicationNo.AgSelectedValue = Nothing
        Me.TxtApplicationNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtApplicationNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtApplicationNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtApplicationNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtApplicationNo.Location = New System.Drawing.Point(322, 90)
        Me.TxtApplicationNo.MaxLength = 100
        Me.TxtApplicationNo.Name = "TxtApplicationNo"
        Me.TxtApplicationNo.Size = New System.Drawing.Size(135, 18)
        Me.TxtApplicationNo.TabIndex = 7
        '
        'LblApplicationNo
        '
        Me.LblApplicationNo.AutoSize = True
        Me.LblApplicationNo.BackColor = System.Drawing.Color.Transparent
        Me.LblApplicationNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblApplicationNo.Location = New System.Drawing.Point(168, 92)
        Me.LblApplicationNo.Name = "LblApplicationNo"
        Me.LblApplicationNo.Size = New System.Drawing.Size(96, 16)
        Me.LblApplicationNo.TabIndex = 736
        Me.LblApplicationNo.Text = "Application No."
        '
        'TxtTransactionBy
        '
        Me.TxtTransactionBy.AgMandatory = False
        Me.TxtTransactionBy.AgMasterHelp = False
        Me.TxtTransactionBy.AgNumberLeftPlaces = 8
        Me.TxtTransactionBy.AgNumberNegetiveAllow = False
        Me.TxtTransactionBy.AgNumberRightPlaces = 2
        Me.TxtTransactionBy.AgPickFromLastValue = False
        Me.TxtTransactionBy.AgRowFilter = ""
        Me.TxtTransactionBy.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTransactionBy.AgSelectedValue = Nothing
        Me.TxtTransactionBy.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTransactionBy.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTransactionBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTransactionBy.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransactionBy.Location = New System.Drawing.Point(556, 90)
        Me.TxtTransactionBy.MaxLength = 100
        Me.TxtTransactionBy.Name = "TxtTransactionBy"
        Me.TxtTransactionBy.Size = New System.Drawing.Size(176, 18)
        Me.TxtTransactionBy.TabIndex = 8
        '
        'LblTransactionBy
        '
        Me.LblTransactionBy.AutoSize = True
        Me.LblTransactionBy.BackColor = System.Drawing.Color.Transparent
        Me.LblTransactionBy.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTransactionBy.Location = New System.Drawing.Point(463, 92)
        Me.LblTransactionBy.Name = "LblTransactionBy"
        Me.LblTransactionBy.Size = New System.Drawing.Size(95, 16)
        Me.LblTransactionBy.TabIndex = 738
        Me.LblTransactionBy.Text = "Transaction By"
        '
        'TxtMemberRemark
        '
        Me.TxtMemberRemark.AgMandatory = False
        Me.TxtMemberRemark.AgMasterHelp = False
        Me.TxtMemberRemark.AgNumberLeftPlaces = 0
        Me.TxtMemberRemark.AgNumberNegetiveAllow = False
        Me.TxtMemberRemark.AgNumberRightPlaces = 0
        Me.TxtMemberRemark.AgPickFromLastValue = False
        Me.TxtMemberRemark.AgRowFilter = ""
        Me.TxtMemberRemark.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMemberRemark.AgSelectedValue = Nothing
        Me.TxtMemberRemark.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMemberRemark.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtMemberRemark.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMemberRemark.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMemberRemark.Location = New System.Drawing.Point(322, 109)
        Me.TxtMemberRemark.MaxLength = 255
        Me.TxtMemberRemark.Name = "TxtMemberRemark"
        Me.TxtMemberRemark.Size = New System.Drawing.Size(410, 18)
        Me.TxtMemberRemark.TabIndex = 9
        '
        'LblMemberRemark
        '
        Me.LblMemberRemark.AutoSize = True
        Me.LblMemberRemark.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblMemberRemark.Location = New System.Drawing.Point(168, 111)
        Me.LblMemberRemark.Name = "LblMemberRemark"
        Me.LblMemberRemark.Size = New System.Drawing.Size(104, 16)
        Me.LblMemberRemark.TabIndex = 742
        Me.LblMemberRemark.Text = "Member Remark"
        '
        'TempBookIssue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(912, 546)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "TempBookIssue"
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
    Protected WithEvents LblMemberCardNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtMemberCardNo As AgControls.AgTextBox
    Protected WithEvents LblMemberCardNo As System.Windows.Forms.Label
    Protected WithEvents TxtMemberType As AgControls.AgTextBox
    Protected WithEvents LblMemberType As System.Windows.Forms.Label
    Protected WithEvents TxtApplicationNo As AgControls.AgTextBox
    Protected WithEvents LblApplicationNo As System.Windows.Forms.Label
    Protected WithEvents TxtTransactionBy As AgControls.AgTextBox
    Protected WithEvents LblTransactionBy As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasureTextReq As System.Windows.Forms.Label
    Protected WithEvents TxtMemberRemark As AgControls.AgTextBox
    Protected WithEvents LblMemberRemark As System.Windows.Forms.Label
#End Region

    Private Sub TempBookIssue_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer, mSr As Integer
        Dim mRequisitionDocId As String
        If 1 = 2 Then

        Else

            mQry = " UPDATE Lib_Member SET ReminderRemark = NULL " & _
                    " WHERE SubCode =" & AgL.Chk_Text(LblMemberCardNoReq.Tag) & "  "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

            mQry = " UPDATE Lib_Member SET ReminderRemark = " & AgL.Chk_Text(TxtMemberRemark.Text) & " " & _
                    " WHERE SubCode =" & AgL.Chk_Text(TxtMemberCardNo.AgSelectedValue) & "  "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

            With Dgl1
                For I = 0 To .RowCount - 1
                    If .Item(Col1BookId, I).Value <> "" Or .Item(Col1TempBookId, I).Value <> "" Then
                        mSr += 1
                        If .AgSelectedValue(Col1TempBookId, I) <> "" Then
                            mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 1 " & _
                                    " WHERE Book_UID = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1TempBookId, I)) & " "
                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                            mQry = " UPDATE Lib_DonationAppDetail SET BookIssueDocId = NULL " & _
                                    " WHERE DocId= " & AgL.Chk_Text(TxtApplicationNo.AgSelectedValue) & " " & _
                                    " AND Book = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1TempBook, I)) & " "
                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                        End If

                        If .AgSelectedValue(Col1BookId, I) <> "" Then
                            mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 0 " & _
                                    " WHERE Book_UID = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1BookId, I)) & " "
                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                            mQry = " UPDATE Lib_DonationAppDetail SET BookIssueDocId = " & AgL.Chk_Text(mInternalCode) & " " & _
                                    " WHERE DocId= " & AgL.Chk_Text(TxtApplicationNo.AgSelectedValue) & " " & _
                                    " AND Book = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1TempBook, I)) & " "
                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                        End If

                        If .AgSelectedValue(Col1TempBook, I) <> "" Then
                            mQry = " SELECT RD.DocId AS RequisitionDocId " & _
                                   " FROM RequisitionDetail RD With (NoLock) " & _
                                   " LEFT JOIN Requisition R With (NoLock) ON R.DocID=RD.DocId  " & _
                                   " WHERE R.RequisitionBy = '" & TxtMemberName.Text & "' AND RD.IssueDocId = '" & mInternalCode & "' " & _
                                   " And RD.Item =" & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1TempBook, I)) & " " & _
                                   " AND ISNULL(R.IsDeleted,0) =0 AND ISNULL(R.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "')='" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                            AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GcnRead)
                            mRequisitionDocId = AgL.ECmd.ExecuteScalar()
                            If mRequisitionDocId <> "" Then
                                mQry = " UPDATE RequisitionDetail SET IssueDocId = NUll " & _
                                        " WHERE DocId =" & AgL.Chk_Text(mRequisitionDocId) & " AND Item = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1TempBook, I)) & " "
                                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                            End If
                        End If

                        If .AgSelectedValue(Col1Book, I) <> "" Then
                            mQry = " SELECT RD.DocId AS RequisitionDocId " & _
                                   " FROM RequisitionDetail RD With (NoLock) " & _
                                   " LEFT JOIN Requisition R With (NoLock) ON R.DocID=RD.DocId  " & _
                                   " WHERE R.RequisitionBy = '" & TxtMemberName.Text & "' " & _
                                   " And RD.Item =" & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Book, I)) & " " & _
                                   " AND ISNULL(R.IsDeleted,0) =0 AND ISNULL(R.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "')='" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                            AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GcnRead)
                            mRequisitionDocId = AgL.ECmd.ExecuteScalar()
                            If mRequisitionDocId <> "" Then
                                mQry = " UPDATE RequisitionDetail SET IssueDocId = " & AgL.Chk_Text(mInternalCode) & " " & _
                                        " WHERE DocId =" & AgL.Chk_Text(mRequisitionDocId) & " AND Item = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Book, I)) & " "
                                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                            End If
                        End If
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub TempRequisition_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Lib_BookIssue"
        LogTableName = "Lib_BookIssue_Log"
        MainLineTableCsv = "Lib_BookIssueDetail,Stock"
        LogLineTableCsv = "Lib_BookIssueDetail_Log,Stock_Log"
        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmTempRequisition_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
               " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select R.DocID As SearchCode " & _
            " From Lib_BookIssue R " & _
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
               " From Lib_BookIssue_Log R " & _
               " Left Join Voucher_Type Vt On R.V_Type = Vt.V_Type  " & _
               " Where R.EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By R.EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT R.DocID AS SearchCode, Vt.Description AS [Issue Type], R.V_Date AS [Issue Date], " & _
                            " R.V_No AS [Issue No], M.MemberCardNo AS [Member Card No],SG.DispName AS [Member Name], " & _
                            " D.V_Type + ' - '+convert(NVARCHAR(5),D.V_No) AS [Application No],SG1.Name AS [Transaction By ], R.Remarks  " & _
                            " FROM Lib_BookIssue R " & _
                            " LEFT JOIN Voucher_type Vt ON R.V_Type = Vt.V_Type " & _
                            " LEFT JOIN Lib_Member M ON M.SubCode = R.Member " & _
                            " LEFT JOIN SubGroup SG ON SG.SubCode = R.Member " & _
                            " LEFT JOIN SubGroup SG1 ON SG1.SubCode = R.TransactionBy " & _
                            " LEFT JOIN Lib_DonationApp D ON D.DocID=R.DonationApp " & _
                            " Where 1=1 " & mCondStr

        AgL.PubFindQryOrdBy = "[Issue Date]"
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("R.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("R.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "R.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT R.UID AS SearchCode, Vt.Description AS [Issue Type], R.V_Date AS [Issue Date], " & _
                            " R.V_No AS [Issue No], M.MemberCardNo AS [Member Card No],SG.DispName AS [Member Name], " & _
                            " D.V_Type + ' - '+convert(NVARCHAR(5),D.V_No) AS [Application No],SG1.Name AS [Transaction By ], R.Remarks  " & _
                            " FROM Lib_BookIssue_Log R " & _
                            " LEFT JOIN Voucher_type Vt ON R.V_Type = Vt.V_Type " & _
                            " LEFT JOIN Lib_Member M ON M.SubCode = R.Member " & _
                            " LEFT JOIN SubGroup SG ON SG.SubCode = R.Member " & _
                            " LEFT JOIN SubGroup SG1 ON SG1.SubCode = R.TransactionBy " & _
                            " LEFT JOIN Lib_DonationApp D ON D.DocID=R.DonationApp " & _
                            " Where R.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Issue Date]"
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid

        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 35, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1AccessionNo, 100, 20, Col1AccessionNo, True, False)
            .AddAgTextColumn(Dgl1, Col1BookId, 100, 20, Col1BookId, True, False)
            .AddAgTextColumn(Dgl1, Col1Book, 170, 0, Col1Book, True, False)
            .AddAgTextColumn(Dgl1, Col1Edition, 80, 20, Col1Edition, True, False)
            .AddAgTextColumn(Dgl1, Col1Writer, 170, 0, Col1Writer, True, True)
            .AddAgTextColumn(Dgl1, Col1Publisher, 170, 0, Col1Publisher, True, True)
            .AddAgNumberColumn(Dgl1, Col1Qty, 50, 5, 0, False, Col1Qty, False, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 80, 20, Col1Unit, False, False)
            .AddAgNumberColumn(Dgl1, Col1ForDays, 50, 5, 0, False, Col1ForDays, True, False, True)
            .AddAgDateColumn(Dgl1, Col1DateToReturn, 80, Col1DateToReturn, True, True)
            .AddAgTextColumn(Dgl1, Col1TempBookId, 100, 20, Col1TempBookId, False, False)
            .AddAgTextColumn(Dgl1, Col1TempBook, 100, 20, Col1TempBook, False, False)
            .AddAgTextColumn(Dgl1, Col1ReturnDocId, 100, 21, Col1ReturnDocId, False, False)
            .AddAgTextColumn(Dgl1, Col1RequisitionDocId, 100, 21, Col1RequisitionDocId, False, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35
        'Dgl1.Anchor = AnchorStyles.None
        'Panel1.Anchor = Dgl1.Anchor
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = " UPDATE Lib_BookIssue_Log " & _
                " SET Member =" & AgL.Chk_Text(TxtMemberCardNo.AgSelectedValue) & " , " & _
                " DonationApp =" & AgL.Chk_Text(TxtApplicationNo.AgSelectedValue) & ", " & _
                " TransactionBy = " & AgL.Chk_Text(TxtTransactionBy.AgSelectedValue) & ", " & _
                " MemberRemarks = " & AgL.Chk_Text(TxtMemberRemark.Text) & " , " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & "  " & _
                " WHERE UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Lib_BookIssueDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Stock_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1BookId, I).Value <> "" Then
                    mSr += 1
                    mMainSr += 1
                    mQry = " INSERT INTO Lib_BookIssueDetail_Log ( DocId,Sr,Book_UID,Book, " & _
                            " Edition,ForDays,ToReturnDate,UID, AccessionNo	) " & _
                            " VALUES 	(" & AgL.Chk_Text(mInternalCode) & "," & mSr & ", " & _
                            " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1BookId, I)) & ", " & _
                            " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Book, I)) & ",  " & _
                            " " & AgL.Chk_Text(Dgl1.Item(Col1Edition, I).Value) & ",	" & _
                            " " & Val(Dgl1.Item(Col1ForDays, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(Dgl1.Item(Col1DateToReturn, I).Value) & ",	" & _
                            " " & AgL.Chk_Text(mSearchCode) & ", " & _
                            " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1AccessionNo, I)) & ") "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                    mQry = " INSERT INTO Stock_Log (DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, " & _
                            " Site_Code, SubCode, Item, Qty_Iss, Unit, Remarks, Edition,UID ) " & _
                            " VALUES (" & AgL.Chk_Text(mInternalCode) & ", " & mMainSr & ", " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                            " " & AgL.Chk_Text(LblPrefix.Text) & ", " & AgL.ConvertDate(TxtV_Date.Text) & ",  " & _
                            " " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(AgL.PubDivCode) & ", " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                            " " & AgL.Chk_Text(TxtTransactionBy.AgSelectedValue) & ", " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Book, I)) & ", " & Val(Dgl1.Item(Col1Qty, I).Value) & ",  " & _
                            " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & AgL.Chk_Text(TxtRemarks.Text) & ", " & AgL.Chk_Text(Dgl1.Item(Col1Edition, I).Value) & "," & AgL.Chk_Text(mSearchCode) & "  ) "
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
                " From Lib_BookIssue R " & _
                " Where R.DocID = '" & SearchCode & "'"
        Else
            mQry = "Select R.* " & _
                " From Lib_BookIssue_Log R " & _
                " Where R.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtMemberCardNo.AgSelectedValue = AgL.XNull(.Rows(0)("Member"))
                LblMemberCardNoReq.Tag = AgL.XNull(.Rows(0)("Member"))
                TxtApplicationNo.AgSelectedValue = AgL.XNull(.Rows(0)("DonationApp"))
                TxtTransactionBy.AgSelectedValue = AgL.XNull(.Rows(0)("TransactionBy"))
                TxtMemberRemark.Text = AgL.XNull(.Rows(0)("MemberRemarks"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                Validating_MemberCard(TxtMemberCardNo.AgSelectedValue)

                If TxtMemberType.AgSelectedValue.ToString.Trim = "" Or TxtMemberType.Text.ToString.Trim = "" Then
                    LblMemberType.Tag = ""
                Else
                    If TxtMemberType.AgHelpDataSet IsNot Nothing Then
                        DrTemp = TxtMemberType.AgHelpDataSet.Tables(0).Select(" Code = '" & TxtMemberType.AgSelectedValue & "' ")
                        LblMemberType.Tag = AgL.XNull(DrTemp(0)("BooksAllowed"))
                    End If
                End If

                '-------------------------------------------------------------
                'Line Records are showing in First Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * Lib_BookIssueDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from Lib_BookIssueDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If

                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1BookId, I) = AgL.XNull(.Rows(I)("Book_UID"))
                            Dgl1.AgSelectedValue(Col1AccessionNo, I) = AgL.XNull(.Rows(I)("AccessionNo"))
                            Dgl1.AgSelectedValue(Col1Book, I) = AgL.XNull(.Rows(I)("Book"))
                            Dgl1.Item(Col1Edition, I).Value = AgL.XNull(.Rows(I)("Edition"))
                            Dgl1.Item(Col1DateToReturn, I).Value = AgL.XNull(.Rows(I)("ToReturnDate"))
                            Dgl1.AgSelectedValue(Col1TempBookId, I) = AgL.XNull(.Rows(I)("Book_UID"))
                            Dgl1.AgSelectedValue(Col1TempBook, I) = AgL.XNull(.Rows(I)("Book"))
                            Validating_AccessionNo(Dgl1.AgSelectedValue(Col1AccessionNo, I), I)
                            Validating_BookId(Dgl1.AgSelectedValue(Col1BookId, I), I)
                            Dgl1.Item(Col1ForDays, I).Value = AgL.VNull(.Rows(I)("ForDays"))
                            Dgl1.Item(Col1ReturnDocId, I).Value = AgL.XNull(.Rows(I)("ReturnDocId"))
                            If Dgl1.Item(Col1ReturnDocId, I).Value <> "" Then
                                Dgl1.CurrentRow.ReadOnly = True
                            End If
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
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = " SELECT M.SubCode AS Code,M.MemberCardNo AS [Member Card No],SG.DispName AS MemberName ,isnull(SG.IsDeleted,0) AS IsDeleted, SG.Div_Code , " & _
                " isnull(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status ,M.MemberType,M.ReminderRemark " & _
                " FROM Lib_Member M " & _
                " LEFT JOIN SubGroup SG ON SG.SubCode=M.SubCode " & _
                " Where " & AgL.PubSiteCondition("M.Site_Code", AgL.PubSiteCode) & " "
        TxtMemberCardNo.AgHelpDataSet(5, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT MT.Code, MT.Description AS MemberType, Mt.BooksAllowed FROM Lib_MemberType MT   Where " & AgL.PubSiteCondition("MT.Site_Code", AgL.PubSiteCode) & " "
        TxtMemberType.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT SG.SubCode AS Code,SG.DispName ,isnull(SG.IsDeleted,0) AS IsDeleted, SG.Div_Code , " & _
               " isnull(SG.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status " & _
               " FROM Pay_Employee E " & _
               " LEFT JOIN SubGroup SG ON SG.SubCode=E.SubCode " & _
               " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
        TxtTransactionBy.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT P.DocID AS Code,P.V_Type + '-' +convert(NVARCHAR(5),P.V_No) AS ApplicationNo , " & _
                        " P.Member, " & _
                        " isnull(P.IsDeleted,0) AS IsDeleted, P.Div_Code , " & _
                        " isnull(P.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status " & _
                        " FROM Lib_DonationApp  P "
        TxtApplicationNo.AgHelpDataSet(4, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        IniBookIDHelp(True)

        mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup ,B.Writer,B.Publisher,B.BookType, " & _
            " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, I.Measure, MeasureUnit " & _
            " FROM Item I" & _
            " LEFT JOIN Lib_Book B ON B.Code=I.Code "
        Dgl1.AgHelpDataSet(Col1Book, 11) = AgL.FillData(mQry, AgL.GCn)
        Dgl1.AgHelpDataSet(Col1TempBook, 11) = Dgl1.AgHelpDataSet(Col1Book).Copy

        IniAccessionNoHelp(True)
    End Sub

    Public Sub IniAccessionNoHelp(Optional ByVal All_Records As Boolean = True, Optional ByVal bMemberTypeCode As String = "")
        If All_Records = True Then
            mQry = " SELECT A.AccessionNo AS Code,A.AccessionNo AS [Accession No],I.Description AS [Book Name]," & _
                    " A.Book, A.Book_UID,A.Edition,A.Writer,A.Publisher,A.IsInStock , I.Unit ,B.BookType," & _
                    " IsNull(AH.IsDeleted ,0) AS IsDeleted, AH.Div_Code, ISNULL(AH.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status,0 AS Days, I.ItemType " & _
                    " FROM Lib_AccessionDetail A " & _
                    " LEFT JOIN Lib_Accession Ad ON Ad.DocID = A.DocID " & _
                    " LEFT JOIN Item I ON I.Code=A.Book  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=I.Code  " & _
                    " LEFT JOIN Lib_Accession AH ON AH.DocID=A.DocId " & _
                    " Where " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & " "
            Dgl1.AgHelpDataSet(Col1AccessionNo, 13) = AgL.FillData(mQry, AgL.GCn)
        Else
            If bMemberTypeCode <> "" Then
                mQry = " SELECT A.AccessionNo AS Code,A.AccessionNo AS [Accession No],I.Description AS [Book Name], " & _
                        " A.Book,A.Book_UID,A.Edition,A.Writer,A.Publisher, IsNull(A.IsInStock,0) As IsInStock , I.Unit ,B.BookType," & _
                        " IsNull(AH.IsDeleted ,0) AS IsDeleted, AH.Div_Code, ISNULL(AH.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status,BT.Days, I.ItemType  " & _
                        " FROM Lib_AccessionDetail A " & _
                        " LEFT JOIN Lib_Accession Ad ON Ad.DocID = A.DocID " & _
                        " LEFT JOIN Item I ON I.Code=A.Book  " & _
                        " LEFT JOIN Lib_Book B ON B.Code=I.Code  " & _
                        " LEFT JOIN Lib_Accession AH ON AH.DocID=A.DocId " & _
                        " LEFT JOIN (SELECT T.* FROM Lib_BookTypeDetail T WHERE T.MemberType = '" & bMemberTypeCode & "') BT ON BT.Code=B.BookType " & _
                        " WHERE 1=1 and " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & " "
                Dgl1.AgHelpDataSet(Col1AccessionNo, 13) = AgL.FillData(mQry, AgL.GCn)
            End If
        End If
    End Sub

    Public Sub IniBookIDHelp(Optional ByVal All_Records As Boolean = True, Optional ByVal bMemberTypeCode As String = "")
        If All_Records = True Then
            mQry = " SELECT A.Book_UID AS Code,A.Book_UID AS [Book ID],I.Description AS [Book Name],A.Book,A.AccessionNo,A.Edition,A.Writer,A.Publisher,A.IsInStock , I.Unit ,B.BookType," & _
                    " IsNull(AH.IsDeleted ,0) AS IsDeleted, AH.Div_Code, ISNULL(AH.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status,0 AS Days, I.ItemType " & _
                    " FROM Lib_AccessionDetail A " & _
                    " LEFT JOIN Lib_Accession Ad ON Ad.DocID = A.DocID " & _
                    " LEFT JOIN Item I ON I.Code=A.Book  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=I.Code  " & _
                    " LEFT JOIN Lib_Accession AH ON AH.DocID=A.DocId " & _
                    " Where " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & " "
            Dgl1.AgHelpDataSet(Col1BookId, 13) = AgL.FillData(mQry, AgL.GCn)
            Dgl1.AgHelpDataSet(Col1TempBookId, 13) = AgL.FillData(mQry, AgL.GCn)
        Else
            If bMemberTypeCode <> "" Then
                mQry = " SELECT A.Book_UID AS Code,A.Book_UID AS [Book ID],I.Description AS [Book Name],A.Book,A.AccessionNo,A.Edition,A.Writer,A.Publisher,A.IsInStock , I.Unit ,B.BookType," & _
                        " IsNull(AH.IsDeleted ,0) AS IsDeleted, AH.Div_Code, ISNULL(AH.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status,BT.Days, I.ItemType  " & _
                        " FROM Lib_AccessionDetail A " & _
                        " LEFT JOIN Lib_Accession Ad ON Ad.DocID = A.DocID " & _
                        " LEFT JOIN Item I ON I.Code=A.Book  " & _
                        " LEFT JOIN Lib_Book B ON B.Code=I.Code  " & _
                        " LEFT JOIN Lib_Accession AH ON AH.DocID=A.DocId " & _
                        " LEFT JOIN (SELECT T.* FROM Lib_BookTypeDetail T WHERE T.MemberType = '" & bMemberTypeCode & "') BT ON BT.Code=B.BookType " & _
                        " WHERE 1=1 and " & AgL.PubSiteCondition("Ad.Site_Code", AgL.PubSiteCode) & " "
                Dgl1.AgHelpDataSet(Col1BookId, 13) = AgL.FillData(mQry, AgL.GCn)
            End If
        End If
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Dim bStrFilter$ = ""

        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1BookId
                If TxtMemberType.AgSelectedValue <> "" Then
                    IniBookIDHelp(False, TxtMemberType.AgSelectedValue)
                End If

                If AgL.XNull(Dgl1.AgSelectedValue(Col1BookId, Dgl1.CurrentCell.RowIndex)).ToString.Trim <> "" Then
                    bStrFilter = " AND (IsInStock = 1 OR Code=" & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1BookId, Dgl1.CurrentCell.RowIndex)) & ")"
                Else
                    bStrFilter = " And IsInStock = 1 "
                End If

                If Dgl1.AgSelectedValue(Col1Book, Dgl1.CurrentCell.RowIndex) <> "" And Dgl1.AgSelectedValue(Col1BookId, Dgl1.CurrentCell.RowIndex) = "" Then
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1BookId).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' " & _
                        " And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "'  " & _
                        " AND Book =" & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Book, Dgl1.CurrentCell.RowIndex)) & " " & bStrFilter
                Else
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1BookId).Index) = " IsDeleted = 0 " & _
                        " And Div_Code = '" & TxtDivision.AgSelectedValue & "' " & _
                        " And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "'  " & bStrFilter
                End If

            Case Col1AccessionNo
                If TxtMemberType.AgSelectedValue <> "" Then
                    IniAccessionNoHelp(False, TxtMemberType.AgSelectedValue)
                    IniBookIDHelp(False, TxtMemberType.AgSelectedValue)
                End If

                If AgL.XNull(Dgl1.AgSelectedValue(Col1AccessionNo, Dgl1.CurrentCell.RowIndex)).ToString.Trim <> "" Then
                    bStrFilter = " AND (IsInStock = 1 OR Code=" & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1AccessionNo, Dgl1.CurrentCell.RowIndex)) & ")"
                Else
                    bStrFilter = " And IsInStock = 1 "
                End If


                If Dgl1.AgSelectedValue(Col1Book, Dgl1.CurrentCell.RowIndex) <> "" And Dgl1.AgSelectedValue(Col1AccessionNo, Dgl1.CurrentCell.RowIndex) = "" Then
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1AccessionNo).Index) = " IsDeleted = 0 And Div_Code = '" & TxtDivision.AgSelectedValue & "' " & _
                        " And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "'  " & _
                        " AND Book = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Book, Dgl1.CurrentCell.RowIndex)) & " " & bStrFilter
                Else
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1AccessionNo).Index) = " IsDeleted = 0 " & _
                        " And Div_Code = '" & TxtDivision.AgSelectedValue & "' " & _
                        " And Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "'  " & bStrFilter
                End If

            Case Col1Book
                Dgl1.AgRowFilter(Dgl1.Columns(Col1Book).Index) = " IsDeleted = 0 " & _
                        " And Div_Code = '" & TxtDivision.AgSelectedValue & "' " & _
                        " And Status='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                        " AND ItemType IN( " & AgL.Chk_Text(ClsMain.ItemType.Book) & " ," & AgL.Chk_Text(ClsMain.ItemType.Generals) & " ) "

        End Select
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer
        LblTotalQty.Text = 0 : LblTotalMeasure.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1BookId, I).Value <> "" Then
                If Val(Dgl1.Item(Col1ForDays, I).Value) <> 0 Then
                    Dgl1.Item(Col1DateToReturn, I).Value = Format(CDate(TxtV_Date.Text).AddDays(Val(Dgl1.Item(Col1ForDays, I).Value)), AgLibrary.ClsConstant.DateFormat_ShortDate)
                End If
                LblTotalQty.Text = Val(LblTotalQty.Text)
                LblTotalMeasure.Text = Val(LblTotalMeasure.Text)
            End If
        Next
        LblTotalMeasure.Text = Format(Val(LblTotalMeasure.Text), "0.000")
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0

        If AgCL.AgIsDuplicate(Dgl1, Dgl1.Columns(Col1BookId).Index) Then passed = False : Exit Sub
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        LblTotalMeasure.Text = 0 : LblTotalQty.Text = 0
        LblMemberCardNoReq.Tag = ""
        LblMemberType.Tag = ""
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtMemberName.Validating, TxtMemberCardNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtMemberCardNo.Name
                    Validating_MemberCard(TxtMemberCardNo.AgSelectedValue)

                    If TxtMemberType.AgSelectedValue.ToString.Trim = "" Or TxtMemberType.Text.ToString.Trim = "" Then
                        LblMemberType.Tag = ""
                    Else
                        If TxtMemberType.AgHelpDataSet IsNot Nothing Then
                            DrTemp = TxtMemberType.AgHelpDataSet.Tables(0).Select(" Code = '" & TxtMemberType.AgSelectedValue & "' ")
                            LblMemberType.Tag = AgL.XNull(DrTemp(0)("BooksAllowed"))
                        End If
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_MemberCard(ByVal Code As String)
        Dim mReminderRemark As String
        Dim DrTemp As DataRow() = Nothing
        If TxtMemberCardNo.Text <> "" Then
            DrTemp = TxtMemberCardNo.AgHelpDataSet.Tables(0).Select(" Code = '" & Code & "' ")
            If DrTemp.Length > 0 Then
                TxtMemberName.Text = AgL.XNull(DrTemp(0)("MemberName"))
                TxtMemberType.AgSelectedValue = AgL.XNull(DrTemp(0)("MemberType"))
                mReminderRemark = AgL.XNull(DrTemp(0)("ReminderRemark"))
                If Topctrl1.Mode = "Add" Then
                    If mReminderRemark <> "" Then MsgBox(mReminderRemark)
                    TxtMemberRemark.Text = AgL.XNull(DrTemp(0)("ReminderRemark"))
                    Call TxtApplicationValue(Code)
                    Dgl1.Focus()
                End If
            Else
                TxtMemberName.Text = ""
                TxtMemberType.Text = ""
            End If
        End If
    End Sub

    Private Sub TxtApplicationValue(ByVal bMemberCode As String)
        Dim dsTemp As DataSet
        mQry = " SELECT L.DocId " & _
                " FROM Lib_DonationApp L " & _
                " LEFT JOIN Lib_DonationAppDetail D ON D.DocId =L.DocID  " & _
                " WHERE L.Member =" & AgL.Chk_Text(bMemberCode) & " AND D.BookIssueDocId  IS NULL "
        dsTemp = AgL.FillData(mQry, AgL.GCn)
        If dsTemp.Tables(0).Rows.Count > 0 Then
            TxtApplicationNo.AgSelectedValue = AgL.XNull(dsTemp.Tables(0).Rows(0)("DocId"))
        End If

    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles _
    TxtMemberCardNo.Enter, TxtMemberName.Enter, TxtTransactionBy.Enter, TxtApplicationNo.Enter
        Try
            Select Case sender.name
                Case TxtMemberCardNo.Name, TxtTransactionBy.Name, TxtApplicationNo.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND " & ClsMain.RetDivFilterStr & ""

                Case TxtApplicationNo.Name
                    sender.AgRowFilter = "  IsDeleted = 0 And  Status ='" & AgTemplate.ClsMain.EntryStatus.Active & "' AND " & ClsMain.RetDivFilterStr & " AND Member=" & AgL.Chk_Text(TxtMemberCardNo.AgSelectedValue) & ""

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Validating_BookId(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1BookId, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1BookId, mRow).ToString.Trim = "" Then
                Dgl1.AgSelectedValue(Col1Book, mRow) = ""
                Dgl1.AgSelectedValue(Col1AccessionNo, mRow) = ""
                Dgl1.Item(Col1Writer, mRow).Value = ""
                Dgl1.Item(Col1Publisher, mRow).Value = ""
                Dgl1.Item(Col1Unit, mRow).Value = ""
                Dgl1.Item(Col1Edition, mRow).Value = ""
                Dgl1.Item(Col1ForDays, mRow).Value = 0
                Dgl1.Item(Col1Qty, mRow).Value = 0
            Else
                If Dgl1.AgHelpDataSet(Col1BookId) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1BookId).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.AgSelectedValue(Col1Book, mRow) = AgL.XNull(DrTemp(0)("Book"))
                    Dgl1.AgSelectedValue(Col1AccessionNo, mRow) = AgL.XNull(DrTemp(0)("AccessionNo"))
                    Dgl1.Item(Col1Writer, mRow).Value = AgL.XNull(DrTemp(0)("Writer"))
                    Dgl1.Item(Col1Publisher, mRow).Value = AgL.XNull(DrTemp(0)("Publisher"))
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
                    Dgl1.Item(Col1Edition, mRow).Value = AgL.XNull(DrTemp(0)("Edition"))
                    Dgl1.Item(Col1ForDays, mRow).Value = AgL.VNull(DrTemp(0)("Days"))
                    Dgl1.Item(Col1Qty, mRow).Value = 1
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub Validating_AccessionNo(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1AccessionNo, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1AccessionNo, mRow).ToString.Trim = "" Then
                Dgl1.AgSelectedValue(Col1BookId, mRow) = ""
            Else
                If Dgl1.AgHelpDataSet(Col1AccessionNo) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1AccessionNo).Tables(0).Select("Code = '" & Code & "'")
                    Dgl1.AgSelectedValue(Col1BookId, mRow) = AgL.XNull(DrTemp(0)("Book_UID"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_AccessionNo Function ")
        End Try
    End Sub

    Private Sub Validating_Book(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Book, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Book, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Writer, mRow).Value = ""
                Dgl1.Item(Col1Publisher, mRow).Value = ""
            Else
                If Dgl1.AgHelpDataSet(Col1Book) IsNot Nothing Then
                    DrTemp = Dgl1.AgHelpDataSet(Col1Book).Tables(0).Select("Code = '" & Code & "'")
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
                Case Col1BookId
                    Validating_BookId(Dgl1.AgSelectedValue(Col1BookId, mRowIndex), mRowIndex)

                Case Col1Book
                    Validating_Book(Dgl1.AgSelectedValue(Col1Book, mRowIndex), mRowIndex)

                Case Col1AccessionNo
                    Validating_AccessionNo(Dgl1.AgSelectedValue(Col1AccessionNo, mRowIndex), mRowIndex)
                    Validating_BookId(Dgl1.AgSelectedValue(Col1BookId, mRowIndex), mRowIndex)

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmIssueDonatedBook_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtMemberName.Enabled = False
        TxtMemberType.Enabled = False
    End Sub

    Private Sub TempBookIssue_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        mQry = " SELECT TOP 1 B.TransactionBy FROM Lib_BookIssue B " & _
                " WHERE isnull(B.IsDeleted,0)=0 " & _
                " ORDER BY B.V_No DESC ,B.V_Date DESC "
        TxtTransactionBy.AgSelectedValue = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar())
        TxtMemberCardNo.Focus()
    End Sub

    Private Sub TempBookIssue_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        Dim I As Integer, mSr As Integer
        Dim mRequisitionDocId As String

        mQry = " UPDATE Lib_Member SET ReminderRemark = NULL " & _
                " WHERE SubCode =" & AgL.Chk_Text(LblMemberCardNoReq.Tag) & "  "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1BookId, I).Value <> "" Then
                    mSr += 1
                    If .AgSelectedValue(Col1TempBookId, I) <> "" Then
                        mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 1 " & _
                                " WHERE Book_UID = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1TempBookId, I)) & " "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                        mQry = " UPDATE Lib_DonationAppDetail SET BookIssueDocId = NULL " & _
                                " WHERE DocId= " & AgL.Chk_Text(TxtApplicationNo.AgSelectedValue) & " " & _
                                " AND Book = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1TempBook, I)) & " "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    End If

                    If .AgSelectedValue(Col1TempBook, I) <> "" Then
                        mQry = " SELECT RD.DocId AS RequisitionDocId " & _
                               " FROM RequisitionDetail RD With (NoLock) " & _
                               " LEFT JOIN Requisition R With (NoLock) ON R.DocID=RD.DocId  " & _
                               " WHERE R.RequisitionBy = '" & TxtMemberName.Text & "' AND RD.IssueDocId = '" & mInternalCode & "' " & _
                               " And RD.Item =" & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1TempBook, I)) & " " & _
                               " AND ISNULL(R.IsDeleted,0) =0 AND ISNULL(R.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "')='" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                        AgL.ECmd = AgL.Dman_Execute(mQry, AgL.GcnRead)
                        mRequisitionDocId = AgL.ECmd.ExecuteScalar()
                        If mRequisitionDocId <> "" Then
                            mQry = " UPDATE RequisitionDetail SET IssueDocId = NUll " & _
                                    " WHERE DocId =" & AgL.Chk_Text(mRequisitionDocId) & " AND Item = " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1TempBook, I)) & " "
                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                        End If
                    End If
                End If
            Next
        End With
    End Sub
End Class
