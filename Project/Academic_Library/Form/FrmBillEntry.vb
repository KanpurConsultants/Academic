Public Class FrmBillEntry
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.BillEntry
    End Sub

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.TxtIssueNo = New AgControls.AgTextBox
        Me.LblIssueNo = New System.Windows.Forms.Label
        Me.TxtReceivedBooks = New AgControls.AgTextBox
        Me.LblReceivedBooks = New System.Windows.Forms.Label
        Me.TxtIssuedBooks = New AgControls.AgTextBox
        Me.LblIssuedBooks = New System.Windows.Forms.Label
        Me.TxtOtherCharges = New AgControls.AgTextBox
        Me.LblOtherCharges = New System.Windows.Forms.Label
        Me.TxtAmount = New AgControls.AgTextBox
        Me.LblAmount = New System.Windows.Forms.Label
        Me.LblReceivedBooksReq = New System.Windows.Forms.Label
        Me.TxtDiscount = New AgControls.AgTextBox
        Me.LblDiscount = New System.Windows.Forms.Label
        Me.TxtNetAmount = New AgControls.AgTextBox
        Me.LblNetAmount = New System.Windows.Forms.Label
        Me.TxtPendingBooks = New AgControls.AgTextBox
        Me.LblPendingBooks = New System.Windows.Forms.Label
        Me.TxtVendor = New AgControls.AgTextBox
        Me.LblVendor = New System.Windows.Forms.Label
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
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(729, 321)
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(569, 321)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(3, 23)
        Me.TxtMoveToLog.Size = New System.Drawing.Size(142, 18)
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(410, 321)
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Tag = ""
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(240, 321)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 321)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(2, 315)
        Me.GroupBox1.Size = New System.Drawing.Size(895, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(470, 321)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
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
        Me.LblV_No.Location = New System.Drawing.Point(455, 74)
        Me.LblV_No.Tag = ""
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(568, 73)
        Me.TxtV_No.Size = New System.Drawing.Size(87, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(339, 79)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.Location = New System.Drawing.Point(213, 74)
        Me.LblV_Date.Tag = ""
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(339, 59)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(354, 73)
        Me.TxtV_Date.Size = New System.Drawing.Size(94, 18)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(213, 54)
        Me.LblV_Type.Tag = ""
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(354, 53)
        Me.TxtV_Type.Size = New System.Drawing.Size(301, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(339, 39)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.Location = New System.Drawing.Point(213, 34)
        Me.LblSite_Code.Tag = ""
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(354, 33)
        Me.TxtSite_Code.Size = New System.Drawing.Size(301, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(516, 74)
        Me.LblPrefix.Tag = ""
        '
        'TabControl1
        '
        Me.TabControl1.Location = New System.Drawing.Point(0, 16)
        Me.TabControl1.Size = New System.Drawing.Size(877, 299)
        Me.TabControl1.TabIndex = 1
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.Gainsboro
        Me.TP1.Controls.Add(Me.TxtVendor)
        Me.TP1.Controls.Add(Me.LblVendor)
        Me.TP1.Controls.Add(Me.TxtPendingBooks)
        Me.TP1.Controls.Add(Me.LblPendingBooks)
        Me.TP1.Controls.Add(Me.TxtNetAmount)
        Me.TP1.Controls.Add(Me.LblNetAmount)
        Me.TP1.Controls.Add(Me.TxtDiscount)
        Me.TP1.Controls.Add(Me.LblDiscount)
        Me.TP1.Controls.Add(Me.LblReceivedBooksReq)
        Me.TP1.Controls.Add(Me.TxtAmount)
        Me.TP1.Controls.Add(Me.LblAmount)
        Me.TP1.Controls.Add(Me.TxtOtherCharges)
        Me.TP1.Controls.Add(Me.LblOtherCharges)
        Me.TP1.Controls.Add(Me.TxtIssuedBooks)
        Me.TP1.Controls.Add(Me.LblIssuedBooks)
        Me.TP1.Controls.Add(Me.TxtReceivedBooks)
        Me.TP1.Controls.Add(Me.LblReceivedBooks)
        Me.TP1.Controls.Add(Me.TxtIssueNo)
        Me.TP1.Controls.Add(Me.LblIssueNo)
        Me.TP1.Size = New System.Drawing.Size(869, 270)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblIssueNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtIssueNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReceivedBooks, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReceivedBooks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblIssuedBooks, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtIssuedBooks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblOtherCharges, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtOtherCharges, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAmount, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtAmount, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReceivedBooksReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDiscount, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDiscount, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblNetAmount, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtNetAmount, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPendingBooks, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPendingBooks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendor, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(877, 41)
        Me.Topctrl1.TabIndex = 1
        '
        'TxtIssueNo
        '
        Me.TxtIssueNo.AgMandatory = True
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
        Me.TxtIssueNo.Location = New System.Drawing.Point(354, 113)
        Me.TxtIssueNo.MaxLength = 50
        Me.TxtIssueNo.Name = "TxtIssueNo"
        Me.TxtIssueNo.Size = New System.Drawing.Size(94, 18)
        Me.TxtIssueNo.TabIndex = 5
        '
        'LblIssueNo
        '
        Me.LblIssueNo.AutoSize = True
        Me.LblIssueNo.BackColor = System.Drawing.Color.Transparent
        Me.LblIssueNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIssueNo.Location = New System.Drawing.Point(213, 113)
        Me.LblIssueNo.Name = "LblIssueNo"
        Me.LblIssueNo.Size = New System.Drawing.Size(63, 16)
        Me.LblIssueNo.TabIndex = 710
        Me.LblIssueNo.Text = "Issue No."
        '
        'TxtReceivedBooks
        '
        Me.TxtReceivedBooks.AgMandatory = True
        Me.TxtReceivedBooks.AgMasterHelp = False
        Me.TxtReceivedBooks.AgNumberLeftPlaces = 8
        Me.TxtReceivedBooks.AgNumberNegetiveAllow = False
        Me.TxtReceivedBooks.AgNumberRightPlaces = 0
        Me.TxtReceivedBooks.AgPickFromLastValue = False
        Me.TxtReceivedBooks.AgRowFilter = ""
        Me.TxtReceivedBooks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtReceivedBooks.AgSelectedValue = Nothing
        Me.TxtReceivedBooks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtReceivedBooks.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtReceivedBooks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtReceivedBooks.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReceivedBooks.Location = New System.Drawing.Point(571, 113)
        Me.TxtReceivedBooks.MaxLength = 50
        Me.TxtReceivedBooks.Name = "TxtReceivedBooks"
        Me.TxtReceivedBooks.Size = New System.Drawing.Size(84, 18)
        Me.TxtReceivedBooks.TabIndex = 6
        '
        'LblReceivedBooks
        '
        Me.LblReceivedBooks.AutoSize = True
        Me.LblReceivedBooks.BackColor = System.Drawing.Color.Transparent
        Me.LblReceivedBooks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReceivedBooks.Location = New System.Drawing.Point(452, 112)
        Me.LblReceivedBooks.Name = "LblReceivedBooks"
        Me.LblReceivedBooks.Size = New System.Drawing.Size(101, 16)
        Me.LblReceivedBooks.TabIndex = 712
        Me.LblReceivedBooks.Text = "Received Books"
        '
        'TxtIssuedBooks
        '
        Me.TxtIssuedBooks.AgMandatory = False
        Me.TxtIssuedBooks.AgMasterHelp = False
        Me.TxtIssuedBooks.AgNumberLeftPlaces = 8
        Me.TxtIssuedBooks.AgNumberNegetiveAllow = False
        Me.TxtIssuedBooks.AgNumberRightPlaces = 0
        Me.TxtIssuedBooks.AgPickFromLastValue = False
        Me.TxtIssuedBooks.AgRowFilter = ""
        Me.TxtIssuedBooks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtIssuedBooks.AgSelectedValue = Nothing
        Me.TxtIssuedBooks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtIssuedBooks.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtIssuedBooks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtIssuedBooks.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtIssuedBooks.Location = New System.Drawing.Point(354, 133)
        Me.TxtIssuedBooks.MaxLength = 50
        Me.TxtIssuedBooks.Name = "TxtIssuedBooks"
        Me.TxtIssuedBooks.Size = New System.Drawing.Size(94, 18)
        Me.TxtIssuedBooks.TabIndex = 7
        '
        'LblIssuedBooks
        '
        Me.LblIssuedBooks.AutoSize = True
        Me.LblIssuedBooks.BackColor = System.Drawing.Color.Transparent
        Me.LblIssuedBooks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblIssuedBooks.Location = New System.Drawing.Point(213, 134)
        Me.LblIssuedBooks.Name = "LblIssuedBooks"
        Me.LblIssuedBooks.Size = New System.Drawing.Size(87, 16)
        Me.LblIssuedBooks.TabIndex = 714
        Me.LblIssuedBooks.Text = "Issued Books"
        '
        'TxtOtherCharges
        '
        Me.TxtOtherCharges.AgMandatory = False
        Me.TxtOtherCharges.AgMasterHelp = False
        Me.TxtOtherCharges.AgNumberLeftPlaces = 8
        Me.TxtOtherCharges.AgNumberNegetiveAllow = False
        Me.TxtOtherCharges.AgNumberRightPlaces = 2
        Me.TxtOtherCharges.AgPickFromLastValue = False
        Me.TxtOtherCharges.AgRowFilter = ""
        Me.TxtOtherCharges.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOtherCharges.AgSelectedValue = Nothing
        Me.TxtOtherCharges.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOtherCharges.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOtherCharges.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOtherCharges.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOtherCharges.Location = New System.Drawing.Point(571, 153)
        Me.TxtOtherCharges.MaxLength = 50
        Me.TxtOtherCharges.Name = "TxtOtherCharges"
        Me.TxtOtherCharges.Size = New System.Drawing.Size(84, 18)
        Me.TxtOtherCharges.TabIndex = 10
        '
        'LblOtherCharges
        '
        Me.LblOtherCharges.AutoSize = True
        Me.LblOtherCharges.BackColor = System.Drawing.Color.Transparent
        Me.LblOtherCharges.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOtherCharges.Location = New System.Drawing.Point(452, 153)
        Me.LblOtherCharges.Name = "LblOtherCharges"
        Me.LblOtherCharges.Size = New System.Drawing.Size(92, 16)
        Me.LblOtherCharges.TabIndex = 716
        Me.LblOtherCharges.Text = "Other Charges"
        '
        'TxtAmount
        '
        Me.TxtAmount.AgMandatory = False
        Me.TxtAmount.AgMasterHelp = False
        Me.TxtAmount.AgNumberLeftPlaces = 8
        Me.TxtAmount.AgNumberNegetiveAllow = False
        Me.TxtAmount.AgNumberRightPlaces = 2
        Me.TxtAmount.AgPickFromLastValue = False
        Me.TxtAmount.AgRowFilter = ""
        Me.TxtAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtAmount.AgSelectedValue = Nothing
        Me.TxtAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtAmount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAmount.Location = New System.Drawing.Point(354, 153)
        Me.TxtAmount.MaxLength = 8
        Me.TxtAmount.Name = "TxtAmount"
        Me.TxtAmount.Size = New System.Drawing.Size(94, 18)
        Me.TxtAmount.TabIndex = 9
        '
        'LblAmount
        '
        Me.LblAmount.AutoSize = True
        Me.LblAmount.BackColor = System.Drawing.Color.Transparent
        Me.LblAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAmount.Location = New System.Drawing.Point(213, 154)
        Me.LblAmount.Name = "LblAmount"
        Me.LblAmount.Size = New System.Drawing.Size(53, 16)
        Me.LblAmount.TabIndex = 720
        Me.LblAmount.Text = "Amount"
        '
        'LblReceivedBooksReq
        '
        Me.LblReceivedBooksReq.AutoSize = True
        Me.LblReceivedBooksReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReceivedBooksReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReceivedBooksReq.Location = New System.Drawing.Point(552, 119)
        Me.LblReceivedBooksReq.Name = "LblReceivedBooksReq"
        Me.LblReceivedBooksReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReceivedBooksReq.TabIndex = 737
        Me.LblReceivedBooksReq.Text = "Ä"
        '
        'TxtDiscount
        '
        Me.TxtDiscount.AgMandatory = False
        Me.TxtDiscount.AgMasterHelp = False
        Me.TxtDiscount.AgNumberLeftPlaces = 8
        Me.TxtDiscount.AgNumberNegetiveAllow = False
        Me.TxtDiscount.AgNumberRightPlaces = 2
        Me.TxtDiscount.AgPickFromLastValue = False
        Me.TxtDiscount.AgRowFilter = ""
        Me.TxtDiscount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtDiscount.AgSelectedValue = Nothing
        Me.TxtDiscount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtDiscount.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtDiscount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDiscount.Location = New System.Drawing.Point(354, 173)
        Me.TxtDiscount.MaxLength = 50
        Me.TxtDiscount.Name = "TxtDiscount"
        Me.TxtDiscount.Size = New System.Drawing.Size(94, 18)
        Me.TxtDiscount.TabIndex = 11
        '
        'LblDiscount
        '
        Me.LblDiscount.AutoSize = True
        Me.LblDiscount.BackColor = System.Drawing.Color.Transparent
        Me.LblDiscount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblDiscount.Location = New System.Drawing.Point(213, 174)
        Me.LblDiscount.Name = "LblDiscount"
        Me.LblDiscount.Size = New System.Drawing.Size(59, 16)
        Me.LblDiscount.TabIndex = 739
        Me.LblDiscount.Text = "Discount"
        Me.LblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtNetAmount
        '
        Me.TxtNetAmount.AgMandatory = False
        Me.TxtNetAmount.AgMasterHelp = False
        Me.TxtNetAmount.AgNumberLeftPlaces = 8
        Me.TxtNetAmount.AgNumberNegetiveAllow = False
        Me.TxtNetAmount.AgNumberRightPlaces = 2
        Me.TxtNetAmount.AgPickFromLastValue = False
        Me.TxtNetAmount.AgRowFilter = ""
        Me.TxtNetAmount.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtNetAmount.AgSelectedValue = Nothing
        Me.TxtNetAmount.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtNetAmount.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtNetAmount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNetAmount.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNetAmount.Location = New System.Drawing.Point(571, 173)
        Me.TxtNetAmount.MaxLength = 50
        Me.TxtNetAmount.Name = "TxtNetAmount"
        Me.TxtNetAmount.Size = New System.Drawing.Size(84, 18)
        Me.TxtNetAmount.TabIndex = 12
        '
        'LblNetAmount
        '
        Me.LblNetAmount.AutoSize = True
        Me.LblNetAmount.BackColor = System.Drawing.Color.Transparent
        Me.LblNetAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblNetAmount.Location = New System.Drawing.Point(452, 173)
        Me.LblNetAmount.Name = "LblNetAmount"
        Me.LblNetAmount.Size = New System.Drawing.Size(77, 16)
        Me.LblNetAmount.TabIndex = 741
        Me.LblNetAmount.Text = "Net Amount"
        Me.LblNetAmount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtPendingBooks
        '
        Me.TxtPendingBooks.AgMandatory = False
        Me.TxtPendingBooks.AgMasterHelp = False
        Me.TxtPendingBooks.AgNumberLeftPlaces = 8
        Me.TxtPendingBooks.AgNumberNegetiveAllow = False
        Me.TxtPendingBooks.AgNumberRightPlaces = 0
        Me.TxtPendingBooks.AgPickFromLastValue = False
        Me.TxtPendingBooks.AgRowFilter = ""
        Me.TxtPendingBooks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPendingBooks.AgSelectedValue = Nothing
        Me.TxtPendingBooks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPendingBooks.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtPendingBooks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPendingBooks.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPendingBooks.Location = New System.Drawing.Point(571, 133)
        Me.TxtPendingBooks.MaxLength = 50
        Me.TxtPendingBooks.Name = "TxtPendingBooks"
        Me.TxtPendingBooks.Size = New System.Drawing.Size(84, 18)
        Me.TxtPendingBooks.TabIndex = 8
        '
        'LblPendingBooks
        '
        Me.LblPendingBooks.AutoSize = True
        Me.LblPendingBooks.BackColor = System.Drawing.Color.Transparent
        Me.LblPendingBooks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPendingBooks.Location = New System.Drawing.Point(452, 134)
        Me.LblPendingBooks.Name = "LblPendingBooks"
        Me.LblPendingBooks.Size = New System.Drawing.Size(96, 16)
        Me.LblPendingBooks.TabIndex = 743
        Me.LblPendingBooks.Text = "Pending Books"
        '
        'TxtVendor
        '
        Me.TxtVendor.AgMandatory = True
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
        Me.TxtVendor.Location = New System.Drawing.Point(354, 93)
        Me.TxtVendor.MaxLength = 50
        Me.TxtVendor.Name = "TxtVendor"
        Me.TxtVendor.Size = New System.Drawing.Size(301, 18)
        Me.TxtVendor.TabIndex = 4
        '
        'LblVendor
        '
        Me.LblVendor.AutoSize = True
        Me.LblVendor.BackColor = System.Drawing.Color.Transparent
        Me.LblVendor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendor.Location = New System.Drawing.Point(213, 92)
        Me.LblVendor.Name = "LblVendor"
        Me.LblVendor.Size = New System.Drawing.Size(49, 16)
        Me.LblVendor.TabIndex = 745
        Me.LblVendor.Text = "Vendor"
        '
        'FrmBillEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(877, 366)
        Me.Name = "FrmBillEntry"
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

    End Sub
    Protected WithEvents LblIssueNo As System.Windows.Forms.Label
    Protected WithEvents TxtIssueNo As AgControls.AgTextBox
    Protected WithEvents LblReceivedBooks As System.Windows.Forms.Label
    Protected WithEvents TxtReceivedBooks As AgControls.AgTextBox
    Protected WithEvents LblIssuedBooks As System.Windows.Forms.Label
    Protected WithEvents TxtIssuedBooks As AgControls.AgTextBox
    Protected WithEvents LblOtherCharges As System.Windows.Forms.Label
    Protected WithEvents TxtOtherCharges As AgControls.AgTextBox
    Protected WithEvents LblAmount As System.Windows.Forms.Label
    Protected WithEvents TxtAmount As AgControls.AgTextBox
    Protected WithEvents TxtDiscount As AgControls.AgTextBox
    Protected WithEvents LblDiscount As System.Windows.Forms.Label
    Protected WithEvents TxtNetAmount As AgControls.AgTextBox
    Protected WithEvents LblNetAmount As System.Windows.Forms.Label
    Protected WithEvents TxtPendingBooks As AgControls.AgTextBox
    Protected WithEvents LblPendingBooks As System.Windows.Forms.Label
    Protected WithEvents TxtVendor As AgControls.AgTextBox
    Protected WithEvents LblVendor As System.Windows.Forms.Label
    Protected WithEvents LblReceivedBooksReq As System.Windows.Forms.Label
#End Region

    Private Sub FrmBillEntry_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            mQry = " UPDATE Lib_BookIssueDetail " & _
                    " SET ReferenceDocId = '" & mInternalCode & "' " & _
                    " WHERE DocId = '" & TxtIssueNo.AgSelectedValue & "' " & _
                    " AND ReferenceDocId IS NULL " & _
                    " AND Book_UID IN ( " & _
                    " SELECT TOP " & Val(TxtReceivedBooks.Text) & " L.Book_UID  FROM Lib_BookIssueDetail L " & _
                    " WHERE L.DocId = '" & TxtIssueNo.AgSelectedValue & "' " & _
                    " AND L.ReferenceDocId IS NULL) "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmGeneralSubscription_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If Val(TxtReceivedBooks.Text) > Val(TxtPendingBooks.Text) Then
            MsgBox("Received Books Can;t Be Greater Than Pending Books", MsgBoxStyle.Information)
            passed = False : Exit Sub
        End If
    End Sub

    Private Sub FrmGeneralSubscription_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = " SELECT H.UID as SearchCode, H.DocId, Vt.Description AS [Entry Type], " & _
                            " H.V_Date AS [Entry Date], H.V_No AS [Entry No], H.NetAmount  " & _
                            " FROM Bill_Log H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"

    End Sub

    Private Sub FrmGeneralSubscription_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT H.DocID, Vt.Description AS [Entry Type], H.V_Date AS [Entry Date], " & _
                            " H.V_No AS [Entry No]], H.NetAmount  " & _
                            " FROM Bill H " & _
                            " LEFT JOIN Voucher_type Vt ON H.V_Type = Vt.V_Type " & _
                            " Where 1=1 " & mCondStr
        AgL.PubFindQryOrdBy = "[Entry Date]"

    End Sub


    Private Sub FrmGeneralSubscription_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Bill"
        LogTableName = "Bill_Log"
    End Sub

    Private Sub FrmGeneralSubscription_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim StructDue As ClsMain.Dues = Nothing

        mQry = "UPDATE Bill_Log " & _
                " SET " & _
                " ReferenceDocId = " & AgL.Chk_Text(TxtIssueNo.AgSelectedValue) & ", " & _
                " ReceivedQty = " & Val(TxtReceivedBooks.Text) & ", " & _
                " IssuedQty = " & Val(TxtIssuedBooks.Text) & ", " & _
                " PendingQty = " & Val(TxtPendingBooks.Text) & ", " & _
                " Vendor = " & AgL.Chk_Text(TxtVendor.AgSelectedValue) & ", " & _
                " Amount = " & Val(TxtAmount.Text) & ", " & _
                " OtherCharges = " & Val(TxtOtherCharges.Text) & ", " & _
                " Discount = " & Val(TxtDiscount.Text) & ", " & _
                " NetAmount = " & Val(TxtNetAmount.Text) & " " & _
                " Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        With StructDue
            .DocID = mInternalCode
            .Sr = 1
            .V_Type = TxtV_Type.AgSelectedValue
            .V_Prefix = LblPrefix.Text
            .V_Date = TxtV_Date.Text
            .V_No = Val(TxtV_No.Text)
            .Div_Code = TxtDivision.AgSelectedValue
            .Site_Code = TxtSite_Code.AgSelectedValue
            .SubCode = TxtVendor.AgSelectedValue
            .Narration = ""
            .ReferenceDocID = TxtIssueNo.AgSelectedValue
            .PaybleAmount = TxtNetAmount.Text
            .AdjustedAmount = 0
            .EntryBy = AgL.PubUserName
            .EntryDate = AgL.GetDateTime(AgL.GcnRead)
            .EntryType = Topctrl1.Mode
            .EntryStatus = LogStatus.LogOpen
            .IsDeleted = 0
            .Status = TxtStatus.Text
            .UID = mSearchCode
        End With
        Call ClsMain.ProcPostInDues(Conn, Cmd, StructDue)
    End Sub

    Private Sub FrmGeneralSubscription_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtPendingBooks.Enabled = False : TxtIssuedBooks.Enabled = False
    End Sub

    Private Sub FrmGeneralSubscription_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        'mQry = " SELECT H.DocID AS Code, H.V_Type + '-' + Convert(NVARCHAR,H.V_No) AS IssueNo, " & _
        '        " IsNull(H.IsDeleted ,0) AS IsDeleted, H.Div_Code, " & _
        '        " ISNULL(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status " & _
        '        " FROM Lib_BookIssue H " & _
        '        " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
        '        " Where Vt.Ncat = '" & ClsMain.Temp_NCat.BookIssueReceiveToBinder & "'"

        mQry = " SELECT L.DocId AS Code, Max(H.V_Type + '-' + Convert(NVARCHAR,H.V_No)) AS IssueNo, " & _
                " Count(L.Book_UID) AS TotalIssuedBooks, " & _
                " IsNull(Max(V1.TotalReceivedBooks),0) AS TotalReceivedBooks, " & _
                " Count(L.Book_UID) - IsNull(Max(V1.TotalReceivedBooks),0) As PendingBooks, " & _
                " IsNull(Max(H.Rate),0) AS Rate, " & _
                " Max(H.Vendor) As Vendor " & _
                " FROM Lib_BookIssueDetail L " & _
                " LEFT JOIN Lib_BookIssue H ON L.DocId = H.DocID " & _
                " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                " LEFT JOIN ( " & _
                " 	SELECT L1.DocId, Count(L1.Book_UID) AS TotalReceivedBooks " & _
                " 	FROM Lib_BookIssueDetail L1 " & _
                " 	WHERE L1.ReferenceDocId IS NOT NULL " & _
                " 	GROUP BY L1.DocId " & _
                " ) AS V1 ON L.DocId = v1.DocId " & _
                " WHERE Vt.NCat = '" & ClsMain.Temp_NCat.BookIssueReceiveToBinder & "' and " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & "" & _
                " GROUP BY L.DocId "
        TxtIssueNo.AgHelpDataSet(5, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Sg.SubCode AS Code, Sg.DispName AS Name  FROM Vendor H LEFT JOIN SubGroup Sg ON H.SubCode = Sg.SubCode " & _
               " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
        TxtVendor.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmGeneralSubscription_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
               " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select H.DocID As SearchCode " & _
            " From Bill H " & _
            " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
            " Where IsNull(H.IsDeleted,0) = 0  " & mCondStr & "  Order By H.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmGeneralSubscription_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = "Select H.UID As SearchCode " & _
               " From Bill_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where H.EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By H.EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmGeneralSubscription_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DtTemp As DataTable

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select * From Bill Where DocID = '" & SearchCode & "'"
        Else
            mQry = "Select * From Bill_Log Where UId = '" & SearchCode & "'"
        End If
        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
        With DtTemp
            If .Rows.Count > 0 Then
                TxtIssueNo.AgSelectedValue = AgL.XNull(.Rows(0)("ReferenceDocId"))
                TxtReceivedBooks.Text = AgL.VNull(.Rows(0)("ReceivedQty"))
                TxtIssuedBooks.Text = AgL.VNull(.Rows(0)("IssuedQty"))
                TxtPendingBooks.Text = AgL.VNull(.Rows(0)("PendingQty"))
                TxtAmount.Text = AgL.VNull(.Rows(0)("Amount"))
                TxtVendor.AgSelectedValue = AgL.XNull(.Rows(0)("Vendor"))
                TxtOtherCharges.Text = AgL.VNull(.Rows(0)("OtherCharges"))
                TxtDiscount.Text = AgL.VNull(.Rows(0)("Discount"))
                TxtNetAmount.Text = AgL.VNull(.Rows(0)("NetAmount"))
            End If
        End With
    End Sub

    Private Sub FrmGeneralSubscription_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.BringToFront()
        AgL.WinSetting(Me, 400, 885, 0, 0)
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtIssueNo.Enter
        Try
            Select Case sender.name
                Case TxtIssueNo.Name
                    sender.AgRowFilter = "  TotalReceivedBooks < TotalIssuedBooks And Vendor  = '" & TxtVendor.AgSelectedValue & "'"
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmTempRequisition_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        TxtNetAmount.Text = 0
        If Val(TxtAmount.Text) = 0 Then
            TxtAmount.Text = Val(LblIssueNo.Tag) * Val(TxtReceivedBooks.Text)
        End If
        TxtNetAmount.Text = Val(TxtAmount.Text) + Val(TxtOtherCharges.Text) - Val(TxtDiscount.Text)
    End Sub

    Private Sub TxtAmount_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtAmount.Validating, TxtAmount.Validating, TxtDiscount.Validating, TxtIssuedBooks.Validating, TxtIssueNo.Validating, TxtNetAmount.Validating, TxtOtherCharges.Validating, TxtReceivedBooks.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.Name
                Case TxtIssueNo.Name
                    If sender.Text <> "" Then
                        DrTemp = sender.AgHelpDataSet.Tables(0).Select(" Code = '" & TxtIssueNo.AgSelectedValue & "' ")
                        If DrTemp.Length > 0 Then
                            TxtIssuedBooks.Text = AgL.VNull(DrTemp(0)("TotalIssuedBooks"))
                            TxtPendingBooks.Text = AgL.VNull(DrTemp(0)("PendingBooks"))
                            TxtVendor.AgSelectedValue = AgL.XNull(DrTemp(0)("Vendor"))
                            LblIssueNo.Tag = AgL.VNull(DrTemp(0)("Rate"))
                        Else
                            TxtIssuedBooks.Text = 0
                            TxtPendingBooks.Text = 0
                            TxtVendor.AgSelectedValue = ""
                            LblIssueNo.Tag = 0
                        End If
                    End If
            End Select
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
