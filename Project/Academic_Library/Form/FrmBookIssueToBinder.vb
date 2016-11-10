Public Class FrmBookIssueToBinder
    Inherits TempBookIssue

    Public WithEvents Dgl2 As New AgControls.AgDataGrid
    Protected Const Col2IssueDocId As String = "IssueDocId"
    Protected Const Col2Received As String = "Received"
    Protected Const Col2Status As String = "Status"
    Protected Const Col2AccessionNo As String = "Accession No"
    Protected Const Col2BookId As String = "Book ID"
    Protected Const Col2TempBookId As String = "Temp Book ID"
    Protected Const Col2Book As String = "Book"
    Protected Const Col2Writer As String = "Writer"
    Protected Const Col2Publisher As String = "Publisher"
    Protected Const Col2Edition As String = "Edition"
    Protected Const Col2Qty As String = "Qty"
    Protected Const Col2Unit As String = "Unit"
    Protected Const Col2DateToReturn As String = "Date To Return"
    Protected Const Col2DateofReturn As String = "Date of Return"
    Protected Const Col2Rate As String = "Rate"
    Protected Const Col2Remark As String = "Remark"

    Protected Const Status_Received As String = "Received"
    Protected Const Status_Lost As String = "Lost"
    Protected Const Status_Replaced As String = "Replaced"

    

    Dim mMemberCardNo$ = ""

    Public Property MemberCardNo() As String
        Get
            MemberCardNo = mMemberCardNo
        End Get
        Set(ByVal value As String)
            mMemberCardNo = value
        End Set
    End Property

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.BookIssueReceiveToBinder
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.TxtToReturnDate = New AgControls.AgTextBox
        Me.LblToReturnDate = New System.Windows.Forms.Label
        Me.TxtVendor = New AgControls.AgTextBox
        Me.LblVendor = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.TxtIssueNo = New AgControls.AgTextBox
        Me.LblIssueNo = New System.Windows.Forms.Label
        Me.TxtRate = New AgControls.AgTextBox
        Me.LblRate = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtMemberName
        '
        Me.TxtMemberName.Location = New System.Drawing.Point(753, 116)
        Me.TxtMemberName.Size = New System.Drawing.Size(52, 18)
        Me.TxtMemberName.TabIndex = 4
        Me.TxtMemberName.Visible = False
        '
        'LblMemberName
        '
        Me.LblMemberName.Location = New System.Drawing.Point(750, 103)
        Me.LblMemberName.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Location = New System.Drawing.Point(8, 548)
        Me.Panel1.Size = New System.Drawing.Size(864, 21)
        Me.Panel1.Visible = True
        Me.Panel1.Controls.SetChildIndex(Me.LblTotalQtyText, 0)
        Me.Panel1.Controls.SetChildIndex(Me.LblTotalAmountText, 0)
        Me.Panel1.Controls.SetChildIndex(Me.LblTotalQty, 0)
        Me.Panel1.Controls.SetChildIndex(Me.LblTotalMeasureTextReq, 0)
        Me.Panel1.Controls.SetChildIndex(Me.LblTotalMeasure, 0)
        Me.Panel1.Controls.SetChildIndex(Me.LblTotalAmount, 0)
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(11, 228)
        Me.Pnl1.Size = New System.Drawing.Size(861, 147)
        '
        'TxtRemarks
        '
        Me.TxtRemarks.Location = New System.Drawing.Point(322, 94)
        Me.TxtRemarks.TabIndex = 8
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(168, 96)
        '
        'LblTotalQty
        '
        Me.LblTotalQty.Visible = False
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.Visible = False
        '
        'LinkLabel1
        '
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.Location = New System.Drawing.Point(9, 208)
        '
        'LblMemberCardNoReq
        '
        Me.LblMemberCardNoReq.Location = New System.Drawing.Point(795, 34)
        Me.LblMemberCardNoReq.Visible = False
        '
        'TxtMemberCardNo
        '
        Me.TxtMemberCardNo.AgMandatory = False
        Me.TxtMemberCardNo.Location = New System.Drawing.Point(770, 44)
        Me.TxtMemberCardNo.Size = New System.Drawing.Size(57, 18)
        Me.TxtMemberCardNo.Visible = False
        '
        'LblMemberCardNo
        '
        Me.LblMemberCardNo.Location = New System.Drawing.Point(767, 11)
        Me.LblMemberCardNo.Size = New System.Drawing.Size(87, 16)
        Me.LblMemberCardNo.Text = "Vendor Name"
        Me.LblMemberCardNo.Visible = False
        '
        'TxtMemberType
        '
        Me.TxtMemberType.Location = New System.Drawing.Point(753, 82)
        Me.TxtMemberType.Size = New System.Drawing.Size(66, 18)
        Me.TxtMemberType.TabIndex = 5
        Me.TxtMemberType.Visible = False
        '
        'LblMemberType
        '
        Me.LblMemberType.Location = New System.Drawing.Point(750, 63)
        Me.LblMemberType.Visible = False
        '
        'TxtApplicationNo
        '
        Me.TxtApplicationNo.Location = New System.Drawing.Point(13, 109)
        Me.TxtApplicationNo.Visible = False
        '
        'LblApplicationNo
        '
        Me.LblApplicationNo.Location = New System.Drawing.Point(17, 92)
        Me.LblApplicationNo.Visible = False
        '
        'TxtTransactionBy
        '
        Me.TxtTransactionBy.Location = New System.Drawing.Point(322, 74)
        Me.TxtTransactionBy.Size = New System.Drawing.Size(182, 18)
        Me.TxtTransactionBy.TabIndex = 6
        '
        'LblTransactionBy
        '
        Me.LblTransactionBy.Location = New System.Drawing.Point(168, 76)
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.Location = New System.Drawing.Point(258, 2)
        Me.LblTotalMeasure.Visible = False
        '
        'LblTotalMeasureTextReq
        '
        Me.LblTotalMeasureTextReq.Location = New System.Drawing.Point(147, 2)
        Me.LblTotalMeasureTextReq.Size = New System.Drawing.Size(80, 16)
        Me.LblTotalMeasureTextReq.Text = "Total Fine :"
        Me.LblTotalMeasureTextReq.Visible = False
        '
        'TxtMemberRemark
        '
        Me.TxtMemberRemark.Location = New System.Drawing.Point(49, 74)
        Me.TxtMemberRemark.Size = New System.Drawing.Size(29, 18)
        Me.TxtMemberRemark.TabIndex = 7
        Me.TxtMemberRemark.Visible = False
        '
        'LblMemberRemark
        '
        Me.LblMemberRemark.Location = New System.Drawing.Point(15, 63)
        Me.LblMemberRemark.Size = New System.Drawing.Size(98, 16)
        Me.LblMemberRemark.Text = "Vendor Remark"
        Me.LblMemberRemark.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(748, 575)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(594, 575)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(421, 575)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(145, 575)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(11, 575)
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 571)
        Me.GroupBox1.Size = New System.Drawing.Size(895, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(287, 575)
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(510, 36)
        Me.LblV_No.Size = New System.Drawing.Size(63, 16)
        Me.LblV_No.Text = "Entry No."
        '
        'TxtV_No
        '
        Me.TxtV_No.Location = New System.Drawing.Point(611, 34)
        Me.TxtV_No.Size = New System.Drawing.Size(121, 18)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(306, 41)
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(168, 36)
        Me.LblV_Date.Size = New System.Drawing.Size(70, 16)
        Me.LblV_Date.Text = "Entry Date"
        '
        'TxtV_Date
        '
        Me.TxtV_Date.Location = New System.Drawing.Point(322, 34)
        Me.TxtV_Date.Size = New System.Drawing.Size(182, 18)
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(510, 16)
        Me.LblV_Type.Size = New System.Drawing.Size(71, 16)
        Me.LblV_Type.Text = "Entry Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.Location = New System.Drawing.Point(611, 14)
        Me.TxtV_Type.Size = New System.Drawing.Size(121, 18)
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.Size = New System.Drawing.Size(182, 18)
        '
        'TabControl1
        '
        Me.TabControl1.Size = New System.Drawing.Size(874, 186)
        '
        'TP1
        '
        Me.TP1.Controls.Add(Me.TxtRate)
        Me.TP1.Controls.Add(Me.LblRate)
        Me.TP1.Controls.Add(Me.TxtVendor)
        Me.TP1.Controls.Add(Me.LblVendor)
        Me.TP1.Controls.Add(Me.TxtToReturnDate)
        Me.TP1.Controls.Add(Me.LblToReturnDate)
        Me.TP1.Size = New System.Drawing.Size(866, 160)
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
        Me.TP1.Controls.SetChildIndex(Me.LblToReturnDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtToReturnDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRate, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(877, 41)
        Me.Topctrl1.TabIndex = 3
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(11, 401)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(860, 146)
        Me.Pnl2.TabIndex = 2
        '
        'LinkLabel2
        '
        Me.LinkLabel2.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Location = New System.Drawing.Point(8, 381)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(118, 20)
        Me.LinkLabel2.TabIndex = 733
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Book Return Detail"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtToReturnDate
        '
        Me.TxtToReturnDate.AgMandatory = False
        Me.TxtToReturnDate.AgMasterHelp = False
        Me.TxtToReturnDate.AgNumberLeftPlaces = 8
        Me.TxtToReturnDate.AgNumberNegetiveAllow = False
        Me.TxtToReturnDate.AgNumberRightPlaces = 2
        Me.TxtToReturnDate.AgPickFromLastValue = False
        Me.TxtToReturnDate.AgRowFilter = ""
        Me.TxtToReturnDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtToReturnDate.AgSelectedValue = Nothing
        Me.TxtToReturnDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtToReturnDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtToReturnDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtToReturnDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtToReturnDate.Location = New System.Drawing.Point(611, 54)
        Me.TxtToReturnDate.MaxLength = 50
        Me.TxtToReturnDate.Name = "TxtToReturnDate"
        Me.TxtToReturnDate.Size = New System.Drawing.Size(121, 18)
        Me.TxtToReturnDate.TabIndex = 5
        '
        'LblToReturnDate
        '
        Me.LblToReturnDate.AutoSize = True
        Me.LblToReturnDate.BackColor = System.Drawing.Color.Transparent
        Me.LblToReturnDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblToReturnDate.Location = New System.Drawing.Point(510, 55)
        Me.LblToReturnDate.Name = "LblToReturnDate"
        Me.LblToReturnDate.Size = New System.Drawing.Size(95, 16)
        Me.LblToReturnDate.TabIndex = 744
        Me.LblToReturnDate.Text = "To Return Date"
        '
        'TxtVendor
        '
        Me.TxtVendor.AgMandatory = False
        Me.TxtVendor.AgMasterHelp = False
        Me.TxtVendor.AgNumberLeftPlaces = 8
        Me.TxtVendor.AgNumberNegetiveAllow = False
        Me.TxtVendor.AgNumberRightPlaces = 2
        Me.TxtVendor.AgPickFromLastValue = False
        Me.TxtVendor.AgRowFilter = ""
        Me.TxtVendor.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendor.AgSelectedValue = Nothing
        Me.TxtVendor.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendor.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVendor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendor.Location = New System.Drawing.Point(322, 54)
        Me.TxtVendor.MaxLength = 50
        Me.TxtVendor.Name = "TxtVendor"
        Me.TxtVendor.Size = New System.Drawing.Size(182, 18)
        Me.TxtVendor.TabIndex = 4
        '
        'LblVendor
        '
        Me.LblVendor.AutoSize = True
        Me.LblVendor.BackColor = System.Drawing.Color.Transparent
        Me.LblVendor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendor.Location = New System.Drawing.Point(168, 55)
        Me.LblVendor.Name = "LblVendor"
        Me.LblVendor.Size = New System.Drawing.Size(45, 16)
        Me.LblVendor.TabIndex = 746
        Me.LblVendor.Text = "Binder"
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.AutoSize = True
        Me.LblTotalAmountText.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalAmountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTotalAmountText.Location = New System.Drawing.Point(711, 2)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(93, 16)
        Me.LblTotalAmountText.TabIndex = 747
        Me.LblTotalAmountText.Text = "Total Amount"
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.AutoSize = True
        Me.LblTotalAmount.BackColor = System.Drawing.Color.Transparent
        Me.LblTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LblTotalAmount.Location = New System.Drawing.Point(820, 2)
        Me.LblTotalAmount.Name = "LblTotalAmount"
        Me.LblTotalAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalAmount.TabIndex = 748
        Me.LblTotalAmount.Text = "."
        '
        'TxtIssueNo
        '
        Me.TxtIssueNo.AgMandatory = False
        Me.TxtIssueNo.AgMasterHelp = False
        Me.TxtIssueNo.AgNumberLeftPlaces = 8
        Me.TxtIssueNo.AgNumberNegetiveAllow = False
        Me.TxtIssueNo.AgNumberRightPlaces = 2
        Me.TxtIssueNo.AgPickFromLastValue = False
        Me.TxtIssueNo.AgRowFilter = ""
        Me.TxtIssueNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIssueNo.AgSelectedValue = Nothing
        Me.TxtIssueNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIssueNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtIssueNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIssueNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIssueNo.Location = New System.Drawing.Point(767, 381)
        Me.TxtIssueNo.MaxLength = 50
        Me.TxtIssueNo.Name = "TxtIssueNo"
        Me.TxtIssueNo.Size = New System.Drawing.Size(102, 18)
        Me.TxtIssueNo.TabIndex = 747
        '
        'LblIssueNo
        '
        Me.LblIssueNo.AutoSize = True
        Me.LblIssueNo.BackColor = System.Drawing.Color.Transparent
        Me.LblIssueNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIssueNo.Location = New System.Drawing.Point(698, 382)
        Me.LblIssueNo.Name = "LblIssueNo"
        Me.LblIssueNo.Size = New System.Drawing.Size(63, 16)
        Me.LblIssueNo.TabIndex = 748
        Me.LblIssueNo.Text = "Issue No."
        '
        'TxtRate
        '
        Me.TxtRate.AgMandatory = False
        Me.TxtRate.AgMasterHelp = False
        Me.TxtRate.AgNumberLeftPlaces = 8
        Me.TxtRate.AgNumberNegetiveAllow = False
        Me.TxtRate.AgNumberRightPlaces = 2
        Me.TxtRate.AgPickFromLastValue = False
        Me.TxtRate.AgRowFilter = ""
        Me.TxtRate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRate.AgSelectedValue = Nothing
        Me.TxtRate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRate.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtRate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRate.Location = New System.Drawing.Point(611, 74)
        Me.TxtRate.MaxLength = 50
        Me.TxtRate.Name = "TxtRate"
        Me.TxtRate.Size = New System.Drawing.Size(121, 18)
        Me.TxtRate.TabIndex = 7
        '
        'LblRate
        '
        Me.LblRate.AutoSize = True
        Me.LblRate.BackColor = System.Drawing.Color.Transparent
        Me.LblRate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRate.Location = New System.Drawing.Point(510, 73)
        Me.LblRate.Name = "LblRate"
        Me.LblRate.Size = New System.Drawing.Size(35, 16)
        Me.LblRate.TabIndex = 750
        Me.LblRate.Text = "Rate"
        '
        'FrmBookIssueToBinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(877, 616)
        Me.Controls.Add(Me.TxtIssueNo)
        Me.Controls.Add(Me.LblIssueNo)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Pnl2)
        Me.LogLineTableCsv = "Lib_BookIssueDetail_Log,Stock_Log"
        Me.LogTableName = "Lib_BookIssue_Log"
        Me.MainLineTableCsv = "Lib_BookIssueDetail,Stock"
        Me.MainTableName = "Lib_BookIssue"
        Me.Name = "FrmBookIssueToBinder"
        Me.Text = "Book Issue"
        Me.Controls.SetChildIndex(Me.Pnl2, 0)
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
        Me.Controls.SetChildIndex(Me.LinkLabel2, 0)
        Me.Controls.SetChildIndex(Me.LblIssueNo, 0)
        Me.Controls.SetChildIndex(Me.TxtIssueNo, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Friend WithEvents Pnl2 As System.Windows.Forms.Panel
    Protected WithEvents TxtToReturnDate As AgControls.AgTextBox
    Protected WithEvents LblToReturnDate As System.Windows.Forms.Label
    Protected WithEvents TxtVendor As AgControls.AgTextBox
    Protected WithEvents LblVendor As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents TxtIssueNo As AgControls.AgTextBox
    Protected WithEvents LblIssueNo As System.Windows.Forms.Label
    Protected WithEvents TxtRate As AgControls.AgTextBox
    Protected WithEvents LblRate As System.Windows.Forms.Label
#End Region

    Private Sub FrmBookIssue_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer, mSr As Integer
        If 1 = 2 Then

        Else
            With Dgl2
                For I = 0 To .RowCount - 1
                    If .Item(Col2BookId, I).Value <> "" Or .Item(Col2TempBookId, I).Value <> "" Then
                        mSr += 1
                        If .Item(Col2TempBookId, I).Value <> "" Then
                            mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 0 " & _
                                    " WHERE Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2TempBookId, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                        End If

                        If .Item(Col2BookId, I).Value <> "" Then
                            mQry = " UPDATE Lib_AccessionDetail SET IsInStock = 1 " & _
                                    " WHERE Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2BookId, I).Value) & " "
                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                        End If
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT H.DocID AS SearchCode, Vt.Description AS [Issue Type], H.V_Date AS [Issue Date], " & _
                            " H.V_No AS [Issue No], Sg.DispName As [Binder Name], " & _
                            " H.Remarks  " & _
                            " FROM Lib_BookIssue H " & _
                            " LEFT JOIN Voucher_type Vt ON H.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup Sg ON Sg.SubCode = H.Vendor " & _
                            " Where 1=1 " & mCondStr

        AgL.PubFindQryOrdBy = "[Issue Date]"
    End Sub

    Private Sub FrmTempRequisition_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT H.DocID AS SearchCode, Vt.Description AS [Issue Type], H.V_Date AS [Issue Date], " & _
                            " H.V_No AS [Issue No], Sg.DispName As [Binder Name], " & _
                            " H.Remarks  " & _
                            " FROM Lib_BookIssue H " & _
                            " LEFT JOIN Voucher_type Vt ON H.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup Sg ON Sg.SubCode = H.Vendor " & _
                            " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Issue Date]"
    End Sub

    Private Sub FrmBookIssue_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        TxtApplicationNo.AgSelectedValue = ""
        'If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1BookId).Index) And AgCL.AgIsBlankGrid(Dgl2, Dgl2.Columns(Col2BookId).Index) Then passed = False : Exit Sub
        'If Dgl1.RowCount < 2 And Dgl2.RowCount < 1 Then MsgBox("Fill Transaction Detail !") : passed = False : Exit Sub

        Dim I As Integer
        Dim bBookReceiveCount As Integer
        bBookReceiveCount = 0

        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1BookId, I).Value <> "" Then
                    bBookReceiveCount += 1
                End If
            Next
        End With

        With Dgl2
            For I = 0 To .RowCount - 1
                If .Item(Col2BookId, I).Value <> "" And Dgl2.Item(Col2Received, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                    bBookReceiveCount += 1
                End If
            Next
        End With

        If bBookReceiveCount < 1 Then
            MsgBox("No Transaction Data in Grid")
            passed = False : Exit Sub
        End If


    End Sub

    Private Sub FrmBookIssue_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        AgL.GridDesign(Dgl2)
    End Sub

    Private Sub FrmBookIssue_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer


        mQry = " UPDATE Lib_BookIssue_Log " & _
                " SET Vendor = " & AgL.Chk_Text(TxtVendor.AgSelectedValue) & ", " & _
                " Rate = " & Val(TxtRate.Text) & " " & _
                " WHERE UID = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        With Dgl2
            For I = 0 To .RowCount - 1
                If .Item(Col2BookId, I).Value <> "" And Dgl2.Item(Col2Received, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                    mSr += 1
                    mMainSr += 1
                    mQry = " UPDATE Lib_BookIssueDetail " & _
                            " SET ReturnDocId = " & AgL.Chk_Text(mInternalCode) & " , " & _
                            " ReturnDate = " & AgL.ConvertDate(Dgl2.Item(Col2DateofReturn, I).Value.ToString) & ", " & _
                            " Status = " & AgL.Chk_Text(Dgl2.Item(Col2Status, I).Value) & ", " & _
                            " Rate = " & Val(Dgl2.Item(Col2Rate, I).Value) & ", " & _
                            " Remarks = " & AgL.Chk_Text(Dgl2.Item(Col2Remark, I).Value) & " " & _
                            " WHERE DocId = " & AgL.Chk_Text(Dgl2.AgSelectedValue(Col2IssueDocId, I)) & "  " & _
                            " AND Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2BookId, I).Value) & " "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                    mQry = " INSERT INTO Stock_Log (DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, " & _
                            " Site_Code, SubCode, Item, Qty_Rec, Unit, Remarks, Edition,UID ) " & _
                            " VALUES (" & AgL.Chk_Text(mInternalCode) & ", " & mMainSr & ", " & _
                            " " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                            " " & AgL.Chk_Text(LblPrefix.Text) & ", " & AgL.ConvertDate(TxtV_Date.Text) & ",  " & _
                            " " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(AgL.PubDivCode) & ", " & _
                            " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                            " " & AgL.Chk_Text(TxtTransactionBy.AgSelectedValue) & ", " & _
                            " " & AgL.Chk_Text(Dgl2.AgSelectedValue(Col2Book, I)) & ", " & Val(Dgl2.Item(Col2Qty, I).Value) & ",  " & _
                            " " & AgL.Chk_Text(Dgl2.Item(Col2Unit, I).Value) & ", " & AgL.Chk_Text(TxtRemarks.Text) & ", " & AgL.Chk_Text(Dgl2.Item(Col2Edition, I).Value) & "," & AgL.Chk_Text(mSearchCode) & "  ) "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmBookIssue_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
        LblTotalMeasure.Text = 0 : LblTotalQty.Text = 0
    End Sub

    Private Sub FrmBookIssue_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer
        Dim bLateDays As Double

        LblTotalQty.Text = 0 : LblTotalMeasure.Text = 0 : LblTotalAmount.Text = 0

        For I = 0 To Dgl2.RowCount - 1
            bLateDays = 0
            If Dgl2.Item(Col2BookId, I).Value <> "" And Dgl2.Item(Col2Received, I).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                Dgl2.Item(Col2Rate, I).Value = Val(TxtRate.Text)
            End If
            LblTotalAmount.Text = Format(Val(LblTotalAmount.Text) + Val(Dgl2.Item(Col2Rate, I).Value), "0.00")
            LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl2.Item(Col2Qty, I).Value)

        Next

        LblTotalMeasure.Text = Format(Val(LblTotalMeasure.Text), "0.000")
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")

        For I = 0 To Dgl1.Rows.Count - 1
            If Dgl1.Item(Col1Book, I).Value <> "" Then
                Dgl1.Item(Col1DateToReturn, I).Value = TxtToReturnDate.Text
                If TxtV_Date.Text <> "" And Dgl1.Item(Col1DateToReturn, I).Value <> "" Then
                    Dgl1.Item(Col1ForDays, I).Value = DateDiff(DateInterval.Day, CDate(TxtV_Date.Text), CDate(Dgl1.Item(Col1DateToReturn, I).Value))
                End If
            End If
        Next
    End Sub

    Private Sub FrmBookIssueToBinder_BaseFunction_DispText() Handles Me.BaseFunction_DispText
    End Sub

    Private Sub FrmBookIssue_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup ,B.Writer,B.Publisher,B.BookType, " & _
                " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, ISNULL(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status, I.Measure, MeasureUnit " & _
                " FROM Item I" & _
                " LEFT JOIN Lib_Book B ON B.Code=I.Code "
        Dgl2.AgHelpDataSet(Col2Book, 11) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT V.SubCode AS Code, Sg.DispName AS VendorName, " & _
                " isnull(Sg.IsDeleted,0) AS IsDeleted, Sg.Div_Code , " & _
                " isnull(Sg.Status,'Active') AS Status " & _
                " FROM Vendor V   " & _
                " LEFT JOIN SubGroup Sg ON V.SubCode = Sg.SubCode " & _
                " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
        TxtVendor.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        'mQry = " SELECT " & AgL.Chk_Text(Status_Received) & " AS Code, " & AgL.Chk_Text(Status_Received) & " AS Name " & _
        '        " UNION ALL " & _
        '        " SELECT " & AgL.Chk_Text(Status_Replaced) & " AS Code, " & AgL.Chk_Text(Status_Replaced) & " AS Name " & _
        '        " UNION ALL " & _
        '        " SELECT " & AgL.Chk_Text(Status_Lost) & " AS Code, " & AgL.Chk_Text(Status_Lost) & " AS Name "
        'Dgl2.AgHelpDataSet(Col2Status, 0) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT H.DocID AS Code, H.V_Type + '-' + Convert(nVarChar,H.V_No) As IssueNo, H.Vendor , " & _
                   " IsNull(H.IsDeleted,0), " & _
                   " IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "')   " & _
                   " FROM Lib_BookIssue H " & _
                   " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                   " WHERE Vt.NCat = '" & ClsMain.Temp_NCat.BookIssueReceiveToBinder & "' "
        Dgl2.AgHelpDataSet(Col2IssueDocId, 3) = AgL.FillData(mQry, AgL.GCn)
        TxtIssueNo.AgHelpDataSet(3) = Dgl2.AgHelpDataSet(Col2IssueDocId, 2).Copy



    End Sub

    Private Sub FrmBookIssue_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl2.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl2, ColSNo, 35, 5, ColSNo, False, True, False)
            .AddAgCheckColumn(Dgl2, Col2Received, 60, Col2Received, True)
            .AddAgTextColumn(Dgl2, Col2Status, 100, 15, Col2Status, True, True, False)
            .AddAgTextColumn(Dgl2, Col2IssueDocId, 100, 21, Col2IssueDocId, True, False)
            .AddAgTextColumn(Dgl2, Col2AccessionNo, 100, 20, Col2AccessionNo, True, True)
            .AddAgTextColumn(Dgl2, Col2BookId, 100, 20, Col2BookId, True, True)
            .AddAgTextColumn(Dgl2, Col2TempBookId, 100, 20, Col2TempBookId, False, True)
            .AddAgTextColumn(Dgl2, Col2Book, 170, 0, Col2Book, True, True)
            .AddAgTextColumn(Dgl2, Col2Writer, 170, 0, Col2Writer, True, True)
            .AddAgTextColumn(Dgl2, Col2Publisher, 170, 0, Col2Publisher, True, True)
            .AddAgTextColumn(Dgl2, Col2Edition, 80, 20, Col2Edition, True, True)
            .AddAgNumberColumn(Dgl2, Col2Qty, 50, 5, 0, False, Col2Qty, False, True, True)
            .AddAgTextColumn(Dgl2, Col2Unit, 80, 20, Col2Unit, False, False)
            .AddAgDateColumn(Dgl2, Col2DateToReturn, 80, Col2DateToReturn, True, True)
            .AddAgDateColumn(Dgl2, Col2DateofReturn, 80, Col2DateofReturn, True, True)
            .AddAgNumberColumn(Dgl2, Col2Rate, 50, 5, 0, False, Col2Rate, True, True, True)
            .AddAgTextColumn(Dgl2, Col2Remark, 120, 255, Col2Remark, True, False)
        End With
        'Dgl2.Columns(Col2Received).CellTemplate.Style.Font = New Font(New FontFamily("Wingdings"), 12)

        AgL.AddAgDataGrid(Dgl2, Pnl2)
        Dgl2.EnableHeadersVisualStyles = False
        Dgl2.ColumnHeadersHeight = 35
        Dgl2.AllowUserToAddRows = False

        'Dgl1.Anchor = AnchorStyles.None
        'Panel1.Anchor = Dgl1.Anchor

        'Dgl1.Columns(Col1DateToReturn).Visible = False
    End Sub

    Private Sub FrmBookIssue_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet



        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                    " From Lib_BookIssue H " & _
                    " Where H.DocID = '" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                    " From Lib_BookIssue_Log H " & _
                    " Where H.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtVendor.AgSelectedValue = AgL.XNull(.Rows(0)("Vendor"))
                TxtRate.Text = AgL.VNull(.Rows(0)("Rate"))
                LblTotalAmount.Text = Format(AgL.VNull(.Rows(0)("TotalAmount")), "0.00")
            End If
        End With

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select L.* " & _
                    " From Lib_BookIssueDetail L " & _
                    " Where L.DocID = '" & SearchCode & "'"
        Else
            mQry = "Select L.* " & _
                    " From Lib_BookIssueDetail_Log L " & _
                    " Where L.UID='" & SearchCode & "'"
        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtToReturnDate.Text = AgL.XNull(.Rows(0)("ToReturnDate"))
            End If
        End With


        '-------------------------------------------------------------
        'Line Records are showing in First Grid
        '-------------------------------------------------------------
        mQry = " Select BI.* ,B.Writer ,B.Publisher  " & _
                " FROM Lib_BookIssueDetail BI " & _
                " LEFT JOIN Lib_Book B  ON B.Code=BI.Book  " & _
                " Where ReturnDocId = '" & mInternalCode & "' Order By Sr"

        DsTemp = AgL.FillData(mQry, AgL.GCn)
        With DsTemp.Tables(0)
            Dgl2.RowCount = 1
            Dgl2.Rows.Clear()
            If .Rows.Count > 0 Then
                For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                    Dgl2.Rows.Add()
                    Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count - 1
                    Dgl2.Item(Col2Received, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                    Dgl2.AgSelectedValue(Col2IssueDocId, I) = AgL.XNull(.Rows(I)("DocId"))
                    Dgl2.Item(Col1AccessionNo, I).Value = AgL.XNull(.Rows(I)("AccessionNo"))
                    Dgl2.Item(Col1BookId, I).Value = AgL.XNull(.Rows(I)("Book_UID"))
                    Dgl2.AgSelectedValue(Col2Book, I) = AgL.XNull(.Rows(I)("Book"))
                    Dgl2.Item(Col2Edition, I).Value = AgL.XNull(.Rows(I)("Edition"))
                    Dgl2.Item(Col2Status, I).Value = AgL.XNull(.Rows(I)("Status"))
                    Dgl2.Item(Col2DateToReturn, I).Value = AgL.XNull(.Rows(I)("ToReturnDate"))
                    Dgl2.Item(Col2DateofReturn, I).Value = AgL.XNull(.Rows(I)("ReturnDate"))
                    Dgl2.Item(Col2TempBookId, I).Value = AgL.XNull(.Rows(I)("Book_UID"))
                    Dgl2.Item(Col2Rate, I).Value = AgL.VNull(.Rows(I)("Rate"))
                    Dgl2.Item(Col2Remark, I).Value = AgL.XNull(.Rows(I)("Remarks"))
                    Dgl2.Item(Col2Writer, I).Value = AgL.XNull(.Rows(I)("Writer"))
                    Dgl2.Item(Col2Publisher, I).Value = AgL.XNull(.Rows(I)("Publisher"))
                    Dgl2.Item(Col2Qty, I).Value = 1

                    'If CDate(Dgl2.Item(Col2DateToReturn, I).Value) <= AgL.PubLoginDate Then
                    '    Dgl2.Rows(I).DefaultCellStyle.ForeColor = System.Drawing.Color.Red
                    'Else
                    '    Dgl2.Rows(I).DefaultCellStyle.ForeColor = System.Drawing.Color.Black
                    'End If

                Next I
            End If
        End With
        Calculation()
        '-------------------------------------------------------------
    End Sub

    Private Sub FrmBookIssue_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 650, 885)
    End Sub

    Private Sub Dgl2_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl2.EditingControl_Validating
        Call Calculation()
    End Sub

    Private Sub DGL2_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl2.RowsAdded
        Dim I As Integer = 0
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
        Try
            With Dgl2
                For I = .Columns(Col2Received).Index To .Columns(Col2Received).Index
                    If .Columns(I).Name <> ColSNo Then
                        sender.Item(I, sender.Rows.Count - 1).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                    End If
                Next
            End With
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ProcFillReceiveGrid(ByVal bVendorCode As String, Optional ByVal IssueDocId As String = "")
        Dim DtTemp As DataTable
        Dim I As Integer
        Dim bConStr$ = ""
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub
            If AgL.StrCmp(Topctrl1.Mode, "Edit") Then Exit Sub

            If IssueDocId <> "" Then
                bConStr = " And H.DocId = '" & IssueDocId & "'"
            End If


            mQry = " SELECT H.DocID AS IssueDocId, H.Vendor, L.Book_UID ,L.Book ,I.Unit, " & _
                    " I.Description AS BookName, B.Writer, B.Publisher, L.Edition , L.ForDays, " & _
                    " L.ToReturnDate , L.AccessionNo " & _
                    " FROM Lib_BookIssue H " & _
                    " LEFT JOIN Lib_BookIssueDetail L ON H.DocID=L.DocId  " & _
                    " LEFT JOIN Item I ON I.Code=L.Book  " & _
                    " LEFT JOIN Lib_Book B ON B.Code=L.Book  " & _
                    " WHERE H.Vendor = " & AgL.Chk_Text(bVendorCode) & "  " & _
                    " AND L.ReturnDocId IS NULL " & _
                    " AND isnull(H.IsDeleted,0) = 0 " & _
                    " AND L.Book_UID IS NOT NULL " & _
                    " AND isnull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & bConStr & _
                    " ORDER BY L.ToReturnDate "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DtTemp.Rows.Count - 1
                        Dgl2.Rows.Add()
                        Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count
                        Dgl2.Item(Col2Received, I).Value = AgLibrary.ClsConstant.StrUnCheckedValue
                        Dgl2.AgSelectedValue(Col2IssueDocId, I) = AgL.XNull(.Rows(I)("IssueDocId"))
                        Dgl2.Item(Col2AccessionNo, I).Value = AgL.XNull(.Rows(I)("AccessionNo"))
                        Dgl2.Item(Col2BookId, I).Value = AgL.XNull(.Rows(I)("Book_UID"))
                        Dgl2.AgSelectedValue(Col2Book, I) = AgL.XNull(.Rows(I)("Book"))
                        Dgl2.Item(Col2Writer, I).Value = AgL.XNull(.Rows(I)("Writer"))
                        Dgl2.Item(Col2Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl2.Item(Col2Publisher, I).Value = AgL.XNull(.Rows(I)("Publisher"))
                        Dgl2.Item(Col2Edition, I).Value = AgL.XNull(.Rows(I)("Edition"))
                        Dgl2.Item(Col2DateToReturn, I).Value = AgL.XNull(.Rows(I)("ToReturnDate"))
                        Dgl2.Item(Col2DateofReturn, I).Value = TxtV_Date.Text
                        Dgl2.Item(Col2Qty, I).Value = 1

                        'If Dgl2.Item(Col2DateToReturn, I).Value <> "" Then
                        '    If CDate(Dgl2.Item(Col2DateToReturn, I).Value) <= CDate(Dgl2.Item(Col2DateofReturn, I).Value) Then
                        '        Dgl2.Rows(I).DefaultCellStyle.ForeColor = System.Drawing.Color.Red
                        '    Else
                        '        Dgl2.Rows(I).DefaultCellStyle.ForeColor = System.Drawing.Color.Black
                        '    End If
                        'End If
                    Next I
                End If
            End With
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            DtTemp = Nothing
        End Try
    End Sub

    Private Sub TxtControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtVendor.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.name
                Case TxtVendor.Name
                    If TxtVendor.AgSelectedValue <> "" Then
                        ProcFillReceiveGrid(TxtVendor.AgSelectedValue)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub DGL2_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgl2.CellMouseUp
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = sender.CurrentCell.RowIndex
            mColumnIndex = sender.CurrentCell.ColumnIndex

            If sender.Item(mColumnIndex, mRowIndex).Value Is Nothing Then sender.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col2Received
                    Call AgL.ProcSetCheckColumnCellValue(sender, Dgl2.CurrentCell.ColumnIndex)
            End Select
        Catch ex As Exception
            'MsgBox(ex.Message)
            If Dgl2.Item(Col2Received, mRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                Dgl2.Item(Col2Status, mRowIndex).Value = Status_Received
                Call Calculation()
            Else
                Dgl2.Item(Col2Status, mRowIndex).Value = ""
                Call Calculation()
            End If
        End Try
    End Sub

    Private Sub TxtToReturnDate_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtToReturnDate.Validating
        Try
            Select Case sender.name
                Case TxtMemberName.Name


            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl2.KeyDown
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        Dim mRowIndex As Integer = 0, mColumnIndex As Integer = 0
        Try
            mRowIndex = sender.CurrentCell.RowIndex
            mColumnIndex = sender.CurrentCell.ColumnIndex
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col2Received
                    If e.KeyCode = Keys.Space Then
                        AgL.ProcSetCheckColumnCellValue(sender, mColumnIndex)
                    End If
            End Select
        Catch ex As Exception
            If Dgl2.Item(Col2Received, mRowIndex).Value = AgLibrary.ClsConstant.StrCheckedValue Then
                Dgl2.Item(Col2Status, mRowIndex).Value = Status_Received
                Call Calculation()
            Else
                Dgl2.Item(Col2Status, mRowIndex).Value = ""
                Call Calculation()
            End If
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1BookId
                Dgl1.AgRowFilter(Dgl1.Columns(Col1BookId).Index) += " And ItemType <> '" & ClsMain.ItemType.CD & "' "
        End Select
    End Sub

    Private Sub TxtIssueNo_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtIssueNo.Validating, TxtMemberCardNo.Validating, TxtMemberName.Validating, TxtMemberRemark.Validating, TxtMemberType.Validating, TxtRate.Validating, TxtRemarks.Validating, TxtVendor.Validating
        Try
            Select Case sender.Name
                Case TxtIssueNo.Name
                    Call ProcFillReceiveGrid(TxtVendor.AgSelectedValue, TxtIssueNo.AgSelectedValue)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmBookIssueToBinder_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        Dim I As Integer, mSr As Integer

        With Dgl2
            For I = 0 To .RowCount - 1
                If .Item(Col2BookId, I).Value <> "" Then
                    mSr += 1
                    If .Item(Col2TempBookId, I).Value <> "" Then
                        mQry = " UPDATE Lib_AccessionDetail " & _
                                " SET IsInStock = 0 " & _
                                " WHERE Book_UID = " & AgL.Chk_Text(Dgl2.Item(Col2TempBookId, I).Value) & " "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    End If
                End If
            Next
        End With
    End Sub
End Class
