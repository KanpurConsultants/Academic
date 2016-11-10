Imports CrystalDecisions.CrystalReports.Engine
Public Class TempInvoice
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Public WithEvents AgCShowGrid1 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCShowGrid2 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid

    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Select As String = "Select"
    Protected Const Col1DueNo As String = "Due No"
    Protected Const Col1RefNo As String = "Refrence No"
    Protected Const Col1DueDate As String = "Due Date"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1DueAmt As String = "Due Amt"
    Protected Const Col1AdjustAmt As String = "Adjust Amt"
    Protected Const Col1BillAmount As String = "Bill Amount"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1BiltyNo As String = "Bilty No"
    Protected Const Col1RefVno As String = "Ref Vno"
    Protected Const Col1RefVtype As String = "Ref type"

    'Private components As System.ComponentModel.IContainer

    Dim mChallanTypeStr$ = ""
    Dim mTransactionType As TransactionType = TransactionType.Receipt
    Dim mDuesAmtFieldName As String = "ReceivableAmount"
    Dim mReferenceNCat$ = ""

    Enum TransactionType
        Receipt = 0
        Payment = 1
    End Enum

    Public Property ReferenceNCat() As String
        Get
            ReferenceNCat = mReferenceNCat
        End Get
        Set(ByVal value As String)
            mReferenceNCat = value
        End Set
    End Property

    Public Property TransType() As TransactionType
        Get
            Return mTransactionType
        End Get
        Set(ByVal value As TransactionType)
            mTransactionType = value
            mDuesAmtFieldName = IIf(TransType = TransactionType.Payment, "PaybleAmount", "ReceivableAmount")
        End Set
    End Property

    Public Property ChallanTypeStr() As String
        Get
            ChallanTypeStr = mChallanTypeStr
        End Get
        Set(ByVal value As String)
            mChallanTypeStr = value
        End Set
    End Property

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtParty = New AgControls.AgTextBox
        Me.LblPartyName = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblAmt = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblTotaAdjestamount = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.BtnFill = New System.Windows.Forms.Button
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.BtnImportDetails = New System.Windows.Forms.Button
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.TxtTodate = New AgControls.AgTextBox
        Me.LvlToDate = New System.Windows.Forms.Label
        Me.TxtFromDate = New AgControls.AgTextBox
        Me.LblFromDate = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TxtPartyCity = New AgControls.AgTextBox
        Me.TxtPartyAdd1 = New AgControls.AgTextBox
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
        Me.GroupBox2.Location = New System.Drawing.Point(830, 581)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 581)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 581)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(289, 581)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 581)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 577)
        Me.GroupBox1.Size = New System.Drawing.Size(1030, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(562, 581)
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
        Me.LblV_No.Location = New System.Drawing.Point(233, 29)
        Me.LblV_No.Size = New System.Drawing.Size(71, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Invoice No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(341, 28)
        Me.TxtV_No.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(111, 34)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(7, 29)
        Me.LblV_Date.Size = New System.Drawing.Size(78, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Invoice Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(311, 14)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(127, 28)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(233, 10)
        Me.LblV_Type.Size = New System.Drawing.Size(79, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Invoice Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(341, 8)
        Me.TxtV_Type.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(111, 14)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(7, 9)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(127, 8)
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
        Me.LblPrefix.Location = New System.Drawing.Point(293, 29)
        Me.LblPrefix.Tag = ""
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(2, 24)
        Me.TabControl1.Size = New System.Drawing.Size(1000, 142)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtPartyAdd1)
        Me.TP1.Controls.Add(Me.TxtPartyCity)
        Me.TP1.Controls.Add(Me.Label15)
        Me.TP1.Controls.Add(Me.Label12)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.TxtParty)
        Me.TP1.Controls.Add(Me.LblPartyName)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.TxtFromDate)
        Me.TP1.Controls.Add(Me.LblFromDate)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.TxtTodate)
        Me.TP1.Controls.Add(Me.LvlToDate)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.BtnFill)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(992, 116)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.BtnFill, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.LvlToDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTodate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblFromDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtFromDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPartyName, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label12, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label15, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyCity, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPartyAdd1, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(1012, 41)
        Me.Topctrl1.TabIndex = 3
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(111, 55)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 694
        Me.Label4.Text = "Ä"
        '
        'TxtParty
        '
        Me.TxtParty.AgMandatory = True
        Me.TxtParty.AgMasterHelp = False
        Me.TxtParty.AgNumberLeftPlaces = 8
        Me.TxtParty.AgNumberNegetiveAllow = False
        Me.TxtParty.AgNumberRightPlaces = 2
        Me.TxtParty.AgPickFromLastValue = False
        Me.TxtParty.AgRowFilter = ""
        Me.TxtParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtParty.AgSelectedValue = Nothing
        Me.TxtParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtParty.Location = New System.Drawing.Point(127, 48)
        Me.TxtParty.MaxLength = 0
        Me.TxtParty.Name = "TxtParty"
        Me.TxtParty.Size = New System.Drawing.Size(377, 18)
        Me.TxtParty.TabIndex = 4
        '
        'LblPartyName
        '
        Me.LblPartyName.AutoSize = True
        Me.LblPartyName.BackColor = System.Drawing.Color.Transparent
        Me.LblPartyName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPartyName.Location = New System.Drawing.Point(7, 48)
        Me.LblPartyName.Name = "LblPartyName"
        Me.LblPartyName.Size = New System.Drawing.Size(77, 16)
        Me.LblPartyName.TabIndex = 693
        Me.LblPartyName.Text = "Party Name"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblAmt)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.LblTotaAdjestamount)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Location = New System.Drawing.Point(6, 433)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblAmt
        '
        Me.LblAmt.AutoSize = True
        Me.LblAmt.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAmt.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblAmt.Location = New System.Drawing.Point(339, 3)
        Me.LblAmt.Name = "LblAmt"
        Me.LblAmt.Size = New System.Drawing.Size(12, 16)
        Me.LblAmt.TabIndex = 668
        Me.LblAmt.Text = "."
        Me.LblAmt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Maroon
        Me.Label1.Location = New System.Drawing.Point(203, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 16)
        Me.Label1.TabIndex = 667
        Me.Label1.Text = "Total Due Amount :"
        '
        'LblTotaAdjestamount
        '
        Me.LblTotaAdjestamount.AutoSize = True
        Me.LblTotaAdjestamount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotaAdjestamount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotaAdjestamount.Location = New System.Drawing.Point(635, 3)
        Me.LblTotaAdjestamount.Name = "LblTotaAdjestamount"
        Me.LblTotaAdjestamount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotaAdjestamount.TabIndex = 666
        Me.LblTotaAdjestamount.Text = "."
        Me.LblTotaAdjestamount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(469, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(160, 16)
        Me.Label33.TabIndex = 665
        Me.Label33.Text = "Total Adjusted Amount :"
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalQty.Location = New System.Drawing.Point(97, 3)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 660
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.AutoSize = True
        Me.LblTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalAmount.Location = New System.Drawing.Point(852, 3)
        Me.LblTotalAmount.Name = "LblTotalAmount"
        Me.LblTotalAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalAmount.TabIndex = 662
        Me.LblTotalAmount.Text = "."
        Me.LblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.AutoSize = True
        Me.LblTotalQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQtyText.Location = New System.Drawing.Point(12, 3)
        Me.LblTotalQtyText.Name = "LblTotalQtyText"
        Me.LblTotalQtyText.Size = New System.Drawing.Size(73, 16)
        Me.LblTotalQtyText.TabIndex = 659
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.AutoSize = True
        Me.LblTotalAmountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmountText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalAmountText.Location = New System.Drawing.Point(745, 3)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(101, 16)
        Me.LblTotalAmountText.TabIndex = 661
        Me.LblTotalAmountText.Text = "Total Amount :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(2, 188)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(1000, 239)
        Me.Pnl1.TabIndex = 1
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(644, 462)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(360, 115)
        Me.PnlCalcGrid.TabIndex = 2
        Me.PnlCalcGrid.Visible = False
        '
        'TxtStructure
        '
        Me.TxtStructure.AgMandatory = False
        Me.TxtStructure.AgMasterHelp = False
        Me.TxtStructure.AgNumberLeftPlaces = 8
        Me.TxtStructure.AgNumberNegetiveAllow = False
        Me.TxtStructure.AgNumberRightPlaces = 2
        Me.TxtStructure.AgPickFromLastValue = False
        Me.TxtStructure.AgRowFilter = ""
        Me.TxtStructure.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStructure.AgSelectedValue = Nothing
        Me.TxtStructure.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStructure.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStructure.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStructure.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStructure.Location = New System.Drawing.Point(886, 79)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(120, 18)
        Me.TxtStructure.TabIndex = 6
        Me.TxtStructure.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(788, 80)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 715
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
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
        Me.TxtRemarks.Location = New System.Drawing.Point(595, 31)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(337, 18)
        Me.TxtRemarks.TabIndex = 9
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(510, 31)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(595, 51)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(100, 18)
        Me.TxtReferenceNo.TabIndex = 10
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(510, 52)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(90, 16)
        Me.LblReferenceNo.TabIndex = 731
        Me.LblReferenceNo.Text = "Reference No."
        '
        'BtnFill
        '
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Location = New System.Drawing.Point(832, 50)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(100, 23)
        Me.BtnFill.TabIndex = 11
        Me.BtnFill.Text = "Fill"
        Me.BtnFill.UseVisualStyleBackColor = True
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(1, 165)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(230, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "GR Detail"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnImportDetails
        '
        Me.BtnImportDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImportDetails.Location = New System.Drawing.Point(4, 552)
        Me.BtnImportDetails.Name = "BtnImportDetails"
        Me.BtnImportDetails.Size = New System.Drawing.Size(98, 23)
        Me.BtnImportDetails.TabIndex = 737
        Me.BtnImportDetails.Text = "Import Details"
        Me.BtnImportDetails.UseVisualStyleBackColor = True
        Me.BtnImportDetails.Visible = False
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(193, 494)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(175, 30)
        Me.PnlCShowGrid2.TabIndex = 741
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(386, 494)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(151, 30)
        Me.PnlCShowGrid.TabIndex = 740
        '
        'TxtTodate
        '
        Me.TxtTodate.AgMandatory = False
        Me.TxtTodate.AgMasterHelp = True
        Me.TxtTodate.AgNumberLeftPlaces = 8
        Me.TxtTodate.AgNumberNegetiveAllow = False
        Me.TxtTodate.AgNumberRightPlaces = 2
        Me.TxtTodate.AgPickFromLastValue = False
        Me.TxtTodate.AgRowFilter = ""
        Me.TxtTodate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTodate.AgSelectedValue = Nothing
        Me.TxtTodate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTodate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtTodate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTodate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTodate.Location = New System.Drawing.Point(812, 11)
        Me.TxtTodate.MaxLength = 20
        Me.TxtTodate.Name = "TxtTodate"
        Me.TxtTodate.Size = New System.Drawing.Size(120, 18)
        Me.TxtTodate.TabIndex = 8
        '
        'LvlToDate
        '
        Me.LvlToDate.AutoSize = True
        Me.LvlToDate.BackColor = System.Drawing.Color.Transparent
        Me.LvlToDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvlToDate.Location = New System.Drawing.Point(714, 13)
        Me.LvlToDate.Name = "LvlToDate"
        Me.LvlToDate.Size = New System.Drawing.Size(53, 16)
        Me.LvlToDate.TabIndex = 708
        Me.LvlToDate.Text = "To Date"
        '
        'TxtFromDate
        '
        Me.TxtFromDate.AgMandatory = False
        Me.TxtFromDate.AgMasterHelp = False
        Me.TxtFromDate.AgNumberLeftPlaces = 8
        Me.TxtFromDate.AgNumberNegetiveAllow = False
        Me.TxtFromDate.AgNumberRightPlaces = 2
        Me.TxtFromDate.AgPickFromLastValue = False
        Me.TxtFromDate.AgRowFilter = ""
        Me.TxtFromDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFromDate.AgSelectedValue = Nothing
        Me.TxtFromDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFromDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtFromDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFromDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFromDate.Location = New System.Drawing.Point(595, 11)
        Me.TxtFromDate.MaxLength = 20
        Me.TxtFromDate.Name = "TxtFromDate"
        Me.TxtFromDate.Size = New System.Drawing.Size(100, 18)
        Me.TxtFromDate.TabIndex = 7
        '
        'LblFromDate
        '
        Me.LblFromDate.AutoSize = True
        Me.LblFromDate.BackColor = System.Drawing.Color.Transparent
        Me.LblFromDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFromDate.Location = New System.Drawing.Point(510, 11)
        Me.LblFromDate.Name = "LblFromDate"
        Me.LblFromDate.Size = New System.Drawing.Size(69, 16)
        Me.LblFromDate.TabIndex = 706
        Me.LblFromDate.Text = "From Date"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 69)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 735
        Me.Label15.Text = "Address"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(8, 89)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 13)
        Me.Label12.TabIndex = 734
        Me.Label12.Text = "City Name"
        '
        'TxtPartyCity
        '
        Me.TxtPartyCity.AgMandatory = False
        Me.TxtPartyCity.AgMasterHelp = True
        Me.TxtPartyCity.AgNumberLeftPlaces = 8
        Me.TxtPartyCity.AgNumberNegetiveAllow = False
        Me.TxtPartyCity.AgNumberRightPlaces = 2
        Me.TxtPartyCity.AgPickFromLastValue = False
        Me.TxtPartyCity.AgRowFilter = ""
        Me.TxtPartyCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPartyCity.AgSelectedValue = Nothing
        Me.TxtPartyCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPartyCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPartyCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartyCity.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartyCity.Location = New System.Drawing.Point(127, 88)
        Me.TxtPartyCity.MaxLength = 20
        Me.TxtPartyCity.Name = "TxtPartyCity"
        Me.TxtPartyCity.Size = New System.Drawing.Size(235, 18)
        Me.TxtPartyCity.TabIndex = 6
        '
        'TxtPartyAdd1
        '
        Me.TxtPartyAdd1.AgMandatory = False
        Me.TxtPartyAdd1.AgMasterHelp = True
        Me.TxtPartyAdd1.AgNumberLeftPlaces = 8
        Me.TxtPartyAdd1.AgNumberNegetiveAllow = False
        Me.TxtPartyAdd1.AgNumberRightPlaces = 2
        Me.TxtPartyAdd1.AgPickFromLastValue = False
        Me.TxtPartyAdd1.AgRowFilter = ""
        Me.TxtPartyAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPartyAdd1.AgSelectedValue = Nothing
        Me.TxtPartyAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPartyAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPartyAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPartyAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartyAdd1.Location = New System.Drawing.Point(127, 68)
        Me.TxtPartyAdd1.MaxLength = 20
        Me.TxtPartyAdd1.Name = "TxtPartyAdd1"
        Me.TxtPartyAdd1.Size = New System.Drawing.Size(377, 18)
        Me.TxtPartyAdd1.TabIndex = 5
        '
        'TempInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(1012, 622)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.BtnImportDetails)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "TempInvoice"
        Me.Text = "'"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.BtnImportDetails, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
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
    Protected WithEvents LblPartyName As System.Windows.Forms.Label
    Protected WithEvents TxtParty As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents LblTotaAdjestamount As System.Windows.Forms.Label
    Protected WithEvents Label33 As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents BtnImportDetails As System.Windows.Forms.Button
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtFromDate As AgControls.AgTextBox
    Protected WithEvents LblFromDate As System.Windows.Forms.Label
    Protected WithEvents TxtTodate As AgControls.AgTextBox
    Protected WithEvents LvlToDate As System.Windows.Forms.Label
    Protected WithEvents LblAmt As System.Windows.Forms.Label
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents Label15 As System.Windows.Forms.Label
    Protected WithEvents Label12 As System.Windows.Forms.Label
    Protected WithEvents TxtPartyAdd1 As AgControls.AgTextBox
    Protected WithEvents TxtPartyCity As AgControls.AgTextBox
