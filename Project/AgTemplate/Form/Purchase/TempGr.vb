Imports CrystalDecisions.CrystalReports.Engine
Public Class TempGr
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    'Dim mLastKeyPressed As Keys
    Public WithEvents AgCShowGrid1 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCShowGrid2 As New AgStructure.AgCalcShowGrid
    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid

    Public WithEvents Dgl1 As AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Item As String = "Item"
    Protected Const Col1PurchOrder As String = "Purch Order"
    Protected Const Col1LotNo As String = "Lot No"
    Protected Const Col1SalesTaxGroup As String = "Sales Tax Group Item"
    Protected Const Col1DocQty As String = "Doc Qty"
    Protected Const Col1RejQty As String = "Rejected Qty"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1PrevQty As String = "Prev Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1MeasureUnit As String = "Measure Unit"
    Protected Const Col1TotalDocMeasure As String = "Total Doc Measure"
    Protected Const Col1TotalRejMeasure As String = "Total Rej Measure"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1InvoicedQty As String = "Invoiced Qty"
    Protected Const Col1InvoicedMeasure As String = "Invoiced Measure"
    Protected Const Col1PrevItem As String = "Prev Item"
    Protected Const Col1PrevPurchOrder As String = "Prev Purch Order"
    Protected Const Col1Remark As String = "Remark"

    Public Class HelpDataSet
        Public Shared Vendor As DataSet = Nothing
        Public Shared Currency As DataSet = Nothing
        Public Shared AgStructure As DataSet = Nothing
        Public Shared SalesTaxGroupParty As DataSet = Nothing
        Public Shared BillingType As DataSet = Nothing
        Public Shared PurchOrder As DataSet = Nothing
        Public Shared Godown As DataSet = Nothing
        Public Shared Form As DataSet = Nothing
        Public Shared Transporter As DataSet = Nothing
        Public Shared FormNo As DataSet = Nothing
        Public Shared Item As DataSet = Nothing
        Public Shared PurchOrderItem As DataSet = Nothing
        Public Shared GateEntry As DataSet = Nothing
    End Class

    Dim mIsPostStock As Boolean = True

    Protected Property IsPostStock() As Boolean
        Get
            IsPostStock = mIsPostStock
        End Get
        Set(ByVal value As Boolean)
            mIsPostStock = value
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
        Me.TxtVendor = New AgControls.AgTextBox
        Me.LblVendor = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalMeasure = New System.Windows.Forms.Label
        Me.Label33 = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtSalesTaxGroupParty = New AgControls.AgTextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtBillingType = New AgControls.AgTextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LblTransport = New System.Windows.Forms.Label
        Me.TxtTransport = New AgControls.AgTextBox
        Me.LblVendorDocNo = New System.Windows.Forms.Label
        Me.TxtVendorDocNo = New AgControls.AgTextBox
        Me.LvlVendorDocDate = New System.Windows.Forms.Label
        Me.TxtVendorDocDate = New AgControls.AgTextBox
        Me.LblCurrency = New System.Windows.Forms.Label
        Me.TxtCurrency = New AgControls.AgTextBox
        Me.TxtGodown = New AgControls.AgTextBox
        Me.LblGodown = New System.Windows.Forms.Label
        Me.LblOrderNo = New System.Windows.Forms.Label
        Me.TxtPurchOrder = New AgControls.AgTextBox
        Me.BtnFill = New System.Windows.Forms.Button
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.TxtGateEntryNo = New AgControls.AgTextBox
        Me.LblGateEntryNo = New System.Windows.Forms.Label
        Me.TxtTruckNo = New AgControls.AgTextBox
        Me.LblTruckNo = New System.Windows.Forms.Label
        Me.TxtForm = New AgControls.AgTextBox
        Me.LblForm = New System.Windows.Forms.Label
        Me.TxtFormNo = New AgControls.AgTextBox
        Me.LblFormNo = New System.Windows.Forms.Label
        Me.TxtTransporter = New AgControls.AgTextBox
        Me.LblTransporter = New System.Windows.Forms.Label
        Me.BtnRemoveFilter = New System.Windows.Forms.Button
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtLrNo = New AgControls.AgTextBox
        Me.LblLrNo = New System.Windows.Forms.Label
        Me.TxtLrDate = New AgControls.AgTextBox
        Me.LblLrDate = New System.Windows.Forms.Label
        Me.RbtChallanDirect = New System.Windows.Forms.RadioButton
        Me.RbtChallanForOrder = New System.Windows.Forms.RadioButton
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
        Me.GroupBox2.Location = New System.Drawing.Point(830, 558)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 558)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(466, 558)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(289, 558)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 558)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 554)
        Me.GroupBox1.Size = New System.Drawing.Size(1030, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(562, 558)
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
        Me.LblV_No.Size = New System.Drawing.Size(76, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Receipt No."
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
        Me.LblV_Date.Location = New System.Drawing.Point(15, 29)
        Me.LblV_Date.Size = New System.Drawing.Size(83, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Receipt Date"
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
        Me.LblV_Type.Size = New System.Drawing.Size(83, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Receipt Type"
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
        Me.LblSite_Code.Location = New System.Drawing.Point(15, 9)
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
        Me.TabControl1.Location = New System.Drawing.Point(4, 41)
        Me.TabControl1.Size = New System.Drawing.Size(1000, 139)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.RbtChallanDirect)
        Me.TP1.Controls.Add(Me.RbtChallanForOrder)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.TxtVendorDocNo)
        Me.TP1.Controls.Add(Me.LblVendorDocNo)
        Me.TP1.Controls.Add(Me.TxtGodown)
        Me.TP1.Controls.Add(Me.LblGodown)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.TxtBillingType)
        Me.TP1.Controls.Add(Me.Label32)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.Label30)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.TxtVendorDocDate)
        Me.TP1.Controls.Add(Me.TxtPurchOrder)
        Me.TP1.Controls.Add(Me.LvlVendorDocDate)
        Me.TP1.Controls.Add(Me.LblOrderNo)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.TxtTransport)
        Me.TP1.Controls.Add(Me.TxtVendor)
        Me.TP1.Controls.Add(Me.LblTransport)
        Me.TP1.Controls.Add(Me.LblVendor)
        Me.TP1.Controls.Add(Me.TxtCurrency)
        Me.TP1.Controls.Add(Me.LblCurrency)
        Me.TP1.Controls.Add(Me.BtnFill)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(992, 113)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.BtnFill, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTransport, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtTransport, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LvlVendorDocDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPurchOrder, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorDocDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label30, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label32, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBillingType, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendorDocNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorDocNo, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.RbtChallanForOrder, 0)
        Me.TP1.Controls.SetChildIndex(Me.RbtChallanDirect, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(1012, 41)
        Me.Topctrl1.TabIndex = 8
        '
        'Dgl1
        '
        Me.Dgl1.AgLastColumn = -1
        Me.Dgl1.AgMandatoryColumn = 0
        Me.Dgl1.AgReadOnlyColumnColor = System.Drawing.Color.Ivory
        Me.Dgl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Dgl1.AgSkipReadOnlyColumns = False
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
        Me.TxtVendor.Location = New System.Drawing.Point(127, 48)
        Me.TxtVendor.MaxLength = 0
        Me.TxtVendor.Name = "TxtVendor"
        Me.TxtVendor.Size = New System.Drawing.Size(377, 18)
        Me.TxtVendor.TabIndex = 4
        '
        'LblVendor
        '
        Me.LblVendor.AutoSize = True
        Me.LblVendor.BackColor = System.Drawing.Color.Transparent
        Me.LblVendor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendor.Location = New System.Drawing.Point(15, 48)
        Me.LblVendor.Name = "LblVendor"
        Me.LblVendor.Size = New System.Drawing.Size(48, 16)
        Me.LblVendor.TabIndex = 693
        Me.LblVendor.Text = "Vendor"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalMeasure)
        Me.Panel1.Controls.Add(Me.Label33)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Location = New System.Drawing.Point(4, 377)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1000, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.AutoSize = True
        Me.LblTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalMeasure.Location = New System.Drawing.Point(865, 3)
        Me.LblTotalMeasure.Name = "LblTotalMeasure"
        Me.LblTotalMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalMeasure.TabIndex = 666
        Me.LblTotalMeasure.Text = "."
        Me.LblTotalMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.LblTotalMeasure.Visible = False
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.ForeColor = System.Drawing.Color.Maroon
        Me.Label33.Location = New System.Drawing.Point(754, 3)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(105, 16)
        Me.Label33.TabIndex = 665
        Me.Label33.Text = "Total Measure :"
        Me.Label33.Visible = False
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
        Me.LblTotalAmount.Location = New System.Drawing.Point(465, 4)
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
        Me.LblTotalQtyText.Size = New System.Drawing.Size(72, 16)
        Me.LblTotalQtyText.TabIndex = 659
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.AutoSize = True
        Me.LblTotalAmountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmountText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalAmountText.Location = New System.Drawing.Point(361, 3)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(100, 16)
        Me.LblTotalAmountText.TabIndex = 661
        Me.LblTotalAmountText.Text = "Total Amount :"
        '
        'Pnl1
        '
        Me.Pnl1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Pnl1.Location = New System.Drawing.Point(4, 207)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(1000, 170)
        Me.Pnl1.TabIndex = 1
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.PnlCalcGrid.Location = New System.Drawing.Point(859, 407)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(145, 144)
        Me.PnlCalcGrid.TabIndex = 694
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
        Me.TxtStructure.Location = New System.Drawing.Point(894, 87)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(79, 18)
        Me.TxtStructure.TabIndex = 14
        Me.TxtStructure.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(827, 87)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 715
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.AgMandatory = False
        Me.TxtSalesTaxGroupParty.AgMasterHelp = False
        Me.TxtSalesTaxGroupParty.AgNumberLeftPlaces = 8
        Me.TxtSalesTaxGroupParty.AgNumberNegetiveAllow = False
        Me.TxtSalesTaxGroupParty.AgNumberRightPlaces = 2
        Me.TxtSalesTaxGroupParty.AgPickFromLastValue = False
        Me.TxtSalesTaxGroupParty.AgRowFilter = ""
        Me.TxtSalesTaxGroupParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSalesTaxGroupParty.AgSelectedValue = Nothing
        Me.TxtSalesTaxGroupParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSalesTaxGroupParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSalesTaxGroupParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSalesTaxGroupParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(121, 485)
        Me.TxtSalesTaxGroupParty.MaxLength = 20
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(238, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 3
        Me.TxtSalesTaxGroupParty.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(9, 485)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(104, 16)
        Me.Label27.TabIndex = 717
        Me.Label27.Text = "Sales Tax Group"
        Me.Label27.Visible = False
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
        Me.TxtRemarks.Location = New System.Drawing.Point(628, 67)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(345, 18)
        Me.TxtRemarks.TabIndex = 13
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(512, 68)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
        '
        'TxtBillingType
        '
        Me.TxtBillingType.AgMandatory = False
        Me.TxtBillingType.AgMasterHelp = False
        Me.TxtBillingType.AgNumberLeftPlaces = 0
        Me.TxtBillingType.AgNumberNegetiveAllow = False
        Me.TxtBillingType.AgNumberRightPlaces = 0
        Me.TxtBillingType.AgPickFromLastValue = False
        Me.TxtBillingType.AgRowFilter = ""
        Me.TxtBillingType.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBillingType.AgSelectedValue = Nothing
        Me.TxtBillingType.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBillingType.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBillingType.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBillingType.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBillingType.Location = New System.Drawing.Point(628, 87)
        Me.TxtBillingType.MaxLength = 20
        Me.TxtBillingType.Name = "TxtBillingType"
        Me.TxtBillingType.Size = New System.Drawing.Size(36, 18)
        Me.TxtBillingType.TabIndex = 13
        Me.TxtBillingType.Visible = False
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(512, 87)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(64, 16)
        Me.Label32.TabIndex = 727
        Me.Label32.Text = "Billing On"
        Me.Label32.Visible = False
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.AgMandatory = True
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(127, 68)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(129, 18)
        Me.TxtReferenceNo.TabIndex = 5
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(15, 68)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(97, 16)
        Me.LblReferenceNo.TabIndex = 731
        Me.LblReferenceNo.Text = "Manual GR No."
        '
        'LblTransport
        '
        Me.LblTransport.AutoSize = True
        Me.LblTransport.BackColor = System.Drawing.Color.Transparent
        Me.LblTransport.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTransport.Location = New System.Drawing.Point(512, 27)
        Me.LblTransport.Name = "LblTransport"
        Me.LblTransport.Size = New System.Drawing.Size(62, 16)
        Me.LblTransport.TabIndex = 729
        Me.LblTransport.Text = "Transport"
        '
        'TxtTransport
        '
        Me.TxtTransport.AgMandatory = False
        Me.TxtTransport.AgMasterHelp = False
        Me.TxtTransport.AgNumberLeftPlaces = 8
        Me.TxtTransport.AgNumberNegetiveAllow = False
        Me.TxtTransport.AgNumberRightPlaces = 2
        Me.TxtTransport.AgPickFromLastValue = False
        Me.TxtTransport.AgRowFilter = ""
        Me.TxtTransport.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTransport.AgSelectedValue = Nothing
        Me.TxtTransport.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTransport.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTransport.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTransport.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransport.Location = New System.Drawing.Point(628, 27)
        Me.TxtTransport.MaxLength = 50
        Me.TxtTransport.Name = "TxtTransport"
        Me.TxtTransport.Size = New System.Drawing.Size(116, 18)
        Me.TxtTransport.TabIndex = 10
        '
        'LblVendorDocNo
        '
        Me.LblVendorDocNo.AutoSize = True
        Me.LblVendorDocNo.BackColor = System.Drawing.Color.Transparent
        Me.LblVendorDocNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendorDocNo.Location = New System.Drawing.Point(512, 7)
        Me.LblVendorDocNo.Name = "LblVendorDocNo"
        Me.LblVendorDocNo.Size = New System.Drawing.Size(99, 16)
        Me.LblVendorDocNo.TabIndex = 706
        Me.LblVendorDocNo.Text = "Vendor Doc No."
        '
        'TxtVendorDocNo
        '
        Me.TxtVendorDocNo.AgMandatory = False
        Me.TxtVendorDocNo.AgMasterHelp = True
        Me.TxtVendorDocNo.AgNumberLeftPlaces = 8
        Me.TxtVendorDocNo.AgNumberNegetiveAllow = False
        Me.TxtVendorDocNo.AgNumberRightPlaces = 2
        Me.TxtVendorDocNo.AgPickFromLastValue = False
        Me.TxtVendorDocNo.AgRowFilter = ""
        Me.TxtVendorDocNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendorDocNo.AgSelectedValue = Nothing
        Me.TxtVendorDocNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendorDocNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVendorDocNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendorDocNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendorDocNo.Location = New System.Drawing.Point(628, 7)
        Me.TxtVendorDocNo.MaxLength = 20
        Me.TxtVendorDocNo.Name = "TxtVendorDocNo"
        Me.TxtVendorDocNo.Size = New System.Drawing.Size(116, 18)
        Me.TxtVendorDocNo.TabIndex = 8
        '
        'LvlVendorDocDate
        '
        Me.LvlVendorDocDate.AutoSize = True
        Me.LvlVendorDocDate.BackColor = System.Drawing.Color.Transparent
        Me.LvlVendorDocDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvlVendorDocDate.Location = New System.Drawing.Point(751, 7)
        Me.LvlVendorDocDate.Name = "LvlVendorDocDate"
        Me.LvlVendorDocDate.Size = New System.Drawing.Size(96, 16)
        Me.LvlVendorDocDate.TabIndex = 708
        Me.LvlVendorDocDate.Text = "Vendor Doc Dt."
        '
        'TxtVendorDocDate
        '
        Me.TxtVendorDocDate.AgMandatory = False
        Me.TxtVendorDocDate.AgMasterHelp = True
        Me.TxtVendorDocDate.AgNumberLeftPlaces = 8
        Me.TxtVendorDocDate.AgNumberNegetiveAllow = False
        Me.TxtVendorDocDate.AgNumberRightPlaces = 2
        Me.TxtVendorDocDate.AgPickFromLastValue = False
        Me.TxtVendorDocDate.AgRowFilter = ""
        Me.TxtVendorDocDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendorDocDate.AgSelectedValue = Nothing
        Me.TxtVendorDocDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendorDocDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtVendorDocDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendorDocDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendorDocDate.Location = New System.Drawing.Point(853, 7)
        Me.TxtVendorDocDate.MaxLength = 20
        Me.TxtVendorDocDate.Name = "TxtVendorDocDate"
        Me.TxtVendorDocDate.Size = New System.Drawing.Size(120, 18)
        Me.TxtVendorDocDate.TabIndex = 9
        '
        'LblCurrency
        '
        Me.LblCurrency.AutoSize = True
        Me.LblCurrency.BackColor = System.Drawing.Color.Transparent
        Me.LblCurrency.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrency.Location = New System.Drawing.Point(751, 28)
        Me.LblCurrency.Name = "LblCurrency"
        Me.LblCurrency.Size = New System.Drawing.Size(60, 16)
        Me.LblCurrency.TabIndex = 735
        Me.LblCurrency.Text = "Currency"
        '
        'TxtCurrency
        '
        Me.TxtCurrency.AgMandatory = False
        Me.TxtCurrency.AgMasterHelp = False
        Me.TxtCurrency.AgNumberLeftPlaces = 8
        Me.TxtCurrency.AgNumberNegetiveAllow = False
        Me.TxtCurrency.AgNumberRightPlaces = 2
        Me.TxtCurrency.AgPickFromLastValue = False
        Me.TxtCurrency.AgRowFilter = ""
        Me.TxtCurrency.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCurrency.AgSelectedValue = Nothing
        Me.TxtCurrency.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCurrency.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCurrency.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCurrency.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrency.Location = New System.Drawing.Point(853, 27)
        Me.TxtCurrency.MaxLength = 20
        Me.TxtCurrency.Name = "TxtCurrency"
        Me.TxtCurrency.Size = New System.Drawing.Size(120, 18)
        Me.TxtCurrency.TabIndex = 11
        '
        'TxtGodown
        '
        Me.TxtGodown.AgMandatory = False
        Me.TxtGodown.AgMasterHelp = False
        Me.TxtGodown.AgNumberLeftPlaces = 8
        Me.TxtGodown.AgNumberNegetiveAllow = False
        Me.TxtGodown.AgNumberRightPlaces = 2
        Me.TxtGodown.AgPickFromLastValue = False
        Me.TxtGodown.AgRowFilter = ""
        Me.TxtGodown.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGodown.AgSelectedValue = Nothing
        Me.TxtGodown.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGodown.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGodown.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGodown.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGodown.Location = New System.Drawing.Point(628, 47)
        Me.TxtGodown.MaxLength = 0
        Me.TxtGodown.Name = "TxtGodown"
        Me.TxtGodown.Size = New System.Drawing.Size(345, 18)
        Me.TxtGodown.TabIndex = 12
        '
        'LblGodown
        '
        Me.LblGodown.AutoSize = True
        Me.LblGodown.BackColor = System.Drawing.Color.Transparent
        Me.LblGodown.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGodown.Location = New System.Drawing.Point(512, 47)
        Me.LblGodown.Name = "LblGodown"
        Me.LblGodown.Size = New System.Drawing.Size(55, 16)
        Me.LblGodown.TabIndex = 737
        Me.LblGodown.Text = "Godown"
        '
        'LblOrderNo
        '
        Me.LblOrderNo.AutoSize = True
        Me.LblOrderNo.BackColor = System.Drawing.Color.Transparent
        Me.LblOrderNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOrderNo.Location = New System.Drawing.Point(260, 69)
        Me.LblOrderNo.Name = "LblOrderNo"
        Me.LblOrderNo.Size = New System.Drawing.Size(64, 16)
        Me.LblOrderNo.TabIndex = 733
        Me.LblOrderNo.Text = "Order No."
        '
        'TxtPurchOrder
        '
        Me.TxtPurchOrder.AgMandatory = False
        Me.TxtPurchOrder.AgMasterHelp = False
        Me.TxtPurchOrder.AgNumberLeftPlaces = 8
        Me.TxtPurchOrder.AgNumberNegetiveAllow = False
        Me.TxtPurchOrder.AgNumberRightPlaces = 2
        Me.TxtPurchOrder.AgPickFromLastValue = False
        Me.TxtPurchOrder.AgRowFilter = ""
        Me.TxtPurchOrder.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPurchOrder.AgSelectedValue = Nothing
        Me.TxtPurchOrder.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPurchOrder.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPurchOrder.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPurchOrder.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPurchOrder.Location = New System.Drawing.Point(328, 68)
        Me.TxtPurchOrder.MaxLength = 20
        Me.TxtPurchOrder.Name = "TxtPurchOrder"
        Me.TxtPurchOrder.Size = New System.Drawing.Size(125, 18)
        Me.TxtPurchOrder.TabIndex = 6
        '
        'BtnFill
        '
        Me.BtnFill.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnFill.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFill.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.BtnFill.Location = New System.Drawing.Point(456, 69)
        Me.BtnFill.Name = "BtnFill"
        Me.BtnFill.Size = New System.Drawing.Size(48, 22)
        Me.BtnFill.TabIndex = 7
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
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 186)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(230, 20)
        Me.LinkLabel1.TabIndex = 738
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Purchase Challan For Following Items"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TxtGateEntryNo
        '
        Me.TxtGateEntryNo.AgMandatory = False
        Me.TxtGateEntryNo.AgMasterHelp = True
        Me.TxtGateEntryNo.AgNumberLeftPlaces = 8
        Me.TxtGateEntryNo.AgNumberNegetiveAllow = False
        Me.TxtGateEntryNo.AgNumberRightPlaces = 2
        Me.TxtGateEntryNo.AgPickFromLastValue = False
        Me.TxtGateEntryNo.AgRowFilter = ""
        Me.TxtGateEntryNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGateEntryNo.AgSelectedValue = Nothing
        Me.TxtGateEntryNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGateEntryNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGateEntryNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGateEntryNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGateEntryNo.Location = New System.Drawing.Point(121, 405)
        Me.TxtGateEntryNo.MaxLength = 0
        Me.TxtGateEntryNo.Name = "TxtGateEntryNo"
        Me.TxtGateEntryNo.Size = New System.Drawing.Size(238, 18)
        Me.TxtGateEntryNo.TabIndex = 4
        Me.TxtGateEntryNo.Visible = False
        '
        'LblGateEntryNo
        '
        Me.LblGateEntryNo.AutoSize = True
        Me.LblGateEntryNo.BackColor = System.Drawing.Color.Transparent
        Me.LblGateEntryNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGateEntryNo.Location = New System.Drawing.Point(9, 406)
        Me.LblGateEntryNo.Name = "LblGateEntryNo"
        Me.LblGateEntryNo.Size = New System.Drawing.Size(95, 16)
        Me.LblGateEntryNo.TabIndex = 740
        Me.LblGateEntryNo.Text = "Gate Entry No."
        Me.LblGateEntryNo.Visible = False
        '
        'TxtTruckNo
        '
        Me.TxtTruckNo.AgMandatory = False
        Me.TxtTruckNo.AgMasterHelp = False
        Me.TxtTruckNo.AgNumberLeftPlaces = 8
        Me.TxtTruckNo.AgNumberNegetiveAllow = False
        Me.TxtTruckNo.AgNumberRightPlaces = 2
        Me.TxtTruckNo.AgPickFromLastValue = False
        Me.TxtTruckNo.AgRowFilter = ""
        Me.TxtTruckNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTruckNo.AgSelectedValue = Nothing
        Me.TxtTruckNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTruckNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTruckNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTruckNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTruckNo.Location = New System.Drawing.Point(121, 425)
        Me.TxtTruckNo.MaxLength = 0
        Me.TxtTruckNo.Name = "TxtTruckNo"
        Me.TxtTruckNo.Size = New System.Drawing.Size(238, 18)
        Me.TxtTruckNo.TabIndex = 5
        Me.TxtTruckNo.Visible = False
        '
        'LblTruckNo
        '
        Me.LblTruckNo.AutoSize = True
        Me.LblTruckNo.BackColor = System.Drawing.Color.Transparent
        Me.LblTruckNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTruckNo.Location = New System.Drawing.Point(9, 426)
        Me.LblTruckNo.Name = "LblTruckNo"
        Me.LblTruckNo.Size = New System.Drawing.Size(64, 16)
        Me.LblTruckNo.TabIndex = 742
        Me.LblTruckNo.Text = "Truck No."
        Me.LblTruckNo.Visible = False
        '
        'TxtForm
        '
        Me.TxtForm.AgMandatory = False
        Me.TxtForm.AgMasterHelp = False
        Me.TxtForm.AgNumberLeftPlaces = 8
        Me.TxtForm.AgNumberNegetiveAllow = False
        Me.TxtForm.AgNumberRightPlaces = 2
        Me.TxtForm.AgPickFromLastValue = False
        Me.TxtForm.AgRowFilter = ""
        Me.TxtForm.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtForm.AgSelectedValue = Nothing
        Me.TxtForm.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtForm.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtForm.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtForm.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtForm.Location = New System.Drawing.Point(121, 505)
        Me.TxtForm.MaxLength = 0
        Me.TxtForm.Name = "TxtForm"
        Me.TxtForm.Size = New System.Drawing.Size(238, 18)
        Me.TxtForm.TabIndex = 6
        Me.TxtForm.Visible = False
        '
        'LblForm
        '
        Me.LblForm.AutoSize = True
        Me.LblForm.BackColor = System.Drawing.Color.Transparent
        Me.LblForm.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblForm.Location = New System.Drawing.Point(9, 506)
        Me.LblForm.Name = "LblForm"
        Me.LblForm.Size = New System.Drawing.Size(38, 16)
        Me.LblForm.TabIndex = 744
        Me.LblForm.Text = "Form"
        Me.LblForm.Visible = False
        '
        'TxtFormNo
        '
        Me.TxtFormNo.AgMandatory = False
        Me.TxtFormNo.AgMasterHelp = False
        Me.TxtFormNo.AgNumberLeftPlaces = 8
        Me.TxtFormNo.AgNumberNegetiveAllow = False
        Me.TxtFormNo.AgNumberRightPlaces = 2
        Me.TxtFormNo.AgPickFromLastValue = False
        Me.TxtFormNo.AgRowFilter = ""
        Me.TxtFormNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtFormNo.AgSelectedValue = Nothing
        Me.TxtFormNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtFormNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtFormNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtFormNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtFormNo.Location = New System.Drawing.Point(121, 525)
        Me.TxtFormNo.MaxLength = 0
        Me.TxtFormNo.Name = "TxtFormNo"
        Me.TxtFormNo.Size = New System.Drawing.Size(207, 18)
        Me.TxtFormNo.TabIndex = 7
        Me.TxtFormNo.Visible = False
        '
        'LblFormNo
        '
        Me.LblFormNo.AutoSize = True
        Me.LblFormNo.BackColor = System.Drawing.Color.Transparent
        Me.LblFormNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblFormNo.Location = New System.Drawing.Point(9, 526)
        Me.LblFormNo.Name = "LblFormNo"
        Me.LblFormNo.Size = New System.Drawing.Size(62, 16)
        Me.LblFormNo.TabIndex = 746
        Me.LblFormNo.Text = "Form No."
        Me.LblFormNo.Visible = False
        '
        'TxtTransporter
        '
        Me.TxtTransporter.AgMandatory = False
        Me.TxtTransporter.AgMasterHelp = False
        Me.TxtTransporter.AgNumberLeftPlaces = 8
        Me.TxtTransporter.AgNumberNegetiveAllow = False
        Me.TxtTransporter.AgNumberRightPlaces = 2
        Me.TxtTransporter.AgPickFromLastValue = False
        Me.TxtTransporter.AgRowFilter = ""
        Me.TxtTransporter.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtTransporter.AgSelectedValue = Nothing
        Me.TxtTransporter.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtTransporter.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtTransporter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtTransporter.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTransporter.Location = New System.Drawing.Point(121, 465)
        Me.TxtTransporter.MaxLength = 20
        Me.TxtTransporter.Name = "TxtTransporter"
        Me.TxtTransporter.Size = New System.Drawing.Size(238, 18)
        Me.TxtTransporter.TabIndex = 2
        Me.TxtTransporter.Visible = False
        '
        'LblTransporter
        '
        Me.LblTransporter.AutoSize = True
        Me.LblTransporter.BackColor = System.Drawing.Color.Transparent
        Me.LblTransporter.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTransporter.Location = New System.Drawing.Point(8, 465)
        Me.LblTransporter.Name = "LblTransporter"
        Me.LblTransporter.Size = New System.Drawing.Size(73, 16)
        Me.LblTransporter.TabIndex = 748
        Me.LblTransporter.Text = "Transporter"
        Me.LblTransporter.Visible = False
        '
        'BtnRemoveFilter
        '
        Me.BtnRemoveFilter.BackColor = System.Drawing.Color.White
        Me.BtnRemoveFilter.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.BtnRemoveFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnRemoveFilter.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.BtnRemoveFilter.Image = Global.AgTemplate.My.Resources.Resources.Filter1
        Me.BtnRemoveFilter.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnRemoveFilter.Location = New System.Drawing.Point(329, 524)
        Me.BtnRemoveFilter.Name = "BtnRemoveFilter"
        Me.BtnRemoveFilter.Size = New System.Drawing.Size(30, 21)
        Me.BtnRemoveFilter.TabIndex = 749
        Me.BtnRemoveFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnRemoveFilter.UseVisualStyleBackColor = False
        Me.BtnRemoveFilter.Visible = False
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(487, 408)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(175, 140)
        Me.PnlCShowGrid2.TabIndex = 751
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(668, 408)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(151, 140)
        Me.PnlCShowGrid.TabIndex = 750
        '
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(111, 75)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 738
        Me.LblReferenceNoReq.Text = "Ä"
        '
        'TxtLrNo
        '
        Me.TxtLrNo.AgMandatory = False
        Me.TxtLrNo.AgMasterHelp = False
        Me.TxtLrNo.AgNumberLeftPlaces = 8
        Me.TxtLrNo.AgNumberNegetiveAllow = False
        Me.TxtLrNo.AgNumberRightPlaces = 2
        Me.TxtLrNo.AgPickFromLastValue = False
        Me.TxtLrNo.AgRowFilter = ""
        Me.TxtLrNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLrNo.AgSelectedValue = Nothing
        Me.TxtLrNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLrNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtLrNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLrNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLrNo.Location = New System.Drawing.Point(121, 445)
        Me.TxtLrNo.MaxLength = 20
        Me.TxtLrNo.Name = "TxtLrNo"
        Me.TxtLrNo.Size = New System.Drawing.Size(76, 18)
        Me.TxtLrNo.TabIndex = 752
        '
        'LblLrNo
        '
        Me.LblLrNo.AutoSize = True
        Me.LblLrNo.BackColor = System.Drawing.Color.Transparent
        Me.LblLrNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLrNo.Location = New System.Drawing.Point(9, 446)
        Me.LblLrNo.Name = "LblLrNo"
        Me.LblLrNo.Size = New System.Drawing.Size(60, 16)
        Me.LblLrNo.TabIndex = 753
        Me.LblLrNo.Text = "L. R. No."
        '
        'TxtLrDate
        '
        Me.TxtLrDate.AgMandatory = False
        Me.TxtLrDate.AgMasterHelp = False
        Me.TxtLrDate.AgNumberLeftPlaces = 8
        Me.TxtLrDate.AgNumberNegetiveAllow = False
        Me.TxtLrDate.AgNumberRightPlaces = 2
        Me.TxtLrDate.AgPickFromLastValue = False
        Me.TxtLrDate.AgRowFilter = ""
        Me.TxtLrDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtLrDate.AgSelectedValue = Nothing
        Me.TxtLrDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtLrDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtLrDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtLrDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLrDate.Location = New System.Drawing.Point(271, 445)
        Me.TxtLrDate.MaxLength = 20
        Me.TxtLrDate.Name = "TxtLrDate"
        Me.TxtLrDate.Size = New System.Drawing.Size(88, 18)
        Me.TxtLrDate.TabIndex = 754
        '
        'LblLrDate
        '
        Me.LblLrDate.AutoSize = True
        Me.LblLrDate.BackColor = System.Drawing.Color.Transparent
        Me.LblLrDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblLrDate.Location = New System.Drawing.Point(201, 447)
        Me.LblLrDate.Name = "LblLrDate"
        Me.LblLrDate.Size = New System.Drawing.Size(67, 16)
        Me.LblLrDate.TabIndex = 755
        Me.LblLrDate.Text = "L. R. Date"
        '
        'RbtChallanDirect
        '
        Me.RbtChallanDirect.AutoSize = True
        Me.RbtChallanDirect.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtChallanDirect.Location = New System.Drawing.Point(263, 92)
        Me.RbtChallanDirect.Name = "RbtChallanDirect"
        Me.RbtChallanDirect.Size = New System.Drawing.Size(106, 17)
        Me.RbtChallanDirect.TabIndex = 743
        Me.RbtChallanDirect.TabStop = True
        Me.RbtChallanDirect.Text = "Challan Direct"
        Me.RbtChallanDirect.UseVisualStyleBackColor = True
        '
        'RbtChallanForOrder
        '
        Me.RbtChallanForOrder.AutoSize = True
        Me.RbtChallanForOrder.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtChallanForOrder.Location = New System.Drawing.Point(127, 92)
        Me.RbtChallanForOrder.Name = "RbtChallanForOrder"
        Me.RbtChallanForOrder.Size = New System.Drawing.Size(127, 17)
        Me.RbtChallanForOrder.TabIndex = 742
        Me.RbtChallanForOrder.TabStop = True
        Me.RbtChallanForOrder.Text = "Challan For Order"
        Me.RbtChallanForOrder.UseVisualStyleBackColor = True
        '
        'TempGr
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(1012, 599)
        Me.Controls.Add(Me.TxtLrDate)
        Me.Controls.Add(Me.LblLrDate)
        Me.Controls.Add(Me.TxtLrNo)
        Me.Controls.Add(Me.LblLrNo)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.BtnRemoveFilter)
        Me.Controls.Add(Me.TxtTransporter)
        Me.Controls.Add(Me.LblTransporter)
        Me.Controls.Add(Me.TxtFormNo)
        Me.Controls.Add(Me.LblFormNo)
        Me.Controls.Add(Me.TxtForm)
        Me.Controls.Add(Me.LblForm)
        Me.Controls.Add(Me.TxtTruckNo)
        Me.Controls.Add(Me.LblTruckNo)
        Me.Controls.Add(Me.TxtGateEntryNo)
        Me.Controls.Add(Me.LblGateEntryNo)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtSalesTaxGroupParty)
        Me.Controls.Add(Me.Label27)
        Me.Name = "TempGr"
        Me.Text = "Template Goods Receive"
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
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
        Me.Controls.SetChildIndex(Me.LblGateEntryNo, 0)
        Me.Controls.SetChildIndex(Me.TxtGateEntryNo, 0)
        Me.Controls.SetChildIndex(Me.LblTruckNo, 0)
        Me.Controls.SetChildIndex(Me.TxtTruckNo, 0)
        Me.Controls.SetChildIndex(Me.LblForm, 0)
        Me.Controls.SetChildIndex(Me.TxtForm, 0)
        Me.Controls.SetChildIndex(Me.LblFormNo, 0)
        Me.Controls.SetChildIndex(Me.TxtFormNo, 0)
        Me.Controls.SetChildIndex(Me.LblTransporter, 0)
        Me.Controls.SetChildIndex(Me.TxtTransporter, 0)
        Me.Controls.SetChildIndex(Me.BtnRemoveFilter, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
        Me.Controls.SetChildIndex(Me.LblLrNo, 0)
        Me.Controls.SetChildIndex(Me.TxtLrNo, 0)
        Me.Controls.SetChildIndex(Me.LblLrDate, 0)
        Me.Controls.SetChildIndex(Me.TxtLrDate, 0)
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
        Me.PerformLayout()

    End Sub
    Protected WithEvents LblVendor As System.Windows.Forms.Label
    Protected WithEvents TxtVendor As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtSalesTaxGroupParty As AgControls.AgTextBox
    Protected WithEvents Label27 As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents TxtBillingType As AgControls.AgTextBox
    Protected WithEvents Label32 As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents Label33 As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtCurrency As AgControls.AgTextBox
    Protected WithEvents LblCurrency As System.Windows.Forms.Label
    Protected WithEvents TxtTransport As AgControls.AgTextBox
    Protected WithEvents LblTransport As System.Windows.Forms.Label
    Protected WithEvents TxtVendorDocDate As AgControls.AgTextBox
    Protected WithEvents LvlVendorDocDate As System.Windows.Forms.Label
    Protected WithEvents TxtVendorDocNo As AgControls.AgTextBox
    Protected WithEvents LblVendorDocNo As System.Windows.Forms.Label
    Protected WithEvents TxtGodown As AgControls.AgTextBox
    Protected WithEvents LblGodown As System.Windows.Forms.Label
    Protected WithEvents TxtPurchOrder As AgControls.AgTextBox
    Protected WithEvents LblOrderNo As System.Windows.Forms.Label
    Protected WithEvents BtnFill As System.Windows.Forms.Button
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents TxtGateEntryNo As AgControls.AgTextBox
    Protected WithEvents LblGateEntryNo As System.Windows.Forms.Label
    Protected WithEvents TxtTruckNo As AgControls.AgTextBox
    Protected WithEvents LblTruckNo As System.Windows.Forms.Label
    Protected WithEvents TxtForm As AgControls.AgTextBox
    Protected WithEvents LblForm As System.Windows.Forms.Label
    Protected WithEvents TxtFormNo As AgControls.AgTextBox
    Protected WithEvents LblFormNo As System.Windows.Forms.Label
    Protected WithEvents TxtTransporter As AgControls.AgTextBox
    Protected WithEvents LblTransporter As System.Windows.Forms.Label
    Protected WithEvents BtnRemoveFilter As System.Windows.Forms.Button
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtLrNo As AgControls.AgTextBox
    Protected WithEvents LblLrNo As System.Windows.Forms.Label
    Protected WithEvents TxtLrDate As AgControls.AgTextBox
    Protected WithEvents LblLrDate As System.Windows.Forms.Label
    Protected WithEvents RbtChallanDirect As System.Windows.Forms.RadioButton
    Protected WithEvents RbtChallanForOrder As System.Windows.Forms.RadioButton
#End Region

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "PurchChallan"
        LogTableName = "PurchChallan_Log"
        MainLineTableCsv = "PurchChallanDetail,Stock,Structure_TransFooter,Structure_TransLine"
        LogLineTableCsv = "PurchChallanDetail_LOG,Stock_Log,Structure_TransFooter_Log,Structure_TransLine_Log"

        AgL.GridDesign(Dgl1)
        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)
        AgL.AddAgDataGrid(AgCShowGrid1, PnlCShowGrid)
        AgL.AddAgDataGrid(AgCShowGrid2, PnlCShowGrid2)

        AgCShowGrid1.Visible = False
        AgCShowGrid2.Visible = False

        AgCalcGrid1.AgLibVar = AgL
        AgCalcGrid1.Visible = False
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From PurchChallan H " & _
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
               " From PurchChallan_Log H " & _
               " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
               " Where EntryStatus='" & LogStatus.LogOpen & "' " & mCondStr & " Order By EntryDate"

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindLog() Handles Me.BaseEvent_FindLog
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT H.UID as SearchCode, Vt.Description AS [Entry Type], H.V_Date AS [Entry Date], " & _
        '                 " H.V_No AS [Entry No], H.ReferenceNo, Sg.DispName As VendorName,  " & _
        '                 " H.VendorDocNo AS [Vendor Doc No], H.VendorDocDate AS [Vendor Doc Date]  " & _
        '                 " FROM PurchChallan_Log H " & _
        '                 " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
        '                 " LEFT JOIN SubGroup Sg On H.Vendor = Sg.SubCode " & _
        '                 " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQry = " SELECT H.UID AS SearchCode, H.V_Type AS [Challan Type], H.V_Prefix AS [Prefix], H.V_Date AS [Challan Date], H.V_No AS [Challan No], " & _
                " H.ReferenceNo AS [Manual No], H.Currency, H.GateEntryNo AS [Gate Entry No], H.TruckNo AS [Truck No], H.SalesTaxGroupParty AS [Sales Tax Group Party], H.Structure,  " & _
                " H.BillingType AS [Billing Type], H.VendorDocNo AS [Vendor Doc No], H.VendorDocDate AS [Vendor Doc Date], H.FormNo, H.Transport, H.Remarks, H.TotalQty AS [Total Qty],  " & _
                " H.TotalMeasure AS [Total Measure], H.TotalAmount AS [Total Amount], H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status],  " & _
                " H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log], H.MoveToLogDate AS [Move To Log Date], H.Status, H.LrNo AS [L.R. No], H.LrDate AS [L.R. date], " & _
                " D.Div_Name AS Division,SM.Name AS [Site Name], SGV.DispName AS [Vendor Name], PO.ReferenceNo AS [Purchase ORDER No], " & _
                " FM.Description AS Form, SGT.DispName AS [Transporter Name],G.Description AS [Godown]  " & _
                " FROM  PurchChallan_Log H " & _
                " LEFT JOIN Division D ON D.Div_Code=H.Div_Code  " & _
                " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " LEFT JOIN SubGroup SGV ON SGV.SubCode  = H.Vendor  " & _
                " LEFT JOIN PurchOrder PO ON PO.DocID=H.PurchOrder  " & _
                " LEFT JOIN Form_Master FM ON FM.Code=H.Form  " & _
                " LEFT JOIN SubGroup SGT ON SGT.SubCode  = H.Transporter  " & _
                " LEFT JOIN Godown G ON G.Code=H.Godown  " & _
                " Where H.EntryStatus = '" & ClsMain.LogStatus.LogOpen & "'" & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        'AgL.PubFindQry = "SELECT H.DocId as SearchCode, Vt.Description AS [Entry Type], " & _
        '                    " H.V_Date AS [Entry Date], H.V_No AS [Entry No], " & _
        '                    " H.ReferenceNo, Sg.DispName As VendorName,  " & _
        '                    " H.VendorDocNo AS [Vendor Doc No], H.VendorDocDate AS [Vendor Doc Date] " & _
        '                    " FROM PurchChallan H " & _
        '                    " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
        '                    " LEFT JOIN SubGroup Sg On H.Vendor = Sg.SubCode " & _
        '                    " Where IsNull(H.IsDeleted,0)=0  " & mCondStr

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, H.V_Type AS [Challan Type], H.V_Prefix AS [Prefix], H.V_Date AS [Challan Date], H.V_No AS [Challan No], " & _
                        " H.ReferenceNo AS [Manual No], H.Currency, H.GateEntryNo AS [Gate Entry No], H.TruckNo AS [Truck No], H.SalesTaxGroupParty AS [Sales Tax Group Party], H.Structure,  " & _
                        " H.BillingType AS [Billing Type], H.VendorDocNo AS [Vendor Doc No], H.VendorDocDate AS [Vendor Doc Date], H.FormNo, H.Transport, H.Remarks, H.TotalQty AS [Total Qty],  " & _
                        " H.TotalMeasure AS [Total Measure], H.TotalAmount AS [Total Amount], H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type], H.EntryStatus AS [Entry Status],  " & _
                        " H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log], H.MoveToLogDate AS [Move To Log Date], H.Status, H.LrNo AS [L.R. No], H.LrDate AS [L.R. date], " & _
                        " D.Div_Name AS Division,SM.Name AS [Site Name], SGV.DispName AS [Vendor Name], PO.ReferenceNo AS [Purchase ORDER No], " & _
                        " FM.Description AS Form, SGT.DispName AS [Transporter Name],G.Description AS [Godown] " & _
                        " FROM  PurchChallan H " & _
                        " LEFT JOIN Division D ON D.Div_Code=H.Div_Code  " & _
                        " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                        " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                        " LEFT JOIN SubGroup SGV ON SGV.SubCode  = H.Vendor  " & _
                        " LEFT JOIN PurchOrder PO ON PO.DocID=H.PurchOrder  " & _
                        " LEFT JOIN Form_Master FM ON FM.Code=H.Form  " & _
                        " LEFT JOIN SubGroup SGT ON SGT.SubCode  = H.Transporter  " & _
                        " LEFT JOIN Godown G ON G.Code=H.Godown  " & _
                         " Where IsNull(H.IsDeleted,0)=0  " & mCondStr
        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 180, 0, Col1Item, True, False)
            .AddAgTextColumn(Dgl1, Col1PurchOrder, 80, 0, Col1PurchOrder, True, False)
            .AddAgTextColumn(Dgl1, Col1LotNo, 120, 20, Col1LotNo, True, False)
            .AddAgTextColumn(Dgl1, Col1SalesTaxGroup, 120, 0, Col1SalesTaxGroup, False, False)
            .AddAgNumberColumn(Dgl1, Col1DocQty, 50, 8, 3, False, Col1DocQty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1RejQty, 60, 8, 3, False, Col1RejQty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Qty, 50, 8, 3, False, Col1Qty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1PrevQty, 50, 8, 3, False, Col1PrevQty, False, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 70, 8, 3, False, Col1MeasurePerPcs, True, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 50, 0, Col1MeasureUnit, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalDocMeasure, 70, 8, 3, False, Col1TotalDocMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalRejMeasure, 70, 8, 3, False, Col1TotalRejMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 70, 8, 3, False, Col1TotalMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 60, 8, 4, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 70, 8, 2, False, Col1Amount, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1InvoicedQty, 70, 8, 3, False, Col1InvoicedQty, False, False, True)
            .AddAgNumberColumn(Dgl1, Col1InvoicedMeasure, 70, 8, 3, False, Col1InvoicedMeasure, False, False, True)
            .AddAgTextColumn(Dgl1, Col1PrevItem, 180, 0, Col1PrevItem, False, False)
            .AddAgTextColumn(Dgl1, Col1PrevPurchOrder, 70, 0, Col1PrevPurchOrder, False, False)
            .AddAgTextColumn(Dgl1, Col1Remark, 150, 0, Col1Remark, True, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = AnchorStyles.None
        Panel1.Anchor = Dgl1.Anchor
        Dgl1.ColumnHeadersHeight = 35


        AgCalcGrid1.Ini_Grid(mSearchCode)
        AgCalcGrid1.AgFixedRows = 6
        AgCShowGrid1.AgIsFixedRows = True
        AgCShowGrid1.AgParentCalcGrid = AgCalcGrid1
        AgCShowGrid2.AgParentCalcGrid = AgCalcGrid1
        If AgCalcGrid1.RowCount > 0 Then
            AgCShowGrid1.Ini_Grid()
            AgCShowGrid2.Ini_Grid()
        End If



        AgCalcGrid1.AgLineGrid = Dgl1
        AgCalcGrid1.AgLineGridMandatoryColumn = Dgl1.Columns(Col1Item).Index
        AgCalcGrid1.AgLineGridGrossColumn = Dgl1.Columns(Col1Amount).Index
        'AgCalcGrid1.AgLineGridPostingGroupSalesTaxProd = Dgl1.Columns(Col1SalesTaxGroup).Index
        AgCalcGrid1.AgLineGridPostingGroupSalesTaxProd = Dgl1.Columns(Col1SalesTaxGroup).Index

        Dgl1.AgSkipReadOnlyColumns = True

        FrmSaleOrder_BaseFunction_FIniList()
        'Ini_List()
    End Sub


    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = " Update PurchChallan_Log " & _
                " SET  " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " Vendor = " & AgL.Chk_Text(TxtVendor.AgSelectedValue) & ", " & _
                " PurchOrder = " & AgL.Chk_Text(TxtPurchOrder.AgSelectedValue) & ", " & _
                " Currency = " & AgL.Chk_Text(TxtCurrency.AgSelectedValue) & ", " & _
                " SalesTaxGroupParty = " & AgL.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & ", " & _
                " Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                " BillingType = " & AgL.Chk_Text(TxtBillingType.AgSelectedValue) & ", " & _
                " VendorDocNo = " & AgL.Chk_Text(TxtVendorDocNo.Text) & ", " & _
                " VendorDocDate = " & AgL.Chk_Text(TxtVendorDocDate.Text) & ", " & _
                " Transport = " & AgL.Chk_Text(TxtTransport.Text) & ", " & _
                " Godown = " & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " TotalAmount = " & Val(LblTotalAmount.Text) & ", " & _
                " TotalMeasure = " & Val(LblTotalMeasure.Text) & " ," & _
                " GateEntryNo = " & AgL.Chk_Text(TxtGateEntryNo.Text) & ", " & _
                " LrDate = " & AgL.Chk_Text(TxtLrDate.Text) & ", " & _
                " LrNo = " & AgL.Chk_Text(TxtLrNo.Text) & ", " & _
                " TruckNo = " & AgL.Chk_Text(TxtTruckNo.Text) & ", " & _
                " Form = " & AgL.Chk_Text(TxtForm.AgSelectedValue) & ", " & _
                " FormNo = " & AgL.Chk_Text(TxtFormNo.Text) & ", " & _
                " Transporter = " & AgL.Chk_Text(TxtTransporter.AgSelectedValue) & " " & _
                " Where UID = '" & mSearchCode & "'"

        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        AgCalcGrid1.Save_TransFooter(mInternalCode, Conn, Cmd, SearchCode)

        mQry = "Delete From PurchChallanDetail_Log Where UID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        If mIsPostStock Then
            mQry = "Delete From Stock_Log Where UID = '" & mSearchCode & "'"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1
                mQry = "Insert Into PurchChallanDetail_Log( UID, DocId, Sr, PurchOrder, Item, LotNo, SalesTaxGroupItem, DocQty, " & _
                        " RejQty, Qty, Unit, MeasurePerPcs, MeasureUnit, TotalDocMeasure, TotalRejMeasure, " & _
                        " TotalMeasure, Rate, Amount, InvoicedQty, InvoicedMeasure,Remark) " & _
                        " Values( " & _
                        " " & AgL.Chk_Text(mSearchCode) & ", " & AgL.Chk_Text(mInternalCode) & ", " & mSr & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1PurchOrder, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, I)) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1LotNo, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1SalesTaxGroup, I)) & ", " & _
                        " " & Val(Dgl1.Item(Col1DocQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1RejQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalDocMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalRejMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1TotalMeasure, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1InvoicedQty, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1InvoicedMeasure, I).Value) & ", " & _
                         " " & AgL.Chk_Text(Dgl1.Item(Col1Remark, I).Value) & " " & _
                        " )"

                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                If mIsPostStock Then Call ProcStockPost(Conn, Cmd, I, mSr)

                AgCalcGrid1.Save_TransLine(mInternalCode, mSr, I, Conn, Cmd, SearchCode)
                RaiseEvent BaseEvent_Save_InTransLine(SearchCode, mSr, I, Conn, Cmd)
            End If
        Next
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer

        Dim DsTemp As DataSet

        Call IniItemList()
        If FrmType = ClsMain.EntryPointType.Main Then
            mQry = "Select H.* " & _
                " From PurchChallan H " & _
                " Where H.DocID='" & SearchCode & "'"
        Else
            mQry = "Select H.* " & _
                " From PurchChallan_Log H " & _
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
                TxtVendor.AgSelectedValue = AgL.XNull(.Rows(0)("Vendor"))
                TxtCurrency.AgSelectedValue = AgL.XNull(.Rows(0)("Currency"))
                TxtVendorDocNo.Text = AgL.XNull(.Rows(0)("VendorDocNo"))
                TxtVendorDocDate.Text = AgL.XNull(.Rows(0)("VendorDocDate"))
                TxtBillingType.AgSelectedValue = AgL.XNull(.Rows(0)("BillingType"))
                TxtPurchOrder.AgSelectedValue = AgL.XNull(.Rows(0)("PurchOrder"))


                TxtCurrency.AgSelectedValue = AgL.XNull(.Rows(0)("Currency"))
                TxtGodown.AgSelectedValue = AgL.XNull(.Rows(0)("Godown"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                TxtTransport.Text = AgL.XNull(.Rows(0)("Transport"))


                TxtGateEntryNo.Text = AgL.XNull(.Rows(0)("GateEntryNo"))
                TxtTruckNo.Text = AgL.XNull(.Rows(0)("TruckNo"))

                TxtLrNo.Text = AgL.XNull(.Rows(0)("LrNo"))
                TxtLrDate.Text = AgL.XNull(.Rows(0)("LrDate"))

                TxtForm.AgSelectedValue = AgL.XNull(.Rows(0)("Form"))
                TxtFormNo.Text = AgL.XNull(.Rows(0)("FormNo"))
                TxtTransporter.AgSelectedValue = AgL.XNull(.Rows(0)("Transporter"))
                TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))


                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))
                LblTotalMeasure.Text = AgL.VNull(.Rows(0)("TotalMeasure"))

                AgCalcGrid1.MoveRec_TransFooter(SearchCode)

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                If FrmType = ClsMain.EntryPointType.Main Then
                    mQry = "Select * from PurchChallanDetail where DocId = '" & SearchCode & "' Order By Sr"
                Else
                    mQry = "Select * from PurchChallanDetail_Log where UID = '" & SearchCode & "' Order By Sr"
                End If


                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.AgSelectedValue(Col1PurchOrder, I) = AgL.XNull(.Rows(I)("PurchOrder"))
                            Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1LotNo, I).Value = AgL.XNull(.Rows(I)("LotNo"))
                            Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                            Dgl1.Item(Col1DocQty, I).Value = AgL.VNull(.Rows(I)("DocQty"))
                            Dgl1.Item(Col1PrevQty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1RejQty, I).Value = AgL.VNull(.Rows(I)("RejQty"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.".PadRight(CType(Dgl1.Columns(Col1MeasurePerPcs), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalDocMeasure")), "0.".PadRight(CType(Dgl1.Columns(Col1TotalDocMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1TotalRejMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalRejMeasure")), "0.".PadRight(CType(Dgl1.Columns(Col1TotalRejMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1TotalMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalMeasure")), "0.".PadRight(CType(Dgl1.Columns(Col1TotalMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1Rate, I).Value = AgL.VNull(.Rows(I)("Rate"))
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                            Dgl1.Item(Col1InvoicedQty, I).Value = AgL.VNull(.Rows(I)("InvoicedQty"))
                            Dgl1.Item(Col1InvoicedMeasure, I).Value = AgL.VNull(.Rows(I)("InvoicedMeasure"))
                            Dgl1.Item(Col1PrevItem, I).Value = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1PrevPurchOrder, I).Value = AgL.XNull(.Rows(I)("PurchOrder"))

                            Dgl1.Item(Col1Remark , I).Value = AgL.XNull(.Rows(I)("Remark"))

                            Call AgCalcGrid1.MoveRec_TransLine(mSearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                            RaiseEvent BaseFunction_MoveRecLine(SearchCode, AgL.VNull(.Rows(I)("Sr")), I)
                        Next I
                    End If
                End With

                AgCShowGrid1.MoveRec_FromCalcGrid()
                AgCShowGrid2.MoveRec_FromCalcGrid()
                'Calculation()
                '-------------------------------------------------------------
            End If
        End With

    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgCalcGrid1.FrmType = Me.FrmType
    End Sub

    Private Sub TxtSalesTaxGroupParty_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtSalesTaxGroupParty.Enter

    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtPurchOrder.Validating, TxtVendor.Validating, TxtSalesTaxGroupParty.Validating, TxtGateEntryNo.Validating, TxtReferenceNo.Validating
        Dim DrTemp As DataRow()
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    IniGrid()
                    ProcFillReferenceNo()

                Case TxtPurchOrder.Name
                    e.Cancel = Not Validate_PurchOrder(TxtPurchOrder)
                    If e.Cancel = False Then
                        Validating_PurchaseOrder(sender.AgSelectedValue)
                    End If

                Case TxtVendor.Name
                    If sender.text.ToString.Trim <> "" Then
                        If sender.AgHelpDataSet IsNot Nothing Then
                            DrTemp = sender.AgHelpDataSet.Tables(0).Select("SubCode = " & AgL.Chk_Text(sender.AgSelectedValue) & "")
                            TxtCurrency.AgSelectedValue = AgL.XNull(DrTemp(0)("Currency"))
                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("SalesTaxPostingGroup")), "") Then
                                TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                                AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                            End If
                        End If
                    End If
                Case TxtSalesTaxGroupParty.Name
                    AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                    Calculation()

                Case TxtGateEntryNo.Name
                    Validating_GateEntry(TxtGateEntryNo.AgSelectedValue)

                Case TxtReferenceNo.Name
                    e.Cancel = Not FCheckDuplicateRefNo()
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_PurchaseOrder(ByVal Code As String)
        Dim DrTemp As DataRow() = Nothing
        Try
            If TxtPurchOrder.Text <> "" Then
                DrTemp = TxtPurchOrder.AgHelpDataSet.Tables(0).Select(" Code = '" & Code & "' ")
                If DrTemp.Length > 0 Then
                    TxtCurrency.AgSelectedValue = AgL.XNull(DrTemp(0)("Currency"))
                Else
                    TxtCurrency.AgSelectedValue = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_GateEntry(ByVal Code As String)
        Dim DrTemp As DataRow() = Nothing
        Try
            If TxtGateEntryNo.Text <> "" Then
                DrTemp = TxtGateEntryNo.AgHelpDataSet.Tables(0).Select(" Code = '" & Code & "' ")
                If DrTemp.Length > 0 Then
                    TxtTransporter.AgSelectedValue = AgL.XNull(DrTemp(0)("Transporter"))
                    TxtTruckNo.Text = AgL.XNull(DrTemp(0)("VehicleNo"))
                    TxtLrNo.Text = AgL.XNull(DrTemp(0)("LrNo"))
                    TxtLrDate.Text = AgL.XNull(DrTemp(0)("LrDate"))
                Else
                    TxtTransporter.AgSelectedValue = ""
                    TxtTruckNo.Text = ""
                    TxtLrNo.Text = ""
                    TxtLrDate.Text = ""
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        ProcFillReferenceNo()
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        IniGrid()
        TabControl1.SelectedTab = TP1

        TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupParty"))
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue

        RbtChallanForOrder.Checked = True
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        TxtVendor.AgHelpDataSet(6, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Vendor
        TxtCurrency.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Currency
        TxtStructure.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.AgStructure
        TxtSalesTaxGroupParty.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.SalesTaxGroupParty
        TxtBillingType.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.BillingType
        TxtPurchOrder.AgHelpDataSet(10, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.PurchOrder
        Dgl1.AgHelpDataSet(Col1PurchOrder, 10) = HelpDataSet.PurchOrder
        TxtGodown.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = HelpDataSet.Godown
        TxtForm.AgHelpDataSet(2) = HelpDataSet.Form
        TxtTransporter.AgHelpDataSet(1) = HelpDataSet.Transporter
        TxtFormNo.AgHelpDataSet(3) = HelpDataSet.FormNo
        TxtGateEntryNo.AgHelpDataSet(7) = HelpDataSet.GateEntry

        Call IniItemList()
    End Sub

    Private Sub IniItemList(Optional ByVal All_Records As Boolean = True)
        If All_Records Then
            Dgl1.AgHelpDataSet(Col1Item, 10) = HelpDataSet.Item
        Else
            Dgl1.AgHelpDataSet(Col1Item, 11) = HelpDataSet.PurchOrderItem
        End If
    End Sub

    Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
        Dim DtTemp As DataTable = Nothing
        Try

            If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Unit, mRow).Value = ""
                Dgl1.Item(Col1MeasureUnit, mRow).Value = ""
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = 0
                Dgl1.Item(Col1Rate, mRow).Value = 0
                Dgl1.Item(Col1DocQty, mRow).Value = 0
                Dgl1.AgSelectedValue(Col1PurchOrder, mRow) = ""
                Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = ""
            Else
                If Dgl1.AgDataRow IsNot Nothing Then
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Unit").Value)
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("MeasureUnit").Value)
                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("MeasurePerPcs").Value)
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("Rate").Value)
                    Dgl1.Item(Col1DocQty, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("PendingQty").Value)
                    Dgl1.AgSelectedValue(Col1PurchOrder, mRow) = AgL.XNull(Dgl1.AgDataRow.Cells("PurchOrder").Value)
                    Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(Dgl1.AgDataRow.Cells("SalesTaxPostingGroup").Value)
                    If AgL.StrCmp(Dgl1.Item(Col1SalesTaxGroup, mRow).Value, "") Then
                        Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
                    End If

                    'If Dgl1.Item(Col1PurchOrder, mRow).Value <> "" Then
                    '    If Dgl1.AgSelectedValue(Col1PurchOrder, mRow) = Dgl1.Item(Col1PrevPurchOrder, mRow).Value _
                    '    And Dgl1.AgSelectedValue(Col1Item, mRow) = Dgl1.Item(Col1PrevItem, mRow).Value Then
                    '        Dgl1.Item(Col1DocQty, mRow).Value = AgL.VNull(DrTemp(0)("PendingQty")) + Dgl1.Item(Col1PrevQty, mRow).Value
                    '    Else
                    '        Dgl1.Item(Col1DocQty, mRow).Value = AgL.VNull(DrTemp(0)("PendingQty"))
                    '    End If
                    'End If
                End If
            End If
            Calculation()
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

                Case Col1PurchOrder
                    e.Cancel = Not Validate_PurchOrder(Dgl1, Dgl1.CurrentCell.RowIndex)
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
        LblTotalMeasure.Text = 0
        LblTotalAmount.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                If Val(Dgl1.Item(Col1DocQty, I).Value) <> 0 And Val(Dgl1.Item(Col1RejQty, I).Value) <> 0 Then
                    Dgl1.Item(Col1Qty, I).Value = Val(Dgl1.Item(Col1DocQty, I).Value) - Val(Dgl1.Item(Col1RejQty, I).Value)
                End If

                Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1TotalMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1TotalDocMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                Dgl1.Item(Col1TotalRejMeasure, I).Value = Format(Val(Dgl1.Item(Col1RejQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1TotalRejMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))

                If AgL.StrCmp(TxtBillingType.Text, "Qty") Or TxtBillingType.Text = "" Then
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                Else
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1TotalDocMeasure, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                End If


                'Footer Calculation
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
            End If
        Next
        AgCalcGrid1.Calculation()
        LblTotalQty.Text = Val(LblTotalQty.Text)
        LblTotalMeasure.Text = Val(LblTotalMeasure.Text)
        LblTotalAmount.Text = Val(LblTotalAmount.Text)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgL.RequiredField(TxtVendor, LblVendor.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtReferenceNo, LblReferenceNo.Text) Then passed = False : Exit Sub

        If TxtPurchOrder.AgSelectedValue <> "" Then
            If Validate_PurchOrder(TxtPurchOrder) = False Then passed = False : Exit Sub
        End If

        If TxtVendorDocDate.Text <> "" Then
            If CDate(TxtVendorDocDate.Text) > CDate(TxtV_Date.Text) Then
                MsgBox("Party order date can't be greater than order date", MsgBoxStyle.Information)
                TxtVendorDocDate.Focus()
                passed = False : Exit Sub
            End If
        End If

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If

                If .Item(Col1PurchOrder, I).Value <> "" Then
                    If Validate_PurchOrder(Dgl1, I) = False Then passed = False : Exit Sub
                End If
            Next
        End With

        passed = FCheckDuplicateRefNo()

    End Sub

    Private Function FCheckDuplicateRefNo() As Boolean
        FCheckDuplicateRefNo = True
        If Topctrl1.Mode = "Add" Then
            mQry = " SELECT COUNT(*) FROM Purchchallan WHERE ReferenceNo = '" & TxtReferenceNo.Text & "'   " & _
                    " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtReferenceNo.Focus()
        Else
            mQry = " SELECT COUNT(*) FROM Purchchallan WHERE ReferenceNo = '" & TxtReferenceNo.Text & "'  " & _
                    " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0 AND DocID <>'" & mInternalCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtReferenceNo.Focus()
        End If
    End Function

    Private Sub TxtShipToPartyCity_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtCurrency.Enter, TxtPurchOrder.Enter, TxtFormNo.Enter, TxtVendor.Enter, TxtSalesTaxGroupParty.Enter
        Try
            Select Case sender.name
                Case TxtVendor.Name
                    sender.AgRowFilter = " IsDeleted = 0 " & _
                        " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "

                Case TxtPurchOrder.Name
                    sender.AgRowFilter = " IsDeleted = 0 " & _
                        " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                        " And " & ClsMain.RetDivFilterStr & " " & _
                        " AND Vendor=" & AgL.Chk_Text(TxtVendor.AgSelectedValue) & " " & _
                        " And PurchaseOrderDate <= '" & TxtV_Date.Text & "' " & _
                        " And PendingQty > 0 "

                Case TxtCurrency.Name
                    sender.AgRowFilter = " IsDeleted = 0 "

                Case TxtForm.Name
                    sender.AgRowFilter = " IsDeleted = 0 And Status = '" & ClsMain.EntryStatus.Active & "'"

                Case TxtFormNo.Name
                    If BtnRemoveFilter.Tag = 0 Then
                        TxtFormNo.AgRowFilter = " Form = '" & TxtForm.AgSelectedValue & "' " & _
                            " And IsUtilised = 0 " & _
                            " And IssueTo In ('" & TxtVendor.AgSelectedValue & "','" & TxtTransport.AgSelectedValue & "' ) "
                    Else
                        TxtFormNo.AgRowFilter = " Form = '" & TxtForm.AgSelectedValue & "' " & _
                            " And IssueTo In ('" & TxtVendor.AgSelectedValue & "','" & TxtTransport.AgSelectedValue & "' ) "
                    End If
                Case TxtSalesTaxGroupParty.Name
                    TxtSalesTaxGroupParty.AgRowFilter = " Active = 1 "

            End Select
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        BtnRemoveFilter.Tag = 0
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                If TxtPurchOrder.AgSelectedValue <> "" Then
                    Call IniItemList(False)
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                            " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                            " AND PendingQty > 0 " & _
                            " And PurchOrder = '" & TxtPurchOrder.AgSelectedValue & "' "
                ElseIf RbtChallanForOrder.Checked Then
                    Call IniItemList(False)
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                            " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                            " AND PendingQty > 0 "
                Else
                    Call IniItemList()
                    Dgl1.AgRowFilter(Dgl1.Columns(Col1Item).Index) = " IsDeleted = 0 " & _
                            " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                End If

            Case Col1PurchOrder
                Dgl1.AgRowFilter(Dgl1.Columns(Col1PurchOrder).Index) = " (IsDeleted = 0 " & _
                        " And Status = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                        " AND Vendor=" & AgL.Chk_Text(TxtVendor.AgSelectedValue) & " " & _
                        " And PurchaseOrderDate <= '" & TxtV_Date.Text & "' " & _
                        " And PendingQty > 0  " & _
                        " Or Code = '" & Dgl1.Item(Col1PrevPurchOrder, Dgl1.CurrentCell.RowIndex).Value & "') "
        End Select
    End Sub

    Private Sub TempGr_BaseEvent_Approve_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Approve_InTrans
        Dim I As Integer

        '------------------------------------------------------------------------
        'Updating Goods Received Qty In Purchase Order Detail
        '-------------------------------------------------------------------------
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mQry = "UPDATE PurchOrderDetail " & _
                            " SET ShippedQty = (SELECT IsNull(Sum(Cd.Qty),0) " & _
                            " 				    FROM PurchChallanDetail Cd With (NoLock) " & _
                            "                   LEFT JOIN PurchChallan C With (NoLock) On Cd.DocId = C.DocId " & _
                            " 				    WHERE Cd.PurchOrder = '" & .AgSelectedValue(Col1PurchOrder, I) & "' " & _
                            " 				    AND Cd.Item = '" & .AgSelectedValue(Col1Item, I) & "' " & _
                            "                   AND IsNull(C.IsDeleted,0) = 0 ), " & _
                            " ShippedMeasure = (SELECT IsNull(Sum(Cd.TotalMeasure),0) " & _
                            " 				    FROM PurchChallanDetail Cd With (NoLock) " & _
                            "                   LEFT JOIN PurchChallan C With (NoLock) On Cd.DocId = C.DocId " & _
                            " 				    WHERE Cd.PurchOrder = '" & .AgSelectedValue(Col1PurchOrder, I) & "' " & _
                            " 				    AND Cd.Item = '" & .AgSelectedValue(Col1Item, I) & "' " & _
                            "                   AND IsNull(C.IsDeleted,0) = 0 ) " & _
                            " WHERE DocId = '" & .AgSelectedValue(Col1PurchOrder, I) & "' " & _
                            " AND Item = '" & .AgSelectedValue(Col1Item, I) & "' "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With

        mQry = " UPDATE Form_ReceiveDetail " & _
                " SET IsUtilised = (SELECT Count(*) FROM PurchChallan WITH (NoLock) WHERE FormNo = '" & TxtFormNo.Text & "') " & _
                " WHERE FormNo = '" & TxtFormNo.Text & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        '-------------------------------------------------------------------------
    End Sub

    Public Sub ProcStockPost(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand, ByVal RowIndex As Integer, ByVal mSr As Integer)
        mQry = "Insert Into Stock_Log(UID, DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, " & _
                    " SubCode, Currency, SalesTaxGroupParty, Structure, BillingType, Item, LotNo, " & _
                    " Godown, Qty_Rec, Unit, MeasurePerPcs, Measure_Rec, MeasureUnit, " & _
                    " Rate, Amount ) " & _
                    " Values( " & _
                    " '" & mSearchCode & "', '" & mInternalCode & "',  " & Val(mSr) & ", " & _
                    " " & AgL.Chk_Text(TxtV_Type.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(LblPrefix.Text) & ", " & AgL.Chk_Text(TxtV_Date.Text) & ", " & _
                    " " & Val(TxtV_No.Text) & ", " & AgL.Chk_Text(TxtDivision.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtSite_Code.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtVendor.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtCurrency.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtSalesTaxGroupParty.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(TxtBillingType.Text) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.AgSelectedValue(Col1Item, RowIndex)) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1LotNo, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1Qty, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1MeasurePerPcs, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1TotalMeasure, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1Rate, RowIndex).Value) & ", " & _
                    " " & AgL.Chk_Text(Dgl1.Item(Col1Amount, RowIndex).Value) & ")  "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub TempGr_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        If AgL.StrCmp(Topctrl1.Mode, "Add") Then
            TxtPurchOrder.Enabled = True
            BtnFill.Enabled = True
        Else
            TxtPurchOrder.Enabled = False
            BtnFill.Enabled = False
        End If
    End Sub

    Private Sub Dgl1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If Topctrl1.Mode <> "Browse" Then
            If e.Control = True And e.KeyCode = Keys.D Then
                sender.CurrentRow.Selected = True
            End If
        End If
    End Sub

    Private Sub ProcFillPurchOrderDetails(ByVal bPurchOrder As String)
        Dim DtTemp As DataTable = Nothing
        Dim bReferenceDocId$ = "", bConStr$ = ""
        Dim I As Integer = 0
        Try
            If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then Exit Sub
            Call IniItemList()

            mQry = " SELECT Po.PurchOrder FROM PurchOrder Po WHERE Po.DocID = '" & bPurchOrder & "'"
            bReferenceDocId = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)

            mQry = "SELECT '" & bPurchOrder & "' As PurchOrder, Pod.Item, Pod.SalesTaxGroupItem, Pod.Unit, " & _
                   " Pod.MeasurePerPcs,Pod.MeasureUnit, Pod.Rate, Pod.Amount, " & _
                   " Pod.Qty - Pod.ShippedQty As Qty " & _
                   " FROM PurchOrderDetail Pod " & _
                   " LEFT JOIN PurchOrder Po On Pod.DocId = Po.DocId " & _
                   " LEFT JOIN Item I ON Pod.Item = I.Code " & _
                   " WHERE Po.DocId = '" & IIf(bReferenceDocId <> "", bReferenceDocId, bPurchOrder) & "' " & _
                   " And (Pod.Qty - Pod.ShippedQty) > 0 "

            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            With DtTemp
                Dgl1.RowCount = 1
                Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                        Dgl1.AgSelectedValue(Col1PurchOrder, I) = AgL.XNull(.Rows(I)("PurchOrder"))
                        Dgl1.AgSelectedValue(Col1Item, I) = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.AgSelectedValue(Col1SalesTaxGroup, I) = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                        Dgl1.Item(Col1DocQty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                        Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.000")
                        Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                        Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                        Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        If Val(Dgl1.Item(Col1DocQty, I).Value) > 0 Then
                            Dgl1.Item(Col1Qty, I).Value = Val(Dgl1.Item(Col1DocQty, I).Value) - Val(Dgl1.Item(Col1RejQty, I).Value)
                        End If
                    Next I
                End If
            End With
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFill_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFill.Click
        If TxtPurchOrder.Text <> "" Then Call ProcFillPurchOrderDetails(TxtPurchOrder.AgSelectedValue)
    End Sub

    Private Sub BtnRemoveFilter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRemoveFilter.Click
        BtnRemoveFilter.Tag = 1
    End Sub

    Private Sub AgCalcGrid1_Calculated() Handles AgCalcGrid1.Calculated
        AgCShowGrid1.MoveRec_FromCalcGrid()
        AgCShowGrid2.MoveRec_FromCalcGrid()
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try
            Dim bRData As String

            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo FROM QCDetail   L LEFT JOIN QC  H ON L.DocId = H.DocID WHERE L.PurchChallan  = '" & TxtDocId.Text & "' And IsNull(H.IsDeleted,0)=0) AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Quality Checking " & bRData & " created against Challan No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If


            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo FROM PurchInvoiceDetail   L LEFT JOIN PurchInvoice  H ON L.DocId = H.DocID WHERE L.PurchChallan  = '" & TxtDocId.Text & "'  And IsNull(H.IsDeleted,0)=0) AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Purchase Invoice " & bRData & " created against Challan No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function


    Private Sub ME_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub ME_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub TempGr_BaseFunction_CreateHelpDataSet() Handles Me.BaseFunction_CreateHelpDataSet
        mQry = "SELECT Sg.SubCode, Sg.DispName AS [Name], Sg.ManualCode, P.Currency, Sg.SalesTaxPostingGroup, " & _
                " IsNull(Sg.IsDeleted,0) As IsDeleted, IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status , " & _
                " Sg.Div_Code " & _
                " FROM Vendor P " & _
                " LEFT JOIN SubGroup Sg ON P.SubCode = Sg.subCode " & _
                " LEFT JOIN City C ON Sg.CityCode = C.CityCode  " & _
                " LEFT JOIN seaport SP ON P.SeaPort = SP.Code  " & _
                " LEFT JOIN City Dc ON sp.City = Dc.CityCode  " & _
                " Where " & AgL.PubSiteConditionCommonAc(AgL.PubIsHo, "Sg.Site_Code", AgL.PubSiteCode, "Sg.CommonAc") & " "
        HelpDataSet.Vendor = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Code AS Currency, IsNull(IsDeleted,0) AS IsDeleted " & _
                " FROM Currency " & _
                " ORDER BY Code "
        HelpDataSet.Currency = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Code, Description  FROM Structure ORDER BY Description "
        HelpDataSet.AgStructure = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Description AS Code, Description, IsNull(Active,0)  FROM PostingGroupSalesTaxParty "
        HelpDataSet.SalesTaxGroupParty = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT 'Qty' AS Code, 'Qty' AS Name " & _
                " Union ALL " & _
                " SELECT 'Measure' AS Code, 'Measure' AS Name"
        HelpDataSet.BillingType = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Po.DocID AS Code, Po.V_Type + '-' + Convert(NVARCHAR, Po.V_No) AS [Purch. Order No],Po.V_Date AS [Order Date], " & _
                " PO.ReferenceNo AS [Manual No],Po.VendorOrderNo AS [Vender Ord. No]," & _
                " Sg.DispName As VendorName, V1.PendingQty, " & _
                " Vt.NCat, isnull(Po.IsDeleted,0) AS IsDeleted, Po.Div_Code ,  " & _
                " isnull(Po.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "' ) AS Status ,  " & _
                " Po.Vendor, Po.Currency, Po.V_Date As PurchaseOrderDate, " & _
                " Po.MoveToLog " & _
                " FROM PurchOrder Po " & _
                " Left Join " & _
                " ( " & _
                " SELECT Pod.DocId, IsNull(Sum(Pod.Qty),0) - IsNull(Sum(Pod.ShippedQty),0) AS PendingQty " & _
                " FROM PurchOrderDetail Pod  " & _
                " GROUP BY Pod.DocId) AS V1 ON Po.DocId = V1.DocId " & _
                " LEFT JOIN Voucher_Type Vt On Po.V_Type = Vt.V_Type  " & _
                " LEFT JOIN SubGroup Sg On Po.Vendor = Sg.SubCode " & _
                " Where " & AgL.PubSiteCondition("Po.Site_Code", AgL.PubSiteCode) & " "
        HelpDataSet.PurchOrder = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT G.Code AS Code, G.Description AS Godown FROM Godown G where " & AgL.PubSiteCondition("G.Site_Code", AgL.PubSiteCode) & " "
        HelpDataSet.Godown = AgL.FillData(mQry, AgL.GCn)

        mQry = " Select F.Code, F.Description As Form, " & _
                " IsNull(F.IsDeleted,0) As IsDeleted,  " & _
                " IsNull(F.Status,'" & ClsMain.EntryStatus.Active & "') As Status    " & _
                " From Form_Master F " & _
                " Where F.Category = 'Road Permit'"
        HelpDataSet.Form = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT T.SubCode AS Code, Sg.DispName AS Name, Sg.ManualCode " & _
                " FROM Transporter T " & _
                " LEFT JOIN SubGroup Sg ON T.SubCode = Sg.SubCode "
        HelpDataSet.Transporter = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Rd.FormNo AS Code, Rd.FormNo, IsNull(Rd.IsUtilised,0) AS IsUtilised, " & _
                " Rd.IssueTo, Rd.Form " & _
                " FROM Form_ReceiveDetail Rd "
        HelpDataSet.FormNo = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT I.Code, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                    " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                    " I.MeasureUnit, I.Measure As MeasurePerPcs, 0 As Rate, 0 As PendingQty, " & _
                    " IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status, '' As PurchOrder " & _
                    " FROM Item I "
        HelpDataSet.Item = AgL.FillData(mQry, AgL.GCn)

        mQry = "SELECT Pod.Item AS Code, I.Description AS Item, Po.V_Type + '-' + Convert(nVarChar,Po.V_No) As PONo, " & _
                    " Po.DocId As PurchOrder, I.Unit, I.ItemType, " & _
                    " Pod.SalesTaxGroupItem As  SalesTaxPostingGroup, IsNull(Po.IsDeleted ,0) AS IsDeleted,  " & _
                    " Po.Div_Code, Pod.MeasureUnit, Pod.MeasurePerPcs, Pod.Rate, " & _
                    " Pod.Qty - Pod.ShippedQty As PendingQty, " & _
                    " IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                    " FROM PurchOrderDetail Pod " & _
                    " LEFT JOIN PurchOrder Po On Pod.DocId = Po.DocId " & _
                    " LEFT JOIN Item I ON Pod.Item = I.Code "
        HelpDataSet.PurchOrderItem = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT GIO.DocID AS Code, GIO.V_Type +'-'+ convert(NVARCHAR(5),GIO.V_No) AS [Entry No], " & _
                " GIO.VehicleNo ,GIO.LrNo,GIO.LrDate, GIO.Transporter, GIO.Driver,  " & _
                " IsNull(GIO.IsDeleted ,0) AS IsDeleted, GIO.Div_Code," & _
                " IsNull(GIO.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') As Status " & _
                " FROM GateInOut GIO "
        HelpDataSet.GateEntry = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Function Validate_PurchOrder(ByVal Sender As Object, Optional ByVal RowIndex As Integer = 0) As Boolean
        Dim DrTemp As DataRow() = Nothing
        Dim DsTemp As DataSet = Nothing
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Function
            Select Case Sender.Name
                Case Dgl1.Name
                    If Dgl1.AgSelectedValue(Col1PurchOrder, RowIndex) <> "" Then
                        DrTemp = Dgl1.AgHelpDataSet(Col1PurchOrder).Tables(0).Select("Code = '" & Dgl1.AgSelectedValue(Col1PurchOrder, RowIndex) & "' ")
                        If DrTemp.Length > 0 Then
                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                                MsgBox("Currently Purchase Order """ & Dgl1.Item(Col1PurchOrder, RowIndex).Value & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                                Dgl1.AgSelectedValue(Col1PurchOrder, RowIndex) = ""
                                Exit Function
                            End If

                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                                MsgBox("Currently Purchase Order """ & Dgl1.Item(Col1PurchOrder, RowIndex).Value & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                                Dgl1.AgSelectedValue(Col1PurchOrder, RowIndex) = ""
                                Exit Function
                            End If
                        End If
                    End If
                    Validate_PurchOrder = True

                Case TxtPurchOrder.Name
                    If TxtPurchOrder.AgSelectedValue <> "" Then
                        DrTemp = TxtPurchOrder.AgHelpDataSet().Tables(0).Select("Code = '" & TxtPurchOrder.AgSelectedValue & "' ")
                        If DrTemp.Length > 0 Then
                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("MoveToLog")), "") Then
                                MsgBox("Currently Purchase Order """ & TxtPurchOrder.Text & """ Is In Log For Modification." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                                TxtPurchOrder.AgSelectedValue = "" : Exit Function
                            End If

                            If Not AgL.StrCmp(AgL.XNull(DrTemp(0)("Status")), AgTemplate.ClsMain.EntryStatus.Active) Then
                                MsgBox("Currently Purchase Order """ & TxtPurchOrder.Text & """ Is Not In Active State." & vbCrLf & "Can't Continue...!", MsgBoxStyle.Information)
                                TxtPurchOrder.AgSelectedValue = "" : Exit Function
                            End If
                        End If
                    End If
                    Validate_PurchOrder = True
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function
    'Start Code By Satyam on 18/11/2011
    Private Sub ProcFillReferenceNo()
        If TxtReferenceNo.Text = "" Then
            If TxtV_Type.Text.ToString.Trim <> "" Or TxtV_Type.AgSelectedValue.Trim <> "" Then
                TxtReferenceNo.Text = TxtV_Type.AgSelectedValue + "-" + TxtV_No.Text
            End If
        End If
    End Sub

    'Code End By Satyam on 18/11/2011
End Class