#End Region

    Private Sub TempInvoice_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        Dim I As Integer
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1DueNo, I).Value <> "" Then
                    mQry = "UPDATE ToBeBilled " & _
                           " SET BilledAmount = (Select sum(Amount) as BilledAmount from GBillDetail where RefDocId= " & AgL.Chk_Text(Dgl1.Item(Col1BiltyNo, I).Value) & " ) " & _
                           " Where Docid = " & AgL.Chk_Text(Dgl1.Item(Col1BiltyNo, I).Value) & " "
                    AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
                End If
            Next
        End With
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Gbill"
        LogTableName = "Gbill_log"
        MainLineTableCsv = "GbillDetail,Structure_TransFooter,Structure_TransLine"
        LogLineTableCsv = "GbillDetail_log,Structure_TransFooter_Log,Structure_TransLine_Log"

        AgL.GridDesign(Dgl1)

        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)
        AgL.AddAgDataGrid(AgCShowGrid1, PnlCShowGrid)
        AgL.AddAgDataGrid(AgCShowGrid2, PnlCShowGrid2)
        AgCShowGrid1.Visible = False
        AgCShowGrid2.Visible = False


        AgCalcGrid1.AgLibVar = AgL
        'AgCalcGrid1.Visible = False


    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From GBill H " & _
        " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
        " Where IsNull(IsDeleted,0)=0  " & mCondStr & "  Order By V_Date Desc "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMastLog(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMastLog
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select UID As SearchCode " & _
               " From GBill_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT H.UID as SearchCode, Vt.Description AS [Entry Type], " & _
        '                    " H.V_Date AS [Entry Date], H.V_No AS [Entry No], " & _
        '                    " H.ReferenceNo, h.partyname As PartyName  " & _
        '                    " FROM GBill_log H " & _
        '                    " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
        '                 " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, H.V_Type AS [Invoice Type], H.V_Prefix AS [Prefix], H.V_Date AS Date, H.V_No AS [Invoice No], " & _
                " H.ReferenceNo AS [Manual No], H.PartyName AS [Party Name], H.PartyAddress AS [Party Address], C.CityName  AS [Party City], H.Structure,  " & _
                " H.FromDate AS [From Date], H.UptoDate AS [Upto Date], H.TotalAmount AS [Total Amount], H.PaidAmount AS [Paid Amount], H.Remark,  " & _
                " H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By],  " & _
                " H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log], H.MoveToLogDate AS [Move To Log Date], H.Status, " & _
                " D.Div_Name AS Division, SM.Name AS [Site Name] " & _
                " FROM  GBill H " & _
                " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
                " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
                " LEFT JOIN City C ON C.CityCode=H.PartyCity " & _
                " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT H.UID as SearchCode, Vt.Description AS [Entry Type], " & _
        '                    " H.V_Date AS [Entry Date], H.V_No AS [Entry No], " & _
        '                    " H.ReferenceNo, h.partyname As PartyName  " & _
        '                    " FROM GBill H " & _
        '                    " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
        '                    " Where 1=1 " & mCondStr

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, H.V_Type AS [Invoice Type], H.V_Prefix AS [Prefix], H.V_Date AS Date, H.V_No AS [Invoice No], " & _
                        " H.ReferenceNo AS [Manual No], H.PartyName AS [Party Name], H.PartyAddress AS [Party Address], C.CityName  AS [Party City], H.Structure,  " & _
                        " H.FromDate AS [From Date], H.UptoDate AS [Upto Date], H.TotalAmount AS [Total Amount], H.PaidAmount AS [Paid Amount], H.Remark,  " & _
                        " H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By],  " & _
                        " H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log], H.MoveToLogDate AS [Move To Log Date], H.Status, " & _
                        " D.Div_Name AS Division, SM.Name AS [Site Name] " & _
                        " FROM  GBill H " & _
                        " LEFT JOIN Division D ON D.Div_Code =H.Div_Code   " & _
                        " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code   " & _
                        " LEFT JOIN voucher_type Vt ON H.V_Type = vt.V_Type  " & _
                        " LEFT JOIN City C ON C.CityCode=H.PartyCity " & _
                        " Where 1=1 " & mCondStr

        AgL.PubFindQryOrdBy = "[Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgCheckColumn(Dgl1, Col1Select, 50, Col1Select, True)
            .AddAgTextColumn(Dgl1, Col1DueNo, 120, 0, Col1DueNo, True, True)
            .AddAgTextColumn(Dgl1, Col1RefNo, 120, 0, Col1RefNo, True, True)
            .AddAgTextColumn(Dgl1, Col1DueDate, 120, 0, Col1DueDate, True, True)
            .AddAgNumberColumn(Dgl1, Col1Qty, 80, 8, 4, False, Col1Qty, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1DueAmt, 100, 8, 2, False, Col1DueAmt, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1AdjustAmt, 100, 8, 2, False, Col1AdjustAmt, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1BillAmount, 100, 8, 2, False, Col1BillAmount, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, True, True, True)
            .AddAgTextColumn(Dgl1, Col1BiltyNo, 120, 0, Col1BiltyNo, False, True)
            .AddAgTextColumn(Dgl1, Col1RefVno, 120, 0, Col1RefVno, False, True)
            .AddAgTextColumn(Dgl1, Col1RefVtype, 120, 0, Col1RefVtype, False, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AllowUserToAddRows = False

        AgCalcGrid1.Ini_Grid(mSearchCode)
        AgCalcGrid1.AgFixedRows = 5
        AgCShowGrid1.AgIsFixedRows = True
        AgCShowGrid1.AgParentCalcGrid = AgCalcGrid1
        AgCShowGrid2.AgParentCalcGrid = AgCalcGrid1
        If AgCalcGrid1.RowCount > 0 Then
            AgCShowGrid1.Ini_Grid()
            AgCShowGrid2.Ini_Grid()
        End If

        AgCalcGrid1.AgLineGrid = Dgl1
        AgCalcGrid1.AgLineGridMandatoryColumn = Dgl1.Columns(Col1DueNo).Index
        AgCalcGrid1.AgLineGridGrossColumn = Dgl1.Columns(Col1Amount).Index
        'AgCalcGrid1.AgLineGridPostingGroupSalesTaxProd = Dgl1.Columns(Col1SalesTaxGroup).Index

        FrmSaleOrder_BaseFunction_FIniList()
        'Ini_List()
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer
        Dim StructDue As AgTemplate.ClsMain.Dues = Nothing

        mQry = " Update GBill_Log SET ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & "   ," & _
               " Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ",FromDate = " & AgL.Chk_Text(TxtFromDate.Text) & "," & _
               " UptoDate = " & AgL.Chk_Text(TxtTodate.Text) & " ,	TotalAmount = " & Val(LblTotalAmount.Text) & " ," & _
               " SubCode =" & AgL.Chk_Text(TxtParty.AgSelectedValue) & ",	PartyName = " & AgL.Chk_Text(TxtParty.Text) & " ," & _
               " PartyAddress =  " & AgL.Chk_Text(TxtPartyAdd1.Text) & ",	PartyCity =  " & AgL.Chk_Text(TxtPartyCity.AgSelectedValue) & ",remark=" & AgL.Chk_Text(TxtRemarks.Text) & " " & _
               " Where UID = '" & mSearchCode & "'"

        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        AgCalcGrid1.Save_TransFooter(mInternalCode, Conn, Cmd, SearchCode)

        mQry = "Delete From GBillDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1DueNo, I).Value <> "" And AgL.StrCmp(Dgl1.Item(Col1Select, I).Value, AgLibrary.ClsConstant.StrCheckedValue) Then
                mSr += 1
                mQry = "INSERT INTO GBillDetail_Log " & _
                       " (UID,DocID,Sr,RefDocId,RefDate,Qty,Amount,AdjustedAmount,BilledAmount,SubCode,DueAmount,RefV_Type,RefV_No,RefReferenceNo )" & _
                       " VALUES (" & AgL.Chk_Text(mSearchCode) & "," & AgL.Chk_Text(mInternalCode) & "," & mSr & ", " & _
                       " " & AgL.Chk_Text(Dgl1.Item(Col1BiltyNo, I).Value) & "," & AgL.Chk_Text(Dgl1.Item(Col1DueDate, I).Value) & ", " & _
                       "" & Val(Dgl1.Item(Col1Qty, I).Value) & "," & Val(Dgl1.Item(Col1Amount, I).Value) & "," & Val(Dgl1.Item(Col1AdjustAmt, I).Value) & " , " & _
                       "" & Val(Dgl1.Item(Col1BillAmount, I).Value) & "," & AgL.Chk_Text(TxtParty.AgSelectedValue) & "," & Val(Dgl1.Item(Col1DueAmt, I).Value) & "," & AgL.Chk_Text(Dgl1.Item(Col1RefVtype, I).Value) & "," & Val(Dgl1.Item(Col1RefVno, I).Value) & "," & AgL.Chk_Text(Dgl1.Item(Col1RefNo, I).Value) & " ) "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                AgCalcGrid1.Save_TransLine(mInternalCode, mSr, I, Conn, Cmd, SearchCode)
                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
            End If
        Next

        With StructDue
            .DocID = mInternalCode
            .Sr = 1
            .V_Type = TxtV_Type.AgSelectedValue
            .V_Prefix = LblPrefix.Text
            .V_Date = TxtV_Date.Text
            .V_No = Val(TxtV_No.Text)
            .Div_Code = TxtDivision.AgSelectedValue
            .Site_Code = TxtSite_Code.AgSelectedValue
            .SubCode = TxtParty.AgSelectedValue
            .Narration = ""
            .ReferenceDocID = mInternalCode
            .RefV_Type = TxtV_Type.AgSelectedValue
            .RefV_No = TxtV_No.Text
            .RefPartyName = TxtParty.Text
            .RefPartyAddress = TxtPartyAdd1.Text
            .RefPartyCity = TxtPartyCity.AgSelectedValue
            If mTransactionType = TransactionType.Receipt Then
                .ReceivableAmount = Val(AgCalcGrid1.AgChargesValue("Namt", AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))
            Else
                .PaybleAmount = Val(AgCalcGrid1.AgChargesValue("Namt", AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))
            End If
            .AdjustedAmount = "0"
            .EntryBy = AgL.PubUserName
            .EntryDate = AgL.GetDateTime(AgL.GcnRead)
            .EntryType = Topctrl1.Mode
            .EntryStatus = LogStatus.LogOpen
            .IsDeleted = 0
            .Status = TxtStatus.Text
            .UID = mSearchCode
        End With

        Call AgTemplate.ClsMain.ProcPostInDues(Conn, Cmd, StructDue)
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer

        Dim DsTemp As DataSet

        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From GBill H " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                " From GBill_Log H " & _
                " Where H.UID='" & SearchCode & "'"

        End If
        DsTemp = AgL.FillData(mQry, AgL.GCn)


        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)

                If AgL.XNull(.Rows(0)("Structure")) <> "" Then
                    TxtStructure.AgSelectedValue = AgL.XNull(.Rows(0)("Structure"))
                End If
                AgCalcGrid1.FrmType = Me.FrmType
                AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue

                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                TxtParty.AgSelectedValue = AgL.XNull(.Rows(0)("Subcode"))
                TxtFromDate.Text = AgL.XNull(.Rows(0)("FromDate"))
                TxtTodate.Text = AgL.XNull(.Rows(0)("UptoDate"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remark"))
                'LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))

                TxtPartyAdd1.Text = AgL.XNull(.Rows(0)("PartyAddress"))
                TxtPartyCity.AgSelectedValue = AgL.XNull(.Rows(0)("Partycity"))

                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))
                AgCalcGrid1.MoveRec_TransFooter(SearchCode)
                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------

                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select  * from GBillDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select  * from GBillDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count
                            Dgl1.Item(Col1Select, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                            Dgl1.Item(Col1DueNo, I).Value = AgL.XNull(.Rows(I)("RefV_Type")) & "-" & AgL.XNull(.Rows(I)("RefV_No"))
                            Dgl1.Item(Col1DueDate, I).Value = AgL.XNull(.Rows(I)("RefDate"))
                            Dgl1.Item(Col1RefVno, I).Value = AgL.XNull(.Rows(I)("RefV_No"))
                            Dgl1.Item(Col1RefVtype, I).Value = AgL.XNull(.Rows(I)("RefV_Type"))
                            Dgl1.Item(Col1RefNo, I).Value = AgL.XNull(.Rows(I)("RefReferenceNo"))

                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))

                            Dgl1.Item(Col1DueAmt, I).Value = Format(AgL.VNull(.Rows(I)("DueAmount")), "0.00")
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            Dgl1.Item(Col1BillAmount, I).Value = Format(AgL.VNull(.Rows(I)("BilledAmount")), "0.00")
                            Dgl1.Item(Col1AdjustAmt, I).Value = Format(AgL.VNull(.Rows(I)("AdjustedAmount")), "0.00")
                            'Dgl1.Item(Col1DueAmt, I).Value = Format(AgL.VNull(.Rows(I)("BillAmount")), "0.00")
                            Dgl1.Item(Col1BiltyNo, I).Value = AgL.XNull(.Rows(I)("RefDocId"))

                            Call AgCalcGrid1.MoveRec_TransLine(mSearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With
                Calculation()
                '-------------------------------------------------------------
            End If
        End With


    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgCalcGrid1.FrmType = Me.FrmType
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtParty.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    IniGrid()

                Case TxtParty.Name
                    If TxtV_Date.Text <> "" And TxtParty.Text <> "" Then
                        If sender.text.ToString.Trim = "" Or sender.AgSelectedValue.Trim = "" Then
                            TxtPartyAdd1.Text = ""
                            TxtPartyCity.Text = ""
                        Else
                            If sender.AgHelpDataSet IsNot Nothing Then
                                DrTemp = sender.AgHelpDataSet.Tables(0).Select("Code = " & AgL.Chk_Text(sender.AgSelectedValue) & "")

                                TxtPartyAdd1.Text = AgL.XNull(DrTemp(0)("Add1"))
                                TxtPartyCity.AgSelectedValue = AgL.XNull(DrTemp(0)("Citycode"))
                            End If
                        End If
                        ' If AgL.StrCmp(Topctrl1.Mode, "Add") Then Call ProcFillPendingChallans(TxtParty.AgSelectedValue, TxtV_Date.Text)
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        IniGrid()
        TabControl1.SelectedTab = TP1
        TxtPartyAdd1.Enabled = False
        TxtPartyCity.Enabled = False
        BtnFill.Enabled = True
        TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + TxtV_No.Text.ToString
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "SELECT Subgroup.subcode AS code,Subgroup.Dispname AS Party, Subgroup.Add1,C.CityName,Subgroup.CityCode FROM SubGroup LEFT JOIN City C ON Subgroup.CityCode = C.CityCode  WHERE Nature IN ('Customer','Supplier') ORDER BY Subgroup.Name  "
        TxtParty.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)


        mQry = "SELECT Code, Description  FROM Structure ORDER BY Description "
        TxtStructure.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT H.CityCode, H.Cityname as City, H.State, H.Country, IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') as Status, IsNull(H.IsDeleted,0) as IsDeleted  FROM City H ORDER BY cityname "
        TxtPartyCity.AgHelpDataSet(2, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)



    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try

            'If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
            '    Dgl1.Item(Col1Unit, mRow).Value = ""
            '    Dgl1.Item(Col1SalesTaxGroup, mRow).Value = ""
            '    Dgl1.Item(Col1MeasureUnit, mRow).Value = ""
            '    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = ""
            '    Dgl1.Item(Col1Rate, mRow).Value = ""
            '    Dgl1.Item(Col1DocQty, mRow).Value = ""
            'Else
            '    If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
            '        DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
            '        Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
            '        Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(DrTemp(0)("MeasureUnit"))
            '        Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.VNull(DrTemp(0)("MeasurePerPcs"))
            '        Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(DrTemp(0)("Rate"))
            '        'Dgl1.Item(Col1DocQty, mRow).Value = AgL.VNull(DrTemp(0)("PendingQty")) + Dgl1.Item(Col1PrevQty, mRow).Value
            '        Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
            '        If AgL.StrCmp(Dgl1.Item(Col1SalesTaxGroup, mRow).Value, "") Then
            '            Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
            '        End If

            '    End If
            'End If
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
                Case Col1BiltyNo
                    '   Validating_Item(Dgl1.AgSelectedValue(Col1Item, mRowIndex), mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0
        LblTotaAdjestamount.Text = 0
        LblTotalAmount.Text = 0
        LblAmt.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1BiltyNo, I).Value <> "" And AgL.StrCmp(Dgl1.Item(Col1Select, I).Value, AgLibrary.ClsConstant.StrCheckedValue) Then

                'Footer Calculation
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)

                LblTotaAdjestamount.Text = Val(LblTotaAdjestamount.Text) + Val(Dgl1.Item(Col1AdjustAmt, I).Value)
                LblAmt.Text = Val(LblAmt.Text) + Val(Dgl1.Item(Col1DueAmt, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
            End If
        Next
        AgCalcGrid1.Calculation()
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.00")
        LblTotaAdjestamount.Text = Format(Val(LblTotaAdjestamount.Text), "0.00")
        LblTotalAmount.Text = Format(Val(LblTotalAmount.Text), "0.00")
        LblAmt.Text = Format(Val(LblAmt.Text), "0.00")
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgL.RequiredField(TxtParty, LblPartyName.Text) Then passed = False : Exit Sub

        If TxtTodate.Text <> "" Then
            If CDate(TxtTodate.Text) > CDate(TxtV_Date.Text) Then
                MsgBox("To  date can't be greater than Bill date", MsgBoxStyle.Information)
                TxtV_Date.Focus()
                passed = False : Exit Sub
            End If
        End If

        'If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub

        'With Dgl1
        '    For I = 0 To .Rows.Count - 1
        '        If .Item(Col1Item, I).Value <> "" Then
        '            If Val(.Item(Col1Qty, I).Value) = 0 Then
        '                MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
        '                .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
        '                passed = False : Exit Sub
        '            End If

        '            If Val(.Item(Col1Rate, I).Value) = 0 Then
        '                MsgBox("Rate Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
        '                .CurrentCell = .Item(Col1Rate, I) : Dgl1.Focus()
        '                passed = False : Exit Sub
        '            End If
        '        End If
        '    Next
        'End With
    End Sub

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Select Case sender.name

        End Select
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()

    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            '  Case Col1Item
            '     Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " (IsDeleted = 0 And Status <= '" & AgTemplate.ClsMain.EntryStatus.Active & "' And PendingQty  > 0 Or Code = '" & Dgl1.AgSelectedValue(Col1Item, Dgl1.CurrentCell.RowIndex) & "') "
        End Select
    End Sub

    Private Sub TempGr_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer
        'Dim DtTemp As DataTable = Nothing
        '------------------------------------------------------------------------
        'Updating Goods Received Qty In Purchase Order Detail
        '-------------------------------------------------------------------------
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1DueNo, I).Value <> "" Then
                    mQry = "UPDATE ToBeBilled " & _
                            " SET BilledAmount = (Select sum(Amount) as BilledAmount from GBillDetail where RefDocId= " & AgL.Chk_Text(Dgl1.Item(Col1BiltyNo, I).Value) & " ) " & _
                             " Where docid= " & AgL.Chk_Text(Dgl1.Item(Col1BiltyNo, I).Value) & " "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)



                End If
            Next
        End With
        '-------------------------------------------------------------------------
    End Sub

    Private Sub ProcFillItems()
        Dim I As Integer = 0
        Dim DtTemp As DataTable = Nothing
        Dim mCondStr As String
        Try
            mcondstr = "where 1=1 AND H.subcode=" & AgL.Chk_Text(TxtParty.AgSelectedValue) & " "
            If TxtFromDate.Text <> "" And TxtTodate.Text <> "" Then
                mcondstr = mcondstr & " AND H.V_Date Between " & AgL.ConvertDate(TxtFromDate.Text) & " And " & AgL.ConvertDate(TxtTodate.Text) & " "
            ElseIf TxtFromDate.Text <> "" And TxtTodate.Text = "" Then
                mcondstr = mcondstr & " AND H.V_Date >= " & AgL.ConvertDate(TxtFromDate.Text) & "  "
            ElseIf TxtFromDate.Text = "" And TxtTodate.Text <> "" Then
                mcondstr = mcondstr & " AND H.V_Date <= " & AgL.ConvertDate(TxtTodate.Text) & "  "
            End If
            mcondstr = mcondstr & "  and isnull(H." & mDuesAmtFieldName & ",0)-isnull(H.AdjustedAmount,0)-isnull(H.BilledAmount,0)>0   "

            If mReferenceNCat <> "" Then
                mCondStr &= " And Vt.NCat = '" & mReferenceNCat & "' "
            End If

            If mcondstr = "" Then Exit Sub

            mQry = "SELECT H.DocId, H.V_no,H.V_Type,H.ReferenceNo ,H.v_date ,  " & _
                    " H.TotalQty,H.AdjustedAmount AS TotalAdjustedAmount,H." & mDuesAmtFieldName & ", " & _
                    " H.BilledAmount " & _
                    " FROM ToBeBilled H  " & _
                    " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & mCondStr
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count
                        Dgl1.Item(Col1Select, I).Value = AgLibrary.ClsConstant.StrCheckedValue
                        Dgl1.Item(Col1DueNo, I).Value = AgL.XNull(.Rows(I)("v_Type")) & "-" & AgL.XNull(.Rows(I)("V_no"))
                        Dgl1.Item(Col1RefNo, I).Value = AgL.XNull(.Rows(I)("ReferenceNo"))
                        Dgl1.Item(Col1RefVno, I).Value = AgL.XNull(.Rows(I)("V_no"))
                        Dgl1.Item(Col1RefVtype, I).Value = AgL.XNull(.Rows(I)("v_Type"))

                        Dgl1.Item(Col1BiltyNo, I).Value = AgL.XNull(.Rows(I)("Docid"))
                        Dgl1.Item(Col1DueDate, I).Value = AgL.XNull(.Rows(I)("v_date"))
                        Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("TotalQty"))
                        Dgl1.Item(Col1DueAmt, I).Value = Format(AgL.VNull(.Rows(I)(mDuesAmtFieldName)), "0.00")

                        Dgl1.Item(Col1BillAmount, I).Value = Format(AgL.VNull(.Rows(I)("BilledAmount")), "0.00")

                        Dgl1.Item(Col1AdjustAmt, I).Value = Format(AgL.VNull(.Rows(I)("TotalAdjustedAmount")), "0.00")
                        Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)(mDuesAmtFieldName)), "0.00") - Format(AgL.VNull(.Rows(I)("TotalAdjustedAmount")), "0.00") - Format(AgL.VNull(.Rows(I)("BilledAmount")), "0.00")

                        'AgCalcGrid1.FCopyStructureLine(AgL.XNull(.Rows(I)("PurchChallan")), Dgl1, I, AgL.VNull(.Rows(I)("Sr")))
                    Next I
                End If
            End With
            'FrmSaleOrder_BaseFunction_Calculation()
            'AgCalcGrid1.Calculation(True)
            Calculation()
            'If Dgl1.Item(Col1PurchChallan, 0).Value <> "" Then Dgl1.Columns(Col1Item).ReadOnly = True
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        Dim I As Integer = 0
        Dim bChallanStr$ = ""
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        Call ProcFillItems()
    End Sub

    Private Sub TempPurchInvoice_BaseFunction_DispText() Handles Me.BaseFunction_DispText

    End Sub

    Private Sub AgCalcGrid1_Calculated() Handles AgCalcGrid1.Calculated
        AgCShowGrid1.MoveRec_FromCalcGrid()
        AgCShowGrid2.MoveRec_FromCalcGrid()
    End Sub

    Private Sub ME_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        TxtParty.Enabled = False
        TxtFromDate.Enabled = False
        TxtTodate.Enabled = False
        BtnFill.Enabled = False
        TxtPartyAdd1.Enabled = False
        TxtPartyCity.Enabled = False
    End Sub

    Private Sub ME_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
    End Sub

    Private Sub TxtPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtPartyCity.Enter
        Select Case sender.name
            Case TxtPartyCity.Name
                CType(sender, AgControls.AgTextBox).AgRowFilter = " Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' And IsDeleted=0 "
        End Select
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
        Try
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col1Select
                    If e.KeyCode = Keys.Space Then
                        Try
                            AgL.ProcSetCheckColumnCellValue(sender, sender.Columns(Col1Select).Index)
                        Catch ex As Exception
                        End Try
                    End If
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DGL1_CellMouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles Dgl1.CellMouseUp
        If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer

        Try
            mRowIndex = sender.CurrentCell.RowIndex
            mColumnIndex = sender.CurrentCell.ColumnIndex

            If sender.Item(mColumnIndex, mRowIndex).Value Is Nothing Then sender.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case sender.Columns(sender.CurrentCell.ColumnIndex).Name
                Case Col1Select
                    Try
                        AgL.ProcSetCheckColumnCellValue(sender, sender.Columns(Col1Select).Index)
                    Catch ex As Exception
                    End Try
            End Select
            Calculation()
        Catch ex As Exception
        End Try
    End Sub
End Class
